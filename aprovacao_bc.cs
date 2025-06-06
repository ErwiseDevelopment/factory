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
   public class aprovacao_bc : GxSilentTrn, IGxSilentTrn
   {
      public aprovacao_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprovacao_bc( IGxContext context )
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
         ReadRow1C51( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1C51( ) ;
         standaloneModal( ) ;
         AddRow1C51( ) ;
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
            E111C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z336AprovacaoId = A336AprovacaoId;
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

      protected void CONFIRM_1C0( )
      {
         BeforeValidate1C51( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1C51( ) ;
            }
            else
            {
               CheckExtendedTable1C51( ) ;
               if ( AnyError == 0 )
               {
                  ZM1C51( 7) ;
                  ZM1C51( 8) ;
                  ZM1C51( 9) ;
                  ZM1C51( 10) ;
               }
               CloseExtendedTableCursors1C51( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121C2( )
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
               AV13TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "AprovadoresId") == 0 )
               {
                  AV11Insert_AprovadoresId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaId") == 0 )
               {
                  AV12Insert_PropostaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV23GXV1 = (int)(AV23GXV1+1);
            }
         }
      }

      protected void E111C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1C51( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z337AprovacaoEm = A337AprovacaoEm;
            Z338AprovacaoDecisao = A338AprovacaoDecisao;
            Z340AprovacaoStatus = A340AprovacaoStatus;
            Z323PropostaId = A323PropostaId;
            Z375AprovadoresId = A375AprovadoresId;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z328PropostaCratedBy = A328PropostaCratedBy;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z133SecUserId = A133SecUserId;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z141SecUserName = A141SecUserName;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z143SecUserFullName = A143SecUserFullName;
         }
         if ( GX_JID == -6 )
         {
            Z336AprovacaoId = A336AprovacaoId;
            Z337AprovacaoEm = A337AprovacaoEm;
            Z338AprovacaoDecisao = A338AprovacaoDecisao;
            Z340AprovacaoStatus = A340AprovacaoStatus;
            Z323PropostaId = A323PropostaId;
            Z375AprovadoresId = A375AprovadoresId;
            Z133SecUserId = A133SecUserId;
            Z143SecUserFullName = A143SecUserFullName;
            Z328PropostaCratedBy = A328PropostaCratedBy;
            Z141SecUserName = A141SecUserName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV22Pgmname = "Aprovacao_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1C51( )
      {
         /* Using cursor BC001C8 */
         pr_default.execute(6, new Object[] {A336AprovacaoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound51 = 1;
            A328PropostaCratedBy = BC001C8_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC001C8_n328PropostaCratedBy[0];
            A133SecUserId = BC001C8_A133SecUserId[0];
            n133SecUserId = BC001C8_n133SecUserId[0];
            A141SecUserName = BC001C8_A141SecUserName[0];
            n141SecUserName = BC001C8_n141SecUserName[0];
            A143SecUserFullName = BC001C8_A143SecUserFullName[0];
            n143SecUserFullName = BC001C8_n143SecUserFullName[0];
            A337AprovacaoEm = BC001C8_A337AprovacaoEm[0];
            n337AprovacaoEm = BC001C8_n337AprovacaoEm[0];
            A338AprovacaoDecisao = BC001C8_A338AprovacaoDecisao[0];
            n338AprovacaoDecisao = BC001C8_n338AprovacaoDecisao[0];
            A340AprovacaoStatus = BC001C8_A340AprovacaoStatus[0];
            n340AprovacaoStatus = BC001C8_n340AprovacaoStatus[0];
            A323PropostaId = BC001C8_A323PropostaId[0];
            n323PropostaId = BC001C8_n323PropostaId[0];
            A375AprovadoresId = BC001C8_A375AprovadoresId[0];
            n375AprovadoresId = BC001C8_n375AprovadoresId[0];
            ZM1C51( -6) ;
         }
         pr_default.close(6);
         OnLoadActions1C51( ) ;
      }

      protected void OnLoadActions1C51( )
      {
         if ( (0==A375AprovadoresId) )
         {
            A375AprovadoresId = 0;
            n375AprovadoresId = false;
            n375AprovadoresId = true;
            n375AprovadoresId = true;
         }
         if ( (0==A323PropostaId) )
         {
            A323PropostaId = 0;
            n323PropostaId = false;
            n323PropostaId = true;
            n323PropostaId = true;
         }
      }

      protected void CheckExtendedTable1C51( )
      {
         standaloneModal( ) ;
         if ( (0==A375AprovadoresId) )
         {
            A375AprovadoresId = 0;
            n375AprovadoresId = false;
            n375AprovadoresId = true;
            n375AprovadoresId = true;
         }
         /* Using cursor BC001C5 */
         pr_default.execute(3, new Object[] {n375AprovadoresId, A375AprovadoresId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A375AprovadoresId) ) )
            {
               GX_msglist.addItem("N�o existe ''.", "ForeignKeyNotFound", 1, "APROVADORESID");
               AnyError = 1;
            }
         }
         A133SecUserId = BC001C5_A133SecUserId[0];
         n133SecUserId = BC001C5_n133SecUserId[0];
         pr_default.close(3);
         /* Using cursor BC001C7 */
         pr_default.execute(5, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("N�o existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
            }
         }
         A143SecUserFullName = BC001C7_A143SecUserFullName[0];
         n143SecUserFullName = BC001C7_n143SecUserFullName[0];
         pr_default.close(5);
         if ( (0==A323PropostaId) )
         {
            A323PropostaId = 0;
            n323PropostaId = false;
            n323PropostaId = true;
            n323PropostaId = true;
         }
         /* Using cursor BC001C4 */
         pr_default.execute(2, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A323PropostaId) ) )
            {
               GX_msglist.addItem("N�o existe 'Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTAID");
               AnyError = 1;
            }
         }
         A328PropostaCratedBy = BC001C4_A328PropostaCratedBy[0];
         n328PropostaCratedBy = BC001C4_n328PropostaCratedBy[0];
         pr_default.close(2);
         /* Using cursor BC001C6 */
         pr_default.execute(4, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A328PropostaCratedBy) ) )
            {
               GX_msglist.addItem("N�o existe 'Sec User Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTACRATEDBY");
               AnyError = 1;
            }
         }
         A141SecUserName = BC001C6_A141SecUserName[0];
         n141SecUserName = BC001C6_n141SecUserName[0];
         pr_default.close(4);
         if ( ! ( ( StringUtil.StrCmp(A340AprovacaoStatus, "APROVADO") == 0 ) || ( StringUtil.StrCmp(A340AprovacaoStatus, "REPROVADO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A340AprovacaoStatus)) ) )
         {
            GX_msglist.addItem("Campo Aprovacao Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1C51( )
      {
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(2);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1C51( )
      {
         /* Using cursor BC001C9 */
         pr_default.execute(7, new Object[] {A336AprovacaoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound51 = 1;
         }
         else
         {
            RcdFound51 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001C3 */
         pr_default.execute(1, new Object[] {A336AprovacaoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1C51( 6) ;
            RcdFound51 = 1;
            A336AprovacaoId = BC001C3_A336AprovacaoId[0];
            A337AprovacaoEm = BC001C3_A337AprovacaoEm[0];
            n337AprovacaoEm = BC001C3_n337AprovacaoEm[0];
            A338AprovacaoDecisao = BC001C3_A338AprovacaoDecisao[0];
            n338AprovacaoDecisao = BC001C3_n338AprovacaoDecisao[0];
            A340AprovacaoStatus = BC001C3_A340AprovacaoStatus[0];
            n340AprovacaoStatus = BC001C3_n340AprovacaoStatus[0];
            A323PropostaId = BC001C3_A323PropostaId[0];
            n323PropostaId = BC001C3_n323PropostaId[0];
            A375AprovadoresId = BC001C3_A375AprovadoresId[0];
            n375AprovadoresId = BC001C3_n375AprovadoresId[0];
            Z336AprovacaoId = A336AprovacaoId;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1C51( ) ;
            if ( AnyError == 1 )
            {
               RcdFound51 = 0;
               InitializeNonKey1C51( ) ;
            }
            Gx_mode = sMode51;
         }
         else
         {
            RcdFound51 = 0;
            InitializeNonKey1C51( ) ;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode51;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1C51( ) ;
         if ( RcdFound51 == 0 )
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
         CONFIRM_1C0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1C51( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001C2 */
            pr_default.execute(0, new Object[] {A336AprovacaoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Aprovacao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z337AprovacaoEm != BC001C2_A337AprovacaoEm[0] ) || ( StringUtil.StrCmp(Z338AprovacaoDecisao, BC001C2_A338AprovacaoDecisao[0]) != 0 ) || ( StringUtil.StrCmp(Z340AprovacaoStatus, BC001C2_A340AprovacaoStatus[0]) != 0 ) || ( Z323PropostaId != BC001C2_A323PropostaId[0] ) || ( Z375AprovadoresId != BC001C2_A375AprovadoresId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Aprovacao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1C51( )
      {
         BeforeValidate1C51( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C51( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1C51( 0) ;
            CheckOptimisticConcurrency1C51( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C51( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1C51( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001C10 */
                     pr_default.execute(8, new Object[] {n337AprovacaoEm, A337AprovacaoEm, n338AprovacaoDecisao, A338AprovacaoDecisao, n340AprovacaoStatus, A340AprovacaoStatus, n323PropostaId, A323PropostaId, n375AprovadoresId, A375AprovadoresId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001C11 */
                     pr_default.execute(9);
                     A336AprovacaoId = BC001C11_A336AprovacaoId[0];
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Aprovacao");
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
               Load1C51( ) ;
            }
            EndLevel1C51( ) ;
         }
         CloseExtendedTableCursors1C51( ) ;
      }

      protected void Update1C51( )
      {
         BeforeValidate1C51( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C51( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C51( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C51( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1C51( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001C12 */
                     pr_default.execute(10, new Object[] {n337AprovacaoEm, A337AprovacaoEm, n338AprovacaoDecisao, A338AprovacaoDecisao, n340AprovacaoStatus, A340AprovacaoStatus, n323PropostaId, A323PropostaId, n375AprovadoresId, A375AprovadoresId, A336AprovacaoId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Aprovacao");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Aprovacao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1C51( ) ;
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
            EndLevel1C51( ) ;
         }
         CloseExtendedTableCursors1C51( ) ;
      }

      protected void DeferredUpdate1C51( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1C51( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C51( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1C51( ) ;
            AfterConfirm1C51( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1C51( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001C13 */
                  pr_default.execute(11, new Object[] {A336AprovacaoId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Aprovacao");
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
         sMode51 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1C51( ) ;
         Gx_mode = sMode51;
      }

      protected void OnDeleteControls1C51( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001C14 */
            pr_default.execute(12, new Object[] {n375AprovadoresId, A375AprovadoresId});
            A133SecUserId = BC001C14_A133SecUserId[0];
            n133SecUserId = BC001C14_n133SecUserId[0];
            pr_default.close(12);
            /* Using cursor BC001C15 */
            pr_default.execute(13, new Object[] {n133SecUserId, A133SecUserId});
            A143SecUserFullName = BC001C15_A143SecUserFullName[0];
            n143SecUserFullName = BC001C15_n143SecUserFullName[0];
            pr_default.close(13);
            /* Using cursor BC001C16 */
            pr_default.execute(14, new Object[] {n323PropostaId, A323PropostaId});
            A328PropostaCratedBy = BC001C16_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC001C16_n328PropostaCratedBy[0];
            pr_default.close(14);
            /* Using cursor BC001C17 */
            pr_default.execute(15, new Object[] {n328PropostaCratedBy, A328PropostaCratedBy});
            A141SecUserName = BC001C17_A141SecUserName[0];
            n141SecUserName = BC001C17_n141SecUserName[0];
            pr_default.close(15);
         }
      }

      protected void EndLevel1C51( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1C51( ) ;
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

      public void ScanKeyStart1C51( )
      {
         /* Scan By routine */
         /* Using cursor BC001C18 */
         pr_default.execute(16, new Object[] {A336AprovacaoId});
         RcdFound51 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound51 = 1;
            A328PropostaCratedBy = BC001C18_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC001C18_n328PropostaCratedBy[0];
            A133SecUserId = BC001C18_A133SecUserId[0];
            n133SecUserId = BC001C18_n133SecUserId[0];
            A336AprovacaoId = BC001C18_A336AprovacaoId[0];
            A141SecUserName = BC001C18_A141SecUserName[0];
            n141SecUserName = BC001C18_n141SecUserName[0];
            A143SecUserFullName = BC001C18_A143SecUserFullName[0];
            n143SecUserFullName = BC001C18_n143SecUserFullName[0];
            A337AprovacaoEm = BC001C18_A337AprovacaoEm[0];
            n337AprovacaoEm = BC001C18_n337AprovacaoEm[0];
            A338AprovacaoDecisao = BC001C18_A338AprovacaoDecisao[0];
            n338AprovacaoDecisao = BC001C18_n338AprovacaoDecisao[0];
            A340AprovacaoStatus = BC001C18_A340AprovacaoStatus[0];
            n340AprovacaoStatus = BC001C18_n340AprovacaoStatus[0];
            A323PropostaId = BC001C18_A323PropostaId[0];
            n323PropostaId = BC001C18_n323PropostaId[0];
            A375AprovadoresId = BC001C18_A375AprovadoresId[0];
            n375AprovadoresId = BC001C18_n375AprovadoresId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1C51( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound51 = 0;
         ScanKeyLoad1C51( ) ;
      }

      protected void ScanKeyLoad1C51( )
      {
         sMode51 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound51 = 1;
            A328PropostaCratedBy = BC001C18_A328PropostaCratedBy[0];
            n328PropostaCratedBy = BC001C18_n328PropostaCratedBy[0];
            A133SecUserId = BC001C18_A133SecUserId[0];
            n133SecUserId = BC001C18_n133SecUserId[0];
            A336AprovacaoId = BC001C18_A336AprovacaoId[0];
            A141SecUserName = BC001C18_A141SecUserName[0];
            n141SecUserName = BC001C18_n141SecUserName[0];
            A143SecUserFullName = BC001C18_A143SecUserFullName[0];
            n143SecUserFullName = BC001C18_n143SecUserFullName[0];
            A337AprovacaoEm = BC001C18_A337AprovacaoEm[0];
            n337AprovacaoEm = BC001C18_n337AprovacaoEm[0];
            A338AprovacaoDecisao = BC001C18_A338AprovacaoDecisao[0];
            n338AprovacaoDecisao = BC001C18_n338AprovacaoDecisao[0];
            A340AprovacaoStatus = BC001C18_A340AprovacaoStatus[0];
            n340AprovacaoStatus = BC001C18_n340AprovacaoStatus[0];
            A323PropostaId = BC001C18_A323PropostaId[0];
            n323PropostaId = BC001C18_n323PropostaId[0];
            A375AprovadoresId = BC001C18_A375AprovadoresId[0];
            n375AprovadoresId = BC001C18_n375AprovadoresId[0];
         }
         Gx_mode = sMode51;
      }

      protected void ScanKeyEnd1C51( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm1C51( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1C51( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1C51( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1C51( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1C51( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1C51( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1C51( )
      {
      }

      protected void send_integrity_lvl_hashes1C51( )
      {
      }

      protected void AddRow1C51( )
      {
         VarsToRow51( bcAprovacao) ;
      }

      protected void ReadRow1C51( )
      {
         RowToVars51( bcAprovacao, 1) ;
      }

      protected void InitializeNonKey1C51( )
      {
         A133SecUserId = 0;
         n133SecUserId = false;
         A328PropostaCratedBy = 0;
         n328PropostaCratedBy = false;
         A375AprovadoresId = 0;
         n375AprovadoresId = false;
         A323PropostaId = 0;
         n323PropostaId = false;
         A141SecUserName = "";
         n141SecUserName = false;
         A143SecUserFullName = "";
         n143SecUserFullName = false;
         A337AprovacaoEm = (DateTime)(DateTime.MinValue);
         n337AprovacaoEm = false;
         A338AprovacaoDecisao = "";
         n338AprovacaoDecisao = false;
         A340AprovacaoStatus = "";
         n340AprovacaoStatus = false;
         Z337AprovacaoEm = (DateTime)(DateTime.MinValue);
         Z338AprovacaoDecisao = "";
         Z340AprovacaoStatus = "";
         Z323PropostaId = 0;
         Z375AprovadoresId = 0;
      }

      protected void InitAll1C51( )
      {
         A336AprovacaoId = 0;
         InitializeNonKey1C51( ) ;
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

      public void VarsToRow51( SdtAprovacao obj51 )
      {
         obj51.gxTpr_Mode = Gx_mode;
         obj51.gxTpr_Aprovadoresid = A375AprovadoresId;
         obj51.gxTpr_Propostaid = A323PropostaId;
         obj51.gxTpr_Secusername = A141SecUserName;
         obj51.gxTpr_Secuserfullname = A143SecUserFullName;
         obj51.gxTpr_Aprovacaoem = A337AprovacaoEm;
         obj51.gxTpr_Aprovacaodecisao = A338AprovacaoDecisao;
         obj51.gxTpr_Aprovacaostatus = A340AprovacaoStatus;
         obj51.gxTpr_Aprovacaoid = A336AprovacaoId;
         obj51.gxTpr_Aprovacaoid_Z = Z336AprovacaoId;
         obj51.gxTpr_Aprovadoresid_Z = Z375AprovadoresId;
         obj51.gxTpr_Propostaid_Z = Z323PropostaId;
         obj51.gxTpr_Secusername_Z = Z141SecUserName;
         obj51.gxTpr_Secuserfullname_Z = Z143SecUserFullName;
         obj51.gxTpr_Aprovacaoem_Z = Z337AprovacaoEm;
         obj51.gxTpr_Aprovacaodecisao_Z = Z338AprovacaoDecisao;
         obj51.gxTpr_Aprovacaostatus_Z = Z340AprovacaoStatus;
         obj51.gxTpr_Aprovadoresid_N = (short)(Convert.ToInt16(n375AprovadoresId));
         obj51.gxTpr_Propostaid_N = (short)(Convert.ToInt16(n323PropostaId));
         obj51.gxTpr_Secusername_N = (short)(Convert.ToInt16(n141SecUserName));
         obj51.gxTpr_Secuserfullname_N = (short)(Convert.ToInt16(n143SecUserFullName));
         obj51.gxTpr_Aprovacaoem_N = (short)(Convert.ToInt16(n337AprovacaoEm));
         obj51.gxTpr_Aprovacaodecisao_N = (short)(Convert.ToInt16(n338AprovacaoDecisao));
         obj51.gxTpr_Aprovacaostatus_N = (short)(Convert.ToInt16(n340AprovacaoStatus));
         obj51.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow51( SdtAprovacao obj51 )
      {
         obj51.gxTpr_Aprovacaoid = A336AprovacaoId;
         return  ;
      }

      public void RowToVars51( SdtAprovacao obj51 ,
                               int forceLoad )
      {
         Gx_mode = obj51.gxTpr_Mode;
         A375AprovadoresId = obj51.gxTpr_Aprovadoresid;
         n375AprovadoresId = false;
         A323PropostaId = obj51.gxTpr_Propostaid;
         n323PropostaId = false;
         A141SecUserName = obj51.gxTpr_Secusername;
         n141SecUserName = false;
         A143SecUserFullName = obj51.gxTpr_Secuserfullname;
         n143SecUserFullName = false;
         A337AprovacaoEm = obj51.gxTpr_Aprovacaoem;
         n337AprovacaoEm = false;
         A338AprovacaoDecisao = obj51.gxTpr_Aprovacaodecisao;
         n338AprovacaoDecisao = false;
         A340AprovacaoStatus = obj51.gxTpr_Aprovacaostatus;
         n340AprovacaoStatus = false;
         A336AprovacaoId = obj51.gxTpr_Aprovacaoid;
         Z336AprovacaoId = obj51.gxTpr_Aprovacaoid_Z;
         Z375AprovadoresId = obj51.gxTpr_Aprovadoresid_Z;
         Z323PropostaId = obj51.gxTpr_Propostaid_Z;
         Z141SecUserName = obj51.gxTpr_Secusername_Z;
         Z143SecUserFullName = obj51.gxTpr_Secuserfullname_Z;
         Z337AprovacaoEm = obj51.gxTpr_Aprovacaoem_Z;
         Z338AprovacaoDecisao = obj51.gxTpr_Aprovacaodecisao_Z;
         Z340AprovacaoStatus = obj51.gxTpr_Aprovacaostatus_Z;
         n375AprovadoresId = (bool)(Convert.ToBoolean(obj51.gxTpr_Aprovadoresid_N));
         n323PropostaId = (bool)(Convert.ToBoolean(obj51.gxTpr_Propostaid_N));
         n141SecUserName = (bool)(Convert.ToBoolean(obj51.gxTpr_Secusername_N));
         n143SecUserFullName = (bool)(Convert.ToBoolean(obj51.gxTpr_Secuserfullname_N));
         n337AprovacaoEm = (bool)(Convert.ToBoolean(obj51.gxTpr_Aprovacaoem_N));
         n338AprovacaoDecisao = (bool)(Convert.ToBoolean(obj51.gxTpr_Aprovacaodecisao_N));
         n340AprovacaoStatus = (bool)(Convert.ToBoolean(obj51.gxTpr_Aprovacaostatus_N));
         Gx_mode = obj51.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A336AprovacaoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1C51( ) ;
         ScanKeyStart1C51( ) ;
         if ( RcdFound51 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z336AprovacaoId = A336AprovacaoId;
         }
         ZM1C51( -6) ;
         OnLoadActions1C51( ) ;
         AddRow1C51( ) ;
         ScanKeyEnd1C51( ) ;
         if ( RcdFound51 == 0 )
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
         RowToVars51( bcAprovacao, 0) ;
         ScanKeyStart1C51( ) ;
         if ( RcdFound51 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z336AprovacaoId = A336AprovacaoId;
         }
         ZM1C51( -6) ;
         OnLoadActions1C51( ) ;
         AddRow1C51( ) ;
         ScanKeyEnd1C51( ) ;
         if ( RcdFound51 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1C51( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1C51( ) ;
         }
         else
         {
            if ( RcdFound51 == 1 )
            {
               if ( A336AprovacaoId != Z336AprovacaoId )
               {
                  A336AprovacaoId = Z336AprovacaoId;
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
                  Update1C51( ) ;
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
                  if ( A336AprovacaoId != Z336AprovacaoId )
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
                        Insert1C51( ) ;
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
                        Insert1C51( ) ;
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
         RowToVars51( bcAprovacao, 1) ;
         SaveImpl( ) ;
         VarsToRow51( bcAprovacao) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars51( bcAprovacao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1C51( ) ;
         AfterTrn( ) ;
         VarsToRow51( bcAprovacao) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow51( bcAprovacao) ;
         }
         else
         {
            SdtAprovacao auxBC = new SdtAprovacao(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A336AprovacaoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcAprovacao);
               auxBC.Save();
               bcAprovacao.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars51( bcAprovacao, 1) ;
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
         RowToVars51( bcAprovacao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1C51( ) ;
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
               VarsToRow51( bcAprovacao) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow51( bcAprovacao) ;
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
         RowToVars51( bcAprovacao, 0) ;
         GetKey1C51( ) ;
         if ( RcdFound51 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A336AprovacaoId != Z336AprovacaoId )
            {
               A336AprovacaoId = Z336AprovacaoId;
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
            if ( A336AprovacaoId != Z336AprovacaoId )
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
         context.RollbackDataStores("aprovacao_bc",pr_default);
         VarsToRow51( bcAprovacao) ;
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
         Gx_mode = bcAprovacao.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcAprovacao.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcAprovacao )
         {
            bcAprovacao = (SdtAprovacao)(sdt);
            if ( StringUtil.StrCmp(bcAprovacao.gxTpr_Mode, "") == 0 )
            {
               bcAprovacao.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow51( bcAprovacao) ;
            }
            else
            {
               RowToVars51( bcAprovacao, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcAprovacao.gxTpr_Mode, "") == 0 )
            {
               bcAprovacao.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars51( bcAprovacao, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtAprovacao Aprovacao_BC
      {
         get {
            return bcAprovacao ;
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
         pr_default.close(14);
         pr_default.close(12);
         pr_default.close(15);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV22Pgmname = "";
         AV13TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z337AprovacaoEm = (DateTime)(DateTime.MinValue);
         A337AprovacaoEm = (DateTime)(DateTime.MinValue);
         Z338AprovacaoDecisao = "";
         A338AprovacaoDecisao = "";
         Z340AprovacaoStatus = "";
         A340AprovacaoStatus = "";
         Z141SecUserName = "";
         A141SecUserName = "";
         Z143SecUserFullName = "";
         A143SecUserFullName = "";
         BC001C8_A328PropostaCratedBy = new short[1] ;
         BC001C8_n328PropostaCratedBy = new bool[] {false} ;
         BC001C8_A133SecUserId = new short[1] ;
         BC001C8_n133SecUserId = new bool[] {false} ;
         BC001C8_A336AprovacaoId = new int[1] ;
         BC001C8_A141SecUserName = new string[] {""} ;
         BC001C8_n141SecUserName = new bool[] {false} ;
         BC001C8_A143SecUserFullName = new string[] {""} ;
         BC001C8_n143SecUserFullName = new bool[] {false} ;
         BC001C8_A337AprovacaoEm = new DateTime[] {DateTime.MinValue} ;
         BC001C8_n337AprovacaoEm = new bool[] {false} ;
         BC001C8_A338AprovacaoDecisao = new string[] {""} ;
         BC001C8_n338AprovacaoDecisao = new bool[] {false} ;
         BC001C8_A340AprovacaoStatus = new string[] {""} ;
         BC001C8_n340AprovacaoStatus = new bool[] {false} ;
         BC001C8_A323PropostaId = new int[1] ;
         BC001C8_n323PropostaId = new bool[] {false} ;
         BC001C8_A375AprovadoresId = new int[1] ;
         BC001C8_n375AprovadoresId = new bool[] {false} ;
         BC001C5_A133SecUserId = new short[1] ;
         BC001C5_n133SecUserId = new bool[] {false} ;
         BC001C7_A143SecUserFullName = new string[] {""} ;
         BC001C7_n143SecUserFullName = new bool[] {false} ;
         BC001C4_A328PropostaCratedBy = new short[1] ;
         BC001C4_n328PropostaCratedBy = new bool[] {false} ;
         BC001C6_A141SecUserName = new string[] {""} ;
         BC001C6_n141SecUserName = new bool[] {false} ;
         BC001C9_A336AprovacaoId = new int[1] ;
         BC001C3_A336AprovacaoId = new int[1] ;
         BC001C3_A337AprovacaoEm = new DateTime[] {DateTime.MinValue} ;
         BC001C3_n337AprovacaoEm = new bool[] {false} ;
         BC001C3_A338AprovacaoDecisao = new string[] {""} ;
         BC001C3_n338AprovacaoDecisao = new bool[] {false} ;
         BC001C3_A340AprovacaoStatus = new string[] {""} ;
         BC001C3_n340AprovacaoStatus = new bool[] {false} ;
         BC001C3_A323PropostaId = new int[1] ;
         BC001C3_n323PropostaId = new bool[] {false} ;
         BC001C3_A375AprovadoresId = new int[1] ;
         BC001C3_n375AprovadoresId = new bool[] {false} ;
         sMode51 = "";
         BC001C2_A336AprovacaoId = new int[1] ;
         BC001C2_A337AprovacaoEm = new DateTime[] {DateTime.MinValue} ;
         BC001C2_n337AprovacaoEm = new bool[] {false} ;
         BC001C2_A338AprovacaoDecisao = new string[] {""} ;
         BC001C2_n338AprovacaoDecisao = new bool[] {false} ;
         BC001C2_A340AprovacaoStatus = new string[] {""} ;
         BC001C2_n340AprovacaoStatus = new bool[] {false} ;
         BC001C2_A323PropostaId = new int[1] ;
         BC001C2_n323PropostaId = new bool[] {false} ;
         BC001C2_A375AprovadoresId = new int[1] ;
         BC001C2_n375AprovadoresId = new bool[] {false} ;
         BC001C11_A336AprovacaoId = new int[1] ;
         BC001C14_A133SecUserId = new short[1] ;
         BC001C14_n133SecUserId = new bool[] {false} ;
         BC001C15_A143SecUserFullName = new string[] {""} ;
         BC001C15_n143SecUserFullName = new bool[] {false} ;
         BC001C16_A328PropostaCratedBy = new short[1] ;
         BC001C16_n328PropostaCratedBy = new bool[] {false} ;
         BC001C17_A141SecUserName = new string[] {""} ;
         BC001C17_n141SecUserName = new bool[] {false} ;
         BC001C18_A328PropostaCratedBy = new short[1] ;
         BC001C18_n328PropostaCratedBy = new bool[] {false} ;
         BC001C18_A133SecUserId = new short[1] ;
         BC001C18_n133SecUserId = new bool[] {false} ;
         BC001C18_A336AprovacaoId = new int[1] ;
         BC001C18_A141SecUserName = new string[] {""} ;
         BC001C18_n141SecUserName = new bool[] {false} ;
         BC001C18_A143SecUserFullName = new string[] {""} ;
         BC001C18_n143SecUserFullName = new bool[] {false} ;
         BC001C18_A337AprovacaoEm = new DateTime[] {DateTime.MinValue} ;
         BC001C18_n337AprovacaoEm = new bool[] {false} ;
         BC001C18_A338AprovacaoDecisao = new string[] {""} ;
         BC001C18_n338AprovacaoDecisao = new bool[] {false} ;
         BC001C18_A340AprovacaoStatus = new string[] {""} ;
         BC001C18_n340AprovacaoStatus = new bool[] {false} ;
         BC001C18_A323PropostaId = new int[1] ;
         BC001C18_n323PropostaId = new bool[] {false} ;
         BC001C18_A375AprovadoresId = new int[1] ;
         BC001C18_n375AprovadoresId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprovacao_bc__default(),
            new Object[][] {
                new Object[] {
               BC001C2_A336AprovacaoId, BC001C2_A337AprovacaoEm, BC001C2_n337AprovacaoEm, BC001C2_A338AprovacaoDecisao, BC001C2_n338AprovacaoDecisao, BC001C2_A340AprovacaoStatus, BC001C2_n340AprovacaoStatus, BC001C2_A323PropostaId, BC001C2_n323PropostaId, BC001C2_A375AprovadoresId,
               BC001C2_n375AprovadoresId
               }
               , new Object[] {
               BC001C3_A336AprovacaoId, BC001C3_A337AprovacaoEm, BC001C3_n337AprovacaoEm, BC001C3_A338AprovacaoDecisao, BC001C3_n338AprovacaoDecisao, BC001C3_A340AprovacaoStatus, BC001C3_n340AprovacaoStatus, BC001C3_A323PropostaId, BC001C3_n323PropostaId, BC001C3_A375AprovadoresId,
               BC001C3_n375AprovadoresId
               }
               , new Object[] {
               BC001C4_A328PropostaCratedBy, BC001C4_n328PropostaCratedBy
               }
               , new Object[] {
               BC001C5_A133SecUserId, BC001C5_n133SecUserId
               }
               , new Object[] {
               BC001C6_A141SecUserName, BC001C6_n141SecUserName
               }
               , new Object[] {
               BC001C7_A143SecUserFullName, BC001C7_n143SecUserFullName
               }
               , new Object[] {
               BC001C8_A328PropostaCratedBy, BC001C8_n328PropostaCratedBy, BC001C8_A133SecUserId, BC001C8_n133SecUserId, BC001C8_A336AprovacaoId, BC001C8_A141SecUserName, BC001C8_n141SecUserName, BC001C8_A143SecUserFullName, BC001C8_n143SecUserFullName, BC001C8_A337AprovacaoEm,
               BC001C8_n337AprovacaoEm, BC001C8_A338AprovacaoDecisao, BC001C8_n338AprovacaoDecisao, BC001C8_A340AprovacaoStatus, BC001C8_n340AprovacaoStatus, BC001C8_A323PropostaId, BC001C8_n323PropostaId, BC001C8_A375AprovadoresId, BC001C8_n375AprovadoresId
               }
               , new Object[] {
               BC001C9_A336AprovacaoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001C11_A336AprovacaoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001C14_A133SecUserId, BC001C14_n133SecUserId
               }
               , new Object[] {
               BC001C15_A143SecUserFullName, BC001C15_n143SecUserFullName
               }
               , new Object[] {
               BC001C16_A328PropostaCratedBy, BC001C16_n328PropostaCratedBy
               }
               , new Object[] {
               BC001C17_A141SecUserName, BC001C17_n141SecUserName
               }
               , new Object[] {
               BC001C18_A328PropostaCratedBy, BC001C18_n328PropostaCratedBy, BC001C18_A133SecUserId, BC001C18_n133SecUserId, BC001C18_A336AprovacaoId, BC001C18_A141SecUserName, BC001C18_n141SecUserName, BC001C18_A143SecUserFullName, BC001C18_n143SecUserFullName, BC001C18_A337AprovacaoEm,
               BC001C18_n337AprovacaoEm, BC001C18_A338AprovacaoDecisao, BC001C18_n338AprovacaoDecisao, BC001C18_A340AprovacaoStatus, BC001C18_n340AprovacaoStatus, BC001C18_A323PropostaId, BC001C18_n323PropostaId, BC001C18_A375AprovadoresId, BC001C18_n375AprovadoresId
               }
            }
         );
         AV22Pgmname = "Aprovacao_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121C2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z328PropostaCratedBy ;
      private short A328PropostaCratedBy ;
      private short Z133SecUserId ;
      private short A133SecUserId ;
      private short RcdFound51 ;
      private int trnEnded ;
      private int Z336AprovacaoId ;
      private int A336AprovacaoId ;
      private int AV23GXV1 ;
      private int AV11Insert_AprovadoresId ;
      private int AV12Insert_PropostaId ;
      private int Z323PropostaId ;
      private int A323PropostaId ;
      private int Z375AprovadoresId ;
      private int A375AprovadoresId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV22Pgmname ;
      private string sMode51 ;
      private DateTime Z337AprovacaoEm ;
      private DateTime A337AprovacaoEm ;
      private bool returnInSub ;
      private bool n328PropostaCratedBy ;
      private bool n133SecUserId ;
      private bool n141SecUserName ;
      private bool n143SecUserFullName ;
      private bool n337AprovacaoEm ;
      private bool n338AprovacaoDecisao ;
      private bool n340AprovacaoStatus ;
      private bool n323PropostaId ;
      private bool n375AprovadoresId ;
      private string Z338AprovacaoDecisao ;
      private string A338AprovacaoDecisao ;
      private string Z340AprovacaoStatus ;
      private string A340AprovacaoStatus ;
      private string Z141SecUserName ;
      private string A141SecUserName ;
      private string Z143SecUserFullName ;
      private string A143SecUserFullName ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] BC001C8_A328PropostaCratedBy ;
      private bool[] BC001C8_n328PropostaCratedBy ;
      private short[] BC001C8_A133SecUserId ;
      private bool[] BC001C8_n133SecUserId ;
      private int[] BC001C8_A336AprovacaoId ;
      private string[] BC001C8_A141SecUserName ;
      private bool[] BC001C8_n141SecUserName ;
      private string[] BC001C8_A143SecUserFullName ;
      private bool[] BC001C8_n143SecUserFullName ;
      private DateTime[] BC001C8_A337AprovacaoEm ;
      private bool[] BC001C8_n337AprovacaoEm ;
      private string[] BC001C8_A338AprovacaoDecisao ;
      private bool[] BC001C8_n338AprovacaoDecisao ;
      private string[] BC001C8_A340AprovacaoStatus ;
      private bool[] BC001C8_n340AprovacaoStatus ;
      private int[] BC001C8_A323PropostaId ;
      private bool[] BC001C8_n323PropostaId ;
      private int[] BC001C8_A375AprovadoresId ;
      private bool[] BC001C8_n375AprovadoresId ;
      private short[] BC001C5_A133SecUserId ;
      private bool[] BC001C5_n133SecUserId ;
      private string[] BC001C7_A143SecUserFullName ;
      private bool[] BC001C7_n143SecUserFullName ;
      private short[] BC001C4_A328PropostaCratedBy ;
      private bool[] BC001C4_n328PropostaCratedBy ;
      private string[] BC001C6_A141SecUserName ;
      private bool[] BC001C6_n141SecUserName ;
      private int[] BC001C9_A336AprovacaoId ;
      private int[] BC001C3_A336AprovacaoId ;
      private DateTime[] BC001C3_A337AprovacaoEm ;
      private bool[] BC001C3_n337AprovacaoEm ;
      private string[] BC001C3_A338AprovacaoDecisao ;
      private bool[] BC001C3_n338AprovacaoDecisao ;
      private string[] BC001C3_A340AprovacaoStatus ;
      private bool[] BC001C3_n340AprovacaoStatus ;
      private int[] BC001C3_A323PropostaId ;
      private bool[] BC001C3_n323PropostaId ;
      private int[] BC001C3_A375AprovadoresId ;
      private bool[] BC001C3_n375AprovadoresId ;
      private int[] BC001C2_A336AprovacaoId ;
      private DateTime[] BC001C2_A337AprovacaoEm ;
      private bool[] BC001C2_n337AprovacaoEm ;
      private string[] BC001C2_A338AprovacaoDecisao ;
      private bool[] BC001C2_n338AprovacaoDecisao ;
      private string[] BC001C2_A340AprovacaoStatus ;
      private bool[] BC001C2_n340AprovacaoStatus ;
      private int[] BC001C2_A323PropostaId ;
      private bool[] BC001C2_n323PropostaId ;
      private int[] BC001C2_A375AprovadoresId ;
      private bool[] BC001C2_n375AprovadoresId ;
      private int[] BC001C11_A336AprovacaoId ;
      private short[] BC001C14_A133SecUserId ;
      private bool[] BC001C14_n133SecUserId ;
      private string[] BC001C15_A143SecUserFullName ;
      private bool[] BC001C15_n143SecUserFullName ;
      private short[] BC001C16_A328PropostaCratedBy ;
      private bool[] BC001C16_n328PropostaCratedBy ;
      private string[] BC001C17_A141SecUserName ;
      private bool[] BC001C17_n141SecUserName ;
      private short[] BC001C18_A328PropostaCratedBy ;
      private bool[] BC001C18_n328PropostaCratedBy ;
      private short[] BC001C18_A133SecUserId ;
      private bool[] BC001C18_n133SecUserId ;
      private int[] BC001C18_A336AprovacaoId ;
      private string[] BC001C18_A141SecUserName ;
      private bool[] BC001C18_n141SecUserName ;
      private string[] BC001C18_A143SecUserFullName ;
      private bool[] BC001C18_n143SecUserFullName ;
      private DateTime[] BC001C18_A337AprovacaoEm ;
      private bool[] BC001C18_n337AprovacaoEm ;
      private string[] BC001C18_A338AprovacaoDecisao ;
      private bool[] BC001C18_n338AprovacaoDecisao ;
      private string[] BC001C18_A340AprovacaoStatus ;
      private bool[] BC001C18_n340AprovacaoStatus ;
      private int[] BC001C18_A323PropostaId ;
      private bool[] BC001C18_n323PropostaId ;
      private int[] BC001C18_A375AprovadoresId ;
      private bool[] BC001C18_n375AprovadoresId ;
      private SdtAprovacao bcAprovacao ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class aprovacao_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001C2;
          prmBC001C2 = new Object[] {
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001C3;
          prmBC001C3 = new Object[] {
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001C4;
          prmBC001C4 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001C5;
          prmBC001C5 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001C6;
          prmBC001C6 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001C7;
          prmBC001C7 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001C8;
          prmBC001C8 = new Object[] {
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001C9;
          prmBC001C9 = new Object[] {
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001C10;
          prmBC001C10 = new Object[] {
          new ParDef("AprovacaoEm",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AprovacaoDecisao",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("AprovacaoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001C11;
          prmBC001C11 = new Object[] {
          };
          Object[] prmBC001C12;
          prmBC001C12 = new Object[] {
          new ParDef("AprovacaoEm",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("AprovacaoDecisao",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("AprovacaoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001C13;
          prmBC001C13 = new Object[] {
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001C14;
          prmBC001C14 = new Object[] {
          new ParDef("AprovadoresId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001C15;
          prmBC001C15 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001C16;
          prmBC001C16 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001C17;
          prmBC001C17 = new Object[] {
          new ParDef("PropostaCratedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001C18;
          prmBC001C18 = new Object[] {
          new ParDef("AprovacaoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC001C2", "SELECT AprovacaoId, AprovacaoEm, AprovacaoDecisao, AprovacaoStatus, PropostaId, AprovadoresId FROM Aprovacao WHERE AprovacaoId = :AprovacaoId  FOR UPDATE OF Aprovacao",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001C3", "SELECT AprovacaoId, AprovacaoEm, AprovacaoDecisao, AprovacaoStatus, PropostaId, AprovadoresId FROM Aprovacao WHERE AprovacaoId = :AprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001C4", "SELECT PropostaCratedBy FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001C5", "SELECT SecUserId FROM Aprovadores WHERE AprovadoresId = :AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001C6", "SELECT SecUserName FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001C7", "SELECT SecUserFullName FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001C8", "SELECT T4.PropostaCratedBy AS PropostaCratedBy, T2.SecUserId, TM1.AprovacaoId, T5.SecUserName, T3.SecUserFullName, TM1.AprovacaoEm, TM1.AprovacaoDecisao, TM1.AprovacaoStatus, TM1.PropostaId, TM1.AprovadoresId FROM ((((Aprovacao TM1 LEFT JOIN Aprovadores T2 ON T2.AprovadoresId = TM1.AprovadoresId) LEFT JOIN SecUser T3 ON T3.SecUserId = T2.SecUserId) LEFT JOIN Proposta T4 ON T4.PropostaId = TM1.PropostaId) LEFT JOIN SecUser T5 ON T5.SecUserId = T4.PropostaCratedBy) WHERE TM1.AprovacaoId = :AprovacaoId ORDER BY TM1.AprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001C9", "SELECT AprovacaoId FROM Aprovacao WHERE AprovacaoId = :AprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001C10", "SAVEPOINT gxupdate;INSERT INTO Aprovacao(AprovacaoEm, AprovacaoDecisao, AprovacaoStatus, PropostaId, AprovadoresId) VALUES(:AprovacaoEm, :AprovacaoDecisao, :AprovacaoStatus, :PropostaId, :AprovadoresId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001C10)
             ,new CursorDef("BC001C11", "SELECT currval('AprovacaoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001C12", "SAVEPOINT gxupdate;UPDATE Aprovacao SET AprovacaoEm=:AprovacaoEm, AprovacaoDecisao=:AprovacaoDecisao, AprovacaoStatus=:AprovacaoStatus, PropostaId=:PropostaId, AprovadoresId=:AprovadoresId  WHERE AprovacaoId = :AprovacaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001C12)
             ,new CursorDef("BC001C13", "SAVEPOINT gxupdate;DELETE FROM Aprovacao  WHERE AprovacaoId = :AprovacaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001C13)
             ,new CursorDef("BC001C14", "SELECT SecUserId FROM Aprovadores WHERE AprovadoresId = :AprovadoresId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001C15", "SELECT SecUserFullName FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001C16", "SELECT PropostaCratedBy FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001C17", "SELECT SecUserName FROM SecUser WHERE SecUserId = :PropostaCratedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001C18", "SELECT T4.PropostaCratedBy AS PropostaCratedBy, T2.SecUserId, TM1.AprovacaoId, T5.SecUserName, T3.SecUserFullName, TM1.AprovacaoEm, TM1.AprovacaoDecisao, TM1.AprovacaoStatus, TM1.PropostaId, TM1.AprovadoresId FROM ((((Aprovacao TM1 LEFT JOIN Aprovadores T2 ON T2.AprovadoresId = TM1.AprovadoresId) LEFT JOIN SecUser T3 ON T3.SecUserId = T2.SecUserId) LEFT JOIN Proposta T4 ON T4.PropostaId = TM1.PropostaId) LEFT JOIN SecUser T5 ON T5.SecUserId = T4.PropostaCratedBy) WHERE TM1.AprovacaoId = :AprovacaoId ORDER BY TM1.AprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001C18,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
