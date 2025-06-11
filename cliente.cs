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
   public class cliente : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel8"+"_"+"RESPONSAVELCELULAR_F") == 0 )
         {
            A454ResponsavelDDD = (short)(Math.Round(NumberUtil.Val( GetPar( "ResponsavelDDD"), "."), 18, MidpointRounding.ToEven));
            n454ResponsavelDDD = false;
            AssignAttri("", false, "A454ResponsavelDDD", ((0==A454ResponsavelDDD)&&IsIns( )||n454ResponsavelDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A454ResponsavelDDD), 4, 0, ".", ""))));
            A455ResponsavelNumero = (int)(Math.Round(NumberUtil.Val( GetPar( "ResponsavelNumero"), "."), 18, MidpointRounding.ToEven));
            n455ResponsavelNumero = false;
            AssignAttri("", false, "A455ResponsavelNumero", ((0==A455ResponsavelNumero)&&IsIns( )||n455ResponsavelNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A455ResponsavelNumero), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX8ASARESPONSAVELCELULAR_F0O28( A454ResponsavelDDD, A455ResponsavelNumero) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_52") == 0 )
         {
            A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_52( A168ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_53") == 0 )
         {
            A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_53( A168ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_54") == 0 )
         {
            A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_54( A168ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_55") == 0 )
         {
            A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_55( A168ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_56") == 0 )
         {
            A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_56( A168ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_51") == 0 )
         {
            A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            A780SerasaUltimaData_F = context.localUtil.ParseDTimeParm( GetPar( "SerasaUltimaData_F"));
            AssignAttri("", false, "A780SerasaUltimaData_F", context.localUtil.TToC( A780SerasaUltimaData_F, 8, 5, 0, 3, "/", ":", " "));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_51( A168ClienteId, A780SerasaUltimaData_F) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_57") == 0 )
         {
            A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_57( A168ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_42") == 0 )
         {
            A186MunicipioCodigo = GetPar( "MunicipioCodigo");
            n186MunicipioCodigo = false;
            AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_42( A186MunicipioCodigo) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_41") == 0 )
         {
            A192TipoClienteId = (short)(Math.Round(NumberUtil.Val( GetPar( "TipoClienteId"), "."), 18, MidpointRounding.ToEven));
            n192TipoClienteId = false;
            AssignAttri("", false, "A192TipoClienteId", ((0==A192TipoClienteId)&&IsIns( )||n192TipoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_41( A192TipoClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_43") == 0 )
         {
            A444ResponsavelMunicipio = GetPar( "ResponsavelMunicipio");
            n444ResponsavelMunicipio = false;
            AssignAttri("", false, "A444ResponsavelMunicipio", A444ResponsavelMunicipio);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_43( A444ResponsavelMunicipio) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_44") == 0 )
         {
            A402BancoId = (int)(Math.Round(NumberUtil.Val( GetPar( "BancoId"), "."), 18, MidpointRounding.ToEven));
            n402BancoId = false;
            AssignAttri("", false, "A402BancoId", ((0==A402BancoId)&&IsIns( )||n402BancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A402BancoId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_44( A402BancoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_45") == 0 )
         {
            A457EspecialidadeId = (int)(Math.Round(NumberUtil.Val( GetPar( "EspecialidadeId"), "."), 18, MidpointRounding.ToEven));
            n457EspecialidadeId = false;
            AssignAttri("", false, "A457EspecialidadeId", ((0==A457EspecialidadeId)&&IsIns( )||n457EspecialidadeId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A457EspecialidadeId), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_45( A457EspecialidadeId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_46") == 0 )
         {
            A437ResponsavelNacionalidade = (int)(Math.Round(NumberUtil.Val( GetPar( "ResponsavelNacionalidade"), "."), 18, MidpointRounding.ToEven));
            n437ResponsavelNacionalidade = false;
            AssignAttri("", false, "A437ResponsavelNacionalidade", ((0==A437ResponsavelNacionalidade)&&IsIns( )||n437ResponsavelNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A437ResponsavelNacionalidade), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_46( A437ResponsavelNacionalidade) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_47") == 0 )
         {
            A484ClienteNacionalidade = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteNacionalidade"), "."), 18, MidpointRounding.ToEven));
            n484ClienteNacionalidade = false;
            AssignAttri("", false, "A484ClienteNacionalidade", ((0==A484ClienteNacionalidade)&&IsIns( )||n484ClienteNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A484ClienteNacionalidade), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_47( A484ClienteNacionalidade) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_48") == 0 )
         {
            A442ResponsavelProfissao = (int)(Math.Round(NumberUtil.Val( GetPar( "ResponsavelProfissao"), "."), 18, MidpointRounding.ToEven));
            n442ResponsavelProfissao = false;
            AssignAttri("", false, "A442ResponsavelProfissao", ((0==A442ResponsavelProfissao)&&IsIns( )||n442ResponsavelProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A442ResponsavelProfissao), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_48( A442ResponsavelProfissao) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_49") == 0 )
         {
            A487ClienteProfissao = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteProfissao"), "."), 18, MidpointRounding.ToEven));
            n487ClienteProfissao = false;
            AssignAttri("", false, "A487ClienteProfissao", ((0==A487ClienteProfissao)&&IsIns( )||n487ClienteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A487ClienteProfissao), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_49( A487ClienteProfissao) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_50") == 0 )
         {
            A489ClienteConvenio = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteConvenio"), "."), 18, MidpointRounding.ToEven));
            n489ClienteConvenio = false;
            AssignAttri("", false, "A489ClienteConvenio", ((0==A489ClienteConvenio)&&IsIns( )||n489ClienteConvenio ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A489ClienteConvenio), 9, 0, ".", ""))));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_50( A489ClienteConvenio) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "cliente")), "cliente") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "cliente")))) ;
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
                  AV7ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7ClienteId", StringUtil.LTrimStr( (decimal)(AV7ClienteId), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteId), "ZZZZZZZZ9"), context));
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
         Form.Meta.addItem("description", "Cliente", 0) ;
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtClienteDocumento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ClienteId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ClienteId = aP1_ClienteId;
         ExecuteImpl();
      }

      protected override void ExecutePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbClienteTipoPessoa = new GXCombobox();
         cmbClienteStatus = new GXCombobox();
         cmbEnderecoTipo = new GXCombobox();
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
         if ( cmbClienteTipoPessoa.ItemCount > 0 )
         {
            A172ClienteTipoPessoa = cmbClienteTipoPessoa.getValidValue(A172ClienteTipoPessoa);
            n172ClienteTipoPessoa = false;
            AssignAttri("", false, "A172ClienteTipoPessoa", A172ClienteTipoPessoa);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbClienteTipoPessoa.CurrentValue = StringUtil.RTrim( A172ClienteTipoPessoa);
            AssignProp("", false, cmbClienteTipoPessoa_Internalname, "Values", cmbClienteTipoPessoa.ToJavascriptSource(), true);
         }
         if ( cmbClienteStatus.ItemCount > 0 )
         {
            A174ClienteStatus = StringUtil.StrToBool( cmbClienteStatus.getValidValue(StringUtil.BoolToStr( A174ClienteStatus)));
            n174ClienteStatus = false;
            AssignAttri("", false, "A174ClienteStatus", A174ClienteStatus);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbClienteStatus.CurrentValue = StringUtil.BoolToStr( A174ClienteStatus);
            AssignProp("", false, cmbClienteStatus_Internalname, "Values", cmbClienteStatus.ToJavascriptSource(), true);
         }
         if ( cmbEnderecoTipo.ItemCount > 0 )
         {
            A181EnderecoTipo = cmbEnderecoTipo.getValidValue(A181EnderecoTipo);
            n181EnderecoTipo = false;
            AssignAttri("", false, "A181EnderecoTipo", A181EnderecoTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbEnderecoTipo.CurrentValue = StringUtil.RTrim( A181EnderecoTipo);
            AssignProp("", false, cmbEnderecoTipo_Internalname, "Values", cmbEnderecoTipo.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteDocumento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteDocumento_Internalname, "Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteDocumento_Internalname, A169ClienteDocumento, StringUtil.RTrim( context.localUtil.Format( A169ClienteDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteDocumento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClienteDocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteRazaoSocial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteRazaoSocial_Internalname, "Razão social", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteRazaoSocial_Internalname, A170ClienteRazaoSocial, StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteRazaoSocial_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClienteRazaoSocial_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteNomeFantasia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteNomeFantasia_Internalname, "Nome fantasia", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteNomeFantasia_Internalname, A171ClienteNomeFantasia, StringUtil.RTrim( context.localUtil.Format( A171ClienteNomeFantasia, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteNomeFantasia_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClienteNomeFantasia_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbClienteTipoPessoa_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbClienteTipoPessoa_Internalname, "Tipo pessoa", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbClienteTipoPessoa, cmbClienteTipoPessoa_Internalname, StringUtil.RTrim( A172ClienteTipoPessoa), 1, cmbClienteTipoPessoa_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbClienteTipoPessoa.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "", true, 0, "HLP_Cliente.htm");
         cmbClienteTipoPessoa.CurrentValue = StringUtil.RTrim( A172ClienteTipoPessoa);
         AssignProp("", false, cmbClienteTipoPessoa_Internalname, "Values", (string)(cmbClienteTipoPessoa.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTipoClienteDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoClienteDescricao_Internalname, "Tipo cliente", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoClienteDescricao_Internalname, A193TipoClienteDescricao, StringUtil.RTrim( context.localUtil.Format( A193TipoClienteDescricao, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoClienteDescricao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTipoClienteDescricao_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbClienteStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbClienteStatus_Internalname, "Status", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbClienteStatus, cmbClienteStatus_Internalname, StringUtil.BoolToStr( A174ClienteStatus), 1, cmbClienteStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbClienteStatus.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "", true, 0, "HLP_Cliente.htm");
         cmbClienteStatus.CurrentValue = StringUtil.BoolToStr( A174ClienteStatus);
         AssignProp("", false, cmbClienteStatus_Internalname, "Values", (string)(cmbClienteStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbEnderecoTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbEnderecoTipo_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbEnderecoTipo, cmbEnderecoTipo_Internalname, StringUtil.RTrim( A181EnderecoTipo), 1, cmbEnderecoTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbEnderecoTipo.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 0, "HLP_Cliente.htm");
         cmbEnderecoTipo.CurrentValue = StringUtil.RTrim( A181EnderecoTipo);
         AssignProp("", false, cmbEnderecoTipo_Internalname, "Values", (string)(cmbEnderecoTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEnderecoCEP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEnderecoCEP_Internalname, "CEP", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEnderecoCEP_Internalname, A182EnderecoCEP, StringUtil.RTrim( context.localUtil.Format( A182EnderecoCEP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEnderecoCEP_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEnderecoCEP_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEnderecoLogradouro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEnderecoLogradouro_Internalname, "Logradouro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEnderecoLogradouro_Internalname, A183EnderecoLogradouro, StringUtil.RTrim( context.localUtil.Format( A183EnderecoLogradouro, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEnderecoLogradouro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEnderecoLogradouro_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEnderecoBairro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEnderecoBairro_Internalname, "Bairro", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEnderecoBairro_Internalname, A184EnderecoBairro, StringUtil.RTrim( context.localUtil.Format( A184EnderecoBairro, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEnderecoBairro_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEnderecoBairro_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEnderecoCidade_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEnderecoCidade_Internalname, "Cidade", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEnderecoCidade_Internalname, A185EnderecoCidade, StringUtil.RTrim( context.localUtil.Format( A185EnderecoCidade, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEnderecoCidade_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEnderecoCidade_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedmunicipiocodigo_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockmunicipiocodigo_Internalname, "Municipio", "", "", lblTextblockmunicipiocodigo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_municipiocodigo.SetProperty("Caption", Combo_municipiocodigo_Caption);
         ucCombo_municipiocodigo.SetProperty("Cls", Combo_municipiocodigo_Cls);
         ucCombo_municipiocodigo.SetProperty("DataListProc", Combo_municipiocodigo_Datalistproc);
         ucCombo_municipiocodigo.SetProperty("DataListProcParametersPrefix", Combo_municipiocodigo_Datalistprocparametersprefix);
         ucCombo_municipiocodigo.SetProperty("DropDownOptionsTitleSettingsIcons", AV19DDO_TitleSettingsIcons);
         ucCombo_municipiocodigo.SetProperty("DropDownOptionsData", AV18MunicipioCodigo_Data);
         ucCombo_municipiocodigo.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_municipiocodigo_Internalname, "COMBO_MUNICIPIOCODIGOContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMunicipioCodigo_Internalname, "Municipio Codigo", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMunicipioCodigo_Internalname, A186MunicipioCodigo, StringUtil.RTrim( context.localUtil.Format( A186MunicipioCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioCodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtMunicipioCodigo_Visible, edtMunicipioCodigo_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtMunicipioUF_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMunicipioUF_Internalname, "Municipio UF", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMunicipioUF_Internalname, A189MunicipioUF, StringUtil.RTrim( context.localUtil.Format( A189MunicipioUF, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMunicipioUF_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtMunicipioUF_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEnderecoNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEnderecoNumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEnderecoNumero_Internalname, A190EnderecoNumero, StringUtil.RTrim( context.localUtil.Format( A190EnderecoNumero, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEnderecoNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEnderecoNumero_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtEnderecoComplemento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEnderecoComplemento_Internalname, "Complemento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEnderecoComplemento_Internalname, A191EnderecoComplemento, StringUtil.RTrim( context.localUtil.Format( A191EnderecoComplemento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEnderecoComplemento_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtEnderecoComplemento_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContatoEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContatoEmail_Internalname, "E-mail", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContatoEmail_Internalname, A201ContatoEmail, StringUtil.RTrim( context.localUtil.Format( A201ContatoEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A201ContatoEmail, "", "", "", edtContatoEmail_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContatoEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContatoDDD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContatoDDD_Internalname, "DDD", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContatoDDD_Internalname, ((0==A198ContatoDDD)&&IsIns( )||n198ContatoDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A198ContatoDDD), 4, 0, ",", ""))), ((0==A198ContatoDDD)&&IsIns( )||n198ContatoDDD ? "" : StringUtil.LTrim( ((edtContatoDDD_Enabled!=0) ? context.localUtil.Format( (decimal)(A198ContatoDDD), "ZZZ9") : context.localUtil.Format( (decimal)(A198ContatoDDD), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContatoDDD_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContatoDDD_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContatoNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContatoNumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContatoNumero_Internalname, ((0==A200ContatoNumero)&&IsIns( )||n200ContatoNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A200ContatoNumero), 18, 0, ",", ""))), ((0==A200ContatoNumero)&&IsIns( )||n200ContatoNumero ? "" : StringUtil.LTrim( ((edtContatoNumero_Enabled!=0) ? context.localUtil.Format( (decimal)(A200ContatoNumero), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A200ContatoNumero), "ZZZZZZZZZZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,100);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContatoNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContatoNumero_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContatoTelefoneNumero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContatoTelefoneNumero_Internalname, "Número", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContatoTelefoneNumero_Internalname, ((0==A202ContatoTelefoneNumero)&&IsIns( )||n202ContatoTelefoneNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A202ContatoTelefoneNumero), 18, 0, ",", ""))), ((0==A202ContatoTelefoneNumero)&&IsIns( )||n202ContatoTelefoneNumero ? "" : StringUtil.LTrim( ((edtContatoTelefoneNumero_Enabled!=0) ? context.localUtil.Format( (decimal)(A202ContatoTelefoneNumero), "ZZZZZZZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A202ContatoTelefoneNumero), "ZZZZZZZZZZZZZZZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContatoTelefoneNumero_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContatoTelefoneNumero_Enabled, 0, "text", "1", 18, "chr", 1, "row", 18, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContatoTelefoneDDD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContatoTelefoneDDD_Internalname, "DDD", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContatoTelefoneDDD_Internalname, ((0==A203ContatoTelefoneDDD)&&IsIns( )||n203ContatoTelefoneDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A203ContatoTelefoneDDD), 4, 0, ",", ""))), ((0==A203ContatoTelefoneDDD)&&IsIns( )||n203ContatoTelefoneDDD ? "" : StringUtil.LTrim( ((edtContatoTelefoneDDD_Enabled!=0) ? context.localUtil.Format( (decimal)(A203ContatoTelefoneDDD), "ZZZ9") : context.localUtil.Format( (decimal)(A203ContatoTelefoneDDD), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContatoTelefoneDDD_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContatoTelefoneDDD_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContatoTelefoneDDI_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContatoTelefoneDDI_Internalname, "DDI", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContatoTelefoneDDI_Internalname, ((0==A204ContatoTelefoneDDI)&&IsIns( )||n204ContatoTelefoneDDI ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A204ContatoTelefoneDDI), 4, 0, ",", ""))), ((0==A204ContatoTelefoneDDI)&&IsIns( )||n204ContatoTelefoneDDI ? "" : StringUtil.LTrim( ((edtContatoTelefoneDDI_Enabled!=0) ? context.localUtil.Format( (decimal)(A204ContatoTelefoneDDI), "ZZZ9") : context.localUtil.Format( (decimal)(A204ContatoTelefoneDDI), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContatoTelefoneDDI_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContatoTelefoneDDI_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtContatoDDI_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtContatoDDI_Internalname, "DDI", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 117,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtContatoDDI_Internalname, ((0==A199ContatoDDI)&&IsIns( )||n199ContatoDDI ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A199ContatoDDI), 4, 0, ",", ""))), ((0==A199ContatoDDI)&&IsIns( )||n199ContatoDDI ? "" : StringUtil.LTrim( ((edtContatoDDI_Enabled!=0) ? context.localUtil.Format( (decimal)(A199ContatoDDI), "ZZZ9") : context.localUtil.Format( (decimal)(A199ContatoDDI), "ZZZ9")))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,117);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtContatoDDI_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtContatoDDI_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteTelefone_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteTelefone_F_Internalname, "Telefone", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteTelefone_F_Internalname, A205ClienteTelefone_F, StringUtil.RTrim( context.localUtil.Format( A205ClienteTelefone_F, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteTelefone_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClienteTelefone_F_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtClienteCelular_F_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteCelular_F_Internalname, "Celular", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteCelular_F_Internalname, A206ClienteCelular_F, StringUtil.RTrim( context.localUtil.Format( A206ClienteCelular_F, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,125);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCelular_F_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtClienteCelular_F_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
         ClassString = "Button";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
         ClassString = "BtnDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_municipiocodigo_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtavCombomunicipiocodigo_Internalname, AV23ComboMunicipioCodigo, StringUtil.RTrim( context.localUtil.Format( AV23ComboMunicipioCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombomunicipiocodigo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombomunicipiocodigo_Visible, edtavCombomunicipiocodigo_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 140,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A168ClienteId), 9, 0, ",", "")), StringUtil.LTrim( ((edtClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,140);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", edtClienteId_Visible, edtClienteId_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 0, -1, 0, true, "Id", "end", false, "", "HLP_Cliente.htm");
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
         E110O2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV19DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vMUNICIPIOCODIGO_DATA"), AV18MunicipioCodigo_Data);
               /* Read saved values. */
               Z168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z168ClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               Z175ClienteCreatedAt = context.localUtil.CToT( cgiGet( "Z175ClienteCreatedAt"), 0);
               n175ClienteCreatedAt = ((DateTime.MinValue==A175ClienteCreatedAt) ? true : false);
               Z176ClienteUpdatedAt = context.localUtil.CToT( cgiGet( "Z176ClienteUpdatedAt"), 0);
               n176ClienteUpdatedAt = ((DateTime.MinValue==A176ClienteUpdatedAt) ? true : false);
               Z169ClienteDocumento = cgiGet( "Z169ClienteDocumento");
               n169ClienteDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A169ClienteDocumento)) ? true : false);
               Z170ClienteRazaoSocial = cgiGet( "Z170ClienteRazaoSocial");
               n170ClienteRazaoSocial = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? true : false);
               Z171ClienteNomeFantasia = cgiGet( "Z171ClienteNomeFantasia");
               n171ClienteNomeFantasia = (String.IsNullOrEmpty(StringUtil.RTrim( A171ClienteNomeFantasia)) ? true : false);
               Z459ClienteDataNascimento = context.localUtil.CToD( cgiGet( "Z459ClienteDataNascimento"), 0);
               n459ClienteDataNascimento = ((DateTime.MinValue==A459ClienteDataNascimento) ? true : false);
               Z172ClienteTipoPessoa = cgiGet( "Z172ClienteTipoPessoa");
               n172ClienteTipoPessoa = (String.IsNullOrEmpty(StringUtil.RTrim( A172ClienteTipoPessoa)) ? true : false);
               Z174ClienteStatus = StringUtil.StrToBool( cgiGet( "Z174ClienteStatus"));
               n174ClienteStatus = ((false==A174ClienteStatus) ? true : false);
               Z177ClienteLogUser = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z177ClienteLogUser"), ",", "."), 18, MidpointRounding.ToEven));
               n177ClienteLogUser = ((0==A177ClienteLogUser) ? true : false);
               Z486ClienteEstadoCivil = cgiGet( "Z486ClienteEstadoCivil");
               n486ClienteEstadoCivil = (String.IsNullOrEmpty(StringUtil.RTrim( A486ClienteEstadoCivil)) ? true : false);
               Z181EnderecoTipo = cgiGet( "Z181EnderecoTipo");
               n181EnderecoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A181EnderecoTipo)) ? true : false);
               Z182EnderecoCEP = cgiGet( "Z182EnderecoCEP");
               n182EnderecoCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A182EnderecoCEP)) ? true : false);
               Z183EnderecoLogradouro = cgiGet( "Z183EnderecoLogradouro");
               n183EnderecoLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A183EnderecoLogradouro)) ? true : false);
               Z184EnderecoBairro = cgiGet( "Z184EnderecoBairro");
               n184EnderecoBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A184EnderecoBairro)) ? true : false);
               Z185EnderecoCidade = cgiGet( "Z185EnderecoCidade");
               n185EnderecoCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A185EnderecoCidade)) ? true : false);
               Z190EnderecoNumero = cgiGet( "Z190EnderecoNumero");
               n190EnderecoNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A190EnderecoNumero)) ? true : false);
               Z191EnderecoComplemento = cgiGet( "Z191EnderecoComplemento");
               n191EnderecoComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A191EnderecoComplemento)) ? true : false);
               Z201ContatoEmail = cgiGet( "Z201ContatoEmail");
               n201ContatoEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A201ContatoEmail)) ? true : false);
               Z198ContatoDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z198ContatoDDD"), ",", "."), 18, MidpointRounding.ToEven));
               n198ContatoDDD = ((0==A198ContatoDDD) ? true : false);
               Z199ContatoDDI = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z199ContatoDDI"), ",", "."), 18, MidpointRounding.ToEven));
               n199ContatoDDI = ((0==A199ContatoDDI) ? true : false);
               Z200ContatoNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z200ContatoNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n200ContatoNumero = ((0==A200ContatoNumero) ? true : false);
               Z202ContatoTelefoneNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z202ContatoTelefoneNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n202ContatoTelefoneNumero = ((0==A202ContatoTelefoneNumero) ? true : false);
               Z203ContatoTelefoneDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z203ContatoTelefoneDDD"), ",", "."), 18, MidpointRounding.ToEven));
               n203ContatoTelefoneDDD = ((0==A203ContatoTelefoneDDD) ? true : false);
               Z204ContatoTelefoneDDI = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z204ContatoTelefoneDDI"), ",", "."), 18, MidpointRounding.ToEven));
               n204ContatoTelefoneDDI = ((0==A204ContatoTelefoneDDI) ? true : false);
               Z421ClienteRG = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z421ClienteRG"), ",", "."), 18, MidpointRounding.ToEven));
               n421ClienteRG = ((0==A421ClienteRG) ? true : false);
               Z537ClienteDepositoTipo = cgiGet( "Z537ClienteDepositoTipo");
               n537ClienteDepositoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A537ClienteDepositoTipo)) ? true : false);
               Z538ClientePixTipo = cgiGet( "Z538ClientePixTipo");
               n538ClientePixTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A538ClientePixTipo)) ? true : false);
               Z539ClientePix = cgiGet( "Z539ClientePix");
               n539ClientePix = (String.IsNullOrEmpty(StringUtil.RTrim( A539ClientePix)) ? true : false);
               Z400ContaAgencia = cgiGet( "Z400ContaAgencia");
               n400ContaAgencia = (String.IsNullOrEmpty(StringUtil.RTrim( A400ContaAgencia)) ? true : false);
               Z401ContaNumero = cgiGet( "Z401ContaNumero");
               n401ContaNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A401ContaNumero)) ? true : false);
               Z436ResponsavelNome = cgiGet( "Z436ResponsavelNome");
               n436ResponsavelNome = (String.IsNullOrEmpty(StringUtil.RTrim( A436ResponsavelNome)) ? true : false);
               Z439ResponsavelEstadoCivil = cgiGet( "Z439ResponsavelEstadoCivil");
               n439ResponsavelEstadoCivil = (String.IsNullOrEmpty(StringUtil.RTrim( A439ResponsavelEstadoCivil)) ? true : false);
               Z576ResponsavelRG = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z576ResponsavelRG"), ",", "."), 18, MidpointRounding.ToEven));
               n576ResponsavelRG = ((0==A576ResponsavelRG) ? true : false);
               Z447ResponsavelCPF = cgiGet( "Z447ResponsavelCPF");
               n447ResponsavelCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A447ResponsavelCPF)) ? true : false);
               Z448ResponsavelCEP = cgiGet( "Z448ResponsavelCEP");
               n448ResponsavelCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A448ResponsavelCEP)) ? true : false);
               Z449ResponsavelLogradouro = cgiGet( "Z449ResponsavelLogradouro");
               n449ResponsavelLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A449ResponsavelLogradouro)) ? true : false);
               Z450ResponsavelBairro = cgiGet( "Z450ResponsavelBairro");
               n450ResponsavelBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A450ResponsavelBairro)) ? true : false);
               Z451ResponsavelCidade = cgiGet( "Z451ResponsavelCidade");
               n451ResponsavelCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A451ResponsavelCidade)) ? true : false);
               Z452ResponsavelLogradouroNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z452ResponsavelLogradouroNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n452ResponsavelLogradouroNumero = ((0==A452ResponsavelLogradouroNumero) ? true : false);
               Z453ResponsavelComplemento = cgiGet( "Z453ResponsavelComplemento");
               n453ResponsavelComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A453ResponsavelComplemento)) ? true : false);
               Z454ResponsavelDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z454ResponsavelDDD"), ",", "."), 18, MidpointRounding.ToEven));
               n454ResponsavelDDD = ((0==A454ResponsavelDDD) ? true : false);
               Z455ResponsavelNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z455ResponsavelNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n455ResponsavelNumero = ((0==A455ResponsavelNumero) ? true : false);
               Z456ResponsavelEmail = cgiGet( "Z456ResponsavelEmail");
               n456ResponsavelEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A456ResponsavelEmail)) ? true : false);
               Z884ClienteSituacao = cgiGet( "Z884ClienteSituacao");
               n884ClienteSituacao = (String.IsNullOrEmpty(StringUtil.RTrim( A884ClienteSituacao)) ? true : false);
               Z885ResponsavelCargo = cgiGet( "Z885ResponsavelCargo");
               n885ResponsavelCargo = (String.IsNullOrEmpty(StringUtil.RTrim( A885ResponsavelCargo)) ? true : false);
               Z1039ClienteTipoRisco = cgiGet( "Z1039ClienteTipoRisco");
               Z192TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z192TipoClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n192TipoClienteId = ((0==A192TipoClienteId) ? true : false);
               Z186MunicipioCodigo = cgiGet( "Z186MunicipioCodigo");
               n186MunicipioCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ? true : false);
               Z444ResponsavelMunicipio = cgiGet( "Z444ResponsavelMunicipio");
               n444ResponsavelMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A444ResponsavelMunicipio)) ? true : false);
               Z402BancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z402BancoId"), ",", "."), 18, MidpointRounding.ToEven));
               n402BancoId = ((0==A402BancoId) ? true : false);
               Z457EspecialidadeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z457EspecialidadeId"), ",", "."), 18, MidpointRounding.ToEven));
               n457EspecialidadeId = ((0==A457EspecialidadeId) ? true : false);
               Z437ResponsavelNacionalidade = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z437ResponsavelNacionalidade"), ",", "."), 18, MidpointRounding.ToEven));
               n437ResponsavelNacionalidade = ((0==A437ResponsavelNacionalidade) ? true : false);
               Z484ClienteNacionalidade = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z484ClienteNacionalidade"), ",", "."), 18, MidpointRounding.ToEven));
               n484ClienteNacionalidade = ((0==A484ClienteNacionalidade) ? true : false);
               Z442ResponsavelProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z442ResponsavelProfissao"), ",", "."), 18, MidpointRounding.ToEven));
               n442ResponsavelProfissao = ((0==A442ResponsavelProfissao) ? true : false);
               Z487ClienteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z487ClienteProfissao"), ",", "."), 18, MidpointRounding.ToEven));
               n487ClienteProfissao = ((0==A487ClienteProfissao) ? true : false);
               Z489ClienteConvenio = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z489ClienteConvenio"), ",", "."), 18, MidpointRounding.ToEven));
               n489ClienteConvenio = ((0==A489ClienteConvenio) ? true : false);
               A175ClienteCreatedAt = context.localUtil.CToT( cgiGet( "Z175ClienteCreatedAt"), 0);
               n175ClienteCreatedAt = false;
               n175ClienteCreatedAt = ((DateTime.MinValue==A175ClienteCreatedAt) ? true : false);
               A176ClienteUpdatedAt = context.localUtil.CToT( cgiGet( "Z176ClienteUpdatedAt"), 0);
               n176ClienteUpdatedAt = false;
               n176ClienteUpdatedAt = ((DateTime.MinValue==A176ClienteUpdatedAt) ? true : false);
               A459ClienteDataNascimento = context.localUtil.CToD( cgiGet( "Z459ClienteDataNascimento"), 0);
               n459ClienteDataNascimento = false;
               n459ClienteDataNascimento = ((DateTime.MinValue==A459ClienteDataNascimento) ? true : false);
               A177ClienteLogUser = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z177ClienteLogUser"), ",", "."), 18, MidpointRounding.ToEven));
               n177ClienteLogUser = false;
               n177ClienteLogUser = ((0==A177ClienteLogUser) ? true : false);
               A486ClienteEstadoCivil = cgiGet( "Z486ClienteEstadoCivil");
               n486ClienteEstadoCivil = false;
               n486ClienteEstadoCivil = (String.IsNullOrEmpty(StringUtil.RTrim( A486ClienteEstadoCivil)) ? true : false);
               A421ClienteRG = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z421ClienteRG"), ",", "."), 18, MidpointRounding.ToEven));
               n421ClienteRG = false;
               n421ClienteRG = ((0==A421ClienteRG) ? true : false);
               A537ClienteDepositoTipo = cgiGet( "Z537ClienteDepositoTipo");
               n537ClienteDepositoTipo = false;
               n537ClienteDepositoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A537ClienteDepositoTipo)) ? true : false);
               A538ClientePixTipo = cgiGet( "Z538ClientePixTipo");
               n538ClientePixTipo = false;
               n538ClientePixTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A538ClientePixTipo)) ? true : false);
               A539ClientePix = cgiGet( "Z539ClientePix");
               n539ClientePix = false;
               n539ClientePix = (String.IsNullOrEmpty(StringUtil.RTrim( A539ClientePix)) ? true : false);
               A400ContaAgencia = cgiGet( "Z400ContaAgencia");
               n400ContaAgencia = false;
               n400ContaAgencia = (String.IsNullOrEmpty(StringUtil.RTrim( A400ContaAgencia)) ? true : false);
               A401ContaNumero = cgiGet( "Z401ContaNumero");
               n401ContaNumero = false;
               n401ContaNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A401ContaNumero)) ? true : false);
               A436ResponsavelNome = cgiGet( "Z436ResponsavelNome");
               n436ResponsavelNome = false;
               n436ResponsavelNome = (String.IsNullOrEmpty(StringUtil.RTrim( A436ResponsavelNome)) ? true : false);
               A439ResponsavelEstadoCivil = cgiGet( "Z439ResponsavelEstadoCivil");
               n439ResponsavelEstadoCivil = false;
               n439ResponsavelEstadoCivil = (String.IsNullOrEmpty(StringUtil.RTrim( A439ResponsavelEstadoCivil)) ? true : false);
               A576ResponsavelRG = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z576ResponsavelRG"), ",", "."), 18, MidpointRounding.ToEven));
               n576ResponsavelRG = false;
               n576ResponsavelRG = ((0==A576ResponsavelRG) ? true : false);
               A447ResponsavelCPF = cgiGet( "Z447ResponsavelCPF");
               n447ResponsavelCPF = false;
               n447ResponsavelCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A447ResponsavelCPF)) ? true : false);
               A448ResponsavelCEP = cgiGet( "Z448ResponsavelCEP");
               n448ResponsavelCEP = false;
               n448ResponsavelCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A448ResponsavelCEP)) ? true : false);
               A449ResponsavelLogradouro = cgiGet( "Z449ResponsavelLogradouro");
               n449ResponsavelLogradouro = false;
               n449ResponsavelLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A449ResponsavelLogradouro)) ? true : false);
               A450ResponsavelBairro = cgiGet( "Z450ResponsavelBairro");
               n450ResponsavelBairro = false;
               n450ResponsavelBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A450ResponsavelBairro)) ? true : false);
               A451ResponsavelCidade = cgiGet( "Z451ResponsavelCidade");
               n451ResponsavelCidade = false;
               n451ResponsavelCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A451ResponsavelCidade)) ? true : false);
               A452ResponsavelLogradouroNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z452ResponsavelLogradouroNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n452ResponsavelLogradouroNumero = false;
               n452ResponsavelLogradouroNumero = ((0==A452ResponsavelLogradouroNumero) ? true : false);
               A453ResponsavelComplemento = cgiGet( "Z453ResponsavelComplemento");
               n453ResponsavelComplemento = false;
               n453ResponsavelComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A453ResponsavelComplemento)) ? true : false);
               A454ResponsavelDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z454ResponsavelDDD"), ",", "."), 18, MidpointRounding.ToEven));
               n454ResponsavelDDD = false;
               n454ResponsavelDDD = ((0==A454ResponsavelDDD) ? true : false);
               A455ResponsavelNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z455ResponsavelNumero"), ",", "."), 18, MidpointRounding.ToEven));
               n455ResponsavelNumero = false;
               n455ResponsavelNumero = ((0==A455ResponsavelNumero) ? true : false);
               A456ResponsavelEmail = cgiGet( "Z456ResponsavelEmail");
               n456ResponsavelEmail = false;
               n456ResponsavelEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A456ResponsavelEmail)) ? true : false);
               A884ClienteSituacao = cgiGet( "Z884ClienteSituacao");
               n884ClienteSituacao = false;
               n884ClienteSituacao = (String.IsNullOrEmpty(StringUtil.RTrim( A884ClienteSituacao)) ? true : false);
               A885ResponsavelCargo = cgiGet( "Z885ResponsavelCargo");
               n885ResponsavelCargo = false;
               n885ResponsavelCargo = (String.IsNullOrEmpty(StringUtil.RTrim( A885ResponsavelCargo)) ? true : false);
               A1039ClienteTipoRisco = cgiGet( "Z1039ClienteTipoRisco");
               A192TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z192TipoClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n192TipoClienteId = false;
               n192TipoClienteId = ((0==A192TipoClienteId) ? true : false);
               A444ResponsavelMunicipio = cgiGet( "Z444ResponsavelMunicipio");
               n444ResponsavelMunicipio = false;
               n444ResponsavelMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A444ResponsavelMunicipio)) ? true : false);
               A402BancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z402BancoId"), ",", "."), 18, MidpointRounding.ToEven));
               n402BancoId = false;
               n402BancoId = ((0==A402BancoId) ? true : false);
               A457EspecialidadeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z457EspecialidadeId"), ",", "."), 18, MidpointRounding.ToEven));
               n457EspecialidadeId = false;
               n457EspecialidadeId = ((0==A457EspecialidadeId) ? true : false);
               A437ResponsavelNacionalidade = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z437ResponsavelNacionalidade"), ",", "."), 18, MidpointRounding.ToEven));
               n437ResponsavelNacionalidade = false;
               n437ResponsavelNacionalidade = ((0==A437ResponsavelNacionalidade) ? true : false);
               A484ClienteNacionalidade = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z484ClienteNacionalidade"), ",", "."), 18, MidpointRounding.ToEven));
               n484ClienteNacionalidade = false;
               n484ClienteNacionalidade = ((0==A484ClienteNacionalidade) ? true : false);
               A442ResponsavelProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z442ResponsavelProfissao"), ",", "."), 18, MidpointRounding.ToEven));
               n442ResponsavelProfissao = false;
               n442ResponsavelProfissao = ((0==A442ResponsavelProfissao) ? true : false);
               A487ClienteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z487ClienteProfissao"), ",", "."), 18, MidpointRounding.ToEven));
               n487ClienteProfissao = false;
               n487ClienteProfissao = ((0==A487ClienteProfissao) ? true : false);
               A489ClienteConvenio = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z489ClienteConvenio"), ",", "."), 18, MidpointRounding.ToEven));
               n489ClienteConvenio = false;
               n489ClienteConvenio = ((0==A489ClienteConvenio) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N457EspecialidadeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N457EspecialidadeId"), ",", "."), 18, MidpointRounding.ToEven));
               n457EspecialidadeId = ((0==A457EspecialidadeId) ? true : false);
               N192TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "N192TipoClienteId"), ",", "."), 18, MidpointRounding.ToEven));
               n192TipoClienteId = ((0==A192TipoClienteId) ? true : false);
               N489ClienteConvenio = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N489ClienteConvenio"), ",", "."), 18, MidpointRounding.ToEven));
               n489ClienteConvenio = ((0==A489ClienteConvenio) ? true : false);
               N484ClienteNacionalidade = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N484ClienteNacionalidade"), ",", "."), 18, MidpointRounding.ToEven));
               n484ClienteNacionalidade = ((0==A484ClienteNacionalidade) ? true : false);
               N487ClienteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N487ClienteProfissao"), ",", "."), 18, MidpointRounding.ToEven));
               n487ClienteProfissao = ((0==A487ClienteProfissao) ? true : false);
               N186MunicipioCodigo = cgiGet( "N186MunicipioCodigo");
               n186MunicipioCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ? true : false);
               N402BancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N402BancoId"), ",", "."), 18, MidpointRounding.ToEven));
               n402BancoId = ((0==A402BancoId) ? true : false);
               N437ResponsavelNacionalidade = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N437ResponsavelNacionalidade"), ",", "."), 18, MidpointRounding.ToEven));
               n437ResponsavelNacionalidade = ((0==A437ResponsavelNacionalidade) ? true : false);
               N442ResponsavelProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N442ResponsavelProfissao"), ",", "."), 18, MidpointRounding.ToEven));
               n442ResponsavelProfissao = ((0==A442ResponsavelProfissao) ? true : false);
               N444ResponsavelMunicipio = cgiGet( "N444ResponsavelMunicipio");
               n444ResponsavelMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A444ResponsavelMunicipio)) ? true : false);
               A454ResponsavelDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( "RESPONSAVELDDD"), ",", "."), 18, MidpointRounding.ToEven));
               n454ResponsavelDDD = ((0==A454ResponsavelDDD) ? true : false);
               A455ResponsavelNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESPONSAVELNUMERO"), ",", "."), 18, MidpointRounding.ToEven));
               n455ResponsavelNumero = ((0==A455ResponsavelNumero) ? true : false);
               A577ResponsavelCelular_F = cgiGet( "RESPONSAVELCELULAR_F");
               A1031RelacionamentoSacado = (short)(Math.Round(context.localUtil.CToN( cgiGet( "RELACIONAMENTOSACADO"), ",", "."), 18, MidpointRounding.ToEven));
               n1031RelacionamentoSacado = false;
               A1030ClienteSacado = StringUtil.StrToBool( cgiGet( "CLIENTESACADO"));
               AV7ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AV29Insert_EspecialidadeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_ESPECIALIDADEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV29Insert_EspecialidadeId", StringUtil.LTrimStr( (decimal)(AV29Insert_EspecialidadeId), 9, 0));
               A457EspecialidadeId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ESPECIALIDADEID"), ",", "."), 18, MidpointRounding.ToEven));
               n457EspecialidadeId = ((0==A457EspecialidadeId) ? true : false);
               AV14Insert_TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_TIPOCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV14Insert_TipoClienteId", StringUtil.LTrimStr( (decimal)(AV14Insert_TipoClienteId), 4, 0));
               A192TipoClienteId = (short)(Math.Round(context.localUtil.CToN( cgiGet( "TIPOCLIENTEID"), ",", "."), 18, MidpointRounding.ToEven));
               n192TipoClienteId = ((0==A192TipoClienteId) ? true : false);
               AV32Insert_ClienteConvenio = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTECONVENIO"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV32Insert_ClienteConvenio", StringUtil.LTrimStr( (decimal)(AV32Insert_ClienteConvenio), 9, 0));
               A489ClienteConvenio = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CLIENTECONVENIO"), ",", "."), 18, MidpointRounding.ToEven));
               n489ClienteConvenio = ((0==A489ClienteConvenio) ? true : false);
               AV30Insert_ClienteNacionalidade = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTENACIONALIDADE"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV30Insert_ClienteNacionalidade", StringUtil.LTrimStr( (decimal)(AV30Insert_ClienteNacionalidade), 9, 0));
               A484ClienteNacionalidade = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CLIENTENACIONALIDADE"), ",", "."), 18, MidpointRounding.ToEven));
               n484ClienteNacionalidade = ((0==A484ClienteNacionalidade) ? true : false);
               AV31Insert_ClienteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEPROFISSAO"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV31Insert_ClienteProfissao", StringUtil.LTrimStr( (decimal)(AV31Insert_ClienteProfissao), 9, 0));
               A487ClienteProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CLIENTEPROFISSAO"), ",", "."), 18, MidpointRounding.ToEven));
               n487ClienteProfissao = ((0==A487ClienteProfissao) ? true : false);
               AV17Insert_MunicipioCodigo = cgiGet( "vINSERT_MUNICIPIOCODIGO");
               AssignAttri("", false, "AV17Insert_MunicipioCodigo", AV17Insert_MunicipioCodigo);
               AV25Insert_BancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_BANCOID"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV25Insert_BancoId", StringUtil.LTrimStr( (decimal)(AV25Insert_BancoId), 9, 0));
               A402BancoId = (int)(Math.Round(context.localUtil.CToN( cgiGet( "BANCOID"), ",", "."), 18, MidpointRounding.ToEven));
               n402BancoId = ((0==A402BancoId) ? true : false);
               AV26Insert_ResponsavelNacionalidade = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_RESPONSAVELNACIONALIDADE"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV26Insert_ResponsavelNacionalidade", StringUtil.LTrimStr( (decimal)(AV26Insert_ResponsavelNacionalidade), 9, 0));
               A437ResponsavelNacionalidade = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESPONSAVELNACIONALIDADE"), ",", "."), 18, MidpointRounding.ToEven));
               n437ResponsavelNacionalidade = ((0==A437ResponsavelNacionalidade) ? true : false);
               AV27Insert_ResponsavelProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_RESPONSAVELPROFISSAO"), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV27Insert_ResponsavelProfissao", StringUtil.LTrimStr( (decimal)(AV27Insert_ResponsavelProfissao), 9, 0));
               A442ResponsavelProfissao = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESPONSAVELPROFISSAO"), ",", "."), 18, MidpointRounding.ToEven));
               n442ResponsavelProfissao = ((0==A442ResponsavelProfissao) ? true : false);
               AV28Insert_ResponsavelMunicipio = cgiGet( "vINSERT_RESPONSAVELMUNICIPIO");
               AssignAttri("", false, "AV28Insert_ResponsavelMunicipio", AV28Insert_ResponsavelMunicipio);
               A444ResponsavelMunicipio = cgiGet( "RESPONSAVELMUNICIPIO");
               n444ResponsavelMunicipio = (String.IsNullOrEmpty(StringUtil.RTrim( A444ResponsavelMunicipio)) ? true : false);
               A175ClienteCreatedAt = context.localUtil.CToT( cgiGet( "CLIENTECREATEDAT"), 0);
               n175ClienteCreatedAt = ((DateTime.MinValue==A175ClienteCreatedAt) ? true : false);
               A176ClienteUpdatedAt = context.localUtil.CToT( cgiGet( "CLIENTEUPDATEDAT"), 0);
               n176ClienteUpdatedAt = ((DateTime.MinValue==A176ClienteUpdatedAt) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A310ClienteValorAPagar_F = context.localUtil.CToN( cgiGet( "CLIENTEVALORAPAGAR_F"), ",", ".");
               n310ClienteValorAPagar_F = false;
               A311ClienteValorAReceber_F = context.localUtil.CToN( cgiGet( "CLIENTEVALORARECEBER_F"), ",", ".");
               n311ClienteValorAReceber_F = false;
               A785SerasaUltimoValorRecomendado_F = context.localUtil.CToN( cgiGet( "SERASAULTIMOVALORRECOMENDADO_F"), ",", ".");
               A459ClienteDataNascimento = context.localUtil.CToD( cgiGet( "CLIENTEDATANASCIMENTO"), 0);
               n459ClienteDataNascimento = ((DateTime.MinValue==A459ClienteDataNascimento) ? true : false);
               A177ClienteLogUser = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CLIENTELOGUSER"), ",", "."), 18, MidpointRounding.ToEven));
               n177ClienteLogUser = ((0==A177ClienteLogUser) ? true : false);
               A486ClienteEstadoCivil = cgiGet( "CLIENTEESTADOCIVIL");
               n486ClienteEstadoCivil = (String.IsNullOrEmpty(StringUtil.RTrim( A486ClienteEstadoCivil)) ? true : false);
               A421ClienteRG = (long)(Math.Round(context.localUtil.CToN( cgiGet( "CLIENTERG"), ",", "."), 18, MidpointRounding.ToEven));
               n421ClienteRG = ((0==A421ClienteRG) ? true : false);
               A537ClienteDepositoTipo = cgiGet( "CLIENTEDEPOSITOTIPO");
               n537ClienteDepositoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A537ClienteDepositoTipo)) ? true : false);
               A538ClientePixTipo = cgiGet( "CLIENTEPIXTIPO");
               n538ClientePixTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A538ClientePixTipo)) ? true : false);
               A539ClientePix = cgiGet( "CLIENTEPIX");
               n539ClientePix = (String.IsNullOrEmpty(StringUtil.RTrim( A539ClientePix)) ? true : false);
               A400ContaAgencia = cgiGet( "CONTAAGENCIA");
               n400ContaAgencia = (String.IsNullOrEmpty(StringUtil.RTrim( A400ContaAgencia)) ? true : false);
               A401ContaNumero = cgiGet( "CONTANUMERO");
               n401ContaNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A401ContaNumero)) ? true : false);
               A436ResponsavelNome = cgiGet( "RESPONSAVELNOME");
               n436ResponsavelNome = (String.IsNullOrEmpty(StringUtil.RTrim( A436ResponsavelNome)) ? true : false);
               A439ResponsavelEstadoCivil = cgiGet( "RESPONSAVELESTADOCIVIL");
               n439ResponsavelEstadoCivil = (String.IsNullOrEmpty(StringUtil.RTrim( A439ResponsavelEstadoCivil)) ? true : false);
               A576ResponsavelRG = (long)(Math.Round(context.localUtil.CToN( cgiGet( "RESPONSAVELRG"), ",", "."), 18, MidpointRounding.ToEven));
               n576ResponsavelRG = ((0==A576ResponsavelRG) ? true : false);
               A447ResponsavelCPF = cgiGet( "RESPONSAVELCPF");
               n447ResponsavelCPF = (String.IsNullOrEmpty(StringUtil.RTrim( A447ResponsavelCPF)) ? true : false);
               A448ResponsavelCEP = cgiGet( "RESPONSAVELCEP");
               n448ResponsavelCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A448ResponsavelCEP)) ? true : false);
               A449ResponsavelLogradouro = cgiGet( "RESPONSAVELLOGRADOURO");
               n449ResponsavelLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A449ResponsavelLogradouro)) ? true : false);
               A450ResponsavelBairro = cgiGet( "RESPONSAVELBAIRRO");
               n450ResponsavelBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A450ResponsavelBairro)) ? true : false);
               A451ResponsavelCidade = cgiGet( "RESPONSAVELCIDADE");
               n451ResponsavelCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A451ResponsavelCidade)) ? true : false);
               A452ResponsavelLogradouroNumero = (int)(Math.Round(context.localUtil.CToN( cgiGet( "RESPONSAVELLOGRADOURONUMERO"), ",", "."), 18, MidpointRounding.ToEven));
               n452ResponsavelLogradouroNumero = ((0==A452ResponsavelLogradouroNumero) ? true : false);
               A453ResponsavelComplemento = cgiGet( "RESPONSAVELCOMPLEMENTO");
               n453ResponsavelComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A453ResponsavelComplemento)) ? true : false);
               A456ResponsavelEmail = cgiGet( "RESPONSAVELEMAIL");
               n456ResponsavelEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A456ResponsavelEmail)) ? true : false);
               A884ClienteSituacao = cgiGet( "CLIENTESITUACAO");
               n884ClienteSituacao = (String.IsNullOrEmpty(StringUtil.RTrim( A884ClienteSituacao)) ? true : false);
               A885ResponsavelCargo = cgiGet( "RESPONSAVELCARGO");
               n885ResponsavelCargo = (String.IsNullOrEmpty(StringUtil.RTrim( A885ResponsavelCargo)) ? true : false);
               A1039ClienteTipoRisco = cgiGet( "CLIENTETIPORISCO");
               A207TipoClientePortal = StringUtil.StrToBool( cgiGet( "TIPOCLIENTEPORTAL"));
               n207TipoClientePortal = false;
               A793TipoClientePortalPjPf = StringUtil.StrToBool( cgiGet( "TIPOCLIENTEPORTALPJPF"));
               n793TipoClientePortalPjPf = false;
               A187MunicipioNome = cgiGet( "MUNICIPIONOME");
               n187MunicipioNome = false;
               A446ResponsavelMunicipioUF = cgiGet( "RESPONSAVELMUNICIPIOUF");
               n446ResponsavelMunicipioUF = false;
               A445ResponsavelMunicipioNome = cgiGet( "RESPONSAVELMUNICIPIONOME");
               n445ResponsavelMunicipioNome = false;
               A404BancoCodigo = (int)(Math.Round(context.localUtil.CToN( cgiGet( "BANCOCODIGO"), ",", "."), 18, MidpointRounding.ToEven));
               n404BancoCodigo = false;
               A403BancoNome = cgiGet( "BANCONOME");
               n403BancoNome = false;
               A438ResponsavelNacionalidadeNome = cgiGet( "RESPONSAVELNACIONALIDADENOME");
               n438ResponsavelNacionalidadeNome = false;
               A485ClienteNacionalidadeNome = cgiGet( "CLIENTENACIONALIDADENOME");
               n485ClienteNacionalidadeNome = false;
               A443ResponsavelProfissaoNome = cgiGet( "RESPONSAVELPROFISSAONOME");
               n443ResponsavelProfissaoNome = false;
               A488ClienteProfissaoNome = cgiGet( "CLIENTEPROFISSAONOME");
               n488ClienteProfissaoNome = false;
               A490ClienteConvenioDescricao = cgiGet( "CLIENTECONVENIODESCRICAO");
               n490ClienteConvenioDescricao = false;
               A780SerasaUltimaData_F = context.localUtil.CToT( cgiGet( "SERASAULTIMADATA_F"), 0);
               A781SerasaScoreUltimaData_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SERASASCOREULTIMADATA_F"), ",", "."), 18, MidpointRounding.ToEven));
               A608SecUserId_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SECUSERID_F"), ",", "."), 18, MidpointRounding.ToEven));
               n608SecUserId_F = false;
               A309ClienteQtdTitulos_F = (int)(Math.Round(context.localUtil.CToN( cgiGet( "CLIENTEQTDTITULOS_F"), ",", "."), 18, MidpointRounding.ToEven));
               n309ClienteQtdTitulos_F = false;
               A732SerasaConsultas_F = (short)(Math.Round(context.localUtil.CToN( cgiGet( "SERASACONSULTAS_F"), ",", "."), 18, MidpointRounding.ToEven));
               AV35Pgmname = cgiGet( "vPGMNAME");
               Combo_municipiocodigo_Objectcall = cgiGet( "COMBO_MUNICIPIOCODIGO_Objectcall");
               Combo_municipiocodigo_Class = cgiGet( "COMBO_MUNICIPIOCODIGO_Class");
               Combo_municipiocodigo_Icontype = cgiGet( "COMBO_MUNICIPIOCODIGO_Icontype");
               Combo_municipiocodigo_Icon = cgiGet( "COMBO_MUNICIPIOCODIGO_Icon");
               Combo_municipiocodigo_Caption = cgiGet( "COMBO_MUNICIPIOCODIGO_Caption");
               Combo_municipiocodigo_Tooltip = cgiGet( "COMBO_MUNICIPIOCODIGO_Tooltip");
               Combo_municipiocodigo_Cls = cgiGet( "COMBO_MUNICIPIOCODIGO_Cls");
               Combo_municipiocodigo_Selectedvalue_set = cgiGet( "COMBO_MUNICIPIOCODIGO_Selectedvalue_set");
               Combo_municipiocodigo_Selectedvalue_get = cgiGet( "COMBO_MUNICIPIOCODIGO_Selectedvalue_get");
               Combo_municipiocodigo_Selectedtext_set = cgiGet( "COMBO_MUNICIPIOCODIGO_Selectedtext_set");
               Combo_municipiocodigo_Selectedtext_get = cgiGet( "COMBO_MUNICIPIOCODIGO_Selectedtext_get");
               Combo_municipiocodigo_Gamoauthtoken = cgiGet( "COMBO_MUNICIPIOCODIGO_Gamoauthtoken");
               Combo_municipiocodigo_Ddointernalname = cgiGet( "COMBO_MUNICIPIOCODIGO_Ddointernalname");
               Combo_municipiocodigo_Titlecontrolalign = cgiGet( "COMBO_MUNICIPIOCODIGO_Titlecontrolalign");
               Combo_municipiocodigo_Dropdownoptionstype = cgiGet( "COMBO_MUNICIPIOCODIGO_Dropdownoptionstype");
               Combo_municipiocodigo_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOCODIGO_Enabled"));
               Combo_municipiocodigo_Visible = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOCODIGO_Visible"));
               Combo_municipiocodigo_Titlecontrolidtoreplace = cgiGet( "COMBO_MUNICIPIOCODIGO_Titlecontrolidtoreplace");
               Combo_municipiocodigo_Datalisttype = cgiGet( "COMBO_MUNICIPIOCODIGO_Datalisttype");
               Combo_municipiocodigo_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOCODIGO_Allowmultipleselection"));
               Combo_municipiocodigo_Datalistfixedvalues = cgiGet( "COMBO_MUNICIPIOCODIGO_Datalistfixedvalues");
               Combo_municipiocodigo_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOCODIGO_Isgriditem"));
               Combo_municipiocodigo_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOCODIGO_Hasdescription"));
               Combo_municipiocodigo_Datalistproc = cgiGet( "COMBO_MUNICIPIOCODIGO_Datalistproc");
               Combo_municipiocodigo_Datalistprocparametersprefix = cgiGet( "COMBO_MUNICIPIOCODIGO_Datalistprocparametersprefix");
               Combo_municipiocodigo_Remoteservicesparameters = cgiGet( "COMBO_MUNICIPIOCODIGO_Remoteservicesparameters");
               Combo_municipiocodigo_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MUNICIPIOCODIGO_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_municipiocodigo_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOCODIGO_Includeonlyselectedoption"));
               Combo_municipiocodigo_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOCODIGO_Includeselectalloption"));
               Combo_municipiocodigo_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOCODIGO_Emptyitem"));
               Combo_municipiocodigo_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_MUNICIPIOCODIGO_Includeaddnewoption"));
               Combo_municipiocodigo_Htmltemplate = cgiGet( "COMBO_MUNICIPIOCODIGO_Htmltemplate");
               Combo_municipiocodigo_Multiplevaluestype = cgiGet( "COMBO_MUNICIPIOCODIGO_Multiplevaluestype");
               Combo_municipiocodigo_Loadingdata = cgiGet( "COMBO_MUNICIPIOCODIGO_Loadingdata");
               Combo_municipiocodigo_Noresultsfound = cgiGet( "COMBO_MUNICIPIOCODIGO_Noresultsfound");
               Combo_municipiocodigo_Emptyitemtext = cgiGet( "COMBO_MUNICIPIOCODIGO_Emptyitemtext");
               Combo_municipiocodigo_Onlyselectedvalues = cgiGet( "COMBO_MUNICIPIOCODIGO_Onlyselectedvalues");
               Combo_municipiocodigo_Selectalltext = cgiGet( "COMBO_MUNICIPIOCODIGO_Selectalltext");
               Combo_municipiocodigo_Multiplevaluesseparator = cgiGet( "COMBO_MUNICIPIOCODIGO_Multiplevaluesseparator");
               Combo_municipiocodigo_Addnewoptiontext = cgiGet( "COMBO_MUNICIPIOCODIGO_Addnewoptiontext");
               Combo_municipiocodigo_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_MUNICIPIOCODIGO_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A169ClienteDocumento = cgiGet( edtClienteDocumento_Internalname);
               n169ClienteDocumento = false;
               AssignAttri("", false, "A169ClienteDocumento", A169ClienteDocumento);
               n169ClienteDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A169ClienteDocumento)) ? true : false);
               A170ClienteRazaoSocial = StringUtil.Upper( cgiGet( edtClienteRazaoSocial_Internalname));
               n170ClienteRazaoSocial = false;
               AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
               n170ClienteRazaoSocial = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? true : false);
               A171ClienteNomeFantasia = StringUtil.Upper( cgiGet( edtClienteNomeFantasia_Internalname));
               n171ClienteNomeFantasia = false;
               AssignAttri("", false, "A171ClienteNomeFantasia", A171ClienteNomeFantasia);
               n171ClienteNomeFantasia = (String.IsNullOrEmpty(StringUtil.RTrim( A171ClienteNomeFantasia)) ? true : false);
               cmbClienteTipoPessoa.CurrentValue = cgiGet( cmbClienteTipoPessoa_Internalname);
               A172ClienteTipoPessoa = cgiGet( cmbClienteTipoPessoa_Internalname);
               n172ClienteTipoPessoa = false;
               AssignAttri("", false, "A172ClienteTipoPessoa", A172ClienteTipoPessoa);
               n172ClienteTipoPessoa = (String.IsNullOrEmpty(StringUtil.RTrim( A172ClienteTipoPessoa)) ? true : false);
               A193TipoClienteDescricao = StringUtil.Upper( cgiGet( edtTipoClienteDescricao_Internalname));
               n193TipoClienteDescricao = false;
               AssignAttri("", false, "A193TipoClienteDescricao", A193TipoClienteDescricao);
               cmbClienteStatus.CurrentValue = cgiGet( cmbClienteStatus_Internalname);
               A174ClienteStatus = StringUtil.StrToBool( cgiGet( cmbClienteStatus_Internalname));
               n174ClienteStatus = false;
               AssignAttri("", false, "A174ClienteStatus", A174ClienteStatus);
               n174ClienteStatus = ((false==A174ClienteStatus) ? true : false);
               cmbEnderecoTipo.CurrentValue = cgiGet( cmbEnderecoTipo_Internalname);
               A181EnderecoTipo = cgiGet( cmbEnderecoTipo_Internalname);
               n181EnderecoTipo = false;
               AssignAttri("", false, "A181EnderecoTipo", A181EnderecoTipo);
               n181EnderecoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A181EnderecoTipo)) ? true : false);
               A182EnderecoCEP = cgiGet( edtEnderecoCEP_Internalname);
               n182EnderecoCEP = false;
               AssignAttri("", false, "A182EnderecoCEP", A182EnderecoCEP);
               n182EnderecoCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A182EnderecoCEP)) ? true : false);
               A183EnderecoLogradouro = StringUtil.Upper( cgiGet( edtEnderecoLogradouro_Internalname));
               n183EnderecoLogradouro = false;
               AssignAttri("", false, "A183EnderecoLogradouro", A183EnderecoLogradouro);
               n183EnderecoLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A183EnderecoLogradouro)) ? true : false);
               A184EnderecoBairro = StringUtil.Upper( cgiGet( edtEnderecoBairro_Internalname));
               n184EnderecoBairro = false;
               AssignAttri("", false, "A184EnderecoBairro", A184EnderecoBairro);
               n184EnderecoBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A184EnderecoBairro)) ? true : false);
               A185EnderecoCidade = StringUtil.Upper( cgiGet( edtEnderecoCidade_Internalname));
               n185EnderecoCidade = false;
               AssignAttri("", false, "A185EnderecoCidade", A185EnderecoCidade);
               n185EnderecoCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A185EnderecoCidade)) ? true : false);
               A186MunicipioCodigo = cgiGet( edtMunicipioCodigo_Internalname);
               n186MunicipioCodigo = false;
               AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
               n186MunicipioCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ? true : false);
               A189MunicipioUF = StringUtil.Upper( cgiGet( edtMunicipioUF_Internalname));
               n189MunicipioUF = false;
               AssignAttri("", false, "A189MunicipioUF", A189MunicipioUF);
               A190EnderecoNumero = cgiGet( edtEnderecoNumero_Internalname);
               n190EnderecoNumero = false;
               AssignAttri("", false, "A190EnderecoNumero", A190EnderecoNumero);
               n190EnderecoNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A190EnderecoNumero)) ? true : false);
               A191EnderecoComplemento = cgiGet( edtEnderecoComplemento_Internalname);
               n191EnderecoComplemento = false;
               AssignAttri("", false, "A191EnderecoComplemento", A191EnderecoComplemento);
               n191EnderecoComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A191EnderecoComplemento)) ? true : false);
               A201ContatoEmail = cgiGet( edtContatoEmail_Internalname);
               n201ContatoEmail = false;
               AssignAttri("", false, "A201ContatoEmail", A201ContatoEmail);
               n201ContatoEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A201ContatoEmail)) ? true : false);
               n198ContatoDDD = ((StringUtil.StrCmp(cgiGet( edtContatoDDD_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtContatoDDD_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContatoDDD_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTATODDD");
                  AnyError = 1;
                  GX_FocusControl = edtContatoDDD_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A198ContatoDDD = 0;
                  n198ContatoDDD = false;
                  AssignAttri("", false, "A198ContatoDDD", (n198ContatoDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A198ContatoDDD), 4, 0, ".", ""))));
               }
               else
               {
                  A198ContatoDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtContatoDDD_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A198ContatoDDD", (n198ContatoDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A198ContatoDDD), 4, 0, ".", ""))));
               }
               n200ContatoNumero = ((StringUtil.StrCmp(cgiGet( edtContatoNumero_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtContatoNumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContatoNumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTATONUMERO");
                  AnyError = 1;
                  GX_FocusControl = edtContatoNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A200ContatoNumero = 0;
                  n200ContatoNumero = false;
                  AssignAttri("", false, "A200ContatoNumero", (n200ContatoNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A200ContatoNumero), 18, 0, ".", ""))));
               }
               else
               {
                  A200ContatoNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtContatoNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A200ContatoNumero", (n200ContatoNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A200ContatoNumero), 18, 0, ".", ""))));
               }
               n202ContatoTelefoneNumero = ((StringUtil.StrCmp(cgiGet( edtContatoTelefoneNumero_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtContatoTelefoneNumero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContatoTelefoneNumero_Internalname), ",", ".") > Convert.ToDecimal( 999999999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTATOTELEFONENUMERO");
                  AnyError = 1;
                  GX_FocusControl = edtContatoTelefoneNumero_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A202ContatoTelefoneNumero = 0;
                  n202ContatoTelefoneNumero = false;
                  AssignAttri("", false, "A202ContatoTelefoneNumero", (n202ContatoTelefoneNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A202ContatoTelefoneNumero), 18, 0, ".", ""))));
               }
               else
               {
                  A202ContatoTelefoneNumero = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtContatoTelefoneNumero_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A202ContatoTelefoneNumero", (n202ContatoTelefoneNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A202ContatoTelefoneNumero), 18, 0, ".", ""))));
               }
               n203ContatoTelefoneDDD = ((StringUtil.StrCmp(cgiGet( edtContatoTelefoneDDD_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtContatoTelefoneDDD_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContatoTelefoneDDD_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTATOTELEFONEDDD");
                  AnyError = 1;
                  GX_FocusControl = edtContatoTelefoneDDD_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A203ContatoTelefoneDDD = 0;
                  n203ContatoTelefoneDDD = false;
                  AssignAttri("", false, "A203ContatoTelefoneDDD", (n203ContatoTelefoneDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A203ContatoTelefoneDDD), 4, 0, ".", ""))));
               }
               else
               {
                  A203ContatoTelefoneDDD = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtContatoTelefoneDDD_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A203ContatoTelefoneDDD", (n203ContatoTelefoneDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A203ContatoTelefoneDDD), 4, 0, ".", ""))));
               }
               n204ContatoTelefoneDDI = ((StringUtil.StrCmp(cgiGet( edtContatoTelefoneDDI_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtContatoTelefoneDDI_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContatoTelefoneDDI_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTATOTELEFONEDDI");
                  AnyError = 1;
                  GX_FocusControl = edtContatoTelefoneDDI_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A204ContatoTelefoneDDI = 0;
                  n204ContatoTelefoneDDI = false;
                  AssignAttri("", false, "A204ContatoTelefoneDDI", (n204ContatoTelefoneDDI ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A204ContatoTelefoneDDI), 4, 0, ".", ""))));
               }
               else
               {
                  A204ContatoTelefoneDDI = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtContatoTelefoneDDI_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A204ContatoTelefoneDDI", (n204ContatoTelefoneDDI ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A204ContatoTelefoneDDI), 4, 0, ".", ""))));
               }
               n199ContatoDDI = ((StringUtil.StrCmp(cgiGet( edtContatoDDI_Internalname), "")==0) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtContatoDDI_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtContatoDDI_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONTATODDI");
                  AnyError = 1;
                  GX_FocusControl = edtContatoDDI_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A199ContatoDDI = 0;
                  n199ContatoDDI = false;
                  AssignAttri("", false, "A199ContatoDDI", (n199ContatoDDI ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A199ContatoDDI), 4, 0, ".", ""))));
               }
               else
               {
                  A199ContatoDDI = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtContatoDDI_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A199ContatoDDI", (n199ContatoDDI ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A199ContatoDDI), 4, 0, ".", ""))));
               }
               A205ClienteTelefone_F = cgiGet( edtClienteTelefone_F_Internalname);
               AssignAttri("", false, "A205ClienteTelefone_F", A205ClienteTelefone_F);
               A206ClienteCelular_F = cgiGet( edtClienteCelular_F_Internalname);
               AssignAttri("", false, "A206ClienteCelular_F", A206ClienteCelular_F);
               AV23ComboMunicipioCodigo = cgiGet( edtavCombomunicipiocodigo_Internalname);
               AssignAttri("", false, "AV23ComboMunicipioCodigo", AV23ComboMunicipioCodigo);
               A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = false;
               AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Cliente");
               A168ClienteId = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n168ClienteId = false;
               AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
               forbiddenHiddens.Add("ClienteId", context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_EspecialidadeId", context.localUtil.Format( (decimal)(AV29Insert_EspecialidadeId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_TipoClienteId", context.localUtil.Format( (decimal)(AV14Insert_TipoClienteId), "ZZZ9"));
               forbiddenHiddens.Add("Insert_ClienteConvenio", context.localUtil.Format( (decimal)(AV32Insert_ClienteConvenio), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ClienteNacionalidade", context.localUtil.Format( (decimal)(AV30Insert_ClienteNacionalidade), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ClienteProfissao", context.localUtil.Format( (decimal)(AV31Insert_ClienteProfissao), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_MunicipioCodigo", StringUtil.RTrim( context.localUtil.Format( AV17Insert_MunicipioCodigo, "")));
               forbiddenHiddens.Add("Insert_BancoId", context.localUtil.Format( (decimal)(AV25Insert_BancoId), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ResponsavelNacionalidade", context.localUtil.Format( (decimal)(AV26Insert_ResponsavelNacionalidade), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ResponsavelProfissao", context.localUtil.Format( (decimal)(AV27Insert_ResponsavelProfissao), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("Insert_ResponsavelMunicipio", StringUtil.RTrim( context.localUtil.Format( AV28Insert_ResponsavelMunicipio, "")));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("ClienteCreatedAt", context.localUtil.Format( A175ClienteCreatedAt, "99/99/99 99:99"));
               forbiddenHiddens.Add("ClienteUpdatedAt", context.localUtil.Format( A176ClienteUpdatedAt, "99/99/99 99:99"));
               forbiddenHiddens.Add("ClienteDataNascimento", context.localUtil.Format(A459ClienteDataNascimento, "99/99/9999"));
               forbiddenHiddens.Add("ClienteLogUser", context.localUtil.Format( (decimal)(A177ClienteLogUser), "ZZZ9"));
               forbiddenHiddens.Add("ClienteEstadoCivil", StringUtil.RTrim( context.localUtil.Format( A486ClienteEstadoCivil, "")));
               forbiddenHiddens.Add("ClienteRG", context.localUtil.Format( (decimal)(A421ClienteRG), "ZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("ClienteDepositoTipo", StringUtil.RTrim( context.localUtil.Format( A537ClienteDepositoTipo, "")));
               forbiddenHiddens.Add("ClientePixTipo", StringUtil.RTrim( context.localUtil.Format( A538ClientePixTipo, "")));
               forbiddenHiddens.Add("ClientePix", StringUtil.RTrim( context.localUtil.Format( A539ClientePix, "")));
               forbiddenHiddens.Add("ContaAgencia", StringUtil.RTrim( context.localUtil.Format( A400ContaAgencia, "")));
               forbiddenHiddens.Add("ContaNumero", StringUtil.RTrim( context.localUtil.Format( A401ContaNumero, "")));
               forbiddenHiddens.Add("ResponsavelNome", StringUtil.RTrim( context.localUtil.Format( A436ResponsavelNome, "")));
               forbiddenHiddens.Add("ResponsavelEstadoCivil", StringUtil.RTrim( context.localUtil.Format( A439ResponsavelEstadoCivil, "")));
               forbiddenHiddens.Add("ResponsavelRG", context.localUtil.Format( (decimal)(A576ResponsavelRG), "ZZZZZZZZZZZ9"));
               forbiddenHiddens.Add("ResponsavelCPF", StringUtil.RTrim( context.localUtil.Format( A447ResponsavelCPF, "")));
               forbiddenHiddens.Add("ResponsavelCEP", StringUtil.RTrim( context.localUtil.Format( A448ResponsavelCEP, "")));
               forbiddenHiddens.Add("ResponsavelLogradouro", StringUtil.RTrim( context.localUtil.Format( A449ResponsavelLogradouro, "")));
               forbiddenHiddens.Add("ResponsavelBairro", StringUtil.RTrim( context.localUtil.Format( A450ResponsavelBairro, "")));
               forbiddenHiddens.Add("ResponsavelCidade", StringUtil.RTrim( context.localUtil.Format( A451ResponsavelCidade, "")));
               forbiddenHiddens.Add("ResponsavelLogradouroNumero", context.localUtil.Format( (decimal)(A452ResponsavelLogradouroNumero), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("ResponsavelComplemento", StringUtil.RTrim( context.localUtil.Format( A453ResponsavelComplemento, "")));
               forbiddenHiddens.Add("ResponsavelDDD", context.localUtil.Format( (decimal)(A454ResponsavelDDD), "ZZZ9"));
               forbiddenHiddens.Add("ResponsavelNumero", context.localUtil.Format( (decimal)(A455ResponsavelNumero), "ZZZZZZZZ9"));
               forbiddenHiddens.Add("ResponsavelEmail", StringUtil.RTrim( context.localUtil.Format( A456ResponsavelEmail, "")));
               forbiddenHiddens.Add("ClienteSituacao", StringUtil.RTrim( context.localUtil.Format( A884ClienteSituacao, "")));
               forbiddenHiddens.Add("ResponsavelCargo", StringUtil.RTrim( context.localUtil.Format( A885ResponsavelCargo, "")));
               forbiddenHiddens.Add("ClienteTipoRisco", StringUtil.RTrim( context.localUtil.Format( A1039ClienteTipoRisco, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A168ClienteId != Z168ClienteId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("cliente:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A168ClienteId = (int)(Math.Round(NumberUtil.Val( GetPar( "ClienteId"), "."), 18, MidpointRounding.ToEven));
                  n168ClienteId = false;
                  AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
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
                     sMode28 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode28;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound28 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0O0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CLIENTEID");
                        AnyError = 1;
                        GX_FocusControl = edtClienteId_Internalname;
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
                           E110O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120O2 ();
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
            E120O2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0O28( ) ;
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
            DisableAttributes0O28( ) ;
         }
         AssignProp("", false, edtavCombomunicipiocodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomunicipiocodigo_Enabled), 5, 0), true);
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

      protected void CONFIRM_0O0( )
      {
         BeforeValidate0O28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0O28( ) ;
            }
            else
            {
               CheckExtendedTable0O28( ) ;
               CloseExtendedTableCursors0O28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0O0( )
      {
      }

      protected void E110O2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV19DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV19DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtMunicipioCodigo_Visible = 0;
         AssignProp("", false, edtMunicipioCodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMunicipioCodigo_Visible), 5, 0), true);
         AV23ComboMunicipioCodigo = "";
         AssignAttri("", false, "AV23ComboMunicipioCodigo", AV23ComboMunicipioCodigo);
         edtavCombomunicipiocodigo_Visible = 0;
         AssignProp("", false, edtavCombomunicipiocodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombomunicipiocodigo_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOMUNICIPIOCODIGO' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV12TrnContext.gxTpr_Transactionname, AV35Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV36GXV1 = 1;
            AssignAttri("", false, "AV36GXV1", StringUtil.LTrimStr( (decimal)(AV36GXV1), 8, 0));
            while ( AV36GXV1 <= AV12TrnContext.gxTpr_Attributes.Count )
            {
               AV16TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV12TrnContext.gxTpr_Attributes.Item(AV36GXV1));
               if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "EspecialidadeId") == 0 )
               {
                  AV29Insert_EspecialidadeId = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV29Insert_EspecialidadeId", StringUtil.LTrimStr( (decimal)(AV29Insert_EspecialidadeId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "TipoClienteId") == 0 )
               {
                  AV14Insert_TipoClienteId = (short)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_TipoClienteId", StringUtil.LTrimStr( (decimal)(AV14Insert_TipoClienteId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ClienteConvenio") == 0 )
               {
                  AV32Insert_ClienteConvenio = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV32Insert_ClienteConvenio", StringUtil.LTrimStr( (decimal)(AV32Insert_ClienteConvenio), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ClienteNacionalidade") == 0 )
               {
                  AV30Insert_ClienteNacionalidade = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV30Insert_ClienteNacionalidade", StringUtil.LTrimStr( (decimal)(AV30Insert_ClienteNacionalidade), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ClienteProfissao") == 0 )
               {
                  AV31Insert_ClienteProfissao = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV31Insert_ClienteProfissao", StringUtil.LTrimStr( (decimal)(AV31Insert_ClienteProfissao), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "MunicipioCodigo") == 0 )
               {
                  AV17Insert_MunicipioCodigo = AV16TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV17Insert_MunicipioCodigo", AV17Insert_MunicipioCodigo);
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17Insert_MunicipioCodigo)) )
                  {
                     AV23ComboMunicipioCodigo = AV17Insert_MunicipioCodigo;
                     AssignAttri("", false, "AV23ComboMunicipioCodigo", AV23ComboMunicipioCodigo);
                     Combo_municipiocodigo_Selectedvalue_set = AV23ComboMunicipioCodigo;
                     ucCombo_municipiocodigo.SendProperty(context, "", false, Combo_municipiocodigo_Internalname, "SelectedValue_set", Combo_municipiocodigo_Selectedvalue_set);
                     GXt_char2 = AV22Combo_DataJson;
                     new clienteloaddvcombo(context ).execute(  "MunicipioCodigo",  "GET",  false,  AV7ClienteId,  AV16TrnContextAtt.gxTpr_Attributevalue, out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
                     AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
                     AV22Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
                     Combo_municipiocodigo_Selectedtext_set = AV21ComboSelectedText;
                     ucCombo_municipiocodigo.SendProperty(context, "", false, Combo_municipiocodigo_Internalname, "SelectedText_set", Combo_municipiocodigo_Selectedtext_set);
                     Combo_municipiocodigo_Enabled = false;
                     ucCombo_municipiocodigo.SendProperty(context, "", false, Combo_municipiocodigo_Internalname, "Enabled", StringUtil.BoolToStr( Combo_municipiocodigo_Enabled));
                  }
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "BancoId") == 0 )
               {
                  AV25Insert_BancoId = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV25Insert_BancoId", StringUtil.LTrimStr( (decimal)(AV25Insert_BancoId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ResponsavelNacionalidade") == 0 )
               {
                  AV26Insert_ResponsavelNacionalidade = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV26Insert_ResponsavelNacionalidade", StringUtil.LTrimStr( (decimal)(AV26Insert_ResponsavelNacionalidade), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ResponsavelProfissao") == 0 )
               {
                  AV27Insert_ResponsavelProfissao = (int)(Math.Round(NumberUtil.Val( AV16TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV27Insert_ResponsavelProfissao", StringUtil.LTrimStr( (decimal)(AV27Insert_ResponsavelProfissao), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV16TrnContextAtt.gxTpr_Attributename, "ResponsavelMunicipio") == 0 )
               {
                  AV28Insert_ResponsavelMunicipio = AV16TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri("", false, "AV28Insert_ResponsavelMunicipio", AV28Insert_ResponsavelMunicipio);
               }
               AV36GXV1 = (int)(AV36GXV1+1);
               AssignAttri("", false, "AV36GXV1", StringUtil.LTrimStr( (decimal)(AV36GXV1), 8, 0));
            }
         }
         edtClienteId_Visible = 0;
         AssignProp("", false, edtClienteId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtClienteId_Visible), 5, 0), true);
      }

      protected void E120O2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV12TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("clienteww") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S112( )
      {
         /* 'LOADCOMBOMUNICIPIOCODIGO' Routine */
         returnInSub = false;
         GXt_char2 = AV22Combo_DataJson;
         new clienteloaddvcombo(context ).execute(  "MunicipioCodigo",  Gx_mode,  false,  AV7ClienteId,  "", out  AV20ComboSelectedValue, out  AV21ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV20ComboSelectedValue", AV20ComboSelectedValue);
         AssignAttri("", false, "AV21ComboSelectedText", AV21ComboSelectedText);
         AV22Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV22Combo_DataJson", AV22Combo_DataJson);
         Combo_municipiocodigo_Selectedvalue_set = AV20ComboSelectedValue;
         ucCombo_municipiocodigo.SendProperty(context, "", false, Combo_municipiocodigo_Internalname, "SelectedValue_set", Combo_municipiocodigo_Selectedvalue_set);
         Combo_municipiocodigo_Selectedtext_set = AV21ComboSelectedText;
         ucCombo_municipiocodigo.SendProperty(context, "", false, Combo_municipiocodigo_Internalname, "SelectedText_set", Combo_municipiocodigo_Selectedtext_set);
         AV23ComboMunicipioCodigo = AV20ComboSelectedValue;
         AssignAttri("", false, "AV23ComboMunicipioCodigo", AV23ComboMunicipioCodigo);
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_municipiocodigo_Enabled = false;
            ucCombo_municipiocodigo.SendProperty(context, "", false, Combo_municipiocodigo_Internalname, "Enabled", StringUtil.BoolToStr( Combo_municipiocodigo_Enabled));
         }
      }

      protected void ZM0O28( short GX_JID )
      {
         if ( ( GX_JID == 39 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z175ClienteCreatedAt = T000O3_A175ClienteCreatedAt[0];
               Z176ClienteUpdatedAt = T000O3_A176ClienteUpdatedAt[0];
               Z169ClienteDocumento = T000O3_A169ClienteDocumento[0];
               Z170ClienteRazaoSocial = T000O3_A170ClienteRazaoSocial[0];
               Z171ClienteNomeFantasia = T000O3_A171ClienteNomeFantasia[0];
               Z459ClienteDataNascimento = T000O3_A459ClienteDataNascimento[0];
               Z172ClienteTipoPessoa = T000O3_A172ClienteTipoPessoa[0];
               Z174ClienteStatus = T000O3_A174ClienteStatus[0];
               Z177ClienteLogUser = T000O3_A177ClienteLogUser[0];
               Z486ClienteEstadoCivil = T000O3_A486ClienteEstadoCivil[0];
               Z181EnderecoTipo = T000O3_A181EnderecoTipo[0];
               Z182EnderecoCEP = T000O3_A182EnderecoCEP[0];
               Z183EnderecoLogradouro = T000O3_A183EnderecoLogradouro[0];
               Z184EnderecoBairro = T000O3_A184EnderecoBairro[0];
               Z185EnderecoCidade = T000O3_A185EnderecoCidade[0];
               Z190EnderecoNumero = T000O3_A190EnderecoNumero[0];
               Z191EnderecoComplemento = T000O3_A191EnderecoComplemento[0];
               Z201ContatoEmail = T000O3_A201ContatoEmail[0];
               Z198ContatoDDD = T000O3_A198ContatoDDD[0];
               Z199ContatoDDI = T000O3_A199ContatoDDI[0];
               Z200ContatoNumero = T000O3_A200ContatoNumero[0];
               Z202ContatoTelefoneNumero = T000O3_A202ContatoTelefoneNumero[0];
               Z203ContatoTelefoneDDD = T000O3_A203ContatoTelefoneDDD[0];
               Z204ContatoTelefoneDDI = T000O3_A204ContatoTelefoneDDI[0];
               Z421ClienteRG = T000O3_A421ClienteRG[0];
               Z537ClienteDepositoTipo = T000O3_A537ClienteDepositoTipo[0];
               Z538ClientePixTipo = T000O3_A538ClientePixTipo[0];
               Z539ClientePix = T000O3_A539ClientePix[0];
               Z400ContaAgencia = T000O3_A400ContaAgencia[0];
               Z401ContaNumero = T000O3_A401ContaNumero[0];
               Z436ResponsavelNome = T000O3_A436ResponsavelNome[0];
               Z439ResponsavelEstadoCivil = T000O3_A439ResponsavelEstadoCivil[0];
               Z576ResponsavelRG = T000O3_A576ResponsavelRG[0];
               Z447ResponsavelCPF = T000O3_A447ResponsavelCPF[0];
               Z448ResponsavelCEP = T000O3_A448ResponsavelCEP[0];
               Z449ResponsavelLogradouro = T000O3_A449ResponsavelLogradouro[0];
               Z450ResponsavelBairro = T000O3_A450ResponsavelBairro[0];
               Z451ResponsavelCidade = T000O3_A451ResponsavelCidade[0];
               Z452ResponsavelLogradouroNumero = T000O3_A452ResponsavelLogradouroNumero[0];
               Z453ResponsavelComplemento = T000O3_A453ResponsavelComplemento[0];
               Z454ResponsavelDDD = T000O3_A454ResponsavelDDD[0];
               Z455ResponsavelNumero = T000O3_A455ResponsavelNumero[0];
               Z456ResponsavelEmail = T000O3_A456ResponsavelEmail[0];
               Z884ClienteSituacao = T000O3_A884ClienteSituacao[0];
               Z885ResponsavelCargo = T000O3_A885ResponsavelCargo[0];
               Z1039ClienteTipoRisco = T000O3_A1039ClienteTipoRisco[0];
               Z192TipoClienteId = T000O3_A192TipoClienteId[0];
               Z186MunicipioCodigo = T000O3_A186MunicipioCodigo[0];
               Z444ResponsavelMunicipio = T000O3_A444ResponsavelMunicipio[0];
               Z402BancoId = T000O3_A402BancoId[0];
               Z457EspecialidadeId = T000O3_A457EspecialidadeId[0];
               Z437ResponsavelNacionalidade = T000O3_A437ResponsavelNacionalidade[0];
               Z484ClienteNacionalidade = T000O3_A484ClienteNacionalidade[0];
               Z442ResponsavelProfissao = T000O3_A442ResponsavelProfissao[0];
               Z487ClienteProfissao = T000O3_A487ClienteProfissao[0];
               Z489ClienteConvenio = T000O3_A489ClienteConvenio[0];
            }
            else
            {
               Z175ClienteCreatedAt = A175ClienteCreatedAt;
               Z176ClienteUpdatedAt = A176ClienteUpdatedAt;
               Z169ClienteDocumento = A169ClienteDocumento;
               Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
               Z171ClienteNomeFantasia = A171ClienteNomeFantasia;
               Z459ClienteDataNascimento = A459ClienteDataNascimento;
               Z172ClienteTipoPessoa = A172ClienteTipoPessoa;
               Z174ClienteStatus = A174ClienteStatus;
               Z177ClienteLogUser = A177ClienteLogUser;
               Z486ClienteEstadoCivil = A486ClienteEstadoCivil;
               Z181EnderecoTipo = A181EnderecoTipo;
               Z182EnderecoCEP = A182EnderecoCEP;
               Z183EnderecoLogradouro = A183EnderecoLogradouro;
               Z184EnderecoBairro = A184EnderecoBairro;
               Z185EnderecoCidade = A185EnderecoCidade;
               Z190EnderecoNumero = A190EnderecoNumero;
               Z191EnderecoComplemento = A191EnderecoComplemento;
               Z201ContatoEmail = A201ContatoEmail;
               Z198ContatoDDD = A198ContatoDDD;
               Z199ContatoDDI = A199ContatoDDI;
               Z200ContatoNumero = A200ContatoNumero;
               Z202ContatoTelefoneNumero = A202ContatoTelefoneNumero;
               Z203ContatoTelefoneDDD = A203ContatoTelefoneDDD;
               Z204ContatoTelefoneDDI = A204ContatoTelefoneDDI;
               Z421ClienteRG = A421ClienteRG;
               Z537ClienteDepositoTipo = A537ClienteDepositoTipo;
               Z538ClientePixTipo = A538ClientePixTipo;
               Z539ClientePix = A539ClientePix;
               Z400ContaAgencia = A400ContaAgencia;
               Z401ContaNumero = A401ContaNumero;
               Z436ResponsavelNome = A436ResponsavelNome;
               Z439ResponsavelEstadoCivil = A439ResponsavelEstadoCivil;
               Z576ResponsavelRG = A576ResponsavelRG;
               Z447ResponsavelCPF = A447ResponsavelCPF;
               Z448ResponsavelCEP = A448ResponsavelCEP;
               Z449ResponsavelLogradouro = A449ResponsavelLogradouro;
               Z450ResponsavelBairro = A450ResponsavelBairro;
               Z451ResponsavelCidade = A451ResponsavelCidade;
               Z452ResponsavelLogradouroNumero = A452ResponsavelLogradouroNumero;
               Z453ResponsavelComplemento = A453ResponsavelComplemento;
               Z454ResponsavelDDD = A454ResponsavelDDD;
               Z455ResponsavelNumero = A455ResponsavelNumero;
               Z456ResponsavelEmail = A456ResponsavelEmail;
               Z884ClienteSituacao = A884ClienteSituacao;
               Z885ResponsavelCargo = A885ResponsavelCargo;
               Z1039ClienteTipoRisco = A1039ClienteTipoRisco;
               Z192TipoClienteId = A192TipoClienteId;
               Z186MunicipioCodigo = A186MunicipioCodigo;
               Z444ResponsavelMunicipio = A444ResponsavelMunicipio;
               Z402BancoId = A402BancoId;
               Z457EspecialidadeId = A457EspecialidadeId;
               Z437ResponsavelNacionalidade = A437ResponsavelNacionalidade;
               Z484ClienteNacionalidade = A484ClienteNacionalidade;
               Z442ResponsavelProfissao = A442ResponsavelProfissao;
               Z487ClienteProfissao = A487ClienteProfissao;
               Z489ClienteConvenio = A489ClienteConvenio;
            }
         }
         if ( GX_JID == -39 )
         {
            Z168ClienteId = A168ClienteId;
            Z175ClienteCreatedAt = A175ClienteCreatedAt;
            Z176ClienteUpdatedAt = A176ClienteUpdatedAt;
            Z169ClienteDocumento = A169ClienteDocumento;
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
            Z171ClienteNomeFantasia = A171ClienteNomeFantasia;
            Z459ClienteDataNascimento = A459ClienteDataNascimento;
            Z172ClienteTipoPessoa = A172ClienteTipoPessoa;
            Z174ClienteStatus = A174ClienteStatus;
            Z177ClienteLogUser = A177ClienteLogUser;
            Z486ClienteEstadoCivil = A486ClienteEstadoCivil;
            Z181EnderecoTipo = A181EnderecoTipo;
            Z182EnderecoCEP = A182EnderecoCEP;
            Z183EnderecoLogradouro = A183EnderecoLogradouro;
            Z184EnderecoBairro = A184EnderecoBairro;
            Z185EnderecoCidade = A185EnderecoCidade;
            Z190EnderecoNumero = A190EnderecoNumero;
            Z191EnderecoComplemento = A191EnderecoComplemento;
            Z201ContatoEmail = A201ContatoEmail;
            Z198ContatoDDD = A198ContatoDDD;
            Z199ContatoDDI = A199ContatoDDI;
            Z200ContatoNumero = A200ContatoNumero;
            Z202ContatoTelefoneNumero = A202ContatoTelefoneNumero;
            Z203ContatoTelefoneDDD = A203ContatoTelefoneDDD;
            Z204ContatoTelefoneDDI = A204ContatoTelefoneDDI;
            Z421ClienteRG = A421ClienteRG;
            Z537ClienteDepositoTipo = A537ClienteDepositoTipo;
            Z538ClientePixTipo = A538ClientePixTipo;
            Z539ClientePix = A539ClientePix;
            Z400ContaAgencia = A400ContaAgencia;
            Z401ContaNumero = A401ContaNumero;
            Z436ResponsavelNome = A436ResponsavelNome;
            Z439ResponsavelEstadoCivil = A439ResponsavelEstadoCivil;
            Z576ResponsavelRG = A576ResponsavelRG;
            Z447ResponsavelCPF = A447ResponsavelCPF;
            Z448ResponsavelCEP = A448ResponsavelCEP;
            Z449ResponsavelLogradouro = A449ResponsavelLogradouro;
            Z450ResponsavelBairro = A450ResponsavelBairro;
            Z451ResponsavelCidade = A451ResponsavelCidade;
            Z452ResponsavelLogradouroNumero = A452ResponsavelLogradouroNumero;
            Z453ResponsavelComplemento = A453ResponsavelComplemento;
            Z454ResponsavelDDD = A454ResponsavelDDD;
            Z455ResponsavelNumero = A455ResponsavelNumero;
            Z456ResponsavelEmail = A456ResponsavelEmail;
            Z884ClienteSituacao = A884ClienteSituacao;
            Z885ResponsavelCargo = A885ResponsavelCargo;
            Z1039ClienteTipoRisco = A1039ClienteTipoRisco;
            Z192TipoClienteId = A192TipoClienteId;
            Z186MunicipioCodigo = A186MunicipioCodigo;
            Z444ResponsavelMunicipio = A444ResponsavelMunicipio;
            Z402BancoId = A402BancoId;
            Z457EspecialidadeId = A457EspecialidadeId;
            Z437ResponsavelNacionalidade = A437ResponsavelNacionalidade;
            Z484ClienteNacionalidade = A484ClienteNacionalidade;
            Z442ResponsavelProfissao = A442ResponsavelProfissao;
            Z487ClienteProfissao = A487ClienteProfissao;
            Z489ClienteConvenio = A489ClienteConvenio;
            Z193TipoClienteDescricao = A193TipoClienteDescricao;
            Z207TipoClientePortal = A207TipoClientePortal;
            Z793TipoClientePortalPjPf = A793TipoClientePortalPjPf;
            Z446ResponsavelMunicipioUF = A446ResponsavelMunicipioUF;
            Z445ResponsavelMunicipioNome = A445ResponsavelMunicipioNome;
            Z404BancoCodigo = A404BancoCodigo;
            Z403BancoNome = A403BancoNome;
            Z438ResponsavelNacionalidadeNome = A438ResponsavelNacionalidadeNome;
            Z485ClienteNacionalidadeNome = A485ClienteNacionalidadeNome;
            Z443ResponsavelProfissaoNome = A443ResponsavelProfissaoNome;
            Z488ClienteProfissaoNome = A488ClienteProfissaoNome;
            Z490ClienteConvenioDescricao = A490ClienteConvenioDescricao;
            Z608SecUserId_F = A608SecUserId_F;
            Z309ClienteQtdTitulos_F = A309ClienteQtdTitulos_F;
            Z310ClienteValorAPagar_F = A310ClienteValorAPagar_F;
            Z311ClienteValorAReceber_F = A311ClienteValorAReceber_F;
            Z780SerasaUltimaData_F = A780SerasaUltimaData_F;
            Z732SerasaConsultas_F = A732SerasaConsultas_F;
            Z1031RelacionamentoSacado = A1031RelacionamentoSacado;
            Z187MunicipioNome = A187MunicipioNome;
            Z189MunicipioUF = A189MunicipioUF;
         }
      }

      protected void standaloneNotModal( )
      {
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         AV35Pgmname = "Cliente";
         AssignAttri("", false, "AV35Pgmname", AV35Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ClienteId) )
         {
            A168ClienteId = AV7ClienteId;
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17Insert_MunicipioCodigo)) )
         {
            edtMunicipioCodigo_Enabled = 0;
            AssignProp("", false, edtMunicipioCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioCodigo_Enabled), 5, 0), true);
         }
         else
         {
            edtMunicipioCodigo_Enabled = 1;
            AssignProp("", false, edtMunicipioCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioCodigo_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A175ClienteCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n175ClienteCreatedAt = false;
            AssignAttri("", false, "A175ClienteCreatedAt", context.localUtil.TToC( A175ClienteCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         }
         if ( IsUpd( )  )
         {
            A176ClienteUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n176ClienteUpdatedAt = false;
            AssignAttri("", false, "A176ClienteUpdatedAt", context.localUtil.TToC( A176ClienteUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
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
         if ( IsIns( )  && (false==A174ClienteStatus) && ( Gx_BScreen == 0 ) )
         {
            A174ClienteStatus = true;
            n174ClienteStatus = false;
            AssignAttri("", false, "A174ClienteStatus", A174ClienteStatus);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000O17 */
            pr_default.execute(13, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               A608SecUserId_F = T000O17_A608SecUserId_F[0];
               n608SecUserId_F = T000O17_n608SecUserId_F[0];
            }
            else
            {
               A608SecUserId_F = 0;
               n608SecUserId_F = false;
               AssignAttri("", false, "A608SecUserId_F", StringUtil.LTrimStr( (decimal)(A608SecUserId_F), 4, 0));
            }
            pr_default.close(13);
            /* Using cursor T000O19 */
            pr_default.execute(14, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               A309ClienteQtdTitulos_F = T000O19_A309ClienteQtdTitulos_F[0];
               n309ClienteQtdTitulos_F = T000O19_n309ClienteQtdTitulos_F[0];
            }
            else
            {
               A309ClienteQtdTitulos_F = 0;
               n309ClienteQtdTitulos_F = false;
               AssignAttri("", false, "A309ClienteQtdTitulos_F", StringUtil.LTrimStr( (decimal)(A309ClienteQtdTitulos_F), 9, 0));
            }
            pr_default.close(14);
            /* Using cursor T000O23 */
            pr_default.execute(15, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               A310ClienteValorAPagar_F = T000O23_A310ClienteValorAPagar_F[0];
               n310ClienteValorAPagar_F = T000O23_n310ClienteValorAPagar_F[0];
            }
            else
            {
               A310ClienteValorAPagar_F = 0;
               n310ClienteValorAPagar_F = false;
               AssignAttri("", false, "A310ClienteValorAPagar_F", StringUtil.LTrimStr( A310ClienteValorAPagar_F, 18, 2));
            }
            pr_default.close(15);
            /* Using cursor T000O26 */
            pr_default.execute(16, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               A311ClienteValorAReceber_F = T000O26_A311ClienteValorAReceber_F[0];
               n311ClienteValorAReceber_F = T000O26_n311ClienteValorAReceber_F[0];
            }
            else
            {
               A311ClienteValorAReceber_F = 0;
               n311ClienteValorAReceber_F = false;
               AssignAttri("", false, "A311ClienteValorAReceber_F", StringUtil.LTrimStr( A311ClienteValorAReceber_F, 18, 2));
            }
            pr_default.close(16);
            /* Using cursor T000O28 */
            pr_default.execute(17, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               A780SerasaUltimaData_F = T000O28_A780SerasaUltimaData_F[0];
               A732SerasaConsultas_F = T000O28_A732SerasaConsultas_F[0];
            }
            else
            {
               A732SerasaConsultas_F = 0;
               AssignAttri("", false, "A732SerasaConsultas_F", StringUtil.LTrimStr( (decimal)(A732SerasaConsultas_F), 4, 0));
               A780SerasaUltimaData_F = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A780SerasaUltimaData_F", context.localUtil.TToC( A780SerasaUltimaData_F, 8, 5, 0, 3, "/", ":", " "));
            }
            pr_default.close(17);
            /* Using cursor T000O15 */
            pr_default.execute(12, new Object[] {A780SerasaUltimaData_F, n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               A781SerasaScoreUltimaData_F = T000O15_A781SerasaScoreUltimaData_F[0];
               A785SerasaUltimoValorRecomendado_F = T000O15_A785SerasaUltimoValorRecomendado_F[0];
            }
            else
            {
               A781SerasaScoreUltimaData_F = 0;
               AssignAttri("", false, "A781SerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A781SerasaScoreUltimaData_F), 4, 0));
               A785SerasaUltimoValorRecomendado_F = 0;
               AssignAttri("", false, "A785SerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A785SerasaUltimoValorRecomendado_F, 18, 2));
            }
            pr_default.close(12);
            /* Using cursor T000O30 */
            pr_default.execute(18, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               A1031RelacionamentoSacado = T000O30_A1031RelacionamentoSacado[0];
               n1031RelacionamentoSacado = T000O30_n1031RelacionamentoSacado[0];
            }
            else
            {
               A1031RelacionamentoSacado = 0;
               n1031RelacionamentoSacado = false;
               AssignAttri("", false, "A1031RelacionamentoSacado", StringUtil.LTrimStr( (decimal)(A1031RelacionamentoSacado), 4, 0));
            }
            pr_default.close(18);
            A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
            AssignAttri("", false, "A1030ClienteSacado", A1030ClienteSacado);
         }
      }

      protected void Load0O28( )
      {
         /* Using cursor T000O40 */
         pr_default.execute(19, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound28 = 1;
            A175ClienteCreatedAt = T000O40_A175ClienteCreatedAt[0];
            n175ClienteCreatedAt = T000O40_n175ClienteCreatedAt[0];
            A176ClienteUpdatedAt = T000O40_A176ClienteUpdatedAt[0];
            n176ClienteUpdatedAt = T000O40_n176ClienteUpdatedAt[0];
            A169ClienteDocumento = T000O40_A169ClienteDocumento[0];
            n169ClienteDocumento = T000O40_n169ClienteDocumento[0];
            AssignAttri("", false, "A169ClienteDocumento", A169ClienteDocumento);
            A170ClienteRazaoSocial = T000O40_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = T000O40_n170ClienteRazaoSocial[0];
            AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
            A171ClienteNomeFantasia = T000O40_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = T000O40_n171ClienteNomeFantasia[0];
            AssignAttri("", false, "A171ClienteNomeFantasia", A171ClienteNomeFantasia);
            A459ClienteDataNascimento = T000O40_A459ClienteDataNascimento[0];
            n459ClienteDataNascimento = T000O40_n459ClienteDataNascimento[0];
            A172ClienteTipoPessoa = T000O40_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = T000O40_n172ClienteTipoPessoa[0];
            AssignAttri("", false, "A172ClienteTipoPessoa", A172ClienteTipoPessoa);
            A193TipoClienteDescricao = T000O40_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = T000O40_n193TipoClienteDescricao[0];
            AssignAttri("", false, "A193TipoClienteDescricao", A193TipoClienteDescricao);
            A207TipoClientePortal = T000O40_A207TipoClientePortal[0];
            n207TipoClientePortal = T000O40_n207TipoClientePortal[0];
            A174ClienteStatus = T000O40_A174ClienteStatus[0];
            n174ClienteStatus = T000O40_n174ClienteStatus[0];
            AssignAttri("", false, "A174ClienteStatus", A174ClienteStatus);
            A490ClienteConvenioDescricao = T000O40_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = T000O40_n490ClienteConvenioDescricao[0];
            A177ClienteLogUser = T000O40_A177ClienteLogUser[0];
            n177ClienteLogUser = T000O40_n177ClienteLogUser[0];
            A485ClienteNacionalidadeNome = T000O40_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = T000O40_n485ClienteNacionalidadeNome[0];
            A488ClienteProfissaoNome = T000O40_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = T000O40_n488ClienteProfissaoNome[0];
            A486ClienteEstadoCivil = T000O40_A486ClienteEstadoCivil[0];
            n486ClienteEstadoCivil = T000O40_n486ClienteEstadoCivil[0];
            A181EnderecoTipo = T000O40_A181EnderecoTipo[0];
            n181EnderecoTipo = T000O40_n181EnderecoTipo[0];
            AssignAttri("", false, "A181EnderecoTipo", A181EnderecoTipo);
            A182EnderecoCEP = T000O40_A182EnderecoCEP[0];
            n182EnderecoCEP = T000O40_n182EnderecoCEP[0];
            AssignAttri("", false, "A182EnderecoCEP", A182EnderecoCEP);
            A183EnderecoLogradouro = T000O40_A183EnderecoLogradouro[0];
            n183EnderecoLogradouro = T000O40_n183EnderecoLogradouro[0];
            AssignAttri("", false, "A183EnderecoLogradouro", A183EnderecoLogradouro);
            A184EnderecoBairro = T000O40_A184EnderecoBairro[0];
            n184EnderecoBairro = T000O40_n184EnderecoBairro[0];
            AssignAttri("", false, "A184EnderecoBairro", A184EnderecoBairro);
            A185EnderecoCidade = T000O40_A185EnderecoCidade[0];
            n185EnderecoCidade = T000O40_n185EnderecoCidade[0];
            AssignAttri("", false, "A185EnderecoCidade", A185EnderecoCidade);
            A187MunicipioNome = T000O40_A187MunicipioNome[0];
            n187MunicipioNome = T000O40_n187MunicipioNome[0];
            A189MunicipioUF = T000O40_A189MunicipioUF[0];
            n189MunicipioUF = T000O40_n189MunicipioUF[0];
            AssignAttri("", false, "A189MunicipioUF", A189MunicipioUF);
            A190EnderecoNumero = T000O40_A190EnderecoNumero[0];
            n190EnderecoNumero = T000O40_n190EnderecoNumero[0];
            AssignAttri("", false, "A190EnderecoNumero", A190EnderecoNumero);
            A191EnderecoComplemento = T000O40_A191EnderecoComplemento[0];
            n191EnderecoComplemento = T000O40_n191EnderecoComplemento[0];
            AssignAttri("", false, "A191EnderecoComplemento", A191EnderecoComplemento);
            A201ContatoEmail = T000O40_A201ContatoEmail[0];
            n201ContatoEmail = T000O40_n201ContatoEmail[0];
            AssignAttri("", false, "A201ContatoEmail", A201ContatoEmail);
            A198ContatoDDD = T000O40_A198ContatoDDD[0];
            n198ContatoDDD = T000O40_n198ContatoDDD[0];
            AssignAttri("", false, "A198ContatoDDD", ((0==A198ContatoDDD)&&IsIns( )||n198ContatoDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A198ContatoDDD), 4, 0, ".", ""))));
            A199ContatoDDI = T000O40_A199ContatoDDI[0];
            n199ContatoDDI = T000O40_n199ContatoDDI[0];
            AssignAttri("", false, "A199ContatoDDI", ((0==A199ContatoDDI)&&IsIns( )||n199ContatoDDI ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A199ContatoDDI), 4, 0, ".", ""))));
            A200ContatoNumero = T000O40_A200ContatoNumero[0];
            n200ContatoNumero = T000O40_n200ContatoNumero[0];
            AssignAttri("", false, "A200ContatoNumero", ((0==A200ContatoNumero)&&IsIns( )||n200ContatoNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A200ContatoNumero), 18, 0, ".", ""))));
            A202ContatoTelefoneNumero = T000O40_A202ContatoTelefoneNumero[0];
            n202ContatoTelefoneNumero = T000O40_n202ContatoTelefoneNumero[0];
            AssignAttri("", false, "A202ContatoTelefoneNumero", ((0==A202ContatoTelefoneNumero)&&IsIns( )||n202ContatoTelefoneNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A202ContatoTelefoneNumero), 18, 0, ".", ""))));
            A203ContatoTelefoneDDD = T000O40_A203ContatoTelefoneDDD[0];
            n203ContatoTelefoneDDD = T000O40_n203ContatoTelefoneDDD[0];
            AssignAttri("", false, "A203ContatoTelefoneDDD", ((0==A203ContatoTelefoneDDD)&&IsIns( )||n203ContatoTelefoneDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A203ContatoTelefoneDDD), 4, 0, ".", ""))));
            A204ContatoTelefoneDDI = T000O40_A204ContatoTelefoneDDI[0];
            n204ContatoTelefoneDDI = T000O40_n204ContatoTelefoneDDI[0];
            AssignAttri("", false, "A204ContatoTelefoneDDI", ((0==A204ContatoTelefoneDDI)&&IsIns( )||n204ContatoTelefoneDDI ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A204ContatoTelefoneDDI), 4, 0, ".", ""))));
            A421ClienteRG = T000O40_A421ClienteRG[0];
            n421ClienteRG = T000O40_n421ClienteRG[0];
            A537ClienteDepositoTipo = T000O40_A537ClienteDepositoTipo[0];
            n537ClienteDepositoTipo = T000O40_n537ClienteDepositoTipo[0];
            A538ClientePixTipo = T000O40_A538ClientePixTipo[0];
            n538ClientePixTipo = T000O40_n538ClientePixTipo[0];
            A539ClientePix = T000O40_A539ClientePix[0];
            n539ClientePix = T000O40_n539ClientePix[0];
            A404BancoCodigo = T000O40_A404BancoCodigo[0];
            n404BancoCodigo = T000O40_n404BancoCodigo[0];
            A403BancoNome = T000O40_A403BancoNome[0];
            n403BancoNome = T000O40_n403BancoNome[0];
            A400ContaAgencia = T000O40_A400ContaAgencia[0];
            n400ContaAgencia = T000O40_n400ContaAgencia[0];
            A401ContaNumero = T000O40_A401ContaNumero[0];
            n401ContaNumero = T000O40_n401ContaNumero[0];
            A436ResponsavelNome = T000O40_A436ResponsavelNome[0];
            n436ResponsavelNome = T000O40_n436ResponsavelNome[0];
            A438ResponsavelNacionalidadeNome = T000O40_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = T000O40_n438ResponsavelNacionalidadeNome[0];
            A439ResponsavelEstadoCivil = T000O40_A439ResponsavelEstadoCivil[0];
            n439ResponsavelEstadoCivil = T000O40_n439ResponsavelEstadoCivil[0];
            A576ResponsavelRG = T000O40_A576ResponsavelRG[0];
            n576ResponsavelRG = T000O40_n576ResponsavelRG[0];
            A443ResponsavelProfissaoNome = T000O40_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = T000O40_n443ResponsavelProfissaoNome[0];
            A447ResponsavelCPF = T000O40_A447ResponsavelCPF[0];
            n447ResponsavelCPF = T000O40_n447ResponsavelCPF[0];
            A448ResponsavelCEP = T000O40_A448ResponsavelCEP[0];
            n448ResponsavelCEP = T000O40_n448ResponsavelCEP[0];
            A449ResponsavelLogradouro = T000O40_A449ResponsavelLogradouro[0];
            n449ResponsavelLogradouro = T000O40_n449ResponsavelLogradouro[0];
            A450ResponsavelBairro = T000O40_A450ResponsavelBairro[0];
            n450ResponsavelBairro = T000O40_n450ResponsavelBairro[0];
            A451ResponsavelCidade = T000O40_A451ResponsavelCidade[0];
            n451ResponsavelCidade = T000O40_n451ResponsavelCidade[0];
            A446ResponsavelMunicipioUF = T000O40_A446ResponsavelMunicipioUF[0];
            n446ResponsavelMunicipioUF = T000O40_n446ResponsavelMunicipioUF[0];
            A445ResponsavelMunicipioNome = T000O40_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = T000O40_n445ResponsavelMunicipioNome[0];
            A452ResponsavelLogradouroNumero = T000O40_A452ResponsavelLogradouroNumero[0];
            n452ResponsavelLogradouroNumero = T000O40_n452ResponsavelLogradouroNumero[0];
            A453ResponsavelComplemento = T000O40_A453ResponsavelComplemento[0];
            n453ResponsavelComplemento = T000O40_n453ResponsavelComplemento[0];
            A454ResponsavelDDD = T000O40_A454ResponsavelDDD[0];
            n454ResponsavelDDD = T000O40_n454ResponsavelDDD[0];
            A455ResponsavelNumero = T000O40_A455ResponsavelNumero[0];
            n455ResponsavelNumero = T000O40_n455ResponsavelNumero[0];
            A456ResponsavelEmail = T000O40_A456ResponsavelEmail[0];
            n456ResponsavelEmail = T000O40_n456ResponsavelEmail[0];
            A884ClienteSituacao = T000O40_A884ClienteSituacao[0];
            n884ClienteSituacao = T000O40_n884ClienteSituacao[0];
            A885ResponsavelCargo = T000O40_A885ResponsavelCargo[0];
            n885ResponsavelCargo = T000O40_n885ResponsavelCargo[0];
            A793TipoClientePortalPjPf = T000O40_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = T000O40_n793TipoClientePortalPjPf[0];
            A1039ClienteTipoRisco = T000O40_A1039ClienteTipoRisco[0];
            A192TipoClienteId = T000O40_A192TipoClienteId[0];
            n192TipoClienteId = T000O40_n192TipoClienteId[0];
            A186MunicipioCodigo = T000O40_A186MunicipioCodigo[0];
            n186MunicipioCodigo = T000O40_n186MunicipioCodigo[0];
            AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
            A444ResponsavelMunicipio = T000O40_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = T000O40_n444ResponsavelMunicipio[0];
            A402BancoId = T000O40_A402BancoId[0];
            n402BancoId = T000O40_n402BancoId[0];
            A457EspecialidadeId = T000O40_A457EspecialidadeId[0];
            n457EspecialidadeId = T000O40_n457EspecialidadeId[0];
            A437ResponsavelNacionalidade = T000O40_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = T000O40_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = T000O40_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = T000O40_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = T000O40_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = T000O40_n442ResponsavelProfissao[0];
            A487ClienteProfissao = T000O40_A487ClienteProfissao[0];
            n487ClienteProfissao = T000O40_n487ClienteProfissao[0];
            A489ClienteConvenio = T000O40_A489ClienteConvenio[0];
            n489ClienteConvenio = T000O40_n489ClienteConvenio[0];
            A780SerasaUltimaData_F = T000O40_A780SerasaUltimaData_F[0];
            A608SecUserId_F = T000O40_A608SecUserId_F[0];
            n608SecUserId_F = T000O40_n608SecUserId_F[0];
            A309ClienteQtdTitulos_F = T000O40_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = T000O40_n309ClienteQtdTitulos_F[0];
            A310ClienteValorAPagar_F = T000O40_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = T000O40_n310ClienteValorAPagar_F[0];
            A311ClienteValorAReceber_F = T000O40_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = T000O40_n311ClienteValorAReceber_F[0];
            A732SerasaConsultas_F = T000O40_A732SerasaConsultas_F[0];
            A1031RelacionamentoSacado = T000O40_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = T000O40_n1031RelacionamentoSacado[0];
            ZM0O28( -39) ;
         }
         pr_default.close(19);
         OnLoadActions0O28( ) ;
      }

      protected void OnLoadActions0O28( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV29Insert_EspecialidadeId) )
         {
            A457EspecialidadeId = AV29Insert_EspecialidadeId;
            n457EspecialidadeId = false;
            AssignAttri("", false, "A457EspecialidadeId", ((0==A457EspecialidadeId)&&IsIns( )||n457EspecialidadeId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A457EspecialidadeId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A457EspecialidadeId) )
            {
               A457EspecialidadeId = 0;
               n457EspecialidadeId = false;
               AssignAttri("", false, "A457EspecialidadeId", ((0==A457EspecialidadeId)&&IsIns( )||n457EspecialidadeId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A457EspecialidadeId), 9, 0, ".", ""))));
               n457EspecialidadeId = true;
               n457EspecialidadeId = true;
               AssignAttri("", false, "A457EspecialidadeId", ((0==A457EspecialidadeId)&&IsIns( )||n457EspecialidadeId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A457EspecialidadeId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_TipoClienteId) )
         {
            A192TipoClienteId = AV14Insert_TipoClienteId;
            n192TipoClienteId = false;
            AssignAttri("", false, "A192TipoClienteId", ((0==A192TipoClienteId)&&IsIns( )||n192TipoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==A192TipoClienteId) )
            {
               A192TipoClienteId = 0;
               n192TipoClienteId = false;
               AssignAttri("", false, "A192TipoClienteId", ((0==A192TipoClienteId)&&IsIns( )||n192TipoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ".", ""))));
               n192TipoClienteId = true;
               n192TipoClienteId = true;
               AssignAttri("", false, "A192TipoClienteId", ((0==A192TipoClienteId)&&IsIns( )||n192TipoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV32Insert_ClienteConvenio) )
         {
            A489ClienteConvenio = AV32Insert_ClienteConvenio;
            n489ClienteConvenio = false;
            AssignAttri("", false, "A489ClienteConvenio", ((0==A489ClienteConvenio)&&IsIns( )||n489ClienteConvenio ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A489ClienteConvenio), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A489ClienteConvenio) )
            {
               A489ClienteConvenio = 0;
               n489ClienteConvenio = false;
               AssignAttri("", false, "A489ClienteConvenio", ((0==A489ClienteConvenio)&&IsIns( )||n489ClienteConvenio ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A489ClienteConvenio), 9, 0, ".", ""))));
               n489ClienteConvenio = true;
               n489ClienteConvenio = true;
               AssignAttri("", false, "A489ClienteConvenio", ((0==A489ClienteConvenio)&&IsIns( )||n489ClienteConvenio ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A489ClienteConvenio), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV30Insert_ClienteNacionalidade) )
         {
            A484ClienteNacionalidade = AV30Insert_ClienteNacionalidade;
            n484ClienteNacionalidade = false;
            AssignAttri("", false, "A484ClienteNacionalidade", ((0==A484ClienteNacionalidade)&&IsIns( )||n484ClienteNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A484ClienteNacionalidade), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A484ClienteNacionalidade) )
            {
               A484ClienteNacionalidade = 0;
               n484ClienteNacionalidade = false;
               AssignAttri("", false, "A484ClienteNacionalidade", ((0==A484ClienteNacionalidade)&&IsIns( )||n484ClienteNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A484ClienteNacionalidade), 9, 0, ".", ""))));
               n484ClienteNacionalidade = true;
               n484ClienteNacionalidade = true;
               AssignAttri("", false, "A484ClienteNacionalidade", ((0==A484ClienteNacionalidade)&&IsIns( )||n484ClienteNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A484ClienteNacionalidade), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV31Insert_ClienteProfissao) )
         {
            A487ClienteProfissao = AV31Insert_ClienteProfissao;
            n487ClienteProfissao = false;
            AssignAttri("", false, "A487ClienteProfissao", ((0==A487ClienteProfissao)&&IsIns( )||n487ClienteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A487ClienteProfissao), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A487ClienteProfissao) )
            {
               A487ClienteProfissao = 0;
               n487ClienteProfissao = false;
               AssignAttri("", false, "A487ClienteProfissao", ((0==A487ClienteProfissao)&&IsIns( )||n487ClienteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A487ClienteProfissao), 9, 0, ".", ""))));
               n487ClienteProfissao = true;
               n487ClienteProfissao = true;
               AssignAttri("", false, "A487ClienteProfissao", ((0==A487ClienteProfissao)&&IsIns( )||n487ClienteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A487ClienteProfissao), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17Insert_MunicipioCodigo)) )
         {
            A186MunicipioCodigo = AV17Insert_MunicipioCodigo;
            n186MunicipioCodigo = false;
            AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23ComboMunicipioCodigo)) )
            {
               A186MunicipioCodigo = "";
               n186MunicipioCodigo = false;
               AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
               n186MunicipioCodigo = true;
               n186MunicipioCodigo = true;
               AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ComboMunicipioCodigo)) )
               {
                  A186MunicipioCodigo = AV23ComboMunicipioCodigo;
                  n186MunicipioCodigo = false;
                  AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
               }
               else
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) )
                  {
                     A186MunicipioCodigo = "";
                     n186MunicipioCodigo = false;
                     AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
                     n186MunicipioCodigo = true;
                     n186MunicipioCodigo = true;
                     AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV25Insert_BancoId) )
         {
            A402BancoId = AV25Insert_BancoId;
            n402BancoId = false;
            AssignAttri("", false, "A402BancoId", ((0==A402BancoId)&&IsIns( )||n402BancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A402BancoId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A402BancoId) )
            {
               A402BancoId = 0;
               n402BancoId = false;
               AssignAttri("", false, "A402BancoId", ((0==A402BancoId)&&IsIns( )||n402BancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A402BancoId), 9, 0, ".", ""))));
               n402BancoId = true;
               n402BancoId = true;
               AssignAttri("", false, "A402BancoId", ((0==A402BancoId)&&IsIns( )||n402BancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A402BancoId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV26Insert_ResponsavelNacionalidade) )
         {
            A437ResponsavelNacionalidade = AV26Insert_ResponsavelNacionalidade;
            n437ResponsavelNacionalidade = false;
            AssignAttri("", false, "A437ResponsavelNacionalidade", ((0==A437ResponsavelNacionalidade)&&IsIns( )||n437ResponsavelNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A437ResponsavelNacionalidade), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A437ResponsavelNacionalidade) )
            {
               A437ResponsavelNacionalidade = 0;
               n437ResponsavelNacionalidade = false;
               AssignAttri("", false, "A437ResponsavelNacionalidade", ((0==A437ResponsavelNacionalidade)&&IsIns( )||n437ResponsavelNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A437ResponsavelNacionalidade), 9, 0, ".", ""))));
               n437ResponsavelNacionalidade = true;
               n437ResponsavelNacionalidade = true;
               AssignAttri("", false, "A437ResponsavelNacionalidade", ((0==A437ResponsavelNacionalidade)&&IsIns( )||n437ResponsavelNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A437ResponsavelNacionalidade), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV27Insert_ResponsavelProfissao) )
         {
            A442ResponsavelProfissao = AV27Insert_ResponsavelProfissao;
            n442ResponsavelProfissao = false;
            AssignAttri("", false, "A442ResponsavelProfissao", ((0==A442ResponsavelProfissao)&&IsIns( )||n442ResponsavelProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A442ResponsavelProfissao), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A442ResponsavelProfissao) )
            {
               A442ResponsavelProfissao = 0;
               n442ResponsavelProfissao = false;
               AssignAttri("", false, "A442ResponsavelProfissao", ((0==A442ResponsavelProfissao)&&IsIns( )||n442ResponsavelProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A442ResponsavelProfissao), 9, 0, ".", ""))));
               n442ResponsavelProfissao = true;
               n442ResponsavelProfissao = true;
               AssignAttri("", false, "A442ResponsavelProfissao", ((0==A442ResponsavelProfissao)&&IsIns( )||n442ResponsavelProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A442ResponsavelProfissao), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28Insert_ResponsavelMunicipio)) )
         {
            A444ResponsavelMunicipio = AV28Insert_ResponsavelMunicipio;
            n444ResponsavelMunicipio = false;
            AssignAttri("", false, "A444ResponsavelMunicipio", A444ResponsavelMunicipio);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A444ResponsavelMunicipio)) )
            {
               A444ResponsavelMunicipio = "";
               n444ResponsavelMunicipio = false;
               AssignAttri("", false, "A444ResponsavelMunicipio", A444ResponsavelMunicipio);
               n444ResponsavelMunicipio = true;
               n444ResponsavelMunicipio = true;
               AssignAttri("", false, "A444ResponsavelMunicipio", A444ResponsavelMunicipio);
            }
         }
         /* Using cursor T000O15 */
         pr_default.execute(12, new Object[] {A780SerasaUltimaData_F, n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A781SerasaScoreUltimaData_F = T000O15_A781SerasaScoreUltimaData_F[0];
            A785SerasaUltimoValorRecomendado_F = T000O15_A785SerasaUltimoValorRecomendado_F[0];
         }
         else
         {
            A781SerasaScoreUltimaData_F = 0;
            AssignAttri("", false, "A781SerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A781SerasaScoreUltimaData_F), 4, 0));
            A785SerasaUltimoValorRecomendado_F = 0;
            AssignAttri("", false, "A785SerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A785SerasaUltimoValorRecomendado_F, 18, 2));
         }
         pr_default.close(12);
         A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
         AssignAttri("", false, "A1030ClienteSacado", A1030ClienteSacado);
         A206ClienteCelular_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A198ContatoDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 1, 5), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 6, 4), "", "", "", "", "", "");
         AssignAttri("", false, "A206ClienteCelular_F", A206ClienteCelular_F);
         A205ClienteTelefone_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A203ContatoTelefoneDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 1, 4), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 5, 4), "", "", "", "", "", "");
         AssignAttri("", false, "A205ClienteTelefone_F", A205ClienteTelefone_F);
         GXt_char2 = A577ResponsavelCelular_F;
         new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char2) ;
         n454ResponsavelDDD = ((0==A454ResponsavelDDD) ? true : false);
         A577ResponsavelCelular_F = GXt_char2;
         AssignAttri("", false, "A577ResponsavelCelular_F", A577ResponsavelCelular_F);
      }

      protected void CheckExtendedTable0O28( )
      {
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV29Insert_EspecialidadeId) )
         {
            A457EspecialidadeId = AV29Insert_EspecialidadeId;
            n457EspecialidadeId = false;
            AssignAttri("", false, "A457EspecialidadeId", ((0==A457EspecialidadeId)&&IsIns( )||n457EspecialidadeId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A457EspecialidadeId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A457EspecialidadeId) )
            {
               A457EspecialidadeId = 0;
               n457EspecialidadeId = false;
               AssignAttri("", false, "A457EspecialidadeId", ((0==A457EspecialidadeId)&&IsIns( )||n457EspecialidadeId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A457EspecialidadeId), 9, 0, ".", ""))));
               n457EspecialidadeId = true;
               n457EspecialidadeId = true;
               AssignAttri("", false, "A457EspecialidadeId", ((0==A457EspecialidadeId)&&IsIns( )||n457EspecialidadeId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A457EspecialidadeId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_TipoClienteId) )
         {
            A192TipoClienteId = AV14Insert_TipoClienteId;
            n192TipoClienteId = false;
            AssignAttri("", false, "A192TipoClienteId", ((0==A192TipoClienteId)&&IsIns( )||n192TipoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ".", ""))));
         }
         else
         {
            if ( (0==A192TipoClienteId) )
            {
               A192TipoClienteId = 0;
               n192TipoClienteId = false;
               AssignAttri("", false, "A192TipoClienteId", ((0==A192TipoClienteId)&&IsIns( )||n192TipoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ".", ""))));
               n192TipoClienteId = true;
               n192TipoClienteId = true;
               AssignAttri("", false, "A192TipoClienteId", ((0==A192TipoClienteId)&&IsIns( )||n192TipoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV32Insert_ClienteConvenio) )
         {
            A489ClienteConvenio = AV32Insert_ClienteConvenio;
            n489ClienteConvenio = false;
            AssignAttri("", false, "A489ClienteConvenio", ((0==A489ClienteConvenio)&&IsIns( )||n489ClienteConvenio ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A489ClienteConvenio), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A489ClienteConvenio) )
            {
               A489ClienteConvenio = 0;
               n489ClienteConvenio = false;
               AssignAttri("", false, "A489ClienteConvenio", ((0==A489ClienteConvenio)&&IsIns( )||n489ClienteConvenio ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A489ClienteConvenio), 9, 0, ".", ""))));
               n489ClienteConvenio = true;
               n489ClienteConvenio = true;
               AssignAttri("", false, "A489ClienteConvenio", ((0==A489ClienteConvenio)&&IsIns( )||n489ClienteConvenio ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A489ClienteConvenio), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV30Insert_ClienteNacionalidade) )
         {
            A484ClienteNacionalidade = AV30Insert_ClienteNacionalidade;
            n484ClienteNacionalidade = false;
            AssignAttri("", false, "A484ClienteNacionalidade", ((0==A484ClienteNacionalidade)&&IsIns( )||n484ClienteNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A484ClienteNacionalidade), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A484ClienteNacionalidade) )
            {
               A484ClienteNacionalidade = 0;
               n484ClienteNacionalidade = false;
               AssignAttri("", false, "A484ClienteNacionalidade", ((0==A484ClienteNacionalidade)&&IsIns( )||n484ClienteNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A484ClienteNacionalidade), 9, 0, ".", ""))));
               n484ClienteNacionalidade = true;
               n484ClienteNacionalidade = true;
               AssignAttri("", false, "A484ClienteNacionalidade", ((0==A484ClienteNacionalidade)&&IsIns( )||n484ClienteNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A484ClienteNacionalidade), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV31Insert_ClienteProfissao) )
         {
            A487ClienteProfissao = AV31Insert_ClienteProfissao;
            n487ClienteProfissao = false;
            AssignAttri("", false, "A487ClienteProfissao", ((0==A487ClienteProfissao)&&IsIns( )||n487ClienteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A487ClienteProfissao), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A487ClienteProfissao) )
            {
               A487ClienteProfissao = 0;
               n487ClienteProfissao = false;
               AssignAttri("", false, "A487ClienteProfissao", ((0==A487ClienteProfissao)&&IsIns( )||n487ClienteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A487ClienteProfissao), 9, 0, ".", ""))));
               n487ClienteProfissao = true;
               n487ClienteProfissao = true;
               AssignAttri("", false, "A487ClienteProfissao", ((0==A487ClienteProfissao)&&IsIns( )||n487ClienteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A487ClienteProfissao), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17Insert_MunicipioCodigo)) )
         {
            A186MunicipioCodigo = AV17Insert_MunicipioCodigo;
            n186MunicipioCodigo = false;
            AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23ComboMunicipioCodigo)) )
            {
               A186MunicipioCodigo = "";
               n186MunicipioCodigo = false;
               AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
               n186MunicipioCodigo = true;
               n186MunicipioCodigo = true;
               AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ComboMunicipioCodigo)) )
               {
                  A186MunicipioCodigo = AV23ComboMunicipioCodigo;
                  n186MunicipioCodigo = false;
                  AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
               }
               else
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) )
                  {
                     A186MunicipioCodigo = "";
                     n186MunicipioCodigo = false;
                     AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
                     n186MunicipioCodigo = true;
                     n186MunicipioCodigo = true;
                     AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
                  }
               }
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV25Insert_BancoId) )
         {
            A402BancoId = AV25Insert_BancoId;
            n402BancoId = false;
            AssignAttri("", false, "A402BancoId", ((0==A402BancoId)&&IsIns( )||n402BancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A402BancoId), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A402BancoId) )
            {
               A402BancoId = 0;
               n402BancoId = false;
               AssignAttri("", false, "A402BancoId", ((0==A402BancoId)&&IsIns( )||n402BancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A402BancoId), 9, 0, ".", ""))));
               n402BancoId = true;
               n402BancoId = true;
               AssignAttri("", false, "A402BancoId", ((0==A402BancoId)&&IsIns( )||n402BancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A402BancoId), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV26Insert_ResponsavelNacionalidade) )
         {
            A437ResponsavelNacionalidade = AV26Insert_ResponsavelNacionalidade;
            n437ResponsavelNacionalidade = false;
            AssignAttri("", false, "A437ResponsavelNacionalidade", ((0==A437ResponsavelNacionalidade)&&IsIns( )||n437ResponsavelNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A437ResponsavelNacionalidade), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A437ResponsavelNacionalidade) )
            {
               A437ResponsavelNacionalidade = 0;
               n437ResponsavelNacionalidade = false;
               AssignAttri("", false, "A437ResponsavelNacionalidade", ((0==A437ResponsavelNacionalidade)&&IsIns( )||n437ResponsavelNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A437ResponsavelNacionalidade), 9, 0, ".", ""))));
               n437ResponsavelNacionalidade = true;
               n437ResponsavelNacionalidade = true;
               AssignAttri("", false, "A437ResponsavelNacionalidade", ((0==A437ResponsavelNacionalidade)&&IsIns( )||n437ResponsavelNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A437ResponsavelNacionalidade), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV27Insert_ResponsavelProfissao) )
         {
            A442ResponsavelProfissao = AV27Insert_ResponsavelProfissao;
            n442ResponsavelProfissao = false;
            AssignAttri("", false, "A442ResponsavelProfissao", ((0==A442ResponsavelProfissao)&&IsIns( )||n442ResponsavelProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A442ResponsavelProfissao), 9, 0, ".", ""))));
         }
         else
         {
            if ( (0==A442ResponsavelProfissao) )
            {
               A442ResponsavelProfissao = 0;
               n442ResponsavelProfissao = false;
               AssignAttri("", false, "A442ResponsavelProfissao", ((0==A442ResponsavelProfissao)&&IsIns( )||n442ResponsavelProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A442ResponsavelProfissao), 9, 0, ".", ""))));
               n442ResponsavelProfissao = true;
               n442ResponsavelProfissao = true;
               AssignAttri("", false, "A442ResponsavelProfissao", ((0==A442ResponsavelProfissao)&&IsIns( )||n442ResponsavelProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A442ResponsavelProfissao), 9, 0, ".", ""))));
            }
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28Insert_ResponsavelMunicipio)) )
         {
            A444ResponsavelMunicipio = AV28Insert_ResponsavelMunicipio;
            n444ResponsavelMunicipio = false;
            AssignAttri("", false, "A444ResponsavelMunicipio", A444ResponsavelMunicipio);
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A444ResponsavelMunicipio)) )
            {
               A444ResponsavelMunicipio = "";
               n444ResponsavelMunicipio = false;
               AssignAttri("", false, "A444ResponsavelMunicipio", A444ResponsavelMunicipio);
               n444ResponsavelMunicipio = true;
               n444ResponsavelMunicipio = true;
               AssignAttri("", false, "A444ResponsavelMunicipio", A444ResponsavelMunicipio);
            }
         }
         /* Using cursor T000O17 */
         pr_default.execute(13, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            A608SecUserId_F = T000O17_A608SecUserId_F[0];
            n608SecUserId_F = T000O17_n608SecUserId_F[0];
         }
         else
         {
            A608SecUserId_F = 0;
            n608SecUserId_F = false;
            AssignAttri("", false, "A608SecUserId_F", StringUtil.LTrimStr( (decimal)(A608SecUserId_F), 4, 0));
         }
         pr_default.close(13);
         /* Using cursor T000O19 */
         pr_default.execute(14, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A309ClienteQtdTitulos_F = T000O19_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = T000O19_n309ClienteQtdTitulos_F[0];
         }
         else
         {
            A309ClienteQtdTitulos_F = 0;
            n309ClienteQtdTitulos_F = false;
            AssignAttri("", false, "A309ClienteQtdTitulos_F", StringUtil.LTrimStr( (decimal)(A309ClienteQtdTitulos_F), 9, 0));
         }
         pr_default.close(14);
         /* Using cursor T000O23 */
         pr_default.execute(15, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            A310ClienteValorAPagar_F = T000O23_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = T000O23_n310ClienteValorAPagar_F[0];
         }
         else
         {
            A310ClienteValorAPagar_F = 0;
            n310ClienteValorAPagar_F = false;
            AssignAttri("", false, "A310ClienteValorAPagar_F", StringUtil.LTrimStr( A310ClienteValorAPagar_F, 18, 2));
         }
         pr_default.close(15);
         if ( ( A310ClienteValorAPagar_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T000O26 */
         pr_default.execute(16, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            A311ClienteValorAReceber_F = T000O26_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = T000O26_n311ClienteValorAReceber_F[0];
         }
         else
         {
            A311ClienteValorAReceber_F = 0;
            n311ClienteValorAReceber_F = false;
            AssignAttri("", false, "A311ClienteValorAReceber_F", StringUtil.LTrimStr( A311ClienteValorAReceber_F, 18, 2));
         }
         pr_default.close(16);
         if ( ( A311ClienteValorAReceber_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T000O28 */
         pr_default.execute(17, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            A780SerasaUltimaData_F = T000O28_A780SerasaUltimaData_F[0];
            A732SerasaConsultas_F = T000O28_A732SerasaConsultas_F[0];
         }
         else
         {
            A732SerasaConsultas_F = 0;
            AssignAttri("", false, "A732SerasaConsultas_F", StringUtil.LTrimStr( (decimal)(A732SerasaConsultas_F), 4, 0));
            A780SerasaUltimaData_F = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "A780SerasaUltimaData_F", context.localUtil.TToC( A780SerasaUltimaData_F, 8, 5, 0, 3, "/", ":", " "));
         }
         pr_default.close(17);
         /* Using cursor T000O15 */
         pr_default.execute(12, new Object[] {A780SerasaUltimaData_F, n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A781SerasaScoreUltimaData_F = T000O15_A781SerasaScoreUltimaData_F[0];
            A785SerasaUltimoValorRecomendado_F = T000O15_A785SerasaUltimoValorRecomendado_F[0];
         }
         else
         {
            A781SerasaScoreUltimaData_F = 0;
            AssignAttri("", false, "A781SerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A781SerasaScoreUltimaData_F), 4, 0));
            A785SerasaUltimoValorRecomendado_F = 0;
            AssignAttri("", false, "A785SerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A785SerasaUltimoValorRecomendado_F, 18, 2));
         }
         pr_default.close(12);
         if ( ( A785SerasaUltimoValorRecomendado_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor T000O30 */
         pr_default.execute(18, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            A1031RelacionamentoSacado = T000O30_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = T000O30_n1031RelacionamentoSacado[0];
         }
         else
         {
            A1031RelacionamentoSacado = 0;
            n1031RelacionamentoSacado = false;
            AssignAttri("", false, "A1031RelacionamentoSacado", StringUtil.LTrimStr( (decimal)(A1031RelacionamentoSacado), 4, 0));
         }
         pr_default.close(18);
         A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
         AssignAttri("", false, "A1030ClienteSacado", A1030ClienteSacado);
         /* Using cursor T000O41 */
         pr_default.execute(20, new Object[] {n169ClienteDocumento, A169ClienteDocumento, n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            GX_msglist.addItem("Documento já está sendo utilizado", 1, "CLIENTEDOCUMENTO");
            AnyError = 1;
            GX_FocusControl = edtClienteDocumento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(20);
         if ( ! ( ( StringUtil.StrCmp(A172ClienteTipoPessoa, "FISICA") == 0 ) || ( StringUtil.StrCmp(A172ClienteTipoPessoa, "JURIDICA") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A172ClienteTipoPessoa)) ) )
         {
            GX_msglist.addItem("Campo Tipo pessoa fora do intervalo", "OutOfRange", 1, "CLIENTETIPOPESSOA");
            AnyError = 1;
            GX_FocusControl = cmbClienteTipoPessoa_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( ( StringUtil.StrCmp(A181EnderecoTipo, "COBRANCA") == 0 ) || ( StringUtil.StrCmp(A181EnderecoTipo, "ENTREGA") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A181EnderecoTipo)) ) )
         {
            GX_msglist.addItem("Campo Endereco Tipo fora do intervalo", "OutOfRange", 1, "ENDERECOTIPO");
            AnyError = 1;
            GX_FocusControl = cmbEnderecoTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000O5 */
         pr_default.execute(3, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ) )
            {
               GX_msglist.addItem("Não existe 'Municipio'.", "ForeignKeyNotFound", 1, "MUNICIPIOCODIGO");
               AnyError = 1;
               GX_FocusControl = edtMunicipioCodigo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A187MunicipioNome = T000O5_A187MunicipioNome[0];
         n187MunicipioNome = T000O5_n187MunicipioNome[0];
         A189MunicipioUF = T000O5_A189MunicipioUF[0];
         n189MunicipioUF = T000O5_n189MunicipioUF[0];
         AssignAttri("", false, "A189MunicipioUF", A189MunicipioUF);
         pr_default.close(3);
         if ( ! ( GxRegex.IsMatch(A201ContatoEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A201ContatoEmail)) ) )
         {
            GX_msglist.addItem("O valor de E-mail não coincide com o padrão especificado", "OutOfRange", 1, "CONTATOEMAIL");
            AnyError = 1;
            GX_FocusControl = edtContatoEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A206ClienteCelular_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A198ContatoDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 1, 5), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 6, 4), "", "", "", "", "", "");
         AssignAttri("", false, "A206ClienteCelular_F", A206ClienteCelular_F);
         A205ClienteTelefone_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A203ContatoTelefoneDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 1, 4), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 5, 4), "", "", "", "", "", "");
         AssignAttri("", false, "A205ClienteTelefone_F", A205ClienteTelefone_F);
         GXt_char2 = A577ResponsavelCelular_F;
         new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char2) ;
         n454ResponsavelDDD = ((0==A454ResponsavelDDD) ? true : false);
         A577ResponsavelCelular_F = GXt_char2;
         AssignAttri("", false, "A577ResponsavelCelular_F", A577ResponsavelCelular_F);
         /* Using cursor T000O4 */
         pr_default.execute(2, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A192TipoClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Cliente'.", "ForeignKeyNotFound", 1, "TIPOCLIENTEID");
               AnyError = 1;
            }
         }
         A193TipoClienteDescricao = T000O4_A193TipoClienteDescricao[0];
         n193TipoClienteDescricao = T000O4_n193TipoClienteDescricao[0];
         AssignAttri("", false, "A193TipoClienteDescricao", A193TipoClienteDescricao);
         A207TipoClientePortal = T000O4_A207TipoClientePortal[0];
         n207TipoClientePortal = T000O4_n207TipoClientePortal[0];
         A793TipoClientePortalPjPf = T000O4_A793TipoClientePortalPjPf[0];
         n793TipoClientePortalPjPf = T000O4_n793TipoClientePortalPjPf[0];
         pr_default.close(2);
         /* Using cursor T000O6 */
         pr_default.execute(4, new Object[] {n444ResponsavelMunicipio, A444ResponsavelMunicipio});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A444ResponsavelMunicipio)) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Reponsavel Municipio'.", "ForeignKeyNotFound", 1, "RESPONSAVELMUNICIPIO");
               AnyError = 1;
            }
         }
         A446ResponsavelMunicipioUF = T000O6_A446ResponsavelMunicipioUF[0];
         n446ResponsavelMunicipioUF = T000O6_n446ResponsavelMunicipioUF[0];
         A445ResponsavelMunicipioNome = T000O6_A445ResponsavelMunicipioNome[0];
         n445ResponsavelMunicipioNome = T000O6_n445ResponsavelMunicipioNome[0];
         pr_default.close(4);
         /* Using cursor T000O7 */
         pr_default.execute(5, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A402BancoId) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
            }
         }
         A404BancoCodigo = T000O7_A404BancoCodigo[0];
         n404BancoCodigo = T000O7_n404BancoCodigo[0];
         A403BancoNome = T000O7_A403BancoNome[0];
         n403BancoNome = T000O7_n403BancoNome[0];
         pr_default.close(5);
         /* Using cursor T000O8 */
         pr_default.execute(6, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A457EspecialidadeId) ) )
            {
               GX_msglist.addItem("Não existe 'Especialidade'.", "ForeignKeyNotFound", 1, "ESPECIALIDADEID");
               AnyError = 1;
            }
         }
         pr_default.close(6);
         /* Using cursor T000O9 */
         pr_default.execute(7, new Object[] {n437ResponsavelNacionalidade, A437ResponsavelNacionalidade});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A437ResponsavelNacionalidade) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Responsavel Nacionalidade'.", "ForeignKeyNotFound", 1, "RESPONSAVELNACIONALIDADE");
               AnyError = 1;
            }
         }
         A438ResponsavelNacionalidadeNome = T000O9_A438ResponsavelNacionalidadeNome[0];
         n438ResponsavelNacionalidadeNome = T000O9_n438ResponsavelNacionalidadeNome[0];
         pr_default.close(7);
         /* Using cursor T000O10 */
         pr_default.execute(8, new Object[] {n484ClienteNacionalidade, A484ClienteNacionalidade});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A484ClienteNacionalidade) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Cliente Nacionalidade'.", "ForeignKeyNotFound", 1, "CLIENTENACIONALIDADE");
               AnyError = 1;
            }
         }
         A485ClienteNacionalidadeNome = T000O10_A485ClienteNacionalidadeNome[0];
         n485ClienteNacionalidadeNome = T000O10_n485ClienteNacionalidadeNome[0];
         pr_default.close(8);
         /* Using cursor T000O11 */
         pr_default.execute(9, new Object[] {n442ResponsavelProfissao, A442ResponsavelProfissao});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A442ResponsavelProfissao) ) )
            {
               GX_msglist.addItem("Não existe 'Db Responsavel Profissao'.", "ForeignKeyNotFound", 1, "RESPONSAVELPROFISSAO");
               AnyError = 1;
            }
         }
         A443ResponsavelProfissaoNome = T000O11_A443ResponsavelProfissaoNome[0];
         n443ResponsavelProfissaoNome = T000O11_n443ResponsavelProfissaoNome[0];
         pr_default.close(9);
         /* Using cursor T000O12 */
         pr_default.execute(10, new Object[] {n487ClienteProfissao, A487ClienteProfissao});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A487ClienteProfissao) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente Profissao'.", "ForeignKeyNotFound", 1, "CLIENTEPROFISSAO");
               AnyError = 1;
            }
         }
         A488ClienteProfissaoNome = T000O12_A488ClienteProfissaoNome[0];
         n488ClienteProfissaoNome = T000O12_n488ClienteProfissaoNome[0];
         pr_default.close(10);
         /* Using cursor T000O13 */
         pr_default.execute(11, new Object[] {n489ClienteConvenio, A489ClienteConvenio});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A489ClienteConvenio) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente Convenio'.", "ForeignKeyNotFound", 1, "CLIENTECONVENIO");
               AnyError = 1;
            }
         }
         A490ClienteConvenioDescricao = T000O13_A490ClienteConvenioDescricao[0];
         n490ClienteConvenioDescricao = T000O13_n490ClienteConvenioDescricao[0];
         pr_default.close(11);
      }

      protected void CloseExtendedTableCursors0O28( )
      {
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(12);
         pr_default.close(18);
         pr_default.close(3);
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(11);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_52( int A168ClienteId )
      {
         /* Using cursor T000O43 */
         pr_default.execute(21, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            A608SecUserId_F = T000O43_A608SecUserId_F[0];
            n608SecUserId_F = T000O43_n608SecUserId_F[0];
         }
         else
         {
            A608SecUserId_F = 0;
            n608SecUserId_F = false;
            AssignAttri("", false, "A608SecUserId_F", StringUtil.LTrimStr( (decimal)(A608SecUserId_F), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A608SecUserId_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(21) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(21);
      }

      protected void gxLoad_53( int A168ClienteId )
      {
         /* Using cursor T000O45 */
         pr_default.execute(22, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            A309ClienteQtdTitulos_F = T000O45_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = T000O45_n309ClienteQtdTitulos_F[0];
         }
         else
         {
            A309ClienteQtdTitulos_F = 0;
            n309ClienteQtdTitulos_F = false;
            AssignAttri("", false, "A309ClienteQtdTitulos_F", StringUtil.LTrimStr( (decimal)(A309ClienteQtdTitulos_F), 9, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A309ClienteQtdTitulos_F), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(22) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(22);
      }

      protected void gxLoad_54( int A168ClienteId )
      {
         /* Using cursor T000O49 */
         pr_default.execute(23, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            A310ClienteValorAPagar_F = T000O49_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = T000O49_n310ClienteValorAPagar_F[0];
         }
         else
         {
            A310ClienteValorAPagar_F = 0;
            n310ClienteValorAPagar_F = false;
            AssignAttri("", false, "A310ClienteValorAPagar_F", StringUtil.LTrimStr( A310ClienteValorAPagar_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A310ClienteValorAPagar_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(23) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(23);
      }

      protected void gxLoad_55( int A168ClienteId )
      {
         /* Using cursor T000O52 */
         pr_default.execute(24, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            A311ClienteValorAReceber_F = T000O52_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = T000O52_n311ClienteValorAReceber_F[0];
         }
         else
         {
            A311ClienteValorAReceber_F = 0;
            n311ClienteValorAReceber_F = false;
            AssignAttri("", false, "A311ClienteValorAReceber_F", StringUtil.LTrimStr( A311ClienteValorAReceber_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A311ClienteValorAReceber_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void gxLoad_56( int A168ClienteId )
      {
         /* Using cursor T000O54 */
         pr_default.execute(25, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            A780SerasaUltimaData_F = T000O54_A780SerasaUltimaData_F[0];
            A732SerasaConsultas_F = T000O54_A732SerasaConsultas_F[0];
         }
         else
         {
            A732SerasaConsultas_F = 0;
            AssignAttri("", false, "A732SerasaConsultas_F", StringUtil.LTrimStr( (decimal)(A732SerasaConsultas_F), 4, 0));
            A780SerasaUltimaData_F = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "A780SerasaUltimaData_F", context.localUtil.TToC( A780SerasaUltimaData_F, 8, 5, 0, 3, "/", ":", " "));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A780SerasaUltimaData_F, 10, 8, 0, 3, "/", ":", " "))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A732SerasaConsultas_F), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void gxLoad_51( int A168ClienteId ,
                                DateTime A780SerasaUltimaData_F )
      {
         /* Using cursor T000O56 */
         pr_default.execute(26, new Object[] {A780SerasaUltimaData_F, n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            A781SerasaScoreUltimaData_F = T000O56_A781SerasaScoreUltimaData_F[0];
            A785SerasaUltimoValorRecomendado_F = T000O56_A785SerasaUltimoValorRecomendado_F[0];
         }
         else
         {
            A781SerasaScoreUltimaData_F = 0;
            AssignAttri("", false, "A781SerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A781SerasaScoreUltimaData_F), 4, 0));
            A785SerasaUltimoValorRecomendado_F = 0;
            AssignAttri("", false, "A785SerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A785SerasaUltimoValorRecomendado_F, 18, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A781SerasaScoreUltimaData_F), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A785SerasaUltimoValorRecomendado_F, 18, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(26) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(26);
      }

      protected void gxLoad_57( int A168ClienteId )
      {
         /* Using cursor T000O58 */
         pr_default.execute(27, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(27) != 101) )
         {
            A1031RelacionamentoSacado = T000O58_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = T000O58_n1031RelacionamentoSacado[0];
         }
         else
         {
            A1031RelacionamentoSacado = 0;
            n1031RelacionamentoSacado = false;
            AssignAttri("", false, "A1031RelacionamentoSacado", StringUtil.LTrimStr( (decimal)(A1031RelacionamentoSacado), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1031RelacionamentoSacado), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(27) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(27);
      }

      protected void gxLoad_42( string A186MunicipioCodigo )
      {
         /* Using cursor T000O59 */
         pr_default.execute(28, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(28) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ) )
            {
               GX_msglist.addItem("Não existe 'Municipio'.", "ForeignKeyNotFound", 1, "MUNICIPIOCODIGO");
               AnyError = 1;
               GX_FocusControl = edtMunicipioCodigo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A187MunicipioNome = T000O59_A187MunicipioNome[0];
         n187MunicipioNome = T000O59_n187MunicipioNome[0];
         A189MunicipioUF = T000O59_A189MunicipioUF[0];
         n189MunicipioUF = T000O59_n189MunicipioUF[0];
         AssignAttri("", false, "A189MunicipioUF", A189MunicipioUF);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A187MunicipioNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( A189MunicipioUF)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(28) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(28);
      }

      protected void gxLoad_41( short A192TipoClienteId )
      {
         /* Using cursor T000O60 */
         pr_default.execute(29, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            if ( ! ( (0==A192TipoClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Cliente'.", "ForeignKeyNotFound", 1, "TIPOCLIENTEID");
               AnyError = 1;
            }
         }
         A193TipoClienteDescricao = T000O60_A193TipoClienteDescricao[0];
         n193TipoClienteDescricao = T000O60_n193TipoClienteDescricao[0];
         AssignAttri("", false, "A193TipoClienteDescricao", A193TipoClienteDescricao);
         A207TipoClientePortal = T000O60_A207TipoClientePortal[0];
         n207TipoClientePortal = T000O60_n207TipoClientePortal[0];
         A793TipoClientePortalPjPf = T000O60_A793TipoClientePortalPjPf[0];
         n793TipoClientePortalPjPf = T000O60_n793TipoClientePortalPjPf[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A193TipoClienteDescricao)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A207TipoClientePortal))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A793TipoClientePortalPjPf))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(29) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(29);
      }

      protected void gxLoad_43( string A444ResponsavelMunicipio )
      {
         /* Using cursor T000O61 */
         pr_default.execute(30, new Object[] {n444ResponsavelMunicipio, A444ResponsavelMunicipio});
         if ( (pr_default.getStatus(30) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A444ResponsavelMunicipio)) ) )
            {
               GX_msglist.addItem("Não existe 'Sd Reponsavel Municipio'.", "ForeignKeyNotFound", 1, "RESPONSAVELMUNICIPIO");
               AnyError = 1;
            }
         }
         A446ResponsavelMunicipioUF = T000O61_A446ResponsavelMunicipioUF[0];
         n446ResponsavelMunicipioUF = T000O61_n446ResponsavelMunicipioUF[0];
         A445ResponsavelMunicipioNome = T000O61_A445ResponsavelMunicipioNome[0];
         n445ResponsavelMunicipioNome = T000O61_n445ResponsavelMunicipioNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A446ResponsavelMunicipioUF)+"\""+","+"\""+GXUtil.EncodeJSConstant( A445ResponsavelMunicipioNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(30) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(30);
      }

      protected void gxLoad_44( int A402BancoId )
      {
         /* Using cursor T000O62 */
         pr_default.execute(31, new Object[] {n402BancoId, A402BancoId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            if ( ! ( (0==A402BancoId) ) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "BANCOID");
               AnyError = 1;
            }
         }
         A404BancoCodigo = T000O62_A404BancoCodigo[0];
         n404BancoCodigo = T000O62_n404BancoCodigo[0];
         A403BancoNome = T000O62_A403BancoNome[0];
         n403BancoNome = T000O62_n403BancoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A404BancoCodigo), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A403BancoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(31) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(31);
      }

      protected void gxLoad_45( int A457EspecialidadeId )
      {
         /* Using cursor T000O63 */
         pr_default.execute(32, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            if ( ! ( (0==A457EspecialidadeId) ) )
            {
               GX_msglist.addItem("Não existe 'Especialidade'.", "ForeignKeyNotFound", 1, "ESPECIALIDADEID");
               AnyError = 1;
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(32) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(32);
      }

      protected void gxLoad_46( int A437ResponsavelNacionalidade )
      {
         /* Using cursor T000O64 */
         pr_default.execute(33, new Object[] {n437ResponsavelNacionalidade, A437ResponsavelNacionalidade});
         if ( (pr_default.getStatus(33) == 101) )
         {
            if ( ! ( (0==A437ResponsavelNacionalidade) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Responsavel Nacionalidade'.", "ForeignKeyNotFound", 1, "RESPONSAVELNACIONALIDADE");
               AnyError = 1;
            }
         }
         A438ResponsavelNacionalidadeNome = T000O64_A438ResponsavelNacionalidadeNome[0];
         n438ResponsavelNacionalidadeNome = T000O64_n438ResponsavelNacionalidadeNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A438ResponsavelNacionalidadeNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(33) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(33);
      }

      protected void gxLoad_47( int A484ClienteNacionalidade )
      {
         /* Using cursor T000O65 */
         pr_default.execute(34, new Object[] {n484ClienteNacionalidade, A484ClienteNacionalidade});
         if ( (pr_default.getStatus(34) == 101) )
         {
            if ( ! ( (0==A484ClienteNacionalidade) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Cliente Nacionalidade'.", "ForeignKeyNotFound", 1, "CLIENTENACIONALIDADE");
               AnyError = 1;
            }
         }
         A485ClienteNacionalidadeNome = T000O65_A485ClienteNacionalidadeNome[0];
         n485ClienteNacionalidadeNome = T000O65_n485ClienteNacionalidadeNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A485ClienteNacionalidadeNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(34) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(34);
      }

      protected void gxLoad_48( int A442ResponsavelProfissao )
      {
         /* Using cursor T000O66 */
         pr_default.execute(35, new Object[] {n442ResponsavelProfissao, A442ResponsavelProfissao});
         if ( (pr_default.getStatus(35) == 101) )
         {
            if ( ! ( (0==A442ResponsavelProfissao) ) )
            {
               GX_msglist.addItem("Não existe 'Db Responsavel Profissao'.", "ForeignKeyNotFound", 1, "RESPONSAVELPROFISSAO");
               AnyError = 1;
            }
         }
         A443ResponsavelProfissaoNome = T000O66_A443ResponsavelProfissaoNome[0];
         n443ResponsavelProfissaoNome = T000O66_n443ResponsavelProfissaoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A443ResponsavelProfissaoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(35) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(35);
      }

      protected void gxLoad_49( int A487ClienteProfissao )
      {
         /* Using cursor T000O67 */
         pr_default.execute(36, new Object[] {n487ClienteProfissao, A487ClienteProfissao});
         if ( (pr_default.getStatus(36) == 101) )
         {
            if ( ! ( (0==A487ClienteProfissao) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente Profissao'.", "ForeignKeyNotFound", 1, "CLIENTEPROFISSAO");
               AnyError = 1;
            }
         }
         A488ClienteProfissaoNome = T000O67_A488ClienteProfissaoNome[0];
         n488ClienteProfissaoNome = T000O67_n488ClienteProfissaoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A488ClienteProfissaoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(36) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(36);
      }

      protected void gxLoad_50( int A489ClienteConvenio )
      {
         /* Using cursor T000O68 */
         pr_default.execute(37, new Object[] {n489ClienteConvenio, A489ClienteConvenio});
         if ( (pr_default.getStatus(37) == 101) )
         {
            if ( ! ( (0==A489ClienteConvenio) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente Convenio'.", "ForeignKeyNotFound", 1, "CLIENTECONVENIO");
               AnyError = 1;
            }
         }
         A490ClienteConvenioDescricao = T000O68_A490ClienteConvenioDescricao[0];
         n490ClienteConvenioDescricao = T000O68_n490ClienteConvenioDescricao[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A490ClienteConvenioDescricao)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(37) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(37);
      }

      protected void GetKey0O28( )
      {
         /* Using cursor T000O69 */
         pr_default.execute(38, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(38) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(38);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000O3 */
         pr_default.execute(1, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0O28( 39) ;
            RcdFound28 = 1;
            A168ClienteId = T000O3_A168ClienteId[0];
            n168ClienteId = T000O3_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            A175ClienteCreatedAt = T000O3_A175ClienteCreatedAt[0];
            n175ClienteCreatedAt = T000O3_n175ClienteCreatedAt[0];
            A176ClienteUpdatedAt = T000O3_A176ClienteUpdatedAt[0];
            n176ClienteUpdatedAt = T000O3_n176ClienteUpdatedAt[0];
            A169ClienteDocumento = T000O3_A169ClienteDocumento[0];
            n169ClienteDocumento = T000O3_n169ClienteDocumento[0];
            AssignAttri("", false, "A169ClienteDocumento", A169ClienteDocumento);
            A170ClienteRazaoSocial = T000O3_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = T000O3_n170ClienteRazaoSocial[0];
            AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
            A171ClienteNomeFantasia = T000O3_A171ClienteNomeFantasia[0];
            n171ClienteNomeFantasia = T000O3_n171ClienteNomeFantasia[0];
            AssignAttri("", false, "A171ClienteNomeFantasia", A171ClienteNomeFantasia);
            A459ClienteDataNascimento = T000O3_A459ClienteDataNascimento[0];
            n459ClienteDataNascimento = T000O3_n459ClienteDataNascimento[0];
            A172ClienteTipoPessoa = T000O3_A172ClienteTipoPessoa[0];
            n172ClienteTipoPessoa = T000O3_n172ClienteTipoPessoa[0];
            AssignAttri("", false, "A172ClienteTipoPessoa", A172ClienteTipoPessoa);
            A174ClienteStatus = T000O3_A174ClienteStatus[0];
            n174ClienteStatus = T000O3_n174ClienteStatus[0];
            AssignAttri("", false, "A174ClienteStatus", A174ClienteStatus);
            A177ClienteLogUser = T000O3_A177ClienteLogUser[0];
            n177ClienteLogUser = T000O3_n177ClienteLogUser[0];
            A486ClienteEstadoCivil = T000O3_A486ClienteEstadoCivil[0];
            n486ClienteEstadoCivil = T000O3_n486ClienteEstadoCivil[0];
            A181EnderecoTipo = T000O3_A181EnderecoTipo[0];
            n181EnderecoTipo = T000O3_n181EnderecoTipo[0];
            AssignAttri("", false, "A181EnderecoTipo", A181EnderecoTipo);
            A182EnderecoCEP = T000O3_A182EnderecoCEP[0];
            n182EnderecoCEP = T000O3_n182EnderecoCEP[0];
            AssignAttri("", false, "A182EnderecoCEP", A182EnderecoCEP);
            A183EnderecoLogradouro = T000O3_A183EnderecoLogradouro[0];
            n183EnderecoLogradouro = T000O3_n183EnderecoLogradouro[0];
            AssignAttri("", false, "A183EnderecoLogradouro", A183EnderecoLogradouro);
            A184EnderecoBairro = T000O3_A184EnderecoBairro[0];
            n184EnderecoBairro = T000O3_n184EnderecoBairro[0];
            AssignAttri("", false, "A184EnderecoBairro", A184EnderecoBairro);
            A185EnderecoCidade = T000O3_A185EnderecoCidade[0];
            n185EnderecoCidade = T000O3_n185EnderecoCidade[0];
            AssignAttri("", false, "A185EnderecoCidade", A185EnderecoCidade);
            A190EnderecoNumero = T000O3_A190EnderecoNumero[0];
            n190EnderecoNumero = T000O3_n190EnderecoNumero[0];
            AssignAttri("", false, "A190EnderecoNumero", A190EnderecoNumero);
            A191EnderecoComplemento = T000O3_A191EnderecoComplemento[0];
            n191EnderecoComplemento = T000O3_n191EnderecoComplemento[0];
            AssignAttri("", false, "A191EnderecoComplemento", A191EnderecoComplemento);
            A201ContatoEmail = T000O3_A201ContatoEmail[0];
            n201ContatoEmail = T000O3_n201ContatoEmail[0];
            AssignAttri("", false, "A201ContatoEmail", A201ContatoEmail);
            A198ContatoDDD = T000O3_A198ContatoDDD[0];
            n198ContatoDDD = T000O3_n198ContatoDDD[0];
            AssignAttri("", false, "A198ContatoDDD", ((0==A198ContatoDDD)&&IsIns( )||n198ContatoDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A198ContatoDDD), 4, 0, ".", ""))));
            A199ContatoDDI = T000O3_A199ContatoDDI[0];
            n199ContatoDDI = T000O3_n199ContatoDDI[0];
            AssignAttri("", false, "A199ContatoDDI", ((0==A199ContatoDDI)&&IsIns( )||n199ContatoDDI ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A199ContatoDDI), 4, 0, ".", ""))));
            A200ContatoNumero = T000O3_A200ContatoNumero[0];
            n200ContatoNumero = T000O3_n200ContatoNumero[0];
            AssignAttri("", false, "A200ContatoNumero", ((0==A200ContatoNumero)&&IsIns( )||n200ContatoNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A200ContatoNumero), 18, 0, ".", ""))));
            A202ContatoTelefoneNumero = T000O3_A202ContatoTelefoneNumero[0];
            n202ContatoTelefoneNumero = T000O3_n202ContatoTelefoneNumero[0];
            AssignAttri("", false, "A202ContatoTelefoneNumero", ((0==A202ContatoTelefoneNumero)&&IsIns( )||n202ContatoTelefoneNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A202ContatoTelefoneNumero), 18, 0, ".", ""))));
            A203ContatoTelefoneDDD = T000O3_A203ContatoTelefoneDDD[0];
            n203ContatoTelefoneDDD = T000O3_n203ContatoTelefoneDDD[0];
            AssignAttri("", false, "A203ContatoTelefoneDDD", ((0==A203ContatoTelefoneDDD)&&IsIns( )||n203ContatoTelefoneDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A203ContatoTelefoneDDD), 4, 0, ".", ""))));
            A204ContatoTelefoneDDI = T000O3_A204ContatoTelefoneDDI[0];
            n204ContatoTelefoneDDI = T000O3_n204ContatoTelefoneDDI[0];
            AssignAttri("", false, "A204ContatoTelefoneDDI", ((0==A204ContatoTelefoneDDI)&&IsIns( )||n204ContatoTelefoneDDI ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A204ContatoTelefoneDDI), 4, 0, ".", ""))));
            A421ClienteRG = T000O3_A421ClienteRG[0];
            n421ClienteRG = T000O3_n421ClienteRG[0];
            A537ClienteDepositoTipo = T000O3_A537ClienteDepositoTipo[0];
            n537ClienteDepositoTipo = T000O3_n537ClienteDepositoTipo[0];
            A538ClientePixTipo = T000O3_A538ClientePixTipo[0];
            n538ClientePixTipo = T000O3_n538ClientePixTipo[0];
            A539ClientePix = T000O3_A539ClientePix[0];
            n539ClientePix = T000O3_n539ClientePix[0];
            A400ContaAgencia = T000O3_A400ContaAgencia[0];
            n400ContaAgencia = T000O3_n400ContaAgencia[0];
            A401ContaNumero = T000O3_A401ContaNumero[0];
            n401ContaNumero = T000O3_n401ContaNumero[0];
            A436ResponsavelNome = T000O3_A436ResponsavelNome[0];
            n436ResponsavelNome = T000O3_n436ResponsavelNome[0];
            A439ResponsavelEstadoCivil = T000O3_A439ResponsavelEstadoCivil[0];
            n439ResponsavelEstadoCivil = T000O3_n439ResponsavelEstadoCivil[0];
            A576ResponsavelRG = T000O3_A576ResponsavelRG[0];
            n576ResponsavelRG = T000O3_n576ResponsavelRG[0];
            A447ResponsavelCPF = T000O3_A447ResponsavelCPF[0];
            n447ResponsavelCPF = T000O3_n447ResponsavelCPF[0];
            A448ResponsavelCEP = T000O3_A448ResponsavelCEP[0];
            n448ResponsavelCEP = T000O3_n448ResponsavelCEP[0];
            A449ResponsavelLogradouro = T000O3_A449ResponsavelLogradouro[0];
            n449ResponsavelLogradouro = T000O3_n449ResponsavelLogradouro[0];
            A450ResponsavelBairro = T000O3_A450ResponsavelBairro[0];
            n450ResponsavelBairro = T000O3_n450ResponsavelBairro[0];
            A451ResponsavelCidade = T000O3_A451ResponsavelCidade[0];
            n451ResponsavelCidade = T000O3_n451ResponsavelCidade[0];
            A452ResponsavelLogradouroNumero = T000O3_A452ResponsavelLogradouroNumero[0];
            n452ResponsavelLogradouroNumero = T000O3_n452ResponsavelLogradouroNumero[0];
            A453ResponsavelComplemento = T000O3_A453ResponsavelComplemento[0];
            n453ResponsavelComplemento = T000O3_n453ResponsavelComplemento[0];
            A454ResponsavelDDD = T000O3_A454ResponsavelDDD[0];
            n454ResponsavelDDD = T000O3_n454ResponsavelDDD[0];
            A455ResponsavelNumero = T000O3_A455ResponsavelNumero[0];
            n455ResponsavelNumero = T000O3_n455ResponsavelNumero[0];
            A456ResponsavelEmail = T000O3_A456ResponsavelEmail[0];
            n456ResponsavelEmail = T000O3_n456ResponsavelEmail[0];
            A884ClienteSituacao = T000O3_A884ClienteSituacao[0];
            n884ClienteSituacao = T000O3_n884ClienteSituacao[0];
            A885ResponsavelCargo = T000O3_A885ResponsavelCargo[0];
            n885ResponsavelCargo = T000O3_n885ResponsavelCargo[0];
            A1039ClienteTipoRisco = T000O3_A1039ClienteTipoRisco[0];
            A192TipoClienteId = T000O3_A192TipoClienteId[0];
            n192TipoClienteId = T000O3_n192TipoClienteId[0];
            A186MunicipioCodigo = T000O3_A186MunicipioCodigo[0];
            n186MunicipioCodigo = T000O3_n186MunicipioCodigo[0];
            AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
            A444ResponsavelMunicipio = T000O3_A444ResponsavelMunicipio[0];
            n444ResponsavelMunicipio = T000O3_n444ResponsavelMunicipio[0];
            A402BancoId = T000O3_A402BancoId[0];
            n402BancoId = T000O3_n402BancoId[0];
            A457EspecialidadeId = T000O3_A457EspecialidadeId[0];
            n457EspecialidadeId = T000O3_n457EspecialidadeId[0];
            A437ResponsavelNacionalidade = T000O3_A437ResponsavelNacionalidade[0];
            n437ResponsavelNacionalidade = T000O3_n437ResponsavelNacionalidade[0];
            A484ClienteNacionalidade = T000O3_A484ClienteNacionalidade[0];
            n484ClienteNacionalidade = T000O3_n484ClienteNacionalidade[0];
            A442ResponsavelProfissao = T000O3_A442ResponsavelProfissao[0];
            n442ResponsavelProfissao = T000O3_n442ResponsavelProfissao[0];
            A487ClienteProfissao = T000O3_A487ClienteProfissao[0];
            n487ClienteProfissao = T000O3_n487ClienteProfissao[0];
            A489ClienteConvenio = T000O3_A489ClienteConvenio[0];
            n489ClienteConvenio = T000O3_n489ClienteConvenio[0];
            Z168ClienteId = A168ClienteId;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0O28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey0O28( ) ;
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0O28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0O28( ) ;
         if ( RcdFound28 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound28 = 0;
         /* Using cursor T000O70 */
         pr_default.execute(39, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(39) != 101) )
         {
            while ( (pr_default.getStatus(39) != 101) && ( ( T000O70_A168ClienteId[0] < A168ClienteId ) ) )
            {
               pr_default.readNext(39);
            }
            if ( (pr_default.getStatus(39) != 101) && ( ( T000O70_A168ClienteId[0] > A168ClienteId ) ) )
            {
               A168ClienteId = T000O70_A168ClienteId[0];
               n168ClienteId = T000O70_n168ClienteId[0];
               AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(39);
      }

      protected void move_previous( )
      {
         RcdFound28 = 0;
         /* Using cursor T000O71 */
         pr_default.execute(40, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(40) != 101) )
         {
            while ( (pr_default.getStatus(40) != 101) && ( ( T000O71_A168ClienteId[0] > A168ClienteId ) ) )
            {
               pr_default.readNext(40);
            }
            if ( (pr_default.getStatus(40) != 101) && ( ( T000O71_A168ClienteId[0] < A168ClienteId ) ) )
            {
               A168ClienteId = T000O71_A168ClienteId[0];
               n168ClienteId = T000O71_n168ClienteId[0];
               AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
               RcdFound28 = 1;
            }
         }
         pr_default.close(40);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0O28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtClienteDocumento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0O28( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( A168ClienteId != Z168ClienteId )
               {
                  A168ClienteId = Z168ClienteId;
                  n168ClienteId = false;
                  AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtClienteDocumento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0O28( ) ;
                  GX_FocusControl = edtClienteDocumento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A168ClienteId != Z168ClienteId )
               {
                  /* Insert record */
                  GX_FocusControl = edtClienteDocumento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0O28( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLIENTEID");
                     AnyError = 1;
                     GX_FocusControl = edtClienteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtClienteDocumento_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0O28( ) ;
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
         if ( A168ClienteId != Z168ClienteId )
         {
            A168ClienteId = Z168ClienteId;
            n168ClienteId = false;
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtClienteDocumento_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0O28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000O2 */
            pr_default.execute(0, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z175ClienteCreatedAt != T000O2_A175ClienteCreatedAt[0] ) || ( Z176ClienteUpdatedAt != T000O2_A176ClienteUpdatedAt[0] ) || ( StringUtil.StrCmp(Z169ClienteDocumento, T000O2_A169ClienteDocumento[0]) != 0 ) || ( StringUtil.StrCmp(Z170ClienteRazaoSocial, T000O2_A170ClienteRazaoSocial[0]) != 0 ) || ( StringUtil.StrCmp(Z171ClienteNomeFantasia, T000O2_A171ClienteNomeFantasia[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z459ClienteDataNascimento ) != DateTimeUtil.ResetTime ( T000O2_A459ClienteDataNascimento[0] ) ) || ( StringUtil.StrCmp(Z172ClienteTipoPessoa, T000O2_A172ClienteTipoPessoa[0]) != 0 ) || ( Z174ClienteStatus != T000O2_A174ClienteStatus[0] ) || ( Z177ClienteLogUser != T000O2_A177ClienteLogUser[0] ) || ( StringUtil.StrCmp(Z486ClienteEstadoCivil, T000O2_A486ClienteEstadoCivil[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z181EnderecoTipo, T000O2_A181EnderecoTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z182EnderecoCEP, T000O2_A182EnderecoCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z183EnderecoLogradouro, T000O2_A183EnderecoLogradouro[0]) != 0 ) || ( StringUtil.StrCmp(Z184EnderecoBairro, T000O2_A184EnderecoBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z185EnderecoCidade, T000O2_A185EnderecoCidade[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z190EnderecoNumero, T000O2_A190EnderecoNumero[0]) != 0 ) || ( StringUtil.StrCmp(Z191EnderecoComplemento, T000O2_A191EnderecoComplemento[0]) != 0 ) || ( StringUtil.StrCmp(Z201ContatoEmail, T000O2_A201ContatoEmail[0]) != 0 ) || ( Z198ContatoDDD != T000O2_A198ContatoDDD[0] ) || ( Z199ContatoDDI != T000O2_A199ContatoDDI[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z200ContatoNumero != T000O2_A200ContatoNumero[0] ) || ( Z202ContatoTelefoneNumero != T000O2_A202ContatoTelefoneNumero[0] ) || ( Z203ContatoTelefoneDDD != T000O2_A203ContatoTelefoneDDD[0] ) || ( Z204ContatoTelefoneDDI != T000O2_A204ContatoTelefoneDDI[0] ) || ( Z421ClienteRG != T000O2_A421ClienteRG[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z537ClienteDepositoTipo, T000O2_A537ClienteDepositoTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z538ClientePixTipo, T000O2_A538ClientePixTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z539ClientePix, T000O2_A539ClientePix[0]) != 0 ) || ( StringUtil.StrCmp(Z400ContaAgencia, T000O2_A400ContaAgencia[0]) != 0 ) || ( StringUtil.StrCmp(Z401ContaNumero, T000O2_A401ContaNumero[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z436ResponsavelNome, T000O2_A436ResponsavelNome[0]) != 0 ) || ( StringUtil.StrCmp(Z439ResponsavelEstadoCivil, T000O2_A439ResponsavelEstadoCivil[0]) != 0 ) || ( Z576ResponsavelRG != T000O2_A576ResponsavelRG[0] ) || ( StringUtil.StrCmp(Z447ResponsavelCPF, T000O2_A447ResponsavelCPF[0]) != 0 ) || ( StringUtil.StrCmp(Z448ResponsavelCEP, T000O2_A448ResponsavelCEP[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z449ResponsavelLogradouro, T000O2_A449ResponsavelLogradouro[0]) != 0 ) || ( StringUtil.StrCmp(Z450ResponsavelBairro, T000O2_A450ResponsavelBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z451ResponsavelCidade, T000O2_A451ResponsavelCidade[0]) != 0 ) || ( Z452ResponsavelLogradouroNumero != T000O2_A452ResponsavelLogradouroNumero[0] ) || ( StringUtil.StrCmp(Z453ResponsavelComplemento, T000O2_A453ResponsavelComplemento[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z454ResponsavelDDD != T000O2_A454ResponsavelDDD[0] ) || ( Z455ResponsavelNumero != T000O2_A455ResponsavelNumero[0] ) || ( StringUtil.StrCmp(Z456ResponsavelEmail, T000O2_A456ResponsavelEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z884ClienteSituacao, T000O2_A884ClienteSituacao[0]) != 0 ) || ( StringUtil.StrCmp(Z885ResponsavelCargo, T000O2_A885ResponsavelCargo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1039ClienteTipoRisco, T000O2_A1039ClienteTipoRisco[0]) != 0 ) || ( Z192TipoClienteId != T000O2_A192TipoClienteId[0] ) || ( StringUtil.StrCmp(Z186MunicipioCodigo, T000O2_A186MunicipioCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z444ResponsavelMunicipio, T000O2_A444ResponsavelMunicipio[0]) != 0 ) || ( Z402BancoId != T000O2_A402BancoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z457EspecialidadeId != T000O2_A457EspecialidadeId[0] ) || ( Z437ResponsavelNacionalidade != T000O2_A437ResponsavelNacionalidade[0] ) || ( Z484ClienteNacionalidade != T000O2_A484ClienteNacionalidade[0] ) || ( Z442ResponsavelProfissao != T000O2_A442ResponsavelProfissao[0] ) || ( Z487ClienteProfissao != T000O2_A487ClienteProfissao[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z489ClienteConvenio != T000O2_A489ClienteConvenio[0] ) )
            {
               if ( Z175ClienteCreatedAt != T000O2_A175ClienteCreatedAt[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteCreatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z175ClienteCreatedAt);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A175ClienteCreatedAt[0]);
               }
               if ( Z176ClienteUpdatedAt != T000O2_A176ClienteUpdatedAt[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteUpdatedAt");
                  GXUtil.WriteLogRaw("Old: ",Z176ClienteUpdatedAt);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A176ClienteUpdatedAt[0]);
               }
               if ( StringUtil.StrCmp(Z169ClienteDocumento, T000O2_A169ClienteDocumento[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteDocumento");
                  GXUtil.WriteLogRaw("Old: ",Z169ClienteDocumento);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A169ClienteDocumento[0]);
               }
               if ( StringUtil.StrCmp(Z170ClienteRazaoSocial, T000O2_A170ClienteRazaoSocial[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteRazaoSocial");
                  GXUtil.WriteLogRaw("Old: ",Z170ClienteRazaoSocial);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A170ClienteRazaoSocial[0]);
               }
               if ( StringUtil.StrCmp(Z171ClienteNomeFantasia, T000O2_A171ClienteNomeFantasia[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteNomeFantasia");
                  GXUtil.WriteLogRaw("Old: ",Z171ClienteNomeFantasia);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A171ClienteNomeFantasia[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z459ClienteDataNascimento ) != DateTimeUtil.ResetTime ( T000O2_A459ClienteDataNascimento[0] ) )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteDataNascimento");
                  GXUtil.WriteLogRaw("Old: ",Z459ClienteDataNascimento);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A459ClienteDataNascimento[0]);
               }
               if ( StringUtil.StrCmp(Z172ClienteTipoPessoa, T000O2_A172ClienteTipoPessoa[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteTipoPessoa");
                  GXUtil.WriteLogRaw("Old: ",Z172ClienteTipoPessoa);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A172ClienteTipoPessoa[0]);
               }
               if ( Z174ClienteStatus != T000O2_A174ClienteStatus[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteStatus");
                  GXUtil.WriteLogRaw("Old: ",Z174ClienteStatus);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A174ClienteStatus[0]);
               }
               if ( Z177ClienteLogUser != T000O2_A177ClienteLogUser[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteLogUser");
                  GXUtil.WriteLogRaw("Old: ",Z177ClienteLogUser);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A177ClienteLogUser[0]);
               }
               if ( StringUtil.StrCmp(Z486ClienteEstadoCivil, T000O2_A486ClienteEstadoCivil[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteEstadoCivil");
                  GXUtil.WriteLogRaw("Old: ",Z486ClienteEstadoCivil);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A486ClienteEstadoCivil[0]);
               }
               if ( StringUtil.StrCmp(Z181EnderecoTipo, T000O2_A181EnderecoTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"EnderecoTipo");
                  GXUtil.WriteLogRaw("Old: ",Z181EnderecoTipo);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A181EnderecoTipo[0]);
               }
               if ( StringUtil.StrCmp(Z182EnderecoCEP, T000O2_A182EnderecoCEP[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"EnderecoCEP");
                  GXUtil.WriteLogRaw("Old: ",Z182EnderecoCEP);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A182EnderecoCEP[0]);
               }
               if ( StringUtil.StrCmp(Z183EnderecoLogradouro, T000O2_A183EnderecoLogradouro[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"EnderecoLogradouro");
                  GXUtil.WriteLogRaw("Old: ",Z183EnderecoLogradouro);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A183EnderecoLogradouro[0]);
               }
               if ( StringUtil.StrCmp(Z184EnderecoBairro, T000O2_A184EnderecoBairro[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"EnderecoBairro");
                  GXUtil.WriteLogRaw("Old: ",Z184EnderecoBairro);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A184EnderecoBairro[0]);
               }
               if ( StringUtil.StrCmp(Z185EnderecoCidade, T000O2_A185EnderecoCidade[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"EnderecoCidade");
                  GXUtil.WriteLogRaw("Old: ",Z185EnderecoCidade);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A185EnderecoCidade[0]);
               }
               if ( StringUtil.StrCmp(Z190EnderecoNumero, T000O2_A190EnderecoNumero[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"EnderecoNumero");
                  GXUtil.WriteLogRaw("Old: ",Z190EnderecoNumero);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A190EnderecoNumero[0]);
               }
               if ( StringUtil.StrCmp(Z191EnderecoComplemento, T000O2_A191EnderecoComplemento[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"EnderecoComplemento");
                  GXUtil.WriteLogRaw("Old: ",Z191EnderecoComplemento);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A191EnderecoComplemento[0]);
               }
               if ( StringUtil.StrCmp(Z201ContatoEmail, T000O2_A201ContatoEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ContatoEmail");
                  GXUtil.WriteLogRaw("Old: ",Z201ContatoEmail);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A201ContatoEmail[0]);
               }
               if ( Z198ContatoDDD != T000O2_A198ContatoDDD[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ContatoDDD");
                  GXUtil.WriteLogRaw("Old: ",Z198ContatoDDD);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A198ContatoDDD[0]);
               }
               if ( Z199ContatoDDI != T000O2_A199ContatoDDI[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ContatoDDI");
                  GXUtil.WriteLogRaw("Old: ",Z199ContatoDDI);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A199ContatoDDI[0]);
               }
               if ( Z200ContatoNumero != T000O2_A200ContatoNumero[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ContatoNumero");
                  GXUtil.WriteLogRaw("Old: ",Z200ContatoNumero);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A200ContatoNumero[0]);
               }
               if ( Z202ContatoTelefoneNumero != T000O2_A202ContatoTelefoneNumero[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ContatoTelefoneNumero");
                  GXUtil.WriteLogRaw("Old: ",Z202ContatoTelefoneNumero);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A202ContatoTelefoneNumero[0]);
               }
               if ( Z203ContatoTelefoneDDD != T000O2_A203ContatoTelefoneDDD[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ContatoTelefoneDDD");
                  GXUtil.WriteLogRaw("Old: ",Z203ContatoTelefoneDDD);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A203ContatoTelefoneDDD[0]);
               }
               if ( Z204ContatoTelefoneDDI != T000O2_A204ContatoTelefoneDDI[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ContatoTelefoneDDI");
                  GXUtil.WriteLogRaw("Old: ",Z204ContatoTelefoneDDI);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A204ContatoTelefoneDDI[0]);
               }
               if ( Z421ClienteRG != T000O2_A421ClienteRG[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteRG");
                  GXUtil.WriteLogRaw("Old: ",Z421ClienteRG);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A421ClienteRG[0]);
               }
               if ( StringUtil.StrCmp(Z537ClienteDepositoTipo, T000O2_A537ClienteDepositoTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteDepositoTipo");
                  GXUtil.WriteLogRaw("Old: ",Z537ClienteDepositoTipo);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A537ClienteDepositoTipo[0]);
               }
               if ( StringUtil.StrCmp(Z538ClientePixTipo, T000O2_A538ClientePixTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClientePixTipo");
                  GXUtil.WriteLogRaw("Old: ",Z538ClientePixTipo);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A538ClientePixTipo[0]);
               }
               if ( StringUtil.StrCmp(Z539ClientePix, T000O2_A539ClientePix[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClientePix");
                  GXUtil.WriteLogRaw("Old: ",Z539ClientePix);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A539ClientePix[0]);
               }
               if ( StringUtil.StrCmp(Z400ContaAgencia, T000O2_A400ContaAgencia[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ContaAgencia");
                  GXUtil.WriteLogRaw("Old: ",Z400ContaAgencia);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A400ContaAgencia[0]);
               }
               if ( StringUtil.StrCmp(Z401ContaNumero, T000O2_A401ContaNumero[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ContaNumero");
                  GXUtil.WriteLogRaw("Old: ",Z401ContaNumero);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A401ContaNumero[0]);
               }
               if ( StringUtil.StrCmp(Z436ResponsavelNome, T000O2_A436ResponsavelNome[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelNome");
                  GXUtil.WriteLogRaw("Old: ",Z436ResponsavelNome);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A436ResponsavelNome[0]);
               }
               if ( StringUtil.StrCmp(Z439ResponsavelEstadoCivil, T000O2_A439ResponsavelEstadoCivil[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelEstadoCivil");
                  GXUtil.WriteLogRaw("Old: ",Z439ResponsavelEstadoCivil);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A439ResponsavelEstadoCivil[0]);
               }
               if ( Z576ResponsavelRG != T000O2_A576ResponsavelRG[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelRG");
                  GXUtil.WriteLogRaw("Old: ",Z576ResponsavelRG);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A576ResponsavelRG[0]);
               }
               if ( StringUtil.StrCmp(Z447ResponsavelCPF, T000O2_A447ResponsavelCPF[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelCPF");
                  GXUtil.WriteLogRaw("Old: ",Z447ResponsavelCPF);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A447ResponsavelCPF[0]);
               }
               if ( StringUtil.StrCmp(Z448ResponsavelCEP, T000O2_A448ResponsavelCEP[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelCEP");
                  GXUtil.WriteLogRaw("Old: ",Z448ResponsavelCEP);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A448ResponsavelCEP[0]);
               }
               if ( StringUtil.StrCmp(Z449ResponsavelLogradouro, T000O2_A449ResponsavelLogradouro[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelLogradouro");
                  GXUtil.WriteLogRaw("Old: ",Z449ResponsavelLogradouro);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A449ResponsavelLogradouro[0]);
               }
               if ( StringUtil.StrCmp(Z450ResponsavelBairro, T000O2_A450ResponsavelBairro[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelBairro");
                  GXUtil.WriteLogRaw("Old: ",Z450ResponsavelBairro);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A450ResponsavelBairro[0]);
               }
               if ( StringUtil.StrCmp(Z451ResponsavelCidade, T000O2_A451ResponsavelCidade[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelCidade");
                  GXUtil.WriteLogRaw("Old: ",Z451ResponsavelCidade);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A451ResponsavelCidade[0]);
               }
               if ( Z452ResponsavelLogradouroNumero != T000O2_A452ResponsavelLogradouroNumero[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelLogradouroNumero");
                  GXUtil.WriteLogRaw("Old: ",Z452ResponsavelLogradouroNumero);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A452ResponsavelLogradouroNumero[0]);
               }
               if ( StringUtil.StrCmp(Z453ResponsavelComplemento, T000O2_A453ResponsavelComplemento[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelComplemento");
                  GXUtil.WriteLogRaw("Old: ",Z453ResponsavelComplemento);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A453ResponsavelComplemento[0]);
               }
               if ( Z454ResponsavelDDD != T000O2_A454ResponsavelDDD[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelDDD");
                  GXUtil.WriteLogRaw("Old: ",Z454ResponsavelDDD);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A454ResponsavelDDD[0]);
               }
               if ( Z455ResponsavelNumero != T000O2_A455ResponsavelNumero[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelNumero");
                  GXUtil.WriteLogRaw("Old: ",Z455ResponsavelNumero);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A455ResponsavelNumero[0]);
               }
               if ( StringUtil.StrCmp(Z456ResponsavelEmail, T000O2_A456ResponsavelEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelEmail");
                  GXUtil.WriteLogRaw("Old: ",Z456ResponsavelEmail);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A456ResponsavelEmail[0]);
               }
               if ( StringUtil.StrCmp(Z884ClienteSituacao, T000O2_A884ClienteSituacao[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteSituacao");
                  GXUtil.WriteLogRaw("Old: ",Z884ClienteSituacao);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A884ClienteSituacao[0]);
               }
               if ( StringUtil.StrCmp(Z885ResponsavelCargo, T000O2_A885ResponsavelCargo[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelCargo");
                  GXUtil.WriteLogRaw("Old: ",Z885ResponsavelCargo);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A885ResponsavelCargo[0]);
               }
               if ( StringUtil.StrCmp(Z1039ClienteTipoRisco, T000O2_A1039ClienteTipoRisco[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteTipoRisco");
                  GXUtil.WriteLogRaw("Old: ",Z1039ClienteTipoRisco);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A1039ClienteTipoRisco[0]);
               }
               if ( Z192TipoClienteId != T000O2_A192TipoClienteId[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"TipoClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z192TipoClienteId);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A192TipoClienteId[0]);
               }
               if ( StringUtil.StrCmp(Z186MunicipioCodigo, T000O2_A186MunicipioCodigo[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"MunicipioCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z186MunicipioCodigo);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A186MunicipioCodigo[0]);
               }
               if ( StringUtil.StrCmp(Z444ResponsavelMunicipio, T000O2_A444ResponsavelMunicipio[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelMunicipio");
                  GXUtil.WriteLogRaw("Old: ",Z444ResponsavelMunicipio);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A444ResponsavelMunicipio[0]);
               }
               if ( Z402BancoId != T000O2_A402BancoId[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"BancoId");
                  GXUtil.WriteLogRaw("Old: ",Z402BancoId);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A402BancoId[0]);
               }
               if ( Z457EspecialidadeId != T000O2_A457EspecialidadeId[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"EspecialidadeId");
                  GXUtil.WriteLogRaw("Old: ",Z457EspecialidadeId);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A457EspecialidadeId[0]);
               }
               if ( Z437ResponsavelNacionalidade != T000O2_A437ResponsavelNacionalidade[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelNacionalidade");
                  GXUtil.WriteLogRaw("Old: ",Z437ResponsavelNacionalidade);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A437ResponsavelNacionalidade[0]);
               }
               if ( Z484ClienteNacionalidade != T000O2_A484ClienteNacionalidade[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteNacionalidade");
                  GXUtil.WriteLogRaw("Old: ",Z484ClienteNacionalidade);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A484ClienteNacionalidade[0]);
               }
               if ( Z442ResponsavelProfissao != T000O2_A442ResponsavelProfissao[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ResponsavelProfissao");
                  GXUtil.WriteLogRaw("Old: ",Z442ResponsavelProfissao);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A442ResponsavelProfissao[0]);
               }
               if ( Z487ClienteProfissao != T000O2_A487ClienteProfissao[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteProfissao");
                  GXUtil.WriteLogRaw("Old: ",Z487ClienteProfissao);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A487ClienteProfissao[0]);
               }
               if ( Z489ClienteConvenio != T000O2_A489ClienteConvenio[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteConvenio");
                  GXUtil.WriteLogRaw("Old: ",Z489ClienteConvenio);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A489ClienteConvenio[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Cliente"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0O28( )
      {
         BeforeValidate0O28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0O28( 0) ;
            CheckOptimisticConcurrency0O28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0O28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000O72 */
                     pr_default.execute(41, new Object[] {n175ClienteCreatedAt, A175ClienteCreatedAt, n176ClienteUpdatedAt, A176ClienteUpdatedAt, n169ClienteDocumento, A169ClienteDocumento, n170ClienteRazaoSocial, A170ClienteRazaoSocial, n171ClienteNomeFantasia, A171ClienteNomeFantasia, n459ClienteDataNascimento, A459ClienteDataNascimento, n172ClienteTipoPessoa, A172ClienteTipoPessoa, n174ClienteStatus, A174ClienteStatus, n177ClienteLogUser, A177ClienteLogUser, n486ClienteEstadoCivil, A486ClienteEstadoCivil, n181EnderecoTipo, A181EnderecoTipo, n182EnderecoCEP, A182EnderecoCEP, n183EnderecoLogradouro, A183EnderecoLogradouro, n184EnderecoBairro, A184EnderecoBairro, n185EnderecoCidade, A185EnderecoCidade, n190EnderecoNumero, A190EnderecoNumero, n191EnderecoComplemento, A191EnderecoComplemento, n201ContatoEmail, A201ContatoEmail, n198ContatoDDD, A198ContatoDDD, n199ContatoDDI, A199ContatoDDI, n200ContatoNumero, A200ContatoNumero, n202ContatoTelefoneNumero, A202ContatoTelefoneNumero, n203ContatoTelefoneDDD, A203ContatoTelefoneDDD, n204ContatoTelefoneDDI, A204ContatoTelefoneDDI, n421ClienteRG, A421ClienteRG, n537ClienteDepositoTipo, A537ClienteDepositoTipo, n538ClientePixTipo, A538ClientePixTipo, n539ClientePix, A539ClientePix, n400ContaAgencia, A400ContaAgencia, n401ContaNumero, A401ContaNumero, n436ResponsavelNome, A436ResponsavelNome, n439ResponsavelEstadoCivil, A439ResponsavelEstadoCivil, n576ResponsavelRG, A576ResponsavelRG, n447ResponsavelCPF, A447ResponsavelCPF, n448ResponsavelCEP, A448ResponsavelCEP, n449ResponsavelLogradouro, A449ResponsavelLogradouro, n450ResponsavelBairro, A450ResponsavelBairro, n451ResponsavelCidade, A451ResponsavelCidade, n452ResponsavelLogradouroNumero, A452ResponsavelLogradouroNumero, n453ResponsavelComplemento, A453ResponsavelComplemento, n454ResponsavelDDD, A454ResponsavelDDD, n455ResponsavelNumero, A455ResponsavelNumero, n456ResponsavelEmail, A456ResponsavelEmail, n884ClienteSituacao, A884ClienteSituacao, n885ResponsavelCargo, A885ResponsavelCargo, A1039ClienteTipoRisco, n192TipoClienteId, A192TipoClienteId, n186MunicipioCodigo, A186MunicipioCodigo, n444ResponsavelMunicipio, A444ResponsavelMunicipio, n402BancoId, A402BancoId, n457EspecialidadeId, A457EspecialidadeId, n437ResponsavelNacionalidade, A437ResponsavelNacionalidade, n484ClienteNacionalidade, A484ClienteNacionalidade, n442ResponsavelProfissao, A442ResponsavelProfissao, n487ClienteProfissao, A487ClienteProfissao, n489ClienteConvenio, A489ClienteConvenio});
                     pr_default.close(41);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000O73 */
                     pr_default.execute(42);
                     A168ClienteId = T000O73_A168ClienteId[0];
                     n168ClienteId = T000O73_n168ClienteId[0];
                     AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
                     pr_default.close(42);
                     pr_default.SmartCacheProvider.SetUpdated("Cliente");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0O0( ) ;
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
               Load0O28( ) ;
            }
            EndLevel0O28( ) ;
         }
         CloseExtendedTableCursors0O28( ) ;
      }

      protected void Update0O28( )
      {
         BeforeValidate0O28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0O28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000O74 */
                     pr_default.execute(43, new Object[] {n175ClienteCreatedAt, A175ClienteCreatedAt, n176ClienteUpdatedAt, A176ClienteUpdatedAt, n169ClienteDocumento, A169ClienteDocumento, n170ClienteRazaoSocial, A170ClienteRazaoSocial, n171ClienteNomeFantasia, A171ClienteNomeFantasia, n459ClienteDataNascimento, A459ClienteDataNascimento, n172ClienteTipoPessoa, A172ClienteTipoPessoa, n174ClienteStatus, A174ClienteStatus, n177ClienteLogUser, A177ClienteLogUser, n486ClienteEstadoCivil, A486ClienteEstadoCivil, n181EnderecoTipo, A181EnderecoTipo, n182EnderecoCEP, A182EnderecoCEP, n183EnderecoLogradouro, A183EnderecoLogradouro, n184EnderecoBairro, A184EnderecoBairro, n185EnderecoCidade, A185EnderecoCidade, n190EnderecoNumero, A190EnderecoNumero, n191EnderecoComplemento, A191EnderecoComplemento, n201ContatoEmail, A201ContatoEmail, n198ContatoDDD, A198ContatoDDD, n199ContatoDDI, A199ContatoDDI, n200ContatoNumero, A200ContatoNumero, n202ContatoTelefoneNumero, A202ContatoTelefoneNumero, n203ContatoTelefoneDDD, A203ContatoTelefoneDDD, n204ContatoTelefoneDDI, A204ContatoTelefoneDDI, n421ClienteRG, A421ClienteRG, n537ClienteDepositoTipo, A537ClienteDepositoTipo, n538ClientePixTipo, A538ClientePixTipo, n539ClientePix, A539ClientePix, n400ContaAgencia, A400ContaAgencia, n401ContaNumero, A401ContaNumero, n436ResponsavelNome, A436ResponsavelNome, n439ResponsavelEstadoCivil, A439ResponsavelEstadoCivil, n576ResponsavelRG, A576ResponsavelRG, n447ResponsavelCPF, A447ResponsavelCPF, n448ResponsavelCEP, A448ResponsavelCEP, n449ResponsavelLogradouro, A449ResponsavelLogradouro, n450ResponsavelBairro, A450ResponsavelBairro, n451ResponsavelCidade, A451ResponsavelCidade, n452ResponsavelLogradouroNumero, A452ResponsavelLogradouroNumero, n453ResponsavelComplemento, A453ResponsavelComplemento, n454ResponsavelDDD, A454ResponsavelDDD, n455ResponsavelNumero, A455ResponsavelNumero, n456ResponsavelEmail, A456ResponsavelEmail, n884ClienteSituacao, A884ClienteSituacao, n885ResponsavelCargo, A885ResponsavelCargo, A1039ClienteTipoRisco, n192TipoClienteId, A192TipoClienteId, n186MunicipioCodigo, A186MunicipioCodigo, n444ResponsavelMunicipio, A444ResponsavelMunicipio, n402BancoId, A402BancoId, n457EspecialidadeId, A457EspecialidadeId, n437ResponsavelNacionalidade, A437ResponsavelNacionalidade, n484ClienteNacionalidade, A484ClienteNacionalidade, n442ResponsavelProfissao, A442ResponsavelProfissao, n487ClienteProfissao, A487ClienteProfissao, n489ClienteConvenio, A489ClienteConvenio, n168ClienteId, A168ClienteId});
                     pr_default.close(43);
                     pr_default.SmartCacheProvider.SetUpdated("Cliente");
                     if ( (pr_default.getStatus(43) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0O28( ) ;
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
            EndLevel0O28( ) ;
         }
         CloseExtendedTableCursors0O28( ) ;
      }

      protected void DeferredUpdate0O28( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0O28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0O28( ) ;
            AfterConfirm0O28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0O28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000O75 */
                  pr_default.execute(44, new Object[] {n168ClienteId, A168ClienteId});
                  pr_default.close(44);
                  pr_default.SmartCacheProvider.SetUpdated("Cliente");
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0O28( ) ;
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0O28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000O77 */
            pr_default.execute(45, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(45) != 101) )
            {
               A608SecUserId_F = T000O77_A608SecUserId_F[0];
               n608SecUserId_F = T000O77_n608SecUserId_F[0];
            }
            else
            {
               A608SecUserId_F = 0;
               n608SecUserId_F = false;
               AssignAttri("", false, "A608SecUserId_F", StringUtil.LTrimStr( (decimal)(A608SecUserId_F), 4, 0));
            }
            pr_default.close(45);
            /* Using cursor T000O79 */
            pr_default.execute(46, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(46) != 101) )
            {
               A309ClienteQtdTitulos_F = T000O79_A309ClienteQtdTitulos_F[0];
               n309ClienteQtdTitulos_F = T000O79_n309ClienteQtdTitulos_F[0];
            }
            else
            {
               A309ClienteQtdTitulos_F = 0;
               n309ClienteQtdTitulos_F = false;
               AssignAttri("", false, "A309ClienteQtdTitulos_F", StringUtil.LTrimStr( (decimal)(A309ClienteQtdTitulos_F), 9, 0));
            }
            pr_default.close(46);
            /* Using cursor T000O83 */
            pr_default.execute(47, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(47) != 101) )
            {
               A310ClienteValorAPagar_F = T000O83_A310ClienteValorAPagar_F[0];
               n310ClienteValorAPagar_F = T000O83_n310ClienteValorAPagar_F[0];
            }
            else
            {
               A310ClienteValorAPagar_F = 0;
               n310ClienteValorAPagar_F = false;
               AssignAttri("", false, "A310ClienteValorAPagar_F", StringUtil.LTrimStr( A310ClienteValorAPagar_F, 18, 2));
            }
            pr_default.close(47);
            /* Using cursor T000O86 */
            pr_default.execute(48, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(48) != 101) )
            {
               A311ClienteValorAReceber_F = T000O86_A311ClienteValorAReceber_F[0];
               n311ClienteValorAReceber_F = T000O86_n311ClienteValorAReceber_F[0];
            }
            else
            {
               A311ClienteValorAReceber_F = 0;
               n311ClienteValorAReceber_F = false;
               AssignAttri("", false, "A311ClienteValorAReceber_F", StringUtil.LTrimStr( A311ClienteValorAReceber_F, 18, 2));
            }
            pr_default.close(48);
            /* Using cursor T000O88 */
            pr_default.execute(49, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(49) != 101) )
            {
               A780SerasaUltimaData_F = T000O88_A780SerasaUltimaData_F[0];
               A732SerasaConsultas_F = T000O88_A732SerasaConsultas_F[0];
            }
            else
            {
               A732SerasaConsultas_F = 0;
               AssignAttri("", false, "A732SerasaConsultas_F", StringUtil.LTrimStr( (decimal)(A732SerasaConsultas_F), 4, 0));
               A780SerasaUltimaData_F = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A780SerasaUltimaData_F", context.localUtil.TToC( A780SerasaUltimaData_F, 8, 5, 0, 3, "/", ":", " "));
            }
            pr_default.close(49);
            /* Using cursor T000O90 */
            pr_default.execute(50, new Object[] {A780SerasaUltimaData_F, n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(50) != 101) )
            {
               A781SerasaScoreUltimaData_F = T000O90_A781SerasaScoreUltimaData_F[0];
               A785SerasaUltimoValorRecomendado_F = T000O90_A785SerasaUltimoValorRecomendado_F[0];
            }
            else
            {
               A781SerasaScoreUltimaData_F = 0;
               AssignAttri("", false, "A781SerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A781SerasaScoreUltimaData_F), 4, 0));
               A785SerasaUltimoValorRecomendado_F = 0;
               AssignAttri("", false, "A785SerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A785SerasaUltimoValorRecomendado_F, 18, 2));
            }
            pr_default.close(50);
            /* Using cursor T000O92 */
            pr_default.execute(51, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(51) != 101) )
            {
               A1031RelacionamentoSacado = T000O92_A1031RelacionamentoSacado[0];
               n1031RelacionamentoSacado = T000O92_n1031RelacionamentoSacado[0];
            }
            else
            {
               A1031RelacionamentoSacado = 0;
               n1031RelacionamentoSacado = false;
               AssignAttri("", false, "A1031RelacionamentoSacado", StringUtil.LTrimStr( (decimal)(A1031RelacionamentoSacado), 4, 0));
            }
            pr_default.close(51);
            A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
            AssignAttri("", false, "A1030ClienteSacado", A1030ClienteSacado);
            /* Using cursor T000O93 */
            pr_default.execute(52, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
            A187MunicipioNome = T000O93_A187MunicipioNome[0];
            n187MunicipioNome = T000O93_n187MunicipioNome[0];
            A189MunicipioUF = T000O93_A189MunicipioUF[0];
            n189MunicipioUF = T000O93_n189MunicipioUF[0];
            AssignAttri("", false, "A189MunicipioUF", A189MunicipioUF);
            pr_default.close(52);
            A206ClienteCelular_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A198ContatoDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 1, 5), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A200ContatoNumero), 18, 0)), 6, 4), "", "", "", "", "", "");
            AssignAttri("", false, "A206ClienteCelular_F", A206ClienteCelular_F);
            A205ClienteTelefone_F = StringUtil.Format( "%1 %2-%3", StringUtil.LTrimStr( (decimal)(A203ContatoTelefoneDDD), 4, 0), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 1, 4), StringUtil.Substring( StringUtil.Trim( StringUtil.Str( (decimal)(A202ContatoTelefoneNumero), 18, 0)), 5, 4), "", "", "", "", "", "");
            AssignAttri("", false, "A205ClienteTelefone_F", A205ClienteTelefone_F);
            GXt_char2 = A577ResponsavelCelular_F;
            new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char2) ;
            n454ResponsavelDDD = ((0==A454ResponsavelDDD) ? true : false);
            A577ResponsavelCelular_F = GXt_char2;
            AssignAttri("", false, "A577ResponsavelCelular_F", A577ResponsavelCelular_F);
            /* Using cursor T000O94 */
            pr_default.execute(53, new Object[] {n192TipoClienteId, A192TipoClienteId});
            A193TipoClienteDescricao = T000O94_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = T000O94_n193TipoClienteDescricao[0];
            AssignAttri("", false, "A193TipoClienteDescricao", A193TipoClienteDescricao);
            A207TipoClientePortal = T000O94_A207TipoClientePortal[0];
            n207TipoClientePortal = T000O94_n207TipoClientePortal[0];
            A793TipoClientePortalPjPf = T000O94_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = T000O94_n793TipoClientePortalPjPf[0];
            pr_default.close(53);
            /* Using cursor T000O95 */
            pr_default.execute(54, new Object[] {n444ResponsavelMunicipio, A444ResponsavelMunicipio});
            A446ResponsavelMunicipioUF = T000O95_A446ResponsavelMunicipioUF[0];
            n446ResponsavelMunicipioUF = T000O95_n446ResponsavelMunicipioUF[0];
            A445ResponsavelMunicipioNome = T000O95_A445ResponsavelMunicipioNome[0];
            n445ResponsavelMunicipioNome = T000O95_n445ResponsavelMunicipioNome[0];
            pr_default.close(54);
            /* Using cursor T000O96 */
            pr_default.execute(55, new Object[] {n402BancoId, A402BancoId});
            A404BancoCodigo = T000O96_A404BancoCodigo[0];
            n404BancoCodigo = T000O96_n404BancoCodigo[0];
            A403BancoNome = T000O96_A403BancoNome[0];
            n403BancoNome = T000O96_n403BancoNome[0];
            pr_default.close(55);
            /* Using cursor T000O97 */
            pr_default.execute(56, new Object[] {n437ResponsavelNacionalidade, A437ResponsavelNacionalidade});
            A438ResponsavelNacionalidadeNome = T000O97_A438ResponsavelNacionalidadeNome[0];
            n438ResponsavelNacionalidadeNome = T000O97_n438ResponsavelNacionalidadeNome[0];
            pr_default.close(56);
            /* Using cursor T000O98 */
            pr_default.execute(57, new Object[] {n484ClienteNacionalidade, A484ClienteNacionalidade});
            A485ClienteNacionalidadeNome = T000O98_A485ClienteNacionalidadeNome[0];
            n485ClienteNacionalidadeNome = T000O98_n485ClienteNacionalidadeNome[0];
            pr_default.close(57);
            /* Using cursor T000O99 */
            pr_default.execute(58, new Object[] {n442ResponsavelProfissao, A442ResponsavelProfissao});
            A443ResponsavelProfissaoNome = T000O99_A443ResponsavelProfissaoNome[0];
            n443ResponsavelProfissaoNome = T000O99_n443ResponsavelProfissaoNome[0];
            pr_default.close(58);
            /* Using cursor T000O100 */
            pr_default.execute(59, new Object[] {n487ClienteProfissao, A487ClienteProfissao});
            A488ClienteProfissaoNome = T000O100_A488ClienteProfissaoNome[0];
            n488ClienteProfissaoNome = T000O100_n488ClienteProfissaoNome[0];
            pr_default.close(59);
            /* Using cursor T000O101 */
            pr_default.execute(60, new Object[] {n489ClienteConvenio, A489ClienteConvenio});
            A490ClienteConvenioDescricao = T000O101_A490ClienteConvenioDescricao[0];
            n490ClienteConvenioDescricao = T000O101_n490ClienteConvenioDescricao[0];
            pr_default.close(60);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000O102 */
            pr_default.execute(61, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(61) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"OperacoesTitulos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(61);
            /* Using cursor T000O103 */
            pr_default.execute(62, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(62) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Sd Proposta Empresa"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(62);
            /* Using cursor T000O104 */
            pr_default.execute(63, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(63) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Sb Proposta Clinica"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(63);
            /* Using cursor T000O105 */
            pr_default.execute(64, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(64) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Proposta Responsavel"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(64);
            /* Using cursor T000O106 */
            pr_default.execute(65, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(65) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Proposta Cliente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(65);
            /* Using cursor T000O107 */
            pr_default.execute(66, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(66) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(66);
            /* Using cursor T000O108 */
            pr_default.execute(67, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(67) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(67);
            /* Using cursor T000O109 */
            pr_default.execute(68, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(68) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(68);
            /* Using cursor T000O110 */
            pr_default.execute(69, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(69) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Relacionamento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(69);
            /* Using cursor T000O111 */
            pr_default.execute(70, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(70) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Operacoes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(70);
            /* Using cursor T000O112 */
            pr_default.execute(71, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(71) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Representante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(71);
            /* Using cursor T000O113 */
            pr_default.execute(72, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(72) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(72);
            /* Using cursor T000O114 */
            pr_default.execute(73, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(73) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscal"+" ("+"Sb Nota Destinatario Cliente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(73);
            /* Using cursor T000O115 */
            pr_default.execute(74, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(74) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscal"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(74);
            /* Using cursor T000O116 */
            pr_default.execute(75, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(75) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Serasa"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(75);
            /* Using cursor T000O117 */
            pr_default.execute(76, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(76) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(76);
            /* Using cursor T000O118 */
            pr_default.execute(77, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(77) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteReponsavel"+" ("+"Sb Cliente Reponsavel"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(77);
            /* Using cursor T000O119 */
            pr_default.execute(78, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(78) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteReponsavel"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(78);
            /* Using cursor T000O120 */
            pr_default.execute(79, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(79) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"AssinaturaParticipante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(79);
            /* Using cursor T000O121 */
            pr_default.execute(80, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(80) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Financiamento"+" ("+"SBFin Cli Int"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(80);
            /* Using cursor T000O122 */
            pr_default.execute(81, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(81) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Financiamento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(81);
         }
      }

      protected void EndLevel0O28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0O28( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("cliente",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0O0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("cliente",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0O28( )
      {
         /* Scan By routine */
         /* Using cursor T000O123 */
         pr_default.execute(82);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(82) != 101) )
         {
            RcdFound28 = 1;
            A168ClienteId = T000O123_A168ClienteId[0];
            n168ClienteId = T000O123_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0O28( )
      {
         /* Scan next routine */
         pr_default.readNext(82);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(82) != 101) )
         {
            RcdFound28 = 1;
            A168ClienteId = T000O123_A168ClienteId[0];
            n168ClienteId = T000O123_n168ClienteId[0];
            AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
         }
      }

      protected void ScanEnd0O28( )
      {
         pr_default.close(82);
      }

      protected void AfterConfirm0O28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0O28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0O28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0O28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0O28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0O28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0O28( )
      {
         edtClienteDocumento_Enabled = 0;
         AssignProp("", false, edtClienteDocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteDocumento_Enabled), 5, 0), true);
         edtClienteRazaoSocial_Enabled = 0;
         AssignProp("", false, edtClienteRazaoSocial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteRazaoSocial_Enabled), 5, 0), true);
         edtClienteNomeFantasia_Enabled = 0;
         AssignProp("", false, edtClienteNomeFantasia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteNomeFantasia_Enabled), 5, 0), true);
         cmbClienteTipoPessoa.Enabled = 0;
         AssignProp("", false, cmbClienteTipoPessoa_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbClienteTipoPessoa.Enabled), 5, 0), true);
         edtTipoClienteDescricao_Enabled = 0;
         AssignProp("", false, edtTipoClienteDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoClienteDescricao_Enabled), 5, 0), true);
         cmbClienteStatus.Enabled = 0;
         AssignProp("", false, cmbClienteStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbClienteStatus.Enabled), 5, 0), true);
         cmbEnderecoTipo.Enabled = 0;
         AssignProp("", false, cmbEnderecoTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbEnderecoTipo.Enabled), 5, 0), true);
         edtEnderecoCEP_Enabled = 0;
         AssignProp("", false, edtEnderecoCEP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnderecoCEP_Enabled), 5, 0), true);
         edtEnderecoLogradouro_Enabled = 0;
         AssignProp("", false, edtEnderecoLogradouro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnderecoLogradouro_Enabled), 5, 0), true);
         edtEnderecoBairro_Enabled = 0;
         AssignProp("", false, edtEnderecoBairro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnderecoBairro_Enabled), 5, 0), true);
         edtEnderecoCidade_Enabled = 0;
         AssignProp("", false, edtEnderecoCidade_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnderecoCidade_Enabled), 5, 0), true);
         edtMunicipioCodigo_Enabled = 0;
         AssignProp("", false, edtMunicipioCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioCodigo_Enabled), 5, 0), true);
         edtMunicipioUF_Enabled = 0;
         AssignProp("", false, edtMunicipioUF_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMunicipioUF_Enabled), 5, 0), true);
         edtEnderecoNumero_Enabled = 0;
         AssignProp("", false, edtEnderecoNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnderecoNumero_Enabled), 5, 0), true);
         edtEnderecoComplemento_Enabled = 0;
         AssignProp("", false, edtEnderecoComplemento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEnderecoComplemento_Enabled), 5, 0), true);
         edtContatoEmail_Enabled = 0;
         AssignProp("", false, edtContatoEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContatoEmail_Enabled), 5, 0), true);
         edtContatoDDD_Enabled = 0;
         AssignProp("", false, edtContatoDDD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContatoDDD_Enabled), 5, 0), true);
         edtContatoNumero_Enabled = 0;
         AssignProp("", false, edtContatoNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContatoNumero_Enabled), 5, 0), true);
         edtContatoTelefoneNumero_Enabled = 0;
         AssignProp("", false, edtContatoTelefoneNumero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContatoTelefoneNumero_Enabled), 5, 0), true);
         edtContatoTelefoneDDD_Enabled = 0;
         AssignProp("", false, edtContatoTelefoneDDD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContatoTelefoneDDD_Enabled), 5, 0), true);
         edtContatoTelefoneDDI_Enabled = 0;
         AssignProp("", false, edtContatoTelefoneDDI_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContatoTelefoneDDI_Enabled), 5, 0), true);
         edtContatoDDI_Enabled = 0;
         AssignProp("", false, edtContatoDDI_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtContatoDDI_Enabled), 5, 0), true);
         edtClienteTelefone_F_Enabled = 0;
         AssignProp("", false, edtClienteTelefone_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteTelefone_F_Enabled), 5, 0), true);
         edtClienteCelular_F_Enabled = 0;
         AssignProp("", false, edtClienteCelular_F_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCelular_F_Enabled), 5, 0), true);
         edtavCombomunicipiocodigo_Enabled = 0;
         AssignProp("", false, edtavCombomunicipiocodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomunicipiocodigo_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0O28( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0O0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         GXEncryptionTmp = "cliente"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ClienteId,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal FormWithFixedActions\" data-gx-class=\"form-horizontal FormWithFixedActions\" novalidate action=\""+formatLink("cliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Cliente");
         forbiddenHiddens.Add("ClienteId", context.localUtil.Format( (decimal)(A168ClienteId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_EspecialidadeId", context.localUtil.Format( (decimal)(AV29Insert_EspecialidadeId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_TipoClienteId", context.localUtil.Format( (decimal)(AV14Insert_TipoClienteId), "ZZZ9"));
         forbiddenHiddens.Add("Insert_ClienteConvenio", context.localUtil.Format( (decimal)(AV32Insert_ClienteConvenio), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ClienteNacionalidade", context.localUtil.Format( (decimal)(AV30Insert_ClienteNacionalidade), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ClienteProfissao", context.localUtil.Format( (decimal)(AV31Insert_ClienteProfissao), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_MunicipioCodigo", StringUtil.RTrim( context.localUtil.Format( AV17Insert_MunicipioCodigo, "")));
         forbiddenHiddens.Add("Insert_BancoId", context.localUtil.Format( (decimal)(AV25Insert_BancoId), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ResponsavelNacionalidade", context.localUtil.Format( (decimal)(AV26Insert_ResponsavelNacionalidade), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ResponsavelProfissao", context.localUtil.Format( (decimal)(AV27Insert_ResponsavelProfissao), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("Insert_ResponsavelMunicipio", StringUtil.RTrim( context.localUtil.Format( AV28Insert_ResponsavelMunicipio, "")));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("ClienteCreatedAt", context.localUtil.Format( A175ClienteCreatedAt, "99/99/99 99:99"));
         forbiddenHiddens.Add("ClienteUpdatedAt", context.localUtil.Format( A176ClienteUpdatedAt, "99/99/99 99:99"));
         forbiddenHiddens.Add("ClienteDataNascimento", context.localUtil.Format(A459ClienteDataNascimento, "99/99/9999"));
         forbiddenHiddens.Add("ClienteLogUser", context.localUtil.Format( (decimal)(A177ClienteLogUser), "ZZZ9"));
         forbiddenHiddens.Add("ClienteEstadoCivil", StringUtil.RTrim( context.localUtil.Format( A486ClienteEstadoCivil, "")));
         forbiddenHiddens.Add("ClienteRG", context.localUtil.Format( (decimal)(A421ClienteRG), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("ClienteDepositoTipo", StringUtil.RTrim( context.localUtil.Format( A537ClienteDepositoTipo, "")));
         forbiddenHiddens.Add("ClientePixTipo", StringUtil.RTrim( context.localUtil.Format( A538ClientePixTipo, "")));
         forbiddenHiddens.Add("ClientePix", StringUtil.RTrim( context.localUtil.Format( A539ClientePix, "")));
         forbiddenHiddens.Add("ContaAgencia", StringUtil.RTrim( context.localUtil.Format( A400ContaAgencia, "")));
         forbiddenHiddens.Add("ContaNumero", StringUtil.RTrim( context.localUtil.Format( A401ContaNumero, "")));
         forbiddenHiddens.Add("ResponsavelNome", StringUtil.RTrim( context.localUtil.Format( A436ResponsavelNome, "")));
         forbiddenHiddens.Add("ResponsavelEstadoCivil", StringUtil.RTrim( context.localUtil.Format( A439ResponsavelEstadoCivil, "")));
         forbiddenHiddens.Add("ResponsavelRG", context.localUtil.Format( (decimal)(A576ResponsavelRG), "ZZZZZZZZZZZ9"));
         forbiddenHiddens.Add("ResponsavelCPF", StringUtil.RTrim( context.localUtil.Format( A447ResponsavelCPF, "")));
         forbiddenHiddens.Add("ResponsavelCEP", StringUtil.RTrim( context.localUtil.Format( A448ResponsavelCEP, "")));
         forbiddenHiddens.Add("ResponsavelLogradouro", StringUtil.RTrim( context.localUtil.Format( A449ResponsavelLogradouro, "")));
         forbiddenHiddens.Add("ResponsavelBairro", StringUtil.RTrim( context.localUtil.Format( A450ResponsavelBairro, "")));
         forbiddenHiddens.Add("ResponsavelCidade", StringUtil.RTrim( context.localUtil.Format( A451ResponsavelCidade, "")));
         forbiddenHiddens.Add("ResponsavelLogradouroNumero", context.localUtil.Format( (decimal)(A452ResponsavelLogradouroNumero), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("ResponsavelComplemento", StringUtil.RTrim( context.localUtil.Format( A453ResponsavelComplemento, "")));
         forbiddenHiddens.Add("ResponsavelDDD", context.localUtil.Format( (decimal)(A454ResponsavelDDD), "ZZZ9"));
         forbiddenHiddens.Add("ResponsavelNumero", context.localUtil.Format( (decimal)(A455ResponsavelNumero), "ZZZZZZZZ9"));
         forbiddenHiddens.Add("ResponsavelEmail", StringUtil.RTrim( context.localUtil.Format( A456ResponsavelEmail, "")));
         forbiddenHiddens.Add("ClienteSituacao", StringUtil.RTrim( context.localUtil.Format( A884ClienteSituacao, "")));
         forbiddenHiddens.Add("ResponsavelCargo", StringUtil.RTrim( context.localUtil.Format( A885ResponsavelCargo, "")));
         forbiddenHiddens.Add("ClienteTipoRisco", StringUtil.RTrim( context.localUtil.Format( A1039ClienteTipoRisco, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cliente:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z168ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z168ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z175ClienteCreatedAt", context.localUtil.TToC( Z175ClienteCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z176ClienteUpdatedAt", context.localUtil.TToC( Z176ClienteUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z169ClienteDocumento", Z169ClienteDocumento);
         GxWebStd.gx_hidden_field( context, "Z170ClienteRazaoSocial", Z170ClienteRazaoSocial);
         GxWebStd.gx_hidden_field( context, "Z171ClienteNomeFantasia", Z171ClienteNomeFantasia);
         GxWebStd.gx_hidden_field( context, "Z459ClienteDataNascimento", context.localUtil.DToC( Z459ClienteDataNascimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z172ClienteTipoPessoa", Z172ClienteTipoPessoa);
         GxWebStd.gx_boolean_hidden_field( context, "Z174ClienteStatus", Z174ClienteStatus);
         GxWebStd.gx_hidden_field( context, "Z177ClienteLogUser", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z177ClienteLogUser), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z486ClienteEstadoCivil", Z486ClienteEstadoCivil);
         GxWebStd.gx_hidden_field( context, "Z181EnderecoTipo", Z181EnderecoTipo);
         GxWebStd.gx_hidden_field( context, "Z182EnderecoCEP", Z182EnderecoCEP);
         GxWebStd.gx_hidden_field( context, "Z183EnderecoLogradouro", Z183EnderecoLogradouro);
         GxWebStd.gx_hidden_field( context, "Z184EnderecoBairro", Z184EnderecoBairro);
         GxWebStd.gx_hidden_field( context, "Z185EnderecoCidade", Z185EnderecoCidade);
         GxWebStd.gx_hidden_field( context, "Z190EnderecoNumero", Z190EnderecoNumero);
         GxWebStd.gx_hidden_field( context, "Z191EnderecoComplemento", Z191EnderecoComplemento);
         GxWebStd.gx_hidden_field( context, "Z201ContatoEmail", Z201ContatoEmail);
         GxWebStd.gx_hidden_field( context, "Z198ContatoDDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z198ContatoDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z199ContatoDDI", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z199ContatoDDI), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z200ContatoNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z200ContatoNumero), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z202ContatoTelefoneNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z202ContatoTelefoneNumero), 18, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z203ContatoTelefoneDDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z203ContatoTelefoneDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z204ContatoTelefoneDDI", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z204ContatoTelefoneDDI), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z421ClienteRG", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z421ClienteRG), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z537ClienteDepositoTipo", Z537ClienteDepositoTipo);
         GxWebStd.gx_hidden_field( context, "Z538ClientePixTipo", Z538ClientePixTipo);
         GxWebStd.gx_hidden_field( context, "Z539ClientePix", Z539ClientePix);
         GxWebStd.gx_hidden_field( context, "Z400ContaAgencia", Z400ContaAgencia);
         GxWebStd.gx_hidden_field( context, "Z401ContaNumero", Z401ContaNumero);
         GxWebStd.gx_hidden_field( context, "Z436ResponsavelNome", Z436ResponsavelNome);
         GxWebStd.gx_hidden_field( context, "Z439ResponsavelEstadoCivil", Z439ResponsavelEstadoCivil);
         GxWebStd.gx_hidden_field( context, "Z576ResponsavelRG", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z576ResponsavelRG), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z447ResponsavelCPF", Z447ResponsavelCPF);
         GxWebStd.gx_hidden_field( context, "Z448ResponsavelCEP", Z448ResponsavelCEP);
         GxWebStd.gx_hidden_field( context, "Z449ResponsavelLogradouro", Z449ResponsavelLogradouro);
         GxWebStd.gx_hidden_field( context, "Z450ResponsavelBairro", Z450ResponsavelBairro);
         GxWebStd.gx_hidden_field( context, "Z451ResponsavelCidade", Z451ResponsavelCidade);
         GxWebStd.gx_hidden_field( context, "Z452ResponsavelLogradouroNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z452ResponsavelLogradouroNumero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z453ResponsavelComplemento", Z453ResponsavelComplemento);
         GxWebStd.gx_hidden_field( context, "Z454ResponsavelDDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z454ResponsavelDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z455ResponsavelNumero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z455ResponsavelNumero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z456ResponsavelEmail", Z456ResponsavelEmail);
         GxWebStd.gx_hidden_field( context, "Z884ClienteSituacao", StringUtil.RTrim( Z884ClienteSituacao));
         GxWebStd.gx_hidden_field( context, "Z885ResponsavelCargo", Z885ResponsavelCargo);
         GxWebStd.gx_hidden_field( context, "Z1039ClienteTipoRisco", Z1039ClienteTipoRisco);
         GxWebStd.gx_hidden_field( context, "Z192TipoClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z192TipoClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z186MunicipioCodigo", Z186MunicipioCodigo);
         GxWebStd.gx_hidden_field( context, "Z444ResponsavelMunicipio", Z444ResponsavelMunicipio);
         GxWebStd.gx_hidden_field( context, "Z402BancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z402BancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z457EspecialidadeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z457EspecialidadeId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z437ResponsavelNacionalidade", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z437ResponsavelNacionalidade), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z484ClienteNacionalidade", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z484ClienteNacionalidade), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z442ResponsavelProfissao", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z442ResponsavelProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z487ClienteProfissao", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z487ClienteProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z489ClienteConvenio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z489ClienteConvenio), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N457EspecialidadeId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A457EspecialidadeId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N192TipoClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N489ClienteConvenio", StringUtil.LTrim( StringUtil.NToC( (decimal)(A489ClienteConvenio), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N484ClienteNacionalidade", StringUtil.LTrim( StringUtil.NToC( (decimal)(A484ClienteNacionalidade), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N487ClienteProfissao", StringUtil.LTrim( StringUtil.NToC( (decimal)(A487ClienteProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N186MunicipioCodigo", A186MunicipioCodigo);
         GxWebStd.gx_hidden_field( context, "N402BancoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A402BancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N437ResponsavelNacionalidade", StringUtil.LTrim( StringUtil.NToC( (decimal)(A437ResponsavelNacionalidade), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N442ResponsavelProfissao", StringUtil.LTrim( StringUtil.NToC( (decimal)(A442ResponsavelProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N444ResponsavelMunicipio", A444ResponsavelMunicipio);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV19DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV19DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMUNICIPIOCODIGO_DATA", AV18MunicipioCodigo_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMUNICIPIOCODIGO_DATA", AV18MunicipioCodigo_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV12TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV12TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV12TrnContext, context));
         GxWebStd.gx_hidden_field( context, "RESPONSAVELDDD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A454ResponsavelDDD), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "RESPONSAVELNUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A455ResponsavelNumero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "RESPONSAVELCELULAR_F", A577ResponsavelCelular_F);
         GxWebStd.gx_hidden_field( context, "RELACIONAMENTOSACADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1031RelacionamentoSacado), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "CLIENTESACADO", A1030ClienteSacado);
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ClienteId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteId), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESPECIALIDADEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29Insert_EspecialidadeId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ESPECIALIDADEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A457EspecialidadeId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_TipoClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TIPOCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTECONVENIO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32Insert_ClienteConvenio), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTECONVENIO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A489ClienteConvenio), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTENACIONALIDADE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30Insert_ClienteNacionalidade), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTENACIONALIDADE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A484ClienteNacionalidade), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEPROFISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31Insert_ClienteProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTEPROFISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A487ClienteProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_MUNICIPIOCODIGO", AV17Insert_MunicipioCodigo);
         GxWebStd.gx_hidden_field( context, "vINSERT_BANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25Insert_BancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "BANCOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A402BancoId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_RESPONSAVELNACIONALIDADE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Insert_ResponsavelNacionalidade), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "RESPONSAVELNACIONALIDADE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A437ResponsavelNacionalidade), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_RESPONSAVELPROFISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27Insert_ResponsavelProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "RESPONSAVELPROFISSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A442ResponsavelProfissao), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_RESPONSAVELMUNICIPIO", AV28Insert_ResponsavelMunicipio);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELMUNICIPIO", A444ResponsavelMunicipio);
         GxWebStd.gx_hidden_field( context, "CLIENTECREATEDAT", context.localUtil.TToC( A175ClienteCreatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CLIENTEUPDATEDAT", context.localUtil.TToC( A176ClienteUpdatedAt, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTEVALORAPAGAR_F", StringUtil.LTrim( StringUtil.NToC( A310ClienteValorAPagar_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTEVALORARECEBER_F", StringUtil.LTrim( StringUtil.NToC( A311ClienteValorAReceber_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "SERASAULTIMOVALORRECOMENDADO_F", StringUtil.LTrim( StringUtil.NToC( A785SerasaUltimoValorRecomendado_F, 18, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTEDATANASCIMENTO", context.localUtil.DToC( A459ClienteDataNascimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "CLIENTELOGUSER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A177ClienteLogUser), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTEESTADOCIVIL", A486ClienteEstadoCivil);
         GxWebStd.gx_hidden_field( context, "CLIENTERG", StringUtil.LTrim( StringUtil.NToC( (decimal)(A421ClienteRG), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTEDEPOSITOTIPO", A537ClienteDepositoTipo);
         GxWebStd.gx_hidden_field( context, "CLIENTEPIXTIPO", A538ClientePixTipo);
         GxWebStd.gx_hidden_field( context, "CLIENTEPIX", A539ClientePix);
         GxWebStd.gx_hidden_field( context, "CONTAAGENCIA", A400ContaAgencia);
         GxWebStd.gx_hidden_field( context, "CONTANUMERO", A401ContaNumero);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELNOME", A436ResponsavelNome);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELESTADOCIVIL", A439ResponsavelEstadoCivil);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELRG", StringUtil.LTrim( StringUtil.NToC( (decimal)(A576ResponsavelRG), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "RESPONSAVELCPF", A447ResponsavelCPF);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELCEP", A448ResponsavelCEP);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELLOGRADOURO", A449ResponsavelLogradouro);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELBAIRRO", A450ResponsavelBairro);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELCIDADE", A451ResponsavelCidade);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELLOGRADOURONUMERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A452ResponsavelLogradouroNumero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "RESPONSAVELCOMPLEMENTO", A453ResponsavelComplemento);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELEMAIL", A456ResponsavelEmail);
         GxWebStd.gx_hidden_field( context, "CLIENTESITUACAO", StringUtil.RTrim( A884ClienteSituacao));
         GxWebStd.gx_hidden_field( context, "RESPONSAVELCARGO", A885ResponsavelCargo);
         GxWebStd.gx_hidden_field( context, "CLIENTETIPORISCO", A1039ClienteTipoRisco);
         GxWebStd.gx_boolean_hidden_field( context, "TIPOCLIENTEPORTAL", A207TipoClientePortal);
         GxWebStd.gx_boolean_hidden_field( context, "TIPOCLIENTEPORTALPJPF", A793TipoClientePortalPjPf);
         GxWebStd.gx_hidden_field( context, "MUNICIPIONOME", A187MunicipioNome);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELMUNICIPIOUF", A446ResponsavelMunicipioUF);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELMUNICIPIONOME", A445ResponsavelMunicipioNome);
         GxWebStd.gx_hidden_field( context, "BANCOCODIGO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A404BancoCodigo), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "BANCONOME", A403BancoNome);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELNACIONALIDADENOME", A438ResponsavelNacionalidadeNome);
         GxWebStd.gx_hidden_field( context, "CLIENTENACIONALIDADENOME", A485ClienteNacionalidadeNome);
         GxWebStd.gx_hidden_field( context, "RESPONSAVELPROFISSAONOME", A443ResponsavelProfissaoNome);
         GxWebStd.gx_hidden_field( context, "CLIENTEPROFISSAONOME", A488ClienteProfissaoNome);
         GxWebStd.gx_hidden_field( context, "CLIENTECONVENIODESCRICAO", A490ClienteConvenioDescricao);
         GxWebStd.gx_hidden_field( context, "SERASAULTIMADATA_F", context.localUtil.TToC( A780SerasaUltimaData_F, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "SERASASCOREULTIMADATA_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A781SerasaScoreUltimaData_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SECUSERID_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A608SecUserId_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "CLIENTEQTDTITULOS_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A309ClienteQtdTitulos_F), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "SERASACONSULTAS_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A732SerasaConsultas_F), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV35Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOCODIGO_Objectcall", StringUtil.RTrim( Combo_municipiocodigo_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOCODIGO_Cls", StringUtil.RTrim( Combo_municipiocodigo_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOCODIGO_Selectedvalue_set", StringUtil.RTrim( Combo_municipiocodigo_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOCODIGO_Selectedtext_set", StringUtil.RTrim( Combo_municipiocodigo_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOCODIGO_Enabled", StringUtil.BoolToStr( Combo_municipiocodigo_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOCODIGO_Datalistproc", StringUtil.RTrim( Combo_municipiocodigo_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_MUNICIPIOCODIGO_Datalistprocparametersprefix", StringUtil.RTrim( Combo_municipiocodigo_Datalistprocparametersprefix));
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
         GXEncryptionTmp = "cliente"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ClienteId,9,0));
         return formatLink("cliente") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Cliente" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cliente" ;
      }

      protected void InitializeNonKey0O28( )
      {
         A457EspecialidadeId = 0;
         n457EspecialidadeId = false;
         AssignAttri("", false, "A457EspecialidadeId", ((0==A457EspecialidadeId)&&IsIns( )||n457EspecialidadeId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A457EspecialidadeId), 9, 0, ".", ""))));
         A192TipoClienteId = 0;
         n192TipoClienteId = false;
         AssignAttri("", false, "A192TipoClienteId", ((0==A192TipoClienteId)&&IsIns( )||n192TipoClienteId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A192TipoClienteId), 4, 0, ".", ""))));
         A489ClienteConvenio = 0;
         n489ClienteConvenio = false;
         AssignAttri("", false, "A489ClienteConvenio", ((0==A489ClienteConvenio)&&IsIns( )||n489ClienteConvenio ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A489ClienteConvenio), 9, 0, ".", ""))));
         A484ClienteNacionalidade = 0;
         n484ClienteNacionalidade = false;
         AssignAttri("", false, "A484ClienteNacionalidade", ((0==A484ClienteNacionalidade)&&IsIns( )||n484ClienteNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A484ClienteNacionalidade), 9, 0, ".", ""))));
         A487ClienteProfissao = 0;
         n487ClienteProfissao = false;
         AssignAttri("", false, "A487ClienteProfissao", ((0==A487ClienteProfissao)&&IsIns( )||n487ClienteProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A487ClienteProfissao), 9, 0, ".", ""))));
         A186MunicipioCodigo = "";
         n186MunicipioCodigo = false;
         AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
         n186MunicipioCodigo = (String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ? true : false);
         A402BancoId = 0;
         n402BancoId = false;
         AssignAttri("", false, "A402BancoId", ((0==A402BancoId)&&IsIns( )||n402BancoId ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A402BancoId), 9, 0, ".", ""))));
         A437ResponsavelNacionalidade = 0;
         n437ResponsavelNacionalidade = false;
         AssignAttri("", false, "A437ResponsavelNacionalidade", ((0==A437ResponsavelNacionalidade)&&IsIns( )||n437ResponsavelNacionalidade ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A437ResponsavelNacionalidade), 9, 0, ".", ""))));
         A442ResponsavelProfissao = 0;
         n442ResponsavelProfissao = false;
         AssignAttri("", false, "A442ResponsavelProfissao", ((0==A442ResponsavelProfissao)&&IsIns( )||n442ResponsavelProfissao ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A442ResponsavelProfissao), 9, 0, ".", ""))));
         A444ResponsavelMunicipio = "";
         n444ResponsavelMunicipio = false;
         AssignAttri("", false, "A444ResponsavelMunicipio", A444ResponsavelMunicipio);
         A175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         n175ClienteCreatedAt = false;
         AssignAttri("", false, "A175ClienteCreatedAt", context.localUtil.TToC( A175ClienteCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A176ClienteUpdatedAt = (DateTime)(DateTime.MinValue);
         n176ClienteUpdatedAt = false;
         AssignAttri("", false, "A176ClienteUpdatedAt", context.localUtil.TToC( A176ClienteUpdatedAt, 8, 5, 0, 3, "/", ":", " "));
         A1030ClienteSacado = false;
         AssignAttri("", false, "A1030ClienteSacado", A1030ClienteSacado);
         A781SerasaScoreUltimaData_F = 0;
         AssignAttri("", false, "A781SerasaScoreUltimaData_F", StringUtil.LTrimStr( (decimal)(A781SerasaScoreUltimaData_F), 4, 0));
         A785SerasaUltimoValorRecomendado_F = 0;
         AssignAttri("", false, "A785SerasaUltimoValorRecomendado_F", StringUtil.LTrimStr( A785SerasaUltimoValorRecomendado_F, 18, 2));
         A577ResponsavelCelular_F = "";
         AssignAttri("", false, "A577ResponsavelCelular_F", A577ResponsavelCelular_F);
         A205ClienteTelefone_F = "";
         AssignAttri("", false, "A205ClienteTelefone_F", A205ClienteTelefone_F);
         A206ClienteCelular_F = "";
         AssignAttri("", false, "A206ClienteCelular_F", A206ClienteCelular_F);
         A608SecUserId_F = 0;
         n608SecUserId_F = false;
         AssignAttri("", false, "A608SecUserId_F", StringUtil.LTrimStr( (decimal)(A608SecUserId_F), 4, 0));
         A169ClienteDocumento = "";
         n169ClienteDocumento = false;
         AssignAttri("", false, "A169ClienteDocumento", A169ClienteDocumento);
         n169ClienteDocumento = (String.IsNullOrEmpty(StringUtil.RTrim( A169ClienteDocumento)) ? true : false);
         A170ClienteRazaoSocial = "";
         n170ClienteRazaoSocial = false;
         AssignAttri("", false, "A170ClienteRazaoSocial", A170ClienteRazaoSocial);
         n170ClienteRazaoSocial = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? true : false);
         A171ClienteNomeFantasia = "";
         n171ClienteNomeFantasia = false;
         AssignAttri("", false, "A171ClienteNomeFantasia", A171ClienteNomeFantasia);
         n171ClienteNomeFantasia = (String.IsNullOrEmpty(StringUtil.RTrim( A171ClienteNomeFantasia)) ? true : false);
         A459ClienteDataNascimento = DateTime.MinValue;
         n459ClienteDataNascimento = false;
         AssignAttri("", false, "A459ClienteDataNascimento", context.localUtil.Format(A459ClienteDataNascimento, "99/99/9999"));
         A172ClienteTipoPessoa = "";
         n172ClienteTipoPessoa = false;
         AssignAttri("", false, "A172ClienteTipoPessoa", A172ClienteTipoPessoa);
         n172ClienteTipoPessoa = (String.IsNullOrEmpty(StringUtil.RTrim( A172ClienteTipoPessoa)) ? true : false);
         A193TipoClienteDescricao = "";
         n193TipoClienteDescricao = false;
         AssignAttri("", false, "A193TipoClienteDescricao", A193TipoClienteDescricao);
         A207TipoClientePortal = false;
         n207TipoClientePortal = false;
         AssignAttri("", false, "A207TipoClientePortal", A207TipoClientePortal);
         A490ClienteConvenioDescricao = "";
         n490ClienteConvenioDescricao = false;
         AssignAttri("", false, "A490ClienteConvenioDescricao", A490ClienteConvenioDescricao);
         A177ClienteLogUser = 0;
         n177ClienteLogUser = false;
         AssignAttri("", false, "A177ClienteLogUser", ((0==A177ClienteLogUser)&&IsIns( )||n177ClienteLogUser ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A177ClienteLogUser), 4, 0, ".", ""))));
         A485ClienteNacionalidadeNome = "";
         n485ClienteNacionalidadeNome = false;
         AssignAttri("", false, "A485ClienteNacionalidadeNome", A485ClienteNacionalidadeNome);
         A488ClienteProfissaoNome = "";
         n488ClienteProfissaoNome = false;
         AssignAttri("", false, "A488ClienteProfissaoNome", A488ClienteProfissaoNome);
         A486ClienteEstadoCivil = "";
         n486ClienteEstadoCivil = false;
         AssignAttri("", false, "A486ClienteEstadoCivil", A486ClienteEstadoCivil);
         A181EnderecoTipo = "";
         n181EnderecoTipo = false;
         AssignAttri("", false, "A181EnderecoTipo", A181EnderecoTipo);
         n181EnderecoTipo = (String.IsNullOrEmpty(StringUtil.RTrim( A181EnderecoTipo)) ? true : false);
         A182EnderecoCEP = "";
         n182EnderecoCEP = false;
         AssignAttri("", false, "A182EnderecoCEP", A182EnderecoCEP);
         n182EnderecoCEP = (String.IsNullOrEmpty(StringUtil.RTrim( A182EnderecoCEP)) ? true : false);
         A183EnderecoLogradouro = "";
         n183EnderecoLogradouro = false;
         AssignAttri("", false, "A183EnderecoLogradouro", A183EnderecoLogradouro);
         n183EnderecoLogradouro = (String.IsNullOrEmpty(StringUtil.RTrim( A183EnderecoLogradouro)) ? true : false);
         A184EnderecoBairro = "";
         n184EnderecoBairro = false;
         AssignAttri("", false, "A184EnderecoBairro", A184EnderecoBairro);
         n184EnderecoBairro = (String.IsNullOrEmpty(StringUtil.RTrim( A184EnderecoBairro)) ? true : false);
         A185EnderecoCidade = "";
         n185EnderecoCidade = false;
         AssignAttri("", false, "A185EnderecoCidade", A185EnderecoCidade);
         n185EnderecoCidade = (String.IsNullOrEmpty(StringUtil.RTrim( A185EnderecoCidade)) ? true : false);
         A187MunicipioNome = "";
         n187MunicipioNome = false;
         AssignAttri("", false, "A187MunicipioNome", A187MunicipioNome);
         A189MunicipioUF = "";
         n189MunicipioUF = false;
         AssignAttri("", false, "A189MunicipioUF", A189MunicipioUF);
         A190EnderecoNumero = "";
         n190EnderecoNumero = false;
         AssignAttri("", false, "A190EnderecoNumero", A190EnderecoNumero);
         n190EnderecoNumero = (String.IsNullOrEmpty(StringUtil.RTrim( A190EnderecoNumero)) ? true : false);
         A191EnderecoComplemento = "";
         n191EnderecoComplemento = false;
         AssignAttri("", false, "A191EnderecoComplemento", A191EnderecoComplemento);
         n191EnderecoComplemento = (String.IsNullOrEmpty(StringUtil.RTrim( A191EnderecoComplemento)) ? true : false);
         A201ContatoEmail = "";
         n201ContatoEmail = false;
         AssignAttri("", false, "A201ContatoEmail", A201ContatoEmail);
         n201ContatoEmail = (String.IsNullOrEmpty(StringUtil.RTrim( A201ContatoEmail)) ? true : false);
         A198ContatoDDD = 0;
         n198ContatoDDD = false;
         AssignAttri("", false, "A198ContatoDDD", ((0==A198ContatoDDD)&&IsIns( )||n198ContatoDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A198ContatoDDD), 4, 0, ".", ""))));
         n198ContatoDDD = ((0==A198ContatoDDD) ? true : false);
         A199ContatoDDI = 0;
         n199ContatoDDI = false;
         AssignAttri("", false, "A199ContatoDDI", ((0==A199ContatoDDI)&&IsIns( )||n199ContatoDDI ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A199ContatoDDI), 4, 0, ".", ""))));
         n199ContatoDDI = ((0==A199ContatoDDI) ? true : false);
         A200ContatoNumero = 0;
         n200ContatoNumero = false;
         AssignAttri("", false, "A200ContatoNumero", ((0==A200ContatoNumero)&&IsIns( )||n200ContatoNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A200ContatoNumero), 18, 0, ".", ""))));
         n200ContatoNumero = ((0==A200ContatoNumero) ? true : false);
         A202ContatoTelefoneNumero = 0;
         n202ContatoTelefoneNumero = false;
         AssignAttri("", false, "A202ContatoTelefoneNumero", ((0==A202ContatoTelefoneNumero)&&IsIns( )||n202ContatoTelefoneNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A202ContatoTelefoneNumero), 18, 0, ".", ""))));
         n202ContatoTelefoneNumero = ((0==A202ContatoTelefoneNumero) ? true : false);
         A203ContatoTelefoneDDD = 0;
         n203ContatoTelefoneDDD = false;
         AssignAttri("", false, "A203ContatoTelefoneDDD", ((0==A203ContatoTelefoneDDD)&&IsIns( )||n203ContatoTelefoneDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A203ContatoTelefoneDDD), 4, 0, ".", ""))));
         n203ContatoTelefoneDDD = ((0==A203ContatoTelefoneDDD) ? true : false);
         A204ContatoTelefoneDDI = 0;
         n204ContatoTelefoneDDI = false;
         AssignAttri("", false, "A204ContatoTelefoneDDI", ((0==A204ContatoTelefoneDDI)&&IsIns( )||n204ContatoTelefoneDDI ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A204ContatoTelefoneDDI), 4, 0, ".", ""))));
         n204ContatoTelefoneDDI = ((0==A204ContatoTelefoneDDI) ? true : false);
         A421ClienteRG = 0;
         n421ClienteRG = false;
         AssignAttri("", false, "A421ClienteRG", ((0==A421ClienteRG)&&IsIns( )||n421ClienteRG ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A421ClienteRG), 12, 0, ".", ""))));
         A309ClienteQtdTitulos_F = 0;
         n309ClienteQtdTitulos_F = false;
         AssignAttri("", false, "A309ClienteQtdTitulos_F", StringUtil.LTrimStr( (decimal)(A309ClienteQtdTitulos_F), 9, 0));
         A310ClienteValorAPagar_F = 0;
         n310ClienteValorAPagar_F = false;
         AssignAttri("", false, "A310ClienteValorAPagar_F", StringUtil.LTrimStr( A310ClienteValorAPagar_F, 18, 2));
         A311ClienteValorAReceber_F = 0;
         n311ClienteValorAReceber_F = false;
         AssignAttri("", false, "A311ClienteValorAReceber_F", StringUtil.LTrimStr( A311ClienteValorAReceber_F, 18, 2));
         A537ClienteDepositoTipo = "";
         n537ClienteDepositoTipo = false;
         AssignAttri("", false, "A537ClienteDepositoTipo", A537ClienteDepositoTipo);
         A538ClientePixTipo = "";
         n538ClientePixTipo = false;
         AssignAttri("", false, "A538ClientePixTipo", A538ClientePixTipo);
         A539ClientePix = "";
         n539ClientePix = false;
         AssignAttri("", false, "A539ClientePix", A539ClientePix);
         A404BancoCodigo = 0;
         n404BancoCodigo = false;
         AssignAttri("", false, "A404BancoCodigo", StringUtil.LTrimStr( (decimal)(A404BancoCodigo), 9, 0));
         A403BancoNome = "";
         n403BancoNome = false;
         AssignAttri("", false, "A403BancoNome", A403BancoNome);
         A400ContaAgencia = "";
         n400ContaAgencia = false;
         AssignAttri("", false, "A400ContaAgencia", A400ContaAgencia);
         A401ContaNumero = "";
         n401ContaNumero = false;
         AssignAttri("", false, "A401ContaNumero", A401ContaNumero);
         A436ResponsavelNome = "";
         n436ResponsavelNome = false;
         AssignAttri("", false, "A436ResponsavelNome", A436ResponsavelNome);
         A438ResponsavelNacionalidadeNome = "";
         n438ResponsavelNacionalidadeNome = false;
         AssignAttri("", false, "A438ResponsavelNacionalidadeNome", A438ResponsavelNacionalidadeNome);
         A439ResponsavelEstadoCivil = "";
         n439ResponsavelEstadoCivil = false;
         AssignAttri("", false, "A439ResponsavelEstadoCivil", A439ResponsavelEstadoCivil);
         A576ResponsavelRG = 0;
         n576ResponsavelRG = false;
         AssignAttri("", false, "A576ResponsavelRG", ((0==A576ResponsavelRG)&&IsIns( )||n576ResponsavelRG ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A576ResponsavelRG), 12, 0, ".", ""))));
         A443ResponsavelProfissaoNome = "";
         n443ResponsavelProfissaoNome = false;
         AssignAttri("", false, "A443ResponsavelProfissaoNome", A443ResponsavelProfissaoNome);
         A447ResponsavelCPF = "";
         n447ResponsavelCPF = false;
         AssignAttri("", false, "A447ResponsavelCPF", A447ResponsavelCPF);
         A448ResponsavelCEP = "";
         n448ResponsavelCEP = false;
         AssignAttri("", false, "A448ResponsavelCEP", A448ResponsavelCEP);
         A449ResponsavelLogradouro = "";
         n449ResponsavelLogradouro = false;
         AssignAttri("", false, "A449ResponsavelLogradouro", A449ResponsavelLogradouro);
         A450ResponsavelBairro = "";
         n450ResponsavelBairro = false;
         AssignAttri("", false, "A450ResponsavelBairro", A450ResponsavelBairro);
         A451ResponsavelCidade = "";
         n451ResponsavelCidade = false;
         AssignAttri("", false, "A451ResponsavelCidade", A451ResponsavelCidade);
         A446ResponsavelMunicipioUF = "";
         n446ResponsavelMunicipioUF = false;
         AssignAttri("", false, "A446ResponsavelMunicipioUF", A446ResponsavelMunicipioUF);
         A445ResponsavelMunicipioNome = "";
         n445ResponsavelMunicipioNome = false;
         AssignAttri("", false, "A445ResponsavelMunicipioNome", A445ResponsavelMunicipioNome);
         A452ResponsavelLogradouroNumero = 0;
         n452ResponsavelLogradouroNumero = false;
         AssignAttri("", false, "A452ResponsavelLogradouroNumero", ((0==A452ResponsavelLogradouroNumero)&&IsIns( )||n452ResponsavelLogradouroNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A452ResponsavelLogradouroNumero), 9, 0, ".", ""))));
         A453ResponsavelComplemento = "";
         n453ResponsavelComplemento = false;
         AssignAttri("", false, "A453ResponsavelComplemento", A453ResponsavelComplemento);
         A454ResponsavelDDD = 0;
         n454ResponsavelDDD = false;
         AssignAttri("", false, "A454ResponsavelDDD", ((0==A454ResponsavelDDD)&&IsIns( )||n454ResponsavelDDD ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A454ResponsavelDDD), 4, 0, ".", ""))));
         A455ResponsavelNumero = 0;
         n455ResponsavelNumero = false;
         AssignAttri("", false, "A455ResponsavelNumero", ((0==A455ResponsavelNumero)&&IsIns( )||n455ResponsavelNumero ? "" : StringUtil.LTrim( StringUtil.NToC( (decimal)(A455ResponsavelNumero), 9, 0, ".", ""))));
         A456ResponsavelEmail = "";
         n456ResponsavelEmail = false;
         AssignAttri("", false, "A456ResponsavelEmail", A456ResponsavelEmail);
         A732SerasaConsultas_F = 0;
         AssignAttri("", false, "A732SerasaConsultas_F", StringUtil.LTrimStr( (decimal)(A732SerasaConsultas_F), 4, 0));
         A780SerasaUltimaData_F = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A780SerasaUltimaData_F", context.localUtil.TToC( A780SerasaUltimaData_F, 8, 5, 0, 3, "/", ":", " "));
         A884ClienteSituacao = "";
         n884ClienteSituacao = false;
         AssignAttri("", false, "A884ClienteSituacao", A884ClienteSituacao);
         A885ResponsavelCargo = "";
         n885ResponsavelCargo = false;
         AssignAttri("", false, "A885ResponsavelCargo", A885ResponsavelCargo);
         A793TipoClientePortalPjPf = false;
         n793TipoClientePortalPjPf = false;
         AssignAttri("", false, "A793TipoClientePortalPjPf", A793TipoClientePortalPjPf);
         A1031RelacionamentoSacado = 0;
         n1031RelacionamentoSacado = false;
         AssignAttri("", false, "A1031RelacionamentoSacado", StringUtil.LTrimStr( (decimal)(A1031RelacionamentoSacado), 4, 0));
         A1039ClienteTipoRisco = "";
         AssignAttri("", false, "A1039ClienteTipoRisco", A1039ClienteTipoRisco);
         A174ClienteStatus = true;
         n174ClienteStatus = false;
         AssignAttri("", false, "A174ClienteStatus", A174ClienteStatus);
         Z175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         Z176ClienteUpdatedAt = (DateTime)(DateTime.MinValue);
         Z169ClienteDocumento = "";
         Z170ClienteRazaoSocial = "";
         Z171ClienteNomeFantasia = "";
         Z459ClienteDataNascimento = DateTime.MinValue;
         Z172ClienteTipoPessoa = "";
         Z174ClienteStatus = false;
         Z177ClienteLogUser = 0;
         Z486ClienteEstadoCivil = "";
         Z181EnderecoTipo = "";
         Z182EnderecoCEP = "";
         Z183EnderecoLogradouro = "";
         Z184EnderecoBairro = "";
         Z185EnderecoCidade = "";
         Z190EnderecoNumero = "";
         Z191EnderecoComplemento = "";
         Z201ContatoEmail = "";
         Z198ContatoDDD = 0;
         Z199ContatoDDI = 0;
         Z200ContatoNumero = 0;
         Z202ContatoTelefoneNumero = 0;
         Z203ContatoTelefoneDDD = 0;
         Z204ContatoTelefoneDDI = 0;
         Z421ClienteRG = 0;
         Z537ClienteDepositoTipo = "";
         Z538ClientePixTipo = "";
         Z539ClientePix = "";
         Z400ContaAgencia = "";
         Z401ContaNumero = "";
         Z436ResponsavelNome = "";
         Z439ResponsavelEstadoCivil = "";
         Z576ResponsavelRG = 0;
         Z447ResponsavelCPF = "";
         Z448ResponsavelCEP = "";
         Z449ResponsavelLogradouro = "";
         Z450ResponsavelBairro = "";
         Z451ResponsavelCidade = "";
         Z452ResponsavelLogradouroNumero = 0;
         Z453ResponsavelComplemento = "";
         Z454ResponsavelDDD = 0;
         Z455ResponsavelNumero = 0;
         Z456ResponsavelEmail = "";
         Z884ClienteSituacao = "";
         Z885ResponsavelCargo = "";
         Z1039ClienteTipoRisco = "";
         Z192TipoClienteId = 0;
         Z186MunicipioCodigo = "";
         Z444ResponsavelMunicipio = "";
         Z402BancoId = 0;
         Z457EspecialidadeId = 0;
         Z437ResponsavelNacionalidade = 0;
         Z484ClienteNacionalidade = 0;
         Z442ResponsavelProfissao = 0;
         Z487ClienteProfissao = 0;
         Z489ClienteConvenio = 0;
      }

      protected void InitAll0O28( )
      {
         A168ClienteId = 0;
         n168ClienteId = false;
         AssignAttri("", false, "A168ClienteId", StringUtil.LTrimStr( (decimal)(A168ClienteId), 9, 0));
         InitializeNonKey0O28( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A175ClienteCreatedAt = i175ClienteCreatedAt;
         n175ClienteCreatedAt = false;
         AssignAttri("", false, "A175ClienteCreatedAt", context.localUtil.TToC( A175ClienteCreatedAt, 8, 5, 0, 3, "/", ":", " "));
         A174ClienteStatus = i174ClienteStatus;
         n174ClienteStatus = false;
         AssignAttri("", false, "A174ClienteStatus", A174ClienteStatus);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202561019135862", true, true);
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
         context.AddJavascriptSource("cliente.js", "?202561019135863", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtClienteDocumento_Internalname = "CLIENTEDOCUMENTO";
         edtClienteRazaoSocial_Internalname = "CLIENTERAZAOSOCIAL";
         edtClienteNomeFantasia_Internalname = "CLIENTENOMEFANTASIA";
         cmbClienteTipoPessoa_Internalname = "CLIENTETIPOPESSOA";
         edtTipoClienteDescricao_Internalname = "TIPOCLIENTEDESCRICAO";
         cmbClienteStatus_Internalname = "CLIENTESTATUS";
         cmbEnderecoTipo_Internalname = "ENDERECOTIPO";
         edtEnderecoCEP_Internalname = "ENDERECOCEP";
         edtEnderecoLogradouro_Internalname = "ENDERECOLOGRADOURO";
         edtEnderecoBairro_Internalname = "ENDERECOBAIRRO";
         edtEnderecoCidade_Internalname = "ENDERECOCIDADE";
         lblTextblockmunicipiocodigo_Internalname = "TEXTBLOCKMUNICIPIOCODIGO";
         Combo_municipiocodigo_Internalname = "COMBO_MUNICIPIOCODIGO";
         edtMunicipioCodigo_Internalname = "MUNICIPIOCODIGO";
         divTablesplittedmunicipiocodigo_Internalname = "TABLESPLITTEDMUNICIPIOCODIGO";
         edtMunicipioUF_Internalname = "MUNICIPIOUF";
         edtEnderecoNumero_Internalname = "ENDERECONUMERO";
         edtEnderecoComplemento_Internalname = "ENDERECOCOMPLEMENTO";
         edtContatoEmail_Internalname = "CONTATOEMAIL";
         edtContatoDDD_Internalname = "CONTATODDD";
         edtContatoNumero_Internalname = "CONTATONUMERO";
         edtContatoTelefoneNumero_Internalname = "CONTATOTELEFONENUMERO";
         edtContatoTelefoneDDD_Internalname = "CONTATOTELEFONEDDD";
         edtContatoTelefoneDDI_Internalname = "CONTATOTELEFONEDDI";
         edtContatoDDI_Internalname = "CONTATODDI";
         edtClienteTelefone_F_Internalname = "CLIENTETELEFONE_F";
         edtClienteCelular_F_Internalname = "CLIENTECELULAR_F";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombomunicipiocodigo_Internalname = "vCOMBOMUNICIPIOCODIGO";
         divSectionattribute_municipiocodigo_Internalname = "SECTIONATTRIBUTE_MUNICIPIOCODIGO";
         edtClienteId_Internalname = "CLIENTEID";
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
         Form.Caption = "Cliente";
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 0;
         edtClienteId_Visible = 1;
         edtavCombomunicipiocodigo_Jsonclick = "";
         edtavCombomunicipiocodigo_Enabled = 0;
         edtavCombomunicipiocodigo_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtClienteCelular_F_Jsonclick = "";
         edtClienteCelular_F_Enabled = 0;
         edtClienteTelefone_F_Jsonclick = "";
         edtClienteTelefone_F_Enabled = 0;
         edtContatoDDI_Jsonclick = "";
         edtContatoDDI_Enabled = 1;
         edtContatoTelefoneDDI_Jsonclick = "";
         edtContatoTelefoneDDI_Enabled = 1;
         edtContatoTelefoneDDD_Jsonclick = "";
         edtContatoTelefoneDDD_Enabled = 1;
         edtContatoTelefoneNumero_Jsonclick = "";
         edtContatoTelefoneNumero_Enabled = 1;
         edtContatoNumero_Jsonclick = "";
         edtContatoNumero_Enabled = 1;
         edtContatoDDD_Jsonclick = "";
         edtContatoDDD_Enabled = 1;
         edtContatoEmail_Jsonclick = "";
         edtContatoEmail_Enabled = 1;
         edtEnderecoComplemento_Jsonclick = "";
         edtEnderecoComplemento_Enabled = 1;
         edtEnderecoNumero_Jsonclick = "";
         edtEnderecoNumero_Enabled = 1;
         edtMunicipioUF_Jsonclick = "";
         edtMunicipioUF_Enabled = 0;
         edtMunicipioCodigo_Jsonclick = "";
         edtMunicipioCodigo_Enabled = 1;
         edtMunicipioCodigo_Visible = 1;
         Combo_municipiocodigo_Datalistprocparametersprefix = " \"ComboName\": \"MunicipioCodigo\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"ClienteId\": 0";
         Combo_municipiocodigo_Datalistproc = "ClienteLoadDVCombo";
         Combo_municipiocodigo_Cls = "ExtendedCombo AttributeFL";
         Combo_municipiocodigo_Caption = "";
         Combo_municipiocodigo_Enabled = Convert.ToBoolean( -1);
         edtEnderecoCidade_Jsonclick = "";
         edtEnderecoCidade_Enabled = 1;
         edtEnderecoBairro_Jsonclick = "";
         edtEnderecoBairro_Enabled = 1;
         edtEnderecoLogradouro_Jsonclick = "";
         edtEnderecoLogradouro_Enabled = 1;
         edtEnderecoCEP_Jsonclick = "";
         edtEnderecoCEP_Enabled = 1;
         cmbEnderecoTipo_Jsonclick = "";
         cmbEnderecoTipo.Enabled = 1;
         cmbClienteStatus_Jsonclick = "";
         cmbClienteStatus.Enabled = 1;
         edtTipoClienteDescricao_Jsonclick = "";
         edtTipoClienteDescricao_Enabled = 0;
         cmbClienteTipoPessoa_Jsonclick = "";
         cmbClienteTipoPessoa.Enabled = 1;
         edtClienteNomeFantasia_Jsonclick = "";
         edtClienteNomeFantasia_Enabled = 1;
         edtClienteRazaoSocial_Jsonclick = "";
         edtClienteRazaoSocial_Enabled = 1;
         edtClienteDocumento_Jsonclick = "";
         edtClienteDocumento_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "";
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

      protected void GX8ASARESPONSAVELCELULAR_F0O28( short A454ResponsavelDDD ,
                                                     int A455ResponsavelNumero )
      {
         GXt_char2 = A577ResponsavelCelular_F;
         new prformatacelular(context ).execute(  StringUtil.Format( "%1%2", StringUtil.LTrimStr( (decimal)(A454ResponsavelDDD), 4, 0), StringUtil.LTrimStr( (decimal)(A455ResponsavelNumero), 9, 0), "", "", "", "", "", "", ""), out  GXt_char2) ;
         n454ResponsavelDDD = ((0==A454ResponsavelDDD) ? true : false);
         A577ResponsavelCelular_F = GXt_char2;
         AssignAttri("", false, "A577ResponsavelCelular_F", A577ResponsavelCelular_F);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A577ResponsavelCelular_F)+"\"") ;
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
         cmbClienteTipoPessoa.Name = "CLIENTETIPOPESSOA";
         cmbClienteTipoPessoa.WebTags = "";
         cmbClienteTipoPessoa.addItem("FISICA", "Física", 0);
         cmbClienteTipoPessoa.addItem("JURIDICA", "Jurídica", 0);
         if ( cmbClienteTipoPessoa.ItemCount > 0 )
         {
            A172ClienteTipoPessoa = cmbClienteTipoPessoa.getValidValue(A172ClienteTipoPessoa);
            n172ClienteTipoPessoa = false;
            AssignAttri("", false, "A172ClienteTipoPessoa", A172ClienteTipoPessoa);
         }
         cmbClienteStatus.Name = "CLIENTESTATUS";
         cmbClienteStatus.WebTags = "";
         cmbClienteStatus.addItem(StringUtil.BoolToStr( true), "ATIVO", 0);
         cmbClienteStatus.addItem(StringUtil.BoolToStr( false), "INATIVO", 0);
         if ( cmbClienteStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (false==A174ClienteStatus) )
            {
               A174ClienteStatus = true;
               n174ClienteStatus = false;
               AssignAttri("", false, "A174ClienteStatus", A174ClienteStatus);
            }
         }
         cmbEnderecoTipo.Name = "ENDERECOTIPO";
         cmbEnderecoTipo.WebTags = "";
         cmbEnderecoTipo.addItem("COBRANCA", "Cobrança", 0);
         cmbEnderecoTipo.addItem("ENTREGA", "Entrega", 0);
         if ( cmbEnderecoTipo.ItemCount > 0 )
         {
            A181EnderecoTipo = cmbEnderecoTipo.getValidValue(A181EnderecoTipo);
            n181EnderecoTipo = false;
            AssignAttri("", false, "A181EnderecoTipo", A181EnderecoTipo);
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

      public void Valid_Clienteid( )
      {
         n168ClienteId = false;
         n310ClienteValorAPagar_F = false;
         n311ClienteValorAReceber_F = false;
         n1031RelacionamentoSacado = false;
         n608SecUserId_F = false;
         n309ClienteQtdTitulos_F = false;
         /* Using cursor T000O77 */
         pr_default.execute(45, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(45) != 101) )
         {
            A608SecUserId_F = T000O77_A608SecUserId_F[0];
            n608SecUserId_F = T000O77_n608SecUserId_F[0];
         }
         else
         {
            A608SecUserId_F = 0;
            n608SecUserId_F = false;
         }
         pr_default.close(45);
         /* Using cursor T000O79 */
         pr_default.execute(46, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(46) != 101) )
         {
            A309ClienteQtdTitulos_F = T000O79_A309ClienteQtdTitulos_F[0];
            n309ClienteQtdTitulos_F = T000O79_n309ClienteQtdTitulos_F[0];
         }
         else
         {
            A309ClienteQtdTitulos_F = 0;
            n309ClienteQtdTitulos_F = false;
         }
         pr_default.close(46);
         /* Using cursor T000O83 */
         pr_default.execute(47, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(47) != 101) )
         {
            A310ClienteValorAPagar_F = T000O83_A310ClienteValorAPagar_F[0];
            n310ClienteValorAPagar_F = T000O83_n310ClienteValorAPagar_F[0];
         }
         else
         {
            A310ClienteValorAPagar_F = 0;
            n310ClienteValorAPagar_F = false;
         }
         pr_default.close(47);
         if ( ( A310ClienteValorAPagar_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
         }
         /* Using cursor T000O86 */
         pr_default.execute(48, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(48) != 101) )
         {
            A311ClienteValorAReceber_F = T000O86_A311ClienteValorAReceber_F[0];
            n311ClienteValorAReceber_F = T000O86_n311ClienteValorAReceber_F[0];
         }
         else
         {
            A311ClienteValorAReceber_F = 0;
            n311ClienteValorAReceber_F = false;
         }
         pr_default.close(48);
         if ( ( A311ClienteValorAReceber_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
         }
         /* Using cursor T000O88 */
         pr_default.execute(49, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(49) != 101) )
         {
            A780SerasaUltimaData_F = T000O88_A780SerasaUltimaData_F[0];
            A732SerasaConsultas_F = T000O88_A732SerasaConsultas_F[0];
         }
         else
         {
            A732SerasaConsultas_F = 0;
            A780SerasaUltimaData_F = (DateTime)(DateTime.MinValue);
         }
         pr_default.close(49);
         /* Using cursor T000O90 */
         pr_default.execute(50, new Object[] {A780SerasaUltimaData_F, n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(50) != 101) )
         {
            A781SerasaScoreUltimaData_F = T000O90_A781SerasaScoreUltimaData_F[0];
            A785SerasaUltimoValorRecomendado_F = T000O90_A785SerasaUltimoValorRecomendado_F[0];
         }
         else
         {
            A781SerasaScoreUltimaData_F = 0;
            A785SerasaUltimoValorRecomendado_F = 0;
         }
         pr_default.close(50);
         if ( ( A785SerasaUltimoValorRecomendado_F < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
         }
         /* Using cursor T000O92 */
         pr_default.execute(51, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(51) != 101) )
         {
            A1031RelacionamentoSacado = T000O92_A1031RelacionamentoSacado[0];
            n1031RelacionamentoSacado = T000O92_n1031RelacionamentoSacado[0];
         }
         else
         {
            A1031RelacionamentoSacado = 0;
            n1031RelacionamentoSacado = false;
         }
         pr_default.close(51);
         A1030ClienteSacado = ((A1031RelacionamentoSacado==0) ? false : true);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A608SecUserId_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A608SecUserId_F), 4, 0, ".", "")));
         AssignAttri("", false, "A309ClienteQtdTitulos_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A309ClienteQtdTitulos_F), 9, 0, ".", "")));
         AssignAttri("", false, "A310ClienteValorAPagar_F", StringUtil.LTrim( StringUtil.NToC( A310ClienteValorAPagar_F, 18, 2, ".", "")));
         AssignAttri("", false, "A311ClienteValorAReceber_F", StringUtil.LTrim( StringUtil.NToC( A311ClienteValorAReceber_F, 18, 2, ".", "")));
         AssignAttri("", false, "A780SerasaUltimaData_F", context.localUtil.TToC( A780SerasaUltimaData_F, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A732SerasaConsultas_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A732SerasaConsultas_F), 4, 0, ".", "")));
         AssignAttri("", false, "A781SerasaScoreUltimaData_F", StringUtil.LTrim( StringUtil.NToC( (decimal)(A781SerasaScoreUltimaData_F), 4, 0, ".", "")));
         AssignAttri("", false, "A785SerasaUltimoValorRecomendado_F", StringUtil.LTrim( StringUtil.NToC( A785SerasaUltimoValorRecomendado_F, 18, 2, ".", "")));
         AssignAttri("", false, "A1031RelacionamentoSacado", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1031RelacionamentoSacado), 4, 0, ".", "")));
         AssignAttri("", false, "A1030ClienteSacado", A1030ClienteSacado);
      }

      public void Valid_Clientedocumento( )
      {
         n169ClienteDocumento = false;
         n168ClienteId = false;
         /* Using cursor T000O124 */
         pr_default.execute(83, new Object[] {n169ClienteDocumento, A169ClienteDocumento, n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(83) != 101) )
         {
            GX_msglist.addItem("Documento já está sendo utilizado", 1, "CLIENTEDOCUMENTO");
            AnyError = 1;
            GX_FocusControl = edtClienteDocumento_Internalname;
         }
         pr_default.close(83);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Municipiocodigo( )
      {
         n186MunicipioCodigo = false;
         n187MunicipioNome = false;
         n189MunicipioUF = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV17Insert_MunicipioCodigo)) )
         {
            A186MunicipioCodigo = AV17Insert_MunicipioCodigo;
            n186MunicipioCodigo = false;
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV23ComboMunicipioCodigo)) )
            {
               A186MunicipioCodigo = "";
               n186MunicipioCodigo = false;
               n186MunicipioCodigo = true;
               n186MunicipioCodigo = true;
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23ComboMunicipioCodigo)) )
               {
                  A186MunicipioCodigo = AV23ComboMunicipioCodigo;
                  n186MunicipioCodigo = false;
               }
               else
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) )
                  {
                     A186MunicipioCodigo = "";
                     n186MunicipioCodigo = false;
                     n186MunicipioCodigo = true;
                     n186MunicipioCodigo = true;
                  }
               }
            }
         }
         /* Using cursor T000O93 */
         pr_default.execute(52, new Object[] {n186MunicipioCodigo, A186MunicipioCodigo});
         if ( (pr_default.getStatus(52) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A186MunicipioCodigo)) ) )
            {
               GX_msglist.addItem("Não existe 'Municipio'.", "ForeignKeyNotFound", 1, "MUNICIPIOCODIGO");
               AnyError = 1;
               GX_FocusControl = edtMunicipioCodigo_Internalname;
            }
         }
         A187MunicipioNome = T000O93_A187MunicipioNome[0];
         n187MunicipioNome = T000O93_n187MunicipioNome[0];
         A189MunicipioUF = T000O93_A189MunicipioUF[0];
         n189MunicipioUF = T000O93_n189MunicipioUF[0];
         pr_default.close(52);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A186MunicipioCodigo", A186MunicipioCodigo);
         AssignAttri("", false, "A187MunicipioNome", A187MunicipioNome);
         AssignAttri("", false, "A189MunicipioUF", A189MunicipioUF);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","""{"handler":"UserMainFullajax","iparms":[{"postForm":true},{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"}]}""");
         setEventMetadata("REFRESH","""{"handler":"Refresh","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV12TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""},{"av":"AV7ClienteId","fld":"vCLIENTEID","pic":"ZZZZZZZZ9","hsh":true,"type":"int"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV29Insert_EspecialidadeId","fld":"vINSERT_ESPECIALIDADEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV14Insert_TipoClienteId","fld":"vINSERT_TIPOCLIENTEID","pic":"ZZZ9","type":"int"},{"av":"AV32Insert_ClienteConvenio","fld":"vINSERT_CLIENTECONVENIO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV30Insert_ClienteNacionalidade","fld":"vINSERT_CLIENTENACIONALIDADE","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV31Insert_ClienteProfissao","fld":"vINSERT_CLIENTEPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV17Insert_MunicipioCodigo","fld":"vINSERT_MUNICIPIOCODIGO","type":"svchar"},{"av":"AV25Insert_BancoId","fld":"vINSERT_BANCOID","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV26Insert_ResponsavelNacionalidade","fld":"vINSERT_RESPONSAVELNACIONALIDADE","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV27Insert_ResponsavelProfissao","fld":"vINSERT_RESPONSAVELPROFISSAO","pic":"ZZZZZZZZ9","type":"int"},{"av":"AV28Insert_ResponsavelMunicipio","fld":"vINSERT_RESPONSAVELMUNICIPIO","type":"svchar"},{"av":"A175ClienteCreatedAt","fld":"CLIENTECREATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A176ClienteUpdatedAt","fld":"CLIENTEUPDATEDAT","pic":"99/99/99 99:99","type":"dtime"},{"av":"A459ClienteDataNascimento","fld":"CLIENTEDATANASCIMENTO","type":"date"},{"av":"A177ClienteLogUser","fld":"CLIENTELOGUSER","pic":"ZZZ9","nullAv":"n177ClienteLogUser","type":"int"},{"av":"A486ClienteEstadoCivil","fld":"CLIENTEESTADOCIVIL","type":"svchar"},{"av":"A421ClienteRG","fld":"CLIENTERG","pic":"ZZZZZZZZZZZ9","nullAv":"n421ClienteRG","type":"int"},{"av":"A537ClienteDepositoTipo","fld":"CLIENTEDEPOSITOTIPO","type":"svchar"},{"av":"A538ClientePixTipo","fld":"CLIENTEPIXTIPO","type":"svchar"},{"av":"A539ClientePix","fld":"CLIENTEPIX","type":"svchar"},{"av":"A400ContaAgencia","fld":"CONTAAGENCIA","type":"svchar"},{"av":"A401ContaNumero","fld":"CONTANUMERO","type":"svchar"},{"av":"A436ResponsavelNome","fld":"RESPONSAVELNOME","type":"svchar"},{"av":"A439ResponsavelEstadoCivil","fld":"RESPONSAVELESTADOCIVIL","type":"svchar"},{"av":"A576ResponsavelRG","fld":"RESPONSAVELRG","pic":"ZZZZZZZZZZZ9","nullAv":"n576ResponsavelRG","type":"int"},{"av":"A447ResponsavelCPF","fld":"RESPONSAVELCPF","type":"svchar"},{"av":"A448ResponsavelCEP","fld":"RESPONSAVELCEP","type":"svchar"},{"av":"A449ResponsavelLogradouro","fld":"RESPONSAVELLOGRADOURO","type":"svchar"},{"av":"A450ResponsavelBairro","fld":"RESPONSAVELBAIRRO","type":"svchar"},{"av":"A451ResponsavelCidade","fld":"RESPONSAVELCIDADE","type":"svchar"},{"av":"A452ResponsavelLogradouroNumero","fld":"RESPONSAVELLOGRADOURONUMERO","pic":"ZZZZZZZZ9","nullAv":"n452ResponsavelLogradouroNumero","type":"int"},{"av":"A453ResponsavelComplemento","fld":"RESPONSAVELCOMPLEMENTO","type":"svchar"},{"av":"A454ResponsavelDDD","fld":"RESPONSAVELDDD","pic":"ZZZ9","nullAv":"n454ResponsavelDDD","type":"int"},{"av":"A455ResponsavelNumero","fld":"RESPONSAVELNUMERO","pic":"ZZZZZZZZ9","nullAv":"n455ResponsavelNumero","type":"int"},{"av":"A456ResponsavelEmail","fld":"RESPONSAVELEMAIL","type":"svchar"},{"av":"A884ClienteSituacao","fld":"CLIENTESITUACAO","type":"char"},{"av":"A885ResponsavelCargo","fld":"RESPONSAVELCARGO","type":"svchar"},{"av":"A1039ClienteTipoRisco","fld":"CLIENTETIPORISCO","type":"svchar"}]}""");
         setEventMetadata("AFTER TRN","""{"handler":"E120O2","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV12TrnContext","fld":"vTRNCONTEXT","hsh":true,"type":""}]}""");
         setEventMetadata("VALID_CLIENTEDOCUMENTO","""{"handler":"Valid_Clientedocumento","iparms":[{"av":"A169ClienteDocumento","fld":"CLIENTEDOCUMENTO","type":"svchar"},{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"}]}""");
         setEventMetadata("VALID_CLIENTETIPOPESSOA","""{"handler":"Valid_Clientetipopessoa","iparms":[]}""");
         setEventMetadata("VALID_ENDERECOTIPO","""{"handler":"Valid_Enderecotipo","iparms":[]}""");
         setEventMetadata("VALID_MUNICIPIOCODIGO","""{"handler":"Valid_Municipiocodigo","iparms":[{"av":"Gx_mode","fld":"vMODE","pic":"@!","hsh":true,"type":"char"},{"av":"AV17Insert_MunicipioCodigo","fld":"vINSERT_MUNICIPIOCODIGO","type":"svchar"},{"av":"AV23ComboMunicipioCodigo","fld":"vCOMBOMUNICIPIOCODIGO","type":"svchar"},{"av":"A186MunicipioCodigo","fld":"MUNICIPIOCODIGO","type":"svchar"},{"av":"A187MunicipioNome","fld":"MUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"A189MunicipioUF","fld":"MUNICIPIOUF","pic":"@!","type":"svchar"}]""");
         setEventMetadata("VALID_MUNICIPIOCODIGO",""","oparms":[{"av":"A186MunicipioCodigo","fld":"MUNICIPIOCODIGO","type":"svchar"},{"av":"A187MunicipioNome","fld":"MUNICIPIONOME","pic":"@!","type":"svchar"},{"av":"A189MunicipioUF","fld":"MUNICIPIOUF","pic":"@!","type":"svchar"}]}""");
         setEventMetadata("VALID_CONTATOEMAIL","""{"handler":"Valid_Contatoemail","iparms":[]}""");
         setEventMetadata("VALID_CONTATODDD","""{"handler":"Valid_Contatoddd","iparms":[]}""");
         setEventMetadata("VALID_CONTATONUMERO","""{"handler":"Valid_Contatonumero","iparms":[]}""");
         setEventMetadata("VALID_CONTATOTELEFONENUMERO","""{"handler":"Valid_Contatotelefonenumero","iparms":[]}""");
         setEventMetadata("VALID_CONTATOTELEFONEDDD","""{"handler":"Valid_Contatotelefoneddd","iparms":[]}""");
         setEventMetadata("VALIDV_COMBOMUNICIPIOCODIGO","""{"handler":"Validv_Combomunicipiocodigo","iparms":[]}""");
         setEventMetadata("VALID_CLIENTEID","""{"handler":"Valid_Clienteid","iparms":[{"av":"A168ClienteId","fld":"CLIENTEID","pic":"ZZZZZZZZ9","type":"int"},{"av":"A310ClienteValorAPagar_F","fld":"CLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A311ClienteValorAReceber_F","fld":"CLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A780SerasaUltimaData_F","fld":"SERASAULTIMADATA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"A785SerasaUltimoValorRecomendado_F","fld":"SERASAULTIMOVALORRECOMENDADO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A1031RelacionamentoSacado","fld":"RELACIONAMENTOSACADO","pic":"ZZZ9","type":"int"},{"av":"A608SecUserId_F","fld":"SECUSERID_F","pic":"ZZZ9","type":"int"},{"av":"A309ClienteQtdTitulos_F","fld":"CLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"A732SerasaConsultas_F","fld":"SERASACONSULTAS_F","pic":"ZZZ9","type":"int"},{"av":"A781SerasaScoreUltimaData_F","fld":"SERASASCOREULTIMADATA_F","pic":"ZZZ9","type":"int"},{"av":"A1030ClienteSacado","fld":"CLIENTESACADO","type":"boolean"}]""");
         setEventMetadata("VALID_CLIENTEID",""","oparms":[{"av":"A608SecUserId_F","fld":"SECUSERID_F","pic":"ZZZ9","type":"int"},{"av":"A309ClienteQtdTitulos_F","fld":"CLIENTEQTDTITULOS_F","pic":"ZZZZZZZZ9","type":"int"},{"av":"A310ClienteValorAPagar_F","fld":"CLIENTEVALORAPAGAR_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A311ClienteValorAReceber_F","fld":"CLIENTEVALORARECEBER_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A780SerasaUltimaData_F","fld":"SERASAULTIMADATA_F","pic":"99/99/99 99:99","type":"dtime"},{"av":"A732SerasaConsultas_F","fld":"SERASACONSULTAS_F","pic":"ZZZ9","type":"int"},{"av":"A781SerasaScoreUltimaData_F","fld":"SERASASCOREULTIMADATA_F","pic":"ZZZ9","type":"int"},{"av":"A785SerasaUltimoValorRecomendado_F","fld":"SERASAULTIMOVALORRECOMENDADO_F","pic":"ZZZ,ZZZ,ZZZ,ZZ9.99","type":"decimal"},{"av":"A1031RelacionamentoSacado","fld":"RELACIONAMENTOSACADO","pic":"ZZZ9","type":"int"},{"av":"A1030ClienteSacado","fld":"CLIENTESACADO","type":"boolean"}]}""");
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
         pr_default.close(53);
         pr_default.close(52);
         pr_default.close(54);
         pr_default.close(55);
         pr_default.close(56);
         pr_default.close(57);
         pr_default.close(58);
         pr_default.close(59);
         pr_default.close(60);
         pr_default.close(50);
         pr_default.close(45);
         pr_default.close(46);
         pr_default.close(47);
         pr_default.close(48);
         pr_default.close(49);
         pr_default.close(51);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         Z176ClienteUpdatedAt = (DateTime)(DateTime.MinValue);
         Z169ClienteDocumento = "";
         Z170ClienteRazaoSocial = "";
         Z171ClienteNomeFantasia = "";
         Z459ClienteDataNascimento = DateTime.MinValue;
         Z172ClienteTipoPessoa = "";
         Z486ClienteEstadoCivil = "";
         Z181EnderecoTipo = "";
         Z182EnderecoCEP = "";
         Z183EnderecoLogradouro = "";
         Z184EnderecoBairro = "";
         Z185EnderecoCidade = "";
         Z190EnderecoNumero = "";
         Z191EnderecoComplemento = "";
         Z201ContatoEmail = "";
         Z537ClienteDepositoTipo = "";
         Z538ClientePixTipo = "";
         Z539ClientePix = "";
         Z400ContaAgencia = "";
         Z401ContaNumero = "";
         Z436ResponsavelNome = "";
         Z439ResponsavelEstadoCivil = "";
         Z447ResponsavelCPF = "";
         Z448ResponsavelCEP = "";
         Z449ResponsavelLogradouro = "";
         Z450ResponsavelBairro = "";
         Z451ResponsavelCidade = "";
         Z453ResponsavelComplemento = "";
         Z456ResponsavelEmail = "";
         Z884ClienteSituacao = "";
         Z885ResponsavelCargo = "";
         Z1039ClienteTipoRisco = "";
         Z186MunicipioCodigo = "";
         Z444ResponsavelMunicipio = "";
         N186MunicipioCodigo = "";
         N444ResponsavelMunicipio = "";
         Combo_municipiocodigo_Selectedvalue_get = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A780SerasaUltimaData_F = (DateTime)(DateTime.MinValue);
         A186MunicipioCodigo = "";
         A444ResponsavelMunicipio = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A172ClienteTipoPessoa = "";
         A181EnderecoTipo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A169ClienteDocumento = "";
         A170ClienteRazaoSocial = "";
         A171ClienteNomeFantasia = "";
         A193TipoClienteDescricao = "";
         A182EnderecoCEP = "";
         A183EnderecoLogradouro = "";
         A184EnderecoBairro = "";
         A185EnderecoCidade = "";
         lblTextblockmunicipiocodigo_Jsonclick = "";
         ucCombo_municipiocodigo = new GXUserControl();
         AV19DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV18MunicipioCodigo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A189MunicipioUF = "";
         A190EnderecoNumero = "";
         A191EnderecoComplemento = "";
         A201ContatoEmail = "";
         A205ClienteTelefone_F = "";
         A206ClienteCelular_F = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV23ComboMunicipioCodigo = "";
         A175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         A176ClienteUpdatedAt = (DateTime)(DateTime.MinValue);
         A459ClienteDataNascimento = DateTime.MinValue;
         A486ClienteEstadoCivil = "";
         A537ClienteDepositoTipo = "";
         A538ClientePixTipo = "";
         A539ClientePix = "";
         A400ContaAgencia = "";
         A401ContaNumero = "";
         A436ResponsavelNome = "";
         A439ResponsavelEstadoCivil = "";
         A447ResponsavelCPF = "";
         A448ResponsavelCEP = "";
         A449ResponsavelLogradouro = "";
         A450ResponsavelBairro = "";
         A451ResponsavelCidade = "";
         A453ResponsavelComplemento = "";
         A456ResponsavelEmail = "";
         A884ClienteSituacao = "";
         A885ResponsavelCargo = "";
         A1039ClienteTipoRisco = "";
         A577ResponsavelCelular_F = "";
         AV17Insert_MunicipioCodigo = "";
         AV28Insert_ResponsavelMunicipio = "";
         A187MunicipioNome = "";
         A446ResponsavelMunicipioUF = "";
         A445ResponsavelMunicipioNome = "";
         A403BancoNome = "";
         A438ResponsavelNacionalidadeNome = "";
         A485ClienteNacionalidadeNome = "";
         A443ResponsavelProfissaoNome = "";
         A488ClienteProfissaoNome = "";
         A490ClienteConvenioDescricao = "";
         AV35Pgmname = "";
         Combo_municipiocodigo_Objectcall = "";
         Combo_municipiocodigo_Class = "";
         Combo_municipiocodigo_Icontype = "";
         Combo_municipiocodigo_Icon = "";
         Combo_municipiocodigo_Tooltip = "";
         Combo_municipiocodigo_Selectedvalue_set = "";
         Combo_municipiocodigo_Selectedtext_set = "";
         Combo_municipiocodigo_Selectedtext_get = "";
         Combo_municipiocodigo_Gamoauthtoken = "";
         Combo_municipiocodigo_Ddointernalname = "";
         Combo_municipiocodigo_Titlecontrolalign = "";
         Combo_municipiocodigo_Dropdownoptionstype = "";
         Combo_municipiocodigo_Titlecontrolidtoreplace = "";
         Combo_municipiocodigo_Datalisttype = "";
         Combo_municipiocodigo_Datalistfixedvalues = "";
         Combo_municipiocodigo_Remoteservicesparameters = "";
         Combo_municipiocodigo_Htmltemplate = "";
         Combo_municipiocodigo_Multiplevaluestype = "";
         Combo_municipiocodigo_Loadingdata = "";
         Combo_municipiocodigo_Noresultsfound = "";
         Combo_municipiocodigo_Emptyitemtext = "";
         Combo_municipiocodigo_Onlyselectedvalues = "";
         Combo_municipiocodigo_Selectalltext = "";
         Combo_municipiocodigo_Multiplevaluesseparator = "";
         Combo_municipiocodigo_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_tableattributes_Titletype = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode28 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         AV16TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV22Combo_DataJson = "";
         AV20ComboSelectedValue = "";
         AV21ComboSelectedText = "";
         Z193TipoClienteDescricao = "";
         Z446ResponsavelMunicipioUF = "";
         Z445ResponsavelMunicipioNome = "";
         Z403BancoNome = "";
         Z438ResponsavelNacionalidadeNome = "";
         Z485ClienteNacionalidadeNome = "";
         Z443ResponsavelProfissaoNome = "";
         Z488ClienteProfissaoNome = "";
         Z490ClienteConvenioDescricao = "";
         Z780SerasaUltimaData_F = (DateTime)(DateTime.MinValue);
         Z187MunicipioNome = "";
         Z189MunicipioUF = "";
         T000O17_A608SecUserId_F = new short[1] ;
         T000O17_n608SecUserId_F = new bool[] {false} ;
         T000O19_A309ClienteQtdTitulos_F = new int[1] ;
         T000O19_n309ClienteQtdTitulos_F = new bool[] {false} ;
         T000O23_A310ClienteValorAPagar_F = new decimal[1] ;
         T000O23_n310ClienteValorAPagar_F = new bool[] {false} ;
         T000O26_A311ClienteValorAReceber_F = new decimal[1] ;
         T000O26_n311ClienteValorAReceber_F = new bool[] {false} ;
         T000O28_A780SerasaUltimaData_F = new DateTime[] {DateTime.MinValue} ;
         T000O28_A732SerasaConsultas_F = new short[1] ;
         T000O15_A781SerasaScoreUltimaData_F = new short[1] ;
         T000O15_A785SerasaUltimoValorRecomendado_F = new decimal[1] ;
         T000O30_A1031RelacionamentoSacado = new short[1] ;
         T000O30_n1031RelacionamentoSacado = new bool[] {false} ;
         T000O40_A168ClienteId = new int[1] ;
         T000O40_n168ClienteId = new bool[] {false} ;
         T000O40_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T000O40_n175ClienteCreatedAt = new bool[] {false} ;
         T000O40_A176ClienteUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T000O40_n176ClienteUpdatedAt = new bool[] {false} ;
         T000O40_A169ClienteDocumento = new string[] {""} ;
         T000O40_n169ClienteDocumento = new bool[] {false} ;
         T000O40_A170ClienteRazaoSocial = new string[] {""} ;
         T000O40_n170ClienteRazaoSocial = new bool[] {false} ;
         T000O40_A171ClienteNomeFantasia = new string[] {""} ;
         T000O40_n171ClienteNomeFantasia = new bool[] {false} ;
         T000O40_A459ClienteDataNascimento = new DateTime[] {DateTime.MinValue} ;
         T000O40_n459ClienteDataNascimento = new bool[] {false} ;
         T000O40_A172ClienteTipoPessoa = new string[] {""} ;
         T000O40_n172ClienteTipoPessoa = new bool[] {false} ;
         T000O40_A193TipoClienteDescricao = new string[] {""} ;
         T000O40_n193TipoClienteDescricao = new bool[] {false} ;
         T000O40_A207TipoClientePortal = new bool[] {false} ;
         T000O40_n207TipoClientePortal = new bool[] {false} ;
         T000O40_A174ClienteStatus = new bool[] {false} ;
         T000O40_n174ClienteStatus = new bool[] {false} ;
         T000O40_A490ClienteConvenioDescricao = new string[] {""} ;
         T000O40_n490ClienteConvenioDescricao = new bool[] {false} ;
         T000O40_A177ClienteLogUser = new short[1] ;
         T000O40_n177ClienteLogUser = new bool[] {false} ;
         T000O40_A485ClienteNacionalidadeNome = new string[] {""} ;
         T000O40_n485ClienteNacionalidadeNome = new bool[] {false} ;
         T000O40_A488ClienteProfissaoNome = new string[] {""} ;
         T000O40_n488ClienteProfissaoNome = new bool[] {false} ;
         T000O40_A486ClienteEstadoCivil = new string[] {""} ;
         T000O40_n486ClienteEstadoCivil = new bool[] {false} ;
         T000O40_A181EnderecoTipo = new string[] {""} ;
         T000O40_n181EnderecoTipo = new bool[] {false} ;
         T000O40_A182EnderecoCEP = new string[] {""} ;
         T000O40_n182EnderecoCEP = new bool[] {false} ;
         T000O40_A183EnderecoLogradouro = new string[] {""} ;
         T000O40_n183EnderecoLogradouro = new bool[] {false} ;
         T000O40_A184EnderecoBairro = new string[] {""} ;
         T000O40_n184EnderecoBairro = new bool[] {false} ;
         T000O40_A185EnderecoCidade = new string[] {""} ;
         T000O40_n185EnderecoCidade = new bool[] {false} ;
         T000O40_A187MunicipioNome = new string[] {""} ;
         T000O40_n187MunicipioNome = new bool[] {false} ;
         T000O40_A189MunicipioUF = new string[] {""} ;
         T000O40_n189MunicipioUF = new bool[] {false} ;
         T000O40_A190EnderecoNumero = new string[] {""} ;
         T000O40_n190EnderecoNumero = new bool[] {false} ;
         T000O40_A191EnderecoComplemento = new string[] {""} ;
         T000O40_n191EnderecoComplemento = new bool[] {false} ;
         T000O40_A201ContatoEmail = new string[] {""} ;
         T000O40_n201ContatoEmail = new bool[] {false} ;
         T000O40_A198ContatoDDD = new short[1] ;
         T000O40_n198ContatoDDD = new bool[] {false} ;
         T000O40_A199ContatoDDI = new short[1] ;
         T000O40_n199ContatoDDI = new bool[] {false} ;
         T000O40_A200ContatoNumero = new long[1] ;
         T000O40_n200ContatoNumero = new bool[] {false} ;
         T000O40_A202ContatoTelefoneNumero = new long[1] ;
         T000O40_n202ContatoTelefoneNumero = new bool[] {false} ;
         T000O40_A203ContatoTelefoneDDD = new short[1] ;
         T000O40_n203ContatoTelefoneDDD = new bool[] {false} ;
         T000O40_A204ContatoTelefoneDDI = new short[1] ;
         T000O40_n204ContatoTelefoneDDI = new bool[] {false} ;
         T000O40_A421ClienteRG = new long[1] ;
         T000O40_n421ClienteRG = new bool[] {false} ;
         T000O40_A537ClienteDepositoTipo = new string[] {""} ;
         T000O40_n537ClienteDepositoTipo = new bool[] {false} ;
         T000O40_A538ClientePixTipo = new string[] {""} ;
         T000O40_n538ClientePixTipo = new bool[] {false} ;
         T000O40_A539ClientePix = new string[] {""} ;
         T000O40_n539ClientePix = new bool[] {false} ;
         T000O40_A404BancoCodigo = new int[1] ;
         T000O40_n404BancoCodigo = new bool[] {false} ;
         T000O40_A403BancoNome = new string[] {""} ;
         T000O40_n403BancoNome = new bool[] {false} ;
         T000O40_A400ContaAgencia = new string[] {""} ;
         T000O40_n400ContaAgencia = new bool[] {false} ;
         T000O40_A401ContaNumero = new string[] {""} ;
         T000O40_n401ContaNumero = new bool[] {false} ;
         T000O40_A436ResponsavelNome = new string[] {""} ;
         T000O40_n436ResponsavelNome = new bool[] {false} ;
         T000O40_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         T000O40_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         T000O40_A439ResponsavelEstadoCivil = new string[] {""} ;
         T000O40_n439ResponsavelEstadoCivil = new bool[] {false} ;
         T000O40_A576ResponsavelRG = new long[1] ;
         T000O40_n576ResponsavelRG = new bool[] {false} ;
         T000O40_A443ResponsavelProfissaoNome = new string[] {""} ;
         T000O40_n443ResponsavelProfissaoNome = new bool[] {false} ;
         T000O40_A447ResponsavelCPF = new string[] {""} ;
         T000O40_n447ResponsavelCPF = new bool[] {false} ;
         T000O40_A448ResponsavelCEP = new string[] {""} ;
         T000O40_n448ResponsavelCEP = new bool[] {false} ;
         T000O40_A449ResponsavelLogradouro = new string[] {""} ;
         T000O40_n449ResponsavelLogradouro = new bool[] {false} ;
         T000O40_A450ResponsavelBairro = new string[] {""} ;
         T000O40_n450ResponsavelBairro = new bool[] {false} ;
         T000O40_A451ResponsavelCidade = new string[] {""} ;
         T000O40_n451ResponsavelCidade = new bool[] {false} ;
         T000O40_A446ResponsavelMunicipioUF = new string[] {""} ;
         T000O40_n446ResponsavelMunicipioUF = new bool[] {false} ;
         T000O40_A445ResponsavelMunicipioNome = new string[] {""} ;
         T000O40_n445ResponsavelMunicipioNome = new bool[] {false} ;
         T000O40_A452ResponsavelLogradouroNumero = new int[1] ;
         T000O40_n452ResponsavelLogradouroNumero = new bool[] {false} ;
         T000O40_A453ResponsavelComplemento = new string[] {""} ;
         T000O40_n453ResponsavelComplemento = new bool[] {false} ;
         T000O40_A454ResponsavelDDD = new short[1] ;
         T000O40_n454ResponsavelDDD = new bool[] {false} ;
         T000O40_A455ResponsavelNumero = new int[1] ;
         T000O40_n455ResponsavelNumero = new bool[] {false} ;
         T000O40_A456ResponsavelEmail = new string[] {""} ;
         T000O40_n456ResponsavelEmail = new bool[] {false} ;
         T000O40_A884ClienteSituacao = new string[] {""} ;
         T000O40_n884ClienteSituacao = new bool[] {false} ;
         T000O40_A885ResponsavelCargo = new string[] {""} ;
         T000O40_n885ResponsavelCargo = new bool[] {false} ;
         T000O40_A793TipoClientePortalPjPf = new bool[] {false} ;
         T000O40_n793TipoClientePortalPjPf = new bool[] {false} ;
         T000O40_A1039ClienteTipoRisco = new string[] {""} ;
         T000O40_A192TipoClienteId = new short[1] ;
         T000O40_n192TipoClienteId = new bool[] {false} ;
         T000O40_A186MunicipioCodigo = new string[] {""} ;
         T000O40_n186MunicipioCodigo = new bool[] {false} ;
         T000O40_A444ResponsavelMunicipio = new string[] {""} ;
         T000O40_n444ResponsavelMunicipio = new bool[] {false} ;
         T000O40_A402BancoId = new int[1] ;
         T000O40_n402BancoId = new bool[] {false} ;
         T000O40_A457EspecialidadeId = new int[1] ;
         T000O40_n457EspecialidadeId = new bool[] {false} ;
         T000O40_A437ResponsavelNacionalidade = new int[1] ;
         T000O40_n437ResponsavelNacionalidade = new bool[] {false} ;
         T000O40_A484ClienteNacionalidade = new int[1] ;
         T000O40_n484ClienteNacionalidade = new bool[] {false} ;
         T000O40_A442ResponsavelProfissao = new int[1] ;
         T000O40_n442ResponsavelProfissao = new bool[] {false} ;
         T000O40_A487ClienteProfissao = new int[1] ;
         T000O40_n487ClienteProfissao = new bool[] {false} ;
         T000O40_A489ClienteConvenio = new int[1] ;
         T000O40_n489ClienteConvenio = new bool[] {false} ;
         T000O40_A780SerasaUltimaData_F = new DateTime[] {DateTime.MinValue} ;
         T000O40_A608SecUserId_F = new short[1] ;
         T000O40_n608SecUserId_F = new bool[] {false} ;
         T000O40_A309ClienteQtdTitulos_F = new int[1] ;
         T000O40_n309ClienteQtdTitulos_F = new bool[] {false} ;
         T000O40_A310ClienteValorAPagar_F = new decimal[1] ;
         T000O40_n310ClienteValorAPagar_F = new bool[] {false} ;
         T000O40_A311ClienteValorAReceber_F = new decimal[1] ;
         T000O40_n311ClienteValorAReceber_F = new bool[] {false} ;
         T000O40_A732SerasaConsultas_F = new short[1] ;
         T000O40_A1031RelacionamentoSacado = new short[1] ;
         T000O40_n1031RelacionamentoSacado = new bool[] {false} ;
         T000O41_A169ClienteDocumento = new string[] {""} ;
         T000O41_n169ClienteDocumento = new bool[] {false} ;
         T000O5_A187MunicipioNome = new string[] {""} ;
         T000O5_n187MunicipioNome = new bool[] {false} ;
         T000O5_A189MunicipioUF = new string[] {""} ;
         T000O5_n189MunicipioUF = new bool[] {false} ;
         T000O4_A193TipoClienteDescricao = new string[] {""} ;
         T000O4_n193TipoClienteDescricao = new bool[] {false} ;
         T000O4_A207TipoClientePortal = new bool[] {false} ;
         T000O4_n207TipoClientePortal = new bool[] {false} ;
         T000O4_A793TipoClientePortalPjPf = new bool[] {false} ;
         T000O4_n793TipoClientePortalPjPf = new bool[] {false} ;
         T000O6_A446ResponsavelMunicipioUF = new string[] {""} ;
         T000O6_n446ResponsavelMunicipioUF = new bool[] {false} ;
         T000O6_A445ResponsavelMunicipioNome = new string[] {""} ;
         T000O6_n445ResponsavelMunicipioNome = new bool[] {false} ;
         T000O7_A404BancoCodigo = new int[1] ;
         T000O7_n404BancoCodigo = new bool[] {false} ;
         T000O7_A403BancoNome = new string[] {""} ;
         T000O7_n403BancoNome = new bool[] {false} ;
         T000O8_A457EspecialidadeId = new int[1] ;
         T000O8_n457EspecialidadeId = new bool[] {false} ;
         T000O9_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         T000O9_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         T000O10_A485ClienteNacionalidadeNome = new string[] {""} ;
         T000O10_n485ClienteNacionalidadeNome = new bool[] {false} ;
         T000O11_A443ResponsavelProfissaoNome = new string[] {""} ;
         T000O11_n443ResponsavelProfissaoNome = new bool[] {false} ;
         T000O12_A488ClienteProfissaoNome = new string[] {""} ;
         T000O12_n488ClienteProfissaoNome = new bool[] {false} ;
         T000O13_A490ClienteConvenioDescricao = new string[] {""} ;
         T000O13_n490ClienteConvenioDescricao = new bool[] {false} ;
         T000O43_A608SecUserId_F = new short[1] ;
         T000O43_n608SecUserId_F = new bool[] {false} ;
         T000O45_A309ClienteQtdTitulos_F = new int[1] ;
         T000O45_n309ClienteQtdTitulos_F = new bool[] {false} ;
         T000O49_A310ClienteValorAPagar_F = new decimal[1] ;
         T000O49_n310ClienteValorAPagar_F = new bool[] {false} ;
         T000O52_A311ClienteValorAReceber_F = new decimal[1] ;
         T000O52_n311ClienteValorAReceber_F = new bool[] {false} ;
         T000O54_A780SerasaUltimaData_F = new DateTime[] {DateTime.MinValue} ;
         T000O54_A732SerasaConsultas_F = new short[1] ;
         T000O56_A781SerasaScoreUltimaData_F = new short[1] ;
         T000O56_A785SerasaUltimoValorRecomendado_F = new decimal[1] ;
         T000O58_A1031RelacionamentoSacado = new short[1] ;
         T000O58_n1031RelacionamentoSacado = new bool[] {false} ;
         T000O59_A187MunicipioNome = new string[] {""} ;
         T000O59_n187MunicipioNome = new bool[] {false} ;
         T000O59_A189MunicipioUF = new string[] {""} ;
         T000O59_n189MunicipioUF = new bool[] {false} ;
         T000O60_A193TipoClienteDescricao = new string[] {""} ;
         T000O60_n193TipoClienteDescricao = new bool[] {false} ;
         T000O60_A207TipoClientePortal = new bool[] {false} ;
         T000O60_n207TipoClientePortal = new bool[] {false} ;
         T000O60_A793TipoClientePortalPjPf = new bool[] {false} ;
         T000O60_n793TipoClientePortalPjPf = new bool[] {false} ;
         T000O61_A446ResponsavelMunicipioUF = new string[] {""} ;
         T000O61_n446ResponsavelMunicipioUF = new bool[] {false} ;
         T000O61_A445ResponsavelMunicipioNome = new string[] {""} ;
         T000O61_n445ResponsavelMunicipioNome = new bool[] {false} ;
         T000O62_A404BancoCodigo = new int[1] ;
         T000O62_n404BancoCodigo = new bool[] {false} ;
         T000O62_A403BancoNome = new string[] {""} ;
         T000O62_n403BancoNome = new bool[] {false} ;
         T000O63_A457EspecialidadeId = new int[1] ;
         T000O63_n457EspecialidadeId = new bool[] {false} ;
         T000O64_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         T000O64_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         T000O65_A485ClienteNacionalidadeNome = new string[] {""} ;
         T000O65_n485ClienteNacionalidadeNome = new bool[] {false} ;
         T000O66_A443ResponsavelProfissaoNome = new string[] {""} ;
         T000O66_n443ResponsavelProfissaoNome = new bool[] {false} ;
         T000O67_A488ClienteProfissaoNome = new string[] {""} ;
         T000O67_n488ClienteProfissaoNome = new bool[] {false} ;
         T000O68_A490ClienteConvenioDescricao = new string[] {""} ;
         T000O68_n490ClienteConvenioDescricao = new bool[] {false} ;
         T000O69_A168ClienteId = new int[1] ;
         T000O69_n168ClienteId = new bool[] {false} ;
         T000O3_A168ClienteId = new int[1] ;
         T000O3_n168ClienteId = new bool[] {false} ;
         T000O3_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T000O3_n175ClienteCreatedAt = new bool[] {false} ;
         T000O3_A176ClienteUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T000O3_n176ClienteUpdatedAt = new bool[] {false} ;
         T000O3_A169ClienteDocumento = new string[] {""} ;
         T000O3_n169ClienteDocumento = new bool[] {false} ;
         T000O3_A170ClienteRazaoSocial = new string[] {""} ;
         T000O3_n170ClienteRazaoSocial = new bool[] {false} ;
         T000O3_A171ClienteNomeFantasia = new string[] {""} ;
         T000O3_n171ClienteNomeFantasia = new bool[] {false} ;
         T000O3_A459ClienteDataNascimento = new DateTime[] {DateTime.MinValue} ;
         T000O3_n459ClienteDataNascimento = new bool[] {false} ;
         T000O3_A172ClienteTipoPessoa = new string[] {""} ;
         T000O3_n172ClienteTipoPessoa = new bool[] {false} ;
         T000O3_A174ClienteStatus = new bool[] {false} ;
         T000O3_n174ClienteStatus = new bool[] {false} ;
         T000O3_A177ClienteLogUser = new short[1] ;
         T000O3_n177ClienteLogUser = new bool[] {false} ;
         T000O3_A486ClienteEstadoCivil = new string[] {""} ;
         T000O3_n486ClienteEstadoCivil = new bool[] {false} ;
         T000O3_A181EnderecoTipo = new string[] {""} ;
         T000O3_n181EnderecoTipo = new bool[] {false} ;
         T000O3_A182EnderecoCEP = new string[] {""} ;
         T000O3_n182EnderecoCEP = new bool[] {false} ;
         T000O3_A183EnderecoLogradouro = new string[] {""} ;
         T000O3_n183EnderecoLogradouro = new bool[] {false} ;
         T000O3_A184EnderecoBairro = new string[] {""} ;
         T000O3_n184EnderecoBairro = new bool[] {false} ;
         T000O3_A185EnderecoCidade = new string[] {""} ;
         T000O3_n185EnderecoCidade = new bool[] {false} ;
         T000O3_A190EnderecoNumero = new string[] {""} ;
         T000O3_n190EnderecoNumero = new bool[] {false} ;
         T000O3_A191EnderecoComplemento = new string[] {""} ;
         T000O3_n191EnderecoComplemento = new bool[] {false} ;
         T000O3_A201ContatoEmail = new string[] {""} ;
         T000O3_n201ContatoEmail = new bool[] {false} ;
         T000O3_A198ContatoDDD = new short[1] ;
         T000O3_n198ContatoDDD = new bool[] {false} ;
         T000O3_A199ContatoDDI = new short[1] ;
         T000O3_n199ContatoDDI = new bool[] {false} ;
         T000O3_A200ContatoNumero = new long[1] ;
         T000O3_n200ContatoNumero = new bool[] {false} ;
         T000O3_A202ContatoTelefoneNumero = new long[1] ;
         T000O3_n202ContatoTelefoneNumero = new bool[] {false} ;
         T000O3_A203ContatoTelefoneDDD = new short[1] ;
         T000O3_n203ContatoTelefoneDDD = new bool[] {false} ;
         T000O3_A204ContatoTelefoneDDI = new short[1] ;
         T000O3_n204ContatoTelefoneDDI = new bool[] {false} ;
         T000O3_A421ClienteRG = new long[1] ;
         T000O3_n421ClienteRG = new bool[] {false} ;
         T000O3_A537ClienteDepositoTipo = new string[] {""} ;
         T000O3_n537ClienteDepositoTipo = new bool[] {false} ;
         T000O3_A538ClientePixTipo = new string[] {""} ;
         T000O3_n538ClientePixTipo = new bool[] {false} ;
         T000O3_A539ClientePix = new string[] {""} ;
         T000O3_n539ClientePix = new bool[] {false} ;
         T000O3_A400ContaAgencia = new string[] {""} ;
         T000O3_n400ContaAgencia = new bool[] {false} ;
         T000O3_A401ContaNumero = new string[] {""} ;
         T000O3_n401ContaNumero = new bool[] {false} ;
         T000O3_A436ResponsavelNome = new string[] {""} ;
         T000O3_n436ResponsavelNome = new bool[] {false} ;
         T000O3_A439ResponsavelEstadoCivil = new string[] {""} ;
         T000O3_n439ResponsavelEstadoCivil = new bool[] {false} ;
         T000O3_A576ResponsavelRG = new long[1] ;
         T000O3_n576ResponsavelRG = new bool[] {false} ;
         T000O3_A447ResponsavelCPF = new string[] {""} ;
         T000O3_n447ResponsavelCPF = new bool[] {false} ;
         T000O3_A448ResponsavelCEP = new string[] {""} ;
         T000O3_n448ResponsavelCEP = new bool[] {false} ;
         T000O3_A449ResponsavelLogradouro = new string[] {""} ;
         T000O3_n449ResponsavelLogradouro = new bool[] {false} ;
         T000O3_A450ResponsavelBairro = new string[] {""} ;
         T000O3_n450ResponsavelBairro = new bool[] {false} ;
         T000O3_A451ResponsavelCidade = new string[] {""} ;
         T000O3_n451ResponsavelCidade = new bool[] {false} ;
         T000O3_A452ResponsavelLogradouroNumero = new int[1] ;
         T000O3_n452ResponsavelLogradouroNumero = new bool[] {false} ;
         T000O3_A453ResponsavelComplemento = new string[] {""} ;
         T000O3_n453ResponsavelComplemento = new bool[] {false} ;
         T000O3_A454ResponsavelDDD = new short[1] ;
         T000O3_n454ResponsavelDDD = new bool[] {false} ;
         T000O3_A455ResponsavelNumero = new int[1] ;
         T000O3_n455ResponsavelNumero = new bool[] {false} ;
         T000O3_A456ResponsavelEmail = new string[] {""} ;
         T000O3_n456ResponsavelEmail = new bool[] {false} ;
         T000O3_A884ClienteSituacao = new string[] {""} ;
         T000O3_n884ClienteSituacao = new bool[] {false} ;
         T000O3_A885ResponsavelCargo = new string[] {""} ;
         T000O3_n885ResponsavelCargo = new bool[] {false} ;
         T000O3_A1039ClienteTipoRisco = new string[] {""} ;
         T000O3_A192TipoClienteId = new short[1] ;
         T000O3_n192TipoClienteId = new bool[] {false} ;
         T000O3_A186MunicipioCodigo = new string[] {""} ;
         T000O3_n186MunicipioCodigo = new bool[] {false} ;
         T000O3_A444ResponsavelMunicipio = new string[] {""} ;
         T000O3_n444ResponsavelMunicipio = new bool[] {false} ;
         T000O3_A402BancoId = new int[1] ;
         T000O3_n402BancoId = new bool[] {false} ;
         T000O3_A457EspecialidadeId = new int[1] ;
         T000O3_n457EspecialidadeId = new bool[] {false} ;
         T000O3_A437ResponsavelNacionalidade = new int[1] ;
         T000O3_n437ResponsavelNacionalidade = new bool[] {false} ;
         T000O3_A484ClienteNacionalidade = new int[1] ;
         T000O3_n484ClienteNacionalidade = new bool[] {false} ;
         T000O3_A442ResponsavelProfissao = new int[1] ;
         T000O3_n442ResponsavelProfissao = new bool[] {false} ;
         T000O3_A487ClienteProfissao = new int[1] ;
         T000O3_n487ClienteProfissao = new bool[] {false} ;
         T000O3_A489ClienteConvenio = new int[1] ;
         T000O3_n489ClienteConvenio = new bool[] {false} ;
         T000O70_A168ClienteId = new int[1] ;
         T000O70_n168ClienteId = new bool[] {false} ;
         T000O71_A168ClienteId = new int[1] ;
         T000O71_n168ClienteId = new bool[] {false} ;
         T000O2_A168ClienteId = new int[1] ;
         T000O2_n168ClienteId = new bool[] {false} ;
         T000O2_A175ClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         T000O2_n175ClienteCreatedAt = new bool[] {false} ;
         T000O2_A176ClienteUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         T000O2_n176ClienteUpdatedAt = new bool[] {false} ;
         T000O2_A169ClienteDocumento = new string[] {""} ;
         T000O2_n169ClienteDocumento = new bool[] {false} ;
         T000O2_A170ClienteRazaoSocial = new string[] {""} ;
         T000O2_n170ClienteRazaoSocial = new bool[] {false} ;
         T000O2_A171ClienteNomeFantasia = new string[] {""} ;
         T000O2_n171ClienteNomeFantasia = new bool[] {false} ;
         T000O2_A459ClienteDataNascimento = new DateTime[] {DateTime.MinValue} ;
         T000O2_n459ClienteDataNascimento = new bool[] {false} ;
         T000O2_A172ClienteTipoPessoa = new string[] {""} ;
         T000O2_n172ClienteTipoPessoa = new bool[] {false} ;
         T000O2_A174ClienteStatus = new bool[] {false} ;
         T000O2_n174ClienteStatus = new bool[] {false} ;
         T000O2_A177ClienteLogUser = new short[1] ;
         T000O2_n177ClienteLogUser = new bool[] {false} ;
         T000O2_A486ClienteEstadoCivil = new string[] {""} ;
         T000O2_n486ClienteEstadoCivil = new bool[] {false} ;
         T000O2_A181EnderecoTipo = new string[] {""} ;
         T000O2_n181EnderecoTipo = new bool[] {false} ;
         T000O2_A182EnderecoCEP = new string[] {""} ;
         T000O2_n182EnderecoCEP = new bool[] {false} ;
         T000O2_A183EnderecoLogradouro = new string[] {""} ;
         T000O2_n183EnderecoLogradouro = new bool[] {false} ;
         T000O2_A184EnderecoBairro = new string[] {""} ;
         T000O2_n184EnderecoBairro = new bool[] {false} ;
         T000O2_A185EnderecoCidade = new string[] {""} ;
         T000O2_n185EnderecoCidade = new bool[] {false} ;
         T000O2_A190EnderecoNumero = new string[] {""} ;
         T000O2_n190EnderecoNumero = new bool[] {false} ;
         T000O2_A191EnderecoComplemento = new string[] {""} ;
         T000O2_n191EnderecoComplemento = new bool[] {false} ;
         T000O2_A201ContatoEmail = new string[] {""} ;
         T000O2_n201ContatoEmail = new bool[] {false} ;
         T000O2_A198ContatoDDD = new short[1] ;
         T000O2_n198ContatoDDD = new bool[] {false} ;
         T000O2_A199ContatoDDI = new short[1] ;
         T000O2_n199ContatoDDI = new bool[] {false} ;
         T000O2_A200ContatoNumero = new long[1] ;
         T000O2_n200ContatoNumero = new bool[] {false} ;
         T000O2_A202ContatoTelefoneNumero = new long[1] ;
         T000O2_n202ContatoTelefoneNumero = new bool[] {false} ;
         T000O2_A203ContatoTelefoneDDD = new short[1] ;
         T000O2_n203ContatoTelefoneDDD = new bool[] {false} ;
         T000O2_A204ContatoTelefoneDDI = new short[1] ;
         T000O2_n204ContatoTelefoneDDI = new bool[] {false} ;
         T000O2_A421ClienteRG = new long[1] ;
         T000O2_n421ClienteRG = new bool[] {false} ;
         T000O2_A537ClienteDepositoTipo = new string[] {""} ;
         T000O2_n537ClienteDepositoTipo = new bool[] {false} ;
         T000O2_A538ClientePixTipo = new string[] {""} ;
         T000O2_n538ClientePixTipo = new bool[] {false} ;
         T000O2_A539ClientePix = new string[] {""} ;
         T000O2_n539ClientePix = new bool[] {false} ;
         T000O2_A400ContaAgencia = new string[] {""} ;
         T000O2_n400ContaAgencia = new bool[] {false} ;
         T000O2_A401ContaNumero = new string[] {""} ;
         T000O2_n401ContaNumero = new bool[] {false} ;
         T000O2_A436ResponsavelNome = new string[] {""} ;
         T000O2_n436ResponsavelNome = new bool[] {false} ;
         T000O2_A439ResponsavelEstadoCivil = new string[] {""} ;
         T000O2_n439ResponsavelEstadoCivil = new bool[] {false} ;
         T000O2_A576ResponsavelRG = new long[1] ;
         T000O2_n576ResponsavelRG = new bool[] {false} ;
         T000O2_A447ResponsavelCPF = new string[] {""} ;
         T000O2_n447ResponsavelCPF = new bool[] {false} ;
         T000O2_A448ResponsavelCEP = new string[] {""} ;
         T000O2_n448ResponsavelCEP = new bool[] {false} ;
         T000O2_A449ResponsavelLogradouro = new string[] {""} ;
         T000O2_n449ResponsavelLogradouro = new bool[] {false} ;
         T000O2_A450ResponsavelBairro = new string[] {""} ;
         T000O2_n450ResponsavelBairro = new bool[] {false} ;
         T000O2_A451ResponsavelCidade = new string[] {""} ;
         T000O2_n451ResponsavelCidade = new bool[] {false} ;
         T000O2_A452ResponsavelLogradouroNumero = new int[1] ;
         T000O2_n452ResponsavelLogradouroNumero = new bool[] {false} ;
         T000O2_A453ResponsavelComplemento = new string[] {""} ;
         T000O2_n453ResponsavelComplemento = new bool[] {false} ;
         T000O2_A454ResponsavelDDD = new short[1] ;
         T000O2_n454ResponsavelDDD = new bool[] {false} ;
         T000O2_A455ResponsavelNumero = new int[1] ;
         T000O2_n455ResponsavelNumero = new bool[] {false} ;
         T000O2_A456ResponsavelEmail = new string[] {""} ;
         T000O2_n456ResponsavelEmail = new bool[] {false} ;
         T000O2_A884ClienteSituacao = new string[] {""} ;
         T000O2_n884ClienteSituacao = new bool[] {false} ;
         T000O2_A885ResponsavelCargo = new string[] {""} ;
         T000O2_n885ResponsavelCargo = new bool[] {false} ;
         T000O2_A1039ClienteTipoRisco = new string[] {""} ;
         T000O2_A192TipoClienteId = new short[1] ;
         T000O2_n192TipoClienteId = new bool[] {false} ;
         T000O2_A186MunicipioCodigo = new string[] {""} ;
         T000O2_n186MunicipioCodigo = new bool[] {false} ;
         T000O2_A444ResponsavelMunicipio = new string[] {""} ;
         T000O2_n444ResponsavelMunicipio = new bool[] {false} ;
         T000O2_A402BancoId = new int[1] ;
         T000O2_n402BancoId = new bool[] {false} ;
         T000O2_A457EspecialidadeId = new int[1] ;
         T000O2_n457EspecialidadeId = new bool[] {false} ;
         T000O2_A437ResponsavelNacionalidade = new int[1] ;
         T000O2_n437ResponsavelNacionalidade = new bool[] {false} ;
         T000O2_A484ClienteNacionalidade = new int[1] ;
         T000O2_n484ClienteNacionalidade = new bool[] {false} ;
         T000O2_A442ResponsavelProfissao = new int[1] ;
         T000O2_n442ResponsavelProfissao = new bool[] {false} ;
         T000O2_A487ClienteProfissao = new int[1] ;
         T000O2_n487ClienteProfissao = new bool[] {false} ;
         T000O2_A489ClienteConvenio = new int[1] ;
         T000O2_n489ClienteConvenio = new bool[] {false} ;
         T000O73_A168ClienteId = new int[1] ;
         T000O73_n168ClienteId = new bool[] {false} ;
         T000O77_A608SecUserId_F = new short[1] ;
         T000O77_n608SecUserId_F = new bool[] {false} ;
         T000O79_A309ClienteQtdTitulos_F = new int[1] ;
         T000O79_n309ClienteQtdTitulos_F = new bool[] {false} ;
         T000O83_A310ClienteValorAPagar_F = new decimal[1] ;
         T000O83_n310ClienteValorAPagar_F = new bool[] {false} ;
         T000O86_A311ClienteValorAReceber_F = new decimal[1] ;
         T000O86_n311ClienteValorAReceber_F = new bool[] {false} ;
         T000O88_A780SerasaUltimaData_F = new DateTime[] {DateTime.MinValue} ;
         T000O88_A732SerasaConsultas_F = new short[1] ;
         T000O90_A781SerasaScoreUltimaData_F = new short[1] ;
         T000O90_A785SerasaUltimoValorRecomendado_F = new decimal[1] ;
         T000O92_A1031RelacionamentoSacado = new short[1] ;
         T000O92_n1031RelacionamentoSacado = new bool[] {false} ;
         T000O93_A187MunicipioNome = new string[] {""} ;
         T000O93_n187MunicipioNome = new bool[] {false} ;
         T000O93_A189MunicipioUF = new string[] {""} ;
         T000O93_n189MunicipioUF = new bool[] {false} ;
         T000O94_A193TipoClienteDescricao = new string[] {""} ;
         T000O94_n193TipoClienteDescricao = new bool[] {false} ;
         T000O94_A207TipoClientePortal = new bool[] {false} ;
         T000O94_n207TipoClientePortal = new bool[] {false} ;
         T000O94_A793TipoClientePortalPjPf = new bool[] {false} ;
         T000O94_n793TipoClientePortalPjPf = new bool[] {false} ;
         T000O95_A446ResponsavelMunicipioUF = new string[] {""} ;
         T000O95_n446ResponsavelMunicipioUF = new bool[] {false} ;
         T000O95_A445ResponsavelMunicipioNome = new string[] {""} ;
         T000O95_n445ResponsavelMunicipioNome = new bool[] {false} ;
         T000O96_A404BancoCodigo = new int[1] ;
         T000O96_n404BancoCodigo = new bool[] {false} ;
         T000O96_A403BancoNome = new string[] {""} ;
         T000O96_n403BancoNome = new bool[] {false} ;
         T000O97_A438ResponsavelNacionalidadeNome = new string[] {""} ;
         T000O97_n438ResponsavelNacionalidadeNome = new bool[] {false} ;
         T000O98_A485ClienteNacionalidadeNome = new string[] {""} ;
         T000O98_n485ClienteNacionalidadeNome = new bool[] {false} ;
         T000O99_A443ResponsavelProfissaoNome = new string[] {""} ;
         T000O99_n443ResponsavelProfissaoNome = new bool[] {false} ;
         T000O100_A488ClienteProfissaoNome = new string[] {""} ;
         T000O100_n488ClienteProfissaoNome = new bool[] {false} ;
         T000O101_A490ClienteConvenioDescricao = new string[] {""} ;
         T000O101_n490ClienteConvenioDescricao = new bool[] {false} ;
         T000O102_A1019OperacoesTitulosId = new int[1] ;
         T000O103_A323PropostaId = new int[1] ;
         T000O104_A323PropostaId = new int[1] ;
         T000O105_A323PropostaId = new int[1] ;
         T000O106_A323PropostaId = new int[1] ;
         T000O107_A227ContratoId = new int[1] ;
         T000O108_A261TituloId = new int[1] ;
         T000O108_n261TituloId = new bool[] {false} ;
         T000O109_A133SecUserId = new short[1] ;
         T000O110_A1032RelacionamentoId = new int[1] ;
         T000O111_A1010OperacoesId = new int[1] ;
         T000O112_A978RepresentanteId = new int[1] ;
         T000O113_A856CreditoId = new int[1] ;
         T000O114_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T000O114_n794NotaFiscalId = new bool[] {false} ;
         T000O115_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         T000O115_n794NotaFiscalId = new bool[] {false} ;
         T000O116_A662SerasaId = new int[1] ;
         T000O117_A599ClienteDocumentoId = new int[1] ;
         T000O118_A551ClienteReponsavelId = new int[1] ;
         T000O119_A551ClienteReponsavelId = new int[1] ;
         T000O120_A242AssinaturaParticipanteId = new int[1] ;
         T000O121_A223FinanciamentoId = new int[1] ;
         T000O122_A223FinanciamentoId = new int[1] ;
         T000O123_A168ClienteId = new int[1] ;
         T000O123_n168ClienteId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i175ClienteCreatedAt = (DateTime)(DateTime.MinValue);
         GXt_char2 = "";
         T000O124_A169ClienteDocumento = new string[] {""} ;
         T000O124_n169ClienteDocumento = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cliente__default(),
            new Object[][] {
                new Object[] {
               T000O2_A168ClienteId, T000O2_A175ClienteCreatedAt, T000O2_n175ClienteCreatedAt, T000O2_A176ClienteUpdatedAt, T000O2_n176ClienteUpdatedAt, T000O2_A169ClienteDocumento, T000O2_n169ClienteDocumento, T000O2_A170ClienteRazaoSocial, T000O2_n170ClienteRazaoSocial, T000O2_A171ClienteNomeFantasia,
               T000O2_n171ClienteNomeFantasia, T000O2_A459ClienteDataNascimento, T000O2_n459ClienteDataNascimento, T000O2_A172ClienteTipoPessoa, T000O2_n172ClienteTipoPessoa, T000O2_A174ClienteStatus, T000O2_n174ClienteStatus, T000O2_A177ClienteLogUser, T000O2_n177ClienteLogUser, T000O2_A486ClienteEstadoCivil,
               T000O2_n486ClienteEstadoCivil, T000O2_A181EnderecoTipo, T000O2_n181EnderecoTipo, T000O2_A182EnderecoCEP, T000O2_n182EnderecoCEP, T000O2_A183EnderecoLogradouro, T000O2_n183EnderecoLogradouro, T000O2_A184EnderecoBairro, T000O2_n184EnderecoBairro, T000O2_A185EnderecoCidade,
               T000O2_n185EnderecoCidade, T000O2_A190EnderecoNumero, T000O2_n190EnderecoNumero, T000O2_A191EnderecoComplemento, T000O2_n191EnderecoComplemento, T000O2_A201ContatoEmail, T000O2_n201ContatoEmail, T000O2_A198ContatoDDD, T000O2_n198ContatoDDD, T000O2_A199ContatoDDI,
               T000O2_n199ContatoDDI, T000O2_A200ContatoNumero, T000O2_n200ContatoNumero, T000O2_A202ContatoTelefoneNumero, T000O2_n202ContatoTelefoneNumero, T000O2_A203ContatoTelefoneDDD, T000O2_n203ContatoTelefoneDDD, T000O2_A204ContatoTelefoneDDI, T000O2_n204ContatoTelefoneDDI, T000O2_A421ClienteRG,
               T000O2_n421ClienteRG, T000O2_A537ClienteDepositoTipo, T000O2_n537ClienteDepositoTipo, T000O2_A538ClientePixTipo, T000O2_n538ClientePixTipo, T000O2_A539ClientePix, T000O2_n539ClientePix, T000O2_A400ContaAgencia, T000O2_n400ContaAgencia, T000O2_A401ContaNumero,
               T000O2_n401ContaNumero, T000O2_A436ResponsavelNome, T000O2_n436ResponsavelNome, T000O2_A439ResponsavelEstadoCivil, T000O2_n439ResponsavelEstadoCivil, T000O2_A576ResponsavelRG, T000O2_n576ResponsavelRG, T000O2_A447ResponsavelCPF, T000O2_n447ResponsavelCPF, T000O2_A448ResponsavelCEP,
               T000O2_n448ResponsavelCEP, T000O2_A449ResponsavelLogradouro, T000O2_n449ResponsavelLogradouro, T000O2_A450ResponsavelBairro, T000O2_n450ResponsavelBairro, T000O2_A451ResponsavelCidade, T000O2_n451ResponsavelCidade, T000O2_A452ResponsavelLogradouroNumero, T000O2_n452ResponsavelLogradouroNumero, T000O2_A453ResponsavelComplemento,
               T000O2_n453ResponsavelComplemento, T000O2_A454ResponsavelDDD, T000O2_n454ResponsavelDDD, T000O2_A455ResponsavelNumero, T000O2_n455ResponsavelNumero, T000O2_A456ResponsavelEmail, T000O2_n456ResponsavelEmail, T000O2_A884ClienteSituacao, T000O2_n884ClienteSituacao, T000O2_A885ResponsavelCargo,
               T000O2_n885ResponsavelCargo, T000O2_A1039ClienteTipoRisco, T000O2_A192TipoClienteId, T000O2_n192TipoClienteId, T000O2_A186MunicipioCodigo, T000O2_n186MunicipioCodigo, T000O2_A444ResponsavelMunicipio, T000O2_n444ResponsavelMunicipio, T000O2_A402BancoId, T000O2_n402BancoId,
               T000O2_A457EspecialidadeId, T000O2_n457EspecialidadeId, T000O2_A437ResponsavelNacionalidade, T000O2_n437ResponsavelNacionalidade, T000O2_A484ClienteNacionalidade, T000O2_n484ClienteNacionalidade, T000O2_A442ResponsavelProfissao, T000O2_n442ResponsavelProfissao, T000O2_A487ClienteProfissao, T000O2_n487ClienteProfissao,
               T000O2_A489ClienteConvenio, T000O2_n489ClienteConvenio
               }
               , new Object[] {
               T000O3_A168ClienteId, T000O3_A175ClienteCreatedAt, T000O3_n175ClienteCreatedAt, T000O3_A176ClienteUpdatedAt, T000O3_n176ClienteUpdatedAt, T000O3_A169ClienteDocumento, T000O3_n169ClienteDocumento, T000O3_A170ClienteRazaoSocial, T000O3_n170ClienteRazaoSocial, T000O3_A171ClienteNomeFantasia,
               T000O3_n171ClienteNomeFantasia, T000O3_A459ClienteDataNascimento, T000O3_n459ClienteDataNascimento, T000O3_A172ClienteTipoPessoa, T000O3_n172ClienteTipoPessoa, T000O3_A174ClienteStatus, T000O3_n174ClienteStatus, T000O3_A177ClienteLogUser, T000O3_n177ClienteLogUser, T000O3_A486ClienteEstadoCivil,
               T000O3_n486ClienteEstadoCivil, T000O3_A181EnderecoTipo, T000O3_n181EnderecoTipo, T000O3_A182EnderecoCEP, T000O3_n182EnderecoCEP, T000O3_A183EnderecoLogradouro, T000O3_n183EnderecoLogradouro, T000O3_A184EnderecoBairro, T000O3_n184EnderecoBairro, T000O3_A185EnderecoCidade,
               T000O3_n185EnderecoCidade, T000O3_A190EnderecoNumero, T000O3_n190EnderecoNumero, T000O3_A191EnderecoComplemento, T000O3_n191EnderecoComplemento, T000O3_A201ContatoEmail, T000O3_n201ContatoEmail, T000O3_A198ContatoDDD, T000O3_n198ContatoDDD, T000O3_A199ContatoDDI,
               T000O3_n199ContatoDDI, T000O3_A200ContatoNumero, T000O3_n200ContatoNumero, T000O3_A202ContatoTelefoneNumero, T000O3_n202ContatoTelefoneNumero, T000O3_A203ContatoTelefoneDDD, T000O3_n203ContatoTelefoneDDD, T000O3_A204ContatoTelefoneDDI, T000O3_n204ContatoTelefoneDDI, T000O3_A421ClienteRG,
               T000O3_n421ClienteRG, T000O3_A537ClienteDepositoTipo, T000O3_n537ClienteDepositoTipo, T000O3_A538ClientePixTipo, T000O3_n538ClientePixTipo, T000O3_A539ClientePix, T000O3_n539ClientePix, T000O3_A400ContaAgencia, T000O3_n400ContaAgencia, T000O3_A401ContaNumero,
               T000O3_n401ContaNumero, T000O3_A436ResponsavelNome, T000O3_n436ResponsavelNome, T000O3_A439ResponsavelEstadoCivil, T000O3_n439ResponsavelEstadoCivil, T000O3_A576ResponsavelRG, T000O3_n576ResponsavelRG, T000O3_A447ResponsavelCPF, T000O3_n447ResponsavelCPF, T000O3_A448ResponsavelCEP,
               T000O3_n448ResponsavelCEP, T000O3_A449ResponsavelLogradouro, T000O3_n449ResponsavelLogradouro, T000O3_A450ResponsavelBairro, T000O3_n450ResponsavelBairro, T000O3_A451ResponsavelCidade, T000O3_n451ResponsavelCidade, T000O3_A452ResponsavelLogradouroNumero, T000O3_n452ResponsavelLogradouroNumero, T000O3_A453ResponsavelComplemento,
               T000O3_n453ResponsavelComplemento, T000O3_A454ResponsavelDDD, T000O3_n454ResponsavelDDD, T000O3_A455ResponsavelNumero, T000O3_n455ResponsavelNumero, T000O3_A456ResponsavelEmail, T000O3_n456ResponsavelEmail, T000O3_A884ClienteSituacao, T000O3_n884ClienteSituacao, T000O3_A885ResponsavelCargo,
               T000O3_n885ResponsavelCargo, T000O3_A1039ClienteTipoRisco, T000O3_A192TipoClienteId, T000O3_n192TipoClienteId, T000O3_A186MunicipioCodigo, T000O3_n186MunicipioCodigo, T000O3_A444ResponsavelMunicipio, T000O3_n444ResponsavelMunicipio, T000O3_A402BancoId, T000O3_n402BancoId,
               T000O3_A457EspecialidadeId, T000O3_n457EspecialidadeId, T000O3_A437ResponsavelNacionalidade, T000O3_n437ResponsavelNacionalidade, T000O3_A484ClienteNacionalidade, T000O3_n484ClienteNacionalidade, T000O3_A442ResponsavelProfissao, T000O3_n442ResponsavelProfissao, T000O3_A487ClienteProfissao, T000O3_n487ClienteProfissao,
               T000O3_A489ClienteConvenio, T000O3_n489ClienteConvenio
               }
               , new Object[] {
               T000O4_A193TipoClienteDescricao, T000O4_n193TipoClienteDescricao, T000O4_A207TipoClientePortal, T000O4_n207TipoClientePortal, T000O4_A793TipoClientePortalPjPf, T000O4_n793TipoClientePortalPjPf
               }
               , new Object[] {
               T000O5_A187MunicipioNome, T000O5_n187MunicipioNome, T000O5_A189MunicipioUF, T000O5_n189MunicipioUF
               }
               , new Object[] {
               T000O6_A446ResponsavelMunicipioUF, T000O6_n446ResponsavelMunicipioUF, T000O6_A445ResponsavelMunicipioNome, T000O6_n445ResponsavelMunicipioNome
               }
               , new Object[] {
               T000O7_A404BancoCodigo, T000O7_n404BancoCodigo, T000O7_A403BancoNome, T000O7_n403BancoNome
               }
               , new Object[] {
               T000O8_A457EspecialidadeId
               }
               , new Object[] {
               T000O9_A438ResponsavelNacionalidadeNome, T000O9_n438ResponsavelNacionalidadeNome
               }
               , new Object[] {
               T000O10_A485ClienteNacionalidadeNome, T000O10_n485ClienteNacionalidadeNome
               }
               , new Object[] {
               T000O11_A443ResponsavelProfissaoNome, T000O11_n443ResponsavelProfissaoNome
               }
               , new Object[] {
               T000O12_A488ClienteProfissaoNome, T000O12_n488ClienteProfissaoNome
               }
               , new Object[] {
               T000O13_A490ClienteConvenioDescricao, T000O13_n490ClienteConvenioDescricao
               }
               , new Object[] {
               T000O15_A781SerasaScoreUltimaData_F, T000O15_A785SerasaUltimoValorRecomendado_F
               }
               , new Object[] {
               T000O17_A608SecUserId_F, T000O17_n608SecUserId_F
               }
               , new Object[] {
               T000O19_A309ClienteQtdTitulos_F, T000O19_n309ClienteQtdTitulos_F
               }
               , new Object[] {
               T000O23_A310ClienteValorAPagar_F, T000O23_n310ClienteValorAPagar_F
               }
               , new Object[] {
               T000O26_A311ClienteValorAReceber_F, T000O26_n311ClienteValorAReceber_F
               }
               , new Object[] {
               T000O28_A780SerasaUltimaData_F, T000O28_A732SerasaConsultas_F
               }
               , new Object[] {
               T000O30_A1031RelacionamentoSacado, T000O30_n1031RelacionamentoSacado
               }
               , new Object[] {
               T000O40_A168ClienteId, T000O40_A175ClienteCreatedAt, T000O40_n175ClienteCreatedAt, T000O40_A176ClienteUpdatedAt, T000O40_n176ClienteUpdatedAt, T000O40_A169ClienteDocumento, T000O40_n169ClienteDocumento, T000O40_A170ClienteRazaoSocial, T000O40_n170ClienteRazaoSocial, T000O40_A171ClienteNomeFantasia,
               T000O40_n171ClienteNomeFantasia, T000O40_A459ClienteDataNascimento, T000O40_n459ClienteDataNascimento, T000O40_A172ClienteTipoPessoa, T000O40_n172ClienteTipoPessoa, T000O40_A193TipoClienteDescricao, T000O40_n193TipoClienteDescricao, T000O40_A207TipoClientePortal, T000O40_n207TipoClientePortal, T000O40_A174ClienteStatus,
               T000O40_n174ClienteStatus, T000O40_A490ClienteConvenioDescricao, T000O40_n490ClienteConvenioDescricao, T000O40_A177ClienteLogUser, T000O40_n177ClienteLogUser, T000O40_A485ClienteNacionalidadeNome, T000O40_n485ClienteNacionalidadeNome, T000O40_A488ClienteProfissaoNome, T000O40_n488ClienteProfissaoNome, T000O40_A486ClienteEstadoCivil,
               T000O40_n486ClienteEstadoCivil, T000O40_A181EnderecoTipo, T000O40_n181EnderecoTipo, T000O40_A182EnderecoCEP, T000O40_n182EnderecoCEP, T000O40_A183EnderecoLogradouro, T000O40_n183EnderecoLogradouro, T000O40_A184EnderecoBairro, T000O40_n184EnderecoBairro, T000O40_A185EnderecoCidade,
               T000O40_n185EnderecoCidade, T000O40_A187MunicipioNome, T000O40_n187MunicipioNome, T000O40_A189MunicipioUF, T000O40_n189MunicipioUF, T000O40_A190EnderecoNumero, T000O40_n190EnderecoNumero, T000O40_A191EnderecoComplemento, T000O40_n191EnderecoComplemento, T000O40_A201ContatoEmail,
               T000O40_n201ContatoEmail, T000O40_A198ContatoDDD, T000O40_n198ContatoDDD, T000O40_A199ContatoDDI, T000O40_n199ContatoDDI, T000O40_A200ContatoNumero, T000O40_n200ContatoNumero, T000O40_A202ContatoTelefoneNumero, T000O40_n202ContatoTelefoneNumero, T000O40_A203ContatoTelefoneDDD,
               T000O40_n203ContatoTelefoneDDD, T000O40_A204ContatoTelefoneDDI, T000O40_n204ContatoTelefoneDDI, T000O40_A421ClienteRG, T000O40_n421ClienteRG, T000O40_A537ClienteDepositoTipo, T000O40_n537ClienteDepositoTipo, T000O40_A538ClientePixTipo, T000O40_n538ClientePixTipo, T000O40_A539ClientePix,
               T000O40_n539ClientePix, T000O40_A404BancoCodigo, T000O40_n404BancoCodigo, T000O40_A403BancoNome, T000O40_n403BancoNome, T000O40_A400ContaAgencia, T000O40_n400ContaAgencia, T000O40_A401ContaNumero, T000O40_n401ContaNumero, T000O40_A436ResponsavelNome,
               T000O40_n436ResponsavelNome, T000O40_A438ResponsavelNacionalidadeNome, T000O40_n438ResponsavelNacionalidadeNome, T000O40_A439ResponsavelEstadoCivil, T000O40_n439ResponsavelEstadoCivil, T000O40_A576ResponsavelRG, T000O40_n576ResponsavelRG, T000O40_A443ResponsavelProfissaoNome, T000O40_n443ResponsavelProfissaoNome, T000O40_A447ResponsavelCPF,
               T000O40_n447ResponsavelCPF, T000O40_A448ResponsavelCEP, T000O40_n448ResponsavelCEP, T000O40_A449ResponsavelLogradouro, T000O40_n449ResponsavelLogradouro, T000O40_A450ResponsavelBairro, T000O40_n450ResponsavelBairro, T000O40_A451ResponsavelCidade, T000O40_n451ResponsavelCidade, T000O40_A446ResponsavelMunicipioUF,
               T000O40_n446ResponsavelMunicipioUF, T000O40_A445ResponsavelMunicipioNome, T000O40_n445ResponsavelMunicipioNome, T000O40_A452ResponsavelLogradouroNumero, T000O40_n452ResponsavelLogradouroNumero, T000O40_A453ResponsavelComplemento, T000O40_n453ResponsavelComplemento, T000O40_A454ResponsavelDDD, T000O40_n454ResponsavelDDD, T000O40_A455ResponsavelNumero,
               T000O40_n455ResponsavelNumero, T000O40_A456ResponsavelEmail, T000O40_n456ResponsavelEmail, T000O40_A884ClienteSituacao, T000O40_n884ClienteSituacao, T000O40_A885ResponsavelCargo, T000O40_n885ResponsavelCargo, T000O40_A793TipoClientePortalPjPf, T000O40_n793TipoClientePortalPjPf, T000O40_A1039ClienteTipoRisco,
               T000O40_A192TipoClienteId, T000O40_n192TipoClienteId, T000O40_A186MunicipioCodigo, T000O40_n186MunicipioCodigo, T000O40_A444ResponsavelMunicipio, T000O40_n444ResponsavelMunicipio, T000O40_A402BancoId, T000O40_n402BancoId, T000O40_A457EspecialidadeId, T000O40_n457EspecialidadeId,
               T000O40_A437ResponsavelNacionalidade, T000O40_n437ResponsavelNacionalidade, T000O40_A484ClienteNacionalidade, T000O40_n484ClienteNacionalidade, T000O40_A442ResponsavelProfissao, T000O40_n442ResponsavelProfissao, T000O40_A487ClienteProfissao, T000O40_n487ClienteProfissao, T000O40_A489ClienteConvenio, T000O40_n489ClienteConvenio,
               T000O40_A780SerasaUltimaData_F, T000O40_A608SecUserId_F, T000O40_n608SecUserId_F, T000O40_A309ClienteQtdTitulos_F, T000O40_n309ClienteQtdTitulos_F, T000O40_A310ClienteValorAPagar_F, T000O40_n310ClienteValorAPagar_F, T000O40_A311ClienteValorAReceber_F, T000O40_n311ClienteValorAReceber_F, T000O40_A732SerasaConsultas_F,
               T000O40_A1031RelacionamentoSacado, T000O40_n1031RelacionamentoSacado
               }
               , new Object[] {
               T000O41_A169ClienteDocumento, T000O41_n169ClienteDocumento
               }
               , new Object[] {
               T000O43_A608SecUserId_F, T000O43_n608SecUserId_F
               }
               , new Object[] {
               T000O45_A309ClienteQtdTitulos_F, T000O45_n309ClienteQtdTitulos_F
               }
               , new Object[] {
               T000O49_A310ClienteValorAPagar_F, T000O49_n310ClienteValorAPagar_F
               }
               , new Object[] {
               T000O52_A311ClienteValorAReceber_F, T000O52_n311ClienteValorAReceber_F
               }
               , new Object[] {
               T000O54_A780SerasaUltimaData_F, T000O54_A732SerasaConsultas_F
               }
               , new Object[] {
               T000O56_A781SerasaScoreUltimaData_F, T000O56_A785SerasaUltimoValorRecomendado_F
               }
               , new Object[] {
               T000O58_A1031RelacionamentoSacado, T000O58_n1031RelacionamentoSacado
               }
               , new Object[] {
               T000O59_A187MunicipioNome, T000O59_n187MunicipioNome, T000O59_A189MunicipioUF, T000O59_n189MunicipioUF
               }
               , new Object[] {
               T000O60_A193TipoClienteDescricao, T000O60_n193TipoClienteDescricao, T000O60_A207TipoClientePortal, T000O60_n207TipoClientePortal, T000O60_A793TipoClientePortalPjPf, T000O60_n793TipoClientePortalPjPf
               }
               , new Object[] {
               T000O61_A446ResponsavelMunicipioUF, T000O61_n446ResponsavelMunicipioUF, T000O61_A445ResponsavelMunicipioNome, T000O61_n445ResponsavelMunicipioNome
               }
               , new Object[] {
               T000O62_A404BancoCodigo, T000O62_n404BancoCodigo, T000O62_A403BancoNome, T000O62_n403BancoNome
               }
               , new Object[] {
               T000O63_A457EspecialidadeId
               }
               , new Object[] {
               T000O64_A438ResponsavelNacionalidadeNome, T000O64_n438ResponsavelNacionalidadeNome
               }
               , new Object[] {
               T000O65_A485ClienteNacionalidadeNome, T000O65_n485ClienteNacionalidadeNome
               }
               , new Object[] {
               T000O66_A443ResponsavelProfissaoNome, T000O66_n443ResponsavelProfissaoNome
               }
               , new Object[] {
               T000O67_A488ClienteProfissaoNome, T000O67_n488ClienteProfissaoNome
               }
               , new Object[] {
               T000O68_A490ClienteConvenioDescricao, T000O68_n490ClienteConvenioDescricao
               }
               , new Object[] {
               T000O69_A168ClienteId
               }
               , new Object[] {
               T000O70_A168ClienteId
               }
               , new Object[] {
               T000O71_A168ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               T000O73_A168ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000O77_A608SecUserId_F, T000O77_n608SecUserId_F
               }
               , new Object[] {
               T000O79_A309ClienteQtdTitulos_F, T000O79_n309ClienteQtdTitulos_F
               }
               , new Object[] {
               T000O83_A310ClienteValorAPagar_F, T000O83_n310ClienteValorAPagar_F
               }
               , new Object[] {
               T000O86_A311ClienteValorAReceber_F, T000O86_n311ClienteValorAReceber_F
               }
               , new Object[] {
               T000O88_A780SerasaUltimaData_F, T000O88_A732SerasaConsultas_F
               }
               , new Object[] {
               T000O90_A781SerasaScoreUltimaData_F, T000O90_A785SerasaUltimoValorRecomendado_F
               }
               , new Object[] {
               T000O92_A1031RelacionamentoSacado, T000O92_n1031RelacionamentoSacado
               }
               , new Object[] {
               T000O93_A187MunicipioNome, T000O93_n187MunicipioNome, T000O93_A189MunicipioUF, T000O93_n189MunicipioUF
               }
               , new Object[] {
               T000O94_A193TipoClienteDescricao, T000O94_n193TipoClienteDescricao, T000O94_A207TipoClientePortal, T000O94_n207TipoClientePortal, T000O94_A793TipoClientePortalPjPf, T000O94_n793TipoClientePortalPjPf
               }
               , new Object[] {
               T000O95_A446ResponsavelMunicipioUF, T000O95_n446ResponsavelMunicipioUF, T000O95_A445ResponsavelMunicipioNome, T000O95_n445ResponsavelMunicipioNome
               }
               , new Object[] {
               T000O96_A404BancoCodigo, T000O96_n404BancoCodigo, T000O96_A403BancoNome, T000O96_n403BancoNome
               }
               , new Object[] {
               T000O97_A438ResponsavelNacionalidadeNome, T000O97_n438ResponsavelNacionalidadeNome
               }
               , new Object[] {
               T000O98_A485ClienteNacionalidadeNome, T000O98_n485ClienteNacionalidadeNome
               }
               , new Object[] {
               T000O99_A443ResponsavelProfissaoNome, T000O99_n443ResponsavelProfissaoNome
               }
               , new Object[] {
               T000O100_A488ClienteProfissaoNome, T000O100_n488ClienteProfissaoNome
               }
               , new Object[] {
               T000O101_A490ClienteConvenioDescricao, T000O101_n490ClienteConvenioDescricao
               }
               , new Object[] {
               T000O102_A1019OperacoesTitulosId
               }
               , new Object[] {
               T000O103_A323PropostaId
               }
               , new Object[] {
               T000O104_A323PropostaId
               }
               , new Object[] {
               T000O105_A323PropostaId
               }
               , new Object[] {
               T000O106_A323PropostaId
               }
               , new Object[] {
               T000O107_A227ContratoId
               }
               , new Object[] {
               T000O108_A261TituloId
               }
               , new Object[] {
               T000O109_A133SecUserId
               }
               , new Object[] {
               T000O110_A1032RelacionamentoId
               }
               , new Object[] {
               T000O111_A1010OperacoesId
               }
               , new Object[] {
               T000O112_A978RepresentanteId
               }
               , new Object[] {
               T000O113_A856CreditoId
               }
               , new Object[] {
               T000O114_A794NotaFiscalId
               }
               , new Object[] {
               T000O115_A794NotaFiscalId
               }
               , new Object[] {
               T000O116_A662SerasaId
               }
               , new Object[] {
               T000O117_A599ClienteDocumentoId
               }
               , new Object[] {
               T000O118_A551ClienteReponsavelId
               }
               , new Object[] {
               T000O119_A551ClienteReponsavelId
               }
               , new Object[] {
               T000O120_A242AssinaturaParticipanteId
               }
               , new Object[] {
               T000O121_A223FinanciamentoId
               }
               , new Object[] {
               T000O122_A223FinanciamentoId
               }
               , new Object[] {
               T000O123_A168ClienteId
               }
               , new Object[] {
               T000O124_A169ClienteDocumento, T000O124_n169ClienteDocumento
               }
            }
         );
         AV35Pgmname = "Cliente";
         Z174ClienteStatus = true;
         n174ClienteStatus = false;
         A174ClienteStatus = true;
         n174ClienteStatus = false;
         i174ClienteStatus = true;
         n174ClienteStatus = false;
      }

      private short Z177ClienteLogUser ;
      private short Z198ContatoDDD ;
      private short Z199ContatoDDI ;
      private short Z203ContatoTelefoneDDD ;
      private short Z204ContatoTelefoneDDI ;
      private short Z454ResponsavelDDD ;
      private short Z192TipoClienteId ;
      private short N192TipoClienteId ;
      private short GxWebError ;
      private short A454ResponsavelDDD ;
      private short A192TipoClienteId ;
      private short AnyError ;
      private short IsModified ;
      private short IsConfirmed ;
      private short nKeyPressed ;
      private short A198ContatoDDD ;
      private short A203ContatoTelefoneDDD ;
      private short A204ContatoTelefoneDDI ;
      private short A199ContatoDDI ;
      private short A177ClienteLogUser ;
      private short A1031RelacionamentoSacado ;
      private short AV14Insert_TipoClienteId ;
      private short Gx_BScreen ;
      private short A781SerasaScoreUltimaData_F ;
      private short A608SecUserId_F ;
      private short A732SerasaConsultas_F ;
      private short RcdFound28 ;
      private short Z608SecUserId_F ;
      private short Z732SerasaConsultas_F ;
      private short Z1031RelacionamentoSacado ;
      private short gxajaxcallmode ;
      private short Z781SerasaScoreUltimaData_F ;
      private int wcpOAV7ClienteId ;
      private int Z168ClienteId ;
      private int Z452ResponsavelLogradouroNumero ;
      private int Z455ResponsavelNumero ;
      private int Z402BancoId ;
      private int Z457EspecialidadeId ;
      private int Z437ResponsavelNacionalidade ;
      private int Z484ClienteNacionalidade ;
      private int Z442ResponsavelProfissao ;
      private int Z487ClienteProfissao ;
      private int Z489ClienteConvenio ;
      private int N457EspecialidadeId ;
      private int N489ClienteConvenio ;
      private int N484ClienteNacionalidade ;
      private int N487ClienteProfissao ;
      private int N402BancoId ;
      private int N437ResponsavelNacionalidade ;
      private int N442ResponsavelProfissao ;
      private int A455ResponsavelNumero ;
      private int A168ClienteId ;
      private int A402BancoId ;
      private int A457EspecialidadeId ;
      private int A437ResponsavelNacionalidade ;
      private int A484ClienteNacionalidade ;
      private int A442ResponsavelProfissao ;
      private int A487ClienteProfissao ;
      private int A489ClienteConvenio ;
      private int AV7ClienteId ;
      private int trnEnded ;
      private int edtClienteDocumento_Enabled ;
      private int edtClienteRazaoSocial_Enabled ;
      private int edtClienteNomeFantasia_Enabled ;
      private int edtTipoClienteDescricao_Enabled ;
      private int edtEnderecoCEP_Enabled ;
      private int edtEnderecoLogradouro_Enabled ;
      private int edtEnderecoBairro_Enabled ;
      private int edtEnderecoCidade_Enabled ;
      private int edtMunicipioCodigo_Visible ;
      private int edtMunicipioCodigo_Enabled ;
      private int edtMunicipioUF_Enabled ;
      private int edtEnderecoNumero_Enabled ;
      private int edtEnderecoComplemento_Enabled ;
      private int edtContatoEmail_Enabled ;
      private int edtContatoDDD_Enabled ;
      private int edtContatoNumero_Enabled ;
      private int edtContatoTelefoneNumero_Enabled ;
      private int edtContatoTelefoneDDD_Enabled ;
      private int edtContatoTelefoneDDI_Enabled ;
      private int edtContatoDDI_Enabled ;
      private int edtClienteTelefone_F_Enabled ;
      private int edtClienteCelular_F_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombomunicipiocodigo_Visible ;
      private int edtavCombomunicipiocodigo_Enabled ;
      private int edtClienteId_Enabled ;
      private int edtClienteId_Visible ;
      private int A452ResponsavelLogradouroNumero ;
      private int AV29Insert_EspecialidadeId ;
      private int AV32Insert_ClienteConvenio ;
      private int AV30Insert_ClienteNacionalidade ;
      private int AV31Insert_ClienteProfissao ;
      private int AV25Insert_BancoId ;
      private int AV26Insert_ResponsavelNacionalidade ;
      private int AV27Insert_ResponsavelProfissao ;
      private int A404BancoCodigo ;
      private int A309ClienteQtdTitulos_F ;
      private int Combo_municipiocodigo_Datalistupdateminimumcharacters ;
      private int Combo_municipiocodigo_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV36GXV1 ;
      private int Z404BancoCodigo ;
      private int Z309ClienteQtdTitulos_F ;
      private int idxLst ;
      private long Z200ContatoNumero ;
      private long Z202ContatoTelefoneNumero ;
      private long Z421ClienteRG ;
      private long Z576ResponsavelRG ;
      private long A200ContatoNumero ;
      private long A202ContatoTelefoneNumero ;
      private long A421ClienteRG ;
      private long A576ResponsavelRG ;
      private decimal A310ClienteValorAPagar_F ;
      private decimal A311ClienteValorAReceber_F ;
      private decimal A785SerasaUltimoValorRecomendado_F ;
      private decimal Z310ClienteValorAPagar_F ;
      private decimal Z311ClienteValorAReceber_F ;
      private decimal Z785SerasaUltimoValorRecomendado_F ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z884ClienteSituacao ;
      private string Combo_municipiocodigo_Selectedvalue_get ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtClienteDocumento_Internalname ;
      private string cmbClienteTipoPessoa_Internalname ;
      private string cmbClienteStatus_Internalname ;
      private string cmbEnderecoTipo_Internalname ;
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
      private string TempTags ;
      private string edtClienteDocumento_Jsonclick ;
      private string edtClienteRazaoSocial_Internalname ;
      private string edtClienteRazaoSocial_Jsonclick ;
      private string edtClienteNomeFantasia_Internalname ;
      private string edtClienteNomeFantasia_Jsonclick ;
      private string cmbClienteTipoPessoa_Jsonclick ;
      private string edtTipoClienteDescricao_Internalname ;
      private string edtTipoClienteDescricao_Jsonclick ;
      private string cmbClienteStatus_Jsonclick ;
      private string cmbEnderecoTipo_Jsonclick ;
      private string edtEnderecoCEP_Internalname ;
      private string edtEnderecoCEP_Jsonclick ;
      private string edtEnderecoLogradouro_Internalname ;
      private string edtEnderecoLogradouro_Jsonclick ;
      private string edtEnderecoBairro_Internalname ;
      private string edtEnderecoBairro_Jsonclick ;
      private string edtEnderecoCidade_Internalname ;
      private string edtEnderecoCidade_Jsonclick ;
      private string divTablesplittedmunicipiocodigo_Internalname ;
      private string lblTextblockmunicipiocodigo_Internalname ;
      private string lblTextblockmunicipiocodigo_Jsonclick ;
      private string Combo_municipiocodigo_Caption ;
      private string Combo_municipiocodigo_Cls ;
      private string Combo_municipiocodigo_Datalistproc ;
      private string Combo_municipiocodigo_Datalistprocparametersprefix ;
      private string Combo_municipiocodigo_Internalname ;
      private string edtMunicipioCodigo_Internalname ;
      private string edtMunicipioCodigo_Jsonclick ;
      private string edtMunicipioUF_Internalname ;
      private string edtMunicipioUF_Jsonclick ;
      private string edtEnderecoNumero_Internalname ;
      private string edtEnderecoNumero_Jsonclick ;
      private string edtEnderecoComplemento_Internalname ;
      private string edtEnderecoComplemento_Jsonclick ;
      private string edtContatoEmail_Internalname ;
      private string edtContatoEmail_Jsonclick ;
      private string edtContatoDDD_Internalname ;
      private string edtContatoDDD_Jsonclick ;
      private string edtContatoNumero_Internalname ;
      private string edtContatoNumero_Jsonclick ;
      private string edtContatoTelefoneNumero_Internalname ;
      private string edtContatoTelefoneNumero_Jsonclick ;
      private string edtContatoTelefoneDDD_Internalname ;
      private string edtContatoTelefoneDDD_Jsonclick ;
      private string edtContatoTelefoneDDI_Internalname ;
      private string edtContatoTelefoneDDI_Jsonclick ;
      private string edtContatoDDI_Internalname ;
      private string edtContatoDDI_Jsonclick ;
      private string edtClienteTelefone_F_Internalname ;
      private string edtClienteTelefone_F_Jsonclick ;
      private string edtClienteCelular_F_Internalname ;
      private string edtClienteCelular_F_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_municipiocodigo_Internalname ;
      private string edtavCombomunicipiocodigo_Internalname ;
      private string edtavCombomunicipiocodigo_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string A884ClienteSituacao ;
      private string AV35Pgmname ;
      private string Combo_municipiocodigo_Objectcall ;
      private string Combo_municipiocodigo_Class ;
      private string Combo_municipiocodigo_Icontype ;
      private string Combo_municipiocodigo_Icon ;
      private string Combo_municipiocodigo_Tooltip ;
      private string Combo_municipiocodigo_Selectedvalue_set ;
      private string Combo_municipiocodigo_Selectedtext_set ;
      private string Combo_municipiocodigo_Selectedtext_get ;
      private string Combo_municipiocodigo_Gamoauthtoken ;
      private string Combo_municipiocodigo_Ddointernalname ;
      private string Combo_municipiocodigo_Titlecontrolalign ;
      private string Combo_municipiocodigo_Dropdownoptionstype ;
      private string Combo_municipiocodigo_Titlecontrolidtoreplace ;
      private string Combo_municipiocodigo_Datalisttype ;
      private string Combo_municipiocodigo_Datalistfixedvalues ;
      private string Combo_municipiocodigo_Remoteservicesparameters ;
      private string Combo_municipiocodigo_Htmltemplate ;
      private string Combo_municipiocodigo_Multiplevaluestype ;
      private string Combo_municipiocodigo_Loadingdata ;
      private string Combo_municipiocodigo_Noresultsfound ;
      private string Combo_municipiocodigo_Emptyitemtext ;
      private string Combo_municipiocodigo_Onlyselectedvalues ;
      private string Combo_municipiocodigo_Selectalltext ;
      private string Combo_municipiocodigo_Multiplevaluesseparator ;
      private string Combo_municipiocodigo_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_tableattributes_Titletype ;
      private string hsh ;
      private string sMode28 ;
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
      private string GXt_char2 ;
      private DateTime Z175ClienteCreatedAt ;
      private DateTime Z176ClienteUpdatedAt ;
      private DateTime A780SerasaUltimaData_F ;
      private DateTime A175ClienteCreatedAt ;
      private DateTime A176ClienteUpdatedAt ;
      private DateTime Z780SerasaUltimaData_F ;
      private DateTime i175ClienteCreatedAt ;
      private DateTime Z459ClienteDataNascimento ;
      private DateTime A459ClienteDataNascimento ;
      private bool Z174ClienteStatus ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n454ResponsavelDDD ;
      private bool n455ResponsavelNumero ;
      private bool n168ClienteId ;
      private bool n186MunicipioCodigo ;
      private bool n192TipoClienteId ;
      private bool n444ResponsavelMunicipio ;
      private bool n402BancoId ;
      private bool n457EspecialidadeId ;
      private bool n437ResponsavelNacionalidade ;
      private bool n484ClienteNacionalidade ;
      private bool n442ResponsavelProfissao ;
      private bool n487ClienteProfissao ;
      private bool n489ClienteConvenio ;
      private bool wbErr ;
      private bool n172ClienteTipoPessoa ;
      private bool A174ClienteStatus ;
      private bool n174ClienteStatus ;
      private bool n181EnderecoTipo ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n198ContatoDDD ;
      private bool n200ContatoNumero ;
      private bool n202ContatoTelefoneNumero ;
      private bool n203ContatoTelefoneDDD ;
      private bool n204ContatoTelefoneDDI ;
      private bool n199ContatoDDI ;
      private bool n175ClienteCreatedAt ;
      private bool n176ClienteUpdatedAt ;
      private bool n169ClienteDocumento ;
      private bool n170ClienteRazaoSocial ;
      private bool n171ClienteNomeFantasia ;
      private bool n459ClienteDataNascimento ;
      private bool n177ClienteLogUser ;
      private bool n486ClienteEstadoCivil ;
      private bool n182EnderecoCEP ;
      private bool n183EnderecoLogradouro ;
      private bool n184EnderecoBairro ;
      private bool n185EnderecoCidade ;
      private bool n190EnderecoNumero ;
      private bool n191EnderecoComplemento ;
      private bool n201ContatoEmail ;
      private bool n421ClienteRG ;
      private bool n537ClienteDepositoTipo ;
      private bool n538ClientePixTipo ;
      private bool n539ClientePix ;
      private bool n400ContaAgencia ;
      private bool n401ContaNumero ;
      private bool n436ResponsavelNome ;
      private bool n439ResponsavelEstadoCivil ;
      private bool n576ResponsavelRG ;
      private bool n447ResponsavelCPF ;
      private bool n448ResponsavelCEP ;
      private bool n449ResponsavelLogradouro ;
      private bool n450ResponsavelBairro ;
      private bool n451ResponsavelCidade ;
      private bool n452ResponsavelLogradouroNumero ;
      private bool n453ResponsavelComplemento ;
      private bool n456ResponsavelEmail ;
      private bool n884ClienteSituacao ;
      private bool n885ResponsavelCargo ;
      private bool n1031RelacionamentoSacado ;
      private bool A1030ClienteSacado ;
      private bool n310ClienteValorAPagar_F ;
      private bool n311ClienteValorAReceber_F ;
      private bool A207TipoClientePortal ;
      private bool n207TipoClientePortal ;
      private bool A793TipoClientePortalPjPf ;
      private bool n793TipoClientePortalPjPf ;
      private bool n187MunicipioNome ;
      private bool n446ResponsavelMunicipioUF ;
      private bool n445ResponsavelMunicipioNome ;
      private bool n404BancoCodigo ;
      private bool n403BancoNome ;
      private bool n438ResponsavelNacionalidadeNome ;
      private bool n485ClienteNacionalidadeNome ;
      private bool n443ResponsavelProfissaoNome ;
      private bool n488ClienteProfissaoNome ;
      private bool n490ClienteConvenioDescricao ;
      private bool n608SecUserId_F ;
      private bool n309ClienteQtdTitulos_F ;
      private bool Combo_municipiocodigo_Enabled ;
      private bool Combo_municipiocodigo_Visible ;
      private bool Combo_municipiocodigo_Allowmultipleselection ;
      private bool Combo_municipiocodigo_Isgriditem ;
      private bool Combo_municipiocodigo_Hasdescription ;
      private bool Combo_municipiocodigo_Includeonlyselectedoption ;
      private bool Combo_municipiocodigo_Includeselectalloption ;
      private bool Combo_municipiocodigo_Emptyitem ;
      private bool Combo_municipiocodigo_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n193TipoClienteDescricao ;
      private bool n189MunicipioUF ;
      private bool returnInSub ;
      private bool Z207TipoClientePortal ;
      private bool Z793TipoClientePortalPjPf ;
      private bool Gx_longc ;
      private bool i174ClienteStatus ;
      private bool Z1030ClienteSacado ;
      private string AV22Combo_DataJson ;
      private string Z169ClienteDocumento ;
      private string Z170ClienteRazaoSocial ;
      private string Z171ClienteNomeFantasia ;
      private string Z172ClienteTipoPessoa ;
      private string Z486ClienteEstadoCivil ;
      private string Z181EnderecoTipo ;
      private string Z182EnderecoCEP ;
      private string Z183EnderecoLogradouro ;
      private string Z184EnderecoBairro ;
      private string Z185EnderecoCidade ;
      private string Z190EnderecoNumero ;
      private string Z191EnderecoComplemento ;
      private string Z201ContatoEmail ;
      private string Z537ClienteDepositoTipo ;
      private string Z538ClientePixTipo ;
      private string Z539ClientePix ;
      private string Z400ContaAgencia ;
      private string Z401ContaNumero ;
      private string Z436ResponsavelNome ;
      private string Z439ResponsavelEstadoCivil ;
      private string Z447ResponsavelCPF ;
      private string Z448ResponsavelCEP ;
      private string Z449ResponsavelLogradouro ;
      private string Z450ResponsavelBairro ;
      private string Z451ResponsavelCidade ;
      private string Z453ResponsavelComplemento ;
      private string Z456ResponsavelEmail ;
      private string Z885ResponsavelCargo ;
      private string Z1039ClienteTipoRisco ;
      private string Z186MunicipioCodigo ;
      private string Z444ResponsavelMunicipio ;
      private string N186MunicipioCodigo ;
      private string N444ResponsavelMunicipio ;
      private string A186MunicipioCodigo ;
      private string A444ResponsavelMunicipio ;
      private string A172ClienteTipoPessoa ;
      private string A181EnderecoTipo ;
      private string A169ClienteDocumento ;
      private string A170ClienteRazaoSocial ;
      private string A171ClienteNomeFantasia ;
      private string A193TipoClienteDescricao ;
      private string A182EnderecoCEP ;
      private string A183EnderecoLogradouro ;
      private string A184EnderecoBairro ;
      private string A185EnderecoCidade ;
      private string A189MunicipioUF ;
      private string A190EnderecoNumero ;
      private string A191EnderecoComplemento ;
      private string A201ContatoEmail ;
      private string A205ClienteTelefone_F ;
      private string A206ClienteCelular_F ;
      private string AV23ComboMunicipioCodigo ;
      private string A486ClienteEstadoCivil ;
      private string A537ClienteDepositoTipo ;
      private string A538ClientePixTipo ;
      private string A539ClientePix ;
      private string A400ContaAgencia ;
      private string A401ContaNumero ;
      private string A436ResponsavelNome ;
      private string A439ResponsavelEstadoCivil ;
      private string A447ResponsavelCPF ;
      private string A448ResponsavelCEP ;
      private string A449ResponsavelLogradouro ;
      private string A450ResponsavelBairro ;
      private string A451ResponsavelCidade ;
      private string A453ResponsavelComplemento ;
      private string A456ResponsavelEmail ;
      private string A885ResponsavelCargo ;
      private string A1039ClienteTipoRisco ;
      private string A577ResponsavelCelular_F ;
      private string AV17Insert_MunicipioCodigo ;
      private string AV28Insert_ResponsavelMunicipio ;
      private string A187MunicipioNome ;
      private string A446ResponsavelMunicipioUF ;
      private string A445ResponsavelMunicipioNome ;
      private string A403BancoNome ;
      private string A438ResponsavelNacionalidadeNome ;
      private string A485ClienteNacionalidadeNome ;
      private string A443ResponsavelProfissaoNome ;
      private string A488ClienteProfissaoNome ;
      private string A490ClienteConvenioDescricao ;
      private string AV20ComboSelectedValue ;
      private string AV21ComboSelectedText ;
      private string Z193TipoClienteDescricao ;
      private string Z446ResponsavelMunicipioUF ;
      private string Z445ResponsavelMunicipioNome ;
      private string Z403BancoNome ;
      private string Z438ResponsavelNacionalidadeNome ;
      private string Z485ClienteNacionalidadeNome ;
      private string Z443ResponsavelProfissaoNome ;
      private string Z488ClienteProfissaoNome ;
      private string Z490ClienteConvenioDescricao ;
      private string Z187MunicipioNome ;
      private string Z189MunicipioUF ;
      private IGxSession AV13WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_municipiocodigo ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbClienteTipoPessoa ;
      private GXCombobox cmbClienteStatus ;
      private GXCombobox cmbEnderecoTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV19DDO_TitleSettingsIcons ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV18MunicipioCodigo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV12TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV16TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] T000O17_A608SecUserId_F ;
      private bool[] T000O17_n608SecUserId_F ;
      private int[] T000O19_A309ClienteQtdTitulos_F ;
      private bool[] T000O19_n309ClienteQtdTitulos_F ;
      private decimal[] T000O23_A310ClienteValorAPagar_F ;
      private bool[] T000O23_n310ClienteValorAPagar_F ;
      private decimal[] T000O26_A311ClienteValorAReceber_F ;
      private bool[] T000O26_n311ClienteValorAReceber_F ;
      private DateTime[] T000O28_A780SerasaUltimaData_F ;
      private short[] T000O28_A732SerasaConsultas_F ;
      private short[] T000O15_A781SerasaScoreUltimaData_F ;
      private decimal[] T000O15_A785SerasaUltimoValorRecomendado_F ;
      private short[] T000O30_A1031RelacionamentoSacado ;
      private bool[] T000O30_n1031RelacionamentoSacado ;
      private int[] T000O40_A168ClienteId ;
      private bool[] T000O40_n168ClienteId ;
      private DateTime[] T000O40_A175ClienteCreatedAt ;
      private bool[] T000O40_n175ClienteCreatedAt ;
      private DateTime[] T000O40_A176ClienteUpdatedAt ;
      private bool[] T000O40_n176ClienteUpdatedAt ;
      private string[] T000O40_A169ClienteDocumento ;
      private bool[] T000O40_n169ClienteDocumento ;
      private string[] T000O40_A170ClienteRazaoSocial ;
      private bool[] T000O40_n170ClienteRazaoSocial ;
      private string[] T000O40_A171ClienteNomeFantasia ;
      private bool[] T000O40_n171ClienteNomeFantasia ;
      private DateTime[] T000O40_A459ClienteDataNascimento ;
      private bool[] T000O40_n459ClienteDataNascimento ;
      private string[] T000O40_A172ClienteTipoPessoa ;
      private bool[] T000O40_n172ClienteTipoPessoa ;
      private string[] T000O40_A193TipoClienteDescricao ;
      private bool[] T000O40_n193TipoClienteDescricao ;
      private bool[] T000O40_A207TipoClientePortal ;
      private bool[] T000O40_n207TipoClientePortal ;
      private bool[] T000O40_A174ClienteStatus ;
      private bool[] T000O40_n174ClienteStatus ;
      private string[] T000O40_A490ClienteConvenioDescricao ;
      private bool[] T000O40_n490ClienteConvenioDescricao ;
      private short[] T000O40_A177ClienteLogUser ;
      private bool[] T000O40_n177ClienteLogUser ;
      private string[] T000O40_A485ClienteNacionalidadeNome ;
      private bool[] T000O40_n485ClienteNacionalidadeNome ;
      private string[] T000O40_A488ClienteProfissaoNome ;
      private bool[] T000O40_n488ClienteProfissaoNome ;
      private string[] T000O40_A486ClienteEstadoCivil ;
      private bool[] T000O40_n486ClienteEstadoCivil ;
      private string[] T000O40_A181EnderecoTipo ;
      private bool[] T000O40_n181EnderecoTipo ;
      private string[] T000O40_A182EnderecoCEP ;
      private bool[] T000O40_n182EnderecoCEP ;
      private string[] T000O40_A183EnderecoLogradouro ;
      private bool[] T000O40_n183EnderecoLogradouro ;
      private string[] T000O40_A184EnderecoBairro ;
      private bool[] T000O40_n184EnderecoBairro ;
      private string[] T000O40_A185EnderecoCidade ;
      private bool[] T000O40_n185EnderecoCidade ;
      private string[] T000O40_A187MunicipioNome ;
      private bool[] T000O40_n187MunicipioNome ;
      private string[] T000O40_A189MunicipioUF ;
      private bool[] T000O40_n189MunicipioUF ;
      private string[] T000O40_A190EnderecoNumero ;
      private bool[] T000O40_n190EnderecoNumero ;
      private string[] T000O40_A191EnderecoComplemento ;
      private bool[] T000O40_n191EnderecoComplemento ;
      private string[] T000O40_A201ContatoEmail ;
      private bool[] T000O40_n201ContatoEmail ;
      private short[] T000O40_A198ContatoDDD ;
      private bool[] T000O40_n198ContatoDDD ;
      private short[] T000O40_A199ContatoDDI ;
      private bool[] T000O40_n199ContatoDDI ;
      private long[] T000O40_A200ContatoNumero ;
      private bool[] T000O40_n200ContatoNumero ;
      private long[] T000O40_A202ContatoTelefoneNumero ;
      private bool[] T000O40_n202ContatoTelefoneNumero ;
      private short[] T000O40_A203ContatoTelefoneDDD ;
      private bool[] T000O40_n203ContatoTelefoneDDD ;
      private short[] T000O40_A204ContatoTelefoneDDI ;
      private bool[] T000O40_n204ContatoTelefoneDDI ;
      private long[] T000O40_A421ClienteRG ;
      private bool[] T000O40_n421ClienteRG ;
      private string[] T000O40_A537ClienteDepositoTipo ;
      private bool[] T000O40_n537ClienteDepositoTipo ;
      private string[] T000O40_A538ClientePixTipo ;
      private bool[] T000O40_n538ClientePixTipo ;
      private string[] T000O40_A539ClientePix ;
      private bool[] T000O40_n539ClientePix ;
      private int[] T000O40_A404BancoCodigo ;
      private bool[] T000O40_n404BancoCodigo ;
      private string[] T000O40_A403BancoNome ;
      private bool[] T000O40_n403BancoNome ;
      private string[] T000O40_A400ContaAgencia ;
      private bool[] T000O40_n400ContaAgencia ;
      private string[] T000O40_A401ContaNumero ;
      private bool[] T000O40_n401ContaNumero ;
      private string[] T000O40_A436ResponsavelNome ;
      private bool[] T000O40_n436ResponsavelNome ;
      private string[] T000O40_A438ResponsavelNacionalidadeNome ;
      private bool[] T000O40_n438ResponsavelNacionalidadeNome ;
      private string[] T000O40_A439ResponsavelEstadoCivil ;
      private bool[] T000O40_n439ResponsavelEstadoCivil ;
      private long[] T000O40_A576ResponsavelRG ;
      private bool[] T000O40_n576ResponsavelRG ;
      private string[] T000O40_A443ResponsavelProfissaoNome ;
      private bool[] T000O40_n443ResponsavelProfissaoNome ;
      private string[] T000O40_A447ResponsavelCPF ;
      private bool[] T000O40_n447ResponsavelCPF ;
      private string[] T000O40_A448ResponsavelCEP ;
      private bool[] T000O40_n448ResponsavelCEP ;
      private string[] T000O40_A449ResponsavelLogradouro ;
      private bool[] T000O40_n449ResponsavelLogradouro ;
      private string[] T000O40_A450ResponsavelBairro ;
      private bool[] T000O40_n450ResponsavelBairro ;
      private string[] T000O40_A451ResponsavelCidade ;
      private bool[] T000O40_n451ResponsavelCidade ;
      private string[] T000O40_A446ResponsavelMunicipioUF ;
      private bool[] T000O40_n446ResponsavelMunicipioUF ;
      private string[] T000O40_A445ResponsavelMunicipioNome ;
      private bool[] T000O40_n445ResponsavelMunicipioNome ;
      private int[] T000O40_A452ResponsavelLogradouroNumero ;
      private bool[] T000O40_n452ResponsavelLogradouroNumero ;
      private string[] T000O40_A453ResponsavelComplemento ;
      private bool[] T000O40_n453ResponsavelComplemento ;
      private short[] T000O40_A454ResponsavelDDD ;
      private bool[] T000O40_n454ResponsavelDDD ;
      private int[] T000O40_A455ResponsavelNumero ;
      private bool[] T000O40_n455ResponsavelNumero ;
      private string[] T000O40_A456ResponsavelEmail ;
      private bool[] T000O40_n456ResponsavelEmail ;
      private string[] T000O40_A884ClienteSituacao ;
      private bool[] T000O40_n884ClienteSituacao ;
      private string[] T000O40_A885ResponsavelCargo ;
      private bool[] T000O40_n885ResponsavelCargo ;
      private bool[] T000O40_A793TipoClientePortalPjPf ;
      private bool[] T000O40_n793TipoClientePortalPjPf ;
      private string[] T000O40_A1039ClienteTipoRisco ;
      private short[] T000O40_A192TipoClienteId ;
      private bool[] T000O40_n192TipoClienteId ;
      private string[] T000O40_A186MunicipioCodigo ;
      private bool[] T000O40_n186MunicipioCodigo ;
      private string[] T000O40_A444ResponsavelMunicipio ;
      private bool[] T000O40_n444ResponsavelMunicipio ;
      private int[] T000O40_A402BancoId ;
      private bool[] T000O40_n402BancoId ;
      private int[] T000O40_A457EspecialidadeId ;
      private bool[] T000O40_n457EspecialidadeId ;
      private int[] T000O40_A437ResponsavelNacionalidade ;
      private bool[] T000O40_n437ResponsavelNacionalidade ;
      private int[] T000O40_A484ClienteNacionalidade ;
      private bool[] T000O40_n484ClienteNacionalidade ;
      private int[] T000O40_A442ResponsavelProfissao ;
      private bool[] T000O40_n442ResponsavelProfissao ;
      private int[] T000O40_A487ClienteProfissao ;
      private bool[] T000O40_n487ClienteProfissao ;
      private int[] T000O40_A489ClienteConvenio ;
      private bool[] T000O40_n489ClienteConvenio ;
      private DateTime[] T000O40_A780SerasaUltimaData_F ;
      private short[] T000O40_A608SecUserId_F ;
      private bool[] T000O40_n608SecUserId_F ;
      private int[] T000O40_A309ClienteQtdTitulos_F ;
      private bool[] T000O40_n309ClienteQtdTitulos_F ;
      private decimal[] T000O40_A310ClienteValorAPagar_F ;
      private bool[] T000O40_n310ClienteValorAPagar_F ;
      private decimal[] T000O40_A311ClienteValorAReceber_F ;
      private bool[] T000O40_n311ClienteValorAReceber_F ;
      private short[] T000O40_A732SerasaConsultas_F ;
      private short[] T000O40_A1031RelacionamentoSacado ;
      private bool[] T000O40_n1031RelacionamentoSacado ;
      private string[] T000O41_A169ClienteDocumento ;
      private bool[] T000O41_n169ClienteDocumento ;
      private string[] T000O5_A187MunicipioNome ;
      private bool[] T000O5_n187MunicipioNome ;
      private string[] T000O5_A189MunicipioUF ;
      private bool[] T000O5_n189MunicipioUF ;
      private string[] T000O4_A193TipoClienteDescricao ;
      private bool[] T000O4_n193TipoClienteDescricao ;
      private bool[] T000O4_A207TipoClientePortal ;
      private bool[] T000O4_n207TipoClientePortal ;
      private bool[] T000O4_A793TipoClientePortalPjPf ;
      private bool[] T000O4_n793TipoClientePortalPjPf ;
      private string[] T000O6_A446ResponsavelMunicipioUF ;
      private bool[] T000O6_n446ResponsavelMunicipioUF ;
      private string[] T000O6_A445ResponsavelMunicipioNome ;
      private bool[] T000O6_n445ResponsavelMunicipioNome ;
      private int[] T000O7_A404BancoCodigo ;
      private bool[] T000O7_n404BancoCodigo ;
      private string[] T000O7_A403BancoNome ;
      private bool[] T000O7_n403BancoNome ;
      private int[] T000O8_A457EspecialidadeId ;
      private bool[] T000O8_n457EspecialidadeId ;
      private string[] T000O9_A438ResponsavelNacionalidadeNome ;
      private bool[] T000O9_n438ResponsavelNacionalidadeNome ;
      private string[] T000O10_A485ClienteNacionalidadeNome ;
      private bool[] T000O10_n485ClienteNacionalidadeNome ;
      private string[] T000O11_A443ResponsavelProfissaoNome ;
      private bool[] T000O11_n443ResponsavelProfissaoNome ;
      private string[] T000O12_A488ClienteProfissaoNome ;
      private bool[] T000O12_n488ClienteProfissaoNome ;
      private string[] T000O13_A490ClienteConvenioDescricao ;
      private bool[] T000O13_n490ClienteConvenioDescricao ;
      private short[] T000O43_A608SecUserId_F ;
      private bool[] T000O43_n608SecUserId_F ;
      private int[] T000O45_A309ClienteQtdTitulos_F ;
      private bool[] T000O45_n309ClienteQtdTitulos_F ;
      private decimal[] T000O49_A310ClienteValorAPagar_F ;
      private bool[] T000O49_n310ClienteValorAPagar_F ;
      private decimal[] T000O52_A311ClienteValorAReceber_F ;
      private bool[] T000O52_n311ClienteValorAReceber_F ;
      private DateTime[] T000O54_A780SerasaUltimaData_F ;
      private short[] T000O54_A732SerasaConsultas_F ;
      private short[] T000O56_A781SerasaScoreUltimaData_F ;
      private decimal[] T000O56_A785SerasaUltimoValorRecomendado_F ;
      private short[] T000O58_A1031RelacionamentoSacado ;
      private bool[] T000O58_n1031RelacionamentoSacado ;
      private string[] T000O59_A187MunicipioNome ;
      private bool[] T000O59_n187MunicipioNome ;
      private string[] T000O59_A189MunicipioUF ;
      private bool[] T000O59_n189MunicipioUF ;
      private string[] T000O60_A193TipoClienteDescricao ;
      private bool[] T000O60_n193TipoClienteDescricao ;
      private bool[] T000O60_A207TipoClientePortal ;
      private bool[] T000O60_n207TipoClientePortal ;
      private bool[] T000O60_A793TipoClientePortalPjPf ;
      private bool[] T000O60_n793TipoClientePortalPjPf ;
      private string[] T000O61_A446ResponsavelMunicipioUF ;
      private bool[] T000O61_n446ResponsavelMunicipioUF ;
      private string[] T000O61_A445ResponsavelMunicipioNome ;
      private bool[] T000O61_n445ResponsavelMunicipioNome ;
      private int[] T000O62_A404BancoCodigo ;
      private bool[] T000O62_n404BancoCodigo ;
      private string[] T000O62_A403BancoNome ;
      private bool[] T000O62_n403BancoNome ;
      private int[] T000O63_A457EspecialidadeId ;
      private bool[] T000O63_n457EspecialidadeId ;
      private string[] T000O64_A438ResponsavelNacionalidadeNome ;
      private bool[] T000O64_n438ResponsavelNacionalidadeNome ;
      private string[] T000O65_A485ClienteNacionalidadeNome ;
      private bool[] T000O65_n485ClienteNacionalidadeNome ;
      private string[] T000O66_A443ResponsavelProfissaoNome ;
      private bool[] T000O66_n443ResponsavelProfissaoNome ;
      private string[] T000O67_A488ClienteProfissaoNome ;
      private bool[] T000O67_n488ClienteProfissaoNome ;
      private string[] T000O68_A490ClienteConvenioDescricao ;
      private bool[] T000O68_n490ClienteConvenioDescricao ;
      private int[] T000O69_A168ClienteId ;
      private bool[] T000O69_n168ClienteId ;
      private int[] T000O3_A168ClienteId ;
      private bool[] T000O3_n168ClienteId ;
      private DateTime[] T000O3_A175ClienteCreatedAt ;
      private bool[] T000O3_n175ClienteCreatedAt ;
      private DateTime[] T000O3_A176ClienteUpdatedAt ;
      private bool[] T000O3_n176ClienteUpdatedAt ;
      private string[] T000O3_A169ClienteDocumento ;
      private bool[] T000O3_n169ClienteDocumento ;
      private string[] T000O3_A170ClienteRazaoSocial ;
      private bool[] T000O3_n170ClienteRazaoSocial ;
      private string[] T000O3_A171ClienteNomeFantasia ;
      private bool[] T000O3_n171ClienteNomeFantasia ;
      private DateTime[] T000O3_A459ClienteDataNascimento ;
      private bool[] T000O3_n459ClienteDataNascimento ;
      private string[] T000O3_A172ClienteTipoPessoa ;
      private bool[] T000O3_n172ClienteTipoPessoa ;
      private bool[] T000O3_A174ClienteStatus ;
      private bool[] T000O3_n174ClienteStatus ;
      private short[] T000O3_A177ClienteLogUser ;
      private bool[] T000O3_n177ClienteLogUser ;
      private string[] T000O3_A486ClienteEstadoCivil ;
      private bool[] T000O3_n486ClienteEstadoCivil ;
      private string[] T000O3_A181EnderecoTipo ;
      private bool[] T000O3_n181EnderecoTipo ;
      private string[] T000O3_A182EnderecoCEP ;
      private bool[] T000O3_n182EnderecoCEP ;
      private string[] T000O3_A183EnderecoLogradouro ;
      private bool[] T000O3_n183EnderecoLogradouro ;
      private string[] T000O3_A184EnderecoBairro ;
      private bool[] T000O3_n184EnderecoBairro ;
      private string[] T000O3_A185EnderecoCidade ;
      private bool[] T000O3_n185EnderecoCidade ;
      private string[] T000O3_A190EnderecoNumero ;
      private bool[] T000O3_n190EnderecoNumero ;
      private string[] T000O3_A191EnderecoComplemento ;
      private bool[] T000O3_n191EnderecoComplemento ;
      private string[] T000O3_A201ContatoEmail ;
      private bool[] T000O3_n201ContatoEmail ;
      private short[] T000O3_A198ContatoDDD ;
      private bool[] T000O3_n198ContatoDDD ;
      private short[] T000O3_A199ContatoDDI ;
      private bool[] T000O3_n199ContatoDDI ;
      private long[] T000O3_A200ContatoNumero ;
      private bool[] T000O3_n200ContatoNumero ;
      private long[] T000O3_A202ContatoTelefoneNumero ;
      private bool[] T000O3_n202ContatoTelefoneNumero ;
      private short[] T000O3_A203ContatoTelefoneDDD ;
      private bool[] T000O3_n203ContatoTelefoneDDD ;
      private short[] T000O3_A204ContatoTelefoneDDI ;
      private bool[] T000O3_n204ContatoTelefoneDDI ;
      private long[] T000O3_A421ClienteRG ;
      private bool[] T000O3_n421ClienteRG ;
      private string[] T000O3_A537ClienteDepositoTipo ;
      private bool[] T000O3_n537ClienteDepositoTipo ;
      private string[] T000O3_A538ClientePixTipo ;
      private bool[] T000O3_n538ClientePixTipo ;
      private string[] T000O3_A539ClientePix ;
      private bool[] T000O3_n539ClientePix ;
      private string[] T000O3_A400ContaAgencia ;
      private bool[] T000O3_n400ContaAgencia ;
      private string[] T000O3_A401ContaNumero ;
      private bool[] T000O3_n401ContaNumero ;
      private string[] T000O3_A436ResponsavelNome ;
      private bool[] T000O3_n436ResponsavelNome ;
      private string[] T000O3_A439ResponsavelEstadoCivil ;
      private bool[] T000O3_n439ResponsavelEstadoCivil ;
      private long[] T000O3_A576ResponsavelRG ;
      private bool[] T000O3_n576ResponsavelRG ;
      private string[] T000O3_A447ResponsavelCPF ;
      private bool[] T000O3_n447ResponsavelCPF ;
      private string[] T000O3_A448ResponsavelCEP ;
      private bool[] T000O3_n448ResponsavelCEP ;
      private string[] T000O3_A449ResponsavelLogradouro ;
      private bool[] T000O3_n449ResponsavelLogradouro ;
      private string[] T000O3_A450ResponsavelBairro ;
      private bool[] T000O3_n450ResponsavelBairro ;
      private string[] T000O3_A451ResponsavelCidade ;
      private bool[] T000O3_n451ResponsavelCidade ;
      private int[] T000O3_A452ResponsavelLogradouroNumero ;
      private bool[] T000O3_n452ResponsavelLogradouroNumero ;
      private string[] T000O3_A453ResponsavelComplemento ;
      private bool[] T000O3_n453ResponsavelComplemento ;
      private short[] T000O3_A454ResponsavelDDD ;
      private bool[] T000O3_n454ResponsavelDDD ;
      private int[] T000O3_A455ResponsavelNumero ;
      private bool[] T000O3_n455ResponsavelNumero ;
      private string[] T000O3_A456ResponsavelEmail ;
      private bool[] T000O3_n456ResponsavelEmail ;
      private string[] T000O3_A884ClienteSituacao ;
      private bool[] T000O3_n884ClienteSituacao ;
      private string[] T000O3_A885ResponsavelCargo ;
      private bool[] T000O3_n885ResponsavelCargo ;
      private string[] T000O3_A1039ClienteTipoRisco ;
      private short[] T000O3_A192TipoClienteId ;
      private bool[] T000O3_n192TipoClienteId ;
      private string[] T000O3_A186MunicipioCodigo ;
      private bool[] T000O3_n186MunicipioCodigo ;
      private string[] T000O3_A444ResponsavelMunicipio ;
      private bool[] T000O3_n444ResponsavelMunicipio ;
      private int[] T000O3_A402BancoId ;
      private bool[] T000O3_n402BancoId ;
      private int[] T000O3_A457EspecialidadeId ;
      private bool[] T000O3_n457EspecialidadeId ;
      private int[] T000O3_A437ResponsavelNacionalidade ;
      private bool[] T000O3_n437ResponsavelNacionalidade ;
      private int[] T000O3_A484ClienteNacionalidade ;
      private bool[] T000O3_n484ClienteNacionalidade ;
      private int[] T000O3_A442ResponsavelProfissao ;
      private bool[] T000O3_n442ResponsavelProfissao ;
      private int[] T000O3_A487ClienteProfissao ;
      private bool[] T000O3_n487ClienteProfissao ;
      private int[] T000O3_A489ClienteConvenio ;
      private bool[] T000O3_n489ClienteConvenio ;
      private int[] T000O70_A168ClienteId ;
      private bool[] T000O70_n168ClienteId ;
      private int[] T000O71_A168ClienteId ;
      private bool[] T000O71_n168ClienteId ;
      private int[] T000O2_A168ClienteId ;
      private bool[] T000O2_n168ClienteId ;
      private DateTime[] T000O2_A175ClienteCreatedAt ;
      private bool[] T000O2_n175ClienteCreatedAt ;
      private DateTime[] T000O2_A176ClienteUpdatedAt ;
      private bool[] T000O2_n176ClienteUpdatedAt ;
      private string[] T000O2_A169ClienteDocumento ;
      private bool[] T000O2_n169ClienteDocumento ;
      private string[] T000O2_A170ClienteRazaoSocial ;
      private bool[] T000O2_n170ClienteRazaoSocial ;
      private string[] T000O2_A171ClienteNomeFantasia ;
      private bool[] T000O2_n171ClienteNomeFantasia ;
      private DateTime[] T000O2_A459ClienteDataNascimento ;
      private bool[] T000O2_n459ClienteDataNascimento ;
      private string[] T000O2_A172ClienteTipoPessoa ;
      private bool[] T000O2_n172ClienteTipoPessoa ;
      private bool[] T000O2_A174ClienteStatus ;
      private bool[] T000O2_n174ClienteStatus ;
      private short[] T000O2_A177ClienteLogUser ;
      private bool[] T000O2_n177ClienteLogUser ;
      private string[] T000O2_A486ClienteEstadoCivil ;
      private bool[] T000O2_n486ClienteEstadoCivil ;
      private string[] T000O2_A181EnderecoTipo ;
      private bool[] T000O2_n181EnderecoTipo ;
      private string[] T000O2_A182EnderecoCEP ;
      private bool[] T000O2_n182EnderecoCEP ;
      private string[] T000O2_A183EnderecoLogradouro ;
      private bool[] T000O2_n183EnderecoLogradouro ;
      private string[] T000O2_A184EnderecoBairro ;
      private bool[] T000O2_n184EnderecoBairro ;
      private string[] T000O2_A185EnderecoCidade ;
      private bool[] T000O2_n185EnderecoCidade ;
      private string[] T000O2_A190EnderecoNumero ;
      private bool[] T000O2_n190EnderecoNumero ;
      private string[] T000O2_A191EnderecoComplemento ;
      private bool[] T000O2_n191EnderecoComplemento ;
      private string[] T000O2_A201ContatoEmail ;
      private bool[] T000O2_n201ContatoEmail ;
      private short[] T000O2_A198ContatoDDD ;
      private bool[] T000O2_n198ContatoDDD ;
      private short[] T000O2_A199ContatoDDI ;
      private bool[] T000O2_n199ContatoDDI ;
      private long[] T000O2_A200ContatoNumero ;
      private bool[] T000O2_n200ContatoNumero ;
      private long[] T000O2_A202ContatoTelefoneNumero ;
      private bool[] T000O2_n202ContatoTelefoneNumero ;
      private short[] T000O2_A203ContatoTelefoneDDD ;
      private bool[] T000O2_n203ContatoTelefoneDDD ;
      private short[] T000O2_A204ContatoTelefoneDDI ;
      private bool[] T000O2_n204ContatoTelefoneDDI ;
      private long[] T000O2_A421ClienteRG ;
      private bool[] T000O2_n421ClienteRG ;
      private string[] T000O2_A537ClienteDepositoTipo ;
      private bool[] T000O2_n537ClienteDepositoTipo ;
      private string[] T000O2_A538ClientePixTipo ;
      private bool[] T000O2_n538ClientePixTipo ;
      private string[] T000O2_A539ClientePix ;
      private bool[] T000O2_n539ClientePix ;
      private string[] T000O2_A400ContaAgencia ;
      private bool[] T000O2_n400ContaAgencia ;
      private string[] T000O2_A401ContaNumero ;
      private bool[] T000O2_n401ContaNumero ;
      private string[] T000O2_A436ResponsavelNome ;
      private bool[] T000O2_n436ResponsavelNome ;
      private string[] T000O2_A439ResponsavelEstadoCivil ;
      private bool[] T000O2_n439ResponsavelEstadoCivil ;
      private long[] T000O2_A576ResponsavelRG ;
      private bool[] T000O2_n576ResponsavelRG ;
      private string[] T000O2_A447ResponsavelCPF ;
      private bool[] T000O2_n447ResponsavelCPF ;
      private string[] T000O2_A448ResponsavelCEP ;
      private bool[] T000O2_n448ResponsavelCEP ;
      private string[] T000O2_A449ResponsavelLogradouro ;
      private bool[] T000O2_n449ResponsavelLogradouro ;
      private string[] T000O2_A450ResponsavelBairro ;
      private bool[] T000O2_n450ResponsavelBairro ;
      private string[] T000O2_A451ResponsavelCidade ;
      private bool[] T000O2_n451ResponsavelCidade ;
      private int[] T000O2_A452ResponsavelLogradouroNumero ;
      private bool[] T000O2_n452ResponsavelLogradouroNumero ;
      private string[] T000O2_A453ResponsavelComplemento ;
      private bool[] T000O2_n453ResponsavelComplemento ;
      private short[] T000O2_A454ResponsavelDDD ;
      private bool[] T000O2_n454ResponsavelDDD ;
      private int[] T000O2_A455ResponsavelNumero ;
      private bool[] T000O2_n455ResponsavelNumero ;
      private string[] T000O2_A456ResponsavelEmail ;
      private bool[] T000O2_n456ResponsavelEmail ;
      private string[] T000O2_A884ClienteSituacao ;
      private bool[] T000O2_n884ClienteSituacao ;
      private string[] T000O2_A885ResponsavelCargo ;
      private bool[] T000O2_n885ResponsavelCargo ;
      private string[] T000O2_A1039ClienteTipoRisco ;
      private short[] T000O2_A192TipoClienteId ;
      private bool[] T000O2_n192TipoClienteId ;
      private string[] T000O2_A186MunicipioCodigo ;
      private bool[] T000O2_n186MunicipioCodigo ;
      private string[] T000O2_A444ResponsavelMunicipio ;
      private bool[] T000O2_n444ResponsavelMunicipio ;
      private int[] T000O2_A402BancoId ;
      private bool[] T000O2_n402BancoId ;
      private int[] T000O2_A457EspecialidadeId ;
      private bool[] T000O2_n457EspecialidadeId ;
      private int[] T000O2_A437ResponsavelNacionalidade ;
      private bool[] T000O2_n437ResponsavelNacionalidade ;
      private int[] T000O2_A484ClienteNacionalidade ;
      private bool[] T000O2_n484ClienteNacionalidade ;
      private int[] T000O2_A442ResponsavelProfissao ;
      private bool[] T000O2_n442ResponsavelProfissao ;
      private int[] T000O2_A487ClienteProfissao ;
      private bool[] T000O2_n487ClienteProfissao ;
      private int[] T000O2_A489ClienteConvenio ;
      private bool[] T000O2_n489ClienteConvenio ;
      private int[] T000O73_A168ClienteId ;
      private bool[] T000O73_n168ClienteId ;
      private short[] T000O77_A608SecUserId_F ;
      private bool[] T000O77_n608SecUserId_F ;
      private int[] T000O79_A309ClienteQtdTitulos_F ;
      private bool[] T000O79_n309ClienteQtdTitulos_F ;
      private decimal[] T000O83_A310ClienteValorAPagar_F ;
      private bool[] T000O83_n310ClienteValorAPagar_F ;
      private decimal[] T000O86_A311ClienteValorAReceber_F ;
      private bool[] T000O86_n311ClienteValorAReceber_F ;
      private DateTime[] T000O88_A780SerasaUltimaData_F ;
      private short[] T000O88_A732SerasaConsultas_F ;
      private short[] T000O90_A781SerasaScoreUltimaData_F ;
      private decimal[] T000O90_A785SerasaUltimoValorRecomendado_F ;
      private short[] T000O92_A1031RelacionamentoSacado ;
      private bool[] T000O92_n1031RelacionamentoSacado ;
      private string[] T000O93_A187MunicipioNome ;
      private bool[] T000O93_n187MunicipioNome ;
      private string[] T000O93_A189MunicipioUF ;
      private bool[] T000O93_n189MunicipioUF ;
      private string[] T000O94_A193TipoClienteDescricao ;
      private bool[] T000O94_n193TipoClienteDescricao ;
      private bool[] T000O94_A207TipoClientePortal ;
      private bool[] T000O94_n207TipoClientePortal ;
      private bool[] T000O94_A793TipoClientePortalPjPf ;
      private bool[] T000O94_n793TipoClientePortalPjPf ;
      private string[] T000O95_A446ResponsavelMunicipioUF ;
      private bool[] T000O95_n446ResponsavelMunicipioUF ;
      private string[] T000O95_A445ResponsavelMunicipioNome ;
      private bool[] T000O95_n445ResponsavelMunicipioNome ;
      private int[] T000O96_A404BancoCodigo ;
      private bool[] T000O96_n404BancoCodigo ;
      private string[] T000O96_A403BancoNome ;
      private bool[] T000O96_n403BancoNome ;
      private string[] T000O97_A438ResponsavelNacionalidadeNome ;
      private bool[] T000O97_n438ResponsavelNacionalidadeNome ;
      private string[] T000O98_A485ClienteNacionalidadeNome ;
      private bool[] T000O98_n485ClienteNacionalidadeNome ;
      private string[] T000O99_A443ResponsavelProfissaoNome ;
      private bool[] T000O99_n443ResponsavelProfissaoNome ;
      private string[] T000O100_A488ClienteProfissaoNome ;
      private bool[] T000O100_n488ClienteProfissaoNome ;
      private string[] T000O101_A490ClienteConvenioDescricao ;
      private bool[] T000O101_n490ClienteConvenioDescricao ;
      private int[] T000O102_A1019OperacoesTitulosId ;
      private int[] T000O103_A323PropostaId ;
      private int[] T000O104_A323PropostaId ;
      private int[] T000O105_A323PropostaId ;
      private int[] T000O106_A323PropostaId ;
      private int[] T000O107_A227ContratoId ;
      private int[] T000O108_A261TituloId ;
      private bool[] T000O108_n261TituloId ;
      private short[] T000O109_A133SecUserId ;
      private int[] T000O110_A1032RelacionamentoId ;
      private int[] T000O111_A1010OperacoesId ;
      private int[] T000O112_A978RepresentanteId ;
      private int[] T000O113_A856CreditoId ;
      private Guid[] T000O114_A794NotaFiscalId ;
      private bool[] T000O114_n794NotaFiscalId ;
      private Guid[] T000O115_A794NotaFiscalId ;
      private bool[] T000O115_n794NotaFiscalId ;
      private int[] T000O116_A662SerasaId ;
      private int[] T000O117_A599ClienteDocumentoId ;
      private int[] T000O118_A551ClienteReponsavelId ;
      private int[] T000O119_A551ClienteReponsavelId ;
      private int[] T000O120_A242AssinaturaParticipanteId ;
      private int[] T000O121_A223FinanciamentoId ;
      private int[] T000O122_A223FinanciamentoId ;
      private int[] T000O123_A168ClienteId ;
      private bool[] T000O123_n168ClienteId ;
      private string[] T000O124_A169ClienteDocumento ;
      private bool[] T000O124_n169ClienteDocumento ;
   }

   public class cliente__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new ForEachCursor(def[38])
         ,new ForEachCursor(def[39])
         ,new ForEachCursor(def[40])
         ,new UpdateCursor(def[41])
         ,new ForEachCursor(def[42])
         ,new UpdateCursor(def[43])
         ,new UpdateCursor(def[44])
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
         ,new ForEachCursor(def[55])
         ,new ForEachCursor(def[56])
         ,new ForEachCursor(def[57])
         ,new ForEachCursor(def[58])
         ,new ForEachCursor(def[59])
         ,new ForEachCursor(def[60])
         ,new ForEachCursor(def[61])
         ,new ForEachCursor(def[62])
         ,new ForEachCursor(def[63])
         ,new ForEachCursor(def[64])
         ,new ForEachCursor(def[65])
         ,new ForEachCursor(def[66])
         ,new ForEachCursor(def[67])
         ,new ForEachCursor(def[68])
         ,new ForEachCursor(def[69])
         ,new ForEachCursor(def[70])
         ,new ForEachCursor(def[71])
         ,new ForEachCursor(def[72])
         ,new ForEachCursor(def[73])
         ,new ForEachCursor(def[74])
         ,new ForEachCursor(def[75])
         ,new ForEachCursor(def[76])
         ,new ForEachCursor(def[77])
         ,new ForEachCursor(def[78])
         ,new ForEachCursor(def[79])
         ,new ForEachCursor(def[80])
         ,new ForEachCursor(def[81])
         ,new ForEachCursor(def[82])
         ,new ForEachCursor(def[83])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000O2;
          prmT000O2 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O3;
          prmT000O3 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O4;
          prmT000O4 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000O5;
          prmT000O5 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000O6;
          prmT000O6 = new Object[] {
          new ParDef("ResponsavelMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000O7;
          prmT000O7 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O8;
          prmT000O8 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O9;
          prmT000O9 = new Object[] {
          new ParDef("ResponsavelNacionalidade",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O10;
          prmT000O10 = new Object[] {
          new ParDef("ClienteNacionalidade",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O11;
          prmT000O11 = new Object[] {
          new ParDef("ResponsavelProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O12;
          prmT000O12 = new Object[] {
          new ParDef("ClienteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O13;
          prmT000O13 = new Object[] {
          new ParDef("ClienteConvenio",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O19;
          prmT000O19 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O23;
          prmT000O23 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O26;
          prmT000O26 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O28;
          prmT000O28 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O30;
          prmT000O30 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O17;
          prmT000O17 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O15;
          prmT000O15 = new Object[] {
          new ParDef("SerasaUltimaData_F",GXType.DateTime,8,5) ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O40;
          prmT000O40 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferT000O40;
          cmdBufferT000O40=" SELECT TM1.ClienteId, TM1.ClienteCreatedAt, TM1.ClienteUpdatedAt, TM1.ClienteDocumento, TM1.ClienteRazaoSocial, TM1.ClienteNomeFantasia, TM1.ClienteDataNascimento, TM1.ClienteTipoPessoa, T2.TipoClienteDescricao, T2.TipoClientePortal, TM1.ClienteStatus, T9.ConvenioDescricao AS ClienteConvenioDescricao, TM1.ClienteLogUser, T6.NacionalidadeNome AS ClienteNacionalidadeNome, T8.ProfissaoNome AS ClienteProfissaoNome, TM1.ClienteEstadoCivil, TM1.EnderecoTipo, TM1.EnderecoCEP, TM1.EnderecoLogradouro, TM1.EnderecoBairro, TM1.EnderecoCidade, T16.MunicipioNome, T16.MunicipioUF, TM1.EnderecoNumero, TM1.EnderecoComplemento, TM1.ContatoEmail, TM1.ContatoDDD, TM1.ContatoDDI, TM1.ContatoNumero, TM1.ContatoTelefoneNumero, TM1.ContatoTelefoneDDD, TM1.ContatoTelefoneDDI, TM1.ClienteRG, TM1.ClienteDepositoTipo, TM1.ClientePixTipo, TM1.ClientePix, T4.BancoCodigo, T4.BancoNome, TM1.ContaAgencia, TM1.ContaNumero, TM1.ResponsavelNome, T5.NacionalidadeNome AS ResponsavelNacionalidadeNome, TM1.ResponsavelEstadoCivil, TM1.ResponsavelRG, T7.ProfissaoNome AS ResponsavelProfissaoNome, TM1.ResponsavelCPF, TM1.ResponsavelCEP, TM1.ResponsavelLogradouro, TM1.ResponsavelBairro, TM1.ResponsavelCidade, T3.MunicipioUF AS ResponsavelMunicipioUF, T3.MunicipioNome AS ResponsavelMunicipioNome, TM1.ResponsavelLogradouroNumero, TM1.ResponsavelComplemento, TM1.ResponsavelDDD, TM1.ResponsavelNumero, TM1.ResponsavelEmail, TM1.ClienteSituacao, TM1.ResponsavelCargo, T2.TipoClientePortalPjPf, TM1.ClienteTipoRisco, TM1.TipoClienteId, TM1.MunicipioCodigo, TM1.ResponsavelMunicipio AS ResponsavelMunicipio, TM1.BancoId, TM1.EspecialidadeId, TM1.ResponsavelNacionalidade AS ResponsavelNacionalidade, TM1.ClienteNacionalidade AS ClienteNacionalidade, TM1.ResponsavelProfissao AS ResponsavelProfissao, TM1.ClienteProfissao AS ClienteProfissao, "
          + " TM1.ClienteConvenio AS ClienteConvenio, COALESCE( T14.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, COALESCE( T10.SecUserId_F, 0) AS SecUserId_F, COALESCE( T11.ClienteQtdTitulos_F, 0) AS ClienteQtdTitulos_F, COALESCE( T12.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F, COALESCE( T13.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F, COALESCE( T14.SerasaConsultas_F, 0) AS SerasaConsultas_F, COALESCE( T15.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (((((((((((((((Cliente TM1 LEFT JOIN TipoCliente T2 ON T2.TipoClienteId = TM1.TipoClienteId) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = TM1.ResponsavelMunicipio) LEFT JOIN Banco T4 ON T4.BancoId = TM1.BancoId) LEFT JOIN Nacionalidade T5 ON T5.NacionalidadeId = TM1.ResponsavelNacionalidade) LEFT JOIN Nacionalidade T6 ON T6.NacionalidadeId = TM1.ClienteNacionalidade) LEFT JOIN Profissao T7 ON T7.ProfissaoId = TM1.ResponsavelProfissao) LEFT JOIN Profissao T8 ON T8.ProfissaoId = TM1.ClienteProfissao) LEFT JOIN Convenio T9 ON T9.ConvenioId = TM1.ClienteConvenio) LEFT JOIN LATERAL (SELECT MIN(SecUserId) AS SecUserId_F, SecUserOwnerId FROM SecUser WHERE (TM1.ClienteId = SecUserOwnerId) AND (SecUserOwnerId = :ClienteId) GROUP BY SecUserOwnerId ) T10 ON T10.SecUserOwnerId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteQtdTitulos_F, T19.ClienteId FROM ((Titulo T17 LEFT JOIN NotaFiscalParcelamento T18 ON T18.NotaFiscalParcelamentoID = T17.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T19 ON T19.NotaFiscalId = T18.NotaFiscalId) WHERE (TM1.ClienteId = T19.ClienteId) AND (Not T17.TituloDeleted) GROUP BY T19.ClienteId ) T11 ON T11.ClienteId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT SUM(COALESCE( T20.TituloSaldoDebito_F, 0)) AS ClienteValorAPagar_F, T19.ClienteId FROM (((Titulo T17 LEFT JOIN NotaFiscalParcelamento"
          + " T18 ON T18.NotaFiscalParcelamentoID = T17.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T19 ON T19.NotaFiscalId = T18.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T21.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T21.TituloValor, 0) - COALESCE( T21.TituloDesconto, 0)) - COALESCE( T22.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoDebito_F, T21.TituloId FROM (Titulo T21 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T21.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T22 ON T22.TituloId = T21.TituloId) ) T20 ON T20.TituloId = T17.TituloId) WHERE TM1.ClienteId = T19.ClienteId GROUP BY T19.ClienteId ) T12 ON T12.ClienteId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT SUM(CASE  WHEN COALESCE( T17.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T17.TituloValor, 0) - COALESCE( T17.TituloDesconto, 0)) - COALESCE( T20.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAReceber_F, T19.ClienteId FROM (((Titulo T17 LEFT JOIN NotaFiscalParcelamento T18 ON T18.NotaFiscalParcelamentoID = T17.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T19 ON T19.NotaFiscalId = T18.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T17.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T20 ON T20.TituloId = T17.TituloId) WHERE TM1.ClienteId = T19.ClienteId GROUP BY T19.ClienteId ) T13 ON T13.ClienteId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS SerasaConsultas_F, ClienteId, MAX(SerasaCreatedAt) AS SerasaUltimaData_F FROM Serasa WHERE TM1.ClienteId = ClienteId GROUP BY ClienteId ) T14 ON T14.ClienteId = TM1.ClienteId) LEFT JOIN LATERAL (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento"
          + " WHERE (TM1.ClienteId = ClienteId) AND (RelacionamentoTipo = ( 'Sacado')) GROUP BY ClienteId ) T15 ON T15.ClienteId = TM1.ClienteId) LEFT JOIN Municipio T16 ON T16.MunicipioCodigo = TM1.MunicipioCodigo) WHERE TM1.ClienteId = :ClienteId ORDER BY TM1.ClienteId" ;
          Object[] prmT000O41;
          prmT000O41 = new Object[] {
          new ParDef("ClienteDocumento",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O43;
          prmT000O43 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O45;
          prmT000O45 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O49;
          prmT000O49 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O52;
          prmT000O52 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O54;
          prmT000O54 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O56;
          prmT000O56 = new Object[] {
          new ParDef("SerasaUltimaData_F",GXType.DateTime,8,5) ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O58;
          prmT000O58 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O59;
          prmT000O59 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000O60;
          prmT000O60 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000O61;
          prmT000O61 = new Object[] {
          new ParDef("ResponsavelMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000O62;
          prmT000O62 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O63;
          prmT000O63 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O64;
          prmT000O64 = new Object[] {
          new ParDef("ResponsavelNacionalidade",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O65;
          prmT000O65 = new Object[] {
          new ParDef("ClienteNacionalidade",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O66;
          prmT000O66 = new Object[] {
          new ParDef("ResponsavelProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O67;
          prmT000O67 = new Object[] {
          new ParDef("ClienteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O68;
          prmT000O68 = new Object[] {
          new ParDef("ClienteConvenio",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O69;
          prmT000O69 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O70;
          prmT000O70 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O71;
          prmT000O71 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O72;
          prmT000O72 = new Object[] {
          new ParDef("ClienteCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteDocumento",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("ClienteRazaoSocial",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ClienteNomeFantasia",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ClienteDataNascimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ClienteTipoPessoa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ClienteLogUser",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ClienteEstadoCivil",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EnderecoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EnderecoCEP",GXType.VarChar,8,0){Nullable=true} ,
          new ParDef("EnderecoLogradouro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EnderecoBairro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EnderecoCidade",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EnderecoNumero",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("EnderecoComplemento",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ContatoEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ContatoDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContatoDDI",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContatoNumero",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("ContatoTelefoneNumero",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("ContatoTelefoneDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContatoTelefoneDDI",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ClienteRG",GXType.Int64,12,0){Nullable=true} ,
          new ParDef("ClienteDepositoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClientePixTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClientePix",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("ContaAgencia",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ContaNumero",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ResponsavelNome",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("ResponsavelEstadoCivil",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ResponsavelRG",GXType.Int64,12,0){Nullable=true} ,
          new ParDef("ResponsavelCPF",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("ResponsavelCEP",GXType.VarChar,15,0){Nullable=true} ,
          new ParDef("ResponsavelLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelCidade",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelLogradouroNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ResponsavelNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ClienteSituacao",GXType.Char,1,0){Nullable=true} ,
          new ParDef("ResponsavelCargo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTipoRisco",GXType.VarChar,40,0) ,
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ResponsavelMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelNacionalidade",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteNacionalidade",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteConvenio",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferT000O72;
          cmdBufferT000O72=" SAVEPOINT gxupdate;INSERT INTO Cliente(ClienteCreatedAt, ClienteUpdatedAt, ClienteDocumento, ClienteRazaoSocial, ClienteNomeFantasia, ClienteDataNascimento, ClienteTipoPessoa, ClienteStatus, ClienteLogUser, ClienteEstadoCivil, EnderecoTipo, EnderecoCEP, EnderecoLogradouro, EnderecoBairro, EnderecoCidade, EnderecoNumero, EnderecoComplemento, ContatoEmail, ContatoDDD, ContatoDDI, ContatoNumero, ContatoTelefoneNumero, ContatoTelefoneDDD, ContatoTelefoneDDI, ClienteRG, ClienteDepositoTipo, ClientePixTipo, ClientePix, ContaAgencia, ContaNumero, ResponsavelNome, ResponsavelEstadoCivil, ResponsavelRG, ResponsavelCPF, ResponsavelCEP, ResponsavelLogradouro, ResponsavelBairro, ResponsavelCidade, ResponsavelLogradouroNumero, ResponsavelComplemento, ResponsavelDDD, ResponsavelNumero, ResponsavelEmail, ClienteSituacao, ResponsavelCargo, ClienteTipoRisco, TipoClienteId, MunicipioCodigo, ResponsavelMunicipio, BancoId, EspecialidadeId, ResponsavelNacionalidade, ClienteNacionalidade, ResponsavelProfissao, ClienteProfissao, ClienteConvenio) VALUES(:ClienteCreatedAt, :ClienteUpdatedAt, :ClienteDocumento, :ClienteRazaoSocial, :ClienteNomeFantasia, :ClienteDataNascimento, :ClienteTipoPessoa, :ClienteStatus, :ClienteLogUser, :ClienteEstadoCivil, :EnderecoTipo, :EnderecoCEP, :EnderecoLogradouro, :EnderecoBairro, :EnderecoCidade, :EnderecoNumero, :EnderecoComplemento, :ContatoEmail, :ContatoDDD, :ContatoDDI, :ContatoNumero, :ContatoTelefoneNumero, :ContatoTelefoneDDD, :ContatoTelefoneDDI, :ClienteRG, :ClienteDepositoTipo, :ClientePixTipo, :ClientePix, :ContaAgencia, :ContaNumero, :ResponsavelNome, :ResponsavelEstadoCivil, :ResponsavelRG, :ResponsavelCPF, :ResponsavelCEP, :ResponsavelLogradouro, :ResponsavelBairro, :ResponsavelCidade, :ResponsavelLogradouroNumero, :ResponsavelComplemento, :ResponsavelDDD, "
          + " :ResponsavelNumero, :ResponsavelEmail, :ClienteSituacao, :ResponsavelCargo, :ClienteTipoRisco, :TipoClienteId, :MunicipioCodigo, :ResponsavelMunicipio, :BancoId, :EspecialidadeId, :ResponsavelNacionalidade, :ClienteNacionalidade, :ResponsavelProfissao, :ClienteProfissao, :ClienteConvenio);RELEASE SAVEPOINT gxupdate" ;
          Object[] prmT000O73;
          prmT000O73 = new Object[] {
          };
          Object[] prmT000O74;
          prmT000O74 = new Object[] {
          new ParDef("ClienteCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteDocumento",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("ClienteRazaoSocial",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ClienteNomeFantasia",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ClienteDataNascimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ClienteTipoPessoa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ClienteLogUser",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ClienteEstadoCivil",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EnderecoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EnderecoCEP",GXType.VarChar,8,0){Nullable=true} ,
          new ParDef("EnderecoLogradouro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EnderecoBairro",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EnderecoCidade",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("EnderecoNumero",GXType.VarChar,10,0){Nullable=true} ,
          new ParDef("EnderecoComplemento",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ContatoEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ContatoDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContatoDDI",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContatoNumero",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("ContatoTelefoneNumero",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("ContatoTelefoneDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContatoTelefoneDDI",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ClienteRG",GXType.Int64,12,0){Nullable=true} ,
          new ParDef("ClienteDepositoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClientePixTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClientePix",GXType.VarChar,80,0){Nullable=true} ,
          new ParDef("ContaAgencia",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ContaNumero",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("ResponsavelNome",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("ResponsavelEstadoCivil",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ResponsavelRG",GXType.Int64,12,0){Nullable=true} ,
          new ParDef("ResponsavelCPF",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("ResponsavelCEP",GXType.VarChar,15,0){Nullable=true} ,
          new ParDef("ResponsavelLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelCidade",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelLogradouroNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ResponsavelDDD",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ResponsavelNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ClienteSituacao",GXType.Char,1,0){Nullable=true} ,
          new ParDef("ResponsavelCargo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTipoRisco",GXType.VarChar,40,0) ,
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ResponsavelMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelNacionalidade",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteNacionalidade",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ResponsavelProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteProfissao",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteConvenio",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferT000O74;
          cmdBufferT000O74=" SAVEPOINT gxupdate;UPDATE Cliente SET ClienteCreatedAt=:ClienteCreatedAt, ClienteUpdatedAt=:ClienteUpdatedAt, ClienteDocumento=:ClienteDocumento, ClienteRazaoSocial=:ClienteRazaoSocial, ClienteNomeFantasia=:ClienteNomeFantasia, ClienteDataNascimento=:ClienteDataNascimento, ClienteTipoPessoa=:ClienteTipoPessoa, ClienteStatus=:ClienteStatus, ClienteLogUser=:ClienteLogUser, ClienteEstadoCivil=:ClienteEstadoCivil, EnderecoTipo=:EnderecoTipo, EnderecoCEP=:EnderecoCEP, EnderecoLogradouro=:EnderecoLogradouro, EnderecoBairro=:EnderecoBairro, EnderecoCidade=:EnderecoCidade, EnderecoNumero=:EnderecoNumero, EnderecoComplemento=:EnderecoComplemento, ContatoEmail=:ContatoEmail, ContatoDDD=:ContatoDDD, ContatoDDI=:ContatoDDI, ContatoNumero=:ContatoNumero, ContatoTelefoneNumero=:ContatoTelefoneNumero, ContatoTelefoneDDD=:ContatoTelefoneDDD, ContatoTelefoneDDI=:ContatoTelefoneDDI, ClienteRG=:ClienteRG, ClienteDepositoTipo=:ClienteDepositoTipo, ClientePixTipo=:ClientePixTipo, ClientePix=:ClientePix, ContaAgencia=:ContaAgencia, ContaNumero=:ContaNumero, ResponsavelNome=:ResponsavelNome, ResponsavelEstadoCivil=:ResponsavelEstadoCivil, ResponsavelRG=:ResponsavelRG, ResponsavelCPF=:ResponsavelCPF, ResponsavelCEP=:ResponsavelCEP, ResponsavelLogradouro=:ResponsavelLogradouro, ResponsavelBairro=:ResponsavelBairro, ResponsavelCidade=:ResponsavelCidade, ResponsavelLogradouroNumero=:ResponsavelLogradouroNumero, ResponsavelComplemento=:ResponsavelComplemento, ResponsavelDDD=:ResponsavelDDD, ResponsavelNumero=:ResponsavelNumero, ResponsavelEmail=:ResponsavelEmail, ClienteSituacao=:ClienteSituacao, ResponsavelCargo=:ResponsavelCargo, ClienteTipoRisco=:ClienteTipoRisco, TipoClienteId=:TipoClienteId, MunicipioCodigo=:MunicipioCodigo, ResponsavelMunicipio=:ResponsavelMunicipio, BancoId=:BancoId, EspecialidadeId=:EspecialidadeId, "
          + " ResponsavelNacionalidade=:ResponsavelNacionalidade, ClienteNacionalidade=:ClienteNacionalidade, ResponsavelProfissao=:ResponsavelProfissao, ClienteProfissao=:ClienteProfissao, ClienteConvenio=:ClienteConvenio  WHERE ClienteId = :ClienteId;RELEASE SAVEPOINT gxupdate" ;
          Object[] prmT000O75;
          prmT000O75 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O77;
          prmT000O77 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O79;
          prmT000O79 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O83;
          prmT000O83 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O86;
          prmT000O86 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O88;
          prmT000O88 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O90;
          prmT000O90 = new Object[] {
          new ParDef("SerasaUltimaData_F",GXType.DateTime,8,5) ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O92;
          prmT000O92 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O93;
          prmT000O93 = new Object[] {
          new ParDef("MunicipioCodigo",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000O94;
          prmT000O94 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000O95;
          prmT000O95 = new Object[] {
          new ParDef("ResponsavelMunicipio",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmT000O96;
          prmT000O96 = new Object[] {
          new ParDef("BancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O97;
          prmT000O97 = new Object[] {
          new ParDef("ResponsavelNacionalidade",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O98;
          prmT000O98 = new Object[] {
          new ParDef("ClienteNacionalidade",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O99;
          prmT000O99 = new Object[] {
          new ParDef("ResponsavelProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O100;
          prmT000O100 = new Object[] {
          new ParDef("ClienteProfissao",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O101;
          prmT000O101 = new Object[] {
          new ParDef("ClienteConvenio",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O102;
          prmT000O102 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O103;
          prmT000O103 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O104;
          prmT000O104 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O105;
          prmT000O105 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O106;
          prmT000O106 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O107;
          prmT000O107 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O108;
          prmT000O108 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O109;
          prmT000O109 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O110;
          prmT000O110 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O111;
          prmT000O111 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O112;
          prmT000O112 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O113;
          prmT000O113 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O114;
          prmT000O114 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O115;
          prmT000O115 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O116;
          prmT000O116 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O117;
          prmT000O117 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O118;
          prmT000O118 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O119;
          prmT000O119 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O120;
          prmT000O120 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O121;
          prmT000O121 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O122;
          prmT000O122 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmT000O123;
          prmT000O123 = new Object[] {
          };
          Object[] prmT000O124;
          prmT000O124 = new Object[] {
          new ParDef("ClienteDocumento",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T000O2", "SELECT ClienteId, ClienteCreatedAt, ClienteUpdatedAt, ClienteDocumento, ClienteRazaoSocial, ClienteNomeFantasia, ClienteDataNascimento, ClienteTipoPessoa, ClienteStatus, ClienteLogUser, ClienteEstadoCivil, EnderecoTipo, EnderecoCEP, EnderecoLogradouro, EnderecoBairro, EnderecoCidade, EnderecoNumero, EnderecoComplemento, ContatoEmail, ContatoDDD, ContatoDDI, ContatoNumero, ContatoTelefoneNumero, ContatoTelefoneDDD, ContatoTelefoneDDI, ClienteRG, ClienteDepositoTipo, ClientePixTipo, ClientePix, ContaAgencia, ContaNumero, ResponsavelNome, ResponsavelEstadoCivil, ResponsavelRG, ResponsavelCPF, ResponsavelCEP, ResponsavelLogradouro, ResponsavelBairro, ResponsavelCidade, ResponsavelLogradouroNumero, ResponsavelComplemento, ResponsavelDDD, ResponsavelNumero, ResponsavelEmail, ClienteSituacao, ResponsavelCargo, ClienteTipoRisco, TipoClienteId, MunicipioCodigo, ResponsavelMunicipio, BancoId, EspecialidadeId, ResponsavelNacionalidade, ClienteNacionalidade, ResponsavelProfissao, ClienteProfissao, ClienteConvenio FROM Cliente WHERE ClienteId = :ClienteId  FOR UPDATE OF Cliente NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000O2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O3", "SELECT ClienteId, ClienteCreatedAt, ClienteUpdatedAt, ClienteDocumento, ClienteRazaoSocial, ClienteNomeFantasia, ClienteDataNascimento, ClienteTipoPessoa, ClienteStatus, ClienteLogUser, ClienteEstadoCivil, EnderecoTipo, EnderecoCEP, EnderecoLogradouro, EnderecoBairro, EnderecoCidade, EnderecoNumero, EnderecoComplemento, ContatoEmail, ContatoDDD, ContatoDDI, ContatoNumero, ContatoTelefoneNumero, ContatoTelefoneDDD, ContatoTelefoneDDI, ClienteRG, ClienteDepositoTipo, ClientePixTipo, ClientePix, ContaAgencia, ContaNumero, ResponsavelNome, ResponsavelEstadoCivil, ResponsavelRG, ResponsavelCPF, ResponsavelCEP, ResponsavelLogradouro, ResponsavelBairro, ResponsavelCidade, ResponsavelLogradouroNumero, ResponsavelComplemento, ResponsavelDDD, ResponsavelNumero, ResponsavelEmail, ClienteSituacao, ResponsavelCargo, ClienteTipoRisco, TipoClienteId, MunicipioCodigo, ResponsavelMunicipio, BancoId, EspecialidadeId, ResponsavelNacionalidade, ClienteNacionalidade, ResponsavelProfissao, ClienteProfissao, ClienteConvenio FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O4", "SELECT TipoClienteDescricao, TipoClientePortal, TipoClientePortalPjPf FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O5", "SELECT MunicipioNome, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O6", "SELECT MunicipioUF AS ResponsavelMunicipioUF, MunicipioNome AS ResponsavelMunicipioNome FROM Municipio WHERE MunicipioCodigo = :ResponsavelMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O7", "SELECT BancoCodigo, BancoNome FROM Banco WHERE BancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O8", "SELECT EspecialidadeId FROM Especialidade WHERE EspecialidadeId = :EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O9", "SELECT NacionalidadeNome AS ResponsavelNacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :ResponsavelNacionalidade ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O10", "SELECT NacionalidadeNome AS ClienteNacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :ClienteNacionalidade ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O11", "SELECT ProfissaoNome AS ResponsavelProfissaoNome FROM Profissao WHERE ProfissaoId = :ResponsavelProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O12", "SELECT ProfissaoNome AS ClienteProfissaoNome FROM Profissao WHERE ProfissaoId = :ClienteProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O13", "SELECT ConvenioDescricao AS ClienteConvenioDescricao FROM Convenio WHERE ConvenioId = :ClienteConvenio ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O15", "SELECT COALESCE( T1.SerasaScoreUltimaData_F, 0) AS SerasaScoreUltimaData_F, COALESCE( T1.SerasaUltimoValorRecomendado_F, 0) AS SerasaUltimoValorRecomendado_F FROM (SELECT MAX(SerasaScore) AS SerasaScoreUltimaData_F, ClienteId, MAX(SerasaValorLimiteRecomendado) AS SerasaUltimoValorRecomendado_F FROM Serasa WHERE SerasaCreatedAt = :SerasaUltimaData_F GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O17", "SELECT COALESCE( T1.SecUserId_F, 0) AS SecUserId_F FROM (SELECT MIN(SecUserId) AS SecUserId_F, SecUserOwnerId FROM SecUser WHERE SecUserOwnerId = :ClienteId GROUP BY SecUserOwnerId ) T1 WHERE T1.SecUserOwnerId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O19", "SELECT COALESCE( T1.ClienteQtdTitulos_F, 0) AS ClienteQtdTitulos_F FROM (SELECT COUNT(*) AS ClienteQtdTitulos_F, T4.ClienteId FROM ((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) WHERE Not T2.TituloDeleted GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O23", "SELECT COALESCE( T1.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F FROM (SELECT SUM(COALESCE( T5.TituloSaldoDebito_F, 0)) AS ClienteValorAPagar_F, T4.ClienteId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T6.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T6.TituloValor, 0) - COALESCE( T6.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoDebito_F, T6.TituloId FROM (Titulo T6 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T6.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = T6.TituloId) ) T5 ON T5.TituloId = T2.TituloId) GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O26", "SELECT COALESCE( T1.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F FROM (SELECT SUM(CASE  WHEN COALESCE( T2.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T2.TituloValor, 0) - COALESCE( T2.TituloDesconto, 0)) - COALESCE( T5.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAReceber_F, T4.ClienteId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O28", "SELECT COALESCE( T1.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, COALESCE( T1.SerasaConsultas_F, 0) AS SerasaConsultas_F FROM (SELECT COUNT(*) AS SerasaConsultas_F, ClienteId, MAX(SerasaCreatedAt) AS SerasaUltimaData_F FROM Serasa GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O30", "SELECT COALESCE( T1.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento WHERE RelacionamentoTipo = ( 'Sacado') GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O30,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O40", cmdBufferT000O40,true, GxErrorMask.GX_NOMASK, false, this,prmT000O40,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O41", "SELECT ClienteDocumento FROM Cliente WHERE (ClienteDocumento = :ClienteDocumento) AND (Not ( ClienteId = :ClienteId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O41,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O43", "SELECT COALESCE( T1.SecUserId_F, 0) AS SecUserId_F FROM (SELECT MIN(SecUserId) AS SecUserId_F, SecUserOwnerId FROM SecUser WHERE SecUserOwnerId = :ClienteId GROUP BY SecUserOwnerId ) T1 WHERE T1.SecUserOwnerId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O43,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O45", "SELECT COALESCE( T1.ClienteQtdTitulos_F, 0) AS ClienteQtdTitulos_F FROM (SELECT COUNT(*) AS ClienteQtdTitulos_F, T4.ClienteId FROM ((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) WHERE Not T2.TituloDeleted GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O45,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O49", "SELECT COALESCE( T1.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F FROM (SELECT SUM(COALESCE( T5.TituloSaldoDebito_F, 0)) AS ClienteValorAPagar_F, T4.ClienteId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T6.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T6.TituloValor, 0) - COALESCE( T6.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoDebito_F, T6.TituloId FROM (Titulo T6 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T6.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = T6.TituloId) ) T5 ON T5.TituloId = T2.TituloId) GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O49,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O52", "SELECT COALESCE( T1.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F FROM (SELECT SUM(CASE  WHEN COALESCE( T2.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T2.TituloValor, 0) - COALESCE( T2.TituloDesconto, 0)) - COALESCE( T5.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAReceber_F, T4.ClienteId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O52,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O54", "SELECT COALESCE( T1.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, COALESCE( T1.SerasaConsultas_F, 0) AS SerasaConsultas_F FROM (SELECT COUNT(*) AS SerasaConsultas_F, ClienteId, MAX(SerasaCreatedAt) AS SerasaUltimaData_F FROM Serasa GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O54,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O56", "SELECT COALESCE( T1.SerasaScoreUltimaData_F, 0) AS SerasaScoreUltimaData_F, COALESCE( T1.SerasaUltimoValorRecomendado_F, 0) AS SerasaUltimoValorRecomendado_F FROM (SELECT MAX(SerasaScore) AS SerasaScoreUltimaData_F, ClienteId, MAX(SerasaValorLimiteRecomendado) AS SerasaUltimoValorRecomendado_F FROM Serasa WHERE SerasaCreatedAt = :SerasaUltimaData_F GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O56,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O58", "SELECT COALESCE( T1.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento WHERE RelacionamentoTipo = ( 'Sacado') GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O58,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O59", "SELECT MunicipioNome, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O59,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O60", "SELECT TipoClienteDescricao, TipoClientePortal, TipoClientePortalPjPf FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O60,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O61", "SELECT MunicipioUF AS ResponsavelMunicipioUF, MunicipioNome AS ResponsavelMunicipioNome FROM Municipio WHERE MunicipioCodigo = :ResponsavelMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O61,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O62", "SELECT BancoCodigo, BancoNome FROM Banco WHERE BancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O62,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O63", "SELECT EspecialidadeId FROM Especialidade WHERE EspecialidadeId = :EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O63,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O64", "SELECT NacionalidadeNome AS ResponsavelNacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :ResponsavelNacionalidade ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O64,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O65", "SELECT NacionalidadeNome AS ClienteNacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :ClienteNacionalidade ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O65,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O66", "SELECT ProfissaoNome AS ResponsavelProfissaoNome FROM Profissao WHERE ProfissaoId = :ResponsavelProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O66,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O67", "SELECT ProfissaoNome AS ClienteProfissaoNome FROM Profissao WHERE ProfissaoId = :ClienteProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O67,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O68", "SELECT ConvenioDescricao AS ClienteConvenioDescricao FROM Convenio WHERE ConvenioId = :ClienteConvenio ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O68,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O69", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O69,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O70", "SELECT ClienteId FROM Cliente WHERE ( ClienteId > :ClienteId) ORDER BY ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O70,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O71", "SELECT ClienteId FROM Cliente WHERE ( ClienteId < :ClienteId) ORDER BY ClienteId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O71,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O72", cmdBufferT000O72, GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000O72)
             ,new CursorDef("T000O73", "SELECT currval('ClienteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O73,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O74", cmdBufferT000O74, GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000O74)
             ,new CursorDef("T000O75", "SAVEPOINT gxupdate;DELETE FROM Cliente  WHERE ClienteId = :ClienteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000O75)
             ,new CursorDef("T000O77", "SELECT COALESCE( T1.SecUserId_F, 0) AS SecUserId_F FROM (SELECT MIN(SecUserId) AS SecUserId_F, SecUserOwnerId FROM SecUser WHERE SecUserOwnerId = :ClienteId GROUP BY SecUserOwnerId ) T1 WHERE T1.SecUserOwnerId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O77,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O79", "SELECT COALESCE( T1.ClienteQtdTitulos_F, 0) AS ClienteQtdTitulos_F FROM (SELECT COUNT(*) AS ClienteQtdTitulos_F, T4.ClienteId FROM ((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) WHERE Not T2.TituloDeleted GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O79,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O83", "SELECT COALESCE( T1.ClienteValorAPagar_F, 0) AS ClienteValorAPagar_F FROM (SELECT SUM(COALESCE( T5.TituloSaldoDebito_F, 0)) AS ClienteValorAPagar_F, T4.ClienteId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T6.TituloTipo, '') = ( 'DEBITO') THEN ( COALESCE( T6.TituloValor, 0) - COALESCE( T6.TituloDesconto, 0)) - COALESCE( T7.TituloTotalMovimento_F, 0) ELSE 0 END AS TituloSaldoDebito_F, T6.TituloId FROM (Titulo T6 LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T6.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T7 ON T7.TituloId = T6.TituloId) ) T5 ON T5.TituloId = T2.TituloId) GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O83,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O86", "SELECT COALESCE( T1.ClienteValorAReceber_F, 0) AS ClienteValorAReceber_F FROM (SELECT SUM(CASE  WHEN COALESCE( T2.TituloTipo, '') = ( 'CREDITO') THEN ( COALESCE( T2.TituloValor, 0) - COALESCE( T2.TituloDesconto, 0)) - COALESCE( T5.TituloTotalMovimento_F, 0) ELSE 0 END) AS ClienteValorAReceber_F, T4.ClienteId FROM (((Titulo T2 LEFT JOIN NotaFiscalParcelamento T3 ON T3.NotaFiscalParcelamentoID = T2.NotaFiscalParcelamentoID) LEFT JOIN NotaFiscal T4 ON T4.NotaFiscalId = T3.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(TituloMovimentoValor) AS TituloTotalMovimento_F, TituloId FROM TituloMovimento WHERE (T2.TituloId = TituloId) AND (TituloMovimentoSoma) GROUP BY TituloId ) T5 ON T5.TituloId = T2.TituloId) GROUP BY T4.ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O86,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O88", "SELECT COALESCE( T1.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, COALESCE( T1.SerasaConsultas_F, 0) AS SerasaConsultas_F FROM (SELECT COUNT(*) AS SerasaConsultas_F, ClienteId, MAX(SerasaCreatedAt) AS SerasaUltimaData_F FROM Serasa GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O88,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O90", "SELECT COALESCE( T1.SerasaScoreUltimaData_F, 0) AS SerasaScoreUltimaData_F, COALESCE( T1.SerasaUltimoValorRecomendado_F, 0) AS SerasaUltimoValorRecomendado_F FROM (SELECT MAX(SerasaScore) AS SerasaScoreUltimaData_F, ClienteId, MAX(SerasaValorLimiteRecomendado) AS SerasaUltimoValorRecomendado_F FROM Serasa WHERE SerasaCreatedAt = :SerasaUltimaData_F GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O90,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O92", "SELECT COALESCE( T1.RelacionamentoSacado, 0) AS RelacionamentoSacado FROM (SELECT COUNT(*) AS RelacionamentoSacado, ClienteId FROM Relacionamento WHERE RelacionamentoTipo = ( 'Sacado') GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O92,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O93", "SELECT MunicipioNome, MunicipioUF FROM Municipio WHERE MunicipioCodigo = :MunicipioCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O93,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O94", "SELECT TipoClienteDescricao, TipoClientePortal, TipoClientePortalPjPf FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O94,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O95", "SELECT MunicipioUF AS ResponsavelMunicipioUF, MunicipioNome AS ResponsavelMunicipioNome FROM Municipio WHERE MunicipioCodigo = :ResponsavelMunicipio ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O95,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O96", "SELECT BancoCodigo, BancoNome FROM Banco WHERE BancoId = :BancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O96,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O97", "SELECT NacionalidadeNome AS ResponsavelNacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :ResponsavelNacionalidade ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O97,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O98", "SELECT NacionalidadeNome AS ClienteNacionalidadeNome FROM Nacionalidade WHERE NacionalidadeId = :ClienteNacionalidade ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O98,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O99", "SELECT ProfissaoNome AS ResponsavelProfissaoNome FROM Profissao WHERE ProfissaoId = :ResponsavelProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O99,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O100", "SELECT ProfissaoNome AS ClienteProfissaoNome FROM Profissao WHERE ProfissaoId = :ClienteProfissao ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O100,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O101", "SELECT ConvenioDescricao AS ClienteConvenioDescricao FROM Convenio WHERE ConvenioId = :ClienteConvenio ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O101,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O102", "SELECT OperacoesTitulosId FROM OperacoesTitulos WHERE SacadoId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O102,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O103", "SELECT PropostaId FROM Proposta WHERE PropostaEmpresaClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O103,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O104", "SELECT PropostaId FROM Proposta WHERE PropostaClinicaId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O104,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O105", "SELECT PropostaId FROM Proposta WHERE PropostaResponsavelId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O105,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O106", "SELECT PropostaId FROM Proposta WHERE PropostaPacienteClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O106,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O107", "SELECT ContratoId FROM Contrato WHERE ContratoClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O107,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O108", "SELECT TituloId FROM Titulo WHERE TituloClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O108,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O109", "SELECT SecUserId FROM SecUser WHERE SecUserOwnerId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O109,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O110", "SELECT RelacionamentoId FROM Relacionamento WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O110,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O111", "SELECT OperacoesId FROM Operacoes WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O111,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O112", "SELECT RepresentanteId FROM Representante WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O112,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O113", "SELECT CreditoId FROM Credito WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O113,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O114", "SELECT NotaFiscalId FROM NotaFiscal WHERE NotaFiscalDestinatarioClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O114,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O115", "SELECT NotaFiscalId FROM NotaFiscal WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O115,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O116", "SELECT SerasaId FROM Serasa WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O116,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O117", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O117,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O118", "SELECT ClienteReponsavelId FROM ClienteReponsavel WHERE ReponsavelClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O118,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O119", "SELECT ClienteReponsavelId FROM ClienteReponsavel WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O119,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O120", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O120,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O121", "SELECT FinanciamentoId FROM Financiamento WHERE IntermediadorClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O121,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O122", "SELECT FinanciamentoId FROM Financiamento WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O122,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000O123", "SELECT ClienteId FROM Cliente ORDER BY ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O123,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000O124", "SELECT ClienteDocumento FROM Cliente WHERE (ClienteDocumento = :ClienteDocumento) AND (Not ( ClienteId = :ClienteId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O124,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
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
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((short[]) buf[37])[0] = rslt.getShort(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((short[]) buf[39])[0] = rslt.getShort(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((long[]) buf[41])[0] = rslt.getLong(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((long[]) buf[43])[0] = rslt.getLong(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((short[]) buf[45])[0] = rslt.getShort(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((long[]) buf[49])[0] = rslt.getLong(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getVarchar(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((long[]) buf[65])[0] = rslt.getLong(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((string[]) buf[71])[0] = rslt.getVarchar(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((string[]) buf[73])[0] = rslt.getVarchar(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((string[]) buf[75])[0] = rslt.getVarchar(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((int[]) buf[77])[0] = rslt.getInt(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                ((string[]) buf[79])[0] = rslt.getVarchar(41);
                ((bool[]) buf[80])[0] = rslt.wasNull(41);
                ((short[]) buf[81])[0] = rslt.getShort(42);
                ((bool[]) buf[82])[0] = rslt.wasNull(42);
                ((int[]) buf[83])[0] = rslt.getInt(43);
                ((bool[]) buf[84])[0] = rslt.wasNull(43);
                ((string[]) buf[85])[0] = rslt.getVarchar(44);
                ((bool[]) buf[86])[0] = rslt.wasNull(44);
                ((string[]) buf[87])[0] = rslt.getString(45, 1);
                ((bool[]) buf[88])[0] = rslt.wasNull(45);
                ((string[]) buf[89])[0] = rslt.getVarchar(46);
                ((bool[]) buf[90])[0] = rslt.wasNull(46);
                ((string[]) buf[91])[0] = rslt.getVarchar(47);
                ((short[]) buf[92])[0] = rslt.getShort(48);
                ((bool[]) buf[93])[0] = rslt.wasNull(48);
                ((string[]) buf[94])[0] = rslt.getVarchar(49);
                ((bool[]) buf[95])[0] = rslt.wasNull(49);
                ((string[]) buf[96])[0] = rslt.getVarchar(50);
                ((bool[]) buf[97])[0] = rslt.wasNull(50);
                ((int[]) buf[98])[0] = rslt.getInt(51);
                ((bool[]) buf[99])[0] = rslt.wasNull(51);
                ((int[]) buf[100])[0] = rslt.getInt(52);
                ((bool[]) buf[101])[0] = rslt.wasNull(52);
                ((int[]) buf[102])[0] = rslt.getInt(53);
                ((bool[]) buf[103])[0] = rslt.wasNull(53);
                ((int[]) buf[104])[0] = rslt.getInt(54);
                ((bool[]) buf[105])[0] = rslt.wasNull(54);
                ((int[]) buf[106])[0] = rslt.getInt(55);
                ((bool[]) buf[107])[0] = rslt.wasNull(55);
                ((int[]) buf[108])[0] = rslt.getInt(56);
                ((bool[]) buf[109])[0] = rslt.wasNull(56);
                ((int[]) buf[110])[0] = rslt.getInt(57);
                ((bool[]) buf[111])[0] = rslt.wasNull(57);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
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
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((short[]) buf[37])[0] = rslt.getShort(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((short[]) buf[39])[0] = rslt.getShort(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((long[]) buf[41])[0] = rslt.getLong(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((long[]) buf[43])[0] = rslt.getLong(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((short[]) buf[45])[0] = rslt.getShort(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((short[]) buf[47])[0] = rslt.getShort(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((long[]) buf[49])[0] = rslt.getLong(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((string[]) buf[51])[0] = rslt.getVarchar(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((string[]) buf[53])[0] = rslt.getVarchar(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((string[]) buf[55])[0] = rslt.getVarchar(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((string[]) buf[57])[0] = rslt.getVarchar(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((string[]) buf[59])[0] = rslt.getVarchar(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((string[]) buf[61])[0] = rslt.getVarchar(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((string[]) buf[63])[0] = rslt.getVarchar(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((long[]) buf[65])[0] = rslt.getLong(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((string[]) buf[71])[0] = rslt.getVarchar(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((string[]) buf[73])[0] = rslt.getVarchar(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((string[]) buf[75])[0] = rslt.getVarchar(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((int[]) buf[77])[0] = rslt.getInt(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                ((string[]) buf[79])[0] = rslt.getVarchar(41);
                ((bool[]) buf[80])[0] = rslt.wasNull(41);
                ((short[]) buf[81])[0] = rslt.getShort(42);
                ((bool[]) buf[82])[0] = rslt.wasNull(42);
                ((int[]) buf[83])[0] = rslt.getInt(43);
                ((bool[]) buf[84])[0] = rslt.wasNull(43);
                ((string[]) buf[85])[0] = rslt.getVarchar(44);
                ((bool[]) buf[86])[0] = rslt.wasNull(44);
                ((string[]) buf[87])[0] = rslt.getString(45, 1);
                ((bool[]) buf[88])[0] = rslt.wasNull(45);
                ((string[]) buf[89])[0] = rslt.getVarchar(46);
                ((bool[]) buf[90])[0] = rslt.wasNull(46);
                ((string[]) buf[91])[0] = rslt.getVarchar(47);
                ((short[]) buf[92])[0] = rslt.getShort(48);
                ((bool[]) buf[93])[0] = rslt.wasNull(48);
                ((string[]) buf[94])[0] = rslt.getVarchar(49);
                ((bool[]) buf[95])[0] = rslt.wasNull(49);
                ((string[]) buf[96])[0] = rslt.getVarchar(50);
                ((bool[]) buf[97])[0] = rslt.wasNull(50);
                ((int[]) buf[98])[0] = rslt.getInt(51);
                ((bool[]) buf[99])[0] = rslt.wasNull(51);
                ((int[]) buf[100])[0] = rslt.getInt(52);
                ((bool[]) buf[101])[0] = rslt.wasNull(52);
                ((int[]) buf[102])[0] = rslt.getInt(53);
                ((bool[]) buf[103])[0] = rslt.wasNull(53);
                ((int[]) buf[104])[0] = rslt.getInt(54);
                ((bool[]) buf[105])[0] = rslt.wasNull(54);
                ((int[]) buf[106])[0] = rslt.getInt(55);
                ((bool[]) buf[107])[0] = rslt.wasNull(55);
                ((int[]) buf[108])[0] = rslt.getInt(56);
                ((bool[]) buf[109])[0] = rslt.wasNull(56);
                ((int[]) buf[110])[0] = rslt.getInt(57);
                ((bool[]) buf[111])[0] = rslt.wasNull(57);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((short[]) buf[23])[0] = rslt.getShort(13);
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
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((string[]) buf[39])[0] = rslt.getVarchar(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((string[]) buf[41])[0] = rslt.getVarchar(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                ((string[]) buf[43])[0] = rslt.getVarchar(23);
                ((bool[]) buf[44])[0] = rslt.wasNull(23);
                ((string[]) buf[45])[0] = rslt.getVarchar(24);
                ((bool[]) buf[46])[0] = rslt.wasNull(24);
                ((string[]) buf[47])[0] = rslt.getVarchar(25);
                ((bool[]) buf[48])[0] = rslt.wasNull(25);
                ((string[]) buf[49])[0] = rslt.getVarchar(26);
                ((bool[]) buf[50])[0] = rslt.wasNull(26);
                ((short[]) buf[51])[0] = rslt.getShort(27);
                ((bool[]) buf[52])[0] = rslt.wasNull(27);
                ((short[]) buf[53])[0] = rslt.getShort(28);
                ((bool[]) buf[54])[0] = rslt.wasNull(28);
                ((long[]) buf[55])[0] = rslt.getLong(29);
                ((bool[]) buf[56])[0] = rslt.wasNull(29);
                ((long[]) buf[57])[0] = rslt.getLong(30);
                ((bool[]) buf[58])[0] = rslt.wasNull(30);
                ((short[]) buf[59])[0] = rslt.getShort(31);
                ((bool[]) buf[60])[0] = rslt.wasNull(31);
                ((short[]) buf[61])[0] = rslt.getShort(32);
                ((bool[]) buf[62])[0] = rslt.wasNull(32);
                ((long[]) buf[63])[0] = rslt.getLong(33);
                ((bool[]) buf[64])[0] = rslt.wasNull(33);
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((string[]) buf[73])[0] = rslt.getVarchar(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((string[]) buf[75])[0] = rslt.getVarchar(39);
                ((bool[]) buf[76])[0] = rslt.wasNull(39);
                ((string[]) buf[77])[0] = rslt.getVarchar(40);
                ((bool[]) buf[78])[0] = rslt.wasNull(40);
                ((string[]) buf[79])[0] = rslt.getVarchar(41);
                ((bool[]) buf[80])[0] = rslt.wasNull(41);
                ((string[]) buf[81])[0] = rslt.getVarchar(42);
                ((bool[]) buf[82])[0] = rslt.wasNull(42);
                ((string[]) buf[83])[0] = rslt.getVarchar(43);
                ((bool[]) buf[84])[0] = rslt.wasNull(43);
                ((long[]) buf[85])[0] = rslt.getLong(44);
                ((bool[]) buf[86])[0] = rslt.wasNull(44);
                ((string[]) buf[87])[0] = rslt.getVarchar(45);
                ((bool[]) buf[88])[0] = rslt.wasNull(45);
                ((string[]) buf[89])[0] = rslt.getVarchar(46);
                ((bool[]) buf[90])[0] = rslt.wasNull(46);
                ((string[]) buf[91])[0] = rslt.getVarchar(47);
                ((bool[]) buf[92])[0] = rslt.wasNull(47);
                ((string[]) buf[93])[0] = rslt.getVarchar(48);
                ((bool[]) buf[94])[0] = rslt.wasNull(48);
                ((string[]) buf[95])[0] = rslt.getVarchar(49);
                ((bool[]) buf[96])[0] = rslt.wasNull(49);
                ((string[]) buf[97])[0] = rslt.getVarchar(50);
                ((bool[]) buf[98])[0] = rslt.wasNull(50);
                ((string[]) buf[99])[0] = rslt.getVarchar(51);
                ((bool[]) buf[100])[0] = rslt.wasNull(51);
                ((string[]) buf[101])[0] = rslt.getVarchar(52);
                ((bool[]) buf[102])[0] = rslt.wasNull(52);
                ((int[]) buf[103])[0] = rslt.getInt(53);
                ((bool[]) buf[104])[0] = rslt.wasNull(53);
                ((string[]) buf[105])[0] = rslt.getVarchar(54);
                ((bool[]) buf[106])[0] = rslt.wasNull(54);
                ((short[]) buf[107])[0] = rslt.getShort(55);
                ((bool[]) buf[108])[0] = rslt.wasNull(55);
                ((int[]) buf[109])[0] = rslt.getInt(56);
                ((bool[]) buf[110])[0] = rslt.wasNull(56);
                ((string[]) buf[111])[0] = rslt.getVarchar(57);
                ((bool[]) buf[112])[0] = rslt.wasNull(57);
                ((string[]) buf[113])[0] = rslt.getString(58, 1);
                ((bool[]) buf[114])[0] = rslt.wasNull(58);
                ((string[]) buf[115])[0] = rslt.getVarchar(59);
                ((bool[]) buf[116])[0] = rslt.wasNull(59);
                ((bool[]) buf[117])[0] = rslt.getBool(60);
                ((bool[]) buf[118])[0] = rslt.wasNull(60);
                ((string[]) buf[119])[0] = rslt.getVarchar(61);
                ((short[]) buf[120])[0] = rslt.getShort(62);
                ((bool[]) buf[121])[0] = rslt.wasNull(62);
                ((string[]) buf[122])[0] = rslt.getVarchar(63);
                ((bool[]) buf[123])[0] = rslt.wasNull(63);
                ((string[]) buf[124])[0] = rslt.getVarchar(64);
                ((bool[]) buf[125])[0] = rslt.wasNull(64);
                ((int[]) buf[126])[0] = rslt.getInt(65);
                ((bool[]) buf[127])[0] = rslt.wasNull(65);
                ((int[]) buf[128])[0] = rslt.getInt(66);
                ((bool[]) buf[129])[0] = rslt.wasNull(66);
                ((int[]) buf[130])[0] = rslt.getInt(67);
                ((bool[]) buf[131])[0] = rslt.wasNull(67);
                ((int[]) buf[132])[0] = rslt.getInt(68);
                ((bool[]) buf[133])[0] = rslt.wasNull(68);
                ((int[]) buf[134])[0] = rslt.getInt(69);
                ((bool[]) buf[135])[0] = rslt.wasNull(69);
                ((int[]) buf[136])[0] = rslt.getInt(70);
                ((bool[]) buf[137])[0] = rslt.wasNull(70);
                ((int[]) buf[138])[0] = rslt.getInt(71);
                ((bool[]) buf[139])[0] = rslt.wasNull(71);
                ((DateTime[]) buf[140])[0] = rslt.getGXDateTime(72);
                ((short[]) buf[141])[0] = rslt.getShort(73);
                ((bool[]) buf[142])[0] = rslt.wasNull(73);
                ((int[]) buf[143])[0] = rslt.getInt(74);
                ((bool[]) buf[144])[0] = rslt.wasNull(74);
                ((decimal[]) buf[145])[0] = rslt.getDecimal(75);
                ((bool[]) buf[146])[0] = rslt.wasNull(75);
                ((decimal[]) buf[147])[0] = rslt.getDecimal(76);
                ((bool[]) buf[148])[0] = rslt.wasNull(76);
                ((short[]) buf[149])[0] = rslt.getShort(77);
                ((short[]) buf[150])[0] = rslt.getShort(78);
                ((bool[]) buf[151])[0] = rslt.wasNull(78);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 23 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 24 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 25 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 26 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 27 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 28 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 29 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 31 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 32 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 33 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 34 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 35 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 36 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 37 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 38 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 39 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 40 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 42 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 45 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 46 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 47 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 48 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 49 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 50 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                return;
             case 51 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 52 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 53 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 54 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 55 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 56 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 57 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 58 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 59 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
       getresults60( cursor, rslt, buf) ;
    }

    public void getresults60( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 60 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 61 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 62 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 63 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 64 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 65 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 66 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 67 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 68 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 69 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 70 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 71 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 72 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 73 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 74 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 75 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 76 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 77 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 78 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 79 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 80 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 81 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 82 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 83 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
