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
   public class propostacontratoassinatura : GXDataArea
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
            A323PropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaId"), "."), 18, MidpointRounding.ToEven));
            n323PropostaId = false;
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A323PropostaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A570PropostaContrato = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaContrato"), "."), 18, MidpointRounding.ToEven));
            n570PropostaContrato = false;
            AssignAttri("", false, "A570PropostaContrato", ((0==A570PropostaContrato)&&IsIns( )||n570PropostaContrato ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A570PropostaContrato), 6, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A570PropostaContrato) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A571PropostaAssinatura = (long)(Math.Round(NumberUtil.Val( GetPar( "PropostaAssinatura"), "."), 18, MidpointRounding.ToEven));
            n571PropostaAssinatura = false;
            AssignAttri("", false, "A571PropostaAssinatura", ((0==A571PropostaAssinatura)&&IsIns( )||n571PropostaAssinatura ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A571PropostaAssinatura) ;
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
         Form.Meta.addItem("description", "Proposta Contrato Assinatura", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public propostacontratoassinatura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostacontratoassinatura( IGxContext context )
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
         cmbPropostaAssinaturaStatus = new GXCombobox();
         cmbPropostaContratoAssinaturaTipo = new GXCombobox();
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
         if ( cmbPropostaAssinaturaStatus.ItemCount > 0 )
         {
            A574PropostaAssinaturaStatus = cmbPropostaAssinaturaStatus.getValidValue(A574PropostaAssinaturaStatus);
            n574PropostaAssinaturaStatus = false;
            AssignAttri("", false, "A574PropostaAssinaturaStatus", A574PropostaAssinaturaStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPropostaAssinaturaStatus.CurrentValue = StringUtil.RTrim( A574PropostaAssinaturaStatus);
            AssignProp("", false, cmbPropostaAssinaturaStatus_Internalname, "Values", cmbPropostaAssinaturaStatus.ToJavascriptSource(), true);
         }
         if ( cmbPropostaContratoAssinaturaTipo.ItemCount > 0 )
         {
            A573PropostaContratoAssinaturaTipo = cmbPropostaContratoAssinaturaTipo.getValidValue(A573PropostaContratoAssinaturaTipo);
            n573PropostaContratoAssinaturaTipo = false;
            AssignAttri("", false, "A573PropostaContratoAssinaturaTipo", A573PropostaContratoAssinaturaTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPropostaContratoAssinaturaTipo.CurrentValue = StringUtil.RTrim( A573PropostaContratoAssinaturaTipo);
            AssignProp("", false, cmbPropostaContratoAssinaturaTipo_Internalname, "Values", cmbPropostaContratoAssinaturaTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Proposta Contrato Assinatura", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_PropostaContratoAssinatura.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaContratoAssinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaContratoAssinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaContratoAssinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaContratoAssinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_PropostaContratoAssinatura.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaContratoAssinaturaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaContratoAssinaturaId_Internalname, "Assinatura Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaContratoAssinaturaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtPropostaContratoAssinaturaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A572PropostaContratoAssinaturaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A572PropostaContratoAssinaturaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaContratoAssinaturaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPropostaContratoAssinaturaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PropostaContratoAssinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaId_Internalname, "Proposta Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaId_Internalname, ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", ""))), ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( ((edtPropostaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPropostaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PropostaContratoAssinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaContrato_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaContrato_Internalname, "Contrato", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaContrato_Internalname, ((0==A570PropostaContrato)&&IsIns( )||n570PropostaContrato ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A570PropostaContrato), 6, 0, ",", ""))), ((0==A570PropostaContrato)&&IsIns( )||n570PropostaContrato ? "" : StringUtil.LTrim( ((edtPropostaContrato_Enabled!=0) ? context.localUtil.Format( (decimal)(A570PropostaContrato), "ZZZZZ9") : context.localUtil.Format( (decimal)(A570PropostaContrato), "ZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaContrato_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPropostaContrato_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaContratoAssinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaAssinatura_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaAssinatura_Internalname, "Assinatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaAssinatura_Internalname, ((0==A571PropostaAssinatura)&&IsIns( )||n571PropostaAssinatura ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ",", ""))), ((0==A571PropostaAssinatura)&&IsIns( )||n571PropostaAssinatura ? "" : StringUtil.LTrim( ((edtPropostaAssinatura_Enabled!=0) ? context.localUtil.Format( (decimal)(A571PropostaAssinatura), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A571PropostaAssinatura), "ZZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaAssinatura_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPropostaAssinatura_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_PropostaContratoAssinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbPropostaAssinaturaStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPropostaAssinaturaStatus_Internalname, "Assinatura Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPropostaAssinaturaStatus, cmbPropostaAssinaturaStatus_Internalname, StringUtil.RTrim( A574PropostaAssinaturaStatus), 1, cmbPropostaAssinaturaStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbPropostaAssinaturaStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_PropostaContratoAssinatura.htm");
         cmbPropostaAssinaturaStatus.CurrentValue = StringUtil.RTrim( A574PropostaAssinaturaStatus);
         AssignProp("", false, cmbPropostaAssinaturaStatus_Internalname, "Values", (string)(cmbPropostaAssinaturaStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbPropostaContratoAssinaturaTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPropostaContratoAssinaturaTipo_Internalname, "Assinatura Tipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPropostaContratoAssinaturaTipo, cmbPropostaContratoAssinaturaTipo_Internalname, StringUtil.RTrim( A573PropostaContratoAssinaturaTipo), 1, cmbPropostaContratoAssinaturaTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbPropostaContratoAssinaturaTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_PropostaContratoAssinatura.htm");
         cmbPropostaContratoAssinaturaTipo.CurrentValue = StringUtil.RTrim( A573PropostaContratoAssinaturaTipo);
         AssignProp("", false, cmbPropostaContratoAssinaturaTipo_Internalname, "Values", (string)(cmbPropostaContratoAssinaturaTipo.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaContratoAssinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaContratoAssinatura.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaContratoAssinatura.htm");
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
            Z572PropostaContratoAssinaturaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z572PropostaContratoAssinaturaId"), ",", "."), 18, MidpointRounding.ToEven));
            Z573PropostaContratoAssinaturaTipo = cgiGet( "Z573PropostaContratoAssinaturaTipo");
            n573PropostaContratoAssinaturaTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A573PropostaContratoAssinaturaTipo)) ? true : false);
            Z323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z323PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
            n323PropostaId = ((0==A323PropostaId) ? true : false);
            Z570PropostaContrato = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z570PropostaContrato"), ",", "."), 18, MidpointRounding.ToEven));
            n570PropostaContrato = ((0==A570PropostaContrato) ? true : false);
            Z571PropostaAssinatura = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z571PropostaAssinatura"), ",", "."), 18, MidpointRounding.ToEven));
            n571PropostaAssinatura = ((0==A571PropostaAssinatura) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtPropostaContratoAssinaturaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropostaContratoAssinaturaId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPOSTACONTRATOASSINATURAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A572PropostaContratoAssinaturaId = 0;
               n572PropostaContratoAssinaturaId = false;
               AssignAttri("", false, "A572PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(A572PropostaContratoAssinaturaId), 9, 0));
            }
            else
            {
               A572PropostaContratoAssinaturaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaContratoAssinaturaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n572PropostaContratoAssinaturaId = false;
               AssignAttri("", false, "A572PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(A572PropostaContratoAssinaturaId), 9, 0));
            }
            n323PropostaId = ((StringUtil.StrCmp(cgiGet( edtPropostaId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A323PropostaId = 0;
               n323PropostaId = false;
               AssignAttri("", false, "A323PropostaId", (n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            }
            else
            {
               A323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A323PropostaId", (n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            }
            n570PropostaContrato = ((StringUtil.StrCmp(cgiGet( edtPropostaContrato_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPropostaContrato_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropostaContrato_Internalname), ",", ".") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPOSTACONTRATO");
               AnyError = 1;
               GX_FocusControl = edtPropostaContrato_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A570PropostaContrato = 0;
               n570PropostaContrato = false;
               AssignAttri("", false, "A570PropostaContrato", (n570PropostaContrato ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A570PropostaContrato), 6, 0, ".", ""))));
            }
            else
            {
               A570PropostaContrato = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaContrato_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A570PropostaContrato", (n570PropostaContrato ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A570PropostaContrato), 6, 0, ".", ""))));
            }
            n571PropostaAssinatura = ((StringUtil.StrCmp(cgiGet( edtPropostaAssinatura_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPropostaAssinatura_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropostaAssinatura_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPOSTAASSINATURA");
               AnyError = 1;
               GX_FocusControl = edtPropostaAssinatura_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A571PropostaAssinatura = 0;
               n571PropostaAssinatura = false;
               AssignAttri("", false, "A571PropostaAssinatura", (n571PropostaAssinatura ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ".", ""))));
            }
            else
            {
               A571PropostaAssinatura = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaAssinatura_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A571PropostaAssinatura", (n571PropostaAssinatura ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ".", ""))));
            }
            cmbPropostaAssinaturaStatus.CurrentValue = cgiGet( cmbPropostaAssinaturaStatus_Internalname);
            A574PropostaAssinaturaStatus = cgiGet( cmbPropostaAssinaturaStatus_Internalname);
            n574PropostaAssinaturaStatus = false;
            AssignAttri("", false, "A574PropostaAssinaturaStatus", A574PropostaAssinaturaStatus);
            cmbPropostaContratoAssinaturaTipo.CurrentValue = cgiGet( cmbPropostaContratoAssinaturaTipo_Internalname);
            A573PropostaContratoAssinaturaTipo = cgiGet( cmbPropostaContratoAssinaturaTipo_Internalname);
            n573PropostaContratoAssinaturaTipo = false;
            AssignAttri("", false, "A573PropostaContratoAssinaturaTipo", A573PropostaContratoAssinaturaTipo);
            n573PropostaContratoAssinaturaTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A573PropostaContratoAssinaturaTipo)) ? true : false);
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
               A572PropostaContratoAssinaturaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaContratoAssinaturaId"), "."), 18, MidpointRounding.ToEven));
               n572PropostaContratoAssinaturaId = false;
               AssignAttri("", false, "A572PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(A572PropostaContratoAssinaturaId), 9, 0));
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
               InitAll2778( ) ;
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
         DisableAttributes2778( ) ;
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

      protected void ResetCaption270( )
      {
      }

      protected void ZM2778( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z573PropostaContratoAssinaturaTipo = T00273_A573PropostaContratoAssinaturaTipo[0];
               Z323PropostaId = T00273_A323PropostaId[0];
               Z570PropostaContrato = T00273_A570PropostaContrato[0];
               Z571PropostaAssinatura = T00273_A571PropostaAssinatura[0];
            }
            else
            {
               Z573PropostaContratoAssinaturaTipo = A573PropostaContratoAssinaturaTipo;
               Z323PropostaId = A323PropostaId;
               Z570PropostaContrato = A570PropostaContrato;
               Z571PropostaAssinatura = A571PropostaAssinatura;
            }
         }
         if ( GX_JID == -2 )
         {
            Z572PropostaContratoAssinaturaId = A572PropostaContratoAssinaturaId;
            Z573PropostaContratoAssinaturaTipo = A573PropostaContratoAssinaturaTipo;
            Z323PropostaId = A323PropostaId;
            Z570PropostaContrato = A570PropostaContrato;
            Z571PropostaAssinatura = A571PropostaAssinatura;
            Z574PropostaAssinaturaStatus = A574PropostaAssinaturaStatus;
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

      protected void Load2778( )
      {
         /* Using cursor T00277 */
         pr_default.execute(5, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound78 = 1;
            A574PropostaAssinaturaStatus = T00277_A574PropostaAssinaturaStatus[0];
            n574PropostaAssinaturaStatus = T00277_n574PropostaAssinaturaStatus[0];
            AssignAttri("", false, "A574PropostaAssinaturaStatus", A574PropostaAssinaturaStatus);
            A573PropostaContratoAssinaturaTipo = T00277_A573PropostaContratoAssinaturaTipo[0];
            n573PropostaContratoAssinaturaTipo = T00277_n573PropostaContratoAssinaturaTipo[0];
            AssignAttri("", false, "A573PropostaContratoAssinaturaTipo", A573PropostaContratoAssinaturaTipo);
            A323PropostaId = T00277_A323PropostaId[0];
            n323PropostaId = T00277_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            A570PropostaContrato = T00277_A570PropostaContrato[0];
            n570PropostaContrato = T00277_n570PropostaContrato[0];
            AssignAttri("", false, "A570PropostaContrato", ((0==A570PropostaContrato)&&IsIns( )||n570PropostaContrato ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A570PropostaContrato), 6, 0, ".", ""))));
            A571PropostaAssinatura = T00277_A571PropostaAssinatura[0];
            n571PropostaAssinatura = T00277_n571PropostaAssinatura[0];
            AssignAttri("", false, "A571PropostaAssinatura", ((0==A571PropostaAssinatura)&&IsIns( )||n571PropostaAssinatura ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ".", ""))));
            ZM2778( -2) ;
         }
         pr_default.close(5);
         OnLoadActions2778( ) ;
      }

      protected void OnLoadActions2778( )
      {
      }

      protected void CheckExtendedTable2778( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00274 */
         pr_default.execute(2, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A323PropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         /* Using cursor T00275 */
         pr_default.execute(3, new Object[] {n570PropostaContrato, A570PropostaContrato});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A570PropostaContrato) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Proposta Contrato'.", "ForeignKeyNotFound", 1, "PROPOSTACONTRATO");
               AnyError = 1;
               GX_FocusControl = edtPropostaContrato_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T00276 */
         pr_default.execute(4, new Object[] {n571PropostaAssinatura, A571PropostaAssinatura});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A571PropostaAssinatura) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Proposta Assinatura'.", "ForeignKeyNotFound", 1, "PROPOSTAASSINATURA");
               AnyError = 1;
               GX_FocusControl = edtPropostaAssinatura_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A574PropostaAssinaturaStatus = T00276_A574PropostaAssinaturaStatus[0];
         n574PropostaAssinaturaStatus = T00276_n574PropostaAssinaturaStatus[0];
         AssignAttri("", false, "A574PropostaAssinaturaStatus", A574PropostaAssinaturaStatus);
         pr_default.close(4);
         if ( ! ( ( StringUtil.StrCmp(A573PropostaContratoAssinaturaTipo, "Contrato") == 0 ) || ( StringUtil.StrCmp(A573PropostaContratoAssinaturaTipo, "Nota_promissoria") == 0 ) || ( StringUtil.StrCmp(A573PropostaContratoAssinaturaTipo, "Nota_promissoria_clinica") == 0 ) || ( StringUtil.StrCmp(A573PropostaContratoAssinaturaTipo, "Nota_promissoria_clinica_taxa") == 0 ) || ( StringUtil.StrCmp(A573PropostaContratoAssinaturaTipo, "Documento") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A573PropostaContratoAssinaturaTipo)) ) )
         {
            GX_msglist.addItem("Campo Proposta Contrato Assinatura Tipo fora do intervalo", "OutOfRange", 1, "PROPOSTACONTRATOASSINATURATIPO");
            AnyError = 1;
            GX_FocusControl = cmbPropostaContratoAssinaturaTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2778( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A323PropostaId )
      {
         /* Using cursor T00278 */
         pr_default.execute(6, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A323PropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void gxLoad_4( int A570PropostaContrato )
      {
         /* Using cursor T00279 */
         pr_default.execute(7, new Object[] {n570PropostaContrato, A570PropostaContrato});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A570PropostaContrato) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Proposta Contrato'.", "ForeignKeyNotFound", 1, "PROPOSTACONTRATO");
               AnyError = 1;
               GX_FocusControl = edtPropostaContrato_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_5( long A571PropostaAssinatura )
      {
         /* Using cursor T002710 */
         pr_default.execute(8, new Object[] {n571PropostaAssinatura, A571PropostaAssinatura});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A571PropostaAssinatura) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Proposta Assinatura'.", "ForeignKeyNotFound", 1, "PROPOSTAASSINATURA");
               AnyError = 1;
               GX_FocusControl = edtPropostaAssinatura_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A574PropostaAssinaturaStatus = T002710_A574PropostaAssinaturaStatus[0];
         n574PropostaAssinaturaStatus = T002710_n574PropostaAssinaturaStatus[0];
         AssignAttri("", false, "A574PropostaAssinaturaStatus", A574PropostaAssinaturaStatus);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A574PropostaAssinaturaStatus)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey2778( )
      {
         /* Using cursor T002711 */
         pr_default.execute(9, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound78 = 1;
         }
         else
         {
            RcdFound78 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00273 */
         pr_default.execute(1, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2778( 2) ;
            RcdFound78 = 1;
            A572PropostaContratoAssinaturaId = T00273_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = T00273_n572PropostaContratoAssinaturaId[0];
            AssignAttri("", false, "A572PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(A572PropostaContratoAssinaturaId), 9, 0));
            A573PropostaContratoAssinaturaTipo = T00273_A573PropostaContratoAssinaturaTipo[0];
            n573PropostaContratoAssinaturaTipo = T00273_n573PropostaContratoAssinaturaTipo[0];
            AssignAttri("", false, "A573PropostaContratoAssinaturaTipo", A573PropostaContratoAssinaturaTipo);
            A323PropostaId = T00273_A323PropostaId[0];
            n323PropostaId = T00273_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            A570PropostaContrato = T00273_A570PropostaContrato[0];
            n570PropostaContrato = T00273_n570PropostaContrato[0];
            AssignAttri("", false, "A570PropostaContrato", ((0==A570PropostaContrato)&&IsIns( )||n570PropostaContrato ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A570PropostaContrato), 6, 0, ".", ""))));
            A571PropostaAssinatura = T00273_A571PropostaAssinatura[0];
            n571PropostaAssinatura = T00273_n571PropostaAssinatura[0];
            AssignAttri("", false, "A571PropostaAssinatura", ((0==A571PropostaAssinatura)&&IsIns( )||n571PropostaAssinatura ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ".", ""))));
            Z572PropostaContratoAssinaturaId = A572PropostaContratoAssinaturaId;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2778( ) ;
            if ( AnyError == 1 )
            {
               RcdFound78 = 0;
               InitializeNonKey2778( ) ;
            }
            Gx_mode = sMode78;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound78 = 0;
            InitializeNonKey2778( ) ;
            sMode78 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode78;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2778( ) ;
         if ( RcdFound78 == 0 )
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
         RcdFound78 = 0;
         /* Using cursor T002712 */
         pr_default.execute(10, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T002712_A572PropostaContratoAssinaturaId[0] < A572PropostaContratoAssinaturaId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T002712_A572PropostaContratoAssinaturaId[0] > A572PropostaContratoAssinaturaId ) ) )
            {
               A572PropostaContratoAssinaturaId = T002712_A572PropostaContratoAssinaturaId[0];
               n572PropostaContratoAssinaturaId = T002712_n572PropostaContratoAssinaturaId[0];
               AssignAttri("", false, "A572PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(A572PropostaContratoAssinaturaId), 9, 0));
               RcdFound78 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound78 = 0;
         /* Using cursor T002713 */
         pr_default.execute(11, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T002713_A572PropostaContratoAssinaturaId[0] > A572PropostaContratoAssinaturaId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T002713_A572PropostaContratoAssinaturaId[0] < A572PropostaContratoAssinaturaId ) ) )
            {
               A572PropostaContratoAssinaturaId = T002713_A572PropostaContratoAssinaturaId[0];
               n572PropostaContratoAssinaturaId = T002713_n572PropostaContratoAssinaturaId[0];
               AssignAttri("", false, "A572PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(A572PropostaContratoAssinaturaId), 9, 0));
               RcdFound78 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2778( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2778( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound78 == 1 )
            {
               if ( A572PropostaContratoAssinaturaId != Z572PropostaContratoAssinaturaId )
               {
                  A572PropostaContratoAssinaturaId = Z572PropostaContratoAssinaturaId;
                  n572PropostaContratoAssinaturaId = false;
                  AssignAttri("", false, "A572PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(A572PropostaContratoAssinaturaId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROPOSTACONTRATOASSINATURAID");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2778( ) ;
                  GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A572PropostaContratoAssinaturaId != Z572PropostaContratoAssinaturaId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2778( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROPOSTACONTRATOASSINATURAID");
                     AnyError = 1;
                     GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2778( ) ;
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
         if ( A572PropostaContratoAssinaturaId != Z572PropostaContratoAssinaturaId )
         {
            A572PropostaContratoAssinaturaId = Z572PropostaContratoAssinaturaId;
            n572PropostaContratoAssinaturaId = false;
            AssignAttri("", false, "A572PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(A572PropostaContratoAssinaturaId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROPOSTACONTRATOASSINATURAID");
            AnyError = 1;
            GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
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
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROPOSTACONTRATOASSINATURAID");
            AnyError = 1;
            GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPropostaId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2778( ) ;
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPropostaId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2778( ) ;
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
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPropostaId_Internalname;
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
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPropostaId_Internalname;
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
         ScanStart2778( ) ;
         if ( RcdFound78 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound78 != 0 )
            {
               ScanNext2778( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPropostaId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2778( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2778( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00272 */
            pr_default.execute(0, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PropostaContratoAssinatura"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z573PropostaContratoAssinaturaTipo, T00272_A573PropostaContratoAssinaturaTipo[0]) != 0 ) || ( Z323PropostaId != T00272_A323PropostaId[0] ) || ( Z570PropostaContrato != T00272_A570PropostaContrato[0] ) || ( Z571PropostaAssinatura != T00272_A571PropostaAssinatura[0] ) )
            {
               if ( StringUtil.StrCmp(Z573PropostaContratoAssinaturaTipo, T00272_A573PropostaContratoAssinaturaTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("propostacontratoassinatura:[seudo value changed for attri]"+"PropostaContratoAssinaturaTipo");
                  GXUtil.WriteLogRaw("Old: ",Z573PropostaContratoAssinaturaTipo);
                  GXUtil.WriteLogRaw("Current: ",T00272_A573PropostaContratoAssinaturaTipo[0]);
               }
               if ( Z323PropostaId != T00272_A323PropostaId[0] )
               {
                  GXUtil.WriteLog("propostacontratoassinatura:[seudo value changed for attri]"+"PropostaId");
                  GXUtil.WriteLogRaw("Old: ",Z323PropostaId);
                  GXUtil.WriteLogRaw("Current: ",T00272_A323PropostaId[0]);
               }
               if ( Z570PropostaContrato != T00272_A570PropostaContrato[0] )
               {
                  GXUtil.WriteLog("propostacontratoassinatura:[seudo value changed for attri]"+"PropostaContrato");
                  GXUtil.WriteLogRaw("Old: ",Z570PropostaContrato);
                  GXUtil.WriteLogRaw("Current: ",T00272_A570PropostaContrato[0]);
               }
               if ( Z571PropostaAssinatura != T00272_A571PropostaAssinatura[0] )
               {
                  GXUtil.WriteLog("propostacontratoassinatura:[seudo value changed for attri]"+"PropostaAssinatura");
                  GXUtil.WriteLogRaw("Old: ",Z571PropostaAssinatura);
                  GXUtil.WriteLogRaw("Current: ",T00272_A571PropostaAssinatura[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PropostaContratoAssinatura"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2778( )
      {
         BeforeValidate2778( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2778( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2778( 0) ;
            CheckOptimisticConcurrency2778( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2778( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2778( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002714 */
                     pr_default.execute(12, new Object[] {n573PropostaContratoAssinaturaTipo, A573PropostaContratoAssinaturaTipo, n323PropostaId, A323PropostaId, n570PropostaContrato, A570PropostaContrato, n571PropostaAssinatura, A571PropostaAssinatura});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002715 */
                     pr_default.execute(13);
                     A572PropostaContratoAssinaturaId = T002715_A572PropostaContratoAssinaturaId[0];
                     n572PropostaContratoAssinaturaId = T002715_n572PropostaContratoAssinaturaId[0];
                     AssignAttri("", false, "A572PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(A572PropostaContratoAssinaturaId), 9, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("PropostaContratoAssinatura");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption270( ) ;
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
               Load2778( ) ;
            }
            EndLevel2778( ) ;
         }
         CloseExtendedTableCursors2778( ) ;
      }

      protected void Update2778( )
      {
         BeforeValidate2778( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2778( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2778( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2778( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2778( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002716 */
                     pr_default.execute(14, new Object[] {n573PropostaContratoAssinaturaTipo, A573PropostaContratoAssinaturaTipo, n323PropostaId, A323PropostaId, n570PropostaContrato, A570PropostaContrato, n571PropostaAssinatura, A571PropostaAssinatura, n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("PropostaContratoAssinatura");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PropostaContratoAssinatura"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2778( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption270( ) ;
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
            EndLevel2778( ) ;
         }
         CloseExtendedTableCursors2778( ) ;
      }

      protected void DeferredUpdate2778( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2778( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2778( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2778( ) ;
            AfterConfirm2778( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2778( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002717 */
                  pr_default.execute(15, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("PropostaContratoAssinatura");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound78 == 0 )
                        {
                           InitAll2778( ) ;
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
                        ResetCaption270( ) ;
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
         sMode78 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2778( ) ;
         Gx_mode = sMode78;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2778( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002718 */
            pr_default.execute(16, new Object[] {n571PropostaAssinatura, A571PropostaAssinatura});
            A574PropostaAssinaturaStatus = T002718_A574PropostaAssinaturaStatus[0];
            n574PropostaAssinaturaStatus = T002718_n574PropostaAssinaturaStatus[0];
            AssignAttri("", false, "A574PropostaAssinaturaStatus", A574PropostaAssinaturaStatus);
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002719 */
            pr_default.execute(17, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoAssinaturas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel2778( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2778( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues270( ) ;
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

      public void ScanStart2778( )
      {
         /* Using cursor T002720 */
         pr_default.execute(18);
         RcdFound78 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound78 = 1;
            A572PropostaContratoAssinaturaId = T002720_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = T002720_n572PropostaContratoAssinaturaId[0];
            AssignAttri("", false, "A572PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(A572PropostaContratoAssinaturaId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2778( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound78 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound78 = 1;
            A572PropostaContratoAssinaturaId = T002720_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = T002720_n572PropostaContratoAssinaturaId[0];
            AssignAttri("", false, "A572PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(A572PropostaContratoAssinaturaId), 9, 0));
         }
      }

      protected void ScanEnd2778( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm2778( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2778( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2778( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2778( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2778( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2778( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2778( )
      {
         edtPropostaContratoAssinaturaId_Enabled = 0;
         AssignProp("", false, edtPropostaContratoAssinaturaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaContratoAssinaturaId_Enabled), 5, 0), true);
         edtPropostaId_Enabled = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         edtPropostaContrato_Enabled = 0;
         AssignProp("", false, edtPropostaContrato_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaContrato_Enabled), 5, 0), true);
         edtPropostaAssinatura_Enabled = 0;
         AssignProp("", false, edtPropostaAssinatura_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaAssinatura_Enabled), 5, 0), true);
         cmbPropostaAssinaturaStatus.Enabled = 0;
         AssignProp("", false, cmbPropostaAssinaturaStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPropostaAssinaturaStatus.Enabled), 5, 0), true);
         cmbPropostaContratoAssinaturaTipo.Enabled = 0;
         AssignProp("", false, cmbPropostaContratoAssinaturaTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPropostaContratoAssinaturaTipo.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2778( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues270( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("propostacontratoassinatura") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z572PropostaContratoAssinaturaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z572PropostaContratoAssinaturaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z573PropostaContratoAssinaturaTipo", Z573PropostaContratoAssinaturaTipo);
         GxWebStd.gx_hidden_field( context, "Z323PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z570PropostaContrato", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z570PropostaContrato), 6, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z571PropostaAssinatura", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z571PropostaAssinatura), 10, 0, ",", "")));
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
         return formatLink("propostacontratoassinatura")  ;
      }

      public override string GetPgmname( )
      {
         return "PropostaContratoAssinatura" ;
      }

      public override string GetPgmdesc( )
      {
         return "Proposta Contrato Assinatura" ;
      }

      protected void InitializeNonKey2778( )
      {
         A323PropostaId = 0;
         n323PropostaId = false;
         AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
         n323PropostaId = ((0==A323PropostaId) ? true : false);
         A570PropostaContrato = 0;
         n570PropostaContrato = false;
         AssignAttri("", false, "A570PropostaContrato", ((0==A570PropostaContrato)&&IsIns( )||n570PropostaContrato ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A570PropostaContrato), 6, 0, ".", ""))));
         n570PropostaContrato = ((0==A570PropostaContrato) ? true : false);
         A571PropostaAssinatura = 0;
         n571PropostaAssinatura = false;
         AssignAttri("", false, "A571PropostaAssinatura", ((0==A571PropostaAssinatura)&&IsIns( )||n571PropostaAssinatura ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ".", ""))));
         n571PropostaAssinatura = ((0==A571PropostaAssinatura) ? true : false);
         A574PropostaAssinaturaStatus = "";
         n574PropostaAssinaturaStatus = false;
         AssignAttri("", false, "A574PropostaAssinaturaStatus", A574PropostaAssinaturaStatus);
         A573PropostaContratoAssinaturaTipo = "";
         n573PropostaContratoAssinaturaTipo = false;
         AssignAttri("", false, "A573PropostaContratoAssinaturaTipo", A573PropostaContratoAssinaturaTipo);
         n573PropostaContratoAssinaturaTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A573PropostaContratoAssinaturaTipo)) ? true : false);
         Z573PropostaContratoAssinaturaTipo = "";
         Z323PropostaId = 0;
         Z570PropostaContrato = 0;
         Z571PropostaAssinatura = 0;
      }

      protected void InitAll2778( )
      {
         A572PropostaContratoAssinaturaId = 0;
         n572PropostaContratoAssinaturaId = false;
         AssignAttri("", false, "A572PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(A572PropostaContratoAssinaturaId), 9, 0));
         InitializeNonKey2778( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101919237", true, true);
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
         context.AddJavascriptSource("propostacontratoassinatura.js", "?20256101919239", false, true);
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
         edtPropostaContratoAssinaturaId_Internalname = "PROPOSTACONTRATOASSINATURAID";
         edtPropostaId_Internalname = "PROPOSTAID";
         edtPropostaContrato_Internalname = "PROPOSTACONTRATO";
         edtPropostaAssinatura_Internalname = "PROPOSTAASSINATURA";
         cmbPropostaAssinaturaStatus_Internalname = "PROPOSTAASSINATURASTATUS";
         cmbPropostaContratoAssinaturaTipo_Internalname = "PROPOSTACONTRATOASSINATURATIPO";
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
         Form.Caption = "Proposta Contrato Assinatura";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbPropostaContratoAssinaturaTipo_Jsonclick = "";
         cmbPropostaContratoAssinaturaTipo.Enabled = 1;
         cmbPropostaAssinaturaStatus_Jsonclick = "";
         cmbPropostaAssinaturaStatus.Enabled = 0;
         edtPropostaAssinatura_Jsonclick = "";
         edtPropostaAssinatura_Enabled = 1;
         edtPropostaContrato_Jsonclick = "";
         edtPropostaContrato_Enabled = 1;
         edtPropostaId_Jsonclick = "";
         edtPropostaId_Enabled = 1;
         edtPropostaContratoAssinaturaId_Jsonclick = "";
         edtPropostaContratoAssinaturaId_Enabled = 1;
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
         cmbPropostaAssinaturaStatus.Name = "PROPOSTAASSINATURASTATUS";
         cmbPropostaAssinaturaStatus.WebTags = "";
         cmbPropostaAssinaturaStatus.addItem("ENVIADO", "Enviado", 0);
         cmbPropostaAssinaturaStatus.addItem("REJEITADO", "Rejeitado", 0);
         cmbPropostaAssinaturaStatus.addItem("CANCELADO", "Cancelado", 0);
         cmbPropostaAssinaturaStatus.addItem("ASSINADO", "Assinado", 0);
         cmbPropostaAssinaturaStatus.addItem("AGUARDANDO_ENVIO", "Aguardando envio", 0);
         if ( cmbPropostaAssinaturaStatus.ItemCount > 0 )
         {
            A574PropostaAssinaturaStatus = cmbPropostaAssinaturaStatus.getValidValue(A574PropostaAssinaturaStatus);
            n574PropostaAssinaturaStatus = false;
            AssignAttri("", false, "A574PropostaAssinaturaStatus", A574PropostaAssinaturaStatus);
         }
         cmbPropostaContratoAssinaturaTipo.Name = "PROPOSTACONTRATOASSINATURATIPO";
         cmbPropostaContratoAssinaturaTipo.WebTags = "";
         cmbPropostaContratoAssinaturaTipo.addItem("Contrato", "Contrato", 0);
         cmbPropostaContratoAssinaturaTipo.addItem("Nota_promissoria", "Nota promissória", 0);
         cmbPropostaContratoAssinaturaTipo.addItem("Nota_promissoria_clinica", "Nota promissória clinica", 0);
         cmbPropostaContratoAssinaturaTipo.addItem("Nota_promissoria_clinica_taxa", "Nota promissória clinica taxa", 0);
         cmbPropostaContratoAssinaturaTipo.addItem("Documento", "Documento", 0);
         if ( cmbPropostaContratoAssinaturaTipo.ItemCount > 0 )
         {
            A573PropostaContratoAssinaturaTipo = cmbPropostaContratoAssinaturaTipo.getValidValue(A573PropostaContratoAssinaturaTipo);
            n573PropostaContratoAssinaturaTipo = false;
            AssignAttri("", false, "A573PropostaContratoAssinaturaTipo", A573PropostaContratoAssinaturaTipo);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtPropostaId_Internalname;
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

      public void Valid_Propostacontratoassinaturaid( )
      {
         n574PropostaAssinaturaStatus = false;
         A574PropostaAssinaturaStatus = cmbPropostaAssinaturaStatus.CurrentValue;
         n574PropostaAssinaturaStatus = false;
         cmbPropostaAssinaturaStatus.CurrentValue = A574PropostaAssinaturaStatus;
         n573PropostaContratoAssinaturaTipo = false;
         A573PropostaContratoAssinaturaTipo = cmbPropostaContratoAssinaturaTipo.CurrentValue;
         n573PropostaContratoAssinaturaTipo = false;
         cmbPropostaContratoAssinaturaTipo.CurrentValue = A573PropostaContratoAssinaturaTipo;
         n572PropostaContratoAssinaturaId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbPropostaContratoAssinaturaTipo.ItemCount > 0 )
         {
            A573PropostaContratoAssinaturaTipo = cmbPropostaContratoAssinaturaTipo.getValidValue(A573PropostaContratoAssinaturaTipo);
            n573PropostaContratoAssinaturaTipo = false;
            cmbPropostaContratoAssinaturaTipo.CurrentValue = A573PropostaContratoAssinaturaTipo;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPropostaContratoAssinaturaTipo.CurrentValue = StringUtil.RTrim( A573PropostaContratoAssinaturaTipo);
         }
         if ( cmbPropostaAssinaturaStatus.ItemCount > 0 )
         {
            A574PropostaAssinaturaStatus = cmbPropostaAssinaturaStatus.getValidValue(A574PropostaAssinaturaStatus);
            n574PropostaAssinaturaStatus = false;
            cmbPropostaAssinaturaStatus.CurrentValue = A574PropostaAssinaturaStatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPropostaAssinaturaStatus.CurrentValue = StringUtil.RTrim( A574PropostaAssinaturaStatus);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
         AssignAttri("", false, "A570PropostaContrato", ((0==A570PropostaContrato)&&IsIns( )||n570PropostaContrato ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A570PropostaContrato), 6, 0, ".", ""))));
         AssignAttri("", false, "A571PropostaAssinatura", ((0==A571PropostaAssinatura)&&IsIns( )||n571PropostaAssinatura ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ".", ""))));
         AssignAttri("", false, "A573PropostaContratoAssinaturaTipo", A573PropostaContratoAssinaturaTipo);
         cmbPropostaContratoAssinaturaTipo.CurrentValue = StringUtil.RTrim( A573PropostaContratoAssinaturaTipo);
         AssignProp("", false, cmbPropostaContratoAssinaturaTipo_Internalname, "Values", cmbPropostaContratoAssinaturaTipo.ToJavascriptSource(), true);
         AssignAttri("", false, "A574PropostaAssinaturaStatus", A574PropostaAssinaturaStatus);
         cmbPropostaAssinaturaStatus.CurrentValue = StringUtil.RTrim( A574PropostaAssinaturaStatus);
         AssignProp("", false, cmbPropostaAssinaturaStatus_Internalname, "Values", cmbPropostaAssinaturaStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z572PropostaContratoAssinaturaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z572PropostaContratoAssinaturaId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z323PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z323PropostaId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z570PropostaContrato", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z570PropostaContrato), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z571PropostaAssinatura", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z571PropostaAssinatura), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z573PropostaContratoAssinaturaTipo", Z573PropostaContratoAssinaturaTipo);
         GxWebStd.gx_hidden_field( context, "Z574PropostaAssinaturaStatus", Z574PropostaAssinaturaStatus);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Propostaid( )
      {
         /* Using cursor T002721 */
         pr_default.execute(19, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A323PropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaId_Internalname;
            }
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Propostacontrato( )
      {
         /* Using cursor T002722 */
         pr_default.execute(20, new Object[] {n570PropostaContrato, A570PropostaContrato});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A570PropostaContrato) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Proposta Contrato'.", "ForeignKeyNotFound", 1, "PROPOSTACONTRATO");
               AnyError = 1;
               GX_FocusControl = edtPropostaContrato_Internalname;
            }
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Propostaassinatura( )
      {
         n574PropostaAssinaturaStatus = false;
         A574PropostaAssinaturaStatus = cmbPropostaAssinaturaStatus.CurrentValue;
         n574PropostaAssinaturaStatus = false;
         cmbPropostaAssinaturaStatus.CurrentValue = A574PropostaAssinaturaStatus;
         /* Using cursor T002718 */
         pr_default.execute(16, new Object[] {n571PropostaAssinatura, A571PropostaAssinatura});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A571PropostaAssinatura) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Proposta Assinatura'.", "ForeignKeyNotFound", 1, "PROPOSTAASSINATURA");
               AnyError = 1;
               GX_FocusControl = edtPropostaAssinatura_Internalname;
            }
         }
         A574PropostaAssinaturaStatus = T002718_A574PropostaAssinaturaStatus[0];
         n574PropostaAssinaturaStatus = T002718_n574PropostaAssinaturaStatus[0];
         cmbPropostaAssinaturaStatus.CurrentValue = A574PropostaAssinaturaStatus;
         pr_default.close(16);
         dynload_actions( ) ;
         if ( cmbPropostaAssinaturaStatus.ItemCount > 0 )
         {
            A574PropostaAssinaturaStatus = cmbPropostaAssinaturaStatus.getValidValue(A574PropostaAssinaturaStatus);
            n574PropostaAssinaturaStatus = false;
            cmbPropostaAssinaturaStatus.CurrentValue = A574PropostaAssinaturaStatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPropostaAssinaturaStatus.CurrentValue = StringUtil.RTrim( A574PropostaAssinaturaStatus);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A574PropostaAssinaturaStatus", A574PropostaAssinaturaStatus);
         cmbPropostaAssinaturaStatus.CurrentValue = StringUtil.RTrim( A574PropostaAssinaturaStatus);
         AssignProp("", false, cmbPropostaAssinaturaStatus_Internalname, "Values", cmbPropostaAssinaturaStatus.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("VALID_PROPOSTACONTRATOASSINATURAID","""{"handler":"Valid_Propostacontratoassinaturaid","iparms":[{"av":"cmbPropostaAssinaturaStatus"},{"av":"A574PropostaAssinaturaStatus","fld":"PROPOSTAASSINATURASTATUS","type":"svchar"},{"av":"cmbPropostaContratoAssinaturaTipo"},{"av":"A573PropostaContratoAssinaturaTipo","fld":"PROPOSTACONTRATOASSINATURATIPO","type":"svchar"},{"av":"A572PropostaContratoAssinaturaId","fld":"PROPOSTACONTRATOASSINATURAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_PROPOSTACONTRATOASSINATURAID",""","oparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","nullAv":"n323PropostaId","type":"int"},{"av":"A570PropostaContrato","fld":"PROPOSTACONTRATO","pic":"ZZZZZ9","nullAv":"n570PropostaContrato","type":"int"},{"av":"A571PropostaAssinatura","fld":"PROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","nullAv":"n571PropostaAssinatura","type":"int"},{"av":"cmbPropostaContratoAssinaturaTipo"},{"av":"A573PropostaContratoAssinaturaTipo","fld":"PROPOSTACONTRATOASSINATURATIPO","type":"svchar"},{"av":"cmbPropostaAssinaturaStatus"},{"av":"A574PropostaAssinaturaStatus","fld":"PROPOSTAASSINATURASTATUS","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z572PropostaContratoAssinaturaId","type":"int"},{"av":"Z323PropostaId","type":"int"},{"av":"Z570PropostaContrato","type":"int"},{"av":"Z571PropostaAssinatura","type":"int"},{"av":"Z573PropostaContratoAssinaturaTipo","type":"svchar"},{"av":"Z574PropostaAssinaturaStatus","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","nullAv":"n323PropostaId","type":"int"}]}""");
         setEventMetadata("VALID_PROPOSTACONTRATO","""{"handler":"Valid_Propostacontrato","iparms":[{"av":"A570PropostaContrato","fld":"PROPOSTACONTRATO","pic":"ZZZZZ9","nullAv":"n570PropostaContrato","type":"int"}]}""");
         setEventMetadata("VALID_PROPOSTAASSINATURA","""{"handler":"Valid_Propostaassinatura","iparms":[{"av":"A571PropostaAssinatura","fld":"PROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","nullAv":"n571PropostaAssinatura","type":"int"},{"av":"cmbPropostaAssinaturaStatus"},{"av":"A574PropostaAssinaturaStatus","fld":"PROPOSTAASSINATURASTATUS","type":"svchar"}]""");
         setEventMetadata("VALID_PROPOSTAASSINATURA",""","oparms":[{"av":"cmbPropostaAssinaturaStatus"},{"av":"A574PropostaAssinaturaStatus","fld":"PROPOSTAASSINATURASTATUS","type":"svchar"}]}""");
         setEventMetadata("VALID_PROPOSTACONTRATOASSINATURATIPO","""{"handler":"Valid_Propostacontratoassinaturatipo","iparms":[]}""");
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
         pr_default.close(19);
         pr_default.close(20);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z573PropostaContratoAssinaturaTipo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A574PropostaAssinaturaStatus = "";
         A573PropostaContratoAssinaturaTipo = "";
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
         Z574PropostaAssinaturaStatus = "";
         T00277_A572PropostaContratoAssinaturaId = new int[1] ;
         T00277_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         T00277_A574PropostaAssinaturaStatus = new string[] {""} ;
         T00277_n574PropostaAssinaturaStatus = new bool[] {false} ;
         T00277_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         T00277_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         T00277_A323PropostaId = new int[1] ;
         T00277_n323PropostaId = new bool[] {false} ;
         T00277_A570PropostaContrato = new int[1] ;
         T00277_n570PropostaContrato = new bool[] {false} ;
         T00277_A571PropostaAssinatura = new long[1] ;
         T00277_n571PropostaAssinatura = new bool[] {false} ;
         T00274_A323PropostaId = new int[1] ;
         T00274_n323PropostaId = new bool[] {false} ;
         T00275_A570PropostaContrato = new int[1] ;
         T00275_n570PropostaContrato = new bool[] {false} ;
         T00276_A574PropostaAssinaturaStatus = new string[] {""} ;
         T00276_n574PropostaAssinaturaStatus = new bool[] {false} ;
         T00278_A323PropostaId = new int[1] ;
         T00278_n323PropostaId = new bool[] {false} ;
         T00279_A570PropostaContrato = new int[1] ;
         T00279_n570PropostaContrato = new bool[] {false} ;
         T002710_A574PropostaAssinaturaStatus = new string[] {""} ;
         T002710_n574PropostaAssinaturaStatus = new bool[] {false} ;
         T002711_A572PropostaContratoAssinaturaId = new int[1] ;
         T002711_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         T00273_A572PropostaContratoAssinaturaId = new int[1] ;
         T00273_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         T00273_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         T00273_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         T00273_A323PropostaId = new int[1] ;
         T00273_n323PropostaId = new bool[] {false} ;
         T00273_A570PropostaContrato = new int[1] ;
         T00273_n570PropostaContrato = new bool[] {false} ;
         T00273_A571PropostaAssinatura = new long[1] ;
         T00273_n571PropostaAssinatura = new bool[] {false} ;
         sMode78 = "";
         T002712_A572PropostaContratoAssinaturaId = new int[1] ;
         T002712_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         T002713_A572PropostaContratoAssinaturaId = new int[1] ;
         T002713_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         T00272_A572PropostaContratoAssinaturaId = new int[1] ;
         T00272_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         T00272_A573PropostaContratoAssinaturaTipo = new string[] {""} ;
         T00272_n573PropostaContratoAssinaturaTipo = new bool[] {false} ;
         T00272_A323PropostaId = new int[1] ;
         T00272_n323PropostaId = new bool[] {false} ;
         T00272_A570PropostaContrato = new int[1] ;
         T00272_n570PropostaContrato = new bool[] {false} ;
         T00272_A571PropostaAssinatura = new long[1] ;
         T00272_n571PropostaAssinatura = new bool[] {false} ;
         T002715_A572PropostaContratoAssinaturaId = new int[1] ;
         T002715_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         T002718_A574PropostaAssinaturaStatus = new string[] {""} ;
         T002718_n574PropostaAssinaturaStatus = new bool[] {false} ;
         T002719_A631ReembolsoAssinaturasId = new int[1] ;
         T002720_A572PropostaContratoAssinaturaId = new int[1] ;
         T002720_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ573PropostaContratoAssinaturaTipo = "";
         ZZ574PropostaAssinaturaStatus = "";
         T002721_A323PropostaId = new int[1] ;
         T002721_n323PropostaId = new bool[] {false} ;
         T002722_A570PropostaContrato = new int[1] ;
         T002722_n570PropostaContrato = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostacontratoassinatura__default(),
            new Object[][] {
                new Object[] {
               T00272_A572PropostaContratoAssinaturaId, T00272_A573PropostaContratoAssinaturaTipo, T00272_n573PropostaContratoAssinaturaTipo, T00272_A323PropostaId, T00272_n323PropostaId, T00272_A570PropostaContrato, T00272_n570PropostaContrato, T00272_A571PropostaAssinatura, T00272_n571PropostaAssinatura
               }
               , new Object[] {
               T00273_A572PropostaContratoAssinaturaId, T00273_A573PropostaContratoAssinaturaTipo, T00273_n573PropostaContratoAssinaturaTipo, T00273_A323PropostaId, T00273_n323PropostaId, T00273_A570PropostaContrato, T00273_n570PropostaContrato, T00273_A571PropostaAssinatura, T00273_n571PropostaAssinatura
               }
               , new Object[] {
               T00274_A323PropostaId
               }
               , new Object[] {
               T00275_A570PropostaContrato
               }
               , new Object[] {
               T00276_A574PropostaAssinaturaStatus, T00276_n574PropostaAssinaturaStatus
               }
               , new Object[] {
               T00277_A572PropostaContratoAssinaturaId, T00277_A574PropostaAssinaturaStatus, T00277_n574PropostaAssinaturaStatus, T00277_A573PropostaContratoAssinaturaTipo, T00277_n573PropostaContratoAssinaturaTipo, T00277_A323PropostaId, T00277_n323PropostaId, T00277_A570PropostaContrato, T00277_n570PropostaContrato, T00277_A571PropostaAssinatura,
               T00277_n571PropostaAssinatura
               }
               , new Object[] {
               T00278_A323PropostaId
               }
               , new Object[] {
               T00279_A570PropostaContrato
               }
               , new Object[] {
               T002710_A574PropostaAssinaturaStatus, T002710_n574PropostaAssinaturaStatus
               }
               , new Object[] {
               T002711_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               T002712_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               T002713_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               }
               , new Object[] {
               T002715_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002718_A574PropostaAssinaturaStatus, T002718_n574PropostaAssinaturaStatus
               }
               , new Object[] {
               T002719_A631ReembolsoAssinaturasId
               }
               , new Object[] {
               T002720_A572PropostaContratoAssinaturaId
               }
               , new Object[] {
               T002721_A323PropostaId
               }
               , new Object[] {
               T002722_A570PropostaContrato
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
      private short RcdFound78 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z572PropostaContratoAssinaturaId ;
      private int Z323PropostaId ;
      private int Z570PropostaContrato ;
      private int A323PropostaId ;
      private int A570PropostaContrato ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A572PropostaContratoAssinaturaId ;
      private int edtPropostaContratoAssinaturaId_Enabled ;
      private int edtPropostaId_Enabled ;
      private int edtPropostaContrato_Enabled ;
      private int edtPropostaAssinatura_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ572PropostaContratoAssinaturaId ;
      private int ZZ323PropostaId ;
      private int ZZ570PropostaContrato ;
      private long Z571PropostaAssinatura ;
      private long A571PropostaAssinatura ;
      private long ZZ571PropostaAssinatura ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPropostaContratoAssinaturaId_Internalname ;
      private string cmbPropostaAssinaturaStatus_Internalname ;
      private string cmbPropostaContratoAssinaturaTipo_Internalname ;
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
      private string edtPropostaContratoAssinaturaId_Jsonclick ;
      private string edtPropostaId_Internalname ;
      private string edtPropostaId_Jsonclick ;
      private string edtPropostaContrato_Internalname ;
      private string edtPropostaContrato_Jsonclick ;
      private string edtPropostaAssinatura_Internalname ;
      private string edtPropostaAssinatura_Jsonclick ;
      private string cmbPropostaAssinaturaStatus_Jsonclick ;
      private string cmbPropostaContratoAssinaturaTipo_Jsonclick ;
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
      private string sMode78 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n323PropostaId ;
      private bool n570PropostaContrato ;
      private bool n571PropostaAssinatura ;
      private bool wbErr ;
      private bool n574PropostaAssinaturaStatus ;
      private bool n573PropostaContratoAssinaturaTipo ;
      private bool n572PropostaContratoAssinaturaId ;
      private string Z573PropostaContratoAssinaturaTipo ;
      private string A574PropostaAssinaturaStatus ;
      private string A573PropostaContratoAssinaturaTipo ;
      private string Z574PropostaAssinaturaStatus ;
      private string ZZ573PropostaContratoAssinaturaTipo ;
      private string ZZ574PropostaAssinaturaStatus ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbPropostaAssinaturaStatus ;
      private GXCombobox cmbPropostaContratoAssinaturaTipo ;
      private IDataStoreProvider pr_default ;
      private int[] T00277_A572PropostaContratoAssinaturaId ;
      private bool[] T00277_n572PropostaContratoAssinaturaId ;
      private string[] T00277_A574PropostaAssinaturaStatus ;
      private bool[] T00277_n574PropostaAssinaturaStatus ;
      private string[] T00277_A573PropostaContratoAssinaturaTipo ;
      private bool[] T00277_n573PropostaContratoAssinaturaTipo ;
      private int[] T00277_A323PropostaId ;
      private bool[] T00277_n323PropostaId ;
      private int[] T00277_A570PropostaContrato ;
      private bool[] T00277_n570PropostaContrato ;
      private long[] T00277_A571PropostaAssinatura ;
      private bool[] T00277_n571PropostaAssinatura ;
      private int[] T00274_A323PropostaId ;
      private bool[] T00274_n323PropostaId ;
      private int[] T00275_A570PropostaContrato ;
      private bool[] T00275_n570PropostaContrato ;
      private string[] T00276_A574PropostaAssinaturaStatus ;
      private bool[] T00276_n574PropostaAssinaturaStatus ;
      private int[] T00278_A323PropostaId ;
      private bool[] T00278_n323PropostaId ;
      private int[] T00279_A570PropostaContrato ;
      private bool[] T00279_n570PropostaContrato ;
      private string[] T002710_A574PropostaAssinaturaStatus ;
      private bool[] T002710_n574PropostaAssinaturaStatus ;
      private int[] T002711_A572PropostaContratoAssinaturaId ;
      private bool[] T002711_n572PropostaContratoAssinaturaId ;
      private int[] T00273_A572PropostaContratoAssinaturaId ;
      private bool[] T00273_n572PropostaContratoAssinaturaId ;
      private string[] T00273_A573PropostaContratoAssinaturaTipo ;
      private bool[] T00273_n573PropostaContratoAssinaturaTipo ;
      private int[] T00273_A323PropostaId ;
      private bool[] T00273_n323PropostaId ;
      private int[] T00273_A570PropostaContrato ;
      private bool[] T00273_n570PropostaContrato ;
      private long[] T00273_A571PropostaAssinatura ;
      private bool[] T00273_n571PropostaAssinatura ;
      private int[] T002712_A572PropostaContratoAssinaturaId ;
      private bool[] T002712_n572PropostaContratoAssinaturaId ;
      private int[] T002713_A572PropostaContratoAssinaturaId ;
      private bool[] T002713_n572PropostaContratoAssinaturaId ;
      private int[] T00272_A572PropostaContratoAssinaturaId ;
      private bool[] T00272_n572PropostaContratoAssinaturaId ;
      private string[] T00272_A573PropostaContratoAssinaturaTipo ;
      private bool[] T00272_n573PropostaContratoAssinaturaTipo ;
      private int[] T00272_A323PropostaId ;
      private bool[] T00272_n323PropostaId ;
      private int[] T00272_A570PropostaContrato ;
      private bool[] T00272_n570PropostaContrato ;
      private long[] T00272_A571PropostaAssinatura ;
      private bool[] T00272_n571PropostaAssinatura ;
      private int[] T002715_A572PropostaContratoAssinaturaId ;
      private bool[] T002715_n572PropostaContratoAssinaturaId ;
      private string[] T002718_A574PropostaAssinaturaStatus ;
      private bool[] T002718_n574PropostaAssinaturaStatus ;
      private int[] T002719_A631ReembolsoAssinaturasId ;
      private int[] T002720_A572PropostaContratoAssinaturaId ;
      private bool[] T002720_n572PropostaContratoAssinaturaId ;
      private int[] T002721_A323PropostaId ;
      private bool[] T002721_n323PropostaId ;
      private int[] T002722_A570PropostaContrato ;
      private bool[] T002722_n570PropostaContrato ;
   }

   public class propostacontratoassinatura__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00272;
          prmT00272 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00273;
          prmT00273 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00274;
          prmT00274 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00275;
          prmT00275 = new Object[] {
          new ParDef("PropostaContrato",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT00276;
          prmT00276 = new Object[] {
          new ParDef("PropostaAssinatura",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT00277;
          prmT00277 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00278;
          prmT00278 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00279;
          prmT00279 = new Object[] {
          new ParDef("PropostaContrato",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmT002710;
          prmT002710 = new Object[] {
          new ParDef("PropostaAssinatura",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT002711;
          prmT002711 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002712;
          prmT002712 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002713;
          prmT002713 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002714;
          prmT002714 = new Object[] {
          new ParDef("PropostaContratoAssinaturaTipo",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaContrato",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("PropostaAssinatura",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT002715;
          prmT002715 = new Object[] {
          };
          Object[] prmT002716;
          prmT002716 = new Object[] {
          new ParDef("PropostaContratoAssinaturaTipo",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaContrato",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("PropostaAssinatura",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002717;
          prmT002717 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002718;
          prmT002718 = new Object[] {
          new ParDef("PropostaAssinatura",GXType.Int64,10,0){Nullable=true}
          };
          Object[] prmT002719;
          prmT002719 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002720;
          prmT002720 = new Object[] {
          };
          Object[] prmT002721;
          prmT002721 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002722;
          prmT002722 = new Object[] {
          new ParDef("PropostaContrato",GXType.Int32,6,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00272", "SELECT PropostaContratoAssinaturaId, PropostaContratoAssinaturaTipo, PropostaId, PropostaContrato, PropostaAssinatura FROM PropostaContratoAssinatura WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId  FOR UPDATE OF PropostaContratoAssinatura NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00272,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00273", "SELECT PropostaContratoAssinaturaId, PropostaContratoAssinaturaTipo, PropostaId, PropostaContrato, PropostaAssinatura FROM PropostaContratoAssinatura WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00273,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00274", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00274,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00275", "SELECT ContratoId AS PropostaContrato FROM Contrato WHERE ContratoId = :PropostaContrato ",true, GxErrorMask.GX_NOMASK, false, this,prmT00275,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00276", "SELECT AssinaturaStatus AS PropostaAssinaturaStatus FROM Assinatura WHERE AssinaturaId = :PropostaAssinatura ",true, GxErrorMask.GX_NOMASK, false, this,prmT00276,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00277", "SELECT TM1.PropostaContratoAssinaturaId, T2.AssinaturaStatus AS PropostaAssinaturaStatus, TM1.PropostaContratoAssinaturaTipo, TM1.PropostaId, TM1.PropostaContrato AS PropostaContrato, TM1.PropostaAssinatura AS PropostaAssinatura FROM (PropostaContratoAssinatura TM1 LEFT JOIN Assinatura T2 ON T2.AssinaturaId = TM1.PropostaAssinatura) WHERE TM1.PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ORDER BY TM1.PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00277,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00278", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00278,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00279", "SELECT ContratoId AS PropostaContrato FROM Contrato WHERE ContratoId = :PropostaContrato ",true, GxErrorMask.GX_NOMASK, false, this,prmT00279,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002710", "SELECT AssinaturaStatus AS PropostaAssinaturaStatus FROM Assinatura WHERE AssinaturaId = :PropostaAssinatura ",true, GxErrorMask.GX_NOMASK, false, this,prmT002710,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002711", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002711,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002712", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE ( PropostaContratoAssinaturaId > :PropostaContratoAssinaturaId) ORDER BY PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002712,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002713", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura WHERE ( PropostaContratoAssinaturaId < :PropostaContratoAssinaturaId) ORDER BY PropostaContratoAssinaturaId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002713,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002714", "SAVEPOINT gxupdate;INSERT INTO PropostaContratoAssinatura(PropostaContratoAssinaturaTipo, PropostaId, PropostaContrato, PropostaAssinatura) VALUES(:PropostaContratoAssinaturaTipo, :PropostaId, :PropostaContrato, :PropostaAssinatura);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002714)
             ,new CursorDef("T002715", "SELECT currval('PropostaContratoAssinaturaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002715,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002716", "SAVEPOINT gxupdate;UPDATE PropostaContratoAssinatura SET PropostaContratoAssinaturaTipo=:PropostaContratoAssinaturaTipo, PropostaId=:PropostaId, PropostaContrato=:PropostaContrato, PropostaAssinatura=:PropostaAssinatura  WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002716)
             ,new CursorDef("T002717", "SAVEPOINT gxupdate;DELETE FROM PropostaContratoAssinatura  WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002717)
             ,new CursorDef("T002718", "SELECT AssinaturaStatus AS PropostaAssinaturaStatus FROM Assinatura WHERE AssinaturaId = :PropostaAssinatura ",true, GxErrorMask.GX_NOMASK, false, this,prmT002718,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002719", "SELECT ReembolsoAssinaturasId FROM ReembolsoAssinaturas WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002719,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002720", "SELECT PropostaContratoAssinaturaId FROM PropostaContratoAssinatura ORDER BY PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002720,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002721", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002721,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002722", "SELECT ContratoId AS PropostaContrato FROM Contrato WHERE ContratoId = :PropostaContrato ",true, GxErrorMask.GX_NOMASK, false, this,prmT002722,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
