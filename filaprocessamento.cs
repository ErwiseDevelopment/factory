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
   public class filaprocessamento : GXDataArea
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
         Form.Meta.addItem("description", "Fila Processamento", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFilaProcessamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public filaprocessamento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public filaprocessamento( IGxContext context )
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
         cmbFilaProcessamentoStatus = new GXCombobox();
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
         if ( cmbFilaProcessamentoStatus.ItemCount > 0 )
         {
            A358FilaProcessamentoStatus = cmbFilaProcessamentoStatus.getValidValue(A358FilaProcessamentoStatus);
            n358FilaProcessamentoStatus = false;
            AssignAttri("", false, "A358FilaProcessamentoStatus", A358FilaProcessamentoStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbFilaProcessamentoStatus.CurrentValue = StringUtil.RTrim( A358FilaProcessamentoStatus);
            AssignProp("", false, cmbFilaProcessamentoStatus_Internalname, "Values", cmbFilaProcessamentoStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Fila Processamento", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_FilaProcessamento.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_FilaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_FilaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_FilaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_FilaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_FilaProcessamento.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFilaProcessamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFilaProcessamentoId_Internalname, "Processamento Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFilaProcessamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A355FilaProcessamentoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtFilaProcessamentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A355FilaProcessamentoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A355FilaProcessamentoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFilaProcessamentoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFilaProcessamentoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_FilaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFilaProcessamentoFuncao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFilaProcessamentoFuncao_Internalname, "Processamento Funcao", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFilaProcessamentoFuncao_Internalname, A356FilaProcessamentoFuncao, StringUtil.RTrim( context.localUtil.Format( A356FilaProcessamentoFuncao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFilaProcessamentoFuncao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFilaProcessamentoFuncao_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_FilaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFilaProcessamentoParametros_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFilaProcessamentoParametros_Internalname, "Processamento Parametros", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtFilaProcessamentoParametros_Internalname, A357FilaProcessamentoParametros, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtFilaProcessamentoParametros_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_FilaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbFilaProcessamentoStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbFilaProcessamentoStatus_Internalname, "Processamento Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbFilaProcessamentoStatus, cmbFilaProcessamentoStatus_Internalname, StringUtil.RTrim( A358FilaProcessamentoStatus), 1, cmbFilaProcessamentoStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbFilaProcessamentoStatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_FilaProcessamento.htm");
         cmbFilaProcessamentoStatus.CurrentValue = StringUtil.RTrim( A358FilaProcessamentoStatus);
         AssignProp("", false, cmbFilaProcessamentoStatus_Internalname, "Values", (string)(cmbFilaProcessamentoStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFilaProcessamentoCriacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFilaProcessamentoCriacao_Internalname, "Processamento Criacao", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFilaProcessamentoCriacao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFilaProcessamentoCriacao_Internalname, context.localUtil.TToC( A359FilaProcessamentoCriacao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A359FilaProcessamentoCriacao, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFilaProcessamentoCriacao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFilaProcessamentoCriacao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FilaProcessamento.htm");
         GxWebStd.gx_bitmap( context, edtFilaProcessamentoCriacao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFilaProcessamentoCriacao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_FilaProcessamento.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtFilaProcessamentoAtualizacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFilaProcessamentoAtualizacao_Internalname, "Processamento Atualizacao", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFilaProcessamentoAtualizacao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFilaProcessamentoAtualizacao_Internalname, context.localUtil.TToC( A360FilaProcessamentoAtualizacao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A360FilaProcessamentoAtualizacao, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFilaProcessamentoAtualizacao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFilaProcessamentoAtualizacao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_FilaProcessamento.htm");
         GxWebStd.gx_bitmap( context, edtFilaProcessamentoAtualizacao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFilaProcessamentoAtualizacao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_FilaProcessamento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_FilaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_FilaProcessamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_FilaProcessamento.htm");
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
            Z355FilaProcessamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z355FilaProcessamentoId"), ",", "."), 18, MidpointRounding.ToEven));
            Z356FilaProcessamentoFuncao = cgiGet( "Z356FilaProcessamentoFuncao");
            n356FilaProcessamentoFuncao = (String.IsNullOrEmpty(StringUtil.RTrim( A356FilaProcessamentoFuncao)) ? true : false);
            Z358FilaProcessamentoStatus = cgiGet( "Z358FilaProcessamentoStatus");
            n358FilaProcessamentoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A358FilaProcessamentoStatus)) ? true : false);
            Z359FilaProcessamentoCriacao = context.localUtil.CToT( cgiGet( "Z359FilaProcessamentoCriacao"), 0);
            n359FilaProcessamentoCriacao = ((DateTime.MinValue==A359FilaProcessamentoCriacao) ? true : false);
            Z360FilaProcessamentoAtualizacao = context.localUtil.CToT( cgiGet( "Z360FilaProcessamentoAtualizacao"), 0);
            n360FilaProcessamentoAtualizacao = ((DateTime.MinValue==A360FilaProcessamentoAtualizacao) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtFilaProcessamentoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFilaProcessamentoId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FILAPROCESSAMENTOID");
               AnyError = 1;
               GX_FocusControl = edtFilaProcessamentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A355FilaProcessamentoId = 0;
               AssignAttri("", false, "A355FilaProcessamentoId", StringUtil.LTrimStr( (decimal)(A355FilaProcessamentoId), 9, 0));
            }
            else
            {
               A355FilaProcessamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtFilaProcessamentoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A355FilaProcessamentoId", StringUtil.LTrimStr( (decimal)(A355FilaProcessamentoId), 9, 0));
            }
            A356FilaProcessamentoFuncao = cgiGet( edtFilaProcessamentoFuncao_Internalname);
            n356FilaProcessamentoFuncao = false;
            AssignAttri("", false, "A356FilaProcessamentoFuncao", A356FilaProcessamentoFuncao);
            n356FilaProcessamentoFuncao = (String.IsNullOrEmpty(StringUtil.RTrim( A356FilaProcessamentoFuncao)) ? true : false);
            A357FilaProcessamentoParametros = cgiGet( edtFilaProcessamentoParametros_Internalname);
            n357FilaProcessamentoParametros = false;
            AssignAttri("", false, "A357FilaProcessamentoParametros", A357FilaProcessamentoParametros);
            n357FilaProcessamentoParametros = (String.IsNullOrEmpty(StringUtil.RTrim( A357FilaProcessamentoParametros)) ? true : false);
            cmbFilaProcessamentoStatus.CurrentValue = cgiGet( cmbFilaProcessamentoStatus_Internalname);
            A358FilaProcessamentoStatus = cgiGet( cmbFilaProcessamentoStatus_Internalname);
            n358FilaProcessamentoStatus = false;
            AssignAttri("", false, "A358FilaProcessamentoStatus", A358FilaProcessamentoStatus);
            n358FilaProcessamentoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A358FilaProcessamentoStatus)) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtFilaProcessamentoCriacao_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fila Processamento Criacao"}), 1, "FILAPROCESSAMENTOCRIACAO");
               AnyError = 1;
               GX_FocusControl = edtFilaProcessamentoCriacao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A359FilaProcessamentoCriacao = (DateTime)(DateTime.MinValue);
               n359FilaProcessamentoCriacao = false;
               AssignAttri("", false, "A359FilaProcessamentoCriacao", context.localUtil.TToC( A359FilaProcessamentoCriacao, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A359FilaProcessamentoCriacao = context.localUtil.CToT( cgiGet( edtFilaProcessamentoCriacao_Internalname));
               n359FilaProcessamentoCriacao = false;
               AssignAttri("", false, "A359FilaProcessamentoCriacao", context.localUtil.TToC( A359FilaProcessamentoCriacao, 8, 5, 0, 3, "/", ":", " "));
            }
            n359FilaProcessamentoCriacao = ((DateTime.MinValue==A359FilaProcessamentoCriacao) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtFilaProcessamentoAtualizacao_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fila Processamento Atualizacao"}), 1, "FILAPROCESSAMENTOATUALIZACAO");
               AnyError = 1;
               GX_FocusControl = edtFilaProcessamentoAtualizacao_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A360FilaProcessamentoAtualizacao = (DateTime)(DateTime.MinValue);
               n360FilaProcessamentoAtualizacao = false;
               AssignAttri("", false, "A360FilaProcessamentoAtualizacao", context.localUtil.TToC( A360FilaProcessamentoAtualizacao, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A360FilaProcessamentoAtualizacao = context.localUtil.CToT( cgiGet( edtFilaProcessamentoAtualizacao_Internalname));
               n360FilaProcessamentoAtualizacao = false;
               AssignAttri("", false, "A360FilaProcessamentoAtualizacao", context.localUtil.TToC( A360FilaProcessamentoAtualizacao, 8, 5, 0, 3, "/", ":", " "));
            }
            n360FilaProcessamentoAtualizacao = ((DateTime.MinValue==A360FilaProcessamentoAtualizacao) ? true : false);
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
               A355FilaProcessamentoId = (int)(Math.Round(NumberUtil.Val( GetPar( "FilaProcessamentoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A355FilaProcessamentoId", StringUtil.LTrimStr( (decimal)(A355FilaProcessamentoId), 9, 0));
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
               InitAll1D52( ) ;
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
         DisableAttributes1D52( ) ;
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

      protected void ResetCaption1D0( )
      {
      }

      protected void ZM1D52( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z356FilaProcessamentoFuncao = T001D3_A356FilaProcessamentoFuncao[0];
               Z358FilaProcessamentoStatus = T001D3_A358FilaProcessamentoStatus[0];
               Z359FilaProcessamentoCriacao = T001D3_A359FilaProcessamentoCriacao[0];
               Z360FilaProcessamentoAtualizacao = T001D3_A360FilaProcessamentoAtualizacao[0];
            }
            else
            {
               Z356FilaProcessamentoFuncao = A356FilaProcessamentoFuncao;
               Z358FilaProcessamentoStatus = A358FilaProcessamentoStatus;
               Z359FilaProcessamentoCriacao = A359FilaProcessamentoCriacao;
               Z360FilaProcessamentoAtualizacao = A360FilaProcessamentoAtualizacao;
            }
         }
         if ( GX_JID == -2 )
         {
            Z355FilaProcessamentoId = A355FilaProcessamentoId;
            Z356FilaProcessamentoFuncao = A356FilaProcessamentoFuncao;
            Z357FilaProcessamentoParametros = A357FilaProcessamentoParametros;
            Z358FilaProcessamentoStatus = A358FilaProcessamentoStatus;
            Z359FilaProcessamentoCriacao = A359FilaProcessamentoCriacao;
            Z360FilaProcessamentoAtualizacao = A360FilaProcessamentoAtualizacao;
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

      protected void Load1D52( )
      {
         /* Using cursor T001D4 */
         pr_default.execute(2, new Object[] {A355FilaProcessamentoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound52 = 1;
            A356FilaProcessamentoFuncao = T001D4_A356FilaProcessamentoFuncao[0];
            n356FilaProcessamentoFuncao = T001D4_n356FilaProcessamentoFuncao[0];
            AssignAttri("", false, "A356FilaProcessamentoFuncao", A356FilaProcessamentoFuncao);
            A357FilaProcessamentoParametros = T001D4_A357FilaProcessamentoParametros[0];
            n357FilaProcessamentoParametros = T001D4_n357FilaProcessamentoParametros[0];
            AssignAttri("", false, "A357FilaProcessamentoParametros", A357FilaProcessamentoParametros);
            A358FilaProcessamentoStatus = T001D4_A358FilaProcessamentoStatus[0];
            n358FilaProcessamentoStatus = T001D4_n358FilaProcessamentoStatus[0];
            AssignAttri("", false, "A358FilaProcessamentoStatus", A358FilaProcessamentoStatus);
            A359FilaProcessamentoCriacao = T001D4_A359FilaProcessamentoCriacao[0];
            n359FilaProcessamentoCriacao = T001D4_n359FilaProcessamentoCriacao[0];
            AssignAttri("", false, "A359FilaProcessamentoCriacao", context.localUtil.TToC( A359FilaProcessamentoCriacao, 8, 5, 0, 3, "/", ":", " "));
            A360FilaProcessamentoAtualizacao = T001D4_A360FilaProcessamentoAtualizacao[0];
            n360FilaProcessamentoAtualizacao = T001D4_n360FilaProcessamentoAtualizacao[0];
            AssignAttri("", false, "A360FilaProcessamentoAtualizacao", context.localUtil.TToC( A360FilaProcessamentoAtualizacao, 8, 5, 0, 3, "/", ":", " "));
            ZM1D52( -2) ;
         }
         pr_default.close(2);
         OnLoadActions1D52( ) ;
      }

      protected void OnLoadActions1D52( )
      {
      }

      protected void CheckExtendedTable1D52( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A358FilaProcessamentoStatus, "PENDENTE") == 0 ) || ( StringUtil.StrCmp(A358FilaProcessamentoStatus, "PROCESSANDO") == 0 ) || ( StringUtil.StrCmp(A358FilaProcessamentoStatus, "CONCLUIDO") == 0 ) || ( StringUtil.StrCmp(A358FilaProcessamentoStatus, "ERRO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A358FilaProcessamentoStatus)) ) )
         {
            GX_msglist.addItem("Campo Fila Processamento Status fora do intervalo", "OutOfRange", 1, "FILAPROCESSAMENTOSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbFilaProcessamentoStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1D52( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1D52( )
      {
         /* Using cursor T001D5 */
         pr_default.execute(3, new Object[] {A355FilaProcessamentoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound52 = 1;
         }
         else
         {
            RcdFound52 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001D3 */
         pr_default.execute(1, new Object[] {A355FilaProcessamentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1D52( 2) ;
            RcdFound52 = 1;
            A355FilaProcessamentoId = T001D3_A355FilaProcessamentoId[0];
            AssignAttri("", false, "A355FilaProcessamentoId", StringUtil.LTrimStr( (decimal)(A355FilaProcessamentoId), 9, 0));
            A356FilaProcessamentoFuncao = T001D3_A356FilaProcessamentoFuncao[0];
            n356FilaProcessamentoFuncao = T001D3_n356FilaProcessamentoFuncao[0];
            AssignAttri("", false, "A356FilaProcessamentoFuncao", A356FilaProcessamentoFuncao);
            A357FilaProcessamentoParametros = T001D3_A357FilaProcessamentoParametros[0];
            n357FilaProcessamentoParametros = T001D3_n357FilaProcessamentoParametros[0];
            AssignAttri("", false, "A357FilaProcessamentoParametros", A357FilaProcessamentoParametros);
            A358FilaProcessamentoStatus = T001D3_A358FilaProcessamentoStatus[0];
            n358FilaProcessamentoStatus = T001D3_n358FilaProcessamentoStatus[0];
            AssignAttri("", false, "A358FilaProcessamentoStatus", A358FilaProcessamentoStatus);
            A359FilaProcessamentoCriacao = T001D3_A359FilaProcessamentoCriacao[0];
            n359FilaProcessamentoCriacao = T001D3_n359FilaProcessamentoCriacao[0];
            AssignAttri("", false, "A359FilaProcessamentoCriacao", context.localUtil.TToC( A359FilaProcessamentoCriacao, 8, 5, 0, 3, "/", ":", " "));
            A360FilaProcessamentoAtualizacao = T001D3_A360FilaProcessamentoAtualizacao[0];
            n360FilaProcessamentoAtualizacao = T001D3_n360FilaProcessamentoAtualizacao[0];
            AssignAttri("", false, "A360FilaProcessamentoAtualizacao", context.localUtil.TToC( A360FilaProcessamentoAtualizacao, 8, 5, 0, 3, "/", ":", " "));
            Z355FilaProcessamentoId = A355FilaProcessamentoId;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1D52( ) ;
            if ( AnyError == 1 )
            {
               RcdFound52 = 0;
               InitializeNonKey1D52( ) ;
            }
            Gx_mode = sMode52;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound52 = 0;
            InitializeNonKey1D52( ) ;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode52;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1D52( ) ;
         if ( RcdFound52 == 0 )
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
         RcdFound52 = 0;
         /* Using cursor T001D6 */
         pr_default.execute(4, new Object[] {A355FilaProcessamentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T001D6_A355FilaProcessamentoId[0] < A355FilaProcessamentoId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T001D6_A355FilaProcessamentoId[0] > A355FilaProcessamentoId ) ) )
            {
               A355FilaProcessamentoId = T001D6_A355FilaProcessamentoId[0];
               AssignAttri("", false, "A355FilaProcessamentoId", StringUtil.LTrimStr( (decimal)(A355FilaProcessamentoId), 9, 0));
               RcdFound52 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound52 = 0;
         /* Using cursor T001D7 */
         pr_default.execute(5, new Object[] {A355FilaProcessamentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T001D7_A355FilaProcessamentoId[0] > A355FilaProcessamentoId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T001D7_A355FilaProcessamentoId[0] < A355FilaProcessamentoId ) ) )
            {
               A355FilaProcessamentoId = T001D7_A355FilaProcessamentoId[0];
               AssignAttri("", false, "A355FilaProcessamentoId", StringUtil.LTrimStr( (decimal)(A355FilaProcessamentoId), 9, 0));
               RcdFound52 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1D52( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFilaProcessamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1D52( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound52 == 1 )
            {
               if ( A355FilaProcessamentoId != Z355FilaProcessamentoId )
               {
                  A355FilaProcessamentoId = Z355FilaProcessamentoId;
                  AssignAttri("", false, "A355FilaProcessamentoId", StringUtil.LTrimStr( (decimal)(A355FilaProcessamentoId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FILAPROCESSAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtFilaProcessamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFilaProcessamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1D52( ) ;
                  GX_FocusControl = edtFilaProcessamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A355FilaProcessamentoId != Z355FilaProcessamentoId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtFilaProcessamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1D52( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FILAPROCESSAMENTOID");
                     AnyError = 1;
                     GX_FocusControl = edtFilaProcessamentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtFilaProcessamentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1D52( ) ;
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
         if ( A355FilaProcessamentoId != Z355FilaProcessamentoId )
         {
            A355FilaProcessamentoId = Z355FilaProcessamentoId;
            AssignAttri("", false, "A355FilaProcessamentoId", StringUtil.LTrimStr( (decimal)(A355FilaProcessamentoId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FILAPROCESSAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtFilaProcessamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFilaProcessamentoId_Internalname;
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
         if ( RcdFound52 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "FILAPROCESSAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtFilaProcessamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtFilaProcessamentoFuncao_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1D52( ) ;
         if ( RcdFound52 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFilaProcessamentoFuncao_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1D52( ) ;
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
         if ( RcdFound52 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFilaProcessamentoFuncao_Internalname;
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
         if ( RcdFound52 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFilaProcessamentoFuncao_Internalname;
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
         ScanStart1D52( ) ;
         if ( RcdFound52 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound52 != 0 )
            {
               ScanNext1D52( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFilaProcessamentoFuncao_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1D52( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1D52( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001D2 */
            pr_default.execute(0, new Object[] {A355FilaProcessamentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FilaProcessamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z356FilaProcessamentoFuncao, T001D2_A356FilaProcessamentoFuncao[0]) != 0 ) || ( StringUtil.StrCmp(Z358FilaProcessamentoStatus, T001D2_A358FilaProcessamentoStatus[0]) != 0 ) || ( Z359FilaProcessamentoCriacao != T001D2_A359FilaProcessamentoCriacao[0] ) || ( Z360FilaProcessamentoAtualizacao != T001D2_A360FilaProcessamentoAtualizacao[0] ) )
            {
               if ( StringUtil.StrCmp(Z356FilaProcessamentoFuncao, T001D2_A356FilaProcessamentoFuncao[0]) != 0 )
               {
                  GXUtil.WriteLog("filaprocessamento:[seudo value changed for attri]"+"FilaProcessamentoFuncao");
                  GXUtil.WriteLogRaw("Old: ",Z356FilaProcessamentoFuncao);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A356FilaProcessamentoFuncao[0]);
               }
               if ( StringUtil.StrCmp(Z358FilaProcessamentoStatus, T001D2_A358FilaProcessamentoStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("filaprocessamento:[seudo value changed for attri]"+"FilaProcessamentoStatus");
                  GXUtil.WriteLogRaw("Old: ",Z358FilaProcessamentoStatus);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A358FilaProcessamentoStatus[0]);
               }
               if ( Z359FilaProcessamentoCriacao != T001D2_A359FilaProcessamentoCriacao[0] )
               {
                  GXUtil.WriteLog("filaprocessamento:[seudo value changed for attri]"+"FilaProcessamentoCriacao");
                  GXUtil.WriteLogRaw("Old: ",Z359FilaProcessamentoCriacao);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A359FilaProcessamentoCriacao[0]);
               }
               if ( Z360FilaProcessamentoAtualizacao != T001D2_A360FilaProcessamentoAtualizacao[0] )
               {
                  GXUtil.WriteLog("filaprocessamento:[seudo value changed for attri]"+"FilaProcessamentoAtualizacao");
                  GXUtil.WriteLogRaw("Old: ",Z360FilaProcessamentoAtualizacao);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A360FilaProcessamentoAtualizacao[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FilaProcessamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1D52( )
      {
         BeforeValidate1D52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D52( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1D52( 0) ;
            CheckOptimisticConcurrency1D52( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D52( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1D52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001D8 */
                     pr_default.execute(6, new Object[] {n356FilaProcessamentoFuncao, A356FilaProcessamentoFuncao, n357FilaProcessamentoParametros, A357FilaProcessamentoParametros, n358FilaProcessamentoStatus, A358FilaProcessamentoStatus, n359FilaProcessamentoCriacao, A359FilaProcessamentoCriacao, n360FilaProcessamentoAtualizacao, A360FilaProcessamentoAtualizacao});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001D9 */
                     pr_default.execute(7);
                     A355FilaProcessamentoId = T001D9_A355FilaProcessamentoId[0];
                     AssignAttri("", false, "A355FilaProcessamentoId", StringUtil.LTrimStr( (decimal)(A355FilaProcessamentoId), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("FilaProcessamento");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1D0( ) ;
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
               Load1D52( ) ;
            }
            EndLevel1D52( ) ;
         }
         CloseExtendedTableCursors1D52( ) ;
      }

      protected void Update1D52( )
      {
         BeforeValidate1D52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D52( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D52( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D52( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1D52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001D10 */
                     pr_default.execute(8, new Object[] {n356FilaProcessamentoFuncao, A356FilaProcessamentoFuncao, n357FilaProcessamentoParametros, A357FilaProcessamentoParametros, n358FilaProcessamentoStatus, A358FilaProcessamentoStatus, n359FilaProcessamentoCriacao, A359FilaProcessamentoCriacao, n360FilaProcessamentoAtualizacao, A360FilaProcessamentoAtualizacao, A355FilaProcessamentoId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("FilaProcessamento");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FilaProcessamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1D52( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1D0( ) ;
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
            EndLevel1D52( ) ;
         }
         CloseExtendedTableCursors1D52( ) ;
      }

      protected void DeferredUpdate1D52( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1D52( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D52( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1D52( ) ;
            AfterConfirm1D52( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1D52( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001D11 */
                  pr_default.execute(9, new Object[] {A355FilaProcessamentoId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("FilaProcessamento");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound52 == 0 )
                        {
                           InitAll1D52( ) ;
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
                        ResetCaption1D0( ) ;
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
         sMode52 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1D52( ) ;
         Gx_mode = sMode52;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1D52( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1D52( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1D52( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues1D0( ) ;
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

      public void ScanStart1D52( )
      {
         /* Using cursor T001D12 */
         pr_default.execute(10);
         RcdFound52 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound52 = 1;
            A355FilaProcessamentoId = T001D12_A355FilaProcessamentoId[0];
            AssignAttri("", false, "A355FilaProcessamentoId", StringUtil.LTrimStr( (decimal)(A355FilaProcessamentoId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1D52( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound52 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound52 = 1;
            A355FilaProcessamentoId = T001D12_A355FilaProcessamentoId[0];
            AssignAttri("", false, "A355FilaProcessamentoId", StringUtil.LTrimStr( (decimal)(A355FilaProcessamentoId), 9, 0));
         }
      }

      protected void ScanEnd1D52( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1D52( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1D52( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1D52( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1D52( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1D52( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1D52( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1D52( )
      {
         edtFilaProcessamentoId_Enabled = 0;
         AssignProp("", false, edtFilaProcessamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFilaProcessamentoId_Enabled), 5, 0), true);
         edtFilaProcessamentoFuncao_Enabled = 0;
         AssignProp("", false, edtFilaProcessamentoFuncao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFilaProcessamentoFuncao_Enabled), 5, 0), true);
         edtFilaProcessamentoParametros_Enabled = 0;
         AssignProp("", false, edtFilaProcessamentoParametros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFilaProcessamentoParametros_Enabled), 5, 0), true);
         cmbFilaProcessamentoStatus.Enabled = 0;
         AssignProp("", false, cmbFilaProcessamentoStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFilaProcessamentoStatus.Enabled), 5, 0), true);
         edtFilaProcessamentoCriacao_Enabled = 0;
         AssignProp("", false, edtFilaProcessamentoCriacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFilaProcessamentoCriacao_Enabled), 5, 0), true);
         edtFilaProcessamentoAtualizacao_Enabled = 0;
         AssignProp("", false, edtFilaProcessamentoAtualizacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFilaProcessamentoAtualizacao_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1D52( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1D0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("filaprocessamento") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z355FilaProcessamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z355FilaProcessamentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z356FilaProcessamentoFuncao", Z356FilaProcessamentoFuncao);
         GxWebStd.gx_hidden_field( context, "Z358FilaProcessamentoStatus", Z358FilaProcessamentoStatus);
         GxWebStd.gx_hidden_field( context, "Z359FilaProcessamentoCriacao", context.localUtil.TToC( Z359FilaProcessamentoCriacao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z360FilaProcessamentoAtualizacao", context.localUtil.TToC( Z360FilaProcessamentoAtualizacao, 10, 8, 0, 0, "/", ":", " "));
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
         return formatLink("filaprocessamento")  ;
      }

      public override string GetPgmname( )
      {
         return "FilaProcessamento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Fila Processamento" ;
      }

      protected void InitializeNonKey1D52( )
      {
         A356FilaProcessamentoFuncao = "";
         n356FilaProcessamentoFuncao = false;
         AssignAttri("", false, "A356FilaProcessamentoFuncao", A356FilaProcessamentoFuncao);
         n356FilaProcessamentoFuncao = (String.IsNullOrEmpty(StringUtil.RTrim( A356FilaProcessamentoFuncao)) ? true : false);
         A357FilaProcessamentoParametros = "";
         n357FilaProcessamentoParametros = false;
         AssignAttri("", false, "A357FilaProcessamentoParametros", A357FilaProcessamentoParametros);
         n357FilaProcessamentoParametros = (String.IsNullOrEmpty(StringUtil.RTrim( A357FilaProcessamentoParametros)) ? true : false);
         A358FilaProcessamentoStatus = "";
         n358FilaProcessamentoStatus = false;
         AssignAttri("", false, "A358FilaProcessamentoStatus", A358FilaProcessamentoStatus);
         n358FilaProcessamentoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A358FilaProcessamentoStatus)) ? true : false);
         A359FilaProcessamentoCriacao = (DateTime)(DateTime.MinValue);
         n359FilaProcessamentoCriacao = false;
         AssignAttri("", false, "A359FilaProcessamentoCriacao", context.localUtil.TToC( A359FilaProcessamentoCriacao, 8, 5, 0, 3, "/", ":", " "));
         n359FilaProcessamentoCriacao = ((DateTime.MinValue==A359FilaProcessamentoCriacao) ? true : false);
         A360FilaProcessamentoAtualizacao = (DateTime)(DateTime.MinValue);
         n360FilaProcessamentoAtualizacao = false;
         AssignAttri("", false, "A360FilaProcessamentoAtualizacao", context.localUtil.TToC( A360FilaProcessamentoAtualizacao, 8, 5, 0, 3, "/", ":", " "));
         n360FilaProcessamentoAtualizacao = ((DateTime.MinValue==A360FilaProcessamentoAtualizacao) ? true : false);
         Z356FilaProcessamentoFuncao = "";
         Z358FilaProcessamentoStatus = "";
         Z359FilaProcessamentoCriacao = (DateTime)(DateTime.MinValue);
         Z360FilaProcessamentoAtualizacao = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll1D52( )
      {
         A355FilaProcessamentoId = 0;
         AssignAttri("", false, "A355FilaProcessamentoId", StringUtil.LTrimStr( (decimal)(A355FilaProcessamentoId), 9, 0));
         InitializeNonKey1D52( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101916530", true, true);
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
         context.AddJavascriptSource("filaprocessamento.js", "?20256101916531", false, true);
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
         edtFilaProcessamentoId_Internalname = "FILAPROCESSAMENTOID";
         edtFilaProcessamentoFuncao_Internalname = "FILAPROCESSAMENTOFUNCAO";
         edtFilaProcessamentoParametros_Internalname = "FILAPROCESSAMENTOPARAMETROS";
         cmbFilaProcessamentoStatus_Internalname = "FILAPROCESSAMENTOSTATUS";
         edtFilaProcessamentoCriacao_Internalname = "FILAPROCESSAMENTOCRIACAO";
         edtFilaProcessamentoAtualizacao_Internalname = "FILAPROCESSAMENTOATUALIZACAO";
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
         Form.Caption = "Fila Processamento";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtFilaProcessamentoAtualizacao_Jsonclick = "";
         edtFilaProcessamentoAtualizacao_Enabled = 1;
         edtFilaProcessamentoCriacao_Jsonclick = "";
         edtFilaProcessamentoCriacao_Enabled = 1;
         cmbFilaProcessamentoStatus_Jsonclick = "";
         cmbFilaProcessamentoStatus.Enabled = 1;
         edtFilaProcessamentoParametros_Enabled = 1;
         edtFilaProcessamentoFuncao_Jsonclick = "";
         edtFilaProcessamentoFuncao_Enabled = 1;
         edtFilaProcessamentoId_Jsonclick = "";
         edtFilaProcessamentoId_Enabled = 1;
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
         cmbFilaProcessamentoStatus.Name = "FILAPROCESSAMENTOSTATUS";
         cmbFilaProcessamentoStatus.WebTags = "";
         cmbFilaProcessamentoStatus.addItem("PENDENTE", "PENDENTE", 0);
         cmbFilaProcessamentoStatus.addItem("PROCESSANDO", "PROCESSANDO", 0);
         cmbFilaProcessamentoStatus.addItem("CONCLUIDO", "CONCLUÌDO", 0);
         cmbFilaProcessamentoStatus.addItem("ERRO", "ERRO", 0);
         if ( cmbFilaProcessamentoStatus.ItemCount > 0 )
         {
            A358FilaProcessamentoStatus = cmbFilaProcessamentoStatus.getValidValue(A358FilaProcessamentoStatus);
            n358FilaProcessamentoStatus = false;
            AssignAttri("", false, "A358FilaProcessamentoStatus", A358FilaProcessamentoStatus);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtFilaProcessamentoFuncao_Internalname;
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

      public void Valid_Filaprocessamentoid( )
      {
         n358FilaProcessamentoStatus = false;
         A358FilaProcessamentoStatus = cmbFilaProcessamentoStatus.CurrentValue;
         n358FilaProcessamentoStatus = false;
         cmbFilaProcessamentoStatus.CurrentValue = A358FilaProcessamentoStatus;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbFilaProcessamentoStatus.ItemCount > 0 )
         {
            A358FilaProcessamentoStatus = cmbFilaProcessamentoStatus.getValidValue(A358FilaProcessamentoStatus);
            n358FilaProcessamentoStatus = false;
            cmbFilaProcessamentoStatus.CurrentValue = A358FilaProcessamentoStatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbFilaProcessamentoStatus.CurrentValue = StringUtil.RTrim( A358FilaProcessamentoStatus);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A356FilaProcessamentoFuncao", A356FilaProcessamentoFuncao);
         AssignAttri("", false, "A357FilaProcessamentoParametros", A357FilaProcessamentoParametros);
         AssignAttri("", false, "A358FilaProcessamentoStatus", A358FilaProcessamentoStatus);
         cmbFilaProcessamentoStatus.CurrentValue = StringUtil.RTrim( A358FilaProcessamentoStatus);
         AssignProp("", false, cmbFilaProcessamentoStatus_Internalname, "Values", cmbFilaProcessamentoStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A359FilaProcessamentoCriacao", context.localUtil.TToC( A359FilaProcessamentoCriacao, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A360FilaProcessamentoAtualizacao", context.localUtil.TToC( A360FilaProcessamentoAtualizacao, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z355FilaProcessamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z355FilaProcessamentoId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z356FilaProcessamentoFuncao", Z356FilaProcessamentoFuncao);
         GxWebStd.gx_hidden_field( context, "Z357FilaProcessamentoParametros", Z357FilaProcessamentoParametros);
         GxWebStd.gx_hidden_field( context, "Z358FilaProcessamentoStatus", Z358FilaProcessamentoStatus);
         GxWebStd.gx_hidden_field( context, "Z359FilaProcessamentoCriacao", context.localUtil.TToC( Z359FilaProcessamentoCriacao, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z360FilaProcessamentoAtualizacao", context.localUtil.TToC( Z360FilaProcessamentoAtualizacao, 10, 8, 0, 3, "/", ":", " "));
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
         setEventMetadata("VALID_FILAPROCESSAMENTOID","""{"handler":"Valid_Filaprocessamentoid","iparms":[{"av":"cmbFilaProcessamentoStatus"},{"av":"A358FilaProcessamentoStatus","fld":"FILAPROCESSAMENTOSTATUS","type":"svchar"},{"av":"A355FilaProcessamentoId","fld":"FILAPROCESSAMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_FILAPROCESSAMENTOID",""","oparms":[{"av":"A356FilaProcessamentoFuncao","fld":"FILAPROCESSAMENTOFUNCAO","type":"svchar"},{"av":"A357FilaProcessamentoParametros","fld":"FILAPROCESSAMENTOPARAMETROS","type":"vchar"},{"av":"cmbFilaProcessamentoStatus"},{"av":"A358FilaProcessamentoStatus","fld":"FILAPROCESSAMENTOSTATUS","type":"svchar"},{"av":"A359FilaProcessamentoCriacao","fld":"FILAPROCESSAMENTOCRIACAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"A360FilaProcessamentoAtualizacao","fld":"FILAPROCESSAMENTOATUALIZACAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z355FilaProcessamentoId","type":"int"},{"av":"Z356FilaProcessamentoFuncao","type":"svchar"},{"av":"Z357FilaProcessamentoParametros","type":"vchar"},{"av":"Z358FilaProcessamentoStatus","type":"svchar"},{"av":"Z359FilaProcessamentoCriacao","type":"dtime"},{"av":"Z360FilaProcessamentoAtualizacao","type":"dtime"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_FILAPROCESSAMENTOSTATUS","""{"handler":"Valid_Filaprocessamentostatus","iparms":[]}""");
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
         Z356FilaProcessamentoFuncao = "";
         Z358FilaProcessamentoStatus = "";
         Z359FilaProcessamentoCriacao = (DateTime)(DateTime.MinValue);
         Z360FilaProcessamentoAtualizacao = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A358FilaProcessamentoStatus = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A356FilaProcessamentoFuncao = "";
         A357FilaProcessamentoParametros = "";
         A359FilaProcessamentoCriacao = (DateTime)(DateTime.MinValue);
         A360FilaProcessamentoAtualizacao = (DateTime)(DateTime.MinValue);
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
         Z357FilaProcessamentoParametros = "";
         T001D4_A355FilaProcessamentoId = new int[1] ;
         T001D4_A356FilaProcessamentoFuncao = new string[] {""} ;
         T001D4_n356FilaProcessamentoFuncao = new bool[] {false} ;
         T001D4_A357FilaProcessamentoParametros = new string[] {""} ;
         T001D4_n357FilaProcessamentoParametros = new bool[] {false} ;
         T001D4_A358FilaProcessamentoStatus = new string[] {""} ;
         T001D4_n358FilaProcessamentoStatus = new bool[] {false} ;
         T001D4_A359FilaProcessamentoCriacao = new DateTime[] {DateTime.MinValue} ;
         T001D4_n359FilaProcessamentoCriacao = new bool[] {false} ;
         T001D4_A360FilaProcessamentoAtualizacao = new DateTime[] {DateTime.MinValue} ;
         T001D4_n360FilaProcessamentoAtualizacao = new bool[] {false} ;
         T001D5_A355FilaProcessamentoId = new int[1] ;
         T001D3_A355FilaProcessamentoId = new int[1] ;
         T001D3_A356FilaProcessamentoFuncao = new string[] {""} ;
         T001D3_n356FilaProcessamentoFuncao = new bool[] {false} ;
         T001D3_A357FilaProcessamentoParametros = new string[] {""} ;
         T001D3_n357FilaProcessamentoParametros = new bool[] {false} ;
         T001D3_A358FilaProcessamentoStatus = new string[] {""} ;
         T001D3_n358FilaProcessamentoStatus = new bool[] {false} ;
         T001D3_A359FilaProcessamentoCriacao = new DateTime[] {DateTime.MinValue} ;
         T001D3_n359FilaProcessamentoCriacao = new bool[] {false} ;
         T001D3_A360FilaProcessamentoAtualizacao = new DateTime[] {DateTime.MinValue} ;
         T001D3_n360FilaProcessamentoAtualizacao = new bool[] {false} ;
         sMode52 = "";
         T001D6_A355FilaProcessamentoId = new int[1] ;
         T001D7_A355FilaProcessamentoId = new int[1] ;
         T001D2_A355FilaProcessamentoId = new int[1] ;
         T001D2_A356FilaProcessamentoFuncao = new string[] {""} ;
         T001D2_n356FilaProcessamentoFuncao = new bool[] {false} ;
         T001D2_A357FilaProcessamentoParametros = new string[] {""} ;
         T001D2_n357FilaProcessamentoParametros = new bool[] {false} ;
         T001D2_A358FilaProcessamentoStatus = new string[] {""} ;
         T001D2_n358FilaProcessamentoStatus = new bool[] {false} ;
         T001D2_A359FilaProcessamentoCriacao = new DateTime[] {DateTime.MinValue} ;
         T001D2_n359FilaProcessamentoCriacao = new bool[] {false} ;
         T001D2_A360FilaProcessamentoAtualizacao = new DateTime[] {DateTime.MinValue} ;
         T001D2_n360FilaProcessamentoAtualizacao = new bool[] {false} ;
         T001D9_A355FilaProcessamentoId = new int[1] ;
         T001D12_A355FilaProcessamentoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ356FilaProcessamentoFuncao = "";
         ZZ357FilaProcessamentoParametros = "";
         ZZ358FilaProcessamentoStatus = "";
         ZZ359FilaProcessamentoCriacao = (DateTime)(DateTime.MinValue);
         ZZ360FilaProcessamentoAtualizacao = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.filaprocessamento__default(),
            new Object[][] {
                new Object[] {
               T001D2_A355FilaProcessamentoId, T001D2_A356FilaProcessamentoFuncao, T001D2_n356FilaProcessamentoFuncao, T001D2_A357FilaProcessamentoParametros, T001D2_n357FilaProcessamentoParametros, T001D2_A358FilaProcessamentoStatus, T001D2_n358FilaProcessamentoStatus, T001D2_A359FilaProcessamentoCriacao, T001D2_n359FilaProcessamentoCriacao, T001D2_A360FilaProcessamentoAtualizacao,
               T001D2_n360FilaProcessamentoAtualizacao
               }
               , new Object[] {
               T001D3_A355FilaProcessamentoId, T001D3_A356FilaProcessamentoFuncao, T001D3_n356FilaProcessamentoFuncao, T001D3_A357FilaProcessamentoParametros, T001D3_n357FilaProcessamentoParametros, T001D3_A358FilaProcessamentoStatus, T001D3_n358FilaProcessamentoStatus, T001D3_A359FilaProcessamentoCriacao, T001D3_n359FilaProcessamentoCriacao, T001D3_A360FilaProcessamentoAtualizacao,
               T001D3_n360FilaProcessamentoAtualizacao
               }
               , new Object[] {
               T001D4_A355FilaProcessamentoId, T001D4_A356FilaProcessamentoFuncao, T001D4_n356FilaProcessamentoFuncao, T001D4_A357FilaProcessamentoParametros, T001D4_n357FilaProcessamentoParametros, T001D4_A358FilaProcessamentoStatus, T001D4_n358FilaProcessamentoStatus, T001D4_A359FilaProcessamentoCriacao, T001D4_n359FilaProcessamentoCriacao, T001D4_A360FilaProcessamentoAtualizacao,
               T001D4_n360FilaProcessamentoAtualizacao
               }
               , new Object[] {
               T001D5_A355FilaProcessamentoId
               }
               , new Object[] {
               T001D6_A355FilaProcessamentoId
               }
               , new Object[] {
               T001D7_A355FilaProcessamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               T001D9_A355FilaProcessamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001D12_A355FilaProcessamentoId
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
      private short RcdFound52 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z355FilaProcessamentoId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A355FilaProcessamentoId ;
      private int edtFilaProcessamentoId_Enabled ;
      private int edtFilaProcessamentoFuncao_Enabled ;
      private int edtFilaProcessamentoParametros_Enabled ;
      private int edtFilaProcessamentoCriacao_Enabled ;
      private int edtFilaProcessamentoAtualizacao_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ355FilaProcessamentoId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFilaProcessamentoId_Internalname ;
      private string cmbFilaProcessamentoStatus_Internalname ;
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
      private string edtFilaProcessamentoId_Jsonclick ;
      private string edtFilaProcessamentoFuncao_Internalname ;
      private string edtFilaProcessamentoFuncao_Jsonclick ;
      private string edtFilaProcessamentoParametros_Internalname ;
      private string cmbFilaProcessamentoStatus_Jsonclick ;
      private string edtFilaProcessamentoCriacao_Internalname ;
      private string edtFilaProcessamentoCriacao_Jsonclick ;
      private string edtFilaProcessamentoAtualizacao_Internalname ;
      private string edtFilaProcessamentoAtualizacao_Jsonclick ;
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
      private string sMode52 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z359FilaProcessamentoCriacao ;
      private DateTime Z360FilaProcessamentoAtualizacao ;
      private DateTime A359FilaProcessamentoCriacao ;
      private DateTime A360FilaProcessamentoAtualizacao ;
      private DateTime ZZ359FilaProcessamentoCriacao ;
      private DateTime ZZ360FilaProcessamentoAtualizacao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n358FilaProcessamentoStatus ;
      private bool n356FilaProcessamentoFuncao ;
      private bool n359FilaProcessamentoCriacao ;
      private bool n360FilaProcessamentoAtualizacao ;
      private bool n357FilaProcessamentoParametros ;
      private string A357FilaProcessamentoParametros ;
      private string Z357FilaProcessamentoParametros ;
      private string ZZ357FilaProcessamentoParametros ;
      private string Z356FilaProcessamentoFuncao ;
      private string Z358FilaProcessamentoStatus ;
      private string A358FilaProcessamentoStatus ;
      private string A356FilaProcessamentoFuncao ;
      private string ZZ356FilaProcessamentoFuncao ;
      private string ZZ358FilaProcessamentoStatus ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFilaProcessamentoStatus ;
      private IDataStoreProvider pr_default ;
      private int[] T001D4_A355FilaProcessamentoId ;
      private string[] T001D4_A356FilaProcessamentoFuncao ;
      private bool[] T001D4_n356FilaProcessamentoFuncao ;
      private string[] T001D4_A357FilaProcessamentoParametros ;
      private bool[] T001D4_n357FilaProcessamentoParametros ;
      private string[] T001D4_A358FilaProcessamentoStatus ;
      private bool[] T001D4_n358FilaProcessamentoStatus ;
      private DateTime[] T001D4_A359FilaProcessamentoCriacao ;
      private bool[] T001D4_n359FilaProcessamentoCriacao ;
      private DateTime[] T001D4_A360FilaProcessamentoAtualizacao ;
      private bool[] T001D4_n360FilaProcessamentoAtualizacao ;
      private int[] T001D5_A355FilaProcessamentoId ;
      private int[] T001D3_A355FilaProcessamentoId ;
      private string[] T001D3_A356FilaProcessamentoFuncao ;
      private bool[] T001D3_n356FilaProcessamentoFuncao ;
      private string[] T001D3_A357FilaProcessamentoParametros ;
      private bool[] T001D3_n357FilaProcessamentoParametros ;
      private string[] T001D3_A358FilaProcessamentoStatus ;
      private bool[] T001D3_n358FilaProcessamentoStatus ;
      private DateTime[] T001D3_A359FilaProcessamentoCriacao ;
      private bool[] T001D3_n359FilaProcessamentoCriacao ;
      private DateTime[] T001D3_A360FilaProcessamentoAtualizacao ;
      private bool[] T001D3_n360FilaProcessamentoAtualizacao ;
      private int[] T001D6_A355FilaProcessamentoId ;
      private int[] T001D7_A355FilaProcessamentoId ;
      private int[] T001D2_A355FilaProcessamentoId ;
      private string[] T001D2_A356FilaProcessamentoFuncao ;
      private bool[] T001D2_n356FilaProcessamentoFuncao ;
      private string[] T001D2_A357FilaProcessamentoParametros ;
      private bool[] T001D2_n357FilaProcessamentoParametros ;
      private string[] T001D2_A358FilaProcessamentoStatus ;
      private bool[] T001D2_n358FilaProcessamentoStatus ;
      private DateTime[] T001D2_A359FilaProcessamentoCriacao ;
      private bool[] T001D2_n359FilaProcessamentoCriacao ;
      private DateTime[] T001D2_A360FilaProcessamentoAtualizacao ;
      private bool[] T001D2_n360FilaProcessamentoAtualizacao ;
      private int[] T001D9_A355FilaProcessamentoId ;
      private int[] T001D12_A355FilaProcessamentoId ;
   }

   public class filaprocessamento__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT001D2;
          prmT001D2 = new Object[] {
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmT001D3;
          prmT001D3 = new Object[] {
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmT001D4;
          prmT001D4 = new Object[] {
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmT001D5;
          prmT001D5 = new Object[] {
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmT001D6;
          prmT001D6 = new Object[] {
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmT001D7;
          prmT001D7 = new Object[] {
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmT001D8;
          prmT001D8 = new Object[] {
          new ParDef("FilaProcessamentoFuncao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("FilaProcessamentoParametros",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("FilaProcessamentoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("FilaProcessamentoCriacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("FilaProcessamentoAtualizacao",GXType.DateTime,8,5){Nullable=true}
          };
          Object[] prmT001D9;
          prmT001D9 = new Object[] {
          };
          Object[] prmT001D10;
          prmT001D10 = new Object[] {
          new ParDef("FilaProcessamentoFuncao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("FilaProcessamentoParametros",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("FilaProcessamentoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("FilaProcessamentoCriacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("FilaProcessamentoAtualizacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmT001D11;
          prmT001D11 = new Object[] {
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmT001D12;
          prmT001D12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T001D2", "SELECT FilaProcessamentoId, FilaProcessamentoFuncao, FilaProcessamentoParametros, FilaProcessamentoStatus, FilaProcessamentoCriacao, FilaProcessamentoAtualizacao FROM FilaProcessamento WHERE FilaProcessamentoId = :FilaProcessamentoId  FOR UPDATE OF FilaProcessamento NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001D2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001D3", "SELECT FilaProcessamentoId, FilaProcessamentoFuncao, FilaProcessamentoParametros, FilaProcessamentoStatus, FilaProcessamentoCriacao, FilaProcessamentoAtualizacao FROM FilaProcessamento WHERE FilaProcessamentoId = :FilaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001D4", "SELECT TM1.FilaProcessamentoId, TM1.FilaProcessamentoFuncao, TM1.FilaProcessamentoParametros, TM1.FilaProcessamentoStatus, TM1.FilaProcessamentoCriacao, TM1.FilaProcessamentoAtualizacao FROM FilaProcessamento TM1 WHERE TM1.FilaProcessamentoId = :FilaProcessamentoId ORDER BY TM1.FilaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001D5", "SELECT FilaProcessamentoId FROM FilaProcessamento WHERE FilaProcessamentoId = :FilaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001D6", "SELECT FilaProcessamentoId FROM FilaProcessamento WHERE ( FilaProcessamentoId > :FilaProcessamentoId) ORDER BY FilaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001D7", "SELECT FilaProcessamentoId FROM FilaProcessamento WHERE ( FilaProcessamentoId < :FilaProcessamentoId) ORDER BY FilaProcessamentoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001D8", "SAVEPOINT gxupdate;INSERT INTO FilaProcessamento(FilaProcessamentoFuncao, FilaProcessamentoParametros, FilaProcessamentoStatus, FilaProcessamentoCriacao, FilaProcessamentoAtualizacao) VALUES(:FilaProcessamentoFuncao, :FilaProcessamentoParametros, :FilaProcessamentoStatus, :FilaProcessamentoCriacao, :FilaProcessamentoAtualizacao);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001D8)
             ,new CursorDef("T001D9", "SELECT currval('FilaProcessamentoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001D10", "SAVEPOINT gxupdate;UPDATE FilaProcessamento SET FilaProcessamentoFuncao=:FilaProcessamentoFuncao, FilaProcessamentoParametros=:FilaProcessamentoParametros, FilaProcessamentoStatus=:FilaProcessamentoStatus, FilaProcessamentoCriacao=:FilaProcessamentoCriacao, FilaProcessamentoAtualizacao=:FilaProcessamentoAtualizacao  WHERE FilaProcessamentoId = :FilaProcessamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001D10)
             ,new CursorDef("T001D11", "SAVEPOINT gxupdate;DELETE FROM FilaProcessamento  WHERE FilaProcessamentoId = :FilaProcessamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001D11)
             ,new CursorDef("T001D12", "SELECT FilaProcessamentoId FROM FilaProcessamento ORDER BY FilaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D12,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
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
