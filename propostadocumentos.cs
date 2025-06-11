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
   public class propostadocumentos : GXDataArea
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
            A405DocumentosId = (int)(Math.Round(NumberUtil.Val( GetPar( "DocumentosId"), "."), 18, MidpointRounding.ToEven));
            n405DocumentosId = false;
            AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A405DocumentosId) ;
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
         Form.Meta.addItem("description", "Proposta Documentos", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPropostaDocumentosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public propostadocumentos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostadocumentos( IGxContext context )
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
         cmbDocumentosStatus = new GXCombobox();
         cmbPropostaDocumentosStatus = new GXCombobox();
         chkPropostaDocumentosAdm = new GXCheckbox();
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
         if ( cmbDocumentosStatus.ItemCount > 0 )
         {
            A407DocumentosStatus = StringUtil.StrToBool( cmbDocumentosStatus.getValidValue(StringUtil.BoolToStr( A407DocumentosStatus)));
            n407DocumentosStatus = false;
            AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDocumentosStatus.CurrentValue = StringUtil.BoolToStr( A407DocumentosStatus);
            AssignProp("", false, cmbDocumentosStatus_Internalname, "Values", cmbDocumentosStatus.ToJavascriptSource(), true);
         }
         if ( cmbPropostaDocumentosStatus.ItemCount > 0 )
         {
            A579PropostaDocumentosStatus = cmbPropostaDocumentosStatus.getValidValue(A579PropostaDocumentosStatus);
            n579PropostaDocumentosStatus = false;
            AssignAttri("", false, "A579PropostaDocumentosStatus", A579PropostaDocumentosStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPropostaDocumentosStatus.CurrentValue = StringUtil.RTrim( A579PropostaDocumentosStatus);
            AssignProp("", false, cmbPropostaDocumentosStatus_Internalname, "Values", cmbPropostaDocumentosStatus.ToJavascriptSource(), true);
         }
         A651PropostaDocumentosAdm = StringUtil.StrToBool( StringUtil.BoolToStr( A651PropostaDocumentosAdm));
         n651PropostaDocumentosAdm = false;
         AssignAttri("", false, "A651PropostaDocumentosAdm", A651PropostaDocumentosAdm);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Proposta Documentos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_PropostaDocumentos.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaDocumentos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaDocumentos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaDocumentos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaDocumentos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_PropostaDocumentos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaDocumentosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaDocumentosId_Internalname, "Documentos Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaDocumentosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A414PropostaDocumentosId), 9, 0, ",", "")), StringUtil.LTrim( ((edtPropostaDocumentosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A414PropostaDocumentosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A414PropostaDocumentosId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaDocumentosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPropostaDocumentosId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PropostaDocumentos.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPropostaId_Internalname, ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ",", ""))), ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( ((edtPropostaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A323PropostaId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPropostaId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PropostaDocumentos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentosId_Internalname, ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ",", ""))), ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( ((edtDocumentosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A405DocumentosId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A405DocumentosId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocumentosId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_PropostaDocumentos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDocumentosDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocumentosDescricao_Internalname, "Documentos Descricao", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocumentosDescricao_Internalname, A406DocumentosDescricao, StringUtil.RTrim( context.localUtil.Format( A406DocumentosDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocumentosDescricao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocumentosDescricao_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaDocumentos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbDocumentosStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbDocumentosStatus_Internalname, "Documentos Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbDocumentosStatus, cmbDocumentosStatus_Internalname, StringUtil.BoolToStr( A407DocumentosStatus), 1, cmbDocumentosStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbDocumentosStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_PropostaDocumentos.htm");
         cmbDocumentosStatus.CurrentValue = StringUtil.BoolToStr( A407DocumentosStatus);
         AssignProp("", false, cmbDocumentosStatus_Internalname, "Values", (string)(cmbDocumentosStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaDocumentosAnexo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaDocumentosAnexo_Internalname, "Documentos Anexo", "col-sm-3 ImageLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         ClassString = "Image";
         StyleString = "";
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         edtPropostaDocumentosAnexo_Filetype = "tmp";
         AssignProp("", false, edtPropostaDocumentosAnexo_Internalname, "Filetype", edtPropostaDocumentosAnexo_Filetype, true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A415PropostaDocumentosAnexo)) )
         {
            gxblobfileaux.Source = A415PropostaDocumentosAnexo;
            if ( ! gxblobfileaux.HasExtension() || ( StringUtil.StrCmp(edtPropostaDocumentosAnexo_Filetype, "tmp") != 0 ) )
            {
               gxblobfileaux.SetExtension(StringUtil.Trim( edtPropostaDocumentosAnexo_Filetype));
            }
            if ( gxblobfileaux.ErrCode == 0 )
            {
               A415PropostaDocumentosAnexo = gxblobfileaux.GetURI();
               n415PropostaDocumentosAnexo = false;
               AssignAttri("", false, "A415PropostaDocumentosAnexo", A415PropostaDocumentosAnexo);
               AssignProp("", false, edtPropostaDocumentosAnexo_Internalname, "URL", context.PathToRelativeUrl( A415PropostaDocumentosAnexo), true);
               edtPropostaDocumentosAnexo_Filetype = gxblobfileaux.GetExtension();
               AssignProp("", false, edtPropostaDocumentosAnexo_Internalname, "Filetype", edtPropostaDocumentosAnexo_Filetype, true);
            }
            AssignProp("", false, edtPropostaDocumentosAnexo_Internalname, "URL", context.PathToRelativeUrl( A415PropostaDocumentosAnexo), true);
         }
         GxWebStd.gx_blob_field( context, edtPropostaDocumentosAnexo_Internalname, StringUtil.RTrim( A415PropostaDocumentosAnexo), context.PathToRelativeUrl( A415PropostaDocumentosAnexo), (String.IsNullOrEmpty(StringUtil.RTrim( edtPropostaDocumentosAnexo_Contenttype)) ? context.GetContentType( (String.IsNullOrEmpty(StringUtil.RTrim( edtPropostaDocumentosAnexo_Filetype)) ? A415PropostaDocumentosAnexo : edtPropostaDocumentosAnexo_Filetype)) : edtPropostaDocumentosAnexo_Contenttype), false, "", edtPropostaDocumentosAnexo_Parameters, 0, edtPropostaDocumentosAnexo_Enabled, 1, "", "", 0, -1, 250, "px", 60, "px", 0, 0, 0, edtPropostaDocumentosAnexo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", StyleString, ClassString, "", "", ""+TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", "", "HLP_PropostaDocumentos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaDocumentosAnexoName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaDocumentosAnexoName_Internalname, "Anexo Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaDocumentosAnexoName_Internalname, A416PropostaDocumentosAnexoName, StringUtil.RTrim( context.localUtil.Format( A416PropostaDocumentosAnexoName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaDocumentosAnexoName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPropostaDocumentosAnexoName_Enabled, 0, "text", "", 80, "chr", 1, "row", 128, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaDocumentos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPropostaDocumentosAnexoFileType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaDocumentosAnexoFileType_Internalname, "File Type", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaDocumentosAnexoFileType_Internalname, A417PropostaDocumentosAnexoFileType, StringUtil.RTrim( context.localUtil.Format( A417PropostaDocumentosAnexoFileType, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaDocumentosAnexoFileType_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPropostaDocumentosAnexoFileType_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaDocumentos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbPropostaDocumentosStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbPropostaDocumentosStatus_Internalname, "Documentos Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbPropostaDocumentosStatus, cmbPropostaDocumentosStatus_Internalname, StringUtil.RTrim( A579PropostaDocumentosStatus), 1, cmbPropostaDocumentosStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbPropostaDocumentosStatus.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_PropostaDocumentos.htm");
         cmbPropostaDocumentosStatus.CurrentValue = StringUtil.RTrim( A579PropostaDocumentosStatus);
         AssignProp("", false, cmbPropostaDocumentosStatus_Internalname, "Values", (string)(cmbPropostaDocumentosStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkPropostaDocumentosAdm_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkPropostaDocumentosAdm_Internalname, "Documentos Adm", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkPropostaDocumentosAdm_Internalname, StringUtil.BoolToStr( A651PropostaDocumentosAdm), "", "Documentos Adm", 1, chkPropostaDocumentosAdm.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,79);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaDocumentos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaDocumentos.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaDocumentos.htm");
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
            Z414PropostaDocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z414PropostaDocumentosId"), ",", "."), 18, MidpointRounding.ToEven));
            Z416PropostaDocumentosAnexoName = cgiGet( "Z416PropostaDocumentosAnexoName");
            n416PropostaDocumentosAnexoName = (String.IsNullOrEmpty(StringUtil.RTrim( A416PropostaDocumentosAnexoName)) ? true : false);
            Z417PropostaDocumentosAnexoFileType = cgiGet( "Z417PropostaDocumentosAnexoFileType");
            n417PropostaDocumentosAnexoFileType = (String.IsNullOrEmpty(StringUtil.RTrim( A417PropostaDocumentosAnexoFileType)) ? true : false);
            Z579PropostaDocumentosStatus = cgiGet( "Z579PropostaDocumentosStatus");
            n579PropostaDocumentosStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A579PropostaDocumentosStatus)) ? true : false);
            Z651PropostaDocumentosAdm = StringUtil.StrToBool( cgiGet( "Z651PropostaDocumentosAdm"));
            n651PropostaDocumentosAdm = ((false==A651PropostaDocumentosAdm) ? true : false);
            Z323PropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z323PropostaId"), ",", "."), 18, MidpointRounding.ToEven));
            n323PropostaId = ((0==A323PropostaId) ? true : false);
            Z405DocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z405DocumentosId"), ",", "."), 18, MidpointRounding.ToEven));
            n405DocumentosId = ((0==A405DocumentosId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            edtPropostaDocumentosAnexo_Filename = cgiGet( "PROPOSTADOCUMENTOSANEXO_Filename");
            edtPropostaDocumentosAnexo_Filetype = cgiGet( "PROPOSTADOCUMENTOSANEXO_Filetype");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtPropostaDocumentosId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropostaDocumentosId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPOSTADOCUMENTOSID");
               AnyError = 1;
               GX_FocusControl = edtPropostaDocumentosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A414PropostaDocumentosId = 0;
               AssignAttri("", false, "A414PropostaDocumentosId", StringUtil.LTrimStr( (decimal)(A414PropostaDocumentosId), 9, 0));
            }
            else
            {
               A414PropostaDocumentosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaDocumentosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A414PropostaDocumentosId", StringUtil.LTrimStr( (decimal)(A414PropostaDocumentosId), 9, 0));
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
            A406DocumentosDescricao = cgiGet( edtDocumentosDescricao_Internalname);
            n406DocumentosDescricao = false;
            AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
            cmbDocumentosStatus.CurrentValue = cgiGet( cmbDocumentosStatus_Internalname);
            A407DocumentosStatus = StringUtil.StrToBool( cgiGet( cmbDocumentosStatus_Internalname));
            n407DocumentosStatus = false;
            AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
            A415PropostaDocumentosAnexo = cgiGet( edtPropostaDocumentosAnexo_Internalname);
            n415PropostaDocumentosAnexo = false;
            AssignAttri("", false, "A415PropostaDocumentosAnexo", A415PropostaDocumentosAnexo);
            n415PropostaDocumentosAnexo = (String.IsNullOrEmpty(StringUtil.RTrim( A415PropostaDocumentosAnexo)) ? true : false);
            A416PropostaDocumentosAnexoName = cgiGet( edtPropostaDocumentosAnexoName_Internalname);
            n416PropostaDocumentosAnexoName = false;
            AssignAttri("", false, "A416PropostaDocumentosAnexoName", A416PropostaDocumentosAnexoName);
            n416PropostaDocumentosAnexoName = (String.IsNullOrEmpty(StringUtil.RTrim( A416PropostaDocumentosAnexoName)) ? true : false);
            A417PropostaDocumentosAnexoFileType = cgiGet( edtPropostaDocumentosAnexoFileType_Internalname);
            n417PropostaDocumentosAnexoFileType = false;
            AssignAttri("", false, "A417PropostaDocumentosAnexoFileType", A417PropostaDocumentosAnexoFileType);
            n417PropostaDocumentosAnexoFileType = (String.IsNullOrEmpty(StringUtil.RTrim( A417PropostaDocumentosAnexoFileType)) ? true : false);
            cmbPropostaDocumentosStatus.CurrentValue = cgiGet( cmbPropostaDocumentosStatus_Internalname);
            A579PropostaDocumentosStatus = cgiGet( cmbPropostaDocumentosStatus_Internalname);
            n579PropostaDocumentosStatus = false;
            AssignAttri("", false, "A579PropostaDocumentosStatus", A579PropostaDocumentosStatus);
            n579PropostaDocumentosStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A579PropostaDocumentosStatus)) ? true : false);
            A651PropostaDocumentosAdm = StringUtil.StrToBool( cgiGet( chkPropostaDocumentosAdm_Internalname));
            n651PropostaDocumentosAdm = false;
            AssignAttri("", false, "A651PropostaDocumentosAdm", A651PropostaDocumentosAdm);
            n651PropostaDocumentosAdm = ((false==A651PropostaDocumentosAdm) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A415PropostaDocumentosAnexo)) )
            {
               edtPropostaDocumentosAnexo_Filename = (string)(CGIGetFileName(edtPropostaDocumentosAnexo_Internalname));
               edtPropostaDocumentosAnexo_Filetype = (string)(CGIGetFileType(edtPropostaDocumentosAnexo_Internalname));
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A415PropostaDocumentosAnexo)) )
            {
               GXCCtlgxBlob = "PROPOSTADOCUMENTOSANEXO" + "_gxBlob";
               A415PropostaDocumentosAnexo = cgiGet( GXCCtlgxBlob);
               n415PropostaDocumentosAnexo = false;
               n415PropostaDocumentosAnexo = (String.IsNullOrEmpty(StringUtil.RTrim( A415PropostaDocumentosAnexo)) ? true : false);
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
               A414PropostaDocumentosId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaDocumentosId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A414PropostaDocumentosId", StringUtil.LTrimStr( (decimal)(A414PropostaDocumentosId), 9, 0));
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
               InitAll1O62( ) ;
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
         DisableAttributes1O62( ) ;
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

      protected void ResetCaption1O0( )
      {
      }

      protected void ZM1O62( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z416PropostaDocumentosAnexoName = T001O3_A416PropostaDocumentosAnexoName[0];
               Z417PropostaDocumentosAnexoFileType = T001O3_A417PropostaDocumentosAnexoFileType[0];
               Z579PropostaDocumentosStatus = T001O3_A579PropostaDocumentosStatus[0];
               Z651PropostaDocumentosAdm = T001O3_A651PropostaDocumentosAdm[0];
               Z323PropostaId = T001O3_A323PropostaId[0];
               Z405DocumentosId = T001O3_A405DocumentosId[0];
            }
            else
            {
               Z416PropostaDocumentosAnexoName = A416PropostaDocumentosAnexoName;
               Z417PropostaDocumentosAnexoFileType = A417PropostaDocumentosAnexoFileType;
               Z579PropostaDocumentosStatus = A579PropostaDocumentosStatus;
               Z651PropostaDocumentosAdm = A651PropostaDocumentosAdm;
               Z323PropostaId = A323PropostaId;
               Z405DocumentosId = A405DocumentosId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z414PropostaDocumentosId = A414PropostaDocumentosId;
            Z415PropostaDocumentosAnexo = A415PropostaDocumentosAnexo;
            Z416PropostaDocumentosAnexoName = A416PropostaDocumentosAnexoName;
            Z417PropostaDocumentosAnexoFileType = A417PropostaDocumentosAnexoFileType;
            Z579PropostaDocumentosStatus = A579PropostaDocumentosStatus;
            Z651PropostaDocumentosAdm = A651PropostaDocumentosAdm;
            Z323PropostaId = A323PropostaId;
            Z405DocumentosId = A405DocumentosId;
            Z406DocumentosDescricao = A406DocumentosDescricao;
            Z407DocumentosStatus = A407DocumentosStatus;
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

      protected void Load1O62( )
      {
         /* Using cursor T001O6 */
         pr_default.execute(4, new Object[] {A414PropostaDocumentosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound62 = 1;
            A406DocumentosDescricao = T001O6_A406DocumentosDescricao[0];
            n406DocumentosDescricao = T001O6_n406DocumentosDescricao[0];
            AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
            A407DocumentosStatus = T001O6_A407DocumentosStatus[0];
            n407DocumentosStatus = T001O6_n407DocumentosStatus[0];
            AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
            A416PropostaDocumentosAnexoName = T001O6_A416PropostaDocumentosAnexoName[0];
            n416PropostaDocumentosAnexoName = T001O6_n416PropostaDocumentosAnexoName[0];
            AssignAttri("", false, "A416PropostaDocumentosAnexoName", A416PropostaDocumentosAnexoName);
            A417PropostaDocumentosAnexoFileType = T001O6_A417PropostaDocumentosAnexoFileType[0];
            n417PropostaDocumentosAnexoFileType = T001O6_n417PropostaDocumentosAnexoFileType[0];
            AssignAttri("", false, "A417PropostaDocumentosAnexoFileType", A417PropostaDocumentosAnexoFileType);
            A579PropostaDocumentosStatus = T001O6_A579PropostaDocumentosStatus[0];
            n579PropostaDocumentosStatus = T001O6_n579PropostaDocumentosStatus[0];
            AssignAttri("", false, "A579PropostaDocumentosStatus", A579PropostaDocumentosStatus);
            A651PropostaDocumentosAdm = T001O6_A651PropostaDocumentosAdm[0];
            n651PropostaDocumentosAdm = T001O6_n651PropostaDocumentosAdm[0];
            AssignAttri("", false, "A651PropostaDocumentosAdm", A651PropostaDocumentosAdm);
            A323PropostaId = T001O6_A323PropostaId[0];
            n323PropostaId = T001O6_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            A405DocumentosId = T001O6_A405DocumentosId[0];
            n405DocumentosId = T001O6_n405DocumentosId[0];
            AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
            A415PropostaDocumentosAnexo = T001O6_A415PropostaDocumentosAnexo[0];
            n415PropostaDocumentosAnexo = T001O6_n415PropostaDocumentosAnexo[0];
            AssignAttri("", false, "A415PropostaDocumentosAnexo", A415PropostaDocumentosAnexo);
            AssignProp("", false, edtPropostaDocumentosAnexo_Internalname, "URL", context.PathToRelativeUrl( A415PropostaDocumentosAnexo), true);
            ZM1O62( -2) ;
         }
         pr_default.close(4);
         OnLoadActions1O62( ) ;
      }

      protected void OnLoadActions1O62( )
      {
      }

      protected void CheckExtendedTable1O62( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001O4 */
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
         /* Using cursor T001O5 */
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
         A406DocumentosDescricao = T001O5_A406DocumentosDescricao[0];
         n406DocumentosDescricao = T001O5_n406DocumentosDescricao[0];
         AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
         A407DocumentosStatus = T001O5_A407DocumentosStatus[0];
         n407DocumentosStatus = T001O5_n407DocumentosStatus[0];
         AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A579PropostaDocumentosStatus, "AGUARDANDO_ANALISE") == 0 ) || ( StringUtil.StrCmp(A579PropostaDocumentosStatus, "APROVADO") == 0 ) || ( StringUtil.StrCmp(A579PropostaDocumentosStatus, "REPROVADO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A579PropostaDocumentosStatus)) ) )
         {
            GX_msglist.addItem("Campo Proposta Documentos Status fora do intervalo", "OutOfRange", 1, "PROPOSTADOCUMENTOSSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbPropostaDocumentosStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1O62( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A323PropostaId )
      {
         /* Using cursor T001O7 */
         pr_default.execute(5, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(5) == 101) )
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
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_4( int A405DocumentosId )
      {
         /* Using cursor T001O8 */
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
         A406DocumentosDescricao = T001O8_A406DocumentosDescricao[0];
         n406DocumentosDescricao = T001O8_n406DocumentosDescricao[0];
         AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
         A407DocumentosStatus = T001O8_A407DocumentosStatus[0];
         n407DocumentosStatus = T001O8_n407DocumentosStatus[0];
         AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A406DocumentosDescricao)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A407DocumentosStatus))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1O62( )
      {
         /* Using cursor T001O9 */
         pr_default.execute(7, new Object[] {A414PropostaDocumentosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound62 = 1;
         }
         else
         {
            RcdFound62 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001O3 */
         pr_default.execute(1, new Object[] {A414PropostaDocumentosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1O62( 2) ;
            RcdFound62 = 1;
            A414PropostaDocumentosId = T001O3_A414PropostaDocumentosId[0];
            AssignAttri("", false, "A414PropostaDocumentosId", StringUtil.LTrimStr( (decimal)(A414PropostaDocumentosId), 9, 0));
            A416PropostaDocumentosAnexoName = T001O3_A416PropostaDocumentosAnexoName[0];
            n416PropostaDocumentosAnexoName = T001O3_n416PropostaDocumentosAnexoName[0];
            AssignAttri("", false, "A416PropostaDocumentosAnexoName", A416PropostaDocumentosAnexoName);
            A417PropostaDocumentosAnexoFileType = T001O3_A417PropostaDocumentosAnexoFileType[0];
            n417PropostaDocumentosAnexoFileType = T001O3_n417PropostaDocumentosAnexoFileType[0];
            AssignAttri("", false, "A417PropostaDocumentosAnexoFileType", A417PropostaDocumentosAnexoFileType);
            A579PropostaDocumentosStatus = T001O3_A579PropostaDocumentosStatus[0];
            n579PropostaDocumentosStatus = T001O3_n579PropostaDocumentosStatus[0];
            AssignAttri("", false, "A579PropostaDocumentosStatus", A579PropostaDocumentosStatus);
            A651PropostaDocumentosAdm = T001O3_A651PropostaDocumentosAdm[0];
            n651PropostaDocumentosAdm = T001O3_n651PropostaDocumentosAdm[0];
            AssignAttri("", false, "A651PropostaDocumentosAdm", A651PropostaDocumentosAdm);
            A323PropostaId = T001O3_A323PropostaId[0];
            n323PropostaId = T001O3_n323PropostaId[0];
            AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
            A405DocumentosId = T001O3_A405DocumentosId[0];
            n405DocumentosId = T001O3_n405DocumentosId[0];
            AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
            A415PropostaDocumentosAnexo = T001O3_A415PropostaDocumentosAnexo[0];
            n415PropostaDocumentosAnexo = T001O3_n415PropostaDocumentosAnexo[0];
            AssignAttri("", false, "A415PropostaDocumentosAnexo", A415PropostaDocumentosAnexo);
            AssignProp("", false, edtPropostaDocumentosAnexo_Internalname, "URL", context.PathToRelativeUrl( A415PropostaDocumentosAnexo), true);
            Z414PropostaDocumentosId = A414PropostaDocumentosId;
            sMode62 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1O62( ) ;
            if ( AnyError == 1 )
            {
               RcdFound62 = 0;
               InitializeNonKey1O62( ) ;
            }
            Gx_mode = sMode62;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound62 = 0;
            InitializeNonKey1O62( ) ;
            sMode62 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode62;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1O62( ) ;
         if ( RcdFound62 == 0 )
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
         RcdFound62 = 0;
         /* Using cursor T001O10 */
         pr_default.execute(8, new Object[] {A414PropostaDocumentosId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001O10_A414PropostaDocumentosId[0] < A414PropostaDocumentosId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001O10_A414PropostaDocumentosId[0] > A414PropostaDocumentosId ) ) )
            {
               A414PropostaDocumentosId = T001O10_A414PropostaDocumentosId[0];
               AssignAttri("", false, "A414PropostaDocumentosId", StringUtil.LTrimStr( (decimal)(A414PropostaDocumentosId), 9, 0));
               RcdFound62 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound62 = 0;
         /* Using cursor T001O11 */
         pr_default.execute(9, new Object[] {A414PropostaDocumentosId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001O11_A414PropostaDocumentosId[0] > A414PropostaDocumentosId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001O11_A414PropostaDocumentosId[0] < A414PropostaDocumentosId ) ) )
            {
               A414PropostaDocumentosId = T001O11_A414PropostaDocumentosId[0];
               AssignAttri("", false, "A414PropostaDocumentosId", StringUtil.LTrimStr( (decimal)(A414PropostaDocumentosId), 9, 0));
               RcdFound62 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1O62( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPropostaDocumentosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1O62( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound62 == 1 )
            {
               if ( A414PropostaDocumentosId != Z414PropostaDocumentosId )
               {
                  A414PropostaDocumentosId = Z414PropostaDocumentosId;
                  AssignAttri("", false, "A414PropostaDocumentosId", StringUtil.LTrimStr( (decimal)(A414PropostaDocumentosId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROPOSTADOCUMENTOSID");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaDocumentosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPropostaDocumentosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1O62( ) ;
                  GX_FocusControl = edtPropostaDocumentosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A414PropostaDocumentosId != Z414PropostaDocumentosId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPropostaDocumentosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1O62( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROPOSTADOCUMENTOSID");
                     AnyError = 1;
                     GX_FocusControl = edtPropostaDocumentosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPropostaDocumentosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1O62( ) ;
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
         if ( A414PropostaDocumentosId != Z414PropostaDocumentosId )
         {
            A414PropostaDocumentosId = Z414PropostaDocumentosId;
            AssignAttri("", false, "A414PropostaDocumentosId", StringUtil.LTrimStr( (decimal)(A414PropostaDocumentosId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROPOSTADOCUMENTOSID");
            AnyError = 1;
            GX_FocusControl = edtPropostaDocumentosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPropostaDocumentosId_Internalname;
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
         if ( RcdFound62 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROPOSTADOCUMENTOSID");
            AnyError = 1;
            GX_FocusControl = edtPropostaDocumentosId_Internalname;
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
         ScanStart1O62( ) ;
         if ( RcdFound62 == 0 )
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
         ScanEnd1O62( ) ;
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
         if ( RcdFound62 == 0 )
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
         if ( RcdFound62 == 0 )
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
         ScanStart1O62( ) ;
         if ( RcdFound62 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound62 != 0 )
            {
               ScanNext1O62( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPropostaId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1O62( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1O62( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001O2 */
            pr_default.execute(0, new Object[] {A414PropostaDocumentosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PropostaDocumentos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z416PropostaDocumentosAnexoName, T001O2_A416PropostaDocumentosAnexoName[0]) != 0 ) || ( StringUtil.StrCmp(Z417PropostaDocumentosAnexoFileType, T001O2_A417PropostaDocumentosAnexoFileType[0]) != 0 ) || ( StringUtil.StrCmp(Z579PropostaDocumentosStatus, T001O2_A579PropostaDocumentosStatus[0]) != 0 ) || ( Z651PropostaDocumentosAdm != T001O2_A651PropostaDocumentosAdm[0] ) || ( Z323PropostaId != T001O2_A323PropostaId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z405DocumentosId != T001O2_A405DocumentosId[0] ) )
            {
               if ( StringUtil.StrCmp(Z416PropostaDocumentosAnexoName, T001O2_A416PropostaDocumentosAnexoName[0]) != 0 )
               {
                  GXUtil.WriteLog("propostadocumentos:[seudo value changed for attri]"+"PropostaDocumentosAnexoName");
                  GXUtil.WriteLogRaw("Old: ",Z416PropostaDocumentosAnexoName);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A416PropostaDocumentosAnexoName[0]);
               }
               if ( StringUtil.StrCmp(Z417PropostaDocumentosAnexoFileType, T001O2_A417PropostaDocumentosAnexoFileType[0]) != 0 )
               {
                  GXUtil.WriteLog("propostadocumentos:[seudo value changed for attri]"+"PropostaDocumentosAnexoFileType");
                  GXUtil.WriteLogRaw("Old: ",Z417PropostaDocumentosAnexoFileType);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A417PropostaDocumentosAnexoFileType[0]);
               }
               if ( StringUtil.StrCmp(Z579PropostaDocumentosStatus, T001O2_A579PropostaDocumentosStatus[0]) != 0 )
               {
                  GXUtil.WriteLog("propostadocumentos:[seudo value changed for attri]"+"PropostaDocumentosStatus");
                  GXUtil.WriteLogRaw("Old: ",Z579PropostaDocumentosStatus);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A579PropostaDocumentosStatus[0]);
               }
               if ( Z651PropostaDocumentosAdm != T001O2_A651PropostaDocumentosAdm[0] )
               {
                  GXUtil.WriteLog("propostadocumentos:[seudo value changed for attri]"+"PropostaDocumentosAdm");
                  GXUtil.WriteLogRaw("Old: ",Z651PropostaDocumentosAdm);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A651PropostaDocumentosAdm[0]);
               }
               if ( Z323PropostaId != T001O2_A323PropostaId[0] )
               {
                  GXUtil.WriteLog("propostadocumentos:[seudo value changed for attri]"+"PropostaId");
                  GXUtil.WriteLogRaw("Old: ",Z323PropostaId);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A323PropostaId[0]);
               }
               if ( Z405DocumentosId != T001O2_A405DocumentosId[0] )
               {
                  GXUtil.WriteLog("propostadocumentos:[seudo value changed for attri]"+"DocumentosId");
                  GXUtil.WriteLogRaw("Old: ",Z405DocumentosId);
                  GXUtil.WriteLogRaw("Current: ",T001O2_A405DocumentosId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PropostaDocumentos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1O62( )
      {
         BeforeValidate1O62( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1O62( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1O62( 0) ;
            CheckOptimisticConcurrency1O62( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1O62( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1O62( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001O12 */
                     pr_default.execute(10, new Object[] {n415PropostaDocumentosAnexo, A415PropostaDocumentosAnexo, n416PropostaDocumentosAnexoName, A416PropostaDocumentosAnexoName, n417PropostaDocumentosAnexoFileType, A417PropostaDocumentosAnexoFileType, n579PropostaDocumentosStatus, A579PropostaDocumentosStatus, n651PropostaDocumentosAdm, A651PropostaDocumentosAdm, n323PropostaId, A323PropostaId, n405DocumentosId, A405DocumentosId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001O13 */
                     pr_default.execute(11);
                     A414PropostaDocumentosId = T001O13_A414PropostaDocumentosId[0];
                     AssignAttri("", false, "A414PropostaDocumentosId", StringUtil.LTrimStr( (decimal)(A414PropostaDocumentosId), 9, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("PropostaDocumentos");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption1O0( ) ;
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
               Load1O62( ) ;
            }
            EndLevel1O62( ) ;
         }
         CloseExtendedTableCursors1O62( ) ;
      }

      protected void Update1O62( )
      {
         BeforeValidate1O62( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1O62( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1O62( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1O62( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1O62( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001O14 */
                     pr_default.execute(12, new Object[] {n416PropostaDocumentosAnexoName, A416PropostaDocumentosAnexoName, n417PropostaDocumentosAnexoFileType, A417PropostaDocumentosAnexoFileType, n579PropostaDocumentosStatus, A579PropostaDocumentosStatus, n651PropostaDocumentosAdm, A651PropostaDocumentosAdm, n323PropostaId, A323PropostaId, n405DocumentosId, A405DocumentosId, A414PropostaDocumentosId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("PropostaDocumentos");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PropostaDocumentos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1O62( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1O0( ) ;
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
            EndLevel1O62( ) ;
         }
         CloseExtendedTableCursors1O62( ) ;
      }

      protected void DeferredUpdate1O62( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001O15 */
            pr_default.execute(13, new Object[] {n415PropostaDocumentosAnexo, A415PropostaDocumentosAnexo, A414PropostaDocumentosId});
            pr_default.close(13);
            pr_default.SmartCacheProvider.SetUpdated("PropostaDocumentos");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1O62( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1O62( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1O62( ) ;
            AfterConfirm1O62( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1O62( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001O16 */
                  pr_default.execute(14, new Object[] {A414PropostaDocumentosId});
                  pr_default.close(14);
                  pr_default.SmartCacheProvider.SetUpdated("PropostaDocumentos");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound62 == 0 )
                        {
                           InitAll1O62( ) ;
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
                        ResetCaption1O0( ) ;
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
         sMode62 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1O62( ) ;
         Gx_mode = sMode62;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1O62( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001O17 */
            pr_default.execute(15, new Object[] {n405DocumentosId, A405DocumentosId});
            A406DocumentosDescricao = T001O17_A406DocumentosDescricao[0];
            n406DocumentosDescricao = T001O17_n406DocumentosDescricao[0];
            AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
            A407DocumentosStatus = T001O17_A407DocumentosStatus[0];
            n407DocumentosStatus = T001O17_n407DocumentosStatus[0];
            AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
            pr_default.close(15);
         }
      }

      protected void EndLevel1O62( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1O62( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues1O0( ) ;
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

      public void ScanStart1O62( )
      {
         /* Using cursor T001O18 */
         pr_default.execute(16);
         RcdFound62 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound62 = 1;
            A414PropostaDocumentosId = T001O18_A414PropostaDocumentosId[0];
            AssignAttri("", false, "A414PropostaDocumentosId", StringUtil.LTrimStr( (decimal)(A414PropostaDocumentosId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1O62( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound62 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound62 = 1;
            A414PropostaDocumentosId = T001O18_A414PropostaDocumentosId[0];
            AssignAttri("", false, "A414PropostaDocumentosId", StringUtil.LTrimStr( (decimal)(A414PropostaDocumentosId), 9, 0));
         }
      }

      protected void ScanEnd1O62( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm1O62( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1O62( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1O62( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1O62( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1O62( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1O62( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1O62( )
      {
         edtPropostaDocumentosId_Enabled = 0;
         AssignProp("", false, edtPropostaDocumentosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaDocumentosId_Enabled), 5, 0), true);
         edtPropostaId_Enabled = 0;
         AssignProp("", false, edtPropostaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaId_Enabled), 5, 0), true);
         edtDocumentosId_Enabled = 0;
         AssignProp("", false, edtDocumentosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentosId_Enabled), 5, 0), true);
         edtDocumentosDescricao_Enabled = 0;
         AssignProp("", false, edtDocumentosDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocumentosDescricao_Enabled), 5, 0), true);
         cmbDocumentosStatus.Enabled = 0;
         AssignProp("", false, cmbDocumentosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbDocumentosStatus.Enabled), 5, 0), true);
         edtPropostaDocumentosAnexo_Enabled = 0;
         AssignProp("", false, edtPropostaDocumentosAnexo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaDocumentosAnexo_Enabled), 5, 0), true);
         edtPropostaDocumentosAnexoName_Enabled = 0;
         AssignProp("", false, edtPropostaDocumentosAnexoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaDocumentosAnexoName_Enabled), 5, 0), true);
         edtPropostaDocumentosAnexoFileType_Enabled = 0;
         AssignProp("", false, edtPropostaDocumentosAnexoFileType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaDocumentosAnexoFileType_Enabled), 5, 0), true);
         cmbPropostaDocumentosStatus.Enabled = 0;
         AssignProp("", false, cmbPropostaDocumentosStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbPropostaDocumentosStatus.Enabled), 5, 0), true);
         chkPropostaDocumentosAdm.Enabled = 0;
         AssignProp("", false, chkPropostaDocumentosAdm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkPropostaDocumentosAdm.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1O62( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1O0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("propostadocumentos") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z414PropostaDocumentosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z414PropostaDocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z416PropostaDocumentosAnexoName", Z416PropostaDocumentosAnexoName);
         GxWebStd.gx_hidden_field( context, "Z417PropostaDocumentosAnexoFileType", Z417PropostaDocumentosAnexoFileType);
         GxWebStd.gx_hidden_field( context, "Z579PropostaDocumentosStatus", Z579PropostaDocumentosStatus);
         GxWebStd.gx_boolean_hidden_field( context, "Z651PropostaDocumentosAdm", Z651PropostaDocumentosAdm);
         GxWebStd.gx_hidden_field( context, "Z323PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z323PropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z405DocumentosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z405DocumentosId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GXCCtlgxBlob = "PROPOSTADOCUMENTOSANEXO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A415PropostaDocumentosAnexo);
         GxWebStd.gx_hidden_field( context, "PROPOSTADOCUMENTOSANEXO_Filename", StringUtil.RTrim( edtPropostaDocumentosAnexo_Filename));
         GxWebStd.gx_hidden_field( context, "PROPOSTADOCUMENTOSANEXO_Filetype", StringUtil.RTrim( edtPropostaDocumentosAnexo_Filetype));
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
         return formatLink("propostadocumentos")  ;
      }

      public override string GetPgmname( )
      {
         return "PropostaDocumentos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Proposta Documentos" ;
      }

      protected void InitializeNonKey1O62( )
      {
         A323PropostaId = 0;
         n323PropostaId = false;
         AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
         n323PropostaId = ((0==A323PropostaId) ? true : false);
         A405DocumentosId = 0;
         n405DocumentosId = false;
         AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
         n405DocumentosId = ((0==A405DocumentosId) ? true : false);
         A406DocumentosDescricao = "";
         n406DocumentosDescricao = false;
         AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
         A407DocumentosStatus = false;
         n407DocumentosStatus = false;
         AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
         A415PropostaDocumentosAnexo = "";
         n415PropostaDocumentosAnexo = false;
         AssignAttri("", false, "A415PropostaDocumentosAnexo", A415PropostaDocumentosAnexo);
         AssignProp("", false, edtPropostaDocumentosAnexo_Internalname, "URL", context.PathToRelativeUrl( A415PropostaDocumentosAnexo), true);
         n415PropostaDocumentosAnexo = (String.IsNullOrEmpty(StringUtil.RTrim( A415PropostaDocumentosAnexo)) ? true : false);
         A416PropostaDocumentosAnexoName = "";
         n416PropostaDocumentosAnexoName = false;
         AssignAttri("", false, "A416PropostaDocumentosAnexoName", A416PropostaDocumentosAnexoName);
         n416PropostaDocumentosAnexoName = (String.IsNullOrEmpty(StringUtil.RTrim( A416PropostaDocumentosAnexoName)) ? true : false);
         A417PropostaDocumentosAnexoFileType = "";
         n417PropostaDocumentosAnexoFileType = false;
         AssignAttri("", false, "A417PropostaDocumentosAnexoFileType", A417PropostaDocumentosAnexoFileType);
         n417PropostaDocumentosAnexoFileType = (String.IsNullOrEmpty(StringUtil.RTrim( A417PropostaDocumentosAnexoFileType)) ? true : false);
         A579PropostaDocumentosStatus = "";
         n579PropostaDocumentosStatus = false;
         AssignAttri("", false, "A579PropostaDocumentosStatus", A579PropostaDocumentosStatus);
         n579PropostaDocumentosStatus = (String.IsNullOrEmpty(StringUtil.RTrim( A579PropostaDocumentosStatus)) ? true : false);
         A651PropostaDocumentosAdm = false;
         n651PropostaDocumentosAdm = false;
         AssignAttri("", false, "A651PropostaDocumentosAdm", A651PropostaDocumentosAdm);
         n651PropostaDocumentosAdm = ((false==A651PropostaDocumentosAdm) ? true : false);
         Z416PropostaDocumentosAnexoName = "";
         Z417PropostaDocumentosAnexoFileType = "";
         Z579PropostaDocumentosStatus = "";
         Z651PropostaDocumentosAdm = false;
         Z323PropostaId = 0;
         Z405DocumentosId = 0;
      }

      protected void InitAll1O62( )
      {
         A414PropostaDocumentosId = 0;
         AssignAttri("", false, "A414PropostaDocumentosId", StringUtil.LTrimStr( (decimal)(A414PropostaDocumentosId), 9, 0));
         InitializeNonKey1O62( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019164923", true, true);
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
         context.AddJavascriptSource("propostadocumentos.js", "?202561019164923", false, true);
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
         edtPropostaDocumentosId_Internalname = "PROPOSTADOCUMENTOSID";
         edtPropostaId_Internalname = "PROPOSTAID";
         edtDocumentosId_Internalname = "DOCUMENTOSID";
         edtDocumentosDescricao_Internalname = "DOCUMENTOSDESCRICAO";
         cmbDocumentosStatus_Internalname = "DOCUMENTOSSTATUS";
         edtPropostaDocumentosAnexo_Internalname = "PROPOSTADOCUMENTOSANEXO";
         edtPropostaDocumentosAnexoName_Internalname = "PROPOSTADOCUMENTOSANEXONAME";
         edtPropostaDocumentosAnexoFileType_Internalname = "PROPOSTADOCUMENTOSANEXOFILETYPE";
         cmbPropostaDocumentosStatus_Internalname = "PROPOSTADOCUMENTOSSTATUS";
         chkPropostaDocumentosAdm_Internalname = "PROPOSTADOCUMENTOSADM";
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
         edtPropostaDocumentosAnexo_Filename = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Proposta Documentos";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkPropostaDocumentosAdm.Enabled = 1;
         cmbPropostaDocumentosStatus_Jsonclick = "";
         cmbPropostaDocumentosStatus.Enabled = 1;
         edtPropostaDocumentosAnexoFileType_Jsonclick = "";
         edtPropostaDocumentosAnexoFileType_Enabled = 1;
         edtPropostaDocumentosAnexoName_Jsonclick = "";
         edtPropostaDocumentosAnexoName_Enabled = 1;
         edtPropostaDocumentosAnexo_Jsonclick = "";
         edtPropostaDocumentosAnexo_Parameters = "";
         edtPropostaDocumentosAnexo_Contenttype = "";
         edtPropostaDocumentosAnexo_Filetype = "";
         edtPropostaDocumentosAnexo_Enabled = 1;
         cmbDocumentosStatus_Jsonclick = "";
         cmbDocumentosStatus.Enabled = 0;
         edtDocumentosDescricao_Jsonclick = "";
         edtDocumentosDescricao_Enabled = 0;
         edtDocumentosId_Jsonclick = "";
         edtDocumentosId_Enabled = 1;
         edtPropostaId_Jsonclick = "";
         edtPropostaId_Enabled = 1;
         edtPropostaDocumentosId_Jsonclick = "";
         edtPropostaDocumentosId_Enabled = 1;
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
         cmbDocumentosStatus.Name = "DOCUMENTOSSTATUS";
         cmbDocumentosStatus.WebTags = "";
         cmbDocumentosStatus.addItem(StringUtil.BoolToStr( true), "Ativo", 0);
         cmbDocumentosStatus.addItem(StringUtil.BoolToStr( false), "Inativo", 0);
         if ( cmbDocumentosStatus.ItemCount > 0 )
         {
            A407DocumentosStatus = StringUtil.StrToBool( cmbDocumentosStatus.getValidValue(StringUtil.BoolToStr( A407DocumentosStatus)));
            n407DocumentosStatus = false;
            AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
         }
         cmbPropostaDocumentosStatus.Name = "PROPOSTADOCUMENTOSSTATUS";
         cmbPropostaDocumentosStatus.WebTags = "";
         cmbPropostaDocumentosStatus.addItem("AGUARDANDO_ANALISE", "Aguardando análise", 0);
         cmbPropostaDocumentosStatus.addItem("APROVADO", "Aprovado", 0);
         cmbPropostaDocumentosStatus.addItem("REPROVADO", "Reprovado", 0);
         if ( cmbPropostaDocumentosStatus.ItemCount > 0 )
         {
            A579PropostaDocumentosStatus = cmbPropostaDocumentosStatus.getValidValue(A579PropostaDocumentosStatus);
            n579PropostaDocumentosStatus = false;
            AssignAttri("", false, "A579PropostaDocumentosStatus", A579PropostaDocumentosStatus);
         }
         chkPropostaDocumentosAdm.Name = "PROPOSTADOCUMENTOSADM";
         chkPropostaDocumentosAdm.WebTags = "";
         chkPropostaDocumentosAdm.Caption = "Documentos Adm";
         AssignProp("", false, chkPropostaDocumentosAdm_Internalname, "TitleCaption", chkPropostaDocumentosAdm.Caption, true);
         chkPropostaDocumentosAdm.CheckedValue = "false";
         A651PropostaDocumentosAdm = StringUtil.StrToBool( StringUtil.BoolToStr( A651PropostaDocumentosAdm));
         n651PropostaDocumentosAdm = false;
         AssignAttri("", false, "A651PropostaDocumentosAdm", A651PropostaDocumentosAdm);
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

      public void Valid_Propostadocumentosid( )
      {
         n407DocumentosStatus = false;
         A407DocumentosStatus = StringUtil.StrToBool( cmbDocumentosStatus.CurrentValue);
         n407DocumentosStatus = false;
         cmbDocumentosStatus.CurrentValue = StringUtil.BoolToStr( A407DocumentosStatus);
         n579PropostaDocumentosStatus = false;
         A579PropostaDocumentosStatus = cmbPropostaDocumentosStatus.CurrentValue;
         n579PropostaDocumentosStatus = false;
         cmbPropostaDocumentosStatus.CurrentValue = A579PropostaDocumentosStatus;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbPropostaDocumentosStatus.ItemCount > 0 )
         {
            A579PropostaDocumentosStatus = cmbPropostaDocumentosStatus.getValidValue(A579PropostaDocumentosStatus);
            n579PropostaDocumentosStatus = false;
            cmbPropostaDocumentosStatus.CurrentValue = A579PropostaDocumentosStatus;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbPropostaDocumentosStatus.CurrentValue = StringUtil.RTrim( A579PropostaDocumentosStatus);
         }
         A651PropostaDocumentosAdm = StringUtil.StrToBool( StringUtil.BoolToStr( A651PropostaDocumentosAdm));
         n651PropostaDocumentosAdm = false;
         if ( cmbDocumentosStatus.ItemCount > 0 )
         {
            A407DocumentosStatus = StringUtil.StrToBool( cmbDocumentosStatus.getValidValue(StringUtil.BoolToStr( A407DocumentosStatus)));
            n407DocumentosStatus = false;
            cmbDocumentosStatus.CurrentValue = StringUtil.BoolToStr( A407DocumentosStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDocumentosStatus.CurrentValue = StringUtil.BoolToStr( A407DocumentosStatus);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A323PropostaId", ((0==A323PropostaId)&&IsIns( )||n323PropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A323PropostaId), 9, 0, ".", ""))));
         AssignAttri("", false, "A405DocumentosId", ((0==A405DocumentosId)&&IsIns( )||n405DocumentosId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A405DocumentosId), 9, 0, ".", ""))));
         AssignAttri("", false, "A415PropostaDocumentosAnexo", context.PathToRelativeUrl( A415PropostaDocumentosAnexo));
         AssignAttri("", false, "A416PropostaDocumentosAnexoName", A416PropostaDocumentosAnexoName);
         AssignAttri("", false, "A417PropostaDocumentosAnexoFileType", A417PropostaDocumentosAnexoFileType);
         AssignAttri("", false, "A579PropostaDocumentosStatus", A579PropostaDocumentosStatus);
         cmbPropostaDocumentosStatus.CurrentValue = StringUtil.RTrim( A579PropostaDocumentosStatus);
         AssignProp("", false, cmbPropostaDocumentosStatus_Internalname, "Values", cmbPropostaDocumentosStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A651PropostaDocumentosAdm", A651PropostaDocumentosAdm);
         AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
         AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
         cmbDocumentosStatus.CurrentValue = StringUtil.BoolToStr( A407DocumentosStatus);
         AssignProp("", false, cmbDocumentosStatus_Internalname, "Values", cmbDocumentosStatus.ToJavascriptSource(), true);
         AssignProp("", false, edtPropostaDocumentosAnexo_Internalname, "Filetype", edtPropostaDocumentosAnexo_Filetype, true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z414PropostaDocumentosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z414PropostaDocumentosId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z323PropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z323PropostaId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z405DocumentosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z405DocumentosId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z415PropostaDocumentosAnexo", context.PathToRelativeUrl( Z415PropostaDocumentosAnexo));
         GxWebStd.gx_hidden_field( context, "Z416PropostaDocumentosAnexoName", Z416PropostaDocumentosAnexoName);
         GxWebStd.gx_hidden_field( context, "Z417PropostaDocumentosAnexoFileType", Z417PropostaDocumentosAnexoFileType);
         GxWebStd.gx_hidden_field( context, "Z579PropostaDocumentosStatus", Z579PropostaDocumentosStatus);
         GxWebStd.gx_hidden_field( context, "Z651PropostaDocumentosAdm", StringUtil.BoolToStr( Z651PropostaDocumentosAdm));
         GxWebStd.gx_hidden_field( context, "Z406DocumentosDescricao", Z406DocumentosDescricao);
         GxWebStd.gx_hidden_field( context, "Z407DocumentosStatus", StringUtil.BoolToStr( Z407DocumentosStatus));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Propostaid( )
      {
         /* Using cursor T001O19 */
         pr_default.execute(17, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( (0==A323PropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaId_Internalname;
            }
         }
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Documentosid( )
      {
         n406DocumentosDescricao = false;
         n407DocumentosStatus = false;
         A407DocumentosStatus = StringUtil.StrToBool( cmbDocumentosStatus.CurrentValue);
         n407DocumentosStatus = false;
         cmbDocumentosStatus.CurrentValue = StringUtil.BoolToStr( A407DocumentosStatus);
         /* Using cursor T001O17 */
         pr_default.execute(15, new Object[] {n405DocumentosId, A405DocumentosId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A405DocumentosId) ) )
            {
               GX_msglist.addItem("Não existe 'Documentos'.", "ForeignKeyNotFound", 1, "DOCUMENTOSID");
               AnyError = 1;
               GX_FocusControl = edtDocumentosId_Internalname;
            }
         }
         A406DocumentosDescricao = T001O17_A406DocumentosDescricao[0];
         n406DocumentosDescricao = T001O17_n406DocumentosDescricao[0];
         A407DocumentosStatus = T001O17_A407DocumentosStatus[0];
         n407DocumentosStatus = T001O17_n407DocumentosStatus[0];
         cmbDocumentosStatus.CurrentValue = StringUtil.BoolToStr( A407DocumentosStatus);
         pr_default.close(15);
         dynload_actions( ) ;
         if ( cmbDocumentosStatus.ItemCount > 0 )
         {
            A407DocumentosStatus = StringUtil.StrToBool( cmbDocumentosStatus.getValidValue(StringUtil.BoolToStr( A407DocumentosStatus)));
            n407DocumentosStatus = false;
            cmbDocumentosStatus.CurrentValue = StringUtil.BoolToStr( A407DocumentosStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbDocumentosStatus.CurrentValue = StringUtil.BoolToStr( A407DocumentosStatus);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A406DocumentosDescricao", A406DocumentosDescricao);
         AssignAttri("", false, "A407DocumentosStatus", A407DocumentosStatus);
         cmbDocumentosStatus.CurrentValue = StringUtil.BoolToStr( A407DocumentosStatus);
         AssignProp("", false, cmbDocumentosStatus_Internalname, "Values", cmbDocumentosStatus.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"}]}""");
         setEventMetadata("VALID_PROPOSTADOCUMENTOSID","""{"handler":"Valid_Propostadocumentosid","iparms":[{"av":"cmbDocumentosStatus"},{"av":"A407DocumentosStatus","fld":"DOCUMENTOSSTATUS","type":"boolean"},{"av":"cmbPropostaDocumentosStatus"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A414PropostaDocumentosId","fld":"PROPOSTADOCUMENTOSID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"}]""");
         setEventMetadata("VALID_PROPOSTADOCUMENTOSID",""","oparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","nullAv":"n323PropostaId","type":"int"},{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","nullAv":"n405DocumentosId","type":"int"},{"av":"A415PropostaDocumentosAnexo","fld":"PROPOSTADOCUMENTOSANEXO","type":"bitstr"},{"av":"A416PropostaDocumentosAnexoName","fld":"PROPOSTADOCUMENTOSANEXONAME","type":"svchar"},{"av":"A417PropostaDocumentosAnexoFileType","fld":"PROPOSTADOCUMENTOSANEXOFILETYPE","type":"svchar"},{"av":"cmbPropostaDocumentosStatus"},{"av":"A579PropostaDocumentosStatus","fld":"PROPOSTADOCUMENTOSSTATUS","type":"svchar"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"cmbDocumentosStatus"},{"av":"A407DocumentosStatus","fld":"DOCUMENTOSSTATUS","type":"boolean"},{"av":"edtPropostaDocumentosAnexo_Filetype","ctrl":"PROPOSTADOCUMENTOSANEXO","prop":"Filetype"},{"av":"edtPropostaDocumentosAnexo_Filename","ctrl":"PROPOSTADOCUMENTOSANEXO","prop":"Filename"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z414PropostaDocumentosId","type":"int"},{"av":"Z323PropostaId","type":"int"},{"av":"Z405DocumentosId","type":"int"},{"av":"Z415PropostaDocumentosAnexo","type":"bitstr"},{"av":"Z416PropostaDocumentosAnexoName","type":"svchar"},{"av":"Z417PropostaDocumentosAnexoFileType","type":"svchar"},{"av":"Z579PropostaDocumentosStatus","type":"svchar"},{"av":"Z651PropostaDocumentosAdm","type":"boolean"},{"av":"Z406DocumentosDescricao","type":"svchar"},{"av":"Z407DocumentosStatus","type":"boolean"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"}]}""");
         setEventMetadata("VALID_PROPOSTAID","""{"handler":"Valid_Propostaid","iparms":[{"av":"A323PropostaId","fld":"PROPOSTAID","pic":"ZZZZZZZZ9","nullAv":"n323PropostaId","type":"int"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"}]""");
         setEventMetadata("VALID_PROPOSTAID",""","oparms":[{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"}]}""");
         setEventMetadata("VALID_DOCUMENTOSID","""{"handler":"Valid_Documentosid","iparms":[{"av":"A405DocumentosId","fld":"DOCUMENTOSID","pic":"ZZZZZZZZ9","nullAv":"n405DocumentosId","type":"int"},{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"cmbDocumentosStatus"},{"av":"A407DocumentosStatus","fld":"DOCUMENTOSSTATUS","type":"boolean"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"}]""");
         setEventMetadata("VALID_DOCUMENTOSID",""","oparms":[{"av":"A406DocumentosDescricao","fld":"DOCUMENTOSDESCRICAO","type":"svchar"},{"av":"cmbDocumentosStatus"},{"av":"A407DocumentosStatus","fld":"DOCUMENTOSSTATUS","type":"boolean"},{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"}]}""");
         setEventMetadata("VALID_PROPOSTADOCUMENTOSSTATUS","""{"handler":"Valid_Propostadocumentosstatus","iparms":[{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"}]""");
         setEventMetadata("VALID_PROPOSTADOCUMENTOSSTATUS",""","oparms":[{"av":"A651PropostaDocumentosAdm","fld":"PROPOSTADOCUMENTOSADM","type":"boolean"}]}""");
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
         pr_default.close(17);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z416PropostaDocumentosAnexoName = "";
         Z417PropostaDocumentosAnexoFileType = "";
         Z579PropostaDocumentosStatus = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A579PropostaDocumentosStatus = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A406DocumentosDescricao = "";
         gxblobfileaux = new GxFile(context.GetPhysicalPath());
         A415PropostaDocumentosAnexo = "";
         A416PropostaDocumentosAnexoName = "";
         A417PropostaDocumentosAnexoFileType = "";
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
         Z415PropostaDocumentosAnexo = "";
         Z406DocumentosDescricao = "";
         T001O6_A414PropostaDocumentosId = new int[1] ;
         T001O6_A406DocumentosDescricao = new string[] {""} ;
         T001O6_n406DocumentosDescricao = new bool[] {false} ;
         T001O6_A407DocumentosStatus = new bool[] {false} ;
         T001O6_n407DocumentosStatus = new bool[] {false} ;
         T001O6_A416PropostaDocumentosAnexoName = new string[] {""} ;
         T001O6_n416PropostaDocumentosAnexoName = new bool[] {false} ;
         T001O6_A417PropostaDocumentosAnexoFileType = new string[] {""} ;
         T001O6_n417PropostaDocumentosAnexoFileType = new bool[] {false} ;
         T001O6_A579PropostaDocumentosStatus = new string[] {""} ;
         T001O6_n579PropostaDocumentosStatus = new bool[] {false} ;
         T001O6_A651PropostaDocumentosAdm = new bool[] {false} ;
         T001O6_n651PropostaDocumentosAdm = new bool[] {false} ;
         T001O6_A323PropostaId = new int[1] ;
         T001O6_n323PropostaId = new bool[] {false} ;
         T001O6_A405DocumentosId = new int[1] ;
         T001O6_n405DocumentosId = new bool[] {false} ;
         T001O6_A415PropostaDocumentosAnexo = new string[] {""} ;
         T001O6_n415PropostaDocumentosAnexo = new bool[] {false} ;
         T001O4_A323PropostaId = new int[1] ;
         T001O4_n323PropostaId = new bool[] {false} ;
         T001O5_A406DocumentosDescricao = new string[] {""} ;
         T001O5_n406DocumentosDescricao = new bool[] {false} ;
         T001O5_A407DocumentosStatus = new bool[] {false} ;
         T001O5_n407DocumentosStatus = new bool[] {false} ;
         T001O7_A323PropostaId = new int[1] ;
         T001O7_n323PropostaId = new bool[] {false} ;
         T001O8_A406DocumentosDescricao = new string[] {""} ;
         T001O8_n406DocumentosDescricao = new bool[] {false} ;
         T001O8_A407DocumentosStatus = new bool[] {false} ;
         T001O8_n407DocumentosStatus = new bool[] {false} ;
         T001O9_A414PropostaDocumentosId = new int[1] ;
         T001O3_A414PropostaDocumentosId = new int[1] ;
         T001O3_A416PropostaDocumentosAnexoName = new string[] {""} ;
         T001O3_n416PropostaDocumentosAnexoName = new bool[] {false} ;
         T001O3_A417PropostaDocumentosAnexoFileType = new string[] {""} ;
         T001O3_n417PropostaDocumentosAnexoFileType = new bool[] {false} ;
         T001O3_A579PropostaDocumentosStatus = new string[] {""} ;
         T001O3_n579PropostaDocumentosStatus = new bool[] {false} ;
         T001O3_A651PropostaDocumentosAdm = new bool[] {false} ;
         T001O3_n651PropostaDocumentosAdm = new bool[] {false} ;
         T001O3_A323PropostaId = new int[1] ;
         T001O3_n323PropostaId = new bool[] {false} ;
         T001O3_A405DocumentosId = new int[1] ;
         T001O3_n405DocumentosId = new bool[] {false} ;
         T001O3_A415PropostaDocumentosAnexo = new string[] {""} ;
         T001O3_n415PropostaDocumentosAnexo = new bool[] {false} ;
         sMode62 = "";
         T001O10_A414PropostaDocumentosId = new int[1] ;
         T001O11_A414PropostaDocumentosId = new int[1] ;
         T001O2_A414PropostaDocumentosId = new int[1] ;
         T001O2_A416PropostaDocumentosAnexoName = new string[] {""} ;
         T001O2_n416PropostaDocumentosAnexoName = new bool[] {false} ;
         T001O2_A417PropostaDocumentosAnexoFileType = new string[] {""} ;
         T001O2_n417PropostaDocumentosAnexoFileType = new bool[] {false} ;
         T001O2_A579PropostaDocumentosStatus = new string[] {""} ;
         T001O2_n579PropostaDocumentosStatus = new bool[] {false} ;
         T001O2_A651PropostaDocumentosAdm = new bool[] {false} ;
         T001O2_n651PropostaDocumentosAdm = new bool[] {false} ;
         T001O2_A323PropostaId = new int[1] ;
         T001O2_n323PropostaId = new bool[] {false} ;
         T001O2_A405DocumentosId = new int[1] ;
         T001O2_n405DocumentosId = new bool[] {false} ;
         T001O2_A415PropostaDocumentosAnexo = new string[] {""} ;
         T001O2_n415PropostaDocumentosAnexo = new bool[] {false} ;
         T001O13_A414PropostaDocumentosId = new int[1] ;
         T001O17_A406DocumentosDescricao = new string[] {""} ;
         T001O17_n406DocumentosDescricao = new bool[] {false} ;
         T001O17_A407DocumentosStatus = new bool[] {false} ;
         T001O17_n407DocumentosStatus = new bool[] {false} ;
         T001O18_A414PropostaDocumentosId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ415PropostaDocumentosAnexo = "";
         ZZ416PropostaDocumentosAnexoName = "";
         ZZ417PropostaDocumentosAnexoFileType = "";
         ZZ579PropostaDocumentosStatus = "";
         ZZ406DocumentosDescricao = "";
         T001O19_A323PropostaId = new int[1] ;
         T001O19_n323PropostaId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostadocumentos__default(),
            new Object[][] {
                new Object[] {
               T001O2_A414PropostaDocumentosId, T001O2_A416PropostaDocumentosAnexoName, T001O2_n416PropostaDocumentosAnexoName, T001O2_A417PropostaDocumentosAnexoFileType, T001O2_n417PropostaDocumentosAnexoFileType, T001O2_A579PropostaDocumentosStatus, T001O2_n579PropostaDocumentosStatus, T001O2_A651PropostaDocumentosAdm, T001O2_n651PropostaDocumentosAdm, T001O2_A323PropostaId,
               T001O2_n323PropostaId, T001O2_A405DocumentosId, T001O2_n405DocumentosId, T001O2_A415PropostaDocumentosAnexo, T001O2_n415PropostaDocumentosAnexo
               }
               , new Object[] {
               T001O3_A414PropostaDocumentosId, T001O3_A416PropostaDocumentosAnexoName, T001O3_n416PropostaDocumentosAnexoName, T001O3_A417PropostaDocumentosAnexoFileType, T001O3_n417PropostaDocumentosAnexoFileType, T001O3_A579PropostaDocumentosStatus, T001O3_n579PropostaDocumentosStatus, T001O3_A651PropostaDocumentosAdm, T001O3_n651PropostaDocumentosAdm, T001O3_A323PropostaId,
               T001O3_n323PropostaId, T001O3_A405DocumentosId, T001O3_n405DocumentosId, T001O3_A415PropostaDocumentosAnexo, T001O3_n415PropostaDocumentosAnexo
               }
               , new Object[] {
               T001O4_A323PropostaId
               }
               , new Object[] {
               T001O5_A406DocumentosDescricao, T001O5_n406DocumentosDescricao, T001O5_A407DocumentosStatus, T001O5_n407DocumentosStatus
               }
               , new Object[] {
               T001O6_A414PropostaDocumentosId, T001O6_A406DocumentosDescricao, T001O6_n406DocumentosDescricao, T001O6_A407DocumentosStatus, T001O6_n407DocumentosStatus, T001O6_A416PropostaDocumentosAnexoName, T001O6_n416PropostaDocumentosAnexoName, T001O6_A417PropostaDocumentosAnexoFileType, T001O6_n417PropostaDocumentosAnexoFileType, T001O6_A579PropostaDocumentosStatus,
               T001O6_n579PropostaDocumentosStatus, T001O6_A651PropostaDocumentosAdm, T001O6_n651PropostaDocumentosAdm, T001O6_A323PropostaId, T001O6_n323PropostaId, T001O6_A405DocumentosId, T001O6_n405DocumentosId, T001O6_A415PropostaDocumentosAnexo, T001O6_n415PropostaDocumentosAnexo
               }
               , new Object[] {
               T001O7_A323PropostaId
               }
               , new Object[] {
               T001O8_A406DocumentosDescricao, T001O8_n406DocumentosDescricao, T001O8_A407DocumentosStatus, T001O8_n407DocumentosStatus
               }
               , new Object[] {
               T001O9_A414PropostaDocumentosId
               }
               , new Object[] {
               T001O10_A414PropostaDocumentosId
               }
               , new Object[] {
               T001O11_A414PropostaDocumentosId
               }
               , new Object[] {
               }
               , new Object[] {
               T001O13_A414PropostaDocumentosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001O17_A406DocumentosDescricao, T001O17_n406DocumentosDescricao, T001O17_A407DocumentosStatus, T001O17_n407DocumentosStatus
               }
               , new Object[] {
               T001O18_A414PropostaDocumentosId
               }
               , new Object[] {
               T001O19_A323PropostaId
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
      private short RcdFound62 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z414PropostaDocumentosId ;
      private int Z323PropostaId ;
      private int Z405DocumentosId ;
      private int A323PropostaId ;
      private int A405DocumentosId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A414PropostaDocumentosId ;
      private int edtPropostaDocumentosId_Enabled ;
      private int edtPropostaId_Enabled ;
      private int edtDocumentosId_Enabled ;
      private int edtDocumentosDescricao_Enabled ;
      private int edtPropostaDocumentosAnexo_Enabled ;
      private int edtPropostaDocumentosAnexoName_Enabled ;
      private int edtPropostaDocumentosAnexoFileType_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ414PropostaDocumentosId ;
      private int ZZ323PropostaId ;
      private int ZZ405DocumentosId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPropostaDocumentosId_Internalname ;
      private string cmbDocumentosStatus_Internalname ;
      private string cmbPropostaDocumentosStatus_Internalname ;
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
      private string edtPropostaDocumentosId_Jsonclick ;
      private string edtPropostaId_Internalname ;
      private string edtPropostaId_Jsonclick ;
      private string edtDocumentosId_Internalname ;
      private string edtDocumentosId_Jsonclick ;
      private string edtDocumentosDescricao_Internalname ;
      private string edtDocumentosDescricao_Jsonclick ;
      private string cmbDocumentosStatus_Jsonclick ;
      private string edtPropostaDocumentosAnexo_Internalname ;
      private string edtPropostaDocumentosAnexo_Filetype ;
      private string edtPropostaDocumentosAnexo_Contenttype ;
      private string edtPropostaDocumentosAnexo_Parameters ;
      private string edtPropostaDocumentosAnexo_Jsonclick ;
      private string edtPropostaDocumentosAnexoName_Internalname ;
      private string edtPropostaDocumentosAnexoName_Jsonclick ;
      private string edtPropostaDocumentosAnexoFileType_Internalname ;
      private string edtPropostaDocumentosAnexoFileType_Jsonclick ;
      private string cmbPropostaDocumentosStatus_Jsonclick ;
      private string chkPropostaDocumentosAdm_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string edtPropostaDocumentosAnexo_Filename ;
      private string GXCCtlgxBlob ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode62 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool Z651PropostaDocumentosAdm ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n323PropostaId ;
      private bool n405DocumentosId ;
      private bool wbErr ;
      private bool A407DocumentosStatus ;
      private bool n407DocumentosStatus ;
      private bool n579PropostaDocumentosStatus ;
      private bool A651PropostaDocumentosAdm ;
      private bool n651PropostaDocumentosAdm ;
      private bool n415PropostaDocumentosAnexo ;
      private bool n416PropostaDocumentosAnexoName ;
      private bool n417PropostaDocumentosAnexoFileType ;
      private bool n406DocumentosDescricao ;
      private bool Z407DocumentosStatus ;
      private bool Gx_longc ;
      private bool ZZ651PropostaDocumentosAdm ;
      private bool ZZ407DocumentosStatus ;
      private string Z416PropostaDocumentosAnexoName ;
      private string Z417PropostaDocumentosAnexoFileType ;
      private string Z579PropostaDocumentosStatus ;
      private string A579PropostaDocumentosStatus ;
      private string A406DocumentosDescricao ;
      private string A416PropostaDocumentosAnexoName ;
      private string A417PropostaDocumentosAnexoFileType ;
      private string Z406DocumentosDescricao ;
      private string ZZ416PropostaDocumentosAnexoName ;
      private string ZZ417PropostaDocumentosAnexoFileType ;
      private string ZZ579PropostaDocumentosStatus ;
      private string ZZ406DocumentosDescricao ;
      private string A415PropostaDocumentosAnexo ;
      private string Z415PropostaDocumentosAnexo ;
      private string ZZ415PropostaDocumentosAnexo ;
      private GxFile gxblobfileaux ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbDocumentosStatus ;
      private GXCombobox cmbPropostaDocumentosStatus ;
      private GXCheckbox chkPropostaDocumentosAdm ;
      private IDataStoreProvider pr_default ;
      private int[] T001O6_A414PropostaDocumentosId ;
      private string[] T001O6_A406DocumentosDescricao ;
      private bool[] T001O6_n406DocumentosDescricao ;
      private bool[] T001O6_A407DocumentosStatus ;
      private bool[] T001O6_n407DocumentosStatus ;
      private string[] T001O6_A416PropostaDocumentosAnexoName ;
      private bool[] T001O6_n416PropostaDocumentosAnexoName ;
      private string[] T001O6_A417PropostaDocumentosAnexoFileType ;
      private bool[] T001O6_n417PropostaDocumentosAnexoFileType ;
      private string[] T001O6_A579PropostaDocumentosStatus ;
      private bool[] T001O6_n579PropostaDocumentosStatus ;
      private bool[] T001O6_A651PropostaDocumentosAdm ;
      private bool[] T001O6_n651PropostaDocumentosAdm ;
      private int[] T001O6_A323PropostaId ;
      private bool[] T001O6_n323PropostaId ;
      private int[] T001O6_A405DocumentosId ;
      private bool[] T001O6_n405DocumentosId ;
      private string[] T001O6_A415PropostaDocumentosAnexo ;
      private bool[] T001O6_n415PropostaDocumentosAnexo ;
      private int[] T001O4_A323PropostaId ;
      private bool[] T001O4_n323PropostaId ;
      private string[] T001O5_A406DocumentosDescricao ;
      private bool[] T001O5_n406DocumentosDescricao ;
      private bool[] T001O5_A407DocumentosStatus ;
      private bool[] T001O5_n407DocumentosStatus ;
      private int[] T001O7_A323PropostaId ;
      private bool[] T001O7_n323PropostaId ;
      private string[] T001O8_A406DocumentosDescricao ;
      private bool[] T001O8_n406DocumentosDescricao ;
      private bool[] T001O8_A407DocumentosStatus ;
      private bool[] T001O8_n407DocumentosStatus ;
      private int[] T001O9_A414PropostaDocumentosId ;
      private int[] T001O3_A414PropostaDocumentosId ;
      private string[] T001O3_A416PropostaDocumentosAnexoName ;
      private bool[] T001O3_n416PropostaDocumentosAnexoName ;
      private string[] T001O3_A417PropostaDocumentosAnexoFileType ;
      private bool[] T001O3_n417PropostaDocumentosAnexoFileType ;
      private string[] T001O3_A579PropostaDocumentosStatus ;
      private bool[] T001O3_n579PropostaDocumentosStatus ;
      private bool[] T001O3_A651PropostaDocumentosAdm ;
      private bool[] T001O3_n651PropostaDocumentosAdm ;
      private int[] T001O3_A323PropostaId ;
      private bool[] T001O3_n323PropostaId ;
      private int[] T001O3_A405DocumentosId ;
      private bool[] T001O3_n405DocumentosId ;
      private string[] T001O3_A415PropostaDocumentosAnexo ;
      private bool[] T001O3_n415PropostaDocumentosAnexo ;
      private int[] T001O10_A414PropostaDocumentosId ;
      private int[] T001O11_A414PropostaDocumentosId ;
      private int[] T001O2_A414PropostaDocumentosId ;
      private string[] T001O2_A416PropostaDocumentosAnexoName ;
      private bool[] T001O2_n416PropostaDocumentosAnexoName ;
      private string[] T001O2_A417PropostaDocumentosAnexoFileType ;
      private bool[] T001O2_n417PropostaDocumentosAnexoFileType ;
      private string[] T001O2_A579PropostaDocumentosStatus ;
      private bool[] T001O2_n579PropostaDocumentosStatus ;
      private bool[] T001O2_A651PropostaDocumentosAdm ;
      private bool[] T001O2_n651PropostaDocumentosAdm ;
      private int[] T001O2_A323PropostaId ;
      private bool[] T001O2_n323PropostaId ;
      private int[] T001O2_A405DocumentosId ;
      private bool[] T001O2_n405DocumentosId ;
      private string[] T001O2_A415PropostaDocumentosAnexo ;
      private bool[] T001O2_n415PropostaDocumentosAnexo ;
      private int[] T001O13_A414PropostaDocumentosId ;
      private string[] T001O17_A406DocumentosDescricao ;
      private bool[] T001O17_n406DocumentosDescricao ;
      private bool[] T001O17_A407DocumentosStatus ;
      private bool[] T001O17_n407DocumentosStatus ;
      private int[] T001O18_A414PropostaDocumentosId ;
      private int[] T001O19_A323PropostaId ;
      private bool[] T001O19_n323PropostaId ;
   }

   public class propostadocumentos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT001O2;
          prmT001O2 = new Object[] {
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmT001O3;
          prmT001O3 = new Object[] {
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmT001O4;
          prmT001O4 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001O5;
          prmT001O5 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001O6;
          prmT001O6 = new Object[] {
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmT001O7;
          prmT001O7 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001O8;
          prmT001O8 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001O9;
          prmT001O9 = new Object[] {
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmT001O10;
          prmT001O10 = new Object[] {
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmT001O11;
          prmT001O11 = new Object[] {
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmT001O12;
          prmT001O12 = new Object[] {
          new ParDef("PropostaDocumentosAnexo",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("PropostaDocumentosAnexoName",GXType.VarChar,128,0){Nullable=true} ,
          new ParDef("PropostaDocumentosAnexoFileType",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaDocumentosStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaDocumentosAdm",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001O13;
          prmT001O13 = new Object[] {
          };
          Object[] prmT001O14;
          prmT001O14 = new Object[] {
          new ParDef("PropostaDocumentosAnexoName",GXType.VarChar,128,0){Nullable=true} ,
          new ParDef("PropostaDocumentosAnexoFileType",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaDocumentosStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaDocumentosAdm",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmT001O15;
          prmT001O15 = new Object[] {
          new ParDef("PropostaDocumentosAnexo",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmT001O16;
          prmT001O16 = new Object[] {
          new ParDef("PropostaDocumentosId",GXType.Int32,9,0)
          };
          Object[] prmT001O17;
          prmT001O17 = new Object[] {
          new ParDef("DocumentosId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001O18;
          prmT001O18 = new Object[] {
          };
          Object[] prmT001O19;
          prmT001O19 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T001O2", "SELECT PropostaDocumentosId, PropostaDocumentosAnexoName, PropostaDocumentosAnexoFileType, PropostaDocumentosStatus, PropostaDocumentosAdm, PropostaId, DocumentosId, PropostaDocumentosAnexo FROM PropostaDocumentos WHERE PropostaDocumentosId = :PropostaDocumentosId  FOR UPDATE OF PropostaDocumentos NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001O2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001O3", "SELECT PropostaDocumentosId, PropostaDocumentosAnexoName, PropostaDocumentosAnexoFileType, PropostaDocumentosStatus, PropostaDocumentosAdm, PropostaId, DocumentosId, PropostaDocumentosAnexo FROM PropostaDocumentos WHERE PropostaDocumentosId = :PropostaDocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001O4", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001O5", "SELECT DocumentosDescricao, DocumentosStatus FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001O6", "SELECT TM1.PropostaDocumentosId, T2.DocumentosDescricao, T2.DocumentosStatus, TM1.PropostaDocumentosAnexoName, TM1.PropostaDocumentosAnexoFileType, TM1.PropostaDocumentosStatus, TM1.PropostaDocumentosAdm, TM1.PropostaId, TM1.DocumentosId, TM1.PropostaDocumentosAnexo FROM (PropostaDocumentos TM1 LEFT JOIN Documentos T2 ON T2.DocumentosId = TM1.DocumentosId) WHERE TM1.PropostaDocumentosId = :PropostaDocumentosId ORDER BY TM1.PropostaDocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001O7", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001O8", "SELECT DocumentosDescricao, DocumentosStatus FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001O9", "SELECT PropostaDocumentosId FROM PropostaDocumentos WHERE PropostaDocumentosId = :PropostaDocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001O10", "SELECT PropostaDocumentosId FROM PropostaDocumentos WHERE ( PropostaDocumentosId > :PropostaDocumentosId) ORDER BY PropostaDocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001O11", "SELECT PropostaDocumentosId FROM PropostaDocumentos WHERE ( PropostaDocumentosId < :PropostaDocumentosId) ORDER BY PropostaDocumentosId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001O12", "SAVEPOINT gxupdate;INSERT INTO PropostaDocumentos(PropostaDocumentosAnexo, PropostaDocumentosAnexoName, PropostaDocumentosAnexoFileType, PropostaDocumentosStatus, PropostaDocumentosAdm, PropostaId, DocumentosId) VALUES(:PropostaDocumentosAnexo, :PropostaDocumentosAnexoName, :PropostaDocumentosAnexoFileType, :PropostaDocumentosStatus, :PropostaDocumentosAdm, :PropostaId, :DocumentosId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001O12)
             ,new CursorDef("T001O13", "SELECT currval('PropostaDocumentosId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001O14", "SAVEPOINT gxupdate;UPDATE PropostaDocumentos SET PropostaDocumentosAnexoName=:PropostaDocumentosAnexoName, PropostaDocumentosAnexoFileType=:PropostaDocumentosAnexoFileType, PropostaDocumentosStatus=:PropostaDocumentosStatus, PropostaDocumentosAdm=:PropostaDocumentosAdm, PropostaId=:PropostaId, DocumentosId=:DocumentosId  WHERE PropostaDocumentosId = :PropostaDocumentosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001O14)
             ,new CursorDef("T001O15", "SAVEPOINT gxupdate;UPDATE PropostaDocumentos SET PropostaDocumentosAnexo=:PropostaDocumentosAnexo  WHERE PropostaDocumentosId = :PropostaDocumentosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001O15)
             ,new CursorDef("T001O16", "SAVEPOINT gxupdate;DELETE FROM PropostaDocumentos  WHERE PropostaDocumentosId = :PropostaDocumentosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001O16)
             ,new CursorDef("T001O17", "SELECT DocumentosDescricao, DocumentosStatus FROM Documentos WHERE DocumentosId = :DocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001O18", "SELECT PropostaDocumentosId FROM PropostaDocumentos ORDER BY PropostaDocumentosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O18,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001O19", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001O19,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[7])[0] = rslt.getBool(5);
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
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getBLOBFile(10, "tmp", "");
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
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
