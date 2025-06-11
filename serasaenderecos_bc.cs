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
   public class serasaenderecos_bc : GxSilentTrn, IGxSilentTrn
   {
      public serasaenderecos_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasaenderecos_bc( IGxContext context )
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
         ReadRow2I88( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2I88( ) ;
         standaloneModal( ) ;
         AddRow2I88( ) ;
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
            E112I2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z716SerasaEnderecosId = A716SerasaEnderecosId;
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

      protected void CONFIRM_2I0( )
      {
         BeforeValidate2I88( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2I88( ) ;
            }
            else
            {
               CheckExtendedTable2I88( ) ;
               if ( AnyError == 0 )
               {
                  ZM2I88( 4) ;
               }
               CloseExtendedTableCursors2I88( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122I2( )
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

      protected void E112I2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2I88( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z717SerasaEnderecosLogr = A717SerasaEnderecosLogr;
            Z718SerasaEnderecosNum = A718SerasaEnderecosNum;
            Z719SerasaEnderecosCompl = A719SerasaEnderecosCompl;
            Z720SerasaEnderecosBairro = A720SerasaEnderecosBairro;
            Z721SerasaEnderecosCidade = A721SerasaEnderecosCidade;
            Z722SerasaEnderecosEstado = A722SerasaEnderecosEstado;
            Z723SerasaEnderecosCEP = A723SerasaEnderecosCEP;
            Z724SerasaEnderecosTelDDD = A724SerasaEnderecosTelDDD;
            Z725SerasaEnderecosTel = A725SerasaEnderecosTel;
            Z662SerasaId = A662SerasaId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -3 )
         {
            Z716SerasaEnderecosId = A716SerasaEnderecosId;
            Z717SerasaEnderecosLogr = A717SerasaEnderecosLogr;
            Z718SerasaEnderecosNum = A718SerasaEnderecosNum;
            Z719SerasaEnderecosCompl = A719SerasaEnderecosCompl;
            Z720SerasaEnderecosBairro = A720SerasaEnderecosBairro;
            Z721SerasaEnderecosCidade = A721SerasaEnderecosCidade;
            Z722SerasaEnderecosEstado = A722SerasaEnderecosEstado;
            Z723SerasaEnderecosCEP = A723SerasaEnderecosCEP;
            Z724SerasaEnderecosTelDDD = A724SerasaEnderecosTelDDD;
            Z725SerasaEnderecosTel = A725SerasaEnderecosTel;
            Z662SerasaId = A662SerasaId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV19Pgmname = "SerasaEnderecos_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2I88( )
      {
         /* Using cursor BC002I5 */
         pr_default.execute(3, new Object[] {A716SerasaEnderecosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound88 = 1;
            A717SerasaEnderecosLogr = BC002I5_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = BC002I5_n717SerasaEnderecosLogr[0];
            A718SerasaEnderecosNum = BC002I5_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = BC002I5_n718SerasaEnderecosNum[0];
            A719SerasaEnderecosCompl = BC002I5_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = BC002I5_n719SerasaEnderecosCompl[0];
            A720SerasaEnderecosBairro = BC002I5_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = BC002I5_n720SerasaEnderecosBairro[0];
            A721SerasaEnderecosCidade = BC002I5_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = BC002I5_n721SerasaEnderecosCidade[0];
            A722SerasaEnderecosEstado = BC002I5_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = BC002I5_n722SerasaEnderecosEstado[0];
            A723SerasaEnderecosCEP = BC002I5_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = BC002I5_n723SerasaEnderecosCEP[0];
            A724SerasaEnderecosTelDDD = BC002I5_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = BC002I5_n724SerasaEnderecosTelDDD[0];
            A725SerasaEnderecosTel = BC002I5_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = BC002I5_n725SerasaEnderecosTel[0];
            A662SerasaId = BC002I5_A662SerasaId[0];
            n662SerasaId = BC002I5_n662SerasaId[0];
            ZM2I88( -3) ;
         }
         pr_default.close(3);
         OnLoadActions2I88( ) ;
      }

      protected void OnLoadActions2I88( )
      {
      }

      protected void CheckExtendedTable2I88( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002I4 */
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
      }

      protected void CloseExtendedTableCursors2I88( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2I88( )
      {
         /* Using cursor BC002I6 */
         pr_default.execute(4, new Object[] {A716SerasaEnderecosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound88 = 1;
         }
         else
         {
            RcdFound88 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002I3 */
         pr_default.execute(1, new Object[] {A716SerasaEnderecosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2I88( 3) ;
            RcdFound88 = 1;
            A716SerasaEnderecosId = BC002I3_A716SerasaEnderecosId[0];
            A717SerasaEnderecosLogr = BC002I3_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = BC002I3_n717SerasaEnderecosLogr[0];
            A718SerasaEnderecosNum = BC002I3_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = BC002I3_n718SerasaEnderecosNum[0];
            A719SerasaEnderecosCompl = BC002I3_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = BC002I3_n719SerasaEnderecosCompl[0];
            A720SerasaEnderecosBairro = BC002I3_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = BC002I3_n720SerasaEnderecosBairro[0];
            A721SerasaEnderecosCidade = BC002I3_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = BC002I3_n721SerasaEnderecosCidade[0];
            A722SerasaEnderecosEstado = BC002I3_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = BC002I3_n722SerasaEnderecosEstado[0];
            A723SerasaEnderecosCEP = BC002I3_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = BC002I3_n723SerasaEnderecosCEP[0];
            A724SerasaEnderecosTelDDD = BC002I3_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = BC002I3_n724SerasaEnderecosTelDDD[0];
            A725SerasaEnderecosTel = BC002I3_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = BC002I3_n725SerasaEnderecosTel[0];
            A662SerasaId = BC002I3_A662SerasaId[0];
            n662SerasaId = BC002I3_n662SerasaId[0];
            Z716SerasaEnderecosId = A716SerasaEnderecosId;
            sMode88 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2I88( ) ;
            if ( AnyError == 1 )
            {
               RcdFound88 = 0;
               InitializeNonKey2I88( ) ;
            }
            Gx_mode = sMode88;
         }
         else
         {
            RcdFound88 = 0;
            InitializeNonKey2I88( ) ;
            sMode88 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode88;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2I88( ) ;
         if ( RcdFound88 == 0 )
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
         CONFIRM_2I0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2I88( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002I2 */
            pr_default.execute(0, new Object[] {A716SerasaEnderecosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaEnderecos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z717SerasaEnderecosLogr, BC002I2_A717SerasaEnderecosLogr[0]) != 0 ) || ( StringUtil.StrCmp(Z718SerasaEnderecosNum, BC002I2_A718SerasaEnderecosNum[0]) != 0 ) || ( StringUtil.StrCmp(Z719SerasaEnderecosCompl, BC002I2_A719SerasaEnderecosCompl[0]) != 0 ) || ( StringUtil.StrCmp(Z720SerasaEnderecosBairro, BC002I2_A720SerasaEnderecosBairro[0]) != 0 ) || ( StringUtil.StrCmp(Z721SerasaEnderecosCidade, BC002I2_A721SerasaEnderecosCidade[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z722SerasaEnderecosEstado, BC002I2_A722SerasaEnderecosEstado[0]) != 0 ) || ( StringUtil.StrCmp(Z723SerasaEnderecosCEP, BC002I2_A723SerasaEnderecosCEP[0]) != 0 ) || ( StringUtil.StrCmp(Z724SerasaEnderecosTelDDD, BC002I2_A724SerasaEnderecosTelDDD[0]) != 0 ) || ( StringUtil.StrCmp(Z725SerasaEnderecosTel, BC002I2_A725SerasaEnderecosTel[0]) != 0 ) || ( Z662SerasaId != BC002I2_A662SerasaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SerasaEnderecos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2I88( )
      {
         BeforeValidate2I88( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2I88( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2I88( 0) ;
            CheckOptimisticConcurrency2I88( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2I88( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2I88( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002I7 */
                     pr_default.execute(5, new Object[] {n717SerasaEnderecosLogr, A717SerasaEnderecosLogr, n718SerasaEnderecosNum, A718SerasaEnderecosNum, n719SerasaEnderecosCompl, A719SerasaEnderecosCompl, n720SerasaEnderecosBairro, A720SerasaEnderecosBairro, n721SerasaEnderecosCidade, A721SerasaEnderecosCidade, n722SerasaEnderecosEstado, A722SerasaEnderecosEstado, n723SerasaEnderecosCEP, A723SerasaEnderecosCEP, n724SerasaEnderecosTelDDD, A724SerasaEnderecosTelDDD, n725SerasaEnderecosTel, A725SerasaEnderecosTel, n662SerasaId, A662SerasaId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002I8 */
                     pr_default.execute(6);
                     A716SerasaEnderecosId = BC002I8_A716SerasaEnderecosId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaEnderecos");
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
               Load2I88( ) ;
            }
            EndLevel2I88( ) ;
         }
         CloseExtendedTableCursors2I88( ) ;
      }

      protected void Update2I88( )
      {
         BeforeValidate2I88( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2I88( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2I88( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2I88( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2I88( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002I9 */
                     pr_default.execute(7, new Object[] {n717SerasaEnderecosLogr, A717SerasaEnderecosLogr, n718SerasaEnderecosNum, A718SerasaEnderecosNum, n719SerasaEnderecosCompl, A719SerasaEnderecosCompl, n720SerasaEnderecosBairro, A720SerasaEnderecosBairro, n721SerasaEnderecosCidade, A721SerasaEnderecosCidade, n722SerasaEnderecosEstado, A722SerasaEnderecosEstado, n723SerasaEnderecosCEP, A723SerasaEnderecosCEP, n724SerasaEnderecosTelDDD, A724SerasaEnderecosTelDDD, n725SerasaEnderecosTel, A725SerasaEnderecosTel, n662SerasaId, A662SerasaId, A716SerasaEnderecosId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaEnderecos");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaEnderecos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2I88( ) ;
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
            EndLevel2I88( ) ;
         }
         CloseExtendedTableCursors2I88( ) ;
      }

      protected void DeferredUpdate2I88( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2I88( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2I88( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2I88( ) ;
            AfterConfirm2I88( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2I88( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002I10 */
                  pr_default.execute(8, new Object[] {A716SerasaEnderecosId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("SerasaEnderecos");
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
         sMode88 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2I88( ) ;
         Gx_mode = sMode88;
      }

      protected void OnDeleteControls2I88( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2I88( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2I88( ) ;
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

      public void ScanKeyStart2I88( )
      {
         /* Scan By routine */
         /* Using cursor BC002I11 */
         pr_default.execute(9, new Object[] {A716SerasaEnderecosId});
         RcdFound88 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound88 = 1;
            A716SerasaEnderecosId = BC002I11_A716SerasaEnderecosId[0];
            A717SerasaEnderecosLogr = BC002I11_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = BC002I11_n717SerasaEnderecosLogr[0];
            A718SerasaEnderecosNum = BC002I11_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = BC002I11_n718SerasaEnderecosNum[0];
            A719SerasaEnderecosCompl = BC002I11_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = BC002I11_n719SerasaEnderecosCompl[0];
            A720SerasaEnderecosBairro = BC002I11_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = BC002I11_n720SerasaEnderecosBairro[0];
            A721SerasaEnderecosCidade = BC002I11_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = BC002I11_n721SerasaEnderecosCidade[0];
            A722SerasaEnderecosEstado = BC002I11_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = BC002I11_n722SerasaEnderecosEstado[0];
            A723SerasaEnderecosCEP = BC002I11_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = BC002I11_n723SerasaEnderecosCEP[0];
            A724SerasaEnderecosTelDDD = BC002I11_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = BC002I11_n724SerasaEnderecosTelDDD[0];
            A725SerasaEnderecosTel = BC002I11_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = BC002I11_n725SerasaEnderecosTel[0];
            A662SerasaId = BC002I11_A662SerasaId[0];
            n662SerasaId = BC002I11_n662SerasaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2I88( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound88 = 0;
         ScanKeyLoad2I88( ) ;
      }

      protected void ScanKeyLoad2I88( )
      {
         sMode88 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound88 = 1;
            A716SerasaEnderecosId = BC002I11_A716SerasaEnderecosId[0];
            A717SerasaEnderecosLogr = BC002I11_A717SerasaEnderecosLogr[0];
            n717SerasaEnderecosLogr = BC002I11_n717SerasaEnderecosLogr[0];
            A718SerasaEnderecosNum = BC002I11_A718SerasaEnderecosNum[0];
            n718SerasaEnderecosNum = BC002I11_n718SerasaEnderecosNum[0];
            A719SerasaEnderecosCompl = BC002I11_A719SerasaEnderecosCompl[0];
            n719SerasaEnderecosCompl = BC002I11_n719SerasaEnderecosCompl[0];
            A720SerasaEnderecosBairro = BC002I11_A720SerasaEnderecosBairro[0];
            n720SerasaEnderecosBairro = BC002I11_n720SerasaEnderecosBairro[0];
            A721SerasaEnderecosCidade = BC002I11_A721SerasaEnderecosCidade[0];
            n721SerasaEnderecosCidade = BC002I11_n721SerasaEnderecosCidade[0];
            A722SerasaEnderecosEstado = BC002I11_A722SerasaEnderecosEstado[0];
            n722SerasaEnderecosEstado = BC002I11_n722SerasaEnderecosEstado[0];
            A723SerasaEnderecosCEP = BC002I11_A723SerasaEnderecosCEP[0];
            n723SerasaEnderecosCEP = BC002I11_n723SerasaEnderecosCEP[0];
            A724SerasaEnderecosTelDDD = BC002I11_A724SerasaEnderecosTelDDD[0];
            n724SerasaEnderecosTelDDD = BC002I11_n724SerasaEnderecosTelDDD[0];
            A725SerasaEnderecosTel = BC002I11_A725SerasaEnderecosTel[0];
            n725SerasaEnderecosTel = BC002I11_n725SerasaEnderecosTel[0];
            A662SerasaId = BC002I11_A662SerasaId[0];
            n662SerasaId = BC002I11_n662SerasaId[0];
         }
         Gx_mode = sMode88;
      }

      protected void ScanKeyEnd2I88( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm2I88( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2I88( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2I88( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2I88( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2I88( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2I88( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2I88( )
      {
      }

      protected void send_integrity_lvl_hashes2I88( )
      {
      }

      protected void AddRow2I88( )
      {
         VarsToRow88( bcSerasaEnderecos) ;
      }

      protected void ReadRow2I88( )
      {
         RowToVars88( bcSerasaEnderecos, 1) ;
      }

      protected void InitializeNonKey2I88( )
      {
         A662SerasaId = 0;
         n662SerasaId = false;
         A717SerasaEnderecosLogr = "";
         n717SerasaEnderecosLogr = false;
         A718SerasaEnderecosNum = "";
         n718SerasaEnderecosNum = false;
         A719SerasaEnderecosCompl = "";
         n719SerasaEnderecosCompl = false;
         A720SerasaEnderecosBairro = "";
         n720SerasaEnderecosBairro = false;
         A721SerasaEnderecosCidade = "";
         n721SerasaEnderecosCidade = false;
         A722SerasaEnderecosEstado = "";
         n722SerasaEnderecosEstado = false;
         A723SerasaEnderecosCEP = "";
         n723SerasaEnderecosCEP = false;
         A724SerasaEnderecosTelDDD = "";
         n724SerasaEnderecosTelDDD = false;
         A725SerasaEnderecosTel = "";
         n725SerasaEnderecosTel = false;
         Z717SerasaEnderecosLogr = "";
         Z718SerasaEnderecosNum = "";
         Z719SerasaEnderecosCompl = "";
         Z720SerasaEnderecosBairro = "";
         Z721SerasaEnderecosCidade = "";
         Z722SerasaEnderecosEstado = "";
         Z723SerasaEnderecosCEP = "";
         Z724SerasaEnderecosTelDDD = "";
         Z725SerasaEnderecosTel = "";
         Z662SerasaId = 0;
      }

      protected void InitAll2I88( )
      {
         A716SerasaEnderecosId = 0;
         InitializeNonKey2I88( ) ;
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

      public void VarsToRow88( SdtSerasaEnderecos obj88 )
      {
         obj88.gxTpr_Mode = Gx_mode;
         obj88.gxTpr_Serasaid = A662SerasaId;
         obj88.gxTpr_Serasaenderecoslogr = A717SerasaEnderecosLogr;
         obj88.gxTpr_Serasaenderecosnum = A718SerasaEnderecosNum;
         obj88.gxTpr_Serasaenderecoscompl = A719SerasaEnderecosCompl;
         obj88.gxTpr_Serasaenderecosbairro = A720SerasaEnderecosBairro;
         obj88.gxTpr_Serasaenderecoscidade = A721SerasaEnderecosCidade;
         obj88.gxTpr_Serasaenderecosestado = A722SerasaEnderecosEstado;
         obj88.gxTpr_Serasaenderecoscep = A723SerasaEnderecosCEP;
         obj88.gxTpr_Serasaenderecostelddd = A724SerasaEnderecosTelDDD;
         obj88.gxTpr_Serasaenderecostel = A725SerasaEnderecosTel;
         obj88.gxTpr_Serasaenderecosid = A716SerasaEnderecosId;
         obj88.gxTpr_Serasaenderecosid_Z = Z716SerasaEnderecosId;
         obj88.gxTpr_Serasaid_Z = Z662SerasaId;
         obj88.gxTpr_Serasaenderecoslogr_Z = Z717SerasaEnderecosLogr;
         obj88.gxTpr_Serasaenderecosnum_Z = Z718SerasaEnderecosNum;
         obj88.gxTpr_Serasaenderecoscompl_Z = Z719SerasaEnderecosCompl;
         obj88.gxTpr_Serasaenderecosbairro_Z = Z720SerasaEnderecosBairro;
         obj88.gxTpr_Serasaenderecoscidade_Z = Z721SerasaEnderecosCidade;
         obj88.gxTpr_Serasaenderecosestado_Z = Z722SerasaEnderecosEstado;
         obj88.gxTpr_Serasaenderecoscep_Z = Z723SerasaEnderecosCEP;
         obj88.gxTpr_Serasaenderecostelddd_Z = Z724SerasaEnderecosTelDDD;
         obj88.gxTpr_Serasaenderecostel_Z = Z725SerasaEnderecosTel;
         obj88.gxTpr_Serasaid_N = (short)(Convert.ToInt16(n662SerasaId));
         obj88.gxTpr_Serasaenderecoslogr_N = (short)(Convert.ToInt16(n717SerasaEnderecosLogr));
         obj88.gxTpr_Serasaenderecosnum_N = (short)(Convert.ToInt16(n718SerasaEnderecosNum));
         obj88.gxTpr_Serasaenderecoscompl_N = (short)(Convert.ToInt16(n719SerasaEnderecosCompl));
         obj88.gxTpr_Serasaenderecosbairro_N = (short)(Convert.ToInt16(n720SerasaEnderecosBairro));
         obj88.gxTpr_Serasaenderecoscidade_N = (short)(Convert.ToInt16(n721SerasaEnderecosCidade));
         obj88.gxTpr_Serasaenderecosestado_N = (short)(Convert.ToInt16(n722SerasaEnderecosEstado));
         obj88.gxTpr_Serasaenderecoscep_N = (short)(Convert.ToInt16(n723SerasaEnderecosCEP));
         obj88.gxTpr_Serasaenderecostelddd_N = (short)(Convert.ToInt16(n724SerasaEnderecosTelDDD));
         obj88.gxTpr_Serasaenderecostel_N = (short)(Convert.ToInt16(n725SerasaEnderecosTel));
         obj88.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow88( SdtSerasaEnderecos obj88 )
      {
         obj88.gxTpr_Serasaenderecosid = A716SerasaEnderecosId;
         return  ;
      }

      public void RowToVars88( SdtSerasaEnderecos obj88 ,
                               int forceLoad )
      {
         Gx_mode = obj88.gxTpr_Mode;
         A662SerasaId = obj88.gxTpr_Serasaid;
         n662SerasaId = false;
         A717SerasaEnderecosLogr = obj88.gxTpr_Serasaenderecoslogr;
         n717SerasaEnderecosLogr = false;
         A718SerasaEnderecosNum = obj88.gxTpr_Serasaenderecosnum;
         n718SerasaEnderecosNum = false;
         A719SerasaEnderecosCompl = obj88.gxTpr_Serasaenderecoscompl;
         n719SerasaEnderecosCompl = false;
         A720SerasaEnderecosBairro = obj88.gxTpr_Serasaenderecosbairro;
         n720SerasaEnderecosBairro = false;
         A721SerasaEnderecosCidade = obj88.gxTpr_Serasaenderecoscidade;
         n721SerasaEnderecosCidade = false;
         A722SerasaEnderecosEstado = obj88.gxTpr_Serasaenderecosestado;
         n722SerasaEnderecosEstado = false;
         A723SerasaEnderecosCEP = obj88.gxTpr_Serasaenderecoscep;
         n723SerasaEnderecosCEP = false;
         A724SerasaEnderecosTelDDD = obj88.gxTpr_Serasaenderecostelddd;
         n724SerasaEnderecosTelDDD = false;
         A725SerasaEnderecosTel = obj88.gxTpr_Serasaenderecostel;
         n725SerasaEnderecosTel = false;
         A716SerasaEnderecosId = obj88.gxTpr_Serasaenderecosid;
         Z716SerasaEnderecosId = obj88.gxTpr_Serasaenderecosid_Z;
         Z662SerasaId = obj88.gxTpr_Serasaid_Z;
         Z717SerasaEnderecosLogr = obj88.gxTpr_Serasaenderecoslogr_Z;
         Z718SerasaEnderecosNum = obj88.gxTpr_Serasaenderecosnum_Z;
         Z719SerasaEnderecosCompl = obj88.gxTpr_Serasaenderecoscompl_Z;
         Z720SerasaEnderecosBairro = obj88.gxTpr_Serasaenderecosbairro_Z;
         Z721SerasaEnderecosCidade = obj88.gxTpr_Serasaenderecoscidade_Z;
         Z722SerasaEnderecosEstado = obj88.gxTpr_Serasaenderecosestado_Z;
         Z723SerasaEnderecosCEP = obj88.gxTpr_Serasaenderecoscep_Z;
         Z724SerasaEnderecosTelDDD = obj88.gxTpr_Serasaenderecostelddd_Z;
         Z725SerasaEnderecosTel = obj88.gxTpr_Serasaenderecostel_Z;
         n662SerasaId = (bool)(Convert.ToBoolean(obj88.gxTpr_Serasaid_N));
         n717SerasaEnderecosLogr = (bool)(Convert.ToBoolean(obj88.gxTpr_Serasaenderecoslogr_N));
         n718SerasaEnderecosNum = (bool)(Convert.ToBoolean(obj88.gxTpr_Serasaenderecosnum_N));
         n719SerasaEnderecosCompl = (bool)(Convert.ToBoolean(obj88.gxTpr_Serasaenderecoscompl_N));
         n720SerasaEnderecosBairro = (bool)(Convert.ToBoolean(obj88.gxTpr_Serasaenderecosbairro_N));
         n721SerasaEnderecosCidade = (bool)(Convert.ToBoolean(obj88.gxTpr_Serasaenderecoscidade_N));
         n722SerasaEnderecosEstado = (bool)(Convert.ToBoolean(obj88.gxTpr_Serasaenderecosestado_N));
         n723SerasaEnderecosCEP = (bool)(Convert.ToBoolean(obj88.gxTpr_Serasaenderecoscep_N));
         n724SerasaEnderecosTelDDD = (bool)(Convert.ToBoolean(obj88.gxTpr_Serasaenderecostelddd_N));
         n725SerasaEnderecosTel = (bool)(Convert.ToBoolean(obj88.gxTpr_Serasaenderecostel_N));
         Gx_mode = obj88.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A716SerasaEnderecosId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2I88( ) ;
         ScanKeyStart2I88( ) ;
         if ( RcdFound88 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z716SerasaEnderecosId = A716SerasaEnderecosId;
         }
         ZM2I88( -3) ;
         OnLoadActions2I88( ) ;
         AddRow2I88( ) ;
         ScanKeyEnd2I88( ) ;
         if ( RcdFound88 == 0 )
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
         RowToVars88( bcSerasaEnderecos, 0) ;
         ScanKeyStart2I88( ) ;
         if ( RcdFound88 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z716SerasaEnderecosId = A716SerasaEnderecosId;
         }
         ZM2I88( -3) ;
         OnLoadActions2I88( ) ;
         AddRow2I88( ) ;
         ScanKeyEnd2I88( ) ;
         if ( RcdFound88 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2I88( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2I88( ) ;
         }
         else
         {
            if ( RcdFound88 == 1 )
            {
               if ( A716SerasaEnderecosId != Z716SerasaEnderecosId )
               {
                  A716SerasaEnderecosId = Z716SerasaEnderecosId;
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
                  Update2I88( ) ;
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
                  if ( A716SerasaEnderecosId != Z716SerasaEnderecosId )
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
                        Insert2I88( ) ;
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
                        Insert2I88( ) ;
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
         RowToVars88( bcSerasaEnderecos, 1) ;
         SaveImpl( ) ;
         VarsToRow88( bcSerasaEnderecos) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars88( bcSerasaEnderecos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2I88( ) ;
         AfterTrn( ) ;
         VarsToRow88( bcSerasaEnderecos) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow88( bcSerasaEnderecos) ;
         }
         else
         {
            SdtSerasaEnderecos auxBC = new SdtSerasaEnderecos(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A716SerasaEnderecosId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSerasaEnderecos);
               auxBC.Save();
               bcSerasaEnderecos.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars88( bcSerasaEnderecos, 1) ;
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
         RowToVars88( bcSerasaEnderecos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2I88( ) ;
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
               VarsToRow88( bcSerasaEnderecos) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow88( bcSerasaEnderecos) ;
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
         RowToVars88( bcSerasaEnderecos, 0) ;
         GetKey2I88( ) ;
         if ( RcdFound88 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A716SerasaEnderecosId != Z716SerasaEnderecosId )
            {
               A716SerasaEnderecosId = Z716SerasaEnderecosId;
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
            if ( A716SerasaEnderecosId != Z716SerasaEnderecosId )
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
         context.RollbackDataStores("serasaenderecos_bc",pr_default);
         VarsToRow88( bcSerasaEnderecos) ;
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
         Gx_mode = bcSerasaEnderecos.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSerasaEnderecos.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSerasaEnderecos )
         {
            bcSerasaEnderecos = (SdtSerasaEnderecos)(sdt);
            if ( StringUtil.StrCmp(bcSerasaEnderecos.gxTpr_Mode, "") == 0 )
            {
               bcSerasaEnderecos.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow88( bcSerasaEnderecos) ;
            }
            else
            {
               RowToVars88( bcSerasaEnderecos, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSerasaEnderecos.gxTpr_Mode, "") == 0 )
            {
               bcSerasaEnderecos.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars88( bcSerasaEnderecos, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSerasaEnderecos SerasaEnderecos_BC
      {
         get {
            return bcSerasaEnderecos ;
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
         Z717SerasaEnderecosLogr = "";
         A717SerasaEnderecosLogr = "";
         Z718SerasaEnderecosNum = "";
         A718SerasaEnderecosNum = "";
         Z719SerasaEnderecosCompl = "";
         A719SerasaEnderecosCompl = "";
         Z720SerasaEnderecosBairro = "";
         A720SerasaEnderecosBairro = "";
         Z721SerasaEnderecosCidade = "";
         A721SerasaEnderecosCidade = "";
         Z722SerasaEnderecosEstado = "";
         A722SerasaEnderecosEstado = "";
         Z723SerasaEnderecosCEP = "";
         A723SerasaEnderecosCEP = "";
         Z724SerasaEnderecosTelDDD = "";
         A724SerasaEnderecosTelDDD = "";
         Z725SerasaEnderecosTel = "";
         A725SerasaEnderecosTel = "";
         BC002I5_A716SerasaEnderecosId = new int[1] ;
         BC002I5_A717SerasaEnderecosLogr = new string[] {""} ;
         BC002I5_n717SerasaEnderecosLogr = new bool[] {false} ;
         BC002I5_A718SerasaEnderecosNum = new string[] {""} ;
         BC002I5_n718SerasaEnderecosNum = new bool[] {false} ;
         BC002I5_A719SerasaEnderecosCompl = new string[] {""} ;
         BC002I5_n719SerasaEnderecosCompl = new bool[] {false} ;
         BC002I5_A720SerasaEnderecosBairro = new string[] {""} ;
         BC002I5_n720SerasaEnderecosBairro = new bool[] {false} ;
         BC002I5_A721SerasaEnderecosCidade = new string[] {""} ;
         BC002I5_n721SerasaEnderecosCidade = new bool[] {false} ;
         BC002I5_A722SerasaEnderecosEstado = new string[] {""} ;
         BC002I5_n722SerasaEnderecosEstado = new bool[] {false} ;
         BC002I5_A723SerasaEnderecosCEP = new string[] {""} ;
         BC002I5_n723SerasaEnderecosCEP = new bool[] {false} ;
         BC002I5_A724SerasaEnderecosTelDDD = new string[] {""} ;
         BC002I5_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         BC002I5_A725SerasaEnderecosTel = new string[] {""} ;
         BC002I5_n725SerasaEnderecosTel = new bool[] {false} ;
         BC002I5_A662SerasaId = new int[1] ;
         BC002I5_n662SerasaId = new bool[] {false} ;
         BC002I4_A662SerasaId = new int[1] ;
         BC002I4_n662SerasaId = new bool[] {false} ;
         BC002I6_A716SerasaEnderecosId = new int[1] ;
         BC002I3_A716SerasaEnderecosId = new int[1] ;
         BC002I3_A717SerasaEnderecosLogr = new string[] {""} ;
         BC002I3_n717SerasaEnderecosLogr = new bool[] {false} ;
         BC002I3_A718SerasaEnderecosNum = new string[] {""} ;
         BC002I3_n718SerasaEnderecosNum = new bool[] {false} ;
         BC002I3_A719SerasaEnderecosCompl = new string[] {""} ;
         BC002I3_n719SerasaEnderecosCompl = new bool[] {false} ;
         BC002I3_A720SerasaEnderecosBairro = new string[] {""} ;
         BC002I3_n720SerasaEnderecosBairro = new bool[] {false} ;
         BC002I3_A721SerasaEnderecosCidade = new string[] {""} ;
         BC002I3_n721SerasaEnderecosCidade = new bool[] {false} ;
         BC002I3_A722SerasaEnderecosEstado = new string[] {""} ;
         BC002I3_n722SerasaEnderecosEstado = new bool[] {false} ;
         BC002I3_A723SerasaEnderecosCEP = new string[] {""} ;
         BC002I3_n723SerasaEnderecosCEP = new bool[] {false} ;
         BC002I3_A724SerasaEnderecosTelDDD = new string[] {""} ;
         BC002I3_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         BC002I3_A725SerasaEnderecosTel = new string[] {""} ;
         BC002I3_n725SerasaEnderecosTel = new bool[] {false} ;
         BC002I3_A662SerasaId = new int[1] ;
         BC002I3_n662SerasaId = new bool[] {false} ;
         sMode88 = "";
         BC002I2_A716SerasaEnderecosId = new int[1] ;
         BC002I2_A717SerasaEnderecosLogr = new string[] {""} ;
         BC002I2_n717SerasaEnderecosLogr = new bool[] {false} ;
         BC002I2_A718SerasaEnderecosNum = new string[] {""} ;
         BC002I2_n718SerasaEnderecosNum = new bool[] {false} ;
         BC002I2_A719SerasaEnderecosCompl = new string[] {""} ;
         BC002I2_n719SerasaEnderecosCompl = new bool[] {false} ;
         BC002I2_A720SerasaEnderecosBairro = new string[] {""} ;
         BC002I2_n720SerasaEnderecosBairro = new bool[] {false} ;
         BC002I2_A721SerasaEnderecosCidade = new string[] {""} ;
         BC002I2_n721SerasaEnderecosCidade = new bool[] {false} ;
         BC002I2_A722SerasaEnderecosEstado = new string[] {""} ;
         BC002I2_n722SerasaEnderecosEstado = new bool[] {false} ;
         BC002I2_A723SerasaEnderecosCEP = new string[] {""} ;
         BC002I2_n723SerasaEnderecosCEP = new bool[] {false} ;
         BC002I2_A724SerasaEnderecosTelDDD = new string[] {""} ;
         BC002I2_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         BC002I2_A725SerasaEnderecosTel = new string[] {""} ;
         BC002I2_n725SerasaEnderecosTel = new bool[] {false} ;
         BC002I2_A662SerasaId = new int[1] ;
         BC002I2_n662SerasaId = new bool[] {false} ;
         BC002I8_A716SerasaEnderecosId = new int[1] ;
         BC002I11_A716SerasaEnderecosId = new int[1] ;
         BC002I11_A717SerasaEnderecosLogr = new string[] {""} ;
         BC002I11_n717SerasaEnderecosLogr = new bool[] {false} ;
         BC002I11_A718SerasaEnderecosNum = new string[] {""} ;
         BC002I11_n718SerasaEnderecosNum = new bool[] {false} ;
         BC002I11_A719SerasaEnderecosCompl = new string[] {""} ;
         BC002I11_n719SerasaEnderecosCompl = new bool[] {false} ;
         BC002I11_A720SerasaEnderecosBairro = new string[] {""} ;
         BC002I11_n720SerasaEnderecosBairro = new bool[] {false} ;
         BC002I11_A721SerasaEnderecosCidade = new string[] {""} ;
         BC002I11_n721SerasaEnderecosCidade = new bool[] {false} ;
         BC002I11_A722SerasaEnderecosEstado = new string[] {""} ;
         BC002I11_n722SerasaEnderecosEstado = new bool[] {false} ;
         BC002I11_A723SerasaEnderecosCEP = new string[] {""} ;
         BC002I11_n723SerasaEnderecosCEP = new bool[] {false} ;
         BC002I11_A724SerasaEnderecosTelDDD = new string[] {""} ;
         BC002I11_n724SerasaEnderecosTelDDD = new bool[] {false} ;
         BC002I11_A725SerasaEnderecosTel = new string[] {""} ;
         BC002I11_n725SerasaEnderecosTel = new bool[] {false} ;
         BC002I11_A662SerasaId = new int[1] ;
         BC002I11_n662SerasaId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaenderecos_bc__default(),
            new Object[][] {
                new Object[] {
               BC002I2_A716SerasaEnderecosId, BC002I2_A717SerasaEnderecosLogr, BC002I2_n717SerasaEnderecosLogr, BC002I2_A718SerasaEnderecosNum, BC002I2_n718SerasaEnderecosNum, BC002I2_A719SerasaEnderecosCompl, BC002I2_n719SerasaEnderecosCompl, BC002I2_A720SerasaEnderecosBairro, BC002I2_n720SerasaEnderecosBairro, BC002I2_A721SerasaEnderecosCidade,
               BC002I2_n721SerasaEnderecosCidade, BC002I2_A722SerasaEnderecosEstado, BC002I2_n722SerasaEnderecosEstado, BC002I2_A723SerasaEnderecosCEP, BC002I2_n723SerasaEnderecosCEP, BC002I2_A724SerasaEnderecosTelDDD, BC002I2_n724SerasaEnderecosTelDDD, BC002I2_A725SerasaEnderecosTel, BC002I2_n725SerasaEnderecosTel, BC002I2_A662SerasaId,
               BC002I2_n662SerasaId
               }
               , new Object[] {
               BC002I3_A716SerasaEnderecosId, BC002I3_A717SerasaEnderecosLogr, BC002I3_n717SerasaEnderecosLogr, BC002I3_A718SerasaEnderecosNum, BC002I3_n718SerasaEnderecosNum, BC002I3_A719SerasaEnderecosCompl, BC002I3_n719SerasaEnderecosCompl, BC002I3_A720SerasaEnderecosBairro, BC002I3_n720SerasaEnderecosBairro, BC002I3_A721SerasaEnderecosCidade,
               BC002I3_n721SerasaEnderecosCidade, BC002I3_A722SerasaEnderecosEstado, BC002I3_n722SerasaEnderecosEstado, BC002I3_A723SerasaEnderecosCEP, BC002I3_n723SerasaEnderecosCEP, BC002I3_A724SerasaEnderecosTelDDD, BC002I3_n724SerasaEnderecosTelDDD, BC002I3_A725SerasaEnderecosTel, BC002I3_n725SerasaEnderecosTel, BC002I3_A662SerasaId,
               BC002I3_n662SerasaId
               }
               , new Object[] {
               BC002I4_A662SerasaId
               }
               , new Object[] {
               BC002I5_A716SerasaEnderecosId, BC002I5_A717SerasaEnderecosLogr, BC002I5_n717SerasaEnderecosLogr, BC002I5_A718SerasaEnderecosNum, BC002I5_n718SerasaEnderecosNum, BC002I5_A719SerasaEnderecosCompl, BC002I5_n719SerasaEnderecosCompl, BC002I5_A720SerasaEnderecosBairro, BC002I5_n720SerasaEnderecosBairro, BC002I5_A721SerasaEnderecosCidade,
               BC002I5_n721SerasaEnderecosCidade, BC002I5_A722SerasaEnderecosEstado, BC002I5_n722SerasaEnderecosEstado, BC002I5_A723SerasaEnderecosCEP, BC002I5_n723SerasaEnderecosCEP, BC002I5_A724SerasaEnderecosTelDDD, BC002I5_n724SerasaEnderecosTelDDD, BC002I5_A725SerasaEnderecosTel, BC002I5_n725SerasaEnderecosTel, BC002I5_A662SerasaId,
               BC002I5_n662SerasaId
               }
               , new Object[] {
               BC002I6_A716SerasaEnderecosId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002I8_A716SerasaEnderecosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002I11_A716SerasaEnderecosId, BC002I11_A717SerasaEnderecosLogr, BC002I11_n717SerasaEnderecosLogr, BC002I11_A718SerasaEnderecosNum, BC002I11_n718SerasaEnderecosNum, BC002I11_A719SerasaEnderecosCompl, BC002I11_n719SerasaEnderecosCompl, BC002I11_A720SerasaEnderecosBairro, BC002I11_n720SerasaEnderecosBairro, BC002I11_A721SerasaEnderecosCidade,
               BC002I11_n721SerasaEnderecosCidade, BC002I11_A722SerasaEnderecosEstado, BC002I11_n722SerasaEnderecosEstado, BC002I11_A723SerasaEnderecosCEP, BC002I11_n723SerasaEnderecosCEP, BC002I11_A724SerasaEnderecosTelDDD, BC002I11_n724SerasaEnderecosTelDDD, BC002I11_A725SerasaEnderecosTel, BC002I11_n725SerasaEnderecosTel, BC002I11_A662SerasaId,
               BC002I11_n662SerasaId
               }
            }
         );
         AV19Pgmname = "SerasaEnderecos_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122I2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound88 ;
      private int trnEnded ;
      private int Z716SerasaEnderecosId ;
      private int A716SerasaEnderecosId ;
      private int AV20GXV1 ;
      private int AV11Insert_SerasaId ;
      private int Z662SerasaId ;
      private int A662SerasaId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV19Pgmname ;
      private string sMode88 ;
      private bool returnInSub ;
      private bool n717SerasaEnderecosLogr ;
      private bool n718SerasaEnderecosNum ;
      private bool n719SerasaEnderecosCompl ;
      private bool n720SerasaEnderecosBairro ;
      private bool n721SerasaEnderecosCidade ;
      private bool n722SerasaEnderecosEstado ;
      private bool n723SerasaEnderecosCEP ;
      private bool n724SerasaEnderecosTelDDD ;
      private bool n725SerasaEnderecosTel ;
      private bool n662SerasaId ;
      private bool Gx_longc ;
      private string Z717SerasaEnderecosLogr ;
      private string A717SerasaEnderecosLogr ;
      private string Z718SerasaEnderecosNum ;
      private string A718SerasaEnderecosNum ;
      private string Z719SerasaEnderecosCompl ;
      private string A719SerasaEnderecosCompl ;
      private string Z720SerasaEnderecosBairro ;
      private string A720SerasaEnderecosBairro ;
      private string Z721SerasaEnderecosCidade ;
      private string A721SerasaEnderecosCidade ;
      private string Z722SerasaEnderecosEstado ;
      private string A722SerasaEnderecosEstado ;
      private string Z723SerasaEnderecosCEP ;
      private string A723SerasaEnderecosCEP ;
      private string Z724SerasaEnderecosTelDDD ;
      private string A724SerasaEnderecosTelDDD ;
      private string Z725SerasaEnderecosTel ;
      private string A725SerasaEnderecosTel ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002I5_A716SerasaEnderecosId ;
      private string[] BC002I5_A717SerasaEnderecosLogr ;
      private bool[] BC002I5_n717SerasaEnderecosLogr ;
      private string[] BC002I5_A718SerasaEnderecosNum ;
      private bool[] BC002I5_n718SerasaEnderecosNum ;
      private string[] BC002I5_A719SerasaEnderecosCompl ;
      private bool[] BC002I5_n719SerasaEnderecosCompl ;
      private string[] BC002I5_A720SerasaEnderecosBairro ;
      private bool[] BC002I5_n720SerasaEnderecosBairro ;
      private string[] BC002I5_A721SerasaEnderecosCidade ;
      private bool[] BC002I5_n721SerasaEnderecosCidade ;
      private string[] BC002I5_A722SerasaEnderecosEstado ;
      private bool[] BC002I5_n722SerasaEnderecosEstado ;
      private string[] BC002I5_A723SerasaEnderecosCEP ;
      private bool[] BC002I5_n723SerasaEnderecosCEP ;
      private string[] BC002I5_A724SerasaEnderecosTelDDD ;
      private bool[] BC002I5_n724SerasaEnderecosTelDDD ;
      private string[] BC002I5_A725SerasaEnderecosTel ;
      private bool[] BC002I5_n725SerasaEnderecosTel ;
      private int[] BC002I5_A662SerasaId ;
      private bool[] BC002I5_n662SerasaId ;
      private int[] BC002I4_A662SerasaId ;
      private bool[] BC002I4_n662SerasaId ;
      private int[] BC002I6_A716SerasaEnderecosId ;
      private int[] BC002I3_A716SerasaEnderecosId ;
      private string[] BC002I3_A717SerasaEnderecosLogr ;
      private bool[] BC002I3_n717SerasaEnderecosLogr ;
      private string[] BC002I3_A718SerasaEnderecosNum ;
      private bool[] BC002I3_n718SerasaEnderecosNum ;
      private string[] BC002I3_A719SerasaEnderecosCompl ;
      private bool[] BC002I3_n719SerasaEnderecosCompl ;
      private string[] BC002I3_A720SerasaEnderecosBairro ;
      private bool[] BC002I3_n720SerasaEnderecosBairro ;
      private string[] BC002I3_A721SerasaEnderecosCidade ;
      private bool[] BC002I3_n721SerasaEnderecosCidade ;
      private string[] BC002I3_A722SerasaEnderecosEstado ;
      private bool[] BC002I3_n722SerasaEnderecosEstado ;
      private string[] BC002I3_A723SerasaEnderecosCEP ;
      private bool[] BC002I3_n723SerasaEnderecosCEP ;
      private string[] BC002I3_A724SerasaEnderecosTelDDD ;
      private bool[] BC002I3_n724SerasaEnderecosTelDDD ;
      private string[] BC002I3_A725SerasaEnderecosTel ;
      private bool[] BC002I3_n725SerasaEnderecosTel ;
      private int[] BC002I3_A662SerasaId ;
      private bool[] BC002I3_n662SerasaId ;
      private int[] BC002I2_A716SerasaEnderecosId ;
      private string[] BC002I2_A717SerasaEnderecosLogr ;
      private bool[] BC002I2_n717SerasaEnderecosLogr ;
      private string[] BC002I2_A718SerasaEnderecosNum ;
      private bool[] BC002I2_n718SerasaEnderecosNum ;
      private string[] BC002I2_A719SerasaEnderecosCompl ;
      private bool[] BC002I2_n719SerasaEnderecosCompl ;
      private string[] BC002I2_A720SerasaEnderecosBairro ;
      private bool[] BC002I2_n720SerasaEnderecosBairro ;
      private string[] BC002I2_A721SerasaEnderecosCidade ;
      private bool[] BC002I2_n721SerasaEnderecosCidade ;
      private string[] BC002I2_A722SerasaEnderecosEstado ;
      private bool[] BC002I2_n722SerasaEnderecosEstado ;
      private string[] BC002I2_A723SerasaEnderecosCEP ;
      private bool[] BC002I2_n723SerasaEnderecosCEP ;
      private string[] BC002I2_A724SerasaEnderecosTelDDD ;
      private bool[] BC002I2_n724SerasaEnderecosTelDDD ;
      private string[] BC002I2_A725SerasaEnderecosTel ;
      private bool[] BC002I2_n725SerasaEnderecosTel ;
      private int[] BC002I2_A662SerasaId ;
      private bool[] BC002I2_n662SerasaId ;
      private int[] BC002I8_A716SerasaEnderecosId ;
      private int[] BC002I11_A716SerasaEnderecosId ;
      private string[] BC002I11_A717SerasaEnderecosLogr ;
      private bool[] BC002I11_n717SerasaEnderecosLogr ;
      private string[] BC002I11_A718SerasaEnderecosNum ;
      private bool[] BC002I11_n718SerasaEnderecosNum ;
      private string[] BC002I11_A719SerasaEnderecosCompl ;
      private bool[] BC002I11_n719SerasaEnderecosCompl ;
      private string[] BC002I11_A720SerasaEnderecosBairro ;
      private bool[] BC002I11_n720SerasaEnderecosBairro ;
      private string[] BC002I11_A721SerasaEnderecosCidade ;
      private bool[] BC002I11_n721SerasaEnderecosCidade ;
      private string[] BC002I11_A722SerasaEnderecosEstado ;
      private bool[] BC002I11_n722SerasaEnderecosEstado ;
      private string[] BC002I11_A723SerasaEnderecosCEP ;
      private bool[] BC002I11_n723SerasaEnderecosCEP ;
      private string[] BC002I11_A724SerasaEnderecosTelDDD ;
      private bool[] BC002I11_n724SerasaEnderecosTelDDD ;
      private string[] BC002I11_A725SerasaEnderecosTel ;
      private bool[] BC002I11_n725SerasaEnderecosTel ;
      private int[] BC002I11_A662SerasaId ;
      private bool[] BC002I11_n662SerasaId ;
      private SdtSerasaEnderecos bcSerasaEnderecos ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class serasaenderecos_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC002I2;
          prmBC002I2 = new Object[] {
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmBC002I3;
          prmBC002I3 = new Object[] {
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmBC002I4;
          prmBC002I4 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002I5;
          prmBC002I5 = new Object[] {
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmBC002I6;
          prmBC002I6 = new Object[] {
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmBC002I7;
          prmBC002I7 = new Object[] {
          new ParDef("SerasaEnderecosLogr",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaEnderecosNum",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosCompl",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("SerasaEnderecosBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaEnderecosCidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosEstado",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosTelDDD",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosTel",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002I8;
          prmBC002I8 = new Object[] {
          };
          Object[] prmBC002I9;
          prmBC002I9 = new Object[] {
          new ParDef("SerasaEnderecosLogr",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaEnderecosNum",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosCompl",GXType.VarChar,50,0){Nullable=true} ,
          new ParDef("SerasaEnderecosBairro",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SerasaEnderecosCidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosEstado",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosCEP",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosTelDDD",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaEnderecosTel",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmBC002I10;
          prmBC002I10 = new Object[] {
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          Object[] prmBC002I11;
          prmBC002I11 = new Object[] {
          new ParDef("SerasaEnderecosId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002I2", "SELECT SerasaEnderecosId, SerasaEnderecosLogr, SerasaEnderecosNum, SerasaEnderecosCompl, SerasaEnderecosBairro, SerasaEnderecosCidade, SerasaEnderecosEstado, SerasaEnderecosCEP, SerasaEnderecosTelDDD, SerasaEnderecosTel, SerasaId FROM SerasaEnderecos WHERE SerasaEnderecosId = :SerasaEnderecosId  FOR UPDATE OF SerasaEnderecos",true, GxErrorMask.GX_NOMASK, false, this,prmBC002I2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002I3", "SELECT SerasaEnderecosId, SerasaEnderecosLogr, SerasaEnderecosNum, SerasaEnderecosCompl, SerasaEnderecosBairro, SerasaEnderecosCidade, SerasaEnderecosEstado, SerasaEnderecosCEP, SerasaEnderecosTelDDD, SerasaEnderecosTel, SerasaId FROM SerasaEnderecos WHERE SerasaEnderecosId = :SerasaEnderecosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002I3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002I4", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002I4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002I5", "SELECT TM1.SerasaEnderecosId, TM1.SerasaEnderecosLogr, TM1.SerasaEnderecosNum, TM1.SerasaEnderecosCompl, TM1.SerasaEnderecosBairro, TM1.SerasaEnderecosCidade, TM1.SerasaEnderecosEstado, TM1.SerasaEnderecosCEP, TM1.SerasaEnderecosTelDDD, TM1.SerasaEnderecosTel, TM1.SerasaId FROM SerasaEnderecos TM1 WHERE TM1.SerasaEnderecosId = :SerasaEnderecosId ORDER BY TM1.SerasaEnderecosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002I5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002I6", "SELECT SerasaEnderecosId FROM SerasaEnderecos WHERE SerasaEnderecosId = :SerasaEnderecosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002I6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002I7", "SAVEPOINT gxupdate;INSERT INTO SerasaEnderecos(SerasaEnderecosLogr, SerasaEnderecosNum, SerasaEnderecosCompl, SerasaEnderecosBairro, SerasaEnderecosCidade, SerasaEnderecosEstado, SerasaEnderecosCEP, SerasaEnderecosTelDDD, SerasaEnderecosTel, SerasaId) VALUES(:SerasaEnderecosLogr, :SerasaEnderecosNum, :SerasaEnderecosCompl, :SerasaEnderecosBairro, :SerasaEnderecosCidade, :SerasaEnderecosEstado, :SerasaEnderecosCEP, :SerasaEnderecosTelDDD, :SerasaEnderecosTel, :SerasaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002I7)
             ,new CursorDef("BC002I8", "SELECT currval('SerasaEnderecosId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002I8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002I9", "SAVEPOINT gxupdate;UPDATE SerasaEnderecos SET SerasaEnderecosLogr=:SerasaEnderecosLogr, SerasaEnderecosNum=:SerasaEnderecosNum, SerasaEnderecosCompl=:SerasaEnderecosCompl, SerasaEnderecosBairro=:SerasaEnderecosBairro, SerasaEnderecosCidade=:SerasaEnderecosCidade, SerasaEnderecosEstado=:SerasaEnderecosEstado, SerasaEnderecosCEP=:SerasaEnderecosCEP, SerasaEnderecosTelDDD=:SerasaEnderecosTelDDD, SerasaEnderecosTel=:SerasaEnderecosTel, SerasaId=:SerasaId  WHERE SerasaEnderecosId = :SerasaEnderecosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002I9)
             ,new CursorDef("BC002I10", "SAVEPOINT gxupdate;DELETE FROM SerasaEnderecos  WHERE SerasaEnderecosId = :SerasaEnderecosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002I10)
             ,new CursorDef("BC002I11", "SELECT TM1.SerasaEnderecosId, TM1.SerasaEnderecosLogr, TM1.SerasaEnderecosNum, TM1.SerasaEnderecosCompl, TM1.SerasaEnderecosBairro, TM1.SerasaEnderecosCidade, TM1.SerasaEnderecosEstado, TM1.SerasaEnderecosCEP, TM1.SerasaEnderecosTelDDD, TM1.SerasaEnderecosTel, TM1.SerasaId FROM SerasaEnderecos TM1 WHERE TM1.SerasaEnderecosId = :SerasaEnderecosId ORDER BY TM1.SerasaEnderecosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002I11,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
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
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
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
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
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
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
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
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}
