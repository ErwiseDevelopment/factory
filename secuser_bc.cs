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
   public class secuser_bc : GxSilentTrn, IGxSilentTrn
   {
      public secuser_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuser_bc( IGxContext context )
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
         ReadRow0I22( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0I22( ) ;
         standaloneModal( ) ;
         AddRow0I22( ) ;
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
            E110I2 ();
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

      protected void CONFIRM_0I0( )
      {
         BeforeValidate0I22( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0I22( ) ;
            }
            else
            {
               CheckExtendedTable0I22( ) ;
               if ( AnyError == 0 )
               {
                  ZM0I22( 15) ;
                  ZM0I22( 16) ;
                  ZM0I22( 17) ;
                  ZM0I22( 18) ;
               }
               CloseExtendedTableCursors0I22( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120I2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV15WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            while ( AV26GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV21TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "SecUserUserMan") == 0 )
               {
                  AV20Insert_SecUserUserMan = (short)(Math.Round(NumberUtil.Val( AV21TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "SecUserClienteId") == 0 )
               {
                  AV22Insert_SecUserClienteId = (short)(Math.Round(NumberUtil.Val( AV21TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV21TrnContextAtt.gxTpr_Attributename, "SecUserOwnerId") == 0 )
               {
                  AV23Insert_SecUserOwnerId = (int)(Math.Round(NumberUtil.Val( AV21TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV26GXV1 = (int)(AV26GXV1+1);
            }
         }
      }

      protected void E110I2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0I22( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z145SecUserCreatedAt = A145SecUserCreatedAt;
            Z141SecUserName = A141SecUserName;
            Z143SecUserFullName = A143SecUserFullName;
            Z144SecUserEmail = A144SecUserEmail;
            Z150SecUserStatus = A150SecUserStatus;
            Z142SecUserPassword = A142SecUserPassword;
            Z791SecUserAnalista = A791SecUserAnalista;
            Z146SecUserUpdateAt = A146SecUserUpdateAt;
            Z208SecUserTemp = A208SecUserTemp;
            Z209SecUserClienteAcesso = A209SecUserClienteAcesso;
            Z226SecUserOwnerId = A226SecUserOwnerId;
            Z147SecUserUserMan = A147SecUserUserMan;
            Z210SecUserClienteId = A210SecUserClienteId;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z192TipoClienteId = A192TipoClienteId;
         }
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            Z148SecUserManName = A148SecUserManName;
            Z149SecUserManFullName = A149SecUserManFullName;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z211SecUserClienteFullName = A211SecUserClienteFullName;
            Z212SecUserClienteStatus = A212SecUserClienteStatus;
            Z213SecUserCliClienteAcesso = A213SecUserCliClienteAcesso;
         }
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z793TipoClientePortalPjPf = A793TipoClientePortalPjPf;
         }
         if ( GX_JID == -14 )
         {
            Z133SecUserId = A133SecUserId;
            Z145SecUserCreatedAt = A145SecUserCreatedAt;
            Z141SecUserName = A141SecUserName;
            Z143SecUserFullName = A143SecUserFullName;
            Z144SecUserEmail = A144SecUserEmail;
            Z150SecUserStatus = A150SecUserStatus;
            Z142SecUserPassword = A142SecUserPassword;
            Z791SecUserAnalista = A791SecUserAnalista;
            Z146SecUserUpdateAt = A146SecUserUpdateAt;
            Z208SecUserTemp = A208SecUserTemp;
            Z209SecUserClienteAcesso = A209SecUserClienteAcesso;
            Z153SecUserTeste = A153SecUserTeste;
            Z226SecUserOwnerId = A226SecUserOwnerId;
            Z147SecUserUserMan = A147SecUserUserMan;
            Z210SecUserClienteId = A210SecUserClienteId;
            Z148SecUserManName = A148SecUserManName;
            Z149SecUserManFullName = A149SecUserManFullName;
            Z211SecUserClienteFullName = A211SecUserClienteFullName;
            Z212SecUserClienteStatus = A212SecUserClienteStatus;
            Z213SecUserCliClienteAcesso = A213SecUserCliClienteAcesso;
            Z192TipoClienteId = A192TipoClienteId;
            Z793TipoClientePortalPjPf = A793TipoClientePortalPjPf;
         }
      }

      protected void standaloneNotModal( )
      {
         AV25Pgmname = "SecUser_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A145SecUserCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n145SecUserCreatedAt = false;
         }
         if ( IsIns( )  && (false==A150SecUserStatus) && ( Gx_BScreen == 0 ) )
         {
            A150SecUserStatus = true;
            n150SecUserStatus = false;
         }
      }

      protected void Load0I22( )
      {
         /* Using cursor BC000I8 */
         pr_default.execute(6, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound22 = 1;
            A192TipoClienteId = BC000I8_A192TipoClienteId[0];
            n192TipoClienteId = BC000I8_n192TipoClienteId[0];
            A145SecUserCreatedAt = BC000I8_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = BC000I8_n145SecUserCreatedAt[0];
            A141SecUserName = BC000I8_A141SecUserName[0];
            n141SecUserName = BC000I8_n141SecUserName[0];
            A143SecUserFullName = BC000I8_A143SecUserFullName[0];
            n143SecUserFullName = BC000I8_n143SecUserFullName[0];
            A144SecUserEmail = BC000I8_A144SecUserEmail[0];
            n144SecUserEmail = BC000I8_n144SecUserEmail[0];
            A150SecUserStatus = BC000I8_A150SecUserStatus[0];
            n150SecUserStatus = BC000I8_n150SecUserStatus[0];
            A142SecUserPassword = BC000I8_A142SecUserPassword[0];
            n142SecUserPassword = BC000I8_n142SecUserPassword[0];
            A791SecUserAnalista = BC000I8_A791SecUserAnalista[0];
            n791SecUserAnalista = BC000I8_n791SecUserAnalista[0];
            A146SecUserUpdateAt = BC000I8_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = BC000I8_n146SecUserUpdateAt[0];
            A148SecUserManName = BC000I8_A148SecUserManName[0];
            n148SecUserManName = BC000I8_n148SecUserManName[0];
            A149SecUserManFullName = BC000I8_A149SecUserManFullName[0];
            n149SecUserManFullName = BC000I8_n149SecUserManFullName[0];
            A208SecUserTemp = BC000I8_A208SecUserTemp[0];
            n208SecUserTemp = BC000I8_n208SecUserTemp[0];
            A209SecUserClienteAcesso = BC000I8_A209SecUserClienteAcesso[0];
            n209SecUserClienteAcesso = BC000I8_n209SecUserClienteAcesso[0];
            A153SecUserTeste = BC000I8_A153SecUserTeste[0];
            n153SecUserTeste = BC000I8_n153SecUserTeste[0];
            A211SecUserClienteFullName = BC000I8_A211SecUserClienteFullName[0];
            n211SecUserClienteFullName = BC000I8_n211SecUserClienteFullName[0];
            A212SecUserClienteStatus = BC000I8_A212SecUserClienteStatus[0];
            n212SecUserClienteStatus = BC000I8_n212SecUserClienteStatus[0];
            A213SecUserCliClienteAcesso = BC000I8_A213SecUserCliClienteAcesso[0];
            n213SecUserCliClienteAcesso = BC000I8_n213SecUserCliClienteAcesso[0];
            A793TipoClientePortalPjPf = BC000I8_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = BC000I8_n793TipoClientePortalPjPf[0];
            A226SecUserOwnerId = BC000I8_A226SecUserOwnerId[0];
            n226SecUserOwnerId = BC000I8_n226SecUserOwnerId[0];
            A147SecUserUserMan = BC000I8_A147SecUserUserMan[0];
            n147SecUserUserMan = BC000I8_n147SecUserUserMan[0];
            A210SecUserClienteId = BC000I8_A210SecUserClienteId[0];
            n210SecUserClienteId = BC000I8_n210SecUserClienteId[0];
            ZM0I22( -14) ;
         }
         pr_default.close(6);
         OnLoadActions0I22( ) ;
      }

      protected void OnLoadActions0I22( )
      {
         if ( (0==A147SecUserUserMan) )
         {
            A147SecUserUserMan = 0;
            n147SecUserUserMan = false;
            n147SecUserUserMan = true;
            n147SecUserUserMan = true;
         }
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
      }

      protected void CheckExtendedTable0I22( )
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
         if ( (0==A147SecUserUserMan) )
         {
            A147SecUserUserMan = 0;
            n147SecUserUserMan = false;
            n147SecUserUserMan = true;
            n147SecUserUserMan = true;
         }
         /* Using cursor BC000I5 */
         pr_default.execute(3, new Object[] {n147SecUserUserMan, A147SecUserUserMan});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A147SecUserUserMan) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Manuten'.", "ForeignKeyNotFound", 1, "SECUSERUSERMAN");
               AnyError = 1;
            }
         }
         A148SecUserManName = BC000I5_A148SecUserManName[0];
         n148SecUserManName = BC000I5_n148SecUserManName[0];
         A149SecUserManFullName = BC000I5_A149SecUserManFullName[0];
         n149SecUserManFullName = BC000I5_n149SecUserManFullName[0];
         pr_default.close(3);
         if ( (0==A210SecUserClienteId) )
         {
            A210SecUserClienteId = 0;
            n210SecUserClienteId = false;
            n210SecUserClienteId = true;
            n210SecUserClienteId = true;
         }
         /* Using cursor BC000I6 */
         pr_default.execute(4, new Object[] {n210SecUserClienteId, A210SecUserClienteId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A210SecUserClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Sec User Cliente User'.", "ForeignKeyNotFound", 1, "SECUSERCLIENTEID");
               AnyError = 1;
            }
         }
         A211SecUserClienteFullName = BC000I6_A211SecUserClienteFullName[0];
         n211SecUserClienteFullName = BC000I6_n211SecUserClienteFullName[0];
         A212SecUserClienteStatus = BC000I6_A212SecUserClienteStatus[0];
         n212SecUserClienteStatus = BC000I6_n212SecUserClienteStatus[0];
         A213SecUserCliClienteAcesso = BC000I6_A213SecUserCliClienteAcesso[0];
         n213SecUserCliClienteAcesso = BC000I6_n213SecUserCliClienteAcesso[0];
         pr_default.close(4);
         if ( (0==A226SecUserOwnerId) )
         {
            A226SecUserOwnerId = 0;
            n226SecUserOwnerId = false;
            n226SecUserOwnerId = true;
            n226SecUserOwnerId = true;
         }
         /* Using cursor BC000I4 */
         pr_default.execute(2, new Object[] {n226SecUserOwnerId, A226SecUserOwnerId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A226SecUserOwnerId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Sec User Owner'.", "ForeignKeyNotFound", 1, "SECUSEROWNERID");
               AnyError = 1;
            }
         }
         A192TipoClienteId = BC000I4_A192TipoClienteId[0];
         n192TipoClienteId = BC000I4_n192TipoClienteId[0];
         pr_default.close(2);
         /* Using cursor BC000I7 */
         pr_default.execute(5, new Object[] {n192TipoClienteId, A192TipoClienteId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A192TipoClienteId) ) )
            {
               GX_msglist.addItem("Não existe 'Tipo Cliente'.", "ForeignKeyNotFound", 1, "TIPOCLIENTEID");
               AnyError = 1;
            }
         }
         A793TipoClientePortalPjPf = BC000I7_A793TipoClientePortalPjPf[0];
         n793TipoClientePortalPjPf = BC000I7_n793TipoClientePortalPjPf[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors0I22( )
      {
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0I22( )
      {
         /* Using cursor BC000I9 */
         pr_default.execute(7, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000I3 */
         pr_default.execute(1, new Object[] {n133SecUserId, A133SecUserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I22( 14) ;
            RcdFound22 = 1;
            A133SecUserId = BC000I3_A133SecUserId[0];
            n133SecUserId = BC000I3_n133SecUserId[0];
            A145SecUserCreatedAt = BC000I3_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = BC000I3_n145SecUserCreatedAt[0];
            A141SecUserName = BC000I3_A141SecUserName[0];
            n141SecUserName = BC000I3_n141SecUserName[0];
            A143SecUserFullName = BC000I3_A143SecUserFullName[0];
            n143SecUserFullName = BC000I3_n143SecUserFullName[0];
            A144SecUserEmail = BC000I3_A144SecUserEmail[0];
            n144SecUserEmail = BC000I3_n144SecUserEmail[0];
            A150SecUserStatus = BC000I3_A150SecUserStatus[0];
            n150SecUserStatus = BC000I3_n150SecUserStatus[0];
            A142SecUserPassword = BC000I3_A142SecUserPassword[0];
            n142SecUserPassword = BC000I3_n142SecUserPassword[0];
            A791SecUserAnalista = BC000I3_A791SecUserAnalista[0];
            n791SecUserAnalista = BC000I3_n791SecUserAnalista[0];
            A146SecUserUpdateAt = BC000I3_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = BC000I3_n146SecUserUpdateAt[0];
            A208SecUserTemp = BC000I3_A208SecUserTemp[0];
            n208SecUserTemp = BC000I3_n208SecUserTemp[0];
            A209SecUserClienteAcesso = BC000I3_A209SecUserClienteAcesso[0];
            n209SecUserClienteAcesso = BC000I3_n209SecUserClienteAcesso[0];
            A153SecUserTeste = BC000I3_A153SecUserTeste[0];
            n153SecUserTeste = BC000I3_n153SecUserTeste[0];
            A226SecUserOwnerId = BC000I3_A226SecUserOwnerId[0];
            n226SecUserOwnerId = BC000I3_n226SecUserOwnerId[0];
            A147SecUserUserMan = BC000I3_A147SecUserUserMan[0];
            n147SecUserUserMan = BC000I3_n147SecUserUserMan[0];
            A210SecUserClienteId = BC000I3_A210SecUserClienteId[0];
            n210SecUserClienteId = BC000I3_n210SecUserClienteId[0];
            Z133SecUserId = A133SecUserId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0I22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0I22( ) ;
            }
            Gx_mode = sMode22;
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0I22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode22;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I22( ) ;
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
         CONFIRM_0I0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0I22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000I2 */
            pr_default.execute(0, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z145SecUserCreatedAt != BC000I2_A145SecUserCreatedAt[0] ) || ( StringUtil.StrCmp(Z141SecUserName, BC000I2_A141SecUserName[0]) != 0 ) || ( StringUtil.StrCmp(Z143SecUserFullName, BC000I2_A143SecUserFullName[0]) != 0 ) || ( StringUtil.StrCmp(Z144SecUserEmail, BC000I2_A144SecUserEmail[0]) != 0 ) || ( Z150SecUserStatus != BC000I2_A150SecUserStatus[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z142SecUserPassword, BC000I2_A142SecUserPassword[0]) != 0 ) || ( Z791SecUserAnalista != BC000I2_A791SecUserAnalista[0] ) || ( Z146SecUserUpdateAt != BC000I2_A146SecUserUpdateAt[0] ) || ( Z208SecUserTemp != BC000I2_A208SecUserTemp[0] ) || ( Z209SecUserClienteAcesso != BC000I2_A209SecUserClienteAcesso[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z226SecUserOwnerId != BC000I2_A226SecUserOwnerId[0] ) || ( Z147SecUserUserMan != BC000I2_A147SecUserUserMan[0] ) || ( Z210SecUserClienteId != BC000I2_A210SecUserClienteId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SecUser"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I22( )
      {
         BeforeValidate0I22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I22( 0) ;
            CheckOptimisticConcurrency0I22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I10 */
                     pr_default.execute(8, new Object[] {n145SecUserCreatedAt, A145SecUserCreatedAt, n141SecUserName, A141SecUserName, n143SecUserFullName, A143SecUserFullName, n144SecUserEmail, A144SecUserEmail, n150SecUserStatus, A150SecUserStatus, n142SecUserPassword, A142SecUserPassword, n791SecUserAnalista, A791SecUserAnalista, n146SecUserUpdateAt, A146SecUserUpdateAt, n208SecUserTemp, A208SecUserTemp, n209SecUserClienteAcesso, A209SecUserClienteAcesso, n153SecUserTeste, A153SecUserTeste, n226SecUserOwnerId, A226SecUserOwnerId, n147SecUserUserMan, A147SecUserUserMan, n210SecUserClienteId, A210SecUserClienteId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000I11 */
                     pr_default.execute(9);
                     A133SecUserId = BC000I11_A133SecUserId[0];
                     n133SecUserId = BC000I11_n133SecUserId[0];
                     pr_default.close(9);
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
               Load0I22( ) ;
            }
            EndLevel0I22( ) ;
         }
         CloseExtendedTableCursors0I22( ) ;
      }

      protected void Update0I22( )
      {
         BeforeValidate0I22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I12 */
                     pr_default.execute(10, new Object[] {n145SecUserCreatedAt, A145SecUserCreatedAt, n141SecUserName, A141SecUserName, n143SecUserFullName, A143SecUserFullName, n144SecUserEmail, A144SecUserEmail, n150SecUserStatus, A150SecUserStatus, n142SecUserPassword, A142SecUserPassword, n791SecUserAnalista, A791SecUserAnalista, n146SecUserUpdateAt, A146SecUserUpdateAt, n208SecUserTemp, A208SecUserTemp, n209SecUserClienteAcesso, A209SecUserClienteAcesso, n153SecUserTeste, A153SecUserTeste, n226SecUserOwnerId, A226SecUserOwnerId, n147SecUserUserMan, A147SecUserUserMan, n210SecUserClienteId, A210SecUserClienteId, n133SecUserId, A133SecUserId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("SecUser");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SecUser"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I22( ) ;
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
            EndLevel0I22( ) ;
         }
         CloseExtendedTableCursors0I22( ) ;
      }

      protected void DeferredUpdate0I22( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0I22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I22( ) ;
            AfterConfirm0I22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000I13 */
                  pr_default.execute(11, new Object[] {n133SecUserId, A133SecUserId});
                  pr_default.close(11);
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
         EndLevel0I22( ) ;
         Gx_mode = sMode22;
      }

      protected void OnDeleteControls0I22( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000I14 */
            pr_default.execute(12, new Object[] {n147SecUserUserMan, A147SecUserUserMan});
            A148SecUserManName = BC000I14_A148SecUserManName[0];
            n148SecUserManName = BC000I14_n148SecUserManName[0];
            A149SecUserManFullName = BC000I14_A149SecUserManFullName[0];
            n149SecUserManFullName = BC000I14_n149SecUserManFullName[0];
            pr_default.close(12);
            /* Using cursor BC000I15 */
            pr_default.execute(13, new Object[] {n210SecUserClienteId, A210SecUserClienteId});
            A211SecUserClienteFullName = BC000I15_A211SecUserClienteFullName[0];
            n211SecUserClienteFullName = BC000I15_n211SecUserClienteFullName[0];
            A212SecUserClienteStatus = BC000I15_A212SecUserClienteStatus[0];
            n212SecUserClienteStatus = BC000I15_n212SecUserClienteStatus[0];
            A213SecUserCliClienteAcesso = BC000I15_A213SecUserCliClienteAcesso[0];
            n213SecUserCliClienteAcesso = BC000I15_n213SecUserCliClienteAcesso[0];
            pr_default.close(13);
            /* Using cursor BC000I16 */
            pr_default.execute(14, new Object[] {n226SecUserOwnerId, A226SecUserOwnerId});
            A192TipoClienteId = BC000I16_A192TipoClienteId[0];
            n192TipoClienteId = BC000I16_n192TipoClienteId[0];
            pr_default.close(14);
            /* Using cursor BC000I17 */
            pr_default.execute(15, new Object[] {n192TipoClienteId, A192TipoClienteId});
            A793TipoClientePortalPjPf = BC000I17_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = BC000I17_n793TipoClientePortalPjPf[0];
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000I18 */
            pr_default.execute(16, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor BC000I19 */
            pr_default.execute(17, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"User"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor BC000I20 */
            pr_default.execute(18, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Chave PIX"+" ("+"Sb Chave PIXUpdated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor BC000I21 */
            pr_default.execute(19, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Chave PIX"+" ("+"Sb Chave PIXCreated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor BC000I22 */
            pr_default.execute(20, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conta Bancaria"+" ("+"Sb Conta Bancaria Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor BC000I23 */
            pr_default.execute(21, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conta Bancaria"+" ("+"Sb Conta Bancaria Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor BC000I24 */
            pr_default.execute(22, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agencia"+" ("+"Sb Agencia Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor BC000I25 */
            pr_default.execute(23, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Agencia"+" ("+"Sb Agencia Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor BC000I26 */
            pr_default.execute(24, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Taxas"+" ("+"Sb Taxas Updated By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor BC000I27 */
            pr_default.execute(25, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Taxas"+" ("+"Sb Taxas Created By"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor BC000I28 */
            pr_default.execute(26, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"+" ("+"Sb Updated By Credito"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor BC000I29 */
            pr_default.execute(27, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Credito"+" ("+"Sdb Credito Usuario"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor BC000I30 */
            pr_default.execute(28, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ReembolsoFlowLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor BC000I31 */
            pr_default.execute(29, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ClienteDocumento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor BC000I32 */
            pr_default.execute(30, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Especialidade"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor BC000I33 */
            pr_default.execute(31, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Reembolso"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor BC000I34 */
            pr_default.execute(32, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"UserNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor BC000I35 */
            pr_default.execute(33, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Proposta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor BC000I36 */
            pr_default.execute(34, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SecUserLog"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor BC000I37 */
            pr_default.execute(35, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ConfiguracoesTestemunhas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor BC000I38 */
            pr_default.execute(36, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Notification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
            /* Using cursor BC000I39 */
            pr_default.execute(37, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor BC000I40 */
            pr_default.execute(38, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sec User UID"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
            /* Using cursor BC000I41 */
            pr_default.execute(39, new Object[] {n133SecUserId, A133SecUserId});
            if ( (pr_default.getStatus(39) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sec User Role"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(39);
         }
      }

      protected void EndLevel0I22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I22( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            if ( (0==A210SecUserClienteId) || n210SecUserClienteId )
            {
               A210SecUserClienteId = A133SecUserId;
               n210SecUserClienteId = false;
            }
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

      public void ScanKeyStart0I22( )
      {
         /* Scan By routine */
         /* Using cursor BC000I42 */
         pr_default.execute(40, new Object[] {n133SecUserId, A133SecUserId});
         RcdFound22 = 0;
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound22 = 1;
            A192TipoClienteId = BC000I42_A192TipoClienteId[0];
            n192TipoClienteId = BC000I42_n192TipoClienteId[0];
            A133SecUserId = BC000I42_A133SecUserId[0];
            n133SecUserId = BC000I42_n133SecUserId[0];
            A145SecUserCreatedAt = BC000I42_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = BC000I42_n145SecUserCreatedAt[0];
            A141SecUserName = BC000I42_A141SecUserName[0];
            n141SecUserName = BC000I42_n141SecUserName[0];
            A143SecUserFullName = BC000I42_A143SecUserFullName[0];
            n143SecUserFullName = BC000I42_n143SecUserFullName[0];
            A144SecUserEmail = BC000I42_A144SecUserEmail[0];
            n144SecUserEmail = BC000I42_n144SecUserEmail[0];
            A150SecUserStatus = BC000I42_A150SecUserStatus[0];
            n150SecUserStatus = BC000I42_n150SecUserStatus[0];
            A142SecUserPassword = BC000I42_A142SecUserPassword[0];
            n142SecUserPassword = BC000I42_n142SecUserPassword[0];
            A791SecUserAnalista = BC000I42_A791SecUserAnalista[0];
            n791SecUserAnalista = BC000I42_n791SecUserAnalista[0];
            A146SecUserUpdateAt = BC000I42_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = BC000I42_n146SecUserUpdateAt[0];
            A148SecUserManName = BC000I42_A148SecUserManName[0];
            n148SecUserManName = BC000I42_n148SecUserManName[0];
            A149SecUserManFullName = BC000I42_A149SecUserManFullName[0];
            n149SecUserManFullName = BC000I42_n149SecUserManFullName[0];
            A208SecUserTemp = BC000I42_A208SecUserTemp[0];
            n208SecUserTemp = BC000I42_n208SecUserTemp[0];
            A209SecUserClienteAcesso = BC000I42_A209SecUserClienteAcesso[0];
            n209SecUserClienteAcesso = BC000I42_n209SecUserClienteAcesso[0];
            A153SecUserTeste = BC000I42_A153SecUserTeste[0];
            n153SecUserTeste = BC000I42_n153SecUserTeste[0];
            A211SecUserClienteFullName = BC000I42_A211SecUserClienteFullName[0];
            n211SecUserClienteFullName = BC000I42_n211SecUserClienteFullName[0];
            A212SecUserClienteStatus = BC000I42_A212SecUserClienteStatus[0];
            n212SecUserClienteStatus = BC000I42_n212SecUserClienteStatus[0];
            A213SecUserCliClienteAcesso = BC000I42_A213SecUserCliClienteAcesso[0];
            n213SecUserCliClienteAcesso = BC000I42_n213SecUserCliClienteAcesso[0];
            A793TipoClientePortalPjPf = BC000I42_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = BC000I42_n793TipoClientePortalPjPf[0];
            A226SecUserOwnerId = BC000I42_A226SecUserOwnerId[0];
            n226SecUserOwnerId = BC000I42_n226SecUserOwnerId[0];
            A147SecUserUserMan = BC000I42_A147SecUserUserMan[0];
            n147SecUserUserMan = BC000I42_n147SecUserUserMan[0];
            A210SecUserClienteId = BC000I42_A210SecUserClienteId[0];
            n210SecUserClienteId = BC000I42_n210SecUserClienteId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0I22( )
      {
         /* Scan next routine */
         pr_default.readNext(40);
         RcdFound22 = 0;
         ScanKeyLoad0I22( ) ;
      }

      protected void ScanKeyLoad0I22( )
      {
         sMode22 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound22 = 1;
            A192TipoClienteId = BC000I42_A192TipoClienteId[0];
            n192TipoClienteId = BC000I42_n192TipoClienteId[0];
            A133SecUserId = BC000I42_A133SecUserId[0];
            n133SecUserId = BC000I42_n133SecUserId[0];
            A145SecUserCreatedAt = BC000I42_A145SecUserCreatedAt[0];
            n145SecUserCreatedAt = BC000I42_n145SecUserCreatedAt[0];
            A141SecUserName = BC000I42_A141SecUserName[0];
            n141SecUserName = BC000I42_n141SecUserName[0];
            A143SecUserFullName = BC000I42_A143SecUserFullName[0];
            n143SecUserFullName = BC000I42_n143SecUserFullName[0];
            A144SecUserEmail = BC000I42_A144SecUserEmail[0];
            n144SecUserEmail = BC000I42_n144SecUserEmail[0];
            A150SecUserStatus = BC000I42_A150SecUserStatus[0];
            n150SecUserStatus = BC000I42_n150SecUserStatus[0];
            A142SecUserPassword = BC000I42_A142SecUserPassword[0];
            n142SecUserPassword = BC000I42_n142SecUserPassword[0];
            A791SecUserAnalista = BC000I42_A791SecUserAnalista[0];
            n791SecUserAnalista = BC000I42_n791SecUserAnalista[0];
            A146SecUserUpdateAt = BC000I42_A146SecUserUpdateAt[0];
            n146SecUserUpdateAt = BC000I42_n146SecUserUpdateAt[0];
            A148SecUserManName = BC000I42_A148SecUserManName[0];
            n148SecUserManName = BC000I42_n148SecUserManName[0];
            A149SecUserManFullName = BC000I42_A149SecUserManFullName[0];
            n149SecUserManFullName = BC000I42_n149SecUserManFullName[0];
            A208SecUserTemp = BC000I42_A208SecUserTemp[0];
            n208SecUserTemp = BC000I42_n208SecUserTemp[0];
            A209SecUserClienteAcesso = BC000I42_A209SecUserClienteAcesso[0];
            n209SecUserClienteAcesso = BC000I42_n209SecUserClienteAcesso[0];
            A153SecUserTeste = BC000I42_A153SecUserTeste[0];
            n153SecUserTeste = BC000I42_n153SecUserTeste[0];
            A211SecUserClienteFullName = BC000I42_A211SecUserClienteFullName[0];
            n211SecUserClienteFullName = BC000I42_n211SecUserClienteFullName[0];
            A212SecUserClienteStatus = BC000I42_A212SecUserClienteStatus[0];
            n212SecUserClienteStatus = BC000I42_n212SecUserClienteStatus[0];
            A213SecUserCliClienteAcesso = BC000I42_A213SecUserCliClienteAcesso[0];
            n213SecUserCliClienteAcesso = BC000I42_n213SecUserCliClienteAcesso[0];
            A793TipoClientePortalPjPf = BC000I42_A793TipoClientePortalPjPf[0];
            n793TipoClientePortalPjPf = BC000I42_n793TipoClientePortalPjPf[0];
            A226SecUserOwnerId = BC000I42_A226SecUserOwnerId[0];
            n226SecUserOwnerId = BC000I42_n226SecUserOwnerId[0];
            A147SecUserUserMan = BC000I42_A147SecUserUserMan[0];
            n147SecUserUserMan = BC000I42_n147SecUserUserMan[0];
            A210SecUserClienteId = BC000I42_A210SecUserClienteId[0];
            n210SecUserClienteId = BC000I42_n210SecUserClienteId[0];
         }
         Gx_mode = sMode22;
      }

      protected void ScanKeyEnd0I22( )
      {
         pr_default.close(40);
      }

      protected void AfterConfirm0I22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0I22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I22( )
      {
      }

      protected void send_integrity_lvl_hashes0I22( )
      {
      }

      protected void AddRow0I22( )
      {
         VarsToRow22( bcSecUser) ;
      }

      protected void ReadRow0I22( )
      {
         RowToVars22( bcSecUser, 1) ;
      }

      protected void InitializeNonKey0I22( )
      {
         A192TipoClienteId = 0;
         n192TipoClienteId = false;
         A145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         n145SecUserCreatedAt = false;
         A210SecUserClienteId = 0;
         n210SecUserClienteId = false;
         A141SecUserName = "";
         n141SecUserName = false;
         A143SecUserFullName = "";
         n143SecUserFullName = false;
         A144SecUserEmail = "";
         n144SecUserEmail = false;
         A142SecUserPassword = "";
         n142SecUserPassword = false;
         A791SecUserAnalista = false;
         n791SecUserAnalista = false;
         A146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         n146SecUserUpdateAt = false;
         A147SecUserUserMan = 0;
         n147SecUserUserMan = false;
         A148SecUserManName = "";
         n148SecUserManName = false;
         A149SecUserManFullName = "";
         n149SecUserManFullName = false;
         A208SecUserTemp = false;
         n208SecUserTemp = false;
         A209SecUserClienteAcesso = false;
         n209SecUserClienteAcesso = false;
         A153SecUserTeste = "";
         n153SecUserTeste = false;
         A211SecUserClienteFullName = "";
         n211SecUserClienteFullName = false;
         A212SecUserClienteStatus = false;
         n212SecUserClienteStatus = false;
         A213SecUserCliClienteAcesso = false;
         n213SecUserCliClienteAcesso = false;
         A226SecUserOwnerId = 0;
         n226SecUserOwnerId = false;
         A793TipoClientePortalPjPf = false;
         n793TipoClientePortalPjPf = false;
         A150SecUserStatus = true;
         n150SecUserStatus = false;
         Z145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         Z141SecUserName = "";
         Z143SecUserFullName = "";
         Z144SecUserEmail = "";
         Z150SecUserStatus = false;
         Z142SecUserPassword = "";
         Z791SecUserAnalista = false;
         Z146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         Z208SecUserTemp = false;
         Z209SecUserClienteAcesso = false;
         Z226SecUserOwnerId = 0;
         Z147SecUserUserMan = 0;
         Z210SecUserClienteId = 0;
      }

      protected void InitAll0I22( )
      {
         A133SecUserId = 0;
         n133SecUserId = false;
         InitializeNonKey0I22( ) ;
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

      public void VarsToRow22( SdtSecUser obj22 )
      {
         obj22.gxTpr_Mode = Gx_mode;
         obj22.gxTpr_Secusercreatedat = A145SecUserCreatedAt;
         obj22.gxTpr_Secuserclienteid = A210SecUserClienteId;
         obj22.gxTpr_Secusername = A141SecUserName;
         obj22.gxTpr_Secuserfullname = A143SecUserFullName;
         obj22.gxTpr_Secuseremail = A144SecUserEmail;
         obj22.gxTpr_Secuserpassword = A142SecUserPassword;
         obj22.gxTpr_Secuseranalista = A791SecUserAnalista;
         obj22.gxTpr_Secuserupdateat = A146SecUserUpdateAt;
         obj22.gxTpr_Secuseruserman = A147SecUserUserMan;
         obj22.gxTpr_Secusermanname = A148SecUserManName;
         obj22.gxTpr_Secusermanfullname = A149SecUserManFullName;
         obj22.gxTpr_Secusertemp = A208SecUserTemp;
         obj22.gxTpr_Secuserclienteacesso = A209SecUserClienteAcesso;
         obj22.gxTpr_Secuserteste = A153SecUserTeste;
         obj22.gxTpr_Secuserclientefullname = A211SecUserClienteFullName;
         obj22.gxTpr_Secuserclientestatus = A212SecUserClienteStatus;
         obj22.gxTpr_Secusercliclienteacesso = A213SecUserCliClienteAcesso;
         obj22.gxTpr_Secuserownerid = A226SecUserOwnerId;
         obj22.gxTpr_Tipoclienteportalpjpf = A793TipoClientePortalPjPf;
         obj22.gxTpr_Secuserstatus = A150SecUserStatus;
         obj22.gxTpr_Secuserid = A133SecUserId;
         obj22.gxTpr_Secuserid_Z = Z133SecUserId;
         obj22.gxTpr_Secusername_Z = Z141SecUserName;
         obj22.gxTpr_Secuserfullname_Z = Z143SecUserFullName;
         obj22.gxTpr_Secuseremail_Z = Z144SecUserEmail;
         obj22.gxTpr_Secuserstatus_Z = Z150SecUserStatus;
         obj22.gxTpr_Secuserpassword_Z = Z142SecUserPassword;
         obj22.gxTpr_Secuseranalista_Z = Z791SecUserAnalista;
         obj22.gxTpr_Secusercreatedat_Z = Z145SecUserCreatedAt;
         obj22.gxTpr_Secuserupdateat_Z = Z146SecUserUpdateAt;
         obj22.gxTpr_Secuseruserman_Z = Z147SecUserUserMan;
         obj22.gxTpr_Secusermanname_Z = Z148SecUserManName;
         obj22.gxTpr_Secusermanfullname_Z = Z149SecUserManFullName;
         obj22.gxTpr_Secusertemp_Z = Z208SecUserTemp;
         obj22.gxTpr_Secuserclienteacesso_Z = Z209SecUserClienteAcesso;
         obj22.gxTpr_Secuserclienteid_Z = Z210SecUserClienteId;
         obj22.gxTpr_Secuserclientefullname_Z = Z211SecUserClienteFullName;
         obj22.gxTpr_Secuserclientestatus_Z = Z212SecUserClienteStatus;
         obj22.gxTpr_Secusercliclienteacesso_Z = Z213SecUserCliClienteAcesso;
         obj22.gxTpr_Secuserownerid_Z = Z226SecUserOwnerId;
         obj22.gxTpr_Tipoclienteportalpjpf_Z = Z793TipoClientePortalPjPf;
         obj22.gxTpr_Secuserid_N = (short)(Convert.ToInt16(n133SecUserId));
         obj22.gxTpr_Secusername_N = (short)(Convert.ToInt16(n141SecUserName));
         obj22.gxTpr_Secuserfullname_N = (short)(Convert.ToInt16(n143SecUserFullName));
         obj22.gxTpr_Secuseremail_N = (short)(Convert.ToInt16(n144SecUserEmail));
         obj22.gxTpr_Secuserstatus_N = (short)(Convert.ToInt16(n150SecUserStatus));
         obj22.gxTpr_Secuserpassword_N = (short)(Convert.ToInt16(n142SecUserPassword));
         obj22.gxTpr_Secuseranalista_N = (short)(Convert.ToInt16(n791SecUserAnalista));
         obj22.gxTpr_Secusercreatedat_N = (short)(Convert.ToInt16(n145SecUserCreatedAt));
         obj22.gxTpr_Secuserupdateat_N = (short)(Convert.ToInt16(n146SecUserUpdateAt));
         obj22.gxTpr_Secuseruserman_N = (short)(Convert.ToInt16(n147SecUserUserMan));
         obj22.gxTpr_Secusermanname_N = (short)(Convert.ToInt16(n148SecUserManName));
         obj22.gxTpr_Secusermanfullname_N = (short)(Convert.ToInt16(n149SecUserManFullName));
         obj22.gxTpr_Secusertemp_N = (short)(Convert.ToInt16(n208SecUserTemp));
         obj22.gxTpr_Secuserclienteacesso_N = (short)(Convert.ToInt16(n209SecUserClienteAcesso));
         obj22.gxTpr_Secuserteste_N = (short)(Convert.ToInt16(n153SecUserTeste));
         obj22.gxTpr_Secuserclienteid_N = (short)(Convert.ToInt16(n210SecUserClienteId));
         obj22.gxTpr_Secuserclientefullname_N = (short)(Convert.ToInt16(n211SecUserClienteFullName));
         obj22.gxTpr_Secuserclientestatus_N = (short)(Convert.ToInt16(n212SecUserClienteStatus));
         obj22.gxTpr_Secusercliclienteacesso_N = (short)(Convert.ToInt16(n213SecUserCliClienteAcesso));
         obj22.gxTpr_Secuserownerid_N = (short)(Convert.ToInt16(n226SecUserOwnerId));
         obj22.gxTpr_Tipoclienteportalpjpf_N = (short)(Convert.ToInt16(n793TipoClientePortalPjPf));
         obj22.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow22( SdtSecUser obj22 )
      {
         obj22.gxTpr_Secuserid = A133SecUserId;
         return  ;
      }

      public void RowToVars22( SdtSecUser obj22 ,
                               int forceLoad )
      {
         Gx_mode = obj22.gxTpr_Mode;
         A145SecUserCreatedAt = obj22.gxTpr_Secusercreatedat;
         n145SecUserCreatedAt = false;
         A210SecUserClienteId = obj22.gxTpr_Secuserclienteid;
         n210SecUserClienteId = false;
         A141SecUserName = obj22.gxTpr_Secusername;
         n141SecUserName = false;
         A143SecUserFullName = obj22.gxTpr_Secuserfullname;
         n143SecUserFullName = false;
         A144SecUserEmail = obj22.gxTpr_Secuseremail;
         n144SecUserEmail = false;
         A142SecUserPassword = obj22.gxTpr_Secuserpassword;
         n142SecUserPassword = false;
         A791SecUserAnalista = obj22.gxTpr_Secuseranalista;
         n791SecUserAnalista = false;
         A146SecUserUpdateAt = obj22.gxTpr_Secuserupdateat;
         n146SecUserUpdateAt = false;
         A147SecUserUserMan = obj22.gxTpr_Secuseruserman;
         n147SecUserUserMan = false;
         A148SecUserManName = obj22.gxTpr_Secusermanname;
         n148SecUserManName = false;
         A149SecUserManFullName = obj22.gxTpr_Secusermanfullname;
         n149SecUserManFullName = false;
         A208SecUserTemp = obj22.gxTpr_Secusertemp;
         n208SecUserTemp = false;
         A209SecUserClienteAcesso = obj22.gxTpr_Secuserclienteacesso;
         n209SecUserClienteAcesso = false;
         A153SecUserTeste = obj22.gxTpr_Secuserteste;
         n153SecUserTeste = false;
         A211SecUserClienteFullName = obj22.gxTpr_Secuserclientefullname;
         n211SecUserClienteFullName = false;
         A212SecUserClienteStatus = obj22.gxTpr_Secuserclientestatus;
         n212SecUserClienteStatus = false;
         A213SecUserCliClienteAcesso = obj22.gxTpr_Secusercliclienteacesso;
         n213SecUserCliClienteAcesso = false;
         A226SecUserOwnerId = obj22.gxTpr_Secuserownerid;
         n226SecUserOwnerId = false;
         A793TipoClientePortalPjPf = obj22.gxTpr_Tipoclienteportalpjpf;
         n793TipoClientePortalPjPf = false;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) || ( forceLoad == 1 ) )
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
         Z142SecUserPassword = obj22.gxTpr_Secuserpassword_Z;
         Z791SecUserAnalista = obj22.gxTpr_Secuseranalista_Z;
         Z145SecUserCreatedAt = obj22.gxTpr_Secusercreatedat_Z;
         Z146SecUserUpdateAt = obj22.gxTpr_Secuserupdateat_Z;
         Z147SecUserUserMan = obj22.gxTpr_Secuseruserman_Z;
         Z148SecUserManName = obj22.gxTpr_Secusermanname_Z;
         Z149SecUserManFullName = obj22.gxTpr_Secusermanfullname_Z;
         Z208SecUserTemp = obj22.gxTpr_Secusertemp_Z;
         Z209SecUserClienteAcesso = obj22.gxTpr_Secuserclienteacesso_Z;
         Z210SecUserClienteId = obj22.gxTpr_Secuserclienteid_Z;
         Z211SecUserClienteFullName = obj22.gxTpr_Secuserclientefullname_Z;
         Z212SecUserClienteStatus = obj22.gxTpr_Secuserclientestatus_Z;
         Z213SecUserCliClienteAcesso = obj22.gxTpr_Secusercliclienteacesso_Z;
         Z226SecUserOwnerId = obj22.gxTpr_Secuserownerid_Z;
         Z793TipoClientePortalPjPf = obj22.gxTpr_Tipoclienteportalpjpf_Z;
         n133SecUserId = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserid_N));
         n141SecUserName = (bool)(Convert.ToBoolean(obj22.gxTpr_Secusername_N));
         n143SecUserFullName = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserfullname_N));
         n144SecUserEmail = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuseremail_N));
         n150SecUserStatus = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserstatus_N));
         n142SecUserPassword = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserpassword_N));
         n791SecUserAnalista = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuseranalista_N));
         n145SecUserCreatedAt = (bool)(Convert.ToBoolean(obj22.gxTpr_Secusercreatedat_N));
         n146SecUserUpdateAt = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserupdateat_N));
         n147SecUserUserMan = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuseruserman_N));
         n148SecUserManName = (bool)(Convert.ToBoolean(obj22.gxTpr_Secusermanname_N));
         n149SecUserManFullName = (bool)(Convert.ToBoolean(obj22.gxTpr_Secusermanfullname_N));
         n208SecUserTemp = (bool)(Convert.ToBoolean(obj22.gxTpr_Secusertemp_N));
         n209SecUserClienteAcesso = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserclienteacesso_N));
         n153SecUserTeste = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserteste_N));
         n210SecUserClienteId = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserclienteid_N));
         n211SecUserClienteFullName = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserclientefullname_N));
         n212SecUserClienteStatus = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserclientestatus_N));
         n213SecUserCliClienteAcesso = (bool)(Convert.ToBoolean(obj22.gxTpr_Secusercliclienteacesso_N));
         n226SecUserOwnerId = (bool)(Convert.ToBoolean(obj22.gxTpr_Secuserownerid_N));
         n793TipoClientePortalPjPf = (bool)(Convert.ToBoolean(obj22.gxTpr_Tipoclienteportalpjpf_N));
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
         InitializeNonKey0I22( ) ;
         ScanKeyStart0I22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z133SecUserId = A133SecUserId;
         }
         ZM0I22( -14) ;
         OnLoadActions0I22( ) ;
         AddRow0I22( ) ;
         ScanKeyEnd0I22( ) ;
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
         RowToVars22( bcSecUser, 0) ;
         ScanKeyStart0I22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z133SecUserId = A133SecUserId;
         }
         ZM0I22( -14) ;
         OnLoadActions0I22( ) ;
         AddRow0I22( ) ;
         ScanKeyEnd0I22( ) ;
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0I22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0I22( ) ;
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
                  Update0I22( ) ;
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
                        Insert0I22( ) ;
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
                        Insert0I22( ) ;
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
         RowToVars22( bcSecUser, 1) ;
         SaveImpl( ) ;
         VarsToRow22( bcSecUser) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars22( bcSecUser, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I22( ) ;
         AfterTrn( ) ;
         VarsToRow22( bcSecUser) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow22( bcSecUser) ;
         }
         else
         {
            SdtSecUser auxBC = new SdtSecUser(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A133SecUserId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcSecUser);
               auxBC.Save();
               bcSecUser.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars22( bcSecUser, 1) ;
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
         RowToVars22( bcSecUser, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I22( ) ;
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
               VarsToRow22( bcSecUser) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow22( bcSecUser) ;
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
         RowToVars22( bcSecUser, 0) ;
         GetKey0I22( ) ;
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
         context.RollbackDataStores("secuser_bc",pr_default);
         VarsToRow22( bcSecUser) ;
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
         Gx_mode = bcSecUser.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcSecUser.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcSecUser )
         {
            bcSecUser = (SdtSecUser)(sdt);
            if ( StringUtil.StrCmp(bcSecUser.gxTpr_Mode, "") == 0 )
            {
               bcSecUser.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow22( bcSecUser) ;
            }
            else
            {
               RowToVars22( bcSecUser, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcSecUser.gxTpr_Mode, "") == 0 )
            {
               bcSecUser.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars22( bcSecUser, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtSecUser SecUser_BC
      {
         get {
            return bcSecUser ;
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
         pr_default.close(14);
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV15WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV25Pgmname = "";
         AV21TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         A145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         Z141SecUserName = "";
         A141SecUserName = "";
         Z143SecUserFullName = "";
         A143SecUserFullName = "";
         Z144SecUserEmail = "";
         A144SecUserEmail = "";
         Z142SecUserPassword = "";
         A142SecUserPassword = "";
         Z146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         A146SecUserUpdateAt = (DateTime)(DateTime.MinValue);
         Z148SecUserManName = "";
         A148SecUserManName = "";
         Z149SecUserManFullName = "";
         A149SecUserManFullName = "";
         Z211SecUserClienteFullName = "";
         A211SecUserClienteFullName = "";
         Z153SecUserTeste = "";
         A153SecUserTeste = "";
         BC000I8_A192TipoClienteId = new short[1] ;
         BC000I8_n192TipoClienteId = new bool[] {false} ;
         BC000I8_A133SecUserId = new short[1] ;
         BC000I8_n133SecUserId = new bool[] {false} ;
         BC000I8_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000I8_n145SecUserCreatedAt = new bool[] {false} ;
         BC000I8_A141SecUserName = new string[] {""} ;
         BC000I8_n141SecUserName = new bool[] {false} ;
         BC000I8_A143SecUserFullName = new string[] {""} ;
         BC000I8_n143SecUserFullName = new bool[] {false} ;
         BC000I8_A144SecUserEmail = new string[] {""} ;
         BC000I8_n144SecUserEmail = new bool[] {false} ;
         BC000I8_A150SecUserStatus = new bool[] {false} ;
         BC000I8_n150SecUserStatus = new bool[] {false} ;
         BC000I8_A142SecUserPassword = new string[] {""} ;
         BC000I8_n142SecUserPassword = new bool[] {false} ;
         BC000I8_A791SecUserAnalista = new bool[] {false} ;
         BC000I8_n791SecUserAnalista = new bool[] {false} ;
         BC000I8_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC000I8_n146SecUserUpdateAt = new bool[] {false} ;
         BC000I8_A148SecUserManName = new string[] {""} ;
         BC000I8_n148SecUserManName = new bool[] {false} ;
         BC000I8_A149SecUserManFullName = new string[] {""} ;
         BC000I8_n149SecUserManFullName = new bool[] {false} ;
         BC000I8_A208SecUserTemp = new bool[] {false} ;
         BC000I8_n208SecUserTemp = new bool[] {false} ;
         BC000I8_A209SecUserClienteAcesso = new bool[] {false} ;
         BC000I8_n209SecUserClienteAcesso = new bool[] {false} ;
         BC000I8_A153SecUserTeste = new string[] {""} ;
         BC000I8_n153SecUserTeste = new bool[] {false} ;
         BC000I8_A211SecUserClienteFullName = new string[] {""} ;
         BC000I8_n211SecUserClienteFullName = new bool[] {false} ;
         BC000I8_A212SecUserClienteStatus = new bool[] {false} ;
         BC000I8_n212SecUserClienteStatus = new bool[] {false} ;
         BC000I8_A213SecUserCliClienteAcesso = new bool[] {false} ;
         BC000I8_n213SecUserCliClienteAcesso = new bool[] {false} ;
         BC000I8_A793TipoClientePortalPjPf = new bool[] {false} ;
         BC000I8_n793TipoClientePortalPjPf = new bool[] {false} ;
         BC000I8_A226SecUserOwnerId = new int[1] ;
         BC000I8_n226SecUserOwnerId = new bool[] {false} ;
         BC000I8_A147SecUserUserMan = new short[1] ;
         BC000I8_n147SecUserUserMan = new bool[] {false} ;
         BC000I8_A210SecUserClienteId = new short[1] ;
         BC000I8_n210SecUserClienteId = new bool[] {false} ;
         BC000I5_A148SecUserManName = new string[] {""} ;
         BC000I5_n148SecUserManName = new bool[] {false} ;
         BC000I5_A149SecUserManFullName = new string[] {""} ;
         BC000I5_n149SecUserManFullName = new bool[] {false} ;
         BC000I6_A211SecUserClienteFullName = new string[] {""} ;
         BC000I6_n211SecUserClienteFullName = new bool[] {false} ;
         BC000I6_A212SecUserClienteStatus = new bool[] {false} ;
         BC000I6_n212SecUserClienteStatus = new bool[] {false} ;
         BC000I6_A213SecUserCliClienteAcesso = new bool[] {false} ;
         BC000I6_n213SecUserCliClienteAcesso = new bool[] {false} ;
         BC000I4_A192TipoClienteId = new short[1] ;
         BC000I4_n192TipoClienteId = new bool[] {false} ;
         BC000I7_A793TipoClientePortalPjPf = new bool[] {false} ;
         BC000I7_n793TipoClientePortalPjPf = new bool[] {false} ;
         BC000I9_A133SecUserId = new short[1] ;
         BC000I9_n133SecUserId = new bool[] {false} ;
         BC000I3_A133SecUserId = new short[1] ;
         BC000I3_n133SecUserId = new bool[] {false} ;
         BC000I3_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000I3_n145SecUserCreatedAt = new bool[] {false} ;
         BC000I3_A141SecUserName = new string[] {""} ;
         BC000I3_n141SecUserName = new bool[] {false} ;
         BC000I3_A143SecUserFullName = new string[] {""} ;
         BC000I3_n143SecUserFullName = new bool[] {false} ;
         BC000I3_A144SecUserEmail = new string[] {""} ;
         BC000I3_n144SecUserEmail = new bool[] {false} ;
         BC000I3_A150SecUserStatus = new bool[] {false} ;
         BC000I3_n150SecUserStatus = new bool[] {false} ;
         BC000I3_A142SecUserPassword = new string[] {""} ;
         BC000I3_n142SecUserPassword = new bool[] {false} ;
         BC000I3_A791SecUserAnalista = new bool[] {false} ;
         BC000I3_n791SecUserAnalista = new bool[] {false} ;
         BC000I3_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC000I3_n146SecUserUpdateAt = new bool[] {false} ;
         BC000I3_A208SecUserTemp = new bool[] {false} ;
         BC000I3_n208SecUserTemp = new bool[] {false} ;
         BC000I3_A209SecUserClienteAcesso = new bool[] {false} ;
         BC000I3_n209SecUserClienteAcesso = new bool[] {false} ;
         BC000I3_A153SecUserTeste = new string[] {""} ;
         BC000I3_n153SecUserTeste = new bool[] {false} ;
         BC000I3_A226SecUserOwnerId = new int[1] ;
         BC000I3_n226SecUserOwnerId = new bool[] {false} ;
         BC000I3_A147SecUserUserMan = new short[1] ;
         BC000I3_n147SecUserUserMan = new bool[] {false} ;
         BC000I3_A210SecUserClienteId = new short[1] ;
         BC000I3_n210SecUserClienteId = new bool[] {false} ;
         sMode22 = "";
         BC000I2_A133SecUserId = new short[1] ;
         BC000I2_n133SecUserId = new bool[] {false} ;
         BC000I2_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000I2_n145SecUserCreatedAt = new bool[] {false} ;
         BC000I2_A141SecUserName = new string[] {""} ;
         BC000I2_n141SecUserName = new bool[] {false} ;
         BC000I2_A143SecUserFullName = new string[] {""} ;
         BC000I2_n143SecUserFullName = new bool[] {false} ;
         BC000I2_A144SecUserEmail = new string[] {""} ;
         BC000I2_n144SecUserEmail = new bool[] {false} ;
         BC000I2_A150SecUserStatus = new bool[] {false} ;
         BC000I2_n150SecUserStatus = new bool[] {false} ;
         BC000I2_A142SecUserPassword = new string[] {""} ;
         BC000I2_n142SecUserPassword = new bool[] {false} ;
         BC000I2_A791SecUserAnalista = new bool[] {false} ;
         BC000I2_n791SecUserAnalista = new bool[] {false} ;
         BC000I2_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC000I2_n146SecUserUpdateAt = new bool[] {false} ;
         BC000I2_A208SecUserTemp = new bool[] {false} ;
         BC000I2_n208SecUserTemp = new bool[] {false} ;
         BC000I2_A209SecUserClienteAcesso = new bool[] {false} ;
         BC000I2_n209SecUserClienteAcesso = new bool[] {false} ;
         BC000I2_A153SecUserTeste = new string[] {""} ;
         BC000I2_n153SecUserTeste = new bool[] {false} ;
         BC000I2_A226SecUserOwnerId = new int[1] ;
         BC000I2_n226SecUserOwnerId = new bool[] {false} ;
         BC000I2_A147SecUserUserMan = new short[1] ;
         BC000I2_n147SecUserUserMan = new bool[] {false} ;
         BC000I2_A210SecUserClienteId = new short[1] ;
         BC000I2_n210SecUserClienteId = new bool[] {false} ;
         BC000I11_A133SecUserId = new short[1] ;
         BC000I11_n133SecUserId = new bool[] {false} ;
         BC000I14_A148SecUserManName = new string[] {""} ;
         BC000I14_n148SecUserManName = new bool[] {false} ;
         BC000I14_A149SecUserManFullName = new string[] {""} ;
         BC000I14_n149SecUserManFullName = new bool[] {false} ;
         BC000I15_A211SecUserClienteFullName = new string[] {""} ;
         BC000I15_n211SecUserClienteFullName = new bool[] {false} ;
         BC000I15_A212SecUserClienteStatus = new bool[] {false} ;
         BC000I15_n212SecUserClienteStatus = new bool[] {false} ;
         BC000I15_A213SecUserCliClienteAcesso = new bool[] {false} ;
         BC000I15_n213SecUserCliClienteAcesso = new bool[] {false} ;
         BC000I16_A192TipoClienteId = new short[1] ;
         BC000I16_n192TipoClienteId = new bool[] {false} ;
         BC000I17_A793TipoClientePortalPjPf = new bool[] {false} ;
         BC000I17_n793TipoClientePortalPjPf = new bool[] {false} ;
         BC000I18_A210SecUserClienteId = new short[1] ;
         BC000I18_n210SecUserClienteId = new bool[] {false} ;
         BC000I19_A147SecUserUserMan = new short[1] ;
         BC000I19_n147SecUserUserMan = new bool[] {false} ;
         BC000I20_A961ChavePIXId = new int[1] ;
         BC000I21_A961ChavePIXId = new int[1] ;
         BC000I22_A951ContaBancariaId = new int[1] ;
         BC000I23_A951ContaBancariaId = new int[1] ;
         BC000I24_A938AgenciaId = new int[1] ;
         BC000I25_A938AgenciaId = new int[1] ;
         BC000I26_A863TaxasId = new int[1] ;
         BC000I27_A863TaxasId = new int[1] ;
         BC000I28_A856CreditoId = new int[1] ;
         BC000I29_A856CreditoId = new int[1] ;
         BC000I30_A746ReembolsoFlowLogId = new int[1] ;
         BC000I31_A599ClienteDocumentoId = new int[1] ;
         BC000I32_A457EspecialidadeId = new int[1] ;
         BC000I33_A518ReembolsoId = new int[1] ;
         BC000I34_A387UserNotificationId = new int[1] ;
         BC000I35_A323PropostaId = new int[1] ;
         BC000I36_A559SecUserLogId = new int[1] ;
         BC000I37_A478ConfiguracoesTestemunhasId = new int[1] ;
         BC000I38_A381NotificationId = new int[1] ;
         BC000I39_A375AprovadoresId = new int[1] ;
         BC000I40_A164SecUserTokenID = new short[1] ;
         BC000I41_A133SecUserId = new short[1] ;
         BC000I41_n133SecUserId = new bool[] {false} ;
         BC000I41_A131SecRoleId = new short[1] ;
         BC000I42_A192TipoClienteId = new short[1] ;
         BC000I42_n192TipoClienteId = new bool[] {false} ;
         BC000I42_A133SecUserId = new short[1] ;
         BC000I42_n133SecUserId = new bool[] {false} ;
         BC000I42_A145SecUserCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC000I42_n145SecUserCreatedAt = new bool[] {false} ;
         BC000I42_A141SecUserName = new string[] {""} ;
         BC000I42_n141SecUserName = new bool[] {false} ;
         BC000I42_A143SecUserFullName = new string[] {""} ;
         BC000I42_n143SecUserFullName = new bool[] {false} ;
         BC000I42_A144SecUserEmail = new string[] {""} ;
         BC000I42_n144SecUserEmail = new bool[] {false} ;
         BC000I42_A150SecUserStatus = new bool[] {false} ;
         BC000I42_n150SecUserStatus = new bool[] {false} ;
         BC000I42_A142SecUserPassword = new string[] {""} ;
         BC000I42_n142SecUserPassword = new bool[] {false} ;
         BC000I42_A791SecUserAnalista = new bool[] {false} ;
         BC000I42_n791SecUserAnalista = new bool[] {false} ;
         BC000I42_A146SecUserUpdateAt = new DateTime[] {DateTime.MinValue} ;
         BC000I42_n146SecUserUpdateAt = new bool[] {false} ;
         BC000I42_A148SecUserManName = new string[] {""} ;
         BC000I42_n148SecUserManName = new bool[] {false} ;
         BC000I42_A149SecUserManFullName = new string[] {""} ;
         BC000I42_n149SecUserManFullName = new bool[] {false} ;
         BC000I42_A208SecUserTemp = new bool[] {false} ;
         BC000I42_n208SecUserTemp = new bool[] {false} ;
         BC000I42_A209SecUserClienteAcesso = new bool[] {false} ;
         BC000I42_n209SecUserClienteAcesso = new bool[] {false} ;
         BC000I42_A153SecUserTeste = new string[] {""} ;
         BC000I42_n153SecUserTeste = new bool[] {false} ;
         BC000I42_A211SecUserClienteFullName = new string[] {""} ;
         BC000I42_n211SecUserClienteFullName = new bool[] {false} ;
         BC000I42_A212SecUserClienteStatus = new bool[] {false} ;
         BC000I42_n212SecUserClienteStatus = new bool[] {false} ;
         BC000I42_A213SecUserCliClienteAcesso = new bool[] {false} ;
         BC000I42_n213SecUserCliClienteAcesso = new bool[] {false} ;
         BC000I42_A793TipoClientePortalPjPf = new bool[] {false} ;
         BC000I42_n793TipoClientePortalPjPf = new bool[] {false} ;
         BC000I42_A226SecUserOwnerId = new int[1] ;
         BC000I42_n226SecUserOwnerId = new bool[] {false} ;
         BC000I42_A147SecUserUserMan = new short[1] ;
         BC000I42_n147SecUserUserMan = new bool[] {false} ;
         BC000I42_A210SecUserClienteId = new short[1] ;
         BC000I42_n210SecUserClienteId = new bool[] {false} ;
         i145SecUserCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.secuser_bc__default(),
            new Object[][] {
                new Object[] {
               BC000I2_A133SecUserId, BC000I2_A145SecUserCreatedAt, BC000I2_n145SecUserCreatedAt, BC000I2_A141SecUserName, BC000I2_n141SecUserName, BC000I2_A143SecUserFullName, BC000I2_n143SecUserFullName, BC000I2_A144SecUserEmail, BC000I2_n144SecUserEmail, BC000I2_A150SecUserStatus,
               BC000I2_n150SecUserStatus, BC000I2_A142SecUserPassword, BC000I2_n142SecUserPassword, BC000I2_A791SecUserAnalista, BC000I2_n791SecUserAnalista, BC000I2_A146SecUserUpdateAt, BC000I2_n146SecUserUpdateAt, BC000I2_A208SecUserTemp, BC000I2_n208SecUserTemp, BC000I2_A209SecUserClienteAcesso,
               BC000I2_n209SecUserClienteAcesso, BC000I2_A153SecUserTeste, BC000I2_n153SecUserTeste, BC000I2_A226SecUserOwnerId, BC000I2_n226SecUserOwnerId, BC000I2_A147SecUserUserMan, BC000I2_n147SecUserUserMan, BC000I2_A210SecUserClienteId, BC000I2_n210SecUserClienteId
               }
               , new Object[] {
               BC000I3_A133SecUserId, BC000I3_A145SecUserCreatedAt, BC000I3_n145SecUserCreatedAt, BC000I3_A141SecUserName, BC000I3_n141SecUserName, BC000I3_A143SecUserFullName, BC000I3_n143SecUserFullName, BC000I3_A144SecUserEmail, BC000I3_n144SecUserEmail, BC000I3_A150SecUserStatus,
               BC000I3_n150SecUserStatus, BC000I3_A142SecUserPassword, BC000I3_n142SecUserPassword, BC000I3_A791SecUserAnalista, BC000I3_n791SecUserAnalista, BC000I3_A146SecUserUpdateAt, BC000I3_n146SecUserUpdateAt, BC000I3_A208SecUserTemp, BC000I3_n208SecUserTemp, BC000I3_A209SecUserClienteAcesso,
               BC000I3_n209SecUserClienteAcesso, BC000I3_A153SecUserTeste, BC000I3_n153SecUserTeste, BC000I3_A226SecUserOwnerId, BC000I3_n226SecUserOwnerId, BC000I3_A147SecUserUserMan, BC000I3_n147SecUserUserMan, BC000I3_A210SecUserClienteId, BC000I3_n210SecUserClienteId
               }
               , new Object[] {
               BC000I4_A192TipoClienteId, BC000I4_n192TipoClienteId
               }
               , new Object[] {
               BC000I5_A148SecUserManName, BC000I5_n148SecUserManName, BC000I5_A149SecUserManFullName, BC000I5_n149SecUserManFullName
               }
               , new Object[] {
               BC000I6_A211SecUserClienteFullName, BC000I6_n211SecUserClienteFullName, BC000I6_A212SecUserClienteStatus, BC000I6_n212SecUserClienteStatus, BC000I6_A213SecUserCliClienteAcesso, BC000I6_n213SecUserCliClienteAcesso
               }
               , new Object[] {
               BC000I7_A793TipoClientePortalPjPf, BC000I7_n793TipoClientePortalPjPf
               }
               , new Object[] {
               BC000I8_A192TipoClienteId, BC000I8_n192TipoClienteId, BC000I8_A133SecUserId, BC000I8_A145SecUserCreatedAt, BC000I8_n145SecUserCreatedAt, BC000I8_A141SecUserName, BC000I8_n141SecUserName, BC000I8_A143SecUserFullName, BC000I8_n143SecUserFullName, BC000I8_A144SecUserEmail,
               BC000I8_n144SecUserEmail, BC000I8_A150SecUserStatus, BC000I8_n150SecUserStatus, BC000I8_A142SecUserPassword, BC000I8_n142SecUserPassword, BC000I8_A791SecUserAnalista, BC000I8_n791SecUserAnalista, BC000I8_A146SecUserUpdateAt, BC000I8_n146SecUserUpdateAt, BC000I8_A148SecUserManName,
               BC000I8_n148SecUserManName, BC000I8_A149SecUserManFullName, BC000I8_n149SecUserManFullName, BC000I8_A208SecUserTemp, BC000I8_n208SecUserTemp, BC000I8_A209SecUserClienteAcesso, BC000I8_n209SecUserClienteAcesso, BC000I8_A153SecUserTeste, BC000I8_n153SecUserTeste, BC000I8_A211SecUserClienteFullName,
               BC000I8_n211SecUserClienteFullName, BC000I8_A212SecUserClienteStatus, BC000I8_n212SecUserClienteStatus, BC000I8_A213SecUserCliClienteAcesso, BC000I8_n213SecUserCliClienteAcesso, BC000I8_A793TipoClientePortalPjPf, BC000I8_n793TipoClientePortalPjPf, BC000I8_A226SecUserOwnerId, BC000I8_n226SecUserOwnerId, BC000I8_A147SecUserUserMan,
               BC000I8_n147SecUserUserMan, BC000I8_A210SecUserClienteId, BC000I8_n210SecUserClienteId
               }
               , new Object[] {
               BC000I9_A133SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000I11_A133SecUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000I14_A148SecUserManName, BC000I14_n148SecUserManName, BC000I14_A149SecUserManFullName, BC000I14_n149SecUserManFullName
               }
               , new Object[] {
               BC000I15_A211SecUserClienteFullName, BC000I15_n211SecUserClienteFullName, BC000I15_A212SecUserClienteStatus, BC000I15_n212SecUserClienteStatus, BC000I15_A213SecUserCliClienteAcesso, BC000I15_n213SecUserCliClienteAcesso
               }
               , new Object[] {
               BC000I16_A192TipoClienteId, BC000I16_n192TipoClienteId
               }
               , new Object[] {
               BC000I17_A793TipoClientePortalPjPf, BC000I17_n793TipoClientePortalPjPf
               }
               , new Object[] {
               BC000I18_A210SecUserClienteId
               }
               , new Object[] {
               BC000I19_A147SecUserUserMan
               }
               , new Object[] {
               BC000I20_A961ChavePIXId
               }
               , new Object[] {
               BC000I21_A961ChavePIXId
               }
               , new Object[] {
               BC000I22_A951ContaBancariaId
               }
               , new Object[] {
               BC000I23_A951ContaBancariaId
               }
               , new Object[] {
               BC000I24_A938AgenciaId
               }
               , new Object[] {
               BC000I25_A938AgenciaId
               }
               , new Object[] {
               BC000I26_A863TaxasId
               }
               , new Object[] {
               BC000I27_A863TaxasId
               }
               , new Object[] {
               BC000I28_A856CreditoId
               }
               , new Object[] {
               BC000I29_A856CreditoId
               }
               , new Object[] {
               BC000I30_A746ReembolsoFlowLogId
               }
               , new Object[] {
               BC000I31_A599ClienteDocumentoId
               }
               , new Object[] {
               BC000I32_A457EspecialidadeId
               }
               , new Object[] {
               BC000I33_A518ReembolsoId
               }
               , new Object[] {
               BC000I34_A387UserNotificationId
               }
               , new Object[] {
               BC000I35_A323PropostaId
               }
               , new Object[] {
               BC000I36_A559SecUserLogId
               }
               , new Object[] {
               BC000I37_A478ConfiguracoesTestemunhasId
               }
               , new Object[] {
               BC000I38_A381NotificationId
               }
               , new Object[] {
               BC000I39_A375AprovadoresId
               }
               , new Object[] {
               BC000I40_A164SecUserTokenID
               }
               , new Object[] {
               BC000I41_A133SecUserId, BC000I41_A131SecRoleId
               }
               , new Object[] {
               BC000I42_A192TipoClienteId, BC000I42_n192TipoClienteId, BC000I42_A133SecUserId, BC000I42_A145SecUserCreatedAt, BC000I42_n145SecUserCreatedAt, BC000I42_A141SecUserName, BC000I42_n141SecUserName, BC000I42_A143SecUserFullName, BC000I42_n143SecUserFullName, BC000I42_A144SecUserEmail,
               BC000I42_n144SecUserEmail, BC000I42_A150SecUserStatus, BC000I42_n150SecUserStatus, BC000I42_A142SecUserPassword, BC000I42_n142SecUserPassword, BC000I42_A791SecUserAnalista, BC000I42_n791SecUserAnalista, BC000I42_A146SecUserUpdateAt, BC000I42_n146SecUserUpdateAt, BC000I42_A148SecUserManName,
               BC000I42_n148SecUserManName, BC000I42_A149SecUserManFullName, BC000I42_n149SecUserManFullName, BC000I42_A208SecUserTemp, BC000I42_n208SecUserTemp, BC000I42_A209SecUserClienteAcesso, BC000I42_n209SecUserClienteAcesso, BC000I42_A153SecUserTeste, BC000I42_n153SecUserTeste, BC000I42_A211SecUserClienteFullName,
               BC000I42_n211SecUserClienteFullName, BC000I42_A212SecUserClienteStatus, BC000I42_n212SecUserClienteStatus, BC000I42_A213SecUserCliClienteAcesso, BC000I42_n213SecUserCliClienteAcesso, BC000I42_A793TipoClientePortalPjPf, BC000I42_n793TipoClientePortalPjPf, BC000I42_A226SecUserOwnerId, BC000I42_n226SecUserOwnerId, BC000I42_A147SecUserUserMan,
               BC000I42_n147SecUserUserMan, BC000I42_A210SecUserClienteId, BC000I42_n210SecUserClienteId
               }
            }
         );
         AV25Pgmname = "SecUser_BC";
         Z150SecUserStatus = true;
         n150SecUserStatus = false;
         A150SecUserStatus = true;
         n150SecUserStatus = false;
         N150SecUserStatus = true;
         n150SecUserStatus = false;
         i150SecUserStatus = true;
         n150SecUserStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120I2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z133SecUserId ;
      private short A133SecUserId ;
      private short AV20Insert_SecUserUserMan ;
      private short AV22Insert_SecUserClienteId ;
      private short Z147SecUserUserMan ;
      private short A147SecUserUserMan ;
      private short Z210SecUserClienteId ;
      private short A210SecUserClienteId ;
      private short Z192TipoClienteId ;
      private short A192TipoClienteId ;
      private short Gx_BScreen ;
      private short RcdFound22 ;
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
      private bool Z791SecUserAnalista ;
      private bool A791SecUserAnalista ;
      private bool Z208SecUserTemp ;
      private bool A208SecUserTemp ;
      private bool Z209SecUserClienteAcesso ;
      private bool A209SecUserClienteAcesso ;
      private bool Z212SecUserClienteStatus ;
      private bool A212SecUserClienteStatus ;
      private bool Z213SecUserCliClienteAcesso ;
      private bool A213SecUserCliClienteAcesso ;
      private bool Z793TipoClientePortalPjPf ;
      private bool A793TipoClientePortalPjPf ;
      private bool n145SecUserCreatedAt ;
      private bool n150SecUserStatus ;
      private bool n133SecUserId ;
      private bool n192TipoClienteId ;
      private bool n141SecUserName ;
      private bool n143SecUserFullName ;
      private bool n144SecUserEmail ;
      private bool n142SecUserPassword ;
      private bool n791SecUserAnalista ;
      private bool n146SecUserUpdateAt ;
      private bool n148SecUserManName ;
      private bool n149SecUserManFullName ;
      private bool n208SecUserTemp ;
      private bool n209SecUserClienteAcesso ;
      private bool n153SecUserTeste ;
      private bool n211SecUserClienteFullName ;
      private bool n212SecUserClienteStatus ;
      private bool n213SecUserCliClienteAcesso ;
      private bool n793TipoClientePortalPjPf ;
      private bool n226SecUserOwnerId ;
      private bool n147SecUserUserMan ;
      private bool n210SecUserClienteId ;
      private bool Gx_longc ;
      private bool N150SecUserStatus ;
      private bool i150SecUserStatus ;
      private string Z153SecUserTeste ;
      private string A153SecUserTeste ;
      private string Z141SecUserName ;
      private string A141SecUserName ;
      private string Z143SecUserFullName ;
      private string A143SecUserFullName ;
      private string Z144SecUserEmail ;
      private string A144SecUserEmail ;
      private string Z142SecUserPassword ;
      private string A142SecUserPassword ;
      private string Z148SecUserManName ;
      private string A148SecUserManName ;
      private string Z149SecUserManFullName ;
      private string A149SecUserManFullName ;
      private string Z211SecUserClienteFullName ;
      private string A211SecUserClienteFullName ;
      private IGxSession AV12WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV15WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV11TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV21TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private short[] BC000I8_A192TipoClienteId ;
      private bool[] BC000I8_n192TipoClienteId ;
      private short[] BC000I8_A133SecUserId ;
      private bool[] BC000I8_n133SecUserId ;
      private DateTime[] BC000I8_A145SecUserCreatedAt ;
      private bool[] BC000I8_n145SecUserCreatedAt ;
      private string[] BC000I8_A141SecUserName ;
      private bool[] BC000I8_n141SecUserName ;
      private string[] BC000I8_A143SecUserFullName ;
      private bool[] BC000I8_n143SecUserFullName ;
      private string[] BC000I8_A144SecUserEmail ;
      private bool[] BC000I8_n144SecUserEmail ;
      private bool[] BC000I8_A150SecUserStatus ;
      private bool[] BC000I8_n150SecUserStatus ;
      private string[] BC000I8_A142SecUserPassword ;
      private bool[] BC000I8_n142SecUserPassword ;
      private bool[] BC000I8_A791SecUserAnalista ;
      private bool[] BC000I8_n791SecUserAnalista ;
      private DateTime[] BC000I8_A146SecUserUpdateAt ;
      private bool[] BC000I8_n146SecUserUpdateAt ;
      private string[] BC000I8_A148SecUserManName ;
      private bool[] BC000I8_n148SecUserManName ;
      private string[] BC000I8_A149SecUserManFullName ;
      private bool[] BC000I8_n149SecUserManFullName ;
      private bool[] BC000I8_A208SecUserTemp ;
      private bool[] BC000I8_n208SecUserTemp ;
      private bool[] BC000I8_A209SecUserClienteAcesso ;
      private bool[] BC000I8_n209SecUserClienteAcesso ;
      private string[] BC000I8_A153SecUserTeste ;
      private bool[] BC000I8_n153SecUserTeste ;
      private string[] BC000I8_A211SecUserClienteFullName ;
      private bool[] BC000I8_n211SecUserClienteFullName ;
      private bool[] BC000I8_A212SecUserClienteStatus ;
      private bool[] BC000I8_n212SecUserClienteStatus ;
      private bool[] BC000I8_A213SecUserCliClienteAcesso ;
      private bool[] BC000I8_n213SecUserCliClienteAcesso ;
      private bool[] BC000I8_A793TipoClientePortalPjPf ;
      private bool[] BC000I8_n793TipoClientePortalPjPf ;
      private int[] BC000I8_A226SecUserOwnerId ;
      private bool[] BC000I8_n226SecUserOwnerId ;
      private short[] BC000I8_A147SecUserUserMan ;
      private bool[] BC000I8_n147SecUserUserMan ;
      private short[] BC000I8_A210SecUserClienteId ;
      private bool[] BC000I8_n210SecUserClienteId ;
      private string[] BC000I5_A148SecUserManName ;
      private bool[] BC000I5_n148SecUserManName ;
      private string[] BC000I5_A149SecUserManFullName ;
      private bool[] BC000I5_n149SecUserManFullName ;
      private string[] BC000I6_A211SecUserClienteFullName ;
      private bool[] BC000I6_n211SecUserClienteFullName ;
      private bool[] BC000I6_A212SecUserClienteStatus ;
      private bool[] BC000I6_n212SecUserClienteStatus ;
      private bool[] BC000I6_A213SecUserCliClienteAcesso ;
      private bool[] BC000I6_n213SecUserCliClienteAcesso ;
      private short[] BC000I4_A192TipoClienteId ;
      private bool[] BC000I4_n192TipoClienteId ;
      private bool[] BC000I7_A793TipoClientePortalPjPf ;
      private bool[] BC000I7_n793TipoClientePortalPjPf ;
      private short[] BC000I9_A133SecUserId ;
      private bool[] BC000I9_n133SecUserId ;
      private short[] BC000I3_A133SecUserId ;
      private bool[] BC000I3_n133SecUserId ;
      private DateTime[] BC000I3_A145SecUserCreatedAt ;
      private bool[] BC000I3_n145SecUserCreatedAt ;
      private string[] BC000I3_A141SecUserName ;
      private bool[] BC000I3_n141SecUserName ;
      private string[] BC000I3_A143SecUserFullName ;
      private bool[] BC000I3_n143SecUserFullName ;
      private string[] BC000I3_A144SecUserEmail ;
      private bool[] BC000I3_n144SecUserEmail ;
      private bool[] BC000I3_A150SecUserStatus ;
      private bool[] BC000I3_n150SecUserStatus ;
      private string[] BC000I3_A142SecUserPassword ;
      private bool[] BC000I3_n142SecUserPassword ;
      private bool[] BC000I3_A791SecUserAnalista ;
      private bool[] BC000I3_n791SecUserAnalista ;
      private DateTime[] BC000I3_A146SecUserUpdateAt ;
      private bool[] BC000I3_n146SecUserUpdateAt ;
      private bool[] BC000I3_A208SecUserTemp ;
      private bool[] BC000I3_n208SecUserTemp ;
      private bool[] BC000I3_A209SecUserClienteAcesso ;
      private bool[] BC000I3_n209SecUserClienteAcesso ;
      private string[] BC000I3_A153SecUserTeste ;
      private bool[] BC000I3_n153SecUserTeste ;
      private int[] BC000I3_A226SecUserOwnerId ;
      private bool[] BC000I3_n226SecUserOwnerId ;
      private short[] BC000I3_A147SecUserUserMan ;
      private bool[] BC000I3_n147SecUserUserMan ;
      private short[] BC000I3_A210SecUserClienteId ;
      private bool[] BC000I3_n210SecUserClienteId ;
      private short[] BC000I2_A133SecUserId ;
      private bool[] BC000I2_n133SecUserId ;
      private DateTime[] BC000I2_A145SecUserCreatedAt ;
      private bool[] BC000I2_n145SecUserCreatedAt ;
      private string[] BC000I2_A141SecUserName ;
      private bool[] BC000I2_n141SecUserName ;
      private string[] BC000I2_A143SecUserFullName ;
      private bool[] BC000I2_n143SecUserFullName ;
      private string[] BC000I2_A144SecUserEmail ;
      private bool[] BC000I2_n144SecUserEmail ;
      private bool[] BC000I2_A150SecUserStatus ;
      private bool[] BC000I2_n150SecUserStatus ;
      private string[] BC000I2_A142SecUserPassword ;
      private bool[] BC000I2_n142SecUserPassword ;
      private bool[] BC000I2_A791SecUserAnalista ;
      private bool[] BC000I2_n791SecUserAnalista ;
      private DateTime[] BC000I2_A146SecUserUpdateAt ;
      private bool[] BC000I2_n146SecUserUpdateAt ;
      private bool[] BC000I2_A208SecUserTemp ;
      private bool[] BC000I2_n208SecUserTemp ;
      private bool[] BC000I2_A209SecUserClienteAcesso ;
      private bool[] BC000I2_n209SecUserClienteAcesso ;
      private string[] BC000I2_A153SecUserTeste ;
      private bool[] BC000I2_n153SecUserTeste ;
      private int[] BC000I2_A226SecUserOwnerId ;
      private bool[] BC000I2_n226SecUserOwnerId ;
      private short[] BC000I2_A147SecUserUserMan ;
      private bool[] BC000I2_n147SecUserUserMan ;
      private short[] BC000I2_A210SecUserClienteId ;
      private bool[] BC000I2_n210SecUserClienteId ;
      private short[] BC000I11_A133SecUserId ;
      private bool[] BC000I11_n133SecUserId ;
      private string[] BC000I14_A148SecUserManName ;
      private bool[] BC000I14_n148SecUserManName ;
      private string[] BC000I14_A149SecUserManFullName ;
      private bool[] BC000I14_n149SecUserManFullName ;
      private string[] BC000I15_A211SecUserClienteFullName ;
      private bool[] BC000I15_n211SecUserClienteFullName ;
      private bool[] BC000I15_A212SecUserClienteStatus ;
      private bool[] BC000I15_n212SecUserClienteStatus ;
      private bool[] BC000I15_A213SecUserCliClienteAcesso ;
      private bool[] BC000I15_n213SecUserCliClienteAcesso ;
      private short[] BC000I16_A192TipoClienteId ;
      private bool[] BC000I16_n192TipoClienteId ;
      private bool[] BC000I17_A793TipoClientePortalPjPf ;
      private bool[] BC000I17_n793TipoClientePortalPjPf ;
      private short[] BC000I18_A210SecUserClienteId ;
      private bool[] BC000I18_n210SecUserClienteId ;
      private short[] BC000I19_A147SecUserUserMan ;
      private bool[] BC000I19_n147SecUserUserMan ;
      private int[] BC000I20_A961ChavePIXId ;
      private int[] BC000I21_A961ChavePIXId ;
      private int[] BC000I22_A951ContaBancariaId ;
      private int[] BC000I23_A951ContaBancariaId ;
      private int[] BC000I24_A938AgenciaId ;
      private int[] BC000I25_A938AgenciaId ;
      private int[] BC000I26_A863TaxasId ;
      private int[] BC000I27_A863TaxasId ;
      private int[] BC000I28_A856CreditoId ;
      private int[] BC000I29_A856CreditoId ;
      private int[] BC000I30_A746ReembolsoFlowLogId ;
      private int[] BC000I31_A599ClienteDocumentoId ;
      private int[] BC000I32_A457EspecialidadeId ;
      private int[] BC000I33_A518ReembolsoId ;
      private int[] BC000I34_A387UserNotificationId ;
      private int[] BC000I35_A323PropostaId ;
      private int[] BC000I36_A559SecUserLogId ;
      private int[] BC000I37_A478ConfiguracoesTestemunhasId ;
      private int[] BC000I38_A381NotificationId ;
      private int[] BC000I39_A375AprovadoresId ;
      private short[] BC000I40_A164SecUserTokenID ;
      private short[] BC000I41_A133SecUserId ;
      private bool[] BC000I41_n133SecUserId ;
      private short[] BC000I41_A131SecRoleId ;
      private short[] BC000I42_A192TipoClienteId ;
      private bool[] BC000I42_n192TipoClienteId ;
      private short[] BC000I42_A133SecUserId ;
      private bool[] BC000I42_n133SecUserId ;
      private DateTime[] BC000I42_A145SecUserCreatedAt ;
      private bool[] BC000I42_n145SecUserCreatedAt ;
      private string[] BC000I42_A141SecUserName ;
      private bool[] BC000I42_n141SecUserName ;
      private string[] BC000I42_A143SecUserFullName ;
      private bool[] BC000I42_n143SecUserFullName ;
      private string[] BC000I42_A144SecUserEmail ;
      private bool[] BC000I42_n144SecUserEmail ;
      private bool[] BC000I42_A150SecUserStatus ;
      private bool[] BC000I42_n150SecUserStatus ;
      private string[] BC000I42_A142SecUserPassword ;
      private bool[] BC000I42_n142SecUserPassword ;
      private bool[] BC000I42_A791SecUserAnalista ;
      private bool[] BC000I42_n791SecUserAnalista ;
      private DateTime[] BC000I42_A146SecUserUpdateAt ;
      private bool[] BC000I42_n146SecUserUpdateAt ;
      private string[] BC000I42_A148SecUserManName ;
      private bool[] BC000I42_n148SecUserManName ;
      private string[] BC000I42_A149SecUserManFullName ;
      private bool[] BC000I42_n149SecUserManFullName ;
      private bool[] BC000I42_A208SecUserTemp ;
      private bool[] BC000I42_n208SecUserTemp ;
      private bool[] BC000I42_A209SecUserClienteAcesso ;
      private bool[] BC000I42_n209SecUserClienteAcesso ;
      private string[] BC000I42_A153SecUserTeste ;
      private bool[] BC000I42_n153SecUserTeste ;
      private string[] BC000I42_A211SecUserClienteFullName ;
      private bool[] BC000I42_n211SecUserClienteFullName ;
      private bool[] BC000I42_A212SecUserClienteStatus ;
      private bool[] BC000I42_n212SecUserClienteStatus ;
      private bool[] BC000I42_A213SecUserCliClienteAcesso ;
      private bool[] BC000I42_n213SecUserCliClienteAcesso ;
      private bool[] BC000I42_A793TipoClientePortalPjPf ;
      private bool[] BC000I42_n793TipoClientePortalPjPf ;
      private int[] BC000I42_A226SecUserOwnerId ;
      private bool[] BC000I42_n226SecUserOwnerId ;
      private short[] BC000I42_A147SecUserUserMan ;
      private bool[] BC000I42_n147SecUserUserMan ;
      private short[] BC000I42_A210SecUserClienteId ;
      private bool[] BC000I42_n210SecUserClienteId ;
      private SdtSecUser bcSecUser ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class secuser_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
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
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new ForEachCursor(def[38])
         ,new ForEachCursor(def[39])
         ,new ForEachCursor(def[40])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000I2;
          prmBC000I2 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I3;
          prmBC000I3 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I4;
          prmBC000I4 = new Object[] {
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000I5;
          prmBC000I5 = new Object[] {
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I6;
          prmBC000I6 = new Object[] {
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I7;
          prmBC000I7 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I8;
          prmBC000I8 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I9;
          prmBC000I9 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I10;
          prmBC000I10 = new Object[] {
          new ParDef("SecUserCreatedAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserName",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserFullName",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("SecUserEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserPassword",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserAnalista",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserUpdateAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserTemp",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserClienteAcesso",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserTeste",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I11;
          prmBC000I11 = new Object[] {
          };
          Object[] prmBC000I12;
          prmBC000I12 = new Object[] {
          new ParDef("SecUserCreatedAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserName",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserFullName",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("SecUserEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserPassword",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("SecUserAnalista",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserUpdateAt",GXType.DateTime,10,5){Nullable=true} ,
          new ParDef("SecUserTemp",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserClienteAcesso",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("SecUserTeste",GXType.LongVarChar,2097152,0){Nullable=true} ,
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I13;
          prmBC000I13 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I14;
          prmBC000I14 = new Object[] {
          new ParDef("SecUserUserMan",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I15;
          prmBC000I15 = new Object[] {
          new ParDef("SecUserClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I16;
          prmBC000I16 = new Object[] {
          new ParDef("SecUserOwnerId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC000I17;
          prmBC000I17 = new Object[] {
          new ParDef("TipoClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I18;
          prmBC000I18 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I19;
          prmBC000I19 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I20;
          prmBC000I20 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I21;
          prmBC000I21 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I22;
          prmBC000I22 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I23;
          prmBC000I23 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I24;
          prmBC000I24 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I25;
          prmBC000I25 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I26;
          prmBC000I26 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I27;
          prmBC000I27 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I28;
          prmBC000I28 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I29;
          prmBC000I29 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I30;
          prmBC000I30 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I31;
          prmBC000I31 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I32;
          prmBC000I32 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I33;
          prmBC000I33 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I34;
          prmBC000I34 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I35;
          prmBC000I35 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I36;
          prmBC000I36 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I37;
          prmBC000I37 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I38;
          prmBC000I38 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I39;
          prmBC000I39 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I40;
          prmBC000I40 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I41;
          prmBC000I41 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000I42;
          prmBC000I42 = new Object[] {
          new ParDef("SecUserId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC000I2", "SELECT SecUserId, SecUserCreatedAt, SecUserName, SecUserFullName, SecUserEmail, SecUserStatus, SecUserPassword, SecUserAnalista, SecUserUpdateAt, SecUserTemp, SecUserClienteAcesso, SecUserTeste, SecUserOwnerId, SecUserUserMan, SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserId  FOR UPDATE OF SecUser",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000I3", "SELECT SecUserId, SecUserCreatedAt, SecUserName, SecUserFullName, SecUserEmail, SecUserStatus, SecUserPassword, SecUserAnalista, SecUserUpdateAt, SecUserTemp, SecUserClienteAcesso, SecUserTeste, SecUserOwnerId, SecUserUserMan, SecUserClienteId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000I4", "SELECT TipoClienteId FROM Cliente WHERE ClienteId = :SecUserOwnerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000I5", "SELECT SecUserName AS SecUserManName, SecUserFullName AS SecUserManFullName FROM SecUser WHERE SecUserId = :SecUserUserMan ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000I6", "SELECT SecUserFullName AS SecUserClienteFullName, SecUserStatus AS SecUserClienteStatus, SecUserClienteAcesso AS SecUserCliClienteAcesso FROM SecUser WHERE SecUserId = :SecUserClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000I7", "SELECT TipoClientePortalPjPf FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000I8", "SELECT T4.TipoClienteId, TM1.SecUserId, TM1.SecUserCreatedAt, TM1.SecUserName, TM1.SecUserFullName, TM1.SecUserEmail, TM1.SecUserStatus, TM1.SecUserPassword, TM1.SecUserAnalista, TM1.SecUserUpdateAt, T2.SecUserName AS SecUserManName, T2.SecUserFullName AS SecUserManFullName, TM1.SecUserTemp, TM1.SecUserClienteAcesso, TM1.SecUserTeste, T3.SecUserFullName AS SecUserClienteFullName, T3.SecUserStatus AS SecUserClienteStatus, T3.SecUserClienteAcesso AS SecUserCliClienteAcesso, T5.TipoClientePortalPjPf, TM1.SecUserOwnerId AS SecUserOwnerId, TM1.SecUserUserMan AS SecUserUserMan, TM1.SecUserClienteId AS SecUserClienteId FROM ((((SecUser TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.SecUserUserMan) LEFT JOIN SecUser T3 ON T3.SecUserId = TM1.SecUserClienteId) LEFT JOIN Cliente T4 ON T4.ClienteId = TM1.SecUserOwnerId) LEFT JOIN TipoCliente T5 ON T5.TipoClienteId = T4.TipoClienteId) WHERE TM1.SecUserId = :SecUserId ORDER BY TM1.SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000I9", "SELECT SecUserId FROM SecUser WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000I10", "SAVEPOINT gxupdate;INSERT INTO SecUser(SecUserCreatedAt, SecUserName, SecUserFullName, SecUserEmail, SecUserStatus, SecUserPassword, SecUserAnalista, SecUserUpdateAt, SecUserTemp, SecUserClienteAcesso, SecUserTeste, SecUserOwnerId, SecUserUserMan, SecUserClienteId) VALUES(:SecUserCreatedAt, :SecUserName, :SecUserFullName, :SecUserEmail, :SecUserStatus, :SecUserPassword, :SecUserAnalista, :SecUserUpdateAt, :SecUserTemp, :SecUserClienteAcesso, :SecUserTeste, :SecUserOwnerId, :SecUserUserMan, :SecUserClienteId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000I10)
             ,new CursorDef("BC000I11", "SELECT currval('SecUserId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000I12", "SAVEPOINT gxupdate;UPDATE SecUser SET SecUserCreatedAt=:SecUserCreatedAt, SecUserName=:SecUserName, SecUserFullName=:SecUserFullName, SecUserEmail=:SecUserEmail, SecUserStatus=:SecUserStatus, SecUserPassword=:SecUserPassword, SecUserAnalista=:SecUserAnalista, SecUserUpdateAt=:SecUserUpdateAt, SecUserTemp=:SecUserTemp, SecUserClienteAcesso=:SecUserClienteAcesso, SecUserTeste=:SecUserTeste, SecUserOwnerId=:SecUserOwnerId, SecUserUserMan=:SecUserUserMan, SecUserClienteId=:SecUserClienteId  WHERE SecUserId = :SecUserId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000I12)
             ,new CursorDef("BC000I13", "SAVEPOINT gxupdate;DELETE FROM SecUser  WHERE SecUserId = :SecUserId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000I13)
             ,new CursorDef("BC000I14", "SELECT SecUserName AS SecUserManName, SecUserFullName AS SecUserManFullName FROM SecUser WHERE SecUserId = :SecUserUserMan ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000I15", "SELECT SecUserFullName AS SecUserClienteFullName, SecUserStatus AS SecUserClienteStatus, SecUserClienteAcesso AS SecUserCliClienteAcesso FROM SecUser WHERE SecUserId = :SecUserClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000I16", "SELECT TipoClienteId FROM Cliente WHERE ClienteId = :SecUserOwnerId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000I17", "SELECT TipoClientePortalPjPf FROM TipoCliente WHERE TipoClienteId = :TipoClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000I18", "SELECT SecUserId AS SecUserClienteId FROM SecUser WHERE SecUserClienteId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I19", "SELECT SecUserId AS SecUserUserMan FROM SecUser WHERE SecUserUserMan = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I19,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I20", "SELECT ChavePIXId FROM ChavePIX WHERE ChavePIXUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I20,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I21", "SELECT ChavePIXId FROM ChavePIX WHERE ChavePIXCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I22", "SELECT ContaBancariaId FROM ContaBancaria WHERE ContaBancariaUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I23", "SELECT ContaBancariaId FROM ContaBancaria WHERE ContaBancariaCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I23,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I24", "SELECT AgenciaId FROM Agencia WHERE AgenciaUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I24,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I25", "SELECT AgenciaId FROM Agencia WHERE AgenciaCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I25,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I26", "SELECT TaxasId FROM Taxas WHERE TaxasUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I26,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I27", "SELECT TaxasId FROM Taxas WHERE TaxasCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I27,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I28", "SELECT CreditoId FROM Credito WHERE CreditoUpdatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I28,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I29", "SELECT CreditoId FROM Credito WHERE CreditoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I29,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I30", "SELECT ReembolsoFlowLogId FROM ReembolsoFlowLog WHERE ReembolsoFlowLogUser = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I30,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I31", "SELECT ClienteDocumentoId FROM ClienteDocumento WHERE ClienteDocumentoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I31,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I32", "SELECT EspecialidadeId FROM Especialidade WHERE EspecialidadeCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I32,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I33", "SELECT ReembolsoId FROM Reembolso WHERE ReembolsoCreatedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I33,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I34", "SELECT UserNotificationId FROM UserNotification WHERE UserNotificationUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I34,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I35", "SELECT PropostaId FROM Proposta WHERE PropostaCratedBy = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I35,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I36", "SELECT SecUserLogId FROM SecUserLog WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I36,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I37", "SELECT ConfiguracoesTestemunhasId FROM ConfiguracoesTestemunhas WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I37,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I38", "SELECT NotificationId FROM Notification WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I38,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I39", "SELECT AprovadoresId FROM Aprovadores WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I39,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I40", "SELECT SecUserTokenID FROM SecUserToken WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I40,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I41", "SELECT SecUserId, SecRoleId FROM SecUserRole WHERE SecUserId = :SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I41,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000I42", "SELECT T4.TipoClienteId, TM1.SecUserId, TM1.SecUserCreatedAt, TM1.SecUserName, TM1.SecUserFullName, TM1.SecUserEmail, TM1.SecUserStatus, TM1.SecUserPassword, TM1.SecUserAnalista, TM1.SecUserUpdateAt, T2.SecUserName AS SecUserManName, T2.SecUserFullName AS SecUserManFullName, TM1.SecUserTemp, TM1.SecUserClienteAcesso, TM1.SecUserTeste, T3.SecUserFullName AS SecUserClienteFullName, T3.SecUserStatus AS SecUserClienteStatus, T3.SecUserClienteAcesso AS SecUserCliClienteAcesso, T5.TipoClientePortalPjPf, TM1.SecUserOwnerId AS SecUserOwnerId, TM1.SecUserUserMan AS SecUserUserMan, TM1.SecUserClienteId AS SecUserClienteId FROM ((((SecUser TM1 LEFT JOIN SecUser T2 ON T2.SecUserId = TM1.SecUserUserMan) LEFT JOIN SecUser T3 ON T3.SecUserId = TM1.SecUserClienteId) LEFT JOIN Cliente T4 ON T4.ClienteId = TM1.SecUserOwnerId) LEFT JOIN TipoCliente T5 ON T5.TipoClienteId = T4.TipoClienteId) WHERE TM1.SecUserId = :SecUserId ORDER BY TM1.SecUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I42,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((bool[]) buf[19])[0] = rslt.getBool(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getLongVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((short[]) buf[25])[0] = rslt.getShort(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((short[]) buf[27])[0] = rslt.getShort(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
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
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getLongVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((bool[]) buf[31])[0] = rslt.getBool(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((bool[]) buf[35])[0] = rslt.getBool(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((short[]) buf[39])[0] = rslt.getShort(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((short[]) buf[41])[0] = rslt.getShort(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 34 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 35 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 36 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 37 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 38 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 39 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 40 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
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
                ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((bool[]) buf[25])[0] = rslt.getBool(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((string[]) buf[27])[0] = rslt.getLongVarchar(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((string[]) buf[29])[0] = rslt.getVarchar(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((bool[]) buf[31])[0] = rslt.getBool(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((bool[]) buf[33])[0] = rslt.getBool(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((bool[]) buf[35])[0] = rslt.getBool(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((int[]) buf[37])[0] = rslt.getInt(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((short[]) buf[39])[0] = rslt.getShort(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((short[]) buf[41])[0] = rslt.getShort(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
       }
    }

 }

}
