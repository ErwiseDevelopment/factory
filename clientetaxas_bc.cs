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
   public class clientetaxas_bc : GxSilentTrn, IGxSilentTrn
   {
      public clientetaxas_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientetaxas_bc( IGxContext context )
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
         ReadRow34108( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey34108( ) ;
         standaloneModal( ) ;
         AddRow34108( ) ;
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
            E11342 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1008ClienteTaxasId = A1008ClienteTaxasId;
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

      protected void CONFIRM_340( )
      {
         BeforeValidate34108( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls34108( ) ;
            }
            else
            {
               CheckExtendedTable34108( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors34108( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12342( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11342( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM34108( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z1045ClienteTaxasCreatedAt = A1045ClienteTaxasCreatedAt;
            Z1046ClienteTaxasUpdatedAt = A1046ClienteTaxasUpdatedAt;
            Z1009ClienteTaxasTipo = A1009ClienteTaxasTipo;
            Z1040ClienteTaxasEfetiva = A1040ClienteTaxasEfetiva;
            Z1041ClienteTaxasMora = A1041ClienteTaxasMora;
            Z1042ClienteTaxasFator = A1042ClienteTaxasFator;
            Z1043ClienteTaxasTipoTarifa = A1043ClienteTaxasTipoTarifa;
            Z1044ClienteTaxasTarifa = A1044ClienteTaxasTarifa;
         }
         if ( GX_JID == -4 )
         {
            Z1008ClienteTaxasId = A1008ClienteTaxasId;
            Z1045ClienteTaxasCreatedAt = A1045ClienteTaxasCreatedAt;
            Z1046ClienteTaxasUpdatedAt = A1046ClienteTaxasUpdatedAt;
            Z1009ClienteTaxasTipo = A1009ClienteTaxasTipo;
            Z1040ClienteTaxasEfetiva = A1040ClienteTaxasEfetiva;
            Z1041ClienteTaxasMora = A1041ClienteTaxasMora;
            Z1042ClienteTaxasFator = A1042ClienteTaxasFator;
            Z1043ClienteTaxasTipoTarifa = A1043ClienteTaxasTipoTarifa;
            Z1044ClienteTaxasTarifa = A1044ClienteTaxasTarifa;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A1045ClienteTaxasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1045ClienteTaxasCreatedAt = false;
         }
         if ( IsUpd( )  )
         {
            A1046ClienteTaxasUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1046ClienteTaxasUpdatedAt = false;
         }
      }

      protected void Load34108( )
      {
         /* Using cursor BC00344 */
         pr_default.execute(2, new Object[] {A1008ClienteTaxasId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound108 = 1;
            A1045ClienteTaxasCreatedAt = BC00344_A1045ClienteTaxasCreatedAt[0];
            n1045ClienteTaxasCreatedAt = BC00344_n1045ClienteTaxasCreatedAt[0];
            A1046ClienteTaxasUpdatedAt = BC00344_A1046ClienteTaxasUpdatedAt[0];
            n1046ClienteTaxasUpdatedAt = BC00344_n1046ClienteTaxasUpdatedAt[0];
            A1009ClienteTaxasTipo = BC00344_A1009ClienteTaxasTipo[0];
            n1009ClienteTaxasTipo = BC00344_n1009ClienteTaxasTipo[0];
            A1040ClienteTaxasEfetiva = BC00344_A1040ClienteTaxasEfetiva[0];
            n1040ClienteTaxasEfetiva = BC00344_n1040ClienteTaxasEfetiva[0];
            A1041ClienteTaxasMora = BC00344_A1041ClienteTaxasMora[0];
            n1041ClienteTaxasMora = BC00344_n1041ClienteTaxasMora[0];
            A1042ClienteTaxasFator = BC00344_A1042ClienteTaxasFator[0];
            n1042ClienteTaxasFator = BC00344_n1042ClienteTaxasFator[0];
            A1043ClienteTaxasTipoTarifa = BC00344_A1043ClienteTaxasTipoTarifa[0];
            n1043ClienteTaxasTipoTarifa = BC00344_n1043ClienteTaxasTipoTarifa[0];
            A1044ClienteTaxasTarifa = BC00344_A1044ClienteTaxasTarifa[0];
            n1044ClienteTaxasTarifa = BC00344_n1044ClienteTaxasTarifa[0];
            ZM34108( -4) ;
         }
         pr_default.close(2);
         OnLoadActions34108( ) ;
      }

      protected void OnLoadActions34108( )
      {
      }

      protected void CheckExtendedTable34108( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00345 */
         pr_default.execute(3, new Object[] {n1009ClienteTaxasTipo, A1009ClienteTaxasTipo, A1008ClienteTaxasId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Cliente Taxas Tipo"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A1009ClienteTaxasTipo, "SEM_RISCO") == 0 ) || ( StringUtil.StrCmp(A1009ClienteTaxasTipo, "BAIXO") == 0 ) || ( StringUtil.StrCmp(A1009ClienteTaxasTipo, "ALTO") == 0 ) || ( StringUtil.StrCmp(A1009ClienteTaxasTipo, "PREMIUM") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1009ClienteTaxasTipo)) ) )
         {
            GX_msglist.addItem("Campo Cliente Taxas Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors34108( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey34108( )
      {
         /* Using cursor BC00346 */
         pr_default.execute(4, new Object[] {A1008ClienteTaxasId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound108 = 1;
         }
         else
         {
            RcdFound108 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00343 */
         pr_default.execute(1, new Object[] {A1008ClienteTaxasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM34108( 4) ;
            RcdFound108 = 1;
            A1008ClienteTaxasId = BC00343_A1008ClienteTaxasId[0];
            A1045ClienteTaxasCreatedAt = BC00343_A1045ClienteTaxasCreatedAt[0];
            n1045ClienteTaxasCreatedAt = BC00343_n1045ClienteTaxasCreatedAt[0];
            A1046ClienteTaxasUpdatedAt = BC00343_A1046ClienteTaxasUpdatedAt[0];
            n1046ClienteTaxasUpdatedAt = BC00343_n1046ClienteTaxasUpdatedAt[0];
            A1009ClienteTaxasTipo = BC00343_A1009ClienteTaxasTipo[0];
            n1009ClienteTaxasTipo = BC00343_n1009ClienteTaxasTipo[0];
            A1040ClienteTaxasEfetiva = BC00343_A1040ClienteTaxasEfetiva[0];
            n1040ClienteTaxasEfetiva = BC00343_n1040ClienteTaxasEfetiva[0];
            A1041ClienteTaxasMora = BC00343_A1041ClienteTaxasMora[0];
            n1041ClienteTaxasMora = BC00343_n1041ClienteTaxasMora[0];
            A1042ClienteTaxasFator = BC00343_A1042ClienteTaxasFator[0];
            n1042ClienteTaxasFator = BC00343_n1042ClienteTaxasFator[0];
            A1043ClienteTaxasTipoTarifa = BC00343_A1043ClienteTaxasTipoTarifa[0];
            n1043ClienteTaxasTipoTarifa = BC00343_n1043ClienteTaxasTipoTarifa[0];
            A1044ClienteTaxasTarifa = BC00343_A1044ClienteTaxasTarifa[0];
            n1044ClienteTaxasTarifa = BC00343_n1044ClienteTaxasTarifa[0];
            Z1008ClienteTaxasId = A1008ClienteTaxasId;
            sMode108 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load34108( ) ;
            if ( AnyError == 1 )
            {
               RcdFound108 = 0;
               InitializeNonKey34108( ) ;
            }
            Gx_mode = sMode108;
         }
         else
         {
            RcdFound108 = 0;
            InitializeNonKey34108( ) ;
            sMode108 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode108;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey34108( ) ;
         if ( RcdFound108 == 0 )
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
         CONFIRM_340( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency34108( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00342 */
            pr_default.execute(0, new Object[] {A1008ClienteTaxasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteTaxas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1045ClienteTaxasCreatedAt != BC00342_A1045ClienteTaxasCreatedAt[0] ) || ( Z1046ClienteTaxasUpdatedAt != BC00342_A1046ClienteTaxasUpdatedAt[0] ) || ( StringUtil.StrCmp(Z1009ClienteTaxasTipo, BC00342_A1009ClienteTaxasTipo[0]) != 0 ) || ( Z1040ClienteTaxasEfetiva != BC00342_A1040ClienteTaxasEfetiva[0] ) || ( Z1041ClienteTaxasMora != BC00342_A1041ClienteTaxasMora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1042ClienteTaxasFator != BC00342_A1042ClienteTaxasFator[0] ) || ( StringUtil.StrCmp(Z1043ClienteTaxasTipoTarifa, BC00342_A1043ClienteTaxasTipoTarifa[0]) != 0 ) || ( Z1044ClienteTaxasTarifa != BC00342_A1044ClienteTaxasTarifa[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ClienteTaxas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert34108( )
      {
         BeforeValidate34108( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable34108( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM34108( 0) ;
            CheckOptimisticConcurrency34108( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm34108( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert34108( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00347 */
                     pr_default.execute(5, new Object[] {n1045ClienteTaxasCreatedAt, A1045ClienteTaxasCreatedAt, n1046ClienteTaxasUpdatedAt, A1046ClienteTaxasUpdatedAt, n1009ClienteTaxasTipo, A1009ClienteTaxasTipo, n1040ClienteTaxasEfetiva, A1040ClienteTaxasEfetiva, n1041ClienteTaxasMora, A1041ClienteTaxasMora, n1042ClienteTaxasFator, A1042ClienteTaxasFator, n1043ClienteTaxasTipoTarifa, A1043ClienteTaxasTipoTarifa, n1044ClienteTaxasTarifa, A1044ClienteTaxasTarifa});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00348 */
                     pr_default.execute(6);
                     A1008ClienteTaxasId = BC00348_A1008ClienteTaxasId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("ClienteTaxas");
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
               Load34108( ) ;
            }
            EndLevel34108( ) ;
         }
         CloseExtendedTableCursors34108( ) ;
      }

      protected void Update34108( )
      {
         BeforeValidate34108( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable34108( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency34108( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm34108( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate34108( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00349 */
                     pr_default.execute(7, new Object[] {n1045ClienteTaxasCreatedAt, A1045ClienteTaxasCreatedAt, n1046ClienteTaxasUpdatedAt, A1046ClienteTaxasUpdatedAt, n1009ClienteTaxasTipo, A1009ClienteTaxasTipo, n1040ClienteTaxasEfetiva, A1040ClienteTaxasEfetiva, n1041ClienteTaxasMora, A1041ClienteTaxasMora, n1042ClienteTaxasFator, A1042ClienteTaxasFator, n1043ClienteTaxasTipoTarifa, A1043ClienteTaxasTipoTarifa, n1044ClienteTaxasTarifa, A1044ClienteTaxasTarifa, A1008ClienteTaxasId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("ClienteTaxas");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ClienteTaxas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate34108( ) ;
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
            EndLevel34108( ) ;
         }
         CloseExtendedTableCursors34108( ) ;
      }

      protected void DeferredUpdate34108( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate34108( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency34108( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls34108( ) ;
            AfterConfirm34108( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete34108( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC003410 */
                  pr_default.execute(8, new Object[] {A1008ClienteTaxasId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("ClienteTaxas");
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
         sMode108 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel34108( ) ;
         Gx_mode = sMode108;
      }

      protected void OnDeleteControls34108( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel34108( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete34108( ) ;
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

      public void ScanKeyStart34108( )
      {
         /* Scan By routine */
         /* Using cursor BC003411 */
         pr_default.execute(9, new Object[] {A1008ClienteTaxasId});
         RcdFound108 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound108 = 1;
            A1008ClienteTaxasId = BC003411_A1008ClienteTaxasId[0];
            A1045ClienteTaxasCreatedAt = BC003411_A1045ClienteTaxasCreatedAt[0];
            n1045ClienteTaxasCreatedAt = BC003411_n1045ClienteTaxasCreatedAt[0];
            A1046ClienteTaxasUpdatedAt = BC003411_A1046ClienteTaxasUpdatedAt[0];
            n1046ClienteTaxasUpdatedAt = BC003411_n1046ClienteTaxasUpdatedAt[0];
            A1009ClienteTaxasTipo = BC003411_A1009ClienteTaxasTipo[0];
            n1009ClienteTaxasTipo = BC003411_n1009ClienteTaxasTipo[0];
            A1040ClienteTaxasEfetiva = BC003411_A1040ClienteTaxasEfetiva[0];
            n1040ClienteTaxasEfetiva = BC003411_n1040ClienteTaxasEfetiva[0];
            A1041ClienteTaxasMora = BC003411_A1041ClienteTaxasMora[0];
            n1041ClienteTaxasMora = BC003411_n1041ClienteTaxasMora[0];
            A1042ClienteTaxasFator = BC003411_A1042ClienteTaxasFator[0];
            n1042ClienteTaxasFator = BC003411_n1042ClienteTaxasFator[0];
            A1043ClienteTaxasTipoTarifa = BC003411_A1043ClienteTaxasTipoTarifa[0];
            n1043ClienteTaxasTipoTarifa = BC003411_n1043ClienteTaxasTipoTarifa[0];
            A1044ClienteTaxasTarifa = BC003411_A1044ClienteTaxasTarifa[0];
            n1044ClienteTaxasTarifa = BC003411_n1044ClienteTaxasTarifa[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext34108( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound108 = 0;
         ScanKeyLoad34108( ) ;
      }

      protected void ScanKeyLoad34108( )
      {
         sMode108 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound108 = 1;
            A1008ClienteTaxasId = BC003411_A1008ClienteTaxasId[0];
            A1045ClienteTaxasCreatedAt = BC003411_A1045ClienteTaxasCreatedAt[0];
            n1045ClienteTaxasCreatedAt = BC003411_n1045ClienteTaxasCreatedAt[0];
            A1046ClienteTaxasUpdatedAt = BC003411_A1046ClienteTaxasUpdatedAt[0];
            n1046ClienteTaxasUpdatedAt = BC003411_n1046ClienteTaxasUpdatedAt[0];
            A1009ClienteTaxasTipo = BC003411_A1009ClienteTaxasTipo[0];
            n1009ClienteTaxasTipo = BC003411_n1009ClienteTaxasTipo[0];
            A1040ClienteTaxasEfetiva = BC003411_A1040ClienteTaxasEfetiva[0];
            n1040ClienteTaxasEfetiva = BC003411_n1040ClienteTaxasEfetiva[0];
            A1041ClienteTaxasMora = BC003411_A1041ClienteTaxasMora[0];
            n1041ClienteTaxasMora = BC003411_n1041ClienteTaxasMora[0];
            A1042ClienteTaxasFator = BC003411_A1042ClienteTaxasFator[0];
            n1042ClienteTaxasFator = BC003411_n1042ClienteTaxasFator[0];
            A1043ClienteTaxasTipoTarifa = BC003411_A1043ClienteTaxasTipoTarifa[0];
            n1043ClienteTaxasTipoTarifa = BC003411_n1043ClienteTaxasTipoTarifa[0];
            A1044ClienteTaxasTarifa = BC003411_A1044ClienteTaxasTarifa[0];
            n1044ClienteTaxasTarifa = BC003411_n1044ClienteTaxasTarifa[0];
         }
         Gx_mode = sMode108;
      }

      protected void ScanKeyEnd34108( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm34108( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert34108( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate34108( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete34108( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete34108( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate34108( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes34108( )
      {
      }

      protected void send_integrity_lvl_hashes34108( )
      {
      }

      protected void AddRow34108( )
      {
         VarsToRow108( bcClienteTaxas) ;
      }

      protected void ReadRow34108( )
      {
         RowToVars108( bcClienteTaxas, 1) ;
      }

      protected void InitializeNonKey34108( )
      {
         A1045ClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         n1045ClienteTaxasCreatedAt = false;
         A1046ClienteTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         n1046ClienteTaxasUpdatedAt = false;
         A1009ClienteTaxasTipo = "";
         n1009ClienteTaxasTipo = false;
         A1040ClienteTaxasEfetiva = 0;
         n1040ClienteTaxasEfetiva = false;
         A1041ClienteTaxasMora = 0;
         n1041ClienteTaxasMora = false;
         A1042ClienteTaxasFator = 0;
         n1042ClienteTaxasFator = false;
         A1043ClienteTaxasTipoTarifa = "";
         n1043ClienteTaxasTipoTarifa = false;
         A1044ClienteTaxasTarifa = 0;
         n1044ClienteTaxasTarifa = false;
         Z1045ClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         Z1046ClienteTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1009ClienteTaxasTipo = "";
         Z1040ClienteTaxasEfetiva = 0;
         Z1041ClienteTaxasMora = 0;
         Z1042ClienteTaxasFator = 0;
         Z1043ClienteTaxasTipoTarifa = "";
         Z1044ClienteTaxasTarifa = 0;
      }

      protected void InitAll34108( )
      {
         A1008ClienteTaxasId = 0;
         InitializeNonKey34108( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1045ClienteTaxasCreatedAt = i1045ClienteTaxasCreatedAt;
         n1045ClienteTaxasCreatedAt = false;
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

      public void VarsToRow108( SdtClienteTaxas obj108 )
      {
         obj108.gxTpr_Mode = Gx_mode;
         obj108.gxTpr_Clientetaxascreatedat = A1045ClienteTaxasCreatedAt;
         obj108.gxTpr_Clientetaxasupdatedat = A1046ClienteTaxasUpdatedAt;
         obj108.gxTpr_Clientetaxastipo = A1009ClienteTaxasTipo;
         obj108.gxTpr_Clientetaxasefetiva = A1040ClienteTaxasEfetiva;
         obj108.gxTpr_Clientetaxasmora = A1041ClienteTaxasMora;
         obj108.gxTpr_Clientetaxasfator = A1042ClienteTaxasFator;
         obj108.gxTpr_Clientetaxastipotarifa = A1043ClienteTaxasTipoTarifa;
         obj108.gxTpr_Clientetaxastarifa = A1044ClienteTaxasTarifa;
         obj108.gxTpr_Clientetaxasid = A1008ClienteTaxasId;
         obj108.gxTpr_Clientetaxasid_Z = Z1008ClienteTaxasId;
         obj108.gxTpr_Clientetaxastipo_Z = Z1009ClienteTaxasTipo;
         obj108.gxTpr_Clientetaxasefetiva_Z = Z1040ClienteTaxasEfetiva;
         obj108.gxTpr_Clientetaxasmora_Z = Z1041ClienteTaxasMora;
         obj108.gxTpr_Clientetaxasfator_Z = Z1042ClienteTaxasFator;
         obj108.gxTpr_Clientetaxastipotarifa_Z = Z1043ClienteTaxasTipoTarifa;
         obj108.gxTpr_Clientetaxastarifa_Z = Z1044ClienteTaxasTarifa;
         obj108.gxTpr_Clientetaxascreatedat_Z = Z1045ClienteTaxasCreatedAt;
         obj108.gxTpr_Clientetaxasupdatedat_Z = Z1046ClienteTaxasUpdatedAt;
         obj108.gxTpr_Clientetaxastipo_N = (short)(Convert.ToInt16(n1009ClienteTaxasTipo));
         obj108.gxTpr_Clientetaxasefetiva_N = (short)(Convert.ToInt16(n1040ClienteTaxasEfetiva));
         obj108.gxTpr_Clientetaxasmora_N = (short)(Convert.ToInt16(n1041ClienteTaxasMora));
         obj108.gxTpr_Clientetaxasfator_N = (short)(Convert.ToInt16(n1042ClienteTaxasFator));
         obj108.gxTpr_Clientetaxastipotarifa_N = (short)(Convert.ToInt16(n1043ClienteTaxasTipoTarifa));
         obj108.gxTpr_Clientetaxastarifa_N = (short)(Convert.ToInt16(n1044ClienteTaxasTarifa));
         obj108.gxTpr_Clientetaxascreatedat_N = (short)(Convert.ToInt16(n1045ClienteTaxasCreatedAt));
         obj108.gxTpr_Clientetaxasupdatedat_N = (short)(Convert.ToInt16(n1046ClienteTaxasUpdatedAt));
         obj108.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow108( SdtClienteTaxas obj108 )
      {
         obj108.gxTpr_Clientetaxasid = A1008ClienteTaxasId;
         return  ;
      }

      public void RowToVars108( SdtClienteTaxas obj108 ,
                                int forceLoad )
      {
         Gx_mode = obj108.gxTpr_Mode;
         A1045ClienteTaxasCreatedAt = obj108.gxTpr_Clientetaxascreatedat;
         n1045ClienteTaxasCreatedAt = false;
         A1046ClienteTaxasUpdatedAt = obj108.gxTpr_Clientetaxasupdatedat;
         n1046ClienteTaxasUpdatedAt = false;
         A1009ClienteTaxasTipo = obj108.gxTpr_Clientetaxastipo;
         n1009ClienteTaxasTipo = false;
         A1040ClienteTaxasEfetiva = obj108.gxTpr_Clientetaxasefetiva;
         n1040ClienteTaxasEfetiva = false;
         A1041ClienteTaxasMora = obj108.gxTpr_Clientetaxasmora;
         n1041ClienteTaxasMora = false;
         A1042ClienteTaxasFator = obj108.gxTpr_Clientetaxasfator;
         n1042ClienteTaxasFator = false;
         A1043ClienteTaxasTipoTarifa = obj108.gxTpr_Clientetaxastipotarifa;
         n1043ClienteTaxasTipoTarifa = false;
         A1044ClienteTaxasTarifa = obj108.gxTpr_Clientetaxastarifa;
         n1044ClienteTaxasTarifa = false;
         A1008ClienteTaxasId = obj108.gxTpr_Clientetaxasid;
         Z1008ClienteTaxasId = obj108.gxTpr_Clientetaxasid_Z;
         Z1009ClienteTaxasTipo = obj108.gxTpr_Clientetaxastipo_Z;
         Z1040ClienteTaxasEfetiva = obj108.gxTpr_Clientetaxasefetiva_Z;
         Z1041ClienteTaxasMora = obj108.gxTpr_Clientetaxasmora_Z;
         Z1042ClienteTaxasFator = obj108.gxTpr_Clientetaxasfator_Z;
         Z1043ClienteTaxasTipoTarifa = obj108.gxTpr_Clientetaxastipotarifa_Z;
         Z1044ClienteTaxasTarifa = obj108.gxTpr_Clientetaxastarifa_Z;
         Z1045ClienteTaxasCreatedAt = obj108.gxTpr_Clientetaxascreatedat_Z;
         Z1046ClienteTaxasUpdatedAt = obj108.gxTpr_Clientetaxasupdatedat_Z;
         n1009ClienteTaxasTipo = (bool)(Convert.ToBoolean(obj108.gxTpr_Clientetaxastipo_N));
         n1040ClienteTaxasEfetiva = (bool)(Convert.ToBoolean(obj108.gxTpr_Clientetaxasefetiva_N));
         n1041ClienteTaxasMora = (bool)(Convert.ToBoolean(obj108.gxTpr_Clientetaxasmora_N));
         n1042ClienteTaxasFator = (bool)(Convert.ToBoolean(obj108.gxTpr_Clientetaxasfator_N));
         n1043ClienteTaxasTipoTarifa = (bool)(Convert.ToBoolean(obj108.gxTpr_Clientetaxastipotarifa_N));
         n1044ClienteTaxasTarifa = (bool)(Convert.ToBoolean(obj108.gxTpr_Clientetaxastarifa_N));
         n1045ClienteTaxasCreatedAt = (bool)(Convert.ToBoolean(obj108.gxTpr_Clientetaxascreatedat_N));
         n1046ClienteTaxasUpdatedAt = (bool)(Convert.ToBoolean(obj108.gxTpr_Clientetaxasupdatedat_N));
         Gx_mode = obj108.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1008ClienteTaxasId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey34108( ) ;
         ScanKeyStart34108( ) ;
         if ( RcdFound108 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1008ClienteTaxasId = A1008ClienteTaxasId;
         }
         ZM34108( -4) ;
         OnLoadActions34108( ) ;
         AddRow34108( ) ;
         ScanKeyEnd34108( ) ;
         if ( RcdFound108 == 0 )
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
         RowToVars108( bcClienteTaxas, 0) ;
         ScanKeyStart34108( ) ;
         if ( RcdFound108 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1008ClienteTaxasId = A1008ClienteTaxasId;
         }
         ZM34108( -4) ;
         OnLoadActions34108( ) ;
         AddRow34108( ) ;
         ScanKeyEnd34108( ) ;
         if ( RcdFound108 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey34108( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert34108( ) ;
         }
         else
         {
            if ( RcdFound108 == 1 )
            {
               if ( A1008ClienteTaxasId != Z1008ClienteTaxasId )
               {
                  A1008ClienteTaxasId = Z1008ClienteTaxasId;
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
                  Update34108( ) ;
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
                  if ( A1008ClienteTaxasId != Z1008ClienteTaxasId )
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
                        Insert34108( ) ;
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
                        Insert34108( ) ;
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
         RowToVars108( bcClienteTaxas, 1) ;
         SaveImpl( ) ;
         VarsToRow108( bcClienteTaxas) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars108( bcClienteTaxas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert34108( ) ;
         AfterTrn( ) ;
         VarsToRow108( bcClienteTaxas) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow108( bcClienteTaxas) ;
         }
         else
         {
            SdtClienteTaxas auxBC = new SdtClienteTaxas(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1008ClienteTaxasId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcClienteTaxas);
               auxBC.Save();
               bcClienteTaxas.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars108( bcClienteTaxas, 1) ;
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
         RowToVars108( bcClienteTaxas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert34108( ) ;
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
               VarsToRow108( bcClienteTaxas) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow108( bcClienteTaxas) ;
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
         RowToVars108( bcClienteTaxas, 0) ;
         GetKey34108( ) ;
         if ( RcdFound108 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1008ClienteTaxasId != Z1008ClienteTaxasId )
            {
               A1008ClienteTaxasId = Z1008ClienteTaxasId;
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
            if ( A1008ClienteTaxasId != Z1008ClienteTaxasId )
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
         context.RollbackDataStores("clientetaxas_bc",pr_default);
         VarsToRow108( bcClienteTaxas) ;
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
         Gx_mode = bcClienteTaxas.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcClienteTaxas.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcClienteTaxas )
         {
            bcClienteTaxas = (SdtClienteTaxas)(sdt);
            if ( StringUtil.StrCmp(bcClienteTaxas.gxTpr_Mode, "") == 0 )
            {
               bcClienteTaxas.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow108( bcClienteTaxas) ;
            }
            else
            {
               RowToVars108( bcClienteTaxas, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcClienteTaxas.gxTpr_Mode, "") == 0 )
            {
               bcClienteTaxas.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars108( bcClienteTaxas, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtClienteTaxas ClienteTaxas_BC
      {
         get {
            return bcClienteTaxas ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z1045ClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         A1045ClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         Z1046ClienteTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         A1046ClienteTaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1009ClienteTaxasTipo = "";
         A1009ClienteTaxasTipo = "";
         Z1043ClienteTaxasTipoTarifa = "";
         A1043ClienteTaxasTipoTarifa = "";
         BC00344_A1008ClienteTaxasId = new int[1] ;
         BC00344_A1045ClienteTaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00344_n1045ClienteTaxasCreatedAt = new bool[] {false} ;
         BC00344_A1046ClienteTaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00344_n1046ClienteTaxasUpdatedAt = new bool[] {false} ;
         BC00344_A1009ClienteTaxasTipo = new string[] {""} ;
         BC00344_n1009ClienteTaxasTipo = new bool[] {false} ;
         BC00344_A1040ClienteTaxasEfetiva = new decimal[1] ;
         BC00344_n1040ClienteTaxasEfetiva = new bool[] {false} ;
         BC00344_A1041ClienteTaxasMora = new decimal[1] ;
         BC00344_n1041ClienteTaxasMora = new bool[] {false} ;
         BC00344_A1042ClienteTaxasFator = new decimal[1] ;
         BC00344_n1042ClienteTaxasFator = new bool[] {false} ;
         BC00344_A1043ClienteTaxasTipoTarifa = new string[] {""} ;
         BC00344_n1043ClienteTaxasTipoTarifa = new bool[] {false} ;
         BC00344_A1044ClienteTaxasTarifa = new decimal[1] ;
         BC00344_n1044ClienteTaxasTarifa = new bool[] {false} ;
         BC00345_A1009ClienteTaxasTipo = new string[] {""} ;
         BC00345_n1009ClienteTaxasTipo = new bool[] {false} ;
         BC00346_A1008ClienteTaxasId = new int[1] ;
         BC00343_A1008ClienteTaxasId = new int[1] ;
         BC00343_A1045ClienteTaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00343_n1045ClienteTaxasCreatedAt = new bool[] {false} ;
         BC00343_A1046ClienteTaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00343_n1046ClienteTaxasUpdatedAt = new bool[] {false} ;
         BC00343_A1009ClienteTaxasTipo = new string[] {""} ;
         BC00343_n1009ClienteTaxasTipo = new bool[] {false} ;
         BC00343_A1040ClienteTaxasEfetiva = new decimal[1] ;
         BC00343_n1040ClienteTaxasEfetiva = new bool[] {false} ;
         BC00343_A1041ClienteTaxasMora = new decimal[1] ;
         BC00343_n1041ClienteTaxasMora = new bool[] {false} ;
         BC00343_A1042ClienteTaxasFator = new decimal[1] ;
         BC00343_n1042ClienteTaxasFator = new bool[] {false} ;
         BC00343_A1043ClienteTaxasTipoTarifa = new string[] {""} ;
         BC00343_n1043ClienteTaxasTipoTarifa = new bool[] {false} ;
         BC00343_A1044ClienteTaxasTarifa = new decimal[1] ;
         BC00343_n1044ClienteTaxasTarifa = new bool[] {false} ;
         sMode108 = "";
         BC00342_A1008ClienteTaxasId = new int[1] ;
         BC00342_A1045ClienteTaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00342_n1045ClienteTaxasCreatedAt = new bool[] {false} ;
         BC00342_A1046ClienteTaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00342_n1046ClienteTaxasUpdatedAt = new bool[] {false} ;
         BC00342_A1009ClienteTaxasTipo = new string[] {""} ;
         BC00342_n1009ClienteTaxasTipo = new bool[] {false} ;
         BC00342_A1040ClienteTaxasEfetiva = new decimal[1] ;
         BC00342_n1040ClienteTaxasEfetiva = new bool[] {false} ;
         BC00342_A1041ClienteTaxasMora = new decimal[1] ;
         BC00342_n1041ClienteTaxasMora = new bool[] {false} ;
         BC00342_A1042ClienteTaxasFator = new decimal[1] ;
         BC00342_n1042ClienteTaxasFator = new bool[] {false} ;
         BC00342_A1043ClienteTaxasTipoTarifa = new string[] {""} ;
         BC00342_n1043ClienteTaxasTipoTarifa = new bool[] {false} ;
         BC00342_A1044ClienteTaxasTarifa = new decimal[1] ;
         BC00342_n1044ClienteTaxasTarifa = new bool[] {false} ;
         BC00348_A1008ClienteTaxasId = new int[1] ;
         BC003411_A1008ClienteTaxasId = new int[1] ;
         BC003411_A1045ClienteTaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003411_n1045ClienteTaxasCreatedAt = new bool[] {false} ;
         BC003411_A1046ClienteTaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003411_n1046ClienteTaxasUpdatedAt = new bool[] {false} ;
         BC003411_A1009ClienteTaxasTipo = new string[] {""} ;
         BC003411_n1009ClienteTaxasTipo = new bool[] {false} ;
         BC003411_A1040ClienteTaxasEfetiva = new decimal[1] ;
         BC003411_n1040ClienteTaxasEfetiva = new bool[] {false} ;
         BC003411_A1041ClienteTaxasMora = new decimal[1] ;
         BC003411_n1041ClienteTaxasMora = new bool[] {false} ;
         BC003411_A1042ClienteTaxasFator = new decimal[1] ;
         BC003411_n1042ClienteTaxasFator = new bool[] {false} ;
         BC003411_A1043ClienteTaxasTipoTarifa = new string[] {""} ;
         BC003411_n1043ClienteTaxasTipoTarifa = new bool[] {false} ;
         BC003411_A1044ClienteTaxasTarifa = new decimal[1] ;
         BC003411_n1044ClienteTaxasTarifa = new bool[] {false} ;
         i1045ClienteTaxasCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientetaxas_bc__default(),
            new Object[][] {
                new Object[] {
               BC00342_A1008ClienteTaxasId, BC00342_A1045ClienteTaxasCreatedAt, BC00342_n1045ClienteTaxasCreatedAt, BC00342_A1046ClienteTaxasUpdatedAt, BC00342_n1046ClienteTaxasUpdatedAt, BC00342_A1009ClienteTaxasTipo, BC00342_n1009ClienteTaxasTipo, BC00342_A1040ClienteTaxasEfetiva, BC00342_n1040ClienteTaxasEfetiva, BC00342_A1041ClienteTaxasMora,
               BC00342_n1041ClienteTaxasMora, BC00342_A1042ClienteTaxasFator, BC00342_n1042ClienteTaxasFator, BC00342_A1043ClienteTaxasTipoTarifa, BC00342_n1043ClienteTaxasTipoTarifa, BC00342_A1044ClienteTaxasTarifa, BC00342_n1044ClienteTaxasTarifa
               }
               , new Object[] {
               BC00343_A1008ClienteTaxasId, BC00343_A1045ClienteTaxasCreatedAt, BC00343_n1045ClienteTaxasCreatedAt, BC00343_A1046ClienteTaxasUpdatedAt, BC00343_n1046ClienteTaxasUpdatedAt, BC00343_A1009ClienteTaxasTipo, BC00343_n1009ClienteTaxasTipo, BC00343_A1040ClienteTaxasEfetiva, BC00343_n1040ClienteTaxasEfetiva, BC00343_A1041ClienteTaxasMora,
               BC00343_n1041ClienteTaxasMora, BC00343_A1042ClienteTaxasFator, BC00343_n1042ClienteTaxasFator, BC00343_A1043ClienteTaxasTipoTarifa, BC00343_n1043ClienteTaxasTipoTarifa, BC00343_A1044ClienteTaxasTarifa, BC00343_n1044ClienteTaxasTarifa
               }
               , new Object[] {
               BC00344_A1008ClienteTaxasId, BC00344_A1045ClienteTaxasCreatedAt, BC00344_n1045ClienteTaxasCreatedAt, BC00344_A1046ClienteTaxasUpdatedAt, BC00344_n1046ClienteTaxasUpdatedAt, BC00344_A1009ClienteTaxasTipo, BC00344_n1009ClienteTaxasTipo, BC00344_A1040ClienteTaxasEfetiva, BC00344_n1040ClienteTaxasEfetiva, BC00344_A1041ClienteTaxasMora,
               BC00344_n1041ClienteTaxasMora, BC00344_A1042ClienteTaxasFator, BC00344_n1042ClienteTaxasFator, BC00344_A1043ClienteTaxasTipoTarifa, BC00344_n1043ClienteTaxasTipoTarifa, BC00344_A1044ClienteTaxasTarifa, BC00344_n1044ClienteTaxasTarifa
               }
               , new Object[] {
               BC00345_A1009ClienteTaxasTipo, BC00345_n1009ClienteTaxasTipo
               }
               , new Object[] {
               BC00346_A1008ClienteTaxasId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00348_A1008ClienteTaxasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC003411_A1008ClienteTaxasId, BC003411_A1045ClienteTaxasCreatedAt, BC003411_n1045ClienteTaxasCreatedAt, BC003411_A1046ClienteTaxasUpdatedAt, BC003411_n1046ClienteTaxasUpdatedAt, BC003411_A1009ClienteTaxasTipo, BC003411_n1009ClienteTaxasTipo, BC003411_A1040ClienteTaxasEfetiva, BC003411_n1040ClienteTaxasEfetiva, BC003411_A1041ClienteTaxasMora,
               BC003411_n1041ClienteTaxasMora, BC003411_A1042ClienteTaxasFator, BC003411_n1042ClienteTaxasFator, BC003411_A1043ClienteTaxasTipoTarifa, BC003411_n1043ClienteTaxasTipoTarifa, BC003411_A1044ClienteTaxasTarifa, BC003411_n1044ClienteTaxasTarifa
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12342 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound108 ;
      private int trnEnded ;
      private int Z1008ClienteTaxasId ;
      private int A1008ClienteTaxasId ;
      private decimal Z1040ClienteTaxasEfetiva ;
      private decimal A1040ClienteTaxasEfetiva ;
      private decimal Z1041ClienteTaxasMora ;
      private decimal A1041ClienteTaxasMora ;
      private decimal Z1042ClienteTaxasFator ;
      private decimal A1042ClienteTaxasFator ;
      private decimal Z1044ClienteTaxasTarifa ;
      private decimal A1044ClienteTaxasTarifa ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode108 ;
      private DateTime Z1045ClienteTaxasCreatedAt ;
      private DateTime A1045ClienteTaxasCreatedAt ;
      private DateTime Z1046ClienteTaxasUpdatedAt ;
      private DateTime A1046ClienteTaxasUpdatedAt ;
      private DateTime i1045ClienteTaxasCreatedAt ;
      private bool returnInSub ;
      private bool n1045ClienteTaxasCreatedAt ;
      private bool n1046ClienteTaxasUpdatedAt ;
      private bool n1009ClienteTaxasTipo ;
      private bool n1040ClienteTaxasEfetiva ;
      private bool n1041ClienteTaxasMora ;
      private bool n1042ClienteTaxasFator ;
      private bool n1043ClienteTaxasTipoTarifa ;
      private bool n1044ClienteTaxasTarifa ;
      private bool Gx_longc ;
      private string Z1009ClienteTaxasTipo ;
      private string A1009ClienteTaxasTipo ;
      private string Z1043ClienteTaxasTipoTarifa ;
      private string A1043ClienteTaxasTipoTarifa ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC00344_A1008ClienteTaxasId ;
      private DateTime[] BC00344_A1045ClienteTaxasCreatedAt ;
      private bool[] BC00344_n1045ClienteTaxasCreatedAt ;
      private DateTime[] BC00344_A1046ClienteTaxasUpdatedAt ;
      private bool[] BC00344_n1046ClienteTaxasUpdatedAt ;
      private string[] BC00344_A1009ClienteTaxasTipo ;
      private bool[] BC00344_n1009ClienteTaxasTipo ;
      private decimal[] BC00344_A1040ClienteTaxasEfetiva ;
      private bool[] BC00344_n1040ClienteTaxasEfetiva ;
      private decimal[] BC00344_A1041ClienteTaxasMora ;
      private bool[] BC00344_n1041ClienteTaxasMora ;
      private decimal[] BC00344_A1042ClienteTaxasFator ;
      private bool[] BC00344_n1042ClienteTaxasFator ;
      private string[] BC00344_A1043ClienteTaxasTipoTarifa ;
      private bool[] BC00344_n1043ClienteTaxasTipoTarifa ;
      private decimal[] BC00344_A1044ClienteTaxasTarifa ;
      private bool[] BC00344_n1044ClienteTaxasTarifa ;
      private string[] BC00345_A1009ClienteTaxasTipo ;
      private bool[] BC00345_n1009ClienteTaxasTipo ;
      private int[] BC00346_A1008ClienteTaxasId ;
      private int[] BC00343_A1008ClienteTaxasId ;
      private DateTime[] BC00343_A1045ClienteTaxasCreatedAt ;
      private bool[] BC00343_n1045ClienteTaxasCreatedAt ;
      private DateTime[] BC00343_A1046ClienteTaxasUpdatedAt ;
      private bool[] BC00343_n1046ClienteTaxasUpdatedAt ;
      private string[] BC00343_A1009ClienteTaxasTipo ;
      private bool[] BC00343_n1009ClienteTaxasTipo ;
      private decimal[] BC00343_A1040ClienteTaxasEfetiva ;
      private bool[] BC00343_n1040ClienteTaxasEfetiva ;
      private decimal[] BC00343_A1041ClienteTaxasMora ;
      private bool[] BC00343_n1041ClienteTaxasMora ;
      private decimal[] BC00343_A1042ClienteTaxasFator ;
      private bool[] BC00343_n1042ClienteTaxasFator ;
      private string[] BC00343_A1043ClienteTaxasTipoTarifa ;
      private bool[] BC00343_n1043ClienteTaxasTipoTarifa ;
      private decimal[] BC00343_A1044ClienteTaxasTarifa ;
      private bool[] BC00343_n1044ClienteTaxasTarifa ;
      private int[] BC00342_A1008ClienteTaxasId ;
      private DateTime[] BC00342_A1045ClienteTaxasCreatedAt ;
      private bool[] BC00342_n1045ClienteTaxasCreatedAt ;
      private DateTime[] BC00342_A1046ClienteTaxasUpdatedAt ;
      private bool[] BC00342_n1046ClienteTaxasUpdatedAt ;
      private string[] BC00342_A1009ClienteTaxasTipo ;
      private bool[] BC00342_n1009ClienteTaxasTipo ;
      private decimal[] BC00342_A1040ClienteTaxasEfetiva ;
      private bool[] BC00342_n1040ClienteTaxasEfetiva ;
      private decimal[] BC00342_A1041ClienteTaxasMora ;
      private bool[] BC00342_n1041ClienteTaxasMora ;
      private decimal[] BC00342_A1042ClienteTaxasFator ;
      private bool[] BC00342_n1042ClienteTaxasFator ;
      private string[] BC00342_A1043ClienteTaxasTipoTarifa ;
      private bool[] BC00342_n1043ClienteTaxasTipoTarifa ;
      private decimal[] BC00342_A1044ClienteTaxasTarifa ;
      private bool[] BC00342_n1044ClienteTaxasTarifa ;
      private int[] BC00348_A1008ClienteTaxasId ;
      private int[] BC003411_A1008ClienteTaxasId ;
      private DateTime[] BC003411_A1045ClienteTaxasCreatedAt ;
      private bool[] BC003411_n1045ClienteTaxasCreatedAt ;
      private DateTime[] BC003411_A1046ClienteTaxasUpdatedAt ;
      private bool[] BC003411_n1046ClienteTaxasUpdatedAt ;
      private string[] BC003411_A1009ClienteTaxasTipo ;
      private bool[] BC003411_n1009ClienteTaxasTipo ;
      private decimal[] BC003411_A1040ClienteTaxasEfetiva ;
      private bool[] BC003411_n1040ClienteTaxasEfetiva ;
      private decimal[] BC003411_A1041ClienteTaxasMora ;
      private bool[] BC003411_n1041ClienteTaxasMora ;
      private decimal[] BC003411_A1042ClienteTaxasFator ;
      private bool[] BC003411_n1042ClienteTaxasFator ;
      private string[] BC003411_A1043ClienteTaxasTipoTarifa ;
      private bool[] BC003411_n1043ClienteTaxasTipoTarifa ;
      private decimal[] BC003411_A1044ClienteTaxasTarifa ;
      private bool[] BC003411_n1044ClienteTaxasTarifa ;
      private SdtClienteTaxas bcClienteTaxas ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class clientetaxas_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00342;
          prmBC00342 = new Object[] {
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmBC00343;
          prmBC00343 = new Object[] {
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmBC00344;
          prmBC00344 = new Object[] {
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmBC00345;
          prmBC00345 = new Object[] {
          new ParDef("ClienteTaxasTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmBC00346;
          prmBC00346 = new Object[] {
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmBC00347;
          prmBC00347 = new Object[] {
          new ParDef("ClienteTaxasCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteTaxasUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteTaxasTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTaxasEfetiva",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ClienteTaxasMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ClienteTaxasFator",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ClienteTaxasTipoTarifa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTaxasTarifa",GXType.Number,15,2){Nullable=true}
          };
          Object[] prmBC00348;
          prmBC00348 = new Object[] {
          };
          Object[] prmBC00349;
          prmBC00349 = new Object[] {
          new ParDef("ClienteTaxasCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteTaxasUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ClienteTaxasTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTaxasEfetiva",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ClienteTaxasMora",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ClienteTaxasFator",GXType.Number,16,4){Nullable=true} ,
          new ParDef("ClienteTaxasTipoTarifa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteTaxasTarifa",GXType.Number,15,2){Nullable=true} ,
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmBC003410;
          prmBC003410 = new Object[] {
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          Object[] prmBC003411;
          prmBC003411 = new Object[] {
          new ParDef("ClienteTaxasId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00342", "SELECT ClienteTaxasId, ClienteTaxasCreatedAt, ClienteTaxasUpdatedAt, ClienteTaxasTipo, ClienteTaxasEfetiva, ClienteTaxasMora, ClienteTaxasFator, ClienteTaxasTipoTarifa, ClienteTaxasTarifa FROM ClienteTaxas WHERE ClienteTaxasId = :ClienteTaxasId  FOR UPDATE OF ClienteTaxas",true, GxErrorMask.GX_NOMASK, false, this,prmBC00342,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00343", "SELECT ClienteTaxasId, ClienteTaxasCreatedAt, ClienteTaxasUpdatedAt, ClienteTaxasTipo, ClienteTaxasEfetiva, ClienteTaxasMora, ClienteTaxasFator, ClienteTaxasTipoTarifa, ClienteTaxasTarifa FROM ClienteTaxas WHERE ClienteTaxasId = :ClienteTaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00343,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00344", "SELECT TM1.ClienteTaxasId, TM1.ClienteTaxasCreatedAt, TM1.ClienteTaxasUpdatedAt, TM1.ClienteTaxasTipo, TM1.ClienteTaxasEfetiva, TM1.ClienteTaxasMora, TM1.ClienteTaxasFator, TM1.ClienteTaxasTipoTarifa, TM1.ClienteTaxasTarifa FROM ClienteTaxas TM1 WHERE TM1.ClienteTaxasId = :ClienteTaxasId ORDER BY TM1.ClienteTaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00344,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00345", "SELECT ClienteTaxasTipo FROM ClienteTaxas WHERE (ClienteTaxasTipo = :ClienteTaxasTipo) AND (Not ( ClienteTaxasId = :ClienteTaxasId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00345,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00346", "SELECT ClienteTaxasId FROM ClienteTaxas WHERE ClienteTaxasId = :ClienteTaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00346,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00347", "SAVEPOINT gxupdate;INSERT INTO ClienteTaxas(ClienteTaxasCreatedAt, ClienteTaxasUpdatedAt, ClienteTaxasTipo, ClienteTaxasEfetiva, ClienteTaxasMora, ClienteTaxasFator, ClienteTaxasTipoTarifa, ClienteTaxasTarifa) VALUES(:ClienteTaxasCreatedAt, :ClienteTaxasUpdatedAt, :ClienteTaxasTipo, :ClienteTaxasEfetiva, :ClienteTaxasMora, :ClienteTaxasFator, :ClienteTaxasTipoTarifa, :ClienteTaxasTarifa);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00347)
             ,new CursorDef("BC00348", "SELECT currval('ClienteTaxasId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00348,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00349", "SAVEPOINT gxupdate;UPDATE ClienteTaxas SET ClienteTaxasCreatedAt=:ClienteTaxasCreatedAt, ClienteTaxasUpdatedAt=:ClienteTaxasUpdatedAt, ClienteTaxasTipo=:ClienteTaxasTipo, ClienteTaxasEfetiva=:ClienteTaxasEfetiva, ClienteTaxasMora=:ClienteTaxasMora, ClienteTaxasFator=:ClienteTaxasFator, ClienteTaxasTipoTarifa=:ClienteTaxasTipoTarifa, ClienteTaxasTarifa=:ClienteTaxasTarifa  WHERE ClienteTaxasId = :ClienteTaxasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00349)
             ,new CursorDef("BC003410", "SAVEPOINT gxupdate;DELETE FROM ClienteTaxas  WHERE ClienteTaxasId = :ClienteTaxasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003410)
             ,new CursorDef("BC003411", "SELECT TM1.ClienteTaxasId, TM1.ClienteTaxasCreatedAt, TM1.ClienteTaxasUpdatedAt, TM1.ClienteTaxasTipo, TM1.ClienteTaxasEfetiva, TM1.ClienteTaxasMora, TM1.ClienteTaxasFator, TM1.ClienteTaxasTipoTarifa, TM1.ClienteTaxasTarifa FROM ClienteTaxas TM1 WHERE TM1.ClienteTaxasId = :ClienteTaxasId ORDER BY TM1.ClienteTaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003411,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
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
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
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
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
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
                return;
       }
    }

 }

}
