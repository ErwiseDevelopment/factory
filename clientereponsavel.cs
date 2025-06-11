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
   public class clientereponsavel : GXDataArea
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
            A552ReponsavelClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReponsavelClienteId"), "."), 18, MidpointRounding.ToEven));
            n552ReponsavelClienteId = false;
            AssignAttri("", false, "A552ReponsavelClienteId", ((0==A552ReponsavelClienteId)&&IsIns( )||n552ReponsavelClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A552ReponsavelClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A552ReponsavelClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
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
            gxLoad_2( A168ClienteId) ;
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
         Form.Meta.addItem("description", "Cliente Reponsavel", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtClienteReponsavelId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clientereponsavel( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientereponsavel( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Cliente Reponsavel", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_ClienteReponsavel.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteReponsavel.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteReponsavel.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteReponsavel.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteReponsavel.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ClienteReponsavel.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteReponsavelId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteReponsavelId_Internalname, "Reponsavel Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteReponsavelId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A551ClienteReponsavelId), 9, 0, ",", "")), StringUtil.LTrim( ((edtClienteReponsavelId_Enabled!=0) ? context.localUtil.Format( (decimal)(A551ClienteReponsavelId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A551ClienteReponsavelId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteReponsavelId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteReponsavelId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ClienteReponsavel.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReponsavelClienteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReponsavelClienteId_Internalname, "Cliente Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReponsavelClienteId_Internalname, ((0==A552ReponsavelClienteId)&&IsIns( )||n552ReponsavelClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A552ReponsavelClienteId), 9, 0, ",", ""))), ((0==A552ReponsavelClienteId)&&IsIns( )||n552ReponsavelClienteId ? "" : StringUtil.LTrim( ((edtReponsavelClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A552ReponsavelClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A552ReponsavelClienteId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReponsavelClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtReponsavelClienteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ClienteReponsavel.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", ""))), ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( ((edtClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ClienteReponsavel.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteReponsavel.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteReponsavel.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ClienteReponsavel.htm");
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
            Z551ClienteReponsavelId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z551ClienteReponsavelId"), ",", "."), 18, MidpointRounding.ToEven));
            Z168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
            n168ClienteId = ((0==A168ClienteId) ? true : false);
            Z552ReponsavelClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z552ReponsavelClienteId"), ",", "."), 18, MidpointRounding.ToEven));
            n552ReponsavelClienteId = ((0==A552ReponsavelClienteId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtClienteReponsavelId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteReponsavelId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTEREPONSAVELID");
               AnyError = 1;
               GX_FocusControl = edtClienteReponsavelId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A551ClienteReponsavelId = 0;
               AssignAttri("", false, "A551ClienteReponsavelId", StringUtil.LTrimStr( (decimal)(A551ClienteReponsavelId), 9, 0));
            }
            else
            {
               A551ClienteReponsavelId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteReponsavelId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A551ClienteReponsavelId", StringUtil.LTrimStr( (decimal)(A551ClienteReponsavelId), 9, 0));
            }
            n552ReponsavelClienteId = ((StringUtil.StrCmp(cgiGet( edtReponsavelClienteId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtReponsavelClienteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtReponsavelClienteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPONSAVELCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtReponsavelClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A552ReponsavelClienteId = 0;
               n552ReponsavelClienteId = false;
               AssignAttri("", false, "A552ReponsavelClienteId", (n552ReponsavelClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A552ReponsavelClienteId), 9, 0, ".", ""))));
            }
            else
            {
               A552ReponsavelClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReponsavelClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A552ReponsavelClienteId", (n552ReponsavelClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A552ReponsavelClienteId), 9, 0, ".", ""))));
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
               A551ClienteReponsavelId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteReponsavelId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A551ClienteReponsavelId", StringUtil.LTrimStr( (decimal)(A551ClienteReponsavelId), 9, 0));
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
               InitAll2375( ) ;
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
         DisableAttributes2375( ) ;
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

      protected void ResetCaption230( )
      {
      }

      protected void ZM2375( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z168ClienteId = T00233_A168ClienteId[0];
               Z552ReponsavelClienteId = T00233_A552ReponsavelClienteId[0];
            }
            else
            {
               Z168ClienteId = A168ClienteId;
               Z552ReponsavelClienteId = A552ReponsavelClienteId;
            }
         }
         if ( GX_JID == -1 )
         {
            Z551ClienteReponsavelId = A551ClienteReponsavelId;
            Z168ClienteId = A168ClienteId;
            Z552ReponsavelClienteId = A552ReponsavelClienteId;
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

      protected void Load2375( )
      {
         /* Using cursor T00236 */
         pr_default.execute(4, new Object[] {A551ClienteReponsavelId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound75 = 1;
            A168ClienteId = T00236_A168ClienteId[0];
            n168ClienteId = T00236_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A552ReponsavelClienteId = T00236_A552ReponsavelClienteId[0];
            n552ReponsavelClienteId = T00236_n552ReponsavelClienteId[0];
            AssignAttri("", false, "A552ReponsavelClienteId", ((0==A552ReponsavelClienteId)&&IsIns( )||n552ReponsavelClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A552ReponsavelClienteId), 9, 0, ".", ""))));
            ZM2375( -1) ;
         }
         pr_default.close(4);
         OnLoadActions2375( ) ;
      }

      protected void OnLoadActions2375( )
      {
      }

      protected void CheckExtendedTable2375( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00235 */
         pr_default.execute(3, new Object[] {n552ReponsavelClienteId, A552ReponsavelClienteId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A552ReponsavelClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Cliente Reponsavel'.", "ForeignKeyNotFound", 1, "REPONSAVELCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtReponsavelClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T00234 */
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
      }

      protected void CloseExtendedTableCursors2375( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A552ReponsavelClienteId )
      {
         /* Using cursor T00237 */
         pr_default.execute(5, new Object[] {n552ReponsavelClienteId, A552ReponsavelClienteId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A552ReponsavelClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Cliente Reponsavel'.", "ForeignKeyNotFound", 1, "REPONSAVELCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtReponsavelClienteId_Internalname;
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

      protected void gxLoad_2( int A168ClienteId )
      {
         /* Using cursor T00238 */
         pr_default.execute(6, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(6) == 101) )
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
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey2375( )
      {
         /* Using cursor T00239 */
         pr_default.execute(7, new Object[] {A551ClienteReponsavelId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound75 = 1;
         }
         else
         {
            RcdFound75 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00233 */
         pr_default.execute(1, new Object[] {A551ClienteReponsavelId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2375( 1) ;
            RcdFound75 = 1;
            A551ClienteReponsavelId = T00233_A551ClienteReponsavelId[0];
            AssignAttri("", false, "A551ClienteReponsavelId", StringUtil.LTrimStr( (decimal)(A551ClienteReponsavelId), 9, 0));
            A168ClienteId = T00233_A168ClienteId[0];
            n168ClienteId = T00233_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
            A552ReponsavelClienteId = T00233_A552ReponsavelClienteId[0];
            n552ReponsavelClienteId = T00233_n552ReponsavelClienteId[0];
            AssignAttri("", false, "A552ReponsavelClienteId", ((0==A552ReponsavelClienteId)&&IsIns( )||n552ReponsavelClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A552ReponsavelClienteId), 9, 0, ".", ""))));
            Z551ClienteReponsavelId = A551ClienteReponsavelId;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2375( ) ;
            if ( AnyError == 1 )
            {
               RcdFound75 = 0;
               InitializeNonKey2375( ) ;
            }
            Gx_mode = sMode75;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound75 = 0;
            InitializeNonKey2375( ) ;
            sMode75 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode75;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2375( ) ;
         if ( RcdFound75 == 0 )
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
         RcdFound75 = 0;
         /* Using cursor T002310 */
         pr_default.execute(8, new Object[] {A551ClienteReponsavelId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T002310_A551ClienteReponsavelId[0] < A551ClienteReponsavelId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T002310_A551ClienteReponsavelId[0] > A551ClienteReponsavelId ) ) )
            {
               A551ClienteReponsavelId = T002310_A551ClienteReponsavelId[0];
               AssignAttri("", false, "A551ClienteReponsavelId", StringUtil.LTrimStr( (decimal)(A551ClienteReponsavelId), 9, 0));
               RcdFound75 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound75 = 0;
         /* Using cursor T002311 */
         pr_default.execute(9, new Object[] {A551ClienteReponsavelId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T002311_A551ClienteReponsavelId[0] > A551ClienteReponsavelId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T002311_A551ClienteReponsavelId[0] < A551ClienteReponsavelId ) ) )
            {
               A551ClienteReponsavelId = T002311_A551ClienteReponsavelId[0];
               AssignAttri("", false, "A551ClienteReponsavelId", StringUtil.LTrimStr( (decimal)(A551ClienteReponsavelId), 9, 0));
               RcdFound75 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2375( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtClienteReponsavelId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2375( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound75 == 1 )
            {
               if ( A551ClienteReponsavelId != Z551ClienteReponsavelId )
               {
                  A551ClienteReponsavelId = Z551ClienteReponsavelId;
                  AssignAttri("", false, "A551ClienteReponsavelId", StringUtil.LTrimStr( (decimal)(A551ClienteReponsavelId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIENTEREPONSAVELID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteReponsavelId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtClienteReponsavelId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2375( ) ;
                  GX_FocusControl = edtClienteReponsavelId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A551ClienteReponsavelId != Z551ClienteReponsavelId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtClienteReponsavelId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2375( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLIENTEREPONSAVELID");
                     AnyError = 1;
                     GX_FocusControl = edtClienteReponsavelId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtClienteReponsavelId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2375( ) ;
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
         if ( A551ClienteReponsavelId != Z551ClienteReponsavelId )
         {
            A551ClienteReponsavelId = Z551ClienteReponsavelId;
            AssignAttri("", false, "A551ClienteReponsavelId", StringUtil.LTrimStr( (decimal)(A551ClienteReponsavelId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIENTEREPONSAVELID");
            AnyError = 1;
            GX_FocusControl = edtClienteReponsavelId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtClienteReponsavelId_Internalname;
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
         if ( RcdFound75 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLIENTEREPONSAVELID");
            AnyError = 1;
            GX_FocusControl = edtClienteReponsavelId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtReponsavelClienteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2375( ) ;
         if ( RcdFound75 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReponsavelClienteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2375( ) ;
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
         if ( RcdFound75 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReponsavelClienteId_Internalname;
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
         if ( RcdFound75 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReponsavelClienteId_Internalname;
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
         ScanStart2375( ) ;
         if ( RcdFound75 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound75 != 0 )
            {
               ScanNext2375( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtReponsavelClienteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2375( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2375( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00232 */
            pr_default.execute(0, new Object[] {A551ClienteReponsavelId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteReponsavel"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z168ClienteId != T00232_A168ClienteId[0] ) || ( Z552ReponsavelClienteId != T00232_A552ReponsavelClienteId[0] ) )
            {
               if ( Z168ClienteId != T00232_A168ClienteId[0] )
               {
                  GXUtil.WriteLog("clientereponsavel:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z168ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T00232_A168ClienteId[0]);
               }
               if ( Z552ReponsavelClienteId != T00232_A552ReponsavelClienteId[0] )
               {
                  GXUtil.WriteLog("clientereponsavel:[seudo value changed for attri]"+"ReponsavelClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z552ReponsavelClienteId);
                  GXUtil.WriteLogRaw("Current: ",T00232_A552ReponsavelClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ClienteReponsavel"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2375( )
      {
         BeforeValidate2375( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2375( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2375( 0) ;
            CheckOptimisticConcurrency2375( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2375( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2375( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002312 */
                     pr_default.execute(10, new Object[] {n168ClienteId, A168ClienteId, n552ReponsavelClienteId, A552ReponsavelClienteId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002313 */
                     pr_default.execute(11);
                     A551ClienteReponsavelId = T002313_A551ClienteReponsavelId[0];
                     AssignAttri("", false, "A551ClienteReponsavelId", StringUtil.LTrimStr( (decimal)(A551ClienteReponsavelId), 9, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("ClienteReponsavel");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption230( ) ;
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
               Load2375( ) ;
            }
            EndLevel2375( ) ;
         }
         CloseExtendedTableCursors2375( ) ;
      }

      protected void Update2375( )
      {
         BeforeValidate2375( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2375( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2375( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2375( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2375( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002314 */
                     pr_default.execute(12, new Object[] {n168ClienteId, A168ClienteId, n552ReponsavelClienteId, A552ReponsavelClienteId, A551ClienteReponsavelId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("ClienteReponsavel");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteReponsavel"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2375( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption230( ) ;
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
            EndLevel2375( ) ;
         }
         CloseExtendedTableCursors2375( ) ;
      }

      protected void DeferredUpdate2375( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2375( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2375( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2375( ) ;
            AfterConfirm2375( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2375( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002315 */
                  pr_default.execute(13, new Object[] {A551ClienteReponsavelId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("ClienteReponsavel");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound75 == 0 )
                        {
                           InitAll2375( ) ;
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
                        ResetCaption230( ) ;
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
         sMode75 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2375( ) ;
         Gx_mode = sMode75;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2375( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2375( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2375( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues230( ) ;
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

      public void ScanStart2375( )
      {
         /* Using cursor T002316 */
         pr_default.execute(14);
         RcdFound75 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound75 = 1;
            A551ClienteReponsavelId = T002316_A551ClienteReponsavelId[0];
            AssignAttri("", false, "A551ClienteReponsavelId", StringUtil.LTrimStr( (decimal)(A551ClienteReponsavelId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2375( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound75 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound75 = 1;
            A551ClienteReponsavelId = T002316_A551ClienteReponsavelId[0];
            AssignAttri("", false, "A551ClienteReponsavelId", StringUtil.LTrimStr( (decimal)(A551ClienteReponsavelId), 9, 0));
         }
      }

      protected void ScanEnd2375( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm2375( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2375( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2375( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2375( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2375( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2375( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2375( )
      {
         edtClienteReponsavelId_Enabled = 0;
         AssignProp("", false, edtClienteReponsavelId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteReponsavelId_Enabled), 5, 0), true);
         edtReponsavelClienteId_Enabled = 0;
         AssignProp("", false, edtReponsavelClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReponsavelClienteId_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2375( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues230( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clientereponsavel") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z551ClienteReponsavelId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z551ClienteReponsavelId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z552ReponsavelClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z552ReponsavelClienteId), 9, 0, ",", "")));
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
         return formatLink("clientereponsavel")  ;
      }

      public override string GetPgmname( )
      {
         return "ClienteReponsavel" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cliente Reponsavel" ;
      }

      protected void InitializeNonKey2375( )
      {
         A552ReponsavelClienteId = 0;
         n552ReponsavelClienteId = false;
         AssignAttri("", false, "A552ReponsavelClienteId", ((0==A552ReponsavelClienteId)&&IsIns( )||n552ReponsavelClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A552ReponsavelClienteId), 9, 0, ".", ""))));
         n552ReponsavelClienteId = ((0==A552ReponsavelClienteId) ? true : false);
         A168ClienteId = 0;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         n168ClienteId = ((0==A168ClienteId) ? true : false);
         Z168ClienteId = 0;
         Z552ReponsavelClienteId = 0;
      }

      protected void InitAll2375( )
      {
         A551ClienteReponsavelId = 0;
         AssignAttri("", false, "A551ClienteReponsavelId", StringUtil.LTrimStr( (decimal)(A551ClienteReponsavelId), 9, 0));
         InitializeNonKey2375( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019181798", true, true);
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
         context.AddJavascriptSource("clientereponsavel.js", "?202561019181798", false, true);
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
         edtClienteReponsavelId_Internalname = "CLIENTEREPONSAVELID";
         edtReponsavelClienteId_Internalname = "REPONSAVELCLIENTEID";
         edtClienteId_Internalname = "CLIENTEID";
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
         Form.Caption = "Cliente Reponsavel";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtReponsavelClienteId_Jsonclick = "";
         edtReponsavelClienteId_Enabled = 1;
         edtClienteReponsavelId_Jsonclick = "";
         edtClienteReponsavelId_Enabled = 1;
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
         GX_FocusControl = edtReponsavelClienteId_Internalname;
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

      public void Valid_Clientereponsavelid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A552ReponsavelClienteId", ((0==A552ReponsavelClienteId)&&IsIns( )||n552ReponsavelClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A552ReponsavelClienteId), 9, 0, ".", ""))));
         AssignAttri("", false, "A168ClienteId", ((0==A168ClienteId)&&IsIns( )||n168ClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ".", ""))));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z551ClienteReponsavelId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z551ClienteReponsavelId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z552ReponsavelClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z552ReponsavelClienteId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Reponsavelclienteid( )
      {
         /* Using cursor T002317 */
         pr_default.execute(15, new Object[] {n552ReponsavelClienteId, A552ReponsavelClienteId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A552ReponsavelClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Cliente Reponsavel'.", "ForeignKeyNotFound", 1, "REPONSAVELCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtReponsavelClienteId_Internalname;
            }
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Clienteid( )
      {
         /* Using cursor T002318 */
         pr_default.execute(16, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtClienteId_Internalname;
            }
         }
         pr_default.close(16);
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
         setEventMetadata("VALID_CLIENTEREPONSAVELID","""{"handler":"Valid_Clientereponsavelid","iparms":[{"av":"A551ClienteReponsavelId","fld":"CLIENTEREPONSAVELID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"}]""");
         setEventMetadata("VALID_CLIENTEREPONSAVELID",""","oparms":[{"av":"A552ReponsavelClienteId","fld":"REPONSAVELCLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n552ReponsavelClienteId","type":"int"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z551ClienteReponsavelId","type":"int"},{"av":"Z552ReponsavelClienteId","type":"int"},{"av":"Z168ClienteId","type":"int"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"}]}""");
         setEventMetadata("VALID_REPONSAVELCLIENTEID","""{"handler":"Valid_Reponsavelclienteid","iparms":[{"av":"A552ReponsavelClienteId","fld":"REPONSAVELCLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n552ReponsavelClienteId","type":"int"}]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","nullAv":"n168ClienteId","type":"int"}]}""");
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
         pr_default.close(15);
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
         T00236_A551ClienteReponsavelId = new int[1] ;
         T00236_A168ClienteId = new int[1] ;
         T00236_n168ClienteId = new bool[] {false} ;
         T00236_A552ReponsavelClienteId = new int[1] ;
         T00236_n552ReponsavelClienteId = new bool[] {false} ;
         T00235_A552ReponsavelClienteId = new int[1] ;
         T00235_n552ReponsavelClienteId = new bool[] {false} ;
         T00234_A168ClienteId = new int[1] ;
         T00234_n168ClienteId = new bool[] {false} ;
         T00237_A552ReponsavelClienteId = new int[1] ;
         T00237_n552ReponsavelClienteId = new bool[] {false} ;
         T00238_A168ClienteId = new int[1] ;
         T00238_n168ClienteId = new bool[] {false} ;
         T00239_A551ClienteReponsavelId = new int[1] ;
         T00233_A551ClienteReponsavelId = new int[1] ;
         T00233_A168ClienteId = new int[1] ;
         T00233_n168ClienteId = new bool[] {false} ;
         T00233_A552ReponsavelClienteId = new int[1] ;
         T00233_n552ReponsavelClienteId = new bool[] {false} ;
         sMode75 = "";
         T002310_A551ClienteReponsavelId = new int[1] ;
         T002311_A551ClienteReponsavelId = new int[1] ;
         T00232_A551ClienteReponsavelId = new int[1] ;
         T00232_A168ClienteId = new int[1] ;
         T00232_n168ClienteId = new bool[] {false} ;
         T00232_A552ReponsavelClienteId = new int[1] ;
         T00232_n552ReponsavelClienteId = new bool[] {false} ;
         T002313_A551ClienteReponsavelId = new int[1] ;
         T002316_A551ClienteReponsavelId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002317_A552ReponsavelClienteId = new int[1] ;
         T002317_n552ReponsavelClienteId = new bool[] {false} ;
         T002318_A168ClienteId = new int[1] ;
         T002318_n168ClienteId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientereponsavel__default(),
            new Object[][] {
                new Object[] {
               T00232_A551ClienteReponsavelId, T00232_A168ClienteId, T00232_n168ClienteId, T00232_A552ReponsavelClienteId, T00232_n552ReponsavelClienteId
               }
               , new Object[] {
               T00233_A551ClienteReponsavelId, T00233_A168ClienteId, T00233_n168ClienteId, T00233_A552ReponsavelClienteId, T00233_n552ReponsavelClienteId
               }
               , new Object[] {
               T00234_A168ClienteId
               }
               , new Object[] {
               T00235_A552ReponsavelClienteId
               }
               , new Object[] {
               T00236_A551ClienteReponsavelId, T00236_A168ClienteId, T00236_n168ClienteId, T00236_A552ReponsavelClienteId, T00236_n552ReponsavelClienteId
               }
               , new Object[] {
               T00237_A552ReponsavelClienteId
               }
               , new Object[] {
               T00238_A168ClienteId
               }
               , new Object[] {
               T00239_A551ClienteReponsavelId
               }
               , new Object[] {
               T002310_A551ClienteReponsavelId
               }
               , new Object[] {
               T002311_A551ClienteReponsavelId
               }
               , new Object[] {
               }
               , new Object[] {
               T002313_A551ClienteReponsavelId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002316_A551ClienteReponsavelId
               }
               , new Object[] {
               T002317_A552ReponsavelClienteId
               }
               , new Object[] {
               T002318_A168ClienteId
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
      private short RcdFound75 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z551ClienteReponsavelId ;
      private int Z168ClienteId ;
      private int Z552ReponsavelClienteId ;
      private int A552ReponsavelClienteId ;
      private int A168ClienteId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A551ClienteReponsavelId ;
      private int edtClienteReponsavelId_Enabled ;
      private int edtReponsavelClienteId_Enabled ;
      private int edtClienteId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ551ClienteReponsavelId ;
      private int ZZ552ReponsavelClienteId ;
      private int ZZ168ClienteId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtClienteReponsavelId_Internalname ;
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
      private string edtClienteReponsavelId_Jsonclick ;
      private string edtReponsavelClienteId_Internalname ;
      private string edtReponsavelClienteId_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
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
      private string sMode75 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n552ReponsavelClienteId ;
      private bool n168ClienteId ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00236_A551ClienteReponsavelId ;
      private int[] T00236_A168ClienteId ;
      private bool[] T00236_n168ClienteId ;
      private int[] T00236_A552ReponsavelClienteId ;
      private bool[] T00236_n552ReponsavelClienteId ;
      private int[] T00235_A552ReponsavelClienteId ;
      private bool[] T00235_n552ReponsavelClienteId ;
      private int[] T00234_A168ClienteId ;
      private bool[] T00234_n168ClienteId ;
      private int[] T00237_A552ReponsavelClienteId ;
      private bool[] T00237_n552ReponsavelClienteId ;
      private int[] T00238_A168ClienteId ;
      private bool[] T00238_n168ClienteId ;
      private int[] T00239_A551ClienteReponsavelId ;
      private int[] T00233_A551ClienteReponsavelId ;
      private int[] T00233_A168ClienteId ;
      private bool[] T00233_n168ClienteId ;
      private int[] T00233_A552ReponsavelClienteId ;
      private bool[] T00233_n552ReponsavelClienteId ;
      private int[] T002310_A551ClienteReponsavelId ;
      private int[] T002311_A551ClienteReponsavelId ;
      private int[] T00232_A551ClienteReponsavelId ;
      private int[] T00232_A168ClienteId ;
      private bool[] T00232_n168ClienteId ;
      private int[] T00232_A552ReponsavelClienteId ;
      private bool[] T00232_n552ReponsavelClienteId ;
      private int[] T002313_A551ClienteReponsavelId ;
      private int[] T002316_A551ClienteReponsavelId ;
      private int[] T002317_A552ReponsavelClienteId ;
      private bool[] T002317_n552ReponsavelClienteId ;
      private int[] T002318_A168ClienteId ;
      private bool[] T002318_n168ClienteId ;
   }

   public class clientereponsavel__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00232;
          prmT00232 = new Object[] {
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmT00233;
          prmT00233 = new Object[] {
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmT00234;
          prmT00234 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00235;
          prmT00235 = new Object[] {
          new ParDef("ReponsavelClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00236;
          prmT00236 = new Object[] {
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmT00237;
          prmT00237 = new Object[] {
          new ParDef("ReponsavelClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00238;
          prmT00238 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00239;
          prmT00239 = new Object[] {
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmT002310;
          prmT002310 = new Object[] {
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmT002311;
          prmT002311 = new Object[] {
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmT002312;
          prmT002312 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReponsavelClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002313;
          prmT002313 = new Object[] {
          };
          Object[] prmT002314;
          prmT002314 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReponsavelClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmT002315;
          prmT002315 = new Object[] {
          new ParDef("ClienteReponsavelId",GXType.Int32,9,0)
          };
          Object[] prmT002316;
          prmT002316 = new Object[] {
          };
          Object[] prmT002317;
          prmT002317 = new Object[] {
          new ParDef("ReponsavelClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002318;
          prmT002318 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00232", "SELECT ClienteReponsavelId, ClienteId, ReponsavelClienteId FROM ClienteReponsavel WHERE ClienteReponsavelId = :ClienteReponsavelId  FOR UPDATE OF ClienteReponsavel NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00232,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00233", "SELECT ClienteReponsavelId, ClienteId, ReponsavelClienteId FROM ClienteReponsavel WHERE ClienteReponsavelId = :ClienteReponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00233,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00234", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00234,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00235", "SELECT ClienteId AS ReponsavelClienteId FROM Cliente WHERE ClienteId = :ReponsavelClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00235,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00236", "SELECT TM1.ClienteReponsavelId, TM1.ClienteId, TM1.ReponsavelClienteId AS ReponsavelClienteId FROM ClienteReponsavel TM1 WHERE TM1.ClienteReponsavelId = :ClienteReponsavelId ORDER BY TM1.ClienteReponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00236,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00237", "SELECT ClienteId AS ReponsavelClienteId FROM Cliente WHERE ClienteId = :ReponsavelClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00237,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00238", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00238,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00239", "SELECT ClienteReponsavelId FROM ClienteReponsavel WHERE ClienteReponsavelId = :ClienteReponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00239,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002310", "SELECT ClienteReponsavelId FROM ClienteReponsavel WHERE ( ClienteReponsavelId > :ClienteReponsavelId) ORDER BY ClienteReponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002310,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002311", "SELECT ClienteReponsavelId FROM ClienteReponsavel WHERE ( ClienteReponsavelId < :ClienteReponsavelId) ORDER BY ClienteReponsavelId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002311,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002312", "SAVEPOINT gxupdate;INSERT INTO ClienteReponsavel(ClienteId, ReponsavelClienteId) VALUES(:ClienteId, :ReponsavelClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002312)
             ,new CursorDef("T002313", "SELECT currval('ClienteReponsavelId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002313,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002314", "SAVEPOINT gxupdate;UPDATE ClienteReponsavel SET ClienteId=:ClienteId, ReponsavelClienteId=:ReponsavelClienteId  WHERE ClienteReponsavelId = :ClienteReponsavelId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002314)
             ,new CursorDef("T002315", "SAVEPOINT gxupdate;DELETE FROM ClienteReponsavel  WHERE ClienteReponsavelId = :ClienteReponsavelId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002315)
             ,new CursorDef("T002316", "SELECT ClienteReponsavelId FROM ClienteReponsavel ORDER BY ClienteReponsavelId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002316,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002317", "SELECT ClienteId AS ReponsavelClienteId FROM Cliente WHERE ClienteId = :ReponsavelClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002317,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002318", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002318,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
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
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
