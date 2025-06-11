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
   public class tipocliente_bc : GxSilentTrn, IGxSilentTrn
   {
      public tipocliente_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tipocliente_bc( IGxContext context )
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
         ReadRow0S32( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0S32( ) ;
         standaloneModal( ) ;
         AddRow0S32( ) ;
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
            E110S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z192TipoClienteId = A192TipoClienteId;
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

      protected void CONFIRM_0S0( )
      {
         BeforeValidate0S32( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0S32( ) ;
            }
            else
            {
               CheckExtendedTable0S32( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0S32( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120S2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0S32( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z195TipoClienteCreatedAt = A195TipoClienteCreatedAt;
            Z193TipoClienteDescricao = A193TipoClienteDescricao;
            Z194TipoClienteTipoPessoa = A194TipoClienteTipoPessoa;
            Z207TipoClientePortal = A207TipoClientePortal;
            Z793TipoClientePortalPjPf = A793TipoClientePortalPjPf;
            Z219TipoClienteFinancia = A219TipoClienteFinancia;
            Z196TipoClienteUpdateAt = A196TipoClienteUpdateAt;
         }
         if ( GX_JID == -5 )
         {
            Z192TipoClienteId = A192TipoClienteId;
            Z195TipoClienteCreatedAt = A195TipoClienteCreatedAt;
            Z193TipoClienteDescricao = A193TipoClienteDescricao;
            Z194TipoClienteTipoPessoa = A194TipoClienteTipoPessoa;
            Z207TipoClientePortal = A207TipoClientePortal;
            Z793TipoClientePortalPjPf = A793TipoClientePortalPjPf;
            Z219TipoClienteFinancia = A219TipoClienteFinancia;
            Z196TipoClienteUpdateAt = A196TipoClienteUpdateAt;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A195TipoClienteCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n195TipoClienteCreatedAt = false;
         }
      }

      protected void Load0S32( )
      {
         /* Using cursor BC000S4 */
         pr_default.execute(2, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound32 = 1;
            A195TipoClienteCreatedAt = BC000S4_A195TipoClienteCreatedAt[0];
            n195TipoClienteCreatedAt = BC000S4_n195TipoClienteCreatedAt[0];
            A193TipoClienteDescricao = BC000S4_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = BC000S4_n193TipoClienteDescricao[0];
            A194TipoClienteTipoPessoa = BC000S4_A194TipoClienteTipoPessoa[0];
            n194TipoClienteTipoPessoa = BC000S4_n194TipoClienteTipoPessoa[0];
            A207TipoClientePortal = BC000S4_A207TipoClientePortal[0];
            n207TipoClientePortal = BC000S4_n207TipoClientePortal[0];
            A793TipoClientePortalPjPf = BC000S4_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = BC000S4_n793TipoClientePortalPjPf[0];
            A219TipoClienteFinancia = BC000S4_A219TipoClienteFinancia[0];
            n219TipoClienteFinancia = BC000S4_n219TipoClienteFinancia[0];
            A196TipoClienteUpdateAt = BC000S4_A196TipoClienteUpdateAt[0];
            n196TipoClienteUpdateAt = BC000S4_n196TipoClienteUpdateAt[0];
            ZM0S32( -5) ;
         }
         pr_default.close(2);
         OnLoadActions0S32( ) ;
      }

      protected void OnLoadActions0S32( )
      {
      }

      protected void CheckExtendedTable0S32( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A193TipoClienteDescricao)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A194TipoClienteTipoPessoa, "FISICA") == 0 ) || ( StringUtil.StrCmp(A194TipoClienteTipoPessoa, "JURIDICA") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A194TipoClienteTipoPessoa)) ) )
         {
            GX_msglist.addItem("Campo Tipo Cliente Tipo Pessoa fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( A207TipoClientePortal && A793TipoClientePortalPjPf )
         {
            GX_msglist.addItem("Não é possível ter acesso á ambos portais", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0S32( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0S32( )
      {
         /* Using cursor BC000S5 */
         pr_default.execute(3, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000S3 */
         pr_default.execute(1, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0S32( 5) ;
            RcdFound32 = 1;
            A192TipoClienteId = BC000S3_A192TipoClienteId[0];
            n192TipoClienteId = BC000S3_n192TipoClienteId[0];
            A195TipoClienteCreatedAt = BC000S3_A195TipoClienteCreatedAt[0];
            n195TipoClienteCreatedAt = BC000S3_n195TipoClienteCreatedAt[0];
            A193TipoClienteDescricao = BC000S3_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = BC000S3_n193TipoClienteDescricao[0];
            A194TipoClienteTipoPessoa = BC000S3_A194TipoClienteTipoPessoa[0];
            n194TipoClienteTipoPessoa = BC000S3_n194TipoClienteTipoPessoa[0];
            A207TipoClientePortal = BC000S3_A207TipoClientePortal[0];
            n207TipoClientePortal = BC000S3_n207TipoClientePortal[0];
            A793TipoClientePortalPjPf = BC000S3_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = BC000S3_n793TipoClientePortalPjPf[0];
            A219TipoClienteFinancia = BC000S3_A219TipoClienteFinancia[0];
            n219TipoClienteFinancia = BC000S3_n219TipoClienteFinancia[0];
            A196TipoClienteUpdateAt = BC000S3_A196TipoClienteUpdateAt[0];
            n196TipoClienteUpdateAt = BC000S3_n196TipoClienteUpdateAt[0];
            Z192TipoClienteId = A192TipoClienteId;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0S32( ) ;
            if ( AnyError == 1 )
            {
               RcdFound32 = 0;
               InitializeNonKey0S32( ) ;
            }
            Gx_mode = sMode32;
         }
         else
         {
            RcdFound32 = 0;
            InitializeNonKey0S32( ) ;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode32;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0S32( ) ;
         if ( RcdFound32 == 0 )
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
         CONFIRM_0S0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0S32( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000S2 */
            pr_default.execute(0, new Object[] {n192TipoClienteId, A192TipoClienteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoCliente"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z195TipoClienteCreatedAt != BC000S2_A195TipoClienteCreatedAt[0] ) || ( StringUtil.StrCmp(Z193TipoClienteDescricao, BC000S2_A193TipoClienteDescricao[0]) != 0 ) || ( StringUtil.StrCmp(Z194TipoClienteTipoPessoa, BC000S2_A194TipoClienteTipoPessoa[0]) != 0 ) || ( Z207TipoClientePortal != BC000S2_A207TipoClientePortal[0] ) || ( Z793TipoClientePortalPjPf != BC000S2_A793TipoClientePortalPjPf[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z219TipoClienteFinancia != BC000S2_A219TipoClienteFinancia[0] ) || ( Z196TipoClienteUpdateAt != BC000S2_A196TipoClienteUpdateAt[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TipoCliente"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S32( )
      {
         BeforeValidate0S32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S32( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S32( 0) ;
            CheckOptimisticConcurrency0S32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S6 */
                     pr_default.execute(4, new Object[] {n195TipoClienteCreatedAt, A195TipoClienteCreatedAt, n193TipoClienteDescricao, A193TipoClienteDescricao, n194TipoClienteTipoPessoa, A194TipoClienteTipoPessoa, n207TipoClientePortal, A207TipoClientePortal, n793TipoClientePortalPjPf, A793TipoClientePortalPjPf, n219TipoClienteFinancia, A219TipoClienteFinancia, n196TipoClienteUpdateAt, A196TipoClienteUpdateAt});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000S7 */
                     pr_default.execute(5);
                     A192TipoClienteId = BC000S7_A192TipoClienteId[0];
                     n192TipoClienteId = BC000S7_n192TipoClienteId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("TipoCliente");
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
               Load0S32( ) ;
            }
            EndLevel0S32( ) ;
         }
         CloseExtendedTableCursors0S32( ) ;
      }

      protected void Update0S32( )
      {
         BeforeValidate0S32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S32( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0S32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S8 */
                     pr_default.execute(6, new Object[] {n195TipoClienteCreatedAt, A195TipoClienteCreatedAt, n193TipoClienteDescricao, A193TipoClienteDescricao, n194TipoClienteTipoPessoa, A194TipoClienteTipoPessoa, n207TipoClientePortal, A207TipoClientePortal, n793TipoClientePortalPjPf, A793TipoClientePortalPjPf, n219TipoClienteFinancia, A219TipoClienteFinancia, n196TipoClienteUpdateAt, A196TipoClienteUpdateAt, n192TipoClienteId, A192TipoClienteId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("TipoCliente");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TipoCliente"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0S32( ) ;
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
            EndLevel0S32( ) ;
         }
         CloseExtendedTableCursors0S32( ) ;
      }

      protected void DeferredUpdate0S32( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0S32( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S32( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S32( ) ;
            AfterConfirm0S32( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S32( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000S9 */
                  pr_default.execute(7, new Object[] {n192TipoClienteId, A192TipoClienteId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("TipoCliente");
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
         sMode32 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0S32( ) ;
         Gx_mode = sMode32;
      }

      protected void OnDeleteControls0S32( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000S10 */
            pr_default.execute(8, new Object[] {n192TipoClienteId, A192TipoClienteId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel0S32( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0S32( ) ;
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

      public void ScanKeyStart0S32( )
      {
         /* Scan By routine */
         /* Using cursor BC000S11 */
         pr_default.execute(9, new Object[] {n192TipoClienteId, A192TipoClienteId});
         RcdFound32 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound32 = 1;
            A192TipoClienteId = BC000S11_A192TipoClienteId[0];
            n192TipoClienteId = BC000S11_n192TipoClienteId[0];
            A195TipoClienteCreatedAt = BC000S11_A195TipoClienteCreatedAt[0];
            n195TipoClienteCreatedAt = BC000S11_n195TipoClienteCreatedAt[0];
            A193TipoClienteDescricao = BC000S11_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = BC000S11_n193TipoClienteDescricao[0];
            A194TipoClienteTipoPessoa = BC000S11_A194TipoClienteTipoPessoa[0];
            n194TipoClienteTipoPessoa = BC000S11_n194TipoClienteTipoPessoa[0];
            A207TipoClientePortal = BC000S11_A207TipoClientePortal[0];
            n207TipoClientePortal = BC000S11_n207TipoClientePortal[0];
            A793TipoClientePortalPjPf = BC000S11_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = BC000S11_n793TipoClientePortalPjPf[0];
            A219TipoClienteFinancia = BC000S11_A219TipoClienteFinancia[0];
            n219TipoClienteFinancia = BC000S11_n219TipoClienteFinancia[0];
            A196TipoClienteUpdateAt = BC000S11_A196TipoClienteUpdateAt[0];
            n196TipoClienteUpdateAt = BC000S11_n196TipoClienteUpdateAt[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0S32( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound32 = 0;
         ScanKeyLoad0S32( ) ;
      }

      protected void ScanKeyLoad0S32( )
      {
         sMode32 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound32 = 1;
            A192TipoClienteId = BC000S11_A192TipoClienteId[0];
            n192TipoClienteId = BC000S11_n192TipoClienteId[0];
            A195TipoClienteCreatedAt = BC000S11_A195TipoClienteCreatedAt[0];
            n195TipoClienteCreatedAt = BC000S11_n195TipoClienteCreatedAt[0];
            A193TipoClienteDescricao = BC000S11_A193TipoClienteDescricao[0];
            n193TipoClienteDescricao = BC000S11_n193TipoClienteDescricao[0];
            A194TipoClienteTipoPessoa = BC000S11_A194TipoClienteTipoPessoa[0];
            n194TipoClienteTipoPessoa = BC000S11_n194TipoClienteTipoPessoa[0];
            A207TipoClientePortal = BC000S11_A207TipoClientePortal[0];
            n207TipoClientePortal = BC000S11_n207TipoClientePortal[0];
            A793TipoClientePortalPjPf = BC000S11_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = BC000S11_n793TipoClientePortalPjPf[0];
            A219TipoClienteFinancia = BC000S11_A219TipoClienteFinancia[0];
            n219TipoClienteFinancia = BC000S11_n219TipoClienteFinancia[0];
            A196TipoClienteUpdateAt = BC000S11_A196TipoClienteUpdateAt[0];
            n196TipoClienteUpdateAt = BC000S11_n196TipoClienteUpdateAt[0];
         }
         Gx_mode = sMode32;
      }

      protected void ScanKeyEnd0S32( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0S32( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S32( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S32( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0S32( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0S32( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0S32( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S32( )
      {
      }

      protected void send_integrity_lvl_hashes0S32( )
      {
      }

      protected void AddRow0S32( )
      {
         VarsToRow32( bcTipoCliente) ;
      }

      protected void ReadRow0S32( )
      {
         RowToVars32( bcTipoCliente, 1) ;
      }

      protected void InitializeNonKey0S32( )
      {
         A195TipoClienteCreatedAt = (DateTime)(DateTime.MinValue);
         n195TipoClienteCreatedAt = false;
         A193TipoClienteDescricao = "";
         n193TipoClienteDescricao = false;
         A194TipoClienteTipoPessoa = "";
         n194TipoClienteTipoPessoa = false;
         A207TipoClientePortal = false;
         n207TipoClientePortal = false;
         A793TipoClientePortalPjPf = false;
         n793TipoClientePortalPjPf = false;
         A219TipoClienteFinancia = false;
         n219TipoClienteFinancia = false;
         A196TipoClienteUpdateAt = (DateTime)(DateTime.MinValue);
         n196TipoClienteUpdateAt = false;
         Z195TipoClienteCreatedAt = (DateTime)(DateTime.MinValue);
         Z193TipoClienteDescricao = "";
         Z194TipoClienteTipoPessoa = "";
         Z207TipoClientePortal = false;
         Z793TipoClientePortalPjPf = false;
         Z219TipoClienteFinancia = false;
         Z196TipoClienteUpdateAt = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll0S32( )
      {
         A192TipoClienteId = 0;
         n192TipoClienteId = false;
         InitializeNonKey0S32( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A195TipoClienteCreatedAt = i195TipoClienteCreatedAt;
         n195TipoClienteCreatedAt = false;
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

      public void VarsToRow32( SdtTipoCliente obj32 )
      {
         obj32.gxTpr_Mode = Gx_mode;
         obj32.gxTpr_Tipoclientecreatedat = A195TipoClienteCreatedAt;
         obj32.gxTpr_Tipoclientedescricao = A193TipoClienteDescricao;
         obj32.gxTpr_Tipoclientetipopessoa = A194TipoClienteTipoPessoa;
         obj32.gxTpr_Tipoclienteportal = A207TipoClientePortal;
         obj32.gxTpr_Tipoclienteportalpjpf = A793TipoClientePortalPjPf;
         obj32.gxTpr_Tipoclientefinancia = A219TipoClienteFinancia;
         obj32.gxTpr_Tipoclienteupdateat = A196TipoClienteUpdateAt;
         obj32.gxTpr_Tipoclienteid = A192TipoClienteId;
         obj32.gxTpr_Tipoclienteid_Z = Z192TipoClienteId;
         obj32.gxTpr_Tipoclientedescricao_Z = Z193TipoClienteDescricao;
         obj32.gxTpr_Tipoclientetipopessoa_Z = Z194TipoClienteTipoPessoa;
         obj32.gxTpr_Tipoclienteportal_Z = Z207TipoClientePortal;
         obj32.gxTpr_Tipoclienteportalpjpf_Z = Z793TipoClientePortalPjPf;
         obj32.gxTpr_Tipoclientefinancia_Z = Z219TipoClienteFinancia;
         obj32.gxTpr_Tipoclientecreatedat_Z = Z195TipoClienteCreatedAt;
         obj32.gxTpr_Tipoclienteupdateat_Z = Z196TipoClienteUpdateAt;
         obj32.gxTpr_Tipoclienteid_N = (short)(Convert.ToInt16(n192TipoClienteId));
         obj32.gxTpr_Tipoclientedescricao_N = (short)(Convert.ToInt16(n193TipoClienteDescricao));
         obj32.gxTpr_Tipoclientetipopessoa_N = (short)(Convert.ToInt16(n194TipoClienteTipoPessoa));
         obj32.gxTpr_Tipoclienteportal_N = (short)(Convert.ToInt16(n207TipoClientePortal));
         obj32.gxTpr_Tipoclienteportalpjpf_N = (short)(Convert.ToInt16(n793TipoClientePortalPjPf));
         obj32.gxTpr_Tipoclientefinancia_N = (short)(Convert.ToInt16(n219TipoClienteFinancia));
         obj32.gxTpr_Tipoclientecreatedat_N = (short)(Convert.ToInt16(n195TipoClienteCreatedAt));
         obj32.gxTpr_Tipoclienteupdateat_N = (short)(Convert.ToInt16(n196TipoClienteUpdateAt));
         obj32.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow32( SdtTipoCliente obj32 )
      {
         obj32.gxTpr_Tipoclienteid = A192TipoClienteId;
         return  ;
      }

      public void RowToVars32( SdtTipoCliente obj32 ,
                               int forceLoad )
      {
         Gx_mode = obj32.gxTpr_Mode;
         A195TipoClienteCreatedAt = obj32.gxTpr_Tipoclientecreatedat;
         n195TipoClienteCreatedAt = false;
         A193TipoClienteDescricao = obj32.gxTpr_Tipoclientedescricao;
         n193TipoClienteDescricao = false;
         A194TipoClienteTipoPessoa = obj32.gxTpr_Tipoclientetipopessoa;
         n194TipoClienteTipoPessoa = false;
         A207TipoClientePortal = obj32.gxTpr_Tipoclienteportal;
         n207TipoClientePortal = false;
         A793TipoClientePortalPjPf = obj32.gxTpr_Tipoclienteportalpjpf;
         n793TipoClientePortalPjPf = false;
         A219TipoClienteFinancia = obj32.gxTpr_Tipoclientefinancia;
         n219TipoClienteFinancia = false;
         A196TipoClienteUpdateAt = obj32.gxTpr_Tipoclienteupdateat;
         n196TipoClienteUpdateAt = false;
         A192TipoClienteId = obj32.gxTpr_Tipoclienteid;
         n192TipoClienteId = false;
         Z192TipoClienteId = obj32.gxTpr_Tipoclienteid_Z;
         Z193TipoClienteDescricao = obj32.gxTpr_Tipoclientedescricao_Z;
         Z194TipoClienteTipoPessoa = obj32.gxTpr_Tipoclientetipopessoa_Z;
         Z207TipoClientePortal = obj32.gxTpr_Tipoclienteportal_Z;
         Z793TipoClientePortalPjPf = obj32.gxTpr_Tipoclienteportalpjpf_Z;
         Z219TipoClienteFinancia = obj32.gxTpr_Tipoclientefinancia_Z;
         Z195TipoClienteCreatedAt = obj32.gxTpr_Tipoclientecreatedat_Z;
         Z196TipoClienteUpdateAt = obj32.gxTpr_Tipoclienteupdateat_Z;
         n192TipoClienteId = (bool)(Convert.ToBoolean(obj32.gxTpr_Tipoclienteid_N));
         n193TipoClienteDescricao = (bool)(Convert.ToBoolean(obj32.gxTpr_Tipoclientedescricao_N));
         n194TipoClienteTipoPessoa = (bool)(Convert.ToBoolean(obj32.gxTpr_Tipoclientetipopessoa_N));
         n207TipoClientePortal = (bool)(Convert.ToBoolean(obj32.gxTpr_Tipoclienteportal_N));
         n793TipoClientePortalPjPf = (bool)(Convert.ToBoolean(obj32.gxTpr_Tipoclienteportalpjpf_N));
         n219TipoClienteFinancia = (bool)(Convert.ToBoolean(obj32.gxTpr_Tipoclientefinancia_N));
         n195TipoClienteCreatedAt = (bool)(Convert.ToBoolean(obj32.gxTpr_Tipoclientecreatedat_N));
         n196TipoClienteUpdateAt = (bool)(Convert.ToBoolean(obj32.gxTpr_Tipoclienteupdateat_N));
         Gx_mode = obj32.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A192TipoClienteId = (short)getParm(obj,0);
         n192TipoClienteId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0S32( ) ;
         ScanKeyStart0S32( ) ;
         if ( RcdFound32 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z192TipoClienteId = A192TipoClienteId;
         }
         ZM0S32( -5) ;
         OnLoadActions0S32( ) ;
         AddRow0S32( ) ;
         ScanKeyEnd0S32( ) ;
         if ( RcdFound32 == 0 )
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
         RowToVars32( bcTipoCliente, 0) ;
         ScanKeyStart0S32( ) ;
         if ( RcdFound32 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z192TipoClienteId = A192TipoClienteId;
         }
         ZM0S32( -5) ;
         OnLoadActions0S32( ) ;
         AddRow0S32( ) ;
         ScanKeyEnd0S32( ) ;
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0S32( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0S32( ) ;
         }
         else
         {
            if ( RcdFound32 == 1 )
            {
               if ( A192TipoClienteId != Z192TipoClienteId )
               {
                  A192TipoClienteId = Z192TipoClienteId;
                  n192TipoClienteId = false;
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
                  Update0S32( ) ;
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
                  if ( A192TipoClienteId != Z192TipoClienteId )
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
                        Insert0S32( ) ;
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
                        Insert0S32( ) ;
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
         RowToVars32( bcTipoCliente, 1) ;
         SaveImpl( ) ;
         VarsToRow32( bcTipoCliente) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars32( bcTipoCliente, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0S32( ) ;
         AfterTrn( ) ;
         VarsToRow32( bcTipoCliente) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow32( bcTipoCliente) ;
         }
         else
         {
            SdtTipoCliente auxBC = new SdtTipoCliente(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A192TipoClienteId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTipoCliente);
               auxBC.Save();
               bcTipoCliente.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars32( bcTipoCliente, 1) ;
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
         RowToVars32( bcTipoCliente, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0S32( ) ;
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
               VarsToRow32( bcTipoCliente) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow32( bcTipoCliente) ;
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
         RowToVars32( bcTipoCliente, 0) ;
         GetKey0S32( ) ;
         if ( RcdFound32 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A192TipoClienteId != Z192TipoClienteId )
            {
               A192TipoClienteId = Z192TipoClienteId;
               n192TipoClienteId = false;
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
            if ( A192TipoClienteId != Z192TipoClienteId )
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
         context.RollbackDataStores("tipocliente_bc",pr_default);
         VarsToRow32( bcTipoCliente) ;
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
         Gx_mode = bcTipoCliente.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTipoCliente.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTipoCliente )
         {
            bcTipoCliente = (SdtTipoCliente)(sdt);
            if ( StringUtil.StrCmp(bcTipoCliente.gxTpr_Mode, "") == 0 )
            {
               bcTipoCliente.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow32( bcTipoCliente) ;
            }
            else
            {
               RowToVars32( bcTipoCliente, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTipoCliente.gxTpr_Mode, "") == 0 )
            {
               bcTipoCliente.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars32( bcTipoCliente, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTipoCliente TipoCliente_BC
      {
         get {
            return bcTipoCliente ;
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
         AV12TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         Z195TipoClienteCreatedAt = (DateTime)(DateTime.MinValue);
         A195TipoClienteCreatedAt = (DateTime)(DateTime.MinValue);
         Z193TipoClienteDescricao = "";
         A193TipoClienteDescricao = "";
         Z194TipoClienteTipoPessoa = "";
         A194TipoClienteTipoPessoa = "";
         Z196TipoClienteUpdateAt = (DateTime)(DateTime.MinValue);
         A196TipoClienteUpdateAt = (DateTime)(DateTime.MinValue);
         BC000S4_A192TipoClienteId = new short[1] ;
         BC000S4_n192TipoClienteId = new bool[] {false} ;
         BC000S4_A195TipoClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000S4_n195TipoClienteCreatedAt = new bool[] {false} ;
         BC000S4_A193TipoClienteDescricao = new string[] {""} ;
         BC000S4_n193TipoClienteDescricao = new bool[] {false} ;
         BC000S4_A194TipoClienteTipoPessoa = new string[] {""} ;
         BC000S4_n194TipoClienteTipoPessoa = new bool[] {false} ;
         BC000S4_A207TipoClientePortal = new bool[] {false} ;
         BC000S4_n207TipoClientePortal = new bool[] {false} ;
         BC000S4_A793TipoClientePortalPjPf = new bool[] {false} ;
         BC000S4_n793TipoClientePortalPjPf = new bool[] {false} ;
         BC000S4_A219TipoClienteFinancia = new bool[] {false} ;
         BC000S4_n219TipoClienteFinancia = new bool[] {false} ;
         BC000S4_A196TipoClienteUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC000S4_n196TipoClienteUpdateAt = new bool[] {false} ;
         BC000S5_A192TipoClienteId = new short[1] ;
         BC000S5_n192TipoClienteId = new bool[] {false} ;
         BC000S3_A192TipoClienteId = new short[1] ;
         BC000S3_n192TipoClienteId = new bool[] {false} ;
         BC000S3_A195TipoClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000S3_n195TipoClienteCreatedAt = new bool[] {false} ;
         BC000S3_A193TipoClienteDescricao = new string[] {""} ;
         BC000S3_n193TipoClienteDescricao = new bool[] {false} ;
         BC000S3_A194TipoClienteTipoPessoa = new string[] {""} ;
         BC000S3_n194TipoClienteTipoPessoa = new bool[] {false} ;
         BC000S3_A207TipoClientePortal = new bool[] {false} ;
         BC000S3_n207TipoClientePortal = new bool[] {false} ;
         BC000S3_A793TipoClientePortalPjPf = new bool[] {false} ;
         BC000S3_n793TipoClientePortalPjPf = new bool[] {false} ;
         BC000S3_A219TipoClienteFinancia = new bool[] {false} ;
         BC000S3_n219TipoClienteFinancia = new bool[] {false} ;
         BC000S3_A196TipoClienteUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC000S3_n196TipoClienteUpdateAt = new bool[] {false} ;
         sMode32 = "";
         BC000S2_A192TipoClienteId = new short[1] ;
         BC000S2_n192TipoClienteId = new bool[] {false} ;
         BC000S2_A195TipoClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000S2_n195TipoClienteCreatedAt = new bool[] {false} ;
         BC000S2_A193TipoClienteDescricao = new string[] {""} ;
         BC000S2_n193TipoClienteDescricao = new bool[] {false} ;
         BC000S2_A194TipoClienteTipoPessoa = new string[] {""} ;
         BC000S2_n194TipoClienteTipoPessoa = new bool[] {false} ;
         BC000S2_A207TipoClientePortal = new bool[] {false} ;
         BC000S2_n207TipoClientePortal = new bool[] {false} ;
         BC000S2_A793TipoClientePortalPjPf = new bool[] {false} ;
         BC000S2_n793TipoClientePortalPjPf = new bool[] {false} ;
         BC000S2_A219TipoClienteFinancia = new bool[] {false} ;
         BC000S2_n219TipoClienteFinancia = new bool[] {false} ;
         BC000S2_A196TipoClienteUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC000S2_n196TipoClienteUpdateAt = new bool[] {false} ;
         BC000S7_A192TipoClienteId = new short[1] ;
         BC000S7_n192TipoClienteId = new bool[] {false} ;
         BC000S10_A168ClienteId = new int[1] ;
         BC000S11_A192TipoClienteId = new short[1] ;
         BC000S11_n192TipoClienteId = new bool[] {false} ;
         BC000S11_A195TipoClienteCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000S11_n195TipoClienteCreatedAt = new bool[] {false} ;
         BC000S11_A193TipoClienteDescricao = new string[] {""} ;
         BC000S11_n193TipoClienteDescricao = new bool[] {false} ;
         BC000S11_A194TipoClienteTipoPessoa = new string[] {""} ;
         BC000S11_n194TipoClienteTipoPessoa = new bool[] {false} ;
         BC000S11_A207TipoClientePortal = new bool[] {false} ;
         BC000S11_n207TipoClientePortal = new bool[] {false} ;
         BC000S11_A793TipoClientePortalPjPf = new bool[] {false} ;
         BC000S11_n793TipoClientePortalPjPf = new bool[] {false} ;
         BC000S11_A219TipoClienteFinancia = new bool[] {false} ;
         BC000S11_n219TipoClienteFinancia = new bool[] {false} ;
         BC000S11_A196TipoClienteUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC000S11_n196TipoClienteUpdateAt = new bool[] {false} ;
         i195TipoClienteCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tipocliente_bc__default(),
            new Object[][] {
                new Object[] {
               BC000S2_A192TipoClienteId, BC000S2_A195TipoClienteCreatedAt, BC000S2_n195TipoClienteCreatedAt, BC000S2_A193TipoClienteDescricao, BC000S2_n193TipoClienteDescricao, BC000S2_A194TipoClienteTipoPessoa, BC000S2_n194TipoClienteTipoPessoa, BC000S2_A207TipoClientePortal, BC000S2_n207TipoClientePortal, BC000S2_A793TipoClientePortalPjPf,
               BC000S2_n793TipoClientePortalPjPf, BC000S2_A219TipoClienteFinancia, BC000S2_n219TipoClienteFinancia, BC000S2_A196TipoClienteUpdateAt, BC000S2_n196TipoClienteUpdateAt
               }
               , new Object[] {
               BC000S3_A192TipoClienteId, BC000S3_A195TipoClienteCreatedAt, BC000S3_n195TipoClienteCreatedAt, BC000S3_A193TipoClienteDescricao, BC000S3_n193TipoClienteDescricao, BC000S3_A194TipoClienteTipoPessoa, BC000S3_n194TipoClienteTipoPessoa, BC000S3_A207TipoClientePortal, BC000S3_n207TipoClientePortal, BC000S3_A793TipoClientePortalPjPf,
               BC000S3_n793TipoClientePortalPjPf, BC000S3_A219TipoClienteFinancia, BC000S3_n219TipoClienteFinancia, BC000S3_A196TipoClienteUpdateAt, BC000S3_n196TipoClienteUpdateAt
               }
               , new Object[] {
               BC000S4_A192TipoClienteId, BC000S4_A195TipoClienteCreatedAt, BC000S4_n195TipoClienteCreatedAt, BC000S4_A193TipoClienteDescricao, BC000S4_n193TipoClienteDescricao, BC000S4_A194TipoClienteTipoPessoa, BC000S4_n194TipoClienteTipoPessoa, BC000S4_A207TipoClientePortal, BC000S4_n207TipoClientePortal, BC000S4_A793TipoClientePortalPjPf,
               BC000S4_n793TipoClientePortalPjPf, BC000S4_A219TipoClienteFinancia, BC000S4_n219TipoClienteFinancia, BC000S4_A196TipoClienteUpdateAt, BC000S4_n196TipoClienteUpdateAt
               }
               , new Object[] {
               BC000S5_A192TipoClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000S7_A192TipoClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000S10_A168ClienteId
               }
               , new Object[] {
               BC000S11_A192TipoClienteId, BC000S11_A195TipoClienteCreatedAt, BC000S11_n195TipoClienteCreatedAt, BC000S11_A193TipoClienteDescricao, BC000S11_n193TipoClienteDescricao, BC000S11_A194TipoClienteTipoPessoa, BC000S11_n194TipoClienteTipoPessoa, BC000S11_A207TipoClientePortal, BC000S11_n207TipoClientePortal, BC000S11_A793TipoClientePortalPjPf,
               BC000S11_n793TipoClientePortalPjPf, BC000S11_A219TipoClienteFinancia, BC000S11_n219TipoClienteFinancia, BC000S11_A196TipoClienteUpdateAt, BC000S11_n196TipoClienteUpdateAt
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120S2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z192TipoClienteId ;
      private short A192TipoClienteId ;
      private short RcdFound32 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode32 ;
      private DateTime Z195TipoClienteCreatedAt ;
      private DateTime A195TipoClienteCreatedAt ;
      private DateTime Z196TipoClienteUpdateAt ;
      private DateTime A196TipoClienteUpdateAt ;
      private DateTime i195TipoClienteCreatedAt ;
      private bool returnInSub ;
      private bool Z207TipoClientePortal ;
      private bool A207TipoClientePortal ;
      private bool Z793TipoClientePortalPjPf ;
      private bool A793TipoClientePortalPjPf ;
      private bool Z219TipoClienteFinancia ;
      private bool A219TipoClienteFinancia ;
      private bool n195TipoClienteCreatedAt ;
      private bool n192TipoClienteId ;
      private bool n193TipoClienteDescricao ;
      private bool n194TipoClienteTipoPessoa ;
      private bool n207TipoClientePortal ;
      private bool n793TipoClientePortalPjPf ;
      private bool n219TipoClienteFinancia ;
      private bool n196TipoClienteUpdateAt ;
      private bool Gx_longc ;
      private string Z193TipoClienteDescricao ;
      private string A193TipoClienteDescricao ;
      private string Z194TipoClienteTipoPessoa ;
      private string A194TipoClienteTipoPessoa ;
      private IGxSession AV13WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV12TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] BC000S4_A192TipoClienteId ;
      private bool[] BC000S4_n192TipoClienteId ;
      private DateTime[] BC000S4_A195TipoClienteCreatedAt ;
      private bool[] BC000S4_n195TipoClienteCreatedAt ;
      private string[] BC000S4_A193TipoClienteDescricao ;
      private bool[] BC000S4_n193TipoClienteDescricao ;
      private string[] BC000S4_A194TipoClienteTipoPessoa ;
      private bool[] BC000S4_n194TipoClienteTipoPessoa ;
      private bool[] BC000S4_A207TipoClientePortal ;
      private bool[] BC000S4_n207TipoClientePortal ;
      private bool[] BC000S4_A793TipoClientePortalPjPf ;
      private bool[] BC000S4_n793TipoClientePortalPjPf ;
      private bool[] BC000S4_A219TipoClienteFinancia ;
      private bool[] BC000S4_n219TipoClienteFinancia ;
      private DateTime[] BC000S4_A196TipoClienteUpdateAt ;
      private bool[] BC000S4_n196TipoClienteUpdateAt ;
      private short[] BC000S5_A192TipoClienteId ;
      private bool[] BC000S5_n192TipoClienteId ;
      private short[] BC000S3_A192TipoClienteId ;
      private bool[] BC000S3_n192TipoClienteId ;
      private DateTime[] BC000S3_A195TipoClienteCreatedAt ;
      private bool[] BC000S3_n195TipoClienteCreatedAt ;
      private string[] BC000S3_A193TipoClienteDescricao ;
      private bool[] BC000S3_n193TipoClienteDescricao ;
      private string[] BC000S3_A194TipoClienteTipoPessoa ;
      private bool[] BC000S3_n194TipoClienteTipoPessoa ;
      private bool[] BC000S3_A207TipoClientePortal ;
      private bool[] BC000S3_n207TipoClientePortal ;
      private bool[] BC000S3_A793TipoClientePortalPjPf ;
      private bool[] BC000S3_n793TipoClientePortalPjPf ;
      private bool[] BC000S3_A219TipoClienteFinancia ;
      private bool[] BC000S3_n219TipoClienteFinancia ;
      private DateTime[] BC000S3_A196TipoClienteUpdateAt ;
      private bool[] BC000S3_n196TipoClienteUpdateAt ;
      private short[] BC000S2_A192TipoClienteId ;
      private bool[] BC000S2_n192TipoClienteId ;
      private DateTime[] BC000S2_A195TipoClienteCreatedAt ;
      private bool[] BC000S2_n195TipoClienteCreatedAt ;
      private string[] BC000S2_A193TipoClienteDescricao ;
      private bool[] BC000S2_n193TipoClienteDescricao ;
      private string[] BC000S2_A194TipoClienteTipoPessoa ;
      private bool[] BC000S2_n194TipoClienteTipoPessoa ;
      private bool[] BC000S2_A207TipoClientePortal ;
      private bool[] BC000S2_n207TipoClientePortal ;
      private bool[] BC000S2_A793TipoClientePortalPjPf ;
      private bool[] BC000S2_n793TipoClientePortalPjPf ;
      private bool[] BC000S2_A219TipoClienteFinancia ;
      private bool[] BC000S2_n219TipoClienteFinancia ;
      private DateTime[] BC000S2_A196TipoClienteUpdateAt ;
      private bool[] BC000S2_n196TipoClienteUpdateAt ;
      private short[] BC000S7_A192TipoClienteId ;
      private bool[] BC000S7_n192TipoClienteId ;
      private int[] BC000S10_A168ClienteId ;
      private short[] BC000S11_A192TipoClienteId ;
      private bool[] BC000S11_n192TipoClienteId ;
      private DateTime[] BC000S11_A195TipoClienteCreatedAt ;
      private bool[] BC000S11_n195TipoClienteCreatedAt ;
      private string[] BC000S11_A193TipoClienteDescricao ;
      private bool[] BC000S11_n193TipoClienteDescricao ;
      private string[] BC000S11_A194TipoClienteTipoPessoa ;
      private bool[] BC000S11_n194TipoClienteTipoPessoa ;
      private bool[] BC000S11_A207TipoClientePortal ;
      private bool[] BC000S11_n207TipoClientePortal ;
      private bool[] BC000S11_A793TipoClientePortalPjPf ;
      private bool[] BC000S11_n793TipoClientePortalPjPf ;
      private bool[] BC000S11_A219TipoClienteFinancia ;
      private bool[] BC000S11_n219TipoClienteFinancia ;
      private DateTime[] BC000S11_A196TipoClienteUpdateAt ;
      private bool[] BC000S11_n196TipoClienteUpdateAt ;
      private SdtTipoCliente bcTipoCliente ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class tipocliente_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new UpdateCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000S2;
          prmBC000S2 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000S3;
          prmBC000S3 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000S4;
          prmBC000S4 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000S5;
          prmBC000S5 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000S6;
          prmBC000S6 = new Object[] {
          new ParDef("TipoClienteCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("TipoClienteDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TipoClienteTipoPessoa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TipoClientePortal",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TipoClientePortalPjPf",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TipoClienteFinancia",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TipoClienteUpdateAt",GXType.DateTime,8,5){Nullable=true}
          };
          Object[] prmBC000S7;
          prmBC000S7 = new Object[] {
          };
          Object[] prmBC000S8;
          prmBC000S8 = new Object[] {
          new ParDef("TipoClienteCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("TipoClienteDescricao",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("TipoClienteTipoPessoa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TipoClientePortal",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TipoClientePortalPjPf",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TipoClienteFinancia",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TipoClienteUpdateAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000S9;
          prmBC000S9 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000S10;
          prmBC000S10 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000S11;
          prmBC000S11 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC000S2", "SELECT TipoClienteId, TipoClienteCreatedAt, TipoClienteDescricao, TipoClienteTipoPessoa, TipoClientePortal, TipoClientePortalPjPf, TipoClienteFinancia, TipoClienteUpdateAt FROM TipoCliente WHERE TipoClienteId = :TipoClienteId  FOR UPDATE OF TipoCliente",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000S3", "SELECT TipoClienteId, TipoClienteCreatedAt, TipoClienteDescricao, TipoClienteTipoPessoa, TipoClientePortal, TipoClientePortalPjPf, TipoClienteFinancia, TipoClienteUpdateAt FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000S4", "SELECT TM1.TipoClienteId, TM1.TipoClienteCreatedAt, TM1.TipoClienteDescricao, TM1.TipoClienteTipoPessoa, TM1.TipoClientePortal, TM1.TipoClientePortalPjPf, TM1.TipoClienteFinancia, TM1.TipoClienteUpdateAt FROM TipoCliente TM1 WHERE TM1.TipoClienteId = :TipoClienteId ORDER BY TM1.TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000S5", "SELECT TipoClienteId FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000S6", "SAVEPOINT gxupdate;INSERT INTO TipoCliente(TipoClienteCreatedAt, TipoClienteDescricao, TipoClienteTipoPessoa, TipoClientePortal, TipoClientePortalPjPf, TipoClienteFinancia, TipoClienteUpdateAt) VALUES(:TipoClienteCreatedAt, :TipoClienteDescricao, :TipoClienteTipoPessoa, :TipoClientePortal, :TipoClientePortalPjPf, :TipoClienteFinancia, :TipoClienteUpdateAt);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000S6)
             ,new CursorDef("BC000S7", "SELECT currval('TipoClienteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000S8", "SAVEPOINT gxupdate;UPDATE TipoCliente SET TipoClienteCreatedAt=:TipoClienteCreatedAt, TipoClienteDescricao=:TipoClienteDescricao, TipoClienteTipoPessoa=:TipoClienteTipoPessoa, TipoClientePortal=:TipoClientePortal, TipoClientePortalPjPf=:TipoClientePortalPjPf, TipoClienteFinancia=:TipoClienteFinancia, TipoClienteUpdateAt=:TipoClienteUpdateAt  WHERE TipoClienteId = :TipoClienteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000S8)
             ,new CursorDef("BC000S9", "SAVEPOINT gxupdate;DELETE FROM TipoCliente  WHERE TipoClienteId = :TipoClienteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000S9)
             ,new CursorDef("BC000S10", "SELECT ClienteId FROM Cliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000S11", "SELECT TM1.TipoClienteId, TM1.TipoClienteCreatedAt, TM1.TipoClienteDescricao, TM1.TipoClienteTipoPessoa, TM1.TipoClientePortal, TM1.TipoClientePortalPjPf, TM1.TipoClienteFinancia, TM1.TipoClienteUpdateAt FROM TipoCliente TM1 WHERE TM1.TipoClienteId = :TipoClienteId ORDER BY TM1.TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S11,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
