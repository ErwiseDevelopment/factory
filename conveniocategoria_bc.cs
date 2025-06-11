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
   public class conveniocategoria_bc : GxSilentTrn, IGxSilentTrn
   {
      public conveniocategoria_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public conveniocategoria_bc( IGxContext context )
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
         ReadRow1W70( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1W70( ) ;
         standaloneModal( ) ;
         AddRow1W70( ) ;
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
            E111W2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z493ConvenioCategoriaId = A493ConvenioCategoriaId;
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

      protected void CONFIRM_1W0( )
      {
         BeforeValidate1W70( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1W70( ) ;
            }
            else
            {
               CheckExtendedTable1W70( ) ;
               if ( AnyError == 0 )
               {
                  ZM1W70( 6) ;
               }
               CloseExtendedTableCursors1W70( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121W2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ConvenioId") == 0 )
               {
                  AV11Insert_ConvenioId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
            }
         }
      }

      protected void E111W2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1W70( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z494ConvenioCategoriaDescricao = A494ConvenioCategoriaDescricao;
            Z495ConvenioCategoriaStatus = A495ConvenioCategoriaStatus;
            Z410ConvenioId = A410ConvenioId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -5 )
         {
            Z493ConvenioCategoriaId = A493ConvenioCategoriaId;
            Z494ConvenioCategoriaDescricao = A494ConvenioCategoriaDescricao;
            Z495ConvenioCategoriaStatus = A495ConvenioCategoriaStatus;
            Z410ConvenioId = A410ConvenioId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV15Pgmname = "ConvenioCategoria_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A495ConvenioCategoriaStatus) && ( Gx_BScreen == 0 ) )
         {
            A495ConvenioCategoriaStatus = true;
            n495ConvenioCategoriaStatus = false;
         }
      }

      protected void Load1W70( )
      {
         /* Using cursor BC001W5 */
         pr_default.execute(3, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound70 = 1;
            A494ConvenioCategoriaDescricao = BC001W5_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = BC001W5_n494ConvenioCategoriaDescricao[0];
            A495ConvenioCategoriaStatus = BC001W5_A495ConvenioCategoriaStatus[0];
            n495ConvenioCategoriaStatus = BC001W5_n495ConvenioCategoriaStatus[0];
            A410ConvenioId = BC001W5_A410ConvenioId[0];
            n410ConvenioId = BC001W5_n410ConvenioId[0];
            ZM1W70( -5) ;
         }
         pr_default.close(3);
         OnLoadActions1W70( ) ;
      }

      protected void OnLoadActions1W70( )
      {
      }

      protected void CheckExtendedTable1W70( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001W4 */
         pr_default.execute(2, new Object[] {n410ConvenioId, A410ConvenioId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A410ConvenioId) ) )
            {
               GX_msglist.addItem("Não existe 'Convenio'.", "ForeignKeyNotFound", 1, "CONVENIOID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1W70( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1W70( )
      {
         /* Using cursor BC001W6 */
         pr_default.execute(4, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound70 = 1;
         }
         else
         {
            RcdFound70 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001W3 */
         pr_default.execute(1, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1W70( 5) ;
            RcdFound70 = 1;
            A493ConvenioCategoriaId = BC001W3_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = BC001W3_n493ConvenioCategoriaId[0];
            A494ConvenioCategoriaDescricao = BC001W3_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = BC001W3_n494ConvenioCategoriaDescricao[0];
            A495ConvenioCategoriaStatus = BC001W3_A495ConvenioCategoriaStatus[0];
            n495ConvenioCategoriaStatus = BC001W3_n495ConvenioCategoriaStatus[0];
            A410ConvenioId = BC001W3_A410ConvenioId[0];
            n410ConvenioId = BC001W3_n410ConvenioId[0];
            Z493ConvenioCategoriaId = A493ConvenioCategoriaId;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1W70( ) ;
            if ( AnyError == 1 )
            {
               RcdFound70 = 0;
               InitializeNonKey1W70( ) ;
            }
            Gx_mode = sMode70;
         }
         else
         {
            RcdFound70 = 0;
            InitializeNonKey1W70( ) ;
            sMode70 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode70;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1W70( ) ;
         if ( RcdFound70 == 0 )
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
         CONFIRM_1W0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1W70( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001W2 */
            pr_default.execute(0, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConvenioCategoria"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z494ConvenioCategoriaDescricao, BC001W2_A494ConvenioCategoriaDescricao[0]) != 0 ) || ( Z495ConvenioCategoriaStatus != BC001W2_A495ConvenioCategoriaStatus[0] ) || ( Z410ConvenioId != BC001W2_A410ConvenioId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ConvenioCategoria"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1W70( )
      {
         BeforeValidate1W70( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W70( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1W70( 0) ;
            CheckOptimisticConcurrency1W70( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W70( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1W70( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001W7 */
                     pr_default.execute(5, new Object[] {n494ConvenioCategoriaDescricao, A494ConvenioCategoriaDescricao, n495ConvenioCategoriaStatus, A495ConvenioCategoriaStatus, n410ConvenioId, A410ConvenioId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001W8 */
                     pr_default.execute(6);
                     A493ConvenioCategoriaId = BC001W8_A493ConvenioCategoriaId[0];
                     n493ConvenioCategoriaId = BC001W8_n493ConvenioCategoriaId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("ConvenioCategoria");
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
               Load1W70( ) ;
            }
            EndLevel1W70( ) ;
         }
         CloseExtendedTableCursors1W70( ) ;
      }

      protected void Update1W70( )
      {
         BeforeValidate1W70( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1W70( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W70( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1W70( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1W70( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001W9 */
                     pr_default.execute(7, new Object[] {n494ConvenioCategoriaDescricao, A494ConvenioCategoriaDescricao, n495ConvenioCategoriaStatus, A495ConvenioCategoriaStatus, n410ConvenioId, A410ConvenioId, n493ConvenioCategoriaId, A493ConvenioCategoriaId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("ConvenioCategoria");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConvenioCategoria"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1W70( ) ;
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
            EndLevel1W70( ) ;
         }
         CloseExtendedTableCursors1W70( ) ;
      }

      protected void DeferredUpdate1W70( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1W70( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1W70( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1W70( ) ;
            AfterConfirm1W70( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1W70( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001W10 */
                  pr_default.execute(8, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("ConvenioCategoria");
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
         sMode70 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1W70( ) ;
         Gx_mode = sMode70;
      }

      protected void OnDeleteControls1W70( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001W11 */
            pr_default.execute(9, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1W70( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1W70( ) ;
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

      public void ScanKeyStart1W70( )
      {
         /* Scan By routine */
         /* Using cursor BC001W12 */
         pr_default.execute(10, new Object[] {n493ConvenioCategoriaId, A493ConvenioCategoriaId});
         RcdFound70 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound70 = 1;
            A493ConvenioCategoriaId = BC001W12_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = BC001W12_n493ConvenioCategoriaId[0];
            A494ConvenioCategoriaDescricao = BC001W12_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = BC001W12_n494ConvenioCategoriaDescricao[0];
            A495ConvenioCategoriaStatus = BC001W12_A495ConvenioCategoriaStatus[0];
            n495ConvenioCategoriaStatus = BC001W12_n495ConvenioCategoriaStatus[0];
            A410ConvenioId = BC001W12_A410ConvenioId[0];
            n410ConvenioId = BC001W12_n410ConvenioId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1W70( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound70 = 0;
         ScanKeyLoad1W70( ) ;
      }

      protected void ScanKeyLoad1W70( )
      {
         sMode70 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound70 = 1;
            A493ConvenioCategoriaId = BC001W12_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = BC001W12_n493ConvenioCategoriaId[0];
            A494ConvenioCategoriaDescricao = BC001W12_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = BC001W12_n494ConvenioCategoriaDescricao[0];
            A495ConvenioCategoriaStatus = BC001W12_A495ConvenioCategoriaStatus[0];
            n495ConvenioCategoriaStatus = BC001W12_n495ConvenioCategoriaStatus[0];
            A410ConvenioId = BC001W12_A410ConvenioId[0];
            n410ConvenioId = BC001W12_n410ConvenioId[0];
         }
         Gx_mode = sMode70;
      }

      protected void ScanKeyEnd1W70( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1W70( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1W70( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1W70( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1W70( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1W70( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1W70( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1W70( )
      {
      }

      protected void send_integrity_lvl_hashes1W70( )
      {
      }

      protected void AddRow1W70( )
      {
         VarsToRow70( bcConvenioCategoria) ;
      }

      protected void ReadRow1W70( )
      {
         RowToVars70( bcConvenioCategoria, 1) ;
      }

      protected void InitializeNonKey1W70( )
      {
         A410ConvenioId = 0;
         n410ConvenioId = false;
         A494ConvenioCategoriaDescricao = "";
         n494ConvenioCategoriaDescricao = false;
         A495ConvenioCategoriaStatus = true;
         n495ConvenioCategoriaStatus = false;
         Z494ConvenioCategoriaDescricao = "";
         Z495ConvenioCategoriaStatus = false;
         Z410ConvenioId = 0;
      }

      protected void InitAll1W70( )
      {
         A493ConvenioCategoriaId = 0;
         n493ConvenioCategoriaId = false;
         InitializeNonKey1W70( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A495ConvenioCategoriaStatus = i495ConvenioCategoriaStatus;
         n495ConvenioCategoriaStatus = false;
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

      public void VarsToRow70( SdtConvenioCategoria obj70 )
      {
         obj70.gxTpr_Mode = Gx_mode;
         obj70.gxTpr_Convenioid = A410ConvenioId;
         obj70.gxTpr_Conveniocategoriadescricao = A494ConvenioCategoriaDescricao;
         obj70.gxTpr_Conveniocategoriastatus = A495ConvenioCategoriaStatus;
         obj70.gxTpr_Conveniocategoriaid = A493ConvenioCategoriaId;
         obj70.gxTpr_Conveniocategoriaid_Z = Z493ConvenioCategoriaId;
         obj70.gxTpr_Convenioid_Z = Z410ConvenioId;
         obj70.gxTpr_Conveniocategoriadescricao_Z = Z494ConvenioCategoriaDescricao;
         obj70.gxTpr_Conveniocategoriastatus_Z = Z495ConvenioCategoriaStatus;
         obj70.gxTpr_Conveniocategoriaid_N = (short)(Convert.ToInt16(n493ConvenioCategoriaId));
         obj70.gxTpr_Convenioid_N = (short)(Convert.ToInt16(n410ConvenioId));
         obj70.gxTpr_Conveniocategoriadescricao_N = (short)(Convert.ToInt16(n494ConvenioCategoriaDescricao));
         obj70.gxTpr_Conveniocategoriastatus_N = (short)(Convert.ToInt16(n495ConvenioCategoriaStatus));
         obj70.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow70( SdtConvenioCategoria obj70 )
      {
         obj70.gxTpr_Conveniocategoriaid = A493ConvenioCategoriaId;
         return  ;
      }

      public void RowToVars70( SdtConvenioCategoria obj70 ,
                               int forceLoad )
      {
         Gx_mode = obj70.gxTpr_Mode;
         A410ConvenioId = obj70.gxTpr_Convenioid;
         n410ConvenioId = false;
         A494ConvenioCategoriaDescricao = obj70.gxTpr_Conveniocategoriadescricao;
         n494ConvenioCategoriaDescricao = false;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A495ConvenioCategoriaStatus = obj70.gxTpr_Conveniocategoriastatus;
            n495ConvenioCategoriaStatus = false;
         }
         A493ConvenioCategoriaId = obj70.gxTpr_Conveniocategoriaid;
         n493ConvenioCategoriaId = false;
         Z493ConvenioCategoriaId = obj70.gxTpr_Conveniocategoriaid_Z;
         Z410ConvenioId = obj70.gxTpr_Convenioid_Z;
         Z494ConvenioCategoriaDescricao = obj70.gxTpr_Conveniocategoriadescricao_Z;
         Z495ConvenioCategoriaStatus = obj70.gxTpr_Conveniocategoriastatus_Z;
         n493ConvenioCategoriaId = (bool)(Convert.ToBoolean(obj70.gxTpr_Conveniocategoriaid_N));
         n410ConvenioId = (bool)(Convert.ToBoolean(obj70.gxTpr_Convenioid_N));
         n494ConvenioCategoriaDescricao = (bool)(Convert.ToBoolean(obj70.gxTpr_Conveniocategoriadescricao_N));
         n495ConvenioCategoriaStatus = (bool)(Convert.ToBoolean(obj70.gxTpr_Conveniocategoriastatus_N));
         Gx_mode = obj70.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A493ConvenioCategoriaId = (int)getParm(obj,0);
         n493ConvenioCategoriaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1W70( ) ;
         ScanKeyStart1W70( ) ;
         if ( RcdFound70 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z493ConvenioCategoriaId = A493ConvenioCategoriaId;
         }
         ZM1W70( -5) ;
         OnLoadActions1W70( ) ;
         AddRow1W70( ) ;
         ScanKeyEnd1W70( ) ;
         if ( RcdFound70 == 0 )
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
         RowToVars70( bcConvenioCategoria, 0) ;
         ScanKeyStart1W70( ) ;
         if ( RcdFound70 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z493ConvenioCategoriaId = A493ConvenioCategoriaId;
         }
         ZM1W70( -5) ;
         OnLoadActions1W70( ) ;
         AddRow1W70( ) ;
         ScanKeyEnd1W70( ) ;
         if ( RcdFound70 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1W70( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1W70( ) ;
         }
         else
         {
            if ( RcdFound70 == 1 )
            {
               if ( A493ConvenioCategoriaId != Z493ConvenioCategoriaId )
               {
                  A493ConvenioCategoriaId = Z493ConvenioCategoriaId;
                  n493ConvenioCategoriaId = false;
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
                  Update1W70( ) ;
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
                  if ( A493ConvenioCategoriaId != Z493ConvenioCategoriaId )
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
                        Insert1W70( ) ;
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
                        Insert1W70( ) ;
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
         RowToVars70( bcConvenioCategoria, 1) ;
         SaveImpl( ) ;
         VarsToRow70( bcConvenioCategoria) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars70( bcConvenioCategoria, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1W70( ) ;
         AfterTrn( ) ;
         VarsToRow70( bcConvenioCategoria) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow70( bcConvenioCategoria) ;
         }
         else
         {
            SdtConvenioCategoria auxBC = new SdtConvenioCategoria(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A493ConvenioCategoriaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcConvenioCategoria);
               auxBC.Save();
               bcConvenioCategoria.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars70( bcConvenioCategoria, 1) ;
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
         RowToVars70( bcConvenioCategoria, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1W70( ) ;
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
               VarsToRow70( bcConvenioCategoria) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow70( bcConvenioCategoria) ;
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
         RowToVars70( bcConvenioCategoria, 0) ;
         GetKey1W70( ) ;
         if ( RcdFound70 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A493ConvenioCategoriaId != Z493ConvenioCategoriaId )
            {
               A493ConvenioCategoriaId = Z493ConvenioCategoriaId;
               n493ConvenioCategoriaId = false;
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
            if ( A493ConvenioCategoriaId != Z493ConvenioCategoriaId )
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
         context.RollbackDataStores("conveniocategoria_bc",pr_default);
         VarsToRow70( bcConvenioCategoria) ;
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
         Gx_mode = bcConvenioCategoria.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcConvenioCategoria.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcConvenioCategoria )
         {
            bcConvenioCategoria = (SdtConvenioCategoria)(sdt);
            if ( StringUtil.StrCmp(bcConvenioCategoria.gxTpr_Mode, "") == 0 )
            {
               bcConvenioCategoria.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow70( bcConvenioCategoria) ;
            }
            else
            {
               RowToVars70( bcConvenioCategoria, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcConvenioCategoria.gxTpr_Mode, "") == 0 )
            {
               bcConvenioCategoria.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars70( bcConvenioCategoria, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtConvenioCategoria ConvenioCategoria_BC
      {
         get {
            return bcConvenioCategoria ;
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
         AV15Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z494ConvenioCategoriaDescricao = "";
         A494ConvenioCategoriaDescricao = "";
         BC001W5_A493ConvenioCategoriaId = new int[1] ;
         BC001W5_n493ConvenioCategoriaId = new bool[] {false} ;
         BC001W5_A494ConvenioCategoriaDescricao = new string[] {""} ;
         BC001W5_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         BC001W5_A495ConvenioCategoriaStatus = new bool[] {false} ;
         BC001W5_n495ConvenioCategoriaStatus = new bool[] {false} ;
         BC001W5_A410ConvenioId = new int[1] ;
         BC001W5_n410ConvenioId = new bool[] {false} ;
         BC001W4_A410ConvenioId = new int[1] ;
         BC001W4_n410ConvenioId = new bool[] {false} ;
         BC001W6_A493ConvenioCategoriaId = new int[1] ;
         BC001W6_n493ConvenioCategoriaId = new bool[] {false} ;
         BC001W3_A493ConvenioCategoriaId = new int[1] ;
         BC001W3_n493ConvenioCategoriaId = new bool[] {false} ;
         BC001W3_A494ConvenioCategoriaDescricao = new string[] {""} ;
         BC001W3_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         BC001W3_A495ConvenioCategoriaStatus = new bool[] {false} ;
         BC001W3_n495ConvenioCategoriaStatus = new bool[] {false} ;
         BC001W3_A410ConvenioId = new int[1] ;
         BC001W3_n410ConvenioId = new bool[] {false} ;
         sMode70 = "";
         BC001W2_A493ConvenioCategoriaId = new int[1] ;
         BC001W2_n493ConvenioCategoriaId = new bool[] {false} ;
         BC001W2_A494ConvenioCategoriaDescricao = new string[] {""} ;
         BC001W2_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         BC001W2_A495ConvenioCategoriaStatus = new bool[] {false} ;
         BC001W2_n495ConvenioCategoriaStatus = new bool[] {false} ;
         BC001W2_A410ConvenioId = new int[1] ;
         BC001W2_n410ConvenioId = new bool[] {false} ;
         BC001W8_A493ConvenioCategoriaId = new int[1] ;
         BC001W8_n493ConvenioCategoriaId = new bool[] {false} ;
         BC001W11_A323PropostaId = new int[1] ;
         BC001W12_A493ConvenioCategoriaId = new int[1] ;
         BC001W12_n493ConvenioCategoriaId = new bool[] {false} ;
         BC001W12_A494ConvenioCategoriaDescricao = new string[] {""} ;
         BC001W12_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         BC001W12_A495ConvenioCategoriaStatus = new bool[] {false} ;
         BC001W12_n495ConvenioCategoriaStatus = new bool[] {false} ;
         BC001W12_A410ConvenioId = new int[1] ;
         BC001W12_n410ConvenioId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conveniocategoria_bc__default(),
            new Object[][] {
                new Object[] {
               BC001W2_A493ConvenioCategoriaId, BC001W2_A494ConvenioCategoriaDescricao, BC001W2_n494ConvenioCategoriaDescricao, BC001W2_A495ConvenioCategoriaStatus, BC001W2_n495ConvenioCategoriaStatus, BC001W2_A410ConvenioId, BC001W2_n410ConvenioId
               }
               , new Object[] {
               BC001W3_A493ConvenioCategoriaId, BC001W3_A494ConvenioCategoriaDescricao, BC001W3_n494ConvenioCategoriaDescricao, BC001W3_A495ConvenioCategoriaStatus, BC001W3_n495ConvenioCategoriaStatus, BC001W3_A410ConvenioId, BC001W3_n410ConvenioId
               }
               , new Object[] {
               BC001W4_A410ConvenioId
               }
               , new Object[] {
               BC001W5_A493ConvenioCategoriaId, BC001W5_A494ConvenioCategoriaDescricao, BC001W5_n494ConvenioCategoriaDescricao, BC001W5_A495ConvenioCategoriaStatus, BC001W5_n495ConvenioCategoriaStatus, BC001W5_A410ConvenioId, BC001W5_n410ConvenioId
               }
               , new Object[] {
               BC001W6_A493ConvenioCategoriaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001W8_A493ConvenioCategoriaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001W11_A323PropostaId
               }
               , new Object[] {
               BC001W12_A493ConvenioCategoriaId, BC001W12_A494ConvenioCategoriaDescricao, BC001W12_n494ConvenioCategoriaDescricao, BC001W12_A495ConvenioCategoriaStatus, BC001W12_n495ConvenioCategoriaStatus, BC001W12_A410ConvenioId, BC001W12_n410ConvenioId
               }
            }
         );
         AV15Pgmname = "ConvenioCategoria_BC";
         Z495ConvenioCategoriaStatus = true;
         n495ConvenioCategoriaStatus = false;
         A495ConvenioCategoriaStatus = true;
         n495ConvenioCategoriaStatus = false;
         i495ConvenioCategoriaStatus = true;
         n495ConvenioCategoriaStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121W2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound70 ;
      private int trnEnded ;
      private int Z493ConvenioCategoriaId ;
      private int A493ConvenioCategoriaId ;
      private int AV16GXV1 ;
      private int AV11Insert_ConvenioId ;
      private int Z410ConvenioId ;
      private int A410ConvenioId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV15Pgmname ;
      private string sMode70 ;
      private bool returnInSub ;
      private bool Z495ConvenioCategoriaStatus ;
      private bool A495ConvenioCategoriaStatus ;
      private bool n495ConvenioCategoriaStatus ;
      private bool n493ConvenioCategoriaId ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n410ConvenioId ;
      private bool i495ConvenioCategoriaStatus ;
      private string Z494ConvenioCategoriaDescricao ;
      private string A494ConvenioCategoriaDescricao ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC001W5_A493ConvenioCategoriaId ;
      private bool[] BC001W5_n493ConvenioCategoriaId ;
      private string[] BC001W5_A494ConvenioCategoriaDescricao ;
      private bool[] BC001W5_n494ConvenioCategoriaDescricao ;
      private bool[] BC001W5_A495ConvenioCategoriaStatus ;
      private bool[] BC001W5_n495ConvenioCategoriaStatus ;
      private int[] BC001W5_A410ConvenioId ;
      private bool[] BC001W5_n410ConvenioId ;
      private int[] BC001W4_A410ConvenioId ;
      private bool[] BC001W4_n410ConvenioId ;
      private int[] BC001W6_A493ConvenioCategoriaId ;
      private bool[] BC001W6_n493ConvenioCategoriaId ;
      private int[] BC001W3_A493ConvenioCategoriaId ;
      private bool[] BC001W3_n493ConvenioCategoriaId ;
      private string[] BC001W3_A494ConvenioCategoriaDescricao ;
      private bool[] BC001W3_n494ConvenioCategoriaDescricao ;
      private bool[] BC001W3_A495ConvenioCategoriaStatus ;
      private bool[] BC001W3_n495ConvenioCategoriaStatus ;
      private int[] BC001W3_A410ConvenioId ;
      private bool[] BC001W3_n410ConvenioId ;
      private int[] BC001W2_A493ConvenioCategoriaId ;
      private bool[] BC001W2_n493ConvenioCategoriaId ;
      private string[] BC001W2_A494ConvenioCategoriaDescricao ;
      private bool[] BC001W2_n494ConvenioCategoriaDescricao ;
      private bool[] BC001W2_A495ConvenioCategoriaStatus ;
      private bool[] BC001W2_n495ConvenioCategoriaStatus ;
      private int[] BC001W2_A410ConvenioId ;
      private bool[] BC001W2_n410ConvenioId ;
      private int[] BC001W8_A493ConvenioCategoriaId ;
      private bool[] BC001W8_n493ConvenioCategoriaId ;
      private int[] BC001W11_A323PropostaId ;
      private int[] BC001W12_A493ConvenioCategoriaId ;
      private bool[] BC001W12_n493ConvenioCategoriaId ;
      private string[] BC001W12_A494ConvenioCategoriaDescricao ;
      private bool[] BC001W12_n494ConvenioCategoriaDescricao ;
      private bool[] BC001W12_A495ConvenioCategoriaStatus ;
      private bool[] BC001W12_n495ConvenioCategoriaStatus ;
      private int[] BC001W12_A410ConvenioId ;
      private bool[] BC001W12_n410ConvenioId ;
      private SdtConvenioCategoria bcConvenioCategoria ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class conveniocategoria_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC001W2;
          prmBC001W2 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001W3;
          prmBC001W3 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001W4;
          prmBC001W4 = new Object[] {
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001W5;
          prmBC001W5 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001W6;
          prmBC001W6 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001W7;
          prmBC001W7 = new Object[] {
          new ParDef("ConvenioCategoriaDescricao",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("ConvenioCategoriaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001W8;
          prmBC001W8 = new Object[] {
          };
          Object[] prmBC001W9;
          prmBC001W9 = new Object[] {
          new ParDef("ConvenioCategoriaDescricao",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("ConvenioCategoriaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ConvenioId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001W10;
          prmBC001W10 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001W11;
          prmBC001W11 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001W12;
          prmBC001W12 = new Object[] {
          new ParDef("ConvenioCategoriaId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001W2", "SELECT ConvenioCategoriaId, ConvenioCategoriaDescricao, ConvenioCategoriaStatus, ConvenioId FROM ConvenioCategoria WHERE ConvenioCategoriaId = :ConvenioCategoriaId  FOR UPDATE OF ConvenioCategoria",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001W3", "SELECT ConvenioCategoriaId, ConvenioCategoriaDescricao, ConvenioCategoriaStatus, ConvenioId FROM ConvenioCategoria WHERE ConvenioCategoriaId = :ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001W4", "SELECT ConvenioId FROM Convenio WHERE ConvenioId = :ConvenioId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001W5", "SELECT TM1.ConvenioCategoriaId, TM1.ConvenioCategoriaDescricao, TM1.ConvenioCategoriaStatus, TM1.ConvenioId FROM ConvenioCategoria TM1 WHERE TM1.ConvenioCategoriaId = :ConvenioCategoriaId ORDER BY TM1.ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001W6", "SELECT ConvenioCategoriaId FROM ConvenioCategoria WHERE ConvenioCategoriaId = :ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001W7", "SAVEPOINT gxupdate;INSERT INTO ConvenioCategoria(ConvenioCategoriaDescricao, ConvenioCategoriaStatus, ConvenioId) VALUES(:ConvenioCategoriaDescricao, :ConvenioCategoriaStatus, :ConvenioId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001W7)
             ,new CursorDef("BC001W8", "SELECT currval('ConvenioCategoriaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001W9", "SAVEPOINT gxupdate;UPDATE ConvenioCategoria SET ConvenioCategoriaDescricao=:ConvenioCategoriaDescricao, ConvenioCategoriaStatus=:ConvenioCategoriaStatus, ConvenioId=:ConvenioId  WHERE ConvenioCategoriaId = :ConvenioCategoriaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001W9)
             ,new CursorDef("BC001W10", "SAVEPOINT gxupdate;DELETE FROM ConvenioCategoria  WHERE ConvenioCategoriaId = :ConvenioCategoriaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001W10)
             ,new CursorDef("BC001W11", "SELECT PropostaId FROM Proposta WHERE ConvenioCategoriaId = :ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001W12", "SELECT TM1.ConvenioCategoriaId, TM1.ConvenioCategoriaDescricao, TM1.ConvenioCategoriaStatus, TM1.ConvenioId FROM ConvenioCategoria TM1 WHERE TM1.ConvenioCategoriaId = :ConvenioCategoriaId ORDER BY TM1.ConvenioCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001W12,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
