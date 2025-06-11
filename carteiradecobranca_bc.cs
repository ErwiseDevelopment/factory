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
   public class carteiradecobranca_bc : GxSilentTrn, IGxSilentTrn
   {
      public carteiradecobranca_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public carteiradecobranca_bc( IGxContext context )
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
         ReadRow36110( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey36110( ) ;
         standaloneModal( ) ;
         AddRow36110( ) ;
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
            /* Execute user event: After Trn */
            E11362 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1069CarteiraDeCobrancaId = A1069CarteiraDeCobrancaId;
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

      protected void CONFIRM_360( )
      {
         BeforeValidate36110( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls36110( ) ;
            }
            else
            {
               CheckExtendedTable36110( ) ;
               if ( AnyError == 0 )
               {
                  ZM36110( 9) ;
                  ZM36110( 10) ;
                  ZM36110( 11) ;
                  ZM36110( 12) ;
               }
               CloseExtendedTableCursors36110( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12362( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11362( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM36110( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z1072CarteiraDeCobrancaWorkspaceId = A1072CarteiraDeCobrancaWorkspaceId;
            Z1075CarteiraDeCobrancaCreatedAt = A1075CarteiraDeCobrancaCreatedAt;
            Z1076CarteiraDeCobrancaUpdatedAt = A1076CarteiraDeCobrancaUpdatedAt;
            Z1070CarteiraDeCobrancaCodigo = A1070CarteiraDeCobrancaCodigo;
            Z1071CarteiraDeCobrancaNome = A1071CarteiraDeCobrancaNome;
            Z1073CarteiraDeCobrancaConvenio = A1073CarteiraDeCobrancaConvenio;
            Z1074CarteiraDeCobrancaStatus = A1074CarteiraDeCobrancaStatus;
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
         if ( GX_JID == -8 )
         {
            Z1069CarteiraDeCobrancaId = A1069CarteiraDeCobrancaId;
            Z1072CarteiraDeCobrancaWorkspaceId = A1072CarteiraDeCobrancaWorkspaceId;
            Z1075CarteiraDeCobrancaCreatedAt = A1075CarteiraDeCobrancaCreatedAt;
            Z1076CarteiraDeCobrancaUpdatedAt = A1076CarteiraDeCobrancaUpdatedAt;
            Z1070CarteiraDeCobrancaCodigo = A1070CarteiraDeCobrancaCodigo;
            Z1071CarteiraDeCobrancaNome = A1071CarteiraDeCobrancaNome;
            Z1073CarteiraDeCobrancaConvenio = A1073CarteiraDeCobrancaConvenio;
            Z1074CarteiraDeCobrancaStatus = A1074CarteiraDeCobrancaStatus;
            Z1111CarteiraDeCobrancaValorTotal = A1111CarteiraDeCobrancaValorTotal;
            Z1112CarteiraDeCobrancaValorRecebido = A1112CarteiraDeCobrancaValorRecebido;
            Z1113CarteiraDeCobrancaTotalBoletos = A1113CarteiraDeCobrancaTotalBoletos;
            Z1114CarteiraDeCobrancaTotalBoletosRegistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
            Z1115CarteiraDeCobrancaTotalBoletosExpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
            Z1116CarteiraDeCobrancaTotalBoletosCancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A1072CarteiraDeCobrancaWorkspaceId) )
         {
            A1072CarteiraDeCobrancaWorkspaceId = Guid.NewGuid( );
            n1072CarteiraDeCobrancaWorkspaceId = false;
         }
         if ( IsIns( )  )
         {
            A1075CarteiraDeCobrancaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1075CarteiraDeCobrancaCreatedAt = false;
         }
         if ( IsUpd( )  )
         {
            A1076CarteiraDeCobrancaUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1076CarteiraDeCobrancaUpdatedAt = false;
         }
         if ( IsIns( )  && (false==A1074CarteiraDeCobrancaStatus) && ( Gx_BScreen == 0 ) )
         {
            A1074CarteiraDeCobrancaStatus = true;
            n1074CarteiraDeCobrancaStatus = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load36110( )
      {
         /* Using cursor BC003616 */
         pr_default.execute(6, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound110 = 1;
            A1072CarteiraDeCobrancaWorkspaceId = BC003616_A1072CarteiraDeCobrancaWorkspaceId[0];
            n1072CarteiraDeCobrancaWorkspaceId = BC003616_n1072CarteiraDeCobrancaWorkspaceId[0];
            A1075CarteiraDeCobrancaCreatedAt = BC003616_A1075CarteiraDeCobrancaCreatedAt[0];
            n1075CarteiraDeCobrancaCreatedAt = BC003616_n1075CarteiraDeCobrancaCreatedAt[0];
            A1076CarteiraDeCobrancaUpdatedAt = BC003616_A1076CarteiraDeCobrancaUpdatedAt[0];
            n1076CarteiraDeCobrancaUpdatedAt = BC003616_n1076CarteiraDeCobrancaUpdatedAt[0];
            A1070CarteiraDeCobrancaCodigo = BC003616_A1070CarteiraDeCobrancaCodigo[0];
            n1070CarteiraDeCobrancaCodigo = BC003616_n1070CarteiraDeCobrancaCodigo[0];
            A1071CarteiraDeCobrancaNome = BC003616_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = BC003616_n1071CarteiraDeCobrancaNome[0];
            A1073CarteiraDeCobrancaConvenio = BC003616_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = BC003616_n1073CarteiraDeCobrancaConvenio[0];
            A1074CarteiraDeCobrancaStatus = BC003616_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = BC003616_n1074CarteiraDeCobrancaStatus[0];
            A1111CarteiraDeCobrancaValorTotal = BC003616_A1111CarteiraDeCobrancaValorTotal[0];
            A1112CarteiraDeCobrancaValorRecebido = BC003616_A1112CarteiraDeCobrancaValorRecebido[0];
            A1113CarteiraDeCobrancaTotalBoletos = BC003616_A1113CarteiraDeCobrancaTotalBoletos[0];
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003616_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003616_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            A1115CarteiraDeCobrancaTotalBoletosExpirados = BC003616_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = BC003616_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            A1116CarteiraDeCobrancaTotalBoletosCancelados = BC003616_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = BC003616_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            ZM36110( -8) ;
         }
         pr_default.close(6);
         OnLoadActions36110( ) ;
      }

      protected void OnLoadActions36110( )
      {
      }

      protected void CheckExtendedTable36110( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00365 */
         pr_default.execute(2, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A1111CarteiraDeCobrancaValorTotal = BC00365_A1111CarteiraDeCobrancaValorTotal[0];
            A1112CarteiraDeCobrancaValorRecebido = BC00365_A1112CarteiraDeCobrancaValorRecebido[0];
            A1113CarteiraDeCobrancaTotalBoletos = BC00365_A1113CarteiraDeCobrancaTotalBoletos[0];
         }
         else
         {
            A1111CarteiraDeCobrancaValorTotal = 0;
            A1112CarteiraDeCobrancaValorRecebido = 0;
            A1113CarteiraDeCobrancaTotalBoletos = 0;
         }
         pr_default.close(2);
         if ( ( A1111CarteiraDeCobrancaValorTotal < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ( A1112CarteiraDeCobrancaValorRecebido < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00367 */
         pr_default.execute(3, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = BC00367_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = BC00367_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
         }
         else
         {
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
         }
         pr_default.close(3);
         /* Using cursor BC00369 */
         pr_default.execute(4, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = BC00369_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = BC00369_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
         }
         else
         {
            A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
            n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
         }
         pr_default.close(4);
         /* Using cursor BC003611 */
         pr_default.execute(5, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = BC003611_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = BC003611_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
         }
         else
         {
            A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
            n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors36110( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey36110( )
      {
         /* Using cursor BC003617 */
         pr_default.execute(7, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound110 = 1;
         }
         else
         {
            RcdFound110 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00363 */
         pr_default.execute(1, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM36110( 8) ;
            RcdFound110 = 1;
            A1069CarteiraDeCobrancaId = BC00363_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = BC00363_n1069CarteiraDeCobrancaId[0];
            A1072CarteiraDeCobrancaWorkspaceId = BC00363_A1072CarteiraDeCobrancaWorkspaceId[0];
            n1072CarteiraDeCobrancaWorkspaceId = BC00363_n1072CarteiraDeCobrancaWorkspaceId[0];
            A1075CarteiraDeCobrancaCreatedAt = BC00363_A1075CarteiraDeCobrancaCreatedAt[0];
            n1075CarteiraDeCobrancaCreatedAt = BC00363_n1075CarteiraDeCobrancaCreatedAt[0];
            A1076CarteiraDeCobrancaUpdatedAt = BC00363_A1076CarteiraDeCobrancaUpdatedAt[0];
            n1076CarteiraDeCobrancaUpdatedAt = BC00363_n1076CarteiraDeCobrancaUpdatedAt[0];
            A1070CarteiraDeCobrancaCodigo = BC00363_A1070CarteiraDeCobrancaCodigo[0];
            n1070CarteiraDeCobrancaCodigo = BC00363_n1070CarteiraDeCobrancaCodigo[0];
            A1071CarteiraDeCobrancaNome = BC00363_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = BC00363_n1071CarteiraDeCobrancaNome[0];
            A1073CarteiraDeCobrancaConvenio = BC00363_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = BC00363_n1073CarteiraDeCobrancaConvenio[0];
            A1074CarteiraDeCobrancaStatus = BC00363_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = BC00363_n1074CarteiraDeCobrancaStatus[0];
            Z1069CarteiraDeCobrancaId = A1069CarteiraDeCobrancaId;
            sMode110 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load36110( ) ;
            if ( AnyError == 1 )
            {
               RcdFound110 = 0;
               InitializeNonKey36110( ) ;
            }
            Gx_mode = sMode110;
         }
         else
         {
            RcdFound110 = 0;
            InitializeNonKey36110( ) ;
            sMode110 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode110;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey36110( ) ;
         if ( RcdFound110 == 0 )
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
         CONFIRM_360( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency36110( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00362 */
            pr_default.execute(0, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarteiraDeCobranca"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1072CarteiraDeCobrancaWorkspaceId != BC00362_A1072CarteiraDeCobrancaWorkspaceId[0] ) || ( Z1075CarteiraDeCobrancaCreatedAt != BC00362_A1075CarteiraDeCobrancaCreatedAt[0] ) || ( Z1076CarteiraDeCobrancaUpdatedAt != BC00362_A1076CarteiraDeCobrancaUpdatedAt[0] ) || ( StringUtil.StrCmp(Z1070CarteiraDeCobrancaCodigo, BC00362_A1070CarteiraDeCobrancaCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z1071CarteiraDeCobrancaNome, BC00362_A1071CarteiraDeCobrancaNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1073CarteiraDeCobrancaConvenio, BC00362_A1073CarteiraDeCobrancaConvenio[0]) != 0 ) || ( Z1074CarteiraDeCobrancaStatus != BC00362_A1074CarteiraDeCobrancaStatus[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CarteiraDeCobranca"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert36110( )
      {
         BeforeValidate36110( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable36110( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM36110( 0) ;
            CheckOptimisticConcurrency36110( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm36110( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert36110( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC003618 */
                     pr_default.execute(8, new Object[] {n1072CarteiraDeCobrancaWorkspaceId, A1072CarteiraDeCobrancaWorkspaceId, n1075CarteiraDeCobrancaCreatedAt, A1075CarteiraDeCobrancaCreatedAt, n1076CarteiraDeCobrancaUpdatedAt, A1076CarteiraDeCobrancaUpdatedAt, n1070CarteiraDeCobrancaCodigo, A1070CarteiraDeCobrancaCodigo, n1071CarteiraDeCobrancaNome, A1071CarteiraDeCobrancaNome, n1073CarteiraDeCobrancaConvenio, A1073CarteiraDeCobrancaConvenio, n1074CarteiraDeCobrancaStatus, A1074CarteiraDeCobrancaStatus});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC003619 */
                     pr_default.execute(9);
                     A1069CarteiraDeCobrancaId = BC003619_A1069CarteiraDeCobrancaId[0];
                     n1069CarteiraDeCobrancaId = BC003619_n1069CarteiraDeCobrancaId[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("CarteiraDeCobranca");
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
               Load36110( ) ;
            }
            EndLevel36110( ) ;
         }
         CloseExtendedTableCursors36110( ) ;
      }

      protected void Update36110( )
      {
         BeforeValidate36110( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable36110( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency36110( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm36110( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate36110( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC003620 */
                     pr_default.execute(10, new Object[] {n1072CarteiraDeCobrancaWorkspaceId, A1072CarteiraDeCobrancaWorkspaceId, n1075CarteiraDeCobrancaCreatedAt, A1075CarteiraDeCobrancaCreatedAt, n1076CarteiraDeCobrancaUpdatedAt, A1076CarteiraDeCobrancaUpdatedAt, n1070CarteiraDeCobrancaCodigo, A1070CarteiraDeCobrancaCodigo, n1071CarteiraDeCobrancaNome, A1071CarteiraDeCobrancaNome, n1073CarteiraDeCobrancaConvenio, A1073CarteiraDeCobrancaConvenio, n1074CarteiraDeCobrancaStatus, A1074CarteiraDeCobrancaStatus, n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("CarteiraDeCobranca");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarteiraDeCobranca"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate36110( ) ;
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
            EndLevel36110( ) ;
         }
         CloseExtendedTableCursors36110( ) ;
      }

      protected void DeferredUpdate36110( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate36110( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency36110( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls36110( ) ;
            AfterConfirm36110( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete36110( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC003621 */
                  pr_default.execute(11, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("CarteiraDeCobranca");
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
         sMode110 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel36110( ) ;
         Gx_mode = sMode110;
      }

      protected void OnDeleteControls36110( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC003623 */
            pr_default.execute(12, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               A1111CarteiraDeCobrancaValorTotal = BC003623_A1111CarteiraDeCobrancaValorTotal[0];
               A1112CarteiraDeCobrancaValorRecebido = BC003623_A1112CarteiraDeCobrancaValorRecebido[0];
               A1113CarteiraDeCobrancaTotalBoletos = BC003623_A1113CarteiraDeCobrancaTotalBoletos[0];
            }
            else
            {
               A1111CarteiraDeCobrancaValorTotal = 0;
               A1112CarteiraDeCobrancaValorRecebido = 0;
               A1113CarteiraDeCobrancaTotalBoletos = 0;
            }
            pr_default.close(12);
            /* Using cursor BC003625 */
            pr_default.execute(13, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003625_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003625_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            }
            else
            {
               A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
               n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
            }
            pr_default.close(13);
            /* Using cursor BC003627 */
            pr_default.execute(14, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               A1115CarteiraDeCobrancaTotalBoletosExpirados = BC003627_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
               n1115CarteiraDeCobrancaTotalBoletosExpirados = BC003627_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            }
            else
            {
               A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
               n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
            }
            pr_default.close(14);
            /* Using cursor BC003629 */
            pr_default.execute(15, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               A1116CarteiraDeCobrancaTotalBoletosCancelados = BC003629_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
               n1116CarteiraDeCobrancaTotalBoletosCancelados = BC003629_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            }
            else
            {
               A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
               n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
            }
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC003630 */
            pr_default.execute(16, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Boleto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel36110( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete36110( ) ;
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

      public void ScanKeyStart36110( )
      {
         /* Scan By routine */
         /* Using cursor BC003635 */
         pr_default.execute(17, new Object[] {n1069CarteiraDeCobrancaId, A1069CarteiraDeCobrancaId});
         RcdFound110 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound110 = 1;
            A1069CarteiraDeCobrancaId = BC003635_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = BC003635_n1069CarteiraDeCobrancaId[0];
            A1072CarteiraDeCobrancaWorkspaceId = BC003635_A1072CarteiraDeCobrancaWorkspaceId[0];
            n1072CarteiraDeCobrancaWorkspaceId = BC003635_n1072CarteiraDeCobrancaWorkspaceId[0];
            A1075CarteiraDeCobrancaCreatedAt = BC003635_A1075CarteiraDeCobrancaCreatedAt[0];
            n1075CarteiraDeCobrancaCreatedAt = BC003635_n1075CarteiraDeCobrancaCreatedAt[0];
            A1076CarteiraDeCobrancaUpdatedAt = BC003635_A1076CarteiraDeCobrancaUpdatedAt[0];
            n1076CarteiraDeCobrancaUpdatedAt = BC003635_n1076CarteiraDeCobrancaUpdatedAt[0];
            A1070CarteiraDeCobrancaCodigo = BC003635_A1070CarteiraDeCobrancaCodigo[0];
            n1070CarteiraDeCobrancaCodigo = BC003635_n1070CarteiraDeCobrancaCodigo[0];
            A1071CarteiraDeCobrancaNome = BC003635_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = BC003635_n1071CarteiraDeCobrancaNome[0];
            A1073CarteiraDeCobrancaConvenio = BC003635_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = BC003635_n1073CarteiraDeCobrancaConvenio[0];
            A1074CarteiraDeCobrancaStatus = BC003635_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = BC003635_n1074CarteiraDeCobrancaStatus[0];
            A1111CarteiraDeCobrancaValorTotal = BC003635_A1111CarteiraDeCobrancaValorTotal[0];
            A1112CarteiraDeCobrancaValorRecebido = BC003635_A1112CarteiraDeCobrancaValorRecebido[0];
            A1113CarteiraDeCobrancaTotalBoletos = BC003635_A1113CarteiraDeCobrancaTotalBoletos[0];
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003635_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003635_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            A1115CarteiraDeCobrancaTotalBoletosExpirados = BC003635_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = BC003635_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            A1116CarteiraDeCobrancaTotalBoletosCancelados = BC003635_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = BC003635_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext36110( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound110 = 0;
         ScanKeyLoad36110( ) ;
      }

      protected void ScanKeyLoad36110( )
      {
         sMode110 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound110 = 1;
            A1069CarteiraDeCobrancaId = BC003635_A1069CarteiraDeCobrancaId[0];
            n1069CarteiraDeCobrancaId = BC003635_n1069CarteiraDeCobrancaId[0];
            A1072CarteiraDeCobrancaWorkspaceId = BC003635_A1072CarteiraDeCobrancaWorkspaceId[0];
            n1072CarteiraDeCobrancaWorkspaceId = BC003635_n1072CarteiraDeCobrancaWorkspaceId[0];
            A1075CarteiraDeCobrancaCreatedAt = BC003635_A1075CarteiraDeCobrancaCreatedAt[0];
            n1075CarteiraDeCobrancaCreatedAt = BC003635_n1075CarteiraDeCobrancaCreatedAt[0];
            A1076CarteiraDeCobrancaUpdatedAt = BC003635_A1076CarteiraDeCobrancaUpdatedAt[0];
            n1076CarteiraDeCobrancaUpdatedAt = BC003635_n1076CarteiraDeCobrancaUpdatedAt[0];
            A1070CarteiraDeCobrancaCodigo = BC003635_A1070CarteiraDeCobrancaCodigo[0];
            n1070CarteiraDeCobrancaCodigo = BC003635_n1070CarteiraDeCobrancaCodigo[0];
            A1071CarteiraDeCobrancaNome = BC003635_A1071CarteiraDeCobrancaNome[0];
            n1071CarteiraDeCobrancaNome = BC003635_n1071CarteiraDeCobrancaNome[0];
            A1073CarteiraDeCobrancaConvenio = BC003635_A1073CarteiraDeCobrancaConvenio[0];
            n1073CarteiraDeCobrancaConvenio = BC003635_n1073CarteiraDeCobrancaConvenio[0];
            A1074CarteiraDeCobrancaStatus = BC003635_A1074CarteiraDeCobrancaStatus[0];
            n1074CarteiraDeCobrancaStatus = BC003635_n1074CarteiraDeCobrancaStatus[0];
            A1111CarteiraDeCobrancaValorTotal = BC003635_A1111CarteiraDeCobrancaValorTotal[0];
            A1112CarteiraDeCobrancaValorRecebido = BC003635_A1112CarteiraDeCobrancaValorRecebido[0];
            A1113CarteiraDeCobrancaTotalBoletos = BC003635_A1113CarteiraDeCobrancaTotalBoletos[0];
            A1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003635_A1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            n1114CarteiraDeCobrancaTotalBoletosRegistrados = BC003635_n1114CarteiraDeCobrancaTotalBoletosRegistrados[0];
            A1115CarteiraDeCobrancaTotalBoletosExpirados = BC003635_A1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            n1115CarteiraDeCobrancaTotalBoletosExpirados = BC003635_n1115CarteiraDeCobrancaTotalBoletosExpirados[0];
            A1116CarteiraDeCobrancaTotalBoletosCancelados = BC003635_A1116CarteiraDeCobrancaTotalBoletosCancelados[0];
            n1116CarteiraDeCobrancaTotalBoletosCancelados = BC003635_n1116CarteiraDeCobrancaTotalBoletosCancelados[0];
         }
         Gx_mode = sMode110;
      }

      protected void ScanKeyEnd36110( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm36110( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert36110( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate36110( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete36110( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete36110( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate36110( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes36110( )
      {
      }

      protected void send_integrity_lvl_hashes36110( )
      {
      }

      protected void AddRow36110( )
      {
         VarsToRow110( bcCarteiraDeCobranca) ;
      }

      protected void ReadRow36110( )
      {
         RowToVars110( bcCarteiraDeCobranca, 1) ;
      }

      protected void InitializeNonKey36110( )
      {
         A1075CarteiraDeCobrancaCreatedAt = (DateTime)(DateTime.MinValue);
         n1075CarteiraDeCobrancaCreatedAt = false;
         A1076CarteiraDeCobrancaUpdatedAt = (DateTime)(DateTime.MinValue);
         n1076CarteiraDeCobrancaUpdatedAt = false;
         A1070CarteiraDeCobrancaCodigo = "";
         n1070CarteiraDeCobrancaCodigo = false;
         A1071CarteiraDeCobrancaNome = "";
         n1071CarteiraDeCobrancaNome = false;
         A1073CarteiraDeCobrancaConvenio = "";
         n1073CarteiraDeCobrancaConvenio = false;
         A1111CarteiraDeCobrancaValorTotal = 0;
         A1112CarteiraDeCobrancaValorRecebido = 0;
         A1113CarteiraDeCobrancaTotalBoletos = 0;
         A1114CarteiraDeCobrancaTotalBoletosRegistrados = 0;
         n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
         A1115CarteiraDeCobrancaTotalBoletosExpirados = 0;
         n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
         A1116CarteiraDeCobrancaTotalBoletosCancelados = 0;
         n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
         A1072CarteiraDeCobrancaWorkspaceId = Guid.NewGuid( );
         n1072CarteiraDeCobrancaWorkspaceId = false;
         A1074CarteiraDeCobrancaStatus = true;
         n1074CarteiraDeCobrancaStatus = false;
         Z1072CarteiraDeCobrancaWorkspaceId = Guid.Empty;
         Z1075CarteiraDeCobrancaCreatedAt = (DateTime)(DateTime.MinValue);
         Z1076CarteiraDeCobrancaUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1070CarteiraDeCobrancaCodigo = "";
         Z1071CarteiraDeCobrancaNome = "";
         Z1073CarteiraDeCobrancaConvenio = "";
         Z1074CarteiraDeCobrancaStatus = false;
      }

      protected void InitAll36110( )
      {
         A1069CarteiraDeCobrancaId = 0;
         n1069CarteiraDeCobrancaId = false;
         InitializeNonKey36110( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1072CarteiraDeCobrancaWorkspaceId = i1072CarteiraDeCobrancaWorkspaceId;
         n1072CarteiraDeCobrancaWorkspaceId = false;
         A1075CarteiraDeCobrancaCreatedAt = i1075CarteiraDeCobrancaCreatedAt;
         n1075CarteiraDeCobrancaCreatedAt = false;
         A1074CarteiraDeCobrancaStatus = i1074CarteiraDeCobrancaStatus;
         n1074CarteiraDeCobrancaStatus = false;
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

      public void VarsToRow110( SdtCarteiraDeCobranca obj110 )
      {
         obj110.gxTpr_Mode = Gx_mode;
         obj110.gxTpr_Carteiradecobrancacreatedat = A1075CarteiraDeCobrancaCreatedAt;
         obj110.gxTpr_Carteiradecobrancaupdatedat = A1076CarteiraDeCobrancaUpdatedAt;
         obj110.gxTpr_Carteiradecobrancacodigo = A1070CarteiraDeCobrancaCodigo;
         obj110.gxTpr_Carteiradecobrancanome = A1071CarteiraDeCobrancaNome;
         obj110.gxTpr_Carteiradecobrancaconvenio = A1073CarteiraDeCobrancaConvenio;
         obj110.gxTpr_Carteiradecobrancavalortotal = A1111CarteiraDeCobrancaValorTotal;
         obj110.gxTpr_Carteiradecobrancavalorrecebido = A1112CarteiraDeCobrancaValorRecebido;
         obj110.gxTpr_Carteiradecobrancatotalboletos = A1113CarteiraDeCobrancaTotalBoletos;
         obj110.gxTpr_Carteiradecobrancatotalboletosregistrados = A1114CarteiraDeCobrancaTotalBoletosRegistrados;
         obj110.gxTpr_Carteiradecobrancatotalboletosexpirados = A1115CarteiraDeCobrancaTotalBoletosExpirados;
         obj110.gxTpr_Carteiradecobrancatotalboletoscancelados = A1116CarteiraDeCobrancaTotalBoletosCancelados;
         obj110.gxTpr_Carteiradecobrancaworkspaceid = A1072CarteiraDeCobrancaWorkspaceId;
         obj110.gxTpr_Carteiradecobrancastatus = A1074CarteiraDeCobrancaStatus;
         obj110.gxTpr_Carteiradecobrancaid = A1069CarteiraDeCobrancaId;
         obj110.gxTpr_Carteiradecobrancaid_Z = Z1069CarteiraDeCobrancaId;
         obj110.gxTpr_Carteiradecobrancacodigo_Z = Z1070CarteiraDeCobrancaCodigo;
         obj110.gxTpr_Carteiradecobrancanome_Z = Z1071CarteiraDeCobrancaNome;
         obj110.gxTpr_Carteiradecobrancaworkspaceid_Z = Z1072CarteiraDeCobrancaWorkspaceId;
         obj110.gxTpr_Carteiradecobrancaconvenio_Z = Z1073CarteiraDeCobrancaConvenio;
         obj110.gxTpr_Carteiradecobrancastatus_Z = Z1074CarteiraDeCobrancaStatus;
         obj110.gxTpr_Carteiradecobrancacreatedat_Z = Z1075CarteiraDeCobrancaCreatedAt;
         obj110.gxTpr_Carteiradecobrancaupdatedat_Z = Z1076CarteiraDeCobrancaUpdatedAt;
         obj110.gxTpr_Carteiradecobrancavalortotal_Z = Z1111CarteiraDeCobrancaValorTotal;
         obj110.gxTpr_Carteiradecobrancavalorrecebido_Z = Z1112CarteiraDeCobrancaValorRecebido;
         obj110.gxTpr_Carteiradecobrancatotalboletos_Z = Z1113CarteiraDeCobrancaTotalBoletos;
         obj110.gxTpr_Carteiradecobrancatotalboletosregistrados_Z = Z1114CarteiraDeCobrancaTotalBoletosRegistrados;
         obj110.gxTpr_Carteiradecobrancatotalboletosexpirados_Z = Z1115CarteiraDeCobrancaTotalBoletosExpirados;
         obj110.gxTpr_Carteiradecobrancatotalboletoscancelados_Z = Z1116CarteiraDeCobrancaTotalBoletosCancelados;
         obj110.gxTpr_Carteiradecobrancaid_N = (short)(Convert.ToInt16(n1069CarteiraDeCobrancaId));
         obj110.gxTpr_Carteiradecobrancacodigo_N = (short)(Convert.ToInt16(n1070CarteiraDeCobrancaCodigo));
         obj110.gxTpr_Carteiradecobrancanome_N = (short)(Convert.ToInt16(n1071CarteiraDeCobrancaNome));
         obj110.gxTpr_Carteiradecobrancaworkspaceid_N = (short)(Convert.ToInt16(n1072CarteiraDeCobrancaWorkspaceId));
         obj110.gxTpr_Carteiradecobrancaconvenio_N = (short)(Convert.ToInt16(n1073CarteiraDeCobrancaConvenio));
         obj110.gxTpr_Carteiradecobrancastatus_N = (short)(Convert.ToInt16(n1074CarteiraDeCobrancaStatus));
         obj110.gxTpr_Carteiradecobrancacreatedat_N = (short)(Convert.ToInt16(n1075CarteiraDeCobrancaCreatedAt));
         obj110.gxTpr_Carteiradecobrancaupdatedat_N = (short)(Convert.ToInt16(n1076CarteiraDeCobrancaUpdatedAt));
         obj110.gxTpr_Carteiradecobrancatotalboletosregistrados_N = (short)(Convert.ToInt16(n1114CarteiraDeCobrancaTotalBoletosRegistrados));
         obj110.gxTpr_Carteiradecobrancatotalboletosexpirados_N = (short)(Convert.ToInt16(n1115CarteiraDeCobrancaTotalBoletosExpirados));
         obj110.gxTpr_Carteiradecobrancatotalboletoscancelados_N = (short)(Convert.ToInt16(n1116CarteiraDeCobrancaTotalBoletosCancelados));
         obj110.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow110( SdtCarteiraDeCobranca obj110 )
      {
         obj110.gxTpr_Carteiradecobrancaid = A1069CarteiraDeCobrancaId;
         return  ;
      }

      public void RowToVars110( SdtCarteiraDeCobranca obj110 ,
                                int forceLoad )
      {
         Gx_mode = obj110.gxTpr_Mode;
         A1075CarteiraDeCobrancaCreatedAt = obj110.gxTpr_Carteiradecobrancacreatedat;
         n1075CarteiraDeCobrancaCreatedAt = false;
         A1076CarteiraDeCobrancaUpdatedAt = obj110.gxTpr_Carteiradecobrancaupdatedat;
         n1076CarteiraDeCobrancaUpdatedAt = false;
         A1070CarteiraDeCobrancaCodigo = obj110.gxTpr_Carteiradecobrancacodigo;
         n1070CarteiraDeCobrancaCodigo = false;
         A1071CarteiraDeCobrancaNome = obj110.gxTpr_Carteiradecobrancanome;
         n1071CarteiraDeCobrancaNome = false;
         A1073CarteiraDeCobrancaConvenio = obj110.gxTpr_Carteiradecobrancaconvenio;
         n1073CarteiraDeCobrancaConvenio = false;
         A1111CarteiraDeCobrancaValorTotal = obj110.gxTpr_Carteiradecobrancavalortotal;
         A1112CarteiraDeCobrancaValorRecebido = obj110.gxTpr_Carteiradecobrancavalorrecebido;
         A1113CarteiraDeCobrancaTotalBoletos = obj110.gxTpr_Carteiradecobrancatotalboletos;
         A1114CarteiraDeCobrancaTotalBoletosRegistrados = obj110.gxTpr_Carteiradecobrancatotalboletosregistrados;
         n1114CarteiraDeCobrancaTotalBoletosRegistrados = false;
         A1115CarteiraDeCobrancaTotalBoletosExpirados = obj110.gxTpr_Carteiradecobrancatotalboletosexpirados;
         n1115CarteiraDeCobrancaTotalBoletosExpirados = false;
         A1116CarteiraDeCobrancaTotalBoletosCancelados = obj110.gxTpr_Carteiradecobrancatotalboletoscancelados;
         n1116CarteiraDeCobrancaTotalBoletosCancelados = false;
         A1072CarteiraDeCobrancaWorkspaceId = obj110.gxTpr_Carteiradecobrancaworkspaceid;
         n1072CarteiraDeCobrancaWorkspaceId = false;
         A1074CarteiraDeCobrancaStatus = obj110.gxTpr_Carteiradecobrancastatus;
         n1074CarteiraDeCobrancaStatus = false;
         A1069CarteiraDeCobrancaId = obj110.gxTpr_Carteiradecobrancaid;
         n1069CarteiraDeCobrancaId = false;
         Z1069CarteiraDeCobrancaId = obj110.gxTpr_Carteiradecobrancaid_Z;
         Z1070CarteiraDeCobrancaCodigo = obj110.gxTpr_Carteiradecobrancacodigo_Z;
         Z1071CarteiraDeCobrancaNome = obj110.gxTpr_Carteiradecobrancanome_Z;
         Z1072CarteiraDeCobrancaWorkspaceId = obj110.gxTpr_Carteiradecobrancaworkspaceid_Z;
         Z1073CarteiraDeCobrancaConvenio = obj110.gxTpr_Carteiradecobrancaconvenio_Z;
         Z1074CarteiraDeCobrancaStatus = obj110.gxTpr_Carteiradecobrancastatus_Z;
         Z1075CarteiraDeCobrancaCreatedAt = obj110.gxTpr_Carteiradecobrancacreatedat_Z;
         Z1076CarteiraDeCobrancaUpdatedAt = obj110.gxTpr_Carteiradecobrancaupdatedat_Z;
         Z1111CarteiraDeCobrancaValorTotal = obj110.gxTpr_Carteiradecobrancavalortotal_Z;
         Z1112CarteiraDeCobrancaValorRecebido = obj110.gxTpr_Carteiradecobrancavalorrecebido_Z;
         Z1113CarteiraDeCobrancaTotalBoletos = obj110.gxTpr_Carteiradecobrancatotalboletos_Z;
         Z1114CarteiraDeCobrancaTotalBoletosRegistrados = obj110.gxTpr_Carteiradecobrancatotalboletosregistrados_Z;
         Z1115CarteiraDeCobrancaTotalBoletosExpirados = obj110.gxTpr_Carteiradecobrancatotalboletosexpirados_Z;
         Z1116CarteiraDeCobrancaTotalBoletosCancelados = obj110.gxTpr_Carteiradecobrancatotalboletoscancelados_Z;
         n1069CarteiraDeCobrancaId = (bool)(Convert.ToBoolean(obj110.gxTpr_Carteiradecobrancaid_N));
         n1070CarteiraDeCobrancaCodigo = (bool)(Convert.ToBoolean(obj110.gxTpr_Carteiradecobrancacodigo_N));
         n1071CarteiraDeCobrancaNome = (bool)(Convert.ToBoolean(obj110.gxTpr_Carteiradecobrancanome_N));
         n1072CarteiraDeCobrancaWorkspaceId = (bool)(Convert.ToBoolean(obj110.gxTpr_Carteiradecobrancaworkspaceid_N));
         n1073CarteiraDeCobrancaConvenio = (bool)(Convert.ToBoolean(obj110.gxTpr_Carteiradecobrancaconvenio_N));
         n1074CarteiraDeCobrancaStatus = (bool)(Convert.ToBoolean(obj110.gxTpr_Carteiradecobrancastatus_N));
         n1075CarteiraDeCobrancaCreatedAt = (bool)(Convert.ToBoolean(obj110.gxTpr_Carteiradecobrancacreatedat_N));
         n1076CarteiraDeCobrancaUpdatedAt = (bool)(Convert.ToBoolean(obj110.gxTpr_Carteiradecobrancaupdatedat_N));
         n1114CarteiraDeCobrancaTotalBoletosRegistrados = (bool)(Convert.ToBoolean(obj110.gxTpr_Carteiradecobrancatotalboletosregistrados_N));
         n1115CarteiraDeCobrancaTotalBoletosExpirados = (bool)(Convert.ToBoolean(obj110.gxTpr_Carteiradecobrancatotalboletosexpirados_N));
         n1116CarteiraDeCobrancaTotalBoletosCancelados = (bool)(Convert.ToBoolean(obj110.gxTpr_Carteiradecobrancatotalboletoscancelados_N));
         Gx_mode = obj110.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1069CarteiraDeCobrancaId = (int)getParm(obj,0);
         n1069CarteiraDeCobrancaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey36110( ) ;
         ScanKeyStart36110( ) ;
         if ( RcdFound110 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1069CarteiraDeCobrancaId = A1069CarteiraDeCobrancaId;
         }
         ZM36110( -8) ;
         OnLoadActions36110( ) ;
         AddRow36110( ) ;
         ScanKeyEnd36110( ) ;
         if ( RcdFound110 == 0 )
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
         RowToVars110( bcCarteiraDeCobranca, 0) ;
         ScanKeyStart36110( ) ;
         if ( RcdFound110 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1069CarteiraDeCobrancaId = A1069CarteiraDeCobrancaId;
         }
         ZM36110( -8) ;
         OnLoadActions36110( ) ;
         AddRow36110( ) ;
         ScanKeyEnd36110( ) ;
         if ( RcdFound110 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey36110( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert36110( ) ;
         }
         else
         {
            if ( RcdFound110 == 1 )
            {
               if ( A1069CarteiraDeCobrancaId != Z1069CarteiraDeCobrancaId )
               {
                  A1069CarteiraDeCobrancaId = Z1069CarteiraDeCobrancaId;
                  n1069CarteiraDeCobrancaId = false;
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
                  Update36110( ) ;
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
                  if ( A1069CarteiraDeCobrancaId != Z1069CarteiraDeCobrancaId )
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
                        Insert36110( ) ;
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
                        Insert36110( ) ;
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
         RowToVars110( bcCarteiraDeCobranca, 1) ;
         SaveImpl( ) ;
         VarsToRow110( bcCarteiraDeCobranca) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars110( bcCarteiraDeCobranca, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert36110( ) ;
         AfterTrn( ) ;
         VarsToRow110( bcCarteiraDeCobranca) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow110( bcCarteiraDeCobranca) ;
         }
         else
         {
            SdtCarteiraDeCobranca auxBC = new SdtCarteiraDeCobranca(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1069CarteiraDeCobrancaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCarteiraDeCobranca);
               auxBC.Save();
               bcCarteiraDeCobranca.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars110( bcCarteiraDeCobranca, 1) ;
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
         RowToVars110( bcCarteiraDeCobranca, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert36110( ) ;
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
               VarsToRow110( bcCarteiraDeCobranca) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow110( bcCarteiraDeCobranca) ;
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
         RowToVars110( bcCarteiraDeCobranca, 0) ;
         GetKey36110( ) ;
         if ( RcdFound110 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1069CarteiraDeCobrancaId != Z1069CarteiraDeCobrancaId )
            {
               A1069CarteiraDeCobrancaId = Z1069CarteiraDeCobrancaId;
               n1069CarteiraDeCobrancaId = false;
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
            if ( A1069CarteiraDeCobrancaId != Z1069CarteiraDeCobrancaId )
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
         context.RollbackDataStores("carteiradecobranca_bc",pr_default);
         VarsToRow110( bcCarteiraDeCobranca) ;
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
         Gx_mode = bcCarteiraDeCobranca.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCarteiraDeCobranca.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCarteiraDeCobranca )
         {
            bcCarteiraDeCobranca = (SdtCarteiraDeCobranca)(sdt);
            if ( StringUtil.StrCmp(bcCarteiraDeCobranca.gxTpr_Mode, "") == 0 )
            {
               bcCarteiraDeCobranca.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow110( bcCarteiraDeCobranca) ;
            }
            else
            {
               RowToVars110( bcCarteiraDeCobranca, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCarteiraDeCobranca.gxTpr_Mode, "") == 0 )
            {
               bcCarteiraDeCobranca.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars110( bcCarteiraDeCobranca, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCarteiraDeCobranca CarteiraDeCobranca_BC
      {
         get {
            return bcCarteiraDeCobranca ;
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
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z1072CarteiraDeCobrancaWorkspaceId = Guid.Empty;
         A1072CarteiraDeCobrancaWorkspaceId = Guid.Empty;
         Z1075CarteiraDeCobrancaCreatedAt = (DateTime)(DateTime.MinValue);
         A1075CarteiraDeCobrancaCreatedAt = (DateTime)(DateTime.MinValue);
         Z1076CarteiraDeCobrancaUpdatedAt = (DateTime)(DateTime.MinValue);
         A1076CarteiraDeCobrancaUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1070CarteiraDeCobrancaCodigo = "";
         A1070CarteiraDeCobrancaCodigo = "";
         Z1071CarteiraDeCobrancaNome = "";
         A1071CarteiraDeCobrancaNome = "";
         Z1073CarteiraDeCobrancaConvenio = "";
         A1073CarteiraDeCobrancaConvenio = "";
         BC003616_A1069CarteiraDeCobrancaId = new int[1] ;
         BC003616_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         BC003616_A1072CarteiraDeCobrancaWorkspaceId = new Guid[] {Guid.Empty} ;
         BC003616_n1072CarteiraDeCobrancaWorkspaceId = new bool[] {false} ;
         BC003616_A1075CarteiraDeCobrancaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003616_n1075CarteiraDeCobrancaCreatedAt = new bool[] {false} ;
         BC003616_A1076CarteiraDeCobrancaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003616_n1076CarteiraDeCobrancaUpdatedAt = new bool[] {false} ;
         BC003616_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         BC003616_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         BC003616_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         BC003616_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         BC003616_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         BC003616_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         BC003616_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC003616_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC003616_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         BC003616_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         BC003616_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         BC003616_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         BC003616_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         BC003616_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         BC003616_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         BC003616_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         BC003616_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         BC00365_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         BC00365_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         BC00365_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         BC00367_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         BC00367_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         BC00369_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         BC00369_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         BC003611_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         BC003611_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         BC003617_A1069CarteiraDeCobrancaId = new int[1] ;
         BC003617_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         BC00363_A1069CarteiraDeCobrancaId = new int[1] ;
         BC00363_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         BC00363_A1072CarteiraDeCobrancaWorkspaceId = new Guid[] {Guid.Empty} ;
         BC00363_n1072CarteiraDeCobrancaWorkspaceId = new bool[] {false} ;
         BC00363_A1075CarteiraDeCobrancaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00363_n1075CarteiraDeCobrancaCreatedAt = new bool[] {false} ;
         BC00363_A1076CarteiraDeCobrancaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00363_n1076CarteiraDeCobrancaUpdatedAt = new bool[] {false} ;
         BC00363_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         BC00363_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         BC00363_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         BC00363_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         BC00363_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         BC00363_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         BC00363_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC00363_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         sMode110 = "";
         BC00362_A1069CarteiraDeCobrancaId = new int[1] ;
         BC00362_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         BC00362_A1072CarteiraDeCobrancaWorkspaceId = new Guid[] {Guid.Empty} ;
         BC00362_n1072CarteiraDeCobrancaWorkspaceId = new bool[] {false} ;
         BC00362_A1075CarteiraDeCobrancaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00362_n1075CarteiraDeCobrancaCreatedAt = new bool[] {false} ;
         BC00362_A1076CarteiraDeCobrancaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00362_n1076CarteiraDeCobrancaUpdatedAt = new bool[] {false} ;
         BC00362_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         BC00362_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         BC00362_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         BC00362_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         BC00362_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         BC00362_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         BC00362_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC00362_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC003619_A1069CarteiraDeCobrancaId = new int[1] ;
         BC003619_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         BC003623_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         BC003623_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         BC003623_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         BC003625_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         BC003625_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         BC003627_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         BC003627_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         BC003629_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         BC003629_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         BC003630_A1077BoletosId = new int[1] ;
         BC003635_A1069CarteiraDeCobrancaId = new int[1] ;
         BC003635_n1069CarteiraDeCobrancaId = new bool[] {false} ;
         BC003635_A1072CarteiraDeCobrancaWorkspaceId = new Guid[] {Guid.Empty} ;
         BC003635_n1072CarteiraDeCobrancaWorkspaceId = new bool[] {false} ;
         BC003635_A1075CarteiraDeCobrancaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003635_n1075CarteiraDeCobrancaCreatedAt = new bool[] {false} ;
         BC003635_A1076CarteiraDeCobrancaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003635_n1076CarteiraDeCobrancaUpdatedAt = new bool[] {false} ;
         BC003635_A1070CarteiraDeCobrancaCodigo = new string[] {""} ;
         BC003635_n1070CarteiraDeCobrancaCodigo = new bool[] {false} ;
         BC003635_A1071CarteiraDeCobrancaNome = new string[] {""} ;
         BC003635_n1071CarteiraDeCobrancaNome = new bool[] {false} ;
         BC003635_A1073CarteiraDeCobrancaConvenio = new string[] {""} ;
         BC003635_n1073CarteiraDeCobrancaConvenio = new bool[] {false} ;
         BC003635_A1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC003635_n1074CarteiraDeCobrancaStatus = new bool[] {false} ;
         BC003635_A1111CarteiraDeCobrancaValorTotal = new decimal[1] ;
         BC003635_A1112CarteiraDeCobrancaValorRecebido = new decimal[1] ;
         BC003635_A1113CarteiraDeCobrancaTotalBoletos = new int[1] ;
         BC003635_A1114CarteiraDeCobrancaTotalBoletosRegistrados = new int[1] ;
         BC003635_n1114CarteiraDeCobrancaTotalBoletosRegistrados = new bool[] {false} ;
         BC003635_A1115CarteiraDeCobrancaTotalBoletosExpirados = new int[1] ;
         BC003635_n1115CarteiraDeCobrancaTotalBoletosExpirados = new bool[] {false} ;
         BC003635_A1116CarteiraDeCobrancaTotalBoletosCancelados = new int[1] ;
         BC003635_n1116CarteiraDeCobrancaTotalBoletosCancelados = new bool[] {false} ;
         i1072CarteiraDeCobrancaWorkspaceId = Guid.Empty;
         i1075CarteiraDeCobrancaCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.carteiradecobranca_bc__default(),
            new Object[][] {
                new Object[] {
               BC00362_A1069CarteiraDeCobrancaId, BC00362_A1072CarteiraDeCobrancaWorkspaceId, BC00362_n1072CarteiraDeCobrancaWorkspaceId, BC00362_A1075CarteiraDeCobrancaCreatedAt, BC00362_n1075CarteiraDeCobrancaCreatedAt, BC00362_A1076CarteiraDeCobrancaUpdatedAt, BC00362_n1076CarteiraDeCobrancaUpdatedAt, BC00362_A1070CarteiraDeCobrancaCodigo, BC00362_n1070CarteiraDeCobrancaCodigo, BC00362_A1071CarteiraDeCobrancaNome,
               BC00362_n1071CarteiraDeCobrancaNome, BC00362_A1073CarteiraDeCobrancaConvenio, BC00362_n1073CarteiraDeCobrancaConvenio, BC00362_A1074CarteiraDeCobrancaStatus, BC00362_n1074CarteiraDeCobrancaStatus
               }
               , new Object[] {
               BC00363_A1069CarteiraDeCobrancaId, BC00363_A1072CarteiraDeCobrancaWorkspaceId, BC00363_n1072CarteiraDeCobrancaWorkspaceId, BC00363_A1075CarteiraDeCobrancaCreatedAt, BC00363_n1075CarteiraDeCobrancaCreatedAt, BC00363_A1076CarteiraDeCobrancaUpdatedAt, BC00363_n1076CarteiraDeCobrancaUpdatedAt, BC00363_A1070CarteiraDeCobrancaCodigo, BC00363_n1070CarteiraDeCobrancaCodigo, BC00363_A1071CarteiraDeCobrancaNome,
               BC00363_n1071CarteiraDeCobrancaNome, BC00363_A1073CarteiraDeCobrancaConvenio, BC00363_n1073CarteiraDeCobrancaConvenio, BC00363_A1074CarteiraDeCobrancaStatus, BC00363_n1074CarteiraDeCobrancaStatus
               }
               , new Object[] {
               BC00365_A1111CarteiraDeCobrancaValorTotal, BC00365_A1112CarteiraDeCobrancaValorRecebido, BC00365_A1113CarteiraDeCobrancaTotalBoletos
               }
               , new Object[] {
               BC00367_A1114CarteiraDeCobrancaTotalBoletosRegistrados, BC00367_n1114CarteiraDeCobrancaTotalBoletosRegistrados
               }
               , new Object[] {
               BC00369_A1115CarteiraDeCobrancaTotalBoletosExpirados, BC00369_n1115CarteiraDeCobrancaTotalBoletosExpirados
               }
               , new Object[] {
               BC003611_A1116CarteiraDeCobrancaTotalBoletosCancelados, BC003611_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               BC003616_A1069CarteiraDeCobrancaId, BC003616_A1072CarteiraDeCobrancaWorkspaceId, BC003616_n1072CarteiraDeCobrancaWorkspaceId, BC003616_A1075CarteiraDeCobrancaCreatedAt, BC003616_n1075CarteiraDeCobrancaCreatedAt, BC003616_A1076CarteiraDeCobrancaUpdatedAt, BC003616_n1076CarteiraDeCobrancaUpdatedAt, BC003616_A1070CarteiraDeCobrancaCodigo, BC003616_n1070CarteiraDeCobrancaCodigo, BC003616_A1071CarteiraDeCobrancaNome,
               BC003616_n1071CarteiraDeCobrancaNome, BC003616_A1073CarteiraDeCobrancaConvenio, BC003616_n1073CarteiraDeCobrancaConvenio, BC003616_A1074CarteiraDeCobrancaStatus, BC003616_n1074CarteiraDeCobrancaStatus, BC003616_A1111CarteiraDeCobrancaValorTotal, BC003616_A1112CarteiraDeCobrancaValorRecebido, BC003616_A1113CarteiraDeCobrancaTotalBoletos, BC003616_A1114CarteiraDeCobrancaTotalBoletosRegistrados, BC003616_n1114CarteiraDeCobrancaTotalBoletosRegistrados,
               BC003616_A1115CarteiraDeCobrancaTotalBoletosExpirados, BC003616_n1115CarteiraDeCobrancaTotalBoletosExpirados, BC003616_A1116CarteiraDeCobrancaTotalBoletosCancelados, BC003616_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               BC003617_A1069CarteiraDeCobrancaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC003619_A1069CarteiraDeCobrancaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC003623_A1111CarteiraDeCobrancaValorTotal, BC003623_A1112CarteiraDeCobrancaValorRecebido, BC003623_A1113CarteiraDeCobrancaTotalBoletos
               }
               , new Object[] {
               BC003625_A1114CarteiraDeCobrancaTotalBoletosRegistrados, BC003625_n1114CarteiraDeCobrancaTotalBoletosRegistrados
               }
               , new Object[] {
               BC003627_A1115CarteiraDeCobrancaTotalBoletosExpirados, BC003627_n1115CarteiraDeCobrancaTotalBoletosExpirados
               }
               , new Object[] {
               BC003629_A1116CarteiraDeCobrancaTotalBoletosCancelados, BC003629_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
               , new Object[] {
               BC003630_A1077BoletosId
               }
               , new Object[] {
               BC003635_A1069CarteiraDeCobrancaId, BC003635_A1072CarteiraDeCobrancaWorkspaceId, BC003635_n1072CarteiraDeCobrancaWorkspaceId, BC003635_A1075CarteiraDeCobrancaCreatedAt, BC003635_n1075CarteiraDeCobrancaCreatedAt, BC003635_A1076CarteiraDeCobrancaUpdatedAt, BC003635_n1076CarteiraDeCobrancaUpdatedAt, BC003635_A1070CarteiraDeCobrancaCodigo, BC003635_n1070CarteiraDeCobrancaCodigo, BC003635_A1071CarteiraDeCobrancaNome,
               BC003635_n1071CarteiraDeCobrancaNome, BC003635_A1073CarteiraDeCobrancaConvenio, BC003635_n1073CarteiraDeCobrancaConvenio, BC003635_A1074CarteiraDeCobrancaStatus, BC003635_n1074CarteiraDeCobrancaStatus, BC003635_A1111CarteiraDeCobrancaValorTotal, BC003635_A1112CarteiraDeCobrancaValorRecebido, BC003635_A1113CarteiraDeCobrancaTotalBoletos, BC003635_A1114CarteiraDeCobrancaTotalBoletosRegistrados, BC003635_n1114CarteiraDeCobrancaTotalBoletosRegistrados,
               BC003635_A1115CarteiraDeCobrancaTotalBoletosExpirados, BC003635_n1115CarteiraDeCobrancaTotalBoletosExpirados, BC003635_A1116CarteiraDeCobrancaTotalBoletosCancelados, BC003635_n1116CarteiraDeCobrancaTotalBoletosCancelados
               }
            }
         );
         Z1072CarteiraDeCobrancaWorkspaceId = Guid.NewGuid( );
         n1072CarteiraDeCobrancaWorkspaceId = false;
         A1072CarteiraDeCobrancaWorkspaceId = Guid.NewGuid( );
         n1072CarteiraDeCobrancaWorkspaceId = false;
         i1072CarteiraDeCobrancaWorkspaceId = Guid.NewGuid( );
         n1072CarteiraDeCobrancaWorkspaceId = false;
         Z1074CarteiraDeCobrancaStatus = true;
         n1074CarteiraDeCobrancaStatus = false;
         A1074CarteiraDeCobrancaStatus = true;
         n1074CarteiraDeCobrancaStatus = false;
         i1074CarteiraDeCobrancaStatus = true;
         n1074CarteiraDeCobrancaStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12362 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound110 ;
      private int trnEnded ;
      private int Z1069CarteiraDeCobrancaId ;
      private int A1069CarteiraDeCobrancaId ;
      private int Z1113CarteiraDeCobrancaTotalBoletos ;
      private int A1113CarteiraDeCobrancaTotalBoletos ;
      private int Z1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int Z1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int Z1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private decimal Z1111CarteiraDeCobrancaValorTotal ;
      private decimal A1111CarteiraDeCobrancaValorTotal ;
      private decimal Z1112CarteiraDeCobrancaValorRecebido ;
      private decimal A1112CarteiraDeCobrancaValorRecebido ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode110 ;
      private DateTime Z1075CarteiraDeCobrancaCreatedAt ;
      private DateTime A1075CarteiraDeCobrancaCreatedAt ;
      private DateTime Z1076CarteiraDeCobrancaUpdatedAt ;
      private DateTime A1076CarteiraDeCobrancaUpdatedAt ;
      private DateTime i1075CarteiraDeCobrancaCreatedAt ;
      private bool returnInSub ;
      private bool Z1074CarteiraDeCobrancaStatus ;
      private bool A1074CarteiraDeCobrancaStatus ;
      private bool n1072CarteiraDeCobrancaWorkspaceId ;
      private bool n1075CarteiraDeCobrancaCreatedAt ;
      private bool n1076CarteiraDeCobrancaUpdatedAt ;
      private bool n1074CarteiraDeCobrancaStatus ;
      private bool n1069CarteiraDeCobrancaId ;
      private bool n1070CarteiraDeCobrancaCodigo ;
      private bool n1071CarteiraDeCobrancaNome ;
      private bool n1073CarteiraDeCobrancaConvenio ;
      private bool n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool Gx_longc ;
      private bool i1074CarteiraDeCobrancaStatus ;
      private string Z1070CarteiraDeCobrancaCodigo ;
      private string A1070CarteiraDeCobrancaCodigo ;
      private string Z1071CarteiraDeCobrancaNome ;
      private string A1071CarteiraDeCobrancaNome ;
      private string Z1073CarteiraDeCobrancaConvenio ;
      private string A1073CarteiraDeCobrancaConvenio ;
      private Guid Z1072CarteiraDeCobrancaWorkspaceId ;
      private Guid A1072CarteiraDeCobrancaWorkspaceId ;
      private Guid i1072CarteiraDeCobrancaWorkspaceId ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC003616_A1069CarteiraDeCobrancaId ;
      private bool[] BC003616_n1069CarteiraDeCobrancaId ;
      private Guid[] BC003616_A1072CarteiraDeCobrancaWorkspaceId ;
      private bool[] BC003616_n1072CarteiraDeCobrancaWorkspaceId ;
      private DateTime[] BC003616_A1075CarteiraDeCobrancaCreatedAt ;
      private bool[] BC003616_n1075CarteiraDeCobrancaCreatedAt ;
      private DateTime[] BC003616_A1076CarteiraDeCobrancaUpdatedAt ;
      private bool[] BC003616_n1076CarteiraDeCobrancaUpdatedAt ;
      private string[] BC003616_A1070CarteiraDeCobrancaCodigo ;
      private bool[] BC003616_n1070CarteiraDeCobrancaCodigo ;
      private string[] BC003616_A1071CarteiraDeCobrancaNome ;
      private bool[] BC003616_n1071CarteiraDeCobrancaNome ;
      private string[] BC003616_A1073CarteiraDeCobrancaConvenio ;
      private bool[] BC003616_n1073CarteiraDeCobrancaConvenio ;
      private bool[] BC003616_A1074CarteiraDeCobrancaStatus ;
      private bool[] BC003616_n1074CarteiraDeCobrancaStatus ;
      private decimal[] BC003616_A1111CarteiraDeCobrancaValorTotal ;
      private decimal[] BC003616_A1112CarteiraDeCobrancaValorRecebido ;
      private int[] BC003616_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] BC003616_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] BC003616_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] BC003616_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] BC003616_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] BC003616_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] BC003616_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private decimal[] BC00365_A1111CarteiraDeCobrancaValorTotal ;
      private decimal[] BC00365_A1112CarteiraDeCobrancaValorRecebido ;
      private int[] BC00365_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] BC00367_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] BC00367_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] BC00369_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] BC00369_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] BC003611_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] BC003611_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int[] BC003617_A1069CarteiraDeCobrancaId ;
      private bool[] BC003617_n1069CarteiraDeCobrancaId ;
      private int[] BC00363_A1069CarteiraDeCobrancaId ;
      private bool[] BC00363_n1069CarteiraDeCobrancaId ;
      private Guid[] BC00363_A1072CarteiraDeCobrancaWorkspaceId ;
      private bool[] BC00363_n1072CarteiraDeCobrancaWorkspaceId ;
      private DateTime[] BC00363_A1075CarteiraDeCobrancaCreatedAt ;
      private bool[] BC00363_n1075CarteiraDeCobrancaCreatedAt ;
      private DateTime[] BC00363_A1076CarteiraDeCobrancaUpdatedAt ;
      private bool[] BC00363_n1076CarteiraDeCobrancaUpdatedAt ;
      private string[] BC00363_A1070CarteiraDeCobrancaCodigo ;
      private bool[] BC00363_n1070CarteiraDeCobrancaCodigo ;
      private string[] BC00363_A1071CarteiraDeCobrancaNome ;
      private bool[] BC00363_n1071CarteiraDeCobrancaNome ;
      private string[] BC00363_A1073CarteiraDeCobrancaConvenio ;
      private bool[] BC00363_n1073CarteiraDeCobrancaConvenio ;
      private bool[] BC00363_A1074CarteiraDeCobrancaStatus ;
      private bool[] BC00363_n1074CarteiraDeCobrancaStatus ;
      private int[] BC00362_A1069CarteiraDeCobrancaId ;
      private bool[] BC00362_n1069CarteiraDeCobrancaId ;
      private Guid[] BC00362_A1072CarteiraDeCobrancaWorkspaceId ;
      private bool[] BC00362_n1072CarteiraDeCobrancaWorkspaceId ;
      private DateTime[] BC00362_A1075CarteiraDeCobrancaCreatedAt ;
      private bool[] BC00362_n1075CarteiraDeCobrancaCreatedAt ;
      private DateTime[] BC00362_A1076CarteiraDeCobrancaUpdatedAt ;
      private bool[] BC00362_n1076CarteiraDeCobrancaUpdatedAt ;
      private string[] BC00362_A1070CarteiraDeCobrancaCodigo ;
      private bool[] BC00362_n1070CarteiraDeCobrancaCodigo ;
      private string[] BC00362_A1071CarteiraDeCobrancaNome ;
      private bool[] BC00362_n1071CarteiraDeCobrancaNome ;
      private string[] BC00362_A1073CarteiraDeCobrancaConvenio ;
      private bool[] BC00362_n1073CarteiraDeCobrancaConvenio ;
      private bool[] BC00362_A1074CarteiraDeCobrancaStatus ;
      private bool[] BC00362_n1074CarteiraDeCobrancaStatus ;
      private int[] BC003619_A1069CarteiraDeCobrancaId ;
      private bool[] BC003619_n1069CarteiraDeCobrancaId ;
      private decimal[] BC003623_A1111CarteiraDeCobrancaValorTotal ;
      private decimal[] BC003623_A1112CarteiraDeCobrancaValorRecebido ;
      private int[] BC003623_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] BC003625_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] BC003625_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] BC003627_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] BC003627_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] BC003629_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] BC003629_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private int[] BC003630_A1077BoletosId ;
      private int[] BC003635_A1069CarteiraDeCobrancaId ;
      private bool[] BC003635_n1069CarteiraDeCobrancaId ;
      private Guid[] BC003635_A1072CarteiraDeCobrancaWorkspaceId ;
      private bool[] BC003635_n1072CarteiraDeCobrancaWorkspaceId ;
      private DateTime[] BC003635_A1075CarteiraDeCobrancaCreatedAt ;
      private bool[] BC003635_n1075CarteiraDeCobrancaCreatedAt ;
      private DateTime[] BC003635_A1076CarteiraDeCobrancaUpdatedAt ;
      private bool[] BC003635_n1076CarteiraDeCobrancaUpdatedAt ;
      private string[] BC003635_A1070CarteiraDeCobrancaCodigo ;
      private bool[] BC003635_n1070CarteiraDeCobrancaCodigo ;
      private string[] BC003635_A1071CarteiraDeCobrancaNome ;
      private bool[] BC003635_n1071CarteiraDeCobrancaNome ;
      private string[] BC003635_A1073CarteiraDeCobrancaConvenio ;
      private bool[] BC003635_n1073CarteiraDeCobrancaConvenio ;
      private bool[] BC003635_A1074CarteiraDeCobrancaStatus ;
      private bool[] BC003635_n1074CarteiraDeCobrancaStatus ;
      private decimal[] BC003635_A1111CarteiraDeCobrancaValorTotal ;
      private decimal[] BC003635_A1112CarteiraDeCobrancaValorRecebido ;
      private int[] BC003635_A1113CarteiraDeCobrancaTotalBoletos ;
      private int[] BC003635_A1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private bool[] BC003635_n1114CarteiraDeCobrancaTotalBoletosRegistrados ;
      private int[] BC003635_A1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private bool[] BC003635_n1115CarteiraDeCobrancaTotalBoletosExpirados ;
      private int[] BC003635_A1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private bool[] BC003635_n1116CarteiraDeCobrancaTotalBoletosCancelados ;
      private SdtCarteiraDeCobranca bcCarteiraDeCobranca ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class carteiradecobranca_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00362;
          prmBC00362 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00363;
          prmBC00363 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00365;
          prmBC00365 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00367;
          prmBC00367 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00369;
          prmBC00369 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003611;
          prmBC003611 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003616;
          prmBC003616 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC003616;
          cmdBufferBC003616=" SELECT TM1.CarteiraDeCobrancaId, TM1.CarteiraDeCobrancaWorkspaceId, TM1.CarteiraDeCobrancaCreatedAt, TM1.CarteiraDeCobrancaUpdatedAt, TM1.CarteiraDeCobrancaCodigo, TM1.CarteiraDeCobrancaNome, TM1.CarteiraDeCobrancaConvenio, TM1.CarteiraDeCobrancaStatus, COALESCE( T2.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T2.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T2.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos, COALESCE( T3.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados, COALESCE( T4.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados, COALESCE( T5.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM ((((CarteiraDeCobranca TM1 LEFT JOIN LATERAL (SELECT SUM(BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, CarteiraDeCobrancaId, SUM(BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto WHERE TM1.CarteiraDeCobrancaId = CarteiraDeCobrancaId GROUP BY CarteiraDeCobrancaId ) T2 ON T2.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE (TM1.CarteiraDeCobrancaId = CarteiraDeCobrancaId) AND (BoletosStatus = ( 'REGISTRADO')) GROUP BY CarteiraDeCobrancaId ) T3 ON T3.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE (TM1.CarteiraDeCobrancaId = CarteiraDeCobrancaId) AND (BoletosStatus = ( 'VENCIDO')) GROUP BY CarteiraDeCobrancaId ) T4 ON T4.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, "
          + " CarteiraDeCobrancaId FROM Boleto WHERE (TM1.CarteiraDeCobrancaId = CarteiraDeCobrancaId) AND (BoletosStatus = ( 'BAIXADO')) GROUP BY CarteiraDeCobrancaId ) T5 ON T5.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) WHERE TM1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ORDER BY TM1.CarteiraDeCobrancaId" ;
          Object[] prmBC003617;
          prmBC003617 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003618;
          prmBC003618 = new Object[] {
          new ParDef("CarteiraDeCobrancaWorkspaceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaCodigo",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaConvenio",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaStatus",GXType.Boolean,4,0){Nullable=true}
          };
          Object[] prmBC003619;
          prmBC003619 = new Object[] {
          };
          Object[] prmBC003620;
          prmBC003620 = new Object[] {
          new ParDef("CarteiraDeCobrancaWorkspaceId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaCodigo",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaConvenio",GXType.VarChar,20,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003621;
          prmBC003621 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003623;
          prmBC003623 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003625;
          prmBC003625 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003627;
          prmBC003627 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003629;
          prmBC003629 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003630;
          prmBC003630 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003635;
          prmBC003635 = new Object[] {
          new ParDef("CarteiraDeCobrancaId",GXType.Int32,9,0){Nullable=true}
          };
          string cmdBufferBC003635;
          cmdBufferBC003635=" SELECT TM1.CarteiraDeCobrancaId, TM1.CarteiraDeCobrancaWorkspaceId, TM1.CarteiraDeCobrancaCreatedAt, TM1.CarteiraDeCobrancaUpdatedAt, TM1.CarteiraDeCobrancaCodigo, TM1.CarteiraDeCobrancaNome, TM1.CarteiraDeCobrancaConvenio, TM1.CarteiraDeCobrancaStatus, COALESCE( T2.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T2.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T2.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos, COALESCE( T3.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados, COALESCE( T4.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados, COALESCE( T5.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM ((((CarteiraDeCobranca TM1 LEFT JOIN LATERAL (SELECT SUM(BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, CarteiraDeCobrancaId, SUM(BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto WHERE TM1.CarteiraDeCobrancaId = CarteiraDeCobrancaId GROUP BY CarteiraDeCobrancaId ) T2 ON T2.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE (TM1.CarteiraDeCobrancaId = CarteiraDeCobrancaId) AND (BoletosStatus = ( 'REGISTRADO')) GROUP BY CarteiraDeCobrancaId ) T3 ON T3.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE (TM1.CarteiraDeCobrancaId = CarteiraDeCobrancaId) AND (BoletosStatus = ( 'VENCIDO')) GROUP BY CarteiraDeCobrancaId ) T4 ON T4.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) LEFT JOIN LATERAL (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, "
          + " CarteiraDeCobrancaId FROM Boleto WHERE (TM1.CarteiraDeCobrancaId = CarteiraDeCobrancaId) AND (BoletosStatus = ( 'BAIXADO')) GROUP BY CarteiraDeCobrancaId ) T5 ON T5.CarteiraDeCobrancaId = TM1.CarteiraDeCobrancaId) WHERE TM1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ORDER BY TM1.CarteiraDeCobrancaId" ;
          def= new CursorDef[] {
              new CursorDef("BC00362", "SELECT CarteiraDeCobrancaId, CarteiraDeCobrancaWorkspaceId, CarteiraDeCobrancaCreatedAt, CarteiraDeCobrancaUpdatedAt, CarteiraDeCobrancaCodigo, CarteiraDeCobrancaNome, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaStatus FROM CarteiraDeCobranca WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId  FOR UPDATE OF CarteiraDeCobranca",true, GxErrorMask.GX_NOMASK, false, this,prmBC00362,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00363", "SELECT CarteiraDeCobrancaId, CarteiraDeCobrancaWorkspaceId, CarteiraDeCobrancaCreatedAt, CarteiraDeCobrancaUpdatedAt, CarteiraDeCobrancaCodigo, CarteiraDeCobrancaNome, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaStatus FROM CarteiraDeCobranca WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00363,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00365", "SELECT COALESCE( T1.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T1.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos FROM (SELECT SUM(BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, CarteiraDeCobrancaId, SUM(BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00365,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00367", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'REGISTRADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00367,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00369", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'VENCIDO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00369,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003611", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'BAIXADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003611,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003616", cmdBufferBC003616,true, GxErrorMask.GX_NOMASK, false, this,prmBC003616,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003617", "SELECT CarteiraDeCobrancaId FROM CarteiraDeCobranca WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003617,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003618", "SAVEPOINT gxupdate;INSERT INTO CarteiraDeCobranca(CarteiraDeCobrancaWorkspaceId, CarteiraDeCobrancaCreatedAt, CarteiraDeCobrancaUpdatedAt, CarteiraDeCobrancaCodigo, CarteiraDeCobrancaNome, CarteiraDeCobrancaConvenio, CarteiraDeCobrancaStatus) VALUES(:CarteiraDeCobrancaWorkspaceId, :CarteiraDeCobrancaCreatedAt, :CarteiraDeCobrancaUpdatedAt, :CarteiraDeCobrancaCodigo, :CarteiraDeCobrancaNome, :CarteiraDeCobrancaConvenio, :CarteiraDeCobrancaStatus);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC003618)
             ,new CursorDef("BC003619", "SELECT currval('CarteiraDeCobrancaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003619,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003620", "SAVEPOINT gxupdate;UPDATE CarteiraDeCobranca SET CarteiraDeCobrancaWorkspaceId=:CarteiraDeCobrancaWorkspaceId, CarteiraDeCobrancaCreatedAt=:CarteiraDeCobrancaCreatedAt, CarteiraDeCobrancaUpdatedAt=:CarteiraDeCobrancaUpdatedAt, CarteiraDeCobrancaCodigo=:CarteiraDeCobrancaCodigo, CarteiraDeCobrancaNome=:CarteiraDeCobrancaNome, CarteiraDeCobrancaConvenio=:CarteiraDeCobrancaConvenio, CarteiraDeCobrancaStatus=:CarteiraDeCobrancaStatus  WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003620)
             ,new CursorDef("BC003621", "SAVEPOINT gxupdate;DELETE FROM CarteiraDeCobranca  WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003621)
             ,new CursorDef("BC003623", "SELECT COALESCE( T1.CarteiraDeCobrancaValorTotal, 0) AS CarteiraDeCobrancaValorTotal, COALESCE( T1.CarteiraDeCobrancaValorRecebido, 0) AS CarteiraDeCobrancaValorRecebido, COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletos FROM (SELECT SUM(BoletosValorNominal) AS CarteiraDeCobrancaValorTotal, CarteiraDeCobrancaId, SUM(BoletosValorPago) AS CarteiraDeCobrancaValorRecebido, COUNT(*) AS CarteiraDeCobrancaTotalBoletos FROM Boleto GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003623,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003625", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosRegistrados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'REGISTRADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003625,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003627", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosExpirados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'VENCIDO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003627,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003629", "SELECT COALESCE( T1.CarteiraDeCobrancaTotalBoletos, 0) AS CarteiraDeCobrancaTotalBoletosCancelados FROM (SELECT COUNT(*) AS CarteiraDeCobrancaTotalBoletos, CarteiraDeCobrancaId FROM Boleto WHERE BoletosStatus = ( 'BAIXADO') GROUP BY CarteiraDeCobrancaId ) T1 WHERE T1.CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003629,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003630", "SELECT BoletosId FROM Boleto WHERE CarteiraDeCobrancaId = :CarteiraDeCobrancaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003630,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC003635", cmdBufferBC003635,true, GxErrorMask.GX_NOMASK, false, this,prmBC003635,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(10);
                ((int[]) buf[17])[0] = rslt.getInt(11);
                ((int[]) buf[18])[0] = rslt.getInt(12);
                ((bool[]) buf[19])[0] = rslt.wasNull(12);
                ((int[]) buf[20])[0] = rslt.getInt(13);
                ((bool[]) buf[21])[0] = rslt.wasNull(13);
                ((int[]) buf[22])[0] = rslt.getInt(14);
                ((bool[]) buf[23])[0] = rslt.wasNull(14);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(10);
                ((int[]) buf[17])[0] = rslt.getInt(11);
                ((int[]) buf[18])[0] = rslt.getInt(12);
                ((bool[]) buf[19])[0] = rslt.wasNull(12);
                ((int[]) buf[20])[0] = rslt.getInt(13);
                ((bool[]) buf[21])[0] = rslt.wasNull(13);
                ((int[]) buf[22])[0] = rslt.getInt(14);
                ((bool[]) buf[23])[0] = rslt.wasNull(14);
                return;
       }
    }

 }

}
