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
   public class agencia_bc : GxSilentTrn, IGxSilentTrn
   {
      public agencia_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public agencia_bc( IGxContext context )
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
         ReadRow2X101( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2X101( ) ;
         standaloneModal( ) ;
         AddRow2X101( ) ;
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
            E112X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z938AgenciaId = A938AgenciaId;
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

      protected void CONFIRM_2X0( )
      {
         BeforeValidate2X101( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2X101( ) ;
            }
            else
            {
               CheckExtendedTable2X101( ) ;
               if ( AnyError == 0 )
               {
                  ZM2X101( 10) ;
                  ZM2X101( 11) ;
                  ZM2X101( 12) ;
               }
               CloseExtendedTableCursors2X101( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV26Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV27GXV1 = 1;
            while ( AV27GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV27GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "AgenciaBancoId") == 0 )
               {
                  AV24Insert_AgenciaBancoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "AgenciaCreatedBy") == 0 )
               {
                  AV11Insert_AgenciaCreatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "AgenciaUpdatedBy") == 0 )
               {
                  AV12Insert_AgenciaUpdatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV27GXV1 = (int)(AV27GXV1+1);
            }
         }
      }

      protected void E112X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2X101( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z941AgenciaCreatedAt = A941AgenciaCreatedAt;
            Z942AgenciaUpdatedAt = A942AgenciaUpdatedAt;
            Z939AgenciaNumero = A939AgenciaNumero;
            Z945AgenciaDigito = A945AgenciaDigito;
            Z940AgenciaStatus = A940AgenciaStatus;
            Z936AgenciaCreatedBy = A936AgenciaCreatedBy;
            Z943AgenciaUpdatedBy = A943AgenciaUpdatedBy;
            Z968AgenciaBancoId = A968AgenciaBancoId;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z937AgenciaCreatedByName = A937AgenciaCreatedByName;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z944AgenciaUpdatedByName = A944AgenciaUpdatedByName;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z969AgenciaBancoNome = A969AgenciaBancoNome;
            Z974AgenciaBancoCodigo = A974AgenciaBancoCodigo;
         }
         if ( GX_JID == -9 )
         {
            Z938AgenciaId = A938AgenciaId;
            Z941AgenciaCreatedAt = A941AgenciaCreatedAt;
            Z942AgenciaUpdatedAt = A942AgenciaUpdatedAt;
            Z939AgenciaNumero = A939AgenciaNumero;
            Z945AgenciaDigito = A945AgenciaDigito;
            Z940AgenciaStatus = A940AgenciaStatus;
            Z936AgenciaCreatedBy = A936AgenciaCreatedBy;
            Z943AgenciaUpdatedBy = A943AgenciaUpdatedBy;
            Z968AgenciaBancoId = A968AgenciaBancoId;
            Z969AgenciaBancoNome = A969AgenciaBancoNome;
            Z974AgenciaBancoCodigo = A974AgenciaBancoCodigo;
            Z937AgenciaCreatedByName = A937AgenciaCreatedByName;
            Z944AgenciaUpdatedByName = A944AgenciaUpdatedByName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV26Pgmname = "Agencia_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A941AgenciaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n941AgenciaCreatedAt = false;
         }
         if ( IsUpd( )  )
         {
            A942AgenciaUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n942AgenciaUpdatedAt = false;
         }
         if ( IsIns( )  && (false==A940AgenciaStatus) && ( Gx_BScreen == 0 ) )
         {
            A940AgenciaStatus = true;
            n940AgenciaStatus = false;
         }
      }

      protected void Load2X101( )
      {
         /* Using cursor BC002X7 */
         pr_default.execute(5, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound101 = 1;
            A941AgenciaCreatedAt = BC002X7_A941AgenciaCreatedAt[0];
            n941AgenciaCreatedAt = BC002X7_n941AgenciaCreatedAt[0];
            A942AgenciaUpdatedAt = BC002X7_A942AgenciaUpdatedAt[0];
            n942AgenciaUpdatedAt = BC002X7_n942AgenciaUpdatedAt[0];
            A969AgenciaBancoNome = BC002X7_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC002X7_n969AgenciaBancoNome[0];
            A974AgenciaBancoCodigo = BC002X7_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = BC002X7_n974AgenciaBancoCodigo[0];
            A939AgenciaNumero = BC002X7_A939AgenciaNumero[0];
            n939AgenciaNumero = BC002X7_n939AgenciaNumero[0];
            A945AgenciaDigito = BC002X7_A945AgenciaDigito[0];
            n945AgenciaDigito = BC002X7_n945AgenciaDigito[0];
            A940AgenciaStatus = BC002X7_A940AgenciaStatus[0];
            n940AgenciaStatus = BC002X7_n940AgenciaStatus[0];
            A937AgenciaCreatedByName = BC002X7_A937AgenciaCreatedByName[0];
            n937AgenciaCreatedByName = BC002X7_n937AgenciaCreatedByName[0];
            A944AgenciaUpdatedByName = BC002X7_A944AgenciaUpdatedByName[0];
            n944AgenciaUpdatedByName = BC002X7_n944AgenciaUpdatedByName[0];
            A936AgenciaCreatedBy = BC002X7_A936AgenciaCreatedBy[0];
            n936AgenciaCreatedBy = BC002X7_n936AgenciaCreatedBy[0];
            A943AgenciaUpdatedBy = BC002X7_A943AgenciaUpdatedBy[0];
            n943AgenciaUpdatedBy = BC002X7_n943AgenciaUpdatedBy[0];
            A968AgenciaBancoId = BC002X7_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC002X7_n968AgenciaBancoId[0];
            ZM2X101( -9) ;
         }
         pr_default.close(5);
         OnLoadActions2X101( ) ;
      }

      protected void OnLoadActions2X101( )
      {
         if ( (0==A936AgenciaCreatedBy) )
         {
            A936AgenciaCreatedBy = 0;
            n936AgenciaCreatedBy = false;
            n936AgenciaCreatedBy = true;
            n936AgenciaCreatedBy = true;
         }
         if ( (0==A943AgenciaUpdatedBy) )
         {
            A943AgenciaUpdatedBy = 0;
            n943AgenciaUpdatedBy = false;
            n943AgenciaUpdatedBy = true;
            n943AgenciaUpdatedBy = true;
         }
      }

      protected void CheckExtendedTable2X101( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002X6 */
         pr_default.execute(4, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = BC002X6_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = BC002X6_n969AgenciaBancoNome[0];
         A974AgenciaBancoCodigo = BC002X6_A974AgenciaBancoCodigo[0];
         n974AgenciaBancoCodigo = BC002X6_n974AgenciaBancoCodigo[0];
         pr_default.close(4);
         if ( (0==A936AgenciaCreatedBy) )
         {
            A936AgenciaCreatedBy = 0;
            n936AgenciaCreatedBy = false;
            n936AgenciaCreatedBy = true;
            n936AgenciaCreatedBy = true;
         }
         /* Using cursor BC002X4 */
         pr_default.execute(2, new Object[] {n936AgenciaCreatedBy, A936AgenciaCreatedBy});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A936AgenciaCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Created By'.", "ForeignKeyNotFound", 1, "AGENCIACREATEDBY");
               AnyError = 1;
            }
         }
         A937AgenciaCreatedByName = BC002X4_A937AgenciaCreatedByName[0];
         n937AgenciaCreatedByName = BC002X4_n937AgenciaCreatedByName[0];
         pr_default.close(2);
         if ( (0==A943AgenciaUpdatedBy) )
         {
            A943AgenciaUpdatedBy = 0;
            n943AgenciaUpdatedBy = false;
            n943AgenciaUpdatedBy = true;
            n943AgenciaUpdatedBy = true;
         }
         /* Using cursor BC002X5 */
         pr_default.execute(3, new Object[] {n943AgenciaUpdatedBy, A943AgenciaUpdatedBy});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A943AgenciaUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Updated By'.", "ForeignKeyNotFound", 1, "AGENCIAUPDATEDBY");
               AnyError = 1;
            }
         }
         A944AgenciaUpdatedByName = BC002X5_A944AgenciaUpdatedByName[0];
         n944AgenciaUpdatedByName = BC002X5_n944AgenciaUpdatedByName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2X101( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2X101( )
      {
         /* Using cursor BC002X8 */
         pr_default.execute(6, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound101 = 1;
         }
         else
         {
            RcdFound101 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002X3 */
         pr_default.execute(1, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2X101( 9) ;
            RcdFound101 = 1;
            A938AgenciaId = BC002X3_A938AgenciaId[0];
            n938AgenciaId = BC002X3_n938AgenciaId[0];
            A941AgenciaCreatedAt = BC002X3_A941AgenciaCreatedAt[0];
            n941AgenciaCreatedAt = BC002X3_n941AgenciaCreatedAt[0];
            A942AgenciaUpdatedAt = BC002X3_A942AgenciaUpdatedAt[0];
            n942AgenciaUpdatedAt = BC002X3_n942AgenciaUpdatedAt[0];
            A939AgenciaNumero = BC002X3_A939AgenciaNumero[0];
            n939AgenciaNumero = BC002X3_n939AgenciaNumero[0];
            A945AgenciaDigito = BC002X3_A945AgenciaDigito[0];
            n945AgenciaDigito = BC002X3_n945AgenciaDigito[0];
            A940AgenciaStatus = BC002X3_A940AgenciaStatus[0];
            n940AgenciaStatus = BC002X3_n940AgenciaStatus[0];
            A936AgenciaCreatedBy = BC002X3_A936AgenciaCreatedBy[0];
            n936AgenciaCreatedBy = BC002X3_n936AgenciaCreatedBy[0];
            A943AgenciaUpdatedBy = BC002X3_A943AgenciaUpdatedBy[0];
            n943AgenciaUpdatedBy = BC002X3_n943AgenciaUpdatedBy[0];
            A968AgenciaBancoId = BC002X3_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC002X3_n968AgenciaBancoId[0];
            Z938AgenciaId = A938AgenciaId;
            sMode101 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2X101( ) ;
            if ( AnyError == 1 )
            {
               RcdFound101 = 0;
               InitializeNonKey2X101( ) ;
            }
            Gx_mode = sMode101;
         }
         else
         {
            RcdFound101 = 0;
            InitializeNonKey2X101( ) ;
            sMode101 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode101;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2X101( ) ;
         if ( RcdFound101 == 0 )
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
         CONFIRM_2X0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2X101( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002X2 */
            pr_default.execute(0, new Object[] {n938AgenciaId, A938AgenciaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Agencia"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z941AgenciaCreatedAt != BC002X2_A941AgenciaCreatedAt[0] ) || ( Z942AgenciaUpdatedAt != BC002X2_A942AgenciaUpdatedAt[0] ) || ( Z939AgenciaNumero != BC002X2_A939AgenciaNumero[0] ) || ( Z945AgenciaDigito != BC002X2_A945AgenciaDigito[0] ) || ( Z940AgenciaStatus != BC002X2_A940AgenciaStatus[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z936AgenciaCreatedBy != BC002X2_A936AgenciaCreatedBy[0] ) || ( Z943AgenciaUpdatedBy != BC002X2_A943AgenciaUpdatedBy[0] ) || ( Z968AgenciaBancoId != BC002X2_A968AgenciaBancoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Agencia"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2X101( )
      {
         BeforeValidate2X101( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2X101( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2X101( 0) ;
            CheckOptimisticConcurrency2X101( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2X101( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2X101( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002X9 */
                     pr_default.execute(7, new Object[] {n941AgenciaCreatedAt, A941AgenciaCreatedAt, n942AgenciaUpdatedAt, A942AgenciaUpdatedAt, n939AgenciaNumero, A939AgenciaNumero, n945AgenciaDigito, A945AgenciaDigito, n940AgenciaStatus, A940AgenciaStatus, n936AgenciaCreatedBy, A936AgenciaCreatedBy, n943AgenciaUpdatedBy, A943AgenciaUpdatedBy, n968AgenciaBancoId, A968AgenciaBancoId});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002X10 */
                     pr_default.execute(8);
                     A938AgenciaId = BC002X10_A938AgenciaId[0];
                     n938AgenciaId = BC002X10_n938AgenciaId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Agencia");
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
               Load2X101( ) ;
            }
            EndLevel2X101( ) ;
         }
         CloseExtendedTableCursors2X101( ) ;
      }

      protected void Update2X101( )
      {
         BeforeValidate2X101( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2X101( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2X101( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2X101( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2X101( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002X11 */
                     pr_default.execute(9, new Object[] {n941AgenciaCreatedAt, A941AgenciaCreatedAt, n942AgenciaUpdatedAt, A942AgenciaUpdatedAt, n939AgenciaNumero, A939AgenciaNumero, n945AgenciaDigito, A945AgenciaDigito, n940AgenciaStatus, A940AgenciaStatus, n936AgenciaCreatedBy, A936AgenciaCreatedBy, n943AgenciaUpdatedBy, A943AgenciaUpdatedBy, n968AgenciaBancoId, A968AgenciaBancoId, n938AgenciaId, A938AgenciaId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Agencia");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Agencia"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2X101( ) ;
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
            EndLevel2X101( ) ;
         }
         CloseExtendedTableCursors2X101( ) ;
      }

      protected void DeferredUpdate2X101( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2X101( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2X101( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2X101( ) ;
            AfterConfirm2X101( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2X101( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002X12 */
                  pr_default.execute(10, new Object[] {n938AgenciaId, A938AgenciaId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Agencia");
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
         sMode101 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2X101( ) ;
         Gx_mode = sMode101;
      }

      protected void OnDeleteControls2X101( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002X13 */
            pr_default.execute(11, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
            A969AgenciaBancoNome = BC002X13_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC002X13_n969AgenciaBancoNome[0];
            A974AgenciaBancoCodigo = BC002X13_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = BC002X13_n974AgenciaBancoCodigo[0];
            pr_default.close(11);
            /* Using cursor BC002X14 */
            pr_default.execute(12, new Object[] {n936AgenciaCreatedBy, A936AgenciaCreatedBy});
            A937AgenciaCreatedByName = BC002X14_A937AgenciaCreatedByName[0];
            n937AgenciaCreatedByName = BC002X14_n937AgenciaCreatedByName[0];
            pr_default.close(12);
            /* Using cursor BC002X15 */
            pr_default.execute(13, new Object[] {n943AgenciaUpdatedBy, A943AgenciaUpdatedBy});
            A944AgenciaUpdatedByName = BC002X15_A944AgenciaUpdatedByName[0];
            n944AgenciaUpdatedByName = BC002X15_n944AgenciaUpdatedByName[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC002X16 */
            pr_default.execute(14, new Object[] {n938AgenciaId, A938AgenciaId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conta Bancaria"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel2X101( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2X101( ) ;
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

      public void ScanKeyStart2X101( )
      {
         /* Scan By routine */
         /* Using cursor BC002X17 */
         pr_default.execute(15, new Object[] {n938AgenciaId, A938AgenciaId});
         RcdFound101 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound101 = 1;
            A938AgenciaId = BC002X17_A938AgenciaId[0];
            n938AgenciaId = BC002X17_n938AgenciaId[0];
            A941AgenciaCreatedAt = BC002X17_A941AgenciaCreatedAt[0];
            n941AgenciaCreatedAt = BC002X17_n941AgenciaCreatedAt[0];
            A942AgenciaUpdatedAt = BC002X17_A942AgenciaUpdatedAt[0];
            n942AgenciaUpdatedAt = BC002X17_n942AgenciaUpdatedAt[0];
            A969AgenciaBancoNome = BC002X17_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC002X17_n969AgenciaBancoNome[0];
            A974AgenciaBancoCodigo = BC002X17_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = BC002X17_n974AgenciaBancoCodigo[0];
            A939AgenciaNumero = BC002X17_A939AgenciaNumero[0];
            n939AgenciaNumero = BC002X17_n939AgenciaNumero[0];
            A945AgenciaDigito = BC002X17_A945AgenciaDigito[0];
            n945AgenciaDigito = BC002X17_n945AgenciaDigito[0];
            A940AgenciaStatus = BC002X17_A940AgenciaStatus[0];
            n940AgenciaStatus = BC002X17_n940AgenciaStatus[0];
            A937AgenciaCreatedByName = BC002X17_A937AgenciaCreatedByName[0];
            n937AgenciaCreatedByName = BC002X17_n937AgenciaCreatedByName[0];
            A944AgenciaUpdatedByName = BC002X17_A944AgenciaUpdatedByName[0];
            n944AgenciaUpdatedByName = BC002X17_n944AgenciaUpdatedByName[0];
            A936AgenciaCreatedBy = BC002X17_A936AgenciaCreatedBy[0];
            n936AgenciaCreatedBy = BC002X17_n936AgenciaCreatedBy[0];
            A943AgenciaUpdatedBy = BC002X17_A943AgenciaUpdatedBy[0];
            n943AgenciaUpdatedBy = BC002X17_n943AgenciaUpdatedBy[0];
            A968AgenciaBancoId = BC002X17_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC002X17_n968AgenciaBancoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2X101( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound101 = 0;
         ScanKeyLoad2X101( ) ;
      }

      protected void ScanKeyLoad2X101( )
      {
         sMode101 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound101 = 1;
            A938AgenciaId = BC002X17_A938AgenciaId[0];
            n938AgenciaId = BC002X17_n938AgenciaId[0];
            A941AgenciaCreatedAt = BC002X17_A941AgenciaCreatedAt[0];
            n941AgenciaCreatedAt = BC002X17_n941AgenciaCreatedAt[0];
            A942AgenciaUpdatedAt = BC002X17_A942AgenciaUpdatedAt[0];
            n942AgenciaUpdatedAt = BC002X17_n942AgenciaUpdatedAt[0];
            A969AgenciaBancoNome = BC002X17_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC002X17_n969AgenciaBancoNome[0];
            A974AgenciaBancoCodigo = BC002X17_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = BC002X17_n974AgenciaBancoCodigo[0];
            A939AgenciaNumero = BC002X17_A939AgenciaNumero[0];
            n939AgenciaNumero = BC002X17_n939AgenciaNumero[0];
            A945AgenciaDigito = BC002X17_A945AgenciaDigito[0];
            n945AgenciaDigito = BC002X17_n945AgenciaDigito[0];
            A940AgenciaStatus = BC002X17_A940AgenciaStatus[0];
            n940AgenciaStatus = BC002X17_n940AgenciaStatus[0];
            A937AgenciaCreatedByName = BC002X17_A937AgenciaCreatedByName[0];
            n937AgenciaCreatedByName = BC002X17_n937AgenciaCreatedByName[0];
            A944AgenciaUpdatedByName = BC002X17_A944AgenciaUpdatedByName[0];
            n944AgenciaUpdatedByName = BC002X17_n944AgenciaUpdatedByName[0];
            A936AgenciaCreatedBy = BC002X17_A936AgenciaCreatedBy[0];
            n936AgenciaCreatedBy = BC002X17_n936AgenciaCreatedBy[0];
            A943AgenciaUpdatedBy = BC002X17_A943AgenciaUpdatedBy[0];
            n943AgenciaUpdatedBy = BC002X17_n943AgenciaUpdatedBy[0];
            A968AgenciaBancoId = BC002X17_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC002X17_n968AgenciaBancoId[0];
         }
         Gx_mode = sMode101;
      }

      protected void ScanKeyEnd2X101( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm2X101( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2X101( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2X101( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2X101( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2X101( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2X101( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2X101( )
      {
      }

      protected void send_integrity_lvl_hashes2X101( )
      {
      }

      protected void AddRow2X101( )
      {
         VarsToRow101( bcAgencia) ;
      }

      protected void ReadRow2X101( )
      {
         RowToVars101( bcAgencia, 1) ;
      }

      protected void InitializeNonKey2X101( )
      {
         A941AgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         n941AgenciaCreatedAt = false;
         A942AgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         n942AgenciaUpdatedAt = false;
         A968AgenciaBancoId = 0;
         n968AgenciaBancoId = false;
         A969AgenciaBancoNome = "";
         n969AgenciaBancoNome = false;
         A974AgenciaBancoCodigo = 0;
         n974AgenciaBancoCodigo = false;
         A939AgenciaNumero = 0;
         n939AgenciaNumero = false;
         A945AgenciaDigito = 0;
         n945AgenciaDigito = false;
         A936AgenciaCreatedBy = 0;
         n936AgenciaCreatedBy = false;
         A937AgenciaCreatedByName = "";
         n937AgenciaCreatedByName = false;
         A943AgenciaUpdatedBy = 0;
         n943AgenciaUpdatedBy = false;
         A944AgenciaUpdatedByName = "";
         n944AgenciaUpdatedByName = false;
         A940AgenciaStatus = true;
         n940AgenciaStatus = false;
         Z941AgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         Z942AgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         Z939AgenciaNumero = 0;
         Z945AgenciaDigito = 0;
         Z940AgenciaStatus = false;
         Z936AgenciaCreatedBy = 0;
         Z943AgenciaUpdatedBy = 0;
         Z968AgenciaBancoId = 0;
      }

      protected void InitAll2X101( )
      {
         A938AgenciaId = 0;
         n938AgenciaId = false;
         InitializeNonKey2X101( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A941AgenciaCreatedAt = i941AgenciaCreatedAt;
         n941AgenciaCreatedAt = false;
         A940AgenciaStatus = i940AgenciaStatus;
         n940AgenciaStatus = false;
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

      public void VarsToRow101( SdtAgencia obj101 )
      {
         obj101.gxTpr_Mode = Gx_mode;
         obj101.gxTpr_Agenciacreatedat = A941AgenciaCreatedAt;
         obj101.gxTpr_Agenciaupdatedat = A942AgenciaUpdatedAt;
         obj101.gxTpr_Agenciabancoid = A968AgenciaBancoId;
         obj101.gxTpr_Agenciabanconome = A969AgenciaBancoNome;
         obj101.gxTpr_Agenciabancocodigo = A974AgenciaBancoCodigo;
         obj101.gxTpr_Agencianumero = A939AgenciaNumero;
         obj101.gxTpr_Agenciadigito = A945AgenciaDigito;
         obj101.gxTpr_Agenciacreatedby = A936AgenciaCreatedBy;
         obj101.gxTpr_Agenciacreatedbyname = A937AgenciaCreatedByName;
         obj101.gxTpr_Agenciaupdatedby = A943AgenciaUpdatedBy;
         obj101.gxTpr_Agenciaupdatedbyname = A944AgenciaUpdatedByName;
         obj101.gxTpr_Agenciastatus = A940AgenciaStatus;
         obj101.gxTpr_Agenciaid = A938AgenciaId;
         obj101.gxTpr_Agenciaid_Z = Z938AgenciaId;
         obj101.gxTpr_Agenciabancoid_Z = Z968AgenciaBancoId;
         obj101.gxTpr_Agenciabanconome_Z = Z969AgenciaBancoNome;
         obj101.gxTpr_Agenciabancocodigo_Z = Z974AgenciaBancoCodigo;
         obj101.gxTpr_Agencianumero_Z = Z939AgenciaNumero;
         obj101.gxTpr_Agenciadigito_Z = Z945AgenciaDigito;
         obj101.gxTpr_Agenciastatus_Z = Z940AgenciaStatus;
         obj101.gxTpr_Agenciacreatedat_Z = Z941AgenciaCreatedAt;
         obj101.gxTpr_Agenciaupdatedat_Z = Z942AgenciaUpdatedAt;
         obj101.gxTpr_Agenciacreatedby_Z = Z936AgenciaCreatedBy;
         obj101.gxTpr_Agenciacreatedbyname_Z = Z937AgenciaCreatedByName;
         obj101.gxTpr_Agenciaupdatedby_Z = Z943AgenciaUpdatedBy;
         obj101.gxTpr_Agenciaupdatedbyname_Z = Z944AgenciaUpdatedByName;
         obj101.gxTpr_Agenciaid_N = (short)(Convert.ToInt16(n938AgenciaId));
         obj101.gxTpr_Agenciabancoid_N = (short)(Convert.ToInt16(n968AgenciaBancoId));
         obj101.gxTpr_Agenciabanconome_N = (short)(Convert.ToInt16(n969AgenciaBancoNome));
         obj101.gxTpr_Agenciabancocodigo_N = (short)(Convert.ToInt16(n974AgenciaBancoCodigo));
         obj101.gxTpr_Agencianumero_N = (short)(Convert.ToInt16(n939AgenciaNumero));
         obj101.gxTpr_Agenciadigito_N = (short)(Convert.ToInt16(n945AgenciaDigito));
         obj101.gxTpr_Agenciastatus_N = (short)(Convert.ToInt16(n940AgenciaStatus));
         obj101.gxTpr_Agenciacreatedat_N = (short)(Convert.ToInt16(n941AgenciaCreatedAt));
         obj101.gxTpr_Agenciaupdatedat_N = (short)(Convert.ToInt16(n942AgenciaUpdatedAt));
         obj101.gxTpr_Agenciacreatedby_N = (short)(Convert.ToInt16(n936AgenciaCreatedBy));
         obj101.gxTpr_Agenciacreatedbyname_N = (short)(Convert.ToInt16(n937AgenciaCreatedByName));
         obj101.gxTpr_Agenciaupdatedby_N = (short)(Convert.ToInt16(n943AgenciaUpdatedBy));
         obj101.gxTpr_Agenciaupdatedbyname_N = (short)(Convert.ToInt16(n944AgenciaUpdatedByName));
         obj101.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow101( SdtAgencia obj101 )
      {
         obj101.gxTpr_Agenciaid = A938AgenciaId;
         return  ;
      }

      public void RowToVars101( SdtAgencia obj101 ,
                                int forceLoad )
      {
         Gx_mode = obj101.gxTpr_Mode;
         A941AgenciaCreatedAt = obj101.gxTpr_Agenciacreatedat;
         n941AgenciaCreatedAt = false;
         A942AgenciaUpdatedAt = obj101.gxTpr_Agenciaupdatedat;
         n942AgenciaUpdatedAt = false;
         A968AgenciaBancoId = obj101.gxTpr_Agenciabancoid;
         n968AgenciaBancoId = false;
         A969AgenciaBancoNome = obj101.gxTpr_Agenciabanconome;
         n969AgenciaBancoNome = false;
         A974AgenciaBancoCodigo = obj101.gxTpr_Agenciabancocodigo;
         n974AgenciaBancoCodigo = false;
         A939AgenciaNumero = obj101.gxTpr_Agencianumero;
         n939AgenciaNumero = false;
         A945AgenciaDigito = obj101.gxTpr_Agenciadigito;
         n945AgenciaDigito = false;
         A936AgenciaCreatedBy = obj101.gxTpr_Agenciacreatedby;
         n936AgenciaCreatedBy = false;
         A937AgenciaCreatedByName = obj101.gxTpr_Agenciacreatedbyname;
         n937AgenciaCreatedByName = false;
         A943AgenciaUpdatedBy = obj101.gxTpr_Agenciaupdatedby;
         n943AgenciaUpdatedBy = false;
         A944AgenciaUpdatedByName = obj101.gxTpr_Agenciaupdatedbyname;
         n944AgenciaUpdatedByName = false;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A940AgenciaStatus = obj101.gxTpr_Agenciastatus;
            n940AgenciaStatus = false;
         }
         A938AgenciaId = obj101.gxTpr_Agenciaid;
         n938AgenciaId = false;
         Z938AgenciaId = obj101.gxTpr_Agenciaid_Z;
         Z968AgenciaBancoId = obj101.gxTpr_Agenciabancoid_Z;
         Z969AgenciaBancoNome = obj101.gxTpr_Agenciabanconome_Z;
         Z974AgenciaBancoCodigo = obj101.gxTpr_Agenciabancocodigo_Z;
         Z939AgenciaNumero = obj101.gxTpr_Agencianumero_Z;
         Z945AgenciaDigito = obj101.gxTpr_Agenciadigito_Z;
         Z940AgenciaStatus = obj101.gxTpr_Agenciastatus_Z;
         Z941AgenciaCreatedAt = obj101.gxTpr_Agenciacreatedat_Z;
         Z942AgenciaUpdatedAt = obj101.gxTpr_Agenciaupdatedat_Z;
         Z936AgenciaCreatedBy = obj101.gxTpr_Agenciacreatedby_Z;
         Z937AgenciaCreatedByName = obj101.gxTpr_Agenciacreatedbyname_Z;
         Z943AgenciaUpdatedBy = obj101.gxTpr_Agenciaupdatedby_Z;
         Z944AgenciaUpdatedByName = obj101.gxTpr_Agenciaupdatedbyname_Z;
         n938AgenciaId = (bool)(Convert.ToBoolean(obj101.gxTpr_Agenciaid_N));
         n968AgenciaBancoId = (bool)(Convert.ToBoolean(obj101.gxTpr_Agenciabancoid_N));
         n969AgenciaBancoNome = (bool)(Convert.ToBoolean(obj101.gxTpr_Agenciabanconome_N));
         n974AgenciaBancoCodigo = (bool)(Convert.ToBoolean(obj101.gxTpr_Agenciabancocodigo_N));
         n939AgenciaNumero = (bool)(Convert.ToBoolean(obj101.gxTpr_Agencianumero_N));
         n945AgenciaDigito = (bool)(Convert.ToBoolean(obj101.gxTpr_Agenciadigito_N));
         n940AgenciaStatus = (bool)(Convert.ToBoolean(obj101.gxTpr_Agenciastatus_N));
         n941AgenciaCreatedAt = (bool)(Convert.ToBoolean(obj101.gxTpr_Agenciacreatedat_N));
         n942AgenciaUpdatedAt = (bool)(Convert.ToBoolean(obj101.gxTpr_Agenciaupdatedat_N));
         n936AgenciaCreatedBy = (bool)(Convert.ToBoolean(obj101.gxTpr_Agenciacreatedby_N));
         n937AgenciaCreatedByName = (bool)(Convert.ToBoolean(obj101.gxTpr_Agenciacreatedbyname_N));
         n943AgenciaUpdatedBy = (bool)(Convert.ToBoolean(obj101.gxTpr_Agenciaupdatedby_N));
         n944AgenciaUpdatedByName = (bool)(Convert.ToBoolean(obj101.gxTpr_Agenciaupdatedbyname_N));
         Gx_mode = obj101.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A938AgenciaId = (int)getParm(obj,0);
         n938AgenciaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2X101( ) ;
         ScanKeyStart2X101( ) ;
         if ( RcdFound101 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z938AgenciaId = A938AgenciaId;
         }
         ZM2X101( -9) ;
         OnLoadActions2X101( ) ;
         AddRow2X101( ) ;
         ScanKeyEnd2X101( ) ;
         if ( RcdFound101 == 0 )
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
         RowToVars101( bcAgencia, 0) ;
         ScanKeyStart2X101( ) ;
         if ( RcdFound101 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z938AgenciaId = A938AgenciaId;
         }
         ZM2X101( -9) ;
         OnLoadActions2X101( ) ;
         AddRow2X101( ) ;
         ScanKeyEnd2X101( ) ;
         if ( RcdFound101 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2X101( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2X101( ) ;
         }
         else
         {
            if ( RcdFound101 == 1 )
            {
               if ( A938AgenciaId != Z938AgenciaId )
               {
                  A938AgenciaId = Z938AgenciaId;
                  n938AgenciaId = false;
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
                  Update2X101( ) ;
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
                  if ( A938AgenciaId != Z938AgenciaId )
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
                        Insert2X101( ) ;
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
                        Insert2X101( ) ;
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
         RowToVars101( bcAgencia, 1) ;
         SaveImpl( ) ;
         VarsToRow101( bcAgencia) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars101( bcAgencia, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2X101( ) ;
         AfterTrn( ) ;
         VarsToRow101( bcAgencia) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow101( bcAgencia) ;
         }
         else
         {
            SdtAgencia auxBC = new SdtAgencia(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A938AgenciaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcAgencia);
               auxBC.Save();
               bcAgencia.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars101( bcAgencia, 1) ;
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
         RowToVars101( bcAgencia, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2X101( ) ;
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
               VarsToRow101( bcAgencia) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow101( bcAgencia) ;
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
         RowToVars101( bcAgencia, 0) ;
         GetKey2X101( ) ;
         if ( RcdFound101 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A938AgenciaId != Z938AgenciaId )
            {
               A938AgenciaId = Z938AgenciaId;
               n938AgenciaId = false;
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
            if ( A938AgenciaId != Z938AgenciaId )
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
         context.RollbackDataStores("agencia_bc",pr_default);
         VarsToRow101( bcAgencia) ;
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
         Gx_mode = bcAgencia.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcAgencia.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcAgencia )
         {
            bcAgencia = (SdtAgencia)(sdt);
            if ( StringUtil.StrCmp(bcAgencia.gxTpr_Mode, "") == 0 )
            {
               bcAgencia.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow101( bcAgencia) ;
            }
            else
            {
               RowToVars101( bcAgencia, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcAgencia.gxTpr_Mode, "") == 0 )
            {
               bcAgencia.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars101( bcAgencia, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtAgencia Agencia_BC
      {
         get {
            return bcAgencia ;
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV26Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z941AgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         A941AgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         Z942AgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         A942AgenciaUpdatedAt = (DateTime)(DateTime.MinValue);
         Z937AgenciaCreatedByName = "";
         A937AgenciaCreatedByName = "";
         Z944AgenciaUpdatedByName = "";
         A944AgenciaUpdatedByName = "";
         Z969AgenciaBancoNome = "";
         A969AgenciaBancoNome = "";
         BC002X7_A938AgenciaId = new int[1] ;
         BC002X7_n938AgenciaId = new bool[] {false} ;
         BC002X7_A941AgenciaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002X7_n941AgenciaCreatedAt = new bool[] {false} ;
         BC002X7_A942AgenciaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002X7_n942AgenciaUpdatedAt = new bool[] {false} ;
         BC002X7_A969AgenciaBancoNome = new string[] {""} ;
         BC002X7_n969AgenciaBancoNome = new bool[] {false} ;
         BC002X7_A974AgenciaBancoCodigo = new int[1] ;
         BC002X7_n974AgenciaBancoCodigo = new bool[] {false} ;
         BC002X7_A939AgenciaNumero = new int[1] ;
         BC002X7_n939AgenciaNumero = new bool[] {false} ;
         BC002X7_A945AgenciaDigito = new int[1] ;
         BC002X7_n945AgenciaDigito = new bool[] {false} ;
         BC002X7_A940AgenciaStatus = new bool[] {false} ;
         BC002X7_n940AgenciaStatus = new bool[] {false} ;
         BC002X7_A937AgenciaCreatedByName = new string[] {""} ;
         BC002X7_n937AgenciaCreatedByName = new bool[] {false} ;
         BC002X7_A944AgenciaUpdatedByName = new string[] {""} ;
         BC002X7_n944AgenciaUpdatedByName = new bool[] {false} ;
         BC002X7_A936AgenciaCreatedBy = new short[1] ;
         BC002X7_n936AgenciaCreatedBy = new bool[] {false} ;
         BC002X7_A943AgenciaUpdatedBy = new short[1] ;
         BC002X7_n943AgenciaUpdatedBy = new bool[] {false} ;
         BC002X7_A968AgenciaBancoId = new int[1] ;
         BC002X7_n968AgenciaBancoId = new bool[] {false} ;
         BC002X6_A969AgenciaBancoNome = new string[] {""} ;
         BC002X6_n969AgenciaBancoNome = new bool[] {false} ;
         BC002X6_A974AgenciaBancoCodigo = new int[1] ;
         BC002X6_n974AgenciaBancoCodigo = new bool[] {false} ;
         BC002X4_A937AgenciaCreatedByName = new string[] {""} ;
         BC002X4_n937AgenciaCreatedByName = new bool[] {false} ;
         BC002X5_A944AgenciaUpdatedByName = new string[] {""} ;
         BC002X5_n944AgenciaUpdatedByName = new bool[] {false} ;
         BC002X8_A938AgenciaId = new int[1] ;
         BC002X8_n938AgenciaId = new bool[] {false} ;
         BC002X3_A938AgenciaId = new int[1] ;
         BC002X3_n938AgenciaId = new bool[] {false} ;
         BC002X3_A941AgenciaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002X3_n941AgenciaCreatedAt = new bool[] {false} ;
         BC002X3_A942AgenciaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002X3_n942AgenciaUpdatedAt = new bool[] {false} ;
         BC002X3_A939AgenciaNumero = new int[1] ;
         BC002X3_n939AgenciaNumero = new bool[] {false} ;
         BC002X3_A945AgenciaDigito = new int[1] ;
         BC002X3_n945AgenciaDigito = new bool[] {false} ;
         BC002X3_A940AgenciaStatus = new bool[] {false} ;
         BC002X3_n940AgenciaStatus = new bool[] {false} ;
         BC002X3_A936AgenciaCreatedBy = new short[1] ;
         BC002X3_n936AgenciaCreatedBy = new bool[] {false} ;
         BC002X3_A943AgenciaUpdatedBy = new short[1] ;
         BC002X3_n943AgenciaUpdatedBy = new bool[] {false} ;
         BC002X3_A968AgenciaBancoId = new int[1] ;
         BC002X3_n968AgenciaBancoId = new bool[] {false} ;
         sMode101 = "";
         BC002X2_A938AgenciaId = new int[1] ;
         BC002X2_n938AgenciaId = new bool[] {false} ;
         BC002X2_A941AgenciaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002X2_n941AgenciaCreatedAt = new bool[] {false} ;
         BC002X2_A942AgenciaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002X2_n942AgenciaUpdatedAt = new bool[] {false} ;
         BC002X2_A939AgenciaNumero = new int[1] ;
         BC002X2_n939AgenciaNumero = new bool[] {false} ;
         BC002X2_A945AgenciaDigito = new int[1] ;
         BC002X2_n945AgenciaDigito = new bool[] {false} ;
         BC002X2_A940AgenciaStatus = new bool[] {false} ;
         BC002X2_n940AgenciaStatus = new bool[] {false} ;
         BC002X2_A936AgenciaCreatedBy = new short[1] ;
         BC002X2_n936AgenciaCreatedBy = new bool[] {false} ;
         BC002X2_A943AgenciaUpdatedBy = new short[1] ;
         BC002X2_n943AgenciaUpdatedBy = new bool[] {false} ;
         BC002X2_A968AgenciaBancoId = new int[1] ;
         BC002X2_n968AgenciaBancoId = new bool[] {false} ;
         BC002X10_A938AgenciaId = new int[1] ;
         BC002X10_n938AgenciaId = new bool[] {false} ;
         BC002X13_A969AgenciaBancoNome = new string[] {""} ;
         BC002X13_n969AgenciaBancoNome = new bool[] {false} ;
         BC002X13_A974AgenciaBancoCodigo = new int[1] ;
         BC002X13_n974AgenciaBancoCodigo = new bool[] {false} ;
         BC002X14_A937AgenciaCreatedByName = new string[] {""} ;
         BC002X14_n937AgenciaCreatedByName = new bool[] {false} ;
         BC002X15_A944AgenciaUpdatedByName = new string[] {""} ;
         BC002X15_n944AgenciaUpdatedByName = new bool[] {false} ;
         BC002X16_A951ContaBancariaId = new int[1] ;
         BC002X17_A938AgenciaId = new int[1] ;
         BC002X17_n938AgenciaId = new bool[] {false} ;
         BC002X17_A941AgenciaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002X17_n941AgenciaCreatedAt = new bool[] {false} ;
         BC002X17_A942AgenciaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002X17_n942AgenciaUpdatedAt = new bool[] {false} ;
         BC002X17_A969AgenciaBancoNome = new string[] {""} ;
         BC002X17_n969AgenciaBancoNome = new bool[] {false} ;
         BC002X17_A974AgenciaBancoCodigo = new int[1] ;
         BC002X17_n974AgenciaBancoCodigo = new bool[] {false} ;
         BC002X17_A939AgenciaNumero = new int[1] ;
         BC002X17_n939AgenciaNumero = new bool[] {false} ;
         BC002X17_A945AgenciaDigito = new int[1] ;
         BC002X17_n945AgenciaDigito = new bool[] {false} ;
         BC002X17_A940AgenciaStatus = new bool[] {false} ;
         BC002X17_n940AgenciaStatus = new bool[] {false} ;
         BC002X17_A937AgenciaCreatedByName = new string[] {""} ;
         BC002X17_n937AgenciaCreatedByName = new bool[] {false} ;
         BC002X17_A944AgenciaUpdatedByName = new string[] {""} ;
         BC002X17_n944AgenciaUpdatedByName = new bool[] {false} ;
         BC002X17_A936AgenciaCreatedBy = new short[1] ;
         BC002X17_n936AgenciaCreatedBy = new bool[] {false} ;
         BC002X17_A943AgenciaUpdatedBy = new short[1] ;
         BC002X17_n943AgenciaUpdatedBy = new bool[] {false} ;
         BC002X17_A968AgenciaBancoId = new int[1] ;
         BC002X17_n968AgenciaBancoId = new bool[] {false} ;
         i941AgenciaCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.agencia_bc__default(),
            new Object[][] {
                new Object[] {
               BC002X2_A938AgenciaId, BC002X2_A941AgenciaCreatedAt, BC002X2_n941AgenciaCreatedAt, BC002X2_A942AgenciaUpdatedAt, BC002X2_n942AgenciaUpdatedAt, BC002X2_A939AgenciaNumero, BC002X2_n939AgenciaNumero, BC002X2_A945AgenciaDigito, BC002X2_n945AgenciaDigito, BC002X2_A940AgenciaStatus,
               BC002X2_n940AgenciaStatus, BC002X2_A936AgenciaCreatedBy, BC002X2_n936AgenciaCreatedBy, BC002X2_A943AgenciaUpdatedBy, BC002X2_n943AgenciaUpdatedBy, BC002X2_A968AgenciaBancoId, BC002X2_n968AgenciaBancoId
               }
               , new Object[] {
               BC002X3_A938AgenciaId, BC002X3_A941AgenciaCreatedAt, BC002X3_n941AgenciaCreatedAt, BC002X3_A942AgenciaUpdatedAt, BC002X3_n942AgenciaUpdatedAt, BC002X3_A939AgenciaNumero, BC002X3_n939AgenciaNumero, BC002X3_A945AgenciaDigito, BC002X3_n945AgenciaDigito, BC002X3_A940AgenciaStatus,
               BC002X3_n940AgenciaStatus, BC002X3_A936AgenciaCreatedBy, BC002X3_n936AgenciaCreatedBy, BC002X3_A943AgenciaUpdatedBy, BC002X3_n943AgenciaUpdatedBy, BC002X3_A968AgenciaBancoId, BC002X3_n968AgenciaBancoId
               }
               , new Object[] {
               BC002X4_A937AgenciaCreatedByName, BC002X4_n937AgenciaCreatedByName
               }
               , new Object[] {
               BC002X5_A944AgenciaUpdatedByName, BC002X5_n944AgenciaUpdatedByName
               }
               , new Object[] {
               BC002X6_A969AgenciaBancoNome, BC002X6_n969AgenciaBancoNome, BC002X6_A974AgenciaBancoCodigo, BC002X6_n974AgenciaBancoCodigo
               }
               , new Object[] {
               BC002X7_A938AgenciaId, BC002X7_A941AgenciaCreatedAt, BC002X7_n941AgenciaCreatedAt, BC002X7_A942AgenciaUpdatedAt, BC002X7_n942AgenciaUpdatedAt, BC002X7_A969AgenciaBancoNome, BC002X7_n969AgenciaBancoNome, BC002X7_A974AgenciaBancoCodigo, BC002X7_n974AgenciaBancoCodigo, BC002X7_A939AgenciaNumero,
               BC002X7_n939AgenciaNumero, BC002X7_A945AgenciaDigito, BC002X7_n945AgenciaDigito, BC002X7_A940AgenciaStatus, BC002X7_n940AgenciaStatus, BC002X7_A937AgenciaCreatedByName, BC002X7_n937AgenciaCreatedByName, BC002X7_A944AgenciaUpdatedByName, BC002X7_n944AgenciaUpdatedByName, BC002X7_A936AgenciaCreatedBy,
               BC002X7_n936AgenciaCreatedBy, BC002X7_A943AgenciaUpdatedBy, BC002X7_n943AgenciaUpdatedBy, BC002X7_A968AgenciaBancoId, BC002X7_n968AgenciaBancoId
               }
               , new Object[] {
               BC002X8_A938AgenciaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002X10_A938AgenciaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002X13_A969AgenciaBancoNome, BC002X13_n969AgenciaBancoNome, BC002X13_A974AgenciaBancoCodigo, BC002X13_n974AgenciaBancoCodigo
               }
               , new Object[] {
               BC002X14_A937AgenciaCreatedByName, BC002X14_n937AgenciaCreatedByName
               }
               , new Object[] {
               BC002X15_A944AgenciaUpdatedByName, BC002X15_n944AgenciaUpdatedByName
               }
               , new Object[] {
               BC002X16_A951ContaBancariaId
               }
               , new Object[] {
               BC002X17_A938AgenciaId, BC002X17_A941AgenciaCreatedAt, BC002X17_n941AgenciaCreatedAt, BC002X17_A942AgenciaUpdatedAt, BC002X17_n942AgenciaUpdatedAt, BC002X17_A969AgenciaBancoNome, BC002X17_n969AgenciaBancoNome, BC002X17_A974AgenciaBancoCodigo, BC002X17_n974AgenciaBancoCodigo, BC002X17_A939AgenciaNumero,
               BC002X17_n939AgenciaNumero, BC002X17_A945AgenciaDigito, BC002X17_n945AgenciaDigito, BC002X17_A940AgenciaStatus, BC002X17_n940AgenciaStatus, BC002X17_A937AgenciaCreatedByName, BC002X17_n937AgenciaCreatedByName, BC002X17_A944AgenciaUpdatedByName, BC002X17_n944AgenciaUpdatedByName, BC002X17_A936AgenciaCreatedBy,
               BC002X17_n936AgenciaCreatedBy, BC002X17_A943AgenciaUpdatedBy, BC002X17_n943AgenciaUpdatedBy, BC002X17_A968AgenciaBancoId, BC002X17_n968AgenciaBancoId
               }
            }
         );
         AV26Pgmname = "Agencia_BC";
         Z940AgenciaStatus = true;
         n940AgenciaStatus = false;
         A940AgenciaStatus = true;
         n940AgenciaStatus = false;
         i940AgenciaStatus = true;
         n940AgenciaStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122X2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV11Insert_AgenciaCreatedBy ;
      private short AV12Insert_AgenciaUpdatedBy ;
      private short Z936AgenciaCreatedBy ;
      private short A936AgenciaCreatedBy ;
      private short Z943AgenciaUpdatedBy ;
      private short A943AgenciaUpdatedBy ;
      private short Gx_BScreen ;
      private short RcdFound101 ;
      private int trnEnded ;
      private int Z938AgenciaId ;
      private int A938AgenciaId ;
      private int AV27GXV1 ;
      private int AV24Insert_AgenciaBancoId ;
      private int Z939AgenciaNumero ;
      private int A939AgenciaNumero ;
      private int Z945AgenciaDigito ;
      private int A945AgenciaDigito ;
      private int Z968AgenciaBancoId ;
      private int A968AgenciaBancoId ;
      private int Z974AgenciaBancoCodigo ;
      private int A974AgenciaBancoCodigo ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV26Pgmname ;
      private string sMode101 ;
      private DateTime Z941AgenciaCreatedAt ;
      private DateTime A941AgenciaCreatedAt ;
      private DateTime Z942AgenciaUpdatedAt ;
      private DateTime A942AgenciaUpdatedAt ;
      private DateTime i941AgenciaCreatedAt ;
      private bool returnInSub ;
      private bool Z940AgenciaStatus ;
      private bool A940AgenciaStatus ;
      private bool n941AgenciaCreatedAt ;
      private bool n942AgenciaUpdatedAt ;
      private bool n940AgenciaStatus ;
      private bool n938AgenciaId ;
      private bool n969AgenciaBancoNome ;
      private bool n974AgenciaBancoCodigo ;
      private bool n939AgenciaNumero ;
      private bool n945AgenciaDigito ;
      private bool n937AgenciaCreatedByName ;
      private bool n944AgenciaUpdatedByName ;
      private bool n936AgenciaCreatedBy ;
      private bool n943AgenciaUpdatedBy ;
      private bool n968AgenciaBancoId ;
      private bool Gx_longc ;
      private bool i940AgenciaStatus ;
      private string Z937AgenciaCreatedByName ;
      private string A937AgenciaCreatedByName ;
      private string Z944AgenciaUpdatedByName ;
      private string A944AgenciaUpdatedByName ;
      private string Z969AgenciaBancoNome ;
      private string A969AgenciaBancoNome ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002X7_A938AgenciaId ;
      private bool[] BC002X7_n938AgenciaId ;
      private DateTime[] BC002X7_A941AgenciaCreatedAt ;
      private bool[] BC002X7_n941AgenciaCreatedAt ;
      private DateTime[] BC002X7_A942AgenciaUpdatedAt ;
      private bool[] BC002X7_n942AgenciaUpdatedAt ;
      private string[] BC002X7_A969AgenciaBancoNome ;
      private bool[] BC002X7_n969AgenciaBancoNome ;
      private int[] BC002X7_A974AgenciaBancoCodigo ;
      private bool[] BC002X7_n974AgenciaBancoCodigo ;
      private int[] BC002X7_A939AgenciaNumero ;
      private bool[] BC002X7_n939AgenciaNumero ;
      private int[] BC002X7_A945AgenciaDigito ;
      private bool[] BC002X7_n945AgenciaDigito ;
      private bool[] BC002X7_A940AgenciaStatus ;
      private bool[] BC002X7_n940AgenciaStatus ;
      private string[] BC002X7_A937AgenciaCreatedByName ;
      private bool[] BC002X7_n937AgenciaCreatedByName ;
      private string[] BC002X7_A944AgenciaUpdatedByName ;
      private bool[] BC002X7_n944AgenciaUpdatedByName ;
      private short[] BC002X7_A936AgenciaCreatedBy ;
      private bool[] BC002X7_n936AgenciaCreatedBy ;
      private short[] BC002X7_A943AgenciaUpdatedBy ;
      private bool[] BC002X7_n943AgenciaUpdatedBy ;
      private int[] BC002X7_A968AgenciaBancoId ;
      private bool[] BC002X7_n968AgenciaBancoId ;
      private string[] BC002X6_A969AgenciaBancoNome ;
      private bool[] BC002X6_n969AgenciaBancoNome ;
      private int[] BC002X6_A974AgenciaBancoCodigo ;
      private bool[] BC002X6_n974AgenciaBancoCodigo ;
      private string[] BC002X4_A937AgenciaCreatedByName ;
      private bool[] BC002X4_n937AgenciaCreatedByName ;
      private string[] BC002X5_A944AgenciaUpdatedByName ;
      private bool[] BC002X5_n944AgenciaUpdatedByName ;
      private int[] BC002X8_A938AgenciaId ;
      private bool[] BC002X8_n938AgenciaId ;
      private int[] BC002X3_A938AgenciaId ;
      private bool[] BC002X3_n938AgenciaId ;
      private DateTime[] BC002X3_A941AgenciaCreatedAt ;
      private bool[] BC002X3_n941AgenciaCreatedAt ;
      private DateTime[] BC002X3_A942AgenciaUpdatedAt ;
      private bool[] BC002X3_n942AgenciaUpdatedAt ;
      private int[] BC002X3_A939AgenciaNumero ;
      private bool[] BC002X3_n939AgenciaNumero ;
      private int[] BC002X3_A945AgenciaDigito ;
      private bool[] BC002X3_n945AgenciaDigito ;
      private bool[] BC002X3_A940AgenciaStatus ;
      private bool[] BC002X3_n940AgenciaStatus ;
      private short[] BC002X3_A936AgenciaCreatedBy ;
      private bool[] BC002X3_n936AgenciaCreatedBy ;
      private short[] BC002X3_A943AgenciaUpdatedBy ;
      private bool[] BC002X3_n943AgenciaUpdatedBy ;
      private int[] BC002X3_A968AgenciaBancoId ;
      private bool[] BC002X3_n968AgenciaBancoId ;
      private int[] BC002X2_A938AgenciaId ;
      private bool[] BC002X2_n938AgenciaId ;
      private DateTime[] BC002X2_A941AgenciaCreatedAt ;
      private bool[] BC002X2_n941AgenciaCreatedAt ;
      private DateTime[] BC002X2_A942AgenciaUpdatedAt ;
      private bool[] BC002X2_n942AgenciaUpdatedAt ;
      private int[] BC002X2_A939AgenciaNumero ;
      private bool[] BC002X2_n939AgenciaNumero ;
      private int[] BC002X2_A945AgenciaDigito ;
      private bool[] BC002X2_n945AgenciaDigito ;
      private bool[] BC002X2_A940AgenciaStatus ;
      private bool[] BC002X2_n940AgenciaStatus ;
      private short[] BC002X2_A936AgenciaCreatedBy ;
      private bool[] BC002X2_n936AgenciaCreatedBy ;
      private short[] BC002X2_A943AgenciaUpdatedBy ;
      private bool[] BC002X2_n943AgenciaUpdatedBy ;
      private int[] BC002X2_A968AgenciaBancoId ;
      private bool[] BC002X2_n968AgenciaBancoId ;
      private int[] BC002X10_A938AgenciaId ;
      private bool[] BC002X10_n938AgenciaId ;
      private string[] BC002X13_A969AgenciaBancoNome ;
      private bool[] BC002X13_n969AgenciaBancoNome ;
      private int[] BC002X13_A974AgenciaBancoCodigo ;
      private bool[] BC002X13_n974AgenciaBancoCodigo ;
      private string[] BC002X14_A937AgenciaCreatedByName ;
      private bool[] BC002X14_n937AgenciaCreatedByName ;
      private string[] BC002X15_A944AgenciaUpdatedByName ;
      private bool[] BC002X15_n944AgenciaUpdatedByName ;
      private int[] BC002X16_A951ContaBancariaId ;
      private int[] BC002X17_A938AgenciaId ;
      private bool[] BC002X17_n938AgenciaId ;
      private DateTime[] BC002X17_A941AgenciaCreatedAt ;
      private bool[] BC002X17_n941AgenciaCreatedAt ;
      private DateTime[] BC002X17_A942AgenciaUpdatedAt ;
      private bool[] BC002X17_n942AgenciaUpdatedAt ;
      private string[] BC002X17_A969AgenciaBancoNome ;
      private bool[] BC002X17_n969AgenciaBancoNome ;
      private int[] BC002X17_A974AgenciaBancoCodigo ;
      private bool[] BC002X17_n974AgenciaBancoCodigo ;
      private int[] BC002X17_A939AgenciaNumero ;
      private bool[] BC002X17_n939AgenciaNumero ;
      private int[] BC002X17_A945AgenciaDigito ;
      private bool[] BC002X17_n945AgenciaDigito ;
      private bool[] BC002X17_A940AgenciaStatus ;
      private bool[] BC002X17_n940AgenciaStatus ;
      private string[] BC002X17_A937AgenciaCreatedByName ;
      private bool[] BC002X17_n937AgenciaCreatedByName ;
      private string[] BC002X17_A944AgenciaUpdatedByName ;
      private bool[] BC002X17_n944AgenciaUpdatedByName ;
      private short[] BC002X17_A936AgenciaCreatedBy ;
      private bool[] BC002X17_n936AgenciaCreatedBy ;
      private short[] BC002X17_A943AgenciaUpdatedBy ;
      private bool[] BC002X17_n943AgenciaUpdatedBy ;
      private int[] BC002X17_A968AgenciaBancoId ;
      private bool[] BC002X17_n968AgenciaBancoId ;
      private SdtAgencia bcAgencia ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class agencia_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
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
          Object[] prmBC002X2;
          prmBC002X2 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002X3;
          prmBC002X3 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002X4;
          prmBC002X4 = new Object[] {
          new ParDef("AgenciaCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002X5;
          prmBC002X5 = new Object[] {
          new ParDef("AgenciaUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002X6;
          prmBC002X6 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002X7;
          prmBC002X7 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002X8;
          prmBC002X8 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002X9;
          prmBC002X9 = new Object[] {
          new ParDef("AgenciaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AgenciaUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AgenciaNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AgenciaDigito",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AgenciaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AgenciaCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AgenciaUpdatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002X10;
          prmBC002X10 = new Object[] {
          };
          Object[] prmBC002X11;
          prmBC002X11 = new Object[] {
          new ParDef("AgenciaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AgenciaUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AgenciaNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AgenciaDigito",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AgenciaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AgenciaCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AgenciaUpdatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002X12;
          prmBC002X12 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002X13;
          prmBC002X13 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002X14;
          prmBC002X14 = new Object[] {
          new ParDef("AgenciaCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002X15;
          prmBC002X15 = new Object[] {
          new ParDef("AgenciaUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002X16;
          prmBC002X16 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002X17;
          prmBC002X17 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC002X2", "SELECT AgenciaId, AgenciaCreatedAt, AgenciaUpdatedAt, AgenciaNumero, AgenciaDigito, AgenciaStatus, AgenciaCreatedBy, AgenciaUpdatedBy, AgenciaBancoId FROM Agencia WHERE AgenciaId = :AgenciaId  FOR UPDATE OF Agencia",true, GxErrorMask.GX_NOMASK, false, this,prmBC002X2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002X3", "SELECT AgenciaId, AgenciaCreatedAt, AgenciaUpdatedAt, AgenciaNumero, AgenciaDigito, AgenciaStatus, AgenciaCreatedBy, AgenciaUpdatedBy, AgenciaBancoId FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002X3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002X4", "SELECT SecUserName AS AgenciaCreatedByName FROM SecUser WHERE SecUserId = :AgenciaCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002X4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002X5", "SELECT SecUserName AS AgenciaUpdatedByName FROM SecUser WHERE SecUserId = :AgenciaUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002X5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002X6", "SELECT BancoNome AS AgenciaBancoNome, BancoCodigo AS AgenciaBancoCodigo FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002X6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002X7", "SELECT TM1.AgenciaId, TM1.AgenciaCreatedAt, TM1.AgenciaUpdatedAt, T2.BancoNome AS AgenciaBancoNome, T2.BancoCodigo AS AgenciaBancoCodigo, TM1.AgenciaNumero, TM1.AgenciaDigito, TM1.AgenciaStatus, T3.SecUserName AS AgenciaCreatedByName, T4.SecUserName AS AgenciaUpdatedByName, TM1.AgenciaCreatedBy AS AgenciaCreatedBy, TM1.AgenciaUpdatedBy AS AgenciaUpdatedBy, TM1.AgenciaBancoId AS AgenciaBancoId FROM (((Agencia TM1 LEFT JOIN Banco T2 ON T2.BancoId = TM1.AgenciaBancoId) LEFT JOIN SecUser T3 ON T3.SecUserId = TM1.AgenciaCreatedBy) LEFT JOIN SecUser T4 ON T4.SecUserId = TM1.AgenciaUpdatedBy) WHERE TM1.AgenciaId = :AgenciaId ORDER BY TM1.AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002X7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002X8", "SELECT AgenciaId FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002X8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002X9", "SAVEPOINT gxupdate;INSERT INTO Agencia(AgenciaCreatedAt, AgenciaUpdatedAt, AgenciaNumero, AgenciaDigito, AgenciaStatus, AgenciaCreatedBy, AgenciaUpdatedBy, AgenciaBancoId) VALUES(:AgenciaCreatedAt, :AgenciaUpdatedAt, :AgenciaNumero, :AgenciaDigito, :AgenciaStatus, :AgenciaCreatedBy, :AgenciaUpdatedBy, :AgenciaBancoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002X9)
             ,new CursorDef("BC002X10", "SELECT currval('AgenciaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002X10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002X11", "SAVEPOINT gxupdate;UPDATE Agencia SET AgenciaCreatedAt=:AgenciaCreatedAt, AgenciaUpdatedAt=:AgenciaUpdatedAt, AgenciaNumero=:AgenciaNumero, AgenciaDigito=:AgenciaDigito, AgenciaStatus=:AgenciaStatus, AgenciaCreatedBy=:AgenciaCreatedBy, AgenciaUpdatedBy=:AgenciaUpdatedBy, AgenciaBancoId=:AgenciaBancoId  WHERE AgenciaId = :AgenciaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002X11)
             ,new CursorDef("BC002X12", "SAVEPOINT gxupdate;DELETE FROM Agencia  WHERE AgenciaId = :AgenciaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002X12)
             ,new CursorDef("BC002X13", "SELECT BancoNome AS AgenciaBancoNome, BancoCodigo AS AgenciaBancoCodigo FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002X13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002X14", "SELECT SecUserName AS AgenciaCreatedByName FROM SecUser WHERE SecUserId = :AgenciaCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002X14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002X15", "SELECT SecUserName AS AgenciaUpdatedByName FROM SecUser WHERE SecUserId = :AgenciaUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002X15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002X16", "SELECT ContaBancariaId FROM ContaBancaria WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002X16,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002X17", "SELECT TM1.AgenciaId, TM1.AgenciaCreatedAt, TM1.AgenciaUpdatedAt, T2.BancoNome AS AgenciaBancoNome, T2.BancoCodigo AS AgenciaBancoCodigo, TM1.AgenciaNumero, TM1.AgenciaDigito, TM1.AgenciaStatus, T3.SecUserName AS AgenciaCreatedByName, T4.SecUserName AS AgenciaUpdatedByName, TM1.AgenciaCreatedBy AS AgenciaCreatedBy, TM1.AgenciaUpdatedBy AS AgenciaUpdatedBy, TM1.AgenciaBancoId AS AgenciaBancoId FROM (((Agencia TM1 LEFT JOIN Banco T2 ON T2.BancoId = TM1.AgenciaBancoId) LEFT JOIN SecUser T3 ON T3.SecUserId = TM1.AgenciaCreatedBy) LEFT JOIN SecUser T4 ON T4.SecUserId = TM1.AgenciaUpdatedBy) WHERE TM1.AgenciaId = :AgenciaId ORDER BY TM1.AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002X17,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((short[]) buf[21])[0] = rslt.getShort(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}
