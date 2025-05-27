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
   public class assinaturaparticipantetoken_bc : GxSilentTrn, IGxSilentTrn
   {
      public assinaturaparticipantetoken_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assinaturaparticipantetoken_bc( IGxContext context )
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
         ReadRow2476( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2476( ) ;
         standaloneModal( ) ;
         AddRow2476( ) ;
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
               Z554AssinaturaParticipanteTokenId = A554AssinaturaParticipanteTokenId;
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

      protected void CONFIRM_240( )
      {
         BeforeValidate2476( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2476( ) ;
            }
            else
            {
               CheckExtendedTable2476( ) ;
               if ( AnyError == 0 )
               {
                  ZM2476( 3) ;
               }
               CloseExtendedTableCursors2476( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM2476( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z555AssinaturaParticipanteTokenExpire = A555AssinaturaParticipanteTokenExpire;
            Z556AssinaturaParticipanteTokenUsed = A556AssinaturaParticipanteTokenUsed;
            Z557AssinaturaParticipanteTokenContent = A557AssinaturaParticipanteTokenContent;
            Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -2 )
         {
            Z554AssinaturaParticipanteTokenId = A554AssinaturaParticipanteTokenId;
            Z555AssinaturaParticipanteTokenExpire = A555AssinaturaParticipanteTokenExpire;
            Z556AssinaturaParticipanteTokenUsed = A556AssinaturaParticipanteTokenUsed;
            Z557AssinaturaParticipanteTokenContent = A557AssinaturaParticipanteTokenContent;
            Z242AssinaturaParticipanteId = A242AssinaturaParticipanteId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A556AssinaturaParticipanteTokenUsed) && ( Gx_BScreen == 0 ) )
         {
            A556AssinaturaParticipanteTokenUsed = false;
            n556AssinaturaParticipanteTokenUsed = false;
         }
      }

      protected void Load2476( )
      {
         /* Using cursor BC00245 */
         pr_default.execute(3, new Object[] {A554AssinaturaParticipanteTokenId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound76 = 1;
            A555AssinaturaParticipanteTokenExpire = BC00245_A555AssinaturaParticipanteTokenExpire[0];
            n555AssinaturaParticipanteTokenExpire = BC00245_n555AssinaturaParticipanteTokenExpire[0];
            A556AssinaturaParticipanteTokenUsed = BC00245_A556AssinaturaParticipanteTokenUsed[0];
            n556AssinaturaParticipanteTokenUsed = BC00245_n556AssinaturaParticipanteTokenUsed[0];
            A557AssinaturaParticipanteTokenContent = BC00245_A557AssinaturaParticipanteTokenContent[0];
            n557AssinaturaParticipanteTokenContent = BC00245_n557AssinaturaParticipanteTokenContent[0];
            A242AssinaturaParticipanteId = BC00245_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = BC00245_n242AssinaturaParticipanteId[0];
            ZM2476( -2) ;
         }
         pr_default.close(3);
         OnLoadActions2476( ) ;
      }

      protected void OnLoadActions2476( )
      {
      }

      protected void CheckExtendedTable2476( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00244 */
         pr_default.execute(2, new Object[] {n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A242AssinaturaParticipanteId) ) )
            {
               GX_msglist.addItem("Não existe 'AssinaturaParticipante'.", "ForeignKeyNotFound", 1, "ASSINATURAPARTICIPANTEID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors2476( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2476( )
      {
         /* Using cursor BC00246 */
         pr_default.execute(4, new Object[] {A554AssinaturaParticipanteTokenId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound76 = 1;
         }
         else
         {
            RcdFound76 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00243 */
         pr_default.execute(1, new Object[] {A554AssinaturaParticipanteTokenId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2476( 2) ;
            RcdFound76 = 1;
            A554AssinaturaParticipanteTokenId = BC00243_A554AssinaturaParticipanteTokenId[0];
            A555AssinaturaParticipanteTokenExpire = BC00243_A555AssinaturaParticipanteTokenExpire[0];
            n555AssinaturaParticipanteTokenExpire = BC00243_n555AssinaturaParticipanteTokenExpire[0];
            A556AssinaturaParticipanteTokenUsed = BC00243_A556AssinaturaParticipanteTokenUsed[0];
            n556AssinaturaParticipanteTokenUsed = BC00243_n556AssinaturaParticipanteTokenUsed[0];
            A557AssinaturaParticipanteTokenContent = BC00243_A557AssinaturaParticipanteTokenContent[0];
            n557AssinaturaParticipanteTokenContent = BC00243_n557AssinaturaParticipanteTokenContent[0];
            A242AssinaturaParticipanteId = BC00243_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = BC00243_n242AssinaturaParticipanteId[0];
            Z554AssinaturaParticipanteTokenId = A554AssinaturaParticipanteTokenId;
            sMode76 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2476( ) ;
            if ( AnyError == 1 )
            {
               RcdFound76 = 0;
               InitializeNonKey2476( ) ;
            }
            Gx_mode = sMode76;
         }
         else
         {
            RcdFound76 = 0;
            InitializeNonKey2476( ) ;
            sMode76 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode76;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2476( ) ;
         if ( RcdFound76 == 0 )
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
         CONFIRM_240( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2476( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00242 */
            pr_default.execute(0, new Object[] {A554AssinaturaParticipanteTokenId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AssinaturaParticipanteToken"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z555AssinaturaParticipanteTokenExpire != BC00242_A555AssinaturaParticipanteTokenExpire[0] ) || ( Z556AssinaturaParticipanteTokenUsed != BC00242_A556AssinaturaParticipanteTokenUsed[0] ) || ( StringUtil.StrCmp(Z557AssinaturaParticipanteTokenContent, BC00242_A557AssinaturaParticipanteTokenContent[0]) != 0 ) || ( Z242AssinaturaParticipanteId != BC00242_A242AssinaturaParticipanteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AssinaturaParticipanteToken"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2476( )
      {
         BeforeValidate2476( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2476( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2476( 0) ;
            CheckOptimisticConcurrency2476( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2476( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2476( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00247 */
                     pr_default.execute(5, new Object[] {n555AssinaturaParticipanteTokenExpire, A555AssinaturaParticipanteTokenExpire, n556AssinaturaParticipanteTokenUsed, A556AssinaturaParticipanteTokenUsed, n557AssinaturaParticipanteTokenContent, A557AssinaturaParticipanteTokenContent, n242AssinaturaParticipanteId, A242AssinaturaParticipanteId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00248 */
                     pr_default.execute(6);
                     A554AssinaturaParticipanteTokenId = BC00248_A554AssinaturaParticipanteTokenId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipanteToken");
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
               Load2476( ) ;
            }
            EndLevel2476( ) ;
         }
         CloseExtendedTableCursors2476( ) ;
      }

      protected void Update2476( )
      {
         BeforeValidate2476( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2476( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2476( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2476( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2476( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00249 */
                     pr_default.execute(7, new Object[] {n555AssinaturaParticipanteTokenExpire, A555AssinaturaParticipanteTokenExpire, n556AssinaturaParticipanteTokenUsed, A556AssinaturaParticipanteTokenUsed, n557AssinaturaParticipanteTokenContent, A557AssinaturaParticipanteTokenContent, n242AssinaturaParticipanteId, A242AssinaturaParticipanteId, A554AssinaturaParticipanteTokenId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipanteToken");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AssinaturaParticipanteToken"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2476( ) ;
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
            EndLevel2476( ) ;
         }
         CloseExtendedTableCursors2476( ) ;
      }

      protected void DeferredUpdate2476( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2476( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2476( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2476( ) ;
            AfterConfirm2476( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2476( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002410 */
                  pr_default.execute(8, new Object[] {A554AssinaturaParticipanteTokenId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("AssinaturaParticipanteToken");
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
         sMode76 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2476( ) ;
         Gx_mode = sMode76;
      }

      protected void OnDeleteControls2476( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2476( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2476( ) ;
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

      public void ScanKeyStart2476( )
      {
         /* Using cursor BC002411 */
         pr_default.execute(9, new Object[] {A554AssinaturaParticipanteTokenId});
         RcdFound76 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound76 = 1;
            A554AssinaturaParticipanteTokenId = BC002411_A554AssinaturaParticipanteTokenId[0];
            A555AssinaturaParticipanteTokenExpire = BC002411_A555AssinaturaParticipanteTokenExpire[0];
            n555AssinaturaParticipanteTokenExpire = BC002411_n555AssinaturaParticipanteTokenExpire[0];
            A556AssinaturaParticipanteTokenUsed = BC002411_A556AssinaturaParticipanteTokenUsed[0];
            n556AssinaturaParticipanteTokenUsed = BC002411_n556AssinaturaParticipanteTokenUsed[0];
            A557AssinaturaParticipanteTokenContent = BC002411_A557AssinaturaParticipanteTokenContent[0];
            n557AssinaturaParticipanteTokenContent = BC002411_n557AssinaturaParticipanteTokenContent[0];
            A242AssinaturaParticipanteId = BC002411_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = BC002411_n242AssinaturaParticipanteId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2476( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound76 = 0;
         ScanKeyLoad2476( ) ;
      }

      protected void ScanKeyLoad2476( )
      {
         sMode76 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound76 = 1;
            A554AssinaturaParticipanteTokenId = BC002411_A554AssinaturaParticipanteTokenId[0];
            A555AssinaturaParticipanteTokenExpire = BC002411_A555AssinaturaParticipanteTokenExpire[0];
            n555AssinaturaParticipanteTokenExpire = BC002411_n555AssinaturaParticipanteTokenExpire[0];
            A556AssinaturaParticipanteTokenUsed = BC002411_A556AssinaturaParticipanteTokenUsed[0];
            n556AssinaturaParticipanteTokenUsed = BC002411_n556AssinaturaParticipanteTokenUsed[0];
            A557AssinaturaParticipanteTokenContent = BC002411_A557AssinaturaParticipanteTokenContent[0];
            n557AssinaturaParticipanteTokenContent = BC002411_n557AssinaturaParticipanteTokenContent[0];
            A242AssinaturaParticipanteId = BC002411_A242AssinaturaParticipanteId[0];
            n242AssinaturaParticipanteId = BC002411_n242AssinaturaParticipanteId[0];
         }
         Gx_mode = sMode76;
      }

      protected void ScanKeyEnd2476( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm2476( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2476( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2476( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2476( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2476( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2476( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2476( )
      {
      }

      protected void send_integrity_lvl_hashes2476( )
      {
      }

      protected void AddRow2476( )
      {
         VarsToRow76( bcAssinaturaParticipanteToken) ;
      }

      protected void ReadRow2476( )
      {
         RowToVars76( bcAssinaturaParticipanteToken, 1) ;
      }

      protected void InitializeNonKey2476( )
      {
         A242AssinaturaParticipanteId = 0;
         n242AssinaturaParticipanteId = false;
         A555AssinaturaParticipanteTokenExpire = (DateTime)(DateTime.MinValue);
         n555AssinaturaParticipanteTokenExpire = false;
         A557AssinaturaParticipanteTokenContent = "";
         n557AssinaturaParticipanteTokenContent = false;
         A556AssinaturaParticipanteTokenUsed = false;
         n556AssinaturaParticipanteTokenUsed = false;
         Z555AssinaturaParticipanteTokenExpire = (DateTime)(DateTime.MinValue);
         Z556AssinaturaParticipanteTokenUsed = false;
         Z557AssinaturaParticipanteTokenContent = "";
         Z242AssinaturaParticipanteId = 0;
      }

      protected void InitAll2476( )
      {
         A554AssinaturaParticipanteTokenId = 0;
         InitializeNonKey2476( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A556AssinaturaParticipanteTokenUsed = i556AssinaturaParticipanteTokenUsed;
         n556AssinaturaParticipanteTokenUsed = false;
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

      public void VarsToRow76( SdtAssinaturaParticipanteToken obj76 )
      {
         obj76.gxTpr_Mode = Gx_mode;
         obj76.gxTpr_Assinaturaparticipanteid = A242AssinaturaParticipanteId;
         obj76.gxTpr_Assinaturaparticipantetokenexpire = A555AssinaturaParticipanteTokenExpire;
         obj76.gxTpr_Assinaturaparticipantetokencontent = A557AssinaturaParticipanteTokenContent;
         obj76.gxTpr_Assinaturaparticipantetokenused = A556AssinaturaParticipanteTokenUsed;
         obj76.gxTpr_Assinaturaparticipantetokenid = A554AssinaturaParticipanteTokenId;
         obj76.gxTpr_Assinaturaparticipantetokenid_Z = Z554AssinaturaParticipanteTokenId;
         obj76.gxTpr_Assinaturaparticipanteid_Z = Z242AssinaturaParticipanteId;
         obj76.gxTpr_Assinaturaparticipantetokenexpire_Z = Z555AssinaturaParticipanteTokenExpire;
         obj76.gxTpr_Assinaturaparticipantetokenused_Z = Z556AssinaturaParticipanteTokenUsed;
         obj76.gxTpr_Assinaturaparticipantetokencontent_Z = Z557AssinaturaParticipanteTokenContent;
         obj76.gxTpr_Assinaturaparticipanteid_N = (short)(Convert.ToInt16(n242AssinaturaParticipanteId));
         obj76.gxTpr_Assinaturaparticipantetokenexpire_N = (short)(Convert.ToInt16(n555AssinaturaParticipanteTokenExpire));
         obj76.gxTpr_Assinaturaparticipantetokenused_N = (short)(Convert.ToInt16(n556AssinaturaParticipanteTokenUsed));
         obj76.gxTpr_Assinaturaparticipantetokencontent_N = (short)(Convert.ToInt16(n557AssinaturaParticipanteTokenContent));
         obj76.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow76( SdtAssinaturaParticipanteToken obj76 )
      {
         obj76.gxTpr_Assinaturaparticipantetokenid = A554AssinaturaParticipanteTokenId;
         return  ;
      }

      public void RowToVars76( SdtAssinaturaParticipanteToken obj76 ,
                               int forceLoad )
      {
         Gx_mode = obj76.gxTpr_Mode;
         A242AssinaturaParticipanteId = obj76.gxTpr_Assinaturaparticipanteid;
         n242AssinaturaParticipanteId = false;
         A555AssinaturaParticipanteTokenExpire = obj76.gxTpr_Assinaturaparticipantetokenexpire;
         n555AssinaturaParticipanteTokenExpire = false;
         A557AssinaturaParticipanteTokenContent = obj76.gxTpr_Assinaturaparticipantetokencontent;
         n557AssinaturaParticipanteTokenContent = false;
         A556AssinaturaParticipanteTokenUsed = obj76.gxTpr_Assinaturaparticipantetokenused;
         n556AssinaturaParticipanteTokenUsed = false;
         A554AssinaturaParticipanteTokenId = obj76.gxTpr_Assinaturaparticipantetokenid;
         Z554AssinaturaParticipanteTokenId = obj76.gxTpr_Assinaturaparticipantetokenid_Z;
         Z242AssinaturaParticipanteId = obj76.gxTpr_Assinaturaparticipanteid_Z;
         Z555AssinaturaParticipanteTokenExpire = obj76.gxTpr_Assinaturaparticipantetokenexpire_Z;
         Z556AssinaturaParticipanteTokenUsed = obj76.gxTpr_Assinaturaparticipantetokenused_Z;
         Z557AssinaturaParticipanteTokenContent = obj76.gxTpr_Assinaturaparticipantetokencontent_Z;
         n242AssinaturaParticipanteId = (bool)(Convert.ToBoolean(obj76.gxTpr_Assinaturaparticipanteid_N));
         n555AssinaturaParticipanteTokenExpire = (bool)(Convert.ToBoolean(obj76.gxTpr_Assinaturaparticipantetokenexpire_N));
         n556AssinaturaParticipanteTokenUsed = (bool)(Convert.ToBoolean(obj76.gxTpr_Assinaturaparticipantetokenused_N));
         n557AssinaturaParticipanteTokenContent = (bool)(Convert.ToBoolean(obj76.gxTpr_Assinaturaparticipantetokencontent_N));
         Gx_mode = obj76.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A554AssinaturaParticipanteTokenId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2476( ) ;
         ScanKeyStart2476( ) ;
         if ( RcdFound76 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z554AssinaturaParticipanteTokenId = A554AssinaturaParticipanteTokenId;
         }
         ZM2476( -2) ;
         OnLoadActions2476( ) ;
         AddRow2476( ) ;
         ScanKeyEnd2476( ) ;
         if ( RcdFound76 == 0 )
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
         RowToVars76( bcAssinaturaParticipanteToken, 0) ;
         ScanKeyStart2476( ) ;
         if ( RcdFound76 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z554AssinaturaParticipanteTokenId = A554AssinaturaParticipanteTokenId;
         }
         ZM2476( -2) ;
         OnLoadActions2476( ) ;
         AddRow2476( ) ;
         ScanKeyEnd2476( ) ;
         if ( RcdFound76 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2476( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2476( ) ;
         }
         else
         {
            if ( RcdFound76 == 1 )
            {
               if ( A554AssinaturaParticipanteTokenId != Z554AssinaturaParticipanteTokenId )
               {
                  A554AssinaturaParticipanteTokenId = Z554AssinaturaParticipanteTokenId;
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
                  Update2476( ) ;
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
                  if ( A554AssinaturaParticipanteTokenId != Z554AssinaturaParticipanteTokenId )
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
                        Insert2476( ) ;
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
                        Insert2476( ) ;
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
         RowToVars76( bcAssinaturaParticipanteToken, 1) ;
         SaveImpl( ) ;
         VarsToRow76( bcAssinaturaParticipanteToken) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars76( bcAssinaturaParticipanteToken, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2476( ) ;
         AfterTrn( ) ;
         VarsToRow76( bcAssinaturaParticipanteToken) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow76( bcAssinaturaParticipanteToken) ;
         }
         else
         {
            SdtAssinaturaParticipanteToken auxBC = new SdtAssinaturaParticipanteToken(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A554AssinaturaParticipanteTokenId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcAssinaturaParticipanteToken);
               auxBC.Save();
               bcAssinaturaParticipanteToken.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars76( bcAssinaturaParticipanteToken, 1) ;
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
         RowToVars76( bcAssinaturaParticipanteToken, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2476( ) ;
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
               VarsToRow76( bcAssinaturaParticipanteToken) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow76( bcAssinaturaParticipanteToken) ;
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
         RowToVars76( bcAssinaturaParticipanteToken, 0) ;
         GetKey2476( ) ;
         if ( RcdFound76 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A554AssinaturaParticipanteTokenId != Z554AssinaturaParticipanteTokenId )
            {
               A554AssinaturaParticipanteTokenId = Z554AssinaturaParticipanteTokenId;
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
            if ( A554AssinaturaParticipanteTokenId != Z554AssinaturaParticipanteTokenId )
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
         context.RollbackDataStores("assinaturaparticipantetoken_bc",pr_default);
         VarsToRow76( bcAssinaturaParticipanteToken) ;
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
         Gx_mode = bcAssinaturaParticipanteToken.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcAssinaturaParticipanteToken.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcAssinaturaParticipanteToken )
         {
            bcAssinaturaParticipanteToken = (SdtAssinaturaParticipanteToken)(sdt);
            if ( StringUtil.StrCmp(bcAssinaturaParticipanteToken.gxTpr_Mode, "") == 0 )
            {
               bcAssinaturaParticipanteToken.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow76( bcAssinaturaParticipanteToken) ;
            }
            else
            {
               RowToVars76( bcAssinaturaParticipanteToken, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcAssinaturaParticipanteToken.gxTpr_Mode, "") == 0 )
            {
               bcAssinaturaParticipanteToken.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars76( bcAssinaturaParticipanteToken, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtAssinaturaParticipanteToken AssinaturaParticipanteToken_BC
      {
         get {
            return bcAssinaturaParticipanteToken ;
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
         Z555AssinaturaParticipanteTokenExpire = (DateTime)(DateTime.MinValue);
         A555AssinaturaParticipanteTokenExpire = (DateTime)(DateTime.MinValue);
         Z557AssinaturaParticipanteTokenContent = "";
         A557AssinaturaParticipanteTokenContent = "";
         BC00245_A554AssinaturaParticipanteTokenId = new int[1] ;
         BC00245_A555AssinaturaParticipanteTokenExpire = new DateTime[] {DateTime.MinValue} ;
         BC00245_n555AssinaturaParticipanteTokenExpire = new bool[] {false} ;
         BC00245_A556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         BC00245_n556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         BC00245_A557AssinaturaParticipanteTokenContent = new string[] {""} ;
         BC00245_n557AssinaturaParticipanteTokenContent = new bool[] {false} ;
         BC00245_A242AssinaturaParticipanteId = new int[1] ;
         BC00245_n242AssinaturaParticipanteId = new bool[] {false} ;
         BC00244_A242AssinaturaParticipanteId = new int[1] ;
         BC00244_n242AssinaturaParticipanteId = new bool[] {false} ;
         BC00246_A554AssinaturaParticipanteTokenId = new int[1] ;
         BC00243_A554AssinaturaParticipanteTokenId = new int[1] ;
         BC00243_A555AssinaturaParticipanteTokenExpire = new DateTime[] {DateTime.MinValue} ;
         BC00243_n555AssinaturaParticipanteTokenExpire = new bool[] {false} ;
         BC00243_A556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         BC00243_n556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         BC00243_A557AssinaturaParticipanteTokenContent = new string[] {""} ;
         BC00243_n557AssinaturaParticipanteTokenContent = new bool[] {false} ;
         BC00243_A242AssinaturaParticipanteId = new int[1] ;
         BC00243_n242AssinaturaParticipanteId = new bool[] {false} ;
         sMode76 = "";
         BC00242_A554AssinaturaParticipanteTokenId = new int[1] ;
         BC00242_A555AssinaturaParticipanteTokenExpire = new DateTime[] {DateTime.MinValue} ;
         BC00242_n555AssinaturaParticipanteTokenExpire = new bool[] {false} ;
         BC00242_A556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         BC00242_n556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         BC00242_A557AssinaturaParticipanteTokenContent = new string[] {""} ;
         BC00242_n557AssinaturaParticipanteTokenContent = new bool[] {false} ;
         BC00242_A242AssinaturaParticipanteId = new int[1] ;
         BC00242_n242AssinaturaParticipanteId = new bool[] {false} ;
         BC00248_A554AssinaturaParticipanteTokenId = new int[1] ;
         BC002411_A554AssinaturaParticipanteTokenId = new int[1] ;
         BC002411_A555AssinaturaParticipanteTokenExpire = new DateTime[] {DateTime.MinValue} ;
         BC002411_n555AssinaturaParticipanteTokenExpire = new bool[] {false} ;
         BC002411_A556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         BC002411_n556AssinaturaParticipanteTokenUsed = new bool[] {false} ;
         BC002411_A557AssinaturaParticipanteTokenContent = new string[] {""} ;
         BC002411_n557AssinaturaParticipanteTokenContent = new bool[] {false} ;
         BC002411_A242AssinaturaParticipanteId = new int[1] ;
         BC002411_n242AssinaturaParticipanteId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinaturaparticipantetoken_bc__default(),
            new Object[][] {
                new Object[] {
               BC00242_A554AssinaturaParticipanteTokenId, BC00242_A555AssinaturaParticipanteTokenExpire, BC00242_n555AssinaturaParticipanteTokenExpire, BC00242_A556AssinaturaParticipanteTokenUsed, BC00242_n556AssinaturaParticipanteTokenUsed, BC00242_A557AssinaturaParticipanteTokenContent, BC00242_n557AssinaturaParticipanteTokenContent, BC00242_A242AssinaturaParticipanteId, BC00242_n242AssinaturaParticipanteId
               }
               , new Object[] {
               BC00243_A554AssinaturaParticipanteTokenId, BC00243_A555AssinaturaParticipanteTokenExpire, BC00243_n555AssinaturaParticipanteTokenExpire, BC00243_A556AssinaturaParticipanteTokenUsed, BC00243_n556AssinaturaParticipanteTokenUsed, BC00243_A557AssinaturaParticipanteTokenContent, BC00243_n557AssinaturaParticipanteTokenContent, BC00243_A242AssinaturaParticipanteId, BC00243_n242AssinaturaParticipanteId
               }
               , new Object[] {
               BC00244_A242AssinaturaParticipanteId
               }
               , new Object[] {
               BC00245_A554AssinaturaParticipanteTokenId, BC00245_A555AssinaturaParticipanteTokenExpire, BC00245_n555AssinaturaParticipanteTokenExpire, BC00245_A556AssinaturaParticipanteTokenUsed, BC00245_n556AssinaturaParticipanteTokenUsed, BC00245_A557AssinaturaParticipanteTokenContent, BC00245_n557AssinaturaParticipanteTokenContent, BC00245_A242AssinaturaParticipanteId, BC00245_n242AssinaturaParticipanteId
               }
               , new Object[] {
               BC00246_A554AssinaturaParticipanteTokenId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00248_A554AssinaturaParticipanteTokenId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002411_A554AssinaturaParticipanteTokenId, BC002411_A555AssinaturaParticipanteTokenExpire, BC002411_n555AssinaturaParticipanteTokenExpire, BC002411_A556AssinaturaParticipanteTokenUsed, BC002411_n556AssinaturaParticipanteTokenUsed, BC002411_A557AssinaturaParticipanteTokenContent, BC002411_n557AssinaturaParticipanteTokenContent, BC002411_A242AssinaturaParticipanteId, BC002411_n242AssinaturaParticipanteId
               }
            }
         );
         Z556AssinaturaParticipanteTokenUsed = false;
         n556AssinaturaParticipanteTokenUsed = false;
         A556AssinaturaParticipanteTokenUsed = false;
         n556AssinaturaParticipanteTokenUsed = false;
         i556AssinaturaParticipanteTokenUsed = false;
         n556AssinaturaParticipanteTokenUsed = false;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound76 ;
      private int trnEnded ;
      private int Z554AssinaturaParticipanteTokenId ;
      private int A554AssinaturaParticipanteTokenId ;
      private int Z242AssinaturaParticipanteId ;
      private int A242AssinaturaParticipanteId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode76 ;
      private DateTime Z555AssinaturaParticipanteTokenExpire ;
      private DateTime A555AssinaturaParticipanteTokenExpire ;
      private bool Z556AssinaturaParticipanteTokenUsed ;
      private bool A556AssinaturaParticipanteTokenUsed ;
      private bool n556AssinaturaParticipanteTokenUsed ;
      private bool n555AssinaturaParticipanteTokenExpire ;
      private bool n557AssinaturaParticipanteTokenContent ;
      private bool n242AssinaturaParticipanteId ;
      private bool i556AssinaturaParticipanteTokenUsed ;
      private string Z557AssinaturaParticipanteTokenContent ;
      private string A557AssinaturaParticipanteTokenContent ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00245_A554AssinaturaParticipanteTokenId ;
      private DateTime[] BC00245_A555AssinaturaParticipanteTokenExpire ;
      private bool[] BC00245_n555AssinaturaParticipanteTokenExpire ;
      private bool[] BC00245_A556AssinaturaParticipanteTokenUsed ;
      private bool[] BC00245_n556AssinaturaParticipanteTokenUsed ;
      private string[] BC00245_A557AssinaturaParticipanteTokenContent ;
      private bool[] BC00245_n557AssinaturaParticipanteTokenContent ;
      private int[] BC00245_A242AssinaturaParticipanteId ;
      private bool[] BC00245_n242AssinaturaParticipanteId ;
      private int[] BC00244_A242AssinaturaParticipanteId ;
      private bool[] BC00244_n242AssinaturaParticipanteId ;
      private int[] BC00246_A554AssinaturaParticipanteTokenId ;
      private int[] BC00243_A554AssinaturaParticipanteTokenId ;
      private DateTime[] BC00243_A555AssinaturaParticipanteTokenExpire ;
      private bool[] BC00243_n555AssinaturaParticipanteTokenExpire ;
      private bool[] BC00243_A556AssinaturaParticipanteTokenUsed ;
      private bool[] BC00243_n556AssinaturaParticipanteTokenUsed ;
      private string[] BC00243_A557AssinaturaParticipanteTokenContent ;
      private bool[] BC00243_n557AssinaturaParticipanteTokenContent ;
      private int[] BC00243_A242AssinaturaParticipanteId ;
      private bool[] BC00243_n242AssinaturaParticipanteId ;
      private int[] BC00242_A554AssinaturaParticipanteTokenId ;
      private DateTime[] BC00242_A555AssinaturaParticipanteTokenExpire ;
      private bool[] BC00242_n555AssinaturaParticipanteTokenExpire ;
      private bool[] BC00242_A556AssinaturaParticipanteTokenUsed ;
      private bool[] BC00242_n556AssinaturaParticipanteTokenUsed ;
      private string[] BC00242_A557AssinaturaParticipanteTokenContent ;
      private bool[] BC00242_n557AssinaturaParticipanteTokenContent ;
      private int[] BC00242_A242AssinaturaParticipanteId ;
      private bool[] BC00242_n242AssinaturaParticipanteId ;
      private int[] BC00248_A554AssinaturaParticipanteTokenId ;
      private int[] BC002411_A554AssinaturaParticipanteTokenId ;
      private DateTime[] BC002411_A555AssinaturaParticipanteTokenExpire ;
      private bool[] BC002411_n555AssinaturaParticipanteTokenExpire ;
      private bool[] BC002411_A556AssinaturaParticipanteTokenUsed ;
      private bool[] BC002411_n556AssinaturaParticipanteTokenUsed ;
      private string[] BC002411_A557AssinaturaParticipanteTokenContent ;
      private bool[] BC002411_n557AssinaturaParticipanteTokenContent ;
      private int[] BC002411_A242AssinaturaParticipanteId ;
      private bool[] BC002411_n242AssinaturaParticipanteId ;
      private SdtAssinaturaParticipanteToken bcAssinaturaParticipanteToken ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class assinaturaparticipantetoken_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC00242;
          prmBC00242 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmBC00243;
          prmBC00243 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmBC00244;
          prmBC00244 = new Object[] {
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00245;
          prmBC00245 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmBC00246;
          prmBC00246 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmBC00247;
          prmBC00247 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenExpire",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTokenUsed",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTokenContent",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00248;
          prmBC00248 = new Object[] {
          };
          Object[] prmBC00249;
          prmBC00249 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenExpire",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTokenUsed",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTokenContent",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmBC002410;
          prmBC002410 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          Object[] prmBC002411;
          prmBC002411 = new Object[] {
          new ParDef("AssinaturaParticipanteTokenId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00242", "SELECT AssinaturaParticipanteTokenId, AssinaturaParticipanteTokenExpire, AssinaturaParticipanteTokenUsed, AssinaturaParticipanteTokenContent, AssinaturaParticipanteId FROM AssinaturaParticipanteToken WHERE AssinaturaParticipanteTokenId = :AssinaturaParticipanteTokenId  FOR UPDATE OF AssinaturaParticipanteToken",true, GxErrorMask.GX_NOMASK, false, this,prmBC00242,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00243", "SELECT AssinaturaParticipanteTokenId, AssinaturaParticipanteTokenExpire, AssinaturaParticipanteTokenUsed, AssinaturaParticipanteTokenContent, AssinaturaParticipanteId FROM AssinaturaParticipanteToken WHERE AssinaturaParticipanteTokenId = :AssinaturaParticipanteTokenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00243,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00244", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE AssinaturaParticipanteId = :AssinaturaParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00244,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00245", "SELECT TM1.AssinaturaParticipanteTokenId, TM1.AssinaturaParticipanteTokenExpire, TM1.AssinaturaParticipanteTokenUsed, TM1.AssinaturaParticipanteTokenContent, TM1.AssinaturaParticipanteId FROM AssinaturaParticipanteToken TM1 WHERE TM1.AssinaturaParticipanteTokenId = :AssinaturaParticipanteTokenId ORDER BY TM1.AssinaturaParticipanteTokenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00245,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00246", "SELECT AssinaturaParticipanteTokenId FROM AssinaturaParticipanteToken WHERE AssinaturaParticipanteTokenId = :AssinaturaParticipanteTokenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00246,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00247", "SAVEPOINT gxupdate;INSERT INTO AssinaturaParticipanteToken(AssinaturaParticipanteTokenExpire, AssinaturaParticipanteTokenUsed, AssinaturaParticipanteTokenContent, AssinaturaParticipanteId) VALUES(:AssinaturaParticipanteTokenExpire, :AssinaturaParticipanteTokenUsed, :AssinaturaParticipanteTokenContent, :AssinaturaParticipanteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00247)
             ,new CursorDef("BC00248", "SELECT currval('AssinaturaParticipanteTokenId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00248,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00249", "SAVEPOINT gxupdate;UPDATE AssinaturaParticipanteToken SET AssinaturaParticipanteTokenExpire=:AssinaturaParticipanteTokenExpire, AssinaturaParticipanteTokenUsed=:AssinaturaParticipanteTokenUsed, AssinaturaParticipanteTokenContent=:AssinaturaParticipanteTokenContent, AssinaturaParticipanteId=:AssinaturaParticipanteId  WHERE AssinaturaParticipanteTokenId = :AssinaturaParticipanteTokenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00249)
             ,new CursorDef("BC002410", "SAVEPOINT gxupdate;DELETE FROM AssinaturaParticipanteToken  WHERE AssinaturaParticipanteTokenId = :AssinaturaParticipanteTokenId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002410)
             ,new CursorDef("BC002411", "SELECT TM1.AssinaturaParticipanteTokenId, TM1.AssinaturaParticipanteTokenExpire, TM1.AssinaturaParticipanteTokenUsed, TM1.AssinaturaParticipanteTokenContent, TM1.AssinaturaParticipanteId FROM AssinaturaParticipanteToken TM1 WHERE TM1.AssinaturaParticipanteTokenId = :AssinaturaParticipanteTokenId ORDER BY TM1.AssinaturaParticipanteTokenId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002411,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

}
