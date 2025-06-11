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
   public class reembolsoassinaturas_bc : GxSilentTrn, IGxSilentTrn
   {
      public reembolsoassinaturas_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public reembolsoassinaturas_bc( IGxContext context )
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
         ReadRow2B81( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2B81( ) ;
         standaloneModal( ) ;
         AddRow2B81( ) ;
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
            E112B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z631ReembolsoAssinaturasId = A631ReembolsoAssinaturasId;
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

      protected void CONFIRM_2B0( )
      {
         BeforeValidate2B81( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2B81( ) ;
            }
            else
            {
               CheckExtendedTable2B81( ) ;
               if ( AnyError == 0 )
               {
                  ZM2B81( 4) ;
                  ZM2B81( 5) ;
               }
               CloseExtendedTableCursors2B81( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            while ( AV23GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ReembolsoId") == 0 )
               {
                  AV11Insert_ReembolsoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaContratoAssinaturaId") == 0 )
               {
                  AV12Insert_PropostaContratoAssinaturaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV23GXV1 = (int)(AV23GXV1+1);
            }
         }
      }

      protected void E112B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2B81( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z632ReembolsoAssinaturasNome = A632ReembolsoAssinaturasNome;
            Z633ReembolsoAssinaturasEmissao = A633ReembolsoAssinaturasEmissao;
            Z518ReembolsoId = A518ReembolsoId;
            Z572PropostaContratoAssinaturaId = A572PropostaContratoAssinaturaId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z571PropostaAssinatura = A571PropostaAssinatura;
         }
         if ( GX_JID == -3 )
         {
            Z631ReembolsoAssinaturasId = A631ReembolsoAssinaturasId;
            Z632ReembolsoAssinaturasNome = A632ReembolsoAssinaturasNome;
            Z633ReembolsoAssinaturasEmissao = A633ReembolsoAssinaturasEmissao;
            Z518ReembolsoId = A518ReembolsoId;
            Z572PropostaContratoAssinaturaId = A572PropostaContratoAssinaturaId;
            Z571PropostaAssinatura = A571PropostaAssinatura;
         }
      }

      protected void standaloneNotModal( )
      {
         AV22Pgmname = "ReembolsoAssinaturas_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2B81( )
      {
         /* Using cursor BC002B6 */
         pr_default.execute(4, new Object[] {A631ReembolsoAssinaturasId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound81 = 1;
            A632ReembolsoAssinaturasNome = BC002B6_A632ReembolsoAssinaturasNome[0];
            n632ReembolsoAssinaturasNome = BC002B6_n632ReembolsoAssinaturasNome[0];
            A633ReembolsoAssinaturasEmissao = BC002B6_A633ReembolsoAssinaturasEmissao[0];
            n633ReembolsoAssinaturasEmissao = BC002B6_n633ReembolsoAssinaturasEmissao[0];
            A518ReembolsoId = BC002B6_A518ReembolsoId[0];
            n518ReembolsoId = BC002B6_n518ReembolsoId[0];
            A572PropostaContratoAssinaturaId = BC002B6_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = BC002B6_n572PropostaContratoAssinaturaId[0];
            A571PropostaAssinatura = BC002B6_A571PropostaAssinatura[0];
            n571PropostaAssinatura = BC002B6_n571PropostaAssinatura[0];
            ZM2B81( -3) ;
         }
         pr_default.close(4);
         OnLoadActions2B81( ) ;
      }

      protected void OnLoadActions2B81( )
      {
      }

      protected void CheckExtendedTable2B81( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002B4 */
         pr_default.execute(2, new Object[] {n518ReembolsoId, A518ReembolsoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A518ReembolsoId) ) )
            {
               GX_msglist.addItem("Não existe 'Reembolso'.", "ForeignKeyNotFound", 1, "REEMBOLSOID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         /* Using cursor BC002B5 */
         pr_default.execute(3, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A572PropostaContratoAssinaturaId) ) )
            {
               GX_msglist.addItem("Não existe 'PropostaContratoAssinatura'.", "ForeignKeyNotFound", 1, "PROPOSTACONTRATOASSINATURAID");
               AnyError = 1;
            }
         }
         A571PropostaAssinatura = BC002B5_A571PropostaAssinatura[0];
         n571PropostaAssinatura = BC002B5_n571PropostaAssinatura[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2B81( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2B81( )
      {
         /* Using cursor BC002B7 */
         pr_default.execute(5, new Object[] {A631ReembolsoAssinaturasId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound81 = 1;
         }
         else
         {
            RcdFound81 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002B3 */
         pr_default.execute(1, new Object[] {A631ReembolsoAssinaturasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2B81( 3) ;
            RcdFound81 = 1;
            A631ReembolsoAssinaturasId = BC002B3_A631ReembolsoAssinaturasId[0];
            A632ReembolsoAssinaturasNome = BC002B3_A632ReembolsoAssinaturasNome[0];
            n632ReembolsoAssinaturasNome = BC002B3_n632ReembolsoAssinaturasNome[0];
            A633ReembolsoAssinaturasEmissao = BC002B3_A633ReembolsoAssinaturasEmissao[0];
            n633ReembolsoAssinaturasEmissao = BC002B3_n633ReembolsoAssinaturasEmissao[0];
            A518ReembolsoId = BC002B3_A518ReembolsoId[0];
            n518ReembolsoId = BC002B3_n518ReembolsoId[0];
            A572PropostaContratoAssinaturaId = BC002B3_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = BC002B3_n572PropostaContratoAssinaturaId[0];
            Z631ReembolsoAssinaturasId = A631ReembolsoAssinaturasId;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2B81( ) ;
            if ( AnyError == 1 )
            {
               RcdFound81 = 0;
               InitializeNonKey2B81( ) ;
            }
            Gx_mode = sMode81;
         }
         else
         {
            RcdFound81 = 0;
            InitializeNonKey2B81( ) ;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode81;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2B81( ) ;
         if ( RcdFound81 == 0 )
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
         CONFIRM_2B0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2B81( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002B2 */
            pr_default.execute(0, new Object[] {A631ReembolsoAssinaturasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoAssinaturas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z632ReembolsoAssinaturasNome, BC002B2_A632ReembolsoAssinaturasNome[0]) != 0 ) || ( Z633ReembolsoAssinaturasEmissao != BC002B2_A633ReembolsoAssinaturasEmissao[0] ) || ( Z518ReembolsoId != BC002B2_A518ReembolsoId[0] ) || ( Z572PropostaContratoAssinaturaId != BC002B2_A572PropostaContratoAssinaturaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ReembolsoAssinaturas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2B81( )
      {
         BeforeValidate2B81( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2B81( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2B81( 0) ;
            CheckOptimisticConcurrency2B81( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2B81( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2B81( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002B8 */
                     pr_default.execute(6, new Object[] {n632ReembolsoAssinaturasNome, A632ReembolsoAssinaturasNome, n633ReembolsoAssinaturasEmissao, A633ReembolsoAssinaturasEmissao, n518ReembolsoId, A518ReembolsoId, n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002B9 */
                     pr_default.execute(7);
                     A631ReembolsoAssinaturasId = BC002B9_A631ReembolsoAssinaturasId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoAssinaturas");
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
               Load2B81( ) ;
            }
            EndLevel2B81( ) ;
         }
         CloseExtendedTableCursors2B81( ) ;
      }

      protected void Update2B81( )
      {
         BeforeValidate2B81( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2B81( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2B81( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2B81( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2B81( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002B10 */
                     pr_default.execute(8, new Object[] {n632ReembolsoAssinaturasNome, A632ReembolsoAssinaturasNome, n633ReembolsoAssinaturasEmissao, A633ReembolsoAssinaturasEmissao, n518ReembolsoId, A518ReembolsoId, n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId, A631ReembolsoAssinaturasId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("ReembolsoAssinaturas");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ReembolsoAssinaturas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2B81( ) ;
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
            EndLevel2B81( ) ;
         }
         CloseExtendedTableCursors2B81( ) ;
      }

      protected void DeferredUpdate2B81( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2B81( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2B81( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2B81( ) ;
            AfterConfirm2B81( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2B81( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002B11 */
                  pr_default.execute(9, new Object[] {A631ReembolsoAssinaturasId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("ReembolsoAssinaturas");
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
         sMode81 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2B81( ) ;
         Gx_mode = sMode81;
      }

      protected void OnDeleteControls2B81( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002B12 */
            pr_default.execute(10, new Object[] {n572PropostaContratoAssinaturaId, A572PropostaContratoAssinaturaId});
            A571PropostaAssinatura = BC002B12_A571PropostaAssinatura[0];
            n571PropostaAssinatura = BC002B12_n571PropostaAssinatura[0];
            pr_default.close(10);
         }
      }

      protected void EndLevel2B81( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2B81( ) ;
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

      public void ScanKeyStart2B81( )
      {
         /* Scan By routine */
         /* Using cursor BC002B13 */
         pr_default.execute(11, new Object[] {A631ReembolsoAssinaturasId});
         RcdFound81 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound81 = 1;
            A631ReembolsoAssinaturasId = BC002B13_A631ReembolsoAssinaturasId[0];
            A632ReembolsoAssinaturasNome = BC002B13_A632ReembolsoAssinaturasNome[0];
            n632ReembolsoAssinaturasNome = BC002B13_n632ReembolsoAssinaturasNome[0];
            A633ReembolsoAssinaturasEmissao = BC002B13_A633ReembolsoAssinaturasEmissao[0];
            n633ReembolsoAssinaturasEmissao = BC002B13_n633ReembolsoAssinaturasEmissao[0];
            A518ReembolsoId = BC002B13_A518ReembolsoId[0];
            n518ReembolsoId = BC002B13_n518ReembolsoId[0];
            A572PropostaContratoAssinaturaId = BC002B13_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = BC002B13_n572PropostaContratoAssinaturaId[0];
            A571PropostaAssinatura = BC002B13_A571PropostaAssinatura[0];
            n571PropostaAssinatura = BC002B13_n571PropostaAssinatura[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2B81( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound81 = 0;
         ScanKeyLoad2B81( ) ;
      }

      protected void ScanKeyLoad2B81( )
      {
         sMode81 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound81 = 1;
            A631ReembolsoAssinaturasId = BC002B13_A631ReembolsoAssinaturasId[0];
            A632ReembolsoAssinaturasNome = BC002B13_A632ReembolsoAssinaturasNome[0];
            n632ReembolsoAssinaturasNome = BC002B13_n632ReembolsoAssinaturasNome[0];
            A633ReembolsoAssinaturasEmissao = BC002B13_A633ReembolsoAssinaturasEmissao[0];
            n633ReembolsoAssinaturasEmissao = BC002B13_n633ReembolsoAssinaturasEmissao[0];
            A518ReembolsoId = BC002B13_A518ReembolsoId[0];
            n518ReembolsoId = BC002B13_n518ReembolsoId[0];
            A572PropostaContratoAssinaturaId = BC002B13_A572PropostaContratoAssinaturaId[0];
            n572PropostaContratoAssinaturaId = BC002B13_n572PropostaContratoAssinaturaId[0];
            A571PropostaAssinatura = BC002B13_A571PropostaAssinatura[0];
            n571PropostaAssinatura = BC002B13_n571PropostaAssinatura[0];
         }
         Gx_mode = sMode81;
      }

      protected void ScanKeyEnd2B81( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm2B81( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2B81( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2B81( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2B81( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2B81( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2B81( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2B81( )
      {
      }

      protected void send_integrity_lvl_hashes2B81( )
      {
      }

      protected void AddRow2B81( )
      {
         VarsToRow81( bcReembolsoAssinaturas) ;
      }

      protected void ReadRow2B81( )
      {
         RowToVars81( bcReembolsoAssinaturas, 1) ;
      }

      protected void InitializeNonKey2B81( )
      {
         A518ReembolsoId = 0;
         n518ReembolsoId = false;
         A572PropostaContratoAssinaturaId = 0;
         n572PropostaContratoAssinaturaId = false;
         A571PropostaAssinatura = 0;
         n571PropostaAssinatura = false;
         A632ReembolsoAssinaturasNome = "";
         n632ReembolsoAssinaturasNome = false;
         A633ReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         n633ReembolsoAssinaturasEmissao = false;
         Z632ReembolsoAssinaturasNome = "";
         Z633ReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         Z518ReembolsoId = 0;
         Z572PropostaContratoAssinaturaId = 0;
      }

      protected void InitAll2B81( )
      {
         A631ReembolsoAssinaturasId = 0;
         InitializeNonKey2B81( ) ;
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

      public void VarsToRow81( SdtReembolsoAssinaturas obj81 )
      {
         obj81.gxTpr_Mode = Gx_mode;
         obj81.gxTpr_Reembolsoid = A518ReembolsoId;
         obj81.gxTpr_Propostacontratoassinaturaid = A572PropostaContratoAssinaturaId;
         obj81.gxTpr_Propostaassinatura = A571PropostaAssinatura;
         obj81.gxTpr_Reembolsoassinaturasnome = A632ReembolsoAssinaturasNome;
         obj81.gxTpr_Reembolsoassinaturasemissao = A633ReembolsoAssinaturasEmissao;
         obj81.gxTpr_Reembolsoassinaturasid = A631ReembolsoAssinaturasId;
         obj81.gxTpr_Reembolsoassinaturasid_Z = Z631ReembolsoAssinaturasId;
         obj81.gxTpr_Reembolsoid_Z = Z518ReembolsoId;
         obj81.gxTpr_Propostacontratoassinaturaid_Z = Z572PropostaContratoAssinaturaId;
         obj81.gxTpr_Propostaassinatura_Z = Z571PropostaAssinatura;
         obj81.gxTpr_Reembolsoassinaturasnome_Z = Z632ReembolsoAssinaturasNome;
         obj81.gxTpr_Reembolsoassinaturasemissao_Z = Z633ReembolsoAssinaturasEmissao;
         obj81.gxTpr_Reembolsoid_N = (short)(Convert.ToInt16(n518ReembolsoId));
         obj81.gxTpr_Propostacontratoassinaturaid_N = (short)(Convert.ToInt16(n572PropostaContratoAssinaturaId));
         obj81.gxTpr_Propostaassinatura_N = (short)(Convert.ToInt16(n571PropostaAssinatura));
         obj81.gxTpr_Reembolsoassinaturasnome_N = (short)(Convert.ToInt16(n632ReembolsoAssinaturasNome));
         obj81.gxTpr_Reembolsoassinaturasemissao_N = (short)(Convert.ToInt16(n633ReembolsoAssinaturasEmissao));
         obj81.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow81( SdtReembolsoAssinaturas obj81 )
      {
         obj81.gxTpr_Reembolsoassinaturasid = A631ReembolsoAssinaturasId;
         return  ;
      }

      public void RowToVars81( SdtReembolsoAssinaturas obj81 ,
                               int forceLoad )
      {
         Gx_mode = obj81.gxTpr_Mode;
         A518ReembolsoId = obj81.gxTpr_Reembolsoid;
         n518ReembolsoId = false;
         A572PropostaContratoAssinaturaId = obj81.gxTpr_Propostacontratoassinaturaid;
         n572PropostaContratoAssinaturaId = false;
         A571PropostaAssinatura = obj81.gxTpr_Propostaassinatura;
         n571PropostaAssinatura = false;
         A632ReembolsoAssinaturasNome = obj81.gxTpr_Reembolsoassinaturasnome;
         n632ReembolsoAssinaturasNome = false;
         A633ReembolsoAssinaturasEmissao = obj81.gxTpr_Reembolsoassinaturasemissao;
         n633ReembolsoAssinaturasEmissao = false;
         A631ReembolsoAssinaturasId = obj81.gxTpr_Reembolsoassinaturasid;
         Z631ReembolsoAssinaturasId = obj81.gxTpr_Reembolsoassinaturasid_Z;
         Z518ReembolsoId = obj81.gxTpr_Reembolsoid_Z;
         Z572PropostaContratoAssinaturaId = obj81.gxTpr_Propostacontratoassinaturaid_Z;
         Z571PropostaAssinatura = obj81.gxTpr_Propostaassinatura_Z;
         Z632ReembolsoAssinaturasNome = obj81.gxTpr_Reembolsoassinaturasnome_Z;
         Z633ReembolsoAssinaturasEmissao = obj81.gxTpr_Reembolsoassinaturasemissao_Z;
         n518ReembolsoId = (bool)(Convert.ToBoolean(obj81.gxTpr_Reembolsoid_N));
         n572PropostaContratoAssinaturaId = (bool)(Convert.ToBoolean(obj81.gxTpr_Propostacontratoassinaturaid_N));
         n571PropostaAssinatura = (bool)(Convert.ToBoolean(obj81.gxTpr_Propostaassinatura_N));
         n632ReembolsoAssinaturasNome = (bool)(Convert.ToBoolean(obj81.gxTpr_Reembolsoassinaturasnome_N));
         n633ReembolsoAssinaturasEmissao = (bool)(Convert.ToBoolean(obj81.gxTpr_Reembolsoassinaturasemissao_N));
         Gx_mode = obj81.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A631ReembolsoAssinaturasId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2B81( ) ;
         ScanKeyStart2B81( ) ;
         if ( RcdFound81 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z631ReembolsoAssinaturasId = A631ReembolsoAssinaturasId;
         }
         ZM2B81( -3) ;
         OnLoadActions2B81( ) ;
         AddRow2B81( ) ;
         ScanKeyEnd2B81( ) ;
         if ( RcdFound81 == 0 )
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
         RowToVars81( bcReembolsoAssinaturas, 0) ;
         ScanKeyStart2B81( ) ;
         if ( RcdFound81 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z631ReembolsoAssinaturasId = A631ReembolsoAssinaturasId;
         }
         ZM2B81( -3) ;
         OnLoadActions2B81( ) ;
         AddRow2B81( ) ;
         ScanKeyEnd2B81( ) ;
         if ( RcdFound81 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2B81( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2B81( ) ;
         }
         else
         {
            if ( RcdFound81 == 1 )
            {
               if ( A631ReembolsoAssinaturasId != Z631ReembolsoAssinaturasId )
               {
                  A631ReembolsoAssinaturasId = Z631ReembolsoAssinaturasId;
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
                  Update2B81( ) ;
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
                  if ( A631ReembolsoAssinaturasId != Z631ReembolsoAssinaturasId )
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
                        Insert2B81( ) ;
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
                        Insert2B81( ) ;
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
         RowToVars81( bcReembolsoAssinaturas, 1) ;
         SaveImpl( ) ;
         VarsToRow81( bcReembolsoAssinaturas) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars81( bcReembolsoAssinaturas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2B81( ) ;
         AfterTrn( ) ;
         VarsToRow81( bcReembolsoAssinaturas) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow81( bcReembolsoAssinaturas) ;
         }
         else
         {
            SdtReembolsoAssinaturas auxBC = new SdtReembolsoAssinaturas(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A631ReembolsoAssinaturasId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcReembolsoAssinaturas);
               auxBC.Save();
               bcReembolsoAssinaturas.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars81( bcReembolsoAssinaturas, 1) ;
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
         RowToVars81( bcReembolsoAssinaturas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2B81( ) ;
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
               VarsToRow81( bcReembolsoAssinaturas) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow81( bcReembolsoAssinaturas) ;
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
         RowToVars81( bcReembolsoAssinaturas, 0) ;
         GetKey2B81( ) ;
         if ( RcdFound81 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A631ReembolsoAssinaturasId != Z631ReembolsoAssinaturasId )
            {
               A631ReembolsoAssinaturasId = Z631ReembolsoAssinaturasId;
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
            if ( A631ReembolsoAssinaturasId != Z631ReembolsoAssinaturasId )
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
         context.RollbackDataStores("reembolsoassinaturas_bc",pr_default);
         VarsToRow81( bcReembolsoAssinaturas) ;
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
         Gx_mode = bcReembolsoAssinaturas.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcReembolsoAssinaturas.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcReembolsoAssinaturas )
         {
            bcReembolsoAssinaturas = (SdtReembolsoAssinaturas)(sdt);
            if ( StringUtil.StrCmp(bcReembolsoAssinaturas.gxTpr_Mode, "") == 0 )
            {
               bcReembolsoAssinaturas.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow81( bcReembolsoAssinaturas) ;
            }
            else
            {
               RowToVars81( bcReembolsoAssinaturas, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcReembolsoAssinaturas.gxTpr_Mode, "") == 0 )
            {
               bcReembolsoAssinaturas.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars81( bcReembolsoAssinaturas, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtReembolsoAssinaturas ReembolsoAssinaturas_BC
      {
         get {
            return bcReembolsoAssinaturas ;
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
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV22Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z632ReembolsoAssinaturasNome = "";
         A632ReembolsoAssinaturasNome = "";
         Z633ReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         A633ReembolsoAssinaturasEmissao = (DateTime)(DateTime.MinValue);
         BC002B6_A631ReembolsoAssinaturasId = new int[1] ;
         BC002B6_A632ReembolsoAssinaturasNome = new string[] {""} ;
         BC002B6_n632ReembolsoAssinaturasNome = new bool[] {false} ;
         BC002B6_A633ReembolsoAssinaturasEmissao = new DateTime[] {DateTime.MinValue} ;
         BC002B6_n633ReembolsoAssinaturasEmissao = new bool[] {false} ;
         BC002B6_A518ReembolsoId = new int[1] ;
         BC002B6_n518ReembolsoId = new bool[] {false} ;
         BC002B6_A572PropostaContratoAssinaturaId = new int[1] ;
         BC002B6_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         BC002B6_A571PropostaAssinatura = new long[1] ;
         BC002B6_n571PropostaAssinatura = new bool[] {false} ;
         BC002B4_A518ReembolsoId = new int[1] ;
         BC002B4_n518ReembolsoId = new bool[] {false} ;
         BC002B5_A571PropostaAssinatura = new long[1] ;
         BC002B5_n571PropostaAssinatura = new bool[] {false} ;
         BC002B7_A631ReembolsoAssinaturasId = new int[1] ;
         BC002B3_A631ReembolsoAssinaturasId = new int[1] ;
         BC002B3_A632ReembolsoAssinaturasNome = new string[] {""} ;
         BC002B3_n632ReembolsoAssinaturasNome = new bool[] {false} ;
         BC002B3_A633ReembolsoAssinaturasEmissao = new DateTime[] {DateTime.MinValue} ;
         BC002B3_n633ReembolsoAssinaturasEmissao = new bool[] {false} ;
         BC002B3_A518ReembolsoId = new int[1] ;
         BC002B3_n518ReembolsoId = new bool[] {false} ;
         BC002B3_A572PropostaContratoAssinaturaId = new int[1] ;
         BC002B3_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         sMode81 = "";
         BC002B2_A631ReembolsoAssinaturasId = new int[1] ;
         BC002B2_A632ReembolsoAssinaturasNome = new string[] {""} ;
         BC002B2_n632ReembolsoAssinaturasNome = new bool[] {false} ;
         BC002B2_A633ReembolsoAssinaturasEmissao = new DateTime[] {DateTime.MinValue} ;
         BC002B2_n633ReembolsoAssinaturasEmissao = new bool[] {false} ;
         BC002B2_A518ReembolsoId = new int[1] ;
         BC002B2_n518ReembolsoId = new bool[] {false} ;
         BC002B2_A572PropostaContratoAssinaturaId = new int[1] ;
         BC002B2_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         BC002B9_A631ReembolsoAssinaturasId = new int[1] ;
         BC002B12_A571PropostaAssinatura = new long[1] ;
         BC002B12_n571PropostaAssinatura = new bool[] {false} ;
         BC002B13_A631ReembolsoAssinaturasId = new int[1] ;
         BC002B13_A632ReembolsoAssinaturasNome = new string[] {""} ;
         BC002B13_n632ReembolsoAssinaturasNome = new bool[] {false} ;
         BC002B13_A633ReembolsoAssinaturasEmissao = new DateTime[] {DateTime.MinValue} ;
         BC002B13_n633ReembolsoAssinaturasEmissao = new bool[] {false} ;
         BC002B13_A518ReembolsoId = new int[1] ;
         BC002B13_n518ReembolsoId = new bool[] {false} ;
         BC002B13_A572PropostaContratoAssinaturaId = new int[1] ;
         BC002B13_n572PropostaContratoAssinaturaId = new bool[] {false} ;
         BC002B13_A571PropostaAssinatura = new long[1] ;
         BC002B13_n571PropostaAssinatura = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reembolsoassinaturas_bc__default(),
            new Object[][] {
                new Object[] {
               BC002B2_A631ReembolsoAssinaturasId, BC002B2_A632ReembolsoAssinaturasNome, BC002B2_n632ReembolsoAssinaturasNome, BC002B2_A633ReembolsoAssinaturasEmissao, BC002B2_n633ReembolsoAssinaturasEmissao, BC002B2_A518ReembolsoId, BC002B2_n518ReembolsoId, BC002B2_A572PropostaContratoAssinaturaId, BC002B2_n572PropostaContratoAssinaturaId
               }
               , new Object[] {
               BC002B3_A631ReembolsoAssinaturasId, BC002B3_A632ReembolsoAssinaturasNome, BC002B3_n632ReembolsoAssinaturasNome, BC002B3_A633ReembolsoAssinaturasEmissao, BC002B3_n633ReembolsoAssinaturasEmissao, BC002B3_A518ReembolsoId, BC002B3_n518ReembolsoId, BC002B3_A572PropostaContratoAssinaturaId, BC002B3_n572PropostaContratoAssinaturaId
               }
               , new Object[] {
               BC002B4_A518ReembolsoId
               }
               , new Object[] {
               BC002B5_A571PropostaAssinatura, BC002B5_n571PropostaAssinatura
               }
               , new Object[] {
               BC002B6_A631ReembolsoAssinaturasId, BC002B6_A632ReembolsoAssinaturasNome, BC002B6_n632ReembolsoAssinaturasNome, BC002B6_A633ReembolsoAssinaturasEmissao, BC002B6_n633ReembolsoAssinaturasEmissao, BC002B6_A518ReembolsoId, BC002B6_n518ReembolsoId, BC002B6_A572PropostaContratoAssinaturaId, BC002B6_n572PropostaContratoAssinaturaId, BC002B6_A571PropostaAssinatura,
               BC002B6_n571PropostaAssinatura
               }
               , new Object[] {
               BC002B7_A631ReembolsoAssinaturasId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002B9_A631ReembolsoAssinaturasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002B12_A571PropostaAssinatura, BC002B12_n571PropostaAssinatura
               }
               , new Object[] {
               BC002B13_A631ReembolsoAssinaturasId, BC002B13_A632ReembolsoAssinaturasNome, BC002B13_n632ReembolsoAssinaturasNome, BC002B13_A633ReembolsoAssinaturasEmissao, BC002B13_n633ReembolsoAssinaturasEmissao, BC002B13_A518ReembolsoId, BC002B13_n518ReembolsoId, BC002B13_A572PropostaContratoAssinaturaId, BC002B13_n572PropostaContratoAssinaturaId, BC002B13_A571PropostaAssinatura,
               BC002B13_n571PropostaAssinatura
               }
            }
         );
         AV22Pgmname = "ReembolsoAssinaturas_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122B2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound81 ;
      private int trnEnded ;
      private int Z631ReembolsoAssinaturasId ;
      private int A631ReembolsoAssinaturasId ;
      private int AV23GXV1 ;
      private int AV11Insert_ReembolsoId ;
      private int AV12Insert_PropostaContratoAssinaturaId ;
      private int Z518ReembolsoId ;
      private int A518ReembolsoId ;
      private int Z572PropostaContratoAssinaturaId ;
      private int A572PropostaContratoAssinaturaId ;
      private long Z571PropostaAssinatura ;
      private long A571PropostaAssinatura ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV22Pgmname ;
      private string sMode81 ;
      private DateTime Z633ReembolsoAssinaturasEmissao ;
      private DateTime A633ReembolsoAssinaturasEmissao ;
      private bool returnInSub ;
      private bool n632ReembolsoAssinaturasNome ;
      private bool n633ReembolsoAssinaturasEmissao ;
      private bool n518ReembolsoId ;
      private bool n572PropostaContratoAssinaturaId ;
      private bool n571PropostaAssinatura ;
      private string Z632ReembolsoAssinaturasNome ;
      private string A632ReembolsoAssinaturasNome ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002B6_A631ReembolsoAssinaturasId ;
      private string[] BC002B6_A632ReembolsoAssinaturasNome ;
      private bool[] BC002B6_n632ReembolsoAssinaturasNome ;
      private DateTime[] BC002B6_A633ReembolsoAssinaturasEmissao ;
      private bool[] BC002B6_n633ReembolsoAssinaturasEmissao ;
      private int[] BC002B6_A518ReembolsoId ;
      private bool[] BC002B6_n518ReembolsoId ;
      private int[] BC002B6_A572PropostaContratoAssinaturaId ;
      private bool[] BC002B6_n572PropostaContratoAssinaturaId ;
      private long[] BC002B6_A571PropostaAssinatura ;
      private bool[] BC002B6_n571PropostaAssinatura ;
      private int[] BC002B4_A518ReembolsoId ;
      private bool[] BC002B4_n518ReembolsoId ;
      private long[] BC002B5_A571PropostaAssinatura ;
      private bool[] BC002B5_n571PropostaAssinatura ;
      private int[] BC002B7_A631ReembolsoAssinaturasId ;
      private int[] BC002B3_A631ReembolsoAssinaturasId ;
      private string[] BC002B3_A632ReembolsoAssinaturasNome ;
      private bool[] BC002B3_n632ReembolsoAssinaturasNome ;
      private DateTime[] BC002B3_A633ReembolsoAssinaturasEmissao ;
      private bool[] BC002B3_n633ReembolsoAssinaturasEmissao ;
      private int[] BC002B3_A518ReembolsoId ;
      private bool[] BC002B3_n518ReembolsoId ;
      private int[] BC002B3_A572PropostaContratoAssinaturaId ;
      private bool[] BC002B3_n572PropostaContratoAssinaturaId ;
      private int[] BC002B2_A631ReembolsoAssinaturasId ;
      private string[] BC002B2_A632ReembolsoAssinaturasNome ;
      private bool[] BC002B2_n632ReembolsoAssinaturasNome ;
      private DateTime[] BC002B2_A633ReembolsoAssinaturasEmissao ;
      private bool[] BC002B2_n633ReembolsoAssinaturasEmissao ;
      private int[] BC002B2_A518ReembolsoId ;
      private bool[] BC002B2_n518ReembolsoId ;
      private int[] BC002B2_A572PropostaContratoAssinaturaId ;
      private bool[] BC002B2_n572PropostaContratoAssinaturaId ;
      private int[] BC002B9_A631ReembolsoAssinaturasId ;
      private long[] BC002B12_A571PropostaAssinatura ;
      private bool[] BC002B12_n571PropostaAssinatura ;
      private int[] BC002B13_A631ReembolsoAssinaturasId ;
      private string[] BC002B13_A632ReembolsoAssinaturasNome ;
      private bool[] BC002B13_n632ReembolsoAssinaturasNome ;
      private DateTime[] BC002B13_A633ReembolsoAssinaturasEmissao ;
      private bool[] BC002B13_n633ReembolsoAssinaturasEmissao ;
      private int[] BC002B13_A518ReembolsoId ;
      private bool[] BC002B13_n518ReembolsoId ;
      private int[] BC002B13_A572PropostaContratoAssinaturaId ;
      private bool[] BC002B13_n572PropostaContratoAssinaturaId ;
      private long[] BC002B13_A571PropostaAssinatura ;
      private bool[] BC002B13_n571PropostaAssinatura ;
      private SdtReembolsoAssinaturas bcReembolsoAssinaturas ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class reembolsoassinaturas_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002B2;
          prmBC002B2 = new Object[] {
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmBC002B3;
          prmBC002B3 = new Object[] {
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmBC002B4;
          prmBC002B4 = new Object[] {
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002B5;
          prmBC002B5 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002B6;
          prmBC002B6 = new Object[] {
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmBC002B7;
          prmBC002B7 = new Object[] {
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmBC002B8;
          prmBC002B8 = new Object[] {
          new ParDef("ReembolsoAssinaturasNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ReembolsoAssinaturasEmissao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002B9;
          prmBC002B9 = new Object[] {
          };
          Object[] prmBC002B10;
          prmBC002B10 = new Object[] {
          new ParDef("ReembolsoAssinaturasNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ReembolsoAssinaturasEmissao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ReembolsoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmBC002B11;
          prmBC002B11 = new Object[] {
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          Object[] prmBC002B12;
          prmBC002B12 = new Object[] {
          new ParDef("PropostaContratoAssinaturaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002B13;
          prmBC002B13 = new Object[] {
          new ParDef("ReembolsoAssinaturasId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002B2", "SELECT ReembolsoAssinaturasId, ReembolsoAssinaturasNome, ReembolsoAssinaturasEmissao, ReembolsoId, PropostaContratoAssinaturaId FROM ReembolsoAssinaturas WHERE ReembolsoAssinaturasId = :ReembolsoAssinaturasId  FOR UPDATE OF ReembolsoAssinaturas",true, GxErrorMask.GX_NOMASK, false, this,prmBC002B2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002B3", "SELECT ReembolsoAssinaturasId, ReembolsoAssinaturasNome, ReembolsoAssinaturasEmissao, ReembolsoId, PropostaContratoAssinaturaId FROM ReembolsoAssinaturas WHERE ReembolsoAssinaturasId = :ReembolsoAssinaturasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002B3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002B4", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoId = :ReembolsoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002B4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002B5", "SELECT PropostaAssinatura FROM PropostaContratoAssinatura WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002B5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002B6", "SELECT TM1.ReembolsoAssinaturasId, TM1.ReembolsoAssinaturasNome, TM1.ReembolsoAssinaturasEmissao, TM1.ReembolsoId, TM1.PropostaContratoAssinaturaId, T2.PropostaAssinatura FROM (ReembolsoAssinaturas TM1 LEFT JOIN PropostaContratoAssinatura T2 ON T2.PropostaContratoAssinaturaId = TM1.PropostaContratoAssinaturaId) WHERE TM1.ReembolsoAssinaturasId = :ReembolsoAssinaturasId ORDER BY TM1.ReembolsoAssinaturasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002B6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002B7", "SELECT ReembolsoAssinaturasId FROM ReembolsoAssinaturas WHERE ReembolsoAssinaturasId = :ReembolsoAssinaturasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002B7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002B8", "SAVEPOINT gxupdate;INSERT INTO ReembolsoAssinaturas(ReembolsoAssinaturasNome, ReembolsoAssinaturasEmissao, ReembolsoId, PropostaContratoAssinaturaId) VALUES(:ReembolsoAssinaturasNome, :ReembolsoAssinaturasEmissao, :ReembolsoId, :PropostaContratoAssinaturaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002B8)
             ,new CursorDef("BC002B9", "SELECT currval('ReembolsoAssinaturasId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002B9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002B10", "SAVEPOINT gxupdate;UPDATE ReembolsoAssinaturas SET ReembolsoAssinaturasNome=:ReembolsoAssinaturasNome, ReembolsoAssinaturasEmissao=:ReembolsoAssinaturasEmissao, ReembolsoId=:ReembolsoId, PropostaContratoAssinaturaId=:PropostaContratoAssinaturaId  WHERE ReembolsoAssinaturasId = :ReembolsoAssinaturasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002B10)
             ,new CursorDef("BC002B11", "SAVEPOINT gxupdate;DELETE FROM ReembolsoAssinaturas  WHERE ReembolsoAssinaturasId = :ReembolsoAssinaturasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002B11)
             ,new CursorDef("BC002B12", "SELECT PropostaAssinatura FROM PropostaContratoAssinatura WHERE PropostaContratoAssinaturaId = :PropostaContratoAssinaturaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002B12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002B13", "SELECT TM1.ReembolsoAssinaturasId, TM1.ReembolsoAssinaturasNome, TM1.ReembolsoAssinaturasEmissao, TM1.ReembolsoId, TM1.PropostaContratoAssinaturaId, T2.PropostaAssinatura FROM (ReembolsoAssinaturas TM1 LEFT JOIN PropostaContratoAssinatura T2 ON T2.PropostaContratoAssinaturaId = TM1.PropostaContratoAssinaturaId) WHERE TM1.ReembolsoAssinaturasId = :ReembolsoAssinaturasId ORDER BY TM1.ReembolsoAssinaturasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002B13,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
