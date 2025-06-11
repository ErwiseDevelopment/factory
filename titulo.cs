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
   public class titulo : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"TITULOSEMCARTEIRADECOBRANCA_F") == 0 )
         {
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASATITULOSEMCARTEIRADECOBRANCA_F1544( A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel10"+"_"+"TITULOTOTALMULTAJUROSCREDITO_F") == 0 )
         {
            A283TituloTipo = GetPar( "TituloTipo");
            n283TituloTipo = false;
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX10ASATITULOTOTALMULTAJUROSCREDITO_F1544( A283TituloTipo, A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel11"+"_"+"TITULOTOTALMULTAJUROSDEBITO_F") == 0 )
         {
            A283TituloTipo = GetPar( "TituloTipo");
            n283TituloTipo = false;
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX11ASATITULOTOTALMULTAJUROSDEBITO_F1544( A283TituloTipo, A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel12"+"_"+"TITULOTOTALMOVIMENTOCREDITO_F") == 0 )
         {
            A283TituloTipo = GetPar( "TituloTipo");
            n283TituloTipo = false;
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX12ASATITULOTOTALMOVIMENTOCREDITO_F1544( A283TituloTipo, A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel13"+"_"+"TITULOTOTALMOVIMENTODEBITO_F") == 0 )
         {
            A283TituloTipo = GetPar( "TituloTipo");
            n283TituloTipo = false;
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX13ASATITULOTOTALMOVIMENTODEBITO_F1544( A283TituloTipo, A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_41") == 0 )
         {
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_41( A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_42") == 0 )
         {
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_42( A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_43") == 0 )
         {
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_43( A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_44") == 0 )
         {
            A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_44( A261TituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_32") == 0 )
         {
            A422ContaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContaId"), "."), 18, MidpointRounding.ToEven));
            n422ContaId = false;
            AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_32( A422ContaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_33") == 0 )
         {
            A426CategoriaTituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "CategoriaTituloId"), "."), 18, MidpointRounding.ToEven));
            n426CategoriaTituloId = false;
            AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_33( A426CategoriaTituloId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_34") == 0 )
         {
            A890NotaFiscalParcelamentoID = StringUtil.StrToGuid( GetPar( "NotaFiscalParcelamentoID"));
            n890NotaFiscalParcelamentoID = false;
            AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_34( A890NotaFiscalParcelamentoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_38") == 0 )
         {
            A794NotaFiscalId = StringUtil.StrToGuid( GetPar( "NotaFiscalId"));
            n794NotaFiscalId = false;
            AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_38( A794NotaFiscalId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_35") == 0 )
         {
            A951ContaBancariaId = (int)(Math.Round(NumberUtil.Val( GetPar( "ContaBancariaId"), "."), 18, MidpointRounding.ToEven));
            n951ContaBancariaId = false;
            AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_35( A951ContaBancariaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_39") == 0 )
         {
            A938AgenciaId = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaId"), "."), 18, MidpointRounding.ToEven));
            n938AgenciaId = false;
            AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_39( A938AgenciaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_40") == 0 )
         {
            A968AgenciaBancoId = (int)(Math.Round(NumberUtil.Val( GetPar( "AgenciaBancoId"), "."), 18, MidpointRounding.ToEven));
            n968AgenciaBancoId = false;
            AssignAttri("", false, "A968AgenciaBancoId", StringUtil.LTrimStr( (decimal)(A968AgenciaBancoId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_40( A968AgenciaBancoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_36") == 0 )
         {
            A419TituloPropostaId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloPropostaId"), "."), 18, MidpointRounding.ToEven));
            n419TituloPropostaId = false;
            AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_36( A419TituloPropostaId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_37") == 0 )
         {
            A420TituloClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloClienteId"), "."), 18, MidpointRounding.ToEven));
            n420TituloClienteId = false;
            AssignAttri("", false, "A420TituloClienteId", ((0==A420TituloClienteId)&&IsIns( )||n420TituloClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A420TituloClienteId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_37( A420TituloClienteId) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "titulo")), "titulo") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "titulo")))) ;
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
                  AV7TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7TituloId", StringUtil.LTrimStr( (decimal)(AV7TituloId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TituloId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Titulo", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTituloValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public titulo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public titulo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TituloId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TituloId = aP1_TituloId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTituloTipo = new GXCombobox();
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
         if ( cmbTituloTipo.ItemCount > 0 )
         {
            A283TituloTipo = cmbTituloTipo.getValidValue(A283TituloTipo);
            n283TituloTipo = false;
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTituloTipo.CurrentValue = StringUtil.RTrim( A283TituloTipo);
            AssignProp("", false, cmbTituloTipo_Internalname, "Values", cmbTituloTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloId_Internalname, "Título", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A261TituloId), 9, 0, ",", "")), StringUtil.LTrim( ((edtTituloId_Enabled!=0) ? context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloValor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloValor_Internalname, ((Convert.ToDecimal(0)==A262TituloValor)&&IsIns( )||n262TituloValor ? "" : StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A262TituloValor)&&IsIns( )||n262TituloValor ? "" : StringUtil.LTrim( ((edtTituloValor_Enabled!=0) ? context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A262TituloValor, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloValor_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloDesconto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloDesconto_Internalname, "Desconto", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloDesconto_Internalname, ((Convert.ToDecimal(0)==A276TituloDesconto)&&IsIns( )||n276TituloDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ",", ""))), ((Convert.ToDecimal(0)==A276TituloDesconto)&&IsIns( )||n276TituloDesconto ? "" : StringUtil.LTrim( ((edtTituloDesconto_Enabled!=0) ? context.localUtil.Format( A276TituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A276TituloDesconto, "ZZZ,ZZZ,ZZZ,ZZ9.99")))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloDesconto_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloDesconto_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloProrrogacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloProrrogacao_Internalname, "Vencimento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTituloProrrogacao_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTituloProrrogacao_Internalname, context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"), context.localUtil.Format( A264TituloProrrogacao, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloProrrogacao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloProrrogacao_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Titulo.htm");
         GxWebStd.gx_bitmap( context, edtTituloProrrogacao_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTituloProrrogacao_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Titulo.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloCompetencia_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloCompetencia_F_Internalname, "Competência", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloCompetencia_F_Internalname, A295TituloCompetencia_F, StringUtil.RTrim( context.localUtil.Format( A295TituloCompetencia_F, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloCompetencia_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloCompetencia_F_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloStatus_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloStatus_F_Internalname, "Situação", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloStatus_F_Internalname, A282TituloStatus_F, StringUtil.RTrim( context.localUtil.Format( A282TituloStatus_F, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloStatus_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloStatus_F_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbTituloTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTituloTipo_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTituloTipo, cmbTituloTipo_Internalname, StringUtil.RTrim( A283TituloTipo), 1, cmbTituloTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbTituloTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_Titulo.htm");
         cmbTituloTipo.CurrentValue = StringUtil.RTrim( A283TituloTipo);
         AssignProp("", false, cmbTituloTipo_Internalname, "Values", (string)(cmbTituloTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloSaldo_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloSaldo_F_Internalname, "Saldo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloSaldo_F_Internalname, StringUtil.LTrim( StringUtil.NToC( A275TituloSaldo_F, 18, 2, ",", "")), StringUtil.LTrim( ((edtTituloSaldo_F_Enabled!=0) ? context.localUtil.Format( A275TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A275TituloSaldo_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloSaldo_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloSaldo_F_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloTotalMovimento_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloTotalMovimento_F_Internalname, "Total baixado", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloTotalMovimento_F_Internalname, StringUtil.LTrim( StringUtil.NToC( A273TituloTotalMovimento_F, 18, 2, ",", "")), StringUtil.LTrim( ((edtTituloTotalMovimento_F_Enabled!=0) ? context.localUtil.Format( A273TituloTotalMovimento_F, "ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A273TituloTotalMovimento_F, "ZZZ,ZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloTotalMovimento_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloTotalMovimento_F_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "Valor", "end", false, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Control Group */
         GxWebStd.gx_group_start( context, grpUnnamedgroup1_Internalname, "Endereço", 1, 0, "px", 0, "px", "Group", "", "HLP_Titulo.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableendereco_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloCEP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloCEP_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloCEP_Internalname, A265TituloCEP, StringUtil.RTrim( context.localUtil.Format( A265TituloCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloCEP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloCEP_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-7 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloLogradouro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloLogradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloLogradouro_Internalname, A266TituloLogradouro, StringUtil.RTrim( context.localUtil.Format( A266TituloLogradouro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloLogradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloLogradouro_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-2 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloNumeroEndereco_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloNumeroEndereco_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloNumeroEndereco_Internalname, A294TituloNumeroEndereco, StringUtil.RTrim( context.localUtil.Format( A294TituloNumeroEndereco, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloNumeroEndereco_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloNumeroEndereco_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloComplemento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloComplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloComplemento_Internalname, A267TituloComplemento, StringUtil.RTrim( context.localUtil.Format( A267TituloComplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloComplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloComplemento_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloBairro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloBairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloBairro_Internalname, A268TituloBairro, StringUtil.RTrim( context.localUtil.Format( A268TituloBairro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloBairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloBairro_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTituloMunicipio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTituloMunicipio_Internalname, "Municipio", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloMunicipio_Internalname, A269TituloMunicipio, StringUtil.RTrim( context.localUtil.Format( A269TituloMunicipio, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloMunicipio_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTituloMunicipio_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         context.WriteHtmlText( "</fieldset>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemovimentos_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         if ( ! isFullAjaxMode( ) )
         {
            /* WebComponent */
            GxWebStd.gx_hidden_field( context, "W0094"+"", StringUtil.RTrim( WebComp_Wctitulomovimentoww_Component));
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent");
            context.WriteHtmlText( " id=\""+"gxHTMLWrpW0094"+""+"\""+"") ;
            context.WriteHtmlText( ">") ;
            if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
            {
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWctitulomovimentoww), StringUtil.Lower( WebComp_Wctitulomovimentoww_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0094"+"");
               }
               WebComp_Wctitulomovimentoww.componentdraw();
               if ( StringUtil.StrCmp(StringUtil.Lower( OldWctitulomovimentoww), StringUtil.Lower( WebComp_Wctitulomovimentoww_Component)) != 0 )
               {
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            context.WriteHtmlText( "</div>") ;
         }
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Titulo.htm");
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
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloDeleted_Internalname, StringUtil.BoolToStr( A284TituloDeleted), StringUtil.BoolToStr( A284TituloDeleted), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloDeleted_Jsonclick, 0, "Attribute", "", "", "", "", edtTituloDeleted_Visible, edtTituloDeleted_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_Titulo.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTituloVencimento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTituloVencimento_Internalname, context.localUtil.Format(A263TituloVencimento, "99/99/9999"), context.localUtil.Format( A263TituloVencimento, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloVencimento_Jsonclick, 0, "Attribute", "", "", "", "", edtTituloVencimento_Visible, edtTituloVencimento_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Titulo.htm");
         GxWebStd.gx_bitmap( context, edtTituloVencimento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTituloVencimento_Visible==0)||(edtTituloVencimento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Titulo.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloCompetenciaAno_Internalname, ((0==A286TituloCompetenciaAno)&&IsIns( )||n286TituloCompetenciaAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ",", ""))), ((0==A286TituloCompetenciaAno)&&IsIns( )||n286TituloCompetenciaAno ? "" : StringUtil.LTrim( ((edtTituloCompetenciaAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A286TituloCompetenciaAno), "ZZZ9") : context.localUtil.Format( (decimal)(A286TituloCompetenciaAno), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,109);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloCompetenciaAno_Jsonclick, 0, "Attribute", "", "", "", "", edtTituloCompetenciaAno_Visible, edtTituloCompetenciaAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Titulo.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTituloCompetenciaMes_Internalname, ((0==A287TituloCompetenciaMes)&&IsIns( )||n287TituloCompetenciaMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ",", ""))), ((0==A287TituloCompetenciaMes)&&IsIns( )||n287TituloCompetenciaMes ? "" : StringUtil.LTrim( ((edtTituloCompetenciaMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A287TituloCompetenciaMes), "ZZZ9") : context.localUtil.Format( (decimal)(A287TituloCompetenciaMes), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,110);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTituloCompetenciaMes_Jsonclick, 0, "Attribute", "", "", "", "", edtTituloCompetenciaMes_Visible, edtTituloCompetenciaMes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Titulo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
               {
                  WebComp_Wctitulomovimentoww.componentstart();
               }
            }
         }
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
         E11152 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z261TituloId"), ",", "."), 18, MidpointRounding.ToEven));
               Z262TituloValor = context.localUtil.CToN( cgiGet( "Z262TituloValor"), ",", ".");
               n262TituloValor = ((Convert.ToDecimal(0)==A262TituloValor) ? true : false);
               Z276TituloDesconto = context.localUtil.CToN( cgiGet( "Z276TituloDesconto"), ",", ".");
               n276TituloDesconto = ((Convert.ToDecimal(0)==A276TituloDesconto) ? true : false);
               Z284TituloDeleted = StringUtil.StrToBool( cgiGet( "Z284TituloDeleted"));
               n284TituloDeleted = ((false==A284TituloDeleted) ? true : false);
               Z314TituloArchived = StringUtil.StrToBool( cgiGet( "Z314TituloArchived"));
               n314TituloArchived = ((false==A314TituloArchived) ? true : false);
               Z263TituloVencimento = context.localUtil.CToD( cgiGet( "Z263TituloVencimento"), 0);
               n263TituloVencimento = ((DateTime.MinValue==A263TituloVencimento) ? true : false);
               Z286TituloCompetenciaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z286TituloCompetenciaAno"), ",", "."), 18, MidpointRounding.ToEven));
               n286TituloCompetenciaAno = ((0==A286TituloCompetenciaAno) ? true : false);
               Z287TituloCompetenciaMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z287TituloCompetenciaMes"), ",", "."), 18, MidpointRounding.ToEven));
               n287TituloCompetenciaMes = ((0==A287TituloCompetenciaMes) ? true : false);
               Z264TituloProrrogacao = context.localUtil.CToD( cgiGet( "Z264TituloProrrogacao"), 0);
               n264TituloProrrogacao = ((DateTime.MinValue==A264TituloProrrogacao) ? true : false);
               Z265TituloCEP = cgiGet( "Z265TituloCEP");
               n265TituloCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A265TituloCEP)) ? true : false);
               Z266TituloLogradouro = cgiGet( "Z266TituloLogradouro");
               n266TituloLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A266TituloLogradouro)) ? true : false);
               Z294TituloNumeroEndereco = cgiGet( "Z294TituloNumeroEndereco");
               n294TituloNumeroEndereco = (String.IsNullOrEmpty(StringUtil.RTrim( A294TituloNumeroEndereco)) ? true : false);
               Z267TituloComplemento = cgiGet( "Z267TituloComplemento");
               n267TituloComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A267TituloComplemento)) ? true : false);
               Z268TituloBairro = cgiGet( "Z268TituloBairro");
               n268TituloBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A268TituloBairro)) ? true : false);
               Z269TituloMunicipio = cgiGet( "Z269TituloMunicipio");
               n269TituloMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A269TituloMunicipio)) ? true : false);
               Z498TituloJurosMora = context.localUtil.CToN( cgiGet( "Z498TituloJurosMora"), ",", ".");
               n498TituloJurosMora = ((Convert.ToDecimal(0)==A498TituloJurosMora) ? true : false);
               Z283TituloTipo = cgiGet( "Z283TituloTipo");
               n283TituloTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A283TituloTipo)) ? true : false);
               Z500TituloCriacao = context.localUtil.CToT( cgiGet( "Z500TituloCriacao"), 0);
               n500TituloCriacao = ((DateTime.MinValue==A500TituloCriacao) ? true : false);
               Z648TituloPropostaTipo = cgiGet( "Z648TituloPropostaTipo");
               n648TituloPropostaTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A648TituloPropostaTipo)) ? true : false);
               Z422ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z422ContaId"), ",", "."), 18, MidpointRounding.ToEven));
               n422ContaId = ((0==A422ContaId) ? true : false);
               Z426CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z426CategoriaTituloId"), ",", "."), 18, MidpointRounding.ToEven));
               n426CategoriaTituloId = ((0==A426CategoriaTituloId) ? true : false);
               Z890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( "Z890NotaFiscalParcelamentoID"));
               n890NotaFiscalParcelamentoID = ((Guid.Empty==A890NotaFiscalParcelamentoID) ? true : false);
               Z951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z951ContaBancariaId"), ",", "."), 18, MidpointRounding.ToEven));
               n951ContaBancariaId = ((0==A951ContaBancariaId) ? true : false);
               Z419TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z419TituloPropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n419TituloPropostaId = ((0==A419TituloPropostaId) ? true : false);
               Z420TituloClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z420TituloClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n420TituloClienteId = ((0==A420TituloClienteId) ? true : false);
               A314TituloArchived = StringUtil.StrToBool( cgiGet( "Z314TituloArchived"));
               n314TituloArchived = false;
               n314TituloArchived = ((false==A314TituloArchived) ? true : false);
               A498TituloJurosMora = context.localUtil.CToN( cgiGet( "Z498TituloJurosMora"), ",", ".");
               n498TituloJurosMora = false;
               n498TituloJurosMora = ((Convert.ToDecimal(0)==A498TituloJurosMora) ? true : false);
               A500TituloCriacao = context.localUtil.CToT( cgiGet( "Z500TituloCriacao"), 0);
               n500TituloCriacao = false;
               n500TituloCriacao = ((DateTime.MinValue==A500TituloCriacao) ? true : false);
               A648TituloPropostaTipo = cgiGet( "Z648TituloPropostaTipo");
               n648TituloPropostaTipo = false;
               n648TituloPropostaTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A648TituloPropostaTipo)) ? true : false);
               A422ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z422ContaId"), ",", "."), 18, MidpointRounding.ToEven));
               n422ContaId = false;
               n422ContaId = ((0==A422ContaId) ? true : false);
               A426CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z426CategoriaTituloId"), ",", "."), 18, MidpointRounding.ToEven));
               n426CategoriaTituloId = false;
               n426CategoriaTituloId = ((0==A426CategoriaTituloId) ? true : false);
               A890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( "Z890NotaFiscalParcelamentoID"));
               n890NotaFiscalParcelamentoID = false;
               n890NotaFiscalParcelamentoID = ((Guid.Empty==A890NotaFiscalParcelamentoID) ? true : false);
               A951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z951ContaBancariaId"), ",", "."), 18, MidpointRounding.ToEven));
               n951ContaBancariaId = false;
               n951ContaBancariaId = ((0==A951ContaBancariaId) ? true : false);
               A419TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z419TituloPropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n419TituloPropostaId = false;
               n419TituloPropostaId = ((0==A419TituloPropostaId) ? true : false);
               A420TituloClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z420TituloClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n420TituloClienteId = false;
               n420TituloClienteId = ((0==A420TituloClienteId) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N420TituloClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N420TituloClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n420TituloClienteId = ((0==A420TituloClienteId) ? true : false);
               N419TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N419TituloPropostaId"), ",", "."), 18, MidpointRounding.ToEven));
               n419TituloPropostaId = ((0==A419TituloPropostaId) ? true : false);
               N422ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N422ContaId"), ",", "."), 18, MidpointRounding.ToEven));
               n422ContaId = ((0==A422ContaId) ? true : false);
               N426CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N426CategoriaTituloId"), ",", "."), 18, MidpointRounding.ToEven));
               n426CategoriaTituloId = ((0==A426CategoriaTituloId) ? true : false);
               N890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( "N890NotaFiscalParcelamentoID"));
               n890NotaFiscalParcelamentoID = ((Guid.Empty==A890NotaFiscalParcelamentoID) ? true : false);
               N951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N951ContaBancariaId"), ",", "."), 18, MidpointRounding.ToEven));
               n951ContaBancariaId = ((0==A951ContaBancariaId) ? true : false);
               A1118TitulosEmCarteiraDeCobranca_F = StringUtil.StrToBool( cgiGet( "TITULOSEMCARTEIRADECOBRANCA_F"));
               A303TituloSaldoCredito_F = context.localUtil.CToN( cgiGet( "TITULOSALDOCREDITO_F"), ",", ".");
               A302TituloSaldoDebito_F = context.localUtil.CToN( cgiGet( "TITULOSALDODEBITO_F"), ",", ".");
               A307TituloTotalMultaJurosCredito_F = context.localUtil.CToN( cgiGet( "TITULOTOTALMULTAJUROSCREDITO_F"), ",", ".");
               A306TituloTotalMultaJurosDebito_F = context.localUtil.CToN( cgiGet( "TITULOTOTALMULTAJUROSDEBITO_F"), ",", ".");
               A305TituloTotalMovimentoCredito_F = context.localUtil.CToN( cgiGet( "TITULOTOTALMOVIMENTOCREDITO_F"), ",", ".");
               A304TituloTotalMovimentoDebito_F = context.localUtil.CToN( cgiGet( "TITULOTOTALMOVIMENTODEBITO_F"), ",", ".");
               AV7TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vTITULOID"), ",", "."), 18, MidpointRounding.ToEven));
               AV25Insert_TituloClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TITULOCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25Insert_TituloClienteId", StringUtil.LTrimStr( (decimal)(AV25Insert_TituloClienteId), 9, 0));
               A420TituloClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TITULOCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               n420TituloClienteId = ((0==A420TituloClienteId) ? true : false);
               AV20Insert_TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TITULOPROPOSTAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20Insert_TituloPropostaId", StringUtil.LTrimStr( (decimal)(AV20Insert_TituloPropostaId), 9, 0));
               A419TituloPropostaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TITULOPROPOSTAID"), ",", "."), 18, MidpointRounding.ToEven));
               n419TituloPropostaId = ((0==A419TituloPropostaId) ? true : false);
               AV21Insert_ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CONTAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21Insert_ContaId", StringUtil.LTrimStr( (decimal)(AV21Insert_ContaId), 9, 0));
               A422ContaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONTAID"), ",", "."), 18, MidpointRounding.ToEven));
               n422ContaId = ((0==A422ContaId) ? true : false);
               AV22Insert_CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CATEGORIATITULOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV22Insert_CategoriaTituloId", StringUtil.LTrimStr( (decimal)(AV22Insert_CategoriaTituloId), 9, 0));
               A426CategoriaTituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CATEGORIATITULOID"), ",", "."), 18, MidpointRounding.ToEven));
               n426CategoriaTituloId = ((0==A426CategoriaTituloId) ? true : false);
               AV23Insert_NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( "vINSERT_NOTAFISCALPARCELAMENTOID"));
               AssignAttri("", false, "AV23Insert_NotaFiscalParcelamentoID", AV23Insert_NotaFiscalParcelamentoID.ToString());
               A890NotaFiscalParcelamentoID = StringUtil.StrToGuid( cgiGet( "NOTAFISCALPARCELAMENTOID"));
               n890NotaFiscalParcelamentoID = ((Guid.Empty==A890NotaFiscalParcelamentoID) ? true : false);
               AV24Insert_ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CONTABANCARIAID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV24Insert_ContaBancariaId", StringUtil.LTrimStr( (decimal)(AV24Insert_ContaBancariaId), 9, 0));
               A951ContaBancariaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CONTABANCARIAID"), ",", "."), 18, MidpointRounding.ToEven));
               n951ContaBancariaId = ((0==A951ContaBancariaId) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A500TituloCriacao = context.localUtil.CToT( cgiGet( "TITULOCRIACAO"), 0);
               n500TituloCriacao = ((DateTime.MinValue==A500TituloCriacao) ? true : false);
               A314TituloArchived = StringUtil.StrToBool( cgiGet( "TITULOARCHIVED"));
               n314TituloArchived = ((false==A314TituloArchived) ? true : false);
               A498TituloJurosMora = context.localUtil.CToN( cgiGet( "TITULOJUROSMORA"), ",", ".");
               n498TituloJurosMora = ((Convert.ToDecimal(0)==A498TituloJurosMora) ? true : false);
               A648TituloPropostaTipo = cgiGet( "TITULOPROPOSTATIPO");
               n648TituloPropostaTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A648TituloPropostaTipo)) ? true : false);
               A794NotaFiscalId = StringUtil.StrToGuid( cgiGet( "NOTAFISCALID"));
               A938AgenciaId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGENCIAID"), ",", "."), 18, MidpointRounding.ToEven));
               A953ContaBancariaCarteira = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CONTABANCARIACARTEIRA"), ",", "."), 18, MidpointRounding.ToEven));
               n953ContaBancariaCarteira = false;
               A952ContaBancariaNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CONTABANCARIANUMERO"), ",", "."), 18, MidpointRounding.ToEven));
               n952ContaBancariaNumero = false;
               A971TituloPropostaDescricao = cgiGet( "TITULOPROPOSTADESCRICAO");
               n971TituloPropostaDescricao = false;
               A501PropostaTaxaAdministrativa = context.localUtil.CToN( cgiGet( "PROPOSTATAXAADMINISTRATIVA"), ",", ".");
               n501PropostaTaxaAdministrativa = false;
               A972TituloCLienteRazaoSocial = cgiGet( "TITULOCLIENTERAZAOSOCIAL");
               n972TituloCLienteRazaoSocial = false;
               A799NotaFiscalNumero = cgiGet( "NOTAFISCALNUMERO");
               n799NotaFiscalNumero = false;
               A968AgenciaBancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGENCIABANCOID"), ",", "."), 18, MidpointRounding.ToEven));
               A939AgenciaNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( "AGENCIANUMERO"), ",", "."), 18, MidpointRounding.ToEven));
               n939AgenciaNumero = false;
               A969AgenciaBancoNome = cgiGet( "AGENCIABANCONOME");
               n969AgenciaBancoNome = false;
               A516TituloDataCredito_F = context.localUtil.CToD( cgiGet( "TITULODATACREDITO_F"), 0);
               n516TituloDataCredito_F = false;
               A301TituloTotalMultaJuros_F = context.localUtil.CToN( cgiGet( "TITULOTOTALMULTAJUROS_F"), ",", ".");
               n301TituloTotalMultaJuros_F = false;
               A1119TitulosCarteiraDeCobranca = cgiGet( "TITULOSCARTEIRADECOBRANCA");
               n1119TitulosCarteiraDeCobranca = false;
               AV27Pgmname = cgiGet( "vPGMNAME");
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
               A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n261TituloId = false;
               AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
               n262TituloValor = ((StringUtil.StrCmp(cgiGet( edtTituloValor_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTituloValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTituloValor_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TITULOVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtTituloValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A262TituloValor = 0;
                  n262TituloValor = false;
                  AssignAttri("", false, "A262TituloValor", (n262TituloValor ? "" : StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", ""))));
               }
               else
               {
                  A262TituloValor = context.localUtil.CToN( cgiGet( edtTituloValor_Internalname), ",", ".");
                  AssignAttri("", false, "A262TituloValor", (n262TituloValor ? "" : StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", ""))));
               }
               n276TituloDesconto = ((StringUtil.StrCmp(cgiGet( edtTituloDesconto_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTituloDesconto_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTituloDesconto_Internalname), ",", ".") > 999999999999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TITULODESCONTO");
                  AnyError = 1;
                  GX_FocusControl = edtTituloDesconto_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A276TituloDesconto = 0;
                  n276TituloDesconto = false;
                  AssignAttri("", false, "A276TituloDesconto", (n276TituloDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ".", ""))));
               }
               else
               {
                  A276TituloDesconto = context.localUtil.CToN( cgiGet( edtTituloDesconto_Internalname), ",", ".");
                  AssignAttri("", false, "A276TituloDesconto", (n276TituloDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ".", ""))));
               }
               if ( context.localUtil.VCDate( cgiGet( edtTituloProrrogacao_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Titulo Prorrogacao"}), 1, "TITULOPRORROGACAO");
                  AnyError = 1;
                  GX_FocusControl = edtTituloProrrogacao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A264TituloProrrogacao = DateTime.MinValue;
                  n264TituloProrrogacao = false;
                  AssignAttri("", false, "A264TituloProrrogacao", context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"));
               }
               else
               {
                  A264TituloProrrogacao = context.localUtil.CToD( cgiGet( edtTituloProrrogacao_Internalname), 2);
                  n264TituloProrrogacao = false;
                  AssignAttri("", false, "A264TituloProrrogacao", context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"));
               }
               n264TituloProrrogacao = ((DateTime.MinValue==A264TituloProrrogacao) ? true : false);
               A295TituloCompetencia_F = cgiGet( edtTituloCompetencia_F_Internalname);
               AssignAttri("", false, "A295TituloCompetencia_F", A295TituloCompetencia_F);
               A282TituloStatus_F = cgiGet( edtTituloStatus_F_Internalname);
               AssignAttri("", false, "A282TituloStatus_F", A282TituloStatus_F);
               cmbTituloTipo.CurrentValue = cgiGet( cmbTituloTipo_Internalname);
               A283TituloTipo = cgiGet( cmbTituloTipo_Internalname);
               n283TituloTipo = false;
               AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
               n283TituloTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A283TituloTipo)) ? true : false);
               A275TituloSaldo_F = context.localUtil.CToN( cgiGet( edtTituloSaldo_F_Internalname), ",", ".");
               AssignAttri("", false, "A275TituloSaldo_F", StringUtil.LTrimStr( A275TituloSaldo_F, 18, 2));
               A273TituloTotalMovimento_F = context.localUtil.CToN( cgiGet( edtTituloTotalMovimento_F_Internalname), ",", ".");
               n273TituloTotalMovimento_F = false;
               AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
               A265TituloCEP = cgiGet( edtTituloCEP_Internalname);
               n265TituloCEP = false;
               AssignAttri("", false, "A265TituloCEP", A265TituloCEP);
               n265TituloCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A265TituloCEP)) ? true : false);
               A266TituloLogradouro = cgiGet( edtTituloLogradouro_Internalname);
               n266TituloLogradouro = false;
               AssignAttri("", false, "A266TituloLogradouro", A266TituloLogradouro);
               n266TituloLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A266TituloLogradouro)) ? true : false);
               A294TituloNumeroEndereco = cgiGet( edtTituloNumeroEndereco_Internalname);
               n294TituloNumeroEndereco = false;
               AssignAttri("", false, "A294TituloNumeroEndereco", A294TituloNumeroEndereco);
               n294TituloNumeroEndereco = (String.IsNullOrEmpty(StringUtil.RTrim( A294TituloNumeroEndereco)) ? true : false);
               A267TituloComplemento = cgiGet( edtTituloComplemento_Internalname);
               n267TituloComplemento = false;
               AssignAttri("", false, "A267TituloComplemento", A267TituloComplemento);
               n267TituloComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A267TituloComplemento)) ? true : false);
               A268TituloBairro = cgiGet( edtTituloBairro_Internalname);
               n268TituloBairro = false;
               AssignAttri("", false, "A268TituloBairro", A268TituloBairro);
               n268TituloBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A268TituloBairro)) ? true : false);
               A269TituloMunicipio = cgiGet( edtTituloMunicipio_Internalname);
               n269TituloMunicipio = false;
               AssignAttri("", false, "A269TituloMunicipio", A269TituloMunicipio);
               n269TituloMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A269TituloMunicipio)) ? true : false);
               A284TituloDeleted = StringUtil.StrToBool( cgiGet( edtTituloDeleted_Internalname));
               n284TituloDeleted = false;
               AssignAttri("", false, "A284TituloDeleted", A284TituloDeleted);
               n284TituloDeleted = ((false==A284TituloDeleted) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtTituloVencimento_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Titulo Vencimento"}), 1, "TITULOVENCIMENTO");
                  AnyError = 1;
                  GX_FocusControl = edtTituloVencimento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A263TituloVencimento = DateTime.MinValue;
                  n263TituloVencimento = false;
                  AssignAttri("", false, "A263TituloVencimento", context.localUtil.Format(A263TituloVencimento, "99/99/9999"));
               }
               else
               {
                  A263TituloVencimento = context.localUtil.CToD( cgiGet( edtTituloVencimento_Internalname), 2);
                  n263TituloVencimento = false;
                  AssignAttri("", false, "A263TituloVencimento", context.localUtil.Format(A263TituloVencimento, "99/99/9999"));
               }
               n263TituloVencimento = ((DateTime.MinValue==A263TituloVencimento) ? true : false);
               n286TituloCompetenciaAno = ((StringUtil.StrCmp(cgiGet( edtTituloCompetenciaAno_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTituloCompetenciaAno_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTituloCompetenciaAno_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TITULOCOMPETENCIAANO");
                  AnyError = 1;
                  GX_FocusControl = edtTituloCompetenciaAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A286TituloCompetenciaAno = 0;
                  n286TituloCompetenciaAno = false;
                  AssignAttri("", false, "A286TituloCompetenciaAno", (n286TituloCompetenciaAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", ""))));
               }
               else
               {
                  A286TituloCompetenciaAno = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaAno_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A286TituloCompetenciaAno", (n286TituloCompetenciaAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", ""))));
               }
               n287TituloCompetenciaMes = ((StringUtil.StrCmp(cgiGet( edtTituloCompetenciaMes_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTituloCompetenciaMes_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTituloCompetenciaMes_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TITULOCOMPETENCIAMES");
                  AnyError = 1;
                  GX_FocusControl = edtTituloCompetenciaMes_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A287TituloCompetenciaMes = 0;
                  n287TituloCompetenciaMes = false;
                  AssignAttri("", false, "A287TituloCompetenciaMes", (n287TituloCompetenciaMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", ""))));
               }
               else
               {
                  A287TituloCompetenciaMes = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloCompetenciaMes_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A287TituloCompetenciaMes", (n287TituloCompetenciaMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", ""))));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Titulo");
               A261TituloId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtTituloId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n261TituloId = false;
               AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
               forbiddenHiddens.Add("TituloId", context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_TituloClienteId", context.localUtil.Format( (decimal)(AV25Insert_TituloClienteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_TituloPropostaId", context.localUtil.Format( (decimal)(AV20Insert_TituloPropostaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ContaId", context.localUtil.Format( (decimal)(AV21Insert_ContaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_CategoriaTituloId", context.localUtil.Format( (decimal)(AV22Insert_CategoriaTituloId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_NotaFiscalParcelamentoID", AV23Insert_NotaFiscalParcelamentoID.ToString());
               forbiddenHiddens.Add("Insert_ContaBancariaId", context.localUtil.Format( (decimal)(AV24Insert_ContaBancariaId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("TituloArchived", StringUtil.BoolToStr( A314TituloArchived));
               forbiddenHiddens.Add("TituloJurosMora", context.localUtil.Format( A498TituloJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
               forbiddenHiddens.Add("TituloCriacao", context.localUtil.Format( A500TituloCriacao, "99/99/99 99:99"));
               forbiddenHiddens.Add("TituloPropostaTipo", StringUtil.RTrim( context.localUtil.Format( A648TituloPropostaTipo, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A261TituloId != Z261TituloId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("titulo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A261TituloId = (int)(Math.Round(NumberUtil.Val( GetPar( "TituloId"), "."), 18, MidpointRounding.ToEven));
                  n261TituloId = false;
                  AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
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
                     sMode44 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode44;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound44 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_150( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TITULOID");
                        AnyError = 1;
                        GX_FocusControl = edtTituloId_Internalname;
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
                           E11152 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12152 ();
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
                  else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 4);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                     if ( nCmpId == 94 )
                     {
                        OldWctitulomovimentoww = cgiGet( "W0094");
                        if ( ( StringUtil.Len( OldWctitulomovimentoww) == 0 ) || ( StringUtil.StrCmp(OldWctitulomovimentoww, WebComp_Wctitulomovimentoww_Component) != 0 ) )
                        {
                           WebComp_Wctitulomovimentoww = getWebComponent(GetType(), "GeneXus.Programs", OldWctitulomovimentoww, new Object[] {context} );
                           WebComp_Wctitulomovimentoww.ComponentInit();
                           WebComp_Wctitulomovimentoww.Name = "OldWctitulomovimentoww";
                           WebComp_Wctitulomovimentoww_Component = OldWctitulomovimentoww;
                        }
                        if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
                        {
                           WebComp_Wctitulomovimentoww.componentprocess("W0094", "", sEvt);
                        }
                        WebComp_Wctitulomovimentoww_Component = OldWctitulomovimentoww;
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
            E12152 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1544( ) ;
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
            DisableAttributes1544( ) ;
         }
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

      protected void CONFIRM_150( )
      {
         BeforeValidate1544( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1544( ) ;
            }
            else
            {
               CheckExtendedTable1544( ) ;
               CloseExtendedTableCursors1544( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption150( )
      {
      }

      protected void E11152( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV27Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV28GXV1 = 1;
            AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            while ( AV28GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV28GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "TituloClienteId") == 0 )
               {
                  AV25Insert_TituloClienteId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV25Insert_TituloClienteId", StringUtil.LTrimStr( (decimal)(AV25Insert_TituloClienteId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "TituloPropostaId") == 0 )
               {
                  AV20Insert_TituloPropostaId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV20Insert_TituloPropostaId", StringUtil.LTrimStr( (decimal)(AV20Insert_TituloPropostaId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ContaId") == 0 )
               {
                  AV21Insert_ContaId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV21Insert_ContaId", StringUtil.LTrimStr( (decimal)(AV21Insert_ContaId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "CategoriaTituloId") == 0 )
               {
                  AV22Insert_CategoriaTituloId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV22Insert_CategoriaTituloId", StringUtil.LTrimStr( (decimal)(AV22Insert_CategoriaTituloId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "NotaFiscalParcelamentoID") == 0 )
               {
                  AV23Insert_NotaFiscalParcelamentoID = StringUtil.StrToGuid( AV12TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV23Insert_NotaFiscalParcelamentoID", AV23Insert_NotaFiscalParcelamentoID.ToString());
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ContaBancariaId") == 0 )
               {
                  AV24Insert_ContaBancariaId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV24Insert_ContaBancariaId", StringUtil.LTrimStr( (decimal)(AV24Insert_ContaBancariaId), 9, 0));
               }
               AV28GXV1 = (int)(AV28GXV1+1);
               AssignAttri("", false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            }
         }
         edtTituloDeleted_Visible = 0;
         AssignProp("", false, edtTituloDeleted_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTituloDeleted_Visible), 5, 0), true);
         edtTituloVencimento_Visible = 0;
         AssignProp("", false, edtTituloVencimento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTituloVencimento_Visible), 5, 0), true);
         edtTituloCompetenciaAno_Visible = 0;
         AssignProp("", false, edtTituloCompetenciaAno_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTituloCompetenciaAno_Visible), 5, 0), true);
         edtTituloCompetenciaMes_Visible = 0;
         AssignProp("", false, edtTituloCompetenciaMes_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTituloCompetenciaMes_Visible), 5, 0), true);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wctitulomovimentoww = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wctitulomovimentoww_Component), StringUtil.Lower( "TituloMovimentoWW")) != 0 )
         {
            WebComp_Wctitulomovimentoww = getWebComponent(GetType(), "GeneXus.Programs", "titulomovimentoww", new Object[] {context} );
            WebComp_Wctitulomovimentoww.ComponentInit();
            WebComp_Wctitulomovimentoww.Name = "TituloMovimentoWW";
            WebComp_Wctitulomovimentoww_Component = "TituloMovimentoWW";
         }
         if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
         {
            WebComp_Wctitulomovimentoww.setjustcreated();
            WebComp_Wctitulomovimentoww.componentprepare(new Object[] {(string)"W0094",(string)"",(int)AV7TituloId});
            WebComp_Wctitulomovimentoww.componentbind(new Object[] {(string)""});
         }
      }

      protected void E12152( )
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

      protected void ZM1544( short GX_JID )
      {
         if ( ( GX_JID == 31 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z262TituloValor = T00153_A262TituloValor[0];
               Z276TituloDesconto = T00153_A276TituloDesconto[0];
               Z284TituloDeleted = T00153_A284TituloDeleted[0];
               Z314TituloArchived = T00153_A314TituloArchived[0];
               Z263TituloVencimento = T00153_A263TituloVencimento[0];
               Z286TituloCompetenciaAno = T00153_A286TituloCompetenciaAno[0];
               Z287TituloCompetenciaMes = T00153_A287TituloCompetenciaMes[0];
               Z264TituloProrrogacao = T00153_A264TituloProrrogacao[0];
               Z265TituloCEP = T00153_A265TituloCEP[0];
               Z266TituloLogradouro = T00153_A266TituloLogradouro[0];
               Z294TituloNumeroEndereco = T00153_A294TituloNumeroEndereco[0];
               Z267TituloComplemento = T00153_A267TituloComplemento[0];
               Z268TituloBairro = T00153_A268TituloBairro[0];
               Z269TituloMunicipio = T00153_A269TituloMunicipio[0];
               Z498TituloJurosMora = T00153_A498TituloJurosMora[0];
               Z283TituloTipo = T00153_A283TituloTipo[0];
               Z500TituloCriacao = T00153_A500TituloCriacao[0];
               Z648TituloPropostaTipo = T00153_A648TituloPropostaTipo[0];
               Z422ContaId = T00153_A422ContaId[0];
               Z426CategoriaTituloId = T00153_A426CategoriaTituloId[0];
               Z890NotaFiscalParcelamentoID = T00153_A890NotaFiscalParcelamentoID[0];
               Z951ContaBancariaId = T00153_A951ContaBancariaId[0];
               Z419TituloPropostaId = T00153_A419TituloPropostaId[0];
               Z420TituloClienteId = T00153_A420TituloClienteId[0];
            }
            else
            {
               Z262TituloValor = A262TituloValor;
               Z276TituloDesconto = A276TituloDesconto;
               Z284TituloDeleted = A284TituloDeleted;
               Z314TituloArchived = A314TituloArchived;
               Z263TituloVencimento = A263TituloVencimento;
               Z286TituloCompetenciaAno = A286TituloCompetenciaAno;
               Z287TituloCompetenciaMes = A287TituloCompetenciaMes;
               Z264TituloProrrogacao = A264TituloProrrogacao;
               Z265TituloCEP = A265TituloCEP;
               Z266TituloLogradouro = A266TituloLogradouro;
               Z294TituloNumeroEndereco = A294TituloNumeroEndereco;
               Z267TituloComplemento = A267TituloComplemento;
               Z268TituloBairro = A268TituloBairro;
               Z269TituloMunicipio = A269TituloMunicipio;
               Z498TituloJurosMora = A498TituloJurosMora;
               Z283TituloTipo = A283TituloTipo;
               Z500TituloCriacao = A500TituloCriacao;
               Z648TituloPropostaTipo = A648TituloPropostaTipo;
               Z422ContaId = A422ContaId;
               Z426CategoriaTituloId = A426CategoriaTituloId;
               Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
               Z951ContaBancariaId = A951ContaBancariaId;
               Z419TituloPropostaId = A419TituloPropostaId;
               Z420TituloClienteId = A420TituloClienteId;
            }
         }
         if ( GX_JID == -31 )
         {
            Z261TituloId = A261TituloId;
            Z262TituloValor = A262TituloValor;
            Z276TituloDesconto = A276TituloDesconto;
            Z284TituloDeleted = A284TituloDeleted;
            Z314TituloArchived = A314TituloArchived;
            Z263TituloVencimento = A263TituloVencimento;
            Z286TituloCompetenciaAno = A286TituloCompetenciaAno;
            Z287TituloCompetenciaMes = A287TituloCompetenciaMes;
            Z264TituloProrrogacao = A264TituloProrrogacao;
            Z265TituloCEP = A265TituloCEP;
            Z266TituloLogradouro = A266TituloLogradouro;
            Z294TituloNumeroEndereco = A294TituloNumeroEndereco;
            Z267TituloComplemento = A267TituloComplemento;
            Z268TituloBairro = A268TituloBairro;
            Z269TituloMunicipio = A269TituloMunicipio;
            Z498TituloJurosMora = A498TituloJurosMora;
            Z283TituloTipo = A283TituloTipo;
            Z500TituloCriacao = A500TituloCriacao;
            Z648TituloPropostaTipo = A648TituloPropostaTipo;
            Z422ContaId = A422ContaId;
            Z426CategoriaTituloId = A426CategoriaTituloId;
            Z890NotaFiscalParcelamentoID = A890NotaFiscalParcelamentoID;
            Z951ContaBancariaId = A951ContaBancariaId;
            Z419TituloPropostaId = A419TituloPropostaId;
            Z420TituloClienteId = A420TituloClienteId;
            Z794NotaFiscalId = A794NotaFiscalId;
            Z799NotaFiscalNumero = A799NotaFiscalNumero;
            Z938AgenciaId = A938AgenciaId;
            Z953ContaBancariaCarteira = A953ContaBancariaCarteira;
            Z952ContaBancariaNumero = A952ContaBancariaNumero;
            Z968AgenciaBancoId = A968AgenciaBancoId;
            Z939AgenciaNumero = A939AgenciaNumero;
            Z969AgenciaBancoNome = A969AgenciaBancoNome;
            Z971TituloPropostaDescricao = A971TituloPropostaDescricao;
            Z501PropostaTaxaAdministrativa = A501PropostaTaxaAdministrativa;
            Z972TituloCLienteRazaoSocial = A972TituloCLienteRazaoSocial;
            Z516TituloDataCredito_F = A516TituloDataCredito_F;
            Z273TituloTotalMovimento_F = A273TituloTotalMovimento_F;
            Z301TituloTotalMultaJuros_F = A301TituloTotalMultaJuros_F;
            Z1119TitulosCarteiraDeCobranca = A1119TitulosCarteiraDeCobranca;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTituloId_Enabled = 0;
         AssignProp("", false, edtTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloId_Enabled), 5, 0), true);
         AV27Pgmname = "Titulo";
         AssignAttri("", false, "AV27Pgmname", AV27Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtTituloId_Enabled = 0;
         AssignProp("", false, edtTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TituloId) )
         {
            A261TituloId = AV7TituloId;
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV25Insert_TituloClienteId) )
         {
            A420TituloClienteId = AV25Insert_TituloClienteId;
            n420TituloClienteId = false;
            AssignAttri("", false, "A420TituloClienteId", ((0==A420TituloClienteId)&&IsIns( )||n420TituloClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A420TituloClienteId), 9, 0, ".", ""))));
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
         if ( IsIns( )  && (false==A284TituloDeleted) && ( Gx_BScreen == 0 ) )
         {
            A284TituloDeleted = false;
            n284TituloDeleted = false;
            AssignAttri("", false, "A284TituloDeleted", A284TituloDeleted);
         }
         if ( IsIns( )  && (DateTime.MinValue==A500TituloCriacao) && ( Gx_BScreen == 0 ) )
         {
            A500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
            n500TituloCriacao = false;
            AssignAttri("", false, "A500TituloCriacao", context.localUtil.TToC( A500TituloCriacao, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T001514 */
            pr_default.execute(11, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               A516TituloDataCredito_F = T001514_A516TituloDataCredito_F[0];
               n516TituloDataCredito_F = T001514_n516TituloDataCredito_F[0];
            }
            else
            {
               A516TituloDataCredito_F = DateTime.MinValue;
               n516TituloDataCredito_F = false;
               AssignAttri("", false, "A516TituloDataCredito_F", context.localUtil.Format(A516TituloDataCredito_F, "99/99/9999"));
            }
            pr_default.close(11);
            /* Using cursor T001516 */
            pr_default.execute(12, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               A273TituloTotalMovimento_F = T001516_A273TituloTotalMovimento_F[0];
               n273TituloTotalMovimento_F = T001516_n273TituloTotalMovimento_F[0];
               AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
            }
            else
            {
               A273TituloTotalMovimento_F = 0;
               n273TituloTotalMovimento_F = false;
               AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
            }
            pr_default.close(12);
            /* Using cursor T001518 */
            pr_default.execute(13, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               A301TituloTotalMultaJuros_F = T001518_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = T001518_n301TituloTotalMultaJuros_F[0];
            }
            else
            {
               A301TituloTotalMultaJuros_F = 0;
               n301TituloTotalMultaJuros_F = false;
               AssignAttri("", false, "A301TituloTotalMultaJuros_F", StringUtil.LTrimStr( A301TituloTotalMultaJuros_F, 18, 2));
            }
            pr_default.close(13);
            /* Using cursor T001520 */
            pr_default.execute(14, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               A1119TitulosCarteiraDeCobranca = T001520_A1119TitulosCarteiraDeCobranca[0];
               n1119TitulosCarteiraDeCobranca = T001520_n1119TitulosCarteiraDeCobranca[0];
            }
            else
            {
               A1119TitulosCarteiraDeCobranca = "";
               n1119TitulosCarteiraDeCobranca = false;
               AssignAttri("", false, "A1119TitulosCarteiraDeCobranca", A1119TitulosCarteiraDeCobranca);
            }
            pr_default.close(14);
            A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
            AssignAttri("", false, "A1118TitulosEmCarteiraDeCobranca_F", A1118TitulosEmCarteiraDeCobranca_F);
            /* Using cursor T00159 */
            pr_default.execute(7, new Object[] {n420TituloClienteId, A420TituloClienteId});
            A972TituloCLienteRazaoSocial = T00159_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = T00159_n972TituloCLienteRazaoSocial[0];
            pr_default.close(7);
         }
      }

      protected void Load1544( )
      {
         /* Using cursor T001525 */
         pr_default.execute(15, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound44 = 1;
            A794NotaFiscalId = T001525_A794NotaFiscalId[0];
            n794NotaFiscalId = T001525_n794NotaFiscalId[0];
            A938AgenciaId = T001525_A938AgenciaId[0];
            n938AgenciaId = T001525_n938AgenciaId[0];
            A968AgenciaBancoId = T001525_A968AgenciaBancoId[0];
            n968AgenciaBancoId = T001525_n968AgenciaBancoId[0];
            A972TituloCLienteRazaoSocial = T001525_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = T001525_n972TituloCLienteRazaoSocial[0];
            A262TituloValor = T001525_A262TituloValor[0];
            n262TituloValor = T001525_n262TituloValor[0];
            AssignAttri("", false, "A262TituloValor", ((Convert.ToDecimal(0)==A262TituloValor)&&IsIns( )||n262TituloValor ? "" : StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", ""))));
            A276TituloDesconto = T001525_A276TituloDesconto[0];
            n276TituloDesconto = T001525_n276TituloDesconto[0];
            AssignAttri("", false, "A276TituloDesconto", ((Convert.ToDecimal(0)==A276TituloDesconto)&&IsIns( )||n276TituloDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ".", ""))));
            A284TituloDeleted = T001525_A284TituloDeleted[0];
            n284TituloDeleted = T001525_n284TituloDeleted[0];
            AssignAttri("", false, "A284TituloDeleted", A284TituloDeleted);
            A314TituloArchived = T001525_A314TituloArchived[0];
            n314TituloArchived = T001525_n314TituloArchived[0];
            A263TituloVencimento = T001525_A263TituloVencimento[0];
            n263TituloVencimento = T001525_n263TituloVencimento[0];
            AssignAttri("", false, "A263TituloVencimento", context.localUtil.Format(A263TituloVencimento, "99/99/9999"));
            A286TituloCompetenciaAno = T001525_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = T001525_n286TituloCompetenciaAno[0];
            AssignAttri("", false, "A286TituloCompetenciaAno", ((0==A286TituloCompetenciaAno)&&IsIns( )||n286TituloCompetenciaAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", ""))));
            A287TituloCompetenciaMes = T001525_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = T001525_n287TituloCompetenciaMes[0];
            AssignAttri("", false, "A287TituloCompetenciaMes", ((0==A287TituloCompetenciaMes)&&IsIns( )||n287TituloCompetenciaMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", ""))));
            A264TituloProrrogacao = T001525_A264TituloProrrogacao[0];
            n264TituloProrrogacao = T001525_n264TituloProrrogacao[0];
            AssignAttri("", false, "A264TituloProrrogacao", context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"));
            A265TituloCEP = T001525_A265TituloCEP[0];
            n265TituloCEP = T001525_n265TituloCEP[0];
            AssignAttri("", false, "A265TituloCEP", A265TituloCEP);
            A266TituloLogradouro = T001525_A266TituloLogradouro[0];
            n266TituloLogradouro = T001525_n266TituloLogradouro[0];
            AssignAttri("", false, "A266TituloLogradouro", A266TituloLogradouro);
            A294TituloNumeroEndereco = T001525_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = T001525_n294TituloNumeroEndereco[0];
            AssignAttri("", false, "A294TituloNumeroEndereco", A294TituloNumeroEndereco);
            A267TituloComplemento = T001525_A267TituloComplemento[0];
            n267TituloComplemento = T001525_n267TituloComplemento[0];
            AssignAttri("", false, "A267TituloComplemento", A267TituloComplemento);
            A268TituloBairro = T001525_A268TituloBairro[0];
            n268TituloBairro = T001525_n268TituloBairro[0];
            AssignAttri("", false, "A268TituloBairro", A268TituloBairro);
            A269TituloMunicipio = T001525_A269TituloMunicipio[0];
            n269TituloMunicipio = T001525_n269TituloMunicipio[0];
            AssignAttri("", false, "A269TituloMunicipio", A269TituloMunicipio);
            A498TituloJurosMora = T001525_A498TituloJurosMora[0];
            n498TituloJurosMora = T001525_n498TituloJurosMora[0];
            A283TituloTipo = T001525_A283TituloTipo[0];
            n283TituloTipo = T001525_n283TituloTipo[0];
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
            A971TituloPropostaDescricao = T001525_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = T001525_n971TituloPropostaDescricao[0];
            A501PropostaTaxaAdministrativa = T001525_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = T001525_n501PropostaTaxaAdministrativa[0];
            A500TituloCriacao = T001525_A500TituloCriacao[0];
            n500TituloCriacao = T001525_n500TituloCriacao[0];
            A648TituloPropostaTipo = T001525_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = T001525_n648TituloPropostaTipo[0];
            A799NotaFiscalNumero = T001525_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = T001525_n799NotaFiscalNumero[0];
            A969AgenciaBancoNome = T001525_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = T001525_n969AgenciaBancoNome[0];
            A953ContaBancariaCarteira = T001525_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = T001525_n953ContaBancariaCarteira[0];
            A952ContaBancariaNumero = T001525_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = T001525_n952ContaBancariaNumero[0];
            A939AgenciaNumero = T001525_A939AgenciaNumero[0];
            n939AgenciaNumero = T001525_n939AgenciaNumero[0];
            A422ContaId = T001525_A422ContaId[0];
            n422ContaId = T001525_n422ContaId[0];
            A426CategoriaTituloId = T001525_A426CategoriaTituloId[0];
            n426CategoriaTituloId = T001525_n426CategoriaTituloId[0];
            A890NotaFiscalParcelamentoID = T001525_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = T001525_n890NotaFiscalParcelamentoID[0];
            A951ContaBancariaId = T001525_A951ContaBancariaId[0];
            n951ContaBancariaId = T001525_n951ContaBancariaId[0];
            A419TituloPropostaId = T001525_A419TituloPropostaId[0];
            n419TituloPropostaId = T001525_n419TituloPropostaId[0];
            A420TituloClienteId = T001525_A420TituloClienteId[0];
            n420TituloClienteId = T001525_n420TituloClienteId[0];
            A516TituloDataCredito_F = T001525_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = T001525_n516TituloDataCredito_F[0];
            A273TituloTotalMovimento_F = T001525_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = T001525_n273TituloTotalMovimento_F[0];
            AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
            A301TituloTotalMultaJuros_F = T001525_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = T001525_n301TituloTotalMultaJuros_F[0];
            A1119TitulosCarteiraDeCobranca = T001525_A1119TitulosCarteiraDeCobranca[0];
            n1119TitulosCarteiraDeCobranca = T001525_n1119TitulosCarteiraDeCobranca[0];
            ZM1544( -31) ;
         }
         pr_default.close(15);
         OnLoadActions1544( ) ;
      }

      protected void OnLoadActions1544( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_TituloPropostaId) )
         {
            A419TituloPropostaId = AV20Insert_TituloPropostaId;
            n419TituloPropostaId = false;
            AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A419TituloPropostaId) )
            {
               A419TituloPropostaId = 0;
               n419TituloPropostaId = false;
               AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
               n419TituloPropostaId = true;
               n419TituloPropostaId = true;
               AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV21Insert_ContaId) )
         {
            A422ContaId = AV21Insert_ContaId;
            n422ContaId = false;
            AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A422ContaId) )
            {
               A422ContaId = 0;
               n422ContaId = false;
               AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
               n422ContaId = true;
               n422ContaId = true;
               AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_CategoriaTituloId) )
         {
            A426CategoriaTituloId = AV22Insert_CategoriaTituloId;
            n426CategoriaTituloId = false;
            AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A426CategoriaTituloId) )
            {
               A426CategoriaTituloId = 0;
               n426CategoriaTituloId = false;
               AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
               n426CategoriaTituloId = true;
               n426CategoriaTituloId = true;
               AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV23Insert_NotaFiscalParcelamentoID) )
         {
            A890NotaFiscalParcelamentoID = AV23Insert_NotaFiscalParcelamentoID;
            n890NotaFiscalParcelamentoID = false;
            AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
         }
         else
         {
            if ( (Guid.Empty==A890NotaFiscalParcelamentoID) )
            {
               A890NotaFiscalParcelamentoID = Guid.Empty;
               n890NotaFiscalParcelamentoID = false;
               AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
               n890NotaFiscalParcelamentoID = true;
               n890NotaFiscalParcelamentoID = true;
               AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_ContaBancariaId) )
         {
            A951ContaBancariaId = AV24Insert_ContaBancariaId;
            n951ContaBancariaId = false;
            AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A951ContaBancariaId) )
            {
               A951ContaBancariaId = 0;
               n951ContaBancariaId = false;
               AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
               n951ContaBancariaId = true;
               n951ContaBancariaId = true;
               AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
            }
         }
         A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         AssignAttri("", false, "A303TituloSaldoCredito_F", StringUtil.LTrimStr( A303TituloSaldoCredito_F, 18, 2));
         A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         AssignAttri("", false, "A302TituloSaldoDebito_F", StringUtil.LTrimStr( A302TituloSaldoDebito_F, 18, 2));
         A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
         AssignAttri("", false, "A275TituloSaldo_F", StringUtil.LTrimStr( A275TituloSaldo_F, 18, 2));
         A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
         AssignAttri("", false, "A282TituloStatus_F", A282TituloStatus_F);
         A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
         AssignAttri("", false, "A1118TitulosEmCarteiraDeCobranca_F", A1118TitulosEmCarteiraDeCobranca_F);
         A307TituloTotalMultaJurosCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMultaJurosCredito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A307TituloTotalMultaJurosCredito_F", StringUtil.LTrimStr( A307TituloTotalMultaJurosCredito_F, 18, 2));
         A306TituloTotalMultaJurosDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMultaJurosDebito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A306TituloTotalMultaJurosDebito_F", StringUtil.LTrimStr( A306TituloTotalMultaJurosDebito_F, 18, 2));
         A305TituloTotalMovimentoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMovimentoCredito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A305TituloTotalMovimentoCredito_F", StringUtil.LTrimStr( A305TituloTotalMovimentoCredito_F, 18, 2));
         A304TituloTotalMovimentoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMovimentoDebito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A304TituloTotalMovimentoDebito_F", StringUtil.LTrimStr( A304TituloTotalMovimentoDebito_F, 18, 2));
         A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
         AssignAttri("", false, "A295TituloCompetencia_F", A295TituloCompetencia_F);
      }

      protected void CheckExtendedTable1544( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV20Insert_TituloPropostaId) )
         {
            A419TituloPropostaId = AV20Insert_TituloPropostaId;
            n419TituloPropostaId = false;
            AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A419TituloPropostaId) )
            {
               A419TituloPropostaId = 0;
               n419TituloPropostaId = false;
               AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
               n419TituloPropostaId = true;
               n419TituloPropostaId = true;
               AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV21Insert_ContaId) )
         {
            A422ContaId = AV21Insert_ContaId;
            n422ContaId = false;
            AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A422ContaId) )
            {
               A422ContaId = 0;
               n422ContaId = false;
               AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
               n422ContaId = true;
               n422ContaId = true;
               AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV22Insert_CategoriaTituloId) )
         {
            A426CategoriaTituloId = AV22Insert_CategoriaTituloId;
            n426CategoriaTituloId = false;
            AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A426CategoriaTituloId) )
            {
               A426CategoriaTituloId = 0;
               n426CategoriaTituloId = false;
               AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
               n426CategoriaTituloId = true;
               n426CategoriaTituloId = true;
               AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV23Insert_NotaFiscalParcelamentoID) )
         {
            A890NotaFiscalParcelamentoID = AV23Insert_NotaFiscalParcelamentoID;
            n890NotaFiscalParcelamentoID = false;
            AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
         }
         else
         {
            if ( (Guid.Empty==A890NotaFiscalParcelamentoID) )
            {
               A890NotaFiscalParcelamentoID = Guid.Empty;
               n890NotaFiscalParcelamentoID = false;
               AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
               n890NotaFiscalParcelamentoID = true;
               n890NotaFiscalParcelamentoID = true;
               AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_ContaBancariaId) )
         {
            A951ContaBancariaId = AV24Insert_ContaBancariaId;
            n951ContaBancariaId = false;
            AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A951ContaBancariaId) )
            {
               A951ContaBancariaId = 0;
               n951ContaBancariaId = false;
               AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
               n951ContaBancariaId = true;
               n951ContaBancariaId = true;
               AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
            }
         }
         /* Using cursor T001514 */
         pr_default.execute(11, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            A516TituloDataCredito_F = T001514_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = T001514_n516TituloDataCredito_F[0];
         }
         else
         {
            A516TituloDataCredito_F = DateTime.MinValue;
            n516TituloDataCredito_F = false;
            AssignAttri("", false, "A516TituloDataCredito_F", context.localUtil.Format(A516TituloDataCredito_F, "99/99/9999"));
         }
         pr_default.close(11);
         /* Using cursor T001516 */
         pr_default.execute(12, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A273TituloTotalMovimento_F = T001516_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = T001516_n273TituloTotalMovimento_F[0];
            AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
         }
         else
         {
            A273TituloTotalMovimento_F = 0;
            n273TituloTotalMovimento_F = false;
            AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
         }
         pr_default.close(12);
         A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         AssignAttri("", false, "A303TituloSaldoCredito_F", StringUtil.LTrimStr( A303TituloSaldoCredito_F, 18, 2));
         A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
         AssignAttri("", false, "A302TituloSaldoDebito_F", StringUtil.LTrimStr( A302TituloSaldoDebito_F, 18, 2));
         A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
         AssignAttri("", false, "A275TituloSaldo_F", StringUtil.LTrimStr( A275TituloSaldo_F, 18, 2));
         A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
         AssignAttri("", false, "A282TituloStatus_F", A282TituloStatus_F);
         /* Using cursor T001518 */
         pr_default.execute(13, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A301TituloTotalMultaJuros_F = T001518_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = T001518_n301TituloTotalMultaJuros_F[0];
         }
         else
         {
            A301TituloTotalMultaJuros_F = 0;
            n301TituloTotalMultaJuros_F = false;
            AssignAttri("", false, "A301TituloTotalMultaJuros_F", StringUtil.LTrimStr( A301TituloTotalMultaJuros_F, 18, 2));
         }
         pr_default.close(13);
         /* Using cursor T001520 */
         pr_default.execute(14, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A1119TitulosCarteiraDeCobranca = T001520_A1119TitulosCarteiraDeCobranca[0];
            n1119TitulosCarteiraDeCobranca = T001520_n1119TitulosCarteiraDeCobranca[0];
         }
         else
         {
            A1119TitulosCarteiraDeCobranca = "";
            n1119TitulosCarteiraDeCobranca = false;
            AssignAttri("", false, "A1119TitulosCarteiraDeCobranca", A1119TitulosCarteiraDeCobranca);
         }
         pr_default.close(14);
         A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
         AssignAttri("", false, "A1118TitulosEmCarteiraDeCobranca_F", A1118TitulosEmCarteiraDeCobranca_F);
         A307TituloTotalMultaJurosCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMultaJurosCredito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A307TituloTotalMultaJurosCredito_F", StringUtil.LTrimStr( A307TituloTotalMultaJurosCredito_F, 18, 2));
         A306TituloTotalMultaJurosDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMultaJurosDebito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A306TituloTotalMultaJurosDebito_F", StringUtil.LTrimStr( A306TituloTotalMultaJurosDebito_F, 18, 2));
         A305TituloTotalMovimentoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMovimentoCredito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A305TituloTotalMovimentoCredito_F", StringUtil.LTrimStr( A305TituloTotalMovimentoCredito_F, 18, 2));
         A304TituloTotalMovimentoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMovimentoDebito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A304TituloTotalMovimentoDebito_F", StringUtil.LTrimStr( A304TituloTotalMovimentoDebito_F, 18, 2));
         if ( ( A262TituloValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "TITULOVALOR");
            AnyError = 1;
            GX_FocusControl = edtTituloValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
         AssignAttri("", false, "A295TituloCompetencia_F", A295TituloCompetencia_F);
         if ( ! ( ( StringUtil.StrCmp(A283TituloTipo, "DEBITO") == 0 ) || ( StringUtil.StrCmp(A283TituloTipo, "CREDITO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A283TituloTipo)) ) )
         {
            GX_msglist.addItem("Campo Titulo Tipo fora do intervalo", "OutOfRange", 1, "TITULOTIPO");
            AnyError = 1;
            GX_FocusControl = cmbTituloTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00154 */
         pr_default.execute(2, new Object[] {n422ContaId, A422ContaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A422ContaId) ) )
            {
               GX_msglist.addItem("Não existe 'Conta'.", "ForeignKeyNotFound", 1, "CONTAID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         /* Using cursor T00155 */
         pr_default.execute(3, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A426CategoriaTituloId) ) )
            {
               GX_msglist.addItem("Não existe 'CategoriaTitulo'.", "ForeignKeyNotFound", 1, "CATEGORIATITULOID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         /* Using cursor T00156 */
         pr_default.execute(4, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (Guid.Empty==A890NotaFiscalParcelamentoID) ) )
            {
               GX_msglist.addItem("Não existe 'Nota Fiscal Parcelamento'.", "ForeignKeyNotFound", 1, "NOTAFISCALPARCELAMENTOID");
               AnyError = 1;
            }
         }
         A794NotaFiscalId = T00156_A794NotaFiscalId[0];
         n794NotaFiscalId = T00156_n794NotaFiscalId[0];
         pr_default.close(4);
         /* Using cursor T001510 */
         pr_default.execute(8, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
            }
         }
         A799NotaFiscalNumero = T001510_A799NotaFiscalNumero[0];
         n799NotaFiscalNumero = T001510_n799NotaFiscalNumero[0];
         pr_default.close(8);
         /* Using cursor T00157 */
         pr_default.execute(5, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A951ContaBancariaId) ) )
            {
               GX_msglist.addItem("Não existe 'Conta Bancaria'.", "ForeignKeyNotFound", 1, "CONTABANCARIAID");
               AnyError = 1;
            }
         }
         A938AgenciaId = T00157_A938AgenciaId[0];
         n938AgenciaId = T00157_n938AgenciaId[0];
         A953ContaBancariaCarteira = T00157_A953ContaBancariaCarteira[0];
         n953ContaBancariaCarteira = T00157_n953ContaBancariaCarteira[0];
         A952ContaBancariaNumero = T00157_A952ContaBancariaNumero[0];
         n952ContaBancariaNumero = T00157_n952ContaBancariaNumero[0];
         pr_default.close(5);
         /* Using cursor T001511 */
         pr_default.execute(9, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A938AgenciaId) ) )
            {
               GX_msglist.addItem("Não existe 'Agencia'.", "ForeignKeyNotFound", 1, "AGENCIAID");
               AnyError = 1;
            }
         }
         A968AgenciaBancoId = T001511_A968AgenciaBancoId[0];
         n968AgenciaBancoId = T001511_n968AgenciaBancoId[0];
         A939AgenciaNumero = T001511_A939AgenciaNumero[0];
         n939AgenciaNumero = T001511_n939AgenciaNumero[0];
         pr_default.close(9);
         /* Using cursor T001512 */
         pr_default.execute(10, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = T001512_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = T001512_n969AgenciaBancoNome[0];
         pr_default.close(10);
         /* Using cursor T00158 */
         pr_default.execute(6, new Object[] {n419TituloPropostaId, A419TituloPropostaId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A419TituloPropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Titulo Proposta Id'.", "ForeignKeyNotFound", 1, "TITULOPROPOSTAID");
               AnyError = 1;
            }
         }
         A971TituloPropostaDescricao = T00158_A971TituloPropostaDescricao[0];
         n971TituloPropostaDescricao = T00158_n971TituloPropostaDescricao[0];
         A501PropostaTaxaAdministrativa = T00158_A501PropostaTaxaAdministrativa[0];
         n501PropostaTaxaAdministrativa = T00158_n501PropostaTaxaAdministrativa[0];
         pr_default.close(6);
         /* Using cursor T00159 */
         pr_default.execute(7, new Object[] {n420TituloClienteId, A420TituloClienteId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A420TituloClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Titulo Cliente Id'.", "ForeignKeyNotFound", 1, "TITULOCLIENTEID");
               AnyError = 1;
            }
         }
         A972TituloCLienteRazaoSocial = T00159_A972TituloCLienteRazaoSocial[0];
         n972TituloCLienteRazaoSocial = T00159_n972TituloCLienteRazaoSocial[0];
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors1544( )
      {
         pr_default.close(11);
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(8);
         pr_default.close(5);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_41( int A261TituloId )
      {
         /* Using cursor T001527 */
         pr_default.execute(16, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            A516TituloDataCredito_F = T001527_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = T001527_n516TituloDataCredito_F[0];
         }
         else
         {
            A516TituloDataCredito_F = DateTime.MinValue;
            n516TituloDataCredito_F = false;
            AssignAttri("", false, "A516TituloDataCredito_F", context.localUtil.Format(A516TituloDataCredito_F, "99/99/9999"));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A516TituloDataCredito_F, "99/99/9999"))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_42( int A261TituloId )
      {
         /* Using cursor T001529 */
         pr_default.execute(17, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            A273TituloTotalMovimento_F = T001529_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = T001529_n273TituloTotalMovimento_F[0];
            AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
         }
         else
         {
            A273TituloTotalMovimento_F = 0;
            n273TituloTotalMovimento_F = false;
            AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A273TituloTotalMovimento_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_43( int A261TituloId )
      {
         /* Using cursor T001531 */
         pr_default.execute(18, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            A301TituloTotalMultaJuros_F = T001531_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = T001531_n301TituloTotalMultaJuros_F[0];
         }
         else
         {
            A301TituloTotalMultaJuros_F = 0;
            n301TituloTotalMultaJuros_F = false;
            AssignAttri("", false, "A301TituloTotalMultaJuros_F", StringUtil.LTrimStr( A301TituloTotalMultaJuros_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A301TituloTotalMultaJuros_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_44( int A261TituloId )
      {
         /* Using cursor T001533 */
         pr_default.execute(19, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A1119TitulosCarteiraDeCobranca = T001533_A1119TitulosCarteiraDeCobranca[0];
            n1119TitulosCarteiraDeCobranca = T001533_n1119TitulosCarteiraDeCobranca[0];
         }
         else
         {
            A1119TitulosCarteiraDeCobranca = "";
            n1119TitulosCarteiraDeCobranca = false;
            AssignAttri("", false, "A1119TitulosCarteiraDeCobranca", A1119TitulosCarteiraDeCobranca);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1119TitulosCarteiraDeCobranca)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_32( int A422ContaId )
      {
         /* Using cursor T001534 */
         pr_default.execute(20, new Object[] {n422ContaId, A422ContaId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A422ContaId) ) )
            {
               GX_msglist.addItem("Não existe 'Conta'.", "ForeignKeyNotFound", 1, "CONTAID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void gxLoad_33( int A426CategoriaTituloId )
      {
         /* Using cursor T001535 */
         pr_default.execute(21, new Object[] {n426CategoriaTituloId, A426CategoriaTituloId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A426CategoriaTituloId) ) )
            {
               GX_msglist.addItem("Não existe 'CategoriaTitulo'.", "ForeignKeyNotFound", 1, "CATEGORIATITULOID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(21) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(21);
      }

      protected void gxLoad_34( Guid A890NotaFiscalParcelamentoID )
      {
         /* Using cursor T001536 */
         pr_default.execute(22, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
         if ( (pr_default.getStatus(22) == 101) )
         {
            if ( ! ( (Guid.Empty==A890NotaFiscalParcelamentoID) ) )
            {
               GX_msglist.addItem("Não existe 'Nota Fiscal Parcelamento'.", "ForeignKeyNotFound", 1, "NOTAFISCALPARCELAMENTOID");
               AnyError = 1;
            }
         }
         A794NotaFiscalId = T001536_A794NotaFiscalId[0];
         n794NotaFiscalId = T001536_n794NotaFiscalId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A794NotaFiscalId.ToString())+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(22) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(22);
      }

      protected void gxLoad_38( Guid A794NotaFiscalId )
      {
         /* Using cursor T001537 */
         pr_default.execute(23, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
            }
         }
         A799NotaFiscalNumero = T001537_A799NotaFiscalNumero[0];
         n799NotaFiscalNumero = T001537_n799NotaFiscalNumero[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A799NotaFiscalNumero)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(23) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(23);
      }

      protected void gxLoad_35( int A951ContaBancariaId )
      {
         /* Using cursor T001538 */
         pr_default.execute(24, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A951ContaBancariaId) ) )
            {
               GX_msglist.addItem("Não existe 'Conta Bancaria'.", "ForeignKeyNotFound", 1, "CONTABANCARIAID");
               AnyError = 1;
            }
         }
         A938AgenciaId = T001538_A938AgenciaId[0];
         n938AgenciaId = T001538_n938AgenciaId[0];
         A953ContaBancariaCarteira = T001538_A953ContaBancariaCarteira[0];
         n953ContaBancariaCarteira = T001538_n953ContaBancariaCarteira[0];
         A952ContaBancariaNumero = T001538_A952ContaBancariaNumero[0];
         n952ContaBancariaNumero = T001538_n952ContaBancariaNumero[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A953ContaBancariaCarteira), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void gxLoad_39( int A938AgenciaId )
      {
         /* Using cursor T001539 */
         pr_default.execute(25, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (0==A938AgenciaId) ) )
            {
               GX_msglist.addItem("Não existe 'Agencia'.", "ForeignKeyNotFound", 1, "AGENCIAID");
               AnyError = 1;
            }
         }
         A968AgenciaBancoId = T001539_A968AgenciaBancoId[0];
         n968AgenciaBancoId = T001539_n968AgenciaBancoId[0];
         A939AgenciaNumero = T001539_A939AgenciaNumero[0];
         n939AgenciaNumero = T001539_n939AgenciaNumero[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void gxLoad_40( int A968AgenciaBancoId )
      {
         /* Using cursor T001540 */
         pr_default.execute(26, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = T001540_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = T001540_n969AgenciaBancoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A969AgenciaBancoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(26) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(26);
      }

      protected void gxLoad_36( int A419TituloPropostaId )
      {
         /* Using cursor T001541 */
         pr_default.execute(27, new Object[] {n419TituloPropostaId, A419TituloPropostaId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            if ( ! ( (0==A419TituloPropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Titulo Proposta Id'.", "ForeignKeyNotFound", 1, "TITULOPROPOSTAID");
               AnyError = 1;
            }
         }
         A971TituloPropostaDescricao = T001541_A971TituloPropostaDescricao[0];
         n971TituloPropostaDescricao = T001541_n971TituloPropostaDescricao[0];
         A501PropostaTaxaAdministrativa = T001541_A501PropostaTaxaAdministrativa[0];
         n501PropostaTaxaAdministrativa = T001541_n501PropostaTaxaAdministrativa[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A971TituloPropostaDescricao)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A501PropostaTaxaAdministrativa, 16, 4, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(27) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(27);
      }

      protected void gxLoad_37( int A420TituloClienteId )
      {
         /* Using cursor T001542 */
         pr_default.execute(28, new Object[] {n420TituloClienteId, A420TituloClienteId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            if ( ! ( (0==A420TituloClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Titulo Cliente Id'.", "ForeignKeyNotFound", 1, "TITULOCLIENTEID");
               AnyError = 1;
            }
         }
         A972TituloCLienteRazaoSocial = T001542_A972TituloCLienteRazaoSocial[0];
         n972TituloCLienteRazaoSocial = T001542_n972TituloCLienteRazaoSocial[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A972TituloCLienteRazaoSocial)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(28) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(28);
      }

      protected void GetKey1544( )
      {
         /* Using cursor T001543 */
         pr_default.execute(29, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound44 = 1;
         }
         else
         {
            RcdFound44 = 0;
         }
         pr_default.close(29);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00153 */
         pr_default.execute(1, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1544( 31) ;
            RcdFound44 = 1;
            A261TituloId = T00153_A261TituloId[0];
            n261TituloId = T00153_n261TituloId[0];
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            A262TituloValor = T00153_A262TituloValor[0];
            n262TituloValor = T00153_n262TituloValor[0];
            AssignAttri("", false, "A262TituloValor", ((Convert.ToDecimal(0)==A262TituloValor)&&IsIns( )||n262TituloValor ? "" : StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", ""))));
            A276TituloDesconto = T00153_A276TituloDesconto[0];
            n276TituloDesconto = T00153_n276TituloDesconto[0];
            AssignAttri("", false, "A276TituloDesconto", ((Convert.ToDecimal(0)==A276TituloDesconto)&&IsIns( )||n276TituloDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ".", ""))));
            A284TituloDeleted = T00153_A284TituloDeleted[0];
            n284TituloDeleted = T00153_n284TituloDeleted[0];
            AssignAttri("", false, "A284TituloDeleted", A284TituloDeleted);
            A314TituloArchived = T00153_A314TituloArchived[0];
            n314TituloArchived = T00153_n314TituloArchived[0];
            A263TituloVencimento = T00153_A263TituloVencimento[0];
            n263TituloVencimento = T00153_n263TituloVencimento[0];
            AssignAttri("", false, "A263TituloVencimento", context.localUtil.Format(A263TituloVencimento, "99/99/9999"));
            A286TituloCompetenciaAno = T00153_A286TituloCompetenciaAno[0];
            n286TituloCompetenciaAno = T00153_n286TituloCompetenciaAno[0];
            AssignAttri("", false, "A286TituloCompetenciaAno", ((0==A286TituloCompetenciaAno)&&IsIns( )||n286TituloCompetenciaAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", ""))));
            A287TituloCompetenciaMes = T00153_A287TituloCompetenciaMes[0];
            n287TituloCompetenciaMes = T00153_n287TituloCompetenciaMes[0];
            AssignAttri("", false, "A287TituloCompetenciaMes", ((0==A287TituloCompetenciaMes)&&IsIns( )||n287TituloCompetenciaMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", ""))));
            A264TituloProrrogacao = T00153_A264TituloProrrogacao[0];
            n264TituloProrrogacao = T00153_n264TituloProrrogacao[0];
            AssignAttri("", false, "A264TituloProrrogacao", context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"));
            A265TituloCEP = T00153_A265TituloCEP[0];
            n265TituloCEP = T00153_n265TituloCEP[0];
            AssignAttri("", false, "A265TituloCEP", A265TituloCEP);
            A266TituloLogradouro = T00153_A266TituloLogradouro[0];
            n266TituloLogradouro = T00153_n266TituloLogradouro[0];
            AssignAttri("", false, "A266TituloLogradouro", A266TituloLogradouro);
            A294TituloNumeroEndereco = T00153_A294TituloNumeroEndereco[0];
            n294TituloNumeroEndereco = T00153_n294TituloNumeroEndereco[0];
            AssignAttri("", false, "A294TituloNumeroEndereco", A294TituloNumeroEndereco);
            A267TituloComplemento = T00153_A267TituloComplemento[0];
            n267TituloComplemento = T00153_n267TituloComplemento[0];
            AssignAttri("", false, "A267TituloComplemento", A267TituloComplemento);
            A268TituloBairro = T00153_A268TituloBairro[0];
            n268TituloBairro = T00153_n268TituloBairro[0];
            AssignAttri("", false, "A268TituloBairro", A268TituloBairro);
            A269TituloMunicipio = T00153_A269TituloMunicipio[0];
            n269TituloMunicipio = T00153_n269TituloMunicipio[0];
            AssignAttri("", false, "A269TituloMunicipio", A269TituloMunicipio);
            A498TituloJurosMora = T00153_A498TituloJurosMora[0];
            n498TituloJurosMora = T00153_n498TituloJurosMora[0];
            A283TituloTipo = T00153_A283TituloTipo[0];
            n283TituloTipo = T00153_n283TituloTipo[0];
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
            A500TituloCriacao = T00153_A500TituloCriacao[0];
            n500TituloCriacao = T00153_n500TituloCriacao[0];
            A648TituloPropostaTipo = T00153_A648TituloPropostaTipo[0];
            n648TituloPropostaTipo = T00153_n648TituloPropostaTipo[0];
            A422ContaId = T00153_A422ContaId[0];
            n422ContaId = T00153_n422ContaId[0];
            A426CategoriaTituloId = T00153_A426CategoriaTituloId[0];
            n426CategoriaTituloId = T00153_n426CategoriaTituloId[0];
            A890NotaFiscalParcelamentoID = T00153_A890NotaFiscalParcelamentoID[0];
            n890NotaFiscalParcelamentoID = T00153_n890NotaFiscalParcelamentoID[0];
            A951ContaBancariaId = T00153_A951ContaBancariaId[0];
            n951ContaBancariaId = T00153_n951ContaBancariaId[0];
            A419TituloPropostaId = T00153_A419TituloPropostaId[0];
            n419TituloPropostaId = T00153_n419TituloPropostaId[0];
            A420TituloClienteId = T00153_A420TituloClienteId[0];
            n420TituloClienteId = T00153_n420TituloClienteId[0];
            Z261TituloId = A261TituloId;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1544( ) ;
            if ( AnyError == 1 )
            {
               RcdFound44 = 0;
               InitializeNonKey1544( ) ;
            }
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound44 = 0;
            InitializeNonKey1544( ) ;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1544( ) ;
         if ( RcdFound44 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound44 = 0;
         /* Using cursor T001544 */
         pr_default.execute(30, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(30) != 101) )
         {
            while ( (pr_default.getStatus(30) != 101) && ( ( T001544_A261TituloId[0] < A261TituloId ) ) )
            {
               pr_default.readNext(30);
            }
            if ( (pr_default.getStatus(30) != 101) && ( ( T001544_A261TituloId[0] > A261TituloId ) ) )
            {
               A261TituloId = T001544_A261TituloId[0];
               n261TituloId = T001544_n261TituloId[0];
               AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
               RcdFound44 = 1;
            }
         }
         pr_default.close(30);
      }

      protected void move_previous( )
      {
         RcdFound44 = 0;
         /* Using cursor T001545 */
         pr_default.execute(31, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(31) != 101) )
         {
            while ( (pr_default.getStatus(31) != 101) && ( ( T001545_A261TituloId[0] > A261TituloId ) ) )
            {
               pr_default.readNext(31);
            }
            if ( (pr_default.getStatus(31) != 101) && ( ( T001545_A261TituloId[0] < A261TituloId ) ) )
            {
               A261TituloId = T001545_A261TituloId[0];
               n261TituloId = T001545_n261TituloId[0];
               AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
               RcdFound44 = 1;
            }
         }
         pr_default.close(31);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1544( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTituloValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1544( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound44 == 1 )
            {
               if ( A261TituloId != Z261TituloId )
               {
                  A261TituloId = Z261TituloId;
                  n261TituloId = false;
                  AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TITULOID");
                  AnyError = 1;
                  GX_FocusControl = edtTituloId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTituloValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1544( ) ;
                  GX_FocusControl = edtTituloValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A261TituloId != Z261TituloId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTituloValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1544( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TITULOID");
                     AnyError = 1;
                     GX_FocusControl = edtTituloId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTituloValor_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1544( ) ;
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
         if ( A261TituloId != Z261TituloId )
         {
            A261TituloId = Z261TituloId;
            n261TituloId = false;
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TITULOID");
            AnyError = 1;
            GX_FocusControl = edtTituloId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTituloValor_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1544( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00152 */
            pr_default.execute(0, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Titulo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z262TituloValor != T00152_A262TituloValor[0] ) || ( Z276TituloDesconto != T00152_A276TituloDesconto[0] ) || ( Z284TituloDeleted != T00152_A284TituloDeleted[0] ) || ( Z314TituloArchived != T00152_A314TituloArchived[0] ) || ( DateTimeUtil.ResetTime ( Z263TituloVencimento ) != DateTimeUtil.ResetTime ( T00152_A263TituloVencimento[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z286TituloCompetenciaAno != T00152_A286TituloCompetenciaAno[0] ) || ( Z287TituloCompetenciaMes != T00152_A287TituloCompetenciaMes[0] ) || ( DateTimeUtil.ResetTime ( Z264TituloProrrogacao ) != DateTimeUtil.ResetTime ( T00152_A264TituloProrrogacao[0] ) ) || ( StringUtil.StrCmp(Z265TituloCEP, T00152_A265TituloCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z266TituloLogradouro, T00152_A266TituloLogradouro[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z294TituloNumeroEndereco, T00152_A294TituloNumeroEndereco[0]) != 0 ) || ( StringUtil.StrCmp(Z267TituloComplemento, T00152_A267TituloComplemento[0]) != 0 ) || ( StringUtil.StrCmp(Z268TituloBairro, T00152_A268TituloBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z269TituloMunicipio, T00152_A269TituloMunicipio[0]) != 0 ) || ( Z498TituloJurosMora != T00152_A498TituloJurosMora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z283TituloTipo, T00152_A283TituloTipo[0]) != 0 ) || ( Z500TituloCriacao != T00152_A500TituloCriacao[0] ) || ( StringUtil.StrCmp(Z648TituloPropostaTipo, T00152_A648TituloPropostaTipo[0]) != 0 ) || ( Z422ContaId != T00152_A422ContaId[0] ) || ( Z426CategoriaTituloId != T00152_A426CategoriaTituloId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z890NotaFiscalParcelamentoID != T00152_A890NotaFiscalParcelamentoID[0] ) || ( Z951ContaBancariaId != T00152_A951ContaBancariaId[0] ) || ( Z419TituloPropostaId != T00152_A419TituloPropostaId[0] ) || ( Z420TituloClienteId != T00152_A420TituloClienteId[0] ) )
            {
               if ( Z262TituloValor != T00152_A262TituloValor[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloValor");
                  GXUtil.WriteLogRaw("Old: ",Z262TituloValor);
                  GXUtil.WriteLogRaw("Current: ",T00152_A262TituloValor[0]);
               }
               if ( Z276TituloDesconto != T00152_A276TituloDesconto[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloDesconto");
                  GXUtil.WriteLogRaw("Old: ",Z276TituloDesconto);
                  GXUtil.WriteLogRaw("Current: ",T00152_A276TituloDesconto[0]);
               }
               if ( Z284TituloDeleted != T00152_A284TituloDeleted[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloDeleted");
                  GXUtil.WriteLogRaw("Old: ",Z284TituloDeleted);
                  GXUtil.WriteLogRaw("Current: ",T00152_A284TituloDeleted[0]);
               }
               if ( Z314TituloArchived != T00152_A314TituloArchived[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloArchived");
                  GXUtil.WriteLogRaw("Old: ",Z314TituloArchived);
                  GXUtil.WriteLogRaw("Current: ",T00152_A314TituloArchived[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z263TituloVencimento ) != DateTimeUtil.ResetTime ( T00152_A263TituloVencimento[0] ) )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloVencimento");
                  GXUtil.WriteLogRaw("Old: ",Z263TituloVencimento);
                  GXUtil.WriteLogRaw("Current: ",T00152_A263TituloVencimento[0]);
               }
               if ( Z286TituloCompetenciaAno != T00152_A286TituloCompetenciaAno[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloCompetenciaAno");
                  GXUtil.WriteLogRaw("Old: ",Z286TituloCompetenciaAno);
                  GXUtil.WriteLogRaw("Current: ",T00152_A286TituloCompetenciaAno[0]);
               }
               if ( Z287TituloCompetenciaMes != T00152_A287TituloCompetenciaMes[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloCompetenciaMes");
                  GXUtil.WriteLogRaw("Old: ",Z287TituloCompetenciaMes);
                  GXUtil.WriteLogRaw("Current: ",T00152_A287TituloCompetenciaMes[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z264TituloProrrogacao ) != DateTimeUtil.ResetTime ( T00152_A264TituloProrrogacao[0] ) )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloProrrogacao");
                  GXUtil.WriteLogRaw("Old: ",Z264TituloProrrogacao);
                  GXUtil.WriteLogRaw("Current: ",T00152_A264TituloProrrogacao[0]);
               }
               if ( StringUtil.StrCmp(Z265TituloCEP, T00152_A265TituloCEP[0]) != 0 )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloCEP");
                  GXUtil.WriteLogRaw("Old: ",Z265TituloCEP);
                  GXUtil.WriteLogRaw("Current: ",T00152_A265TituloCEP[0]);
               }
               if ( StringUtil.StrCmp(Z266TituloLogradouro, T00152_A266TituloLogradouro[0]) != 0 )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloLogradouro");
                  GXUtil.WriteLogRaw("Old: ",Z266TituloLogradouro);
                  GXUtil.WriteLogRaw("Current: ",T00152_A266TituloLogradouro[0]);
               }
               if ( StringUtil.StrCmp(Z294TituloNumeroEndereco, T00152_A294TituloNumeroEndereco[0]) != 0 )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloNumeroEndereco");
                  GXUtil.WriteLogRaw("Old: ",Z294TituloNumeroEndereco);
                  GXUtil.WriteLogRaw("Current: ",T00152_A294TituloNumeroEndereco[0]);
               }
               if ( StringUtil.StrCmp(Z267TituloComplemento, T00152_A267TituloComplemento[0]) != 0 )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloComplemento");
                  GXUtil.WriteLogRaw("Old: ",Z267TituloComplemento);
                  GXUtil.WriteLogRaw("Current: ",T00152_A267TituloComplemento[0]);
               }
               if ( StringUtil.StrCmp(Z268TituloBairro, T00152_A268TituloBairro[0]) != 0 )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloBairro");
                  GXUtil.WriteLogRaw("Old: ",Z268TituloBairro);
                  GXUtil.WriteLogRaw("Current: ",T00152_A268TituloBairro[0]);
               }
               if ( StringUtil.StrCmp(Z269TituloMunicipio, T00152_A269TituloMunicipio[0]) != 0 )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloMunicipio");
                  GXUtil.WriteLogRaw("Old: ",Z269TituloMunicipio);
                  GXUtil.WriteLogRaw("Current: ",T00152_A269TituloMunicipio[0]);
               }
               if ( Z498TituloJurosMora != T00152_A498TituloJurosMora[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloJurosMora");
                  GXUtil.WriteLogRaw("Old: ",Z498TituloJurosMora);
                  GXUtil.WriteLogRaw("Current: ",T00152_A498TituloJurosMora[0]);
               }
               if ( StringUtil.StrCmp(Z283TituloTipo, T00152_A283TituloTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloTipo");
                  GXUtil.WriteLogRaw("Old: ",Z283TituloTipo);
                  GXUtil.WriteLogRaw("Current: ",T00152_A283TituloTipo[0]);
               }
               if ( Z500TituloCriacao != T00152_A500TituloCriacao[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloCriacao");
                  GXUtil.WriteLogRaw("Old: ",Z500TituloCriacao);
                  GXUtil.WriteLogRaw("Current: ",T00152_A500TituloCriacao[0]);
               }
               if ( StringUtil.StrCmp(Z648TituloPropostaTipo, T00152_A648TituloPropostaTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloPropostaTipo");
                  GXUtil.WriteLogRaw("Old: ",Z648TituloPropostaTipo);
                  GXUtil.WriteLogRaw("Current: ",T00152_A648TituloPropostaTipo[0]);
               }
               if ( Z422ContaId != T00152_A422ContaId[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"ContaId");
                  GXUtil.WriteLogRaw("Old: ",Z422ContaId);
                  GXUtil.WriteLogRaw("Current: ",T00152_A422ContaId[0]);
               }
               if ( Z426CategoriaTituloId != T00152_A426CategoriaTituloId[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"CategoriaTituloId");
                  GXUtil.WriteLogRaw("Old: ",Z426CategoriaTituloId);
                  GXUtil.WriteLogRaw("Current: ",T00152_A426CategoriaTituloId[0]);
               }
               if ( Z890NotaFiscalParcelamentoID != T00152_A890NotaFiscalParcelamentoID[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"NotaFiscalParcelamentoID");
                  GXUtil.WriteLogRaw("Old: ",Z890NotaFiscalParcelamentoID);
                  GXUtil.WriteLogRaw("Current: ",T00152_A890NotaFiscalParcelamentoID[0]);
               }
               if ( Z951ContaBancariaId != T00152_A951ContaBancariaId[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"ContaBancariaId");
                  GXUtil.WriteLogRaw("Old: ",Z951ContaBancariaId);
                  GXUtil.WriteLogRaw("Current: ",T00152_A951ContaBancariaId[0]);
               }
               if ( Z419TituloPropostaId != T00152_A419TituloPropostaId[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloPropostaId");
                  GXUtil.WriteLogRaw("Old: ",Z419TituloPropostaId);
                  GXUtil.WriteLogRaw("Current: ",T00152_A419TituloPropostaId[0]);
               }
               if ( Z420TituloClienteId != T00152_A420TituloClienteId[0] )
               {
                  GXUtil.WriteLog("titulo:[seudo value changed for attri]"+"TituloClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z420TituloClienteId);
                  GXUtil.WriteLogRaw("Current: ",T00152_A420TituloClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Titulo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1544( )
      {
         BeforeValidate1544( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1544( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1544( 0) ;
            CheckOptimisticConcurrency1544( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1544( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1544( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001546 */
                     pr_default.execute(32, new Object[] {n262TituloValor, A262TituloValor, n276TituloDesconto, A276TituloDesconto, n284TituloDeleted, A284TituloDeleted, n314TituloArchived, A314TituloArchived, n263TituloVencimento, A263TituloVencimento, n286TituloCompetenciaAno, A286TituloCompetenciaAno, n287TituloCompetenciaMes, A287TituloCompetenciaMes, n264TituloProrrogacao, A264TituloProrrogacao, n265TituloCEP, A265TituloCEP, n266TituloLogradouro, A266TituloLogradouro, n294TituloNumeroEndereco, A294TituloNumeroEndereco, n267TituloComplemento, A267TituloComplemento, n268TituloBairro, A268TituloBairro, n269TituloMunicipio, A269TituloMunicipio, n498TituloJurosMora, A498TituloJurosMora, n283TituloTipo, A283TituloTipo, n500TituloCriacao, A500TituloCriacao, n648TituloPropostaTipo, A648TituloPropostaTipo, n422ContaId, A422ContaId, n426CategoriaTituloId, A426CategoriaTituloId, n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID, n951ContaBancariaId, A951ContaBancariaId, n419TituloPropostaId, A419TituloPropostaId, n420TituloClienteId, A420TituloClienteId});
                     pr_default.close(32);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001547 */
                     pr_default.execute(33);
                     A261TituloId = T001547_A261TituloId[0];
                     n261TituloId = T001547_n261TituloId[0];
                     AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
                     pr_default.close(33);
                     pr_default.SmartCacheProvider.SetUpdated("Titulo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption150( ) ;
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
               Load1544( ) ;
            }
            EndLevel1544( ) ;
         }
         CloseExtendedTableCursors1544( ) ;
      }

      protected void Update1544( )
      {
         BeforeValidate1544( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1544( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1544( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1544( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1544( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001548 */
                     pr_default.execute(34, new Object[] {n262TituloValor, A262TituloValor, n276TituloDesconto, A276TituloDesconto, n284TituloDeleted, A284TituloDeleted, n314TituloArchived, A314TituloArchived, n263TituloVencimento, A263TituloVencimento, n286TituloCompetenciaAno, A286TituloCompetenciaAno, n287TituloCompetenciaMes, A287TituloCompetenciaMes, n264TituloProrrogacao, A264TituloProrrogacao, n265TituloCEP, A265TituloCEP, n266TituloLogradouro, A266TituloLogradouro, n294TituloNumeroEndereco, A294TituloNumeroEndereco, n267TituloComplemento, A267TituloComplemento, n268TituloBairro, A268TituloBairro, n269TituloMunicipio, A269TituloMunicipio, n498TituloJurosMora, A498TituloJurosMora, n283TituloTipo, A283TituloTipo, n500TituloCriacao, A500TituloCriacao, n648TituloPropostaTipo, A648TituloPropostaTipo, n422ContaId, A422ContaId, n426CategoriaTituloId, A426CategoriaTituloId, n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID, n951ContaBancariaId, A951ContaBancariaId, n419TituloPropostaId, A419TituloPropostaId, n420TituloClienteId, A420TituloClienteId, n261TituloId, A261TituloId});
                     pr_default.close(34);
                     pr_default.SmartCacheProvider.SetUpdated("Titulo");
                     if ( (pr_default.getStatus(34) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Titulo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1544( ) ;
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
            EndLevel1544( ) ;
         }
         CloseExtendedTableCursors1544( ) ;
      }

      protected void DeferredUpdate1544( )
      {
      }

      protected void delete( )
      {
         BeforeValidate1544( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1544( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1544( ) ;
            AfterConfirm1544( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1544( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001549 */
                  pr_default.execute(35, new Object[] {n261TituloId, A261TituloId});
                  pr_default.close(35);
                  pr_default.SmartCacheProvider.SetUpdated("Titulo");
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
         sMode44 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1544( ) ;
         Gx_mode = sMode44;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1544( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001551 */
            pr_default.execute(36, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(36) != 101) )
            {
               A516TituloDataCredito_F = T001551_A516TituloDataCredito_F[0];
               n516TituloDataCredito_F = T001551_n516TituloDataCredito_F[0];
            }
            else
            {
               A516TituloDataCredito_F = DateTime.MinValue;
               n516TituloDataCredito_F = false;
               AssignAttri("", false, "A516TituloDataCredito_F", context.localUtil.Format(A516TituloDataCredito_F, "99/99/9999"));
            }
            pr_default.close(36);
            /* Using cursor T001553 */
            pr_default.execute(37, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(37) != 101) )
            {
               A273TituloTotalMovimento_F = T001553_A273TituloTotalMovimento_F[0];
               n273TituloTotalMovimento_F = T001553_n273TituloTotalMovimento_F[0];
               AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
            }
            else
            {
               A273TituloTotalMovimento_F = 0;
               n273TituloTotalMovimento_F = false;
               AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
            }
            pr_default.close(37);
            /* Using cursor T001555 */
            pr_default.execute(38, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(38) != 101) )
            {
               A301TituloTotalMultaJuros_F = T001555_A301TituloTotalMultaJuros_F[0];
               n301TituloTotalMultaJuros_F = T001555_n301TituloTotalMultaJuros_F[0];
            }
            else
            {
               A301TituloTotalMultaJuros_F = 0;
               n301TituloTotalMultaJuros_F = false;
               AssignAttri("", false, "A301TituloTotalMultaJuros_F", StringUtil.LTrimStr( A301TituloTotalMultaJuros_F, 18, 2));
            }
            pr_default.close(38);
            /* Using cursor T001557 */
            pr_default.execute(39, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(39) != 101) )
            {
               A1119TitulosCarteiraDeCobranca = T001557_A1119TitulosCarteiraDeCobranca[0];
               n1119TitulosCarteiraDeCobranca = T001557_n1119TitulosCarteiraDeCobranca[0];
            }
            else
            {
               A1119TitulosCarteiraDeCobranca = "";
               n1119TitulosCarteiraDeCobranca = false;
               AssignAttri("", false, "A1119TitulosCarteiraDeCobranca", A1119TitulosCarteiraDeCobranca);
            }
            pr_default.close(39);
            A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
            AssignAttri("", false, "A1118TitulosEmCarteiraDeCobranca_F", A1118TitulosEmCarteiraDeCobranca_F);
            A275TituloSaldo_F = (decimal)((A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F);
            AssignAttri("", false, "A275TituloSaldo_F", StringUtil.LTrimStr( A275TituloSaldo_F, 18, 2));
            A282TituloStatus_F = ((Convert.ToDecimal(0)==A275TituloSaldo_F) ? "Liquidado" : ((A275TituloSaldo_F==A262TituloValor) ? "Aberto" : "Baixado parcialmente"));
            AssignAttri("", false, "A282TituloStatus_F", A282TituloStatus_F);
            A295TituloCompetencia_F = StringUtil.Format( "%1/%2", StringUtil.PadL( StringUtil.Str( (decimal)(A287TituloCompetenciaMes), 4, 0), 2, "0"), StringUtil.LTrimStr( (decimal)(A286TituloCompetenciaAno), 4, 0), "", "", "", "", "", "", "");
            AssignAttri("", false, "A295TituloCompetencia_F", A295TituloCompetencia_F);
            A303TituloSaldoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
            AssignAttri("", false, "A303TituloSaldoCredito_F", StringUtil.LTrimStr( A303TituloSaldoCredito_F, 18, 2));
            A302TituloSaldoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? (A262TituloValor-A276TituloDesconto)-A273TituloTotalMovimento_F : (decimal)(0));
            AssignAttri("", false, "A302TituloSaldoDebito_F", StringUtil.LTrimStr( A302TituloSaldoDebito_F, 18, 2));
            A307TituloTotalMultaJurosCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMultaJurosCredito_F0( A261TituloId) : (decimal)(0));
            AssignAttri("", false, "A307TituloTotalMultaJurosCredito_F", StringUtil.LTrimStr( A307TituloTotalMultaJurosCredito_F, 18, 2));
            A306TituloTotalMultaJurosDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMultaJurosDebito_F0( A261TituloId) : (decimal)(0));
            AssignAttri("", false, "A306TituloTotalMultaJurosDebito_F", StringUtil.LTrimStr( A306TituloTotalMultaJurosDebito_F, 18, 2));
            A305TituloTotalMovimentoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMovimentoCredito_F0( A261TituloId) : (decimal)(0));
            AssignAttri("", false, "A305TituloTotalMovimentoCredito_F", StringUtil.LTrimStr( A305TituloTotalMovimentoCredito_F, 18, 2));
            A304TituloTotalMovimentoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMovimentoDebito_F0( A261TituloId) : (decimal)(0));
            AssignAttri("", false, "A304TituloTotalMovimentoDebito_F", StringUtil.LTrimStr( A304TituloTotalMovimentoDebito_F, 18, 2));
            /* Using cursor T001558 */
            pr_default.execute(40, new Object[] {n890NotaFiscalParcelamentoID, A890NotaFiscalParcelamentoID});
            A794NotaFiscalId = T001558_A794NotaFiscalId[0];
            n794NotaFiscalId = T001558_n794NotaFiscalId[0];
            pr_default.close(40);
            /* Using cursor T001559 */
            pr_default.execute(41, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            A799NotaFiscalNumero = T001559_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = T001559_n799NotaFiscalNumero[0];
            pr_default.close(41);
            /* Using cursor T001560 */
            pr_default.execute(42, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            A938AgenciaId = T001560_A938AgenciaId[0];
            n938AgenciaId = T001560_n938AgenciaId[0];
            A953ContaBancariaCarteira = T001560_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = T001560_n953ContaBancariaCarteira[0];
            A952ContaBancariaNumero = T001560_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = T001560_n952ContaBancariaNumero[0];
            pr_default.close(42);
            /* Using cursor T001561 */
            pr_default.execute(43, new Object[] {n938AgenciaId, A938AgenciaId});
            A968AgenciaBancoId = T001561_A968AgenciaBancoId[0];
            n968AgenciaBancoId = T001561_n968AgenciaBancoId[0];
            A939AgenciaNumero = T001561_A939AgenciaNumero[0];
            n939AgenciaNumero = T001561_n939AgenciaNumero[0];
            pr_default.close(43);
            /* Using cursor T001562 */
            pr_default.execute(44, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
            A969AgenciaBancoNome = T001562_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = T001562_n969AgenciaBancoNome[0];
            pr_default.close(44);
            /* Using cursor T001563 */
            pr_default.execute(45, new Object[] {n419TituloPropostaId, A419TituloPropostaId});
            A971TituloPropostaDescricao = T001563_A971TituloPropostaDescricao[0];
            n971TituloPropostaDescricao = T001563_n971TituloPropostaDescricao[0];
            A501PropostaTaxaAdministrativa = T001563_A501PropostaTaxaAdministrativa[0];
            n501PropostaTaxaAdministrativa = T001563_n501PropostaTaxaAdministrativa[0];
            pr_default.close(45);
            /* Using cursor T001564 */
            pr_default.execute(46, new Object[] {n420TituloClienteId, A420TituloClienteId});
            A972TituloCLienteRazaoSocial = T001564_A972TituloCLienteRazaoSocial[0];
            n972TituloCLienteRazaoSocial = T001564_n972TituloCLienteRazaoSocial[0];
            pr_default.close(46);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001565 */
            pr_default.execute(47, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(47) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Boleto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(47);
            /* Using cursor T001566 */
            pr_default.execute(48, new Object[] {n261TituloId, A261TituloId});
            if ( (pr_default.getStatus(48) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TituloMovimento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(48);
         }
      }

      protected void EndLevel1544( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1544( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("titulo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues150( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("titulo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1544( )
      {
         /* Scan By routine */
         /* Using cursor T001567 */
         pr_default.execute(49);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(49) != 101) )
         {
            RcdFound44 = 1;
            A261TituloId = T001567_A261TituloId[0];
            n261TituloId = T001567_n261TituloId[0];
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1544( )
      {
         /* Scan next routine */
         pr_default.readNext(49);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(49) != 101) )
         {
            RcdFound44 = 1;
            A261TituloId = T001567_A261TituloId[0];
            n261TituloId = T001567_n261TituloId[0];
            AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
         }
      }

      protected void ScanEnd1544( )
      {
         pr_default.close(49);
      }

      protected void AfterConfirm1544( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1544( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1544( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1544( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1544( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1544( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1544( )
      {
         edtTituloId_Enabled = 0;
         AssignProp("", false, edtTituloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloId_Enabled), 5, 0), true);
         edtTituloValor_Enabled = 0;
         AssignProp("", false, edtTituloValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloValor_Enabled), 5, 0), true);
         edtTituloDesconto_Enabled = 0;
         AssignProp("", false, edtTituloDesconto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloDesconto_Enabled), 5, 0), true);
         edtTituloProrrogacao_Enabled = 0;
         AssignProp("", false, edtTituloProrrogacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloProrrogacao_Enabled), 5, 0), true);
         edtTituloCompetencia_F_Enabled = 0;
         AssignProp("", false, edtTituloCompetencia_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloCompetencia_F_Enabled), 5, 0), true);
         edtTituloStatus_F_Enabled = 0;
         AssignProp("", false, edtTituloStatus_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloStatus_F_Enabled), 5, 0), true);
         cmbTituloTipo.Enabled = 0;
         AssignProp("", false, cmbTituloTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTituloTipo.Enabled), 5, 0), true);
         edtTituloSaldo_F_Enabled = 0;
         AssignProp("", false, edtTituloSaldo_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloSaldo_F_Enabled), 5, 0), true);
         edtTituloTotalMovimento_F_Enabled = 0;
         AssignProp("", false, edtTituloTotalMovimento_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloTotalMovimento_F_Enabled), 5, 0), true);
         edtTituloCEP_Enabled = 0;
         AssignProp("", false, edtTituloCEP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloCEP_Enabled), 5, 0), true);
         edtTituloLogradouro_Enabled = 0;
         AssignProp("", false, edtTituloLogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloLogradouro_Enabled), 5, 0), true);
         edtTituloNumeroEndereco_Enabled = 0;
         AssignProp("", false, edtTituloNumeroEndereco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloNumeroEndereco_Enabled), 5, 0), true);
         edtTituloComplemento_Enabled = 0;
         AssignProp("", false, edtTituloComplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloComplemento_Enabled), 5, 0), true);
         edtTituloBairro_Enabled = 0;
         AssignProp("", false, edtTituloBairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloBairro_Enabled), 5, 0), true);
         edtTituloMunicipio_Enabled = 0;
         AssignProp("", false, edtTituloMunicipio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloMunicipio_Enabled), 5, 0), true);
         edtTituloDeleted_Enabled = 0;
         AssignProp("", false, edtTituloDeleted_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloDeleted_Enabled), 5, 0), true);
         edtTituloVencimento_Enabled = 0;
         AssignProp("", false, edtTituloVencimento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloVencimento_Enabled), 5, 0), true);
         edtTituloCompetenciaAno_Enabled = 0;
         AssignProp("", false, edtTituloCompetenciaAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloCompetenciaAno_Enabled), 5, 0), true);
         edtTituloCompetenciaMes_Enabled = 0;
         AssignProp("", false, edtTituloCompetenciaMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTituloCompetenciaMes_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1544( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues150( )
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
         GXEncryptionTmp = "titulo"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TituloId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("titulo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Titulo");
         forbiddenHiddens.Add("TituloId", context.localUtil.Format( (decimal)(A261TituloId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_TituloClienteId", context.localUtil.Format( (decimal)(AV25Insert_TituloClienteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_TituloPropostaId", context.localUtil.Format( (decimal)(AV20Insert_TituloPropostaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ContaId", context.localUtil.Format( (decimal)(AV21Insert_ContaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_CategoriaTituloId", context.localUtil.Format( (decimal)(AV22Insert_CategoriaTituloId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_NotaFiscalParcelamentoID", AV23Insert_NotaFiscalParcelamentoID.ToString());
         forbiddenHiddens.Add("Insert_ContaBancariaId", context.localUtil.Format( (decimal)(AV24Insert_ContaBancariaId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("TituloArchived", StringUtil.BoolToStr( A314TituloArchived));
         forbiddenHiddens.Add("TituloJurosMora", context.localUtil.Format( A498TituloJurosMora, "Z,ZZZ,ZZZ,ZZZ,ZZ9.99%"));
         forbiddenHiddens.Add("TituloCriacao", context.localUtil.Format( A500TituloCriacao, "99/99/99 99:99"));
         forbiddenHiddens.Add("TituloPropostaTipo", StringUtil.RTrim( context.localUtil.Format( A648TituloPropostaTipo, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("titulo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z261TituloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z261TituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z262TituloValor", StringUtil.LTrim( StringUtil.NToC( Z262TituloValor, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z276TituloDesconto", StringUtil.LTrim( StringUtil.NToC( Z276TituloDesconto, 18, 2, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z284TituloDeleted", Z284TituloDeleted);
         GxWebStd.gx_boolean_hidden_field( context, "Z314TituloArchived", Z314TituloArchived);
         GxWebStd.gx_hidden_field( context, "Z263TituloVencimento", context.localUtil.DToC( Z263TituloVencimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z286TituloCompetenciaAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z286TituloCompetenciaAno), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z287TituloCompetenciaMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z287TituloCompetenciaMes), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z264TituloProrrogacao", context.localUtil.DToC( Z264TituloProrrogacao, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z265TituloCEP", Z265TituloCEP);
         GxWebStd.gx_hidden_field( context, "Z266TituloLogradouro", Z266TituloLogradouro);
         GxWebStd.gx_hidden_field( context, "Z294TituloNumeroEndereco", Z294TituloNumeroEndereco);
         GxWebStd.gx_hidden_field( context, "Z267TituloComplemento", Z267TituloComplemento);
         GxWebStd.gx_hidden_field( context, "Z268TituloBairro", Z268TituloBairro);
         GxWebStd.gx_hidden_field( context, "Z269TituloMunicipio", Z269TituloMunicipio);
         GxWebStd.gx_hidden_field( context, "Z498TituloJurosMora", StringUtil.LTrim( StringUtil.NToC( Z498TituloJurosMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z283TituloTipo", Z283TituloTipo);
         GxWebStd.gx_hidden_field( context, "Z500TituloCriacao", context.localUtil.TToC( Z500TituloCriacao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z648TituloPropostaTipo", Z648TituloPropostaTipo);
         GxWebStd.gx_hidden_field( context, "Z422ContaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z422ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z426CategoriaTituloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z426CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z890NotaFiscalParcelamentoID", Z890NotaFiscalParcelamentoID.ToString());
         GxWebStd.gx_hidden_field( context, "Z951ContaBancariaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z951ContaBancariaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z419TituloPropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z419TituloPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z420TituloClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z420TituloClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N420TituloClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A420TituloClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N419TituloPropostaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N422ContaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N426CategoriaTituloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
         GxWebStd.gx_hidden_field( context, "N951ContaBancariaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_boolean_hidden_field( context, "TITULOSEMCARTEIRADECOBRANCA_F", A1118TitulosEmCarteiraDeCobranca_F);
         GxWebStd.gx_hidden_field( context, "TITULOSALDOCREDITO_F", StringUtil.LTrim( StringUtil.NToC( A303TituloSaldoCredito_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOSALDODEBITO_F", StringUtil.LTrim( StringUtil.NToC( A302TituloSaldoDebito_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOTOTALMULTAJUROSCREDITO_F", StringUtil.LTrim( StringUtil.NToC( A307TituloTotalMultaJurosCredito_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOTOTALMULTAJUROSDEBITO_F", StringUtil.LTrim( StringUtil.NToC( A306TituloTotalMultaJurosDebito_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOTOTALMOVIMENTOCREDITO_F", StringUtil.LTrim( StringUtil.NToC( A305TituloTotalMovimentoCredito_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOTOTALMOVIMENTODEBITO_F", StringUtil.LTrim( StringUtil.NToC( A304TituloTotalMovimentoDebito_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTITULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TituloId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_TITULOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25Insert_TituloClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A420TituloClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TITULOPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20Insert_TituloPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOPROPOSTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21Insert_ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CATEGORIATITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22Insert_CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CATEGORIATITULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_NOTAFISCALPARCELAMENTOID", AV23Insert_NotaFiscalParcelamentoID.ToString());
         GxWebStd.gx_hidden_field( context, "NOTAFISCALPARCELAMENTOID", A890NotaFiscalParcelamentoID.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_CONTABANCARIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24Insert_ContaBancariaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTABANCARIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOCRIACAO", context.localUtil.TToC( A500TituloCriacao, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "TITULOARCHIVED", A314TituloArchived);
         GxWebStd.gx_hidden_field( context, "TITULOJUROSMORA", StringUtil.LTrim( StringUtil.NToC( A498TituloJurosMora, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOPROPOSTATIPO", A648TituloPropostaTipo);
         GxWebStd.gx_hidden_field( context, "NOTAFISCALID", A794NotaFiscalId.ToString());
         GxWebStd.gx_hidden_field( context, "AGENCIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A938AgenciaId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTABANCARIACARTEIRA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A953ContaBancariaCarteira), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CONTABANCARIANUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A952ContaBancariaNumero), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOPROPOSTADESCRICAO", A971TituloPropostaDescricao);
         GxWebStd.gx_hidden_field( context, "PROPOSTATAXAADMINISTRATIVA", StringUtil.LTrim( StringUtil.NToC( A501PropostaTaxaAdministrativa, 16, 4, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOCLIENTERAZAOSOCIAL", A972TituloCLienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "NOTAFISCALNUMERO", A799NotaFiscalNumero);
         GxWebStd.gx_hidden_field( context, "AGENCIABANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A968AgenciaBancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "AGENCIANUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A939AgenciaNumero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "AGENCIABANCONOME", A969AgenciaBancoNome);
         GxWebStd.gx_hidden_field( context, "TITULODATACREDITO_F", context.localUtil.DToC( A516TituloDataCredito_F, 0, "/"));
         GxWebStd.gx_hidden_field( context, "TITULOTOTALMULTAJUROS_F", StringUtil.LTrim( StringUtil.NToC( A301TituloTotalMultaJuros_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "TITULOSCARTEIRADECOBRANCA", A1119TitulosCarteiraDeCobranca);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
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
         if ( ! ( WebComp_Wctitulomovimentoww == null ) )
         {
            WebComp_Wctitulomovimentoww.componentjscripts();
         }
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
               {
                  WebComp_Wctitulomovimentoww.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
               {
                  WebComp_Wctitulomovimentoww.componentstart();
               }
            }
         }
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
         GXEncryptionTmp = "titulo"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TituloId,9,0));
         return formatLink("titulo") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Titulo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Titulo" ;
      }

      protected void InitializeNonKey1544( )
      {
         A968AgenciaBancoId = 0;
         n968AgenciaBancoId = false;
         AssignAttri("", false, "A968AgenciaBancoId", StringUtil.LTrimStr( (decimal)(A968AgenciaBancoId), 9, 0));
         A938AgenciaId = 0;
         n938AgenciaId = false;
         AssignAttri("", false, "A938AgenciaId", StringUtil.LTrimStr( (decimal)(A938AgenciaId), 9, 0));
         A794NotaFiscalId = Guid.Empty;
         n794NotaFiscalId = false;
         AssignAttri("", false, "A794NotaFiscalId", A794NotaFiscalId.ToString());
         A420TituloClienteId = 0;
         n420TituloClienteId = false;
         AssignAttri("", false, "A420TituloClienteId", ((0==A420TituloClienteId)&&IsIns( )||n420TituloClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A420TituloClienteId), 9, 0, ".", ""))));
         A419TituloPropostaId = 0;
         n419TituloPropostaId = false;
         AssignAttri("", false, "A419TituloPropostaId", ((0==A419TituloPropostaId)&&IsIns( )||n419TituloPropostaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A419TituloPropostaId), 9, 0, ".", ""))));
         A422ContaId = 0;
         n422ContaId = false;
         AssignAttri("", false, "A422ContaId", ((0==A422ContaId)&&IsIns( )||n422ContaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A422ContaId), 9, 0, ".", ""))));
         A426CategoriaTituloId = 0;
         n426CategoriaTituloId = false;
         AssignAttri("", false, "A426CategoriaTituloId", ((0==A426CategoriaTituloId)&&IsIns( )||n426CategoriaTituloId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A426CategoriaTituloId), 9, 0, ".", ""))));
         A890NotaFiscalParcelamentoID = Guid.Empty;
         n890NotaFiscalParcelamentoID = false;
         AssignAttri("", false, "A890NotaFiscalParcelamentoID", A890NotaFiscalParcelamentoID.ToString());
         A951ContaBancariaId = 0;
         n951ContaBancariaId = false;
         AssignAttri("", false, "A951ContaBancariaId", ((0==A951ContaBancariaId)&&IsIns( )||n951ContaBancariaId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A951ContaBancariaId), 9, 0, ".", ""))));
         A304TituloTotalMovimentoDebito_F = 0;
         AssignAttri("", false, "A304TituloTotalMovimentoDebito_F", StringUtil.LTrimStr( A304TituloTotalMovimentoDebito_F, 18, 2));
         A305TituloTotalMovimentoCredito_F = 0;
         AssignAttri("", false, "A305TituloTotalMovimentoCredito_F", StringUtil.LTrimStr( A305TituloTotalMovimentoCredito_F, 18, 2));
         A306TituloTotalMultaJurosDebito_F = 0;
         AssignAttri("", false, "A306TituloTotalMultaJurosDebito_F", StringUtil.LTrimStr( A306TituloTotalMultaJurosDebito_F, 18, 2));
         A307TituloTotalMultaJurosCredito_F = 0;
         AssignAttri("", false, "A307TituloTotalMultaJurosCredito_F", StringUtil.LTrimStr( A307TituloTotalMultaJurosCredito_F, 18, 2));
         A295TituloCompetencia_F = "";
         AssignAttri("", false, "A295TituloCompetencia_F", A295TituloCompetencia_F);
         A275TituloSaldo_F = 0;
         AssignAttri("", false, "A275TituloSaldo_F", StringUtil.LTrimStr( A275TituloSaldo_F, 18, 2));
         A282TituloStatus_F = "";
         AssignAttri("", false, "A282TituloStatus_F", A282TituloStatus_F);
         A302TituloSaldoDebito_F = 0;
         AssignAttri("", false, "A302TituloSaldoDebito_F", StringUtil.LTrimStr( A302TituloSaldoDebito_F, 18, 2));
         A303TituloSaldoCredito_F = 0;
         AssignAttri("", false, "A303TituloSaldoCredito_F", StringUtil.LTrimStr( A303TituloSaldoCredito_F, 18, 2));
         A972TituloCLienteRazaoSocial = "";
         n972TituloCLienteRazaoSocial = false;
         AssignAttri("", false, "A972TituloCLienteRazaoSocial", A972TituloCLienteRazaoSocial);
         A262TituloValor = 0;
         n262TituloValor = false;
         AssignAttri("", false, "A262TituloValor", ((Convert.ToDecimal(0)==A262TituloValor)&&IsIns( )||n262TituloValor ? "" : StringUtil.LTrim( StringUtil.NToC( A262TituloValor, 18, 2, ".", ""))));
         n262TituloValor = ((Convert.ToDecimal(0)==A262TituloValor) ? true : false);
         A276TituloDesconto = 0;
         n276TituloDesconto = false;
         AssignAttri("", false, "A276TituloDesconto", ((Convert.ToDecimal(0)==A276TituloDesconto)&&IsIns( )||n276TituloDesconto ? "" : StringUtil.LTrim( StringUtil.NToC( A276TituloDesconto, 18, 2, ".", ""))));
         n276TituloDesconto = ((Convert.ToDecimal(0)==A276TituloDesconto) ? true : false);
         A314TituloArchived = false;
         n314TituloArchived = false;
         AssignAttri("", false, "A314TituloArchived", A314TituloArchived);
         A263TituloVencimento = DateTime.MinValue;
         n263TituloVencimento = false;
         AssignAttri("", false, "A263TituloVencimento", context.localUtil.Format(A263TituloVencimento, "99/99/9999"));
         n263TituloVencimento = ((DateTime.MinValue==A263TituloVencimento) ? true : false);
         A286TituloCompetenciaAno = 0;
         n286TituloCompetenciaAno = false;
         AssignAttri("", false, "A286TituloCompetenciaAno", ((0==A286TituloCompetenciaAno)&&IsIns( )||n286TituloCompetenciaAno ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A286TituloCompetenciaAno), 4, 0, ".", ""))));
         n286TituloCompetenciaAno = ((0==A286TituloCompetenciaAno) ? true : false);
         A287TituloCompetenciaMes = 0;
         n287TituloCompetenciaMes = false;
         AssignAttri("", false, "A287TituloCompetenciaMes", ((0==A287TituloCompetenciaMes)&&IsIns( )||n287TituloCompetenciaMes ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A287TituloCompetenciaMes), 4, 0, ".", ""))));
         n287TituloCompetenciaMes = ((0==A287TituloCompetenciaMes) ? true : false);
         A264TituloProrrogacao = DateTime.MinValue;
         n264TituloProrrogacao = false;
         AssignAttri("", false, "A264TituloProrrogacao", context.localUtil.Format(A264TituloProrrogacao, "99/99/9999"));
         n264TituloProrrogacao = ((DateTime.MinValue==A264TituloProrrogacao) ? true : false);
         A265TituloCEP = "";
         n265TituloCEP = false;
         AssignAttri("", false, "A265TituloCEP", A265TituloCEP);
         n265TituloCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A265TituloCEP)) ? true : false);
         A266TituloLogradouro = "";
         n266TituloLogradouro = false;
         AssignAttri("", false, "A266TituloLogradouro", A266TituloLogradouro);
         n266TituloLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A266TituloLogradouro)) ? true : false);
         A294TituloNumeroEndereco = "";
         n294TituloNumeroEndereco = false;
         AssignAttri("", false, "A294TituloNumeroEndereco", A294TituloNumeroEndereco);
         n294TituloNumeroEndereco = (String.IsNullOrEmpty(StringUtil.RTrim( A294TituloNumeroEndereco)) ? true : false);
         A267TituloComplemento = "";
         n267TituloComplemento = false;
         AssignAttri("", false, "A267TituloComplemento", A267TituloComplemento);
         n267TituloComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A267TituloComplemento)) ? true : false);
         A268TituloBairro = "";
         n268TituloBairro = false;
         AssignAttri("", false, "A268TituloBairro", A268TituloBairro);
         n268TituloBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A268TituloBairro)) ? true : false);
         A269TituloMunicipio = "";
         n269TituloMunicipio = false;
         AssignAttri("", false, "A269TituloMunicipio", A269TituloMunicipio);
         n269TituloMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A269TituloMunicipio)) ? true : false);
         A498TituloJurosMora = 0;
         n498TituloJurosMora = false;
         AssignAttri("", false, "A498TituloJurosMora", ((Convert.ToDecimal(0)==A498TituloJurosMora)&&IsIns( )||n498TituloJurosMora ? "" : StringUtil.LTrim( StringUtil.NToC( A498TituloJurosMora, 16, 4, ".", ""))));
         A283TituloTipo = "";
         n283TituloTipo = false;
         AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
         n283TituloTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A283TituloTipo)) ? true : false);
         A971TituloPropostaDescricao = "";
         n971TituloPropostaDescricao = false;
         AssignAttri("", false, "A971TituloPropostaDescricao", A971TituloPropostaDescricao);
         A501PropostaTaxaAdministrativa = 0;
         n501PropostaTaxaAdministrativa = false;
         AssignAttri("", false, "A501PropostaTaxaAdministrativa", StringUtil.LTrimStr( A501PropostaTaxaAdministrativa, 16, 4));
         A516TituloDataCredito_F = DateTime.MinValue;
         n516TituloDataCredito_F = false;
         AssignAttri("", false, "A516TituloDataCredito_F", context.localUtil.Format(A516TituloDataCredito_F, "99/99/9999"));
         A273TituloTotalMovimento_F = 0;
         n273TituloTotalMovimento_F = false;
         AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrimStr( A273TituloTotalMovimento_F, 18, 2));
         A301TituloTotalMultaJuros_F = 0;
         n301TituloTotalMultaJuros_F = false;
         AssignAttri("", false, "A301TituloTotalMultaJuros_F", StringUtil.LTrimStr( A301TituloTotalMultaJuros_F, 18, 2));
         A648TituloPropostaTipo = "";
         n648TituloPropostaTipo = false;
         AssignAttri("", false, "A648TituloPropostaTipo", A648TituloPropostaTipo);
         A799NotaFiscalNumero = "";
         n799NotaFiscalNumero = false;
         AssignAttri("", false, "A799NotaFiscalNumero", A799NotaFiscalNumero);
         A969AgenciaBancoNome = "";
         n969AgenciaBancoNome = false;
         AssignAttri("", false, "A969AgenciaBancoNome", A969AgenciaBancoNome);
         A953ContaBancariaCarteira = 0;
         n953ContaBancariaCarteira = false;
         AssignAttri("", false, "A953ContaBancariaCarteira", StringUtil.LTrimStr( (decimal)(A953ContaBancariaCarteira), 10, 0));
         A952ContaBancariaNumero = 0;
         n952ContaBancariaNumero = false;
         AssignAttri("", false, "A952ContaBancariaNumero", StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0));
         A939AgenciaNumero = 0;
         n939AgenciaNumero = false;
         AssignAttri("", false, "A939AgenciaNumero", StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0));
         A1118TitulosEmCarteiraDeCobranca_F = false;
         AssignAttri("", false, "A1118TitulosEmCarteiraDeCobranca_F", A1118TitulosEmCarteiraDeCobranca_F);
         A1119TitulosCarteiraDeCobranca = "";
         n1119TitulosCarteiraDeCobranca = false;
         AssignAttri("", false, "A1119TitulosCarteiraDeCobranca", A1119TitulosCarteiraDeCobranca);
         A284TituloDeleted = false;
         n284TituloDeleted = false;
         AssignAttri("", false, "A284TituloDeleted", A284TituloDeleted);
         A500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
         n500TituloCriacao = false;
         AssignAttri("", false, "A500TituloCriacao", context.localUtil.TToC( A500TituloCriacao, 8, 5, 0, 3, "/", ":", " "));
         Z262TituloValor = 0;
         Z276TituloDesconto = 0;
         Z284TituloDeleted = false;
         Z314TituloArchived = false;
         Z263TituloVencimento = DateTime.MinValue;
         Z286TituloCompetenciaAno = 0;
         Z287TituloCompetenciaMes = 0;
         Z264TituloProrrogacao = DateTime.MinValue;
         Z265TituloCEP = "";
         Z266TituloLogradouro = "";
         Z294TituloNumeroEndereco = "";
         Z267TituloComplemento = "";
         Z268TituloBairro = "";
         Z269TituloMunicipio = "";
         Z498TituloJurosMora = 0;
         Z283TituloTipo = "";
         Z500TituloCriacao = (DateTime)(DateTime.MinValue);
         Z648TituloPropostaTipo = "";
         Z422ContaId = 0;
         Z426CategoriaTituloId = 0;
         Z890NotaFiscalParcelamentoID = Guid.Empty;
         Z951ContaBancariaId = 0;
         Z419TituloPropostaId = 0;
         Z420TituloClienteId = 0;
      }

      protected void InitAll1544( )
      {
         A261TituloId = 0;
         n261TituloId = false;
         AssignAttri("", false, "A261TituloId", StringUtil.LTrimStr( (decimal)(A261TituloId), 9, 0));
         InitializeNonKey1544( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A284TituloDeleted = i284TituloDeleted;
         n284TituloDeleted = false;
         AssignAttri("", false, "A284TituloDeleted", A284TituloDeleted);
         A500TituloCriacao = i500TituloCriacao;
         n500TituloCriacao = false;
         AssignAttri("", false, "A500TituloCriacao", context.localUtil.TToC( A500TituloCriacao, 8, 5, 0, 3, "/", ":", " "));
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wctitulomovimentoww == null ) )
         {
            if ( StringUtil.Len( WebComp_Wctitulomovimentoww_Component) != 0 )
            {
               WebComp_Wctitulomovimentoww.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20256101915380", true, true);
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
         context.AddJavascriptSource("titulo.js", "?20256101915383", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTituloId_Internalname = "TITULOID";
         edtTituloValor_Internalname = "TITULOVALOR";
         edtTituloDesconto_Internalname = "TITULODESCONTO";
         edtTituloProrrogacao_Internalname = "TITULOPRORROGACAO";
         edtTituloCompetencia_F_Internalname = "TITULOCOMPETENCIA_F";
         edtTituloStatus_F_Internalname = "TITULOSTATUS_F";
         cmbTituloTipo_Internalname = "TITULOTIPO";
         edtTituloSaldo_F_Internalname = "TITULOSALDO_F";
         edtTituloTotalMovimento_F_Internalname = "TITULOTOTALMOVIMENTO_F";
         edtTituloCEP_Internalname = "TITULOCEP";
         edtTituloLogradouro_Internalname = "TITULOLOGRADOURO";
         edtTituloNumeroEndereco_Internalname = "TITULONUMEROENDERECO";
         edtTituloComplemento_Internalname = "TITULOCOMPLEMENTO";
         edtTituloBairro_Internalname = "TITULOBAIRRO";
         edtTituloMunicipio_Internalname = "TITULOMUNICIPIO";
         divTableendereco_Internalname = "TABLEENDERECO";
         grpUnnamedgroup1_Internalname = "UNNAMEDGROUP1";
         divTablemovimentos_Internalname = "TABLEMOVIMENTOS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtTituloDeleted_Internalname = "TITULODELETED";
         edtTituloVencimento_Internalname = "TITULOVENCIMENTO";
         edtTituloCompetenciaAno_Internalname = "TITULOCOMPETENCIAANO";
         edtTituloCompetenciaMes_Internalname = "TITULOCOMPETENCIAMES";
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
         Form.Caption = "Titulo";
         edtTituloCompetenciaMes_Jsonclick = "";
         edtTituloCompetenciaMes_Enabled = 1;
         edtTituloCompetenciaMes_Visible = 1;
         edtTituloCompetenciaAno_Jsonclick = "";
         edtTituloCompetenciaAno_Enabled = 1;
         edtTituloCompetenciaAno_Visible = 1;
         edtTituloVencimento_Jsonclick = "";
         edtTituloVencimento_Enabled = 1;
         edtTituloVencimento_Visible = 1;
         edtTituloDeleted_Jsonclick = "";
         edtTituloDeleted_Enabled = 1;
         edtTituloDeleted_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTituloMunicipio_Jsonclick = "";
         edtTituloMunicipio_Enabled = 1;
         edtTituloBairro_Jsonclick = "";
         edtTituloBairro_Enabled = 1;
         edtTituloComplemento_Jsonclick = "";
         edtTituloComplemento_Enabled = 1;
         edtTituloNumeroEndereco_Jsonclick = "";
         edtTituloNumeroEndereco_Enabled = 1;
         edtTituloLogradouro_Jsonclick = "";
         edtTituloLogradouro_Enabled = 1;
         edtTituloCEP_Jsonclick = "";
         edtTituloCEP_Enabled = 1;
         edtTituloTotalMovimento_F_Jsonclick = "";
         edtTituloTotalMovimento_F_Enabled = 0;
         edtTituloSaldo_F_Jsonclick = "";
         edtTituloSaldo_F_Enabled = 0;
         cmbTituloTipo_Jsonclick = "";
         cmbTituloTipo.Enabled = 1;
         edtTituloStatus_F_Jsonclick = "";
         edtTituloStatus_F_Enabled = 0;
         edtTituloCompetencia_F_Jsonclick = "";
         edtTituloCompetencia_F_Enabled = 0;
         edtTituloProrrogacao_Jsonclick = "";
         edtTituloProrrogacao_Enabled = 1;
         edtTituloDesconto_Jsonclick = "";
         edtTituloDesconto_Enabled = 1;
         edtTituloValor_Jsonclick = "";
         edtTituloValor_Enabled = 1;
         edtTituloId_Jsonclick = "";
         edtTituloId_Enabled = 0;
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

      protected void GX4ASATITULOSEMCARTEIRADECOBRANCA_F1544( int A261TituloId )
      {
         A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
         AssignAttri("", false, "A1118TitulosEmCarteiraDeCobranca_F", A1118TitulosEmCarteiraDeCobranca_F);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A1118TitulosEmCarteiraDeCobranca_F))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX10ASATITULOTOTALMULTAJUROSCREDITO_F1544( string A283TituloTipo ,
                                                                int A261TituloId )
      {
         A307TituloTotalMultaJurosCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMultaJurosCredito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A307TituloTotalMultaJurosCredito_F", StringUtil.LTrimStr( A307TituloTotalMultaJurosCredito_F, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A307TituloTotalMultaJurosCredito_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX11ASATITULOTOTALMULTAJUROSDEBITO_F1544( string A283TituloTipo ,
                                                               int A261TituloId )
      {
         A306TituloTotalMultaJurosDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMultaJurosDebito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A306TituloTotalMultaJurosDebito_F", StringUtil.LTrimStr( A306TituloTotalMultaJurosDebito_F, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A306TituloTotalMultaJurosDebito_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX12ASATITULOTOTALMOVIMENTOCREDITO_F1544( string A283TituloTipo ,
                                                               int A261TituloId )
      {
         A305TituloTotalMovimentoCredito_F = ((StringUtil.StrCmp(A283TituloTipo, "CREDITO")==0) ? GetTituloTotalMovimentoCredito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A305TituloTotalMovimentoCredito_F", StringUtil.LTrimStr( A305TituloTotalMovimentoCredito_F, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A305TituloTotalMovimentoCredito_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX13ASATITULOTOTALMOVIMENTODEBITO_F1544( string A283TituloTipo ,
                                                              int A261TituloId )
      {
         A304TituloTotalMovimentoDebito_F = ((StringUtil.StrCmp(A283TituloTipo, "DEBITO")==0) ? GetTituloTotalMovimentoDebito_F0( A261TituloId) : (decimal)(0));
         AssignAttri("", false, "A304TituloTotalMovimentoDebito_F", StringUtil.LTrimStr( A304TituloTotalMovimentoDebito_F, 18, 2));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A304TituloTotalMovimentoDebito_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbTituloTipo.Name = "TITULOTIPO";
         cmbTituloTipo.WebTags = "";
         cmbTituloTipo.addItem("DEBITO", "Débito", 0);
         cmbTituloTipo.addItem("CREDITO", "Crédito", 0);
         if ( cmbTituloTipo.ItemCount > 0 )
         {
            A283TituloTipo = cmbTituloTipo.getValidValue(A283TituloTipo);
            n283TituloTipo = false;
            AssignAttri("", false, "A283TituloTipo", A283TituloTipo);
         }
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

      public void Valid_Tituloid( )
      {
         n261TituloId = false;
         n516TituloDataCredito_F = false;
         n273TituloTotalMovimento_F = false;
         n301TituloTotalMultaJuros_F = false;
         n1119TitulosCarteiraDeCobranca = false;
         /* Using cursor T001551 */
         pr_default.execute(36, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(36) != 101) )
         {
            A516TituloDataCredito_F = T001551_A516TituloDataCredito_F[0];
            n516TituloDataCredito_F = T001551_n516TituloDataCredito_F[0];
         }
         else
         {
            A516TituloDataCredito_F = DateTime.MinValue;
            n516TituloDataCredito_F = false;
         }
         pr_default.close(36);
         /* Using cursor T001553 */
         pr_default.execute(37, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(37) != 101) )
         {
            A273TituloTotalMovimento_F = T001553_A273TituloTotalMovimento_F[0];
            n273TituloTotalMovimento_F = T001553_n273TituloTotalMovimento_F[0];
         }
         else
         {
            A273TituloTotalMovimento_F = 0;
            n273TituloTotalMovimento_F = false;
         }
         pr_default.close(37);
         /* Using cursor T001555 */
         pr_default.execute(38, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(38) != 101) )
         {
            A301TituloTotalMultaJuros_F = T001555_A301TituloTotalMultaJuros_F[0];
            n301TituloTotalMultaJuros_F = T001555_n301TituloTotalMultaJuros_F[0];
         }
         else
         {
            A301TituloTotalMultaJuros_F = 0;
            n301TituloTotalMultaJuros_F = false;
         }
         pr_default.close(38);
         /* Using cursor T001557 */
         pr_default.execute(39, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(39) != 101) )
         {
            A1119TitulosCarteiraDeCobranca = T001557_A1119TitulosCarteiraDeCobranca[0];
            n1119TitulosCarteiraDeCobranca = T001557_n1119TitulosCarteiraDeCobranca[0];
         }
         else
         {
            A1119TitulosCarteiraDeCobranca = "";
            n1119TitulosCarteiraDeCobranca = false;
         }
         pr_default.close(39);
         A1118TitulosEmCarteiraDeCobranca_F = ((GetTitulosEmCarteiraDeCobranca_F0( A261TituloId)==0) ? false : true);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A516TituloDataCredito_F", context.localUtil.Format(A516TituloDataCredito_F, "99/99/9999"));
         AssignAttri("", false, "A273TituloTotalMovimento_F", StringUtil.LTrim( StringUtil.NToC( A273TituloTotalMovimento_F, 18, 2, ".", "")));
         AssignAttri("", false, "A301TituloTotalMultaJuros_F", StringUtil.LTrim( StringUtil.NToC( A301TituloTotalMultaJuros_F, 18, 2, ".", "")));
         AssignAttri("", false, "A1119TitulosCarteiraDeCobranca", A1119TitulosCarteiraDeCobranca);
         AssignAttri("", false, "A1118TitulosEmCarteiraDeCobranca_F", A1118TitulosEmCarteiraDeCobranca_F);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7TituloId","fld":"vTITULOID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV25Insert_TituloClienteId","fld":"vINSERT_TITULOCLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV20Insert_TituloPropostaId","fld":"vINSERT_TITULOPROPOSTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV21Insert_ContaId","fld":"vINSERT_CONTAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV22Insert_CategoriaTituloId","fld":"vINSERT_CATEGORIATITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV23Insert_NotaFiscalParcelamentoID","fld":"vINSERT_NOTAFISCALPARCELAMENTOID","type":"guid"},{"av":"AV24Insert_ContaBancariaId","fld":"vINSERT_CONTABANCARIAID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A314TituloArchived","fld":"TITULOARCHIVED","type":"boolean"},{"av":"A498TituloJurosMora","fld":"TITULOJUROSMORA","pic":"Z,ZZZ,ZZZ,ZZZ,ZZ9.99%","nullAv":"n498TituloJurosMora","type":"decimal"},{"av":"A500TituloCriacao","fld":"TITULOCRIACAO","pic":"99/99/99 99:99","type":"dtime"},{"av":"A648TituloPropostaTipo","fld":"TITULOPROPOSTATIPO","type":"svchar"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E12152","iparms":[]}""");
         setEventMetadata("VALID_TITULOID","""{"handler":"Valid_Tituloid","iparms":[{"av":"A261TituloId","fld":"TITULOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A516TituloDataCredito_F","fld":"TITULODATACREDITO_F","type":"date"},{"av":"A273TituloTotalMovimento_F","fld":"TITULOTOTALMOVIMENTO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A301TituloTotalMultaJuros_F","fld":"TITULOTOTALMULTAJUROS_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A1119TitulosCarteiraDeCobranca","fld":"TITULOSCARTEIRADECOBRANCA","type":"svchar"},{"av":"A1118TitulosEmCarteiraDeCobranca_F","fld":"TITULOSEMCARTEIRADECOBRANCA_F","type":"boolean"}]""");
         setEventMetadata("VALID_TITULOID",""","oparms":[{"av":"A516TituloDataCredito_F","fld":"TITULODATACREDITO_F","type":"date"},{"av":"A273TituloTotalMovimento_F","fld":"TITULOTOTALMOVIMENTO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A301TituloTotalMultaJuros_F","fld":"TITULOTOTALMULTAJUROS_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A1119TitulosCarteiraDeCobranca","fld":"TITULOSCARTEIRADECOBRANCA","type":"svchar"},{"av":"A1118TitulosEmCarteiraDeCobranca_F","fld":"TITULOSEMCARTEIRADECOBRANCA_F","type":"boolean"}]}""");
         setEventMetadata("VALID_TITULOVALOR","""{"handler":"Valid_Titulovalor","iparms":[]}""");
         setEventMetadata("VALID_TITULODESCONTO","""{"handler":"Valid_Titulodesconto","iparms":[]}""");
         setEventMetadata("VALID_TITULOTIPO","""{"handler":"Valid_Titulotipo","iparms":[]}""");
         setEventMetadata("VALID_TITULOSALDO_F","""{"handler":"Valid_Titulosaldo_f","iparms":[]}""");
         setEventMetadata("VALID_TITULOTOTALMOVIMENTO_F","""{"handler":"Valid_Titulototalmovimento_f","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIAANO","""{"handler":"Valid_Titulocompetenciaano","iparms":[]}""");
         setEventMetadata("VALID_TITULOCOMPETENCIAMES","""{"handler":"Valid_Titulocompetenciames","iparms":[]}""");
         return  ;
      }

      protected decimal GetTituloTotalMovimentoDebito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor T001568 */
         pr_default.execute(50, new Object[] {nA261TituloId, E261TituloId});
         if ( (pr_default.getStatus(50) != 101) )
         {
            X271TituloMovimentoValor = T001568_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = T001568_n271TituloMovimentoValor[0];
         }
         pr_default.close(50);
         return X271TituloMovimentoValor ;
      }

      protected decimal GetTituloTotalMovimentoCredito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor T001569 */
         pr_default.execute(51, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(51) != 101) )
         {
            X271TituloMovimentoValor = T001569_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = T001569_n271TituloMovimentoValor[0];
         }
         pr_default.close(51);
         return X271TituloMovimentoValor ;
      }

      protected decimal GetTituloTotalMultaJurosDebito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor T001570 */
         pr_default.execute(52, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(52) != 101) )
         {
            X271TituloMovimentoValor = T001570_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = T001570_n271TituloMovimentoValor[0];
         }
         pr_default.close(52);
         return X271TituloMovimentoValor ;
      }

      protected decimal GetTituloTotalMultaJurosCredito_F0( int E261TituloId )
      {
         X271TituloMovimentoValor = 0;
         /* Using cursor T001571 */
         pr_default.execute(53, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(53) != 101) )
         {
            X271TituloMovimentoValor = T001571_A271TituloMovimentoValor[0];
            nX271TituloMovimentoValor = T001571_n271TituloMovimentoValor[0];
         }
         pr_default.close(53);
         return X271TituloMovimentoValor ;
      }

      protected int GetTitulosEmCarteiraDeCobranca_F0( int E261TituloId )
      {
         Gx_cnt = 0;
         /* Using cursor T001572 */
         pr_default.execute(54, new Object[] {nE261TituloId, E261TituloId});
         if ( (pr_default.getStatus(54) != 101) )
         {
            Gx_cnt = T001572_Gx_cnt[0];
         }
         pr_default.close(54);
         return Gx_cnt ;
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
         pr_default.close(40);
         pr_default.close(42);
         pr_default.close(45);
         pr_default.close(46);
         pr_default.close(41);
         pr_default.close(43);
         pr_default.close(44);
         pr_default.close(36);
         pr_default.close(37);
         pr_default.close(38);
         pr_default.close(39);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z263TituloVencimento = DateTime.MinValue;
         Z264TituloProrrogacao = DateTime.MinValue;
         Z265TituloCEP = "";
         Z266TituloLogradouro = "";
         Z294TituloNumeroEndereco = "";
         Z267TituloComplemento = "";
         Z268TituloBairro = "";
         Z269TituloMunicipio = "";
         Z283TituloTipo = "";
         Z500TituloCriacao = (DateTime)(DateTime.MinValue);
         Z648TituloPropostaTipo = "";
         Z890NotaFiscalParcelamentoID = Guid.Empty;
         N890NotaFiscalParcelamentoID = Guid.Empty;
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A283TituloTipo = "";
         A890NotaFiscalParcelamentoID = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
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
         A264TituloProrrogacao = DateTime.MinValue;
         A295TituloCompetencia_F = "";
         A282TituloStatus_F = "";
         A265TituloCEP = "";
         A266TituloLogradouro = "";
         A294TituloNumeroEndereco = "";
         A267TituloComplemento = "";
         A268TituloBairro = "";
         A269TituloMunicipio = "";
         WebComp_Wctitulomovimentoww_Component = "";
         OldWctitulomovimentoww = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         A263TituloVencimento = DateTime.MinValue;
         A500TituloCriacao = (DateTime)(DateTime.MinValue);
         A648TituloPropostaTipo = "";
         AV23Insert_NotaFiscalParcelamentoID = Guid.Empty;
         A971TituloPropostaDescricao = "";
         A972TituloCLienteRazaoSocial = "";
         A799NotaFiscalNumero = "";
         A969AgenciaBancoNome = "";
         A516TituloDataCredito_F = DateTime.MinValue;
         A1119TitulosCarteiraDeCobranca = "";
         AV27Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode44 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z794NotaFiscalId = Guid.Empty;
         Z799NotaFiscalNumero = "";
         Z969AgenciaBancoNome = "";
         Z971TituloPropostaDescricao = "";
         Z972TituloCLienteRazaoSocial = "";
         Z516TituloDataCredito_F = DateTime.MinValue;
         Z1119TitulosCarteiraDeCobranca = "";
         T001514_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         T001514_n516TituloDataCredito_F = new bool[] {false} ;
         T001516_A273TituloTotalMovimento_F = new decimal[1] ;
         T001516_n273TituloTotalMovimento_F = new bool[] {false} ;
         T001518_A301TituloTotalMultaJuros_F = new decimal[1] ;
         T001518_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         T001520_A1119TitulosCarteiraDeCobranca = new string[] {""} ;
         T001520_n1119TitulosCarteiraDeCobranca = new bool[] {false} ;
         T00159_A972TituloCLienteRazaoSocial = new string[] {""} ;
         T00159_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         T001525_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T001525_n794NotaFiscalId = new bool[] {false} ;
         T001525_A938AgenciaId = new int[1] ;
         T001525_n938AgenciaId = new bool[] {false} ;
         T001525_A968AgenciaBancoId = new int[1] ;
         T001525_n968AgenciaBancoId = new bool[] {false} ;
         T001525_A261TituloId = new int[1] ;
         T001525_n261TituloId = new bool[] {false} ;
         T001525_A972TituloCLienteRazaoSocial = new string[] {""} ;
         T001525_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         T001525_A262TituloValor = new decimal[1] ;
         T001525_n262TituloValor = new bool[] {false} ;
         T001525_A276TituloDesconto = new decimal[1] ;
         T001525_n276TituloDesconto = new bool[] {false} ;
         T001525_A284TituloDeleted = new bool[] {false} ;
         T001525_n284TituloDeleted = new bool[] {false} ;
         T001525_A314TituloArchived = new bool[] {false} ;
         T001525_n314TituloArchived = new bool[] {false} ;
         T001525_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         T001525_n263TituloVencimento = new bool[] {false} ;
         T001525_A286TituloCompetenciaAno = new short[1] ;
         T001525_n286TituloCompetenciaAno = new bool[] {false} ;
         T001525_A287TituloCompetenciaMes = new short[1] ;
         T001525_n287TituloCompetenciaMes = new bool[] {false} ;
         T001525_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         T001525_n264TituloProrrogacao = new bool[] {false} ;
         T001525_A265TituloCEP = new string[] {""} ;
         T001525_n265TituloCEP = new bool[] {false} ;
         T001525_A266TituloLogradouro = new string[] {""} ;
         T001525_n266TituloLogradouro = new bool[] {false} ;
         T001525_A294TituloNumeroEndereco = new string[] {""} ;
         T001525_n294TituloNumeroEndereco = new bool[] {false} ;
         T001525_A267TituloComplemento = new string[] {""} ;
         T001525_n267TituloComplemento = new bool[] {false} ;
         T001525_A268TituloBairro = new string[] {""} ;
         T001525_n268TituloBairro = new bool[] {false} ;
         T001525_A269TituloMunicipio = new string[] {""} ;
         T001525_n269TituloMunicipio = new bool[] {false} ;
         T001525_A498TituloJurosMora = new decimal[1] ;
         T001525_n498TituloJurosMora = new bool[] {false} ;
         T001525_A283TituloTipo = new string[] {""} ;
         T001525_n283TituloTipo = new bool[] {false} ;
         T001525_A971TituloPropostaDescricao = new string[] {""} ;
         T001525_n971TituloPropostaDescricao = new bool[] {false} ;
         T001525_A501PropostaTaxaAdministrativa = new decimal[1] ;
         T001525_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         T001525_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         T001525_n500TituloCriacao = new bool[] {false} ;
         T001525_A648TituloPropostaTipo = new string[] {""} ;
         T001525_n648TituloPropostaTipo = new bool[] {false} ;
         T001525_A799NotaFiscalNumero = new string[] {""} ;
         T001525_n799NotaFiscalNumero = new bool[] {false} ;
         T001525_A969AgenciaBancoNome = new string[] {""} ;
         T001525_n969AgenciaBancoNome = new bool[] {false} ;
         T001525_A953ContaBancariaCarteira = new long[1] ;
         T001525_n953ContaBancariaCarteira = new bool[] {false} ;
         T001525_A952ContaBancariaNumero = new long[1] ;
         T001525_n952ContaBancariaNumero = new bool[] {false} ;
         T001525_A939AgenciaNumero = new int[1] ;
         T001525_n939AgenciaNumero = new bool[] {false} ;
         T001525_A422ContaId = new int[1] ;
         T001525_n422ContaId = new bool[] {false} ;
         T001525_A426CategoriaTituloId = new int[1] ;
         T001525_n426CategoriaTituloId = new bool[] {false} ;
         T001525_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T001525_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         T001525_A951ContaBancariaId = new int[1] ;
         T001525_n951ContaBancariaId = new bool[] {false} ;
         T001525_A419TituloPropostaId = new int[1] ;
         T001525_n419TituloPropostaId = new bool[] {false} ;
         T001525_A420TituloClienteId = new int[1] ;
         T001525_n420TituloClienteId = new bool[] {false} ;
         T001525_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         T001525_n516TituloDataCredito_F = new bool[] {false} ;
         T001525_A273TituloTotalMovimento_F = new decimal[1] ;
         T001525_n273TituloTotalMovimento_F = new bool[] {false} ;
         T001525_A301TituloTotalMultaJuros_F = new decimal[1] ;
         T001525_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         T001525_A1119TitulosCarteiraDeCobranca = new string[] {""} ;
         T001525_n1119TitulosCarteiraDeCobranca = new bool[] {false} ;
         T00154_A422ContaId = new int[1] ;
         T00154_n422ContaId = new bool[] {false} ;
         T00155_A426CategoriaTituloId = new int[1] ;
         T00155_n426CategoriaTituloId = new bool[] {false} ;
         T00156_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T00156_n794NotaFiscalId = new bool[] {false} ;
         T001510_A799NotaFiscalNumero = new string[] {""} ;
         T001510_n799NotaFiscalNumero = new bool[] {false} ;
         T00157_A938AgenciaId = new int[1] ;
         T00157_n938AgenciaId = new bool[] {false} ;
         T00157_A953ContaBancariaCarteira = new long[1] ;
         T00157_n953ContaBancariaCarteira = new bool[] {false} ;
         T00157_A952ContaBancariaNumero = new long[1] ;
         T00157_n952ContaBancariaNumero = new bool[] {false} ;
         T001511_A968AgenciaBancoId = new int[1] ;
         T001511_n968AgenciaBancoId = new bool[] {false} ;
         T001511_A939AgenciaNumero = new int[1] ;
         T001511_n939AgenciaNumero = new bool[] {false} ;
         T001512_A969AgenciaBancoNome = new string[] {""} ;
         T001512_n969AgenciaBancoNome = new bool[] {false} ;
         T00158_A971TituloPropostaDescricao = new string[] {""} ;
         T00158_n971TituloPropostaDescricao = new bool[] {false} ;
         T00158_A501PropostaTaxaAdministrativa = new decimal[1] ;
         T00158_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         T001527_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         T001527_n516TituloDataCredito_F = new bool[] {false} ;
         T001529_A273TituloTotalMovimento_F = new decimal[1] ;
         T001529_n273TituloTotalMovimento_F = new bool[] {false} ;
         T001531_A301TituloTotalMultaJuros_F = new decimal[1] ;
         T001531_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         T001533_A1119TitulosCarteiraDeCobranca = new string[] {""} ;
         T001533_n1119TitulosCarteiraDeCobranca = new bool[] {false} ;
         T001534_A422ContaId = new int[1] ;
         T001534_n422ContaId = new bool[] {false} ;
         T001535_A426CategoriaTituloId = new int[1] ;
         T001535_n426CategoriaTituloId = new bool[] {false} ;
         T001536_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T001536_n794NotaFiscalId = new bool[] {false} ;
         T001537_A799NotaFiscalNumero = new string[] {""} ;
         T001537_n799NotaFiscalNumero = new bool[] {false} ;
         T001538_A938AgenciaId = new int[1] ;
         T001538_n938AgenciaId = new bool[] {false} ;
         T001538_A953ContaBancariaCarteira = new long[1] ;
         T001538_n953ContaBancariaCarteira = new bool[] {false} ;
         T001538_A952ContaBancariaNumero = new long[1] ;
         T001538_n952ContaBancariaNumero = new bool[] {false} ;
         T001539_A968AgenciaBancoId = new int[1] ;
         T001539_n968AgenciaBancoId = new bool[] {false} ;
         T001539_A939AgenciaNumero = new int[1] ;
         T001539_n939AgenciaNumero = new bool[] {false} ;
         T001540_A969AgenciaBancoNome = new string[] {""} ;
         T001540_n969AgenciaBancoNome = new bool[] {false} ;
         T001541_A971TituloPropostaDescricao = new string[] {""} ;
         T001541_n971TituloPropostaDescricao = new bool[] {false} ;
         T001541_A501PropostaTaxaAdministrativa = new decimal[1] ;
         T001541_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         T001542_A972TituloCLienteRazaoSocial = new string[] {""} ;
         T001542_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         T001543_A261TituloId = new int[1] ;
         T001543_n261TituloId = new bool[] {false} ;
         T00153_A261TituloId = new int[1] ;
         T00153_n261TituloId = new bool[] {false} ;
         T00153_A262TituloValor = new decimal[1] ;
         T00153_n262TituloValor = new bool[] {false} ;
         T00153_A276TituloDesconto = new decimal[1] ;
         T00153_n276TituloDesconto = new bool[] {false} ;
         T00153_A284TituloDeleted = new bool[] {false} ;
         T00153_n284TituloDeleted = new bool[] {false} ;
         T00153_A314TituloArchived = new bool[] {false} ;
         T00153_n314TituloArchived = new bool[] {false} ;
         T00153_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         T00153_n263TituloVencimento = new bool[] {false} ;
         T00153_A286TituloCompetenciaAno = new short[1] ;
         T00153_n286TituloCompetenciaAno = new bool[] {false} ;
         T00153_A287TituloCompetenciaMes = new short[1] ;
         T00153_n287TituloCompetenciaMes = new bool[] {false} ;
         T00153_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         T00153_n264TituloProrrogacao = new bool[] {false} ;
         T00153_A265TituloCEP = new string[] {""} ;
         T00153_n265TituloCEP = new bool[] {false} ;
         T00153_A266TituloLogradouro = new string[] {""} ;
         T00153_n266TituloLogradouro = new bool[] {false} ;
         T00153_A294TituloNumeroEndereco = new string[] {""} ;
         T00153_n294TituloNumeroEndereco = new bool[] {false} ;
         T00153_A267TituloComplemento = new string[] {""} ;
         T00153_n267TituloComplemento = new bool[] {false} ;
         T00153_A268TituloBairro = new string[] {""} ;
         T00153_n268TituloBairro = new bool[] {false} ;
         T00153_A269TituloMunicipio = new string[] {""} ;
         T00153_n269TituloMunicipio = new bool[] {false} ;
         T00153_A498TituloJurosMora = new decimal[1] ;
         T00153_n498TituloJurosMora = new bool[] {false} ;
         T00153_A283TituloTipo = new string[] {""} ;
         T00153_n283TituloTipo = new bool[] {false} ;
         T00153_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         T00153_n500TituloCriacao = new bool[] {false} ;
         T00153_A648TituloPropostaTipo = new string[] {""} ;
         T00153_n648TituloPropostaTipo = new bool[] {false} ;
         T00153_A422ContaId = new int[1] ;
         T00153_n422ContaId = new bool[] {false} ;
         T00153_A426CategoriaTituloId = new int[1] ;
         T00153_n426CategoriaTituloId = new bool[] {false} ;
         T00153_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T00153_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         T00153_A951ContaBancariaId = new int[1] ;
         T00153_n951ContaBancariaId = new bool[] {false} ;
         T00153_A419TituloPropostaId = new int[1] ;
         T00153_n419TituloPropostaId = new bool[] {false} ;
         T00153_A420TituloClienteId = new int[1] ;
         T00153_n420TituloClienteId = new bool[] {false} ;
         T001544_A261TituloId = new int[1] ;
         T001544_n261TituloId = new bool[] {false} ;
         T001545_A261TituloId = new int[1] ;
         T001545_n261TituloId = new bool[] {false} ;
         T00152_A261TituloId = new int[1] ;
         T00152_n261TituloId = new bool[] {false} ;
         T00152_A262TituloValor = new decimal[1] ;
         T00152_n262TituloValor = new bool[] {false} ;
         T00152_A276TituloDesconto = new decimal[1] ;
         T00152_n276TituloDesconto = new bool[] {false} ;
         T00152_A284TituloDeleted = new bool[] {false} ;
         T00152_n284TituloDeleted = new bool[] {false} ;
         T00152_A314TituloArchived = new bool[] {false} ;
         T00152_n314TituloArchived = new bool[] {false} ;
         T00152_A263TituloVencimento = new DateTime[] {DateTime.MinValue} ;
         T00152_n263TituloVencimento = new bool[] {false} ;
         T00152_A286TituloCompetenciaAno = new short[1] ;
         T00152_n286TituloCompetenciaAno = new bool[] {false} ;
         T00152_A287TituloCompetenciaMes = new short[1] ;
         T00152_n287TituloCompetenciaMes = new bool[] {false} ;
         T00152_A264TituloProrrogacao = new DateTime[] {DateTime.MinValue} ;
         T00152_n264TituloProrrogacao = new bool[] {false} ;
         T00152_A265TituloCEP = new string[] {""} ;
         T00152_n265TituloCEP = new bool[] {false} ;
         T00152_A266TituloLogradouro = new string[] {""} ;
         T00152_n266TituloLogradouro = new bool[] {false} ;
         T00152_A294TituloNumeroEndereco = new string[] {""} ;
         T00152_n294TituloNumeroEndereco = new bool[] {false} ;
         T00152_A267TituloComplemento = new string[] {""} ;
         T00152_n267TituloComplemento = new bool[] {false} ;
         T00152_A268TituloBairro = new string[] {""} ;
         T00152_n268TituloBairro = new bool[] {false} ;
         T00152_A269TituloMunicipio = new string[] {""} ;
         T00152_n269TituloMunicipio = new bool[] {false} ;
         T00152_A498TituloJurosMora = new decimal[1] ;
         T00152_n498TituloJurosMora = new bool[] {false} ;
         T00152_A283TituloTipo = new string[] {""} ;
         T00152_n283TituloTipo = new bool[] {false} ;
         T00152_A500TituloCriacao = new DateTime[] {DateTime.MinValue} ;
         T00152_n500TituloCriacao = new bool[] {false} ;
         T00152_A648TituloPropostaTipo = new string[] {""} ;
         T00152_n648TituloPropostaTipo = new bool[] {false} ;
         T00152_A422ContaId = new int[1] ;
         T00152_n422ContaId = new bool[] {false} ;
         T00152_A426CategoriaTituloId = new int[1] ;
         T00152_n426CategoriaTituloId = new bool[] {false} ;
         T00152_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         T00152_n890NotaFiscalParcelamentoID = new bool[] {false} ;
         T00152_A951ContaBancariaId = new int[1] ;
         T00152_n951ContaBancariaId = new bool[] {false} ;
         T00152_A419TituloPropostaId = new int[1] ;
         T00152_n419TituloPropostaId = new bool[] {false} ;
         T00152_A420TituloClienteId = new int[1] ;
         T00152_n420TituloClienteId = new bool[] {false} ;
         T001547_A261TituloId = new int[1] ;
         T001547_n261TituloId = new bool[] {false} ;
         T001551_A516TituloDataCredito_F = new DateTime[] {DateTime.MinValue} ;
         T001551_n516TituloDataCredito_F = new bool[] {false} ;
         T001553_A273TituloTotalMovimento_F = new decimal[1] ;
         T001553_n273TituloTotalMovimento_F = new bool[] {false} ;
         T001555_A301TituloTotalMultaJuros_F = new decimal[1] ;
         T001555_n301TituloTotalMultaJuros_F = new bool[] {false} ;
         T001557_A1119TitulosCarteiraDeCobranca = new string[] {""} ;
         T001557_n1119TitulosCarteiraDeCobranca = new bool[] {false} ;
         T001558_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T001558_n794NotaFiscalId = new bool[] {false} ;
         T001559_A799NotaFiscalNumero = new string[] {""} ;
         T001559_n799NotaFiscalNumero = new bool[] {false} ;
         T001560_A938AgenciaId = new int[1] ;
         T001560_n938AgenciaId = new bool[] {false} ;
         T001560_A953ContaBancariaCarteira = new long[1] ;
         T001560_n953ContaBancariaCarteira = new bool[] {false} ;
         T001560_A952ContaBancariaNumero = new long[1] ;
         T001560_n952ContaBancariaNumero = new bool[] {false} ;
         T001561_A968AgenciaBancoId = new int[1] ;
         T001561_n968AgenciaBancoId = new bool[] {false} ;
         T001561_A939AgenciaNumero = new int[1] ;
         T001561_n939AgenciaNumero = new bool[] {false} ;
         T001562_A969AgenciaBancoNome = new string[] {""} ;
         T001562_n969AgenciaBancoNome = new bool[] {false} ;
         T001563_A971TituloPropostaDescricao = new string[] {""} ;
         T001563_n971TituloPropostaDescricao = new bool[] {false} ;
         T001563_A501PropostaTaxaAdministrativa = new decimal[1] ;
         T001563_n501PropostaTaxaAdministrativa = new bool[] {false} ;
         T001564_A972TituloCLienteRazaoSocial = new string[] {""} ;
         T001564_n972TituloCLienteRazaoSocial = new bool[] {false} ;
         T001565_A1077BoletosId = new int[1] ;
         T001566_A270TituloMovimentoId = new int[1] ;
         T001567_A261TituloId = new int[1] ;
         T001567_n261TituloId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i500TituloCriacao = (DateTime)(DateTime.MinValue);
         T001568_A271TituloMovimentoValor = new decimal[1] ;
         T001568_n271TituloMovimentoValor = new bool[] {false} ;
         T001569_A271TituloMovimentoValor = new decimal[1] ;
         T001569_n271TituloMovimentoValor = new bool[] {false} ;
         T001570_A271TituloMovimentoValor = new decimal[1] ;
         T001570_n271TituloMovimentoValor = new bool[] {false} ;
         T001571_A271TituloMovimentoValor = new decimal[1] ;
         T001571_n271TituloMovimentoValor = new bool[] {false} ;
         T001572_Gx_cnt = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.titulo__default(),
            new Object[][] {
                new Object[] {
               T00152_A261TituloId, T00152_A262TituloValor, T00152_n262TituloValor, T00152_A276TituloDesconto, T00152_n276TituloDesconto, T00152_A284TituloDeleted, T00152_n284TituloDeleted, T00152_A314TituloArchived, T00152_n314TituloArchived, T00152_A263TituloVencimento,
               T00152_n263TituloVencimento, T00152_A286TituloCompetenciaAno, T00152_n286TituloCompetenciaAno, T00152_A287TituloCompetenciaMes, T00152_n287TituloCompetenciaMes, T00152_A264TituloProrrogacao, T00152_n264TituloProrrogacao, T00152_A265TituloCEP, T00152_n265TituloCEP, T00152_A266TituloLogradouro,
               T00152_n266TituloLogradouro, T00152_A294TituloNumeroEndereco, T00152_n294TituloNumeroEndereco, T00152_A267TituloComplemento, T00152_n267TituloComplemento, T00152_A268TituloBairro, T00152_n268TituloBairro, T00152_A269TituloMunicipio, T00152_n269TituloMunicipio, T00152_A498TituloJurosMora,
               T00152_n498TituloJurosMora, T00152_A283TituloTipo, T00152_n283TituloTipo, T00152_A500TituloCriacao, T00152_n500TituloCriacao, T00152_A648TituloPropostaTipo, T00152_n648TituloPropostaTipo, T00152_A422ContaId, T00152_n422ContaId, T00152_A426CategoriaTituloId,
               T00152_n426CategoriaTituloId, T00152_A890NotaFiscalParcelamentoID, T00152_n890NotaFiscalParcelamentoID, T00152_A951ContaBancariaId, T00152_n951ContaBancariaId, T00152_A419TituloPropostaId, T00152_n419TituloPropostaId, T00152_A420TituloClienteId, T00152_n420TituloClienteId
               }
               , new Object[] {
               T00153_A261TituloId, T00153_A262TituloValor, T00153_n262TituloValor, T00153_A276TituloDesconto, T00153_n276TituloDesconto, T00153_A284TituloDeleted, T00153_n284TituloDeleted, T00153_A314TituloArchived, T00153_n314TituloArchived, T00153_A263TituloVencimento,
               T00153_n263TituloVencimento, T00153_A286TituloCompetenciaAno, T00153_n286TituloCompetenciaAno, T00153_A287TituloCompetenciaMes, T00153_n287TituloCompetenciaMes, T00153_A264TituloProrrogacao, T00153_n264TituloProrrogacao, T00153_A265TituloCEP, T00153_n265TituloCEP, T00153_A266TituloLogradouro,
               T00153_n266TituloLogradouro, T00153_A294TituloNumeroEndereco, T00153_n294TituloNumeroEndereco, T00153_A267TituloComplemento, T00153_n267TituloComplemento, T00153_A268TituloBairro, T00153_n268TituloBairro, T00153_A269TituloMunicipio, T00153_n269TituloMunicipio, T00153_A498TituloJurosMora,
               T00153_n498TituloJurosMora, T00153_A283TituloTipo, T00153_n283TituloTipo, T00153_A500TituloCriacao, T00153_n500TituloCriacao, T00153_A648TituloPropostaTipo, T00153_n648TituloPropostaTipo, T00153_A422ContaId, T00153_n422ContaId, T00153_A426CategoriaTituloId,
               T00153_n426CategoriaTituloId, T00153_A890NotaFiscalParcelamentoID, T00153_n890NotaFiscalParcelamentoID, T00153_A951ContaBancariaId, T00153_n951ContaBancariaId, T00153_A419TituloPropostaId, T00153_n419TituloPropostaId, T00153_A420TituloClienteId, T00153_n420TituloClienteId
               }
               , new Object[] {
               T00154_A422ContaId
               }
               , new Object[] {
               T00155_A426CategoriaTituloId
               }
               , new Object[] {
               T00156_A794NotaFiscalId, T00156_n794NotaFiscalId
               }
               , new Object[] {
               T00157_A938AgenciaId, T00157_n938AgenciaId, T00157_A953ContaBancariaCarteira, T00157_n953ContaBancariaCarteira, T00157_A952ContaBancariaNumero, T00157_n952ContaBancariaNumero
               }
               , new Object[] {
               T00158_A971TituloPropostaDescricao, T00158_n971TituloPropostaDescricao, T00158_A501PropostaTaxaAdministrativa, T00158_n501PropostaTaxaAdministrativa
               }
               , new Object[] {
               T00159_A972TituloCLienteRazaoSocial, T00159_n972TituloCLienteRazaoSocial
               }
               , new Object[] {
               T001510_A799NotaFiscalNumero, T001510_n799NotaFiscalNumero
               }
               , new Object[] {
               T001511_A968AgenciaBancoId, T001511_n968AgenciaBancoId, T001511_A939AgenciaNumero, T001511_n939AgenciaNumero
               }
               , new Object[] {
               T001512_A969AgenciaBancoNome, T001512_n969AgenciaBancoNome
               }
               , new Object[] {
               T001514_A516TituloDataCredito_F, T001514_n516TituloDataCredito_F
               }
               , new Object[] {
               T001516_A273TituloTotalMovimento_F, T001516_n273TituloTotalMovimento_F
               }
               , new Object[] {
               T001518_A301TituloTotalMultaJuros_F, T001518_n301TituloTotalMultaJuros_F
               }
               , new Object[] {
               T001520_A1119TitulosCarteiraDeCobranca, T001520_n1119TitulosCarteiraDeCobranca
               }
               , new Object[] {
               T001525_A794NotaFiscalId, T001525_n794NotaFiscalId, T001525_A938AgenciaId, T001525_n938AgenciaId, T001525_A968AgenciaBancoId, T001525_n968AgenciaBancoId, T001525_A261TituloId, T001525_A972TituloCLienteRazaoSocial, T001525_n972TituloCLienteRazaoSocial, T001525_A262TituloValor,
               T001525_n262TituloValor, T001525_A276TituloDesconto, T001525_n276TituloDesconto, T001525_A284TituloDeleted, T001525_n284TituloDeleted, T001525_A314TituloArchived, T001525_n314TituloArchived, T001525_A263TituloVencimento, T001525_n263TituloVencimento, T001525_A286TituloCompetenciaAno,
               T001525_n286TituloCompetenciaAno, T001525_A287TituloCompetenciaMes, T001525_n287TituloCompetenciaMes, T001525_A264TituloProrrogacao, T001525_n264TituloProrrogacao, T001525_A265TituloCEP, T001525_n265TituloCEP, T001525_A266TituloLogradouro, T001525_n266TituloLogradouro, T001525_A294TituloNumeroEndereco,
               T001525_n294TituloNumeroEndereco, T001525_A267TituloComplemento, T001525_n267TituloComplemento, T001525_A268TituloBairro, T001525_n268TituloBairro, T001525_A269TituloMunicipio, T001525_n269TituloMunicipio, T001525_A498TituloJurosMora, T001525_n498TituloJurosMora, T001525_A283TituloTipo,
               T001525_n283TituloTipo, T001525_A971TituloPropostaDescricao, T001525_n971TituloPropostaDescricao, T001525_A501PropostaTaxaAdministrativa, T001525_n501PropostaTaxaAdministrativa, T001525_A500TituloCriacao, T001525_n500TituloCriacao, T001525_A648TituloPropostaTipo, T001525_n648TituloPropostaTipo, T001525_A799NotaFiscalNumero,
               T001525_n799NotaFiscalNumero, T001525_A969AgenciaBancoNome, T001525_n969AgenciaBancoNome, T001525_A953ContaBancariaCarteira, T001525_n953ContaBancariaCarteira, T001525_A952ContaBancariaNumero, T001525_n952ContaBancariaNumero, T001525_A939AgenciaNumero, T001525_n939AgenciaNumero, T001525_A422ContaId,
               T001525_n422ContaId, T001525_A426CategoriaTituloId, T001525_n426CategoriaTituloId, T001525_A890NotaFiscalParcelamentoID, T001525_n890NotaFiscalParcelamentoID, T001525_A951ContaBancariaId, T001525_n951ContaBancariaId, T001525_A419TituloPropostaId, T001525_n419TituloPropostaId, T001525_A420TituloClienteId,
               T001525_n420TituloClienteId, T001525_A516TituloDataCredito_F, T001525_n516TituloDataCredito_F, T001525_A273TituloTotalMovimento_F, T001525_n273TituloTotalMovimento_F, T001525_A301TituloTotalMultaJuros_F, T001525_n301TituloTotalMultaJuros_F, T001525_A1119TitulosCarteiraDeCobranca, T001525_n1119TitulosCarteiraDeCobranca
               }
               , new Object[] {
               T001527_A516TituloDataCredito_F, T001527_n516TituloDataCredito_F
               }
               , new Object[] {
               T001529_A273TituloTotalMovimento_F, T001529_n273TituloTotalMovimento_F
               }
               , new Object[] {
               T001531_A301TituloTotalMultaJuros_F, T001531_n301TituloTotalMultaJuros_F
               }
               , new Object[] {
               T001533_A1119TitulosCarteiraDeCobranca, T001533_n1119TitulosCarteiraDeCobranca
               }
               , new Object[] {
               T001534_A422ContaId
               }
               , new Object[] {
               T001535_A426CategoriaTituloId
               }
               , new Object[] {
               T001536_A794NotaFiscalId, T001536_n794NotaFiscalId
               }
               , new Object[] {
               T001537_A799NotaFiscalNumero, T001537_n799NotaFiscalNumero
               }
               , new Object[] {
               T001538_A938AgenciaId, T001538_n938AgenciaId, T001538_A953ContaBancariaCarteira, T001538_n953ContaBancariaCarteira, T001538_A952ContaBancariaNumero, T001538_n952ContaBancariaNumero
               }
               , new Object[] {
               T001539_A968AgenciaBancoId, T001539_n968AgenciaBancoId, T001539_A939AgenciaNumero, T001539_n939AgenciaNumero
               }
               , new Object[] {
               T001540_A969AgenciaBancoNome, T001540_n969AgenciaBancoNome
               }
               , new Object[] {
               T001541_A971TituloPropostaDescricao, T001541_n971TituloPropostaDescricao, T001541_A501PropostaTaxaAdministrativa, T001541_n501PropostaTaxaAdministrativa
               }
               , new Object[] {
               T001542_A972TituloCLienteRazaoSocial, T001542_n972TituloCLienteRazaoSocial
               }
               , new Object[] {
               T001543_A261TituloId
               }
               , new Object[] {
               T001544_A261TituloId
               }
               , new Object[] {
               T001545_A261TituloId
               }
               , new Object[] {
               }
               , new Object[] {
               T001547_A261TituloId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001551_A516TituloDataCredito_F, T001551_n516TituloDataCredito_F
               }
               , new Object[] {
               T001553_A273TituloTotalMovimento_F, T001553_n273TituloTotalMovimento_F
               }
               , new Object[] {
               T001555_A301TituloTotalMultaJuros_F, T001555_n301TituloTotalMultaJuros_F
               }
               , new Object[] {
               T001557_A1119TitulosCarteiraDeCobranca, T001557_n1119TitulosCarteiraDeCobranca
               }
               , new Object[] {
               T001558_A794NotaFiscalId, T001558_n794NotaFiscalId
               }
               , new Object[] {
               T001559_A799NotaFiscalNumero, T001559_n799NotaFiscalNumero
               }
               , new Object[] {
               T001560_A938AgenciaId, T001560_n938AgenciaId, T001560_A953ContaBancariaCarteira, T001560_n953ContaBancariaCarteira, T001560_A952ContaBancariaNumero, T001560_n952ContaBancariaNumero
               }
               , new Object[] {
               T001561_A968AgenciaBancoId, T001561_n968AgenciaBancoId, T001561_A939AgenciaNumero, T001561_n939AgenciaNumero
               }
               , new Object[] {
               T001562_A969AgenciaBancoNome, T001562_n969AgenciaBancoNome
               }
               , new Object[] {
               T001563_A971TituloPropostaDescricao, T001563_n971TituloPropostaDescricao, T001563_A501PropostaTaxaAdministrativa, T001563_n501PropostaTaxaAdministrativa
               }
               , new Object[] {
               T001564_A972TituloCLienteRazaoSocial, T001564_n972TituloCLienteRazaoSocial
               }
               , new Object[] {
               T001565_A1077BoletosId
               }
               , new Object[] {
               T001566_A270TituloMovimentoId
               }
               , new Object[] {
               T001567_A261TituloId
               }
               , new Object[] {
               T001568_A271TituloMovimentoValor, T001568_n271TituloMovimentoValor
               }
               , new Object[] {
               T001569_A271TituloMovimentoValor, T001569_n271TituloMovimentoValor
               }
               , new Object[] {
               T001570_A271TituloMovimentoValor, T001570_n271TituloMovimentoValor
               }
               , new Object[] {
               T001571_A271TituloMovimentoValor, T001571_n271TituloMovimentoValor
               }
               , new Object[] {
               T001572_Gx_cnt
               }
            }
         );
         WebComp_Wctitulomovimentoww = new GeneXus.Http.GXNullWebComponent();
         AV27Pgmname = "Titulo";
         Z500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
         n500TituloCriacao = false;
         A500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
         n500TituloCriacao = false;
         i500TituloCriacao = DateTimeUtil.ServerNow( context, pr_default);
         n500TituloCriacao = false;
         Z284TituloDeleted = false;
         n284TituloDeleted = false;
         A284TituloDeleted = false;
         n284TituloDeleted = false;
         i284TituloDeleted = false;
         n284TituloDeleted = false;
      }

      private short Z286TituloCompetenciaAno ;
      private short Z287TituloCompetenciaMes ;
      private short GxWebError ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A286TituloCompetenciaAno ;
      private short A287TituloCompetenciaMes ;
      private short Gx_BScreen ;
      private short RcdFound44 ;
      private short nCmpId ;
      private short gxajaxcallmode ;
      private int wcpOAV7TituloId ;
      private int Z261TituloId ;
      private int Z422ContaId ;
      private int Z426CategoriaTituloId ;
      private int Z951ContaBancariaId ;
      private int Z419TituloPropostaId ;
      private int Z420TituloClienteId ;
      private int N420TituloClienteId ;
      private int N419TituloPropostaId ;
      private int N422ContaId ;
      private int N426CategoriaTituloId ;
      private int N951ContaBancariaId ;
      private int A261TituloId ;
      private int A422ContaId ;
      private int A426CategoriaTituloId ;
      private int A951ContaBancariaId ;
      private int A938AgenciaId ;
      private int A968AgenciaBancoId ;
      private int A419TituloPropostaId ;
      private int A420TituloClienteId ;
      private int AV7TituloId ;
      private int trnEnded ;
      private int edtTituloId_Enabled ;
      private int edtTituloValor_Enabled ;
      private int edtTituloDesconto_Enabled ;
      private int edtTituloProrrogacao_Enabled ;
      private int edtTituloCompetencia_F_Enabled ;
      private int edtTituloStatus_F_Enabled ;
      private int edtTituloSaldo_F_Enabled ;
      private int edtTituloTotalMovimento_F_Enabled ;
      private int edtTituloCEP_Enabled ;
      private int edtTituloLogradouro_Enabled ;
      private int edtTituloNumeroEndereco_Enabled ;
      private int edtTituloComplemento_Enabled ;
      private int edtTituloBairro_Enabled ;
      private int edtTituloMunicipio_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtTituloDeleted_Visible ;
      private int edtTituloDeleted_Enabled ;
      private int edtTituloVencimento_Visible ;
      private int edtTituloVencimento_Enabled ;
      private int edtTituloCompetenciaAno_Enabled ;
      private int edtTituloCompetenciaAno_Visible ;
      private int edtTituloCompetenciaMes_Enabled ;
      private int edtTituloCompetenciaMes_Visible ;
      private int AV25Insert_TituloClienteId ;
      private int AV20Insert_TituloPropostaId ;
      private int AV21Insert_ContaId ;
      private int AV22Insert_CategoriaTituloId ;
      private int AV24Insert_ContaBancariaId ;
      private int A939AgenciaNumero ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV28GXV1 ;
      private int Z938AgenciaId ;
      private int Z968AgenciaBancoId ;
      private int Z939AgenciaNumero ;
      private int idxLst ;
      private int E261TituloId ;
      private int Gx_cnt ;
      private long A953ContaBancariaCarteira ;
      private long A952ContaBancariaNumero ;
      private long Z953ContaBancariaCarteira ;
      private long Z952ContaBancariaNumero ;
      private decimal Z262TituloValor ;
      private decimal Z276TituloDesconto ;
      private decimal Z498TituloJurosMora ;
      private decimal A262TituloValor ;
      private decimal A276TituloDesconto ;
      private decimal A275TituloSaldo_F ;
      private decimal A273TituloTotalMovimento_F ;
      private decimal A498TituloJurosMora ;
      private decimal A303TituloSaldoCredito_F ;
      private decimal A302TituloSaldoDebito_F ;
      private decimal A307TituloTotalMultaJurosCredito_F ;
      private decimal A306TituloTotalMultaJurosDebito_F ;
      private decimal A305TituloTotalMovimentoCredito_F ;
      private decimal A304TituloTotalMovimentoDebito_F ;
      private decimal A501PropostaTaxaAdministrativa ;
      private decimal A301TituloTotalMultaJuros_F ;
      private decimal Z501PropostaTaxaAdministrativa ;
      private decimal Z273TituloTotalMovimento_F ;
      private decimal Z301TituloTotalMultaJuros_F ;
      private decimal X271TituloMovimentoValor ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTituloValor_Internalname ;
      private string cmbTituloTipo_Internalname ;
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
      private string edtTituloId_Internalname ;
      private string TempTags ;
      private string edtTituloId_Jsonclick ;
      private string edtTituloValor_Jsonclick ;
      private string edtTituloDesconto_Internalname ;
      private string edtTituloDesconto_Jsonclick ;
      private string edtTituloProrrogacao_Internalname ;
      private string edtTituloProrrogacao_Jsonclick ;
      private string edtTituloCompetencia_F_Internalname ;
      private string edtTituloCompetencia_F_Jsonclick ;
      private string edtTituloStatus_F_Internalname ;
      private string edtTituloStatus_F_Jsonclick ;
      private string cmbTituloTipo_Jsonclick ;
      private string edtTituloSaldo_F_Internalname ;
      private string edtTituloSaldo_F_Jsonclick ;
      private string edtTituloTotalMovimento_F_Internalname ;
      private string edtTituloTotalMovimento_F_Jsonclick ;
      private string grpUnnamedgroup1_Internalname ;
      private string divTableendereco_Internalname ;
      private string edtTituloCEP_Internalname ;
      private string edtTituloCEP_Jsonclick ;
      private string edtTituloLogradouro_Internalname ;
      private string edtTituloLogradouro_Jsonclick ;
      private string edtTituloNumeroEndereco_Internalname ;
      private string edtTituloNumeroEndereco_Jsonclick ;
      private string edtTituloComplemento_Internalname ;
      private string edtTituloComplemento_Jsonclick ;
      private string edtTituloBairro_Internalname ;
      private string edtTituloBairro_Jsonclick ;
      private string edtTituloMunicipio_Internalname ;
      private string edtTituloMunicipio_Jsonclick ;
      private string divTablemovimentos_Internalname ;
      private string WebComp_Wctitulomovimentoww_Component ;
      private string OldWctitulomovimentoww ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtTituloDeleted_Internalname ;
      private string edtTituloDeleted_Jsonclick ;
      private string edtTituloVencimento_Internalname ;
      private string edtTituloVencimento_Jsonclick ;
      private string edtTituloCompetenciaAno_Internalname ;
      private string edtTituloCompetenciaAno_Jsonclick ;
      private string edtTituloCompetenciaMes_Internalname ;
      private string edtTituloCompetenciaMes_Jsonclick ;
      private string AV27Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode44 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z500TituloCriacao ;
      private DateTime A500TituloCriacao ;
      private DateTime i500TituloCriacao ;
      private DateTime Z263TituloVencimento ;
      private DateTime Z264TituloProrrogacao ;
      private DateTime A264TituloProrrogacao ;
      private DateTime A263TituloVencimento ;
      private DateTime A516TituloDataCredito_F ;
      private DateTime Z516TituloDataCredito_F ;
      private bool Z284TituloDeleted ;
      private bool Z314TituloArchived ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n261TituloId ;
      private bool n283TituloTipo ;
      private bool n422ContaId ;
      private bool n426CategoriaTituloId ;
      private bool n890NotaFiscalParcelamentoID ;
      private bool n794NotaFiscalId ;
      private bool n951ContaBancariaId ;
      private bool n938AgenciaId ;
      private bool n968AgenciaBancoId ;
      private bool n419TituloPropostaId ;
      private bool n420TituloClienteId ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n262TituloValor ;
      private bool n276TituloDesconto ;
      private bool A284TituloDeleted ;
      private bool n286TituloCompetenciaAno ;
      private bool n287TituloCompetenciaMes ;
      private bool n284TituloDeleted ;
      private bool n314TituloArchived ;
      private bool A314TituloArchived ;
      private bool n263TituloVencimento ;
      private bool n264TituloProrrogacao ;
      private bool n265TituloCEP ;
      private bool n266TituloLogradouro ;
      private bool n294TituloNumeroEndereco ;
      private bool n267TituloComplemento ;
      private bool n268TituloBairro ;
      private bool n269TituloMunicipio ;
      private bool n498TituloJurosMora ;
      private bool n500TituloCriacao ;
      private bool n648TituloPropostaTipo ;
      private bool A1118TitulosEmCarteiraDeCobranca_F ;
      private bool n953ContaBancariaCarteira ;
      private bool n952ContaBancariaNumero ;
      private bool n971TituloPropostaDescricao ;
      private bool n501PropostaTaxaAdministrativa ;
      private bool n972TituloCLienteRazaoSocial ;
      private bool n799NotaFiscalNumero ;
      private bool n939AgenciaNumero ;
      private bool n969AgenciaBancoNome ;
      private bool n516TituloDataCredito_F ;
      private bool n301TituloTotalMultaJuros_F ;
      private bool n1119TitulosCarteiraDeCobranca ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n273TituloTotalMovimento_F ;
      private bool returnInSub ;
      private bool bDynCreated_Wctitulomovimentoww ;
      private bool Gx_longc ;
      private bool i284TituloDeleted ;
      private bool Z1118TitulosEmCarteiraDeCobranca_F ;
      private bool nA261TituloId ;
      private bool nX271TituloMovimentoValor ;
      private bool nE261TituloId ;
      private string Z265TituloCEP ;
      private string Z266TituloLogradouro ;
      private string Z294TituloNumeroEndereco ;
      private string Z267TituloComplemento ;
      private string Z268TituloBairro ;
      private string Z269TituloMunicipio ;
      private string Z283TituloTipo ;
      private string Z648TituloPropostaTipo ;
      private string A283TituloTipo ;
      private string A295TituloCompetencia_F ;
      private string A282TituloStatus_F ;
      private string A265TituloCEP ;
      private string A266TituloLogradouro ;
      private string A294TituloNumeroEndereco ;
      private string A267TituloComplemento ;
      private string A268TituloBairro ;
      private string A269TituloMunicipio ;
      private string A648TituloPropostaTipo ;
      private string A971TituloPropostaDescricao ;
      private string A972TituloCLienteRazaoSocial ;
      private string A799NotaFiscalNumero ;
      private string A969AgenciaBancoNome ;
      private string A1119TitulosCarteiraDeCobranca ;
      private string Z799NotaFiscalNumero ;
      private string Z969AgenciaBancoNome ;
      private string Z971TituloPropostaDescricao ;
      private string Z972TituloCLienteRazaoSocial ;
      private string Z1119TitulosCarteiraDeCobranca ;
      private Guid Z890NotaFiscalParcelamentoID ;
      private Guid N890NotaFiscalParcelamentoID ;
      private Guid A890NotaFiscalParcelamentoID ;
      private Guid A794NotaFiscalId ;
      private Guid AV23Insert_NotaFiscalParcelamentoID ;
      private Guid Z794NotaFiscalId ;
      private IGxSession AV10WebSession ;
      private GXWebComponent WebComp_Wctitulomovimentoww ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTituloTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T001514_A516TituloDataCredito_F ;
      private bool[] T001514_n516TituloDataCredito_F ;
      private decimal[] T001516_A273TituloTotalMovimento_F ;
      private bool[] T001516_n273TituloTotalMovimento_F ;
      private decimal[] T001518_A301TituloTotalMultaJuros_F ;
      private bool[] T001518_n301TituloTotalMultaJuros_F ;
      private string[] T001520_A1119TitulosCarteiraDeCobranca ;
      private bool[] T001520_n1119TitulosCarteiraDeCobranca ;
      private string[] T00159_A972TituloCLienteRazaoSocial ;
      private bool[] T00159_n972TituloCLienteRazaoSocial ;
      private Guid[] T001525_A794NotaFiscalId ;
      private bool[] T001525_n794NotaFiscalId ;
      private int[] T001525_A938AgenciaId ;
      private bool[] T001525_n938AgenciaId ;
      private int[] T001525_A968AgenciaBancoId ;
      private bool[] T001525_n968AgenciaBancoId ;
      private int[] T001525_A261TituloId ;
      private bool[] T001525_n261TituloId ;
      private string[] T001525_A972TituloCLienteRazaoSocial ;
      private bool[] T001525_n972TituloCLienteRazaoSocial ;
      private decimal[] T001525_A262TituloValor ;
      private bool[] T001525_n262TituloValor ;
      private decimal[] T001525_A276TituloDesconto ;
      private bool[] T001525_n276TituloDesconto ;
      private bool[] T001525_A284TituloDeleted ;
      private bool[] T001525_n284TituloDeleted ;
      private bool[] T001525_A314TituloArchived ;
      private bool[] T001525_n314TituloArchived ;
      private DateTime[] T001525_A263TituloVencimento ;
      private bool[] T001525_n263TituloVencimento ;
      private short[] T001525_A286TituloCompetenciaAno ;
      private bool[] T001525_n286TituloCompetenciaAno ;
      private short[] T001525_A287TituloCompetenciaMes ;
      private bool[] T001525_n287TituloCompetenciaMes ;
      private DateTime[] T001525_A264TituloProrrogacao ;
      private bool[] T001525_n264TituloProrrogacao ;
      private string[] T001525_A265TituloCEP ;
      private bool[] T001525_n265TituloCEP ;
      private string[] T001525_A266TituloLogradouro ;
      private bool[] T001525_n266TituloLogradouro ;
      private string[] T001525_A294TituloNumeroEndereco ;
      private bool[] T001525_n294TituloNumeroEndereco ;
      private string[] T001525_A267TituloComplemento ;
      private bool[] T001525_n267TituloComplemento ;
      private string[] T001525_A268TituloBairro ;
      private bool[] T001525_n268TituloBairro ;
      private string[] T001525_A269TituloMunicipio ;
      private bool[] T001525_n269TituloMunicipio ;
      private decimal[] T001525_A498TituloJurosMora ;
      private bool[] T001525_n498TituloJurosMora ;
      private string[] T001525_A283TituloTipo ;
      private bool[] T001525_n283TituloTipo ;
      private string[] T001525_A971TituloPropostaDescricao ;
      private bool[] T001525_n971TituloPropostaDescricao ;
      private decimal[] T001525_A501PropostaTaxaAdministrativa ;
      private bool[] T001525_n501PropostaTaxaAdministrativa ;
      private DateTime[] T001525_A500TituloCriacao ;
      private bool[] T001525_n500TituloCriacao ;
      private string[] T001525_A648TituloPropostaTipo ;
      private bool[] T001525_n648TituloPropostaTipo ;
      private string[] T001525_A799NotaFiscalNumero ;
      private bool[] T001525_n799NotaFiscalNumero ;
      private string[] T001525_A969AgenciaBancoNome ;
      private bool[] T001525_n969AgenciaBancoNome ;
      private long[] T001525_A953ContaBancariaCarteira ;
      private bool[] T001525_n953ContaBancariaCarteira ;
      private long[] T001525_A952ContaBancariaNumero ;
      private bool[] T001525_n952ContaBancariaNumero ;
      private int[] T001525_A939AgenciaNumero ;
      private bool[] T001525_n939AgenciaNumero ;
      private int[] T001525_A422ContaId ;
      private bool[] T001525_n422ContaId ;
      private int[] T001525_A426CategoriaTituloId ;
      private bool[] T001525_n426CategoriaTituloId ;
      private Guid[] T001525_A890NotaFiscalParcelamentoID ;
      private bool[] T001525_n890NotaFiscalParcelamentoID ;
      private int[] T001525_A951ContaBancariaId ;
      private bool[] T001525_n951ContaBancariaId ;
      private int[] T001525_A419TituloPropostaId ;
      private bool[] T001525_n419TituloPropostaId ;
      private int[] T001525_A420TituloClienteId ;
      private bool[] T001525_n420TituloClienteId ;
      private DateTime[] T001525_A516TituloDataCredito_F ;
      private bool[] T001525_n516TituloDataCredito_F ;
      private decimal[] T001525_A273TituloTotalMovimento_F ;
      private bool[] T001525_n273TituloTotalMovimento_F ;
      private decimal[] T001525_A301TituloTotalMultaJuros_F ;
      private bool[] T001525_n301TituloTotalMultaJuros_F ;
      private string[] T001525_A1119TitulosCarteiraDeCobranca ;
      private bool[] T001525_n1119TitulosCarteiraDeCobranca ;
      private int[] T00154_A422ContaId ;
      private bool[] T00154_n422ContaId ;
      private int[] T00155_A426CategoriaTituloId ;
      private bool[] T00155_n426CategoriaTituloId ;
      private Guid[] T00156_A794NotaFiscalId ;
      private bool[] T00156_n794NotaFiscalId ;
      private string[] T001510_A799NotaFiscalNumero ;
      private bool[] T001510_n799NotaFiscalNumero ;
      private int[] T00157_A938AgenciaId ;
      private bool[] T00157_n938AgenciaId ;
      private long[] T00157_A953ContaBancariaCarteira ;
      private bool[] T00157_n953ContaBancariaCarteira ;
      private long[] T00157_A952ContaBancariaNumero ;
      private bool[] T00157_n952ContaBancariaNumero ;
      private int[] T001511_A968AgenciaBancoId ;
      private bool[] T001511_n968AgenciaBancoId ;
      private int[] T001511_A939AgenciaNumero ;
      private bool[] T001511_n939AgenciaNumero ;
      private string[] T001512_A969AgenciaBancoNome ;
      private bool[] T001512_n969AgenciaBancoNome ;
      private string[] T00158_A971TituloPropostaDescricao ;
      private bool[] T00158_n971TituloPropostaDescricao ;
      private decimal[] T00158_A501PropostaTaxaAdministrativa ;
      private bool[] T00158_n501PropostaTaxaAdministrativa ;
      private DateTime[] T001527_A516TituloDataCredito_F ;
      private bool[] T001527_n516TituloDataCredito_F ;
      private decimal[] T001529_A273TituloTotalMovimento_F ;
      private bool[] T001529_n273TituloTotalMovimento_F ;
      private decimal[] T001531_A301TituloTotalMultaJuros_F ;
      private bool[] T001531_n301TituloTotalMultaJuros_F ;
      private string[] T001533_A1119TitulosCarteiraDeCobranca ;
      private bool[] T001533_n1119TitulosCarteiraDeCobranca ;
      private int[] T001534_A422ContaId ;
      private bool[] T001534_n422ContaId ;
      private int[] T001535_A426CategoriaTituloId ;
      private bool[] T001535_n426CategoriaTituloId ;
      private Guid[] T001536_A794NotaFiscalId ;
      private bool[] T001536_n794NotaFiscalId ;
      private string[] T001537_A799NotaFiscalNumero ;
      private bool[] T001537_n799NotaFiscalNumero ;
      private int[] T001538_A938AgenciaId ;
      private bool[] T001538_n938AgenciaId ;
      private long[] T001538_A953ContaBancariaCarteira ;
      private bool[] T001538_n953ContaBancariaCarteira ;
      private long[] T001538_A952ContaBancariaNumero ;
      private bool[] T001538_n952ContaBancariaNumero ;
      private int[] T001539_A968AgenciaBancoId ;
      private bool[] T001539_n968AgenciaBancoId ;
      private int[] T001539_A939AgenciaNumero ;
      private bool[] T001539_n939AgenciaNumero ;
      private string[] T001540_A969AgenciaBancoNome ;
      private bool[] T001540_n969AgenciaBancoNome ;
      private string[] T001541_A971TituloPropostaDescricao ;
      private bool[] T001541_n971TituloPropostaDescricao ;
      private decimal[] T001541_A501PropostaTaxaAdministrativa ;
      private bool[] T001541_n501PropostaTaxaAdministrativa ;
      private string[] T001542_A972TituloCLienteRazaoSocial ;
      private bool[] T001542_n972TituloCLienteRazaoSocial ;
      private int[] T001543_A261TituloId ;
      private bool[] T001543_n261TituloId ;
      private int[] T00153_A261TituloId ;
      private bool[] T00153_n261TituloId ;
      private decimal[] T00153_A262TituloValor ;
      private bool[] T00153_n262TituloValor ;
      private decimal[] T00153_A276TituloDesconto ;
      private bool[] T00153_n276TituloDesconto ;
      private bool[] T00153_A284TituloDeleted ;
      private bool[] T00153_n284TituloDeleted ;
      private bool[] T00153_A314TituloArchived ;
      private bool[] T00153_n314TituloArchived ;
      private DateTime[] T00153_A263TituloVencimento ;
      private bool[] T00153_n263TituloVencimento ;
      private short[] T00153_A286TituloCompetenciaAno ;
      private bool[] T00153_n286TituloCompetenciaAno ;
      private short[] T00153_A287TituloCompetenciaMes ;
      private bool[] T00153_n287TituloCompetenciaMes ;
      private DateTime[] T00153_A264TituloProrrogacao ;
      private bool[] T00153_n264TituloProrrogacao ;
      private string[] T00153_A265TituloCEP ;
      private bool[] T00153_n265TituloCEP ;
      private string[] T00153_A266TituloLogradouro ;
      private bool[] T00153_n266TituloLogradouro ;
      private string[] T00153_A294TituloNumeroEndereco ;
      private bool[] T00153_n294TituloNumeroEndereco ;
      private string[] T00153_A267TituloComplemento ;
      private bool[] T00153_n267TituloComplemento ;
      private string[] T00153_A268TituloBairro ;
      private bool[] T00153_n268TituloBairro ;
      private string[] T00153_A269TituloMunicipio ;
      private bool[] T00153_n269TituloMunicipio ;
      private decimal[] T00153_A498TituloJurosMora ;
      private bool[] T00153_n498TituloJurosMora ;
      private string[] T00153_A283TituloTipo ;
      private bool[] T00153_n283TituloTipo ;
      private DateTime[] T00153_A500TituloCriacao ;
      private bool[] T00153_n500TituloCriacao ;
      private string[] T00153_A648TituloPropostaTipo ;
      private bool[] T00153_n648TituloPropostaTipo ;
      private int[] T00153_A422ContaId ;
      private bool[] T00153_n422ContaId ;
      private int[] T00153_A426CategoriaTituloId ;
      private bool[] T00153_n426CategoriaTituloId ;
      private Guid[] T00153_A890NotaFiscalParcelamentoID ;
      private bool[] T00153_n890NotaFiscalParcelamentoID ;
      private int[] T00153_A951ContaBancariaId ;
      private bool[] T00153_n951ContaBancariaId ;
      private int[] T00153_A419TituloPropostaId ;
      private bool[] T00153_n419TituloPropostaId ;
      private int[] T00153_A420TituloClienteId ;
      private bool[] T00153_n420TituloClienteId ;
      private int[] T001544_A261TituloId ;
      private bool[] T001544_n261TituloId ;
      private int[] T001545_A261TituloId ;
      private bool[] T001545_n261TituloId ;
      private int[] T00152_A261TituloId ;
      private bool[] T00152_n261TituloId ;
      private decimal[] T00152_A262TituloValor ;
      private bool[] T00152_n262TituloValor ;
      private decimal[] T00152_A276TituloDesconto ;
      private bool[] T00152_n276TituloDesconto ;
      private bool[] T00152_A284TituloDeleted ;
      private bool[] T00152_n284TituloDeleted ;
      private bool[] T00152_A314TituloArchived ;
      private bool[] T00152_n314TituloArchived ;
      private DateTime[] T00152_A263TituloVencimento ;
      private bool[] T00152_n263TituloVencimento ;
      private short[] T00152_A286TituloCompetenciaAno ;
      private bool[] T00152_n286TituloCompetenciaAno ;
      private short[] T00152_A287TituloCompetenciaMes ;
      private bool[] T00152_n287TituloCompetenciaMes ;
      private DateTime[] T00152_A264TituloProrrogacao ;
      private bool[] T00152_n264TituloProrrogacao ;
      private string[] T00152_A265TituloCEP ;
      private bool[] T00152_n265TituloCEP ;
      private string[] T00152_A266TituloLogradouro ;
      private bool[] T00152_n266TituloLogradouro ;
      private string[] T00152_A294TituloNumeroEndereco ;
      private bool[] T00152_n294TituloNumeroEndereco ;
      private string[] T00152_A267TituloComplemento ;
      private bool[] T00152_n267TituloComplemento ;
      private string[] T00152_A268TituloBairro ;
      private bool[] T00152_n268TituloBairro ;
      private string[] T00152_A269TituloMunicipio ;
      private bool[] T00152_n269TituloMunicipio ;
      private decimal[] T00152_A498TituloJurosMora ;
      private bool[] T00152_n498TituloJurosMora ;
      private string[] T00152_A283TituloTipo ;
      private bool[] T00152_n283TituloTipo ;
      private DateTime[] T00152_A500TituloCriacao ;
      private bool[] T00152_n500TituloCriacao ;
      private string[] T00152_A648TituloPropostaTipo ;
      private bool[] T00152_n648TituloPropostaTipo ;
      private int[] T00152_A422ContaId ;
      private bool[] T00152_n422ContaId ;
      private int[] T00152_A426CategoriaTituloId ;
      private bool[] T00152_n426CategoriaTituloId ;
      private Guid[] T00152_A890NotaFiscalParcelamentoID ;
      private bool[] T00152_n890NotaFiscalParcelamentoID ;
      private int[] T00152_A951ContaBancariaId ;
      private bool[] T00152_n951ContaBancariaId ;
      private int[] T00152_A419TituloPropostaId ;
      private bool[] T00152_n419TituloPropostaId ;
      private int[] T00152_A420TituloClienteId ;
      private bool[] T00152_n420TituloClienteId ;
      private int[] T001547_A261TituloId ;
      private bool[] T001547_n261TituloId ;
      private DateTime[] T001551_A516TituloDataCredito_F ;
      private bool[] T001551_n516TituloDataCredito_F ;
      private decimal[] T001553_A273TituloTotalMovimento_F ;
      private bool[] T001553_n273TituloTotalMovimento_F ;
      private decimal[] T001555_A301TituloTotalMultaJuros_F ;
      private bool[] T001555_n301TituloTotalMultaJuros_F ;
      private string[] T001557_A1119TitulosCarteiraDeCobranca ;
      private bool[] T001557_n1119TitulosCarteiraDeCobranca ;
      private Guid[] T001558_A794NotaFiscalId ;
      private bool[] T001558_n794NotaFiscalId ;
      private string[] T001559_A799NotaFiscalNumero ;
      private bool[] T001559_n799NotaFiscalNumero ;
      private int[] T001560_A938AgenciaId ;
      private bool[] T001560_n938AgenciaId ;
      private long[] T001560_A953ContaBancariaCarteira ;
      private bool[] T001560_n953ContaBancariaCarteira ;
      private long[] T001560_A952ContaBancariaNumero ;
      private bool[] T001560_n952ContaBancariaNumero ;
      private int[] T001561_A968AgenciaBancoId ;
      private bool[] T001561_n968AgenciaBancoId ;
      private int[] T001561_A939AgenciaNumero ;
      private bool[] T001561_n939AgenciaNumero ;
      private string[] T001562_A969AgenciaBancoNome ;
      private bool[] T001562_n969AgenciaBancoNome ;
      private string[] T001563_A971TituloPropostaDescricao ;
      private bool[] T001563_n971TituloPropostaDescricao ;
      private decimal[] T001563_A501PropostaTaxaAdministrativa ;
      private bool[] T001563_n501PropostaTaxaAdministrativa ;
      private string[] T001564_A972TituloCLienteRazaoSocial ;
      private bool[] T001564_n972TituloCLienteRazaoSocial ;
      private int[] T001565_A1077BoletosId ;
      private int[] T001566_A270TituloMovimentoId ;
      private int[] T001567_A261TituloId ;
      private bool[] T001567_n261TituloId ;
      private decimal[] T001568_A271TituloMovimentoValor ;
      private bool[] T001568_n271TituloMovimentoValor ;
      private decimal[] T001569_A271TituloMovimentoValor ;
      private bool[] T001569_n271TituloMovimentoValor ;
      private decimal[] T001570_A271TituloMovimentoValor ;
      private bool[] T001570_n271TituloMovimentoValor ;
      private decimal[] T001571_A271TituloMovimentoValor ;
      private bool[] T001571_n271TituloMovimentoValor ;
      private int[] T001572_Gx_cnt ;
   }

   public class titulo__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new UpdateCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new UpdateCursor(def[34])
         ,new UpdateCursor(def[35])
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new ForEachCursor(def[38])
         ,new ForEachCursor(def[39])
         ,new ForEachCursor(def[40])
         ,new ForEachCursor(def[41])
         ,new ForEachCursor(def[42])
         ,new ForEachCursor(def[43])
         ,new ForEachCursor(def[44])
         ,new ForEachCursor(def[45])
         ,new ForEachCursor(def[46])
         ,new ForEachCursor(def[47])
         ,new ForEachCursor(def[48])
         ,new ForEachCursor(def[49])
         ,new ForEachCursor(def[50])
         ,new ForEachCursor(def[51])
         ,new ForEachCursor(def[52])
         ,new ForEachCursor(def[53])
         ,new ForEachCursor(def[54])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00152;
          prmT00152 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00153;
          prmT00153 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00154;
          prmT00154 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00155;
          prmT00155 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00156;
          prmT00156 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT00157;
          prmT00157 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00158;
          prmT00158 = new Object[] {
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT00159;
          prmT00159 = new Object[] {
          new ParDef("TituloClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001510;
          prmT001510 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT001511;
          prmT001511 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001512;
          prmT001512 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001514;
          prmT001514 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001516;
          prmT001516 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001518;
          prmT001518 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001520;
          prmT001520 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001525;
          prmT001525 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferT001525;
          cmdBufferT001525=" SELECT T2.NotaFiscalId, T4.AgenciaId, T5.AgenciaBancoId AS AgenciaBancoId, TM1.TituloId, T8.ClienteRazaoSocial AS TituloCLienteRazaoSocial, TM1.TituloValor, TM1.TituloDesconto, TM1.TituloDeleted, TM1.TituloArchived, TM1.TituloVencimento, TM1.TituloCompetenciaAno, TM1.TituloCompetenciaMes, TM1.TituloProrrogacao, TM1.TituloCEP, TM1.TituloLogradouro, TM1.TituloNumeroEndereco, TM1.TituloComplemento, TM1.TituloBairro, TM1.TituloMunicipio, TM1.TituloJurosMora, TM1.TituloTipo, T7.PropostaDescricao AS TituloPropostaDescricao, T7.PropostaTaxaAdministrativa, TM1.TituloCriacao, TM1.TituloPropostaTipo, T3.NotaFiscalNumero, T6.BancoNome AS AgenciaBancoNome, T4.ContaBancariaCarteira, T4.ContaBancariaNumero, T5.AgenciaNumero, TM1.ContaId, TM1.CategoriaTituloId, TM1.NotaFiscalParcelamentoID, TM1.ContaBancariaId, TM1.TituloPropostaId AS TituloPropostaId, TM1.TituloClienteId AS TituloClienteId, COALESCE( T9.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F, COALESCE( T10.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F, COALESCE( T11.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F, COALESCE( T12.TitulosCarteiraDeCobranca, '') AS TitulosCarteiraDeCobranca FROM (((((((((((Titulo TM1 LEFT JOIN NotaFiscalParcelamento T2 ON T2.NotaFiscalParcelamentoID = TM1.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T3 ON T3.NotaFiscalId = T2.NotaFiscalId) LEFT JOIN ContaBancaria T4 ON T4.ContaBancariaId = TM1.ContaBancariaId) LEFT JOIN Agencia T5 ON T5.AgenciaId = T4.AgenciaId) LEFT JOIN Banco T6 ON T6.BancoId = T5.AgenciaBancoId) LEFT JOIN Proposta T7 ON T7.PropostaId = TM1.TituloPropostaId) LEFT JOIN Cliente T8 ON T8.ClienteId = TM1.TituloClienteId) LEFT JOIN LATERAL (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento WHERE TM1.TituloId = TituloId "
          + " GROUP BY TituloId ) T9 ON T9.TituloId = TM1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (TM1.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T10 ON T10.TituloId = TM1.TituloId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (TM1.TituloId = TituloId) AND (Not TituloMovimentoSoma) GROUP BY TituloId ) T11 ON T11.TituloId = TM1.TituloId) LEFT JOIN LATERAL (SELECT MAX(T14.CarteiraDeCobrancaNome) AS TitulosCarteiraDeCobranca, T13.TituloId FROM (Boleto T13 LEFT JOIN CarteiraDeCobranca T14 ON T14.CarteiraDeCobrancaId = T13.CarteiraDeCobrancaId) WHERE TM1.TituloId = T13.TituloId GROUP BY T13.TituloId ) T12 ON T12.TituloId = TM1.TituloId) WHERE TM1.TituloId = :TituloId ORDER BY TM1.TituloId" ;
          Object[] prmT001527;
          prmT001527 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001529;
          prmT001529 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001531;
          prmT001531 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001533;
          prmT001533 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001534;
          prmT001534 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001535;
          prmT001535 = new Object[] {
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001536;
          prmT001536 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT001537;
          prmT001537 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT001538;
          prmT001538 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001539;
          prmT001539 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001540;
          prmT001540 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001541;
          prmT001541 = new Object[] {
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001542;
          prmT001542 = new Object[] {
          new ParDef("TituloClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001543;
          prmT001543 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001544;
          prmT001544 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001545;
          prmT001545 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001546;
          prmT001546 = new Object[] {
          new ParDef("TituloValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloDeleted",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloArchived",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloCompetenciaAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TituloCompetenciaMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TituloProrrogacao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloCEP",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("TituloLogradouro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloNumeroEndereco",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("TituloComplemento",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloBairro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloMunicipio",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TituloTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TituloCriacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("TituloPropostaTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001547;
          prmT001547 = new Object[] {
          };
          Object[] prmT001548;
          prmT001548 = new Object[] {
          new ParDef("TituloValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloDeleted",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloArchived",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloCompetenciaAno",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TituloCompetenciaMes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TituloProrrogacao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloCEP",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("TituloLogradouro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloNumeroEndereco",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("TituloComplemento",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloBairro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloMunicipio",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TituloJurosMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TituloTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TituloCriacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("TituloPropostaTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("CategoriaTituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001549;
          prmT001549 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001551;
          prmT001551 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001553;
          prmT001553 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001555;
          prmT001555 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001557;
          prmT001557 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001558;
          prmT001558 = new Object[] {
          new ParDef("NotaFiscalParcelamentoID",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT001559;
          prmT001559 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmT001560;
          prmT001560 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001561;
          prmT001561 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001562;
          prmT001562 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001563;
          prmT001563 = new Object[] {
          new ParDef("TituloPropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001564;
          prmT001564 = new Object[] {
          new ParDef("TituloClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001565;
          prmT001565 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001566;
          prmT001566 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001567;
          prmT001567 = new Object[] {
          };
          Object[] prmT001568;
          prmT001568 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001569;
          prmT001569 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001570;
          prmT001570 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001571;
          prmT001571 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT001572;
          prmT001572 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T00152", "SELECT TituloId, TituloValor, TituloDesconto, TituloDeleted, TituloArchived, TituloVencimento, TituloCompetenciaAno, TituloCompetenciaMes, TituloProrrogacao, TituloCEP, TituloLogradouro, TituloNumeroEndereco, TituloComplemento, TituloBairro, TituloMunicipio, TituloJurosMora, TituloTipo, TituloCriacao, TituloPropostaTipo, ContaId, CategoriaTituloId, NotaFiscalParcelamentoID, ContaBancariaId, TituloPropostaId, TituloClienteId FROM Titulo WHERE TituloId = :TituloId  FOR UPDATE OF Titulo NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00152,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00153", "SELECT TituloId, TituloValor, TituloDesconto, TituloDeleted, TituloArchived, TituloVencimento, TituloCompetenciaAno, TituloCompetenciaMes, TituloProrrogacao, TituloCEP, TituloLogradouro, TituloNumeroEndereco, TituloComplemento, TituloBairro, TituloMunicipio, TituloJurosMora, TituloTipo, TituloCriacao, TituloPropostaTipo, ContaId, CategoriaTituloId, NotaFiscalParcelamentoID, ContaBancariaId, TituloPropostaId, TituloClienteId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00153,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00154", "SELECT ContaId FROM Conta WHERE ContaId = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00154,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00155", "SELECT CategoriaTituloId FROM CategoriaTitulo WHERE CategoriaTituloId = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00155,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00156", "SELECT NotaFiscalId FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00156,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00157", "SELECT AgenciaId, ContaBancariaCarteira, ContaBancariaNumero FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00157,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00158", "SELECT PropostaDescricao AS TituloPropostaDescricao, PropostaTaxaAdministrativa FROM Proposta WHERE PropostaId = :TituloPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00158,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00159", "SELECT ClienteRazaoSocial AS TituloCLienteRazaoSocial FROM Cliente WHERE ClienteId = :TituloClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00159,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001510", "SELECT NotaFiscalNumero FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001510,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001511", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001511,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001512", "SELECT BancoNome AS AgenciaBancoNome FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001512,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001514", "SELECT COALESCE( T1.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F FROM (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001514,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001516", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001516,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001518", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE Not TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001518,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001520", "SELECT COALESCE( T1.TitulosCarteiraDeCobranca, '') AS TitulosCarteiraDeCobranca FROM (SELECT MAX(T3.CarteiraDeCobrancaNome) AS TitulosCarteiraDeCobranca, T2.TituloId FROM (Boleto T2 LEFT JOIN CarteiraDeCobranca T3 ON T3.CarteiraDeCobrancaId = T2.CarteiraDeCobrancaId) GROUP BY T2.TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001520,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001525", cmdBufferT001525,true, GxErrorMask.GX_NOMASK, false, this,prmT001525,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001527", "SELECT COALESCE( T1.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F FROM (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001527,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001529", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001529,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001531", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE Not TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001531,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001533", "SELECT COALESCE( T1.TitulosCarteiraDeCobranca, '') AS TitulosCarteiraDeCobranca FROM (SELECT MAX(T3.CarteiraDeCobrancaNome) AS TitulosCarteiraDeCobranca, T2.TituloId FROM (Boleto T2 LEFT JOIN CarteiraDeCobranca T3 ON T3.CarteiraDeCobrancaId = T2.CarteiraDeCobrancaId) GROUP BY T2.TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001533,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001534", "SELECT ContaId FROM Conta WHERE ContaId = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001534,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001535", "SELECT CategoriaTituloId FROM CategoriaTitulo WHERE CategoriaTituloId = :CategoriaTituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001535,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001536", "SELECT NotaFiscalId FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001536,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001537", "SELECT NotaFiscalNumero FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001537,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001538", "SELECT AgenciaId, ContaBancariaCarteira, ContaBancariaNumero FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001538,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001539", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001539,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001540", "SELECT BancoNome AS AgenciaBancoNome FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001540,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001541", "SELECT PropostaDescricao AS TituloPropostaDescricao, PropostaTaxaAdministrativa FROM Proposta WHERE PropostaId = :TituloPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001541,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001542", "SELECT ClienteRazaoSocial AS TituloCLienteRazaoSocial FROM Cliente WHERE ClienteId = :TituloClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001542,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001543", "SELECT TituloId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001543,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001544", "SELECT TituloId FROM Titulo WHERE ( TituloId > :TituloId) ORDER BY TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001544,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001545", "SELECT TituloId FROM Titulo WHERE ( TituloId < :TituloId) ORDER BY TituloId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001545,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001546", "SAVEPOINT gxupdate;INSERT INTO Titulo(TituloValor, TituloDesconto, TituloDeleted, TituloArchived, TituloVencimento, TituloCompetenciaAno, TituloCompetenciaMes, TituloProrrogacao, TituloCEP, TituloLogradouro, TituloNumeroEndereco, TituloComplemento, TituloBairro, TituloMunicipio, TituloJurosMora, TituloTipo, TituloCriacao, TituloPropostaTipo, ContaId, CategoriaTituloId, NotaFiscalParcelamentoID, ContaBancariaId, TituloPropostaId, TituloClienteId) VALUES(:TituloValor, :TituloDesconto, :TituloDeleted, :TituloArchived, :TituloVencimento, :TituloCompetenciaAno, :TituloCompetenciaMes, :TituloProrrogacao, :TituloCEP, :TituloLogradouro, :TituloNumeroEndereco, :TituloComplemento, :TituloBairro, :TituloMunicipio, :TituloJurosMora, :TituloTipo, :TituloCriacao, :TituloPropostaTipo, :ContaId, :CategoriaTituloId, :NotaFiscalParcelamentoID, :ContaBancariaId, :TituloPropostaId, :TituloClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001546)
             ,new CursorDef("T001547", "SELECT currval('TituloId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001547,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001548", "SAVEPOINT gxupdate;UPDATE Titulo SET TituloValor=:TituloValor, TituloDesconto=:TituloDesconto, TituloDeleted=:TituloDeleted, TituloArchived=:TituloArchived, TituloVencimento=:TituloVencimento, TituloCompetenciaAno=:TituloCompetenciaAno, TituloCompetenciaMes=:TituloCompetenciaMes, TituloProrrogacao=:TituloProrrogacao, TituloCEP=:TituloCEP, TituloLogradouro=:TituloLogradouro, TituloNumeroEndereco=:TituloNumeroEndereco, TituloComplemento=:TituloComplemento, TituloBairro=:TituloBairro, TituloMunicipio=:TituloMunicipio, TituloJurosMora=:TituloJurosMora, TituloTipo=:TituloTipo, TituloCriacao=:TituloCriacao, TituloPropostaTipo=:TituloPropostaTipo, ContaId=:ContaId, CategoriaTituloId=:CategoriaTituloId, NotaFiscalParcelamentoID=:NotaFiscalParcelamentoID, ContaBancariaId=:ContaBancariaId, TituloPropostaId=:TituloPropostaId, TituloClienteId=:TituloClienteId  WHERE TituloId = :TituloId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001548)
             ,new CursorDef("T001549", "SAVEPOINT gxupdate;DELETE FROM Titulo  WHERE TituloId = :TituloId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001549)
             ,new CursorDef("T001551", "SELECT COALESCE( T1.TituloDataCredito_F, DATE '00010101') AS TituloDataCredito_F FROM (SELECT MAX(TituloMovimentoDataCredito) AS TituloDataCredito_F, TituloId FROM TituloMovimento GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001551,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001553", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMovimento_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001553,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001555", "SELECT COALESCE( T1.TituloTotalMovimento_F, 0) AS TituloTotalMultaJuros_F FROM (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE Not TituloMovimentoSoma GROUP BY TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001555,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001557", "SELECT COALESCE( T1.TitulosCarteiraDeCobranca, '') AS TitulosCarteiraDeCobranca FROM (SELECT MAX(T3.CarteiraDeCobrancaNome) AS TitulosCarteiraDeCobranca, T2.TituloId FROM (Boleto T2 LEFT JOIN CarteiraDeCobranca T3 ON T3.CarteiraDeCobrancaId = T2.CarteiraDeCobrancaId) GROUP BY T2.TituloId ) T1 WHERE T1.TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001557,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001558", "SELECT NotaFiscalId FROM NotaFiscalParcelamento WHERE NotaFiscalParcelamentoID = :NotaFiscalParcelamentoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001558,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001559", "SELECT NotaFiscalNumero FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001559,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001560", "SELECT AgenciaId, ContaBancariaCarteira, ContaBancariaNumero FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001560,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001561", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001561,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001562", "SELECT BancoNome AS AgenciaBancoNome FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001562,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001563", "SELECT PropostaDescricao AS TituloPropostaDescricao, PropostaTaxaAdministrativa FROM Proposta WHERE PropostaId = :TituloPropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001563,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001564", "SELECT ClienteRazaoSocial AS TituloCLienteRazaoSocial FROM Cliente WHERE ClienteId = :TituloClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001564,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001565", "SELECT BoletosId FROM Boleto WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001565,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001566", "SELECT TituloMovimentoId FROM TituloMovimento WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001566,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T001567", "SELECT TituloId FROM Titulo ORDER BY TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001567,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001568", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001568,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001569", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001569,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001570", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( Not TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001570,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001571", "SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F FROM TituloMovimento WHERE ( TituloId = :TituloId) and ( Not TituloMovimentoSoma) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001571,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T001572", "SELECT COUNT(*) FROM Boleto WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT001572,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((Guid[]) buf[41])[0] = rslt.getGuid(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((Guid[]) buf[41])[0] = rslt.getGuid(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((int[]) buf[43])[0] = rslt.getInt(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((int[]) buf[45])[0] = rslt.getInt(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((int[]) buf[47])[0] = rslt.getInt(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((decimal[]) buf[37])[0] = rslt.getDecimal(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((decimal[]) buf[43])[0] = rslt.getDecimal(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((DateTime[]) buf[45])[0] = rslt.getGXDateTime(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((long[]) buf[53])[0] = rslt.getLong(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((long[]) buf[55])[0] = rslt.getLong(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((int[]) buf[57])[0] = rslt.getInt(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((int[]) buf[59])[0] = rslt.getInt(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((int[]) buf[61])[0] = rslt.getInt(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((Guid[]) buf[63])[0] = rslt.getGuid(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((int[]) buf[65])[0] = rslt.getInt(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((int[]) buf[67])[0] = rslt.getInt(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((int[]) buf[69])[0] = rslt.getInt(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((DateTime[]) buf[71])[0] = rslt.getGXDate(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((decimal[]) buf[73])[0] = rslt.getDecimal(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((decimal[]) buf[75])[0] = rslt.getDecimal(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((string[]) buf[77])[0] = rslt.getVarchar(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                return;
             case 16 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 22 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 23 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 27 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 28 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 29 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 31 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 33 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 36 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 37 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 38 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 39 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 40 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 41 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 42 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 43 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 44 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 45 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 46 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 47 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 48 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 49 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 50 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 51 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 52 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 53 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 54 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
    }

 }

}
