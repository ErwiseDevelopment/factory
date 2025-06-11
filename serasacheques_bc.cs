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
   public class serasacheques_bc : GxSilentTrn, IGxSilentTrn
   {
      public serasacheques_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasacheques_bc( IGxContext context )
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
         ReadRow2F85( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2F85( ) ;
         standaloneModal( ) ;
         AddRow2F85( ) ;
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
            E112F2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z693SerasaChequesId = A693SerasaChequesId;
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

      protected void CONFIRM_2F0( )
      {
         BeforeValidate2F85( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2F85( ) ;
            }
            else
            {
               CheckExtendedTable2F85( ) ;
               if ( AnyError == 0 )
               {
                  ZM2F85( 5) ;
               }
               CloseExtendedTableCursors2F85( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122F2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV19Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV20GXV1 = 1;
            while ( AV20GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV20GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "SerasaId") == 0 )
               {
                  AV11Insert_SerasaId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV20GXV1 = (int)(AV20GXV1+1);
            }
         }
      }

      protected void E112F2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2F85( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z694SerasaChequesTotalCons = A694SerasaChequesTotalCons;
            Z695SerasaChequesQtdSemFundo = A695SerasaChequesQtdSemFundo;
            Z696SerasaChequesUltOcorSus = A696SerasaChequesUltOcorSus;
            Z697SerasaChequesValorSemFundo = A697SerasaChequesValorSemFundo;
            Z698SerasaChequesTotalSust = A698SerasaChequesTotalSust;
            Z662SerasaId = A662SerasaId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -4 )
         {
            Z693SerasaChequesId = A693SerasaChequesId;
            Z694SerasaChequesTotalCons = A694SerasaChequesTotalCons;
            Z695SerasaChequesQtdSemFundo = A695SerasaChequesQtdSemFundo;
            Z696SerasaChequesUltOcorSus = A696SerasaChequesUltOcorSus;
            Z697SerasaChequesValorSemFundo = A697SerasaChequesValorSemFundo;
            Z698SerasaChequesTotalSust = A698SerasaChequesTotalSust;
            Z662SerasaId = A662SerasaId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV19Pgmname = "SerasaCheques_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2F85( )
      {
         /* Using cursor BC002F5 */
         pr_default.execute(3, new Object[] {A693SerasaChequesId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound85 = 1;
            A694SerasaChequesTotalCons = BC002F5_A694SerasaChequesTotalCons[0];
            n694SerasaChequesTotalCons = BC002F5_n694SerasaChequesTotalCons[0];
            A695SerasaChequesQtdSemFundo = BC002F5_A695SerasaChequesQtdSemFundo[0];
            n695SerasaChequesQtdSemFundo = BC002F5_n695SerasaChequesQtdSemFundo[0];
            A696SerasaChequesUltOcorSus = BC002F5_A696SerasaChequesUltOcorSus[0];
            n696SerasaChequesUltOcorSus = BC002F5_n696SerasaChequesUltOcorSus[0];
            A697SerasaChequesValorSemFundo = BC002F5_A697SerasaChequesValorSemFundo[0];
            n697SerasaChequesValorSemFundo = BC002F5_n697SerasaChequesValorSemFundo[0];
            A698SerasaChequesTotalSust = BC002F5_A698SerasaChequesTotalSust[0];
            n698SerasaChequesTotalSust = BC002F5_n698SerasaChequesTotalSust[0];
            A662SerasaId = BC002F5_A662SerasaId[0];
            n662SerasaId = BC002F5_n662SerasaId[0];
            ZM2F85( -4) ;
         }
         pr_default.close(3);
         OnLoadActions2F85( ) ;
      }

      protected void OnLoadActions2F85( )
      {
      }

      protected void CheckExtendedTable2F85( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002F4 */
         pr_default.execute(2, new Object[] {n662SerasaId, A662SerasaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A662SerasaId) ) )
            {
               GX_msglist.addItem("Não existe 'Serasa'.", "ForeignKeyNotFound", 1, "SERASAID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         if ( ( A697SerasaChequesValorSemFundo < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2F85( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2F85( )
      {
         /* Using cursor BC002F6 */
         pr_default.execute(4, new Object[] {A693SerasaChequesId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound85 = 1;
         }
         else
         {
            RcdFound85 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002F3 */
         pr_default.execute(1, new Object[] {A693SerasaChequesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2F85( 4) ;
            RcdFound85 = 1;
            A693SerasaChequesId = BC002F3_A693SerasaChequesId[0];
            A694SerasaChequesTotalCons = BC002F3_A694SerasaChequesTotalCons[0];
            n694SerasaChequesTotalCons = BC002F3_n694SerasaChequesTotalCons[0];
            A695SerasaChequesQtdSemFundo = BC002F3_A695SerasaChequesQtdSemFundo[0];
            n695SerasaChequesQtdSemFundo = BC002F3_n695SerasaChequesQtdSemFundo[0];
            A696SerasaChequesUltOcorSus = BC002F3_A696SerasaChequesUltOcorSus[0];
            n696SerasaChequesUltOcorSus = BC002F3_n696SerasaChequesUltOcorSus[0];
            A697SerasaChequesValorSemFundo = BC002F3_A697SerasaChequesValorSemFundo[0];
            n697SerasaChequesValorSemFundo = BC002F3_n697SerasaChequesValorSemFundo[0];
            A698SerasaChequesTotalSust = BC002F3_A698SerasaChequesTotalSust[0];
            n698SerasaChequesTotalSust = BC002F3_n698SerasaChequesTotalSust[0];
            A662SerasaId = BC002F3_A662SerasaId[0];
            n662SerasaId = BC002F3_n662SerasaId[0];
            Z693SerasaChequesId = A693SerasaChequesId;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2F85( ) ;
            if ( AnyError == 1 )
            {
               RcdFound85 = 0;
               InitializeNonKey2F85( ) ;
            }
            Gx_mode = sMode85;
         }
         else
         {
            RcdFound85 = 0;
            InitializeNonKey2F85( ) ;
            sMode85 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode85;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2F85( ) ;
         if ( RcdFound85 == 0 )
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
         CONFIRM_2F0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2F85( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002F2 */
            pr_default.execute(0, new Object[] {A693SerasaChequesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaCheques"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z694SerasaChequesTotalCons != BC002F2_A694SerasaChequesTotalCons[0] ) || ( Z695SerasaChequesQtdSemFundo != BC002F2_A695SerasaChequesQtdSemFundo[0] ) || ( DateTimeUtil.ResetTime ( Z696SerasaChequesUltOcorSus ) != DateTimeUtil.ResetTime ( BC002F2_A696SerasaChequesUltOcorSus[0] ) ) || ( Z697SerasaChequesValorSemFundo != BC002F2_A697SerasaChequesValorSemFundo[0] ) || ( Z698SerasaChequesTotalSust != BC002F2_A698SerasaChequesTotalSust[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z662SerasaId != BC002F2_A662SerasaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SerasaCheques"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2F85( )
      {
         BeforeValidate2F85( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2F85( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2F85( 0) ;
            CheckOptimisticConcurrency2F85( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2F85( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2F85( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002F7 */
                     pr_default.execute(5, new Object[] {n694SerasaChequesTotalCons, A694SerasaChequesTotalCons, n695SerasaChequesQtdSemFundo, A695SerasaChequesQtdSemFundo, n696SerasaChequesUltOcorSus, A696SerasaChequesUltOcorSus, n697SerasaChequesValorSemFundo, A697SerasaChequesValorSemFundo, n698SerasaChequesTotalSust, A698SerasaChequesTotalSust, n662SerasaId, A662SerasaId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002F8 */
                     pr_default.execute(6);
                     A693SerasaChequesId = BC002F8_A693SerasaChequesId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaCheques");
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
               Load2F85( ) ;
            }
            EndLevel2F85( ) ;
         }
         CloseExtendedTableCursors2F85( ) ;
      }

      protected void Update2F85( )
      {
         BeforeValidate2F85( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2F85( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2F85( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2F85( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2F85( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002F9 */
                     pr_default.execute(7, new Object[] {n694SerasaChequesTotalCons, A694SerasaChequesTotalCons, n695SerasaChequesQtdSemFundo, A695SerasaChequesQtdSemFundo, n696SerasaChequesUltOcorSus, A696SerasaChequesUltOcorSus, n697SerasaChequesValorSemFundo, A697SerasaChequesValorSemFundo, n698SerasaChequesTotalSust, A698SerasaChequesTotalSust, n662SerasaId, A662SerasaId, A693SerasaChequesId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaCheques");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaCheques"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2F85( ) ;
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
            EndLevel2F85( ) ;
         }
         CloseExtendedTableCursors2F85( ) ;
      }

      protected void DeferredUpdate2F85( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2F85( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2F85( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2F85( ) ;
            AfterConfirm2F85( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2F85( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002F10 */
                  pr_default.execute(8, new Object[] {A693SerasaChequesId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("SerasaCheques");
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
         sMode85 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2F85( ) ;
         Gx_mode = sMode85;
      }

      protected void OnDeleteControls2F85( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2F85( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2F85( ) ;
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

      public void ScanKeyStart2F85( )
      {
         /* Scan By routine */
         /* Using cursor BC002F11 */
         pr_default.execute(9, new Object[] {A693SerasaChequesId});
         RcdFound85 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound85 = 1;
            A693SerasaChequesId = BC002F11_A693SerasaChequesId[0];
            A694SerasaChequesTotalCons = BC002F11_A694SerasaChequesTotalCons[0];
            n694SerasaChequesTotalCons = BC002F11_n694SerasaChequesTotalCons[0];
            A695SerasaChequesQtdSemFundo = BC002F11_A695SerasaChequesQtdSemFundo[0];
            n695SerasaChequesQtdSemFundo = BC002F11_n695SerasaChequesQtdSemFundo[0];
            A696SerasaChequesUltOcorSus = BC002F11_A696SerasaChequesUltOcorSus[0];
            n696SerasaChequesUltOcorSus = BC002F11_n696SerasaChequesUltOcorSus[0];
            A697SerasaChequesValorSemFundo = BC002F11_A697SerasaChequesValorSemFundo[0];
            n697SerasaChequesValorSemFundo = BC002F11_n697SerasaChequesValorSemFundo[0];
            A698SerasaChequesTotalSust = BC002F11_A698SerasaChequesTotalSust[0];
            n698SerasaChequesTotalSust = BC002F11_n698SerasaChequesTotalSust[0];
            A662SerasaId = BC002F11_A662SerasaId[0];
            n662SerasaId = BC002F11_n662SerasaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2F85( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound85 = 0;
         ScanKeyLoad2F85( ) ;
      }

      protected void ScanKeyLoad2F85( )
      {
         sMode85 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound85 = 1;
            A693SerasaChequesId = BC002F11_A693SerasaChequesId[0];
            A694SerasaChequesTotalCons = BC002F11_A694SerasaChequesTotalCons[0];
            n694SerasaChequesTotalCons = BC002F11_n694SerasaChequesTotalCons[0];
            A695SerasaChequesQtdSemFundo = BC002F11_A695SerasaChequesQtdSemFundo[0];
            n695SerasaChequesQtdSemFundo = BC002F11_n695SerasaChequesQtdSemFundo[0];
            A696SerasaChequesUltOcorSus = BC002F11_A696SerasaChequesUltOcorSus[0];
            n696SerasaChequesUltOcorSus = BC002F11_n696SerasaChequesUltOcorSus[0];
            A697SerasaChequesValorSemFundo = BC002F11_A697SerasaChequesValorSemFundo[0];
            n697SerasaChequesValorSemFundo = BC002F11_n697SerasaChequesValorSemFundo[0];
            A698SerasaChequesTotalSust = BC002F11_A698SerasaChequesTotalSust[0];
            n698SerasaChequesTotalSust = BC002F11_n698SerasaChequesTotalSust[0];
            A662SerasaId = BC002F11_A662SerasaId[0];
            n662SerasaId = BC002F11_n662SerasaId[0];
         }
         Gx_mode = sMode85;
      }

      protected void ScanKeyEnd2F85( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm2F85( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2F85( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2F85( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2F85( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2F85( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2F85( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2F85( )
      {
      }

      protected void send_integrity_lvl_hashes2F85( )
      {
      }

      protected void AddRow2F85( )
      {
         VarsToRow85( bcSerasaCheques) ;
      }

      protected void ReadRow2F85( )
      {
         RowToVars85( bcSerasaCheques, 1) ;
      }

      protected void InitializeNonKey2F85( )
      {
         A662SerasaId = 0;
         n662SerasaId = false;
         A694SerasaChequesTotalCons = 0;
         n694SerasaChequesTotalCons = false;
         A695SerasaChequesQtdSemFundo = 0;
         n695SerasaChequesQtdSemFundo = false;
         A696SerasaChequesUltOcorSus = DateTime.MinValue;
         n696SerasaChequesUltOcorSus = false;
         A697SerasaChequesValorSemFundo = 0;
         n697SerasaChequesValorSemFundo = false;
         A698SerasaChequesTotalSust = 0;
         n698SerasaChequesTotalSust = false;
         Z694SerasaChequesTotalCons = 0;
         Z695SerasaChequesQtdSemFundo = 0;
         Z696SerasaChequesUltOcorSus = DateTime.MinValue;
         Z697SerasaChequesValorSemFundo = 0;
         Z698SerasaChequesTotalSust = 0;
         Z662SerasaId = 0;
      }

      protected void InitAll2F85( )
      {
         A693SerasaChequesId = 0;
         InitializeNonKey2F85( ) ;
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

      public void VarsToRow85( SdtSerasaCheques obj85 )
      {
         obj85.gxTpr_Mode = Gx_mode;
         obj85.gxTpr_Serasaid = A662SerasaId;
         obj85.gxTpr_Serasachequestotalcons = A694SerasaChequesTotalCons;
         obj85.gxTpr_Serasachequesqtdsemfundo = A695SerasaChequesQtdSemFundo;
         obj85.gxTpr_Serasachequesultocorsus = A696SerasaChequesUltOcorSus;
         obj85.gxTpr_Serasachequesvalorsemfundo = A697SerasaChequesValorSemFundo;
         obj85.gxTpr_Serasachequestotalsust = A698SerasaChequesTotalSust;
         obj85.gxTpr_Serasachequesid = A693SerasaChequesId;
         obj85.gxTpr_Serasachequesid_Z = Z693SerasaChequesId;
         obj85.gxTpr_Serasaid_Z = Z662SerasaId;
         obj85.gxTpr_Serasachequestotalcons_Z = Z694SerasaChequesTotalCons;
         obj85.gxTpr_Serasachequesqtdsemfundo_Z = Z695SerasaChequesQtdSemFundo;
         obj85.gxTpr_Serasachequesultocorsus_Z = Z696SerasaChequesUltOcorSus;
         obj85.gxTpr_Serasachequesvalorsemfundo_Z = Z697SerasaChequesValorSemFundo;
         obj85.gxTpr_Serasachequestotalsust_Z = Z698SerasaChequesTotalSust;
         obj85.gxTpr_Serasaid_N = (short)(Convert.ToInt16(n662SerasaId));
         obj85.gxTpr_Serasachequestotalcons_N = (short)(Convert.ToInt16(n694SerasaChequesTotalCons));
         obj85.gxTpr_Serasachequesqtdsemfundo_N = (short)(Convert.ToInt16(n695SerasaChequesQtdSemFundo));
         obj85.gxTpr_Serasachequesultocorsus_N = (short)(Convert.ToInt16(n696SerasaChequesUltOcorSus));
         obj85.gxTpr_Serasachequesvalorsemfundo_N = (short)(Convert.ToInt16(n697SerasaChequesValorSemFundo));
         obj85.gxTpr_Serasachequestotalsust_N = (short)(Convert.ToInt16(n698SerasaChequesTotalSust));
         obj85.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow85( SdtSerasaCheques obj85 )
      {
         obj85.gxTpr_Serasachequesid = A693SerasaChequesId;
         return  ;
      }

      public void RowToVars85( SdtSerasaCheques obj85 ,
                               int forceLoad )
      {
         Gx_mode = obj85.gxTpr_Mode;
         A662SerasaId = obj85.gxTpr_Serasaid;
         n662SerasaId = false;
         A694SerasaChequesTotalCons = obj85.gxTpr_Serasachequestotalcons;
         n694SerasaChequesTotalCons = false;
         A695SerasaChequesQtdSemFundo = obj85.gxTpr_Serasachequesqtdsemfundo;
         n695SerasaChequesQtdSemFundo = false;
         A696SerasaChequesUltOcorSus = obj85.gxTpr_Serasachequesultocorsus;
         n696SerasaChequesUltOcorSus = false;
         A697SerasaChequesValorSemFundo = obj85.gxTpr_Serasachequesvalorsemfundo;
         n697SerasaChequesValorSemFundo = false;
         A698SerasaChequesTotalSust = obj85.gxTpr_Serasachequestotalsust;
         n698SerasaChequesTotalSust = false;
         A693SerasaChequesId = obj85.gxTpr_Serasachequesid;
         Z693SerasaChequesId = obj85.gxTpr_Serasachequesid_Z;
         Z662SerasaId = obj85.gxTpr_Serasaid_Z;
         Z694SerasaChequesTotalCons = obj85.gxTpr_Serasachequestotalcons_Z;
         Z695SerasaChequesQtdSemFundo = obj85.gxTpr_Serasachequesqtdsemfundo_Z;
         Z696SerasaChequesUltOcorSus = obj85.gxTpr_Serasachequesultocorsus_Z;
         Z697SerasaChequesValorSemFundo = obj85.gxTpr_Serasachequesvalorsemfundo_Z;
         Z698SerasaChequesTotalSust = obj85.gxTpr_Serasachequestotalsust_Z;
         n662SerasaId = (bool)(Convert.ToBoolean(obj85.gxTpr_Serasaid_N));
         n694SerasaChequesTotalCons = (bool)(Convert.ToBoolean(obj85.gxTpr_Serasachequestotalcons_N));
         n695SerasaChequesQtdSemFundo = (bool)(Convert.ToBoolean(obj85.gxTpr_Serasachequesqtdsemfundo_N));
         n696SerasaChequesUltOcorSus = (bool)(Convert.ToBoolean(obj85.gxTpr_Serasachequesultocorsus_N));
         n697SerasaChequesValorSemFundo = (bool)(Convert.ToBoolean(obj85.gxTpr_Serasachequesvalorsemfundo_N));
         n698SerasaChequesTotalSust = (bool)(Convert.ToBoolean(obj85.gxTpr_Serasachequestotalsust_N));
         Gx_mode = obj85.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A693SerasaChequesId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2F85( ) ;
         ScanKeyStart2F85( ) ;
         if ( RcdFound85 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z693SerasaChequesId = A693SerasaChequesId;
         }
         ZM2F85( -4) ;
         OnLoadActions2F85( ) ;
         AddRow2F85( ) ;
         ScanKeyEnd2F85( ) ;
         if ( RcdFound85 == 0 )
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
         RowToVars85( bcSerasaCheques, 0) ;
         ScanKeyStart2F85( ) ;
         if ( RcdFound85 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z693SerasaChequesId = A693SerasaChequesId;
         }
         ZM2F85( -4) ;
         OnLoadActions2F85( ) ;
         AddRow2F85( ) ;
         ScanKeyEnd2F85( ) ;
         if ( RcdFound85 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2F85( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2F85( ) ;
         }
         else
         {
            if ( RcdFound85 == 1 )
            {
               if ( A693SerasaChequesId != Z693SerasaChequesId )
               {
                  A693SerasaChequesId = Z693SerasaChequesId;
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
                  Update2F85( ) ;
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
                  if ( A693SerasaChequesId != Z693SerasaChequesId )
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
                        Insert2F85( ) ;
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
                        Insert2F85( ) ;
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
         RowToVars85( bcSerasaCheques, 1) ;
         SaveImpl( ) ;
         VarsToRow85( bcSerasaCheques) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars85( bcSerasaCheques, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2F85( ) ;
         AfterTrn( ) ;
         VarsToRow85( bcSerasaCheques) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow85( bcSerasaCheques) ;
         }
         else
         {
            SdtSerasaCheques auxBC = new SdtSerasaCheques(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A693SerasaChequesId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSerasaCheques);
               auxBC.Save();
               bcSerasaCheques.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars85( bcSerasaCheques, 1) ;
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
         RowToVars85( bcSerasaCheques, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2F85( ) ;
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
               VarsToRow85( bcSerasaCheques) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow85( bcSerasaCheques) ;
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
         RowToVars85( bcSerasaCheques, 0) ;
         GetKey2F85( ) ;
         if ( RcdFound85 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A693SerasaChequesId != Z693SerasaChequesId )
            {
               A693SerasaChequesId = Z693SerasaChequesId;
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
            if ( A693SerasaChequesId != Z693SerasaChequesId )
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
         context.RollbackDataStores("serasacheques_bc",pr_default);
         VarsToRow85( bcSerasaCheques) ;
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
         Gx_mode = bcSerasaCheques.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSerasaCheques.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSerasaCheques )
         {
            bcSerasaCheques = (SdtSerasaCheques)(sdt);
            if ( StringUtil.StrCmp(bcSerasaCheques.gxTpr_Mode, "") == 0 )
            {
               bcSerasaCheques.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow85( bcSerasaCheques) ;
            }
            else
            {
               RowToVars85( bcSerasaCheques, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSerasaCheques.gxTpr_Mode, "") == 0 )
            {
               bcSerasaCheques.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars85( bcSerasaCheques, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSerasaCheques SerasaCheques_BC
      {
         get {
            return bcSerasaCheques ;
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
         AV19Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z696SerasaChequesUltOcorSus = DateTime.MinValue;
         A696SerasaChequesUltOcorSus = DateTime.MinValue;
         BC002F5_A693SerasaChequesId = new int[1] ;
         BC002F5_A694SerasaChequesTotalCons = new decimal[1] ;
         BC002F5_n694SerasaChequesTotalCons = new bool[] {false} ;
         BC002F5_A695SerasaChequesQtdSemFundo = new decimal[1] ;
         BC002F5_n695SerasaChequesQtdSemFundo = new bool[] {false} ;
         BC002F5_A696SerasaChequesUltOcorSus = new DateTime[] {DateTime.MinValue} ;
         BC002F5_n696SerasaChequesUltOcorSus = new bool[] {false} ;
         BC002F5_A697SerasaChequesValorSemFundo = new decimal[1] ;
         BC002F5_n697SerasaChequesValorSemFundo = new bool[] {false} ;
         BC002F5_A698SerasaChequesTotalSust = new decimal[1] ;
         BC002F5_n698SerasaChequesTotalSust = new bool[] {false} ;
         BC002F5_A662SerasaId = new int[1] ;
         BC002F5_n662SerasaId = new bool[] {false} ;
         BC002F4_A662SerasaId = new int[1] ;
         BC002F4_n662SerasaId = new bool[] {false} ;
         BC002F6_A693SerasaChequesId = new int[1] ;
         BC002F3_A693SerasaChequesId = new int[1] ;
         BC002F3_A694SerasaChequesTotalCons = new decimal[1] ;
         BC002F3_n694SerasaChequesTotalCons = new bool[] {false} ;
         BC002F3_A695SerasaChequesQtdSemFundo = new decimal[1] ;
         BC002F3_n695SerasaChequesQtdSemFundo = new bool[] {false} ;
         BC002F3_A696SerasaChequesUltOcorSus = new DateTime[] {DateTime.MinValue} ;
         BC002F3_n696SerasaChequesUltOcorSus = new bool[] {false} ;
         BC002F3_A697SerasaChequesValorSemFundo = new decimal[1] ;
         BC002F3_n697SerasaChequesValorSemFundo = new bool[] {false} ;
         BC002F3_A698SerasaChequesTotalSust = new decimal[1] ;
         BC002F3_n698SerasaChequesTotalSust = new bool[] {false} ;
         BC002F3_A662SerasaId = new int[1] ;
         BC002F3_n662SerasaId = new bool[] {false} ;
         sMode85 = "";
         BC002F2_A693SerasaChequesId = new int[1] ;
         BC002F2_A694SerasaChequesTotalCons = new decimal[1] ;
         BC002F2_n694SerasaChequesTotalCons = new bool[] {false} ;
         BC002F2_A695SerasaChequesQtdSemFundo = new decimal[1] ;
         BC002F2_n695SerasaChequesQtdSemFundo = new bool[] {false} ;
         BC002F2_A696SerasaChequesUltOcorSus = new DateTime[] {DateTime.MinValue} ;
         BC002F2_n696SerasaChequesUltOcorSus = new bool[] {false} ;
         BC002F2_A697SerasaChequesValorSemFundo = new decimal[1] ;
         BC002F2_n697SerasaChequesValorSemFundo = new bool[] {false} ;
         BC002F2_A698SerasaChequesTotalSust = new decimal[1] ;
         BC002F2_n698SerasaChequesTotalSust = new bool[] {false} ;
         BC002F2_A662SerasaId = new int[1] ;
         BC002F2_n662SerasaId = new bool[] {false} ;
         BC002F8_A693SerasaChequesId = new int[1] ;
         BC002F11_A693SerasaChequesId = new int[1] ;
         BC002F11_A694SerasaChequesTotalCons = new decimal[1] ;
         BC002F11_n694SerasaChequesTotalCons = new bool[] {false} ;
         BC002F11_A695SerasaChequesQtdSemFundo = new decimal[1] ;
         BC002F11_n695SerasaChequesQtdSemFundo = new bool[] {false} ;
         BC002F11_A696SerasaChequesUltOcorSus = new DateTime[] {DateTime.MinValue} ;
         BC002F11_n696SerasaChequesUltOcorSus = new bool[] {false} ;
         BC002F11_A697SerasaChequesValorSemFundo = new decimal[1] ;
         BC002F11_n697SerasaChequesValorSemFundo = new bool[] {false} ;
         BC002F11_A698SerasaChequesTotalSust = new decimal[1] ;
         BC002F11_n698SerasaChequesTotalSust = new bool[] {false} ;
         BC002F11_A662SerasaId = new int[1] ;
         BC002F11_n662SerasaId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasacheques_bc__default(),
            new Object[][] {
                new Object[] {
               BC002F2_A693SerasaChequesId, BC002F2_A694SerasaChequesTotalCons, BC002F2_n694SerasaChequesTotalCons, BC002F2_A695SerasaChequesQtdSemFundo, BC002F2_n695SerasaChequesQtdSemFundo, BC002F2_A696SerasaChequesUltOcorSus, BC002F2_n696SerasaChequesUltOcorSus, BC002F2_A697SerasaChequesValorSemFundo, BC002F2_n697SerasaChequesValorSemFundo, BC002F2_A698SerasaChequesTotalSust,
               BC002F2_n698SerasaChequesTotalSust, BC002F2_A662SerasaId, BC002F2_n662SerasaId
               }
               , new Object[] {
               BC002F3_A693SerasaChequesId, BC002F3_A694SerasaChequesTotalCons, BC002F3_n694SerasaChequesTotalCons, BC002F3_A695SerasaChequesQtdSemFundo, BC002F3_n695SerasaChequesQtdSemFundo, BC002F3_A696SerasaChequesUltOcorSus, BC002F3_n696SerasaChequesUltOcorSus, BC002F3_A697SerasaChequesValorSemFundo, BC002F3_n697SerasaChequesValorSemFundo, BC002F3_A698SerasaChequesTotalSust,
               BC002F3_n698SerasaChequesTotalSust, BC002F3_A662SerasaId, BC002F3_n662SerasaId
               }
               , new Object[] {
               BC002F4_A662SerasaId
               }
               , new Object[] {
               BC002F5_A693SerasaChequesId, BC002F5_A694SerasaChequesTotalCons, BC002F5_n694SerasaChequesTotalCons, BC002F5_A695SerasaChequesQtdSemFundo, BC002F5_n695SerasaChequesQtdSemFundo, BC002F5_A696SerasaChequesUltOcorSus, BC002F5_n696SerasaChequesUltOcorSus, BC002F5_A697SerasaChequesValorSemFundo, BC002F5_n697SerasaChequesValorSemFundo, BC002F5_A698SerasaChequesTotalSust,
               BC002F5_n698SerasaChequesTotalSust, BC002F5_A662SerasaId, BC002F5_n662SerasaId
               }
               , new Object[] {
               BC002F6_A693SerasaChequesId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002F8_A693SerasaChequesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002F11_A693SerasaChequesId, BC002F11_A694SerasaChequesTotalCons, BC002F11_n694SerasaChequesTotalCons, BC002F11_A695SerasaChequesQtdSemFundo, BC002F11_n695SerasaChequesQtdSemFundo, BC002F11_A696SerasaChequesUltOcorSus, BC002F11_n696SerasaChequesUltOcorSus, BC002F11_A697SerasaChequesValorSemFundo, BC002F11_n697SerasaChequesValorSemFundo, BC002F11_A698SerasaChequesTotalSust,
               BC002F11_n698SerasaChequesTotalSust, BC002F11_A662SerasaId, BC002F11_n662SerasaId
               }
            }
         );
         AV19Pgmname = "SerasaCheques_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122F2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound85 ;
      private int trnEnded ;
      private int Z693SerasaChequesId ;
      private int A693SerasaChequesId ;
      private int AV20GXV1 ;
      private int AV11Insert_SerasaId ;
      private int Z662SerasaId ;
      private int A662SerasaId ;
      private decimal Z694SerasaChequesTotalCons ;
      private decimal A694SerasaChequesTotalCons ;
      private decimal Z695SerasaChequesQtdSemFundo ;
      private decimal A695SerasaChequesQtdSemFundo ;
      private decimal Z697SerasaChequesValorSemFundo ;
      private decimal A697SerasaChequesValorSemFundo ;
      private decimal Z698SerasaChequesTotalSust ;
      private decimal A698SerasaChequesTotalSust ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV19Pgmname ;
      private string sMode85 ;
      private DateTime Z696SerasaChequesUltOcorSus ;
      private DateTime A696SerasaChequesUltOcorSus ;
      private bool returnInSub ;
      private bool n694SerasaChequesTotalCons ;
      private bool n695SerasaChequesQtdSemFundo ;
      private bool n696SerasaChequesUltOcorSus ;
      private bool n697SerasaChequesValorSemFundo ;
      private bool n698SerasaChequesTotalSust ;
      private bool n662SerasaId ;
      private bool Gx_longc ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002F5_A693SerasaChequesId ;
      private decimal[] BC002F5_A694SerasaChequesTotalCons ;
      private bool[] BC002F5_n694SerasaChequesTotalCons ;
      private decimal[] BC002F5_A695SerasaChequesQtdSemFundo ;
      private bool[] BC002F5_n695SerasaChequesQtdSemFundo ;
      private DateTime[] BC002F5_A696SerasaChequesUltOcorSus ;
      private bool[] BC002F5_n696SerasaChequesUltOcorSus ;
      private decimal[] BC002F5_A697SerasaChequesValorSemFundo ;
      private bool[] BC002F5_n697SerasaChequesValorSemFundo ;
      private decimal[] BC002F5_A698SerasaChequesTotalSust ;
      private bool[] BC002F5_n698SerasaChequesTotalSust ;
      private int[] BC002F5_A662SerasaId ;
      private bool[] BC002F5_n662SerasaId ;
      private int[] BC002F4_A662SerasaId ;
      private bool[] BC002F4_n662SerasaId ;
      private int[] BC002F6_A693SerasaChequesId ;
      private int[] BC002F3_A693SerasaChequesId ;
      private decimal[] BC002F3_A694SerasaChequesTotalCons ;
      private bool[] BC002F3_n694SerasaChequesTotalCons ;
      private decimal[] BC002F3_A695SerasaChequesQtdSemFundo ;
      private bool[] BC002F3_n695SerasaChequesQtdSemFundo ;
      private DateTime[] BC002F3_A696SerasaChequesUltOcorSus ;
      private bool[] BC002F3_n696SerasaChequesUltOcorSus ;
      private decimal[] BC002F3_A697SerasaChequesValorSemFundo ;
      private bool[] BC002F3_n697SerasaChequesValorSemFundo ;
      private decimal[] BC002F3_A698SerasaChequesTotalSust ;
      private bool[] BC002F3_n698SerasaChequesTotalSust ;
      private int[] BC002F3_A662SerasaId ;
      private bool[] BC002F3_n662SerasaId ;
      private int[] BC002F2_A693SerasaChequesId ;
      private decimal[] BC002F2_A694SerasaChequesTotalCons ;
      private bool[] BC002F2_n694SerasaChequesTotalCons ;
      private decimal[] BC002F2_A695SerasaChequesQtdSemFundo ;
      private bool[] BC002F2_n695SerasaChequesQtdSemFundo ;
      private DateTime[] BC002F2_A696SerasaChequesUltOcorSus ;
      private bool[] BC002F2_n696SerasaChequesUltOcorSus ;
      private decimal[] BC002F2_A697SerasaChequesValorSemFundo ;
      private bool[] BC002F2_n697SerasaChequesValorSemFundo ;
      private decimal[] BC002F2_A698SerasaChequesTotalSust ;
      private bool[] BC002F2_n698SerasaChequesTotalSust ;
      private int[] BC002F2_A662SerasaId ;
      private bool[] BC002F2_n662SerasaId ;
      private int[] BC002F8_A693SerasaChequesId ;
      private int[] BC002F11_A693SerasaChequesId ;
      private decimal[] BC002F11_A694SerasaChequesTotalCons ;
      private bool[] BC002F11_n694SerasaChequesTotalCons ;
      private decimal[] BC002F11_A695SerasaChequesQtdSemFundo ;
      private bool[] BC002F11_n695SerasaChequesQtdSemFundo ;
      private DateTime[] BC002F11_A696SerasaChequesUltOcorSus ;
      private bool[] BC002F11_n696SerasaChequesUltOcorSus ;
      private decimal[] BC002F11_A697SerasaChequesValorSemFundo ;
      private bool[] BC002F11_n697SerasaChequesValorSemFundo ;
      private decimal[] BC002F11_A698SerasaChequesTotalSust ;
      private bool[] BC002F11_n698SerasaChequesTotalSust ;
      private int[] BC002F11_A662SerasaId ;
      private bool[] BC002F11_n662SerasaId ;
      private SdtSerasaCheques bcSerasaCheques ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class serasacheques_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC002F2;
          prmBC002F2 = new Object[] {
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmBC002F3;
          prmBC002F3 = new Object[] {
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmBC002F4;
          prmBC002F4 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002F5;
          prmBC002F5 = new Object[] {
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmBC002F6;
          prmBC002F6 = new Object[] {
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmBC002F7;
          prmBC002F7 = new Object[] {
          new ParDef("SerasaChequesTotalCons",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaChequesQtdSemFundo",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaChequesUltOcorSus",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaChequesValorSemFundo",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaChequesTotalSust",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002F8;
          prmBC002F8 = new Object[] {
          };
          Object[] prmBC002F9;
          prmBC002F9 = new Object[] {
          new ParDef("SerasaChequesTotalCons",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaChequesQtdSemFundo",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaChequesUltOcorSus",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaChequesValorSemFundo",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaChequesTotalSust",GXType.Number,15,2){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmBC002F10;
          prmBC002F10 = new Object[] {
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          Object[] prmBC002F11;
          prmBC002F11 = new Object[] {
          new ParDef("SerasaChequesId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002F2", "SELECT SerasaChequesId, SerasaChequesTotalCons, SerasaChequesQtdSemFundo, SerasaChequesUltOcorSus, SerasaChequesValorSemFundo, SerasaChequesTotalSust, SerasaId FROM SerasaCheques WHERE SerasaChequesId = :SerasaChequesId  FOR UPDATE OF SerasaCheques",true, GxErrorMask.GX_NOMASK, false, this,prmBC002F2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002F3", "SELECT SerasaChequesId, SerasaChequesTotalCons, SerasaChequesQtdSemFundo, SerasaChequesUltOcorSus, SerasaChequesValorSemFundo, SerasaChequesTotalSust, SerasaId FROM SerasaCheques WHERE SerasaChequesId = :SerasaChequesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002F3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002F4", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002F4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002F5", "SELECT TM1.SerasaChequesId, TM1.SerasaChequesTotalCons, TM1.SerasaChequesQtdSemFundo, TM1.SerasaChequesUltOcorSus, TM1.SerasaChequesValorSemFundo, TM1.SerasaChequesTotalSust, TM1.SerasaId FROM SerasaCheques TM1 WHERE TM1.SerasaChequesId = :SerasaChequesId ORDER BY TM1.SerasaChequesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002F5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002F6", "SELECT SerasaChequesId FROM SerasaCheques WHERE SerasaChequesId = :SerasaChequesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002F6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002F7", "SAVEPOINT gxupdate;INSERT INTO SerasaCheques(SerasaChequesTotalCons, SerasaChequesQtdSemFundo, SerasaChequesUltOcorSus, SerasaChequesValorSemFundo, SerasaChequesTotalSust, SerasaId) VALUES(:SerasaChequesTotalCons, :SerasaChequesQtdSemFundo, :SerasaChequesUltOcorSus, :SerasaChequesValorSemFundo, :SerasaChequesTotalSust, :SerasaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002F7)
             ,new CursorDef("BC002F8", "SELECT currval('SerasaChequesId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002F8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002F9", "SAVEPOINT gxupdate;UPDATE SerasaCheques SET SerasaChequesTotalCons=:SerasaChequesTotalCons, SerasaChequesQtdSemFundo=:SerasaChequesQtdSemFundo, SerasaChequesUltOcorSus=:SerasaChequesUltOcorSus, SerasaChequesValorSemFundo=:SerasaChequesValorSemFundo, SerasaChequesTotalSust=:SerasaChequesTotalSust, SerasaId=:SerasaId  WHERE SerasaChequesId = :SerasaChequesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002F9)
             ,new CursorDef("BC002F10", "SAVEPOINT gxupdate;DELETE FROM SerasaCheques  WHERE SerasaChequesId = :SerasaChequesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002F10)
             ,new CursorDef("BC002F11", "SELECT TM1.SerasaChequesId, TM1.SerasaChequesTotalCons, TM1.SerasaChequesQtdSemFundo, TM1.SerasaChequesUltOcorSus, TM1.SerasaChequesValorSemFundo, TM1.SerasaChequesTotalSust, TM1.SerasaId FROM SerasaCheques TM1 WHERE TM1.SerasaChequesId = :SerasaChequesId ORDER BY TM1.SerasaChequesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002F11,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}
