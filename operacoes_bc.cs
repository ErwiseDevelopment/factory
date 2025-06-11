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
   public class operacoes_bc : GxSilentTrn, IGxSilentTrn
   {
      public operacoes_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacoes_bc( IGxContext context )
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
         ReadRow31105( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey31105( ) ;
         standaloneModal( ) ;
         AddRow31105( ) ;
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
               Z1010OperacoesId = A1010OperacoesId;
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

      protected void CONFIRM_310( )
      {
         BeforeValidate31105( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls31105( ) ;
            }
            else
            {
               CheckExtendedTable31105( ) ;
               if ( AnyError == 0 )
               {
                  ZM31105( 3) ;
                  ZM31105( 4) ;
               }
               CloseExtendedTableCursors31105( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM31105( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z1011OperacoesData = A1011OperacoesData;
            Z1012OperacoesStatus = A1012OperacoesStatus;
            Z1015OperacoesTaxaEfetiva = A1015OperacoesTaxaEfetiva;
            Z1016OperacoesTaxaMora = A1016OperacoesTaxaMora;
            Z1047OperacoesFator = A1047OperacoesFator;
            Z1048OperacoesTipoTarifa = A1048OperacoesTipoTarifa;
            Z1049OperacoesTarifa = A1049OperacoesTarifa;
            Z1017OperacoesCreatedAt = A1017OperacoesCreatedAt;
            Z1018OperacoesUpdateAt = A1018OperacoesUpdateAt;
            Z168ClienteId = A168ClienteId;
            Z227ContratoId = A227ContratoId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z228ContratoNome = A228ContratoNome;
         }
         if ( GX_JID == -2 )
         {
            Z1010OperacoesId = A1010OperacoesId;
            Z1011OperacoesData = A1011OperacoesData;
            Z1012OperacoesStatus = A1012OperacoesStatus;
            Z1015OperacoesTaxaEfetiva = A1015OperacoesTaxaEfetiva;
            Z1016OperacoesTaxaMora = A1016OperacoesTaxaMora;
            Z1047OperacoesFator = A1047OperacoesFator;
            Z1048OperacoesTipoTarifa = A1048OperacoesTipoTarifa;
            Z1049OperacoesTarifa = A1049OperacoesTarifa;
            Z1017OperacoesCreatedAt = A1017OperacoesCreatedAt;
            Z1018OperacoesUpdateAt = A1018OperacoesUpdateAt;
            Z168ClienteId = A168ClienteId;
            Z227ContratoId = A227ContratoId;
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
            Z228ContratoNome = A228ContratoNome;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load31105( )
      {
         /* Using cursor BC00316 */
         pr_default.execute(4, new Object[] {n1010OperacoesId, A1010OperacoesId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound105 = 1;
            A170ClienteRazaoSocial = BC00316_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC00316_n170ClienteRazaoSocial[0];
            A1011OperacoesData = BC00316_A1011OperacoesData[0];
            n1011OperacoesData = BC00316_n1011OperacoesData[0];
            A1012OperacoesStatus = BC00316_A1012OperacoesStatus[0];
            n1012OperacoesStatus = BC00316_n1012OperacoesStatus[0];
            A1015OperacoesTaxaEfetiva = BC00316_A1015OperacoesTaxaEfetiva[0];
            n1015OperacoesTaxaEfetiva = BC00316_n1015OperacoesTaxaEfetiva[0];
            A1016OperacoesTaxaMora = BC00316_A1016OperacoesTaxaMora[0];
            n1016OperacoesTaxaMora = BC00316_n1016OperacoesTaxaMora[0];
            A1047OperacoesFator = BC00316_A1047OperacoesFator[0];
            n1047OperacoesFator = BC00316_n1047OperacoesFator[0];
            A1048OperacoesTipoTarifa = BC00316_A1048OperacoesTipoTarifa[0];
            n1048OperacoesTipoTarifa = BC00316_n1048OperacoesTipoTarifa[0];
            A1049OperacoesTarifa = BC00316_A1049OperacoesTarifa[0];
            n1049OperacoesTarifa = BC00316_n1049OperacoesTarifa[0];
            A228ContratoNome = BC00316_A228ContratoNome[0];
            n228ContratoNome = BC00316_n228ContratoNome[0];
            A1017OperacoesCreatedAt = BC00316_A1017OperacoesCreatedAt[0];
            n1017OperacoesCreatedAt = BC00316_n1017OperacoesCreatedAt[0];
            A1018OperacoesUpdateAt = BC00316_A1018OperacoesUpdateAt[0];
            n1018OperacoesUpdateAt = BC00316_n1018OperacoesUpdateAt[0];
            A168ClienteId = BC00316_A168ClienteId[0];
            n168ClienteId = BC00316_n168ClienteId[0];
            A227ContratoId = BC00316_A227ContratoId[0];
            n227ContratoId = BC00316_n227ContratoId[0];
            ZM31105( -2) ;
         }
         pr_default.close(4);
         OnLoadActions31105( ) ;
      }

      protected void OnLoadActions31105( )
      {
      }

      protected void CheckExtendedTable31105( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00314 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
            }
         }
         A170ClienteRazaoSocial = BC00314_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = BC00314_n170ClienteRazaoSocial[0];
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A1012OperacoesStatus, "PENDENTE") == 0 ) || ( StringUtil.StrCmp(A1012OperacoesStatus, "APROVADA") == 0 ) || ( StringUtil.StrCmp(A1012OperacoesStatus, "RECUSADA") == 0 ) || ( StringUtil.StrCmp(A1012OperacoesStatus, "LIQUIDADA") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1012OperacoesStatus)) ) )
         {
            GX_msglist.addItem("Campo Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00315 */
         pr_default.execute(3, new Object[] {n227ContratoId, A227ContratoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A227ContratoId) ) )
            {
               GX_msglist.addItem("Não existe 'Contrato'.", "ForeignKeyNotFound", 1, "CONTRATOID");
               AnyError = 1;
            }
         }
         A228ContratoNome = BC00315_A228ContratoNome[0];
         n228ContratoNome = BC00315_n228ContratoNome[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors31105( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey31105( )
      {
         /* Using cursor BC00317 */
         pr_default.execute(5, new Object[] {n1010OperacoesId, A1010OperacoesId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound105 = 1;
         }
         else
         {
            RcdFound105 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00313 */
         pr_default.execute(1, new Object[] {n1010OperacoesId, A1010OperacoesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM31105( 2) ;
            RcdFound105 = 1;
            A1010OperacoesId = BC00313_A1010OperacoesId[0];
            n1010OperacoesId = BC00313_n1010OperacoesId[0];
            A1011OperacoesData = BC00313_A1011OperacoesData[0];
            n1011OperacoesData = BC00313_n1011OperacoesData[0];
            A1012OperacoesStatus = BC00313_A1012OperacoesStatus[0];
            n1012OperacoesStatus = BC00313_n1012OperacoesStatus[0];
            A1015OperacoesTaxaEfetiva = BC00313_A1015OperacoesTaxaEfetiva[0];
            n1015OperacoesTaxaEfetiva = BC00313_n1015OperacoesTaxaEfetiva[0];
            A1016OperacoesTaxaMora = BC00313_A1016OperacoesTaxaMora[0];
            n1016OperacoesTaxaMora = BC00313_n1016OperacoesTaxaMora[0];
            A1047OperacoesFator = BC00313_A1047OperacoesFator[0];
            n1047OperacoesFator = BC00313_n1047OperacoesFator[0];
            A1048OperacoesTipoTarifa = BC00313_A1048OperacoesTipoTarifa[0];
            n1048OperacoesTipoTarifa = BC00313_n1048OperacoesTipoTarifa[0];
            A1049OperacoesTarifa = BC00313_A1049OperacoesTarifa[0];
            n1049OperacoesTarifa = BC00313_n1049OperacoesTarifa[0];
            A1017OperacoesCreatedAt = BC00313_A1017OperacoesCreatedAt[0];
            n1017OperacoesCreatedAt = BC00313_n1017OperacoesCreatedAt[0];
            A1018OperacoesUpdateAt = BC00313_A1018OperacoesUpdateAt[0];
            n1018OperacoesUpdateAt = BC00313_n1018OperacoesUpdateAt[0];
            A168ClienteId = BC00313_A168ClienteId[0];
            n168ClienteId = BC00313_n168ClienteId[0];
            A227ContratoId = BC00313_A227ContratoId[0];
            n227ContratoId = BC00313_n227ContratoId[0];
            Z1010OperacoesId = A1010OperacoesId;
            sMode105 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load31105( ) ;
            if ( AnyError == 1 )
            {
               RcdFound105 = 0;
               InitializeNonKey31105( ) ;
            }
            Gx_mode = sMode105;
         }
         else
         {
            RcdFound105 = 0;
            InitializeNonKey31105( ) ;
            sMode105 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode105;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey31105( ) ;
         if ( RcdFound105 == 0 )
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
         CONFIRM_310( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency31105( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00312 */
            pr_default.execute(0, new Object[] {n1010OperacoesId, A1010OperacoesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Operacoes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1011OperacoesData ) != DateTimeUtil.ResetTime ( BC00312_A1011OperacoesData[0] ) ) || ( StringUtil.StrCmp(Z1012OperacoesStatus, BC00312_A1012OperacoesStatus[0]) != 0 ) || ( Z1015OperacoesTaxaEfetiva != BC00312_A1015OperacoesTaxaEfetiva[0] ) || ( Z1016OperacoesTaxaMora != BC00312_A1016OperacoesTaxaMora[0] ) || ( Z1047OperacoesFator != BC00312_A1047OperacoesFator[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1048OperacoesTipoTarifa, BC00312_A1048OperacoesTipoTarifa[0]) != 0 ) || ( Z1049OperacoesTarifa != BC00312_A1049OperacoesTarifa[0] ) || ( Z1017OperacoesCreatedAt != BC00312_A1017OperacoesCreatedAt[0] ) || ( Z1018OperacoesUpdateAt != BC00312_A1018OperacoesUpdateAt[0] ) || ( Z168ClienteId != BC00312_A168ClienteId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z227ContratoId != BC00312_A227ContratoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Operacoes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert31105( )
      {
         BeforeValidate31105( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable31105( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM31105( 0) ;
            CheckOptimisticConcurrency31105( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm31105( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert31105( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00318 */
                     pr_default.execute(6, new Object[] {n1011OperacoesData, A1011OperacoesData, n1012OperacoesStatus, A1012OperacoesStatus, n1015OperacoesTaxaEfetiva, A1015OperacoesTaxaEfetiva, n1016OperacoesTaxaMora, A1016OperacoesTaxaMora, n1047OperacoesFator, A1047OperacoesFator, n1048OperacoesTipoTarifa, A1048OperacoesTipoTarifa, n1049OperacoesTarifa, A1049OperacoesTarifa, n1017OperacoesCreatedAt, A1017OperacoesCreatedAt, n1018OperacoesUpdateAt, A1018OperacoesUpdateAt, n168ClienteId, A168ClienteId, n227ContratoId, A227ContratoId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00319 */
                     pr_default.execute(7);
                     A1010OperacoesId = BC00319_A1010OperacoesId[0];
                     n1010OperacoesId = BC00319_n1010OperacoesId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Operacoes");
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
               Load31105( ) ;
            }
            EndLevel31105( ) ;
         }
         CloseExtendedTableCursors31105( ) ;
      }

      protected void Update31105( )
      {
         BeforeValidate31105( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable31105( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency31105( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm31105( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate31105( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC003110 */
                     pr_default.execute(8, new Object[] {n1011OperacoesData, A1011OperacoesData, n1012OperacoesStatus, A1012OperacoesStatus, n1015OperacoesTaxaEfetiva, A1015OperacoesTaxaEfetiva, n1016OperacoesTaxaMora, A1016OperacoesTaxaMora, n1047OperacoesFator, A1047OperacoesFator, n1048OperacoesTipoTarifa, A1048OperacoesTipoTarifa, n1049OperacoesTarifa, A1049OperacoesTarifa, n1017OperacoesCreatedAt, A1017OperacoesCreatedAt, n1018OperacoesUpdateAt, A1018OperacoesUpdateAt, n168ClienteId, A168ClienteId, n227ContratoId, A227ContratoId, n1010OperacoesId, A1010OperacoesId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Operacoes");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Operacoes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate31105( ) ;
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
            EndLevel31105( ) ;
         }
         CloseExtendedTableCursors31105( ) ;
      }

      protected void DeferredUpdate31105( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate31105( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency31105( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls31105( ) ;
            AfterConfirm31105( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete31105( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC003111 */
                  pr_default.execute(9, new Object[] {n1010OperacoesId, A1010OperacoesId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Operacoes");
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
         sMode105 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel31105( ) ;
         Gx_mode = sMode105;
      }

      protected void OnDeleteControls31105( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC003112 */
            pr_default.execute(10, new Object[] {n168ClienteId, A168ClienteId});
            A170ClienteRazaoSocial = BC003112_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC003112_n170ClienteRazaoSocial[0];
            pr_default.close(10);
            /* Using cursor BC003113 */
            pr_default.execute(11, new Object[] {n227ContratoId, A227ContratoId});
            A228ContratoNome = BC003113_A228ContratoNome[0];
            n228ContratoNome = BC003113_n228ContratoNome[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC003114 */
            pr_default.execute(12, new Object[] {n1010OperacoesId, A1010OperacoesId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"OperacoesTitulos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel31105( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete31105( ) ;
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

      public void ScanKeyStart31105( )
      {
         /* Using cursor BC003115 */
         pr_default.execute(13, new Object[] {n1010OperacoesId, A1010OperacoesId});
         RcdFound105 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound105 = 1;
            A1010OperacoesId = BC003115_A1010OperacoesId[0];
            n1010OperacoesId = BC003115_n1010OperacoesId[0];
            A170ClienteRazaoSocial = BC003115_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC003115_n170ClienteRazaoSocial[0];
            A1011OperacoesData = BC003115_A1011OperacoesData[0];
            n1011OperacoesData = BC003115_n1011OperacoesData[0];
            A1012OperacoesStatus = BC003115_A1012OperacoesStatus[0];
            n1012OperacoesStatus = BC003115_n1012OperacoesStatus[0];
            A1015OperacoesTaxaEfetiva = BC003115_A1015OperacoesTaxaEfetiva[0];
            n1015OperacoesTaxaEfetiva = BC003115_n1015OperacoesTaxaEfetiva[0];
            A1016OperacoesTaxaMora = BC003115_A1016OperacoesTaxaMora[0];
            n1016OperacoesTaxaMora = BC003115_n1016OperacoesTaxaMora[0];
            A1047OperacoesFator = BC003115_A1047OperacoesFator[0];
            n1047OperacoesFator = BC003115_n1047OperacoesFator[0];
            A1048OperacoesTipoTarifa = BC003115_A1048OperacoesTipoTarifa[0];
            n1048OperacoesTipoTarifa = BC003115_n1048OperacoesTipoTarifa[0];
            A1049OperacoesTarifa = BC003115_A1049OperacoesTarifa[0];
            n1049OperacoesTarifa = BC003115_n1049OperacoesTarifa[0];
            A228ContratoNome = BC003115_A228ContratoNome[0];
            n228ContratoNome = BC003115_n228ContratoNome[0];
            A1017OperacoesCreatedAt = BC003115_A1017OperacoesCreatedAt[0];
            n1017OperacoesCreatedAt = BC003115_n1017OperacoesCreatedAt[0];
            A1018OperacoesUpdateAt = BC003115_A1018OperacoesUpdateAt[0];
            n1018OperacoesUpdateAt = BC003115_n1018OperacoesUpdateAt[0];
            A168ClienteId = BC003115_A168ClienteId[0];
            n168ClienteId = BC003115_n168ClienteId[0];
            A227ContratoId = BC003115_A227ContratoId[0];
            n227ContratoId = BC003115_n227ContratoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext31105( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound105 = 0;
         ScanKeyLoad31105( ) ;
      }

      protected void ScanKeyLoad31105( )
      {
         sMode105 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound105 = 1;
            A1010OperacoesId = BC003115_A1010OperacoesId[0];
            n1010OperacoesId = BC003115_n1010OperacoesId[0];
            A170ClienteRazaoSocial = BC003115_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC003115_n170ClienteRazaoSocial[0];
            A1011OperacoesData = BC003115_A1011OperacoesData[0];
            n1011OperacoesData = BC003115_n1011OperacoesData[0];
            A1012OperacoesStatus = BC003115_A1012OperacoesStatus[0];
            n1012OperacoesStatus = BC003115_n1012OperacoesStatus[0];
            A1015OperacoesTaxaEfetiva = BC003115_A1015OperacoesTaxaEfetiva[0];
            n1015OperacoesTaxaEfetiva = BC003115_n1015OperacoesTaxaEfetiva[0];
            A1016OperacoesTaxaMora = BC003115_A1016OperacoesTaxaMora[0];
            n1016OperacoesTaxaMora = BC003115_n1016OperacoesTaxaMora[0];
            A1047OperacoesFator = BC003115_A1047OperacoesFator[0];
            n1047OperacoesFator = BC003115_n1047OperacoesFator[0];
            A1048OperacoesTipoTarifa = BC003115_A1048OperacoesTipoTarifa[0];
            n1048OperacoesTipoTarifa = BC003115_n1048OperacoesTipoTarifa[0];
            A1049OperacoesTarifa = BC003115_A1049OperacoesTarifa[0];
            n1049OperacoesTarifa = BC003115_n1049OperacoesTarifa[0];
            A228ContratoNome = BC003115_A228ContratoNome[0];
            n228ContratoNome = BC003115_n228ContratoNome[0];
            A1017OperacoesCreatedAt = BC003115_A1017OperacoesCreatedAt[0];
            n1017OperacoesCreatedAt = BC003115_n1017OperacoesCreatedAt[0];
            A1018OperacoesUpdateAt = BC003115_A1018OperacoesUpdateAt[0];
            n1018OperacoesUpdateAt = BC003115_n1018OperacoesUpdateAt[0];
            A168ClienteId = BC003115_A168ClienteId[0];
            n168ClienteId = BC003115_n168ClienteId[0];
            A227ContratoId = BC003115_A227ContratoId[0];
            n227ContratoId = BC003115_n227ContratoId[0];
         }
         Gx_mode = sMode105;
      }

      protected void ScanKeyEnd31105( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm31105( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert31105( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate31105( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete31105( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete31105( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate31105( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes31105( )
      {
      }

      protected void send_integrity_lvl_hashes31105( )
      {
      }

      protected void AddRow31105( )
      {
         VarsToRow105( bcOperacoes) ;
      }

      protected void ReadRow31105( )
      {
         RowToVars105( bcOperacoes, 1) ;
      }

      protected void InitializeNonKey31105( )
      {
         A168ClienteId = 0;
         n168ClienteId = false;
         A170ClienteRazaoSocial = "";
         n170ClienteRazaoSocial = false;
         A1011OperacoesData = DateTime.MinValue;
         n1011OperacoesData = false;
         A1012OperacoesStatus = "";
         n1012OperacoesStatus = false;
         A1015OperacoesTaxaEfetiva = 0;
         n1015OperacoesTaxaEfetiva = false;
         A227ContratoId = 0;
         n227ContratoId = false;
         A1016OperacoesTaxaMora = 0;
         n1016OperacoesTaxaMora = false;
         A1047OperacoesFator = 0;
         n1047OperacoesFator = false;
         A1048OperacoesTipoTarifa = "";
         n1048OperacoesTipoTarifa = false;
         A1049OperacoesTarifa = 0;
         n1049OperacoesTarifa = false;
         A228ContratoNome = "";
         n228ContratoNome = false;
         A1017OperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         n1017OperacoesCreatedAt = false;
         A1018OperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         n1018OperacoesUpdateAt = false;
         Z1011OperacoesData = DateTime.MinValue;
         Z1012OperacoesStatus = "";
         Z1015OperacoesTaxaEfetiva = 0;
         Z1016OperacoesTaxaMora = 0;
         Z1047OperacoesFator = 0;
         Z1048OperacoesTipoTarifa = "";
         Z1049OperacoesTarifa = 0;
         Z1017OperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         Z1018OperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         Z168ClienteId = 0;
         Z227ContratoId = 0;
      }

      protected void InitAll31105( )
      {
         A1010OperacoesId = 0;
         n1010OperacoesId = false;
         InitializeNonKey31105( ) ;
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

      public void VarsToRow105( SdtOperacoes obj105 )
      {
         obj105.gxTpr_Mode = Gx_mode;
         obj105.gxTpr_Clienteid = A168ClienteId;
         obj105.gxTpr_Clienterazaosocial = A170ClienteRazaoSocial;
         obj105.gxTpr_Operacoesdata = A1011OperacoesData;
         obj105.gxTpr_Operacoesstatus = A1012OperacoesStatus;
         obj105.gxTpr_Operacoestaxaefetiva = A1015OperacoesTaxaEfetiva;
         obj105.gxTpr_Contratoid = A227ContratoId;
         obj105.gxTpr_Operacoestaxamora = A1016OperacoesTaxaMora;
         obj105.gxTpr_Operacoesfator = A1047OperacoesFator;
         obj105.gxTpr_Operacoestipotarifa = A1048OperacoesTipoTarifa;
         obj105.gxTpr_Operacoestarifa = A1049OperacoesTarifa;
         obj105.gxTpr_Contratonome = A228ContratoNome;
         obj105.gxTpr_Operacoescreatedat = A1017OperacoesCreatedAt;
         obj105.gxTpr_Operacoesupdateat = A1018OperacoesUpdateAt;
         obj105.gxTpr_Operacoesid = A1010OperacoesId;
         obj105.gxTpr_Operacoesid_Z = Z1010OperacoesId;
         obj105.gxTpr_Clienteid_Z = Z168ClienteId;
         obj105.gxTpr_Clienterazaosocial_Z = Z170ClienteRazaoSocial;
         obj105.gxTpr_Operacoesdata_Z = Z1011OperacoesData;
         obj105.gxTpr_Operacoesstatus_Z = Z1012OperacoesStatus;
         obj105.gxTpr_Operacoestaxaefetiva_Z = Z1015OperacoesTaxaEfetiva;
         obj105.gxTpr_Contratoid_Z = Z227ContratoId;
         obj105.gxTpr_Operacoestaxamora_Z = Z1016OperacoesTaxaMora;
         obj105.gxTpr_Operacoesfator_Z = Z1047OperacoesFator;
         obj105.gxTpr_Operacoestipotarifa_Z = Z1048OperacoesTipoTarifa;
         obj105.gxTpr_Operacoestarifa_Z = Z1049OperacoesTarifa;
         obj105.gxTpr_Contratonome_Z = Z228ContratoNome;
         obj105.gxTpr_Operacoescreatedat_Z = Z1017OperacoesCreatedAt;
         obj105.gxTpr_Operacoesupdateat_Z = Z1018OperacoesUpdateAt;
         obj105.gxTpr_Operacoesid_N = (short)(Convert.ToInt16(n1010OperacoesId));
         obj105.gxTpr_Clienteid_N = (short)(Convert.ToInt16(n168ClienteId));
         obj105.gxTpr_Clienterazaosocial_N = (short)(Convert.ToInt16(n170ClienteRazaoSocial));
         obj105.gxTpr_Operacoesdata_N = (short)(Convert.ToInt16(n1011OperacoesData));
         obj105.gxTpr_Operacoesstatus_N = (short)(Convert.ToInt16(n1012OperacoesStatus));
         obj105.gxTpr_Operacoestaxaefetiva_N = (short)(Convert.ToInt16(n1015OperacoesTaxaEfetiva));
         obj105.gxTpr_Contratoid_N = (short)(Convert.ToInt16(n227ContratoId));
         obj105.gxTpr_Operacoestaxamora_N = (short)(Convert.ToInt16(n1016OperacoesTaxaMora));
         obj105.gxTpr_Operacoesfator_N = (short)(Convert.ToInt16(n1047OperacoesFator));
         obj105.gxTpr_Operacoestipotarifa_N = (short)(Convert.ToInt16(n1048OperacoesTipoTarifa));
         obj105.gxTpr_Operacoestarifa_N = (short)(Convert.ToInt16(n1049OperacoesTarifa));
         obj105.gxTpr_Contratonome_N = (short)(Convert.ToInt16(n228ContratoNome));
         obj105.gxTpr_Operacoescreatedat_N = (short)(Convert.ToInt16(n1017OperacoesCreatedAt));
         obj105.gxTpr_Operacoesupdateat_N = (short)(Convert.ToInt16(n1018OperacoesUpdateAt));
         obj105.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow105( SdtOperacoes obj105 )
      {
         obj105.gxTpr_Operacoesid = A1010OperacoesId;
         return  ;
      }

      public void RowToVars105( SdtOperacoes obj105 ,
                                int forceLoad )
      {
         Gx_mode = obj105.gxTpr_Mode;
         A168ClienteId = obj105.gxTpr_Clienteid;
         n168ClienteId = false;
         A170ClienteRazaoSocial = obj105.gxTpr_Clienterazaosocial;
         n170ClienteRazaoSocial = false;
         A1011OperacoesData = obj105.gxTpr_Operacoesdata;
         n1011OperacoesData = false;
         A1012OperacoesStatus = obj105.gxTpr_Operacoesstatus;
         n1012OperacoesStatus = false;
         A1015OperacoesTaxaEfetiva = obj105.gxTpr_Operacoestaxaefetiva;
         n1015OperacoesTaxaEfetiva = false;
         A227ContratoId = obj105.gxTpr_Contratoid;
         n227ContratoId = false;
         A1016OperacoesTaxaMora = obj105.gxTpr_Operacoestaxamora;
         n1016OperacoesTaxaMora = false;
         A1047OperacoesFator = obj105.gxTpr_Operacoesfator;
         n1047OperacoesFator = false;
         A1048OperacoesTipoTarifa = obj105.gxTpr_Operacoestipotarifa;
         n1048OperacoesTipoTarifa = false;
         A1049OperacoesTarifa = obj105.gxTpr_Operacoestarifa;
         n1049OperacoesTarifa = false;
         A228ContratoNome = obj105.gxTpr_Contratonome;
         n228ContratoNome = false;
         A1017OperacoesCreatedAt = obj105.gxTpr_Operacoescreatedat;
         n1017OperacoesCreatedAt = false;
         A1018OperacoesUpdateAt = obj105.gxTpr_Operacoesupdateat;
         n1018OperacoesUpdateAt = false;
         A1010OperacoesId = obj105.gxTpr_Operacoesid;
         n1010OperacoesId = false;
         Z1010OperacoesId = obj105.gxTpr_Operacoesid_Z;
         Z168ClienteId = obj105.gxTpr_Clienteid_Z;
         Z170ClienteRazaoSocial = obj105.gxTpr_Clienterazaosocial_Z;
         Z1011OperacoesData = obj105.gxTpr_Operacoesdata_Z;
         Z1012OperacoesStatus = obj105.gxTpr_Operacoesstatus_Z;
         Z1015OperacoesTaxaEfetiva = obj105.gxTpr_Operacoestaxaefetiva_Z;
         Z227ContratoId = obj105.gxTpr_Contratoid_Z;
         Z1016OperacoesTaxaMora = obj105.gxTpr_Operacoestaxamora_Z;
         Z1047OperacoesFator = obj105.gxTpr_Operacoesfator_Z;
         Z1048OperacoesTipoTarifa = obj105.gxTpr_Operacoestipotarifa_Z;
         Z1049OperacoesTarifa = obj105.gxTpr_Operacoestarifa_Z;
         Z228ContratoNome = obj105.gxTpr_Contratonome_Z;
         Z1017OperacoesCreatedAt = obj105.gxTpr_Operacoescreatedat_Z;
         Z1018OperacoesUpdateAt = obj105.gxTpr_Operacoesupdateat_Z;
         n1010OperacoesId = (bool)(Convert.ToBoolean(obj105.gxTpr_Operacoesid_N));
         n168ClienteId = (bool)(Convert.ToBoolean(obj105.gxTpr_Clienteid_N));
         n170ClienteRazaoSocial = (bool)(Convert.ToBoolean(obj105.gxTpr_Clienterazaosocial_N));
         n1011OperacoesData = (bool)(Convert.ToBoolean(obj105.gxTpr_Operacoesdata_N));
         n1012OperacoesStatus = (bool)(Convert.ToBoolean(obj105.gxTpr_Operacoesstatus_N));
         n1015OperacoesTaxaEfetiva = (bool)(Convert.ToBoolean(obj105.gxTpr_Operacoestaxaefetiva_N));
         n227ContratoId = (bool)(Convert.ToBoolean(obj105.gxTpr_Contratoid_N));
         n1016OperacoesTaxaMora = (bool)(Convert.ToBoolean(obj105.gxTpr_Operacoestaxamora_N));
         n1047OperacoesFator = (bool)(Convert.ToBoolean(obj105.gxTpr_Operacoesfator_N));
         n1048OperacoesTipoTarifa = (bool)(Convert.ToBoolean(obj105.gxTpr_Operacoestipotarifa_N));
         n1049OperacoesTarifa = (bool)(Convert.ToBoolean(obj105.gxTpr_Operacoestarifa_N));
         n228ContratoNome = (bool)(Convert.ToBoolean(obj105.gxTpr_Contratonome_N));
         n1017OperacoesCreatedAt = (bool)(Convert.ToBoolean(obj105.gxTpr_Operacoescreatedat_N));
         n1018OperacoesUpdateAt = (bool)(Convert.ToBoolean(obj105.gxTpr_Operacoesupdateat_N));
         Gx_mode = obj105.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1010OperacoesId = (int)getParm(obj,0);
         n1010OperacoesId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey31105( ) ;
         ScanKeyStart31105( ) ;
         if ( RcdFound105 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1010OperacoesId = A1010OperacoesId;
         }
         ZM31105( -2) ;
         OnLoadActions31105( ) ;
         AddRow31105( ) ;
         ScanKeyEnd31105( ) ;
         if ( RcdFound105 == 0 )
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
         RowToVars105( bcOperacoes, 0) ;
         ScanKeyStart31105( ) ;
         if ( RcdFound105 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1010OperacoesId = A1010OperacoesId;
         }
         ZM31105( -2) ;
         OnLoadActions31105( ) ;
         AddRow31105( ) ;
         ScanKeyEnd31105( ) ;
         if ( RcdFound105 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey31105( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert31105( ) ;
         }
         else
         {
            if ( RcdFound105 == 1 )
            {
               if ( A1010OperacoesId != Z1010OperacoesId )
               {
                  A1010OperacoesId = Z1010OperacoesId;
                  n1010OperacoesId = false;
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
                  Update31105( ) ;
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
                  if ( A1010OperacoesId != Z1010OperacoesId )
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
                        Insert31105( ) ;
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
                        Insert31105( ) ;
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
         RowToVars105( bcOperacoes, 1) ;
         SaveImpl( ) ;
         VarsToRow105( bcOperacoes) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars105( bcOperacoes, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert31105( ) ;
         AfterTrn( ) ;
         VarsToRow105( bcOperacoes) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow105( bcOperacoes) ;
         }
         else
         {
            SdtOperacoes auxBC = new SdtOperacoes(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1010OperacoesId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcOperacoes);
               auxBC.Save();
               bcOperacoes.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars105( bcOperacoes, 1) ;
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
         RowToVars105( bcOperacoes, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert31105( ) ;
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
               VarsToRow105( bcOperacoes) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow105( bcOperacoes) ;
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
         RowToVars105( bcOperacoes, 0) ;
         GetKey31105( ) ;
         if ( RcdFound105 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1010OperacoesId != Z1010OperacoesId )
            {
               A1010OperacoesId = Z1010OperacoesId;
               n1010OperacoesId = false;
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
            if ( A1010OperacoesId != Z1010OperacoesId )
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
         context.RollbackDataStores("operacoes_bc",pr_default);
         VarsToRow105( bcOperacoes) ;
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
         Gx_mode = bcOperacoes.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcOperacoes.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcOperacoes )
         {
            bcOperacoes = (SdtOperacoes)(sdt);
            if ( StringUtil.StrCmp(bcOperacoes.gxTpr_Mode, "") == 0 )
            {
               bcOperacoes.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow105( bcOperacoes) ;
            }
            else
            {
               RowToVars105( bcOperacoes, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcOperacoes.gxTpr_Mode, "") == 0 )
            {
               bcOperacoes.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars105( bcOperacoes, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtOperacoes Operacoes_BC
      {
         get {
            return bcOperacoes ;
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
         pr_default.close(10);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1011OperacoesData = DateTime.MinValue;
         A1011OperacoesData = DateTime.MinValue;
         Z1012OperacoesStatus = "";
         A1012OperacoesStatus = "";
         Z1048OperacoesTipoTarifa = "";
         A1048OperacoesTipoTarifa = "";
         Z1017OperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         A1017OperacoesCreatedAt = (DateTime)(DateTime.MinValue);
         Z1018OperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         A1018OperacoesUpdateAt = (DateTime)(DateTime.MinValue);
         Z170ClienteRazaoSocial = "";
         A170ClienteRazaoSocial = "";
         Z228ContratoNome = "";
         A228ContratoNome = "";
         BC00316_A1010OperacoesId = new int[1] ;
         BC00316_n1010OperacoesId = new bool[] {false} ;
         BC00316_A170ClienteRazaoSocial = new string[] {""} ;
         BC00316_n170ClienteRazaoSocial = new bool[] {false} ;
         BC00316_A1011OperacoesData = new DateTime[] {DateTime.MinValue} ;
         BC00316_n1011OperacoesData = new bool[] {false} ;
         BC00316_A1012OperacoesStatus = new string[] {""} ;
         BC00316_n1012OperacoesStatus = new bool[] {false} ;
         BC00316_A1015OperacoesTaxaEfetiva = new decimal[1] ;
         BC00316_n1015OperacoesTaxaEfetiva = new bool[] {false} ;
         BC00316_A1016OperacoesTaxaMora = new decimal[1] ;
         BC00316_n1016OperacoesTaxaMora = new bool[] {false} ;
         BC00316_A1047OperacoesFator = new decimal[1] ;
         BC00316_n1047OperacoesFator = new bool[] {false} ;
         BC00316_A1048OperacoesTipoTarifa = new string[] {""} ;
         BC00316_n1048OperacoesTipoTarifa = new bool[] {false} ;
         BC00316_A1049OperacoesTarifa = new decimal[1] ;
         BC00316_n1049OperacoesTarifa = new bool[] {false} ;
         BC00316_A228ContratoNome = new string[] {""} ;
         BC00316_n228ContratoNome = new bool[] {false} ;
         BC00316_A1017OperacoesCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00316_n1017OperacoesCreatedAt = new bool[] {false} ;
         BC00316_A1018OperacoesUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC00316_n1018OperacoesUpdateAt = new bool[] {false} ;
         BC00316_A168ClienteId = new int[1] ;
         BC00316_n168ClienteId = new bool[] {false} ;
         BC00316_A227ContratoId = new int[1] ;
         BC00316_n227ContratoId = new bool[] {false} ;
         BC00314_A170ClienteRazaoSocial = new string[] {""} ;
         BC00314_n170ClienteRazaoSocial = new bool[] {false} ;
         BC00315_A228ContratoNome = new string[] {""} ;
         BC00315_n228ContratoNome = new bool[] {false} ;
         BC00317_A1010OperacoesId = new int[1] ;
         BC00317_n1010OperacoesId = new bool[] {false} ;
         BC00313_A1010OperacoesId = new int[1] ;
         BC00313_n1010OperacoesId = new bool[] {false} ;
         BC00313_A1011OperacoesData = new DateTime[] {DateTime.MinValue} ;
         BC00313_n1011OperacoesData = new bool[] {false} ;
         BC00313_A1012OperacoesStatus = new string[] {""} ;
         BC00313_n1012OperacoesStatus = new bool[] {false} ;
         BC00313_A1015OperacoesTaxaEfetiva = new decimal[1] ;
         BC00313_n1015OperacoesTaxaEfetiva = new bool[] {false} ;
         BC00313_A1016OperacoesTaxaMora = new decimal[1] ;
         BC00313_n1016OperacoesTaxaMora = new bool[] {false} ;
         BC00313_A1047OperacoesFator = new decimal[1] ;
         BC00313_n1047OperacoesFator = new bool[] {false} ;
         BC00313_A1048OperacoesTipoTarifa = new string[] {""} ;
         BC00313_n1048OperacoesTipoTarifa = new bool[] {false} ;
         BC00313_A1049OperacoesTarifa = new decimal[1] ;
         BC00313_n1049OperacoesTarifa = new bool[] {false} ;
         BC00313_A1017OperacoesCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00313_n1017OperacoesCreatedAt = new bool[] {false} ;
         BC00313_A1018OperacoesUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC00313_n1018OperacoesUpdateAt = new bool[] {false} ;
         BC00313_A168ClienteId = new int[1] ;
         BC00313_n168ClienteId = new bool[] {false} ;
         BC00313_A227ContratoId = new int[1] ;
         BC00313_n227ContratoId = new bool[] {false} ;
         sMode105 = "";
         BC00312_A1010OperacoesId = new int[1] ;
         BC00312_n1010OperacoesId = new bool[] {false} ;
         BC00312_A1011OperacoesData = new DateTime[] {DateTime.MinValue} ;
         BC00312_n1011OperacoesData = new bool[] {false} ;
         BC00312_A1012OperacoesStatus = new string[] {""} ;
         BC00312_n1012OperacoesStatus = new bool[] {false} ;
         BC00312_A1015OperacoesTaxaEfetiva = new decimal[1] ;
         BC00312_n1015OperacoesTaxaEfetiva = new bool[] {false} ;
         BC00312_A1016OperacoesTaxaMora = new decimal[1] ;
         BC00312_n1016OperacoesTaxaMora = new bool[] {false} ;
         BC00312_A1047OperacoesFator = new decimal[1] ;
         BC00312_n1047OperacoesFator = new bool[] {false} ;
         BC00312_A1048OperacoesTipoTarifa = new string[] {""} ;
         BC00312_n1048OperacoesTipoTarifa = new bool[] {false} ;
         BC00312_A1049OperacoesTarifa = new decimal[1] ;
         BC00312_n1049OperacoesTarifa = new bool[] {false} ;
         BC00312_A1017OperacoesCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00312_n1017OperacoesCreatedAt = new bool[] {false} ;
         BC00312_A1018OperacoesUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC00312_n1018OperacoesUpdateAt = new bool[] {false} ;
         BC00312_A168ClienteId = new int[1] ;
         BC00312_n168ClienteId = new bool[] {false} ;
         BC00312_A227ContratoId = new int[1] ;
         BC00312_n227ContratoId = new bool[] {false} ;
         BC00319_A1010OperacoesId = new int[1] ;
         BC00319_n1010OperacoesId = new bool[] {false} ;
         BC003112_A170ClienteRazaoSocial = new string[] {""} ;
         BC003112_n170ClienteRazaoSocial = new bool[] {false} ;
         BC003113_A228ContratoNome = new string[] {""} ;
         BC003113_n228ContratoNome = new bool[] {false} ;
         BC003114_A1019OperacoesTitulosId = new int[1] ;
         BC003115_A1010OperacoesId = new int[1] ;
         BC003115_n1010OperacoesId = new bool[] {false} ;
         BC003115_A170ClienteRazaoSocial = new string[] {""} ;
         BC003115_n170ClienteRazaoSocial = new bool[] {false} ;
         BC003115_A1011OperacoesData = new DateTime[] {DateTime.MinValue} ;
         BC003115_n1011OperacoesData = new bool[] {false} ;
         BC003115_A1012OperacoesStatus = new string[] {""} ;
         BC003115_n1012OperacoesStatus = new bool[] {false} ;
         BC003115_A1015OperacoesTaxaEfetiva = new decimal[1] ;
         BC003115_n1015OperacoesTaxaEfetiva = new bool[] {false} ;
         BC003115_A1016OperacoesTaxaMora = new decimal[1] ;
         BC003115_n1016OperacoesTaxaMora = new bool[] {false} ;
         BC003115_A1047OperacoesFator = new decimal[1] ;
         BC003115_n1047OperacoesFator = new bool[] {false} ;
         BC003115_A1048OperacoesTipoTarifa = new string[] {""} ;
         BC003115_n1048OperacoesTipoTarifa = new bool[] {false} ;
         BC003115_A1049OperacoesTarifa = new decimal[1] ;
         BC003115_n1049OperacoesTarifa = new bool[] {false} ;
         BC003115_A228ContratoNome = new string[] {""} ;
         BC003115_n228ContratoNome = new bool[] {false} ;
         BC003115_A1017OperacoesCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003115_n1017OperacoesCreatedAt = new bool[] {false} ;
         BC003115_A1018OperacoesUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC003115_n1018OperacoesUpdateAt = new bool[] {false} ;
         BC003115_A168ClienteId = new int[1] ;
         BC003115_n168ClienteId = new bool[] {false} ;
         BC003115_A227ContratoId = new int[1] ;
         BC003115_n227ContratoId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacoes_bc__default(),
            new Object[][] {
                new Object[] {
               BC00312_A1010OperacoesId, BC00312_A1011OperacoesData, BC00312_n1011OperacoesData, BC00312_A1012OperacoesStatus, BC00312_n1012OperacoesStatus, BC00312_A1015OperacoesTaxaEfetiva, BC00312_n1015OperacoesTaxaEfetiva, BC00312_A1016OperacoesTaxaMora, BC00312_n1016OperacoesTaxaMora, BC00312_A1047OperacoesFator,
               BC00312_n1047OperacoesFator, BC00312_A1048OperacoesTipoTarifa, BC00312_n1048OperacoesTipoTarifa, BC00312_A1049OperacoesTarifa, BC00312_n1049OperacoesTarifa, BC00312_A1017OperacoesCreatedAt, BC00312_n1017OperacoesCreatedAt, BC00312_A1018OperacoesUpdateAt, BC00312_n1018OperacoesUpdateAt, BC00312_A168ClienteId,
               BC00312_n168ClienteId, BC00312_A227ContratoId, BC00312_n227ContratoId
               }
               , new Object[] {
               BC00313_A1010OperacoesId, BC00313_A1011OperacoesData, BC00313_n1011OperacoesData, BC00313_A1012OperacoesStatus, BC00313_n1012OperacoesStatus, BC00313_A1015OperacoesTaxaEfetiva, BC00313_n1015OperacoesTaxaEfetiva, BC00313_A1016OperacoesTaxaMora, BC00313_n1016OperacoesTaxaMora, BC00313_A1047OperacoesFator,
               BC00313_n1047OperacoesFator, BC00313_A1048OperacoesTipoTarifa, BC00313_n1048OperacoesTipoTarifa, BC00313_A1049OperacoesTarifa, BC00313_n1049OperacoesTarifa, BC00313_A1017OperacoesCreatedAt, BC00313_n1017OperacoesCreatedAt, BC00313_A1018OperacoesUpdateAt, BC00313_n1018OperacoesUpdateAt, BC00313_A168ClienteId,
               BC00313_n168ClienteId, BC00313_A227ContratoId, BC00313_n227ContratoId
               }
               , new Object[] {
               BC00314_A170ClienteRazaoSocial, BC00314_n170ClienteRazaoSocial
               }
               , new Object[] {
               BC00315_A228ContratoNome, BC00315_n228ContratoNome
               }
               , new Object[] {
               BC00316_A1010OperacoesId, BC00316_A170ClienteRazaoSocial, BC00316_n170ClienteRazaoSocial, BC00316_A1011OperacoesData, BC00316_n1011OperacoesData, BC00316_A1012OperacoesStatus, BC00316_n1012OperacoesStatus, BC00316_A1015OperacoesTaxaEfetiva, BC00316_n1015OperacoesTaxaEfetiva, BC00316_A1016OperacoesTaxaMora,
               BC00316_n1016OperacoesTaxaMora, BC00316_A1047OperacoesFator, BC00316_n1047OperacoesFator, BC00316_A1048OperacoesTipoTarifa, BC00316_n1048OperacoesTipoTarifa, BC00316_A1049OperacoesTarifa, BC00316_n1049OperacoesTarifa, BC00316_A228ContratoNome, BC00316_n228ContratoNome, BC00316_A1017OperacoesCreatedAt,
               BC00316_n1017OperacoesCreatedAt, BC00316_A1018OperacoesUpdateAt, BC00316_n1018OperacoesUpdateAt, BC00316_A168ClienteId, BC00316_n168ClienteId, BC00316_A227ContratoId, BC00316_n227ContratoId
               }
               , new Object[] {
               BC00317_A1010OperacoesId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00319_A1010OperacoesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC003112_A170ClienteRazaoSocial, BC003112_n170ClienteRazaoSocial
               }
               , new Object[] {
               BC003113_A228ContratoNome, BC003113_n228ContratoNome
               }
               , new Object[] {
               BC003114_A1019OperacoesTitulosId
               }
               , new Object[] {
               BC003115_A1010OperacoesId, BC003115_A170ClienteRazaoSocial, BC003115_n170ClienteRazaoSocial, BC003115_A1011OperacoesData, BC003115_n1011OperacoesData, BC003115_A1012OperacoesStatus, BC003115_n1012OperacoesStatus, BC003115_A1015OperacoesTaxaEfetiva, BC003115_n1015OperacoesTaxaEfetiva, BC003115_A1016OperacoesTaxaMora,
               BC003115_n1016OperacoesTaxaMora, BC003115_A1047OperacoesFator, BC003115_n1047OperacoesFator, BC003115_A1048OperacoesTipoTarifa, BC003115_n1048OperacoesTipoTarifa, BC003115_A1049OperacoesTarifa, BC003115_n1049OperacoesTarifa, BC003115_A228ContratoNome, BC003115_n228ContratoNome, BC003115_A1017OperacoesCreatedAt,
               BC003115_n1017OperacoesCreatedAt, BC003115_A1018OperacoesUpdateAt, BC003115_n1018OperacoesUpdateAt, BC003115_A168ClienteId, BC003115_n168ClienteId, BC003115_A227ContratoId, BC003115_n227ContratoId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound105 ;
      private int trnEnded ;
      private int Z1010OperacoesId ;
      private int A1010OperacoesId ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private int Z227ContratoId ;
      private int A227ContratoId ;
      private decimal Z1015OperacoesTaxaEfetiva ;
      private decimal A1015OperacoesTaxaEfetiva ;
      private decimal Z1016OperacoesTaxaMora ;
      private decimal A1016OperacoesTaxaMora ;
      private decimal Z1047OperacoesFator ;
      private decimal A1047OperacoesFator ;
      private decimal Z1049OperacoesTarifa ;
      private decimal A1049OperacoesTarifa ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode105 ;
      private DateTime Z1017OperacoesCreatedAt ;
      private DateTime A1017OperacoesCreatedAt ;
      private DateTime Z1018OperacoesUpdateAt ;
      private DateTime A1018OperacoesUpdateAt ;
      private DateTime Z1011OperacoesData ;
      private DateTime A1011OperacoesData ;
      private bool n1010OperacoesId ;
      private bool n170ClienteRazaoSocial ;
      private bool n1011OperacoesData ;
      private bool n1012OperacoesStatus ;
      private bool n1015OperacoesTaxaEfetiva ;
      private bool n1016OperacoesTaxaMora ;
      private bool n1047OperacoesFator ;
      private bool n1048OperacoesTipoTarifa ;
      private bool n1049OperacoesTarifa ;
      private bool n228ContratoNome ;
      private bool n1017OperacoesCreatedAt ;
      private bool n1018OperacoesUpdateAt ;
      private bool n168ClienteId ;
      private bool n227ContratoId ;
      private bool Gx_longc ;
      private string Z1012OperacoesStatus ;
      private string A1012OperacoesStatus ;
      private string Z1048OperacoesTipoTarifa ;
      private string A1048OperacoesTipoTarifa ;
      private string Z170ClienteRazaoSocial ;
      private string A170ClienteRazaoSocial ;
      private string Z228ContratoNome ;
      private string A228ContratoNome ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00316_A1010OperacoesId ;
      private bool[] BC00316_n1010OperacoesId ;
      private string[] BC00316_A170ClienteRazaoSocial ;
      private bool[] BC00316_n170ClienteRazaoSocial ;
      private DateTime[] BC00316_A1011OperacoesData ;
      private bool[] BC00316_n1011OperacoesData ;
      private string[] BC00316_A1012OperacoesStatus ;
      private bool[] BC00316_n1012OperacoesStatus ;
      private decimal[] BC00316_A1015OperacoesTaxaEfetiva ;
      private bool[] BC00316_n1015OperacoesTaxaEfetiva ;
      private decimal[] BC00316_A1016OperacoesTaxaMora ;
      private bool[] BC00316_n1016OperacoesTaxaMora ;
      private decimal[] BC00316_A1047OperacoesFator ;
      private bool[] BC00316_n1047OperacoesFator ;
      private string[] BC00316_A1048OperacoesTipoTarifa ;
      private bool[] BC00316_n1048OperacoesTipoTarifa ;
      private decimal[] BC00316_A1049OperacoesTarifa ;
      private bool[] BC00316_n1049OperacoesTarifa ;
      private string[] BC00316_A228ContratoNome ;
      private bool[] BC00316_n228ContratoNome ;
      private DateTime[] BC00316_A1017OperacoesCreatedAt ;
      private bool[] BC00316_n1017OperacoesCreatedAt ;
      private DateTime[] BC00316_A1018OperacoesUpdateAt ;
      private bool[] BC00316_n1018OperacoesUpdateAt ;
      private int[] BC00316_A168ClienteId ;
      private bool[] BC00316_n168ClienteId ;
      private int[] BC00316_A227ContratoId ;
      private bool[] BC00316_n227ContratoId ;
      private string[] BC00314_A170ClienteRazaoSocial ;
      private bool[] BC00314_n170ClienteRazaoSocial ;
      private string[] BC00315_A228ContratoNome ;
      private bool[] BC00315_n228ContratoNome ;
      private int[] BC00317_A1010OperacoesId ;
      private bool[] BC00317_n1010OperacoesId ;
      private int[] BC00313_A1010OperacoesId ;
      private bool[] BC00313_n1010OperacoesId ;
      private DateTime[] BC00313_A1011OperacoesData ;
      private bool[] BC00313_n1011OperacoesData ;
      private string[] BC00313_A1012OperacoesStatus ;
      private bool[] BC00313_n1012OperacoesStatus ;
      private decimal[] BC00313_A1015OperacoesTaxaEfetiva ;
      private bool[] BC00313_n1015OperacoesTaxaEfetiva ;
      private decimal[] BC00313_A1016OperacoesTaxaMora ;
      private bool[] BC00313_n1016OperacoesTaxaMora ;
      private decimal[] BC00313_A1047OperacoesFator ;
      private bool[] BC00313_n1047OperacoesFator ;
      private string[] BC00313_A1048OperacoesTipoTarifa ;
      private bool[] BC00313_n1048OperacoesTipoTarifa ;
      private decimal[] BC00313_A1049OperacoesTarifa ;
      private bool[] BC00313_n1049OperacoesTarifa ;
      private DateTime[] BC00313_A1017OperacoesCreatedAt ;
      private bool[] BC00313_n1017OperacoesCreatedAt ;
      private DateTime[] BC00313_A1018OperacoesUpdateAt ;
      private bool[] BC00313_n1018OperacoesUpdateAt ;
      private int[] BC00313_A168ClienteId ;
      private bool[] BC00313_n168ClienteId ;
      private int[] BC00313_A227ContratoId ;
      private bool[] BC00313_n227ContratoId ;
      private int[] BC00312_A1010OperacoesId ;
      private bool[] BC00312_n1010OperacoesId ;
      private DateTime[] BC00312_A1011OperacoesData ;
      private bool[] BC00312_n1011OperacoesData ;
      private string[] BC00312_A1012OperacoesStatus ;
      private bool[] BC00312_n1012OperacoesStatus ;
      private decimal[] BC00312_A1015OperacoesTaxaEfetiva ;
      private bool[] BC00312_n1015OperacoesTaxaEfetiva ;
      private decimal[] BC00312_A1016OperacoesTaxaMora ;
      private bool[] BC00312_n1016OperacoesTaxaMora ;
      private decimal[] BC00312_A1047OperacoesFator ;
      private bool[] BC00312_n1047OperacoesFator ;
      private string[] BC00312_A1048OperacoesTipoTarifa ;
      private bool[] BC00312_n1048OperacoesTipoTarifa ;
      private decimal[] BC00312_A1049OperacoesTarifa ;
      private bool[] BC00312_n1049OperacoesTarifa ;
      private DateTime[] BC00312_A1017OperacoesCreatedAt ;
      private bool[] BC00312_n1017OperacoesCreatedAt ;
      private DateTime[] BC00312_A1018OperacoesUpdateAt ;
      private bool[] BC00312_n1018OperacoesUpdateAt ;
      private int[] BC00312_A168ClienteId ;
      private bool[] BC00312_n168ClienteId ;
      private int[] BC00312_A227ContratoId ;
      private bool[] BC00312_n227ContratoId ;
      private int[] BC00319_A1010OperacoesId ;
      private bool[] BC00319_n1010OperacoesId ;
      private string[] BC003112_A170ClienteRazaoSocial ;
      private bool[] BC003112_n170ClienteRazaoSocial ;
      private string[] BC003113_A228ContratoNome ;
      private bool[] BC003113_n228ContratoNome ;
      private int[] BC003114_A1019OperacoesTitulosId ;
      private int[] BC003115_A1010OperacoesId ;
      private bool[] BC003115_n1010OperacoesId ;
      private string[] BC003115_A170ClienteRazaoSocial ;
      private bool[] BC003115_n170ClienteRazaoSocial ;
      private DateTime[] BC003115_A1011OperacoesData ;
      private bool[] BC003115_n1011OperacoesData ;
      private string[] BC003115_A1012OperacoesStatus ;
      private bool[] BC003115_n1012OperacoesStatus ;
      private decimal[] BC003115_A1015OperacoesTaxaEfetiva ;
      private bool[] BC003115_n1015OperacoesTaxaEfetiva ;
      private decimal[] BC003115_A1016OperacoesTaxaMora ;
      private bool[] BC003115_n1016OperacoesTaxaMora ;
      private decimal[] BC003115_A1047OperacoesFator ;
      private bool[] BC003115_n1047OperacoesFator ;
      private string[] BC003115_A1048OperacoesTipoTarifa ;
      private bool[] BC003115_n1048OperacoesTipoTarifa ;
      private decimal[] BC003115_A1049OperacoesTarifa ;
      private bool[] BC003115_n1049OperacoesTarifa ;
      private string[] BC003115_A228ContratoNome ;
      private bool[] BC003115_n228ContratoNome ;
      private DateTime[] BC003115_A1017OperacoesCreatedAt ;
      private bool[] BC003115_n1017OperacoesCreatedAt ;
      private DateTime[] BC003115_A1018OperacoesUpdateAt ;
      private bool[] BC003115_n1018OperacoesUpdateAt ;
      private int[] BC003115_A168ClienteId ;
      private bool[] BC003115_n168ClienteId ;
      private int[] BC003115_A227ContratoId ;
      private bool[] BC003115_n227ContratoId ;
      private SdtOperacoes bcOperacoes ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class operacoes_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00312;
          prmBC00312 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00313;
          prmBC00313 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00314;
          prmBC00314 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00315;
          prmBC00315 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC00316;
          prmBC00316 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00317;
          prmBC00317 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00318;
          prmBC00318 = new Object[] {
          new ParDef("OperacoesData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("OperacoesStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTaxaEfetiva",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesTaxaMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesFator",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesTipoTarifa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTarifa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("OperacoesCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("OperacoesUpdateAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC00319;
          prmBC00319 = new Object[] {
          };
          Object[] prmBC003110;
          prmBC003110 = new Object[] {
          new ParDef("OperacoesData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("OperacoesStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTaxaEfetiva",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesTaxaMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesFator",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesTipoTarifa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTarifa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("OperacoesCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("OperacoesUpdateAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true} ,
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003111;
          prmBC003111 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003112;
          prmBC003112 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003113;
          prmBC003113 = new Object[] {
          new ParDef("ContratoId",GXType.Int32,6,0){Nullable=true}
          };
          Object[] prmBC003114;
          prmBC003114 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003115;
          prmBC003115 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC00312", "SELECT OperacoesId, OperacoesData, OperacoesStatus, OperacoesTaxaEfetiva, OperacoesTaxaMora, OperacoesFator, OperacoesTipoTarifa, OperacoesTarifa, OperacoesCreatedAt, OperacoesUpdateAt, ClienteId, ContratoId FROM Operacoes WHERE OperacoesId = :OperacoesId  FOR UPDATE OF Operacoes",true, GxErrorMask.GX_NOMASK, false, this,prmBC00312,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00313", "SELECT OperacoesId, OperacoesData, OperacoesStatus, OperacoesTaxaEfetiva, OperacoesTaxaMora, OperacoesFator, OperacoesTipoTarifa, OperacoesTarifa, OperacoesCreatedAt, OperacoesUpdateAt, ClienteId, ContratoId FROM Operacoes WHERE OperacoesId = :OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00313,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00314", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00314,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00315", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00315,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00316", "SELECT TM1.OperacoesId, T2.ClienteRazaoSocial, TM1.OperacoesData, TM1.OperacoesStatus, TM1.OperacoesTaxaEfetiva, TM1.OperacoesTaxaMora, TM1.OperacoesFator, TM1.OperacoesTipoTarifa, TM1.OperacoesTarifa, T3.ContratoNome, TM1.OperacoesCreatedAt, TM1.OperacoesUpdateAt, TM1.ClienteId, TM1.ContratoId FROM ((Operacoes TM1 LEFT JOIN Cliente T2 ON T2.ClienteId = TM1.ClienteId) LEFT JOIN Contrato T3 ON T3.ContratoId = TM1.ContratoId) WHERE TM1.OperacoesId = :OperacoesId ORDER BY TM1.OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00316,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00317", "SELECT OperacoesId FROM Operacoes WHERE OperacoesId = :OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00317,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00318", "SAVEPOINT gxupdate;INSERT INTO Operacoes(OperacoesData, OperacoesStatus, OperacoesTaxaEfetiva, OperacoesTaxaMora, OperacoesFator, OperacoesTipoTarifa, OperacoesTarifa, OperacoesCreatedAt, OperacoesUpdateAt, ClienteId, ContratoId) VALUES(:OperacoesData, :OperacoesStatus, :OperacoesTaxaEfetiva, :OperacoesTaxaMora, :OperacoesFator, :OperacoesTipoTarifa, :OperacoesTarifa, :OperacoesCreatedAt, :OperacoesUpdateAt, :ClienteId, :ContratoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00318)
             ,new CursorDef("BC00319", "SELECT currval('OperacoesId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00319,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003110", "SAVEPOINT gxupdate;UPDATE Operacoes SET OperacoesData=:OperacoesData, OperacoesStatus=:OperacoesStatus, OperacoesTaxaEfetiva=:OperacoesTaxaEfetiva, OperacoesTaxaMora=:OperacoesTaxaMora, OperacoesFator=:OperacoesFator, OperacoesTipoTarifa=:OperacoesTipoTarifa, OperacoesTarifa=:OperacoesTarifa, OperacoesCreatedAt=:OperacoesCreatedAt, OperacoesUpdateAt=:OperacoesUpdateAt, ClienteId=:ClienteId, ContratoId=:ContratoId  WHERE OperacoesId = :OperacoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003110)
             ,new CursorDef("BC003111", "SAVEPOINT gxupdate;DELETE FROM Operacoes  WHERE OperacoesId = :OperacoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003111)
             ,new CursorDef("BC003112", "SELECT ClienteRazaoSocial FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003112,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003113", "SELECT ContratoNome FROM Contrato WHERE ContratoId = :ContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003113,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003114", "SELECT OperacoesTitulosId FROM OperacoesTitulos WHERE OperacoesId = :OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003114,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC003115", "SELECT TM1.OperacoesId, T2.ClienteRazaoSocial, TM1.OperacoesData, TM1.OperacoesStatus, TM1.OperacoesTaxaEfetiva, TM1.OperacoesTaxaMora, TM1.OperacoesFator, TM1.OperacoesTipoTarifa, TM1.OperacoesTarifa, T3.ContratoNome, TM1.OperacoesCreatedAt, TM1.OperacoesUpdateAt, TM1.ClienteId, TM1.ContratoId FROM ((Operacoes TM1 LEFT JOIN Cliente T2 ON T2.ClienteId = TM1.ClienteId) LEFT JOIN Contrato T3 ON T3.ContratoId = TM1.ContratoId) WHERE TM1.OperacoesId = :OperacoesId ORDER BY TM1.OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003115,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
       }
    }

 }

}
