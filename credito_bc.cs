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
   public class credito_bc : GxSilentTrn, IGxSilentTrn
   {
      public credito_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public credito_bc( IGxContext context )
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
         ReadRow2P95( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2P95( ) ;
         standaloneModal( ) ;
         AddRow2P95( ) ;
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
            E112P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z856CreditoId = A856CreditoId;
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

      protected void CONFIRM_2P0( )
      {
         BeforeValidate2P95( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2P95( ) ;
            }
            else
            {
               CheckExtendedTable2P95( ) ;
               if ( AnyError == 0 )
               {
                  ZM2P95( 9) ;
                  ZM2P95( 10) ;
                  ZM2P95( 11) ;
               }
               CloseExtendedTableCursors2P95( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122P2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            while ( AV26GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV11Insert_ClienteId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "CreditoCreatedBy") == 0 )
               {
                  AV12Insert_CreditoCreatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "CreditoUpdatedBy") == 0 )
               {
                  AV24Insert_CreditoUpdatedBy = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV26GXV1 = (int)(AV26GXV1+1);
            }
         }
      }

      protected void E112P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2P95( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z859CreditoCreatedAt = A859CreditoCreatedAt;
            Z860CreditoUpdatedAt = A860CreditoUpdatedAt;
            Z857CreditoValor = A857CreditoValor;
            Z858CreditoVigencia = A858CreditoVigencia;
            Z168ClienteId = A168ClienteId;
            Z861CreditoCreatedBy = A861CreditoCreatedBy;
            Z862CreditoUpdatedBy = A862CreditoUpdatedBy;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -8 )
         {
            Z856CreditoId = A856CreditoId;
            Z859CreditoCreatedAt = A859CreditoCreatedAt;
            Z860CreditoUpdatedAt = A860CreditoUpdatedAt;
            Z857CreditoValor = A857CreditoValor;
            Z858CreditoVigencia = A858CreditoVigencia;
            Z168ClienteId = A168ClienteId;
            Z861CreditoCreatedBy = A861CreditoCreatedBy;
            Z862CreditoUpdatedBy = A862CreditoUpdatedBy;
         }
      }

      protected void standaloneNotModal( )
      {
         AV25Pgmname = "Credito_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A859CreditoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n859CreditoCreatedAt = false;
         }
         if ( IsUpd( )  )
         {
            A860CreditoUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n860CreditoUpdatedAt = false;
         }
      }

      protected void Load2P95( )
      {
         /* Using cursor BC002P7 */
         pr_default.execute(5, new Object[] {A856CreditoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound95 = 1;
            A859CreditoCreatedAt = BC002P7_A859CreditoCreatedAt[0];
            n859CreditoCreatedAt = BC002P7_n859CreditoCreatedAt[0];
            A860CreditoUpdatedAt = BC002P7_A860CreditoUpdatedAt[0];
            n860CreditoUpdatedAt = BC002P7_n860CreditoUpdatedAt[0];
            A857CreditoValor = BC002P7_A857CreditoValor[0];
            n857CreditoValor = BC002P7_n857CreditoValor[0];
            A858CreditoVigencia = BC002P7_A858CreditoVigencia[0];
            n858CreditoVigencia = BC002P7_n858CreditoVigencia[0];
            A168ClienteId = BC002P7_A168ClienteId[0];
            n168ClienteId = BC002P7_n168ClienteId[0];
            A861CreditoCreatedBy = BC002P7_A861CreditoCreatedBy[0];
            n861CreditoCreatedBy = BC002P7_n861CreditoCreatedBy[0];
            A862CreditoUpdatedBy = BC002P7_A862CreditoUpdatedBy[0];
            n862CreditoUpdatedBy = BC002P7_n862CreditoUpdatedBy[0];
            ZM2P95( -8) ;
         }
         pr_default.close(5);
         OnLoadActions2P95( ) ;
      }

      protected void OnLoadActions2P95( )
      {
      }

      protected void CheckExtendedTable2P95( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002P4 */
         pr_default.execute(2, new Object[] {n168ClienteId, A168ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A168ClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         if ( (Convert.ToDecimal(0)==A857CreditoValor) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Credito Valor", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ( A857CreditoValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( (DateTime.MinValue==A858CreditoVigencia) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Credito Vigencia", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC002P5 */
         pr_default.execute(3, new Object[] {n861CreditoCreatedBy, A861CreditoCreatedBy});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A861CreditoCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sdb Credito Usuario'.", "ForeignKeyNotFound", 1, "CREDITOCREATEDBY");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         /* Using cursor BC002P6 */
         pr_default.execute(4, new Object[] {n862CreditoUpdatedBy, A862CreditoUpdatedBy});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A862CreditoUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Updated By Credito'.", "ForeignKeyNotFound", 1, "CREDITOUPDATEDBY");
               AnyError = 1;
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2P95( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2P95( )
      {
         /* Using cursor BC002P8 */
         pr_default.execute(6, new Object[] {A856CreditoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound95 = 1;
         }
         else
         {
            RcdFound95 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002P3 */
         pr_default.execute(1, new Object[] {A856CreditoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2P95( 8) ;
            RcdFound95 = 1;
            A856CreditoId = BC002P3_A856CreditoId[0];
            A859CreditoCreatedAt = BC002P3_A859CreditoCreatedAt[0];
            n859CreditoCreatedAt = BC002P3_n859CreditoCreatedAt[0];
            A860CreditoUpdatedAt = BC002P3_A860CreditoUpdatedAt[0];
            n860CreditoUpdatedAt = BC002P3_n860CreditoUpdatedAt[0];
            A857CreditoValor = BC002P3_A857CreditoValor[0];
            n857CreditoValor = BC002P3_n857CreditoValor[0];
            A858CreditoVigencia = BC002P3_A858CreditoVigencia[0];
            n858CreditoVigencia = BC002P3_n858CreditoVigencia[0];
            A168ClienteId = BC002P3_A168ClienteId[0];
            n168ClienteId = BC002P3_n168ClienteId[0];
            A861CreditoCreatedBy = BC002P3_A861CreditoCreatedBy[0];
            n861CreditoCreatedBy = BC002P3_n861CreditoCreatedBy[0];
            A862CreditoUpdatedBy = BC002P3_A862CreditoUpdatedBy[0];
            n862CreditoUpdatedBy = BC002P3_n862CreditoUpdatedBy[0];
            Z856CreditoId = A856CreditoId;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2P95( ) ;
            if ( AnyError == 1 )
            {
               RcdFound95 = 0;
               InitializeNonKey2P95( ) ;
            }
            Gx_mode = sMode95;
         }
         else
         {
            RcdFound95 = 0;
            InitializeNonKey2P95( ) ;
            sMode95 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode95;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2P95( ) ;
         if ( RcdFound95 == 0 )
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
         CONFIRM_2P0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2P95( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002P2 */
            pr_default.execute(0, new Object[] {A856CreditoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Credito"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z859CreditoCreatedAt != BC002P2_A859CreditoCreatedAt[0] ) || ( Z860CreditoUpdatedAt != BC002P2_A860CreditoUpdatedAt[0] ) || ( Z857CreditoValor != BC002P2_A857CreditoValor[0] ) || ( DateTimeUtil.ResetTime ( Z858CreditoVigencia ) != DateTimeUtil.ResetTime ( BC002P2_A858CreditoVigencia[0] ) ) || ( Z168ClienteId != BC002P2_A168ClienteId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z861CreditoCreatedBy != BC002P2_A861CreditoCreatedBy[0] ) || ( Z862CreditoUpdatedBy != BC002P2_A862CreditoUpdatedBy[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Credito"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2P95( )
      {
         BeforeValidate2P95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2P95( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2P95( 0) ;
            CheckOptimisticConcurrency2P95( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2P95( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2P95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002P9 */
                     pr_default.execute(7, new Object[] {n859CreditoCreatedAt, A859CreditoCreatedAt, n860CreditoUpdatedAt, A860CreditoUpdatedAt, n857CreditoValor, A857CreditoValor, n858CreditoVigencia, A858CreditoVigencia, n168ClienteId, A168ClienteId, n861CreditoCreatedBy, A861CreditoCreatedBy, n862CreditoUpdatedBy, A862CreditoUpdatedBy});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002P10 */
                     pr_default.execute(8);
                     A856CreditoId = BC002P10_A856CreditoId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Credito");
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
               Load2P95( ) ;
            }
            EndLevel2P95( ) ;
         }
         CloseExtendedTableCursors2P95( ) ;
      }

      protected void Update2P95( )
      {
         BeforeValidate2P95( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2P95( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2P95( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2P95( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2P95( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002P11 */
                     pr_default.execute(9, new Object[] {n859CreditoCreatedAt, A859CreditoCreatedAt, n860CreditoUpdatedAt, A860CreditoUpdatedAt, n857CreditoValor, A857CreditoValor, n858CreditoVigencia, A858CreditoVigencia, n168ClienteId, A168ClienteId, n861CreditoCreatedBy, A861CreditoCreatedBy, n862CreditoUpdatedBy, A862CreditoUpdatedBy, A856CreditoId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Credito");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Credito"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2P95( ) ;
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
            EndLevel2P95( ) ;
         }
         CloseExtendedTableCursors2P95( ) ;
      }

      protected void DeferredUpdate2P95( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2P95( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2P95( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2P95( ) ;
            AfterConfirm2P95( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2P95( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002P12 */
                  pr_default.execute(10, new Object[] {A856CreditoId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("Credito");
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
         sMode95 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2P95( ) ;
         Gx_mode = sMode95;
      }

      protected void OnDeleteControls2P95( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2P95( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2P95( ) ;
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

      public void ScanKeyStart2P95( )
      {
         /* Scan By routine */
         /* Using cursor BC002P13 */
         pr_default.execute(11, new Object[] {A856CreditoId});
         RcdFound95 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound95 = 1;
            A856CreditoId = BC002P13_A856CreditoId[0];
            A859CreditoCreatedAt = BC002P13_A859CreditoCreatedAt[0];
            n859CreditoCreatedAt = BC002P13_n859CreditoCreatedAt[0];
            A860CreditoUpdatedAt = BC002P13_A860CreditoUpdatedAt[0];
            n860CreditoUpdatedAt = BC002P13_n860CreditoUpdatedAt[0];
            A857CreditoValor = BC002P13_A857CreditoValor[0];
            n857CreditoValor = BC002P13_n857CreditoValor[0];
            A858CreditoVigencia = BC002P13_A858CreditoVigencia[0];
            n858CreditoVigencia = BC002P13_n858CreditoVigencia[0];
            A168ClienteId = BC002P13_A168ClienteId[0];
            n168ClienteId = BC002P13_n168ClienteId[0];
            A861CreditoCreatedBy = BC002P13_A861CreditoCreatedBy[0];
            n861CreditoCreatedBy = BC002P13_n861CreditoCreatedBy[0];
            A862CreditoUpdatedBy = BC002P13_A862CreditoUpdatedBy[0];
            n862CreditoUpdatedBy = BC002P13_n862CreditoUpdatedBy[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2P95( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound95 = 0;
         ScanKeyLoad2P95( ) ;
      }

      protected void ScanKeyLoad2P95( )
      {
         sMode95 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound95 = 1;
            A856CreditoId = BC002P13_A856CreditoId[0];
            A859CreditoCreatedAt = BC002P13_A859CreditoCreatedAt[0];
            n859CreditoCreatedAt = BC002P13_n859CreditoCreatedAt[0];
            A860CreditoUpdatedAt = BC002P13_A860CreditoUpdatedAt[0];
            n860CreditoUpdatedAt = BC002P13_n860CreditoUpdatedAt[0];
            A857CreditoValor = BC002P13_A857CreditoValor[0];
            n857CreditoValor = BC002P13_n857CreditoValor[0];
            A858CreditoVigencia = BC002P13_A858CreditoVigencia[0];
            n858CreditoVigencia = BC002P13_n858CreditoVigencia[0];
            A168ClienteId = BC002P13_A168ClienteId[0];
            n168ClienteId = BC002P13_n168ClienteId[0];
            A861CreditoCreatedBy = BC002P13_A861CreditoCreatedBy[0];
            n861CreditoCreatedBy = BC002P13_n861CreditoCreatedBy[0];
            A862CreditoUpdatedBy = BC002P13_A862CreditoUpdatedBy[0];
            n862CreditoUpdatedBy = BC002P13_n862CreditoUpdatedBy[0];
         }
         Gx_mode = sMode95;
      }

      protected void ScanKeyEnd2P95( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm2P95( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2P95( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2P95( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2P95( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2P95( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2P95( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2P95( )
      {
      }

      protected void send_integrity_lvl_hashes2P95( )
      {
      }

      protected void AddRow2P95( )
      {
         VarsToRow95( bcCredito) ;
      }

      protected void ReadRow2P95( )
      {
         RowToVars95( bcCredito, 1) ;
      }

      protected void InitializeNonKey2P95( )
      {
         A859CreditoCreatedAt = (DateTime)(DateTime.MinValue);
         n859CreditoCreatedAt = false;
         A860CreditoUpdatedAt = (DateTime)(DateTime.MinValue);
         n860CreditoUpdatedAt = false;
         A168ClienteId = 0;
         n168ClienteId = false;
         A857CreditoValor = 0;
         n857CreditoValor = false;
         A858CreditoVigencia = DateTime.MinValue;
         n858CreditoVigencia = false;
         A861CreditoCreatedBy = 0;
         n861CreditoCreatedBy = false;
         A862CreditoUpdatedBy = 0;
         n862CreditoUpdatedBy = false;
         Z859CreditoCreatedAt = (DateTime)(DateTime.MinValue);
         Z860CreditoUpdatedAt = (DateTime)(DateTime.MinValue);
         Z857CreditoValor = 0;
         Z858CreditoVigencia = DateTime.MinValue;
         Z168ClienteId = 0;
         Z861CreditoCreatedBy = 0;
         Z862CreditoUpdatedBy = 0;
      }

      protected void InitAll2P95( )
      {
         A856CreditoId = 0;
         InitializeNonKey2P95( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A859CreditoCreatedAt = i859CreditoCreatedAt;
         n859CreditoCreatedAt = false;
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

      public void VarsToRow95( SdtCredito obj95 )
      {
         obj95.gxTpr_Mode = Gx_mode;
         obj95.gxTpr_Creditocreatedat = A859CreditoCreatedAt;
         obj95.gxTpr_Creditoupdatedat = A860CreditoUpdatedAt;
         obj95.gxTpr_Clienteid = A168ClienteId;
         obj95.gxTpr_Creditovalor = A857CreditoValor;
         obj95.gxTpr_Creditovigencia = A858CreditoVigencia;
         obj95.gxTpr_Creditocreatedby = A861CreditoCreatedBy;
         obj95.gxTpr_Creditoupdatedby = A862CreditoUpdatedBy;
         obj95.gxTpr_Creditoid = A856CreditoId;
         obj95.gxTpr_Creditoid_Z = Z856CreditoId;
         obj95.gxTpr_Clienteid_Z = Z168ClienteId;
         obj95.gxTpr_Creditovalor_Z = Z857CreditoValor;
         obj95.gxTpr_Creditovigencia_Z = Z858CreditoVigencia;
         obj95.gxTpr_Creditocreatedat_Z = Z859CreditoCreatedAt;
         obj95.gxTpr_Creditoupdatedat_Z = Z860CreditoUpdatedAt;
         obj95.gxTpr_Creditocreatedby_Z = Z861CreditoCreatedBy;
         obj95.gxTpr_Creditoupdatedby_Z = Z862CreditoUpdatedBy;
         obj95.gxTpr_Clienteid_N = (short)(Convert.ToInt16(n168ClienteId));
         obj95.gxTpr_Creditovalor_N = (short)(Convert.ToInt16(n857CreditoValor));
         obj95.gxTpr_Creditovigencia_N = (short)(Convert.ToInt16(n858CreditoVigencia));
         obj95.gxTpr_Creditocreatedat_N = (short)(Convert.ToInt16(n859CreditoCreatedAt));
         obj95.gxTpr_Creditoupdatedat_N = (short)(Convert.ToInt16(n860CreditoUpdatedAt));
         obj95.gxTpr_Creditocreatedby_N = (short)(Convert.ToInt16(n861CreditoCreatedBy));
         obj95.gxTpr_Creditoupdatedby_N = (short)(Convert.ToInt16(n862CreditoUpdatedBy));
         obj95.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow95( SdtCredito obj95 )
      {
         obj95.gxTpr_Creditoid = A856CreditoId;
         return  ;
      }

      public void RowToVars95( SdtCredito obj95 ,
                               int forceLoad )
      {
         Gx_mode = obj95.gxTpr_Mode;
         A859CreditoCreatedAt = obj95.gxTpr_Creditocreatedat;
         n859CreditoCreatedAt = false;
         A860CreditoUpdatedAt = obj95.gxTpr_Creditoupdatedat;
         n860CreditoUpdatedAt = false;
         A168ClienteId = obj95.gxTpr_Clienteid;
         n168ClienteId = false;
         A857CreditoValor = obj95.gxTpr_Creditovalor;
         n857CreditoValor = false;
         A858CreditoVigencia = obj95.gxTpr_Creditovigencia;
         n858CreditoVigencia = false;
         A861CreditoCreatedBy = obj95.gxTpr_Creditocreatedby;
         n861CreditoCreatedBy = false;
         A862CreditoUpdatedBy = obj95.gxTpr_Creditoupdatedby;
         n862CreditoUpdatedBy = false;
         A856CreditoId = obj95.gxTpr_Creditoid;
         Z856CreditoId = obj95.gxTpr_Creditoid_Z;
         Z168ClienteId = obj95.gxTpr_Clienteid_Z;
         Z857CreditoValor = obj95.gxTpr_Creditovalor_Z;
         Z858CreditoVigencia = obj95.gxTpr_Creditovigencia_Z;
         Z859CreditoCreatedAt = obj95.gxTpr_Creditocreatedat_Z;
         Z860CreditoUpdatedAt = obj95.gxTpr_Creditoupdatedat_Z;
         Z861CreditoCreatedBy = obj95.gxTpr_Creditocreatedby_Z;
         Z862CreditoUpdatedBy = obj95.gxTpr_Creditoupdatedby_Z;
         n168ClienteId = (bool)(Convert.ToBoolean(obj95.gxTpr_Clienteid_N));
         n857CreditoValor = (bool)(Convert.ToBoolean(obj95.gxTpr_Creditovalor_N));
         n858CreditoVigencia = (bool)(Convert.ToBoolean(obj95.gxTpr_Creditovigencia_N));
         n859CreditoCreatedAt = (bool)(Convert.ToBoolean(obj95.gxTpr_Creditocreatedat_N));
         n860CreditoUpdatedAt = (bool)(Convert.ToBoolean(obj95.gxTpr_Creditoupdatedat_N));
         n861CreditoCreatedBy = (bool)(Convert.ToBoolean(obj95.gxTpr_Creditocreatedby_N));
         n862CreditoUpdatedBy = (bool)(Convert.ToBoolean(obj95.gxTpr_Creditoupdatedby_N));
         Gx_mode = obj95.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A856CreditoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2P95( ) ;
         ScanKeyStart2P95( ) ;
         if ( RcdFound95 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z856CreditoId = A856CreditoId;
         }
         ZM2P95( -8) ;
         OnLoadActions2P95( ) ;
         AddRow2P95( ) ;
         ScanKeyEnd2P95( ) ;
         if ( RcdFound95 == 0 )
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
         RowToVars95( bcCredito, 0) ;
         ScanKeyStart2P95( ) ;
         if ( RcdFound95 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z856CreditoId = A856CreditoId;
         }
         ZM2P95( -8) ;
         OnLoadActions2P95( ) ;
         AddRow2P95( ) ;
         ScanKeyEnd2P95( ) ;
         if ( RcdFound95 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2P95( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2P95( ) ;
         }
         else
         {
            if ( RcdFound95 == 1 )
            {
               if ( A856CreditoId != Z856CreditoId )
               {
                  A856CreditoId = Z856CreditoId;
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
                  Update2P95( ) ;
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
                  if ( A856CreditoId != Z856CreditoId )
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
                        Insert2P95( ) ;
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
                        Insert2P95( ) ;
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
         RowToVars95( bcCredito, 1) ;
         SaveImpl( ) ;
         VarsToRow95( bcCredito) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars95( bcCredito, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2P95( ) ;
         AfterTrn( ) ;
         VarsToRow95( bcCredito) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow95( bcCredito) ;
         }
         else
         {
            SdtCredito auxBC = new SdtCredito(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A856CreditoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCredito);
               auxBC.Save();
               bcCredito.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars95( bcCredito, 1) ;
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
         RowToVars95( bcCredito, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2P95( ) ;
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
               VarsToRow95( bcCredito) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow95( bcCredito) ;
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
         RowToVars95( bcCredito, 0) ;
         GetKey2P95( ) ;
         if ( RcdFound95 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A856CreditoId != Z856CreditoId )
            {
               A856CreditoId = Z856CreditoId;
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
            if ( A856CreditoId != Z856CreditoId )
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
         context.RollbackDataStores("credito_bc",pr_default);
         VarsToRow95( bcCredito) ;
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
         Gx_mode = bcCredito.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCredito.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCredito )
         {
            bcCredito = (SdtCredito)(sdt);
            if ( StringUtil.StrCmp(bcCredito.gxTpr_Mode, "") == 0 )
            {
               bcCredito.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow95( bcCredito) ;
            }
            else
            {
               RowToVars95( bcCredito, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCredito.gxTpr_Mode, "") == 0 )
            {
               bcCredito.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars95( bcCredito, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtCredito Credito_BC
      {
         get {
            return bcCredito ;
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
         AV25Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z859CreditoCreatedAt = (DateTime)(DateTime.MinValue);
         A859CreditoCreatedAt = (DateTime)(DateTime.MinValue);
         Z860CreditoUpdatedAt = (DateTime)(DateTime.MinValue);
         A860CreditoUpdatedAt = (DateTime)(DateTime.MinValue);
         Z858CreditoVigencia = DateTime.MinValue;
         A858CreditoVigencia = DateTime.MinValue;
         BC002P7_A856CreditoId = new int[1] ;
         BC002P7_A859CreditoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002P7_n859CreditoCreatedAt = new bool[] {false} ;
         BC002P7_A860CreditoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002P7_n860CreditoUpdatedAt = new bool[] {false} ;
         BC002P7_A857CreditoValor = new decimal[1] ;
         BC002P7_n857CreditoValor = new bool[] {false} ;
         BC002P7_A858CreditoVigencia = new DateTime[] {DateTime.MinValue} ;
         BC002P7_n858CreditoVigencia = new bool[] {false} ;
         BC002P7_A168ClienteId = new int[1] ;
         BC002P7_n168ClienteId = new bool[] {false} ;
         BC002P7_A861CreditoCreatedBy = new short[1] ;
         BC002P7_n861CreditoCreatedBy = new bool[] {false} ;
         BC002P7_A862CreditoUpdatedBy = new short[1] ;
         BC002P7_n862CreditoUpdatedBy = new bool[] {false} ;
         BC002P4_A168ClienteId = new int[1] ;
         BC002P4_n168ClienteId = new bool[] {false} ;
         BC002P5_A861CreditoCreatedBy = new short[1] ;
         BC002P5_n861CreditoCreatedBy = new bool[] {false} ;
         BC002P6_A862CreditoUpdatedBy = new short[1] ;
         BC002P6_n862CreditoUpdatedBy = new bool[] {false} ;
         BC002P8_A856CreditoId = new int[1] ;
         BC002P3_A856CreditoId = new int[1] ;
         BC002P3_A859CreditoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002P3_n859CreditoCreatedAt = new bool[] {false} ;
         BC002P3_A860CreditoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002P3_n860CreditoUpdatedAt = new bool[] {false} ;
         BC002P3_A857CreditoValor = new decimal[1] ;
         BC002P3_n857CreditoValor = new bool[] {false} ;
         BC002P3_A858CreditoVigencia = new DateTime[] {DateTime.MinValue} ;
         BC002P3_n858CreditoVigencia = new bool[] {false} ;
         BC002P3_A168ClienteId = new int[1] ;
         BC002P3_n168ClienteId = new bool[] {false} ;
         BC002P3_A861CreditoCreatedBy = new short[1] ;
         BC002P3_n861CreditoCreatedBy = new bool[] {false} ;
         BC002P3_A862CreditoUpdatedBy = new short[1] ;
         BC002P3_n862CreditoUpdatedBy = new bool[] {false} ;
         sMode95 = "";
         BC002P2_A856CreditoId = new int[1] ;
         BC002P2_A859CreditoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002P2_n859CreditoCreatedAt = new bool[] {false} ;
         BC002P2_A860CreditoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002P2_n860CreditoUpdatedAt = new bool[] {false} ;
         BC002P2_A857CreditoValor = new decimal[1] ;
         BC002P2_n857CreditoValor = new bool[] {false} ;
         BC002P2_A858CreditoVigencia = new DateTime[] {DateTime.MinValue} ;
         BC002P2_n858CreditoVigencia = new bool[] {false} ;
         BC002P2_A168ClienteId = new int[1] ;
         BC002P2_n168ClienteId = new bool[] {false} ;
         BC002P2_A861CreditoCreatedBy = new short[1] ;
         BC002P2_n861CreditoCreatedBy = new bool[] {false} ;
         BC002P2_A862CreditoUpdatedBy = new short[1] ;
         BC002P2_n862CreditoUpdatedBy = new bool[] {false} ;
         BC002P10_A856CreditoId = new int[1] ;
         BC002P13_A856CreditoId = new int[1] ;
         BC002P13_A859CreditoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002P13_n859CreditoCreatedAt = new bool[] {false} ;
         BC002P13_A860CreditoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002P13_n860CreditoUpdatedAt = new bool[] {false} ;
         BC002P13_A857CreditoValor = new decimal[1] ;
         BC002P13_n857CreditoValor = new bool[] {false} ;
         BC002P13_A858CreditoVigencia = new DateTime[] {DateTime.MinValue} ;
         BC002P13_n858CreditoVigencia = new bool[] {false} ;
         BC002P13_A168ClienteId = new int[1] ;
         BC002P13_n168ClienteId = new bool[] {false} ;
         BC002P13_A861CreditoCreatedBy = new short[1] ;
         BC002P13_n861CreditoCreatedBy = new bool[] {false} ;
         BC002P13_A862CreditoUpdatedBy = new short[1] ;
         BC002P13_n862CreditoUpdatedBy = new bool[] {false} ;
         i859CreditoCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.credito_bc__default(),
            new Object[][] {
                new Object[] {
               BC002P2_A856CreditoId, BC002P2_A859CreditoCreatedAt, BC002P2_n859CreditoCreatedAt, BC002P2_A860CreditoUpdatedAt, BC002P2_n860CreditoUpdatedAt, BC002P2_A857CreditoValor, BC002P2_n857CreditoValor, BC002P2_A858CreditoVigencia, BC002P2_n858CreditoVigencia, BC002P2_A168ClienteId,
               BC002P2_n168ClienteId, BC002P2_A861CreditoCreatedBy, BC002P2_n861CreditoCreatedBy, BC002P2_A862CreditoUpdatedBy, BC002P2_n862CreditoUpdatedBy
               }
               , new Object[] {
               BC002P3_A856CreditoId, BC002P3_A859CreditoCreatedAt, BC002P3_n859CreditoCreatedAt, BC002P3_A860CreditoUpdatedAt, BC002P3_n860CreditoUpdatedAt, BC002P3_A857CreditoValor, BC002P3_n857CreditoValor, BC002P3_A858CreditoVigencia, BC002P3_n858CreditoVigencia, BC002P3_A168ClienteId,
               BC002P3_n168ClienteId, BC002P3_A861CreditoCreatedBy, BC002P3_n861CreditoCreatedBy, BC002P3_A862CreditoUpdatedBy, BC002P3_n862CreditoUpdatedBy
               }
               , new Object[] {
               BC002P4_A168ClienteId
               }
               , new Object[] {
               BC002P5_A861CreditoCreatedBy
               }
               , new Object[] {
               BC002P6_A862CreditoUpdatedBy
               }
               , new Object[] {
               BC002P7_A856CreditoId, BC002P7_A859CreditoCreatedAt, BC002P7_n859CreditoCreatedAt, BC002P7_A860CreditoUpdatedAt, BC002P7_n860CreditoUpdatedAt, BC002P7_A857CreditoValor, BC002P7_n857CreditoValor, BC002P7_A858CreditoVigencia, BC002P7_n858CreditoVigencia, BC002P7_A168ClienteId,
               BC002P7_n168ClienteId, BC002P7_A861CreditoCreatedBy, BC002P7_n861CreditoCreatedBy, BC002P7_A862CreditoUpdatedBy, BC002P7_n862CreditoUpdatedBy
               }
               , new Object[] {
               BC002P8_A856CreditoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002P10_A856CreditoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002P13_A856CreditoId, BC002P13_A859CreditoCreatedAt, BC002P13_n859CreditoCreatedAt, BC002P13_A860CreditoUpdatedAt, BC002P13_n860CreditoUpdatedAt, BC002P13_A857CreditoValor, BC002P13_n857CreditoValor, BC002P13_A858CreditoVigencia, BC002P13_n858CreditoVigencia, BC002P13_A168ClienteId,
               BC002P13_n168ClienteId, BC002P13_A861CreditoCreatedBy, BC002P13_n861CreditoCreatedBy, BC002P13_A862CreditoUpdatedBy, BC002P13_n862CreditoUpdatedBy
               }
            }
         );
         AV25Pgmname = "Credito_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122P2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV12Insert_CreditoCreatedBy ;
      private short AV24Insert_CreditoUpdatedBy ;
      private short Z861CreditoCreatedBy ;
      private short A861CreditoCreatedBy ;
      private short Z862CreditoUpdatedBy ;
      private short A862CreditoUpdatedBy ;
      private short RcdFound95 ;
      private int trnEnded ;
      private int Z856CreditoId ;
      private int A856CreditoId ;
      private int AV26GXV1 ;
      private int AV11Insert_ClienteId ;
      private int Z168ClienteId ;
      private int A168ClienteId ;
      private decimal Z857CreditoValor ;
      private decimal A857CreditoValor ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV25Pgmname ;
      private string sMode95 ;
      private DateTime Z859CreditoCreatedAt ;
      private DateTime A859CreditoCreatedAt ;
      private DateTime Z860CreditoUpdatedAt ;
      private DateTime A860CreditoUpdatedAt ;
      private DateTime i859CreditoCreatedAt ;
      private DateTime Z858CreditoVigencia ;
      private DateTime A858CreditoVigencia ;
      private bool returnInSub ;
      private bool n859CreditoCreatedAt ;
      private bool n860CreditoUpdatedAt ;
      private bool n857CreditoValor ;
      private bool n858CreditoVigencia ;
      private bool n168ClienteId ;
      private bool n861CreditoCreatedBy ;
      private bool n862CreditoUpdatedBy ;
      private bool Gx_longc ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002P7_A856CreditoId ;
      private DateTime[] BC002P7_A859CreditoCreatedAt ;
      private bool[] BC002P7_n859CreditoCreatedAt ;
      private DateTime[] BC002P7_A860CreditoUpdatedAt ;
      private bool[] BC002P7_n860CreditoUpdatedAt ;
      private decimal[] BC002P7_A857CreditoValor ;
      private bool[] BC002P7_n857CreditoValor ;
      private DateTime[] BC002P7_A858CreditoVigencia ;
      private bool[] BC002P7_n858CreditoVigencia ;
      private int[] BC002P7_A168ClienteId ;
      private bool[] BC002P7_n168ClienteId ;
      private short[] BC002P7_A861CreditoCreatedBy ;
      private bool[] BC002P7_n861CreditoCreatedBy ;
      private short[] BC002P7_A862CreditoUpdatedBy ;
      private bool[] BC002P7_n862CreditoUpdatedBy ;
      private int[] BC002P4_A168ClienteId ;
      private bool[] BC002P4_n168ClienteId ;
      private short[] BC002P5_A861CreditoCreatedBy ;
      private bool[] BC002P5_n861CreditoCreatedBy ;
      private short[] BC002P6_A862CreditoUpdatedBy ;
      private bool[] BC002P6_n862CreditoUpdatedBy ;
      private int[] BC002P8_A856CreditoId ;
      private int[] BC002P3_A856CreditoId ;
      private DateTime[] BC002P3_A859CreditoCreatedAt ;
      private bool[] BC002P3_n859CreditoCreatedAt ;
      private DateTime[] BC002P3_A860CreditoUpdatedAt ;
      private bool[] BC002P3_n860CreditoUpdatedAt ;
      private decimal[] BC002P3_A857CreditoValor ;
      private bool[] BC002P3_n857CreditoValor ;
      private DateTime[] BC002P3_A858CreditoVigencia ;
      private bool[] BC002P3_n858CreditoVigencia ;
      private int[] BC002P3_A168ClienteId ;
      private bool[] BC002P3_n168ClienteId ;
      private short[] BC002P3_A861CreditoCreatedBy ;
      private bool[] BC002P3_n861CreditoCreatedBy ;
      private short[] BC002P3_A862CreditoUpdatedBy ;
      private bool[] BC002P3_n862CreditoUpdatedBy ;
      private int[] BC002P2_A856CreditoId ;
      private DateTime[] BC002P2_A859CreditoCreatedAt ;
      private bool[] BC002P2_n859CreditoCreatedAt ;
      private DateTime[] BC002P2_A860CreditoUpdatedAt ;
      private bool[] BC002P2_n860CreditoUpdatedAt ;
      private decimal[] BC002P2_A857CreditoValor ;
      private bool[] BC002P2_n857CreditoValor ;
      private DateTime[] BC002P2_A858CreditoVigencia ;
      private bool[] BC002P2_n858CreditoVigencia ;
      private int[] BC002P2_A168ClienteId ;
      private bool[] BC002P2_n168ClienteId ;
      private short[] BC002P2_A861CreditoCreatedBy ;
      private bool[] BC002P2_n861CreditoCreatedBy ;
      private short[] BC002P2_A862CreditoUpdatedBy ;
      private bool[] BC002P2_n862CreditoUpdatedBy ;
      private int[] BC002P10_A856CreditoId ;
      private int[] BC002P13_A856CreditoId ;
      private DateTime[] BC002P13_A859CreditoCreatedAt ;
      private bool[] BC002P13_n859CreditoCreatedAt ;
      private DateTime[] BC002P13_A860CreditoUpdatedAt ;
      private bool[] BC002P13_n860CreditoUpdatedAt ;
      private decimal[] BC002P13_A857CreditoValor ;
      private bool[] BC002P13_n857CreditoValor ;
      private DateTime[] BC002P13_A858CreditoVigencia ;
      private bool[] BC002P13_n858CreditoVigencia ;
      private int[] BC002P13_A168ClienteId ;
      private bool[] BC002P13_n168ClienteId ;
      private short[] BC002P13_A861CreditoCreatedBy ;
      private bool[] BC002P13_n861CreditoCreatedBy ;
      private short[] BC002P13_A862CreditoUpdatedBy ;
      private bool[] BC002P13_n862CreditoUpdatedBy ;
      private SdtCredito bcCredito ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class credito_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002P2;
          prmBC002P2 = new Object[] {
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmBC002P3;
          prmBC002P3 = new Object[] {
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmBC002P4;
          prmBC002P4 = new Object[] {
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002P5;
          prmBC002P5 = new Object[] {
          new ParDef("CreditoCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002P6;
          prmBC002P6 = new Object[] {
          new ParDef("CreditoUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002P7;
          prmBC002P7 = new Object[] {
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmBC002P8;
          prmBC002P8 = new Object[] {
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmBC002P9;
          prmBC002P9 = new Object[] {
          new ParDef("CreditoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CreditoUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CreditoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("CreditoVigencia",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("CreditoCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("CreditoUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002P10;
          prmBC002P10 = new Object[] {
          };
          Object[] prmBC002P11;
          prmBC002P11 = new Object[] {
          new ParDef("CreditoCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CreditoUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("CreditoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("CreditoVigencia",GXType.Date,8,0){Nullable=true} ,
          new ParDef("ClienteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("CreditoCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("CreditoUpdatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmBC002P12;
          prmBC002P12 = new Object[] {
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          Object[] prmBC002P13;
          prmBC002P13 = new Object[] {
          new ParDef("CreditoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002P2", "SELECT CreditoId, CreditoCreatedAt, CreditoUpdatedAt, CreditoValor, CreditoVigencia, ClienteId, CreditoCreatedBy, CreditoUpdatedBy FROM Credito WHERE CreditoId = :CreditoId  FOR UPDATE OF Credito",true, GxErrorMask.GX_NOMASK, false, this,prmBC002P2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002P3", "SELECT CreditoId, CreditoCreatedAt, CreditoUpdatedAt, CreditoValor, CreditoVigencia, ClienteId, CreditoCreatedBy, CreditoUpdatedBy FROM Credito WHERE CreditoId = :CreditoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002P3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002P4", "SELECT ClienteId FROM Cliente WHERE ClienteId = :ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002P4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002P5", "SELECT SecUserId AS CreditoCreatedBy FROM SecUser WHERE SecUserId = :CreditoCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002P5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002P6", "SELECT SecUserId AS CreditoUpdatedBy FROM SecUser WHERE SecUserId = :CreditoUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002P6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002P7", "SELECT TM1.CreditoId, TM1.CreditoCreatedAt, TM1.CreditoUpdatedAt, TM1.CreditoValor, TM1.CreditoVigencia, TM1.ClienteId, TM1.CreditoCreatedBy AS CreditoCreatedBy, TM1.CreditoUpdatedBy AS CreditoUpdatedBy FROM Credito TM1 WHERE TM1.CreditoId = :CreditoId ORDER BY TM1.CreditoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002P7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002P8", "SELECT CreditoId FROM Credito WHERE CreditoId = :CreditoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002P8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002P9", "SAVEPOINT gxupdate;INSERT INTO Credito(CreditoCreatedAt, CreditoUpdatedAt, CreditoValor, CreditoVigencia, ClienteId, CreditoCreatedBy, CreditoUpdatedBy) VALUES(:CreditoCreatedAt, :CreditoUpdatedAt, :CreditoValor, :CreditoVigencia, :ClienteId, :CreditoCreatedBy, :CreditoUpdatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002P9)
             ,new CursorDef("BC002P10", "SELECT currval('CreditoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002P10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002P11", "SAVEPOINT gxupdate;UPDATE Credito SET CreditoCreatedAt=:CreditoCreatedAt, CreditoUpdatedAt=:CreditoUpdatedAt, CreditoValor=:CreditoValor, CreditoVigencia=:CreditoVigencia, ClienteId=:ClienteId, CreditoCreatedBy=:CreditoCreatedBy, CreditoUpdatedBy=:CreditoUpdatedBy  WHERE CreditoId = :CreditoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002P11)
             ,new CursorDef("BC002P12", "SAVEPOINT gxupdate;DELETE FROM Credito  WHERE CreditoId = :CreditoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002P12)
             ,new CursorDef("BC002P13", "SELECT TM1.CreditoId, TM1.CreditoCreatedAt, TM1.CreditoUpdatedAt, TM1.CreditoValor, TM1.CreditoVigencia, TM1.ClienteId, TM1.CreditoCreatedBy AS CreditoCreatedBy, TM1.CreditoUpdatedBy AS CreditoUpdatedBy FROM Credito TM1 WHERE TM1.CreditoId = :CreditoId ORDER BY TM1.CreditoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002P13,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
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
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
