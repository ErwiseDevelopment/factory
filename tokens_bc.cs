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
   public class tokens_bc : GxSilentTrn, IGxSilentTrn
   {
      public tokens_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tokens_bc( IGxContext context )
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
         ReadRow35109( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey35109( ) ;
         standaloneModal( ) ;
         AddRow35109( ) ;
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
               Z1050TokensId = A1050TokensId;
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

      protected void CONFIRM_350( )
      {
         BeforeValidate35109( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls35109( ) ;
            }
            else
            {
               CheckExtendedTable35109( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors35109( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM35109( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z1052TokensExpire = A1052TokensExpire;
            Z1053TokensType = A1053TokensType;
            Z1058TokensDateTime = A1058TokensDateTime;
         }
         if ( GX_JID == -2 )
         {
            Z1050TokensId = A1050TokensId;
            Z1051TokensContent = A1051TokensContent;
            Z1052TokensExpire = A1052TokensExpire;
            Z1053TokensType = A1053TokensType;
            Z1058TokensDateTime = A1058TokensDateTime;
            Z1057TokensSalt = A1057TokensSalt;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load35109( )
      {
         /* Using cursor BC00354 */
         pr_default.execute(2, new Object[] {A1050TokensId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound109 = 1;
            A1051TokensContent = BC00354_A1051TokensContent[0];
            n1051TokensContent = BC00354_n1051TokensContent[0];
            A1052TokensExpire = BC00354_A1052TokensExpire[0];
            n1052TokensExpire = BC00354_n1052TokensExpire[0];
            A1053TokensType = BC00354_A1053TokensType[0];
            n1053TokensType = BC00354_n1053TokensType[0];
            A1058TokensDateTime = BC00354_A1058TokensDateTime[0];
            n1058TokensDateTime = BC00354_n1058TokensDateTime[0];
            A1057TokensSalt = BC00354_A1057TokensSalt[0];
            n1057TokensSalt = BC00354_n1057TokensSalt[0];
            ZM35109( -2) ;
         }
         pr_default.close(2);
         OnLoadActions35109( ) ;
      }

      protected void OnLoadActions35109( )
      {
      }

      protected void CheckExtendedTable35109( )
      {
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A1053TokensType, "9cf42625-e388-45f6-aae5-e7c2b7ddcffc") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1053TokensType)) ) )
         {
            GX_msglist.addItem("Campo Type token fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors35109( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey35109( )
      {
         /* Using cursor BC00355 */
         pr_default.execute(3, new Object[] {A1050TokensId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound109 = 1;
         }
         else
         {
            RcdFound109 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00353 */
         pr_default.execute(1, new Object[] {A1050TokensId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM35109( 2) ;
            RcdFound109 = 1;
            A1050TokensId = BC00353_A1050TokensId[0];
            A1051TokensContent = BC00353_A1051TokensContent[0];
            n1051TokensContent = BC00353_n1051TokensContent[0];
            A1052TokensExpire = BC00353_A1052TokensExpire[0];
            n1052TokensExpire = BC00353_n1052TokensExpire[0];
            A1053TokensType = BC00353_A1053TokensType[0];
            n1053TokensType = BC00353_n1053TokensType[0];
            A1058TokensDateTime = BC00353_A1058TokensDateTime[0];
            n1058TokensDateTime = BC00353_n1058TokensDateTime[0];
            A1057TokensSalt = BC00353_A1057TokensSalt[0];
            n1057TokensSalt = BC00353_n1057TokensSalt[0];
            Z1050TokensId = A1050TokensId;
            sMode109 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load35109( ) ;
            if ( AnyError == 1 )
            {
               RcdFound109 = 0;
               InitializeNonKey35109( ) ;
            }
            Gx_mode = sMode109;
         }
         else
         {
            RcdFound109 = 0;
            InitializeNonKey35109( ) ;
            sMode109 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode109;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey35109( ) ;
         if ( RcdFound109 == 0 )
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
         CONFIRM_350( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency35109( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00352 */
            pr_default.execute(0, new Object[] {A1050TokensId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tokens"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1052TokensExpire != BC00352_A1052TokensExpire[0] ) || ( StringUtil.StrCmp(Z1053TokensType, BC00352_A1053TokensType[0]) != 0 ) || ( Z1058TokensDateTime != BC00352_A1058TokensDateTime[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Tokens"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert35109( )
      {
         BeforeValidate35109( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable35109( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM35109( 0) ;
            CheckOptimisticConcurrency35109( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm35109( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert35109( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00356 */
                     pr_default.execute(4, new Object[] {n1051TokensContent, A1051TokensContent, n1052TokensExpire, A1052TokensExpire, n1053TokensType, A1053TokensType, n1058TokensDateTime, A1058TokensDateTime, n1057TokensSalt, A1057TokensSalt});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00357 */
                     pr_default.execute(5);
                     A1050TokensId = BC00357_A1050TokensId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Tokens");
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
               Load35109( ) ;
            }
            EndLevel35109( ) ;
         }
         CloseExtendedTableCursors35109( ) ;
      }

      protected void Update35109( )
      {
         BeforeValidate35109( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable35109( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency35109( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm35109( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate35109( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00358 */
                     pr_default.execute(6, new Object[] {n1051TokensContent, A1051TokensContent, n1052TokensExpire, A1052TokensExpire, n1053TokensType, A1053TokensType, n1058TokensDateTime, A1058TokensDateTime, n1057TokensSalt, A1057TokensSalt, A1050TokensId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Tokens");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Tokens"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate35109( ) ;
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
            EndLevel35109( ) ;
         }
         CloseExtendedTableCursors35109( ) ;
      }

      protected void DeferredUpdate35109( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate35109( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency35109( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls35109( ) ;
            AfterConfirm35109( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete35109( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00359 */
                  pr_default.execute(7, new Object[] {A1050TokensId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Tokens");
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
         sMode109 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel35109( ) ;
         Gx_mode = sMode109;
      }

      protected void OnDeleteControls35109( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel35109( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete35109( ) ;
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

      public void ScanKeyStart35109( )
      {
         /* Using cursor BC003510 */
         pr_default.execute(8, new Object[] {A1050TokensId});
         RcdFound109 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound109 = 1;
            A1050TokensId = BC003510_A1050TokensId[0];
            A1051TokensContent = BC003510_A1051TokensContent[0];
            n1051TokensContent = BC003510_n1051TokensContent[0];
            A1052TokensExpire = BC003510_A1052TokensExpire[0];
            n1052TokensExpire = BC003510_n1052TokensExpire[0];
            A1053TokensType = BC003510_A1053TokensType[0];
            n1053TokensType = BC003510_n1053TokensType[0];
            A1058TokensDateTime = BC003510_A1058TokensDateTime[0];
            n1058TokensDateTime = BC003510_n1058TokensDateTime[0];
            A1057TokensSalt = BC003510_A1057TokensSalt[0];
            n1057TokensSalt = BC003510_n1057TokensSalt[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext35109( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound109 = 0;
         ScanKeyLoad35109( ) ;
      }

      protected void ScanKeyLoad35109( )
      {
         sMode109 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound109 = 1;
            A1050TokensId = BC003510_A1050TokensId[0];
            A1051TokensContent = BC003510_A1051TokensContent[0];
            n1051TokensContent = BC003510_n1051TokensContent[0];
            A1052TokensExpire = BC003510_A1052TokensExpire[0];
            n1052TokensExpire = BC003510_n1052TokensExpire[0];
            A1053TokensType = BC003510_A1053TokensType[0];
            n1053TokensType = BC003510_n1053TokensType[0];
            A1058TokensDateTime = BC003510_A1058TokensDateTime[0];
            n1058TokensDateTime = BC003510_n1058TokensDateTime[0];
            A1057TokensSalt = BC003510_A1057TokensSalt[0];
            n1057TokensSalt = BC003510_n1057TokensSalt[0];
         }
         Gx_mode = sMode109;
      }

      protected void ScanKeyEnd35109( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm35109( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert35109( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate35109( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete35109( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete35109( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate35109( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes35109( )
      {
      }

      protected void send_integrity_lvl_hashes35109( )
      {
      }

      protected void AddRow35109( )
      {
         VarsToRow109( bcTokens) ;
      }

      protected void ReadRow35109( )
      {
         RowToVars109( bcTokens, 1) ;
      }

      protected void InitializeNonKey35109( )
      {
         A1051TokensContent = "";
         n1051TokensContent = false;
         A1052TokensExpire = 0;
         n1052TokensExpire = false;
         A1053TokensType = "";
         n1053TokensType = false;
         A1058TokensDateTime = 0;
         n1058TokensDateTime = false;
         A1057TokensSalt = "";
         n1057TokensSalt = false;
         Z1052TokensExpire = 0;
         Z1053TokensType = "";
         Z1058TokensDateTime = 0;
      }

      protected void InitAll35109( )
      {
         A1050TokensId = 0;
         InitializeNonKey35109( ) ;
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

      public void VarsToRow109( SdtTokens obj109 )
      {
         obj109.gxTpr_Mode = Gx_mode;
         obj109.gxTpr_Tokenscontent = A1051TokensContent;
         obj109.gxTpr_Tokensexpire = A1052TokensExpire;
         obj109.gxTpr_Tokenstype = A1053TokensType;
         obj109.gxTpr_Tokensdatetime = A1058TokensDateTime;
         obj109.gxTpr_Tokenssalt = A1057TokensSalt;
         obj109.gxTpr_Tokensid = A1050TokensId;
         obj109.gxTpr_Tokensid_Z = Z1050TokensId;
         obj109.gxTpr_Tokensexpire_Z = Z1052TokensExpire;
         obj109.gxTpr_Tokenstype_Z = Z1053TokensType;
         obj109.gxTpr_Tokensdatetime_Z = Z1058TokensDateTime;
         obj109.gxTpr_Tokenscontent_N = (short)(Convert.ToInt16(n1051TokensContent));
         obj109.gxTpr_Tokensexpire_N = (short)(Convert.ToInt16(n1052TokensExpire));
         obj109.gxTpr_Tokenstype_N = (short)(Convert.ToInt16(n1053TokensType));
         obj109.gxTpr_Tokensdatetime_N = (short)(Convert.ToInt16(n1058TokensDateTime));
         obj109.gxTpr_Tokenssalt_N = (short)(Convert.ToInt16(n1057TokensSalt));
         obj109.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow109( SdtTokens obj109 )
      {
         obj109.gxTpr_Tokensid = A1050TokensId;
         return  ;
      }

      public void RowToVars109( SdtTokens obj109 ,
                                int forceLoad )
      {
         Gx_mode = obj109.gxTpr_Mode;
         A1051TokensContent = obj109.gxTpr_Tokenscontent;
         n1051TokensContent = false;
         A1052TokensExpire = obj109.gxTpr_Tokensexpire;
         n1052TokensExpire = false;
         A1053TokensType = obj109.gxTpr_Tokenstype;
         n1053TokensType = false;
         A1058TokensDateTime = obj109.gxTpr_Tokensdatetime;
         n1058TokensDateTime = false;
         A1057TokensSalt = obj109.gxTpr_Tokenssalt;
         n1057TokensSalt = false;
         A1050TokensId = obj109.gxTpr_Tokensid;
         Z1050TokensId = obj109.gxTpr_Tokensid_Z;
         Z1052TokensExpire = obj109.gxTpr_Tokensexpire_Z;
         Z1053TokensType = obj109.gxTpr_Tokenstype_Z;
         Z1058TokensDateTime = obj109.gxTpr_Tokensdatetime_Z;
         n1051TokensContent = (bool)(Convert.ToBoolean(obj109.gxTpr_Tokenscontent_N));
         n1052TokensExpire = (bool)(Convert.ToBoolean(obj109.gxTpr_Tokensexpire_N));
         n1053TokensType = (bool)(Convert.ToBoolean(obj109.gxTpr_Tokenstype_N));
         n1058TokensDateTime = (bool)(Convert.ToBoolean(obj109.gxTpr_Tokensdatetime_N));
         n1057TokensSalt = (bool)(Convert.ToBoolean(obj109.gxTpr_Tokenssalt_N));
         Gx_mode = obj109.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1050TokensId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey35109( ) ;
         ScanKeyStart35109( ) ;
         if ( RcdFound109 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1050TokensId = A1050TokensId;
         }
         ZM35109( -2) ;
         OnLoadActions35109( ) ;
         AddRow35109( ) ;
         ScanKeyEnd35109( ) ;
         if ( RcdFound109 == 0 )
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
         RowToVars109( bcTokens, 0) ;
         ScanKeyStart35109( ) ;
         if ( RcdFound109 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1050TokensId = A1050TokensId;
         }
         ZM35109( -2) ;
         OnLoadActions35109( ) ;
         AddRow35109( ) ;
         ScanKeyEnd35109( ) ;
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey35109( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert35109( ) ;
         }
         else
         {
            if ( RcdFound109 == 1 )
            {
               if ( A1050TokensId != Z1050TokensId )
               {
                  A1050TokensId = Z1050TokensId;
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
                  Update35109( ) ;
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
                  if ( A1050TokensId != Z1050TokensId )
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
                        Insert35109( ) ;
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
                        Insert35109( ) ;
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
         RowToVars109( bcTokens, 1) ;
         SaveImpl( ) ;
         VarsToRow109( bcTokens) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars109( bcTokens, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert35109( ) ;
         AfterTrn( ) ;
         VarsToRow109( bcTokens) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow109( bcTokens) ;
         }
         else
         {
            SdtTokens auxBC = new SdtTokens(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1050TokensId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTokens);
               auxBC.Save();
               bcTokens.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars109( bcTokens, 1) ;
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
         RowToVars109( bcTokens, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert35109( ) ;
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
               VarsToRow109( bcTokens) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow109( bcTokens) ;
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
         RowToVars109( bcTokens, 0) ;
         GetKey35109( ) ;
         if ( RcdFound109 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1050TokensId != Z1050TokensId )
            {
               A1050TokensId = Z1050TokensId;
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
            if ( A1050TokensId != Z1050TokensId )
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
         context.RollbackDataStores("tokens_bc",pr_default);
         VarsToRow109( bcTokens) ;
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
         Gx_mode = bcTokens.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTokens.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTokens )
         {
            bcTokens = (SdtTokens)(sdt);
            if ( StringUtil.StrCmp(bcTokens.gxTpr_Mode, "") == 0 )
            {
               bcTokens.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow109( bcTokens) ;
            }
            else
            {
               RowToVars109( bcTokens, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTokens.gxTpr_Mode, "") == 0 )
            {
               bcTokens.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars109( bcTokens, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTokens Tokens_BC
      {
         get {
            return bcTokens ;
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
         Z1053TokensType = "";
         A1053TokensType = "";
         Z1051TokensContent = "";
         A1051TokensContent = "";
         Z1057TokensSalt = "";
         A1057TokensSalt = "";
         BC00354_A1050TokensId = new int[1] ;
         BC00354_A1051TokensContent = new string[] {""} ;
         BC00354_n1051TokensContent = new bool[] {false} ;
         BC00354_A1052TokensExpire = new int[1] ;
         BC00354_n1052TokensExpire = new bool[] {false} ;
         BC00354_A1053TokensType = new string[] {""} ;
         BC00354_n1053TokensType = new bool[] {false} ;
         BC00354_A1058TokensDateTime = new long[1] ;
         BC00354_n1058TokensDateTime = new bool[] {false} ;
         BC00354_A1057TokensSalt = new string[] {""} ;
         BC00354_n1057TokensSalt = new bool[] {false} ;
         BC00355_A1050TokensId = new int[1] ;
         BC00353_A1050TokensId = new int[1] ;
         BC00353_A1051TokensContent = new string[] {""} ;
         BC00353_n1051TokensContent = new bool[] {false} ;
         BC00353_A1052TokensExpire = new int[1] ;
         BC00353_n1052TokensExpire = new bool[] {false} ;
         BC00353_A1053TokensType = new string[] {""} ;
         BC00353_n1053TokensType = new bool[] {false} ;
         BC00353_A1058TokensDateTime = new long[1] ;
         BC00353_n1058TokensDateTime = new bool[] {false} ;
         BC00353_A1057TokensSalt = new string[] {""} ;
         BC00353_n1057TokensSalt = new bool[] {false} ;
         sMode109 = "";
         BC00352_A1050TokensId = new int[1] ;
         BC00352_A1051TokensContent = new string[] {""} ;
         BC00352_n1051TokensContent = new bool[] {false} ;
         BC00352_A1052TokensExpire = new int[1] ;
         BC00352_n1052TokensExpire = new bool[] {false} ;
         BC00352_A1053TokensType = new string[] {""} ;
         BC00352_n1053TokensType = new bool[] {false} ;
         BC00352_A1058TokensDateTime = new long[1] ;
         BC00352_n1058TokensDateTime = new bool[] {false} ;
         BC00352_A1057TokensSalt = new string[] {""} ;
         BC00352_n1057TokensSalt = new bool[] {false} ;
         BC00357_A1050TokensId = new int[1] ;
         BC003510_A1050TokensId = new int[1] ;
         BC003510_A1051TokensContent = new string[] {""} ;
         BC003510_n1051TokensContent = new bool[] {false} ;
         BC003510_A1052TokensExpire = new int[1] ;
         BC003510_n1052TokensExpire = new bool[] {false} ;
         BC003510_A1053TokensType = new string[] {""} ;
         BC003510_n1053TokensType = new bool[] {false} ;
         BC003510_A1058TokensDateTime = new long[1] ;
         BC003510_n1058TokensDateTime = new bool[] {false} ;
         BC003510_A1057TokensSalt = new string[] {""} ;
         BC003510_n1057TokensSalt = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tokens_bc__default(),
            new Object[][] {
                new Object[] {
               BC00352_A1050TokensId, BC00352_A1051TokensContent, BC00352_n1051TokensContent, BC00352_A1052TokensExpire, BC00352_n1052TokensExpire, BC00352_A1053TokensType, BC00352_n1053TokensType, BC00352_A1058TokensDateTime, BC00352_n1058TokensDateTime, BC00352_A1057TokensSalt,
               BC00352_n1057TokensSalt
               }
               , new Object[] {
               BC00353_A1050TokensId, BC00353_A1051TokensContent, BC00353_n1051TokensContent, BC00353_A1052TokensExpire, BC00353_n1052TokensExpire, BC00353_A1053TokensType, BC00353_n1053TokensType, BC00353_A1058TokensDateTime, BC00353_n1058TokensDateTime, BC00353_A1057TokensSalt,
               BC00353_n1057TokensSalt
               }
               , new Object[] {
               BC00354_A1050TokensId, BC00354_A1051TokensContent, BC00354_n1051TokensContent, BC00354_A1052TokensExpire, BC00354_n1052TokensExpire, BC00354_A1053TokensType, BC00354_n1053TokensType, BC00354_A1058TokensDateTime, BC00354_n1058TokensDateTime, BC00354_A1057TokensSalt,
               BC00354_n1057TokensSalt
               }
               , new Object[] {
               BC00355_A1050TokensId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00357_A1050TokensId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC003510_A1050TokensId, BC003510_A1051TokensContent, BC003510_n1051TokensContent, BC003510_A1052TokensExpire, BC003510_n1052TokensExpire, BC003510_A1053TokensType, BC003510_n1053TokensType, BC003510_A1058TokensDateTime, BC003510_n1058TokensDateTime, BC003510_A1057TokensSalt,
               BC003510_n1057TokensSalt
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound109 ;
      private int trnEnded ;
      private int Z1050TokensId ;
      private int A1050TokensId ;
      private int Z1052TokensExpire ;
      private int A1052TokensExpire ;
      private long Z1058TokensDateTime ;
      private long A1058TokensDateTime ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode109 ;
      private bool n1051TokensContent ;
      private bool n1052TokensExpire ;
      private bool n1053TokensType ;
      private bool n1058TokensDateTime ;
      private bool n1057TokensSalt ;
      private string Z1051TokensContent ;
      private string A1051TokensContent ;
      private string Z1057TokensSalt ;
      private string A1057TokensSalt ;
      private string Z1053TokensType ;
      private string A1053TokensType ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00354_A1050TokensId ;
      private string[] BC00354_A1051TokensContent ;
      private bool[] BC00354_n1051TokensContent ;
      private int[] BC00354_A1052TokensExpire ;
      private bool[] BC00354_n1052TokensExpire ;
      private string[] BC00354_A1053TokensType ;
      private bool[] BC00354_n1053TokensType ;
      private long[] BC00354_A1058TokensDateTime ;
      private bool[] BC00354_n1058TokensDateTime ;
      private string[] BC00354_A1057TokensSalt ;
      private bool[] BC00354_n1057TokensSalt ;
      private int[] BC00355_A1050TokensId ;
      private int[] BC00353_A1050TokensId ;
      private string[] BC00353_A1051TokensContent ;
      private bool[] BC00353_n1051TokensContent ;
      private int[] BC00353_A1052TokensExpire ;
      private bool[] BC00353_n1052TokensExpire ;
      private string[] BC00353_A1053TokensType ;
      private bool[] BC00353_n1053TokensType ;
      private long[] BC00353_A1058TokensDateTime ;
      private bool[] BC00353_n1058TokensDateTime ;
      private string[] BC00353_A1057TokensSalt ;
      private bool[] BC00353_n1057TokensSalt ;
      private int[] BC00352_A1050TokensId ;
      private string[] BC00352_A1051TokensContent ;
      private bool[] BC00352_n1051TokensContent ;
      private int[] BC00352_A1052TokensExpire ;
      private bool[] BC00352_n1052TokensExpire ;
      private string[] BC00352_A1053TokensType ;
      private bool[] BC00352_n1053TokensType ;
      private long[] BC00352_A1058TokensDateTime ;
      private bool[] BC00352_n1058TokensDateTime ;
      private string[] BC00352_A1057TokensSalt ;
      private bool[] BC00352_n1057TokensSalt ;
      private int[] BC00357_A1050TokensId ;
      private int[] BC003510_A1050TokensId ;
      private string[] BC003510_A1051TokensContent ;
      private bool[] BC003510_n1051TokensContent ;
      private int[] BC003510_A1052TokensExpire ;
      private bool[] BC003510_n1052TokensExpire ;
      private string[] BC003510_A1053TokensType ;
      private bool[] BC003510_n1053TokensType ;
      private long[] BC003510_A1058TokensDateTime ;
      private bool[] BC003510_n1058TokensDateTime ;
      private string[] BC003510_A1057TokensSalt ;
      private bool[] BC003510_n1057TokensSalt ;
      private SdtTokens bcTokens ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class tokens_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC00352;
          prmBC00352 = new Object[] {
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmBC00353;
          prmBC00353 = new Object[] {
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmBC00354;
          prmBC00354 = new Object[] {
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmBC00355;
          prmBC00355 = new Object[] {
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmBC00356;
          prmBC00356 = new Object[] {
          new ParDef("TokensContent",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("TokensExpire",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("TokensType",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("TokensDateTime",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("TokensSalt",GXType.LongVarChar,2097152,0){Nullable=true}
          };
          Object[] prmBC00357;
          prmBC00357 = new Object[] {
          };
          Object[] prmBC00358;
          prmBC00358 = new Object[] {
          new ParDef("TokensContent",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("TokensExpire",GXType.Int32,8,0){Nullable=true} ,
          new ParDef("TokensType",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("TokensDateTime",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("TokensSalt",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmBC00359;
          prmBC00359 = new Object[] {
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          Object[] prmBC003510;
          prmBC003510 = new Object[] {
          new ParDef("TokensId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00352", "SELECT TokensId, TokensContent, TokensExpire, TokensType, TokensDateTime, TokensSalt FROM Tokens WHERE TokensId = :TokensId  FOR UPDATE OF Tokens",true, GxErrorMask.GX_NOMASK, false, this,prmBC00352,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00353", "SELECT TokensId, TokensContent, TokensExpire, TokensType, TokensDateTime, TokensSalt FROM Tokens WHERE TokensId = :TokensId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00353,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00354", "SELECT TM1.TokensId, TM1.TokensContent, TM1.TokensExpire, TM1.TokensType, TM1.TokensDateTime, TM1.TokensSalt FROM Tokens TM1 WHERE TM1.TokensId = :TokensId ORDER BY TM1.TokensId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00354,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00355", "SELECT TokensId FROM Tokens WHERE TokensId = :TokensId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00355,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00356", "SAVEPOINT gxupdate;INSERT INTO Tokens(TokensContent, TokensExpire, TokensType, TokensDateTime, TokensSalt) VALUES(:TokensContent, :TokensExpire, :TokensType, :TokensDateTime, :TokensSalt);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00356)
             ,new CursorDef("BC00357", "SELECT currval('TokensId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00357,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00358", "SAVEPOINT gxupdate;UPDATE Tokens SET TokensContent=:TokensContent, TokensExpire=:TokensExpire, TokensType=:TokensType, TokensDateTime=:TokensDateTime, TokensSalt=:TokensSalt  WHERE TokensId = :TokensId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00358)
             ,new CursorDef("BC00359", "SAVEPOINT gxupdate;DELETE FROM Tokens  WHERE TokensId = :TokensId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00359)
             ,new CursorDef("BC003510", "SELECT TM1.TokensId, TM1.TokensContent, TM1.TokensExpire, TM1.TokensType, TM1.TokensDateTime, TM1.TokensSalt FROM Tokens TM1 WHERE TM1.TokensId = :TokensId ORDER BY TM1.TokensId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003510,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((long[]) buf[7])[0] = rslt.getLong(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getLongVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
