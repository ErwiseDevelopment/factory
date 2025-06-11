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
   public class chavepix_bc : GxSilentTrn, IGxSilentTrn
   {
      public chavepix_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public chavepix_bc( IGxContext context )
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
         ReadRow2Z103( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2Z103( ) ;
         standaloneModal( ) ;
         AddRow2Z103( ) ;
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
            E112Z2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z961ChavePIXId = A961ChavePIXId;
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

      protected void CONFIRM_2Z0( )
      {
         BeforeValidate2Z103( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2Z103( ) ;
            }
            else
            {
               CheckExtendedTable2Z103( ) ;
               if ( AnyError == 0 )
               {
                  ZM2Z103( 9) ;
                  ZM2Z103( 10) ;
                  ZM2Z103( 11) ;
                  ZM2Z103( 12) ;
                  ZM2Z103( 13) ;
                  ZM2Z103( 14) ;
               }
               CloseExtendedTableCursors2Z103( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV17Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV18GXV1 = 1;
            while ( AV18GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV18GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ContaBancariaId") == 0 )
               {
                  AV11Insert_ContaBancariaId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ChavePIXCreatedBy") == 0 )
               {
                  AV12Insert_ChavePIXCreatedBy = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ChavePIXUpdatedBy") == 0 )
               {
                  AV13Insert_ChavePIXUpdatedBy = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV18GXV1 = (int)(AV18GXV1+1);
            }
         }
      }

      protected void E112Z2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2Z103( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z966ChavePIXCreatedAt = A966ChavePIXCreatedAt;
            Z967ChavePIXUpdatedAt = A967ChavePIXUpdatedAt;
            Z962ChavePIXTipo = A962ChavePIXTipo;
            Z963ChavePIXConteudo = A963ChavePIXConteudo;
            Z964ChavePIXStatus = A964ChavePIXStatus;
            Z965ChavePIXPrincipal = A965ChavePIXPrincipal;
            Z951ContaBancariaId = A951ContaBancariaId;
            Z957ChavePIXCreatedBy = A957ChavePIXCreatedBy;
            Z959ChavePIXUpdatedBy = A959ChavePIXUpdatedBy;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z938AgenciaId = A938AgenciaId;
            Z952ContaBancariaNumero = A952ContaBancariaNumero;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z958ChavePIXCreatedByName = A958ChavePIXCreatedByName;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z960ChavePIXUpdatedByName = A960ChavePIXUpdatedByName;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z968AgenciaBancoId = A968AgenciaBancoId;
            Z939AgenciaNumero = A939AgenciaNumero;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z969AgenciaBancoNome = A969AgenciaBancoNome;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
         }
         if ( GX_JID == -8 )
         {
            Z961ChavePIXId = A961ChavePIXId;
            Z966ChavePIXCreatedAt = A966ChavePIXCreatedAt;
            Z967ChavePIXUpdatedAt = A967ChavePIXUpdatedAt;
            Z962ChavePIXTipo = A962ChavePIXTipo;
            Z963ChavePIXConteudo = A963ChavePIXConteudo;
            Z964ChavePIXStatus = A964ChavePIXStatus;
            Z965ChavePIXPrincipal = A965ChavePIXPrincipal;
            Z951ContaBancariaId = A951ContaBancariaId;
            Z957ChavePIXCreatedBy = A957ChavePIXCreatedBy;
            Z959ChavePIXUpdatedBy = A959ChavePIXUpdatedBy;
            Z938AgenciaId = A938AgenciaId;
            Z952ContaBancariaNumero = A952ContaBancariaNumero;
            Z968AgenciaBancoId = A968AgenciaBancoId;
            Z939AgenciaNumero = A939AgenciaNumero;
            Z969AgenciaBancoNome = A969AgenciaBancoNome;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
            Z958ChavePIXCreatedByName = A958ChavePIXCreatedByName;
            Z960ChavePIXUpdatedByName = A960ChavePIXUpdatedByName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV17Pgmname = "ChavePIX_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A966ChavePIXCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n966ChavePIXCreatedAt = false;
         }
         if ( IsUpd( )  )
         {
            A967ChavePIXUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n967ChavePIXUpdatedAt = false;
         }
         if ( IsIns( )  && (false==A964ChavePIXStatus) && ( Gx_BScreen == 0 ) )
         {
            A964ChavePIXStatus = true;
            n964ChavePIXStatus = false;
         }
      }

      protected void Load2Z103( )
      {
         /* Using cursor BC002Z12 */
         pr_default.execute(8, new Object[] {A961ChavePIXId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound103 = 1;
            A938AgenciaId = BC002Z12_A938AgenciaId[0];
            n938AgenciaId = BC002Z12_n938AgenciaId[0];
            A968AgenciaBancoId = BC002Z12_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC002Z12_n968AgenciaBancoId[0];
            A966ChavePIXCreatedAt = BC002Z12_A966ChavePIXCreatedAt[0];
            n966ChavePIXCreatedAt = BC002Z12_n966ChavePIXCreatedAt[0];
            A967ChavePIXUpdatedAt = BC002Z12_A967ChavePIXUpdatedAt[0];
            n967ChavePIXUpdatedAt = BC002Z12_n967ChavePIXUpdatedAt[0];
            A962ChavePIXTipo = BC002Z12_A962ChavePIXTipo[0];
            n962ChavePIXTipo = BC002Z12_n962ChavePIXTipo[0];
            A963ChavePIXConteudo = BC002Z12_A963ChavePIXConteudo[0];
            n963ChavePIXConteudo = BC002Z12_n963ChavePIXConteudo[0];
            A964ChavePIXStatus = BC002Z12_A964ChavePIXStatus[0];
            n964ChavePIXStatus = BC002Z12_n964ChavePIXStatus[0];
            A965ChavePIXPrincipal = BC002Z12_A965ChavePIXPrincipal[0];
            n965ChavePIXPrincipal = BC002Z12_n965ChavePIXPrincipal[0];
            A952ContaBancariaNumero = BC002Z12_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = BC002Z12_n952ContaBancariaNumero[0];
            A939AgenciaNumero = BC002Z12_A939AgenciaNumero[0];
            n939AgenciaNumero = BC002Z12_n939AgenciaNumero[0];
            A969AgenciaBancoNome = BC002Z12_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC002Z12_n969AgenciaBancoNome[0];
            A958ChavePIXCreatedByName = BC002Z12_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = BC002Z12_n958ChavePIXCreatedByName[0];
            A960ChavePIXUpdatedByName = BC002Z12_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = BC002Z12_n960ChavePIXUpdatedByName[0];
            A951ContaBancariaId = BC002Z12_A951ContaBancariaId[0];
            n951ContaBancariaId = BC002Z12_n951ContaBancariaId[0];
            A957ChavePIXCreatedBy = BC002Z12_A957ChavePIXCreatedBy[0];
            n957ChavePIXCreatedBy = BC002Z12_n957ChavePIXCreatedBy[0];
            A959ChavePIXUpdatedBy = BC002Z12_A959ChavePIXUpdatedBy[0];
            n959ChavePIXUpdatedBy = BC002Z12_n959ChavePIXUpdatedBy[0];
            A970ContaBancariaCountChavePIX_F = BC002Z12_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = BC002Z12_n970ContaBancariaCountChavePIX_F[0];
            ZM2Z103( -8) ;
         }
         pr_default.close(8);
         OnLoadActions2Z103( ) ;
      }

      protected void OnLoadActions2Z103( )
      {
      }

      protected void CheckExtendedTable2Z103( )
      {
         standaloneModal( ) ;
         if ( ! ( ( StringUtil.StrCmp(A962ChavePIXTipo, "CPF") == 0 ) || ( StringUtil.StrCmp(A962ChavePIXTipo, "CNPJ") == 0 ) || ( StringUtil.StrCmp(A962ChavePIXTipo, "Telefone") == 0 ) || ( StringUtil.StrCmp(A962ChavePIXTipo, "Email") == 0 ) || ( StringUtil.StrCmp(A962ChavePIXTipo, "ChaveAleatoria") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A962ChavePIXTipo)) ) )
         {
            GX_msglist.addItem("Campo Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC002Z4 */
         pr_default.execute(2, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A951ContaBancariaId) ) )
            {
               GX_msglist.addItem("Não existe 'Conta Bancaria'.", "ForeignKeyNotFound", 1, "CONTABANCARIAID");
               AnyError = 1;
            }
         }
         A938AgenciaId = BC002Z4_A938AgenciaId[0];
         n938AgenciaId = BC002Z4_n938AgenciaId[0];
         A952ContaBancariaNumero = BC002Z4_A952ContaBancariaNumero[0];
         n952ContaBancariaNumero = BC002Z4_n952ContaBancariaNumero[0];
         pr_default.close(2);
         /* Using cursor BC002Z7 */
         pr_default.execute(5, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A938AgenciaId) ) )
            {
               GX_msglist.addItem("Não existe 'Agencia'.", "ForeignKeyNotFound", 1, "AGENCIAID");
               AnyError = 1;
            }
         }
         A968AgenciaBancoId = BC002Z7_A968AgenciaBancoId[0];
         n968AgenciaBancoId = BC002Z7_n968AgenciaBancoId[0];
         A939AgenciaNumero = BC002Z7_A939AgenciaNumero[0];
         n939AgenciaNumero = BC002Z7_n939AgenciaNumero[0];
         pr_default.close(5);
         /* Using cursor BC002Z8 */
         pr_default.execute(6, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = BC002Z8_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = BC002Z8_n969AgenciaBancoNome[0];
         pr_default.close(6);
         /* Using cursor BC002Z10 */
         pr_default.execute(7, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A970ContaBancariaCountChavePIX_F = BC002Z10_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = BC002Z10_n970ContaBancariaCountChavePIX_F[0];
         }
         else
         {
            A970ContaBancariaCountChavePIX_F = 0;
            n970ContaBancariaCountChavePIX_F = false;
         }
         pr_default.close(7);
         /* Using cursor BC002Z5 */
         pr_default.execute(3, new Object[] {n957ChavePIXCreatedBy, A957ChavePIXCreatedBy});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A957ChavePIXCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Chave PIXCreated By'.", "ForeignKeyNotFound", 1, "CHAVEPIXCREATEDBY");
               AnyError = 1;
            }
         }
         A958ChavePIXCreatedByName = BC002Z5_A958ChavePIXCreatedByName[0];
         n958ChavePIXCreatedByName = BC002Z5_n958ChavePIXCreatedByName[0];
         pr_default.close(3);
         /* Using cursor BC002Z6 */
         pr_default.execute(4, new Object[] {n959ChavePIXUpdatedBy, A959ChavePIXUpdatedBy});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A959ChavePIXUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Chave PIXUpdated By'.", "ForeignKeyNotFound", 1, "CHAVEPIXUPDATEDBY");
               AnyError = 1;
            }
         }
         A960ChavePIXUpdatedByName = BC002Z6_A960ChavePIXUpdatedByName[0];
         n960ChavePIXUpdatedByName = BC002Z6_n960ChavePIXUpdatedByName[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2Z103( )
      {
         pr_default.close(2);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2Z103( )
      {
         /* Using cursor BC002Z13 */
         pr_default.execute(9, new Object[] {A961ChavePIXId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound103 = 1;
         }
         else
         {
            RcdFound103 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002Z3 */
         pr_default.execute(1, new Object[] {A961ChavePIXId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2Z103( 8) ;
            RcdFound103 = 1;
            A961ChavePIXId = BC002Z3_A961ChavePIXId[0];
            A966ChavePIXCreatedAt = BC002Z3_A966ChavePIXCreatedAt[0];
            n966ChavePIXCreatedAt = BC002Z3_n966ChavePIXCreatedAt[0];
            A967ChavePIXUpdatedAt = BC002Z3_A967ChavePIXUpdatedAt[0];
            n967ChavePIXUpdatedAt = BC002Z3_n967ChavePIXUpdatedAt[0];
            A962ChavePIXTipo = BC002Z3_A962ChavePIXTipo[0];
            n962ChavePIXTipo = BC002Z3_n962ChavePIXTipo[0];
            A963ChavePIXConteudo = BC002Z3_A963ChavePIXConteudo[0];
            n963ChavePIXConteudo = BC002Z3_n963ChavePIXConteudo[0];
            A964ChavePIXStatus = BC002Z3_A964ChavePIXStatus[0];
            n964ChavePIXStatus = BC002Z3_n964ChavePIXStatus[0];
            A965ChavePIXPrincipal = BC002Z3_A965ChavePIXPrincipal[0];
            n965ChavePIXPrincipal = BC002Z3_n965ChavePIXPrincipal[0];
            A951ContaBancariaId = BC002Z3_A951ContaBancariaId[0];
            n951ContaBancariaId = BC002Z3_n951ContaBancariaId[0];
            A957ChavePIXCreatedBy = BC002Z3_A957ChavePIXCreatedBy[0];
            n957ChavePIXCreatedBy = BC002Z3_n957ChavePIXCreatedBy[0];
            A959ChavePIXUpdatedBy = BC002Z3_A959ChavePIXUpdatedBy[0];
            n959ChavePIXUpdatedBy = BC002Z3_n959ChavePIXUpdatedBy[0];
            Z961ChavePIXId = A961ChavePIXId;
            sMode103 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2Z103( ) ;
            if ( AnyError == 1 )
            {
               RcdFound103 = 0;
               InitializeNonKey2Z103( ) ;
            }
            Gx_mode = sMode103;
         }
         else
         {
            RcdFound103 = 0;
            InitializeNonKey2Z103( ) ;
            sMode103 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode103;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2Z103( ) ;
         if ( RcdFound103 == 0 )
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
         CONFIRM_2Z0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2Z103( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002Z2 */
            pr_default.execute(0, new Object[] {A961ChavePIXId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ChavePIX"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z966ChavePIXCreatedAt != BC002Z2_A966ChavePIXCreatedAt[0] ) || ( Z967ChavePIXUpdatedAt != BC002Z2_A967ChavePIXUpdatedAt[0] ) || ( StringUtil.StrCmp(Z962ChavePIXTipo, BC002Z2_A962ChavePIXTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z963ChavePIXConteudo, BC002Z2_A963ChavePIXConteudo[0]) != 0 ) || ( Z964ChavePIXStatus != BC002Z2_A964ChavePIXStatus[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z965ChavePIXPrincipal != BC002Z2_A965ChavePIXPrincipal[0] ) || ( Z951ContaBancariaId != BC002Z2_A951ContaBancariaId[0] ) || ( Z957ChavePIXCreatedBy != BC002Z2_A957ChavePIXCreatedBy[0] ) || ( Z959ChavePIXUpdatedBy != BC002Z2_A959ChavePIXUpdatedBy[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ChavePIX"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2Z103( )
      {
         BeforeValidate2Z103( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Z103( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2Z103( 0) ;
            CheckOptimisticConcurrency2Z103( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Z103( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2Z103( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002Z14 */
                     pr_default.execute(10, new Object[] {n966ChavePIXCreatedAt, A966ChavePIXCreatedAt, n967ChavePIXUpdatedAt, A967ChavePIXUpdatedAt, n962ChavePIXTipo, A962ChavePIXTipo, n963ChavePIXConteudo, A963ChavePIXConteudo, n964ChavePIXStatus, A964ChavePIXStatus, n965ChavePIXPrincipal, A965ChavePIXPrincipal, n951ContaBancariaId, A951ContaBancariaId, n957ChavePIXCreatedBy, A957ChavePIXCreatedBy, n959ChavePIXUpdatedBy, A959ChavePIXUpdatedBy});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002Z15 */
                     pr_default.execute(11);
                     A961ChavePIXId = BC002Z15_A961ChavePIXId[0];
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("ChavePIX");
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
               Load2Z103( ) ;
            }
            EndLevel2Z103( ) ;
         }
         CloseExtendedTableCursors2Z103( ) ;
      }

      protected void Update2Z103( )
      {
         BeforeValidate2Z103( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Z103( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Z103( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Z103( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2Z103( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002Z16 */
                     pr_default.execute(12, new Object[] {n966ChavePIXCreatedAt, A966ChavePIXCreatedAt, n967ChavePIXUpdatedAt, A967ChavePIXUpdatedAt, n962ChavePIXTipo, A962ChavePIXTipo, n963ChavePIXConteudo, A963ChavePIXConteudo, n964ChavePIXStatus, A964ChavePIXStatus, n965ChavePIXPrincipal, A965ChavePIXPrincipal, n951ContaBancariaId, A951ContaBancariaId, n957ChavePIXCreatedBy, A957ChavePIXCreatedBy, n959ChavePIXUpdatedBy, A959ChavePIXUpdatedBy, A961ChavePIXId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("ChavePIX");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ChavePIX"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2Z103( ) ;
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
            EndLevel2Z103( ) ;
         }
         CloseExtendedTableCursors2Z103( ) ;
      }

      protected void DeferredUpdate2Z103( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2Z103( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Z103( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2Z103( ) ;
            AfterConfirm2Z103( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2Z103( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002Z17 */
                  pr_default.execute(13, new Object[] {A961ChavePIXId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("ChavePIX");
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
         sMode103 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2Z103( ) ;
         Gx_mode = sMode103;
      }

      protected void OnDeleteControls2Z103( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002Z18 */
            pr_default.execute(14, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            A938AgenciaId = BC002Z18_A938AgenciaId[0];
            n938AgenciaId = BC002Z18_n938AgenciaId[0];
            A952ContaBancariaNumero = BC002Z18_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = BC002Z18_n952ContaBancariaNumero[0];
            pr_default.close(14);
            /* Using cursor BC002Z19 */
            pr_default.execute(15, new Object[] {n938AgenciaId, A938AgenciaId});
            A968AgenciaBancoId = BC002Z19_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC002Z19_n968AgenciaBancoId[0];
            A939AgenciaNumero = BC002Z19_A939AgenciaNumero[0];
            n939AgenciaNumero = BC002Z19_n939AgenciaNumero[0];
            pr_default.close(15);
            /* Using cursor BC002Z20 */
            pr_default.execute(16, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
            A969AgenciaBancoNome = BC002Z20_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC002Z20_n969AgenciaBancoNome[0];
            pr_default.close(16);
            /* Using cursor BC002Z22 */
            pr_default.execute(17, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               A970ContaBancariaCountChavePIX_F = BC002Z22_A970ContaBancariaCountChavePIX_F[0];
               n970ContaBancariaCountChavePIX_F = BC002Z22_n970ContaBancariaCountChavePIX_F[0];
            }
            else
            {
               A970ContaBancariaCountChavePIX_F = 0;
               n970ContaBancariaCountChavePIX_F = false;
            }
            pr_default.close(17);
            /* Using cursor BC002Z23 */
            pr_default.execute(18, new Object[] {n957ChavePIXCreatedBy, A957ChavePIXCreatedBy});
            A958ChavePIXCreatedByName = BC002Z23_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = BC002Z23_n958ChavePIXCreatedByName[0];
            pr_default.close(18);
            /* Using cursor BC002Z24 */
            pr_default.execute(19, new Object[] {n959ChavePIXUpdatedBy, A959ChavePIXUpdatedBy});
            A960ChavePIXUpdatedByName = BC002Z24_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = BC002Z24_n960ChavePIXUpdatedByName[0];
            pr_default.close(19);
         }
      }

      protected void EndLevel2Z103( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2Z103( ) ;
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

      public void ScanKeyStart2Z103( )
      {
         /* Scan By routine */
         /* Using cursor BC002Z26 */
         pr_default.execute(20, new Object[] {A961ChavePIXId});
         RcdFound103 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound103 = 1;
            A938AgenciaId = BC002Z26_A938AgenciaId[0];
            n938AgenciaId = BC002Z26_n938AgenciaId[0];
            A968AgenciaBancoId = BC002Z26_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC002Z26_n968AgenciaBancoId[0];
            A961ChavePIXId = BC002Z26_A961ChavePIXId[0];
            A966ChavePIXCreatedAt = BC002Z26_A966ChavePIXCreatedAt[0];
            n966ChavePIXCreatedAt = BC002Z26_n966ChavePIXCreatedAt[0];
            A967ChavePIXUpdatedAt = BC002Z26_A967ChavePIXUpdatedAt[0];
            n967ChavePIXUpdatedAt = BC002Z26_n967ChavePIXUpdatedAt[0];
            A962ChavePIXTipo = BC002Z26_A962ChavePIXTipo[0];
            n962ChavePIXTipo = BC002Z26_n962ChavePIXTipo[0];
            A963ChavePIXConteudo = BC002Z26_A963ChavePIXConteudo[0];
            n963ChavePIXConteudo = BC002Z26_n963ChavePIXConteudo[0];
            A964ChavePIXStatus = BC002Z26_A964ChavePIXStatus[0];
            n964ChavePIXStatus = BC002Z26_n964ChavePIXStatus[0];
            A965ChavePIXPrincipal = BC002Z26_A965ChavePIXPrincipal[0];
            n965ChavePIXPrincipal = BC002Z26_n965ChavePIXPrincipal[0];
            A952ContaBancariaNumero = BC002Z26_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = BC002Z26_n952ContaBancariaNumero[0];
            A939AgenciaNumero = BC002Z26_A939AgenciaNumero[0];
            n939AgenciaNumero = BC002Z26_n939AgenciaNumero[0];
            A969AgenciaBancoNome = BC002Z26_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC002Z26_n969AgenciaBancoNome[0];
            A958ChavePIXCreatedByName = BC002Z26_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = BC002Z26_n958ChavePIXCreatedByName[0];
            A960ChavePIXUpdatedByName = BC002Z26_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = BC002Z26_n960ChavePIXUpdatedByName[0];
            A951ContaBancariaId = BC002Z26_A951ContaBancariaId[0];
            n951ContaBancariaId = BC002Z26_n951ContaBancariaId[0];
            A957ChavePIXCreatedBy = BC002Z26_A957ChavePIXCreatedBy[0];
            n957ChavePIXCreatedBy = BC002Z26_n957ChavePIXCreatedBy[0];
            A959ChavePIXUpdatedBy = BC002Z26_A959ChavePIXUpdatedBy[0];
            n959ChavePIXUpdatedBy = BC002Z26_n959ChavePIXUpdatedBy[0];
            A970ContaBancariaCountChavePIX_F = BC002Z26_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = BC002Z26_n970ContaBancariaCountChavePIX_F[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2Z103( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound103 = 0;
         ScanKeyLoad2Z103( ) ;
      }

      protected void ScanKeyLoad2Z103( )
      {
         sMode103 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound103 = 1;
            A938AgenciaId = BC002Z26_A938AgenciaId[0];
            n938AgenciaId = BC002Z26_n938AgenciaId[0];
            A968AgenciaBancoId = BC002Z26_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC002Z26_n968AgenciaBancoId[0];
            A961ChavePIXId = BC002Z26_A961ChavePIXId[0];
            A966ChavePIXCreatedAt = BC002Z26_A966ChavePIXCreatedAt[0];
            n966ChavePIXCreatedAt = BC002Z26_n966ChavePIXCreatedAt[0];
            A967ChavePIXUpdatedAt = BC002Z26_A967ChavePIXUpdatedAt[0];
            n967ChavePIXUpdatedAt = BC002Z26_n967ChavePIXUpdatedAt[0];
            A962ChavePIXTipo = BC002Z26_A962ChavePIXTipo[0];
            n962ChavePIXTipo = BC002Z26_n962ChavePIXTipo[0];
            A963ChavePIXConteudo = BC002Z26_A963ChavePIXConteudo[0];
            n963ChavePIXConteudo = BC002Z26_n963ChavePIXConteudo[0];
            A964ChavePIXStatus = BC002Z26_A964ChavePIXStatus[0];
            n964ChavePIXStatus = BC002Z26_n964ChavePIXStatus[0];
            A965ChavePIXPrincipal = BC002Z26_A965ChavePIXPrincipal[0];
            n965ChavePIXPrincipal = BC002Z26_n965ChavePIXPrincipal[0];
            A952ContaBancariaNumero = BC002Z26_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = BC002Z26_n952ContaBancariaNumero[0];
            A939AgenciaNumero = BC002Z26_A939AgenciaNumero[0];
            n939AgenciaNumero = BC002Z26_n939AgenciaNumero[0];
            A969AgenciaBancoNome = BC002Z26_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC002Z26_n969AgenciaBancoNome[0];
            A958ChavePIXCreatedByName = BC002Z26_A958ChavePIXCreatedByName[0];
            n958ChavePIXCreatedByName = BC002Z26_n958ChavePIXCreatedByName[0];
            A960ChavePIXUpdatedByName = BC002Z26_A960ChavePIXUpdatedByName[0];
            n960ChavePIXUpdatedByName = BC002Z26_n960ChavePIXUpdatedByName[0];
            A951ContaBancariaId = BC002Z26_A951ContaBancariaId[0];
            n951ContaBancariaId = BC002Z26_n951ContaBancariaId[0];
            A957ChavePIXCreatedBy = BC002Z26_A957ChavePIXCreatedBy[0];
            n957ChavePIXCreatedBy = BC002Z26_n957ChavePIXCreatedBy[0];
            A959ChavePIXUpdatedBy = BC002Z26_A959ChavePIXUpdatedBy[0];
            n959ChavePIXUpdatedBy = BC002Z26_n959ChavePIXUpdatedBy[0];
            A970ContaBancariaCountChavePIX_F = BC002Z26_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = BC002Z26_n970ContaBancariaCountChavePIX_F[0];
         }
         Gx_mode = sMode103;
      }

      protected void ScanKeyEnd2Z103( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm2Z103( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2Z103( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2Z103( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2Z103( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2Z103( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2Z103( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2Z103( )
      {
      }

      protected void send_integrity_lvl_hashes2Z103( )
      {
      }

      protected void AddRow2Z103( )
      {
         VarsToRow103( bcChavePIX) ;
      }

      protected void ReadRow2Z103( )
      {
         RowToVars103( bcChavePIX, 1) ;
      }

      protected void InitializeNonKey2Z103( )
      {
         A968AgenciaBancoId = 0;
         n968AgenciaBancoId = false;
         A938AgenciaId = 0;
         n938AgenciaId = false;
         A966ChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         n966ChavePIXCreatedAt = false;
         A967ChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         n967ChavePIXUpdatedAt = false;
         A970ContaBancariaCountChavePIX_F = 0;
         n970ContaBancariaCountChavePIX_F = false;
         A962ChavePIXTipo = "";
         n962ChavePIXTipo = false;
         A963ChavePIXConteudo = "";
         n963ChavePIXConteudo = false;
         A965ChavePIXPrincipal = false;
         n965ChavePIXPrincipal = false;
         A951ContaBancariaId = 0;
         n951ContaBancariaId = false;
         A952ContaBancariaNumero = 0;
         n952ContaBancariaNumero = false;
         A939AgenciaNumero = 0;
         n939AgenciaNumero = false;
         A969AgenciaBancoNome = "";
         n969AgenciaBancoNome = false;
         A957ChavePIXCreatedBy = 0;
         n957ChavePIXCreatedBy = false;
         A958ChavePIXCreatedByName = "";
         n958ChavePIXCreatedByName = false;
         A959ChavePIXUpdatedBy = 0;
         n959ChavePIXUpdatedBy = false;
         A960ChavePIXUpdatedByName = "";
         n960ChavePIXUpdatedByName = false;
         A964ChavePIXStatus = true;
         n964ChavePIXStatus = false;
         Z966ChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         Z967ChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         Z962ChavePIXTipo = "";
         Z963ChavePIXConteudo = "";
         Z964ChavePIXStatus = false;
         Z965ChavePIXPrincipal = false;
         Z951ContaBancariaId = 0;
         Z957ChavePIXCreatedBy = 0;
         Z959ChavePIXUpdatedBy = 0;
      }

      protected void InitAll2Z103( )
      {
         A961ChavePIXId = 0;
         InitializeNonKey2Z103( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A966ChavePIXCreatedAt = i966ChavePIXCreatedAt;
         n966ChavePIXCreatedAt = false;
         A964ChavePIXStatus = i964ChavePIXStatus;
         n964ChavePIXStatus = false;
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

      public void VarsToRow103( SdtChavePIX obj103 )
      {
         obj103.gxTpr_Mode = Gx_mode;
         obj103.gxTpr_Chavepixcreatedat = A966ChavePIXCreatedAt;
         obj103.gxTpr_Chavepixupdatedat = A967ChavePIXUpdatedAt;
         obj103.gxTpr_Contabancariacountchavepix_f = A970ContaBancariaCountChavePIX_F;
         obj103.gxTpr_Chavepixtipo = A962ChavePIXTipo;
         obj103.gxTpr_Chavepixconteudo = A963ChavePIXConteudo;
         obj103.gxTpr_Chavepixprincipal = A965ChavePIXPrincipal;
         obj103.gxTpr_Contabancariaid = A951ContaBancariaId;
         obj103.gxTpr_Contabancarianumero = A952ContaBancariaNumero;
         obj103.gxTpr_Agencianumero = A939AgenciaNumero;
         obj103.gxTpr_Agenciabanconome = A969AgenciaBancoNome;
         obj103.gxTpr_Chavepixcreatedby = A957ChavePIXCreatedBy;
         obj103.gxTpr_Chavepixcreatedbyname = A958ChavePIXCreatedByName;
         obj103.gxTpr_Chavepixupdatedby = A959ChavePIXUpdatedBy;
         obj103.gxTpr_Chavepixupdatedbyname = A960ChavePIXUpdatedByName;
         obj103.gxTpr_Chavepixstatus = A964ChavePIXStatus;
         obj103.gxTpr_Chavepixid = A961ChavePIXId;
         obj103.gxTpr_Chavepixid_Z = Z961ChavePIXId;
         obj103.gxTpr_Chavepixtipo_Z = Z962ChavePIXTipo;
         obj103.gxTpr_Chavepixconteudo_Z = Z963ChavePIXConteudo;
         obj103.gxTpr_Chavepixstatus_Z = Z964ChavePIXStatus;
         obj103.gxTpr_Chavepixprincipal_Z = Z965ChavePIXPrincipal;
         obj103.gxTpr_Contabancariaid_Z = Z951ContaBancariaId;
         obj103.gxTpr_Contabancarianumero_Z = Z952ContaBancariaNumero;
         obj103.gxTpr_Contabancariacountchavepix_f_Z = Z970ContaBancariaCountChavePIX_F;
         obj103.gxTpr_Agencianumero_Z = Z939AgenciaNumero;
         obj103.gxTpr_Agenciabanconome_Z = Z969AgenciaBancoNome;
         obj103.gxTpr_Chavepixcreatedat_Z = Z966ChavePIXCreatedAt;
         obj103.gxTpr_Chavepixcreatedby_Z = Z957ChavePIXCreatedBy;
         obj103.gxTpr_Chavepixcreatedbyname_Z = Z958ChavePIXCreatedByName;
         obj103.gxTpr_Chavepixupdatedat_Z = Z967ChavePIXUpdatedAt;
         obj103.gxTpr_Chavepixupdatedby_Z = Z959ChavePIXUpdatedBy;
         obj103.gxTpr_Chavepixupdatedbyname_Z = Z960ChavePIXUpdatedByName;
         obj103.gxTpr_Chavepixtipo_N = (short)(Convert.ToInt16(n962ChavePIXTipo));
         obj103.gxTpr_Chavepixconteudo_N = (short)(Convert.ToInt16(n963ChavePIXConteudo));
         obj103.gxTpr_Chavepixstatus_N = (short)(Convert.ToInt16(n964ChavePIXStatus));
         obj103.gxTpr_Chavepixprincipal_N = (short)(Convert.ToInt16(n965ChavePIXPrincipal));
         obj103.gxTpr_Contabancariaid_N = (short)(Convert.ToInt16(n951ContaBancariaId));
         obj103.gxTpr_Contabancarianumero_N = (short)(Convert.ToInt16(n952ContaBancariaNumero));
         obj103.gxTpr_Contabancariacountchavepix_f_N = (short)(Convert.ToInt16(n970ContaBancariaCountChavePIX_F));
         obj103.gxTpr_Agencianumero_N = (short)(Convert.ToInt16(n939AgenciaNumero));
         obj103.gxTpr_Agenciabanconome_N = (short)(Convert.ToInt16(n969AgenciaBancoNome));
         obj103.gxTpr_Chavepixcreatedat_N = (short)(Convert.ToInt16(n966ChavePIXCreatedAt));
         obj103.gxTpr_Chavepixcreatedby_N = (short)(Convert.ToInt16(n957ChavePIXCreatedBy));
         obj103.gxTpr_Chavepixcreatedbyname_N = (short)(Convert.ToInt16(n958ChavePIXCreatedByName));
         obj103.gxTpr_Chavepixupdatedat_N = (short)(Convert.ToInt16(n967ChavePIXUpdatedAt));
         obj103.gxTpr_Chavepixupdatedby_N = (short)(Convert.ToInt16(n959ChavePIXUpdatedBy));
         obj103.gxTpr_Chavepixupdatedbyname_N = (short)(Convert.ToInt16(n960ChavePIXUpdatedByName));
         obj103.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow103( SdtChavePIX obj103 )
      {
         obj103.gxTpr_Chavepixid = A961ChavePIXId;
         return  ;
      }

      public void RowToVars103( SdtChavePIX obj103 ,
                                int forceLoad )
      {
         Gx_mode = obj103.gxTpr_Mode;
         A966ChavePIXCreatedAt = obj103.gxTpr_Chavepixcreatedat;
         n966ChavePIXCreatedAt = false;
         A967ChavePIXUpdatedAt = obj103.gxTpr_Chavepixupdatedat;
         n967ChavePIXUpdatedAt = false;
         A970ContaBancariaCountChavePIX_F = obj103.gxTpr_Contabancariacountchavepix_f;
         n970ContaBancariaCountChavePIX_F = false;
         A962ChavePIXTipo = obj103.gxTpr_Chavepixtipo;
         n962ChavePIXTipo = false;
         A963ChavePIXConteudo = obj103.gxTpr_Chavepixconteudo;
         n963ChavePIXConteudo = false;
         A965ChavePIXPrincipal = obj103.gxTpr_Chavepixprincipal;
         n965ChavePIXPrincipal = false;
         A951ContaBancariaId = obj103.gxTpr_Contabancariaid;
         n951ContaBancariaId = false;
         A952ContaBancariaNumero = obj103.gxTpr_Contabancarianumero;
         n952ContaBancariaNumero = false;
         A939AgenciaNumero = obj103.gxTpr_Agencianumero;
         n939AgenciaNumero = false;
         A969AgenciaBancoNome = obj103.gxTpr_Agenciabanconome;
         n969AgenciaBancoNome = false;
         A957ChavePIXCreatedBy = obj103.gxTpr_Chavepixcreatedby;
         n957ChavePIXCreatedBy = false;
         A958ChavePIXCreatedByName = obj103.gxTpr_Chavepixcreatedbyname;
         n958ChavePIXCreatedByName = false;
         A959ChavePIXUpdatedBy = obj103.gxTpr_Chavepixupdatedby;
         n959ChavePIXUpdatedBy = false;
         A960ChavePIXUpdatedByName = obj103.gxTpr_Chavepixupdatedbyname;
         n960ChavePIXUpdatedByName = false;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A964ChavePIXStatus = obj103.gxTpr_Chavepixstatus;
            n964ChavePIXStatus = false;
         }
         A961ChavePIXId = obj103.gxTpr_Chavepixid;
         Z961ChavePIXId = obj103.gxTpr_Chavepixid_Z;
         Z962ChavePIXTipo = obj103.gxTpr_Chavepixtipo_Z;
         Z963ChavePIXConteudo = obj103.gxTpr_Chavepixconteudo_Z;
         Z964ChavePIXStatus = obj103.gxTpr_Chavepixstatus_Z;
         Z965ChavePIXPrincipal = obj103.gxTpr_Chavepixprincipal_Z;
         Z951ContaBancariaId = obj103.gxTpr_Contabancariaid_Z;
         Z952ContaBancariaNumero = obj103.gxTpr_Contabancarianumero_Z;
         Z970ContaBancariaCountChavePIX_F = obj103.gxTpr_Contabancariacountchavepix_f_Z;
         Z939AgenciaNumero = obj103.gxTpr_Agencianumero_Z;
         Z969AgenciaBancoNome = obj103.gxTpr_Agenciabanconome_Z;
         Z966ChavePIXCreatedAt = obj103.gxTpr_Chavepixcreatedat_Z;
         Z957ChavePIXCreatedBy = obj103.gxTpr_Chavepixcreatedby_Z;
         Z958ChavePIXCreatedByName = obj103.gxTpr_Chavepixcreatedbyname_Z;
         Z967ChavePIXUpdatedAt = obj103.gxTpr_Chavepixupdatedat_Z;
         Z959ChavePIXUpdatedBy = obj103.gxTpr_Chavepixupdatedby_Z;
         Z960ChavePIXUpdatedByName = obj103.gxTpr_Chavepixupdatedbyname_Z;
         n962ChavePIXTipo = (bool)(Convert.ToBoolean(obj103.gxTpr_Chavepixtipo_N));
         n963ChavePIXConteudo = (bool)(Convert.ToBoolean(obj103.gxTpr_Chavepixconteudo_N));
         n964ChavePIXStatus = (bool)(Convert.ToBoolean(obj103.gxTpr_Chavepixstatus_N));
         n965ChavePIXPrincipal = (bool)(Convert.ToBoolean(obj103.gxTpr_Chavepixprincipal_N));
         n951ContaBancariaId = (bool)(Convert.ToBoolean(obj103.gxTpr_Contabancariaid_N));
         n952ContaBancariaNumero = (bool)(Convert.ToBoolean(obj103.gxTpr_Contabancarianumero_N));
         n970ContaBancariaCountChavePIX_F = (bool)(Convert.ToBoolean(obj103.gxTpr_Contabancariacountchavepix_f_N));
         n939AgenciaNumero = (bool)(Convert.ToBoolean(obj103.gxTpr_Agencianumero_N));
         n969AgenciaBancoNome = (bool)(Convert.ToBoolean(obj103.gxTpr_Agenciabanconome_N));
         n966ChavePIXCreatedAt = (bool)(Convert.ToBoolean(obj103.gxTpr_Chavepixcreatedat_N));
         n957ChavePIXCreatedBy = (bool)(Convert.ToBoolean(obj103.gxTpr_Chavepixcreatedby_N));
         n958ChavePIXCreatedByName = (bool)(Convert.ToBoolean(obj103.gxTpr_Chavepixcreatedbyname_N));
         n967ChavePIXUpdatedAt = (bool)(Convert.ToBoolean(obj103.gxTpr_Chavepixupdatedat_N));
         n959ChavePIXUpdatedBy = (bool)(Convert.ToBoolean(obj103.gxTpr_Chavepixupdatedby_N));
         n960ChavePIXUpdatedByName = (bool)(Convert.ToBoolean(obj103.gxTpr_Chavepixupdatedbyname_N));
         Gx_mode = obj103.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A961ChavePIXId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2Z103( ) ;
         ScanKeyStart2Z103( ) ;
         if ( RcdFound103 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z961ChavePIXId = A961ChavePIXId;
         }
         ZM2Z103( -8) ;
         OnLoadActions2Z103( ) ;
         AddRow2Z103( ) ;
         ScanKeyEnd2Z103( ) ;
         if ( RcdFound103 == 0 )
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
         RowToVars103( bcChavePIX, 0) ;
         ScanKeyStart2Z103( ) ;
         if ( RcdFound103 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z961ChavePIXId = A961ChavePIXId;
         }
         ZM2Z103( -8) ;
         OnLoadActions2Z103( ) ;
         AddRow2Z103( ) ;
         ScanKeyEnd2Z103( ) ;
         if ( RcdFound103 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2Z103( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2Z103( ) ;
         }
         else
         {
            if ( RcdFound103 == 1 )
            {
               if ( A961ChavePIXId != Z961ChavePIXId )
               {
                  A961ChavePIXId = Z961ChavePIXId;
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
                  Update2Z103( ) ;
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
                  if ( A961ChavePIXId != Z961ChavePIXId )
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
                        Insert2Z103( ) ;
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
                        Insert2Z103( ) ;
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
         RowToVars103( bcChavePIX, 1) ;
         SaveImpl( ) ;
         VarsToRow103( bcChavePIX) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars103( bcChavePIX, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2Z103( ) ;
         AfterTrn( ) ;
         VarsToRow103( bcChavePIX) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow103( bcChavePIX) ;
         }
         else
         {
            SdtChavePIX auxBC = new SdtChavePIX(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A961ChavePIXId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcChavePIX);
               auxBC.Save();
               bcChavePIX.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars103( bcChavePIX, 1) ;
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
         RowToVars103( bcChavePIX, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2Z103( ) ;
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
               VarsToRow103( bcChavePIX) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow103( bcChavePIX) ;
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
         RowToVars103( bcChavePIX, 0) ;
         GetKey2Z103( ) ;
         if ( RcdFound103 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A961ChavePIXId != Z961ChavePIXId )
            {
               A961ChavePIXId = Z961ChavePIXId;
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
            if ( A961ChavePIXId != Z961ChavePIXId )
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
         context.RollbackDataStores("chavepix_bc",pr_default);
         VarsToRow103( bcChavePIX) ;
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
         Gx_mode = bcChavePIX.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcChavePIX.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcChavePIX )
         {
            bcChavePIX = (SdtChavePIX)(sdt);
            if ( StringUtil.StrCmp(bcChavePIX.gxTpr_Mode, "") == 0 )
            {
               bcChavePIX.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow103( bcChavePIX) ;
            }
            else
            {
               RowToVars103( bcChavePIX, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcChavePIX.gxTpr_Mode, "") == 0 )
            {
               bcChavePIX.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars103( bcChavePIX, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtChavePIX ChavePIX_BC
      {
         get {
            return bcChavePIX ;
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
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV17Pgmname = "";
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z966ChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         A966ChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         Z967ChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         A967ChavePIXUpdatedAt = (DateTime)(DateTime.MinValue);
         Z962ChavePIXTipo = "";
         A962ChavePIXTipo = "";
         Z963ChavePIXConteudo = "";
         A963ChavePIXConteudo = "";
         Z958ChavePIXCreatedByName = "";
         A958ChavePIXCreatedByName = "";
         Z960ChavePIXUpdatedByName = "";
         A960ChavePIXUpdatedByName = "";
         Z969AgenciaBancoNome = "";
         A969AgenciaBancoNome = "";
         BC002Z12_A938AgenciaId = new int[1] ;
         BC002Z12_n938AgenciaId = new bool[] {false} ;
         BC002Z12_A968AgenciaBancoId = new int[1] ;
         BC002Z12_n968AgenciaBancoId = new bool[] {false} ;
         BC002Z12_A961ChavePIXId = new int[1] ;
         BC002Z12_A966ChavePIXCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Z12_n966ChavePIXCreatedAt = new bool[] {false} ;
         BC002Z12_A967ChavePIXUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Z12_n967ChavePIXUpdatedAt = new bool[] {false} ;
         BC002Z12_A962ChavePIXTipo = new string[] {""} ;
         BC002Z12_n962ChavePIXTipo = new bool[] {false} ;
         BC002Z12_A963ChavePIXConteudo = new string[] {""} ;
         BC002Z12_n963ChavePIXConteudo = new bool[] {false} ;
         BC002Z12_A964ChavePIXStatus = new bool[] {false} ;
         BC002Z12_n964ChavePIXStatus = new bool[] {false} ;
         BC002Z12_A965ChavePIXPrincipal = new bool[] {false} ;
         BC002Z12_n965ChavePIXPrincipal = new bool[] {false} ;
         BC002Z12_A952ContaBancariaNumero = new long[1] ;
         BC002Z12_n952ContaBancariaNumero = new bool[] {false} ;
         BC002Z12_A939AgenciaNumero = new int[1] ;
         BC002Z12_n939AgenciaNumero = new bool[] {false} ;
         BC002Z12_A969AgenciaBancoNome = new string[] {""} ;
         BC002Z12_n969AgenciaBancoNome = new bool[] {false} ;
         BC002Z12_A958ChavePIXCreatedByName = new string[] {""} ;
         BC002Z12_n958ChavePIXCreatedByName = new bool[] {false} ;
         BC002Z12_A960ChavePIXUpdatedByName = new string[] {""} ;
         BC002Z12_n960ChavePIXUpdatedByName = new bool[] {false} ;
         BC002Z12_A951ContaBancariaId = new int[1] ;
         BC002Z12_n951ContaBancariaId = new bool[] {false} ;
         BC002Z12_A957ChavePIXCreatedBy = new short[1] ;
         BC002Z12_n957ChavePIXCreatedBy = new bool[] {false} ;
         BC002Z12_A959ChavePIXUpdatedBy = new short[1] ;
         BC002Z12_n959ChavePIXUpdatedBy = new bool[] {false} ;
         BC002Z12_A970ContaBancariaCountChavePIX_F = new short[1] ;
         BC002Z12_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         BC002Z4_A938AgenciaId = new int[1] ;
         BC002Z4_n938AgenciaId = new bool[] {false} ;
         BC002Z4_A952ContaBancariaNumero = new long[1] ;
         BC002Z4_n952ContaBancariaNumero = new bool[] {false} ;
         BC002Z7_A968AgenciaBancoId = new int[1] ;
         BC002Z7_n968AgenciaBancoId = new bool[] {false} ;
         BC002Z7_A939AgenciaNumero = new int[1] ;
         BC002Z7_n939AgenciaNumero = new bool[] {false} ;
         BC002Z8_A969AgenciaBancoNome = new string[] {""} ;
         BC002Z8_n969AgenciaBancoNome = new bool[] {false} ;
         BC002Z10_A970ContaBancariaCountChavePIX_F = new short[1] ;
         BC002Z10_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         BC002Z5_A958ChavePIXCreatedByName = new string[] {""} ;
         BC002Z5_n958ChavePIXCreatedByName = new bool[] {false} ;
         BC002Z6_A960ChavePIXUpdatedByName = new string[] {""} ;
         BC002Z6_n960ChavePIXUpdatedByName = new bool[] {false} ;
         BC002Z13_A961ChavePIXId = new int[1] ;
         BC002Z3_A961ChavePIXId = new int[1] ;
         BC002Z3_A966ChavePIXCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Z3_n966ChavePIXCreatedAt = new bool[] {false} ;
         BC002Z3_A967ChavePIXUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Z3_n967ChavePIXUpdatedAt = new bool[] {false} ;
         BC002Z3_A962ChavePIXTipo = new string[] {""} ;
         BC002Z3_n962ChavePIXTipo = new bool[] {false} ;
         BC002Z3_A963ChavePIXConteudo = new string[] {""} ;
         BC002Z3_n963ChavePIXConteudo = new bool[] {false} ;
         BC002Z3_A964ChavePIXStatus = new bool[] {false} ;
         BC002Z3_n964ChavePIXStatus = new bool[] {false} ;
         BC002Z3_A965ChavePIXPrincipal = new bool[] {false} ;
         BC002Z3_n965ChavePIXPrincipal = new bool[] {false} ;
         BC002Z3_A951ContaBancariaId = new int[1] ;
         BC002Z3_n951ContaBancariaId = new bool[] {false} ;
         BC002Z3_A957ChavePIXCreatedBy = new short[1] ;
         BC002Z3_n957ChavePIXCreatedBy = new bool[] {false} ;
         BC002Z3_A959ChavePIXUpdatedBy = new short[1] ;
         BC002Z3_n959ChavePIXUpdatedBy = new bool[] {false} ;
         sMode103 = "";
         BC002Z2_A961ChavePIXId = new int[1] ;
         BC002Z2_A966ChavePIXCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Z2_n966ChavePIXCreatedAt = new bool[] {false} ;
         BC002Z2_A967ChavePIXUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Z2_n967ChavePIXUpdatedAt = new bool[] {false} ;
         BC002Z2_A962ChavePIXTipo = new string[] {""} ;
         BC002Z2_n962ChavePIXTipo = new bool[] {false} ;
         BC002Z2_A963ChavePIXConteudo = new string[] {""} ;
         BC002Z2_n963ChavePIXConteudo = new bool[] {false} ;
         BC002Z2_A964ChavePIXStatus = new bool[] {false} ;
         BC002Z2_n964ChavePIXStatus = new bool[] {false} ;
         BC002Z2_A965ChavePIXPrincipal = new bool[] {false} ;
         BC002Z2_n965ChavePIXPrincipal = new bool[] {false} ;
         BC002Z2_A951ContaBancariaId = new int[1] ;
         BC002Z2_n951ContaBancariaId = new bool[] {false} ;
         BC002Z2_A957ChavePIXCreatedBy = new short[1] ;
         BC002Z2_n957ChavePIXCreatedBy = new bool[] {false} ;
         BC002Z2_A959ChavePIXUpdatedBy = new short[1] ;
         BC002Z2_n959ChavePIXUpdatedBy = new bool[] {false} ;
         BC002Z15_A961ChavePIXId = new int[1] ;
         BC002Z18_A938AgenciaId = new int[1] ;
         BC002Z18_n938AgenciaId = new bool[] {false} ;
         BC002Z18_A952ContaBancariaNumero = new long[1] ;
         BC002Z18_n952ContaBancariaNumero = new bool[] {false} ;
         BC002Z19_A968AgenciaBancoId = new int[1] ;
         BC002Z19_n968AgenciaBancoId = new bool[] {false} ;
         BC002Z19_A939AgenciaNumero = new int[1] ;
         BC002Z19_n939AgenciaNumero = new bool[] {false} ;
         BC002Z20_A969AgenciaBancoNome = new string[] {""} ;
         BC002Z20_n969AgenciaBancoNome = new bool[] {false} ;
         BC002Z22_A970ContaBancariaCountChavePIX_F = new short[1] ;
         BC002Z22_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         BC002Z23_A958ChavePIXCreatedByName = new string[] {""} ;
         BC002Z23_n958ChavePIXCreatedByName = new bool[] {false} ;
         BC002Z24_A960ChavePIXUpdatedByName = new string[] {""} ;
         BC002Z24_n960ChavePIXUpdatedByName = new bool[] {false} ;
         BC002Z26_A938AgenciaId = new int[1] ;
         BC002Z26_n938AgenciaId = new bool[] {false} ;
         BC002Z26_A968AgenciaBancoId = new int[1] ;
         BC002Z26_n968AgenciaBancoId = new bool[] {false} ;
         BC002Z26_A961ChavePIXId = new int[1] ;
         BC002Z26_A966ChavePIXCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Z26_n966ChavePIXCreatedAt = new bool[] {false} ;
         BC002Z26_A967ChavePIXUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Z26_n967ChavePIXUpdatedAt = new bool[] {false} ;
         BC002Z26_A962ChavePIXTipo = new string[] {""} ;
         BC002Z26_n962ChavePIXTipo = new bool[] {false} ;
         BC002Z26_A963ChavePIXConteudo = new string[] {""} ;
         BC002Z26_n963ChavePIXConteudo = new bool[] {false} ;
         BC002Z26_A964ChavePIXStatus = new bool[] {false} ;
         BC002Z26_n964ChavePIXStatus = new bool[] {false} ;
         BC002Z26_A965ChavePIXPrincipal = new bool[] {false} ;
         BC002Z26_n965ChavePIXPrincipal = new bool[] {false} ;
         BC002Z26_A952ContaBancariaNumero = new long[1] ;
         BC002Z26_n952ContaBancariaNumero = new bool[] {false} ;
         BC002Z26_A939AgenciaNumero = new int[1] ;
         BC002Z26_n939AgenciaNumero = new bool[] {false} ;
         BC002Z26_A969AgenciaBancoNome = new string[] {""} ;
         BC002Z26_n969AgenciaBancoNome = new bool[] {false} ;
         BC002Z26_A958ChavePIXCreatedByName = new string[] {""} ;
         BC002Z26_n958ChavePIXCreatedByName = new bool[] {false} ;
         BC002Z26_A960ChavePIXUpdatedByName = new string[] {""} ;
         BC002Z26_n960ChavePIXUpdatedByName = new bool[] {false} ;
         BC002Z26_A951ContaBancariaId = new int[1] ;
         BC002Z26_n951ContaBancariaId = new bool[] {false} ;
         BC002Z26_A957ChavePIXCreatedBy = new short[1] ;
         BC002Z26_n957ChavePIXCreatedBy = new bool[] {false} ;
         BC002Z26_A959ChavePIXUpdatedBy = new short[1] ;
         BC002Z26_n959ChavePIXUpdatedBy = new bool[] {false} ;
         BC002Z26_A970ContaBancariaCountChavePIX_F = new short[1] ;
         BC002Z26_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         i966ChavePIXCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.chavepix_bc__default(),
            new Object[][] {
                new Object[] {
               BC002Z2_A961ChavePIXId, BC002Z2_A966ChavePIXCreatedAt, BC002Z2_n966ChavePIXCreatedAt, BC002Z2_A967ChavePIXUpdatedAt, BC002Z2_n967ChavePIXUpdatedAt, BC002Z2_A962ChavePIXTipo, BC002Z2_n962ChavePIXTipo, BC002Z2_A963ChavePIXConteudo, BC002Z2_n963ChavePIXConteudo, BC002Z2_A964ChavePIXStatus,
               BC002Z2_n964ChavePIXStatus, BC002Z2_A965ChavePIXPrincipal, BC002Z2_n965ChavePIXPrincipal, BC002Z2_A951ContaBancariaId, BC002Z2_n951ContaBancariaId, BC002Z2_A957ChavePIXCreatedBy, BC002Z2_n957ChavePIXCreatedBy, BC002Z2_A959ChavePIXUpdatedBy, BC002Z2_n959ChavePIXUpdatedBy
               }
               , new Object[] {
               BC002Z3_A961ChavePIXId, BC002Z3_A966ChavePIXCreatedAt, BC002Z3_n966ChavePIXCreatedAt, BC002Z3_A967ChavePIXUpdatedAt, BC002Z3_n967ChavePIXUpdatedAt, BC002Z3_A962ChavePIXTipo, BC002Z3_n962ChavePIXTipo, BC002Z3_A963ChavePIXConteudo, BC002Z3_n963ChavePIXConteudo, BC002Z3_A964ChavePIXStatus,
               BC002Z3_n964ChavePIXStatus, BC002Z3_A965ChavePIXPrincipal, BC002Z3_n965ChavePIXPrincipal, BC002Z3_A951ContaBancariaId, BC002Z3_n951ContaBancariaId, BC002Z3_A957ChavePIXCreatedBy, BC002Z3_n957ChavePIXCreatedBy, BC002Z3_A959ChavePIXUpdatedBy, BC002Z3_n959ChavePIXUpdatedBy
               }
               , new Object[] {
               BC002Z4_A938AgenciaId, BC002Z4_n938AgenciaId, BC002Z4_A952ContaBancariaNumero, BC002Z4_n952ContaBancariaNumero
               }
               , new Object[] {
               BC002Z5_A958ChavePIXCreatedByName, BC002Z5_n958ChavePIXCreatedByName
               }
               , new Object[] {
               BC002Z6_A960ChavePIXUpdatedByName, BC002Z6_n960ChavePIXUpdatedByName
               }
               , new Object[] {
               BC002Z7_A968AgenciaBancoId, BC002Z7_n968AgenciaBancoId, BC002Z7_A939AgenciaNumero, BC002Z7_n939AgenciaNumero
               }
               , new Object[] {
               BC002Z8_A969AgenciaBancoNome, BC002Z8_n969AgenciaBancoNome
               }
               , new Object[] {
               BC002Z10_A970ContaBancariaCountChavePIX_F, BC002Z10_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               BC002Z12_A938AgenciaId, BC002Z12_n938AgenciaId, BC002Z12_A968AgenciaBancoId, BC002Z12_n968AgenciaBancoId, BC002Z12_A961ChavePIXId, BC002Z12_A966ChavePIXCreatedAt, BC002Z12_n966ChavePIXCreatedAt, BC002Z12_A967ChavePIXUpdatedAt, BC002Z12_n967ChavePIXUpdatedAt, BC002Z12_A962ChavePIXTipo,
               BC002Z12_n962ChavePIXTipo, BC002Z12_A963ChavePIXConteudo, BC002Z12_n963ChavePIXConteudo, BC002Z12_A964ChavePIXStatus, BC002Z12_n964ChavePIXStatus, BC002Z12_A965ChavePIXPrincipal, BC002Z12_n965ChavePIXPrincipal, BC002Z12_A952ContaBancariaNumero, BC002Z12_n952ContaBancariaNumero, BC002Z12_A939AgenciaNumero,
               BC002Z12_n939AgenciaNumero, BC002Z12_A969AgenciaBancoNome, BC002Z12_n969AgenciaBancoNome, BC002Z12_A958ChavePIXCreatedByName, BC002Z12_n958ChavePIXCreatedByName, BC002Z12_A960ChavePIXUpdatedByName, BC002Z12_n960ChavePIXUpdatedByName, BC002Z12_A951ContaBancariaId, BC002Z12_n951ContaBancariaId, BC002Z12_A957ChavePIXCreatedBy,
               BC002Z12_n957ChavePIXCreatedBy, BC002Z12_A959ChavePIXUpdatedBy, BC002Z12_n959ChavePIXUpdatedBy, BC002Z12_A970ContaBancariaCountChavePIX_F, BC002Z12_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               BC002Z13_A961ChavePIXId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002Z15_A961ChavePIXId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002Z18_A938AgenciaId, BC002Z18_n938AgenciaId, BC002Z18_A952ContaBancariaNumero, BC002Z18_n952ContaBancariaNumero
               }
               , new Object[] {
               BC002Z19_A968AgenciaBancoId, BC002Z19_n968AgenciaBancoId, BC002Z19_A939AgenciaNumero, BC002Z19_n939AgenciaNumero
               }
               , new Object[] {
               BC002Z20_A969AgenciaBancoNome, BC002Z20_n969AgenciaBancoNome
               }
               , new Object[] {
               BC002Z22_A970ContaBancariaCountChavePIX_F, BC002Z22_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               BC002Z23_A958ChavePIXCreatedByName, BC002Z23_n958ChavePIXCreatedByName
               }
               , new Object[] {
               BC002Z24_A960ChavePIXUpdatedByName, BC002Z24_n960ChavePIXUpdatedByName
               }
               , new Object[] {
               BC002Z26_A938AgenciaId, BC002Z26_n938AgenciaId, BC002Z26_A968AgenciaBancoId, BC002Z26_n968AgenciaBancoId, BC002Z26_A961ChavePIXId, BC002Z26_A966ChavePIXCreatedAt, BC002Z26_n966ChavePIXCreatedAt, BC002Z26_A967ChavePIXUpdatedAt, BC002Z26_n967ChavePIXUpdatedAt, BC002Z26_A962ChavePIXTipo,
               BC002Z26_n962ChavePIXTipo, BC002Z26_A963ChavePIXConteudo, BC002Z26_n963ChavePIXConteudo, BC002Z26_A964ChavePIXStatus, BC002Z26_n964ChavePIXStatus, BC002Z26_A965ChavePIXPrincipal, BC002Z26_n965ChavePIXPrincipal, BC002Z26_A952ContaBancariaNumero, BC002Z26_n952ContaBancariaNumero, BC002Z26_A939AgenciaNumero,
               BC002Z26_n939AgenciaNumero, BC002Z26_A969AgenciaBancoNome, BC002Z26_n969AgenciaBancoNome, BC002Z26_A958ChavePIXCreatedByName, BC002Z26_n958ChavePIXCreatedByName, BC002Z26_A960ChavePIXUpdatedByName, BC002Z26_n960ChavePIXUpdatedByName, BC002Z26_A951ContaBancariaId, BC002Z26_n951ContaBancariaId, BC002Z26_A957ChavePIXCreatedBy,
               BC002Z26_n957ChavePIXCreatedBy, BC002Z26_A959ChavePIXUpdatedBy, BC002Z26_n959ChavePIXUpdatedBy, BC002Z26_A970ContaBancariaCountChavePIX_F, BC002Z26_n970ContaBancariaCountChavePIX_F
               }
            }
         );
         AV17Pgmname = "ChavePIX_BC";
         Z964ChavePIXStatus = true;
         n964ChavePIXStatus = false;
         A964ChavePIXStatus = true;
         n964ChavePIXStatus = false;
         i964ChavePIXStatus = true;
         n964ChavePIXStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122Z2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV12Insert_ChavePIXCreatedBy ;
      private short AV13Insert_ChavePIXUpdatedBy ;
      private short Z957ChavePIXCreatedBy ;
      private short A957ChavePIXCreatedBy ;
      private short Z959ChavePIXUpdatedBy ;
      private short A959ChavePIXUpdatedBy ;
      private short Z970ContaBancariaCountChavePIX_F ;
      private short A970ContaBancariaCountChavePIX_F ;
      private short Gx_BScreen ;
      private short RcdFound103 ;
      private int trnEnded ;
      private int Z961ChavePIXId ;
      private int A961ChavePIXId ;
      private int AV18GXV1 ;
      private int AV11Insert_ContaBancariaId ;
      private int Z951ContaBancariaId ;
      private int A951ContaBancariaId ;
      private int Z938AgenciaId ;
      private int A938AgenciaId ;
      private int Z968AgenciaBancoId ;
      private int A968AgenciaBancoId ;
      private int Z939AgenciaNumero ;
      private int A939AgenciaNumero ;
      private long Z952ContaBancariaNumero ;
      private long A952ContaBancariaNumero ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV17Pgmname ;
      private string sMode103 ;
      private DateTime Z966ChavePIXCreatedAt ;
      private DateTime A966ChavePIXCreatedAt ;
      private DateTime Z967ChavePIXUpdatedAt ;
      private DateTime A967ChavePIXUpdatedAt ;
      private DateTime i966ChavePIXCreatedAt ;
      private bool returnInSub ;
      private bool Z964ChavePIXStatus ;
      private bool A964ChavePIXStatus ;
      private bool Z965ChavePIXPrincipal ;
      private bool A965ChavePIXPrincipal ;
      private bool n966ChavePIXCreatedAt ;
      private bool n967ChavePIXUpdatedAt ;
      private bool n964ChavePIXStatus ;
      private bool n938AgenciaId ;
      private bool n968AgenciaBancoId ;
      private bool n962ChavePIXTipo ;
      private bool n963ChavePIXConteudo ;
      private bool n965ChavePIXPrincipal ;
      private bool n952ContaBancariaNumero ;
      private bool n939AgenciaNumero ;
      private bool n969AgenciaBancoNome ;
      private bool n958ChavePIXCreatedByName ;
      private bool n960ChavePIXUpdatedByName ;
      private bool n951ContaBancariaId ;
      private bool n957ChavePIXCreatedBy ;
      private bool n959ChavePIXUpdatedBy ;
      private bool n970ContaBancariaCountChavePIX_F ;
      private bool Gx_longc ;
      private bool i964ChavePIXStatus ;
      private string Z962ChavePIXTipo ;
      private string A962ChavePIXTipo ;
      private string Z963ChavePIXConteudo ;
      private string A963ChavePIXConteudo ;
      private string Z958ChavePIXCreatedByName ;
      private string A958ChavePIXCreatedByName ;
      private string Z960ChavePIXUpdatedByName ;
      private string A960ChavePIXUpdatedByName ;
      private string Z969AgenciaBancoNome ;
      private string A969AgenciaBancoNome ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002Z12_A938AgenciaId ;
      private bool[] BC002Z12_n938AgenciaId ;
      private int[] BC002Z12_A968AgenciaBancoId ;
      private bool[] BC002Z12_n968AgenciaBancoId ;
      private int[] BC002Z12_A961ChavePIXId ;
      private DateTime[] BC002Z12_A966ChavePIXCreatedAt ;
      private bool[] BC002Z12_n966ChavePIXCreatedAt ;
      private DateTime[] BC002Z12_A967ChavePIXUpdatedAt ;
      private bool[] BC002Z12_n967ChavePIXUpdatedAt ;
      private string[] BC002Z12_A962ChavePIXTipo ;
      private bool[] BC002Z12_n962ChavePIXTipo ;
      private string[] BC002Z12_A963ChavePIXConteudo ;
      private bool[] BC002Z12_n963ChavePIXConteudo ;
      private bool[] BC002Z12_A964ChavePIXStatus ;
      private bool[] BC002Z12_n964ChavePIXStatus ;
      private bool[] BC002Z12_A965ChavePIXPrincipal ;
      private bool[] BC002Z12_n965ChavePIXPrincipal ;
      private long[] BC002Z12_A952ContaBancariaNumero ;
      private bool[] BC002Z12_n952ContaBancariaNumero ;
      private int[] BC002Z12_A939AgenciaNumero ;
      private bool[] BC002Z12_n939AgenciaNumero ;
      private string[] BC002Z12_A969AgenciaBancoNome ;
      private bool[] BC002Z12_n969AgenciaBancoNome ;
      private string[] BC002Z12_A958ChavePIXCreatedByName ;
      private bool[] BC002Z12_n958ChavePIXCreatedByName ;
      private string[] BC002Z12_A960ChavePIXUpdatedByName ;
      private bool[] BC002Z12_n960ChavePIXUpdatedByName ;
      private int[] BC002Z12_A951ContaBancariaId ;
      private bool[] BC002Z12_n951ContaBancariaId ;
      private short[] BC002Z12_A957ChavePIXCreatedBy ;
      private bool[] BC002Z12_n957ChavePIXCreatedBy ;
      private short[] BC002Z12_A959ChavePIXUpdatedBy ;
      private bool[] BC002Z12_n959ChavePIXUpdatedBy ;
      private short[] BC002Z12_A970ContaBancariaCountChavePIX_F ;
      private bool[] BC002Z12_n970ContaBancariaCountChavePIX_F ;
      private int[] BC002Z4_A938AgenciaId ;
      private bool[] BC002Z4_n938AgenciaId ;
      private long[] BC002Z4_A952ContaBancariaNumero ;
      private bool[] BC002Z4_n952ContaBancariaNumero ;
      private int[] BC002Z7_A968AgenciaBancoId ;
      private bool[] BC002Z7_n968AgenciaBancoId ;
      private int[] BC002Z7_A939AgenciaNumero ;
      private bool[] BC002Z7_n939AgenciaNumero ;
      private string[] BC002Z8_A969AgenciaBancoNome ;
      private bool[] BC002Z8_n969AgenciaBancoNome ;
      private short[] BC002Z10_A970ContaBancariaCountChavePIX_F ;
      private bool[] BC002Z10_n970ContaBancariaCountChavePIX_F ;
      private string[] BC002Z5_A958ChavePIXCreatedByName ;
      private bool[] BC002Z5_n958ChavePIXCreatedByName ;
      private string[] BC002Z6_A960ChavePIXUpdatedByName ;
      private bool[] BC002Z6_n960ChavePIXUpdatedByName ;
      private int[] BC002Z13_A961ChavePIXId ;
      private int[] BC002Z3_A961ChavePIXId ;
      private DateTime[] BC002Z3_A966ChavePIXCreatedAt ;
      private bool[] BC002Z3_n966ChavePIXCreatedAt ;
      private DateTime[] BC002Z3_A967ChavePIXUpdatedAt ;
      private bool[] BC002Z3_n967ChavePIXUpdatedAt ;
      private string[] BC002Z3_A962ChavePIXTipo ;
      private bool[] BC002Z3_n962ChavePIXTipo ;
      private string[] BC002Z3_A963ChavePIXConteudo ;
      private bool[] BC002Z3_n963ChavePIXConteudo ;
      private bool[] BC002Z3_A964ChavePIXStatus ;
      private bool[] BC002Z3_n964ChavePIXStatus ;
      private bool[] BC002Z3_A965ChavePIXPrincipal ;
      private bool[] BC002Z3_n965ChavePIXPrincipal ;
      private int[] BC002Z3_A951ContaBancariaId ;
      private bool[] BC002Z3_n951ContaBancariaId ;
      private short[] BC002Z3_A957ChavePIXCreatedBy ;
      private bool[] BC002Z3_n957ChavePIXCreatedBy ;
      private short[] BC002Z3_A959ChavePIXUpdatedBy ;
      private bool[] BC002Z3_n959ChavePIXUpdatedBy ;
      private int[] BC002Z2_A961ChavePIXId ;
      private DateTime[] BC002Z2_A966ChavePIXCreatedAt ;
      private bool[] BC002Z2_n966ChavePIXCreatedAt ;
      private DateTime[] BC002Z2_A967ChavePIXUpdatedAt ;
      private bool[] BC002Z2_n967ChavePIXUpdatedAt ;
      private string[] BC002Z2_A962ChavePIXTipo ;
      private bool[] BC002Z2_n962ChavePIXTipo ;
      private string[] BC002Z2_A963ChavePIXConteudo ;
      private bool[] BC002Z2_n963ChavePIXConteudo ;
      private bool[] BC002Z2_A964ChavePIXStatus ;
      private bool[] BC002Z2_n964ChavePIXStatus ;
      private bool[] BC002Z2_A965ChavePIXPrincipal ;
      private bool[] BC002Z2_n965ChavePIXPrincipal ;
      private int[] BC002Z2_A951ContaBancariaId ;
      private bool[] BC002Z2_n951ContaBancariaId ;
      private short[] BC002Z2_A957ChavePIXCreatedBy ;
      private bool[] BC002Z2_n957ChavePIXCreatedBy ;
      private short[] BC002Z2_A959ChavePIXUpdatedBy ;
      private bool[] BC002Z2_n959ChavePIXUpdatedBy ;
      private int[] BC002Z15_A961ChavePIXId ;
      private int[] BC002Z18_A938AgenciaId ;
      private bool[] BC002Z18_n938AgenciaId ;
      private long[] BC002Z18_A952ContaBancariaNumero ;
      private bool[] BC002Z18_n952ContaBancariaNumero ;
      private int[] BC002Z19_A968AgenciaBancoId ;
      private bool[] BC002Z19_n968AgenciaBancoId ;
      private int[] BC002Z19_A939AgenciaNumero ;
      private bool[] BC002Z19_n939AgenciaNumero ;
      private string[] BC002Z20_A969AgenciaBancoNome ;
      private bool[] BC002Z20_n969AgenciaBancoNome ;
      private short[] BC002Z22_A970ContaBancariaCountChavePIX_F ;
      private bool[] BC002Z22_n970ContaBancariaCountChavePIX_F ;
      private string[] BC002Z23_A958ChavePIXCreatedByName ;
      private bool[] BC002Z23_n958ChavePIXCreatedByName ;
      private string[] BC002Z24_A960ChavePIXUpdatedByName ;
      private bool[] BC002Z24_n960ChavePIXUpdatedByName ;
      private int[] BC002Z26_A938AgenciaId ;
      private bool[] BC002Z26_n938AgenciaId ;
      private int[] BC002Z26_A968AgenciaBancoId ;
      private bool[] BC002Z26_n968AgenciaBancoId ;
      private int[] BC002Z26_A961ChavePIXId ;
      private DateTime[] BC002Z26_A966ChavePIXCreatedAt ;
      private bool[] BC002Z26_n966ChavePIXCreatedAt ;
      private DateTime[] BC002Z26_A967ChavePIXUpdatedAt ;
      private bool[] BC002Z26_n967ChavePIXUpdatedAt ;
      private string[] BC002Z26_A962ChavePIXTipo ;
      private bool[] BC002Z26_n962ChavePIXTipo ;
      private string[] BC002Z26_A963ChavePIXConteudo ;
      private bool[] BC002Z26_n963ChavePIXConteudo ;
      private bool[] BC002Z26_A964ChavePIXStatus ;
      private bool[] BC002Z26_n964ChavePIXStatus ;
      private bool[] BC002Z26_A965ChavePIXPrincipal ;
      private bool[] BC002Z26_n965ChavePIXPrincipal ;
      private long[] BC002Z26_A952ContaBancariaNumero ;
      private bool[] BC002Z26_n952ContaBancariaNumero ;
      private int[] BC002Z26_A939AgenciaNumero ;
      private bool[] BC002Z26_n939AgenciaNumero ;
      private string[] BC002Z26_A969AgenciaBancoNome ;
      private bool[] BC002Z26_n969AgenciaBancoNome ;
      private string[] BC002Z26_A958ChavePIXCreatedByName ;
      private bool[] BC002Z26_n958ChavePIXCreatedByName ;
      private string[] BC002Z26_A960ChavePIXUpdatedByName ;
      private bool[] BC002Z26_n960ChavePIXUpdatedByName ;
      private int[] BC002Z26_A951ContaBancariaId ;
      private bool[] BC002Z26_n951ContaBancariaId ;
      private short[] BC002Z26_A957ChavePIXCreatedBy ;
      private bool[] BC002Z26_n957ChavePIXCreatedBy ;
      private short[] BC002Z26_A959ChavePIXUpdatedBy ;
      private bool[] BC002Z26_n959ChavePIXUpdatedBy ;
      private short[] BC002Z26_A970ContaBancariaCountChavePIX_F ;
      private bool[] BC002Z26_n970ContaBancariaCountChavePIX_F ;
      private SdtChavePIX bcChavePIX ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class chavepix_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002Z2;
          prmBC002Z2 = new Object[] {
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmBC002Z3;
          prmBC002Z3 = new Object[] {
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmBC002Z4;
          prmBC002Z4 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Z5;
          prmBC002Z5 = new Object[] {
          new ParDef("ChavePIXCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Z6;
          prmBC002Z6 = new Object[] {
          new ParDef("ChavePIXUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Z7;
          prmBC002Z7 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Z8;
          prmBC002Z8 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Z10;
          prmBC002Z10 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Z12;
          prmBC002Z12 = new Object[] {
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmBC002Z13;
          prmBC002Z13 = new Object[] {
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmBC002Z14;
          prmBC002Z14 = new Object[] {
          new ParDef("ChavePIXCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ChavePIXUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ChavePIXTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ChavePIXConteudo",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ChavePIXStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ChavePIXPrincipal",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ChavePIXCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ChavePIXUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Z15;
          prmBC002Z15 = new Object[] {
          };
          Object[] prmBC002Z16;
          prmBC002Z16 = new Object[] {
          new ParDef("ChavePIXCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ChavePIXUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ChavePIXTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("ChavePIXConteudo",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("ChavePIXStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ChavePIXPrincipal",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ChavePIXCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ChavePIXUpdatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmBC002Z17;
          prmBC002Z17 = new Object[] {
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          Object[] prmBC002Z18;
          prmBC002Z18 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Z19;
          prmBC002Z19 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Z20;
          prmBC002Z20 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Z22;
          prmBC002Z22 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Z23;
          prmBC002Z23 = new Object[] {
          new ParDef("ChavePIXCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Z24;
          prmBC002Z24 = new Object[] {
          new ParDef("ChavePIXUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Z26;
          prmBC002Z26 = new Object[] {
          new ParDef("ChavePIXId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002Z2", "SELECT ChavePIXId, ChavePIXCreatedAt, ChavePIXUpdatedAt, ChavePIXTipo, ChavePIXConteudo, ChavePIXStatus, ChavePIXPrincipal, ContaBancariaId, ChavePIXCreatedBy, ChavePIXUpdatedBy FROM ChavePIX WHERE ChavePIXId = :ChavePIXId  FOR UPDATE OF ChavePIX",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z3", "SELECT ChavePIXId, ChavePIXCreatedAt, ChavePIXUpdatedAt, ChavePIXTipo, ChavePIXConteudo, ChavePIXStatus, ChavePIXPrincipal, ContaBancariaId, ChavePIXCreatedBy, ChavePIXUpdatedBy FROM ChavePIX WHERE ChavePIXId = :ChavePIXId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z4", "SELECT AgenciaId, ContaBancariaNumero FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z5", "SELECT SecUserName AS ChavePIXCreatedByName FROM SecUser WHERE SecUserId = :ChavePIXCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z6", "SELECT SecUserName AS ChavePIXUpdatedByName FROM SecUser WHERE SecUserId = :ChavePIXUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z7", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z8", "SELECT BancoNome AS AgenciaBancoNome FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z10", "SELECT COALESCE( T1.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, ContaBancariaId FROM ChavePIX GROUP BY ContaBancariaId ) T1 WHERE T1.ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z12", "SELECT T2.AgenciaId, T3.AgenciaBancoId AS AgenciaBancoId, TM1.ChavePIXId, TM1.ChavePIXCreatedAt, TM1.ChavePIXUpdatedAt, TM1.ChavePIXTipo, TM1.ChavePIXConteudo, TM1.ChavePIXStatus, TM1.ChavePIXPrincipal, T2.ContaBancariaNumero, T3.AgenciaNumero, T4.BancoNome AS AgenciaBancoNome, T6.SecUserName AS ChavePIXCreatedByName, T7.SecUserName AS ChavePIXUpdatedByName, TM1.ContaBancariaId, TM1.ChavePIXCreatedBy AS ChavePIXCreatedBy, TM1.ChavePIXUpdatedBy AS ChavePIXUpdatedBy, COALESCE( T5.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM ((((((ChavePIX TM1 LEFT JOIN ContaBancaria T2 ON T2.ContaBancariaId = TM1.ContaBancariaId) LEFT JOIN Agencia T3 ON T3.AgenciaId = T2.AgenciaId) LEFT JOIN Banco T4 ON T4.BancoId = T3.AgenciaBancoId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, TM1.ContaBancariaId FROM ChavePIX TM1 WHERE TM1.ContaBancariaId = TM1.ContaBancariaId GROUP BY TM1.ContaBancariaId ) T5 ON T5.ContaBancariaId = TM1.ContaBancariaId) LEFT JOIN SecUser T6 ON T6.SecUserId = TM1.ChavePIXCreatedBy) LEFT JOIN SecUser T7 ON T7.SecUserId = TM1.ChavePIXUpdatedBy) WHERE TM1.ChavePIXId = :ChavePIXId ORDER BY TM1.ChavePIXId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z13", "SELECT ChavePIXId FROM ChavePIX WHERE ChavePIXId = :ChavePIXId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z14", "SAVEPOINT gxupdate;INSERT INTO ChavePIX(ChavePIXCreatedAt, ChavePIXUpdatedAt, ChavePIXTipo, ChavePIXConteudo, ChavePIXStatus, ChavePIXPrincipal, ContaBancariaId, ChavePIXCreatedBy, ChavePIXUpdatedBy) VALUES(:ChavePIXCreatedAt, :ChavePIXUpdatedAt, :ChavePIXTipo, :ChavePIXConteudo, :ChavePIXStatus, :ChavePIXPrincipal, :ContaBancariaId, :ChavePIXCreatedBy, :ChavePIXUpdatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002Z14)
             ,new CursorDef("BC002Z15", "SELECT currval('ChavePIXId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z16", "SAVEPOINT gxupdate;UPDATE ChavePIX SET ChavePIXCreatedAt=:ChavePIXCreatedAt, ChavePIXUpdatedAt=:ChavePIXUpdatedAt, ChavePIXTipo=:ChavePIXTipo, ChavePIXConteudo=:ChavePIXConteudo, ChavePIXStatus=:ChavePIXStatus, ChavePIXPrincipal=:ChavePIXPrincipal, ContaBancariaId=:ContaBancariaId, ChavePIXCreatedBy=:ChavePIXCreatedBy, ChavePIXUpdatedBy=:ChavePIXUpdatedBy  WHERE ChavePIXId = :ChavePIXId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002Z16)
             ,new CursorDef("BC002Z17", "SAVEPOINT gxupdate;DELETE FROM ChavePIX  WHERE ChavePIXId = :ChavePIXId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002Z17)
             ,new CursorDef("BC002Z18", "SELECT AgenciaId, ContaBancariaNumero FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z19", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z20", "SELECT BancoNome AS AgenciaBancoNome FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z22", "SELECT COALESCE( T1.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, ContaBancariaId FROM ChavePIX GROUP BY ContaBancariaId ) T1 WHERE T1.ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z23", "SELECT SecUserName AS ChavePIXCreatedByName FROM SecUser WHERE SecUserId = :ChavePIXCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z23,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z24", "SELECT SecUserName AS ChavePIXUpdatedByName FROM SecUser WHERE SecUserId = :ChavePIXUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z24,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Z26", "SELECT T2.AgenciaId, T3.AgenciaBancoId AS AgenciaBancoId, TM1.ChavePIXId, TM1.ChavePIXCreatedAt, TM1.ChavePIXUpdatedAt, TM1.ChavePIXTipo, TM1.ChavePIXConteudo, TM1.ChavePIXStatus, TM1.ChavePIXPrincipal, T2.ContaBancariaNumero, T3.AgenciaNumero, T4.BancoNome AS AgenciaBancoNome, T6.SecUserName AS ChavePIXCreatedByName, T7.SecUserName AS ChavePIXUpdatedByName, TM1.ContaBancariaId, TM1.ChavePIXCreatedBy AS ChavePIXCreatedBy, TM1.ChavePIXUpdatedBy AS ChavePIXUpdatedBy, COALESCE( T5.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM ((((((ChavePIX TM1 LEFT JOIN ContaBancaria T2 ON T2.ContaBancariaId = TM1.ContaBancariaId) LEFT JOIN Agencia T3 ON T3.AgenciaId = T2.AgenciaId) LEFT JOIN Banco T4 ON T4.BancoId = T3.AgenciaBancoId) LEFT JOIN LATERAL (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, TM1.ContaBancariaId FROM ChavePIX TM1 WHERE TM1.ContaBancariaId = TM1.ContaBancariaId GROUP BY TM1.ContaBancariaId ) T5 ON T5.ContaBancariaId = TM1.ContaBancariaId) LEFT JOIN SecUser T6 ON T6.SecUserId = TM1.ChavePIXCreatedBy) LEFT JOIN SecUser T7 ON T7.SecUserId = TM1.ChavePIXUpdatedBy) WHERE TM1.ChavePIXId = :ChavePIXId ORDER BY TM1.ChavePIXId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Z26,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((long[]) buf[17])[0] = rslt.getLong(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((int[]) buf[27])[0] = rslt.getInt(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((short[]) buf[33])[0] = rslt.getShort(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                return;
             case 9 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((bool[]) buf[15])[0] = rslt.getBool(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((long[]) buf[17])[0] = rslt.getLong(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((string[]) buf[23])[0] = rslt.getVarchar(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((string[]) buf[25])[0] = rslt.getVarchar(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((int[]) buf[27])[0] = rslt.getInt(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((short[]) buf[29])[0] = rslt.getShort(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((short[]) buf[31])[0] = rslt.getShort(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((short[]) buf[33])[0] = rslt.getShort(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                return;
       }
    }

 }

}
