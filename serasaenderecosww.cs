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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class serasaenderecosww : GXWebComponent
   {
      public serasaenderecosww( )
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

      public serasaenderecosww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_SerasaId )
      {
         this.AV34SerasaId = aP0_SerasaId;
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
               gxfirstwebparm = GetFirstPar( "SerasaId");
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
                  AV34SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri(sPrefix, false, "AV34SerasaId", StringUtil.LTrimStr( (decimal)(AV34SerasaId), 9, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(int)AV34SerasaId});
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
                  gxfirstwebparm = GetFirstPar( "SerasaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "SerasaId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  gxnrGrid_newrow_invoke( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  gxgrGrid_refresh_invoke( ) ;
                  return  ;
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

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_12 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_12"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_12_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_12_idx = GetPar( "sGXsfl_12_idx");
         sPrefix = GetPar( "sPrefix");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV13OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV34SerasaId = (int)(Math.Round(NumberUtil.Val( GetPar( "SerasaId"), "."), 18, MidpointRounding.ToEven));
         AV15TFSerasaEnderecosCEP = GetPar( "TFSerasaEnderecosCEP");
         AV16TFSerasaEnderecosCEP_Sel = GetPar( "TFSerasaEnderecosCEP_Sel");
         AV17TFSerasaEnderecosLogr = GetPar( "TFSerasaEnderecosLogr");
         AV18TFSerasaEnderecosLogr_Sel = GetPar( "TFSerasaEnderecosLogr_Sel");
         AV19TFSerasaEnderecosNum = GetPar( "TFSerasaEnderecosNum");
         AV20TFSerasaEnderecosNum_Sel = GetPar( "TFSerasaEnderecosNum_Sel");
         AV21TFSerasaEnderecosCompl = GetPar( "TFSerasaEnderecosCompl");
         AV22TFSerasaEnderecosCompl_Sel = GetPar( "TFSerasaEnderecosCompl_Sel");
         AV23TFSerasaEnderecosBairro = GetPar( "TFSerasaEnderecosBairro");
         AV24TFSerasaEnderecosBairro_Sel = GetPar( "TFSerasaEnderecosBairro_Sel");
         AV25TFSerasaEnderecosCidade = GetPar( "TFSerasaEnderecosCidade");
         AV26TFSerasaEnderecosCidade_Sel = GetPar( "TFSerasaEnderecosCidade_Sel");
         AV27TFSerasaEnderecosEstado = GetPar( "TFSerasaEnderecosEstado");
         AV28TFSerasaEnderecosEstado_Sel = GetPar( "TFSerasaEnderecosEstado_Sel");
         AV29TFSerasaEnderecosTelDDD = GetPar( "TFSerasaEnderecosTelDDD");
         AV30TFSerasaEnderecosTelDDD_Sel = GetPar( "TFSerasaEnderecosTelDDD_Sel");
         AV31TFSerasaEnderecosTel = GetPar( "TFSerasaEnderecosTel");
         AV32TFSerasaEnderecosTel_Sel = GetPar( "TFSerasaEnderecosTel_Sel");
         AV54Pgmname = GetPar( "Pgmname");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV34SerasaId, AV15TFSerasaEnderecosCEP, AV16TFSerasaEnderecosCEP_Sel, AV17TFSerasaEnderecosLogr, AV18TFSerasaEnderecosLogr_Sel, AV19TFSerasaEnderecosNum, AV20TFSerasaEnderecosNum_Sel, AV21TFSerasaEnderecosCompl, AV22TFSerasaEnderecosCompl_Sel, AV23TFSerasaEnderecosBairro, AV24TFSerasaEnderecosBairro_Sel, AV25TFSerasaEnderecosCidade, AV26TFSerasaEnderecosCidade_Sel, AV27TFSerasaEnderecosEstado, AV28TFSerasaEnderecosEstado_Sel, AV29TFSerasaEnderecosTelDDD, AV30TFSerasaEnderecosTelDDD_Sel, AV31TFSerasaEnderecosTel, AV32TFSerasaEnderecosTel_Sel, AV54Pgmname, sPrefix) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
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
            PA892( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV54Pgmname = "SerasaEnderecosWW";
               WS892( ) ;
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
            context.SendWebValue( " Serasa Enderecos") ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GXEncryptionTmp = "serasaenderecosww"+UrlEncode(StringUtil.LTrimStr(AV34SerasaId,9,0));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("serasaenderecosww") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GXH_vORDEREDDSC", StringUtil.BoolToStr( AV13OrderedDsc));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_12", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_12), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vDDO_TITLESETTINGSICONS", AV33DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vDDO_TITLESETTINGSICONS", AV33DDO_TitleSettingsIcons);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV34SerasaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV34SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSERASAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34SerasaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSCEP", AV15TFSerasaEnderecosCEP);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSCEP_SEL", AV16TFSerasaEnderecosCEP_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSLOGR", AV17TFSerasaEnderecosLogr);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSLOGR_SEL", AV18TFSerasaEnderecosLogr_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSNUM", AV19TFSerasaEnderecosNum);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSNUM_SEL", AV20TFSerasaEnderecosNum_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSCOMPL", AV21TFSerasaEnderecosCompl);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSCOMPL_SEL", AV22TFSerasaEnderecosCompl_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSBAIRRO", AV23TFSerasaEnderecosBairro);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSBAIRRO_SEL", AV24TFSerasaEnderecosBairro_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSCIDADE", AV25TFSerasaEnderecosCidade);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSCIDADE_SEL", AV26TFSerasaEnderecosCidade_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSESTADO", AV27TFSerasaEnderecosEstado);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSESTADO_SEL", AV28TFSerasaEnderecosEstado_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSTELDDD", AV29TFSerasaEnderecosTelDDD);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSTELDDD_SEL", AV30TFSerasaEnderecosTelDDD_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSTEL", AV31TFSerasaEnderecosTel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vTFSERASAENDERECOSTEL_SEL", AV32TFSerasaEnderecosTel_Sel);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vORDEREDDSC", AV13OrderedDsc);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, sPrefix+"DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
      }

      protected void RenderHtmlCloseForm892( )
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
         return "SerasaEnderecosWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Serasa Enderecos" ;
      }

      protected void WB890( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "serasaenderecosww");
               context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
               context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
               context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl12( ) ;
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            nRC_GXsfl_12 = (int)(nGXsfl_12_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV33DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, sPrefix+"DDO_GRIDContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, sPrefix+"GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 12 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START892( )
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
            Form.Meta.addItem("description", " Serasa Enderecos", 0) ;
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
               STRUP890( ) ;
            }
         }
      }

      protected void WS892( )
      {
         START892( ) ;
         EVT892( ) ;
      }

      protected void EVT892( )
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
                                 STRUP890( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP890( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Ddo_grid.Onoptionclicked */
                                    E11892 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP890( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP890( ) ;
                              }
                              AV35Serasaenderecoswwds_1_serasaid = AV34SerasaId;
                              AV36Serasaenderecoswwds_2_tfserasaenderecoscep = AV15TFSerasaEnderecosCEP;
                              AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV16TFSerasaEnderecosCEP_Sel;
                              AV38Serasaenderecoswwds_4_tfserasaenderecoslogr = AV17TFSerasaEnderecosLogr;
                              AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV18TFSerasaEnderecosLogr_Sel;
                              AV40Serasaenderecoswwds_6_tfserasaenderecosnum = AV19TFSerasaEnderecosNum;
                              AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV20TFSerasaEnderecosNum_Sel;
                              AV42Serasaenderecoswwds_8_tfserasaenderecoscompl = AV21TFSerasaEnderecosCompl;
                              AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV22TFSerasaEnderecosCompl_Sel;
                              AV44Serasaenderecoswwds_10_tfserasaenderecosbairro = AV23TFSerasaEnderecosBairro;
                              AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV24TFSerasaEnderecosBairro_Sel;
                              AV46Serasaenderecoswwds_12_tfserasaenderecoscidade = AV25TFSerasaEnderecosCidade;
                              AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV26TFSerasaEnderecosCidade_Sel;
                              AV48Serasaenderecoswwds_14_tfserasaenderecosestado = AV27TFSerasaEnderecosEstado;
                              AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV28TFSerasaEnderecosEstado_Sel;
                              AV50Serasaenderecoswwds_16_tfserasaenderecostelddd = AV29TFSerasaEnderecosTelDDD;
                              AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV30TFSerasaEnderecosTelDDD_Sel;
                              AV52Serasaenderecoswwds_18_tfserasaenderecostel = AV31TFSerasaEnderecosTel;
                              AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV32TFSerasaEnderecosTel_Sel;
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP890( ) ;
                              }
                              nGXsfl_12_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
                              SubsflControlProps_122( ) ;
                              A716SerasaEnderecosId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaEnderecosId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A662SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtSerasaId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              n662SerasaId = false;
                              A723SerasaEnderecosCEP = cgiGet( edtSerasaEnderecosCEP_Internalname);
                              n723SerasaEnderecosCEP = false;
                              A717SerasaEnderecosLogr = cgiGet( edtSerasaEnderecosLogr_Internalname);
                              n717SerasaEnderecosLogr = false;
                              A718SerasaEnderecosNum = cgiGet( edtSerasaEnderecosNum_Internalname);
                              n718SerasaEnderecosNum = false;
                              A719SerasaEnderecosCompl = cgiGet( edtSerasaEnderecosCompl_Internalname);
                              n719SerasaEnderecosCompl = false;
                              A720SerasaEnderecosBairro = cgiGet( edtSerasaEnderecosBairro_Internalname);
                              n720SerasaEnderecosBairro = false;
                              A721SerasaEnderecosCidade = cgiGet( edtSerasaEnderecosCidade_Internalname);
                              n721SerasaEnderecosCidade = false;
                              A722SerasaEnderecosEstado = cgiGet( edtSerasaEnderecosEstado_Internalname);
                              n722SerasaEnderecosEstado = false;
                              A724SerasaEnderecosTelDDD = cgiGet( edtSerasaEnderecosTelDDD_Internalname);
                              n724SerasaEnderecosTelDDD = false;
                              A725SerasaEnderecosTel = cgiGet( edtSerasaEnderecosTel_Internalname);
                              n725SerasaEnderecosTel = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E12892 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Refresh */
                                          E13892 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Grid.Load */
                                          E14892 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             /* Set Refresh If Orderedby Changed */
                                             if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
                                             {
                                                Rfr0gs = true;
                                             }
                                             /* Set Refresh If Ordereddsc Changed */
                                             if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV13OrderedDsc )
                                             {
                                                Rfr0gs = true;
                                             }
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
                                       STRUP890( ) ;
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
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE892( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm892( ) ;
            }
         }
      }

      protected void PA892( )
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
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "serasaenderecosww")), "serasaenderecosww") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "serasaenderecosww")))) ;
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
                     gxfirstwebparm = GetFirstPar( "SerasaId");
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

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_122( ) ;
         while ( nGXsfl_12_idx <= nRC_GXsfl_12 )
         {
            sendrow_122( ) ;
            nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV12OrderedBy ,
                                       bool AV13OrderedDsc ,
                                       int AV34SerasaId ,
                                       string AV15TFSerasaEnderecosCEP ,
                                       string AV16TFSerasaEnderecosCEP_Sel ,
                                       string AV17TFSerasaEnderecosLogr ,
                                       string AV18TFSerasaEnderecosLogr_Sel ,
                                       string AV19TFSerasaEnderecosNum ,
                                       string AV20TFSerasaEnderecosNum_Sel ,
                                       string AV21TFSerasaEnderecosCompl ,
                                       string AV22TFSerasaEnderecosCompl_Sel ,
                                       string AV23TFSerasaEnderecosBairro ,
                                       string AV24TFSerasaEnderecosBairro_Sel ,
                                       string AV25TFSerasaEnderecosCidade ,
                                       string AV26TFSerasaEnderecosCidade_Sel ,
                                       string AV27TFSerasaEnderecosEstado ,
                                       string AV28TFSerasaEnderecosEstado_Sel ,
                                       string AV29TFSerasaEnderecosTelDDD ,
                                       string AV30TFSerasaEnderecosTelDDD_Sel ,
                                       string AV31TFSerasaEnderecosTel ,
                                       string AV32TFSerasaEnderecosTel_Sel ,
                                       string AV54Pgmname ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF892( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
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
         RF892( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV54Pgmname = "SerasaEnderecosWW";
      }

      protected void RF892( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 12;
         /* Execute user event: Refresh */
         E13892 ();
         nGXsfl_12_idx = 1;
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         bGXsfl_12_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_122( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                                 AV36Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                                 AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                                 AV38Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                                 AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                                 AV40Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                                 AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                                 AV42Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                                 AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                                 AV44Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                                 AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                                 AV46Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                                 AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                                 AV48Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                                 AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                                 AV50Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                                 AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                                 AV52Serasaenderecoswwds_18_tfserasaenderecostel ,
                                                 A723SerasaEnderecosCEP ,
                                                 A717SerasaEnderecosLogr ,
                                                 A718SerasaEnderecosNum ,
                                                 A719SerasaEnderecosCompl ,
                                                 A720SerasaEnderecosBairro ,
                                                 A721SerasaEnderecosCidade ,
                                                 A722SerasaEnderecosEstado ,
                                                 A724SerasaEnderecosTelDDD ,
                                                 A725SerasaEnderecosTel ,
                                                 AV12OrderedBy ,
                                                 AV13OrderedDsc ,
                                                 A662SerasaId ,
                                                 AV35Serasaenderecoswwds_1_serasaid } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                                 TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV36Serasaenderecoswwds_2_tfserasaenderecoscep = StringUtil.Concat( StringUtil.RTrim( AV36Serasaenderecoswwds_2_tfserasaenderecoscep), "%", "");
            lV38Serasaenderecoswwds_4_tfserasaenderecoslogr = StringUtil.Concat( StringUtil.RTrim( AV38Serasaenderecoswwds_4_tfserasaenderecoslogr), "%", "");
            lV40Serasaenderecoswwds_6_tfserasaenderecosnum = StringUtil.Concat( StringUtil.RTrim( AV40Serasaenderecoswwds_6_tfserasaenderecosnum), "%", "");
            lV42Serasaenderecoswwds_8_tfserasaenderecoscompl = StringUtil.Concat( StringUtil.RTrim( AV42Serasaenderecoswwds_8_tfserasaenderecoscompl), "%", "");
            lV44Serasaenderecoswwds_10_tfserasaenderecosbairro = StringUtil.Concat( StringUtil.RTrim( AV44Serasaenderecoswwds_10_tfserasaenderecosbairro), "%", "");
            lV46Serasaenderecoswwds_12_tfserasaenderecoscidade = StringUtil.Concat( StringUtil.RTrim( AV46Serasaenderecoswwds_12_tfserasaenderecoscidade), "%", "");
            lV48Serasaenderecoswwds_14_tfserasaenderecosestado = StringUtil.Concat( StringUtil.RTrim( AV48Serasaenderecoswwds_14_tfserasaenderecosestado), "%", "");
            lV50Serasaenderecoswwds_16_tfserasaenderecostelddd = StringUtil.Concat( StringUtil.RTrim( AV50Serasaenderecoswwds_16_tfserasaenderecostelddd), "%", "");
            lV52Serasaenderecoswwds_18_tfserasaenderecostel = StringUtil.Concat( StringUtil.RTrim( AV52Serasaenderecoswwds_18_tfserasaenderecostel), "%", "");
            /* Using cursor H00892 */
            pr_default.execute(0, new Object[] {AV35Serasaenderecoswwds_1_serasaid, lV36Serasaenderecoswwds_2_tfserasaenderecoscep, AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel, lV38Serasaenderecoswwds_4_tfserasaenderecoslogr, AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, lV40Serasaenderecoswwds_6_tfserasaenderecosnum, AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel, lV42Serasaenderecoswwds_8_tfserasaenderecoscompl, AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, lV44Serasaenderecoswwds_10_tfserasaenderecosbairro, AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, lV46Serasaenderecoswwds_12_tfserasaenderecoscidade, AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, lV48Serasaenderecoswwds_14_tfserasaenderecosestado, AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel, lV50Serasaenderecoswwds_16_tfserasaenderecostelddd, AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, lV52Serasaenderecoswwds_18_tfserasaenderecostel, AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_12_idx = 1;
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A725SerasaEnderecosTel = H00892_A725SerasaEnderecosTel[0];
               n725SerasaEnderecosTel = H00892_n725SerasaEnderecosTel[0];
               A724SerasaEnderecosTelDDD = H00892_A724SerasaEnderecosTelDDD[0];
               n724SerasaEnderecosTelDDD = H00892_n724SerasaEnderecosTelDDD[0];
               A722SerasaEnderecosEstado = H00892_A722SerasaEnderecosEstado[0];
               n722SerasaEnderecosEstado = H00892_n722SerasaEnderecosEstado[0];
               A721SerasaEnderecosCidade = H00892_A721SerasaEnderecosCidade[0];
               n721SerasaEnderecosCidade = H00892_n721SerasaEnderecosCidade[0];
               A720SerasaEnderecosBairro = H00892_A720SerasaEnderecosBairro[0];
               n720SerasaEnderecosBairro = H00892_n720SerasaEnderecosBairro[0];
               A719SerasaEnderecosCompl = H00892_A719SerasaEnderecosCompl[0];
               n719SerasaEnderecosCompl = H00892_n719SerasaEnderecosCompl[0];
               A718SerasaEnderecosNum = H00892_A718SerasaEnderecosNum[0];
               n718SerasaEnderecosNum = H00892_n718SerasaEnderecosNum[0];
               A717SerasaEnderecosLogr = H00892_A717SerasaEnderecosLogr[0];
               n717SerasaEnderecosLogr = H00892_n717SerasaEnderecosLogr[0];
               A723SerasaEnderecosCEP = H00892_A723SerasaEnderecosCEP[0];
               n723SerasaEnderecosCEP = H00892_n723SerasaEnderecosCEP[0];
               A662SerasaId = H00892_A662SerasaId[0];
               n662SerasaId = H00892_n662SerasaId[0];
               A716SerasaEnderecosId = H00892_A716SerasaEnderecosId[0];
               /* Execute user event: Grid.Load */
               E14892 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 12;
            WB890( ) ;
         }
         bGXsfl_12_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes892( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV54Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV54Pgmname, "")), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV35Serasaenderecoswwds_1_serasaid = AV34SerasaId;
         AV36Serasaenderecoswwds_2_tfserasaenderecoscep = AV15TFSerasaEnderecosCEP;
         AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV16TFSerasaEnderecosCEP_Sel;
         AV38Serasaenderecoswwds_4_tfserasaenderecoslogr = AV17TFSerasaEnderecosLogr;
         AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV18TFSerasaEnderecosLogr_Sel;
         AV40Serasaenderecoswwds_6_tfserasaenderecosnum = AV19TFSerasaEnderecosNum;
         AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV20TFSerasaEnderecosNum_Sel;
         AV42Serasaenderecoswwds_8_tfserasaenderecoscompl = AV21TFSerasaEnderecosCompl;
         AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV22TFSerasaEnderecosCompl_Sel;
         AV44Serasaenderecoswwds_10_tfserasaenderecosbairro = AV23TFSerasaEnderecosBairro;
         AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV24TFSerasaEnderecosBairro_Sel;
         AV46Serasaenderecoswwds_12_tfserasaenderecoscidade = AV25TFSerasaEnderecosCidade;
         AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV26TFSerasaEnderecosCidade_Sel;
         AV48Serasaenderecoswwds_14_tfserasaenderecosestado = AV27TFSerasaEnderecosEstado;
         AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV28TFSerasaEnderecosEstado_Sel;
         AV50Serasaenderecoswwds_16_tfserasaenderecostelddd = AV29TFSerasaEnderecosTelDDD;
         AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV30TFSerasaEnderecosTelDDD_Sel;
         AV52Serasaenderecoswwds_18_tfserasaenderecostel = AV31TFSerasaEnderecosTel;
         AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV32TFSerasaEnderecosTel_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                              AV36Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                              AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                              AV38Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                              AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                              AV40Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                              AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                              AV42Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                              AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                              AV44Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                              AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                              AV46Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                              AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                              AV48Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                              AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                              AV50Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                              AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                              AV52Serasaenderecoswwds_18_tfserasaenderecostel ,
                                              A723SerasaEnderecosCEP ,
                                              A717SerasaEnderecosLogr ,
                                              A718SerasaEnderecosNum ,
                                              A719SerasaEnderecosCompl ,
                                              A720SerasaEnderecosBairro ,
                                              A721SerasaEnderecosCidade ,
                                              A722SerasaEnderecosEstado ,
                                              A724SerasaEnderecosTelDDD ,
                                              A725SerasaEnderecosTel ,
                                              AV12OrderedBy ,
                                              AV13OrderedDsc ,
                                              A662SerasaId ,
                                              AV35Serasaenderecoswwds_1_serasaid } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV36Serasaenderecoswwds_2_tfserasaenderecoscep = StringUtil.Concat( StringUtil.RTrim( AV36Serasaenderecoswwds_2_tfserasaenderecoscep), "%", "");
         lV38Serasaenderecoswwds_4_tfserasaenderecoslogr = StringUtil.Concat( StringUtil.RTrim( AV38Serasaenderecoswwds_4_tfserasaenderecoslogr), "%", "");
         lV40Serasaenderecoswwds_6_tfserasaenderecosnum = StringUtil.Concat( StringUtil.RTrim( AV40Serasaenderecoswwds_6_tfserasaenderecosnum), "%", "");
         lV42Serasaenderecoswwds_8_tfserasaenderecoscompl = StringUtil.Concat( StringUtil.RTrim( AV42Serasaenderecoswwds_8_tfserasaenderecoscompl), "%", "");
         lV44Serasaenderecoswwds_10_tfserasaenderecosbairro = StringUtil.Concat( StringUtil.RTrim( AV44Serasaenderecoswwds_10_tfserasaenderecosbairro), "%", "");
         lV46Serasaenderecoswwds_12_tfserasaenderecoscidade = StringUtil.Concat( StringUtil.RTrim( AV46Serasaenderecoswwds_12_tfserasaenderecoscidade), "%", "");
         lV48Serasaenderecoswwds_14_tfserasaenderecosestado = StringUtil.Concat( StringUtil.RTrim( AV48Serasaenderecoswwds_14_tfserasaenderecosestado), "%", "");
         lV50Serasaenderecoswwds_16_tfserasaenderecostelddd = StringUtil.Concat( StringUtil.RTrim( AV50Serasaenderecoswwds_16_tfserasaenderecostelddd), "%", "");
         lV52Serasaenderecoswwds_18_tfserasaenderecostel = StringUtil.Concat( StringUtil.RTrim( AV52Serasaenderecoswwds_18_tfserasaenderecostel), "%", "");
         /* Using cursor H00893 */
         pr_default.execute(1, new Object[] {AV35Serasaenderecoswwds_1_serasaid, lV36Serasaenderecoswwds_2_tfserasaenderecoscep, AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel, lV38Serasaenderecoswwds_4_tfserasaenderecoslogr, AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, lV40Serasaenderecoswwds_6_tfserasaenderecosnum, AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel, lV42Serasaenderecoswwds_8_tfserasaenderecoscompl, AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, lV44Serasaenderecoswwds_10_tfserasaenderecosbairro, AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, lV46Serasaenderecoswwds_12_tfserasaenderecoscidade, AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, lV48Serasaenderecoswwds_14_tfserasaenderecosestado, AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel, lV50Serasaenderecoswwds_16_tfserasaenderecostelddd, AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, lV52Serasaenderecoswwds_18_tfserasaenderecostel, AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel});
         GRID_nRecordCount = H00893_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV35Serasaenderecoswwds_1_serasaid = AV34SerasaId;
         AV36Serasaenderecoswwds_2_tfserasaenderecoscep = AV15TFSerasaEnderecosCEP;
         AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV16TFSerasaEnderecosCEP_Sel;
         AV38Serasaenderecoswwds_4_tfserasaenderecoslogr = AV17TFSerasaEnderecosLogr;
         AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV18TFSerasaEnderecosLogr_Sel;
         AV40Serasaenderecoswwds_6_tfserasaenderecosnum = AV19TFSerasaEnderecosNum;
         AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV20TFSerasaEnderecosNum_Sel;
         AV42Serasaenderecoswwds_8_tfserasaenderecoscompl = AV21TFSerasaEnderecosCompl;
         AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV22TFSerasaEnderecosCompl_Sel;
         AV44Serasaenderecoswwds_10_tfserasaenderecosbairro = AV23TFSerasaEnderecosBairro;
         AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV24TFSerasaEnderecosBairro_Sel;
         AV46Serasaenderecoswwds_12_tfserasaenderecoscidade = AV25TFSerasaEnderecosCidade;
         AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV26TFSerasaEnderecosCidade_Sel;
         AV48Serasaenderecoswwds_14_tfserasaenderecosestado = AV27TFSerasaEnderecosEstado;
         AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV28TFSerasaEnderecosEstado_Sel;
         AV50Serasaenderecoswwds_16_tfserasaenderecostelddd = AV29TFSerasaEnderecosTelDDD;
         AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV30TFSerasaEnderecosTelDDD_Sel;
         AV52Serasaenderecoswwds_18_tfserasaenderecostel = AV31TFSerasaEnderecosTel;
         AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV32TFSerasaEnderecosTel_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV34SerasaId, AV15TFSerasaEnderecosCEP, AV16TFSerasaEnderecosCEP_Sel, AV17TFSerasaEnderecosLogr, AV18TFSerasaEnderecosLogr_Sel, AV19TFSerasaEnderecosNum, AV20TFSerasaEnderecosNum_Sel, AV21TFSerasaEnderecosCompl, AV22TFSerasaEnderecosCompl_Sel, AV23TFSerasaEnderecosBairro, AV24TFSerasaEnderecosBairro_Sel, AV25TFSerasaEnderecosCidade, AV26TFSerasaEnderecosCidade_Sel, AV27TFSerasaEnderecosEstado, AV28TFSerasaEnderecosEstado_Sel, AV29TFSerasaEnderecosTelDDD, AV30TFSerasaEnderecosTelDDD_Sel, AV31TFSerasaEnderecosTel, AV32TFSerasaEnderecosTel_Sel, AV54Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV35Serasaenderecoswwds_1_serasaid = AV34SerasaId;
         AV36Serasaenderecoswwds_2_tfserasaenderecoscep = AV15TFSerasaEnderecosCEP;
         AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV16TFSerasaEnderecosCEP_Sel;
         AV38Serasaenderecoswwds_4_tfserasaenderecoslogr = AV17TFSerasaEnderecosLogr;
         AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV18TFSerasaEnderecosLogr_Sel;
         AV40Serasaenderecoswwds_6_tfserasaenderecosnum = AV19TFSerasaEnderecosNum;
         AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV20TFSerasaEnderecosNum_Sel;
         AV42Serasaenderecoswwds_8_tfserasaenderecoscompl = AV21TFSerasaEnderecosCompl;
         AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV22TFSerasaEnderecosCompl_Sel;
         AV44Serasaenderecoswwds_10_tfserasaenderecosbairro = AV23TFSerasaEnderecosBairro;
         AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV24TFSerasaEnderecosBairro_Sel;
         AV46Serasaenderecoswwds_12_tfserasaenderecoscidade = AV25TFSerasaEnderecosCidade;
         AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV26TFSerasaEnderecosCidade_Sel;
         AV48Serasaenderecoswwds_14_tfserasaenderecosestado = AV27TFSerasaEnderecosEstado;
         AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV28TFSerasaEnderecosEstado_Sel;
         AV50Serasaenderecoswwds_16_tfserasaenderecostelddd = AV29TFSerasaEnderecosTelDDD;
         AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV30TFSerasaEnderecosTelDDD_Sel;
         AV52Serasaenderecoswwds_18_tfserasaenderecostel = AV31TFSerasaEnderecosTel;
         AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV32TFSerasaEnderecosTel_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV34SerasaId, AV15TFSerasaEnderecosCEP, AV16TFSerasaEnderecosCEP_Sel, AV17TFSerasaEnderecosLogr, AV18TFSerasaEnderecosLogr_Sel, AV19TFSerasaEnderecosNum, AV20TFSerasaEnderecosNum_Sel, AV21TFSerasaEnderecosCompl, AV22TFSerasaEnderecosCompl_Sel, AV23TFSerasaEnderecosBairro, AV24TFSerasaEnderecosBairro_Sel, AV25TFSerasaEnderecosCidade, AV26TFSerasaEnderecosCidade_Sel, AV27TFSerasaEnderecosEstado, AV28TFSerasaEnderecosEstado_Sel, AV29TFSerasaEnderecosTelDDD, AV30TFSerasaEnderecosTelDDD_Sel, AV31TFSerasaEnderecosTel, AV32TFSerasaEnderecosTel_Sel, AV54Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV35Serasaenderecoswwds_1_serasaid = AV34SerasaId;
         AV36Serasaenderecoswwds_2_tfserasaenderecoscep = AV15TFSerasaEnderecosCEP;
         AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV16TFSerasaEnderecosCEP_Sel;
         AV38Serasaenderecoswwds_4_tfserasaenderecoslogr = AV17TFSerasaEnderecosLogr;
         AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV18TFSerasaEnderecosLogr_Sel;
         AV40Serasaenderecoswwds_6_tfserasaenderecosnum = AV19TFSerasaEnderecosNum;
         AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV20TFSerasaEnderecosNum_Sel;
         AV42Serasaenderecoswwds_8_tfserasaenderecoscompl = AV21TFSerasaEnderecosCompl;
         AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV22TFSerasaEnderecosCompl_Sel;
         AV44Serasaenderecoswwds_10_tfserasaenderecosbairro = AV23TFSerasaEnderecosBairro;
         AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV24TFSerasaEnderecosBairro_Sel;
         AV46Serasaenderecoswwds_12_tfserasaenderecoscidade = AV25TFSerasaEnderecosCidade;
         AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV26TFSerasaEnderecosCidade_Sel;
         AV48Serasaenderecoswwds_14_tfserasaenderecosestado = AV27TFSerasaEnderecosEstado;
         AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV28TFSerasaEnderecosEstado_Sel;
         AV50Serasaenderecoswwds_16_tfserasaenderecostelddd = AV29TFSerasaEnderecosTelDDD;
         AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV30TFSerasaEnderecosTelDDD_Sel;
         AV52Serasaenderecoswwds_18_tfserasaenderecostel = AV31TFSerasaEnderecosTel;
         AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV32TFSerasaEnderecosTel_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV34SerasaId, AV15TFSerasaEnderecosCEP, AV16TFSerasaEnderecosCEP_Sel, AV17TFSerasaEnderecosLogr, AV18TFSerasaEnderecosLogr_Sel, AV19TFSerasaEnderecosNum, AV20TFSerasaEnderecosNum_Sel, AV21TFSerasaEnderecosCompl, AV22TFSerasaEnderecosCompl_Sel, AV23TFSerasaEnderecosBairro, AV24TFSerasaEnderecosBairro_Sel, AV25TFSerasaEnderecosCidade, AV26TFSerasaEnderecosCidade_Sel, AV27TFSerasaEnderecosEstado, AV28TFSerasaEnderecosEstado_Sel, AV29TFSerasaEnderecosTelDDD, AV30TFSerasaEnderecosTelDDD_Sel, AV31TFSerasaEnderecosTel, AV32TFSerasaEnderecosTel_Sel, AV54Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV35Serasaenderecoswwds_1_serasaid = AV34SerasaId;
         AV36Serasaenderecoswwds_2_tfserasaenderecoscep = AV15TFSerasaEnderecosCEP;
         AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV16TFSerasaEnderecosCEP_Sel;
         AV38Serasaenderecoswwds_4_tfserasaenderecoslogr = AV17TFSerasaEnderecosLogr;
         AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV18TFSerasaEnderecosLogr_Sel;
         AV40Serasaenderecoswwds_6_tfserasaenderecosnum = AV19TFSerasaEnderecosNum;
         AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV20TFSerasaEnderecosNum_Sel;
         AV42Serasaenderecoswwds_8_tfserasaenderecoscompl = AV21TFSerasaEnderecosCompl;
         AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV22TFSerasaEnderecosCompl_Sel;
         AV44Serasaenderecoswwds_10_tfserasaenderecosbairro = AV23TFSerasaEnderecosBairro;
         AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV24TFSerasaEnderecosBairro_Sel;
         AV46Serasaenderecoswwds_12_tfserasaenderecoscidade = AV25TFSerasaEnderecosCidade;
         AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV26TFSerasaEnderecosCidade_Sel;
         AV48Serasaenderecoswwds_14_tfserasaenderecosestado = AV27TFSerasaEnderecosEstado;
         AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV28TFSerasaEnderecosEstado_Sel;
         AV50Serasaenderecoswwds_16_tfserasaenderecostelddd = AV29TFSerasaEnderecosTelDDD;
         AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV30TFSerasaEnderecosTelDDD_Sel;
         AV52Serasaenderecoswwds_18_tfserasaenderecostel = AV31TFSerasaEnderecosTel;
         AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV32TFSerasaEnderecosTel_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV34SerasaId, AV15TFSerasaEnderecosCEP, AV16TFSerasaEnderecosCEP_Sel, AV17TFSerasaEnderecosLogr, AV18TFSerasaEnderecosLogr_Sel, AV19TFSerasaEnderecosNum, AV20TFSerasaEnderecosNum_Sel, AV21TFSerasaEnderecosCompl, AV22TFSerasaEnderecosCompl_Sel, AV23TFSerasaEnderecosBairro, AV24TFSerasaEnderecosBairro_Sel, AV25TFSerasaEnderecosCidade, AV26TFSerasaEnderecosCidade_Sel, AV27TFSerasaEnderecosEstado, AV28TFSerasaEnderecosEstado_Sel, AV29TFSerasaEnderecosTelDDD, AV30TFSerasaEnderecosTelDDD_Sel, AV31TFSerasaEnderecosTel, AV32TFSerasaEnderecosTel_Sel, AV54Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV35Serasaenderecoswwds_1_serasaid = AV34SerasaId;
         AV36Serasaenderecoswwds_2_tfserasaenderecoscep = AV15TFSerasaEnderecosCEP;
         AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV16TFSerasaEnderecosCEP_Sel;
         AV38Serasaenderecoswwds_4_tfserasaenderecoslogr = AV17TFSerasaEnderecosLogr;
         AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV18TFSerasaEnderecosLogr_Sel;
         AV40Serasaenderecoswwds_6_tfserasaenderecosnum = AV19TFSerasaEnderecosNum;
         AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV20TFSerasaEnderecosNum_Sel;
         AV42Serasaenderecoswwds_8_tfserasaenderecoscompl = AV21TFSerasaEnderecosCompl;
         AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV22TFSerasaEnderecosCompl_Sel;
         AV44Serasaenderecoswwds_10_tfserasaenderecosbairro = AV23TFSerasaEnderecosBairro;
         AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV24TFSerasaEnderecosBairro_Sel;
         AV46Serasaenderecoswwds_12_tfserasaenderecoscidade = AV25TFSerasaEnderecosCidade;
         AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV26TFSerasaEnderecosCidade_Sel;
         AV48Serasaenderecoswwds_14_tfserasaenderecosestado = AV27TFSerasaEnderecosEstado;
         AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV28TFSerasaEnderecosEstado_Sel;
         AV50Serasaenderecoswwds_16_tfserasaenderecostelddd = AV29TFSerasaEnderecosTelDDD;
         AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV30TFSerasaEnderecosTelDDD_Sel;
         AV52Serasaenderecoswwds_18_tfserasaenderecostel = AV31TFSerasaEnderecosTel;
         AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV32TFSerasaEnderecosTel_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV12OrderedBy, AV13OrderedDsc, AV34SerasaId, AV15TFSerasaEnderecosCEP, AV16TFSerasaEnderecosCEP_Sel, AV17TFSerasaEnderecosLogr, AV18TFSerasaEnderecosLogr_Sel, AV19TFSerasaEnderecosNum, AV20TFSerasaEnderecosNum_Sel, AV21TFSerasaEnderecosCompl, AV22TFSerasaEnderecosCompl_Sel, AV23TFSerasaEnderecosBairro, AV24TFSerasaEnderecosBairro_Sel, AV25TFSerasaEnderecosCidade, AV26TFSerasaEnderecosCidade_Sel, AV27TFSerasaEnderecosEstado, AV28TFSerasaEnderecosEstado_Sel, AV29TFSerasaEnderecosTelDDD, AV30TFSerasaEnderecosTelDDD_Sel, AV31TFSerasaEnderecosTel, AV32TFSerasaEnderecosTel_Sel, AV54Pgmname, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV54Pgmname = "SerasaEnderecosWW";
         edtSerasaEnderecosId_Enabled = 0;
         edtSerasaId_Enabled = 0;
         edtSerasaEnderecosCEP_Enabled = 0;
         edtSerasaEnderecosLogr_Enabled = 0;
         edtSerasaEnderecosNum_Enabled = 0;
         edtSerasaEnderecosCompl_Enabled = 0;
         edtSerasaEnderecosBairro_Enabled = 0;
         edtSerasaEnderecosCidade_Enabled = 0;
         edtSerasaEnderecosEstado_Enabled = 0;
         edtSerasaEnderecosTelDDD_Enabled = 0;
         edtSerasaEnderecosTel_Enabled = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP890( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E12892 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vDDO_TITLESETTINGSICONS"), AV33DDO_TitleSettingsIcons);
            /* Read saved values. */
            nRC_GXsfl_12 = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_12"), ",", "."), 18, MidpointRounding.ToEven));
            wcpOAV34SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV34SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Caption = cgiGet( sPrefix+"DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( sPrefix+"DDO_GRID_Filteredtext_set");
            Ddo_grid_Selectedvalue_set = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gridinternalname = cgiGet( sPrefix+"DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( sPrefix+"DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( sPrefix+"DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( sPrefix+"DDO_GRID_Includesortasc");
            Ddo_grid_Sortedstatus = cgiGet( sPrefix+"DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( sPrefix+"DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( sPrefix+"DDO_GRID_Filtertype");
            Ddo_grid_Includedatalist = cgiGet( sPrefix+"DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( sPrefix+"DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( sPrefix+"DDO_GRID_Datalistproc");
            Grid_empowerer_Gridinternalname = cgiGet( sPrefix+"GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( sPrefix+"GRID_EMPOWERER_Hastitlesettings"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_grid_Activeeventkey = cgiGet( sPrefix+"DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( sPrefix+"DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtext_get = cgiGet( sPrefix+"DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( sPrefix+"DDO_GRID_Selectedcolumn");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( sPrefix+"GXH_vORDEREDBY"), ",", ".") != Convert.ToDecimal( AV12OrderedBy )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( sPrefix+"GXH_vORDEREDDSC")) != AV13OrderedDsc )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E12892 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E12892( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, sPrefix, false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV12OrderedBy < 1 )
         {
            AV12OrderedBy = 1;
            AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV33DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV33DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
      }

      protected void E13892( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV35Serasaenderecoswwds_1_serasaid = AV34SerasaId;
         AV36Serasaenderecoswwds_2_tfserasaenderecoscep = AV15TFSerasaEnderecosCEP;
         AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel = AV16TFSerasaEnderecosCEP_Sel;
         AV38Serasaenderecoswwds_4_tfserasaenderecoslogr = AV17TFSerasaEnderecosLogr;
         AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = AV18TFSerasaEnderecosLogr_Sel;
         AV40Serasaenderecoswwds_6_tfserasaenderecosnum = AV19TFSerasaEnderecosNum;
         AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel = AV20TFSerasaEnderecosNum_Sel;
         AV42Serasaenderecoswwds_8_tfserasaenderecoscompl = AV21TFSerasaEnderecosCompl;
         AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = AV22TFSerasaEnderecosCompl_Sel;
         AV44Serasaenderecoswwds_10_tfserasaenderecosbairro = AV23TFSerasaEnderecosBairro;
         AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = AV24TFSerasaEnderecosBairro_Sel;
         AV46Serasaenderecoswwds_12_tfserasaenderecoscidade = AV25TFSerasaEnderecosCidade;
         AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = AV26TFSerasaEnderecosCidade_Sel;
         AV48Serasaenderecoswwds_14_tfserasaenderecosestado = AV27TFSerasaEnderecosEstado;
         AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel = AV28TFSerasaEnderecosEstado_Sel;
         AV50Serasaenderecoswwds_16_tfserasaenderecostelddd = AV29TFSerasaEnderecosTelDDD;
         AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = AV30TFSerasaEnderecosTelDDD_Sel;
         AV52Serasaenderecoswwds_18_tfserasaenderecostel = AV31TFSerasaEnderecosTel;
         AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel = AV32TFSerasaEnderecosTel_Sel;
      }

      protected void E11892( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV12OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
            AV13OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S132 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaEnderecosCEP") == 0 )
            {
               AV15TFSerasaEnderecosCEP = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV15TFSerasaEnderecosCEP", AV15TFSerasaEnderecosCEP);
               AV16TFSerasaEnderecosCEP_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV16TFSerasaEnderecosCEP_Sel", AV16TFSerasaEnderecosCEP_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaEnderecosLogr") == 0 )
            {
               AV17TFSerasaEnderecosLogr = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV17TFSerasaEnderecosLogr", AV17TFSerasaEnderecosLogr);
               AV18TFSerasaEnderecosLogr_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV18TFSerasaEnderecosLogr_Sel", AV18TFSerasaEnderecosLogr_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaEnderecosNum") == 0 )
            {
               AV19TFSerasaEnderecosNum = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV19TFSerasaEnderecosNum", AV19TFSerasaEnderecosNum);
               AV20TFSerasaEnderecosNum_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV20TFSerasaEnderecosNum_Sel", AV20TFSerasaEnderecosNum_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaEnderecosCompl") == 0 )
            {
               AV21TFSerasaEnderecosCompl = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV21TFSerasaEnderecosCompl", AV21TFSerasaEnderecosCompl);
               AV22TFSerasaEnderecosCompl_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV22TFSerasaEnderecosCompl_Sel", AV22TFSerasaEnderecosCompl_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaEnderecosBairro") == 0 )
            {
               AV23TFSerasaEnderecosBairro = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV23TFSerasaEnderecosBairro", AV23TFSerasaEnderecosBairro);
               AV24TFSerasaEnderecosBairro_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV24TFSerasaEnderecosBairro_Sel", AV24TFSerasaEnderecosBairro_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaEnderecosCidade") == 0 )
            {
               AV25TFSerasaEnderecosCidade = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV25TFSerasaEnderecosCidade", AV25TFSerasaEnderecosCidade);
               AV26TFSerasaEnderecosCidade_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV26TFSerasaEnderecosCidade_Sel", AV26TFSerasaEnderecosCidade_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaEnderecosEstado") == 0 )
            {
               AV27TFSerasaEnderecosEstado = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV27TFSerasaEnderecosEstado", AV27TFSerasaEnderecosEstado);
               AV28TFSerasaEnderecosEstado_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV28TFSerasaEnderecosEstado_Sel", AV28TFSerasaEnderecosEstado_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaEnderecosTelDDD") == 0 )
            {
               AV29TFSerasaEnderecosTelDDD = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV29TFSerasaEnderecosTelDDD", AV29TFSerasaEnderecosTelDDD);
               AV30TFSerasaEnderecosTelDDD_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV30TFSerasaEnderecosTelDDD_Sel", AV30TFSerasaEnderecosTelDDD_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "SerasaEnderecosTel") == 0 )
            {
               AV31TFSerasaEnderecosTel = Ddo_grid_Filteredtext_get;
               AssignAttri(sPrefix, false, "AV31TFSerasaEnderecosTel", AV31TFSerasaEnderecosTel);
               AV32TFSerasaEnderecosTel_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri(sPrefix, false, "AV32TFSerasaEnderecosTel_Sel", AV32TFSerasaEnderecosTel_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E14892( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "serasaenderecos"+UrlEncode(StringUtil.RTrim("DSP")) + "," + UrlEncode(StringUtil.LTrimStr(A716SerasaEnderecosId,9,0));
         edtSerasaEnderecosLogr_Link = formatLink("serasaenderecos") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 12;
         }
         sendrow_122( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_12_Refreshing )
         {
            DoAjaxLoad(12, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void S132( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV12OrderedBy), 4, 0))+":"+(AV13OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV14Session.Get(AV54Pgmname+"GridState"), "") == 0 )
         {
            AV10GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV54Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV10GridState.FromXml(AV14Session.Get(AV54Pgmname+"GridState"), null, "", "");
         }
         AV12OrderedBy = AV10GridState.gxTpr_Orderedby;
         AssignAttri(sPrefix, false, "AV12OrderedBy", StringUtil.LTrimStr( (decimal)(AV12OrderedBy), 4, 0));
         AV13OrderedDsc = AV10GridState.gxTpr_Ordereddsc;
         AssignAttri(sPrefix, false, "AV13OrderedDsc", AV13OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV10GridState.gxTpr_Filtervalues.Count )
         {
            AV11GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV10GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSCEP") == 0 )
            {
               AV15TFSerasaEnderecosCEP = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV15TFSerasaEnderecosCEP", AV15TFSerasaEnderecosCEP);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSCEP_SEL") == 0 )
            {
               AV16TFSerasaEnderecosCEP_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV16TFSerasaEnderecosCEP_Sel", AV16TFSerasaEnderecosCEP_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSLOGR") == 0 )
            {
               AV17TFSerasaEnderecosLogr = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV17TFSerasaEnderecosLogr", AV17TFSerasaEnderecosLogr);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSLOGR_SEL") == 0 )
            {
               AV18TFSerasaEnderecosLogr_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV18TFSerasaEnderecosLogr_Sel", AV18TFSerasaEnderecosLogr_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSNUM") == 0 )
            {
               AV19TFSerasaEnderecosNum = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV19TFSerasaEnderecosNum", AV19TFSerasaEnderecosNum);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSNUM_SEL") == 0 )
            {
               AV20TFSerasaEnderecosNum_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV20TFSerasaEnderecosNum_Sel", AV20TFSerasaEnderecosNum_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSCOMPL") == 0 )
            {
               AV21TFSerasaEnderecosCompl = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV21TFSerasaEnderecosCompl", AV21TFSerasaEnderecosCompl);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSCOMPL_SEL") == 0 )
            {
               AV22TFSerasaEnderecosCompl_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV22TFSerasaEnderecosCompl_Sel", AV22TFSerasaEnderecosCompl_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSBAIRRO") == 0 )
            {
               AV23TFSerasaEnderecosBairro = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV23TFSerasaEnderecosBairro", AV23TFSerasaEnderecosBairro);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSBAIRRO_SEL") == 0 )
            {
               AV24TFSerasaEnderecosBairro_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV24TFSerasaEnderecosBairro_Sel", AV24TFSerasaEnderecosBairro_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSCIDADE") == 0 )
            {
               AV25TFSerasaEnderecosCidade = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV25TFSerasaEnderecosCidade", AV25TFSerasaEnderecosCidade);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSCIDADE_SEL") == 0 )
            {
               AV26TFSerasaEnderecosCidade_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV26TFSerasaEnderecosCidade_Sel", AV26TFSerasaEnderecosCidade_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSESTADO") == 0 )
            {
               AV27TFSerasaEnderecosEstado = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV27TFSerasaEnderecosEstado", AV27TFSerasaEnderecosEstado);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSESTADO_SEL") == 0 )
            {
               AV28TFSerasaEnderecosEstado_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV28TFSerasaEnderecosEstado_Sel", AV28TFSerasaEnderecosEstado_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSTELDDD") == 0 )
            {
               AV29TFSerasaEnderecosTelDDD = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV29TFSerasaEnderecosTelDDD", AV29TFSerasaEnderecosTelDDD);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSTELDDD_SEL") == 0 )
            {
               AV30TFSerasaEnderecosTelDDD_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV30TFSerasaEnderecosTelDDD_Sel", AV30TFSerasaEnderecosTelDDD_Sel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSTEL") == 0 )
            {
               AV31TFSerasaEnderecosTel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV31TFSerasaEnderecosTel", AV31TFSerasaEnderecosTel);
            }
            else if ( StringUtil.StrCmp(AV11GridStateFilterValue.gxTpr_Name, "TFSERASAENDERECOSTEL_SEL") == 0 )
            {
               AV32TFSerasaEnderecosTel_Sel = AV11GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV32TFSerasaEnderecosTel_Sel", AV32TFSerasaEnderecosTel_Sel);
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSerasaEnderecosCEP_Sel)),  AV16TFSerasaEnderecosCEP_Sel, out  GXt_char2) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSerasaEnderecosLogr_Sel)),  AV18TFSerasaEnderecosLogr_Sel, out  GXt_char3) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSerasaEnderecosNum_Sel)),  AV20TFSerasaEnderecosNum_Sel, out  GXt_char4) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSerasaEnderecosCompl_Sel)),  AV22TFSerasaEnderecosCompl_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSerasaEnderecosBairro_Sel)),  AV24TFSerasaEnderecosBairro_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSerasaEnderecosCidade_Sel)),  AV26TFSerasaEnderecosCidade_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSerasaEnderecosEstado_Sel)),  AV28TFSerasaEnderecosEstado_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSerasaEnderecosTelDDD_Sel)),  AV30TFSerasaEnderecosTelDDD_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSerasaEnderecosTel_Sel)),  AV32TFSerasaEnderecosTel_Sel, out  GXt_char10) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char3+"|"+GXt_char4+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"|"+GXt_char9+"|"+GXt_char10;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSerasaEnderecosCEP)),  AV15TFSerasaEnderecosCEP, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSerasaEnderecosLogr)),  AV17TFSerasaEnderecosLogr, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV19TFSerasaEnderecosNum)),  AV19TFSerasaEnderecosNum, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV21TFSerasaEnderecosCompl)),  AV21TFSerasaEnderecosCompl, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSerasaEnderecosBairro)),  AV23TFSerasaEnderecosBairro, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSerasaEnderecosCidade)),  AV25TFSerasaEnderecosCidade, out  GXt_char5) ;
         GXt_char4 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSerasaEnderecosEstado)),  AV27TFSerasaEnderecosEstado, out  GXt_char4) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSerasaEnderecosTelDDD)),  AV29TFSerasaEnderecosTelDDD, out  GXt_char3) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSerasaEnderecosTel)),  AV31TFSerasaEnderecosTel, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char4+"|"+GXt_char3+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, sPrefix, false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV10GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV10GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV10GridState.gxTpr_Currentpage) ;
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV10GridState.FromXml(AV14Session.Get(AV54Pgmname+"GridState"), null, "", "");
         AV10GridState.gxTpr_Orderedby = AV12OrderedBy;
         AV10GridState.gxTpr_Ordereddsc = AV13OrderedDsc;
         AV10GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAENDERECOSCEP",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15TFSerasaEnderecosCEP)),  0,  AV15TFSerasaEnderecosCEP,  AV15TFSerasaEnderecosCEP,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV16TFSerasaEnderecosCEP_Sel)),  AV16TFSerasaEnderecosCEP_Sel,  AV16TFSerasaEnderecosCEP_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAENDERECOSLOGR",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17TFSerasaEnderecosLogr)),  0,  AV17TFSerasaEnderecosLogr,  AV17TFSerasaEnderecosLogr,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV18TFSerasaEnderecosLogr_Sel)),  AV18TFSerasaEnderecosLogr_Sel,  AV18TFSerasaEnderecosLogr_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAENDERECOSNUM",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV19TFSerasaEnderecosNum)),  0,  AV19TFSerasaEnderecosNum,  AV19TFSerasaEnderecosNum,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20TFSerasaEnderecosNum_Sel)),  AV20TFSerasaEnderecosNum_Sel,  AV20TFSerasaEnderecosNum_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAENDERECOSCOMPL",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV21TFSerasaEnderecosCompl)),  0,  AV21TFSerasaEnderecosCompl,  AV21TFSerasaEnderecosCompl,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV22TFSerasaEnderecosCompl_Sel)),  AV22TFSerasaEnderecosCompl_Sel,  AV22TFSerasaEnderecosCompl_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAENDERECOSBAIRRO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV23TFSerasaEnderecosBairro)),  0,  AV23TFSerasaEnderecosBairro,  AV23TFSerasaEnderecosBairro,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV24TFSerasaEnderecosBairro_Sel)),  AV24TFSerasaEnderecosBairro_Sel,  AV24TFSerasaEnderecosBairro_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAENDERECOSCIDADE",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV25TFSerasaEnderecosCidade)),  0,  AV25TFSerasaEnderecosCidade,  AV25TFSerasaEnderecosCidade,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV26TFSerasaEnderecosCidade_Sel)),  AV26TFSerasaEnderecosCidade_Sel,  AV26TFSerasaEnderecosCidade_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAENDERECOSESTADO",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV27TFSerasaEnderecosEstado)),  0,  AV27TFSerasaEnderecosEstado,  AV27TFSerasaEnderecosEstado,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28TFSerasaEnderecosEstado_Sel)),  AV28TFSerasaEnderecosEstado_Sel,  AV28TFSerasaEnderecosEstado_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAENDERECOSTELDDD",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV29TFSerasaEnderecosTelDDD)),  0,  AV29TFSerasaEnderecosTelDDD,  AV29TFSerasaEnderecosTelDDD,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV30TFSerasaEnderecosTelDDD_Sel)),  AV30TFSerasaEnderecosTelDDD_Sel,  AV30TFSerasaEnderecosTelDDD_Sel) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV10GridState,  "TFSERASAENDERECOSTEL",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV31TFSerasaEnderecosTel)),  0,  AV31TFSerasaEnderecosTel,  AV31TFSerasaEnderecosTel,  false,  "",  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV32TFSerasaEnderecosTel_Sel)),  AV32TFSerasaEnderecosTel_Sel,  AV32TFSerasaEnderecosTel_Sel) ;
         if ( ! (0==AV34SerasaId) )
         {
            AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
            AV11GridStateFilterValue.gxTpr_Name = "PARM_&SERASAID";
            AV11GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV34SerasaId), 9, 0);
            AV10GridState.gxTpr_Filtervalues.Add(AV11GridStateFilterValue, 0);
         }
         AV10GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV10GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV54Pgmname+"GridState",  AV10GridState.ToXml(false, true, "", "")) ;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV8TrnContext.gxTpr_Callerobject = AV54Pgmname;
         AV8TrnContext.gxTpr_Callerondelete = true;
         AV8TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV8TrnContext.gxTpr_Transactionname = "SerasaEnderecos";
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV9TrnContextAtt.gxTpr_Attributename = "SerasaId";
         AV9TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV34SerasaId), 9, 0);
         AV8TrnContext.gxTpr_Attributes.Add(AV9TrnContextAtt, 0);
         AV14Session.Set("TrnContext", AV8TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV34SerasaId = Convert.ToInt32(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV34SerasaId", StringUtil.LTrimStr( (decimal)(AV34SerasaId), 9, 0));
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
         PA892( ) ;
         WS892( ) ;
         WE892( ) ;
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
         sCtrlAV34SerasaId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA892( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "serasaenderecosww", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA892( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV34SerasaId = Convert.ToInt32(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV34SerasaId", StringUtil.LTrimStr( (decimal)(AV34SerasaId), 9, 0));
         }
         wcpOAV34SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV34SerasaId"), ",", "."), 18, MidpointRounding.ToEven));
         if ( ! GetJustCreated( ) && ( ( AV34SerasaId != wcpOAV34SerasaId ) ) )
         {
            setjustcreated();
         }
         wcpOAV34SerasaId = AV34SerasaId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV34SerasaId = cgiGet( sPrefix+"AV34SerasaId_CTRL");
         if ( StringUtil.Len( sCtrlAV34SerasaId) > 0 )
         {
            AV34SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sCtrlAV34SerasaId), ",", "."), 18, MidpointRounding.ToEven));
            AssignAttri(sPrefix, false, "AV34SerasaId", StringUtil.LTrimStr( (decimal)(AV34SerasaId), 9, 0));
         }
         else
         {
            AV34SerasaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( sPrefix+"AV34SerasaId_PARM"), ",", "."), 18, MidpointRounding.ToEven));
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
         PA892( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS892( ) ;
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
         WS892( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV34SerasaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34SerasaId), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV34SerasaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV34SerasaId_CTRL", StringUtil.RTrim( sCtrlAV34SerasaId));
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
         WE892( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019203049", true, true);
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
         context.AddJavascriptSource("serasaenderecosww.js", "?202561019203049", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_122( )
      {
         edtSerasaEnderecosId_Internalname = sPrefix+"SERASAENDERECOSID_"+sGXsfl_12_idx;
         edtSerasaId_Internalname = sPrefix+"SERASAID_"+sGXsfl_12_idx;
         edtSerasaEnderecosCEP_Internalname = sPrefix+"SERASAENDERECOSCEP_"+sGXsfl_12_idx;
         edtSerasaEnderecosLogr_Internalname = sPrefix+"SERASAENDERECOSLOGR_"+sGXsfl_12_idx;
         edtSerasaEnderecosNum_Internalname = sPrefix+"SERASAENDERECOSNUM_"+sGXsfl_12_idx;
         edtSerasaEnderecosCompl_Internalname = sPrefix+"SERASAENDERECOSCOMPL_"+sGXsfl_12_idx;
         edtSerasaEnderecosBairro_Internalname = sPrefix+"SERASAENDERECOSBAIRRO_"+sGXsfl_12_idx;
         edtSerasaEnderecosCidade_Internalname = sPrefix+"SERASAENDERECOSCIDADE_"+sGXsfl_12_idx;
         edtSerasaEnderecosEstado_Internalname = sPrefix+"SERASAENDERECOSESTADO_"+sGXsfl_12_idx;
         edtSerasaEnderecosTelDDD_Internalname = sPrefix+"SERASAENDERECOSTELDDD_"+sGXsfl_12_idx;
         edtSerasaEnderecosTel_Internalname = sPrefix+"SERASAENDERECOSTEL_"+sGXsfl_12_idx;
      }

      protected void SubsflControlProps_fel_122( )
      {
         edtSerasaEnderecosId_Internalname = sPrefix+"SERASAENDERECOSID_"+sGXsfl_12_fel_idx;
         edtSerasaId_Internalname = sPrefix+"SERASAID_"+sGXsfl_12_fel_idx;
         edtSerasaEnderecosCEP_Internalname = sPrefix+"SERASAENDERECOSCEP_"+sGXsfl_12_fel_idx;
         edtSerasaEnderecosLogr_Internalname = sPrefix+"SERASAENDERECOSLOGR_"+sGXsfl_12_fel_idx;
         edtSerasaEnderecosNum_Internalname = sPrefix+"SERASAENDERECOSNUM_"+sGXsfl_12_fel_idx;
         edtSerasaEnderecosCompl_Internalname = sPrefix+"SERASAENDERECOSCOMPL_"+sGXsfl_12_fel_idx;
         edtSerasaEnderecosBairro_Internalname = sPrefix+"SERASAENDERECOSBAIRRO_"+sGXsfl_12_fel_idx;
         edtSerasaEnderecosCidade_Internalname = sPrefix+"SERASAENDERECOSCIDADE_"+sGXsfl_12_fel_idx;
         edtSerasaEnderecosEstado_Internalname = sPrefix+"SERASAENDERECOSESTADO_"+sGXsfl_12_fel_idx;
         edtSerasaEnderecosTelDDD_Internalname = sPrefix+"SERASAENDERECOSTELDDD_"+sGXsfl_12_fel_idx;
         edtSerasaEnderecosTel_Internalname = sPrefix+"SERASAENDERECOSTEL_"+sGXsfl_12_fel_idx;
      }

      protected void sendrow_122( )
      {
         sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
         SubsflControlProps_122( ) ;
         WB890( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_12_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_12_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithBorderColor WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_12_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaEnderecosId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A716SerasaEnderecosId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A716SerasaEnderecosId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaEnderecosId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A662SerasaId), "ZZZZZZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaEnderecosCEP_Internalname,(string)A723SerasaEnderecosCEP,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaEnderecosCEP_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaEnderecosLogr_Internalname,(string)A717SerasaEnderecosLogr,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtSerasaEnderecosLogr_Link,(string)"",(string)"",(string)"",(string)edtSerasaEnderecosLogr_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaEnderecosNum_Internalname,(string)A718SerasaEnderecosNum,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaEnderecosNum_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaEnderecosCompl_Internalname,(string)A719SerasaEnderecosCompl,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaEnderecosCompl_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaEnderecosBairro_Internalname,(string)A720SerasaEnderecosBairro,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaEnderecosBairro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaEnderecosCidade_Internalname,(string)A721SerasaEnderecosCidade,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaEnderecosCidade_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaEnderecosEstado_Internalname,(string)A722SerasaEnderecosEstado,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaEnderecosEstado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaEnderecosTelDDD_Internalname,(string)A724SerasaEnderecosTelDDD,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaEnderecosTelDDD_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSerasaEnderecosTel_Internalname,(string)A725SerasaEnderecosTel,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSerasaEnderecosTel_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)12,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes892( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_12_idx = ((subGrid_Islastpage==1)&&(nGXsfl_12_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_12_idx+1);
            sGXsfl_12_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_12_idx), 4, 0), 4, "0");
            SubsflControlProps_122( ) ;
         }
         /* End function sendrow_122 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl12( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"12\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithBorderColor WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Enderecos Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Id") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "CEP") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Logradouro") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Número") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Complemento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Bairro") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cidade") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Estado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "DDD") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Telefone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithBorderColor WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A716SerasaEnderecosId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A662SerasaId), 9, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A723SerasaEnderecosCEP));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A717SerasaEnderecosLogr));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtSerasaEnderecosLogr_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A718SerasaEnderecosNum));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A719SerasaEnderecosCompl));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A720SerasaEnderecosBairro));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A721SerasaEnderecosCidade));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A722SerasaEnderecosEstado));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A724SerasaEnderecosTelDDD));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A725SerasaEnderecosTel));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtSerasaEnderecosId_Internalname = sPrefix+"SERASAENDERECOSID";
         edtSerasaId_Internalname = sPrefix+"SERASAID";
         edtSerasaEnderecosCEP_Internalname = sPrefix+"SERASAENDERECOSCEP";
         edtSerasaEnderecosLogr_Internalname = sPrefix+"SERASAENDERECOSLOGR";
         edtSerasaEnderecosNum_Internalname = sPrefix+"SERASAENDERECOSNUM";
         edtSerasaEnderecosCompl_Internalname = sPrefix+"SERASAENDERECOSCOMPL";
         edtSerasaEnderecosBairro_Internalname = sPrefix+"SERASAENDERECOSBAIRRO";
         edtSerasaEnderecosCidade_Internalname = sPrefix+"SERASAENDERECOSCIDADE";
         edtSerasaEnderecosEstado_Internalname = sPrefix+"SERASAENDERECOSESTADO";
         edtSerasaEnderecosTelDDD_Internalname = sPrefix+"SERASAENDERECOSTELDDD";
         edtSerasaEnderecosTel_Internalname = sPrefix+"SERASAENDERECOSTEL";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         Ddo_grid_Internalname = sPrefix+"DDO_GRID";
         Grid_empowerer_Internalname = sPrefix+"GRID_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = sPrefix+"HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
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
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtSerasaEnderecosTel_Jsonclick = "";
         edtSerasaEnderecosTelDDD_Jsonclick = "";
         edtSerasaEnderecosEstado_Jsonclick = "";
         edtSerasaEnderecosCidade_Jsonclick = "";
         edtSerasaEnderecosBairro_Jsonclick = "";
         edtSerasaEnderecosCompl_Jsonclick = "";
         edtSerasaEnderecosNum_Jsonclick = "";
         edtSerasaEnderecosLogr_Jsonclick = "";
         edtSerasaEnderecosLogr_Link = "";
         edtSerasaEnderecosCEP_Jsonclick = "";
         edtSerasaId_Jsonclick = "";
         edtSerasaEnderecosId_Jsonclick = "";
         subGrid_Class = "GridWithBorderColor WorkWith";
         subGrid_Backcolorstyle = 0;
         edtSerasaEnderecosTel_Enabled = 0;
         edtSerasaEnderecosTelDDD_Enabled = 0;
         edtSerasaEnderecosEstado_Enabled = 0;
         edtSerasaEnderecosCidade_Enabled = 0;
         edtSerasaEnderecosBairro_Enabled = 0;
         edtSerasaEnderecosCompl_Enabled = 0;
         edtSerasaEnderecosNum_Enabled = 0;
         edtSerasaEnderecosLogr_Enabled = 0;
         edtSerasaEnderecosCEP_Enabled = 0;
         edtSerasaId_Enabled = 0;
         edtSerasaEnderecosId_Enabled = 0;
         subGrid_Sortable = 0;
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_grid_Datalistproc = "SerasaEnderecosWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8|9";
         Ddo_grid_Columnids = "2:SerasaEnderecosCEP|3:SerasaEnderecosLogr|4:SerasaEnderecosNum|5:SerasaEnderecosCompl|6:SerasaEnderecosBairro|7:SerasaEnderecosCidade|8:SerasaEnderecosEstado|9:SerasaEnderecosTelDDD|10:SerasaEnderecosTel";
         Ddo_grid_Gridinternalname = "";
         subGrid_Rows = 0;
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
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV34SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaEnderecosCEP","fld":"vTFSERASAENDERECOSCEP","type":"svchar"},{"av":"AV16TFSerasaEnderecosCEP_Sel","fld":"vTFSERASAENDERECOSCEP_SEL","type":"svchar"},{"av":"AV17TFSerasaEnderecosLogr","fld":"vTFSERASAENDERECOSLOGR","type":"svchar"},{"av":"AV18TFSerasaEnderecosLogr_Sel","fld":"vTFSERASAENDERECOSLOGR_SEL","type":"svchar"},{"av":"AV19TFSerasaEnderecosNum","fld":"vTFSERASAENDERECOSNUM","type":"svchar"},{"av":"AV20TFSerasaEnderecosNum_Sel","fld":"vTFSERASAENDERECOSNUM_SEL","type":"svchar"},{"av":"AV21TFSerasaEnderecosCompl","fld":"vTFSERASAENDERECOSCOMPL","type":"svchar"},{"av":"AV22TFSerasaEnderecosCompl_Sel","fld":"vTFSERASAENDERECOSCOMPL_SEL","type":"svchar"},{"av":"AV23TFSerasaEnderecosBairro","fld":"vTFSERASAENDERECOSBAIRRO","type":"svchar"},{"av":"AV24TFSerasaEnderecosBairro_Sel","fld":"vTFSERASAENDERECOSBAIRRO_SEL","type":"svchar"},{"av":"AV25TFSerasaEnderecosCidade","fld":"vTFSERASAENDERECOSCIDADE","type":"svchar"},{"av":"AV26TFSerasaEnderecosCidade_Sel","fld":"vTFSERASAENDERECOSCIDADE_SEL","type":"svchar"},{"av":"AV27TFSerasaEnderecosEstado","fld":"vTFSERASAENDERECOSESTADO","type":"svchar"},{"av":"AV28TFSerasaEnderecosEstado_Sel","fld":"vTFSERASAENDERECOSESTADO_SEL","type":"svchar"},{"av":"AV29TFSerasaEnderecosTelDDD","fld":"vTFSERASAENDERECOSTELDDD","type":"svchar"},{"av":"AV30TFSerasaEnderecosTelDDD_Sel","fld":"vTFSERASAENDERECOSTELDDD_SEL","type":"svchar"},{"av":"AV31TFSerasaEnderecosTel","fld":"vTFSERASAENDERECOSTEL","type":"svchar"},{"av":"AV32TFSerasaEnderecosTel_Sel","fld":"vTFSERASAENDERECOSTEL_SEL","type":"svchar"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV54Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"}]}""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","""{"handler":"E11892","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV34SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaEnderecosCEP","fld":"vTFSERASAENDERECOSCEP","type":"svchar"},{"av":"AV16TFSerasaEnderecosCEP_Sel","fld":"vTFSERASAENDERECOSCEP_SEL","type":"svchar"},{"av":"AV17TFSerasaEnderecosLogr","fld":"vTFSERASAENDERECOSLOGR","type":"svchar"},{"av":"AV18TFSerasaEnderecosLogr_Sel","fld":"vTFSERASAENDERECOSLOGR_SEL","type":"svchar"},{"av":"AV19TFSerasaEnderecosNum","fld":"vTFSERASAENDERECOSNUM","type":"svchar"},{"av":"AV20TFSerasaEnderecosNum_Sel","fld":"vTFSERASAENDERECOSNUM_SEL","type":"svchar"},{"av":"AV21TFSerasaEnderecosCompl","fld":"vTFSERASAENDERECOSCOMPL","type":"svchar"},{"av":"AV22TFSerasaEnderecosCompl_Sel","fld":"vTFSERASAENDERECOSCOMPL_SEL","type":"svchar"},{"av":"AV23TFSerasaEnderecosBairro","fld":"vTFSERASAENDERECOSBAIRRO","type":"svchar"},{"av":"AV24TFSerasaEnderecosBairro_Sel","fld":"vTFSERASAENDERECOSBAIRRO_SEL","type":"svchar"},{"av":"AV25TFSerasaEnderecosCidade","fld":"vTFSERASAENDERECOSCIDADE","type":"svchar"},{"av":"AV26TFSerasaEnderecosCidade_Sel","fld":"vTFSERASAENDERECOSCIDADE_SEL","type":"svchar"},{"av":"AV27TFSerasaEnderecosEstado","fld":"vTFSERASAENDERECOSESTADO","type":"svchar"},{"av":"AV28TFSerasaEnderecosEstado_Sel","fld":"vTFSERASAENDERECOSESTADO_SEL","type":"svchar"},{"av":"AV29TFSerasaEnderecosTelDDD","fld":"vTFSERASAENDERECOSTELDDD","type":"svchar"},{"av":"AV30TFSerasaEnderecosTelDDD_Sel","fld":"vTFSERASAENDERECOSTELDDD_SEL","type":"svchar"},{"av":"AV31TFSerasaEnderecosTel","fld":"vTFSERASAENDERECOSTEL","type":"svchar"},{"av":"AV32TFSerasaEnderecosTel_Sel","fld":"vTFSERASAENDERECOSTEL_SEL","type":"svchar"},{"av":"AV54Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"sPrefix","type":"char"},{"av":"Ddo_grid_Activeeventkey","ctrl":"DDO_GRID","prop":"ActiveEventKey"},{"av":"Ddo_grid_Selectedvalue_get","ctrl":"DDO_GRID","prop":"SelectedValue_get"},{"av":"Ddo_grid_Filteredtext_get","ctrl":"DDO_GRID","prop":"FilteredText_get"},{"av":"Ddo_grid_Selectedcolumn","ctrl":"DDO_GRID","prop":"SelectedColumn"}]""");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",""","oparms":[{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"AV31TFSerasaEnderecosTel","fld":"vTFSERASAENDERECOSTEL","type":"svchar"},{"av":"AV32TFSerasaEnderecosTel_Sel","fld":"vTFSERASAENDERECOSTEL_SEL","type":"svchar"},{"av":"AV29TFSerasaEnderecosTelDDD","fld":"vTFSERASAENDERECOSTELDDD","type":"svchar"},{"av":"AV30TFSerasaEnderecosTelDDD_Sel","fld":"vTFSERASAENDERECOSTELDDD_SEL","type":"svchar"},{"av":"AV27TFSerasaEnderecosEstado","fld":"vTFSERASAENDERECOSESTADO","type":"svchar"},{"av":"AV28TFSerasaEnderecosEstado_Sel","fld":"vTFSERASAENDERECOSESTADO_SEL","type":"svchar"},{"av":"AV25TFSerasaEnderecosCidade","fld":"vTFSERASAENDERECOSCIDADE","type":"svchar"},{"av":"AV26TFSerasaEnderecosCidade_Sel","fld":"vTFSERASAENDERECOSCIDADE_SEL","type":"svchar"},{"av":"AV23TFSerasaEnderecosBairro","fld":"vTFSERASAENDERECOSBAIRRO","type":"svchar"},{"av":"AV24TFSerasaEnderecosBairro_Sel","fld":"vTFSERASAENDERECOSBAIRRO_SEL","type":"svchar"},{"av":"AV21TFSerasaEnderecosCompl","fld":"vTFSERASAENDERECOSCOMPL","type":"svchar"},{"av":"AV22TFSerasaEnderecosCompl_Sel","fld":"vTFSERASAENDERECOSCOMPL_SEL","type":"svchar"},{"av":"AV19TFSerasaEnderecosNum","fld":"vTFSERASAENDERECOSNUM","type":"svchar"},{"av":"AV20TFSerasaEnderecosNum_Sel","fld":"vTFSERASAENDERECOSNUM_SEL","type":"svchar"},{"av":"AV17TFSerasaEnderecosLogr","fld":"vTFSERASAENDERECOSLOGR","type":"svchar"},{"av":"AV18TFSerasaEnderecosLogr_Sel","fld":"vTFSERASAENDERECOSLOGR_SEL","type":"svchar"},{"av":"AV15TFSerasaEnderecosCEP","fld":"vTFSERASAENDERECOSCEP","type":"svchar"},{"av":"AV16TFSerasaEnderecosCEP_Sel","fld":"vTFSERASAENDERECOSCEP_SEL","type":"svchar"},{"av":"Ddo_grid_Sortedstatus","ctrl":"DDO_GRID","prop":"SortedStatus"}]}""");
         setEventMetadata("GRID.LOAD","""{"handler":"E14892","iparms":[{"av":"A716SerasaEnderecosId","fld":"SERASAENDERECOSID","pic":"ZZZZZZZZ9","type":"int"}]""");
         setEventMetadata("GRID.LOAD",""","oparms":[{"av":"edtSerasaEnderecosLogr_Link","ctrl":"SERASAENDERECOSLOGR","prop":"Link"}]}""");
         setEventMetadata("GRID_FIRSTPAGE","""{"handler":"subgrid_firstpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV34SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaEnderecosCEP","fld":"vTFSERASAENDERECOSCEP","type":"svchar"},{"av":"AV16TFSerasaEnderecosCEP_Sel","fld":"vTFSERASAENDERECOSCEP_SEL","type":"svchar"},{"av":"AV17TFSerasaEnderecosLogr","fld":"vTFSERASAENDERECOSLOGR","type":"svchar"},{"av":"AV18TFSerasaEnderecosLogr_Sel","fld":"vTFSERASAENDERECOSLOGR_SEL","type":"svchar"},{"av":"AV19TFSerasaEnderecosNum","fld":"vTFSERASAENDERECOSNUM","type":"svchar"},{"av":"AV20TFSerasaEnderecosNum_Sel","fld":"vTFSERASAENDERECOSNUM_SEL","type":"svchar"},{"av":"AV21TFSerasaEnderecosCompl","fld":"vTFSERASAENDERECOSCOMPL","type":"svchar"},{"av":"AV22TFSerasaEnderecosCompl_Sel","fld":"vTFSERASAENDERECOSCOMPL_SEL","type":"svchar"},{"av":"AV23TFSerasaEnderecosBairro","fld":"vTFSERASAENDERECOSBAIRRO","type":"svchar"},{"av":"AV24TFSerasaEnderecosBairro_Sel","fld":"vTFSERASAENDERECOSBAIRRO_SEL","type":"svchar"},{"av":"AV25TFSerasaEnderecosCidade","fld":"vTFSERASAENDERECOSCIDADE","type":"svchar"},{"av":"AV26TFSerasaEnderecosCidade_Sel","fld":"vTFSERASAENDERECOSCIDADE_SEL","type":"svchar"},{"av":"AV27TFSerasaEnderecosEstado","fld":"vTFSERASAENDERECOSESTADO","type":"svchar"},{"av":"AV28TFSerasaEnderecosEstado_Sel","fld":"vTFSERASAENDERECOSESTADO_SEL","type":"svchar"},{"av":"AV29TFSerasaEnderecosTelDDD","fld":"vTFSERASAENDERECOSTELDDD","type":"svchar"},{"av":"AV30TFSerasaEnderecosTelDDD_Sel","fld":"vTFSERASAENDERECOSTELDDD_SEL","type":"svchar"},{"av":"AV31TFSerasaEnderecosTel","fld":"vTFSERASAENDERECOSTEL","type":"svchar"},{"av":"AV32TFSerasaEnderecosTel_Sel","fld":"vTFSERASAENDERECOSTEL_SEL","type":"svchar"},{"av":"AV54Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_PREVPAGE","""{"handler":"subgrid_previouspage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV34SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaEnderecosCEP","fld":"vTFSERASAENDERECOSCEP","type":"svchar"},{"av":"AV16TFSerasaEnderecosCEP_Sel","fld":"vTFSERASAENDERECOSCEP_SEL","type":"svchar"},{"av":"AV17TFSerasaEnderecosLogr","fld":"vTFSERASAENDERECOSLOGR","type":"svchar"},{"av":"AV18TFSerasaEnderecosLogr_Sel","fld":"vTFSERASAENDERECOSLOGR_SEL","type":"svchar"},{"av":"AV19TFSerasaEnderecosNum","fld":"vTFSERASAENDERECOSNUM","type":"svchar"},{"av":"AV20TFSerasaEnderecosNum_Sel","fld":"vTFSERASAENDERECOSNUM_SEL","type":"svchar"},{"av":"AV21TFSerasaEnderecosCompl","fld":"vTFSERASAENDERECOSCOMPL","type":"svchar"},{"av":"AV22TFSerasaEnderecosCompl_Sel","fld":"vTFSERASAENDERECOSCOMPL_SEL","type":"svchar"},{"av":"AV23TFSerasaEnderecosBairro","fld":"vTFSERASAENDERECOSBAIRRO","type":"svchar"},{"av":"AV24TFSerasaEnderecosBairro_Sel","fld":"vTFSERASAENDERECOSBAIRRO_SEL","type":"svchar"},{"av":"AV25TFSerasaEnderecosCidade","fld":"vTFSERASAENDERECOSCIDADE","type":"svchar"},{"av":"AV26TFSerasaEnderecosCidade_Sel","fld":"vTFSERASAENDERECOSCIDADE_SEL","type":"svchar"},{"av":"AV27TFSerasaEnderecosEstado","fld":"vTFSERASAENDERECOSESTADO","type":"svchar"},{"av":"AV28TFSerasaEnderecosEstado_Sel","fld":"vTFSERASAENDERECOSESTADO_SEL","type":"svchar"},{"av":"AV29TFSerasaEnderecosTelDDD","fld":"vTFSERASAENDERECOSTELDDD","type":"svchar"},{"av":"AV30TFSerasaEnderecosTelDDD_Sel","fld":"vTFSERASAENDERECOSTELDDD_SEL","type":"svchar"},{"av":"AV31TFSerasaEnderecosTel","fld":"vTFSERASAENDERECOSTEL","type":"svchar"},{"av":"AV32TFSerasaEnderecosTel_Sel","fld":"vTFSERASAENDERECOSTEL_SEL","type":"svchar"},{"av":"AV54Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_NEXTPAGE","""{"handler":"subgrid_nextpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV34SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaEnderecosCEP","fld":"vTFSERASAENDERECOSCEP","type":"svchar"},{"av":"AV16TFSerasaEnderecosCEP_Sel","fld":"vTFSERASAENDERECOSCEP_SEL","type":"svchar"},{"av":"AV17TFSerasaEnderecosLogr","fld":"vTFSERASAENDERECOSLOGR","type":"svchar"},{"av":"AV18TFSerasaEnderecosLogr_Sel","fld":"vTFSERASAENDERECOSLOGR_SEL","type":"svchar"},{"av":"AV19TFSerasaEnderecosNum","fld":"vTFSERASAENDERECOSNUM","type":"svchar"},{"av":"AV20TFSerasaEnderecosNum_Sel","fld":"vTFSERASAENDERECOSNUM_SEL","type":"svchar"},{"av":"AV21TFSerasaEnderecosCompl","fld":"vTFSERASAENDERECOSCOMPL","type":"svchar"},{"av":"AV22TFSerasaEnderecosCompl_Sel","fld":"vTFSERASAENDERECOSCOMPL_SEL","type":"svchar"},{"av":"AV23TFSerasaEnderecosBairro","fld":"vTFSERASAENDERECOSBAIRRO","type":"svchar"},{"av":"AV24TFSerasaEnderecosBairro_Sel","fld":"vTFSERASAENDERECOSBAIRRO_SEL","type":"svchar"},{"av":"AV25TFSerasaEnderecosCidade","fld":"vTFSERASAENDERECOSCIDADE","type":"svchar"},{"av":"AV26TFSerasaEnderecosCidade_Sel","fld":"vTFSERASAENDERECOSCIDADE_SEL","type":"svchar"},{"av":"AV27TFSerasaEnderecosEstado","fld":"vTFSERASAENDERECOSESTADO","type":"svchar"},{"av":"AV28TFSerasaEnderecosEstado_Sel","fld":"vTFSERASAENDERECOSESTADO_SEL","type":"svchar"},{"av":"AV29TFSerasaEnderecosTelDDD","fld":"vTFSERASAENDERECOSTELDDD","type":"svchar"},{"av":"AV30TFSerasaEnderecosTelDDD_Sel","fld":"vTFSERASAENDERECOSTELDDD_SEL","type":"svchar"},{"av":"AV31TFSerasaEnderecosTel","fld":"vTFSERASAENDERECOSTEL","type":"svchar"},{"av":"AV32TFSerasaEnderecosTel_Sel","fld":"vTFSERASAENDERECOSTEL_SEL","type":"svchar"},{"av":"AV54Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("GRID_LASTPAGE","""{"handler":"subgrid_lastpage","iparms":[{"av":"GRID_nFirstRecordOnPage","type":"int"},{"av":"GRID_nEOF","type":"int"},{"av":"sPrefix","type":"char"},{"av":"AV34SerasaId","fld":"vSERASAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV15TFSerasaEnderecosCEP","fld":"vTFSERASAENDERECOSCEP","type":"svchar"},{"av":"AV16TFSerasaEnderecosCEP_Sel","fld":"vTFSERASAENDERECOSCEP_SEL","type":"svchar"},{"av":"AV17TFSerasaEnderecosLogr","fld":"vTFSERASAENDERECOSLOGR","type":"svchar"},{"av":"AV18TFSerasaEnderecosLogr_Sel","fld":"vTFSERASAENDERECOSLOGR_SEL","type":"svchar"},{"av":"AV19TFSerasaEnderecosNum","fld":"vTFSERASAENDERECOSNUM","type":"svchar"},{"av":"AV20TFSerasaEnderecosNum_Sel","fld":"vTFSERASAENDERECOSNUM_SEL","type":"svchar"},{"av":"AV21TFSerasaEnderecosCompl","fld":"vTFSERASAENDERECOSCOMPL","type":"svchar"},{"av":"AV22TFSerasaEnderecosCompl_Sel","fld":"vTFSERASAENDERECOSCOMPL_SEL","type":"svchar"},{"av":"AV23TFSerasaEnderecosBairro","fld":"vTFSERASAENDERECOSBAIRRO","type":"svchar"},{"av":"AV24TFSerasaEnderecosBairro_Sel","fld":"vTFSERASAENDERECOSBAIRRO_SEL","type":"svchar"},{"av":"AV25TFSerasaEnderecosCidade","fld":"vTFSERASAENDERECOSCIDADE","type":"svchar"},{"av":"AV26TFSerasaEnderecosCidade_Sel","fld":"vTFSERASAENDERECOSCIDADE_SEL","type":"svchar"},{"av":"AV27TFSerasaEnderecosEstado","fld":"vTFSERASAENDERECOSESTADO","type":"svchar"},{"av":"AV28TFSerasaEnderecosEstado_Sel","fld":"vTFSERASAENDERECOSESTADO_SEL","type":"svchar"},{"av":"AV29TFSerasaEnderecosTelDDD","fld":"vTFSERASAENDERECOSTELDDD","type":"svchar"},{"av":"AV30TFSerasaEnderecosTelDDD_Sel","fld":"vTFSERASAENDERECOSTELDDD_SEL","type":"svchar"},{"av":"AV31TFSerasaEnderecosTel","fld":"vTFSERASAENDERECOSTEL","type":"svchar"},{"av":"AV32TFSerasaEnderecosTel_Sel","fld":"vTFSERASAENDERECOSTEL_SEL","type":"svchar"},{"av":"AV54Pgmname","fld":"vPGMNAME","hsh":true,"type":"char"},{"av":"AV12OrderedBy","fld":"vORDEREDBY","pic":"ZZZ9","type":"int"},{"av":"AV13OrderedDsc","fld":"vORDEREDDSC","type":"boolean"},{"av":"subGrid_Rows","ctrl":"GRID","prop":"Rows"}]}""");
         setEventMetadata("NULL","""{"handler":"Valid_Serasaenderecostel","iparms":[]}""");
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
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV15TFSerasaEnderecosCEP = "";
         AV16TFSerasaEnderecosCEP_Sel = "";
         AV17TFSerasaEnderecosLogr = "";
         AV18TFSerasaEnderecosLogr_Sel = "";
         AV19TFSerasaEnderecosNum = "";
         AV20TFSerasaEnderecosNum_Sel = "";
         AV21TFSerasaEnderecosCompl = "";
         AV22TFSerasaEnderecosCompl_Sel = "";
         AV23TFSerasaEnderecosBairro = "";
         AV24TFSerasaEnderecosBairro_Sel = "";
         AV25TFSerasaEnderecosCidade = "";
         AV26TFSerasaEnderecosCidade_Sel = "";
         AV27TFSerasaEnderecosEstado = "";
         AV28TFSerasaEnderecosEstado_Sel = "";
         AV29TFSerasaEnderecosTelDDD = "";
         AV30TFSerasaEnderecosTelDDD_Sel = "";
         AV31TFSerasaEnderecosTel = "";
         AV32TFSerasaEnderecosTel_Sel = "";
         AV54Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV33DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Sortedstatus = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucDdo_grid = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV36Serasaenderecoswwds_2_tfserasaenderecoscep = "";
         AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel = "";
         AV38Serasaenderecoswwds_4_tfserasaenderecoslogr = "";
         AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel = "";
         AV40Serasaenderecoswwds_6_tfserasaenderecosnum = "";
         AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel = "";
         AV42Serasaenderecoswwds_8_tfserasaenderecoscompl = "";
         AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel = "";
         AV44Serasaenderecoswwds_10_tfserasaenderecosbairro = "";
         AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel = "";
         AV46Serasaenderecoswwds_12_tfserasaenderecoscidade = "";
         AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel = "";
         AV48Serasaenderecoswwds_14_tfserasaenderecosestado = "";
         AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel = "";
         AV50Serasaenderecoswwds_16_tfserasaenderecostelddd = "";
         AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel = "";
         AV52Serasaenderecoswwds_18_tfserasaenderecostel = "";
         AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel = "";
         A723SerasaEnderecosCEP = "";
         A717SerasaEnderecosLogr = "";
         A718SerasaEnderecosNum = "";
         A719SerasaEnderecosCompl = "";
         A720SerasaEnderecosBairro = "";
         A721SerasaEnderecosCidade = "";
         A722SerasaEnderecosEstado = "";
         A724SerasaEnderecosTelDDD = "";
         A725SerasaEnderecosTel = "";
         GXDecQS = "";
         lV36Serasaenderecoswwds_2_tfserasaenderecoscep = "";
         lV38Serasaenderecoswwds_4_tfserasaenderecoslogr = "";
         lV40Serasaenderecoswwds_6_tfserasaenderecosnum = "";
         lV42Serasaenderecoswwds_8_tfserasaenderecoscompl = "";
         lV44Serasaenderecoswwds_10_tfserasaenderecosbairro = "";
         lV46Serasaenderecoswwds_12_tfserasaenderecoscidade = "";
         lV48Serasaenderecoswwds_14_tfserasaenderecosestado = "";
         lV50Serasaenderecoswwds_16_tfserasaenderecostelddd = "";
         lV52Serasaenderecoswwds_18_tfserasaenderecostel = "";
         H00892_A725SerasaEnderecosTel = new string[] {""} ;
         H00892_n725SerasaEnderecosTel = new bool[] {false} ;
         H00892_A724SerasaEnderecosTelDDD = new string[] {""} ;
         H00892_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         H00892_A722SerasaEnderecosEstado = new string[] {""} ;
         H00892_n722SerasaEnderecosEstado = new bool[] {false} ;
         H00892_A721SerasaEnderecosCidade = new string[] {""} ;
         H00892_n721SerasaEnderecosCidade = new bool[] {false} ;
         H00892_A720SerasaEnderecosBairro = new string[] {""} ;
         H00892_n720SerasaEnderecosBairro = new bool[] {false} ;
         H00892_A719SerasaEnderecosCompl = new string[] {""} ;
         H00892_n719SerasaEnderecosCompl = new bool[] {false} ;
         H00892_A718SerasaEnderecosNum = new string[] {""} ;
         H00892_n718SerasaEnderecosNum = new bool[] {false} ;
         H00892_A717SerasaEnderecosLogr = new string[] {""} ;
         H00892_n717SerasaEnderecosLogr = new bool[] {false} ;
         H00892_A723SerasaEnderecosCEP = new string[] {""} ;
         H00892_n723SerasaEnderecosCEP = new bool[] {false} ;
         H00892_A662SerasaId = new int[1] ;
         H00892_n662SerasaId = new bool[] {false} ;
         H00892_A716SerasaEnderecosId = new int[1] ;
         H00893_AGRID_nRecordCount = new long[1] ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GridRow = new GXWebRow();
         AV14Session = context.GetSession();
         AV10GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV11GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char4 = "";
         GXt_char3 = "";
         GXt_char2 = "";
         AV8TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV9TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV34SerasaId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaenderecosww__default(),
            new Object[][] {
                new Object[] {
               H00892_A725SerasaEnderecosTel, H00892_n725SerasaEnderecosTel, H00892_A724SerasaEnderecosTelDDD, H00892_n724SerasaEnderecosTelDDD, H00892_A722SerasaEnderecosEstado, H00892_n722SerasaEnderecosEstado, H00892_A721SerasaEnderecosCidade, H00892_n721SerasaEnderecosCidade, H00892_A720SerasaEnderecosBairro, H00892_n720SerasaEnderecosBairro,
               H00892_A719SerasaEnderecosCompl, H00892_n719SerasaEnderecosCompl, H00892_A718SerasaEnderecosNum, H00892_n718SerasaEnderecosNum, H00892_A717SerasaEnderecosLogr, H00892_n717SerasaEnderecosLogr, H00892_A723SerasaEnderecosCEP, H00892_n723SerasaEnderecosCEP, H00892_A662SerasaId, H00892_n662SerasaId,
               H00892_A716SerasaEnderecosId
               }
               , new Object[] {
               H00893_AGRID_nRecordCount
               }
            }
         );
         AV54Pgmname = "SerasaEnderecosWW";
         /* GeneXus formulas. */
         AV54Pgmname = "SerasaEnderecosWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV12OrderedBy ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int AV34SerasaId ;
      private int wcpOAV34SerasaId ;
      private int subGrid_Rows ;
      private int nRC_GXsfl_12 ;
      private int nGXsfl_12_idx=1 ;
      private int AV35Serasaenderecoswwds_1_serasaid ;
      private int A716SerasaEnderecosId ;
      private int A662SerasaId ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtSerasaEnderecosId_Enabled ;
      private int edtSerasaId_Enabled ;
      private int edtSerasaEnderecosCEP_Enabled ;
      private int edtSerasaEnderecosLogr_Enabled ;
      private int edtSerasaEnderecosNum_Enabled ;
      private int edtSerasaEnderecosCompl_Enabled ;
      private int edtSerasaEnderecosBairro_Enabled ;
      private int edtSerasaEnderecosCidade_Enabled ;
      private int edtSerasaEnderecosEstado_Enabled ;
      private int edtSerasaEnderecosTelDDD_Enabled ;
      private int edtSerasaEnderecosTel_Enabled ;
      private int AV55GXV1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_12_idx="0001" ;
      private string AV54Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtSerasaEnderecosId_Internalname ;
      private string edtSerasaId_Internalname ;
      private string edtSerasaEnderecosCEP_Internalname ;
      private string edtSerasaEnderecosLogr_Internalname ;
      private string edtSerasaEnderecosNum_Internalname ;
      private string edtSerasaEnderecosCompl_Internalname ;
      private string edtSerasaEnderecosBairro_Internalname ;
      private string edtSerasaEnderecosCidade_Internalname ;
      private string edtSerasaEnderecosEstado_Internalname ;
      private string edtSerasaEnderecosTelDDD_Internalname ;
      private string edtSerasaEnderecosTel_Internalname ;
      private string GXDecQS ;
      private string edtSerasaEnderecosLogr_Link ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char4 ;
      private string GXt_char3 ;
      private string GXt_char2 ;
      private string sCtrlAV34SerasaId ;
      private string sGXsfl_12_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtSerasaEnderecosId_Jsonclick ;
      private string edtSerasaId_Jsonclick ;
      private string edtSerasaEnderecosCEP_Jsonclick ;
      private string edtSerasaEnderecosLogr_Jsonclick ;
      private string edtSerasaEnderecosNum_Jsonclick ;
      private string edtSerasaEnderecosCompl_Jsonclick ;
      private string edtSerasaEnderecosBairro_Jsonclick ;
      private string edtSerasaEnderecosCidade_Jsonclick ;
      private string edtSerasaEnderecosEstado_Jsonclick ;
      private string edtSerasaEnderecosTelDDD_Jsonclick ;
      private string edtSerasaEnderecosTel_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13OrderedDsc ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n662SerasaId ;
      private bool n723SerasaEnderecosCEP ;
      private bool n717SerasaEnderecosLogr ;
      private bool n718SerasaEnderecosNum ;
      private bool n719SerasaEnderecosCompl ;
      private bool n720SerasaEnderecosBairro ;
      private bool n721SerasaEnderecosCidade ;
      private bool n722SerasaEnderecosEstado ;
      private bool n724SerasaEnderecosTelDDD ;
      private bool n725SerasaEnderecosTel ;
      private bool bGXsfl_12_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string AV15TFSerasaEnderecosCEP ;
      private string AV16TFSerasaEnderecosCEP_Sel ;
      private string AV17TFSerasaEnderecosLogr ;
      private string AV18TFSerasaEnderecosLogr_Sel ;
      private string AV19TFSerasaEnderecosNum ;
      private string AV20TFSerasaEnderecosNum_Sel ;
      private string AV21TFSerasaEnderecosCompl ;
      private string AV22TFSerasaEnderecosCompl_Sel ;
      private string AV23TFSerasaEnderecosBairro ;
      private string AV24TFSerasaEnderecosBairro_Sel ;
      private string AV25TFSerasaEnderecosCidade ;
      private string AV26TFSerasaEnderecosCidade_Sel ;
      private string AV27TFSerasaEnderecosEstado ;
      private string AV28TFSerasaEnderecosEstado_Sel ;
      private string AV29TFSerasaEnderecosTelDDD ;
      private string AV30TFSerasaEnderecosTelDDD_Sel ;
      private string AV31TFSerasaEnderecosTel ;
      private string AV32TFSerasaEnderecosTel_Sel ;
      private string AV36Serasaenderecoswwds_2_tfserasaenderecoscep ;
      private string AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel ;
      private string AV38Serasaenderecoswwds_4_tfserasaenderecoslogr ;
      private string AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ;
      private string AV40Serasaenderecoswwds_6_tfserasaenderecosnum ;
      private string AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel ;
      private string AV42Serasaenderecoswwds_8_tfserasaenderecoscompl ;
      private string AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ;
      private string AV44Serasaenderecoswwds_10_tfserasaenderecosbairro ;
      private string AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ;
      private string AV46Serasaenderecoswwds_12_tfserasaenderecoscidade ;
      private string AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ;
      private string AV48Serasaenderecoswwds_14_tfserasaenderecosestado ;
      private string AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel ;
      private string AV50Serasaenderecoswwds_16_tfserasaenderecostelddd ;
      private string AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ;
      private string AV52Serasaenderecoswwds_18_tfserasaenderecostel ;
      private string AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel ;
      private string A723SerasaEnderecosCEP ;
      private string A717SerasaEnderecosLogr ;
      private string A718SerasaEnderecosNum ;
      private string A719SerasaEnderecosCompl ;
      private string A720SerasaEnderecosBairro ;
      private string A721SerasaEnderecosCidade ;
      private string A722SerasaEnderecosEstado ;
      private string A724SerasaEnderecosTelDDD ;
      private string A725SerasaEnderecosTel ;
      private string lV36Serasaenderecoswwds_2_tfserasaenderecoscep ;
      private string lV38Serasaenderecoswwds_4_tfserasaenderecoslogr ;
      private string lV40Serasaenderecoswwds_6_tfserasaenderecosnum ;
      private string lV42Serasaenderecoswwds_8_tfserasaenderecoscompl ;
      private string lV44Serasaenderecoswwds_10_tfserasaenderecosbairro ;
      private string lV46Serasaenderecoswwds_12_tfserasaenderecoscidade ;
      private string lV48Serasaenderecoswwds_14_tfserasaenderecosestado ;
      private string lV50Serasaenderecoswwds_16_tfserasaenderecostelddd ;
      private string lV52Serasaenderecoswwds_18_tfserasaenderecostel ;
      private IGxSession AV14Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucGrid_empowerer ;
      private GXWebForm Form ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV33DDO_TitleSettingsIcons ;
      private IDataStoreProvider pr_default ;
      private string[] H00892_A725SerasaEnderecosTel ;
      private bool[] H00892_n725SerasaEnderecosTel ;
      private string[] H00892_A724SerasaEnderecosTelDDD ;
      private bool[] H00892_n724SerasaEnderecosTelDDD ;
      private string[] H00892_A722SerasaEnderecosEstado ;
      private bool[] H00892_n722SerasaEnderecosEstado ;
      private string[] H00892_A721SerasaEnderecosCidade ;
      private bool[] H00892_n721SerasaEnderecosCidade ;
      private string[] H00892_A720SerasaEnderecosBairro ;
      private bool[] H00892_n720SerasaEnderecosBairro ;
      private string[] H00892_A719SerasaEnderecosCompl ;
      private bool[] H00892_n719SerasaEnderecosCompl ;
      private string[] H00892_A718SerasaEnderecosNum ;
      private bool[] H00892_n718SerasaEnderecosNum ;
      private string[] H00892_A717SerasaEnderecosLogr ;
      private bool[] H00892_n717SerasaEnderecosLogr ;
      private string[] H00892_A723SerasaEnderecosCEP ;
      private bool[] H00892_n723SerasaEnderecosCEP ;
      private int[] H00892_A662SerasaId ;
      private bool[] H00892_n662SerasaId ;
      private int[] H00892_A716SerasaEnderecosId ;
      private long[] H00893_AGRID_nRecordCount ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV10GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV11GridStateFilterValue ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV8TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV9TrnContextAtt ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class serasaenderecosww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00892( IGxContext context ,
                                             string AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                             string AV36Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                             string AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                             string AV38Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                             string AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                             string AV40Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                             string AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                             string AV42Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                             string AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                             string AV44Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                             string AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                             string AV46Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                             string AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                             string AV48Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                             string AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                             string AV50Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                             string AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                             string AV52Serasaenderecoswwds_18_tfserasaenderecostel ,
                                             string A723SerasaEnderecosCEP ,
                                             string A717SerasaEnderecosLogr ,
                                             string A718SerasaEnderecosNum ,
                                             string A719SerasaEnderecosCompl ,
                                             string A720SerasaEnderecosBairro ,
                                             string A721SerasaEnderecosCidade ,
                                             string A722SerasaEnderecosEstado ,
                                             string A724SerasaEnderecosTelDDD ,
                                             string A725SerasaEnderecosTel ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A662SerasaId ,
                                             int AV35Serasaenderecoswwds_1_serasaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[22];
         Object[] GXv_Object12 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " SerasaEnderecosTel, SerasaEnderecosTelDDD, SerasaEnderecosEstado, SerasaEnderecosCidade, SerasaEnderecosBairro, SerasaEnderecosCompl, SerasaEnderecosNum, SerasaEnderecosLogr, SerasaEnderecosCEP, SerasaId, SerasaEnderecosId";
         sFromString = " FROM SerasaEnderecos";
         sOrderString = "";
         AddWhere(sWhereString, "(SerasaId = :AV35Serasaenderecoswwds_1_serasaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36Serasaenderecoswwds_2_tfserasaenderecoscep)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP like :lV36Serasaenderecoswwds_2_tfserasaenderecoscep)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ! ( StringUtil.StrCmp(AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP = ( :AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel))");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( StringUtil.StrCmp(AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCEP))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38Serasaenderecoswwds_4_tfserasaenderecoslogr)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr like :lV38Serasaenderecoswwds_4_tfserasaenderecoslogr)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ! ( StringUtil.StrCmp(AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr = ( :AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel))");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( StringUtil.StrCmp(AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosLogr))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Serasaenderecoswwds_6_tfserasaenderecosnum)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum like :lV40Serasaenderecoswwds_6_tfserasaenderecosnum)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ! ( StringUtil.StrCmp(AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum = ( :AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel))");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( StringUtil.StrCmp(AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Serasaenderecoswwds_8_tfserasaenderecoscompl)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl like :lV42Serasaenderecoswwds_8_tfserasaenderecoscompl)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ! ( StringUtil.StrCmp(AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl = ( :AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel))");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( StringUtil.StrCmp(AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCompl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Serasaenderecoswwds_10_tfserasaenderecosbairro)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro like :lV44Serasaenderecoswwds_10_tfserasaenderecosbairro)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ! ( StringUtil.StrCmp(AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro = ( :AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel))");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( StringUtil.StrCmp(AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosBairro))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Serasaenderecoswwds_12_tfserasaenderecoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade like :lV46Serasaenderecoswwds_12_tfserasaenderecoscidade)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ! ( StringUtil.StrCmp(AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade = ( :AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel))");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( StringUtil.StrCmp(AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Serasaenderecoswwds_14_tfserasaenderecosestado)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado like :lV48Serasaenderecoswwds_14_tfserasaenderecosestado)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ! ( StringUtil.StrCmp(AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado = ( :AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel))");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( StringUtil.StrCmp(AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosEstado))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Serasaenderecoswwds_16_tfserasaenderecostelddd)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD like :lV50Serasaenderecoswwds_16_tfserasaenderecostelddd)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ! ( StringUtil.StrCmp(AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD = ( :AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel))");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( StringUtil.StrCmp(AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTelDDD))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Serasaenderecoswwds_18_tfserasaenderecostel)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel like :lV52Serasaenderecoswwds_18_tfserasaenderecostel)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ! ( StringUtil.StrCmp(AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel = ( :AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel))");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( StringUtil.StrCmp(AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTel))=0))");
         }
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaEnderecosCEP, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaEnderecosCEP DESC, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaEnderecosLogr, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaEnderecosLogr DESC, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaEnderecosNum, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaEnderecosNum DESC, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaEnderecosCompl, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaEnderecosCompl DESC, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaEnderecosBairro, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaEnderecosBairro DESC, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaEnderecosCidade, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaEnderecosCidade DESC, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaEnderecosEstado, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaEnderecosEstado DESC, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaEnderecosTelDDD, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaEnderecosTelDDD DESC, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 9 ) && ! AV13OrderedDsc )
         {
            sOrderString += " ORDER BY SerasaId, SerasaEnderecosTel, SerasaEnderecosId";
         }
         else if ( ( AV12OrderedBy == 9 ) && ( AV13OrderedDsc ) )
         {
            sOrderString += " ORDER BY SerasaId DESC, SerasaEnderecosTel DESC, SerasaEnderecosId";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY SerasaEnderecosId";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_H00893( IGxContext context ,
                                             string AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel ,
                                             string AV36Serasaenderecoswwds_2_tfserasaenderecoscep ,
                                             string AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel ,
                                             string AV38Serasaenderecoswwds_4_tfserasaenderecoslogr ,
                                             string AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel ,
                                             string AV40Serasaenderecoswwds_6_tfserasaenderecosnum ,
                                             string AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel ,
                                             string AV42Serasaenderecoswwds_8_tfserasaenderecoscompl ,
                                             string AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel ,
                                             string AV44Serasaenderecoswwds_10_tfserasaenderecosbairro ,
                                             string AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel ,
                                             string AV46Serasaenderecoswwds_12_tfserasaenderecoscidade ,
                                             string AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel ,
                                             string AV48Serasaenderecoswwds_14_tfserasaenderecosestado ,
                                             string AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel ,
                                             string AV50Serasaenderecoswwds_16_tfserasaenderecostelddd ,
                                             string AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel ,
                                             string AV52Serasaenderecoswwds_18_tfserasaenderecostel ,
                                             string A723SerasaEnderecosCEP ,
                                             string A717SerasaEnderecosLogr ,
                                             string A718SerasaEnderecosNum ,
                                             string A719SerasaEnderecosCompl ,
                                             string A720SerasaEnderecosBairro ,
                                             string A721SerasaEnderecosCidade ,
                                             string A722SerasaEnderecosEstado ,
                                             string A724SerasaEnderecosTelDDD ,
                                             string A725SerasaEnderecosTel ,
                                             short AV12OrderedBy ,
                                             bool AV13OrderedDsc ,
                                             int A662SerasaId ,
                                             int AV35Serasaenderecoswwds_1_serasaid )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[19];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM SerasaEnderecos";
         AddWhere(sWhereString, "(SerasaId = :AV35Serasaenderecoswwds_1_serasaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36Serasaenderecoswwds_2_tfserasaenderecoscep)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP like :lV36Serasaenderecoswwds_2_tfserasaenderecoscep)");
         }
         else
         {
            GXv_int13[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel)) && ! ( StringUtil.StrCmp(AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP = ( :AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel))");
         }
         else
         {
            GXv_int13[2] = 1;
         }
         if ( StringUtil.StrCmp(AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCEP IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCEP))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38Serasaenderecoswwds_4_tfserasaenderecoslogr)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr like :lV38Serasaenderecoswwds_4_tfserasaenderecoslogr)");
         }
         else
         {
            GXv_int13[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel)) && ! ( StringUtil.StrCmp(AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr = ( :AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel))");
         }
         else
         {
            GXv_int13[4] = 1;
         }
         if ( StringUtil.StrCmp(AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosLogr IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosLogr))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40Serasaenderecoswwds_6_tfserasaenderecosnum)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum like :lV40Serasaenderecoswwds_6_tfserasaenderecosnum)");
         }
         else
         {
            GXv_int13[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel)) && ! ( StringUtil.StrCmp(AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum = ( :AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel))");
         }
         else
         {
            GXv_int13[6] = 1;
         }
         if ( StringUtil.StrCmp(AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosNum IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42Serasaenderecoswwds_8_tfserasaenderecoscompl)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl like :lV42Serasaenderecoswwds_8_tfserasaenderecoscompl)");
         }
         else
         {
            GXv_int13[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel)) && ! ( StringUtil.StrCmp(AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl = ( :AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel))");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( StringUtil.StrCmp(AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCompl IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCompl))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Serasaenderecoswwds_10_tfserasaenderecosbairro)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro like :lV44Serasaenderecoswwds_10_tfserasaenderecosbairro)");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel)) && ! ( StringUtil.StrCmp(AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro = ( :AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel))");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( StringUtil.StrCmp(AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosBairro IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosBairro))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Serasaenderecoswwds_12_tfserasaenderecoscidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade like :lV46Serasaenderecoswwds_12_tfserasaenderecoscidade)");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel)) && ! ( StringUtil.StrCmp(AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade = ( :AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel))");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( StringUtil.StrCmp(AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosCidade IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Serasaenderecoswwds_14_tfserasaenderecosestado)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado like :lV48Serasaenderecoswwds_14_tfserasaenderecosestado)");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel)) && ! ( StringUtil.StrCmp(AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado = ( :AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel))");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( StringUtil.StrCmp(AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosEstado IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosEstado))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Serasaenderecoswwds_16_tfserasaenderecostelddd)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD like :lV50Serasaenderecoswwds_16_tfserasaenderecostelddd)");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel)) && ! ( StringUtil.StrCmp(AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD = ( :AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel))");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( StringUtil.StrCmp(AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTelDDD IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTelDDD))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Serasaenderecoswwds_18_tfserasaenderecostel)) ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel like :lV52Serasaenderecoswwds_18_tfserasaenderecostel)");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel)) && ! ( StringUtil.StrCmp(AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel = ( :AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel))");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( StringUtil.StrCmp(AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaEnderecosTel IS NULL or (char_length(trim(trailing ' ' from SerasaEnderecosTel))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV12OrderedBy == 1 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 1 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 2 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 2 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 3 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 3 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 4 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 4 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 5 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 5 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 6 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 6 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 7 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 7 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 8 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 8 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 9 ) && ! AV13OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV12OrderedBy == 9 ) && ( AV13OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H00892(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (int)dynConstraints[29] , (int)dynConstraints[30] );
               case 1 :
                     return conditional_H00893(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (int)dynConstraints[29] , (int)dynConstraints[30] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00892;
          prmH00892 = new Object[] {
          new ParDef("AV35Serasaenderecoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("lV36Serasaenderecoswwds_2_tfserasaenderecoscep",GXType.VarChar,40,0) ,
          new ParDef("AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel",GXType.VarChar,40,0) ,
          new ParDef("lV38Serasaenderecoswwds_4_tfserasaenderecoslogr",GXType.VarChar,100,0) ,
          new ParDef("AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel",GXType.VarChar,100,0) ,
          new ParDef("lV40Serasaenderecoswwds_6_tfserasaenderecosnum",GXType.VarChar,40,0) ,
          new ParDef("AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel",GXType.VarChar,40,0) ,
          new ParDef("lV42Serasaenderecoswwds_8_tfserasaenderecoscompl",GXType.VarChar,50,0) ,
          new ParDef("AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel",GXType.VarChar,50,0) ,
          new ParDef("lV44Serasaenderecoswwds_10_tfserasaenderecosbairro",GXType.VarChar,100,0) ,
          new ParDef("AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel",GXType.VarChar,100,0) ,
          new ParDef("lV46Serasaenderecoswwds_12_tfserasaenderecoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV48Serasaenderecoswwds_14_tfserasaenderecosestado",GXType.VarChar,40,0) ,
          new ParDef("AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel",GXType.VarChar,40,0) ,
          new ParDef("lV50Serasaenderecoswwds_16_tfserasaenderecostelddd",GXType.VarChar,40,0) ,
          new ParDef("AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel",GXType.VarChar,40,0) ,
          new ParDef("lV52Serasaenderecoswwds_18_tfserasaenderecostel",GXType.VarChar,40,0) ,
          new ParDef("AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel",GXType.VarChar,40,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00893;
          prmH00893 = new Object[] {
          new ParDef("AV35Serasaenderecoswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("lV36Serasaenderecoswwds_2_tfserasaenderecoscep",GXType.VarChar,40,0) ,
          new ParDef("AV37Serasaenderecoswwds_3_tfserasaenderecoscep_sel",GXType.VarChar,40,0) ,
          new ParDef("lV38Serasaenderecoswwds_4_tfserasaenderecoslogr",GXType.VarChar,100,0) ,
          new ParDef("AV39Serasaenderecoswwds_5_tfserasaenderecoslogr_sel",GXType.VarChar,100,0) ,
          new ParDef("lV40Serasaenderecoswwds_6_tfserasaenderecosnum",GXType.VarChar,40,0) ,
          new ParDef("AV41Serasaenderecoswwds_7_tfserasaenderecosnum_sel",GXType.VarChar,40,0) ,
          new ParDef("lV42Serasaenderecoswwds_8_tfserasaenderecoscompl",GXType.VarChar,50,0) ,
          new ParDef("AV43Serasaenderecoswwds_9_tfserasaenderecoscompl_sel",GXType.VarChar,50,0) ,
          new ParDef("lV44Serasaenderecoswwds_10_tfserasaenderecosbairro",GXType.VarChar,100,0) ,
          new ParDef("AV45Serasaenderecoswwds_11_tfserasaenderecosbairro_sel",GXType.VarChar,100,0) ,
          new ParDef("lV46Serasaenderecoswwds_12_tfserasaenderecoscidade",GXType.VarChar,40,0) ,
          new ParDef("AV47Serasaenderecoswwds_13_tfserasaenderecoscidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV48Serasaenderecoswwds_14_tfserasaenderecosestado",GXType.VarChar,40,0) ,
          new ParDef("AV49Serasaenderecoswwds_15_tfserasaenderecosestado_sel",GXType.VarChar,40,0) ,
          new ParDef("lV50Serasaenderecoswwds_16_tfserasaenderecostelddd",GXType.VarChar,40,0) ,
          new ParDef("AV51Serasaenderecoswwds_17_tfserasaenderecostelddd_sel",GXType.VarChar,40,0) ,
          new ParDef("lV52Serasaenderecoswwds_18_tfserasaenderecostel",GXType.VarChar,40,0) ,
          new ParDef("AV53Serasaenderecoswwds_19_tfserasaenderecostel_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00892", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00892,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00893", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00893,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((int[]) buf[20])[0] = rslt.getInt(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
