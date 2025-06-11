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
   public class clientenotas_bc : GxSilentTrn, IGxSilentTrn
   {
      public clientenotas_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientenotas_bc( IGxContext context )
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
         ReadRow2R28( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2R28( ) ;
         standaloneModal( ) ;
         AddRow2R28( ) ;
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
               Z168ClienteId = A168ClienteId;
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

      protected void CONFIRM_2R0( )
      {
         BeforeValidate2R28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2R28( ) ;
            }
            else
            {
               CheckExtendedTable2R28( ) ;
               if ( AnyError == 0 )
               {
                  ZM2R28( 3) ;
               }
               CloseExtendedTableCursors2R28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM2R28( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z886ClienteCountNotas_F = A886ClienteCountNotas_F;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z886ClienteCountNotas_F = A886ClienteCountNotas_F;
         }
         if ( GX_JID == -1 )
         {
            Z168ClienteId = A168ClienteId;
            Z886ClienteCountNotas_F = A886ClienteCountNotas_F;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2R28( )
      {
         /* Using cursor BC002R7 */
         pr_default.execute(3, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound28 = 1;
            A886ClienteCountNotas_F = BC002R7_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = BC002R7_n886ClienteCountNotas_F[0];
            ZM2R28( -1) ;
         }
         pr_default.close(3);
         OnLoadActions2R28( ) ;
      }

      protected void OnLoadActions2R28( )
      {
      }

      protected void CheckExtendedTable2R28( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002R5 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A886ClienteCountNotas_F = BC002R5_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = BC002R5_n886ClienteCountNotas_F[0];
         }
         else
         {
            A886ClienteCountNotas_F = 0;
            n886ClienteCountNotas_F = false;
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors2R28( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2R28( )
      {
         /* Using cursor BC002R8 */
         pr_default.execute(4, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002R3 */
         pr_default.execute(1, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2R28( 1) ;
            RcdFound28 = 1;
            A168ClienteId = BC002R3_A168ClienteId[0];
            n168ClienteId = BC002R3_n168ClienteId[0];
            Z168ClienteId = A168ClienteId;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2R28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey2R28( ) ;
            }
            Gx_mode = sMode28;
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey2R28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode28;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2R28( ) ;
         if ( RcdFound28 == 0 )
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
         CONFIRM_2R0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2R28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002R2 */
            pr_default.execute(0, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Cliente"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2R28( )
      {
         BeforeValidate2R28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2R28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2R28( 0) ;
            CheckOptimisticConcurrency2R28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2R28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2R28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002R9 */
                     pr_default.execute(5);
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002R10 */
                     pr_default.execute(6);
                     A168ClienteId = BC002R10_A168ClienteId[0];
                     n168ClienteId = BC002R10_n168ClienteId[0];
                     pr_default.close(6);
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
               Load2R28( ) ;
            }
            EndLevel2R28( ) ;
         }
         CloseExtendedTableCursors2R28( ) ;
      }

      protected void Update2R28( )
      {
         BeforeValidate2R28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2R28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2R28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2R28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2R28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table Cliente */
                     DeferredUpdate2R28( ) ;
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
            EndLevel2R28( ) ;
         }
         CloseExtendedTableCursors2R28( ) ;
      }

      protected void DeferredUpdate2R28( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2R28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2R28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2R28( ) ;
            AfterConfirm2R28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2R28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002R11 */
                  pr_default.execute(7, new Object[] {n168ClienteId, A168ClienteId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Cliente");
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2R28( ) ;
         Gx_mode = sMode28;
      }

      protected void OnDeleteControls2R28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002R13 */
            pr_default.execute(8, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               A886ClienteCountNotas_F = BC002R13_A886ClienteCountNotas_F[0];
               n886ClienteCountNotas_F = BC002R13_n886ClienteCountNotas_F[0];
            }
            else
            {
               A886ClienteCountNotas_F = 0;
               n886ClienteCountNotas_F = false;
            }
            pr_default.close(8);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC002R14 */
            pr_default.execute(9, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"OperacoesTitulos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC002R15 */
            pr_default.execute(10, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Sd Proposta Empresa"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC002R16 */
            pr_default.execute(11, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Sb Proposta Clinica"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC002R17 */
            pr_default.execute(12, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Proposta Responsavel"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC002R18 */
            pr_default.execute(13, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"+" ("+"Proposta Cliente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC002R19 */
            pr_default.execute(14, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor BC002R20 */
            pr_default.execute(15, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor BC002R21 */
            pr_default.execute(16, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor BC002R22 */
            pr_default.execute(17, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Relacionamento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor BC002R23 */
            pr_default.execute(18, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Operacoes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor BC002R24 */
            pr_default.execute(19, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Representante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor BC002R25 */
            pr_default.execute(20, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor BC002R26 */
            pr_default.execute(21, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscal"+" ("+"Sb Nota Destinatario Cliente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor BC002R27 */
            pr_default.execute(22, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"NotaFiscal"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor BC002R28 */
            pr_default.execute(23, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Serasa"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor BC002R29 */
            pr_default.execute(24, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor BC002R30 */
            pr_default.execute(25, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteReponsavel"+" ("+"Sb Cliente Reponsavel"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor BC002R31 */
            pr_default.execute(26, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteReponsavel"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor BC002R32 */
            pr_default.execute(27, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"AssinaturaParticipante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor BC002R33 */
            pr_default.execute(28, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Financiamento"+" ("+"SBFin Cli Int"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor BC002R34 */
            pr_default.execute(29, new Object[] {n168ClienteId, A168ClienteId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Financiamento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
         }
      }

      protected void EndLevel2R28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2R28( ) ;
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

      public void ScanKeyStart2R28( )
      {
         /* Using cursor BC002R36 */
         pr_default.execute(30, new Object[] {n168ClienteId, A168ClienteId});
         RcdFound28 = 0;
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound28 = 1;
            A168ClienteId = BC002R36_A168ClienteId[0];
            n168ClienteId = BC002R36_n168ClienteId[0];
            A886ClienteCountNotas_F = BC002R36_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = BC002R36_n886ClienteCountNotas_F[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2R28( )
      {
         /* Scan next routine */
         pr_default.readNext(30);
         RcdFound28 = 0;
         ScanKeyLoad2R28( ) ;
      }

      protected void ScanKeyLoad2R28( )
      {
         sMode28 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound28 = 1;
            A168ClienteId = BC002R36_A168ClienteId[0];
            n168ClienteId = BC002R36_n168ClienteId[0];
            A886ClienteCountNotas_F = BC002R36_A886ClienteCountNotas_F[0];
            n886ClienteCountNotas_F = BC002R36_n886ClienteCountNotas_F[0];
         }
         Gx_mode = sMode28;
      }

      protected void ScanKeyEnd2R28( )
      {
         pr_default.close(30);
      }

      protected void AfterConfirm2R28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2R28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2R28( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2R28( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2R28( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2R28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2R28( )
      {
      }

      protected void send_integrity_lvl_hashes2R28( )
      {
      }

      protected void AddRow2R28( )
      {
         VarsToRow28( bcClienteNotas) ;
      }

      protected void ReadRow2R28( )
      {
         RowToVars28( bcClienteNotas, 1) ;
      }

      protected void InitializeNonKey2R28( )
      {
         A886ClienteCountNotas_F = 0;
         n886ClienteCountNotas_F = false;
      }

      protected void InitAll2R28( )
      {
         A168ClienteId = 0;
         n168ClienteId = false;
         InitializeNonKey2R28( ) ;
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

      public void VarsToRow28( SdtClienteNotas obj28 )
      {
         obj28.gxTpr_Mode = Gx_mode;
         obj28.gxTpr_Clientecountnotas_f = A886ClienteCountNotas_F;
         obj28.gxTpr_Clienteid = A168ClienteId;
         obj28.gxTpr_Clienteid_Z = Z168ClienteId;
         obj28.gxTpr_Clientecountnotas_f_Z = Z886ClienteCountNotas_F;
         obj28.gxTpr_Clienteid_N = (short)(Convert.ToInt16(n168ClienteId));
         obj28.gxTpr_Clientecountnotas_f_N = (short)(Convert.ToInt16(n886ClienteCountNotas_F));
         obj28.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow28( SdtClienteNotas obj28 )
      {
         obj28.gxTpr_Clienteid = A168ClienteId;
         return  ;
      }

      public void RowToVars28( SdtClienteNotas obj28 ,
                               int forceLoad )
      {
         Gx_mode = obj28.gxTpr_Mode;
         A886ClienteCountNotas_F = obj28.gxTpr_Clientecountnotas_f;
         n886ClienteCountNotas_F = false;
         A168ClienteId = obj28.gxTpr_Clienteid;
         n168ClienteId = false;
         Z168ClienteId = obj28.gxTpr_Clienteid_Z;
         Z886ClienteCountNotas_F = obj28.gxTpr_Clientecountnotas_f_Z;
         n168ClienteId = (bool)(Convert.ToBoolean(obj28.gxTpr_Clienteid_N));
         n886ClienteCountNotas_F = (bool)(Convert.ToBoolean(obj28.gxTpr_Clientecountnotas_f_N));
         Gx_mode = obj28.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A168ClienteId = (int)getParm(obj,0);
         n168ClienteId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2R28( ) ;
         ScanKeyStart2R28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z168ClienteId = A168ClienteId;
         }
         ZM2R28( -1) ;
         OnLoadActions2R28( ) ;
         AddRow2R28( ) ;
         ScanKeyEnd2R28( ) ;
         if ( RcdFound28 == 0 )
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
         RowToVars28( bcClienteNotas, 0) ;
         ScanKeyStart2R28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z168ClienteId = A168ClienteId;
         }
         ZM2R28( -1) ;
         OnLoadActions2R28( ) ;
         AddRow2R28( ) ;
         ScanKeyEnd2R28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2R28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2R28( ) ;
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( A168ClienteId != Z168ClienteId )
               {
                  A168ClienteId = Z168ClienteId;
                  n168ClienteId = false;
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
                  Update2R28( ) ;
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
                  if ( A168ClienteId != Z168ClienteId )
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
                        Insert2R28( ) ;
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
                        Insert2R28( ) ;
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
         RowToVars28( bcClienteNotas, 1) ;
         SaveImpl( ) ;
         VarsToRow28( bcClienteNotas) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars28( bcClienteNotas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2R28( ) ;
         AfterTrn( ) ;
         VarsToRow28( bcClienteNotas) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow28( bcClienteNotas) ;
         }
         else
         {
            SdtClienteNotas auxBC = new SdtClienteNotas(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A168ClienteId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcClienteNotas);
               auxBC.Save();
               bcClienteNotas.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars28( bcClienteNotas, 1) ;
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
         RowToVars28( bcClienteNotas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2R28( ) ;
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
               VarsToRow28( bcClienteNotas) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow28( bcClienteNotas) ;
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
         RowToVars28( bcClienteNotas, 0) ;
         GetKey2R28( ) ;
         if ( RcdFound28 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A168ClienteId != Z168ClienteId )
            {
               A168ClienteId = Z168ClienteId;
               n168ClienteId = false;
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
            if ( A168ClienteId != Z168ClienteId )
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
         context.RollbackDataStores("clientenotas_bc",pr_default);
         VarsToRow28( bcClienteNotas) ;
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
         Gx_mode = bcClienteNotas.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcClienteNotas.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcClienteNotas )
         {
            bcClienteNotas = (SdtClienteNotas)(sdt);
            if ( StringUtil.StrCmp(bcClienteNotas.gxTpr_Mode, "") == 0 )
            {
               bcClienteNotas.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow28( bcClienteNotas) ;
            }
            else
            {
               RowToVars28( bcClienteNotas, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcClienteNotas.gxTpr_Mode, "") == 0 )
            {
               bcClienteNotas.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars28( bcClienteNotas, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtClienteNotas ClienteNotas_BC
      {
         get {
            return bcClienteNotas ;
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
         pr_default.close(8);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         BC002R7_A168ClienteId = new int[1] ;
         BC002R7_n168ClienteId = new bool[] {false} ;
         BC002R7_A886ClienteCountNotas_F = new short[1] ;
         BC002R7_n886ClienteCountNotas_F = new bool[] {false} ;
         BC002R5_A886ClienteCountNotas_F = new short[1] ;
         BC002R5_n886ClienteCountNotas_F = new bool[] {false} ;
         BC002R8_A168ClienteId = new int[1] ;
         BC002R8_n168ClienteId = new bool[] {false} ;
         BC002R3_A168ClienteId = new int[1] ;
         BC002R3_n168ClienteId = new bool[] {false} ;
         sMode28 = "";
         BC002R2_A168ClienteId = new int[1] ;
         BC002R2_n168ClienteId = new bool[] {false} ;
         BC002R10_A168ClienteId = new int[1] ;
         BC002R10_n168ClienteId = new bool[] {false} ;
         BC002R13_A886ClienteCountNotas_F = new short[1] ;
         BC002R13_n886ClienteCountNotas_F = new bool[] {false} ;
         BC002R14_A1019OperacoesTitulosId = new int[1] ;
         BC002R15_A323PropostaId = new int[1] ;
         BC002R16_A323PropostaId = new int[1] ;
         BC002R17_A323PropostaId = new int[1] ;
         BC002R18_A323PropostaId = new int[1] ;
         BC002R19_A227ContratoId = new int[1] ;
         BC002R20_A261TituloId = new int[1] ;
         BC002R21_A133SecUserId = new short[1] ;
         BC002R22_A1032RelacionamentoId = new int[1] ;
         BC002R23_A1010OperacoesId = new int[1] ;
         BC002R24_A978RepresentanteId = new int[1] ;
         BC002R25_A856CreditoId = new int[1] ;
         BC002R26_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002R27_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002R28_A662SerasaId = new int[1] ;
         BC002R29_A599ClienteDocumentoId = new int[1] ;
         BC002R30_A551ClienteReponsavelId = new int[1] ;
         BC002R31_A551ClienteReponsavelId = new int[1] ;
         BC002R32_A242AssinaturaParticipanteId = new int[1] ;
         BC002R33_A223FinanciamentoId = new int[1] ;
         BC002R34_A223FinanciamentoId = new int[1] ;
         BC002R36_A168ClienteId = new int[1] ;
         BC002R36_n168ClienteId = new bool[] {false} ;
         BC002R36_A886ClienteCountNotas_F = new short[1] ;
         BC002R36_n886ClienteCountNotas_F = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientenotas_bc__default(),
            new Object[][] {
                new Object[] {
               BC002R2_A168ClienteId
               }
               , new Object[] {
               BC002R3_A168ClienteId
               }
               , new Object[] {
               BC002R5_A886ClienteCountNotas_F, BC002R5_n886ClienteCountNotas_F
               }
               , new Object[] {
               BC002R7_A168ClienteId, BC002R7_A886ClienteCountNotas_F, BC002R7_n886ClienteCountNotas_F
               }
               , new Object[] {
               BC002R8_A168ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002R10_A168ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002R13_A886ClienteCountNotas_F, BC002R13_n886ClienteCountNotas_F
               }
               , new Object[] {
               BC002R14_A1019OperacoesTitulosId
               }
               , new Object[] {
               BC002R15_A323PropostaId
               }
               , new Object[] {
               BC002R16_A323PropostaId
               }
               , new Object[] {
               BC002R17_A323PropostaId
               }
               , new Object[] {
               BC002R18_A323PropostaId
               }
               , new Object[] {
               BC002R19_A227ContratoId
               }
               , new Object[] {
               BC002R20_A261TituloId
               }
               , new Object[] {
               BC002R21_A133SecUserId
               }
               , new Object[] {
               BC002R22_A1032RelacionamentoId
               }
               , new Object[] {
               BC002R23_A1010OperacoesId
               }
               , new Object[] {
               BC002R24_A978RepresentanteId
               }
               , new Object[] {
               BC002R25_A856CreditoId
               }
               , new Object[] {
               BC002R26_A794NotaFiscalId
               }
               , new Object[] {
               BC002R27_A794NotaFiscalId
               }
               , new Object[] {
               BC002R28_A662SerasaId
               }
               , new Object[] {
               BC002R29_A599ClienteDocumentoId
               }
               , new Object[] {
               BC002R30_A551ClienteReponsavelId
               }
               , new Object[] {
               BC002R31_A551ClienteReponsavelId
               }
               , new Object[] {
               BC002R32_A242AssinaturaParticipanteId
               }
               , new Object[] {
               BC002R33_A223FinanciamentoId
               }
               , new Object[] {
               BC002R34_A223FinanciamentoId
               }
               , new Object[] {
               BC002R36_A168ClienteId, BC002R36_A886ClienteCountNotas_F, BC002R36_n886ClienteCountNotas_F
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z886ClienteCountNotas_F ;
      private short A886ClienteCountNotas_F ;
      private short RcdFound28 ;
      private int trnEnded ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode28 ;
      private bool n168ClienteId ;
      private bool n886ClienteCountNotas_F ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC002R7_A168ClienteId ;
      private bool[] BC002R7_n168ClienteId ;
      private short[] BC002R7_A886ClienteCountNotas_F ;
      private bool[] BC002R7_n886ClienteCountNotas_F ;
      private short[] BC002R5_A886ClienteCountNotas_F ;
      private bool[] BC002R5_n886ClienteCountNotas_F ;
      private int[] BC002R8_A168ClienteId ;
      private bool[] BC002R8_n168ClienteId ;
      private int[] BC002R3_A168ClienteId ;
      private bool[] BC002R3_n168ClienteId ;
      private int[] BC002R2_A168ClienteId ;
      private bool[] BC002R2_n168ClienteId ;
      private int[] BC002R10_A168ClienteId ;
      private bool[] BC002R10_n168ClienteId ;
      private short[] BC002R13_A886ClienteCountNotas_F ;
      private bool[] BC002R13_n886ClienteCountNotas_F ;
      private int[] BC002R14_A1019OperacoesTitulosId ;
      private int[] BC002R15_A323PropostaId ;
      private int[] BC002R16_A323PropostaId ;
      private int[] BC002R17_A323PropostaId ;
      private int[] BC002R18_A323PropostaId ;
      private int[] BC002R19_A227ContratoId ;
      private int[] BC002R20_A261TituloId ;
      private short[] BC002R21_A133SecUserId ;
      private int[] BC002R22_A1032RelacionamentoId ;
      private int[] BC002R23_A1010OperacoesId ;
      private int[] BC002R24_A978RepresentanteId ;
      private int[] BC002R25_A856CreditoId ;
      private Guid[] BC002R26_A794NotaFiscalId ;
      private Guid[] BC002R27_A794NotaFiscalId ;
      private int[] BC002R28_A662SerasaId ;
      private int[] BC002R29_A599ClienteDocumentoId ;
      private int[] BC002R30_A551ClienteReponsavelId ;
      private int[] BC002R31_A551ClienteReponsavelId ;
      private int[] BC002R32_A242AssinaturaParticipanteId ;
      private int[] BC002R33_A223FinanciamentoId ;
      private int[] BC002R34_A223FinanciamentoId ;
      private int[] BC002R36_A168ClienteId ;
      private bool[] BC002R36_n168ClienteId ;
      private short[] BC002R36_A886ClienteCountNotas_F ;
      private bool[] BC002R36_n886ClienteCountNotas_F ;
      private SdtClienteNotas bcClienteNotas ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class clientenotas_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002R2;
          prmBC002R2 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R3;
          prmBC002R3 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R5;
          prmBC002R5 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R7;
          prmBC002R7 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R8;
          prmBC002R8 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R9;
          prmBC002R9 = new Object[] {
          };
          Object[] prmBC002R10;
          prmBC002R10 = new Object[] {
          };
          Object[] prmBC002R11;
          prmBC002R11 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R13;
          prmBC002R13 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R14;
          prmBC002R14 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R15;
          prmBC002R15 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R16;
          prmBC002R16 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R17;
          prmBC002R17 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R18;
          prmBC002R18 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R19;
          prmBC002R19 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R20;
          prmBC002R20 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R21;
          prmBC002R21 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R22;
          prmBC002R22 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R23;
          prmBC002R23 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R24;
          prmBC002R24 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R25;
          prmBC002R25 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R26;
          prmBC002R26 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R27;
          prmBC002R27 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R28;
          prmBC002R28 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R29;
          prmBC002R29 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R30;
          prmBC002R30 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R31;
          prmBC002R31 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R32;
          prmBC002R32 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R33;
          prmBC002R33 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R34;
          prmBC002R34 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002R36;
          prmBC002R36 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC002R2", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId  FOR UPDATE OF Cliente",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002R3", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002R5", "SELECT COALESCE( T1.ClienteCountNotas_F, 0) AS ClienteCountNotas_F FROM (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002R7", "SELECT TM1.ClienteId, COALESCE( T2.ClienteCountNotas_F, 0) AS ClienteCountNotas_F FROM (Cliente TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal WHERE TM1.ClienteId = ClienteId GROUP BY ClienteId ) T2 ON T2.ClienteId = TM1.ClienteId) WHERE TM1.ClienteId = :ClienteId ORDER BY TM1.ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002R8", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002R9", "SAVEPOINT gxupdate;INSERT INTO Cliente(ClienteDocumento, ClienteRazaoSocial, ClienteNomeFantasia, ClienteTipoPessoa, ClienteStatus, ClienteCreatedAt, ClienteUpdatedAt, ClienteLogUser, TipoClienteId, EnderecoTipo, EnderecoCEP, EnderecoLogradouro, EnderecoBairro, EnderecoCidade, MunicipioCodigo, EnderecoNumero, EnderecoComplemento, ContatoEmail, ContatoDDD, ContatoDDI, ContatoNumero, ContatoTelefoneNumero, ContatoTelefoneDDD, ContatoTelefoneDDI, BancoId, ContaAgencia, ContaNumero, ClienteRG, ResponsavelNome, ResponsavelNacionalidade, ResponsavelEstadoCivil, ResponsavelProfissao, ResponsavelCPF, ResponsavelCEP, ResponsavelLogradouro, ResponsavelBairro, ResponsavelCidade, ResponsavelMunicipio, ResponsavelLogradouroNumero, ResponsavelComplemento, ResponsavelDDD, ResponsavelNumero, ResponsavelEmail, ClienteDataNascimento, EspecialidadeId, ClienteConvenio, ClienteNacionalidade, ClienteProfissao, ClienteEstadoCivil, ClienteDepositoTipo, ClientePixTipo, ClientePix, ResponsavelRG, ClienteSituacao, ResponsavelCargo, ClienteTipoRisco) VALUES('', '', '', '', FALSE, DATE '00010101', DATE '00010101', 0, 0, '', '', '', '', '', '', '', '', '', 0, 0, 0, 0, 0, 0, 0, '', '', 0, '', 0, '', 0, '', '', '', '', '', '', 0, '', 0, 0, '', DATE '00010101', 0, 0, 0, 0, '', '', '', '', 0, '', '', '');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002R9)
             ,new CursorDef("BC002R10", "SELECT currval('ClienteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002R11", "SAVEPOINT gxupdate;DELETE FROM Cliente  WHERE ClienteId = :ClienteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002R11)
             ,new CursorDef("BC002R13", "SELECT COALESCE( T1.ClienteCountNotas_F, 0) AS ClienteCountNotas_F FROM (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal GROUP BY ClienteId ) T1 WHERE T1.ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002R14", "SELECT OperacoesTitulosId FROM OperacoesTitulos WHERE SacadoId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R15", "SELECT PropostaId FROM Proposta WHERE PropostaEmpresaClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R16", "SELECT PropostaId FROM Proposta WHERE PropostaClinicaId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R16,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R17", "SELECT PropostaId FROM Proposta WHERE PropostaResponsavelId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R17,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R18", "SELECT PropostaId FROM Proposta WHERE PropostaPacienteClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R19", "SELECT ContratoId FROM Contrato WHERE ContratoClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R19,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R20", "SELECT TituloId FROM Titulo WHERE TituloClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R20,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R21", "SELECT SecUserId FROM SecUser WHERE SecUserOwnerId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R22", "SELECT RelacionamentoId FROM Relacionamento WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R23", "SELECT OperacoesId FROM Operacoes WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R23,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R24", "SELECT RepresentanteId FROM Representante WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R24,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R25", "SELECT CreditoId FROM Credito WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R25,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R26", "SELECT NotaFiscalId FROM NotaFiscal WHERE NotaFiscalDestinatarioClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R26,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R27", "SELECT NotaFiscalId FROM NotaFiscal WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R27,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R28", "SELECT SerasaId FROM Serasa WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R28,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R29", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R29,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R30", "SELECT ClienteReponsavelId FROM ClienteReponsavel WHERE ReponsavelClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R30,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R31", "SELECT ClienteReponsavelId FROM ClienteReponsavel WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R31,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R32", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R32,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R33", "SELECT FinanciamentoId FROM Financiamento WHERE IntermediadorClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R33,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R34", "SELECT FinanciamentoId FROM Financiamento WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R34,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002R36", "SELECT TM1.ClienteId, COALESCE( T2.ClienteCountNotas_F, 0) AS ClienteCountNotas_F FROM (Cliente TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS ClienteCountNotas_F, ClienteId FROM NotaFiscal WHERE TM1.ClienteId = ClienteId GROUP BY ClienteId ) T2 ON T2.ClienteId = TM1.ClienteId) WHERE TM1.ClienteId = :ClienteId ORDER BY TM1.ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002R36,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 21 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 22 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 27 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}
