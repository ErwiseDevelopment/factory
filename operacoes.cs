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
   public class operacoes : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A227ContratoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContratoId"), "."), 18, MidpointRounding.ToEven));
            n227ContratoId = false;
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A227ContratoId) ;
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
         Form.Meta.addItem("description", "Operacoes", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtOperacoesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public operacoes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacoes( IGxContext context )
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
         cmbOperacoesStatus = new GXCombobox();
         cmbOperacoesTipoTarifa = new GXCombobox();
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
         if ( cmbOperacoesStatus.ItemCount > 0 )
         {
            A1012OperacoesStatus = cmbOperacoesStatus.getValidValue(A1012OperacoesStatus);
            n1012OperacoesStatus = false;
            AssignAttri("", false, "A1012OperacoesStatus", A1012OperacoesStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbOperacoesStatus.CurrentValue = StringUtil.RTrim( A1012OperacoesStatus);
            AssignProp("", false, cmbOperacoesStatus_Internalname, "Values", cmbOperacoesStatus.ToJavascriptSource(), true);
         }
         if ( cmbOperacoesTipoTarifa.ItemCount > 0 )
         {
            A1048OperacoesTipoTarifa = cmbOperacoesTipoTarifa.getValidValue(A1048OperacoesTipoTarifa);
            n1048OperacoesTipoTarifa = false;
            AssignAttri("", false, "A1048OperacoesTipoTarifa", A1048OperacoesTipoTarifa);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbOperacoesTipoTarifa.CurrentValue = StringUtil.RTrim( A1048OperacoesTipoTarifa);
            AssignProp("", false, cmbOperacoesTipoTarifa_Internalname, "Values", cmbOperacoesTipoTarifa.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Operacoes", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Operacoes.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Operacoes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacoesId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacoesId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacoesId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1010OperacoesId), 9, 0, ",", "")), StringUtil.LTrim( ((edtOperacoesId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1010OperacoesId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1010OperacoesId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOperacoesId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Operacoes.htm");
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
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", ""))), ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( ((edtClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteRazaoSocial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteRazaoSocial_Internalname, "Prestador", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteRazaoSocial_Internalname, A170ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteRazaoSocial_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteRazaoSocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacoesData_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacoesData_Internalname, "Data", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOperacoesData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOperacoesData_Internalname, context.localUtil.Format(A1011OperacoesData, "99/99/99"), context.localUtil.Format( A1011OperacoesData, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesData_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOperacoesData_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operacoes.htm");
         GxWebStd.gx_bitmap( context, edtOperacoesData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOperacoesData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Operacoes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbOperacoesStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbOperacoesStatus_Internalname, "Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbOperacoesStatus, cmbOperacoesStatus_Internalname, StringUtil.RTrim( A1012OperacoesStatus), 1, cmbOperacoesStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbOperacoesStatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_Operacoes.htm");
         cmbOperacoesStatus.CurrentValue = StringUtil.RTrim( A1012OperacoesStatus);
         AssignProp("", false, cmbOperacoesStatus_Internalname, "Values", (string)(cmbOperacoesStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacoesTaxaEfetiva_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacoesTaxaEfetiva_Internalname, "Efetiva", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacoesTaxaEfetiva_Internalname, ((Convert.ToDecimal(0)==A1015OperacoesTaxaEfetiva)&&IsIns( )||n1015OperacoesTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1015OperacoesTaxaEfetiva, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A1015OperacoesTaxaEfetiva)&&IsIns( )||n1015OperacoesTaxaEfetiva ? "" : StringUtil.LTrim( ((edtOperacoesTaxaEfetiva_Enabled!=0) ? context.localUtil.Format( A1015OperacoesTaxaEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A1015OperacoesTaxaEfetiva, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesTaxaEfetiva_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOperacoesTaxaEfetiva_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContratoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContratoId_Internalname, "Contrato Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContratoId_Internalname, ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ",", ""))), ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( ((edtContratoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9") : context.localUtil.Format( (decimal)(A227ContratoId), "ZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContratoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtContratoId_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacoesTaxaMora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacoesTaxaMora_Internalname, "Mora", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacoesTaxaMora_Internalname, ((Convert.ToDecimal(0)==A1016OperacoesTaxaMora)&&IsIns( )||n1016OperacoesTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1016OperacoesTaxaMora, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A1016OperacoesTaxaMora)&&IsIns( )||n1016OperacoesTaxaMora ? "" : StringUtil.LTrim( ((edtOperacoesTaxaMora_Enabled!=0) ? context.localUtil.Format( A1016OperacoesTaxaMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A1016OperacoesTaxaMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesTaxaMora_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOperacoesTaxaMora_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacoesFator_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacoesFator_Internalname, "Fator", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacoesFator_Internalname, ((Convert.ToDecimal(0)==A1047OperacoesFator)&&IsIns( )||n1047OperacoesFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1047OperacoesFator, 21, 4, ",", ""))), ((Convert.ToDecimal(0)==A1047OperacoesFator)&&IsIns( )||n1047OperacoesFator ? "" : StringUtil.LTrim( ((edtOperacoesFator_Enabled!=0) ? context.localUtil.Format( A1047OperacoesFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%") : context.localUtil.Format( A1047OperacoesFator, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','4');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesFator_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOperacoesFator_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 0, -1, 0, true, "Percentual", "end", false, "", "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbOperacoesTipoTarifa_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbOperacoesTipoTarifa_Internalname, "Tipo Tarifa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbOperacoesTipoTarifa, cmbOperacoesTipoTarifa_Internalname, StringUtil.RTrim( A1048OperacoesTipoTarifa), 1, cmbOperacoesTipoTarifa_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbOperacoesTipoTarifa.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_Operacoes.htm");
         cmbOperacoesTipoTarifa.CurrentValue = StringUtil.RTrim( A1048OperacoesTipoTarifa);
         AssignProp("", false, cmbOperacoesTipoTarifa_Internalname, "Values", (string)(cmbOperacoesTipoTarifa.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacoesTarifa_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacoesTarifa_Internalname, "Tarifa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOperacoesTarifa_Internalname, ((Convert.ToDecimal(0)==A1049OperacoesTarifa)&&IsIns( )||n1049OperacoesTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1049OperacoesTarifa, 15, 2, ",", ""))), ((Convert.ToDecimal(0)==A1049OperacoesTarifa)&&IsIns( )||n1049OperacoesTarifa ? "" : StringUtil.LTrim( ((edtOperacoesTarifa_Enabled!=0) ? context.localUtil.Format( A1049OperacoesTarifa, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A1049OperacoesTarifa, "ZZZZZZZZZZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesTarifa_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOperacoesTarifa_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContratoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContratoNome_Internalname, "Contrato", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContratoNome_Internalname, A228ContratoNome, StringUtil.RTrim( context.localUtil.Format( A228ContratoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContratoNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtContratoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 125, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacoesCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacoesCreatedAt_Internalname, "em", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOperacoesCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOperacoesCreatedAt_Internalname, context.localUtil.TToC( A1017OperacoesCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1017OperacoesCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOperacoesCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operacoes.htm");
         GxWebStd.gx_bitmap( context, edtOperacoesCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOperacoesCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Operacoes.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtOperacoesUpdateAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOperacoesUpdateAt_Internalname, "em", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOperacoesUpdateAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOperacoesUpdateAt_Internalname, context.localUtil.TToC( A1018OperacoesUpdateAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1018OperacoesUpdateAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOperacoesUpdateAt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOperacoesUpdateAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Operacoes.htm");
         GxWebStd.gx_bitmap( context, edtOperacoesUpdateAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOperacoesUpdateAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Operacoes.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Operacoes.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Operacoes.htm");
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
            Z1010OperacoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z1010OperacoesId"), ",", "."), 18, MidpointRounding.ToEven));
            Z1011OperacoesData = context.localUtil.CToD( cgiGet( "Z1011OperacoesData"), 0);
            n1011OperacoesData = ((DateTime.MinValue==A1011OperacoesData) ? true : false);
            Z1012OperacoesStatus = cgiGet( "Z1012OperacoesStatus");
            n1012OperacoesStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A1012OperacoesStatus)) ? true : false);
            Z1015OperacoesTaxaEfetiva = context.localUtil.CToN( cgiGet( "Z1015OperacoesTaxaEfetiva"), ",", ".");
            n1015OperacoesTaxaEfetiva = ((Convert.ToDecimal(0)==A1015OperacoesTaxaEfetiva) ? true : false);
            Z1016OperacoesTaxaMora = context.localUtil.CToN( cgiGet( "Z1016OperacoesTaxaMora"), ",", ".");
            n1016OperacoesTaxaMora = ((Convert.ToDecimal(0)==A1016OperacoesTaxaMora) ? true : false);
            Z1047OperacoesFator = context.localUtil.CToN( cgiGet( "Z1047OperacoesFator"), ",", ".");
            n1047OperacoesFator = ((Convert.ToDecimal(0)==A1047OperacoesFator) ? true : false);
            Z1048OperacoesTipoTarifa = cgiGet( "Z1048OperacoesTipoTarifa");
            n1048OperacoesTipoTarifa = (String.IsNullOrEmpty(StringUtil.RTrim( A1048OperacoesTipoTarifa)) ? true : false);
            Z1049OperacoesTarifa = context.localUtil.CToN( cgiGet( "Z1049OperacoesTarifa"), ",", ".");
            n1049OperacoesTarifa = ((Convert.ToDecimal(0)==A1049OperacoesTarifa) ? true : false);
            Z1017OperacoesCreatedAt = context.localUtil.CToT( cgiGet( "Z1017OperacoesCreatedAt"), 0);
            n1017OperacoesCreatedAt = ((DateTime.MinValue==A1017OperacoesCreatedAt) ? true : false);
            Z1018OperacoesUpdateAt = context.localUtil.CToT( cgiGet( "Z1018OperacoesUpdateAt"), 0);
            n1018OperacoesUpdateAt = ((DateTime.MinValue==A1018OperacoesUpdateAt) ? true : false);
            Z168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
            n168ClienteId = ((0==A168ClienteId) ? true : false);
            Z227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z227ContratoId"), ",", "."), 18, MidpointRounding.ToEven));
            n227ContratoId = ((0==A227ContratoId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtOperacoesId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacoesId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACOESID");
               AnyError = 1;
               GX_FocusControl = edtOperacoesId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1010OperacoesId = 0;
               n1010OperacoesId = false;
               AssignAttri("", false, "A1010OperacoesId", StringUtil.LTrimStr( (decimal)(A1010OperacoesId), 9, 0));
            }
            else
            {
               A1010OperacoesId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtOperacoesId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n1010OperacoesId = false;
               AssignAttri("", false, "A1010OperacoesId", StringUtil.LTrimStr( (decimal)(A1010OperacoesId), 9, 0));
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
            A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
            n170ClienteRazaoSocial = false;
            AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
            if ( context.localUtil.VCDate( cgiGet( edtOperacoesData_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data"}), 1, "OPERACOESDATA");
               AnyError = 1;
               GX_FocusControl = edtOperacoesData_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1011OperacoesData = DateTime.MinValue;
               n1011OperacoesData = false;
               AssignAttri("", false, "A1011OperacoesData", context.localUtil.Format(A1011OperacoesData, "99/99/99"));
            }
            else
            {
               A1011OperacoesData = context.localUtil.CToD( cgiGet( edtOperacoesData_Internalname), 2);
               n1011OperacoesData = false;
               AssignAttri("", false, "A1011OperacoesData", context.localUtil.Format(A1011OperacoesData, "99/99/99"));
            }
            n1011OperacoesData = ((DateTime.MinValue==A1011OperacoesData) ? true : false);
            cmbOperacoesStatus.CurrentValue = cgiGet( cmbOperacoesStatus_Internalname);
            A1012OperacoesStatus = cgiGet( cmbOperacoesStatus_Internalname);
            n1012OperacoesStatus = false;
            AssignAttri("", false, "A1012OperacoesStatus", A1012OperacoesStatus);
            n1012OperacoesStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A1012OperacoesStatus)) ? true : false);
            n1015OperacoesTaxaEfetiva = ((StringUtil.StrCmp(cgiGet( edtOperacoesTaxaEfetiva_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOperacoesTaxaEfetiva_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacoesTaxaEfetiva_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACOESTAXAEFETIVA");
               AnyError = 1;
               GX_FocusControl = edtOperacoesTaxaEfetiva_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1015OperacoesTaxaEfetiva = 0;
               n1015OperacoesTaxaEfetiva = false;
               AssignAttri("", false, "A1015OperacoesTaxaEfetiva", (n1015OperacoesTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1015OperacoesTaxaEfetiva, 16, 4, ".", ""))));
            }
            else
            {
               A1015OperacoesTaxaEfetiva = context.localUtil.CToN( cgiGet( edtOperacoesTaxaEfetiva_Internalname), ",", ".");
               AssignAttri("", false, "A1015OperacoesTaxaEfetiva", (n1015OperacoesTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1015OperacoesTaxaEfetiva, 16, 4, ".", ""))));
            }
            n227ContratoId = ((StringUtil.StrCmp(cgiGet( edtContratoId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A227ContratoId = 0;
               n227ContratoId = false;
               AssignAttri("", false, "A227ContratoId", (n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            }
            else
            {
               A227ContratoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtContratoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A227ContratoId", (n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            }
            n1016OperacoesTaxaMora = ((StringUtil.StrCmp(cgiGet( edtOperacoesTaxaMora_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOperacoesTaxaMora_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacoesTaxaMora_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACOESTAXAMORA");
               AnyError = 1;
               GX_FocusControl = edtOperacoesTaxaMora_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1016OperacoesTaxaMora = 0;
               n1016OperacoesTaxaMora = false;
               AssignAttri("", false, "A1016OperacoesTaxaMora", (n1016OperacoesTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1016OperacoesTaxaMora, 16, 4, ".", ""))));
            }
            else
            {
               A1016OperacoesTaxaMora = context.localUtil.CToN( cgiGet( edtOperacoesTaxaMora_Internalname), ",", ".");
               AssignAttri("", false, "A1016OperacoesTaxaMora", (n1016OperacoesTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1016OperacoesTaxaMora, 16, 4, ".", ""))));
            }
            n1047OperacoesFator = ((StringUtil.StrCmp(cgiGet( edtOperacoesFator_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOperacoesFator_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacoesFator_Internalname), ",", ".") > 99999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACOESFATOR");
               AnyError = 1;
               GX_FocusControl = edtOperacoesFator_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1047OperacoesFator = 0;
               n1047OperacoesFator = false;
               AssignAttri("", false, "A1047OperacoesFator", (n1047OperacoesFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1047OperacoesFator, 16, 4, ".", ""))));
            }
            else
            {
               A1047OperacoesFator = context.localUtil.CToN( cgiGet( edtOperacoesFator_Internalname), ",", ".");
               AssignAttri("", false, "A1047OperacoesFator", (n1047OperacoesFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1047OperacoesFator, 16, 4, ".", ""))));
            }
            cmbOperacoesTipoTarifa.CurrentValue = cgiGet( cmbOperacoesTipoTarifa_Internalname);
            A1048OperacoesTipoTarifa = cgiGet( cmbOperacoesTipoTarifa_Internalname);
            n1048OperacoesTipoTarifa = false;
            AssignAttri("", false, "A1048OperacoesTipoTarifa", A1048OperacoesTipoTarifa);
            n1048OperacoesTipoTarifa = (String.IsNullOrEmpty(StringUtil.RTrim( A1048OperacoesTipoTarifa)) ? true : false);
            n1049OperacoesTarifa = ((StringUtil.StrCmp(cgiGet( edtOperacoesTarifa_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOperacoesTarifa_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOperacoesTarifa_Internalname), ",", ".") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OPERACOESTARIFA");
               AnyError = 1;
               GX_FocusControl = edtOperacoesTarifa_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1049OperacoesTarifa = 0;
               n1049OperacoesTarifa = false;
               AssignAttri("", false, "A1049OperacoesTarifa", (n1049OperacoesTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1049OperacoesTarifa, 15, 2, ".", ""))));
            }
            else
            {
               A1049OperacoesTarifa = context.localUtil.CToN( cgiGet( edtOperacoesTarifa_Internalname), ",", ".");
               AssignAttri("", false, "A1049OperacoesTarifa", (n1049OperacoesTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1049OperacoesTarifa, 15, 2, ".", ""))));
            }
            A228ContratoNome = cgiGet( edtContratoNome_Internalname);
            n228ContratoNome = false;
            AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
            if ( context.localUtil.VCDateTime( cgiGet( edtOperacoesCreatedAt_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Criado em"}), 1, "OPERACOESCREATEDAT");
               AnyError = 1;
               GX_FocusControl = edtOperacoesCreatedAt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1017OperacoesCreatedAt = (DateTime)(DateTime.MinValue);
               n1017OperacoesCreatedAt = false;
               AssignAttri("", false, "A1017OperacoesCreatedAt", context.localUtil.TToC( A1017OperacoesCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1017OperacoesCreatedAt = context.localUtil.CToT( cgiGet( edtOperacoesCreatedAt_Internalname));
               n1017OperacoesCreatedAt = false;
               AssignAttri("", false, "A1017OperacoesCreatedAt", context.localUtil.TToC( A1017OperacoesCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            n1017OperacoesCreatedAt = ((DateTime.MinValue==A1017OperacoesCreatedAt) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtOperacoesUpdateAt_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Atualizado em"}), 1, "OPERACOESUPDATEAT");
               AnyError = 1;
               GX_FocusControl = edtOperacoesUpdateAt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1018OperacoesUpdateAt = (DateTime)(DateTime.MinValue);
               n1018OperacoesUpdateAt = false;
               AssignAttri("", false, "A1018OperacoesUpdateAt", context.localUtil.TToC( A1018OperacoesUpdateAt, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1018OperacoesUpdateAt = context.localUtil.CToT( cgiGet( edtOperacoesUpdateAt_Internalname));
               n1018OperacoesUpdateAt = false;
               AssignAttri("", false, "A1018OperacoesUpdateAt", context.localUtil.TToC( A1018OperacoesUpdateAt, 8, 5, 0, 3, "/", ":", " "));
            }
            n1018OperacoesUpdateAt = ((DateTime.MinValue==A1018OperacoesUpdateAt) ? true : false);
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
               A1010OperacoesId = (int)(Math.Round(NumberUtil.Val( GetPar( "OperacoesId"), "."), 18, MidpointRounding.ToEven));
               n1010OperacoesId = false;
               AssignAttri("", false, "A1010OperacoesId", StringUtil.LTrimStr( (decimal)(A1010OperacoesId), 9, 0));
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
               InitAll31105( ) ;
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
         DisableAttributes31105( ) ;
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

      protected void ResetCaption310( )
      {
      }

      protected void ZM31105( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1011OperacoesData = T00313_A1011OperacoesData[0];
               Z1012OperacoesStatus = T00313_A1012OperacoesStatus[0];
               Z1015OperacoesTaxaEfetiva = T00313_A1015OperacoesTaxaEfetiva[0];
               Z1016OperacoesTaxaMora = T00313_A1016OperacoesTaxaMora[0];
               Z1047OperacoesFator = T00313_A1047OperacoesFator[0];
               Z1048OperacoesTipoTarifa = T00313_A1048OperacoesTipoTarifa[0];
               Z1049OperacoesTarifa = T00313_A1049OperacoesTarifa[0];
               Z1017OperacoesCreatedAt = T00313_A1017OperacoesCreatedAt[0];
               Z1018OperacoesUpdateAt = T00313_A1018OperacoesUpdateAt[0];
               Z168ClienteId = T00313_A168ClienteId[0];
               Z227ContratoId = T00313_A227ContratoId[0];
            }
            else
            {
               Z1011OperacoesData = A1011OperacoesData;
               Z1012OperacoesStatus = A1012OperacoesStatus;
               Z1015OperacoesTaxaEfetiva = A1015OperacoesTaxaEfetiva;
               Z1016OperacoesTaxaMora = A1016OperacoesTaxaMora;
               Z1047OperacoesFator = A1047OperacoesFator;
               Z1048OperacoesTipoTarifa = A1048OperacoesTipoTarifa;
               Z1049OperacoesTarifa = A1049OperacoesTarifa;
               Z1017OperacoesCreatedAt = A1017OperacoesCreatedAt;
               Z1018OperacoesUpdateAt = A1018OperacoesUpdateAt;
               Z168ClienteId = A168ClienteId;
               Z227ContratoId = A227ContratoId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z1010OperacoesId = A1010OperacoesId;
            Z1011OperacoesData = A1011OperacoesData;
            Z1012OperacoesStatus = A1012OperacoesStatus;
            Z1015OperacoesTaxaEfetiva = A1015OperacoesTaxaEfetiva;
            Z1016OperacoesTaxaMora = A1016OperacoesTaxaMora;
            Z1047OperacoesFator = A1047OperacoesFator;
            Z1048OperacoesTipoTarifa = A1048OperacoesTipoTarifa;
            Z1049OperacoesTarifa = A1049OperacoesTarifa;
            Z1017OperacoesCreatedAt = A1017OperacoesCreatedAt;
            Z1018OperacoesUpdateAt = A1018OperacoesUpdateAt;
            Z168ClienteId = A168ClienteId;
            Z227ContratoId = A227ContratoId;
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
            Z228ContratoNome = A228ContratoNome;
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

      protected void Load31105( )
      {
         /* Using cursor T00316 */
         pr_default.execute(4, new Object[] {n1010OperacoesId, A1010OperacoesId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound105 = 1;
            A170ClienteRazaoSocial = T00316_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = T00316_n170ClienteRazaoSocial[0];
            AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
            A1011OperacoesData = T00316_A1011OperacoesData[0];
            n1011OperacoesData = T00316_n1011OperacoesData[0];
            AssignAttri("", false, "A1011OperacoesData", context.localUtil.Format(A1011OperacoesData, "99/99/99"));
            A1012OperacoesStatus = T00316_A1012OperacoesStatus[0];
            n1012OperacoesStatus = T00316_n1012OperacoesStatus[0];
            AssignAttri("", false, "A1012OperacoesStatus", A1012OperacoesStatus);
            A1015OperacoesTaxaEfetiva = T00316_A1015OperacoesTaxaEfetiva[0];
            n1015OperacoesTaxaEfetiva = T00316_n1015OperacoesTaxaEfetiva[0];
            AssignAttri("", false, "A1015OperacoesTaxaEfetiva", ((Convert.ToDecimal(0)==A1015OperacoesTaxaEfetiva)&&IsIns( )||n1015OperacoesTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1015OperacoesTaxaEfetiva, 16, 4, ".", ""))));
            A1016OperacoesTaxaMora = T00316_A1016OperacoesTaxaMora[0];
            n1016OperacoesTaxaMora = T00316_n1016OperacoesTaxaMora[0];
            AssignAttri("", false, "A1016OperacoesTaxaMora", ((Convert.ToDecimal(0)==A1016OperacoesTaxaMora)&&IsIns( )||n1016OperacoesTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1016OperacoesTaxaMora, 16, 4, ".", ""))));
            A1047OperacoesFator = T00316_A1047OperacoesFator[0];
            n1047OperacoesFator = T00316_n1047OperacoesFator[0];
            AssignAttri("", false, "A1047OperacoesFator", ((Convert.ToDecimal(0)==A1047OperacoesFator)&&IsIns( )||n1047OperacoesFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1047OperacoesFator, 16, 4, ".", ""))));
            A1048OperacoesTipoTarifa = T00316_A1048OperacoesTipoTarifa[0];
            n1048OperacoesTipoTarifa = T00316_n1048OperacoesTipoTarifa[0];
            AssignAttri("", false, "A1048OperacoesTipoTarifa", A1048OperacoesTipoTarifa);
            A1049OperacoesTarifa = T00316_A1049OperacoesTarifa[0];
            n1049OperacoesTarifa = T00316_n1049OperacoesTarifa[0];
            AssignAttri("", false, "A1049OperacoesTarifa", ((Convert.ToDecimal(0)==A1049OperacoesTarifa)&&IsIns( )||n1049OperacoesTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1049OperacoesTarifa, 15, 2, ".", ""))));
            A228ContratoNome = T00316_A228ContratoNome[0];
            n228ContratoNome = T00316_n228ContratoNome[0];
            AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
            A1017OperacoesCreatedAt = T00316_A1017OperacoesCreatedAt[0];
            n1017OperacoesCreatedAt = T00316_n1017OperacoesCreatedAt[0];
            AssignAttri("", false, "A1017OperacoesCreatedAt", context.localUtil.TToC( A1017OperacoesCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A1018OperacoesUpdateAt = T00316_A1018OperacoesUpdateAt[0];
            n1018OperacoesUpdateAt = T00316_n1018OperacoesUpdateAt[0];
            AssignAttri("", false, "A1018OperacoesUpdateAt", context.localUtil.TToC( A1018OperacoesUpdateAt, 8, 5, 0, 3, "/", ":", " "));
            A168ClienteId = T00316_A168ClienteId[0];
            n168ClienteId = T00316_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A227ContratoId = T00316_A227ContratoId[0];
            n227ContratoId = T00316_n227ContratoId[0];
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            ZM31105( -2) ;
         }
         pr_default.close(4);
         OnLoadActions31105( ) ;
      }

      protected void OnLoadActions31105( )
      {
      }

      protected void CheckExtendedTable31105( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00314 */
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
         A170ClienteRazaoSocial = T00314_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = T00314_n170ClienteRazaoSocial[0];
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A1012OperacoesStatus, "PENDENTE") == 0 ) || ( StringUtil.StrCmp(A1012OperacoesStatus, "APROVADA") == 0 ) || ( StringUtil.StrCmp(A1012OperacoesStatus, "RECUSADA") == 0 ) || ( StringUtil.StrCmp(A1012OperacoesStatus, "LIQUIDADA") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1012OperacoesStatus)) ) )
         {
            GX_msglist.addItem("Campo Status fora do intervalo", "OutOfRange", 1, "OPERACOESSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbOperacoesStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00315 */
         pr_default.execute(3, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A228ContratoNome = T00315_A228ContratoNome[0];
         n228ContratoNome = T00315_n228ContratoNome[0];
         AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors31105( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A168ClienteId )
      {
         /* Using cursor T00317 */
         pr_default.execute(5, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A170ClienteRazaoSocial = T00317_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = T00317_n170ClienteRazaoSocial[0];
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A170ClienteRazaoSocial)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_4( int A227ContratoId )
      {
         /* Using cursor T00318 */
         pr_default.execute(6, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A228ContratoNome = T00318_A228ContratoNome[0];
         n228ContratoNome = T00318_n228ContratoNome[0];
         AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A228ContratoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey31105( )
      {
         /* Using cursor T00319 */
         pr_default.execute(7, new Object[] {n1010OperacoesId, A1010OperacoesId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound105 = 1;
         }
         else
         {
            RcdFound105 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00313 */
         pr_default.execute(1, new Object[] {n1010OperacoesId, A1010OperacoesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM31105( 2) ;
            RcdFound105 = 1;
            A1010OperacoesId = T00313_A1010OperacoesId[0];
            n1010OperacoesId = T00313_n1010OperacoesId[0];
            AssignAttri("", false, "A1010OperacoesId", StringUtil.LTrimStr( (decimal)(A1010OperacoesId), 9, 0));
            A1011OperacoesData = T00313_A1011OperacoesData[0];
            n1011OperacoesData = T00313_n1011OperacoesData[0];
            AssignAttri("", false, "A1011OperacoesData", context.localUtil.Format(A1011OperacoesData, "99/99/99"));
            A1012OperacoesStatus = T00313_A1012OperacoesStatus[0];
            n1012OperacoesStatus = T00313_n1012OperacoesStatus[0];
            AssignAttri("", false, "A1012OperacoesStatus", A1012OperacoesStatus);
            A1015OperacoesTaxaEfetiva = T00313_A1015OperacoesTaxaEfetiva[0];
            n1015OperacoesTaxaEfetiva = T00313_n1015OperacoesTaxaEfetiva[0];
            AssignAttri("", false, "A1015OperacoesTaxaEfetiva", ((Convert.ToDecimal(0)==A1015OperacoesTaxaEfetiva)&&IsIns( )||n1015OperacoesTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1015OperacoesTaxaEfetiva, 16, 4, ".", ""))));
            A1016OperacoesTaxaMora = T00313_A1016OperacoesTaxaMora[0];
            n1016OperacoesTaxaMora = T00313_n1016OperacoesTaxaMora[0];
            AssignAttri("", false, "A1016OperacoesTaxaMora", ((Convert.ToDecimal(0)==A1016OperacoesTaxaMora)&&IsIns( )||n1016OperacoesTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1016OperacoesTaxaMora, 16, 4, ".", ""))));
            A1047OperacoesFator = T00313_A1047OperacoesFator[0];
            n1047OperacoesFator = T00313_n1047OperacoesFator[0];
            AssignAttri("", false, "A1047OperacoesFator", ((Convert.ToDecimal(0)==A1047OperacoesFator)&&IsIns( )||n1047OperacoesFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1047OperacoesFator, 16, 4, ".", ""))));
            A1048OperacoesTipoTarifa = T00313_A1048OperacoesTipoTarifa[0];
            n1048OperacoesTipoTarifa = T00313_n1048OperacoesTipoTarifa[0];
            AssignAttri("", false, "A1048OperacoesTipoTarifa", A1048OperacoesTipoTarifa);
            A1049OperacoesTarifa = T00313_A1049OperacoesTarifa[0];
            n1049OperacoesTarifa = T00313_n1049OperacoesTarifa[0];
            AssignAttri("", false, "A1049OperacoesTarifa", ((Convert.ToDecimal(0)==A1049OperacoesTarifa)&&IsIns( )||n1049OperacoesTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1049OperacoesTarifa, 15, 2, ".", ""))));
            A1017OperacoesCreatedAt = T00313_A1017OperacoesCreatedAt[0];
            n1017OperacoesCreatedAt = T00313_n1017OperacoesCreatedAt[0];
            AssignAttri("", false, "A1017OperacoesCreatedAt", context.localUtil.TToC( A1017OperacoesCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A1018OperacoesUpdateAt = T00313_A1018OperacoesUpdateAt[0];
            n1018OperacoesUpdateAt = T00313_n1018OperacoesUpdateAt[0];
            AssignAttri("", false, "A1018OperacoesUpdateAt", context.localUtil.TToC( A1018OperacoesUpdateAt, 8, 5, 0, 3, "/", ":", " "));
            A168ClienteId = T00313_A168ClienteId[0];
            n168ClienteId = T00313_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A227ContratoId = T00313_A227ContratoId[0];
            n227ContratoId = T00313_n227ContratoId[0];
            AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
            Z1010OperacoesId = A1010OperacoesId;
            sMode105 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load31105( ) ;
            if ( AnyError == 1 )
            {
               RcdFound105 = 0;
               InitializeNonKey31105( ) ;
            }
            Gx_mode = sMode105;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound105 = 0;
            InitializeNonKey31105( ) ;
            sMode105 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode105;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey31105( ) ;
         if ( RcdFound105 == 0 )
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
         RcdFound105 = 0;
         /* Using cursor T003110 */
         pr_default.execute(8, new Object[] {n1010OperacoesId, A1010OperacoesId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T003110_A1010OperacoesId[0] < A1010OperacoesId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T003110_A1010OperacoesId[0] > A1010OperacoesId ) ) )
            {
               A1010OperacoesId = T003110_A1010OperacoesId[0];
               n1010OperacoesId = T003110_n1010OperacoesId[0];
               AssignAttri("", false, "A1010OperacoesId", StringUtil.LTrimStr( (decimal)(A1010OperacoesId), 9, 0));
               RcdFound105 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound105 = 0;
         /* Using cursor T003111 */
         pr_default.execute(9, new Object[] {n1010OperacoesId, A1010OperacoesId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T003111_A1010OperacoesId[0] > A1010OperacoesId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T003111_A1010OperacoesId[0] < A1010OperacoesId ) ) )
            {
               A1010OperacoesId = T003111_A1010OperacoesId[0];
               n1010OperacoesId = T003111_n1010OperacoesId[0];
               AssignAttri("", false, "A1010OperacoesId", StringUtil.LTrimStr( (decimal)(A1010OperacoesId), 9, 0));
               RcdFound105 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey31105( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtOperacoesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert31105( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound105 == 1 )
            {
               if ( A1010OperacoesId != Z1010OperacoesId )
               {
                  A1010OperacoesId = Z1010OperacoesId;
                  n1010OperacoesId = false;
                  AssignAttri("", false, "A1010OperacoesId", StringUtil.LTrimStr( (decimal)(A1010OperacoesId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "OPERACOESID");
                  AnyError = 1;
                  GX_FocusControl = edtOperacoesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtOperacoesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update31105( ) ;
                  GX_FocusControl = edtOperacoesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1010OperacoesId != Z1010OperacoesId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtOperacoesId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert31105( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "OPERACOESID");
                     AnyError = 1;
                     GX_FocusControl = edtOperacoesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtOperacoesId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert31105( ) ;
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
         if ( A1010OperacoesId != Z1010OperacoesId )
         {
            A1010OperacoesId = Z1010OperacoesId;
            n1010OperacoesId = false;
            AssignAttri("", false, "A1010OperacoesId", StringUtil.LTrimStr( (decimal)(A1010OperacoesId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "OPERACOESID");
            AnyError = 1;
            GX_FocusControl = edtOperacoesId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtOperacoesId_Internalname;
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
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "OPERACOESID");
            AnyError = 1;
            GX_FocusControl = edtOperacoesId_Internalname;
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
         ScanStart31105( ) ;
         if ( RcdFound105 == 0 )
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
         ScanEnd31105( ) ;
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
         if ( RcdFound105 == 0 )
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
         if ( RcdFound105 == 0 )
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
         ScanStart31105( ) ;
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound105 != 0 )
            {
               ScanNext31105( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtClienteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd31105( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency31105( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00312 */
            pr_default.execute(0, new Object[] {n1010OperacoesId, A1010OperacoesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Operacoes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1011OperacoesData ) != DateTimeUtil.ResetTime ( T00312_A1011OperacoesData[0] ) ) || ( StringUtil.StrCmp(Z1012OperacoesStatus, T00312_A1012OperacoesStatus[0]) != 0 ) || ( Z1015OperacoesTaxaEfetiva != T00312_A1015OperacoesTaxaEfetiva[0] ) || ( Z1016OperacoesTaxaMora != T00312_A1016OperacoesTaxaMora[0] ) || ( Z1047OperacoesFator != T00312_A1047OperacoesFator[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1048OperacoesTipoTarifa, T00312_A1048OperacoesTipoTarifa[0]) != 0 ) || ( Z1049OperacoesTarifa != T00312_A1049OperacoesTarifa[0] ) || ( Z1017OperacoesCreatedAt != T00312_A1017OperacoesCreatedAt[0] ) || ( Z1018OperacoesUpdateAt != T00312_A1018OperacoesUpdateAt[0] ) || ( Z168ClienteId != T00312_A168ClienteId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z227ContratoId != T00312_A227ContratoId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1011OperacoesData ) != DateTimeUtil.ResetTime ( T00312_A1011OperacoesData[0] ) )
               {
                  GXUtil.WriteLog("operacoes:[seudo value changed for attri]"+"OperacoesData");
                  GXUtil.WriteLogRaw("Old: ",Z1011OperacoesData);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1011OperacoesData[0]);
               }
               if ( StringUtil.StrCmp(Z1012OperacoesStatus, T00312_A1012OperacoesStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("operacoes:[seudo value changed for attri]"+"OperacoesStatus");
                  GXUtil.WriteLogRaw("Old: ",Z1012OperacoesStatus);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1012OperacoesStatus[0]);
               }
               if ( Z1015OperacoesTaxaEfetiva != T00312_A1015OperacoesTaxaEfetiva[0] )
               {
                  GXUtil.WriteLog("operacoes:[seudo value changed for attri]"+"OperacoesTaxaEfetiva");
                  GXUtil.WriteLogRaw("Old: ",Z1015OperacoesTaxaEfetiva);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1015OperacoesTaxaEfetiva[0]);
               }
               if ( Z1016OperacoesTaxaMora != T00312_A1016OperacoesTaxaMora[0] )
               {
                  GXUtil.WriteLog("operacoes:[seudo value changed for attri]"+"OperacoesTaxaMora");
                  GXUtil.WriteLogRaw("Old: ",Z1016OperacoesTaxaMora);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1016OperacoesTaxaMora[0]);
               }
               if ( Z1047OperacoesFator != T00312_A1047OperacoesFator[0] )
               {
                  GXUtil.WriteLog("operacoes:[seudo value changed for attri]"+"OperacoesFator");
                  GXUtil.WriteLogRaw("Old: ",Z1047OperacoesFator);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1047OperacoesFator[0]);
               }
               if ( StringUtil.StrCmp(Z1048OperacoesTipoTarifa, T00312_A1048OperacoesTipoTarifa[0]) != 0 )
               {
                  GXUtil.WriteLog("operacoes:[seudo value changed for attri]"+"OperacoesTipoTarifa");
                  GXUtil.WriteLogRaw("Old: ",Z1048OperacoesTipoTarifa);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1048OperacoesTipoTarifa[0]);
               }
               if ( Z1049OperacoesTarifa != T00312_A1049OperacoesTarifa[0] )
               {
                  GXUtil.WriteLog("operacoes:[seudo value changed for attri]"+"OperacoesTarifa");
                  GXUtil.WriteLogRaw("Old: ",Z1049OperacoesTarifa);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1049OperacoesTarifa[0]);
               }
               if ( Z1017OperacoesCreatedAt != T00312_A1017OperacoesCreatedAt[0] )
               {
                  GXUtil.WriteLog("operacoes:[seudo value changed for attri]"+"OperacoesCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z1017OperacoesCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1017OperacoesCreatedAt[0]);
               }
               if ( Z1018OperacoesUpdateAt != T00312_A1018OperacoesUpdateAt[0] )
               {
                  GXUtil.WriteLog("operacoes:[seudo value changed for attri]"+"OperacoesUpdateAt");
                  GXUtil.WriteLogRaw("Old: ",Z1018OperacoesUpdateAt);
                  GXUtil.WriteLogRaw("Current: ",T00312_A1018OperacoesUpdateAt[0]);
               }
               if ( Z168ClienteId != T00312_A168ClienteId[0] )
               {
                  GXUtil.WriteLog("operacoes:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z168ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T00312_A168ClienteId[0]);
               }
               if ( Z227ContratoId != T00312_A227ContratoId[0] )
               {
                  GXUtil.WriteLog("operacoes:[seudo value changed for attri]"+"ContratoId");
                  GXUtil.WriteLogRaw("Old: ",Z227ContratoId);
                  GXUtil.WriteLogRaw("Current: ",T00312_A227ContratoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Operacoes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert31105( )
      {
         BeforeValidate31105( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable31105( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM31105( 0) ;
            CheckOptimisticConcurrency31105( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm31105( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert31105( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003112 */
                     pr_default.execute(10, new Object[] {n1011OperacoesData, A1011OperacoesData, n1012OperacoesStatus, A1012OperacoesStatus, n1015OperacoesTaxaEfetiva, A1015OperacoesTaxaEfetiva, n1016OperacoesTaxaMora, A1016OperacoesTaxaMora, n1047OperacoesFator, A1047OperacoesFator, n1048OperacoesTipoTarifa, A1048OperacoesTipoTarifa, n1049OperacoesTarifa, A1049OperacoesTarifa, n1017OperacoesCreatedAt, A1017OperacoesCreatedAt, n1018OperacoesUpdateAt, A1018OperacoesUpdateAt, n168ClienteId, A168ClienteId, n227ContratoId, A227ContratoId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T003113 */
                     pr_default.execute(11);
                     A1010OperacoesId = T003113_A1010OperacoesId[0];
                     n1010OperacoesId = T003113_n1010OperacoesId[0];
                     AssignAttri("", false, "A1010OperacoesId", StringUtil.LTrimStr( (decimal)(A1010OperacoesId), 9, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Operacoes");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption310( ) ;
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
               Load31105( ) ;
            }
            EndLevel31105( ) ;
         }
         CloseExtendedTableCursors31105( ) ;
      }

      protected void Update31105( )
      {
         BeforeValidate31105( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable31105( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency31105( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm31105( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate31105( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003114 */
                     pr_default.execute(12, new Object[] {n1011OperacoesData, A1011OperacoesData, n1012OperacoesStatus, A1012OperacoesStatus, n1015OperacoesTaxaEfetiva, A1015OperacoesTaxaEfetiva, n1016OperacoesTaxaMora, A1016OperacoesTaxaMora, n1047OperacoesFator, A1047OperacoesFator, n1048OperacoesTipoTarifa, A1048OperacoesTipoTarifa, n1049OperacoesTarifa, A1049OperacoesTarifa, n1017OperacoesCreatedAt, A1017OperacoesCreatedAt, n1018OperacoesUpdateAt, A1018OperacoesUpdateAt, n168ClienteId, A168ClienteId, n227ContratoId, A227ContratoId, n1010OperacoesId, A1010OperacoesId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Operacoes");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Operacoes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate31105( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption310( ) ;
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
            EndLevel31105( ) ;
         }
         CloseExtendedTableCursors31105( ) ;
      }

      protected void DeferredUpdate31105( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate31105( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency31105( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls31105( ) ;
            AfterConfirm31105( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete31105( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003115 */
                  pr_default.execute(13, new Object[] {n1010OperacoesId, A1010OperacoesId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("Operacoes");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound105 == 0 )
                        {
                           InitAll31105( ) ;
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
                        ResetCaption310( ) ;
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
         sMode105 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel31105( ) ;
         Gx_mode = sMode105;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls31105( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003116 */
            pr_default.execute(14, new Object[] {n168ClienteId, A168ClienteId});
            A170ClienteRazaoSocial = T003116_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = T003116_n170ClienteRazaoSocial[0];
            AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
            pr_default.close(14);
            /* Using cursor T003117 */
            pr_default.execute(15, new Object[] {n227ContratoId, A227ContratoId});
            A228ContratoNome = T003117_A228ContratoNome[0];
            n228ContratoNome = T003117_n228ContratoNome[0];
            AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T003118 */
            pr_default.execute(16, new Object[] {n1010OperacoesId, A1010OperacoesId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"OperacoesTitulos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel31105( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete31105( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues310( ) ;
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

      public void ScanStart31105( )
      {
         /* Using cursor T003119 */
         pr_default.execute(17);
         RcdFound105 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound105 = 1;
            A1010OperacoesId = T003119_A1010OperacoesId[0];
            n1010OperacoesId = T003119_n1010OperacoesId[0];
            AssignAttri("", false, "A1010OperacoesId", StringUtil.LTrimStr( (decimal)(A1010OperacoesId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext31105( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound105 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound105 = 1;
            A1010OperacoesId = T003119_A1010OperacoesId[0];
            n1010OperacoesId = T003119_n1010OperacoesId[0];
            AssignAttri("", false, "A1010OperacoesId", StringUtil.LTrimStr( (decimal)(A1010OperacoesId), 9, 0));
         }
      }

      protected void ScanEnd31105( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm31105( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert31105( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate31105( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete31105( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete31105( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate31105( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes31105( )
      {
         edtOperacoesId_Enabled = 0;
         AssignProp("", false, edtOperacoesId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesId_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtClienteRazaoSocial_Enabled = 0;
         AssignProp("", false, edtClienteRazaoSocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteRazaoSocial_Enabled), 5, 0), true);
         edtOperacoesData_Enabled = 0;
         AssignProp("", false, edtOperacoesData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesData_Enabled), 5, 0), true);
         cmbOperacoesStatus.Enabled = 0;
         AssignProp("", false, cmbOperacoesStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacoesStatus.Enabled), 5, 0), true);
         edtOperacoesTaxaEfetiva_Enabled = 0;
         AssignProp("", false, edtOperacoesTaxaEfetiva_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesTaxaEfetiva_Enabled), 5, 0), true);
         edtContratoId_Enabled = 0;
         AssignProp("", false, edtContratoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoId_Enabled), 5, 0), true);
         edtOperacoesTaxaMora_Enabled = 0;
         AssignProp("", false, edtOperacoesTaxaMora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesTaxaMora_Enabled), 5, 0), true);
         edtOperacoesFator_Enabled = 0;
         AssignProp("", false, edtOperacoesFator_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesFator_Enabled), 5, 0), true);
         cmbOperacoesTipoTarifa.Enabled = 0;
         AssignProp("", false, cmbOperacoesTipoTarifa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbOperacoesTipoTarifa.Enabled), 5, 0), true);
         edtOperacoesTarifa_Enabled = 0;
         AssignProp("", false, edtOperacoesTarifa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesTarifa_Enabled), 5, 0), true);
         edtContratoNome_Enabled = 0;
         AssignProp("", false, edtContratoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContratoNome_Enabled), 5, 0), true);
         edtOperacoesCreatedAt_Enabled = 0;
         AssignProp("", false, edtOperacoesCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesCreatedAt_Enabled), 5, 0), true);
         edtOperacoesUpdateAt_Enabled = 0;
         AssignProp("", false, edtOperacoesUpdateAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOperacoesUpdateAt_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes31105( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues310( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("operacoes") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1010OperacoesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1010OperacoesId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1011OperacoesData", context.localUtil.DToC( Z1011OperacoesData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1012OperacoesStatus", Z1012OperacoesStatus);
         GxWebStd.gx_hidden_field( context, "Z1015OperacoesTaxaEfetiva", StringUtil.LTrim( StringUtil.NToC( Z1015OperacoesTaxaEfetiva, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1016OperacoesTaxaMora", StringUtil.LTrim( StringUtil.NToC( Z1016OperacoesTaxaMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1047OperacoesFator", StringUtil.LTrim( StringUtil.NToC( Z1047OperacoesFator, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1048OperacoesTipoTarifa", Z1048OperacoesTipoTarifa);
         GxWebStd.gx_hidden_field( context, "Z1049OperacoesTarifa", StringUtil.LTrim( StringUtil.NToC( Z1049OperacoesTarifa, 15, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1017OperacoesCreatedAt", context.localUtil.TToC( Z1017OperacoesCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1018OperacoesUpdateAt", context.localUtil.TToC( Z1018OperacoesUpdateAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z227ContratoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z227ContratoId), 6, 0, ",", "")));
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
         return formatLink("operacoes")  ;
      }

      public override string GetPgmname( )
      {
         return "Operacoes" ;
      }

      public override string GetPgmdesc( )
      {
         return "Operacoes" ;
      }

      protected void InitializeNonKey31105( )
      {
         A168ClienteId = 0;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         n168ClienteId = ((0==A168ClienteId) ? true : false);
         A170ClienteRazaoSocial = "";
         n170ClienteRazaoSocial = false;
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
         A1011OperacoesData = DateTime.MinValue;
         n1011OperacoesData = false;
         AssignAttri("", false, "A1011OperacoesData", context.localUtil.Format(A1011OperacoesData, "99/99/99"));
         n1011OperacoesData = ((DateTime.MinValue==A1011OperacoesData) ? true : false);
         A1012OperacoesStatus = "";
         n1012OperacoesStatus = false;
         AssignAttri("", false, "A1012OperacoesStatus", A1012OperacoesStatus);
         n1012OperacoesStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A1012OperacoesStatus)) ? true : false);
         A1015OperacoesTaxaEfetiva = 0;
         n1015OperacoesTaxaEfetiva = false;
         AssignAttri("", false, "A1015OperacoesTaxaEfetiva", ((Convert.ToDecimal(0)==A1015OperacoesTaxaEfetiva)&&IsIns( )||n1015OperacoesTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1015OperacoesTaxaEfetiva, 16, 4, ".", ""))));
         n1015OperacoesTaxaEfetiva = ((Convert.ToDecimal(0)==A1015OperacoesTaxaEfetiva) ? true : false);
         A227ContratoId = 0;
         n227ContratoId = false;
         AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
         n227ContratoId = ((0==A227ContratoId) ? true : false);
         A1016OperacoesTaxaMora = 0;
         n1016OperacoesTaxaMora = false;
         AssignAttri("", false, "A1016OperacoesTaxaMora", ((Convert.ToDecimal(0)==A1016OperacoesTaxaMora)&&IsIns( )||n1016OperacoesTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1016OperacoesTaxaMora, 16, 4, ".", ""))));
         n1016OperacoesTaxaMora = ((Convert.ToDecimal(0)==A1016OperacoesTaxaMora) ? true : false);
         A1047OperacoesFator = 0;
         n1047OperacoesFator = false;
         AssignAttri("", false, "A1047OperacoesFator", ((Convert.ToDecimal(0)==A1047OperacoesFator)&&IsIns( )||n1047OperacoesFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1047OperacoesFator, 16, 4, ".", ""))));
         n1047OperacoesFator = ((Convert.ToDecimal(0)==A1047OperacoesFator) ? true : false);
         A1048OperacoesTipoTarifa = "";
         n1048OperacoesTipoTarifa = false;
         AssignAttri("", false, "A1048OperacoesTipoTarifa", A1048OperacoesTipoTarifa);
         n1048OperacoesTipoTarifa = (String.IsNullOrEmpty(StringUtil.RTrim( A1048OperacoesTipoTarifa)) ? true : false);
         A1049OperacoesTarifa = 0;
         n1049OperacoesTarifa = false;
         AssignAttri("", false, "A1049OperacoesTarifa", ((Convert.ToDecimal(0)==A1049OperacoesTarifa)&&IsIns( )||n1049OperacoesTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1049OperacoesTarifa, 15, 2, ".", ""))));
         n1049OperacoesTarifa = ((Convert.ToDecimal(0)==A1049OperacoesTarifa) ? true : false);
         A228ContratoNome = "";
         n228ContratoNome = false;
         AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
         A1017OperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         n1017OperacoesCreatedAt = false;
         AssignAttri("", false, "A1017OperacoesCreatedAt", context.localUtil.TToC( A1017OperacoesCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         n1017OperacoesCreatedAt = ((DateTime.MinValue==A1017OperacoesCreatedAt) ? true : false);
         A1018OperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         n1018OperacoesUpdateAt = false;
         AssignAttri("", false, "A1018OperacoesUpdateAt", context.localUtil.TToC( A1018OperacoesUpdateAt, 8, 5, 0, 3, "/", ":", " "));
         n1018OperacoesUpdateAt = ((DateTime.MinValue==A1018OperacoesUpdateAt) ? true : false);
         Z1011OperacoesData = DateTime.MinValue;
         Z1012OperacoesStatus = "";
         Z1015OperacoesTaxaEfetiva = 0;
         Z1016OperacoesTaxaMora = 0;
         Z1047OperacoesFator = 0;
         Z1048OperacoesTipoTarifa = "";
         Z1049OperacoesTarifa = 0;
         Z1017OperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         Z1018OperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         Z168ClienteId = 0;
         Z227ContratoId = 0;
      }

      protected void InitAll31105( )
      {
         A1010OperacoesId = 0;
         n1010OperacoesId = false;
         AssignAttri("", false, "A1010OperacoesId", StringUtil.LTrimStr( (decimal)(A1010OperacoesId), 9, 0));
         InitializeNonKey31105( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101922297", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 133260), false, true);
         context.AddJavascriptSource("operacoes.js", "?20256101922298", false, true);
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
         edtOperacoesId_Internalname = "OPERACOESID";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL";
         edtOperacoesData_Internalname = "OPERACOESDATA";
         cmbOperacoesStatus_Internalname = "OPERACOESSTATUS";
         edtOperacoesTaxaEfetiva_Internalname = "OPERACOESTAXAEFETIVA";
         edtContratoId_Internalname = "CONTRATOID";
         edtOperacoesTaxaMora_Internalname = "OPERACOESTAXAMORA";
         edtOperacoesFator_Internalname = "OPERACOESFATOR";
         cmbOperacoesTipoTarifa_Internalname = "OPERACOESTIPOTARIFA";
         edtOperacoesTarifa_Internalname = "OPERACOESTARIFA";
         edtContratoNome_Internalname = "CONTRATONOME";
         edtOperacoesCreatedAt_Internalname = "OPERACOESCREATEDAT";
         edtOperacoesUpdateAt_Internalname = "OPERACOESUPDATEAT";
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
         Form.Caption = "Operacoes";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtOperacoesUpdateAt_Jsonclick = "";
         edtOperacoesUpdateAt_Enabled = 1;
         edtOperacoesCreatedAt_Jsonclick = "";
         edtOperacoesCreatedAt_Enabled = 1;
         edtContratoNome_Jsonclick = "";
         edtContratoNome_Enabled = 0;
         edtOperacoesTarifa_Jsonclick = "";
         edtOperacoesTarifa_Enabled = 1;
         cmbOperacoesTipoTarifa_Jsonclick = "";
         cmbOperacoesTipoTarifa.Enabled = 1;
         edtOperacoesFator_Jsonclick = "";
         edtOperacoesFator_Enabled = 1;
         edtOperacoesTaxaMora_Jsonclick = "";
         edtOperacoesTaxaMora_Enabled = 1;
         edtContratoId_Jsonclick = "";
         edtContratoId_Enabled = 1;
         edtOperacoesTaxaEfetiva_Jsonclick = "";
         edtOperacoesTaxaEfetiva_Enabled = 1;
         cmbOperacoesStatus_Jsonclick = "";
         cmbOperacoesStatus.Enabled = 1;
         edtOperacoesData_Jsonclick = "";
         edtOperacoesData_Enabled = 1;
         edtClienteRazaoSocial_Jsonclick = "";
         edtClienteRazaoSocial_Enabled = 0;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtOperacoesId_Jsonclick = "";
         edtOperacoesId_Enabled = 1;
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
         cmbOperacoesStatus.Name = "OPERACOESSTATUS";
         cmbOperacoesStatus.WebTags = "";
         cmbOperacoesStatus.addItem("PENDENTE", "Pendente", 0);
         cmbOperacoesStatus.addItem("APROVADA", "Aprovada", 0);
         cmbOperacoesStatus.addItem("RECUSADA", "Recusada", 0);
         cmbOperacoesStatus.addItem("LIQUIDADA", "Liquidada", 0);
         if ( cmbOperacoesStatus.ItemCount > 0 )
         {
            A1012OperacoesStatus = cmbOperacoesStatus.getValidValue(A1012OperacoesStatus);
            n1012OperacoesStatus = false;
            AssignAttri("", false, "A1012OperacoesStatus", A1012OperacoesStatus);
         }
         cmbOperacoesTipoTarifa.Name = "OPERACOESTIPOTARIFA";
         cmbOperacoesTipoTarifa.WebTags = "";
         cmbOperacoesTipoTarifa.addItem("P", "Percentual", 0);
         cmbOperacoesTipoTarifa.addItem("V", "Valor", 0);
         if ( cmbOperacoesTipoTarifa.ItemCount > 0 )
         {
            A1048OperacoesTipoTarifa = cmbOperacoesTipoTarifa.getValidValue(A1048OperacoesTipoTarifa);
            n1048OperacoesTipoTarifa = false;
            AssignAttri("", false, "A1048OperacoesTipoTarifa", A1048OperacoesTipoTarifa);
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

      public void Valid_Operacoesid( )
      {
         n1048OperacoesTipoTarifa = false;
         A1048OperacoesTipoTarifa = cmbOperacoesTipoTarifa.CurrentValue;
         n1048OperacoesTipoTarifa = false;
         cmbOperacoesTipoTarifa.CurrentValue = A1048OperacoesTipoTarifa;
         n1012OperacoesStatus = false;
         A1012OperacoesStatus = cmbOperacoesStatus.CurrentValue;
         n1012OperacoesStatus = false;
         cmbOperacoesStatus.CurrentValue = A1012OperacoesStatus;
         n1010OperacoesId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbOperacoesStatus.ItemCount > 0 )
         {
            A1012OperacoesStatus = cmbOperacoesStatus.getValidValue(A1012OperacoesStatus);
            n1012OperacoesStatus = false;
            cmbOperacoesStatus.CurrentValue = A1012OperacoesStatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbOperacoesStatus.CurrentValue = StringUtil.RTrim( A1012OperacoesStatus);
         }
         if ( cmbOperacoesTipoTarifa.ItemCount > 0 )
         {
            A1048OperacoesTipoTarifa = cmbOperacoesTipoTarifa.getValidValue(A1048OperacoesTipoTarifa);
            n1048OperacoesTipoTarifa = false;
            cmbOperacoesTipoTarifa.CurrentValue = A1048OperacoesTipoTarifa;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbOperacoesTipoTarifa.CurrentValue = StringUtil.RTrim( A1048OperacoesTipoTarifa);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         AssignAttri("", false, "A1011OperacoesData", context.localUtil.Format(A1011OperacoesData, "99/99/99"));
         AssignAttri("", false, "A1012OperacoesStatus", A1012OperacoesStatus);
         cmbOperacoesStatus.CurrentValue = StringUtil.RTrim( A1012OperacoesStatus);
         AssignProp("", false, cmbOperacoesStatus_Internalname, "Values", cmbOperacoesStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A1015OperacoesTaxaEfetiva", ((Convert.ToDecimal(0)==A1015OperacoesTaxaEfetiva)&&IsIns( )||n1015OperacoesTaxaEfetiva ? "" : StringUtil.LTrim( StringUtil.NToC( A1015OperacoesTaxaEfetiva, 16, 4, ".", ""))));
         AssignAttri("", false, "A227ContratoId", ((0==A227ContratoId)&&IsIns( )||n227ContratoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A227ContratoId), 6, 0, ".", ""))));
         AssignAttri("", false, "A1016OperacoesTaxaMora", ((Convert.ToDecimal(0)==A1016OperacoesTaxaMora)&&IsIns( )||n1016OperacoesTaxaMora ? "" : StringUtil.LTrim( StringUtil.NToC( A1016OperacoesTaxaMora, 16, 4, ".", ""))));
         AssignAttri("", false, "A1047OperacoesFator", ((Convert.ToDecimal(0)==A1047OperacoesFator)&&IsIns( )||n1047OperacoesFator ? "" : StringUtil.LTrim( StringUtil.NToC( A1047OperacoesFator, 16, 4, ".", ""))));
         AssignAttri("", false, "A1048OperacoesTipoTarifa", A1048OperacoesTipoTarifa);
         cmbOperacoesTipoTarifa.CurrentValue = StringUtil.RTrim( A1048OperacoesTipoTarifa);
         AssignProp("", false, cmbOperacoesTipoTarifa_Internalname, "Values", cmbOperacoesTipoTarifa.ToJavascriptSource(), true);
         AssignAttri("", false, "A1049OperacoesTarifa", ((Convert.ToDecimal(0)==A1049OperacoesTarifa)&&IsIns( )||n1049OperacoesTarifa ? "" : StringUtil.LTrim( StringUtil.NToC( A1049OperacoesTarifa, 15, 2, ".", ""))));
         AssignAttri("", false, "A1017OperacoesCreatedAt", context.localUtil.TToC( A1017OperacoesCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1018OperacoesUpdateAt", context.localUtil.TToC( A1018OperacoesUpdateAt, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
         AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z1010OperacoesId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1010OperacoesId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1011OperacoesData", context.localUtil.Format(Z1011OperacoesData, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1012OperacoesStatus", Z1012OperacoesStatus);
         GxWebStd.gx_hidden_field( context, "Z1015OperacoesTaxaEfetiva", StringUtil.LTrim( StringUtil.NToC( Z1015OperacoesTaxaEfetiva, 16, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z227ContratoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z227ContratoId), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1016OperacoesTaxaMora", StringUtil.LTrim( StringUtil.NToC( Z1016OperacoesTaxaMora, 16, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1047OperacoesFator", StringUtil.LTrim( StringUtil.NToC( Z1047OperacoesFator, 16, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1048OperacoesTipoTarifa", Z1048OperacoesTipoTarifa);
         GxWebStd.gx_hidden_field( context, "Z1049OperacoesTarifa", StringUtil.LTrim( StringUtil.NToC( Z1049OperacoesTarifa, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1017OperacoesCreatedAt", context.localUtil.TToC( Z1017OperacoesCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1018OperacoesUpdateAt", context.localUtil.TToC( Z1018OperacoesUpdateAt, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z170ClienteRazaoSocial", Z170ClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "Z228ContratoNome", Z228ContratoNome);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Clienteid( )
      {
         n170ClienteRazaoSocial = false;
         /* Using cursor T003116 */
         pr_default.execute(14, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
            }
         }
         A170ClienteRazaoSocial = T003116_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = T003116_n170ClienteRazaoSocial[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
      }

      public void Valid_Contratoid( )
      {
         n228ContratoNome = false;
         /* Using cursor T003117 */
         pr_default.execute(15, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
               GX_FocusControl = edtContratoId_Internalname;
            }
         }
         A228ContratoNome = T003117_A228ContratoNome[0];
         n228ContratoNome = T003117_n228ContratoNome[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A228ContratoNome", A228ContratoNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_OPERACOESID","""{"handler":"Valid_Operacoesid","iparms":[{"av":"cmbOperacoesTipoTarifa"},{"av":"A1048OperacoesTipoTarifa","fld":"OPERACOESTIPOTARIFA","type":"svchar"},{"av":"cmbOperacoesStatus"},{"av":"A1012OperacoesStatus","fld":"OPERACOESSTATUS","type":"svchar"},{"av":"A1010OperacoesId","fld":"OPERACOESID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_OPERACOESID",""","oparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"},{"av":"A1011OperacoesData","fld":"OPERACOESDATA","type":"date"},{"av":"cmbOperacoesStatus"},{"av":"A1012OperacoesStatus","fld":"OPERACOESSTATUS","type":"svchar"},{"av":"A1015OperacoesTaxaEfetiva","fld":"OPERACOESTAXAEFETIVA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n1015OperacoesTaxaEfetiva","type":"decimal"},{"av":"A227ContratoId","fld":"CONTRATOID","pic":"ZZZZZ9","nullAv":"n227ContratoId","type":"int"},{"av":"A1016OperacoesTaxaMora","fld":"OPERACOESTAXAMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n1016OperacoesTaxaMora","type":"decimal"},{"av":"A1047OperacoesFator","fld":"OPERACOESFATOR","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n1047OperacoesFator","type":"decimal"},{"av":"cmbOperacoesTipoTarifa"},{"av":"A1048OperacoesTipoTarifa","fld":"OPERACOESTIPOTARIFA","type":"svchar"},{"av":"A1049OperacoesTarifa","fld":"OPERACOESTARIFA","pic":"ZZZZZZZZZZZ9.99","nullAv":"n1049OperacoesTarifa","type":"decimal"},{"av":"A1017OperacoesCreatedAt","fld":"OPERACOESCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A1018OperacoesUpdateAt","fld":"OPERACOESUPDATEAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"},{"av":"A228ContratoNome","fld":"CONTRATONOME","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z1010OperacoesId","type":"int"},{"av":"Z168ClienteId","type":"int"},{"av":"Z1011OperacoesData","type":"date"},{"av":"Z1012OperacoesStatus","type":"svchar"},{"av":"Z1015OperacoesTaxaEfetiva","type":"decimal"},{"av":"Z227ContratoId","type":"int"},{"av":"Z1016OperacoesTaxaMora","type":"decimal"},{"av":"Z1047OperacoesFator","type":"decimal"},{"av":"Z1048OperacoesTipoTarifa","type":"svchar"},{"av":"Z1049OperacoesTarifa","type":"decimal"},{"av":"Z1017OperacoesCreatedAt","type":"dtime"},{"av":"Z1018OperacoesUpdateAt","type":"dtime"},{"av":"Z170ClienteRazaoSocial","type":"svchar"},{"av":"Z228ContratoNome","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"},{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_CLIENTEID",""","oparms":[{"av":"A170ClienteRazaoSocial","fld":"CLIENTERAZAOSOCIAL","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("VALID_OPERACOESSTATUS","""{"handler":"Valid_Operacoesstatus","iparms":[]}""");
         setEventMetadata("VALID_CONTRATOID","""{"handler":"Valid_Contratoid","iparms":[{"av":"A227ContratoId","fld":"CONTRATOID","pic":"ZZZZZ9","nullAv":"n227ContratoId","type":"int"},{"av":"A228ContratoNome","fld":"CONTRATONOME","type":"svchar"}]""");
         setEventMetadata("VALID_CONTRATOID",""","oparms":[{"av":"A228ContratoNome","fld":"CONTRATONOME","type":"svchar"}]}""");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z1011OperacoesData = DateTime.MinValue;
         Z1012OperacoesStatus = "";
         Z1048OperacoesTipoTarifa = "";
         Z1017OperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         Z1018OperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1012OperacoesStatus = "";
         A1048OperacoesTipoTarifa = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A170ClienteRazaoSocial = "";
         A1011OperacoesData = DateTime.MinValue;
         A228ContratoNome = "";
         A1017OperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         A1018OperacoesUpdateAt = (DateTime)(DateTime.MinValue);
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
         Z170ClienteRazaoSocial = "";
         Z228ContratoNome = "";
         T00316_A1010OperacoesId = new int[1] ;
         T00316_n1010OperacoesId = new bool[] {false} ;
         T00316_A170ClienteRazaoSocial = new string[] {""} ;
         T00316_n170ClienteRazaoSocial = new bool[] {false} ;
         T00316_A1011OperacoesData = new DateTime[] {DateTime.MinValue} ;
         T00316_n1011OperacoesData = new bool[] {false} ;
         T00316_A1012OperacoesStatus = new string[] {""} ;
         T00316_n1012OperacoesStatus = new bool[] {false} ;
         T00316_A1015OperacoesTaxaEfetiva = new decimal[1] ;
         T00316_n1015OperacoesTaxaEfetiva = new bool[] {false} ;
         T00316_A1016OperacoesTaxaMora = new decimal[1] ;
         T00316_n1016OperacoesTaxaMora = new bool[] {false} ;
         T00316_A1047OperacoesFator = new decimal[1] ;
         T00316_n1047OperacoesFator = new bool[] {false} ;
         T00316_A1048OperacoesTipoTarifa = new string[] {""} ;
         T00316_n1048OperacoesTipoTarifa = new bool[] {false} ;
         T00316_A1049OperacoesTarifa = new decimal[1] ;
         T00316_n1049OperacoesTarifa = new bool[] {false} ;
         T00316_A228ContratoNome = new string[] {""} ;
         T00316_n228ContratoNome = new bool[] {false} ;
         T00316_A1017OperacoesCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00316_n1017OperacoesCreatedAt = new bool[] {false} ;
         T00316_A1018OperacoesUpdateAt = new DateTime[] {DateTime.MinValue} ;
         T00316_n1018OperacoesUpdateAt = new bool[] {false} ;
         T00316_A168ClienteId = new int[1] ;
         T00316_n168ClienteId = new bool[] {false} ;
         T00316_A227ContratoId = new int[1] ;
         T00316_n227ContratoId = new bool[] {false} ;
         T00314_A170ClienteRazaoSocial = new string[] {""} ;
         T00314_n170ClienteRazaoSocial = new bool[] {false} ;
         T00315_A228ContratoNome = new string[] {""} ;
         T00315_n228ContratoNome = new bool[] {false} ;
         T00317_A170ClienteRazaoSocial = new string[] {""} ;
         T00317_n170ClienteRazaoSocial = new bool[] {false} ;
         T00318_A228ContratoNome = new string[] {""} ;
         T00318_n228ContratoNome = new bool[] {false} ;
         T00319_A1010OperacoesId = new int[1] ;
         T00319_n1010OperacoesId = new bool[] {false} ;
         T00313_A1010OperacoesId = new int[1] ;
         T00313_n1010OperacoesId = new bool[] {false} ;
         T00313_A1011OperacoesData = new DateTime[] {DateTime.MinValue} ;
         T00313_n1011OperacoesData = new bool[] {false} ;
         T00313_A1012OperacoesStatus = new string[] {""} ;
         T00313_n1012OperacoesStatus = new bool[] {false} ;
         T00313_A1015OperacoesTaxaEfetiva = new decimal[1] ;
         T00313_n1015OperacoesTaxaEfetiva = new bool[] {false} ;
         T00313_A1016OperacoesTaxaMora = new decimal[1] ;
         T00313_n1016OperacoesTaxaMora = new bool[] {false} ;
         T00313_A1047OperacoesFator = new decimal[1] ;
         T00313_n1047OperacoesFator = new bool[] {false} ;
         T00313_A1048OperacoesTipoTarifa = new string[] {""} ;
         T00313_n1048OperacoesTipoTarifa = new bool[] {false} ;
         T00313_A1049OperacoesTarifa = new decimal[1] ;
         T00313_n1049OperacoesTarifa = new bool[] {false} ;
         T00313_A1017OperacoesCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00313_n1017OperacoesCreatedAt = new bool[] {false} ;
         T00313_A1018OperacoesUpdateAt = new DateTime[] {DateTime.MinValue} ;
         T00313_n1018OperacoesUpdateAt = new bool[] {false} ;
         T00313_A168ClienteId = new int[1] ;
         T00313_n168ClienteId = new bool[] {false} ;
         T00313_A227ContratoId = new int[1] ;
         T00313_n227ContratoId = new bool[] {false} ;
         sMode105 = "";
         T003110_A1010OperacoesId = new int[1] ;
         T003110_n1010OperacoesId = new bool[] {false} ;
         T003111_A1010OperacoesId = new int[1] ;
         T003111_n1010OperacoesId = new bool[] {false} ;
         T00312_A1010OperacoesId = new int[1] ;
         T00312_n1010OperacoesId = new bool[] {false} ;
         T00312_A1011OperacoesData = new DateTime[] {DateTime.MinValue} ;
         T00312_n1011OperacoesData = new bool[] {false} ;
         T00312_A1012OperacoesStatus = new string[] {""} ;
         T00312_n1012OperacoesStatus = new bool[] {false} ;
         T00312_A1015OperacoesTaxaEfetiva = new decimal[1] ;
         T00312_n1015OperacoesTaxaEfetiva = new bool[] {false} ;
         T00312_A1016OperacoesTaxaMora = new decimal[1] ;
         T00312_n1016OperacoesTaxaMora = new bool[] {false} ;
         T00312_A1047OperacoesFator = new decimal[1] ;
         T00312_n1047OperacoesFator = new bool[] {false} ;
         T00312_A1048OperacoesTipoTarifa = new string[] {""} ;
         T00312_n1048OperacoesTipoTarifa = new bool[] {false} ;
         T00312_A1049OperacoesTarifa = new decimal[1] ;
         T00312_n1049OperacoesTarifa = new bool[] {false} ;
         T00312_A1017OperacoesCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00312_n1017OperacoesCreatedAt = new bool[] {false} ;
         T00312_A1018OperacoesUpdateAt = new DateTime[] {DateTime.MinValue} ;
         T00312_n1018OperacoesUpdateAt = new bool[] {false} ;
         T00312_A168ClienteId = new int[1] ;
         T00312_n168ClienteId = new bool[] {false} ;
         T00312_A227ContratoId = new int[1] ;
         T00312_n227ContratoId = new bool[] {false} ;
         T003113_A1010OperacoesId = new int[1] ;
         T003113_n1010OperacoesId = new bool[] {false} ;
         T003116_A170ClienteRazaoSocial = new string[] {""} ;
         T003116_n170ClienteRazaoSocial = new bool[] {false} ;
         T003117_A228ContratoNome = new string[] {""} ;
         T003117_n228ContratoNome = new bool[] {false} ;
         T003118_A1019OperacoesTitulosId = new int[1] ;
         T003119_A1010OperacoesId = new int[1] ;
         T003119_n1010OperacoesId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1011OperacoesData = DateTime.MinValue;
         ZZ1012OperacoesStatus = "";
         ZZ1048OperacoesTipoTarifa = "";
         ZZ1017OperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         ZZ1018OperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         ZZ170ClienteRazaoSocial = "";
         ZZ228ContratoNome = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacoes__default(),
            new Object[][] {
                new Object[] {
               T00312_A1010OperacoesId, T00312_A1011OperacoesData, T00312_n1011OperacoesData, T00312_A1012OperacoesStatus, T00312_n1012OperacoesStatus, T00312_A1015OperacoesTaxaEfetiva, T00312_n1015OperacoesTaxaEfetiva, T00312_A1016OperacoesTaxaMora, T00312_n1016OperacoesTaxaMora, T00312_A1047OperacoesFator,
               T00312_n1047OperacoesFator, T00312_A1048OperacoesTipoTarifa, T00312_n1048OperacoesTipoTarifa, T00312_A1049OperacoesTarifa, T00312_n1049OperacoesTarifa, T00312_A1017OperacoesCreatedAt, T00312_n1017OperacoesCreatedAt, T00312_A1018OperacoesUpdateAt, T00312_n1018OperacoesUpdateAt, T00312_A168ClienteId,
               T00312_n168ClienteId, T00312_A227ContratoId, T00312_n227ContratoId
               }
               , new Object[] {
               T00313_A1010OperacoesId, T00313_A1011OperacoesData, T00313_n1011OperacoesData, T00313_A1012OperacoesStatus, T00313_n1012OperacoesStatus, T00313_A1015OperacoesTaxaEfetiva, T00313_n1015OperacoesTaxaEfetiva, T00313_A1016OperacoesTaxaMora, T00313_n1016OperacoesTaxaMora, T00313_A1047OperacoesFator,
               T00313_n1047OperacoesFator, T00313_A1048OperacoesTipoTarifa, T00313_n1048OperacoesTipoTarifa, T00313_A1049OperacoesTarifa, T00313_n1049OperacoesTarifa, T00313_A1017OperacoesCreatedAt, T00313_n1017OperacoesCreatedAt, T00313_A1018OperacoesUpdateAt, T00313_n1018OperacoesUpdateAt, T00313_A168ClienteId,
               T00313_n168ClienteId, T00313_A227ContratoId, T00313_n227ContratoId
               }
               , new Object[] {
               T00314_A170ClienteRazaoSocial, T00314_n170ClienteRazaoSocial
               }
               , new Object[] {
               T00315_A228ContratoNome, T00315_n228ContratoNome
               }
               , new Object[] {
               T00316_A1010OperacoesId, T00316_A170ClienteRazaoSocial, T00316_n170ClienteRazaoSocial, T00316_A1011OperacoesData, T00316_n1011OperacoesData, T00316_A1012OperacoesStatus, T00316_n1012OperacoesStatus, T00316_A1015OperacoesTaxaEfetiva, T00316_n1015OperacoesTaxaEfetiva, T00316_A1016OperacoesTaxaMora,
               T00316_n1016OperacoesTaxaMora, T00316_A1047OperacoesFator, T00316_n1047OperacoesFator, T00316_A1048OperacoesTipoTarifa, T00316_n1048OperacoesTipoTarifa, T00316_A1049OperacoesTarifa, T00316_n1049OperacoesTarifa, T00316_A228ContratoNome, T00316_n228ContratoNome, T00316_A1017OperacoesCreatedAt,
               T00316_n1017OperacoesCreatedAt, T00316_A1018OperacoesUpdateAt, T00316_n1018OperacoesUpdateAt, T00316_A168ClienteId, T00316_n168ClienteId, T00316_A227ContratoId, T00316_n227ContratoId
               }
               , new Object[] {
               T00317_A170ClienteRazaoSocial, T00317_n170ClienteRazaoSocial
               }
               , new Object[] {
               T00318_A228ContratoNome, T00318_n228ContratoNome
               }
               , new Object[] {
               T00319_A1010OperacoesId
               }
               , new Object[] {
               T003110_A1010OperacoesId
               }
               , new Object[] {
               T003111_A1010OperacoesId
               }
               , new Object[] {
               }
               , new Object[] {
               T003113_A1010OperacoesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003116_A170ClienteRazaoSocial, T003116_n170ClienteRazaoSocial
               }
               , new Object[] {
               T003117_A228ContratoNome, T003117_n228ContratoNome
               }
               , new Object[] {
               T003118_A1019OperacoesTitulosId
               }
               , new Object[] {
               T003119_A1010OperacoesId
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
      private short RcdFound105 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z1010OperacoesId ;
      private int Z168ClienteId ;
      private int Z227ContratoId ;
      private int A168ClienteId ;
      private int A227ContratoId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A1010OperacoesId ;
      private int edtOperacoesId_Enabled ;
      private int edtClienteId_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtOperacoesData_Enabled ;
      private int edtOperacoesTaxaEfetiva_Enabled ;
      private int edtContratoId_Enabled ;
      private int edtOperacoesTaxaMora_Enabled ;
      private int edtOperacoesFator_Enabled ;
      private int edtOperacoesTarifa_Enabled ;
      private int edtContratoNome_Enabled ;
      private int edtOperacoesCreatedAt_Enabled ;
      private int edtOperacoesUpdateAt_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ1010OperacoesId ;
      private int ZZ168ClienteId ;
      private int ZZ227ContratoId ;
      private decimal Z1015OperacoesTaxaEfetiva ;
      private decimal Z1016OperacoesTaxaMora ;
      private decimal Z1047OperacoesFator ;
      private decimal Z1049OperacoesTarifa ;
      private decimal A1015OperacoesTaxaEfetiva ;
      private decimal A1016OperacoesTaxaMora ;
      private decimal A1047OperacoesFator ;
      private decimal A1049OperacoesTarifa ;
      private decimal ZZ1015OperacoesTaxaEfetiva ;
      private decimal ZZ1016OperacoesTaxaMora ;
      private decimal ZZ1047OperacoesFator ;
      private decimal ZZ1049OperacoesTarifa ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtOperacoesId_Internalname ;
      private string cmbOperacoesStatus_Internalname ;
      private string cmbOperacoesTipoTarifa_Internalname ;
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
      private string edtOperacoesId_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteRazaoSocial_Internalname ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string edtOperacoesData_Internalname ;
      private string edtOperacoesData_Jsonclick ;
      private string cmbOperacoesStatus_Jsonclick ;
      private string edtOperacoesTaxaEfetiva_Internalname ;
      private string edtOperacoesTaxaEfetiva_Jsonclick ;
      private string edtContratoId_Internalname ;
      private string edtContratoId_Jsonclick ;
      private string edtOperacoesTaxaMora_Internalname ;
      private string edtOperacoesTaxaMora_Jsonclick ;
      private string edtOperacoesFator_Internalname ;
      private string edtOperacoesFator_Jsonclick ;
      private string cmbOperacoesTipoTarifa_Jsonclick ;
      private string edtOperacoesTarifa_Internalname ;
      private string edtOperacoesTarifa_Jsonclick ;
      private string edtContratoNome_Internalname ;
      private string edtContratoNome_Jsonclick ;
      private string edtOperacoesCreatedAt_Internalname ;
      private string edtOperacoesCreatedAt_Jsonclick ;
      private string edtOperacoesUpdateAt_Internalname ;
      private string edtOperacoesUpdateAt_Jsonclick ;
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
      private string sMode105 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z1017OperacoesCreatedAt ;
      private DateTime Z1018OperacoesUpdateAt ;
      private DateTime A1017OperacoesCreatedAt ;
      private DateTime A1018OperacoesUpdateAt ;
      private DateTime ZZ1017OperacoesCreatedAt ;
      private DateTime ZZ1018OperacoesUpdateAt ;
      private DateTime Z1011OperacoesData ;
      private DateTime A1011OperacoesData ;
      private DateTime ZZ1011OperacoesData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n168ClienteId ;
      private bool n227ContratoId ;
      private bool wbErr ;
      private bool n1012OperacoesStatus ;
      private bool n1048OperacoesTipoTarifa ;
      private bool n1015OperacoesTaxaEfetiva ;
      private bool n1016OperacoesTaxaMora ;
      private bool n1047OperacoesFator ;
      private bool n1049OperacoesTarifa ;
      private bool n1011OperacoesData ;
      private bool n1017OperacoesCreatedAt ;
      private bool n1018OperacoesUpdateAt ;
      private bool n1010OperacoesId ;
      private bool n170ClienteRazaoSocial ;
      private bool n228ContratoNome ;
      private bool Gx_longc ;
      private string Z1012OperacoesStatus ;
      private string Z1048OperacoesTipoTarifa ;
      private string A1012OperacoesStatus ;
      private string A1048OperacoesTipoTarifa ;
      private string A170ClienteRazaoSocial ;
      private string A228ContratoNome ;
      private string Z170ClienteRazaoSocial ;
      private string Z228ContratoNome ;
      private string ZZ1012OperacoesStatus ;
      private string ZZ1048OperacoesTipoTarifa ;
      private string ZZ170ClienteRazaoSocial ;
      private string ZZ228ContratoNome ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbOperacoesStatus ;
      private GXCombobox cmbOperacoesTipoTarifa ;
      private IDataStoreProvider pr_default ;
      private int[] T00316_A1010OperacoesId ;
      private bool[] T00316_n1010OperacoesId ;
      private string[] T00316_A170ClienteRazaoSocial ;
      private bool[] T00316_n170ClienteRazaoSocial ;
      private DateTime[] T00316_A1011OperacoesData ;
      private bool[] T00316_n1011OperacoesData ;
      private string[] T00316_A1012OperacoesStatus ;
      private bool[] T00316_n1012OperacoesStatus ;
      private decimal[] T00316_A1015OperacoesTaxaEfetiva ;
      private bool[] T00316_n1015OperacoesTaxaEfetiva ;
      private decimal[] T00316_A1016OperacoesTaxaMora ;
      private bool[] T00316_n1016OperacoesTaxaMora ;
      private decimal[] T00316_A1047OperacoesFator ;
      private bool[] T00316_n1047OperacoesFator ;
      private string[] T00316_A1048OperacoesTipoTarifa ;
      private bool[] T00316_n1048OperacoesTipoTarifa ;
      private decimal[] T00316_A1049OperacoesTarifa ;
      private bool[] T00316_n1049OperacoesTarifa ;
      private string[] T00316_A228ContratoNome ;
      private bool[] T00316_n228ContratoNome ;
      private DateTime[] T00316_A1017OperacoesCreatedAt ;
      private bool[] T00316_n1017OperacoesCreatedAt ;
      private DateTime[] T00316_A1018OperacoesUpdateAt ;
      private bool[] T00316_n1018OperacoesUpdateAt ;
      private int[] T00316_A168ClienteId ;
      private bool[] T00316_n168ClienteId ;
      private int[] T00316_A227ContratoId ;
      private bool[] T00316_n227ContratoId ;
      private string[] T00314_A170ClienteRazaoSocial ;
      private bool[] T00314_n170ClienteRazaoSocial ;
      private string[] T00315_A228ContratoNome ;
      private bool[] T00315_n228ContratoNome ;
      private string[] T00317_A170ClienteRazaoSocial ;
      private bool[] T00317_n170ClienteRazaoSocial ;
      private string[] T00318_A228ContratoNome ;
      private bool[] T00318_n228ContratoNome ;
      private int[] T00319_A1010OperacoesId ;
      private bool[] T00319_n1010OperacoesId ;
      private int[] T00313_A1010OperacoesId ;
      private bool[] T00313_n1010OperacoesId ;
      private DateTime[] T00313_A1011OperacoesData ;
      private bool[] T00313_n1011OperacoesData ;
      private string[] T00313_A1012OperacoesStatus ;
      private bool[] T00313_n1012OperacoesStatus ;
      private decimal[] T00313_A1015OperacoesTaxaEfetiva ;
      private bool[] T00313_n1015OperacoesTaxaEfetiva ;
      private decimal[] T00313_A1016OperacoesTaxaMora ;
      private bool[] T00313_n1016OperacoesTaxaMora ;
      private decimal[] T00313_A1047OperacoesFator ;
      private bool[] T00313_n1047OperacoesFator ;
      private string[] T00313_A1048OperacoesTipoTarifa ;
      private bool[] T00313_n1048OperacoesTipoTarifa ;
      private decimal[] T00313_A1049OperacoesTarifa ;
      private bool[] T00313_n1049OperacoesTarifa ;
      private DateTime[] T00313_A1017OperacoesCreatedAt ;
      private bool[] T00313_n1017OperacoesCreatedAt ;
      private DateTime[] T00313_A1018OperacoesUpdateAt ;
      private bool[] T00313_n1018OperacoesUpdateAt ;
      private int[] T00313_A168ClienteId ;
      private bool[] T00313_n168ClienteId ;
      private int[] T00313_A227ContratoId ;
      private bool[] T00313_n227ContratoId ;
      private int[] T003110_A1010OperacoesId ;
      private bool[] T003110_n1010OperacoesId ;
      private int[] T003111_A1010OperacoesId ;
      private bool[] T003111_n1010OperacoesId ;
      private int[] T00312_A1010OperacoesId ;
      private bool[] T00312_n1010OperacoesId ;
      private DateTime[] T00312_A1011OperacoesData ;
      private bool[] T00312_n1011OperacoesData ;
      private string[] T00312_A1012OperacoesStatus ;
      private bool[] T00312_n1012OperacoesStatus ;
      private decimal[] T00312_A1015OperacoesTaxaEfetiva ;
      private bool[] T00312_n1015OperacoesTaxaEfetiva ;
      private decimal[] T00312_A1016OperacoesTaxaMora ;
      private bool[] T00312_n1016OperacoesTaxaMora ;
      private decimal[] T00312_A1047OperacoesFator ;
      private bool[] T00312_n1047OperacoesFator ;
      private string[] T00312_A1048OperacoesTipoTarifa ;
      private bool[] T00312_n1048OperacoesTipoTarifa ;
      private decimal[] T00312_A1049OperacoesTarifa ;
      private bool[] T00312_n1049OperacoesTarifa ;
      private DateTime[] T00312_A1017OperacoesCreatedAt ;
      private bool[] T00312_n1017OperacoesCreatedAt ;
      private DateTime[] T00312_A1018OperacoesUpdateAt ;
      private bool[] T00312_n1018OperacoesUpdateAt ;
      private int[] T00312_A168ClienteId ;
      private bool[] T00312_n168ClienteId ;
      private int[] T00312_A227ContratoId ;
      private bool[] T00312_n227ContratoId ;
      private int[] T003113_A1010OperacoesId ;
      private bool[] T003113_n1010OperacoesId ;
      private string[] T003116_A170ClienteRazaoSocial ;
      private bool[] T003116_n170ClienteRazaoSocial ;
      private string[] T003117_A228ContratoNome ;
      private bool[] T003117_n228ContratoNome ;
      private int[] T003118_A1019OperacoesTitulosId ;
      private int[] T003119_A1010OperacoesId ;
      private bool[] T003119_n1010OperacoesId ;
   }

   public class operacoes__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00312;
          prmT00312 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00313;
          prmT00313 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00314;
          prmT00314 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00315;
          prmT00315 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00316;
          prmT00316 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00317;
          prmT00317 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00318;
          prmT00318 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00319;
          prmT00319 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003110;
          prmT003110 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003111;
          prmT003111 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003112;
          prmT003112 = new Object[] {
          new ParDef("OperacoesData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("OperacoesStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTaxaEfetiva",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesTaxaMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesFator",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesTipoTarifa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTarifa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("OperacoesCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("OperacoesUpdateAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT003113;
          prmT003113 = new Object[] {
          };
          Object[] prmT003114;
          prmT003114 = new Object[] {
          new ParDef("OperacoesData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("OperacoesStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTaxaEfetiva",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesTaxaMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesFator",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesTipoTarifa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTarifa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("OperacoesCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("OperacoesUpdateAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003115;
          prmT003115 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003116;
          prmT003116 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003117;
          prmT003117 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT003118;
          prmT003118 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT003119;
          prmT003119 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T00312", "SELECT OperacoesId, OperacoesData, OperacoesStatus, OperacoesTaxaEfetiva, OperacoesTaxaMora, OperacoesFator, OperacoesTipoTarifa, OperacoesTarifa, OperacoesCreatedAt, OperacoesUpdateAt, ClienteId, ContratoId FROM Operacoes WHERE OperacoesId = :OperacoesId  FOR UPDATE OF Operacoes NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00312,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00313", "SELECT OperacoesId, OperacoesData, OperacoesStatus, OperacoesTaxaEfetiva, OperacoesTaxaMora, OperacoesFator, OperacoesTipoTarifa, OperacoesTarifa, OperacoesCreatedAt, OperacoesUpdateAt, ClienteId, ContratoId FROM Operacoes WHERE OperacoesId = :OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00313,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00314", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00314,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00315", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00315,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00316", "SELECT TM1.OperacoesId, T2.ClienteRazaoSocial, TM1.OperacoesData, TM1.OperacoesStatus, TM1.OperacoesTaxaEfetiva, TM1.OperacoesTaxaMora, TM1.OperacoesFator, TM1.OperacoesTipoTarifa, TM1.OperacoesTarifa, T3.ContratoNome, TM1.OperacoesCreatedAt, TM1.OperacoesUpdateAt, TM1.ClienteId, TM1.ContratoId FROM ((Operacoes TM1 LEFT JOIN Cliente T2 ON T2.ClienteId = TM1.ClienteId) LEFT JOIN Contrato T3 ON T3.ContratoId = TM1.ContratoId) WHERE TM1.OperacoesId = :OperacoesId ORDER BY TM1.OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00316,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00317", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00317,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00318", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00318,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00319", "SELECT OperacoesId FROM Operacoes WHERE OperacoesId = :OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00319,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003110", "SELECT OperacoesId FROM Operacoes WHERE ( OperacoesId > :OperacoesId) ORDER BY OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003110,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003111", "SELECT OperacoesId FROM Operacoes WHERE ( OperacoesId < :OperacoesId) ORDER BY OperacoesId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT003111,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003112", "SAVEPOINT gxupdate;INSERT INTO Operacoes(OperacoesData, OperacoesStatus, OperacoesTaxaEfetiva, OperacoesTaxaMora, OperacoesFator, OperacoesTipoTarifa, OperacoesTarifa, OperacoesCreatedAt, OperacoesUpdateAt, ClienteId, ContratoId) VALUES(:OperacoesData, :OperacoesStatus, :OperacoesTaxaEfetiva, :OperacoesTaxaMora, :OperacoesFator, :OperacoesTipoTarifa, :OperacoesTarifa, :OperacoesCreatedAt, :OperacoesUpdateAt, :ClienteId, :ContratoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT003112)
             ,new CursorDef("T003113", "SELECT currval('OperacoesId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT003113,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003114", "SAVEPOINT gxupdate;UPDATE Operacoes SET OperacoesData=:OperacoesData, OperacoesStatus=:OperacoesStatus, OperacoesTaxaEfetiva=:OperacoesTaxaEfetiva, OperacoesTaxaMora=:OperacoesTaxaMora, OperacoesFator=:OperacoesFator, OperacoesTipoTarifa=:OperacoesTipoTarifa, OperacoesTarifa=:OperacoesTarifa, OperacoesCreatedAt=:OperacoesCreatedAt, OperacoesUpdateAt=:OperacoesUpdateAt, ClienteId=:ClienteId, ContratoId=:ContratoId  WHERE OperacoesId = :OperacoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003114)
             ,new CursorDef("T003115", "SAVEPOINT gxupdate;DELETE FROM Operacoes  WHERE OperacoesId = :OperacoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT003115)
             ,new CursorDef("T003116", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003116,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003117", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003117,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T003118", "SELECT OperacoesTitulosId FROM OperacoesTitulos WHERE OperacoesId = :OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003118,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T003119", "SELECT OperacoesId FROM Operacoes ORDER BY OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmT003119,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
