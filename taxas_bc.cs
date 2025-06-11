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
   public class taxas_bc : GxSilentTrn, IGxSilentTrn
   {
      public taxas_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public taxas_bc( IGxContext context )
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
         ReadRow2Q96( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2Q96( ) ;
         standaloneModal( ) ;
         AddRow2Q96( ) ;
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
            E112Q2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z863TaxasId = A863TaxasId;
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

      protected void CONFIRM_2Q0( )
      {
         BeforeValidate2Q96( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2Q96( ) ;
            }
            else
            {
               CheckExtendedTable2Q96( ) ;
               if ( AnyError == 0 )
               {
                  ZM2Q96( 7) ;
                  ZM2Q96( 8) ;
               }
               CloseExtendedTableCursors2Q96( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122Q2( )
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
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            while ( AV25GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TaxasCreatedBy") == 0 )
               {
                  AV11Insert_TaxasCreatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TaxasUpdatedBy") == 0 )
               {
                  AV12Insert_TaxasUpdatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
            }
         }
      }

      protected void E112Q2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
      }

      protected void ZM2Q96( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z866TaxasCreatedAt = A866TaxasCreatedAt;
            Z867TaxasUpdatedAt = A867TaxasUpdatedAt;
            Z864TaxasPercentual = A864TaxasPercentual;
            Z894TaxasPercentualAnual = A894TaxasPercentualAnual;
            Z865TaxasValorMinimo = A865TaxasValorMinimo;
            Z868TaxasCreatedBy = A868TaxasCreatedBy;
            Z869TaxasUpdatedBy = A869TaxasUpdatedBy;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z872TaxasCreatedName = A872TaxasCreatedName;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z873TaxasUpdatedName = A873TaxasUpdatedName;
         }
         if ( GX_JID == -6 )
         {
            Z863TaxasId = A863TaxasId;
            Z866TaxasCreatedAt = A866TaxasCreatedAt;
            Z867TaxasUpdatedAt = A867TaxasUpdatedAt;
            Z864TaxasPercentual = A864TaxasPercentual;
            Z894TaxasPercentualAnual = A894TaxasPercentualAnual;
            Z865TaxasValorMinimo = A865TaxasValorMinimo;
            Z868TaxasCreatedBy = A868TaxasCreatedBy;
            Z869TaxasUpdatedBy = A869TaxasUpdatedBy;
            Z872TaxasCreatedName = A872TaxasCreatedName;
            Z873TaxasUpdatedName = A873TaxasUpdatedName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV24Pgmname = "Taxas_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A866TaxasCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n866TaxasCreatedAt = false;
         }
         if ( IsUpd( )  )
         {
            A867TaxasUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n867TaxasUpdatedAt = false;
         }
      }

      protected void Load2Q96( )
      {
         /* Using cursor BC002Q6 */
         pr_default.execute(4, new Object[] {A863TaxasId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound96 = 1;
            A866TaxasCreatedAt = BC002Q6_A866TaxasCreatedAt[0];
            n866TaxasCreatedAt = BC002Q6_n866TaxasCreatedAt[0];
            A867TaxasUpdatedAt = BC002Q6_A867TaxasUpdatedAt[0];
            n867TaxasUpdatedAt = BC002Q6_n867TaxasUpdatedAt[0];
            A864TaxasPercentual = BC002Q6_A864TaxasPercentual[0];
            n864TaxasPercentual = BC002Q6_n864TaxasPercentual[0];
            A894TaxasPercentualAnual = BC002Q6_A894TaxasPercentualAnual[0];
            n894TaxasPercentualAnual = BC002Q6_n894TaxasPercentualAnual[0];
            A865TaxasValorMinimo = BC002Q6_A865TaxasValorMinimo[0];
            n865TaxasValorMinimo = BC002Q6_n865TaxasValorMinimo[0];
            A872TaxasCreatedName = BC002Q6_A872TaxasCreatedName[0];
            n872TaxasCreatedName = BC002Q6_n872TaxasCreatedName[0];
            A873TaxasUpdatedName = BC002Q6_A873TaxasUpdatedName[0];
            n873TaxasUpdatedName = BC002Q6_n873TaxasUpdatedName[0];
            A868TaxasCreatedBy = BC002Q6_A868TaxasCreatedBy[0];
            n868TaxasCreatedBy = BC002Q6_n868TaxasCreatedBy[0];
            A869TaxasUpdatedBy = BC002Q6_A869TaxasUpdatedBy[0];
            n869TaxasUpdatedBy = BC002Q6_n869TaxasUpdatedBy[0];
            ZM2Q96( -6) ;
         }
         pr_default.close(4);
         OnLoadActions2Q96( ) ;
      }

      protected void OnLoadActions2Q96( )
      {
      }

      protected void CheckExtendedTable2Q96( )
      {
         standaloneModal( ) ;
         if ( ( A865TaxasValorMinimo < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC002Q4 */
         pr_default.execute(2, new Object[] {n868TaxasCreatedBy, A868TaxasCreatedBy});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A868TaxasCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Taxas Created By'.", "ForeignKeyNotFound", 1, "TAXASCREATEDBY");
               AnyError = 1;
            }
         }
         A872TaxasCreatedName = BC002Q4_A872TaxasCreatedName[0];
         n872TaxasCreatedName = BC002Q4_n872TaxasCreatedName[0];
         pr_default.close(2);
         /* Using cursor BC002Q5 */
         pr_default.execute(3, new Object[] {n869TaxasUpdatedBy, A869TaxasUpdatedBy});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A869TaxasUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Taxas Updated By'.", "ForeignKeyNotFound", 1, "TAXASUPDATEDBY");
               AnyError = 1;
            }
         }
         A873TaxasUpdatedName = BC002Q5_A873TaxasUpdatedName[0];
         n873TaxasUpdatedName = BC002Q5_n873TaxasUpdatedName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2Q96( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2Q96( )
      {
         /* Using cursor BC002Q7 */
         pr_default.execute(5, new Object[] {A863TaxasId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound96 = 1;
         }
         else
         {
            RcdFound96 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002Q3 */
         pr_default.execute(1, new Object[] {A863TaxasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2Q96( 6) ;
            RcdFound96 = 1;
            A863TaxasId = BC002Q3_A863TaxasId[0];
            A866TaxasCreatedAt = BC002Q3_A866TaxasCreatedAt[0];
            n866TaxasCreatedAt = BC002Q3_n866TaxasCreatedAt[0];
            A867TaxasUpdatedAt = BC002Q3_A867TaxasUpdatedAt[0];
            n867TaxasUpdatedAt = BC002Q3_n867TaxasUpdatedAt[0];
            A864TaxasPercentual = BC002Q3_A864TaxasPercentual[0];
            n864TaxasPercentual = BC002Q3_n864TaxasPercentual[0];
            A894TaxasPercentualAnual = BC002Q3_A894TaxasPercentualAnual[0];
            n894TaxasPercentualAnual = BC002Q3_n894TaxasPercentualAnual[0];
            A865TaxasValorMinimo = BC002Q3_A865TaxasValorMinimo[0];
            n865TaxasValorMinimo = BC002Q3_n865TaxasValorMinimo[0];
            A868TaxasCreatedBy = BC002Q3_A868TaxasCreatedBy[0];
            n868TaxasCreatedBy = BC002Q3_n868TaxasCreatedBy[0];
            A869TaxasUpdatedBy = BC002Q3_A869TaxasUpdatedBy[0];
            n869TaxasUpdatedBy = BC002Q3_n869TaxasUpdatedBy[0];
            Z863TaxasId = A863TaxasId;
            sMode96 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2Q96( ) ;
            if ( AnyError == 1 )
            {
               RcdFound96 = 0;
               InitializeNonKey2Q96( ) ;
            }
            Gx_mode = sMode96;
         }
         else
         {
            RcdFound96 = 0;
            InitializeNonKey2Q96( ) ;
            sMode96 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode96;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2Q96( ) ;
         if ( RcdFound96 == 0 )
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
         CONFIRM_2Q0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2Q96( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002Q2 */
            pr_default.execute(0, new Object[] {A863TaxasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Taxas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z866TaxasCreatedAt != BC002Q2_A866TaxasCreatedAt[0] ) || ( Z867TaxasUpdatedAt != BC002Q2_A867TaxasUpdatedAt[0] ) || ( Z864TaxasPercentual != BC002Q2_A864TaxasPercentual[0] ) || ( Z894TaxasPercentualAnual != BC002Q2_A894TaxasPercentualAnual[0] ) || ( Z865TaxasValorMinimo != BC002Q2_A865TaxasValorMinimo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z868TaxasCreatedBy != BC002Q2_A868TaxasCreatedBy[0] ) || ( Z869TaxasUpdatedBy != BC002Q2_A869TaxasUpdatedBy[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Taxas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2Q96( )
      {
         BeforeValidate2Q96( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Q96( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2Q96( 0) ;
            CheckOptimisticConcurrency2Q96( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Q96( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2Q96( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002Q8 */
                     pr_default.execute(6, new Object[] {n866TaxasCreatedAt, A866TaxasCreatedAt, n867TaxasUpdatedAt, A867TaxasUpdatedAt, n864TaxasPercentual, A864TaxasPercentual, n894TaxasPercentualAnual, A894TaxasPercentualAnual, n865TaxasValorMinimo, A865TaxasValorMinimo, n868TaxasCreatedBy, A868TaxasCreatedBy, n869TaxasUpdatedBy, A869TaxasUpdatedBy});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002Q9 */
                     pr_default.execute(7);
                     A863TaxasId = BC002Q9_A863TaxasId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Taxas");
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
               Load2Q96( ) ;
            }
            EndLevel2Q96( ) ;
         }
         CloseExtendedTableCursors2Q96( ) ;
      }

      protected void Update2Q96( )
      {
         BeforeValidate2Q96( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Q96( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Q96( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Q96( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2Q96( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002Q10 */
                     pr_default.execute(8, new Object[] {n866TaxasCreatedAt, A866TaxasCreatedAt, n867TaxasUpdatedAt, A867TaxasUpdatedAt, n864TaxasPercentual, A864TaxasPercentual, n894TaxasPercentualAnual, A894TaxasPercentualAnual, n865TaxasValorMinimo, A865TaxasValorMinimo, n868TaxasCreatedBy, A868TaxasCreatedBy, n869TaxasUpdatedBy, A869TaxasUpdatedBy, A863TaxasId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Taxas");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Taxas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2Q96( ) ;
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
            EndLevel2Q96( ) ;
         }
         CloseExtendedTableCursors2Q96( ) ;
      }

      protected void DeferredUpdate2Q96( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2Q96( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Q96( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2Q96( ) ;
            AfterConfirm2Q96( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2Q96( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002Q11 */
                  pr_default.execute(9, new Object[] {A863TaxasId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Taxas");
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
         sMode96 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2Q96( ) ;
         Gx_mode = sMode96;
      }

      protected void OnDeleteControls2Q96( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002Q12 */
            pr_default.execute(10, new Object[] {n868TaxasCreatedBy, A868TaxasCreatedBy});
            A872TaxasCreatedName = BC002Q12_A872TaxasCreatedName[0];
            n872TaxasCreatedName = BC002Q12_n872TaxasCreatedName[0];
            pr_default.close(10);
            /* Using cursor BC002Q13 */
            pr_default.execute(11, new Object[] {n869TaxasUpdatedBy, A869TaxasUpdatedBy});
            A873TaxasUpdatedName = BC002Q13_A873TaxasUpdatedName[0];
            n873TaxasUpdatedName = BC002Q13_n873TaxasUpdatedName[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel2Q96( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2Q96( ) ;
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

      public void ScanKeyStart2Q96( )
      {
         /* Scan By routine */
         /* Using cursor BC002Q14 */
         pr_default.execute(12, new Object[] {A863TaxasId});
         RcdFound96 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound96 = 1;
            A863TaxasId = BC002Q14_A863TaxasId[0];
            A866TaxasCreatedAt = BC002Q14_A866TaxasCreatedAt[0];
            n866TaxasCreatedAt = BC002Q14_n866TaxasCreatedAt[0];
            A867TaxasUpdatedAt = BC002Q14_A867TaxasUpdatedAt[0];
            n867TaxasUpdatedAt = BC002Q14_n867TaxasUpdatedAt[0];
            A864TaxasPercentual = BC002Q14_A864TaxasPercentual[0];
            n864TaxasPercentual = BC002Q14_n864TaxasPercentual[0];
            A894TaxasPercentualAnual = BC002Q14_A894TaxasPercentualAnual[0];
            n894TaxasPercentualAnual = BC002Q14_n894TaxasPercentualAnual[0];
            A865TaxasValorMinimo = BC002Q14_A865TaxasValorMinimo[0];
            n865TaxasValorMinimo = BC002Q14_n865TaxasValorMinimo[0];
            A872TaxasCreatedName = BC002Q14_A872TaxasCreatedName[0];
            n872TaxasCreatedName = BC002Q14_n872TaxasCreatedName[0];
            A873TaxasUpdatedName = BC002Q14_A873TaxasUpdatedName[0];
            n873TaxasUpdatedName = BC002Q14_n873TaxasUpdatedName[0];
            A868TaxasCreatedBy = BC002Q14_A868TaxasCreatedBy[0];
            n868TaxasCreatedBy = BC002Q14_n868TaxasCreatedBy[0];
            A869TaxasUpdatedBy = BC002Q14_A869TaxasUpdatedBy[0];
            n869TaxasUpdatedBy = BC002Q14_n869TaxasUpdatedBy[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2Q96( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound96 = 0;
         ScanKeyLoad2Q96( ) ;
      }

      protected void ScanKeyLoad2Q96( )
      {
         sMode96 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound96 = 1;
            A863TaxasId = BC002Q14_A863TaxasId[0];
            A866TaxasCreatedAt = BC002Q14_A866TaxasCreatedAt[0];
            n866TaxasCreatedAt = BC002Q14_n866TaxasCreatedAt[0];
            A867TaxasUpdatedAt = BC002Q14_A867TaxasUpdatedAt[0];
            n867TaxasUpdatedAt = BC002Q14_n867TaxasUpdatedAt[0];
            A864TaxasPercentual = BC002Q14_A864TaxasPercentual[0];
            n864TaxasPercentual = BC002Q14_n864TaxasPercentual[0];
            A894TaxasPercentualAnual = BC002Q14_A894TaxasPercentualAnual[0];
            n894TaxasPercentualAnual = BC002Q14_n894TaxasPercentualAnual[0];
            A865TaxasValorMinimo = BC002Q14_A865TaxasValorMinimo[0];
            n865TaxasValorMinimo = BC002Q14_n865TaxasValorMinimo[0];
            A872TaxasCreatedName = BC002Q14_A872TaxasCreatedName[0];
            n872TaxasCreatedName = BC002Q14_n872TaxasCreatedName[0];
            A873TaxasUpdatedName = BC002Q14_A873TaxasUpdatedName[0];
            n873TaxasUpdatedName = BC002Q14_n873TaxasUpdatedName[0];
            A868TaxasCreatedBy = BC002Q14_A868TaxasCreatedBy[0];
            n868TaxasCreatedBy = BC002Q14_n868TaxasCreatedBy[0];
            A869TaxasUpdatedBy = BC002Q14_A869TaxasUpdatedBy[0];
            n869TaxasUpdatedBy = BC002Q14_n869TaxasUpdatedBy[0];
         }
         Gx_mode = sMode96;
      }

      protected void ScanKeyEnd2Q96( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm2Q96( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2Q96( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2Q96( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2Q96( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2Q96( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2Q96( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2Q96( )
      {
      }

      protected void send_integrity_lvl_hashes2Q96( )
      {
      }

      protected void AddRow2Q96( )
      {
         VarsToRow96( bcTaxas) ;
      }

      protected void ReadRow2Q96( )
      {
         RowToVars96( bcTaxas, 1) ;
      }

      protected void InitializeNonKey2Q96( )
      {
         A866TaxasCreatedAt = (DateTime)(DateTime.MinValue);
         n866TaxasCreatedAt = false;
         A867TaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         n867TaxasUpdatedAt = false;
         A864TaxasPercentual = 0;
         n864TaxasPercentual = false;
         A894TaxasPercentualAnual = 0;
         n894TaxasPercentualAnual = false;
         A865TaxasValorMinimo = 0;
         n865TaxasValorMinimo = false;
         A868TaxasCreatedBy = 0;
         n868TaxasCreatedBy = false;
         A872TaxasCreatedName = "";
         n872TaxasCreatedName = false;
         A869TaxasUpdatedBy = 0;
         n869TaxasUpdatedBy = false;
         A873TaxasUpdatedName = "";
         n873TaxasUpdatedName = false;
         Z866TaxasCreatedAt = (DateTime)(DateTime.MinValue);
         Z867TaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         Z864TaxasPercentual = 0;
         Z894TaxasPercentualAnual = 0;
         Z865TaxasValorMinimo = 0;
         Z868TaxasCreatedBy = 0;
         Z869TaxasUpdatedBy = 0;
      }

      protected void InitAll2Q96( )
      {
         A863TaxasId = 0;
         InitializeNonKey2Q96( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A866TaxasCreatedAt = i866TaxasCreatedAt;
         n866TaxasCreatedAt = false;
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

      public void VarsToRow96( SdtTaxas obj96 )
      {
         obj96.gxTpr_Mode = Gx_mode;
         obj96.gxTpr_Taxascreatedat = A866TaxasCreatedAt;
         obj96.gxTpr_Taxasupdatedat = A867TaxasUpdatedAt;
         obj96.gxTpr_Taxaspercentual = A864TaxasPercentual;
         obj96.gxTpr_Taxaspercentualanual = A894TaxasPercentualAnual;
         obj96.gxTpr_Taxasvalorminimo = A865TaxasValorMinimo;
         obj96.gxTpr_Taxascreatedby = A868TaxasCreatedBy;
         obj96.gxTpr_Taxascreatedname = A872TaxasCreatedName;
         obj96.gxTpr_Taxasupdatedby = A869TaxasUpdatedBy;
         obj96.gxTpr_Taxasupdatedname = A873TaxasUpdatedName;
         obj96.gxTpr_Taxasid = A863TaxasId;
         obj96.gxTpr_Taxasid_Z = Z863TaxasId;
         obj96.gxTpr_Taxaspercentual_Z = Z864TaxasPercentual;
         obj96.gxTpr_Taxaspercentualanual_Z = Z894TaxasPercentualAnual;
         obj96.gxTpr_Taxasvalorminimo_Z = Z865TaxasValorMinimo;
         obj96.gxTpr_Taxascreatedat_Z = Z866TaxasCreatedAt;
         obj96.gxTpr_Taxasupdatedat_Z = Z867TaxasUpdatedAt;
         obj96.gxTpr_Taxascreatedby_Z = Z868TaxasCreatedBy;
         obj96.gxTpr_Taxascreatedname_Z = Z872TaxasCreatedName;
         obj96.gxTpr_Taxasupdatedby_Z = Z869TaxasUpdatedBy;
         obj96.gxTpr_Taxasupdatedname_Z = Z873TaxasUpdatedName;
         obj96.gxTpr_Taxaspercentual_N = (short)(Convert.ToInt16(n864TaxasPercentual));
         obj96.gxTpr_Taxaspercentualanual_N = (short)(Convert.ToInt16(n894TaxasPercentualAnual));
         obj96.gxTpr_Taxasvalorminimo_N = (short)(Convert.ToInt16(n865TaxasValorMinimo));
         obj96.gxTpr_Taxascreatedat_N = (short)(Convert.ToInt16(n866TaxasCreatedAt));
         obj96.gxTpr_Taxasupdatedat_N = (short)(Convert.ToInt16(n867TaxasUpdatedAt));
         obj96.gxTpr_Taxascreatedby_N = (short)(Convert.ToInt16(n868TaxasCreatedBy));
         obj96.gxTpr_Taxascreatedname_N = (short)(Convert.ToInt16(n872TaxasCreatedName));
         obj96.gxTpr_Taxasupdatedby_N = (short)(Convert.ToInt16(n869TaxasUpdatedBy));
         obj96.gxTpr_Taxasupdatedname_N = (short)(Convert.ToInt16(n873TaxasUpdatedName));
         obj96.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow96( SdtTaxas obj96 )
      {
         obj96.gxTpr_Taxasid = A863TaxasId;
         return  ;
      }

      public void RowToVars96( SdtTaxas obj96 ,
                               int forceLoad )
      {
         Gx_mode = obj96.gxTpr_Mode;
         A866TaxasCreatedAt = obj96.gxTpr_Taxascreatedat;
         n866TaxasCreatedAt = false;
         A867TaxasUpdatedAt = obj96.gxTpr_Taxasupdatedat;
         n867TaxasUpdatedAt = false;
         A864TaxasPercentual = obj96.gxTpr_Taxaspercentual;
         n864TaxasPercentual = false;
         A894TaxasPercentualAnual = obj96.gxTpr_Taxaspercentualanual;
         n894TaxasPercentualAnual = false;
         A865TaxasValorMinimo = obj96.gxTpr_Taxasvalorminimo;
         n865TaxasValorMinimo = false;
         A868TaxasCreatedBy = obj96.gxTpr_Taxascreatedby;
         n868TaxasCreatedBy = false;
         A872TaxasCreatedName = obj96.gxTpr_Taxascreatedname;
         n872TaxasCreatedName = false;
         A869TaxasUpdatedBy = obj96.gxTpr_Taxasupdatedby;
         n869TaxasUpdatedBy = false;
         A873TaxasUpdatedName = obj96.gxTpr_Taxasupdatedname;
         n873TaxasUpdatedName = false;
         A863TaxasId = obj96.gxTpr_Taxasid;
         Z863TaxasId = obj96.gxTpr_Taxasid_Z;
         Z864TaxasPercentual = obj96.gxTpr_Taxaspercentual_Z;
         Z894TaxasPercentualAnual = obj96.gxTpr_Taxaspercentualanual_Z;
         Z865TaxasValorMinimo = obj96.gxTpr_Taxasvalorminimo_Z;
         Z866TaxasCreatedAt = obj96.gxTpr_Taxascreatedat_Z;
         Z867TaxasUpdatedAt = obj96.gxTpr_Taxasupdatedat_Z;
         Z868TaxasCreatedBy = obj96.gxTpr_Taxascreatedby_Z;
         Z872TaxasCreatedName = obj96.gxTpr_Taxascreatedname_Z;
         Z869TaxasUpdatedBy = obj96.gxTpr_Taxasupdatedby_Z;
         Z873TaxasUpdatedName = obj96.gxTpr_Taxasupdatedname_Z;
         n864TaxasPercentual = (bool)(Convert.ToBoolean(obj96.gxTpr_Taxaspercentual_N));
         n894TaxasPercentualAnual = (bool)(Convert.ToBoolean(obj96.gxTpr_Taxaspercentualanual_N));
         n865TaxasValorMinimo = (bool)(Convert.ToBoolean(obj96.gxTpr_Taxasvalorminimo_N));
         n866TaxasCreatedAt = (bool)(Convert.ToBoolean(obj96.gxTpr_Taxascreatedat_N));
         n867TaxasUpdatedAt = (bool)(Convert.ToBoolean(obj96.gxTpr_Taxasupdatedat_N));
         n868TaxasCreatedBy = (bool)(Convert.ToBoolean(obj96.gxTpr_Taxascreatedby_N));
         n872TaxasCreatedName = (bool)(Convert.ToBoolean(obj96.gxTpr_Taxascreatedname_N));
         n869TaxasUpdatedBy = (bool)(Convert.ToBoolean(obj96.gxTpr_Taxasupdatedby_N));
         n873TaxasUpdatedName = (bool)(Convert.ToBoolean(obj96.gxTpr_Taxasupdatedname_N));
         Gx_mode = obj96.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A863TaxasId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2Q96( ) ;
         ScanKeyStart2Q96( ) ;
         if ( RcdFound96 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z863TaxasId = A863TaxasId;
         }
         ZM2Q96( -6) ;
         OnLoadActions2Q96( ) ;
         AddRow2Q96( ) ;
         ScanKeyEnd2Q96( ) ;
         if ( RcdFound96 == 0 )
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
         RowToVars96( bcTaxas, 0) ;
         ScanKeyStart2Q96( ) ;
         if ( RcdFound96 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z863TaxasId = A863TaxasId;
         }
         ZM2Q96( -6) ;
         OnLoadActions2Q96( ) ;
         AddRow2Q96( ) ;
         ScanKeyEnd2Q96( ) ;
         if ( RcdFound96 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2Q96( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2Q96( ) ;
         }
         else
         {
            if ( RcdFound96 == 1 )
            {
               if ( A863TaxasId != Z863TaxasId )
               {
                  A863TaxasId = Z863TaxasId;
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
                  Update2Q96( ) ;
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
                  if ( A863TaxasId != Z863TaxasId )
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
                        Insert2Q96( ) ;
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
                        Insert2Q96( ) ;
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
         RowToVars96( bcTaxas, 1) ;
         SaveImpl( ) ;
         VarsToRow96( bcTaxas) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars96( bcTaxas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2Q96( ) ;
         AfterTrn( ) ;
         VarsToRow96( bcTaxas) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow96( bcTaxas) ;
         }
         else
         {
            SdtTaxas auxBC = new SdtTaxas(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A863TaxasId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTaxas);
               auxBC.Save();
               bcTaxas.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars96( bcTaxas, 1) ;
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
         RowToVars96( bcTaxas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2Q96( ) ;
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
               VarsToRow96( bcTaxas) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow96( bcTaxas) ;
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
         RowToVars96( bcTaxas, 0) ;
         GetKey2Q96( ) ;
         if ( RcdFound96 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A863TaxasId != Z863TaxasId )
            {
               A863TaxasId = Z863TaxasId;
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
            if ( A863TaxasId != Z863TaxasId )
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
         context.RollbackDataStores("taxas_bc",pr_default);
         VarsToRow96( bcTaxas) ;
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
         Gx_mode = bcTaxas.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTaxas.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTaxas )
         {
            bcTaxas = (SdtTaxas)(sdt);
            if ( StringUtil.StrCmp(bcTaxas.gxTpr_Mode, "") == 0 )
            {
               bcTaxas.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow96( bcTaxas) ;
            }
            else
            {
               RowToVars96( bcTaxas, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTaxas.gxTpr_Mode, "") == 0 )
            {
               bcTaxas.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars96( bcTaxas, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTaxas Taxas_BC
      {
         get {
            return bcTaxas ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV24Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z866TaxasCreatedAt = (DateTime)(DateTime.MinValue);
         A866TaxasCreatedAt = (DateTime)(DateTime.MinValue);
         Z867TaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         A867TaxasUpdatedAt = (DateTime)(DateTime.MinValue);
         Z872TaxasCreatedName = "";
         A872TaxasCreatedName = "";
         Z873TaxasUpdatedName = "";
         A873TaxasUpdatedName = "";
         BC002Q6_A863TaxasId = new int[1] ;
         BC002Q6_A866TaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Q6_n866TaxasCreatedAt = new bool[] {false} ;
         BC002Q6_A867TaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Q6_n867TaxasUpdatedAt = new bool[] {false} ;
         BC002Q6_A864TaxasPercentual = new decimal[1] ;
         BC002Q6_n864TaxasPercentual = new bool[] {false} ;
         BC002Q6_A894TaxasPercentualAnual = new decimal[1] ;
         BC002Q6_n894TaxasPercentualAnual = new bool[] {false} ;
         BC002Q6_A865TaxasValorMinimo = new decimal[1] ;
         BC002Q6_n865TaxasValorMinimo = new bool[] {false} ;
         BC002Q6_A872TaxasCreatedName = new string[] {""} ;
         BC002Q6_n872TaxasCreatedName = new bool[] {false} ;
         BC002Q6_A873TaxasUpdatedName = new string[] {""} ;
         BC002Q6_n873TaxasUpdatedName = new bool[] {false} ;
         BC002Q6_A868TaxasCreatedBy = new short[1] ;
         BC002Q6_n868TaxasCreatedBy = new bool[] {false} ;
         BC002Q6_A869TaxasUpdatedBy = new short[1] ;
         BC002Q6_n869TaxasUpdatedBy = new bool[] {false} ;
         BC002Q4_A872TaxasCreatedName = new string[] {""} ;
         BC002Q4_n872TaxasCreatedName = new bool[] {false} ;
         BC002Q5_A873TaxasUpdatedName = new string[] {""} ;
         BC002Q5_n873TaxasUpdatedName = new bool[] {false} ;
         BC002Q7_A863TaxasId = new int[1] ;
         BC002Q3_A863TaxasId = new int[1] ;
         BC002Q3_A866TaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Q3_n866TaxasCreatedAt = new bool[] {false} ;
         BC002Q3_A867TaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Q3_n867TaxasUpdatedAt = new bool[] {false} ;
         BC002Q3_A864TaxasPercentual = new decimal[1] ;
         BC002Q3_n864TaxasPercentual = new bool[] {false} ;
         BC002Q3_A894TaxasPercentualAnual = new decimal[1] ;
         BC002Q3_n894TaxasPercentualAnual = new bool[] {false} ;
         BC002Q3_A865TaxasValorMinimo = new decimal[1] ;
         BC002Q3_n865TaxasValorMinimo = new bool[] {false} ;
         BC002Q3_A868TaxasCreatedBy = new short[1] ;
         BC002Q3_n868TaxasCreatedBy = new bool[] {false} ;
         BC002Q3_A869TaxasUpdatedBy = new short[1] ;
         BC002Q3_n869TaxasUpdatedBy = new bool[] {false} ;
         sMode96 = "";
         BC002Q2_A863TaxasId = new int[1] ;
         BC002Q2_A866TaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Q2_n866TaxasCreatedAt = new bool[] {false} ;
         BC002Q2_A867TaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Q2_n867TaxasUpdatedAt = new bool[] {false} ;
         BC002Q2_A864TaxasPercentual = new decimal[1] ;
         BC002Q2_n864TaxasPercentual = new bool[] {false} ;
         BC002Q2_A894TaxasPercentualAnual = new decimal[1] ;
         BC002Q2_n894TaxasPercentualAnual = new bool[] {false} ;
         BC002Q2_A865TaxasValorMinimo = new decimal[1] ;
         BC002Q2_n865TaxasValorMinimo = new bool[] {false} ;
         BC002Q2_A868TaxasCreatedBy = new short[1] ;
         BC002Q2_n868TaxasCreatedBy = new bool[] {false} ;
         BC002Q2_A869TaxasUpdatedBy = new short[1] ;
         BC002Q2_n869TaxasUpdatedBy = new bool[] {false} ;
         BC002Q9_A863TaxasId = new int[1] ;
         BC002Q12_A872TaxasCreatedName = new string[] {""} ;
         BC002Q12_n872TaxasCreatedName = new bool[] {false} ;
         BC002Q13_A873TaxasUpdatedName = new string[] {""} ;
         BC002Q13_n873TaxasUpdatedName = new bool[] {false} ;
         BC002Q14_A863TaxasId = new int[1] ;
         BC002Q14_A866TaxasCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Q14_n866TaxasCreatedAt = new bool[] {false} ;
         BC002Q14_A867TaxasUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Q14_n867TaxasUpdatedAt = new bool[] {false} ;
         BC002Q14_A864TaxasPercentual = new decimal[1] ;
         BC002Q14_n864TaxasPercentual = new bool[] {false} ;
         BC002Q14_A894TaxasPercentualAnual = new decimal[1] ;
         BC002Q14_n894TaxasPercentualAnual = new bool[] {false} ;
         BC002Q14_A865TaxasValorMinimo = new decimal[1] ;
         BC002Q14_n865TaxasValorMinimo = new bool[] {false} ;
         BC002Q14_A872TaxasCreatedName = new string[] {""} ;
         BC002Q14_n872TaxasCreatedName = new bool[] {false} ;
         BC002Q14_A873TaxasUpdatedName = new string[] {""} ;
         BC002Q14_n873TaxasUpdatedName = new bool[] {false} ;
         BC002Q14_A868TaxasCreatedBy = new short[1] ;
         BC002Q14_n868TaxasCreatedBy = new bool[] {false} ;
         BC002Q14_A869TaxasUpdatedBy = new short[1] ;
         BC002Q14_n869TaxasUpdatedBy = new bool[] {false} ;
         i866TaxasCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.taxas_bc__default(),
            new Object[][] {
                new Object[] {
               BC002Q2_A863TaxasId, BC002Q2_A866TaxasCreatedAt, BC002Q2_n866TaxasCreatedAt, BC002Q2_A867TaxasUpdatedAt, BC002Q2_n867TaxasUpdatedAt, BC002Q2_A864TaxasPercentual, BC002Q2_n864TaxasPercentual, BC002Q2_A894TaxasPercentualAnual, BC002Q2_n894TaxasPercentualAnual, BC002Q2_A865TaxasValorMinimo,
               BC002Q2_n865TaxasValorMinimo, BC002Q2_A868TaxasCreatedBy, BC002Q2_n868TaxasCreatedBy, BC002Q2_A869TaxasUpdatedBy, BC002Q2_n869TaxasUpdatedBy
               }
               , new Object[] {
               BC002Q3_A863TaxasId, BC002Q3_A866TaxasCreatedAt, BC002Q3_n866TaxasCreatedAt, BC002Q3_A867TaxasUpdatedAt, BC002Q3_n867TaxasUpdatedAt, BC002Q3_A864TaxasPercentual, BC002Q3_n864TaxasPercentual, BC002Q3_A894TaxasPercentualAnual, BC002Q3_n894TaxasPercentualAnual, BC002Q3_A865TaxasValorMinimo,
               BC002Q3_n865TaxasValorMinimo, BC002Q3_A868TaxasCreatedBy, BC002Q3_n868TaxasCreatedBy, BC002Q3_A869TaxasUpdatedBy, BC002Q3_n869TaxasUpdatedBy
               }
               , new Object[] {
               BC002Q4_A872TaxasCreatedName, BC002Q4_n872TaxasCreatedName
               }
               , new Object[] {
               BC002Q5_A873TaxasUpdatedName, BC002Q5_n873TaxasUpdatedName
               }
               , new Object[] {
               BC002Q6_A863TaxasId, BC002Q6_A866TaxasCreatedAt, BC002Q6_n866TaxasCreatedAt, BC002Q6_A867TaxasUpdatedAt, BC002Q6_n867TaxasUpdatedAt, BC002Q6_A864TaxasPercentual, BC002Q6_n864TaxasPercentual, BC002Q6_A894TaxasPercentualAnual, BC002Q6_n894TaxasPercentualAnual, BC002Q6_A865TaxasValorMinimo,
               BC002Q6_n865TaxasValorMinimo, BC002Q6_A872TaxasCreatedName, BC002Q6_n872TaxasCreatedName, BC002Q6_A873TaxasUpdatedName, BC002Q6_n873TaxasUpdatedName, BC002Q6_A868TaxasCreatedBy, BC002Q6_n868TaxasCreatedBy, BC002Q6_A869TaxasUpdatedBy, BC002Q6_n869TaxasUpdatedBy
               }
               , new Object[] {
               BC002Q7_A863TaxasId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002Q9_A863TaxasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002Q12_A872TaxasCreatedName, BC002Q12_n872TaxasCreatedName
               }
               , new Object[] {
               BC002Q13_A873TaxasUpdatedName, BC002Q13_n873TaxasUpdatedName
               }
               , new Object[] {
               BC002Q14_A863TaxasId, BC002Q14_A866TaxasCreatedAt, BC002Q14_n866TaxasCreatedAt, BC002Q14_A867TaxasUpdatedAt, BC002Q14_n867TaxasUpdatedAt, BC002Q14_A864TaxasPercentual, BC002Q14_n864TaxasPercentual, BC002Q14_A894TaxasPercentualAnual, BC002Q14_n894TaxasPercentualAnual, BC002Q14_A865TaxasValorMinimo,
               BC002Q14_n865TaxasValorMinimo, BC002Q14_A872TaxasCreatedName, BC002Q14_n872TaxasCreatedName, BC002Q14_A873TaxasUpdatedName, BC002Q14_n873TaxasUpdatedName, BC002Q14_A868TaxasCreatedBy, BC002Q14_n868TaxasCreatedBy, BC002Q14_A869TaxasUpdatedBy, BC002Q14_n869TaxasUpdatedBy
               }
            }
         );
         AV24Pgmname = "Taxas_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122Q2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV11Insert_TaxasCreatedBy ;
      private short AV12Insert_TaxasUpdatedBy ;
      private short Z868TaxasCreatedBy ;
      private short A868TaxasCreatedBy ;
      private short Z869TaxasUpdatedBy ;
      private short A869TaxasUpdatedBy ;
      private short RcdFound96 ;
      private int trnEnded ;
      private int Z863TaxasId ;
      private int A863TaxasId ;
      private int AV25GXV1 ;
      private decimal Z864TaxasPercentual ;
      private decimal A864TaxasPercentual ;
      private decimal Z894TaxasPercentualAnual ;
      private decimal A894TaxasPercentualAnual ;
      private decimal Z865TaxasValorMinimo ;
      private decimal A865TaxasValorMinimo ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV24Pgmname ;
      private string sMode96 ;
      private DateTime Z866TaxasCreatedAt ;
      private DateTime A866TaxasCreatedAt ;
      private DateTime Z867TaxasUpdatedAt ;
      private DateTime A867TaxasUpdatedAt ;
      private DateTime i866TaxasCreatedAt ;
      private bool returnInSub ;
      private bool n866TaxasCreatedAt ;
      private bool n867TaxasUpdatedAt ;
      private bool n864TaxasPercentual ;
      private bool n894TaxasPercentualAnual ;
      private bool n865TaxasValorMinimo ;
      private bool n872TaxasCreatedName ;
      private bool n873TaxasUpdatedName ;
      private bool n868TaxasCreatedBy ;
      private bool n869TaxasUpdatedBy ;
      private bool Gx_longc ;
      private string Z872TaxasCreatedName ;
      private string A872TaxasCreatedName ;
      private string Z873TaxasUpdatedName ;
      private string A873TaxasUpdatedName ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002Q6_A863TaxasId ;
      private DateTime[] BC002Q6_A866TaxasCreatedAt ;
      private bool[] BC002Q6_n866TaxasCreatedAt ;
      private DateTime[] BC002Q6_A867TaxasUpdatedAt ;
      private bool[] BC002Q6_n867TaxasUpdatedAt ;
      private decimal[] BC002Q6_A864TaxasPercentual ;
      private bool[] BC002Q6_n864TaxasPercentual ;
      private decimal[] BC002Q6_A894TaxasPercentualAnual ;
      private bool[] BC002Q6_n894TaxasPercentualAnual ;
      private decimal[] BC002Q6_A865TaxasValorMinimo ;
      private bool[] BC002Q6_n865TaxasValorMinimo ;
      private string[] BC002Q6_A872TaxasCreatedName ;
      private bool[] BC002Q6_n872TaxasCreatedName ;
      private string[] BC002Q6_A873TaxasUpdatedName ;
      private bool[] BC002Q6_n873TaxasUpdatedName ;
      private short[] BC002Q6_A868TaxasCreatedBy ;
      private bool[] BC002Q6_n868TaxasCreatedBy ;
      private short[] BC002Q6_A869TaxasUpdatedBy ;
      private bool[] BC002Q6_n869TaxasUpdatedBy ;
      private string[] BC002Q4_A872TaxasCreatedName ;
      private bool[] BC002Q4_n872TaxasCreatedName ;
      private string[] BC002Q5_A873TaxasUpdatedName ;
      private bool[] BC002Q5_n873TaxasUpdatedName ;
      private int[] BC002Q7_A863TaxasId ;
      private int[] BC002Q3_A863TaxasId ;
      private DateTime[] BC002Q3_A866TaxasCreatedAt ;
      private bool[] BC002Q3_n866TaxasCreatedAt ;
      private DateTime[] BC002Q3_A867TaxasUpdatedAt ;
      private bool[] BC002Q3_n867TaxasUpdatedAt ;
      private decimal[] BC002Q3_A864TaxasPercentual ;
      private bool[] BC002Q3_n864TaxasPercentual ;
      private decimal[] BC002Q3_A894TaxasPercentualAnual ;
      private bool[] BC002Q3_n894TaxasPercentualAnual ;
      private decimal[] BC002Q3_A865TaxasValorMinimo ;
      private bool[] BC002Q3_n865TaxasValorMinimo ;
      private short[] BC002Q3_A868TaxasCreatedBy ;
      private bool[] BC002Q3_n868TaxasCreatedBy ;
      private short[] BC002Q3_A869TaxasUpdatedBy ;
      private bool[] BC002Q3_n869TaxasUpdatedBy ;
      private int[] BC002Q2_A863TaxasId ;
      private DateTime[] BC002Q2_A866TaxasCreatedAt ;
      private bool[] BC002Q2_n866TaxasCreatedAt ;
      private DateTime[] BC002Q2_A867TaxasUpdatedAt ;
      private bool[] BC002Q2_n867TaxasUpdatedAt ;
      private decimal[] BC002Q2_A864TaxasPercentual ;
      private bool[] BC002Q2_n864TaxasPercentual ;
      private decimal[] BC002Q2_A894TaxasPercentualAnual ;
      private bool[] BC002Q2_n894TaxasPercentualAnual ;
      private decimal[] BC002Q2_A865TaxasValorMinimo ;
      private bool[] BC002Q2_n865TaxasValorMinimo ;
      private short[] BC002Q2_A868TaxasCreatedBy ;
      private bool[] BC002Q2_n868TaxasCreatedBy ;
      private short[] BC002Q2_A869TaxasUpdatedBy ;
      private bool[] BC002Q2_n869TaxasUpdatedBy ;
      private int[] BC002Q9_A863TaxasId ;
      private string[] BC002Q12_A872TaxasCreatedName ;
      private bool[] BC002Q12_n872TaxasCreatedName ;
      private string[] BC002Q13_A873TaxasUpdatedName ;
      private bool[] BC002Q13_n873TaxasUpdatedName ;
      private int[] BC002Q14_A863TaxasId ;
      private DateTime[] BC002Q14_A866TaxasCreatedAt ;
      private bool[] BC002Q14_n866TaxasCreatedAt ;
      private DateTime[] BC002Q14_A867TaxasUpdatedAt ;
      private bool[] BC002Q14_n867TaxasUpdatedAt ;
      private decimal[] BC002Q14_A864TaxasPercentual ;
      private bool[] BC002Q14_n864TaxasPercentual ;
      private decimal[] BC002Q14_A894TaxasPercentualAnual ;
      private bool[] BC002Q14_n894TaxasPercentualAnual ;
      private decimal[] BC002Q14_A865TaxasValorMinimo ;
      private bool[] BC002Q14_n865TaxasValorMinimo ;
      private string[] BC002Q14_A872TaxasCreatedName ;
      private bool[] BC002Q14_n872TaxasCreatedName ;
      private string[] BC002Q14_A873TaxasUpdatedName ;
      private bool[] BC002Q14_n873TaxasUpdatedName ;
      private short[] BC002Q14_A868TaxasCreatedBy ;
      private bool[] BC002Q14_n868TaxasCreatedBy ;
      private short[] BC002Q14_A869TaxasUpdatedBy ;
      private bool[] BC002Q14_n869TaxasUpdatedBy ;
      private SdtTaxas bcTaxas ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class taxas_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002Q2;
          prmBC002Q2 = new Object[] {
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmBC002Q3;
          prmBC002Q3 = new Object[] {
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmBC002Q4;
          prmBC002Q4 = new Object[] {
          new ParDef("TaxasCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Q5;
          prmBC002Q5 = new Object[] {
          new ParDef("TaxasUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Q6;
          prmBC002Q6 = new Object[] {
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmBC002Q7;
          prmBC002Q7 = new Object[] {
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmBC002Q8;
          prmBC002Q8 = new Object[] {
          new ParDef("TaxasCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TaxasUpdatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TaxasPercentual",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TaxasPercentualAnual",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TaxasValorMinimo",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TaxasCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TaxasUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Q9;
          prmBC002Q9 = new Object[] {
          };
          Object[] prmBC002Q10;
          prmBC002Q10 = new Object[] {
          new ParDef("TaxasCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TaxasUpdatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TaxasPercentual",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TaxasPercentualAnual",GXType.Number,16,4){Nullable=true} ,
          new ParDef("TaxasValorMinimo",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TaxasCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TaxasUpdatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmBC002Q11;
          prmBC002Q11 = new Object[] {
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          Object[] prmBC002Q12;
          prmBC002Q12 = new Object[] {
          new ParDef("TaxasCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Q13;
          prmBC002Q13 = new Object[] {
          new ParDef("TaxasUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Q14;
          prmBC002Q14 = new Object[] {
          new ParDef("TaxasId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002Q2", "SELECT TaxasId, TaxasCreatedAt, TaxasUpdatedAt, TaxasPercentual, TaxasPercentualAnual, TaxasValorMinimo, TaxasCreatedBy, TaxasUpdatedBy FROM Taxas WHERE TaxasId = :TaxasId  FOR UPDATE OF Taxas",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Q2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Q3", "SELECT TaxasId, TaxasCreatedAt, TaxasUpdatedAt, TaxasPercentual, TaxasPercentualAnual, TaxasValorMinimo, TaxasCreatedBy, TaxasUpdatedBy FROM Taxas WHERE TaxasId = :TaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Q3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Q4", "SELECT SecUserFullName AS TaxasCreatedName FROM SecUser WHERE SecUserId = :TaxasCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Q4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Q5", "SELECT SecUserFullName AS TaxasUpdatedName FROM SecUser WHERE SecUserId = :TaxasUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Q5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Q6", "SELECT TM1.TaxasId, TM1.TaxasCreatedAt, TM1.TaxasUpdatedAt, TM1.TaxasPercentual, TM1.TaxasPercentualAnual, TM1.TaxasValorMinimo, T2.SecUserFullName AS TaxasCreatedName, T3.SecUserFullName AS TaxasUpdatedName, TM1.TaxasCreatedBy AS TaxasCreatedBy, TM1.TaxasUpdatedBy AS TaxasUpdatedBy FROM ((Taxas TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.TaxasCreatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = TM1.TaxasUpdatedBy) WHERE TM1.TaxasId = :TaxasId ORDER BY TM1.TaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Q6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Q7", "SELECT TaxasId FROM Taxas WHERE TaxasId = :TaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Q7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Q8", "SAVEPOINT gxupdate;INSERT INTO Taxas(TaxasCreatedAt, TaxasUpdatedAt, TaxasPercentual, TaxasPercentualAnual, TaxasValorMinimo, TaxasCreatedBy, TaxasUpdatedBy) VALUES(:TaxasCreatedAt, :TaxasUpdatedAt, :TaxasPercentual, :TaxasPercentualAnual, :TaxasValorMinimo, :TaxasCreatedBy, :TaxasUpdatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002Q8)
             ,new CursorDef("BC002Q9", "SELECT currval('TaxasId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Q9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Q10", "SAVEPOINT gxupdate;UPDATE Taxas SET TaxasCreatedAt=:TaxasCreatedAt, TaxasUpdatedAt=:TaxasUpdatedAt, TaxasPercentual=:TaxasPercentual, TaxasPercentualAnual=:TaxasPercentualAnual, TaxasValorMinimo=:TaxasValorMinimo, TaxasCreatedBy=:TaxasCreatedBy, TaxasUpdatedBy=:TaxasUpdatedBy  WHERE TaxasId = :TaxasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002Q10)
             ,new CursorDef("BC002Q11", "SAVEPOINT gxupdate;DELETE FROM Taxas  WHERE TaxasId = :TaxasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002Q11)
             ,new CursorDef("BC002Q12", "SELECT SecUserFullName AS TaxasCreatedName FROM SecUser WHERE SecUserId = :TaxasCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Q12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Q13", "SELECT SecUserFullName AS TaxasUpdatedName FROM SecUser WHERE SecUserId = :TaxasUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Q13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Q14", "SELECT TM1.TaxasId, TM1.TaxasCreatedAt, TM1.TaxasUpdatedAt, TM1.TaxasPercentual, TM1.TaxasPercentualAnual, TM1.TaxasValorMinimo, T2.SecUserFullName AS TaxasCreatedName, T3.SecUserFullName AS TaxasUpdatedName, TM1.TaxasCreatedBy AS TaxasCreatedBy, TM1.TaxasUpdatedBy AS TaxasUpdatedBy FROM ((Taxas TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.TaxasCreatedBy) LEFT JOIN SecUser T3 ON T3.SecUserId = TM1.TaxasUpdatedBy) WHERE TM1.TaxasId = :TaxasId ORDER BY TM1.TaxasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Q14,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
