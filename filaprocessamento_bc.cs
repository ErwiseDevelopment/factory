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
   public class filaprocessamento_bc : GxSilentTrn, IGxSilentTrn
   {
      public filaprocessamento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public filaprocessamento_bc( IGxContext context )
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
         ReadRow1D52( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1D52( ) ;
         standaloneModal( ) ;
         AddRow1D52( ) ;
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
               Z355FilaProcessamentoId = A355FilaProcessamentoId;
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

      protected void CONFIRM_1D0( )
      {
         BeforeValidate1D52( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1D52( ) ;
            }
            else
            {
               CheckExtendedTable1D52( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1D52( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1D52( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z356FilaProcessamentoFuncao = A356FilaProcessamentoFuncao;
            Z358FilaProcessamentoStatus = A358FilaProcessamentoStatus;
            Z359FilaProcessamentoCriacao = A359FilaProcessamentoCriacao;
            Z360FilaProcessamentoAtualizacao = A360FilaProcessamentoAtualizacao;
         }
         if ( GX_JID == -2 )
         {
            Z355FilaProcessamentoId = A355FilaProcessamentoId;
            Z356FilaProcessamentoFuncao = A356FilaProcessamentoFuncao;
            Z357FilaProcessamentoParametros = A357FilaProcessamentoParametros;
            Z358FilaProcessamentoStatus = A358FilaProcessamentoStatus;
            Z359FilaProcessamentoCriacao = A359FilaProcessamentoCriacao;
            Z360FilaProcessamentoAtualizacao = A360FilaProcessamentoAtualizacao;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1D52( )
      {
         /* Using cursor BC001D4 */
         pr_default.execute(2, new Object[] {A355FilaProcessamentoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound52 = 1;
            A356FilaProcessamentoFuncao = BC001D4_A356FilaProcessamentoFuncao[0];
            n356FilaProcessamentoFuncao = BC001D4_n356FilaProcessamentoFuncao[0];
            A357FilaProcessamentoParametros = BC001D4_A357FilaProcessamentoParametros[0];
            n357FilaProcessamentoParametros = BC001D4_n357FilaProcessamentoParametros[0];
            A358FilaProcessamentoStatus = BC001D4_A358FilaProcessamentoStatus[0];
            n358FilaProcessamentoStatus = BC001D4_n358FilaProcessamentoStatus[0];
            A359FilaProcessamentoCriacao = BC001D4_A359FilaProcessamentoCriacao[0];
            n359FilaProcessamentoCriacao = BC001D4_n359FilaProcessamentoCriacao[0];
            A360FilaProcessamentoAtualizacao = BC001D4_A360FilaProcessamentoAtualizacao[0];
            n360FilaProcessamentoAtualizacao = BC001D4_n360FilaProcessamentoAtualizacao[0];
            ZM1D52( -2) ;
         }
         pr_default.close(2);
         OnLoadActions1D52( ) ;
      }

      protected void OnLoadActions1D52( )
      {
      }

      protected void CheckExtendedTable1D52( )
      {
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A358FilaProcessamentoStatus, "PENDENTE") == 0 ) || ( StringUtil.StrCmp(A358FilaProcessamentoStatus, "PROCESSANDO") == 0 ) || ( StringUtil.StrCmp(A358FilaProcessamentoStatus, "CONCLUIDO") == 0 ) || ( StringUtil.StrCmp(A358FilaProcessamentoStatus, "ERRO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A358FilaProcessamentoStatus)) ) )
         {
            GX_msglist.addItem("Campo Fila Processamento Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1D52( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1D52( )
      {
         /* Using cursor BC001D5 */
         pr_default.execute(3, new Object[] {A355FilaProcessamentoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound52 = 1;
         }
         else
         {
            RcdFound52 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001D3 */
         pr_default.execute(1, new Object[] {A355FilaProcessamentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1D52( 2) ;
            RcdFound52 = 1;
            A355FilaProcessamentoId = BC001D3_A355FilaProcessamentoId[0];
            A356FilaProcessamentoFuncao = BC001D3_A356FilaProcessamentoFuncao[0];
            n356FilaProcessamentoFuncao = BC001D3_n356FilaProcessamentoFuncao[0];
            A357FilaProcessamentoParametros = BC001D3_A357FilaProcessamentoParametros[0];
            n357FilaProcessamentoParametros = BC001D3_n357FilaProcessamentoParametros[0];
            A358FilaProcessamentoStatus = BC001D3_A358FilaProcessamentoStatus[0];
            n358FilaProcessamentoStatus = BC001D3_n358FilaProcessamentoStatus[0];
            A359FilaProcessamentoCriacao = BC001D3_A359FilaProcessamentoCriacao[0];
            n359FilaProcessamentoCriacao = BC001D3_n359FilaProcessamentoCriacao[0];
            A360FilaProcessamentoAtualizacao = BC001D3_A360FilaProcessamentoAtualizacao[0];
            n360FilaProcessamentoAtualizacao = BC001D3_n360FilaProcessamentoAtualizacao[0];
            Z355FilaProcessamentoId = A355FilaProcessamentoId;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1D52( ) ;
            if ( AnyError == 1 )
            {
               RcdFound52 = 0;
               InitializeNonKey1D52( ) ;
            }
            Gx_mode = sMode52;
         }
         else
         {
            RcdFound52 = 0;
            InitializeNonKey1D52( ) ;
            sMode52 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode52;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1D52( ) ;
         if ( RcdFound52 == 0 )
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
         CONFIRM_1D0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1D52( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001D2 */
            pr_default.execute(0, new Object[] {A355FilaProcessamentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FilaProcessamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z356FilaProcessamentoFuncao, BC001D2_A356FilaProcessamentoFuncao[0]) != 0 ) || ( StringUtil.StrCmp(Z358FilaProcessamentoStatus, BC001D2_A358FilaProcessamentoStatus[0]) != 0 ) || ( Z359FilaProcessamentoCriacao != BC001D2_A359FilaProcessamentoCriacao[0] ) || ( Z360FilaProcessamentoAtualizacao != BC001D2_A360FilaProcessamentoAtualizacao[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"FilaProcessamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1D52( )
      {
         BeforeValidate1D52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D52( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1D52( 0) ;
            CheckOptimisticConcurrency1D52( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D52( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1D52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001D6 */
                     pr_default.execute(4, new Object[] {n356FilaProcessamentoFuncao, A356FilaProcessamentoFuncao, n357FilaProcessamentoParametros, A357FilaProcessamentoParametros, n358FilaProcessamentoStatus, A358FilaProcessamentoStatus, n359FilaProcessamentoCriacao, A359FilaProcessamentoCriacao, n360FilaProcessamentoAtualizacao, A360FilaProcessamentoAtualizacao});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001D7 */
                     pr_default.execute(5);
                     A355FilaProcessamentoId = BC001D7_A355FilaProcessamentoId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("FilaProcessamento");
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
               Load1D52( ) ;
            }
            EndLevel1D52( ) ;
         }
         CloseExtendedTableCursors1D52( ) ;
      }

      protected void Update1D52( )
      {
         BeforeValidate1D52( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D52( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D52( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D52( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1D52( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001D8 */
                     pr_default.execute(6, new Object[] {n356FilaProcessamentoFuncao, A356FilaProcessamentoFuncao, n357FilaProcessamentoParametros, A357FilaProcessamentoParametros, n358FilaProcessamentoStatus, A358FilaProcessamentoStatus, n359FilaProcessamentoCriacao, A359FilaProcessamentoCriacao, n360FilaProcessamentoAtualizacao, A360FilaProcessamentoAtualizacao, A355FilaProcessamentoId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("FilaProcessamento");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"FilaProcessamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1D52( ) ;
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
            EndLevel1D52( ) ;
         }
         CloseExtendedTableCursors1D52( ) ;
      }

      protected void DeferredUpdate1D52( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1D52( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D52( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1D52( ) ;
            AfterConfirm1D52( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1D52( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001D9 */
                  pr_default.execute(7, new Object[] {A355FilaProcessamentoId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("FilaProcessamento");
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
         sMode52 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1D52( ) ;
         Gx_mode = sMode52;
      }

      protected void OnDeleteControls1D52( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1D52( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1D52( ) ;
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

      public void ScanKeyStart1D52( )
      {
         /* Using cursor BC001D10 */
         pr_default.execute(8, new Object[] {A355FilaProcessamentoId});
         RcdFound52 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound52 = 1;
            A355FilaProcessamentoId = BC001D10_A355FilaProcessamentoId[0];
            A356FilaProcessamentoFuncao = BC001D10_A356FilaProcessamentoFuncao[0];
            n356FilaProcessamentoFuncao = BC001D10_n356FilaProcessamentoFuncao[0];
            A357FilaProcessamentoParametros = BC001D10_A357FilaProcessamentoParametros[0];
            n357FilaProcessamentoParametros = BC001D10_n357FilaProcessamentoParametros[0];
            A358FilaProcessamentoStatus = BC001D10_A358FilaProcessamentoStatus[0];
            n358FilaProcessamentoStatus = BC001D10_n358FilaProcessamentoStatus[0];
            A359FilaProcessamentoCriacao = BC001D10_A359FilaProcessamentoCriacao[0];
            n359FilaProcessamentoCriacao = BC001D10_n359FilaProcessamentoCriacao[0];
            A360FilaProcessamentoAtualizacao = BC001D10_A360FilaProcessamentoAtualizacao[0];
            n360FilaProcessamentoAtualizacao = BC001D10_n360FilaProcessamentoAtualizacao[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1D52( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound52 = 0;
         ScanKeyLoad1D52( ) ;
      }

      protected void ScanKeyLoad1D52( )
      {
         sMode52 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound52 = 1;
            A355FilaProcessamentoId = BC001D10_A355FilaProcessamentoId[0];
            A356FilaProcessamentoFuncao = BC001D10_A356FilaProcessamentoFuncao[0];
            n356FilaProcessamentoFuncao = BC001D10_n356FilaProcessamentoFuncao[0];
            A357FilaProcessamentoParametros = BC001D10_A357FilaProcessamentoParametros[0];
            n357FilaProcessamentoParametros = BC001D10_n357FilaProcessamentoParametros[0];
            A358FilaProcessamentoStatus = BC001D10_A358FilaProcessamentoStatus[0];
            n358FilaProcessamentoStatus = BC001D10_n358FilaProcessamentoStatus[0];
            A359FilaProcessamentoCriacao = BC001D10_A359FilaProcessamentoCriacao[0];
            n359FilaProcessamentoCriacao = BC001D10_n359FilaProcessamentoCriacao[0];
            A360FilaProcessamentoAtualizacao = BC001D10_A360FilaProcessamentoAtualizacao[0];
            n360FilaProcessamentoAtualizacao = BC001D10_n360FilaProcessamentoAtualizacao[0];
         }
         Gx_mode = sMode52;
      }

      protected void ScanKeyEnd1D52( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1D52( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1D52( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1D52( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1D52( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1D52( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1D52( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1D52( )
      {
      }

      protected void send_integrity_lvl_hashes1D52( )
      {
      }

      protected void AddRow1D52( )
      {
         VarsToRow52( bcFilaProcessamento) ;
      }

      protected void ReadRow1D52( )
      {
         RowToVars52( bcFilaProcessamento, 1) ;
      }

      protected void InitializeNonKey1D52( )
      {
         A356FilaProcessamentoFuncao = "";
         n356FilaProcessamentoFuncao = false;
         A357FilaProcessamentoParametros = "";
         n357FilaProcessamentoParametros = false;
         A358FilaProcessamentoStatus = "";
         n358FilaProcessamentoStatus = false;
         A359FilaProcessamentoCriacao = (DateTime)(DateTime.MinValue);
         n359FilaProcessamentoCriacao = false;
         A360FilaProcessamentoAtualizacao = (DateTime)(DateTime.MinValue);
         n360FilaProcessamentoAtualizacao = false;
         Z356FilaProcessamentoFuncao = "";
         Z358FilaProcessamentoStatus = "";
         Z359FilaProcessamentoCriacao = (DateTime)(DateTime.MinValue);
         Z360FilaProcessamentoAtualizacao = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll1D52( )
      {
         A355FilaProcessamentoId = 0;
         InitializeNonKey1D52( ) ;
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

      public void VarsToRow52( SdtFilaProcessamento obj52 )
      {
         obj52.gxTpr_Mode = Gx_mode;
         obj52.gxTpr_Filaprocessamentofuncao = A356FilaProcessamentoFuncao;
         obj52.gxTpr_Filaprocessamentoparametros = A357FilaProcessamentoParametros;
         obj52.gxTpr_Filaprocessamentostatus = A358FilaProcessamentoStatus;
         obj52.gxTpr_Filaprocessamentocriacao = A359FilaProcessamentoCriacao;
         obj52.gxTpr_Filaprocessamentoatualizacao = A360FilaProcessamentoAtualizacao;
         obj52.gxTpr_Filaprocessamentoid = A355FilaProcessamentoId;
         obj52.gxTpr_Filaprocessamentoid_Z = Z355FilaProcessamentoId;
         obj52.gxTpr_Filaprocessamentofuncao_Z = Z356FilaProcessamentoFuncao;
         obj52.gxTpr_Filaprocessamentostatus_Z = Z358FilaProcessamentoStatus;
         obj52.gxTpr_Filaprocessamentocriacao_Z = Z359FilaProcessamentoCriacao;
         obj52.gxTpr_Filaprocessamentoatualizacao_Z = Z360FilaProcessamentoAtualizacao;
         obj52.gxTpr_Filaprocessamentofuncao_N = (short)(Convert.ToInt16(n356FilaProcessamentoFuncao));
         obj52.gxTpr_Filaprocessamentoparametros_N = (short)(Convert.ToInt16(n357FilaProcessamentoParametros));
         obj52.gxTpr_Filaprocessamentostatus_N = (short)(Convert.ToInt16(n358FilaProcessamentoStatus));
         obj52.gxTpr_Filaprocessamentocriacao_N = (short)(Convert.ToInt16(n359FilaProcessamentoCriacao));
         obj52.gxTpr_Filaprocessamentoatualizacao_N = (short)(Convert.ToInt16(n360FilaProcessamentoAtualizacao));
         obj52.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow52( SdtFilaProcessamento obj52 )
      {
         obj52.gxTpr_Filaprocessamentoid = A355FilaProcessamentoId;
         return  ;
      }

      public void RowToVars52( SdtFilaProcessamento obj52 ,
                               int forceLoad )
      {
         Gx_mode = obj52.gxTpr_Mode;
         A356FilaProcessamentoFuncao = obj52.gxTpr_Filaprocessamentofuncao;
         n356FilaProcessamentoFuncao = false;
         A357FilaProcessamentoParametros = obj52.gxTpr_Filaprocessamentoparametros;
         n357FilaProcessamentoParametros = false;
         A358FilaProcessamentoStatus = obj52.gxTpr_Filaprocessamentostatus;
         n358FilaProcessamentoStatus = false;
         A359FilaProcessamentoCriacao = obj52.gxTpr_Filaprocessamentocriacao;
         n359FilaProcessamentoCriacao = false;
         A360FilaProcessamentoAtualizacao = obj52.gxTpr_Filaprocessamentoatualizacao;
         n360FilaProcessamentoAtualizacao = false;
         A355FilaProcessamentoId = obj52.gxTpr_Filaprocessamentoid;
         Z355FilaProcessamentoId = obj52.gxTpr_Filaprocessamentoid_Z;
         Z356FilaProcessamentoFuncao = obj52.gxTpr_Filaprocessamentofuncao_Z;
         Z358FilaProcessamentoStatus = obj52.gxTpr_Filaprocessamentostatus_Z;
         Z359FilaProcessamentoCriacao = obj52.gxTpr_Filaprocessamentocriacao_Z;
         Z360FilaProcessamentoAtualizacao = obj52.gxTpr_Filaprocessamentoatualizacao_Z;
         n356FilaProcessamentoFuncao = (bool)(Convert.ToBoolean(obj52.gxTpr_Filaprocessamentofuncao_N));
         n357FilaProcessamentoParametros = (bool)(Convert.ToBoolean(obj52.gxTpr_Filaprocessamentoparametros_N));
         n358FilaProcessamentoStatus = (bool)(Convert.ToBoolean(obj52.gxTpr_Filaprocessamentostatus_N));
         n359FilaProcessamentoCriacao = (bool)(Convert.ToBoolean(obj52.gxTpr_Filaprocessamentocriacao_N));
         n360FilaProcessamentoAtualizacao = (bool)(Convert.ToBoolean(obj52.gxTpr_Filaprocessamentoatualizacao_N));
         Gx_mode = obj52.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A355FilaProcessamentoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1D52( ) ;
         ScanKeyStart1D52( ) ;
         if ( RcdFound52 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z355FilaProcessamentoId = A355FilaProcessamentoId;
         }
         ZM1D52( -2) ;
         OnLoadActions1D52( ) ;
         AddRow1D52( ) ;
         ScanKeyEnd1D52( ) ;
         if ( RcdFound52 == 0 )
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
         RowToVars52( bcFilaProcessamento, 0) ;
         ScanKeyStart1D52( ) ;
         if ( RcdFound52 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z355FilaProcessamentoId = A355FilaProcessamentoId;
         }
         ZM1D52( -2) ;
         OnLoadActions1D52( ) ;
         AddRow1D52( ) ;
         ScanKeyEnd1D52( ) ;
         if ( RcdFound52 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1D52( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1D52( ) ;
         }
         else
         {
            if ( RcdFound52 == 1 )
            {
               if ( A355FilaProcessamentoId != Z355FilaProcessamentoId )
               {
                  A355FilaProcessamentoId = Z355FilaProcessamentoId;
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
                  Update1D52( ) ;
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
                  if ( A355FilaProcessamentoId != Z355FilaProcessamentoId )
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
                        Insert1D52( ) ;
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
                        Insert1D52( ) ;
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
         RowToVars52( bcFilaProcessamento, 1) ;
         SaveImpl( ) ;
         VarsToRow52( bcFilaProcessamento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars52( bcFilaProcessamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1D52( ) ;
         AfterTrn( ) ;
         VarsToRow52( bcFilaProcessamento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow52( bcFilaProcessamento) ;
         }
         else
         {
            SdtFilaProcessamento auxBC = new SdtFilaProcessamento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A355FilaProcessamentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcFilaProcessamento);
               auxBC.Save();
               bcFilaProcessamento.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars52( bcFilaProcessamento, 1) ;
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
         RowToVars52( bcFilaProcessamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1D52( ) ;
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
               VarsToRow52( bcFilaProcessamento) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow52( bcFilaProcessamento) ;
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
         RowToVars52( bcFilaProcessamento, 0) ;
         GetKey1D52( ) ;
         if ( RcdFound52 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A355FilaProcessamentoId != Z355FilaProcessamentoId )
            {
               A355FilaProcessamentoId = Z355FilaProcessamentoId;
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
            if ( A355FilaProcessamentoId != Z355FilaProcessamentoId )
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
         context.RollbackDataStores("filaprocessamento_bc",pr_default);
         VarsToRow52( bcFilaProcessamento) ;
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
         Gx_mode = bcFilaProcessamento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcFilaProcessamento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcFilaProcessamento )
         {
            bcFilaProcessamento = (SdtFilaProcessamento)(sdt);
            if ( StringUtil.StrCmp(bcFilaProcessamento.gxTpr_Mode, "") == 0 )
            {
               bcFilaProcessamento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow52( bcFilaProcessamento) ;
            }
            else
            {
               RowToVars52( bcFilaProcessamento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcFilaProcessamento.gxTpr_Mode, "") == 0 )
            {
               bcFilaProcessamento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars52( bcFilaProcessamento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtFilaProcessamento FilaProcessamento_BC
      {
         get {
            return bcFilaProcessamento ;
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
         Z356FilaProcessamentoFuncao = "";
         A356FilaProcessamentoFuncao = "";
         Z358FilaProcessamentoStatus = "";
         A358FilaProcessamentoStatus = "";
         Z359FilaProcessamentoCriacao = (DateTime)(DateTime.MinValue);
         A359FilaProcessamentoCriacao = (DateTime)(DateTime.MinValue);
         Z360FilaProcessamentoAtualizacao = (DateTime)(DateTime.MinValue);
         A360FilaProcessamentoAtualizacao = (DateTime)(DateTime.MinValue);
         Z357FilaProcessamentoParametros = "";
         A357FilaProcessamentoParametros = "";
         BC001D4_A355FilaProcessamentoId = new int[1] ;
         BC001D4_A356FilaProcessamentoFuncao = new string[] {""} ;
         BC001D4_n356FilaProcessamentoFuncao = new bool[] {false} ;
         BC001D4_A357FilaProcessamentoParametros = new string[] {""} ;
         BC001D4_n357FilaProcessamentoParametros = new bool[] {false} ;
         BC001D4_A358FilaProcessamentoStatus = new string[] {""} ;
         BC001D4_n358FilaProcessamentoStatus = new bool[] {false} ;
         BC001D4_A359FilaProcessamentoCriacao = new DateTime[] {DateTime.MinValue} ;
         BC001D4_n359FilaProcessamentoCriacao = new bool[] {false} ;
         BC001D4_A360FilaProcessamentoAtualizacao = new DateTime[] {DateTime.MinValue} ;
         BC001D4_n360FilaProcessamentoAtualizacao = new bool[] {false} ;
         BC001D5_A355FilaProcessamentoId = new int[1] ;
         BC001D3_A355FilaProcessamentoId = new int[1] ;
         BC001D3_A356FilaProcessamentoFuncao = new string[] {""} ;
         BC001D3_n356FilaProcessamentoFuncao = new bool[] {false} ;
         BC001D3_A357FilaProcessamentoParametros = new string[] {""} ;
         BC001D3_n357FilaProcessamentoParametros = new bool[] {false} ;
         BC001D3_A358FilaProcessamentoStatus = new string[] {""} ;
         BC001D3_n358FilaProcessamentoStatus = new bool[] {false} ;
         BC001D3_A359FilaProcessamentoCriacao = new DateTime[] {DateTime.MinValue} ;
         BC001D3_n359FilaProcessamentoCriacao = new bool[] {false} ;
         BC001D3_A360FilaProcessamentoAtualizacao = new DateTime[] {DateTime.MinValue} ;
         BC001D3_n360FilaProcessamentoAtualizacao = new bool[] {false} ;
         sMode52 = "";
         BC001D2_A355FilaProcessamentoId = new int[1] ;
         BC001D2_A356FilaProcessamentoFuncao = new string[] {""} ;
         BC001D2_n356FilaProcessamentoFuncao = new bool[] {false} ;
         BC001D2_A357FilaProcessamentoParametros = new string[] {""} ;
         BC001D2_n357FilaProcessamentoParametros = new bool[] {false} ;
         BC001D2_A358FilaProcessamentoStatus = new string[] {""} ;
         BC001D2_n358FilaProcessamentoStatus = new bool[] {false} ;
         BC001D2_A359FilaProcessamentoCriacao = new DateTime[] {DateTime.MinValue} ;
         BC001D2_n359FilaProcessamentoCriacao = new bool[] {false} ;
         BC001D2_A360FilaProcessamentoAtualizacao = new DateTime[] {DateTime.MinValue} ;
         BC001D2_n360FilaProcessamentoAtualizacao = new bool[] {false} ;
         BC001D7_A355FilaProcessamentoId = new int[1] ;
         BC001D10_A355FilaProcessamentoId = new int[1] ;
         BC001D10_A356FilaProcessamentoFuncao = new string[] {""} ;
         BC001D10_n356FilaProcessamentoFuncao = new bool[] {false} ;
         BC001D10_A357FilaProcessamentoParametros = new string[] {""} ;
         BC001D10_n357FilaProcessamentoParametros = new bool[] {false} ;
         BC001D10_A358FilaProcessamentoStatus = new string[] {""} ;
         BC001D10_n358FilaProcessamentoStatus = new bool[] {false} ;
         BC001D10_A359FilaProcessamentoCriacao = new DateTime[] {DateTime.MinValue} ;
         BC001D10_n359FilaProcessamentoCriacao = new bool[] {false} ;
         BC001D10_A360FilaProcessamentoAtualizacao = new DateTime[] {DateTime.MinValue} ;
         BC001D10_n360FilaProcessamentoAtualizacao = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.filaprocessamento_bc__default(),
            new Object[][] {
                new Object[] {
               BC001D2_A355FilaProcessamentoId, BC001D2_A356FilaProcessamentoFuncao, BC001D2_n356FilaProcessamentoFuncao, BC001D2_A357FilaProcessamentoParametros, BC001D2_n357FilaProcessamentoParametros, BC001D2_A358FilaProcessamentoStatus, BC001D2_n358FilaProcessamentoStatus, BC001D2_A359FilaProcessamentoCriacao, BC001D2_n359FilaProcessamentoCriacao, BC001D2_A360FilaProcessamentoAtualizacao,
               BC001D2_n360FilaProcessamentoAtualizacao
               }
               , new Object[] {
               BC001D3_A355FilaProcessamentoId, BC001D3_A356FilaProcessamentoFuncao, BC001D3_n356FilaProcessamentoFuncao, BC001D3_A357FilaProcessamentoParametros, BC001D3_n357FilaProcessamentoParametros, BC001D3_A358FilaProcessamentoStatus, BC001D3_n358FilaProcessamentoStatus, BC001D3_A359FilaProcessamentoCriacao, BC001D3_n359FilaProcessamentoCriacao, BC001D3_A360FilaProcessamentoAtualizacao,
               BC001D3_n360FilaProcessamentoAtualizacao
               }
               , new Object[] {
               BC001D4_A355FilaProcessamentoId, BC001D4_A356FilaProcessamentoFuncao, BC001D4_n356FilaProcessamentoFuncao, BC001D4_A357FilaProcessamentoParametros, BC001D4_n357FilaProcessamentoParametros, BC001D4_A358FilaProcessamentoStatus, BC001D4_n358FilaProcessamentoStatus, BC001D4_A359FilaProcessamentoCriacao, BC001D4_n359FilaProcessamentoCriacao, BC001D4_A360FilaProcessamentoAtualizacao,
               BC001D4_n360FilaProcessamentoAtualizacao
               }
               , new Object[] {
               BC001D5_A355FilaProcessamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001D7_A355FilaProcessamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001D10_A355FilaProcessamentoId, BC001D10_A356FilaProcessamentoFuncao, BC001D10_n356FilaProcessamentoFuncao, BC001D10_A357FilaProcessamentoParametros, BC001D10_n357FilaProcessamentoParametros, BC001D10_A358FilaProcessamentoStatus, BC001D10_n358FilaProcessamentoStatus, BC001D10_A359FilaProcessamentoCriacao, BC001D10_n359FilaProcessamentoCriacao, BC001D10_A360FilaProcessamentoAtualizacao,
               BC001D10_n360FilaProcessamentoAtualizacao
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound52 ;
      private int trnEnded ;
      private int Z355FilaProcessamentoId ;
      private int A355FilaProcessamentoId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode52 ;
      private DateTime Z359FilaProcessamentoCriacao ;
      private DateTime A359FilaProcessamentoCriacao ;
      private DateTime Z360FilaProcessamentoAtualizacao ;
      private DateTime A360FilaProcessamentoAtualizacao ;
      private bool n356FilaProcessamentoFuncao ;
      private bool n357FilaProcessamentoParametros ;
      private bool n358FilaProcessamentoStatus ;
      private bool n359FilaProcessamentoCriacao ;
      private bool n360FilaProcessamentoAtualizacao ;
      private string Z357FilaProcessamentoParametros ;
      private string A357FilaProcessamentoParametros ;
      private string Z356FilaProcessamentoFuncao ;
      private string A356FilaProcessamentoFuncao ;
      private string Z358FilaProcessamentoStatus ;
      private string A358FilaProcessamentoStatus ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001D4_A355FilaProcessamentoId ;
      private string[] BC001D4_A356FilaProcessamentoFuncao ;
      private bool[] BC001D4_n356FilaProcessamentoFuncao ;
      private string[] BC001D4_A357FilaProcessamentoParametros ;
      private bool[] BC001D4_n357FilaProcessamentoParametros ;
      private string[] BC001D4_A358FilaProcessamentoStatus ;
      private bool[] BC001D4_n358FilaProcessamentoStatus ;
      private DateTime[] BC001D4_A359FilaProcessamentoCriacao ;
      private bool[] BC001D4_n359FilaProcessamentoCriacao ;
      private DateTime[] BC001D4_A360FilaProcessamentoAtualizacao ;
      private bool[] BC001D4_n360FilaProcessamentoAtualizacao ;
      private int[] BC001D5_A355FilaProcessamentoId ;
      private int[] BC001D3_A355FilaProcessamentoId ;
      private string[] BC001D3_A356FilaProcessamentoFuncao ;
      private bool[] BC001D3_n356FilaProcessamentoFuncao ;
      private string[] BC001D3_A357FilaProcessamentoParametros ;
      private bool[] BC001D3_n357FilaProcessamentoParametros ;
      private string[] BC001D3_A358FilaProcessamentoStatus ;
      private bool[] BC001D3_n358FilaProcessamentoStatus ;
      private DateTime[] BC001D3_A359FilaProcessamentoCriacao ;
      private bool[] BC001D3_n359FilaProcessamentoCriacao ;
      private DateTime[] BC001D3_A360FilaProcessamentoAtualizacao ;
      private bool[] BC001D3_n360FilaProcessamentoAtualizacao ;
      private int[] BC001D2_A355FilaProcessamentoId ;
      private string[] BC001D2_A356FilaProcessamentoFuncao ;
      private bool[] BC001D2_n356FilaProcessamentoFuncao ;
      private string[] BC001D2_A357FilaProcessamentoParametros ;
      private bool[] BC001D2_n357FilaProcessamentoParametros ;
      private string[] BC001D2_A358FilaProcessamentoStatus ;
      private bool[] BC001D2_n358FilaProcessamentoStatus ;
      private DateTime[] BC001D2_A359FilaProcessamentoCriacao ;
      private bool[] BC001D2_n359FilaProcessamentoCriacao ;
      private DateTime[] BC001D2_A360FilaProcessamentoAtualizacao ;
      private bool[] BC001D2_n360FilaProcessamentoAtualizacao ;
      private int[] BC001D7_A355FilaProcessamentoId ;
      private int[] BC001D10_A355FilaProcessamentoId ;
      private string[] BC001D10_A356FilaProcessamentoFuncao ;
      private bool[] BC001D10_n356FilaProcessamentoFuncao ;
      private string[] BC001D10_A357FilaProcessamentoParametros ;
      private bool[] BC001D10_n357FilaProcessamentoParametros ;
      private string[] BC001D10_A358FilaProcessamentoStatus ;
      private bool[] BC001D10_n358FilaProcessamentoStatus ;
      private DateTime[] BC001D10_A359FilaProcessamentoCriacao ;
      private bool[] BC001D10_n359FilaProcessamentoCriacao ;
      private DateTime[] BC001D10_A360FilaProcessamentoAtualizacao ;
      private bool[] BC001D10_n360FilaProcessamentoAtualizacao ;
      private SdtFilaProcessamento bcFilaProcessamento ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class filaprocessamento_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001D2;
          prmBC001D2 = new Object[] {
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC001D3;
          prmBC001D3 = new Object[] {
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC001D4;
          prmBC001D4 = new Object[] {
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC001D5;
          prmBC001D5 = new Object[] {
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC001D6;
          prmBC001D6 = new Object[] {
          new ParDef("FilaProcessamentoFuncao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("FilaProcessamentoParametros",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("FilaProcessamentoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("FilaProcessamentoCriacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("FilaProcessamentoAtualizacao",GXType.DateTime,8,5){Nullable=true}
          };
          Object[] prmBC001D7;
          prmBC001D7 = new Object[] {
          };
          Object[] prmBC001D8;
          prmBC001D8 = new Object[] {
          new ParDef("FilaProcessamentoFuncao",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("FilaProcessamentoParametros",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("FilaProcessamentoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("FilaProcessamentoCriacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("FilaProcessamentoAtualizacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC001D9;
          prmBC001D9 = new Object[] {
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC001D10;
          prmBC001D10 = new Object[] {
          new ParDef("FilaProcessamentoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC001D2", "SELECT FilaProcessamentoId, FilaProcessamentoFuncao, FilaProcessamentoParametros, FilaProcessamentoStatus, FilaProcessamentoCriacao, FilaProcessamentoAtualizacao FROM FilaProcessamento WHERE FilaProcessamentoId = :FilaProcessamentoId  FOR UPDATE OF FilaProcessamento",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001D3", "SELECT FilaProcessamentoId, FilaProcessamentoFuncao, FilaProcessamentoParametros, FilaProcessamentoStatus, FilaProcessamentoCriacao, FilaProcessamentoAtualizacao FROM FilaProcessamento WHERE FilaProcessamentoId = :FilaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001D4", "SELECT TM1.FilaProcessamentoId, TM1.FilaProcessamentoFuncao, TM1.FilaProcessamentoParametros, TM1.FilaProcessamentoStatus, TM1.FilaProcessamentoCriacao, TM1.FilaProcessamentoAtualizacao FROM FilaProcessamento TM1 WHERE TM1.FilaProcessamentoId = :FilaProcessamentoId ORDER BY TM1.FilaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001D5", "SELECT FilaProcessamentoId FROM FilaProcessamento WHERE FilaProcessamentoId = :FilaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001D6", "SAVEPOINT gxupdate;INSERT INTO FilaProcessamento(FilaProcessamentoFuncao, FilaProcessamentoParametros, FilaProcessamentoStatus, FilaProcessamentoCriacao, FilaProcessamentoAtualizacao) VALUES(:FilaProcessamentoFuncao, :FilaProcessamentoParametros, :FilaProcessamentoStatus, :FilaProcessamentoCriacao, :FilaProcessamentoAtualizacao);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001D6)
             ,new CursorDef("BC001D7", "SELECT currval('FilaProcessamentoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001D8", "SAVEPOINT gxupdate;UPDATE FilaProcessamento SET FilaProcessamentoFuncao=:FilaProcessamentoFuncao, FilaProcessamentoParametros=:FilaProcessamentoParametros, FilaProcessamentoStatus=:FilaProcessamentoStatus, FilaProcessamentoCriacao=:FilaProcessamentoCriacao, FilaProcessamentoAtualizacao=:FilaProcessamentoAtualizacao  WHERE FilaProcessamentoId = :FilaProcessamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001D8)
             ,new CursorDef("BC001D9", "SAVEPOINT gxupdate;DELETE FROM FilaProcessamento  WHERE FilaProcessamentoId = :FilaProcessamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001D9)
             ,new CursorDef("BC001D10", "SELECT TM1.FilaProcessamentoId, TM1.FilaProcessamentoFuncao, TM1.FilaProcessamentoParametros, TM1.FilaProcessamentoStatus, TM1.FilaProcessamentoCriacao, TM1.FilaProcessamentoAtualizacao FROM FilaProcessamento TM1 WHERE TM1.FilaProcessamentoId = :FilaProcessamentoId ORDER BY TM1.FilaProcessamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001D10,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
