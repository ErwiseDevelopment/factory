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
   public class reembolsoassinaturas : GXDataArea
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
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
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
            gxLoad_12( A518ReembolsoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A572PropostaContratoAssinaturaId = (int)(Math.Round(NumberUtil.Val( GetPar( "PropostaContratoAssinaturaId"), "."), 18, MidpointRounding.ToEven));
            n572PropostaContratoAssinaturaId = false;
            AssignAttri("", false, "A572PropostaContratoAssinaturaId", ((0==A572PropostaContratoAssinaturaId)&&IsIns( )||n572PropostaContratoAssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A572PropostaContratoAssinaturaId) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            GxWebError = 1;
            context.HttpContext.Response.StatusCode = 403;
            context.WriteHtmlText( "<title>403 Forbidden</title>") ;
            context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
            context.WriteHtmlText( "<p /><hr />") ;
            GXUtil.WriteLog("send_http_error_code " + 403.ToString());
         }
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "reembolsoassinaturas")), "reembolsoassinaturas") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "reembolsoassinaturas")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7ReembolsoAssinaturasId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoAssinaturasId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(AV7ReembolsoAssinaturasId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOASSINATURASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ReembolsoAssinaturasId), "ZZZZZZZZ9"), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
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
         Form.Meta.addItem("description", "Reembolso Assinaturas", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtReembolsoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public reembolsoassinaturas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoassinaturas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ReembolsoAssinaturasId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ReembolsoAssinaturasId = aP1_ReembolsoAssinaturasId;
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction TableMainFixedActions", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoAssinaturasId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoAssinaturasId_Internalname, "Assinaturas Id", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoAssinaturasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A631ReembolsoAssinaturasId), 9, 0, ",", "")), StringUtil.LTrim( ((edtReembolsoAssinaturasId_Enabled!=0) ? context.localUtil.Format( (decimal)(A631ReembolsoAssinaturasId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A631ReembolsoAssinaturasId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoAssinaturasId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoAssinaturasId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoAssinaturas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedreembolsoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockreembolsoid_Internalname, "Reembolso", "", "", lblTextblockreembolsoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ReembolsoAssinaturas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_reembolsoid.SetProperty("Caption", Combo_reembolsoid_Caption);
         ucCombo_reembolsoid.SetProperty("Cls", Combo_reembolsoid_Cls);
         ucCombo_reembolsoid.SetProperty("DataListProc", Combo_reembolsoid_Datalistproc);
         ucCombo_reembolsoid.SetProperty("DataListProcParametersPrefix", Combo_reembolsoid_Datalistprocparametersprefix);
         ucCombo_reembolsoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_reembolsoid.SetProperty("DropDownOptionsData", AV14ReembolsoId_Data);
         ucCombo_reembolsoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_reembolsoid_Internalname, "COMBO_REEMBOLSOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoId_Internalname, "Reembolso Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoId_Internalname, ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ",", ""))), ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A518ReembolsoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoId_Jsonclick, 0, "Attribute", "", "", "", "", edtReembolsoId_Visible, edtReembolsoId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoAssinaturas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedpropostacontratoassinaturaid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockpropostacontratoassinaturaid_Internalname, "Proposta Contrato Assinatura", "", "", lblTextblockpropostacontratoassinaturaid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_ReembolsoAssinaturas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_propostacontratoassinaturaid.SetProperty("Caption", Combo_propostacontratoassinaturaid_Caption);
         ucCombo_propostacontratoassinaturaid.SetProperty("Cls", Combo_propostacontratoassinaturaid_Cls);
         ucCombo_propostacontratoassinaturaid.SetProperty("DataListProc", Combo_propostacontratoassinaturaid_Datalistproc);
         ucCombo_propostacontratoassinaturaid.SetProperty("DataListProcParametersPrefix", Combo_propostacontratoassinaturaid_Datalistprocparametersprefix);
         ucCombo_propostacontratoassinaturaid.SetProperty("DropDownOptionsTitleSettingsIcons", AV15DDO_TitleSettingsIcons);
         ucCombo_propostacontratoassinaturaid.SetProperty("DropDownOptionsData", AV20PropostaContratoAssinaturaId_Data);
         ucCombo_propostacontratoassinaturaid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_propostacontratoassinaturaid_Internalname, "COMBO_PROPOSTACONTRATOASSINATURAIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPropostaContratoAssinaturaId_Internalname, "Proposta Contrato Assinatura Id", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPropostaContratoAssinaturaId_Internalname, ((0==A572PropostaContratoAssinaturaId)&&IsIns( )||n572PropostaContratoAssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ",", ""))), ((0==A572PropostaContratoAssinaturaId)&&IsIns( )||n572PropostaContratoAssinaturaId ? "" : StringUtil.LTrim( context.localUtil.Format( (decimal)(A572PropostaContratoAssinaturaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPropostaContratoAssinaturaId_Jsonclick, 0, "Attribute", "", "", "", "", edtPropostaContratoAssinaturaId_Visible, edtPropostaContratoAssinaturaId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_ReembolsoAssinaturas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoAssinaturasNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoAssinaturasNome_Internalname, "Nome amigável do arquivo/documento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtReembolsoAssinaturasNome_Internalname, A632ReembolsoAssinaturasNome, StringUtil.RTrim( context.localUtil.Format( A632ReembolsoAssinaturasNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoAssinaturasNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoAssinaturasNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_ReembolsoAssinaturas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtReembolsoAssinaturasEmissao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtReembolsoAssinaturasEmissao_Internalname, "Data/hora de emissão", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtReembolsoAssinaturasEmissao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtReembolsoAssinaturasEmissao_Internalname, context.localUtil.TToC( A633ReembolsoAssinaturasEmissao, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A633ReembolsoAssinaturasEmissao, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtReembolsoAssinaturasEmissao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtReembolsoAssinaturasEmissao_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoAssinaturas.htm");
         GxWebStd.gx_bitmap( context, edtReembolsoAssinaturasEmissao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtReembolsoAssinaturasEmissao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ReembolsoAssinaturas.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupFixedBottom CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoAssinaturas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoAssinaturas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ReembolsoAssinaturas.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_reembolsoid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavComboreembolsoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19ComboReembolsoId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavComboreembolsoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV19ComboReembolsoId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV19ComboReembolsoId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboreembolsoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboreembolsoid_Visible, edtavComboreembolsoid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoAssinaturas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_propostacontratoassinaturaid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombopropostacontratoassinaturaid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ComboPropostaContratoAssinaturaId), 9, 0, ",", "")), StringUtil.LTrim( ((edtavCombopropostacontratoassinaturaid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV21ComboPropostaContratoAssinaturaId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV21ComboPropostaContratoAssinaturaId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,70);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombopropostacontratoassinaturaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombopropostacontratoassinaturaid_Visible, edtavCombopropostacontratoassinaturaid_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_ReembolsoAssinaturas.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112B2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV15DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vREEMBOLSOID_DATA"), AV14ReembolsoId_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vPROPOSTACONTRATOASSINATURAID_DATA"), AV20PropostaContratoAssinaturaId_Data);
               /* Read saved values. */
               Z631ReembolsoAssinaturasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z631ReembolsoAssinaturasId"), ",", "."), 18, MidpointRounding.ToEven));
               Z632ReembolsoAssinaturasNome = cgiGet( "Z632ReembolsoAssinaturasNome");
               n632ReembolsoAssinaturasNome = (String.IsNullOrEmpty(StringUtil.RTrim( A632ReembolsoAssinaturasNome)) ? true : false);
               Z633ReembolsoAssinaturasEmissao = context.localUtil.CToT( cgiGet( "Z633ReembolsoAssinaturasEmissao"), 0);
               n633ReembolsoAssinaturasEmissao = ((DateTime.MinValue==A633ReembolsoAssinaturasEmissao) ? true : false);
               Z518ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z518ReembolsoId"), ",", "."), 18, MidpointRounding.ToEven));
               n518ReembolsoId = ((0==A518ReembolsoId) ? true : false);
               Z572PropostaContratoAssinaturaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z572PropostaContratoAssinaturaId"), ",", "."), 18, MidpointRounding.ToEven));
               n572PropostaContratoAssinaturaId = ((0==A572PropostaContratoAssinaturaId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N518ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N518ReembolsoId"), ",", "."), 18, MidpointRounding.ToEven));
               n518ReembolsoId = ((0==A518ReembolsoId) ? true : false);
               N572PropostaContratoAssinaturaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N572PropostaContratoAssinaturaId"), ",", "."), 18, MidpointRounding.ToEven));
               n572PropostaContratoAssinaturaId = ((0==A572PropostaContratoAssinaturaId) ? true : false);
               AV7ReembolsoAssinaturasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vREEMBOLSOASSINATURASID"), ",", "."), 18, MidpointRounding.ToEven));
               AV11Insert_ReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_REEMBOLSOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV11Insert_ReembolsoId", StringUtil.LTrimStr( (decimal)(AV11Insert_ReembolsoId), 9, 0));
               AV12Insert_PropostaContratoAssinaturaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PROPOSTACONTRATOASSINATURAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV12Insert_PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(AV12Insert_PropostaContratoAssinaturaId), 9, 0));
               A571PropostaAssinatura = (long)(Math.Round(context.localUtil.CToN( cgiGet( "PROPOSTAASSINATURA"), ",", "."), 18, MidpointRounding.ToEven));
               n571PropostaAssinatura = false;
               AV22Pgmname = cgiGet( "vPGMNAME");
               Combo_reembolsoid_Objectcall = cgiGet( "COMBO_REEMBOLSOID_Objectcall");
               Combo_reembolsoid_Class = cgiGet( "COMBO_REEMBOLSOID_Class");
               Combo_reembolsoid_Icontype = cgiGet( "COMBO_REEMBOLSOID_Icontype");
               Combo_reembolsoid_Icon = cgiGet( "COMBO_REEMBOLSOID_Icon");
               Combo_reembolsoid_Caption = cgiGet( "COMBO_REEMBOLSOID_Caption");
               Combo_reembolsoid_Tooltip = cgiGet( "COMBO_REEMBOLSOID_Tooltip");
               Combo_reembolsoid_Cls = cgiGet( "COMBO_REEMBOLSOID_Cls");
               Combo_reembolsoid_Selectedvalue_set = cgiGet( "COMBO_REEMBOLSOID_Selectedvalue_set");
               Combo_reembolsoid_Selectedvalue_get = cgiGet( "COMBO_REEMBOLSOID_Selectedvalue_get");
               Combo_reembolsoid_Selectedtext_set = cgiGet( "COMBO_REEMBOLSOID_Selectedtext_set");
               Combo_reembolsoid_Selectedtext_get = cgiGet( "COMBO_REEMBOLSOID_Selectedtext_get");
               Combo_reembolsoid_Gamoauthtoken = cgiGet( "COMBO_REEMBOLSOID_Gamoauthtoken");
               Combo_reembolsoid_Ddointernalname = cgiGet( "COMBO_REEMBOLSOID_Ddointernalname");
               Combo_reembolsoid_Titlecontrolalign = cgiGet( "COMBO_REEMBOLSOID_Titlecontrolalign");
               Combo_reembolsoid_Dropdownoptionstype = cgiGet( "COMBO_REEMBOLSOID_Dropdownoptionstype");
               Combo_reembolsoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOID_Enabled"));
               Combo_reembolsoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOID_Visible"));
               Combo_reembolsoid_Titlecontrolidtoreplace = cgiGet( "COMBO_REEMBOLSOID_Titlecontrolidtoreplace");
               Combo_reembolsoid_Datalisttype = cgiGet( "COMBO_REEMBOLSOID_Datalisttype");
               Combo_reembolsoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOID_Allowmultipleselection"));
               Combo_reembolsoid_Datalistfixedvalues = cgiGet( "COMBO_REEMBOLSOID_Datalistfixedvalues");
               Combo_reembolsoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOID_Isgriditem"));
               Combo_reembolsoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOID_Hasdescription"));
               Combo_reembolsoid_Datalistproc = cgiGet( "COMBO_REEMBOLSOID_Datalistproc");
               Combo_reembolsoid_Datalistprocparametersprefix = cgiGet( "COMBO_REEMBOLSOID_Datalistprocparametersprefix");
               Combo_reembolsoid_Remoteservicesparameters = cgiGet( "COMBO_REEMBOLSOID_Remoteservicesparameters");
               Combo_reembolsoid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REEMBOLSOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_reembolsoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOID_Includeonlyselectedoption"));
               Combo_reembolsoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOID_Includeselectalloption"));
               Combo_reembolsoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOID_Emptyitem"));
               Combo_reembolsoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_REEMBOLSOID_Includeaddnewoption"));
               Combo_reembolsoid_Htmltemplate = cgiGet( "COMBO_REEMBOLSOID_Htmltemplate");
               Combo_reembolsoid_Multiplevaluestype = cgiGet( "COMBO_REEMBOLSOID_Multiplevaluestype");
               Combo_reembolsoid_Loadingdata = cgiGet( "COMBO_REEMBOLSOID_Loadingdata");
               Combo_reembolsoid_Noresultsfound = cgiGet( "COMBO_REEMBOLSOID_Noresultsfound");
               Combo_reembolsoid_Emptyitemtext = cgiGet( "COMBO_REEMBOLSOID_Emptyitemtext");
               Combo_reembolsoid_Onlyselectedvalues = cgiGet( "COMBO_REEMBOLSOID_Onlyselectedvalues");
               Combo_reembolsoid_Selectalltext = cgiGet( "COMBO_REEMBOLSOID_Selectalltext");
               Combo_reembolsoid_Multiplevaluesseparator = cgiGet( "COMBO_REEMBOLSOID_Multiplevaluesseparator");
               Combo_reembolsoid_Addnewoptiontext = cgiGet( "COMBO_REEMBOLSOID_Addnewoptiontext");
               Combo_reembolsoid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_REEMBOLSOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_propostacontratoassinaturaid_Objectcall = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Objectcall");
               Combo_propostacontratoassinaturaid_Class = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Class");
               Combo_propostacontratoassinaturaid_Icontype = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Icontype");
               Combo_propostacontratoassinaturaid_Icon = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Icon");
               Combo_propostacontratoassinaturaid_Caption = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Caption");
               Combo_propostacontratoassinaturaid_Tooltip = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Tooltip");
               Combo_propostacontratoassinaturaid_Cls = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Cls");
               Combo_propostacontratoassinaturaid_Selectedvalue_set = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Selectedvalue_set");
               Combo_propostacontratoassinaturaid_Selectedvalue_get = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Selectedvalue_get");
               Combo_propostacontratoassinaturaid_Selectedtext_set = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Selectedtext_set");
               Combo_propostacontratoassinaturaid_Selectedtext_get = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Selectedtext_get");
               Combo_propostacontratoassinaturaid_Gamoauthtoken = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Gamoauthtoken");
               Combo_propostacontratoassinaturaid_Ddointernalname = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Ddointernalname");
               Combo_propostacontratoassinaturaid_Titlecontrolalign = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Titlecontrolalign");
               Combo_propostacontratoassinaturaid_Dropdownoptionstype = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Dropdownoptionstype");
               Combo_propostacontratoassinaturaid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Enabled"));
               Combo_propostacontratoassinaturaid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Visible"));
               Combo_propostacontratoassinaturaid_Titlecontrolidtoreplace = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Titlecontrolidtoreplace");
               Combo_propostacontratoassinaturaid_Datalisttype = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Datalisttype");
               Combo_propostacontratoassinaturaid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Allowmultipleselection"));
               Combo_propostacontratoassinaturaid_Datalistfixedvalues = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Datalistfixedvalues");
               Combo_propostacontratoassinaturaid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Isgriditem"));
               Combo_propostacontratoassinaturaid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Hasdescription"));
               Combo_propostacontratoassinaturaid_Datalistproc = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Datalistproc");
               Combo_propostacontratoassinaturaid_Datalistprocparametersprefix = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Datalistprocparametersprefix");
               Combo_propostacontratoassinaturaid_Remoteservicesparameters = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Remoteservicesparameters");
               Combo_propostacontratoassinaturaid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_propostacontratoassinaturaid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Includeonlyselectedoption"));
               Combo_propostacontratoassinaturaid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Includeselectalloption"));
               Combo_propostacontratoassinaturaid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Emptyitem"));
               Combo_propostacontratoassinaturaid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Includeaddnewoption"));
               Combo_propostacontratoassinaturaid_Htmltemplate = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Htmltemplate");
               Combo_propostacontratoassinaturaid_Multiplevaluestype = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Multiplevaluestype");
               Combo_propostacontratoassinaturaid_Loadingdata = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Loadingdata");
               Combo_propostacontratoassinaturaid_Noresultsfound = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Noresultsfound");
               Combo_propostacontratoassinaturaid_Emptyitemtext = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Emptyitemtext");
               Combo_propostacontratoassinaturaid_Onlyselectedvalues = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Onlyselectedvalues");
               Combo_propostacontratoassinaturaid_Selectalltext = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Selectalltext");
               Combo_propostacontratoassinaturaid_Multiplevaluesseparator = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Multiplevaluesseparator");
               Combo_propostacontratoassinaturaid_Addnewoptiontext = cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Addnewoptiontext");
               Combo_propostacontratoassinaturaid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PROPOSTACONTRATOASSINATURAID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Titletype = cgiGet( "DVPANEL_TABLEATTRIBUTES_Titletype");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A631ReembolsoAssinaturasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoAssinaturasId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A631ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(A631ReembolsoAssinaturasId), 9, 0));
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
               n572PropostaContratoAssinaturaId = ((StringUtil.StrCmp(cgiGet( edtPropostaContratoAssinaturaId_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPropostaContratoAssinaturaId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPropostaContratoAssinaturaId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROPOSTACONTRATOASSINATURAID");
                  AnyError = 1;
                  GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A572PropostaContratoAssinaturaId = 0;
                  n572PropostaContratoAssinaturaId = false;
                  AssignAttri("", false, "A572PropostaContratoAssinaturaId", (n572PropostaContratoAssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ".", ""))));
               }
               else
               {
                  A572PropostaContratoAssinaturaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPropostaContratoAssinaturaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A572PropostaContratoAssinaturaId", (n572PropostaContratoAssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ".", ""))));
               }
               A632ReembolsoAssinaturasNome = cgiGet( edtReembolsoAssinaturasNome_Internalname);
               n632ReembolsoAssinaturasNome = false;
               AssignAttri("", false, "A632ReembolsoAssinaturasNome", A632ReembolsoAssinaturasNome);
               n632ReembolsoAssinaturasNome = (String.IsNullOrEmpty(StringUtil.RTrim( A632ReembolsoAssinaturasNome)) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtReembolsoAssinaturasEmissao_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Reembolso Assinaturas Emissao"}), 1, "REEMBOLSOASSINATURASEMISSAO");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoAssinaturasEmissao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A633ReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
                  n633ReembolsoAssinaturasEmissao = false;
                  AssignAttri("", false, "A633ReembolsoAssinaturasEmissao", context.localUtil.TToC( A633ReembolsoAssinaturasEmissao, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A633ReembolsoAssinaturasEmissao = context.localUtil.CToT( cgiGet( edtReembolsoAssinaturasEmissao_Internalname));
                  n633ReembolsoAssinaturasEmissao = false;
                  AssignAttri("", false, "A633ReembolsoAssinaturasEmissao", context.localUtil.TToC( A633ReembolsoAssinaturasEmissao, 8, 5, 0, 3, "/", ":", " "));
               }
               n633ReembolsoAssinaturasEmissao = ((DateTime.MinValue==A633ReembolsoAssinaturasEmissao) ? true : false);
               AV19ComboReembolsoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboreembolsoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV19ComboReembolsoId", StringUtil.LTrimStr( (decimal)(AV19ComboReembolsoId), 9, 0));
               AV21ComboPropostaContratoAssinaturaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombopropostacontratoassinaturaid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21ComboPropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(AV21ComboPropostaContratoAssinaturaId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ReembolsoAssinaturas");
               A631ReembolsoAssinaturasId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtReembolsoAssinaturasId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A631ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(A631ReembolsoAssinaturasId), 9, 0));
               forbiddenHiddens.Add("ReembolsoAssinaturasId", context.localUtil.Format( (decimal)(A631ReembolsoAssinaturasId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ReembolsoId", context.localUtil.Format( (decimal)(AV11Insert_ReembolsoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_PropostaContratoAssinaturaId", context.localUtil.Format( (decimal)(AV12Insert_PropostaContratoAssinaturaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A631ReembolsoAssinaturasId != Z631ReembolsoAssinaturasId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("reembolsoassinaturas:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A631ReembolsoAssinaturasId = (int)(Math.Round(NumberUtil.Val( GetPar( "ReembolsoAssinaturasId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A631ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(A631ReembolsoAssinaturasId), 9, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode81 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode81;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound81 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_2B0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "REEMBOLSOASSINATURASID");
                        AnyError = 1;
                        GX_FocusControl = edtReembolsoAssinaturasId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E112B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            /* Execute user event: After Trn */
            E122B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2B81( ) ;
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
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes2B81( ) ;
         }
         AssignProp("", false, edtavComboreembolsoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreembolsoid_Enabled), 5, 0), true);
         AssignProp("", false, edtavCombopropostacontratoassinaturaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopropostacontratoassinaturaid_Enabled), 5, 0), true);
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

      protected void CONFIRM_2B0( )
      {
         BeforeValidate2B81( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2B81( ) ;
            }
            else
            {
               CheckExtendedTable2B81( ) ;
               CloseExtendedTableCursors2B81( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption2B0( )
      {
      }

      protected void E112B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV15DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV15DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtPropostaContratoAssinaturaId_Visible = 0;
         AssignProp("", false, edtPropostaContratoAssinaturaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPropostaContratoAssinaturaId_Visible), 5, 0), true);
         AV21ComboPropostaContratoAssinaturaId = 0;
         AssignAttri("", false, "AV21ComboPropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(AV21ComboPropostaContratoAssinaturaId), 9, 0));
         edtavCombopropostacontratoassinaturaid_Visible = 0;
         AssignProp("", false, edtavCombopropostacontratoassinaturaid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombopropostacontratoassinaturaid_Visible), 5, 0), true);
         edtReembolsoId_Visible = 0;
         AssignProp("", false, edtReembolsoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtReembolsoId_Visible), 5, 0), true);
         AV19ComboReembolsoId = 0;
         AssignAttri("", false, "AV19ComboReembolsoId", StringUtil.LTrimStr( (decimal)(AV19ComboReembolsoId), 9, 0));
         edtavComboreembolsoid_Visible = 0;
         AssignProp("", false, edtavComboreembolsoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboreembolsoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOREEMBOLSOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADCOMBOPROPOSTACONTRATOASSINATURAID' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            while ( AV23GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ReembolsoId") == 0 )
               {
                  AV11Insert_ReembolsoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV11Insert_ReembolsoId", StringUtil.LTrimStr( (decimal)(AV11Insert_ReembolsoId), 9, 0));
                  if ( ! (0==AV11Insert_ReembolsoId) )
                  {
                     AV19ComboReembolsoId = AV11Insert_ReembolsoId;
                     AssignAttri("", false, "AV19ComboReembolsoId", StringUtil.LTrimStr( (decimal)(AV19ComboReembolsoId), 9, 0));
                     Combo_reembolsoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV19ComboReembolsoId), 9, 0));
                     ucCombo_reembolsoid.SendProperty(context, "", false, Combo_reembolsoid_Internalname, "SelectedValue_set", Combo_reembolsoid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new reembolsoassinaturasloaddvcombo(context ).execute(  "ReembolsoId",  "GET",  false,  AV7ReembolsoAssinaturasId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_reembolsoid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_reembolsoid.SendProperty(context, "", false, Combo_reembolsoid_Internalname, "SelectedText_set", Combo_reembolsoid_Selectedtext_set);
                     Combo_reembolsoid_Enabled = false;
                     ucCombo_reembolsoid.SendProperty(context, "", false, Combo_reembolsoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_reembolsoid_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaContratoAssinaturaId") == 0 )
               {
                  AV12Insert_PropostaContratoAssinaturaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV12Insert_PropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(AV12Insert_PropostaContratoAssinaturaId), 9, 0));
                  if ( ! (0==AV12Insert_PropostaContratoAssinaturaId) )
                  {
                     AV21ComboPropostaContratoAssinaturaId = AV12Insert_PropostaContratoAssinaturaId;
                     AssignAttri("", false, "AV21ComboPropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(AV21ComboPropostaContratoAssinaturaId), 9, 0));
                     Combo_propostacontratoassinaturaid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV21ComboPropostaContratoAssinaturaId), 9, 0));
                     ucCombo_propostacontratoassinaturaid.SendProperty(context, "", false, Combo_propostacontratoassinaturaid_Internalname, "SelectedValue_set", Combo_propostacontratoassinaturaid_Selectedvalue_set);
                     GXt_char2 = AV18Combo_DataJson;
                     new reembolsoassinaturasloaddvcombo(context ).execute(  "PropostaContratoAssinaturaId",  "GET",  false,  AV7ReembolsoAssinaturasId,  AV13TrnContextAtt.gxTpr_Attributevalue, out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
                     AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
                     AV18Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
                     Combo_propostacontratoassinaturaid_Selectedtext_set = AV17ComboSelectedText;
                     ucCombo_propostacontratoassinaturaid.SendProperty(context, "", false, Combo_propostacontratoassinaturaid_Internalname, "SelectedText_set", Combo_propostacontratoassinaturaid_Selectedtext_set);
                     Combo_propostacontratoassinaturaid_Enabled = false;
                     ucCombo_propostacontratoassinaturaid.SendProperty(context, "", false, Combo_propostacontratoassinaturaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_propostacontratoassinaturaid_Enabled));
                  }
               }
               AV23GXV1 = (int)(AV23GXV1+1);
               AssignAttri("", false, "AV23GXV1", StringUtil.LTrimStr( (decimal)(AV23GXV1), 8, 0));
            }
         }
      }

      protected void E122B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'LOADCOMBOPROPOSTACONTRATOASSINATURAID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new reembolsoassinaturasloaddvcombo(context ).execute(  "PropostaContratoAssinaturaId",  Gx_mode,  false,  AV7ReembolsoAssinaturasId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_propostacontratoassinaturaid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_propostacontratoassinaturaid.SendProperty(context, "", false, Combo_propostacontratoassinaturaid_Internalname, "SelectedValue_set", Combo_propostacontratoassinaturaid_Selectedvalue_set);
         Combo_propostacontratoassinaturaid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_propostacontratoassinaturaid.SendProperty(context, "", false, Combo_propostacontratoassinaturaid_Internalname, "SelectedText_set", Combo_propostacontratoassinaturaid_Selectedtext_set);
         AV21ComboPropostaContratoAssinaturaId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV21ComboPropostaContratoAssinaturaId", StringUtil.LTrimStr( (decimal)(AV21ComboPropostaContratoAssinaturaId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_propostacontratoassinaturaid_Enabled = false;
            ucCombo_propostacontratoassinaturaid.SendProperty(context, "", false, Combo_propostacontratoassinaturaid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_propostacontratoassinaturaid_Enabled));
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOREEMBOLSOID' Routine */
         returnInSub = false;
         GXt_char2 = AV18Combo_DataJson;
         new reembolsoassinaturasloaddvcombo(context ).execute(  "ReembolsoId",  Gx_mode,  false,  AV7ReembolsoAssinaturasId,  "", out  AV16ComboSelectedValue, out  AV17ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV16ComboSelectedValue", AV16ComboSelectedValue);
         AssignAttri("", false, "AV17ComboSelectedText", AV17ComboSelectedText);
         AV18Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV18Combo_DataJson", AV18Combo_DataJson);
         Combo_reembolsoid_Selectedvalue_set = AV16ComboSelectedValue;
         ucCombo_reembolsoid.SendProperty(context, "", false, Combo_reembolsoid_Internalname, "SelectedValue_set", Combo_reembolsoid_Selectedvalue_set);
         Combo_reembolsoid_Selectedtext_set = AV17ComboSelectedText;
         ucCombo_reembolsoid.SendProperty(context, "", false, Combo_reembolsoid_Internalname, "SelectedText_set", Combo_reembolsoid_Selectedtext_set);
         AV19ComboReembolsoId = (int)(Math.Round(NumberUtil.Val( AV16ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV19ComboReembolsoId", StringUtil.LTrimStr( (decimal)(AV19ComboReembolsoId), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_reembolsoid_Enabled = false;
            ucCombo_reembolsoid.SendProperty(context, "", false, Combo_reembolsoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_reembolsoid_Enabled));
         }
      }

      protected void ZM2B81( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z632ReembolsoAssinaturasNome = T002B3_A632ReembolsoAssinaturasNome[0];
               Z633ReembolsoAssinaturasEmissao = T002B3_A633ReembolsoAssinaturasEmissao[0];
               Z518ReembolsoId = T002B3_A518ReembolsoId[0];
               Z572PropostaContratoAssinaturaId = T002B3_A572PropostaContratoAssinaturaId[0];
            }
            else
            {
               Z632ReembolsoAssinaturasNome = A632ReembolsoAssinaturasNome;
               Z633ReembolsoAssinaturasEmissao = A633ReembolsoAssinaturasEmissao;
               Z518ReembolsoId = A518ReembolsoId;
               Z572PropostaContratoAssinaturaId = A572PropostaContratoAssinaturaId;
            }
         }
         if ( GX_JID == -11 )
         {
            Z631ReembolsoAssinaturasId = A631ReembolsoAssinaturasId;
            Z632ReembolsoAssinaturasNome = A632ReembolsoAssinaturasNome;
            Z633ReembolsoAssinaturasEmissao = A633ReembolsoAssinaturasEmissao;
            Z518ReembolsoId = A518ReembolsoId;
            Z572PropostaContratoAssinaturaId = A572PropostaContratoAssinaturaId;
            Z571PropostaAssinatura = A571PropostaAssinatura;
         }
      }

      protected void standaloneNotModal( )
      {
         edtReembolsoAssinaturasId_Enabled = 0;
         AssignProp("", false, edtReembolsoAssinaturasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoAssinaturasId_Enabled), 5, 0), true);
         AV22Pgmname = "ReembolsoAssinaturas";
         AssignAttri("", false, "AV22Pgmname", AV22Pgmname);
         edtReembolsoAssinaturasId_Enabled = 0;
         AssignProp("", false, edtReembolsoAssinaturasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoAssinaturasId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ReembolsoAssinaturasId) )
         {
            A631ReembolsoAssinaturasId = AV7ReembolsoAssinaturasId;
            AssignAttri("", false, "A631ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(A631ReembolsoAssinaturasId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ReembolsoId) )
         {
            edtReembolsoId_Enabled = 0;
            AssignProp("", false, edtReembolsoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoId_Enabled), 5, 0), true);
         }
         else
         {
            edtReembolsoId_Enabled = 1;
            AssignProp("", false, edtReembolsoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_PropostaContratoAssinaturaId) )
         {
            edtPropostaContratoAssinaturaId_Enabled = 0;
            AssignProp("", false, edtPropostaContratoAssinaturaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaContratoAssinaturaId_Enabled), 5, 0), true);
         }
         else
         {
            edtPropostaContratoAssinaturaId_Enabled = 1;
            AssignProp("", false, edtPropostaContratoAssinaturaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaContratoAssinaturaId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ReembolsoId) )
         {
            A518ReembolsoId = AV11Insert_ReembolsoId;
            n518ReembolsoId = false;
            AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV19ComboReembolsoId) )
            {
               A518ReembolsoId = 0;
               n518ReembolsoId = false;
               AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
               n518ReembolsoId = true;
               n518ReembolsoId = true;
               AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV19ComboReembolsoId) )
               {
                  A518ReembolsoId = AV19ComboReembolsoId;
                  n518ReembolsoId = false;
                  AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_PropostaContratoAssinaturaId) )
         {
            A572PropostaContratoAssinaturaId = AV12Insert_PropostaContratoAssinaturaId;
            n572PropostaContratoAssinaturaId = false;
            AssignAttri("", false, "A572PropostaContratoAssinaturaId", ((0==A572PropostaContratoAssinaturaId)&&IsIns( )||n572PropostaContratoAssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==AV21ComboPropostaContratoAssinaturaId) )
            {
               A572PropostaContratoAssinaturaId = 0;
               n572PropostaContratoAssinaturaId = false;
               AssignAttri("", false, "A572PropostaContratoAssinaturaId", ((0==A572PropostaContratoAssinaturaId)&&IsIns( )||n572PropostaContratoAssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ".", ""))));
               n572PropostaContratoAssinaturaId = true;
               n572PropostaContratoAssinaturaId = true;
               AssignAttri("", false, "A572PropostaContratoAssinaturaId", ((0==A572PropostaContratoAssinaturaId)&&IsIns( )||n572PropostaContratoAssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ".", ""))));
            }
            else
            {
               if ( ! (0==AV21ComboPropostaContratoAssinaturaId) )
               {
                  A572PropostaContratoAssinaturaId = AV21ComboPropostaContratoAssinaturaId;
                  n572PropostaContratoAssinaturaId = false;
                  AssignAttri("", false, "A572PropostaContratoAssinaturaId", ((0==A572PropostaContratoAssinaturaId)&&IsIns( )||n572PropostaContratoAssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ".", ""))));
               }
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T002B5 */
            pr_default.execute(3, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
            A571PropostaAssinatura = T002B5_A571PropostaAssinatura[0];
            n571PropostaAssinatura = T002B5_n571PropostaAssinatura[0];
            pr_default.close(3);
         }
      }

      protected void Load2B81( )
      {
         /* Using cursor T002B6 */
         pr_default.execute(4, new Object[] {A631ReembolsoAssinaturasId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound81 = 1;
            A632ReembolsoAssinaturasNome = T002B6_A632ReembolsoAssinaturasNome[0];
            n632ReembolsoAssinaturasNome = T002B6_n632ReembolsoAssinaturasNome[0];
            AssignAttri("", false, "A632ReembolsoAssinaturasNome", A632ReembolsoAssinaturasNome);
            A633ReembolsoAssinaturasEmissao = T002B6_A633ReembolsoAssinaturasEmissao[0];
            n633ReembolsoAssinaturasEmissao = T002B6_n633ReembolsoAssinaturasEmissao[0];
            AssignAttri("", false, "A633ReembolsoAssinaturasEmissao", context.localUtil.TToC( A633ReembolsoAssinaturasEmissao, 8, 5, 0, 3, "/", ":", " "));
            A518ReembolsoId = T002B6_A518ReembolsoId[0];
            n518ReembolsoId = T002B6_n518ReembolsoId[0];
            AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            A572PropostaContratoAssinaturaId = T002B6_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = T002B6_n572PropostaContratoAssinaturaId[0];
            AssignAttri("", false, "A572PropostaContratoAssinaturaId", ((0==A572PropostaContratoAssinaturaId)&&IsIns( )||n572PropostaContratoAssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ".", ""))));
            A571PropostaAssinatura = T002B6_A571PropostaAssinatura[0];
            n571PropostaAssinatura = T002B6_n571PropostaAssinatura[0];
            ZM2B81( -11) ;
         }
         pr_default.close(4);
         OnLoadActions2B81( ) ;
      }

      protected void OnLoadActions2B81( )
      {
      }

      protected void CheckExtendedTable2B81( )
      {
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002B4 */
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
         /* Using cursor T002B5 */
         pr_default.execute(3, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A572PropostaContratoAssinaturaId) ) )
            {
               GX_msglist.addItem("Não existe 'PropostaContratoAssinatura'.", "ForeignKeyNotFound", 1, "PROPOSTACONTRATOASSINATURAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A571PropostaAssinatura = T002B5_A571PropostaAssinatura[0];
         n571PropostaAssinatura = T002B5_n571PropostaAssinatura[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2B81( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( int A518ReembolsoId )
      {
         /* Using cursor T002B7 */
         pr_default.execute(5, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(5) == 101) )
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
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_13( int A572PropostaContratoAssinaturaId )
      {
         /* Using cursor T002B8 */
         pr_default.execute(6, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A572PropostaContratoAssinaturaId) ) )
            {
               GX_msglist.addItem("Não existe 'PropostaContratoAssinatura'.", "ForeignKeyNotFound", 1, "PROPOSTACONTRATOASSINATURAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A571PropostaAssinatura = T002B8_A571PropostaAssinatura[0];
         n571PropostaAssinatura = T002B8_n571PropostaAssinatura[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey2B81( )
      {
         /* Using cursor T002B9 */
         pr_default.execute(7, new Object[] {A631ReembolsoAssinaturasId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound81 = 1;
         }
         else
         {
            RcdFound81 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002B3 */
         pr_default.execute(1, new Object[] {A631ReembolsoAssinaturasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2B81( 11) ;
            RcdFound81 = 1;
            A631ReembolsoAssinaturasId = T002B3_A631ReembolsoAssinaturasId[0];
            AssignAttri("", false, "A631ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(A631ReembolsoAssinaturasId), 9, 0));
            A632ReembolsoAssinaturasNome = T002B3_A632ReembolsoAssinaturasNome[0];
            n632ReembolsoAssinaturasNome = T002B3_n632ReembolsoAssinaturasNome[0];
            AssignAttri("", false, "A632ReembolsoAssinaturasNome", A632ReembolsoAssinaturasNome);
            A633ReembolsoAssinaturasEmissao = T002B3_A633ReembolsoAssinaturasEmissao[0];
            n633ReembolsoAssinaturasEmissao = T002B3_n633ReembolsoAssinaturasEmissao[0];
            AssignAttri("", false, "A633ReembolsoAssinaturasEmissao", context.localUtil.TToC( A633ReembolsoAssinaturasEmissao, 8, 5, 0, 3, "/", ":", " "));
            A518ReembolsoId = T002B3_A518ReembolsoId[0];
            n518ReembolsoId = T002B3_n518ReembolsoId[0];
            AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
            A572PropostaContratoAssinaturaId = T002B3_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = T002B3_n572PropostaContratoAssinaturaId[0];
            AssignAttri("", false, "A572PropostaContratoAssinaturaId", ((0==A572PropostaContratoAssinaturaId)&&IsIns( )||n572PropostaContratoAssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ".", ""))));
            Z631ReembolsoAssinaturasId = A631ReembolsoAssinaturasId;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load2B81( ) ;
            if ( AnyError == 1 )
            {
               RcdFound81 = 0;
               InitializeNonKey2B81( ) ;
            }
            Gx_mode = sMode81;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound81 = 0;
            InitializeNonKey2B81( ) ;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode81;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2B81( ) ;
         if ( RcdFound81 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound81 = 0;
         /* Using cursor T002B10 */
         pr_default.execute(8, new Object[] {A631ReembolsoAssinaturasId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T002B10_A631ReembolsoAssinaturasId[0] < A631ReembolsoAssinaturasId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T002B10_A631ReembolsoAssinaturasId[0] > A631ReembolsoAssinaturasId ) ) )
            {
               A631ReembolsoAssinaturasId = T002B10_A631ReembolsoAssinaturasId[0];
               AssignAttri("", false, "A631ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(A631ReembolsoAssinaturasId), 9, 0));
               RcdFound81 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound81 = 0;
         /* Using cursor T002B11 */
         pr_default.execute(9, new Object[] {A631ReembolsoAssinaturasId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T002B11_A631ReembolsoAssinaturasId[0] > A631ReembolsoAssinaturasId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T002B11_A631ReembolsoAssinaturasId[0] < A631ReembolsoAssinaturasId ) ) )
            {
               A631ReembolsoAssinaturasId = T002B11_A631ReembolsoAssinaturasId[0];
               AssignAttri("", false, "A631ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(A631ReembolsoAssinaturasId), 9, 0));
               RcdFound81 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2B81( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtReembolsoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2B81( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound81 == 1 )
            {
               if ( A631ReembolsoAssinaturasId != Z631ReembolsoAssinaturasId )
               {
                  A631ReembolsoAssinaturasId = Z631ReembolsoAssinaturasId;
                  AssignAttri("", false, "A631ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(A631ReembolsoAssinaturasId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "REEMBOLSOASSINATURASID");
                  AnyError = 1;
                  GX_FocusControl = edtReembolsoAssinaturasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtReembolsoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update2B81( ) ;
                  GX_FocusControl = edtReembolsoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A631ReembolsoAssinaturasId != Z631ReembolsoAssinaturasId )
               {
                  /* Insert record */
                  GX_FocusControl = edtReembolsoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2B81( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "REEMBOLSOASSINATURASID");
                     AnyError = 1;
                     GX_FocusControl = edtReembolsoAssinaturasId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtReembolsoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2B81( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A631ReembolsoAssinaturasId != Z631ReembolsoAssinaturasId )
         {
            A631ReembolsoAssinaturasId = Z631ReembolsoAssinaturasId;
            AssignAttri("", false, "A631ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(A631ReembolsoAssinaturasId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "REEMBOLSOASSINATURASID");
            AnyError = 1;
            GX_FocusControl = edtReembolsoAssinaturasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtReembolsoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency2B81( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002B2 */
            pr_default.execute(0, new Object[] {A631ReembolsoAssinaturasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoAssinaturas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z632ReembolsoAssinaturasNome, T002B2_A632ReembolsoAssinaturasNome[0]) != 0 ) || ( Z633ReembolsoAssinaturasEmissao != T002B2_A633ReembolsoAssinaturasEmissao[0] ) || ( Z518ReembolsoId != T002B2_A518ReembolsoId[0] ) || ( Z572PropostaContratoAssinaturaId != T002B2_A572PropostaContratoAssinaturaId[0] ) )
            {
               if ( StringUtil.StrCmp(Z632ReembolsoAssinaturasNome, T002B2_A632ReembolsoAssinaturasNome[0]) != 0 )
               {
                  GXUtil.WriteLog("reembolsoassinaturas:[seudo value changed for attri]"+"ReembolsoAssinaturasNome");
                  GXUtil.WriteLogRaw("Old: ",Z632ReembolsoAssinaturasNome);
                  GXUtil.WriteLogRaw("Current: ",T002B2_A632ReembolsoAssinaturasNome[0]);
               }
               if ( Z633ReembolsoAssinaturasEmissao != T002B2_A633ReembolsoAssinaturasEmissao[0] )
               {
                  GXUtil.WriteLog("reembolsoassinaturas:[seudo value changed for attri]"+"ReembolsoAssinaturasEmissao");
                  GXUtil.WriteLogRaw("Old: ",Z633ReembolsoAssinaturasEmissao);
                  GXUtil.WriteLogRaw("Current: ",T002B2_A633ReembolsoAssinaturasEmissao[0]);
               }
               if ( Z518ReembolsoId != T002B2_A518ReembolsoId[0] )
               {
                  GXUtil.WriteLog("reembolsoassinaturas:[seudo value changed for attri]"+"ReembolsoId");
                  GXUtil.WriteLogRaw("Old: ",Z518ReembolsoId);
                  GXUtil.WriteLogRaw("Current: ",T002B2_A518ReembolsoId[0]);
               }
               if ( Z572PropostaContratoAssinaturaId != T002B2_A572PropostaContratoAssinaturaId[0] )
               {
                  GXUtil.WriteLog("reembolsoassinaturas:[seudo value changed for attri]"+"PropostaContratoAssinaturaId");
                  GXUtil.WriteLogRaw("Old: ",Z572PropostaContratoAssinaturaId);
                  GXUtil.WriteLogRaw("Current: ",T002B2_A572PropostaContratoAssinaturaId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ReembolsoAssinaturas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2B81( )
      {
         BeforeValidate2B81( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2B81( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2B81( 0) ;
            CheckOptimisticConcurrency2B81( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2B81( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2B81( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002B12 */
                     pr_default.execute(10, new Object[] {n632ReembolsoAssinaturasNome, A632ReembolsoAssinaturasNome, n633ReembolsoAssinaturasEmissao, A633ReembolsoAssinaturasEmissao, n518ReembolsoId, A518ReembolsoId, n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T002B13 */
                     pr_default.execute(11);
                     A631ReembolsoAssinaturasId = T002B13_A631ReembolsoAssinaturasId[0];
                     AssignAttri("", false, "A631ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(A631ReembolsoAssinaturasId), 9, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoAssinaturas");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption2B0( ) ;
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
               Load2B81( ) ;
            }
            EndLevel2B81( ) ;
         }
         CloseExtendedTableCursors2B81( ) ;
      }

      protected void Update2B81( )
      {
         BeforeValidate2B81( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2B81( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2B81( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2B81( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2B81( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002B14 */
                     pr_default.execute(12, new Object[] {n632ReembolsoAssinaturasNome, A632ReembolsoAssinaturasNome, n633ReembolsoAssinaturasEmissao, A633ReembolsoAssinaturasEmissao, n518ReembolsoId, A518ReembolsoId, n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId, A631ReembolsoAssinaturasId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoAssinaturas");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoAssinaturas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2B81( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
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
            }
            EndLevel2B81( ) ;
         }
         CloseExtendedTableCursors2B81( ) ;
      }

      protected void DeferredUpdate2B81( )
      {
      }

      protected void delete( )
      {
         BeforeValidate2B81( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2B81( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2B81( ) ;
            AfterConfirm2B81( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2B81( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002B15 */
                  pr_default.execute(13, new Object[] {A631ReembolsoAssinaturasId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("ReembolsoAssinaturas");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
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
         }
         sMode81 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2B81( ) ;
         Gx_mode = sMode81;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2B81( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002B16 */
            pr_default.execute(14, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
            A571PropostaAssinatura = T002B16_A571PropostaAssinatura[0];
            n571PropostaAssinatura = T002B16_n571PropostaAssinatura[0];
            pr_default.close(14);
         }
      }

      protected void EndLevel2B81( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2B81( ) ;
         }
         if ( AnyError == 0 )
         {
            if ( AnyError == 0 )
            {
               ConfirmValues2B0( ) ;
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

      public void ScanStart2B81( )
      {
         /* Scan By routine */
         /* Using cursor T002B17 */
         pr_default.execute(15);
         RcdFound81 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound81 = 1;
            A631ReembolsoAssinaturasId = T002B17_A631ReembolsoAssinaturasId[0];
            AssignAttri("", false, "A631ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(A631ReembolsoAssinaturasId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2B81( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound81 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound81 = 1;
            A631ReembolsoAssinaturasId = T002B17_A631ReembolsoAssinaturasId[0];
            AssignAttri("", false, "A631ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(A631ReembolsoAssinaturasId), 9, 0));
         }
      }

      protected void ScanEnd2B81( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm2B81( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2B81( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2B81( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2B81( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2B81( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2B81( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2B81( )
      {
         edtReembolsoAssinaturasId_Enabled = 0;
         AssignProp("", false, edtReembolsoAssinaturasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoAssinaturasId_Enabled), 5, 0), true);
         edtReembolsoId_Enabled = 0;
         AssignProp("", false, edtReembolsoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoId_Enabled), 5, 0), true);
         edtPropostaContratoAssinaturaId_Enabled = 0;
         AssignProp("", false, edtPropostaContratoAssinaturaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPropostaContratoAssinaturaId_Enabled), 5, 0), true);
         edtReembolsoAssinaturasNome_Enabled = 0;
         AssignProp("", false, edtReembolsoAssinaturasNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoAssinaturasNome_Enabled), 5, 0), true);
         edtReembolsoAssinaturasEmissao_Enabled = 0;
         AssignProp("", false, edtReembolsoAssinaturasEmissao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtReembolsoAssinaturasEmissao_Enabled), 5, 0), true);
         edtavComboreembolsoid_Enabled = 0;
         AssignProp("", false, edtavComboreembolsoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboreembolsoid_Enabled), 5, 0), true);
         edtavCombopropostacontratoassinaturaid_Enabled = 0;
         AssignProp("", false, edtavCombopropostacontratoassinaturaid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombopropostacontratoassinaturaid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2B81( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2B0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal FormWithFixedActions\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "reembolsoassinaturas"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ReembolsoAssinaturasId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("reembolsoassinaturas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal FormWithFixedActions", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"ReembolsoAssinaturas");
         forbiddenHiddens.Add("ReembolsoAssinaturasId", context.localUtil.Format( (decimal)(A631ReembolsoAssinaturasId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ReembolsoId", context.localUtil.Format( (decimal)(AV11Insert_ReembolsoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_PropostaContratoAssinaturaId", context.localUtil.Format( (decimal)(AV12Insert_PropostaContratoAssinaturaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("reembolsoassinaturas:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z631ReembolsoAssinaturasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z631ReembolsoAssinaturasId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z632ReembolsoAssinaturasNome", Z632ReembolsoAssinaturasNome);
         GxWebStd.gx_hidden_field( context, "Z633ReembolsoAssinaturasEmissao", context.localUtil.TToC( Z633ReembolsoAssinaturasEmissao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z518ReembolsoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z518ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z572PropostaContratoAssinaturaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z572PropostaContratoAssinaturaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N518ReembolsoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N572PropostaContratoAssinaturaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV15DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vREEMBOLSOID_DATA", AV14ReembolsoId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vREEMBOLSOID_DATA", AV14ReembolsoId_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROPOSTACONTRATOASSINATURAID_DATA", AV20PropostaContratoAssinaturaId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROPOSTACONTRATOASSINATURAID_DATA", AV20PropostaContratoAssinaturaId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vREEMBOLSOASSINATURASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ReembolsoAssinaturasId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vREEMBOLSOASSINATURASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ReembolsoAssinaturasId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_REEMBOLSOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ReembolsoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PROPOSTACONTRATOASSINATURAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_PropostaContratoAssinaturaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PROPOSTAASSINATURA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV22Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOID_Objectcall", StringUtil.RTrim( Combo_reembolsoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOID_Cls", StringUtil.RTrim( Combo_reembolsoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOID_Selectedvalue_set", StringUtil.RTrim( Combo_reembolsoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOID_Selectedtext_set", StringUtil.RTrim( Combo_reembolsoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOID_Enabled", StringUtil.BoolToStr( Combo_reembolsoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOID_Datalistproc", StringUtil.RTrim( Combo_reembolsoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_REEMBOLSOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_reembolsoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACONTRATOASSINATURAID_Objectcall", StringUtil.RTrim( Combo_propostacontratoassinaturaid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACONTRATOASSINATURAID_Cls", StringUtil.RTrim( Combo_propostacontratoassinaturaid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACONTRATOASSINATURAID_Selectedvalue_set", StringUtil.RTrim( Combo_propostacontratoassinaturaid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACONTRATOASSINATURAID_Selectedtext_set", StringUtil.RTrim( Combo_propostacontratoassinaturaid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACONTRATOASSINATURAID_Enabled", StringUtil.BoolToStr( Combo_propostacontratoassinaturaid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACONTRATOASSINATURAID_Datalistproc", StringUtil.RTrim( Combo_propostacontratoassinaturaid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PROPOSTACONTRATOASSINATURAID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_propostacontratoassinaturaid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
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
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormWithFixedActions" : Form.Class)+"-fx");
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "reembolsoassinaturas"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ReembolsoAssinaturasId,9,0));
         return formatLink("reembolsoassinaturas") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "ReembolsoAssinaturas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Reembolso Assinaturas" ;
      }

      protected void InitializeNonKey2B81( )
      {
         A518ReembolsoId = 0;
         n518ReembolsoId = false;
         AssignAttri("", false, "A518ReembolsoId", ((0==A518ReembolsoId)&&IsIns( )||n518ReembolsoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A518ReembolsoId), 9, 0, ".", ""))));
         n518ReembolsoId = ((0==A518ReembolsoId) ? true : false);
         A572PropostaContratoAssinaturaId = 0;
         n572PropostaContratoAssinaturaId = false;
         AssignAttri("", false, "A572PropostaContratoAssinaturaId", ((0==A572PropostaContratoAssinaturaId)&&IsIns( )||n572PropostaContratoAssinaturaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A572PropostaContratoAssinaturaId), 9, 0, ".", ""))));
         n572PropostaContratoAssinaturaId = ((0==A572PropostaContratoAssinaturaId) ? true : false);
         A571PropostaAssinatura = 0;
         n571PropostaAssinatura = false;
         AssignAttri("", false, "A571PropostaAssinatura", StringUtil.LTrimStr( (decimal)(A571PropostaAssinatura), 10, 0));
         A632ReembolsoAssinaturasNome = "";
         n632ReembolsoAssinaturasNome = false;
         AssignAttri("", false, "A632ReembolsoAssinaturasNome", A632ReembolsoAssinaturasNome);
         n632ReembolsoAssinaturasNome = (String.IsNullOrEmpty(StringUtil.RTrim( A632ReembolsoAssinaturasNome)) ? true : false);
         A633ReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         n633ReembolsoAssinaturasEmissao = false;
         AssignAttri("", false, "A633ReembolsoAssinaturasEmissao", context.localUtil.TToC( A633ReembolsoAssinaturasEmissao, 8, 5, 0, 3, "/", ":", " "));
         n633ReembolsoAssinaturasEmissao = ((DateTime.MinValue==A633ReembolsoAssinaturasEmissao) ? true : false);
         Z632ReembolsoAssinaturasNome = "";
         Z633ReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         Z518ReembolsoId = 0;
         Z572PropostaContratoAssinaturaId = 0;
      }

      protected void InitAll2B81( )
      {
         A631ReembolsoAssinaturasId = 0;
         AssignAttri("", false, "A631ReembolsoAssinaturasId", StringUtil.LTrimStr( (decimal)(A631ReembolsoAssinaturasId), 9, 0));
         InitializeNonKey2B81( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019193057", true, true);
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
         context.AddJavascriptSource("reembolsoassinaturas.js", "?202561019193058", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtReembolsoAssinaturasId_Internalname = "REEMBOLSOASSINATURASID";
         lblTextblockreembolsoid_Internalname = "TEXTBLOCKREEMBOLSOID";
         Combo_reembolsoid_Internalname = "COMBO_REEMBOLSOID";
         edtReembolsoId_Internalname = "REEMBOLSOID";
         divTablesplittedreembolsoid_Internalname = "TABLESPLITTEDREEMBOLSOID";
         lblTextblockpropostacontratoassinaturaid_Internalname = "TEXTBLOCKPROPOSTACONTRATOASSINATURAID";
         Combo_propostacontratoassinaturaid_Internalname = "COMBO_PROPOSTACONTRATOASSINATURAID";
         edtPropostaContratoAssinaturaId_Internalname = "PROPOSTACONTRATOASSINATURAID";
         divTablesplittedpropostacontratoassinaturaid_Internalname = "TABLESPLITTEDPROPOSTACONTRATOASSINATURAID";
         edtReembolsoAssinaturasNome_Internalname = "REEMBOLSOASSINATURASNOME";
         edtReembolsoAssinaturasEmissao_Internalname = "REEMBOLSOASSINATURASEMISSAO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboreembolsoid_Internalname = "vCOMBOREEMBOLSOID";
         divSectionattribute_reembolsoid_Internalname = "SECTIONATTRIBUTE_REEMBOLSOID";
         edtavCombopropostacontratoassinaturaid_Internalname = "vCOMBOPROPOSTACONTRATOASSINATURAID";
         divSectionattribute_propostacontratoassinaturaid_Internalname = "SECTIONATTRIBUTE_PROPOSTACONTRATOASSINATURAID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
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
         Form.Caption = "Reembolso Assinaturas";
         edtavCombopropostacontratoassinaturaid_Jsonclick = "";
         edtavCombopropostacontratoassinaturaid_Enabled = 0;
         edtavCombopropostacontratoassinaturaid_Visible = 1;
         edtavComboreembolsoid_Jsonclick = "";
         edtavComboreembolsoid_Enabled = 0;
         edtavComboreembolsoid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtReembolsoAssinaturasEmissao_Jsonclick = "";
         edtReembolsoAssinaturasEmissao_Enabled = 1;
         edtReembolsoAssinaturasNome_Jsonclick = "";
         edtReembolsoAssinaturasNome_Enabled = 1;
         edtPropostaContratoAssinaturaId_Jsonclick = "";
         edtPropostaContratoAssinaturaId_Enabled = 1;
         edtPropostaContratoAssinaturaId_Visible = 1;
         Combo_propostacontratoassinaturaid_Datalistprocparametersprefix = " \"ComboName\": \"PropostaContratoAssinaturaId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ReembolsoAssinaturasId\": 0";
         Combo_propostacontratoassinaturaid_Datalistproc = "ReembolsoAssinaturasLoadDVCombo";
         Combo_propostacontratoassinaturaid_Cls = "ExtendedCombo AttributeFL";
         Combo_propostacontratoassinaturaid_Caption = "";
         Combo_propostacontratoassinaturaid_Enabled = Convert.ToBoolean( -1);
         edtReembolsoId_Jsonclick = "";
         edtReembolsoId_Enabled = 1;
         edtReembolsoId_Visible = 1;
         Combo_reembolsoid_Datalistprocparametersprefix = " \"ComboName\": \"ReembolsoId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ReembolsoAssinaturasId\": 0";
         Combo_reembolsoid_Datalistproc = "ReembolsoAssinaturasLoadDVCombo";
         Combo_reembolsoid_Cls = "ExtendedCombo AttributeFL";
         Combo_reembolsoid_Caption = "";
         Combo_reembolsoid_Enabled = Convert.ToBoolean( -1);
         edtReembolsoAssinaturasId_Jsonclick = "";
         edtReembolsoAssinaturasId_Enabled = 0;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações Gerais";
         Dvpanel_tableattributes_Cls = "PanelCard_GrayTitle";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
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

      public void Valid_Reembolsoid( )
      {
         /* Using cursor T002B18 */
         pr_default.execute(16, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A518ReembolsoId) ) )
            {
               GX_msglist.addItem("Não existe 'Reembolso'.", "ForeignKeyNotFound", 1, "REEMBOLSOID");
               AnyError = 1;
               GX_FocusControl = edtReembolsoId_Internalname;
            }
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Propostacontratoassinaturaid( )
      {
         n571PropostaAssinatura = false;
         /* Using cursor T002B16 */
         pr_default.execute(14, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A572PropostaContratoAssinaturaId) ) )
            {
               GX_msglist.addItem("Não existe 'PropostaContratoAssinatura'.", "ForeignKeyNotFound", 1, "PROPOSTACONTRATOASSINATURAID");
               AnyError = 1;
               GX_FocusControl = edtPropostaContratoAssinaturaId_Internalname;
            }
         }
         A571PropostaAssinatura = T002B16_A571PropostaAssinatura[0];
         n571PropostaAssinatura = T002B16_n571PropostaAssinatura[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A571PropostaAssinatura", StringUtil.LTrim( StringUtil.NToC( (decimal)(A571PropostaAssinatura), 10, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ReembolsoAssinaturasId","fld":"vREEMBOLSOASSINATURASID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ReembolsoAssinaturasId","fld":"vREEMBOLSOASSINATURASID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A631ReembolsoAssinaturasId","fld":"REEMBOLSOASSINATURASID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV11Insert_ReembolsoId","fld":"vINSERT_REEMBOLSOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV12Insert_PropostaContratoAssinaturaId","fld":"vINSERT_PROPOSTACONTRATOASSINATURAID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E122B2","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOASSINATURASID","""{"handler":"Valid_Reembolsoassinaturasid","iparms":[]}""");
         setEventMetadata("VALID_REEMBOLSOID","""{"handler":"Valid_Reembolsoid","iparms":[{"av":"A518ReembolsoId","fld":"REEMBOLSOID","pic":"ZZZZZZZZ9","nullAv":"n518ReembolsoId","type":"int"}]}""");
         setEventMetadata("VALID_PROPOSTACONTRATOASSINATURAID","""{"handler":"Valid_Propostacontratoassinaturaid","iparms":[{"av":"A572PropostaContratoAssinaturaId","fld":"PROPOSTACONTRATOASSINATURAID","pic":"ZZZZZZZZ9","nullAv":"n572PropostaContratoAssinaturaId","type":"int"},{"av":"A571PropostaAssinatura","fld":"PROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("VALID_PROPOSTACONTRATOASSINATURAID",""","oparms":[{"av":"A571PropostaAssinatura","fld":"PROPOSTAASSINATURA","pic":"ZZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VALIDV_COMBOREEMBOLSOID","""{"handler":"Validv_Comboreembolsoid","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOPROPOSTACONTRATOASSINATURAID","""{"handler":"Validv_Combopropostacontratoassinaturaid","iparms":[]}""");
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
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z632ReembolsoAssinaturasNome = "";
         Z633ReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         Combo_propostacontratoassinaturaid_Selectedvalue_get = "";
         Combo_reembolsoid_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblockreembolsoid_Jsonclick = "";
         ucCombo_reembolsoid = new GXUserControl();
         AV15DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV14ReembolsoId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         lblTextblockpropostacontratoassinaturaid_Jsonclick = "";
         ucCombo_propostacontratoassinaturaid = new GXUserControl();
         AV20PropostaContratoAssinaturaId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A632ReembolsoAssinaturasNome = "";
         A633ReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV22Pgmname = "";
         Combo_reembolsoid_Objectcall = "";
         Combo_reembolsoid_Class = "";
         Combo_reembolsoid_Icontype = "";
         Combo_reembolsoid_Icon = "";
         Combo_reembolsoid_Tooltip = "";
         Combo_reembolsoid_Selectedvalue_set = "";
         Combo_reembolsoid_Selectedtext_set = "";
         Combo_reembolsoid_Selectedtext_get = "";
         Combo_reembolsoid_Gamoauthtoken = "";
         Combo_reembolsoid_Ddointernalname = "";
         Combo_reembolsoid_Titlecontrolalign = "";
         Combo_reembolsoid_Dropdownoptionstype = "";
         Combo_reembolsoid_Titlecontrolidtoreplace = "";
         Combo_reembolsoid_Datalisttype = "";
         Combo_reembolsoid_Datalistfixedvalues = "";
         Combo_reembolsoid_Remoteservicesparameters = "";
         Combo_reembolsoid_Htmltemplate = "";
         Combo_reembolsoid_Multiplevaluestype = "";
         Combo_reembolsoid_Loadingdata = "";
         Combo_reembolsoid_Noresultsfound = "";
         Combo_reembolsoid_Emptyitemtext = "";
         Combo_reembolsoid_Onlyselectedvalues = "";
         Combo_reembolsoid_Selectalltext = "";
         Combo_reembolsoid_Multiplevaluesseparator = "";
         Combo_reembolsoid_Addnewoptiontext = "";
         Combo_propostacontratoassinaturaid_Objectcall = "";
         Combo_propostacontratoassinaturaid_Class = "";
         Combo_propostacontratoassinaturaid_Icontype = "";
         Combo_propostacontratoassinaturaid_Icon = "";
         Combo_propostacontratoassinaturaid_Tooltip = "";
         Combo_propostacontratoassinaturaid_Selectedvalue_set = "";
         Combo_propostacontratoassinaturaid_Selectedtext_set = "";
         Combo_propostacontratoassinaturaid_Selectedtext_get = "";
         Combo_propostacontratoassinaturaid_Gamoauthtoken = "";
         Combo_propostacontratoassinaturaid_Ddointernalname = "";
         Combo_propostacontratoassinaturaid_Titlecontrolalign = "";
         Combo_propostacontratoassinaturaid_Dropdownoptionstype = "";
         Combo_propostacontratoassinaturaid_Titlecontrolidtoreplace = "";
         Combo_propostacontratoassinaturaid_Datalisttype = "";
         Combo_propostacontratoassinaturaid_Datalistfixedvalues = "";
         Combo_propostacontratoassinaturaid_Remoteservicesparameters = "";
         Combo_propostacontratoassinaturaid_Htmltemplate = "";
         Combo_propostacontratoassinaturaid_Multiplevaluestype = "";
         Combo_propostacontratoassinaturaid_Loadingdata = "";
         Combo_propostacontratoassinaturaid_Noresultsfound = "";
         Combo_propostacontratoassinaturaid_Emptyitemtext = "";
         Combo_propostacontratoassinaturaid_Onlyselectedvalues = "";
         Combo_propostacontratoassinaturaid_Selectalltext = "";
         Combo_propostacontratoassinaturaid_Multiplevaluesseparator = "";
         Combo_propostacontratoassinaturaid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode81 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV18Combo_DataJson = "";
         AV16ComboSelectedValue = "";
         AV17ComboSelectedText = "";
         GXt_char2 = "";
         T002B5_A571PropostaAssinatura = new long[1] ;
         T002B5_n571PropostaAssinatura = new bool[] {false} ;
         T002B6_A631ReembolsoAssinaturasId = new int[1] ;
         T002B6_A632ReembolsoAssinaturasNome = new string[] {""} ;
         T002B6_n632ReembolsoAssinaturasNome = new bool[] {false} ;
         T002B6_A633ReembolsoAssinaturasEmissao = new DateTime[] {DateTime.MinValue} ;
         T002B6_n633ReembolsoAssinaturasEmissao = new bool[] {false} ;
         T002B6_A518ReembolsoId = new int[1] ;
         T002B6_n518ReembolsoId = new bool[] {false} ;
         T002B6_A572PropostaContratoAssinaturaId = new int[1] ;
         T002B6_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         T002B6_A571PropostaAssinatura = new long[1] ;
         T002B6_n571PropostaAssinatura = new bool[] {false} ;
         T002B4_A518ReembolsoId = new int[1] ;
         T002B4_n518ReembolsoId = new bool[] {false} ;
         T002B7_A518ReembolsoId = new int[1] ;
         T002B7_n518ReembolsoId = new bool[] {false} ;
         T002B8_A571PropostaAssinatura = new long[1] ;
         T002B8_n571PropostaAssinatura = new bool[] {false} ;
         T002B9_A631ReembolsoAssinaturasId = new int[1] ;
         T002B3_A631ReembolsoAssinaturasId = new int[1] ;
         T002B3_A632ReembolsoAssinaturasNome = new string[] {""} ;
         T002B3_n632ReembolsoAssinaturasNome = new bool[] {false} ;
         T002B3_A633ReembolsoAssinaturasEmissao = new DateTime[] {DateTime.MinValue} ;
         T002B3_n633ReembolsoAssinaturasEmissao = new bool[] {false} ;
         T002B3_A518ReembolsoId = new int[1] ;
         T002B3_n518ReembolsoId = new bool[] {false} ;
         T002B3_A572PropostaContratoAssinaturaId = new int[1] ;
         T002B3_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         T002B10_A631ReembolsoAssinaturasId = new int[1] ;
         T002B11_A631ReembolsoAssinaturasId = new int[1] ;
         T002B2_A631ReembolsoAssinaturasId = new int[1] ;
         T002B2_A632ReembolsoAssinaturasNome = new string[] {""} ;
         T002B2_n632ReembolsoAssinaturasNome = new bool[] {false} ;
         T002B2_A633ReembolsoAssinaturasEmissao = new DateTime[] {DateTime.MinValue} ;
         T002B2_n633ReembolsoAssinaturasEmissao = new bool[] {false} ;
         T002B2_A518ReembolsoId = new int[1] ;
         T002B2_n518ReembolsoId = new bool[] {false} ;
         T002B2_A572PropostaContratoAssinaturaId = new int[1] ;
         T002B2_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         T002B13_A631ReembolsoAssinaturasId = new int[1] ;
         T002B16_A571PropostaAssinatura = new long[1] ;
         T002B16_n571PropostaAssinatura = new bool[] {false} ;
         T002B17_A631ReembolsoAssinaturasId = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T002B18_A518ReembolsoId = new int[1] ;
         T002B18_n518ReembolsoId = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoassinaturas__default(),
            new Object[][] {
                new Object[] {
               T002B2_A631ReembolsoAssinaturasId, T002B2_A632ReembolsoAssinaturasNome, T002B2_n632ReembolsoAssinaturasNome, T002B2_A633ReembolsoAssinaturasEmissao, T002B2_n633ReembolsoAssinaturasEmissao, T002B2_A518ReembolsoId, T002B2_n518ReembolsoId, T002B2_A572PropostaContratoAssinaturaId, T002B2_n572PropostaContratoAssinaturaId
               }
               , new Object[] {
               T002B3_A631ReembolsoAssinaturasId, T002B3_A632ReembolsoAssinaturasNome, T002B3_n632ReembolsoAssinaturasNome, T002B3_A633ReembolsoAssinaturasEmissao, T002B3_n633ReembolsoAssinaturasEmissao, T002B3_A518ReembolsoId, T002B3_n518ReembolsoId, T002B3_A572PropostaContratoAssinaturaId, T002B3_n572PropostaContratoAssinaturaId
               }
               , new Object[] {
               T002B4_A518ReembolsoId
               }
               , new Object[] {
               T002B5_A571PropostaAssinatura, T002B5_n571PropostaAssinatura
               }
               , new Object[] {
               T002B6_A631ReembolsoAssinaturasId, T002B6_A632ReembolsoAssinaturasNome, T002B6_n632ReembolsoAssinaturasNome, T002B6_A633ReembolsoAssinaturasEmissao, T002B6_n633ReembolsoAssinaturasEmissao, T002B6_A518ReembolsoId, T002B6_n518ReembolsoId, T002B6_A572PropostaContratoAssinaturaId, T002B6_n572PropostaContratoAssinaturaId, T002B6_A571PropostaAssinatura,
               T002B6_n571PropostaAssinatura
               }
               , new Object[] {
               T002B7_A518ReembolsoId
               }
               , new Object[] {
               T002B8_A571PropostaAssinatura, T002B8_n571PropostaAssinatura
               }
               , new Object[] {
               T002B9_A631ReembolsoAssinaturasId
               }
               , new Object[] {
               T002B10_A631ReembolsoAssinaturasId
               }
               , new Object[] {
               T002B11_A631ReembolsoAssinaturasId
               }
               , new Object[] {
               }
               , new Object[] {
               T002B13_A631ReembolsoAssinaturasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002B16_A571PropostaAssinatura, T002B16_n571PropostaAssinatura
               }
               , new Object[] {
               T002B17_A631ReembolsoAssinaturasId
               }
               , new Object[] {
               T002B18_A518ReembolsoId
               }
            }
         );
         AV22Pgmname = "ReembolsoAssinaturas";
      }

      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short RcdFound81 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7ReembolsoAssinaturasId ;
      private int Z631ReembolsoAssinaturasId ;
      private int Z518ReembolsoId ;
      private int Z572PropostaContratoAssinaturaId ;
      private int N518ReembolsoId ;
      private int N572PropostaContratoAssinaturaId ;
      private int A518ReembolsoId ;
      private int A572PropostaContratoAssinaturaId ;
      private int AV7ReembolsoAssinaturasId ;
      private int trnEnded ;
      private int A631ReembolsoAssinaturasId ;
      private int edtReembolsoAssinaturasId_Enabled ;
      private int edtReembolsoId_Visible ;
      private int edtReembolsoId_Enabled ;
      private int edtPropostaContratoAssinaturaId_Visible ;
      private int edtPropostaContratoAssinaturaId_Enabled ;
      private int edtReembolsoAssinaturasNome_Enabled ;
      private int edtReembolsoAssinaturasEmissao_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int AV19ComboReembolsoId ;
      private int edtavComboreembolsoid_Enabled ;
      private int edtavComboreembolsoid_Visible ;
      private int AV21ComboPropostaContratoAssinaturaId ;
      private int edtavCombopropostacontratoassinaturaid_Enabled ;
      private int edtavCombopropostacontratoassinaturaid_Visible ;
      private int AV11Insert_ReembolsoId ;
      private int AV12Insert_PropostaContratoAssinaturaId ;
      private int Combo_reembolsoid_Datalistupdateminimumcharacters ;
      private int Combo_reembolsoid_Gxcontroltype ;
      private int Combo_propostacontratoassinaturaid_Datalistupdateminimumcharacters ;
      private int Combo_propostacontratoassinaturaid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV23GXV1 ;
      private int idxLst ;
      private long A571PropostaAssinatura ;
      private long Z571PropostaAssinatura ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_propostacontratoassinaturaid_Selectedvalue_get ;
      private string Combo_reembolsoid_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtReembolsoId_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtReembolsoAssinaturasId_Internalname ;
      private string TempTags ;
      private string edtReembolsoAssinaturasId_Jsonclick ;
      private string divTablesplittedreembolsoid_Internalname ;
      private string lblTextblockreembolsoid_Internalname ;
      private string lblTextblockreembolsoid_Jsonclick ;
      private string Combo_reembolsoid_Caption ;
      private string Combo_reembolsoid_Cls ;
      private string Combo_reembolsoid_Datalistproc ;
      private string Combo_reembolsoid_Datalistprocparametersprefix ;
      private string Combo_reembolsoid_Internalname ;
      private string edtReembolsoId_Jsonclick ;
      private string divTablesplittedpropostacontratoassinaturaid_Internalname ;
      private string lblTextblockpropostacontratoassinaturaid_Internalname ;
      private string lblTextblockpropostacontratoassinaturaid_Jsonclick ;
      private string Combo_propostacontratoassinaturaid_Caption ;
      private string Combo_propostacontratoassinaturaid_Cls ;
      private string Combo_propostacontratoassinaturaid_Datalistproc ;
      private string Combo_propostacontratoassinaturaid_Datalistprocparametersprefix ;
      private string Combo_propostacontratoassinaturaid_Internalname ;
      private string edtPropostaContratoAssinaturaId_Internalname ;
      private string edtPropostaContratoAssinaturaId_Jsonclick ;
      private string edtReembolsoAssinaturasNome_Internalname ;
      private string edtReembolsoAssinaturasNome_Jsonclick ;
      private string edtReembolsoAssinaturasEmissao_Internalname ;
      private string edtReembolsoAssinaturasEmissao_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_reembolsoid_Internalname ;
      private string edtavComboreembolsoid_Internalname ;
      private string edtavComboreembolsoid_Jsonclick ;
      private string divSectionattribute_propostacontratoassinaturaid_Internalname ;
      private string edtavCombopropostacontratoassinaturaid_Internalname ;
      private string edtavCombopropostacontratoassinaturaid_Jsonclick ;
      private string AV22Pgmname ;
      private string Combo_reembolsoid_Objectcall ;
      private string Combo_reembolsoid_Class ;
      private string Combo_reembolsoid_Icontype ;
      private string Combo_reembolsoid_Icon ;
      private string Combo_reembolsoid_Tooltip ;
      private string Combo_reembolsoid_Selectedvalue_set ;
      private string Combo_reembolsoid_Selectedtext_set ;
      private string Combo_reembolsoid_Selectedtext_get ;
      private string Combo_reembolsoid_Gamoauthtoken ;
      private string Combo_reembolsoid_Ddointernalname ;
      private string Combo_reembolsoid_Titlecontrolalign ;
      private string Combo_reembolsoid_Dropdownoptionstype ;
      private string Combo_reembolsoid_Titlecontrolidtoreplace ;
      private string Combo_reembolsoid_Datalisttype ;
      private string Combo_reembolsoid_Datalistfixedvalues ;
      private string Combo_reembolsoid_Remoteservicesparameters ;
      private string Combo_reembolsoid_Htmltemplate ;
      private string Combo_reembolsoid_Multiplevaluestype ;
      private string Combo_reembolsoid_Loadingdata ;
      private string Combo_reembolsoid_Noresultsfound ;
      private string Combo_reembolsoid_Emptyitemtext ;
      private string Combo_reembolsoid_Onlyselectedvalues ;
      private string Combo_reembolsoid_Selectalltext ;
      private string Combo_reembolsoid_Multiplevaluesseparator ;
      private string Combo_reembolsoid_Addnewoptiontext ;
      private string Combo_propostacontratoassinaturaid_Objectcall ;
      private string Combo_propostacontratoassinaturaid_Class ;
      private string Combo_propostacontratoassinaturaid_Icontype ;
      private string Combo_propostacontratoassinaturaid_Icon ;
      private string Combo_propostacontratoassinaturaid_Tooltip ;
      private string Combo_propostacontratoassinaturaid_Selectedvalue_set ;
      private string Combo_propostacontratoassinaturaid_Selectedtext_set ;
      private string Combo_propostacontratoassinaturaid_Selectedtext_get ;
      private string Combo_propostacontratoassinaturaid_Gamoauthtoken ;
      private string Combo_propostacontratoassinaturaid_Ddointernalname ;
      private string Combo_propostacontratoassinaturaid_Titlecontrolalign ;
      private string Combo_propostacontratoassinaturaid_Dropdownoptionstype ;
      private string Combo_propostacontratoassinaturaid_Titlecontrolidtoreplace ;
      private string Combo_propostacontratoassinaturaid_Datalisttype ;
      private string Combo_propostacontratoassinaturaid_Datalistfixedvalues ;
      private string Combo_propostacontratoassinaturaid_Remoteservicesparameters ;
      private string Combo_propostacontratoassinaturaid_Htmltemplate ;
      private string Combo_propostacontratoassinaturaid_Multiplevaluestype ;
      private string Combo_propostacontratoassinaturaid_Loadingdata ;
      private string Combo_propostacontratoassinaturaid_Noresultsfound ;
      private string Combo_propostacontratoassinaturaid_Emptyitemtext ;
      private string Combo_propostacontratoassinaturaid_Onlyselectedvalues ;
      private string Combo_propostacontratoassinaturaid_Selectalltext ;
      private string Combo_propostacontratoassinaturaid_Multiplevaluesseparator ;
      private string Combo_propostacontratoassinaturaid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode81 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z633ReembolsoAssinaturasEmissao ;
      private DateTime A633ReembolsoAssinaturasEmissao ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n518ReembolsoId ;
      private bool n572PropostaContratoAssinaturaId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n632ReembolsoAssinaturasNome ;
      private bool n633ReembolsoAssinaturasEmissao ;
      private bool n571PropostaAssinatura ;
      private bool Combo_reembolsoid_Enabled ;
      private bool Combo_reembolsoid_Visible ;
      private bool Combo_reembolsoid_Allowmultipleselection ;
      private bool Combo_reembolsoid_Isgriditem ;
      private bool Combo_reembolsoid_Hasdescription ;
      private bool Combo_reembolsoid_Includeonlyselectedoption ;
      private bool Combo_reembolsoid_Includeselectalloption ;
      private bool Combo_reembolsoid_Emptyitem ;
      private bool Combo_reembolsoid_Includeaddnewoption ;
      private bool Combo_propostacontratoassinaturaid_Enabled ;
      private bool Combo_propostacontratoassinaturaid_Visible ;
      private bool Combo_propostacontratoassinaturaid_Allowmultipleselection ;
      private bool Combo_propostacontratoassinaturaid_Isgriditem ;
      private bool Combo_propostacontratoassinaturaid_Hasdescription ;
      private bool Combo_propostacontratoassinaturaid_Includeonlyselectedoption ;
      private bool Combo_propostacontratoassinaturaid_Includeselectalloption ;
      private bool Combo_propostacontratoassinaturaid_Emptyitem ;
      private bool Combo_propostacontratoassinaturaid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string AV18Combo_DataJson ;
      private string Z632ReembolsoAssinaturasNome ;
      private string A632ReembolsoAssinaturasNome ;
      private string AV16ComboSelectedValue ;
      private string AV17ComboSelectedText ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_reembolsoid ;
      private GXUserControl ucCombo_propostacontratoassinaturaid ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV15DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV14ReembolsoId_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV20PropostaContratoAssinaturaId_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private long[] T002B5_A571PropostaAssinatura ;
      private bool[] T002B5_n571PropostaAssinatura ;
      private int[] T002B6_A631ReembolsoAssinaturasId ;
      private string[] T002B6_A632ReembolsoAssinaturasNome ;
      private bool[] T002B6_n632ReembolsoAssinaturasNome ;
      private DateTime[] T002B6_A633ReembolsoAssinaturasEmissao ;
      private bool[] T002B6_n633ReembolsoAssinaturasEmissao ;
      private int[] T002B6_A518ReembolsoId ;
      private bool[] T002B6_n518ReembolsoId ;
      private int[] T002B6_A572PropostaContratoAssinaturaId ;
      private bool[] T002B6_n572PropostaContratoAssinaturaId ;
      private long[] T002B6_A571PropostaAssinatura ;
      private bool[] T002B6_n571PropostaAssinatura ;
      private int[] T002B4_A518ReembolsoId ;
      private bool[] T002B4_n518ReembolsoId ;
      private int[] T002B7_A518ReembolsoId ;
      private bool[] T002B7_n518ReembolsoId ;
      private long[] T002B8_A571PropostaAssinatura ;
      private bool[] T002B8_n571PropostaAssinatura ;
      private int[] T002B9_A631ReembolsoAssinaturasId ;
      private int[] T002B3_A631ReembolsoAssinaturasId ;
      private string[] T002B3_A632ReembolsoAssinaturasNome ;
      private bool[] T002B3_n632ReembolsoAssinaturasNome ;
      private DateTime[] T002B3_A633ReembolsoAssinaturasEmissao ;
      private bool[] T002B3_n633ReembolsoAssinaturasEmissao ;
      private int[] T002B3_A518ReembolsoId ;
      private bool[] T002B3_n518ReembolsoId ;
      private int[] T002B3_A572PropostaContratoAssinaturaId ;
      private bool[] T002B3_n572PropostaContratoAssinaturaId ;
      private int[] T002B10_A631ReembolsoAssinaturasId ;
      private int[] T002B11_A631ReembolsoAssinaturasId ;
      private int[] T002B2_A631ReembolsoAssinaturasId ;
      private string[] T002B2_A632ReembolsoAssinaturasNome ;
      private bool[] T002B2_n632ReembolsoAssinaturasNome ;
      private DateTime[] T002B2_A633ReembolsoAssinaturasEmissao ;
      private bool[] T002B2_n633ReembolsoAssinaturasEmissao ;
      private int[] T002B2_A518ReembolsoId ;
      private bool[] T002B2_n518ReembolsoId ;
      private int[] T002B2_A572PropostaContratoAssinaturaId ;
      private bool[] T002B2_n572PropostaContratoAssinaturaId ;
      private int[] T002B13_A631ReembolsoAssinaturasId ;
      private long[] T002B16_A571PropostaAssinatura ;
      private bool[] T002B16_n571PropostaAssinatura ;
      private int[] T002B17_A631ReembolsoAssinaturasId ;
      private int[] T002B18_A518ReembolsoId ;
      private bool[] T002B18_n518ReembolsoId ;
   }

   public class reembolsoassinaturas__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT002B2;
          prmT002B2 = new Object[] {
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmT002B3;
          prmT002B3 = new Object[] {
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmT002B4;
          prmT002B4 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002B5;
          prmT002B5 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002B6;
          prmT002B6 = new Object[] {
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmT002B7;
          prmT002B7 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002B8;
          prmT002B8 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002B9;
          prmT002B9 = new Object[] {
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmT002B10;
          prmT002B10 = new Object[] {
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmT002B11;
          prmT002B11 = new Object[] {
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmT002B12;
          prmT002B12 = new Object[] {
          new ParDef("ReembolsoAssinaturasNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ReembolsoAssinaturasEmissao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002B13;
          prmT002B13 = new Object[] {
          };
          Object[] prmT002B14;
          prmT002B14 = new Object[] {
          new ParDef("ReembolsoAssinaturasNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ReembolsoAssinaturasEmissao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmT002B15;
          prmT002B15 = new Object[] {
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmT002B16;
          prmT002B16 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT002B17;
          prmT002B17 = new Object[] {
          };
          Object[] prmT002B18;
          prmT002B18 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T002B2", "SELECT ReembolsoAssinaturasId, ReembolsoAssinaturasNome, ReembolsoAssinaturasEmissao, ReembolsoId, PropostaContratoAssinaturaId FROM ReembolsoAssinaturas WHERE ReembolsoAssinaturasId = :ReembolsoAssinaturasId  FOR UPDATE OF ReembolsoAssinaturas NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT002B2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002B3", "SELECT ReembolsoAssinaturasId, ReembolsoAssinaturasNome, ReembolsoAssinaturasEmissao, ReembolsoId, PropostaContratoAssinaturaId FROM ReembolsoAssinaturas WHERE ReembolsoAssinaturasId = :ReembolsoAssinaturasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002B4", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002B5", "SELECT PropostaAssinatura FROM PropostaContratoAssinatura WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002B6", "SELECT TM1.ReembolsoAssinaturasId, TM1.ReembolsoAssinaturasNome, TM1.ReembolsoAssinaturasEmissao, TM1.ReembolsoId, TM1.PropostaContratoAssinaturaId, T2.PropostaAssinatura FROM (ReembolsoAssinaturas TM1 LEFT JOIN PropostaContratoAssinatura T2 ON T2.PropostaContratoAssinaturaId = TM1.PropostaContratoAssinaturaId) WHERE TM1.ReembolsoAssinaturasId = :ReembolsoAssinaturasId ORDER BY TM1.ReembolsoAssinaturasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002B7", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002B8", "SELECT PropostaAssinatura FROM PropostaContratoAssinatura WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002B9", "SELECT ReembolsoAssinaturasId FROM ReembolsoAssinaturas WHERE ReembolsoAssinaturasId = :ReembolsoAssinaturasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002B10", "SELECT ReembolsoAssinaturasId FROM ReembolsoAssinaturas WHERE ( ReembolsoAssinaturasId > :ReembolsoAssinaturasId) ORDER BY ReembolsoAssinaturasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002B11", "SELECT ReembolsoAssinaturasId FROM ReembolsoAssinaturas WHERE ( ReembolsoAssinaturasId < :ReembolsoAssinaturasId) ORDER BY ReembolsoAssinaturasId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T002B12", "SAVEPOINT gxupdate;INSERT INTO ReembolsoAssinaturas(ReembolsoAssinaturasNome, ReembolsoAssinaturasEmissao, ReembolsoId, PropostaContratoAssinaturaId) VALUES(:ReembolsoAssinaturasNome, :ReembolsoAssinaturasEmissao, :ReembolsoId, :PropostaContratoAssinaturaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002B12)
             ,new CursorDef("T002B13", "SELECT currval('ReembolsoAssinaturasId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002B14", "SAVEPOINT gxupdate;UPDATE ReembolsoAssinaturas SET ReembolsoAssinaturasNome=:ReembolsoAssinaturasNome, ReembolsoAssinaturasEmissao=:ReembolsoAssinaturasEmissao, ReembolsoId=:ReembolsoId, PropostaContratoAssinaturaId=:PropostaContratoAssinaturaId  WHERE ReembolsoAssinaturasId = :ReembolsoAssinaturasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002B14)
             ,new CursorDef("T002B15", "SAVEPOINT gxupdate;DELETE FROM ReembolsoAssinaturas  WHERE ReembolsoAssinaturasId = :ReembolsoAssinaturasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT002B15)
             ,new CursorDef("T002B16", "SELECT PropostaAssinatura FROM PropostaContratoAssinatura WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002B17", "SELECT ReembolsoAssinaturasId FROM ReembolsoAssinaturas ORDER BY ReembolsoAssinaturasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B17,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T002B18", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B18,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
