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
   public class financiamento_bc : GxSilentTrn, IGxSilentTrn
   {
      public financiamento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public financiamento_bc( IGxContext context )
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
         ReadRow0W35( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0W35( ) ;
         standaloneModal( ) ;
         AddRow0W35( ) ;
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
            E110W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z223FinanciamentoId = A223FinanciamentoId;
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

      protected void CONFIRM_0W0( )
      {
         BeforeValidate0W35( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0W35( ) ;
            }
            else
            {
               CheckExtendedTable0W35( ) ;
               if ( AnyError == 0 )
               {
                  ZM0W35( 6) ;
                  ZM0W35( 7) ;
               }
               CloseExtendedTableCursors0W35( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            while ( AV24GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV11Insert_ClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "IntermediadorClienteId") == 0 )
               {
                  AV12Insert_IntermediadorClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV24GXV1 = (int)(AV24GXV1+1);
            }
         }
      }

      protected void E110W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0W35( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z224FinanciamentoValor = A224FinanciamentoValor;
            Z225FinanciamentoStatus = A225FinanciamentoStatus;
            Z168ClienteId = A168ClienteId;
            Z220IntermediadorClienteId = A220IntermediadorClienteId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
            Z169ClienteDocumento = A169ClienteDocumento;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z221IntermediadorClienteRazaoSocial = A221IntermediadorClienteRazaoSocial;
            Z222IntermediadorClienteDocumento = A222IntermediadorClienteDocumento;
         }
         if ( GX_JID == -5 )
         {
            Z223FinanciamentoId = A223FinanciamentoId;
            Z224FinanciamentoValor = A224FinanciamentoValor;
            Z225FinanciamentoStatus = A225FinanciamentoStatus;
            Z168ClienteId = A168ClienteId;
            Z220IntermediadorClienteId = A220IntermediadorClienteId;
            Z170ClienteRazaoSocial = A170ClienteRazaoSocial;
            Z169ClienteDocumento = A169ClienteDocumento;
            Z221IntermediadorClienteRazaoSocial = A221IntermediadorClienteRazaoSocial;
            Z222IntermediadorClienteDocumento = A222IntermediadorClienteDocumento;
         }
      }

      protected void standaloneNotModal( )
      {
         AV23Pgmname = "Financiamento_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0W35( )
      {
         /* Using cursor BC000W6 */
         pr_default.execute(4, new Object[] {A223FinanciamentoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound35 = 1;
            A170ClienteRazaoSocial = BC000W6_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC000W6_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = BC000W6_A169ClienteDocumento[0];
            n169ClienteDocumento = BC000W6_n169ClienteDocumento[0];
            A224FinanciamentoValor = BC000W6_A224FinanciamentoValor[0];
            n224FinanciamentoValor = BC000W6_n224FinanciamentoValor[0];
            A225FinanciamentoStatus = BC000W6_A225FinanciamentoStatus[0];
            n225FinanciamentoStatus = BC000W6_n225FinanciamentoStatus[0];
            A221IntermediadorClienteRazaoSocial = BC000W6_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = BC000W6_n221IntermediadorClienteRazaoSocial[0];
            A222IntermediadorClienteDocumento = BC000W6_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = BC000W6_n222IntermediadorClienteDocumento[0];
            A168ClienteId = BC000W6_A168ClienteId[0];
            n168ClienteId = BC000W6_n168ClienteId[0];
            A220IntermediadorClienteId = BC000W6_A220IntermediadorClienteId[0];
            n220IntermediadorClienteId = BC000W6_n220IntermediadorClienteId[0];
            ZM0W35( -5) ;
         }
         pr_default.close(4);
         OnLoadActions0W35( ) ;
      }

      protected void OnLoadActions0W35( )
      {
      }

      protected void CheckExtendedTable0W35( )
      {
         standaloneModal( ) ;
         /* Using cursor BC000W4 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
            }
         }
         A170ClienteRazaoSocial = BC000W4_A170ClienteRazaoSocial[0];
         n170ClienteRazaoSocial = BC000W4_n170ClienteRazaoSocial[0];
         A169ClienteDocumento = BC000W4_A169ClienteDocumento[0];
         n169ClienteDocumento = BC000W4_n169ClienteDocumento[0];
         pr_default.close(2);
         if ( ( A224FinanciamentoValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A225FinanciamentoStatus, "EM_ANALISE") == 0 ) || ( StringUtil.StrCmp(A225FinanciamentoStatus, "REPROVADO") == 0 ) || ( StringUtil.StrCmp(A225FinanciamentoStatus, "APROVADO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A225FinanciamentoStatus)) ) )
         {
            GX_msglist.addItem("Campo Financiamento Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000W5 */
         pr_default.execute(3, new Object[] {n220IntermediadorClienteId, A220IntermediadorClienteId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A220IntermediadorClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'SBFin Cli Int'.", "ForeignKeyNotFound", 1, "INTERMEDIADORCLIENTEID");
               AnyError = 1;
            }
         }
         A221IntermediadorClienteRazaoSocial = BC000W5_A221IntermediadorClienteRazaoSocial[0];
         n221IntermediadorClienteRazaoSocial = BC000W5_n221IntermediadorClienteRazaoSocial[0];
         A222IntermediadorClienteDocumento = BC000W5_A222IntermediadorClienteDocumento[0];
         n222IntermediadorClienteDocumento = BC000W5_n222IntermediadorClienteDocumento[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0W35( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0W35( )
      {
         /* Using cursor BC000W7 */
         pr_default.execute(5, new Object[] {A223FinanciamentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound35 = 1;
         }
         else
         {
            RcdFound35 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000W3 */
         pr_default.execute(1, new Object[] {A223FinanciamentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0W35( 5) ;
            RcdFound35 = 1;
            A223FinanciamentoId = BC000W3_A223FinanciamentoId[0];
            A224FinanciamentoValor = BC000W3_A224FinanciamentoValor[0];
            n224FinanciamentoValor = BC000W3_n224FinanciamentoValor[0];
            A225FinanciamentoStatus = BC000W3_A225FinanciamentoStatus[0];
            n225FinanciamentoStatus = BC000W3_n225FinanciamentoStatus[0];
            A168ClienteId = BC000W3_A168ClienteId[0];
            n168ClienteId = BC000W3_n168ClienteId[0];
            A220IntermediadorClienteId = BC000W3_A220IntermediadorClienteId[0];
            n220IntermediadorClienteId = BC000W3_n220IntermediadorClienteId[0];
            Z223FinanciamentoId = A223FinanciamentoId;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0W35( ) ;
            if ( AnyError == 1 )
            {
               RcdFound35 = 0;
               InitializeNonKey0W35( ) ;
            }
            Gx_mode = sMode35;
         }
         else
         {
            RcdFound35 = 0;
            InitializeNonKey0W35( ) ;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode35;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0W35( ) ;
         if ( RcdFound35 == 0 )
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
         CONFIRM_0W0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0W35( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000W2 */
            pr_default.execute(0, new Object[] {A223FinanciamentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Financiamento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z224FinanciamentoValor != BC000W2_A224FinanciamentoValor[0] ) || ( StringUtil.StrCmp(Z225FinanciamentoStatus, BC000W2_A225FinanciamentoStatus[0]) != 0 ) || ( Z168ClienteId != BC000W2_A168ClienteId[0] ) || ( Z220IntermediadorClienteId != BC000W2_A220IntermediadorClienteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Financiamento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0W35( )
      {
         BeforeValidate0W35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W35( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0W35( 0) ;
            CheckOptimisticConcurrency0W35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0W35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W8 */
                     pr_default.execute(6, new Object[] {n224FinanciamentoValor, A224FinanciamentoValor, n225FinanciamentoStatus, A225FinanciamentoStatus, n168ClienteId, A168ClienteId, n220IntermediadorClienteId, A220IntermediadorClienteId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000W9 */
                     pr_default.execute(7);
                     A223FinanciamentoId = BC000W9_A223FinanciamentoId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Financiamento");
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
               Load0W35( ) ;
            }
            EndLevel0W35( ) ;
         }
         CloseExtendedTableCursors0W35( ) ;
      }

      protected void Update0W35( )
      {
         BeforeValidate0W35( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0W35( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W35( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0W35( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0W35( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000W10 */
                     pr_default.execute(8, new Object[] {n224FinanciamentoValor, A224FinanciamentoValor, n225FinanciamentoStatus, A225FinanciamentoStatus, n168ClienteId, A168ClienteId, n220IntermediadorClienteId, A220IntermediadorClienteId, A223FinanciamentoId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Financiamento");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Financiamento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0W35( ) ;
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
            EndLevel0W35( ) ;
         }
         CloseExtendedTableCursors0W35( ) ;
      }

      protected void DeferredUpdate0W35( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0W35( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0W35( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0W35( ) ;
            AfterConfirm0W35( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0W35( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000W11 */
                  pr_default.execute(9, new Object[] {A223FinanciamentoId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Financiamento");
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
         sMode35 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0W35( ) ;
         Gx_mode = sMode35;
      }

      protected void OnDeleteControls0W35( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000W12 */
            pr_default.execute(10, new Object[] {n168ClienteId, A168ClienteId});
            A170ClienteRazaoSocial = BC000W12_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC000W12_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = BC000W12_A169ClienteDocumento[0];
            n169ClienteDocumento = BC000W12_n169ClienteDocumento[0];
            pr_default.close(10);
            /* Using cursor BC000W13 */
            pr_default.execute(11, new Object[] {n220IntermediadorClienteId, A220IntermediadorClienteId});
            A221IntermediadorClienteRazaoSocial = BC000W13_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = BC000W13_n221IntermediadorClienteRazaoSocial[0];
            A222IntermediadorClienteDocumento = BC000W13_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = BC000W13_n222IntermediadorClienteDocumento[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel0W35( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0W35( ) ;
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

      public void ScanKeyStart0W35( )
      {
         /* Scan By routine */
         /* Using cursor BC000W14 */
         pr_default.execute(12, new Object[] {A223FinanciamentoId});
         RcdFound35 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound35 = 1;
            A223FinanciamentoId = BC000W14_A223FinanciamentoId[0];
            A170ClienteRazaoSocial = BC000W14_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC000W14_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = BC000W14_A169ClienteDocumento[0];
            n169ClienteDocumento = BC000W14_n169ClienteDocumento[0];
            A224FinanciamentoValor = BC000W14_A224FinanciamentoValor[0];
            n224FinanciamentoValor = BC000W14_n224FinanciamentoValor[0];
            A225FinanciamentoStatus = BC000W14_A225FinanciamentoStatus[0];
            n225FinanciamentoStatus = BC000W14_n225FinanciamentoStatus[0];
            A221IntermediadorClienteRazaoSocial = BC000W14_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = BC000W14_n221IntermediadorClienteRazaoSocial[0];
            A222IntermediadorClienteDocumento = BC000W14_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = BC000W14_n222IntermediadorClienteDocumento[0];
            A168ClienteId = BC000W14_A168ClienteId[0];
            n168ClienteId = BC000W14_n168ClienteId[0];
            A220IntermediadorClienteId = BC000W14_A220IntermediadorClienteId[0];
            n220IntermediadorClienteId = BC000W14_n220IntermediadorClienteId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0W35( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound35 = 0;
         ScanKeyLoad0W35( ) ;
      }

      protected void ScanKeyLoad0W35( )
      {
         sMode35 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound35 = 1;
            A223FinanciamentoId = BC000W14_A223FinanciamentoId[0];
            A170ClienteRazaoSocial = BC000W14_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = BC000W14_n170ClienteRazaoSocial[0];
            A169ClienteDocumento = BC000W14_A169ClienteDocumento[0];
            n169ClienteDocumento = BC000W14_n169ClienteDocumento[0];
            A224FinanciamentoValor = BC000W14_A224FinanciamentoValor[0];
            n224FinanciamentoValor = BC000W14_n224FinanciamentoValor[0];
            A225FinanciamentoStatus = BC000W14_A225FinanciamentoStatus[0];
            n225FinanciamentoStatus = BC000W14_n225FinanciamentoStatus[0];
            A221IntermediadorClienteRazaoSocial = BC000W14_A221IntermediadorClienteRazaoSocial[0];
            n221IntermediadorClienteRazaoSocial = BC000W14_n221IntermediadorClienteRazaoSocial[0];
            A222IntermediadorClienteDocumento = BC000W14_A222IntermediadorClienteDocumento[0];
            n222IntermediadorClienteDocumento = BC000W14_n222IntermediadorClienteDocumento[0];
            A168ClienteId = BC000W14_A168ClienteId[0];
            n168ClienteId = BC000W14_n168ClienteId[0];
            A220IntermediadorClienteId = BC000W14_A220IntermediadorClienteId[0];
            n220IntermediadorClienteId = BC000W14_n220IntermediadorClienteId[0];
         }
         Gx_mode = sMode35;
      }

      protected void ScanKeyEnd0W35( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0W35( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0W35( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0W35( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0W35( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0W35( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0W35( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0W35( )
      {
      }

      protected void send_integrity_lvl_hashes0W35( )
      {
      }

      protected void AddRow0W35( )
      {
         VarsToRow35( bcFinanciamento) ;
      }

      protected void ReadRow0W35( )
      {
         RowToVars35( bcFinanciamento, 1) ;
      }

      protected void InitializeNonKey0W35( )
      {
         A168ClienteId = 0;
         n168ClienteId = false;
         A170ClienteRazaoSocial = "";
         n170ClienteRazaoSocial = false;
         A169ClienteDocumento = "";
         n169ClienteDocumento = false;
         A224FinanciamentoValor = 0;
         n224FinanciamentoValor = false;
         A225FinanciamentoStatus = "";
         n225FinanciamentoStatus = false;
         A220IntermediadorClienteId = 0;
         n220IntermediadorClienteId = false;
         A221IntermediadorClienteRazaoSocial = "";
         n221IntermediadorClienteRazaoSocial = false;
         A222IntermediadorClienteDocumento = "";
         n222IntermediadorClienteDocumento = false;
         Z224FinanciamentoValor = 0;
         Z225FinanciamentoStatus = "";
         Z168ClienteId = 0;
         Z220IntermediadorClienteId = 0;
      }

      protected void InitAll0W35( )
      {
         A223FinanciamentoId = 0;
         InitializeNonKey0W35( ) ;
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

      public void VarsToRow35( SdtFinanciamento obj35 )
      {
         obj35.gxTpr_Mode = Gx_mode;
         obj35.gxTpr_Clienteid = A168ClienteId;
         obj35.gxTpr_Clienterazaosocial = A170ClienteRazaoSocial;
         obj35.gxTpr_Clientedocumento = A169ClienteDocumento;
         obj35.gxTpr_Financiamentovalor = A224FinanciamentoValor;
         obj35.gxTpr_Financiamentostatus = A225FinanciamentoStatus;
         obj35.gxTpr_Intermediadorclienteid = A220IntermediadorClienteId;
         obj35.gxTpr_Intermediadorclienterazaosocial = A221IntermediadorClienteRazaoSocial;
         obj35.gxTpr_Intermediadorclientedocumento = A222IntermediadorClienteDocumento;
         obj35.gxTpr_Financiamentoid = A223FinanciamentoId;
         obj35.gxTpr_Financiamentoid_Z = Z223FinanciamentoId;
         obj35.gxTpr_Clienteid_Z = Z168ClienteId;
         obj35.gxTpr_Clienterazaosocial_Z = Z170ClienteRazaoSocial;
         obj35.gxTpr_Clientedocumento_Z = Z169ClienteDocumento;
         obj35.gxTpr_Financiamentovalor_Z = Z224FinanciamentoValor;
         obj35.gxTpr_Financiamentostatus_Z = Z225FinanciamentoStatus;
         obj35.gxTpr_Intermediadorclienteid_Z = Z220IntermediadorClienteId;
         obj35.gxTpr_Intermediadorclienterazaosocial_Z = Z221IntermediadorClienteRazaoSocial;
         obj35.gxTpr_Intermediadorclientedocumento_Z = Z222IntermediadorClienteDocumento;
         obj35.gxTpr_Clienteid_N = (short)(Convert.ToInt16(n168ClienteId));
         obj35.gxTpr_Clienterazaosocial_N = (short)(Convert.ToInt16(n170ClienteRazaoSocial));
         obj35.gxTpr_Clientedocumento_N = (short)(Convert.ToInt16(n169ClienteDocumento));
         obj35.gxTpr_Financiamentovalor_N = (short)(Convert.ToInt16(n224FinanciamentoValor));
         obj35.gxTpr_Financiamentostatus_N = (short)(Convert.ToInt16(n225FinanciamentoStatus));
         obj35.gxTpr_Intermediadorclienteid_N = (short)(Convert.ToInt16(n220IntermediadorClienteId));
         obj35.gxTpr_Intermediadorclienterazaosocial_N = (short)(Convert.ToInt16(n221IntermediadorClienteRazaoSocial));
         obj35.gxTpr_Intermediadorclientedocumento_N = (short)(Convert.ToInt16(n222IntermediadorClienteDocumento));
         obj35.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow35( SdtFinanciamento obj35 )
      {
         obj35.gxTpr_Financiamentoid = A223FinanciamentoId;
         return  ;
      }

      public void RowToVars35( SdtFinanciamento obj35 ,
                               int forceLoad )
      {
         Gx_mode = obj35.gxTpr_Mode;
         A168ClienteId = obj35.gxTpr_Clienteid;
         n168ClienteId = false;
         A170ClienteRazaoSocial = obj35.gxTpr_Clienterazaosocial;
         n170ClienteRazaoSocial = false;
         A169ClienteDocumento = obj35.gxTpr_Clientedocumento;
         n169ClienteDocumento = false;
         A224FinanciamentoValor = obj35.gxTpr_Financiamentovalor;
         n224FinanciamentoValor = false;
         A225FinanciamentoStatus = obj35.gxTpr_Financiamentostatus;
         n225FinanciamentoStatus = false;
         A220IntermediadorClienteId = obj35.gxTpr_Intermediadorclienteid;
         n220IntermediadorClienteId = false;
         A221IntermediadorClienteRazaoSocial = obj35.gxTpr_Intermediadorclienterazaosocial;
         n221IntermediadorClienteRazaoSocial = false;
         A222IntermediadorClienteDocumento = obj35.gxTpr_Intermediadorclientedocumento;
         n222IntermediadorClienteDocumento = false;
         A223FinanciamentoId = obj35.gxTpr_Financiamentoid;
         Z223FinanciamentoId = obj35.gxTpr_Financiamentoid_Z;
         Z168ClienteId = obj35.gxTpr_Clienteid_Z;
         Z170ClienteRazaoSocial = obj35.gxTpr_Clienterazaosocial_Z;
         Z169ClienteDocumento = obj35.gxTpr_Clientedocumento_Z;
         Z224FinanciamentoValor = obj35.gxTpr_Financiamentovalor_Z;
         Z225FinanciamentoStatus = obj35.gxTpr_Financiamentostatus_Z;
         Z220IntermediadorClienteId = obj35.gxTpr_Intermediadorclienteid_Z;
         Z221IntermediadorClienteRazaoSocial = obj35.gxTpr_Intermediadorclienterazaosocial_Z;
         Z222IntermediadorClienteDocumento = obj35.gxTpr_Intermediadorclientedocumento_Z;
         n168ClienteId = (bool)(Convert.ToBoolean(obj35.gxTpr_Clienteid_N));
         n170ClienteRazaoSocial = (bool)(Convert.ToBoolean(obj35.gxTpr_Clienterazaosocial_N));
         n169ClienteDocumento = (bool)(Convert.ToBoolean(obj35.gxTpr_Clientedocumento_N));
         n224FinanciamentoValor = (bool)(Convert.ToBoolean(obj35.gxTpr_Financiamentovalor_N));
         n225FinanciamentoStatus = (bool)(Convert.ToBoolean(obj35.gxTpr_Financiamentostatus_N));
         n220IntermediadorClienteId = (bool)(Convert.ToBoolean(obj35.gxTpr_Intermediadorclienteid_N));
         n221IntermediadorClienteRazaoSocial = (bool)(Convert.ToBoolean(obj35.gxTpr_Intermediadorclienterazaosocial_N));
         n222IntermediadorClienteDocumento = (bool)(Convert.ToBoolean(obj35.gxTpr_Intermediadorclientedocumento_N));
         Gx_mode = obj35.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A223FinanciamentoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0W35( ) ;
         ScanKeyStart0W35( ) ;
         if ( RcdFound35 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z223FinanciamentoId = A223FinanciamentoId;
         }
         ZM0W35( -5) ;
         OnLoadActions0W35( ) ;
         AddRow0W35( ) ;
         ScanKeyEnd0W35( ) ;
         if ( RcdFound35 == 0 )
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
         RowToVars35( bcFinanciamento, 0) ;
         ScanKeyStart0W35( ) ;
         if ( RcdFound35 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z223FinanciamentoId = A223FinanciamentoId;
         }
         ZM0W35( -5) ;
         OnLoadActions0W35( ) ;
         AddRow0W35( ) ;
         ScanKeyEnd0W35( ) ;
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0W35( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0W35( ) ;
         }
         else
         {
            if ( RcdFound35 == 1 )
            {
               if ( A223FinanciamentoId != Z223FinanciamentoId )
               {
                  A223FinanciamentoId = Z223FinanciamentoId;
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
                  Update0W35( ) ;
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
                  if ( A223FinanciamentoId != Z223FinanciamentoId )
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
                        Insert0W35( ) ;
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
                        Insert0W35( ) ;
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
         RowToVars35( bcFinanciamento, 1) ;
         SaveImpl( ) ;
         VarsToRow35( bcFinanciamento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars35( bcFinanciamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0W35( ) ;
         AfterTrn( ) ;
         VarsToRow35( bcFinanciamento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow35( bcFinanciamento) ;
         }
         else
         {
            SdtFinanciamento auxBC = new SdtFinanciamento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A223FinanciamentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcFinanciamento);
               auxBC.Save();
               bcFinanciamento.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars35( bcFinanciamento, 1) ;
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
         RowToVars35( bcFinanciamento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0W35( ) ;
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
               VarsToRow35( bcFinanciamento) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow35( bcFinanciamento) ;
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
         RowToVars35( bcFinanciamento, 0) ;
         GetKey0W35( ) ;
         if ( RcdFound35 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A223FinanciamentoId != Z223FinanciamentoId )
            {
               A223FinanciamentoId = Z223FinanciamentoId;
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
            if ( A223FinanciamentoId != Z223FinanciamentoId )
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
         context.RollbackDataStores("financiamento_bc",pr_default);
         VarsToRow35( bcFinanciamento) ;
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
         Gx_mode = bcFinanciamento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcFinanciamento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcFinanciamento )
         {
            bcFinanciamento = (SdtFinanciamento)(sdt);
            if ( StringUtil.StrCmp(bcFinanciamento.gxTpr_Mode, "") == 0 )
            {
               bcFinanciamento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow35( bcFinanciamento) ;
            }
            else
            {
               RowToVars35( bcFinanciamento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcFinanciamento.gxTpr_Mode, "") == 0 )
            {
               bcFinanciamento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars35( bcFinanciamento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtFinanciamento Financiamento_BC
      {
         get {
            return bcFinanciamento ;
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
         AV23Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z225FinanciamentoStatus = "";
         A225FinanciamentoStatus = "";
         Z170ClienteRazaoSocial = "";
         A170ClienteRazaoSocial = "";
         Z169ClienteDocumento = "";
         A169ClienteDocumento = "";
         Z221IntermediadorClienteRazaoSocial = "";
         A221IntermediadorClienteRazaoSocial = "";
         Z222IntermediadorClienteDocumento = "";
         A222IntermediadorClienteDocumento = "";
         BC000W6_A223FinanciamentoId = new int[1] ;
         BC000W6_A170ClienteRazaoSocial = new string[] {""} ;
         BC000W6_n170ClienteRazaoSocial = new bool[] {false} ;
         BC000W6_A169ClienteDocumento = new string[] {""} ;
         BC000W6_n169ClienteDocumento = new bool[] {false} ;
         BC000W6_A224FinanciamentoValor = new decimal[1] ;
         BC000W6_n224FinanciamentoValor = new bool[] {false} ;
         BC000W6_A225FinanciamentoStatus = new string[] {""} ;
         BC000W6_n225FinanciamentoStatus = new bool[] {false} ;
         BC000W6_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         BC000W6_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         BC000W6_A222IntermediadorClienteDocumento = new string[] {""} ;
         BC000W6_n222IntermediadorClienteDocumento = new bool[] {false} ;
         BC000W6_A168ClienteId = new int[1] ;
         BC000W6_n168ClienteId = new bool[] {false} ;
         BC000W6_A220IntermediadorClienteId = new int[1] ;
         BC000W6_n220IntermediadorClienteId = new bool[] {false} ;
         BC000W4_A170ClienteRazaoSocial = new string[] {""} ;
         BC000W4_n170ClienteRazaoSocial = new bool[] {false} ;
         BC000W4_A169ClienteDocumento = new string[] {""} ;
         BC000W4_n169ClienteDocumento = new bool[] {false} ;
         BC000W5_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         BC000W5_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         BC000W5_A222IntermediadorClienteDocumento = new string[] {""} ;
         BC000W5_n222IntermediadorClienteDocumento = new bool[] {false} ;
         BC000W7_A223FinanciamentoId = new int[1] ;
         BC000W3_A223FinanciamentoId = new int[1] ;
         BC000W3_A224FinanciamentoValor = new decimal[1] ;
         BC000W3_n224FinanciamentoValor = new bool[] {false} ;
         BC000W3_A225FinanciamentoStatus = new string[] {""} ;
         BC000W3_n225FinanciamentoStatus = new bool[] {false} ;
         BC000W3_A168ClienteId = new int[1] ;
         BC000W3_n168ClienteId = new bool[] {false} ;
         BC000W3_A220IntermediadorClienteId = new int[1] ;
         BC000W3_n220IntermediadorClienteId = new bool[] {false} ;
         sMode35 = "";
         BC000W2_A223FinanciamentoId = new int[1] ;
         BC000W2_A224FinanciamentoValor = new decimal[1] ;
         BC000W2_n224FinanciamentoValor = new bool[] {false} ;
         BC000W2_A225FinanciamentoStatus = new string[] {""} ;
         BC000W2_n225FinanciamentoStatus = new bool[] {false} ;
         BC000W2_A168ClienteId = new int[1] ;
         BC000W2_n168ClienteId = new bool[] {false} ;
         BC000W2_A220IntermediadorClienteId = new int[1] ;
         BC000W2_n220IntermediadorClienteId = new bool[] {false} ;
         BC000W9_A223FinanciamentoId = new int[1] ;
         BC000W12_A170ClienteRazaoSocial = new string[] {""} ;
         BC000W12_n170ClienteRazaoSocial = new bool[] {false} ;
         BC000W12_A169ClienteDocumento = new string[] {""} ;
         BC000W12_n169ClienteDocumento = new bool[] {false} ;
         BC000W13_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         BC000W13_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         BC000W13_A222IntermediadorClienteDocumento = new string[] {""} ;
         BC000W13_n222IntermediadorClienteDocumento = new bool[] {false} ;
         BC000W14_A223FinanciamentoId = new int[1] ;
         BC000W14_A170ClienteRazaoSocial = new string[] {""} ;
         BC000W14_n170ClienteRazaoSocial = new bool[] {false} ;
         BC000W14_A169ClienteDocumento = new string[] {""} ;
         BC000W14_n169ClienteDocumento = new bool[] {false} ;
         BC000W14_A224FinanciamentoValor = new decimal[1] ;
         BC000W14_n224FinanciamentoValor = new bool[] {false} ;
         BC000W14_A225FinanciamentoStatus = new string[] {""} ;
         BC000W14_n225FinanciamentoStatus = new bool[] {false} ;
         BC000W14_A221IntermediadorClienteRazaoSocial = new string[] {""} ;
         BC000W14_n221IntermediadorClienteRazaoSocial = new bool[] {false} ;
         BC000W14_A222IntermediadorClienteDocumento = new string[] {""} ;
         BC000W14_n222IntermediadorClienteDocumento = new bool[] {false} ;
         BC000W14_A168ClienteId = new int[1] ;
         BC000W14_n168ClienteId = new bool[] {false} ;
         BC000W14_A220IntermediadorClienteId = new int[1] ;
         BC000W14_n220IntermediadorClienteId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.financiamento_bc__default(),
            new Object[][] {
                new Object[] {
               BC000W2_A223FinanciamentoId, BC000W2_A224FinanciamentoValor, BC000W2_n224FinanciamentoValor, BC000W2_A225FinanciamentoStatus, BC000W2_n225FinanciamentoStatus, BC000W2_A168ClienteId, BC000W2_n168ClienteId, BC000W2_A220IntermediadorClienteId, BC000W2_n220IntermediadorClienteId
               }
               , new Object[] {
               BC000W3_A223FinanciamentoId, BC000W3_A224FinanciamentoValor, BC000W3_n224FinanciamentoValor, BC000W3_A225FinanciamentoStatus, BC000W3_n225FinanciamentoStatus, BC000W3_A168ClienteId, BC000W3_n168ClienteId, BC000W3_A220IntermediadorClienteId, BC000W3_n220IntermediadorClienteId
               }
               , new Object[] {
               BC000W4_A170ClienteRazaoSocial, BC000W4_n170ClienteRazaoSocial, BC000W4_A169ClienteDocumento, BC000W4_n169ClienteDocumento
               }
               , new Object[] {
               BC000W5_A221IntermediadorClienteRazaoSocial, BC000W5_n221IntermediadorClienteRazaoSocial, BC000W5_A222IntermediadorClienteDocumento, BC000W5_n222IntermediadorClienteDocumento
               }
               , new Object[] {
               BC000W6_A223FinanciamentoId, BC000W6_A170ClienteRazaoSocial, BC000W6_n170ClienteRazaoSocial, BC000W6_A169ClienteDocumento, BC000W6_n169ClienteDocumento, BC000W6_A224FinanciamentoValor, BC000W6_n224FinanciamentoValor, BC000W6_A225FinanciamentoStatus, BC000W6_n225FinanciamentoStatus, BC000W6_A221IntermediadorClienteRazaoSocial,
               BC000W6_n221IntermediadorClienteRazaoSocial, BC000W6_A222IntermediadorClienteDocumento, BC000W6_n222IntermediadorClienteDocumento, BC000W6_A168ClienteId, BC000W6_n168ClienteId, BC000W6_A220IntermediadorClienteId, BC000W6_n220IntermediadorClienteId
               }
               , new Object[] {
               BC000W7_A223FinanciamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000W9_A223FinanciamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000W12_A170ClienteRazaoSocial, BC000W12_n170ClienteRazaoSocial, BC000W12_A169ClienteDocumento, BC000W12_n169ClienteDocumento
               }
               , new Object[] {
               BC000W13_A221IntermediadorClienteRazaoSocial, BC000W13_n221IntermediadorClienteRazaoSocial, BC000W13_A222IntermediadorClienteDocumento, BC000W13_n222IntermediadorClienteDocumento
               }
               , new Object[] {
               BC000W14_A223FinanciamentoId, BC000W14_A170ClienteRazaoSocial, BC000W14_n170ClienteRazaoSocial, BC000W14_A169ClienteDocumento, BC000W14_n169ClienteDocumento, BC000W14_A224FinanciamentoValor, BC000W14_n224FinanciamentoValor, BC000W14_A225FinanciamentoStatus, BC000W14_n225FinanciamentoStatus, BC000W14_A221IntermediadorClienteRazaoSocial,
               BC000W14_n221IntermediadorClienteRazaoSocial, BC000W14_A222IntermediadorClienteDocumento, BC000W14_n222IntermediadorClienteDocumento, BC000W14_A168ClienteId, BC000W14_n168ClienteId, BC000W14_A220IntermediadorClienteId, BC000W14_n220IntermediadorClienteId
               }
            }
         );
         AV23Pgmname = "Financiamento_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120W2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound35 ;
      private int trnEnded ;
      private int Z223FinanciamentoId ;
      private int A223FinanciamentoId ;
      private int AV24GXV1 ;
      private int AV11Insert_ClienteId ;
      private int AV12Insert_IntermediadorClienteId ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private int Z220IntermediadorClienteId ;
      private int A220IntermediadorClienteId ;
      private decimal Z224FinanciamentoValor ;
      private decimal A224FinanciamentoValor ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV23Pgmname ;
      private string sMode35 ;
      private bool returnInSub ;
      private bool n170ClienteRazaoSocial ;
      private bool n169ClienteDocumento ;
      private bool n224FinanciamentoValor ;
      private bool n225FinanciamentoStatus ;
      private bool n221IntermediadorClienteRazaoSocial ;
      private bool n222IntermediadorClienteDocumento ;
      private bool n168ClienteId ;
      private bool n220IntermediadorClienteId ;
      private string Z225FinanciamentoStatus ;
      private string A225FinanciamentoStatus ;
      private string Z170ClienteRazaoSocial ;
      private string A170ClienteRazaoSocial ;
      private string Z169ClienteDocumento ;
      private string A169ClienteDocumento ;
      private string Z221IntermediadorClienteRazaoSocial ;
      private string A221IntermediadorClienteRazaoSocial ;
      private string Z222IntermediadorClienteDocumento ;
      private string A222IntermediadorClienteDocumento ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC000W6_A223FinanciamentoId ;
      private string[] BC000W6_A170ClienteRazaoSocial ;
      private bool[] BC000W6_n170ClienteRazaoSocial ;
      private string[] BC000W6_A169ClienteDocumento ;
      private bool[] BC000W6_n169ClienteDocumento ;
      private decimal[] BC000W6_A224FinanciamentoValor ;
      private bool[] BC000W6_n224FinanciamentoValor ;
      private string[] BC000W6_A225FinanciamentoStatus ;
      private bool[] BC000W6_n225FinanciamentoStatus ;
      private string[] BC000W6_A221IntermediadorClienteRazaoSocial ;
      private bool[] BC000W6_n221IntermediadorClienteRazaoSocial ;
      private string[] BC000W6_A222IntermediadorClienteDocumento ;
      private bool[] BC000W6_n222IntermediadorClienteDocumento ;
      private int[] BC000W6_A168ClienteId ;
      private bool[] BC000W6_n168ClienteId ;
      private int[] BC000W6_A220IntermediadorClienteId ;
      private bool[] BC000W6_n220IntermediadorClienteId ;
      private string[] BC000W4_A170ClienteRazaoSocial ;
      private bool[] BC000W4_n170ClienteRazaoSocial ;
      private string[] BC000W4_A169ClienteDocumento ;
      private bool[] BC000W4_n169ClienteDocumento ;
      private string[] BC000W5_A221IntermediadorClienteRazaoSocial ;
      private bool[] BC000W5_n221IntermediadorClienteRazaoSocial ;
      private string[] BC000W5_A222IntermediadorClienteDocumento ;
      private bool[] BC000W5_n222IntermediadorClienteDocumento ;
      private int[] BC000W7_A223FinanciamentoId ;
      private int[] BC000W3_A223FinanciamentoId ;
      private decimal[] BC000W3_A224FinanciamentoValor ;
      private bool[] BC000W3_n224FinanciamentoValor ;
      private string[] BC000W3_A225FinanciamentoStatus ;
      private bool[] BC000W3_n225FinanciamentoStatus ;
      private int[] BC000W3_A168ClienteId ;
      private bool[] BC000W3_n168ClienteId ;
      private int[] BC000W3_A220IntermediadorClienteId ;
      private bool[] BC000W3_n220IntermediadorClienteId ;
      private int[] BC000W2_A223FinanciamentoId ;
      private decimal[] BC000W2_A224FinanciamentoValor ;
      private bool[] BC000W2_n224FinanciamentoValor ;
      private string[] BC000W2_A225FinanciamentoStatus ;
      private bool[] BC000W2_n225FinanciamentoStatus ;
      private int[] BC000W2_A168ClienteId ;
      private bool[] BC000W2_n168ClienteId ;
      private int[] BC000W2_A220IntermediadorClienteId ;
      private bool[] BC000W2_n220IntermediadorClienteId ;
      private int[] BC000W9_A223FinanciamentoId ;
      private string[] BC000W12_A170ClienteRazaoSocial ;
      private bool[] BC000W12_n170ClienteRazaoSocial ;
      private string[] BC000W12_A169ClienteDocumento ;
      private bool[] BC000W12_n169ClienteDocumento ;
      private string[] BC000W13_A221IntermediadorClienteRazaoSocial ;
      private bool[] BC000W13_n221IntermediadorClienteRazaoSocial ;
      private string[] BC000W13_A222IntermediadorClienteDocumento ;
      private bool[] BC000W13_n222IntermediadorClienteDocumento ;
      private int[] BC000W14_A223FinanciamentoId ;
      private string[] BC000W14_A170ClienteRazaoSocial ;
      private bool[] BC000W14_n170ClienteRazaoSocial ;
      private string[] BC000W14_A169ClienteDocumento ;
      private bool[] BC000W14_n169ClienteDocumento ;
      private decimal[] BC000W14_A224FinanciamentoValor ;
      private bool[] BC000W14_n224FinanciamentoValor ;
      private string[] BC000W14_A225FinanciamentoStatus ;
      private bool[] BC000W14_n225FinanciamentoStatus ;
      private string[] BC000W14_A221IntermediadorClienteRazaoSocial ;
      private bool[] BC000W14_n221IntermediadorClienteRazaoSocial ;
      private string[] BC000W14_A222IntermediadorClienteDocumento ;
      private bool[] BC000W14_n222IntermediadorClienteDocumento ;
      private int[] BC000W14_A168ClienteId ;
      private bool[] BC000W14_n168ClienteId ;
      private int[] BC000W14_A220IntermediadorClienteId ;
      private bool[] BC000W14_n220IntermediadorClienteId ;
      private SdtFinanciamento bcFinanciamento ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class financiamento_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC000W2;
          prmBC000W2 = new Object[] {
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC000W3;
          prmBC000W3 = new Object[] {
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC000W4;
          prmBC000W4 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000W5;
          prmBC000W5 = new Object[] {
          new ParDef("IntermediadorClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000W6;
          prmBC000W6 = new Object[] {
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC000W7;
          prmBC000W7 = new Object[] {
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC000W8;
          prmBC000W8 = new Object[] {
          new ParDef("FinanciamentoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("FinanciamentoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("IntermediadorClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000W9;
          prmBC000W9 = new Object[] {
          };
          Object[] prmBC000W10;
          prmBC000W10 = new Object[] {
          new ParDef("FinanciamentoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("FinanciamentoStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("IntermediadorClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC000W11;
          prmBC000W11 = new Object[] {
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          Object[] prmBC000W12;
          prmBC000W12 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000W13;
          prmBC000W13 = new Object[] {
          new ParDef("IntermediadorClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000W14;
          prmBC000W14 = new Object[] {
          new ParDef("FinanciamentoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000W2", "SELECT FinanciamentoId, FinanciamentoValor, FinanciamentoStatus, ClienteId, IntermediadorClienteId FROM Financiamento WHERE FinanciamentoId = :FinanciamentoId  FOR UPDATE OF Financiamento",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000W3", "SELECT FinanciamentoId, FinanciamentoValor, FinanciamentoStatus, ClienteId, IntermediadorClienteId FROM Financiamento WHERE FinanciamentoId = :FinanciamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000W4", "SELECT ClienteRazaoSocial, ClienteDocumento FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000W5", "SELECT ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, ClienteDocumento AS IntermediadorClienteDocumento FROM Cliente WHERE ClienteId = :IntermediadorClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000W6", "SELECT TM1.FinanciamentoId, T2.ClienteRazaoSocial, T2.ClienteDocumento, TM1.FinanciamentoValor, TM1.FinanciamentoStatus, T3.ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, T3.ClienteDocumento AS IntermediadorClienteDocumento, TM1.ClienteId, TM1.IntermediadorClienteId AS IntermediadorClienteId FROM ((Financiamento TM1 LEFT JOIN Cliente T2 ON T2.ClienteId = TM1.ClienteId) LEFT JOIN Cliente T3 ON T3.ClienteId = TM1.IntermediadorClienteId) WHERE TM1.FinanciamentoId = :FinanciamentoId ORDER BY TM1.FinanciamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000W7", "SELECT FinanciamentoId FROM Financiamento WHERE FinanciamentoId = :FinanciamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000W8", "SAVEPOINT gxupdate;INSERT INTO Financiamento(FinanciamentoValor, FinanciamentoStatus, ClienteId, IntermediadorClienteId) VALUES(:FinanciamentoValor, :FinanciamentoStatus, :ClienteId, :IntermediadorClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000W8)
             ,new CursorDef("BC000W9", "SELECT currval('FinanciamentoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000W10", "SAVEPOINT gxupdate;UPDATE Financiamento SET FinanciamentoValor=:FinanciamentoValor, FinanciamentoStatus=:FinanciamentoStatus, ClienteId=:ClienteId, IntermediadorClienteId=:IntermediadorClienteId  WHERE FinanciamentoId = :FinanciamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W10)
             ,new CursorDef("BC000W11", "SAVEPOINT gxupdate;DELETE FROM Financiamento  WHERE FinanciamentoId = :FinanciamentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000W11)
             ,new CursorDef("BC000W12", "SELECT ClienteRazaoSocial, ClienteDocumento FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000W13", "SELECT ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, ClienteDocumento AS IntermediadorClienteDocumento FROM Cliente WHERE ClienteId = :IntermediadorClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000W14", "SELECT TM1.FinanciamentoId, T2.ClienteRazaoSocial, T2.ClienteDocumento, TM1.FinanciamentoValor, TM1.FinanciamentoStatus, T3.ClienteRazaoSocial AS IntermediadorClienteRazaoSocial, T3.ClienteDocumento AS IntermediadorClienteDocumento, TM1.ClienteId, TM1.IntermediadorClienteId AS IntermediadorClienteId FROM ((Financiamento TM1 LEFT JOIN Cliente T2 ON T2.ClienteId = TM1.ClienteId) LEFT JOIN Cliente T3 ON T3.ClienteId = TM1.IntermediadorClienteId) WHERE TM1.FinanciamentoId = :FinanciamentoId ORDER BY TM1.FinanciamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000W14,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
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
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
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
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                return;
       }
    }

 }

}
