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
   public class layoutcontrato_bc : GxSilentTrn, IGxSilentTrn
   {
      public layoutcontrato_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public layoutcontrato_bc( IGxContext context )
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
         ReadRow0L25( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0L25( ) ;
         standaloneModal( ) ;
         AddRow0L25( ) ;
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
            E110L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z154LayoutContratoId = A154LayoutContratoId;
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

      protected void CONFIRM_0L0( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0L25( ) ;
            }
            else
            {
               CheckExtendedTable0L25( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0L25( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120L2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void ZM0L25( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z155LayoutContratoDescricao = A155LayoutContratoDescricao;
            Z156LayoutContratoStatus = A156LayoutContratoStatus;
            Z906LayoutContratoTipo = A906LayoutContratoTipo;
            Z1000LayoutContratoTag = A1000LayoutContratoTag;
         }
         if ( GX_JID == -7 )
         {
            Z154LayoutContratoId = A154LayoutContratoId;
            Z155LayoutContratoDescricao = A155LayoutContratoDescricao;
            Z156LayoutContratoStatus = A156LayoutContratoStatus;
            Z157LayoutContratoCorpo = A157LayoutContratoCorpo;
            Z906LayoutContratoTipo = A906LayoutContratoTipo;
            Z1000LayoutContratoTag = A1000LayoutContratoTag;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A156LayoutContratoStatus) && ( Gx_BScreen == 0 ) )
         {
            A156LayoutContratoStatus = true;
            n156LayoutContratoStatus = false;
         }
      }

      protected void Load0L25( )
      {
         /* Using cursor BC000L4 */
         pr_default.execute(2, new Object[] {A154LayoutContratoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound25 = 1;
            A155LayoutContratoDescricao = BC000L4_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = BC000L4_n155LayoutContratoDescricao[0];
            A156LayoutContratoStatus = BC000L4_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = BC000L4_n156LayoutContratoStatus[0];
            A157LayoutContratoCorpo = BC000L4_A157LayoutContratoCorpo[0];
            n157LayoutContratoCorpo = BC000L4_n157LayoutContratoCorpo[0];
            A906LayoutContratoTipo = BC000L4_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = BC000L4_n906LayoutContratoTipo[0];
            A1000LayoutContratoTag = BC000L4_A1000LayoutContratoTag[0];
            n1000LayoutContratoTag = BC000L4_n1000LayoutContratoTag[0];
            ZM0L25( -7) ;
         }
         pr_default.close(2);
         OnLoadActions0L25( ) ;
      }

      protected void OnLoadActions0L25( )
      {
         if ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") != 0 )
         {
            A1000LayoutContratoTag = "";
            n1000LayoutContratoTag = false;
            n1000LayoutContratoTag = false;
         }
      }

      protected void CheckExtendedTable0L25( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A155LayoutContratoDescricao)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A906LayoutContratoTipo, "C") == 0 ) || ( StringUtil.StrCmp(A906LayoutContratoTipo, "M") == 0 ) || ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A906LayoutContratoTipo)) ) )
         {
            GX_msglist.addItem("Campo Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") != 0 )
         {
            A1000LayoutContratoTag = "";
            n1000LayoutContratoTag = false;
            n1000LayoutContratoTag = false;
         }
         if ( ( ( StringUtil.StrCmp(A906LayoutContratoTipo, "A") == 0 ) ) && String.IsNullOrEmpty(StringUtil.RTrim( A1000LayoutContratoTag)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Layout Contrato Tag", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0L25( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0L25( )
      {
         /* Using cursor BC000L5 */
         pr_default.execute(3, new Object[] {A154LayoutContratoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000L3 */
         pr_default.execute(1, new Object[] {A154LayoutContratoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L25( 7) ;
            RcdFound25 = 1;
            A154LayoutContratoId = BC000L3_A154LayoutContratoId[0];
            A155LayoutContratoDescricao = BC000L3_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = BC000L3_n155LayoutContratoDescricao[0];
            A156LayoutContratoStatus = BC000L3_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = BC000L3_n156LayoutContratoStatus[0];
            A157LayoutContratoCorpo = BC000L3_A157LayoutContratoCorpo[0];
            n157LayoutContratoCorpo = BC000L3_n157LayoutContratoCorpo[0];
            A906LayoutContratoTipo = BC000L3_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = BC000L3_n906LayoutContratoTipo[0];
            A1000LayoutContratoTag = BC000L3_A1000LayoutContratoTag[0];
            n1000LayoutContratoTag = BC000L3_n1000LayoutContratoTag[0];
            Z154LayoutContratoId = A154LayoutContratoId;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0L25( ) ;
            if ( AnyError == 1 )
            {
               RcdFound25 = 0;
               InitializeNonKey0L25( ) ;
            }
            Gx_mode = sMode25;
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0L25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode25;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L25( ) ;
         if ( RcdFound25 == 0 )
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
         CONFIRM_0L0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0L25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000L2 */
            pr_default.execute(0, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LayoutContrato"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z155LayoutContratoDescricao, BC000L2_A155LayoutContratoDescricao[0]) != 0 ) || ( Z156LayoutContratoStatus != BC000L2_A156LayoutContratoStatus[0] ) || ( StringUtil.StrCmp(Z906LayoutContratoTipo, BC000L2_A906LayoutContratoTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z1000LayoutContratoTag, BC000L2_A1000LayoutContratoTag[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LayoutContrato"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L25( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L25( 0) ;
            CheckOptimisticConcurrency0L25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000L6 */
                     pr_default.execute(4, new Object[] {n155LayoutContratoDescricao, A155LayoutContratoDescricao, n156LayoutContratoStatus, A156LayoutContratoStatus, n157LayoutContratoCorpo, A157LayoutContratoCorpo, n906LayoutContratoTipo, A906LayoutContratoTipo, n1000LayoutContratoTag, A1000LayoutContratoTag});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000L7 */
                     pr_default.execute(5);
                     A154LayoutContratoId = BC000L7_A154LayoutContratoId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("LayoutContrato");
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
               Load0L25( ) ;
            }
            EndLevel0L25( ) ;
         }
         CloseExtendedTableCursors0L25( ) ;
      }

      protected void Update0L25( )
      {
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000L8 */
                     pr_default.execute(6, new Object[] {n155LayoutContratoDescricao, A155LayoutContratoDescricao, n156LayoutContratoStatus, A156LayoutContratoStatus, n157LayoutContratoCorpo, A157LayoutContratoCorpo, n906LayoutContratoTipo, A906LayoutContratoTipo, n1000LayoutContratoTag, A1000LayoutContratoTag, A154LayoutContratoId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("LayoutContrato");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LayoutContrato"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L25( ) ;
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
            EndLevel0L25( ) ;
         }
         CloseExtendedTableCursors0L25( ) ;
      }

      protected void DeferredUpdate0L25( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0L25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L25( ) ;
            AfterConfirm0L25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000L9 */
                  pr_default.execute(7, new Object[] {A154LayoutContratoId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("LayoutContrato");
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
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0L25( ) ;
         Gx_mode = sMode25;
      }

      protected void OnDeleteControls0L25( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000L10 */
            pr_default.execute(8, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotificacaoAgendada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000L11 */
            pr_default.execute(9, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuracoes"+" ("+"Sb Config Layout Contrato Compra Titulo"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000L12 */
            pr_default.execute(10, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuracoes"+" ("+"Sb Layout Promissoria Paciente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000L13 */
            pr_default.execute(11, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuracoes"+" ("+"Sb Layout Promissoria Clinica Taxa"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000L14 */
            pr_default.execute(12, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuracoes"+" ("+"Sb Layout Promissoria Clinica Emprestimo"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000L15 */
            pr_default.execute(13, new Object[] {A154LayoutContratoId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuracoes"+" ("+"Sb Layout Proposta Config"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0L25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L25( ) ;
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

      public void ScanKeyStart0L25( )
      {
         /* Scan By routine */
         /* Using cursor BC000L16 */
         pr_default.execute(14, new Object[] {A154LayoutContratoId});
         RcdFound25 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound25 = 1;
            A154LayoutContratoId = BC000L16_A154LayoutContratoId[0];
            A155LayoutContratoDescricao = BC000L16_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = BC000L16_n155LayoutContratoDescricao[0];
            A156LayoutContratoStatus = BC000L16_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = BC000L16_n156LayoutContratoStatus[0];
            A157LayoutContratoCorpo = BC000L16_A157LayoutContratoCorpo[0];
            n157LayoutContratoCorpo = BC000L16_n157LayoutContratoCorpo[0];
            A906LayoutContratoTipo = BC000L16_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = BC000L16_n906LayoutContratoTipo[0];
            A1000LayoutContratoTag = BC000L16_A1000LayoutContratoTag[0];
            n1000LayoutContratoTag = BC000L16_n1000LayoutContratoTag[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0L25( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound25 = 0;
         ScanKeyLoad0L25( ) ;
      }

      protected void ScanKeyLoad0L25( )
      {
         sMode25 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound25 = 1;
            A154LayoutContratoId = BC000L16_A154LayoutContratoId[0];
            A155LayoutContratoDescricao = BC000L16_A155LayoutContratoDescricao[0];
            n155LayoutContratoDescricao = BC000L16_n155LayoutContratoDescricao[0];
            A156LayoutContratoStatus = BC000L16_A156LayoutContratoStatus[0];
            n156LayoutContratoStatus = BC000L16_n156LayoutContratoStatus[0];
            A157LayoutContratoCorpo = BC000L16_A157LayoutContratoCorpo[0];
            n157LayoutContratoCorpo = BC000L16_n157LayoutContratoCorpo[0];
            A906LayoutContratoTipo = BC000L16_A906LayoutContratoTipo[0];
            n906LayoutContratoTipo = BC000L16_n906LayoutContratoTipo[0];
            A1000LayoutContratoTag = BC000L16_A1000LayoutContratoTag[0];
            n1000LayoutContratoTag = BC000L16_n1000LayoutContratoTag[0];
         }
         Gx_mode = sMode25;
      }

      protected void ScanKeyEnd0L25( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0L25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L25( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0L25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0L25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0L25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L25( )
      {
      }

      protected void send_integrity_lvl_hashes0L25( )
      {
      }

      protected void AddRow0L25( )
      {
         VarsToRow25( bcLayoutContrato) ;
      }

      protected void ReadRow0L25( )
      {
         RowToVars25( bcLayoutContrato, 1) ;
      }

      protected void InitializeNonKey0L25( )
      {
         A155LayoutContratoDescricao = "";
         n155LayoutContratoDescricao = false;
         A157LayoutContratoCorpo = "";
         n157LayoutContratoCorpo = false;
         A906LayoutContratoTipo = "";
         n906LayoutContratoTipo = false;
         A1000LayoutContratoTag = "";
         n1000LayoutContratoTag = false;
         A156LayoutContratoStatus = true;
         n156LayoutContratoStatus = false;
         Z155LayoutContratoDescricao = "";
         Z156LayoutContratoStatus = false;
         Z906LayoutContratoTipo = "";
         Z1000LayoutContratoTag = "";
      }

      protected void InitAll0L25( )
      {
         A154LayoutContratoId = 0;
         InitializeNonKey0L25( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A156LayoutContratoStatus = i156LayoutContratoStatus;
         n156LayoutContratoStatus = false;
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

      public void VarsToRow25( SdtLayoutContrato obj25 )
      {
         obj25.gxTpr_Mode = Gx_mode;
         obj25.gxTpr_Layoutcontratodescricao = A155LayoutContratoDescricao;
         obj25.gxTpr_Layoutcontratocorpo = A157LayoutContratoCorpo;
         obj25.gxTpr_Layoutcontratotipo = A906LayoutContratoTipo;
         obj25.gxTpr_Layoutcontratotag = A1000LayoutContratoTag;
         obj25.gxTpr_Layoutcontratostatus = A156LayoutContratoStatus;
         obj25.gxTpr_Layoutcontratoid = A154LayoutContratoId;
         obj25.gxTpr_Layoutcontratoid_Z = Z154LayoutContratoId;
         obj25.gxTpr_Layoutcontratodescricao_Z = Z155LayoutContratoDescricao;
         obj25.gxTpr_Layoutcontratostatus_Z = Z156LayoutContratoStatus;
         obj25.gxTpr_Layoutcontratotipo_Z = Z906LayoutContratoTipo;
         obj25.gxTpr_Layoutcontratotag_Z = Z1000LayoutContratoTag;
         obj25.gxTpr_Layoutcontratodescricao_N = (short)(Convert.ToInt16(n155LayoutContratoDescricao));
         obj25.gxTpr_Layoutcontratostatus_N = (short)(Convert.ToInt16(n156LayoutContratoStatus));
         obj25.gxTpr_Layoutcontratocorpo_N = (short)(Convert.ToInt16(n157LayoutContratoCorpo));
         obj25.gxTpr_Layoutcontratotipo_N = (short)(Convert.ToInt16(n906LayoutContratoTipo));
         obj25.gxTpr_Layoutcontratotag_N = (short)(Convert.ToInt16(n1000LayoutContratoTag));
         obj25.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow25( SdtLayoutContrato obj25 )
      {
         obj25.gxTpr_Layoutcontratoid = A154LayoutContratoId;
         return  ;
      }

      public void RowToVars25( SdtLayoutContrato obj25 ,
                               int forceLoad )
      {
         Gx_mode = obj25.gxTpr_Mode;
         A155LayoutContratoDescricao = obj25.gxTpr_Layoutcontratodescricao;
         n155LayoutContratoDescricao = false;
         A157LayoutContratoCorpo = obj25.gxTpr_Layoutcontratocorpo;
         n157LayoutContratoCorpo = false;
         A906LayoutContratoTipo = obj25.gxTpr_Layoutcontratotipo;
         n906LayoutContratoTipo = false;
         A1000LayoutContratoTag = obj25.gxTpr_Layoutcontratotag;
         n1000LayoutContratoTag = false;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A156LayoutContratoStatus = obj25.gxTpr_Layoutcontratostatus;
            n156LayoutContratoStatus = false;
         }
         A154LayoutContratoId = obj25.gxTpr_Layoutcontratoid;
         Z154LayoutContratoId = obj25.gxTpr_Layoutcontratoid_Z;
         Z155LayoutContratoDescricao = obj25.gxTpr_Layoutcontratodescricao_Z;
         Z156LayoutContratoStatus = obj25.gxTpr_Layoutcontratostatus_Z;
         Z906LayoutContratoTipo = obj25.gxTpr_Layoutcontratotipo_Z;
         Z1000LayoutContratoTag = obj25.gxTpr_Layoutcontratotag_Z;
         n155LayoutContratoDescricao = (bool)(Convert.ToBoolean(obj25.gxTpr_Layoutcontratodescricao_N));
         n156LayoutContratoStatus = (bool)(Convert.ToBoolean(obj25.gxTpr_Layoutcontratostatus_N));
         n157LayoutContratoCorpo = (bool)(Convert.ToBoolean(obj25.gxTpr_Layoutcontratocorpo_N));
         n906LayoutContratoTipo = (bool)(Convert.ToBoolean(obj25.gxTpr_Layoutcontratotipo_N));
         n1000LayoutContratoTag = (bool)(Convert.ToBoolean(obj25.gxTpr_Layoutcontratotag_N));
         Gx_mode = obj25.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A154LayoutContratoId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0L25( ) ;
         ScanKeyStart0L25( ) ;
         if ( RcdFound25 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z154LayoutContratoId = A154LayoutContratoId;
         }
         ZM0L25( -7) ;
         OnLoadActions0L25( ) ;
         AddRow0L25( ) ;
         ScanKeyEnd0L25( ) ;
         if ( RcdFound25 == 0 )
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
         RowToVars25( bcLayoutContrato, 0) ;
         ScanKeyStart0L25( ) ;
         if ( RcdFound25 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z154LayoutContratoId = A154LayoutContratoId;
         }
         ZM0L25( -7) ;
         OnLoadActions0L25( ) ;
         AddRow0L25( ) ;
         ScanKeyEnd0L25( ) ;
         if ( RcdFound25 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0L25( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0L25( ) ;
         }
         else
         {
            if ( RcdFound25 == 1 )
            {
               if ( A154LayoutContratoId != Z154LayoutContratoId )
               {
                  A154LayoutContratoId = Z154LayoutContratoId;
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
                  Update0L25( ) ;
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
                  if ( A154LayoutContratoId != Z154LayoutContratoId )
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
                        Insert0L25( ) ;
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
                        Insert0L25( ) ;
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
         RowToVars25( bcLayoutContrato, 1) ;
         SaveImpl( ) ;
         VarsToRow25( bcLayoutContrato) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars25( bcLayoutContrato, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0L25( ) ;
         AfterTrn( ) ;
         VarsToRow25( bcLayoutContrato) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow25( bcLayoutContrato) ;
         }
         else
         {
            SdtLayoutContrato auxBC = new SdtLayoutContrato(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A154LayoutContratoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcLayoutContrato);
               auxBC.Save();
               bcLayoutContrato.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars25( bcLayoutContrato, 1) ;
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
         RowToVars25( bcLayoutContrato, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0L25( ) ;
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
               VarsToRow25( bcLayoutContrato) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow25( bcLayoutContrato) ;
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
         RowToVars25( bcLayoutContrato, 0) ;
         GetKey0L25( ) ;
         if ( RcdFound25 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A154LayoutContratoId != Z154LayoutContratoId )
            {
               A154LayoutContratoId = Z154LayoutContratoId;
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
            if ( A154LayoutContratoId != Z154LayoutContratoId )
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
         context.RollbackDataStores("layoutcontrato_bc",pr_default);
         VarsToRow25( bcLayoutContrato) ;
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
         Gx_mode = bcLayoutContrato.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcLayoutContrato.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcLayoutContrato )
         {
            bcLayoutContrato = (SdtLayoutContrato)(sdt);
            if ( StringUtil.StrCmp(bcLayoutContrato.gxTpr_Mode, "") == 0 )
            {
               bcLayoutContrato.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow25( bcLayoutContrato) ;
            }
            else
            {
               RowToVars25( bcLayoutContrato, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcLayoutContrato.gxTpr_Mode, "") == 0 )
            {
               bcLayoutContrato.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars25( bcLayoutContrato, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtLayoutContrato LayoutContrato_BC
      {
         get {
            return bcLayoutContrato ;
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
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z155LayoutContratoDescricao = "";
         A155LayoutContratoDescricao = "";
         Z906LayoutContratoTipo = "";
         A906LayoutContratoTipo = "";
         Z1000LayoutContratoTag = "";
         A1000LayoutContratoTag = "";
         Z157LayoutContratoCorpo = "";
         A157LayoutContratoCorpo = "";
         BC000L4_A154LayoutContratoId = new short[1] ;
         BC000L4_A155LayoutContratoDescricao = new string[] {""} ;
         BC000L4_n155LayoutContratoDescricao = new bool[] {false} ;
         BC000L4_A156LayoutContratoStatus = new bool[] {false} ;
         BC000L4_n156LayoutContratoStatus = new bool[] {false} ;
         BC000L4_A157LayoutContratoCorpo = new string[] {""} ;
         BC000L4_n157LayoutContratoCorpo = new bool[] {false} ;
         BC000L4_A906LayoutContratoTipo = new string[] {""} ;
         BC000L4_n906LayoutContratoTipo = new bool[] {false} ;
         BC000L4_A1000LayoutContratoTag = new string[] {""} ;
         BC000L4_n1000LayoutContratoTag = new bool[] {false} ;
         BC000L5_A154LayoutContratoId = new short[1] ;
         BC000L3_A154LayoutContratoId = new short[1] ;
         BC000L3_A155LayoutContratoDescricao = new string[] {""} ;
         BC000L3_n155LayoutContratoDescricao = new bool[] {false} ;
         BC000L3_A156LayoutContratoStatus = new bool[] {false} ;
         BC000L3_n156LayoutContratoStatus = new bool[] {false} ;
         BC000L3_A157LayoutContratoCorpo = new string[] {""} ;
         BC000L3_n157LayoutContratoCorpo = new bool[] {false} ;
         BC000L3_A906LayoutContratoTipo = new string[] {""} ;
         BC000L3_n906LayoutContratoTipo = new bool[] {false} ;
         BC000L3_A1000LayoutContratoTag = new string[] {""} ;
         BC000L3_n1000LayoutContratoTag = new bool[] {false} ;
         sMode25 = "";
         BC000L2_A154LayoutContratoId = new short[1] ;
         BC000L2_A155LayoutContratoDescricao = new string[] {""} ;
         BC000L2_n155LayoutContratoDescricao = new bool[] {false} ;
         BC000L2_A156LayoutContratoStatus = new bool[] {false} ;
         BC000L2_n156LayoutContratoStatus = new bool[] {false} ;
         BC000L2_A157LayoutContratoCorpo = new string[] {""} ;
         BC000L2_n157LayoutContratoCorpo = new bool[] {false} ;
         BC000L2_A906LayoutContratoTipo = new string[] {""} ;
         BC000L2_n906LayoutContratoTipo = new bool[] {false} ;
         BC000L2_A1000LayoutContratoTag = new string[] {""} ;
         BC000L2_n1000LayoutContratoTag = new bool[] {false} ;
         BC000L7_A154LayoutContratoId = new short[1] ;
         BC000L10_A898NotificacaoAgendadaId = new int[1] ;
         BC000L11_A299ConfiguracoesId = new int[1] ;
         BC000L12_A299ConfiguracoesId = new int[1] ;
         BC000L13_A299ConfiguracoesId = new int[1] ;
         BC000L14_A299ConfiguracoesId = new int[1] ;
         BC000L15_A299ConfiguracoesId = new int[1] ;
         BC000L16_A154LayoutContratoId = new short[1] ;
         BC000L16_A155LayoutContratoDescricao = new string[] {""} ;
         BC000L16_n155LayoutContratoDescricao = new bool[] {false} ;
         BC000L16_A156LayoutContratoStatus = new bool[] {false} ;
         BC000L16_n156LayoutContratoStatus = new bool[] {false} ;
         BC000L16_A157LayoutContratoCorpo = new string[] {""} ;
         BC000L16_n157LayoutContratoCorpo = new bool[] {false} ;
         BC000L16_A906LayoutContratoTipo = new string[] {""} ;
         BC000L16_n906LayoutContratoTipo = new bool[] {false} ;
         BC000L16_A1000LayoutContratoTag = new string[] {""} ;
         BC000L16_n1000LayoutContratoTag = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.layoutcontrato_bc__default(),
            new Object[][] {
                new Object[] {
               BC000L2_A154LayoutContratoId, BC000L2_A155LayoutContratoDescricao, BC000L2_n155LayoutContratoDescricao, BC000L2_A156LayoutContratoStatus, BC000L2_n156LayoutContratoStatus, BC000L2_A157LayoutContratoCorpo, BC000L2_n157LayoutContratoCorpo, BC000L2_A906LayoutContratoTipo, BC000L2_n906LayoutContratoTipo, BC000L2_A1000LayoutContratoTag,
               BC000L2_n1000LayoutContratoTag
               }
               , new Object[] {
               BC000L3_A154LayoutContratoId, BC000L3_A155LayoutContratoDescricao, BC000L3_n155LayoutContratoDescricao, BC000L3_A156LayoutContratoStatus, BC000L3_n156LayoutContratoStatus, BC000L3_A157LayoutContratoCorpo, BC000L3_n157LayoutContratoCorpo, BC000L3_A906LayoutContratoTipo, BC000L3_n906LayoutContratoTipo, BC000L3_A1000LayoutContratoTag,
               BC000L3_n1000LayoutContratoTag
               }
               , new Object[] {
               BC000L4_A154LayoutContratoId, BC000L4_A155LayoutContratoDescricao, BC000L4_n155LayoutContratoDescricao, BC000L4_A156LayoutContratoStatus, BC000L4_n156LayoutContratoStatus, BC000L4_A157LayoutContratoCorpo, BC000L4_n157LayoutContratoCorpo, BC000L4_A906LayoutContratoTipo, BC000L4_n906LayoutContratoTipo, BC000L4_A1000LayoutContratoTag,
               BC000L4_n1000LayoutContratoTag
               }
               , new Object[] {
               BC000L5_A154LayoutContratoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000L7_A154LayoutContratoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000L10_A898NotificacaoAgendadaId
               }
               , new Object[] {
               BC000L11_A299ConfiguracoesId
               }
               , new Object[] {
               BC000L12_A299ConfiguracoesId
               }
               , new Object[] {
               BC000L13_A299ConfiguracoesId
               }
               , new Object[] {
               BC000L14_A299ConfiguracoesId
               }
               , new Object[] {
               BC000L15_A299ConfiguracoesId
               }
               , new Object[] {
               BC000L16_A154LayoutContratoId, BC000L16_A155LayoutContratoDescricao, BC000L16_n155LayoutContratoDescricao, BC000L16_A156LayoutContratoStatus, BC000L16_n156LayoutContratoStatus, BC000L16_A157LayoutContratoCorpo, BC000L16_n157LayoutContratoCorpo, BC000L16_A906LayoutContratoTipo, BC000L16_n906LayoutContratoTipo, BC000L16_A1000LayoutContratoTag,
               BC000L16_n1000LayoutContratoTag
               }
            }
         );
         Z156LayoutContratoStatus = true;
         n156LayoutContratoStatus = false;
         A156LayoutContratoStatus = true;
         n156LayoutContratoStatus = false;
         i156LayoutContratoStatus = true;
         n156LayoutContratoStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120L2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z154LayoutContratoId ;
      private short A154LayoutContratoId ;
      private short Gx_BScreen ;
      private short RcdFound25 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode25 ;
      private bool returnInSub ;
      private bool Z156LayoutContratoStatus ;
      private bool A156LayoutContratoStatus ;
      private bool n156LayoutContratoStatus ;
      private bool n155LayoutContratoDescricao ;
      private bool n157LayoutContratoCorpo ;
      private bool n906LayoutContratoTipo ;
      private bool n1000LayoutContratoTag ;
      private bool i156LayoutContratoStatus ;
      private string Z157LayoutContratoCorpo ;
      private string A157LayoutContratoCorpo ;
      private string Z155LayoutContratoDescricao ;
      private string A155LayoutContratoDescricao ;
      private string Z906LayoutContratoTipo ;
      private string A906LayoutContratoTipo ;
      private string Z1000LayoutContratoTag ;
      private string A1000LayoutContratoTag ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] BC000L4_A154LayoutContratoId ;
      private string[] BC000L4_A155LayoutContratoDescricao ;
      private bool[] BC000L4_n155LayoutContratoDescricao ;
      private bool[] BC000L4_A156LayoutContratoStatus ;
      private bool[] BC000L4_n156LayoutContratoStatus ;
      private string[] BC000L4_A157LayoutContratoCorpo ;
      private bool[] BC000L4_n157LayoutContratoCorpo ;
      private string[] BC000L4_A906LayoutContratoTipo ;
      private bool[] BC000L4_n906LayoutContratoTipo ;
      private string[] BC000L4_A1000LayoutContratoTag ;
      private bool[] BC000L4_n1000LayoutContratoTag ;
      private short[] BC000L5_A154LayoutContratoId ;
      private short[] BC000L3_A154LayoutContratoId ;
      private string[] BC000L3_A155LayoutContratoDescricao ;
      private bool[] BC000L3_n155LayoutContratoDescricao ;
      private bool[] BC000L3_A156LayoutContratoStatus ;
      private bool[] BC000L3_n156LayoutContratoStatus ;
      private string[] BC000L3_A157LayoutContratoCorpo ;
      private bool[] BC000L3_n157LayoutContratoCorpo ;
      private string[] BC000L3_A906LayoutContratoTipo ;
      private bool[] BC000L3_n906LayoutContratoTipo ;
      private string[] BC000L3_A1000LayoutContratoTag ;
      private bool[] BC000L3_n1000LayoutContratoTag ;
      private short[] BC000L2_A154LayoutContratoId ;
      private string[] BC000L2_A155LayoutContratoDescricao ;
      private bool[] BC000L2_n155LayoutContratoDescricao ;
      private bool[] BC000L2_A156LayoutContratoStatus ;
      private bool[] BC000L2_n156LayoutContratoStatus ;
      private string[] BC000L2_A157LayoutContratoCorpo ;
      private bool[] BC000L2_n157LayoutContratoCorpo ;
      private string[] BC000L2_A906LayoutContratoTipo ;
      private bool[] BC000L2_n906LayoutContratoTipo ;
      private string[] BC000L2_A1000LayoutContratoTag ;
      private bool[] BC000L2_n1000LayoutContratoTag ;
      private short[] BC000L7_A154LayoutContratoId ;
      private int[] BC000L10_A898NotificacaoAgendadaId ;
      private int[] BC000L11_A299ConfiguracoesId ;
      private int[] BC000L12_A299ConfiguracoesId ;
      private int[] BC000L13_A299ConfiguracoesId ;
      private int[] BC000L14_A299ConfiguracoesId ;
      private int[] BC000L15_A299ConfiguracoesId ;
      private short[] BC000L16_A154LayoutContratoId ;
      private string[] BC000L16_A155LayoutContratoDescricao ;
      private bool[] BC000L16_n155LayoutContratoDescricao ;
      private bool[] BC000L16_A156LayoutContratoStatus ;
      private bool[] BC000L16_n156LayoutContratoStatus ;
      private string[] BC000L16_A157LayoutContratoCorpo ;
      private bool[] BC000L16_n157LayoutContratoCorpo ;
      private string[] BC000L16_A906LayoutContratoTipo ;
      private bool[] BC000L16_n906LayoutContratoTipo ;
      private string[] BC000L16_A1000LayoutContratoTag ;
      private bool[] BC000L16_n1000LayoutContratoTag ;
      private SdtLayoutContrato bcLayoutContrato ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class layoutcontrato_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000L2;
          prmBC000L2 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmBC000L3;
          prmBC000L3 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmBC000L4;
          prmBC000L4 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmBC000L5;
          prmBC000L5 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmBC000L6;
          prmBC000L6 = new Object[] {
          new ParDef("LayoutContratoDescricao",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("LayoutContratoStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("LayoutContratoCorpo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("LayoutContratoTipo",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("LayoutContratoTag",GXType.VarChar,40,0){Nullable=true}
          };
          Object[] prmBC000L7;
          prmBC000L7 = new Object[] {
          };
          Object[] prmBC000L8;
          prmBC000L8 = new Object[] {
          new ParDef("LayoutContratoDescricao",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("LayoutContratoStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("LayoutContratoCorpo",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("LayoutContratoTipo",GXType.VarChar,1,0){Nullable=true} ,
          new ParDef("LayoutContratoTag",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmBC000L9;
          prmBC000L9 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmBC000L10;
          prmBC000L10 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmBC000L11;
          prmBC000L11 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmBC000L12;
          prmBC000L12 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmBC000L13;
          prmBC000L13 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmBC000L14;
          prmBC000L14 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmBC000L15;
          prmBC000L15 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          Object[] prmBC000L16;
          prmBC000L16 = new Object[] {
          new ParDef("LayoutContratoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000L2", "SELECT LayoutContratoId, LayoutContratoDescricao, LayoutContratoStatus, LayoutContratoCorpo, LayoutContratoTipo, LayoutContratoTag FROM LayoutContrato WHERE LayoutContratoId = :LayoutContratoId  FOR UPDATE OF LayoutContrato",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000L3", "SELECT LayoutContratoId, LayoutContratoDescricao, LayoutContratoStatus, LayoutContratoCorpo, LayoutContratoTipo, LayoutContratoTag FROM LayoutContrato WHERE LayoutContratoId = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000L4", "SELECT TM1.LayoutContratoId, TM1.LayoutContratoDescricao, TM1.LayoutContratoStatus, TM1.LayoutContratoCorpo, TM1.LayoutContratoTipo, TM1.LayoutContratoTag FROM LayoutContrato TM1 WHERE TM1.LayoutContratoId = :LayoutContratoId ORDER BY TM1.LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000L5", "SELECT LayoutContratoId FROM LayoutContrato WHERE LayoutContratoId = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000L6", "SAVEPOINT gxupdate;INSERT INTO LayoutContrato(LayoutContratoDescricao, LayoutContratoStatus, LayoutContratoCorpo, LayoutContratoTipo, LayoutContratoTag) VALUES(:LayoutContratoDescricao, :LayoutContratoStatus, :LayoutContratoCorpo, :LayoutContratoTipo, :LayoutContratoTag);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000L6)
             ,new CursorDef("BC000L7", "SELECT currval('LayoutContratoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000L8", "SAVEPOINT gxupdate;UPDATE LayoutContrato SET LayoutContratoDescricao=:LayoutContratoDescricao, LayoutContratoStatus=:LayoutContratoStatus, LayoutContratoCorpo=:LayoutContratoCorpo, LayoutContratoTipo=:LayoutContratoTipo, LayoutContratoTag=:LayoutContratoTag  WHERE LayoutContratoId = :LayoutContratoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000L8)
             ,new CursorDef("BC000L9", "SAVEPOINT gxupdate;DELETE FROM LayoutContrato  WHERE LayoutContratoId = :LayoutContratoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000L9)
             ,new CursorDef("BC000L10", "SELECT NotificacaoAgendadaId FROM NotificacaoAgendada WHERE NotificacaoAgendadaLayoutId = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000L11", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfigLayoutContratoCompraTitulo = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000L12", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfigLayoutPromissoriaPaciente = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000L13", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfigLayoutPromissoriaClinicaTaxa = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000L14", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfigLayoutPromissoriaClinicaEmprestimo = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000L15", "SELECT ConfiguracoesId FROM Configuracoes WHERE ConfiguracoesLayoutProposta = :LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000L16", "SELECT TM1.LayoutContratoId, TM1.LayoutContratoDescricao, TM1.LayoutContratoStatus, TM1.LayoutContratoCorpo, TM1.LayoutContratoTipo, TM1.LayoutContratoTag FROM LayoutContrato TM1 WHERE TM1.LayoutContratoId = :LayoutContratoId ORDER BY TM1.LayoutContratoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L16,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
