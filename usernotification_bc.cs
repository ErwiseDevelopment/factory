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
   public class usernotification_bc : GxSilentTrn, IGxSilentTrn
   {
      public usernotification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usernotification_bc( IGxContext context )
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
         ReadRow1I57( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1I57( ) ;
         standaloneModal( ) ;
         AddRow1I57( ) ;
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
               Z387UserNotificationId = A387UserNotificationId;
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

      protected void CONFIRM_1I0( )
      {
         BeforeValidate1I57( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1I57( ) ;
            }
            else
            {
               CheckExtendedTable1I57( ) ;
               if ( AnyError == 0 )
               {
                  ZM1I57( 3) ;
                  ZM1I57( 4) ;
               }
               CloseExtendedTableCursors1I57( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1I57( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z389UserNotificationStatus = A389UserNotificationStatus;
            Z390UserNotificationSentAt = A390UserNotificationSentAt;
            Z391UserNotificationReadAt = A391UserNotificationReadAt;
            Z381NotificationId = A381NotificationId;
            Z388UserNotificationUserId = A388UserNotificationUserId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -2 )
         {
            Z387UserNotificationId = A387UserNotificationId;
            Z389UserNotificationStatus = A389UserNotificationStatus;
            Z390UserNotificationSentAt = A390UserNotificationSentAt;
            Z391UserNotificationReadAt = A391UserNotificationReadAt;
            Z381NotificationId = A381NotificationId;
            Z388UserNotificationUserId = A388UserNotificationUserId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1I57( )
      {
         /* Using cursor BC001I6 */
         pr_default.execute(4, new Object[] {A387UserNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound57 = 1;
            A389UserNotificationStatus = BC001I6_A389UserNotificationStatus[0];
            n389UserNotificationStatus = BC001I6_n389UserNotificationStatus[0];
            A390UserNotificationSentAt = BC001I6_A390UserNotificationSentAt[0];
            n390UserNotificationSentAt = BC001I6_n390UserNotificationSentAt[0];
            A391UserNotificationReadAt = BC001I6_A391UserNotificationReadAt[0];
            n391UserNotificationReadAt = BC001I6_n391UserNotificationReadAt[0];
            A381NotificationId = BC001I6_A381NotificationId[0];
            n381NotificationId = BC001I6_n381NotificationId[0];
            A388UserNotificationUserId = BC001I6_A388UserNotificationUserId[0];
            n388UserNotificationUserId = BC001I6_n388UserNotificationUserId[0];
            ZM1I57( -2) ;
         }
         pr_default.close(4);
         OnLoadActions1I57( ) ;
      }

      protected void OnLoadActions1I57( )
      {
      }

      protected void CheckExtendedTable1I57( )
      {
         standaloneModal( ) ;
         /* Using cursor BC001I4 */
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
         /* Using cursor BC001I5 */
         pr_default.execute(3, new Object[] {n388UserNotificationUserId, A388UserNotificationUserId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A388UserNotificationUserId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb User Notification'.", "ForeignKeyNotFound", 1, "USERNOTIFICATIONUSERID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A389UserNotificationStatus, "Unread") == 0 ) || ( StringUtil.StrCmp(A389UserNotificationStatus, "Read") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A389UserNotificationStatus)) ) )
         {
            GX_msglist.addItem("Campo User Notification Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1I57( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1I57( )
      {
         /* Using cursor BC001I7 */
         pr_default.execute(5, new Object[] {A387UserNotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound57 = 1;
         }
         else
         {
            RcdFound57 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001I3 */
         pr_default.execute(1, new Object[] {A387UserNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1I57( 2) ;
            RcdFound57 = 1;
            A387UserNotificationId = BC001I3_A387UserNotificationId[0];
            A389UserNotificationStatus = BC001I3_A389UserNotificationStatus[0];
            n389UserNotificationStatus = BC001I3_n389UserNotificationStatus[0];
            A390UserNotificationSentAt = BC001I3_A390UserNotificationSentAt[0];
            n390UserNotificationSentAt = BC001I3_n390UserNotificationSentAt[0];
            A391UserNotificationReadAt = BC001I3_A391UserNotificationReadAt[0];
            n391UserNotificationReadAt = BC001I3_n391UserNotificationReadAt[0];
            A381NotificationId = BC001I3_A381NotificationId[0];
            n381NotificationId = BC001I3_n381NotificationId[0];
            A388UserNotificationUserId = BC001I3_A388UserNotificationUserId[0];
            n388UserNotificationUserId = BC001I3_n388UserNotificationUserId[0];
            Z387UserNotificationId = A387UserNotificationId;
            sMode57 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1I57( ) ;
            if ( AnyError == 1 )
            {
               RcdFound57 = 0;
               InitializeNonKey1I57( ) ;
            }
            Gx_mode = sMode57;
         }
         else
         {
            RcdFound57 = 0;
            InitializeNonKey1I57( ) ;
            sMode57 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode57;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1I57( ) ;
         if ( RcdFound57 == 0 )
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
         CONFIRM_1I0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1I57( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001I2 */
            pr_default.execute(0, new Object[] {A387UserNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z389UserNotificationStatus, BC001I2_A389UserNotificationStatus[0]) != 0 ) || ( Z390UserNotificationSentAt != BC001I2_A390UserNotificationSentAt[0] ) || ( Z391UserNotificationReadAt != BC001I2_A391UserNotificationReadAt[0] ) || ( Z381NotificationId != BC001I2_A381NotificationId[0] ) || ( Z388UserNotificationUserId != BC001I2_A388UserNotificationUserId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"UserNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1I57( )
      {
         BeforeValidate1I57( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1I57( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1I57( 0) ;
            CheckOptimisticConcurrency1I57( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1I57( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1I57( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001I8 */
                     pr_default.execute(6, new Object[] {n389UserNotificationStatus, A389UserNotificationStatus, n390UserNotificationSentAt, A390UserNotificationSentAt, n391UserNotificationReadAt, A391UserNotificationReadAt, n381NotificationId, A381NotificationId, n388UserNotificationUserId, A388UserNotificationUserId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001I9 */
                     pr_default.execute(7);
                     A387UserNotificationId = BC001I9_A387UserNotificationId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("UserNotification");
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
               Load1I57( ) ;
            }
            EndLevel1I57( ) ;
         }
         CloseExtendedTableCursors1I57( ) ;
      }

      protected void Update1I57( )
      {
         BeforeValidate1I57( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1I57( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1I57( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1I57( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1I57( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001I10 */
                     pr_default.execute(8, new Object[] {n389UserNotificationStatus, A389UserNotificationStatus, n390UserNotificationSentAt, A390UserNotificationSentAt, n391UserNotificationReadAt, A391UserNotificationReadAt, n381NotificationId, A381NotificationId, n388UserNotificationUserId, A388UserNotificationUserId, A387UserNotificationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("UserNotification");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1I57( ) ;
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
            EndLevel1I57( ) ;
         }
         CloseExtendedTableCursors1I57( ) ;
      }

      protected void DeferredUpdate1I57( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1I57( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1I57( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1I57( ) ;
            AfterConfirm1I57( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1I57( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001I11 */
                  pr_default.execute(9, new Object[] {A387UserNotificationId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("UserNotification");
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
         sMode57 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1I57( ) ;
         Gx_mode = sMode57;
      }

      protected void OnDeleteControls1I57( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1I57( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1I57( ) ;
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

      public void ScanKeyStart1I57( )
      {
         /* Using cursor BC001I12 */
         pr_default.execute(10, new Object[] {A387UserNotificationId});
         RcdFound57 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound57 = 1;
            A387UserNotificationId = BC001I12_A387UserNotificationId[0];
            A389UserNotificationStatus = BC001I12_A389UserNotificationStatus[0];
            n389UserNotificationStatus = BC001I12_n389UserNotificationStatus[0];
            A390UserNotificationSentAt = BC001I12_A390UserNotificationSentAt[0];
            n390UserNotificationSentAt = BC001I12_n390UserNotificationSentAt[0];
            A391UserNotificationReadAt = BC001I12_A391UserNotificationReadAt[0];
            n391UserNotificationReadAt = BC001I12_n391UserNotificationReadAt[0];
            A381NotificationId = BC001I12_A381NotificationId[0];
            n381NotificationId = BC001I12_n381NotificationId[0];
            A388UserNotificationUserId = BC001I12_A388UserNotificationUserId[0];
            n388UserNotificationUserId = BC001I12_n388UserNotificationUserId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1I57( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound57 = 0;
         ScanKeyLoad1I57( ) ;
      }

      protected void ScanKeyLoad1I57( )
      {
         sMode57 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound57 = 1;
            A387UserNotificationId = BC001I12_A387UserNotificationId[0];
            A389UserNotificationStatus = BC001I12_A389UserNotificationStatus[0];
            n389UserNotificationStatus = BC001I12_n389UserNotificationStatus[0];
            A390UserNotificationSentAt = BC001I12_A390UserNotificationSentAt[0];
            n390UserNotificationSentAt = BC001I12_n390UserNotificationSentAt[0];
            A391UserNotificationReadAt = BC001I12_A391UserNotificationReadAt[0];
            n391UserNotificationReadAt = BC001I12_n391UserNotificationReadAt[0];
            A381NotificationId = BC001I12_A381NotificationId[0];
            n381NotificationId = BC001I12_n381NotificationId[0];
            A388UserNotificationUserId = BC001I12_A388UserNotificationUserId[0];
            n388UserNotificationUserId = BC001I12_n388UserNotificationUserId[0];
         }
         Gx_mode = sMode57;
      }

      protected void ScanKeyEnd1I57( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1I57( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1I57( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1I57( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1I57( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1I57( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1I57( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1I57( )
      {
      }

      protected void send_integrity_lvl_hashes1I57( )
      {
      }

      protected void AddRow1I57( )
      {
         VarsToRow57( bcUserNotification) ;
      }

      protected void ReadRow1I57( )
      {
         RowToVars57( bcUserNotification, 1) ;
      }

      protected void InitializeNonKey1I57( )
      {
         A381NotificationId = 0;
         n381NotificationId = false;
         A388UserNotificationUserId = 0;
         n388UserNotificationUserId = false;
         A389UserNotificationStatus = "";
         n389UserNotificationStatus = false;
         A390UserNotificationSentAt = (DateTime)(DateTime.MinValue);
         n390UserNotificationSentAt = false;
         A391UserNotificationReadAt = (DateTime)(DateTime.MinValue);
         n391UserNotificationReadAt = false;
         Z389UserNotificationStatus = "";
         Z390UserNotificationSentAt = (DateTime)(DateTime.MinValue);
         Z391UserNotificationReadAt = (DateTime)(DateTime.MinValue);
         Z381NotificationId = 0;
         Z388UserNotificationUserId = 0;
      }

      protected void InitAll1I57( )
      {
         A387UserNotificationId = 0;
         InitializeNonKey1I57( ) ;
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

      public void VarsToRow57( SdtUserNotification obj57 )
      {
         obj57.gxTpr_Mode = Gx_mode;
         obj57.gxTpr_Notificationid = A381NotificationId;
         obj57.gxTpr_Usernotificationuserid = A388UserNotificationUserId;
         obj57.gxTpr_Usernotificationstatus = A389UserNotificationStatus;
         obj57.gxTpr_Usernotificationsentat = A390UserNotificationSentAt;
         obj57.gxTpr_Usernotificationreadat = A391UserNotificationReadAt;
         obj57.gxTpr_Usernotificationid = A387UserNotificationId;
         obj57.gxTpr_Usernotificationid_Z = Z387UserNotificationId;
         obj57.gxTpr_Notificationid_Z = Z381NotificationId;
         obj57.gxTpr_Usernotificationuserid_Z = Z388UserNotificationUserId;
         obj57.gxTpr_Usernotificationstatus_Z = Z389UserNotificationStatus;
         obj57.gxTpr_Usernotificationsentat_Z = Z390UserNotificationSentAt;
         obj57.gxTpr_Usernotificationreadat_Z = Z391UserNotificationReadAt;
         obj57.gxTpr_Notificationid_N = (short)(Convert.ToInt16(n381NotificationId));
         obj57.gxTpr_Usernotificationuserid_N = (short)(Convert.ToInt16(n388UserNotificationUserId));
         obj57.gxTpr_Usernotificationstatus_N = (short)(Convert.ToInt16(n389UserNotificationStatus));
         obj57.gxTpr_Usernotificationsentat_N = (short)(Convert.ToInt16(n390UserNotificationSentAt));
         obj57.gxTpr_Usernotificationreadat_N = (short)(Convert.ToInt16(n391UserNotificationReadAt));
         obj57.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow57( SdtUserNotification obj57 )
      {
         obj57.gxTpr_Usernotificationid = A387UserNotificationId;
         return  ;
      }

      public void RowToVars57( SdtUserNotification obj57 ,
                               int forceLoad )
      {
         Gx_mode = obj57.gxTpr_Mode;
         A381NotificationId = obj57.gxTpr_Notificationid;
         n381NotificationId = false;
         A388UserNotificationUserId = obj57.gxTpr_Usernotificationuserid;
         n388UserNotificationUserId = false;
         A389UserNotificationStatus = obj57.gxTpr_Usernotificationstatus;
         n389UserNotificationStatus = false;
         A390UserNotificationSentAt = obj57.gxTpr_Usernotificationsentat;
         n390UserNotificationSentAt = false;
         A391UserNotificationReadAt = obj57.gxTpr_Usernotificationreadat;
         n391UserNotificationReadAt = false;
         A387UserNotificationId = obj57.gxTpr_Usernotificationid;
         Z387UserNotificationId = obj57.gxTpr_Usernotificationid_Z;
         Z381NotificationId = obj57.gxTpr_Notificationid_Z;
         Z388UserNotificationUserId = obj57.gxTpr_Usernotificationuserid_Z;
         Z389UserNotificationStatus = obj57.gxTpr_Usernotificationstatus_Z;
         Z390UserNotificationSentAt = obj57.gxTpr_Usernotificationsentat_Z;
         Z391UserNotificationReadAt = obj57.gxTpr_Usernotificationreadat_Z;
         n381NotificationId = (bool)(Convert.ToBoolean(obj57.gxTpr_Notificationid_N));
         n388UserNotificationUserId = (bool)(Convert.ToBoolean(obj57.gxTpr_Usernotificationuserid_N));
         n389UserNotificationStatus = (bool)(Convert.ToBoolean(obj57.gxTpr_Usernotificationstatus_N));
         n390UserNotificationSentAt = (bool)(Convert.ToBoolean(obj57.gxTpr_Usernotificationsentat_N));
         n391UserNotificationReadAt = (bool)(Convert.ToBoolean(obj57.gxTpr_Usernotificationreadat_N));
         Gx_mode = obj57.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A387UserNotificationId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1I57( ) ;
         ScanKeyStart1I57( ) ;
         if ( RcdFound57 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z387UserNotificationId = A387UserNotificationId;
         }
         ZM1I57( -2) ;
         OnLoadActions1I57( ) ;
         AddRow1I57( ) ;
         ScanKeyEnd1I57( ) ;
         if ( RcdFound57 == 0 )
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
         RowToVars57( bcUserNotification, 0) ;
         ScanKeyStart1I57( ) ;
         if ( RcdFound57 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z387UserNotificationId = A387UserNotificationId;
         }
         ZM1I57( -2) ;
         OnLoadActions1I57( ) ;
         AddRow1I57( ) ;
         ScanKeyEnd1I57( ) ;
         if ( RcdFound57 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1I57( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1I57( ) ;
         }
         else
         {
            if ( RcdFound57 == 1 )
            {
               if ( A387UserNotificationId != Z387UserNotificationId )
               {
                  A387UserNotificationId = Z387UserNotificationId;
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
                  Update1I57( ) ;
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
                  if ( A387UserNotificationId != Z387UserNotificationId )
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
                        Insert1I57( ) ;
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
                        Insert1I57( ) ;
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
         RowToVars57( bcUserNotification, 1) ;
         SaveImpl( ) ;
         VarsToRow57( bcUserNotification) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars57( bcUserNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1I57( ) ;
         AfterTrn( ) ;
         VarsToRow57( bcUserNotification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow57( bcUserNotification) ;
         }
         else
         {
            SdtUserNotification auxBC = new SdtUserNotification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A387UserNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcUserNotification);
               auxBC.Save();
               bcUserNotification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars57( bcUserNotification, 1) ;
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
         RowToVars57( bcUserNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1I57( ) ;
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
               VarsToRow57( bcUserNotification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow57( bcUserNotification) ;
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
         RowToVars57( bcUserNotification, 0) ;
         GetKey1I57( ) ;
         if ( RcdFound57 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A387UserNotificationId != Z387UserNotificationId )
            {
               A387UserNotificationId = Z387UserNotificationId;
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
            if ( A387UserNotificationId != Z387UserNotificationId )
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
         context.RollbackDataStores("usernotification_bc",pr_default);
         VarsToRow57( bcUserNotification) ;
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
         Gx_mode = bcUserNotification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcUserNotification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcUserNotification )
         {
            bcUserNotification = (SdtUserNotification)(sdt);
            if ( StringUtil.StrCmp(bcUserNotification.gxTpr_Mode, "") == 0 )
            {
               bcUserNotification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow57( bcUserNotification) ;
            }
            else
            {
               RowToVars57( bcUserNotification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcUserNotification.gxTpr_Mode, "") == 0 )
            {
               bcUserNotification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars57( bcUserNotification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtUserNotification UserNotification_BC
      {
         get {
            return bcUserNotification ;
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
         Z389UserNotificationStatus = "";
         A389UserNotificationStatus = "";
         Z390UserNotificationSentAt = (DateTime)(DateTime.MinValue);
         A390UserNotificationSentAt = (DateTime)(DateTime.MinValue);
         Z391UserNotificationReadAt = (DateTime)(DateTime.MinValue);
         A391UserNotificationReadAt = (DateTime)(DateTime.MinValue);
         BC001I6_A387UserNotificationId = new int[1] ;
         BC001I6_A389UserNotificationStatus = new string[] {""} ;
         BC001I6_n389UserNotificationStatus = new bool[] {false} ;
         BC001I6_A390UserNotificationSentAt = new DateTime[] {DateTime.MinValue} ;
         BC001I6_n390UserNotificationSentAt = new bool[] {false} ;
         BC001I6_A391UserNotificationReadAt = new DateTime[] {DateTime.MinValue} ;
         BC001I6_n391UserNotificationReadAt = new bool[] {false} ;
         BC001I6_A381NotificationId = new int[1] ;
         BC001I6_n381NotificationId = new bool[] {false} ;
         BC001I6_A388UserNotificationUserId = new short[1] ;
         BC001I6_n388UserNotificationUserId = new bool[] {false} ;
         BC001I4_A381NotificationId = new int[1] ;
         BC001I4_n381NotificationId = new bool[] {false} ;
         BC001I5_A388UserNotificationUserId = new short[1] ;
         BC001I5_n388UserNotificationUserId = new bool[] {false} ;
         BC001I7_A387UserNotificationId = new int[1] ;
         BC001I3_A387UserNotificationId = new int[1] ;
         BC001I3_A389UserNotificationStatus = new string[] {""} ;
         BC001I3_n389UserNotificationStatus = new bool[] {false} ;
         BC001I3_A390UserNotificationSentAt = new DateTime[] {DateTime.MinValue} ;
         BC001I3_n390UserNotificationSentAt = new bool[] {false} ;
         BC001I3_A391UserNotificationReadAt = new DateTime[] {DateTime.MinValue} ;
         BC001I3_n391UserNotificationReadAt = new bool[] {false} ;
         BC001I3_A381NotificationId = new int[1] ;
         BC001I3_n381NotificationId = new bool[] {false} ;
         BC001I3_A388UserNotificationUserId = new short[1] ;
         BC001I3_n388UserNotificationUserId = new bool[] {false} ;
         sMode57 = "";
         BC001I2_A387UserNotificationId = new int[1] ;
         BC001I2_A389UserNotificationStatus = new string[] {""} ;
         BC001I2_n389UserNotificationStatus = new bool[] {false} ;
         BC001I2_A390UserNotificationSentAt = new DateTime[] {DateTime.MinValue} ;
         BC001I2_n390UserNotificationSentAt = new bool[] {false} ;
         BC001I2_A391UserNotificationReadAt = new DateTime[] {DateTime.MinValue} ;
         BC001I2_n391UserNotificationReadAt = new bool[] {false} ;
         BC001I2_A381NotificationId = new int[1] ;
         BC001I2_n381NotificationId = new bool[] {false} ;
         BC001I2_A388UserNotificationUserId = new short[1] ;
         BC001I2_n388UserNotificationUserId = new bool[] {false} ;
         BC001I9_A387UserNotificationId = new int[1] ;
         BC001I12_A387UserNotificationId = new int[1] ;
         BC001I12_A389UserNotificationStatus = new string[] {""} ;
         BC001I12_n389UserNotificationStatus = new bool[] {false} ;
         BC001I12_A390UserNotificationSentAt = new DateTime[] {DateTime.MinValue} ;
         BC001I12_n390UserNotificationSentAt = new bool[] {false} ;
         BC001I12_A391UserNotificationReadAt = new DateTime[] {DateTime.MinValue} ;
         BC001I12_n391UserNotificationReadAt = new bool[] {false} ;
         BC001I12_A381NotificationId = new int[1] ;
         BC001I12_n381NotificationId = new bool[] {false} ;
         BC001I12_A388UserNotificationUserId = new short[1] ;
         BC001I12_n388UserNotificationUserId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usernotification_bc__default(),
            new Object[][] {
                new Object[] {
               BC001I2_A387UserNotificationId, BC001I2_A389UserNotificationStatus, BC001I2_n389UserNotificationStatus, BC001I2_A390UserNotificationSentAt, BC001I2_n390UserNotificationSentAt, BC001I2_A391UserNotificationReadAt, BC001I2_n391UserNotificationReadAt, BC001I2_A381NotificationId, BC001I2_n381NotificationId, BC001I2_A388UserNotificationUserId,
               BC001I2_n388UserNotificationUserId
               }
               , new Object[] {
               BC001I3_A387UserNotificationId, BC001I3_A389UserNotificationStatus, BC001I3_n389UserNotificationStatus, BC001I3_A390UserNotificationSentAt, BC001I3_n390UserNotificationSentAt, BC001I3_A391UserNotificationReadAt, BC001I3_n391UserNotificationReadAt, BC001I3_A381NotificationId, BC001I3_n381NotificationId, BC001I3_A388UserNotificationUserId,
               BC001I3_n388UserNotificationUserId
               }
               , new Object[] {
               BC001I4_A381NotificationId
               }
               , new Object[] {
               BC001I5_A388UserNotificationUserId
               }
               , new Object[] {
               BC001I6_A387UserNotificationId, BC001I6_A389UserNotificationStatus, BC001I6_n389UserNotificationStatus, BC001I6_A390UserNotificationSentAt, BC001I6_n390UserNotificationSentAt, BC001I6_A391UserNotificationReadAt, BC001I6_n391UserNotificationReadAt, BC001I6_A381NotificationId, BC001I6_n381NotificationId, BC001I6_A388UserNotificationUserId,
               BC001I6_n388UserNotificationUserId
               }
               , new Object[] {
               BC001I7_A387UserNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001I9_A387UserNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001I12_A387UserNotificationId, BC001I12_A389UserNotificationStatus, BC001I12_n389UserNotificationStatus, BC001I12_A390UserNotificationSentAt, BC001I12_n390UserNotificationSentAt, BC001I12_A391UserNotificationReadAt, BC001I12_n391UserNotificationReadAt, BC001I12_A381NotificationId, BC001I12_n381NotificationId, BC001I12_A388UserNotificationUserId,
               BC001I12_n388UserNotificationUserId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z388UserNotificationUserId ;
      private short A388UserNotificationUserId ;
      private short RcdFound57 ;
      private int trnEnded ;
      private int Z387UserNotificationId ;
      private int A387UserNotificationId ;
      private int Z381NotificationId ;
      private int A381NotificationId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode57 ;
      private DateTime Z390UserNotificationSentAt ;
      private DateTime A390UserNotificationSentAt ;
      private DateTime Z391UserNotificationReadAt ;
      private DateTime A391UserNotificationReadAt ;
      private bool n389UserNotificationStatus ;
      private bool n390UserNotificationSentAt ;
      private bool n391UserNotificationReadAt ;
      private bool n381NotificationId ;
      private bool n388UserNotificationUserId ;
      private string Z389UserNotificationStatus ;
      private string A389UserNotificationStatus ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001I6_A387UserNotificationId ;
      private string[] BC001I6_A389UserNotificationStatus ;
      private bool[] BC001I6_n389UserNotificationStatus ;
      private DateTime[] BC001I6_A390UserNotificationSentAt ;
      private bool[] BC001I6_n390UserNotificationSentAt ;
      private DateTime[] BC001I6_A391UserNotificationReadAt ;
      private bool[] BC001I6_n391UserNotificationReadAt ;
      private int[] BC001I6_A381NotificationId ;
      private bool[] BC001I6_n381NotificationId ;
      private short[] BC001I6_A388UserNotificationUserId ;
      private bool[] BC001I6_n388UserNotificationUserId ;
      private int[] BC001I4_A381NotificationId ;
      private bool[] BC001I4_n381NotificationId ;
      private short[] BC001I5_A388UserNotificationUserId ;
      private bool[] BC001I5_n388UserNotificationUserId ;
      private int[] BC001I7_A387UserNotificationId ;
      private int[] BC001I3_A387UserNotificationId ;
      private string[] BC001I3_A389UserNotificationStatus ;
      private bool[] BC001I3_n389UserNotificationStatus ;
      private DateTime[] BC001I3_A390UserNotificationSentAt ;
      private bool[] BC001I3_n390UserNotificationSentAt ;
      private DateTime[] BC001I3_A391UserNotificationReadAt ;
      private bool[] BC001I3_n391UserNotificationReadAt ;
      private int[] BC001I3_A381NotificationId ;
      private bool[] BC001I3_n381NotificationId ;
      private short[] BC001I3_A388UserNotificationUserId ;
      private bool[] BC001I3_n388UserNotificationUserId ;
      private int[] BC001I2_A387UserNotificationId ;
      private string[] BC001I2_A389UserNotificationStatus ;
      private bool[] BC001I2_n389UserNotificationStatus ;
      private DateTime[] BC001I2_A390UserNotificationSentAt ;
      private bool[] BC001I2_n390UserNotificationSentAt ;
      private DateTime[] BC001I2_A391UserNotificationReadAt ;
      private bool[] BC001I2_n391UserNotificationReadAt ;
      private int[] BC001I2_A381NotificationId ;
      private bool[] BC001I2_n381NotificationId ;
      private short[] BC001I2_A388UserNotificationUserId ;
      private bool[] BC001I2_n388UserNotificationUserId ;
      private int[] BC001I9_A387UserNotificationId ;
      private int[] BC001I12_A387UserNotificationId ;
      private string[] BC001I12_A389UserNotificationStatus ;
      private bool[] BC001I12_n389UserNotificationStatus ;
      private DateTime[] BC001I12_A390UserNotificationSentAt ;
      private bool[] BC001I12_n390UserNotificationSentAt ;
      private DateTime[] BC001I12_A391UserNotificationReadAt ;
      private bool[] BC001I12_n391UserNotificationReadAt ;
      private int[] BC001I12_A381NotificationId ;
      private bool[] BC001I12_n381NotificationId ;
      private short[] BC001I12_A388UserNotificationUserId ;
      private bool[] BC001I12_n388UserNotificationUserId ;
      private SdtUserNotification bcUserNotification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class usernotification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001I2;
          prmBC001I2 = new Object[] {
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmBC001I3;
          prmBC001I3 = new Object[] {
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmBC001I4;
          prmBC001I4 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001I5;
          prmBC001I5 = new Object[] {
          new ParDef("UserNotificationUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001I6;
          prmBC001I6 = new Object[] {
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmBC001I7;
          prmBC001I7 = new Object[] {
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmBC001I8;
          prmBC001I8 = new Object[] {
          new ParDef("UserNotificationStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("UserNotificationSentAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("UserNotificationReadAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("UserNotificationUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001I9;
          prmBC001I9 = new Object[] {
          };
          Object[] prmBC001I10;
          prmBC001I10 = new Object[] {
          new ParDef("UserNotificationStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("UserNotificationSentAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("UserNotificationReadAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("UserNotificationUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmBC001I11;
          prmBC001I11 = new Object[] {
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          Object[] prmBC001I12;
          prmBC001I12 = new Object[] {
          new ParDef("UserNotificationId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC001I2", "SELECT UserNotificationId, UserNotificationStatus, UserNotificationSentAt, UserNotificationReadAt, NotificationId, UserNotificationUserId FROM UserNotification WHERE UserNotificationId = :UserNotificationId  FOR UPDATE OF UserNotification",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001I3", "SELECT UserNotificationId, UserNotificationStatus, UserNotificationSentAt, UserNotificationReadAt, NotificationId, UserNotificationUserId FROM UserNotification WHERE UserNotificationId = :UserNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001I4", "SELECT NotificationId FROM Notification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001I5", "SELECT SecUserId AS UserNotificationUserId FROM SecUser WHERE SecUserId = :UserNotificationUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001I6", "SELECT TM1.UserNotificationId, TM1.UserNotificationStatus, TM1.UserNotificationSentAt, TM1.UserNotificationReadAt, TM1.NotificationId, TM1.UserNotificationUserId AS UserNotificationUserId FROM UserNotification TM1 WHERE TM1.UserNotificationId = :UserNotificationId ORDER BY TM1.UserNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001I7", "SELECT UserNotificationId FROM UserNotification WHERE UserNotificationId = :UserNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001I8", "SAVEPOINT gxupdate;INSERT INTO UserNotification(UserNotificationStatus, UserNotificationSentAt, UserNotificationReadAt, NotificationId, UserNotificationUserId) VALUES(:UserNotificationStatus, :UserNotificationSentAt, :UserNotificationReadAt, :NotificationId, :UserNotificationUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001I8)
             ,new CursorDef("BC001I9", "SELECT currval('UserNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001I10", "SAVEPOINT gxupdate;UPDATE UserNotification SET UserNotificationStatus=:UserNotificationStatus, UserNotificationSentAt=:UserNotificationSentAt, UserNotificationReadAt=:UserNotificationReadAt, NotificationId=:NotificationId, UserNotificationUserId=:UserNotificationUserId  WHERE UserNotificationId = :UserNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001I10)
             ,new CursorDef("BC001I11", "SAVEPOINT gxupdate;DELETE FROM UserNotification  WHERE UserNotificationId = :UserNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001I11)
             ,new CursorDef("BC001I12", "SELECT TM1.UserNotificationId, TM1.UserNotificationStatus, TM1.UserNotificationSentAt, TM1.UserNotificationReadAt, TM1.NotificationId, TM1.UserNotificationUserId AS UserNotificationUserId FROM UserNotification TM1 WHERE TM1.UserNotificationId = :UserNotificationId ORDER BY TM1.UserNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001I12,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((short[]) buf[9])[0] = rslt.getShort(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
