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
   public class wcparticipante : GXWebComponent
   {
      public wcparticipante( )
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

      public wcparticipante( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_ParticipanteId ,
                           string aP1_ParticipanteNome ,
                           string aP2_ParticipanteDocumento ,
                           string aP3_ParticipanteEmail ,
                           string aP4_AssinaturaParticipanteTipo )
      {
         this.AV9ParticipanteId = aP0_ParticipanteId;
         this.AV5ParticipanteNome = aP1_ParticipanteNome;
         this.AV6ParticipanteDocumento = aP2_ParticipanteDocumento;
         this.AV7ParticipanteEmail = aP3_ParticipanteEmail;
         this.AV8AssinaturaParticipanteTipo = aP4_AssinaturaParticipanteTipo;
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
               gxfirstwebparm = GetFirstPar( "ParticipanteId");
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
                  AV9ParticipanteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ParticipanteId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV9ParticipanteId", StringUtil.LTrimStr( (decimal)(AV9ParticipanteId), 8, 0));
                  AV5ParticipanteNome = GetPar( "ParticipanteNome");
                  AssignAttri(sPrefix, false, "AV5ParticipanteNome", AV5ParticipanteNome);
                  AV6ParticipanteDocumento = GetPar( "ParticipanteDocumento");
                  AssignAttri(sPrefix, false, "AV6ParticipanteDocumento", AV6ParticipanteDocumento);
                  AV7ParticipanteEmail = GetPar( "ParticipanteEmail");
                  AssignAttri(sPrefix, false, "AV7ParticipanteEmail", AV7ParticipanteEmail);
                  AV8AssinaturaParticipanteTipo = GetPar( "AssinaturaParticipanteTipo");
                  AssignAttri(sPrefix, false, "AV8AssinaturaParticipanteTipo", AV8AssinaturaParticipanteTipo);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV9ParticipanteId,(string)AV5ParticipanteNome,(string)AV6ParticipanteDocumento,(string)AV7ParticipanteEmail,(string)AV8AssinaturaParticipanteTipo});
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
                  gxfirstwebparm = GetFirstPar( "ParticipanteId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ParticipanteId");
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
            PA4L2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               WS4L2( ) ;
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
            context.SendWebValue( "Participante") ;
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wcparticipante"+UrlEncode(StringUtil.LTrimStr(AV9ParticipanteId,8,0)) + "," + UrlEncode(StringUtil.RTrim(AV5ParticipanteNome)) + "," + UrlEncode(StringUtil.RTrim(AV6ParticipanteDocumento)) + "," + UrlEncode(StringUtil.RTrim(AV7ParticipanteEmail)) + "," + UrlEncode(StringUtil.RTrim(AV8AssinaturaParticipanteTipo));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wcparticipante") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
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
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9ParticipanteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV9ParticipanteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV5ParticipanteNome", wcpOAV5ParticipanteNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6ParticipanteDocumento", wcpOAV6ParticipanteDocumento);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7ParticipanteEmail", wcpOAV7ParticipanteEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8AssinaturaParticipanteTipo", wcpOAV8AssinaturaParticipanteTipo);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPARTICIPANTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ParticipanteId), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPARTICIPANTENOME", AV5ParticipanteNome);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPARTICIPANTEDOCUMENTO", AV6ParticipanteDocumento);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPARTICIPANTEEMAIL", AV7ParticipanteEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"vASSINATURAPARTICIPANTETIPO", AV8AssinaturaParticipanteTipo);
      }

      protected void RenderHtmlCloseForm4L2( )
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
         return "WcParticipante" ;
      }

      public override string GetPgmdesc( )
      {
         return "Participante" ;
      }

      protected void WB4L0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "wcparticipante");
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "card-party-contract", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-11", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltipo_Internalname, lblLbltipo_Caption, "", "", lblLbltipo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblExcluir_Internalname, "<i class=\"fas fa-times\"></i>", "", "", lblExcluir_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e114l1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 1, "HLP_WcParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblnome_Internalname, lblLblnome_Caption, "", "", lblLblnome_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecardcontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:space-between;align-items:flex-start;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldocumento_Internalname, lblLbldocumento_Caption, "", "", lblLbldocumento_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblemail_Internalname, lblLblemail_Caption, "", "", lblLblemail_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WcParticipante.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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

      protected void START4L2( )
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
            Form.Meta.addItem("description", "Participante", 0) ;
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
               STRUP4L0( ) ;
            }
         }
      }

      protected void WS4L2( )
      {
         START4L2( ) ;
         EVT4L2( ) ;
      }

      protected void EVT4L2( )
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
                                 STRUP4L0( ) ;
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
                                 STRUP4L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E124L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E134L2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4L0( ) ;
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
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP4L0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
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

      protected void WE4L2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4L2( ) ;
            }
         }
      }

      protected void PA4L2( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wcparticipante")), "wcparticipante") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wcparticipante")))) ;
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
                     gxfirstwebparm = GetFirstPar( "ParticipanteId");
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
         RF4L2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF4L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E134L2 ();
            WB4L0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4L2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E124L2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV9ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9ParticipanteId"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV5ParticipanteNome = cgiGet( sPrefix+"wcpOAV5ParticipanteNome");
            wcpOAV6ParticipanteDocumento = cgiGet( sPrefix+"wcpOAV6ParticipanteDocumento");
            wcpOAV7ParticipanteEmail = cgiGet( sPrefix+"wcpOAV7ParticipanteEmail");
            wcpOAV8AssinaturaParticipanteTipo = cgiGet( sPrefix+"wcpOAV8AssinaturaParticipanteTipo");
            AV9ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"vPARTICIPANTEID"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
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
         E124L2 ();
         if (returnInSub) return;
      }

      protected void E124L2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblLbltipo_Caption = StringUtil.Format( "<h2>%1</h2>", AV8AssinaturaParticipanteTipo, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblLbltipo_Internalname, "Caption", lblLbltipo_Caption, true);
         lblLblnome_Caption = StringUtil.Format( "<h3>%1</h3>", AV5ParticipanteNome, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblLblnome_Internalname, "Caption", lblLblnome_Caption, true);
         lblLbldocumento_Caption = StringUtil.Format( "<h4>CPF: %1</h4>", AV6ParticipanteDocumento, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblLbldocumento_Internalname, "Caption", lblLbldocumento_Caption, true);
         lblLblemail_Caption = StringUtil.Format( "<h4>E-mail: %1</h4>", AV7ParticipanteEmail, "", "", "", "", "", "", "", "");
         AssignProp(sPrefix, false, lblLblemail_Internalname, "Caption", lblLblemail_Caption, true);
      }

      protected void nextLoad( )
      {
      }

      protected void E134L2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV9ParticipanteId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV9ParticipanteId", StringUtil.LTrimStr( (decimal)(AV9ParticipanteId), 8, 0));
         AV5ParticipanteNome = (string)getParm(obj,1);
         AssignAttri(sPrefix, false, "AV5ParticipanteNome", AV5ParticipanteNome);
         AV6ParticipanteDocumento = (string)getParm(obj,2);
         AssignAttri(sPrefix, false, "AV6ParticipanteDocumento", AV6ParticipanteDocumento);
         AV7ParticipanteEmail = (string)getParm(obj,3);
         AssignAttri(sPrefix, false, "AV7ParticipanteEmail", AV7ParticipanteEmail);
         AV8AssinaturaParticipanteTipo = (string)getParm(obj,4);
         AssignAttri(sPrefix, false, "AV8AssinaturaParticipanteTipo", AV8AssinaturaParticipanteTipo);
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
         PA4L2( ) ;
         WS4L2( ) ;
         WE4L2( ) ;
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
         sCtrlAV9ParticipanteId = (string)((string)getParm(obj,0));
         sCtrlAV5ParticipanteNome = (string)((string)getParm(obj,1));
         sCtrlAV6ParticipanteDocumento = (string)((string)getParm(obj,2));
         sCtrlAV7ParticipanteEmail = (string)((string)getParm(obj,3));
         sCtrlAV8AssinaturaParticipanteTipo = (string)((string)getParm(obj,4));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA4L2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "wcparticipante", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA4L2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV9ParticipanteId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV9ParticipanteId", StringUtil.LTrimStr( (decimal)(AV9ParticipanteId), 8, 0));
            AV5ParticipanteNome = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV5ParticipanteNome", AV5ParticipanteNome);
            AV6ParticipanteDocumento = (string)getParm(obj,4);
            AssignAttri(sPrefix, false, "AV6ParticipanteDocumento", AV6ParticipanteDocumento);
            AV7ParticipanteEmail = (string)getParm(obj,5);
            AssignAttri(sPrefix, false, "AV7ParticipanteEmail", AV7ParticipanteEmail);
            AV8AssinaturaParticipanteTipo = (string)getParm(obj,6);
            AssignAttri(sPrefix, false, "AV8AssinaturaParticipanteTipo", AV8AssinaturaParticipanteTipo);
         }
         wcpOAV9ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9ParticipanteId"), ",", "."), 18, MidpointRounding.ToEven));
         wcpOAV5ParticipanteNome = cgiGet( sPrefix+"wcpOAV5ParticipanteNome");
         wcpOAV6ParticipanteDocumento = cgiGet( sPrefix+"wcpOAV6ParticipanteDocumento");
         wcpOAV7ParticipanteEmail = cgiGet( sPrefix+"wcpOAV7ParticipanteEmail");
         wcpOAV8AssinaturaParticipanteTipo = cgiGet( sPrefix+"wcpOAV8AssinaturaParticipanteTipo");
         if ( ! GetJustCreated( ) && ( ( AV9ParticipanteId != wcpOAV9ParticipanteId ) || ( StringUtil.StrCmp(AV5ParticipanteNome, wcpOAV5ParticipanteNome) != 0 ) || ( StringUtil.StrCmp(AV6ParticipanteDocumento, wcpOAV6ParticipanteDocumento) != 0 ) || ( StringUtil.StrCmp(AV7ParticipanteEmail, wcpOAV7ParticipanteEmail) != 0 ) || ( StringUtil.StrCmp(AV8AssinaturaParticipanteTipo, wcpOAV8AssinaturaParticipanteTipo) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV9ParticipanteId = AV9ParticipanteId;
         wcpOAV5ParticipanteNome = AV5ParticipanteNome;
         wcpOAV6ParticipanteDocumento = AV6ParticipanteDocumento;
         wcpOAV7ParticipanteEmail = AV7ParticipanteEmail;
         wcpOAV8AssinaturaParticipanteTipo = AV8AssinaturaParticipanteTipo;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV9ParticipanteId = cgiGet( sPrefix+"AV9ParticipanteId_CTRL");
         if ( StringUtil.Len( sCtrlAV9ParticipanteId) > 0 )
         {
            AV9ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV9ParticipanteId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV9ParticipanteId", StringUtil.LTrimStr( (decimal)(AV9ParticipanteId), 8, 0));
         }
         else
         {
            AV9ParticipanteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV9ParticipanteId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
         }
         sCtrlAV5ParticipanteNome = cgiGet( sPrefix+"AV5ParticipanteNome_CTRL");
         if ( StringUtil.Len( sCtrlAV5ParticipanteNome) > 0 )
         {
            AV5ParticipanteNome = cgiGet( sCtrlAV5ParticipanteNome);
            AssignAttri(sPrefix, false, "AV5ParticipanteNome", AV5ParticipanteNome);
         }
         else
         {
            AV5ParticipanteNome = cgiGet( sPrefix+"AV5ParticipanteNome_PARM");
         }
         sCtrlAV6ParticipanteDocumento = cgiGet( sPrefix+"AV6ParticipanteDocumento_CTRL");
         if ( StringUtil.Len( sCtrlAV6ParticipanteDocumento) > 0 )
         {
            AV6ParticipanteDocumento = cgiGet( sCtrlAV6ParticipanteDocumento);
            AssignAttri(sPrefix, false, "AV6ParticipanteDocumento", AV6ParticipanteDocumento);
         }
         else
         {
            AV6ParticipanteDocumento = cgiGet( sPrefix+"AV6ParticipanteDocumento_PARM");
         }
         sCtrlAV7ParticipanteEmail = cgiGet( sPrefix+"AV7ParticipanteEmail_CTRL");
         if ( StringUtil.Len( sCtrlAV7ParticipanteEmail) > 0 )
         {
            AV7ParticipanteEmail = cgiGet( sCtrlAV7ParticipanteEmail);
            AssignAttri(sPrefix, false, "AV7ParticipanteEmail", AV7ParticipanteEmail);
         }
         else
         {
            AV7ParticipanteEmail = cgiGet( sPrefix+"AV7ParticipanteEmail_PARM");
         }
         sCtrlAV8AssinaturaParticipanteTipo = cgiGet( sPrefix+"AV8AssinaturaParticipanteTipo_CTRL");
         if ( StringUtil.Len( sCtrlAV8AssinaturaParticipanteTipo) > 0 )
         {
            AV8AssinaturaParticipanteTipo = cgiGet( sCtrlAV8AssinaturaParticipanteTipo);
            AssignAttri(sPrefix, false, "AV8AssinaturaParticipanteTipo", AV8AssinaturaParticipanteTipo);
         }
         else
         {
            AV8AssinaturaParticipanteTipo = cgiGet( sPrefix+"AV8AssinaturaParticipanteTipo_PARM");
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
         PA4L2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS4L2( ) ;
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
         WS4L2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9ParticipanteId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ParticipanteId), 8, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9ParticipanteId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9ParticipanteId_CTRL", StringUtil.RTrim( sCtrlAV9ParticipanteId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV5ParticipanteNome_PARM", AV5ParticipanteNome);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV5ParticipanteNome)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV5ParticipanteNome_CTRL", StringUtil.RTrim( sCtrlAV5ParticipanteNome));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6ParticipanteDocumento_PARM", AV6ParticipanteDocumento);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6ParticipanteDocumento)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6ParticipanteDocumento_CTRL", StringUtil.RTrim( sCtrlAV6ParticipanteDocumento));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7ParticipanteEmail_PARM", AV7ParticipanteEmail);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7ParticipanteEmail)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7ParticipanteEmail_CTRL", StringUtil.RTrim( sCtrlAV7ParticipanteEmail));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8AssinaturaParticipanteTipo_PARM", AV8AssinaturaParticipanteTipo);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8AssinaturaParticipanteTipo)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8AssinaturaParticipanteTipo_CTRL", StringUtil.RTrim( sCtrlAV8AssinaturaParticipanteTipo));
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
         WE4L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101964719", true, true);
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
         context.AddJavascriptSource("wcparticipante.js", "?20256101964719", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLbltipo_Internalname = sPrefix+"LBLTIPO";
         lblExcluir_Internalname = sPrefix+"EXCLUIR";
         divUnnamedtable1_Internalname = sPrefix+"UNNAMEDTABLE1";
         lblLblnome_Internalname = sPrefix+"LBLNOME";
         lblLbldocumento_Internalname = sPrefix+"LBLDOCUMENTO";
         lblLblemail_Internalname = sPrefix+"LBLEMAIL";
         divTablecardcontent_Internalname = sPrefix+"TABLECARDCONTENT";
         divTablecontent_Internalname = sPrefix+"TABLECONTENT";
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
         lblLblemail_Caption = "<h4>E-mail: alessandro.piazzati@gmail.com</h4>";
         lblLbldocumento_Caption = "<h4>CPF: 341.368.878-25</h4>";
         lblLblnome_Caption = "<h3>Alessandro Piazza</h3>";
         lblLbltipo_Caption = "<h2>Contratante</h2>";
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("'DOEXCLUIR'","""{"handler":"E114L1","iparms":[{"av":"AV9ParticipanteId","fld":"vPARTICIPANTEID","pic":"ZZZZZZZ9","type":"int"}]}""");
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
         wcpOAV5ParticipanteNome = "";
         wcpOAV6ParticipanteDocumento = "";
         wcpOAV7ParticipanteEmail = "";
         wcpOAV8AssinaturaParticipanteTipo = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblLbltipo_Jsonclick = "";
         lblExcluir_Jsonclick = "";
         lblLblnome_Jsonclick = "";
         lblLbldocumento_Jsonclick = "";
         lblLblemail_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV9ParticipanteId = "";
         sCtrlAV5ParticipanteNome = "";
         sCtrlAV6ParticipanteDocumento = "";
         sCtrlAV7ParticipanteEmail = "";
         sCtrlAV8AssinaturaParticipanteTipo = "";
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV9ParticipanteId ;
      private int wcpOAV9ParticipanteId ;
      private int idxLst ;
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
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string lblLbltipo_Internalname ;
      private string lblLbltipo_Caption ;
      private string lblLbltipo_Jsonclick ;
      private string lblExcluir_Internalname ;
      private string lblExcluir_Jsonclick ;
      private string lblLblnome_Internalname ;
      private string lblLblnome_Caption ;
      private string lblLblnome_Jsonclick ;
      private string divTablecardcontent_Internalname ;
      private string lblLbldocumento_Internalname ;
      private string lblLbldocumento_Caption ;
      private string lblLbldocumento_Jsonclick ;
      private string lblLblemail_Internalname ;
      private string lblLblemail_Caption ;
      private string lblLblemail_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string sCtrlAV9ParticipanteId ;
      private string sCtrlAV5ParticipanteNome ;
      private string sCtrlAV6ParticipanteDocumento ;
      private string sCtrlAV7ParticipanteEmail ;
      private string sCtrlAV8AssinaturaParticipanteTipo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV5ParticipanteNome ;
      private string AV6ParticipanteDocumento ;
      private string AV7ParticipanteEmail ;
      private string AV8AssinaturaParticipanteTipo ;
      private string wcpOAV5ParticipanteNome ;
      private string wcpOAV6ParticipanteDocumento ;
      private string wcpOAV7ParticipanteEmail ;
      private string wcpOAV8AssinaturaParticipanteTipo ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

}
