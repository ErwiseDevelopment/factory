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
   public class conta_bc : GxSilentTrn, IGxSilentTrn
   {
      public conta_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public conta_bc( IGxContext context )
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
         ReadRow1P63( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1P63( ) ;
         standaloneModal( ) ;
         AddRow1P63( ) ;
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
            E111P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z422ContaId = A422ContaId;
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

      protected void CONFIRM_1P0( )
      {
         BeforeValidate1P63( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1P63( ) ;
            }
            else
            {
               CheckExtendedTable1P63( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1P63( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121P2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1P63( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z425ContaDataUltimaAtualizacao = A425ContaDataUltimaAtualizacao;
            Z423ContaSaldoAtual = A423ContaSaldoAtual;
            Z424ContaNomeConta = A424ContaNomeConta;
            Z430ContaStatus = A430ContaStatus;
            Z499ContaProposta = A499ContaProposta;
         }
         if ( GX_JID == -4 )
         {
            Z422ContaId = A422ContaId;
            Z425ContaDataUltimaAtualizacao = A425ContaDataUltimaAtualizacao;
            Z423ContaSaldoAtual = A423ContaSaldoAtual;
            Z424ContaNomeConta = A424ContaNomeConta;
            Z430ContaStatus = A430ContaStatus;
            Z499ContaProposta = A499ContaProposta;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         A425ContaDataUltimaAtualizacao = DateTimeUtil.ServerNow( context, pr_default);
         n425ContaDataUltimaAtualizacao = false;
         if ( IsIns( )  && (false==A430ContaStatus) && ( Gx_BScreen == 0 ) )
         {
            A430ContaStatus = true;
            n430ContaStatus = false;
         }
      }

      protected void Load1P63( )
      {
         /* Using cursor BC001P4 */
         pr_default.execute(2, new Object[] {n422ContaId, A422ContaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound63 = 1;
            A425ContaDataUltimaAtualizacao = BC001P4_A425ContaDataUltimaAtualizacao[0];
            n425ContaDataUltimaAtualizacao = BC001P4_n425ContaDataUltimaAtualizacao[0];
            A423ContaSaldoAtual = BC001P4_A423ContaSaldoAtual[0];
            n423ContaSaldoAtual = BC001P4_n423ContaSaldoAtual[0];
            A424ContaNomeConta = BC001P4_A424ContaNomeConta[0];
            n424ContaNomeConta = BC001P4_n424ContaNomeConta[0];
            A430ContaStatus = BC001P4_A430ContaStatus[0];
            n430ContaStatus = BC001P4_n430ContaStatus[0];
            A499ContaProposta = BC001P4_A499ContaProposta[0];
            n499ContaProposta = BC001P4_n499ContaProposta[0];
            ZM1P63( -4) ;
         }
         pr_default.close(2);
         OnLoadActions1P63( ) ;
      }

      protected void OnLoadActions1P63( )
      {
      }

      protected void CheckExtendedTable1P63( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1P63( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1P63( )
      {
         /* Using cursor BC001P5 */
         pr_default.execute(3, new Object[] {n422ContaId, A422ContaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound63 = 1;
         }
         else
         {
            RcdFound63 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001P3 */
         pr_default.execute(1, new Object[] {n422ContaId, A422ContaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1P63( 4) ;
            RcdFound63 = 1;
            A422ContaId = BC001P3_A422ContaId[0];
            n422ContaId = BC001P3_n422ContaId[0];
            A425ContaDataUltimaAtualizacao = BC001P3_A425ContaDataUltimaAtualizacao[0];
            n425ContaDataUltimaAtualizacao = BC001P3_n425ContaDataUltimaAtualizacao[0];
            A423ContaSaldoAtual = BC001P3_A423ContaSaldoAtual[0];
            n423ContaSaldoAtual = BC001P3_n423ContaSaldoAtual[0];
            A424ContaNomeConta = BC001P3_A424ContaNomeConta[0];
            n424ContaNomeConta = BC001P3_n424ContaNomeConta[0];
            A430ContaStatus = BC001P3_A430ContaStatus[0];
            n430ContaStatus = BC001P3_n430ContaStatus[0];
            A499ContaProposta = BC001P3_A499ContaProposta[0];
            n499ContaProposta = BC001P3_n499ContaProposta[0];
            Z422ContaId = A422ContaId;
            sMode63 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1P63( ) ;
            if ( AnyError == 1 )
            {
               RcdFound63 = 0;
               InitializeNonKey1P63( ) ;
            }
            Gx_mode = sMode63;
         }
         else
         {
            RcdFound63 = 0;
            InitializeNonKey1P63( ) ;
            sMode63 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode63;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1P63( ) ;
         if ( RcdFound63 == 0 )
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
         CONFIRM_1P0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1P63( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001P2 */
            pr_default.execute(0, new Object[] {n422ContaId, A422ContaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Conta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z425ContaDataUltimaAtualizacao != BC001P2_A425ContaDataUltimaAtualizacao[0] ) || ( Z423ContaSaldoAtual != BC001P2_A423ContaSaldoAtual[0] ) || ( StringUtil.StrCmp(Z424ContaNomeConta, BC001P2_A424ContaNomeConta[0]) != 0 ) || ( Z430ContaStatus != BC001P2_A430ContaStatus[0] ) || ( Z499ContaProposta != BC001P2_A499ContaProposta[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Conta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1P63( )
      {
         BeforeValidate1P63( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1P63( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1P63( 0) ;
            CheckOptimisticConcurrency1P63( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1P63( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1P63( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001P6 */
                     pr_default.execute(4, new Object[] {n425ContaDataUltimaAtualizacao, A425ContaDataUltimaAtualizacao, n423ContaSaldoAtual, A423ContaSaldoAtual, n424ContaNomeConta, A424ContaNomeConta, n430ContaStatus, A430ContaStatus, n499ContaProposta, A499ContaProposta});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001P7 */
                     pr_default.execute(5);
                     A422ContaId = BC001P7_A422ContaId[0];
                     n422ContaId = BC001P7_n422ContaId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Conta");
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
               Load1P63( ) ;
            }
            EndLevel1P63( ) ;
         }
         CloseExtendedTableCursors1P63( ) ;
      }

      protected void Update1P63( )
      {
         BeforeValidate1P63( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1P63( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1P63( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1P63( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1P63( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001P8 */
                     pr_default.execute(6, new Object[] {n425ContaDataUltimaAtualizacao, A425ContaDataUltimaAtualizacao, n423ContaSaldoAtual, A423ContaSaldoAtual, n424ContaNomeConta, A424ContaNomeConta, n430ContaStatus, A430ContaStatus, n499ContaProposta, A499ContaProposta, n422ContaId, A422ContaId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Conta");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Conta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1P63( ) ;
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
            EndLevel1P63( ) ;
         }
         CloseExtendedTableCursors1P63( ) ;
      }

      protected void DeferredUpdate1P63( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1P63( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1P63( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1P63( ) ;
            AfterConfirm1P63( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1P63( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001P9 */
                  pr_default.execute(7, new Object[] {n422ContaId, A422ContaId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Conta");
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
         sMode63 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1P63( ) ;
         Gx_mode = sMode63;
      }

      protected void OnDeleteControls1P63( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001P10 */
            pr_default.execute(8, new Object[] {n422ContaId, A422ContaId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TituloMovimento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC001P11 */
            pr_default.execute(9, new Object[] {n422ContaId, A422ContaId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1P63( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1P63( ) ;
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

      public void ScanKeyStart1P63( )
      {
         /* Scan By routine */
         /* Using cursor BC001P12 */
         pr_default.execute(10, new Object[] {n422ContaId, A422ContaId});
         RcdFound63 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound63 = 1;
            A422ContaId = BC001P12_A422ContaId[0];
            n422ContaId = BC001P12_n422ContaId[0];
            A425ContaDataUltimaAtualizacao = BC001P12_A425ContaDataUltimaAtualizacao[0];
            n425ContaDataUltimaAtualizacao = BC001P12_n425ContaDataUltimaAtualizacao[0];
            A423ContaSaldoAtual = BC001P12_A423ContaSaldoAtual[0];
            n423ContaSaldoAtual = BC001P12_n423ContaSaldoAtual[0];
            A424ContaNomeConta = BC001P12_A424ContaNomeConta[0];
            n424ContaNomeConta = BC001P12_n424ContaNomeConta[0];
            A430ContaStatus = BC001P12_A430ContaStatus[0];
            n430ContaStatus = BC001P12_n430ContaStatus[0];
            A499ContaProposta = BC001P12_A499ContaProposta[0];
            n499ContaProposta = BC001P12_n499ContaProposta[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1P63( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound63 = 0;
         ScanKeyLoad1P63( ) ;
      }

      protected void ScanKeyLoad1P63( )
      {
         sMode63 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound63 = 1;
            A422ContaId = BC001P12_A422ContaId[0];
            n422ContaId = BC001P12_n422ContaId[0];
            A425ContaDataUltimaAtualizacao = BC001P12_A425ContaDataUltimaAtualizacao[0];
            n425ContaDataUltimaAtualizacao = BC001P12_n425ContaDataUltimaAtualizacao[0];
            A423ContaSaldoAtual = BC001P12_A423ContaSaldoAtual[0];
            n423ContaSaldoAtual = BC001P12_n423ContaSaldoAtual[0];
            A424ContaNomeConta = BC001P12_A424ContaNomeConta[0];
            n424ContaNomeConta = BC001P12_n424ContaNomeConta[0];
            A430ContaStatus = BC001P12_A430ContaStatus[0];
            n430ContaStatus = BC001P12_n430ContaStatus[0];
            A499ContaProposta = BC001P12_A499ContaProposta[0];
            n499ContaProposta = BC001P12_n499ContaProposta[0];
         }
         Gx_mode = sMode63;
      }

      protected void ScanKeyEnd1P63( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1P63( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1P63( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1P63( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1P63( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1P63( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1P63( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1P63( )
      {
      }

      protected void send_integrity_lvl_hashes1P63( )
      {
      }

      protected void AddRow1P63( )
      {
         VarsToRow63( bcConta) ;
      }

      protected void ReadRow1P63( )
      {
         RowToVars63( bcConta, 1) ;
      }

      protected void InitializeNonKey1P63( )
      {
         A425ContaDataUltimaAtualizacao = (DateTime)(DateTime.MinValue);
         n425ContaDataUltimaAtualizacao = false;
         A423ContaSaldoAtual = 0;
         n423ContaSaldoAtual = false;
         A424ContaNomeConta = "";
         n424ContaNomeConta = false;
         A499ContaProposta = false;
         n499ContaProposta = false;
         A430ContaStatus = true;
         n430ContaStatus = false;
         Z425ContaDataUltimaAtualizacao = (DateTime)(DateTime.MinValue);
         Z423ContaSaldoAtual = 0;
         Z424ContaNomeConta = "";
         Z430ContaStatus = false;
         Z499ContaProposta = false;
      }

      protected void InitAll1P63( )
      {
         A422ContaId = 0;
         n422ContaId = false;
         InitializeNonKey1P63( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A425ContaDataUltimaAtualizacao = i425ContaDataUltimaAtualizacao;
         n425ContaDataUltimaAtualizacao = false;
         A430ContaStatus = i430ContaStatus;
         n430ContaStatus = false;
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

      public void VarsToRow63( SdtConta obj63 )
      {
         obj63.gxTpr_Mode = Gx_mode;
         obj63.gxTpr_Contadataultimaatualizacao = A425ContaDataUltimaAtualizacao;
         obj63.gxTpr_Contasaldoatual = A423ContaSaldoAtual;
         obj63.gxTpr_Contanomeconta = A424ContaNomeConta;
         obj63.gxTpr_Contaproposta = A499ContaProposta;
         obj63.gxTpr_Contastatus = A430ContaStatus;
         obj63.gxTpr_Contaid = A422ContaId;
         obj63.gxTpr_Contaid_Z = Z422ContaId;
         obj63.gxTpr_Contasaldoatual_Z = Z423ContaSaldoAtual;
         obj63.gxTpr_Contanomeconta_Z = Z424ContaNomeConta;
         obj63.gxTpr_Contadataultimaatualizacao_Z = Z425ContaDataUltimaAtualizacao;
         obj63.gxTpr_Contastatus_Z = Z430ContaStatus;
         obj63.gxTpr_Contaproposta_Z = Z499ContaProposta;
         obj63.gxTpr_Contaid_N = (short)(Convert.ToInt16(n422ContaId));
         obj63.gxTpr_Contasaldoatual_N = (short)(Convert.ToInt16(n423ContaSaldoAtual));
         obj63.gxTpr_Contanomeconta_N = (short)(Convert.ToInt16(n424ContaNomeConta));
         obj63.gxTpr_Contadataultimaatualizacao_N = (short)(Convert.ToInt16(n425ContaDataUltimaAtualizacao));
         obj63.gxTpr_Contastatus_N = (short)(Convert.ToInt16(n430ContaStatus));
         obj63.gxTpr_Contaproposta_N = (short)(Convert.ToInt16(n499ContaProposta));
         obj63.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow63( SdtConta obj63 )
      {
         obj63.gxTpr_Contaid = A422ContaId;
         return  ;
      }

      public void RowToVars63( SdtConta obj63 ,
                               int forceLoad )
      {
         Gx_mode = obj63.gxTpr_Mode;
         A425ContaDataUltimaAtualizacao = obj63.gxTpr_Contadataultimaatualizacao;
         n425ContaDataUltimaAtualizacao = false;
         A423ContaSaldoAtual = obj63.gxTpr_Contasaldoatual;
         n423ContaSaldoAtual = false;
         A424ContaNomeConta = obj63.gxTpr_Contanomeconta;
         n424ContaNomeConta = false;
         A499ContaProposta = obj63.gxTpr_Contaproposta;
         n499ContaProposta = false;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A430ContaStatus = obj63.gxTpr_Contastatus;
            n430ContaStatus = false;
         }
         A422ContaId = obj63.gxTpr_Contaid;
         n422ContaId = false;
         Z422ContaId = obj63.gxTpr_Contaid_Z;
         Z423ContaSaldoAtual = obj63.gxTpr_Contasaldoatual_Z;
         Z424ContaNomeConta = obj63.gxTpr_Contanomeconta_Z;
         Z425ContaDataUltimaAtualizacao = obj63.gxTpr_Contadataultimaatualizacao_Z;
         Z430ContaStatus = obj63.gxTpr_Contastatus_Z;
         Z499ContaProposta = obj63.gxTpr_Contaproposta_Z;
         n422ContaId = (bool)(Convert.ToBoolean(obj63.gxTpr_Contaid_N));
         n423ContaSaldoAtual = (bool)(Convert.ToBoolean(obj63.gxTpr_Contasaldoatual_N));
         n424ContaNomeConta = (bool)(Convert.ToBoolean(obj63.gxTpr_Contanomeconta_N));
         n425ContaDataUltimaAtualizacao = (bool)(Convert.ToBoolean(obj63.gxTpr_Contadataultimaatualizacao_N));
         n430ContaStatus = (bool)(Convert.ToBoolean(obj63.gxTpr_Contastatus_N));
         n499ContaProposta = (bool)(Convert.ToBoolean(obj63.gxTpr_Contaproposta_N));
         Gx_mode = obj63.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A422ContaId = (int)getParm(obj,0);
         n422ContaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1P63( ) ;
         ScanKeyStart1P63( ) ;
         if ( RcdFound63 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z422ContaId = A422ContaId;
         }
         ZM1P63( -4) ;
         OnLoadActions1P63( ) ;
         AddRow1P63( ) ;
         ScanKeyEnd1P63( ) ;
         if ( RcdFound63 == 0 )
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
         RowToVars63( bcConta, 0) ;
         ScanKeyStart1P63( ) ;
         if ( RcdFound63 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z422ContaId = A422ContaId;
         }
         ZM1P63( -4) ;
         OnLoadActions1P63( ) ;
         AddRow1P63( ) ;
         ScanKeyEnd1P63( ) ;
         if ( RcdFound63 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1P63( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1P63( ) ;
         }
         else
         {
            if ( RcdFound63 == 1 )
            {
               if ( A422ContaId != Z422ContaId )
               {
                  A422ContaId = Z422ContaId;
                  n422ContaId = false;
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
                  Update1P63( ) ;
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
                  if ( A422ContaId != Z422ContaId )
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
                        Insert1P63( ) ;
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
                        Insert1P63( ) ;
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
         RowToVars63( bcConta, 1) ;
         SaveImpl( ) ;
         VarsToRow63( bcConta) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars63( bcConta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1P63( ) ;
         AfterTrn( ) ;
         VarsToRow63( bcConta) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow63( bcConta) ;
         }
         else
         {
            SdtConta auxBC = new SdtConta(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A422ContaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcConta);
               auxBC.Save();
               bcConta.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars63( bcConta, 1) ;
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
         RowToVars63( bcConta, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1P63( ) ;
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
               VarsToRow63( bcConta) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow63( bcConta) ;
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
         RowToVars63( bcConta, 0) ;
         GetKey1P63( ) ;
         if ( RcdFound63 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A422ContaId != Z422ContaId )
            {
               A422ContaId = Z422ContaId;
               n422ContaId = false;
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
            if ( A422ContaId != Z422ContaId )
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
         context.RollbackDataStores("conta_bc",pr_default);
         VarsToRow63( bcConta) ;
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
         Gx_mode = bcConta.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcConta.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcConta )
         {
            bcConta = (SdtConta)(sdt);
            if ( StringUtil.StrCmp(bcConta.gxTpr_Mode, "") == 0 )
            {
               bcConta.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow63( bcConta) ;
            }
            else
            {
               RowToVars63( bcConta, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcConta.gxTpr_Mode, "") == 0 )
            {
               bcConta.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars63( bcConta, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtConta Conta_BC
      {
         get {
            return bcConta ;
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
         Z425ContaDataUltimaAtualizacao = (DateTime)(DateTime.MinValue);
         A425ContaDataUltimaAtualizacao = (DateTime)(DateTime.MinValue);
         Z424ContaNomeConta = "";
         A424ContaNomeConta = "";
         BC001P4_A422ContaId = new int[1] ;
         BC001P4_n422ContaId = new bool[] {false} ;
         BC001P4_A425ContaDataUltimaAtualizacao = new DateTime[] {DateTime.MinValue} ;
         BC001P4_n425ContaDataUltimaAtualizacao = new bool[] {false} ;
         BC001P4_A423ContaSaldoAtual = new decimal[1] ;
         BC001P4_n423ContaSaldoAtual = new bool[] {false} ;
         BC001P4_A424ContaNomeConta = new string[] {""} ;
         BC001P4_n424ContaNomeConta = new bool[] {false} ;
         BC001P4_A430ContaStatus = new bool[] {false} ;
         BC001P4_n430ContaStatus = new bool[] {false} ;
         BC001P4_A499ContaProposta = new bool[] {false} ;
         BC001P4_n499ContaProposta = new bool[] {false} ;
         BC001P5_A422ContaId = new int[1] ;
         BC001P5_n422ContaId = new bool[] {false} ;
         BC001P3_A422ContaId = new int[1] ;
         BC001P3_n422ContaId = new bool[] {false} ;
         BC001P3_A425ContaDataUltimaAtualizacao = new DateTime[] {DateTime.MinValue} ;
         BC001P3_n425ContaDataUltimaAtualizacao = new bool[] {false} ;
         BC001P3_A423ContaSaldoAtual = new decimal[1] ;
         BC001P3_n423ContaSaldoAtual = new bool[] {false} ;
         BC001P3_A424ContaNomeConta = new string[] {""} ;
         BC001P3_n424ContaNomeConta = new bool[] {false} ;
         BC001P3_A430ContaStatus = new bool[] {false} ;
         BC001P3_n430ContaStatus = new bool[] {false} ;
         BC001P3_A499ContaProposta = new bool[] {false} ;
         BC001P3_n499ContaProposta = new bool[] {false} ;
         sMode63 = "";
         BC001P2_A422ContaId = new int[1] ;
         BC001P2_n422ContaId = new bool[] {false} ;
         BC001P2_A425ContaDataUltimaAtualizacao = new DateTime[] {DateTime.MinValue} ;
         BC001P2_n425ContaDataUltimaAtualizacao = new bool[] {false} ;
         BC001P2_A423ContaSaldoAtual = new decimal[1] ;
         BC001P2_n423ContaSaldoAtual = new bool[] {false} ;
         BC001P2_A424ContaNomeConta = new string[] {""} ;
         BC001P2_n424ContaNomeConta = new bool[] {false} ;
         BC001P2_A430ContaStatus = new bool[] {false} ;
         BC001P2_n430ContaStatus = new bool[] {false} ;
         BC001P2_A499ContaProposta = new bool[] {false} ;
         BC001P2_n499ContaProposta = new bool[] {false} ;
         BC001P7_A422ContaId = new int[1] ;
         BC001P7_n422ContaId = new bool[] {false} ;
         BC001P10_A270TituloMovimentoId = new int[1] ;
         BC001P11_A261TituloId = new int[1] ;
         BC001P12_A422ContaId = new int[1] ;
         BC001P12_n422ContaId = new bool[] {false} ;
         BC001P12_A425ContaDataUltimaAtualizacao = new DateTime[] {DateTime.MinValue} ;
         BC001P12_n425ContaDataUltimaAtualizacao = new bool[] {false} ;
         BC001P12_A423ContaSaldoAtual = new decimal[1] ;
         BC001P12_n423ContaSaldoAtual = new bool[] {false} ;
         BC001P12_A424ContaNomeConta = new string[] {""} ;
         BC001P12_n424ContaNomeConta = new bool[] {false} ;
         BC001P12_A430ContaStatus = new bool[] {false} ;
         BC001P12_n430ContaStatus = new bool[] {false} ;
         BC001P12_A499ContaProposta = new bool[] {false} ;
         BC001P12_n499ContaProposta = new bool[] {false} ;
         i425ContaDataUltimaAtualizacao = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conta_bc__default(),
            new Object[][] {
                new Object[] {
               BC001P2_A422ContaId, BC001P2_A425ContaDataUltimaAtualizacao, BC001P2_n425ContaDataUltimaAtualizacao, BC001P2_A423ContaSaldoAtual, BC001P2_n423ContaSaldoAtual, BC001P2_A424ContaNomeConta, BC001P2_n424ContaNomeConta, BC001P2_A430ContaStatus, BC001P2_n430ContaStatus, BC001P2_A499ContaProposta,
               BC001P2_n499ContaProposta
               }
               , new Object[] {
               BC001P3_A422ContaId, BC001P3_A425ContaDataUltimaAtualizacao, BC001P3_n425ContaDataUltimaAtualizacao, BC001P3_A423ContaSaldoAtual, BC001P3_n423ContaSaldoAtual, BC001P3_A424ContaNomeConta, BC001P3_n424ContaNomeConta, BC001P3_A430ContaStatus, BC001P3_n430ContaStatus, BC001P3_A499ContaProposta,
               BC001P3_n499ContaProposta
               }
               , new Object[] {
               BC001P4_A422ContaId, BC001P4_A425ContaDataUltimaAtualizacao, BC001P4_n425ContaDataUltimaAtualizacao, BC001P4_A423ContaSaldoAtual, BC001P4_n423ContaSaldoAtual, BC001P4_A424ContaNomeConta, BC001P4_n424ContaNomeConta, BC001P4_A430ContaStatus, BC001P4_n430ContaStatus, BC001P4_A499ContaProposta,
               BC001P4_n499ContaProposta
               }
               , new Object[] {
               BC001P5_A422ContaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001P7_A422ContaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001P10_A270TituloMovimentoId
               }
               , new Object[] {
               BC001P11_A261TituloId
               }
               , new Object[] {
               BC001P12_A422ContaId, BC001P12_A425ContaDataUltimaAtualizacao, BC001P12_n425ContaDataUltimaAtualizacao, BC001P12_A423ContaSaldoAtual, BC001P12_n423ContaSaldoAtual, BC001P12_A424ContaNomeConta, BC001P12_n424ContaNomeConta, BC001P12_A430ContaStatus, BC001P12_n430ContaStatus, BC001P12_A499ContaProposta,
               BC001P12_n499ContaProposta
               }
            }
         );
         Z430ContaStatus = true;
         n430ContaStatus = false;
         A430ContaStatus = true;
         n430ContaStatus = false;
         i430ContaStatus = true;
         n430ContaStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121P2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound63 ;
      private int trnEnded ;
      private int Z422ContaId ;
      private int A422ContaId ;
      private decimal Z423ContaSaldoAtual ;
      private decimal A423ContaSaldoAtual ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode63 ;
      private DateTime Z425ContaDataUltimaAtualizacao ;
      private DateTime A425ContaDataUltimaAtualizacao ;
      private DateTime i425ContaDataUltimaAtualizacao ;
      private bool returnInSub ;
      private bool Z430ContaStatus ;
      private bool A430ContaStatus ;
      private bool Z499ContaProposta ;
      private bool A499ContaProposta ;
      private bool n425ContaDataUltimaAtualizacao ;
      private bool n430ContaStatus ;
      private bool n422ContaId ;
      private bool n423ContaSaldoAtual ;
      private bool n424ContaNomeConta ;
      private bool n499ContaProposta ;
      private bool i430ContaStatus ;
      private string Z424ContaNomeConta ;
      private string A424ContaNomeConta ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC001P4_A422ContaId ;
      private bool[] BC001P4_n422ContaId ;
      private DateTime[] BC001P4_A425ContaDataUltimaAtualizacao ;
      private bool[] BC001P4_n425ContaDataUltimaAtualizacao ;
      private decimal[] BC001P4_A423ContaSaldoAtual ;
      private bool[] BC001P4_n423ContaSaldoAtual ;
      private string[] BC001P4_A424ContaNomeConta ;
      private bool[] BC001P4_n424ContaNomeConta ;
      private bool[] BC001P4_A430ContaStatus ;
      private bool[] BC001P4_n430ContaStatus ;
      private bool[] BC001P4_A499ContaProposta ;
      private bool[] BC001P4_n499ContaProposta ;
      private int[] BC001P5_A422ContaId ;
      private bool[] BC001P5_n422ContaId ;
      private int[] BC001P3_A422ContaId ;
      private bool[] BC001P3_n422ContaId ;
      private DateTime[] BC001P3_A425ContaDataUltimaAtualizacao ;
      private bool[] BC001P3_n425ContaDataUltimaAtualizacao ;
      private decimal[] BC001P3_A423ContaSaldoAtual ;
      private bool[] BC001P3_n423ContaSaldoAtual ;
      private string[] BC001P3_A424ContaNomeConta ;
      private bool[] BC001P3_n424ContaNomeConta ;
      private bool[] BC001P3_A430ContaStatus ;
      private bool[] BC001P3_n430ContaStatus ;
      private bool[] BC001P3_A499ContaProposta ;
      private bool[] BC001P3_n499ContaProposta ;
      private int[] BC001P2_A422ContaId ;
      private bool[] BC001P2_n422ContaId ;
      private DateTime[] BC001P2_A425ContaDataUltimaAtualizacao ;
      private bool[] BC001P2_n425ContaDataUltimaAtualizacao ;
      private decimal[] BC001P2_A423ContaSaldoAtual ;
      private bool[] BC001P2_n423ContaSaldoAtual ;
      private string[] BC001P2_A424ContaNomeConta ;
      private bool[] BC001P2_n424ContaNomeConta ;
      private bool[] BC001P2_A430ContaStatus ;
      private bool[] BC001P2_n430ContaStatus ;
      private bool[] BC001P2_A499ContaProposta ;
      private bool[] BC001P2_n499ContaProposta ;
      private int[] BC001P7_A422ContaId ;
      private bool[] BC001P7_n422ContaId ;
      private int[] BC001P10_A270TituloMovimentoId ;
      private int[] BC001P11_A261TituloId ;
      private int[] BC001P12_A422ContaId ;
      private bool[] BC001P12_n422ContaId ;
      private DateTime[] BC001P12_A425ContaDataUltimaAtualizacao ;
      private bool[] BC001P12_n425ContaDataUltimaAtualizacao ;
      private decimal[] BC001P12_A423ContaSaldoAtual ;
      private bool[] BC001P12_n423ContaSaldoAtual ;
      private string[] BC001P12_A424ContaNomeConta ;
      private bool[] BC001P12_n424ContaNomeConta ;
      private bool[] BC001P12_A430ContaStatus ;
      private bool[] BC001P12_n430ContaStatus ;
      private bool[] BC001P12_A499ContaProposta ;
      private bool[] BC001P12_n499ContaProposta ;
      private SdtConta bcConta ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class conta_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001P2;
          prmBC001P2 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001P3;
          prmBC001P3 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001P4;
          prmBC001P4 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001P5;
          prmBC001P5 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001P6;
          prmBC001P6 = new Object[] {
          new ParDef("ContaDataUltimaAtualizacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaSaldoAtual",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ContaNomeConta",GXType.VarChar,60,2){Nullable=true} ,
          new ParDef("ContaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaProposta",GXType.Boolean,4,0){Nullable=true}
          };
          Object[] prmBC001P7;
          prmBC001P7 = new Object[] {
          };
          Object[] prmBC001P8;
          prmBC001P8 = new Object[] {
          new ParDef("ContaDataUltimaAtualizacao",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaSaldoAtual",GXType.Number,18,2){Nullable=true} ,
          new ParDef("ContaNomeConta",GXType.VarChar,60,2){Nullable=true} ,
          new ParDef("ContaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaProposta",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001P9;
          prmBC001P9 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001P10;
          prmBC001P10 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001P11;
          prmBC001P11 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001P12;
          prmBC001P12 = new Object[] {
          new ParDef("ContaId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001P2", "SELECT ContaId, ContaDataUltimaAtualizacao, ContaSaldoAtual, ContaNomeConta, ContaStatus, ContaProposta FROM Conta WHERE ContaId = :ContaId  FOR UPDATE OF Conta",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001P3", "SELECT ContaId, ContaDataUltimaAtualizacao, ContaSaldoAtual, ContaNomeConta, ContaStatus, ContaProposta FROM Conta WHERE ContaId = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001P4", "SELECT TM1.ContaId, TM1.ContaDataUltimaAtualizacao, TM1.ContaSaldoAtual, TM1.ContaNomeConta, TM1.ContaStatus, TM1.ContaProposta FROM Conta TM1 WHERE TM1.ContaId = :ContaId ORDER BY TM1.ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001P5", "SELECT ContaId FROM Conta WHERE ContaId = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001P6", "SAVEPOINT gxupdate;INSERT INTO Conta(ContaDataUltimaAtualizacao, ContaSaldoAtual, ContaNomeConta, ContaStatus, ContaProposta) VALUES(:ContaDataUltimaAtualizacao, :ContaSaldoAtual, :ContaNomeConta, :ContaStatus, :ContaProposta);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001P6)
             ,new CursorDef("BC001P7", "SELECT currval('ContaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001P8", "SAVEPOINT gxupdate;UPDATE Conta SET ContaDataUltimaAtualizacao=:ContaDataUltimaAtualizacao, ContaSaldoAtual=:ContaSaldoAtual, ContaNomeConta=:ContaNomeConta, ContaStatus=:ContaStatus, ContaProposta=:ContaProposta  WHERE ContaId = :ContaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001P8)
             ,new CursorDef("BC001P9", "SAVEPOINT gxupdate;DELETE FROM Conta  WHERE ContaId = :ContaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001P9)
             ,new CursorDef("BC001P10", "SELECT TituloMovimentoId FROM TituloMovimento WHERE TituloMovimentoConta = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001P11", "SELECT TituloId FROM Titulo WHERE ContaId = :ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001P12", "SELECT TM1.ContaId, TM1.ContaDataUltimaAtualizacao, TM1.ContaSaldoAtual, TM1.ContaNomeConta, TM1.ContaStatus, TM1.ContaProposta FROM Conta TM1 WHERE TM1.ContaId = :ContaId ORDER BY TM1.ContaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001P12,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
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
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
