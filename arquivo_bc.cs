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
   public class arquivo_bc : GxSilentTrn, IGxSilentTrn
   {
      public arquivo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public arquivo_bc( IGxContext context )
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
         ReadRow0Y37( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0Y37( ) ;
         standaloneModal( ) ;
         AddRow0Y37( ) ;
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
               Z231ArquivoId = A231ArquivoId;
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

      protected void CONFIRM_0Y0( )
      {
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Y37( ) ;
            }
            else
            {
               CheckExtendedTable0Y37( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0Y37( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM0Y37( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z231ArquivoId = A231ArquivoId;
            Z232ArquivoBlob = A232ArquivoBlob;
            Z254ArquivoExtensao = A254ArquivoExtensao;
            Z255ArquivoNome = A255ArquivoNome;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0Y37( )
      {
         /* Using cursor BC000Y4 */
         pr_default.execute(2, new Object[] {n231ArquivoId, A231ArquivoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound37 = 1;
            A254ArquivoExtensao = BC000Y4_A254ArquivoExtensao[0];
            n254ArquivoExtensao = BC000Y4_n254ArquivoExtensao[0];
            A232ArquivoBlob_Filetype = A254ArquivoExtensao;
            A255ArquivoNome = BC000Y4_A255ArquivoNome[0];
            n255ArquivoNome = BC000Y4_n255ArquivoNome[0];
            A232ArquivoBlob_Filename = A255ArquivoNome;
            A232ArquivoBlob = BC000Y4_A232ArquivoBlob[0];
            n232ArquivoBlob = BC000Y4_n232ArquivoBlob[0];
            ZM0Y37( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0Y37( ) ;
      }

      protected void OnLoadActions0Y37( )
      {
      }

      protected void CheckExtendedTable0Y37( )
      {
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0Y37( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Y37( )
      {
         /* Using cursor BC000Y5 */
         pr_default.execute(3, new Object[] {n231ArquivoId, A231ArquivoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound37 = 1;
         }
         else
         {
            RcdFound37 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000Y3 */
         pr_default.execute(1, new Object[] {n231ArquivoId, A231ArquivoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Y37( 1) ;
            RcdFound37 = 1;
            A231ArquivoId = BC000Y3_A231ArquivoId[0];
            n231ArquivoId = BC000Y3_n231ArquivoId[0];
            A254ArquivoExtensao = BC000Y3_A254ArquivoExtensao[0];
            n254ArquivoExtensao = BC000Y3_n254ArquivoExtensao[0];
            A232ArquivoBlob_Filetype = A254ArquivoExtensao;
            A255ArquivoNome = BC000Y3_A255ArquivoNome[0];
            n255ArquivoNome = BC000Y3_n255ArquivoNome[0];
            A232ArquivoBlob_Filename = A255ArquivoNome;
            A232ArquivoBlob = BC000Y3_A232ArquivoBlob[0];
            n232ArquivoBlob = BC000Y3_n232ArquivoBlob[0];
            Z231ArquivoId = A231ArquivoId;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0Y37( ) ;
            if ( AnyError == 1 )
            {
               RcdFound37 = 0;
               InitializeNonKey0Y37( ) ;
            }
            Gx_mode = sMode37;
         }
         else
         {
            RcdFound37 = 0;
            InitializeNonKey0Y37( ) ;
            sMode37 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode37;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Y37( ) ;
         if ( RcdFound37 == 0 )
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
         CONFIRM_0Y0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0Y37( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Y2 */
            pr_default.execute(0, new Object[] {n231ArquivoId, A231ArquivoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Arquivo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Arquivo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Y37( )
      {
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Y37( 0) ;
            CheckOptimisticConcurrency0Y37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Y37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Y6 */
                     pr_default.execute(4, new Object[] {n232ArquivoBlob, A232ArquivoBlob, n254ArquivoExtensao, A254ArquivoExtensao, n255ArquivoNome, A255ArquivoNome});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000Y7 */
                     pr_default.execute(5);
                     A231ArquivoId = BC000Y7_A231ArquivoId[0];
                     n231ArquivoId = BC000Y7_n231ArquivoId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Arquivo");
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
               Load0Y37( ) ;
            }
            EndLevel0Y37( ) ;
         }
         CloseExtendedTableCursors0Y37( ) ;
      }

      protected void Update0Y37( )
      {
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y37( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Y37( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Y37( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Y8 */
                     pr_default.execute(6, new Object[] {n254ArquivoExtensao, A254ArquivoExtensao, n255ArquivoNome, A255ArquivoNome, n231ArquivoId, A231ArquivoId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Arquivo");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Arquivo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Y37( ) ;
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
            EndLevel0Y37( ) ;
         }
         CloseExtendedTableCursors0Y37( ) ;
      }

      protected void DeferredUpdate0Y37( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000Y9 */
            pr_default.execute(7, new Object[] {n232ArquivoBlob, A232ArquivoBlob, n231ArquivoId, A231ArquivoId});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("Arquivo");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Y37( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Y37( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Y37( ) ;
            AfterConfirm0Y37( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Y37( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000Y10 */
                  pr_default.execute(8, new Object[] {n231ArquivoId, A231ArquivoId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Arquivo");
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
         sMode37 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Y37( ) ;
         Gx_mode = sMode37;
      }

      protected void OnDeleteControls0Y37( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000Y11 */
            pr_default.execute(9, new Object[] {n231ArquivoId, A231ArquivoId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Assinatura"+" ("+"Sb Arquivo Assinado"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000Y12 */
            pr_default.execute(10, new Object[] {n231ArquivoId, A231ArquivoId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Assinatura"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel0Y37( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Y37( ) ;
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

      public void ScanKeyStart0Y37( )
      {
         /* Using cursor BC000Y13 */
         pr_default.execute(11, new Object[] {n231ArquivoId, A231ArquivoId});
         RcdFound37 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound37 = 1;
            A231ArquivoId = BC000Y13_A231ArquivoId[0];
            n231ArquivoId = BC000Y13_n231ArquivoId[0];
            A254ArquivoExtensao = BC000Y13_A254ArquivoExtensao[0];
            n254ArquivoExtensao = BC000Y13_n254ArquivoExtensao[0];
            A232ArquivoBlob_Filetype = A254ArquivoExtensao;
            A255ArquivoNome = BC000Y13_A255ArquivoNome[0];
            n255ArquivoNome = BC000Y13_n255ArquivoNome[0];
            A232ArquivoBlob_Filename = A255ArquivoNome;
            A232ArquivoBlob = BC000Y13_A232ArquivoBlob[0];
            n232ArquivoBlob = BC000Y13_n232ArquivoBlob[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Y37( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound37 = 0;
         ScanKeyLoad0Y37( ) ;
      }

      protected void ScanKeyLoad0Y37( )
      {
         sMode37 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound37 = 1;
            A231ArquivoId = BC000Y13_A231ArquivoId[0];
            n231ArquivoId = BC000Y13_n231ArquivoId[0];
            A254ArquivoExtensao = BC000Y13_A254ArquivoExtensao[0];
            n254ArquivoExtensao = BC000Y13_n254ArquivoExtensao[0];
            A232ArquivoBlob_Filetype = A254ArquivoExtensao;
            A255ArquivoNome = BC000Y13_A255ArquivoNome[0];
            n255ArquivoNome = BC000Y13_n255ArquivoNome[0];
            A232ArquivoBlob_Filename = A255ArquivoNome;
            A232ArquivoBlob = BC000Y13_A232ArquivoBlob[0];
            n232ArquivoBlob = BC000Y13_n232ArquivoBlob[0];
         }
         Gx_mode = sMode37;
      }

      protected void ScanKeyEnd0Y37( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0Y37( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Y37( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Y37( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Y37( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Y37( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Y37( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Y37( )
      {
      }

      protected void send_integrity_lvl_hashes0Y37( )
      {
      }

      protected void AddRow0Y37( )
      {
         VarsToRow37( bcArquivo) ;
      }

      protected void ReadRow0Y37( )
      {
         RowToVars37( bcArquivo, 1) ;
      }

      protected void InitializeNonKey0Y37( )
      {
         A232ArquivoBlob = "";
         n232ArquivoBlob = false;
         A254ArquivoExtensao = "";
         n254ArquivoExtensao = false;
         A255ArquivoNome = "";
         n255ArquivoNome = false;
      }

      protected void InitAll0Y37( )
      {
         A231ArquivoId = 0;
         n231ArquivoId = false;
         InitializeNonKey0Y37( ) ;
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

      public void VarsToRow37( SdtArquivo obj37 )
      {
         obj37.gxTpr_Mode = Gx_mode;
         obj37.gxTpr_Arquivoblob = A232ArquivoBlob;
         obj37.gxTpr_Arquivoextensao = A254ArquivoExtensao;
         obj37.gxTpr_Arquivonome = A255ArquivoNome;
         obj37.gxTpr_Arquivoid = A231ArquivoId;
         obj37.gxTpr_Arquivoid_Z = Z231ArquivoId;
         obj37.gxTpr_Arquivonome_Z = Z255ArquivoNome;
         obj37.gxTpr_Arquivoextensao_Z = Z254ArquivoExtensao;
         obj37.gxTpr_Arquivoid_N = (short)(Convert.ToInt16(n231ArquivoId));
         obj37.gxTpr_Arquivonome_N = (short)(Convert.ToInt16(n255ArquivoNome));
         obj37.gxTpr_Arquivoextensao_N = (short)(Convert.ToInt16(n254ArquivoExtensao));
         obj37.gxTpr_Arquivoblob_N = (short)(Convert.ToInt16(n232ArquivoBlob));
         obj37.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow37( SdtArquivo obj37 )
      {
         obj37.gxTpr_Arquivoid = A231ArquivoId;
         return  ;
      }

      public void RowToVars37( SdtArquivo obj37 ,
                               int forceLoad )
      {
         Gx_mode = obj37.gxTpr_Mode;
         A232ArquivoBlob = obj37.gxTpr_Arquivoblob;
         n232ArquivoBlob = false;
         A254ArquivoExtensao = (String.IsNullOrEmpty(StringUtil.RTrim( obj37.gxTpr_Arquivoextensao)) ? FileUtil.GetFileType( A232ArquivoBlob) : obj37.gxTpr_Arquivoextensao);
         n254ArquivoExtensao = false;
         A255ArquivoNome = (String.IsNullOrEmpty(StringUtil.RTrim( obj37.gxTpr_Arquivonome)) ? FileUtil.GetFileName( A232ArquivoBlob) : obj37.gxTpr_Arquivonome);
         n255ArquivoNome = false;
         A231ArquivoId = obj37.gxTpr_Arquivoid;
         n231ArquivoId = false;
         Z231ArquivoId = obj37.gxTpr_Arquivoid_Z;
         Z255ArquivoNome = obj37.gxTpr_Arquivonome_Z;
         Z254ArquivoExtensao = obj37.gxTpr_Arquivoextensao_Z;
         n231ArquivoId = (bool)(Convert.ToBoolean(obj37.gxTpr_Arquivoid_N));
         n255ArquivoNome = (bool)(Convert.ToBoolean(obj37.gxTpr_Arquivonome_N));
         n254ArquivoExtensao = (bool)(Convert.ToBoolean(obj37.gxTpr_Arquivoextensao_N));
         n232ArquivoBlob = (bool)(Convert.ToBoolean(obj37.gxTpr_Arquivoblob_N));
         Gx_mode = obj37.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A231ArquivoId = (int)getParm(obj,0);
         n231ArquivoId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0Y37( ) ;
         ScanKeyStart0Y37( ) ;
         if ( RcdFound37 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z231ArquivoId = A231ArquivoId;
         }
         ZM0Y37( -1) ;
         OnLoadActions0Y37( ) ;
         AddRow0Y37( ) ;
         ScanKeyEnd0Y37( ) ;
         if ( RcdFound37 == 0 )
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
         RowToVars37( bcArquivo, 0) ;
         ScanKeyStart0Y37( ) ;
         if ( RcdFound37 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z231ArquivoId = A231ArquivoId;
         }
         ZM0Y37( -1) ;
         OnLoadActions0Y37( ) ;
         AddRow0Y37( ) ;
         ScanKeyEnd0Y37( ) ;
         if ( RcdFound37 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0Y37( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0Y37( ) ;
         }
         else
         {
            if ( RcdFound37 == 1 )
            {
               if ( A231ArquivoId != Z231ArquivoId )
               {
                  A231ArquivoId = Z231ArquivoId;
                  n231ArquivoId = false;
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
                  Update0Y37( ) ;
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
                  if ( A231ArquivoId != Z231ArquivoId )
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
                        Insert0Y37( ) ;
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
                        Insert0Y37( ) ;
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
         RowToVars37( bcArquivo, 1) ;
         SaveImpl( ) ;
         VarsToRow37( bcArquivo) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars37( bcArquivo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Y37( ) ;
         AfterTrn( ) ;
         VarsToRow37( bcArquivo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow37( bcArquivo) ;
         }
         else
         {
            SdtArquivo auxBC = new SdtArquivo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A231ArquivoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcArquivo);
               auxBC.Save();
               bcArquivo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars37( bcArquivo, 1) ;
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
         RowToVars37( bcArquivo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Y37( ) ;
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
               VarsToRow37( bcArquivo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow37( bcArquivo) ;
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
         RowToVars37( bcArquivo, 0) ;
         GetKey0Y37( ) ;
         if ( RcdFound37 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A231ArquivoId != Z231ArquivoId )
            {
               A231ArquivoId = Z231ArquivoId;
               n231ArquivoId = false;
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
            if ( A231ArquivoId != Z231ArquivoId )
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
         context.RollbackDataStores("arquivo_bc",pr_default);
         VarsToRow37( bcArquivo) ;
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
         Gx_mode = bcArquivo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcArquivo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcArquivo )
         {
            bcArquivo = (SdtArquivo)(sdt);
            if ( StringUtil.StrCmp(bcArquivo.gxTpr_Mode, "") == 0 )
            {
               bcArquivo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow37( bcArquivo) ;
            }
            else
            {
               RowToVars37( bcArquivo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcArquivo.gxTpr_Mode, "") == 0 )
            {
               bcArquivo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars37( bcArquivo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtArquivo Arquivo_BC
      {
         get {
            return bcArquivo ;
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
         Z232ArquivoBlob = "";
         A232ArquivoBlob = "";
         Z254ArquivoExtensao = "";
         A254ArquivoExtensao = "";
         Z255ArquivoNome = "";
         A255ArquivoNome = "";
         BC000Y4_A231ArquivoId = new int[1] ;
         BC000Y4_n231ArquivoId = new bool[] {false} ;
         BC000Y4_A254ArquivoExtensao = new string[] {""} ;
         BC000Y4_n254ArquivoExtensao = new bool[] {false} ;
         BC000Y4_A255ArquivoNome = new string[] {""} ;
         BC000Y4_n255ArquivoNome = new bool[] {false} ;
         BC000Y4_A232ArquivoBlob = new string[] {""} ;
         BC000Y4_n232ArquivoBlob = new bool[] {false} ;
         A232ArquivoBlob_Filetype = "";
         A232ArquivoBlob_Filename = "";
         BC000Y5_A231ArquivoId = new int[1] ;
         BC000Y5_n231ArquivoId = new bool[] {false} ;
         BC000Y3_A231ArquivoId = new int[1] ;
         BC000Y3_n231ArquivoId = new bool[] {false} ;
         BC000Y3_A254ArquivoExtensao = new string[] {""} ;
         BC000Y3_n254ArquivoExtensao = new bool[] {false} ;
         BC000Y3_A255ArquivoNome = new string[] {""} ;
         BC000Y3_n255ArquivoNome = new bool[] {false} ;
         BC000Y3_A232ArquivoBlob = new string[] {""} ;
         BC000Y3_n232ArquivoBlob = new bool[] {false} ;
         sMode37 = "";
         BC000Y2_A231ArquivoId = new int[1] ;
         BC000Y2_n231ArquivoId = new bool[] {false} ;
         BC000Y2_A254ArquivoExtensao = new string[] {""} ;
         BC000Y2_n254ArquivoExtensao = new bool[] {false} ;
         BC000Y2_A255ArquivoNome = new string[] {""} ;
         BC000Y2_n255ArquivoNome = new bool[] {false} ;
         BC000Y2_A232ArquivoBlob = new string[] {""} ;
         BC000Y2_n232ArquivoBlob = new bool[] {false} ;
         BC000Y7_A231ArquivoId = new int[1] ;
         BC000Y7_n231ArquivoId = new bool[] {false} ;
         BC000Y11_A238AssinaturaId = new long[1] ;
         BC000Y12_A238AssinaturaId = new long[1] ;
         BC000Y13_A231ArquivoId = new int[1] ;
         BC000Y13_n231ArquivoId = new bool[] {false} ;
         BC000Y13_A254ArquivoExtensao = new string[] {""} ;
         BC000Y13_n254ArquivoExtensao = new bool[] {false} ;
         BC000Y13_A255ArquivoNome = new string[] {""} ;
         BC000Y13_n255ArquivoNome = new bool[] {false} ;
         BC000Y13_A232ArquivoBlob = new string[] {""} ;
         BC000Y13_n232ArquivoBlob = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.arquivo_bc__default(),
            new Object[][] {
                new Object[] {
               BC000Y2_A231ArquivoId, BC000Y2_A254ArquivoExtensao, BC000Y2_n254ArquivoExtensao, BC000Y2_A255ArquivoNome, BC000Y2_n255ArquivoNome, BC000Y2_A232ArquivoBlob, BC000Y2_n232ArquivoBlob
               }
               , new Object[] {
               BC000Y3_A231ArquivoId, BC000Y3_A254ArquivoExtensao, BC000Y3_n254ArquivoExtensao, BC000Y3_A255ArquivoNome, BC000Y3_n255ArquivoNome, BC000Y3_A232ArquivoBlob, BC000Y3_n232ArquivoBlob
               }
               , new Object[] {
               BC000Y4_A231ArquivoId, BC000Y4_A254ArquivoExtensao, BC000Y4_n254ArquivoExtensao, BC000Y4_A255ArquivoNome, BC000Y4_n255ArquivoNome, BC000Y4_A232ArquivoBlob, BC000Y4_n232ArquivoBlob
               }
               , new Object[] {
               BC000Y5_A231ArquivoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Y7_A231ArquivoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Y11_A238AssinaturaId
               }
               , new Object[] {
               BC000Y12_A238AssinaturaId
               }
               , new Object[] {
               BC000Y13_A231ArquivoId, BC000Y13_A254ArquivoExtensao, BC000Y13_n254ArquivoExtensao, BC000Y13_A255ArquivoNome, BC000Y13_n255ArquivoNome, BC000Y13_A232ArquivoBlob, BC000Y13_n232ArquivoBlob
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound37 ;
      private int trnEnded ;
      private int Z231ArquivoId ;
      private int A231ArquivoId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A232ArquivoBlob_Filetype ;
      private string A232ArquivoBlob_Filename ;
      private string sMode37 ;
      private bool n231ArquivoId ;
      private bool n254ArquivoExtensao ;
      private bool n255ArquivoNome ;
      private bool n232ArquivoBlob ;
      private string Z254ArquivoExtensao ;
      private string A254ArquivoExtensao ;
      private string Z255ArquivoNome ;
      private string A255ArquivoNome ;
      private string Z232ArquivoBlob ;
      private string A232ArquivoBlob ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000Y4_A231ArquivoId ;
      private bool[] BC000Y4_n231ArquivoId ;
      private string[] BC000Y4_A254ArquivoExtensao ;
      private bool[] BC000Y4_n254ArquivoExtensao ;
      private string[] BC000Y4_A255ArquivoNome ;
      private bool[] BC000Y4_n255ArquivoNome ;
      private string[] BC000Y4_A232ArquivoBlob ;
      private bool[] BC000Y4_n232ArquivoBlob ;
      private int[] BC000Y5_A231ArquivoId ;
      private bool[] BC000Y5_n231ArquivoId ;
      private int[] BC000Y3_A231ArquivoId ;
      private bool[] BC000Y3_n231ArquivoId ;
      private string[] BC000Y3_A254ArquivoExtensao ;
      private bool[] BC000Y3_n254ArquivoExtensao ;
      private string[] BC000Y3_A255ArquivoNome ;
      private bool[] BC000Y3_n255ArquivoNome ;
      private string[] BC000Y3_A232ArquivoBlob ;
      private bool[] BC000Y3_n232ArquivoBlob ;
      private int[] BC000Y2_A231ArquivoId ;
      private bool[] BC000Y2_n231ArquivoId ;
      private string[] BC000Y2_A254ArquivoExtensao ;
      private bool[] BC000Y2_n254ArquivoExtensao ;
      private string[] BC000Y2_A255ArquivoNome ;
      private bool[] BC000Y2_n255ArquivoNome ;
      private string[] BC000Y2_A232ArquivoBlob ;
      private bool[] BC000Y2_n232ArquivoBlob ;
      private int[] BC000Y7_A231ArquivoId ;
      private bool[] BC000Y7_n231ArquivoId ;
      private long[] BC000Y11_A238AssinaturaId ;
      private long[] BC000Y12_A238AssinaturaId ;
      private int[] BC000Y13_A231ArquivoId ;
      private bool[] BC000Y13_n231ArquivoId ;
      private string[] BC000Y13_A254ArquivoExtensao ;
      private bool[] BC000Y13_n254ArquivoExtensao ;
      private string[] BC000Y13_A255ArquivoNome ;
      private bool[] BC000Y13_n255ArquivoNome ;
      private string[] BC000Y13_A232ArquivoBlob ;
      private bool[] BC000Y13_n232ArquivoBlob ;
      private SdtArquivo bcArquivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class arquivo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000Y2;
          prmBC000Y2 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Y3;
          prmBC000Y3 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Y4;
          prmBC000Y4 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Y5;
          prmBC000Y5 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Y6;
          prmBC000Y6 = new Object[] {
          new ParDef("ArquivoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ArquivoExtensao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ArquivoNome",GXType.VarChar,150,0){Nullable=true}
          };
          Object[] prmBC000Y7;
          prmBC000Y7 = new Object[] {
          };
          Object[] prmBC000Y8;
          prmBC000Y8 = new Object[] {
          new ParDef("ArquivoExtensao",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ArquivoNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Y9;
          prmBC000Y9 = new Object[] {
          new ParDef("ArquivoBlob",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Y10;
          prmBC000Y10 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Y11;
          prmBC000Y11 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Y12;
          prmBC000Y12 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Y13;
          prmBC000Y13 = new Object[] {
          new ParDef("ArquivoId",GXType.Int32,8,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC000Y2", "SELECT ArquivoId, ArquivoExtensao, ArquivoNome, ArquivoBlob FROM Arquivo WHERE ArquivoId = :ArquivoId  FOR UPDATE OF Arquivo",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000Y3", "SELECT ArquivoId, ArquivoExtensao, ArquivoNome, ArquivoBlob FROM Arquivo WHERE ArquivoId = :ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000Y4", "SELECT TM1.ArquivoId, TM1.ArquivoExtensao, TM1.ArquivoNome, TM1.ArquivoBlob FROM Arquivo TM1 WHERE TM1.ArquivoId = :ArquivoId ORDER BY TM1.ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000Y5", "SELECT ArquivoId FROM Arquivo WHERE ArquivoId = :ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000Y6", "SAVEPOINT gxupdate;INSERT INTO Arquivo(ArquivoBlob, ArquivoExtensao, ArquivoNome) VALUES(:ArquivoBlob, :ArquivoExtensao, :ArquivoNome);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Y6)
             ,new CursorDef("BC000Y7", "SELECT currval('ArquivoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000Y8", "SAVEPOINT gxupdate;UPDATE Arquivo SET ArquivoExtensao=:ArquivoExtensao, ArquivoNome=:ArquivoNome  WHERE ArquivoId = :ArquivoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Y8)
             ,new CursorDef("BC000Y9", "SAVEPOINT gxupdate;UPDATE Arquivo SET ArquivoBlob=:ArquivoBlob  WHERE ArquivoId = :ArquivoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Y9)
             ,new CursorDef("BC000Y10", "SAVEPOINT gxupdate;DELETE FROM Arquivo  WHERE ArquivoId = :ArquivoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Y10)
             ,new CursorDef("BC000Y11", "SELECT AssinaturaId FROM Assinatura WHERE ArquivoAssinadoId = :ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000Y12", "SELECT AssinaturaId FROM Assinatura WHERE ArquivoId = :ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000Y13", "SELECT TM1.ArquivoId, TM1.ArquivoExtensao, TM1.ArquivoNome, TM1.ArquivoBlob FROM Arquivo TM1 WHERE TM1.ArquivoId = :ArquivoId ORDER BY TM1.ArquivoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Y13,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[5])[0] = rslt.getBLOBFile(4, rslt.getVarchar(2), rslt.getVarchar(3));
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getBLOBFile(4, rslt.getVarchar(2), rslt.getVarchar(3));
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getBLOBFile(4, rslt.getVarchar(2), rslt.getVarchar(3));
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getBLOBFile(4, rslt.getVarchar(2), rslt.getVarchar(3));
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
