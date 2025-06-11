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
   public class reembolsoparcelas : GXDataArea
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
            A518ReembolsoId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoId"), "."), 18, MidpointRounding.ToEven));
            n518ReembolsoId = false;
            AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A518ReembolsoId) ;
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
         Form.Meta.addItem("description", "Reembolso Parcelas", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtReembolsoParcelasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public reembolsoparcelas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoparcelas( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Reembolso Parcelas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ReembolsoParcelas.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ReembolsoParcelas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoParcelasId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoParcelasId_Internalname, "Parcelas Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoParcelasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A634ReembolsoParcelasId), 9, 0, ",", "")), StringUtil.LTrim( ((edtReembolsoParcelasId_Enabled!=0) ? context.localUtil.Format( (decimal)(A634ReembolsoParcelasId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A634ReembolsoParcelasId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoParcelasId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoParcelasId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoId_Internalname, "Reembolso Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoId_Internalname, ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ",", ""))), ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( ((edtReembolsoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A518ReembolsoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A518ReembolsoId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoParcelasValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoParcelasValor_Internalname, "Valor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoParcelasValor_Internalname, ((Convert.ToDecimal(0)==A635ReembolsoParcelasValor)&&IsIns( )||n635ReembolsoParcelasValor ? "" : StringUtil.LTrim( StringUtil.NToC( A635ReembolsoParcelasValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A635ReembolsoParcelasValor)&&IsIns( )||n635ReembolsoParcelasValor ? "" : StringUtil.LTrim( ((edtReembolsoParcelasValor_Enabled!=0) ? context.localUtil.Format( A635ReembolsoParcelasValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A635ReembolsoParcelasValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoParcelasValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoParcelasValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoParcelasData_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoParcelasData_Internalname, "Data do depósito", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtReembolsoParcelasData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtReembolsoParcelasData_Internalname, context.localUtil.Format(A636ReembolsoParcelasData, "99/99/9999"), context.localUtil.Format( A636ReembolsoParcelasData, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoParcelasData_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoParcelasData_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_bitmap( context, edtReembolsoParcelasData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtReembolsoParcelasData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ReembolsoParcelas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoParcelasObservacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoParcelasObservacao_Internalname, "Observação", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoParcelasObservacao_Internalname, A637ReembolsoParcelasObservacao, StringUtil.RTrim( context.localUtil.Format( A637ReembolsoParcelasObservacao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoParcelasObservacao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoParcelasObservacao_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoParcelasCreatedAt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoParcelasCreatedAt_Internalname, "Created At", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtReembolsoParcelasCreatedAt_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtReembolsoParcelasCreatedAt_Internalname, context.localUtil.TToC( A638ReembolsoParcelasCreatedAt, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A638ReembolsoParcelasCreatedAt, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoParcelasCreatedAt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoParcelasCreatedAt_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_bitmap( context, edtReembolsoParcelasCreatedAt_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtReembolsoParcelasCreatedAt_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ReembolsoParcelas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoParcelasTaxaValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoParcelasTaxaValor_Internalname, "Taxa Valor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoParcelasTaxaValor_Internalname, ((Convert.ToDecimal(0)==A639ReembolsoParcelasTaxaValor)&&IsIns( )||n639ReembolsoParcelasTaxaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A639ReembolsoParcelasTaxaValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A639ReembolsoParcelasTaxaValor)&&IsIns( )||n639ReembolsoParcelasTaxaValor ? "" : StringUtil.LTrim( ((edtReembolsoParcelasTaxaValor_Enabled!=0) ? context.localUtil.Format( A639ReembolsoParcelasTaxaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A639ReembolsoParcelasTaxaValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoParcelasTaxaValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoParcelasTaxaValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoParcelasJurosValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoParcelasJurosValor_Internalname, "Juros Valor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoParcelasJurosValor_Internalname, ((Convert.ToDecimal(0)==A640ReembolsoParcelasJurosValor)&&IsIns( )||n640ReembolsoParcelasJurosValor ? "" : StringUtil.LTrim( StringUtil.NToC( A640ReembolsoParcelasJurosValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A640ReembolsoParcelasJurosValor)&&IsIns( )||n640ReembolsoParcelasJurosValor ? "" : StringUtil.LTrim( ((edtReembolsoParcelasJurosValor_Enabled!=0) ? context.localUtil.Format( A640ReembolsoParcelasJurosValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A640ReembolsoParcelasJurosValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoParcelasJurosValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoParcelasJurosValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoParcelasDiasPJuros_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoParcelasDiasPJuros_Internalname, "Dias PJuros", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoParcelasDiasPJuros_Internalname, ((0==A641ReembolsoParcelasDiasPJuros)&&IsIns( )||n641ReembolsoParcelasDiasPJuros ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A641ReembolsoParcelasDiasPJuros), 4, 0, ",", ""))), ((0==A641ReembolsoParcelasDiasPJuros)&&IsIns( )||n641ReembolsoParcelasDiasPJuros ? "" : StringUtil.LTrim( ((edtReembolsoParcelasDiasPJuros_Enabled!=0) ? context.localUtil.Format( (decimal)(A641ReembolsoParcelasDiasPJuros), "ZZZ9") : context.localUtil.Format( (decimal)(A641ReembolsoParcelasDiasPJuros), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoParcelasDiasPJuros_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReembolsoParcelasDiasPJuros_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoParcelas.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoParcelas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoParcelas.htm");
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
            Z634ReembolsoParcelasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z634ReembolsoParcelasId"), ",", "."), 18, MidpointRounding.ToEven));
            Z635ReembolsoParcelasValor = context.localUtil.CToN( cgiGet( "Z635ReembolsoParcelasValor"), ",", ".");
            n635ReembolsoParcelasValor = ((Convert.ToDecimal(0)==A635ReembolsoParcelasValor) ? true : false);
            Z636ReembolsoParcelasData = context.localUtil.CToD( cgiGet( "Z636ReembolsoParcelasData"), 0);
            n636ReembolsoParcelasData = ((DateTime.MinValue==A636ReembolsoParcelasData) ? true : false);
            Z637ReembolsoParcelasObservacao = cgiGet( "Z637ReembolsoParcelasObservacao");
            n637ReembolsoParcelasObservacao = (String.IsNullOrEmpty(StringUtil.RTrim( A637ReembolsoParcelasObservacao)) ? true : false);
            Z638ReembolsoParcelasCreatedAt = context.localUtil.CToT( cgiGet( "Z638ReembolsoParcelasCreatedAt"), 0);
            n638ReembolsoParcelasCreatedAt = ((DateTime.MinValue==A638ReembolsoParcelasCreatedAt) ? true : false);
            Z639ReembolsoParcelasTaxaValor = context.localUtil.CToN( cgiGet( "Z639ReembolsoParcelasTaxaValor"), ",", ".");
            n639ReembolsoParcelasTaxaValor = ((Convert.ToDecimal(0)==A639ReembolsoParcelasTaxaValor) ? true : false);
            Z640ReembolsoParcelasJurosValor = context.localUtil.CToN( cgiGet( "Z640ReembolsoParcelasJurosValor"), ",", ".");
            n640ReembolsoParcelasJurosValor = ((Convert.ToDecimal(0)==A640ReembolsoParcelasJurosValor) ? true : false);
            Z641ReembolsoParcelasDiasPJuros = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z641ReembolsoParcelasDiasPJuros"), ",", "."), 18, MidpointRounding.ToEven));
            n641ReembolsoParcelasDiasPJuros = ((0==A641ReembolsoParcelasDiasPJuros) ? true : false);
            Z518ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z518ReembolsoId"), ",", "."), 18, MidpointRounding.ToEven));
            n518ReembolsoId = ((0==A518ReembolsoId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoParcelasId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoParcelasId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOPARCELASID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoParcelasId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A634ReembolsoParcelasId = 0;
               AssignAttri("", false, "A634ReembolsoParcelasId", StringUtil.LTrimStr( (decimal)(A634ReembolsoParcelasId), 9, 0));
            }
            else
            {
               A634ReembolsoParcelasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoParcelasId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A634ReembolsoParcelasId", StringUtil.LTrimStr( (decimal)(A634ReembolsoParcelasId), 9, 0));
            }
            n518ReembolsoId = ((StringUtil.StrCmp(cgiGet( edtReembolsoId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A518ReembolsoId = 0;
               n518ReembolsoId = false;
               AssignAttri("", false, "A518ReembolsoId", (n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            }
            else
            {
               A518ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A518ReembolsoId", (n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            }
            n635ReembolsoParcelasValor = ((StringUtil.StrCmp(cgiGet( edtReembolsoParcelasValor_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoParcelasValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoParcelasValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOPARCELASVALOR");
               AnyError = 1;
               GX_FocusControl = edtReembolsoParcelasValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A635ReembolsoParcelasValor = 0;
               n635ReembolsoParcelasValor = false;
               AssignAttri("", false, "A635ReembolsoParcelasValor", (n635ReembolsoParcelasValor ? "" : StringUtil.LTrim( StringUtil.NToC( A635ReembolsoParcelasValor, 18, 2, ".", ""))));
            }
            else
            {
               A635ReembolsoParcelasValor = context.localUtil.CToN( cgiGet( edtReembolsoParcelasValor_Internalname), ",", ".");
               AssignAttri("", false, "A635ReembolsoParcelasValor", (n635ReembolsoParcelasValor ? "" : StringUtil.LTrim( StringUtil.NToC( A635ReembolsoParcelasValor, 18, 2, ".", ""))));
            }
            if ( context.localUtil.VCDate( cgiGet( edtReembolsoParcelasData_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data do depósito"}), 1, "REEMBOLSOPARCELASDATA");
               AnyError = 1;
               GX_FocusControl = edtReembolsoParcelasData_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A636ReembolsoParcelasData = DateTime.MinValue;
               n636ReembolsoParcelasData = false;
               AssignAttri("", false, "A636ReembolsoParcelasData", context.localUtil.Format(A636ReembolsoParcelasData, "99/99/9999"));
            }
            else
            {
               A636ReembolsoParcelasData = context.localUtil.CToD( cgiGet( edtReembolsoParcelasData_Internalname), 2);
               n636ReembolsoParcelasData = false;
               AssignAttri("", false, "A636ReembolsoParcelasData", context.localUtil.Format(A636ReembolsoParcelasData, "99/99/9999"));
            }
            n636ReembolsoParcelasData = ((DateTime.MinValue==A636ReembolsoParcelasData) ? true : false);
            A637ReembolsoParcelasObservacao = cgiGet( edtReembolsoParcelasObservacao_Internalname);
            n637ReembolsoParcelasObservacao = false;
            AssignAttri("", false, "A637ReembolsoParcelasObservacao", A637ReembolsoParcelasObservacao);
            n637ReembolsoParcelasObservacao = (String.IsNullOrEmpty(StringUtil.RTrim( A637ReembolsoParcelasObservacao)) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtReembolsoParcelasCreatedAt_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Reembolso Parcelas Created At"}), 1, "REEMBOLSOPARCELASCREATEDAT");
               AnyError = 1;
               GX_FocusControl = edtReembolsoParcelasCreatedAt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A638ReembolsoParcelasCreatedAt = (DateTime)(DateTime.MinValue);
               n638ReembolsoParcelasCreatedAt = false;
               AssignAttri("", false, "A638ReembolsoParcelasCreatedAt", context.localUtil.TToC( A638ReembolsoParcelasCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A638ReembolsoParcelasCreatedAt = context.localUtil.CToT( cgiGet( edtReembolsoParcelasCreatedAt_Internalname));
               n638ReembolsoParcelasCreatedAt = false;
               AssignAttri("", false, "A638ReembolsoParcelasCreatedAt", context.localUtil.TToC( A638ReembolsoParcelasCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            }
            n638ReembolsoParcelasCreatedAt = ((DateTime.MinValue==A638ReembolsoParcelasCreatedAt) ? true : false);
            n639ReembolsoParcelasTaxaValor = ((StringUtil.StrCmp(cgiGet( edtReembolsoParcelasTaxaValor_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoParcelasTaxaValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoParcelasTaxaValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOPARCELASTAXAVALOR");
               AnyError = 1;
               GX_FocusControl = edtReembolsoParcelasTaxaValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A639ReembolsoParcelasTaxaValor = 0;
               n639ReembolsoParcelasTaxaValor = false;
               AssignAttri("", false, "A639ReembolsoParcelasTaxaValor", (n639ReembolsoParcelasTaxaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A639ReembolsoParcelasTaxaValor, 18, 2, ".", ""))));
            }
            else
            {
               A639ReembolsoParcelasTaxaValor = context.localUtil.CToN( cgiGet( edtReembolsoParcelasTaxaValor_Internalname), ",", ".");
               AssignAttri("", false, "A639ReembolsoParcelasTaxaValor", (n639ReembolsoParcelasTaxaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A639ReembolsoParcelasTaxaValor, 18, 2, ".", ""))));
            }
            n640ReembolsoParcelasJurosValor = ((StringUtil.StrCmp(cgiGet( edtReembolsoParcelasJurosValor_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoParcelasJurosValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoParcelasJurosValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOPARCELASJUROSVALOR");
               AnyError = 1;
               GX_FocusControl = edtReembolsoParcelasJurosValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A640ReembolsoParcelasJurosValor = 0;
               n640ReembolsoParcelasJurosValor = false;
               AssignAttri("", false, "A640ReembolsoParcelasJurosValor", (n640ReembolsoParcelasJurosValor ? "" : StringUtil.LTrim( StringUtil.NToC( A640ReembolsoParcelasJurosValor, 18, 2, ".", ""))));
            }
            else
            {
               A640ReembolsoParcelasJurosValor = context.localUtil.CToN( cgiGet( edtReembolsoParcelasJurosValor_Internalname), ",", ".");
               AssignAttri("", false, "A640ReembolsoParcelasJurosValor", (n640ReembolsoParcelasJurosValor ? "" : StringUtil.LTrim( StringUtil.NToC( A640ReembolsoParcelasJurosValor, 18, 2, ".", ""))));
            }
            n641ReembolsoParcelasDiasPJuros = ((StringUtil.StrCmp(cgiGet( edtReembolsoParcelasDiasPJuros_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtReembolsoParcelasDiasPJuros_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReembolsoParcelasDiasPJuros_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REEMBOLSOPARCELASDIASPJUROS");
               AnyError = 1;
               GX_FocusControl = edtReembolsoParcelasDiasPJuros_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A641ReembolsoParcelasDiasPJuros = 0;
               n641ReembolsoParcelasDiasPJuros = false;
               AssignAttri("", false, "A641ReembolsoParcelasDiasPJuros", (n641ReembolsoParcelasDiasPJuros ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A641ReembolsoParcelasDiasPJuros), 4, 0, ".", ""))));
            }
            else
            {
               A641ReembolsoParcelasDiasPJuros = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoParcelasDiasPJuros_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A641ReembolsoParcelasDiasPJuros", (n641ReembolsoParcelasDiasPJuros ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A641ReembolsoParcelasDiasPJuros), 4, 0, ".", ""))));
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
               A634ReembolsoParcelasId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoParcelasId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A634ReembolsoParcelasId", StringUtil.LTrimStr( (decimal)(A634ReembolsoParcelasId), 9, 0));
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
               InitAll2C82( ) ;
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
         DisableAttributes2C82( ) ;
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

      protected void ResetCaption2C0( )
      {
      }

      protected void ZM2C82( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z635ReembolsoParcelasValor = T002C3_A635ReembolsoParcelasValor[0];
               Z636ReembolsoParcelasData = T002C3_A636ReembolsoParcelasData[0];
               Z637ReembolsoParcelasObservacao = T002C3_A637ReembolsoParcelasObservacao[0];
               Z638ReembolsoParcelasCreatedAt = T002C3_A638ReembolsoParcelasCreatedAt[0];
               Z639ReembolsoParcelasTaxaValor = T002C3_A639ReembolsoParcelasTaxaValor[0];
               Z640ReembolsoParcelasJurosValor = T002C3_A640ReembolsoParcelasJurosValor[0];
               Z641ReembolsoParcelasDiasPJuros = T002C3_A641ReembolsoParcelasDiasPJuros[0];
               Z518ReembolsoId = T002C3_A518ReembolsoId[0];
            }
            else
            {
               Z635ReembolsoParcelasValor = A635ReembolsoParcelasValor;
               Z636ReembolsoParcelasData = A636ReembolsoParcelasData;
               Z637ReembolsoParcelasObservacao = A637ReembolsoParcelasObservacao;
               Z638ReembolsoParcelasCreatedAt = A638ReembolsoParcelasCreatedAt;
               Z639ReembolsoParcelasTaxaValor = A639ReembolsoParcelasTaxaValor;
               Z640ReembolsoParcelasJurosValor = A640ReembolsoParcelasJurosValor;
               Z641ReembolsoParcelasDiasPJuros = A641ReembolsoParcelasDiasPJuros;
               Z518ReembolsoId = A518ReembolsoId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z634ReembolsoParcelasId = A634ReembolsoParcelasId;
            Z635ReembolsoParcelasValor = A635ReembolsoParcelasValor;
            Z636ReembolsoParcelasData = A636ReembolsoParcelasData;
            Z637ReembolsoParcelasObservacao = A637ReembolsoParcelasObservacao;
            Z638ReembolsoParcelasCreatedAt = A638ReembolsoParcelasCreatedAt;
            Z639ReembolsoParcelasTaxaValor = A639ReembolsoParcelasTaxaValor;
            Z640ReembolsoParcelasJurosValor = A640ReembolsoParcelasJurosValor;
            Z641ReembolsoParcelasDiasPJuros = A641ReembolsoParcelasDiasPJuros;
            Z518ReembolsoId = A518ReembolsoId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A638ReembolsoParcelasCreatedAt) && ( Gx_BScreen == 0 ) )
         {
            A638ReembolsoParcelasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n638ReembolsoParcelasCreatedAt = false;
            AssignAttri("", false, "A638ReembolsoParcelasCreatedAt", context.localUtil.TToC( A638ReembolsoParcelasCreatedAt, 8, 5, 0, 3, "/", ":", " "));
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

      protected void Load2C82( )
      {
         /* Using cursor T002C5 */
         pr_default.execute(3, new Object[] {A634ReembolsoParcelasId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound82 = 1;
            A635ReembolsoParcelasValor = T002C5_A635ReembolsoParcelasValor[0];
            n635ReembolsoParcelasValor = T002C5_n635ReembolsoParcelasValor[0];
            AssignAttri("", false, "A635ReembolsoParcelasValor", ((Convert.ToDecimal(0)==A635ReembolsoParcelasValor)&&IsIns( )||n635ReembolsoParcelasValor ? "" : StringUtil.LTrim( StringUtil.NToC( A635ReembolsoParcelasValor, 18, 2, ".", ""))));
            A636ReembolsoParcelasData = T002C5_A636ReembolsoParcelasData[0];
            n636ReembolsoParcelasData = T002C5_n636ReembolsoParcelasData[0];
            AssignAttri("", false, "A636ReembolsoParcelasData", context.localUtil.Format(A636ReembolsoParcelasData, "99/99/9999"));
            A637ReembolsoParcelasObservacao = T002C5_A637ReembolsoParcelasObservacao[0];
            n637ReembolsoParcelasObservacao = T002C5_n637ReembolsoParcelasObservacao[0];
            AssignAttri("", false, "A637ReembolsoParcelasObservacao", A637ReembolsoParcelasObservacao);
            A638ReembolsoParcelasCreatedAt = T002C5_A638ReembolsoParcelasCreatedAt[0];
            n638ReembolsoParcelasCreatedAt = T002C5_n638ReembolsoParcelasCreatedAt[0];
            AssignAttri("", false, "A638ReembolsoParcelasCreatedAt", context.localUtil.TToC( A638ReembolsoParcelasCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A639ReembolsoParcelasTaxaValor = T002C5_A639ReembolsoParcelasTaxaValor[0];
            n639ReembolsoParcelasTaxaValor = T002C5_n639ReembolsoParcelasTaxaValor[0];
            AssignAttri("", false, "A639ReembolsoParcelasTaxaValor", ((Convert.ToDecimal(0)==A639ReembolsoParcelasTaxaValor)&&IsIns( )||n639ReembolsoParcelasTaxaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A639ReembolsoParcelasTaxaValor, 18, 2, ".", ""))));
            A640ReembolsoParcelasJurosValor = T002C5_A640ReembolsoParcelasJurosValor[0];
            n640ReembolsoParcelasJurosValor = T002C5_n640ReembolsoParcelasJurosValor[0];
            AssignAttri("", false, "A640ReembolsoParcelasJurosValor", ((Convert.ToDecimal(0)==A640ReembolsoParcelasJurosValor)&&IsIns( )||n640ReembolsoParcelasJurosValor ? "" : StringUtil.LTrim( StringUtil.NToC( A640ReembolsoParcelasJurosValor, 18, 2, ".", ""))));
            A641ReembolsoParcelasDiasPJuros = T002C5_A641ReembolsoParcelasDiasPJuros[0];
            n641ReembolsoParcelasDiasPJuros = T002C5_n641ReembolsoParcelasDiasPJuros[0];
            AssignAttri("", false, "A641ReembolsoParcelasDiasPJuros", ((0==A641ReembolsoParcelasDiasPJuros)&&IsIns( )||n641ReembolsoParcelasDiasPJuros ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A641ReembolsoParcelasDiasPJuros), 4, 0, ".", ""))));
            A518ReembolsoId = T002C5_A518ReembolsoId[0];
            n518ReembolsoId = T002C5_n518ReembolsoId[0];
            AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            ZM2C82( -2) ;
         }
         pr_default.close(3);
         OnLoadActions2C82( ) ;
      }

      protected void OnLoadActions2C82( )
      {
      }

      protected void CheckExtendedTable2C82( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T002C4 */
         pr_default.execute(2, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A518ReembolsoId) ) )
            {
               GX_msglist.addItem("Não existe 'Reembolso'.", "ForeignKeyNotFound", 1, "REEMBOLSOID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors2C82( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A518ReembolsoId )
      {
         /* Using cursor T002C6 */
         pr_default.execute(4, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A518ReembolsoId) ) )
            {
               GX_msglist.addItem("Não existe 'Reembolso'.", "ForeignKeyNotFound", 1, "REEMBOLSOID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoId_Internalname;
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

      protected void GetKey2C82( )
      {
         /* Using cursor T002C7 */
         pr_default.execute(5, new Object[] {A634ReembolsoParcelasId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound82 = 1;
         }
         else
         {
            RcdFound82 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002C3 */
         pr_default.execute(1, new Object[] {A634ReembolsoParcelasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2C82( 2) ;
            RcdFound82 = 1;
            A634ReembolsoParcelasId = T002C3_A634ReembolsoParcelasId[0];
            AssignAttri("", false, "A634ReembolsoParcelasId", StringUtil.LTrimStr( (decimal)(A634ReembolsoParcelasId), 9, 0));
            A635ReembolsoParcelasValor = T002C3_A635ReembolsoParcelasValor[0];
            n635ReembolsoParcelasValor = T002C3_n635ReembolsoParcelasValor[0];
            AssignAttri("", false, "A635ReembolsoParcelasValor", ((Convert.ToDecimal(0)==A635ReembolsoParcelasValor)&&IsIns( )||n635ReembolsoParcelasValor ? "" : StringUtil.LTrim( StringUtil.NToC( A635ReembolsoParcelasValor, 18, 2, ".", ""))));
            A636ReembolsoParcelasData = T002C3_A636ReembolsoParcelasData[0];
            n636ReembolsoParcelasData = T002C3_n636ReembolsoParcelasData[0];
            AssignAttri("", false, "A636ReembolsoParcelasData", context.localUtil.Format(A636ReembolsoParcelasData, "99/99/9999"));
            A637ReembolsoParcelasObservacao = T002C3_A637ReembolsoParcelasObservacao[0];
            n637ReembolsoParcelasObservacao = T002C3_n637ReembolsoParcelasObservacao[0];
            AssignAttri("", false, "A637ReembolsoParcelasObservacao", A637ReembolsoParcelasObservacao);
            A638ReembolsoParcelasCreatedAt = T002C3_A638ReembolsoParcelasCreatedAt[0];
            n638ReembolsoParcelasCreatedAt = T002C3_n638ReembolsoParcelasCreatedAt[0];
            AssignAttri("", false, "A638ReembolsoParcelasCreatedAt", context.localUtil.TToC( A638ReembolsoParcelasCreatedAt, 8, 5, 0, 3, "/", ":", " "));
            A639ReembolsoParcelasTaxaValor = T002C3_A639ReembolsoParcelasTaxaValor[0];
            n639ReembolsoParcelasTaxaValor = T002C3_n639ReembolsoParcelasTaxaValor[0];
            AssignAttri("", false, "A639ReembolsoParcelasTaxaValor", ((Convert.ToDecimal(0)==A639ReembolsoParcelasTaxaValor)&&IsIns( )||n639ReembolsoParcelasTaxaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A639ReembolsoParcelasTaxaValor, 18, 2, ".", ""))));
            A640ReembolsoParcelasJurosValor = T002C3_A640ReembolsoParcelasJurosValor[0];
            n640ReembolsoParcelasJurosValor = T002C3_n640ReembolsoParcelasJurosValor[0];
            AssignAttri("", false, "A640ReembolsoParcelasJurosValor", ((Convert.ToDecimal(0)==A640ReembolsoParcelasJurosValor)&&IsIns( )||n640ReembolsoParcelasJurosValor ? "" : StringUtil.LTrim( StringUtil.NToC( A640ReembolsoParcelasJurosValor, 18, 2, ".", ""))));
            A641ReembolsoParcelasDiasPJuros = T002C3_A641ReembolsoParcelasDiasPJuros[0];
            n641ReembolsoParcelasDiasPJuros = T002C3_n641ReembolsoParcelasDiasPJuros[0];
            AssignAttri("", false, "A641ReembolsoParcelasDiasPJuros", ((0==A641ReembolsoParcelasDiasPJuros)&&IsIns( )||n641ReembolsoParcelasDiasPJuros ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A641ReembolsoParcelasDiasPJuros), 4, 0, ".", ""))));
            A518ReembolsoId = T002C3_A518ReembolsoId[0];
            n518ReembolsoId = T002C3_n518ReembolsoId[0];
            AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            Z634ReembolsoParcelasId = A634ReembolsoParcelasId;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2C82( ) ;
            if ( AnyError == 1 )
            {
               RcdFound82 = 0;
               InitializeNonKey2C82( ) ;
            }
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound82 = 0;
            InitializeNonKey2C82( ) ;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2C82( ) ;
         if ( RcdFound82 == 0 )
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
         RcdFound82 = 0;
         /* Using cursor T002C8 */
         pr_default.execute(6, new Object[] {A634ReembolsoParcelasId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T002C8_A634ReembolsoParcelasId[0] < A634ReembolsoParcelasId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T002C8_A634ReembolsoParcelasId[0] > A634ReembolsoParcelasId ) ) )
            {
               A634ReembolsoParcelasId = T002C8_A634ReembolsoParcelasId[0];
               AssignAttri("", false, "A634ReembolsoParcelasId", StringUtil.LTrimStr( (decimal)(A634ReembolsoParcelasId), 9, 0));
               RcdFound82 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound82 = 0;
         /* Using cursor T002C9 */
         pr_default.execute(7, new Object[] {A634ReembolsoParcelasId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T002C9_A634ReembolsoParcelasId[0] > A634ReembolsoParcelasId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T002C9_A634ReembolsoParcelasId[0] < A634ReembolsoParcelasId ) ) )
            {
               A634ReembolsoParcelasId = T002C9_A634ReembolsoParcelasId[0];
               AssignAttri("", false, "A634ReembolsoParcelasId", StringUtil.LTrimStr( (decimal)(A634ReembolsoParcelasId), 9, 0));
               RcdFound82 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2C82( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtReembolsoParcelasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2C82( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound82 == 1 )
            {
               if ( A634ReembolsoParcelasId != Z634ReembolsoParcelasId )
               {
                  A634ReembolsoParcelasId = Z634ReembolsoParcelasId;
                  AssignAttri("", false, "A634ReembolsoParcelasId", StringUtil.LTrimStr( (decimal)(A634ReembolsoParcelasId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "REEMBOLSOPARCELASID");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoParcelasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtReembolsoParcelasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2C82( ) ;
                  GX_FocusControl = edtReembolsoParcelasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A634ReembolsoParcelasId != Z634ReembolsoParcelasId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtReembolsoParcelasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2C82( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "REEMBOLSOPARCELASID");
                     AnyError = 1;
                     GX_FocusControl = edtReembolsoParcelasId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtReembolsoParcelasId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2C82( ) ;
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
         if ( A634ReembolsoParcelasId != Z634ReembolsoParcelasId )
         {
            A634ReembolsoParcelasId = Z634ReembolsoParcelasId;
            AssignAttri("", false, "A634ReembolsoParcelasId", StringUtil.LTrimStr( (decimal)(A634ReembolsoParcelasId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "REEMBOLSOPARCELASID");
            AnyError = 1;
            GX_FocusControl = edtReembolsoParcelasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtReembolsoParcelasId_Internalname;
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
         if ( RcdFound82 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "REEMBOLSOPARCELASID");
            AnyError = 1;
            GX_FocusControl = edtReembolsoParcelasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtReembolsoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2C82( ) ;
         if ( RcdFound82 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2C82( ) ;
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
         if ( RcdFound82 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoId_Internalname;
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
         if ( RcdFound82 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoId_Internalname;
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
         ScanStart2C82( ) ;
         if ( RcdFound82 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound82 != 0 )
            {
               ScanNext2C82( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReembolsoId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2C82( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2C82( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002C2 */
            pr_default.execute(0, new Object[] {A634ReembolsoParcelasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoParcelas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z635ReembolsoParcelasValor != T002C2_A635ReembolsoParcelasValor[0] ) || ( DateTimeUtil.ResetTime ( Z636ReembolsoParcelasData ) != DateTimeUtil.ResetTime ( T002C2_A636ReembolsoParcelasData[0] ) ) || ( StringUtil.StrCmp(Z637ReembolsoParcelasObservacao, T002C2_A637ReembolsoParcelasObservacao[0]) != 0 ) || ( Z638ReembolsoParcelasCreatedAt != T002C2_A638ReembolsoParcelasCreatedAt[0] ) || ( Z639ReembolsoParcelasTaxaValor != T002C2_A639ReembolsoParcelasTaxaValor[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z640ReembolsoParcelasJurosValor != T002C2_A640ReembolsoParcelasJurosValor[0] ) || ( Z641ReembolsoParcelasDiasPJuros != T002C2_A641ReembolsoParcelasDiasPJuros[0] ) || ( Z518ReembolsoId != T002C2_A518ReembolsoId[0] ) )
            {
               if ( Z635ReembolsoParcelasValor != T002C2_A635ReembolsoParcelasValor[0] )
               {
                  GXUtil.WriteLog("reembolsoparcelas:[seudo value changed for attri]"+"ReembolsoParcelasValor");
                  GXUtil.WriteLogRaw("Old: ",Z635ReembolsoParcelasValor);
                  GXUtil.WriteLogRaw("Current: ",T002C2_A635ReembolsoParcelasValor[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z636ReembolsoParcelasData ) != DateTimeUtil.ResetTime ( T002C2_A636ReembolsoParcelasData[0] ) )
               {
                  GXUtil.WriteLog("reembolsoparcelas:[seudo value changed for attri]"+"ReembolsoParcelasData");
                  GXUtil.WriteLogRaw("Old: ",Z636ReembolsoParcelasData);
                  GXUtil.WriteLogRaw("Current: ",T002C2_A636ReembolsoParcelasData[0]);
               }
               if ( StringUtil.StrCmp(Z637ReembolsoParcelasObservacao, T002C2_A637ReembolsoParcelasObservacao[0]) != 0 )
               {
                  GXUtil.WriteLog("reembolsoparcelas:[seudo value changed for attri]"+"ReembolsoParcelasObservacao");
                  GXUtil.WriteLogRaw("Old: ",Z637ReembolsoParcelasObservacao);
                  GXUtil.WriteLogRaw("Current: ",T002C2_A637ReembolsoParcelasObservacao[0]);
               }
               if ( Z638ReembolsoParcelasCreatedAt != T002C2_A638ReembolsoParcelasCreatedAt[0] )
               {
                  GXUtil.WriteLog("reembolsoparcelas:[seudo value changed for attri]"+"ReembolsoParcelasCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z638ReembolsoParcelasCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T002C2_A638ReembolsoParcelasCreatedAt[0]);
               }
               if ( Z639ReembolsoParcelasTaxaValor != T002C2_A639ReembolsoParcelasTaxaValor[0] )
               {
                  GXUtil.WriteLog("reembolsoparcelas:[seudo value changed for attri]"+"ReembolsoParcelasTaxaValor");
                  GXUtil.WriteLogRaw("Old: ",Z639ReembolsoParcelasTaxaValor);
                  GXUtil.WriteLogRaw("Current: ",T002C2_A639ReembolsoParcelasTaxaValor[0]);
               }
               if ( Z640ReembolsoParcelasJurosValor != T002C2_A640ReembolsoParcelasJurosValor[0] )
               {
                  GXUtil.WriteLog("reembolsoparcelas:[seudo value changed for attri]"+"ReembolsoParcelasJurosValor");
                  GXUtil.WriteLogRaw("Old: ",Z640ReembolsoParcelasJurosValor);
                  GXUtil.WriteLogRaw("Current: ",T002C2_A640ReembolsoParcelasJurosValor[0]);
               }
               if ( Z641ReembolsoParcelasDiasPJuros != T002C2_A641ReembolsoParcelasDiasPJuros[0] )
               {
                  GXUtil.WriteLog("reembolsoparcelas:[seudo value changed for attri]"+"ReembolsoParcelasDiasPJuros");
                  GXUtil.WriteLogRaw("Old: ",Z641ReembolsoParcelasDiasPJuros);
                  GXUtil.WriteLogRaw("Current: ",T002C2_A641ReembolsoParcelasDiasPJuros[0]);
               }
               if ( Z518ReembolsoId != T002C2_A518ReembolsoId[0] )
               {
                  GXUtil.WriteLog("reembolsoparcelas:[seudo value changed for attri]"+"ReembolsoId");
                  GXUtil.WriteLogRaw("Old: ",Z518ReembolsoId);
                  GXUtil.WriteLogRaw("Current: ",T002C2_A518ReembolsoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ReembolsoParcelas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2C82( )
      {
         BeforeValidate2C82( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2C82( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2C82( 0) ;
            CheckOptimisticConcurrency2C82( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2C82( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2C82( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002C10 */
                     pr_default.execute(8, new Object[] {n635ReembolsoParcelasValor, A635ReembolsoParcelasValor, n636ReembolsoParcelasData, A636ReembolsoParcelasData, n637ReembolsoParcelasObservacao, A637ReembolsoParcelasObservacao, n638ReembolsoParcelasCreatedAt, A638ReembolsoParcelasCreatedAt, n639ReembolsoParcelasTaxaValor, A639ReembolsoParcelasTaxaValor, n640ReembolsoParcelasJurosValor, A640ReembolsoParcelasJurosValor, n641ReembolsoParcelasDiasPJuros, A641ReembolsoParcelasDiasPJuros, n518ReembolsoId, A518ReembolsoId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002C11 */
                     pr_default.execute(9);
                     A634ReembolsoParcelasId = T002C11_A634ReembolsoParcelasId[0];
                     AssignAttri("", false, "A634ReembolsoParcelasId", StringUtil.LTrimStr( (decimal)(A634ReembolsoParcelasId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoParcelas");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2C0( ) ;
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
               Load2C82( ) ;
            }
            EndLevel2C82( ) ;
         }
         CloseExtendedTableCursors2C82( ) ;
      }

      protected void Update2C82( )
      {
         BeforeValidate2C82( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2C82( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2C82( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2C82( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2C82( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002C12 */
                     pr_default.execute(10, new Object[] {n635ReembolsoParcelasValor, A635ReembolsoParcelasValor, n636ReembolsoParcelasData, A636ReembolsoParcelasData, n637ReembolsoParcelasObservacao, A637ReembolsoParcelasObservacao, n638ReembolsoParcelasCreatedAt, A638ReembolsoParcelasCreatedAt, n639ReembolsoParcelasTaxaValor, A639ReembolsoParcelasTaxaValor, n640ReembolsoParcelasJurosValor, A640ReembolsoParcelasJurosValor, n641ReembolsoParcelasDiasPJuros, A641ReembolsoParcelasDiasPJuros, n518ReembolsoId, A518ReembolsoId, A634ReembolsoParcelasId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoParcelas");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoParcelas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2C82( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2C0( ) ;
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
            EndLevel2C82( ) ;
         }
         CloseExtendedTableCursors2C82( ) ;
      }

      protected void DeferredUpdate2C82( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2C82( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2C82( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2C82( ) ;
            AfterConfirm2C82( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2C82( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002C13 */
                  pr_default.execute(11, new Object[] {A634ReembolsoParcelasId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("ReembolsoParcelas");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound82 == 0 )
                        {
                           InitAll2C82( ) ;
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
                        ResetCaption2C0( ) ;
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
         sMode82 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2C82( ) ;
         Gx_mode = sMode82;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2C82( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2C82( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2C82( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2C0( ) ;
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

      public void ScanStart2C82( )
      {
         /* Using cursor T002C14 */
         pr_default.execute(12);
         RcdFound82 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound82 = 1;
            A634ReembolsoParcelasId = T002C14_A634ReembolsoParcelasId[0];
            AssignAttri("", false, "A634ReembolsoParcelasId", StringUtil.LTrimStr( (decimal)(A634ReembolsoParcelasId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2C82( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound82 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound82 = 1;
            A634ReembolsoParcelasId = T002C14_A634ReembolsoParcelasId[0];
            AssignAttri("", false, "A634ReembolsoParcelasId", StringUtil.LTrimStr( (decimal)(A634ReembolsoParcelasId), 9, 0));
         }
      }

      protected void ScanEnd2C82( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm2C82( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2C82( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2C82( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2C82( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2C82( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2C82( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2C82( )
      {
         edtReembolsoParcelasId_Enabled = 0;
         AssignProp("", false, edtReembolsoParcelasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoParcelasId_Enabled), 5, 0), true);
         edtReembolsoId_Enabled = 0;
         AssignProp("", false, edtReembolsoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoId_Enabled), 5, 0), true);
         edtReembolsoParcelasValor_Enabled = 0;
         AssignProp("", false, edtReembolsoParcelasValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoParcelasValor_Enabled), 5, 0), true);
         edtReembolsoParcelasData_Enabled = 0;
         AssignProp("", false, edtReembolsoParcelasData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoParcelasData_Enabled), 5, 0), true);
         edtReembolsoParcelasObservacao_Enabled = 0;
         AssignProp("", false, edtReembolsoParcelasObservacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoParcelasObservacao_Enabled), 5, 0), true);
         edtReembolsoParcelasCreatedAt_Enabled = 0;
         AssignProp("", false, edtReembolsoParcelasCreatedAt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoParcelasCreatedAt_Enabled), 5, 0), true);
         edtReembolsoParcelasTaxaValor_Enabled = 0;
         AssignProp("", false, edtReembolsoParcelasTaxaValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoParcelasTaxaValor_Enabled), 5, 0), true);
         edtReembolsoParcelasJurosValor_Enabled = 0;
         AssignProp("", false, edtReembolsoParcelasJurosValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoParcelasJurosValor_Enabled), 5, 0), true);
         edtReembolsoParcelasDiasPJuros_Enabled = 0;
         AssignProp("", false, edtReembolsoParcelasDiasPJuros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoParcelasDiasPJuros_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2C82( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2C0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reembolsoparcelas") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z634ReembolsoParcelasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z634ReembolsoParcelasId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z635ReembolsoParcelasValor", StringUtil.LTrim( StringUtil.NToC( Z635ReembolsoParcelasValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z636ReembolsoParcelasData", context.localUtil.DToC( Z636ReembolsoParcelasData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z637ReembolsoParcelasObservacao", Z637ReembolsoParcelasObservacao);
         GxWebStd.gx_hidden_field( context, "Z638ReembolsoParcelasCreatedAt", context.localUtil.TToC( Z638ReembolsoParcelasCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z639ReembolsoParcelasTaxaValor", StringUtil.LTrim( StringUtil.NToC( Z639ReembolsoParcelasTaxaValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z640ReembolsoParcelasJurosValor", StringUtil.LTrim( StringUtil.NToC( Z640ReembolsoParcelasJurosValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z641ReembolsoParcelasDiasPJuros", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z641ReembolsoParcelasDiasPJuros), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z518ReembolsoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z518ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
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
         return formatLink("reembolsoparcelas")  ;
      }

      public override string GetPgmname( )
      {
         return "ReembolsoParcelas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reembolso Parcelas" ;
      }

      protected void InitializeNonKey2C82( )
      {
         A518ReembolsoId = 0;
         n518ReembolsoId = false;
         AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
         n518ReembolsoId = ((0==A518ReembolsoId) ? true : false);
         A635ReembolsoParcelasValor = 0;
         n635ReembolsoParcelasValor = false;
         AssignAttri("", false, "A635ReembolsoParcelasValor", ((Convert.ToDecimal(0)==A635ReembolsoParcelasValor)&&IsIns( )||n635ReembolsoParcelasValor ? "" : StringUtil.LTrim( StringUtil.NToC( A635ReembolsoParcelasValor, 18, 2, ".", ""))));
         n635ReembolsoParcelasValor = ((Convert.ToDecimal(0)==A635ReembolsoParcelasValor) ? true : false);
         A636ReembolsoParcelasData = DateTime.MinValue;
         n636ReembolsoParcelasData = false;
         AssignAttri("", false, "A636ReembolsoParcelasData", context.localUtil.Format(A636ReembolsoParcelasData, "99/99/9999"));
         n636ReembolsoParcelasData = ((DateTime.MinValue==A636ReembolsoParcelasData) ? true : false);
         A637ReembolsoParcelasObservacao = "";
         n637ReembolsoParcelasObservacao = false;
         AssignAttri("", false, "A637ReembolsoParcelasObservacao", A637ReembolsoParcelasObservacao);
         n637ReembolsoParcelasObservacao = (String.IsNullOrEmpty(StringUtil.RTrim( A637ReembolsoParcelasObservacao)) ? true : false);
         A639ReembolsoParcelasTaxaValor = 0;
         n639ReembolsoParcelasTaxaValor = false;
         AssignAttri("", false, "A639ReembolsoParcelasTaxaValor", ((Convert.ToDecimal(0)==A639ReembolsoParcelasTaxaValor)&&IsIns( )||n639ReembolsoParcelasTaxaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A639ReembolsoParcelasTaxaValor, 18, 2, ".", ""))));
         n639ReembolsoParcelasTaxaValor = ((Convert.ToDecimal(0)==A639ReembolsoParcelasTaxaValor) ? true : false);
         A640ReembolsoParcelasJurosValor = 0;
         n640ReembolsoParcelasJurosValor = false;
         AssignAttri("", false, "A640ReembolsoParcelasJurosValor", ((Convert.ToDecimal(0)==A640ReembolsoParcelasJurosValor)&&IsIns( )||n640ReembolsoParcelasJurosValor ? "" : StringUtil.LTrim( StringUtil.NToC( A640ReembolsoParcelasJurosValor, 18, 2, ".", ""))));
         n640ReembolsoParcelasJurosValor = ((Convert.ToDecimal(0)==A640ReembolsoParcelasJurosValor) ? true : false);
         A641ReembolsoParcelasDiasPJuros = 0;
         n641ReembolsoParcelasDiasPJuros = false;
         AssignAttri("", false, "A641ReembolsoParcelasDiasPJuros", ((0==A641ReembolsoParcelasDiasPJuros)&&IsIns( )||n641ReembolsoParcelasDiasPJuros ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A641ReembolsoParcelasDiasPJuros), 4, 0, ".", ""))));
         n641ReembolsoParcelasDiasPJuros = ((0==A641ReembolsoParcelasDiasPJuros) ? true : false);
         A638ReembolsoParcelasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n638ReembolsoParcelasCreatedAt = false;
         AssignAttri("", false, "A638ReembolsoParcelasCreatedAt", context.localUtil.TToC( A638ReembolsoParcelasCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         Z635ReembolsoParcelasValor = 0;
         Z636ReembolsoParcelasData = DateTime.MinValue;
         Z637ReembolsoParcelasObservacao = "";
         Z638ReembolsoParcelasCreatedAt = (DateTime)(DateTime.MinValue);
         Z639ReembolsoParcelasTaxaValor = 0;
         Z640ReembolsoParcelasJurosValor = 0;
         Z641ReembolsoParcelasDiasPJuros = 0;
         Z518ReembolsoId = 0;
      }

      protected void InitAll2C82( )
      {
         A634ReembolsoParcelasId = 0;
         AssignAttri("", false, "A634ReembolsoParcelasId", StringUtil.LTrimStr( (decimal)(A634ReembolsoParcelasId), 9, 0));
         InitializeNonKey2C82( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A638ReembolsoParcelasCreatedAt = i638ReembolsoParcelasCreatedAt;
         n638ReembolsoParcelasCreatedAt = false;
         AssignAttri("", false, "A638ReembolsoParcelasCreatedAt", context.localUtil.TToC( A638ReembolsoParcelasCreatedAt, 8, 5, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019193864", true, true);
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
         context.AddJavascriptSource("reembolsoparcelas.js", "?202561019193865", false, true);
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
         edtReembolsoParcelasId_Internalname = "REEMBOLSOPARCELASID";
         edtReembolsoId_Internalname = "REEMBOLSOID";
         edtReembolsoParcelasValor_Internalname = "REEMBOLSOPARCELASVALOR";
         edtReembolsoParcelasData_Internalname = "REEMBOLSOPARCELASDATA";
         edtReembolsoParcelasObservacao_Internalname = "REEMBOLSOPARCELASOBSERVACAO";
         edtReembolsoParcelasCreatedAt_Internalname = "REEMBOLSOPARCELASCREATEDAT";
         edtReembolsoParcelasTaxaValor_Internalname = "REEMBOLSOPARCELASTAXAVALOR";
         edtReembolsoParcelasJurosValor_Internalname = "REEMBOLSOPARCELASJUROSVALOR";
         edtReembolsoParcelasDiasPJuros_Internalname = "REEMBOLSOPARCELASDIASPJUROS";
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
         Form.Caption = "Reembolso Parcelas";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtReembolsoParcelasDiasPJuros_Jsonclick = "";
         edtReembolsoParcelasDiasPJuros_Enabled = 1;
         edtReembolsoParcelasJurosValor_Jsonclick = "";
         edtReembolsoParcelasJurosValor_Enabled = 1;
         edtReembolsoParcelasTaxaValor_Jsonclick = "";
         edtReembolsoParcelasTaxaValor_Enabled = 1;
         edtReembolsoParcelasCreatedAt_Jsonclick = "";
         edtReembolsoParcelasCreatedAt_Enabled = 1;
         edtReembolsoParcelasObservacao_Jsonclick = "";
         edtReembolsoParcelasObservacao_Enabled = 1;
         edtReembolsoParcelasData_Jsonclick = "";
         edtReembolsoParcelasData_Enabled = 1;
         edtReembolsoParcelasValor_Jsonclick = "";
         edtReembolsoParcelasValor_Enabled = 1;
         edtReembolsoId_Jsonclick = "";
         edtReembolsoId_Enabled = 1;
         edtReembolsoParcelasId_Jsonclick = "";
         edtReembolsoParcelasId_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtReembolsoId_Internalname;
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

      public void Valid_Reembolsoparcelasid( )
      {
         n638ReembolsoParcelasCreatedAt = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
         AssignAttri("", false, "A635ReembolsoParcelasValor", ((Convert.ToDecimal(0)==A635ReembolsoParcelasValor)&&IsIns( )||n635ReembolsoParcelasValor ? "" : StringUtil.LTrim( StringUtil.NToC( A635ReembolsoParcelasValor, 18, 2, ".", ""))));
         AssignAttri("", false, "A636ReembolsoParcelasData", context.localUtil.Format(A636ReembolsoParcelasData, "99/99/9999"));
         AssignAttri("", false, "A637ReembolsoParcelasObservacao", A637ReembolsoParcelasObservacao);
         AssignAttri("", false, "A638ReembolsoParcelasCreatedAt", context.localUtil.TToC( A638ReembolsoParcelasCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A639ReembolsoParcelasTaxaValor", ((Convert.ToDecimal(0)==A639ReembolsoParcelasTaxaValor)&&IsIns( )||n639ReembolsoParcelasTaxaValor ? "" : StringUtil.LTrim( StringUtil.NToC( A639ReembolsoParcelasTaxaValor, 18, 2, ".", ""))));
         AssignAttri("", false, "A640ReembolsoParcelasJurosValor", ((Convert.ToDecimal(0)==A640ReembolsoParcelasJurosValor)&&IsIns( )||n640ReembolsoParcelasJurosValor ? "" : StringUtil.LTrim( StringUtil.NToC( A640ReembolsoParcelasJurosValor, 18, 2, ".", ""))));
         AssignAttri("", false, "A641ReembolsoParcelasDiasPJuros", ((0==A641ReembolsoParcelasDiasPJuros)&&IsIns( )||n641ReembolsoParcelasDiasPJuros ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A641ReembolsoParcelasDiasPJuros), 4, 0, ".", ""))));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z634ReembolsoParcelasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z634ReembolsoParcelasId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z518ReembolsoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z518ReembolsoId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z635ReembolsoParcelasValor", StringUtil.LTrim( StringUtil.NToC( Z635ReembolsoParcelasValor, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z636ReembolsoParcelasData", context.localUtil.Format(Z636ReembolsoParcelasData, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z637ReembolsoParcelasObservacao", Z637ReembolsoParcelasObservacao);
         GxWebStd.gx_hidden_field( context, "Z638ReembolsoParcelasCreatedAt", context.localUtil.TToC( Z638ReembolsoParcelasCreatedAt, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z639ReembolsoParcelasTaxaValor", StringUtil.LTrim( StringUtil.NToC( Z639ReembolsoParcelasTaxaValor, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z640ReembolsoParcelasJurosValor", StringUtil.LTrim( StringUtil.NToC( Z640ReembolsoParcelasJurosValor, 18, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z641ReembolsoParcelasDiasPJuros", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z641ReembolsoParcelasDiasPJuros), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Reembolsoid( )
      {
         /* Using cursor T002C15 */
         pr_default.execute(13, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A518ReembolsoId) ) )
            {
               GX_msglist.addItem("Não existe 'Reembolso'.", "ForeignKeyNotFound", 1, "REEMBOLSOID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoId_Internalname;
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
         setEventMetadata("VALID_REEMBOLSOPARCELASID","""{"handler":"Valid_Reembolsoparcelasid","iparms":[{"av":"A634ReembolsoParcelasId","fld":"REEMBOLSOPARCELASID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A638ReembolsoParcelasCreatedAt","fld":"REEMBOLSOPARCELASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"}]""");
         setEventMetadata("VALID_REEMBOLSOPARCELASID",""","oparms":[{"av":"A518ReembolsoId","fld":"REEMBOLSOID","pic":"ZZZZZZZZ9","nullAv":"n518ReembolsoId","type":"int"},{"av":"A635ReembolsoParcelasValor","fld":"REEMBOLSOPARCELASVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","nullAv":"n635ReembolsoParcelasValor","type":"decimal"},{"av":"A636ReembolsoParcelasData","fld":"REEMBOLSOPARCELASDATA","type":"date"},{"av":"A637ReembolsoParcelasObservacao","fld":"REEMBOLSOPARCELASOBSERVACAO","type":"svchar"},{"av":"A638ReembolsoParcelasCreatedAt","fld":"REEMBOLSOPARCELASCREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A639ReembolsoParcelasTaxaValor","fld":"REEMBOLSOPARCELASTAXAVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","nullAv":"n639ReembolsoParcelasTaxaValor","type":"decimal"},{"av":"A640ReembolsoParcelasJurosValor","fld":"REEMBOLSOPARCELASJUROSVALOR","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","nullAv":"n640ReembolsoParcelasJurosValor","type":"decimal"},{"av":"A641ReembolsoParcelasDiasPJuros","fld":"REEMBOLSOPARCELASDIASPJUROS","pic":"ZZZ9","nullAv":"n641ReembolsoParcelasDiasPJuros","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z634ReembolsoParcelasId","type":"int"},{"av":"Z518ReembolsoId","type":"int"},{"av":"Z635ReembolsoParcelasValor","type":"decimal"},{"av":"Z636ReembolsoParcelasData","type":"date"},{"av":"Z637ReembolsoParcelasObservacao","type":"svchar"},{"av":"Z638ReembolsoParcelasCreatedAt","type":"dtime"},{"av":"Z639ReembolsoParcelasTaxaValor","type":"decimal"},{"av":"Z640ReembolsoParcelasJurosValor","type":"decimal"},{"av":"Z641ReembolsoParcelasDiasPJuros","type":"int"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_REEMBOLSOID","""{"handler":"Valid_Reembolsoid","iparms":[{"av":"A518ReembolsoId","fld":"REEMBOLSOID","pic":"ZZZZZZZZ9","nullAv":"n518ReembolsoId","type":"int"}]}""");
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
         Z636ReembolsoParcelasData = DateTime.MinValue;
         Z637ReembolsoParcelasObservacao = "";
         Z638ReembolsoParcelasCreatedAt = (DateTime)(DateTime.MinValue);
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
         A636ReembolsoParcelasData = DateTime.MinValue;
         A637ReembolsoParcelasObservacao = "";
         A638ReembolsoParcelasCreatedAt = (DateTime)(DateTime.MinValue);
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
         T002C5_A634ReembolsoParcelasId = new int[1] ;
         T002C5_A635ReembolsoParcelasValor = new decimal[1] ;
         T002C5_n635ReembolsoParcelasValor = new bool[] {false} ;
         T002C5_A636ReembolsoParcelasData = new DateTime[] {DateTime.MinValue} ;
         T002C5_n636ReembolsoParcelasData = new bool[] {false} ;
         T002C5_A637ReembolsoParcelasObservacao = new string[] {""} ;
         T002C5_n637ReembolsoParcelasObservacao = new bool[] {false} ;
         T002C5_A638ReembolsoParcelasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002C5_n638ReembolsoParcelasCreatedAt = new bool[] {false} ;
         T002C5_A639ReembolsoParcelasTaxaValor = new decimal[1] ;
         T002C5_n639ReembolsoParcelasTaxaValor = new bool[] {false} ;
         T002C5_A640ReembolsoParcelasJurosValor = new decimal[1] ;
         T002C5_n640ReembolsoParcelasJurosValor = new bool[] {false} ;
         T002C5_A641ReembolsoParcelasDiasPJuros = new short[1] ;
         T002C5_n641ReembolsoParcelasDiasPJuros = new bool[] {false} ;
         T002C5_A518ReembolsoId = new int[1] ;
         T002C5_n518ReembolsoId = new bool[] {false} ;
         T002C4_A518ReembolsoId = new int[1] ;
         T002C4_n518ReembolsoId = new bool[] {false} ;
         T002C6_A518ReembolsoId = new int[1] ;
         T002C6_n518ReembolsoId = new bool[] {false} ;
         T002C7_A634ReembolsoParcelasId = new int[1] ;
         T002C3_A634ReembolsoParcelasId = new int[1] ;
         T002C3_A635ReembolsoParcelasValor = new decimal[1] ;
         T002C3_n635ReembolsoParcelasValor = new bool[] {false} ;
         T002C3_A636ReembolsoParcelasData = new DateTime[] {DateTime.MinValue} ;
         T002C3_n636ReembolsoParcelasData = new bool[] {false} ;
         T002C3_A637ReembolsoParcelasObservacao = new string[] {""} ;
         T002C3_n637ReembolsoParcelasObservacao = new bool[] {false} ;
         T002C3_A638ReembolsoParcelasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002C3_n638ReembolsoParcelasCreatedAt = new bool[] {false} ;
         T002C3_A639ReembolsoParcelasTaxaValor = new decimal[1] ;
         T002C3_n639ReembolsoParcelasTaxaValor = new bool[] {false} ;
         T002C3_A640ReembolsoParcelasJurosValor = new decimal[1] ;
         T002C3_n640ReembolsoParcelasJurosValor = new bool[] {false} ;
         T002C3_A641ReembolsoParcelasDiasPJuros = new short[1] ;
         T002C3_n641ReembolsoParcelasDiasPJuros = new bool[] {false} ;
         T002C3_A518ReembolsoId = new int[1] ;
         T002C3_n518ReembolsoId = new bool[] {false} ;
         sMode82 = "";
         T002C8_A634ReembolsoParcelasId = new int[1] ;
         T002C9_A634ReembolsoParcelasId = new int[1] ;
         T002C2_A634ReembolsoParcelasId = new int[1] ;
         T002C2_A635ReembolsoParcelasValor = new decimal[1] ;
         T002C2_n635ReembolsoParcelasValor = new bool[] {false} ;
         T002C2_A636ReembolsoParcelasData = new DateTime[] {DateTime.MinValue} ;
         T002C2_n636ReembolsoParcelasData = new bool[] {false} ;
         T002C2_A637ReembolsoParcelasObservacao = new string[] {""} ;
         T002C2_n637ReembolsoParcelasObservacao = new bool[] {false} ;
         T002C2_A638ReembolsoParcelasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T002C2_n638ReembolsoParcelasCreatedAt = new bool[] {false} ;
         T002C2_A639ReembolsoParcelasTaxaValor = new decimal[1] ;
         T002C2_n639ReembolsoParcelasTaxaValor = new bool[] {false} ;
         T002C2_A640ReembolsoParcelasJurosValor = new decimal[1] ;
         T002C2_n640ReembolsoParcelasJurosValor = new bool[] {false} ;
         T002C2_A641ReembolsoParcelasDiasPJuros = new short[1] ;
         T002C2_n641ReembolsoParcelasDiasPJuros = new bool[] {false} ;
         T002C2_A518ReembolsoId = new int[1] ;
         T002C2_n518ReembolsoId = new bool[] {false} ;
         T002C11_A634ReembolsoParcelasId = new int[1] ;
         T002C14_A634ReembolsoParcelasId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i638ReembolsoParcelasCreatedAt = (DateTime)(DateTime.MinValue);
         ZZ636ReembolsoParcelasData = DateTime.MinValue;
         ZZ637ReembolsoParcelasObservacao = "";
         ZZ638ReembolsoParcelasCreatedAt = (DateTime)(DateTime.MinValue);
         T002C15_A518ReembolsoId = new int[1] ;
         T002C15_n518ReembolsoId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoparcelas__default(),
            new Object[][] {
                new Object[] {
               T002C2_A634ReembolsoParcelasId, T002C2_A635ReembolsoParcelasValor, T002C2_n635ReembolsoParcelasValor, T002C2_A636ReembolsoParcelasData, T002C2_n636ReembolsoParcelasData, T002C2_A637ReembolsoParcelasObservacao, T002C2_n637ReembolsoParcelasObservacao, T002C2_A638ReembolsoParcelasCreatedAt, T002C2_n638ReembolsoParcelasCreatedAt, T002C2_A639ReembolsoParcelasTaxaValor,
               T002C2_n639ReembolsoParcelasTaxaValor, T002C2_A640ReembolsoParcelasJurosValor, T002C2_n640ReembolsoParcelasJurosValor, T002C2_A641ReembolsoParcelasDiasPJuros, T002C2_n641ReembolsoParcelasDiasPJuros, T002C2_A518ReembolsoId, T002C2_n518ReembolsoId
               }
               , new Object[] {
               T002C3_A634ReembolsoParcelasId, T002C3_A635ReembolsoParcelasValor, T002C3_n635ReembolsoParcelasValor, T002C3_A636ReembolsoParcelasData, T002C3_n636ReembolsoParcelasData, T002C3_A637ReembolsoParcelasObservacao, T002C3_n637ReembolsoParcelasObservacao, T002C3_A638ReembolsoParcelasCreatedAt, T002C3_n638ReembolsoParcelasCreatedAt, T002C3_A639ReembolsoParcelasTaxaValor,
               T002C3_n639ReembolsoParcelasTaxaValor, T002C3_A640ReembolsoParcelasJurosValor, T002C3_n640ReembolsoParcelasJurosValor, T002C3_A641ReembolsoParcelasDiasPJuros, T002C3_n641ReembolsoParcelasDiasPJuros, T002C3_A518ReembolsoId, T002C3_n518ReembolsoId
               }
               , new Object[] {
               T002C4_A518ReembolsoId
               }
               , new Object[] {
               T002C5_A634ReembolsoParcelasId, T002C5_A635ReembolsoParcelasValor, T002C5_n635ReembolsoParcelasValor, T002C5_A636ReembolsoParcelasData, T002C5_n636ReembolsoParcelasData, T002C5_A637ReembolsoParcelasObservacao, T002C5_n637ReembolsoParcelasObservacao, T002C5_A638ReembolsoParcelasCreatedAt, T002C5_n638ReembolsoParcelasCreatedAt, T002C5_A639ReembolsoParcelasTaxaValor,
               T002C5_n639ReembolsoParcelasTaxaValor, T002C5_A640ReembolsoParcelasJurosValor, T002C5_n640ReembolsoParcelasJurosValor, T002C5_A641ReembolsoParcelasDiasPJuros, T002C5_n641ReembolsoParcelasDiasPJuros, T002C5_A518ReembolsoId, T002C5_n518ReembolsoId
               }
               , new Object[] {
               T002C6_A518ReembolsoId
               }
               , new Object[] {
               T002C7_A634ReembolsoParcelasId
               }
               , new Object[] {
               T002C8_A634ReembolsoParcelasId
               }
               , new Object[] {
               T002C9_A634ReembolsoParcelasId
               }
               , new Object[] {
               }
               , new Object[] {
               T002C11_A634ReembolsoParcelasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002C14_A634ReembolsoParcelasId
               }
               , new Object[] {
               T002C15_A518ReembolsoId
               }
            }
         );
         Z638ReembolsoParcelasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n638ReembolsoParcelasCreatedAt = false;
         A638ReembolsoParcelasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n638ReembolsoParcelasCreatedAt = false;
         i638ReembolsoParcelasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n638ReembolsoParcelasCreatedAt = false;
      }

      private short Z641ReembolsoParcelasDiasPJuros ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A641ReembolsoParcelasDiasPJuros ;
      private short Gx_BScreen ;
      private short RcdFound82 ;
      private short gxajaxcallmode ;
      private short ZZ641ReembolsoParcelasDiasPJuros ;
      private int Z634ReembolsoParcelasId ;
      private int Z518ReembolsoId ;
      private int A518ReembolsoId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A634ReembolsoParcelasId ;
      private int edtReembolsoParcelasId_Enabled ;
      private int edtReembolsoId_Enabled ;
      private int edtReembolsoParcelasValor_Enabled ;
      private int edtReembolsoParcelasData_Enabled ;
      private int edtReembolsoParcelasObservacao_Enabled ;
      private int edtReembolsoParcelasCreatedAt_Enabled ;
      private int edtReembolsoParcelasTaxaValor_Enabled ;
      private int edtReembolsoParcelasJurosValor_Enabled ;
      private int edtReembolsoParcelasDiasPJuros_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ634ReembolsoParcelasId ;
      private int ZZ518ReembolsoId ;
      private decimal Z635ReembolsoParcelasValor ;
      private decimal Z639ReembolsoParcelasTaxaValor ;
      private decimal Z640ReembolsoParcelasJurosValor ;
      private decimal A635ReembolsoParcelasValor ;
      private decimal A639ReembolsoParcelasTaxaValor ;
      private decimal A640ReembolsoParcelasJurosValor ;
      private decimal ZZ635ReembolsoParcelasValor ;
      private decimal ZZ639ReembolsoParcelasTaxaValor ;
      private decimal ZZ640ReembolsoParcelasJurosValor ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtReembolsoParcelasId_Internalname ;
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
      private string edtReembolsoParcelasId_Jsonclick ;
      private string edtReembolsoId_Internalname ;
      private string edtReembolsoId_Jsonclick ;
      private string edtReembolsoParcelasValor_Internalname ;
      private string edtReembolsoParcelasValor_Jsonclick ;
      private string edtReembolsoParcelasData_Internalname ;
      private string edtReembolsoParcelasData_Jsonclick ;
      private string edtReembolsoParcelasObservacao_Internalname ;
      private string edtReembolsoParcelasObservacao_Jsonclick ;
      private string edtReembolsoParcelasCreatedAt_Internalname ;
      private string edtReembolsoParcelasCreatedAt_Jsonclick ;
      private string edtReembolsoParcelasTaxaValor_Internalname ;
      private string edtReembolsoParcelasTaxaValor_Jsonclick ;
      private string edtReembolsoParcelasJurosValor_Internalname ;
      private string edtReembolsoParcelasJurosValor_Jsonclick ;
      private string edtReembolsoParcelasDiasPJuros_Internalname ;
      private string edtReembolsoParcelasDiasPJuros_Jsonclick ;
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
      private string sMode82 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z638ReembolsoParcelasCreatedAt ;
      private DateTime A638ReembolsoParcelasCreatedAt ;
      private DateTime i638ReembolsoParcelasCreatedAt ;
      private DateTime ZZ638ReembolsoParcelasCreatedAt ;
      private DateTime Z636ReembolsoParcelasData ;
      private DateTime A636ReembolsoParcelasData ;
      private DateTime ZZ636ReembolsoParcelasData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n518ReembolsoId ;
      private bool wbErr ;
      private bool n635ReembolsoParcelasValor ;
      private bool n639ReembolsoParcelasTaxaValor ;
      private bool n640ReembolsoParcelasJurosValor ;
      private bool n641ReembolsoParcelasDiasPJuros ;
      private bool n636ReembolsoParcelasData ;
      private bool n637ReembolsoParcelasObservacao ;
      private bool n638ReembolsoParcelasCreatedAt ;
      private bool Gx_longc ;
      private string Z637ReembolsoParcelasObservacao ;
      private string A637ReembolsoParcelasObservacao ;
      private string ZZ637ReembolsoParcelasObservacao ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T002C5_A634ReembolsoParcelasId ;
      private decimal[] T002C5_A635ReembolsoParcelasValor ;
      private bool[] T002C5_n635ReembolsoParcelasValor ;
      private DateTime[] T002C5_A636ReembolsoParcelasData ;
      private bool[] T002C5_n636ReembolsoParcelasData ;
      private string[] T002C5_A637ReembolsoParcelasObservacao ;
      private bool[] T002C5_n637ReembolsoParcelasObservacao ;
      private DateTime[] T002C5_A638ReembolsoParcelasCreatedAt ;
      private bool[] T002C5_n638ReembolsoParcelasCreatedAt ;
      private decimal[] T002C5_A639ReembolsoParcelasTaxaValor ;
      private bool[] T002C5_n639ReembolsoParcelasTaxaValor ;
      private decimal[] T002C5_A640ReembolsoParcelasJurosValor ;
      private bool[] T002C5_n640ReembolsoParcelasJurosValor ;
      private short[] T002C5_A641ReembolsoParcelasDiasPJuros ;
      private bool[] T002C5_n641ReembolsoParcelasDiasPJuros ;
      private int[] T002C5_A518ReembolsoId ;
      private bool[] T002C5_n518ReembolsoId ;
      private int[] T002C4_A518ReembolsoId ;
      private bool[] T002C4_n518ReembolsoId ;
      private int[] T002C6_A518ReembolsoId ;
      private bool[] T002C6_n518ReembolsoId ;
      private int[] T002C7_A634ReembolsoParcelasId ;
      private int[] T002C3_A634ReembolsoParcelasId ;
      private decimal[] T002C3_A635ReembolsoParcelasValor ;
      private bool[] T002C3_n635ReembolsoParcelasValor ;
      private DateTime[] T002C3_A636ReembolsoParcelasData ;
      private bool[] T002C3_n636ReembolsoParcelasData ;
      private string[] T002C3_A637ReembolsoParcelasObservacao ;
      private bool[] T002C3_n637ReembolsoParcelasObservacao ;
      private DateTime[] T002C3_A638ReembolsoParcelasCreatedAt ;
      private bool[] T002C3_n638ReembolsoParcelasCreatedAt ;
      private decimal[] T002C3_A639ReembolsoParcelasTaxaValor ;
      private bool[] T002C3_n639ReembolsoParcelasTaxaValor ;
      private decimal[] T002C3_A640ReembolsoParcelasJurosValor ;
      private bool[] T002C3_n640ReembolsoParcelasJurosValor ;
      private short[] T002C3_A641ReembolsoParcelasDiasPJuros ;
      private bool[] T002C3_n641ReembolsoParcelasDiasPJuros ;
      private int[] T002C3_A518ReembolsoId ;
      private bool[] T002C3_n518ReembolsoId ;
      private int[] T002C8_A634ReembolsoParcelasId ;
      private int[] T002C9_A634ReembolsoParcelasId ;
      private int[] T002C2_A634ReembolsoParcelasId ;
      private decimal[] T002C2_A635ReembolsoParcelasValor ;
      private bool[] T002C2_n635ReembolsoParcelasValor ;
      private DateTime[] T002C2_A636ReembolsoParcelasData ;
      private bool[] T002C2_n636ReembolsoParcelasData ;
      private string[] T002C2_A637ReembolsoParcelasObservacao ;
      private bool[] T002C2_n637ReembolsoParcelasObservacao ;
      private DateTime[] T002C2_A638ReembolsoParcelasCreatedAt ;
      private bool[] T002C2_n638ReembolsoParcelasCreatedAt ;
      private decimal[] T002C2_A639ReembolsoParcelasTaxaValor ;
      private bool[] T002C2_n639ReembolsoParcelasTaxaValor ;
      private decimal[] T002C2_A640ReembolsoParcelasJurosValor ;
      private bool[] T002C2_n640ReembolsoParcelasJurosValor ;
      private short[] T002C2_A641ReembolsoParcelasDiasPJuros ;
      private bool[] T002C2_n641ReembolsoParcelasDiasPJuros ;
      private int[] T002C2_A518ReembolsoId ;
      private bool[] T002C2_n518ReembolsoId ;
      private int[] T002C11_A634ReembolsoParcelasId ;
      private int[] T002C14_A634ReembolsoParcelasId ;
      private int[] T002C15_A518ReembolsoId ;
      private bool[] T002C15_n518ReembolsoId ;
   }

   public class reembolsoparcelas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT002C2;
          prmT002C2 = new Object[] {
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmT002C3;
          prmT002C3 = new Object[] {
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmT002C4;
          prmT002C4 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002C5;
          prmT002C5 = new Object[] {
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmT002C6;
          prmT002C6 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002C7;
          prmT002C7 = new Object[] {
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmT002C8;
          prmT002C8 = new Object[] {
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmT002C9;
          prmT002C9 = new Object[] {
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmT002C10;
          prmT002C10 = new Object[] {
          new ParDef("ReembolsoParcelasValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ReembolsoParcelasData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ReembolsoParcelasObservacao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ReembolsoParcelasCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoParcelasTaxaValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ReembolsoParcelasJurosValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ReembolsoParcelasDiasPJuros",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002C11;
          prmT002C11 = new Object[] {
          };
          Object[] prmT002C12;
          prmT002C12 = new Object[] {
          new ParDef("ReembolsoParcelasValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ReembolsoParcelasData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ReembolsoParcelasObservacao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ReembolsoParcelasCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoParcelasTaxaValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ReembolsoParcelasJurosValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ReembolsoParcelasDiasPJuros",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmT002C13;
          prmT002C13 = new Object[] {
          new ParDef("ReembolsoParcelasId",GXType.Int32,9,0)
          };
          Object[] prmT002C14;
          prmT002C14 = new Object[] {
          };
          Object[] prmT002C15;
          prmT002C15 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T002C2", "SELECT ReembolsoParcelasId, ReembolsoParcelasValor, ReembolsoParcelasData, ReembolsoParcelasObservacao, ReembolsoParcelasCreatedAt, ReembolsoParcelasTaxaValor, ReembolsoParcelasJurosValor, ReembolsoParcelasDiasPJuros, ReembolsoId FROM ReembolsoParcelas WHERE ReembolsoParcelasId = :ReembolsoParcelasId  FOR UPDATE OF ReembolsoParcelas NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002C3", "SELECT ReembolsoParcelasId, ReembolsoParcelasValor, ReembolsoParcelasData, ReembolsoParcelasObservacao, ReembolsoParcelasCreatedAt, ReembolsoParcelasTaxaValor, ReembolsoParcelasJurosValor, ReembolsoParcelasDiasPJuros, ReembolsoId FROM ReembolsoParcelas WHERE ReembolsoParcelasId = :ReembolsoParcelasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002C4", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002C5", "SELECT TM1.ReembolsoParcelasId, TM1.ReembolsoParcelasValor, TM1.ReembolsoParcelasData, TM1.ReembolsoParcelasObservacao, TM1.ReembolsoParcelasCreatedAt, TM1.ReembolsoParcelasTaxaValor, TM1.ReembolsoParcelasJurosValor, TM1.ReembolsoParcelasDiasPJuros, TM1.ReembolsoId FROM ReembolsoParcelas TM1 WHERE TM1.ReembolsoParcelasId = :ReembolsoParcelasId ORDER BY TM1.ReembolsoParcelasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002C6", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002C7", "SELECT ReembolsoParcelasId FROM ReembolsoParcelas WHERE ReembolsoParcelasId = :ReembolsoParcelasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002C8", "SELECT ReembolsoParcelasId FROM ReembolsoParcelas WHERE ( ReembolsoParcelasId > :ReembolsoParcelasId) ORDER BY ReembolsoParcelasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002C9", "SELECT ReembolsoParcelasId FROM ReembolsoParcelas WHERE ( ReembolsoParcelasId < :ReembolsoParcelasId) ORDER BY ReembolsoParcelasId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002C10", "SAVEPOINT gxupdate;INSERT INTO ReembolsoParcelas(ReembolsoParcelasValor, ReembolsoParcelasData, ReembolsoParcelasObservacao, ReembolsoParcelasCreatedAt, ReembolsoParcelasTaxaValor, ReembolsoParcelasJurosValor, ReembolsoParcelasDiasPJuros, ReembolsoId) VALUES(:ReembolsoParcelasValor, :ReembolsoParcelasData, :ReembolsoParcelasObservacao, :ReembolsoParcelasCreatedAt, :ReembolsoParcelasTaxaValor, :ReembolsoParcelasJurosValor, :ReembolsoParcelasDiasPJuros, :ReembolsoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002C10)
             ,new CursorDef("T002C11", "SELECT currval('ReembolsoParcelasId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002C12", "SAVEPOINT gxupdate;UPDATE ReembolsoParcelas SET ReembolsoParcelasValor=:ReembolsoParcelasValor, ReembolsoParcelasData=:ReembolsoParcelasData, ReembolsoParcelasObservacao=:ReembolsoParcelasObservacao, ReembolsoParcelasCreatedAt=:ReembolsoParcelasCreatedAt, ReembolsoParcelasTaxaValor=:ReembolsoParcelasTaxaValor, ReembolsoParcelasJurosValor=:ReembolsoParcelasJurosValor, ReembolsoParcelasDiasPJuros=:ReembolsoParcelasDiasPJuros, ReembolsoId=:ReembolsoId  WHERE ReembolsoParcelasId = :ReembolsoParcelasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002C12)
             ,new CursorDef("T002C13", "SAVEPOINT gxupdate;DELETE FROM ReembolsoParcelas  WHERE ReembolsoParcelasId = :ReembolsoParcelasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002C13)
             ,new CursorDef("T002C14", "SELECT ReembolsoParcelasId FROM ReembolsoParcelas ORDER BY ReembolsoParcelasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002C15", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002C15,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
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
