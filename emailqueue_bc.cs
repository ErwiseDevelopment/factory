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
   public class emailqueue_bc : GxSilentTrn, IGxSilentTrn
   {
      public emailqueue_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public emailqueue_bc( IGxContext context )
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
         ReadRow1J58( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1J58( ) ;
         standaloneModal( ) ;
         AddRow1J58( ) ;
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
               Z392EmailQueueId = A392EmailQueueId;
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

      protected void CONFIRM_1J0( )
      {
         BeforeValidate1J58( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1J58( ) ;
            }
            else
            {
               CheckExtendedTable1J58( ) ;
               if ( AnyError == 0 )
               {
                  ZM1J58( 4) ;
               }
               CloseExtendedTableCursors1J58( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1J58( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z393EmailQueueRecipient = A393EmailQueueRecipient;
            Z394EmailQueueStatus = A394EmailQueueStatus;
            Z395EmailQueueSentAt = A395EmailQueueSentAt;
            Z396EmailQueueErrorMessage = A396EmailQueueErrorMessage;
            Z381NotificationId = A381NotificationId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -3 )
         {
            Z392EmailQueueId = A392EmailQueueId;
            Z393EmailQueueRecipient = A393EmailQueueRecipient;
            Z394EmailQueueStatus = A394EmailQueueStatus;
            Z395EmailQueueSentAt = A395EmailQueueSentAt;
            Z396EmailQueueErrorMessage = A396EmailQueueErrorMessage;
            Z381NotificationId = A381NotificationId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1J58( )
      {
         /* Using cursor BC001J5 */
         pr_default.execute(3, new Object[] {A392EmailQueueId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound58 = 1;
            A393EmailQueueRecipient = BC001J5_A393EmailQueueRecipient[0];
            n393EmailQueueRecipient = BC001J5_n393EmailQueueRecipient[0];
            A394EmailQueueStatus = BC001J5_A394EmailQueueStatus[0];
            n394EmailQueueStatus = BC001J5_n394EmailQueueStatus[0];
            A395EmailQueueSentAt = BC001J5_A395EmailQueueSentAt[0];
            n395EmailQueueSentAt = BC001J5_n395EmailQueueSentAt[0];
            A396EmailQueueErrorMessage = BC001J5_A396EmailQueueErrorMessage[0];
            n396EmailQueueErrorMessage = BC001J5_n396EmailQueueErrorMessage[0];
            A381NotificationId = BC001J5_A381NotificationId[0];
            n381NotificationId = BC001J5_n381NotificationId[0];
            ZM1J58( -3) ;
         }
         pr_default.close(3);
         OnLoadActions1J58( ) ;
      }

      protected void OnLoadActions1J58( )
      {
      }

      protected void CheckExtendedTable1J58( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001J4 */
         pr_default.execute(2, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A381NotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'Notification'.", "ForeignKeyNotFound", 1, "NOTIFICATIONID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A393EmailQueueRecipient,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A393EmailQueueRecipient)) ) )
         {
            GX_msglist.addItem("O valor de Email Queue Recipient não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A394EmailQueueStatus, "Pending") == 0 ) || ( StringUtil.StrCmp(A394EmailQueueStatus, "Sent") == 0 ) || ( StringUtil.StrCmp(A394EmailQueueStatus, "Failed") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A394EmailQueueStatus)) ) )
         {
            GX_msglist.addItem("Campo Email Queue Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1J58( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1J58( )
      {
         /* Using cursor BC001J6 */
         pr_default.execute(4, new Object[] {A392EmailQueueId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound58 = 1;
         }
         else
         {
            RcdFound58 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001J3 */
         pr_default.execute(1, new Object[] {A392EmailQueueId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1J58( 3) ;
            RcdFound58 = 1;
            A392EmailQueueId = BC001J3_A392EmailQueueId[0];
            A393EmailQueueRecipient = BC001J3_A393EmailQueueRecipient[0];
            n393EmailQueueRecipient = BC001J3_n393EmailQueueRecipient[0];
            A394EmailQueueStatus = BC001J3_A394EmailQueueStatus[0];
            n394EmailQueueStatus = BC001J3_n394EmailQueueStatus[0];
            A395EmailQueueSentAt = BC001J3_A395EmailQueueSentAt[0];
            n395EmailQueueSentAt = BC001J3_n395EmailQueueSentAt[0];
            A396EmailQueueErrorMessage = BC001J3_A396EmailQueueErrorMessage[0];
            n396EmailQueueErrorMessage = BC001J3_n396EmailQueueErrorMessage[0];
            A381NotificationId = BC001J3_A381NotificationId[0];
            n381NotificationId = BC001J3_n381NotificationId[0];
            Z392EmailQueueId = A392EmailQueueId;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1J58( ) ;
            if ( AnyError == 1 )
            {
               RcdFound58 = 0;
               InitializeNonKey1J58( ) ;
            }
            Gx_mode = sMode58;
         }
         else
         {
            RcdFound58 = 0;
            InitializeNonKey1J58( ) ;
            sMode58 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode58;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1J58( ) ;
         if ( RcdFound58 == 0 )
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
         CONFIRM_1J0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1J58( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001J2 */
            pr_default.execute(0, new Object[] {A392EmailQueueId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmailQueue"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z393EmailQueueRecipient, BC001J2_A393EmailQueueRecipient[0]) != 0 ) || ( StringUtil.StrCmp(Z394EmailQueueStatus, BC001J2_A394EmailQueueStatus[0]) != 0 ) || ( Z395EmailQueueSentAt != BC001J2_A395EmailQueueSentAt[0] ) || ( StringUtil.StrCmp(Z396EmailQueueErrorMessage, BC001J2_A396EmailQueueErrorMessage[0]) != 0 ) || ( Z381NotificationId != BC001J2_A381NotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EmailQueue"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1J58( )
      {
         BeforeValidate1J58( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1J58( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1J58( 0) ;
            CheckOptimisticConcurrency1J58( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1J58( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1J58( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001J7 */
                     pr_default.execute(5, new Object[] {n393EmailQueueRecipient, A393EmailQueueRecipient, n394EmailQueueStatus, A394EmailQueueStatus, n395EmailQueueSentAt, A395EmailQueueSentAt, n396EmailQueueErrorMessage, A396EmailQueueErrorMessage, n381NotificationId, A381NotificationId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001J8 */
                     pr_default.execute(6);
                     A392EmailQueueId = BC001J8_A392EmailQueueId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("EmailQueue");
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
               Load1J58( ) ;
            }
            EndLevel1J58( ) ;
         }
         CloseExtendedTableCursors1J58( ) ;
      }

      protected void Update1J58( )
      {
         BeforeValidate1J58( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1J58( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1J58( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1J58( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1J58( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001J9 */
                     pr_default.execute(7, new Object[] {n393EmailQueueRecipient, A393EmailQueueRecipient, n394EmailQueueStatus, A394EmailQueueStatus, n395EmailQueueSentAt, A395EmailQueueSentAt, n396EmailQueueErrorMessage, A396EmailQueueErrorMessage, n381NotificationId, A381NotificationId, A392EmailQueueId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("EmailQueue");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EmailQueue"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1J58( ) ;
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
            EndLevel1J58( ) ;
         }
         CloseExtendedTableCursors1J58( ) ;
      }

      protected void DeferredUpdate1J58( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1J58( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1J58( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1J58( ) ;
            AfterConfirm1J58( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1J58( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001J10 */
                  pr_default.execute(8, new Object[] {A392EmailQueueId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("EmailQueue");
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
         sMode58 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1J58( ) ;
         Gx_mode = sMode58;
      }

      protected void OnDeleteControls1J58( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1J58( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1J58( ) ;
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

      public void ScanKeyStart1J58( )
      {
         /* Using cursor BC001J11 */
         pr_default.execute(9, new Object[] {A392EmailQueueId});
         RcdFound58 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound58 = 1;
            A392EmailQueueId = BC001J11_A392EmailQueueId[0];
            A393EmailQueueRecipient = BC001J11_A393EmailQueueRecipient[0];
            n393EmailQueueRecipient = BC001J11_n393EmailQueueRecipient[0];
            A394EmailQueueStatus = BC001J11_A394EmailQueueStatus[0];
            n394EmailQueueStatus = BC001J11_n394EmailQueueStatus[0];
            A395EmailQueueSentAt = BC001J11_A395EmailQueueSentAt[0];
            n395EmailQueueSentAt = BC001J11_n395EmailQueueSentAt[0];
            A396EmailQueueErrorMessage = BC001J11_A396EmailQueueErrorMessage[0];
            n396EmailQueueErrorMessage = BC001J11_n396EmailQueueErrorMessage[0];
            A381NotificationId = BC001J11_A381NotificationId[0];
            n381NotificationId = BC001J11_n381NotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1J58( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound58 = 0;
         ScanKeyLoad1J58( ) ;
      }

      protected void ScanKeyLoad1J58( )
      {
         sMode58 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound58 = 1;
            A392EmailQueueId = BC001J11_A392EmailQueueId[0];
            A393EmailQueueRecipient = BC001J11_A393EmailQueueRecipient[0];
            n393EmailQueueRecipient = BC001J11_n393EmailQueueRecipient[0];
            A394EmailQueueStatus = BC001J11_A394EmailQueueStatus[0];
            n394EmailQueueStatus = BC001J11_n394EmailQueueStatus[0];
            A395EmailQueueSentAt = BC001J11_A395EmailQueueSentAt[0];
            n395EmailQueueSentAt = BC001J11_n395EmailQueueSentAt[0];
            A396EmailQueueErrorMessage = BC001J11_A396EmailQueueErrorMessage[0];
            n396EmailQueueErrorMessage = BC001J11_n396EmailQueueErrorMessage[0];
            A381NotificationId = BC001J11_A381NotificationId[0];
            n381NotificationId = BC001J11_n381NotificationId[0];
         }
         Gx_mode = sMode58;
      }

      protected void ScanKeyEnd1J58( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm1J58( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1J58( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1J58( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1J58( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1J58( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1J58( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1J58( )
      {
      }

      protected void send_integrity_lvl_hashes1J58( )
      {
      }

      protected void AddRow1J58( )
      {
         VarsToRow58( bcEmailQueue) ;
      }

      protected void ReadRow1J58( )
      {
         RowToVars58( bcEmailQueue, 1) ;
      }

      protected void InitializeNonKey1J58( )
      {
         A381NotificationId = 0;
         n381NotificationId = false;
         A393EmailQueueRecipient = "";
         n393EmailQueueRecipient = false;
         A394EmailQueueStatus = "";
         n394EmailQueueStatus = false;
         A395EmailQueueSentAt = (DateTime)(DateTime.MinValue);
         n395EmailQueueSentAt = false;
         A396EmailQueueErrorMessage = "";
         n396EmailQueueErrorMessage = false;
         Z393EmailQueueRecipient = "";
         Z394EmailQueueStatus = "";
         Z395EmailQueueSentAt = (DateTime)(DateTime.MinValue);
         Z396EmailQueueErrorMessage = "";
         Z381NotificationId = 0;
      }

      protected void InitAll1J58( )
      {
         A392EmailQueueId = 0;
         InitializeNonKey1J58( ) ;
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

      public void VarsToRow58( SdtEmailQueue obj58 )
      {
         obj58.gxTpr_Mode = Gx_mode;
         obj58.gxTpr_Notificationid = A381NotificationId;
         obj58.gxTpr_Emailqueuerecipient = A393EmailQueueRecipient;
         obj58.gxTpr_Emailqueuestatus = A394EmailQueueStatus;
         obj58.gxTpr_Emailqueuesentat = A395EmailQueueSentAt;
         obj58.gxTpr_Emailqueueerrormessage = A396EmailQueueErrorMessage;
         obj58.gxTpr_Emailqueueid = A392EmailQueueId;
         obj58.gxTpr_Emailqueueid_Z = Z392EmailQueueId;
         obj58.gxTpr_Notificationid_Z = Z381NotificationId;
         obj58.gxTpr_Emailqueuerecipient_Z = Z393EmailQueueRecipient;
         obj58.gxTpr_Emailqueuestatus_Z = Z394EmailQueueStatus;
         obj58.gxTpr_Emailqueuesentat_Z = Z395EmailQueueSentAt;
         obj58.gxTpr_Emailqueueerrormessage_Z = Z396EmailQueueErrorMessage;
         obj58.gxTpr_Notificationid_N = (short)(Convert.ToInt16(n381NotificationId));
         obj58.gxTpr_Emailqueuerecipient_N = (short)(Convert.ToInt16(n393EmailQueueRecipient));
         obj58.gxTpr_Emailqueuestatus_N = (short)(Convert.ToInt16(n394EmailQueueStatus));
         obj58.gxTpr_Emailqueuesentat_N = (short)(Convert.ToInt16(n395EmailQueueSentAt));
         obj58.gxTpr_Emailqueueerrormessage_N = (short)(Convert.ToInt16(n396EmailQueueErrorMessage));
         obj58.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow58( SdtEmailQueue obj58 )
      {
         obj58.gxTpr_Emailqueueid = A392EmailQueueId;
         return  ;
      }

      public void RowToVars58( SdtEmailQueue obj58 ,
                               int forceLoad )
      {
         Gx_mode = obj58.gxTpr_Mode;
         A381NotificationId = obj58.gxTpr_Notificationid;
         n381NotificationId = false;
         A393EmailQueueRecipient = obj58.gxTpr_Emailqueuerecipient;
         n393EmailQueueRecipient = false;
         A394EmailQueueStatus = obj58.gxTpr_Emailqueuestatus;
         n394EmailQueueStatus = false;
         A395EmailQueueSentAt = obj58.gxTpr_Emailqueuesentat;
         n395EmailQueueSentAt = false;
         A396EmailQueueErrorMessage = obj58.gxTpr_Emailqueueerrormessage;
         n396EmailQueueErrorMessage = false;
         A392EmailQueueId = obj58.gxTpr_Emailqueueid;
         Z392EmailQueueId = obj58.gxTpr_Emailqueueid_Z;
         Z381NotificationId = obj58.gxTpr_Notificationid_Z;
         Z393EmailQueueRecipient = obj58.gxTpr_Emailqueuerecipient_Z;
         Z394EmailQueueStatus = obj58.gxTpr_Emailqueuestatus_Z;
         Z395EmailQueueSentAt = obj58.gxTpr_Emailqueuesentat_Z;
         Z396EmailQueueErrorMessage = obj58.gxTpr_Emailqueueerrormessage_Z;
         n381NotificationId = (bool)(Convert.ToBoolean(obj58.gxTpr_Notificationid_N));
         n393EmailQueueRecipient = (bool)(Convert.ToBoolean(obj58.gxTpr_Emailqueuerecipient_N));
         n394EmailQueueStatus = (bool)(Convert.ToBoolean(obj58.gxTpr_Emailqueuestatus_N));
         n395EmailQueueSentAt = (bool)(Convert.ToBoolean(obj58.gxTpr_Emailqueuesentat_N));
         n396EmailQueueErrorMessage = (bool)(Convert.ToBoolean(obj58.gxTpr_Emailqueueerrormessage_N));
         Gx_mode = obj58.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A392EmailQueueId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1J58( ) ;
         ScanKeyStart1J58( ) ;
         if ( RcdFound58 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z392EmailQueueId = A392EmailQueueId;
         }
         ZM1J58( -3) ;
         OnLoadActions1J58( ) ;
         AddRow1J58( ) ;
         ScanKeyEnd1J58( ) ;
         if ( RcdFound58 == 0 )
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
         RowToVars58( bcEmailQueue, 0) ;
         ScanKeyStart1J58( ) ;
         if ( RcdFound58 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z392EmailQueueId = A392EmailQueueId;
         }
         ZM1J58( -3) ;
         OnLoadActions1J58( ) ;
         AddRow1J58( ) ;
         ScanKeyEnd1J58( ) ;
         if ( RcdFound58 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1J58( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1J58( ) ;
         }
         else
         {
            if ( RcdFound58 == 1 )
            {
               if ( A392EmailQueueId != Z392EmailQueueId )
               {
                  A392EmailQueueId = Z392EmailQueueId;
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
                  Update1J58( ) ;
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
                  if ( A392EmailQueueId != Z392EmailQueueId )
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
                        Insert1J58( ) ;
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
                        Insert1J58( ) ;
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
         RowToVars58( bcEmailQueue, 1) ;
         SaveImpl( ) ;
         VarsToRow58( bcEmailQueue) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars58( bcEmailQueue, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1J58( ) ;
         AfterTrn( ) ;
         VarsToRow58( bcEmailQueue) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow58( bcEmailQueue) ;
         }
         else
         {
            SdtEmailQueue auxBC = new SdtEmailQueue(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A392EmailQueueId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEmailQueue);
               auxBC.Save();
               bcEmailQueue.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars58( bcEmailQueue, 1) ;
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
         RowToVars58( bcEmailQueue, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1J58( ) ;
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
               VarsToRow58( bcEmailQueue) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow58( bcEmailQueue) ;
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
         RowToVars58( bcEmailQueue, 0) ;
         GetKey1J58( ) ;
         if ( RcdFound58 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A392EmailQueueId != Z392EmailQueueId )
            {
               A392EmailQueueId = Z392EmailQueueId;
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
            if ( A392EmailQueueId != Z392EmailQueueId )
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
         context.RollbackDataStores("emailqueue_bc",pr_default);
         VarsToRow58( bcEmailQueue) ;
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
         Gx_mode = bcEmailQueue.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEmailQueue.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEmailQueue )
         {
            bcEmailQueue = (SdtEmailQueue)(sdt);
            if ( StringUtil.StrCmp(bcEmailQueue.gxTpr_Mode, "") == 0 )
            {
               bcEmailQueue.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow58( bcEmailQueue) ;
            }
            else
            {
               RowToVars58( bcEmailQueue, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEmailQueue.gxTpr_Mode, "") == 0 )
            {
               bcEmailQueue.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars58( bcEmailQueue, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtEmailQueue EmailQueue_BC
      {
         get {
            return bcEmailQueue ;
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
         Z393EmailQueueRecipient = "";
         A393EmailQueueRecipient = "";
         Z394EmailQueueStatus = "";
         A394EmailQueueStatus = "";
         Z395EmailQueueSentAt = (DateTime)(DateTime.MinValue);
         A395EmailQueueSentAt = (DateTime)(DateTime.MinValue);
         Z396EmailQueueErrorMessage = "";
         A396EmailQueueErrorMessage = "";
         BC001J5_A392EmailQueueId = new int[1] ;
         BC001J5_A393EmailQueueRecipient = new string[] {""} ;
         BC001J5_n393EmailQueueRecipient = new bool[] {false} ;
         BC001J5_A394EmailQueueStatus = new string[] {""} ;
         BC001J5_n394EmailQueueStatus = new bool[] {false} ;
         BC001J5_A395EmailQueueSentAt = new DateTime[] {DateTime.MinValue} ;
         BC001J5_n395EmailQueueSentAt = new bool[] {false} ;
         BC001J5_A396EmailQueueErrorMessage = new string[] {""} ;
         BC001J5_n396EmailQueueErrorMessage = new bool[] {false} ;
         BC001J5_A381NotificationId = new int[1] ;
         BC001J5_n381NotificationId = new bool[] {false} ;
         BC001J4_A381NotificationId = new int[1] ;
         BC001J4_n381NotificationId = new bool[] {false} ;
         BC001J6_A392EmailQueueId = new int[1] ;
         BC001J3_A392EmailQueueId = new int[1] ;
         BC001J3_A393EmailQueueRecipient = new string[] {""} ;
         BC001J3_n393EmailQueueRecipient = new bool[] {false} ;
         BC001J3_A394EmailQueueStatus = new string[] {""} ;
         BC001J3_n394EmailQueueStatus = new bool[] {false} ;
         BC001J3_A395EmailQueueSentAt = new DateTime[] {DateTime.MinValue} ;
         BC001J3_n395EmailQueueSentAt = new bool[] {false} ;
         BC001J3_A396EmailQueueErrorMessage = new string[] {""} ;
         BC001J3_n396EmailQueueErrorMessage = new bool[] {false} ;
         BC001J3_A381NotificationId = new int[1] ;
         BC001J3_n381NotificationId = new bool[] {false} ;
         sMode58 = "";
         BC001J2_A392EmailQueueId = new int[1] ;
         BC001J2_A393EmailQueueRecipient = new string[] {""} ;
         BC001J2_n393EmailQueueRecipient = new bool[] {false} ;
         BC001J2_A394EmailQueueStatus = new string[] {""} ;
         BC001J2_n394EmailQueueStatus = new bool[] {false} ;
         BC001J2_A395EmailQueueSentAt = new DateTime[] {DateTime.MinValue} ;
         BC001J2_n395EmailQueueSentAt = new bool[] {false} ;
         BC001J2_A396EmailQueueErrorMessage = new string[] {""} ;
         BC001J2_n396EmailQueueErrorMessage = new bool[] {false} ;
         BC001J2_A381NotificationId = new int[1] ;
         BC001J2_n381NotificationId = new bool[] {false} ;
         BC001J8_A392EmailQueueId = new int[1] ;
         BC001J11_A392EmailQueueId = new int[1] ;
         BC001J11_A393EmailQueueRecipient = new string[] {""} ;
         BC001J11_n393EmailQueueRecipient = new bool[] {false} ;
         BC001J11_A394EmailQueueStatus = new string[] {""} ;
         BC001J11_n394EmailQueueStatus = new bool[] {false} ;
         BC001J11_A395EmailQueueSentAt = new DateTime[] {DateTime.MinValue} ;
         BC001J11_n395EmailQueueSentAt = new bool[] {false} ;
         BC001J11_A396EmailQueueErrorMessage = new string[] {""} ;
         BC001J11_n396EmailQueueErrorMessage = new bool[] {false} ;
         BC001J11_A381NotificationId = new int[1] ;
         BC001J11_n381NotificationId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.emailqueue_bc__default(),
            new Object[][] {
                new Object[] {
               BC001J2_A392EmailQueueId, BC001J2_A393EmailQueueRecipient, BC001J2_n393EmailQueueRecipient, BC001J2_A394EmailQueueStatus, BC001J2_n394EmailQueueStatus, BC001J2_A395EmailQueueSentAt, BC001J2_n395EmailQueueSentAt, BC001J2_A396EmailQueueErrorMessage, BC001J2_n396EmailQueueErrorMessage, BC001J2_A381NotificationId,
               BC001J2_n381NotificationId
               }
               , new Object[] {
               BC001J3_A392EmailQueueId, BC001J3_A393EmailQueueRecipient, BC001J3_n393EmailQueueRecipient, BC001J3_A394EmailQueueStatus, BC001J3_n394EmailQueueStatus, BC001J3_A395EmailQueueSentAt, BC001J3_n395EmailQueueSentAt, BC001J3_A396EmailQueueErrorMessage, BC001J3_n396EmailQueueErrorMessage, BC001J3_A381NotificationId,
               BC001J3_n381NotificationId
               }
               , new Object[] {
               BC001J4_A381NotificationId
               }
               , new Object[] {
               BC001J5_A392EmailQueueId, BC001J5_A393EmailQueueRecipient, BC001J5_n393EmailQueueRecipient, BC001J5_A394EmailQueueStatus, BC001J5_n394EmailQueueStatus, BC001J5_A395EmailQueueSentAt, BC001J5_n395EmailQueueSentAt, BC001J5_A396EmailQueueErrorMessage, BC001J5_n396EmailQueueErrorMessage, BC001J5_A381NotificationId,
               BC001J5_n381NotificationId
               }
               , new Object[] {
               BC001J6_A392EmailQueueId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001J8_A392EmailQueueId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001J11_A392EmailQueueId, BC001J11_A393EmailQueueRecipient, BC001J11_n393EmailQueueRecipient, BC001J11_A394EmailQueueStatus, BC001J11_n394EmailQueueStatus, BC001J11_A395EmailQueueSentAt, BC001J11_n395EmailQueueSentAt, BC001J11_A396EmailQueueErrorMessage, BC001J11_n396EmailQueueErrorMessage, BC001J11_A381NotificationId,
               BC001J11_n381NotificationId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound58 ;
      private int trnEnded ;
      private int Z392EmailQueueId ;
      private int A392EmailQueueId ;
      private int Z381NotificationId ;
      private int A381NotificationId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode58 ;
      private DateTime Z395EmailQueueSentAt ;
      private DateTime A395EmailQueueSentAt ;
      private bool n393EmailQueueRecipient ;
      private bool n394EmailQueueStatus ;
      private bool n395EmailQueueSentAt ;
      private bool n396EmailQueueErrorMessage ;
      private bool n381NotificationId ;
      private string Z393EmailQueueRecipient ;
      private string A393EmailQueueRecipient ;
      private string Z394EmailQueueStatus ;
      private string A394EmailQueueStatus ;
      private string Z396EmailQueueErrorMessage ;
      private string A396EmailQueueErrorMessage ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001J5_A392EmailQueueId ;
      private string[] BC001J5_A393EmailQueueRecipient ;
      private bool[] BC001J5_n393EmailQueueRecipient ;
      private string[] BC001J5_A394EmailQueueStatus ;
      private bool[] BC001J5_n394EmailQueueStatus ;
      private DateTime[] BC001J5_A395EmailQueueSentAt ;
      private bool[] BC001J5_n395EmailQueueSentAt ;
      private string[] BC001J5_A396EmailQueueErrorMessage ;
      private bool[] BC001J5_n396EmailQueueErrorMessage ;
      private int[] BC001J5_A381NotificationId ;
      private bool[] BC001J5_n381NotificationId ;
      private int[] BC001J4_A381NotificationId ;
      private bool[] BC001J4_n381NotificationId ;
      private int[] BC001J6_A392EmailQueueId ;
      private int[] BC001J3_A392EmailQueueId ;
      private string[] BC001J3_A393EmailQueueRecipient ;
      private bool[] BC001J3_n393EmailQueueRecipient ;
      private string[] BC001J3_A394EmailQueueStatus ;
      private bool[] BC001J3_n394EmailQueueStatus ;
      private DateTime[] BC001J3_A395EmailQueueSentAt ;
      private bool[] BC001J3_n395EmailQueueSentAt ;
      private string[] BC001J3_A396EmailQueueErrorMessage ;
      private bool[] BC001J3_n396EmailQueueErrorMessage ;
      private int[] BC001J3_A381NotificationId ;
      private bool[] BC001J3_n381NotificationId ;
      private int[] BC001J2_A392EmailQueueId ;
      private string[] BC001J2_A393EmailQueueRecipient ;
      private bool[] BC001J2_n393EmailQueueRecipient ;
      private string[] BC001J2_A394EmailQueueStatus ;
      private bool[] BC001J2_n394EmailQueueStatus ;
      private DateTime[] BC001J2_A395EmailQueueSentAt ;
      private bool[] BC001J2_n395EmailQueueSentAt ;
      private string[] BC001J2_A396EmailQueueErrorMessage ;
      private bool[] BC001J2_n396EmailQueueErrorMessage ;
      private int[] BC001J2_A381NotificationId ;
      private bool[] BC001J2_n381NotificationId ;
      private int[] BC001J8_A392EmailQueueId ;
      private int[] BC001J11_A392EmailQueueId ;
      private string[] BC001J11_A393EmailQueueRecipient ;
      private bool[] BC001J11_n393EmailQueueRecipient ;
      private string[] BC001J11_A394EmailQueueStatus ;
      private bool[] BC001J11_n394EmailQueueStatus ;
      private DateTime[] BC001J11_A395EmailQueueSentAt ;
      private bool[] BC001J11_n395EmailQueueSentAt ;
      private string[] BC001J11_A396EmailQueueErrorMessage ;
      private bool[] BC001J11_n396EmailQueueErrorMessage ;
      private int[] BC001J11_A381NotificationId ;
      private bool[] BC001J11_n381NotificationId ;
      private SdtEmailQueue bcEmailQueue ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class emailqueue_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC001J2;
          prmBC001J2 = new Object[] {
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmBC001J3;
          prmBC001J3 = new Object[] {
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmBC001J4;
          prmBC001J4 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001J5;
          prmBC001J5 = new Object[] {
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmBC001J6;
          prmBC001J6 = new Object[] {
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmBC001J7;
          prmBC001J7 = new Object[] {
          new ParDef("EmailQueueRecipient",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmailQueueStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmailQueueSentAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("EmailQueueErrorMessage",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001J8;
          prmBC001J8 = new Object[] {
          };
          Object[] prmBC001J9;
          prmBC001J9 = new Object[] {
          new ParDef("EmailQueueRecipient",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("EmailQueueStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("EmailQueueSentAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("EmailQueueErrorMessage",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmBC001J10;
          prmBC001J10 = new Object[] {
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          Object[] prmBC001J11;
          prmBC001J11 = new Object[] {
          new ParDef("EmailQueueId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC001J2", "SELECT EmailQueueId, EmailQueueRecipient, EmailQueueStatus, EmailQueueSentAt, EmailQueueErrorMessage, NotificationId FROM EmailQueue WHERE EmailQueueId = :EmailQueueId  FOR UPDATE OF EmailQueue",true, GxErrorMask.GX_NOMASK, false, this,prmBC001J2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001J3", "SELECT EmailQueueId, EmailQueueRecipient, EmailQueueStatus, EmailQueueSentAt, EmailQueueErrorMessage, NotificationId FROM EmailQueue WHERE EmailQueueId = :EmailQueueId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001J3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001J4", "SELECT NotificationId FROM Notification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001J4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001J5", "SELECT TM1.EmailQueueId, TM1.EmailQueueRecipient, TM1.EmailQueueStatus, TM1.EmailQueueSentAt, TM1.EmailQueueErrorMessage, TM1.NotificationId FROM EmailQueue TM1 WHERE TM1.EmailQueueId = :EmailQueueId ORDER BY TM1.EmailQueueId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001J5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001J6", "SELECT EmailQueueId FROM EmailQueue WHERE EmailQueueId = :EmailQueueId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001J6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001J7", "SAVEPOINT gxupdate;INSERT INTO EmailQueue(EmailQueueRecipient, EmailQueueStatus, EmailQueueSentAt, EmailQueueErrorMessage, NotificationId) VALUES(:EmailQueueRecipient, :EmailQueueStatus, :EmailQueueSentAt, :EmailQueueErrorMessage, :NotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001J7)
             ,new CursorDef("BC001J8", "SELECT currval('EmailQueueId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001J8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001J9", "SAVEPOINT gxupdate;UPDATE EmailQueue SET EmailQueueRecipient=:EmailQueueRecipient, EmailQueueStatus=:EmailQueueStatus, EmailQueueSentAt=:EmailQueueSentAt, EmailQueueErrorMessage=:EmailQueueErrorMessage, NotificationId=:NotificationId  WHERE EmailQueueId = :EmailQueueId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001J9)
             ,new CursorDef("BC001J10", "SAVEPOINT gxupdate;DELETE FROM EmailQueue  WHERE EmailQueueId = :EmailQueueId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001J10)
             ,new CursorDef("BC001J11", "SELECT TM1.EmailQueueId, TM1.EmailQueueRecipient, TM1.EmailQueueStatus, TM1.EmailQueueSentAt, TM1.EmailQueueErrorMessage, TM1.NotificationId FROM EmailQueue TM1 WHERE TM1.EmailQueueId = :EmailQueueId ORDER BY TM1.EmailQueueId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001J11,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
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
