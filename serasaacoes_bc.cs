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
   public class serasaacoes_bc : GxSilentTrn, IGxSilentTrn
   {
      public serasaacoes_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasaacoes_bc( IGxContext context )
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
         ReadRow2G86( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2G86( ) ;
         standaloneModal( ) ;
         AddRow2G86( ) ;
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
            E112G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z699SerasaAcoesId = A699SerasaAcoesId;
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

      protected void CONFIRM_2G0( )
      {
         BeforeValidate2G86( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2G86( ) ;
            }
            else
            {
               CheckExtendedTable2G86( ) ;
               if ( AnyError == 0 )
               {
                  ZM2G86( 5) ;
               }
               CloseExtendedTableCursors2G86( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122G2( )
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

      protected void E112G2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2G86( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z700SerasaAcoesData = A700SerasaAcoesData;
            Z701SerasaAcoesNatureza = A701SerasaAcoesNatureza;
            Z702SerasaAcoesValor = A702SerasaAcoesValor;
            Z703SerasaAcoesDistribuidor = A703SerasaAcoesDistribuidor;
            Z704SerasaAcoesVara = A704SerasaAcoesVara;
            Z705SerasaAcoesCidade = A705SerasaAcoesCidade;
            Z706SerasaAcoesUF = A706SerasaAcoesUF;
            Z707SerasaAcoesPrincipal = A707SerasaAcoesPrincipal;
            Z708SerasaAcoesTipoMoeda = A708SerasaAcoesTipoMoeda;
            Z709SerasaAcoesQtdOco = A709SerasaAcoesQtdOco;
            Z662SerasaId = A662SerasaId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -4 )
         {
            Z699SerasaAcoesId = A699SerasaAcoesId;
            Z700SerasaAcoesData = A700SerasaAcoesData;
            Z701SerasaAcoesNatureza = A701SerasaAcoesNatureza;
            Z702SerasaAcoesValor = A702SerasaAcoesValor;
            Z703SerasaAcoesDistribuidor = A703SerasaAcoesDistribuidor;
            Z704SerasaAcoesVara = A704SerasaAcoesVara;
            Z705SerasaAcoesCidade = A705SerasaAcoesCidade;
            Z706SerasaAcoesUF = A706SerasaAcoesUF;
            Z707SerasaAcoesPrincipal = A707SerasaAcoesPrincipal;
            Z708SerasaAcoesTipoMoeda = A708SerasaAcoesTipoMoeda;
            Z709SerasaAcoesQtdOco = A709SerasaAcoesQtdOco;
            Z662SerasaId = A662SerasaId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV19Pgmname = "SerasaAcoes_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2G86( )
      {
         /* Using cursor BC002G5 */
         pr_default.execute(3, new Object[] {A699SerasaAcoesId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound86 = 1;
            A700SerasaAcoesData = BC002G5_A700SerasaAcoesData[0];
            n700SerasaAcoesData = BC002G5_n700SerasaAcoesData[0];
            A701SerasaAcoesNatureza = BC002G5_A701SerasaAcoesNatureza[0];
            n701SerasaAcoesNatureza = BC002G5_n701SerasaAcoesNatureza[0];
            A702SerasaAcoesValor = BC002G5_A702SerasaAcoesValor[0];
            n702SerasaAcoesValor = BC002G5_n702SerasaAcoesValor[0];
            A703SerasaAcoesDistribuidor = BC002G5_A703SerasaAcoesDistribuidor[0];
            n703SerasaAcoesDistribuidor = BC002G5_n703SerasaAcoesDistribuidor[0];
            A704SerasaAcoesVara = BC002G5_A704SerasaAcoesVara[0];
            n704SerasaAcoesVara = BC002G5_n704SerasaAcoesVara[0];
            A705SerasaAcoesCidade = BC002G5_A705SerasaAcoesCidade[0];
            n705SerasaAcoesCidade = BC002G5_n705SerasaAcoesCidade[0];
            A706SerasaAcoesUF = BC002G5_A706SerasaAcoesUF[0];
            n706SerasaAcoesUF = BC002G5_n706SerasaAcoesUF[0];
            A707SerasaAcoesPrincipal = BC002G5_A707SerasaAcoesPrincipal[0];
            n707SerasaAcoesPrincipal = BC002G5_n707SerasaAcoesPrincipal[0];
            A708SerasaAcoesTipoMoeda = BC002G5_A708SerasaAcoesTipoMoeda[0];
            n708SerasaAcoesTipoMoeda = BC002G5_n708SerasaAcoesTipoMoeda[0];
            A709SerasaAcoesQtdOco = BC002G5_A709SerasaAcoesQtdOco[0];
            n709SerasaAcoesQtdOco = BC002G5_n709SerasaAcoesQtdOco[0];
            A662SerasaId = BC002G5_A662SerasaId[0];
            n662SerasaId = BC002G5_n662SerasaId[0];
            ZM2G86( -4) ;
         }
         pr_default.close(3);
         OnLoadActions2G86( ) ;
      }

      protected void OnLoadActions2G86( )
      {
      }

      protected void CheckExtendedTable2G86( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002G4 */
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
         if ( ( A702SerasaAcoesValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2G86( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2G86( )
      {
         /* Using cursor BC002G6 */
         pr_default.execute(4, new Object[] {A699SerasaAcoesId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound86 = 1;
         }
         else
         {
            RcdFound86 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002G3 */
         pr_default.execute(1, new Object[] {A699SerasaAcoesId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2G86( 4) ;
            RcdFound86 = 1;
            A699SerasaAcoesId = BC002G3_A699SerasaAcoesId[0];
            A700SerasaAcoesData = BC002G3_A700SerasaAcoesData[0];
            n700SerasaAcoesData = BC002G3_n700SerasaAcoesData[0];
            A701SerasaAcoesNatureza = BC002G3_A701SerasaAcoesNatureza[0];
            n701SerasaAcoesNatureza = BC002G3_n701SerasaAcoesNatureza[0];
            A702SerasaAcoesValor = BC002G3_A702SerasaAcoesValor[0];
            n702SerasaAcoesValor = BC002G3_n702SerasaAcoesValor[0];
            A703SerasaAcoesDistribuidor = BC002G3_A703SerasaAcoesDistribuidor[0];
            n703SerasaAcoesDistribuidor = BC002G3_n703SerasaAcoesDistribuidor[0];
            A704SerasaAcoesVara = BC002G3_A704SerasaAcoesVara[0];
            n704SerasaAcoesVara = BC002G3_n704SerasaAcoesVara[0];
            A705SerasaAcoesCidade = BC002G3_A705SerasaAcoesCidade[0];
            n705SerasaAcoesCidade = BC002G3_n705SerasaAcoesCidade[0];
            A706SerasaAcoesUF = BC002G3_A706SerasaAcoesUF[0];
            n706SerasaAcoesUF = BC002G3_n706SerasaAcoesUF[0];
            A707SerasaAcoesPrincipal = BC002G3_A707SerasaAcoesPrincipal[0];
            n707SerasaAcoesPrincipal = BC002G3_n707SerasaAcoesPrincipal[0];
            A708SerasaAcoesTipoMoeda = BC002G3_A708SerasaAcoesTipoMoeda[0];
            n708SerasaAcoesTipoMoeda = BC002G3_n708SerasaAcoesTipoMoeda[0];
            A709SerasaAcoesQtdOco = BC002G3_A709SerasaAcoesQtdOco[0];
            n709SerasaAcoesQtdOco = BC002G3_n709SerasaAcoesQtdOco[0];
            A662SerasaId = BC002G3_A662SerasaId[0];
            n662SerasaId = BC002G3_n662SerasaId[0];
            Z699SerasaAcoesId = A699SerasaAcoesId;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2G86( ) ;
            if ( AnyError == 1 )
            {
               RcdFound86 = 0;
               InitializeNonKey2G86( ) ;
            }
            Gx_mode = sMode86;
         }
         else
         {
            RcdFound86 = 0;
            InitializeNonKey2G86( ) ;
            sMode86 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode86;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2G86( ) ;
         if ( RcdFound86 == 0 )
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
         CONFIRM_2G0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2G86( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002G2 */
            pr_default.execute(0, new Object[] {A699SerasaAcoesId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaAcoes"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z700SerasaAcoesData ) != DateTimeUtil.ResetTime ( BC002G2_A700SerasaAcoesData[0] ) ) || ( StringUtil.StrCmp(Z701SerasaAcoesNatureza, BC002G2_A701SerasaAcoesNatureza[0]) != 0 ) || ( Z702SerasaAcoesValor != BC002G2_A702SerasaAcoesValor[0] ) || ( StringUtil.StrCmp(Z703SerasaAcoesDistribuidor, BC002G2_A703SerasaAcoesDistribuidor[0]) != 0 ) || ( StringUtil.StrCmp(Z704SerasaAcoesVara, BC002G2_A704SerasaAcoesVara[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z705SerasaAcoesCidade, BC002G2_A705SerasaAcoesCidade[0]) != 0 ) || ( StringUtil.StrCmp(Z706SerasaAcoesUF, BC002G2_A706SerasaAcoesUF[0]) != 0 ) || ( StringUtil.StrCmp(Z707SerasaAcoesPrincipal, BC002G2_A707SerasaAcoesPrincipal[0]) != 0 ) || ( StringUtil.StrCmp(Z708SerasaAcoesTipoMoeda, BC002G2_A708SerasaAcoesTipoMoeda[0]) != 0 ) || ( Z709SerasaAcoesQtdOco != BC002G2_A709SerasaAcoesQtdOco[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z662SerasaId != BC002G2_A662SerasaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SerasaAcoes"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2G86( )
      {
         BeforeValidate2G86( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2G86( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2G86( 0) ;
            CheckOptimisticConcurrency2G86( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2G86( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2G86( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002G7 */
                     pr_default.execute(5, new Object[] {n700SerasaAcoesData, A700SerasaAcoesData, n701SerasaAcoesNatureza, A701SerasaAcoesNatureza, n702SerasaAcoesValor, A702SerasaAcoesValor, n703SerasaAcoesDistribuidor, A703SerasaAcoesDistribuidor, n704SerasaAcoesVara, A704SerasaAcoesVara, n705SerasaAcoesCidade, A705SerasaAcoesCidade, n706SerasaAcoesUF, A706SerasaAcoesUF, n707SerasaAcoesPrincipal, A707SerasaAcoesPrincipal, n708SerasaAcoesTipoMoeda, A708SerasaAcoesTipoMoeda, n709SerasaAcoesQtdOco, A709SerasaAcoesQtdOco, n662SerasaId, A662SerasaId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002G8 */
                     pr_default.execute(6);
                     A699SerasaAcoesId = BC002G8_A699SerasaAcoesId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaAcoes");
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
               Load2G86( ) ;
            }
            EndLevel2G86( ) ;
         }
         CloseExtendedTableCursors2G86( ) ;
      }

      protected void Update2G86( )
      {
         BeforeValidate2G86( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2G86( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2G86( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2G86( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2G86( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002G9 */
                     pr_default.execute(7, new Object[] {n700SerasaAcoesData, A700SerasaAcoesData, n701SerasaAcoesNatureza, A701SerasaAcoesNatureza, n702SerasaAcoesValor, A702SerasaAcoesValor, n703SerasaAcoesDistribuidor, A703SerasaAcoesDistribuidor, n704SerasaAcoesVara, A704SerasaAcoesVara, n705SerasaAcoesCidade, A705SerasaAcoesCidade, n706SerasaAcoesUF, A706SerasaAcoesUF, n707SerasaAcoesPrincipal, A707SerasaAcoesPrincipal, n708SerasaAcoesTipoMoeda, A708SerasaAcoesTipoMoeda, n709SerasaAcoesQtdOco, A709SerasaAcoesQtdOco, n662SerasaId, A662SerasaId, A699SerasaAcoesId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaAcoes");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaAcoes"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2G86( ) ;
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
            EndLevel2G86( ) ;
         }
         CloseExtendedTableCursors2G86( ) ;
      }

      protected void DeferredUpdate2G86( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2G86( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2G86( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2G86( ) ;
            AfterConfirm2G86( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2G86( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002G10 */
                  pr_default.execute(8, new Object[] {A699SerasaAcoesId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("SerasaAcoes");
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
         sMode86 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2G86( ) ;
         Gx_mode = sMode86;
      }

      protected void OnDeleteControls2G86( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2G86( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2G86( ) ;
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

      public void ScanKeyStart2G86( )
      {
         /* Scan By routine */
         /* Using cursor BC002G11 */
         pr_default.execute(9, new Object[] {A699SerasaAcoesId});
         RcdFound86 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound86 = 1;
            A699SerasaAcoesId = BC002G11_A699SerasaAcoesId[0];
            A700SerasaAcoesData = BC002G11_A700SerasaAcoesData[0];
            n700SerasaAcoesData = BC002G11_n700SerasaAcoesData[0];
            A701SerasaAcoesNatureza = BC002G11_A701SerasaAcoesNatureza[0];
            n701SerasaAcoesNatureza = BC002G11_n701SerasaAcoesNatureza[0];
            A702SerasaAcoesValor = BC002G11_A702SerasaAcoesValor[0];
            n702SerasaAcoesValor = BC002G11_n702SerasaAcoesValor[0];
            A703SerasaAcoesDistribuidor = BC002G11_A703SerasaAcoesDistribuidor[0];
            n703SerasaAcoesDistribuidor = BC002G11_n703SerasaAcoesDistribuidor[0];
            A704SerasaAcoesVara = BC002G11_A704SerasaAcoesVara[0];
            n704SerasaAcoesVara = BC002G11_n704SerasaAcoesVara[0];
            A705SerasaAcoesCidade = BC002G11_A705SerasaAcoesCidade[0];
            n705SerasaAcoesCidade = BC002G11_n705SerasaAcoesCidade[0];
            A706SerasaAcoesUF = BC002G11_A706SerasaAcoesUF[0];
            n706SerasaAcoesUF = BC002G11_n706SerasaAcoesUF[0];
            A707SerasaAcoesPrincipal = BC002G11_A707SerasaAcoesPrincipal[0];
            n707SerasaAcoesPrincipal = BC002G11_n707SerasaAcoesPrincipal[0];
            A708SerasaAcoesTipoMoeda = BC002G11_A708SerasaAcoesTipoMoeda[0];
            n708SerasaAcoesTipoMoeda = BC002G11_n708SerasaAcoesTipoMoeda[0];
            A709SerasaAcoesQtdOco = BC002G11_A709SerasaAcoesQtdOco[0];
            n709SerasaAcoesQtdOco = BC002G11_n709SerasaAcoesQtdOco[0];
            A662SerasaId = BC002G11_A662SerasaId[0];
            n662SerasaId = BC002G11_n662SerasaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2G86( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound86 = 0;
         ScanKeyLoad2G86( ) ;
      }

      protected void ScanKeyLoad2G86( )
      {
         sMode86 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound86 = 1;
            A699SerasaAcoesId = BC002G11_A699SerasaAcoesId[0];
            A700SerasaAcoesData = BC002G11_A700SerasaAcoesData[0];
            n700SerasaAcoesData = BC002G11_n700SerasaAcoesData[0];
            A701SerasaAcoesNatureza = BC002G11_A701SerasaAcoesNatureza[0];
            n701SerasaAcoesNatureza = BC002G11_n701SerasaAcoesNatureza[0];
            A702SerasaAcoesValor = BC002G11_A702SerasaAcoesValor[0];
            n702SerasaAcoesValor = BC002G11_n702SerasaAcoesValor[0];
            A703SerasaAcoesDistribuidor = BC002G11_A703SerasaAcoesDistribuidor[0];
            n703SerasaAcoesDistribuidor = BC002G11_n703SerasaAcoesDistribuidor[0];
            A704SerasaAcoesVara = BC002G11_A704SerasaAcoesVara[0];
            n704SerasaAcoesVara = BC002G11_n704SerasaAcoesVara[0];
            A705SerasaAcoesCidade = BC002G11_A705SerasaAcoesCidade[0];
            n705SerasaAcoesCidade = BC002G11_n705SerasaAcoesCidade[0];
            A706SerasaAcoesUF = BC002G11_A706SerasaAcoesUF[0];
            n706SerasaAcoesUF = BC002G11_n706SerasaAcoesUF[0];
            A707SerasaAcoesPrincipal = BC002G11_A707SerasaAcoesPrincipal[0];
            n707SerasaAcoesPrincipal = BC002G11_n707SerasaAcoesPrincipal[0];
            A708SerasaAcoesTipoMoeda = BC002G11_A708SerasaAcoesTipoMoeda[0];
            n708SerasaAcoesTipoMoeda = BC002G11_n708SerasaAcoesTipoMoeda[0];
            A709SerasaAcoesQtdOco = BC002G11_A709SerasaAcoesQtdOco[0];
            n709SerasaAcoesQtdOco = BC002G11_n709SerasaAcoesQtdOco[0];
            A662SerasaId = BC002G11_A662SerasaId[0];
            n662SerasaId = BC002G11_n662SerasaId[0];
         }
         Gx_mode = sMode86;
      }

      protected void ScanKeyEnd2G86( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm2G86( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2G86( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2G86( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2G86( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2G86( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2G86( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2G86( )
      {
      }

      protected void send_integrity_lvl_hashes2G86( )
      {
      }

      protected void AddRow2G86( )
      {
         VarsToRow86( bcSerasaAcoes) ;
      }

      protected void ReadRow2G86( )
      {
         RowToVars86( bcSerasaAcoes, 1) ;
      }

      protected void InitializeNonKey2G86( )
      {
         A662SerasaId = 0;
         n662SerasaId = false;
         A700SerasaAcoesData = DateTime.MinValue;
         n700SerasaAcoesData = false;
         A701SerasaAcoesNatureza = "";
         n701SerasaAcoesNatureza = false;
         A702SerasaAcoesValor = 0;
         n702SerasaAcoesValor = false;
         A703SerasaAcoesDistribuidor = "";
         n703SerasaAcoesDistribuidor = false;
         A704SerasaAcoesVara = "";
         n704SerasaAcoesVara = false;
         A705SerasaAcoesCidade = "";
         n705SerasaAcoesCidade = false;
         A706SerasaAcoesUF = "";
         n706SerasaAcoesUF = false;
         A707SerasaAcoesPrincipal = "";
         n707SerasaAcoesPrincipal = false;
         A708SerasaAcoesTipoMoeda = "";
         n708SerasaAcoesTipoMoeda = false;
         A709SerasaAcoesQtdOco = 0;
         n709SerasaAcoesQtdOco = false;
         Z700SerasaAcoesData = DateTime.MinValue;
         Z701SerasaAcoesNatureza = "";
         Z702SerasaAcoesValor = 0;
         Z703SerasaAcoesDistribuidor = "";
         Z704SerasaAcoesVara = "";
         Z705SerasaAcoesCidade = "";
         Z706SerasaAcoesUF = "";
         Z707SerasaAcoesPrincipal = "";
         Z708SerasaAcoesTipoMoeda = "";
         Z709SerasaAcoesQtdOco = 0;
         Z662SerasaId = 0;
      }

      protected void InitAll2G86( )
      {
         A699SerasaAcoesId = 0;
         InitializeNonKey2G86( ) ;
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

      public void VarsToRow86( SdtSerasaAcoes obj86 )
      {
         obj86.gxTpr_Mode = Gx_mode;
         obj86.gxTpr_Serasaid = A662SerasaId;
         obj86.gxTpr_Serasaacoesdata = A700SerasaAcoesData;
         obj86.gxTpr_Serasaacoesnatureza = A701SerasaAcoesNatureza;
         obj86.gxTpr_Serasaacoesvalor = A702SerasaAcoesValor;
         obj86.gxTpr_Serasaacoesdistribuidor = A703SerasaAcoesDistribuidor;
         obj86.gxTpr_Serasaacoesvara = A704SerasaAcoesVara;
         obj86.gxTpr_Serasaacoescidade = A705SerasaAcoesCidade;
         obj86.gxTpr_Serasaacoesuf = A706SerasaAcoesUF;
         obj86.gxTpr_Serasaacoesprincipal = A707SerasaAcoesPrincipal;
         obj86.gxTpr_Serasaacoestipomoeda = A708SerasaAcoesTipoMoeda;
         obj86.gxTpr_Serasaacoesqtdoco = A709SerasaAcoesQtdOco;
         obj86.gxTpr_Serasaacoesid = A699SerasaAcoesId;
         obj86.gxTpr_Serasaacoesid_Z = Z699SerasaAcoesId;
         obj86.gxTpr_Serasaid_Z = Z662SerasaId;
         obj86.gxTpr_Serasaacoesdata_Z = Z700SerasaAcoesData;
         obj86.gxTpr_Serasaacoesnatureza_Z = Z701SerasaAcoesNatureza;
         obj86.gxTpr_Serasaacoesvalor_Z = Z702SerasaAcoesValor;
         obj86.gxTpr_Serasaacoesdistribuidor_Z = Z703SerasaAcoesDistribuidor;
         obj86.gxTpr_Serasaacoesvara_Z = Z704SerasaAcoesVara;
         obj86.gxTpr_Serasaacoescidade_Z = Z705SerasaAcoesCidade;
         obj86.gxTpr_Serasaacoesuf_Z = Z706SerasaAcoesUF;
         obj86.gxTpr_Serasaacoesprincipal_Z = Z707SerasaAcoesPrincipal;
         obj86.gxTpr_Serasaacoestipomoeda_Z = Z708SerasaAcoesTipoMoeda;
         obj86.gxTpr_Serasaacoesqtdoco_Z = Z709SerasaAcoesQtdOco;
         obj86.gxTpr_Serasaid_N = (short)(Convert.ToInt16(n662SerasaId));
         obj86.gxTpr_Serasaacoesdata_N = (short)(Convert.ToInt16(n700SerasaAcoesData));
         obj86.gxTpr_Serasaacoesnatureza_N = (short)(Convert.ToInt16(n701SerasaAcoesNatureza));
         obj86.gxTpr_Serasaacoesvalor_N = (short)(Convert.ToInt16(n702SerasaAcoesValor));
         obj86.gxTpr_Serasaacoesdistribuidor_N = (short)(Convert.ToInt16(n703SerasaAcoesDistribuidor));
         obj86.gxTpr_Serasaacoesvara_N = (short)(Convert.ToInt16(n704SerasaAcoesVara));
         obj86.gxTpr_Serasaacoescidade_N = (short)(Convert.ToInt16(n705SerasaAcoesCidade));
         obj86.gxTpr_Serasaacoesuf_N = (short)(Convert.ToInt16(n706SerasaAcoesUF));
         obj86.gxTpr_Serasaacoesprincipal_N = (short)(Convert.ToInt16(n707SerasaAcoesPrincipal));
         obj86.gxTpr_Serasaacoestipomoeda_N = (short)(Convert.ToInt16(n708SerasaAcoesTipoMoeda));
         obj86.gxTpr_Serasaacoesqtdoco_N = (short)(Convert.ToInt16(n709SerasaAcoesQtdOco));
         obj86.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow86( SdtSerasaAcoes obj86 )
      {
         obj86.gxTpr_Serasaacoesid = A699SerasaAcoesId;
         return  ;
      }

      public void RowToVars86( SdtSerasaAcoes obj86 ,
                               int forceLoad )
      {
         Gx_mode = obj86.gxTpr_Mode;
         A662SerasaId = obj86.gxTpr_Serasaid;
         n662SerasaId = false;
         A700SerasaAcoesData = obj86.gxTpr_Serasaacoesdata;
         n700SerasaAcoesData = false;
         A701SerasaAcoesNatureza = obj86.gxTpr_Serasaacoesnatureza;
         n701SerasaAcoesNatureza = false;
         A702SerasaAcoesValor = obj86.gxTpr_Serasaacoesvalor;
         n702SerasaAcoesValor = false;
         A703SerasaAcoesDistribuidor = obj86.gxTpr_Serasaacoesdistribuidor;
         n703SerasaAcoesDistribuidor = false;
         A704SerasaAcoesVara = obj86.gxTpr_Serasaacoesvara;
         n704SerasaAcoesVara = false;
         A705SerasaAcoesCidade = obj86.gxTpr_Serasaacoescidade;
         n705SerasaAcoesCidade = false;
         A706SerasaAcoesUF = obj86.gxTpr_Serasaacoesuf;
         n706SerasaAcoesUF = false;
         A707SerasaAcoesPrincipal = obj86.gxTpr_Serasaacoesprincipal;
         n707SerasaAcoesPrincipal = false;
         A708SerasaAcoesTipoMoeda = obj86.gxTpr_Serasaacoestipomoeda;
         n708SerasaAcoesTipoMoeda = false;
         A709SerasaAcoesQtdOco = obj86.gxTpr_Serasaacoesqtdoco;
         n709SerasaAcoesQtdOco = false;
         A699SerasaAcoesId = obj86.gxTpr_Serasaacoesid;
         Z699SerasaAcoesId = obj86.gxTpr_Serasaacoesid_Z;
         Z662SerasaId = obj86.gxTpr_Serasaid_Z;
         Z700SerasaAcoesData = obj86.gxTpr_Serasaacoesdata_Z;
         Z701SerasaAcoesNatureza = obj86.gxTpr_Serasaacoesnatureza_Z;
         Z702SerasaAcoesValor = obj86.gxTpr_Serasaacoesvalor_Z;
         Z703SerasaAcoesDistribuidor = obj86.gxTpr_Serasaacoesdistribuidor_Z;
         Z704SerasaAcoesVara = obj86.gxTpr_Serasaacoesvara_Z;
         Z705SerasaAcoesCidade = obj86.gxTpr_Serasaacoescidade_Z;
         Z706SerasaAcoesUF = obj86.gxTpr_Serasaacoesuf_Z;
         Z707SerasaAcoesPrincipal = obj86.gxTpr_Serasaacoesprincipal_Z;
         Z708SerasaAcoesTipoMoeda = obj86.gxTpr_Serasaacoestipomoeda_Z;
         Z709SerasaAcoesQtdOco = obj86.gxTpr_Serasaacoesqtdoco_Z;
         n662SerasaId = (bool)(Convert.ToBoolean(obj86.gxTpr_Serasaid_N));
         n700SerasaAcoesData = (bool)(Convert.ToBoolean(obj86.gxTpr_Serasaacoesdata_N));
         n701SerasaAcoesNatureza = (bool)(Convert.ToBoolean(obj86.gxTpr_Serasaacoesnatureza_N));
         n702SerasaAcoesValor = (bool)(Convert.ToBoolean(obj86.gxTpr_Serasaacoesvalor_N));
         n703SerasaAcoesDistribuidor = (bool)(Convert.ToBoolean(obj86.gxTpr_Serasaacoesdistribuidor_N));
         n704SerasaAcoesVara = (bool)(Convert.ToBoolean(obj86.gxTpr_Serasaacoesvara_N));
         n705SerasaAcoesCidade = (bool)(Convert.ToBoolean(obj86.gxTpr_Serasaacoescidade_N));
         n706SerasaAcoesUF = (bool)(Convert.ToBoolean(obj86.gxTpr_Serasaacoesuf_N));
         n707SerasaAcoesPrincipal = (bool)(Convert.ToBoolean(obj86.gxTpr_Serasaacoesprincipal_N));
         n708SerasaAcoesTipoMoeda = (bool)(Convert.ToBoolean(obj86.gxTpr_Serasaacoestipomoeda_N));
         n709SerasaAcoesQtdOco = (bool)(Convert.ToBoolean(obj86.gxTpr_Serasaacoesqtdoco_N));
         Gx_mode = obj86.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A699SerasaAcoesId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2G86( ) ;
         ScanKeyStart2G86( ) ;
         if ( RcdFound86 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z699SerasaAcoesId = A699SerasaAcoesId;
         }
         ZM2G86( -4) ;
         OnLoadActions2G86( ) ;
         AddRow2G86( ) ;
         ScanKeyEnd2G86( ) ;
         if ( RcdFound86 == 0 )
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
         RowToVars86( bcSerasaAcoes, 0) ;
         ScanKeyStart2G86( ) ;
         if ( RcdFound86 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z699SerasaAcoesId = A699SerasaAcoesId;
         }
         ZM2G86( -4) ;
         OnLoadActions2G86( ) ;
         AddRow2G86( ) ;
         ScanKeyEnd2G86( ) ;
         if ( RcdFound86 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2G86( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2G86( ) ;
         }
         else
         {
            if ( RcdFound86 == 1 )
            {
               if ( A699SerasaAcoesId != Z699SerasaAcoesId )
               {
                  A699SerasaAcoesId = Z699SerasaAcoesId;
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
                  Update2G86( ) ;
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
                  if ( A699SerasaAcoesId != Z699SerasaAcoesId )
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
                        Insert2G86( ) ;
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
                        Insert2G86( ) ;
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
         RowToVars86( bcSerasaAcoes, 1) ;
         SaveImpl( ) ;
         VarsToRow86( bcSerasaAcoes) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars86( bcSerasaAcoes, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2G86( ) ;
         AfterTrn( ) ;
         VarsToRow86( bcSerasaAcoes) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow86( bcSerasaAcoes) ;
         }
         else
         {
            SdtSerasaAcoes auxBC = new SdtSerasaAcoes(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A699SerasaAcoesId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSerasaAcoes);
               auxBC.Save();
               bcSerasaAcoes.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars86( bcSerasaAcoes, 1) ;
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
         RowToVars86( bcSerasaAcoes, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2G86( ) ;
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
               VarsToRow86( bcSerasaAcoes) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow86( bcSerasaAcoes) ;
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
         RowToVars86( bcSerasaAcoes, 0) ;
         GetKey2G86( ) ;
         if ( RcdFound86 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A699SerasaAcoesId != Z699SerasaAcoesId )
            {
               A699SerasaAcoesId = Z699SerasaAcoesId;
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
            if ( A699SerasaAcoesId != Z699SerasaAcoesId )
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
         context.RollbackDataStores("serasaacoes_bc",pr_default);
         VarsToRow86( bcSerasaAcoes) ;
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
         Gx_mode = bcSerasaAcoes.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSerasaAcoes.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSerasaAcoes )
         {
            bcSerasaAcoes = (SdtSerasaAcoes)(sdt);
            if ( StringUtil.StrCmp(bcSerasaAcoes.gxTpr_Mode, "") == 0 )
            {
               bcSerasaAcoes.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow86( bcSerasaAcoes) ;
            }
            else
            {
               RowToVars86( bcSerasaAcoes, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSerasaAcoes.gxTpr_Mode, "") == 0 )
            {
               bcSerasaAcoes.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars86( bcSerasaAcoes, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSerasaAcoes SerasaAcoes_BC
      {
         get {
            return bcSerasaAcoes ;
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
         Z700SerasaAcoesData = DateTime.MinValue;
         A700SerasaAcoesData = DateTime.MinValue;
         Z701SerasaAcoesNatureza = "";
         A701SerasaAcoesNatureza = "";
         Z703SerasaAcoesDistribuidor = "";
         A703SerasaAcoesDistribuidor = "";
         Z704SerasaAcoesVara = "";
         A704SerasaAcoesVara = "";
         Z705SerasaAcoesCidade = "";
         A705SerasaAcoesCidade = "";
         Z706SerasaAcoesUF = "";
         A706SerasaAcoesUF = "";
         Z707SerasaAcoesPrincipal = "";
         A707SerasaAcoesPrincipal = "";
         Z708SerasaAcoesTipoMoeda = "";
         A708SerasaAcoesTipoMoeda = "";
         BC002G5_A699SerasaAcoesId = new int[1] ;
         BC002G5_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         BC002G5_n700SerasaAcoesData = new bool[] {false} ;
         BC002G5_A701SerasaAcoesNatureza = new string[] {""} ;
         BC002G5_n701SerasaAcoesNatureza = new bool[] {false} ;
         BC002G5_A702SerasaAcoesValor = new decimal[1] ;
         BC002G5_n702SerasaAcoesValor = new bool[] {false} ;
         BC002G5_A703SerasaAcoesDistribuidor = new string[] {""} ;
         BC002G5_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         BC002G5_A704SerasaAcoesVara = new string[] {""} ;
         BC002G5_n704SerasaAcoesVara = new bool[] {false} ;
         BC002G5_A705SerasaAcoesCidade = new string[] {""} ;
         BC002G5_n705SerasaAcoesCidade = new bool[] {false} ;
         BC002G5_A706SerasaAcoesUF = new string[] {""} ;
         BC002G5_n706SerasaAcoesUF = new bool[] {false} ;
         BC002G5_A707SerasaAcoesPrincipal = new string[] {""} ;
         BC002G5_n707SerasaAcoesPrincipal = new bool[] {false} ;
         BC002G5_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         BC002G5_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         BC002G5_A709SerasaAcoesQtdOco = new short[1] ;
         BC002G5_n709SerasaAcoesQtdOco = new bool[] {false} ;
         BC002G5_A662SerasaId = new int[1] ;
         BC002G5_n662SerasaId = new bool[] {false} ;
         BC002G4_A662SerasaId = new int[1] ;
         BC002G4_n662SerasaId = new bool[] {false} ;
         BC002G6_A699SerasaAcoesId = new int[1] ;
         BC002G3_A699SerasaAcoesId = new int[1] ;
         BC002G3_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         BC002G3_n700SerasaAcoesData = new bool[] {false} ;
         BC002G3_A701SerasaAcoesNatureza = new string[] {""} ;
         BC002G3_n701SerasaAcoesNatureza = new bool[] {false} ;
         BC002G3_A702SerasaAcoesValor = new decimal[1] ;
         BC002G3_n702SerasaAcoesValor = new bool[] {false} ;
         BC002G3_A703SerasaAcoesDistribuidor = new string[] {""} ;
         BC002G3_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         BC002G3_A704SerasaAcoesVara = new string[] {""} ;
         BC002G3_n704SerasaAcoesVara = new bool[] {false} ;
         BC002G3_A705SerasaAcoesCidade = new string[] {""} ;
         BC002G3_n705SerasaAcoesCidade = new bool[] {false} ;
         BC002G3_A706SerasaAcoesUF = new string[] {""} ;
         BC002G3_n706SerasaAcoesUF = new bool[] {false} ;
         BC002G3_A707SerasaAcoesPrincipal = new string[] {""} ;
         BC002G3_n707SerasaAcoesPrincipal = new bool[] {false} ;
         BC002G3_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         BC002G3_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         BC002G3_A709SerasaAcoesQtdOco = new short[1] ;
         BC002G3_n709SerasaAcoesQtdOco = new bool[] {false} ;
         BC002G3_A662SerasaId = new int[1] ;
         BC002G3_n662SerasaId = new bool[] {false} ;
         sMode86 = "";
         BC002G2_A699SerasaAcoesId = new int[1] ;
         BC002G2_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         BC002G2_n700SerasaAcoesData = new bool[] {false} ;
         BC002G2_A701SerasaAcoesNatureza = new string[] {""} ;
         BC002G2_n701SerasaAcoesNatureza = new bool[] {false} ;
         BC002G2_A702SerasaAcoesValor = new decimal[1] ;
         BC002G2_n702SerasaAcoesValor = new bool[] {false} ;
         BC002G2_A703SerasaAcoesDistribuidor = new string[] {""} ;
         BC002G2_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         BC002G2_A704SerasaAcoesVara = new string[] {""} ;
         BC002G2_n704SerasaAcoesVara = new bool[] {false} ;
         BC002G2_A705SerasaAcoesCidade = new string[] {""} ;
         BC002G2_n705SerasaAcoesCidade = new bool[] {false} ;
         BC002G2_A706SerasaAcoesUF = new string[] {""} ;
         BC002G2_n706SerasaAcoesUF = new bool[] {false} ;
         BC002G2_A707SerasaAcoesPrincipal = new string[] {""} ;
         BC002G2_n707SerasaAcoesPrincipal = new bool[] {false} ;
         BC002G2_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         BC002G2_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         BC002G2_A709SerasaAcoesQtdOco = new short[1] ;
         BC002G2_n709SerasaAcoesQtdOco = new bool[] {false} ;
         BC002G2_A662SerasaId = new int[1] ;
         BC002G2_n662SerasaId = new bool[] {false} ;
         BC002G8_A699SerasaAcoesId = new int[1] ;
         BC002G11_A699SerasaAcoesId = new int[1] ;
         BC002G11_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         BC002G11_n700SerasaAcoesData = new bool[] {false} ;
         BC002G11_A701SerasaAcoesNatureza = new string[] {""} ;
         BC002G11_n701SerasaAcoesNatureza = new bool[] {false} ;
         BC002G11_A702SerasaAcoesValor = new decimal[1] ;
         BC002G11_n702SerasaAcoesValor = new bool[] {false} ;
         BC002G11_A703SerasaAcoesDistribuidor = new string[] {""} ;
         BC002G11_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         BC002G11_A704SerasaAcoesVara = new string[] {""} ;
         BC002G11_n704SerasaAcoesVara = new bool[] {false} ;
         BC002G11_A705SerasaAcoesCidade = new string[] {""} ;
         BC002G11_n705SerasaAcoesCidade = new bool[] {false} ;
         BC002G11_A706SerasaAcoesUF = new string[] {""} ;
         BC002G11_n706SerasaAcoesUF = new bool[] {false} ;
         BC002G11_A707SerasaAcoesPrincipal = new string[] {""} ;
         BC002G11_n707SerasaAcoesPrincipal = new bool[] {false} ;
         BC002G11_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         BC002G11_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         BC002G11_A709SerasaAcoesQtdOco = new short[1] ;
         BC002G11_n709SerasaAcoesQtdOco = new bool[] {false} ;
         BC002G11_A662SerasaId = new int[1] ;
         BC002G11_n662SerasaId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaacoes_bc__default(),
            new Object[][] {
                new Object[] {
               BC002G2_A699SerasaAcoesId, BC002G2_A700SerasaAcoesData, BC002G2_n700SerasaAcoesData, BC002G2_A701SerasaAcoesNatureza, BC002G2_n701SerasaAcoesNatureza, BC002G2_A702SerasaAcoesValor, BC002G2_n702SerasaAcoesValor, BC002G2_A703SerasaAcoesDistribuidor, BC002G2_n703SerasaAcoesDistribuidor, BC002G2_A704SerasaAcoesVara,
               BC002G2_n704SerasaAcoesVara, BC002G2_A705SerasaAcoesCidade, BC002G2_n705SerasaAcoesCidade, BC002G2_A706SerasaAcoesUF, BC002G2_n706SerasaAcoesUF, BC002G2_A707SerasaAcoesPrincipal, BC002G2_n707SerasaAcoesPrincipal, BC002G2_A708SerasaAcoesTipoMoeda, BC002G2_n708SerasaAcoesTipoMoeda, BC002G2_A709SerasaAcoesQtdOco,
               BC002G2_n709SerasaAcoesQtdOco, BC002G2_A662SerasaId, BC002G2_n662SerasaId
               }
               , new Object[] {
               BC002G3_A699SerasaAcoesId, BC002G3_A700SerasaAcoesData, BC002G3_n700SerasaAcoesData, BC002G3_A701SerasaAcoesNatureza, BC002G3_n701SerasaAcoesNatureza, BC002G3_A702SerasaAcoesValor, BC002G3_n702SerasaAcoesValor, BC002G3_A703SerasaAcoesDistribuidor, BC002G3_n703SerasaAcoesDistribuidor, BC002G3_A704SerasaAcoesVara,
               BC002G3_n704SerasaAcoesVara, BC002G3_A705SerasaAcoesCidade, BC002G3_n705SerasaAcoesCidade, BC002G3_A706SerasaAcoesUF, BC002G3_n706SerasaAcoesUF, BC002G3_A707SerasaAcoesPrincipal, BC002G3_n707SerasaAcoesPrincipal, BC002G3_A708SerasaAcoesTipoMoeda, BC002G3_n708SerasaAcoesTipoMoeda, BC002G3_A709SerasaAcoesQtdOco,
               BC002G3_n709SerasaAcoesQtdOco, BC002G3_A662SerasaId, BC002G3_n662SerasaId
               }
               , new Object[] {
               BC002G4_A662SerasaId
               }
               , new Object[] {
               BC002G5_A699SerasaAcoesId, BC002G5_A700SerasaAcoesData, BC002G5_n700SerasaAcoesData, BC002G5_A701SerasaAcoesNatureza, BC002G5_n701SerasaAcoesNatureza, BC002G5_A702SerasaAcoesValor, BC002G5_n702SerasaAcoesValor, BC002G5_A703SerasaAcoesDistribuidor, BC002G5_n703SerasaAcoesDistribuidor, BC002G5_A704SerasaAcoesVara,
               BC002G5_n704SerasaAcoesVara, BC002G5_A705SerasaAcoesCidade, BC002G5_n705SerasaAcoesCidade, BC002G5_A706SerasaAcoesUF, BC002G5_n706SerasaAcoesUF, BC002G5_A707SerasaAcoesPrincipal, BC002G5_n707SerasaAcoesPrincipal, BC002G5_A708SerasaAcoesTipoMoeda, BC002G5_n708SerasaAcoesTipoMoeda, BC002G5_A709SerasaAcoesQtdOco,
               BC002G5_n709SerasaAcoesQtdOco, BC002G5_A662SerasaId, BC002G5_n662SerasaId
               }
               , new Object[] {
               BC002G6_A699SerasaAcoesId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002G8_A699SerasaAcoesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002G11_A699SerasaAcoesId, BC002G11_A700SerasaAcoesData, BC002G11_n700SerasaAcoesData, BC002G11_A701SerasaAcoesNatureza, BC002G11_n701SerasaAcoesNatureza, BC002G11_A702SerasaAcoesValor, BC002G11_n702SerasaAcoesValor, BC002G11_A703SerasaAcoesDistribuidor, BC002G11_n703SerasaAcoesDistribuidor, BC002G11_A704SerasaAcoesVara,
               BC002G11_n704SerasaAcoesVara, BC002G11_A705SerasaAcoesCidade, BC002G11_n705SerasaAcoesCidade, BC002G11_A706SerasaAcoesUF, BC002G11_n706SerasaAcoesUF, BC002G11_A707SerasaAcoesPrincipal, BC002G11_n707SerasaAcoesPrincipal, BC002G11_A708SerasaAcoesTipoMoeda, BC002G11_n708SerasaAcoesTipoMoeda, BC002G11_A709SerasaAcoesQtdOco,
               BC002G11_n709SerasaAcoesQtdOco, BC002G11_A662SerasaId, BC002G11_n662SerasaId
               }
            }
         );
         AV19Pgmname = "SerasaAcoes_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122G2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z709SerasaAcoesQtdOco ;
      private short A709SerasaAcoesQtdOco ;
      private short RcdFound86 ;
      private int trnEnded ;
      private int Z699SerasaAcoesId ;
      private int A699SerasaAcoesId ;
      private int AV20GXV1 ;
      private int AV11Insert_SerasaId ;
      private int Z662SerasaId ;
      private int A662SerasaId ;
      private decimal Z702SerasaAcoesValor ;
      private decimal A702SerasaAcoesValor ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV19Pgmname ;
      private string sMode86 ;
      private DateTime Z700SerasaAcoesData ;
      private DateTime A700SerasaAcoesData ;
      private bool returnInSub ;
      private bool n700SerasaAcoesData ;
      private bool n701SerasaAcoesNatureza ;
      private bool n702SerasaAcoesValor ;
      private bool n703SerasaAcoesDistribuidor ;
      private bool n704SerasaAcoesVara ;
      private bool n705SerasaAcoesCidade ;
      private bool n706SerasaAcoesUF ;
      private bool n707SerasaAcoesPrincipal ;
      private bool n708SerasaAcoesTipoMoeda ;
      private bool n709SerasaAcoesQtdOco ;
      private bool n662SerasaId ;
      private bool Gx_longc ;
      private string Z701SerasaAcoesNatureza ;
      private string A701SerasaAcoesNatureza ;
      private string Z703SerasaAcoesDistribuidor ;
      private string A703SerasaAcoesDistribuidor ;
      private string Z704SerasaAcoesVara ;
      private string A704SerasaAcoesVara ;
      private string Z705SerasaAcoesCidade ;
      private string A705SerasaAcoesCidade ;
      private string Z706SerasaAcoesUF ;
      private string A706SerasaAcoesUF ;
      private string Z707SerasaAcoesPrincipal ;
      private string A707SerasaAcoesPrincipal ;
      private string Z708SerasaAcoesTipoMoeda ;
      private string A708SerasaAcoesTipoMoeda ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002G5_A699SerasaAcoesId ;
      private DateTime[] BC002G5_A700SerasaAcoesData ;
      private bool[] BC002G5_n700SerasaAcoesData ;
      private string[] BC002G5_A701SerasaAcoesNatureza ;
      private bool[] BC002G5_n701SerasaAcoesNatureza ;
      private decimal[] BC002G5_A702SerasaAcoesValor ;
      private bool[] BC002G5_n702SerasaAcoesValor ;
      private string[] BC002G5_A703SerasaAcoesDistribuidor ;
      private bool[] BC002G5_n703SerasaAcoesDistribuidor ;
      private string[] BC002G5_A704SerasaAcoesVara ;
      private bool[] BC002G5_n704SerasaAcoesVara ;
      private string[] BC002G5_A705SerasaAcoesCidade ;
      private bool[] BC002G5_n705SerasaAcoesCidade ;
      private string[] BC002G5_A706SerasaAcoesUF ;
      private bool[] BC002G5_n706SerasaAcoesUF ;
      private string[] BC002G5_A707SerasaAcoesPrincipal ;
      private bool[] BC002G5_n707SerasaAcoesPrincipal ;
      private string[] BC002G5_A708SerasaAcoesTipoMoeda ;
      private bool[] BC002G5_n708SerasaAcoesTipoMoeda ;
      private short[] BC002G5_A709SerasaAcoesQtdOco ;
      private bool[] BC002G5_n709SerasaAcoesQtdOco ;
      private int[] BC002G5_A662SerasaId ;
      private bool[] BC002G5_n662SerasaId ;
      private int[] BC002G4_A662SerasaId ;
      private bool[] BC002G4_n662SerasaId ;
      private int[] BC002G6_A699SerasaAcoesId ;
      private int[] BC002G3_A699SerasaAcoesId ;
      private DateTime[] BC002G3_A700SerasaAcoesData ;
      private bool[] BC002G3_n700SerasaAcoesData ;
      private string[] BC002G3_A701SerasaAcoesNatureza ;
      private bool[] BC002G3_n701SerasaAcoesNatureza ;
      private decimal[] BC002G3_A702SerasaAcoesValor ;
      private bool[] BC002G3_n702SerasaAcoesValor ;
      private string[] BC002G3_A703SerasaAcoesDistribuidor ;
      private bool[] BC002G3_n703SerasaAcoesDistribuidor ;
      private string[] BC002G3_A704SerasaAcoesVara ;
      private bool[] BC002G3_n704SerasaAcoesVara ;
      private string[] BC002G3_A705SerasaAcoesCidade ;
      private bool[] BC002G3_n705SerasaAcoesCidade ;
      private string[] BC002G3_A706SerasaAcoesUF ;
      private bool[] BC002G3_n706SerasaAcoesUF ;
      private string[] BC002G3_A707SerasaAcoesPrincipal ;
      private bool[] BC002G3_n707SerasaAcoesPrincipal ;
      private string[] BC002G3_A708SerasaAcoesTipoMoeda ;
      private bool[] BC002G3_n708SerasaAcoesTipoMoeda ;
      private short[] BC002G3_A709SerasaAcoesQtdOco ;
      private bool[] BC002G3_n709SerasaAcoesQtdOco ;
      private int[] BC002G3_A662SerasaId ;
      private bool[] BC002G3_n662SerasaId ;
      private int[] BC002G2_A699SerasaAcoesId ;
      private DateTime[] BC002G2_A700SerasaAcoesData ;
      private bool[] BC002G2_n700SerasaAcoesData ;
      private string[] BC002G2_A701SerasaAcoesNatureza ;
      private bool[] BC002G2_n701SerasaAcoesNatureza ;
      private decimal[] BC002G2_A702SerasaAcoesValor ;
      private bool[] BC002G2_n702SerasaAcoesValor ;
      private string[] BC002G2_A703SerasaAcoesDistribuidor ;
      private bool[] BC002G2_n703SerasaAcoesDistribuidor ;
      private string[] BC002G2_A704SerasaAcoesVara ;
      private bool[] BC002G2_n704SerasaAcoesVara ;
      private string[] BC002G2_A705SerasaAcoesCidade ;
      private bool[] BC002G2_n705SerasaAcoesCidade ;
      private string[] BC002G2_A706SerasaAcoesUF ;
      private bool[] BC002G2_n706SerasaAcoesUF ;
      private string[] BC002G2_A707SerasaAcoesPrincipal ;
      private bool[] BC002G2_n707SerasaAcoesPrincipal ;
      private string[] BC002G2_A708SerasaAcoesTipoMoeda ;
      private bool[] BC002G2_n708SerasaAcoesTipoMoeda ;
      private short[] BC002G2_A709SerasaAcoesQtdOco ;
      private bool[] BC002G2_n709SerasaAcoesQtdOco ;
      private int[] BC002G2_A662SerasaId ;
      private bool[] BC002G2_n662SerasaId ;
      private int[] BC002G8_A699SerasaAcoesId ;
      private int[] BC002G11_A699SerasaAcoesId ;
      private DateTime[] BC002G11_A700SerasaAcoesData ;
      private bool[] BC002G11_n700SerasaAcoesData ;
      private string[] BC002G11_A701SerasaAcoesNatureza ;
      private bool[] BC002G11_n701SerasaAcoesNatureza ;
      private decimal[] BC002G11_A702SerasaAcoesValor ;
      private bool[] BC002G11_n702SerasaAcoesValor ;
      private string[] BC002G11_A703SerasaAcoesDistribuidor ;
      private bool[] BC002G11_n703SerasaAcoesDistribuidor ;
      private string[] BC002G11_A704SerasaAcoesVara ;
      private bool[] BC002G11_n704SerasaAcoesVara ;
      private string[] BC002G11_A705SerasaAcoesCidade ;
      private bool[] BC002G11_n705SerasaAcoesCidade ;
      private string[] BC002G11_A706SerasaAcoesUF ;
      private bool[] BC002G11_n706SerasaAcoesUF ;
      private string[] BC002G11_A707SerasaAcoesPrincipal ;
      private bool[] BC002G11_n707SerasaAcoesPrincipal ;
      private string[] BC002G11_A708SerasaAcoesTipoMoeda ;
      private bool[] BC002G11_n708SerasaAcoesTipoMoeda ;
      private short[] BC002G11_A709SerasaAcoesQtdOco ;
      private bool[] BC002G11_n709SerasaAcoesQtdOco ;
      private int[] BC002G11_A662SerasaId ;
      private bool[] BC002G11_n662SerasaId ;
      private SdtSerasaAcoes bcSerasaAcoes ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class serasaacoes_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC002G2;
          prmBC002G2 = new Object[] {
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmBC002G3;
          prmBC002G3 = new Object[] {
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmBC002G4;
          prmBC002G4 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002G5;
          prmBC002G5 = new Object[] {
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmBC002G6;
          prmBC002G6 = new Object[] {
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmBC002G7;
          prmBC002G7 = new Object[] {
          new ParDef("SerasaAcoesData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaAcoesNatureza",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaAcoesValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaAcoesDistribuidor",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaAcoesVara",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesCidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesPrincipal",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesTipoMoeda",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesQtdOco",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002G8;
          prmBC002G8 = new Object[] {
          };
          Object[] prmBC002G9;
          prmBC002G9 = new Object[] {
          new ParDef("SerasaAcoesData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaAcoesNatureza",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaAcoesValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaAcoesDistribuidor",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaAcoesVara",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesCidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesUF",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesPrincipal",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesTipoMoeda",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaAcoesQtdOco",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmBC002G10;
          prmBC002G10 = new Object[] {
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          Object[] prmBC002G11;
          prmBC002G11 = new Object[] {
          new ParDef("SerasaAcoesId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002G2", "SELECT SerasaAcoesId, SerasaAcoesData, SerasaAcoesNatureza, SerasaAcoesValor, SerasaAcoesDistribuidor, SerasaAcoesVara, SerasaAcoesCidade, SerasaAcoesUF, SerasaAcoesPrincipal, SerasaAcoesTipoMoeda, SerasaAcoesQtdOco, SerasaId FROM SerasaAcoes WHERE SerasaAcoesId = :SerasaAcoesId  FOR UPDATE OF SerasaAcoes",true, GxErrorMask.GX_NOMASK, false, this,prmBC002G2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002G3", "SELECT SerasaAcoesId, SerasaAcoesData, SerasaAcoesNatureza, SerasaAcoesValor, SerasaAcoesDistribuidor, SerasaAcoesVara, SerasaAcoesCidade, SerasaAcoesUF, SerasaAcoesPrincipal, SerasaAcoesTipoMoeda, SerasaAcoesQtdOco, SerasaId FROM SerasaAcoes WHERE SerasaAcoesId = :SerasaAcoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002G3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002G4", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002G4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002G5", "SELECT TM1.SerasaAcoesId, TM1.SerasaAcoesData, TM1.SerasaAcoesNatureza, TM1.SerasaAcoesValor, TM1.SerasaAcoesDistribuidor, TM1.SerasaAcoesVara, TM1.SerasaAcoesCidade, TM1.SerasaAcoesUF, TM1.SerasaAcoesPrincipal, TM1.SerasaAcoesTipoMoeda, TM1.SerasaAcoesQtdOco, TM1.SerasaId FROM SerasaAcoes TM1 WHERE TM1.SerasaAcoesId = :SerasaAcoesId ORDER BY TM1.SerasaAcoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002G5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002G6", "SELECT SerasaAcoesId FROM SerasaAcoes WHERE SerasaAcoesId = :SerasaAcoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002G6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002G7", "SAVEPOINT gxupdate;INSERT INTO SerasaAcoes(SerasaAcoesData, SerasaAcoesNatureza, SerasaAcoesValor, SerasaAcoesDistribuidor, SerasaAcoesVara, SerasaAcoesCidade, SerasaAcoesUF, SerasaAcoesPrincipal, SerasaAcoesTipoMoeda, SerasaAcoesQtdOco, SerasaId) VALUES(:SerasaAcoesData, :SerasaAcoesNatureza, :SerasaAcoesValor, :SerasaAcoesDistribuidor, :SerasaAcoesVara, :SerasaAcoesCidade, :SerasaAcoesUF, :SerasaAcoesPrincipal, :SerasaAcoesTipoMoeda, :SerasaAcoesQtdOco, :SerasaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002G7)
             ,new CursorDef("BC002G8", "SELECT currval('SerasaAcoesId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002G8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002G9", "SAVEPOINT gxupdate;UPDATE SerasaAcoes SET SerasaAcoesData=:SerasaAcoesData, SerasaAcoesNatureza=:SerasaAcoesNatureza, SerasaAcoesValor=:SerasaAcoesValor, SerasaAcoesDistribuidor=:SerasaAcoesDistribuidor, SerasaAcoesVara=:SerasaAcoesVara, SerasaAcoesCidade=:SerasaAcoesCidade, SerasaAcoesUF=:SerasaAcoesUF, SerasaAcoesPrincipal=:SerasaAcoesPrincipal, SerasaAcoesTipoMoeda=:SerasaAcoesTipoMoeda, SerasaAcoesQtdOco=:SerasaAcoesQtdOco, SerasaId=:SerasaId  WHERE SerasaAcoesId = :SerasaAcoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002G9)
             ,new CursorDef("BC002G10", "SAVEPOINT gxupdate;DELETE FROM SerasaAcoes  WHERE SerasaAcoesId = :SerasaAcoesId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002G10)
             ,new CursorDef("BC002G11", "SELECT TM1.SerasaAcoesId, TM1.SerasaAcoesData, TM1.SerasaAcoesNatureza, TM1.SerasaAcoesValor, TM1.SerasaAcoesDistribuidor, TM1.SerasaAcoesVara, TM1.SerasaAcoesCidade, TM1.SerasaAcoesUF, TM1.SerasaAcoesPrincipal, TM1.SerasaAcoesTipoMoeda, TM1.SerasaAcoesQtdOco, TM1.SerasaId FROM SerasaAcoes TM1 WHERE TM1.SerasaAcoesId = :SerasaAcoesId ORDER BY TM1.SerasaAcoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002G11,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
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
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
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
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getVarchar(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getVarchar(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                return;
       }
    }

 }

}
