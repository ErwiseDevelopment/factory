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
   public class relacionamento : GXDataArea
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
            A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A168ClienteId) ;
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
         Form.Meta.addItem("description", "Relacionamento", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtRelacionamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public relacionamento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public relacionamento( IGxContext context )
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
         cmbRelacionamentoTipo = new GXCombobox();
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
         if ( cmbRelacionamentoTipo.ItemCount > 0 )
         {
            A1033RelacionamentoTipo = cmbRelacionamentoTipo.getValidValue(A1033RelacionamentoTipo);
            n1033RelacionamentoTipo = false;
            AssignAttri("", false, "A1033RelacionamentoTipo", A1033RelacionamentoTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRelacionamentoTipo.CurrentValue = StringUtil.RTrim( A1033RelacionamentoTipo);
            AssignProp("", false, cmbRelacionamentoTipo_Internalname, "Values", cmbRelacionamentoTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Relacionamento", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Relacionamento.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Relacionamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Relacionamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Relacionamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Relacionamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Relacionamento.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtRelacionamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRelacionamentoId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRelacionamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1032RelacionamentoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtRelacionamentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1032RelacionamentoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1032RelacionamentoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRelacionamentoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRelacionamentoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Relacionamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Cliente Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", ""))), ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( ((edtClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Relacionamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbRelacionamentoTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbRelacionamentoTipo_Internalname, "Tipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbRelacionamentoTipo, cmbRelacionamentoTipo_Internalname, StringUtil.RTrim( A1033RelacionamentoTipo), 1, cmbRelacionamentoTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbRelacionamentoTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", true, 0, "HLP_Relacionamento.htm");
         cmbRelacionamentoTipo.CurrentValue = StringUtil.RTrim( A1033RelacionamentoTipo);
         AssignProp("", false, cmbRelacionamentoTipo_Internalname, "Values", (string)(cmbRelacionamentoTipo.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Relacionamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Relacionamento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Relacionamento.htm");
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
            Z1032RelacionamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1032RelacionamentoId"), ",", "."), 18, MidpointRounding.ToEven));
            Z1033RelacionamentoTipo = cgiGet( "Z1033RelacionamentoTipo");
            n1033RelacionamentoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A1033RelacionamentoTipo)) ? true : false);
            Z168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
            n168ClienteId = ((0==A168ClienteId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtRelacionamentoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRelacionamentoId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RELACIONAMENTOID");
               AnyError = 1;
               GX_FocusControl = edtRelacionamentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1032RelacionamentoId = 0;
               AssignAttri("", false, "A1032RelacionamentoId", StringUtil.LTrimStr( (decimal)(A1032RelacionamentoId), 9, 0));
            }
            else
            {
               A1032RelacionamentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtRelacionamentoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1032RelacionamentoId", StringUtil.LTrimStr( (decimal)(A1032RelacionamentoId), 9, 0));
            }
            n168ClienteId = ((StringUtil.StrCmp(cgiGet( edtClienteId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A168ClienteId = 0;
               n168ClienteId = false;
               AssignAttri("", false, "A168ClienteId", (n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            }
            else
            {
               A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A168ClienteId", (n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            }
            cmbRelacionamentoTipo.CurrentValue = cgiGet( cmbRelacionamentoTipo_Internalname);
            A1033RelacionamentoTipo = cgiGet( cmbRelacionamentoTipo_Internalname);
            n1033RelacionamentoTipo = false;
            AssignAttri("", false, "A1033RelacionamentoTipo", A1033RelacionamentoTipo);
            n1033RelacionamentoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A1033RelacionamentoTipo)) ? true : false);
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
               A1032RelacionamentoId = (int)(Math.Round(NumberUtil.Val( GetPar( "RelacionamentoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A1032RelacionamentoId", StringUtil.LTrimStr( (decimal)(A1032RelacionamentoId), 9, 0));
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
               InitAll33107( ) ;
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
         DisableAttributes33107( ) ;
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

      protected void ResetCaption330( )
      {
      }

      protected void ZM33107( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1033RelacionamentoTipo = T00333_A1033RelacionamentoTipo[0];
               Z168ClienteId = T00333_A168ClienteId[0];
            }
            else
            {
               Z1033RelacionamentoTipo = A1033RelacionamentoTipo;
               Z168ClienteId = A168ClienteId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z1032RelacionamentoId = A1032RelacionamentoId;
            Z1033RelacionamentoTipo = A1033RelacionamentoTipo;
            Z168ClienteId = A168ClienteId;
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

      protected void Load33107( )
      {
         /* Using cursor T00335 */
         pr_default.execute(3, new Object[] {A1032RelacionamentoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound107 = 1;
            A1033RelacionamentoTipo = T00335_A1033RelacionamentoTipo[0];
            n1033RelacionamentoTipo = T00335_n1033RelacionamentoTipo[0];
            AssignAttri("", false, "A1033RelacionamentoTipo", A1033RelacionamentoTipo);
            A168ClienteId = T00335_A168ClienteId[0];
            n168ClienteId = T00335_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            ZM33107( -2) ;
         }
         pr_default.close(3);
         OnLoadActions33107( ) ;
      }

      protected void OnLoadActions33107( )
      {
      }

      protected void CheckExtendedTable33107( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00334 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A1033RelacionamentoTipo, "Cliente") == 0 ) || ( StringUtil.StrCmp(A1033RelacionamentoTipo, "Paciente") == 0 ) || ( StringUtil.StrCmp(A1033RelacionamentoTipo, "Clinica") == 0 ) || ( StringUtil.StrCmp(A1033RelacionamentoTipo, "Sacado") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1033RelacionamentoTipo)) ) )
         {
            GX_msglist.addItem("Campo Relacionamento Tipo fora do intervalo", "OutOfRange", 1, "RELACIONAMENTOTIPO");
            AnyError = 1;
            GX_FocusControl = cmbRelacionamentoTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors33107( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A168ClienteId )
      {
         /* Using cursor T00336 */
         pr_default.execute(4, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
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

      protected void GetKey33107( )
      {
         /* Using cursor T00337 */
         pr_default.execute(5, new Object[] {A1032RelacionamentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound107 = 1;
         }
         else
         {
            RcdFound107 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00333 */
         pr_default.execute(1, new Object[] {A1032RelacionamentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM33107( 2) ;
            RcdFound107 = 1;
            A1032RelacionamentoId = T00333_A1032RelacionamentoId[0];
            AssignAttri("", false, "A1032RelacionamentoId", StringUtil.LTrimStr( (decimal)(A1032RelacionamentoId), 9, 0));
            A1033RelacionamentoTipo = T00333_A1033RelacionamentoTipo[0];
            n1033RelacionamentoTipo = T00333_n1033RelacionamentoTipo[0];
            AssignAttri("", false, "A1033RelacionamentoTipo", A1033RelacionamentoTipo);
            A168ClienteId = T00333_A168ClienteId[0];
            n168ClienteId = T00333_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            Z1032RelacionamentoId = A1032RelacionamentoId;
            sMode107 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load33107( ) ;
            if ( AnyError == 1 )
            {
               RcdFound107 = 0;
               InitializeNonKey33107( ) ;
            }
            Gx_mode = sMode107;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound107 = 0;
            InitializeNonKey33107( ) ;
            sMode107 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode107;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey33107( ) ;
         if ( RcdFound107 == 0 )
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
         RcdFound107 = 0;
         /* Using cursor T00338 */
         pr_default.execute(6, new Object[] {A1032RelacionamentoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00338_A1032RelacionamentoId[0] < A1032RelacionamentoId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00338_A1032RelacionamentoId[0] > A1032RelacionamentoId ) ) )
            {
               A1032RelacionamentoId = T00338_A1032RelacionamentoId[0];
               AssignAttri("", false, "A1032RelacionamentoId", StringUtil.LTrimStr( (decimal)(A1032RelacionamentoId), 9, 0));
               RcdFound107 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound107 = 0;
         /* Using cursor T00339 */
         pr_default.execute(7, new Object[] {A1032RelacionamentoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00339_A1032RelacionamentoId[0] > A1032RelacionamentoId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00339_A1032RelacionamentoId[0] < A1032RelacionamentoId ) ) )
            {
               A1032RelacionamentoId = T00339_A1032RelacionamentoId[0];
               AssignAttri("", false, "A1032RelacionamentoId", StringUtil.LTrimStr( (decimal)(A1032RelacionamentoId), 9, 0));
               RcdFound107 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey33107( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtRelacionamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert33107( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound107 == 1 )
            {
               if ( A1032RelacionamentoId != Z1032RelacionamentoId )
               {
                  A1032RelacionamentoId = Z1032RelacionamentoId;
                  AssignAttri("", false, "A1032RelacionamentoId", StringUtil.LTrimStr( (decimal)(A1032RelacionamentoId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RELACIONAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtRelacionamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtRelacionamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update33107( ) ;
                  GX_FocusControl = edtRelacionamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1032RelacionamentoId != Z1032RelacionamentoId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtRelacionamentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert33107( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RELACIONAMENTOID");
                     AnyError = 1;
                     GX_FocusControl = edtRelacionamentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtRelacionamentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert33107( ) ;
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
         if ( A1032RelacionamentoId != Z1032RelacionamentoId )
         {
            A1032RelacionamentoId = Z1032RelacionamentoId;
            AssignAttri("", false, "A1032RelacionamentoId", StringUtil.LTrimStr( (decimal)(A1032RelacionamentoId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RELACIONAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtRelacionamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtRelacionamentoId_Internalname;
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
         if ( RcdFound107 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "RELACIONAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtRelacionamentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtClienteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart33107( ) ;
         if ( RcdFound107 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd33107( ) ;
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
         if ( RcdFound107 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteId_Internalname;
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
         if ( RcdFound107 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteId_Internalname;
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
         ScanStart33107( ) ;
         if ( RcdFound107 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound107 != 0 )
            {
               ScanNext33107( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd33107( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency33107( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00332 */
            pr_default.execute(0, new Object[] {A1032RelacionamentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Relacionamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1033RelacionamentoTipo, T00332_A1033RelacionamentoTipo[0]) != 0 ) || ( Z168ClienteId != T00332_A168ClienteId[0] ) )
            {
               if ( StringUtil.StrCmp(Z1033RelacionamentoTipo, T00332_A1033RelacionamentoTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("relacionamento:[seudo value changed for attri]"+"RelacionamentoTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1033RelacionamentoTipo);
                  GXUtil.WriteLogRaw("Current: ",T00332_A1033RelacionamentoTipo[0]);
               }
               if ( Z168ClienteId != T00332_A168ClienteId[0] )
               {
                  GXUtil.WriteLog("relacionamento:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z168ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T00332_A168ClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Relacionamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert33107( )
      {
         BeforeValidate33107( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable33107( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM33107( 0) ;
            CheckOptimisticConcurrency33107( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm33107( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert33107( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003310 */
                     pr_default.execute(8, new Object[] {n1033RelacionamentoTipo, A1033RelacionamentoTipo, n168ClienteId, A168ClienteId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T003311 */
                     pr_default.execute(9);
                     A1032RelacionamentoId = T003311_A1032RelacionamentoId[0];
                     AssignAttri("", false, "A1032RelacionamentoId", StringUtil.LTrimStr( (decimal)(A1032RelacionamentoId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Relacionamento");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption330( ) ;
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
               Load33107( ) ;
            }
            EndLevel33107( ) ;
         }
         CloseExtendedTableCursors33107( ) ;
      }

      protected void Update33107( )
      {
         BeforeValidate33107( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable33107( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency33107( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm33107( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate33107( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003312 */
                     pr_default.execute(10, new Object[] {n1033RelacionamentoTipo, A1033RelacionamentoTipo, n168ClienteId, A168ClienteId, A1032RelacionamentoId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Relacionamento");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Relacionamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate33107( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption330( ) ;
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
            EndLevel33107( ) ;
         }
         CloseExtendedTableCursors33107( ) ;
      }

      protected void DeferredUpdate33107( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate33107( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency33107( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls33107( ) ;
            AfterConfirm33107( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete33107( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003313 */
                  pr_default.execute(11, new Object[] {A1032RelacionamentoId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Relacionamento");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound107 == 0 )
                        {
                           InitAll33107( ) ;
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
                        ResetCaption330( ) ;
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
         sMode107 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel33107( ) ;
         Gx_mode = sMode107;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls33107( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel33107( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete33107( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues330( ) ;
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

      public void ScanStart33107( )
      {
         /* Using cursor T003314 */
         pr_default.execute(12);
         RcdFound107 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound107 = 1;
            A1032RelacionamentoId = T003314_A1032RelacionamentoId[0];
            AssignAttri("", false, "A1032RelacionamentoId", StringUtil.LTrimStr( (decimal)(A1032RelacionamentoId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext33107( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound107 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound107 = 1;
            A1032RelacionamentoId = T003314_A1032RelacionamentoId[0];
            AssignAttri("", false, "A1032RelacionamentoId", StringUtil.LTrimStr( (decimal)(A1032RelacionamentoId), 9, 0));
         }
      }

      protected void ScanEnd33107( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm33107( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert33107( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate33107( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete33107( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete33107( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate33107( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes33107( )
      {
         edtRelacionamentoId_Enabled = 0;
         AssignProp("", false, edtRelacionamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRelacionamentoId_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         cmbRelacionamentoTipo.Enabled = 0;
         AssignProp("", false, cmbRelacionamentoTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRelacionamentoTipo.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes33107( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues330( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("relacionamento") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1032RelacionamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1032RelacionamentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1033RelacionamentoTipo", Z1033RelacionamentoTipo);
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ",", "")));
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
         return formatLink("relacionamento")  ;
      }

      public override string GetPgmname( )
      {
         return "Relacionamento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Relacionamento" ;
      }

      protected void InitializeNonKey33107( )
      {
         A168ClienteId = 0;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         n168ClienteId = ((0==A168ClienteId) ? true : false);
         A1033RelacionamentoTipo = "";
         n1033RelacionamentoTipo = false;
         AssignAttri("", false, "A1033RelacionamentoTipo", A1033RelacionamentoTipo);
         n1033RelacionamentoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A1033RelacionamentoTipo)) ? true : false);
         Z1033RelacionamentoTipo = "";
         Z168ClienteId = 0;
      }

      protected void InitAll33107( )
      {
         A1032RelacionamentoId = 0;
         AssignAttri("", false, "A1032RelacionamentoId", StringUtil.LTrimStr( (decimal)(A1032RelacionamentoId), 9, 0));
         InitializeNonKey33107( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019221424", true, true);
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
         context.AddJavascriptSource("relacionamento.js", "?202561019221425", false, true);
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
         edtRelacionamentoId_Internalname = "RELACIONAMENTOID";
         edtClienteId_Internalname = "CLIENTEID";
         cmbRelacionamentoTipo_Internalname = "RELACIONAMENTOTIPO";
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
         Form.Caption = "Relacionamento";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbRelacionamentoTipo_Jsonclick = "";
         cmbRelacionamentoTipo.Enabled = 1;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtRelacionamentoId_Jsonclick = "";
         edtRelacionamentoId_Enabled = 1;
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
         cmbRelacionamentoTipo.Name = "RELACIONAMENTOTIPO";
         cmbRelacionamentoTipo.WebTags = "";
         cmbRelacionamentoTipo.addItem("Cliente", "Cliente", 0);
         cmbRelacionamentoTipo.addItem("Paciente", "Paciente", 0);
         cmbRelacionamentoTipo.addItem("Clinica", "Clinica", 0);
         cmbRelacionamentoTipo.addItem("Sacado", "Sacado", 0);
         if ( cmbRelacionamentoTipo.ItemCount > 0 )
         {
            A1033RelacionamentoTipo = cmbRelacionamentoTipo.getValidValue(A1033RelacionamentoTipo);
            n1033RelacionamentoTipo = false;
            AssignAttri("", false, "A1033RelacionamentoTipo", A1033RelacionamentoTipo);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtClienteId_Internalname;
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

      public void Valid_Relacionamentoid( )
      {
         n1033RelacionamentoTipo = false;
         A1033RelacionamentoTipo = cmbRelacionamentoTipo.CurrentValue;
         n1033RelacionamentoTipo = false;
         cmbRelacionamentoTipo.CurrentValue = A1033RelacionamentoTipo;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbRelacionamentoTipo.ItemCount > 0 )
         {
            A1033RelacionamentoTipo = cmbRelacionamentoTipo.getValidValue(A1033RelacionamentoTipo);
            n1033RelacionamentoTipo = false;
            cmbRelacionamentoTipo.CurrentValue = A1033RelacionamentoTipo;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRelacionamentoTipo.CurrentValue = StringUtil.RTrim( A1033RelacionamentoTipo);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         AssignAttri("", false, "A1033RelacionamentoTipo", A1033RelacionamentoTipo);
         cmbRelacionamentoTipo.CurrentValue = StringUtil.RTrim( A1033RelacionamentoTipo);
         AssignProp("", false, cmbRelacionamentoTipo_Internalname, "Values", cmbRelacionamentoTipo.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z1032RelacionamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1032RelacionamentoId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1033RelacionamentoTipo", Z1033RelacionamentoTipo);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Clienteid( )
      {
         /* Using cursor T003315 */
         pr_default.execute(13, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_RELACIONAMENTOID","""{"handler":"Valid_Relacionamentoid","iparms":[{"av":"cmbRelacionamentoTipo"},{"av":"A1033RelacionamentoTipo","fld":"RELACIONAMENTOTIPO","type":"svchar"},{"av":"A1032RelacionamentoId","fld":"RELACIONAMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_RELACIONAMENTOID",""","oparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"},{"av":"cmbRelacionamentoTipo"},{"av":"A1033RelacionamentoTipo","fld":"RELACIONAMENTOTIPO","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z1032RelacionamentoId","type":"int"},{"av":"Z168ClienteId","type":"int"},{"av":"Z1033RelacionamentoTipo","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"}]}""");
         setEventMetadata("VALID_RELACIONAMENTOTIPO","""{"handler":"Valid_Relacionamentotipo","iparms":[]}""");
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
         Z1033RelacionamentoTipo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1033RelacionamentoTipo = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
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
         T00335_A1032RelacionamentoId = new int[1] ;
         T00335_A1033RelacionamentoTipo = new string[] {""} ;
         T00335_n1033RelacionamentoTipo = new bool[] {false} ;
         T00335_A168ClienteId = new int[1] ;
         T00335_n168ClienteId = new bool[] {false} ;
         T00334_A168ClienteId = new int[1] ;
         T00334_n168ClienteId = new bool[] {false} ;
         T00336_A168ClienteId = new int[1] ;
         T00336_n168ClienteId = new bool[] {false} ;
         T00337_A1032RelacionamentoId = new int[1] ;
         T00333_A1032RelacionamentoId = new int[1] ;
         T00333_A1033RelacionamentoTipo = new string[] {""} ;
         T00333_n1033RelacionamentoTipo = new bool[] {false} ;
         T00333_A168ClienteId = new int[1] ;
         T00333_n168ClienteId = new bool[] {false} ;
         sMode107 = "";
         T00338_A1032RelacionamentoId = new int[1] ;
         T00339_A1032RelacionamentoId = new int[1] ;
         T00332_A1032RelacionamentoId = new int[1] ;
         T00332_A1033RelacionamentoTipo = new string[] {""} ;
         T00332_n1033RelacionamentoTipo = new bool[] {false} ;
         T00332_A168ClienteId = new int[1] ;
         T00332_n168ClienteId = new bool[] {false} ;
         T003311_A1032RelacionamentoId = new int[1] ;
         T003314_A1032RelacionamentoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1033RelacionamentoTipo = "";
         T003315_A168ClienteId = new int[1] ;
         T003315_n168ClienteId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.relacionamento__default(),
            new Object[][] {
                new Object[] {
               T00332_A1032RelacionamentoId, T00332_A1033RelacionamentoTipo, T00332_n1033RelacionamentoTipo, T00332_A168ClienteId, T00332_n168ClienteId
               }
               , new Object[] {
               T00333_A1032RelacionamentoId, T00333_A1033RelacionamentoTipo, T00333_n1033RelacionamentoTipo, T00333_A168ClienteId, T00333_n168ClienteId
               }
               , new Object[] {
               T00334_A168ClienteId
               }
               , new Object[] {
               T00335_A1032RelacionamentoId, T00335_A1033RelacionamentoTipo, T00335_n1033RelacionamentoTipo, T00335_A168ClienteId, T00335_n168ClienteId
               }
               , new Object[] {
               T00336_A168ClienteId
               }
               , new Object[] {
               T00337_A1032RelacionamentoId
               }
               , new Object[] {
               T00338_A1032RelacionamentoId
               }
               , new Object[] {
               T00339_A1032RelacionamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               T003311_A1032RelacionamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003314_A1032RelacionamentoId
               }
               , new Object[] {
               T003315_A168ClienteId
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
      private short RcdFound107 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z1032RelacionamentoId ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A1032RelacionamentoId ;
      private int edtRelacionamentoId_Enabled ;
      private int edtClienteId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ1032RelacionamentoId ;
      private int ZZ168ClienteId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtRelacionamentoId_Internalname ;
      private string cmbRelacionamentoTipo_Internalname ;
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
      private string edtRelacionamentoId_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string cmbRelacionamentoTipo_Jsonclick ;
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
      private string sMode107 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n168ClienteId ;
      private bool wbErr ;
      private bool n1033RelacionamentoTipo ;
      private string Z1033RelacionamentoTipo ;
      private string A1033RelacionamentoTipo ;
      private string ZZ1033RelacionamentoTipo ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbRelacionamentoTipo ;
      private IDataStoreProvider pr_default ;
      private int[] T00335_A1032RelacionamentoId ;
      private string[] T00335_A1033RelacionamentoTipo ;
      private bool[] T00335_n1033RelacionamentoTipo ;
      private int[] T00335_A168ClienteId ;
      private bool[] T00335_n168ClienteId ;
      private int[] T00334_A168ClienteId ;
      private bool[] T00334_n168ClienteId ;
      private int[] T00336_A168ClienteId ;
      private bool[] T00336_n168ClienteId ;
      private int[] T00337_A1032RelacionamentoId ;
      private int[] T00333_A1032RelacionamentoId ;
      private string[] T00333_A1033RelacionamentoTipo ;
      private bool[] T00333_n1033RelacionamentoTipo ;
      private int[] T00333_A168ClienteId ;
      private bool[] T00333_n168ClienteId ;
      private int[] T00338_A1032RelacionamentoId ;
      private int[] T00339_A1032RelacionamentoId ;
      private int[] T00332_A1032RelacionamentoId ;
      private string[] T00332_A1033RelacionamentoTipo ;
      private bool[] T00332_n1033RelacionamentoTipo ;
      private int[] T00332_A168ClienteId ;
      private bool[] T00332_n168ClienteId ;
      private int[] T003311_A1032RelacionamentoId ;
      private int[] T003314_A1032RelacionamentoId ;
      private int[] T003315_A168ClienteId ;
      private bool[] T003315_n168ClienteId ;
   }

   public class relacionamento__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00332;
          prmT00332 = new Object[] {
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmT00333;
          prmT00333 = new Object[] {
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmT00334;
          prmT00334 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00335;
          prmT00335 = new Object[] {
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmT00336;
          prmT00336 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00337;
          prmT00337 = new Object[] {
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmT00338;
          prmT00338 = new Object[] {
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmT00339;
          prmT00339 = new Object[] {
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmT003310;
          prmT003310 = new Object[] {
          new ParDef("RelacionamentoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003311;
          prmT003311 = new Object[] {
          };
          Object[] prmT003312;
          prmT003312 = new Object[] {
          new ParDef("RelacionamentoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmT003313;
          prmT003313 = new Object[] {
          new ParDef("RelacionamentoId",GXType.Int32,9,0)
          };
          Object[] prmT003314;
          prmT003314 = new Object[] {
          };
          Object[] prmT003315;
          prmT003315 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00332", "SELECT RelacionamentoId, RelacionamentoTipo, ClienteId FROM Relacionamento WHERE RelacionamentoId = :RelacionamentoId  FOR UPDATE OF Relacionamento NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00332,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00333", "SELECT RelacionamentoId, RelacionamentoTipo, ClienteId FROM Relacionamento WHERE RelacionamentoId = :RelacionamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00333,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00334", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00334,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00335", "SELECT TM1.RelacionamentoId, TM1.RelacionamentoTipo, TM1.ClienteId FROM Relacionamento TM1 WHERE TM1.RelacionamentoId = :RelacionamentoId ORDER BY TM1.RelacionamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00335,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00336", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00336,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00337", "SELECT RelacionamentoId FROM Relacionamento WHERE RelacionamentoId = :RelacionamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00337,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00338", "SELECT RelacionamentoId FROM Relacionamento WHERE ( RelacionamentoId > :RelacionamentoId) ORDER BY RelacionamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00338,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00339", "SELECT RelacionamentoId FROM Relacionamento WHERE ( RelacionamentoId < :RelacionamentoId) ORDER BY RelacionamentoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00339,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003310", "SAVEPOINT gxupdate;INSERT INTO Relacionamento(RelacionamentoTipo, ClienteId) VALUES(:RelacionamentoTipo, :ClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003310)
             ,new CursorDef("T003311", "SELECT currval('RelacionamentoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT003311,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003312", "SAVEPOINT gxupdate;UPDATE Relacionamento SET RelacionamentoTipo=:RelacionamentoTipo, ClienteId=:ClienteId  WHERE RelacionamentoId = :RelacionamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003312)
             ,new CursorDef("T003313", "SAVEPOINT gxupdate;DELETE FROM Relacionamento  WHERE RelacionamentoId = :RelacionamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003313)
             ,new CursorDef("T003314", "SELECT RelacionamentoId FROM Relacionamento ORDER BY RelacionamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003314,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003315", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003315,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
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
