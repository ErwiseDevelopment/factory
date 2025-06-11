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
   public class especialidade_bc : GxSilentTrn, IGxSilentTrn
   {
      public especialidade_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public especialidade_bc( IGxContext context )
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
         ReadRow1T67( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1T67( ) ;
         standaloneModal( ) ;
         AddRow1T67( ) ;
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
            E111T2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z457EspecialidadeId = A457EspecialidadeId;
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

      protected void CONFIRM_1T0( )
      {
         BeforeValidate1T67( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1T67( ) ;
            }
            else
            {
               CheckExtendedTable1T67( ) ;
               if ( AnyError == 0 )
               {
                  ZM1T67( 9) ;
               }
               CloseExtendedTableCursors1T67( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121T2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "EspecialidadeCreatedBy") == 0 )
               {
                  AV11Insert_EspecialidadeCreatedBy = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
            }
         }
      }

      protected void E111T2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1T67( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z596EspecialidadeCreatedAt = A596EspecialidadeCreatedAt;
            Z598EspecialidadeUpdatedAt = A598EspecialidadeUpdatedAt;
            Z458EspecialidadeNome = A458EspecialidadeNome;
            Z595EspecialidadeStatus = A595EspecialidadeStatus;
            Z597EspecialidadeCreatedBy = A597EspecialidadeCreatedBy;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -8 )
         {
            Z457EspecialidadeId = A457EspecialidadeId;
            Z596EspecialidadeCreatedAt = A596EspecialidadeCreatedAt;
            Z598EspecialidadeUpdatedAt = A598EspecialidadeUpdatedAt;
            Z458EspecialidadeNome = A458EspecialidadeNome;
            Z595EspecialidadeStatus = A595EspecialidadeStatus;
            Z597EspecialidadeCreatedBy = A597EspecialidadeCreatedBy;
         }
      }

      protected void standaloneNotModal( )
      {
         AV14Pgmname = "Especialidade_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            A598EspecialidadeUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n598EspecialidadeUpdatedAt = false;
         }
         else
         {
            A598EspecialidadeUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n598EspecialidadeUpdatedAt = false;
         }
         if ( IsIns( )  )
         {
            A596EspecialidadeCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n596EspecialidadeCreatedAt = false;
         }
         else
         {
            if ( IsIns( )  && (DateTime.MinValue==A596EspecialidadeCreatedAt) && ( Gx_BScreen == 0 ) )
            {
               A596EspecialidadeCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
               n596EspecialidadeCreatedAt = false;
            }
         }
         if ( IsIns( )  && (false==A595EspecialidadeStatus) && ( Gx_BScreen == 0 ) )
         {
            A595EspecialidadeStatus = true;
            n595EspecialidadeStatus = false;
         }
      }

      protected void Load1T67( )
      {
         /* Using cursor BC001T5 */
         pr_default.execute(3, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound67 = 1;
            A596EspecialidadeCreatedAt = BC001T5_A596EspecialidadeCreatedAt[0];
            n596EspecialidadeCreatedAt = BC001T5_n596EspecialidadeCreatedAt[0];
            A598EspecialidadeUpdatedAt = BC001T5_A598EspecialidadeUpdatedAt[0];
            n598EspecialidadeUpdatedAt = BC001T5_n598EspecialidadeUpdatedAt[0];
            A458EspecialidadeNome = BC001T5_A458EspecialidadeNome[0];
            n458EspecialidadeNome = BC001T5_n458EspecialidadeNome[0];
            A595EspecialidadeStatus = BC001T5_A595EspecialidadeStatus[0];
            n595EspecialidadeStatus = BC001T5_n595EspecialidadeStatus[0];
            A597EspecialidadeCreatedBy = BC001T5_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = BC001T5_n597EspecialidadeCreatedBy[0];
            ZM1T67( -8) ;
         }
         pr_default.close(3);
         OnLoadActions1T67( ) ;
      }

      protected void OnLoadActions1T67( )
      {
         if ( (0==A597EspecialidadeCreatedBy) )
         {
            A597EspecialidadeCreatedBy = 0;
            n597EspecialidadeCreatedBy = false;
            n597EspecialidadeCreatedBy = true;
            n597EspecialidadeCreatedBy = true;
         }
         else
         {
            if ( IsIns( )  && (0==A597EspecialidadeCreatedBy) && ( Gx_BScreen == 0 ) )
            {
               A597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
               n597EspecialidadeCreatedBy = false;
            }
         }
      }

      protected void CheckExtendedTable1T67( )
      {
         standaloneModal( ) ;
         if ( (0==A597EspecialidadeCreatedBy) )
         {
            A597EspecialidadeCreatedBy = 0;
            n597EspecialidadeCreatedBy = false;
            n597EspecialidadeCreatedBy = true;
            n597EspecialidadeCreatedBy = true;
         }
         else
         {
            if ( IsIns( )  && (0==A597EspecialidadeCreatedBy) && ( Gx_BScreen == 0 ) )
            {
               A597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
               n597EspecialidadeCreatedBy = false;
            }
         }
         /* Using cursor BC001T4 */
         pr_default.execute(2, new Object[] {n597EspecialidadeCreatedBy, A597EspecialidadeCreatedBy});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A597EspecialidadeCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Especialidade Created By'.", "ForeignKeyNotFound", 1, "ESPECIALIDADECREATEDBY");
               AnyError = 1;
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1T67( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1T67( )
      {
         /* Using cursor BC001T6 */
         pr_default.execute(4, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound67 = 1;
         }
         else
         {
            RcdFound67 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001T3 */
         pr_default.execute(1, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1T67( 8) ;
            RcdFound67 = 1;
            A457EspecialidadeId = BC001T3_A457EspecialidadeId[0];
            n457EspecialidadeId = BC001T3_n457EspecialidadeId[0];
            A596EspecialidadeCreatedAt = BC001T3_A596EspecialidadeCreatedAt[0];
            n596EspecialidadeCreatedAt = BC001T3_n596EspecialidadeCreatedAt[0];
            A598EspecialidadeUpdatedAt = BC001T3_A598EspecialidadeUpdatedAt[0];
            n598EspecialidadeUpdatedAt = BC001T3_n598EspecialidadeUpdatedAt[0];
            A458EspecialidadeNome = BC001T3_A458EspecialidadeNome[0];
            n458EspecialidadeNome = BC001T3_n458EspecialidadeNome[0];
            A595EspecialidadeStatus = BC001T3_A595EspecialidadeStatus[0];
            n595EspecialidadeStatus = BC001T3_n595EspecialidadeStatus[0];
            A597EspecialidadeCreatedBy = BC001T3_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = BC001T3_n597EspecialidadeCreatedBy[0];
            Z457EspecialidadeId = A457EspecialidadeId;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1T67( ) ;
            if ( AnyError == 1 )
            {
               RcdFound67 = 0;
               InitializeNonKey1T67( ) ;
            }
            Gx_mode = sMode67;
         }
         else
         {
            RcdFound67 = 0;
            InitializeNonKey1T67( ) ;
            sMode67 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode67;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1T67( ) ;
         if ( RcdFound67 == 0 )
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
         CONFIRM_1T0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1T67( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001T2 */
            pr_default.execute(0, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Especialidade"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z596EspecialidadeCreatedAt != BC001T2_A596EspecialidadeCreatedAt[0] ) || ( Z598EspecialidadeUpdatedAt != BC001T2_A598EspecialidadeUpdatedAt[0] ) || ( StringUtil.StrCmp(Z458EspecialidadeNome, BC001T2_A458EspecialidadeNome[0]) != 0 ) || ( Z595EspecialidadeStatus != BC001T2_A595EspecialidadeStatus[0] ) || ( Z597EspecialidadeCreatedBy != BC001T2_A597EspecialidadeCreatedBy[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Especialidade"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1T67( )
      {
         BeforeValidate1T67( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T67( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1T67( 0) ;
            CheckOptimisticConcurrency1T67( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T67( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1T67( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001T7 */
                     pr_default.execute(5, new Object[] {n596EspecialidadeCreatedAt, A596EspecialidadeCreatedAt, n598EspecialidadeUpdatedAt, A598EspecialidadeUpdatedAt, n458EspecialidadeNome, A458EspecialidadeNome, n595EspecialidadeStatus, A595EspecialidadeStatus, n597EspecialidadeCreatedBy, A597EspecialidadeCreatedBy});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001T8 */
                     pr_default.execute(6);
                     A457EspecialidadeId = BC001T8_A457EspecialidadeId[0];
                     n457EspecialidadeId = BC001T8_n457EspecialidadeId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Especialidade");
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
               Load1T67( ) ;
            }
            EndLevel1T67( ) ;
         }
         CloseExtendedTableCursors1T67( ) ;
      }

      protected void Update1T67( )
      {
         BeforeValidate1T67( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T67( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T67( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T67( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1T67( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001T9 */
                     pr_default.execute(7, new Object[] {n596EspecialidadeCreatedAt, A596EspecialidadeCreatedAt, n598EspecialidadeUpdatedAt, A598EspecialidadeUpdatedAt, n458EspecialidadeNome, A458EspecialidadeNome, n595EspecialidadeStatus, A595EspecialidadeStatus, n597EspecialidadeCreatedBy, A597EspecialidadeCreatedBy, n457EspecialidadeId, A457EspecialidadeId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Especialidade");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Especialidade"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1T67( ) ;
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
            EndLevel1T67( ) ;
         }
         CloseExtendedTableCursors1T67( ) ;
      }

      protected void DeferredUpdate1T67( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1T67( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T67( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1T67( ) ;
            AfterConfirm1T67( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1T67( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001T10 */
                  pr_default.execute(8, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Especialidade");
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
         sMode67 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1T67( ) ;
         Gx_mode = sMode67;
      }

      protected void OnDeleteControls1T67( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001T11 */
            pr_default.execute(9, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1T67( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1T67( ) ;
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

      public void ScanKeyStart1T67( )
      {
         /* Scan By routine */
         /* Using cursor BC001T12 */
         pr_default.execute(10, new Object[] {n457EspecialidadeId, A457EspecialidadeId});
         RcdFound67 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound67 = 1;
            A457EspecialidadeId = BC001T12_A457EspecialidadeId[0];
            n457EspecialidadeId = BC001T12_n457EspecialidadeId[0];
            A596EspecialidadeCreatedAt = BC001T12_A596EspecialidadeCreatedAt[0];
            n596EspecialidadeCreatedAt = BC001T12_n596EspecialidadeCreatedAt[0];
            A598EspecialidadeUpdatedAt = BC001T12_A598EspecialidadeUpdatedAt[0];
            n598EspecialidadeUpdatedAt = BC001T12_n598EspecialidadeUpdatedAt[0];
            A458EspecialidadeNome = BC001T12_A458EspecialidadeNome[0];
            n458EspecialidadeNome = BC001T12_n458EspecialidadeNome[0];
            A595EspecialidadeStatus = BC001T12_A595EspecialidadeStatus[0];
            n595EspecialidadeStatus = BC001T12_n595EspecialidadeStatus[0];
            A597EspecialidadeCreatedBy = BC001T12_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = BC001T12_n597EspecialidadeCreatedBy[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1T67( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound67 = 0;
         ScanKeyLoad1T67( ) ;
      }

      protected void ScanKeyLoad1T67( )
      {
         sMode67 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound67 = 1;
            A457EspecialidadeId = BC001T12_A457EspecialidadeId[0];
            n457EspecialidadeId = BC001T12_n457EspecialidadeId[0];
            A596EspecialidadeCreatedAt = BC001T12_A596EspecialidadeCreatedAt[0];
            n596EspecialidadeCreatedAt = BC001T12_n596EspecialidadeCreatedAt[0];
            A598EspecialidadeUpdatedAt = BC001T12_A598EspecialidadeUpdatedAt[0];
            n598EspecialidadeUpdatedAt = BC001T12_n598EspecialidadeUpdatedAt[0];
            A458EspecialidadeNome = BC001T12_A458EspecialidadeNome[0];
            n458EspecialidadeNome = BC001T12_n458EspecialidadeNome[0];
            A595EspecialidadeStatus = BC001T12_A595EspecialidadeStatus[0];
            n595EspecialidadeStatus = BC001T12_n595EspecialidadeStatus[0];
            A597EspecialidadeCreatedBy = BC001T12_A597EspecialidadeCreatedBy[0];
            n597EspecialidadeCreatedBy = BC001T12_n597EspecialidadeCreatedBy[0];
         }
         Gx_mode = sMode67;
      }

      protected void ScanKeyEnd1T67( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1T67( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1T67( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1T67( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1T67( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1T67( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1T67( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1T67( )
      {
      }

      protected void send_integrity_lvl_hashes1T67( )
      {
      }

      protected void AddRow1T67( )
      {
         VarsToRow67( bcEspecialidade) ;
      }

      protected void ReadRow1T67( )
      {
         RowToVars67( bcEspecialidade, 1) ;
      }

      protected void InitializeNonKey1T67( )
      {
         A596EspecialidadeCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n596EspecialidadeCreatedAt = false;
         A598EspecialidadeUpdatedAt = (DateTime)(DateTime.MinValue);
         n598EspecialidadeUpdatedAt = false;
         A458EspecialidadeNome = "";
         n458EspecialidadeNome = false;
         A595EspecialidadeStatus = true;
         n595EspecialidadeStatus = false;
         A597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
         n597EspecialidadeCreatedBy = false;
         Z596EspecialidadeCreatedAt = (DateTime)(DateTime.MinValue);
         Z598EspecialidadeUpdatedAt = (DateTime)(DateTime.MinValue);
         Z458EspecialidadeNome = "";
         Z595EspecialidadeStatus = false;
         Z597EspecialidadeCreatedBy = 0;
      }

      protected void InitAll1T67( )
      {
         A457EspecialidadeId = 0;
         n457EspecialidadeId = false;
         InitializeNonKey1T67( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A596EspecialidadeCreatedAt = i596EspecialidadeCreatedAt;
         n596EspecialidadeCreatedAt = false;
         A595EspecialidadeStatus = i595EspecialidadeStatus;
         n595EspecialidadeStatus = false;
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

      public void VarsToRow67( SdtEspecialidade obj67 )
      {
         obj67.gxTpr_Mode = Gx_mode;
         obj67.gxTpr_Especialidadecreatedat = A596EspecialidadeCreatedAt;
         obj67.gxTpr_Especialidadeupdatedat = A598EspecialidadeUpdatedAt;
         obj67.gxTpr_Especialidadenome = A458EspecialidadeNome;
         obj67.gxTpr_Especialidadestatus = A595EspecialidadeStatus;
         obj67.gxTpr_Especialidadecreatedby = A597EspecialidadeCreatedBy;
         obj67.gxTpr_Especialidadeid = A457EspecialidadeId;
         obj67.gxTpr_Especialidadeid_Z = Z457EspecialidadeId;
         obj67.gxTpr_Especialidadenome_Z = Z458EspecialidadeNome;
         obj67.gxTpr_Especialidadestatus_Z = Z595EspecialidadeStatus;
         obj67.gxTpr_Especialidadeupdatedat_Z = Z598EspecialidadeUpdatedAt;
         obj67.gxTpr_Especialidadecreatedat_Z = Z596EspecialidadeCreatedAt;
         obj67.gxTpr_Especialidadecreatedby_Z = Z597EspecialidadeCreatedBy;
         obj67.gxTpr_Especialidadeid_N = (short)(Convert.ToInt16(n457EspecialidadeId));
         obj67.gxTpr_Especialidadenome_N = (short)(Convert.ToInt16(n458EspecialidadeNome));
         obj67.gxTpr_Especialidadestatus_N = (short)(Convert.ToInt16(n595EspecialidadeStatus));
         obj67.gxTpr_Especialidadeupdatedat_N = (short)(Convert.ToInt16(n598EspecialidadeUpdatedAt));
         obj67.gxTpr_Especialidadecreatedat_N = (short)(Convert.ToInt16(n596EspecialidadeCreatedAt));
         obj67.gxTpr_Especialidadecreatedby_N = (short)(Convert.ToInt16(n597EspecialidadeCreatedBy));
         obj67.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow67( SdtEspecialidade obj67 )
      {
         obj67.gxTpr_Especialidadeid = A457EspecialidadeId;
         return  ;
      }

      public void RowToVars67( SdtEspecialidade obj67 ,
                               int forceLoad )
      {
         Gx_mode = obj67.gxTpr_Mode;
         A596EspecialidadeCreatedAt = obj67.gxTpr_Especialidadecreatedat;
         n596EspecialidadeCreatedAt = false;
         A598EspecialidadeUpdatedAt = obj67.gxTpr_Especialidadeupdatedat;
         n598EspecialidadeUpdatedAt = false;
         A458EspecialidadeNome = obj67.gxTpr_Especialidadenome;
         n458EspecialidadeNome = false;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A595EspecialidadeStatus = obj67.gxTpr_Especialidadestatus;
            n595EspecialidadeStatus = false;
         }
         A597EspecialidadeCreatedBy = obj67.gxTpr_Especialidadecreatedby;
         n597EspecialidadeCreatedBy = false;
         A457EspecialidadeId = obj67.gxTpr_Especialidadeid;
         n457EspecialidadeId = false;
         Z457EspecialidadeId = obj67.gxTpr_Especialidadeid_Z;
         Z458EspecialidadeNome = obj67.gxTpr_Especialidadenome_Z;
         Z595EspecialidadeStatus = obj67.gxTpr_Especialidadestatus_Z;
         Z598EspecialidadeUpdatedAt = obj67.gxTpr_Especialidadeupdatedat_Z;
         Z596EspecialidadeCreatedAt = obj67.gxTpr_Especialidadecreatedat_Z;
         Z597EspecialidadeCreatedBy = obj67.gxTpr_Especialidadecreatedby_Z;
         n457EspecialidadeId = (bool)(Convert.ToBoolean(obj67.gxTpr_Especialidadeid_N));
         n458EspecialidadeNome = (bool)(Convert.ToBoolean(obj67.gxTpr_Especialidadenome_N));
         n595EspecialidadeStatus = (bool)(Convert.ToBoolean(obj67.gxTpr_Especialidadestatus_N));
         n598EspecialidadeUpdatedAt = (bool)(Convert.ToBoolean(obj67.gxTpr_Especialidadeupdatedat_N));
         n596EspecialidadeCreatedAt = (bool)(Convert.ToBoolean(obj67.gxTpr_Especialidadecreatedat_N));
         n597EspecialidadeCreatedBy = (bool)(Convert.ToBoolean(obj67.gxTpr_Especialidadecreatedby_N));
         Gx_mode = obj67.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A457EspecialidadeId = (int)getParm(obj,0);
         n457EspecialidadeId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1T67( ) ;
         ScanKeyStart1T67( ) ;
         if ( RcdFound67 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z457EspecialidadeId = A457EspecialidadeId;
         }
         ZM1T67( -8) ;
         OnLoadActions1T67( ) ;
         AddRow1T67( ) ;
         ScanKeyEnd1T67( ) ;
         if ( RcdFound67 == 0 )
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
         RowToVars67( bcEspecialidade, 0) ;
         ScanKeyStart1T67( ) ;
         if ( RcdFound67 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z457EspecialidadeId = A457EspecialidadeId;
         }
         ZM1T67( -8) ;
         OnLoadActions1T67( ) ;
         AddRow1T67( ) ;
         ScanKeyEnd1T67( ) ;
         if ( RcdFound67 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1T67( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1T67( ) ;
         }
         else
         {
            if ( RcdFound67 == 1 )
            {
               if ( A457EspecialidadeId != Z457EspecialidadeId )
               {
                  A457EspecialidadeId = Z457EspecialidadeId;
                  n457EspecialidadeId = false;
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
                  Update1T67( ) ;
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
                  if ( A457EspecialidadeId != Z457EspecialidadeId )
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
                        Insert1T67( ) ;
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
                        Insert1T67( ) ;
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
         RowToVars67( bcEspecialidade, 1) ;
         SaveImpl( ) ;
         VarsToRow67( bcEspecialidade) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars67( bcEspecialidade, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1T67( ) ;
         AfterTrn( ) ;
         VarsToRow67( bcEspecialidade) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow67( bcEspecialidade) ;
         }
         else
         {
            SdtEspecialidade auxBC = new SdtEspecialidade(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A457EspecialidadeId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEspecialidade);
               auxBC.Save();
               bcEspecialidade.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars67( bcEspecialidade, 1) ;
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
         RowToVars67( bcEspecialidade, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1T67( ) ;
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
               VarsToRow67( bcEspecialidade) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow67( bcEspecialidade) ;
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
         RowToVars67( bcEspecialidade, 0) ;
         GetKey1T67( ) ;
         if ( RcdFound67 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A457EspecialidadeId != Z457EspecialidadeId )
            {
               A457EspecialidadeId = Z457EspecialidadeId;
               n457EspecialidadeId = false;
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
            if ( A457EspecialidadeId != Z457EspecialidadeId )
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
         context.RollbackDataStores("especialidade_bc",pr_default);
         VarsToRow67( bcEspecialidade) ;
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
         Gx_mode = bcEspecialidade.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEspecialidade.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEspecialidade )
         {
            bcEspecialidade = (SdtEspecialidade)(sdt);
            if ( StringUtil.StrCmp(bcEspecialidade.gxTpr_Mode, "") == 0 )
            {
               bcEspecialidade.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow67( bcEspecialidade) ;
            }
            else
            {
               RowToVars67( bcEspecialidade, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEspecialidade.gxTpr_Mode, "") == 0 )
            {
               bcEspecialidade.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars67( bcEspecialidade, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtEspecialidade Especialidade_BC
      {
         get {
            return bcEspecialidade ;
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
         AV14Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z596EspecialidadeCreatedAt = (DateTime)(DateTime.MinValue);
         A596EspecialidadeCreatedAt = (DateTime)(DateTime.MinValue);
         Z598EspecialidadeUpdatedAt = (DateTime)(DateTime.MinValue);
         A598EspecialidadeUpdatedAt = (DateTime)(DateTime.MinValue);
         Z458EspecialidadeNome = "";
         A458EspecialidadeNome = "";
         BC001T5_A457EspecialidadeId = new int[1] ;
         BC001T5_n457EspecialidadeId = new bool[] {false} ;
         BC001T5_A596EspecialidadeCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001T5_n596EspecialidadeCreatedAt = new bool[] {false} ;
         BC001T5_A598EspecialidadeUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001T5_n598EspecialidadeUpdatedAt = new bool[] {false} ;
         BC001T5_A458EspecialidadeNome = new string[] {""} ;
         BC001T5_n458EspecialidadeNome = new bool[] {false} ;
         BC001T5_A595EspecialidadeStatus = new bool[] {false} ;
         BC001T5_n595EspecialidadeStatus = new bool[] {false} ;
         BC001T5_A597EspecialidadeCreatedBy = new short[1] ;
         BC001T5_n597EspecialidadeCreatedBy = new bool[] {false} ;
         BC001T4_A597EspecialidadeCreatedBy = new short[1] ;
         BC001T4_n597EspecialidadeCreatedBy = new bool[] {false} ;
         BC001T6_A457EspecialidadeId = new int[1] ;
         BC001T6_n457EspecialidadeId = new bool[] {false} ;
         BC001T3_A457EspecialidadeId = new int[1] ;
         BC001T3_n457EspecialidadeId = new bool[] {false} ;
         BC001T3_A596EspecialidadeCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001T3_n596EspecialidadeCreatedAt = new bool[] {false} ;
         BC001T3_A598EspecialidadeUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001T3_n598EspecialidadeUpdatedAt = new bool[] {false} ;
         BC001T3_A458EspecialidadeNome = new string[] {""} ;
         BC001T3_n458EspecialidadeNome = new bool[] {false} ;
         BC001T3_A595EspecialidadeStatus = new bool[] {false} ;
         BC001T3_n595EspecialidadeStatus = new bool[] {false} ;
         BC001T3_A597EspecialidadeCreatedBy = new short[1] ;
         BC001T3_n597EspecialidadeCreatedBy = new bool[] {false} ;
         sMode67 = "";
         BC001T2_A457EspecialidadeId = new int[1] ;
         BC001T2_n457EspecialidadeId = new bool[] {false} ;
         BC001T2_A596EspecialidadeCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001T2_n596EspecialidadeCreatedAt = new bool[] {false} ;
         BC001T2_A598EspecialidadeUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001T2_n598EspecialidadeUpdatedAt = new bool[] {false} ;
         BC001T2_A458EspecialidadeNome = new string[] {""} ;
         BC001T2_n458EspecialidadeNome = new bool[] {false} ;
         BC001T2_A595EspecialidadeStatus = new bool[] {false} ;
         BC001T2_n595EspecialidadeStatus = new bool[] {false} ;
         BC001T2_A597EspecialidadeCreatedBy = new short[1] ;
         BC001T2_n597EspecialidadeCreatedBy = new bool[] {false} ;
         BC001T8_A457EspecialidadeId = new int[1] ;
         BC001T8_n457EspecialidadeId = new bool[] {false} ;
         BC001T11_A168ClienteId = new int[1] ;
         BC001T12_A457EspecialidadeId = new int[1] ;
         BC001T12_n457EspecialidadeId = new bool[] {false} ;
         BC001T12_A596EspecialidadeCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001T12_n596EspecialidadeCreatedAt = new bool[] {false} ;
         BC001T12_A598EspecialidadeUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001T12_n598EspecialidadeUpdatedAt = new bool[] {false} ;
         BC001T12_A458EspecialidadeNome = new string[] {""} ;
         BC001T12_n458EspecialidadeNome = new bool[] {false} ;
         BC001T12_A595EspecialidadeStatus = new bool[] {false} ;
         BC001T12_n595EspecialidadeStatus = new bool[] {false} ;
         BC001T12_A597EspecialidadeCreatedBy = new short[1] ;
         BC001T12_n597EspecialidadeCreatedBy = new bool[] {false} ;
         i596EspecialidadeCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.especialidade_bc__default(),
            new Object[][] {
                new Object[] {
               BC001T2_A457EspecialidadeId, BC001T2_A596EspecialidadeCreatedAt, BC001T2_n596EspecialidadeCreatedAt, BC001T2_A598EspecialidadeUpdatedAt, BC001T2_n598EspecialidadeUpdatedAt, BC001T2_A458EspecialidadeNome, BC001T2_n458EspecialidadeNome, BC001T2_A595EspecialidadeStatus, BC001T2_n595EspecialidadeStatus, BC001T2_A597EspecialidadeCreatedBy,
               BC001T2_n597EspecialidadeCreatedBy
               }
               , new Object[] {
               BC001T3_A457EspecialidadeId, BC001T3_A596EspecialidadeCreatedAt, BC001T3_n596EspecialidadeCreatedAt, BC001T3_A598EspecialidadeUpdatedAt, BC001T3_n598EspecialidadeUpdatedAt, BC001T3_A458EspecialidadeNome, BC001T3_n458EspecialidadeNome, BC001T3_A595EspecialidadeStatus, BC001T3_n595EspecialidadeStatus, BC001T3_A597EspecialidadeCreatedBy,
               BC001T3_n597EspecialidadeCreatedBy
               }
               , new Object[] {
               BC001T4_A597EspecialidadeCreatedBy
               }
               , new Object[] {
               BC001T5_A457EspecialidadeId, BC001T5_A596EspecialidadeCreatedAt, BC001T5_n596EspecialidadeCreatedAt, BC001T5_A598EspecialidadeUpdatedAt, BC001T5_n598EspecialidadeUpdatedAt, BC001T5_A458EspecialidadeNome, BC001T5_n458EspecialidadeNome, BC001T5_A595EspecialidadeStatus, BC001T5_n595EspecialidadeStatus, BC001T5_A597EspecialidadeCreatedBy,
               BC001T5_n597EspecialidadeCreatedBy
               }
               , new Object[] {
               BC001T6_A457EspecialidadeId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001T8_A457EspecialidadeId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001T11_A168ClienteId
               }
               , new Object[] {
               BC001T12_A457EspecialidadeId, BC001T12_A596EspecialidadeCreatedAt, BC001T12_n596EspecialidadeCreatedAt, BC001T12_A598EspecialidadeUpdatedAt, BC001T12_n598EspecialidadeUpdatedAt, BC001T12_A458EspecialidadeNome, BC001T12_n458EspecialidadeNome, BC001T12_A595EspecialidadeStatus, BC001T12_n595EspecialidadeStatus, BC001T12_A597EspecialidadeCreatedBy,
               BC001T12_n597EspecialidadeCreatedBy
               }
            }
         );
         AV14Pgmname = "Especialidade_BC";
         Z597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
         n597EspecialidadeCreatedBy = false;
         A597EspecialidadeCreatedBy = AV8WWPContext.gxTpr_Userid;
         n597EspecialidadeCreatedBy = false;
         Z596EspecialidadeCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n596EspecialidadeCreatedAt = false;
         A596EspecialidadeCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n596EspecialidadeCreatedAt = false;
         i596EspecialidadeCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n596EspecialidadeCreatedAt = false;
         Z595EspecialidadeStatus = true;
         n595EspecialidadeStatus = false;
         A595EspecialidadeStatus = true;
         n595EspecialidadeStatus = false;
         i595EspecialidadeStatus = true;
         n595EspecialidadeStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121T2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV11Insert_EspecialidadeCreatedBy ;
      private short Z597EspecialidadeCreatedBy ;
      private short A597EspecialidadeCreatedBy ;
      private short Gx_BScreen ;
      private short RcdFound67 ;
      private int trnEnded ;
      private int Z457EspecialidadeId ;
      private int A457EspecialidadeId ;
      private int AV15GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV14Pgmname ;
      private string sMode67 ;
      private DateTime Z596EspecialidadeCreatedAt ;
      private DateTime A596EspecialidadeCreatedAt ;
      private DateTime Z598EspecialidadeUpdatedAt ;
      private DateTime A598EspecialidadeUpdatedAt ;
      private DateTime i596EspecialidadeCreatedAt ;
      private bool returnInSub ;
      private bool Z595EspecialidadeStatus ;
      private bool A595EspecialidadeStatus ;
      private bool n598EspecialidadeUpdatedAt ;
      private bool n596EspecialidadeCreatedAt ;
      private bool n595EspecialidadeStatus ;
      private bool n457EspecialidadeId ;
      private bool n458EspecialidadeNome ;
      private bool n597EspecialidadeCreatedBy ;
      private bool i595EspecialidadeStatus ;
      private string Z458EspecialidadeNome ;
      private string A458EspecialidadeNome ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC001T5_A457EspecialidadeId ;
      private bool[] BC001T5_n457EspecialidadeId ;
      private DateTime[] BC001T5_A596EspecialidadeCreatedAt ;
      private bool[] BC001T5_n596EspecialidadeCreatedAt ;
      private DateTime[] BC001T5_A598EspecialidadeUpdatedAt ;
      private bool[] BC001T5_n598EspecialidadeUpdatedAt ;
      private string[] BC001T5_A458EspecialidadeNome ;
      private bool[] BC001T5_n458EspecialidadeNome ;
      private bool[] BC001T5_A595EspecialidadeStatus ;
      private bool[] BC001T5_n595EspecialidadeStatus ;
      private short[] BC001T5_A597EspecialidadeCreatedBy ;
      private bool[] BC001T5_n597EspecialidadeCreatedBy ;
      private short[] BC001T4_A597EspecialidadeCreatedBy ;
      private bool[] BC001T4_n597EspecialidadeCreatedBy ;
      private int[] BC001T6_A457EspecialidadeId ;
      private bool[] BC001T6_n457EspecialidadeId ;
      private int[] BC001T3_A457EspecialidadeId ;
      private bool[] BC001T3_n457EspecialidadeId ;
      private DateTime[] BC001T3_A596EspecialidadeCreatedAt ;
      private bool[] BC001T3_n596EspecialidadeCreatedAt ;
      private DateTime[] BC001T3_A598EspecialidadeUpdatedAt ;
      private bool[] BC001T3_n598EspecialidadeUpdatedAt ;
      private string[] BC001T3_A458EspecialidadeNome ;
      private bool[] BC001T3_n458EspecialidadeNome ;
      private bool[] BC001T3_A595EspecialidadeStatus ;
      private bool[] BC001T3_n595EspecialidadeStatus ;
      private short[] BC001T3_A597EspecialidadeCreatedBy ;
      private bool[] BC001T3_n597EspecialidadeCreatedBy ;
      private int[] BC001T2_A457EspecialidadeId ;
      private bool[] BC001T2_n457EspecialidadeId ;
      private DateTime[] BC001T2_A596EspecialidadeCreatedAt ;
      private bool[] BC001T2_n596EspecialidadeCreatedAt ;
      private DateTime[] BC001T2_A598EspecialidadeUpdatedAt ;
      private bool[] BC001T2_n598EspecialidadeUpdatedAt ;
      private string[] BC001T2_A458EspecialidadeNome ;
      private bool[] BC001T2_n458EspecialidadeNome ;
      private bool[] BC001T2_A595EspecialidadeStatus ;
      private bool[] BC001T2_n595EspecialidadeStatus ;
      private short[] BC001T2_A597EspecialidadeCreatedBy ;
      private bool[] BC001T2_n597EspecialidadeCreatedBy ;
      private int[] BC001T8_A457EspecialidadeId ;
      private bool[] BC001T8_n457EspecialidadeId ;
      private int[] BC001T11_A168ClienteId ;
      private int[] BC001T12_A457EspecialidadeId ;
      private bool[] BC001T12_n457EspecialidadeId ;
      private DateTime[] BC001T12_A596EspecialidadeCreatedAt ;
      private bool[] BC001T12_n596EspecialidadeCreatedAt ;
      private DateTime[] BC001T12_A598EspecialidadeUpdatedAt ;
      private bool[] BC001T12_n598EspecialidadeUpdatedAt ;
      private string[] BC001T12_A458EspecialidadeNome ;
      private bool[] BC001T12_n458EspecialidadeNome ;
      private bool[] BC001T12_A595EspecialidadeStatus ;
      private bool[] BC001T12_n595EspecialidadeStatus ;
      private short[] BC001T12_A597EspecialidadeCreatedBy ;
      private bool[] BC001T12_n597EspecialidadeCreatedBy ;
      private SdtEspecialidade bcEspecialidade ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class especialidade_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001T2;
          prmBC001T2 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001T3;
          prmBC001T3 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001T4;
          prmBC001T4 = new Object[] {
          new ParDef("EspecialidadeCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001T5;
          prmBC001T5 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001T6;
          prmBC001T6 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001T7;
          prmBC001T7 = new Object[] {
          new ParDef("EspecialidadeCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("EspecialidadeUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("EspecialidadeNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("EspecialidadeStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("EspecialidadeCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001T8;
          prmBC001T8 = new Object[] {
          };
          Object[] prmBC001T9;
          prmBC001T9 = new Object[] {
          new ParDef("EspecialidadeCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("EspecialidadeUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("EspecialidadeNome",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("EspecialidadeStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("EspecialidadeCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001T10;
          prmBC001T10 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001T11;
          prmBC001T11 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001T12;
          prmBC001T12 = new Object[] {
          new ParDef("EspecialidadeId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001T2", "SELECT EspecialidadeId, EspecialidadeCreatedAt, EspecialidadeUpdatedAt, EspecialidadeNome, EspecialidadeStatus, EspecialidadeCreatedBy FROM Especialidade WHERE EspecialidadeId = :EspecialidadeId  FOR UPDATE OF Especialidade",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001T3", "SELECT EspecialidadeId, EspecialidadeCreatedAt, EspecialidadeUpdatedAt, EspecialidadeNome, EspecialidadeStatus, EspecialidadeCreatedBy FROM Especialidade WHERE EspecialidadeId = :EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001T4", "SELECT SecUserId AS EspecialidadeCreatedBy FROM SecUser WHERE SecUserId = :EspecialidadeCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001T5", "SELECT TM1.EspecialidadeId, TM1.EspecialidadeCreatedAt, TM1.EspecialidadeUpdatedAt, TM1.EspecialidadeNome, TM1.EspecialidadeStatus, TM1.EspecialidadeCreatedBy AS EspecialidadeCreatedBy FROM Especialidade TM1 WHERE TM1.EspecialidadeId = :EspecialidadeId ORDER BY TM1.EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001T6", "SELECT EspecialidadeId FROM Especialidade WHERE EspecialidadeId = :EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001T7", "SAVEPOINT gxupdate;INSERT INTO Especialidade(EspecialidadeCreatedAt, EspecialidadeUpdatedAt, EspecialidadeNome, EspecialidadeStatus, EspecialidadeCreatedBy) VALUES(:EspecialidadeCreatedAt, :EspecialidadeUpdatedAt, :EspecialidadeNome, :EspecialidadeStatus, :EspecialidadeCreatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001T7)
             ,new CursorDef("BC001T8", "SELECT currval('EspecialidadeId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001T9", "SAVEPOINT gxupdate;UPDATE Especialidade SET EspecialidadeCreatedAt=:EspecialidadeCreatedAt, EspecialidadeUpdatedAt=:EspecialidadeUpdatedAt, EspecialidadeNome=:EspecialidadeNome, EspecialidadeStatus=:EspecialidadeStatus, EspecialidadeCreatedBy=:EspecialidadeCreatedBy  WHERE EspecialidadeId = :EspecialidadeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001T9)
             ,new CursorDef("BC001T10", "SAVEPOINT gxupdate;DELETE FROM Especialidade  WHERE EspecialidadeId = :EspecialidadeId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001T10)
             ,new CursorDef("BC001T11", "SELECT ClienteId FROM Cliente WHERE EspecialidadeId = :EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001T12", "SELECT TM1.EspecialidadeId, TM1.EspecialidadeCreatedAt, TM1.EspecialidadeUpdatedAt, TM1.EspecialidadeNome, TM1.EspecialidadeStatus, TM1.EspecialidadeCreatedBy AS EspecialidadeCreatedBy FROM Especialidade TM1 WHERE TM1.EspecialidadeId = :EspecialidadeId ORDER BY TM1.EspecialidadeId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001T12,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
