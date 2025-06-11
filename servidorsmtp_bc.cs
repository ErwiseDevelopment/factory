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
   public class servidorsmtp_bc : GxSilentTrn, IGxSilentTrn
   {
      public servidorsmtp_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public servidorsmtp_bc( IGxContext context )
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
         ReadRow0M26( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0M26( ) ;
         standaloneModal( ) ;
         AddRow0M26( ) ;
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
            E110M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z158ServidorSMTPId = A158ServidorSMTPId;
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

      protected void CONFIRM_0M0( )
      {
         BeforeValidate0M26( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0M26( ) ;
            }
            else
            {
               CheckExtendedTable0M26( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0M26( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0M26( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z159ServidorSMTPServer = A159ServidorSMTPServer;
            Z160ServidorSMTPPorta = A160ServidorSMTPPorta;
            Z161ServidorSMTPEmail = A161ServidorSMTPEmail;
            Z162ServidorSMTPPass = A162ServidorSMTPPass;
            Z163ServidorSMTPUsuario = A163ServidorSMTPUsuario;
         }
         if ( GX_JID == -2 )
         {
            Z158ServidorSMTPId = A158ServidorSMTPId;
            Z159ServidorSMTPServer = A159ServidorSMTPServer;
            Z160ServidorSMTPPorta = A160ServidorSMTPPorta;
            Z161ServidorSMTPEmail = A161ServidorSMTPEmail;
            Z162ServidorSMTPPass = A162ServidorSMTPPass;
            Z163ServidorSMTPUsuario = A163ServidorSMTPUsuario;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0M26( )
      {
         /* Using cursor BC000M4 */
         pr_default.execute(2, new Object[] {A158ServidorSMTPId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound26 = 1;
            A159ServidorSMTPServer = BC000M4_A159ServidorSMTPServer[0];
            n159ServidorSMTPServer = BC000M4_n159ServidorSMTPServer[0];
            A160ServidorSMTPPorta = BC000M4_A160ServidorSMTPPorta[0];
            n160ServidorSMTPPorta = BC000M4_n160ServidorSMTPPorta[0];
            A161ServidorSMTPEmail = BC000M4_A161ServidorSMTPEmail[0];
            n161ServidorSMTPEmail = BC000M4_n161ServidorSMTPEmail[0];
            A162ServidorSMTPPass = BC000M4_A162ServidorSMTPPass[0];
            n162ServidorSMTPPass = BC000M4_n162ServidorSMTPPass[0];
            A163ServidorSMTPUsuario = BC000M4_A163ServidorSMTPUsuario[0];
            n163ServidorSMTPUsuario = BC000M4_n163ServidorSMTPUsuario[0];
            ZM0M26( -2) ;
         }
         pr_default.close(2);
         OnLoadActions0M26( ) ;
      }

      protected void OnLoadActions0M26( )
      {
      }

      protected void CheckExtendedTable0M26( )
      {
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A161ServidorSMTPEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A161ServidorSMTPEmail)) ) )
         {
            GX_msglist.addItem("O valor de Servidor SMTPEmail não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0M26( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0M26( )
      {
         /* Using cursor BC000M5 */
         pr_default.execute(3, new Object[] {A158ServidorSMTPId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000M3 */
         pr_default.execute(1, new Object[] {A158ServidorSMTPId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0M26( 2) ;
            RcdFound26 = 1;
            A158ServidorSMTPId = BC000M3_A158ServidorSMTPId[0];
            A159ServidorSMTPServer = BC000M3_A159ServidorSMTPServer[0];
            n159ServidorSMTPServer = BC000M3_n159ServidorSMTPServer[0];
            A160ServidorSMTPPorta = BC000M3_A160ServidorSMTPPorta[0];
            n160ServidorSMTPPorta = BC000M3_n160ServidorSMTPPorta[0];
            A161ServidorSMTPEmail = BC000M3_A161ServidorSMTPEmail[0];
            n161ServidorSMTPEmail = BC000M3_n161ServidorSMTPEmail[0];
            A162ServidorSMTPPass = BC000M3_A162ServidorSMTPPass[0];
            n162ServidorSMTPPass = BC000M3_n162ServidorSMTPPass[0];
            A163ServidorSMTPUsuario = BC000M3_A163ServidorSMTPUsuario[0];
            n163ServidorSMTPUsuario = BC000M3_n163ServidorSMTPUsuario[0];
            Z158ServidorSMTPId = A158ServidorSMTPId;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0M26( ) ;
            if ( AnyError == 1 )
            {
               RcdFound26 = 0;
               InitializeNonKey0M26( ) ;
            }
            Gx_mode = sMode26;
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0M26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode26;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0M26( ) ;
         if ( RcdFound26 == 0 )
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
         CONFIRM_0M0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0M26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000M2 */
            pr_default.execute(0, new Object[] {A158ServidorSMTPId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ServidorSMTP"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z159ServidorSMTPServer, BC000M2_A159ServidorSMTPServer[0]) != 0 ) || ( StringUtil.StrCmp(Z160ServidorSMTPPorta, BC000M2_A160ServidorSMTPPorta[0]) != 0 ) || ( StringUtil.StrCmp(Z161ServidorSMTPEmail, BC000M2_A161ServidorSMTPEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z162ServidorSMTPPass, BC000M2_A162ServidorSMTPPass[0]) != 0 ) || ( StringUtil.StrCmp(Z163ServidorSMTPUsuario, BC000M2_A163ServidorSMTPUsuario[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ServidorSMTP"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M26( )
      {
         BeforeValidate0M26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M26( 0) ;
            CheckOptimisticConcurrency0M26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000M6 */
                     pr_default.execute(4, new Object[] {n159ServidorSMTPServer, A159ServidorSMTPServer, n160ServidorSMTPPorta, A160ServidorSMTPPorta, n161ServidorSMTPEmail, A161ServidorSMTPEmail, n162ServidorSMTPPass, A162ServidorSMTPPass, n163ServidorSMTPUsuario, A163ServidorSMTPUsuario});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000M7 */
                     pr_default.execute(5);
                     A158ServidorSMTPId = BC000M7_A158ServidorSMTPId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("ServidorSMTP");
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
               Load0M26( ) ;
            }
            EndLevel0M26( ) ;
         }
         CloseExtendedTableCursors0M26( ) ;
      }

      protected void Update0M26( )
      {
         BeforeValidate0M26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0M26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000M8 */
                     pr_default.execute(6, new Object[] {n159ServidorSMTPServer, A159ServidorSMTPServer, n160ServidorSMTPPorta, A160ServidorSMTPPorta, n161ServidorSMTPEmail, A161ServidorSMTPEmail, n162ServidorSMTPPass, A162ServidorSMTPPass, n163ServidorSMTPUsuario, A163ServidorSMTPUsuario, A158ServidorSMTPId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("ServidorSMTP");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ServidorSMTP"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0M26( ) ;
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
            EndLevel0M26( ) ;
         }
         CloseExtendedTableCursors0M26( ) ;
      }

      protected void DeferredUpdate0M26( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0M26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M26( ) ;
            AfterConfirm0M26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000M9 */
                  pr_default.execute(7, new Object[] {A158ServidorSMTPId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("ServidorSMTP");
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
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0M26( ) ;
         Gx_mode = sMode26;
      }

      protected void OnDeleteControls0M26( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0M26( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0M26( ) ;
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

      public void ScanKeyStart0M26( )
      {
         /* Scan By routine */
         /* Using cursor BC000M10 */
         pr_default.execute(8, new Object[] {A158ServidorSMTPId});
         RcdFound26 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound26 = 1;
            A158ServidorSMTPId = BC000M10_A158ServidorSMTPId[0];
            A159ServidorSMTPServer = BC000M10_A159ServidorSMTPServer[0];
            n159ServidorSMTPServer = BC000M10_n159ServidorSMTPServer[0];
            A160ServidorSMTPPorta = BC000M10_A160ServidorSMTPPorta[0];
            n160ServidorSMTPPorta = BC000M10_n160ServidorSMTPPorta[0];
            A161ServidorSMTPEmail = BC000M10_A161ServidorSMTPEmail[0];
            n161ServidorSMTPEmail = BC000M10_n161ServidorSMTPEmail[0];
            A162ServidorSMTPPass = BC000M10_A162ServidorSMTPPass[0];
            n162ServidorSMTPPass = BC000M10_n162ServidorSMTPPass[0];
            A163ServidorSMTPUsuario = BC000M10_A163ServidorSMTPUsuario[0];
            n163ServidorSMTPUsuario = BC000M10_n163ServidorSMTPUsuario[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0M26( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound26 = 0;
         ScanKeyLoad0M26( ) ;
      }

      protected void ScanKeyLoad0M26( )
      {
         sMode26 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound26 = 1;
            A158ServidorSMTPId = BC000M10_A158ServidorSMTPId[0];
            A159ServidorSMTPServer = BC000M10_A159ServidorSMTPServer[0];
            n159ServidorSMTPServer = BC000M10_n159ServidorSMTPServer[0];
            A160ServidorSMTPPorta = BC000M10_A160ServidorSMTPPorta[0];
            n160ServidorSMTPPorta = BC000M10_n160ServidorSMTPPorta[0];
            A161ServidorSMTPEmail = BC000M10_A161ServidorSMTPEmail[0];
            n161ServidorSMTPEmail = BC000M10_n161ServidorSMTPEmail[0];
            A162ServidorSMTPPass = BC000M10_A162ServidorSMTPPass[0];
            n162ServidorSMTPPass = BC000M10_n162ServidorSMTPPass[0];
            A163ServidorSMTPUsuario = BC000M10_A163ServidorSMTPUsuario[0];
            n163ServidorSMTPUsuario = BC000M10_n163ServidorSMTPUsuario[0];
         }
         Gx_mode = sMode26;
      }

      protected void ScanKeyEnd0M26( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0M26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M26( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0M26( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0M26( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0M26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M26( )
      {
      }

      protected void send_integrity_lvl_hashes0M26( )
      {
      }

      protected void AddRow0M26( )
      {
         VarsToRow26( bcServidorSMTP) ;
      }

      protected void ReadRow0M26( )
      {
         RowToVars26( bcServidorSMTP, 1) ;
      }

      protected void InitializeNonKey0M26( )
      {
         A159ServidorSMTPServer = "";
         n159ServidorSMTPServer = false;
         A160ServidorSMTPPorta = "";
         n160ServidorSMTPPorta = false;
         A161ServidorSMTPEmail = "";
         n161ServidorSMTPEmail = false;
         A162ServidorSMTPPass = "";
         n162ServidorSMTPPass = false;
         A163ServidorSMTPUsuario = "";
         n163ServidorSMTPUsuario = false;
         Z159ServidorSMTPServer = "";
         Z160ServidorSMTPPorta = "";
         Z161ServidorSMTPEmail = "";
         Z162ServidorSMTPPass = "";
         Z163ServidorSMTPUsuario = "";
      }

      protected void InitAll0M26( )
      {
         A158ServidorSMTPId = 0;
         InitializeNonKey0M26( ) ;
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

      public void VarsToRow26( SdtServidorSMTP obj26 )
      {
         obj26.gxTpr_Mode = Gx_mode;
         obj26.gxTpr_Servidorsmtpserver = A159ServidorSMTPServer;
         obj26.gxTpr_Servidorsmtpporta = A160ServidorSMTPPorta;
         obj26.gxTpr_Servidorsmtpemail = A161ServidorSMTPEmail;
         obj26.gxTpr_Servidorsmtppass = A162ServidorSMTPPass;
         obj26.gxTpr_Servidorsmtpusuario = A163ServidorSMTPUsuario;
         obj26.gxTpr_Servidorsmtpid = A158ServidorSMTPId;
         obj26.gxTpr_Servidorsmtpid_Z = Z158ServidorSMTPId;
         obj26.gxTpr_Servidorsmtpserver_Z = Z159ServidorSMTPServer;
         obj26.gxTpr_Servidorsmtpporta_Z = Z160ServidorSMTPPorta;
         obj26.gxTpr_Servidorsmtpemail_Z = Z161ServidorSMTPEmail;
         obj26.gxTpr_Servidorsmtppass_Z = Z162ServidorSMTPPass;
         obj26.gxTpr_Servidorsmtpusuario_Z = Z163ServidorSMTPUsuario;
         obj26.gxTpr_Servidorsmtpserver_N = (short)(Convert.ToInt16(n159ServidorSMTPServer));
         obj26.gxTpr_Servidorsmtpporta_N = (short)(Convert.ToInt16(n160ServidorSMTPPorta));
         obj26.gxTpr_Servidorsmtpemail_N = (short)(Convert.ToInt16(n161ServidorSMTPEmail));
         obj26.gxTpr_Servidorsmtppass_N = (short)(Convert.ToInt16(n162ServidorSMTPPass));
         obj26.gxTpr_Servidorsmtpusuario_N = (short)(Convert.ToInt16(n163ServidorSMTPUsuario));
         obj26.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow26( SdtServidorSMTP obj26 )
      {
         obj26.gxTpr_Servidorsmtpid = A158ServidorSMTPId;
         return  ;
      }

      public void RowToVars26( SdtServidorSMTP obj26 ,
                               int forceLoad )
      {
         Gx_mode = obj26.gxTpr_Mode;
         A159ServidorSMTPServer = obj26.gxTpr_Servidorsmtpserver;
         n159ServidorSMTPServer = false;
         A160ServidorSMTPPorta = obj26.gxTpr_Servidorsmtpporta;
         n160ServidorSMTPPorta = false;
         A161ServidorSMTPEmail = obj26.gxTpr_Servidorsmtpemail;
         n161ServidorSMTPEmail = false;
         A162ServidorSMTPPass = obj26.gxTpr_Servidorsmtppass;
         n162ServidorSMTPPass = false;
         A163ServidorSMTPUsuario = obj26.gxTpr_Servidorsmtpusuario;
         n163ServidorSMTPUsuario = false;
         A158ServidorSMTPId = obj26.gxTpr_Servidorsmtpid;
         Z158ServidorSMTPId = obj26.gxTpr_Servidorsmtpid_Z;
         Z159ServidorSMTPServer = obj26.gxTpr_Servidorsmtpserver_Z;
         Z160ServidorSMTPPorta = obj26.gxTpr_Servidorsmtpporta_Z;
         Z161ServidorSMTPEmail = obj26.gxTpr_Servidorsmtpemail_Z;
         Z162ServidorSMTPPass = obj26.gxTpr_Servidorsmtppass_Z;
         Z163ServidorSMTPUsuario = obj26.gxTpr_Servidorsmtpusuario_Z;
         n159ServidorSMTPServer = (bool)(Convert.ToBoolean(obj26.gxTpr_Servidorsmtpserver_N));
         n160ServidorSMTPPorta = (bool)(Convert.ToBoolean(obj26.gxTpr_Servidorsmtpporta_N));
         n161ServidorSMTPEmail = (bool)(Convert.ToBoolean(obj26.gxTpr_Servidorsmtpemail_N));
         n162ServidorSMTPPass = (bool)(Convert.ToBoolean(obj26.gxTpr_Servidorsmtppass_N));
         n163ServidorSMTPUsuario = (bool)(Convert.ToBoolean(obj26.gxTpr_Servidorsmtpusuario_N));
         Gx_mode = obj26.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A158ServidorSMTPId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0M26( ) ;
         ScanKeyStart0M26( ) ;
         if ( RcdFound26 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z158ServidorSMTPId = A158ServidorSMTPId;
         }
         ZM0M26( -2) ;
         OnLoadActions0M26( ) ;
         AddRow0M26( ) ;
         ScanKeyEnd0M26( ) ;
         if ( RcdFound26 == 0 )
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
         RowToVars26( bcServidorSMTP, 0) ;
         ScanKeyStart0M26( ) ;
         if ( RcdFound26 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z158ServidorSMTPId = A158ServidorSMTPId;
         }
         ZM0M26( -2) ;
         OnLoadActions0M26( ) ;
         AddRow0M26( ) ;
         ScanKeyEnd0M26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0M26( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0M26( ) ;
         }
         else
         {
            if ( RcdFound26 == 1 )
            {
               if ( A158ServidorSMTPId != Z158ServidorSMTPId )
               {
                  A158ServidorSMTPId = Z158ServidorSMTPId;
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
                  Update0M26( ) ;
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
                  if ( A158ServidorSMTPId != Z158ServidorSMTPId )
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
                        Insert0M26( ) ;
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
                        Insert0M26( ) ;
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
         RowToVars26( bcServidorSMTP, 1) ;
         SaveImpl( ) ;
         VarsToRow26( bcServidorSMTP) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars26( bcServidorSMTP, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0M26( ) ;
         AfterTrn( ) ;
         VarsToRow26( bcServidorSMTP) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow26( bcServidorSMTP) ;
         }
         else
         {
            SdtServidorSMTP auxBC = new SdtServidorSMTP(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A158ServidorSMTPId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcServidorSMTP);
               auxBC.Save();
               bcServidorSMTP.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars26( bcServidorSMTP, 1) ;
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
         RowToVars26( bcServidorSMTP, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0M26( ) ;
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
               VarsToRow26( bcServidorSMTP) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow26( bcServidorSMTP) ;
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
         RowToVars26( bcServidorSMTP, 0) ;
         GetKey0M26( ) ;
         if ( RcdFound26 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A158ServidorSMTPId != Z158ServidorSMTPId )
            {
               A158ServidorSMTPId = Z158ServidorSMTPId;
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
            if ( A158ServidorSMTPId != Z158ServidorSMTPId )
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
         context.RollbackDataStores("servidorsmtp_bc",pr_default);
         VarsToRow26( bcServidorSMTP) ;
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
         Gx_mode = bcServidorSMTP.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcServidorSMTP.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcServidorSMTP )
         {
            bcServidorSMTP = (SdtServidorSMTP)(sdt);
            if ( StringUtil.StrCmp(bcServidorSMTP.gxTpr_Mode, "") == 0 )
            {
               bcServidorSMTP.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow26( bcServidorSMTP) ;
            }
            else
            {
               RowToVars26( bcServidorSMTP, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcServidorSMTP.gxTpr_Mode, "") == 0 )
            {
               bcServidorSMTP.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars26( bcServidorSMTP, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtServidorSMTP ServidorSMTP_BC
      {
         get {
            return bcServidorSMTP ;
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
         Z159ServidorSMTPServer = "";
         A159ServidorSMTPServer = "";
         Z160ServidorSMTPPorta = "";
         A160ServidorSMTPPorta = "";
         Z161ServidorSMTPEmail = "";
         A161ServidorSMTPEmail = "";
         Z162ServidorSMTPPass = "";
         A162ServidorSMTPPass = "";
         Z163ServidorSMTPUsuario = "";
         A163ServidorSMTPUsuario = "";
         BC000M4_A158ServidorSMTPId = new short[1] ;
         BC000M4_A159ServidorSMTPServer = new string[] {""} ;
         BC000M4_n159ServidorSMTPServer = new bool[] {false} ;
         BC000M4_A160ServidorSMTPPorta = new string[] {""} ;
         BC000M4_n160ServidorSMTPPorta = new bool[] {false} ;
         BC000M4_A161ServidorSMTPEmail = new string[] {""} ;
         BC000M4_n161ServidorSMTPEmail = new bool[] {false} ;
         BC000M4_A162ServidorSMTPPass = new string[] {""} ;
         BC000M4_n162ServidorSMTPPass = new bool[] {false} ;
         BC000M4_A163ServidorSMTPUsuario = new string[] {""} ;
         BC000M4_n163ServidorSMTPUsuario = new bool[] {false} ;
         BC000M5_A158ServidorSMTPId = new short[1] ;
         BC000M3_A158ServidorSMTPId = new short[1] ;
         BC000M3_A159ServidorSMTPServer = new string[] {""} ;
         BC000M3_n159ServidorSMTPServer = new bool[] {false} ;
         BC000M3_A160ServidorSMTPPorta = new string[] {""} ;
         BC000M3_n160ServidorSMTPPorta = new bool[] {false} ;
         BC000M3_A161ServidorSMTPEmail = new string[] {""} ;
         BC000M3_n161ServidorSMTPEmail = new bool[] {false} ;
         BC000M3_A162ServidorSMTPPass = new string[] {""} ;
         BC000M3_n162ServidorSMTPPass = new bool[] {false} ;
         BC000M3_A163ServidorSMTPUsuario = new string[] {""} ;
         BC000M3_n163ServidorSMTPUsuario = new bool[] {false} ;
         sMode26 = "";
         BC000M2_A158ServidorSMTPId = new short[1] ;
         BC000M2_A159ServidorSMTPServer = new string[] {""} ;
         BC000M2_n159ServidorSMTPServer = new bool[] {false} ;
         BC000M2_A160ServidorSMTPPorta = new string[] {""} ;
         BC000M2_n160ServidorSMTPPorta = new bool[] {false} ;
         BC000M2_A161ServidorSMTPEmail = new string[] {""} ;
         BC000M2_n161ServidorSMTPEmail = new bool[] {false} ;
         BC000M2_A162ServidorSMTPPass = new string[] {""} ;
         BC000M2_n162ServidorSMTPPass = new bool[] {false} ;
         BC000M2_A163ServidorSMTPUsuario = new string[] {""} ;
         BC000M2_n163ServidorSMTPUsuario = new bool[] {false} ;
         BC000M7_A158ServidorSMTPId = new short[1] ;
         BC000M10_A158ServidorSMTPId = new short[1] ;
         BC000M10_A159ServidorSMTPServer = new string[] {""} ;
         BC000M10_n159ServidorSMTPServer = new bool[] {false} ;
         BC000M10_A160ServidorSMTPPorta = new string[] {""} ;
         BC000M10_n160ServidorSMTPPorta = new bool[] {false} ;
         BC000M10_A161ServidorSMTPEmail = new string[] {""} ;
         BC000M10_n161ServidorSMTPEmail = new bool[] {false} ;
         BC000M10_A162ServidorSMTPPass = new string[] {""} ;
         BC000M10_n162ServidorSMTPPass = new bool[] {false} ;
         BC000M10_A163ServidorSMTPUsuario = new string[] {""} ;
         BC000M10_n163ServidorSMTPUsuario = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.servidorsmtp_bc__default(),
            new Object[][] {
                new Object[] {
               BC000M2_A158ServidorSMTPId, BC000M2_A159ServidorSMTPServer, BC000M2_n159ServidorSMTPServer, BC000M2_A160ServidorSMTPPorta, BC000M2_n160ServidorSMTPPorta, BC000M2_A161ServidorSMTPEmail, BC000M2_n161ServidorSMTPEmail, BC000M2_A162ServidorSMTPPass, BC000M2_n162ServidorSMTPPass, BC000M2_A163ServidorSMTPUsuario,
               BC000M2_n163ServidorSMTPUsuario
               }
               , new Object[] {
               BC000M3_A158ServidorSMTPId, BC000M3_A159ServidorSMTPServer, BC000M3_n159ServidorSMTPServer, BC000M3_A160ServidorSMTPPorta, BC000M3_n160ServidorSMTPPorta, BC000M3_A161ServidorSMTPEmail, BC000M3_n161ServidorSMTPEmail, BC000M3_A162ServidorSMTPPass, BC000M3_n162ServidorSMTPPass, BC000M3_A163ServidorSMTPUsuario,
               BC000M3_n163ServidorSMTPUsuario
               }
               , new Object[] {
               BC000M4_A158ServidorSMTPId, BC000M4_A159ServidorSMTPServer, BC000M4_n159ServidorSMTPServer, BC000M4_A160ServidorSMTPPorta, BC000M4_n160ServidorSMTPPorta, BC000M4_A161ServidorSMTPEmail, BC000M4_n161ServidorSMTPEmail, BC000M4_A162ServidorSMTPPass, BC000M4_n162ServidorSMTPPass, BC000M4_A163ServidorSMTPUsuario,
               BC000M4_n163ServidorSMTPUsuario
               }
               , new Object[] {
               BC000M5_A158ServidorSMTPId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000M7_A158ServidorSMTPId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000M10_A158ServidorSMTPId, BC000M10_A159ServidorSMTPServer, BC000M10_n159ServidorSMTPServer, BC000M10_A160ServidorSMTPPorta, BC000M10_n160ServidorSMTPPorta, BC000M10_A161ServidorSMTPEmail, BC000M10_n161ServidorSMTPEmail, BC000M10_A162ServidorSMTPPass, BC000M10_n162ServidorSMTPPass, BC000M10_A163ServidorSMTPUsuario,
               BC000M10_n163ServidorSMTPUsuario
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120M2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z158ServidorSMTPId ;
      private short A158ServidorSMTPId ;
      private short RcdFound26 ;
      private int trnEnded ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode26 ;
      private bool returnInSub ;
      private bool n159ServidorSMTPServer ;
      private bool n160ServidorSMTPPorta ;
      private bool n161ServidorSMTPEmail ;
      private bool n162ServidorSMTPPass ;
      private bool n163ServidorSMTPUsuario ;
      private string Z159ServidorSMTPServer ;
      private string A159ServidorSMTPServer ;
      private string Z160ServidorSMTPPorta ;
      private string A160ServidorSMTPPorta ;
      private string Z161ServidorSMTPEmail ;
      private string A161ServidorSMTPEmail ;
      private string Z162ServidorSMTPPass ;
      private string A162ServidorSMTPPass ;
      private string Z163ServidorSMTPUsuario ;
      private string A163ServidorSMTPUsuario ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private short[] BC000M4_A158ServidorSMTPId ;
      private string[] BC000M4_A159ServidorSMTPServer ;
      private bool[] BC000M4_n159ServidorSMTPServer ;
      private string[] BC000M4_A160ServidorSMTPPorta ;
      private bool[] BC000M4_n160ServidorSMTPPorta ;
      private string[] BC000M4_A161ServidorSMTPEmail ;
      private bool[] BC000M4_n161ServidorSMTPEmail ;
      private string[] BC000M4_A162ServidorSMTPPass ;
      private bool[] BC000M4_n162ServidorSMTPPass ;
      private string[] BC000M4_A163ServidorSMTPUsuario ;
      private bool[] BC000M4_n163ServidorSMTPUsuario ;
      private short[] BC000M5_A158ServidorSMTPId ;
      private short[] BC000M3_A158ServidorSMTPId ;
      private string[] BC000M3_A159ServidorSMTPServer ;
      private bool[] BC000M3_n159ServidorSMTPServer ;
      private string[] BC000M3_A160ServidorSMTPPorta ;
      private bool[] BC000M3_n160ServidorSMTPPorta ;
      private string[] BC000M3_A161ServidorSMTPEmail ;
      private bool[] BC000M3_n161ServidorSMTPEmail ;
      private string[] BC000M3_A162ServidorSMTPPass ;
      private bool[] BC000M3_n162ServidorSMTPPass ;
      private string[] BC000M3_A163ServidorSMTPUsuario ;
      private bool[] BC000M3_n163ServidorSMTPUsuario ;
      private short[] BC000M2_A158ServidorSMTPId ;
      private string[] BC000M2_A159ServidorSMTPServer ;
      private bool[] BC000M2_n159ServidorSMTPServer ;
      private string[] BC000M2_A160ServidorSMTPPorta ;
      private bool[] BC000M2_n160ServidorSMTPPorta ;
      private string[] BC000M2_A161ServidorSMTPEmail ;
      private bool[] BC000M2_n161ServidorSMTPEmail ;
      private string[] BC000M2_A162ServidorSMTPPass ;
      private bool[] BC000M2_n162ServidorSMTPPass ;
      private string[] BC000M2_A163ServidorSMTPUsuario ;
      private bool[] BC000M2_n163ServidorSMTPUsuario ;
      private short[] BC000M7_A158ServidorSMTPId ;
      private short[] BC000M10_A158ServidorSMTPId ;
      private string[] BC000M10_A159ServidorSMTPServer ;
      private bool[] BC000M10_n159ServidorSMTPServer ;
      private string[] BC000M10_A160ServidorSMTPPorta ;
      private bool[] BC000M10_n160ServidorSMTPPorta ;
      private string[] BC000M10_A161ServidorSMTPEmail ;
      private bool[] BC000M10_n161ServidorSMTPEmail ;
      private string[] BC000M10_A162ServidorSMTPPass ;
      private bool[] BC000M10_n162ServidorSMTPPass ;
      private string[] BC000M10_A163ServidorSMTPUsuario ;
      private bool[] BC000M10_n163ServidorSMTPUsuario ;
      private SdtServidorSMTP bcServidorSMTP ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class servidorsmtp_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC000M2;
          prmBC000M2 = new Object[] {
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmBC000M3;
          prmBC000M3 = new Object[] {
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmBC000M4;
          prmBC000M4 = new Object[] {
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmBC000M5;
          prmBC000M5 = new Object[] {
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmBC000M6;
          prmBC000M6 = new Object[] {
          new ParDef("ServidorSMTPServer",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ServidorSMTPPorta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ServidorSMTPEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ServidorSMTPPass",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("ServidorSMTPUsuario",GXType.VarChar,90,0){Nullable=true}
          };
          Object[] prmBC000M7;
          prmBC000M7 = new Object[] {
          };
          Object[] prmBC000M8;
          prmBC000M8 = new Object[] {
          new ParDef("ServidorSMTPServer",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ServidorSMTPPorta",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ServidorSMTPEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ServidorSMTPPass",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("ServidorSMTPUsuario",GXType.VarChar,90,0){Nullable=true} ,
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmBC000M9;
          prmBC000M9 = new Object[] {
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          Object[] prmBC000M10;
          prmBC000M10 = new Object[] {
          new ParDef("ServidorSMTPId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000M2", "SELECT ServidorSMTPId, ServidorSMTPServer, ServidorSMTPPorta, ServidorSMTPEmail, ServidorSMTPPass, ServidorSMTPUsuario FROM ServidorSMTP WHERE ServidorSMTPId = :ServidorSMTPId  FOR UPDATE OF ServidorSMTP",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000M3", "SELECT ServidorSMTPId, ServidorSMTPServer, ServidorSMTPPorta, ServidorSMTPEmail, ServidorSMTPPass, ServidorSMTPUsuario FROM ServidorSMTP WHERE ServidorSMTPId = :ServidorSMTPId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000M4", "SELECT TM1.ServidorSMTPId, TM1.ServidorSMTPServer, TM1.ServidorSMTPPorta, TM1.ServidorSMTPEmail, TM1.ServidorSMTPPass, TM1.ServidorSMTPUsuario FROM ServidorSMTP TM1 WHERE TM1.ServidorSMTPId = :ServidorSMTPId ORDER BY TM1.ServidorSMTPId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000M5", "SELECT ServidorSMTPId FROM ServidorSMTP WHERE ServidorSMTPId = :ServidorSMTPId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000M6", "SAVEPOINT gxupdate;INSERT INTO ServidorSMTP(ServidorSMTPServer, ServidorSMTPPorta, ServidorSMTPEmail, ServidorSMTPPass, ServidorSMTPUsuario) VALUES(:ServidorSMTPServer, :ServidorSMTPPorta, :ServidorSMTPEmail, :ServidorSMTPPass, :ServidorSMTPUsuario);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000M6)
             ,new CursorDef("BC000M7", "SELECT currval('ServidorSMTPId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000M8", "SAVEPOINT gxupdate;UPDATE ServidorSMTP SET ServidorSMTPServer=:ServidorSMTPServer, ServidorSMTPPorta=:ServidorSMTPPorta, ServidorSMTPEmail=:ServidorSMTPEmail, ServidorSMTPPass=:ServidorSMTPPass, ServidorSMTPUsuario=:ServidorSMTPUsuario  WHERE ServidorSMTPId = :ServidorSMTPId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000M8)
             ,new CursorDef("BC000M9", "SAVEPOINT gxupdate;DELETE FROM ServidorSMTP  WHERE ServidorSMTPId = :ServidorSMTPId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000M9)
             ,new CursorDef("BC000M10", "SELECT TM1.ServidorSMTPId, TM1.ServidorSMTPServer, TM1.ServidorSMTPPorta, TM1.ServidorSMTPEmail, TM1.ServidorSMTPPass, TM1.ServidorSMTPUsuario FROM ServidorSMTP TM1 WHERE TM1.ServidorSMTPId = :ServidorSMTPId ORDER BY TM1.ServidorSMTPId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M10,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}
