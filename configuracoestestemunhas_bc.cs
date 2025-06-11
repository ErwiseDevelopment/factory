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
   public class configuracoestestemunhas_bc : GxSilentTrn, IGxSilentTrn
   {
      public configuracoestestemunhas_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public configuracoestestemunhas_bc( IGxContext context )
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
         ReadRow1U68( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1U68( ) ;
         standaloneModal( ) ;
         AddRow1U68( ) ;
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
            E111U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z478ConfiguracoesTestemunhasId = A478ConfiguracoesTestemunhasId;
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

      protected void CONFIRM_1U0( )
      {
         BeforeValidate1U68( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1U68( ) ;
            }
            else
            {
               CheckExtendedTable1U68( ) ;
               if ( AnyError == 0 )
               {
                  ZM1U68( 6) ;
               }
               CloseExtendedTableCursors1U68( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E121U2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV21Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV22GXV1 = 1;
            while ( AV22GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV22GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "SecUserId") == 0 )
               {
                  AV19Insert_SecUserId = (short)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV22GXV1 = (int)(AV22GXV1+1);
            }
         }
      }

      protected void E111U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1U68( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z479ConfiguracoesTestemunhasNome = A479ConfiguracoesTestemunhasNome;
            Z480ConfiguracoesTestemunhasDocumento = A480ConfiguracoesTestemunhasDocumento;
            Z481ConfiguracoesTestemunhasEmail = A481ConfiguracoesTestemunhasEmail;
            Z133SecUserId = A133SecUserId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -5 )
         {
            Z478ConfiguracoesTestemunhasId = A478ConfiguracoesTestemunhasId;
            Z479ConfiguracoesTestemunhasNome = A479ConfiguracoesTestemunhasNome;
            Z480ConfiguracoesTestemunhasDocumento = A480ConfiguracoesTestemunhasDocumento;
            Z481ConfiguracoesTestemunhasEmail = A481ConfiguracoesTestemunhasEmail;
            Z133SecUserId = A133SecUserId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV21Pgmname = "ConfiguracoesTestemunhas_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A133SecUserId) && ( Gx_BScreen == 0 ) )
         {
            A133SecUserId = AV8WWPContext.gxTpr_Userid;
            n133SecUserId = false;
         }
      }

      protected void Load1U68( )
      {
         /* Using cursor BC001U5 */
         pr_default.execute(3, new Object[] {A478ConfiguracoesTestemunhasId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound68 = 1;
            A479ConfiguracoesTestemunhasNome = BC001U5_A479ConfiguracoesTestemunhasNome[0];
            n479ConfiguracoesTestemunhasNome = BC001U5_n479ConfiguracoesTestemunhasNome[0];
            A480ConfiguracoesTestemunhasDocumento = BC001U5_A480ConfiguracoesTestemunhasDocumento[0];
            n480ConfiguracoesTestemunhasDocumento = BC001U5_n480ConfiguracoesTestemunhasDocumento[0];
            A481ConfiguracoesTestemunhasEmail = BC001U5_A481ConfiguracoesTestemunhasEmail[0];
            n481ConfiguracoesTestemunhasEmail = BC001U5_n481ConfiguracoesTestemunhasEmail[0];
            A133SecUserId = BC001U5_A133SecUserId[0];
            n133SecUserId = BC001U5_n133SecUserId[0];
            ZM1U68( -5) ;
         }
         pr_default.close(3);
         OnLoadActions1U68( ) ;
      }

      protected void OnLoadActions1U68( )
      {
      }

      protected void CheckExtendedTable1U68( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A481ConfiguracoesTestemunhasEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A481ConfiguracoesTestemunhasEmail)) ) )
         {
            GX_msglist.addItem("O valor de Configuracoes Testemunhas Email não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC001U4 */
         pr_default.execute(2, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A133SecUserId) ) )
            {
               GX_msglist.addItem("Não existe 'User'.", "ForeignKeyNotFound", 1, "SECUSERID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1U68( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1U68( )
      {
         /* Using cursor BC001U6 */
         pr_default.execute(4, new Object[] {A478ConfiguracoesTestemunhasId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound68 = 1;
         }
         else
         {
            RcdFound68 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001U3 */
         pr_default.execute(1, new Object[] {A478ConfiguracoesTestemunhasId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1U68( 5) ;
            RcdFound68 = 1;
            A478ConfiguracoesTestemunhasId = BC001U3_A478ConfiguracoesTestemunhasId[0];
            A479ConfiguracoesTestemunhasNome = BC001U3_A479ConfiguracoesTestemunhasNome[0];
            n479ConfiguracoesTestemunhasNome = BC001U3_n479ConfiguracoesTestemunhasNome[0];
            A480ConfiguracoesTestemunhasDocumento = BC001U3_A480ConfiguracoesTestemunhasDocumento[0];
            n480ConfiguracoesTestemunhasDocumento = BC001U3_n480ConfiguracoesTestemunhasDocumento[0];
            A481ConfiguracoesTestemunhasEmail = BC001U3_A481ConfiguracoesTestemunhasEmail[0];
            n481ConfiguracoesTestemunhasEmail = BC001U3_n481ConfiguracoesTestemunhasEmail[0];
            A133SecUserId = BC001U3_A133SecUserId[0];
            n133SecUserId = BC001U3_n133SecUserId[0];
            Z478ConfiguracoesTestemunhasId = A478ConfiguracoesTestemunhasId;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1U68( ) ;
            if ( AnyError == 1 )
            {
               RcdFound68 = 0;
               InitializeNonKey1U68( ) ;
            }
            Gx_mode = sMode68;
         }
         else
         {
            RcdFound68 = 0;
            InitializeNonKey1U68( ) ;
            sMode68 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode68;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1U68( ) ;
         if ( RcdFound68 == 0 )
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
         CONFIRM_1U0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1U68( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001U2 */
            pr_default.execute(0, new Object[] {A478ConfiguracoesTestemunhasId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConfiguracoesTestemunhas"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z479ConfiguracoesTestemunhasNome, BC001U2_A479ConfiguracoesTestemunhasNome[0]) != 0 ) || ( StringUtil.StrCmp(Z480ConfiguracoesTestemunhasDocumento, BC001U2_A480ConfiguracoesTestemunhasDocumento[0]) != 0 ) || ( StringUtil.StrCmp(Z481ConfiguracoesTestemunhasEmail, BC001U2_A481ConfiguracoesTestemunhasEmail[0]) != 0 ) || ( Z133SecUserId != BC001U2_A133SecUserId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ConfiguracoesTestemunhas"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1U68( )
      {
         BeforeValidate1U68( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U68( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1U68( 0) ;
            CheckOptimisticConcurrency1U68( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U68( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1U68( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001U7 */
                     pr_default.execute(5, new Object[] {n479ConfiguracoesTestemunhasNome, A479ConfiguracoesTestemunhasNome, n480ConfiguracoesTestemunhasDocumento, A480ConfiguracoesTestemunhasDocumento, n481ConfiguracoesTestemunhasEmail, A481ConfiguracoesTestemunhasEmail, n133SecUserId, A133SecUserId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001U8 */
                     pr_default.execute(6);
                     A478ConfiguracoesTestemunhasId = BC001U8_A478ConfiguracoesTestemunhasId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("ConfiguracoesTestemunhas");
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
               Load1U68( ) ;
            }
            EndLevel1U68( ) ;
         }
         CloseExtendedTableCursors1U68( ) ;
      }

      protected void Update1U68( )
      {
         BeforeValidate1U68( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U68( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U68( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U68( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1U68( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001U9 */
                     pr_default.execute(7, new Object[] {n479ConfiguracoesTestemunhasNome, A479ConfiguracoesTestemunhasNome, n480ConfiguracoesTestemunhasDocumento, A480ConfiguracoesTestemunhasDocumento, n481ConfiguracoesTestemunhasEmail, A481ConfiguracoesTestemunhasEmail, n133SecUserId, A133SecUserId, A478ConfiguracoesTestemunhasId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("ConfiguracoesTestemunhas");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ConfiguracoesTestemunhas"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1U68( ) ;
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
            EndLevel1U68( ) ;
         }
         CloseExtendedTableCursors1U68( ) ;
      }

      protected void DeferredUpdate1U68( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1U68( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U68( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1U68( ) ;
            AfterConfirm1U68( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1U68( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001U10 */
                  pr_default.execute(8, new Object[] {A478ConfiguracoesTestemunhasId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("ConfiguracoesTestemunhas");
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
         sMode68 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1U68( ) ;
         Gx_mode = sMode68;
      }

      protected void OnDeleteControls1U68( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1U68( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1U68( ) ;
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

      public void ScanKeyStart1U68( )
      {
         /* Scan By routine */
         /* Using cursor BC001U11 */
         pr_default.execute(9, new Object[] {A478ConfiguracoesTestemunhasId});
         RcdFound68 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound68 = 1;
            A478ConfiguracoesTestemunhasId = BC001U11_A478ConfiguracoesTestemunhasId[0];
            A479ConfiguracoesTestemunhasNome = BC001U11_A479ConfiguracoesTestemunhasNome[0];
            n479ConfiguracoesTestemunhasNome = BC001U11_n479ConfiguracoesTestemunhasNome[0];
            A480ConfiguracoesTestemunhasDocumento = BC001U11_A480ConfiguracoesTestemunhasDocumento[0];
            n480ConfiguracoesTestemunhasDocumento = BC001U11_n480ConfiguracoesTestemunhasDocumento[0];
            A481ConfiguracoesTestemunhasEmail = BC001U11_A481ConfiguracoesTestemunhasEmail[0];
            n481ConfiguracoesTestemunhasEmail = BC001U11_n481ConfiguracoesTestemunhasEmail[0];
            A133SecUserId = BC001U11_A133SecUserId[0];
            n133SecUserId = BC001U11_n133SecUserId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1U68( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound68 = 0;
         ScanKeyLoad1U68( ) ;
      }

      protected void ScanKeyLoad1U68( )
      {
         sMode68 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound68 = 1;
            A478ConfiguracoesTestemunhasId = BC001U11_A478ConfiguracoesTestemunhasId[0];
            A479ConfiguracoesTestemunhasNome = BC001U11_A479ConfiguracoesTestemunhasNome[0];
            n479ConfiguracoesTestemunhasNome = BC001U11_n479ConfiguracoesTestemunhasNome[0];
            A480ConfiguracoesTestemunhasDocumento = BC001U11_A480ConfiguracoesTestemunhasDocumento[0];
            n480ConfiguracoesTestemunhasDocumento = BC001U11_n480ConfiguracoesTestemunhasDocumento[0];
            A481ConfiguracoesTestemunhasEmail = BC001U11_A481ConfiguracoesTestemunhasEmail[0];
            n481ConfiguracoesTestemunhasEmail = BC001U11_n481ConfiguracoesTestemunhasEmail[0];
            A133SecUserId = BC001U11_A133SecUserId[0];
            n133SecUserId = BC001U11_n133SecUserId[0];
         }
         Gx_mode = sMode68;
      }

      protected void ScanKeyEnd1U68( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1U68( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1U68( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1U68( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1U68( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1U68( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1U68( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1U68( )
      {
      }

      protected void send_integrity_lvl_hashes1U68( )
      {
      }

      protected void AddRow1U68( )
      {
         VarsToRow68( bcConfiguracoesTestemunhas) ;
      }

      protected void ReadRow1U68( )
      {
         RowToVars68( bcConfiguracoesTestemunhas, 1) ;
      }

      protected void InitializeNonKey1U68( )
      {
         A479ConfiguracoesTestemunhasNome = "";
         n479ConfiguracoesTestemunhasNome = false;
         A480ConfiguracoesTestemunhasDocumento = "";
         n480ConfiguracoesTestemunhasDocumento = false;
         A481ConfiguracoesTestemunhasEmail = "";
         n481ConfiguracoesTestemunhasEmail = false;
         A133SecUserId = AV8WWPContext.gxTpr_Userid;
         n133SecUserId = false;
         Z479ConfiguracoesTestemunhasNome = "";
         Z480ConfiguracoesTestemunhasDocumento = "";
         Z481ConfiguracoesTestemunhasEmail = "";
         Z133SecUserId = 0;
      }

      protected void InitAll1U68( )
      {
         A478ConfiguracoesTestemunhasId = 0;
         InitializeNonKey1U68( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A133SecUserId = i133SecUserId;
         n133SecUserId = false;
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

      public void VarsToRow68( SdtConfiguracoesTestemunhas obj68 )
      {
         obj68.gxTpr_Mode = Gx_mode;
         obj68.gxTpr_Configuracoestestemunhasnome = A479ConfiguracoesTestemunhasNome;
         obj68.gxTpr_Configuracoestestemunhasdocumento = A480ConfiguracoesTestemunhasDocumento;
         obj68.gxTpr_Configuracoestestemunhasemail = A481ConfiguracoesTestemunhasEmail;
         obj68.gxTpr_Secuserid = A133SecUserId;
         obj68.gxTpr_Configuracoestestemunhasid = A478ConfiguracoesTestemunhasId;
         obj68.gxTpr_Configuracoestestemunhasid_Z = Z478ConfiguracoesTestemunhasId;
         obj68.gxTpr_Configuracoestestemunhasnome_Z = Z479ConfiguracoesTestemunhasNome;
         obj68.gxTpr_Configuracoestestemunhasdocumento_Z = Z480ConfiguracoesTestemunhasDocumento;
         obj68.gxTpr_Configuracoestestemunhasemail_Z = Z481ConfiguracoesTestemunhasEmail;
         obj68.gxTpr_Secuserid_Z = Z133SecUserId;
         obj68.gxTpr_Configuracoestestemunhasnome_N = (short)(Convert.ToInt16(n479ConfiguracoesTestemunhasNome));
         obj68.gxTpr_Configuracoestestemunhasdocumento_N = (short)(Convert.ToInt16(n480ConfiguracoesTestemunhasDocumento));
         obj68.gxTpr_Configuracoestestemunhasemail_N = (short)(Convert.ToInt16(n481ConfiguracoesTestemunhasEmail));
         obj68.gxTpr_Secuserid_N = (short)(Convert.ToInt16(n133SecUserId));
         obj68.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow68( SdtConfiguracoesTestemunhas obj68 )
      {
         obj68.gxTpr_Configuracoestestemunhasid = A478ConfiguracoesTestemunhasId;
         return  ;
      }

      public void RowToVars68( SdtConfiguracoesTestemunhas obj68 ,
                               int forceLoad )
      {
         Gx_mode = obj68.gxTpr_Mode;
         A479ConfiguracoesTestemunhasNome = obj68.gxTpr_Configuracoestestemunhasnome;
         n479ConfiguracoesTestemunhasNome = false;
         A480ConfiguracoesTestemunhasDocumento = obj68.gxTpr_Configuracoestestemunhasdocumento;
         n480ConfiguracoesTestemunhasDocumento = false;
         A481ConfiguracoesTestemunhasEmail = obj68.gxTpr_Configuracoestestemunhasemail;
         n481ConfiguracoesTestemunhasEmail = false;
         A133SecUserId = obj68.gxTpr_Secuserid;
         n133SecUserId = false;
         A478ConfiguracoesTestemunhasId = obj68.gxTpr_Configuracoestestemunhasid;
         Z478ConfiguracoesTestemunhasId = obj68.gxTpr_Configuracoestestemunhasid_Z;
         Z479ConfiguracoesTestemunhasNome = obj68.gxTpr_Configuracoestestemunhasnome_Z;
         Z480ConfiguracoesTestemunhasDocumento = obj68.gxTpr_Configuracoestestemunhasdocumento_Z;
         Z481ConfiguracoesTestemunhasEmail = obj68.gxTpr_Configuracoestestemunhasemail_Z;
         Z133SecUserId = obj68.gxTpr_Secuserid_Z;
         n479ConfiguracoesTestemunhasNome = (bool)(Convert.ToBoolean(obj68.gxTpr_Configuracoestestemunhasnome_N));
         n480ConfiguracoesTestemunhasDocumento = (bool)(Convert.ToBoolean(obj68.gxTpr_Configuracoestestemunhasdocumento_N));
         n481ConfiguracoesTestemunhasEmail = (bool)(Convert.ToBoolean(obj68.gxTpr_Configuracoestestemunhasemail_N));
         n133SecUserId = (bool)(Convert.ToBoolean(obj68.gxTpr_Secuserid_N));
         Gx_mode = obj68.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A478ConfiguracoesTestemunhasId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1U68( ) ;
         ScanKeyStart1U68( ) ;
         if ( RcdFound68 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z478ConfiguracoesTestemunhasId = A478ConfiguracoesTestemunhasId;
         }
         ZM1U68( -5) ;
         OnLoadActions1U68( ) ;
         AddRow1U68( ) ;
         ScanKeyEnd1U68( ) ;
         if ( RcdFound68 == 0 )
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
         RowToVars68( bcConfiguracoesTestemunhas, 0) ;
         ScanKeyStart1U68( ) ;
         if ( RcdFound68 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z478ConfiguracoesTestemunhasId = A478ConfiguracoesTestemunhasId;
         }
         ZM1U68( -5) ;
         OnLoadActions1U68( ) ;
         AddRow1U68( ) ;
         ScanKeyEnd1U68( ) ;
         if ( RcdFound68 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1U68( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1U68( ) ;
         }
         else
         {
            if ( RcdFound68 == 1 )
            {
               if ( A478ConfiguracoesTestemunhasId != Z478ConfiguracoesTestemunhasId )
               {
                  A478ConfiguracoesTestemunhasId = Z478ConfiguracoesTestemunhasId;
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
                  Update1U68( ) ;
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
                  if ( A478ConfiguracoesTestemunhasId != Z478ConfiguracoesTestemunhasId )
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
                        Insert1U68( ) ;
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
                        Insert1U68( ) ;
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
         RowToVars68( bcConfiguracoesTestemunhas, 1) ;
         SaveImpl( ) ;
         VarsToRow68( bcConfiguracoesTestemunhas) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars68( bcConfiguracoesTestemunhas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1U68( ) ;
         AfterTrn( ) ;
         VarsToRow68( bcConfiguracoesTestemunhas) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow68( bcConfiguracoesTestemunhas) ;
         }
         else
         {
            SdtConfiguracoesTestemunhas auxBC = new SdtConfiguracoesTestemunhas(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A478ConfiguracoesTestemunhasId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcConfiguracoesTestemunhas);
               auxBC.Save();
               bcConfiguracoesTestemunhas.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars68( bcConfiguracoesTestemunhas, 1) ;
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
         RowToVars68( bcConfiguracoesTestemunhas, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1U68( ) ;
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
               VarsToRow68( bcConfiguracoesTestemunhas) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow68( bcConfiguracoesTestemunhas) ;
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
         RowToVars68( bcConfiguracoesTestemunhas, 0) ;
         GetKey1U68( ) ;
         if ( RcdFound68 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A478ConfiguracoesTestemunhasId != Z478ConfiguracoesTestemunhasId )
            {
               A478ConfiguracoesTestemunhasId = Z478ConfiguracoesTestemunhasId;
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
            if ( A478ConfiguracoesTestemunhasId != Z478ConfiguracoesTestemunhasId )
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
         context.RollbackDataStores("configuracoestestemunhas_bc",pr_default);
         VarsToRow68( bcConfiguracoesTestemunhas) ;
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
         Gx_mode = bcConfiguracoesTestemunhas.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcConfiguracoesTestemunhas.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcConfiguracoesTestemunhas )
         {
            bcConfiguracoesTestemunhas = (SdtConfiguracoesTestemunhas)(sdt);
            if ( StringUtil.StrCmp(bcConfiguracoesTestemunhas.gxTpr_Mode, "") == 0 )
            {
               bcConfiguracoesTestemunhas.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow68( bcConfiguracoesTestemunhas) ;
            }
            else
            {
               RowToVars68( bcConfiguracoesTestemunhas, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcConfiguracoesTestemunhas.gxTpr_Mode, "") == 0 )
            {
               bcConfiguracoesTestemunhas.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars68( bcConfiguracoesTestemunhas, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtConfiguracoesTestemunhas ConfiguracoesTestemunhas_BC
      {
         get {
            return bcConfiguracoesTestemunhas ;
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
         AV21Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z479ConfiguracoesTestemunhasNome = "";
         A479ConfiguracoesTestemunhasNome = "";
         Z480ConfiguracoesTestemunhasDocumento = "";
         A480ConfiguracoesTestemunhasDocumento = "";
         Z481ConfiguracoesTestemunhasEmail = "";
         A481ConfiguracoesTestemunhasEmail = "";
         BC001U5_A478ConfiguracoesTestemunhasId = new int[1] ;
         BC001U5_A479ConfiguracoesTestemunhasNome = new string[] {""} ;
         BC001U5_n479ConfiguracoesTestemunhasNome = new bool[] {false} ;
         BC001U5_A480ConfiguracoesTestemunhasDocumento = new string[] {""} ;
         BC001U5_n480ConfiguracoesTestemunhasDocumento = new bool[] {false} ;
         BC001U5_A481ConfiguracoesTestemunhasEmail = new string[] {""} ;
         BC001U5_n481ConfiguracoesTestemunhasEmail = new bool[] {false} ;
         BC001U5_A133SecUserId = new short[1] ;
         BC001U5_n133SecUserId = new bool[] {false} ;
         BC001U4_A133SecUserId = new short[1] ;
         BC001U4_n133SecUserId = new bool[] {false} ;
         BC001U6_A478ConfiguracoesTestemunhasId = new int[1] ;
         BC001U3_A478ConfiguracoesTestemunhasId = new int[1] ;
         BC001U3_A479ConfiguracoesTestemunhasNome = new string[] {""} ;
         BC001U3_n479ConfiguracoesTestemunhasNome = new bool[] {false} ;
         BC001U3_A480ConfiguracoesTestemunhasDocumento = new string[] {""} ;
         BC001U3_n480ConfiguracoesTestemunhasDocumento = new bool[] {false} ;
         BC001U3_A481ConfiguracoesTestemunhasEmail = new string[] {""} ;
         BC001U3_n481ConfiguracoesTestemunhasEmail = new bool[] {false} ;
         BC001U3_A133SecUserId = new short[1] ;
         BC001U3_n133SecUserId = new bool[] {false} ;
         sMode68 = "";
         BC001U2_A478ConfiguracoesTestemunhasId = new int[1] ;
         BC001U2_A479ConfiguracoesTestemunhasNome = new string[] {""} ;
         BC001U2_n479ConfiguracoesTestemunhasNome = new bool[] {false} ;
         BC001U2_A480ConfiguracoesTestemunhasDocumento = new string[] {""} ;
         BC001U2_n480ConfiguracoesTestemunhasDocumento = new bool[] {false} ;
         BC001U2_A481ConfiguracoesTestemunhasEmail = new string[] {""} ;
         BC001U2_n481ConfiguracoesTestemunhasEmail = new bool[] {false} ;
         BC001U2_A133SecUserId = new short[1] ;
         BC001U2_n133SecUserId = new bool[] {false} ;
         BC001U8_A478ConfiguracoesTestemunhasId = new int[1] ;
         BC001U11_A478ConfiguracoesTestemunhasId = new int[1] ;
         BC001U11_A479ConfiguracoesTestemunhasNome = new string[] {""} ;
         BC001U11_n479ConfiguracoesTestemunhasNome = new bool[] {false} ;
         BC001U11_A480ConfiguracoesTestemunhasDocumento = new string[] {""} ;
         BC001U11_n480ConfiguracoesTestemunhasDocumento = new bool[] {false} ;
         BC001U11_A481ConfiguracoesTestemunhasEmail = new string[] {""} ;
         BC001U11_n481ConfiguracoesTestemunhasEmail = new bool[] {false} ;
         BC001U11_A133SecUserId = new short[1] ;
         BC001U11_n133SecUserId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracoestestemunhas_bc__default(),
            new Object[][] {
                new Object[] {
               BC001U2_A478ConfiguracoesTestemunhasId, BC001U2_A479ConfiguracoesTestemunhasNome, BC001U2_n479ConfiguracoesTestemunhasNome, BC001U2_A480ConfiguracoesTestemunhasDocumento, BC001U2_n480ConfiguracoesTestemunhasDocumento, BC001U2_A481ConfiguracoesTestemunhasEmail, BC001U2_n481ConfiguracoesTestemunhasEmail, BC001U2_A133SecUserId, BC001U2_n133SecUserId
               }
               , new Object[] {
               BC001U3_A478ConfiguracoesTestemunhasId, BC001U3_A479ConfiguracoesTestemunhasNome, BC001U3_n479ConfiguracoesTestemunhasNome, BC001U3_A480ConfiguracoesTestemunhasDocumento, BC001U3_n480ConfiguracoesTestemunhasDocumento, BC001U3_A481ConfiguracoesTestemunhasEmail, BC001U3_n481ConfiguracoesTestemunhasEmail, BC001U3_A133SecUserId, BC001U3_n133SecUserId
               }
               , new Object[] {
               BC001U4_A133SecUserId
               }
               , new Object[] {
               BC001U5_A478ConfiguracoesTestemunhasId, BC001U5_A479ConfiguracoesTestemunhasNome, BC001U5_n479ConfiguracoesTestemunhasNome, BC001U5_A480ConfiguracoesTestemunhasDocumento, BC001U5_n480ConfiguracoesTestemunhasDocumento, BC001U5_A481ConfiguracoesTestemunhasEmail, BC001U5_n481ConfiguracoesTestemunhasEmail, BC001U5_A133SecUserId, BC001U5_n133SecUserId
               }
               , new Object[] {
               BC001U6_A478ConfiguracoesTestemunhasId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001U8_A478ConfiguracoesTestemunhasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001U11_A478ConfiguracoesTestemunhasId, BC001U11_A479ConfiguracoesTestemunhasNome, BC001U11_n479ConfiguracoesTestemunhasNome, BC001U11_A480ConfiguracoesTestemunhasDocumento, BC001U11_n480ConfiguracoesTestemunhasDocumento, BC001U11_A481ConfiguracoesTestemunhasEmail, BC001U11_n481ConfiguracoesTestemunhasEmail, BC001U11_A133SecUserId, BC001U11_n133SecUserId
               }
            }
         );
         AV21Pgmname = "ConfiguracoesTestemunhas_BC";
         Z133SecUserId = AV8WWPContext.gxTpr_Userid;
         n133SecUserId = false;
         A133SecUserId = AV8WWPContext.gxTpr_Userid;
         n133SecUserId = false;
         i133SecUserId = AV8WWPContext.gxTpr_Userid;
         n133SecUserId = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E121U2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV19Insert_SecUserId ;
      private short Z133SecUserId ;
      private short A133SecUserId ;
      private short Gx_BScreen ;
      private short RcdFound68 ;
      private short i133SecUserId ;
      private int trnEnded ;
      private int Z478ConfiguracoesTestemunhasId ;
      private int A478ConfiguracoesTestemunhasId ;
      private int AV22GXV1 ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV21Pgmname ;
      private string sMode68 ;
      private bool returnInSub ;
      private bool n133SecUserId ;
      private bool n479ConfiguracoesTestemunhasNome ;
      private bool n480ConfiguracoesTestemunhasDocumento ;
      private bool n481ConfiguracoesTestemunhasEmail ;
      private string Z479ConfiguracoesTestemunhasNome ;
      private string A479ConfiguracoesTestemunhasNome ;
      private string Z480ConfiguracoesTestemunhasDocumento ;
      private string A480ConfiguracoesTestemunhasDocumento ;
      private string Z481ConfiguracoesTestemunhasEmail ;
      private string A481ConfiguracoesTestemunhasEmail ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC001U5_A478ConfiguracoesTestemunhasId ;
      private string[] BC001U5_A479ConfiguracoesTestemunhasNome ;
      private bool[] BC001U5_n479ConfiguracoesTestemunhasNome ;
      private string[] BC001U5_A480ConfiguracoesTestemunhasDocumento ;
      private bool[] BC001U5_n480ConfiguracoesTestemunhasDocumento ;
      private string[] BC001U5_A481ConfiguracoesTestemunhasEmail ;
      private bool[] BC001U5_n481ConfiguracoesTestemunhasEmail ;
      private short[] BC001U5_A133SecUserId ;
      private bool[] BC001U5_n133SecUserId ;
      private short[] BC001U4_A133SecUserId ;
      private bool[] BC001U4_n133SecUserId ;
      private int[] BC001U6_A478ConfiguracoesTestemunhasId ;
      private int[] BC001U3_A478ConfiguracoesTestemunhasId ;
      private string[] BC001U3_A479ConfiguracoesTestemunhasNome ;
      private bool[] BC001U3_n479ConfiguracoesTestemunhasNome ;
      private string[] BC001U3_A480ConfiguracoesTestemunhasDocumento ;
      private bool[] BC001U3_n480ConfiguracoesTestemunhasDocumento ;
      private string[] BC001U3_A481ConfiguracoesTestemunhasEmail ;
      private bool[] BC001U3_n481ConfiguracoesTestemunhasEmail ;
      private short[] BC001U3_A133SecUserId ;
      private bool[] BC001U3_n133SecUserId ;
      private int[] BC001U2_A478ConfiguracoesTestemunhasId ;
      private string[] BC001U2_A479ConfiguracoesTestemunhasNome ;
      private bool[] BC001U2_n479ConfiguracoesTestemunhasNome ;
      private string[] BC001U2_A480ConfiguracoesTestemunhasDocumento ;
      private bool[] BC001U2_n480ConfiguracoesTestemunhasDocumento ;
      private string[] BC001U2_A481ConfiguracoesTestemunhasEmail ;
      private bool[] BC001U2_n481ConfiguracoesTestemunhasEmail ;
      private short[] BC001U2_A133SecUserId ;
      private bool[] BC001U2_n133SecUserId ;
      private int[] BC001U8_A478ConfiguracoesTestemunhasId ;
      private int[] BC001U11_A478ConfiguracoesTestemunhasId ;
      private string[] BC001U11_A479ConfiguracoesTestemunhasNome ;
      private bool[] BC001U11_n479ConfiguracoesTestemunhasNome ;
      private string[] BC001U11_A480ConfiguracoesTestemunhasDocumento ;
      private bool[] BC001U11_n480ConfiguracoesTestemunhasDocumento ;
      private string[] BC001U11_A481ConfiguracoesTestemunhasEmail ;
      private bool[] BC001U11_n481ConfiguracoesTestemunhasEmail ;
      private short[] BC001U11_A133SecUserId ;
      private bool[] BC001U11_n133SecUserId ;
      private SdtConfiguracoesTestemunhas bcConfiguracoesTestemunhas ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class configuracoestestemunhas_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC001U2;
          prmBC001U2 = new Object[] {
          new ParDef("ConfiguracoesTestemunhasId",GXType.Int32,9,0)
          };
          Object[] prmBC001U3;
          prmBC001U3 = new Object[] {
          new ParDef("ConfiguracoesTestemunhasId",GXType.Int32,9,0)
          };
          Object[] prmBC001U4;
          prmBC001U4 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001U5;
          prmBC001U5 = new Object[] {
          new ParDef("ConfiguracoesTestemunhasId",GXType.Int32,9,0)
          };
          Object[] prmBC001U6;
          prmBC001U6 = new Object[] {
          new ParDef("ConfiguracoesTestemunhasId",GXType.Int32,9,0)
          };
          Object[] prmBC001U7;
          prmBC001U7 = new Object[] {
          new ParDef("ConfiguracoesTestemunhasNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("ConfiguracoesTestemunhasDocumento",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConfiguracoesTestemunhasEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001U8;
          prmBC001U8 = new Object[] {
          };
          Object[] prmBC001U9;
          prmBC001U9 = new Object[] {
          new ParDef("ConfiguracoesTestemunhasNome",GXType.VarChar,70,0){Nullable=true} ,
          new ParDef("ConfiguracoesTestemunhasDocumento",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ConfiguracoesTestemunhasEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ConfiguracoesTestemunhasId",GXType.Int32,9,0)
          };
          Object[] prmBC001U10;
          prmBC001U10 = new Object[] {
          new ParDef("ConfiguracoesTestemunhasId",GXType.Int32,9,0)
          };
          Object[] prmBC001U11;
          prmBC001U11 = new Object[] {
          new ParDef("ConfiguracoesTestemunhasId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC001U2", "SELECT ConfiguracoesTestemunhasId, ConfiguracoesTestemunhasNome, ConfiguracoesTestemunhasDocumento, ConfiguracoesTestemunhasEmail, SecUserId FROM ConfiguracoesTestemunhas WHERE ConfiguracoesTestemunhasId = :ConfiguracoesTestemunhasId  FOR UPDATE OF ConfiguracoesTestemunhas",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001U3", "SELECT ConfiguracoesTestemunhasId, ConfiguracoesTestemunhasNome, ConfiguracoesTestemunhasDocumento, ConfiguracoesTestemunhasEmail, SecUserId FROM ConfiguracoesTestemunhas WHERE ConfiguracoesTestemunhasId = :ConfiguracoesTestemunhasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001U4", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001U5", "SELECT TM1.ConfiguracoesTestemunhasId, TM1.ConfiguracoesTestemunhasNome, TM1.ConfiguracoesTestemunhasDocumento, TM1.ConfiguracoesTestemunhasEmail, TM1.SecUserId FROM ConfiguracoesTestemunhas TM1 WHERE TM1.ConfiguracoesTestemunhasId = :ConfiguracoesTestemunhasId ORDER BY TM1.ConfiguracoesTestemunhasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001U6", "SELECT ConfiguracoesTestemunhasId FROM ConfiguracoesTestemunhas WHERE ConfiguracoesTestemunhasId = :ConfiguracoesTestemunhasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001U7", "SAVEPOINT gxupdate;INSERT INTO ConfiguracoesTestemunhas(ConfiguracoesTestemunhasNome, ConfiguracoesTestemunhasDocumento, ConfiguracoesTestemunhasEmail, SecUserId) VALUES(:ConfiguracoesTestemunhasNome, :ConfiguracoesTestemunhasDocumento, :ConfiguracoesTestemunhasEmail, :SecUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001U7)
             ,new CursorDef("BC001U8", "SELECT currval('ConfiguracoesTestemunhasId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001U9", "SAVEPOINT gxupdate;UPDATE ConfiguracoesTestemunhas SET ConfiguracoesTestemunhasNome=:ConfiguracoesTestemunhasNome, ConfiguracoesTestemunhasDocumento=:ConfiguracoesTestemunhasDocumento, ConfiguracoesTestemunhasEmail=:ConfiguracoesTestemunhasEmail, SecUserId=:SecUserId  WHERE ConfiguracoesTestemunhasId = :ConfiguracoesTestemunhasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001U9)
             ,new CursorDef("BC001U10", "SAVEPOINT gxupdate;DELETE FROM ConfiguracoesTestemunhas  WHERE ConfiguracoesTestemunhasId = :ConfiguracoesTestemunhasId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001U10)
             ,new CursorDef("BC001U11", "SELECT TM1.ConfiguracoesTestemunhasId, TM1.ConfiguracoesTestemunhasNome, TM1.ConfiguracoesTestemunhasDocumento, TM1.ConfiguracoesTestemunhasEmail, TM1.SecUserId FROM ConfiguracoesTestemunhas TM1 WHERE TM1.ConfiguracoesTestemunhasId = :ConfiguracoesTestemunhasId ORDER BY TM1.ConfiguracoesTestemunhasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001U11,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
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
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
