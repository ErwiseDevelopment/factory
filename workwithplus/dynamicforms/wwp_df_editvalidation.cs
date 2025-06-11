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
namespace GeneXus.Programs.workwithplus.dynamicforms {
   public class wwp_df_editvalidation : GXWebComponent
   {
      public wwp_df_editvalidation( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
      }

      public wwp_df_editvalidation( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_WWPDynamicFormMode ,
                           short aP1_WWPFormElementParentId ,
                           short aP2_WWPFormElementId ,
                           string aP3_WWPFormElementReferenceId ,
                           short aP4_WWPFormElementDataType ,
                           short aP5_SessionId ,
                           string aP6_ValidationJson ,
                           bool aP7_IncludeCurrentElement )
      {
         this.AV16WWPDynamicFormMode = aP0_WWPDynamicFormMode;
         this.AV21WWPFormElementParentId = aP1_WWPFormElementParentId;
         this.AV19WWPFormElementId = aP2_WWPFormElementId;
         this.AV20WWPFormElementReferenceId = aP3_WWPFormElementReferenceId;
         this.AV18WWPFormElementDataType = aP4_WWPFormElementDataType;
         this.AV9SessionId = aP5_SessionId;
         this.AV12ValidationJson = aP6_ValidationJson;
         this.AV22IncludeCurrentElement = aP7_IncludeCurrentElement;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV16WWPDynamicFormMode = GetPar( "WWPDynamicFormMode");
                  AssignAttri(sPrefix, false, "AV16WWPDynamicFormMode", AV16WWPDynamicFormMode);
                  AV21WWPFormElementParentId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementParentId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV21WWPFormElementParentId", StringUtil.LTrimStr( (decimal)(AV21WWPFormElementParentId), 4, 0));
                  AV19WWPFormElementId = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV19WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV19WWPFormElementId), 4, 0));
                  AV20WWPFormElementReferenceId = GetPar( "WWPFormElementReferenceId");
                  AssignAttri(sPrefix, false, "AV20WWPFormElementReferenceId", AV20WWPFormElementReferenceId);
                  AV18WWPFormElementDataType = (short)(Math.Round(NumberUtil.Val( GetPar( "WWPFormElementDataType"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV18WWPFormElementDataType", StringUtil.LTrimStr( (decimal)(AV18WWPFormElementDataType), 2, 0));
                  AV9SessionId = (short)(Math.Round(NumberUtil.Val( GetPar( "SessionId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV9SessionId", StringUtil.LTrimStr( (decimal)(AV9SessionId), 4, 0));
                  AV12ValidationJson = GetPar( "ValidationJson");
                  AssignAttri(sPrefix, false, "AV12ValidationJson", AV12ValidationJson);
                  AV22IncludeCurrentElement = StringUtil.StrToBool( GetPar( "IncludeCurrentElement"));
                  AssignAttri(sPrefix, false, "AV22IncludeCurrentElement", AV22IncludeCurrentElement);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV16WWPDynamicFormMode,(short)AV21WWPFormElementParentId,(short)AV19WWPFormElementId,(string)AV20WWPFormElementReferenceId,(short)AV18WWPFormElementDataType,(short)AV9SessionId,(string)AV12ValidationJson,(bool)AV22IncludeCurrentElement});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
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
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA282( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS282( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Validation") ;
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
         }
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
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Suggest/SuggestRender.js", "", false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
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
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal FormNoBackgroundColor\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "workwithplus.dynamicforms.wwp_df_editvalidation"+UrlEncode(StringUtil.RTrim(AV16WWPDynamicFormMode)) + "," + UrlEncode(StringUtil.LTrimStr(AV21WWPFormElementParentId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV19WWPFormElementId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV20WWPFormElementReferenceId)) + "," + UrlEncode(StringUtil.LTrimStr(AV18WWPFormElementDataType,2,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV9SessionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV12ValidationJson)) + "," + UrlEncode(StringUtil.BoolToStr(AV22IncludeCurrentElement));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormNoBackgroundColor\" data-gx-class=\"form-horizontal FormNoBackgroundColor\" novalidate action=\""+formatLink("workwithplus.dynamicforms.wwp_df_editvalidation") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal FormNoBackgroundColor", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal FormNoBackgroundColor" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV16WWPDynamicFormMode", StringUtil.RTrim( wcpOAV16WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV21WWPFormElementParentId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV21WWPFormElementParentId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV19WWPFormElementId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV19WWPFormElementId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV20WWPFormElementReferenceId", wcpOAV20WWPFormElementReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV18WWPFormElementDataType", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV18WWPFormElementDataType), 2, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9SessionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV9SessionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV12ValidationJson", wcpOAV12ValidationJson);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"wcpOAV22IncludeCurrentElement", wcpOAV22IncludeCurrentElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"vSESSIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9SessionId), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vINCLUDECURRENTELEMENT", AV22IncludeCurrentElement);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19WWPFormElementId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCONDITIONERROR", AV7ConditionError);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vWWPFORM", AV17WWPForm);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vWWPFORM", AV17WWPForm);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vEXECUTECONDITIONTOTEST", AV8ExecuteConditionToTest);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTREFERENCEID", AV20WWPFormElementReferenceId);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTDATATYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18WWPFormElementDataType), 2, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vALLREFERENCEIDS", AV5AllReferenceIds);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vALLREFERENCEIDS", AV5AllReferenceIds);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vVALIDATION", AV10Validation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vVALIDATION", AV10Validation);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vCHECKREQUIREDFIELDSRESULT", AV6CheckRequiredFieldsResult);
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPDYNAMICFORMMODE", StringUtil.RTrim( AV16WWPDynamicFormMode));
         GxWebStd.gx_hidden_field( context, sPrefix+"vWWPFORMELEMENTPARENTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21WWPFormElementParentId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vVALIDATIONJSON", AV12ValidationJson);
      }

      protected void RenderHtmlCloseForm282( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "WorkWithPlus.DynamicForms.WWP_DF_EditValidation" ;
      }

      public override string GetPgmdesc( )
      {
         return "Validation" ;
      }

      protected void WB280( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "workwithplus.dynamicforms.wwp_df_editvalidation");
               context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Suggest/SuggestRender.js", "", false, true);
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransactionPopUp", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavValidationmessage_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValidationmessage_Internalname, "Mensagem de validação", "col-sm-3 AttributeFLLabel SmallTextAreaLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL SmallTextArea";
            StyleString = "";
            ClassString = "AttributeFL SmallTextArea";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavValidationmessage_Internalname, AV13ValidationMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,14);\"", 0, 1, edtavValidationmessage_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_EditValidation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divValidationconditioncell_Internalname, 1, 0, "px", 0, "px", divValidationconditioncell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablesplittedvalidationcondition_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockvalidationcondition_Internalname, "Condição de validação", "", "", lblTextblockvalidationcondition_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WorkWithPlus/DynamicForms/WWP_DF_EditValidation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
            wb_table1_22_282( true) ;
         }
         else
         {
            wb_table1_22_282( false) ;
         }
         return  ;
      }

      protected void wb_table1_22_282e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "end", "top", "", "", "div");
            /* User Defined Control */
            ucBtntestcondition.SetProperty("TooltipText", Btntestcondition_Tooltiptext);
            ucBtntestcondition.SetProperty("BeforeIconClass", Btntestcondition_Beforeiconclass);
            ucBtntestcondition.SetProperty("Caption", Btntestcondition_Caption);
            ucBtntestcondition.SetProperty("Class", Btntestcondition_Class);
            ucBtntestcondition.Render(context, "wwp_iconbutton", Btntestcondition_Internalname, sPrefix+"BTNTESTCONDITIONContainer");
            GxWebStd.gx_div_end( context, "end", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUcmentions.SetProperty("DataListProc", Ucmentions_Datalistproc);
            ucUcmentions.Render(context, "wwp.suggest", Ucmentions_Internalname, sPrefix+"UCMENTIONSContainer");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WorkWithPlus/DynamicForms/WWP_DF_EditValidation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnuacancel_Internalname, "", "Fechar", bttBtnuacancel_Jsonclick, 7, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e11281_client"+"'", TempTags, "", 2, "HLP_WorkWithPlus/DynamicForms/WWP_DF_EditValidation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START282( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_12-186073", 0) ;
               }
            }
            Form.Meta.addItem("description", "Validation", 0) ;
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP280( ) ;
            }
         }
      }

      protected void WS282( )
      {
         START282( ) ;
         EVT282( ) ;
      }

      protected void EVT282( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E12282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOTESTCONDITION'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoTestCondition' */
                                    E13282 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E14282 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E15282 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP280( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = edtavValidationmessage_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE282( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm282( ) ;
            }
         }
      }

      protected void PA282( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( StringUtil.Len( sPrefix) == 0 )
            {
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "workwithplus.dynamicforms.wwp_df_editvalidation")), "workwithplus.dynamicforms.wwp_df_editvalidation") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "workwithplus.dynamicforms.wwp_df_editvalidation")))) ;
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
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "WWPDynamicFormMode");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
                     }
                     if ( toggleJsOutput )
                     {
                        if ( context.isSpaRequest( ) )
                        {
                           enableJsOutput();
                        }
                     }
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavValidationmessage_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF282( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF282( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15282 ();
            WB280( ) ;
         }
      }

      protected void send_integrity_lvl_hashes282( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP280( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12282 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV16WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV16WWPDynamicFormMode");
            wcpOAV21WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV21WWPFormElementParentId"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV19WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV19WWPFormElementId"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV20WWPFormElementReferenceId = cgiGet( sPrefix+"wcpOAV20WWPFormElementReferenceId");
            wcpOAV18WWPFormElementDataType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV18WWPFormElementDataType"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV9SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9SessionId"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV12ValidationJson = cgiGet( sPrefix+"wcpOAV12ValidationJson");
            wcpOAV22IncludeCurrentElement = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV22IncludeCurrentElement"));
            /* Read variables values. */
            AV13ValidationMessage = cgiGet( edtavValidationmessage_Internalname);
            AssignAttri(sPrefix, false, "AV13ValidationMessage", AV13ValidationMessage);
            AV11ValidationCondition = cgiGet( edtavValidationcondition_Internalname);
            AssignAttri(sPrefix, false, "AV11ValidationCondition", AV11ValidationCondition);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E12282 ();
         if (returnInSub) return;
      }

      protected void E12282( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod(sPrefix, false, "UCMENTIONSContainer", "Attach", "", new Object[] {(string)"&",(string)edtavValidationcondition_Internalname});
         Ucmentions_Datalistprocextrapartameters = StringUtil.Format( "\"SessionId\": \"%1\",\"IncludeCurrentElement\": \"%2\",\"CurrentElementId\": \"%3\",\"MaxOptions\": \"5\"", StringUtil.Trim( StringUtil.Str( (decimal)(AV9SessionId), 4, 0)), StringUtil.Trim( StringUtil.BoolToStr( AV22IncludeCurrentElement)), StringUtil.Trim( StringUtil.Str( (decimal)(AV19WWPFormElementId), 4, 0)), "", "", "", "", "", "");
         ucUcmentions.SendProperty(context, sPrefix, false, Ucmentions_Internalname, "DataListProcExtraPartameters", Ucmentions_Datalistprocextrapartameters);
         lblValidationconditionhelpicon_Caption = StringUtil.StringReplace( lblValidationconditionhelpicon_Caption, "VisibleConditionHelpText", "A condição pode se referir a outros campos usando o caráter &.<br/>Se os operadores \"\"and\"\" ou \"\"or\"\" forem usados, os dois lados da condição devem estar entre os parentesco. Por exemplo: (condicional_1) and ((condicionado_2) or (condicionado_3)).<br/>&Value deve ser usado para se referir ao campo atual.<br/>&Today pode ser usado para se referir à data atual, DateSum(&value, dias, meses, anos) para operar com datas e 0 é o valor de uma data vazia.");
         AssignProp(sPrefix, false, lblValidationconditionhelpicon_Internalname, "Caption", lblValidationconditionhelpicon_Caption, true);
         if ( StringUtil.StrCmp(AV12ValidationJson, "") != 0 )
         {
            AV10Validation.FromJSonString(AV12ValidationJson, null);
            AV11ValidationCondition = AV10Validation.gxTpr_Condition.gxTpr_Expression;
            AssignAttri(sPrefix, false, "AV11ValidationCondition", AV11ValidationCondition);
            AV13ValidationMessage = AV10Validation.gxTpr_Message;
            AssignAttri(sPrefix, false, "AV13ValidationMessage", AV13ValidationMessage);
         }
         divValidationconditioncell_Class = "DataContentCellFL RequiredDataContentCellFL DynamicForm_AttInfoIconCell";
         AssignProp(sPrefix, false, divValidationconditioncell_Internalname, "Class", divValidationconditioncell_Class, true);
      }

      protected void E13282( )
      {
         /* 'DoTestCondition' Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11ValidationCondition))) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Insira uma condição para validar",  "error",  edtavValidationcondition_Internalname,  "true",  ""));
         }
         else
         {
            AV8ExecuteConditionToTest = true;
            AssignAttri(sPrefix, false, "AV8ExecuteConditionToTest", AV8ExecuteConditionToTest);
            GXt_char1 = AV14VarCharAux;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getavailablevariables(context ).execute(  AV9SessionId,  AV22IncludeCurrentElement,  AV19WWPFormElementId,  9999,  "", out  GXt_char1) ;
            AV14VarCharAux = GXt_char1;
            AV5AllReferenceIds.FromJSonString(StringUtil.Lower( AV14VarCharAux), null);
            GXt_SdtWWP_Form2 = AV17WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV9SessionId, out  GXt_SdtWWP_Form2) ;
            AV17WWPForm = GXt_SdtWWP_Form2;
            /* Execute user subroutine: 'VALIDATE VISIBILITY CONDITION' */
            S112 ();
            if (returnInSub) return;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7ConditionError)) )
            {
               GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Condição executada com sucesso",  "success",  "",  "true",  ""));
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5AllReferenceIds", AV5AllReferenceIds);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17WWPForm", AV17WWPForm);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10Validation", AV10Validation);
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV6CheckRequiredFieldsResult = true;
         AssignAttri(sPrefix, false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13ValidationMessage)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Mensagem de validação", "", "", "", "", "", "", "", ""),  "error",  edtavValidationmessage_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11ValidationCondition)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  StringUtil.Format( "%1 é obrigatório.", "Condição de validação", "", "", "", "", "", "", "", ""),  "error",  edtavValidationcondition_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
         if ( AV6CheckRequiredFieldsResult )
         {
            GXt_SdtWWP_Form2 = AV17WWPForm;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_loadformdefinition(context ).execute(  AV9SessionId, out  GXt_SdtWWP_Form2) ;
            AV17WWPForm = GXt_SdtWWP_Form2;
            GXt_char1 = AV14VarCharAux;
            new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getavailablevariables(context ).execute(  AV9SessionId,  AV22IncludeCurrentElement,  AV19WWPFormElementId,  9999,  "", out  GXt_char1) ;
            AV14VarCharAux = GXt_char1;
            AV5AllReferenceIds.FromJSonString(StringUtil.Lower( AV14VarCharAux), null);
            AV8ExecuteConditionToTest = false;
            AssignAttri(sPrefix, false, "AV8ExecuteConditionToTest", AV8ExecuteConditionToTest);
            /* Execute user subroutine: 'VALIDATE VISIBILITY CONDITION' */
            S112 ();
            if (returnInSub) return;
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E14282 ();
         if (returnInSub) return;
      }

      protected void E14282( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV6CheckRequiredFieldsResult )
         {
            AV10Validation.gxTpr_Iserror = true;
            AV10Validation.gxTpr_Message = AV13ValidationMessage;
            this.executeExternalObjectMethod(sPrefix, false, "WWPActions", "WCPopup_Close", new Object[] {AV10Validation.ToJSonString(false, true)}, false);
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10Validation", AV10Validation);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV17WWPForm", AV17WWPForm);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV5AllReferenceIds", AV5AllReferenceIds);
      }

      protected void S112( )
      {
         /* 'VALIDATE VISIBILITY CONDITION' Routine */
         returnInSub = false;
         new GeneXus.Programs.workwithplus.dynamicforms.wwp_df_getconditionmentionsandvalidate(context ).execute(  AV17WWPForm,  AV11ValidationCondition,  true,  AV8ExecuteConditionToTest,  AV20WWPFormElementReferenceId,  AV18WWPFormElementDataType, ref  AV5AllReferenceIds, out  AV15VarCharList, out  AV7ConditionError) ;
         AssignAttri(sPrefix, false, "AV7ConditionError", AV7ConditionError);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7ConditionError)) )
         {
            AV10Validation.gxTpr_Condition.gxTpr_Expression = AV11ValidationCondition;
            AV10Validation.gxTpr_Condition.gxTpr_Mentionedfields = AV15VarCharList;
         }
         else
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  AV7ConditionError,  "error",  edtavValidationcondition_Internalname,  "true",  ""));
            AV6CheckRequiredFieldsResult = false;
            AssignAttri(sPrefix, false, "AV6CheckRequiredFieldsResult", AV6CheckRequiredFieldsResult);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E15282( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_22_282( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergedvalidationcondition_Internalname, tblTablemergedvalidationcondition_Internalname, "", "TableMerged", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='MergeDataCell'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavValidationcondition_Internalname, "Validation Condition", "gx-form-item AttributeFLLabel SmallTextAreaLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AttributeFL SmallTextArea";
            StyleString = "";
            ClassString = "AttributeFL SmallTextArea";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavValidationcondition_Internalname, AV11ValidationCondition, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", 0, 1, edtavValidationcondition_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WorkWithPlus/DynamicForms/WWP_DF_EditValidation.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='DynFormConditionHelpCell'>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblValidationconditionhelpicon_Internalname, lblValidationconditionhelpicon_Caption, "", "", lblValidationconditionhelpicon_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WorkWithPlus/DynamicForms/WWP_DF_EditValidation.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_22_282e( true) ;
         }
         else
         {
            wb_table1_22_282e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV16WWPDynamicFormMode = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV16WWPDynamicFormMode", AV16WWPDynamicFormMode);
         AV21WWPFormElementParentId = Convert.ToInt16(getParm(obj,1));
         AssignAttri(sPrefix, false, "AV21WWPFormElementParentId", StringUtil.LTrimStr( (decimal)(AV21WWPFormElementParentId), 4, 0));
         AV19WWPFormElementId = Convert.ToInt16(getParm(obj,2));
         AssignAttri(sPrefix, false, "AV19WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV19WWPFormElementId), 4, 0));
         AV20WWPFormElementReferenceId = (string)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV20WWPFormElementReferenceId", AV20WWPFormElementReferenceId);
         AV18WWPFormElementDataType = Convert.ToInt16(getParm(obj,4));
         AssignAttri(sPrefix, false, "AV18WWPFormElementDataType", StringUtil.LTrimStr( (decimal)(AV18WWPFormElementDataType), 2, 0));
         AV9SessionId = Convert.ToInt16(getParm(obj,5));
         AssignAttri(sPrefix, false, "AV9SessionId", StringUtil.LTrimStr( (decimal)(AV9SessionId), 4, 0));
         AV12ValidationJson = (string)getParm(obj,6);
         AssignAttri(sPrefix, false, "AV12ValidationJson", AV12ValidationJson);
         AV22IncludeCurrentElement = (bool)getParm(obj,7);
         AssignAttri(sPrefix, false, "AV22IncludeCurrentElement", AV22IncludeCurrentElement);
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA282( ) ;
         WS282( ) ;
         WE282( ) ;
         cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected override EncryptionType GetEncryptionType( )
      {
         return EncryptionType.SESSION ;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV16WWPDynamicFormMode = (string)((string)getParm(obj,0));
         sCtrlAV21WWPFormElementParentId = (string)((string)getParm(obj,1));
         sCtrlAV19WWPFormElementId = (string)((string)getParm(obj,2));
         sCtrlAV20WWPFormElementReferenceId = (string)((string)getParm(obj,3));
         sCtrlAV18WWPFormElementDataType = (string)((string)getParm(obj,4));
         sCtrlAV9SessionId = (string)((string)getParm(obj,5));
         sCtrlAV12ValidationJson = (string)((string)getParm(obj,6));
         sCtrlAV22IncludeCurrentElement = (string)((string)getParm(obj,7));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA282( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "workwithplus\\dynamicforms\\wwp_df_editvalidation", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA282( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV16WWPDynamicFormMode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV16WWPDynamicFormMode", AV16WWPDynamicFormMode);
            AV21WWPFormElementParentId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV21WWPFormElementParentId", StringUtil.LTrimStr( (decimal)(AV21WWPFormElementParentId), 4, 0));
            AV19WWPFormElementId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV19WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV19WWPFormElementId), 4, 0));
            AV20WWPFormElementReferenceId = (string)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV20WWPFormElementReferenceId", AV20WWPFormElementReferenceId);
            AV18WWPFormElementDataType = Convert.ToInt16(getParm(obj,6));
            AssignAttri(sPrefix, false, "AV18WWPFormElementDataType", StringUtil.LTrimStr( (decimal)(AV18WWPFormElementDataType), 2, 0));
            AV9SessionId = Convert.ToInt16(getParm(obj,7));
            AssignAttri(sPrefix, false, "AV9SessionId", StringUtil.LTrimStr( (decimal)(AV9SessionId), 4, 0));
            AV12ValidationJson = (string)getParm(obj,8);
            AssignAttri(sPrefix, false, "AV12ValidationJson", AV12ValidationJson);
            AV22IncludeCurrentElement = (bool)getParm(obj,9);
            AssignAttri(sPrefix, false, "AV22IncludeCurrentElement", AV22IncludeCurrentElement);
         }
         wcpOAV16WWPDynamicFormMode = cgiGet( sPrefix+"wcpOAV16WWPDynamicFormMode");
         wcpOAV21WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV21WWPFormElementParentId"), ",", "."), 18, MidpointRounding.ToEven));
         wcpOAV19WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV19WWPFormElementId"), ",", "."), 18, MidpointRounding.ToEven));
         wcpOAV20WWPFormElementReferenceId = cgiGet( sPrefix+"wcpOAV20WWPFormElementReferenceId");
         wcpOAV18WWPFormElementDataType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV18WWPFormElementDataType"), ",", "."), 18, MidpointRounding.ToEven));
         wcpOAV9SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9SessionId"), ",", "."), 18, MidpointRounding.ToEven));
         wcpOAV12ValidationJson = cgiGet( sPrefix+"wcpOAV12ValidationJson");
         wcpOAV22IncludeCurrentElement = StringUtil.StrToBool( cgiGet( sPrefix+"wcpOAV22IncludeCurrentElement"));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV16WWPDynamicFormMode, wcpOAV16WWPDynamicFormMode) != 0 ) || ( AV21WWPFormElementParentId != wcpOAV21WWPFormElementParentId ) || ( AV19WWPFormElementId != wcpOAV19WWPFormElementId ) || ( StringUtil.StrCmp(AV20WWPFormElementReferenceId, wcpOAV20WWPFormElementReferenceId) != 0 ) || ( AV18WWPFormElementDataType != wcpOAV18WWPFormElementDataType ) || ( AV9SessionId != wcpOAV9SessionId ) || ( StringUtil.StrCmp(AV12ValidationJson, wcpOAV12ValidationJson) != 0 ) || ( AV22IncludeCurrentElement != wcpOAV22IncludeCurrentElement ) ) )
         {
            setjustcreated();
         }
         wcpOAV16WWPDynamicFormMode = AV16WWPDynamicFormMode;
         wcpOAV21WWPFormElementParentId = AV21WWPFormElementParentId;
         wcpOAV19WWPFormElementId = AV19WWPFormElementId;
         wcpOAV20WWPFormElementReferenceId = AV20WWPFormElementReferenceId;
         wcpOAV18WWPFormElementDataType = AV18WWPFormElementDataType;
         wcpOAV9SessionId = AV9SessionId;
         wcpOAV12ValidationJson = AV12ValidationJson;
         wcpOAV22IncludeCurrentElement = AV22IncludeCurrentElement;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV16WWPDynamicFormMode = cgiGet( sPrefix+"AV16WWPDynamicFormMode_CTRL");
         if ( StringUtil.Len( sCtrlAV16WWPDynamicFormMode) > 0 )
         {
            AV16WWPDynamicFormMode = cgiGet( sCtrlAV16WWPDynamicFormMode);
            AssignAttri(sPrefix, false, "AV16WWPDynamicFormMode", AV16WWPDynamicFormMode);
         }
         else
         {
            AV16WWPDynamicFormMode = cgiGet( sPrefix+"AV16WWPDynamicFormMode_PARM");
         }
         sCtrlAV21WWPFormElementParentId = cgiGet( sPrefix+"AV21WWPFormElementParentId_CTRL");
         if ( StringUtil.Len( sCtrlAV21WWPFormElementParentId) > 0 )
         {
            AV21WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV21WWPFormElementParentId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV21WWPFormElementParentId", StringUtil.LTrimStr( (decimal)(AV21WWPFormElementParentId), 4, 0));
         }
         else
         {
            AV21WWPFormElementParentId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV21WWPFormElementParentId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
         sCtrlAV19WWPFormElementId = cgiGet( sPrefix+"AV19WWPFormElementId_CTRL");
         if ( StringUtil.Len( sCtrlAV19WWPFormElementId) > 0 )
         {
            AV19WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV19WWPFormElementId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV19WWPFormElementId", StringUtil.LTrimStr( (decimal)(AV19WWPFormElementId), 4, 0));
         }
         else
         {
            AV19WWPFormElementId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV19WWPFormElementId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
         sCtrlAV20WWPFormElementReferenceId = cgiGet( sPrefix+"AV20WWPFormElementReferenceId_CTRL");
         if ( StringUtil.Len( sCtrlAV20WWPFormElementReferenceId) > 0 )
         {
            AV20WWPFormElementReferenceId = cgiGet( sCtrlAV20WWPFormElementReferenceId);
            AssignAttri(sPrefix, false, "AV20WWPFormElementReferenceId", AV20WWPFormElementReferenceId);
         }
         else
         {
            AV20WWPFormElementReferenceId = cgiGet( sPrefix+"AV20WWPFormElementReferenceId_PARM");
         }
         sCtrlAV18WWPFormElementDataType = cgiGet( sPrefix+"AV18WWPFormElementDataType_CTRL");
         if ( StringUtil.Len( sCtrlAV18WWPFormElementDataType) > 0 )
         {
            AV18WWPFormElementDataType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV18WWPFormElementDataType), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV18WWPFormElementDataType", StringUtil.LTrimStr( (decimal)(AV18WWPFormElementDataType), 2, 0));
         }
         else
         {
            AV18WWPFormElementDataType = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV18WWPFormElementDataType_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
         sCtrlAV9SessionId = cgiGet( sPrefix+"AV9SessionId_CTRL");
         if ( StringUtil.Len( sCtrlAV9SessionId) > 0 )
         {
            AV9SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV9SessionId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV9SessionId", StringUtil.LTrimStr( (decimal)(AV9SessionId), 4, 0));
         }
         else
         {
            AV9SessionId = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV9SessionId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
         sCtrlAV12ValidationJson = cgiGet( sPrefix+"AV12ValidationJson_CTRL");
         if ( StringUtil.Len( sCtrlAV12ValidationJson) > 0 )
         {
            AV12ValidationJson = cgiGet( sCtrlAV12ValidationJson);
            AssignAttri(sPrefix, false, "AV12ValidationJson", AV12ValidationJson);
         }
         else
         {
            AV12ValidationJson = cgiGet( sPrefix+"AV12ValidationJson_PARM");
         }
         sCtrlAV22IncludeCurrentElement = cgiGet( sPrefix+"AV22IncludeCurrentElement_CTRL");
         if ( StringUtil.Len( sCtrlAV22IncludeCurrentElement) > 0 )
         {
            AV22IncludeCurrentElement = StringUtil.StrToBool( cgiGet( sCtrlAV22IncludeCurrentElement));
            AssignAttri(sPrefix, false, "AV22IncludeCurrentElement", AV22IncludeCurrentElement);
         }
         else
         {
            AV22IncludeCurrentElement = StringUtil.StrToBool( cgiGet( sPrefix+"AV22IncludeCurrentElement_PARM"));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA282( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS282( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS282( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV16WWPDynamicFormMode_PARM", StringUtil.RTrim( AV16WWPDynamicFormMode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV16WWPDynamicFormMode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV16WWPDynamicFormMode_CTRL", StringUtil.RTrim( sCtrlAV16WWPDynamicFormMode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV21WWPFormElementParentId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21WWPFormElementParentId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV21WWPFormElementParentId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV21WWPFormElementParentId_CTRL", StringUtil.RTrim( sCtrlAV21WWPFormElementParentId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV19WWPFormElementId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19WWPFormElementId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV19WWPFormElementId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV19WWPFormElementId_CTRL", StringUtil.RTrim( sCtrlAV19WWPFormElementId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV20WWPFormElementReferenceId_PARM", AV20WWPFormElementReferenceId);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV20WWPFormElementReferenceId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV20WWPFormElementReferenceId_CTRL", StringUtil.RTrim( sCtrlAV20WWPFormElementReferenceId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV18WWPFormElementDataType_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18WWPFormElementDataType), 2, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV18WWPFormElementDataType)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV18WWPFormElementDataType_CTRL", StringUtil.RTrim( sCtrlAV18WWPFormElementDataType));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9SessionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9SessionId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9SessionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9SessionId_CTRL", StringUtil.RTrim( sCtrlAV9SessionId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV12ValidationJson_PARM", AV12ValidationJson);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV12ValidationJson)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV12ValidationJson_CTRL", StringUtil.RTrim( sCtrlAV12ValidationJson));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV22IncludeCurrentElement_PARM", StringUtil.BoolToStr( AV22IncludeCurrentElement));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV22IncludeCurrentElement)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV22IncludeCurrentElement_CTRL", StringUtil.RTrim( sCtrlAV22IncludeCurrentElement));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE282( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101972179", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("workwithplus/dynamicforms/wwp_df_editvalidation.js", "?20256101972180", false, true);
         context.AddJavascriptSource("UserControls/WWP_IconButtonRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Suggest/SuggestRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavValidationmessage_Internalname = sPrefix+"vVALIDATIONMESSAGE";
         lblTextblockvalidationcondition_Internalname = sPrefix+"TEXTBLOCKVALIDATIONCONDITION";
         edtavValidationcondition_Internalname = sPrefix+"vVALIDATIONCONDITION";
         lblValidationconditionhelpicon_Internalname = sPrefix+"VALIDATIONCONDITIONHELPICON";
         tblTablemergedvalidationcondition_Internalname = sPrefix+"TABLEMERGEDVALIDATIONCONDITION";
         divTablesplittedvalidationcondition_Internalname = sPrefix+"TABLESPLITTEDVALIDATIONCONDITION";
         divValidationconditioncell_Internalname = sPrefix+"VALIDATIONCONDITIONCELL";
         Btntestcondition_Internalname = sPrefix+"BTNTESTCONDITION";
         Ucmentions_Internalname = sPrefix+"UCMENTIONS";
         divTableattributes_Internalname = sPrefix+"TABLEATTRIBUTES";
         bttBtnenter_Internalname = sPrefix+"BTNENTER";
         bttBtnuacancel_Internalname = sPrefix+"BTNUACANCEL";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusDS", true);
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtavValidationcondition_Enabled = 1;
         lblValidationconditionhelpicon_Caption = "<i class='BootstrapTooltipLeft fas fa-circle-info' title='VisibleConditionHelpText'></i>";
         Ucmentions_Datalistprocextrapartameters = "";
         Ucmentions_Datalistproc = "WorkWithPlus.DynamicForms.WWP_DF_GetAvailableVariables";
         Btntestcondition_Class = "ButtonGray";
         Btntestcondition_Caption = "Condição de teste";
         Btntestcondition_Beforeiconclass = "fas fa-circle-play";
         Btntestcondition_Tooltiptext = "";
         divValidationconditioncell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
         edtavValidationmessage_Enabled = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[]}""");
         setEventMetadata("'DOUACANCEL'","""{"handler":"E11281","iparms":[]}""");
         setEventMetadata("'DOTESTCONDITION'","""{"handler":"E13282","iparms":[{"av":"AV11ValidationCondition","fld":"vVALIDATIONCONDITION","type":"vchar"},{"av":"AV9SessionId","fld":"vSESSIONID","pic":"ZZZ9","type":"int"},{"av":"AV22IncludeCurrentElement","fld":"vINCLUDECURRENTELEMENT","type":"boolean"},{"av":"AV19WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9","type":"int"},{"av":"AV7ConditionError","fld":"vCONDITIONERROR","type":"svchar"},{"av":"AV17WWPForm","fld":"vWWPFORM","type":""},{"av":"AV8ExecuteConditionToTest","fld":"vEXECUTECONDITIONTOTEST","type":"boolean"},{"av":"AV20WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID","type":"svchar"},{"av":"AV18WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","type":"int"},{"av":"AV5AllReferenceIds","fld":"vALLREFERENCEIDS","type":""},{"av":"AV10Validation","fld":"vVALIDATION","type":""}]""");
         setEventMetadata("'DOTESTCONDITION'",""","oparms":[{"av":"AV8ExecuteConditionToTest","fld":"vEXECUTECONDITIONTOTEST","type":"boolean"},{"av":"AV5AllReferenceIds","fld":"vALLREFERENCEIDS","type":""},{"av":"AV17WWPForm","fld":"vWWPFORM","type":""},{"av":"AV7ConditionError","fld":"vCONDITIONERROR","type":"svchar"},{"av":"AV10Validation","fld":"vVALIDATION","type":""},{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"}]}""");
         setEventMetadata("ENTER","""{"handler":"E14282","iparms":[{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV10Validation","fld":"vVALIDATION","type":""},{"av":"AV13ValidationMessage","fld":"vVALIDATIONMESSAGE","type":"vchar"},{"av":"AV11ValidationCondition","fld":"vVALIDATIONCONDITION","type":"vchar"},{"av":"AV9SessionId","fld":"vSESSIONID","pic":"ZZZ9","type":"int"},{"av":"AV22IncludeCurrentElement","fld":"vINCLUDECURRENTELEMENT","type":"boolean"},{"av":"AV19WWPFormElementId","fld":"vWWPFORMELEMENTID","pic":"ZZZ9","type":"int"},{"av":"AV17WWPForm","fld":"vWWPFORM","type":""},{"av":"AV8ExecuteConditionToTest","fld":"vEXECUTECONDITIONTOTEST","type":"boolean"},{"av":"AV20WWPFormElementReferenceId","fld":"vWWPFORMELEMENTREFERENCEID","type":"svchar"},{"av":"AV18WWPFormElementDataType","fld":"vWWPFORMELEMENTDATATYPE","pic":"Z9","type":"int"},{"av":"AV5AllReferenceIds","fld":"vALLREFERENCEIDS","type":""}]""");
         setEventMetadata("ENTER",""","oparms":[{"av":"AV10Validation","fld":"vVALIDATION","type":""},{"av":"AV6CheckRequiredFieldsResult","fld":"vCHECKREQUIREDFIELDSRESULT","type":"boolean"},{"av":"AV17WWPForm","fld":"vWWPFORM","type":""},{"av":"AV5AllReferenceIds","fld":"vALLREFERENCEIDS","type":""},{"av":"AV8ExecuteConditionToTest","fld":"vEXECUTECONDITIONTOTEST","type":"boolean"},{"av":"AV7ConditionError","fld":"vCONDITIONERROR","type":"svchar"}]}""");
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

      public override void initialize( )
      {
         wcpOAV16WWPDynamicFormMode = "";
         wcpOAV20WWPFormElementReferenceId = "";
         wcpOAV12ValidationJson = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV7ConditionError = "";
         AV17WWPForm = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         AV5AllReferenceIds = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem>( context, "WWPSuggestDataItem", "Factory21");
         AV10Validation = new WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation(context);
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         AV13ValidationMessage = "";
         lblTextblockvalidationcondition_Jsonclick = "";
         ucBtntestcondition = new GXUserControl();
         ucUcmentions = new GXUserControl();
         bttBtnenter_Jsonclick = "";
         bttBtnuacancel_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV11ValidationCondition = "";
         AV14VarCharAux = "";
         GXt_SdtWWP_Form2 = new GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form(context);
         GXt_char1 = "";
         AV15VarCharList = new GxSimpleCollection<string>();
         sStyleString = "";
         lblValidationconditionhelpicon_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV16WWPDynamicFormMode = "";
         sCtrlAV21WWPFormElementParentId = "";
         sCtrlAV19WWPFormElementId = "";
         sCtrlAV20WWPFormElementReferenceId = "";
         sCtrlAV18WWPFormElementDataType = "";
         sCtrlAV9SessionId = "";
         sCtrlAV12ValidationJson = "";
         sCtrlAV22IncludeCurrentElement = "";
         /* GeneXus formulas. */
      }

      private short AV21WWPFormElementParentId ;
      private short AV19WWPFormElementId ;
      private short AV18WWPFormElementDataType ;
      private short AV9SessionId ;
      private short wcpOAV21WWPFormElementParentId ;
      private short wcpOAV19WWPFormElementId ;
      private short wcpOAV18WWPFormElementDataType ;
      private short wcpOAV9SessionId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int edtavValidationmessage_Enabled ;
      private int edtavValidationcondition_Enabled ;
      private int idxLst ;
      private string AV16WWPDynamicFormMode ;
      private string wcpOAV16WWPDynamicFormMode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableattributes_Internalname ;
      private string edtavValidationmessage_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string divValidationconditioncell_Internalname ;
      private string divValidationconditioncell_Class ;
      private string divTablesplittedvalidationcondition_Internalname ;
      private string lblTextblockvalidationcondition_Internalname ;
      private string lblTextblockvalidationcondition_Jsonclick ;
      private string Btntestcondition_Tooltiptext ;
      private string Btntestcondition_Beforeiconclass ;
      private string Btntestcondition_Caption ;
      private string Btntestcondition_Class ;
      private string Btntestcondition_Internalname ;
      private string Ucmentions_Datalistproc ;
      private string Ucmentions_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtnuacancel_Internalname ;
      private string bttBtnuacancel_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string edtavValidationcondition_Internalname ;
      private string Ucmentions_Datalistprocextrapartameters ;
      private string lblValidationconditionhelpicon_Caption ;
      private string lblValidationconditionhelpicon_Internalname ;
      private string GXt_char1 ;
      private string sStyleString ;
      private string tblTablemergedvalidationcondition_Internalname ;
      private string lblValidationconditionhelpicon_Jsonclick ;
      private string sCtrlAV16WWPDynamicFormMode ;
      private string sCtrlAV21WWPFormElementParentId ;
      private string sCtrlAV19WWPFormElementId ;
      private string sCtrlAV20WWPFormElementReferenceId ;
      private string sCtrlAV18WWPFormElementDataType ;
      private string sCtrlAV9SessionId ;
      private string sCtrlAV12ValidationJson ;
      private string sCtrlAV22IncludeCurrentElement ;
      private bool AV22IncludeCurrentElement ;
      private bool wcpOAV22IncludeCurrentElement ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV8ExecuteConditionToTest ;
      private bool AV6CheckRequiredFieldsResult ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV13ValidationMessage ;
      private string AV11ValidationCondition ;
      private string AV20WWPFormElementReferenceId ;
      private string AV12ValidationJson ;
      private string wcpOAV20WWPFormElementReferenceId ;
      private string wcpOAV12ValidationJson ;
      private string AV7ConditionError ;
      private string AV14VarCharAux ;
      private GXUserControl ucBtntestcondition ;
      private GXUserControl ucUcmentions ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form AV17WWPForm ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWPSuggestDataItem> AV5AllReferenceIds ;
      private WorkWithPlus.workwithplus_dynamicforms.SdtWWP_DF_Validation AV10Validation ;
      private GeneXus.Programs.workwithplus.dynamicforms.SdtWWP_Form GXt_SdtWWP_Form2 ;
      private GxSimpleCollection<string> AV15VarCharList ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
