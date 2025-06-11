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
   public class usuario_bc : GxSilentTrn, IGxSilentTrn
   {
      public usuario_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usuario_bc( IGxContext context )
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
         ReadRow2622( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2622( ) ;
         standaloneModal( ) ;
         AddRow2622( ) ;
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
            E11262 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z133SecUserId = A133SecUserId;
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

      protected void CONFIRM_260( )
      {
         BeforeValidate2622( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2622( ) ;
            }
            else
            {
               CheckExtendedTable2622( ) ;
               if ( AnyError == 0 )
               {
                  ZM2622( 15) ;
                  ZM2622( 16) ;
                  ZM2622( 17) ;
               }
               CloseExtendedTableCursors2622( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12262( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SecUserClienteId") == 0 )
               {
                  AV11Insert_SecUserClienteId = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SecUserOwnerId") == 0 )
               {
                  AV12Insert_SecUserOwnerId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "SecUserUserMan") == 0 )
               {
                  AV13Insert_SecUserUserMan = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
            }
         }
      }

      protected void E11262( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2622( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z145SecUserCreatedAt = A145SecUserCreatedAt;
            Z146SecUserUpdateAt = A146SecUserUpdateAt;
            Z141SecUserName = A141SecUserName;
            Z143SecUserFullName = A143SecUserFullName;
            Z144SecUserEmail = A144SecUserEmail;
            Z150SecUserStatus = A150SecUserStatus;
            Z226SecUserOwnerId = A226SecUserOwnerId;
            Z147SecUserUserMan = A147SecUserUserMan;
            Z210SecUserClienteId = A210SecUserClienteId;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -14 )
         {
            Z133SecUserId = A133SecUserId;
            Z145SecUserCreatedAt = A145SecUserCreatedAt;
            Z146SecUserUpdateAt = A146SecUserUpdateAt;
            Z141SecUserName = A141SecUserName;
            Z143SecUserFullName = A143SecUserFullName;
            Z144SecUserEmail = A144SecUserEmail;
            Z150SecUserStatus = A150SecUserStatus;
            Z226SecUserOwnerId = A226SecUserOwnerId;
            Z147SecUserUserMan = A147SecUserUserMan;
            Z210SecUserClienteId = A210SecUserClienteId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV16Pgmname = "Usuario_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            A146SecUserUpdateAt = DateTimeUtil.ServerNow( context, pr_default);
            n146SecUserUpdateAt = false;
         }
         if ( IsIns( )  )
         {
            A145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n145SecUserCreatedAt = false;
         }
         else
         {
            if ( IsIns( )  && (DateTime.MinValue==A145SecUserCreatedAt) && ( Gx_BScreen == 0 ) )
            {
               A145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
               n145SecUserCreatedAt = false;
            }
         }
         if ( IsIns( )  && (false==A150SecUserStatus) && ( Gx_BScreen == 0 ) )
         {
            A150SecUserStatus = true;
            n150SecUserStatus = false;
         }
      }

      protected void Load2622( )
      {
         /* Using cursor BC00267 */
         pr_default.execute(5, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound22 = 1;
            A145SecUserCreatedAt = BC00267_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = BC00267_n145SecUserCreatedAt[0];
            A146SecUserUpdateAt = BC00267_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = BC00267_n146SecUserUpdateAt[0];
            A141SecUserName = BC00267_A141SecUserName[0];
            n141SecUserName = BC00267_n141SecUserName[0];
            A143SecUserFullName = BC00267_A143SecUserFullName[0];
            n143SecUserFullName = BC00267_n143SecUserFullName[0];
            A144SecUserEmail = BC00267_A144SecUserEmail[0];
            n144SecUserEmail = BC00267_n144SecUserEmail[0];
            A150SecUserStatus = BC00267_A150SecUserStatus[0];
            n150SecUserStatus = BC00267_n150SecUserStatus[0];
            A226SecUserOwnerId = BC00267_A226SecUserOwnerId[0];
            n226SecUserOwnerId = BC00267_n226SecUserOwnerId[0];
            A147SecUserUserMan = BC00267_A147SecUserUserMan[0];
            n147SecUserUserMan = BC00267_n147SecUserUserMan[0];
            A210SecUserClienteId = BC00267_A210SecUserClienteId[0];
            n210SecUserClienteId = BC00267_n210SecUserClienteId[0];
            ZM2622( -14) ;
         }
         pr_default.close(5);
         OnLoadActions2622( ) ;
      }

      protected void OnLoadActions2622( )
      {
         if ( (0==A210SecUserClienteId) )
         {
            A210SecUserClienteId = 0;
            n210SecUserClienteId = false;
            n210SecUserClienteId = true;
            n210SecUserClienteId = true;
         }
         if ( (0==A226SecUserOwnerId) )
         {
            A226SecUserOwnerId = 0;
            n226SecUserOwnerId = false;
            n226SecUserOwnerId = true;
            n226SecUserOwnerId = true;
         }
         if ( (0==A147SecUserUserMan) )
         {
            A147SecUserUserMan = 0;
            n147SecUserUserMan = false;
            n147SecUserUserMan = true;
            n147SecUserUserMan = true;
         }
      }

      protected void CheckExtendedTable2622( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A141SecUserName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Usuário", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A143SecUserFullName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A144SecUserEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A144SecUserEmail)) ) )
         {
            GX_msglist.addItem("O valor de E-mail não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A144SecUserEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "E-mail", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( (0==A210SecUserClienteId) )
         {
            A210SecUserClienteId = 0;
            n210SecUserClienteId = false;
            n210SecUserClienteId = true;
            n210SecUserClienteId = true;
         }
         /* Using cursor BC00266 */
         pr_default.execute(4, new Object[] {n210SecUserClienteId, A210SecUserClienteId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A210SecUserClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Cliente User'.", "ForeignKeyNotFound", 1, "SECUSERCLIENTEID");
               AnyError = 1;
            }
         }
         pr_default.close(4);
         if ( (0==A226SecUserOwnerId) )
         {
            A226SecUserOwnerId = 0;
            n226SecUserOwnerId = false;
            n226SecUserOwnerId = true;
            n226SecUserOwnerId = true;
         }
         /* Using cursor BC00264 */
         pr_default.execute(2, new Object[] {n226SecUserOwnerId, A226SecUserOwnerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A226SecUserOwnerId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Sec User Owner'.", "ForeignKeyNotFound", 1, "SECUSEROWNERID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         if ( (0==A147SecUserUserMan) )
         {
            A147SecUserUserMan = 0;
            n147SecUserUserMan = false;
            n147SecUserUserMan = true;
            n147SecUserUserMan = true;
         }
         /* Using cursor BC00265 */
         pr_default.execute(3, new Object[] {n147SecUserUserMan, A147SecUserUserMan});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A147SecUserUserMan) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Manuten'.", "ForeignKeyNotFound", 1, "SECUSERUSERMAN");
               AnyError = 1;
            }
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2622( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2622( )
      {
         /* Using cursor BC00268 */
         pr_default.execute(6, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00263 */
         pr_default.execute(1, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2622( 14) ;
            RcdFound22 = 1;
            A133SecUserId = BC00263_A133SecUserId[0];
            n133SecUserId = BC00263_n133SecUserId[0];
            A145SecUserCreatedAt = BC00263_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = BC00263_n145SecUserCreatedAt[0];
            A146SecUserUpdateAt = BC00263_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = BC00263_n146SecUserUpdateAt[0];
            A141SecUserName = BC00263_A141SecUserName[0];
            n141SecUserName = BC00263_n141SecUserName[0];
            A143SecUserFullName = BC00263_A143SecUserFullName[0];
            n143SecUserFullName = BC00263_n143SecUserFullName[0];
            A144SecUserEmail = BC00263_A144SecUserEmail[0];
            n144SecUserEmail = BC00263_n144SecUserEmail[0];
            A150SecUserStatus = BC00263_A150SecUserStatus[0];
            n150SecUserStatus = BC00263_n150SecUserStatus[0];
            A226SecUserOwnerId = BC00263_A226SecUserOwnerId[0];
            n226SecUserOwnerId = BC00263_n226SecUserOwnerId[0];
            A147SecUserUserMan = BC00263_A147SecUserUserMan[0];
            n147SecUserUserMan = BC00263_n147SecUserUserMan[0];
            A210SecUserClienteId = BC00263_A210SecUserClienteId[0];
            n210SecUserClienteId = BC00263_n210SecUserClienteId[0];
            Z133SecUserId = A133SecUserId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2622( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey2622( ) ;
            }
            Gx_mode = sMode22;
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey2622( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode22;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2622( ) ;
         if ( RcdFound22 == 0 )
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
         CONFIRM_260( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2622( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00262 */
            pr_default.execute(0, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z145SecUserCreatedAt != BC00262_A145SecUserCreatedAt[0] ) || ( Z146SecUserUpdateAt != BC00262_A146SecUserUpdateAt[0] ) || ( StringUtil.StrCmp(Z141SecUserName, BC00262_A141SecUserName[0]) != 0 ) || ( StringUtil.StrCmp(Z143SecUserFullName, BC00262_A143SecUserFullName[0]) != 0 ) || ( StringUtil.StrCmp(Z144SecUserEmail, BC00262_A144SecUserEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z150SecUserStatus != BC00262_A150SecUserStatus[0] ) || ( Z226SecUserOwnerId != BC00262_A226SecUserOwnerId[0] ) || ( Z147SecUserUserMan != BC00262_A147SecUserUserMan[0] ) || ( Z210SecUserClienteId != BC00262_A210SecUserClienteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUser"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2622( )
      {
         BeforeValidate2622( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2622( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2622( 0) ;
            CheckOptimisticConcurrency2622( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2622( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2622( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00269 */
                     pr_default.execute(7, new Object[] {n145SecUserCreatedAt, A145SecUserCreatedAt, n146SecUserUpdateAt, A146SecUserUpdateAt, n141SecUserName, A141SecUserName, n143SecUserFullName, A143SecUserFullName, n144SecUserEmail, A144SecUserEmail, n150SecUserStatus, A150SecUserStatus, n226SecUserOwnerId, A226SecUserOwnerId, n147SecUserUserMan, A147SecUserUserMan, n210SecUserClienteId, A210SecUserClienteId});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002610 */
                     pr_default.execute(8);
                     A133SecUserId = BC002610_A133SecUserId[0];
                     n133SecUserId = BC002610_n133SecUserId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("SecUser");
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
               Load2622( ) ;
            }
            EndLevel2622( ) ;
         }
         CloseExtendedTableCursors2622( ) ;
      }

      protected void Update2622( )
      {
         BeforeValidate2622( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2622( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2622( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2622( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2622( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002611 */
                     pr_default.execute(9, new Object[] {n145SecUserCreatedAt, A145SecUserCreatedAt, n146SecUserUpdateAt, A146SecUserUpdateAt, n141SecUserName, A141SecUserName, n143SecUserFullName, A143SecUserFullName, n144SecUserEmail, A144SecUserEmail, n150SecUserStatus, A150SecUserStatus, n226SecUserOwnerId, A226SecUserOwnerId, n147SecUserUserMan, A147SecUserUserMan, n210SecUserClienteId, A210SecUserClienteId, n133SecUserId, A133SecUserId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SecUser");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2622( ) ;
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
            EndLevel2622( ) ;
         }
         CloseExtendedTableCursors2622( ) ;
      }

      protected void DeferredUpdate2622( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2622( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2622( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2622( ) ;
            AfterConfirm2622( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2622( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002612 */
                  pr_default.execute(10, new Object[] {n133SecUserId, A133SecUserId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("SecUser");
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2622( ) ;
         Gx_mode = sMode22;
      }

      protected void OnDeleteControls2622( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC002613 */
            pr_default.execute(11, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC002614 */
            pr_default.execute(12, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC002615 */
            pr_default.execute(13, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Chave PIX"+" ("+"Sb Chave PIXUpdated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC002616 */
            pr_default.execute(14, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Chave PIX"+" ("+"Sb Chave PIXCreated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor BC002617 */
            pr_default.execute(15, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conta Bancaria"+" ("+"Sb Conta Bancaria Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor BC002618 */
            pr_default.execute(16, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conta Bancaria"+" ("+"Sb Conta Bancaria Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor BC002619 */
            pr_default.execute(17, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agencia"+" ("+"Sb Agencia Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor BC002620 */
            pr_default.execute(18, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agencia"+" ("+"Sb Agencia Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor BC002621 */
            pr_default.execute(19, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Taxas"+" ("+"Sb Taxas Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor BC002622 */
            pr_default.execute(20, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Taxas"+" ("+"Sb Taxas Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor BC002623 */
            pr_default.execute(21, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"+" ("+"Sb Updated By Credito"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor BC002624 */
            pr_default.execute(22, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"+" ("+"Sdb Credito Usuario"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor BC002625 */
            pr_default.execute(23, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoFlowLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor BC002626 */
            pr_default.execute(24, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor BC002627 */
            pr_default.execute(25, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Especialidade"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor BC002628 */
            pr_default.execute(26, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor BC002629 */
            pr_default.execute(27, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"UserNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor BC002630 */
            pr_default.execute(28, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor BC002631 */
            pr_default.execute(29, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SecUserLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor BC002632 */
            pr_default.execute(30, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ConfiguracoesTestemunhas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor BC002633 */
            pr_default.execute(31, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Notification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor BC002634 */
            pr_default.execute(32, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor BC002635 */
            pr_default.execute(33, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sec User UID"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor BC002636 */
            pr_default.execute(34, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sec User Role"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
         }
      }

      protected void EndLevel2622( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2622( ) ;
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

      public void ScanKeyStart2622( )
      {
         /* Scan By routine */
         /* Using cursor BC002637 */
         pr_default.execute(35, new Object[] {n133SecUserId, A133SecUserId});
         RcdFound22 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound22 = 1;
            A133SecUserId = BC002637_A133SecUserId[0];
            n133SecUserId = BC002637_n133SecUserId[0];
            A145SecUserCreatedAt = BC002637_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = BC002637_n145SecUserCreatedAt[0];
            A146SecUserUpdateAt = BC002637_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = BC002637_n146SecUserUpdateAt[0];
            A141SecUserName = BC002637_A141SecUserName[0];
            n141SecUserName = BC002637_n141SecUserName[0];
            A143SecUserFullName = BC002637_A143SecUserFullName[0];
            n143SecUserFullName = BC002637_n143SecUserFullName[0];
            A144SecUserEmail = BC002637_A144SecUserEmail[0];
            n144SecUserEmail = BC002637_n144SecUserEmail[0];
            A150SecUserStatus = BC002637_A150SecUserStatus[0];
            n150SecUserStatus = BC002637_n150SecUserStatus[0];
            A226SecUserOwnerId = BC002637_A226SecUserOwnerId[0];
            n226SecUserOwnerId = BC002637_n226SecUserOwnerId[0];
            A147SecUserUserMan = BC002637_A147SecUserUserMan[0];
            n147SecUserUserMan = BC002637_n147SecUserUserMan[0];
            A210SecUserClienteId = BC002637_A210SecUserClienteId[0];
            n210SecUserClienteId = BC002637_n210SecUserClienteId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2622( )
      {
         /* Scan next routine */
         pr_default.readNext(35);
         RcdFound22 = 0;
         ScanKeyLoad2622( ) ;
      }

      protected void ScanKeyLoad2622( )
      {
         sMode22 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound22 = 1;
            A133SecUserId = BC002637_A133SecUserId[0];
            n133SecUserId = BC002637_n133SecUserId[0];
            A145SecUserCreatedAt = BC002637_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = BC002637_n145SecUserCreatedAt[0];
            A146SecUserUpdateAt = BC002637_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = BC002637_n146SecUserUpdateAt[0];
            A141SecUserName = BC002637_A141SecUserName[0];
            n141SecUserName = BC002637_n141SecUserName[0];
            A143SecUserFullName = BC002637_A143SecUserFullName[0];
            n143SecUserFullName = BC002637_n143SecUserFullName[0];
            A144SecUserEmail = BC002637_A144SecUserEmail[0];
            n144SecUserEmail = BC002637_n144SecUserEmail[0];
            A150SecUserStatus = BC002637_A150SecUserStatus[0];
            n150SecUserStatus = BC002637_n150SecUserStatus[0];
            A226SecUserOwnerId = BC002637_A226SecUserOwnerId[0];
            n226SecUserOwnerId = BC002637_n226SecUserOwnerId[0];
            A147SecUserUserMan = BC002637_A147SecUserUserMan[0];
            n147SecUserUserMan = BC002637_n147SecUserUserMan[0];
            A210SecUserClienteId = BC002637_A210SecUserClienteId[0];
            n210SecUserClienteId = BC002637_n210SecUserClienteId[0];
         }
         Gx_mode = sMode22;
      }

      protected void ScanKeyEnd2622( )
      {
         pr_default.close(35);
      }

      protected void AfterConfirm2622( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2622( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2622( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2622( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2622( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2622( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2622( )
      {
      }

      protected void send_integrity_lvl_hashes2622( )
      {
      }

      protected void AddRow2622( )
      {
         VarsToRow22( bcUsuario) ;
      }

      protected void ReadRow2622( )
      {
         RowToVars22( bcUsuario, 1) ;
      }

      protected void InitializeNonKey2622( )
      {
         A145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n145SecUserCreatedAt = false;
         A146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         n146SecUserUpdateAt = false;
         A141SecUserName = "";
         n141SecUserName = false;
         A143SecUserFullName = "";
         n143SecUserFullName = false;
         A144SecUserEmail = "";
         n144SecUserEmail = false;
         A210SecUserClienteId = 0;
         n210SecUserClienteId = false;
         A226SecUserOwnerId = 0;
         n226SecUserOwnerId = false;
         A147SecUserUserMan = 0;
         n147SecUserUserMan = false;
         A150SecUserStatus = true;
         n150SecUserStatus = false;
         Z145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         Z146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         Z141SecUserName = "";
         Z143SecUserFullName = "";
         Z144SecUserEmail = "";
         Z150SecUserStatus = false;
         Z226SecUserOwnerId = 0;
         Z147SecUserUserMan = 0;
         Z210SecUserClienteId = 0;
      }

      protected void InitAll2622( )
      {
         A133SecUserId = 0;
         n133SecUserId = false;
         InitializeNonKey2622( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A145SecUserCreatedAt = i145SecUserCreatedAt;
         n145SecUserCreatedAt = false;
         A150SecUserStatus = i150SecUserStatus;
         n150SecUserStatus = false;
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

      public void VarsToRow22( SdtUsuario obj22 )
      {
         obj22.gxTpr_Mode = Gx_mode;
         obj22.gxTpr_Secusercreatedat = A145SecUserCreatedAt;
         obj22.gxTpr_Secuserupdateat = A146SecUserUpdateAt;
         obj22.gxTpr_Secusername = A141SecUserName;
         obj22.gxTpr_Secuserfullname = A143SecUserFullName;
         obj22.gxTpr_Secuseremail = A144SecUserEmail;
         obj22.gxTpr_Secuserclienteid = A210SecUserClienteId;
         obj22.gxTpr_Secuserownerid = A226SecUserOwnerId;
         obj22.gxTpr_Secuseruserman = A147SecUserUserMan;
         obj22.gxTpr_Secuserstatus = A150SecUserStatus;
         obj22.gxTpr_Secuserid = A133SecUserId;
         obj22.gxTpr_Secuserid_Z = Z133SecUserId;
         obj22.gxTpr_Secusername_Z = Z141SecUserName;
         obj22.gxTpr_Secuserfullname_Z = Z143SecUserFullName;
         obj22.gxTpr_Secuseremail_Z = Z144SecUserEmail;
         obj22.gxTpr_Secuserstatus_Z = Z150SecUserStatus;
         obj22.gxTpr_Secusercreatedat_Z = Z145SecUserCreatedAt;
         obj22.gxTpr_Secuserupdateat_Z = Z146SecUserUpdateAt;
         obj22.gxTpr_Secuserclienteid_Z = Z210SecUserClienteId;
         obj22.gxTpr_Secuserownerid_Z = Z226SecUserOwnerId;
         obj22.gxTpr_Secuseruserman_Z = Z147SecUserUserMan;
         obj22.gxTpr_Secuserid_N = (short)(Convert.ToInt16(n133SecUserId));
         obj22.gxTpr_Secusername_N = (short)(Convert.ToInt16(n141SecUserName));
         obj22.gxTpr_Secuserfullname_N = (short)(Convert.ToInt16(n143SecUserFullName));
         obj22.gxTpr_Secuseremail_N = (short)(Convert.ToInt16(n144SecUserEmail));
         obj22.gxTpr_Secuserstatus_N = (short)(Convert.ToInt16(n150SecUserStatus));
         obj22.gxTpr_Secusercreatedat_N = (short)(Convert.ToInt16(n145SecUserCreatedAt));
         obj22.gxTpr_Secuserupdateat_N = (short)(Convert.ToInt16(n146SecUserUpdateAt));
         obj22.gxTpr_Secuserclienteid_N = (short)(Convert.ToInt16(n210SecUserClienteId));
         obj22.gxTpr_Secuserownerid_N = (short)(Convert.ToInt16(n226SecUserOwnerId));
         obj22.gxTpr_Secuseruserman_N = (short)(Convert.ToInt16(n147SecUserUserMan));
         obj22.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow22( SdtUsuario obj22 )
      {
         obj22.gxTpr_Secuserid = A133SecUserId;
         return  ;
      }

      public void RowToVars22( SdtUsuario obj22 ,
                               int forceLoad )
      {
         Gx_mode = obj22.gxTpr_Mode;
         A145SecUserCreatedAt = obj22.gxTpr_Secusercreatedat;
         n145SecUserCreatedAt = false;
         A146SecUserUpdateAt = obj22.gxTpr_Secuserupdateat;
         n146SecUserUpdateAt = false;
         A141SecUserName = obj22.gxTpr_Secusername;
         n141SecUserName = false;
         A143SecUserFullName = obj22.gxTpr_Secuserfullname;
         n143SecUserFullName = false;
         A144SecUserEmail = obj22.gxTpr_Secuseremail;
         n144SecUserEmail = false;
         A210SecUserClienteId = obj22.gxTpr_Secuserclienteid;
         n210SecUserClienteId = false;
         A226SecUserOwnerId = obj22.gxTpr_Secuserownerid;
         n226SecUserOwnerId = false;
         A147SecUserUserMan = obj22.gxTpr_Secuseruserman;
         n147SecUserUserMan = false;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A150SecUserStatus = obj22.gxTpr_Secuserstatus;
            n150SecUserStatus = false;
         }
         A133SecUserId = obj22.gxTpr_Secuserid;
         n133SecUserId = false;
         Z133SecUserId = obj22.gxTpr_Secuserid_Z;
         Z141SecUserName = obj22.gxTpr_Secusername_Z;
         Z143SecUserFullName = obj22.gxTpr_Secuserfullname_Z;
         Z144SecUserEmail = obj22.gxTpr_Secuseremail_Z;
         Z150SecUserStatus = obj22.gxTpr_Secuserstatus_Z;
         Z145SecUserCreatedAt = obj22.gxTpr_Secusercreatedat_Z;
         Z146SecUserUpdateAt = obj22.gxTpr_Secuserupdateat_Z;
         Z210SecUserClienteId = obj22.gxTpr_Secuserclienteid_Z;
         Z226SecUserOwnerId = obj22.gxTpr_Secuserownerid_Z;
         Z147SecUserUserMan = obj22.gxTpr_Secuseruserman_Z;
         n133SecUserId = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserid_N));
         n141SecUserName = (bool)(Convert.ToBoolean(obj22.gxTpr_Secusername_N));
         n143SecUserFullName = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserfullname_N));
         n144SecUserEmail = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuseremail_N));
         n150SecUserStatus = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserstatus_N));
         n145SecUserCreatedAt = (bool)(Convert.ToBoolean(obj22.gxTpr_Secusercreatedat_N));
         n146SecUserUpdateAt = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserupdateat_N));
         n210SecUserClienteId = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserclienteid_N));
         n226SecUserOwnerId = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserownerid_N));
         n147SecUserUserMan = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuseruserman_N));
         Gx_mode = obj22.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A133SecUserId = (short)getParm(obj,0);
         n133SecUserId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2622( ) ;
         ScanKeyStart2622( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z133SecUserId = A133SecUserId;
         }
         ZM2622( -14) ;
         OnLoadActions2622( ) ;
         AddRow2622( ) ;
         ScanKeyEnd2622( ) ;
         if ( RcdFound22 == 0 )
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
         RowToVars22( bcUsuario, 0) ;
         ScanKeyStart2622( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z133SecUserId = A133SecUserId;
         }
         ZM2622( -14) ;
         OnLoadActions2622( ) ;
         AddRow2622( ) ;
         ScanKeyEnd2622( ) ;
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2622( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2622( ) ;
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( A133SecUserId != Z133SecUserId )
               {
                  A133SecUserId = Z133SecUserId;
                  n133SecUserId = false;
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
                  Update2622( ) ;
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
                  if ( A133SecUserId != Z133SecUserId )
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
                        Insert2622( ) ;
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
                        Insert2622( ) ;
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
         RowToVars22( bcUsuario, 1) ;
         SaveImpl( ) ;
         VarsToRow22( bcUsuario) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars22( bcUsuario, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2622( ) ;
         AfterTrn( ) ;
         VarsToRow22( bcUsuario) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow22( bcUsuario) ;
         }
         else
         {
            SdtUsuario auxBC = new SdtUsuario(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A133SecUserId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcUsuario);
               auxBC.Save();
               bcUsuario.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars22( bcUsuario, 1) ;
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
         RowToVars22( bcUsuario, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2622( ) ;
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
               VarsToRow22( bcUsuario) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow22( bcUsuario) ;
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
         RowToVars22( bcUsuario, 0) ;
         GetKey2622( ) ;
         if ( RcdFound22 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A133SecUserId != Z133SecUserId )
            {
               A133SecUserId = Z133SecUserId;
               n133SecUserId = false;
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
            if ( A133SecUserId != Z133SecUserId )
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
         context.RollbackDataStores("usuario_bc",pr_default);
         VarsToRow22( bcUsuario) ;
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
         Gx_mode = bcUsuario.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcUsuario.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcUsuario )
         {
            bcUsuario = (SdtUsuario)(sdt);
            if ( StringUtil.StrCmp(bcUsuario.gxTpr_Mode, "") == 0 )
            {
               bcUsuario.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow22( bcUsuario) ;
            }
            else
            {
               RowToVars22( bcUsuario, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcUsuario.gxTpr_Mode, "") == 0 )
            {
               bcUsuario.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars22( bcUsuario, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtUsuario Usuario_BC
      {
         get {
            return bcUsuario ;
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
         AV16Pgmname = "";
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         A145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         Z146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         A146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         Z141SecUserName = "";
         A141SecUserName = "";
         Z143SecUserFullName = "";
         A143SecUserFullName = "";
         Z144SecUserEmail = "";
         A144SecUserEmail = "";
         BC00267_A133SecUserId = new short[1] ;
         BC00267_n133SecUserId = new bool[] {false} ;
         BC00267_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00267_n145SecUserCreatedAt = new bool[] {false} ;
         BC00267_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC00267_n146SecUserUpdateAt = new bool[] {false} ;
         BC00267_A141SecUserName = new string[] {""} ;
         BC00267_n141SecUserName = new bool[] {false} ;
         BC00267_A143SecUserFullName = new string[] {""} ;
         BC00267_n143SecUserFullName = new bool[] {false} ;
         BC00267_A144SecUserEmail = new string[] {""} ;
         BC00267_n144SecUserEmail = new bool[] {false} ;
         BC00267_A150SecUserStatus = new bool[] {false} ;
         BC00267_n150SecUserStatus = new bool[] {false} ;
         BC00267_A226SecUserOwnerId = new int[1] ;
         BC00267_n226SecUserOwnerId = new bool[] {false} ;
         BC00267_A147SecUserUserMan = new short[1] ;
         BC00267_n147SecUserUserMan = new bool[] {false} ;
         BC00267_A210SecUserClienteId = new short[1] ;
         BC00267_n210SecUserClienteId = new bool[] {false} ;
         BC00266_A210SecUserClienteId = new short[1] ;
         BC00266_n210SecUserClienteId = new bool[] {false} ;
         BC00264_A226SecUserOwnerId = new int[1] ;
         BC00264_n226SecUserOwnerId = new bool[] {false} ;
         BC00265_A147SecUserUserMan = new short[1] ;
         BC00265_n147SecUserUserMan = new bool[] {false} ;
         BC00268_A133SecUserId = new short[1] ;
         BC00268_n133SecUserId = new bool[] {false} ;
         BC00263_A133SecUserId = new short[1] ;
         BC00263_n133SecUserId = new bool[] {false} ;
         BC00263_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00263_n145SecUserCreatedAt = new bool[] {false} ;
         BC00263_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC00263_n146SecUserUpdateAt = new bool[] {false} ;
         BC00263_A141SecUserName = new string[] {""} ;
         BC00263_n141SecUserName = new bool[] {false} ;
         BC00263_A143SecUserFullName = new string[] {""} ;
         BC00263_n143SecUserFullName = new bool[] {false} ;
         BC00263_A144SecUserEmail = new string[] {""} ;
         BC00263_n144SecUserEmail = new bool[] {false} ;
         BC00263_A150SecUserStatus = new bool[] {false} ;
         BC00263_n150SecUserStatus = new bool[] {false} ;
         BC00263_A226SecUserOwnerId = new int[1] ;
         BC00263_n226SecUserOwnerId = new bool[] {false} ;
         BC00263_A147SecUserUserMan = new short[1] ;
         BC00263_n147SecUserUserMan = new bool[] {false} ;
         BC00263_A210SecUserClienteId = new short[1] ;
         BC00263_n210SecUserClienteId = new bool[] {false} ;
         sMode22 = "";
         BC00262_A133SecUserId = new short[1] ;
         BC00262_n133SecUserId = new bool[] {false} ;
         BC00262_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00262_n145SecUserCreatedAt = new bool[] {false} ;
         BC00262_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC00262_n146SecUserUpdateAt = new bool[] {false} ;
         BC00262_A141SecUserName = new string[] {""} ;
         BC00262_n141SecUserName = new bool[] {false} ;
         BC00262_A143SecUserFullName = new string[] {""} ;
         BC00262_n143SecUserFullName = new bool[] {false} ;
         BC00262_A144SecUserEmail = new string[] {""} ;
         BC00262_n144SecUserEmail = new bool[] {false} ;
         BC00262_A150SecUserStatus = new bool[] {false} ;
         BC00262_n150SecUserStatus = new bool[] {false} ;
         BC00262_A226SecUserOwnerId = new int[1] ;
         BC00262_n226SecUserOwnerId = new bool[] {false} ;
         BC00262_A147SecUserUserMan = new short[1] ;
         BC00262_n147SecUserUserMan = new bool[] {false} ;
         BC00262_A210SecUserClienteId = new short[1] ;
         BC00262_n210SecUserClienteId = new bool[] {false} ;
         BC002610_A133SecUserId = new short[1] ;
         BC002610_n133SecUserId = new bool[] {false} ;
         BC002613_A210SecUserClienteId = new short[1] ;
         BC002613_n210SecUserClienteId = new bool[] {false} ;
         BC002614_A147SecUserUserMan = new short[1] ;
         BC002614_n147SecUserUserMan = new bool[] {false} ;
         BC002615_A961ChavePIXId = new int[1] ;
         BC002616_A961ChavePIXId = new int[1] ;
         BC002617_A951ContaBancariaId = new int[1] ;
         BC002618_A951ContaBancariaId = new int[1] ;
         BC002619_A938AgenciaId = new int[1] ;
         BC002620_A938AgenciaId = new int[1] ;
         BC002621_A863TaxasId = new int[1] ;
         BC002622_A863TaxasId = new int[1] ;
         BC002623_A856CreditoId = new int[1] ;
         BC002624_A856CreditoId = new int[1] ;
         BC002625_A746ReembolsoFlowLogId = new int[1] ;
         BC002626_A599ClienteDocumentoId = new int[1] ;
         BC002627_A457EspecialidadeId = new int[1] ;
         BC002628_A518ReembolsoId = new int[1] ;
         BC002629_A387UserNotificationId = new int[1] ;
         BC002630_A323PropostaId = new int[1] ;
         BC002631_A559SecUserLogId = new int[1] ;
         BC002632_A478ConfiguracoesTestemunhasId = new int[1] ;
         BC002633_A381NotificationId = new int[1] ;
         BC002634_A375AprovadoresId = new int[1] ;
         BC002635_A164SecUserTokenID = new short[1] ;
         BC002636_A133SecUserId = new short[1] ;
         BC002636_n133SecUserId = new bool[] {false} ;
         BC002636_A131SecRoleId = new short[1] ;
         BC002637_A133SecUserId = new short[1] ;
         BC002637_n133SecUserId = new bool[] {false} ;
         BC002637_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002637_n145SecUserCreatedAt = new bool[] {false} ;
         BC002637_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC002637_n146SecUserUpdateAt = new bool[] {false} ;
         BC002637_A141SecUserName = new string[] {""} ;
         BC002637_n141SecUserName = new bool[] {false} ;
         BC002637_A143SecUserFullName = new string[] {""} ;
         BC002637_n143SecUserFullName = new bool[] {false} ;
         BC002637_A144SecUserEmail = new string[] {""} ;
         BC002637_n144SecUserEmail = new bool[] {false} ;
         BC002637_A150SecUserStatus = new bool[] {false} ;
         BC002637_n150SecUserStatus = new bool[] {false} ;
         BC002637_A226SecUserOwnerId = new int[1] ;
         BC002637_n226SecUserOwnerId = new bool[] {false} ;
         BC002637_A147SecUserUserMan = new short[1] ;
         BC002637_n147SecUserUserMan = new bool[] {false} ;
         BC002637_A210SecUserClienteId = new short[1] ;
         BC002637_n210SecUserClienteId = new bool[] {false} ;
         i145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuario_bc__default(),
            new Object[][] {
                new Object[] {
               BC00262_A133SecUserId, BC00262_A145SecUserCreatedAt, BC00262_n145SecUserCreatedAt, BC00262_A146SecUserUpdateAt, BC00262_n146SecUserUpdateAt, BC00262_A141SecUserName, BC00262_n141SecUserName, BC00262_A143SecUserFullName, BC00262_n143SecUserFullName, BC00262_A144SecUserEmail,
               BC00262_n144SecUserEmail, BC00262_A150SecUserStatus, BC00262_n150SecUserStatus, BC00262_A226SecUserOwnerId, BC00262_n226SecUserOwnerId, BC00262_A147SecUserUserMan, BC00262_n147SecUserUserMan, BC00262_A210SecUserClienteId, BC00262_n210SecUserClienteId
               }
               , new Object[] {
               BC00263_A133SecUserId, BC00263_A145SecUserCreatedAt, BC00263_n145SecUserCreatedAt, BC00263_A146SecUserUpdateAt, BC00263_n146SecUserUpdateAt, BC00263_A141SecUserName, BC00263_n141SecUserName, BC00263_A143SecUserFullName, BC00263_n143SecUserFullName, BC00263_A144SecUserEmail,
               BC00263_n144SecUserEmail, BC00263_A150SecUserStatus, BC00263_n150SecUserStatus, BC00263_A226SecUserOwnerId, BC00263_n226SecUserOwnerId, BC00263_A147SecUserUserMan, BC00263_n147SecUserUserMan, BC00263_A210SecUserClienteId, BC00263_n210SecUserClienteId
               }
               , new Object[] {
               BC00264_A226SecUserOwnerId
               }
               , new Object[] {
               BC00265_A147SecUserUserMan
               }
               , new Object[] {
               BC00266_A210SecUserClienteId
               }
               , new Object[] {
               BC00267_A133SecUserId, BC00267_A145SecUserCreatedAt, BC00267_n145SecUserCreatedAt, BC00267_A146SecUserUpdateAt, BC00267_n146SecUserUpdateAt, BC00267_A141SecUserName, BC00267_n141SecUserName, BC00267_A143SecUserFullName, BC00267_n143SecUserFullName, BC00267_A144SecUserEmail,
               BC00267_n144SecUserEmail, BC00267_A150SecUserStatus, BC00267_n150SecUserStatus, BC00267_A226SecUserOwnerId, BC00267_n226SecUserOwnerId, BC00267_A147SecUserUserMan, BC00267_n147SecUserUserMan, BC00267_A210SecUserClienteId, BC00267_n210SecUserClienteId
               }
               , new Object[] {
               BC00268_A133SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002610_A133SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002613_A210SecUserClienteId
               }
               , new Object[] {
               BC002614_A147SecUserUserMan
               }
               , new Object[] {
               BC002615_A961ChavePIXId
               }
               , new Object[] {
               BC002616_A961ChavePIXId
               }
               , new Object[] {
               BC002617_A951ContaBancariaId
               }
               , new Object[] {
               BC002618_A951ContaBancariaId
               }
               , new Object[] {
               BC002619_A938AgenciaId
               }
               , new Object[] {
               BC002620_A938AgenciaId
               }
               , new Object[] {
               BC002621_A863TaxasId
               }
               , new Object[] {
               BC002622_A863TaxasId
               }
               , new Object[] {
               BC002623_A856CreditoId
               }
               , new Object[] {
               BC002624_A856CreditoId
               }
               , new Object[] {
               BC002625_A746ReembolsoFlowLogId
               }
               , new Object[] {
               BC002626_A599ClienteDocumentoId
               }
               , new Object[] {
               BC002627_A457EspecialidadeId
               }
               , new Object[] {
               BC002628_A518ReembolsoId
               }
               , new Object[] {
               BC002629_A387UserNotificationId
               }
               , new Object[] {
               BC002630_A323PropostaId
               }
               , new Object[] {
               BC002631_A559SecUserLogId
               }
               , new Object[] {
               BC002632_A478ConfiguracoesTestemunhasId
               }
               , new Object[] {
               BC002633_A381NotificationId
               }
               , new Object[] {
               BC002634_A375AprovadoresId
               }
               , new Object[] {
               BC002635_A164SecUserTokenID
               }
               , new Object[] {
               BC002636_A133SecUserId, BC002636_A131SecRoleId
               }
               , new Object[] {
               BC002637_A133SecUserId, BC002637_A145SecUserCreatedAt, BC002637_n145SecUserCreatedAt, BC002637_A146SecUserUpdateAt, BC002637_n146SecUserUpdateAt, BC002637_A141SecUserName, BC002637_n141SecUserName, BC002637_A143SecUserFullName, BC002637_n143SecUserFullName, BC002637_A144SecUserEmail,
               BC002637_n144SecUserEmail, BC002637_A150SecUserStatus, BC002637_n150SecUserStatus, BC002637_A226SecUserOwnerId, BC002637_n226SecUserOwnerId, BC002637_A147SecUserUserMan, BC002637_n147SecUserUserMan, BC002637_A210SecUserClienteId, BC002637_n210SecUserClienteId
               }
            }
         );
         AV16Pgmname = "Usuario_BC";
         Z145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n145SecUserCreatedAt = false;
         A145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n145SecUserCreatedAt = false;
         i145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n145SecUserCreatedAt = false;
         Z150SecUserStatus = true;
         n150SecUserStatus = false;
         A150SecUserStatus = true;
         n150SecUserStatus = false;
         i150SecUserStatus = true;
         n150SecUserStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12262 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z133SecUserId ;
      private short A133SecUserId ;
      private short AV11Insert_SecUserClienteId ;
      private short AV13Insert_SecUserUserMan ;
      private short Z147SecUserUserMan ;
      private short A147SecUserUserMan ;
      private short Z210SecUserClienteId ;
      private short A210SecUserClienteId ;
      private short Gx_BScreen ;
      private short RcdFound22 ;
      private int trnEnded ;
      private int AV17GXV1 ;
      private int AV12Insert_SecUserOwnerId ;
      private int Z226SecUserOwnerId ;
      private int A226SecUserOwnerId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV16Pgmname ;
      private string sMode22 ;
      private DateTime Z145SecUserCreatedAt ;
      private DateTime A145SecUserCreatedAt ;
      private DateTime Z146SecUserUpdateAt ;
      private DateTime A146SecUserUpdateAt ;
      private DateTime i145SecUserCreatedAt ;
      private bool returnInSub ;
      private bool Z150SecUserStatus ;
      private bool A150SecUserStatus ;
      private bool n146SecUserUpdateAt ;
      private bool n145SecUserCreatedAt ;
      private bool n150SecUserStatus ;
      private bool n133SecUserId ;
      private bool n141SecUserName ;
      private bool n143SecUserFullName ;
      private bool n144SecUserEmail ;
      private bool n226SecUserOwnerId ;
      private bool n147SecUserUserMan ;
      private bool n210SecUserClienteId ;
      private bool Gx_longc ;
      private bool i150SecUserStatus ;
      private string Z141SecUserName ;
      private string A141SecUserName ;
      private string Z143SecUserFullName ;
      private string A143SecUserFullName ;
      private string Z144SecUserEmail ;
      private string A144SecUserEmail ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] BC00267_A133SecUserId ;
      private bool[] BC00267_n133SecUserId ;
      private DateTime[] BC00267_A145SecUserCreatedAt ;
      private bool[] BC00267_n145SecUserCreatedAt ;
      private DateTime[] BC00267_A146SecUserUpdateAt ;
      private bool[] BC00267_n146SecUserUpdateAt ;
      private string[] BC00267_A141SecUserName ;
      private bool[] BC00267_n141SecUserName ;
      private string[] BC00267_A143SecUserFullName ;
      private bool[] BC00267_n143SecUserFullName ;
      private string[] BC00267_A144SecUserEmail ;
      private bool[] BC00267_n144SecUserEmail ;
      private bool[] BC00267_A150SecUserStatus ;
      private bool[] BC00267_n150SecUserStatus ;
      private int[] BC00267_A226SecUserOwnerId ;
      private bool[] BC00267_n226SecUserOwnerId ;
      private short[] BC00267_A147SecUserUserMan ;
      private bool[] BC00267_n147SecUserUserMan ;
      private short[] BC00267_A210SecUserClienteId ;
      private bool[] BC00267_n210SecUserClienteId ;
      private short[] BC00266_A210SecUserClienteId ;
      private bool[] BC00266_n210SecUserClienteId ;
      private int[] BC00264_A226SecUserOwnerId ;
      private bool[] BC00264_n226SecUserOwnerId ;
      private short[] BC00265_A147SecUserUserMan ;
      private bool[] BC00265_n147SecUserUserMan ;
      private short[] BC00268_A133SecUserId ;
      private bool[] BC00268_n133SecUserId ;
      private short[] BC00263_A133SecUserId ;
      private bool[] BC00263_n133SecUserId ;
      private DateTime[] BC00263_A145SecUserCreatedAt ;
      private bool[] BC00263_n145SecUserCreatedAt ;
      private DateTime[] BC00263_A146SecUserUpdateAt ;
      private bool[] BC00263_n146SecUserUpdateAt ;
      private string[] BC00263_A141SecUserName ;
      private bool[] BC00263_n141SecUserName ;
      private string[] BC00263_A143SecUserFullName ;
      private bool[] BC00263_n143SecUserFullName ;
      private string[] BC00263_A144SecUserEmail ;
      private bool[] BC00263_n144SecUserEmail ;
      private bool[] BC00263_A150SecUserStatus ;
      private bool[] BC00263_n150SecUserStatus ;
      private int[] BC00263_A226SecUserOwnerId ;
      private bool[] BC00263_n226SecUserOwnerId ;
      private short[] BC00263_A147SecUserUserMan ;
      private bool[] BC00263_n147SecUserUserMan ;
      private short[] BC00263_A210SecUserClienteId ;
      private bool[] BC00263_n210SecUserClienteId ;
      private short[] BC00262_A133SecUserId ;
      private bool[] BC00262_n133SecUserId ;
      private DateTime[] BC00262_A145SecUserCreatedAt ;
      private bool[] BC00262_n145SecUserCreatedAt ;
      private DateTime[] BC00262_A146SecUserUpdateAt ;
      private bool[] BC00262_n146SecUserUpdateAt ;
      private string[] BC00262_A141SecUserName ;
      private bool[] BC00262_n141SecUserName ;
      private string[] BC00262_A143SecUserFullName ;
      private bool[] BC00262_n143SecUserFullName ;
      private string[] BC00262_A144SecUserEmail ;
      private bool[] BC00262_n144SecUserEmail ;
      private bool[] BC00262_A150SecUserStatus ;
      private bool[] BC00262_n150SecUserStatus ;
      private int[] BC00262_A226SecUserOwnerId ;
      private bool[] BC00262_n226SecUserOwnerId ;
      private short[] BC00262_A147SecUserUserMan ;
      private bool[] BC00262_n147SecUserUserMan ;
      private short[] BC00262_A210SecUserClienteId ;
      private bool[] BC00262_n210SecUserClienteId ;
      private short[] BC002610_A133SecUserId ;
      private bool[] BC002610_n133SecUserId ;
      private short[] BC002613_A210SecUserClienteId ;
      private bool[] BC002613_n210SecUserClienteId ;
      private short[] BC002614_A147SecUserUserMan ;
      private bool[] BC002614_n147SecUserUserMan ;
      private int[] BC002615_A961ChavePIXId ;
      private int[] BC002616_A961ChavePIXId ;
      private int[] BC002617_A951ContaBancariaId ;
      private int[] BC002618_A951ContaBancariaId ;
      private int[] BC002619_A938AgenciaId ;
      private int[] BC002620_A938AgenciaId ;
      private int[] BC002621_A863TaxasId ;
      private int[] BC002622_A863TaxasId ;
      private int[] BC002623_A856CreditoId ;
      private int[] BC002624_A856CreditoId ;
      private int[] BC002625_A746ReembolsoFlowLogId ;
      private int[] BC002626_A599ClienteDocumentoId ;
      private int[] BC002627_A457EspecialidadeId ;
      private int[] BC002628_A518ReembolsoId ;
      private int[] BC002629_A387UserNotificationId ;
      private int[] BC002630_A323PropostaId ;
      private int[] BC002631_A559SecUserLogId ;
      private int[] BC002632_A478ConfiguracoesTestemunhasId ;
      private int[] BC002633_A381NotificationId ;
      private int[] BC002634_A375AprovadoresId ;
      private short[] BC002635_A164SecUserTokenID ;
      private short[] BC002636_A133SecUserId ;
      private bool[] BC002636_n133SecUserId ;
      private short[] BC002636_A131SecRoleId ;
      private short[] BC002637_A133SecUserId ;
      private bool[] BC002637_n133SecUserId ;
      private DateTime[] BC002637_A145SecUserCreatedAt ;
      private bool[] BC002637_n145SecUserCreatedAt ;
      private DateTime[] BC002637_A146SecUserUpdateAt ;
      private bool[] BC002637_n146SecUserUpdateAt ;
      private string[] BC002637_A141SecUserName ;
      private bool[] BC002637_n141SecUserName ;
      private string[] BC002637_A143SecUserFullName ;
      private bool[] BC002637_n143SecUserFullName ;
      private string[] BC002637_A144SecUserEmail ;
      private bool[] BC002637_n144SecUserEmail ;
      private bool[] BC002637_A150SecUserStatus ;
      private bool[] BC002637_n150SecUserStatus ;
      private int[] BC002637_A226SecUserOwnerId ;
      private bool[] BC002637_n226SecUserOwnerId ;
      private short[] BC002637_A147SecUserUserMan ;
      private bool[] BC002637_n147SecUserUserMan ;
      private short[] BC002637_A210SecUserClienteId ;
      private bool[] BC002637_n210SecUserClienteId ;
      private SdtUsuario bcUsuario ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class usuario_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00262;
          prmBC00262 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00263;
          prmBC00263 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00264;
          prmBC00264 = new Object[] {
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00265;
          prmBC00265 = new Object[] {
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00266;
          prmBC00266 = new Object[] {
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00267;
          prmBC00267 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00268;
          prmBC00268 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00269;
          prmBC00269 = new Object[] {
          new ParDef("SecUserCreatedAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserUpdateAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserName",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserFullName",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("SecUserEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002610;
          prmBC002610 = new Object[] {
          };
          Object[] prmBC002611;
          prmBC002611 = new Object[] {
          new ParDef("SecUserCreatedAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserUpdateAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserName",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserFullName",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("SecUserEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002612;
          prmBC002612 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002613;
          prmBC002613 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002614;
          prmBC002614 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002615;
          prmBC002615 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002616;
          prmBC002616 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002617;
          prmBC002617 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002618;
          prmBC002618 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002619;
          prmBC002619 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002620;
          prmBC002620 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002621;
          prmBC002621 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002622;
          prmBC002622 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002623;
          prmBC002623 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002624;
          prmBC002624 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002625;
          prmBC002625 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002626;
          prmBC002626 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002627;
          prmBC002627 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002628;
          prmBC002628 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002629;
          prmBC002629 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002630;
          prmBC002630 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002631;
          prmBC002631 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002632;
          prmBC002632 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002633;
          prmBC002633 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002634;
          prmBC002634 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002635;
          prmBC002635 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002636;
          prmBC002636 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002637;
          prmBC002637 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC00262", "SELECT SecUserId, SecUserCreatedAt, SecUserUpdateAt, SecUserName, SecUserFullName, SecUserEmail, SecUserStatus, SecUserOwnerId, SecUserUserMan, SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserId  FOR UPDATE OF SecUser",true, GxErrorMask.GX_NOMASK, false, this,prmBC00262,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00263", "SELECT SecUserId, SecUserCreatedAt, SecUserUpdateAt, SecUserName, SecUserFullName, SecUserEmail, SecUserStatus, SecUserOwnerId, SecUserUserMan, SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00263,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00264", "SELECT ClienteId AS SecUserOwnerId FROM Cliente WHERE ClienteId = :SecUserOwnerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00264,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00265", "SELECT SecUserId AS SecUserUserMan FROM SecUser WHERE SecUserId = :SecUserUserMan ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00265,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00266", "SELECT SecUserId AS SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00266,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00267", "SELECT TM1.SecUserId, TM1.SecUserCreatedAt, TM1.SecUserUpdateAt, TM1.SecUserName, TM1.SecUserFullName, TM1.SecUserEmail, TM1.SecUserStatus, TM1.SecUserOwnerId AS SecUserOwnerId, TM1.SecUserUserMan AS SecUserUserMan, TM1.SecUserClienteId AS SecUserClienteId FROM SecUser TM1 WHERE TM1.SecUserId = :SecUserId ORDER BY TM1.SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00267,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00268", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00268,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00269", "SAVEPOINT gxupdate;INSERT INTO SecUser(SecUserCreatedAt, SecUserUpdateAt, SecUserName, SecUserFullName, SecUserEmail, SecUserStatus, SecUserOwnerId, SecUserUserMan, SecUserClienteId, SecUserPassword, SecUserTeste, SecUserTemp, SecUserClienteAcesso, SecUserAnalista) VALUES(:SecUserCreatedAt, :SecUserUpdateAt, :SecUserName, :SecUserFullName, :SecUserEmail, :SecUserStatus, :SecUserOwnerId, :SecUserUserMan, :SecUserClienteId, '', '', FALSE, FALSE, FALSE);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00269)
             ,new CursorDef("BC002610", "SELECT currval('SecUserId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002611", "SAVEPOINT gxupdate;UPDATE SecUser SET SecUserCreatedAt=:SecUserCreatedAt, SecUserUpdateAt=:SecUserUpdateAt, SecUserName=:SecUserName, SecUserFullName=:SecUserFullName, SecUserEmail=:SecUserEmail, SecUserStatus=:SecUserStatus, SecUserOwnerId=:SecUserOwnerId, SecUserUserMan=:SecUserUserMan, SecUserClienteId=:SecUserClienteId  WHERE SecUserId = :SecUserId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002611)
             ,new CursorDef("BC002612", "SAVEPOINT gxupdate;DELETE FROM SecUser  WHERE SecUserId = :SecUserId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002612)
             ,new CursorDef("BC002613", "SELECT SecUserId AS SecUserClienteId FROM SecUser WHERE SecUserClienteId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002613,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002614", "SELECT SecUserId AS SecUserUserMan FROM SecUser WHERE SecUserUserMan = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002614,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002615", "SELECT ChavePIXId FROM ChavePIX WHERE ChavePIXUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002615,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002616", "SELECT ChavePIXId FROM ChavePIX WHERE ChavePIXCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002616,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002617", "SELECT ContaBancariaId FROM ContaBancaria WHERE ContaBancariaUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002617,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002618", "SELECT ContaBancariaId FROM ContaBancaria WHERE ContaBancariaCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002618,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002619", "SELECT AgenciaId FROM Agencia WHERE AgenciaUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002619,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002620", "SELECT AgenciaId FROM Agencia WHERE AgenciaCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002620,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002621", "SELECT TaxasId FROM Taxas WHERE TaxasUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002621,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002622", "SELECT TaxasId FROM Taxas WHERE TaxasCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002622,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002623", "SELECT CreditoId FROM Credito WHERE CreditoUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002623,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002624", "SELECT CreditoId FROM Credito WHERE CreditoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002624,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002625", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogUser = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002625,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002626", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE ClienteDocumentoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002626,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002627", "SELECT EspecialidadeId FROM Especialidade WHERE EspecialidadeCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002627,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002628", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002628,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002629", "SELECT UserNotificationId FROM UserNotification WHERE UserNotificationUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002629,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002630", "SELECT PropostaId FROM Proposta WHERE PropostaCratedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002630,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002631", "SELECT SecUserLogId FROM SecUserLog WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002631,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002632", "SELECT ConfiguracoesTestemunhasId FROM ConfiguracoesTestemunhas WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002632,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002633", "SELECT NotificationId FROM Notification WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002633,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002634", "SELECT AprovadoresId FROM Aprovadores WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002634,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002635", "SELECT SecUserTokenID FROM SecUserToken WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002635,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002636", "SELECT SecUserId, SecRoleId FROM SecUserRole WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002636,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002637", "SELECT TM1.SecUserId, TM1.SecUserCreatedAt, TM1.SecUserUpdateAt, TM1.SecUserName, TM1.SecUserFullName, TM1.SecUserEmail, TM1.SecUserStatus, TM1.SecUserOwnerId AS SecUserOwnerId, TM1.SecUserUserMan AS SecUserUserMan, TM1.SecUserClienteId AS SecUserClienteId FROM SecUser TM1 WHERE TM1.SecUserId = :SecUserId ORDER BY TM1.SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002637,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 16 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 17 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 21 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 22 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 23 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 24 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 25 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 26 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 27 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 28 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 29 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 31 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 32 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 33 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 34 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 35 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((int[]) buf[13])[0] = rslt.getInt(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((short[]) buf[15])[0] = rslt.getShort(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
