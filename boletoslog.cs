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
   public class boletoslog : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A1077BoletosId = (int)(Math.Round(NumberUtil.Val( GetPar( "BoletosId"), "."), 18, MidpointRounding.ToEven));
            n1077BoletosId = false;
            AssignAttri("", false, "A1077BoletosId", ((0==A1077BoletosId)&&IsIns( )||n1077BoletosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1077BoletosId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A1077BoletosId) ;
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
         Form.Meta.addItem("description", "Boletos Log", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtBoletosLogId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public boletoslog( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public boletoslog( IGxContext context )
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
         cmbBoletosLogOperacao = new GXCombobox();
         cmbBoletosLogStatusAnterior = new GXCombobox();
         cmbBoletosLogStatusNovo = new GXCombobox();
         chkBoletosLogSucesso = new GXCheckbox();
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
         if ( cmbBoletosLogOperacao.ItemCount > 0 )
         {
            A1102BoletosLogOperacao = cmbBoletosLogOperacao.getValidValue(A1102BoletosLogOperacao);
            n1102BoletosLogOperacao = false;
            AssignAttri("", false, "A1102BoletosLogOperacao", A1102BoletosLogOperacao);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbBoletosLogOperacao.CurrentValue = StringUtil.RTrim( A1102BoletosLogOperacao);
            AssignProp("", false, cmbBoletosLogOperacao_Internalname, "Values", cmbBoletosLogOperacao.ToJavascriptSource(), true);
         }
         if ( cmbBoletosLogStatusAnterior.ItemCount > 0 )
         {
            A1103BoletosLogStatusAnterior = cmbBoletosLogStatusAnterior.getValidValue(A1103BoletosLogStatusAnterior);
            n1103BoletosLogStatusAnterior = false;
            AssignAttri("", false, "A1103BoletosLogStatusAnterior", A1103BoletosLogStatusAnterior);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbBoletosLogStatusAnterior.CurrentValue = StringUtil.RTrim( A1103BoletosLogStatusAnterior);
            AssignProp("", false, cmbBoletosLogStatusAnterior_Internalname, "Values", cmbBoletosLogStatusAnterior.ToJavascriptSource(), true);
         }
         if ( cmbBoletosLogStatusNovo.ItemCount > 0 )
         {
            A1104BoletosLogStatusNovo = cmbBoletosLogStatusNovo.getValidValue(A1104BoletosLogStatusNovo);
            n1104BoletosLogStatusNovo = false;
            AssignAttri("", false, "A1104BoletosLogStatusNovo", A1104BoletosLogStatusNovo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbBoletosLogStatusNovo.CurrentValue = StringUtil.RTrim( A1104BoletosLogStatusNovo);
            AssignProp("", false, cmbBoletosLogStatusNovo_Internalname, "Values", cmbBoletosLogStatusNovo.ToJavascriptSource(), true);
         }
         A1108BoletosLogSucesso = StringUtil.StrToBool( StringUtil.BoolToStr( A1108BoletosLogSucesso));
         n1108BoletosLogSucesso = false;
         AssignAttri("", false, "A1108BoletosLogSucesso", A1108BoletosLogSucesso);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Boletos Log", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_BoletosLog.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_BoletosLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_BoletosLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_BoletosLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_BoletosLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_BoletosLog.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosLogId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosLogId_Internalname, "Log Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosLogId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1101BoletosLogId), 9, 0, ",", "")), StringUtil.LTrim( ((edtBoletosLogId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1101BoletosLogId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1101BoletosLogId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosLogId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBoletosLogId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_BoletosLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosId_Internalname, "Boletos Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosId_Internalname, ((0==A1077BoletosId)&&IsIns( )||n1077BoletosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1077BoletosId), 9, 0, ",", ""))), ((0==A1077BoletosId)&&IsIns( )||n1077BoletosId ? "" : StringUtil.LTrim( ((edtBoletosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1077BoletosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1077BoletosId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBoletosId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_BoletosLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbBoletosLogOperacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbBoletosLogOperacao_Internalname, "Log Operacao", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbBoletosLogOperacao, cmbBoletosLogOperacao_Internalname, StringUtil.RTrim( A1102BoletosLogOperacao), 1, cmbBoletosLogOperacao_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbBoletosLogOperacao.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_BoletosLog.htm");
         cmbBoletosLogOperacao.CurrentValue = StringUtil.RTrim( A1102BoletosLogOperacao);
         AssignProp("", false, cmbBoletosLogOperacao_Internalname, "Values", (string)(cmbBoletosLogOperacao.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbBoletosLogStatusAnterior_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbBoletosLogStatusAnterior_Internalname, "Status Anterior", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbBoletosLogStatusAnterior, cmbBoletosLogStatusAnterior_Internalname, StringUtil.RTrim( A1103BoletosLogStatusAnterior), 1, cmbBoletosLogStatusAnterior_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbBoletosLogStatusAnterior.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_BoletosLog.htm");
         cmbBoletosLogStatusAnterior.CurrentValue = StringUtil.RTrim( A1103BoletosLogStatusAnterior);
         AssignProp("", false, cmbBoletosLogStatusAnterior_Internalname, "Values", (string)(cmbBoletosLogStatusAnterior.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbBoletosLogStatusNovo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbBoletosLogStatusNovo_Internalname, "Status Novo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbBoletosLogStatusNovo, cmbBoletosLogStatusNovo_Internalname, StringUtil.RTrim( A1104BoletosLogStatusNovo), 1, cmbBoletosLogStatusNovo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbBoletosLogStatusNovo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_BoletosLog.htm");
         cmbBoletosLogStatusNovo.CurrentValue = StringUtil.RTrim( A1104BoletosLogStatusNovo);
         AssignProp("", false, cmbBoletosLogStatusNovo_Internalname, "Values", (string)(cmbBoletosLogStatusNovo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosLogRequisicao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosLogRequisicao_Internalname, "Requisição", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtBoletosLogRequisicao_Internalname, A1105BoletosLogRequisicao, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtBoletosLogRequisicao_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_BoletosLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosLogResponse_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosLogResponse_Internalname, "Reponse", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtBoletosLogResponse_Internalname, A1106BoletosLogResponse, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtBoletosLogResponse_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_BoletosLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosLogCodigoHttp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosLogCodigoHttp_Internalname, "Código HTTP", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosLogCodigoHttp_Internalname, ((0==A1107BoletosLogCodigoHttp)&&IsIns( )||n1107BoletosLogCodigoHttp ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1107BoletosLogCodigoHttp), 4, 0, ",", ""))), ((0==A1107BoletosLogCodigoHttp)&&IsIns( )||n1107BoletosLogCodigoHttp ? "" : StringUtil.LTrim( ((edtBoletosLogCodigoHttp_Enabled!=0) ? context.localUtil.Format( (decimal)(A1107BoletosLogCodigoHttp), "ZZZ9") : context.localUtil.Format( (decimal)(A1107BoletosLogCodigoHttp), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosLogCodigoHttp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBoletosLogCodigoHttp_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_BoletosLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkBoletosLogSucesso_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkBoletosLogSucesso_Internalname, "Sucesso", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkBoletosLogSucesso_Internalname, StringUtil.BoolToStr( A1108BoletosLogSucesso), "", "Sucesso", 1, chkBoletosLogSucesso.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(74, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,74);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosLogObservacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosLogObservacao_Internalname, "Observação", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBoletosLogObservacao_Internalname, A1109BoletosLogObservacao, StringUtil.RTrim( context.localUtil.Format( A1109BoletosLogObservacao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosLogObservacao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBoletosLogObservacao_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_BoletosLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtBoletosLogCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBoletosLogCreatedAt_Internalname, "Created At", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtBoletosLogCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtBoletosLogCreatedAt_Internalname, context.localUtil.TToC( A1110BoletosLogCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1110BoletosLogCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBoletosLogCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBoletosLogCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_BoletosLog.htm");
         GxWebStd.gx_bitmap( context, edtBoletosLogCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtBoletosLogCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_BoletosLog.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_BoletosLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_BoletosLog.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_BoletosLog.htm");
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
            Z1101BoletosLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1101BoletosLogId"), ",", "."), 18, MidpointRounding.ToEven));
            Z1102BoletosLogOperacao = cgiGet( "Z1102BoletosLogOperacao");
            n1102BoletosLogOperacao = (String.IsNullOrEmpty(StringUtil.RTrim( A1102BoletosLogOperacao)) ? true : false);
            Z1103BoletosLogStatusAnterior = cgiGet( "Z1103BoletosLogStatusAnterior");
            n1103BoletosLogStatusAnterior = (String.IsNullOrEmpty(StringUtil.RTrim( A1103BoletosLogStatusAnterior)) ? true : false);
            Z1104BoletosLogStatusNovo = cgiGet( "Z1104BoletosLogStatusNovo");
            n1104BoletosLogStatusNovo = (String.IsNullOrEmpty(StringUtil.RTrim( A1104BoletosLogStatusNovo)) ? true : false);
            Z1107BoletosLogCodigoHttp = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z1107BoletosLogCodigoHttp"), ",", "."), 18, MidpointRounding.ToEven));
            n1107BoletosLogCodigoHttp = ((0==A1107BoletosLogCodigoHttp) ? true : false);
            Z1108BoletosLogSucesso = StringUtil.StrToBool( cgiGet( "Z1108BoletosLogSucesso"));
            n1108BoletosLogSucesso = ((false==A1108BoletosLogSucesso) ? true : false);
            Z1109BoletosLogObservacao = cgiGet( "Z1109BoletosLogObservacao");
            n1109BoletosLogObservacao = (String.IsNullOrEmpty(StringUtil.RTrim( A1109BoletosLogObservacao)) ? true : false);
            Z1110BoletosLogCreatedAt = context.localUtil.CToT( cgiGet( "Z1110BoletosLogCreatedAt"), 0);
            n1110BoletosLogCreatedAt = ((DateTime.MinValue==A1110BoletosLogCreatedAt) ? true : false);
            Z1077BoletosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1077BoletosId"), ",", "."), 18, MidpointRounding.ToEven));
            n1077BoletosId = ((0==A1077BoletosId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtBoletosLogId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBoletosLogId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BOLETOSLOGID");
               AnyError = 1;
               GX_FocusControl = edtBoletosLogId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1101BoletosLogId = 0;
               AssignAttri("", false, "A1101BoletosLogId", StringUtil.LTrimStr( (decimal)(A1101BoletosLogId), 9, 0));
            }
            else
            {
               A1101BoletosLogId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtBoletosLogId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1101BoletosLogId", StringUtil.LTrimStr( (decimal)(A1101BoletosLogId), 9, 0));
            }
            n1077BoletosId = ((StringUtil.StrCmp(cgiGet( edtBoletosId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtBoletosId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBoletosId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BOLETOSID");
               AnyError = 1;
               GX_FocusControl = edtBoletosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1077BoletosId = 0;
               n1077BoletosId = false;
               AssignAttri("", false, "A1077BoletosId", (n1077BoletosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1077BoletosId), 9, 0, ".", ""))));
            }
            else
            {
               A1077BoletosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtBoletosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1077BoletosId", (n1077BoletosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1077BoletosId), 9, 0, ".", ""))));
            }
            cmbBoletosLogOperacao.CurrentValue = cgiGet( cmbBoletosLogOperacao_Internalname);
            A1102BoletosLogOperacao = cgiGet( cmbBoletosLogOperacao_Internalname);
            n1102BoletosLogOperacao = false;
            AssignAttri("", false, "A1102BoletosLogOperacao", A1102BoletosLogOperacao);
            n1102BoletosLogOperacao = (String.IsNullOrEmpty(StringUtil.RTrim( A1102BoletosLogOperacao)) ? true : false);
            cmbBoletosLogStatusAnterior.CurrentValue = cgiGet( cmbBoletosLogStatusAnterior_Internalname);
            A1103BoletosLogStatusAnterior = cgiGet( cmbBoletosLogStatusAnterior_Internalname);
            n1103BoletosLogStatusAnterior = false;
            AssignAttri("", false, "A1103BoletosLogStatusAnterior", A1103BoletosLogStatusAnterior);
            n1103BoletosLogStatusAnterior = (String.IsNullOrEmpty(StringUtil.RTrim( A1103BoletosLogStatusAnterior)) ? true : false);
            cmbBoletosLogStatusNovo.CurrentValue = cgiGet( cmbBoletosLogStatusNovo_Internalname);
            A1104BoletosLogStatusNovo = cgiGet( cmbBoletosLogStatusNovo_Internalname);
            n1104BoletosLogStatusNovo = false;
            AssignAttri("", false, "A1104BoletosLogStatusNovo", A1104BoletosLogStatusNovo);
            n1104BoletosLogStatusNovo = (String.IsNullOrEmpty(StringUtil.RTrim( A1104BoletosLogStatusNovo)) ? true : false);
            A1105BoletosLogRequisicao = cgiGet( edtBoletosLogRequisicao_Internalname);
            n1105BoletosLogRequisicao = false;
            AssignAttri("", false, "A1105BoletosLogRequisicao", A1105BoletosLogRequisicao);
            n1105BoletosLogRequisicao = (String.IsNullOrEmpty(StringUtil.RTrim( A1105BoletosLogRequisicao)) ? true : false);
            A1106BoletosLogResponse = cgiGet( edtBoletosLogResponse_Internalname);
            n1106BoletosLogResponse = false;
            AssignAttri("", false, "A1106BoletosLogResponse", A1106BoletosLogResponse);
            n1106BoletosLogResponse = (String.IsNullOrEmpty(StringUtil.RTrim( A1106BoletosLogResponse)) ? true : false);
            n1107BoletosLogCodigoHttp = ((StringUtil.StrCmp(cgiGet( edtBoletosLogCodigoHttp_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtBoletosLogCodigoHttp_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBoletosLogCodigoHttp_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BOLETOSLOGCODIGOHTTP");
               AnyError = 1;
               GX_FocusControl = edtBoletosLogCodigoHttp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1107BoletosLogCodigoHttp = 0;
               n1107BoletosLogCodigoHttp = false;
               AssignAttri("", false, "A1107BoletosLogCodigoHttp", (n1107BoletosLogCodigoHttp ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1107BoletosLogCodigoHttp), 4, 0, ".", ""))));
            }
            else
            {
               A1107BoletosLogCodigoHttp = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtBoletosLogCodigoHttp_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1107BoletosLogCodigoHttp", (n1107BoletosLogCodigoHttp ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1107BoletosLogCodigoHttp), 4, 0, ".", ""))));
            }
            A1108BoletosLogSucesso = StringUtil.StrToBool( cgiGet( chkBoletosLogSucesso_Internalname));
            n1108BoletosLogSucesso = false;
            AssignAttri("", false, "A1108BoletosLogSucesso", A1108BoletosLogSucesso);
            n1108BoletosLogSucesso = ((false==A1108BoletosLogSucesso) ? true : false);
            A1109BoletosLogObservacao = cgiGet( edtBoletosLogObservacao_Internalname);
            n1109BoletosLogObservacao = false;
            AssignAttri("", false, "A1109BoletosLogObservacao", A1109BoletosLogObservacao);
            n1109BoletosLogObservacao = (String.IsNullOrEmpty(StringUtil.RTrim( A1109BoletosLogObservacao)) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtBoletosLogCreatedAt_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Boletos Log Created At"}), 1, "BOLETOSLOGCREATEDAT");
               AnyError = 1;
               GX_FocusControl = edtBoletosLogCreatedAt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1110BoletosLogCreatedAt = (DateTime)(DateTime.MinValue);
               n1110BoletosLogCreatedAt = false;
               AssignAttri("", false, "A1110BoletosLogCreatedAt", context.localUtil.TToC( A1110BoletosLogCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1110BoletosLogCreatedAt = context.localUtil.CToT( cgiGet( edtBoletosLogCreatedAt_Internalname));
               n1110BoletosLogCreatedAt = false;
               AssignAttri("", false, "A1110BoletosLogCreatedAt", context.localUtil.TToC( A1110BoletosLogCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            n1110BoletosLogCreatedAt = ((DateTime.MinValue==A1110BoletosLogCreatedAt) ? true : false);
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
               A1101BoletosLogId = (int)(Math.Round(NumberUtil.Val( GetPar( "BoletosLogId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1101BoletosLogId", StringUtil.LTrimStr( (decimal)(A1101BoletosLogId), 9, 0));
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
               InitAll38112( ) ;
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
         DisableAttributes38112( ) ;
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

      protected void ResetCaption380( )
      {
      }

      protected void ZM38112( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1102BoletosLogOperacao = T00383_A1102BoletosLogOperacao[0];
               Z1103BoletosLogStatusAnterior = T00383_A1103BoletosLogStatusAnterior[0];
               Z1104BoletosLogStatusNovo = T00383_A1104BoletosLogStatusNovo[0];
               Z1107BoletosLogCodigoHttp = T00383_A1107BoletosLogCodigoHttp[0];
               Z1108BoletosLogSucesso = T00383_A1108BoletosLogSucesso[0];
               Z1109BoletosLogObservacao = T00383_A1109BoletosLogObservacao[0];
               Z1110BoletosLogCreatedAt = T00383_A1110BoletosLogCreatedAt[0];
               Z1077BoletosId = T00383_A1077BoletosId[0];
            }
            else
            {
               Z1102BoletosLogOperacao = A1102BoletosLogOperacao;
               Z1103BoletosLogStatusAnterior = A1103BoletosLogStatusAnterior;
               Z1104BoletosLogStatusNovo = A1104BoletosLogStatusNovo;
               Z1107BoletosLogCodigoHttp = A1107BoletosLogCodigoHttp;
               Z1108BoletosLogSucesso = A1108BoletosLogSucesso;
               Z1109BoletosLogObservacao = A1109BoletosLogObservacao;
               Z1110BoletosLogCreatedAt = A1110BoletosLogCreatedAt;
               Z1077BoletosId = A1077BoletosId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z1101BoletosLogId = A1101BoletosLogId;
            Z1102BoletosLogOperacao = A1102BoletosLogOperacao;
            Z1103BoletosLogStatusAnterior = A1103BoletosLogStatusAnterior;
            Z1104BoletosLogStatusNovo = A1104BoletosLogStatusNovo;
            Z1105BoletosLogRequisicao = A1105BoletosLogRequisicao;
            Z1106BoletosLogResponse = A1106BoletosLogResponse;
            Z1107BoletosLogCodigoHttp = A1107BoletosLogCodigoHttp;
            Z1108BoletosLogSucesso = A1108BoletosLogSucesso;
            Z1109BoletosLogObservacao = A1109BoletosLogObservacao;
            Z1110BoletosLogCreatedAt = A1110BoletosLogCreatedAt;
            Z1077BoletosId = A1077BoletosId;
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

      protected void Load38112( )
      {
         /* Using cursor T00385 */
         pr_default.execute(3, new Object[] {A1101BoletosLogId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound112 = 1;
            A1102BoletosLogOperacao = T00385_A1102BoletosLogOperacao[0];
            n1102BoletosLogOperacao = T00385_n1102BoletosLogOperacao[0];
            AssignAttri("", false, "A1102BoletosLogOperacao", A1102BoletosLogOperacao);
            A1103BoletosLogStatusAnterior = T00385_A1103BoletosLogStatusAnterior[0];
            n1103BoletosLogStatusAnterior = T00385_n1103BoletosLogStatusAnterior[0];
            AssignAttri("", false, "A1103BoletosLogStatusAnterior", A1103BoletosLogStatusAnterior);
            A1104BoletosLogStatusNovo = T00385_A1104BoletosLogStatusNovo[0];
            n1104BoletosLogStatusNovo = T00385_n1104BoletosLogStatusNovo[0];
            AssignAttri("", false, "A1104BoletosLogStatusNovo", A1104BoletosLogStatusNovo);
            A1105BoletosLogRequisicao = T00385_A1105BoletosLogRequisicao[0];
            n1105BoletosLogRequisicao = T00385_n1105BoletosLogRequisicao[0];
            AssignAttri("", false, "A1105BoletosLogRequisicao", A1105BoletosLogRequisicao);
            A1106BoletosLogResponse = T00385_A1106BoletosLogResponse[0];
            n1106BoletosLogResponse = T00385_n1106BoletosLogResponse[0];
            AssignAttri("", false, "A1106BoletosLogResponse", A1106BoletosLogResponse);
            A1107BoletosLogCodigoHttp = T00385_A1107BoletosLogCodigoHttp[0];
            n1107BoletosLogCodigoHttp = T00385_n1107BoletosLogCodigoHttp[0];
            AssignAttri("", false, "A1107BoletosLogCodigoHttp", ((0==A1107BoletosLogCodigoHttp)&&IsIns( )||n1107BoletosLogCodigoHttp ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1107BoletosLogCodigoHttp), 4, 0, ".", ""))));
            A1108BoletosLogSucesso = T00385_A1108BoletosLogSucesso[0];
            n1108BoletosLogSucesso = T00385_n1108BoletosLogSucesso[0];
            AssignAttri("", false, "A1108BoletosLogSucesso", A1108BoletosLogSucesso);
            A1109BoletosLogObservacao = T00385_A1109BoletosLogObservacao[0];
            n1109BoletosLogObservacao = T00385_n1109BoletosLogObservacao[0];
            AssignAttri("", false, "A1109BoletosLogObservacao", A1109BoletosLogObservacao);
            A1110BoletosLogCreatedAt = T00385_A1110BoletosLogCreatedAt[0];
            n1110BoletosLogCreatedAt = T00385_n1110BoletosLogCreatedAt[0];
            AssignAttri("", false, "A1110BoletosLogCreatedAt", context.localUtil.TToC( A1110BoletosLogCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A1077BoletosId = T00385_A1077BoletosId[0];
            n1077BoletosId = T00385_n1077BoletosId[0];
            AssignAttri("", false, "A1077BoletosId", ((0==A1077BoletosId)&&IsIns( )||n1077BoletosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1077BoletosId), 9, 0, ".", ""))));
            ZM38112( -4) ;
         }
         pr_default.close(3);
         OnLoadActions38112( ) ;
      }

      protected void OnLoadActions38112( )
      {
      }

      protected void CheckExtendedTable38112( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00384 */
         pr_default.execute(2, new Object[] {n1077BoletosId, A1077BoletosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A1077BoletosId) ) )
            {
               GX_msglist.addItem("Não existe 'Boleto'.", "ForeignKeyNotFound", 1, "BOLETOSID");
               AnyError = 1;
               GX_FocusControl = edtBoletosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A1102BoletosLogOperacao, "REGISTRO") == 0 ) || ( StringUtil.StrCmp(A1102BoletosLogOperacao, "CONSULTA") == 0 ) || ( StringUtil.StrCmp(A1102BoletosLogOperacao, "BAIXA") == 0 ) || ( StringUtil.StrCmp(A1102BoletosLogOperacao, "ALTERACAO") == 0 ) || ( StringUtil.StrCmp(A1102BoletosLogOperacao, "WEBHOOK") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1102BoletosLogOperacao)) ) )
         {
            GX_msglist.addItem("Campo Boletos Log Operacao fora do intervalo", "OutOfRange", 1, "BOLETOSLOGOPERACAO");
            AnyError = 1;
            GX_FocusControl = cmbBoletosLogOperacao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A1103BoletosLogStatusAnterior, "RASCUNHO") == 0 ) || ( StringUtil.StrCmp(A1103BoletosLogStatusAnterior, "REGISTRADO") == 0 ) || ( StringUtil.StrCmp(A1103BoletosLogStatusAnterior, "LIQUIDADO") == 0 ) || ( StringUtil.StrCmp(A1103BoletosLogStatusAnterior, "BAIXADO") == 0 ) || ( StringUtil.StrCmp(A1103BoletosLogStatusAnterior, "VENCIDO") == 0 ) || ( StringUtil.StrCmp(A1103BoletosLogStatusAnterior, "ERRO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1103BoletosLogStatusAnterior)) ) )
         {
            GX_msglist.addItem("Campo Boletos Log Status Anterior fora do intervalo", "OutOfRange", 1, "BOLETOSLOGSTATUSANTERIOR");
            AnyError = 1;
            GX_FocusControl = cmbBoletosLogStatusAnterior_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A1104BoletosLogStatusNovo, "RASCUNHO") == 0 ) || ( StringUtil.StrCmp(A1104BoletosLogStatusNovo, "REGISTRADO") == 0 ) || ( StringUtil.StrCmp(A1104BoletosLogStatusNovo, "LIQUIDADO") == 0 ) || ( StringUtil.StrCmp(A1104BoletosLogStatusNovo, "BAIXADO") == 0 ) || ( StringUtil.StrCmp(A1104BoletosLogStatusNovo, "VENCIDO") == 0 ) || ( StringUtil.StrCmp(A1104BoletosLogStatusNovo, "ERRO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1104BoletosLogStatusNovo)) ) )
         {
            GX_msglist.addItem("Campo Boletos Log Status Novo fora do intervalo", "OutOfRange", 1, "BOLETOSLOGSTATUSNOVO");
            AnyError = 1;
            GX_FocusControl = cmbBoletosLogStatusNovo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors38112( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( int A1077BoletosId )
      {
         /* Using cursor T00386 */
         pr_default.execute(4, new Object[] {n1077BoletosId, A1077BoletosId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A1077BoletosId) ) )
            {
               GX_msglist.addItem("Não existe 'Boleto'.", "ForeignKeyNotFound", 1, "BOLETOSID");
               AnyError = 1;
               GX_FocusControl = edtBoletosId_Internalname;
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

      protected void GetKey38112( )
      {
         /* Using cursor T00387 */
         pr_default.execute(5, new Object[] {A1101BoletosLogId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound112 = 1;
         }
         else
         {
            RcdFound112 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00383 */
         pr_default.execute(1, new Object[] {A1101BoletosLogId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM38112( 4) ;
            RcdFound112 = 1;
            A1101BoletosLogId = T00383_A1101BoletosLogId[0];
            AssignAttri("", false, "A1101BoletosLogId", StringUtil.LTrimStr( (decimal)(A1101BoletosLogId), 9, 0));
            A1102BoletosLogOperacao = T00383_A1102BoletosLogOperacao[0];
            n1102BoletosLogOperacao = T00383_n1102BoletosLogOperacao[0];
            AssignAttri("", false, "A1102BoletosLogOperacao", A1102BoletosLogOperacao);
            A1103BoletosLogStatusAnterior = T00383_A1103BoletosLogStatusAnterior[0];
            n1103BoletosLogStatusAnterior = T00383_n1103BoletosLogStatusAnterior[0];
            AssignAttri("", false, "A1103BoletosLogStatusAnterior", A1103BoletosLogStatusAnterior);
            A1104BoletosLogStatusNovo = T00383_A1104BoletosLogStatusNovo[0];
            n1104BoletosLogStatusNovo = T00383_n1104BoletosLogStatusNovo[0];
            AssignAttri("", false, "A1104BoletosLogStatusNovo", A1104BoletosLogStatusNovo);
            A1105BoletosLogRequisicao = T00383_A1105BoletosLogRequisicao[0];
            n1105BoletosLogRequisicao = T00383_n1105BoletosLogRequisicao[0];
            AssignAttri("", false, "A1105BoletosLogRequisicao", A1105BoletosLogRequisicao);
            A1106BoletosLogResponse = T00383_A1106BoletosLogResponse[0];
            n1106BoletosLogResponse = T00383_n1106BoletosLogResponse[0];
            AssignAttri("", false, "A1106BoletosLogResponse", A1106BoletosLogResponse);
            A1107BoletosLogCodigoHttp = T00383_A1107BoletosLogCodigoHttp[0];
            n1107BoletosLogCodigoHttp = T00383_n1107BoletosLogCodigoHttp[0];
            AssignAttri("", false, "A1107BoletosLogCodigoHttp", ((0==A1107BoletosLogCodigoHttp)&&IsIns( )||n1107BoletosLogCodigoHttp ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1107BoletosLogCodigoHttp), 4, 0, ".", ""))));
            A1108BoletosLogSucesso = T00383_A1108BoletosLogSucesso[0];
            n1108BoletosLogSucesso = T00383_n1108BoletosLogSucesso[0];
            AssignAttri("", false, "A1108BoletosLogSucesso", A1108BoletosLogSucesso);
            A1109BoletosLogObservacao = T00383_A1109BoletosLogObservacao[0];
            n1109BoletosLogObservacao = T00383_n1109BoletosLogObservacao[0];
            AssignAttri("", false, "A1109BoletosLogObservacao", A1109BoletosLogObservacao);
            A1110BoletosLogCreatedAt = T00383_A1110BoletosLogCreatedAt[0];
            n1110BoletosLogCreatedAt = T00383_n1110BoletosLogCreatedAt[0];
            AssignAttri("", false, "A1110BoletosLogCreatedAt", context.localUtil.TToC( A1110BoletosLogCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A1077BoletosId = T00383_A1077BoletosId[0];
            n1077BoletosId = T00383_n1077BoletosId[0];
            AssignAttri("", false, "A1077BoletosId", ((0==A1077BoletosId)&&IsIns( )||n1077BoletosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1077BoletosId), 9, 0, ".", ""))));
            Z1101BoletosLogId = A1101BoletosLogId;
            sMode112 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load38112( ) ;
            if ( AnyError == 1 )
            {
               RcdFound112 = 0;
               InitializeNonKey38112( ) ;
            }
            Gx_mode = sMode112;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound112 = 0;
            InitializeNonKey38112( ) ;
            sMode112 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode112;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey38112( ) ;
         if ( RcdFound112 == 0 )
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
         RcdFound112 = 0;
         /* Using cursor T00388 */
         pr_default.execute(6, new Object[] {A1101BoletosLogId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00388_A1101BoletosLogId[0] < A1101BoletosLogId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00388_A1101BoletosLogId[0] > A1101BoletosLogId ) ) )
            {
               A1101BoletosLogId = T00388_A1101BoletosLogId[0];
               AssignAttri("", false, "A1101BoletosLogId", StringUtil.LTrimStr( (decimal)(A1101BoletosLogId), 9, 0));
               RcdFound112 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound112 = 0;
         /* Using cursor T00389 */
         pr_default.execute(7, new Object[] {A1101BoletosLogId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00389_A1101BoletosLogId[0] > A1101BoletosLogId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00389_A1101BoletosLogId[0] < A1101BoletosLogId ) ) )
            {
               A1101BoletosLogId = T00389_A1101BoletosLogId[0];
               AssignAttri("", false, "A1101BoletosLogId", StringUtil.LTrimStr( (decimal)(A1101BoletosLogId), 9, 0));
               RcdFound112 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey38112( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtBoletosLogId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert38112( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound112 == 1 )
            {
               if ( A1101BoletosLogId != Z1101BoletosLogId )
               {
                  A1101BoletosLogId = Z1101BoletosLogId;
                  AssignAttri("", false, "A1101BoletosLogId", StringUtil.LTrimStr( (decimal)(A1101BoletosLogId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "BOLETOSLOGID");
                  AnyError = 1;
                  GX_FocusControl = edtBoletosLogId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtBoletosLogId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update38112( ) ;
                  GX_FocusControl = edtBoletosLogId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1101BoletosLogId != Z1101BoletosLogId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtBoletosLogId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert38112( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "BOLETOSLOGID");
                     AnyError = 1;
                     GX_FocusControl = edtBoletosLogId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtBoletosLogId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert38112( ) ;
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
         if ( A1101BoletosLogId != Z1101BoletosLogId )
         {
            A1101BoletosLogId = Z1101BoletosLogId;
            AssignAttri("", false, "A1101BoletosLogId", StringUtil.LTrimStr( (decimal)(A1101BoletosLogId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "BOLETOSLOGID");
            AnyError = 1;
            GX_FocusControl = edtBoletosLogId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtBoletosLogId_Internalname;
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
         if ( RcdFound112 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "BOLETOSLOGID");
            AnyError = 1;
            GX_FocusControl = edtBoletosLogId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtBoletosId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart38112( ) ;
         if ( RcdFound112 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtBoletosId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd38112( ) ;
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
         if ( RcdFound112 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtBoletosId_Internalname;
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
         if ( RcdFound112 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtBoletosId_Internalname;
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
         ScanStart38112( ) ;
         if ( RcdFound112 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound112 != 0 )
            {
               ScanNext38112( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtBoletosId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd38112( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency38112( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00382 */
            pr_default.execute(0, new Object[] {A1101BoletosLogId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"BoletosLog"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1102BoletosLogOperacao, T00382_A1102BoletosLogOperacao[0]) != 0 ) || ( StringUtil.StrCmp(Z1103BoletosLogStatusAnterior, T00382_A1103BoletosLogStatusAnterior[0]) != 0 ) || ( StringUtil.StrCmp(Z1104BoletosLogStatusNovo, T00382_A1104BoletosLogStatusNovo[0]) != 0 ) || ( Z1107BoletosLogCodigoHttp != T00382_A1107BoletosLogCodigoHttp[0] ) || ( Z1108BoletosLogSucesso != T00382_A1108BoletosLogSucesso[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1109BoletosLogObservacao, T00382_A1109BoletosLogObservacao[0]) != 0 ) || ( Z1110BoletosLogCreatedAt != T00382_A1110BoletosLogCreatedAt[0] ) || ( Z1077BoletosId != T00382_A1077BoletosId[0] ) )
            {
               if ( StringUtil.StrCmp(Z1102BoletosLogOperacao, T00382_A1102BoletosLogOperacao[0]) != 0 )
               {
                  GXUtil.WriteLog("boletoslog:[seudo value changed for attri]"+"BoletosLogOperacao");
                  GXUtil.WriteLogRaw("Old: ",Z1102BoletosLogOperacao);
                  GXUtil.WriteLogRaw("Current: ",T00382_A1102BoletosLogOperacao[0]);
               }
               if ( StringUtil.StrCmp(Z1103BoletosLogStatusAnterior, T00382_A1103BoletosLogStatusAnterior[0]) != 0 )
               {
                  GXUtil.WriteLog("boletoslog:[seudo value changed for attri]"+"BoletosLogStatusAnterior");
                  GXUtil.WriteLogRaw("Old: ",Z1103BoletosLogStatusAnterior);
                  GXUtil.WriteLogRaw("Current: ",T00382_A1103BoletosLogStatusAnterior[0]);
               }
               if ( StringUtil.StrCmp(Z1104BoletosLogStatusNovo, T00382_A1104BoletosLogStatusNovo[0]) != 0 )
               {
                  GXUtil.WriteLog("boletoslog:[seudo value changed for attri]"+"BoletosLogStatusNovo");
                  GXUtil.WriteLogRaw("Old: ",Z1104BoletosLogStatusNovo);
                  GXUtil.WriteLogRaw("Current: ",T00382_A1104BoletosLogStatusNovo[0]);
               }
               if ( Z1107BoletosLogCodigoHttp != T00382_A1107BoletosLogCodigoHttp[0] )
               {
                  GXUtil.WriteLog("boletoslog:[seudo value changed for attri]"+"BoletosLogCodigoHttp");
                  GXUtil.WriteLogRaw("Old: ",Z1107BoletosLogCodigoHttp);
                  GXUtil.WriteLogRaw("Current: ",T00382_A1107BoletosLogCodigoHttp[0]);
               }
               if ( Z1108BoletosLogSucesso != T00382_A1108BoletosLogSucesso[0] )
               {
                  GXUtil.WriteLog("boletoslog:[seudo value changed for attri]"+"BoletosLogSucesso");
                  GXUtil.WriteLogRaw("Old: ",Z1108BoletosLogSucesso);
                  GXUtil.WriteLogRaw("Current: ",T00382_A1108BoletosLogSucesso[0]);
               }
               if ( StringUtil.StrCmp(Z1109BoletosLogObservacao, T00382_A1109BoletosLogObservacao[0]) != 0 )
               {
                  GXUtil.WriteLog("boletoslog:[seudo value changed for attri]"+"BoletosLogObservacao");
                  GXUtil.WriteLogRaw("Old: ",Z1109BoletosLogObservacao);
                  GXUtil.WriteLogRaw("Current: ",T00382_A1109BoletosLogObservacao[0]);
               }
               if ( Z1110BoletosLogCreatedAt != T00382_A1110BoletosLogCreatedAt[0] )
               {
                  GXUtil.WriteLog("boletoslog:[seudo value changed for attri]"+"BoletosLogCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z1110BoletosLogCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00382_A1110BoletosLogCreatedAt[0]);
               }
               if ( Z1077BoletosId != T00382_A1077BoletosId[0] )
               {
                  GXUtil.WriteLog("boletoslog:[seudo value changed for attri]"+"BoletosId");
                  GXUtil.WriteLogRaw("Old: ",Z1077BoletosId);
                  GXUtil.WriteLogRaw("Current: ",T00382_A1077BoletosId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"BoletosLog"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert38112( )
      {
         BeforeValidate38112( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable38112( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM38112( 0) ;
            CheckOptimisticConcurrency38112( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm38112( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert38112( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003810 */
                     pr_default.execute(8, new Object[] {n1102BoletosLogOperacao, A1102BoletosLogOperacao, n1103BoletosLogStatusAnterior, A1103BoletosLogStatusAnterior, n1104BoletosLogStatusNovo, A1104BoletosLogStatusNovo, n1105BoletosLogRequisicao, A1105BoletosLogRequisicao, n1106BoletosLogResponse, A1106BoletosLogResponse, n1107BoletosLogCodigoHttp, A1107BoletosLogCodigoHttp, n1108BoletosLogSucesso, A1108BoletosLogSucesso, n1109BoletosLogObservacao, A1109BoletosLogObservacao, n1110BoletosLogCreatedAt, A1110BoletosLogCreatedAt, n1077BoletosId, A1077BoletosId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T003811 */
                     pr_default.execute(9);
                     A1101BoletosLogId = T003811_A1101BoletosLogId[0];
                     AssignAttri("", false, "A1101BoletosLogId", StringUtil.LTrimStr( (decimal)(A1101BoletosLogId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("BoletosLog");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption380( ) ;
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
               Load38112( ) ;
            }
            EndLevel38112( ) ;
         }
         CloseExtendedTableCursors38112( ) ;
      }

      protected void Update38112( )
      {
         BeforeValidate38112( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable38112( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency38112( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm38112( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate38112( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003812 */
                     pr_default.execute(10, new Object[] {n1102BoletosLogOperacao, A1102BoletosLogOperacao, n1103BoletosLogStatusAnterior, A1103BoletosLogStatusAnterior, n1104BoletosLogStatusNovo, A1104BoletosLogStatusNovo, n1105BoletosLogRequisicao, A1105BoletosLogRequisicao, n1106BoletosLogResponse, A1106BoletosLogResponse, n1107BoletosLogCodigoHttp, A1107BoletosLogCodigoHttp, n1108BoletosLogSucesso, A1108BoletosLogSucesso, n1109BoletosLogObservacao, A1109BoletosLogObservacao, n1110BoletosLogCreatedAt, A1110BoletosLogCreatedAt, n1077BoletosId, A1077BoletosId, A1101BoletosLogId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("BoletosLog");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"BoletosLog"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate38112( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption380( ) ;
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
            EndLevel38112( ) ;
         }
         CloseExtendedTableCursors38112( ) ;
      }

      protected void DeferredUpdate38112( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate38112( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency38112( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls38112( ) ;
            AfterConfirm38112( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete38112( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003813 */
                  pr_default.execute(11, new Object[] {A1101BoletosLogId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("BoletosLog");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound112 == 0 )
                        {
                           InitAll38112( ) ;
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
                        ResetCaption380( ) ;
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
         sMode112 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel38112( ) ;
         Gx_mode = sMode112;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls38112( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel38112( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete38112( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues380( ) ;
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

      public void ScanStart38112( )
      {
         /* Using cursor T003814 */
         pr_default.execute(12);
         RcdFound112 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound112 = 1;
            A1101BoletosLogId = T003814_A1101BoletosLogId[0];
            AssignAttri("", false, "A1101BoletosLogId", StringUtil.LTrimStr( (decimal)(A1101BoletosLogId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext38112( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound112 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound112 = 1;
            A1101BoletosLogId = T003814_A1101BoletosLogId[0];
            AssignAttri("", false, "A1101BoletosLogId", StringUtil.LTrimStr( (decimal)(A1101BoletosLogId), 9, 0));
         }
      }

      protected void ScanEnd38112( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm38112( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert38112( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate38112( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete38112( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete38112( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate38112( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes38112( )
      {
         edtBoletosLogId_Enabled = 0;
         AssignProp("", false, edtBoletosLogId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosLogId_Enabled), 5, 0), true);
         edtBoletosId_Enabled = 0;
         AssignProp("", false, edtBoletosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosId_Enabled), 5, 0), true);
         cmbBoletosLogOperacao.Enabled = 0;
         AssignProp("", false, cmbBoletosLogOperacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbBoletosLogOperacao.Enabled), 5, 0), true);
         cmbBoletosLogStatusAnterior.Enabled = 0;
         AssignProp("", false, cmbBoletosLogStatusAnterior_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbBoletosLogStatusAnterior.Enabled), 5, 0), true);
         cmbBoletosLogStatusNovo.Enabled = 0;
         AssignProp("", false, cmbBoletosLogStatusNovo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbBoletosLogStatusNovo.Enabled), 5, 0), true);
         edtBoletosLogRequisicao_Enabled = 0;
         AssignProp("", false, edtBoletosLogRequisicao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosLogRequisicao_Enabled), 5, 0), true);
         edtBoletosLogResponse_Enabled = 0;
         AssignProp("", false, edtBoletosLogResponse_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosLogResponse_Enabled), 5, 0), true);
         edtBoletosLogCodigoHttp_Enabled = 0;
         AssignProp("", false, edtBoletosLogCodigoHttp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosLogCodigoHttp_Enabled), 5, 0), true);
         chkBoletosLogSucesso.Enabled = 0;
         AssignProp("", false, chkBoletosLogSucesso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkBoletosLogSucesso.Enabled), 5, 0), true);
         edtBoletosLogObservacao_Enabled = 0;
         AssignProp("", false, edtBoletosLogObservacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosLogObservacao_Enabled), 5, 0), true);
         edtBoletosLogCreatedAt_Enabled = 0;
         AssignProp("", false, edtBoletosLogCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBoletosLogCreatedAt_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes38112( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues380( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("boletoslog") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1101BoletosLogId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1101BoletosLogId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1102BoletosLogOperacao", Z1102BoletosLogOperacao);
         GxWebStd.gx_hidden_field( context, "Z1103BoletosLogStatusAnterior", Z1103BoletosLogStatusAnterior);
         GxWebStd.gx_hidden_field( context, "Z1104BoletosLogStatusNovo", Z1104BoletosLogStatusNovo);
         GxWebStd.gx_hidden_field( context, "Z1107BoletosLogCodigoHttp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1107BoletosLogCodigoHttp), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z1108BoletosLogSucesso", Z1108BoletosLogSucesso);
         GxWebStd.gx_hidden_field( context, "Z1109BoletosLogObservacao", Z1109BoletosLogObservacao);
         GxWebStd.gx_hidden_field( context, "Z1110BoletosLogCreatedAt", context.localUtil.TToC( Z1110BoletosLogCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1077BoletosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1077BoletosId), 9, 0, ",", "")));
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
         return formatLink("boletoslog")  ;
      }

      public override string GetPgmname( )
      {
         return "BoletosLog" ;
      }

      public override string GetPgmdesc( )
      {
         return "Boletos Log" ;
      }

      protected void InitializeNonKey38112( )
      {
         A1077BoletosId = 0;
         n1077BoletosId = false;
         AssignAttri("", false, "A1077BoletosId", ((0==A1077BoletosId)&&IsIns( )||n1077BoletosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1077BoletosId), 9, 0, ".", ""))));
         n1077BoletosId = ((0==A1077BoletosId) ? true : false);
         A1102BoletosLogOperacao = "";
         n1102BoletosLogOperacao = false;
         AssignAttri("", false, "A1102BoletosLogOperacao", A1102BoletosLogOperacao);
         n1102BoletosLogOperacao = (String.IsNullOrEmpty(StringUtil.RTrim( A1102BoletosLogOperacao)) ? true : false);
         A1103BoletosLogStatusAnterior = "";
         n1103BoletosLogStatusAnterior = false;
         AssignAttri("", false, "A1103BoletosLogStatusAnterior", A1103BoletosLogStatusAnterior);
         n1103BoletosLogStatusAnterior = (String.IsNullOrEmpty(StringUtil.RTrim( A1103BoletosLogStatusAnterior)) ? true : false);
         A1104BoletosLogStatusNovo = "";
         n1104BoletosLogStatusNovo = false;
         AssignAttri("", false, "A1104BoletosLogStatusNovo", A1104BoletosLogStatusNovo);
         n1104BoletosLogStatusNovo = (String.IsNullOrEmpty(StringUtil.RTrim( A1104BoletosLogStatusNovo)) ? true : false);
         A1105BoletosLogRequisicao = "";
         n1105BoletosLogRequisicao = false;
         AssignAttri("", false, "A1105BoletosLogRequisicao", A1105BoletosLogRequisicao);
         n1105BoletosLogRequisicao = (String.IsNullOrEmpty(StringUtil.RTrim( A1105BoletosLogRequisicao)) ? true : false);
         A1106BoletosLogResponse = "";
         n1106BoletosLogResponse = false;
         AssignAttri("", false, "A1106BoletosLogResponse", A1106BoletosLogResponse);
         n1106BoletosLogResponse = (String.IsNullOrEmpty(StringUtil.RTrim( A1106BoletosLogResponse)) ? true : false);
         A1107BoletosLogCodigoHttp = 0;
         n1107BoletosLogCodigoHttp = false;
         AssignAttri("", false, "A1107BoletosLogCodigoHttp", ((0==A1107BoletosLogCodigoHttp)&&IsIns( )||n1107BoletosLogCodigoHttp ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1107BoletosLogCodigoHttp), 4, 0, ".", ""))));
         n1107BoletosLogCodigoHttp = ((0==A1107BoletosLogCodigoHttp) ? true : false);
         A1108BoletosLogSucesso = false;
         n1108BoletosLogSucesso = false;
         AssignAttri("", false, "A1108BoletosLogSucesso", A1108BoletosLogSucesso);
         n1108BoletosLogSucesso = ((false==A1108BoletosLogSucesso) ? true : false);
         A1109BoletosLogObservacao = "";
         n1109BoletosLogObservacao = false;
         AssignAttri("", false, "A1109BoletosLogObservacao", A1109BoletosLogObservacao);
         n1109BoletosLogObservacao = (String.IsNullOrEmpty(StringUtil.RTrim( A1109BoletosLogObservacao)) ? true : false);
         A1110BoletosLogCreatedAt = (DateTime)(DateTime.MinValue);
         n1110BoletosLogCreatedAt = false;
         AssignAttri("", false, "A1110BoletosLogCreatedAt", context.localUtil.TToC( A1110BoletosLogCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         n1110BoletosLogCreatedAt = ((DateTime.MinValue==A1110BoletosLogCreatedAt) ? true : false);
         Z1102BoletosLogOperacao = "";
         Z1103BoletosLogStatusAnterior = "";
         Z1104BoletosLogStatusNovo = "";
         Z1107BoletosLogCodigoHttp = 0;
         Z1108BoletosLogSucesso = false;
         Z1109BoletosLogObservacao = "";
         Z1110BoletosLogCreatedAt = (DateTime)(DateTime.MinValue);
         Z1077BoletosId = 0;
      }

      protected void InitAll38112( )
      {
         A1101BoletosLogId = 0;
         AssignAttri("", false, "A1101BoletosLogId", StringUtil.LTrimStr( (decimal)(A1101BoletosLogId), 9, 0));
         InitializeNonKey38112( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019223070", true, true);
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
         context.AddJavascriptSource("boletoslog.js", "?202561019223070", false, true);
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
         edtBoletosLogId_Internalname = "BOLETOSLOGID";
         edtBoletosId_Internalname = "BOLETOSID";
         cmbBoletosLogOperacao_Internalname = "BOLETOSLOGOPERACAO";
         cmbBoletosLogStatusAnterior_Internalname = "BOLETOSLOGSTATUSANTERIOR";
         cmbBoletosLogStatusNovo_Internalname = "BOLETOSLOGSTATUSNOVO";
         edtBoletosLogRequisicao_Internalname = "BOLETOSLOGREQUISICAO";
         edtBoletosLogResponse_Internalname = "BOLETOSLOGRESPONSE";
         edtBoletosLogCodigoHttp_Internalname = "BOLETOSLOGCODIGOHTTP";
         chkBoletosLogSucesso_Internalname = "BOLETOSLOGSUCESSO";
         edtBoletosLogObservacao_Internalname = "BOLETOSLOGOBSERVACAO";
         edtBoletosLogCreatedAt_Internalname = "BOLETOSLOGCREATEDAT";
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
         Form.Caption = "Boletos Log";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtBoletosLogCreatedAt_Jsonclick = "";
         edtBoletosLogCreatedAt_Enabled = 1;
         edtBoletosLogObservacao_Jsonclick = "";
         edtBoletosLogObservacao_Enabled = 1;
         chkBoletosLogSucesso.Enabled = 1;
         edtBoletosLogCodigoHttp_Jsonclick = "";
         edtBoletosLogCodigoHttp_Enabled = 1;
         edtBoletosLogResponse_Enabled = 1;
         edtBoletosLogRequisicao_Enabled = 1;
         cmbBoletosLogStatusNovo_Jsonclick = "";
         cmbBoletosLogStatusNovo.Enabled = 1;
         cmbBoletosLogStatusAnterior_Jsonclick = "";
         cmbBoletosLogStatusAnterior.Enabled = 1;
         cmbBoletosLogOperacao_Jsonclick = "";
         cmbBoletosLogOperacao.Enabled = 1;
         edtBoletosId_Jsonclick = "";
         edtBoletosId_Enabled = 1;
         edtBoletosLogId_Jsonclick = "";
         edtBoletosLogId_Enabled = 1;
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
         cmbBoletosLogOperacao.Name = "BOLETOSLOGOPERACAO";
         cmbBoletosLogOperacao.WebTags = "";
         cmbBoletosLogOperacao.addItem("REGISTRO", "Registro", 0);
         cmbBoletosLogOperacao.addItem("CONSULTA", "Consulta", 0);
         cmbBoletosLogOperacao.addItem("BAIXA", "Baixa", 0);
         cmbBoletosLogOperacao.addItem("ALTERACAO", "Alteração", 0);
         cmbBoletosLogOperacao.addItem("WEBHOOK", "Webhook", 0);
         if ( cmbBoletosLogOperacao.ItemCount > 0 )
         {
            A1102BoletosLogOperacao = cmbBoletosLogOperacao.getValidValue(A1102BoletosLogOperacao);
            n1102BoletosLogOperacao = false;
            AssignAttri("", false, "A1102BoletosLogOperacao", A1102BoletosLogOperacao);
         }
         cmbBoletosLogStatusAnterior.Name = "BOLETOSLOGSTATUSANTERIOR";
         cmbBoletosLogStatusAnterior.WebTags = "";
         cmbBoletosLogStatusAnterior.addItem("RASCUNHO", "Rascunho", 0);
         cmbBoletosLogStatusAnterior.addItem("REGISTRADO", "Registrado", 0);
         cmbBoletosLogStatusAnterior.addItem("LIQUIDADO", "Liquidado", 0);
         cmbBoletosLogStatusAnterior.addItem("BAIXADO", "Baixado", 0);
         cmbBoletosLogStatusAnterior.addItem("VENCIDO", "Vencido", 0);
         cmbBoletosLogStatusAnterior.addItem("ERRO", "Erro", 0);
         if ( cmbBoletosLogStatusAnterior.ItemCount > 0 )
         {
            A1103BoletosLogStatusAnterior = cmbBoletosLogStatusAnterior.getValidValue(A1103BoletosLogStatusAnterior);
            n1103BoletosLogStatusAnterior = false;
            AssignAttri("", false, "A1103BoletosLogStatusAnterior", A1103BoletosLogStatusAnterior);
         }
         cmbBoletosLogStatusNovo.Name = "BOLETOSLOGSTATUSNOVO";
         cmbBoletosLogStatusNovo.WebTags = "";
         cmbBoletosLogStatusNovo.addItem("RASCUNHO", "Rascunho", 0);
         cmbBoletosLogStatusNovo.addItem("REGISTRADO", "Registrado", 0);
         cmbBoletosLogStatusNovo.addItem("LIQUIDADO", "Liquidado", 0);
         cmbBoletosLogStatusNovo.addItem("BAIXADO", "Baixado", 0);
         cmbBoletosLogStatusNovo.addItem("VENCIDO", "Vencido", 0);
         cmbBoletosLogStatusNovo.addItem("ERRO", "Erro", 0);
         if ( cmbBoletosLogStatusNovo.ItemCount > 0 )
         {
            A1104BoletosLogStatusNovo = cmbBoletosLogStatusNovo.getValidValue(A1104BoletosLogStatusNovo);
            n1104BoletosLogStatusNovo = false;
            AssignAttri("", false, "A1104BoletosLogStatusNovo", A1104BoletosLogStatusNovo);
         }
         chkBoletosLogSucesso.Name = "BOLETOSLOGSUCESSO";
         chkBoletosLogSucesso.WebTags = "";
         chkBoletosLogSucesso.Caption = "Sucesso";
         AssignProp("", false, chkBoletosLogSucesso_Internalname, "TitleCaption", chkBoletosLogSucesso.Caption, true);
         chkBoletosLogSucesso.CheckedValue = "false";
         A1108BoletosLogSucesso = StringUtil.StrToBool( StringUtil.BoolToStr( A1108BoletosLogSucesso));
         n1108BoletosLogSucesso = false;
         AssignAttri("", false, "A1108BoletosLogSucesso", A1108BoletosLogSucesso);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtBoletosId_Internalname;
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

      public void Valid_Boletoslogid( )
      {
         n1104BoletosLogStatusNovo = false;
         A1104BoletosLogStatusNovo = cmbBoletosLogStatusNovo.CurrentValue;
         n1104BoletosLogStatusNovo = false;
         cmbBoletosLogStatusNovo.CurrentValue = A1104BoletosLogStatusNovo;
         n1103BoletosLogStatusAnterior = false;
         A1103BoletosLogStatusAnterior = cmbBoletosLogStatusAnterior.CurrentValue;
         n1103BoletosLogStatusAnterior = false;
         cmbBoletosLogStatusAnterior.CurrentValue = A1103BoletosLogStatusAnterior;
         n1102BoletosLogOperacao = false;
         A1102BoletosLogOperacao = cmbBoletosLogOperacao.CurrentValue;
         n1102BoletosLogOperacao = false;
         cmbBoletosLogOperacao.CurrentValue = A1102BoletosLogOperacao;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbBoletosLogOperacao.ItemCount > 0 )
         {
            A1102BoletosLogOperacao = cmbBoletosLogOperacao.getValidValue(A1102BoletosLogOperacao);
            n1102BoletosLogOperacao = false;
            cmbBoletosLogOperacao.CurrentValue = A1102BoletosLogOperacao;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbBoletosLogOperacao.CurrentValue = StringUtil.RTrim( A1102BoletosLogOperacao);
         }
         if ( cmbBoletosLogStatusAnterior.ItemCount > 0 )
         {
            A1103BoletosLogStatusAnterior = cmbBoletosLogStatusAnterior.getValidValue(A1103BoletosLogStatusAnterior);
            n1103BoletosLogStatusAnterior = false;
            cmbBoletosLogStatusAnterior.CurrentValue = A1103BoletosLogStatusAnterior;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbBoletosLogStatusAnterior.CurrentValue = StringUtil.RTrim( A1103BoletosLogStatusAnterior);
         }
         if ( cmbBoletosLogStatusNovo.ItemCount > 0 )
         {
            A1104BoletosLogStatusNovo = cmbBoletosLogStatusNovo.getValidValue(A1104BoletosLogStatusNovo);
            n1104BoletosLogStatusNovo = false;
            cmbBoletosLogStatusNovo.CurrentValue = A1104BoletosLogStatusNovo;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbBoletosLogStatusNovo.CurrentValue = StringUtil.RTrim( A1104BoletosLogStatusNovo);
         }
         A1108BoletosLogSucesso = StringUtil.StrToBool( StringUtil.BoolToStr( A1108BoletosLogSucesso));
         n1108BoletosLogSucesso = false;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1077BoletosId", ((0==A1077BoletosId)&&IsIns( )||n1077BoletosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1077BoletosId), 9, 0, ".", ""))));
         AssignAttri("", false, "A1102BoletosLogOperacao", A1102BoletosLogOperacao);
         cmbBoletosLogOperacao.CurrentValue = StringUtil.RTrim( A1102BoletosLogOperacao);
         AssignProp("", false, cmbBoletosLogOperacao_Internalname, "Values", cmbBoletosLogOperacao.ToJavascriptSource(), true);
         AssignAttri("", false, "A1103BoletosLogStatusAnterior", A1103BoletosLogStatusAnterior);
         cmbBoletosLogStatusAnterior.CurrentValue = StringUtil.RTrim( A1103BoletosLogStatusAnterior);
         AssignProp("", false, cmbBoletosLogStatusAnterior_Internalname, "Values", cmbBoletosLogStatusAnterior.ToJavascriptSource(), true);
         AssignAttri("", false, "A1104BoletosLogStatusNovo", A1104BoletosLogStatusNovo);
         cmbBoletosLogStatusNovo.CurrentValue = StringUtil.RTrim( A1104BoletosLogStatusNovo);
         AssignProp("", false, cmbBoletosLogStatusNovo_Internalname, "Values", cmbBoletosLogStatusNovo.ToJavascriptSource(), true);
         AssignAttri("", false, "A1105BoletosLogRequisicao", A1105BoletosLogRequisicao);
         AssignAttri("", false, "A1106BoletosLogResponse", A1106BoletosLogResponse);
         AssignAttri("", false, "A1107BoletosLogCodigoHttp", ((0==A1107BoletosLogCodigoHttp)&&IsIns( )||n1107BoletosLogCodigoHttp ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A1107BoletosLogCodigoHttp), 4, 0, ".", ""))));
         AssignAttri("", false, "A1108BoletosLogSucesso", A1108BoletosLogSucesso);
         AssignAttri("", false, "A1109BoletosLogObservacao", A1109BoletosLogObservacao);
         AssignAttri("", false, "A1110BoletosLogCreatedAt", context.localUtil.TToC( A1110BoletosLogCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z1101BoletosLogId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1101BoletosLogId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1077BoletosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1077BoletosId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1102BoletosLogOperacao", Z1102BoletosLogOperacao);
         GxWebStd.gx_hidden_field( context, "Z1103BoletosLogStatusAnterior", Z1103BoletosLogStatusAnterior);
         GxWebStd.gx_hidden_field( context, "Z1104BoletosLogStatusNovo", Z1104BoletosLogStatusNovo);
         GxWebStd.gx_hidden_field( context, "Z1105BoletosLogRequisicao", Z1105BoletosLogRequisicao);
         GxWebStd.gx_hidden_field( context, "Z1106BoletosLogResponse", Z1106BoletosLogResponse);
         GxWebStd.gx_hidden_field( context, "Z1107BoletosLogCodigoHttp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1107BoletosLogCodigoHttp), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1108BoletosLogSucesso", StringUtil.BoolToStr( Z1108BoletosLogSucesso));
         GxWebStd.gx_hidden_field( context, "Z1109BoletosLogObservacao", Z1109BoletosLogObservacao);
         GxWebStd.gx_hidden_field( context, "Z1110BoletosLogCreatedAt", context.localUtil.TToC( Z1110BoletosLogCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Boletosid( )
      {
         /* Using cursor T003815 */
         pr_default.execute(13, new Object[] {n1077BoletosId, A1077BoletosId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A1077BoletosId) ) )
            {
               GX_msglist.addItem("Não existe 'Boleto'.", "ForeignKeyNotFound", 1, "BOLETOSID");
               AnyError = 1;
               GX_FocusControl = edtBoletosId_Internalname;
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]}""");
         setEventMetadata("VALID_BOLETOSLOGID","""{"handler":"Valid_Boletoslogid","iparms":[{"av":"cmbBoletosLogStatusNovo"},{"av":"A1104BoletosLogStatusNovo","fld":"BOLETOSLOGSTATUSNOVO","type":"svchar"},{"av":"cmbBoletosLogStatusAnterior"},{"av":"A1103BoletosLogStatusAnterior","fld":"BOLETOSLOGSTATUSANTERIOR","type":"svchar"},{"av":"cmbBoletosLogOperacao"},{"av":"A1102BoletosLogOperacao","fld":"BOLETOSLOGOPERACAO","type":"svchar"},{"av":"A1101BoletosLogId","fld":"BOLETOSLOGID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]""");
         setEventMetadata("VALID_BOLETOSLOGID",""","oparms":[{"av":"A1077BoletosId","fld":"BOLETOSID","pic":"ZZZZZZZZ9","nullAv":"n1077BoletosId","type":"int"},{"av":"cmbBoletosLogOperacao"},{"av":"A1102BoletosLogOperacao","fld":"BOLETOSLOGOPERACAO","type":"svchar"},{"av":"cmbBoletosLogStatusAnterior"},{"av":"A1103BoletosLogStatusAnterior","fld":"BOLETOSLOGSTATUSANTERIOR","type":"svchar"},{"av":"cmbBoletosLogStatusNovo"},{"av":"A1104BoletosLogStatusNovo","fld":"BOLETOSLOGSTATUSNOVO","type":"svchar"},{"av":"A1105BoletosLogRequisicao","fld":"BOLETOSLOGREQUISICAO","type":"vchar"},{"av":"A1106BoletosLogResponse","fld":"BOLETOSLOGRESPONSE","type":"vchar"},{"av":"A1107BoletosLogCodigoHttp","fld":"BOLETOSLOGCODIGOHTTP","pic":"ZZZ9","nullAv":"n1107BoletosLogCodigoHttp","type":"int"},{"av":"A1109BoletosLogObservacao","fld":"BOLETOSLOGOBSERVACAO","type":"svchar"},{"av":"A1110BoletosLogCreatedAt","fld":"BOLETOSLOGCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z1101BoletosLogId","type":"int"},{"av":"Z1077BoletosId","type":"int"},{"av":"Z1102BoletosLogOperacao","type":"svchar"},{"av":"Z1103BoletosLogStatusAnterior","type":"svchar"},{"av":"Z1104BoletosLogStatusNovo","type":"svchar"},{"av":"Z1105BoletosLogRequisicao","type":"vchar"},{"av":"Z1106BoletosLogResponse","type":"vchar"},{"av":"Z1107BoletosLogCodigoHttp","type":"int"},{"av":"Z1108BoletosLogSucesso","type":"boolean"},{"av":"Z1109BoletosLogObservacao","type":"svchar"},{"av":"Z1110BoletosLogCreatedAt","type":"dtime"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]}""");
         setEventMetadata("VALID_BOLETOSID","""{"handler":"Valid_Boletosid","iparms":[{"av":"A1077BoletosId","fld":"BOLETOSID","pic":"ZZZZZZZZ9","nullAv":"n1077BoletosId","type":"int"},{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]""");
         setEventMetadata("VALID_BOLETOSID",""","oparms":[{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]}""");
         setEventMetadata("VALID_BOLETOSLOGOPERACAO","""{"handler":"Valid_Boletoslogoperacao","iparms":[{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]""");
         setEventMetadata("VALID_BOLETOSLOGOPERACAO",""","oparms":[{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]}""");
         setEventMetadata("VALID_BOLETOSLOGSTATUSANTERIOR","""{"handler":"Valid_Boletoslogstatusanterior","iparms":[{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]""");
         setEventMetadata("VALID_BOLETOSLOGSTATUSANTERIOR",""","oparms":[{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]}""");
         setEventMetadata("VALID_BOLETOSLOGSTATUSNOVO","""{"handler":"Valid_Boletoslogstatusnovo","iparms":[{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]""");
         setEventMetadata("VALID_BOLETOSLOGSTATUSNOVO",""","oparms":[{"av":"A1108BoletosLogSucesso","fld":"BOLETOSLOGSUCESSO","type":"boolean"}]}""");
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
         Z1102BoletosLogOperacao = "";
         Z1103BoletosLogStatusAnterior = "";
         Z1104BoletosLogStatusNovo = "";
         Z1109BoletosLogObservacao = "";
         Z1110BoletosLogCreatedAt = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1102BoletosLogOperacao = "";
         A1103BoletosLogStatusAnterior = "";
         A1104BoletosLogStatusNovo = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A1105BoletosLogRequisicao = "";
         A1106BoletosLogResponse = "";
         A1109BoletosLogObservacao = "";
         A1110BoletosLogCreatedAt = (DateTime)(DateTime.MinValue);
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
         Z1105BoletosLogRequisicao = "";
         Z1106BoletosLogResponse = "";
         T00385_A1101BoletosLogId = new int[1] ;
         T00385_A1102BoletosLogOperacao = new string[] {""} ;
         T00385_n1102BoletosLogOperacao = new bool[] {false} ;
         T00385_A1103BoletosLogStatusAnterior = new string[] {""} ;
         T00385_n1103BoletosLogStatusAnterior = new bool[] {false} ;
         T00385_A1104BoletosLogStatusNovo = new string[] {""} ;
         T00385_n1104BoletosLogStatusNovo = new bool[] {false} ;
         T00385_A1105BoletosLogRequisicao = new string[] {""} ;
         T00385_n1105BoletosLogRequisicao = new bool[] {false} ;
         T00385_A1106BoletosLogResponse = new string[] {""} ;
         T00385_n1106BoletosLogResponse = new bool[] {false} ;
         T00385_A1107BoletosLogCodigoHttp = new short[1] ;
         T00385_n1107BoletosLogCodigoHttp = new bool[] {false} ;
         T00385_A1108BoletosLogSucesso = new bool[] {false} ;
         T00385_n1108BoletosLogSucesso = new bool[] {false} ;
         T00385_A1109BoletosLogObservacao = new string[] {""} ;
         T00385_n1109BoletosLogObservacao = new bool[] {false} ;
         T00385_A1110BoletosLogCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00385_n1110BoletosLogCreatedAt = new bool[] {false} ;
         T00385_A1077BoletosId = new int[1] ;
         T00385_n1077BoletosId = new bool[] {false} ;
         T00384_A1077BoletosId = new int[1] ;
         T00384_n1077BoletosId = new bool[] {false} ;
         T00386_A1077BoletosId = new int[1] ;
         T00386_n1077BoletosId = new bool[] {false} ;
         T00387_A1101BoletosLogId = new int[1] ;
         T00383_A1101BoletosLogId = new int[1] ;
         T00383_A1102BoletosLogOperacao = new string[] {""} ;
         T00383_n1102BoletosLogOperacao = new bool[] {false} ;
         T00383_A1103BoletosLogStatusAnterior = new string[] {""} ;
         T00383_n1103BoletosLogStatusAnterior = new bool[] {false} ;
         T00383_A1104BoletosLogStatusNovo = new string[] {""} ;
         T00383_n1104BoletosLogStatusNovo = new bool[] {false} ;
         T00383_A1105BoletosLogRequisicao = new string[] {""} ;
         T00383_n1105BoletosLogRequisicao = new bool[] {false} ;
         T00383_A1106BoletosLogResponse = new string[] {""} ;
         T00383_n1106BoletosLogResponse = new bool[] {false} ;
         T00383_A1107BoletosLogCodigoHttp = new short[1] ;
         T00383_n1107BoletosLogCodigoHttp = new bool[] {false} ;
         T00383_A1108BoletosLogSucesso = new bool[] {false} ;
         T00383_n1108BoletosLogSucesso = new bool[] {false} ;
         T00383_A1109BoletosLogObservacao = new string[] {""} ;
         T00383_n1109BoletosLogObservacao = new bool[] {false} ;
         T00383_A1110BoletosLogCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00383_n1110BoletosLogCreatedAt = new bool[] {false} ;
         T00383_A1077BoletosId = new int[1] ;
         T00383_n1077BoletosId = new bool[] {false} ;
         sMode112 = "";
         T00388_A1101BoletosLogId = new int[1] ;
         T00389_A1101BoletosLogId = new int[1] ;
         T00382_A1101BoletosLogId = new int[1] ;
         T00382_A1102BoletosLogOperacao = new string[] {""} ;
         T00382_n1102BoletosLogOperacao = new bool[] {false} ;
         T00382_A1103BoletosLogStatusAnterior = new string[] {""} ;
         T00382_n1103BoletosLogStatusAnterior = new bool[] {false} ;
         T00382_A1104BoletosLogStatusNovo = new string[] {""} ;
         T00382_n1104BoletosLogStatusNovo = new bool[] {false} ;
         T00382_A1105BoletosLogRequisicao = new string[] {""} ;
         T00382_n1105BoletosLogRequisicao = new bool[] {false} ;
         T00382_A1106BoletosLogResponse = new string[] {""} ;
         T00382_n1106BoletosLogResponse = new bool[] {false} ;
         T00382_A1107BoletosLogCodigoHttp = new short[1] ;
         T00382_n1107BoletosLogCodigoHttp = new bool[] {false} ;
         T00382_A1108BoletosLogSucesso = new bool[] {false} ;
         T00382_n1108BoletosLogSucesso = new bool[] {false} ;
         T00382_A1109BoletosLogObservacao = new string[] {""} ;
         T00382_n1109BoletosLogObservacao = new bool[] {false} ;
         T00382_A1110BoletosLogCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00382_n1110BoletosLogCreatedAt = new bool[] {false} ;
         T00382_A1077BoletosId = new int[1] ;
         T00382_n1077BoletosId = new bool[] {false} ;
         T003811_A1101BoletosLogId = new int[1] ;
         T003814_A1101BoletosLogId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1102BoletosLogOperacao = "";
         ZZ1103BoletosLogStatusAnterior = "";
         ZZ1104BoletosLogStatusNovo = "";
         ZZ1105BoletosLogRequisicao = "";
         ZZ1106BoletosLogResponse = "";
         ZZ1109BoletosLogObservacao = "";
         ZZ1110BoletosLogCreatedAt = (DateTime)(DateTime.MinValue);
         T003815_A1077BoletosId = new int[1] ;
         T003815_n1077BoletosId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.boletoslog__default(),
            new Object[][] {
                new Object[] {
               T00382_A1101BoletosLogId, T00382_A1102BoletosLogOperacao, T00382_n1102BoletosLogOperacao, T00382_A1103BoletosLogStatusAnterior, T00382_n1103BoletosLogStatusAnterior, T00382_A1104BoletosLogStatusNovo, T00382_n1104BoletosLogStatusNovo, T00382_A1105BoletosLogRequisicao, T00382_n1105BoletosLogRequisicao, T00382_A1106BoletosLogResponse,
               T00382_n1106BoletosLogResponse, T00382_A1107BoletosLogCodigoHttp, T00382_n1107BoletosLogCodigoHttp, T00382_A1108BoletosLogSucesso, T00382_n1108BoletosLogSucesso, T00382_A1109BoletosLogObservacao, T00382_n1109BoletosLogObservacao, T00382_A1110BoletosLogCreatedAt, T00382_n1110BoletosLogCreatedAt, T00382_A1077BoletosId,
               T00382_n1077BoletosId
               }
               , new Object[] {
               T00383_A1101BoletosLogId, T00383_A1102BoletosLogOperacao, T00383_n1102BoletosLogOperacao, T00383_A1103BoletosLogStatusAnterior, T00383_n1103BoletosLogStatusAnterior, T00383_A1104BoletosLogStatusNovo, T00383_n1104BoletosLogStatusNovo, T00383_A1105BoletosLogRequisicao, T00383_n1105BoletosLogRequisicao, T00383_A1106BoletosLogResponse,
               T00383_n1106BoletosLogResponse, T00383_A1107BoletosLogCodigoHttp, T00383_n1107BoletosLogCodigoHttp, T00383_A1108BoletosLogSucesso, T00383_n1108BoletosLogSucesso, T00383_A1109BoletosLogObservacao, T00383_n1109BoletosLogObservacao, T00383_A1110BoletosLogCreatedAt, T00383_n1110BoletosLogCreatedAt, T00383_A1077BoletosId,
               T00383_n1077BoletosId
               }
               , new Object[] {
               T00384_A1077BoletosId
               }
               , new Object[] {
               T00385_A1101BoletosLogId, T00385_A1102BoletosLogOperacao, T00385_n1102BoletosLogOperacao, T00385_A1103BoletosLogStatusAnterior, T00385_n1103BoletosLogStatusAnterior, T00385_A1104BoletosLogStatusNovo, T00385_n1104BoletosLogStatusNovo, T00385_A1105BoletosLogRequisicao, T00385_n1105BoletosLogRequisicao, T00385_A1106BoletosLogResponse,
               T00385_n1106BoletosLogResponse, T00385_A1107BoletosLogCodigoHttp, T00385_n1107BoletosLogCodigoHttp, T00385_A1108BoletosLogSucesso, T00385_n1108BoletosLogSucesso, T00385_A1109BoletosLogObservacao, T00385_n1109BoletosLogObservacao, T00385_A1110BoletosLogCreatedAt, T00385_n1110BoletosLogCreatedAt, T00385_A1077BoletosId,
               T00385_n1077BoletosId
               }
               , new Object[] {
               T00386_A1077BoletosId
               }
               , new Object[] {
               T00387_A1101BoletosLogId
               }
               , new Object[] {
               T00388_A1101BoletosLogId
               }
               , new Object[] {
               T00389_A1101BoletosLogId
               }
               , new Object[] {
               }
               , new Object[] {
               T003811_A1101BoletosLogId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003814_A1101BoletosLogId
               }
               , new Object[] {
               T003815_A1077BoletosId
               }
            }
         );
      }

      private short Z1107BoletosLogCodigoHttp ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A1107BoletosLogCodigoHttp ;
      private short RcdFound112 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1107BoletosLogCodigoHttp ;
      private int Z1101BoletosLogId ;
      private int Z1077BoletosId ;
      private int A1077BoletosId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A1101BoletosLogId ;
      private int edtBoletosLogId_Enabled ;
      private int edtBoletosId_Enabled ;
      private int edtBoletosLogRequisicao_Enabled ;
      private int edtBoletosLogResponse_Enabled ;
      private int edtBoletosLogCodigoHttp_Enabled ;
      private int edtBoletosLogObservacao_Enabled ;
      private int edtBoletosLogCreatedAt_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ1101BoletosLogId ;
      private int ZZ1077BoletosId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtBoletosLogId_Internalname ;
      private string cmbBoletosLogOperacao_Internalname ;
      private string cmbBoletosLogStatusAnterior_Internalname ;
      private string cmbBoletosLogStatusNovo_Internalname ;
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
      private string edtBoletosLogId_Jsonclick ;
      private string edtBoletosId_Internalname ;
      private string edtBoletosId_Jsonclick ;
      private string cmbBoletosLogOperacao_Jsonclick ;
      private string cmbBoletosLogStatusAnterior_Jsonclick ;
      private string cmbBoletosLogStatusNovo_Jsonclick ;
      private string edtBoletosLogRequisicao_Internalname ;
      private string edtBoletosLogResponse_Internalname ;
      private string edtBoletosLogCodigoHttp_Internalname ;
      private string edtBoletosLogCodigoHttp_Jsonclick ;
      private string chkBoletosLogSucesso_Internalname ;
      private string edtBoletosLogObservacao_Internalname ;
      private string edtBoletosLogObservacao_Jsonclick ;
      private string edtBoletosLogCreatedAt_Internalname ;
      private string edtBoletosLogCreatedAt_Jsonclick ;
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
      private string sMode112 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z1110BoletosLogCreatedAt ;
      private DateTime A1110BoletosLogCreatedAt ;
      private DateTime ZZ1110BoletosLogCreatedAt ;
      private bool Z1108BoletosLogSucesso ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n1077BoletosId ;
      private bool wbErr ;
      private bool n1102BoletosLogOperacao ;
      private bool n1103BoletosLogStatusAnterior ;
      private bool n1104BoletosLogStatusNovo ;
      private bool A1108BoletosLogSucesso ;
      private bool n1108BoletosLogSucesso ;
      private bool n1107BoletosLogCodigoHttp ;
      private bool n1109BoletosLogObservacao ;
      private bool n1110BoletosLogCreatedAt ;
      private bool n1105BoletosLogRequisicao ;
      private bool n1106BoletosLogResponse ;
      private bool Gx_longc ;
      private bool ZZ1108BoletosLogSucesso ;
      private string A1105BoletosLogRequisicao ;
      private string A1106BoletosLogResponse ;
      private string Z1105BoletosLogRequisicao ;
      private string Z1106BoletosLogResponse ;
      private string ZZ1105BoletosLogRequisicao ;
      private string ZZ1106BoletosLogResponse ;
      private string Z1102BoletosLogOperacao ;
      private string Z1103BoletosLogStatusAnterior ;
      private string Z1104BoletosLogStatusNovo ;
      private string Z1109BoletosLogObservacao ;
      private string A1102BoletosLogOperacao ;
      private string A1103BoletosLogStatusAnterior ;
      private string A1104BoletosLogStatusNovo ;
      private string A1109BoletosLogObservacao ;
      private string ZZ1102BoletosLogOperacao ;
      private string ZZ1103BoletosLogStatusAnterior ;
      private string ZZ1104BoletosLogStatusNovo ;
      private string ZZ1109BoletosLogObservacao ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbBoletosLogOperacao ;
      private GXCombobox cmbBoletosLogStatusAnterior ;
      private GXCombobox cmbBoletosLogStatusNovo ;
      private GXCheckbox chkBoletosLogSucesso ;
      private IDataStoreProvider pr_default ;
      private int[] T00385_A1101BoletosLogId ;
      private string[] T00385_A1102BoletosLogOperacao ;
      private bool[] T00385_n1102BoletosLogOperacao ;
      private string[] T00385_A1103BoletosLogStatusAnterior ;
      private bool[] T00385_n1103BoletosLogStatusAnterior ;
      private string[] T00385_A1104BoletosLogStatusNovo ;
      private bool[] T00385_n1104BoletosLogStatusNovo ;
      private string[] T00385_A1105BoletosLogRequisicao ;
      private bool[] T00385_n1105BoletosLogRequisicao ;
      private string[] T00385_A1106BoletosLogResponse ;
      private bool[] T00385_n1106BoletosLogResponse ;
      private short[] T00385_A1107BoletosLogCodigoHttp ;
      private bool[] T00385_n1107BoletosLogCodigoHttp ;
      private bool[] T00385_A1108BoletosLogSucesso ;
      private bool[] T00385_n1108BoletosLogSucesso ;
      private string[] T00385_A1109BoletosLogObservacao ;
      private bool[] T00385_n1109BoletosLogObservacao ;
      private DateTime[] T00385_A1110BoletosLogCreatedAt ;
      private bool[] T00385_n1110BoletosLogCreatedAt ;
      private int[] T00385_A1077BoletosId ;
      private bool[] T00385_n1077BoletosId ;
      private int[] T00384_A1077BoletosId ;
      private bool[] T00384_n1077BoletosId ;
      private int[] T00386_A1077BoletosId ;
      private bool[] T00386_n1077BoletosId ;
      private int[] T00387_A1101BoletosLogId ;
      private int[] T00383_A1101BoletosLogId ;
      private string[] T00383_A1102BoletosLogOperacao ;
      private bool[] T00383_n1102BoletosLogOperacao ;
      private string[] T00383_A1103BoletosLogStatusAnterior ;
      private bool[] T00383_n1103BoletosLogStatusAnterior ;
      private string[] T00383_A1104BoletosLogStatusNovo ;
      private bool[] T00383_n1104BoletosLogStatusNovo ;
      private string[] T00383_A1105BoletosLogRequisicao ;
      private bool[] T00383_n1105BoletosLogRequisicao ;
      private string[] T00383_A1106BoletosLogResponse ;
      private bool[] T00383_n1106BoletosLogResponse ;
      private short[] T00383_A1107BoletosLogCodigoHttp ;
      private bool[] T00383_n1107BoletosLogCodigoHttp ;
      private bool[] T00383_A1108BoletosLogSucesso ;
      private bool[] T00383_n1108BoletosLogSucesso ;
      private string[] T00383_A1109BoletosLogObservacao ;
      private bool[] T00383_n1109BoletosLogObservacao ;
      private DateTime[] T00383_A1110BoletosLogCreatedAt ;
      private bool[] T00383_n1110BoletosLogCreatedAt ;
      private int[] T00383_A1077BoletosId ;
      private bool[] T00383_n1077BoletosId ;
      private int[] T00388_A1101BoletosLogId ;
      private int[] T00389_A1101BoletosLogId ;
      private int[] T00382_A1101BoletosLogId ;
      private string[] T00382_A1102BoletosLogOperacao ;
      private bool[] T00382_n1102BoletosLogOperacao ;
      private string[] T00382_A1103BoletosLogStatusAnterior ;
      private bool[] T00382_n1103BoletosLogStatusAnterior ;
      private string[] T00382_A1104BoletosLogStatusNovo ;
      private bool[] T00382_n1104BoletosLogStatusNovo ;
      private string[] T00382_A1105BoletosLogRequisicao ;
      private bool[] T00382_n1105BoletosLogRequisicao ;
      private string[] T00382_A1106BoletosLogResponse ;
      private bool[] T00382_n1106BoletosLogResponse ;
      private short[] T00382_A1107BoletosLogCodigoHttp ;
      private bool[] T00382_n1107BoletosLogCodigoHttp ;
      private bool[] T00382_A1108BoletosLogSucesso ;
      private bool[] T00382_n1108BoletosLogSucesso ;
      private string[] T00382_A1109BoletosLogObservacao ;
      private bool[] T00382_n1109BoletosLogObservacao ;
      private DateTime[] T00382_A1110BoletosLogCreatedAt ;
      private bool[] T00382_n1110BoletosLogCreatedAt ;
      private int[] T00382_A1077BoletosId ;
      private bool[] T00382_n1077BoletosId ;
      private int[] T003811_A1101BoletosLogId ;
      private int[] T003814_A1101BoletosLogId ;
      private int[] T003815_A1077BoletosId ;
      private bool[] T003815_n1077BoletosId ;
   }

   public class boletoslog__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00382;
          prmT00382 = new Object[] {
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmT00383;
          prmT00383 = new Object[] {
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmT00384;
          prmT00384 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00385;
          prmT00385 = new Object[] {
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmT00386;
          prmT00386 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00387;
          prmT00387 = new Object[] {
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmT00388;
          prmT00388 = new Object[] {
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmT00389;
          prmT00389 = new Object[] {
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmT003810;
          prmT003810 = new Object[] {
          new ParDef("BoletosLogOperacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosLogStatusAnterior",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosLogStatusNovo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosLogRequisicao",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("BoletosLogResponse",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("BoletosLogCodigoHttp",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("BoletosLogSucesso",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("BoletosLogObservacao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("BoletosLogCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003811;
          prmT003811 = new Object[] {
          };
          Object[] prmT003812;
          prmT003812 = new Object[] {
          new ParDef("BoletosLogOperacao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosLogStatusAnterior",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosLogStatusNovo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BoletosLogRequisicao",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("BoletosLogResponse",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("BoletosLogCodigoHttp",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("BoletosLogSucesso",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("BoletosLogObservacao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("BoletosLogCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmT003813;
          prmT003813 = new Object[] {
          new ParDef("BoletosLogId",GXType.Int32,9,0)
          };
          Object[] prmT003814;
          prmT003814 = new Object[] {
          };
          Object[] prmT003815;
          prmT003815 = new Object[] {
          new ParDef("BoletosId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00382", "SELECT BoletosLogId, BoletosLogOperacao, BoletosLogStatusAnterior, BoletosLogStatusNovo, BoletosLogRequisicao, BoletosLogResponse, BoletosLogCodigoHttp, BoletosLogSucesso, BoletosLogObservacao, BoletosLogCreatedAt, BoletosId FROM BoletosLog WHERE BoletosLogId = :BoletosLogId  FOR UPDATE OF BoletosLog NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00382,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00383", "SELECT BoletosLogId, BoletosLogOperacao, BoletosLogStatusAnterior, BoletosLogStatusNovo, BoletosLogRequisicao, BoletosLogResponse, BoletosLogCodigoHttp, BoletosLogSucesso, BoletosLogObservacao, BoletosLogCreatedAt, BoletosId FROM BoletosLog WHERE BoletosLogId = :BoletosLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00383,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00384", "SELECT BoletosId FROM Boleto WHERE BoletosId = :BoletosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00384,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00385", "SELECT TM1.BoletosLogId, TM1.BoletosLogOperacao, TM1.BoletosLogStatusAnterior, TM1.BoletosLogStatusNovo, TM1.BoletosLogRequisicao, TM1.BoletosLogResponse, TM1.BoletosLogCodigoHttp, TM1.BoletosLogSucesso, TM1.BoletosLogObservacao, TM1.BoletosLogCreatedAt, TM1.BoletosId FROM BoletosLog TM1 WHERE TM1.BoletosLogId = :BoletosLogId ORDER BY TM1.BoletosLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00385,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00386", "SELECT BoletosId FROM Boleto WHERE BoletosId = :BoletosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00386,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00387", "SELECT BoletosLogId FROM BoletosLog WHERE BoletosLogId = :BoletosLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00387,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00388", "SELECT BoletosLogId FROM BoletosLog WHERE ( BoletosLogId > :BoletosLogId) ORDER BY BoletosLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00388,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00389", "SELECT BoletosLogId FROM BoletosLog WHERE ( BoletosLogId < :BoletosLogId) ORDER BY BoletosLogId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00389,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003810", "SAVEPOINT gxupdate;INSERT INTO BoletosLog(BoletosLogOperacao, BoletosLogStatusAnterior, BoletosLogStatusNovo, BoletosLogRequisicao, BoletosLogResponse, BoletosLogCodigoHttp, BoletosLogSucesso, BoletosLogObservacao, BoletosLogCreatedAt, BoletosId) VALUES(:BoletosLogOperacao, :BoletosLogStatusAnterior, :BoletosLogStatusNovo, :BoletosLogRequisicao, :BoletosLogResponse, :BoletosLogCodigoHttp, :BoletosLogSucesso, :BoletosLogObservacao, :BoletosLogCreatedAt, :BoletosId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003810)
             ,new CursorDef("T003811", "SELECT currval('BoletosLogId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT003811,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003812", "SAVEPOINT gxupdate;UPDATE BoletosLog SET BoletosLogOperacao=:BoletosLogOperacao, BoletosLogStatusAnterior=:BoletosLogStatusAnterior, BoletosLogStatusNovo=:BoletosLogStatusNovo, BoletosLogRequisicao=:BoletosLogRequisicao, BoletosLogResponse=:BoletosLogResponse, BoletosLogCodigoHttp=:BoletosLogCodigoHttp, BoletosLogSucesso=:BoletosLogSucesso, BoletosLogObservacao=:BoletosLogObservacao, BoletosLogCreatedAt=:BoletosLogCreatedAt, BoletosId=:BoletosId  WHERE BoletosLogId = :BoletosLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003812)
             ,new CursorDef("T003813", "SAVEPOINT gxupdate;DELETE FROM BoletosLog  WHERE BoletosLogId = :BoletosLogId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003813)
             ,new CursorDef("T003814", "SELECT BoletosLogId FROM BoletosLog ORDER BY BoletosLogId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003814,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003815", "SELECT BoletosId FROM Boleto WHERE BoletosId = :BoletosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003815,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getLongVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
