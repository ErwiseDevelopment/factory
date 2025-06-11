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
   public class reembolsodocumento : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A526ReembolsoEtapaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoEtapaId"), "."), 18, MidpointRounding.ToEven));
            n526ReembolsoEtapaId = false;
            AssignAttri("", false, "A526ReembolsoEtapaId", ((0==A526ReembolsoEtapaId)&&IsIns( )||n526ReembolsoEtapaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A526ReembolsoEtapaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A526ReembolsoEtapaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A405DocumentosId = (int)(Math.Round(NumberUtil.Val( GetPar( "DocumentosId"), "."), 18, MidpointRounding.ToEven));
            n405DocumentosId = false;
            AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A405DocumentosId) ;
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
         Form.Meta.addItem("description", "Reembolso Documento", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtReembolsoDocumentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public reembolsodocumento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsodocumento( IGxContext context )
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
         cmbReembolsoDocumentoStatus = new GXCombobox();
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
         if ( cmbReembolsoDocumentoStatus.ItemCount > 0 )
         {
            A549ReembolsoDocumentoStatus = cmbReembolsoDocumentoStatus.getValidValue(A549ReembolsoDocumentoStatus);
            n549ReembolsoDocumentoStatus = false;
            AssignAttri("", false, "A549ReembolsoDocumentoStatus", A549ReembolsoDocumentoStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbReembolsoDocumentoStatus.CurrentValue = StringUtil.RTrim( A549ReembolsoDocumentoStatus);
            AssignProp("", false, cmbReembolsoDocumentoStatus_Internalname, "Values", cmbReembolsoDocumentoStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Reembolso Documento", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ReembolsoDocumento.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ReembolsoDocumento.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoDocumentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoDocumentoId_Internalname, "Documento Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoDocumentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A529ReembolsoDocumentoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtReembolsoDocumentoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A529ReembolsoDocumentoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A529ReembolsoDocumentoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoDocumentoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoDocumentoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoEtapaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoEtapaId_Internalname, "Reembolso Etapa Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoEtapaId_Internalname, ((0==A526ReembolsoEtapaId)&&IsIns( )||n526ReembolsoEtapaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A526ReembolsoEtapaId), 9, 0, ",", ""))), ((0==A526ReembolsoEtapaId)&&IsIns( )||n526ReembolsoEtapaId ? "" : StringUtil.LTrim( ((edtReembolsoEtapaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A526ReembolsoEtapaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A526ReembolsoEtapaId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoEtapaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoEtapaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoDocumentoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoDocumentoNome_Internalname, "Documento Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoDocumentoNome_Internalname, A530ReembolsoDocumentoNome, StringUtil.RTrim( context.localUtil.Format( A530ReembolsoDocumentoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoDocumentoNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoDocumentoNome_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoDocumentoBlob_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoDocumentoBlob_Internalname, "Documento Blob", "col-sm-3 ImageLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         ClassString = "Image";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         edtReembolsoDocumentoBlob_Filetype = "tmp";
         AssignProp("", false, edtReembolsoDocumentoBlob_Internalname, "Filetype", edtReembolsoDocumentoBlob_Filetype, true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A531ReembolsoDocumentoBlob)) )
         {
            gxblobfileaux.Source = A531ReembolsoDocumentoBlob;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtReembolsoDocumentoBlob_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtReembolsoDocumentoBlob_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A531ReembolsoDocumentoBlob = gxblobfileaux.GetURI();
               n531ReembolsoDocumentoBlob = false;
               AssignAttri("", false, "A531ReembolsoDocumentoBlob", A531ReembolsoDocumentoBlob);
               AssignProp("", false, edtReembolsoDocumentoBlob_Internalname, "URL", context.PathToRelativeUrl( A531ReembolsoDocumentoBlob), true);
               edtReembolsoDocumentoBlob_Filetype = gxblobfileaux.GetExtension();
               AssignProp("", false, edtReembolsoDocumentoBlob_Internalname, "Filetype", edtReembolsoDocumentoBlob_Filetype, true);
            }
            AssignProp("", false, edtReembolsoDocumentoBlob_Internalname, "URL", context.PathToRelativeUrl( A531ReembolsoDocumentoBlob), true);
         }
         GxWebStd.gx_blob_field( context, edtReembolsoDocumentoBlob_Internalname, StringUtil.RTrim( A531ReembolsoDocumentoBlob), context.PathToRelativeUrl( A531ReembolsoDocumentoBlob), (String.IsNullOrEmpty(StringUtil.RTrim( edtReembolsoDocumentoBlob_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtReembolsoDocumentoBlob_Filetype)) ? A531ReembolsoDocumentoBlob : edtReembolsoDocumentoBlob_Filetype)) : edtReembolsoDocumentoBlob_Contenttype), false, "", edtReembolsoDocumentoBlob_Parameters, 0, edtReembolsoDocumentoBlob_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtReembolsoDocumentoBlob_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", "", "HLP_ReembolsoDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoDocumentoBlobExt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoDocumentoBlobExt_Internalname, "Blob Ext", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoDocumentoBlobExt_Internalname, A532ReembolsoDocumentoBlobExt, StringUtil.RTrim( context.localUtil.Format( A532ReembolsoDocumentoBlobExt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoDocumentoBlobExt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoDocumentoBlobExt_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoDocumentoCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoDocumentoCreatedAt_Internalname, "Created At", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtReembolsoDocumentoCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtReembolsoDocumentoCreatedAt_Internalname, context.localUtil.TToC( A533ReembolsoDocumentoCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A533ReembolsoDocumentoCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoDocumentoCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoDocumentoCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoDocumento.htm");
         GxWebStd.gx_bitmap( context, edtReembolsoDocumentoCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtReembolsoDocumentoCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ReembolsoDocumento.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDocumentosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocumentosId_Internalname, "Documentos Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentosId_Internalname, ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ",", ""))), ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( ((edtDocumentosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A405DocumentosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A405DocumentosId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocumentosId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbReembolsoDocumentoStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbReembolsoDocumentoStatus_Internalname, "Documento Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbReembolsoDocumentoStatus, cmbReembolsoDocumentoStatus_Internalname, StringUtil.RTrim( A549ReembolsoDocumentoStatus), 1, cmbReembolsoDocumentoStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbReembolsoDocumentoStatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "", true, 0, "HLP_ReembolsoDocumento.htm");
         cmbReembolsoDocumentoStatus.CurrentValue = StringUtil.RTrim( A549ReembolsoDocumentoStatus);
         AssignProp("", false, cmbReembolsoDocumentoStatus_Internalname, "Values", (string)(cmbReembolsoDocumentoStatus.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoDocumento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoDocumento.htm");
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
            Z529ReembolsoDocumentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z529ReembolsoDocumentoId"), ",", "."), 18, MidpointRounding.ToEven));
            Z530ReembolsoDocumentoNome = cgiGet( "Z530ReembolsoDocumentoNome");
            n530ReembolsoDocumentoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A530ReembolsoDocumentoNome)) ? true : false);
            Z532ReembolsoDocumentoBlobExt = cgiGet( "Z532ReembolsoDocumentoBlobExt");
            n532ReembolsoDocumentoBlobExt = (String.IsNullOrEmpty(StringUtil.RTrim( A532ReembolsoDocumentoBlobExt)) ? true : false);
            Z533ReembolsoDocumentoCreatedAt = context.localUtil.CToT( cgiGet( "Z533ReembolsoDocumentoCreatedAt"), 0);
            n533ReembolsoDocumentoCreatedAt = ((DateTime.MinValue==A533ReembolsoDocumentoCreatedAt) ? true : false);
            Z549ReembolsoDocumentoStatus = cgiGet( "Z549ReembolsoDocumentoStatus");
            n549ReembolsoDocumentoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A549ReembolsoDocumentoStatus)) ? true : false);
            Z526ReembolsoEtapaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z526ReembolsoEtapaId"), ",", "."), 18, MidpointRounding.ToEven));
            n526ReembolsoEtapaId = ((0==A526ReembolsoEtapaId) ? true : false);
            Z405DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z405DocumentosId"), ",", "."), 18, MidpointRounding.ToEven));
            n405DocumentosId = ((0==A405DocumentosId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            edtReembolsoDocumentoBlob_Filename = cgiGet( "REEMBOLSODOCUMENTOBLOB_Filename");
            edtReembolsoDocumentoBlob_Filetype = cgiGet( "REEMBOLSODOCUMENTOBLOB_Filetype");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoDocumentoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoDocumentoId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSODOCUMENTOID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoDocumentoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A529ReembolsoDocumentoId = 0;
               AssignAttri("", false, "A529ReembolsoDocumentoId", StringUtil.LTrimStr( (decimal)(A529ReembolsoDocumentoId), 9, 0));
            }
            else
            {
               A529ReembolsoDocumentoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoDocumentoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A529ReembolsoDocumentoId", StringUtil.LTrimStr( (decimal)(A529ReembolsoDocumentoId), 9, 0));
            }
            n526ReembolsoEtapaId = ((StringUtil.StrCmp(cgiGet( edtReembolsoEtapaId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoEtapaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoEtapaId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOETAPAID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoEtapaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A526ReembolsoEtapaId = 0;
               n526ReembolsoEtapaId = false;
               AssignAttri("", false, "A526ReembolsoEtapaId", (n526ReembolsoEtapaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A526ReembolsoEtapaId), 9, 0, ".", ""))));
            }
            else
            {
               A526ReembolsoEtapaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoEtapaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A526ReembolsoEtapaId", (n526ReembolsoEtapaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A526ReembolsoEtapaId), 9, 0, ".", ""))));
            }
            A530ReembolsoDocumentoNome = cgiGet( edtReembolsoDocumentoNome_Internalname);
            n530ReembolsoDocumentoNome = false;
            AssignAttri("", false, "A530ReembolsoDocumentoNome", A530ReembolsoDocumentoNome);
            n530ReembolsoDocumentoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A530ReembolsoDocumentoNome)) ? true : false);
            A531ReembolsoDocumentoBlob = cgiGet( edtReembolsoDocumentoBlob_Internalname);
            n531ReembolsoDocumentoBlob = false;
            AssignAttri("", false, "A531ReembolsoDocumentoBlob", A531ReembolsoDocumentoBlob);
            n531ReembolsoDocumentoBlob = (String.IsNullOrEmpty(StringUtil.RTrim( A531ReembolsoDocumentoBlob)) ? true : false);
            A532ReembolsoDocumentoBlobExt = cgiGet( edtReembolsoDocumentoBlobExt_Internalname);
            n532ReembolsoDocumentoBlobExt = false;
            AssignAttri("", false, "A532ReembolsoDocumentoBlobExt", A532ReembolsoDocumentoBlobExt);
            n532ReembolsoDocumentoBlobExt = (String.IsNullOrEmpty(StringUtil.RTrim( A532ReembolsoDocumentoBlobExt)) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtReembolsoDocumentoCreatedAt_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Reembolso Documento Created At"}), 1, "REEMBOLSODOCUMENTOCREATEDAT");
               AnyError = 1;
               GX_FocusControl = edtReembolsoDocumentoCreatedAt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A533ReembolsoDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
               n533ReembolsoDocumentoCreatedAt = false;
               AssignAttri("", false, "A533ReembolsoDocumentoCreatedAt", context.localUtil.TToC( A533ReembolsoDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A533ReembolsoDocumentoCreatedAt = context.localUtil.CToT( cgiGet( edtReembolsoDocumentoCreatedAt_Internalname));
               n533ReembolsoDocumentoCreatedAt = false;
               AssignAttri("", false, "A533ReembolsoDocumentoCreatedAt", context.localUtil.TToC( A533ReembolsoDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            n533ReembolsoDocumentoCreatedAt = ((DateTime.MinValue==A533ReembolsoDocumentoCreatedAt) ? true : false);
            n405DocumentosId = ((StringUtil.StrCmp(cgiGet( edtDocumentosId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtDocumentosId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocumentosId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCUMENTOSID");
               AnyError = 1;
               GX_FocusControl = edtDocumentosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A405DocumentosId = 0;
               n405DocumentosId = false;
               AssignAttri("", false, "A405DocumentosId", (n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
            }
            else
            {
               A405DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDocumentosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A405DocumentosId", (n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
            }
            cmbReembolsoDocumentoStatus.CurrentValue = cgiGet( cmbReembolsoDocumentoStatus_Internalname);
            A549ReembolsoDocumentoStatus = cgiGet( cmbReembolsoDocumentoStatus_Internalname);
            n549ReembolsoDocumentoStatus = false;
            AssignAttri("", false, "A549ReembolsoDocumentoStatus", A549ReembolsoDocumentoStatus);
            n549ReembolsoDocumentoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A549ReembolsoDocumentoStatus)) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A531ReembolsoDocumentoBlob)) )
            {
               edtReembolsoDocumentoBlob_Filename = (string)(CGIGetFileName(edtReembolsoDocumentoBlob_Internalname));
               edtReembolsoDocumentoBlob_Filetype = (string)(CGIGetFileType(edtReembolsoDocumentoBlob_Internalname));
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A531ReembolsoDocumentoBlob)) )
            {
               GXCCtlgxBlob = "REEMBOLSODOCUMENTOBLOB" + "_gxBlob";
               A531ReembolsoDocumentoBlob = cgiGet( GXCCtlgxBlob);
               n531ReembolsoDocumentoBlob = false;
               n531ReembolsoDocumentoBlob = (String.IsNullOrEmpty(StringUtil.RTrim( A531ReembolsoDocumentoBlob)) ? true : false);
            }
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
               A529ReembolsoDocumentoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoDocumentoId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A529ReembolsoDocumentoId", StringUtil.LTrimStr( (decimal)(A529ReembolsoDocumentoId), 9, 0));
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
               InitAll2174( ) ;
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
         DisableAttributes2174( ) ;
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

      protected void ResetCaption210( )
      {
      }

      protected void ZM2174( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z530ReembolsoDocumentoNome = T00213_A530ReembolsoDocumentoNome[0];
               Z532ReembolsoDocumentoBlobExt = T00213_A532ReembolsoDocumentoBlobExt[0];
               Z533ReembolsoDocumentoCreatedAt = T00213_A533ReembolsoDocumentoCreatedAt[0];
               Z549ReembolsoDocumentoStatus = T00213_A549ReembolsoDocumentoStatus[0];
               Z526ReembolsoEtapaId = T00213_A526ReembolsoEtapaId[0];
               Z405DocumentosId = T00213_A405DocumentosId[0];
            }
            else
            {
               Z530ReembolsoDocumentoNome = A530ReembolsoDocumentoNome;
               Z532ReembolsoDocumentoBlobExt = A532ReembolsoDocumentoBlobExt;
               Z533ReembolsoDocumentoCreatedAt = A533ReembolsoDocumentoCreatedAt;
               Z549ReembolsoDocumentoStatus = A549ReembolsoDocumentoStatus;
               Z526ReembolsoEtapaId = A526ReembolsoEtapaId;
               Z405DocumentosId = A405DocumentosId;
            }
         }
         if ( GX_JID == -3 )
         {
            Z529ReembolsoDocumentoId = A529ReembolsoDocumentoId;
            Z530ReembolsoDocumentoNome = A530ReembolsoDocumentoNome;
            Z531ReembolsoDocumentoBlob = A531ReembolsoDocumentoBlob;
            Z532ReembolsoDocumentoBlobExt = A532ReembolsoDocumentoBlobExt;
            Z533ReembolsoDocumentoCreatedAt = A533ReembolsoDocumentoCreatedAt;
            Z549ReembolsoDocumentoStatus = A549ReembolsoDocumentoStatus;
            Z526ReembolsoEtapaId = A526ReembolsoEtapaId;
            Z405DocumentosId = A405DocumentosId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A533ReembolsoDocumentoCreatedAt) && ( Gx_BScreen == 0 ) )
         {
            A533ReembolsoDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n533ReembolsoDocumentoCreatedAt = false;
            AssignAttri("", false, "A533ReembolsoDocumentoCreatedAt", context.localUtil.TToC( A533ReembolsoDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
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

      protected void Load2174( )
      {
         /* Using cursor T00216 */
         pr_default.execute(4, new Object[] {A529ReembolsoDocumentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound74 = 1;
            A530ReembolsoDocumentoNome = T00216_A530ReembolsoDocumentoNome[0];
            n530ReembolsoDocumentoNome = T00216_n530ReembolsoDocumentoNome[0];
            AssignAttri("", false, "A530ReembolsoDocumentoNome", A530ReembolsoDocumentoNome);
            A532ReembolsoDocumentoBlobExt = T00216_A532ReembolsoDocumentoBlobExt[0];
            n532ReembolsoDocumentoBlobExt = T00216_n532ReembolsoDocumentoBlobExt[0];
            AssignAttri("", false, "A532ReembolsoDocumentoBlobExt", A532ReembolsoDocumentoBlobExt);
            A533ReembolsoDocumentoCreatedAt = T00216_A533ReembolsoDocumentoCreatedAt[0];
            n533ReembolsoDocumentoCreatedAt = T00216_n533ReembolsoDocumentoCreatedAt[0];
            AssignAttri("", false, "A533ReembolsoDocumentoCreatedAt", context.localUtil.TToC( A533ReembolsoDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A549ReembolsoDocumentoStatus = T00216_A549ReembolsoDocumentoStatus[0];
            n549ReembolsoDocumentoStatus = T00216_n549ReembolsoDocumentoStatus[0];
            AssignAttri("", false, "A549ReembolsoDocumentoStatus", A549ReembolsoDocumentoStatus);
            A526ReembolsoEtapaId = T00216_A526ReembolsoEtapaId[0];
            n526ReembolsoEtapaId = T00216_n526ReembolsoEtapaId[0];
            AssignAttri("", false, "A526ReembolsoEtapaId", ((0==A526ReembolsoEtapaId)&&IsIns( )||n526ReembolsoEtapaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A526ReembolsoEtapaId), 9, 0, ".", ""))));
            A405DocumentosId = T00216_A405DocumentosId[0];
            n405DocumentosId = T00216_n405DocumentosId[0];
            AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
            A531ReembolsoDocumentoBlob = T00216_A531ReembolsoDocumentoBlob[0];
            n531ReembolsoDocumentoBlob = T00216_n531ReembolsoDocumentoBlob[0];
            AssignAttri("", false, "A531ReembolsoDocumentoBlob", A531ReembolsoDocumentoBlob);
            AssignProp("", false, edtReembolsoDocumentoBlob_Internalname, "URL", context.PathToRelativeUrl( A531ReembolsoDocumentoBlob), true);
            ZM2174( -3) ;
         }
         pr_default.close(4);
         OnLoadActions2174( ) ;
      }

      protected void OnLoadActions2174( )
      {
      }

      protected void CheckExtendedTable2174( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00214 */
         pr_default.execute(2, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A526ReembolsoEtapaId) ) )
            {
               GX_msglist.addItem("Não existe 'ReembolsoEtapa'.", "ForeignKeyNotFound", 1, "REEMBOLSOETAPAID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoEtapaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         /* Using cursor T00215 */
         pr_default.execute(3, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A405DocumentosId) ) )
            {
               GX_msglist.addItem("Não existe 'Documentos'.", "ForeignKeyNotFound", 1, "DOCUMENTOSID");
               AnyError = 1;
               GX_FocusControl = edtDocumentosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A549ReembolsoDocumentoStatus, "AGUARDANDO_ANALISE") == 0 ) || ( StringUtil.StrCmp(A549ReembolsoDocumentoStatus, "APROVADO") == 0 ) || ( StringUtil.StrCmp(A549ReembolsoDocumentoStatus, "REPROVADO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A549ReembolsoDocumentoStatus)) ) )
         {
            GX_msglist.addItem("Campo Reembolso Documento Status fora do intervalo", "OutOfRange", 1, "REEMBOLSODOCUMENTOSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbReembolsoDocumentoStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2174( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( int A526ReembolsoEtapaId )
      {
         /* Using cursor T00217 */
         pr_default.execute(5, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A526ReembolsoEtapaId) ) )
            {
               GX_msglist.addItem("Não existe 'ReembolsoEtapa'.", "ForeignKeyNotFound", 1, "REEMBOLSOETAPAID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoEtapaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_5( int A405DocumentosId )
      {
         /* Using cursor T00218 */
         pr_default.execute(6, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A405DocumentosId) ) )
            {
               GX_msglist.addItem("Não existe 'Documentos'.", "ForeignKeyNotFound", 1, "DOCUMENTOSID");
               AnyError = 1;
               GX_FocusControl = edtDocumentosId_Internalname;
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

      protected void GetKey2174( )
      {
         /* Using cursor T00219 */
         pr_default.execute(7, new Object[] {A529ReembolsoDocumentoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound74 = 1;
         }
         else
         {
            RcdFound74 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00213 */
         pr_default.execute(1, new Object[] {A529ReembolsoDocumentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2174( 3) ;
            RcdFound74 = 1;
            A529ReembolsoDocumentoId = T00213_A529ReembolsoDocumentoId[0];
            AssignAttri("", false, "A529ReembolsoDocumentoId", StringUtil.LTrimStr( (decimal)(A529ReembolsoDocumentoId), 9, 0));
            A530ReembolsoDocumentoNome = T00213_A530ReembolsoDocumentoNome[0];
            n530ReembolsoDocumentoNome = T00213_n530ReembolsoDocumentoNome[0];
            AssignAttri("", false, "A530ReembolsoDocumentoNome", A530ReembolsoDocumentoNome);
            A532ReembolsoDocumentoBlobExt = T00213_A532ReembolsoDocumentoBlobExt[0];
            n532ReembolsoDocumentoBlobExt = T00213_n532ReembolsoDocumentoBlobExt[0];
            AssignAttri("", false, "A532ReembolsoDocumentoBlobExt", A532ReembolsoDocumentoBlobExt);
            A533ReembolsoDocumentoCreatedAt = T00213_A533ReembolsoDocumentoCreatedAt[0];
            n533ReembolsoDocumentoCreatedAt = T00213_n533ReembolsoDocumentoCreatedAt[0];
            AssignAttri("", false, "A533ReembolsoDocumentoCreatedAt", context.localUtil.TToC( A533ReembolsoDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A549ReembolsoDocumentoStatus = T00213_A549ReembolsoDocumentoStatus[0];
            n549ReembolsoDocumentoStatus = T00213_n549ReembolsoDocumentoStatus[0];
            AssignAttri("", false, "A549ReembolsoDocumentoStatus", A549ReembolsoDocumentoStatus);
            A526ReembolsoEtapaId = T00213_A526ReembolsoEtapaId[0];
            n526ReembolsoEtapaId = T00213_n526ReembolsoEtapaId[0];
            AssignAttri("", false, "A526ReembolsoEtapaId", ((0==A526ReembolsoEtapaId)&&IsIns( )||n526ReembolsoEtapaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A526ReembolsoEtapaId), 9, 0, ".", ""))));
            A405DocumentosId = T00213_A405DocumentosId[0];
            n405DocumentosId = T00213_n405DocumentosId[0];
            AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
            A531ReembolsoDocumentoBlob = T00213_A531ReembolsoDocumentoBlob[0];
            n531ReembolsoDocumentoBlob = T00213_n531ReembolsoDocumentoBlob[0];
            AssignAttri("", false, "A531ReembolsoDocumentoBlob", A531ReembolsoDocumentoBlob);
            AssignProp("", false, edtReembolsoDocumentoBlob_Internalname, "URL", context.PathToRelativeUrl( A531ReembolsoDocumentoBlob), true);
            Z529ReembolsoDocumentoId = A529ReembolsoDocumentoId;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2174( ) ;
            if ( AnyError == 1 )
            {
               RcdFound74 = 0;
               InitializeNonKey2174( ) ;
            }
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound74 = 0;
            InitializeNonKey2174( ) ;
            sMode74 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode74;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2174( ) ;
         if ( RcdFound74 == 0 )
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
         RcdFound74 = 0;
         /* Using cursor T002110 */
         pr_default.execute(8, new Object[] {A529ReembolsoDocumentoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T002110_A529ReembolsoDocumentoId[0] < A529ReembolsoDocumentoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T002110_A529ReembolsoDocumentoId[0] > A529ReembolsoDocumentoId ) ) )
            {
               A529ReembolsoDocumentoId = T002110_A529ReembolsoDocumentoId[0];
               AssignAttri("", false, "A529ReembolsoDocumentoId", StringUtil.LTrimStr( (decimal)(A529ReembolsoDocumentoId), 9, 0));
               RcdFound74 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound74 = 0;
         /* Using cursor T002111 */
         pr_default.execute(9, new Object[] {A529ReembolsoDocumentoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T002111_A529ReembolsoDocumentoId[0] > A529ReembolsoDocumentoId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T002111_A529ReembolsoDocumentoId[0] < A529ReembolsoDocumentoId ) ) )
            {
               A529ReembolsoDocumentoId = T002111_A529ReembolsoDocumentoId[0];
               AssignAttri("", false, "A529ReembolsoDocumentoId", StringUtil.LTrimStr( (decimal)(A529ReembolsoDocumentoId), 9, 0));
               RcdFound74 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2174( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtReembolsoDocumentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2174( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound74 == 1 )
            {
               if ( A529ReembolsoDocumentoId != Z529ReembolsoDocumentoId )
               {
                  A529ReembolsoDocumentoId = Z529ReembolsoDocumentoId;
                  AssignAttri("", false, "A529ReembolsoDocumentoId", StringUtil.LTrimStr( (decimal)(A529ReembolsoDocumentoId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "REEMBOLSODOCUMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoDocumentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtReembolsoDocumentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2174( ) ;
                  GX_FocusControl = edtReembolsoDocumentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A529ReembolsoDocumentoId != Z529ReembolsoDocumentoId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtReembolsoDocumentoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2174( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "REEMBOLSODOCUMENTOID");
                     AnyError = 1;
                     GX_FocusControl = edtReembolsoDocumentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtReembolsoDocumentoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2174( ) ;
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
         if ( A529ReembolsoDocumentoId != Z529ReembolsoDocumentoId )
         {
            A529ReembolsoDocumentoId = Z529ReembolsoDocumentoId;
            AssignAttri("", false, "A529ReembolsoDocumentoId", StringUtil.LTrimStr( (decimal)(A529ReembolsoDocumentoId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "REEMBOLSODOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtReembolsoDocumentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtReembolsoDocumentoId_Internalname;
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
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "REEMBOLSODOCUMENTOID");
            AnyError = 1;
            GX_FocusControl = edtReembolsoDocumentoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtReembolsoEtapaId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2174( ) ;
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoEtapaId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2174( ) ;
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
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoEtapaId_Internalname;
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
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoEtapaId_Internalname;
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
         ScanStart2174( ) ;
         if ( RcdFound74 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound74 != 0 )
            {
               ScanNext2174( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoEtapaId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2174( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2174( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00212 */
            pr_default.execute(0, new Object[] {A529ReembolsoDocumentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoDocumento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z530ReembolsoDocumentoNome, T00212_A530ReembolsoDocumentoNome[0]) != 0 ) || ( StringUtil.StrCmp(Z532ReembolsoDocumentoBlobExt, T00212_A532ReembolsoDocumentoBlobExt[0]) != 0 ) || ( Z533ReembolsoDocumentoCreatedAt != T00212_A533ReembolsoDocumentoCreatedAt[0] ) || ( StringUtil.StrCmp(Z549ReembolsoDocumentoStatus, T00212_A549ReembolsoDocumentoStatus[0]) != 0 ) || ( Z526ReembolsoEtapaId != T00212_A526ReembolsoEtapaId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z405DocumentosId != T00212_A405DocumentosId[0] ) )
            {
               if ( StringUtil.StrCmp(Z530ReembolsoDocumentoNome, T00212_A530ReembolsoDocumentoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("reembolsodocumento:[seudo value changed for attri]"+"ReembolsoDocumentoNome");
                  GXUtil.WriteLogRaw("Old: ",Z530ReembolsoDocumentoNome);
                  GXUtil.WriteLogRaw("Current: ",T00212_A530ReembolsoDocumentoNome[0]);
               }
               if ( StringUtil.StrCmp(Z532ReembolsoDocumentoBlobExt, T00212_A532ReembolsoDocumentoBlobExt[0]) != 0 )
               {
                  GXUtil.WriteLog("reembolsodocumento:[seudo value changed for attri]"+"ReembolsoDocumentoBlobExt");
                  GXUtil.WriteLogRaw("Old: ",Z532ReembolsoDocumentoBlobExt);
                  GXUtil.WriteLogRaw("Current: ",T00212_A532ReembolsoDocumentoBlobExt[0]);
               }
               if ( Z533ReembolsoDocumentoCreatedAt != T00212_A533ReembolsoDocumentoCreatedAt[0] )
               {
                  GXUtil.WriteLog("reembolsodocumento:[seudo value changed for attri]"+"ReembolsoDocumentoCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z533ReembolsoDocumentoCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T00212_A533ReembolsoDocumentoCreatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z549ReembolsoDocumentoStatus, T00212_A549ReembolsoDocumentoStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("reembolsodocumento:[seudo value changed for attri]"+"ReembolsoDocumentoStatus");
                  GXUtil.WriteLogRaw("Old: ",Z549ReembolsoDocumentoStatus);
                  GXUtil.WriteLogRaw("Current: ",T00212_A549ReembolsoDocumentoStatus[0]);
               }
               if ( Z526ReembolsoEtapaId != T00212_A526ReembolsoEtapaId[0] )
               {
                  GXUtil.WriteLog("reembolsodocumento:[seudo value changed for attri]"+"ReembolsoEtapaId");
                  GXUtil.WriteLogRaw("Old: ",Z526ReembolsoEtapaId);
                  GXUtil.WriteLogRaw("Current: ",T00212_A526ReembolsoEtapaId[0]);
               }
               if ( Z405DocumentosId != T00212_A405DocumentosId[0] )
               {
                  GXUtil.WriteLog("reembolsodocumento:[seudo value changed for attri]"+"DocumentosId");
                  GXUtil.WriteLogRaw("Old: ",Z405DocumentosId);
                  GXUtil.WriteLogRaw("Current: ",T00212_A405DocumentosId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ReembolsoDocumento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2174( )
      {
         BeforeValidate2174( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2174( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2174( 0) ;
            CheckOptimisticConcurrency2174( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2174( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2174( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002112 */
                     pr_default.execute(10, new Object[] {n530ReembolsoDocumentoNome, A530ReembolsoDocumentoNome, n531ReembolsoDocumentoBlob, A531ReembolsoDocumentoBlob, n532ReembolsoDocumentoBlobExt, A532ReembolsoDocumentoBlobExt, n533ReembolsoDocumentoCreatedAt, A533ReembolsoDocumentoCreatedAt, n549ReembolsoDocumentoStatus, A549ReembolsoDocumentoStatus, n526ReembolsoEtapaId, A526ReembolsoEtapaId, n405DocumentosId, A405DocumentosId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002113 */
                     pr_default.execute(11);
                     A529ReembolsoDocumentoId = T002113_A529ReembolsoDocumentoId[0];
                     AssignAttri("", false, "A529ReembolsoDocumentoId", StringUtil.LTrimStr( (decimal)(A529ReembolsoDocumentoId), 9, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoDocumento");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption210( ) ;
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
               Load2174( ) ;
            }
            EndLevel2174( ) ;
         }
         CloseExtendedTableCursors2174( ) ;
      }

      protected void Update2174( )
      {
         BeforeValidate2174( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2174( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2174( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2174( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2174( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002114 */
                     pr_default.execute(12, new Object[] {n530ReembolsoDocumentoNome, A530ReembolsoDocumentoNome, n532ReembolsoDocumentoBlobExt, A532ReembolsoDocumentoBlobExt, n533ReembolsoDocumentoCreatedAt, A533ReembolsoDocumentoCreatedAt, n549ReembolsoDocumentoStatus, A549ReembolsoDocumentoStatus, n526ReembolsoEtapaId, A526ReembolsoEtapaId, n405DocumentosId, A405DocumentosId, A529ReembolsoDocumentoId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoDocumento");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoDocumento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2174( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption210( ) ;
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
            EndLevel2174( ) ;
         }
         CloseExtendedTableCursors2174( ) ;
      }

      protected void DeferredUpdate2174( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T002115 */
            pr_default.execute(13, new Object[] {n531ReembolsoDocumentoBlob, A531ReembolsoDocumentoBlob, A529ReembolsoDocumentoId});
            pr_default.close(13);
            pr_default.SmartCacheProvider.SetUpdated("ReembolsoDocumento");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2174( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2174( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2174( ) ;
            AfterConfirm2174( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2174( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002116 */
                  pr_default.execute(14, new Object[] {A529ReembolsoDocumentoId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("ReembolsoDocumento");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound74 == 0 )
                        {
                           InitAll2174( ) ;
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
                        ResetCaption210( ) ;
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
         sMode74 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2174( ) ;
         Gx_mode = sMode74;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2174( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2174( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2174( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues210( ) ;
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

      public void ScanStart2174( )
      {
         /* Using cursor T002117 */
         pr_default.execute(15);
         RcdFound74 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound74 = 1;
            A529ReembolsoDocumentoId = T002117_A529ReembolsoDocumentoId[0];
            AssignAttri("", false, "A529ReembolsoDocumentoId", StringUtil.LTrimStr( (decimal)(A529ReembolsoDocumentoId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2174( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound74 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound74 = 1;
            A529ReembolsoDocumentoId = T002117_A529ReembolsoDocumentoId[0];
            AssignAttri("", false, "A529ReembolsoDocumentoId", StringUtil.LTrimStr( (decimal)(A529ReembolsoDocumentoId), 9, 0));
         }
      }

      protected void ScanEnd2174( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm2174( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2174( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2174( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2174( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2174( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2174( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2174( )
      {
         edtReembolsoDocumentoId_Enabled = 0;
         AssignProp("", false, edtReembolsoDocumentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoDocumentoId_Enabled), 5, 0), true);
         edtReembolsoEtapaId_Enabled = 0;
         AssignProp("", false, edtReembolsoEtapaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoEtapaId_Enabled), 5, 0), true);
         edtReembolsoDocumentoNome_Enabled = 0;
         AssignProp("", false, edtReembolsoDocumentoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoDocumentoNome_Enabled), 5, 0), true);
         edtReembolsoDocumentoBlob_Enabled = 0;
         AssignProp("", false, edtReembolsoDocumentoBlob_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoDocumentoBlob_Enabled), 5, 0), true);
         edtReembolsoDocumentoBlobExt_Enabled = 0;
         AssignProp("", false, edtReembolsoDocumentoBlobExt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoDocumentoBlobExt_Enabled), 5, 0), true);
         edtReembolsoDocumentoCreatedAt_Enabled = 0;
         AssignProp("", false, edtReembolsoDocumentoCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoDocumentoCreatedAt_Enabled), 5, 0), true);
         edtDocumentosId_Enabled = 0;
         AssignProp("", false, edtDocumentosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentosId_Enabled), 5, 0), true);
         cmbReembolsoDocumentoStatus.Enabled = 0;
         AssignProp("", false, cmbReembolsoDocumentoStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbReembolsoDocumentoStatus.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2174( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues210( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reembolsodocumento") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z529ReembolsoDocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z529ReembolsoDocumentoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z530ReembolsoDocumentoNome", Z530ReembolsoDocumentoNome);
         GxWebStd.gx_hidden_field( context, "Z532ReembolsoDocumentoBlobExt", Z532ReembolsoDocumentoBlobExt);
         GxWebStd.gx_hidden_field( context, "Z533ReembolsoDocumentoCreatedAt", context.localUtil.TToC( Z533ReembolsoDocumentoCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z549ReembolsoDocumentoStatus", Z549ReembolsoDocumentoStatus);
         GxWebStd.gx_hidden_field( context, "Z526ReembolsoEtapaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z526ReembolsoEtapaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z405DocumentosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z405DocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GXCCtlgxBlob = "REEMBOLSODOCUMENTOBLOB" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A531ReembolsoDocumentoBlob);
         GxWebStd.gx_hidden_field( context, "REEMBOLSODOCUMENTOBLOB_Filename", StringUtil.RTrim( edtReembolsoDocumentoBlob_Filename));
         GxWebStd.gx_hidden_field( context, "REEMBOLSODOCUMENTOBLOB_Filetype", StringUtil.RTrim( edtReembolsoDocumentoBlob_Filetype));
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
         return formatLink("reembolsodocumento")  ;
      }

      public override string GetPgmname( )
      {
         return "ReembolsoDocumento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reembolso Documento" ;
      }

      protected void InitializeNonKey2174( )
      {
         A526ReembolsoEtapaId = 0;
         n526ReembolsoEtapaId = false;
         AssignAttri("", false, "A526ReembolsoEtapaId", ((0==A526ReembolsoEtapaId)&&IsIns( )||n526ReembolsoEtapaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A526ReembolsoEtapaId), 9, 0, ".", ""))));
         n526ReembolsoEtapaId = ((0==A526ReembolsoEtapaId) ? true : false);
         A530ReembolsoDocumentoNome = "";
         n530ReembolsoDocumentoNome = false;
         AssignAttri("", false, "A530ReembolsoDocumentoNome", A530ReembolsoDocumentoNome);
         n530ReembolsoDocumentoNome = (String.IsNullOrEmpty(StringUtil.RTrim( A530ReembolsoDocumentoNome)) ? true : false);
         A531ReembolsoDocumentoBlob = "";
         n531ReembolsoDocumentoBlob = false;
         AssignAttri("", false, "A531ReembolsoDocumentoBlob", A531ReembolsoDocumentoBlob);
         AssignProp("", false, edtReembolsoDocumentoBlob_Internalname, "URL", context.PathToRelativeUrl( A531ReembolsoDocumentoBlob), true);
         n531ReembolsoDocumentoBlob = (String.IsNullOrEmpty(StringUtil.RTrim( A531ReembolsoDocumentoBlob)) ? true : false);
         A532ReembolsoDocumentoBlobExt = "";
         n532ReembolsoDocumentoBlobExt = false;
         AssignAttri("", false, "A532ReembolsoDocumentoBlobExt", A532ReembolsoDocumentoBlobExt);
         n532ReembolsoDocumentoBlobExt = (String.IsNullOrEmpty(StringUtil.RTrim( A532ReembolsoDocumentoBlobExt)) ? true : false);
         A405DocumentosId = 0;
         n405DocumentosId = false;
         AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
         n405DocumentosId = ((0==A405DocumentosId) ? true : false);
         A549ReembolsoDocumentoStatus = "";
         n549ReembolsoDocumentoStatus = false;
         AssignAttri("", false, "A549ReembolsoDocumentoStatus", A549ReembolsoDocumentoStatus);
         n549ReembolsoDocumentoStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A549ReembolsoDocumentoStatus)) ? true : false);
         A533ReembolsoDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n533ReembolsoDocumentoCreatedAt = false;
         AssignAttri("", false, "A533ReembolsoDocumentoCreatedAt", context.localUtil.TToC( A533ReembolsoDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         Z530ReembolsoDocumentoNome = "";
         Z532ReembolsoDocumentoBlobExt = "";
         Z533ReembolsoDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         Z549ReembolsoDocumentoStatus = "";
         Z526ReembolsoEtapaId = 0;
         Z405DocumentosId = 0;
      }

      protected void InitAll2174( )
      {
         A529ReembolsoDocumentoId = 0;
         AssignAttri("", false, "A529ReembolsoDocumentoId", StringUtil.LTrimStr( (decimal)(A529ReembolsoDocumentoId), 9, 0));
         InitializeNonKey2174( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A533ReembolsoDocumentoCreatedAt = i533ReembolsoDocumentoCreatedAt;
         n533ReembolsoDocumentoCreatedAt = false;
         AssignAttri("", false, "A533ReembolsoDocumentoCreatedAt", context.localUtil.TToC( A533ReembolsoDocumentoCreatedAt, 8, 5, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019181317", true, true);
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
         context.AddJavascriptSource("reembolsodocumento.js", "?202561019181318", false, true);
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
         edtReembolsoDocumentoId_Internalname = "REEMBOLSODOCUMENTOID";
         edtReembolsoEtapaId_Internalname = "REEMBOLSOETAPAID";
         edtReembolsoDocumentoNome_Internalname = "REEMBOLSODOCUMENTONOME";
         edtReembolsoDocumentoBlob_Internalname = "REEMBOLSODOCUMENTOBLOB";
         edtReembolsoDocumentoBlobExt_Internalname = "REEMBOLSODOCUMENTOBLOBEXT";
         edtReembolsoDocumentoCreatedAt_Internalname = "REEMBOLSODOCUMENTOCREATEDAT";
         edtDocumentosId_Internalname = "DOCUMENTOSID";
         cmbReembolsoDocumentoStatus_Internalname = "REEMBOLSODOCUMENTOSTATUS";
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
         edtReembolsoDocumentoBlob_Filename = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Reembolso Documento";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbReembolsoDocumentoStatus_Jsonclick = "";
         cmbReembolsoDocumentoStatus.Enabled = 1;
         edtDocumentosId_Jsonclick = "";
         edtDocumentosId_Enabled = 1;
         edtReembolsoDocumentoCreatedAt_Jsonclick = "";
         edtReembolsoDocumentoCreatedAt_Enabled = 1;
         edtReembolsoDocumentoBlobExt_Jsonclick = "";
         edtReembolsoDocumentoBlobExt_Enabled = 1;
         edtReembolsoDocumentoBlob_Jsonclick = "";
         edtReembolsoDocumentoBlob_Parameters = "";
         edtReembolsoDocumentoBlob_Contenttype = "";
         edtReembolsoDocumentoBlob_Filetype = "";
         edtReembolsoDocumentoBlob_Enabled = 1;
         edtReembolsoDocumentoNome_Jsonclick = "";
         edtReembolsoDocumentoNome_Enabled = 1;
         edtReembolsoEtapaId_Jsonclick = "";
         edtReembolsoEtapaId_Enabled = 1;
         edtReembolsoDocumentoId_Jsonclick = "";
         edtReembolsoDocumentoId_Enabled = 1;
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
         cmbReembolsoDocumentoStatus.Name = "REEMBOLSODOCUMENTOSTATUS";
         cmbReembolsoDocumentoStatus.WebTags = "";
         cmbReembolsoDocumentoStatus.addItem("AGUARDANDO_ANALISE", "Aguardando análise", 0);
         cmbReembolsoDocumentoStatus.addItem("APROVADO", "Aprovado", 0);
         cmbReembolsoDocumentoStatus.addItem("REPROVADO", "Reprovado", 0);
         if ( cmbReembolsoDocumentoStatus.ItemCount > 0 )
         {
            A549ReembolsoDocumentoStatus = cmbReembolsoDocumentoStatus.getValidValue(A549ReembolsoDocumentoStatus);
            n549ReembolsoDocumentoStatus = false;
            AssignAttri("", false, "A549ReembolsoDocumentoStatus", A549ReembolsoDocumentoStatus);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtReembolsoEtapaId_Internalname;
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

      public void Valid_Reembolsodocumentoid( )
      {
         n549ReembolsoDocumentoStatus = false;
         A549ReembolsoDocumentoStatus = cmbReembolsoDocumentoStatus.CurrentValue;
         n549ReembolsoDocumentoStatus = false;
         cmbReembolsoDocumentoStatus.CurrentValue = A549ReembolsoDocumentoStatus;
         n533ReembolsoDocumentoCreatedAt = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbReembolsoDocumentoStatus.ItemCount > 0 )
         {
            A549ReembolsoDocumentoStatus = cmbReembolsoDocumentoStatus.getValidValue(A549ReembolsoDocumentoStatus);
            n549ReembolsoDocumentoStatus = false;
            cmbReembolsoDocumentoStatus.CurrentValue = A549ReembolsoDocumentoStatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbReembolsoDocumentoStatus.CurrentValue = StringUtil.RTrim( A549ReembolsoDocumentoStatus);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A526ReembolsoEtapaId", ((0==A526ReembolsoEtapaId)&&IsIns( )||n526ReembolsoEtapaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A526ReembolsoEtapaId), 9, 0, ".", ""))));
         AssignAttri("", false, "A530ReembolsoDocumentoNome", A530ReembolsoDocumentoNome);
         AssignAttri("", false, "A531ReembolsoDocumentoBlob", context.PathToRelativeUrl( A531ReembolsoDocumentoBlob));
         AssignAttri("", false, "A532ReembolsoDocumentoBlobExt", A532ReembolsoDocumentoBlobExt);
         AssignAttri("", false, "A533ReembolsoDocumentoCreatedAt", context.localUtil.TToC( A533ReembolsoDocumentoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
         AssignAttri("", false, "A549ReembolsoDocumentoStatus", A549ReembolsoDocumentoStatus);
         cmbReembolsoDocumentoStatus.CurrentValue = StringUtil.RTrim( A549ReembolsoDocumentoStatus);
         AssignProp("", false, cmbReembolsoDocumentoStatus_Internalname, "Values", cmbReembolsoDocumentoStatus.ToJavascriptSource(), true);
         AssignProp("", false, edtReembolsoDocumentoBlob_Internalname, "Filetype", edtReembolsoDocumentoBlob_Filetype, true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z529ReembolsoDocumentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z529ReembolsoDocumentoId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z526ReembolsoEtapaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z526ReembolsoEtapaId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z530ReembolsoDocumentoNome", Z530ReembolsoDocumentoNome);
         GxWebStd.gx_hidden_field( context, "Z531ReembolsoDocumentoBlob", context.PathToRelativeUrl( Z531ReembolsoDocumentoBlob));
         GxWebStd.gx_hidden_field( context, "Z532ReembolsoDocumentoBlobExt", Z532ReembolsoDocumentoBlobExt);
         GxWebStd.gx_hidden_field( context, "Z533ReembolsoDocumentoCreatedAt", context.localUtil.TToC( Z533ReembolsoDocumentoCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z405DocumentosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z405DocumentosId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z549ReembolsoDocumentoStatus", Z549ReembolsoDocumentoStatus);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Reembolsoetapaid( )
      {
         /* Using cursor T002118 */
         pr_default.execute(16, new Object[] {n526ReembolsoEtapaId, A526ReembolsoEtapaId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A526ReembolsoEtapaId) ) )
            {
               GX_msglist.addItem("Não existe 'ReembolsoEtapa'.", "ForeignKeyNotFound", 1, "REEMBOLSOETAPAID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoEtapaId_Internalname;
            }
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Documentosid( )
      {
         /* Using cursor T002119 */
         pr_default.execute(17, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A405DocumentosId) ) )
            {
               GX_msglist.addItem("Não existe 'Documentos'.", "ForeignKeyNotFound", 1, "DOCUMENTOSID");
               AnyError = 1;
               GX_FocusControl = edtDocumentosId_Internalname;
            }
         }
         pr_default.close(17);
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
         setEventMetadata("VALID_REEMBOLSODOCUMENTOID","""{"handler":"Valid_Reembolsodocumentoid","iparms":[{"av":"cmbReembolsoDocumentoStatus"},{"av":"A549ReembolsoDocumentoStatus","fld":"REEMBOLSODOCUMENTOSTATUS","type":"svchar"},{"av":"A529ReembolsoDocumentoId","fld":"REEMBOLSODOCUMENTOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A533ReembolsoDocumentoCreatedAt","fld":"REEMBOLSODOCUMENTOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"}]""");
         setEventMetadata("VALID_REEMBOLSODOCUMENTOID",""","oparms":[{"av":"A526ReembolsoEtapaId","fld":"REEMBOLSOETAPAID","pic":"ZZZZZZZZ9","nullAv":"n526ReembolsoEtapaId","type":"int"},{"av":"A530ReembolsoDocumentoNome","fld":"REEMBOLSODOCUMENTONOME","type":"svchar"},{"av":"A531ReembolsoDocumentoBlob","fld":"REEMBOLSODOCUMENTOBLOB","type":"bitstr"},{"av":"A532ReembolsoDocumentoBlobExt","fld":"REEMBOLSODOCUMENTOBLOBEXT","type":"svchar"},{"av":"A533ReembolsoDocumentoCreatedAt","fld":"REEMBOLSODOCUMENTOCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","nullAv":"n405DocumentosId","type":"int"},{"av":"cmbReembolsoDocumentoStatus"},{"av":"A549ReembolsoDocumentoStatus","fld":"REEMBOLSODOCUMENTOSTATUS","type":"svchar"},{"av":"edtReembolsoDocumentoBlob_Filetype","ctrl":"REEMBOLSODOCUMENTOBLOB","prop":"Filetype"},{"av":"edtReembolsoDocumentoBlob_Filename","ctrl":"REEMBOLSODOCUMENTOBLOB","prop":"Filename"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z529ReembolsoDocumentoId","type":"int"},{"av":"Z526ReembolsoEtapaId","type":"int"},{"av":"Z530ReembolsoDocumentoNome","type":"svchar"},{"av":"Z531ReembolsoDocumentoBlob","type":"bitstr"},{"av":"Z532ReembolsoDocumentoBlobExt","type":"svchar"},{"av":"Z533ReembolsoDocumentoCreatedAt","type":"dtime"},{"av":"Z405DocumentosId","type":"int"},{"av":"Z549ReembolsoDocumentoStatus","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_REEMBOLSOETAPAID","""{"handler":"Valid_Reembolsoetapaid","iparms":[{"av":"A526ReembolsoEtapaId","fld":"REEMBOLSOETAPAID","pic":"ZZZZZZZZ9","nullAv":"n526ReembolsoEtapaId","type":"int"}]}""");
         setEventMetadata("VALID_DOCUMENTOSID","""{"handler":"Valid_Documentosid","iparms":[{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","nullAv":"n405DocumentosId","type":"int"}]}""");
         setEventMetadata("VALID_REEMBOLSODOCUMENTOSTATUS","""{"handler":"Valid_Reembolsodocumentostatus","iparms":[]}""");
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
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z530ReembolsoDocumentoNome = "";
         Z532ReembolsoDocumentoBlobExt = "";
         Z533ReembolsoDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         Z549ReembolsoDocumentoStatus = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A549ReembolsoDocumentoStatus = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A530ReembolsoDocumentoNome = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         A531ReembolsoDocumentoBlob = "";
         A532ReembolsoDocumentoBlobExt = "";
         A533ReembolsoDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         GXCCtlgxBlob = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z531ReembolsoDocumentoBlob = "";
         T00216_A529ReembolsoDocumentoId = new int[1] ;
         T00216_A530ReembolsoDocumentoNome = new string[] {""} ;
         T00216_n530ReembolsoDocumentoNome = new bool[] {false} ;
         T00216_A532ReembolsoDocumentoBlobExt = new string[] {""} ;
         T00216_n532ReembolsoDocumentoBlobExt = new bool[] {false} ;
         T00216_A533ReembolsoDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00216_n533ReembolsoDocumentoCreatedAt = new bool[] {false} ;
         T00216_A549ReembolsoDocumentoStatus = new string[] {""} ;
         T00216_n549ReembolsoDocumentoStatus = new bool[] {false} ;
         T00216_A526ReembolsoEtapaId = new int[1] ;
         T00216_n526ReembolsoEtapaId = new bool[] {false} ;
         T00216_A405DocumentosId = new int[1] ;
         T00216_n405DocumentosId = new bool[] {false} ;
         T00216_A531ReembolsoDocumentoBlob = new string[] {""} ;
         T00216_n531ReembolsoDocumentoBlob = new bool[] {false} ;
         T00214_A526ReembolsoEtapaId = new int[1] ;
         T00214_n526ReembolsoEtapaId = new bool[] {false} ;
         T00215_A405DocumentosId = new int[1] ;
         T00215_n405DocumentosId = new bool[] {false} ;
         T00217_A526ReembolsoEtapaId = new int[1] ;
         T00217_n526ReembolsoEtapaId = new bool[] {false} ;
         T00218_A405DocumentosId = new int[1] ;
         T00218_n405DocumentosId = new bool[] {false} ;
         T00219_A529ReembolsoDocumentoId = new int[1] ;
         T00213_A529ReembolsoDocumentoId = new int[1] ;
         T00213_A530ReembolsoDocumentoNome = new string[] {""} ;
         T00213_n530ReembolsoDocumentoNome = new bool[] {false} ;
         T00213_A532ReembolsoDocumentoBlobExt = new string[] {""} ;
         T00213_n532ReembolsoDocumentoBlobExt = new bool[] {false} ;
         T00213_A533ReembolsoDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00213_n533ReembolsoDocumentoCreatedAt = new bool[] {false} ;
         T00213_A549ReembolsoDocumentoStatus = new string[] {""} ;
         T00213_n549ReembolsoDocumentoStatus = new bool[] {false} ;
         T00213_A526ReembolsoEtapaId = new int[1] ;
         T00213_n526ReembolsoEtapaId = new bool[] {false} ;
         T00213_A405DocumentosId = new int[1] ;
         T00213_n405DocumentosId = new bool[] {false} ;
         T00213_A531ReembolsoDocumentoBlob = new string[] {""} ;
         T00213_n531ReembolsoDocumentoBlob = new bool[] {false} ;
         sMode74 = "";
         T002110_A529ReembolsoDocumentoId = new int[1] ;
         T002111_A529ReembolsoDocumentoId = new int[1] ;
         T00212_A529ReembolsoDocumentoId = new int[1] ;
         T00212_A530ReembolsoDocumentoNome = new string[] {""} ;
         T00212_n530ReembolsoDocumentoNome = new bool[] {false} ;
         T00212_A532ReembolsoDocumentoBlobExt = new string[] {""} ;
         T00212_n532ReembolsoDocumentoBlobExt = new bool[] {false} ;
         T00212_A533ReembolsoDocumentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T00212_n533ReembolsoDocumentoCreatedAt = new bool[] {false} ;
         T00212_A549ReembolsoDocumentoStatus = new string[] {""} ;
         T00212_n549ReembolsoDocumentoStatus = new bool[] {false} ;
         T00212_A526ReembolsoEtapaId = new int[1] ;
         T00212_n526ReembolsoEtapaId = new bool[] {false} ;
         T00212_A405DocumentosId = new int[1] ;
         T00212_n405DocumentosId = new bool[] {false} ;
         T00212_A531ReembolsoDocumentoBlob = new string[] {""} ;
         T00212_n531ReembolsoDocumentoBlob = new bool[] {false} ;
         T002113_A529ReembolsoDocumentoId = new int[1] ;
         T002117_A529ReembolsoDocumentoId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i533ReembolsoDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         ZZ530ReembolsoDocumentoNome = "";
         ZZ531ReembolsoDocumentoBlob = "";
         ZZ532ReembolsoDocumentoBlobExt = "";
         ZZ533ReembolsoDocumentoCreatedAt = (DateTime)(DateTime.MinValue);
         ZZ549ReembolsoDocumentoStatus = "";
         T002118_A526ReembolsoEtapaId = new int[1] ;
         T002118_n526ReembolsoEtapaId = new bool[] {false} ;
         T002119_A405DocumentosId = new int[1] ;
         T002119_n405DocumentosId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsodocumento__default(),
            new Object[][] {
                new Object[] {
               T00212_A529ReembolsoDocumentoId, T00212_A530ReembolsoDocumentoNome, T00212_n530ReembolsoDocumentoNome, T00212_A532ReembolsoDocumentoBlobExt, T00212_n532ReembolsoDocumentoBlobExt, T00212_A533ReembolsoDocumentoCreatedAt, T00212_n533ReembolsoDocumentoCreatedAt, T00212_A549ReembolsoDocumentoStatus, T00212_n549ReembolsoDocumentoStatus, T00212_A526ReembolsoEtapaId,
               T00212_n526ReembolsoEtapaId, T00212_A405DocumentosId, T00212_n405DocumentosId, T00212_A531ReembolsoDocumentoBlob, T00212_n531ReembolsoDocumentoBlob
               }
               , new Object[] {
               T00213_A529ReembolsoDocumentoId, T00213_A530ReembolsoDocumentoNome, T00213_n530ReembolsoDocumentoNome, T00213_A532ReembolsoDocumentoBlobExt, T00213_n532ReembolsoDocumentoBlobExt, T00213_A533ReembolsoDocumentoCreatedAt, T00213_n533ReembolsoDocumentoCreatedAt, T00213_A549ReembolsoDocumentoStatus, T00213_n549ReembolsoDocumentoStatus, T00213_A526ReembolsoEtapaId,
               T00213_n526ReembolsoEtapaId, T00213_A405DocumentosId, T00213_n405DocumentosId, T00213_A531ReembolsoDocumentoBlob, T00213_n531ReembolsoDocumentoBlob
               }
               , new Object[] {
               T00214_A526ReembolsoEtapaId
               }
               , new Object[] {
               T00215_A405DocumentosId
               }
               , new Object[] {
               T00216_A529ReembolsoDocumentoId, T00216_A530ReembolsoDocumentoNome, T00216_n530ReembolsoDocumentoNome, T00216_A532ReembolsoDocumentoBlobExt, T00216_n532ReembolsoDocumentoBlobExt, T00216_A533ReembolsoDocumentoCreatedAt, T00216_n533ReembolsoDocumentoCreatedAt, T00216_A549ReembolsoDocumentoStatus, T00216_n549ReembolsoDocumentoStatus, T00216_A526ReembolsoEtapaId,
               T00216_n526ReembolsoEtapaId, T00216_A405DocumentosId, T00216_n405DocumentosId, T00216_A531ReembolsoDocumentoBlob, T00216_n531ReembolsoDocumentoBlob
               }
               , new Object[] {
               T00217_A526ReembolsoEtapaId
               }
               , new Object[] {
               T00218_A405DocumentosId
               }
               , new Object[] {
               T00219_A529ReembolsoDocumentoId
               }
               , new Object[] {
               T002110_A529ReembolsoDocumentoId
               }
               , new Object[] {
               T002111_A529ReembolsoDocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               T002113_A529ReembolsoDocumentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002117_A529ReembolsoDocumentoId
               }
               , new Object[] {
               T002118_A526ReembolsoEtapaId
               }
               , new Object[] {
               T002119_A405DocumentosId
               }
            }
         );
         Z533ReembolsoDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n533ReembolsoDocumentoCreatedAt = false;
         A533ReembolsoDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n533ReembolsoDocumentoCreatedAt = false;
         i533ReembolsoDocumentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n533ReembolsoDocumentoCreatedAt = false;
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound74 ;
      private short gxajaxcallmode ;
      private int Z529ReembolsoDocumentoId ;
      private int Z526ReembolsoEtapaId ;
      private int Z405DocumentosId ;
      private int A526ReembolsoEtapaId ;
      private int A405DocumentosId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A529ReembolsoDocumentoId ;
      private int edtReembolsoDocumentoId_Enabled ;
      private int edtReembolsoEtapaId_Enabled ;
      private int edtReembolsoDocumentoNome_Enabled ;
      private int edtReembolsoDocumentoBlob_Enabled ;
      private int edtReembolsoDocumentoBlobExt_Enabled ;
      private int edtReembolsoDocumentoCreatedAt_Enabled ;
      private int edtDocumentosId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ529ReembolsoDocumentoId ;
      private int ZZ526ReembolsoEtapaId ;
      private int ZZ405DocumentosId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtReembolsoDocumentoId_Internalname ;
      private string cmbReembolsoDocumentoStatus_Internalname ;
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
      private string edtReembolsoDocumentoId_Jsonclick ;
      private string edtReembolsoEtapaId_Internalname ;
      private string edtReembolsoEtapaId_Jsonclick ;
      private string edtReembolsoDocumentoNome_Internalname ;
      private string edtReembolsoDocumentoNome_Jsonclick ;
      private string edtReembolsoDocumentoBlob_Internalname ;
      private string edtReembolsoDocumentoBlob_Filetype ;
      private string edtReembolsoDocumentoBlob_Contenttype ;
      private string edtReembolsoDocumentoBlob_Parameters ;
      private string edtReembolsoDocumentoBlob_Jsonclick ;
      private string edtReembolsoDocumentoBlobExt_Internalname ;
      private string edtReembolsoDocumentoBlobExt_Jsonclick ;
      private string edtReembolsoDocumentoCreatedAt_Internalname ;
      private string edtReembolsoDocumentoCreatedAt_Jsonclick ;
      private string edtDocumentosId_Internalname ;
      private string edtDocumentosId_Jsonclick ;
      private string cmbReembolsoDocumentoStatus_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string edtReembolsoDocumentoBlob_Filename ;
      private string GXCCtlgxBlob ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode74 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z533ReembolsoDocumentoCreatedAt ;
      private DateTime A533ReembolsoDocumentoCreatedAt ;
      private DateTime i533ReembolsoDocumentoCreatedAt ;
      private DateTime ZZ533ReembolsoDocumentoCreatedAt ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n526ReembolsoEtapaId ;
      private bool n405DocumentosId ;
      private bool wbErr ;
      private bool n549ReembolsoDocumentoStatus ;
      private bool n531ReembolsoDocumentoBlob ;
      private bool n530ReembolsoDocumentoNome ;
      private bool n532ReembolsoDocumentoBlobExt ;
      private bool n533ReembolsoDocumentoCreatedAt ;
      private bool Gx_longc ;
      private string Z530ReembolsoDocumentoNome ;
      private string Z532ReembolsoDocumentoBlobExt ;
      private string Z549ReembolsoDocumentoStatus ;
      private string A549ReembolsoDocumentoStatus ;
      private string A530ReembolsoDocumentoNome ;
      private string A532ReembolsoDocumentoBlobExt ;
      private string ZZ530ReembolsoDocumentoNome ;
      private string ZZ532ReembolsoDocumentoBlobExt ;
      private string ZZ549ReembolsoDocumentoStatus ;
      private string A531ReembolsoDocumentoBlob ;
      private string Z531ReembolsoDocumentoBlob ;
      private string ZZ531ReembolsoDocumentoBlob ;
      private GxFile gxblobfileaux ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbReembolsoDocumentoStatus ;
      private IDataStoreProvider pr_default ;
      private int[] T00216_A529ReembolsoDocumentoId ;
      private string[] T00216_A530ReembolsoDocumentoNome ;
      private bool[] T00216_n530ReembolsoDocumentoNome ;
      private string[] T00216_A532ReembolsoDocumentoBlobExt ;
      private bool[] T00216_n532ReembolsoDocumentoBlobExt ;
      private DateTime[] T00216_A533ReembolsoDocumentoCreatedAt ;
      private bool[] T00216_n533ReembolsoDocumentoCreatedAt ;
      private string[] T00216_A549ReembolsoDocumentoStatus ;
      private bool[] T00216_n549ReembolsoDocumentoStatus ;
      private int[] T00216_A526ReembolsoEtapaId ;
      private bool[] T00216_n526ReembolsoEtapaId ;
      private int[] T00216_A405DocumentosId ;
      private bool[] T00216_n405DocumentosId ;
      private string[] T00216_A531ReembolsoDocumentoBlob ;
      private bool[] T00216_n531ReembolsoDocumentoBlob ;
      private int[] T00214_A526ReembolsoEtapaId ;
      private bool[] T00214_n526ReembolsoEtapaId ;
      private int[] T00215_A405DocumentosId ;
      private bool[] T00215_n405DocumentosId ;
      private int[] T00217_A526ReembolsoEtapaId ;
      private bool[] T00217_n526ReembolsoEtapaId ;
      private int[] T00218_A405DocumentosId ;
      private bool[] T00218_n405DocumentosId ;
      private int[] T00219_A529ReembolsoDocumentoId ;
      private int[] T00213_A529ReembolsoDocumentoId ;
      private string[] T00213_A530ReembolsoDocumentoNome ;
      private bool[] T00213_n530ReembolsoDocumentoNome ;
      private string[] T00213_A532ReembolsoDocumentoBlobExt ;
      private bool[] T00213_n532ReembolsoDocumentoBlobExt ;
      private DateTime[] T00213_A533ReembolsoDocumentoCreatedAt ;
      private bool[] T00213_n533ReembolsoDocumentoCreatedAt ;
      private string[] T00213_A549ReembolsoDocumentoStatus ;
      private bool[] T00213_n549ReembolsoDocumentoStatus ;
      private int[] T00213_A526ReembolsoEtapaId ;
      private bool[] T00213_n526ReembolsoEtapaId ;
      private int[] T00213_A405DocumentosId ;
      private bool[] T00213_n405DocumentosId ;
      private string[] T00213_A531ReembolsoDocumentoBlob ;
      private bool[] T00213_n531ReembolsoDocumentoBlob ;
      private int[] T002110_A529ReembolsoDocumentoId ;
      private int[] T002111_A529ReembolsoDocumentoId ;
      private int[] T00212_A529ReembolsoDocumentoId ;
      private string[] T00212_A530ReembolsoDocumentoNome ;
      private bool[] T00212_n530ReembolsoDocumentoNome ;
      private string[] T00212_A532ReembolsoDocumentoBlobExt ;
      private bool[] T00212_n532ReembolsoDocumentoBlobExt ;
      private DateTime[] T00212_A533ReembolsoDocumentoCreatedAt ;
      private bool[] T00212_n533ReembolsoDocumentoCreatedAt ;
      private string[] T00212_A549ReembolsoDocumentoStatus ;
      private bool[] T00212_n549ReembolsoDocumentoStatus ;
      private int[] T00212_A526ReembolsoEtapaId ;
      private bool[] T00212_n526ReembolsoEtapaId ;
      private int[] T00212_A405DocumentosId ;
      private bool[] T00212_n405DocumentosId ;
      private string[] T00212_A531ReembolsoDocumentoBlob ;
      private bool[] T00212_n531ReembolsoDocumentoBlob ;
      private int[] T002113_A529ReembolsoDocumentoId ;
      private int[] T002117_A529ReembolsoDocumentoId ;
      private int[] T002118_A526ReembolsoEtapaId ;
      private bool[] T002118_n526ReembolsoEtapaId ;
      private int[] T002119_A405DocumentosId ;
      private bool[] T002119_n405DocumentosId ;
   }

   public class reembolsodocumento__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[14])
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
          Object[] prmT00212;
          prmT00212 = new Object[] {
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT00213;
          prmT00213 = new Object[] {
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT00214;
          prmT00214 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00215;
          prmT00215 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00216;
          prmT00216 = new Object[] {
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT00217;
          prmT00217 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00218;
          prmT00218 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00219;
          prmT00219 = new Object[] {
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT002110;
          prmT002110 = new Object[] {
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT002111;
          prmT002111 = new Object[] {
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT002112;
          prmT002112 = new Object[] {
          new ParDef("ReembolsoDocumentoNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ReembolsoDocumentoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ReembolsoDocumentoBlobExt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ReembolsoDocumentoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoDocumentoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002113;
          prmT002113 = new Object[] {
          };
          Object[] prmT002114;
          prmT002114 = new Object[] {
          new ParDef("ReembolsoDocumentoNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ReembolsoDocumentoBlobExt",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ReembolsoDocumentoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoDocumentoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT002115;
          prmT002115 = new Object[] {
          new ParDef("ReembolsoDocumentoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT002116;
          prmT002116 = new Object[] {
          new ParDef("ReembolsoDocumentoId",GXType.Int32,9,0)
          };
          Object[] prmT002117;
          prmT002117 = new Object[] {
          };
          Object[] prmT002118;
          prmT002118 = new Object[] {
          new ParDef("ReembolsoEtapaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002119;
          prmT002119 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00212", "SELECT ReembolsoDocumentoId, ReembolsoDocumentoNome, ReembolsoDocumentoBlobExt, ReembolsoDocumentoCreatedAt, ReembolsoDocumentoStatus, ReembolsoEtapaId, DocumentosId, ReembolsoDocumentoBlob FROM ReembolsoDocumento WHERE ReembolsoDocumentoId = :ReembolsoDocumentoId  FOR UPDATE OF ReembolsoDocumento NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00212,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00213", "SELECT ReembolsoDocumentoId, ReembolsoDocumentoNome, ReembolsoDocumentoBlobExt, ReembolsoDocumentoCreatedAt, ReembolsoDocumentoStatus, ReembolsoEtapaId, DocumentosId, ReembolsoDocumentoBlob FROM ReembolsoDocumento WHERE ReembolsoDocumentoId = :ReembolsoDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00213,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00214", "SELECT ReembolsoEtapaId FROM ReembolsoEtapa WHERE ReembolsoEtapaId = :ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00214,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00215", "SELECT DocumentosId FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00215,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00216", "SELECT TM1.ReembolsoDocumentoId, TM1.ReembolsoDocumentoNome, TM1.ReembolsoDocumentoBlobExt, TM1.ReembolsoDocumentoCreatedAt, TM1.ReembolsoDocumentoStatus, TM1.ReembolsoEtapaId, TM1.DocumentosId, TM1.ReembolsoDocumentoBlob FROM ReembolsoDocumento TM1 WHERE TM1.ReembolsoDocumentoId = :ReembolsoDocumentoId ORDER BY TM1.ReembolsoDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00216,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00217", "SELECT ReembolsoEtapaId FROM ReembolsoEtapa WHERE ReembolsoEtapaId = :ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00217,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00218", "SELECT DocumentosId FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00218,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00219", "SELECT ReembolsoDocumentoId FROM ReembolsoDocumento WHERE ReembolsoDocumentoId = :ReembolsoDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00219,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002110", "SELECT ReembolsoDocumentoId FROM ReembolsoDocumento WHERE ( ReembolsoDocumentoId > :ReembolsoDocumentoId) ORDER BY ReembolsoDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002110,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002111", "SELECT ReembolsoDocumentoId FROM ReembolsoDocumento WHERE ( ReembolsoDocumentoId < :ReembolsoDocumentoId) ORDER BY ReembolsoDocumentoId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002111,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002112", "SAVEPOINT gxupdate;INSERT INTO ReembolsoDocumento(ReembolsoDocumentoNome, ReembolsoDocumentoBlob, ReembolsoDocumentoBlobExt, ReembolsoDocumentoCreatedAt, ReembolsoDocumentoStatus, ReembolsoEtapaId, DocumentosId) VALUES(:ReembolsoDocumentoNome, :ReembolsoDocumentoBlob, :ReembolsoDocumentoBlobExt, :ReembolsoDocumentoCreatedAt, :ReembolsoDocumentoStatus, :ReembolsoEtapaId, :DocumentosId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002112)
             ,new CursorDef("T002113", "SELECT currval('ReembolsoDocumentoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002113,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002114", "SAVEPOINT gxupdate;UPDATE ReembolsoDocumento SET ReembolsoDocumentoNome=:ReembolsoDocumentoNome, ReembolsoDocumentoBlobExt=:ReembolsoDocumentoBlobExt, ReembolsoDocumentoCreatedAt=:ReembolsoDocumentoCreatedAt, ReembolsoDocumentoStatus=:ReembolsoDocumentoStatus, ReembolsoEtapaId=:ReembolsoEtapaId, DocumentosId=:DocumentosId  WHERE ReembolsoDocumentoId = :ReembolsoDocumentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002114)
             ,new CursorDef("T002115", "SAVEPOINT gxupdate;UPDATE ReembolsoDocumento SET ReembolsoDocumentoBlob=:ReembolsoDocumentoBlob  WHERE ReembolsoDocumentoId = :ReembolsoDocumentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002115)
             ,new CursorDef("T002116", "SAVEPOINT gxupdate;DELETE FROM ReembolsoDocumento  WHERE ReembolsoDocumentoId = :ReembolsoDocumentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002116)
             ,new CursorDef("T002117", "SELECT ReembolsoDocumentoId FROM ReembolsoDocumento ORDER BY ReembolsoDocumentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002117,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002118", "SELECT ReembolsoEtapaId FROM ReembolsoEtapa WHERE ReembolsoEtapaId = :ReembolsoEtapaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002118,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002119", "SELECT DocumentosId FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002119,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getBLOBFile(8, "tmp", "");
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getBLOBFile(8, "tmp", "");
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getBLOBFile(8, "tmp", "");
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
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
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
