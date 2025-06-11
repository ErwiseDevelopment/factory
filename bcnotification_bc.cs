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
   public class bcnotification_bc : GxSilentTrn, IGxSilentTrn
   {
      public bcnotification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public bcnotification_bc( IGxContext context )
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
         ReadRow1H56( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1H56( ) ;
         standaloneModal( ) ;
         AddRow1H56( ) ;
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
               Z381NotificationId = A381NotificationId;
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

      protected void CONFIRM_1H0( )
      {
         BeforeValidate1H56( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1H56( ) ;
            }
            else
            {
               CheckExtendedTable1H56( ) ;
               if ( AnyError == 0 )
               {
                  ZM1H56( 6) ;
               }
               CloseExtendedTableCursors1H56( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void ZM1H56( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z382NotificationTitle = A382NotificationTitle;
            Z383NotificationMessage = A383NotificationMessage;
            Z384NotificationType = A384NotificationType;
            Z385NotificationCreatedAt = A385NotificationCreatedAt;
            Z386NotificationStatus = A386NotificationStatus;
            Z397NotificationLink = A397NotificationLink;
            Z133SecUserId = A133SecUserId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -5 )
         {
            Z381NotificationId = A381NotificationId;
            Z382NotificationTitle = A382NotificationTitle;
            Z383NotificationMessage = A383NotificationMessage;
            Z384NotificationType = A384NotificationType;
            Z385NotificationCreatedAt = A385NotificationCreatedAt;
            Z386NotificationStatus = A386NotificationStatus;
            Z397NotificationLink = A397NotificationLink;
            Z133SecUserId = A133SecUserId;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1H56( )
      {
         /* Using cursor BC001H5 */
         pr_default.execute(3, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound56 = 1;
            A382NotificationTitle = BC001H5_A382NotificationTitle[0];
            n382NotificationTitle = BC001H5_n382NotificationTitle[0];
            A383NotificationMessage = BC001H5_A383NotificationMessage[0];
            n383NotificationMessage = BC001H5_n383NotificationMessage[0];
            A384NotificationType = BC001H5_A384NotificationType[0];
            n384NotificationType = BC001H5_n384NotificationType[0];
            A385NotificationCreatedAt = BC001H5_A385NotificationCreatedAt[0];
            n385NotificationCreatedAt = BC001H5_n385NotificationCreatedAt[0];
            A386NotificationStatus = BC001H5_A386NotificationStatus[0];
            n386NotificationStatus = BC001H5_n386NotificationStatus[0];
            A397NotificationLink = BC001H5_A397NotificationLink[0];
            n397NotificationLink = BC001H5_n397NotificationLink[0];
            A133SecUserId = BC001H5_A133SecUserId[0];
            n133SecUserId = BC001H5_n133SecUserId[0];
            ZM1H56( -5) ;
         }
         pr_default.close(3);
         OnLoadActions1H56( ) ;
      }

      protected void OnLoadActions1H56( )
      {
         if ( (0==A133SecUserId) )
         {
            A133SecUserId = 0;
            n133SecUserId = false;
            n133SecUserId = true;
            n133SecUserId = true;
         }
      }

      protected void CheckExtendedTable1H56( )
      {
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A384NotificationType, "Internal") == 0 ) || ( StringUtil.StrCmp(A384NotificationType, "Email") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A384NotificationType)) ) )
         {
            GX_msglist.addItem("Campo Notification Type fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A386NotificationStatus, "Pending") == 0 ) || ( StringUtil.StrCmp(A386NotificationStatus, "Sent") == 0 ) || ( StringUtil.StrCmp(A386NotificationStatus, "Read") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A386NotificationStatus)) ) )
         {
            GX_msglist.addItem("Campo Notification Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (0==A133SecUserId) )
         {
            A133SecUserId = 0;
            n133SecUserId = false;
            n133SecUserId = true;
            n133SecUserId = true;
         }
         /* Using cursor BC001H4 */
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
         if ( ! ( GxRegex.IsMatch(A397NotificationLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") || String.IsNullOrEmpty(StringUtil.RTrim( A397NotificationLink)) ) )
         {
            GX_msglist.addItem("O valor de Notification Link não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1H56( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1H56( )
      {
         /* Using cursor BC001H6 */
         pr_default.execute(4, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound56 = 1;
         }
         else
         {
            RcdFound56 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC001H3 */
         pr_default.execute(1, new Object[] {n381NotificationId, A381NotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1H56( 5) ;
            RcdFound56 = 1;
            A381NotificationId = BC001H3_A381NotificationId[0];
            n381NotificationId = BC001H3_n381NotificationId[0];
            A382NotificationTitle = BC001H3_A382NotificationTitle[0];
            n382NotificationTitle = BC001H3_n382NotificationTitle[0];
            A383NotificationMessage = BC001H3_A383NotificationMessage[0];
            n383NotificationMessage = BC001H3_n383NotificationMessage[0];
            A384NotificationType = BC001H3_A384NotificationType[0];
            n384NotificationType = BC001H3_n384NotificationType[0];
            A385NotificationCreatedAt = BC001H3_A385NotificationCreatedAt[0];
            n385NotificationCreatedAt = BC001H3_n385NotificationCreatedAt[0];
            A386NotificationStatus = BC001H3_A386NotificationStatus[0];
            n386NotificationStatus = BC001H3_n386NotificationStatus[0];
            A397NotificationLink = BC001H3_A397NotificationLink[0];
            n397NotificationLink = BC001H3_n397NotificationLink[0];
            A133SecUserId = BC001H3_A133SecUserId[0];
            n133SecUserId = BC001H3_n133SecUserId[0];
            Z381NotificationId = A381NotificationId;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1H56( ) ;
            if ( AnyError == 1 )
            {
               RcdFound56 = 0;
               InitializeNonKey1H56( ) ;
            }
            Gx_mode = sMode56;
         }
         else
         {
            RcdFound56 = 0;
            InitializeNonKey1H56( ) ;
            sMode56 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode56;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1H56( ) ;
         if ( RcdFound56 == 0 )
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
         CONFIRM_1H0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1H56( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC001H2 */
            pr_default.execute(0, new Object[] {n381NotificationId, A381NotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Notification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z382NotificationTitle, BC001H2_A382NotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z383NotificationMessage, BC001H2_A383NotificationMessage[0]) != 0 ) || ( StringUtil.StrCmp(Z384NotificationType, BC001H2_A384NotificationType[0]) != 0 ) || ( Z385NotificationCreatedAt != BC001H2_A385NotificationCreatedAt[0] ) || ( StringUtil.StrCmp(Z386NotificationStatus, BC001H2_A386NotificationStatus[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z397NotificationLink, BC001H2_A397NotificationLink[0]) != 0 ) || ( Z133SecUserId != BC001H2_A133SecUserId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Notification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1H56( )
      {
         BeforeValidate1H56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H56( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1H56( 0) ;
            CheckOptimisticConcurrency1H56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1H56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001H7 */
                     pr_default.execute(5, new Object[] {n382NotificationTitle, A382NotificationTitle, n383NotificationMessage, A383NotificationMessage, n384NotificationType, A384NotificationType, n385NotificationCreatedAt, A385NotificationCreatedAt, n386NotificationStatus, A386NotificationStatus, n397NotificationLink, A397NotificationLink, n133SecUserId, A133SecUserId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001H8 */
                     pr_default.execute(6);
                     A381NotificationId = BC001H8_A381NotificationId[0];
                     n381NotificationId = BC001H8_n381NotificationId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Notification");
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
               Load1H56( ) ;
            }
            EndLevel1H56( ) ;
         }
         CloseExtendedTableCursors1H56( ) ;
      }

      protected void Update1H56( )
      {
         BeforeValidate1H56( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H56( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H56( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H56( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1H56( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001H9 */
                     pr_default.execute(7, new Object[] {n382NotificationTitle, A382NotificationTitle, n383NotificationMessage, A383NotificationMessage, n384NotificationType, A384NotificationType, n385NotificationCreatedAt, A385NotificationCreatedAt, n386NotificationStatus, A386NotificationStatus, n397NotificationLink, A397NotificationLink, n133SecUserId, A133SecUserId, n381NotificationId, A381NotificationId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Notification");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Notification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1H56( ) ;
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
            EndLevel1H56( ) ;
         }
         CloseExtendedTableCursors1H56( ) ;
      }

      protected void DeferredUpdate1H56( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1H56( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H56( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1H56( ) ;
            AfterConfirm1H56( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1H56( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001H10 */
                  pr_default.execute(8, new Object[] {n381NotificationId, A381NotificationId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Notification");
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
         sMode56 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1H56( ) ;
         Gx_mode = sMode56;
      }

      protected void OnDeleteControls1H56( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001H11 */
            pr_default.execute(9, new Object[] {n381NotificationId, A381NotificationId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"EmailQueue"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC001H12 */
            pr_default.execute(10, new Object[] {n381NotificationId, A381NotificationId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"UserNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel1H56( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1H56( ) ;
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

      public void ScanKeyStart1H56( )
      {
         /* Using cursor BC001H13 */
         pr_default.execute(11, new Object[] {n381NotificationId, A381NotificationId});
         RcdFound56 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound56 = 1;
            A381NotificationId = BC001H13_A381NotificationId[0];
            n381NotificationId = BC001H13_n381NotificationId[0];
            A382NotificationTitle = BC001H13_A382NotificationTitle[0];
            n382NotificationTitle = BC001H13_n382NotificationTitle[0];
            A383NotificationMessage = BC001H13_A383NotificationMessage[0];
            n383NotificationMessage = BC001H13_n383NotificationMessage[0];
            A384NotificationType = BC001H13_A384NotificationType[0];
            n384NotificationType = BC001H13_n384NotificationType[0];
            A385NotificationCreatedAt = BC001H13_A385NotificationCreatedAt[0];
            n385NotificationCreatedAt = BC001H13_n385NotificationCreatedAt[0];
            A386NotificationStatus = BC001H13_A386NotificationStatus[0];
            n386NotificationStatus = BC001H13_n386NotificationStatus[0];
            A397NotificationLink = BC001H13_A397NotificationLink[0];
            n397NotificationLink = BC001H13_n397NotificationLink[0];
            A133SecUserId = BC001H13_A133SecUserId[0];
            n133SecUserId = BC001H13_n133SecUserId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1H56( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound56 = 0;
         ScanKeyLoad1H56( ) ;
      }

      protected void ScanKeyLoad1H56( )
      {
         sMode56 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound56 = 1;
            A381NotificationId = BC001H13_A381NotificationId[0];
            n381NotificationId = BC001H13_n381NotificationId[0];
            A382NotificationTitle = BC001H13_A382NotificationTitle[0];
            n382NotificationTitle = BC001H13_n382NotificationTitle[0];
            A383NotificationMessage = BC001H13_A383NotificationMessage[0];
            n383NotificationMessage = BC001H13_n383NotificationMessage[0];
            A384NotificationType = BC001H13_A384NotificationType[0];
            n384NotificationType = BC001H13_n384NotificationType[0];
            A385NotificationCreatedAt = BC001H13_A385NotificationCreatedAt[0];
            n385NotificationCreatedAt = BC001H13_n385NotificationCreatedAt[0];
            A386NotificationStatus = BC001H13_A386NotificationStatus[0];
            n386NotificationStatus = BC001H13_n386NotificationStatus[0];
            A397NotificationLink = BC001H13_A397NotificationLink[0];
            n397NotificationLink = BC001H13_n397NotificationLink[0];
            A133SecUserId = BC001H13_A133SecUserId[0];
            n133SecUserId = BC001H13_n133SecUserId[0];
         }
         Gx_mode = sMode56;
      }

      protected void ScanKeyEnd1H56( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1H56( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1H56( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1H56( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1H56( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1H56( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1H56( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1H56( )
      {
      }

      protected void send_integrity_lvl_hashes1H56( )
      {
      }

      protected void AddRow1H56( )
      {
         VarsToRow56( bcBCNotification) ;
      }

      protected void ReadRow1H56( )
      {
         RowToVars56( bcBCNotification, 1) ;
      }

      protected void InitializeNonKey1H56( )
      {
         A382NotificationTitle = "";
         n382NotificationTitle = false;
         A383NotificationMessage = "";
         n383NotificationMessage = false;
         A384NotificationType = "";
         n384NotificationType = false;
         A385NotificationCreatedAt = (DateTime)(DateTime.MinValue);
         n385NotificationCreatedAt = false;
         A386NotificationStatus = "";
         n386NotificationStatus = false;
         A133SecUserId = 0;
         n133SecUserId = false;
         A397NotificationLink = "";
         n397NotificationLink = false;
         Z382NotificationTitle = "";
         Z383NotificationMessage = "";
         Z384NotificationType = "";
         Z385NotificationCreatedAt = (DateTime)(DateTime.MinValue);
         Z386NotificationStatus = "";
         Z397NotificationLink = "";
         Z133SecUserId = 0;
      }

      protected void InitAll1H56( )
      {
         A381NotificationId = 0;
         n381NotificationId = false;
         InitializeNonKey1H56( ) ;
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

      public void VarsToRow56( SdtBCNotification obj56 )
      {
         obj56.gxTpr_Mode = Gx_mode;
         obj56.gxTpr_Notificationtitle = A382NotificationTitle;
         obj56.gxTpr_Notificationmessage = A383NotificationMessage;
         obj56.gxTpr_Notificationtype = A384NotificationType;
         obj56.gxTpr_Notificationcreatedat = A385NotificationCreatedAt;
         obj56.gxTpr_Notificationstatus = A386NotificationStatus;
         obj56.gxTpr_Secuserid = A133SecUserId;
         obj56.gxTpr_Notificationlink = A397NotificationLink;
         obj56.gxTpr_Notificationid = A381NotificationId;
         obj56.gxTpr_Notificationid_Z = Z381NotificationId;
         obj56.gxTpr_Notificationtitle_Z = Z382NotificationTitle;
         obj56.gxTpr_Notificationmessage_Z = Z383NotificationMessage;
         obj56.gxTpr_Notificationtype_Z = Z384NotificationType;
         obj56.gxTpr_Notificationcreatedat_Z = Z385NotificationCreatedAt;
         obj56.gxTpr_Notificationstatus_Z = Z386NotificationStatus;
         obj56.gxTpr_Secuserid_Z = Z133SecUserId;
         obj56.gxTpr_Notificationlink_Z = Z397NotificationLink;
         obj56.gxTpr_Notificationid_N = (short)(Convert.ToInt16(n381NotificationId));
         obj56.gxTpr_Notificationtitle_N = (short)(Convert.ToInt16(n382NotificationTitle));
         obj56.gxTpr_Notificationmessage_N = (short)(Convert.ToInt16(n383NotificationMessage));
         obj56.gxTpr_Notificationtype_N = (short)(Convert.ToInt16(n384NotificationType));
         obj56.gxTpr_Notificationcreatedat_N = (short)(Convert.ToInt16(n385NotificationCreatedAt));
         obj56.gxTpr_Notificationstatus_N = (short)(Convert.ToInt16(n386NotificationStatus));
         obj56.gxTpr_Secuserid_N = (short)(Convert.ToInt16(n133SecUserId));
         obj56.gxTpr_Notificationlink_N = (short)(Convert.ToInt16(n397NotificationLink));
         obj56.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow56( SdtBCNotification obj56 )
      {
         obj56.gxTpr_Notificationid = A381NotificationId;
         return  ;
      }

      public void RowToVars56( SdtBCNotification obj56 ,
                               int forceLoad )
      {
         Gx_mode = obj56.gxTpr_Mode;
         A382NotificationTitle = obj56.gxTpr_Notificationtitle;
         n382NotificationTitle = false;
         A383NotificationMessage = obj56.gxTpr_Notificationmessage;
         n383NotificationMessage = false;
         A384NotificationType = obj56.gxTpr_Notificationtype;
         n384NotificationType = false;
         A385NotificationCreatedAt = obj56.gxTpr_Notificationcreatedat;
         n385NotificationCreatedAt = false;
         A386NotificationStatus = obj56.gxTpr_Notificationstatus;
         n386NotificationStatus = false;
         A133SecUserId = obj56.gxTpr_Secuserid;
         n133SecUserId = false;
         A397NotificationLink = obj56.gxTpr_Notificationlink;
         n397NotificationLink = false;
         A381NotificationId = obj56.gxTpr_Notificationid;
         n381NotificationId = false;
         Z381NotificationId = obj56.gxTpr_Notificationid_Z;
         Z382NotificationTitle = obj56.gxTpr_Notificationtitle_Z;
         Z383NotificationMessage = obj56.gxTpr_Notificationmessage_Z;
         Z384NotificationType = obj56.gxTpr_Notificationtype_Z;
         Z385NotificationCreatedAt = obj56.gxTpr_Notificationcreatedat_Z;
         Z386NotificationStatus = obj56.gxTpr_Notificationstatus_Z;
         Z133SecUserId = obj56.gxTpr_Secuserid_Z;
         Z397NotificationLink = obj56.gxTpr_Notificationlink_Z;
         n381NotificationId = (bool)(Convert.ToBoolean(obj56.gxTpr_Notificationid_N));
         n382NotificationTitle = (bool)(Convert.ToBoolean(obj56.gxTpr_Notificationtitle_N));
         n383NotificationMessage = (bool)(Convert.ToBoolean(obj56.gxTpr_Notificationmessage_N));
         n384NotificationType = (bool)(Convert.ToBoolean(obj56.gxTpr_Notificationtype_N));
         n385NotificationCreatedAt = (bool)(Convert.ToBoolean(obj56.gxTpr_Notificationcreatedat_N));
         n386NotificationStatus = (bool)(Convert.ToBoolean(obj56.gxTpr_Notificationstatus_N));
         n133SecUserId = (bool)(Convert.ToBoolean(obj56.gxTpr_Secuserid_N));
         n397NotificationLink = (bool)(Convert.ToBoolean(obj56.gxTpr_Notificationlink_N));
         Gx_mode = obj56.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A381NotificationId = (int)getParm(obj,0);
         n381NotificationId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1H56( ) ;
         ScanKeyStart1H56( ) ;
         if ( RcdFound56 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z381NotificationId = A381NotificationId;
         }
         ZM1H56( -5) ;
         OnLoadActions1H56( ) ;
         AddRow1H56( ) ;
         ScanKeyEnd1H56( ) ;
         if ( RcdFound56 == 0 )
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
         RowToVars56( bcBCNotification, 0) ;
         ScanKeyStart1H56( ) ;
         if ( RcdFound56 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z381NotificationId = A381NotificationId;
         }
         ZM1H56( -5) ;
         OnLoadActions1H56( ) ;
         AddRow1H56( ) ;
         ScanKeyEnd1H56( ) ;
         if ( RcdFound56 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1H56( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1H56( ) ;
         }
         else
         {
            if ( RcdFound56 == 1 )
            {
               if ( A381NotificationId != Z381NotificationId )
               {
                  A381NotificationId = Z381NotificationId;
                  n381NotificationId = false;
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
                  Update1H56( ) ;
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
                  if ( A381NotificationId != Z381NotificationId )
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
                        Insert1H56( ) ;
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
                        Insert1H56( ) ;
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
         RowToVars56( bcBCNotification, 1) ;
         SaveImpl( ) ;
         VarsToRow56( bcBCNotification) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars56( bcBCNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1H56( ) ;
         AfterTrn( ) ;
         VarsToRow56( bcBCNotification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow56( bcBCNotification) ;
         }
         else
         {
            SdtBCNotification auxBC = new SdtBCNotification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A381NotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcBCNotification);
               auxBC.Save();
               bcBCNotification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars56( bcBCNotification, 1) ;
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
         RowToVars56( bcBCNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1H56( ) ;
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
               VarsToRow56( bcBCNotification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow56( bcBCNotification) ;
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
         RowToVars56( bcBCNotification, 0) ;
         GetKey1H56( ) ;
         if ( RcdFound56 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A381NotificationId != Z381NotificationId )
            {
               A381NotificationId = Z381NotificationId;
               n381NotificationId = false;
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
            if ( A381NotificationId != Z381NotificationId )
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
         context.RollbackDataStores("bcnotification_bc",pr_default);
         VarsToRow56( bcBCNotification) ;
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
         Gx_mode = bcBCNotification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcBCNotification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcBCNotification )
         {
            bcBCNotification = (SdtBCNotification)(sdt);
            if ( StringUtil.StrCmp(bcBCNotification.gxTpr_Mode, "") == 0 )
            {
               bcBCNotification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow56( bcBCNotification) ;
            }
            else
            {
               RowToVars56( bcBCNotification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcBCNotification.gxTpr_Mode, "") == 0 )
            {
               bcBCNotification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars56( bcBCNotification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtBCNotification BCNotification_BC
      {
         get {
            return bcBCNotification ;
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
         Z382NotificationTitle = "";
         A382NotificationTitle = "";
         Z383NotificationMessage = "";
         A383NotificationMessage = "";
         Z384NotificationType = "";
         A384NotificationType = "";
         Z385NotificationCreatedAt = (DateTime)(DateTime.MinValue);
         A385NotificationCreatedAt = (DateTime)(DateTime.MinValue);
         Z386NotificationStatus = "";
         A386NotificationStatus = "";
         Z397NotificationLink = "";
         A397NotificationLink = "";
         BC001H5_A381NotificationId = new int[1] ;
         BC001H5_n381NotificationId = new bool[] {false} ;
         BC001H5_A382NotificationTitle = new string[] {""} ;
         BC001H5_n382NotificationTitle = new bool[] {false} ;
         BC001H5_A383NotificationMessage = new string[] {""} ;
         BC001H5_n383NotificationMessage = new bool[] {false} ;
         BC001H5_A384NotificationType = new string[] {""} ;
         BC001H5_n384NotificationType = new bool[] {false} ;
         BC001H5_A385NotificationCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001H5_n385NotificationCreatedAt = new bool[] {false} ;
         BC001H5_A386NotificationStatus = new string[] {""} ;
         BC001H5_n386NotificationStatus = new bool[] {false} ;
         BC001H5_A397NotificationLink = new string[] {""} ;
         BC001H5_n397NotificationLink = new bool[] {false} ;
         BC001H5_A133SecUserId = new short[1] ;
         BC001H5_n133SecUserId = new bool[] {false} ;
         BC001H4_A133SecUserId = new short[1] ;
         BC001H4_n133SecUserId = new bool[] {false} ;
         BC001H6_A381NotificationId = new int[1] ;
         BC001H6_n381NotificationId = new bool[] {false} ;
         BC001H3_A381NotificationId = new int[1] ;
         BC001H3_n381NotificationId = new bool[] {false} ;
         BC001H3_A382NotificationTitle = new string[] {""} ;
         BC001H3_n382NotificationTitle = new bool[] {false} ;
         BC001H3_A383NotificationMessage = new string[] {""} ;
         BC001H3_n383NotificationMessage = new bool[] {false} ;
         BC001H3_A384NotificationType = new string[] {""} ;
         BC001H3_n384NotificationType = new bool[] {false} ;
         BC001H3_A385NotificationCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001H3_n385NotificationCreatedAt = new bool[] {false} ;
         BC001H3_A386NotificationStatus = new string[] {""} ;
         BC001H3_n386NotificationStatus = new bool[] {false} ;
         BC001H3_A397NotificationLink = new string[] {""} ;
         BC001H3_n397NotificationLink = new bool[] {false} ;
         BC001H3_A133SecUserId = new short[1] ;
         BC001H3_n133SecUserId = new bool[] {false} ;
         sMode56 = "";
         BC001H2_A381NotificationId = new int[1] ;
         BC001H2_n381NotificationId = new bool[] {false} ;
         BC001H2_A382NotificationTitle = new string[] {""} ;
         BC001H2_n382NotificationTitle = new bool[] {false} ;
         BC001H2_A383NotificationMessage = new string[] {""} ;
         BC001H2_n383NotificationMessage = new bool[] {false} ;
         BC001H2_A384NotificationType = new string[] {""} ;
         BC001H2_n384NotificationType = new bool[] {false} ;
         BC001H2_A385NotificationCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001H2_n385NotificationCreatedAt = new bool[] {false} ;
         BC001H2_A386NotificationStatus = new string[] {""} ;
         BC001H2_n386NotificationStatus = new bool[] {false} ;
         BC001H2_A397NotificationLink = new string[] {""} ;
         BC001H2_n397NotificationLink = new bool[] {false} ;
         BC001H2_A133SecUserId = new short[1] ;
         BC001H2_n133SecUserId = new bool[] {false} ;
         BC001H8_A381NotificationId = new int[1] ;
         BC001H8_n381NotificationId = new bool[] {false} ;
         BC001H11_A392EmailQueueId = new int[1] ;
         BC001H12_A387UserNotificationId = new int[1] ;
         BC001H13_A381NotificationId = new int[1] ;
         BC001H13_n381NotificationId = new bool[] {false} ;
         BC001H13_A382NotificationTitle = new string[] {""} ;
         BC001H13_n382NotificationTitle = new bool[] {false} ;
         BC001H13_A383NotificationMessage = new string[] {""} ;
         BC001H13_n383NotificationMessage = new bool[] {false} ;
         BC001H13_A384NotificationType = new string[] {""} ;
         BC001H13_n384NotificationType = new bool[] {false} ;
         BC001H13_A385NotificationCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001H13_n385NotificationCreatedAt = new bool[] {false} ;
         BC001H13_A386NotificationStatus = new string[] {""} ;
         BC001H13_n386NotificationStatus = new bool[] {false} ;
         BC001H13_A397NotificationLink = new string[] {""} ;
         BC001H13_n397NotificationLink = new bool[] {false} ;
         BC001H13_A133SecUserId = new short[1] ;
         BC001H13_n133SecUserId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bcnotification_bc__default(),
            new Object[][] {
                new Object[] {
               BC001H2_A381NotificationId, BC001H2_A382NotificationTitle, BC001H2_n382NotificationTitle, BC001H2_A383NotificationMessage, BC001H2_n383NotificationMessage, BC001H2_A384NotificationType, BC001H2_n384NotificationType, BC001H2_A385NotificationCreatedAt, BC001H2_n385NotificationCreatedAt, BC001H2_A386NotificationStatus,
               BC001H2_n386NotificationStatus, BC001H2_A397NotificationLink, BC001H2_n397NotificationLink, BC001H2_A133SecUserId, BC001H2_n133SecUserId
               }
               , new Object[] {
               BC001H3_A381NotificationId, BC001H3_A382NotificationTitle, BC001H3_n382NotificationTitle, BC001H3_A383NotificationMessage, BC001H3_n383NotificationMessage, BC001H3_A384NotificationType, BC001H3_n384NotificationType, BC001H3_A385NotificationCreatedAt, BC001H3_n385NotificationCreatedAt, BC001H3_A386NotificationStatus,
               BC001H3_n386NotificationStatus, BC001H3_A397NotificationLink, BC001H3_n397NotificationLink, BC001H3_A133SecUserId, BC001H3_n133SecUserId
               }
               , new Object[] {
               BC001H4_A133SecUserId
               }
               , new Object[] {
               BC001H5_A381NotificationId, BC001H5_A382NotificationTitle, BC001H5_n382NotificationTitle, BC001H5_A383NotificationMessage, BC001H5_n383NotificationMessage, BC001H5_A384NotificationType, BC001H5_n384NotificationType, BC001H5_A385NotificationCreatedAt, BC001H5_n385NotificationCreatedAt, BC001H5_A386NotificationStatus,
               BC001H5_n386NotificationStatus, BC001H5_A397NotificationLink, BC001H5_n397NotificationLink, BC001H5_A133SecUserId, BC001H5_n133SecUserId
               }
               , new Object[] {
               BC001H6_A381NotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001H8_A381NotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001H11_A392EmailQueueId
               }
               , new Object[] {
               BC001H12_A387UserNotificationId
               }
               , new Object[] {
               BC001H13_A381NotificationId, BC001H13_A382NotificationTitle, BC001H13_n382NotificationTitle, BC001H13_A383NotificationMessage, BC001H13_n383NotificationMessage, BC001H13_A384NotificationType, BC001H13_n384NotificationType, BC001H13_A385NotificationCreatedAt, BC001H13_n385NotificationCreatedAt, BC001H13_A386NotificationStatus,
               BC001H13_n386NotificationStatus, BC001H13_A397NotificationLink, BC001H13_n397NotificationLink, BC001H13_A133SecUserId, BC001H13_n133SecUserId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z133SecUserId ;
      private short A133SecUserId ;
      private short RcdFound56 ;
      private int trnEnded ;
      private int Z381NotificationId ;
      private int A381NotificationId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode56 ;
      private DateTime Z385NotificationCreatedAt ;
      private DateTime A385NotificationCreatedAt ;
      private bool n381NotificationId ;
      private bool n382NotificationTitle ;
      private bool n383NotificationMessage ;
      private bool n384NotificationType ;
      private bool n385NotificationCreatedAt ;
      private bool n386NotificationStatus ;
      private bool n397NotificationLink ;
      private bool n133SecUserId ;
      private bool Gx_longc ;
      private string Z382NotificationTitle ;
      private string A382NotificationTitle ;
      private string Z383NotificationMessage ;
      private string A383NotificationMessage ;
      private string Z384NotificationType ;
      private string A384NotificationType ;
      private string Z386NotificationStatus ;
      private string A386NotificationStatus ;
      private string Z397NotificationLink ;
      private string A397NotificationLink ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC001H5_A381NotificationId ;
      private bool[] BC001H5_n381NotificationId ;
      private string[] BC001H5_A382NotificationTitle ;
      private bool[] BC001H5_n382NotificationTitle ;
      private string[] BC001H5_A383NotificationMessage ;
      private bool[] BC001H5_n383NotificationMessage ;
      private string[] BC001H5_A384NotificationType ;
      private bool[] BC001H5_n384NotificationType ;
      private DateTime[] BC001H5_A385NotificationCreatedAt ;
      private bool[] BC001H5_n385NotificationCreatedAt ;
      private string[] BC001H5_A386NotificationStatus ;
      private bool[] BC001H5_n386NotificationStatus ;
      private string[] BC001H5_A397NotificationLink ;
      private bool[] BC001H5_n397NotificationLink ;
      private short[] BC001H5_A133SecUserId ;
      private bool[] BC001H5_n133SecUserId ;
      private short[] BC001H4_A133SecUserId ;
      private bool[] BC001H4_n133SecUserId ;
      private int[] BC001H6_A381NotificationId ;
      private bool[] BC001H6_n381NotificationId ;
      private int[] BC001H3_A381NotificationId ;
      private bool[] BC001H3_n381NotificationId ;
      private string[] BC001H3_A382NotificationTitle ;
      private bool[] BC001H3_n382NotificationTitle ;
      private string[] BC001H3_A383NotificationMessage ;
      private bool[] BC001H3_n383NotificationMessage ;
      private string[] BC001H3_A384NotificationType ;
      private bool[] BC001H3_n384NotificationType ;
      private DateTime[] BC001H3_A385NotificationCreatedAt ;
      private bool[] BC001H3_n385NotificationCreatedAt ;
      private string[] BC001H3_A386NotificationStatus ;
      private bool[] BC001H3_n386NotificationStatus ;
      private string[] BC001H3_A397NotificationLink ;
      private bool[] BC001H3_n397NotificationLink ;
      private short[] BC001H3_A133SecUserId ;
      private bool[] BC001H3_n133SecUserId ;
      private int[] BC001H2_A381NotificationId ;
      private bool[] BC001H2_n381NotificationId ;
      private string[] BC001H2_A382NotificationTitle ;
      private bool[] BC001H2_n382NotificationTitle ;
      private string[] BC001H2_A383NotificationMessage ;
      private bool[] BC001H2_n383NotificationMessage ;
      private string[] BC001H2_A384NotificationType ;
      private bool[] BC001H2_n384NotificationType ;
      private DateTime[] BC001H2_A385NotificationCreatedAt ;
      private bool[] BC001H2_n385NotificationCreatedAt ;
      private string[] BC001H2_A386NotificationStatus ;
      private bool[] BC001H2_n386NotificationStatus ;
      private string[] BC001H2_A397NotificationLink ;
      private bool[] BC001H2_n397NotificationLink ;
      private short[] BC001H2_A133SecUserId ;
      private bool[] BC001H2_n133SecUserId ;
      private int[] BC001H8_A381NotificationId ;
      private bool[] BC001H8_n381NotificationId ;
      private int[] BC001H11_A392EmailQueueId ;
      private int[] BC001H12_A387UserNotificationId ;
      private int[] BC001H13_A381NotificationId ;
      private bool[] BC001H13_n381NotificationId ;
      private string[] BC001H13_A382NotificationTitle ;
      private bool[] BC001H13_n382NotificationTitle ;
      private string[] BC001H13_A383NotificationMessage ;
      private bool[] BC001H13_n383NotificationMessage ;
      private string[] BC001H13_A384NotificationType ;
      private bool[] BC001H13_n384NotificationType ;
      private DateTime[] BC001H13_A385NotificationCreatedAt ;
      private bool[] BC001H13_n385NotificationCreatedAt ;
      private string[] BC001H13_A386NotificationStatus ;
      private bool[] BC001H13_n386NotificationStatus ;
      private string[] BC001H13_A397NotificationLink ;
      private bool[] BC001H13_n397NotificationLink ;
      private short[] BC001H13_A133SecUserId ;
      private bool[] BC001H13_n133SecUserId ;
      private SdtBCNotification bcBCNotification ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class bcnotification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC001H2;
          prmBC001H2 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001H3;
          prmBC001H3 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001H4;
          prmBC001H4 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001H5;
          prmBC001H5 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001H6;
          prmBC001H6 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001H7;
          prmBC001H7 = new Object[] {
          new ParDef("NotificationTitle",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotificationMessage",GXType.VarChar,106,0){Nullable=true} ,
          new ParDef("NotificationType",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotificationCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificationStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotificationLink",GXType.VarChar,1000,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC001H8;
          prmBC001H8 = new Object[] {
          };
          Object[] prmBC001H9;
          prmBC001H9 = new Object[] {
          new ParDef("NotificationTitle",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotificationMessage",GXType.VarChar,106,0){Nullable=true} ,
          new ParDef("NotificationType",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotificationCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("NotificationStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotificationLink",GXType.VarChar,1000,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001H10;
          prmBC001H10 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001H11;
          prmBC001H11 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001H12;
          prmBC001H12 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001H13;
          prmBC001H13 = new Object[] {
          new ParDef("NotificationId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC001H2", "SELECT NotificationId, NotificationTitle, NotificationMessage, NotificationType, NotificationCreatedAt, NotificationStatus, NotificationLink, SecUserId FROM Notification WHERE NotificationId = :NotificationId  FOR UPDATE OF Notification",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001H3", "SELECT NotificationId, NotificationTitle, NotificationMessage, NotificationType, NotificationCreatedAt, NotificationStatus, NotificationLink, SecUserId FROM Notification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001H4", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001H5", "SELECT TM1.NotificationId, TM1.NotificationTitle, TM1.NotificationMessage, TM1.NotificationType, TM1.NotificationCreatedAt, TM1.NotificationStatus, TM1.NotificationLink, TM1.SecUserId FROM Notification TM1 WHERE TM1.NotificationId = :NotificationId ORDER BY TM1.NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001H6", "SELECT NotificationId FROM Notification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001H7", "SAVEPOINT gxupdate;INSERT INTO Notification(NotificationTitle, NotificationMessage, NotificationType, NotificationCreatedAt, NotificationStatus, NotificationLink, SecUserId) VALUES(:NotificationTitle, :NotificationMessage, :NotificationType, :NotificationCreatedAt, :NotificationStatus, :NotificationLink, :SecUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001H7)
             ,new CursorDef("BC001H8", "SELECT currval('NotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001H9", "SAVEPOINT gxupdate;UPDATE Notification SET NotificationTitle=:NotificationTitle, NotificationMessage=:NotificationMessage, NotificationType=:NotificationType, NotificationCreatedAt=:NotificationCreatedAt, NotificationStatus=:NotificationStatus, NotificationLink=:NotificationLink, SecUserId=:SecUserId  WHERE NotificationId = :NotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001H9)
             ,new CursorDef("BC001H10", "SAVEPOINT gxupdate;DELETE FROM Notification  WHERE NotificationId = :NotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001H10)
             ,new CursorDef("BC001H11", "SELECT EmailQueueId FROM EmailQueue WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001H12", "SELECT UserNotificationId FROM UserNotification WHERE NotificationId = :NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC001H13", "SELECT TM1.NotificationId, TM1.NotificationTitle, TM1.NotificationMessage, TM1.NotificationType, TM1.NotificationCreatedAt, TM1.NotificationStatus, TM1.NotificationLink, TM1.SecUserId FROM Notification TM1 WHERE TM1.NotificationId = :NotificationId ORDER BY TM1.NotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001H13,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
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
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
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
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
