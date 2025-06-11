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
   public class secusercliente_bc : GxSilentTrn, IGxSilentTrn
   {
      public secusercliente_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secusercliente_bc( IGxContext context )
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
         ReadRow0U22( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0U22( ) ;
         standaloneModal( ) ;
         AddRow0U22( ) ;
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
            E110U2 ();
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

      protected void CONFIRM_0U0( )
      {
         BeforeValidate0U22( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0U22( ) ;
            }
            else
            {
               CheckExtendedTable0U22( ) ;
               if ( AnyError == 0 )
               {
                  ZM0U22( 15) ;
                  ZM0U22( 16) ;
                  ZM0U22( 17) ;
               }
               CloseExtendedTableCursors0U22( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120U2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            while ( AV26GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "SecUserUserMan") == 0 )
               {
                  AV11Insert_SecUserUserMan = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "SecUserClienteId") == 0 )
               {
                  AV12Insert_SecUserClienteId = (short)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "SecUserOwnerId") == 0 )
               {
                  AV23Insert_SecUserOwnerId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV26GXV1 = (int)(AV26GXV1+1);
            }
         }
      }

      protected void E110U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0U22( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z145SecUserCreatedAt = A145SecUserCreatedAt;
            Z146SecUserUpdateAt = A146SecUserUpdateAt;
            Z143SecUserFullName = A143SecUserFullName;
            Z141SecUserName = A141SecUserName;
            Z144SecUserEmail = A144SecUserEmail;
            Z150SecUserStatus = A150SecUserStatus;
            Z142SecUserPassword = A142SecUserPassword;
            Z208SecUserTemp = A208SecUserTemp;
            Z209SecUserClienteAcesso = A209SecUserClienteAcesso;
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
            Z143SecUserFullName = A143SecUserFullName;
            Z141SecUserName = A141SecUserName;
            Z144SecUserEmail = A144SecUserEmail;
            Z150SecUserStatus = A150SecUserStatus;
            Z142SecUserPassword = A142SecUserPassword;
            Z208SecUserTemp = A208SecUserTemp;
            Z209SecUserClienteAcesso = A209SecUserClienteAcesso;
            Z153SecUserTeste = A153SecUserTeste;
            Z226SecUserOwnerId = A226SecUserOwnerId;
            Z147SecUserUserMan = A147SecUserUserMan;
            Z210SecUserClienteId = A210SecUserClienteId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV25Pgmname = "SecUserCliente_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n145SecUserCreatedAt = false;
         }
         if ( IsUpd( )  )
         {
            A146SecUserUpdateAt = DateTimeUtil.ServerNow( context, pr_default);
            n146SecUserUpdateAt = false;
         }
         if ( IsIns( )  )
         {
            A210SecUserClienteId = AV8WWPContext.gxTpr_Userid;
            n210SecUserClienteId = false;
         }
         A226SecUserOwnerId = AV8WWPContext.gxTpr_Ownerid;
         n226SecUserOwnerId = false;
         A147SecUserUserMan = AV8WWPContext.gxTpr_Userid;
         n147SecUserUserMan = false;
         if ( IsIns( )  && (false==A209SecUserClienteAcesso) && ( Gx_BScreen == 0 ) )
         {
            A209SecUserClienteAcesso = true;
            n209SecUserClienteAcesso = false;
         }
         if ( IsIns( )  && (false==A208SecUserTemp) && ( Gx_BScreen == 0 ) )
         {
            A208SecUserTemp = false;
            n208SecUserTemp = false;
         }
      }

      protected void Load0U22( )
      {
         /* Using cursor BC000U7 */
         pr_default.execute(5, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound22 = 1;
            A145SecUserCreatedAt = BC000U7_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = BC000U7_n145SecUserCreatedAt[0];
            A146SecUserUpdateAt = BC000U7_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = BC000U7_n146SecUserUpdateAt[0];
            A143SecUserFullName = BC000U7_A143SecUserFullName[0];
            n143SecUserFullName = BC000U7_n143SecUserFullName[0];
            A141SecUserName = BC000U7_A141SecUserName[0];
            n141SecUserName = BC000U7_n141SecUserName[0];
            A144SecUserEmail = BC000U7_A144SecUserEmail[0];
            n144SecUserEmail = BC000U7_n144SecUserEmail[0];
            A150SecUserStatus = BC000U7_A150SecUserStatus[0];
            n150SecUserStatus = BC000U7_n150SecUserStatus[0];
            A142SecUserPassword = BC000U7_A142SecUserPassword[0];
            n142SecUserPassword = BC000U7_n142SecUserPassword[0];
            A208SecUserTemp = BC000U7_A208SecUserTemp[0];
            n208SecUserTemp = BC000U7_n208SecUserTemp[0];
            A209SecUserClienteAcesso = BC000U7_A209SecUserClienteAcesso[0];
            n209SecUserClienteAcesso = BC000U7_n209SecUserClienteAcesso[0];
            A153SecUserTeste = BC000U7_A153SecUserTeste[0];
            n153SecUserTeste = BC000U7_n153SecUserTeste[0];
            A226SecUserOwnerId = BC000U7_A226SecUserOwnerId[0];
            n226SecUserOwnerId = BC000U7_n226SecUserOwnerId[0];
            A147SecUserUserMan = BC000U7_A147SecUserUserMan[0];
            n147SecUserUserMan = BC000U7_n147SecUserUserMan[0];
            A210SecUserClienteId = BC000U7_A210SecUserClienteId[0];
            n210SecUserClienteId = BC000U7_n210SecUserClienteId[0];
            ZM0U22( -14) ;
         }
         pr_default.close(5);
         OnLoadActions0U22( ) ;
      }

      protected void OnLoadActions0U22( )
      {
      }

      protected void CheckExtendedTable0U22( )
      {
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A143SecUserFullName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A141SecUserName)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Usuário", "", "", "", "", "", "", "", ""), 1, "");
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
         /* Using cursor BC000U5 */
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
         /* Using cursor BC000U6 */
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
         /* Using cursor BC000U4 */
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
      }

      protected void CloseExtendedTableCursors0U22( )
      {
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0U22( )
      {
         /* Using cursor BC000U8 */
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
         /* Using cursor BC000U3 */
         pr_default.execute(1, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0U22( 14) ;
            RcdFound22 = 1;
            A133SecUserId = BC000U3_A133SecUserId[0];
            n133SecUserId = BC000U3_n133SecUserId[0];
            A145SecUserCreatedAt = BC000U3_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = BC000U3_n145SecUserCreatedAt[0];
            A146SecUserUpdateAt = BC000U3_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = BC000U3_n146SecUserUpdateAt[0];
            A143SecUserFullName = BC000U3_A143SecUserFullName[0];
            n143SecUserFullName = BC000U3_n143SecUserFullName[0];
            A141SecUserName = BC000U3_A141SecUserName[0];
            n141SecUserName = BC000U3_n141SecUserName[0];
            A144SecUserEmail = BC000U3_A144SecUserEmail[0];
            n144SecUserEmail = BC000U3_n144SecUserEmail[0];
            A150SecUserStatus = BC000U3_A150SecUserStatus[0];
            n150SecUserStatus = BC000U3_n150SecUserStatus[0];
            A142SecUserPassword = BC000U3_A142SecUserPassword[0];
            n142SecUserPassword = BC000U3_n142SecUserPassword[0];
            A208SecUserTemp = BC000U3_A208SecUserTemp[0];
            n208SecUserTemp = BC000U3_n208SecUserTemp[0];
            A209SecUserClienteAcesso = BC000U3_A209SecUserClienteAcesso[0];
            n209SecUserClienteAcesso = BC000U3_n209SecUserClienteAcesso[0];
            A153SecUserTeste = BC000U3_A153SecUserTeste[0];
            n153SecUserTeste = BC000U3_n153SecUserTeste[0];
            A226SecUserOwnerId = BC000U3_A226SecUserOwnerId[0];
            n226SecUserOwnerId = BC000U3_n226SecUserOwnerId[0];
            A147SecUserUserMan = BC000U3_A147SecUserUserMan[0];
            n147SecUserUserMan = BC000U3_n147SecUserUserMan[0];
            A210SecUserClienteId = BC000U3_A210SecUserClienteId[0];
            n210SecUserClienteId = BC000U3_n210SecUserClienteId[0];
            Z133SecUserId = A133SecUserId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0U22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0U22( ) ;
            }
            Gx_mode = sMode22;
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0U22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode22;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0U22( ) ;
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
         CONFIRM_0U0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0U22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000U2 */
            pr_default.execute(0, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z145SecUserCreatedAt != BC000U2_A145SecUserCreatedAt[0] ) || ( Z146SecUserUpdateAt != BC000U2_A146SecUserUpdateAt[0] ) || ( StringUtil.StrCmp(Z143SecUserFullName, BC000U2_A143SecUserFullName[0]) != 0 ) || ( StringUtil.StrCmp(Z141SecUserName, BC000U2_A141SecUserName[0]) != 0 ) || ( StringUtil.StrCmp(Z144SecUserEmail, BC000U2_A144SecUserEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z150SecUserStatus != BC000U2_A150SecUserStatus[0] ) || ( StringUtil.StrCmp(Z142SecUserPassword, BC000U2_A142SecUserPassword[0]) != 0 ) || ( Z208SecUserTemp != BC000U2_A208SecUserTemp[0] ) || ( Z209SecUserClienteAcesso != BC000U2_A209SecUserClienteAcesso[0] ) || ( Z226SecUserOwnerId != BC000U2_A226SecUserOwnerId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z147SecUserUserMan != BC000U2_A147SecUserUserMan[0] ) || ( Z210SecUserClienteId != BC000U2_A210SecUserClienteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUser"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0U22( )
      {
         BeforeValidate0U22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0U22( 0) ;
            CheckOptimisticConcurrency0U22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0U22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U9 */
                     pr_default.execute(7, new Object[] {n145SecUserCreatedAt, A145SecUserCreatedAt, n146SecUserUpdateAt, A146SecUserUpdateAt, n143SecUserFullName, A143SecUserFullName, n141SecUserName, A141SecUserName, n144SecUserEmail, A144SecUserEmail, n150SecUserStatus, A150SecUserStatus, n142SecUserPassword, A142SecUserPassword, n208SecUserTemp, A208SecUserTemp, n209SecUserClienteAcesso, A209SecUserClienteAcesso, n153SecUserTeste, A153SecUserTeste, n226SecUserOwnerId, A226SecUserOwnerId, n147SecUserUserMan, A147SecUserUserMan, n210SecUserClienteId, A210SecUserClienteId});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000U10 */
                     pr_default.execute(8);
                     A133SecUserId = BC000U10_A133SecUserId[0];
                     n133SecUserId = BC000U10_n133SecUserId[0];
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
               Load0U22( ) ;
            }
            EndLevel0U22( ) ;
         }
         CloseExtendedTableCursors0U22( ) ;
      }

      protected void Update0U22( )
      {
         BeforeValidate0U22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0U22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U11 */
                     pr_default.execute(9, new Object[] {n145SecUserCreatedAt, A145SecUserCreatedAt, n146SecUserUpdateAt, A146SecUserUpdateAt, n143SecUserFullName, A143SecUserFullName, n141SecUserName, A141SecUserName, n144SecUserEmail, A144SecUserEmail, n150SecUserStatus, A150SecUserStatus, n142SecUserPassword, A142SecUserPassword, n208SecUserTemp, A208SecUserTemp, n209SecUserClienteAcesso, A209SecUserClienteAcesso, n153SecUserTeste, A153SecUserTeste, n226SecUserOwnerId, A226SecUserOwnerId, n147SecUserUserMan, A147SecUserUserMan, n210SecUserClienteId, A210SecUserClienteId, n133SecUserId, A133SecUserId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("SecUser");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0U22( ) ;
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
            EndLevel0U22( ) ;
         }
         CloseExtendedTableCursors0U22( ) ;
      }

      protected void DeferredUpdate0U22( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0U22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0U22( ) ;
            AfterConfirm0U22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0U22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000U12 */
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
         EndLevel0U22( ) ;
         Gx_mode = sMode22;
      }

      protected void OnDeleteControls0U22( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000U13 */
            pr_default.execute(11, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000U14 */
            pr_default.execute(12, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000U15 */
            pr_default.execute(13, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Chave PIX"+" ("+"Sb Chave PIXUpdated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000U16 */
            pr_default.execute(14, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Chave PIX"+" ("+"Sb Chave PIXCreated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor BC000U17 */
            pr_default.execute(15, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conta Bancaria"+" ("+"Sb Conta Bancaria Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor BC000U18 */
            pr_default.execute(16, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conta Bancaria"+" ("+"Sb Conta Bancaria Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor BC000U19 */
            pr_default.execute(17, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agencia"+" ("+"Sb Agencia Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor BC000U20 */
            pr_default.execute(18, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agencia"+" ("+"Sb Agencia Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor BC000U21 */
            pr_default.execute(19, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Taxas"+" ("+"Sb Taxas Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor BC000U22 */
            pr_default.execute(20, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Taxas"+" ("+"Sb Taxas Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor BC000U23 */
            pr_default.execute(21, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"+" ("+"Sb Updated By Credito"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor BC000U24 */
            pr_default.execute(22, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"+" ("+"Sdb Credito Usuario"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor BC000U25 */
            pr_default.execute(23, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoFlowLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor BC000U26 */
            pr_default.execute(24, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor BC000U27 */
            pr_default.execute(25, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Especialidade"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor BC000U28 */
            pr_default.execute(26, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor BC000U29 */
            pr_default.execute(27, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"UserNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor BC000U30 */
            pr_default.execute(28, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor BC000U31 */
            pr_default.execute(29, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SecUserLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor BC000U32 */
            pr_default.execute(30, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ConfiguracoesTestemunhas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor BC000U33 */
            pr_default.execute(31, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Notification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor BC000U34 */
            pr_default.execute(32, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor BC000U35 */
            pr_default.execute(33, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sec User UID"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor BC000U36 */
            pr_default.execute(34, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sec User Role"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
         }
      }

      protected void EndLevel0U22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0U22( ) ;
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

      public void ScanKeyStart0U22( )
      {
         /* Scan By routine */
         /* Using cursor BC000U37 */
         pr_default.execute(35, new Object[] {n133SecUserId, A133SecUserId});
         RcdFound22 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound22 = 1;
            A133SecUserId = BC000U37_A133SecUserId[0];
            n133SecUserId = BC000U37_n133SecUserId[0];
            A145SecUserCreatedAt = BC000U37_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = BC000U37_n145SecUserCreatedAt[0];
            A146SecUserUpdateAt = BC000U37_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = BC000U37_n146SecUserUpdateAt[0];
            A143SecUserFullName = BC000U37_A143SecUserFullName[0];
            n143SecUserFullName = BC000U37_n143SecUserFullName[0];
            A141SecUserName = BC000U37_A141SecUserName[0];
            n141SecUserName = BC000U37_n141SecUserName[0];
            A144SecUserEmail = BC000U37_A144SecUserEmail[0];
            n144SecUserEmail = BC000U37_n144SecUserEmail[0];
            A150SecUserStatus = BC000U37_A150SecUserStatus[0];
            n150SecUserStatus = BC000U37_n150SecUserStatus[0];
            A142SecUserPassword = BC000U37_A142SecUserPassword[0];
            n142SecUserPassword = BC000U37_n142SecUserPassword[0];
            A208SecUserTemp = BC000U37_A208SecUserTemp[0];
            n208SecUserTemp = BC000U37_n208SecUserTemp[0];
            A209SecUserClienteAcesso = BC000U37_A209SecUserClienteAcesso[0];
            n209SecUserClienteAcesso = BC000U37_n209SecUserClienteAcesso[0];
            A153SecUserTeste = BC000U37_A153SecUserTeste[0];
            n153SecUserTeste = BC000U37_n153SecUserTeste[0];
            A226SecUserOwnerId = BC000U37_A226SecUserOwnerId[0];
            n226SecUserOwnerId = BC000U37_n226SecUserOwnerId[0];
            A147SecUserUserMan = BC000U37_A147SecUserUserMan[0];
            n147SecUserUserMan = BC000U37_n147SecUserUserMan[0];
            A210SecUserClienteId = BC000U37_A210SecUserClienteId[0];
            n210SecUserClienteId = BC000U37_n210SecUserClienteId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0U22( )
      {
         /* Scan next routine */
         pr_default.readNext(35);
         RcdFound22 = 0;
         ScanKeyLoad0U22( ) ;
      }

      protected void ScanKeyLoad0U22( )
      {
         sMode22 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound22 = 1;
            A133SecUserId = BC000U37_A133SecUserId[0];
            n133SecUserId = BC000U37_n133SecUserId[0];
            A145SecUserCreatedAt = BC000U37_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = BC000U37_n145SecUserCreatedAt[0];
            A146SecUserUpdateAt = BC000U37_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = BC000U37_n146SecUserUpdateAt[0];
            A143SecUserFullName = BC000U37_A143SecUserFullName[0];
            n143SecUserFullName = BC000U37_n143SecUserFullName[0];
            A141SecUserName = BC000U37_A141SecUserName[0];
            n141SecUserName = BC000U37_n141SecUserName[0];
            A144SecUserEmail = BC000U37_A144SecUserEmail[0];
            n144SecUserEmail = BC000U37_n144SecUserEmail[0];
            A150SecUserStatus = BC000U37_A150SecUserStatus[0];
            n150SecUserStatus = BC000U37_n150SecUserStatus[0];
            A142SecUserPassword = BC000U37_A142SecUserPassword[0];
            n142SecUserPassword = BC000U37_n142SecUserPassword[0];
            A208SecUserTemp = BC000U37_A208SecUserTemp[0];
            n208SecUserTemp = BC000U37_n208SecUserTemp[0];
            A209SecUserClienteAcesso = BC000U37_A209SecUserClienteAcesso[0];
            n209SecUserClienteAcesso = BC000U37_n209SecUserClienteAcesso[0];
            A153SecUserTeste = BC000U37_A153SecUserTeste[0];
            n153SecUserTeste = BC000U37_n153SecUserTeste[0];
            A226SecUserOwnerId = BC000U37_A226SecUserOwnerId[0];
            n226SecUserOwnerId = BC000U37_n226SecUserOwnerId[0];
            A147SecUserUserMan = BC000U37_A147SecUserUserMan[0];
            n147SecUserUserMan = BC000U37_n147SecUserUserMan[0];
            A210SecUserClienteId = BC000U37_A210SecUserClienteId[0];
            n210SecUserClienteId = BC000U37_n210SecUserClienteId[0];
         }
         Gx_mode = sMode22;
      }

      protected void ScanKeyEnd0U22( )
      {
         pr_default.close(35);
      }

      protected void AfterConfirm0U22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0U22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0U22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0U22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0U22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0U22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0U22( )
      {
      }

      protected void send_integrity_lvl_hashes0U22( )
      {
      }

      protected void AddRow0U22( )
      {
         VarsToRow22( bcSecUserCliente) ;
      }

      protected void ReadRow0U22( )
      {
         RowToVars22( bcSecUserCliente, 1) ;
      }

      protected void InitializeNonKey0U22( )
      {
         A145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         n145SecUserCreatedAt = false;
         A210SecUserClienteId = 0;
         n210SecUserClienteId = false;
         A226SecUserOwnerId = 0;
         n226SecUserOwnerId = false;
         A146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         n146SecUserUpdateAt = false;
         A147SecUserUserMan = 0;
         n147SecUserUserMan = false;
         A143SecUserFullName = "";
         n143SecUserFullName = false;
         A141SecUserName = "";
         n141SecUserName = false;
         A144SecUserEmail = "";
         n144SecUserEmail = false;
         A150SecUserStatus = false;
         n150SecUserStatus = false;
         A142SecUserPassword = "";
         n142SecUserPassword = false;
         A153SecUserTeste = "";
         n153SecUserTeste = false;
         A208SecUserTemp = false;
         n208SecUserTemp = false;
         A209SecUserClienteAcesso = true;
         n209SecUserClienteAcesso = false;
         Z145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         Z146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         Z143SecUserFullName = "";
         Z141SecUserName = "";
         Z144SecUserEmail = "";
         Z150SecUserStatus = false;
         Z142SecUserPassword = "";
         Z208SecUserTemp = false;
         Z209SecUserClienteAcesso = false;
         Z226SecUserOwnerId = 0;
         Z147SecUserUserMan = 0;
         Z210SecUserClienteId = 0;
      }

      protected void InitAll0U22( )
      {
         A133SecUserId = 0;
         n133SecUserId = false;
         InitializeNonKey0U22( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A145SecUserCreatedAt = i145SecUserCreatedAt;
         n145SecUserCreatedAt = false;
         A210SecUserClienteId = i210SecUserClienteId;
         n210SecUserClienteId = false;
         A209SecUserClienteAcesso = i209SecUserClienteAcesso;
         n209SecUserClienteAcesso = false;
         A208SecUserTemp = i208SecUserTemp;
         n208SecUserTemp = false;
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

      public void VarsToRow22( SdtSecUserCliente obj22 )
      {
         obj22.gxTpr_Mode = Gx_mode;
         obj22.gxTpr_Secusercreatedat = A145SecUserCreatedAt;
         obj22.gxTpr_Secuserclienteid = A210SecUserClienteId;
         obj22.gxTpr_Secuserownerid = A226SecUserOwnerId;
         obj22.gxTpr_Secuserupdateat = A146SecUserUpdateAt;
         obj22.gxTpr_Secuseruserman = A147SecUserUserMan;
         obj22.gxTpr_Secuserfullname = A143SecUserFullName;
         obj22.gxTpr_Secusername = A141SecUserName;
         obj22.gxTpr_Secuseremail = A144SecUserEmail;
         obj22.gxTpr_Secuserstatus = A150SecUserStatus;
         obj22.gxTpr_Secuserpassword = A142SecUserPassword;
         obj22.gxTpr_Secuserteste = A153SecUserTeste;
         obj22.gxTpr_Secusertemp = A208SecUserTemp;
         obj22.gxTpr_Secuserclienteacesso = A209SecUserClienteAcesso;
         obj22.gxTpr_Secuserid = A133SecUserId;
         obj22.gxTpr_Secuserid_Z = Z133SecUserId;
         obj22.gxTpr_Secuserfullname_Z = Z143SecUserFullName;
         obj22.gxTpr_Secusername_Z = Z141SecUserName;
         obj22.gxTpr_Secuseremail_Z = Z144SecUserEmail;
         obj22.gxTpr_Secuserstatus_Z = Z150SecUserStatus;
         obj22.gxTpr_Secuserpassword_Z = Z142SecUserPassword;
         obj22.gxTpr_Secusercreatedat_Z = Z145SecUserCreatedAt;
         obj22.gxTpr_Secuserupdateat_Z = Z146SecUserUpdateAt;
         obj22.gxTpr_Secuseruserman_Z = Z147SecUserUserMan;
         obj22.gxTpr_Secusertemp_Z = Z208SecUserTemp;
         obj22.gxTpr_Secuserclienteacesso_Z = Z209SecUserClienteAcesso;
         obj22.gxTpr_Secuserclienteid_Z = Z210SecUserClienteId;
         obj22.gxTpr_Secuserownerid_Z = Z226SecUserOwnerId;
         obj22.gxTpr_Secuserid_N = (short)(Convert.ToInt16(n133SecUserId));
         obj22.gxTpr_Secuserfullname_N = (short)(Convert.ToInt16(n143SecUserFullName));
         obj22.gxTpr_Secusername_N = (short)(Convert.ToInt16(n141SecUserName));
         obj22.gxTpr_Secuseremail_N = (short)(Convert.ToInt16(n144SecUserEmail));
         obj22.gxTpr_Secuserstatus_N = (short)(Convert.ToInt16(n150SecUserStatus));
         obj22.gxTpr_Secuserpassword_N = (short)(Convert.ToInt16(n142SecUserPassword));
         obj22.gxTpr_Secusercreatedat_N = (short)(Convert.ToInt16(n145SecUserCreatedAt));
         obj22.gxTpr_Secuserupdateat_N = (short)(Convert.ToInt16(n146SecUserUpdateAt));
         obj22.gxTpr_Secuseruserman_N = (short)(Convert.ToInt16(n147SecUserUserMan));
         obj22.gxTpr_Secusertemp_N = (short)(Convert.ToInt16(n208SecUserTemp));
         obj22.gxTpr_Secuserclienteacesso_N = (short)(Convert.ToInt16(n209SecUserClienteAcesso));
         obj22.gxTpr_Secuserteste_N = (short)(Convert.ToInt16(n153SecUserTeste));
         obj22.gxTpr_Secuserclienteid_N = (short)(Convert.ToInt16(n210SecUserClienteId));
         obj22.gxTpr_Secuserownerid_N = (short)(Convert.ToInt16(n226SecUserOwnerId));
         obj22.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow22( SdtSecUserCliente obj22 )
      {
         obj22.gxTpr_Secuserid = A133SecUserId;
         return  ;
      }

      public void RowToVars22( SdtSecUserCliente obj22 ,
                               int forceLoad )
      {
         Gx_mode = obj22.gxTpr_Mode;
         A145SecUserCreatedAt = obj22.gxTpr_Secusercreatedat;
         n145SecUserCreatedAt = false;
         A210SecUserClienteId = obj22.gxTpr_Secuserclienteid;
         n210SecUserClienteId = false;
         A226SecUserOwnerId = obj22.gxTpr_Secuserownerid;
         n226SecUserOwnerId = false;
         A146SecUserUpdateAt = obj22.gxTpr_Secuserupdateat;
         n146SecUserUpdateAt = false;
         A147SecUserUserMan = obj22.gxTpr_Secuseruserman;
         n147SecUserUserMan = false;
         A143SecUserFullName = obj22.gxTpr_Secuserfullname;
         n143SecUserFullName = false;
         A141SecUserName = obj22.gxTpr_Secusername;
         n141SecUserName = false;
         A144SecUserEmail = obj22.gxTpr_Secuseremail;
         n144SecUserEmail = false;
         A150SecUserStatus = obj22.gxTpr_Secuserstatus;
         n150SecUserStatus = false;
         A142SecUserPassword = obj22.gxTpr_Secuserpassword;
         n142SecUserPassword = false;
         A153SecUserTeste = obj22.gxTpr_Secuserteste;
         n153SecUserTeste = false;
         A208SecUserTemp = obj22.gxTpr_Secusertemp;
         n208SecUserTemp = false;
         A209SecUserClienteAcesso = obj22.gxTpr_Secuserclienteacesso;
         n209SecUserClienteAcesso = false;
         A133SecUserId = obj22.gxTpr_Secuserid;
         n133SecUserId = false;
         Z133SecUserId = obj22.gxTpr_Secuserid_Z;
         Z143SecUserFullName = obj22.gxTpr_Secuserfullname_Z;
         Z141SecUserName = obj22.gxTpr_Secusername_Z;
         Z144SecUserEmail = obj22.gxTpr_Secuseremail_Z;
         Z150SecUserStatus = obj22.gxTpr_Secuserstatus_Z;
         Z142SecUserPassword = obj22.gxTpr_Secuserpassword_Z;
         Z145SecUserCreatedAt = obj22.gxTpr_Secusercreatedat_Z;
         Z146SecUserUpdateAt = obj22.gxTpr_Secuserupdateat_Z;
         Z147SecUserUserMan = obj22.gxTpr_Secuseruserman_Z;
         Z208SecUserTemp = obj22.gxTpr_Secusertemp_Z;
         Z209SecUserClienteAcesso = obj22.gxTpr_Secuserclienteacesso_Z;
         Z210SecUserClienteId = obj22.gxTpr_Secuserclienteid_Z;
         Z226SecUserOwnerId = obj22.gxTpr_Secuserownerid_Z;
         n133SecUserId = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserid_N));
         n143SecUserFullName = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserfullname_N));
         n141SecUserName = (bool)(Convert.ToBoolean(obj22.gxTpr_Secusername_N));
         n144SecUserEmail = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuseremail_N));
         n150SecUserStatus = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserstatus_N));
         n142SecUserPassword = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserpassword_N));
         n145SecUserCreatedAt = (bool)(Convert.ToBoolean(obj22.gxTpr_Secusercreatedat_N));
         n146SecUserUpdateAt = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserupdateat_N));
         n147SecUserUserMan = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuseruserman_N));
         n208SecUserTemp = (bool)(Convert.ToBoolean(obj22.gxTpr_Secusertemp_N));
         n209SecUserClienteAcesso = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserclienteacesso_N));
         n153SecUserTeste = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserteste_N));
         n210SecUserClienteId = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserclienteid_N));
         n226SecUserOwnerId = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserownerid_N));
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
         InitializeNonKey0U22( ) ;
         ScanKeyStart0U22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z133SecUserId = A133SecUserId;
         }
         ZM0U22( -14) ;
         OnLoadActions0U22( ) ;
         AddRow0U22( ) ;
         ScanKeyEnd0U22( ) ;
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
         RowToVars22( bcSecUserCliente, 0) ;
         ScanKeyStart0U22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z133SecUserId = A133SecUserId;
         }
         ZM0U22( -14) ;
         OnLoadActions0U22( ) ;
         AddRow0U22( ) ;
         ScanKeyEnd0U22( ) ;
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0U22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0U22( ) ;
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
                  Update0U22( ) ;
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
                        Insert0U22( ) ;
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
                        Insert0U22( ) ;
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
         RowToVars22( bcSecUserCliente, 1) ;
         SaveImpl( ) ;
         VarsToRow22( bcSecUserCliente) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars22( bcSecUserCliente, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0U22( ) ;
         AfterTrn( ) ;
         VarsToRow22( bcSecUserCliente) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow22( bcSecUserCliente) ;
         }
         else
         {
            SdtSecUserCliente auxBC = new SdtSecUserCliente(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A133SecUserId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSecUserCliente);
               auxBC.Save();
               bcSecUserCliente.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars22( bcSecUserCliente, 1) ;
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
         RowToVars22( bcSecUserCliente, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0U22( ) ;
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
               VarsToRow22( bcSecUserCliente) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow22( bcSecUserCliente) ;
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
         RowToVars22( bcSecUserCliente, 0) ;
         GetKey0U22( ) ;
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
         context.RollbackDataStores("secusercliente_bc",pr_default);
         VarsToRow22( bcSecUserCliente) ;
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
         Gx_mode = bcSecUserCliente.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSecUserCliente.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSecUserCliente )
         {
            bcSecUserCliente = (SdtSecUserCliente)(sdt);
            if ( StringUtil.StrCmp(bcSecUserCliente.gxTpr_Mode, "") == 0 )
            {
               bcSecUserCliente.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow22( bcSecUserCliente) ;
            }
            else
            {
               RowToVars22( bcSecUserCliente, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSecUserCliente.gxTpr_Mode, "") == 0 )
            {
               bcSecUserCliente.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars22( bcSecUserCliente, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSecUserCliente SecUserCliente_BC
      {
         get {
            return bcSecUserCliente ;
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
         AV25Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         A145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         Z146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         A146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         Z143SecUserFullName = "";
         A143SecUserFullName = "";
         Z141SecUserName = "";
         A141SecUserName = "";
         Z144SecUserEmail = "";
         A144SecUserEmail = "";
         Z142SecUserPassword = "";
         A142SecUserPassword = "";
         Z153SecUserTeste = "";
         A153SecUserTeste = "";
         BC000U7_A133SecUserId = new short[1] ;
         BC000U7_n133SecUserId = new bool[] {false} ;
         BC000U7_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000U7_n145SecUserCreatedAt = new bool[] {false} ;
         BC000U7_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC000U7_n146SecUserUpdateAt = new bool[] {false} ;
         BC000U7_A143SecUserFullName = new string[] {""} ;
         BC000U7_n143SecUserFullName = new bool[] {false} ;
         BC000U7_A141SecUserName = new string[] {""} ;
         BC000U7_n141SecUserName = new bool[] {false} ;
         BC000U7_A144SecUserEmail = new string[] {""} ;
         BC000U7_n144SecUserEmail = new bool[] {false} ;
         BC000U7_A150SecUserStatus = new bool[] {false} ;
         BC000U7_n150SecUserStatus = new bool[] {false} ;
         BC000U7_A142SecUserPassword = new string[] {""} ;
         BC000U7_n142SecUserPassword = new bool[] {false} ;
         BC000U7_A208SecUserTemp = new bool[] {false} ;
         BC000U7_n208SecUserTemp = new bool[] {false} ;
         BC000U7_A209SecUserClienteAcesso = new bool[] {false} ;
         BC000U7_n209SecUserClienteAcesso = new bool[] {false} ;
         BC000U7_A153SecUserTeste = new string[] {""} ;
         BC000U7_n153SecUserTeste = new bool[] {false} ;
         BC000U7_A226SecUserOwnerId = new int[1] ;
         BC000U7_n226SecUserOwnerId = new bool[] {false} ;
         BC000U7_A147SecUserUserMan = new short[1] ;
         BC000U7_n147SecUserUserMan = new bool[] {false} ;
         BC000U7_A210SecUserClienteId = new short[1] ;
         BC000U7_n210SecUserClienteId = new bool[] {false} ;
         BC000U5_A147SecUserUserMan = new short[1] ;
         BC000U5_n147SecUserUserMan = new bool[] {false} ;
         BC000U6_A210SecUserClienteId = new short[1] ;
         BC000U6_n210SecUserClienteId = new bool[] {false} ;
         BC000U4_A226SecUserOwnerId = new int[1] ;
         BC000U4_n226SecUserOwnerId = new bool[] {false} ;
         BC000U8_A133SecUserId = new short[1] ;
         BC000U8_n133SecUserId = new bool[] {false} ;
         BC000U3_A133SecUserId = new short[1] ;
         BC000U3_n133SecUserId = new bool[] {false} ;
         BC000U3_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000U3_n145SecUserCreatedAt = new bool[] {false} ;
         BC000U3_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC000U3_n146SecUserUpdateAt = new bool[] {false} ;
         BC000U3_A143SecUserFullName = new string[] {""} ;
         BC000U3_n143SecUserFullName = new bool[] {false} ;
         BC000U3_A141SecUserName = new string[] {""} ;
         BC000U3_n141SecUserName = new bool[] {false} ;
         BC000U3_A144SecUserEmail = new string[] {""} ;
         BC000U3_n144SecUserEmail = new bool[] {false} ;
         BC000U3_A150SecUserStatus = new bool[] {false} ;
         BC000U3_n150SecUserStatus = new bool[] {false} ;
         BC000U3_A142SecUserPassword = new string[] {""} ;
         BC000U3_n142SecUserPassword = new bool[] {false} ;
         BC000U3_A208SecUserTemp = new bool[] {false} ;
         BC000U3_n208SecUserTemp = new bool[] {false} ;
         BC000U3_A209SecUserClienteAcesso = new bool[] {false} ;
         BC000U3_n209SecUserClienteAcesso = new bool[] {false} ;
         BC000U3_A153SecUserTeste = new string[] {""} ;
         BC000U3_n153SecUserTeste = new bool[] {false} ;
         BC000U3_A226SecUserOwnerId = new int[1] ;
         BC000U3_n226SecUserOwnerId = new bool[] {false} ;
         BC000U3_A147SecUserUserMan = new short[1] ;
         BC000U3_n147SecUserUserMan = new bool[] {false} ;
         BC000U3_A210SecUserClienteId = new short[1] ;
         BC000U3_n210SecUserClienteId = new bool[] {false} ;
         sMode22 = "";
         BC000U2_A133SecUserId = new short[1] ;
         BC000U2_n133SecUserId = new bool[] {false} ;
         BC000U2_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000U2_n145SecUserCreatedAt = new bool[] {false} ;
         BC000U2_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC000U2_n146SecUserUpdateAt = new bool[] {false} ;
         BC000U2_A143SecUserFullName = new string[] {""} ;
         BC000U2_n143SecUserFullName = new bool[] {false} ;
         BC000U2_A141SecUserName = new string[] {""} ;
         BC000U2_n141SecUserName = new bool[] {false} ;
         BC000U2_A144SecUserEmail = new string[] {""} ;
         BC000U2_n144SecUserEmail = new bool[] {false} ;
         BC000U2_A150SecUserStatus = new bool[] {false} ;
         BC000U2_n150SecUserStatus = new bool[] {false} ;
         BC000U2_A142SecUserPassword = new string[] {""} ;
         BC000U2_n142SecUserPassword = new bool[] {false} ;
         BC000U2_A208SecUserTemp = new bool[] {false} ;
         BC000U2_n208SecUserTemp = new bool[] {false} ;
         BC000U2_A209SecUserClienteAcesso = new bool[] {false} ;
         BC000U2_n209SecUserClienteAcesso = new bool[] {false} ;
         BC000U2_A153SecUserTeste = new string[] {""} ;
         BC000U2_n153SecUserTeste = new bool[] {false} ;
         BC000U2_A226SecUserOwnerId = new int[1] ;
         BC000U2_n226SecUserOwnerId = new bool[] {false} ;
         BC000U2_A147SecUserUserMan = new short[1] ;
         BC000U2_n147SecUserUserMan = new bool[] {false} ;
         BC000U2_A210SecUserClienteId = new short[1] ;
         BC000U2_n210SecUserClienteId = new bool[] {false} ;
         BC000U10_A133SecUserId = new short[1] ;
         BC000U10_n133SecUserId = new bool[] {false} ;
         BC000U13_A210SecUserClienteId = new short[1] ;
         BC000U13_n210SecUserClienteId = new bool[] {false} ;
         BC000U14_A147SecUserUserMan = new short[1] ;
         BC000U14_n147SecUserUserMan = new bool[] {false} ;
         BC000U15_A961ChavePIXId = new int[1] ;
         BC000U16_A961ChavePIXId = new int[1] ;
         BC000U17_A951ContaBancariaId = new int[1] ;
         BC000U18_A951ContaBancariaId = new int[1] ;
         BC000U19_A938AgenciaId = new int[1] ;
         BC000U20_A938AgenciaId = new int[1] ;
         BC000U21_A863TaxasId = new int[1] ;
         BC000U22_A863TaxasId = new int[1] ;
         BC000U23_A856CreditoId = new int[1] ;
         BC000U24_A856CreditoId = new int[1] ;
         BC000U25_A746ReembolsoFlowLogId = new int[1] ;
         BC000U26_A599ClienteDocumentoId = new int[1] ;
         BC000U27_A457EspecialidadeId = new int[1] ;
         BC000U28_A518ReembolsoId = new int[1] ;
         BC000U29_A387UserNotificationId = new int[1] ;
         BC000U30_A323PropostaId = new int[1] ;
         BC000U31_A559SecUserLogId = new int[1] ;
         BC000U32_A478ConfiguracoesTestemunhasId = new int[1] ;
         BC000U33_A381NotificationId = new int[1] ;
         BC000U34_A375AprovadoresId = new int[1] ;
         BC000U35_A164SecUserTokenID = new short[1] ;
         BC000U36_A133SecUserId = new short[1] ;
         BC000U36_n133SecUserId = new bool[] {false} ;
         BC000U36_A131SecRoleId = new short[1] ;
         BC000U37_A133SecUserId = new short[1] ;
         BC000U37_n133SecUserId = new bool[] {false} ;
         BC000U37_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000U37_n145SecUserCreatedAt = new bool[] {false} ;
         BC000U37_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC000U37_n146SecUserUpdateAt = new bool[] {false} ;
         BC000U37_A143SecUserFullName = new string[] {""} ;
         BC000U37_n143SecUserFullName = new bool[] {false} ;
         BC000U37_A141SecUserName = new string[] {""} ;
         BC000U37_n141SecUserName = new bool[] {false} ;
         BC000U37_A144SecUserEmail = new string[] {""} ;
         BC000U37_n144SecUserEmail = new bool[] {false} ;
         BC000U37_A150SecUserStatus = new bool[] {false} ;
         BC000U37_n150SecUserStatus = new bool[] {false} ;
         BC000U37_A142SecUserPassword = new string[] {""} ;
         BC000U37_n142SecUserPassword = new bool[] {false} ;
         BC000U37_A208SecUserTemp = new bool[] {false} ;
         BC000U37_n208SecUserTemp = new bool[] {false} ;
         BC000U37_A209SecUserClienteAcesso = new bool[] {false} ;
         BC000U37_n209SecUserClienteAcesso = new bool[] {false} ;
         BC000U37_A153SecUserTeste = new string[] {""} ;
         BC000U37_n153SecUserTeste = new bool[] {false} ;
         BC000U37_A226SecUserOwnerId = new int[1] ;
         BC000U37_n226SecUserOwnerId = new bool[] {false} ;
         BC000U37_A147SecUserUserMan = new short[1] ;
         BC000U37_n147SecUserUserMan = new bool[] {false} ;
         BC000U37_A210SecUserClienteId = new short[1] ;
         BC000U37_n210SecUserClienteId = new bool[] {false} ;
         i145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secusercliente_bc__default(),
            new Object[][] {
                new Object[] {
               BC000U2_A133SecUserId, BC000U2_A145SecUserCreatedAt, BC000U2_n145SecUserCreatedAt, BC000U2_A146SecUserUpdateAt, BC000U2_n146SecUserUpdateAt, BC000U2_A143SecUserFullName, BC000U2_n143SecUserFullName, BC000U2_A141SecUserName, BC000U2_n141SecUserName, BC000U2_A144SecUserEmail,
               BC000U2_n144SecUserEmail, BC000U2_A150SecUserStatus, BC000U2_n150SecUserStatus, BC000U2_A142SecUserPassword, BC000U2_n142SecUserPassword, BC000U2_A208SecUserTemp, BC000U2_n208SecUserTemp, BC000U2_A209SecUserClienteAcesso, BC000U2_n209SecUserClienteAcesso, BC000U2_A153SecUserTeste,
               BC000U2_n153SecUserTeste, BC000U2_A226SecUserOwnerId, BC000U2_n226SecUserOwnerId, BC000U2_A147SecUserUserMan, BC000U2_n147SecUserUserMan, BC000U2_A210SecUserClienteId, BC000U2_n210SecUserClienteId
               }
               , new Object[] {
               BC000U3_A133SecUserId, BC000U3_A145SecUserCreatedAt, BC000U3_n145SecUserCreatedAt, BC000U3_A146SecUserUpdateAt, BC000U3_n146SecUserUpdateAt, BC000U3_A143SecUserFullName, BC000U3_n143SecUserFullName, BC000U3_A141SecUserName, BC000U3_n141SecUserName, BC000U3_A144SecUserEmail,
               BC000U3_n144SecUserEmail, BC000U3_A150SecUserStatus, BC000U3_n150SecUserStatus, BC000U3_A142SecUserPassword, BC000U3_n142SecUserPassword, BC000U3_A208SecUserTemp, BC000U3_n208SecUserTemp, BC000U3_A209SecUserClienteAcesso, BC000U3_n209SecUserClienteAcesso, BC000U3_A153SecUserTeste,
               BC000U3_n153SecUserTeste, BC000U3_A226SecUserOwnerId, BC000U3_n226SecUserOwnerId, BC000U3_A147SecUserUserMan, BC000U3_n147SecUserUserMan, BC000U3_A210SecUserClienteId, BC000U3_n210SecUserClienteId
               }
               , new Object[] {
               BC000U4_A226SecUserOwnerId
               }
               , new Object[] {
               BC000U5_A147SecUserUserMan
               }
               , new Object[] {
               BC000U6_A210SecUserClienteId
               }
               , new Object[] {
               BC000U7_A133SecUserId, BC000U7_A145SecUserCreatedAt, BC000U7_n145SecUserCreatedAt, BC000U7_A146SecUserUpdateAt, BC000U7_n146SecUserUpdateAt, BC000U7_A143SecUserFullName, BC000U7_n143SecUserFullName, BC000U7_A141SecUserName, BC000U7_n141SecUserName, BC000U7_A144SecUserEmail,
               BC000U7_n144SecUserEmail, BC000U7_A150SecUserStatus, BC000U7_n150SecUserStatus, BC000U7_A142SecUserPassword, BC000U7_n142SecUserPassword, BC000U7_A208SecUserTemp, BC000U7_n208SecUserTemp, BC000U7_A209SecUserClienteAcesso, BC000U7_n209SecUserClienteAcesso, BC000U7_A153SecUserTeste,
               BC000U7_n153SecUserTeste, BC000U7_A226SecUserOwnerId, BC000U7_n226SecUserOwnerId, BC000U7_A147SecUserUserMan, BC000U7_n147SecUserUserMan, BC000U7_A210SecUserClienteId, BC000U7_n210SecUserClienteId
               }
               , new Object[] {
               BC000U8_A133SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000U10_A133SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000U13_A210SecUserClienteId
               }
               , new Object[] {
               BC000U14_A147SecUserUserMan
               }
               , new Object[] {
               BC000U15_A961ChavePIXId
               }
               , new Object[] {
               BC000U16_A961ChavePIXId
               }
               , new Object[] {
               BC000U17_A951ContaBancariaId
               }
               , new Object[] {
               BC000U18_A951ContaBancariaId
               }
               , new Object[] {
               BC000U19_A938AgenciaId
               }
               , new Object[] {
               BC000U20_A938AgenciaId
               }
               , new Object[] {
               BC000U21_A863TaxasId
               }
               , new Object[] {
               BC000U22_A863TaxasId
               }
               , new Object[] {
               BC000U23_A856CreditoId
               }
               , new Object[] {
               BC000U24_A856CreditoId
               }
               , new Object[] {
               BC000U25_A746ReembolsoFlowLogId
               }
               , new Object[] {
               BC000U26_A599ClienteDocumentoId
               }
               , new Object[] {
               BC000U27_A457EspecialidadeId
               }
               , new Object[] {
               BC000U28_A518ReembolsoId
               }
               , new Object[] {
               BC000U29_A387UserNotificationId
               }
               , new Object[] {
               BC000U30_A323PropostaId
               }
               , new Object[] {
               BC000U31_A559SecUserLogId
               }
               , new Object[] {
               BC000U32_A478ConfiguracoesTestemunhasId
               }
               , new Object[] {
               BC000U33_A381NotificationId
               }
               , new Object[] {
               BC000U34_A375AprovadoresId
               }
               , new Object[] {
               BC000U35_A164SecUserTokenID
               }
               , new Object[] {
               BC000U36_A133SecUserId, BC000U36_A131SecRoleId
               }
               , new Object[] {
               BC000U37_A133SecUserId, BC000U37_A145SecUserCreatedAt, BC000U37_n145SecUserCreatedAt, BC000U37_A146SecUserUpdateAt, BC000U37_n146SecUserUpdateAt, BC000U37_A143SecUserFullName, BC000U37_n143SecUserFullName, BC000U37_A141SecUserName, BC000U37_n141SecUserName, BC000U37_A144SecUserEmail,
               BC000U37_n144SecUserEmail, BC000U37_A150SecUserStatus, BC000U37_n150SecUserStatus, BC000U37_A142SecUserPassword, BC000U37_n142SecUserPassword, BC000U37_A208SecUserTemp, BC000U37_n208SecUserTemp, BC000U37_A209SecUserClienteAcesso, BC000U37_n209SecUserClienteAcesso, BC000U37_A153SecUserTeste,
               BC000U37_n153SecUserTeste, BC000U37_A226SecUserOwnerId, BC000U37_n226SecUserOwnerId, BC000U37_A147SecUserUserMan, BC000U37_n147SecUserUserMan, BC000U37_A210SecUserClienteId, BC000U37_n210SecUserClienteId
               }
            }
         );
         AV25Pgmname = "SecUserCliente_BC";
         Z208SecUserTemp = false;
         n208SecUserTemp = false;
         A208SecUserTemp = false;
         n208SecUserTemp = false;
         i208SecUserTemp = false;
         n208SecUserTemp = false;
         Z209SecUserClienteAcesso = true;
         n209SecUserClienteAcesso = false;
         A209SecUserClienteAcesso = true;
         n209SecUserClienteAcesso = false;
         i209SecUserClienteAcesso = true;
         n209SecUserClienteAcesso = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120U2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z133SecUserId ;
      private short A133SecUserId ;
      private short AV11Insert_SecUserUserMan ;
      private short AV12Insert_SecUserClienteId ;
      private short Z147SecUserUserMan ;
      private short A147SecUserUserMan ;
      private short Z210SecUserClienteId ;
      private short A210SecUserClienteId ;
      private short Gx_BScreen ;
      private short RcdFound22 ;
      private short i210SecUserClienteId ;
      private int trnEnded ;
      private int AV26GXV1 ;
      private int AV23Insert_SecUserOwnerId ;
      private int Z226SecUserOwnerId ;
      private int A226SecUserOwnerId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV25Pgmname ;
      private string sMode22 ;
      private DateTime Z145SecUserCreatedAt ;
      private DateTime A145SecUserCreatedAt ;
      private DateTime Z146SecUserUpdateAt ;
      private DateTime A146SecUserUpdateAt ;
      private DateTime i145SecUserCreatedAt ;
      private bool returnInSub ;
      private bool Z150SecUserStatus ;
      private bool A150SecUserStatus ;
      private bool Z208SecUserTemp ;
      private bool A208SecUserTemp ;
      private bool Z209SecUserClienteAcesso ;
      private bool A209SecUserClienteAcesso ;
      private bool n145SecUserCreatedAt ;
      private bool n146SecUserUpdateAt ;
      private bool n210SecUserClienteId ;
      private bool n226SecUserOwnerId ;
      private bool n147SecUserUserMan ;
      private bool n209SecUserClienteAcesso ;
      private bool n208SecUserTemp ;
      private bool n133SecUserId ;
      private bool n143SecUserFullName ;
      private bool n141SecUserName ;
      private bool n144SecUserEmail ;
      private bool n150SecUserStatus ;
      private bool n142SecUserPassword ;
      private bool n153SecUserTeste ;
      private bool Gx_longc ;
      private bool i209SecUserClienteAcesso ;
      private bool i208SecUserTemp ;
      private string Z153SecUserTeste ;
      private string A153SecUserTeste ;
      private string Z143SecUserFullName ;
      private string A143SecUserFullName ;
      private string Z141SecUserName ;
      private string A141SecUserName ;
      private string Z144SecUserEmail ;
      private string A144SecUserEmail ;
      private string Z142SecUserPassword ;
      private string A142SecUserPassword ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] BC000U7_A133SecUserId ;
      private bool[] BC000U7_n133SecUserId ;
      private DateTime[] BC000U7_A145SecUserCreatedAt ;
      private bool[] BC000U7_n145SecUserCreatedAt ;
      private DateTime[] BC000U7_A146SecUserUpdateAt ;
      private bool[] BC000U7_n146SecUserUpdateAt ;
      private string[] BC000U7_A143SecUserFullName ;
      private bool[] BC000U7_n143SecUserFullName ;
      private string[] BC000U7_A141SecUserName ;
      private bool[] BC000U7_n141SecUserName ;
      private string[] BC000U7_A144SecUserEmail ;
      private bool[] BC000U7_n144SecUserEmail ;
      private bool[] BC000U7_A150SecUserStatus ;
      private bool[] BC000U7_n150SecUserStatus ;
      private string[] BC000U7_A142SecUserPassword ;
      private bool[] BC000U7_n142SecUserPassword ;
      private bool[] BC000U7_A208SecUserTemp ;
      private bool[] BC000U7_n208SecUserTemp ;
      private bool[] BC000U7_A209SecUserClienteAcesso ;
      private bool[] BC000U7_n209SecUserClienteAcesso ;
      private string[] BC000U7_A153SecUserTeste ;
      private bool[] BC000U7_n153SecUserTeste ;
      private int[] BC000U7_A226SecUserOwnerId ;
      private bool[] BC000U7_n226SecUserOwnerId ;
      private short[] BC000U7_A147SecUserUserMan ;
      private bool[] BC000U7_n147SecUserUserMan ;
      private short[] BC000U7_A210SecUserClienteId ;
      private bool[] BC000U7_n210SecUserClienteId ;
      private short[] BC000U5_A147SecUserUserMan ;
      private bool[] BC000U5_n147SecUserUserMan ;
      private short[] BC000U6_A210SecUserClienteId ;
      private bool[] BC000U6_n210SecUserClienteId ;
      private int[] BC000U4_A226SecUserOwnerId ;
      private bool[] BC000U4_n226SecUserOwnerId ;
      private short[] BC000U8_A133SecUserId ;
      private bool[] BC000U8_n133SecUserId ;
      private short[] BC000U3_A133SecUserId ;
      private bool[] BC000U3_n133SecUserId ;
      private DateTime[] BC000U3_A145SecUserCreatedAt ;
      private bool[] BC000U3_n145SecUserCreatedAt ;
      private DateTime[] BC000U3_A146SecUserUpdateAt ;
      private bool[] BC000U3_n146SecUserUpdateAt ;
      private string[] BC000U3_A143SecUserFullName ;
      private bool[] BC000U3_n143SecUserFullName ;
      private string[] BC000U3_A141SecUserName ;
      private bool[] BC000U3_n141SecUserName ;
      private string[] BC000U3_A144SecUserEmail ;
      private bool[] BC000U3_n144SecUserEmail ;
      private bool[] BC000U3_A150SecUserStatus ;
      private bool[] BC000U3_n150SecUserStatus ;
      private string[] BC000U3_A142SecUserPassword ;
      private bool[] BC000U3_n142SecUserPassword ;
      private bool[] BC000U3_A208SecUserTemp ;
      private bool[] BC000U3_n208SecUserTemp ;
      private bool[] BC000U3_A209SecUserClienteAcesso ;
      private bool[] BC000U3_n209SecUserClienteAcesso ;
      private string[] BC000U3_A153SecUserTeste ;
      private bool[] BC000U3_n153SecUserTeste ;
      private int[] BC000U3_A226SecUserOwnerId ;
      private bool[] BC000U3_n226SecUserOwnerId ;
      private short[] BC000U3_A147SecUserUserMan ;
      private bool[] BC000U3_n147SecUserUserMan ;
      private short[] BC000U3_A210SecUserClienteId ;
      private bool[] BC000U3_n210SecUserClienteId ;
      private short[] BC000U2_A133SecUserId ;
      private bool[] BC000U2_n133SecUserId ;
      private DateTime[] BC000U2_A145SecUserCreatedAt ;
      private bool[] BC000U2_n145SecUserCreatedAt ;
      private DateTime[] BC000U2_A146SecUserUpdateAt ;
      private bool[] BC000U2_n146SecUserUpdateAt ;
      private string[] BC000U2_A143SecUserFullName ;
      private bool[] BC000U2_n143SecUserFullName ;
      private string[] BC000U2_A141SecUserName ;
      private bool[] BC000U2_n141SecUserName ;
      private string[] BC000U2_A144SecUserEmail ;
      private bool[] BC000U2_n144SecUserEmail ;
      private bool[] BC000U2_A150SecUserStatus ;
      private bool[] BC000U2_n150SecUserStatus ;
      private string[] BC000U2_A142SecUserPassword ;
      private bool[] BC000U2_n142SecUserPassword ;
      private bool[] BC000U2_A208SecUserTemp ;
      private bool[] BC000U2_n208SecUserTemp ;
      private bool[] BC000U2_A209SecUserClienteAcesso ;
      private bool[] BC000U2_n209SecUserClienteAcesso ;
      private string[] BC000U2_A153SecUserTeste ;
      private bool[] BC000U2_n153SecUserTeste ;
      private int[] BC000U2_A226SecUserOwnerId ;
      private bool[] BC000U2_n226SecUserOwnerId ;
      private short[] BC000U2_A147SecUserUserMan ;
      private bool[] BC000U2_n147SecUserUserMan ;
      private short[] BC000U2_A210SecUserClienteId ;
      private bool[] BC000U2_n210SecUserClienteId ;
      private short[] BC000U10_A133SecUserId ;
      private bool[] BC000U10_n133SecUserId ;
      private short[] BC000U13_A210SecUserClienteId ;
      private bool[] BC000U13_n210SecUserClienteId ;
      private short[] BC000U14_A147SecUserUserMan ;
      private bool[] BC000U14_n147SecUserUserMan ;
      private int[] BC000U15_A961ChavePIXId ;
      private int[] BC000U16_A961ChavePIXId ;
      private int[] BC000U17_A951ContaBancariaId ;
      private int[] BC000U18_A951ContaBancariaId ;
      private int[] BC000U19_A938AgenciaId ;
      private int[] BC000U20_A938AgenciaId ;
      private int[] BC000U21_A863TaxasId ;
      private int[] BC000U22_A863TaxasId ;
      private int[] BC000U23_A856CreditoId ;
      private int[] BC000U24_A856CreditoId ;
      private int[] BC000U25_A746ReembolsoFlowLogId ;
      private int[] BC000U26_A599ClienteDocumentoId ;
      private int[] BC000U27_A457EspecialidadeId ;
      private int[] BC000U28_A518ReembolsoId ;
      private int[] BC000U29_A387UserNotificationId ;
      private int[] BC000U30_A323PropostaId ;
      private int[] BC000U31_A559SecUserLogId ;
      private int[] BC000U32_A478ConfiguracoesTestemunhasId ;
      private int[] BC000U33_A381NotificationId ;
      private int[] BC000U34_A375AprovadoresId ;
      private short[] BC000U35_A164SecUserTokenID ;
      private short[] BC000U36_A133SecUserId ;
      private bool[] BC000U36_n133SecUserId ;
      private short[] BC000U36_A131SecRoleId ;
      private short[] BC000U37_A133SecUserId ;
      private bool[] BC000U37_n133SecUserId ;
      private DateTime[] BC000U37_A145SecUserCreatedAt ;
      private bool[] BC000U37_n145SecUserCreatedAt ;
      private DateTime[] BC000U37_A146SecUserUpdateAt ;
      private bool[] BC000U37_n146SecUserUpdateAt ;
      private string[] BC000U37_A143SecUserFullName ;
      private bool[] BC000U37_n143SecUserFullName ;
      private string[] BC000U37_A141SecUserName ;
      private bool[] BC000U37_n141SecUserName ;
      private string[] BC000U37_A144SecUserEmail ;
      private bool[] BC000U37_n144SecUserEmail ;
      private bool[] BC000U37_A150SecUserStatus ;
      private bool[] BC000U37_n150SecUserStatus ;
      private string[] BC000U37_A142SecUserPassword ;
      private bool[] BC000U37_n142SecUserPassword ;
      private bool[] BC000U37_A208SecUserTemp ;
      private bool[] BC000U37_n208SecUserTemp ;
      private bool[] BC000U37_A209SecUserClienteAcesso ;
      private bool[] BC000U37_n209SecUserClienteAcesso ;
      private string[] BC000U37_A153SecUserTeste ;
      private bool[] BC000U37_n153SecUserTeste ;
      private int[] BC000U37_A226SecUserOwnerId ;
      private bool[] BC000U37_n226SecUserOwnerId ;
      private short[] BC000U37_A147SecUserUserMan ;
      private bool[] BC000U37_n147SecUserUserMan ;
      private short[] BC000U37_A210SecUserClienteId ;
      private bool[] BC000U37_n210SecUserClienteId ;
      private SdtSecUserCliente bcSecUserCliente ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secusercliente_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC000U2;
          prmBC000U2 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U3;
          prmBC000U3 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U4;
          prmBC000U4 = new Object[] {
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000U5;
          prmBC000U5 = new Object[] {
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U6;
          prmBC000U6 = new Object[] {
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U7;
          prmBC000U7 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U8;
          prmBC000U8 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U9;
          prmBC000U9 = new Object[] {
          new ParDef("SecUserCreatedAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserUpdateAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserFullName",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("SecUserName",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserPassword",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserTemp",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserClienteAcesso",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserTeste",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U10;
          prmBC000U10 = new Object[] {
          };
          Object[] prmBC000U11;
          prmBC000U11 = new Object[] {
          new ParDef("SecUserCreatedAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserUpdateAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserFullName",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("SecUserName",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserPassword",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserTemp",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserClienteAcesso",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserTeste",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U12;
          prmBC000U12 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U13;
          prmBC000U13 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U14;
          prmBC000U14 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U15;
          prmBC000U15 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U16;
          prmBC000U16 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U17;
          prmBC000U17 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U18;
          prmBC000U18 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U19;
          prmBC000U19 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U20;
          prmBC000U20 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U21;
          prmBC000U21 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U22;
          prmBC000U22 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U23;
          prmBC000U23 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U24;
          prmBC000U24 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U25;
          prmBC000U25 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U26;
          prmBC000U26 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U27;
          prmBC000U27 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U28;
          prmBC000U28 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U29;
          prmBC000U29 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U30;
          prmBC000U30 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U31;
          prmBC000U31 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U32;
          prmBC000U32 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U33;
          prmBC000U33 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U34;
          prmBC000U34 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U35;
          prmBC000U35 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U36;
          prmBC000U36 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000U37;
          prmBC000U37 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC000U2", "SELECT SecUserId, SecUserCreatedAt, SecUserUpdateAt, SecUserFullName, SecUserName, SecUserEmail, SecUserStatus, SecUserPassword, SecUserTemp, SecUserClienteAcesso, SecUserTeste, SecUserOwnerId, SecUserUserMan, SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserId  FOR UPDATE OF SecUser",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000U3", "SELECT SecUserId, SecUserCreatedAt, SecUserUpdateAt, SecUserFullName, SecUserName, SecUserEmail, SecUserStatus, SecUserPassword, SecUserTemp, SecUserClienteAcesso, SecUserTeste, SecUserOwnerId, SecUserUserMan, SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000U4", "SELECT ClienteId AS SecUserOwnerId FROM Cliente WHERE ClienteId = :SecUserOwnerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000U5", "SELECT SecUserId AS SecUserUserMan FROM SecUser WHERE SecUserId = :SecUserUserMan ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000U6", "SELECT SecUserId AS SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000U7", "SELECT TM1.SecUserId, TM1.SecUserCreatedAt, TM1.SecUserUpdateAt, TM1.SecUserFullName, TM1.SecUserName, TM1.SecUserEmail, TM1.SecUserStatus, TM1.SecUserPassword, TM1.SecUserTemp, TM1.SecUserClienteAcesso, TM1.SecUserTeste, TM1.SecUserOwnerId AS SecUserOwnerId, TM1.SecUserUserMan AS SecUserUserMan, TM1.SecUserClienteId AS SecUserClienteId FROM SecUser TM1 WHERE TM1.SecUserId = :SecUserId ORDER BY TM1.SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000U8", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000U9", "SAVEPOINT gxupdate;INSERT INTO SecUser(SecUserCreatedAt, SecUserUpdateAt, SecUserFullName, SecUserName, SecUserEmail, SecUserStatus, SecUserPassword, SecUserTemp, SecUserClienteAcesso, SecUserTeste, SecUserOwnerId, SecUserUserMan, SecUserClienteId, SecUserAnalista) VALUES(:SecUserCreatedAt, :SecUserUpdateAt, :SecUserFullName, :SecUserName, :SecUserEmail, :SecUserStatus, :SecUserPassword, :SecUserTemp, :SecUserClienteAcesso, :SecUserTeste, :SecUserOwnerId, :SecUserUserMan, :SecUserClienteId, FALSE);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000U9)
             ,new CursorDef("BC000U10", "SELECT currval('SecUserId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000U11", "SAVEPOINT gxupdate;UPDATE SecUser SET SecUserCreatedAt=:SecUserCreatedAt, SecUserUpdateAt=:SecUserUpdateAt, SecUserFullName=:SecUserFullName, SecUserName=:SecUserName, SecUserEmail=:SecUserEmail, SecUserStatus=:SecUserStatus, SecUserPassword=:SecUserPassword, SecUserTemp=:SecUserTemp, SecUserClienteAcesso=:SecUserClienteAcesso, SecUserTeste=:SecUserTeste, SecUserOwnerId=:SecUserOwnerId, SecUserUserMan=:SecUserUserMan, SecUserClienteId=:SecUserClienteId  WHERE SecUserId = :SecUserId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000U11)
             ,new CursorDef("BC000U12", "SAVEPOINT gxupdate;DELETE FROM SecUser  WHERE SecUserId = :SecUserId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000U12)
             ,new CursorDef("BC000U13", "SELECT SecUserId AS SecUserClienteId FROM SecUser WHERE SecUserClienteId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U14", "SELECT SecUserId AS SecUserUserMan FROM SecUser WHERE SecUserUserMan = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U15", "SELECT ChavePIXId FROM ChavePIX WHERE ChavePIXUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U15,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U16", "SELECT ChavePIXId FROM ChavePIX WHERE ChavePIXCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U16,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U17", "SELECT ContaBancariaId FROM ContaBancaria WHERE ContaBancariaUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U17,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U18", "SELECT ContaBancariaId FROM ContaBancaria WHERE ContaBancariaCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U19", "SELECT AgenciaId FROM Agencia WHERE AgenciaUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U19,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U20", "SELECT AgenciaId FROM Agencia WHERE AgenciaCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U20,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U21", "SELECT TaxasId FROM Taxas WHERE TaxasUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U22", "SELECT TaxasId FROM Taxas WHERE TaxasCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U23", "SELECT CreditoId FROM Credito WHERE CreditoUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U23,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U24", "SELECT CreditoId FROM Credito WHERE CreditoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U24,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U25", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogUser = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U25,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U26", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE ClienteDocumentoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U26,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U27", "SELECT EspecialidadeId FROM Especialidade WHERE EspecialidadeCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U27,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U28", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U28,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U29", "SELECT UserNotificationId FROM UserNotification WHERE UserNotificationUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U29,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U30", "SELECT PropostaId FROM Proposta WHERE PropostaCratedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U30,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U31", "SELECT SecUserLogId FROM SecUserLog WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U31,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U32", "SELECT ConfiguracoesTestemunhasId FROM ConfiguracoesTestemunhas WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U32,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U33", "SELECT NotificationId FROM Notification WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U33,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U34", "SELECT AprovadoresId FROM Aprovadores WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U34,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U35", "SELECT SecUserTokenID FROM SecUserToken WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U35,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U36", "SELECT SecUserId, SecRoleId FROM SecUserRole WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U36,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000U37", "SELECT TM1.SecUserId, TM1.SecUserCreatedAt, TM1.SecUserUpdateAt, TM1.SecUserFullName, TM1.SecUserName, TM1.SecUserEmail, TM1.SecUserStatus, TM1.SecUserPassword, TM1.SecUserTemp, TM1.SecUserClienteAcesso, TM1.SecUserTeste, TM1.SecUserOwnerId AS SecUserOwnerId, TM1.SecUserUserMan AS SecUserUserMan, TM1.SecUserClienteId AS SecUserClienteId FROM SecUser TM1 WHERE TM1.SecUserId = :SecUserId ORDER BY TM1.SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U37,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((short[]) buf[23])[0] = rslt.getShort(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
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
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((short[]) buf[23])[0] = rslt.getShort(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
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
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((short[]) buf[23])[0] = rslt.getShort(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
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
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getLongVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((short[]) buf[23])[0] = rslt.getShort(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
       }
    }

 }

}
