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
   public class serasaocorrencias_bc : GxSilentTrn, IGxSilentTrn
   {
      public serasaocorrencias_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasaocorrencias_bc( IGxContext context )
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
         ReadRow2J89( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2J89( ) ;
         standaloneModal( ) ;
         AddRow2J89( ) ;
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
            E112J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z726SerasaOcorrenciasId = A726SerasaOcorrenciasId;
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

      protected void CONFIRM_2J0( )
      {
         BeforeValidate2J89( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2J89( ) ;
            }
            else
            {
               CheckExtendedTable2J89( ) ;
               if ( AnyError == 0 )
               {
                  ZM2J89( 5) ;
               }
               CloseExtendedTableCursors2J89( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122J2( )
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

      protected void E112J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2J89( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z727SerasaOcorrenciasData = A727SerasaOcorrenciasData;
            Z728SerasaOcorrenciasOrigem = A728SerasaOcorrenciasOrigem;
            Z729SerasaOcorrenciasModalidade = A729SerasaOcorrenciasModalidade;
            Z730SerasaOcorrenciasTipoMoeda = A730SerasaOcorrenciasTipoMoeda;
            Z731SerasaOcorrenciasValor = A731SerasaOcorrenciasValor;
            Z662SerasaId = A662SerasaId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -4 )
         {
            Z726SerasaOcorrenciasId = A726SerasaOcorrenciasId;
            Z727SerasaOcorrenciasData = A727SerasaOcorrenciasData;
            Z728SerasaOcorrenciasOrigem = A728SerasaOcorrenciasOrigem;
            Z729SerasaOcorrenciasModalidade = A729SerasaOcorrenciasModalidade;
            Z730SerasaOcorrenciasTipoMoeda = A730SerasaOcorrenciasTipoMoeda;
            Z731SerasaOcorrenciasValor = A731SerasaOcorrenciasValor;
            Z662SerasaId = A662SerasaId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV19Pgmname = "SerasaOcorrencias_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2J89( )
      {
         /* Using cursor BC002J5 */
         pr_default.execute(3, new Object[] {A726SerasaOcorrenciasId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound89 = 1;
            A727SerasaOcorrenciasData = BC002J5_A727SerasaOcorrenciasData[0];
            n727SerasaOcorrenciasData = BC002J5_n727SerasaOcorrenciasData[0];
            A728SerasaOcorrenciasOrigem = BC002J5_A728SerasaOcorrenciasOrigem[0];
            n728SerasaOcorrenciasOrigem = BC002J5_n728SerasaOcorrenciasOrigem[0];
            A729SerasaOcorrenciasModalidade = BC002J5_A729SerasaOcorrenciasModalidade[0];
            n729SerasaOcorrenciasModalidade = BC002J5_n729SerasaOcorrenciasModalidade[0];
            A730SerasaOcorrenciasTipoMoeda = BC002J5_A730SerasaOcorrenciasTipoMoeda[0];
            n730SerasaOcorrenciasTipoMoeda = BC002J5_n730SerasaOcorrenciasTipoMoeda[0];
            A731SerasaOcorrenciasValor = BC002J5_A731SerasaOcorrenciasValor[0];
            n731SerasaOcorrenciasValor = BC002J5_n731SerasaOcorrenciasValor[0];
            A662SerasaId = BC002J5_A662SerasaId[0];
            n662SerasaId = BC002J5_n662SerasaId[0];
            ZM2J89( -4) ;
         }
         pr_default.close(3);
         OnLoadActions2J89( ) ;
      }

      protected void OnLoadActions2J89( )
      {
      }

      protected void CheckExtendedTable2J89( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002J4 */
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
         if ( ( A731SerasaOcorrenciasValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2J89( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2J89( )
      {
         /* Using cursor BC002J6 */
         pr_default.execute(4, new Object[] {A726SerasaOcorrenciasId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound89 = 1;
         }
         else
         {
            RcdFound89 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002J3 */
         pr_default.execute(1, new Object[] {A726SerasaOcorrenciasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2J89( 4) ;
            RcdFound89 = 1;
            A726SerasaOcorrenciasId = BC002J3_A726SerasaOcorrenciasId[0];
            A727SerasaOcorrenciasData = BC002J3_A727SerasaOcorrenciasData[0];
            n727SerasaOcorrenciasData = BC002J3_n727SerasaOcorrenciasData[0];
            A728SerasaOcorrenciasOrigem = BC002J3_A728SerasaOcorrenciasOrigem[0];
            n728SerasaOcorrenciasOrigem = BC002J3_n728SerasaOcorrenciasOrigem[0];
            A729SerasaOcorrenciasModalidade = BC002J3_A729SerasaOcorrenciasModalidade[0];
            n729SerasaOcorrenciasModalidade = BC002J3_n729SerasaOcorrenciasModalidade[0];
            A730SerasaOcorrenciasTipoMoeda = BC002J3_A730SerasaOcorrenciasTipoMoeda[0];
            n730SerasaOcorrenciasTipoMoeda = BC002J3_n730SerasaOcorrenciasTipoMoeda[0];
            A731SerasaOcorrenciasValor = BC002J3_A731SerasaOcorrenciasValor[0];
            n731SerasaOcorrenciasValor = BC002J3_n731SerasaOcorrenciasValor[0];
            A662SerasaId = BC002J3_A662SerasaId[0];
            n662SerasaId = BC002J3_n662SerasaId[0];
            Z726SerasaOcorrenciasId = A726SerasaOcorrenciasId;
            sMode89 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2J89( ) ;
            if ( AnyError == 1 )
            {
               RcdFound89 = 0;
               InitializeNonKey2J89( ) ;
            }
            Gx_mode = sMode89;
         }
         else
         {
            RcdFound89 = 0;
            InitializeNonKey2J89( ) ;
            sMode89 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode89;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2J89( ) ;
         if ( RcdFound89 == 0 )
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
         CONFIRM_2J0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2J89( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002J2 */
            pr_default.execute(0, new Object[] {A726SerasaOcorrenciasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaOcorrencias"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z727SerasaOcorrenciasData ) != DateTimeUtil.ResetTime ( BC002J2_A727SerasaOcorrenciasData[0] ) ) || ( StringUtil.StrCmp(Z728SerasaOcorrenciasOrigem, BC002J2_A728SerasaOcorrenciasOrigem[0]) != 0 ) || ( StringUtil.StrCmp(Z729SerasaOcorrenciasModalidade, BC002J2_A729SerasaOcorrenciasModalidade[0]) != 0 ) || ( StringUtil.StrCmp(Z730SerasaOcorrenciasTipoMoeda, BC002J2_A730SerasaOcorrenciasTipoMoeda[0]) != 0 ) || ( Z731SerasaOcorrenciasValor != BC002J2_A731SerasaOcorrenciasValor[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z662SerasaId != BC002J2_A662SerasaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SerasaOcorrencias"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2J89( )
      {
         BeforeValidate2J89( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2J89( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2J89( 0) ;
            CheckOptimisticConcurrency2J89( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2J89( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2J89( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002J7 */
                     pr_default.execute(5, new Object[] {n727SerasaOcorrenciasData, A727SerasaOcorrenciasData, n728SerasaOcorrenciasOrigem, A728SerasaOcorrenciasOrigem, n729SerasaOcorrenciasModalidade, A729SerasaOcorrenciasModalidade, n730SerasaOcorrenciasTipoMoeda, A730SerasaOcorrenciasTipoMoeda, n731SerasaOcorrenciasValor, A731SerasaOcorrenciasValor, n662SerasaId, A662SerasaId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002J8 */
                     pr_default.execute(6);
                     A726SerasaOcorrenciasId = BC002J8_A726SerasaOcorrenciasId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaOcorrencias");
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
               Load2J89( ) ;
            }
            EndLevel2J89( ) ;
         }
         CloseExtendedTableCursors2J89( ) ;
      }

      protected void Update2J89( )
      {
         BeforeValidate2J89( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2J89( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2J89( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2J89( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2J89( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002J9 */
                     pr_default.execute(7, new Object[] {n727SerasaOcorrenciasData, A727SerasaOcorrenciasData, n728SerasaOcorrenciasOrigem, A728SerasaOcorrenciasOrigem, n729SerasaOcorrenciasModalidade, A729SerasaOcorrenciasModalidade, n730SerasaOcorrenciasTipoMoeda, A730SerasaOcorrenciasTipoMoeda, n731SerasaOcorrenciasValor, A731SerasaOcorrenciasValor, n662SerasaId, A662SerasaId, A726SerasaOcorrenciasId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaOcorrencias");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaOcorrencias"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2J89( ) ;
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
            EndLevel2J89( ) ;
         }
         CloseExtendedTableCursors2J89( ) ;
      }

      protected void DeferredUpdate2J89( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2J89( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2J89( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2J89( ) ;
            AfterConfirm2J89( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2J89( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002J10 */
                  pr_default.execute(8, new Object[] {A726SerasaOcorrenciasId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("SerasaOcorrencias");
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
         sMode89 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2J89( ) ;
         Gx_mode = sMode89;
      }

      protected void OnDeleteControls2J89( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2J89( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2J89( ) ;
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

      public void ScanKeyStart2J89( )
      {
         /* Scan By routine */
         /* Using cursor BC002J11 */
         pr_default.execute(9, new Object[] {A726SerasaOcorrenciasId});
         RcdFound89 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound89 = 1;
            A726SerasaOcorrenciasId = BC002J11_A726SerasaOcorrenciasId[0];
            A727SerasaOcorrenciasData = BC002J11_A727SerasaOcorrenciasData[0];
            n727SerasaOcorrenciasData = BC002J11_n727SerasaOcorrenciasData[0];
            A728SerasaOcorrenciasOrigem = BC002J11_A728SerasaOcorrenciasOrigem[0];
            n728SerasaOcorrenciasOrigem = BC002J11_n728SerasaOcorrenciasOrigem[0];
            A729SerasaOcorrenciasModalidade = BC002J11_A729SerasaOcorrenciasModalidade[0];
            n729SerasaOcorrenciasModalidade = BC002J11_n729SerasaOcorrenciasModalidade[0];
            A730SerasaOcorrenciasTipoMoeda = BC002J11_A730SerasaOcorrenciasTipoMoeda[0];
            n730SerasaOcorrenciasTipoMoeda = BC002J11_n730SerasaOcorrenciasTipoMoeda[0];
            A731SerasaOcorrenciasValor = BC002J11_A731SerasaOcorrenciasValor[0];
            n731SerasaOcorrenciasValor = BC002J11_n731SerasaOcorrenciasValor[0];
            A662SerasaId = BC002J11_A662SerasaId[0];
            n662SerasaId = BC002J11_n662SerasaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2J89( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound89 = 0;
         ScanKeyLoad2J89( ) ;
      }

      protected void ScanKeyLoad2J89( )
      {
         sMode89 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound89 = 1;
            A726SerasaOcorrenciasId = BC002J11_A726SerasaOcorrenciasId[0];
            A727SerasaOcorrenciasData = BC002J11_A727SerasaOcorrenciasData[0];
            n727SerasaOcorrenciasData = BC002J11_n727SerasaOcorrenciasData[0];
            A728SerasaOcorrenciasOrigem = BC002J11_A728SerasaOcorrenciasOrigem[0];
            n728SerasaOcorrenciasOrigem = BC002J11_n728SerasaOcorrenciasOrigem[0];
            A729SerasaOcorrenciasModalidade = BC002J11_A729SerasaOcorrenciasModalidade[0];
            n729SerasaOcorrenciasModalidade = BC002J11_n729SerasaOcorrenciasModalidade[0];
            A730SerasaOcorrenciasTipoMoeda = BC002J11_A730SerasaOcorrenciasTipoMoeda[0];
            n730SerasaOcorrenciasTipoMoeda = BC002J11_n730SerasaOcorrenciasTipoMoeda[0];
            A731SerasaOcorrenciasValor = BC002J11_A731SerasaOcorrenciasValor[0];
            n731SerasaOcorrenciasValor = BC002J11_n731SerasaOcorrenciasValor[0];
            A662SerasaId = BC002J11_A662SerasaId[0];
            n662SerasaId = BC002J11_n662SerasaId[0];
         }
         Gx_mode = sMode89;
      }

      protected void ScanKeyEnd2J89( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm2J89( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2J89( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2J89( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2J89( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2J89( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2J89( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2J89( )
      {
      }

      protected void send_integrity_lvl_hashes2J89( )
      {
      }

      protected void AddRow2J89( )
      {
         VarsToRow89( bcSerasaOcorrencias) ;
      }

      protected void ReadRow2J89( )
      {
         RowToVars89( bcSerasaOcorrencias, 1) ;
      }

      protected void InitializeNonKey2J89( )
      {
         A662SerasaId = 0;
         n662SerasaId = false;
         A727SerasaOcorrenciasData = DateTime.MinValue;
         n727SerasaOcorrenciasData = false;
         A728SerasaOcorrenciasOrigem = "";
         n728SerasaOcorrenciasOrigem = false;
         A729SerasaOcorrenciasModalidade = "";
         n729SerasaOcorrenciasModalidade = false;
         A730SerasaOcorrenciasTipoMoeda = "";
         n730SerasaOcorrenciasTipoMoeda = false;
         A731SerasaOcorrenciasValor = 0;
         n731SerasaOcorrenciasValor = false;
         Z727SerasaOcorrenciasData = DateTime.MinValue;
         Z728SerasaOcorrenciasOrigem = "";
         Z729SerasaOcorrenciasModalidade = "";
         Z730SerasaOcorrenciasTipoMoeda = "";
         Z731SerasaOcorrenciasValor = 0;
         Z662SerasaId = 0;
      }

      protected void InitAll2J89( )
      {
         A726SerasaOcorrenciasId = 0;
         InitializeNonKey2J89( ) ;
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

      public void VarsToRow89( SdtSerasaOcorrencias obj89 )
      {
         obj89.gxTpr_Mode = Gx_mode;
         obj89.gxTpr_Serasaid = A662SerasaId;
         obj89.gxTpr_Serasaocorrenciasdata = A727SerasaOcorrenciasData;
         obj89.gxTpr_Serasaocorrenciasorigem = A728SerasaOcorrenciasOrigem;
         obj89.gxTpr_Serasaocorrenciasmodalidade = A729SerasaOcorrenciasModalidade;
         obj89.gxTpr_Serasaocorrenciastipomoeda = A730SerasaOcorrenciasTipoMoeda;
         obj89.gxTpr_Serasaocorrenciasvalor = A731SerasaOcorrenciasValor;
         obj89.gxTpr_Serasaocorrenciasid = A726SerasaOcorrenciasId;
         obj89.gxTpr_Serasaocorrenciasid_Z = Z726SerasaOcorrenciasId;
         obj89.gxTpr_Serasaid_Z = Z662SerasaId;
         obj89.gxTpr_Serasaocorrenciasdata_Z = Z727SerasaOcorrenciasData;
         obj89.gxTpr_Serasaocorrenciasorigem_Z = Z728SerasaOcorrenciasOrigem;
         obj89.gxTpr_Serasaocorrenciasmodalidade_Z = Z729SerasaOcorrenciasModalidade;
         obj89.gxTpr_Serasaocorrenciastipomoeda_Z = Z730SerasaOcorrenciasTipoMoeda;
         obj89.gxTpr_Serasaocorrenciasvalor_Z = Z731SerasaOcorrenciasValor;
         obj89.gxTpr_Serasaid_N = (short)(Convert.ToInt16(n662SerasaId));
         obj89.gxTpr_Serasaocorrenciasdata_N = (short)(Convert.ToInt16(n727SerasaOcorrenciasData));
         obj89.gxTpr_Serasaocorrenciasorigem_N = (short)(Convert.ToInt16(n728SerasaOcorrenciasOrigem));
         obj89.gxTpr_Serasaocorrenciasmodalidade_N = (short)(Convert.ToInt16(n729SerasaOcorrenciasModalidade));
         obj89.gxTpr_Serasaocorrenciastipomoeda_N = (short)(Convert.ToInt16(n730SerasaOcorrenciasTipoMoeda));
         obj89.gxTpr_Serasaocorrenciasvalor_N = (short)(Convert.ToInt16(n731SerasaOcorrenciasValor));
         obj89.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow89( SdtSerasaOcorrencias obj89 )
      {
         obj89.gxTpr_Serasaocorrenciasid = A726SerasaOcorrenciasId;
         return  ;
      }

      public void RowToVars89( SdtSerasaOcorrencias obj89 ,
                               int forceLoad )
      {
         Gx_mode = obj89.gxTpr_Mode;
         A662SerasaId = obj89.gxTpr_Serasaid;
         n662SerasaId = false;
         A727SerasaOcorrenciasData = obj89.gxTpr_Serasaocorrenciasdata;
         n727SerasaOcorrenciasData = false;
         A728SerasaOcorrenciasOrigem = obj89.gxTpr_Serasaocorrenciasorigem;
         n728SerasaOcorrenciasOrigem = false;
         A729SerasaOcorrenciasModalidade = obj89.gxTpr_Serasaocorrenciasmodalidade;
         n729SerasaOcorrenciasModalidade = false;
         A730SerasaOcorrenciasTipoMoeda = obj89.gxTpr_Serasaocorrenciastipomoeda;
         n730SerasaOcorrenciasTipoMoeda = false;
         A731SerasaOcorrenciasValor = obj89.gxTpr_Serasaocorrenciasvalor;
         n731SerasaOcorrenciasValor = false;
         A726SerasaOcorrenciasId = obj89.gxTpr_Serasaocorrenciasid;
         Z726SerasaOcorrenciasId = obj89.gxTpr_Serasaocorrenciasid_Z;
         Z662SerasaId = obj89.gxTpr_Serasaid_Z;
         Z727SerasaOcorrenciasData = obj89.gxTpr_Serasaocorrenciasdata_Z;
         Z728SerasaOcorrenciasOrigem = obj89.gxTpr_Serasaocorrenciasorigem_Z;
         Z729SerasaOcorrenciasModalidade = obj89.gxTpr_Serasaocorrenciasmodalidade_Z;
         Z730SerasaOcorrenciasTipoMoeda = obj89.gxTpr_Serasaocorrenciastipomoeda_Z;
         Z731SerasaOcorrenciasValor = obj89.gxTpr_Serasaocorrenciasvalor_Z;
         n662SerasaId = (bool)(Convert.ToBoolean(obj89.gxTpr_Serasaid_N));
         n727SerasaOcorrenciasData = (bool)(Convert.ToBoolean(obj89.gxTpr_Serasaocorrenciasdata_N));
         n728SerasaOcorrenciasOrigem = (bool)(Convert.ToBoolean(obj89.gxTpr_Serasaocorrenciasorigem_N));
         n729SerasaOcorrenciasModalidade = (bool)(Convert.ToBoolean(obj89.gxTpr_Serasaocorrenciasmodalidade_N));
         n730SerasaOcorrenciasTipoMoeda = (bool)(Convert.ToBoolean(obj89.gxTpr_Serasaocorrenciastipomoeda_N));
         n731SerasaOcorrenciasValor = (bool)(Convert.ToBoolean(obj89.gxTpr_Serasaocorrenciasvalor_N));
         Gx_mode = obj89.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A726SerasaOcorrenciasId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2J89( ) ;
         ScanKeyStart2J89( ) ;
         if ( RcdFound89 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z726SerasaOcorrenciasId = A726SerasaOcorrenciasId;
         }
         ZM2J89( -4) ;
         OnLoadActions2J89( ) ;
         AddRow2J89( ) ;
         ScanKeyEnd2J89( ) ;
         if ( RcdFound89 == 0 )
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
         RowToVars89( bcSerasaOcorrencias, 0) ;
         ScanKeyStart2J89( ) ;
         if ( RcdFound89 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z726SerasaOcorrenciasId = A726SerasaOcorrenciasId;
         }
         ZM2J89( -4) ;
         OnLoadActions2J89( ) ;
         AddRow2J89( ) ;
         ScanKeyEnd2J89( ) ;
         if ( RcdFound89 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2J89( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2J89( ) ;
         }
         else
         {
            if ( RcdFound89 == 1 )
            {
               if ( A726SerasaOcorrenciasId != Z726SerasaOcorrenciasId )
               {
                  A726SerasaOcorrenciasId = Z726SerasaOcorrenciasId;
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
                  Update2J89( ) ;
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
                  if ( A726SerasaOcorrenciasId != Z726SerasaOcorrenciasId )
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
                        Insert2J89( ) ;
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
                        Insert2J89( ) ;
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
         RowToVars89( bcSerasaOcorrencias, 1) ;
         SaveImpl( ) ;
         VarsToRow89( bcSerasaOcorrencias) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars89( bcSerasaOcorrencias, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2J89( ) ;
         AfterTrn( ) ;
         VarsToRow89( bcSerasaOcorrencias) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow89( bcSerasaOcorrencias) ;
         }
         else
         {
            SdtSerasaOcorrencias auxBC = new SdtSerasaOcorrencias(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A726SerasaOcorrenciasId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSerasaOcorrencias);
               auxBC.Save();
               bcSerasaOcorrencias.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars89( bcSerasaOcorrencias, 1) ;
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
         RowToVars89( bcSerasaOcorrencias, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2J89( ) ;
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
               VarsToRow89( bcSerasaOcorrencias) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow89( bcSerasaOcorrencias) ;
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
         RowToVars89( bcSerasaOcorrencias, 0) ;
         GetKey2J89( ) ;
         if ( RcdFound89 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A726SerasaOcorrenciasId != Z726SerasaOcorrenciasId )
            {
               A726SerasaOcorrenciasId = Z726SerasaOcorrenciasId;
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
            if ( A726SerasaOcorrenciasId != Z726SerasaOcorrenciasId )
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
         context.RollbackDataStores("serasaocorrencias_bc",pr_default);
         VarsToRow89( bcSerasaOcorrencias) ;
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
         Gx_mode = bcSerasaOcorrencias.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSerasaOcorrencias.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSerasaOcorrencias )
         {
            bcSerasaOcorrencias = (SdtSerasaOcorrencias)(sdt);
            if ( StringUtil.StrCmp(bcSerasaOcorrencias.gxTpr_Mode, "") == 0 )
            {
               bcSerasaOcorrencias.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow89( bcSerasaOcorrencias) ;
            }
            else
            {
               RowToVars89( bcSerasaOcorrencias, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSerasaOcorrencias.gxTpr_Mode, "") == 0 )
            {
               bcSerasaOcorrencias.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars89( bcSerasaOcorrencias, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSerasaOcorrencias SerasaOcorrencias_BC
      {
         get {
            return bcSerasaOcorrencias ;
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
         Z727SerasaOcorrenciasData = DateTime.MinValue;
         A727SerasaOcorrenciasData = DateTime.MinValue;
         Z728SerasaOcorrenciasOrigem = "";
         A728SerasaOcorrenciasOrigem = "";
         Z729SerasaOcorrenciasModalidade = "";
         A729SerasaOcorrenciasModalidade = "";
         Z730SerasaOcorrenciasTipoMoeda = "";
         A730SerasaOcorrenciasTipoMoeda = "";
         BC002J5_A726SerasaOcorrenciasId = new int[1] ;
         BC002J5_A727SerasaOcorrenciasData = new DateTime[] {DateTime.MinValue} ;
         BC002J5_n727SerasaOcorrenciasData = new bool[] {false} ;
         BC002J5_A728SerasaOcorrenciasOrigem = new string[] {""} ;
         BC002J5_n728SerasaOcorrenciasOrigem = new bool[] {false} ;
         BC002J5_A729SerasaOcorrenciasModalidade = new string[] {""} ;
         BC002J5_n729SerasaOcorrenciasModalidade = new bool[] {false} ;
         BC002J5_A730SerasaOcorrenciasTipoMoeda = new string[] {""} ;
         BC002J5_n730SerasaOcorrenciasTipoMoeda = new bool[] {false} ;
         BC002J5_A731SerasaOcorrenciasValor = new decimal[1] ;
         BC002J5_n731SerasaOcorrenciasValor = new bool[] {false} ;
         BC002J5_A662SerasaId = new int[1] ;
         BC002J5_n662SerasaId = new bool[] {false} ;
         BC002J4_A662SerasaId = new int[1] ;
         BC002J4_n662SerasaId = new bool[] {false} ;
         BC002J6_A726SerasaOcorrenciasId = new int[1] ;
         BC002J3_A726SerasaOcorrenciasId = new int[1] ;
         BC002J3_A727SerasaOcorrenciasData = new DateTime[] {DateTime.MinValue} ;
         BC002J3_n727SerasaOcorrenciasData = new bool[] {false} ;
         BC002J3_A728SerasaOcorrenciasOrigem = new string[] {""} ;
         BC002J3_n728SerasaOcorrenciasOrigem = new bool[] {false} ;
         BC002J3_A729SerasaOcorrenciasModalidade = new string[] {""} ;
         BC002J3_n729SerasaOcorrenciasModalidade = new bool[] {false} ;
         BC002J3_A730SerasaOcorrenciasTipoMoeda = new string[] {""} ;
         BC002J3_n730SerasaOcorrenciasTipoMoeda = new bool[] {false} ;
         BC002J3_A731SerasaOcorrenciasValor = new decimal[1] ;
         BC002J3_n731SerasaOcorrenciasValor = new bool[] {false} ;
         BC002J3_A662SerasaId = new int[1] ;
         BC002J3_n662SerasaId = new bool[] {false} ;
         sMode89 = "";
         BC002J2_A726SerasaOcorrenciasId = new int[1] ;
         BC002J2_A727SerasaOcorrenciasData = new DateTime[] {DateTime.MinValue} ;
         BC002J2_n727SerasaOcorrenciasData = new bool[] {false} ;
         BC002J2_A728SerasaOcorrenciasOrigem = new string[] {""} ;
         BC002J2_n728SerasaOcorrenciasOrigem = new bool[] {false} ;
         BC002J2_A729SerasaOcorrenciasModalidade = new string[] {""} ;
         BC002J2_n729SerasaOcorrenciasModalidade = new bool[] {false} ;
         BC002J2_A730SerasaOcorrenciasTipoMoeda = new string[] {""} ;
         BC002J2_n730SerasaOcorrenciasTipoMoeda = new bool[] {false} ;
         BC002J2_A731SerasaOcorrenciasValor = new decimal[1] ;
         BC002J2_n731SerasaOcorrenciasValor = new bool[] {false} ;
         BC002J2_A662SerasaId = new int[1] ;
         BC002J2_n662SerasaId = new bool[] {false} ;
         BC002J8_A726SerasaOcorrenciasId = new int[1] ;
         BC002J11_A726SerasaOcorrenciasId = new int[1] ;
         BC002J11_A727SerasaOcorrenciasData = new DateTime[] {DateTime.MinValue} ;
         BC002J11_n727SerasaOcorrenciasData = new bool[] {false} ;
         BC002J11_A728SerasaOcorrenciasOrigem = new string[] {""} ;
         BC002J11_n728SerasaOcorrenciasOrigem = new bool[] {false} ;
         BC002J11_A729SerasaOcorrenciasModalidade = new string[] {""} ;
         BC002J11_n729SerasaOcorrenciasModalidade = new bool[] {false} ;
         BC002J11_A730SerasaOcorrenciasTipoMoeda = new string[] {""} ;
         BC002J11_n730SerasaOcorrenciasTipoMoeda = new bool[] {false} ;
         BC002J11_A731SerasaOcorrenciasValor = new decimal[1] ;
         BC002J11_n731SerasaOcorrenciasValor = new bool[] {false} ;
         BC002J11_A662SerasaId = new int[1] ;
         BC002J11_n662SerasaId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaocorrencias_bc__default(),
            new Object[][] {
                new Object[] {
               BC002J2_A726SerasaOcorrenciasId, BC002J2_A727SerasaOcorrenciasData, BC002J2_n727SerasaOcorrenciasData, BC002J2_A728SerasaOcorrenciasOrigem, BC002J2_n728SerasaOcorrenciasOrigem, BC002J2_A729SerasaOcorrenciasModalidade, BC002J2_n729SerasaOcorrenciasModalidade, BC002J2_A730SerasaOcorrenciasTipoMoeda, BC002J2_n730SerasaOcorrenciasTipoMoeda, BC002J2_A731SerasaOcorrenciasValor,
               BC002J2_n731SerasaOcorrenciasValor, BC002J2_A662SerasaId, BC002J2_n662SerasaId
               }
               , new Object[] {
               BC002J3_A726SerasaOcorrenciasId, BC002J3_A727SerasaOcorrenciasData, BC002J3_n727SerasaOcorrenciasData, BC002J3_A728SerasaOcorrenciasOrigem, BC002J3_n728SerasaOcorrenciasOrigem, BC002J3_A729SerasaOcorrenciasModalidade, BC002J3_n729SerasaOcorrenciasModalidade, BC002J3_A730SerasaOcorrenciasTipoMoeda, BC002J3_n730SerasaOcorrenciasTipoMoeda, BC002J3_A731SerasaOcorrenciasValor,
               BC002J3_n731SerasaOcorrenciasValor, BC002J3_A662SerasaId, BC002J3_n662SerasaId
               }
               , new Object[] {
               BC002J4_A662SerasaId
               }
               , new Object[] {
               BC002J5_A726SerasaOcorrenciasId, BC002J5_A727SerasaOcorrenciasData, BC002J5_n727SerasaOcorrenciasData, BC002J5_A728SerasaOcorrenciasOrigem, BC002J5_n728SerasaOcorrenciasOrigem, BC002J5_A729SerasaOcorrenciasModalidade, BC002J5_n729SerasaOcorrenciasModalidade, BC002J5_A730SerasaOcorrenciasTipoMoeda, BC002J5_n730SerasaOcorrenciasTipoMoeda, BC002J5_A731SerasaOcorrenciasValor,
               BC002J5_n731SerasaOcorrenciasValor, BC002J5_A662SerasaId, BC002J5_n662SerasaId
               }
               , new Object[] {
               BC002J6_A726SerasaOcorrenciasId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002J8_A726SerasaOcorrenciasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002J11_A726SerasaOcorrenciasId, BC002J11_A727SerasaOcorrenciasData, BC002J11_n727SerasaOcorrenciasData, BC002J11_A728SerasaOcorrenciasOrigem, BC002J11_n728SerasaOcorrenciasOrigem, BC002J11_A729SerasaOcorrenciasModalidade, BC002J11_n729SerasaOcorrenciasModalidade, BC002J11_A730SerasaOcorrenciasTipoMoeda, BC002J11_n730SerasaOcorrenciasTipoMoeda, BC002J11_A731SerasaOcorrenciasValor,
               BC002J11_n731SerasaOcorrenciasValor, BC002J11_A662SerasaId, BC002J11_n662SerasaId
               }
            }
         );
         AV19Pgmname = "SerasaOcorrencias_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122J2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound89 ;
      private int trnEnded ;
      private int Z726SerasaOcorrenciasId ;
      private int A726SerasaOcorrenciasId ;
      private int AV20GXV1 ;
      private int AV11Insert_SerasaId ;
      private int Z662SerasaId ;
      private int A662SerasaId ;
      private decimal Z731SerasaOcorrenciasValor ;
      private decimal A731SerasaOcorrenciasValor ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV19Pgmname ;
      private string sMode89 ;
      private DateTime Z727SerasaOcorrenciasData ;
      private DateTime A727SerasaOcorrenciasData ;
      private bool returnInSub ;
      private bool n727SerasaOcorrenciasData ;
      private bool n728SerasaOcorrenciasOrigem ;
      private bool n729SerasaOcorrenciasModalidade ;
      private bool n730SerasaOcorrenciasTipoMoeda ;
      private bool n731SerasaOcorrenciasValor ;
      private bool n662SerasaId ;
      private bool Gx_longc ;
      private string Z728SerasaOcorrenciasOrigem ;
      private string A728SerasaOcorrenciasOrigem ;
      private string Z729SerasaOcorrenciasModalidade ;
      private string A729SerasaOcorrenciasModalidade ;
      private string Z730SerasaOcorrenciasTipoMoeda ;
      private string A730SerasaOcorrenciasTipoMoeda ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002J5_A726SerasaOcorrenciasId ;
      private DateTime[] BC002J5_A727SerasaOcorrenciasData ;
      private bool[] BC002J5_n727SerasaOcorrenciasData ;
      private string[] BC002J5_A728SerasaOcorrenciasOrigem ;
      private bool[] BC002J5_n728SerasaOcorrenciasOrigem ;
      private string[] BC002J5_A729SerasaOcorrenciasModalidade ;
      private bool[] BC002J5_n729SerasaOcorrenciasModalidade ;
      private string[] BC002J5_A730SerasaOcorrenciasTipoMoeda ;
      private bool[] BC002J5_n730SerasaOcorrenciasTipoMoeda ;
      private decimal[] BC002J5_A731SerasaOcorrenciasValor ;
      private bool[] BC002J5_n731SerasaOcorrenciasValor ;
      private int[] BC002J5_A662SerasaId ;
      private bool[] BC002J5_n662SerasaId ;
      private int[] BC002J4_A662SerasaId ;
      private bool[] BC002J4_n662SerasaId ;
      private int[] BC002J6_A726SerasaOcorrenciasId ;
      private int[] BC002J3_A726SerasaOcorrenciasId ;
      private DateTime[] BC002J3_A727SerasaOcorrenciasData ;
      private bool[] BC002J3_n727SerasaOcorrenciasData ;
      private string[] BC002J3_A728SerasaOcorrenciasOrigem ;
      private bool[] BC002J3_n728SerasaOcorrenciasOrigem ;
      private string[] BC002J3_A729SerasaOcorrenciasModalidade ;
      private bool[] BC002J3_n729SerasaOcorrenciasModalidade ;
      private string[] BC002J3_A730SerasaOcorrenciasTipoMoeda ;
      private bool[] BC002J3_n730SerasaOcorrenciasTipoMoeda ;
      private decimal[] BC002J3_A731SerasaOcorrenciasValor ;
      private bool[] BC002J3_n731SerasaOcorrenciasValor ;
      private int[] BC002J3_A662SerasaId ;
      private bool[] BC002J3_n662SerasaId ;
      private int[] BC002J2_A726SerasaOcorrenciasId ;
      private DateTime[] BC002J2_A727SerasaOcorrenciasData ;
      private bool[] BC002J2_n727SerasaOcorrenciasData ;
      private string[] BC002J2_A728SerasaOcorrenciasOrigem ;
      private bool[] BC002J2_n728SerasaOcorrenciasOrigem ;
      private string[] BC002J2_A729SerasaOcorrenciasModalidade ;
      private bool[] BC002J2_n729SerasaOcorrenciasModalidade ;
      private string[] BC002J2_A730SerasaOcorrenciasTipoMoeda ;
      private bool[] BC002J2_n730SerasaOcorrenciasTipoMoeda ;
      private decimal[] BC002J2_A731SerasaOcorrenciasValor ;
      private bool[] BC002J2_n731SerasaOcorrenciasValor ;
      private int[] BC002J2_A662SerasaId ;
      private bool[] BC002J2_n662SerasaId ;
      private int[] BC002J8_A726SerasaOcorrenciasId ;
      private int[] BC002J11_A726SerasaOcorrenciasId ;
      private DateTime[] BC002J11_A727SerasaOcorrenciasData ;
      private bool[] BC002J11_n727SerasaOcorrenciasData ;
      private string[] BC002J11_A728SerasaOcorrenciasOrigem ;
      private bool[] BC002J11_n728SerasaOcorrenciasOrigem ;
      private string[] BC002J11_A729SerasaOcorrenciasModalidade ;
      private bool[] BC002J11_n729SerasaOcorrenciasModalidade ;
      private string[] BC002J11_A730SerasaOcorrenciasTipoMoeda ;
      private bool[] BC002J11_n730SerasaOcorrenciasTipoMoeda ;
      private decimal[] BC002J11_A731SerasaOcorrenciasValor ;
      private bool[] BC002J11_n731SerasaOcorrenciasValor ;
      private int[] BC002J11_A662SerasaId ;
      private bool[] BC002J11_n662SerasaId ;
      private SdtSerasaOcorrencias bcSerasaOcorrencias ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class serasaocorrencias_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC002J2;
          prmBC002J2 = new Object[] {
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmBC002J3;
          prmBC002J3 = new Object[] {
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmBC002J4;
          prmBC002J4 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002J5;
          prmBC002J5 = new Object[] {
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmBC002J6;
          prmBC002J6 = new Object[] {
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmBC002J7;
          prmBC002J7 = new Object[] {
          new ParDef("SerasaOcorrenciasData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasOrigem",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasModalidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasTipoMoeda",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002J8;
          prmBC002J8 = new Object[] {
          };
          Object[] prmBC002J9;
          prmBC002J9 = new Object[] {
          new ParDef("SerasaOcorrenciasData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasOrigem",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasModalidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasTipoMoeda",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmBC002J10;
          prmBC002J10 = new Object[] {
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          Object[] prmBC002J11;
          prmBC002J11 = new Object[] {
          new ParDef("SerasaOcorrenciasId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002J2", "SELECT SerasaOcorrenciasId, SerasaOcorrenciasData, SerasaOcorrenciasOrigem, SerasaOcorrenciasModalidade, SerasaOcorrenciasTipoMoeda, SerasaOcorrenciasValor, SerasaId FROM SerasaOcorrencias WHERE SerasaOcorrenciasId = :SerasaOcorrenciasId  FOR UPDATE OF SerasaOcorrencias",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002J3", "SELECT SerasaOcorrenciasId, SerasaOcorrenciasData, SerasaOcorrenciasOrigem, SerasaOcorrenciasModalidade, SerasaOcorrenciasTipoMoeda, SerasaOcorrenciasValor, SerasaId FROM SerasaOcorrencias WHERE SerasaOcorrenciasId = :SerasaOcorrenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002J4", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002J5", "SELECT TM1.SerasaOcorrenciasId, TM1.SerasaOcorrenciasData, TM1.SerasaOcorrenciasOrigem, TM1.SerasaOcorrenciasModalidade, TM1.SerasaOcorrenciasTipoMoeda, TM1.SerasaOcorrenciasValor, TM1.SerasaId FROM SerasaOcorrencias TM1 WHERE TM1.SerasaOcorrenciasId = :SerasaOcorrenciasId ORDER BY TM1.SerasaOcorrenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002J6", "SELECT SerasaOcorrenciasId FROM SerasaOcorrencias WHERE SerasaOcorrenciasId = :SerasaOcorrenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002J7", "SAVEPOINT gxupdate;INSERT INTO SerasaOcorrencias(SerasaOcorrenciasData, SerasaOcorrenciasOrigem, SerasaOcorrenciasModalidade, SerasaOcorrenciasTipoMoeda, SerasaOcorrenciasValor, SerasaId) VALUES(:SerasaOcorrenciasData, :SerasaOcorrenciasOrigem, :SerasaOcorrenciasModalidade, :SerasaOcorrenciasTipoMoeda, :SerasaOcorrenciasValor, :SerasaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002J7)
             ,new CursorDef("BC002J8", "SELECT currval('SerasaOcorrenciasId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002J9", "SAVEPOINT gxupdate;UPDATE SerasaOcorrencias SET SerasaOcorrenciasData=:SerasaOcorrenciasData, SerasaOcorrenciasOrigem=:SerasaOcorrenciasOrigem, SerasaOcorrenciasModalidade=:SerasaOcorrenciasModalidade, SerasaOcorrenciasTipoMoeda=:SerasaOcorrenciasTipoMoeda, SerasaOcorrenciasValor=:SerasaOcorrenciasValor, SerasaId=:SerasaId  WHERE SerasaOcorrenciasId = :SerasaOcorrenciasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002J9)
             ,new CursorDef("BC002J10", "SAVEPOINT gxupdate;DELETE FROM SerasaOcorrencias  WHERE SerasaOcorrenciasId = :SerasaOcorrenciasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002J10)
             ,new CursorDef("BC002J11", "SELECT TM1.SerasaOcorrenciasId, TM1.SerasaOcorrenciasData, TM1.SerasaOcorrenciasOrigem, TM1.SerasaOcorrenciasModalidade, TM1.SerasaOcorrenciasTipoMoeda, TM1.SerasaOcorrenciasValor, TM1.SerasaId FROM SerasaOcorrencias TM1 WHERE TM1.SerasaOcorrenciasId = :SerasaOcorrenciasId ORDER BY TM1.SerasaOcorrenciasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002J11,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
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
