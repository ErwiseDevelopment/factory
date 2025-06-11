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
   public class assinaturaparticipantetoken : GXDataArea
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
            A242AssinaturaParticipanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaParticipanteId"), "."), 18, MidpointRounding.ToEven));
            n242AssinaturaParticipanteId = false;
            AssignAttri("", false, "A242AssinaturaParticipanteId", ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A242AssinaturaParticipanteId) ;
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
         Form.Meta.addItem("description", "Assinatura Participante Token", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAssinaturaParticipanteTokenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public assinaturaparticipantetoken( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assinaturaparticipantetoken( IGxContext context )
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
         chkAssinaturaParticipanteTokenUsed = new GXCheckbox();
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
         A556AssinaturaParticipanteTokenUsed = StringUtil.StrToBool( StringUtil.BoolToStr( A556AssinaturaParticipanteTokenUsed));
         n556AssinaturaParticipanteTokenUsed = false;
         AssignAttri("", false, "A556AssinaturaParticipanteTokenUsed", A556AssinaturaParticipanteTokenUsed);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Assinatura Participante Token", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_AssinaturaParticipanteToken.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AssinaturaParticipanteToken.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteTokenId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteTokenId_Internalname, "Token Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteTokenId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0, ",", "")), StringUtil.LTrim( ((edtAssinaturaParticipanteTokenId_Enabled!=0) ? context.localUtil.Format( (decimal)(A554AssinaturaParticipanteTokenId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A554AssinaturaParticipanteTokenId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteTokenId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteTokenId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_AssinaturaParticipanteToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteId_Internalname, "Assinatura Participante Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteId_Internalname, ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ",", ""))), ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( ((edtAssinaturaParticipanteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A242AssinaturaParticipanteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A242AssinaturaParticipanteId), "ZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_AssinaturaParticipanteToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteTokenExpire_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteTokenExpire_Internalname, "Token Expire", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtAssinaturaParticipanteTokenExpire_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteTokenExpire_Internalname, context.localUtil.TToC( A555AssinaturaParticipanteTokenExpire, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A555AssinaturaParticipanteTokenExpire, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteTokenExpire_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteTokenExpire_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_AssinaturaParticipanteToken.htm");
         GxWebStd.gx_bitmap( context, edtAssinaturaParticipanteTokenExpire_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtAssinaturaParticipanteTokenExpire_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AssinaturaParticipanteToken.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkAssinaturaParticipanteTokenUsed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkAssinaturaParticipanteTokenUsed_Internalname, "Token Used", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkAssinaturaParticipanteTokenUsed_Internalname, StringUtil.BoolToStr( A556AssinaturaParticipanteTokenUsed), "", "Token Used", 1, chkAssinaturaParticipanteTokenUsed.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(49, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,49);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtAssinaturaParticipanteTokenContent_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAssinaturaParticipanteTokenContent_Internalname, "Token Content", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAssinaturaParticipanteTokenContent_Internalname, A557AssinaturaParticipanteTokenContent, StringUtil.RTrim( context.localUtil.Format( A557AssinaturaParticipanteTokenContent, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAssinaturaParticipanteTokenContent_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAssinaturaParticipanteTokenContent_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaParticipanteToken.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteToken.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaParticipanteToken.htm");
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
            Z554AssinaturaParticipanteTokenId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z554AssinaturaParticipanteTokenId"), ",", "."), 18, MidpointRounding.ToEven));
            Z555AssinaturaParticipanteTokenExpire = context.localUtil.CToT( cgiGet( "Z555AssinaturaParticipanteTokenExpire"), 0);
            n555AssinaturaParticipanteTokenExpire = ((DateTime.MinValue==A555AssinaturaParticipanteTokenExpire) ? true : false);
            Z556AssinaturaParticipanteTokenUsed = StringUtil.StrToBool( cgiGet( "Z556AssinaturaParticipanteTokenUsed"));
            n556AssinaturaParticipanteTokenUsed = ((false==A556AssinaturaParticipanteTokenUsed) ? true : false);
            Z557AssinaturaParticipanteTokenContent = cgiGet( "Z557AssinaturaParticipanteTokenContent");
            n557AssinaturaParticipanteTokenContent = (String.IsNullOrEmpty(StringUtil.RTrim( A557AssinaturaParticipanteTokenContent)) ? true : false);
            Z242AssinaturaParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z242AssinaturaParticipanteId"), ",", "."), 18, MidpointRounding.ToEven));
            n242AssinaturaParticipanteId = ((0==A242AssinaturaParticipanteId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteTokenId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteTokenId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ASSINATURAPARTICIPANTETOKENID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteTokenId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A554AssinaturaParticipanteTokenId = 0;
               AssignAttri("", false, "A554AssinaturaParticipanteTokenId", StringUtil.LTrimStr( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0));
            }
            else
            {
               A554AssinaturaParticipanteTokenId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteTokenId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A554AssinaturaParticipanteTokenId", StringUtil.LTrimStr( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0));
            }
            n242AssinaturaParticipanteId = ((StringUtil.StrCmp(cgiGet( edtAssinaturaParticipanteId_Internalname), "")==0) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ASSINATURAPARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A242AssinaturaParticipanteId = 0;
               n242AssinaturaParticipanteId = false;
               AssignAttri("", false, "A242AssinaturaParticipanteId", (n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
            }
            else
            {
               A242AssinaturaParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtAssinaturaParticipanteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A242AssinaturaParticipanteId", (n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtAssinaturaParticipanteTokenExpire_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Assinatura Participante Token Expire"}), 1, "ASSINATURAPARTICIPANTETOKENEXPIRE");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteTokenExpire_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A555AssinaturaParticipanteTokenExpire = (DateTime)(DateTime.MinValue);
               n555AssinaturaParticipanteTokenExpire = false;
               AssignAttri("", false, "A555AssinaturaParticipanteTokenExpire", context.localUtil.TToC( A555AssinaturaParticipanteTokenExpire, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A555AssinaturaParticipanteTokenExpire = context.localUtil.CToT( cgiGet( edtAssinaturaParticipanteTokenExpire_Internalname));
               n555AssinaturaParticipanteTokenExpire = false;
               AssignAttri("", false, "A555AssinaturaParticipanteTokenExpire", context.localUtil.TToC( A555AssinaturaParticipanteTokenExpire, 8, 5, 0, 3, "/", ":", " "));
            }
            n555AssinaturaParticipanteTokenExpire = ((DateTime.MinValue==A555AssinaturaParticipanteTokenExpire) ? true : false);
            A556AssinaturaParticipanteTokenUsed = StringUtil.StrToBool( cgiGet( chkAssinaturaParticipanteTokenUsed_Internalname));
            n556AssinaturaParticipanteTokenUsed = false;
            AssignAttri("", false, "A556AssinaturaParticipanteTokenUsed", A556AssinaturaParticipanteTokenUsed);
            n556AssinaturaParticipanteTokenUsed = ((false==A556AssinaturaParticipanteTokenUsed) ? true : false);
            A557AssinaturaParticipanteTokenContent = cgiGet( edtAssinaturaParticipanteTokenContent_Internalname);
            n557AssinaturaParticipanteTokenContent = false;
            AssignAttri("", false, "A557AssinaturaParticipanteTokenContent", A557AssinaturaParticipanteTokenContent);
            n557AssinaturaParticipanteTokenContent = (String.IsNullOrEmpty(StringUtil.RTrim( A557AssinaturaParticipanteTokenContent)) ? true : false);
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
               A554AssinaturaParticipanteTokenId = (int)(Math.Round(NumberUtil.Val( GetPar( "AssinaturaParticipanteTokenId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A554AssinaturaParticipanteTokenId", StringUtil.LTrimStr( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0));
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
               InitAll2476( ) ;
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
         DisableAttributes2476( ) ;
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

      protected void ResetCaption240( )
      {
      }

      protected void ZM2476( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z555AssinaturaParticipanteTokenExpire = T00243_A555AssinaturaParticipanteTokenExpire[0];
               Z556AssinaturaParticipanteTokenUsed = T00243_A556AssinaturaParticipanteTokenUsed[0];
               Z557AssinaturaParticipanteTokenContent = T00243_A557AssinaturaParticipanteTokenContent[0];
               Z242AssinaturaParticipanteId = T00243_A242AssinaturaParticipanteId[0];
            }
            else
            {
               Z555AssinaturaParticipanteTokenExpire = A555AssinaturaParticipanteTokenExpire;
               Z556AssinaturaParticipanteTokenUsed = A556AssinaturaParticipanteTokenUsed;
               Z557AssinaturaParticipanteTokenContent = A557AssinaturaParticipanteTokenContent;
               Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z554AssinaturaParticipanteTokenId = A554AssinaturaParticipanteTokenId;
            Z555AssinaturaParticipanteTokenExpire = A555AssinaturaParticipanteTokenExpire;
            Z556AssinaturaParticipanteTokenUsed = A556AssinaturaParticipanteTokenUsed;
            Z557AssinaturaParticipanteTokenContent = A557AssinaturaParticipanteTokenContent;
            Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A556AssinaturaParticipanteTokenUsed) && ( Gx_BScreen == 0 ) )
         {
            A556AssinaturaParticipanteTokenUsed = false;
            n556AssinaturaParticipanteTokenUsed = false;
            AssignAttri("", false, "A556AssinaturaParticipanteTokenUsed", A556AssinaturaParticipanteTokenUsed);
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

      protected void Load2476( )
      {
         /* Using cursor T00245 */
         pr_default.execute(3, new Object[] {A554AssinaturaParticipanteTokenId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound76 = 1;
            A555AssinaturaParticipanteTokenExpire = T00245_A555AssinaturaParticipanteTokenExpire[0];
            n555AssinaturaParticipanteTokenExpire = T00245_n555AssinaturaParticipanteTokenExpire[0];
            AssignAttri("", false, "A555AssinaturaParticipanteTokenExpire", context.localUtil.TToC( A555AssinaturaParticipanteTokenExpire, 8, 5, 0, 3, "/", ":", " "));
            A556AssinaturaParticipanteTokenUsed = T00245_A556AssinaturaParticipanteTokenUsed[0];
            n556AssinaturaParticipanteTokenUsed = T00245_n556AssinaturaParticipanteTokenUsed[0];
            AssignAttri("", false, "A556AssinaturaParticipanteTokenUsed", A556AssinaturaParticipanteTokenUsed);
            A557AssinaturaParticipanteTokenContent = T00245_A557AssinaturaParticipanteTokenContent[0];
            n557AssinaturaParticipanteTokenContent = T00245_n557AssinaturaParticipanteTokenContent[0];
            AssignAttri("", false, "A557AssinaturaParticipanteTokenContent", A557AssinaturaParticipanteTokenContent);
            A242AssinaturaParticipanteId = T00245_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = T00245_n242AssinaturaParticipanteId[0];
            AssignAttri("", false, "A242AssinaturaParticipanteId", ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
            ZM2476( -2) ;
         }
         pr_default.close(3);
         OnLoadActions2476( ) ;
      }

      protected void OnLoadActions2476( )
      {
      }

      protected void CheckExtendedTable2476( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00244 */
         pr_default.execute(2, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A242AssinaturaParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'AssinaturaParticipante'.", "ForeignKeyNotFound", 1, "ASSINATURAPARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors2476( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A242AssinaturaParticipanteId )
      {
         /* Using cursor T00246 */
         pr_default.execute(4, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A242AssinaturaParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'AssinaturaParticipante'.", "ForeignKeyNotFound", 1, "ASSINATURAPARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
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

      protected void GetKey2476( )
      {
         /* Using cursor T00247 */
         pr_default.execute(5, new Object[] {A554AssinaturaParticipanteTokenId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound76 = 1;
         }
         else
         {
            RcdFound76 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00243 */
         pr_default.execute(1, new Object[] {A554AssinaturaParticipanteTokenId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2476( 2) ;
            RcdFound76 = 1;
            A554AssinaturaParticipanteTokenId = T00243_A554AssinaturaParticipanteTokenId[0];
            AssignAttri("", false, "A554AssinaturaParticipanteTokenId", StringUtil.LTrimStr( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0));
            A555AssinaturaParticipanteTokenExpire = T00243_A555AssinaturaParticipanteTokenExpire[0];
            n555AssinaturaParticipanteTokenExpire = T00243_n555AssinaturaParticipanteTokenExpire[0];
            AssignAttri("", false, "A555AssinaturaParticipanteTokenExpire", context.localUtil.TToC( A555AssinaturaParticipanteTokenExpire, 8, 5, 0, 3, "/", ":", " "));
            A556AssinaturaParticipanteTokenUsed = T00243_A556AssinaturaParticipanteTokenUsed[0];
            n556AssinaturaParticipanteTokenUsed = T00243_n556AssinaturaParticipanteTokenUsed[0];
            AssignAttri("", false, "A556AssinaturaParticipanteTokenUsed", A556AssinaturaParticipanteTokenUsed);
            A557AssinaturaParticipanteTokenContent = T00243_A557AssinaturaParticipanteTokenContent[0];
            n557AssinaturaParticipanteTokenContent = T00243_n557AssinaturaParticipanteTokenContent[0];
            AssignAttri("", false, "A557AssinaturaParticipanteTokenContent", A557AssinaturaParticipanteTokenContent);
            A242AssinaturaParticipanteId = T00243_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = T00243_n242AssinaturaParticipanteId[0];
            AssignAttri("", false, "A242AssinaturaParticipanteId", ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
            Z554AssinaturaParticipanteTokenId = A554AssinaturaParticipanteTokenId;
            sMode76 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2476( ) ;
            if ( AnyError == 1 )
            {
               RcdFound76 = 0;
               InitializeNonKey2476( ) ;
            }
            Gx_mode = sMode76;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound76 = 0;
            InitializeNonKey2476( ) ;
            sMode76 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode76;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2476( ) ;
         if ( RcdFound76 == 0 )
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
         RcdFound76 = 0;
         /* Using cursor T00248 */
         pr_default.execute(6, new Object[] {A554AssinaturaParticipanteTokenId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00248_A554AssinaturaParticipanteTokenId[0] < A554AssinaturaParticipanteTokenId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00248_A554AssinaturaParticipanteTokenId[0] > A554AssinaturaParticipanteTokenId ) ) )
            {
               A554AssinaturaParticipanteTokenId = T00248_A554AssinaturaParticipanteTokenId[0];
               AssignAttri("", false, "A554AssinaturaParticipanteTokenId", StringUtil.LTrimStr( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0));
               RcdFound76 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound76 = 0;
         /* Using cursor T00249 */
         pr_default.execute(7, new Object[] {A554AssinaturaParticipanteTokenId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00249_A554AssinaturaParticipanteTokenId[0] > A554AssinaturaParticipanteTokenId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00249_A554AssinaturaParticipanteTokenId[0] < A554AssinaturaParticipanteTokenId ) ) )
            {
               A554AssinaturaParticipanteTokenId = T00249_A554AssinaturaParticipanteTokenId[0];
               AssignAttri("", false, "A554AssinaturaParticipanteTokenId", StringUtil.LTrimStr( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0));
               RcdFound76 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2476( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAssinaturaParticipanteTokenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2476( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound76 == 1 )
            {
               if ( A554AssinaturaParticipanteTokenId != Z554AssinaturaParticipanteTokenId )
               {
                  A554AssinaturaParticipanteTokenId = Z554AssinaturaParticipanteTokenId;
                  AssignAttri("", false, "A554AssinaturaParticipanteTokenId", StringUtil.LTrimStr( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ASSINATURAPARTICIPANTETOKENID");
                  AnyError = 1;
                  GX_FocusControl = edtAssinaturaParticipanteTokenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAssinaturaParticipanteTokenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2476( ) ;
                  GX_FocusControl = edtAssinaturaParticipanteTokenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A554AssinaturaParticipanteTokenId != Z554AssinaturaParticipanteTokenId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAssinaturaParticipanteTokenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2476( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ASSINATURAPARTICIPANTETOKENID");
                     AnyError = 1;
                     GX_FocusControl = edtAssinaturaParticipanteTokenId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAssinaturaParticipanteTokenId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2476( ) ;
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
         if ( A554AssinaturaParticipanteTokenId != Z554AssinaturaParticipanteTokenId )
         {
            A554AssinaturaParticipanteTokenId = Z554AssinaturaParticipanteTokenId;
            AssignAttri("", false, "A554AssinaturaParticipanteTokenId", StringUtil.LTrimStr( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ASSINATURAPARTICIPANTETOKENID");
            AnyError = 1;
            GX_FocusControl = edtAssinaturaParticipanteTokenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAssinaturaParticipanteTokenId_Internalname;
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
         if ( RcdFound76 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ASSINATURAPARTICIPANTETOKENID");
            AnyError = 1;
            GX_FocusControl = edtAssinaturaParticipanteTokenId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2476( ) ;
         if ( RcdFound76 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2476( ) ;
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
         if ( RcdFound76 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
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
         if ( RcdFound76 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
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
         ScanStart2476( ) ;
         if ( RcdFound76 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound76 != 0 )
            {
               ScanNext2476( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2476( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2476( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00242 */
            pr_default.execute(0, new Object[] {A554AssinaturaParticipanteTokenId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AssinaturaParticipanteToken"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z555AssinaturaParticipanteTokenExpire != T00242_A555AssinaturaParticipanteTokenExpire[0] ) || ( Z556AssinaturaParticipanteTokenUsed != T00242_A556AssinaturaParticipanteTokenUsed[0] ) || ( StringUtil.StrCmp(Z557AssinaturaParticipanteTokenContent, T00242_A557AssinaturaParticipanteTokenContent[0]) != 0 ) || ( Z242AssinaturaParticipanteId != T00242_A242AssinaturaParticipanteId[0] ) )
            {
               if ( Z555AssinaturaParticipanteTokenExpire != T00242_A555AssinaturaParticipanteTokenExpire[0] )
               {
                  GXUtil.WriteLog("assinaturaparticipantetoken:[seudo value changed for attri]"+"AssinaturaParticipanteTokenExpire");
                  GXUtil.WriteLogRaw("Old: ",Z555AssinaturaParticipanteTokenExpire);
                  GXUtil.WriteLogRaw("Current: ",T00242_A555AssinaturaParticipanteTokenExpire[0]);
               }
               if ( Z556AssinaturaParticipanteTokenUsed != T00242_A556AssinaturaParticipanteTokenUsed[0] )
               {
                  GXUtil.WriteLog("assinaturaparticipantetoken:[seudo value changed for attri]"+"AssinaturaParticipanteTokenUsed");
                  GXUtil.WriteLogRaw("Old: ",Z556AssinaturaParticipanteTokenUsed);
                  GXUtil.WriteLogRaw("Current: ",T00242_A556AssinaturaParticipanteTokenUsed[0]);
               }
               if ( StringUtil.StrCmp(Z557AssinaturaParticipanteTokenContent, T00242_A557AssinaturaParticipanteTokenContent[0]) != 0 )
               {
                  GXUtil.WriteLog("assinaturaparticipantetoken:[seudo value changed for attri]"+"AssinaturaParticipanteTokenContent");
                  GXUtil.WriteLogRaw("Old: ",Z557AssinaturaParticipanteTokenContent);
                  GXUtil.WriteLogRaw("Current: ",T00242_A557AssinaturaParticipanteTokenContent[0]);
               }
               if ( Z242AssinaturaParticipanteId != T00242_A242AssinaturaParticipanteId[0] )
               {
                  GXUtil.WriteLog("assinaturaparticipantetoken:[seudo value changed for attri]"+"AssinaturaParticipanteId");
                  GXUtil.WriteLogRaw("Old: ",Z242AssinaturaParticipanteId);
                  GXUtil.WriteLogRaw("Current: ",T00242_A242AssinaturaParticipanteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AssinaturaParticipanteToken"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2476( )
      {
         BeforeValidate2476( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2476( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2476( 0) ;
            CheckOptimisticConcurrency2476( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2476( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2476( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002410 */
                     pr_default.execute(8, new Object[] {n555AssinaturaParticipanteTokenExpire, A555AssinaturaParticipanteTokenExpire, n556AssinaturaParticipanteTokenUsed, A556AssinaturaParticipanteTokenUsed, n557AssinaturaParticipanteTokenContent, A557AssinaturaParticipanteTokenContent, n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002411 */
                     pr_default.execute(9);
                     A554AssinaturaParticipanteTokenId = T002411_A554AssinaturaParticipanteTokenId[0];
                     AssignAttri("", false, "A554AssinaturaParticipanteTokenId", StringUtil.LTrimStr( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipanteToken");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption240( ) ;
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
               Load2476( ) ;
            }
            EndLevel2476( ) ;
         }
         CloseExtendedTableCursors2476( ) ;
      }

      protected void Update2476( )
      {
         BeforeValidate2476( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2476( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2476( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2476( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2476( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002412 */
                     pr_default.execute(10, new Object[] {n555AssinaturaParticipanteTokenExpire, A555AssinaturaParticipanteTokenExpire, n556AssinaturaParticipanteTokenUsed, A556AssinaturaParticipanteTokenUsed, n557AssinaturaParticipanteTokenContent, A557AssinaturaParticipanteTokenContent, n242AssinaturaParticipanteId, A242AssinaturaParticipanteId, A554AssinaturaParticipanteTokenId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipanteToken");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AssinaturaParticipanteToken"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2476( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption240( ) ;
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
            EndLevel2476( ) ;
         }
         CloseExtendedTableCursors2476( ) ;
      }

      protected void DeferredUpdate2476( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2476( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2476( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2476( ) ;
            AfterConfirm2476( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2476( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002413 */
                  pr_default.execute(11, new Object[] {A554AssinaturaParticipanteTokenId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipanteToken");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound76 == 0 )
                        {
                           InitAll2476( ) ;
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
                        ResetCaption240( ) ;
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
         sMode76 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2476( ) ;
         Gx_mode = sMode76;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2476( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2476( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2476( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues240( ) ;
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

      public void ScanStart2476( )
      {
         /* Using cursor T002414 */
         pr_default.execute(12);
         RcdFound76 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound76 = 1;
            A554AssinaturaParticipanteTokenId = T002414_A554AssinaturaParticipanteTokenId[0];
            AssignAttri("", false, "A554AssinaturaParticipanteTokenId", StringUtil.LTrimStr( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2476( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound76 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound76 = 1;
            A554AssinaturaParticipanteTokenId = T002414_A554AssinaturaParticipanteTokenId[0];
            AssignAttri("", false, "A554AssinaturaParticipanteTokenId", StringUtil.LTrimStr( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0));
         }
      }

      protected void ScanEnd2476( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm2476( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2476( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2476( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2476( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2476( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2476( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2476( )
      {
         edtAssinaturaParticipanteTokenId_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteTokenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteTokenId_Enabled), 5, 0), true);
         edtAssinaturaParticipanteId_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteId_Enabled), 5, 0), true);
         edtAssinaturaParticipanteTokenExpire_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteTokenExpire_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteTokenExpire_Enabled), 5, 0), true);
         chkAssinaturaParticipanteTokenUsed.Enabled = 0;
         AssignProp("", false, chkAssinaturaParticipanteTokenUsed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkAssinaturaParticipanteTokenUsed.Enabled), 5, 0), true);
         edtAssinaturaParticipanteTokenContent_Enabled = 0;
         AssignProp("", false, edtAssinaturaParticipanteTokenContent_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAssinaturaParticipanteTokenContent_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2476( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues240( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("assinaturaparticipantetoken") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z554AssinaturaParticipanteTokenId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z554AssinaturaParticipanteTokenId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z555AssinaturaParticipanteTokenExpire", context.localUtil.TToC( Z555AssinaturaParticipanteTokenExpire, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z556AssinaturaParticipanteTokenUsed", Z556AssinaturaParticipanteTokenUsed);
         GxWebStd.gx_hidden_field( context, "Z557AssinaturaParticipanteTokenContent", Z557AssinaturaParticipanteTokenContent);
         GxWebStd.gx_hidden_field( context, "Z242AssinaturaParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z242AssinaturaParticipanteId), 9, 0, ",", "")));
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
         return formatLink("assinaturaparticipantetoken")  ;
      }

      public override string GetPgmname( )
      {
         return "AssinaturaParticipanteToken" ;
      }

      public override string GetPgmdesc( )
      {
         return "Assinatura Participante Token" ;
      }

      protected void InitializeNonKey2476( )
      {
         A242AssinaturaParticipanteId = 0;
         n242AssinaturaParticipanteId = false;
         AssignAttri("", false, "A242AssinaturaParticipanteId", ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
         n242AssinaturaParticipanteId = ((0==A242AssinaturaParticipanteId) ? true : false);
         A555AssinaturaParticipanteTokenExpire = (DateTime)(DateTime.MinValue);
         n555AssinaturaParticipanteTokenExpire = false;
         AssignAttri("", false, "A555AssinaturaParticipanteTokenExpire", context.localUtil.TToC( A555AssinaturaParticipanteTokenExpire, 8, 5, 0, 3, "/", ":", " "));
         n555AssinaturaParticipanteTokenExpire = ((DateTime.MinValue==A555AssinaturaParticipanteTokenExpire) ? true : false);
         A557AssinaturaParticipanteTokenContent = "";
         n557AssinaturaParticipanteTokenContent = false;
         AssignAttri("", false, "A557AssinaturaParticipanteTokenContent", A557AssinaturaParticipanteTokenContent);
         n557AssinaturaParticipanteTokenContent = (String.IsNullOrEmpty(StringUtil.RTrim( A557AssinaturaParticipanteTokenContent)) ? true : false);
         A556AssinaturaParticipanteTokenUsed = false;
         n556AssinaturaParticipanteTokenUsed = false;
         AssignAttri("", false, "A556AssinaturaParticipanteTokenUsed", A556AssinaturaParticipanteTokenUsed);
         Z555AssinaturaParticipanteTokenExpire = (DateTime)(DateTime.MinValue);
         Z556AssinaturaParticipanteTokenUsed = false;
         Z557AssinaturaParticipanteTokenContent = "";
         Z242AssinaturaParticipanteId = 0;
      }

      protected void InitAll2476( )
      {
         A554AssinaturaParticipanteTokenId = 0;
         AssignAttri("", false, "A554AssinaturaParticipanteTokenId", StringUtil.LTrimStr( (decimal)(A554AssinaturaParticipanteTokenId), 9, 0));
         InitializeNonKey2476( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A556AssinaturaParticipanteTokenUsed = i556AssinaturaParticipanteTokenUsed;
         n556AssinaturaParticipanteTokenUsed = false;
         AssignAttri("", false, "A556AssinaturaParticipanteTokenUsed", A556AssinaturaParticipanteTokenUsed);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101918473", true, true);
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
         context.AddJavascriptSource("assinaturaparticipantetoken.js", "?20256101918474", false, true);
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
         edtAssinaturaParticipanteTokenId_Internalname = "ASSINATURAPARTICIPANTETOKENID";
         edtAssinaturaParticipanteId_Internalname = "ASSINATURAPARTICIPANTEID";
         edtAssinaturaParticipanteTokenExpire_Internalname = "ASSINATURAPARTICIPANTETOKENEXPIRE";
         chkAssinaturaParticipanteTokenUsed_Internalname = "ASSINATURAPARTICIPANTETOKENUSED";
         edtAssinaturaParticipanteTokenContent_Internalname = "ASSINATURAPARTICIPANTETOKENCONTENT";
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
         Form.Caption = "Assinatura Participante Token";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAssinaturaParticipanteTokenContent_Jsonclick = "";
         edtAssinaturaParticipanteTokenContent_Enabled = 1;
         chkAssinaturaParticipanteTokenUsed.Enabled = 1;
         edtAssinaturaParticipanteTokenExpire_Jsonclick = "";
         edtAssinaturaParticipanteTokenExpire_Enabled = 1;
         edtAssinaturaParticipanteId_Jsonclick = "";
         edtAssinaturaParticipanteId_Enabled = 1;
         edtAssinaturaParticipanteTokenId_Jsonclick = "";
         edtAssinaturaParticipanteTokenId_Enabled = 1;
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
         chkAssinaturaParticipanteTokenUsed.Name = "ASSINATURAPARTICIPANTETOKENUSED";
         chkAssinaturaParticipanteTokenUsed.WebTags = "";
         chkAssinaturaParticipanteTokenUsed.Caption = "Token Used";
         AssignProp("", false, chkAssinaturaParticipanteTokenUsed_Internalname, "TitleCaption", chkAssinaturaParticipanteTokenUsed.Caption, true);
         chkAssinaturaParticipanteTokenUsed.CheckedValue = "false";
         if ( IsIns( ) && (false==A556AssinaturaParticipanteTokenUsed) )
         {
            A556AssinaturaParticipanteTokenUsed = false;
            n556AssinaturaParticipanteTokenUsed = false;
            AssignAttri("", false, "A556AssinaturaParticipanteTokenUsed", A556AssinaturaParticipanteTokenUsed);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
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

      public void Valid_Assinaturaparticipantetokenid( )
      {
         n556AssinaturaParticipanteTokenUsed = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A556AssinaturaParticipanteTokenUsed = StringUtil.StrToBool( StringUtil.BoolToStr( A556AssinaturaParticipanteTokenUsed));
         n556AssinaturaParticipanteTokenUsed = false;
         /*  Sending validation outputs */
         AssignAttri("", false, "A242AssinaturaParticipanteId", ((0==A242AssinaturaParticipanteId)&&IsIns( )||n242AssinaturaParticipanteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A242AssinaturaParticipanteId), 9, 0, ".", ""))));
         AssignAttri("", false, "A555AssinaturaParticipanteTokenExpire", context.localUtil.TToC( A555AssinaturaParticipanteTokenExpire, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A556AssinaturaParticipanteTokenUsed", A556AssinaturaParticipanteTokenUsed);
         AssignAttri("", false, "A557AssinaturaParticipanteTokenContent", A557AssinaturaParticipanteTokenContent);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z554AssinaturaParticipanteTokenId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z554AssinaturaParticipanteTokenId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z242AssinaturaParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z242AssinaturaParticipanteId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z555AssinaturaParticipanteTokenExpire", context.localUtil.TToC( Z555AssinaturaParticipanteTokenExpire, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z556AssinaturaParticipanteTokenUsed", StringUtil.BoolToStr( Z556AssinaturaParticipanteTokenUsed));
         GxWebStd.gx_hidden_field( context, "Z557AssinaturaParticipanteTokenContent", Z557AssinaturaParticipanteTokenContent);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Assinaturaparticipanteid( )
      {
         /* Using cursor T002415 */
         pr_default.execute(13, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A242AssinaturaParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'AssinaturaParticipante'.", "ForeignKeyNotFound", 1, "ASSINATURAPARTICIPANTEID");
               AnyError = 1;
               GX_FocusControl = edtAssinaturaParticipanteId_Internalname;
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
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"A556AssinaturaParticipanteTokenUsed","fld":"ASSINATURAPARTICIPANTETOKENUSED","type":"boolean"}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"A556AssinaturaParticipanteTokenUsed","fld":"ASSINATURAPARTICIPANTETOKENUSED","type":"boolean"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"A556AssinaturaParticipanteTokenUsed","fld":"ASSINATURAPARTICIPANTETOKENUSED","type":"boolean"}]""");
         setEventMetadata("REFRESH",""","oparms":[{"av":"A556AssinaturaParticipanteTokenUsed","fld":"ASSINATURAPARTICIPANTETOKENUSED","type":"boolean"}]}""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTETOKENID","""{"handler":"Valid_Assinaturaparticipantetokenid","iparms":[{"av":"A554AssinaturaParticipanteTokenId","fld":"ASSINATURAPARTICIPANTETOKENID","pic":"ZZZZZZZZ9","type":"int"},{"av":"Gx_BScreen","fld":"vGXBSCREEN","pic":"9","type":"int"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"A556AssinaturaParticipanteTokenUsed","fld":"ASSINATURAPARTICIPANTETOKENUSED","type":"boolean"}]""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTETOKENID",""","oparms":[{"av":"A242AssinaturaParticipanteId","fld":"ASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","nullAv":"n242AssinaturaParticipanteId","type":"int"},{"av":"A555AssinaturaParticipanteTokenExpire","fld":"ASSINATURAPARTICIPANTETOKENEXPIRE","pic":"99/99/99 99:99","type":"dtime"},{"av":"A557AssinaturaParticipanteTokenContent","fld":"ASSINATURAPARTICIPANTETOKENCONTENT","type":"svchar"},{"av":"Gx_mode","fld":"vMODE","pic":"@!","type":"char"},{"av":"Z554AssinaturaParticipanteTokenId","type":"int"},{"av":"Z242AssinaturaParticipanteId","type":"int"},{"av":"Z555AssinaturaParticipanteTokenExpire","type":"dtime"},{"av":"Z556AssinaturaParticipanteTokenUsed","type":"boolean"},{"av":"Z557AssinaturaParticipanteTokenContent","type":"svchar"},{"ctrl":"BTN_DELETE","prop":"Enabled"},{"ctrl":"BTN_ENTER","prop":"Enabled"},{"av":"A556AssinaturaParticipanteTokenUsed","fld":"ASSINATURAPARTICIPANTETOKENUSED","type":"boolean"}]}""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTEID","""{"handler":"Valid_Assinaturaparticipanteid","iparms":[{"av":"A242AssinaturaParticipanteId","fld":"ASSINATURAPARTICIPANTEID","pic":"ZZZZZZZZ9","nullAv":"n242AssinaturaParticipanteId","type":"int"},{"av":"A556AssinaturaParticipanteTokenUsed","fld":"ASSINATURAPARTICIPANTETOKENUSED","type":"boolean"}]""");
         setEventMetadata("VALID_ASSINATURAPARTICIPANTEID",""","oparms":[{"av":"A556AssinaturaParticipanteTokenUsed","fld":"ASSINATURAPARTICIPANTETOKENUSED","type":"boolean"}]}""");
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
         Z555AssinaturaParticipanteTokenExpire = (DateTime)(DateTime.MinValue);
         Z557AssinaturaParticipanteTokenContent = "";
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
         A555AssinaturaParticipanteTokenExpire = (DateTime)(DateTime.MinValue);
         A557AssinaturaParticipanteTokenContent = "";
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
         T00245_A554AssinaturaParticipanteTokenId = new int[1] ;
         T00245_A555AssinaturaParticipanteTokenExpire = new DateTime[] {DateTime.MinValue} ;
         T00245_n555AssinaturaParticipanteTokenExpire = new bool[] {false} ;
         T00245_A556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         T00245_n556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         T00245_A557AssinaturaParticipanteTokenContent = new string[] {""} ;
         T00245_n557AssinaturaParticipanteTokenContent = new bool[] {false} ;
         T00245_A242AssinaturaParticipanteId = new int[1] ;
         T00245_n242AssinaturaParticipanteId = new bool[] {false} ;
         T00244_A242AssinaturaParticipanteId = new int[1] ;
         T00244_n242AssinaturaParticipanteId = new bool[] {false} ;
         T00246_A242AssinaturaParticipanteId = new int[1] ;
         T00246_n242AssinaturaParticipanteId = new bool[] {false} ;
         T00247_A554AssinaturaParticipanteTokenId = new int[1] ;
         T00243_A554AssinaturaParticipanteTokenId = new int[1] ;
         T00243_A555AssinaturaParticipanteTokenExpire = new DateTime[] {DateTime.MinValue} ;
         T00243_n555AssinaturaParticipanteTokenExpire = new bool[] {false} ;
         T00243_A556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         T00243_n556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         T00243_A557AssinaturaParticipanteTokenContent = new string[] {""} ;
         T00243_n557AssinaturaParticipanteTokenContent = new bool[] {false} ;
         T00243_A242AssinaturaParticipanteId = new int[1] ;
         T00243_n242AssinaturaParticipanteId = new bool[] {false} ;
         sMode76 = "";
         T00248_A554AssinaturaParticipanteTokenId = new int[1] ;
         T00249_A554AssinaturaParticipanteTokenId = new int[1] ;
         T00242_A554AssinaturaParticipanteTokenId = new int[1] ;
         T00242_A555AssinaturaParticipanteTokenExpire = new DateTime[] {DateTime.MinValue} ;
         T00242_n555AssinaturaParticipanteTokenExpire = new bool[] {false} ;
         T00242_A556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         T00242_n556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         T00242_A557AssinaturaParticipanteTokenContent = new string[] {""} ;
         T00242_n557AssinaturaParticipanteTokenContent = new bool[] {false} ;
         T00242_A242AssinaturaParticipanteId = new int[1] ;
         T00242_n242AssinaturaParticipanteId = new bool[] {false} ;
         T002411_A554AssinaturaParticipanteTokenId = new int[1] ;
         T002414_A554AssinaturaParticipanteTokenId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ555AssinaturaParticipanteTokenExpire = (DateTime)(DateTime.MinValue);
         ZZ557AssinaturaParticipanteTokenContent = "";
         T002415_A242AssinaturaParticipanteId = new int[1] ;
         T002415_n242AssinaturaParticipanteId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinaturaparticipantetoken__default(),
            new Object[][] {
                new Object[] {
               T00242_A554AssinaturaParticipanteTokenId, T00242_A555AssinaturaParticipanteTokenExpire, T00242_n555AssinaturaParticipanteTokenExpire, T00242_A556AssinaturaParticipanteTokenUsed, T00242_n556AssinaturaParticipanteTokenUsed, T00242_A557AssinaturaParticipanteTokenContent, T00242_n557AssinaturaParticipanteTokenContent, T00242_A242AssinaturaParticipanteId, T00242_n242AssinaturaParticipanteId
               }
               , new Object[] {
               T00243_A554AssinaturaParticipanteTokenId, T00243_A555AssinaturaParticipanteTokenExpire, T00243_n555AssinaturaParticipanteTokenExpire, T00243_A556AssinaturaParticipanteTokenUsed, T00243_n556AssinaturaParticipanteTokenUsed, T00243_A557AssinaturaParticipanteTokenContent, T00243_n557AssinaturaParticipanteTokenContent, T00243_A242AssinaturaParticipanteId, T00243_n242AssinaturaParticipanteId
               }
               , new Object[] {
               T00244_A242AssinaturaParticipanteId
               }
               , new Object[] {
               T00245_A554AssinaturaParticipanteTokenId, T00245_A555AssinaturaParticipanteTokenExpire, T00245_n555AssinaturaParticipanteTokenExpire, T00245_A556AssinaturaParticipanteTokenUsed, T00245_n556AssinaturaParticipanteTokenUsed, T00245_A557AssinaturaParticipanteTokenContent, T00245_n557AssinaturaParticipanteTokenContent, T00245_A242AssinaturaParticipanteId, T00245_n242AssinaturaParticipanteId
               }
               , new Object[] {
               T00246_A242AssinaturaParticipanteId
               }
               , new Object[] {
               T00247_A554AssinaturaParticipanteTokenId
               }
               , new Object[] {
               T00248_A554AssinaturaParticipanteTokenId
               }
               , new Object[] {
               T00249_A554AssinaturaParticipanteTokenId
               }
               , new Object[] {
               }
               , new Object[] {
               T002411_A554AssinaturaParticipanteTokenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002414_A554AssinaturaParticipanteTokenId
               }
               , new Object[] {
               T002415_A242AssinaturaParticipanteId
               }
            }
         );
         Z556AssinaturaParticipanteTokenUsed = false;
         n556AssinaturaParticipanteTokenUsed = false;
         A556AssinaturaParticipanteTokenUsed = false;
         n556AssinaturaParticipanteTokenUsed = false;
         i556AssinaturaParticipanteTokenUsed = false;
         n556AssinaturaParticipanteTokenUsed = false;
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short Gx_BScreen ;
      private short RcdFound76 ;
      private short gxajaxcallmode ;
      private int Z554AssinaturaParticipanteTokenId ;
      private int Z242AssinaturaParticipanteId ;
      private int A242AssinaturaParticipanteId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A554AssinaturaParticipanteTokenId ;
      private int edtAssinaturaParticipanteTokenId_Enabled ;
      private int edtAssinaturaParticipanteId_Enabled ;
      private int edtAssinaturaParticipanteTokenExpire_Enabled ;
      private int edtAssinaturaParticipanteTokenContent_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ554AssinaturaParticipanteTokenId ;
      private int ZZ242AssinaturaParticipanteId ;
      private string sPrefix ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAssinaturaParticipanteTokenId_Internalname ;
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
      private string edtAssinaturaParticipanteTokenId_Jsonclick ;
      private string edtAssinaturaParticipanteId_Internalname ;
      private string edtAssinaturaParticipanteId_Jsonclick ;
      private string edtAssinaturaParticipanteTokenExpire_Internalname ;
      private string edtAssinaturaParticipanteTokenExpire_Jsonclick ;
      private string chkAssinaturaParticipanteTokenUsed_Internalname ;
      private string edtAssinaturaParticipanteTokenContent_Internalname ;
      private string edtAssinaturaParticipanteTokenContent_Jsonclick ;
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
      private string sMode76 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z555AssinaturaParticipanteTokenExpire ;
      private DateTime A555AssinaturaParticipanteTokenExpire ;
      private DateTime ZZ555AssinaturaParticipanteTokenExpire ;
      private bool Z556AssinaturaParticipanteTokenUsed ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n242AssinaturaParticipanteId ;
      private bool wbErr ;
      private bool A556AssinaturaParticipanteTokenUsed ;
      private bool n556AssinaturaParticipanteTokenUsed ;
      private bool n555AssinaturaParticipanteTokenExpire ;
      private bool n557AssinaturaParticipanteTokenContent ;
      private bool i556AssinaturaParticipanteTokenUsed ;
      private bool ZZ556AssinaturaParticipanteTokenUsed ;
      private string Z557AssinaturaParticipanteTokenContent ;
      private string A557AssinaturaParticipanteTokenContent ;
      private string ZZ557AssinaturaParticipanteTokenContent ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkAssinaturaParticipanteTokenUsed ;
      private IDataStoreProvider pr_default ;
      private int[] T00245_A554AssinaturaParticipanteTokenId ;
      private DateTime[] T00245_A555AssinaturaParticipanteTokenExpire ;
      private bool[] T00245_n555AssinaturaParticipanteTokenExpire ;
      private bool[] T00245_A556AssinaturaParticipanteTokenUsed ;
      private bool[] T00245_n556AssinaturaParticipanteTokenUsed ;
      private string[] T00245_A557AssinaturaParticipanteTokenContent ;
      private bool[] T00245_n557AssinaturaParticipanteTokenContent ;
      private int[] T00245_A242AssinaturaParticipanteId ;
      private bool[] T00245_n242AssinaturaParticipanteId ;
      private int[] T00244_A242AssinaturaParticipanteId ;
      private bool[] T00244_n242AssinaturaParticipanteId ;
      private int[] T00246_A242AssinaturaParticipanteId ;
      private bool[] T00246_n242AssinaturaParticipanteId ;
      private int[] T00247_A554AssinaturaParticipanteTokenId ;
      private int[] T00243_A554AssinaturaParticipanteTokenId ;
      private DateTime[] T00243_A555AssinaturaParticipanteTokenExpire ;
      private bool[] T00243_n555AssinaturaParticipanteTokenExpire ;
      private bool[] T00243_A556AssinaturaParticipanteTokenUsed ;
      private bool[] T00243_n556AssinaturaParticipanteTokenUsed ;
      private string[] T00243_A557AssinaturaParticipanteTokenContent ;
      private bool[] T00243_n557AssinaturaParticipanteTokenContent ;
      private int[] T00243_A242AssinaturaParticipanteId ;
      private bool[] T00243_n242AssinaturaParticipanteId ;
      private int[] T00248_A554AssinaturaParticipanteTokenId ;
      private int[] T00249_A554AssinaturaParticipanteTokenId ;
      private int[] T00242_A554AssinaturaParticipanteTokenId ;
      private DateTime[] T00242_A555AssinaturaParticipanteTokenExpire ;
      private bool[] T00242_n555AssinaturaParticipanteTokenExpire ;
      private bool[] T00242_A556AssinaturaParticipanteTokenUsed ;
      private bool[] T00242_n556AssinaturaParticipanteTokenUsed ;
      private string[] T00242_A557AssinaturaParticipanteTokenContent ;
      private bool[] T00242_n557AssinaturaParticipanteTokenContent ;
      private int[] T00242_A242AssinaturaParticipanteId ;
      private bool[] T00242_n242AssinaturaParticipanteId ;
      private int[] T002411_A554AssinaturaParticipanteTokenId ;
      private int[] T002414_A554AssinaturaParticipanteTokenId ;
      private int[] T002415_A242AssinaturaParticipanteId ;
      private bool[] T002415_n242AssinaturaParticipanteId ;
   }

   public class assinaturaparticipantetoken__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00242;
          prmT00242 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmT00243;
          prmT00243 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmT00244;
          prmT00244 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00245;
          prmT00245 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmT00246;
          prmT00246 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00247;
          prmT00247 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmT00248;
          prmT00248 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmT00249;
          prmT00249 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmT002410;
          prmT002410 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenExpire",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTokenUsed",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTokenContent",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002411;
          prmT002411 = new Object[] {
          };
          Object[] prmT002412;
          prmT002412 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenExpire",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTokenUsed",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTokenContent",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmT002413;
          prmT002413 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmT002414;
          prmT002414 = new Object[] {
          };
          Object[] prmT002415;
          prmT002415 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00242", "SELECT AssinaturaParticipanteTokenId, AssinaturaParticipanteTokenExpire, AssinaturaParticipanteTokenUsed, AssinaturaParticipanteTokenContent, AssinaturaParticipanteId FROM AssinaturaParticipanteToken WHERE AssinaturaParticipanteTokenId = :AssinaturaParticipanteTokenId  FOR UPDATE OF AssinaturaParticipanteToken NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00242,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00243", "SELECT AssinaturaParticipanteTokenId, AssinaturaParticipanteTokenExpire, AssinaturaParticipanteTokenUsed, AssinaturaParticipanteTokenContent, AssinaturaParticipanteId FROM AssinaturaParticipanteToken WHERE AssinaturaParticipanteTokenId = :AssinaturaParticipanteTokenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00243,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00244", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00244,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00245", "SELECT TM1.AssinaturaParticipanteTokenId, TM1.AssinaturaParticipanteTokenExpire, TM1.AssinaturaParticipanteTokenUsed, TM1.AssinaturaParticipanteTokenContent, TM1.AssinaturaParticipanteId FROM AssinaturaParticipanteToken TM1 WHERE TM1.AssinaturaParticipanteTokenId = :AssinaturaParticipanteTokenId ORDER BY TM1.AssinaturaParticipanteTokenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00245,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00246", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00246,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00247", "SELECT AssinaturaParticipanteTokenId FROM AssinaturaParticipanteToken WHERE AssinaturaParticipanteTokenId = :AssinaturaParticipanteTokenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00247,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00248", "SELECT AssinaturaParticipanteTokenId FROM AssinaturaParticipanteToken WHERE ( AssinaturaParticipanteTokenId > :AssinaturaParticipanteTokenId) ORDER BY AssinaturaParticipanteTokenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00248,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00249", "SELECT AssinaturaParticipanteTokenId FROM AssinaturaParticipanteToken WHERE ( AssinaturaParticipanteTokenId < :AssinaturaParticipanteTokenId) ORDER BY AssinaturaParticipanteTokenId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00249,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002410", "SAVEPOINT gxupdate;INSERT INTO AssinaturaParticipanteToken(AssinaturaParticipanteTokenExpire, AssinaturaParticipanteTokenUsed, AssinaturaParticipanteTokenContent, AssinaturaParticipanteId) VALUES(:AssinaturaParticipanteTokenExpire, :AssinaturaParticipanteTokenUsed, :AssinaturaParticipanteTokenContent, :AssinaturaParticipanteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002410)
             ,new CursorDef("T002411", "SELECT currval('AssinaturaParticipanteTokenId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002411,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002412", "SAVEPOINT gxupdate;UPDATE AssinaturaParticipanteToken SET AssinaturaParticipanteTokenExpire=:AssinaturaParticipanteTokenExpire, AssinaturaParticipanteTokenUsed=:AssinaturaParticipanteTokenUsed, AssinaturaParticipanteTokenContent=:AssinaturaParticipanteTokenContent, AssinaturaParticipanteId=:AssinaturaParticipanteId  WHERE AssinaturaParticipanteTokenId = :AssinaturaParticipanteTokenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002412)
             ,new CursorDef("T002413", "SAVEPOINT gxupdate;DELETE FROM AssinaturaParticipanteToken  WHERE AssinaturaParticipanteTokenId = :AssinaturaParticipanteTokenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002413)
             ,new CursorDef("T002414", "SELECT AssinaturaParticipanteTokenId FROM AssinaturaParticipanteToken ORDER BY AssinaturaParticipanteTokenId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002414,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002415", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002415,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
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
