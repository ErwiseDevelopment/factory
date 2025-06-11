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
   public class limiteaprovacao_bc : GxSilentTrn, IGxSilentTrn
   {
      public limiteaprovacao_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public limiteaprovacao_bc( IGxContext context )
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
         ReadRow1B50( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1B50( ) ;
         standaloneModal( ) ;
         AddRow1B50( ) ;
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
            E111B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z331LimiteAprovacaoId = A331LimiteAprovacaoId;
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

      protected void CONFIRM_1B0( )
      {
         BeforeValidate1B50( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1B50( ) ;
            }
            else
            {
               CheckExtendedTable1B50( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1B50( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E111B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1B50( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z332LimiteAprovacaoValorMinimo = A332LimiteAprovacaoValorMinimo;
            Z334LimiteAprovacaoAprovacoes = A334LimiteAprovacaoAprovacoes;
            Z344LimiteAprovacaoReprovacoesPermitidas = A344LimiteAprovacaoReprovacoesPermitidas;
         }
         if ( GX_JID == -4 )
         {
            Z331LimiteAprovacaoId = A331LimiteAprovacaoId;
            Z332LimiteAprovacaoValorMinimo = A332LimiteAprovacaoValorMinimo;
            Z334LimiteAprovacaoAprovacoes = A334LimiteAprovacaoAprovacoes;
            Z344LimiteAprovacaoReprovacoesPermitidas = A344LimiteAprovacaoReprovacoesPermitidas;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1B50( )
      {
         /* Using cursor BC001B4 */
         pr_default.execute(2, new Object[] {A331LimiteAprovacaoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound50 = 1;
            A332LimiteAprovacaoValorMinimo = BC001B4_A332LimiteAprovacaoValorMinimo[0];
            n332LimiteAprovacaoValorMinimo = BC001B4_n332LimiteAprovacaoValorMinimo[0];
            A334LimiteAprovacaoAprovacoes = BC001B4_A334LimiteAprovacaoAprovacoes[0];
            n334LimiteAprovacaoAprovacoes = BC001B4_n334LimiteAprovacaoAprovacoes[0];
            A344LimiteAprovacaoReprovacoesPermitidas = BC001B4_A344LimiteAprovacaoReprovacoesPermitidas[0];
            ZM1B50( -4) ;
         }
         pr_default.close(2);
         OnLoadActions1B50( ) ;
      }

      protected void OnLoadActions1B50( )
      {
      }

      protected void CheckExtendedTable1B50( )
      {
         standaloneModal( ) ;
         if ( (Convert.ToDecimal(0)==A332LimiteAprovacaoValorMinimo) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Limite Aprovacao Valor Minimo", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ( A332LimiteAprovacaoValorMinimo < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( (0==A334LimiteAprovacaoAprovacoes) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Limite Aprovacao Aprovacoes", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1B50( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1B50( )
      {
         /* Using cursor BC001B5 */
         pr_default.execute(3, new Object[] {A331LimiteAprovacaoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound50 = 1;
         }
         else
         {
            RcdFound50 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001B3 */
         pr_default.execute(1, new Object[] {A331LimiteAprovacaoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1B50( 4) ;
            RcdFound50 = 1;
            A331LimiteAprovacaoId = BC001B3_A331LimiteAprovacaoId[0];
            A332LimiteAprovacaoValorMinimo = BC001B3_A332LimiteAprovacaoValorMinimo[0];
            n332LimiteAprovacaoValorMinimo = BC001B3_n332LimiteAprovacaoValorMinimo[0];
            A334LimiteAprovacaoAprovacoes = BC001B3_A334LimiteAprovacaoAprovacoes[0];
            n334LimiteAprovacaoAprovacoes = BC001B3_n334LimiteAprovacaoAprovacoes[0];
            A344LimiteAprovacaoReprovacoesPermitidas = BC001B3_A344LimiteAprovacaoReprovacoesPermitidas[0];
            Z331LimiteAprovacaoId = A331LimiteAprovacaoId;
            sMode50 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1B50( ) ;
            if ( AnyError == 1 )
            {
               RcdFound50 = 0;
               InitializeNonKey1B50( ) ;
            }
            Gx_mode = sMode50;
         }
         else
         {
            RcdFound50 = 0;
            InitializeNonKey1B50( ) ;
            sMode50 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode50;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1B50( ) ;
         if ( RcdFound50 == 0 )
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
         CONFIRM_1B0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1B50( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001B2 */
            pr_default.execute(0, new Object[] {A331LimiteAprovacaoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LimiteAprovacao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z332LimiteAprovacaoValorMinimo != BC001B2_A332LimiteAprovacaoValorMinimo[0] ) || ( Z334LimiteAprovacaoAprovacoes != BC001B2_A334LimiteAprovacaoAprovacoes[0] ) || ( Z344LimiteAprovacaoReprovacoesPermitidas != BC001B2_A344LimiteAprovacaoReprovacoesPermitidas[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LimiteAprovacao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1B50( )
      {
         BeforeValidate1B50( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B50( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1B50( 0) ;
            CheckOptimisticConcurrency1B50( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B50( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1B50( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001B6 */
                     pr_default.execute(4, new Object[] {n332LimiteAprovacaoValorMinimo, A332LimiteAprovacaoValorMinimo, n334LimiteAprovacaoAprovacoes, A334LimiteAprovacaoAprovacoes, A344LimiteAprovacaoReprovacoesPermitidas});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001B7 */
                     pr_default.execute(5);
                     A331LimiteAprovacaoId = BC001B7_A331LimiteAprovacaoId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("LimiteAprovacao");
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
               Load1B50( ) ;
            }
            EndLevel1B50( ) ;
         }
         CloseExtendedTableCursors1B50( ) ;
      }

      protected void Update1B50( )
      {
         BeforeValidate1B50( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1B50( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B50( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1B50( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1B50( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001B8 */
                     pr_default.execute(6, new Object[] {n332LimiteAprovacaoValorMinimo, A332LimiteAprovacaoValorMinimo, n334LimiteAprovacaoAprovacoes, A334LimiteAprovacaoAprovacoes, A344LimiteAprovacaoReprovacoesPermitidas, A331LimiteAprovacaoId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("LimiteAprovacao");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LimiteAprovacao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1B50( ) ;
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
            EndLevel1B50( ) ;
         }
         CloseExtendedTableCursors1B50( ) ;
      }

      protected void DeferredUpdate1B50( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1B50( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1B50( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1B50( ) ;
            AfterConfirm1B50( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1B50( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001B9 */
                  pr_default.execute(7, new Object[] {A331LimiteAprovacaoId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("LimiteAprovacao");
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
         sMode50 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1B50( ) ;
         Gx_mode = sMode50;
      }

      protected void OnDeleteControls1B50( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1B50( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1B50( ) ;
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

      public void ScanKeyStart1B50( )
      {
         /* Scan By routine */
         /* Using cursor BC001B10 */
         pr_default.execute(8, new Object[] {A331LimiteAprovacaoId});
         RcdFound50 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound50 = 1;
            A331LimiteAprovacaoId = BC001B10_A331LimiteAprovacaoId[0];
            A332LimiteAprovacaoValorMinimo = BC001B10_A332LimiteAprovacaoValorMinimo[0];
            n332LimiteAprovacaoValorMinimo = BC001B10_n332LimiteAprovacaoValorMinimo[0];
            A334LimiteAprovacaoAprovacoes = BC001B10_A334LimiteAprovacaoAprovacoes[0];
            n334LimiteAprovacaoAprovacoes = BC001B10_n334LimiteAprovacaoAprovacoes[0];
            A344LimiteAprovacaoReprovacoesPermitidas = BC001B10_A344LimiteAprovacaoReprovacoesPermitidas[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1B50( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound50 = 0;
         ScanKeyLoad1B50( ) ;
      }

      protected void ScanKeyLoad1B50( )
      {
         sMode50 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound50 = 1;
            A331LimiteAprovacaoId = BC001B10_A331LimiteAprovacaoId[0];
            A332LimiteAprovacaoValorMinimo = BC001B10_A332LimiteAprovacaoValorMinimo[0];
            n332LimiteAprovacaoValorMinimo = BC001B10_n332LimiteAprovacaoValorMinimo[0];
            A334LimiteAprovacaoAprovacoes = BC001B10_A334LimiteAprovacaoAprovacoes[0];
            n334LimiteAprovacaoAprovacoes = BC001B10_n334LimiteAprovacaoAprovacoes[0];
            A344LimiteAprovacaoReprovacoesPermitidas = BC001B10_A344LimiteAprovacaoReprovacoesPermitidas[0];
         }
         Gx_mode = sMode50;
      }

      protected void ScanKeyEnd1B50( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1B50( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1B50( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1B50( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1B50( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1B50( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1B50( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1B50( )
      {
      }

      protected void send_integrity_lvl_hashes1B50( )
      {
      }

      protected void AddRow1B50( )
      {
         VarsToRow50( bcLimiteAprovacao) ;
      }

      protected void ReadRow1B50( )
      {
         RowToVars50( bcLimiteAprovacao, 1) ;
      }

      protected void InitializeNonKey1B50( )
      {
         A332LimiteAprovacaoValorMinimo = 0;
         n332LimiteAprovacaoValorMinimo = false;
         A334LimiteAprovacaoAprovacoes = 0;
         n334LimiteAprovacaoAprovacoes = false;
         A344LimiteAprovacaoReprovacoesPermitidas = 0;
         Z332LimiteAprovacaoValorMinimo = 0;
         Z334LimiteAprovacaoAprovacoes = 0;
         Z344LimiteAprovacaoReprovacoesPermitidas = 0;
      }

      protected void InitAll1B50( )
      {
         A331LimiteAprovacaoId = 0;
         InitializeNonKey1B50( ) ;
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

      public void VarsToRow50( SdtLimiteAprovacao obj50 )
      {
         obj50.gxTpr_Mode = Gx_mode;
         obj50.gxTpr_Limiteaprovacaovalorminimo = A332LimiteAprovacaoValorMinimo;
         obj50.gxTpr_Limiteaprovacaoaprovacoes = A334LimiteAprovacaoAprovacoes;
         obj50.gxTpr_Limiteaprovacaoreprovacoespermitidas = A344LimiteAprovacaoReprovacoesPermitidas;
         obj50.gxTpr_Limiteaprovacaoid = A331LimiteAprovacaoId;
         obj50.gxTpr_Limiteaprovacaoid_Z = Z331LimiteAprovacaoId;
         obj50.gxTpr_Limiteaprovacaovalorminimo_Z = Z332LimiteAprovacaoValorMinimo;
         obj50.gxTpr_Limiteaprovacaoaprovacoes_Z = Z334LimiteAprovacaoAprovacoes;
         obj50.gxTpr_Limiteaprovacaoreprovacoespermitidas_Z = Z344LimiteAprovacaoReprovacoesPermitidas;
         obj50.gxTpr_Limiteaprovacaovalorminimo_N = (short)(Convert.ToInt16(n332LimiteAprovacaoValorMinimo));
         obj50.gxTpr_Limiteaprovacaoaprovacoes_N = (short)(Convert.ToInt16(n334LimiteAprovacaoAprovacoes));
         obj50.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow50( SdtLimiteAprovacao obj50 )
      {
         obj50.gxTpr_Limiteaprovacaoid = A331LimiteAprovacaoId;
         return  ;
      }

      public void RowToVars50( SdtLimiteAprovacao obj50 ,
                               int forceLoad )
      {
         Gx_mode = obj50.gxTpr_Mode;
         A332LimiteAprovacaoValorMinimo = obj50.gxTpr_Limiteaprovacaovalorminimo;
         n332LimiteAprovacaoValorMinimo = false;
         A334LimiteAprovacaoAprovacoes = obj50.gxTpr_Limiteaprovacaoaprovacoes;
         n334LimiteAprovacaoAprovacoes = false;
         A344LimiteAprovacaoReprovacoesPermitidas = obj50.gxTpr_Limiteaprovacaoreprovacoespermitidas;
         A331LimiteAprovacaoId = obj50.gxTpr_Limiteaprovacaoid;
         Z331LimiteAprovacaoId = obj50.gxTpr_Limiteaprovacaoid_Z;
         Z332LimiteAprovacaoValorMinimo = obj50.gxTpr_Limiteaprovacaovalorminimo_Z;
         Z334LimiteAprovacaoAprovacoes = obj50.gxTpr_Limiteaprovacaoaprovacoes_Z;
         Z344LimiteAprovacaoReprovacoesPermitidas = obj50.gxTpr_Limiteaprovacaoreprovacoespermitidas_Z;
         n332LimiteAprovacaoValorMinimo = (bool)(Convert.ToBoolean(obj50.gxTpr_Limiteaprovacaovalorminimo_N));
         n334LimiteAprovacaoAprovacoes = (bool)(Convert.ToBoolean(obj50.gxTpr_Limiteaprovacaoaprovacoes_N));
         Gx_mode = obj50.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A331LimiteAprovacaoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1B50( ) ;
         ScanKeyStart1B50( ) ;
         if ( RcdFound50 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z331LimiteAprovacaoId = A331LimiteAprovacaoId;
         }
         ZM1B50( -4) ;
         OnLoadActions1B50( ) ;
         AddRow1B50( ) ;
         ScanKeyEnd1B50( ) ;
         if ( RcdFound50 == 0 )
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
         RowToVars50( bcLimiteAprovacao, 0) ;
         ScanKeyStart1B50( ) ;
         if ( RcdFound50 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z331LimiteAprovacaoId = A331LimiteAprovacaoId;
         }
         ZM1B50( -4) ;
         OnLoadActions1B50( ) ;
         AddRow1B50( ) ;
         ScanKeyEnd1B50( ) ;
         if ( RcdFound50 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1B50( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1B50( ) ;
         }
         else
         {
            if ( RcdFound50 == 1 )
            {
               if ( A331LimiteAprovacaoId != Z331LimiteAprovacaoId )
               {
                  A331LimiteAprovacaoId = Z331LimiteAprovacaoId;
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
                  Update1B50( ) ;
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
                  if ( A331LimiteAprovacaoId != Z331LimiteAprovacaoId )
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
                        Insert1B50( ) ;
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
                        Insert1B50( ) ;
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
         RowToVars50( bcLimiteAprovacao, 1) ;
         SaveImpl( ) ;
         VarsToRow50( bcLimiteAprovacao) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars50( bcLimiteAprovacao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1B50( ) ;
         AfterTrn( ) ;
         VarsToRow50( bcLimiteAprovacao) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow50( bcLimiteAprovacao) ;
         }
         else
         {
            SdtLimiteAprovacao auxBC = new SdtLimiteAprovacao(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A331LimiteAprovacaoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcLimiteAprovacao);
               auxBC.Save();
               bcLimiteAprovacao.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars50( bcLimiteAprovacao, 1) ;
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
         RowToVars50( bcLimiteAprovacao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1B50( ) ;
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
               VarsToRow50( bcLimiteAprovacao) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow50( bcLimiteAprovacao) ;
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
         RowToVars50( bcLimiteAprovacao, 0) ;
         GetKey1B50( ) ;
         if ( RcdFound50 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A331LimiteAprovacaoId != Z331LimiteAprovacaoId )
            {
               A331LimiteAprovacaoId = Z331LimiteAprovacaoId;
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
            if ( A331LimiteAprovacaoId != Z331LimiteAprovacaoId )
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
         context.RollbackDataStores("limiteaprovacao_bc",pr_default);
         VarsToRow50( bcLimiteAprovacao) ;
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
         Gx_mode = bcLimiteAprovacao.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcLimiteAprovacao.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcLimiteAprovacao )
         {
            bcLimiteAprovacao = (SdtLimiteAprovacao)(sdt);
            if ( StringUtil.StrCmp(bcLimiteAprovacao.gxTpr_Mode, "") == 0 )
            {
               bcLimiteAprovacao.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow50( bcLimiteAprovacao) ;
            }
            else
            {
               RowToVars50( bcLimiteAprovacao, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcLimiteAprovacao.gxTpr_Mode, "") == 0 )
            {
               bcLimiteAprovacao.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars50( bcLimiteAprovacao, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtLimiteAprovacao LimiteAprovacao_BC
      {
         get {
            return bcLimiteAprovacao ;
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
         BC001B4_A331LimiteAprovacaoId = new int[1] ;
         BC001B4_A332LimiteAprovacaoValorMinimo = new decimal[1] ;
         BC001B4_n332LimiteAprovacaoValorMinimo = new bool[] {false} ;
         BC001B4_A334LimiteAprovacaoAprovacoes = new short[1] ;
         BC001B4_n334LimiteAprovacaoAprovacoes = new bool[] {false} ;
         BC001B4_A344LimiteAprovacaoReprovacoesPermitidas = new short[1] ;
         BC001B5_A331LimiteAprovacaoId = new int[1] ;
         BC001B3_A331LimiteAprovacaoId = new int[1] ;
         BC001B3_A332LimiteAprovacaoValorMinimo = new decimal[1] ;
         BC001B3_n332LimiteAprovacaoValorMinimo = new bool[] {false} ;
         BC001B3_A334LimiteAprovacaoAprovacoes = new short[1] ;
         BC001B3_n334LimiteAprovacaoAprovacoes = new bool[] {false} ;
         BC001B3_A344LimiteAprovacaoReprovacoesPermitidas = new short[1] ;
         sMode50 = "";
         BC001B2_A331LimiteAprovacaoId = new int[1] ;
         BC001B2_A332LimiteAprovacaoValorMinimo = new decimal[1] ;
         BC001B2_n332LimiteAprovacaoValorMinimo = new bool[] {false} ;
         BC001B2_A334LimiteAprovacaoAprovacoes = new short[1] ;
         BC001B2_n334LimiteAprovacaoAprovacoes = new bool[] {false} ;
         BC001B2_A344LimiteAprovacaoReprovacoesPermitidas = new short[1] ;
         BC001B7_A331LimiteAprovacaoId = new int[1] ;
         BC001B10_A331LimiteAprovacaoId = new int[1] ;
         BC001B10_A332LimiteAprovacaoValorMinimo = new decimal[1] ;
         BC001B10_n332LimiteAprovacaoValorMinimo = new bool[] {false} ;
         BC001B10_A334LimiteAprovacaoAprovacoes = new short[1] ;
         BC001B10_n334LimiteAprovacaoAprovacoes = new bool[] {false} ;
         BC001B10_A344LimiteAprovacaoReprovacoesPermitidas = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.limiteaprovacao_bc__default(),
            new Object[][] {
                new Object[] {
               BC001B2_A331LimiteAprovacaoId, BC001B2_A332LimiteAprovacaoValorMinimo, BC001B2_n332LimiteAprovacaoValorMinimo, BC001B2_A334LimiteAprovacaoAprovacoes, BC001B2_n334LimiteAprovacaoAprovacoes, BC001B2_A344LimiteAprovacaoReprovacoesPermitidas
               }
               , new Object[] {
               BC001B3_A331LimiteAprovacaoId, BC001B3_A332LimiteAprovacaoValorMinimo, BC001B3_n332LimiteAprovacaoValorMinimo, BC001B3_A334LimiteAprovacaoAprovacoes, BC001B3_n334LimiteAprovacaoAprovacoes, BC001B3_A344LimiteAprovacaoReprovacoesPermitidas
               }
               , new Object[] {
               BC001B4_A331LimiteAprovacaoId, BC001B4_A332LimiteAprovacaoValorMinimo, BC001B4_n332LimiteAprovacaoValorMinimo, BC001B4_A334LimiteAprovacaoAprovacoes, BC001B4_n334LimiteAprovacaoAprovacoes, BC001B4_A344LimiteAprovacaoReprovacoesPermitidas
               }
               , new Object[] {
               BC001B5_A331LimiteAprovacaoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001B7_A331LimiteAprovacaoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001B10_A331LimiteAprovacaoId, BC001B10_A332LimiteAprovacaoValorMinimo, BC001B10_n332LimiteAprovacaoValorMinimo, BC001B10_A334LimiteAprovacaoAprovacoes, BC001B10_n334LimiteAprovacaoAprovacoes, BC001B10_A344LimiteAprovacaoReprovacoesPermitidas
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121B2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z334LimiteAprovacaoAprovacoes ;
      private short A334LimiteAprovacaoAprovacoes ;
      private short Z344LimiteAprovacaoReprovacoesPermitidas ;
      private short A344LimiteAprovacaoReprovacoesPermitidas ;
      private short RcdFound50 ;
      private int trnEnded ;
      private int Z331LimiteAprovacaoId ;
      private int A331LimiteAprovacaoId ;
      private decimal Z332LimiteAprovacaoValorMinimo ;
      private decimal A332LimiteAprovacaoValorMinimo ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode50 ;
      private bool returnInSub ;
      private bool n332LimiteAprovacaoValorMinimo ;
      private bool n334LimiteAprovacaoAprovacoes ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC001B4_A331LimiteAprovacaoId ;
      private decimal[] BC001B4_A332LimiteAprovacaoValorMinimo ;
      private bool[] BC001B4_n332LimiteAprovacaoValorMinimo ;
      private short[] BC001B4_A334LimiteAprovacaoAprovacoes ;
      private bool[] BC001B4_n334LimiteAprovacaoAprovacoes ;
      private short[] BC001B4_A344LimiteAprovacaoReprovacoesPermitidas ;
      private int[] BC001B5_A331LimiteAprovacaoId ;
      private int[] BC001B3_A331LimiteAprovacaoId ;
      private decimal[] BC001B3_A332LimiteAprovacaoValorMinimo ;
      private bool[] BC001B3_n332LimiteAprovacaoValorMinimo ;
      private short[] BC001B3_A334LimiteAprovacaoAprovacoes ;
      private bool[] BC001B3_n334LimiteAprovacaoAprovacoes ;
      private short[] BC001B3_A344LimiteAprovacaoReprovacoesPermitidas ;
      private int[] BC001B2_A331LimiteAprovacaoId ;
      private decimal[] BC001B2_A332LimiteAprovacaoValorMinimo ;
      private bool[] BC001B2_n332LimiteAprovacaoValorMinimo ;
      private short[] BC001B2_A334LimiteAprovacaoAprovacoes ;
      private bool[] BC001B2_n334LimiteAprovacaoAprovacoes ;
      private short[] BC001B2_A344LimiteAprovacaoReprovacoesPermitidas ;
      private int[] BC001B7_A331LimiteAprovacaoId ;
      private int[] BC001B10_A331LimiteAprovacaoId ;
      private decimal[] BC001B10_A332LimiteAprovacaoValorMinimo ;
      private bool[] BC001B10_n332LimiteAprovacaoValorMinimo ;
      private short[] BC001B10_A334LimiteAprovacaoAprovacoes ;
      private bool[] BC001B10_n334LimiteAprovacaoAprovacoes ;
      private short[] BC001B10_A344LimiteAprovacaoReprovacoesPermitidas ;
      private SdtLimiteAprovacao bcLimiteAprovacao ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class limiteaprovacao_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC001B2;
          prmBC001B2 = new Object[] {
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001B3;
          prmBC001B3 = new Object[] {
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001B4;
          prmBC001B4 = new Object[] {
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001B5;
          prmBC001B5 = new Object[] {
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001B6;
          prmBC001B6 = new Object[] {
          new ParDef("LimiteAprovacaoValorMinimo",GXType.Number,18,2){Nullable=true} ,
          new ParDef("LimiteAprovacaoAprovacoes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("LimiteAprovacaoReprovacoesPermitidas",GXType.Int16,4,0)
          };
          Object[] prmBC001B7;
          prmBC001B7 = new Object[] {
          };
          Object[] prmBC001B8;
          prmBC001B8 = new Object[] {
          new ParDef("LimiteAprovacaoValorMinimo",GXType.Number,18,2){Nullable=true} ,
          new ParDef("LimiteAprovacaoAprovacoes",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("LimiteAprovacaoReprovacoesPermitidas",GXType.Int16,4,0) ,
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001B9;
          prmBC001B9 = new Object[] {
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          Object[] prmBC001B10;
          prmBC001B10 = new Object[] {
          new ParDef("LimiteAprovacaoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC001B2", "SELECT LimiteAprovacaoId, LimiteAprovacaoValorMinimo, LimiteAprovacaoAprovacoes, LimiteAprovacaoReprovacoesPermitidas FROM LimiteAprovacao WHERE LimiteAprovacaoId = :LimiteAprovacaoId  FOR UPDATE OF LimiteAprovacao",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001B3", "SELECT LimiteAprovacaoId, LimiteAprovacaoValorMinimo, LimiteAprovacaoAprovacoes, LimiteAprovacaoReprovacoesPermitidas FROM LimiteAprovacao WHERE LimiteAprovacaoId = :LimiteAprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001B4", "SELECT TM1.LimiteAprovacaoId, TM1.LimiteAprovacaoValorMinimo, TM1.LimiteAprovacaoAprovacoes, TM1.LimiteAprovacaoReprovacoesPermitidas FROM LimiteAprovacao TM1 WHERE TM1.LimiteAprovacaoId = :LimiteAprovacaoId ORDER BY TM1.LimiteAprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001B5", "SELECT LimiteAprovacaoId FROM LimiteAprovacao WHERE LimiteAprovacaoId = :LimiteAprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001B6", "SAVEPOINT gxupdate;INSERT INTO LimiteAprovacao(LimiteAprovacaoValorMinimo, LimiteAprovacaoAprovacoes, LimiteAprovacaoReprovacoesPermitidas) VALUES(:LimiteAprovacaoValorMinimo, :LimiteAprovacaoAprovacoes, :LimiteAprovacaoReprovacoesPermitidas);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001B6)
             ,new CursorDef("BC001B7", "SELECT currval('LimiteAprovacaoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001B8", "SAVEPOINT gxupdate;UPDATE LimiteAprovacao SET LimiteAprovacaoValorMinimo=:LimiteAprovacaoValorMinimo, LimiteAprovacaoAprovacoes=:LimiteAprovacaoAprovacoes, LimiteAprovacaoReprovacoesPermitidas=:LimiteAprovacaoReprovacoesPermitidas  WHERE LimiteAprovacaoId = :LimiteAprovacaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001B8)
             ,new CursorDef("BC001B9", "SAVEPOINT gxupdate;DELETE FROM LimiteAprovacao  WHERE LimiteAprovacaoId = :LimiteAprovacaoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001B9)
             ,new CursorDef("BC001B10", "SELECT TM1.LimiteAprovacaoId, TM1.LimiteAprovacaoValorMinimo, TM1.LimiteAprovacaoAprovacoes, TM1.LimiteAprovacaoReprovacoesPermitidas FROM LimiteAprovacao TM1 WHERE TM1.LimiteAprovacaoId = :LimiteAprovacaoId ORDER BY TM1.LimiteAprovacaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001B10,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((short[]) buf[5])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
