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
   public class notafiscal_bc : GxSilentTrn, IGxSilentTrn
   {
      public notafiscal_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notafiscal_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow2N93( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2N93( ) ;
         standaloneModal( ) ;
         AddRow2N93( ) ;
         Gx_mode = "INS";
         return  ;
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
               Z794NotaFiscalId = A794NotaFiscalId;
               SetMode( "UPD") ;
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

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_2N0( )
      {
         BeforeValidate2N93( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2N93( ) ;
            }
            else
            {
               CheckExtendedTable2N93( ) ;
               if ( AnyError == 0 )
               {
                  ZM2N93( 15) ;
                  ZM2N93( 16) ;
                  ZM2N93( 17) ;
                  ZM2N93( 18) ;
               }
               CloseExtendedTableCursors2N93( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM2N93( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z795NotaFiscalUF = A795NotaFiscalUF;
            Z796NotaFiscalNatureza = A796NotaFiscalNatureza;
            Z797NotaFiscalMod = A797NotaFiscalMod;
            Z798NotaFiscalSerie = A798NotaFiscalSerie;
            Z799NotaFiscalNumero = A799NotaFiscalNumero;
            Z800NotaFiscalDataEmissao = A800NotaFiscalDataEmissao;
            Z801NotaFiscalDataSaida = A801NotaFiscalDataSaida;
            Z802NotaFiscalTipo = A802NotaFiscalTipo;
            Z803NotaFiscalMunicipio = A803NotaFiscalMunicipio;
            Z804NotaFiscalTipoEmissao = A804NotaFiscalTipoEmissao;
            Z805NotaFiscalAmbiente = A805NotaFiscalAmbiente;
            Z806NotaFiscalFinalidades = A806NotaFiscalFinalidades;
            Z818NotaFiscaEmitentelDocumento = A818NotaFiscaEmitentelDocumento;
            Z808NotaFiscalEmitenteNome = A808NotaFiscalEmitenteNome;
            Z809NotaFiscalEmitenteLogradouro = A809NotaFiscalEmitenteLogradouro;
            Z810NotaFiscalEmitenteLogNum = A810NotaFiscalEmitenteLogNum;
            Z811NotaFiscalEmitenteComplemento = A811NotaFiscalEmitenteComplemento;
            Z812NotaFiscalEmitenteBairro = A812NotaFiscalEmitenteBairro;
            Z813NotaFiscalEmitenteMunicipio = A813NotaFiscalEmitenteMunicipio;
            Z814NotaFiscalEmitenteUF = A814NotaFiscalEmitenteUF;
            Z815NotaFiscalEmitenteCEP = A815NotaFiscalEmitenteCEP;
            Z816NotaFiscalEmitentePais = A816NotaFiscalEmitentePais;
            Z817NotaFiscalEmitenteTelefone = A817NotaFiscalEmitenteTelefone;
            Z819NotaFiscalEmitenteIE = A819NotaFiscalEmitenteIE;
            Z820NotaFiscalDestinatarioDocumento = A820NotaFiscalDestinatarioDocumento;
            Z852NotaFiscalDestinatarioNome = A852NotaFiscalDestinatarioNome;
            Z821NotaFiscalDestinatarioLogradouro = A821NotaFiscalDestinatarioLogradouro;
            Z822NotaFiscalDestinatarioLogNum = A822NotaFiscalDestinatarioLogNum;
            Z823NotaFiscalDestinatarioComplemento = A823NotaFiscalDestinatarioComplemento;
            Z824NotaFiscalDestinatarioBairro = A824NotaFiscalDestinatarioBairro;
            Z825NotaFiscalDestinatarioMunicipio = A825NotaFiscalDestinatarioMunicipio;
            Z826NotaFiscalDestinatarioUF = A826NotaFiscalDestinatarioUF;
            Z827NotaFiscalDestinatarioCEP = A827NotaFiscalDestinatarioCEP;
            Z828NotaFiscalDestinatarioPais = A828NotaFiscalDestinatarioPais;
            Z829NotaFiscalDestinatarioFone = A829NotaFiscalDestinatarioFone;
            Z168ClienteId = A168ClienteId;
            Z889NotaFiscalDestinatarioClienteId = A889NotaFiscalDestinatarioClienteId;
            Z874NotaFiscalValorTotal_F = A874NotaFiscalValorTotal_F;
            Z875NotaFiscalValorTotalVendido_F = A875NotaFiscalValorTotalVendido_F;
            Z876NotaFiscalSaldo_F = A876NotaFiscalSaldo_F;
            Z877NotaFiscalQuantidadeDeItens_F = A877NotaFiscalQuantidadeDeItens_F;
            Z878NotaFiscalQuantidadeDeItensVendidos_F = A878NotaFiscalQuantidadeDeItensVendidos_F;
            Z879NotaFiscalQuantidadeResumo_F = A879NotaFiscalQuantidadeResumo_F;
            Z881NotaFiscalValorFormatado_F = A881NotaFiscalValorFormatado_F;
            Z882NotaFiscalValorVendidoFormatado_F = A882NotaFiscalValorVendidoFormatado_F;
            Z883NotaFiscalSaldoFormatado_F = A883NotaFiscalSaldoFormatado_F;
            Z880NotaFiscalStatus = A880NotaFiscalStatus;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z874NotaFiscalValorTotal_F = A874NotaFiscalValorTotal_F;
            Z875NotaFiscalValorTotalVendido_F = A875NotaFiscalValorTotalVendido_F;
            Z876NotaFiscalSaldo_F = A876NotaFiscalSaldo_F;
            Z877NotaFiscalQuantidadeDeItens_F = A877NotaFiscalQuantidadeDeItens_F;
            Z878NotaFiscalQuantidadeDeItensVendidos_F = A878NotaFiscalQuantidadeDeItensVendidos_F;
            Z879NotaFiscalQuantidadeResumo_F = A879NotaFiscalQuantidadeResumo_F;
            Z881NotaFiscalValorFormatado_F = A881NotaFiscalValorFormatado_F;
            Z882NotaFiscalValorVendidoFormatado_F = A882NotaFiscalValorVendidoFormatado_F;
            Z883NotaFiscalSaldoFormatado_F = A883NotaFiscalSaldoFormatado_F;
            Z880NotaFiscalStatus = A880NotaFiscalStatus;
         }
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z874NotaFiscalValorTotal_F = A874NotaFiscalValorTotal_F;
            Z875NotaFiscalValorTotalVendido_F = A875NotaFiscalValorTotalVendido_F;
            Z876NotaFiscalSaldo_F = A876NotaFiscalSaldo_F;
            Z877NotaFiscalQuantidadeDeItens_F = A877NotaFiscalQuantidadeDeItens_F;
            Z878NotaFiscalQuantidadeDeItensVendidos_F = A878NotaFiscalQuantidadeDeItensVendidos_F;
            Z879NotaFiscalQuantidadeResumo_F = A879NotaFiscalQuantidadeResumo_F;
            Z881NotaFiscalValorFormatado_F = A881NotaFiscalValorFormatado_F;
            Z882NotaFiscalValorVendidoFormatado_F = A882NotaFiscalValorVendidoFormatado_F;
            Z883NotaFiscalSaldoFormatado_F = A883NotaFiscalSaldoFormatado_F;
            Z880NotaFiscalStatus = A880NotaFiscalStatus;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z874NotaFiscalValorTotal_F = A874NotaFiscalValorTotal_F;
            Z875NotaFiscalValorTotalVendido_F = A875NotaFiscalValorTotalVendido_F;
            Z876NotaFiscalSaldo_F = A876NotaFiscalSaldo_F;
            Z877NotaFiscalQuantidadeDeItens_F = A877NotaFiscalQuantidadeDeItens_F;
            Z878NotaFiscalQuantidadeDeItensVendidos_F = A878NotaFiscalQuantidadeDeItensVendidos_F;
            Z879NotaFiscalQuantidadeResumo_F = A879NotaFiscalQuantidadeResumo_F;
            Z881NotaFiscalValorFormatado_F = A881NotaFiscalValorFormatado_F;
            Z882NotaFiscalValorVendidoFormatado_F = A882NotaFiscalValorVendidoFormatado_F;
            Z883NotaFiscalSaldoFormatado_F = A883NotaFiscalSaldoFormatado_F;
            Z880NotaFiscalStatus = A880NotaFiscalStatus;
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z874NotaFiscalValorTotal_F = A874NotaFiscalValorTotal_F;
            Z875NotaFiscalValorTotalVendido_F = A875NotaFiscalValorTotalVendido_F;
            Z876NotaFiscalSaldo_F = A876NotaFiscalSaldo_F;
            Z877NotaFiscalQuantidadeDeItens_F = A877NotaFiscalQuantidadeDeItens_F;
            Z878NotaFiscalQuantidadeDeItensVendidos_F = A878NotaFiscalQuantidadeDeItensVendidos_F;
            Z879NotaFiscalQuantidadeResumo_F = A879NotaFiscalQuantidadeResumo_F;
            Z881NotaFiscalValorFormatado_F = A881NotaFiscalValorFormatado_F;
            Z882NotaFiscalValorVendidoFormatado_F = A882NotaFiscalValorVendidoFormatado_F;
            Z883NotaFiscalSaldoFormatado_F = A883NotaFiscalSaldoFormatado_F;
            Z880NotaFiscalStatus = A880NotaFiscalStatus;
         }
         if ( GX_JID == -14 )
         {
            Z794NotaFiscalId = A794NotaFiscalId;
            Z795NotaFiscalUF = A795NotaFiscalUF;
            Z796NotaFiscalNatureza = A796NotaFiscalNatureza;
            Z797NotaFiscalMod = A797NotaFiscalMod;
            Z798NotaFiscalSerie = A798NotaFiscalSerie;
            Z799NotaFiscalNumero = A799NotaFiscalNumero;
            Z800NotaFiscalDataEmissao = A800NotaFiscalDataEmissao;
            Z801NotaFiscalDataSaida = A801NotaFiscalDataSaida;
            Z802NotaFiscalTipo = A802NotaFiscalTipo;
            Z803NotaFiscalMunicipio = A803NotaFiscalMunicipio;
            Z804NotaFiscalTipoEmissao = A804NotaFiscalTipoEmissao;
            Z805NotaFiscalAmbiente = A805NotaFiscalAmbiente;
            Z806NotaFiscalFinalidades = A806NotaFiscalFinalidades;
            Z818NotaFiscaEmitentelDocumento = A818NotaFiscaEmitentelDocumento;
            Z808NotaFiscalEmitenteNome = A808NotaFiscalEmitenteNome;
            Z809NotaFiscalEmitenteLogradouro = A809NotaFiscalEmitenteLogradouro;
            Z810NotaFiscalEmitenteLogNum = A810NotaFiscalEmitenteLogNum;
            Z811NotaFiscalEmitenteComplemento = A811NotaFiscalEmitenteComplemento;
            Z812NotaFiscalEmitenteBairro = A812NotaFiscalEmitenteBairro;
            Z813NotaFiscalEmitenteMunicipio = A813NotaFiscalEmitenteMunicipio;
            Z814NotaFiscalEmitenteUF = A814NotaFiscalEmitenteUF;
            Z815NotaFiscalEmitenteCEP = A815NotaFiscalEmitenteCEP;
            Z816NotaFiscalEmitentePais = A816NotaFiscalEmitentePais;
            Z817NotaFiscalEmitenteTelefone = A817NotaFiscalEmitenteTelefone;
            Z819NotaFiscalEmitenteIE = A819NotaFiscalEmitenteIE;
            Z820NotaFiscalDestinatarioDocumento = A820NotaFiscalDestinatarioDocumento;
            Z852NotaFiscalDestinatarioNome = A852NotaFiscalDestinatarioNome;
            Z821NotaFiscalDestinatarioLogradouro = A821NotaFiscalDestinatarioLogradouro;
            Z822NotaFiscalDestinatarioLogNum = A822NotaFiscalDestinatarioLogNum;
            Z823NotaFiscalDestinatarioComplemento = A823NotaFiscalDestinatarioComplemento;
            Z824NotaFiscalDestinatarioBairro = A824NotaFiscalDestinatarioBairro;
            Z825NotaFiscalDestinatarioMunicipio = A825NotaFiscalDestinatarioMunicipio;
            Z826NotaFiscalDestinatarioUF = A826NotaFiscalDestinatarioUF;
            Z827NotaFiscalDestinatarioCEP = A827NotaFiscalDestinatarioCEP;
            Z828NotaFiscalDestinatarioPais = A828NotaFiscalDestinatarioPais;
            Z829NotaFiscalDestinatarioFone = A829NotaFiscalDestinatarioFone;
            Z168ClienteId = A168ClienteId;
            Z889NotaFiscalDestinatarioClienteId = A889NotaFiscalDestinatarioClienteId;
            Z874NotaFiscalValorTotal_F = A874NotaFiscalValorTotal_F;
            Z877NotaFiscalQuantidadeDeItens_F = A877NotaFiscalQuantidadeDeItens_F;
            Z875NotaFiscalValorTotalVendido_F = A875NotaFiscalValorTotalVendido_F;
            Z878NotaFiscalQuantidadeDeItensVendidos_F = A878NotaFiscalQuantidadeDeItensVendidos_F;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A794NotaFiscalId) )
         {
            A794NotaFiscalId = Guid.NewGuid( );
            n794NotaFiscalId = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor BC002N7 */
            pr_default.execute(4, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(4) != 101) )
            {
               A874NotaFiscalValorTotal_F = BC002N7_A874NotaFiscalValorTotal_F[0];
               A877NotaFiscalQuantidadeDeItens_F = BC002N7_A877NotaFiscalQuantidadeDeItens_F[0];
            }
            else
            {
               A874NotaFiscalValorTotal_F = 0;
               A877NotaFiscalQuantidadeDeItens_F = 0;
            }
            pr_default.close(4);
            A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
            /* Using cursor BC002N9 */
            pr_default.execute(5, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(5) != 101) )
            {
               A875NotaFiscalValorTotalVendido_F = BC002N9_A875NotaFiscalValorTotalVendido_F[0];
               A878NotaFiscalQuantidadeDeItensVendidos_F = BC002N9_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            }
            else
            {
               A875NotaFiscalValorTotalVendido_F = 0;
               A878NotaFiscalQuantidadeDeItensVendidos_F = 0;
            }
            pr_default.close(5);
            A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
            A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
            A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
            A880NotaFiscalStatus = ((A878NotaFiscalQuantidadeDeItensVendidos_F==A877NotaFiscalQuantidadeDeItens_F) ? "Completo" : "Parcial");
            A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
         }
      }

      protected void Load2N93( )
      {
         /* Using cursor BC002N12 */
         pr_default.execute(6, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound93 = 1;
            A795NotaFiscalUF = BC002N12_A795NotaFiscalUF[0];
            n795NotaFiscalUF = BC002N12_n795NotaFiscalUF[0];
            A796NotaFiscalNatureza = BC002N12_A796NotaFiscalNatureza[0];
            n796NotaFiscalNatureza = BC002N12_n796NotaFiscalNatureza[0];
            A797NotaFiscalMod = BC002N12_A797NotaFiscalMod[0];
            n797NotaFiscalMod = BC002N12_n797NotaFiscalMod[0];
            A798NotaFiscalSerie = BC002N12_A798NotaFiscalSerie[0];
            n798NotaFiscalSerie = BC002N12_n798NotaFiscalSerie[0];
            A799NotaFiscalNumero = BC002N12_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = BC002N12_n799NotaFiscalNumero[0];
            A800NotaFiscalDataEmissao = BC002N12_A800NotaFiscalDataEmissao[0];
            n800NotaFiscalDataEmissao = BC002N12_n800NotaFiscalDataEmissao[0];
            A801NotaFiscalDataSaida = BC002N12_A801NotaFiscalDataSaida[0];
            n801NotaFiscalDataSaida = BC002N12_n801NotaFiscalDataSaida[0];
            A802NotaFiscalTipo = BC002N12_A802NotaFiscalTipo[0];
            n802NotaFiscalTipo = BC002N12_n802NotaFiscalTipo[0];
            A803NotaFiscalMunicipio = BC002N12_A803NotaFiscalMunicipio[0];
            n803NotaFiscalMunicipio = BC002N12_n803NotaFiscalMunicipio[0];
            A804NotaFiscalTipoEmissao = BC002N12_A804NotaFiscalTipoEmissao[0];
            n804NotaFiscalTipoEmissao = BC002N12_n804NotaFiscalTipoEmissao[0];
            A805NotaFiscalAmbiente = BC002N12_A805NotaFiscalAmbiente[0];
            n805NotaFiscalAmbiente = BC002N12_n805NotaFiscalAmbiente[0];
            A806NotaFiscalFinalidades = BC002N12_A806NotaFiscalFinalidades[0];
            n806NotaFiscalFinalidades = BC002N12_n806NotaFiscalFinalidades[0];
            A818NotaFiscaEmitentelDocumento = BC002N12_A818NotaFiscaEmitentelDocumento[0];
            n818NotaFiscaEmitentelDocumento = BC002N12_n818NotaFiscaEmitentelDocumento[0];
            A808NotaFiscalEmitenteNome = BC002N12_A808NotaFiscalEmitenteNome[0];
            n808NotaFiscalEmitenteNome = BC002N12_n808NotaFiscalEmitenteNome[0];
            A809NotaFiscalEmitenteLogradouro = BC002N12_A809NotaFiscalEmitenteLogradouro[0];
            n809NotaFiscalEmitenteLogradouro = BC002N12_n809NotaFiscalEmitenteLogradouro[0];
            A810NotaFiscalEmitenteLogNum = BC002N12_A810NotaFiscalEmitenteLogNum[0];
            n810NotaFiscalEmitenteLogNum = BC002N12_n810NotaFiscalEmitenteLogNum[0];
            A811NotaFiscalEmitenteComplemento = BC002N12_A811NotaFiscalEmitenteComplemento[0];
            n811NotaFiscalEmitenteComplemento = BC002N12_n811NotaFiscalEmitenteComplemento[0];
            A812NotaFiscalEmitenteBairro = BC002N12_A812NotaFiscalEmitenteBairro[0];
            n812NotaFiscalEmitenteBairro = BC002N12_n812NotaFiscalEmitenteBairro[0];
            A813NotaFiscalEmitenteMunicipio = BC002N12_A813NotaFiscalEmitenteMunicipio[0];
            n813NotaFiscalEmitenteMunicipio = BC002N12_n813NotaFiscalEmitenteMunicipio[0];
            A814NotaFiscalEmitenteUF = BC002N12_A814NotaFiscalEmitenteUF[0];
            n814NotaFiscalEmitenteUF = BC002N12_n814NotaFiscalEmitenteUF[0];
            A815NotaFiscalEmitenteCEP = BC002N12_A815NotaFiscalEmitenteCEP[0];
            n815NotaFiscalEmitenteCEP = BC002N12_n815NotaFiscalEmitenteCEP[0];
            A816NotaFiscalEmitentePais = BC002N12_A816NotaFiscalEmitentePais[0];
            n816NotaFiscalEmitentePais = BC002N12_n816NotaFiscalEmitentePais[0];
            A817NotaFiscalEmitenteTelefone = BC002N12_A817NotaFiscalEmitenteTelefone[0];
            n817NotaFiscalEmitenteTelefone = BC002N12_n817NotaFiscalEmitenteTelefone[0];
            A819NotaFiscalEmitenteIE = BC002N12_A819NotaFiscalEmitenteIE[0];
            n819NotaFiscalEmitenteIE = BC002N12_n819NotaFiscalEmitenteIE[0];
            A820NotaFiscalDestinatarioDocumento = BC002N12_A820NotaFiscalDestinatarioDocumento[0];
            n820NotaFiscalDestinatarioDocumento = BC002N12_n820NotaFiscalDestinatarioDocumento[0];
            A852NotaFiscalDestinatarioNome = BC002N12_A852NotaFiscalDestinatarioNome[0];
            n852NotaFiscalDestinatarioNome = BC002N12_n852NotaFiscalDestinatarioNome[0];
            A821NotaFiscalDestinatarioLogradouro = BC002N12_A821NotaFiscalDestinatarioLogradouro[0];
            n821NotaFiscalDestinatarioLogradouro = BC002N12_n821NotaFiscalDestinatarioLogradouro[0];
            A822NotaFiscalDestinatarioLogNum = BC002N12_A822NotaFiscalDestinatarioLogNum[0];
            n822NotaFiscalDestinatarioLogNum = BC002N12_n822NotaFiscalDestinatarioLogNum[0];
            A823NotaFiscalDestinatarioComplemento = BC002N12_A823NotaFiscalDestinatarioComplemento[0];
            n823NotaFiscalDestinatarioComplemento = BC002N12_n823NotaFiscalDestinatarioComplemento[0];
            A824NotaFiscalDestinatarioBairro = BC002N12_A824NotaFiscalDestinatarioBairro[0];
            n824NotaFiscalDestinatarioBairro = BC002N12_n824NotaFiscalDestinatarioBairro[0];
            A825NotaFiscalDestinatarioMunicipio = BC002N12_A825NotaFiscalDestinatarioMunicipio[0];
            n825NotaFiscalDestinatarioMunicipio = BC002N12_n825NotaFiscalDestinatarioMunicipio[0];
            A826NotaFiscalDestinatarioUF = BC002N12_A826NotaFiscalDestinatarioUF[0];
            n826NotaFiscalDestinatarioUF = BC002N12_n826NotaFiscalDestinatarioUF[0];
            A827NotaFiscalDestinatarioCEP = BC002N12_A827NotaFiscalDestinatarioCEP[0];
            n827NotaFiscalDestinatarioCEP = BC002N12_n827NotaFiscalDestinatarioCEP[0];
            A828NotaFiscalDestinatarioPais = BC002N12_A828NotaFiscalDestinatarioPais[0];
            n828NotaFiscalDestinatarioPais = BC002N12_n828NotaFiscalDestinatarioPais[0];
            A829NotaFiscalDestinatarioFone = BC002N12_A829NotaFiscalDestinatarioFone[0];
            n829NotaFiscalDestinatarioFone = BC002N12_n829NotaFiscalDestinatarioFone[0];
            A168ClienteId = BC002N12_A168ClienteId[0];
            n168ClienteId = BC002N12_n168ClienteId[0];
            A889NotaFiscalDestinatarioClienteId = BC002N12_A889NotaFiscalDestinatarioClienteId[0];
            n889NotaFiscalDestinatarioClienteId = BC002N12_n889NotaFiscalDestinatarioClienteId[0];
            A874NotaFiscalValorTotal_F = BC002N12_A874NotaFiscalValorTotal_F[0];
            A875NotaFiscalValorTotalVendido_F = BC002N12_A875NotaFiscalValorTotalVendido_F[0];
            A877NotaFiscalQuantidadeDeItens_F = BC002N12_A877NotaFiscalQuantidadeDeItens_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = BC002N12_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            ZM2N93( -14) ;
         }
         pr_default.close(6);
         OnLoadActions2N93( ) ;
      }

      protected void OnLoadActions2N93( )
      {
         A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
         A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
         A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
         A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
         A880NotaFiscalStatus = ((A878NotaFiscalQuantidadeDeItensVendidos_F==A877NotaFiscalQuantidadeDeItens_F) ? "Completo" : "Parcial");
         A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
      }

      protected void CheckExtendedTable2N93( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002N7 */
         pr_default.execute(4, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A874NotaFiscalValorTotal_F = BC002N7_A874NotaFiscalValorTotal_F[0];
            A877NotaFiscalQuantidadeDeItens_F = BC002N7_A877NotaFiscalQuantidadeDeItens_F[0];
         }
         else
         {
            A874NotaFiscalValorTotal_F = 0;
            A877NotaFiscalQuantidadeDeItens_F = 0;
         }
         pr_default.close(4);
         A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
         /* Using cursor BC002N9 */
         pr_default.execute(5, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A875NotaFiscalValorTotalVendido_F = BC002N9_A875NotaFiscalValorTotalVendido_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = BC002N9_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
         }
         else
         {
            A875NotaFiscalValorTotalVendido_F = 0;
            A878NotaFiscalQuantidadeDeItensVendidos_F = 0;
         }
         pr_default.close(5);
         A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
         A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
         A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
         A880NotaFiscalStatus = ((A878NotaFiscalQuantidadeDeItensVendidos_F==A877NotaFiscalQuantidadeDeItens_F) ? "Completo" : "Parcial");
         A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
         /* Using cursor BC002N4 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         if ( ! ( ( A795NotaFiscalUF == 11 ) || ( A795NotaFiscalUF == 12 ) || ( A795NotaFiscalUF == 13 ) || ( A795NotaFiscalUF == 14 ) || ( A795NotaFiscalUF == 15 ) || ( A795NotaFiscalUF == 16 ) || ( A795NotaFiscalUF == 17 ) || ( A795NotaFiscalUF == 21 ) || ( A795NotaFiscalUF == 22 ) || ( A795NotaFiscalUF == 23 ) || ( A795NotaFiscalUF == 24 ) || ( A795NotaFiscalUF == 25 ) || ( A795NotaFiscalUF == 26 ) || ( A795NotaFiscalUF == 27 ) || ( A795NotaFiscalUF == 28 ) || ( A795NotaFiscalUF == 29 ) || ( A795NotaFiscalUF == 31 ) || ( A795NotaFiscalUF == 32 ) || ( A795NotaFiscalUF == 33 ) || ( A795NotaFiscalUF == 35 ) || ( A795NotaFiscalUF == 41 ) || ( A795NotaFiscalUF == 42 ) || ( A795NotaFiscalUF == 43 ) || ( A795NotaFiscalUF == 50 ) || ( A795NotaFiscalUF == 51 ) || ( A795NotaFiscalUF == 52 ) || ( A795NotaFiscalUF == 53 ) || (0==A795NotaFiscalUF) ) )
         {
            GX_msglist.addItem("Campo Nota Fiscal UF fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A802NotaFiscalTipo, "0") == 0 ) || ( StringUtil.StrCmp(A802NotaFiscalTipo, "1") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A802NotaFiscalTipo)) ) )
         {
            GX_msglist.addItem("Campo Nota Fiscal Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A804NotaFiscalTipoEmissao, "1") == 0 ) || ( StringUtil.StrCmp(A804NotaFiscalTipoEmissao, "2") == 0 ) || ( StringUtil.StrCmp(A804NotaFiscalTipoEmissao, "9") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A804NotaFiscalTipoEmissao)) ) )
         {
            GX_msglist.addItem("Campo Nota Fiscal Tipo Emissao fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( A805NotaFiscalAmbiente == 1 ) || ( A805NotaFiscalAmbiente == 2 ) || (0==A805NotaFiscalAmbiente) ) )
         {
            GX_msglist.addItem("Campo Nota Fiscal Ambiente fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A806NotaFiscalFinalidades, "1") == 0 ) || ( StringUtil.StrCmp(A806NotaFiscalFinalidades, "2") == 0 ) || ( StringUtil.StrCmp(A806NotaFiscalFinalidades, "3") == 0 ) || ( StringUtil.StrCmp(A806NotaFiscalFinalidades, "4") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A806NotaFiscalFinalidades)) ) )
         {
            GX_msglist.addItem("Campo Nota Fiscal Finalidades fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC002N5 */
         pr_default.execute(3, new Object[] {n889NotaFiscalDestinatarioClienteId, A889NotaFiscalDestinatarioClienteId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A889NotaFiscalDestinatarioClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Nota Destinatario Cliente'.", "ForeignKeyNotFound", 1, "NOTAFISCALDESTINATARIOCLIENTEID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2N93( )
      {
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2N93( )
      {
         /* Using cursor BC002N13 */
         pr_default.execute(7, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound93 = 1;
         }
         else
         {
            RcdFound93 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002N3 */
         pr_default.execute(1, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2N93( 14) ;
            RcdFound93 = 1;
            A794NotaFiscalId = BC002N3_A794NotaFiscalId[0];
            n794NotaFiscalId = BC002N3_n794NotaFiscalId[0];
            A795NotaFiscalUF = BC002N3_A795NotaFiscalUF[0];
            n795NotaFiscalUF = BC002N3_n795NotaFiscalUF[0];
            A796NotaFiscalNatureza = BC002N3_A796NotaFiscalNatureza[0];
            n796NotaFiscalNatureza = BC002N3_n796NotaFiscalNatureza[0];
            A797NotaFiscalMod = BC002N3_A797NotaFiscalMod[0];
            n797NotaFiscalMod = BC002N3_n797NotaFiscalMod[0];
            A798NotaFiscalSerie = BC002N3_A798NotaFiscalSerie[0];
            n798NotaFiscalSerie = BC002N3_n798NotaFiscalSerie[0];
            A799NotaFiscalNumero = BC002N3_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = BC002N3_n799NotaFiscalNumero[0];
            A800NotaFiscalDataEmissao = BC002N3_A800NotaFiscalDataEmissao[0];
            n800NotaFiscalDataEmissao = BC002N3_n800NotaFiscalDataEmissao[0];
            A801NotaFiscalDataSaida = BC002N3_A801NotaFiscalDataSaida[0];
            n801NotaFiscalDataSaida = BC002N3_n801NotaFiscalDataSaida[0];
            A802NotaFiscalTipo = BC002N3_A802NotaFiscalTipo[0];
            n802NotaFiscalTipo = BC002N3_n802NotaFiscalTipo[0];
            A803NotaFiscalMunicipio = BC002N3_A803NotaFiscalMunicipio[0];
            n803NotaFiscalMunicipio = BC002N3_n803NotaFiscalMunicipio[0];
            A804NotaFiscalTipoEmissao = BC002N3_A804NotaFiscalTipoEmissao[0];
            n804NotaFiscalTipoEmissao = BC002N3_n804NotaFiscalTipoEmissao[0];
            A805NotaFiscalAmbiente = BC002N3_A805NotaFiscalAmbiente[0];
            n805NotaFiscalAmbiente = BC002N3_n805NotaFiscalAmbiente[0];
            A806NotaFiscalFinalidades = BC002N3_A806NotaFiscalFinalidades[0];
            n806NotaFiscalFinalidades = BC002N3_n806NotaFiscalFinalidades[0];
            A818NotaFiscaEmitentelDocumento = BC002N3_A818NotaFiscaEmitentelDocumento[0];
            n818NotaFiscaEmitentelDocumento = BC002N3_n818NotaFiscaEmitentelDocumento[0];
            A808NotaFiscalEmitenteNome = BC002N3_A808NotaFiscalEmitenteNome[0];
            n808NotaFiscalEmitenteNome = BC002N3_n808NotaFiscalEmitenteNome[0];
            A809NotaFiscalEmitenteLogradouro = BC002N3_A809NotaFiscalEmitenteLogradouro[0];
            n809NotaFiscalEmitenteLogradouro = BC002N3_n809NotaFiscalEmitenteLogradouro[0];
            A810NotaFiscalEmitenteLogNum = BC002N3_A810NotaFiscalEmitenteLogNum[0];
            n810NotaFiscalEmitenteLogNum = BC002N3_n810NotaFiscalEmitenteLogNum[0];
            A811NotaFiscalEmitenteComplemento = BC002N3_A811NotaFiscalEmitenteComplemento[0];
            n811NotaFiscalEmitenteComplemento = BC002N3_n811NotaFiscalEmitenteComplemento[0];
            A812NotaFiscalEmitenteBairro = BC002N3_A812NotaFiscalEmitenteBairro[0];
            n812NotaFiscalEmitenteBairro = BC002N3_n812NotaFiscalEmitenteBairro[0];
            A813NotaFiscalEmitenteMunicipio = BC002N3_A813NotaFiscalEmitenteMunicipio[0];
            n813NotaFiscalEmitenteMunicipio = BC002N3_n813NotaFiscalEmitenteMunicipio[0];
            A814NotaFiscalEmitenteUF = BC002N3_A814NotaFiscalEmitenteUF[0];
            n814NotaFiscalEmitenteUF = BC002N3_n814NotaFiscalEmitenteUF[0];
            A815NotaFiscalEmitenteCEP = BC002N3_A815NotaFiscalEmitenteCEP[0];
            n815NotaFiscalEmitenteCEP = BC002N3_n815NotaFiscalEmitenteCEP[0];
            A816NotaFiscalEmitentePais = BC002N3_A816NotaFiscalEmitentePais[0];
            n816NotaFiscalEmitentePais = BC002N3_n816NotaFiscalEmitentePais[0];
            A817NotaFiscalEmitenteTelefone = BC002N3_A817NotaFiscalEmitenteTelefone[0];
            n817NotaFiscalEmitenteTelefone = BC002N3_n817NotaFiscalEmitenteTelefone[0];
            A819NotaFiscalEmitenteIE = BC002N3_A819NotaFiscalEmitenteIE[0];
            n819NotaFiscalEmitenteIE = BC002N3_n819NotaFiscalEmitenteIE[0];
            A820NotaFiscalDestinatarioDocumento = BC002N3_A820NotaFiscalDestinatarioDocumento[0];
            n820NotaFiscalDestinatarioDocumento = BC002N3_n820NotaFiscalDestinatarioDocumento[0];
            A852NotaFiscalDestinatarioNome = BC002N3_A852NotaFiscalDestinatarioNome[0];
            n852NotaFiscalDestinatarioNome = BC002N3_n852NotaFiscalDestinatarioNome[0];
            A821NotaFiscalDestinatarioLogradouro = BC002N3_A821NotaFiscalDestinatarioLogradouro[0];
            n821NotaFiscalDestinatarioLogradouro = BC002N3_n821NotaFiscalDestinatarioLogradouro[0];
            A822NotaFiscalDestinatarioLogNum = BC002N3_A822NotaFiscalDestinatarioLogNum[0];
            n822NotaFiscalDestinatarioLogNum = BC002N3_n822NotaFiscalDestinatarioLogNum[0];
            A823NotaFiscalDestinatarioComplemento = BC002N3_A823NotaFiscalDestinatarioComplemento[0];
            n823NotaFiscalDestinatarioComplemento = BC002N3_n823NotaFiscalDestinatarioComplemento[0];
            A824NotaFiscalDestinatarioBairro = BC002N3_A824NotaFiscalDestinatarioBairro[0];
            n824NotaFiscalDestinatarioBairro = BC002N3_n824NotaFiscalDestinatarioBairro[0];
            A825NotaFiscalDestinatarioMunicipio = BC002N3_A825NotaFiscalDestinatarioMunicipio[0];
            n825NotaFiscalDestinatarioMunicipio = BC002N3_n825NotaFiscalDestinatarioMunicipio[0];
            A826NotaFiscalDestinatarioUF = BC002N3_A826NotaFiscalDestinatarioUF[0];
            n826NotaFiscalDestinatarioUF = BC002N3_n826NotaFiscalDestinatarioUF[0];
            A827NotaFiscalDestinatarioCEP = BC002N3_A827NotaFiscalDestinatarioCEP[0];
            n827NotaFiscalDestinatarioCEP = BC002N3_n827NotaFiscalDestinatarioCEP[0];
            A828NotaFiscalDestinatarioPais = BC002N3_A828NotaFiscalDestinatarioPais[0];
            n828NotaFiscalDestinatarioPais = BC002N3_n828NotaFiscalDestinatarioPais[0];
            A829NotaFiscalDestinatarioFone = BC002N3_A829NotaFiscalDestinatarioFone[0];
            n829NotaFiscalDestinatarioFone = BC002N3_n829NotaFiscalDestinatarioFone[0];
            A168ClienteId = BC002N3_A168ClienteId[0];
            n168ClienteId = BC002N3_n168ClienteId[0];
            A889NotaFiscalDestinatarioClienteId = BC002N3_A889NotaFiscalDestinatarioClienteId[0];
            n889NotaFiscalDestinatarioClienteId = BC002N3_n889NotaFiscalDestinatarioClienteId[0];
            Z794NotaFiscalId = A794NotaFiscalId;
            sMode93 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2N93( ) ;
            if ( AnyError == 1 )
            {
               RcdFound93 = 0;
               InitializeNonKey2N93( ) ;
            }
            Gx_mode = sMode93;
         }
         else
         {
            RcdFound93 = 0;
            InitializeNonKey2N93( ) ;
            sMode93 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode93;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2N93( ) ;
         if ( RcdFound93 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_2N0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2N93( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002N2 */
            pr_default.execute(0, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotaFiscal"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z795NotaFiscalUF != BC002N2_A795NotaFiscalUF[0] ) || ( StringUtil.StrCmp(Z796NotaFiscalNatureza, BC002N2_A796NotaFiscalNatureza[0]) != 0 ) || ( StringUtil.StrCmp(Z797NotaFiscalMod, BC002N2_A797NotaFiscalMod[0]) != 0 ) || ( StringUtil.StrCmp(Z798NotaFiscalSerie, BC002N2_A798NotaFiscalSerie[0]) != 0 ) || ( StringUtil.StrCmp(Z799NotaFiscalNumero, BC002N2_A799NotaFiscalNumero[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z800NotaFiscalDataEmissao != BC002N2_A800NotaFiscalDataEmissao[0] ) || ( Z801NotaFiscalDataSaida != BC002N2_A801NotaFiscalDataSaida[0] ) || ( StringUtil.StrCmp(Z802NotaFiscalTipo, BC002N2_A802NotaFiscalTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z803NotaFiscalMunicipio, BC002N2_A803NotaFiscalMunicipio[0]) != 0 ) || ( StringUtil.StrCmp(Z804NotaFiscalTipoEmissao, BC002N2_A804NotaFiscalTipoEmissao[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z805NotaFiscalAmbiente != BC002N2_A805NotaFiscalAmbiente[0] ) || ( StringUtil.StrCmp(Z806NotaFiscalFinalidades, BC002N2_A806NotaFiscalFinalidades[0]) != 0 ) || ( StringUtil.StrCmp(Z818NotaFiscaEmitentelDocumento, BC002N2_A818NotaFiscaEmitentelDocumento[0]) != 0 ) || ( StringUtil.StrCmp(Z808NotaFiscalEmitenteNome, BC002N2_A808NotaFiscalEmitenteNome[0]) != 0 ) || ( StringUtil.StrCmp(Z809NotaFiscalEmitenteLogradouro, BC002N2_A809NotaFiscalEmitenteLogradouro[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z810NotaFiscalEmitenteLogNum, BC002N2_A810NotaFiscalEmitenteLogNum[0]) != 0 ) || ( StringUtil.StrCmp(Z811NotaFiscalEmitenteComplemento, BC002N2_A811NotaFiscalEmitenteComplemento[0]) != 0 ) || ( StringUtil.StrCmp(Z812NotaFiscalEmitenteBairro, BC002N2_A812NotaFiscalEmitenteBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z813NotaFiscalEmitenteMunicipio, BC002N2_A813NotaFiscalEmitenteMunicipio[0]) != 0 ) || ( StringUtil.StrCmp(Z814NotaFiscalEmitenteUF, BC002N2_A814NotaFiscalEmitenteUF[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z815NotaFiscalEmitenteCEP, BC002N2_A815NotaFiscalEmitenteCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z816NotaFiscalEmitentePais, BC002N2_A816NotaFiscalEmitentePais[0]) != 0 ) || ( StringUtil.StrCmp(Z817NotaFiscalEmitenteTelefone, BC002N2_A817NotaFiscalEmitenteTelefone[0]) != 0 ) || ( StringUtil.StrCmp(Z819NotaFiscalEmitenteIE, BC002N2_A819NotaFiscalEmitenteIE[0]) != 0 ) || ( StringUtil.StrCmp(Z820NotaFiscalDestinatarioDocumento, BC002N2_A820NotaFiscalDestinatarioDocumento[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z852NotaFiscalDestinatarioNome, BC002N2_A852NotaFiscalDestinatarioNome[0]) != 0 ) || ( StringUtil.StrCmp(Z821NotaFiscalDestinatarioLogradouro, BC002N2_A821NotaFiscalDestinatarioLogradouro[0]) != 0 ) || ( StringUtil.StrCmp(Z822NotaFiscalDestinatarioLogNum, BC002N2_A822NotaFiscalDestinatarioLogNum[0]) != 0 ) || ( StringUtil.StrCmp(Z823NotaFiscalDestinatarioComplemento, BC002N2_A823NotaFiscalDestinatarioComplemento[0]) != 0 ) || ( StringUtil.StrCmp(Z824NotaFiscalDestinatarioBairro, BC002N2_A824NotaFiscalDestinatarioBairro[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z825NotaFiscalDestinatarioMunicipio, BC002N2_A825NotaFiscalDestinatarioMunicipio[0]) != 0 ) || ( StringUtil.StrCmp(Z826NotaFiscalDestinatarioUF, BC002N2_A826NotaFiscalDestinatarioUF[0]) != 0 ) || ( StringUtil.StrCmp(Z827NotaFiscalDestinatarioCEP, BC002N2_A827NotaFiscalDestinatarioCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z828NotaFiscalDestinatarioPais, BC002N2_A828NotaFiscalDestinatarioPais[0]) != 0 ) || ( StringUtil.StrCmp(Z829NotaFiscalDestinatarioFone, BC002N2_A829NotaFiscalDestinatarioFone[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z168ClienteId != BC002N2_A168ClienteId[0] ) || ( Z889NotaFiscalDestinatarioClienteId != BC002N2_A889NotaFiscalDestinatarioClienteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"NotaFiscal"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2N93( )
      {
         BeforeValidate2N93( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2N93( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2N93( 0) ;
            CheckOptimisticConcurrency2N93( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2N93( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2N93( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002N14 */
                     pr_default.execute(8, new Object[] {n794NotaFiscalId, A794NotaFiscalId, n795NotaFiscalUF, A795NotaFiscalUF, n796NotaFiscalNatureza, A796NotaFiscalNatureza, n797NotaFiscalMod, A797NotaFiscalMod, n798NotaFiscalSerie, A798NotaFiscalSerie, n799NotaFiscalNumero, A799NotaFiscalNumero, n800NotaFiscalDataEmissao, A800NotaFiscalDataEmissao, n801NotaFiscalDataSaida, A801NotaFiscalDataSaida, n802NotaFiscalTipo, A802NotaFiscalTipo, n803NotaFiscalMunicipio, A803NotaFiscalMunicipio, n804NotaFiscalTipoEmissao, A804NotaFiscalTipoEmissao, n805NotaFiscalAmbiente, A805NotaFiscalAmbiente, n806NotaFiscalFinalidades, A806NotaFiscalFinalidades, n818NotaFiscaEmitentelDocumento, A818NotaFiscaEmitentelDocumento, n808NotaFiscalEmitenteNome, A808NotaFiscalEmitenteNome, n809NotaFiscalEmitenteLogradouro, A809NotaFiscalEmitenteLogradouro, n810NotaFiscalEmitenteLogNum, A810NotaFiscalEmitenteLogNum, n811NotaFiscalEmitenteComplemento, A811NotaFiscalEmitenteComplemento, n812NotaFiscalEmitenteBairro, A812NotaFiscalEmitenteBairro, n813NotaFiscalEmitenteMunicipio, A813NotaFiscalEmitenteMunicipio, n814NotaFiscalEmitenteUF, A814NotaFiscalEmitenteUF, n815NotaFiscalEmitenteCEP, A815NotaFiscalEmitenteCEP, n816NotaFiscalEmitentePais, A816NotaFiscalEmitentePais, n817NotaFiscalEmitenteTelefone, A817NotaFiscalEmitenteTelefone, n819NotaFiscalEmitenteIE, A819NotaFiscalEmitenteIE, n820NotaFiscalDestinatarioDocumento, A820NotaFiscalDestinatarioDocumento, n852NotaFiscalDestinatarioNome, A852NotaFiscalDestinatarioNome, n821NotaFiscalDestinatarioLogradouro, A821NotaFiscalDestinatarioLogradouro, n822NotaFiscalDestinatarioLogNum, A822NotaFiscalDestinatarioLogNum, n823NotaFiscalDestinatarioComplemento, A823NotaFiscalDestinatarioComplemento, n824NotaFiscalDestinatarioBairro, A824NotaFiscalDestinatarioBairro, n825NotaFiscalDestinatarioMunicipio, A825NotaFiscalDestinatarioMunicipio, n826NotaFiscalDestinatarioUF, A826NotaFiscalDestinatarioUF, n827NotaFiscalDestinatarioCEP, A827NotaFiscalDestinatarioCEP, n828NotaFiscalDestinatarioPais, A828NotaFiscalDestinatarioPais, n829NotaFiscalDestinatarioFone, A829NotaFiscalDestinatarioFone, n168ClienteId, A168ClienteId, n889NotaFiscalDestinatarioClienteId, A889NotaFiscalDestinatarioClienteId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("NotaFiscal");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
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
               Load2N93( ) ;
            }
            EndLevel2N93( ) ;
         }
         CloseExtendedTableCursors2N93( ) ;
      }

      protected void Update2N93( )
      {
         BeforeValidate2N93( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2N93( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2N93( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2N93( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2N93( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002N15 */
                     pr_default.execute(9, new Object[] {n795NotaFiscalUF, A795NotaFiscalUF, n796NotaFiscalNatureza, A796NotaFiscalNatureza, n797NotaFiscalMod, A797NotaFiscalMod, n798NotaFiscalSerie, A798NotaFiscalSerie, n799NotaFiscalNumero, A799NotaFiscalNumero, n800NotaFiscalDataEmissao, A800NotaFiscalDataEmissao, n801NotaFiscalDataSaida, A801NotaFiscalDataSaida, n802NotaFiscalTipo, A802NotaFiscalTipo, n803NotaFiscalMunicipio, A803NotaFiscalMunicipio, n804NotaFiscalTipoEmissao, A804NotaFiscalTipoEmissao, n805NotaFiscalAmbiente, A805NotaFiscalAmbiente, n806NotaFiscalFinalidades, A806NotaFiscalFinalidades, n818NotaFiscaEmitentelDocumento, A818NotaFiscaEmitentelDocumento, n808NotaFiscalEmitenteNome, A808NotaFiscalEmitenteNome, n809NotaFiscalEmitenteLogradouro, A809NotaFiscalEmitenteLogradouro, n810NotaFiscalEmitenteLogNum, A810NotaFiscalEmitenteLogNum, n811NotaFiscalEmitenteComplemento, A811NotaFiscalEmitenteComplemento, n812NotaFiscalEmitenteBairro, A812NotaFiscalEmitenteBairro, n813NotaFiscalEmitenteMunicipio, A813NotaFiscalEmitenteMunicipio, n814NotaFiscalEmitenteUF, A814NotaFiscalEmitenteUF, n815NotaFiscalEmitenteCEP, A815NotaFiscalEmitenteCEP, n816NotaFiscalEmitentePais, A816NotaFiscalEmitentePais, n817NotaFiscalEmitenteTelefone, A817NotaFiscalEmitenteTelefone, n819NotaFiscalEmitenteIE, A819NotaFiscalEmitenteIE, n820NotaFiscalDestinatarioDocumento, A820NotaFiscalDestinatarioDocumento, n852NotaFiscalDestinatarioNome, A852NotaFiscalDestinatarioNome, n821NotaFiscalDestinatarioLogradouro, A821NotaFiscalDestinatarioLogradouro, n822NotaFiscalDestinatarioLogNum, A822NotaFiscalDestinatarioLogNum, n823NotaFiscalDestinatarioComplemento, A823NotaFiscalDestinatarioComplemento, n824NotaFiscalDestinatarioBairro, A824NotaFiscalDestinatarioBairro, n825NotaFiscalDestinatarioMunicipio, A825NotaFiscalDestinatarioMunicipio, n826NotaFiscalDestinatarioUF, A826NotaFiscalDestinatarioUF, n827NotaFiscalDestinatarioCEP, A827NotaFiscalDestinatarioCEP, n828NotaFiscalDestinatarioPais, A828NotaFiscalDestinatarioPais, n829NotaFiscalDestinatarioFone, A829NotaFiscalDestinatarioFone, n168ClienteId, A168ClienteId, n889NotaFiscalDestinatarioClienteId, A889NotaFiscalDestinatarioClienteId, n794NotaFiscalId, A794NotaFiscalId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("NotaFiscal");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotaFiscal"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2N93( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
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
            EndLevel2N93( ) ;
         }
         CloseExtendedTableCursors2N93( ) ;
      }

      protected void DeferredUpdate2N93( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2N93( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2N93( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2N93( ) ;
            AfterConfirm2N93( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2N93( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002N16 */
                  pr_default.execute(10, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("NotaFiscal");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
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
         sMode93 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2N93( ) ;
         Gx_mode = sMode93;
      }

      protected void OnDeleteControls2N93( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002N18 */
            pr_default.execute(11, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               A874NotaFiscalValorTotal_F = BC002N18_A874NotaFiscalValorTotal_F[0];
               A877NotaFiscalQuantidadeDeItens_F = BC002N18_A877NotaFiscalQuantidadeDeItens_F[0];
            }
            else
            {
               A874NotaFiscalValorTotal_F = 0;
               A877NotaFiscalQuantidadeDeItens_F = 0;
            }
            pr_default.close(11);
            A881NotaFiscalValorFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A874NotaFiscalValorTotal_F, 18, 2), "", "", "", "", "", "", "", "");
            /* Using cursor BC002N20 */
            pr_default.execute(12, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               A875NotaFiscalValorTotalVendido_F = BC002N20_A875NotaFiscalValorTotalVendido_F[0];
               A878NotaFiscalQuantidadeDeItensVendidos_F = BC002N20_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
            }
            else
            {
               A875NotaFiscalValorTotalVendido_F = 0;
               A878NotaFiscalQuantidadeDeItensVendidos_F = 0;
            }
            pr_default.close(12);
            A876NotaFiscalSaldo_F = (decimal)(A874NotaFiscalValorTotal_F-A875NotaFiscalValorTotalVendido_F);
            A883NotaFiscalSaldoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A876NotaFiscalSaldo_F, 18, 2), "", "", "", "", "", "", "", "");
            A882NotaFiscalValorVendidoFormatado_F = StringUtil.Format( "R$%1", StringUtil.LTrimStr( A875NotaFiscalValorTotalVendido_F, 18, 2), "", "", "", "", "", "", "", "");
            A880NotaFiscalStatus = ((A878NotaFiscalQuantidadeDeItensVendidos_F==A877NotaFiscalQuantidadeDeItens_F) ? "Completo" : "Parcial");
            A879NotaFiscalQuantidadeResumo_F = StringUtil.Format( "%1/%2", StringUtil.LTrimStr( (decimal)(A878NotaFiscalQuantidadeDeItensVendidos_F), 4, 0), StringUtil.LTrimStr( (decimal)(A877NotaFiscalQuantidadeDeItens_F), 4, 0), "", "", "", "", "", "", "");
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC002N21 */
            pr_default.execute(13, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Nota Fiscal Parcelamento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC002N22 */
            pr_default.execute(14, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscalItem"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel2N93( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2N93( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart2N93( )
      {
         /* Using cursor BC002N25 */
         pr_default.execute(15, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         RcdFound93 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound93 = 1;
            A794NotaFiscalId = BC002N25_A794NotaFiscalId[0];
            n794NotaFiscalId = BC002N25_n794NotaFiscalId[0];
            A795NotaFiscalUF = BC002N25_A795NotaFiscalUF[0];
            n795NotaFiscalUF = BC002N25_n795NotaFiscalUF[0];
            A796NotaFiscalNatureza = BC002N25_A796NotaFiscalNatureza[0];
            n796NotaFiscalNatureza = BC002N25_n796NotaFiscalNatureza[0];
            A797NotaFiscalMod = BC002N25_A797NotaFiscalMod[0];
            n797NotaFiscalMod = BC002N25_n797NotaFiscalMod[0];
            A798NotaFiscalSerie = BC002N25_A798NotaFiscalSerie[0];
            n798NotaFiscalSerie = BC002N25_n798NotaFiscalSerie[0];
            A799NotaFiscalNumero = BC002N25_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = BC002N25_n799NotaFiscalNumero[0];
            A800NotaFiscalDataEmissao = BC002N25_A800NotaFiscalDataEmissao[0];
            n800NotaFiscalDataEmissao = BC002N25_n800NotaFiscalDataEmissao[0];
            A801NotaFiscalDataSaida = BC002N25_A801NotaFiscalDataSaida[0];
            n801NotaFiscalDataSaida = BC002N25_n801NotaFiscalDataSaida[0];
            A802NotaFiscalTipo = BC002N25_A802NotaFiscalTipo[0];
            n802NotaFiscalTipo = BC002N25_n802NotaFiscalTipo[0];
            A803NotaFiscalMunicipio = BC002N25_A803NotaFiscalMunicipio[0];
            n803NotaFiscalMunicipio = BC002N25_n803NotaFiscalMunicipio[0];
            A804NotaFiscalTipoEmissao = BC002N25_A804NotaFiscalTipoEmissao[0];
            n804NotaFiscalTipoEmissao = BC002N25_n804NotaFiscalTipoEmissao[0];
            A805NotaFiscalAmbiente = BC002N25_A805NotaFiscalAmbiente[0];
            n805NotaFiscalAmbiente = BC002N25_n805NotaFiscalAmbiente[0];
            A806NotaFiscalFinalidades = BC002N25_A806NotaFiscalFinalidades[0];
            n806NotaFiscalFinalidades = BC002N25_n806NotaFiscalFinalidades[0];
            A818NotaFiscaEmitentelDocumento = BC002N25_A818NotaFiscaEmitentelDocumento[0];
            n818NotaFiscaEmitentelDocumento = BC002N25_n818NotaFiscaEmitentelDocumento[0];
            A808NotaFiscalEmitenteNome = BC002N25_A808NotaFiscalEmitenteNome[0];
            n808NotaFiscalEmitenteNome = BC002N25_n808NotaFiscalEmitenteNome[0];
            A809NotaFiscalEmitenteLogradouro = BC002N25_A809NotaFiscalEmitenteLogradouro[0];
            n809NotaFiscalEmitenteLogradouro = BC002N25_n809NotaFiscalEmitenteLogradouro[0];
            A810NotaFiscalEmitenteLogNum = BC002N25_A810NotaFiscalEmitenteLogNum[0];
            n810NotaFiscalEmitenteLogNum = BC002N25_n810NotaFiscalEmitenteLogNum[0];
            A811NotaFiscalEmitenteComplemento = BC002N25_A811NotaFiscalEmitenteComplemento[0];
            n811NotaFiscalEmitenteComplemento = BC002N25_n811NotaFiscalEmitenteComplemento[0];
            A812NotaFiscalEmitenteBairro = BC002N25_A812NotaFiscalEmitenteBairro[0];
            n812NotaFiscalEmitenteBairro = BC002N25_n812NotaFiscalEmitenteBairro[0];
            A813NotaFiscalEmitenteMunicipio = BC002N25_A813NotaFiscalEmitenteMunicipio[0];
            n813NotaFiscalEmitenteMunicipio = BC002N25_n813NotaFiscalEmitenteMunicipio[0];
            A814NotaFiscalEmitenteUF = BC002N25_A814NotaFiscalEmitenteUF[0];
            n814NotaFiscalEmitenteUF = BC002N25_n814NotaFiscalEmitenteUF[0];
            A815NotaFiscalEmitenteCEP = BC002N25_A815NotaFiscalEmitenteCEP[0];
            n815NotaFiscalEmitenteCEP = BC002N25_n815NotaFiscalEmitenteCEP[0];
            A816NotaFiscalEmitentePais = BC002N25_A816NotaFiscalEmitentePais[0];
            n816NotaFiscalEmitentePais = BC002N25_n816NotaFiscalEmitentePais[0];
            A817NotaFiscalEmitenteTelefone = BC002N25_A817NotaFiscalEmitenteTelefone[0];
            n817NotaFiscalEmitenteTelefone = BC002N25_n817NotaFiscalEmitenteTelefone[0];
            A819NotaFiscalEmitenteIE = BC002N25_A819NotaFiscalEmitenteIE[0];
            n819NotaFiscalEmitenteIE = BC002N25_n819NotaFiscalEmitenteIE[0];
            A820NotaFiscalDestinatarioDocumento = BC002N25_A820NotaFiscalDestinatarioDocumento[0];
            n820NotaFiscalDestinatarioDocumento = BC002N25_n820NotaFiscalDestinatarioDocumento[0];
            A852NotaFiscalDestinatarioNome = BC002N25_A852NotaFiscalDestinatarioNome[0];
            n852NotaFiscalDestinatarioNome = BC002N25_n852NotaFiscalDestinatarioNome[0];
            A821NotaFiscalDestinatarioLogradouro = BC002N25_A821NotaFiscalDestinatarioLogradouro[0];
            n821NotaFiscalDestinatarioLogradouro = BC002N25_n821NotaFiscalDestinatarioLogradouro[0];
            A822NotaFiscalDestinatarioLogNum = BC002N25_A822NotaFiscalDestinatarioLogNum[0];
            n822NotaFiscalDestinatarioLogNum = BC002N25_n822NotaFiscalDestinatarioLogNum[0];
            A823NotaFiscalDestinatarioComplemento = BC002N25_A823NotaFiscalDestinatarioComplemento[0];
            n823NotaFiscalDestinatarioComplemento = BC002N25_n823NotaFiscalDestinatarioComplemento[0];
            A824NotaFiscalDestinatarioBairro = BC002N25_A824NotaFiscalDestinatarioBairro[0];
            n824NotaFiscalDestinatarioBairro = BC002N25_n824NotaFiscalDestinatarioBairro[0];
            A825NotaFiscalDestinatarioMunicipio = BC002N25_A825NotaFiscalDestinatarioMunicipio[0];
            n825NotaFiscalDestinatarioMunicipio = BC002N25_n825NotaFiscalDestinatarioMunicipio[0];
            A826NotaFiscalDestinatarioUF = BC002N25_A826NotaFiscalDestinatarioUF[0];
            n826NotaFiscalDestinatarioUF = BC002N25_n826NotaFiscalDestinatarioUF[0];
            A827NotaFiscalDestinatarioCEP = BC002N25_A827NotaFiscalDestinatarioCEP[0];
            n827NotaFiscalDestinatarioCEP = BC002N25_n827NotaFiscalDestinatarioCEP[0];
            A828NotaFiscalDestinatarioPais = BC002N25_A828NotaFiscalDestinatarioPais[0];
            n828NotaFiscalDestinatarioPais = BC002N25_n828NotaFiscalDestinatarioPais[0];
            A829NotaFiscalDestinatarioFone = BC002N25_A829NotaFiscalDestinatarioFone[0];
            n829NotaFiscalDestinatarioFone = BC002N25_n829NotaFiscalDestinatarioFone[0];
            A168ClienteId = BC002N25_A168ClienteId[0];
            n168ClienteId = BC002N25_n168ClienteId[0];
            A889NotaFiscalDestinatarioClienteId = BC002N25_A889NotaFiscalDestinatarioClienteId[0];
            n889NotaFiscalDestinatarioClienteId = BC002N25_n889NotaFiscalDestinatarioClienteId[0];
            A874NotaFiscalValorTotal_F = BC002N25_A874NotaFiscalValorTotal_F[0];
            A875NotaFiscalValorTotalVendido_F = BC002N25_A875NotaFiscalValorTotalVendido_F[0];
            A877NotaFiscalQuantidadeDeItens_F = BC002N25_A877NotaFiscalQuantidadeDeItens_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = BC002N25_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2N93( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound93 = 0;
         ScanKeyLoad2N93( ) ;
      }

      protected void ScanKeyLoad2N93( )
      {
         sMode93 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound93 = 1;
            A794NotaFiscalId = BC002N25_A794NotaFiscalId[0];
            n794NotaFiscalId = BC002N25_n794NotaFiscalId[0];
            A795NotaFiscalUF = BC002N25_A795NotaFiscalUF[0];
            n795NotaFiscalUF = BC002N25_n795NotaFiscalUF[0];
            A796NotaFiscalNatureza = BC002N25_A796NotaFiscalNatureza[0];
            n796NotaFiscalNatureza = BC002N25_n796NotaFiscalNatureza[0];
            A797NotaFiscalMod = BC002N25_A797NotaFiscalMod[0];
            n797NotaFiscalMod = BC002N25_n797NotaFiscalMod[0];
            A798NotaFiscalSerie = BC002N25_A798NotaFiscalSerie[0];
            n798NotaFiscalSerie = BC002N25_n798NotaFiscalSerie[0];
            A799NotaFiscalNumero = BC002N25_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = BC002N25_n799NotaFiscalNumero[0];
            A800NotaFiscalDataEmissao = BC002N25_A800NotaFiscalDataEmissao[0];
            n800NotaFiscalDataEmissao = BC002N25_n800NotaFiscalDataEmissao[0];
            A801NotaFiscalDataSaida = BC002N25_A801NotaFiscalDataSaida[0];
            n801NotaFiscalDataSaida = BC002N25_n801NotaFiscalDataSaida[0];
            A802NotaFiscalTipo = BC002N25_A802NotaFiscalTipo[0];
            n802NotaFiscalTipo = BC002N25_n802NotaFiscalTipo[0];
            A803NotaFiscalMunicipio = BC002N25_A803NotaFiscalMunicipio[0];
            n803NotaFiscalMunicipio = BC002N25_n803NotaFiscalMunicipio[0];
            A804NotaFiscalTipoEmissao = BC002N25_A804NotaFiscalTipoEmissao[0];
            n804NotaFiscalTipoEmissao = BC002N25_n804NotaFiscalTipoEmissao[0];
            A805NotaFiscalAmbiente = BC002N25_A805NotaFiscalAmbiente[0];
            n805NotaFiscalAmbiente = BC002N25_n805NotaFiscalAmbiente[0];
            A806NotaFiscalFinalidades = BC002N25_A806NotaFiscalFinalidades[0];
            n806NotaFiscalFinalidades = BC002N25_n806NotaFiscalFinalidades[0];
            A818NotaFiscaEmitentelDocumento = BC002N25_A818NotaFiscaEmitentelDocumento[0];
            n818NotaFiscaEmitentelDocumento = BC002N25_n818NotaFiscaEmitentelDocumento[0];
            A808NotaFiscalEmitenteNome = BC002N25_A808NotaFiscalEmitenteNome[0];
            n808NotaFiscalEmitenteNome = BC002N25_n808NotaFiscalEmitenteNome[0];
            A809NotaFiscalEmitenteLogradouro = BC002N25_A809NotaFiscalEmitenteLogradouro[0];
            n809NotaFiscalEmitenteLogradouro = BC002N25_n809NotaFiscalEmitenteLogradouro[0];
            A810NotaFiscalEmitenteLogNum = BC002N25_A810NotaFiscalEmitenteLogNum[0];
            n810NotaFiscalEmitenteLogNum = BC002N25_n810NotaFiscalEmitenteLogNum[0];
            A811NotaFiscalEmitenteComplemento = BC002N25_A811NotaFiscalEmitenteComplemento[0];
            n811NotaFiscalEmitenteComplemento = BC002N25_n811NotaFiscalEmitenteComplemento[0];
            A812NotaFiscalEmitenteBairro = BC002N25_A812NotaFiscalEmitenteBairro[0];
            n812NotaFiscalEmitenteBairro = BC002N25_n812NotaFiscalEmitenteBairro[0];
            A813NotaFiscalEmitenteMunicipio = BC002N25_A813NotaFiscalEmitenteMunicipio[0];
            n813NotaFiscalEmitenteMunicipio = BC002N25_n813NotaFiscalEmitenteMunicipio[0];
            A814NotaFiscalEmitenteUF = BC002N25_A814NotaFiscalEmitenteUF[0];
            n814NotaFiscalEmitenteUF = BC002N25_n814NotaFiscalEmitenteUF[0];
            A815NotaFiscalEmitenteCEP = BC002N25_A815NotaFiscalEmitenteCEP[0];
            n815NotaFiscalEmitenteCEP = BC002N25_n815NotaFiscalEmitenteCEP[0];
            A816NotaFiscalEmitentePais = BC002N25_A816NotaFiscalEmitentePais[0];
            n816NotaFiscalEmitentePais = BC002N25_n816NotaFiscalEmitentePais[0];
            A817NotaFiscalEmitenteTelefone = BC002N25_A817NotaFiscalEmitenteTelefone[0];
            n817NotaFiscalEmitenteTelefone = BC002N25_n817NotaFiscalEmitenteTelefone[0];
            A819NotaFiscalEmitenteIE = BC002N25_A819NotaFiscalEmitenteIE[0];
            n819NotaFiscalEmitenteIE = BC002N25_n819NotaFiscalEmitenteIE[0];
            A820NotaFiscalDestinatarioDocumento = BC002N25_A820NotaFiscalDestinatarioDocumento[0];
            n820NotaFiscalDestinatarioDocumento = BC002N25_n820NotaFiscalDestinatarioDocumento[0];
            A852NotaFiscalDestinatarioNome = BC002N25_A852NotaFiscalDestinatarioNome[0];
            n852NotaFiscalDestinatarioNome = BC002N25_n852NotaFiscalDestinatarioNome[0];
            A821NotaFiscalDestinatarioLogradouro = BC002N25_A821NotaFiscalDestinatarioLogradouro[0];
            n821NotaFiscalDestinatarioLogradouro = BC002N25_n821NotaFiscalDestinatarioLogradouro[0];
            A822NotaFiscalDestinatarioLogNum = BC002N25_A822NotaFiscalDestinatarioLogNum[0];
            n822NotaFiscalDestinatarioLogNum = BC002N25_n822NotaFiscalDestinatarioLogNum[0];
            A823NotaFiscalDestinatarioComplemento = BC002N25_A823NotaFiscalDestinatarioComplemento[0];
            n823NotaFiscalDestinatarioComplemento = BC002N25_n823NotaFiscalDestinatarioComplemento[0];
            A824NotaFiscalDestinatarioBairro = BC002N25_A824NotaFiscalDestinatarioBairro[0];
            n824NotaFiscalDestinatarioBairro = BC002N25_n824NotaFiscalDestinatarioBairro[0];
            A825NotaFiscalDestinatarioMunicipio = BC002N25_A825NotaFiscalDestinatarioMunicipio[0];
            n825NotaFiscalDestinatarioMunicipio = BC002N25_n825NotaFiscalDestinatarioMunicipio[0];
            A826NotaFiscalDestinatarioUF = BC002N25_A826NotaFiscalDestinatarioUF[0];
            n826NotaFiscalDestinatarioUF = BC002N25_n826NotaFiscalDestinatarioUF[0];
            A827NotaFiscalDestinatarioCEP = BC002N25_A827NotaFiscalDestinatarioCEP[0];
            n827NotaFiscalDestinatarioCEP = BC002N25_n827NotaFiscalDestinatarioCEP[0];
            A828NotaFiscalDestinatarioPais = BC002N25_A828NotaFiscalDestinatarioPais[0];
            n828NotaFiscalDestinatarioPais = BC002N25_n828NotaFiscalDestinatarioPais[0];
            A829NotaFiscalDestinatarioFone = BC002N25_A829NotaFiscalDestinatarioFone[0];
            n829NotaFiscalDestinatarioFone = BC002N25_n829NotaFiscalDestinatarioFone[0];
            A168ClienteId = BC002N25_A168ClienteId[0];
            n168ClienteId = BC002N25_n168ClienteId[0];
            A889NotaFiscalDestinatarioClienteId = BC002N25_A889NotaFiscalDestinatarioClienteId[0];
            n889NotaFiscalDestinatarioClienteId = BC002N25_n889NotaFiscalDestinatarioClienteId[0];
            A874NotaFiscalValorTotal_F = BC002N25_A874NotaFiscalValorTotal_F[0];
            A875NotaFiscalValorTotalVendido_F = BC002N25_A875NotaFiscalValorTotalVendido_F[0];
            A877NotaFiscalQuantidadeDeItens_F = BC002N25_A877NotaFiscalQuantidadeDeItens_F[0];
            A878NotaFiscalQuantidadeDeItensVendidos_F = BC002N25_A878NotaFiscalQuantidadeDeItensVendidos_F[0];
         }
         Gx_mode = sMode93;
      }

      protected void ScanKeyEnd2N93( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm2N93( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2N93( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2N93( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2N93( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2N93( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2N93( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2N93( )
      {
      }

      protected void send_integrity_lvl_hashes2N93( )
      {
      }

      protected void AddRow2N93( )
      {
         VarsToRow93( bcNotaFiscal) ;
      }

      protected void ReadRow2N93( )
      {
         RowToVars93( bcNotaFiscal, 1) ;
      }

      protected void InitializeNonKey2N93( )
      {
         A879NotaFiscalQuantidadeResumo_F = "";
         A880NotaFiscalStatus = "";
         A883NotaFiscalSaldoFormatado_F = "";
         A882NotaFiscalValorVendidoFormatado_F = "";
         A876NotaFiscalSaldo_F = 0;
         A881NotaFiscalValorFormatado_F = "";
         A168ClienteId = 0;
         n168ClienteId = false;
         A795NotaFiscalUF = 0;
         n795NotaFiscalUF = false;
         A874NotaFiscalValorTotal_F = 0;
         A875NotaFiscalValorTotalVendido_F = 0;
         A877NotaFiscalQuantidadeDeItens_F = 0;
         A878NotaFiscalQuantidadeDeItensVendidos_F = 0;
         A796NotaFiscalNatureza = "";
         n796NotaFiscalNatureza = false;
         A797NotaFiscalMod = "";
         n797NotaFiscalMod = false;
         A798NotaFiscalSerie = "";
         n798NotaFiscalSerie = false;
         A799NotaFiscalNumero = "";
         n799NotaFiscalNumero = false;
         A800NotaFiscalDataEmissao = (DateTime)(DateTime.MinValue);
         n800NotaFiscalDataEmissao = false;
         A801NotaFiscalDataSaida = (DateTime)(DateTime.MinValue);
         n801NotaFiscalDataSaida = false;
         A802NotaFiscalTipo = "";
         n802NotaFiscalTipo = false;
         A803NotaFiscalMunicipio = "";
         n803NotaFiscalMunicipio = false;
         A804NotaFiscalTipoEmissao = "";
         n804NotaFiscalTipoEmissao = false;
         A805NotaFiscalAmbiente = 0;
         n805NotaFiscalAmbiente = false;
         A806NotaFiscalFinalidades = "";
         n806NotaFiscalFinalidades = false;
         A818NotaFiscaEmitentelDocumento = "";
         n818NotaFiscaEmitentelDocumento = false;
         A808NotaFiscalEmitenteNome = "";
         n808NotaFiscalEmitenteNome = false;
         A809NotaFiscalEmitenteLogradouro = "";
         n809NotaFiscalEmitenteLogradouro = false;
         A810NotaFiscalEmitenteLogNum = "";
         n810NotaFiscalEmitenteLogNum = false;
         A811NotaFiscalEmitenteComplemento = "";
         n811NotaFiscalEmitenteComplemento = false;
         A812NotaFiscalEmitenteBairro = "";
         n812NotaFiscalEmitenteBairro = false;
         A813NotaFiscalEmitenteMunicipio = "";
         n813NotaFiscalEmitenteMunicipio = false;
         A814NotaFiscalEmitenteUF = "";
         n814NotaFiscalEmitenteUF = false;
         A815NotaFiscalEmitenteCEP = "";
         n815NotaFiscalEmitenteCEP = false;
         A816NotaFiscalEmitentePais = "";
         n816NotaFiscalEmitentePais = false;
         A817NotaFiscalEmitenteTelefone = "";
         n817NotaFiscalEmitenteTelefone = false;
         A819NotaFiscalEmitenteIE = "";
         n819NotaFiscalEmitenteIE = false;
         A889NotaFiscalDestinatarioClienteId = 0;
         n889NotaFiscalDestinatarioClienteId = false;
         A820NotaFiscalDestinatarioDocumento = "";
         n820NotaFiscalDestinatarioDocumento = false;
         A852NotaFiscalDestinatarioNome = "";
         n852NotaFiscalDestinatarioNome = false;
         A821NotaFiscalDestinatarioLogradouro = "";
         n821NotaFiscalDestinatarioLogradouro = false;
         A822NotaFiscalDestinatarioLogNum = "";
         n822NotaFiscalDestinatarioLogNum = false;
         A823NotaFiscalDestinatarioComplemento = "";
         n823NotaFiscalDestinatarioComplemento = false;
         A824NotaFiscalDestinatarioBairro = "";
         n824NotaFiscalDestinatarioBairro = false;
         A825NotaFiscalDestinatarioMunicipio = "";
         n825NotaFiscalDestinatarioMunicipio = false;
         A826NotaFiscalDestinatarioUF = "";
         n826NotaFiscalDestinatarioUF = false;
         A827NotaFiscalDestinatarioCEP = "";
         n827NotaFiscalDestinatarioCEP = false;
         A828NotaFiscalDestinatarioPais = "";
         n828NotaFiscalDestinatarioPais = false;
         A829NotaFiscalDestinatarioFone = "";
         n829NotaFiscalDestinatarioFone = false;
         Z795NotaFiscalUF = 0;
         Z796NotaFiscalNatureza = "";
         Z797NotaFiscalMod = "";
         Z798NotaFiscalSerie = "";
         Z799NotaFiscalNumero = "";
         Z800NotaFiscalDataEmissao = (DateTime)(DateTime.MinValue);
         Z801NotaFiscalDataSaida = (DateTime)(DateTime.MinValue);
         Z802NotaFiscalTipo = "";
         Z803NotaFiscalMunicipio = "";
         Z804NotaFiscalTipoEmissao = "";
         Z805NotaFiscalAmbiente = 0;
         Z806NotaFiscalFinalidades = "";
         Z818NotaFiscaEmitentelDocumento = "";
         Z808NotaFiscalEmitenteNome = "";
         Z809NotaFiscalEmitenteLogradouro = "";
         Z810NotaFiscalEmitenteLogNum = "";
         Z811NotaFiscalEmitenteComplemento = "";
         Z812NotaFiscalEmitenteBairro = "";
         Z813NotaFiscalEmitenteMunicipio = "";
         Z814NotaFiscalEmitenteUF = "";
         Z815NotaFiscalEmitenteCEP = "";
         Z816NotaFiscalEmitentePais = "";
         Z817NotaFiscalEmitenteTelefone = "";
         Z819NotaFiscalEmitenteIE = "";
         Z820NotaFiscalDestinatarioDocumento = "";
         Z852NotaFiscalDestinatarioNome = "";
         Z821NotaFiscalDestinatarioLogradouro = "";
         Z822NotaFiscalDestinatarioLogNum = "";
         Z823NotaFiscalDestinatarioComplemento = "";
         Z824NotaFiscalDestinatarioBairro = "";
         Z825NotaFiscalDestinatarioMunicipio = "";
         Z826NotaFiscalDestinatarioUF = "";
         Z827NotaFiscalDestinatarioCEP = "";
         Z828NotaFiscalDestinatarioPais = "";
         Z829NotaFiscalDestinatarioFone = "";
         Z168ClienteId = 0;
         Z889NotaFiscalDestinatarioClienteId = 0;
      }

      protected void InitAll2N93( )
      {
         A794NotaFiscalId = Guid.NewGuid( );
         n794NotaFiscalId = false;
         InitializeNonKey2N93( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow93( SdtNotaFiscal obj93 )
      {
         obj93.gxTpr_Mode = Gx_mode;
         obj93.gxTpr_Notafiscalquantidaderesumo_f = A879NotaFiscalQuantidadeResumo_F;
         obj93.gxTpr_Notafiscalstatus = A880NotaFiscalStatus;
         obj93.gxTpr_Notafiscalsaldoformatado_f = A883NotaFiscalSaldoFormatado_F;
         obj93.gxTpr_Notafiscalvalorvendidoformatado_f = A882NotaFiscalValorVendidoFormatado_F;
         obj93.gxTpr_Notafiscalsaldo_f = A876NotaFiscalSaldo_F;
         obj93.gxTpr_Notafiscalvalorformatado_f = A881NotaFiscalValorFormatado_F;
         obj93.gxTpr_Clienteid = A168ClienteId;
         obj93.gxTpr_Notafiscaluf = A795NotaFiscalUF;
         obj93.gxTpr_Notafiscalvalortotal_f = A874NotaFiscalValorTotal_F;
         obj93.gxTpr_Notafiscalvalortotalvendido_f = A875NotaFiscalValorTotalVendido_F;
         obj93.gxTpr_Notafiscalquantidadedeitens_f = A877NotaFiscalQuantidadeDeItens_F;
         obj93.gxTpr_Notafiscalquantidadedeitensvendidos_f = A878NotaFiscalQuantidadeDeItensVendidos_F;
         obj93.gxTpr_Notafiscalnatureza = A796NotaFiscalNatureza;
         obj93.gxTpr_Notafiscalmod = A797NotaFiscalMod;
         obj93.gxTpr_Notafiscalserie = A798NotaFiscalSerie;
         obj93.gxTpr_Notafiscalnumero = A799NotaFiscalNumero;
         obj93.gxTpr_Notafiscaldataemissao = A800NotaFiscalDataEmissao;
         obj93.gxTpr_Notafiscaldatasaida = A801NotaFiscalDataSaida;
         obj93.gxTpr_Notafiscaltipo = A802NotaFiscalTipo;
         obj93.gxTpr_Notafiscalmunicipio = A803NotaFiscalMunicipio;
         obj93.gxTpr_Notafiscaltipoemissao = A804NotaFiscalTipoEmissao;
         obj93.gxTpr_Notafiscalambiente = A805NotaFiscalAmbiente;
         obj93.gxTpr_Notafiscalfinalidades = A806NotaFiscalFinalidades;
         obj93.gxTpr_Notafiscaemitenteldocumento = A818NotaFiscaEmitentelDocumento;
         obj93.gxTpr_Notafiscalemitentenome = A808NotaFiscalEmitenteNome;
         obj93.gxTpr_Notafiscalemitentelogradouro = A809NotaFiscalEmitenteLogradouro;
         obj93.gxTpr_Notafiscalemitentelognum = A810NotaFiscalEmitenteLogNum;
         obj93.gxTpr_Notafiscalemitentecomplemento = A811NotaFiscalEmitenteComplemento;
         obj93.gxTpr_Notafiscalemitentebairro = A812NotaFiscalEmitenteBairro;
         obj93.gxTpr_Notafiscalemitentemunicipio = A813NotaFiscalEmitenteMunicipio;
         obj93.gxTpr_Notafiscalemitenteuf = A814NotaFiscalEmitenteUF;
         obj93.gxTpr_Notafiscalemitentecep = A815NotaFiscalEmitenteCEP;
         obj93.gxTpr_Notafiscalemitentepais = A816NotaFiscalEmitentePais;
         obj93.gxTpr_Notafiscalemitentetelefone = A817NotaFiscalEmitenteTelefone;
         obj93.gxTpr_Notafiscalemitenteie = A819NotaFiscalEmitenteIE;
         obj93.gxTpr_Notafiscaldestinatarioclienteid = A889NotaFiscalDestinatarioClienteId;
         obj93.gxTpr_Notafiscaldestinatariodocumento = A820NotaFiscalDestinatarioDocumento;
         obj93.gxTpr_Notafiscaldestinatarionome = A852NotaFiscalDestinatarioNome;
         obj93.gxTpr_Notafiscaldestinatariologradouro = A821NotaFiscalDestinatarioLogradouro;
         obj93.gxTpr_Notafiscaldestinatariolognum = A822NotaFiscalDestinatarioLogNum;
         obj93.gxTpr_Notafiscaldestinatariocomplemento = A823NotaFiscalDestinatarioComplemento;
         obj93.gxTpr_Notafiscaldestinatariobairro = A824NotaFiscalDestinatarioBairro;
         obj93.gxTpr_Notafiscaldestinatariomunicipio = A825NotaFiscalDestinatarioMunicipio;
         obj93.gxTpr_Notafiscaldestinatariouf = A826NotaFiscalDestinatarioUF;
         obj93.gxTpr_Notafiscaldestinatariocep = A827NotaFiscalDestinatarioCEP;
         obj93.gxTpr_Notafiscaldestinatariopais = A828NotaFiscalDestinatarioPais;
         obj93.gxTpr_Notafiscaldestinatariofone = A829NotaFiscalDestinatarioFone;
         obj93.gxTpr_Notafiscalid = A794NotaFiscalId;
         obj93.gxTpr_Notafiscalid_Z = Z794NotaFiscalId;
         obj93.gxTpr_Clienteid_Z = Z168ClienteId;
         obj93.gxTpr_Notafiscaluf_Z = Z795NotaFiscalUF;
         obj93.gxTpr_Notafiscalvalortotal_f_Z = Z874NotaFiscalValorTotal_F;
         obj93.gxTpr_Notafiscalvalortotalvendido_f_Z = Z875NotaFiscalValorTotalVendido_F;
         obj93.gxTpr_Notafiscalsaldo_f_Z = Z876NotaFiscalSaldo_F;
         obj93.gxTpr_Notafiscalquantidadedeitens_f_Z = Z877NotaFiscalQuantidadeDeItens_F;
         obj93.gxTpr_Notafiscalquantidadedeitensvendidos_f_Z = Z878NotaFiscalQuantidadeDeItensVendidos_F;
         obj93.gxTpr_Notafiscalquantidaderesumo_f_Z = Z879NotaFiscalQuantidadeResumo_F;
         obj93.gxTpr_Notafiscalvalorformatado_f_Z = Z881NotaFiscalValorFormatado_F;
         obj93.gxTpr_Notafiscalvalorvendidoformatado_f_Z = Z882NotaFiscalValorVendidoFormatado_F;
         obj93.gxTpr_Notafiscalsaldoformatado_f_Z = Z883NotaFiscalSaldoFormatado_F;
         obj93.gxTpr_Notafiscalstatus_Z = Z880NotaFiscalStatus;
         obj93.gxTpr_Notafiscalnatureza_Z = Z796NotaFiscalNatureza;
         obj93.gxTpr_Notafiscalmod_Z = Z797NotaFiscalMod;
         obj93.gxTpr_Notafiscalserie_Z = Z798NotaFiscalSerie;
         obj93.gxTpr_Notafiscalnumero_Z = Z799NotaFiscalNumero;
         obj93.gxTpr_Notafiscaldataemissao_Z = Z800NotaFiscalDataEmissao;
         obj93.gxTpr_Notafiscaldatasaida_Z = Z801NotaFiscalDataSaida;
         obj93.gxTpr_Notafiscaltipo_Z = Z802NotaFiscalTipo;
         obj93.gxTpr_Notafiscalmunicipio_Z = Z803NotaFiscalMunicipio;
         obj93.gxTpr_Notafiscaltipoemissao_Z = Z804NotaFiscalTipoEmissao;
         obj93.gxTpr_Notafiscalambiente_Z = Z805NotaFiscalAmbiente;
         obj93.gxTpr_Notafiscalfinalidades_Z = Z806NotaFiscalFinalidades;
         obj93.gxTpr_Notafiscaemitenteldocumento_Z = Z818NotaFiscaEmitentelDocumento;
         obj93.gxTpr_Notafiscalemitentenome_Z = Z808NotaFiscalEmitenteNome;
         obj93.gxTpr_Notafiscalemitentelogradouro_Z = Z809NotaFiscalEmitenteLogradouro;
         obj93.gxTpr_Notafiscalemitentelognum_Z = Z810NotaFiscalEmitenteLogNum;
         obj93.gxTpr_Notafiscalemitentecomplemento_Z = Z811NotaFiscalEmitenteComplemento;
         obj93.gxTpr_Notafiscalemitentebairro_Z = Z812NotaFiscalEmitenteBairro;
         obj93.gxTpr_Notafiscalemitentemunicipio_Z = Z813NotaFiscalEmitenteMunicipio;
         obj93.gxTpr_Notafiscalemitenteuf_Z = Z814NotaFiscalEmitenteUF;
         obj93.gxTpr_Notafiscalemitentecep_Z = Z815NotaFiscalEmitenteCEP;
         obj93.gxTpr_Notafiscalemitentepais_Z = Z816NotaFiscalEmitentePais;
         obj93.gxTpr_Notafiscalemitentetelefone_Z = Z817NotaFiscalEmitenteTelefone;
         obj93.gxTpr_Notafiscalemitenteie_Z = Z819NotaFiscalEmitenteIE;
         obj93.gxTpr_Notafiscaldestinatarioclienteid_Z = Z889NotaFiscalDestinatarioClienteId;
         obj93.gxTpr_Notafiscaldestinatariodocumento_Z = Z820NotaFiscalDestinatarioDocumento;
         obj93.gxTpr_Notafiscaldestinatarionome_Z = Z852NotaFiscalDestinatarioNome;
         obj93.gxTpr_Notafiscaldestinatariologradouro_Z = Z821NotaFiscalDestinatarioLogradouro;
         obj93.gxTpr_Notafiscaldestinatariolognum_Z = Z822NotaFiscalDestinatarioLogNum;
         obj93.gxTpr_Notafiscaldestinatariocomplemento_Z = Z823NotaFiscalDestinatarioComplemento;
         obj93.gxTpr_Notafiscaldestinatariobairro_Z = Z824NotaFiscalDestinatarioBairro;
         obj93.gxTpr_Notafiscaldestinatariomunicipio_Z = Z825NotaFiscalDestinatarioMunicipio;
         obj93.gxTpr_Notafiscaldestinatariouf_Z = Z826NotaFiscalDestinatarioUF;
         obj93.gxTpr_Notafiscaldestinatariocep_Z = Z827NotaFiscalDestinatarioCEP;
         obj93.gxTpr_Notafiscaldestinatariopais_Z = Z828NotaFiscalDestinatarioPais;
         obj93.gxTpr_Notafiscaldestinatariofone_Z = Z829NotaFiscalDestinatarioFone;
         obj93.gxTpr_Notafiscalid_N = (short)(Convert.ToInt16(n794NotaFiscalId));
         obj93.gxTpr_Clienteid_N = (short)(Convert.ToInt16(n168ClienteId));
         obj93.gxTpr_Notafiscaluf_N = (short)(Convert.ToInt16(n795NotaFiscalUF));
         obj93.gxTpr_Notafiscalnatureza_N = (short)(Convert.ToInt16(n796NotaFiscalNatureza));
         obj93.gxTpr_Notafiscalmod_N = (short)(Convert.ToInt16(n797NotaFiscalMod));
         obj93.gxTpr_Notafiscalserie_N = (short)(Convert.ToInt16(n798NotaFiscalSerie));
         obj93.gxTpr_Notafiscalnumero_N = (short)(Convert.ToInt16(n799NotaFiscalNumero));
         obj93.gxTpr_Notafiscaldataemissao_N = (short)(Convert.ToInt16(n800NotaFiscalDataEmissao));
         obj93.gxTpr_Notafiscaldatasaida_N = (short)(Convert.ToInt16(n801NotaFiscalDataSaida));
         obj93.gxTpr_Notafiscaltipo_N = (short)(Convert.ToInt16(n802NotaFiscalTipo));
         obj93.gxTpr_Notafiscalmunicipio_N = (short)(Convert.ToInt16(n803NotaFiscalMunicipio));
         obj93.gxTpr_Notafiscaltipoemissao_N = (short)(Convert.ToInt16(n804NotaFiscalTipoEmissao));
         obj93.gxTpr_Notafiscalambiente_N = (short)(Convert.ToInt16(n805NotaFiscalAmbiente));
         obj93.gxTpr_Notafiscalfinalidades_N = (short)(Convert.ToInt16(n806NotaFiscalFinalidades));
         obj93.gxTpr_Notafiscaemitenteldocumento_N = (short)(Convert.ToInt16(n818NotaFiscaEmitentelDocumento));
         obj93.gxTpr_Notafiscalemitentenome_N = (short)(Convert.ToInt16(n808NotaFiscalEmitenteNome));
         obj93.gxTpr_Notafiscalemitentelogradouro_N = (short)(Convert.ToInt16(n809NotaFiscalEmitenteLogradouro));
         obj93.gxTpr_Notafiscalemitentelognum_N = (short)(Convert.ToInt16(n810NotaFiscalEmitenteLogNum));
         obj93.gxTpr_Notafiscalemitentecomplemento_N = (short)(Convert.ToInt16(n811NotaFiscalEmitenteComplemento));
         obj93.gxTpr_Notafiscalemitentebairro_N = (short)(Convert.ToInt16(n812NotaFiscalEmitenteBairro));
         obj93.gxTpr_Notafiscalemitentemunicipio_N = (short)(Convert.ToInt16(n813NotaFiscalEmitenteMunicipio));
         obj93.gxTpr_Notafiscalemitenteuf_N = (short)(Convert.ToInt16(n814NotaFiscalEmitenteUF));
         obj93.gxTpr_Notafiscalemitentecep_N = (short)(Convert.ToInt16(n815NotaFiscalEmitenteCEP));
         obj93.gxTpr_Notafiscalemitentepais_N = (short)(Convert.ToInt16(n816NotaFiscalEmitentePais));
         obj93.gxTpr_Notafiscalemitentetelefone_N = (short)(Convert.ToInt16(n817NotaFiscalEmitenteTelefone));
         obj93.gxTpr_Notafiscalemitenteie_N = (short)(Convert.ToInt16(n819NotaFiscalEmitenteIE));
         obj93.gxTpr_Notafiscaldestinatarioclienteid_N = (short)(Convert.ToInt16(n889NotaFiscalDestinatarioClienteId));
         obj93.gxTpr_Notafiscaldestinatariodocumento_N = (short)(Convert.ToInt16(n820NotaFiscalDestinatarioDocumento));
         obj93.gxTpr_Notafiscaldestinatarionome_N = (short)(Convert.ToInt16(n852NotaFiscalDestinatarioNome));
         obj93.gxTpr_Notafiscaldestinatariologradouro_N = (short)(Convert.ToInt16(n821NotaFiscalDestinatarioLogradouro));
         obj93.gxTpr_Notafiscaldestinatariolognum_N = (short)(Convert.ToInt16(n822NotaFiscalDestinatarioLogNum));
         obj93.gxTpr_Notafiscaldestinatariocomplemento_N = (short)(Convert.ToInt16(n823NotaFiscalDestinatarioComplemento));
         obj93.gxTpr_Notafiscaldestinatariobairro_N = (short)(Convert.ToInt16(n824NotaFiscalDestinatarioBairro));
         obj93.gxTpr_Notafiscaldestinatariomunicipio_N = (short)(Convert.ToInt16(n825NotaFiscalDestinatarioMunicipio));
         obj93.gxTpr_Notafiscaldestinatariouf_N = (short)(Convert.ToInt16(n826NotaFiscalDestinatarioUF));
         obj93.gxTpr_Notafiscaldestinatariocep_N = (short)(Convert.ToInt16(n827NotaFiscalDestinatarioCEP));
         obj93.gxTpr_Notafiscaldestinatariopais_N = (short)(Convert.ToInt16(n828NotaFiscalDestinatarioPais));
         obj93.gxTpr_Notafiscaldestinatariofone_N = (short)(Convert.ToInt16(n829NotaFiscalDestinatarioFone));
         obj93.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow93( SdtNotaFiscal obj93 )
      {
         obj93.gxTpr_Notafiscalid = A794NotaFiscalId;
         return  ;
      }

      public void RowToVars93( SdtNotaFiscal obj93 ,
                               int forceLoad )
      {
         Gx_mode = obj93.gxTpr_Mode;
         A879NotaFiscalQuantidadeResumo_F = obj93.gxTpr_Notafiscalquantidaderesumo_f;
         A880NotaFiscalStatus = obj93.gxTpr_Notafiscalstatus;
         A883NotaFiscalSaldoFormatado_F = obj93.gxTpr_Notafiscalsaldoformatado_f;
         A882NotaFiscalValorVendidoFormatado_F = obj93.gxTpr_Notafiscalvalorvendidoformatado_f;
         A876NotaFiscalSaldo_F = obj93.gxTpr_Notafiscalsaldo_f;
         A881NotaFiscalValorFormatado_F = obj93.gxTpr_Notafiscalvalorformatado_f;
         A168ClienteId = obj93.gxTpr_Clienteid;
         n168ClienteId = false;
         A795NotaFiscalUF = obj93.gxTpr_Notafiscaluf;
         n795NotaFiscalUF = false;
         A874NotaFiscalValorTotal_F = obj93.gxTpr_Notafiscalvalortotal_f;
         A875NotaFiscalValorTotalVendido_F = obj93.gxTpr_Notafiscalvalortotalvendido_f;
         A877NotaFiscalQuantidadeDeItens_F = obj93.gxTpr_Notafiscalquantidadedeitens_f;
         A878NotaFiscalQuantidadeDeItensVendidos_F = obj93.gxTpr_Notafiscalquantidadedeitensvendidos_f;
         A796NotaFiscalNatureza = obj93.gxTpr_Notafiscalnatureza;
         n796NotaFiscalNatureza = false;
         A797NotaFiscalMod = obj93.gxTpr_Notafiscalmod;
         n797NotaFiscalMod = false;
         A798NotaFiscalSerie = obj93.gxTpr_Notafiscalserie;
         n798NotaFiscalSerie = false;
         A799NotaFiscalNumero = obj93.gxTpr_Notafiscalnumero;
         n799NotaFiscalNumero = false;
         A800NotaFiscalDataEmissao = obj93.gxTpr_Notafiscaldataemissao;
         n800NotaFiscalDataEmissao = false;
         A801NotaFiscalDataSaida = obj93.gxTpr_Notafiscaldatasaida;
         n801NotaFiscalDataSaida = false;
         A802NotaFiscalTipo = obj93.gxTpr_Notafiscaltipo;
         n802NotaFiscalTipo = false;
         A803NotaFiscalMunicipio = obj93.gxTpr_Notafiscalmunicipio;
         n803NotaFiscalMunicipio = false;
         A804NotaFiscalTipoEmissao = obj93.gxTpr_Notafiscaltipoemissao;
         n804NotaFiscalTipoEmissao = false;
         A805NotaFiscalAmbiente = obj93.gxTpr_Notafiscalambiente;
         n805NotaFiscalAmbiente = false;
         A806NotaFiscalFinalidades = obj93.gxTpr_Notafiscalfinalidades;
         n806NotaFiscalFinalidades = false;
         A818NotaFiscaEmitentelDocumento = obj93.gxTpr_Notafiscaemitenteldocumento;
         n818NotaFiscaEmitentelDocumento = false;
         A808NotaFiscalEmitenteNome = obj93.gxTpr_Notafiscalemitentenome;
         n808NotaFiscalEmitenteNome = false;
         A809NotaFiscalEmitenteLogradouro = obj93.gxTpr_Notafiscalemitentelogradouro;
         n809NotaFiscalEmitenteLogradouro = false;
         A810NotaFiscalEmitenteLogNum = obj93.gxTpr_Notafiscalemitentelognum;
         n810NotaFiscalEmitenteLogNum = false;
         A811NotaFiscalEmitenteComplemento = obj93.gxTpr_Notafiscalemitentecomplemento;
         n811NotaFiscalEmitenteComplemento = false;
         A812NotaFiscalEmitenteBairro = obj93.gxTpr_Notafiscalemitentebairro;
         n812NotaFiscalEmitenteBairro = false;
         A813NotaFiscalEmitenteMunicipio = obj93.gxTpr_Notafiscalemitentemunicipio;
         n813NotaFiscalEmitenteMunicipio = false;
         A814NotaFiscalEmitenteUF = obj93.gxTpr_Notafiscalemitenteuf;
         n814NotaFiscalEmitenteUF = false;
         A815NotaFiscalEmitenteCEP = obj93.gxTpr_Notafiscalemitentecep;
         n815NotaFiscalEmitenteCEP = false;
         A816NotaFiscalEmitentePais = obj93.gxTpr_Notafiscalemitentepais;
         n816NotaFiscalEmitentePais = false;
         A817NotaFiscalEmitenteTelefone = obj93.gxTpr_Notafiscalemitentetelefone;
         n817NotaFiscalEmitenteTelefone = false;
         A819NotaFiscalEmitenteIE = obj93.gxTpr_Notafiscalemitenteie;
         n819NotaFiscalEmitenteIE = false;
         A889NotaFiscalDestinatarioClienteId = obj93.gxTpr_Notafiscaldestinatarioclienteid;
         n889NotaFiscalDestinatarioClienteId = false;
         A820NotaFiscalDestinatarioDocumento = obj93.gxTpr_Notafiscaldestinatariodocumento;
         n820NotaFiscalDestinatarioDocumento = false;
         A852NotaFiscalDestinatarioNome = obj93.gxTpr_Notafiscaldestinatarionome;
         n852NotaFiscalDestinatarioNome = false;
         A821NotaFiscalDestinatarioLogradouro = obj93.gxTpr_Notafiscaldestinatariologradouro;
         n821NotaFiscalDestinatarioLogradouro = false;
         A822NotaFiscalDestinatarioLogNum = obj93.gxTpr_Notafiscaldestinatariolognum;
         n822NotaFiscalDestinatarioLogNum = false;
         A823NotaFiscalDestinatarioComplemento = obj93.gxTpr_Notafiscaldestinatariocomplemento;
         n823NotaFiscalDestinatarioComplemento = false;
         A824NotaFiscalDestinatarioBairro = obj93.gxTpr_Notafiscaldestinatariobairro;
         n824NotaFiscalDestinatarioBairro = false;
         A825NotaFiscalDestinatarioMunicipio = obj93.gxTpr_Notafiscaldestinatariomunicipio;
         n825NotaFiscalDestinatarioMunicipio = false;
         A826NotaFiscalDestinatarioUF = obj93.gxTpr_Notafiscaldestinatariouf;
         n826NotaFiscalDestinatarioUF = false;
         A827NotaFiscalDestinatarioCEP = obj93.gxTpr_Notafiscaldestinatariocep;
         n827NotaFiscalDestinatarioCEP = false;
         A828NotaFiscalDestinatarioPais = obj93.gxTpr_Notafiscaldestinatariopais;
         n828NotaFiscalDestinatarioPais = false;
         A829NotaFiscalDestinatarioFone = obj93.gxTpr_Notafiscaldestinatariofone;
         n829NotaFiscalDestinatarioFone = false;
         A794NotaFiscalId = obj93.gxTpr_Notafiscalid;
         n794NotaFiscalId = false;
         Z794NotaFiscalId = obj93.gxTpr_Notafiscalid_Z;
         Z168ClienteId = obj93.gxTpr_Clienteid_Z;
         Z795NotaFiscalUF = obj93.gxTpr_Notafiscaluf_Z;
         Z874NotaFiscalValorTotal_F = obj93.gxTpr_Notafiscalvalortotal_f_Z;
         Z875NotaFiscalValorTotalVendido_F = obj93.gxTpr_Notafiscalvalortotalvendido_f_Z;
         Z876NotaFiscalSaldo_F = obj93.gxTpr_Notafiscalsaldo_f_Z;
         Z877NotaFiscalQuantidadeDeItens_F = obj93.gxTpr_Notafiscalquantidadedeitens_f_Z;
         Z878NotaFiscalQuantidadeDeItensVendidos_F = obj93.gxTpr_Notafiscalquantidadedeitensvendidos_f_Z;
         Z879NotaFiscalQuantidadeResumo_F = obj93.gxTpr_Notafiscalquantidaderesumo_f_Z;
         Z881NotaFiscalValorFormatado_F = obj93.gxTpr_Notafiscalvalorformatado_f_Z;
         Z882NotaFiscalValorVendidoFormatado_F = obj93.gxTpr_Notafiscalvalorvendidoformatado_f_Z;
         Z883NotaFiscalSaldoFormatado_F = obj93.gxTpr_Notafiscalsaldoformatado_f_Z;
         Z880NotaFiscalStatus = obj93.gxTpr_Notafiscalstatus_Z;
         Z796NotaFiscalNatureza = obj93.gxTpr_Notafiscalnatureza_Z;
         Z797NotaFiscalMod = obj93.gxTpr_Notafiscalmod_Z;
         Z798NotaFiscalSerie = obj93.gxTpr_Notafiscalserie_Z;
         Z799NotaFiscalNumero = obj93.gxTpr_Notafiscalnumero_Z;
         Z800NotaFiscalDataEmissao = obj93.gxTpr_Notafiscaldataemissao_Z;
         Z801NotaFiscalDataSaida = obj93.gxTpr_Notafiscaldatasaida_Z;
         Z802NotaFiscalTipo = obj93.gxTpr_Notafiscaltipo_Z;
         Z803NotaFiscalMunicipio = obj93.gxTpr_Notafiscalmunicipio_Z;
         Z804NotaFiscalTipoEmissao = obj93.gxTpr_Notafiscaltipoemissao_Z;
         Z805NotaFiscalAmbiente = obj93.gxTpr_Notafiscalambiente_Z;
         Z806NotaFiscalFinalidades = obj93.gxTpr_Notafiscalfinalidades_Z;
         Z818NotaFiscaEmitentelDocumento = obj93.gxTpr_Notafiscaemitenteldocumento_Z;
         Z808NotaFiscalEmitenteNome = obj93.gxTpr_Notafiscalemitentenome_Z;
         Z809NotaFiscalEmitenteLogradouro = obj93.gxTpr_Notafiscalemitentelogradouro_Z;
         Z810NotaFiscalEmitenteLogNum = obj93.gxTpr_Notafiscalemitentelognum_Z;
         Z811NotaFiscalEmitenteComplemento = obj93.gxTpr_Notafiscalemitentecomplemento_Z;
         Z812NotaFiscalEmitenteBairro = obj93.gxTpr_Notafiscalemitentebairro_Z;
         Z813NotaFiscalEmitenteMunicipio = obj93.gxTpr_Notafiscalemitentemunicipio_Z;
         Z814NotaFiscalEmitenteUF = obj93.gxTpr_Notafiscalemitenteuf_Z;
         Z815NotaFiscalEmitenteCEP = obj93.gxTpr_Notafiscalemitentecep_Z;
         Z816NotaFiscalEmitentePais = obj93.gxTpr_Notafiscalemitentepais_Z;
         Z817NotaFiscalEmitenteTelefone = obj93.gxTpr_Notafiscalemitentetelefone_Z;
         Z819NotaFiscalEmitenteIE = obj93.gxTpr_Notafiscalemitenteie_Z;
         Z889NotaFiscalDestinatarioClienteId = obj93.gxTpr_Notafiscaldestinatarioclienteid_Z;
         Z820NotaFiscalDestinatarioDocumento = obj93.gxTpr_Notafiscaldestinatariodocumento_Z;
         Z852NotaFiscalDestinatarioNome = obj93.gxTpr_Notafiscaldestinatarionome_Z;
         Z821NotaFiscalDestinatarioLogradouro = obj93.gxTpr_Notafiscaldestinatariologradouro_Z;
         Z822NotaFiscalDestinatarioLogNum = obj93.gxTpr_Notafiscaldestinatariolognum_Z;
         Z823NotaFiscalDestinatarioComplemento = obj93.gxTpr_Notafiscaldestinatariocomplemento_Z;
         Z824NotaFiscalDestinatarioBairro = obj93.gxTpr_Notafiscaldestinatariobairro_Z;
         Z825NotaFiscalDestinatarioMunicipio = obj93.gxTpr_Notafiscaldestinatariomunicipio_Z;
         Z826NotaFiscalDestinatarioUF = obj93.gxTpr_Notafiscaldestinatariouf_Z;
         Z827NotaFiscalDestinatarioCEP = obj93.gxTpr_Notafiscaldestinatariocep_Z;
         Z828NotaFiscalDestinatarioPais = obj93.gxTpr_Notafiscaldestinatariopais_Z;
         Z829NotaFiscalDestinatarioFone = obj93.gxTpr_Notafiscaldestinatariofone_Z;
         n794NotaFiscalId = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalid_N));
         n168ClienteId = (bool)(Convert.ToBoolean(obj93.gxTpr_Clienteid_N));
         n795NotaFiscalUF = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaluf_N));
         n796NotaFiscalNatureza = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalnatureza_N));
         n797NotaFiscalMod = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalmod_N));
         n798NotaFiscalSerie = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalserie_N));
         n799NotaFiscalNumero = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalnumero_N));
         n800NotaFiscalDataEmissao = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldataemissao_N));
         n801NotaFiscalDataSaida = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldatasaida_N));
         n802NotaFiscalTipo = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaltipo_N));
         n803NotaFiscalMunicipio = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalmunicipio_N));
         n804NotaFiscalTipoEmissao = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaltipoemissao_N));
         n805NotaFiscalAmbiente = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalambiente_N));
         n806NotaFiscalFinalidades = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalfinalidades_N));
         n818NotaFiscaEmitentelDocumento = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaemitenteldocumento_N));
         n808NotaFiscalEmitenteNome = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalemitentenome_N));
         n809NotaFiscalEmitenteLogradouro = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalemitentelogradouro_N));
         n810NotaFiscalEmitenteLogNum = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalemitentelognum_N));
         n811NotaFiscalEmitenteComplemento = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalemitentecomplemento_N));
         n812NotaFiscalEmitenteBairro = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalemitentebairro_N));
         n813NotaFiscalEmitenteMunicipio = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalemitentemunicipio_N));
         n814NotaFiscalEmitenteUF = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalemitenteuf_N));
         n815NotaFiscalEmitenteCEP = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalemitentecep_N));
         n816NotaFiscalEmitentePais = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalemitentepais_N));
         n817NotaFiscalEmitenteTelefone = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalemitentetelefone_N));
         n819NotaFiscalEmitenteIE = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscalemitenteie_N));
         n889NotaFiscalDestinatarioClienteId = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldestinatarioclienteid_N));
         n820NotaFiscalDestinatarioDocumento = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldestinatariodocumento_N));
         n852NotaFiscalDestinatarioNome = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldestinatarionome_N));
         n821NotaFiscalDestinatarioLogradouro = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldestinatariologradouro_N));
         n822NotaFiscalDestinatarioLogNum = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldestinatariolognum_N));
         n823NotaFiscalDestinatarioComplemento = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldestinatariocomplemento_N));
         n824NotaFiscalDestinatarioBairro = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldestinatariobairro_N));
         n825NotaFiscalDestinatarioMunicipio = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldestinatariomunicipio_N));
         n826NotaFiscalDestinatarioUF = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldestinatariouf_N));
         n827NotaFiscalDestinatarioCEP = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldestinatariocep_N));
         n828NotaFiscalDestinatarioPais = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldestinatariopais_N));
         n829NotaFiscalDestinatarioFone = (bool)(Convert.ToBoolean(obj93.gxTpr_Notafiscaldestinatariofone_N));
         Gx_mode = obj93.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A794NotaFiscalId = (Guid)getParm(obj,0);
         n794NotaFiscalId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2N93( ) ;
         ScanKeyStart2N93( ) ;
         if ( RcdFound93 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z794NotaFiscalId = A794NotaFiscalId;
         }
         ZM2N93( -14) ;
         OnLoadActions2N93( ) ;
         AddRow2N93( ) ;
         ScanKeyEnd2N93( ) ;
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars93( bcNotaFiscal, 0) ;
         ScanKeyStart2N93( ) ;
         if ( RcdFound93 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z794NotaFiscalId = A794NotaFiscalId;
         }
         ZM2N93( -14) ;
         OnLoadActions2N93( ) ;
         AddRow2N93( ) ;
         ScanKeyEnd2N93( ) ;
         if ( RcdFound93 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2N93( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2N93( ) ;
         }
         else
         {
            if ( RcdFound93 == 1 )
            {
               if ( A794NotaFiscalId != Z794NotaFiscalId )
               {
                  A794NotaFiscalId = Z794NotaFiscalId;
                  n794NotaFiscalId = false;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update2N93( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A794NotaFiscalId != Z794NotaFiscalId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert2N93( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert2N93( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars93( bcNotaFiscal, 1) ;
         SaveImpl( ) ;
         VarsToRow93( bcNotaFiscal) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars93( bcNotaFiscal, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2N93( ) ;
         AfterTrn( ) ;
         VarsToRow93( bcNotaFiscal) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow93( bcNotaFiscal) ;
         }
         else
         {
            SdtNotaFiscal auxBC = new SdtNotaFiscal(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A794NotaFiscalId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcNotaFiscal);
               auxBC.Save();
               bcNotaFiscal.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars93( bcNotaFiscal, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars93( bcNotaFiscal, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2N93( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow93( bcNotaFiscal) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow93( bcNotaFiscal) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars93( bcNotaFiscal, 0) ;
         GetKey2N93( ) ;
         if ( RcdFound93 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A794NotaFiscalId != Z794NotaFiscalId )
            {
               A794NotaFiscalId = Z794NotaFiscalId;
               n794NotaFiscalId = false;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A794NotaFiscalId != Z794NotaFiscalId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("notafiscal_bc",pr_default);
         VarsToRow93( bcNotaFiscal) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcNotaFiscal.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcNotaFiscal.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcNotaFiscal )
         {
            bcNotaFiscal = (SdtNotaFiscal)(sdt);
            if ( StringUtil.StrCmp(bcNotaFiscal.gxTpr_Mode, "") == 0 )
            {
               bcNotaFiscal.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow93( bcNotaFiscal) ;
            }
            else
            {
               RowToVars93( bcNotaFiscal, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcNotaFiscal.gxTpr_Mode, "") == 0 )
            {
               bcNotaFiscal.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars93( bcNotaFiscal, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtNotaFiscal NotaFiscal_BC
      {
         get {
            return bcNotaFiscal ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
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
         pr_default.close(11);
         pr_default.close(12);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z794NotaFiscalId = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         Z796NotaFiscalNatureza = "";
         A796NotaFiscalNatureza = "";
         Z797NotaFiscalMod = "";
         A797NotaFiscalMod = "";
         Z798NotaFiscalSerie = "";
         A798NotaFiscalSerie = "";
         Z799NotaFiscalNumero = "";
         A799NotaFiscalNumero = "";
         Z800NotaFiscalDataEmissao = (DateTime)(DateTime.MinValue);
         A800NotaFiscalDataEmissao = (DateTime)(DateTime.MinValue);
         Z801NotaFiscalDataSaida = (DateTime)(DateTime.MinValue);
         A801NotaFiscalDataSaida = (DateTime)(DateTime.MinValue);
         Z802NotaFiscalTipo = "";
         A802NotaFiscalTipo = "";
         Z803NotaFiscalMunicipio = "";
         A803NotaFiscalMunicipio = "";
         Z804NotaFiscalTipoEmissao = "";
         A804NotaFiscalTipoEmissao = "";
         Z806NotaFiscalFinalidades = "";
         A806NotaFiscalFinalidades = "";
         Z818NotaFiscaEmitentelDocumento = "";
         A818NotaFiscaEmitentelDocumento = "";
         Z808NotaFiscalEmitenteNome = "";
         A808NotaFiscalEmitenteNome = "";
         Z809NotaFiscalEmitenteLogradouro = "";
         A809NotaFiscalEmitenteLogradouro = "";
         Z810NotaFiscalEmitenteLogNum = "";
         A810NotaFiscalEmitenteLogNum = "";
         Z811NotaFiscalEmitenteComplemento = "";
         A811NotaFiscalEmitenteComplemento = "";
         Z812NotaFiscalEmitenteBairro = "";
         A812NotaFiscalEmitenteBairro = "";
         Z813NotaFiscalEmitenteMunicipio = "";
         A813NotaFiscalEmitenteMunicipio = "";
         Z814NotaFiscalEmitenteUF = "";
         A814NotaFiscalEmitenteUF = "";
         Z815NotaFiscalEmitenteCEP = "";
         A815NotaFiscalEmitenteCEP = "";
         Z816NotaFiscalEmitentePais = "";
         A816NotaFiscalEmitentePais = "";
         Z817NotaFiscalEmitenteTelefone = "";
         A817NotaFiscalEmitenteTelefone = "";
         Z819NotaFiscalEmitenteIE = "";
         A819NotaFiscalEmitenteIE = "";
         Z820NotaFiscalDestinatarioDocumento = "";
         A820NotaFiscalDestinatarioDocumento = "";
         Z852NotaFiscalDestinatarioNome = "";
         A852NotaFiscalDestinatarioNome = "";
         Z821NotaFiscalDestinatarioLogradouro = "";
         A821NotaFiscalDestinatarioLogradouro = "";
         Z822NotaFiscalDestinatarioLogNum = "";
         A822NotaFiscalDestinatarioLogNum = "";
         Z823NotaFiscalDestinatarioComplemento = "";
         A823NotaFiscalDestinatarioComplemento = "";
         Z824NotaFiscalDestinatarioBairro = "";
         A824NotaFiscalDestinatarioBairro = "";
         Z825NotaFiscalDestinatarioMunicipio = "";
         A825NotaFiscalDestinatarioMunicipio = "";
         Z826NotaFiscalDestinatarioUF = "";
         A826NotaFiscalDestinatarioUF = "";
         Z827NotaFiscalDestinatarioCEP = "";
         A827NotaFiscalDestinatarioCEP = "";
         Z828NotaFiscalDestinatarioPais = "";
         A828NotaFiscalDestinatarioPais = "";
         Z829NotaFiscalDestinatarioFone = "";
         A829NotaFiscalDestinatarioFone = "";
         Z879NotaFiscalQuantidadeResumo_F = "";
         A879NotaFiscalQuantidadeResumo_F = "";
         Z881NotaFiscalValorFormatado_F = "";
         A881NotaFiscalValorFormatado_F = "";
         Z882NotaFiscalValorVendidoFormatado_F = "";
         A882NotaFiscalValorVendidoFormatado_F = "";
         Z883NotaFiscalSaldoFormatado_F = "";
         A883NotaFiscalSaldoFormatado_F = "";
         Z880NotaFiscalStatus = "";
         A880NotaFiscalStatus = "";
         BC002N7_A874NotaFiscalValorTotal_F = new decimal[1] ;
         BC002N7_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         BC002N9_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         BC002N9_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         BC002N12_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002N12_n794NotaFiscalId = new bool[] {false} ;
         BC002N12_A795NotaFiscalUF = new short[1] ;
         BC002N12_n795NotaFiscalUF = new bool[] {false} ;
         BC002N12_A796NotaFiscalNatureza = new string[] {""} ;
         BC002N12_n796NotaFiscalNatureza = new bool[] {false} ;
         BC002N12_A797NotaFiscalMod = new string[] {""} ;
         BC002N12_n797NotaFiscalMod = new bool[] {false} ;
         BC002N12_A798NotaFiscalSerie = new string[] {""} ;
         BC002N12_n798NotaFiscalSerie = new bool[] {false} ;
         BC002N12_A799NotaFiscalNumero = new string[] {""} ;
         BC002N12_n799NotaFiscalNumero = new bool[] {false} ;
         BC002N12_A800NotaFiscalDataEmissao = new DateTime[] {DateTime.MinValue} ;
         BC002N12_n800NotaFiscalDataEmissao = new bool[] {false} ;
         BC002N12_A801NotaFiscalDataSaida = new DateTime[] {DateTime.MinValue} ;
         BC002N12_n801NotaFiscalDataSaida = new bool[] {false} ;
         BC002N12_A802NotaFiscalTipo = new string[] {""} ;
         BC002N12_n802NotaFiscalTipo = new bool[] {false} ;
         BC002N12_A803NotaFiscalMunicipio = new string[] {""} ;
         BC002N12_n803NotaFiscalMunicipio = new bool[] {false} ;
         BC002N12_A804NotaFiscalTipoEmissao = new string[] {""} ;
         BC002N12_n804NotaFiscalTipoEmissao = new bool[] {false} ;
         BC002N12_A805NotaFiscalAmbiente = new short[1] ;
         BC002N12_n805NotaFiscalAmbiente = new bool[] {false} ;
         BC002N12_A806NotaFiscalFinalidades = new string[] {""} ;
         BC002N12_n806NotaFiscalFinalidades = new bool[] {false} ;
         BC002N12_A818NotaFiscaEmitentelDocumento = new string[] {""} ;
         BC002N12_n818NotaFiscaEmitentelDocumento = new bool[] {false} ;
         BC002N12_A808NotaFiscalEmitenteNome = new string[] {""} ;
         BC002N12_n808NotaFiscalEmitenteNome = new bool[] {false} ;
         BC002N12_A809NotaFiscalEmitenteLogradouro = new string[] {""} ;
         BC002N12_n809NotaFiscalEmitenteLogradouro = new bool[] {false} ;
         BC002N12_A810NotaFiscalEmitenteLogNum = new string[] {""} ;
         BC002N12_n810NotaFiscalEmitenteLogNum = new bool[] {false} ;
         BC002N12_A811NotaFiscalEmitenteComplemento = new string[] {""} ;
         BC002N12_n811NotaFiscalEmitenteComplemento = new bool[] {false} ;
         BC002N12_A812NotaFiscalEmitenteBairro = new string[] {""} ;
         BC002N12_n812NotaFiscalEmitenteBairro = new bool[] {false} ;
         BC002N12_A813NotaFiscalEmitenteMunicipio = new string[] {""} ;
         BC002N12_n813NotaFiscalEmitenteMunicipio = new bool[] {false} ;
         BC002N12_A814NotaFiscalEmitenteUF = new string[] {""} ;
         BC002N12_n814NotaFiscalEmitenteUF = new bool[] {false} ;
         BC002N12_A815NotaFiscalEmitenteCEP = new string[] {""} ;
         BC002N12_n815NotaFiscalEmitenteCEP = new bool[] {false} ;
         BC002N12_A816NotaFiscalEmitentePais = new string[] {""} ;
         BC002N12_n816NotaFiscalEmitentePais = new bool[] {false} ;
         BC002N12_A817NotaFiscalEmitenteTelefone = new string[] {""} ;
         BC002N12_n817NotaFiscalEmitenteTelefone = new bool[] {false} ;
         BC002N12_A819NotaFiscalEmitenteIE = new string[] {""} ;
         BC002N12_n819NotaFiscalEmitenteIE = new bool[] {false} ;
         BC002N12_A820NotaFiscalDestinatarioDocumento = new string[] {""} ;
         BC002N12_n820NotaFiscalDestinatarioDocumento = new bool[] {false} ;
         BC002N12_A852NotaFiscalDestinatarioNome = new string[] {""} ;
         BC002N12_n852NotaFiscalDestinatarioNome = new bool[] {false} ;
         BC002N12_A821NotaFiscalDestinatarioLogradouro = new string[] {""} ;
         BC002N12_n821NotaFiscalDestinatarioLogradouro = new bool[] {false} ;
         BC002N12_A822NotaFiscalDestinatarioLogNum = new string[] {""} ;
         BC002N12_n822NotaFiscalDestinatarioLogNum = new bool[] {false} ;
         BC002N12_A823NotaFiscalDestinatarioComplemento = new string[] {""} ;
         BC002N12_n823NotaFiscalDestinatarioComplemento = new bool[] {false} ;
         BC002N12_A824NotaFiscalDestinatarioBairro = new string[] {""} ;
         BC002N12_n824NotaFiscalDestinatarioBairro = new bool[] {false} ;
         BC002N12_A825NotaFiscalDestinatarioMunicipio = new string[] {""} ;
         BC002N12_n825NotaFiscalDestinatarioMunicipio = new bool[] {false} ;
         BC002N12_A826NotaFiscalDestinatarioUF = new string[] {""} ;
         BC002N12_n826NotaFiscalDestinatarioUF = new bool[] {false} ;
         BC002N12_A827NotaFiscalDestinatarioCEP = new string[] {""} ;
         BC002N12_n827NotaFiscalDestinatarioCEP = new bool[] {false} ;
         BC002N12_A828NotaFiscalDestinatarioPais = new string[] {""} ;
         BC002N12_n828NotaFiscalDestinatarioPais = new bool[] {false} ;
         BC002N12_A829NotaFiscalDestinatarioFone = new string[] {""} ;
         BC002N12_n829NotaFiscalDestinatarioFone = new bool[] {false} ;
         BC002N12_A168ClienteId = new int[1] ;
         BC002N12_n168ClienteId = new bool[] {false} ;
         BC002N12_A889NotaFiscalDestinatarioClienteId = new int[1] ;
         BC002N12_n889NotaFiscalDestinatarioClienteId = new bool[] {false} ;
         BC002N12_A874NotaFiscalValorTotal_F = new decimal[1] ;
         BC002N12_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         BC002N12_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         BC002N12_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         BC002N4_A168ClienteId = new int[1] ;
         BC002N4_n168ClienteId = new bool[] {false} ;
         BC002N5_A889NotaFiscalDestinatarioClienteId = new int[1] ;
         BC002N5_n889NotaFiscalDestinatarioClienteId = new bool[] {false} ;
         BC002N13_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002N13_n794NotaFiscalId = new bool[] {false} ;
         BC002N3_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002N3_n794NotaFiscalId = new bool[] {false} ;
         BC002N3_A795NotaFiscalUF = new short[1] ;
         BC002N3_n795NotaFiscalUF = new bool[] {false} ;
         BC002N3_A796NotaFiscalNatureza = new string[] {""} ;
         BC002N3_n796NotaFiscalNatureza = new bool[] {false} ;
         BC002N3_A797NotaFiscalMod = new string[] {""} ;
         BC002N3_n797NotaFiscalMod = new bool[] {false} ;
         BC002N3_A798NotaFiscalSerie = new string[] {""} ;
         BC002N3_n798NotaFiscalSerie = new bool[] {false} ;
         BC002N3_A799NotaFiscalNumero = new string[] {""} ;
         BC002N3_n799NotaFiscalNumero = new bool[] {false} ;
         BC002N3_A800NotaFiscalDataEmissao = new DateTime[] {DateTime.MinValue} ;
         BC002N3_n800NotaFiscalDataEmissao = new bool[] {false} ;
         BC002N3_A801NotaFiscalDataSaida = new DateTime[] {DateTime.MinValue} ;
         BC002N3_n801NotaFiscalDataSaida = new bool[] {false} ;
         BC002N3_A802NotaFiscalTipo = new string[] {""} ;
         BC002N3_n802NotaFiscalTipo = new bool[] {false} ;
         BC002N3_A803NotaFiscalMunicipio = new string[] {""} ;
         BC002N3_n803NotaFiscalMunicipio = new bool[] {false} ;
         BC002N3_A804NotaFiscalTipoEmissao = new string[] {""} ;
         BC002N3_n804NotaFiscalTipoEmissao = new bool[] {false} ;
         BC002N3_A805NotaFiscalAmbiente = new short[1] ;
         BC002N3_n805NotaFiscalAmbiente = new bool[] {false} ;
         BC002N3_A806NotaFiscalFinalidades = new string[] {""} ;
         BC002N3_n806NotaFiscalFinalidades = new bool[] {false} ;
         BC002N3_A818NotaFiscaEmitentelDocumento = new string[] {""} ;
         BC002N3_n818NotaFiscaEmitentelDocumento = new bool[] {false} ;
         BC002N3_A808NotaFiscalEmitenteNome = new string[] {""} ;
         BC002N3_n808NotaFiscalEmitenteNome = new bool[] {false} ;
         BC002N3_A809NotaFiscalEmitenteLogradouro = new string[] {""} ;
         BC002N3_n809NotaFiscalEmitenteLogradouro = new bool[] {false} ;
         BC002N3_A810NotaFiscalEmitenteLogNum = new string[] {""} ;
         BC002N3_n810NotaFiscalEmitenteLogNum = new bool[] {false} ;
         BC002N3_A811NotaFiscalEmitenteComplemento = new string[] {""} ;
         BC002N3_n811NotaFiscalEmitenteComplemento = new bool[] {false} ;
         BC002N3_A812NotaFiscalEmitenteBairro = new string[] {""} ;
         BC002N3_n812NotaFiscalEmitenteBairro = new bool[] {false} ;
         BC002N3_A813NotaFiscalEmitenteMunicipio = new string[] {""} ;
         BC002N3_n813NotaFiscalEmitenteMunicipio = new bool[] {false} ;
         BC002N3_A814NotaFiscalEmitenteUF = new string[] {""} ;
         BC002N3_n814NotaFiscalEmitenteUF = new bool[] {false} ;
         BC002N3_A815NotaFiscalEmitenteCEP = new string[] {""} ;
         BC002N3_n815NotaFiscalEmitenteCEP = new bool[] {false} ;
         BC002N3_A816NotaFiscalEmitentePais = new string[] {""} ;
         BC002N3_n816NotaFiscalEmitentePais = new bool[] {false} ;
         BC002N3_A817NotaFiscalEmitenteTelefone = new string[] {""} ;
         BC002N3_n817NotaFiscalEmitenteTelefone = new bool[] {false} ;
         BC002N3_A819NotaFiscalEmitenteIE = new string[] {""} ;
         BC002N3_n819NotaFiscalEmitenteIE = new bool[] {false} ;
         BC002N3_A820NotaFiscalDestinatarioDocumento = new string[] {""} ;
         BC002N3_n820NotaFiscalDestinatarioDocumento = new bool[] {false} ;
         BC002N3_A852NotaFiscalDestinatarioNome = new string[] {""} ;
         BC002N3_n852NotaFiscalDestinatarioNome = new bool[] {false} ;
         BC002N3_A821NotaFiscalDestinatarioLogradouro = new string[] {""} ;
         BC002N3_n821NotaFiscalDestinatarioLogradouro = new bool[] {false} ;
         BC002N3_A822NotaFiscalDestinatarioLogNum = new string[] {""} ;
         BC002N3_n822NotaFiscalDestinatarioLogNum = new bool[] {false} ;
         BC002N3_A823NotaFiscalDestinatarioComplemento = new string[] {""} ;
         BC002N3_n823NotaFiscalDestinatarioComplemento = new bool[] {false} ;
         BC002N3_A824NotaFiscalDestinatarioBairro = new string[] {""} ;
         BC002N3_n824NotaFiscalDestinatarioBairro = new bool[] {false} ;
         BC002N3_A825NotaFiscalDestinatarioMunicipio = new string[] {""} ;
         BC002N3_n825NotaFiscalDestinatarioMunicipio = new bool[] {false} ;
         BC002N3_A826NotaFiscalDestinatarioUF = new string[] {""} ;
         BC002N3_n826NotaFiscalDestinatarioUF = new bool[] {false} ;
         BC002N3_A827NotaFiscalDestinatarioCEP = new string[] {""} ;
         BC002N3_n827NotaFiscalDestinatarioCEP = new bool[] {false} ;
         BC002N3_A828NotaFiscalDestinatarioPais = new string[] {""} ;
         BC002N3_n828NotaFiscalDestinatarioPais = new bool[] {false} ;
         BC002N3_A829NotaFiscalDestinatarioFone = new string[] {""} ;
         BC002N3_n829NotaFiscalDestinatarioFone = new bool[] {false} ;
         BC002N3_A168ClienteId = new int[1] ;
         BC002N3_n168ClienteId = new bool[] {false} ;
         BC002N3_A889NotaFiscalDestinatarioClienteId = new int[1] ;
         BC002N3_n889NotaFiscalDestinatarioClienteId = new bool[] {false} ;
         sMode93 = "";
         BC002N2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002N2_n794NotaFiscalId = new bool[] {false} ;
         BC002N2_A795NotaFiscalUF = new short[1] ;
         BC002N2_n795NotaFiscalUF = new bool[] {false} ;
         BC002N2_A796NotaFiscalNatureza = new string[] {""} ;
         BC002N2_n796NotaFiscalNatureza = new bool[] {false} ;
         BC002N2_A797NotaFiscalMod = new string[] {""} ;
         BC002N2_n797NotaFiscalMod = new bool[] {false} ;
         BC002N2_A798NotaFiscalSerie = new string[] {""} ;
         BC002N2_n798NotaFiscalSerie = new bool[] {false} ;
         BC002N2_A799NotaFiscalNumero = new string[] {""} ;
         BC002N2_n799NotaFiscalNumero = new bool[] {false} ;
         BC002N2_A800NotaFiscalDataEmissao = new DateTime[] {DateTime.MinValue} ;
         BC002N2_n800NotaFiscalDataEmissao = new bool[] {false} ;
         BC002N2_A801NotaFiscalDataSaida = new DateTime[] {DateTime.MinValue} ;
         BC002N2_n801NotaFiscalDataSaida = new bool[] {false} ;
         BC002N2_A802NotaFiscalTipo = new string[] {""} ;
         BC002N2_n802NotaFiscalTipo = new bool[] {false} ;
         BC002N2_A803NotaFiscalMunicipio = new string[] {""} ;
         BC002N2_n803NotaFiscalMunicipio = new bool[] {false} ;
         BC002N2_A804NotaFiscalTipoEmissao = new string[] {""} ;
         BC002N2_n804NotaFiscalTipoEmissao = new bool[] {false} ;
         BC002N2_A805NotaFiscalAmbiente = new short[1] ;
         BC002N2_n805NotaFiscalAmbiente = new bool[] {false} ;
         BC002N2_A806NotaFiscalFinalidades = new string[] {""} ;
         BC002N2_n806NotaFiscalFinalidades = new bool[] {false} ;
         BC002N2_A818NotaFiscaEmitentelDocumento = new string[] {""} ;
         BC002N2_n818NotaFiscaEmitentelDocumento = new bool[] {false} ;
         BC002N2_A808NotaFiscalEmitenteNome = new string[] {""} ;
         BC002N2_n808NotaFiscalEmitenteNome = new bool[] {false} ;
         BC002N2_A809NotaFiscalEmitenteLogradouro = new string[] {""} ;
         BC002N2_n809NotaFiscalEmitenteLogradouro = new bool[] {false} ;
         BC002N2_A810NotaFiscalEmitenteLogNum = new string[] {""} ;
         BC002N2_n810NotaFiscalEmitenteLogNum = new bool[] {false} ;
         BC002N2_A811NotaFiscalEmitenteComplemento = new string[] {""} ;
         BC002N2_n811NotaFiscalEmitenteComplemento = new bool[] {false} ;
         BC002N2_A812NotaFiscalEmitenteBairro = new string[] {""} ;
         BC002N2_n812NotaFiscalEmitenteBairro = new bool[] {false} ;
         BC002N2_A813NotaFiscalEmitenteMunicipio = new string[] {""} ;
         BC002N2_n813NotaFiscalEmitenteMunicipio = new bool[] {false} ;
         BC002N2_A814NotaFiscalEmitenteUF = new string[] {""} ;
         BC002N2_n814NotaFiscalEmitenteUF = new bool[] {false} ;
         BC002N2_A815NotaFiscalEmitenteCEP = new string[] {""} ;
         BC002N2_n815NotaFiscalEmitenteCEP = new bool[] {false} ;
         BC002N2_A816NotaFiscalEmitentePais = new string[] {""} ;
         BC002N2_n816NotaFiscalEmitentePais = new bool[] {false} ;
         BC002N2_A817NotaFiscalEmitenteTelefone = new string[] {""} ;
         BC002N2_n817NotaFiscalEmitenteTelefone = new bool[] {false} ;
         BC002N2_A819NotaFiscalEmitenteIE = new string[] {""} ;
         BC002N2_n819NotaFiscalEmitenteIE = new bool[] {false} ;
         BC002N2_A820NotaFiscalDestinatarioDocumento = new string[] {""} ;
         BC002N2_n820NotaFiscalDestinatarioDocumento = new bool[] {false} ;
         BC002N2_A852NotaFiscalDestinatarioNome = new string[] {""} ;
         BC002N2_n852NotaFiscalDestinatarioNome = new bool[] {false} ;
         BC002N2_A821NotaFiscalDestinatarioLogradouro = new string[] {""} ;
         BC002N2_n821NotaFiscalDestinatarioLogradouro = new bool[] {false} ;
         BC002N2_A822NotaFiscalDestinatarioLogNum = new string[] {""} ;
         BC002N2_n822NotaFiscalDestinatarioLogNum = new bool[] {false} ;
         BC002N2_A823NotaFiscalDestinatarioComplemento = new string[] {""} ;
         BC002N2_n823NotaFiscalDestinatarioComplemento = new bool[] {false} ;
         BC002N2_A824NotaFiscalDestinatarioBairro = new string[] {""} ;
         BC002N2_n824NotaFiscalDestinatarioBairro = new bool[] {false} ;
         BC002N2_A825NotaFiscalDestinatarioMunicipio = new string[] {""} ;
         BC002N2_n825NotaFiscalDestinatarioMunicipio = new bool[] {false} ;
         BC002N2_A826NotaFiscalDestinatarioUF = new string[] {""} ;
         BC002N2_n826NotaFiscalDestinatarioUF = new bool[] {false} ;
         BC002N2_A827NotaFiscalDestinatarioCEP = new string[] {""} ;
         BC002N2_n827NotaFiscalDestinatarioCEP = new bool[] {false} ;
         BC002N2_A828NotaFiscalDestinatarioPais = new string[] {""} ;
         BC002N2_n828NotaFiscalDestinatarioPais = new bool[] {false} ;
         BC002N2_A829NotaFiscalDestinatarioFone = new string[] {""} ;
         BC002N2_n829NotaFiscalDestinatarioFone = new bool[] {false} ;
         BC002N2_A168ClienteId = new int[1] ;
         BC002N2_n168ClienteId = new bool[] {false} ;
         BC002N2_A889NotaFiscalDestinatarioClienteId = new int[1] ;
         BC002N2_n889NotaFiscalDestinatarioClienteId = new bool[] {false} ;
         BC002N18_A874NotaFiscalValorTotal_F = new decimal[1] ;
         BC002N18_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         BC002N20_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         BC002N20_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         BC002N21_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         BC002N22_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         BC002N25_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002N25_n794NotaFiscalId = new bool[] {false} ;
         BC002N25_A795NotaFiscalUF = new short[1] ;
         BC002N25_n795NotaFiscalUF = new bool[] {false} ;
         BC002N25_A796NotaFiscalNatureza = new string[] {""} ;
         BC002N25_n796NotaFiscalNatureza = new bool[] {false} ;
         BC002N25_A797NotaFiscalMod = new string[] {""} ;
         BC002N25_n797NotaFiscalMod = new bool[] {false} ;
         BC002N25_A798NotaFiscalSerie = new string[] {""} ;
         BC002N25_n798NotaFiscalSerie = new bool[] {false} ;
         BC002N25_A799NotaFiscalNumero = new string[] {""} ;
         BC002N25_n799NotaFiscalNumero = new bool[] {false} ;
         BC002N25_A800NotaFiscalDataEmissao = new DateTime[] {DateTime.MinValue} ;
         BC002N25_n800NotaFiscalDataEmissao = new bool[] {false} ;
         BC002N25_A801NotaFiscalDataSaida = new DateTime[] {DateTime.MinValue} ;
         BC002N25_n801NotaFiscalDataSaida = new bool[] {false} ;
         BC002N25_A802NotaFiscalTipo = new string[] {""} ;
         BC002N25_n802NotaFiscalTipo = new bool[] {false} ;
         BC002N25_A803NotaFiscalMunicipio = new string[] {""} ;
         BC002N25_n803NotaFiscalMunicipio = new bool[] {false} ;
         BC002N25_A804NotaFiscalTipoEmissao = new string[] {""} ;
         BC002N25_n804NotaFiscalTipoEmissao = new bool[] {false} ;
         BC002N25_A805NotaFiscalAmbiente = new short[1] ;
         BC002N25_n805NotaFiscalAmbiente = new bool[] {false} ;
         BC002N25_A806NotaFiscalFinalidades = new string[] {""} ;
         BC002N25_n806NotaFiscalFinalidades = new bool[] {false} ;
         BC002N25_A818NotaFiscaEmitentelDocumento = new string[] {""} ;
         BC002N25_n818NotaFiscaEmitentelDocumento = new bool[] {false} ;
         BC002N25_A808NotaFiscalEmitenteNome = new string[] {""} ;
         BC002N25_n808NotaFiscalEmitenteNome = new bool[] {false} ;
         BC002N25_A809NotaFiscalEmitenteLogradouro = new string[] {""} ;
         BC002N25_n809NotaFiscalEmitenteLogradouro = new bool[] {false} ;
         BC002N25_A810NotaFiscalEmitenteLogNum = new string[] {""} ;
         BC002N25_n810NotaFiscalEmitenteLogNum = new bool[] {false} ;
         BC002N25_A811NotaFiscalEmitenteComplemento = new string[] {""} ;
         BC002N25_n811NotaFiscalEmitenteComplemento = new bool[] {false} ;
         BC002N25_A812NotaFiscalEmitenteBairro = new string[] {""} ;
         BC002N25_n812NotaFiscalEmitenteBairro = new bool[] {false} ;
         BC002N25_A813NotaFiscalEmitenteMunicipio = new string[] {""} ;
         BC002N25_n813NotaFiscalEmitenteMunicipio = new bool[] {false} ;
         BC002N25_A814NotaFiscalEmitenteUF = new string[] {""} ;
         BC002N25_n814NotaFiscalEmitenteUF = new bool[] {false} ;
         BC002N25_A815NotaFiscalEmitenteCEP = new string[] {""} ;
         BC002N25_n815NotaFiscalEmitenteCEP = new bool[] {false} ;
         BC002N25_A816NotaFiscalEmitentePais = new string[] {""} ;
         BC002N25_n816NotaFiscalEmitentePais = new bool[] {false} ;
         BC002N25_A817NotaFiscalEmitenteTelefone = new string[] {""} ;
         BC002N25_n817NotaFiscalEmitenteTelefone = new bool[] {false} ;
         BC002N25_A819NotaFiscalEmitenteIE = new string[] {""} ;
         BC002N25_n819NotaFiscalEmitenteIE = new bool[] {false} ;
         BC002N25_A820NotaFiscalDestinatarioDocumento = new string[] {""} ;
         BC002N25_n820NotaFiscalDestinatarioDocumento = new bool[] {false} ;
         BC002N25_A852NotaFiscalDestinatarioNome = new string[] {""} ;
         BC002N25_n852NotaFiscalDestinatarioNome = new bool[] {false} ;
         BC002N25_A821NotaFiscalDestinatarioLogradouro = new string[] {""} ;
         BC002N25_n821NotaFiscalDestinatarioLogradouro = new bool[] {false} ;
         BC002N25_A822NotaFiscalDestinatarioLogNum = new string[] {""} ;
         BC002N25_n822NotaFiscalDestinatarioLogNum = new bool[] {false} ;
         BC002N25_A823NotaFiscalDestinatarioComplemento = new string[] {""} ;
         BC002N25_n823NotaFiscalDestinatarioComplemento = new bool[] {false} ;
         BC002N25_A824NotaFiscalDestinatarioBairro = new string[] {""} ;
         BC002N25_n824NotaFiscalDestinatarioBairro = new bool[] {false} ;
         BC002N25_A825NotaFiscalDestinatarioMunicipio = new string[] {""} ;
         BC002N25_n825NotaFiscalDestinatarioMunicipio = new bool[] {false} ;
         BC002N25_A826NotaFiscalDestinatarioUF = new string[] {""} ;
         BC002N25_n826NotaFiscalDestinatarioUF = new bool[] {false} ;
         BC002N25_A827NotaFiscalDestinatarioCEP = new string[] {""} ;
         BC002N25_n827NotaFiscalDestinatarioCEP = new bool[] {false} ;
         BC002N25_A828NotaFiscalDestinatarioPais = new string[] {""} ;
         BC002N25_n828NotaFiscalDestinatarioPais = new bool[] {false} ;
         BC002N25_A829NotaFiscalDestinatarioFone = new string[] {""} ;
         BC002N25_n829NotaFiscalDestinatarioFone = new bool[] {false} ;
         BC002N25_A168ClienteId = new int[1] ;
         BC002N25_n168ClienteId = new bool[] {false} ;
         BC002N25_A889NotaFiscalDestinatarioClienteId = new int[1] ;
         BC002N25_n889NotaFiscalDestinatarioClienteId = new bool[] {false} ;
         BC002N25_A874NotaFiscalValorTotal_F = new decimal[1] ;
         BC002N25_A875NotaFiscalValorTotalVendido_F = new decimal[1] ;
         BC002N25_A877NotaFiscalQuantidadeDeItens_F = new short[1] ;
         BC002N25_A878NotaFiscalQuantidadeDeItensVendidos_F = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscal_bc__default(),
            new Object[][] {
                new Object[] {
               BC002N2_A794NotaFiscalId, BC002N2_A795NotaFiscalUF, BC002N2_n795NotaFiscalUF, BC002N2_A796NotaFiscalNatureza, BC002N2_n796NotaFiscalNatureza, BC002N2_A797NotaFiscalMod, BC002N2_n797NotaFiscalMod, BC002N2_A798NotaFiscalSerie, BC002N2_n798NotaFiscalSerie, BC002N2_A799NotaFiscalNumero,
               BC002N2_n799NotaFiscalNumero, BC002N2_A800NotaFiscalDataEmissao, BC002N2_n800NotaFiscalDataEmissao, BC002N2_A801NotaFiscalDataSaida, BC002N2_n801NotaFiscalDataSaida, BC002N2_A802NotaFiscalTipo, BC002N2_n802NotaFiscalTipo, BC002N2_A803NotaFiscalMunicipio, BC002N2_n803NotaFiscalMunicipio, BC002N2_A804NotaFiscalTipoEmissao,
               BC002N2_n804NotaFiscalTipoEmissao, BC002N2_A805NotaFiscalAmbiente, BC002N2_n805NotaFiscalAmbiente, BC002N2_A806NotaFiscalFinalidades, BC002N2_n806NotaFiscalFinalidades, BC002N2_A818NotaFiscaEmitentelDocumento, BC002N2_n818NotaFiscaEmitentelDocumento, BC002N2_A808NotaFiscalEmitenteNome, BC002N2_n808NotaFiscalEmitenteNome, BC002N2_A809NotaFiscalEmitenteLogradouro,
               BC002N2_n809NotaFiscalEmitenteLogradouro, BC002N2_A810NotaFiscalEmitenteLogNum, BC002N2_n810NotaFiscalEmitenteLogNum, BC002N2_A811NotaFiscalEmitenteComplemento, BC002N2_n811NotaFiscalEmitenteComplemento, BC002N2_A812NotaFiscalEmitenteBairro, BC002N2_n812NotaFiscalEmitenteBairro, BC002N2_A813NotaFiscalEmitenteMunicipio, BC002N2_n813NotaFiscalEmitenteMunicipio, BC002N2_A814NotaFiscalEmitenteUF,
               BC002N2_n814NotaFiscalEmitenteUF, BC002N2_A815NotaFiscalEmitenteCEP, BC002N2_n815NotaFiscalEmitenteCEP, BC002N2_A816NotaFiscalEmitentePais, BC002N2_n816NotaFiscalEmitentePais, BC002N2_A817NotaFiscalEmitenteTelefone, BC002N2_n817NotaFiscalEmitenteTelefone, BC002N2_A819NotaFiscalEmitenteIE, BC002N2_n819NotaFiscalEmitenteIE, BC002N2_A820NotaFiscalDestinatarioDocumento,
               BC002N2_n820NotaFiscalDestinatarioDocumento, BC002N2_A852NotaFiscalDestinatarioNome, BC002N2_n852NotaFiscalDestinatarioNome, BC002N2_A821NotaFiscalDestinatarioLogradouro, BC002N2_n821NotaFiscalDestinatarioLogradouro, BC002N2_A822NotaFiscalDestinatarioLogNum, BC002N2_n822NotaFiscalDestinatarioLogNum, BC002N2_A823NotaFiscalDestinatarioComplemento, BC002N2_n823NotaFiscalDestinatarioComplemento, BC002N2_A824NotaFiscalDestinatarioBairro,
               BC002N2_n824NotaFiscalDestinatarioBairro, BC002N2_A825NotaFiscalDestinatarioMunicipio, BC002N2_n825NotaFiscalDestinatarioMunicipio, BC002N2_A826NotaFiscalDestinatarioUF, BC002N2_n826NotaFiscalDestinatarioUF, BC002N2_A827NotaFiscalDestinatarioCEP, BC002N2_n827NotaFiscalDestinatarioCEP, BC002N2_A828NotaFiscalDestinatarioPais, BC002N2_n828NotaFiscalDestinatarioPais, BC002N2_A829NotaFiscalDestinatarioFone,
               BC002N2_n829NotaFiscalDestinatarioFone, BC002N2_A168ClienteId, BC002N2_n168ClienteId, BC002N2_A889NotaFiscalDestinatarioClienteId, BC002N2_n889NotaFiscalDestinatarioClienteId
               }
               , new Object[] {
               BC002N3_A794NotaFiscalId, BC002N3_A795NotaFiscalUF, BC002N3_n795NotaFiscalUF, BC002N3_A796NotaFiscalNatureza, BC002N3_n796NotaFiscalNatureza, BC002N3_A797NotaFiscalMod, BC002N3_n797NotaFiscalMod, BC002N3_A798NotaFiscalSerie, BC002N3_n798NotaFiscalSerie, BC002N3_A799NotaFiscalNumero,
               BC002N3_n799NotaFiscalNumero, BC002N3_A800NotaFiscalDataEmissao, BC002N3_n800NotaFiscalDataEmissao, BC002N3_A801NotaFiscalDataSaida, BC002N3_n801NotaFiscalDataSaida, BC002N3_A802NotaFiscalTipo, BC002N3_n802NotaFiscalTipo, BC002N3_A803NotaFiscalMunicipio, BC002N3_n803NotaFiscalMunicipio, BC002N3_A804NotaFiscalTipoEmissao,
               BC002N3_n804NotaFiscalTipoEmissao, BC002N3_A805NotaFiscalAmbiente, BC002N3_n805NotaFiscalAmbiente, BC002N3_A806NotaFiscalFinalidades, BC002N3_n806NotaFiscalFinalidades, BC002N3_A818NotaFiscaEmitentelDocumento, BC002N3_n818NotaFiscaEmitentelDocumento, BC002N3_A808NotaFiscalEmitenteNome, BC002N3_n808NotaFiscalEmitenteNome, BC002N3_A809NotaFiscalEmitenteLogradouro,
               BC002N3_n809NotaFiscalEmitenteLogradouro, BC002N3_A810NotaFiscalEmitenteLogNum, BC002N3_n810NotaFiscalEmitenteLogNum, BC002N3_A811NotaFiscalEmitenteComplemento, BC002N3_n811NotaFiscalEmitenteComplemento, BC002N3_A812NotaFiscalEmitenteBairro, BC002N3_n812NotaFiscalEmitenteBairro, BC002N3_A813NotaFiscalEmitenteMunicipio, BC002N3_n813NotaFiscalEmitenteMunicipio, BC002N3_A814NotaFiscalEmitenteUF,
               BC002N3_n814NotaFiscalEmitenteUF, BC002N3_A815NotaFiscalEmitenteCEP, BC002N3_n815NotaFiscalEmitenteCEP, BC002N3_A816NotaFiscalEmitentePais, BC002N3_n816NotaFiscalEmitentePais, BC002N3_A817NotaFiscalEmitenteTelefone, BC002N3_n817NotaFiscalEmitenteTelefone, BC002N3_A819NotaFiscalEmitenteIE, BC002N3_n819NotaFiscalEmitenteIE, BC002N3_A820NotaFiscalDestinatarioDocumento,
               BC002N3_n820NotaFiscalDestinatarioDocumento, BC002N3_A852NotaFiscalDestinatarioNome, BC002N3_n852NotaFiscalDestinatarioNome, BC002N3_A821NotaFiscalDestinatarioLogradouro, BC002N3_n821NotaFiscalDestinatarioLogradouro, BC002N3_A822NotaFiscalDestinatarioLogNum, BC002N3_n822NotaFiscalDestinatarioLogNum, BC002N3_A823NotaFiscalDestinatarioComplemento, BC002N3_n823NotaFiscalDestinatarioComplemento, BC002N3_A824NotaFiscalDestinatarioBairro,
               BC002N3_n824NotaFiscalDestinatarioBairro, BC002N3_A825NotaFiscalDestinatarioMunicipio, BC002N3_n825NotaFiscalDestinatarioMunicipio, BC002N3_A826NotaFiscalDestinatarioUF, BC002N3_n826NotaFiscalDestinatarioUF, BC002N3_A827NotaFiscalDestinatarioCEP, BC002N3_n827NotaFiscalDestinatarioCEP, BC002N3_A828NotaFiscalDestinatarioPais, BC002N3_n828NotaFiscalDestinatarioPais, BC002N3_A829NotaFiscalDestinatarioFone,
               BC002N3_n829NotaFiscalDestinatarioFone, BC002N3_A168ClienteId, BC002N3_n168ClienteId, BC002N3_A889NotaFiscalDestinatarioClienteId, BC002N3_n889NotaFiscalDestinatarioClienteId
               }
               , new Object[] {
               BC002N4_A168ClienteId
               }
               , new Object[] {
               BC002N5_A889NotaFiscalDestinatarioClienteId
               }
               , new Object[] {
               BC002N7_A874NotaFiscalValorTotal_F, BC002N7_A877NotaFiscalQuantidadeDeItens_F
               }
               , new Object[] {
               BC002N9_A875NotaFiscalValorTotalVendido_F, BC002N9_A878NotaFiscalQuantidadeDeItensVendidos_F
               }
               , new Object[] {
               BC002N12_A794NotaFiscalId, BC002N12_A795NotaFiscalUF, BC002N12_n795NotaFiscalUF, BC002N12_A796NotaFiscalNatureza, BC002N12_n796NotaFiscalNatureza, BC002N12_A797NotaFiscalMod, BC002N12_n797NotaFiscalMod, BC002N12_A798NotaFiscalSerie, BC002N12_n798NotaFiscalSerie, BC002N12_A799NotaFiscalNumero,
               BC002N12_n799NotaFiscalNumero, BC002N12_A800NotaFiscalDataEmissao, BC002N12_n800NotaFiscalDataEmissao, BC002N12_A801NotaFiscalDataSaida, BC002N12_n801NotaFiscalDataSaida, BC002N12_A802NotaFiscalTipo, BC002N12_n802NotaFiscalTipo, BC002N12_A803NotaFiscalMunicipio, BC002N12_n803NotaFiscalMunicipio, BC002N12_A804NotaFiscalTipoEmissao,
               BC002N12_n804NotaFiscalTipoEmissao, BC002N12_A805NotaFiscalAmbiente, BC002N12_n805NotaFiscalAmbiente, BC002N12_A806NotaFiscalFinalidades, BC002N12_n806NotaFiscalFinalidades, BC002N12_A818NotaFiscaEmitentelDocumento, BC002N12_n818NotaFiscaEmitentelDocumento, BC002N12_A808NotaFiscalEmitenteNome, BC002N12_n808NotaFiscalEmitenteNome, BC002N12_A809NotaFiscalEmitenteLogradouro,
               BC002N12_n809NotaFiscalEmitenteLogradouro, BC002N12_A810NotaFiscalEmitenteLogNum, BC002N12_n810NotaFiscalEmitenteLogNum, BC002N12_A811NotaFiscalEmitenteComplemento, BC002N12_n811NotaFiscalEmitenteComplemento, BC002N12_A812NotaFiscalEmitenteBairro, BC002N12_n812NotaFiscalEmitenteBairro, BC002N12_A813NotaFiscalEmitenteMunicipio, BC002N12_n813NotaFiscalEmitenteMunicipio, BC002N12_A814NotaFiscalEmitenteUF,
               BC002N12_n814NotaFiscalEmitenteUF, BC002N12_A815NotaFiscalEmitenteCEP, BC002N12_n815NotaFiscalEmitenteCEP, BC002N12_A816NotaFiscalEmitentePais, BC002N12_n816NotaFiscalEmitentePais, BC002N12_A817NotaFiscalEmitenteTelefone, BC002N12_n817NotaFiscalEmitenteTelefone, BC002N12_A819NotaFiscalEmitenteIE, BC002N12_n819NotaFiscalEmitenteIE, BC002N12_A820NotaFiscalDestinatarioDocumento,
               BC002N12_n820NotaFiscalDestinatarioDocumento, BC002N12_A852NotaFiscalDestinatarioNome, BC002N12_n852NotaFiscalDestinatarioNome, BC002N12_A821NotaFiscalDestinatarioLogradouro, BC002N12_n821NotaFiscalDestinatarioLogradouro, BC002N12_A822NotaFiscalDestinatarioLogNum, BC002N12_n822NotaFiscalDestinatarioLogNum, BC002N12_A823NotaFiscalDestinatarioComplemento, BC002N12_n823NotaFiscalDestinatarioComplemento, BC002N12_A824NotaFiscalDestinatarioBairro,
               BC002N12_n824NotaFiscalDestinatarioBairro, BC002N12_A825NotaFiscalDestinatarioMunicipio, BC002N12_n825NotaFiscalDestinatarioMunicipio, BC002N12_A826NotaFiscalDestinatarioUF, BC002N12_n826NotaFiscalDestinatarioUF, BC002N12_A827NotaFiscalDestinatarioCEP, BC002N12_n827NotaFiscalDestinatarioCEP, BC002N12_A828NotaFiscalDestinatarioPais, BC002N12_n828NotaFiscalDestinatarioPais, BC002N12_A829NotaFiscalDestinatarioFone,
               BC002N12_n829NotaFiscalDestinatarioFone, BC002N12_A168ClienteId, BC002N12_n168ClienteId, BC002N12_A889NotaFiscalDestinatarioClienteId, BC002N12_n889NotaFiscalDestinatarioClienteId, BC002N12_A874NotaFiscalValorTotal_F, BC002N12_A875NotaFiscalValorTotalVendido_F, BC002N12_A877NotaFiscalQuantidadeDeItens_F, BC002N12_A878NotaFiscalQuantidadeDeItensVendidos_F
               }
               , new Object[] {
               BC002N13_A794NotaFiscalId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002N18_A874NotaFiscalValorTotal_F, BC002N18_A877NotaFiscalQuantidadeDeItens_F
               }
               , new Object[] {
               BC002N20_A875NotaFiscalValorTotalVendido_F, BC002N20_A878NotaFiscalQuantidadeDeItensVendidos_F
               }
               , new Object[] {
               BC002N21_A890NotaFiscalParcelamentoID
               }
               , new Object[] {
               BC002N22_A830NotaFiscalItemId
               }
               , new Object[] {
               BC002N25_A794NotaFiscalId, BC002N25_A795NotaFiscalUF, BC002N25_n795NotaFiscalUF, BC002N25_A796NotaFiscalNatureza, BC002N25_n796NotaFiscalNatureza, BC002N25_A797NotaFiscalMod, BC002N25_n797NotaFiscalMod, BC002N25_A798NotaFiscalSerie, BC002N25_n798NotaFiscalSerie, BC002N25_A799NotaFiscalNumero,
               BC002N25_n799NotaFiscalNumero, BC002N25_A800NotaFiscalDataEmissao, BC002N25_n800NotaFiscalDataEmissao, BC002N25_A801NotaFiscalDataSaida, BC002N25_n801NotaFiscalDataSaida, BC002N25_A802NotaFiscalTipo, BC002N25_n802NotaFiscalTipo, BC002N25_A803NotaFiscalMunicipio, BC002N25_n803NotaFiscalMunicipio, BC002N25_A804NotaFiscalTipoEmissao,
               BC002N25_n804NotaFiscalTipoEmissao, BC002N25_A805NotaFiscalAmbiente, BC002N25_n805NotaFiscalAmbiente, BC002N25_A806NotaFiscalFinalidades, BC002N25_n806NotaFiscalFinalidades, BC002N25_A818NotaFiscaEmitentelDocumento, BC002N25_n818NotaFiscaEmitentelDocumento, BC002N25_A808NotaFiscalEmitenteNome, BC002N25_n808NotaFiscalEmitenteNome, BC002N25_A809NotaFiscalEmitenteLogradouro,
               BC002N25_n809NotaFiscalEmitenteLogradouro, BC002N25_A810NotaFiscalEmitenteLogNum, BC002N25_n810NotaFiscalEmitenteLogNum, BC002N25_A811NotaFiscalEmitenteComplemento, BC002N25_n811NotaFiscalEmitenteComplemento, BC002N25_A812NotaFiscalEmitenteBairro, BC002N25_n812NotaFiscalEmitenteBairro, BC002N25_A813NotaFiscalEmitenteMunicipio, BC002N25_n813NotaFiscalEmitenteMunicipio, BC002N25_A814NotaFiscalEmitenteUF,
               BC002N25_n814NotaFiscalEmitenteUF, BC002N25_A815NotaFiscalEmitenteCEP, BC002N25_n815NotaFiscalEmitenteCEP, BC002N25_A816NotaFiscalEmitentePais, BC002N25_n816NotaFiscalEmitentePais, BC002N25_A817NotaFiscalEmitenteTelefone, BC002N25_n817NotaFiscalEmitenteTelefone, BC002N25_A819NotaFiscalEmitenteIE, BC002N25_n819NotaFiscalEmitenteIE, BC002N25_A820NotaFiscalDestinatarioDocumento,
               BC002N25_n820NotaFiscalDestinatarioDocumento, BC002N25_A852NotaFiscalDestinatarioNome, BC002N25_n852NotaFiscalDestinatarioNome, BC002N25_A821NotaFiscalDestinatarioLogradouro, BC002N25_n821NotaFiscalDestinatarioLogradouro, BC002N25_A822NotaFiscalDestinatarioLogNum, BC002N25_n822NotaFiscalDestinatarioLogNum, BC002N25_A823NotaFiscalDestinatarioComplemento, BC002N25_n823NotaFiscalDestinatarioComplemento, BC002N25_A824NotaFiscalDestinatarioBairro,
               BC002N25_n824NotaFiscalDestinatarioBairro, BC002N25_A825NotaFiscalDestinatarioMunicipio, BC002N25_n825NotaFiscalDestinatarioMunicipio, BC002N25_A826NotaFiscalDestinatarioUF, BC002N25_n826NotaFiscalDestinatarioUF, BC002N25_A827NotaFiscalDestinatarioCEP, BC002N25_n827NotaFiscalDestinatarioCEP, BC002N25_A828NotaFiscalDestinatarioPais, BC002N25_n828NotaFiscalDestinatarioPais, BC002N25_A829NotaFiscalDestinatarioFone,
               BC002N25_n829NotaFiscalDestinatarioFone, BC002N25_A168ClienteId, BC002N25_n168ClienteId, BC002N25_A889NotaFiscalDestinatarioClienteId, BC002N25_n889NotaFiscalDestinatarioClienteId, BC002N25_A874NotaFiscalValorTotal_F, BC002N25_A875NotaFiscalValorTotalVendido_F, BC002N25_A877NotaFiscalQuantidadeDeItens_F, BC002N25_A878NotaFiscalQuantidadeDeItensVendidos_F
               }
            }
         );
         Z794NotaFiscalId = Guid.NewGuid( );
         n794NotaFiscalId = false;
         A794NotaFiscalId = Guid.NewGuid( );
         n794NotaFiscalId = false;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z795NotaFiscalUF ;
      private short A795NotaFiscalUF ;
      private short Z805NotaFiscalAmbiente ;
      private short A805NotaFiscalAmbiente ;
      private short Z877NotaFiscalQuantidadeDeItens_F ;
      private short A877NotaFiscalQuantidadeDeItens_F ;
      private short Z878NotaFiscalQuantidadeDeItensVendidos_F ;
      private short A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private short Gx_BScreen ;
      private short RcdFound93 ;
      private int trnEnded ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private int Z889NotaFiscalDestinatarioClienteId ;
      private int A889NotaFiscalDestinatarioClienteId ;
      private decimal Z874NotaFiscalValorTotal_F ;
      private decimal A874NotaFiscalValorTotal_F ;
      private decimal Z875NotaFiscalValorTotalVendido_F ;
      private decimal A875NotaFiscalValorTotalVendido_F ;
      private decimal Z876NotaFiscalSaldo_F ;
      private decimal A876NotaFiscalSaldo_F ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode93 ;
      private DateTime Z800NotaFiscalDataEmissao ;
      private DateTime A800NotaFiscalDataEmissao ;
      private DateTime Z801NotaFiscalDataSaida ;
      private DateTime A801NotaFiscalDataSaida ;
      private bool n794NotaFiscalId ;
      private bool n795NotaFiscalUF ;
      private bool n796NotaFiscalNatureza ;
      private bool n797NotaFiscalMod ;
      private bool n798NotaFiscalSerie ;
      private bool n799NotaFiscalNumero ;
      private bool n800NotaFiscalDataEmissao ;
      private bool n801NotaFiscalDataSaida ;
      private bool n802NotaFiscalTipo ;
      private bool n803NotaFiscalMunicipio ;
      private bool n804NotaFiscalTipoEmissao ;
      private bool n805NotaFiscalAmbiente ;
      private bool n806NotaFiscalFinalidades ;
      private bool n818NotaFiscaEmitentelDocumento ;
      private bool n808NotaFiscalEmitenteNome ;
      private bool n809NotaFiscalEmitenteLogradouro ;
      private bool n810NotaFiscalEmitenteLogNum ;
      private bool n811NotaFiscalEmitenteComplemento ;
      private bool n812NotaFiscalEmitenteBairro ;
      private bool n813NotaFiscalEmitenteMunicipio ;
      private bool n814NotaFiscalEmitenteUF ;
      private bool n815NotaFiscalEmitenteCEP ;
      private bool n816NotaFiscalEmitentePais ;
      private bool n817NotaFiscalEmitenteTelefone ;
      private bool n819NotaFiscalEmitenteIE ;
      private bool n820NotaFiscalDestinatarioDocumento ;
      private bool n852NotaFiscalDestinatarioNome ;
      private bool n821NotaFiscalDestinatarioLogradouro ;
      private bool n822NotaFiscalDestinatarioLogNum ;
      private bool n823NotaFiscalDestinatarioComplemento ;
      private bool n824NotaFiscalDestinatarioBairro ;
      private bool n825NotaFiscalDestinatarioMunicipio ;
      private bool n826NotaFiscalDestinatarioUF ;
      private bool n827NotaFiscalDestinatarioCEP ;
      private bool n828NotaFiscalDestinatarioPais ;
      private bool n829NotaFiscalDestinatarioFone ;
      private bool n168ClienteId ;
      private bool n889NotaFiscalDestinatarioClienteId ;
      private bool Gx_longc ;
      private string Z796NotaFiscalNatureza ;
      private string A796NotaFiscalNatureza ;
      private string Z797NotaFiscalMod ;
      private string A797NotaFiscalMod ;
      private string Z798NotaFiscalSerie ;
      private string A798NotaFiscalSerie ;
      private string Z799NotaFiscalNumero ;
      private string A799NotaFiscalNumero ;
      private string Z802NotaFiscalTipo ;
      private string A802NotaFiscalTipo ;
      private string Z803NotaFiscalMunicipio ;
      private string A803NotaFiscalMunicipio ;
      private string Z804NotaFiscalTipoEmissao ;
      private string A804NotaFiscalTipoEmissao ;
      private string Z806NotaFiscalFinalidades ;
      private string A806NotaFiscalFinalidades ;
      private string Z818NotaFiscaEmitentelDocumento ;
      private string A818NotaFiscaEmitentelDocumento ;
      private string Z808NotaFiscalEmitenteNome ;
      private string A808NotaFiscalEmitenteNome ;
      private string Z809NotaFiscalEmitenteLogradouro ;
      private string A809NotaFiscalEmitenteLogradouro ;
      private string Z810NotaFiscalEmitenteLogNum ;
      private string A810NotaFiscalEmitenteLogNum ;
      private string Z811NotaFiscalEmitenteComplemento ;
      private string A811NotaFiscalEmitenteComplemento ;
      private string Z812NotaFiscalEmitenteBairro ;
      private string A812NotaFiscalEmitenteBairro ;
      private string Z813NotaFiscalEmitenteMunicipio ;
      private string A813NotaFiscalEmitenteMunicipio ;
      private string Z814NotaFiscalEmitenteUF ;
      private string A814NotaFiscalEmitenteUF ;
      private string Z815NotaFiscalEmitenteCEP ;
      private string A815NotaFiscalEmitenteCEP ;
      private string Z816NotaFiscalEmitentePais ;
      private string A816NotaFiscalEmitentePais ;
      private string Z817NotaFiscalEmitenteTelefone ;
      private string A817NotaFiscalEmitenteTelefone ;
      private string Z819NotaFiscalEmitenteIE ;
      private string A819NotaFiscalEmitenteIE ;
      private string Z820NotaFiscalDestinatarioDocumento ;
      private string A820NotaFiscalDestinatarioDocumento ;
      private string Z852NotaFiscalDestinatarioNome ;
      private string A852NotaFiscalDestinatarioNome ;
      private string Z821NotaFiscalDestinatarioLogradouro ;
      private string A821NotaFiscalDestinatarioLogradouro ;
      private string Z822NotaFiscalDestinatarioLogNum ;
      private string A822NotaFiscalDestinatarioLogNum ;
      private string Z823NotaFiscalDestinatarioComplemento ;
      private string A823NotaFiscalDestinatarioComplemento ;
      private string Z824NotaFiscalDestinatarioBairro ;
      private string A824NotaFiscalDestinatarioBairro ;
      private string Z825NotaFiscalDestinatarioMunicipio ;
      private string A825NotaFiscalDestinatarioMunicipio ;
      private string Z826NotaFiscalDestinatarioUF ;
      private string A826NotaFiscalDestinatarioUF ;
      private string Z827NotaFiscalDestinatarioCEP ;
      private string A827NotaFiscalDestinatarioCEP ;
      private string Z828NotaFiscalDestinatarioPais ;
      private string A828NotaFiscalDestinatarioPais ;
      private string Z829NotaFiscalDestinatarioFone ;
      private string A829NotaFiscalDestinatarioFone ;
      private string Z879NotaFiscalQuantidadeResumo_F ;
      private string A879NotaFiscalQuantidadeResumo_F ;
      private string Z881NotaFiscalValorFormatado_F ;
      private string A881NotaFiscalValorFormatado_F ;
      private string Z882NotaFiscalValorVendidoFormatado_F ;
      private string A882NotaFiscalValorVendidoFormatado_F ;
      private string Z883NotaFiscalSaldoFormatado_F ;
      private string A883NotaFiscalSaldoFormatado_F ;
      private string Z880NotaFiscalStatus ;
      private string A880NotaFiscalStatus ;
      private Guid Z794NotaFiscalId ;
      private Guid A794NotaFiscalId ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] BC002N7_A874NotaFiscalValorTotal_F ;
      private short[] BC002N7_A877NotaFiscalQuantidadeDeItens_F ;
      private decimal[] BC002N9_A875NotaFiscalValorTotalVendido_F ;
      private short[] BC002N9_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private Guid[] BC002N12_A794NotaFiscalId ;
      private bool[] BC002N12_n794NotaFiscalId ;
      private short[] BC002N12_A795NotaFiscalUF ;
      private bool[] BC002N12_n795NotaFiscalUF ;
      private string[] BC002N12_A796NotaFiscalNatureza ;
      private bool[] BC002N12_n796NotaFiscalNatureza ;
      private string[] BC002N12_A797NotaFiscalMod ;
      private bool[] BC002N12_n797NotaFiscalMod ;
      private string[] BC002N12_A798NotaFiscalSerie ;
      private bool[] BC002N12_n798NotaFiscalSerie ;
      private string[] BC002N12_A799NotaFiscalNumero ;
      private bool[] BC002N12_n799NotaFiscalNumero ;
      private DateTime[] BC002N12_A800NotaFiscalDataEmissao ;
      private bool[] BC002N12_n800NotaFiscalDataEmissao ;
      private DateTime[] BC002N12_A801NotaFiscalDataSaida ;
      private bool[] BC002N12_n801NotaFiscalDataSaida ;
      private string[] BC002N12_A802NotaFiscalTipo ;
      private bool[] BC002N12_n802NotaFiscalTipo ;
      private string[] BC002N12_A803NotaFiscalMunicipio ;
      private bool[] BC002N12_n803NotaFiscalMunicipio ;
      private string[] BC002N12_A804NotaFiscalTipoEmissao ;
      private bool[] BC002N12_n804NotaFiscalTipoEmissao ;
      private short[] BC002N12_A805NotaFiscalAmbiente ;
      private bool[] BC002N12_n805NotaFiscalAmbiente ;
      private string[] BC002N12_A806NotaFiscalFinalidades ;
      private bool[] BC002N12_n806NotaFiscalFinalidades ;
      private string[] BC002N12_A818NotaFiscaEmitentelDocumento ;
      private bool[] BC002N12_n818NotaFiscaEmitentelDocumento ;
      private string[] BC002N12_A808NotaFiscalEmitenteNome ;
      private bool[] BC002N12_n808NotaFiscalEmitenteNome ;
      private string[] BC002N12_A809NotaFiscalEmitenteLogradouro ;
      private bool[] BC002N12_n809NotaFiscalEmitenteLogradouro ;
      private string[] BC002N12_A810NotaFiscalEmitenteLogNum ;
      private bool[] BC002N12_n810NotaFiscalEmitenteLogNum ;
      private string[] BC002N12_A811NotaFiscalEmitenteComplemento ;
      private bool[] BC002N12_n811NotaFiscalEmitenteComplemento ;
      private string[] BC002N12_A812NotaFiscalEmitenteBairro ;
      private bool[] BC002N12_n812NotaFiscalEmitenteBairro ;
      private string[] BC002N12_A813NotaFiscalEmitenteMunicipio ;
      private bool[] BC002N12_n813NotaFiscalEmitenteMunicipio ;
      private string[] BC002N12_A814NotaFiscalEmitenteUF ;
      private bool[] BC002N12_n814NotaFiscalEmitenteUF ;
      private string[] BC002N12_A815NotaFiscalEmitenteCEP ;
      private bool[] BC002N12_n815NotaFiscalEmitenteCEP ;
      private string[] BC002N12_A816NotaFiscalEmitentePais ;
      private bool[] BC002N12_n816NotaFiscalEmitentePais ;
      private string[] BC002N12_A817NotaFiscalEmitenteTelefone ;
      private bool[] BC002N12_n817NotaFiscalEmitenteTelefone ;
      private string[] BC002N12_A819NotaFiscalEmitenteIE ;
      private bool[] BC002N12_n819NotaFiscalEmitenteIE ;
      private string[] BC002N12_A820NotaFiscalDestinatarioDocumento ;
      private bool[] BC002N12_n820NotaFiscalDestinatarioDocumento ;
      private string[] BC002N12_A852NotaFiscalDestinatarioNome ;
      private bool[] BC002N12_n852NotaFiscalDestinatarioNome ;
      private string[] BC002N12_A821NotaFiscalDestinatarioLogradouro ;
      private bool[] BC002N12_n821NotaFiscalDestinatarioLogradouro ;
      private string[] BC002N12_A822NotaFiscalDestinatarioLogNum ;
      private bool[] BC002N12_n822NotaFiscalDestinatarioLogNum ;
      private string[] BC002N12_A823NotaFiscalDestinatarioComplemento ;
      private bool[] BC002N12_n823NotaFiscalDestinatarioComplemento ;
      private string[] BC002N12_A824NotaFiscalDestinatarioBairro ;
      private bool[] BC002N12_n824NotaFiscalDestinatarioBairro ;
      private string[] BC002N12_A825NotaFiscalDestinatarioMunicipio ;
      private bool[] BC002N12_n825NotaFiscalDestinatarioMunicipio ;
      private string[] BC002N12_A826NotaFiscalDestinatarioUF ;
      private bool[] BC002N12_n826NotaFiscalDestinatarioUF ;
      private string[] BC002N12_A827NotaFiscalDestinatarioCEP ;
      private bool[] BC002N12_n827NotaFiscalDestinatarioCEP ;
      private string[] BC002N12_A828NotaFiscalDestinatarioPais ;
      private bool[] BC002N12_n828NotaFiscalDestinatarioPais ;
      private string[] BC002N12_A829NotaFiscalDestinatarioFone ;
      private bool[] BC002N12_n829NotaFiscalDestinatarioFone ;
      private int[] BC002N12_A168ClienteId ;
      private bool[] BC002N12_n168ClienteId ;
      private int[] BC002N12_A889NotaFiscalDestinatarioClienteId ;
      private bool[] BC002N12_n889NotaFiscalDestinatarioClienteId ;
      private decimal[] BC002N12_A874NotaFiscalValorTotal_F ;
      private decimal[] BC002N12_A875NotaFiscalValorTotalVendido_F ;
      private short[] BC002N12_A877NotaFiscalQuantidadeDeItens_F ;
      private short[] BC002N12_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private int[] BC002N4_A168ClienteId ;
      private bool[] BC002N4_n168ClienteId ;
      private int[] BC002N5_A889NotaFiscalDestinatarioClienteId ;
      private bool[] BC002N5_n889NotaFiscalDestinatarioClienteId ;
      private Guid[] BC002N13_A794NotaFiscalId ;
      private bool[] BC002N13_n794NotaFiscalId ;
      private Guid[] BC002N3_A794NotaFiscalId ;
      private bool[] BC002N3_n794NotaFiscalId ;
      private short[] BC002N3_A795NotaFiscalUF ;
      private bool[] BC002N3_n795NotaFiscalUF ;
      private string[] BC002N3_A796NotaFiscalNatureza ;
      private bool[] BC002N3_n796NotaFiscalNatureza ;
      private string[] BC002N3_A797NotaFiscalMod ;
      private bool[] BC002N3_n797NotaFiscalMod ;
      private string[] BC002N3_A798NotaFiscalSerie ;
      private bool[] BC002N3_n798NotaFiscalSerie ;
      private string[] BC002N3_A799NotaFiscalNumero ;
      private bool[] BC002N3_n799NotaFiscalNumero ;
      private DateTime[] BC002N3_A800NotaFiscalDataEmissao ;
      private bool[] BC002N3_n800NotaFiscalDataEmissao ;
      private DateTime[] BC002N3_A801NotaFiscalDataSaida ;
      private bool[] BC002N3_n801NotaFiscalDataSaida ;
      private string[] BC002N3_A802NotaFiscalTipo ;
      private bool[] BC002N3_n802NotaFiscalTipo ;
      private string[] BC002N3_A803NotaFiscalMunicipio ;
      private bool[] BC002N3_n803NotaFiscalMunicipio ;
      private string[] BC002N3_A804NotaFiscalTipoEmissao ;
      private bool[] BC002N3_n804NotaFiscalTipoEmissao ;
      private short[] BC002N3_A805NotaFiscalAmbiente ;
      private bool[] BC002N3_n805NotaFiscalAmbiente ;
      private string[] BC002N3_A806NotaFiscalFinalidades ;
      private bool[] BC002N3_n806NotaFiscalFinalidades ;
      private string[] BC002N3_A818NotaFiscaEmitentelDocumento ;
      private bool[] BC002N3_n818NotaFiscaEmitentelDocumento ;
      private string[] BC002N3_A808NotaFiscalEmitenteNome ;
      private bool[] BC002N3_n808NotaFiscalEmitenteNome ;
      private string[] BC002N3_A809NotaFiscalEmitenteLogradouro ;
      private bool[] BC002N3_n809NotaFiscalEmitenteLogradouro ;
      private string[] BC002N3_A810NotaFiscalEmitenteLogNum ;
      private bool[] BC002N3_n810NotaFiscalEmitenteLogNum ;
      private string[] BC002N3_A811NotaFiscalEmitenteComplemento ;
      private bool[] BC002N3_n811NotaFiscalEmitenteComplemento ;
      private string[] BC002N3_A812NotaFiscalEmitenteBairro ;
      private bool[] BC002N3_n812NotaFiscalEmitenteBairro ;
      private string[] BC002N3_A813NotaFiscalEmitenteMunicipio ;
      private bool[] BC002N3_n813NotaFiscalEmitenteMunicipio ;
      private string[] BC002N3_A814NotaFiscalEmitenteUF ;
      private bool[] BC002N3_n814NotaFiscalEmitenteUF ;
      private string[] BC002N3_A815NotaFiscalEmitenteCEP ;
      private bool[] BC002N3_n815NotaFiscalEmitenteCEP ;
      private string[] BC002N3_A816NotaFiscalEmitentePais ;
      private bool[] BC002N3_n816NotaFiscalEmitentePais ;
      private string[] BC002N3_A817NotaFiscalEmitenteTelefone ;
      private bool[] BC002N3_n817NotaFiscalEmitenteTelefone ;
      private string[] BC002N3_A819NotaFiscalEmitenteIE ;
      private bool[] BC002N3_n819NotaFiscalEmitenteIE ;
      private string[] BC002N3_A820NotaFiscalDestinatarioDocumento ;
      private bool[] BC002N3_n820NotaFiscalDestinatarioDocumento ;
      private string[] BC002N3_A852NotaFiscalDestinatarioNome ;
      private bool[] BC002N3_n852NotaFiscalDestinatarioNome ;
      private string[] BC002N3_A821NotaFiscalDestinatarioLogradouro ;
      private bool[] BC002N3_n821NotaFiscalDestinatarioLogradouro ;
      private string[] BC002N3_A822NotaFiscalDestinatarioLogNum ;
      private bool[] BC002N3_n822NotaFiscalDestinatarioLogNum ;
      private string[] BC002N3_A823NotaFiscalDestinatarioComplemento ;
      private bool[] BC002N3_n823NotaFiscalDestinatarioComplemento ;
      private string[] BC002N3_A824NotaFiscalDestinatarioBairro ;
      private bool[] BC002N3_n824NotaFiscalDestinatarioBairro ;
      private string[] BC002N3_A825NotaFiscalDestinatarioMunicipio ;
      private bool[] BC002N3_n825NotaFiscalDestinatarioMunicipio ;
      private string[] BC002N3_A826NotaFiscalDestinatarioUF ;
      private bool[] BC002N3_n826NotaFiscalDestinatarioUF ;
      private string[] BC002N3_A827NotaFiscalDestinatarioCEP ;
      private bool[] BC002N3_n827NotaFiscalDestinatarioCEP ;
      private string[] BC002N3_A828NotaFiscalDestinatarioPais ;
      private bool[] BC002N3_n828NotaFiscalDestinatarioPais ;
      private string[] BC002N3_A829NotaFiscalDestinatarioFone ;
      private bool[] BC002N3_n829NotaFiscalDestinatarioFone ;
      private int[] BC002N3_A168ClienteId ;
      private bool[] BC002N3_n168ClienteId ;
      private int[] BC002N3_A889NotaFiscalDestinatarioClienteId ;
      private bool[] BC002N3_n889NotaFiscalDestinatarioClienteId ;
      private Guid[] BC002N2_A794NotaFiscalId ;
      private bool[] BC002N2_n794NotaFiscalId ;
      private short[] BC002N2_A795NotaFiscalUF ;
      private bool[] BC002N2_n795NotaFiscalUF ;
      private string[] BC002N2_A796NotaFiscalNatureza ;
      private bool[] BC002N2_n796NotaFiscalNatureza ;
      private string[] BC002N2_A797NotaFiscalMod ;
      private bool[] BC002N2_n797NotaFiscalMod ;
      private string[] BC002N2_A798NotaFiscalSerie ;
      private bool[] BC002N2_n798NotaFiscalSerie ;
      private string[] BC002N2_A799NotaFiscalNumero ;
      private bool[] BC002N2_n799NotaFiscalNumero ;
      private DateTime[] BC002N2_A800NotaFiscalDataEmissao ;
      private bool[] BC002N2_n800NotaFiscalDataEmissao ;
      private DateTime[] BC002N2_A801NotaFiscalDataSaida ;
      private bool[] BC002N2_n801NotaFiscalDataSaida ;
      private string[] BC002N2_A802NotaFiscalTipo ;
      private bool[] BC002N2_n802NotaFiscalTipo ;
      private string[] BC002N2_A803NotaFiscalMunicipio ;
      private bool[] BC002N2_n803NotaFiscalMunicipio ;
      private string[] BC002N2_A804NotaFiscalTipoEmissao ;
      private bool[] BC002N2_n804NotaFiscalTipoEmissao ;
      private short[] BC002N2_A805NotaFiscalAmbiente ;
      private bool[] BC002N2_n805NotaFiscalAmbiente ;
      private string[] BC002N2_A806NotaFiscalFinalidades ;
      private bool[] BC002N2_n806NotaFiscalFinalidades ;
      private string[] BC002N2_A818NotaFiscaEmitentelDocumento ;
      private bool[] BC002N2_n818NotaFiscaEmitentelDocumento ;
      private string[] BC002N2_A808NotaFiscalEmitenteNome ;
      private bool[] BC002N2_n808NotaFiscalEmitenteNome ;
      private string[] BC002N2_A809NotaFiscalEmitenteLogradouro ;
      private bool[] BC002N2_n809NotaFiscalEmitenteLogradouro ;
      private string[] BC002N2_A810NotaFiscalEmitenteLogNum ;
      private bool[] BC002N2_n810NotaFiscalEmitenteLogNum ;
      private string[] BC002N2_A811NotaFiscalEmitenteComplemento ;
      private bool[] BC002N2_n811NotaFiscalEmitenteComplemento ;
      private string[] BC002N2_A812NotaFiscalEmitenteBairro ;
      private bool[] BC002N2_n812NotaFiscalEmitenteBairro ;
      private string[] BC002N2_A813NotaFiscalEmitenteMunicipio ;
      private bool[] BC002N2_n813NotaFiscalEmitenteMunicipio ;
      private string[] BC002N2_A814NotaFiscalEmitenteUF ;
      private bool[] BC002N2_n814NotaFiscalEmitenteUF ;
      private string[] BC002N2_A815NotaFiscalEmitenteCEP ;
      private bool[] BC002N2_n815NotaFiscalEmitenteCEP ;
      private string[] BC002N2_A816NotaFiscalEmitentePais ;
      private bool[] BC002N2_n816NotaFiscalEmitentePais ;
      private string[] BC002N2_A817NotaFiscalEmitenteTelefone ;
      private bool[] BC002N2_n817NotaFiscalEmitenteTelefone ;
      private string[] BC002N2_A819NotaFiscalEmitenteIE ;
      private bool[] BC002N2_n819NotaFiscalEmitenteIE ;
      private string[] BC002N2_A820NotaFiscalDestinatarioDocumento ;
      private bool[] BC002N2_n820NotaFiscalDestinatarioDocumento ;
      private string[] BC002N2_A852NotaFiscalDestinatarioNome ;
      private bool[] BC002N2_n852NotaFiscalDestinatarioNome ;
      private string[] BC002N2_A821NotaFiscalDestinatarioLogradouro ;
      private bool[] BC002N2_n821NotaFiscalDestinatarioLogradouro ;
      private string[] BC002N2_A822NotaFiscalDestinatarioLogNum ;
      private bool[] BC002N2_n822NotaFiscalDestinatarioLogNum ;
      private string[] BC002N2_A823NotaFiscalDestinatarioComplemento ;
      private bool[] BC002N2_n823NotaFiscalDestinatarioComplemento ;
      private string[] BC002N2_A824NotaFiscalDestinatarioBairro ;
      private bool[] BC002N2_n824NotaFiscalDestinatarioBairro ;
      private string[] BC002N2_A825NotaFiscalDestinatarioMunicipio ;
      private bool[] BC002N2_n825NotaFiscalDestinatarioMunicipio ;
      private string[] BC002N2_A826NotaFiscalDestinatarioUF ;
      private bool[] BC002N2_n826NotaFiscalDestinatarioUF ;
      private string[] BC002N2_A827NotaFiscalDestinatarioCEP ;
      private bool[] BC002N2_n827NotaFiscalDestinatarioCEP ;
      private string[] BC002N2_A828NotaFiscalDestinatarioPais ;
      private bool[] BC002N2_n828NotaFiscalDestinatarioPais ;
      private string[] BC002N2_A829NotaFiscalDestinatarioFone ;
      private bool[] BC002N2_n829NotaFiscalDestinatarioFone ;
      private int[] BC002N2_A168ClienteId ;
      private bool[] BC002N2_n168ClienteId ;
      private int[] BC002N2_A889NotaFiscalDestinatarioClienteId ;
      private bool[] BC002N2_n889NotaFiscalDestinatarioClienteId ;
      private decimal[] BC002N18_A874NotaFiscalValorTotal_F ;
      private short[] BC002N18_A877NotaFiscalQuantidadeDeItens_F ;
      private decimal[] BC002N20_A875NotaFiscalValorTotalVendido_F ;
      private short[] BC002N20_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private Guid[] BC002N21_A890NotaFiscalParcelamentoID ;
      private Guid[] BC002N22_A830NotaFiscalItemId ;
      private Guid[] BC002N25_A794NotaFiscalId ;
      private bool[] BC002N25_n794NotaFiscalId ;
      private short[] BC002N25_A795NotaFiscalUF ;
      private bool[] BC002N25_n795NotaFiscalUF ;
      private string[] BC002N25_A796NotaFiscalNatureza ;
      private bool[] BC002N25_n796NotaFiscalNatureza ;
      private string[] BC002N25_A797NotaFiscalMod ;
      private bool[] BC002N25_n797NotaFiscalMod ;
      private string[] BC002N25_A798NotaFiscalSerie ;
      private bool[] BC002N25_n798NotaFiscalSerie ;
      private string[] BC002N25_A799NotaFiscalNumero ;
      private bool[] BC002N25_n799NotaFiscalNumero ;
      private DateTime[] BC002N25_A800NotaFiscalDataEmissao ;
      private bool[] BC002N25_n800NotaFiscalDataEmissao ;
      private DateTime[] BC002N25_A801NotaFiscalDataSaida ;
      private bool[] BC002N25_n801NotaFiscalDataSaida ;
      private string[] BC002N25_A802NotaFiscalTipo ;
      private bool[] BC002N25_n802NotaFiscalTipo ;
      private string[] BC002N25_A803NotaFiscalMunicipio ;
      private bool[] BC002N25_n803NotaFiscalMunicipio ;
      private string[] BC002N25_A804NotaFiscalTipoEmissao ;
      private bool[] BC002N25_n804NotaFiscalTipoEmissao ;
      private short[] BC002N25_A805NotaFiscalAmbiente ;
      private bool[] BC002N25_n805NotaFiscalAmbiente ;
      private string[] BC002N25_A806NotaFiscalFinalidades ;
      private bool[] BC002N25_n806NotaFiscalFinalidades ;
      private string[] BC002N25_A818NotaFiscaEmitentelDocumento ;
      private bool[] BC002N25_n818NotaFiscaEmitentelDocumento ;
      private string[] BC002N25_A808NotaFiscalEmitenteNome ;
      private bool[] BC002N25_n808NotaFiscalEmitenteNome ;
      private string[] BC002N25_A809NotaFiscalEmitenteLogradouro ;
      private bool[] BC002N25_n809NotaFiscalEmitenteLogradouro ;
      private string[] BC002N25_A810NotaFiscalEmitenteLogNum ;
      private bool[] BC002N25_n810NotaFiscalEmitenteLogNum ;
      private string[] BC002N25_A811NotaFiscalEmitenteComplemento ;
      private bool[] BC002N25_n811NotaFiscalEmitenteComplemento ;
      private string[] BC002N25_A812NotaFiscalEmitenteBairro ;
      private bool[] BC002N25_n812NotaFiscalEmitenteBairro ;
      private string[] BC002N25_A813NotaFiscalEmitenteMunicipio ;
      private bool[] BC002N25_n813NotaFiscalEmitenteMunicipio ;
      private string[] BC002N25_A814NotaFiscalEmitenteUF ;
      private bool[] BC002N25_n814NotaFiscalEmitenteUF ;
      private string[] BC002N25_A815NotaFiscalEmitenteCEP ;
      private bool[] BC002N25_n815NotaFiscalEmitenteCEP ;
      private string[] BC002N25_A816NotaFiscalEmitentePais ;
      private bool[] BC002N25_n816NotaFiscalEmitentePais ;
      private string[] BC002N25_A817NotaFiscalEmitenteTelefone ;
      private bool[] BC002N25_n817NotaFiscalEmitenteTelefone ;
      private string[] BC002N25_A819NotaFiscalEmitenteIE ;
      private bool[] BC002N25_n819NotaFiscalEmitenteIE ;
      private string[] BC002N25_A820NotaFiscalDestinatarioDocumento ;
      private bool[] BC002N25_n820NotaFiscalDestinatarioDocumento ;
      private string[] BC002N25_A852NotaFiscalDestinatarioNome ;
      private bool[] BC002N25_n852NotaFiscalDestinatarioNome ;
      private string[] BC002N25_A821NotaFiscalDestinatarioLogradouro ;
      private bool[] BC002N25_n821NotaFiscalDestinatarioLogradouro ;
      private string[] BC002N25_A822NotaFiscalDestinatarioLogNum ;
      private bool[] BC002N25_n822NotaFiscalDestinatarioLogNum ;
      private string[] BC002N25_A823NotaFiscalDestinatarioComplemento ;
      private bool[] BC002N25_n823NotaFiscalDestinatarioComplemento ;
      private string[] BC002N25_A824NotaFiscalDestinatarioBairro ;
      private bool[] BC002N25_n824NotaFiscalDestinatarioBairro ;
      private string[] BC002N25_A825NotaFiscalDestinatarioMunicipio ;
      private bool[] BC002N25_n825NotaFiscalDestinatarioMunicipio ;
      private string[] BC002N25_A826NotaFiscalDestinatarioUF ;
      private bool[] BC002N25_n826NotaFiscalDestinatarioUF ;
      private string[] BC002N25_A827NotaFiscalDestinatarioCEP ;
      private bool[] BC002N25_n827NotaFiscalDestinatarioCEP ;
      private string[] BC002N25_A828NotaFiscalDestinatarioPais ;
      private bool[] BC002N25_n828NotaFiscalDestinatarioPais ;
      private string[] BC002N25_A829NotaFiscalDestinatarioFone ;
      private bool[] BC002N25_n829NotaFiscalDestinatarioFone ;
      private int[] BC002N25_A168ClienteId ;
      private bool[] BC002N25_n168ClienteId ;
      private int[] BC002N25_A889NotaFiscalDestinatarioClienteId ;
      private bool[] BC002N25_n889NotaFiscalDestinatarioClienteId ;
      private decimal[] BC002N25_A874NotaFiscalValorTotal_F ;
      private decimal[] BC002N25_A875NotaFiscalValorTotalVendido_F ;
      private short[] BC002N25_A877NotaFiscalQuantidadeDeItens_F ;
      private short[] BC002N25_A878NotaFiscalQuantidadeDeItensVendidos_F ;
      private SdtNotaFiscal bcNotaFiscal ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class notafiscal_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002N2;
          prmBC002N2 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002N3;
          prmBC002N3 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002N4;
          prmBC002N4 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002N5;
          prmBC002N5 = new Object[] {
          new ParDef("NotaFiscalDestinatarioClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002N7;
          prmBC002N7 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002N9;
          prmBC002N9 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002N12;
          prmBC002N12 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          string cmdBufferBC002N12;
          cmdBufferBC002N12=" SELECT TM1.NotaFiscalId, TM1.NotaFiscalUF, TM1.NotaFiscalNatureza, TM1.NotaFiscalMod, TM1.NotaFiscalSerie, TM1.NotaFiscalNumero, TM1.NotaFiscalDataEmissao, TM1.NotaFiscalDataSaida, TM1.NotaFiscalTipo, TM1.NotaFiscalMunicipio, TM1.NotaFiscalTipoEmissao, TM1.NotaFiscalAmbiente, TM1.NotaFiscalFinalidades, TM1.NotaFiscaEmitentelDocumento, TM1.NotaFiscalEmitenteNome, TM1.NotaFiscalEmitenteLogradouro, TM1.NotaFiscalEmitenteLogNum, TM1.NotaFiscalEmitenteComplemento, TM1.NotaFiscalEmitenteBairro, TM1.NotaFiscalEmitenteMunicipio, TM1.NotaFiscalEmitenteUF, TM1.NotaFiscalEmitenteCEP, TM1.NotaFiscalEmitentePais, TM1.NotaFiscalEmitenteTelefone, TM1.NotaFiscalEmitenteIE, TM1.NotaFiscalDestinatarioDocumento, TM1.NotaFiscalDestinatarioNome, TM1.NotaFiscalDestinatarioLogradouro, TM1.NotaFiscalDestinatarioLogNum, TM1.NotaFiscalDestinatarioComplemento, TM1.NotaFiscalDestinatarioBairro, TM1.NotaFiscalDestinatarioMunicipio, TM1.NotaFiscalDestinatarioUF, TM1.NotaFiscalDestinatarioCEP, TM1.NotaFiscalDestinatarioPais, TM1.NotaFiscalDestinatarioFone, TM1.ClienteId, TM1.NotaFiscalDestinatarioClienteId AS NotaFiscalDestinatarioClienteId, COALESCE( T2.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F, COALESCE( T3.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T2.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItens_F, COALESCE( T3.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F FROM ((NotaFiscal TM1 LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem WHERE TM1.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T2 ON T2.NotaFiscalId = TM1.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, "
          + " NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem WHERE (TM1.NotaFiscalId = NotaFiscalId) AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T3 ON T3.NotaFiscalId = TM1.NotaFiscalId) WHERE TM1.NotaFiscalId = :NotaFiscalId ORDER BY TM1.NotaFiscalId" ;
          Object[] prmBC002N13;
          prmBC002N13 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002N14;
          prmBC002N14 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("NotaFiscalUF",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotaFiscalNatureza",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("NotaFiscalMod",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("NotaFiscalSerie",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("NotaFiscalNumero",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDataEmissao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotaFiscalDataSaida",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotaFiscalTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalTipoEmissao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalAmbiente",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotaFiscalFinalidades",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscaEmitentelDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteLogNum",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitentePais",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteTelefone",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteIE",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioLogNum",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioPais",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioFone",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioClienteId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC002N14;
          cmdBufferBC002N14=" SAVEPOINT gxupdate;INSERT INTO NotaFiscal(NotaFiscalId, NotaFiscalUF, NotaFiscalNatureza, NotaFiscalMod, NotaFiscalSerie, NotaFiscalNumero, NotaFiscalDataEmissao, NotaFiscalDataSaida, NotaFiscalTipo, NotaFiscalMunicipio, NotaFiscalTipoEmissao, NotaFiscalAmbiente, NotaFiscalFinalidades, NotaFiscaEmitentelDocumento, NotaFiscalEmitenteNome, NotaFiscalEmitenteLogradouro, NotaFiscalEmitenteLogNum, NotaFiscalEmitenteComplemento, NotaFiscalEmitenteBairro, NotaFiscalEmitenteMunicipio, NotaFiscalEmitenteUF, NotaFiscalEmitenteCEP, NotaFiscalEmitentePais, NotaFiscalEmitenteTelefone, NotaFiscalEmitenteIE, NotaFiscalDestinatarioDocumento, NotaFiscalDestinatarioNome, NotaFiscalDestinatarioLogradouro, NotaFiscalDestinatarioLogNum, NotaFiscalDestinatarioComplemento, NotaFiscalDestinatarioBairro, NotaFiscalDestinatarioMunicipio, NotaFiscalDestinatarioUF, NotaFiscalDestinatarioCEP, NotaFiscalDestinatarioPais, NotaFiscalDestinatarioFone, ClienteId, NotaFiscalDestinatarioClienteId) VALUES(:NotaFiscalId, :NotaFiscalUF, :NotaFiscalNatureza, :NotaFiscalMod, :NotaFiscalSerie, :NotaFiscalNumero, :NotaFiscalDataEmissao, :NotaFiscalDataSaida, :NotaFiscalTipo, :NotaFiscalMunicipio, :NotaFiscalTipoEmissao, :NotaFiscalAmbiente, :NotaFiscalFinalidades, :NotaFiscaEmitentelDocumento, :NotaFiscalEmitenteNome, :NotaFiscalEmitenteLogradouro, :NotaFiscalEmitenteLogNum, :NotaFiscalEmitenteComplemento, :NotaFiscalEmitenteBairro, :NotaFiscalEmitenteMunicipio, :NotaFiscalEmitenteUF, :NotaFiscalEmitenteCEP, :NotaFiscalEmitentePais, :NotaFiscalEmitenteTelefone, :NotaFiscalEmitenteIE, :NotaFiscalDestinatarioDocumento, :NotaFiscalDestinatarioNome, :NotaFiscalDestinatarioLogradouro, :NotaFiscalDestinatarioLogNum, :NotaFiscalDestinatarioComplemento, :NotaFiscalDestinatarioBairro, :NotaFiscalDestinatarioMunicipio, :NotaFiscalDestinatarioUF, "
          + " :NotaFiscalDestinatarioCEP, :NotaFiscalDestinatarioPais, :NotaFiscalDestinatarioFone, :ClienteId, :NotaFiscalDestinatarioClienteId);RELEASE SAVEPOINT gxupdate" ;
          Object[] prmBC002N15;
          prmBC002N15 = new Object[] {
          new ParDef("NotaFiscalUF",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotaFiscalNatureza",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("NotaFiscalMod",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("NotaFiscalSerie",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("NotaFiscalNumero",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDataEmissao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotaFiscalDataSaida",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotaFiscalTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalTipoEmissao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalAmbiente",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotaFiscalFinalidades",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscaEmitentelDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteLogNum",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitentePais",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteTelefone",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalEmitenteIE",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioLogradouro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioLogNum",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioComplemento",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioMunicipio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioPais",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioFone",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalDestinatarioClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          string cmdBufferBC002N15;
          cmdBufferBC002N15=" SAVEPOINT gxupdate;UPDATE NotaFiscal SET NotaFiscalUF=:NotaFiscalUF, NotaFiscalNatureza=:NotaFiscalNatureza, NotaFiscalMod=:NotaFiscalMod, NotaFiscalSerie=:NotaFiscalSerie, NotaFiscalNumero=:NotaFiscalNumero, NotaFiscalDataEmissao=:NotaFiscalDataEmissao, NotaFiscalDataSaida=:NotaFiscalDataSaida, NotaFiscalTipo=:NotaFiscalTipo, NotaFiscalMunicipio=:NotaFiscalMunicipio, NotaFiscalTipoEmissao=:NotaFiscalTipoEmissao, NotaFiscalAmbiente=:NotaFiscalAmbiente, NotaFiscalFinalidades=:NotaFiscalFinalidades, NotaFiscaEmitentelDocumento=:NotaFiscaEmitentelDocumento, NotaFiscalEmitenteNome=:NotaFiscalEmitenteNome, NotaFiscalEmitenteLogradouro=:NotaFiscalEmitenteLogradouro, NotaFiscalEmitenteLogNum=:NotaFiscalEmitenteLogNum, NotaFiscalEmitenteComplemento=:NotaFiscalEmitenteComplemento, NotaFiscalEmitenteBairro=:NotaFiscalEmitenteBairro, NotaFiscalEmitenteMunicipio=:NotaFiscalEmitenteMunicipio, NotaFiscalEmitenteUF=:NotaFiscalEmitenteUF, NotaFiscalEmitenteCEP=:NotaFiscalEmitenteCEP, NotaFiscalEmitentePais=:NotaFiscalEmitentePais, NotaFiscalEmitenteTelefone=:NotaFiscalEmitenteTelefone, NotaFiscalEmitenteIE=:NotaFiscalEmitenteIE, NotaFiscalDestinatarioDocumento=:NotaFiscalDestinatarioDocumento, NotaFiscalDestinatarioNome=:NotaFiscalDestinatarioNome, NotaFiscalDestinatarioLogradouro=:NotaFiscalDestinatarioLogradouro, NotaFiscalDestinatarioLogNum=:NotaFiscalDestinatarioLogNum, NotaFiscalDestinatarioComplemento=:NotaFiscalDestinatarioComplemento, NotaFiscalDestinatarioBairro=:NotaFiscalDestinatarioBairro, NotaFiscalDestinatarioMunicipio=:NotaFiscalDestinatarioMunicipio, NotaFiscalDestinatarioUF=:NotaFiscalDestinatarioUF, NotaFiscalDestinatarioCEP=:NotaFiscalDestinatarioCEP, NotaFiscalDestinatarioPais=:NotaFiscalDestinatarioPais, NotaFiscalDestinatarioFone=:NotaFiscalDestinatarioFone, ClienteId=:ClienteId, "
          + " NotaFiscalDestinatarioClienteId=:NotaFiscalDestinatarioClienteId  WHERE NotaFiscalId = :NotaFiscalId;RELEASE SAVEPOINT gxupdate" ;
          Object[] prmBC002N16;
          prmBC002N16 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002N18;
          prmBC002N18 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002N20;
          prmBC002N20 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002N21;
          prmBC002N21 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002N22;
          prmBC002N22 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002N25;
          prmBC002N25 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          string cmdBufferBC002N25;
          cmdBufferBC002N25=" SELECT TM1.NotaFiscalId, TM1.NotaFiscalUF, TM1.NotaFiscalNatureza, TM1.NotaFiscalMod, TM1.NotaFiscalSerie, TM1.NotaFiscalNumero, TM1.NotaFiscalDataEmissao, TM1.NotaFiscalDataSaida, TM1.NotaFiscalTipo, TM1.NotaFiscalMunicipio, TM1.NotaFiscalTipoEmissao, TM1.NotaFiscalAmbiente, TM1.NotaFiscalFinalidades, TM1.NotaFiscaEmitentelDocumento, TM1.NotaFiscalEmitenteNome, TM1.NotaFiscalEmitenteLogradouro, TM1.NotaFiscalEmitenteLogNum, TM1.NotaFiscalEmitenteComplemento, TM1.NotaFiscalEmitenteBairro, TM1.NotaFiscalEmitenteMunicipio, TM1.NotaFiscalEmitenteUF, TM1.NotaFiscalEmitenteCEP, TM1.NotaFiscalEmitentePais, TM1.NotaFiscalEmitenteTelefone, TM1.NotaFiscalEmitenteIE, TM1.NotaFiscalDestinatarioDocumento, TM1.NotaFiscalDestinatarioNome, TM1.NotaFiscalDestinatarioLogradouro, TM1.NotaFiscalDestinatarioLogNum, TM1.NotaFiscalDestinatarioComplemento, TM1.NotaFiscalDestinatarioBairro, TM1.NotaFiscalDestinatarioMunicipio, TM1.NotaFiscalDestinatarioUF, TM1.NotaFiscalDestinatarioCEP, TM1.NotaFiscalDestinatarioPais, TM1.NotaFiscalDestinatarioFone, TM1.ClienteId, TM1.NotaFiscalDestinatarioClienteId AS NotaFiscalDestinatarioClienteId, COALESCE( T2.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F, COALESCE( T3.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T2.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItens_F, COALESCE( T3.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F FROM ((NotaFiscal TM1 LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem WHERE TM1.NotaFiscalId = NotaFiscalId GROUP BY NotaFiscalId ) T2 ON T2.NotaFiscalId = TM1.NotaFiscalId) LEFT JOIN LATERAL (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, "
          + " NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem WHERE (TM1.NotaFiscalId = NotaFiscalId) AND (NotaFiscalItemVendido = ( 'VENDIDO')) GROUP BY NotaFiscalId ) T3 ON T3.NotaFiscalId = TM1.NotaFiscalId) WHERE TM1.NotaFiscalId = :NotaFiscalId ORDER BY TM1.NotaFiscalId" ;
          def= new CursorDef[] {
              new CursorDef("BC002N2", "SELECT NotaFiscalId, NotaFiscalUF, NotaFiscalNatureza, NotaFiscalMod, NotaFiscalSerie, NotaFiscalNumero, NotaFiscalDataEmissao, NotaFiscalDataSaida, NotaFiscalTipo, NotaFiscalMunicipio, NotaFiscalTipoEmissao, NotaFiscalAmbiente, NotaFiscalFinalidades, NotaFiscaEmitentelDocumento, NotaFiscalEmitenteNome, NotaFiscalEmitenteLogradouro, NotaFiscalEmitenteLogNum, NotaFiscalEmitenteComplemento, NotaFiscalEmitenteBairro, NotaFiscalEmitenteMunicipio, NotaFiscalEmitenteUF, NotaFiscalEmitenteCEP, NotaFiscalEmitentePais, NotaFiscalEmitenteTelefone, NotaFiscalEmitenteIE, NotaFiscalDestinatarioDocumento, NotaFiscalDestinatarioNome, NotaFiscalDestinatarioLogradouro, NotaFiscalDestinatarioLogNum, NotaFiscalDestinatarioComplemento, NotaFiscalDestinatarioBairro, NotaFiscalDestinatarioMunicipio, NotaFiscalDestinatarioUF, NotaFiscalDestinatarioCEP, NotaFiscalDestinatarioPais, NotaFiscalDestinatarioFone, ClienteId, NotaFiscalDestinatarioClienteId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId  FOR UPDATE OF NotaFiscal",true, GxErrorMask.GX_NOMASK, false, this,prmBC002N2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002N3", "SELECT NotaFiscalId, NotaFiscalUF, NotaFiscalNatureza, NotaFiscalMod, NotaFiscalSerie, NotaFiscalNumero, NotaFiscalDataEmissao, NotaFiscalDataSaida, NotaFiscalTipo, NotaFiscalMunicipio, NotaFiscalTipoEmissao, NotaFiscalAmbiente, NotaFiscalFinalidades, NotaFiscaEmitentelDocumento, NotaFiscalEmitenteNome, NotaFiscalEmitenteLogradouro, NotaFiscalEmitenteLogNum, NotaFiscalEmitenteComplemento, NotaFiscalEmitenteBairro, NotaFiscalEmitenteMunicipio, NotaFiscalEmitenteUF, NotaFiscalEmitenteCEP, NotaFiscalEmitentePais, NotaFiscalEmitenteTelefone, NotaFiscalEmitenteIE, NotaFiscalDestinatarioDocumento, NotaFiscalDestinatarioNome, NotaFiscalDestinatarioLogradouro, NotaFiscalDestinatarioLogNum, NotaFiscalDestinatarioComplemento, NotaFiscalDestinatarioBairro, NotaFiscalDestinatarioMunicipio, NotaFiscalDestinatarioUF, NotaFiscalDestinatarioCEP, NotaFiscalDestinatarioPais, NotaFiscalDestinatarioFone, ClienteId, NotaFiscalDestinatarioClienteId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002N3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002N4", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002N4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002N5", "SELECT ClienteId AS NotaFiscalDestinatarioClienteId FROM Cliente WHERE ClienteId = :NotaFiscalDestinatarioClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002N5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002N7", "SELECT COALESCE( T1.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F, COALESCE( T1.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItens_F FROM (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem GROUP BY NotaFiscalId ) T1 WHERE T1.NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002N7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002N9", "SELECT COALESCE( T1.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T1.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F FROM (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem WHERE NotaFiscalItemVendido = ( 'VENDIDO') GROUP BY NotaFiscalId ) T1 WHERE T1.NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002N9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002N12", cmdBufferBC002N12,true, GxErrorMask.GX_NOMASK, false, this,prmBC002N12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002N13", "SELECT NotaFiscalId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002N13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002N14", cmdBufferBC002N14, GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002N14)
             ,new CursorDef("BC002N15", cmdBufferBC002N15, GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002N15)
             ,new CursorDef("BC002N16", "SAVEPOINT gxupdate;DELETE FROM NotaFiscal  WHERE NotaFiscalId = :NotaFiscalId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002N16)
             ,new CursorDef("BC002N18", "SELECT COALESCE( T1.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotal_F, COALESCE( T1.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItens_F FROM (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem GROUP BY NotaFiscalId ) T1 WHERE T1.NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002N18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002N20", "SELECT COALESCE( T1.NotaFiscalValorTotal_F, 0) AS NotaFiscalValorTotalVendido_F, COALESCE( T1.NotaFiscalQuantidadeDeItens_F, 0) AS NotaFiscalQuantidadeDeItensVendidos_F FROM (SELECT SUM(NotaFiscalItemValorTotal) AS NotaFiscalValorTotal_F, NotaFiscalId, COUNT(*) AS NotaFiscalQuantidadeDeItens_F FROM NotaFiscalItem WHERE NotaFiscalItemVendido = ( 'VENDIDO') GROUP BY NotaFiscalId ) T1 WHERE T1.NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002N20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002N21", "SELECT NotaFiscalParcelamentoID FROM NotaFiscalParcelamento WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002N21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002N22", "SELECT NotaFiscalItemId FROM NotaFiscalItem WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002N22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002N25", cmdBufferBC002N25,true, GxErrorMask.GX_NOMASK, false, this,prmBC002N25,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
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
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((int[]) buf[73])[0] = rslt.getInt(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
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
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((int[]) buf[73])[0] = rslt.getInt(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 5 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 6 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
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
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((int[]) buf[73])[0] = rslt.getInt(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((decimal[]) buf[75])[0] = rslt.getDecimal(39);
                ((decimal[]) buf[76])[0] = rslt.getDecimal(40);
                ((short[]) buf[77])[0] = rslt.getShort(41);
                ((short[]) buf[78])[0] = rslt.getShort(42);
                return;
             case 7 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 11 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 12 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 13 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 14 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 15 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
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
                ((string[]) buf[65])[0] = rslt.getVarchar(34);
                ((bool[]) buf[66])[0] = rslt.wasNull(34);
                ((string[]) buf[67])[0] = rslt.getVarchar(35);
                ((bool[]) buf[68])[0] = rslt.wasNull(35);
                ((string[]) buf[69])[0] = rslt.getVarchar(36);
                ((bool[]) buf[70])[0] = rslt.wasNull(36);
                ((int[]) buf[71])[0] = rslt.getInt(37);
                ((bool[]) buf[72])[0] = rslt.wasNull(37);
                ((int[]) buf[73])[0] = rslt.getInt(38);
                ((bool[]) buf[74])[0] = rslt.wasNull(38);
                ((decimal[]) buf[75])[0] = rslt.getDecimal(39);
                ((decimal[]) buf[76])[0] = rslt.getDecimal(40);
                ((short[]) buf[77])[0] = rslt.getShort(41);
                ((short[]) buf[78])[0] = rslt.getShort(42);
                return;
       }
    }

 }

}
