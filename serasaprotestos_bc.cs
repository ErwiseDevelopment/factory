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
   public class serasaprotestos_bc : GxSilentTrn, IGxSilentTrn
   {
      public serasaprotestos_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasaprotestos_bc( IGxContext context )
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
         ReadRow2H87( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2H87( ) ;
         standaloneModal( ) ;
         AddRow2H87( ) ;
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
            E112H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z711SerasaProtestosId = A711SerasaProtestosId;
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

      protected void CONFIRM_2H0( )
      {
         BeforeValidate2H87( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2H87( ) ;
            }
            else
            {
               CheckExtendedTable2H87( ) ;
               if ( AnyError == 0 )
               {
                  ZM2H87( 5) ;
               }
               CloseExtendedTableCursors2H87( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122H2( )
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

      protected void E112H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2H87( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z712SerasaProtestosData = A712SerasaProtestosData;
            Z713SerasaProtestosValor = A713SerasaProtestosValor;
            Z714SerasaProtestosCartorio = A714SerasaProtestosCartorio;
            Z715SerasaProtestosCidade = A715SerasaProtestosCidade;
            Z662SerasaId = A662SerasaId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -4 )
         {
            Z711SerasaProtestosId = A711SerasaProtestosId;
            Z712SerasaProtestosData = A712SerasaProtestosData;
            Z713SerasaProtestosValor = A713SerasaProtestosValor;
            Z714SerasaProtestosCartorio = A714SerasaProtestosCartorio;
            Z715SerasaProtestosCidade = A715SerasaProtestosCidade;
            Z662SerasaId = A662SerasaId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV19Pgmname = "SerasaProtestos_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load2H87( )
      {
         /* Using cursor BC002H5 */
         pr_default.execute(3, new Object[] {A711SerasaProtestosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound87 = 1;
            A712SerasaProtestosData = BC002H5_A712SerasaProtestosData[0];
            n712SerasaProtestosData = BC002H5_n712SerasaProtestosData[0];
            A713SerasaProtestosValor = BC002H5_A713SerasaProtestosValor[0];
            n713SerasaProtestosValor = BC002H5_n713SerasaProtestosValor[0];
            A714SerasaProtestosCartorio = BC002H5_A714SerasaProtestosCartorio[0];
            n714SerasaProtestosCartorio = BC002H5_n714SerasaProtestosCartorio[0];
            A715SerasaProtestosCidade = BC002H5_A715SerasaProtestosCidade[0];
            n715SerasaProtestosCidade = BC002H5_n715SerasaProtestosCidade[0];
            A662SerasaId = BC002H5_A662SerasaId[0];
            n662SerasaId = BC002H5_n662SerasaId[0];
            ZM2H87( -4) ;
         }
         pr_default.close(3);
         OnLoadActions2H87( ) ;
      }

      protected void OnLoadActions2H87( )
      {
      }

      protected void CheckExtendedTable2H87( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002H4 */
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
         if ( ( A713SerasaProtestosValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2H87( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2H87( )
      {
         /* Using cursor BC002H6 */
         pr_default.execute(4, new Object[] {A711SerasaProtestosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound87 = 1;
         }
         else
         {
            RcdFound87 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002H3 */
         pr_default.execute(1, new Object[] {A711SerasaProtestosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2H87( 4) ;
            RcdFound87 = 1;
            A711SerasaProtestosId = BC002H3_A711SerasaProtestosId[0];
            A712SerasaProtestosData = BC002H3_A712SerasaProtestosData[0];
            n712SerasaProtestosData = BC002H3_n712SerasaProtestosData[0];
            A713SerasaProtestosValor = BC002H3_A713SerasaProtestosValor[0];
            n713SerasaProtestosValor = BC002H3_n713SerasaProtestosValor[0];
            A714SerasaProtestosCartorio = BC002H3_A714SerasaProtestosCartorio[0];
            n714SerasaProtestosCartorio = BC002H3_n714SerasaProtestosCartorio[0];
            A715SerasaProtestosCidade = BC002H3_A715SerasaProtestosCidade[0];
            n715SerasaProtestosCidade = BC002H3_n715SerasaProtestosCidade[0];
            A662SerasaId = BC002H3_A662SerasaId[0];
            n662SerasaId = BC002H3_n662SerasaId[0];
            Z711SerasaProtestosId = A711SerasaProtestosId;
            sMode87 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2H87( ) ;
            if ( AnyError == 1 )
            {
               RcdFound87 = 0;
               InitializeNonKey2H87( ) ;
            }
            Gx_mode = sMode87;
         }
         else
         {
            RcdFound87 = 0;
            InitializeNonKey2H87( ) ;
            sMode87 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode87;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2H87( ) ;
         if ( RcdFound87 == 0 )
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
         CONFIRM_2H0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2H87( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002H2 */
            pr_default.execute(0, new Object[] {A711SerasaProtestosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaProtestos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z712SerasaProtestosData ) != DateTimeUtil.ResetTime ( BC002H2_A712SerasaProtestosData[0] ) ) || ( Z713SerasaProtestosValor != BC002H2_A713SerasaProtestosValor[0] ) || ( StringUtil.StrCmp(Z714SerasaProtestosCartorio, BC002H2_A714SerasaProtestosCartorio[0]) != 0 ) || ( StringUtil.StrCmp(Z715SerasaProtestosCidade, BC002H2_A715SerasaProtestosCidade[0]) != 0 ) || ( Z662SerasaId != BC002H2_A662SerasaId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SerasaProtestos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2H87( )
      {
         BeforeValidate2H87( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2H87( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2H87( 0) ;
            CheckOptimisticConcurrency2H87( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2H87( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2H87( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002H7 */
                     pr_default.execute(5, new Object[] {n712SerasaProtestosData, A712SerasaProtestosData, n713SerasaProtestosValor, A713SerasaProtestosValor, n714SerasaProtestosCartorio, A714SerasaProtestosCartorio, n715SerasaProtestosCidade, A715SerasaProtestosCidade, n662SerasaId, A662SerasaId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002H8 */
                     pr_default.execute(6);
                     A711SerasaProtestosId = BC002H8_A711SerasaProtestosId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaProtestos");
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
               Load2H87( ) ;
            }
            EndLevel2H87( ) ;
         }
         CloseExtendedTableCursors2H87( ) ;
      }

      protected void Update2H87( )
      {
         BeforeValidate2H87( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2H87( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2H87( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2H87( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2H87( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002H9 */
                     pr_default.execute(7, new Object[] {n712SerasaProtestosData, A712SerasaProtestosData, n713SerasaProtestosValor, A713SerasaProtestosValor, n714SerasaProtestosCartorio, A714SerasaProtestosCartorio, n715SerasaProtestosCidade, A715SerasaProtestosCidade, n662SerasaId, A662SerasaId, A711SerasaProtestosId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("SerasaProtestos");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SerasaProtestos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2H87( ) ;
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
            EndLevel2H87( ) ;
         }
         CloseExtendedTableCursors2H87( ) ;
      }

      protected void DeferredUpdate2H87( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2H87( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2H87( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2H87( ) ;
            AfterConfirm2H87( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2H87( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002H10 */
                  pr_default.execute(8, new Object[] {A711SerasaProtestosId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("SerasaProtestos");
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
         sMode87 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2H87( ) ;
         Gx_mode = sMode87;
      }

      protected void OnDeleteControls2H87( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2H87( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2H87( ) ;
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

      public void ScanKeyStart2H87( )
      {
         /* Scan By routine */
         /* Using cursor BC002H11 */
         pr_default.execute(9, new Object[] {A711SerasaProtestosId});
         RcdFound87 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound87 = 1;
            A711SerasaProtestosId = BC002H11_A711SerasaProtestosId[0];
            A712SerasaProtestosData = BC002H11_A712SerasaProtestosData[0];
            n712SerasaProtestosData = BC002H11_n712SerasaProtestosData[0];
            A713SerasaProtestosValor = BC002H11_A713SerasaProtestosValor[0];
            n713SerasaProtestosValor = BC002H11_n713SerasaProtestosValor[0];
            A714SerasaProtestosCartorio = BC002H11_A714SerasaProtestosCartorio[0];
            n714SerasaProtestosCartorio = BC002H11_n714SerasaProtestosCartorio[0];
            A715SerasaProtestosCidade = BC002H11_A715SerasaProtestosCidade[0];
            n715SerasaProtestosCidade = BC002H11_n715SerasaProtestosCidade[0];
            A662SerasaId = BC002H11_A662SerasaId[0];
            n662SerasaId = BC002H11_n662SerasaId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2H87( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound87 = 0;
         ScanKeyLoad2H87( ) ;
      }

      protected void ScanKeyLoad2H87( )
      {
         sMode87 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound87 = 1;
            A711SerasaProtestosId = BC002H11_A711SerasaProtestosId[0];
            A712SerasaProtestosData = BC002H11_A712SerasaProtestosData[0];
            n712SerasaProtestosData = BC002H11_n712SerasaProtestosData[0];
            A713SerasaProtestosValor = BC002H11_A713SerasaProtestosValor[0];
            n713SerasaProtestosValor = BC002H11_n713SerasaProtestosValor[0];
            A714SerasaProtestosCartorio = BC002H11_A714SerasaProtestosCartorio[0];
            n714SerasaProtestosCartorio = BC002H11_n714SerasaProtestosCartorio[0];
            A715SerasaProtestosCidade = BC002H11_A715SerasaProtestosCidade[0];
            n715SerasaProtestosCidade = BC002H11_n715SerasaProtestosCidade[0];
            A662SerasaId = BC002H11_A662SerasaId[0];
            n662SerasaId = BC002H11_n662SerasaId[0];
         }
         Gx_mode = sMode87;
      }

      protected void ScanKeyEnd2H87( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm2H87( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2H87( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2H87( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2H87( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2H87( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2H87( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2H87( )
      {
      }

      protected void send_integrity_lvl_hashes2H87( )
      {
      }

      protected void AddRow2H87( )
      {
         VarsToRow87( bcSerasaProtestos) ;
      }

      protected void ReadRow2H87( )
      {
         RowToVars87( bcSerasaProtestos, 1) ;
      }

      protected void InitializeNonKey2H87( )
      {
         A662SerasaId = 0;
         n662SerasaId = false;
         A712SerasaProtestosData = DateTime.MinValue;
         n712SerasaProtestosData = false;
         A713SerasaProtestosValor = 0;
         n713SerasaProtestosValor = false;
         A714SerasaProtestosCartorio = "";
         n714SerasaProtestosCartorio = false;
         A715SerasaProtestosCidade = "";
         n715SerasaProtestosCidade = false;
         Z712SerasaProtestosData = DateTime.MinValue;
         Z713SerasaProtestosValor = 0;
         Z714SerasaProtestosCartorio = "";
         Z715SerasaProtestosCidade = "";
         Z662SerasaId = 0;
      }

      protected void InitAll2H87( )
      {
         A711SerasaProtestosId = 0;
         InitializeNonKey2H87( ) ;
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

      public void VarsToRow87( SdtSerasaProtestos obj87 )
      {
         obj87.gxTpr_Mode = Gx_mode;
         obj87.gxTpr_Serasaid = A662SerasaId;
         obj87.gxTpr_Serasaprotestosdata = A712SerasaProtestosData;
         obj87.gxTpr_Serasaprotestosvalor = A713SerasaProtestosValor;
         obj87.gxTpr_Serasaprotestoscartorio = A714SerasaProtestosCartorio;
         obj87.gxTpr_Serasaprotestoscidade = A715SerasaProtestosCidade;
         obj87.gxTpr_Serasaprotestosid = A711SerasaProtestosId;
         obj87.gxTpr_Serasaprotestosid_Z = Z711SerasaProtestosId;
         obj87.gxTpr_Serasaid_Z = Z662SerasaId;
         obj87.gxTpr_Serasaprotestosdata_Z = Z712SerasaProtestosData;
         obj87.gxTpr_Serasaprotestosvalor_Z = Z713SerasaProtestosValor;
         obj87.gxTpr_Serasaprotestoscartorio_Z = Z714SerasaProtestosCartorio;
         obj87.gxTpr_Serasaprotestoscidade_Z = Z715SerasaProtestosCidade;
         obj87.gxTpr_Serasaid_N = (short)(Convert.ToInt16(n662SerasaId));
         obj87.gxTpr_Serasaprotestosdata_N = (short)(Convert.ToInt16(n712SerasaProtestosData));
         obj87.gxTpr_Serasaprotestosvalor_N = (short)(Convert.ToInt16(n713SerasaProtestosValor));
         obj87.gxTpr_Serasaprotestoscartorio_N = (short)(Convert.ToInt16(n714SerasaProtestosCartorio));
         obj87.gxTpr_Serasaprotestoscidade_N = (short)(Convert.ToInt16(n715SerasaProtestosCidade));
         obj87.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow87( SdtSerasaProtestos obj87 )
      {
         obj87.gxTpr_Serasaprotestosid = A711SerasaProtestosId;
         return  ;
      }

      public void RowToVars87( SdtSerasaProtestos obj87 ,
                               int forceLoad )
      {
         Gx_mode = obj87.gxTpr_Mode;
         A662SerasaId = obj87.gxTpr_Serasaid;
         n662SerasaId = false;
         A712SerasaProtestosData = obj87.gxTpr_Serasaprotestosdata;
         n712SerasaProtestosData = false;
         A713SerasaProtestosValor = obj87.gxTpr_Serasaprotestosvalor;
         n713SerasaProtestosValor = false;
         A714SerasaProtestosCartorio = obj87.gxTpr_Serasaprotestoscartorio;
         n714SerasaProtestosCartorio = false;
         A715SerasaProtestosCidade = obj87.gxTpr_Serasaprotestoscidade;
         n715SerasaProtestosCidade = false;
         A711SerasaProtestosId = obj87.gxTpr_Serasaprotestosid;
         Z711SerasaProtestosId = obj87.gxTpr_Serasaprotestosid_Z;
         Z662SerasaId = obj87.gxTpr_Serasaid_Z;
         Z712SerasaProtestosData = obj87.gxTpr_Serasaprotestosdata_Z;
         Z713SerasaProtestosValor = obj87.gxTpr_Serasaprotestosvalor_Z;
         Z714SerasaProtestosCartorio = obj87.gxTpr_Serasaprotestoscartorio_Z;
         Z715SerasaProtestosCidade = obj87.gxTpr_Serasaprotestoscidade_Z;
         n662SerasaId = (bool)(Convert.ToBoolean(obj87.gxTpr_Serasaid_N));
         n712SerasaProtestosData = (bool)(Convert.ToBoolean(obj87.gxTpr_Serasaprotestosdata_N));
         n713SerasaProtestosValor = (bool)(Convert.ToBoolean(obj87.gxTpr_Serasaprotestosvalor_N));
         n714SerasaProtestosCartorio = (bool)(Convert.ToBoolean(obj87.gxTpr_Serasaprotestoscartorio_N));
         n715SerasaProtestosCidade = (bool)(Convert.ToBoolean(obj87.gxTpr_Serasaprotestoscidade_N));
         Gx_mode = obj87.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A711SerasaProtestosId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2H87( ) ;
         ScanKeyStart2H87( ) ;
         if ( RcdFound87 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z711SerasaProtestosId = A711SerasaProtestosId;
         }
         ZM2H87( -4) ;
         OnLoadActions2H87( ) ;
         AddRow2H87( ) ;
         ScanKeyEnd2H87( ) ;
         if ( RcdFound87 == 0 )
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
         RowToVars87( bcSerasaProtestos, 0) ;
         ScanKeyStart2H87( ) ;
         if ( RcdFound87 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z711SerasaProtestosId = A711SerasaProtestosId;
         }
         ZM2H87( -4) ;
         OnLoadActions2H87( ) ;
         AddRow2H87( ) ;
         ScanKeyEnd2H87( ) ;
         if ( RcdFound87 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2H87( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2H87( ) ;
         }
         else
         {
            if ( RcdFound87 == 1 )
            {
               if ( A711SerasaProtestosId != Z711SerasaProtestosId )
               {
                  A711SerasaProtestosId = Z711SerasaProtestosId;
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
                  Update2H87( ) ;
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
                  if ( A711SerasaProtestosId != Z711SerasaProtestosId )
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
                        Insert2H87( ) ;
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
                        Insert2H87( ) ;
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
         RowToVars87( bcSerasaProtestos, 1) ;
         SaveImpl( ) ;
         VarsToRow87( bcSerasaProtestos) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars87( bcSerasaProtestos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2H87( ) ;
         AfterTrn( ) ;
         VarsToRow87( bcSerasaProtestos) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow87( bcSerasaProtestos) ;
         }
         else
         {
            SdtSerasaProtestos auxBC = new SdtSerasaProtestos(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A711SerasaProtestosId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSerasaProtestos);
               auxBC.Save();
               bcSerasaProtestos.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars87( bcSerasaProtestos, 1) ;
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
         RowToVars87( bcSerasaProtestos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2H87( ) ;
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
               VarsToRow87( bcSerasaProtestos) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow87( bcSerasaProtestos) ;
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
         RowToVars87( bcSerasaProtestos, 0) ;
         GetKey2H87( ) ;
         if ( RcdFound87 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A711SerasaProtestosId != Z711SerasaProtestosId )
            {
               A711SerasaProtestosId = Z711SerasaProtestosId;
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
            if ( A711SerasaProtestosId != Z711SerasaProtestosId )
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
         context.RollbackDataStores("serasaprotestos_bc",pr_default);
         VarsToRow87( bcSerasaProtestos) ;
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
         Gx_mode = bcSerasaProtestos.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSerasaProtestos.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSerasaProtestos )
         {
            bcSerasaProtestos = (SdtSerasaProtestos)(sdt);
            if ( StringUtil.StrCmp(bcSerasaProtestos.gxTpr_Mode, "") == 0 )
            {
               bcSerasaProtestos.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow87( bcSerasaProtestos) ;
            }
            else
            {
               RowToVars87( bcSerasaProtestos, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSerasaProtestos.gxTpr_Mode, "") == 0 )
            {
               bcSerasaProtestos.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars87( bcSerasaProtestos, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSerasaProtestos SerasaProtestos_BC
      {
         get {
            return bcSerasaProtestos ;
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
         Z712SerasaProtestosData = DateTime.MinValue;
         A712SerasaProtestosData = DateTime.MinValue;
         Z714SerasaProtestosCartorio = "";
         A714SerasaProtestosCartorio = "";
         Z715SerasaProtestosCidade = "";
         A715SerasaProtestosCidade = "";
         BC002H5_A711SerasaProtestosId = new int[1] ;
         BC002H5_A712SerasaProtestosData = new DateTime[] {DateTime.MinValue} ;
         BC002H5_n712SerasaProtestosData = new bool[] {false} ;
         BC002H5_A713SerasaProtestosValor = new decimal[1] ;
         BC002H5_n713SerasaProtestosValor = new bool[] {false} ;
         BC002H5_A714SerasaProtestosCartorio = new string[] {""} ;
         BC002H5_n714SerasaProtestosCartorio = new bool[] {false} ;
         BC002H5_A715SerasaProtestosCidade = new string[] {""} ;
         BC002H5_n715SerasaProtestosCidade = new bool[] {false} ;
         BC002H5_A662SerasaId = new int[1] ;
         BC002H5_n662SerasaId = new bool[] {false} ;
         BC002H4_A662SerasaId = new int[1] ;
         BC002H4_n662SerasaId = new bool[] {false} ;
         BC002H6_A711SerasaProtestosId = new int[1] ;
         BC002H3_A711SerasaProtestosId = new int[1] ;
         BC002H3_A712SerasaProtestosData = new DateTime[] {DateTime.MinValue} ;
         BC002H3_n712SerasaProtestosData = new bool[] {false} ;
         BC002H3_A713SerasaProtestosValor = new decimal[1] ;
         BC002H3_n713SerasaProtestosValor = new bool[] {false} ;
         BC002H3_A714SerasaProtestosCartorio = new string[] {""} ;
         BC002H3_n714SerasaProtestosCartorio = new bool[] {false} ;
         BC002H3_A715SerasaProtestosCidade = new string[] {""} ;
         BC002H3_n715SerasaProtestosCidade = new bool[] {false} ;
         BC002H3_A662SerasaId = new int[1] ;
         BC002H3_n662SerasaId = new bool[] {false} ;
         sMode87 = "";
         BC002H2_A711SerasaProtestosId = new int[1] ;
         BC002H2_A712SerasaProtestosData = new DateTime[] {DateTime.MinValue} ;
         BC002H2_n712SerasaProtestosData = new bool[] {false} ;
         BC002H2_A713SerasaProtestosValor = new decimal[1] ;
         BC002H2_n713SerasaProtestosValor = new bool[] {false} ;
         BC002H2_A714SerasaProtestosCartorio = new string[] {""} ;
         BC002H2_n714SerasaProtestosCartorio = new bool[] {false} ;
         BC002H2_A715SerasaProtestosCidade = new string[] {""} ;
         BC002H2_n715SerasaProtestosCidade = new bool[] {false} ;
         BC002H2_A662SerasaId = new int[1] ;
         BC002H2_n662SerasaId = new bool[] {false} ;
         BC002H8_A711SerasaProtestosId = new int[1] ;
         BC002H11_A711SerasaProtestosId = new int[1] ;
         BC002H11_A712SerasaProtestosData = new DateTime[] {DateTime.MinValue} ;
         BC002H11_n712SerasaProtestosData = new bool[] {false} ;
         BC002H11_A713SerasaProtestosValor = new decimal[1] ;
         BC002H11_n713SerasaProtestosValor = new bool[] {false} ;
         BC002H11_A714SerasaProtestosCartorio = new string[] {""} ;
         BC002H11_n714SerasaProtestosCartorio = new bool[] {false} ;
         BC002H11_A715SerasaProtestosCidade = new string[] {""} ;
         BC002H11_n715SerasaProtestosCidade = new bool[] {false} ;
         BC002H11_A662SerasaId = new int[1] ;
         BC002H11_n662SerasaId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaprotestos_bc__default(),
            new Object[][] {
                new Object[] {
               BC002H2_A711SerasaProtestosId, BC002H2_A712SerasaProtestosData, BC002H2_n712SerasaProtestosData, BC002H2_A713SerasaProtestosValor, BC002H2_n713SerasaProtestosValor, BC002H2_A714SerasaProtestosCartorio, BC002H2_n714SerasaProtestosCartorio, BC002H2_A715SerasaProtestosCidade, BC002H2_n715SerasaProtestosCidade, BC002H2_A662SerasaId,
               BC002H2_n662SerasaId
               }
               , new Object[] {
               BC002H3_A711SerasaProtestosId, BC002H3_A712SerasaProtestosData, BC002H3_n712SerasaProtestosData, BC002H3_A713SerasaProtestosValor, BC002H3_n713SerasaProtestosValor, BC002H3_A714SerasaProtestosCartorio, BC002H3_n714SerasaProtestosCartorio, BC002H3_A715SerasaProtestosCidade, BC002H3_n715SerasaProtestosCidade, BC002H3_A662SerasaId,
               BC002H3_n662SerasaId
               }
               , new Object[] {
               BC002H4_A662SerasaId
               }
               , new Object[] {
               BC002H5_A711SerasaProtestosId, BC002H5_A712SerasaProtestosData, BC002H5_n712SerasaProtestosData, BC002H5_A713SerasaProtestosValor, BC002H5_n713SerasaProtestosValor, BC002H5_A714SerasaProtestosCartorio, BC002H5_n714SerasaProtestosCartorio, BC002H5_A715SerasaProtestosCidade, BC002H5_n715SerasaProtestosCidade, BC002H5_A662SerasaId,
               BC002H5_n662SerasaId
               }
               , new Object[] {
               BC002H6_A711SerasaProtestosId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002H8_A711SerasaProtestosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002H11_A711SerasaProtestosId, BC002H11_A712SerasaProtestosData, BC002H11_n712SerasaProtestosData, BC002H11_A713SerasaProtestosValor, BC002H11_n713SerasaProtestosValor, BC002H11_A714SerasaProtestosCartorio, BC002H11_n714SerasaProtestosCartorio, BC002H11_A715SerasaProtestosCidade, BC002H11_n715SerasaProtestosCidade, BC002H11_A662SerasaId,
               BC002H11_n662SerasaId
               }
            }
         );
         AV19Pgmname = "SerasaProtestos_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122H2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound87 ;
      private int trnEnded ;
      private int Z711SerasaProtestosId ;
      private int A711SerasaProtestosId ;
      private int AV20GXV1 ;
      private int AV11Insert_SerasaId ;
      private int Z662SerasaId ;
      private int A662SerasaId ;
      private decimal Z713SerasaProtestosValor ;
      private decimal A713SerasaProtestosValor ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV19Pgmname ;
      private string sMode87 ;
      private DateTime Z712SerasaProtestosData ;
      private DateTime A712SerasaProtestosData ;
      private bool returnInSub ;
      private bool n712SerasaProtestosData ;
      private bool n713SerasaProtestosValor ;
      private bool n714SerasaProtestosCartorio ;
      private bool n715SerasaProtestosCidade ;
      private bool n662SerasaId ;
      private string Z714SerasaProtestosCartorio ;
      private string A714SerasaProtestosCartorio ;
      private string Z715SerasaProtestosCidade ;
      private string A715SerasaProtestosCidade ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002H5_A711SerasaProtestosId ;
      private DateTime[] BC002H5_A712SerasaProtestosData ;
      private bool[] BC002H5_n712SerasaProtestosData ;
      private decimal[] BC002H5_A713SerasaProtestosValor ;
      private bool[] BC002H5_n713SerasaProtestosValor ;
      private string[] BC002H5_A714SerasaProtestosCartorio ;
      private bool[] BC002H5_n714SerasaProtestosCartorio ;
      private string[] BC002H5_A715SerasaProtestosCidade ;
      private bool[] BC002H5_n715SerasaProtestosCidade ;
      private int[] BC002H5_A662SerasaId ;
      private bool[] BC002H5_n662SerasaId ;
      private int[] BC002H4_A662SerasaId ;
      private bool[] BC002H4_n662SerasaId ;
      private int[] BC002H6_A711SerasaProtestosId ;
      private int[] BC002H3_A711SerasaProtestosId ;
      private DateTime[] BC002H3_A712SerasaProtestosData ;
      private bool[] BC002H3_n712SerasaProtestosData ;
      private decimal[] BC002H3_A713SerasaProtestosValor ;
      private bool[] BC002H3_n713SerasaProtestosValor ;
      private string[] BC002H3_A714SerasaProtestosCartorio ;
      private bool[] BC002H3_n714SerasaProtestosCartorio ;
      private string[] BC002H3_A715SerasaProtestosCidade ;
      private bool[] BC002H3_n715SerasaProtestosCidade ;
      private int[] BC002H3_A662SerasaId ;
      private bool[] BC002H3_n662SerasaId ;
      private int[] BC002H2_A711SerasaProtestosId ;
      private DateTime[] BC002H2_A712SerasaProtestosData ;
      private bool[] BC002H2_n712SerasaProtestosData ;
      private decimal[] BC002H2_A713SerasaProtestosValor ;
      private bool[] BC002H2_n713SerasaProtestosValor ;
      private string[] BC002H2_A714SerasaProtestosCartorio ;
      private bool[] BC002H2_n714SerasaProtestosCartorio ;
      private string[] BC002H2_A715SerasaProtestosCidade ;
      private bool[] BC002H2_n715SerasaProtestosCidade ;
      private int[] BC002H2_A662SerasaId ;
      private bool[] BC002H2_n662SerasaId ;
      private int[] BC002H8_A711SerasaProtestosId ;
      private int[] BC002H11_A711SerasaProtestosId ;
      private DateTime[] BC002H11_A712SerasaProtestosData ;
      private bool[] BC002H11_n712SerasaProtestosData ;
      private decimal[] BC002H11_A713SerasaProtestosValor ;
      private bool[] BC002H11_n713SerasaProtestosValor ;
      private string[] BC002H11_A714SerasaProtestosCartorio ;
      private bool[] BC002H11_n714SerasaProtestosCartorio ;
      private string[] BC002H11_A715SerasaProtestosCidade ;
      private bool[] BC002H11_n715SerasaProtestosCidade ;
      private int[] BC002H11_A662SerasaId ;
      private bool[] BC002H11_n662SerasaId ;
      private SdtSerasaProtestos bcSerasaProtestos ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class serasaprotestos_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC002H2;
          prmBC002H2 = new Object[] {
          new ParDef("SerasaProtestosId",GXType.Int32,9,0)
          };
          Object[] prmBC002H3;
          prmBC002H3 = new Object[] {
          new ParDef("SerasaProtestosId",GXType.Int32,9,0)
          };
          Object[] prmBC002H4;
          prmBC002H4 = new Object[] {
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002H5;
          prmBC002H5 = new Object[] {
          new ParDef("SerasaProtestosId",GXType.Int32,9,0)
          };
          Object[] prmBC002H6;
          prmBC002H6 = new Object[] {
          new ParDef("SerasaProtestosId",GXType.Int32,9,0)
          };
          Object[] prmBC002H7;
          prmBC002H7 = new Object[] {
          new ParDef("SerasaProtestosData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaProtestosValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaProtestosCartorio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaProtestosCidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002H8;
          prmBC002H8 = new Object[] {
          };
          Object[] prmBC002H9;
          prmBC002H9 = new Object[] {
          new ParDef("SerasaProtestosData",GXType.Date,8,0){Nullable=true} ,
          new ParDef("SerasaProtestosValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("SerasaProtestosCartorio",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaProtestosCidade",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("SerasaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SerasaProtestosId",GXType.Int32,9,0)
          };
          Object[] prmBC002H10;
          prmBC002H10 = new Object[] {
          new ParDef("SerasaProtestosId",GXType.Int32,9,0)
          };
          Object[] prmBC002H11;
          prmBC002H11 = new Object[] {
          new ParDef("SerasaProtestosId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002H2", "SELECT SerasaProtestosId, SerasaProtestosData, SerasaProtestosValor, SerasaProtestosCartorio, SerasaProtestosCidade, SerasaId FROM SerasaProtestos WHERE SerasaProtestosId = :SerasaProtestosId  FOR UPDATE OF SerasaProtestos",true, GxErrorMask.GX_NOMASK, false, this,prmBC002H2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002H3", "SELECT SerasaProtestosId, SerasaProtestosData, SerasaProtestosValor, SerasaProtestosCartorio, SerasaProtestosCidade, SerasaId FROM SerasaProtestos WHERE SerasaProtestosId = :SerasaProtestosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002H3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002H4", "SELECT SerasaId FROM Serasa WHERE SerasaId = :SerasaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002H4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002H5", "SELECT TM1.SerasaProtestosId, TM1.SerasaProtestosData, TM1.SerasaProtestosValor, TM1.SerasaProtestosCartorio, TM1.SerasaProtestosCidade, TM1.SerasaId FROM SerasaProtestos TM1 WHERE TM1.SerasaProtestosId = :SerasaProtestosId ORDER BY TM1.SerasaProtestosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002H5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002H6", "SELECT SerasaProtestosId FROM SerasaProtestos WHERE SerasaProtestosId = :SerasaProtestosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002H6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002H7", "SAVEPOINT gxupdate;INSERT INTO SerasaProtestos(SerasaProtestosData, SerasaProtestosValor, SerasaProtestosCartorio, SerasaProtestosCidade, SerasaId) VALUES(:SerasaProtestosData, :SerasaProtestosValor, :SerasaProtestosCartorio, :SerasaProtestosCidade, :SerasaId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002H7)
             ,new CursorDef("BC002H8", "SELECT currval('SerasaProtestosId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002H8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002H9", "SAVEPOINT gxupdate;UPDATE SerasaProtestos SET SerasaProtestosData=:SerasaProtestosData, SerasaProtestosValor=:SerasaProtestosValor, SerasaProtestosCartorio=:SerasaProtestosCartorio, SerasaProtestosCidade=:SerasaProtestosCidade, SerasaId=:SerasaId  WHERE SerasaProtestosId = :SerasaProtestosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002H9)
             ,new CursorDef("BC002H10", "SAVEPOINT gxupdate;DELETE FROM SerasaProtestos  WHERE SerasaProtestosId = :SerasaProtestosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002H10)
             ,new CursorDef("BC002H11", "SELECT TM1.SerasaProtestosId, TM1.SerasaProtestosData, TM1.SerasaProtestosValor, TM1.SerasaProtestosCartorio, TM1.SerasaProtestosCidade, TM1.SerasaId FROM SerasaProtestos TM1 WHERE TM1.SerasaProtestosId = :SerasaProtestosId ORDER BY TM1.SerasaProtestosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002H11,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
