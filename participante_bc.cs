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
   public class participante_bc : GxSilentTrn, IGxSilentTrn
   {
      public participante_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public participante_bc( IGxContext context )
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
         ReadRow0Z38( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0Z38( ) ;
         standaloneModal( ) ;
         AddRow0Z38( ) ;
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
            E110Z2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z233ParticipanteId = A233ParticipanteId;
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

      protected void CONFIRM_0Z0( )
      {
         BeforeValidate0Z38( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Z38( ) ;
            }
            else
            {
               CheckExtendedTable0Z38( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0Z38( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E120Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110Z2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0Z38( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z234ParticipanteDocumento = A234ParticipanteDocumento;
            Z248ParticipanteNome = A248ParticipanteNome;
            Z235ParticipanteEmail = A235ParticipanteEmail;
            Z1001ParticipanteTipoPessoa = A1001ParticipanteTipoPessoa;
            Z1002ParticipanteRepresentanteNome = A1002ParticipanteRepresentanteNome;
            Z1003ParticipanteRepresentanteEmail = A1003ParticipanteRepresentanteEmail;
            Z1004ParticipanteRepresentanteDocumento = A1004ParticipanteRepresentanteDocumento;
            Z1005ParticipanteEmail_F = A1005ParticipanteEmail_F;
            Z1006ParticipanteDocumento_F = A1006ParticipanteDocumento_F;
         }
         if ( GX_JID == -11 )
         {
            Z233ParticipanteId = A233ParticipanteId;
            Z234ParticipanteDocumento = A234ParticipanteDocumento;
            Z248ParticipanteNome = A248ParticipanteNome;
            Z235ParticipanteEmail = A235ParticipanteEmail;
            Z1001ParticipanteTipoPessoa = A1001ParticipanteTipoPessoa;
            Z1002ParticipanteRepresentanteNome = A1002ParticipanteRepresentanteNome;
            Z1003ParticipanteRepresentanteEmail = A1003ParticipanteRepresentanteEmail;
            Z1004ParticipanteRepresentanteDocumento = A1004ParticipanteRepresentanteDocumento;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0Z38( )
      {
         /* Using cursor BC000Z4 */
         pr_default.execute(2, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound38 = 1;
            A234ParticipanteDocumento = BC000Z4_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = BC000Z4_n234ParticipanteDocumento[0];
            A248ParticipanteNome = BC000Z4_A248ParticipanteNome[0];
            n248ParticipanteNome = BC000Z4_n248ParticipanteNome[0];
            A235ParticipanteEmail = BC000Z4_A235ParticipanteEmail[0];
            n235ParticipanteEmail = BC000Z4_n235ParticipanteEmail[0];
            A1001ParticipanteTipoPessoa = BC000Z4_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = BC000Z4_n1001ParticipanteTipoPessoa[0];
            A1002ParticipanteRepresentanteNome = BC000Z4_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = BC000Z4_n1002ParticipanteRepresentanteNome[0];
            A1003ParticipanteRepresentanteEmail = BC000Z4_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = BC000Z4_n1003ParticipanteRepresentanteEmail[0];
            A1004ParticipanteRepresentanteDocumento = BC000Z4_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = BC000Z4_n1004ParticipanteRepresentanteDocumento[0];
            ZM0Z38( -11) ;
         }
         pr_default.close(2);
         OnLoadActions0Z38( ) ;
      }

      protected void OnLoadActions0Z38( )
      {
         A1006ParticipanteDocumento_F = ((StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "JURIDICA")==0) ? A1004ParticipanteRepresentanteDocumento : A234ParticipanteDocumento);
         A1005ParticipanteEmail_F = ((StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "JURIDICA")==0) ? A1003ParticipanteRepresentanteEmail : A235ParticipanteEmail);
      }

      protected void CheckExtendedTable0Z38( )
      {
         standaloneModal( ) ;
         A1006ParticipanteDocumento_F = ((StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "JURIDICA")==0) ? A1004ParticipanteRepresentanteDocumento : A234ParticipanteDocumento);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A234ParticipanteDocumento)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Participante Documento", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A248ParticipanteNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Participante Nome", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A235ParticipanteEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A235ParticipanteEmail)) ) )
         {
            GX_msglist.addItem("O valor de Participante Email não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         A1005ParticipanteEmail_F = ((StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "JURIDICA")==0) ? A1003ParticipanteRepresentanteEmail : A235ParticipanteEmail);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A235ParticipanteEmail)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Participante Email", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "FISICA") == 0 ) || ( StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "JURIDICA") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1001ParticipanteTipoPessoa)) ) )
         {
            GX_msglist.addItem("Campo Participante Tipo Pessoa fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A1003ParticipanteRepresentanteEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") || String.IsNullOrEmpty(StringUtil.RTrim( A1003ParticipanteRepresentanteEmail)) ) )
         {
            GX_msglist.addItem("O valor de Participante Representante Email não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0Z38( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Z38( )
      {
         /* Using cursor BC000Z5 */
         pr_default.execute(3, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound38 = 1;
         }
         else
         {
            RcdFound38 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000Z3 */
         pr_default.execute(1, new Object[] {n233ParticipanteId, A233ParticipanteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Z38( 11) ;
            RcdFound38 = 1;
            A233ParticipanteId = BC000Z3_A233ParticipanteId[0];
            n233ParticipanteId = BC000Z3_n233ParticipanteId[0];
            A234ParticipanteDocumento = BC000Z3_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = BC000Z3_n234ParticipanteDocumento[0];
            A248ParticipanteNome = BC000Z3_A248ParticipanteNome[0];
            n248ParticipanteNome = BC000Z3_n248ParticipanteNome[0];
            A235ParticipanteEmail = BC000Z3_A235ParticipanteEmail[0];
            n235ParticipanteEmail = BC000Z3_n235ParticipanteEmail[0];
            A1001ParticipanteTipoPessoa = BC000Z3_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = BC000Z3_n1001ParticipanteTipoPessoa[0];
            A1002ParticipanteRepresentanteNome = BC000Z3_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = BC000Z3_n1002ParticipanteRepresentanteNome[0];
            A1003ParticipanteRepresentanteEmail = BC000Z3_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = BC000Z3_n1003ParticipanteRepresentanteEmail[0];
            A1004ParticipanteRepresentanteDocumento = BC000Z3_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = BC000Z3_n1004ParticipanteRepresentanteDocumento[0];
            Z233ParticipanteId = A233ParticipanteId;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0Z38( ) ;
            if ( AnyError == 1 )
            {
               RcdFound38 = 0;
               InitializeNonKey0Z38( ) ;
            }
            Gx_mode = sMode38;
         }
         else
         {
            RcdFound38 = 0;
            InitializeNonKey0Z38( ) ;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode38;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Z38( ) ;
         if ( RcdFound38 == 0 )
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
         CONFIRM_0Z0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0Z38( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Z2 */
            pr_default.execute(0, new Object[] {n233ParticipanteId, A233ParticipanteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Participante"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z234ParticipanteDocumento, BC000Z2_A234ParticipanteDocumento[0]) != 0 ) || ( StringUtil.StrCmp(Z248ParticipanteNome, BC000Z2_A248ParticipanteNome[0]) != 0 ) || ( StringUtil.StrCmp(Z235ParticipanteEmail, BC000Z2_A235ParticipanteEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z1001ParticipanteTipoPessoa, BC000Z2_A1001ParticipanteTipoPessoa[0]) != 0 ) || ( StringUtil.StrCmp(Z1002ParticipanteRepresentanteNome, BC000Z2_A1002ParticipanteRepresentanteNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1003ParticipanteRepresentanteEmail, BC000Z2_A1003ParticipanteRepresentanteEmail[0]) != 0 ) || ( StringUtil.StrCmp(Z1004ParticipanteRepresentanteDocumento, BC000Z2_A1004ParticipanteRepresentanteDocumento[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Participante"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z38( )
      {
         BeforeValidate0Z38( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z38( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z38( 0) ;
            CheckOptimisticConcurrency0Z38( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z38( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z38( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z6 */
                     pr_default.execute(4, new Object[] {n234ParticipanteDocumento, A234ParticipanteDocumento, n248ParticipanteNome, A248ParticipanteNome, n235ParticipanteEmail, A235ParticipanteEmail, n1001ParticipanteTipoPessoa, A1001ParticipanteTipoPessoa, n1002ParticipanteRepresentanteNome, A1002ParticipanteRepresentanteNome, n1003ParticipanteRepresentanteEmail, A1003ParticipanteRepresentanteEmail, n1004ParticipanteRepresentanteDocumento, A1004ParticipanteRepresentanteDocumento});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000Z7 */
                     pr_default.execute(5);
                     A233ParticipanteId = BC000Z7_A233ParticipanteId[0];
                     n233ParticipanteId = BC000Z7_n233ParticipanteId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Participante");
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
               Load0Z38( ) ;
            }
            EndLevel0Z38( ) ;
         }
         CloseExtendedTableCursors0Z38( ) ;
      }

      protected void Update0Z38( )
      {
         BeforeValidate0Z38( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z38( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z38( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z38( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z38( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Z8 */
                     pr_default.execute(6, new Object[] {n234ParticipanteDocumento, A234ParticipanteDocumento, n248ParticipanteNome, A248ParticipanteNome, n235ParticipanteEmail, A235ParticipanteEmail, n1001ParticipanteTipoPessoa, A1001ParticipanteTipoPessoa, n1002ParticipanteRepresentanteNome, A1002ParticipanteRepresentanteNome, n1003ParticipanteRepresentanteEmail, A1003ParticipanteRepresentanteEmail, n1004ParticipanteRepresentanteDocumento, A1004ParticipanteRepresentanteDocumento, n233ParticipanteId, A233ParticipanteId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Participante");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Participante"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z38( ) ;
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
            EndLevel0Z38( ) ;
         }
         CloseExtendedTableCursors0Z38( ) ;
      }

      protected void DeferredUpdate0Z38( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Z38( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z38( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z38( ) ;
            AfterConfirm0Z38( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z38( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000Z9 */
                  pr_default.execute(7, new Object[] {n233ParticipanteId, A233ParticipanteId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("Participante");
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
         sMode38 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Z38( ) ;
         Gx_mode = sMode38;
      }

      protected void OnDeleteControls0Z38( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A1005ParticipanteEmail_F = ((StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "JURIDICA")==0) ? A1003ParticipanteRepresentanteEmail : A235ParticipanteEmail);
            A1006ParticipanteDocumento_F = ((StringUtil.StrCmp(A1001ParticipanteTipoPessoa, "JURIDICA")==0) ? A1004ParticipanteRepresentanteDocumento : A234ParticipanteDocumento);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000Z10 */
            pr_default.execute(8, new Object[] {n233ParticipanteId, A233ParticipanteId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"AssinaturaParticipante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000Z11 */
            pr_default.execute(9, new Object[] {n233ParticipanteId, A233ParticipanteId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Contrato Participante"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0Z38( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Z38( ) ;
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

      public void ScanKeyStart0Z38( )
      {
         /* Scan By routine */
         /* Using cursor BC000Z12 */
         pr_default.execute(10, new Object[] {n233ParticipanteId, A233ParticipanteId});
         RcdFound38 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound38 = 1;
            A233ParticipanteId = BC000Z12_A233ParticipanteId[0];
            n233ParticipanteId = BC000Z12_n233ParticipanteId[0];
            A234ParticipanteDocumento = BC000Z12_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = BC000Z12_n234ParticipanteDocumento[0];
            A248ParticipanteNome = BC000Z12_A248ParticipanteNome[0];
            n248ParticipanteNome = BC000Z12_n248ParticipanteNome[0];
            A235ParticipanteEmail = BC000Z12_A235ParticipanteEmail[0];
            n235ParticipanteEmail = BC000Z12_n235ParticipanteEmail[0];
            A1001ParticipanteTipoPessoa = BC000Z12_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = BC000Z12_n1001ParticipanteTipoPessoa[0];
            A1002ParticipanteRepresentanteNome = BC000Z12_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = BC000Z12_n1002ParticipanteRepresentanteNome[0];
            A1003ParticipanteRepresentanteEmail = BC000Z12_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = BC000Z12_n1003ParticipanteRepresentanteEmail[0];
            A1004ParticipanteRepresentanteDocumento = BC000Z12_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = BC000Z12_n1004ParticipanteRepresentanteDocumento[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Z38( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound38 = 0;
         ScanKeyLoad0Z38( ) ;
      }

      protected void ScanKeyLoad0Z38( )
      {
         sMode38 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound38 = 1;
            A233ParticipanteId = BC000Z12_A233ParticipanteId[0];
            n233ParticipanteId = BC000Z12_n233ParticipanteId[0];
            A234ParticipanteDocumento = BC000Z12_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = BC000Z12_n234ParticipanteDocumento[0];
            A248ParticipanteNome = BC000Z12_A248ParticipanteNome[0];
            n248ParticipanteNome = BC000Z12_n248ParticipanteNome[0];
            A235ParticipanteEmail = BC000Z12_A235ParticipanteEmail[0];
            n235ParticipanteEmail = BC000Z12_n235ParticipanteEmail[0];
            A1001ParticipanteTipoPessoa = BC000Z12_A1001ParticipanteTipoPessoa[0];
            n1001ParticipanteTipoPessoa = BC000Z12_n1001ParticipanteTipoPessoa[0];
            A1002ParticipanteRepresentanteNome = BC000Z12_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = BC000Z12_n1002ParticipanteRepresentanteNome[0];
            A1003ParticipanteRepresentanteEmail = BC000Z12_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = BC000Z12_n1003ParticipanteRepresentanteEmail[0];
            A1004ParticipanteRepresentanteDocumento = BC000Z12_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = BC000Z12_n1004ParticipanteRepresentanteDocumento[0];
         }
         Gx_mode = sMode38;
      }

      protected void ScanKeyEnd0Z38( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0Z38( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z38( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z38( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z38( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z38( )
      {
         /* Before Complete Rules */
         new prvalidcpf(context ).execute(  "FISICA",  A234ParticipanteDocumento, out  AV11isOk, out  AV12ErroMsg) ;
         if ( ! AV11isOk )
         {
            GX_msglist.addItem(AV12ErroMsg, 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeValidate0Z38( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z38( )
      {
      }

      protected void send_integrity_lvl_hashes0Z38( )
      {
      }

      protected void AddRow0Z38( )
      {
         VarsToRow38( bcParticipante) ;
      }

      protected void ReadRow0Z38( )
      {
         RowToVars38( bcParticipante, 1) ;
      }

      protected void InitializeNonKey0Z38( )
      {
         AV11isOk = false;
         AV12ErroMsg = "";
         A1005ParticipanteEmail_F = "";
         A1006ParticipanteDocumento_F = "";
         A234ParticipanteDocumento = "";
         n234ParticipanteDocumento = false;
         A248ParticipanteNome = "";
         n248ParticipanteNome = false;
         A235ParticipanteEmail = "";
         n235ParticipanteEmail = false;
         A1001ParticipanteTipoPessoa = "";
         n1001ParticipanteTipoPessoa = false;
         A1002ParticipanteRepresentanteNome = "";
         n1002ParticipanteRepresentanteNome = false;
         A1003ParticipanteRepresentanteEmail = "";
         n1003ParticipanteRepresentanteEmail = false;
         A1004ParticipanteRepresentanteDocumento = "";
         n1004ParticipanteRepresentanteDocumento = false;
         Z234ParticipanteDocumento = "";
         Z248ParticipanteNome = "";
         Z235ParticipanteEmail = "";
         Z1001ParticipanteTipoPessoa = "";
         Z1002ParticipanteRepresentanteNome = "";
         Z1003ParticipanteRepresentanteEmail = "";
         Z1004ParticipanteRepresentanteDocumento = "";
      }

      protected void InitAll0Z38( )
      {
         A233ParticipanteId = 0;
         n233ParticipanteId = false;
         InitializeNonKey0Z38( ) ;
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

      public void VarsToRow38( SdtParticipante obj38 )
      {
         obj38.gxTpr_Mode = Gx_mode;
         obj38.gxTpr_Participanteemail_f = A1005ParticipanteEmail_F;
         obj38.gxTpr_Participantedocumento_f = A1006ParticipanteDocumento_F;
         obj38.gxTpr_Participantedocumento = A234ParticipanteDocumento;
         obj38.gxTpr_Participantenome = A248ParticipanteNome;
         obj38.gxTpr_Participanteemail = A235ParticipanteEmail;
         obj38.gxTpr_Participantetipopessoa = A1001ParticipanteTipoPessoa;
         obj38.gxTpr_Participanterepresentantenome = A1002ParticipanteRepresentanteNome;
         obj38.gxTpr_Participanterepresentanteemail = A1003ParticipanteRepresentanteEmail;
         obj38.gxTpr_Participanterepresentantedocumento = A1004ParticipanteRepresentanteDocumento;
         obj38.gxTpr_Participanteid = A233ParticipanteId;
         obj38.gxTpr_Participanteid_Z = Z233ParticipanteId;
         obj38.gxTpr_Participantedocumento_Z = Z234ParticipanteDocumento;
         obj38.gxTpr_Participantenome_Z = Z248ParticipanteNome;
         obj38.gxTpr_Participanteemail_Z = Z235ParticipanteEmail;
         obj38.gxTpr_Participantetipopessoa_Z = Z1001ParticipanteTipoPessoa;
         obj38.gxTpr_Participanterepresentantenome_Z = Z1002ParticipanteRepresentanteNome;
         obj38.gxTpr_Participanterepresentanteemail_Z = Z1003ParticipanteRepresentanteEmail;
         obj38.gxTpr_Participanterepresentantedocumento_Z = Z1004ParticipanteRepresentanteDocumento;
         obj38.gxTpr_Participanteemail_f_Z = Z1005ParticipanteEmail_F;
         obj38.gxTpr_Participantedocumento_f_Z = Z1006ParticipanteDocumento_F;
         obj38.gxTpr_Participanteid_N = (short)(Convert.ToInt16(n233ParticipanteId));
         obj38.gxTpr_Participantedocumento_N = (short)(Convert.ToInt16(n234ParticipanteDocumento));
         obj38.gxTpr_Participantenome_N = (short)(Convert.ToInt16(n248ParticipanteNome));
         obj38.gxTpr_Participanteemail_N = (short)(Convert.ToInt16(n235ParticipanteEmail));
         obj38.gxTpr_Participantetipopessoa_N = (short)(Convert.ToInt16(n1001ParticipanteTipoPessoa));
         obj38.gxTpr_Participanterepresentantenome_N = (short)(Convert.ToInt16(n1002ParticipanteRepresentanteNome));
         obj38.gxTpr_Participanterepresentanteemail_N = (short)(Convert.ToInt16(n1003ParticipanteRepresentanteEmail));
         obj38.gxTpr_Participanterepresentantedocumento_N = (short)(Convert.ToInt16(n1004ParticipanteRepresentanteDocumento));
         obj38.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow38( SdtParticipante obj38 )
      {
         obj38.gxTpr_Participanteid = A233ParticipanteId;
         return  ;
      }

      public void RowToVars38( SdtParticipante obj38 ,
                               int forceLoad )
      {
         Gx_mode = obj38.gxTpr_Mode;
         A1005ParticipanteEmail_F = obj38.gxTpr_Participanteemail_f;
         A1006ParticipanteDocumento_F = obj38.gxTpr_Participantedocumento_f;
         A234ParticipanteDocumento = obj38.gxTpr_Participantedocumento;
         n234ParticipanteDocumento = false;
         A248ParticipanteNome = obj38.gxTpr_Participantenome;
         n248ParticipanteNome = false;
         A235ParticipanteEmail = obj38.gxTpr_Participanteemail;
         n235ParticipanteEmail = false;
         A1001ParticipanteTipoPessoa = obj38.gxTpr_Participantetipopessoa;
         n1001ParticipanteTipoPessoa = false;
         A1002ParticipanteRepresentanteNome = obj38.gxTpr_Participanterepresentantenome;
         n1002ParticipanteRepresentanteNome = false;
         A1003ParticipanteRepresentanteEmail = obj38.gxTpr_Participanterepresentanteemail;
         n1003ParticipanteRepresentanteEmail = false;
         A1004ParticipanteRepresentanteDocumento = obj38.gxTpr_Participanterepresentantedocumento;
         n1004ParticipanteRepresentanteDocumento = false;
         A233ParticipanteId = obj38.gxTpr_Participanteid;
         n233ParticipanteId = false;
         Z233ParticipanteId = obj38.gxTpr_Participanteid_Z;
         Z234ParticipanteDocumento = obj38.gxTpr_Participantedocumento_Z;
         Z248ParticipanteNome = obj38.gxTpr_Participantenome_Z;
         Z235ParticipanteEmail = obj38.gxTpr_Participanteemail_Z;
         Z1001ParticipanteTipoPessoa = obj38.gxTpr_Participantetipopessoa_Z;
         Z1002ParticipanteRepresentanteNome = obj38.gxTpr_Participanterepresentantenome_Z;
         Z1003ParticipanteRepresentanteEmail = obj38.gxTpr_Participanterepresentanteemail_Z;
         Z1004ParticipanteRepresentanteDocumento = obj38.gxTpr_Participanterepresentantedocumento_Z;
         Z1005ParticipanteEmail_F = obj38.gxTpr_Participanteemail_f_Z;
         Z1006ParticipanteDocumento_F = obj38.gxTpr_Participantedocumento_f_Z;
         n233ParticipanteId = (bool)(Convert.ToBoolean(obj38.gxTpr_Participanteid_N));
         n234ParticipanteDocumento = (bool)(Convert.ToBoolean(obj38.gxTpr_Participantedocumento_N));
         n248ParticipanteNome = (bool)(Convert.ToBoolean(obj38.gxTpr_Participantenome_N));
         n235ParticipanteEmail = (bool)(Convert.ToBoolean(obj38.gxTpr_Participanteemail_N));
         n1001ParticipanteTipoPessoa = (bool)(Convert.ToBoolean(obj38.gxTpr_Participantetipopessoa_N));
         n1002ParticipanteRepresentanteNome = (bool)(Convert.ToBoolean(obj38.gxTpr_Participanterepresentantenome_N));
         n1003ParticipanteRepresentanteEmail = (bool)(Convert.ToBoolean(obj38.gxTpr_Participanterepresentanteemail_N));
         n1004ParticipanteRepresentanteDocumento = (bool)(Convert.ToBoolean(obj38.gxTpr_Participanterepresentantedocumento_N));
         Gx_mode = obj38.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A233ParticipanteId = (int)getParm(obj,0);
         n233ParticipanteId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0Z38( ) ;
         ScanKeyStart0Z38( ) ;
         if ( RcdFound38 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z233ParticipanteId = A233ParticipanteId;
         }
         ZM0Z38( -11) ;
         OnLoadActions0Z38( ) ;
         AddRow0Z38( ) ;
         ScanKeyEnd0Z38( ) ;
         if ( RcdFound38 == 0 )
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
         RowToVars38( bcParticipante, 0) ;
         ScanKeyStart0Z38( ) ;
         if ( RcdFound38 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z233ParticipanteId = A233ParticipanteId;
         }
         ZM0Z38( -11) ;
         OnLoadActions0Z38( ) ;
         AddRow0Z38( ) ;
         ScanKeyEnd0Z38( ) ;
         if ( RcdFound38 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey0Z38( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0Z38( ) ;
         }
         else
         {
            if ( RcdFound38 == 1 )
            {
               if ( A233ParticipanteId != Z233ParticipanteId )
               {
                  A233ParticipanteId = Z233ParticipanteId;
                  n233ParticipanteId = false;
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
                  Update0Z38( ) ;
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
                  if ( A233ParticipanteId != Z233ParticipanteId )
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
                        Insert0Z38( ) ;
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
                        Insert0Z38( ) ;
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
         RowToVars38( bcParticipante, 1) ;
         SaveImpl( ) ;
         VarsToRow38( bcParticipante) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars38( bcParticipante, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Z38( ) ;
         AfterTrn( ) ;
         VarsToRow38( bcParticipante) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow38( bcParticipante) ;
         }
         else
         {
            SdtParticipante auxBC = new SdtParticipante(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A233ParticipanteId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcParticipante);
               auxBC.Save();
               bcParticipante.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars38( bcParticipante, 1) ;
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
         RowToVars38( bcParticipante, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Z38( ) ;
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
               VarsToRow38( bcParticipante) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow38( bcParticipante) ;
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
         RowToVars38( bcParticipante, 0) ;
         GetKey0Z38( ) ;
         if ( RcdFound38 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A233ParticipanteId != Z233ParticipanteId )
            {
               A233ParticipanteId = Z233ParticipanteId;
               n233ParticipanteId = false;
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
            if ( A233ParticipanteId != Z233ParticipanteId )
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
         context.RollbackDataStores("participante_bc",pr_default);
         VarsToRow38( bcParticipante) ;
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
         Gx_mode = bcParticipante.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcParticipante.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcParticipante )
         {
            bcParticipante = (SdtParticipante)(sdt);
            if ( StringUtil.StrCmp(bcParticipante.gxTpr_Mode, "") == 0 )
            {
               bcParticipante.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow38( bcParticipante) ;
            }
            else
            {
               RowToVars38( bcParticipante, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcParticipante.gxTpr_Mode, "") == 0 )
            {
               bcParticipante.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars38( bcParticipante, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtParticipante Participante_BC
      {
         get {
            return bcParticipante ;
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
         Z234ParticipanteDocumento = "";
         A234ParticipanteDocumento = "";
         Z248ParticipanteNome = "";
         A248ParticipanteNome = "";
         Z235ParticipanteEmail = "";
         A235ParticipanteEmail = "";
         Z1001ParticipanteTipoPessoa = "";
         A1001ParticipanteTipoPessoa = "";
         Z1002ParticipanteRepresentanteNome = "";
         A1002ParticipanteRepresentanteNome = "";
         Z1003ParticipanteRepresentanteEmail = "";
         A1003ParticipanteRepresentanteEmail = "";
         Z1004ParticipanteRepresentanteDocumento = "";
         A1004ParticipanteRepresentanteDocumento = "";
         Z1005ParticipanteEmail_F = "";
         A1005ParticipanteEmail_F = "";
         Z1006ParticipanteDocumento_F = "";
         A1006ParticipanteDocumento_F = "";
         BC000Z4_A233ParticipanteId = new int[1] ;
         BC000Z4_n233ParticipanteId = new bool[] {false} ;
         BC000Z4_A234ParticipanteDocumento = new string[] {""} ;
         BC000Z4_n234ParticipanteDocumento = new bool[] {false} ;
         BC000Z4_A248ParticipanteNome = new string[] {""} ;
         BC000Z4_n248ParticipanteNome = new bool[] {false} ;
         BC000Z4_A235ParticipanteEmail = new string[] {""} ;
         BC000Z4_n235ParticipanteEmail = new bool[] {false} ;
         BC000Z4_A1001ParticipanteTipoPessoa = new string[] {""} ;
         BC000Z4_n1001ParticipanteTipoPessoa = new bool[] {false} ;
         BC000Z4_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         BC000Z4_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         BC000Z4_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         BC000Z4_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         BC000Z4_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         BC000Z4_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         BC000Z5_A233ParticipanteId = new int[1] ;
         BC000Z5_n233ParticipanteId = new bool[] {false} ;
         BC000Z3_A233ParticipanteId = new int[1] ;
         BC000Z3_n233ParticipanteId = new bool[] {false} ;
         BC000Z3_A234ParticipanteDocumento = new string[] {""} ;
         BC000Z3_n234ParticipanteDocumento = new bool[] {false} ;
         BC000Z3_A248ParticipanteNome = new string[] {""} ;
         BC000Z3_n248ParticipanteNome = new bool[] {false} ;
         BC000Z3_A235ParticipanteEmail = new string[] {""} ;
         BC000Z3_n235ParticipanteEmail = new bool[] {false} ;
         BC000Z3_A1001ParticipanteTipoPessoa = new string[] {""} ;
         BC000Z3_n1001ParticipanteTipoPessoa = new bool[] {false} ;
         BC000Z3_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         BC000Z3_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         BC000Z3_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         BC000Z3_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         BC000Z3_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         BC000Z3_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         sMode38 = "";
         BC000Z2_A233ParticipanteId = new int[1] ;
         BC000Z2_n233ParticipanteId = new bool[] {false} ;
         BC000Z2_A234ParticipanteDocumento = new string[] {""} ;
         BC000Z2_n234ParticipanteDocumento = new bool[] {false} ;
         BC000Z2_A248ParticipanteNome = new string[] {""} ;
         BC000Z2_n248ParticipanteNome = new bool[] {false} ;
         BC000Z2_A235ParticipanteEmail = new string[] {""} ;
         BC000Z2_n235ParticipanteEmail = new bool[] {false} ;
         BC000Z2_A1001ParticipanteTipoPessoa = new string[] {""} ;
         BC000Z2_n1001ParticipanteTipoPessoa = new bool[] {false} ;
         BC000Z2_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         BC000Z2_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         BC000Z2_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         BC000Z2_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         BC000Z2_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         BC000Z2_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         BC000Z7_A233ParticipanteId = new int[1] ;
         BC000Z7_n233ParticipanteId = new bool[] {false} ;
         BC000Z10_A242AssinaturaParticipanteId = new int[1] ;
         BC000Z11_A237ContratoParticipanteId = new int[1] ;
         BC000Z12_A233ParticipanteId = new int[1] ;
         BC000Z12_n233ParticipanteId = new bool[] {false} ;
         BC000Z12_A234ParticipanteDocumento = new string[] {""} ;
         BC000Z12_n234ParticipanteDocumento = new bool[] {false} ;
         BC000Z12_A248ParticipanteNome = new string[] {""} ;
         BC000Z12_n248ParticipanteNome = new bool[] {false} ;
         BC000Z12_A235ParticipanteEmail = new string[] {""} ;
         BC000Z12_n235ParticipanteEmail = new bool[] {false} ;
         BC000Z12_A1001ParticipanteTipoPessoa = new string[] {""} ;
         BC000Z12_n1001ParticipanteTipoPessoa = new bool[] {false} ;
         BC000Z12_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         BC000Z12_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         BC000Z12_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         BC000Z12_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         BC000Z12_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         BC000Z12_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         AV12ErroMsg = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.participante_bc__default(),
            new Object[][] {
                new Object[] {
               BC000Z2_A233ParticipanteId, BC000Z2_A234ParticipanteDocumento, BC000Z2_n234ParticipanteDocumento, BC000Z2_A248ParticipanteNome, BC000Z2_n248ParticipanteNome, BC000Z2_A235ParticipanteEmail, BC000Z2_n235ParticipanteEmail, BC000Z2_A1001ParticipanteTipoPessoa, BC000Z2_n1001ParticipanteTipoPessoa, BC000Z2_A1002ParticipanteRepresentanteNome,
               BC000Z2_n1002ParticipanteRepresentanteNome, BC000Z2_A1003ParticipanteRepresentanteEmail, BC000Z2_n1003ParticipanteRepresentanteEmail, BC000Z2_A1004ParticipanteRepresentanteDocumento, BC000Z2_n1004ParticipanteRepresentanteDocumento
               }
               , new Object[] {
               BC000Z3_A233ParticipanteId, BC000Z3_A234ParticipanteDocumento, BC000Z3_n234ParticipanteDocumento, BC000Z3_A248ParticipanteNome, BC000Z3_n248ParticipanteNome, BC000Z3_A235ParticipanteEmail, BC000Z3_n235ParticipanteEmail, BC000Z3_A1001ParticipanteTipoPessoa, BC000Z3_n1001ParticipanteTipoPessoa, BC000Z3_A1002ParticipanteRepresentanteNome,
               BC000Z3_n1002ParticipanteRepresentanteNome, BC000Z3_A1003ParticipanteRepresentanteEmail, BC000Z3_n1003ParticipanteRepresentanteEmail, BC000Z3_A1004ParticipanteRepresentanteDocumento, BC000Z3_n1004ParticipanteRepresentanteDocumento
               }
               , new Object[] {
               BC000Z4_A233ParticipanteId, BC000Z4_A234ParticipanteDocumento, BC000Z4_n234ParticipanteDocumento, BC000Z4_A248ParticipanteNome, BC000Z4_n248ParticipanteNome, BC000Z4_A235ParticipanteEmail, BC000Z4_n235ParticipanteEmail, BC000Z4_A1001ParticipanteTipoPessoa, BC000Z4_n1001ParticipanteTipoPessoa, BC000Z4_A1002ParticipanteRepresentanteNome,
               BC000Z4_n1002ParticipanteRepresentanteNome, BC000Z4_A1003ParticipanteRepresentanteEmail, BC000Z4_n1003ParticipanteRepresentanteEmail, BC000Z4_A1004ParticipanteRepresentanteDocumento, BC000Z4_n1004ParticipanteRepresentanteDocumento
               }
               , new Object[] {
               BC000Z5_A233ParticipanteId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Z7_A233ParticipanteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Z10_A242AssinaturaParticipanteId
               }
               , new Object[] {
               BC000Z11_A237ContratoParticipanteId
               }
               , new Object[] {
               BC000Z12_A233ParticipanteId, BC000Z12_A234ParticipanteDocumento, BC000Z12_n234ParticipanteDocumento, BC000Z12_A248ParticipanteNome, BC000Z12_n248ParticipanteNome, BC000Z12_A235ParticipanteEmail, BC000Z12_n235ParticipanteEmail, BC000Z12_A1001ParticipanteTipoPessoa, BC000Z12_n1001ParticipanteTipoPessoa, BC000Z12_A1002ParticipanteRepresentanteNome,
               BC000Z12_n1002ParticipanteRepresentanteNome, BC000Z12_A1003ParticipanteRepresentanteEmail, BC000Z12_n1003ParticipanteRepresentanteEmail, BC000Z12_A1004ParticipanteRepresentanteDocumento, BC000Z12_n1004ParticipanteRepresentanteDocumento
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120Z2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound38 ;
      private int trnEnded ;
      private int Z233ParticipanteId ;
      private int A233ParticipanteId ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode38 ;
      private bool returnInSub ;
      private bool n233ParticipanteId ;
      private bool n234ParticipanteDocumento ;
      private bool n248ParticipanteNome ;
      private bool n235ParticipanteEmail ;
      private bool n1001ParticipanteTipoPessoa ;
      private bool n1002ParticipanteRepresentanteNome ;
      private bool n1003ParticipanteRepresentanteEmail ;
      private bool n1004ParticipanteRepresentanteDocumento ;
      private bool Gx_longc ;
      private bool AV11isOk ;
      private string Z234ParticipanteDocumento ;
      private string A234ParticipanteDocumento ;
      private string Z248ParticipanteNome ;
      private string A248ParticipanteNome ;
      private string Z235ParticipanteEmail ;
      private string A235ParticipanteEmail ;
      private string Z1001ParticipanteTipoPessoa ;
      private string A1001ParticipanteTipoPessoa ;
      private string Z1002ParticipanteRepresentanteNome ;
      private string A1002ParticipanteRepresentanteNome ;
      private string Z1003ParticipanteRepresentanteEmail ;
      private string A1003ParticipanteRepresentanteEmail ;
      private string Z1004ParticipanteRepresentanteDocumento ;
      private string A1004ParticipanteRepresentanteDocumento ;
      private string Z1005ParticipanteEmail_F ;
      private string A1005ParticipanteEmail_F ;
      private string Z1006ParticipanteDocumento_F ;
      private string A1006ParticipanteDocumento_F ;
      private string AV12ErroMsg ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private IDataStoreProvider pr_default ;
      private int[] BC000Z4_A233ParticipanteId ;
      private bool[] BC000Z4_n233ParticipanteId ;
      private string[] BC000Z4_A234ParticipanteDocumento ;
      private bool[] BC000Z4_n234ParticipanteDocumento ;
      private string[] BC000Z4_A248ParticipanteNome ;
      private bool[] BC000Z4_n248ParticipanteNome ;
      private string[] BC000Z4_A235ParticipanteEmail ;
      private bool[] BC000Z4_n235ParticipanteEmail ;
      private string[] BC000Z4_A1001ParticipanteTipoPessoa ;
      private bool[] BC000Z4_n1001ParticipanteTipoPessoa ;
      private string[] BC000Z4_A1002ParticipanteRepresentanteNome ;
      private bool[] BC000Z4_n1002ParticipanteRepresentanteNome ;
      private string[] BC000Z4_A1003ParticipanteRepresentanteEmail ;
      private bool[] BC000Z4_n1003ParticipanteRepresentanteEmail ;
      private string[] BC000Z4_A1004ParticipanteRepresentanteDocumento ;
      private bool[] BC000Z4_n1004ParticipanteRepresentanteDocumento ;
      private int[] BC000Z5_A233ParticipanteId ;
      private bool[] BC000Z5_n233ParticipanteId ;
      private int[] BC000Z3_A233ParticipanteId ;
      private bool[] BC000Z3_n233ParticipanteId ;
      private string[] BC000Z3_A234ParticipanteDocumento ;
      private bool[] BC000Z3_n234ParticipanteDocumento ;
      private string[] BC000Z3_A248ParticipanteNome ;
      private bool[] BC000Z3_n248ParticipanteNome ;
      private string[] BC000Z3_A235ParticipanteEmail ;
      private bool[] BC000Z3_n235ParticipanteEmail ;
      private string[] BC000Z3_A1001ParticipanteTipoPessoa ;
      private bool[] BC000Z3_n1001ParticipanteTipoPessoa ;
      private string[] BC000Z3_A1002ParticipanteRepresentanteNome ;
      private bool[] BC000Z3_n1002ParticipanteRepresentanteNome ;
      private string[] BC000Z3_A1003ParticipanteRepresentanteEmail ;
      private bool[] BC000Z3_n1003ParticipanteRepresentanteEmail ;
      private string[] BC000Z3_A1004ParticipanteRepresentanteDocumento ;
      private bool[] BC000Z3_n1004ParticipanteRepresentanteDocumento ;
      private int[] BC000Z2_A233ParticipanteId ;
      private bool[] BC000Z2_n233ParticipanteId ;
      private string[] BC000Z2_A234ParticipanteDocumento ;
      private bool[] BC000Z2_n234ParticipanteDocumento ;
      private string[] BC000Z2_A248ParticipanteNome ;
      private bool[] BC000Z2_n248ParticipanteNome ;
      private string[] BC000Z2_A235ParticipanteEmail ;
      private bool[] BC000Z2_n235ParticipanteEmail ;
      private string[] BC000Z2_A1001ParticipanteTipoPessoa ;
      private bool[] BC000Z2_n1001ParticipanteTipoPessoa ;
      private string[] BC000Z2_A1002ParticipanteRepresentanteNome ;
      private bool[] BC000Z2_n1002ParticipanteRepresentanteNome ;
      private string[] BC000Z2_A1003ParticipanteRepresentanteEmail ;
      private bool[] BC000Z2_n1003ParticipanteRepresentanteEmail ;
      private string[] BC000Z2_A1004ParticipanteRepresentanteDocumento ;
      private bool[] BC000Z2_n1004ParticipanteRepresentanteDocumento ;
      private int[] BC000Z7_A233ParticipanteId ;
      private bool[] BC000Z7_n233ParticipanteId ;
      private int[] BC000Z10_A242AssinaturaParticipanteId ;
      private int[] BC000Z11_A237ContratoParticipanteId ;
      private int[] BC000Z12_A233ParticipanteId ;
      private bool[] BC000Z12_n233ParticipanteId ;
      private string[] BC000Z12_A234ParticipanteDocumento ;
      private bool[] BC000Z12_n234ParticipanteDocumento ;
      private string[] BC000Z12_A248ParticipanteNome ;
      private bool[] BC000Z12_n248ParticipanteNome ;
      private string[] BC000Z12_A235ParticipanteEmail ;
      private bool[] BC000Z12_n235ParticipanteEmail ;
      private string[] BC000Z12_A1001ParticipanteTipoPessoa ;
      private bool[] BC000Z12_n1001ParticipanteTipoPessoa ;
      private string[] BC000Z12_A1002ParticipanteRepresentanteNome ;
      private bool[] BC000Z12_n1002ParticipanteRepresentanteNome ;
      private string[] BC000Z12_A1003ParticipanteRepresentanteEmail ;
      private bool[] BC000Z12_n1003ParticipanteRepresentanteEmail ;
      private string[] BC000Z12_A1004ParticipanteRepresentanteDocumento ;
      private bool[] BC000Z12_n1004ParticipanteRepresentanteDocumento ;
      private SdtParticipante bcParticipante ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class participante_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000Z2;
          prmBC000Z2 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Z3;
          prmBC000Z3 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Z4;
          prmBC000Z4 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Z5;
          prmBC000Z5 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Z6;
          prmBC000Z6 = new Object[] {
          new ParDef("ParticipanteDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("ParticipanteNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ParticipanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ParticipanteTipoPessoa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ParticipanteRepresentanteNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ParticipanteRepresentanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ParticipanteRepresentanteDocumento",GXType.VarChar,14,0){Nullable=true}
          };
          Object[] prmBC000Z7;
          prmBC000Z7 = new Object[] {
          };
          Object[] prmBC000Z8;
          prmBC000Z8 = new Object[] {
          new ParDef("ParticipanteDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("ParticipanteNome",GXType.VarChar,150,0){Nullable=true} ,
          new ParDef("ParticipanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ParticipanteTipoPessoa",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ParticipanteRepresentanteNome",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ParticipanteRepresentanteEmail",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ParticipanteRepresentanteDocumento",GXType.VarChar,14,0){Nullable=true} ,
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Z9;
          prmBC000Z9 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Z10;
          prmBC000Z10 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Z11;
          prmBC000Z11 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          Object[] prmBC000Z12;
          prmBC000Z12 = new Object[] {
          new ParDef("ParticipanteId",GXType.Int32,8,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC000Z2", "SELECT ParticipanteId, ParticipanteDocumento, ParticipanteNome, ParticipanteEmail, ParticipanteTipoPessoa, ParticipanteRepresentanteNome, ParticipanteRepresentanteEmail, ParticipanteRepresentanteDocumento FROM Participante WHERE ParticipanteId = :ParticipanteId  FOR UPDATE OF Participante",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000Z3", "SELECT ParticipanteId, ParticipanteDocumento, ParticipanteNome, ParticipanteEmail, ParticipanteTipoPessoa, ParticipanteRepresentanteNome, ParticipanteRepresentanteEmail, ParticipanteRepresentanteDocumento FROM Participante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000Z4", "SELECT TM1.ParticipanteId, TM1.ParticipanteDocumento, TM1.ParticipanteNome, TM1.ParticipanteEmail, TM1.ParticipanteTipoPessoa, TM1.ParticipanteRepresentanteNome, TM1.ParticipanteRepresentanteEmail, TM1.ParticipanteRepresentanteDocumento FROM Participante TM1 WHERE TM1.ParticipanteId = :ParticipanteId ORDER BY TM1.ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000Z5", "SELECT ParticipanteId FROM Participante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000Z6", "SAVEPOINT gxupdate;INSERT INTO Participante(ParticipanteDocumento, ParticipanteNome, ParticipanteEmail, ParticipanteTipoPessoa, ParticipanteRepresentanteNome, ParticipanteRepresentanteEmail, ParticipanteRepresentanteDocumento) VALUES(:ParticipanteDocumento, :ParticipanteNome, :ParticipanteEmail, :ParticipanteTipoPessoa, :ParticipanteRepresentanteNome, :ParticipanteRepresentanteEmail, :ParticipanteRepresentanteDocumento);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Z6)
             ,new CursorDef("BC000Z7", "SELECT currval('ParticipanteId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000Z8", "SAVEPOINT gxupdate;UPDATE Participante SET ParticipanteDocumento=:ParticipanteDocumento, ParticipanteNome=:ParticipanteNome, ParticipanteEmail=:ParticipanteEmail, ParticipanteTipoPessoa=:ParticipanteTipoPessoa, ParticipanteRepresentanteNome=:ParticipanteRepresentanteNome, ParticipanteRepresentanteEmail=:ParticipanteRepresentanteEmail, ParticipanteRepresentanteDocumento=:ParticipanteRepresentanteDocumento  WHERE ParticipanteId = :ParticipanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z8)
             ,new CursorDef("BC000Z9", "SAVEPOINT gxupdate;DELETE FROM Participante  WHERE ParticipanteId = :ParticipanteId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Z9)
             ,new CursorDef("BC000Z10", "SELECT AssinaturaParticipanteId FROM AssinaturaParticipante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z10,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000Z11", "SELECT ContratoParticipanteId FROM ContratoParticipante WHERE ParticipanteId = :ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z11,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000Z12", "SELECT TM1.ParticipanteId, TM1.ParticipanteDocumento, TM1.ParticipanteNome, TM1.ParticipanteEmail, TM1.ParticipanteTipoPessoa, TM1.ParticipanteRepresentanteNome, TM1.ParticipanteRepresentanteEmail, TM1.ParticipanteRepresentanteDocumento FROM Participante TM1 WHERE TM1.ParticipanteId = :ParticipanteId ORDER BY TM1.ParticipanteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Z12,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
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
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
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
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}
