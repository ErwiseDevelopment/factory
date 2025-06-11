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
   public class contabancaria_bc : GxSilentTrn, IGxSilentTrn
   {
      public contabancaria_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contabancaria_bc( IGxContext context )
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
         ReadRow2Y102( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2Y102( ) ;
         standaloneModal( ) ;
         AddRow2Y102( ) ;
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
            E112Y2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z951ContaBancariaId = A951ContaBancariaId;
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

      protected void CONFIRM_2Y0( )
      {
         BeforeValidate2Y102( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2Y102( ) ;
            }
            else
            {
               CheckExtendedTable2Y102( ) ;
               if ( AnyError == 0 )
               {
                  ZM2Y102( 9) ;
                  ZM2Y102( 10) ;
                  ZM2Y102( 11) ;
                  ZM2Y102( 12) ;
                  ZM2Y102( 13) ;
               }
               CloseExtendedTableCursors2Y102( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV28Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV29GXV1 = 1;
            while ( AV29GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV29GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "AgenciaId") == 0 )
               {
                  AV11Insert_AgenciaId = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ContaBancariaCreatedBy") == 0 )
               {
                  AV12Insert_ContaBancariaCreatedBy = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "ContaBancariaUpdatedBy") == 0 )
               {
                  AV13Insert_ContaBancariaUpdatedBy = (short)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV29GXV1 = (int)(AV29GXV1+1);
            }
         }
      }

      protected void E112Y2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2Y102( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z954ContaBancariaCreatedAt = A954ContaBancariaCreatedAt;
            Z955ContaBancariaUpdatedAt = A955ContaBancariaUpdatedAt;
            Z952ContaBancariaNumero = A952ContaBancariaNumero;
            Z975ContaBancariaDigito = A975ContaBancariaDigito;
            Z953ContaBancariaCarteira = A953ContaBancariaCarteira;
            Z956ContaBancariaStatus = A956ContaBancariaStatus;
            Z973ContaBancariaRegistraBoletos = A973ContaBancariaRegistraBoletos;
            Z938AgenciaId = A938AgenciaId;
            Z947ContaBancariaCreatedBy = A947ContaBancariaCreatedBy;
            Z949ContaBancariaUpdatedBy = A949ContaBancariaUpdatedBy;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
            Z976ContaBancariaDescricao_F = A976ContaBancariaDescricao_F;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z968AgenciaBancoId = A968AgenciaBancoId;
            Z939AgenciaNumero = A939AgenciaNumero;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
            Z976ContaBancariaDescricao_F = A976ContaBancariaDescricao_F;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z948ContaBancariaCreatedByName = A948ContaBancariaCreatedByName;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
            Z976ContaBancariaDescricao_F = A976ContaBancariaDescricao_F;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z950ContaBancariaUpdatedByName = A950ContaBancariaUpdatedByName;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
            Z976ContaBancariaDescricao_F = A976ContaBancariaDescricao_F;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z969AgenciaBancoNome = A969AgenciaBancoNome;
            Z974AgenciaBancoCodigo = A974AgenciaBancoCodigo;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
            Z976ContaBancariaDescricao_F = A976ContaBancariaDescricao_F;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
            Z976ContaBancariaDescricao_F = A976ContaBancariaDescricao_F;
         }
         if ( GX_JID == -8 )
         {
            Z951ContaBancariaId = A951ContaBancariaId;
            Z954ContaBancariaCreatedAt = A954ContaBancariaCreatedAt;
            Z955ContaBancariaUpdatedAt = A955ContaBancariaUpdatedAt;
            Z952ContaBancariaNumero = A952ContaBancariaNumero;
            Z975ContaBancariaDigito = A975ContaBancariaDigito;
            Z953ContaBancariaCarteira = A953ContaBancariaCarteira;
            Z956ContaBancariaStatus = A956ContaBancariaStatus;
            Z973ContaBancariaRegistraBoletos = A973ContaBancariaRegistraBoletos;
            Z938AgenciaId = A938AgenciaId;
            Z947ContaBancariaCreatedBy = A947ContaBancariaCreatedBy;
            Z949ContaBancariaUpdatedBy = A949ContaBancariaUpdatedBy;
            Z970ContaBancariaCountChavePIX_F = A970ContaBancariaCountChavePIX_F;
            Z968AgenciaBancoId = A968AgenciaBancoId;
            Z939AgenciaNumero = A939AgenciaNumero;
            Z969AgenciaBancoNome = A969AgenciaBancoNome;
            Z974AgenciaBancoCodigo = A974AgenciaBancoCodigo;
            Z948ContaBancariaCreatedByName = A948ContaBancariaCreatedByName;
            Z950ContaBancariaUpdatedByName = A950ContaBancariaUpdatedByName;
         }
      }

      protected void standaloneNotModal( )
      {
         AV28Pgmname = "ContaBancaria_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A954ContaBancariaCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n954ContaBancariaCreatedAt = false;
         }
         if ( IsUpd( )  )
         {
            A955ContaBancariaUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n955ContaBancariaUpdatedAt = false;
         }
         if ( IsIns( )  && (false==A956ContaBancariaStatus) && ( Gx_BScreen == 0 ) )
         {
            A956ContaBancariaStatus = true;
            n956ContaBancariaStatus = false;
         }
      }

      protected void Load2Y102( )
      {
         /* Using cursor BC002Y11 */
         pr_default.execute(7, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound102 = 1;
            A968AgenciaBancoId = BC002Y11_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC002Y11_n968AgenciaBancoId[0];
            A954ContaBancariaCreatedAt = BC002Y11_A954ContaBancariaCreatedAt[0];
            n954ContaBancariaCreatedAt = BC002Y11_n954ContaBancariaCreatedAt[0];
            A955ContaBancariaUpdatedAt = BC002Y11_A955ContaBancariaUpdatedAt[0];
            n955ContaBancariaUpdatedAt = BC002Y11_n955ContaBancariaUpdatedAt[0];
            A939AgenciaNumero = BC002Y11_A939AgenciaNumero[0];
            n939AgenciaNumero = BC002Y11_n939AgenciaNumero[0];
            A969AgenciaBancoNome = BC002Y11_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC002Y11_n969AgenciaBancoNome[0];
            A952ContaBancariaNumero = BC002Y11_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = BC002Y11_n952ContaBancariaNumero[0];
            A975ContaBancariaDigito = BC002Y11_A975ContaBancariaDigito[0];
            n975ContaBancariaDigito = BC002Y11_n975ContaBancariaDigito[0];
            A953ContaBancariaCarteira = BC002Y11_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = BC002Y11_n953ContaBancariaCarteira[0];
            A956ContaBancariaStatus = BC002Y11_A956ContaBancariaStatus[0];
            n956ContaBancariaStatus = BC002Y11_n956ContaBancariaStatus[0];
            A948ContaBancariaCreatedByName = BC002Y11_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = BC002Y11_n948ContaBancariaCreatedByName[0];
            A950ContaBancariaUpdatedByName = BC002Y11_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = BC002Y11_n950ContaBancariaUpdatedByName[0];
            A973ContaBancariaRegistraBoletos = BC002Y11_A973ContaBancariaRegistraBoletos[0];
            n973ContaBancariaRegistraBoletos = BC002Y11_n973ContaBancariaRegistraBoletos[0];
            A974AgenciaBancoCodigo = BC002Y11_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = BC002Y11_n974AgenciaBancoCodigo[0];
            A938AgenciaId = BC002Y11_A938AgenciaId[0];
            n938AgenciaId = BC002Y11_n938AgenciaId[0];
            A947ContaBancariaCreatedBy = BC002Y11_A947ContaBancariaCreatedBy[0];
            n947ContaBancariaCreatedBy = BC002Y11_n947ContaBancariaCreatedBy[0];
            A949ContaBancariaUpdatedBy = BC002Y11_A949ContaBancariaUpdatedBy[0];
            n949ContaBancariaUpdatedBy = BC002Y11_n949ContaBancariaUpdatedBy[0];
            A970ContaBancariaCountChavePIX_F = BC002Y11_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = BC002Y11_n970ContaBancariaCountChavePIX_F[0];
            ZM2Y102( -8) ;
         }
         pr_default.close(7);
         OnLoadActions2Y102( ) ;
      }

      protected void OnLoadActions2Y102( )
      {
         A976ContaBancariaDescricao_F = StringUtil.Format( "%1 - %2 Ag %3 Cc %4-%5", StringUtil.LTrimStr( (decimal)(A974AgenciaBancoCodigo), 9, 0), A969AgenciaBancoNome, StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0), StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0), StringUtil.LTrimStr( (decimal)(A975ContaBancariaDigito), 4, 0), "", "", "", "");
      }

      protected void CheckExtendedTable2Y102( )
      {
         standaloneModal( ) ;
         /* Using cursor BC002Y9 */
         pr_default.execute(6, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A970ContaBancariaCountChavePIX_F = BC002Y9_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = BC002Y9_n970ContaBancariaCountChavePIX_F[0];
         }
         else
         {
            A970ContaBancariaCountChavePIX_F = 0;
            n970ContaBancariaCountChavePIX_F = false;
         }
         pr_default.close(6);
         /* Using cursor BC002Y4 */
         pr_default.execute(2, new Object[] {n938AgenciaId, A938AgenciaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A938AgenciaId) ) )
            {
               GX_msglist.addItem("Não existe 'Agencia'.", "ForeignKeyNotFound", 1, "AGENCIAID");
               AnyError = 1;
            }
         }
         A968AgenciaBancoId = BC002Y4_A968AgenciaBancoId[0];
         n968AgenciaBancoId = BC002Y4_n968AgenciaBancoId[0];
         A939AgenciaNumero = BC002Y4_A939AgenciaNumero[0];
         n939AgenciaNumero = BC002Y4_n939AgenciaNumero[0];
         pr_default.close(2);
         /* Using cursor BC002Y7 */
         pr_default.execute(5, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A968AgenciaBancoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Agencia Banco Id'.", "ForeignKeyNotFound", 1, "AGENCIABANCOID");
               AnyError = 1;
            }
         }
         A969AgenciaBancoNome = BC002Y7_A969AgenciaBancoNome[0];
         n969AgenciaBancoNome = BC002Y7_n969AgenciaBancoNome[0];
         A974AgenciaBancoCodigo = BC002Y7_A974AgenciaBancoCodigo[0];
         n974AgenciaBancoCodigo = BC002Y7_n974AgenciaBancoCodigo[0];
         pr_default.close(5);
         A976ContaBancariaDescricao_F = StringUtil.Format( "%1 - %2 Ag %3 Cc %4-%5", StringUtil.LTrimStr( (decimal)(A974AgenciaBancoCodigo), 9, 0), A969AgenciaBancoNome, StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0), StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0), StringUtil.LTrimStr( (decimal)(A975ContaBancariaDigito), 4, 0), "", "", "", "");
         /* Using cursor BC002Y5 */
         pr_default.execute(3, new Object[] {n947ContaBancariaCreatedBy, A947ContaBancariaCreatedBy});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A947ContaBancariaCreatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Conta Bancaria Created By'.", "ForeignKeyNotFound", 1, "CONTABANCARIACREATEDBY");
               AnyError = 1;
            }
         }
         A948ContaBancariaCreatedByName = BC002Y5_A948ContaBancariaCreatedByName[0];
         n948ContaBancariaCreatedByName = BC002Y5_n948ContaBancariaCreatedByName[0];
         pr_default.close(3);
         /* Using cursor BC002Y6 */
         pr_default.execute(4, new Object[] {n949ContaBancariaUpdatedBy, A949ContaBancariaUpdatedBy});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A949ContaBancariaUpdatedBy) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Conta Bancaria Updated By'.", "ForeignKeyNotFound", 1, "CONTABANCARIAUPDATEDBY");
               AnyError = 1;
            }
         }
         A950ContaBancariaUpdatedByName = BC002Y6_A950ContaBancariaUpdatedByName[0];
         n950ContaBancariaUpdatedByName = BC002Y6_n950ContaBancariaUpdatedByName[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors2Y102( )
      {
         pr_default.close(6);
         pr_default.close(2);
         pr_default.close(5);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2Y102( )
      {
         /* Using cursor BC002Y12 */
         pr_default.execute(8, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound102 = 1;
         }
         else
         {
            RcdFound102 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002Y3 */
         pr_default.execute(1, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2Y102( 8) ;
            RcdFound102 = 1;
            A951ContaBancariaId = BC002Y3_A951ContaBancariaId[0];
            n951ContaBancariaId = BC002Y3_n951ContaBancariaId[0];
            A954ContaBancariaCreatedAt = BC002Y3_A954ContaBancariaCreatedAt[0];
            n954ContaBancariaCreatedAt = BC002Y3_n954ContaBancariaCreatedAt[0];
            A955ContaBancariaUpdatedAt = BC002Y3_A955ContaBancariaUpdatedAt[0];
            n955ContaBancariaUpdatedAt = BC002Y3_n955ContaBancariaUpdatedAt[0];
            A952ContaBancariaNumero = BC002Y3_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = BC002Y3_n952ContaBancariaNumero[0];
            A975ContaBancariaDigito = BC002Y3_A975ContaBancariaDigito[0];
            n975ContaBancariaDigito = BC002Y3_n975ContaBancariaDigito[0];
            A953ContaBancariaCarteira = BC002Y3_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = BC002Y3_n953ContaBancariaCarteira[0];
            A956ContaBancariaStatus = BC002Y3_A956ContaBancariaStatus[0];
            n956ContaBancariaStatus = BC002Y3_n956ContaBancariaStatus[0];
            A973ContaBancariaRegistraBoletos = BC002Y3_A973ContaBancariaRegistraBoletos[0];
            n973ContaBancariaRegistraBoletos = BC002Y3_n973ContaBancariaRegistraBoletos[0];
            A938AgenciaId = BC002Y3_A938AgenciaId[0];
            n938AgenciaId = BC002Y3_n938AgenciaId[0];
            A947ContaBancariaCreatedBy = BC002Y3_A947ContaBancariaCreatedBy[0];
            n947ContaBancariaCreatedBy = BC002Y3_n947ContaBancariaCreatedBy[0];
            A949ContaBancariaUpdatedBy = BC002Y3_A949ContaBancariaUpdatedBy[0];
            n949ContaBancariaUpdatedBy = BC002Y3_n949ContaBancariaUpdatedBy[0];
            Z951ContaBancariaId = A951ContaBancariaId;
            sMode102 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2Y102( ) ;
            if ( AnyError == 1 )
            {
               RcdFound102 = 0;
               InitializeNonKey2Y102( ) ;
            }
            Gx_mode = sMode102;
         }
         else
         {
            RcdFound102 = 0;
            InitializeNonKey2Y102( ) ;
            sMode102 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode102;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2Y102( ) ;
         if ( RcdFound102 == 0 )
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
         CONFIRM_2Y0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2Y102( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002Y2 */
            pr_default.execute(0, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ContaBancaria"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z954ContaBancariaCreatedAt != BC002Y2_A954ContaBancariaCreatedAt[0] ) || ( Z955ContaBancariaUpdatedAt != BC002Y2_A955ContaBancariaUpdatedAt[0] ) || ( Z952ContaBancariaNumero != BC002Y2_A952ContaBancariaNumero[0] ) || ( Z975ContaBancariaDigito != BC002Y2_A975ContaBancariaDigito[0] ) || ( Z953ContaBancariaCarteira != BC002Y2_A953ContaBancariaCarteira[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z956ContaBancariaStatus != BC002Y2_A956ContaBancariaStatus[0] ) || ( Z973ContaBancariaRegistraBoletos != BC002Y2_A973ContaBancariaRegistraBoletos[0] ) || ( Z938AgenciaId != BC002Y2_A938AgenciaId[0] ) || ( Z947ContaBancariaCreatedBy != BC002Y2_A947ContaBancariaCreatedBy[0] ) || ( Z949ContaBancariaUpdatedBy != BC002Y2_A949ContaBancariaUpdatedBy[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ContaBancaria"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2Y102( )
      {
         BeforeValidate2Y102( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Y102( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2Y102( 0) ;
            CheckOptimisticConcurrency2Y102( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Y102( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2Y102( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002Y13 */
                     pr_default.execute(9, new Object[] {n954ContaBancariaCreatedAt, A954ContaBancariaCreatedAt, n955ContaBancariaUpdatedAt, A955ContaBancariaUpdatedAt, n952ContaBancariaNumero, A952ContaBancariaNumero, n975ContaBancariaDigito, A975ContaBancariaDigito, n953ContaBancariaCarteira, A953ContaBancariaCarteira, n956ContaBancariaStatus, A956ContaBancariaStatus, n973ContaBancariaRegistraBoletos, A973ContaBancariaRegistraBoletos, n938AgenciaId, A938AgenciaId, n947ContaBancariaCreatedBy, A947ContaBancariaCreatedBy, n949ContaBancariaUpdatedBy, A949ContaBancariaUpdatedBy});
                     pr_default.close(9);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC002Y14 */
                     pr_default.execute(10);
                     A951ContaBancariaId = BC002Y14_A951ContaBancariaId[0];
                     n951ContaBancariaId = BC002Y14_n951ContaBancariaId[0];
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("ContaBancaria");
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
               Load2Y102( ) ;
            }
            EndLevel2Y102( ) ;
         }
         CloseExtendedTableCursors2Y102( ) ;
      }

      protected void Update2Y102( )
      {
         BeforeValidate2Y102( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2Y102( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Y102( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2Y102( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2Y102( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002Y15 */
                     pr_default.execute(11, new Object[] {n954ContaBancariaCreatedAt, A954ContaBancariaCreatedAt, n955ContaBancariaUpdatedAt, A955ContaBancariaUpdatedAt, n952ContaBancariaNumero, A952ContaBancariaNumero, n975ContaBancariaDigito, A975ContaBancariaDigito, n953ContaBancariaCarteira, A953ContaBancariaCarteira, n956ContaBancariaStatus, A956ContaBancariaStatus, n973ContaBancariaRegistraBoletos, A973ContaBancariaRegistraBoletos, n938AgenciaId, A938AgenciaId, n947ContaBancariaCreatedBy, A947ContaBancariaCreatedBy, n949ContaBancariaUpdatedBy, A949ContaBancariaUpdatedBy, n951ContaBancariaId, A951ContaBancariaId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("ContaBancaria");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ContaBancaria"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2Y102( ) ;
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
            EndLevel2Y102( ) ;
         }
         CloseExtendedTableCursors2Y102( ) ;
      }

      protected void DeferredUpdate2Y102( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2Y102( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2Y102( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2Y102( ) ;
            AfterConfirm2Y102( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2Y102( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002Y16 */
                  pr_default.execute(12, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("ContaBancaria");
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
         sMode102 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2Y102( ) ;
         Gx_mode = sMode102;
      }

      protected void OnDeleteControls2Y102( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC002Y18 */
            pr_default.execute(13, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               A970ContaBancariaCountChavePIX_F = BC002Y18_A970ContaBancariaCountChavePIX_F[0];
               n970ContaBancariaCountChavePIX_F = BC002Y18_n970ContaBancariaCountChavePIX_F[0];
            }
            else
            {
               A970ContaBancariaCountChavePIX_F = 0;
               n970ContaBancariaCountChavePIX_F = false;
            }
            pr_default.close(13);
            /* Using cursor BC002Y19 */
            pr_default.execute(14, new Object[] {n938AgenciaId, A938AgenciaId});
            A968AgenciaBancoId = BC002Y19_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC002Y19_n968AgenciaBancoId[0];
            A939AgenciaNumero = BC002Y19_A939AgenciaNumero[0];
            n939AgenciaNumero = BC002Y19_n939AgenciaNumero[0];
            pr_default.close(14);
            /* Using cursor BC002Y20 */
            pr_default.execute(15, new Object[] {n968AgenciaBancoId, A968AgenciaBancoId});
            A969AgenciaBancoNome = BC002Y20_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC002Y20_n969AgenciaBancoNome[0];
            A974AgenciaBancoCodigo = BC002Y20_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = BC002Y20_n974AgenciaBancoCodigo[0];
            pr_default.close(15);
            A976ContaBancariaDescricao_F = StringUtil.Format( "%1 - %2 Ag %3 Cc %4-%5", StringUtil.LTrimStr( (decimal)(A974AgenciaBancoCodigo), 9, 0), A969AgenciaBancoNome, StringUtil.LTrimStr( (decimal)(A939AgenciaNumero), 9, 0), StringUtil.LTrimStr( (decimal)(A952ContaBancariaNumero), 18, 0), StringUtil.LTrimStr( (decimal)(A975ContaBancariaDigito), 4, 0), "", "", "", "");
            /* Using cursor BC002Y21 */
            pr_default.execute(16, new Object[] {n947ContaBancariaCreatedBy, A947ContaBancariaCreatedBy});
            A948ContaBancariaCreatedByName = BC002Y21_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = BC002Y21_n948ContaBancariaCreatedByName[0];
            pr_default.close(16);
            /* Using cursor BC002Y22 */
            pr_default.execute(17, new Object[] {n949ContaBancariaUpdatedBy, A949ContaBancariaUpdatedBy});
            A950ContaBancariaUpdatedByName = BC002Y22_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = BC002Y22_n950ContaBancariaUpdatedByName[0];
            pr_default.close(17);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC002Y23 */
            pr_default.execute(18, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Chave PIX"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor BC002Y24 */
            pr_default.execute(19, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Titulo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel2Y102( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2Y102( ) ;
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

      public void ScanKeyStart2Y102( )
      {
         /* Scan By routine */
         /* Using cursor BC002Y26 */
         pr_default.execute(20, new Object[] {n951ContaBancariaId, A951ContaBancariaId});
         RcdFound102 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound102 = 1;
            A968AgenciaBancoId = BC002Y26_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC002Y26_n968AgenciaBancoId[0];
            A951ContaBancariaId = BC002Y26_A951ContaBancariaId[0];
            n951ContaBancariaId = BC002Y26_n951ContaBancariaId[0];
            A954ContaBancariaCreatedAt = BC002Y26_A954ContaBancariaCreatedAt[0];
            n954ContaBancariaCreatedAt = BC002Y26_n954ContaBancariaCreatedAt[0];
            A955ContaBancariaUpdatedAt = BC002Y26_A955ContaBancariaUpdatedAt[0];
            n955ContaBancariaUpdatedAt = BC002Y26_n955ContaBancariaUpdatedAt[0];
            A939AgenciaNumero = BC002Y26_A939AgenciaNumero[0];
            n939AgenciaNumero = BC002Y26_n939AgenciaNumero[0];
            A969AgenciaBancoNome = BC002Y26_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC002Y26_n969AgenciaBancoNome[0];
            A952ContaBancariaNumero = BC002Y26_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = BC002Y26_n952ContaBancariaNumero[0];
            A975ContaBancariaDigito = BC002Y26_A975ContaBancariaDigito[0];
            n975ContaBancariaDigito = BC002Y26_n975ContaBancariaDigito[0];
            A953ContaBancariaCarteira = BC002Y26_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = BC002Y26_n953ContaBancariaCarteira[0];
            A956ContaBancariaStatus = BC002Y26_A956ContaBancariaStatus[0];
            n956ContaBancariaStatus = BC002Y26_n956ContaBancariaStatus[0];
            A948ContaBancariaCreatedByName = BC002Y26_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = BC002Y26_n948ContaBancariaCreatedByName[0];
            A950ContaBancariaUpdatedByName = BC002Y26_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = BC002Y26_n950ContaBancariaUpdatedByName[0];
            A973ContaBancariaRegistraBoletos = BC002Y26_A973ContaBancariaRegistraBoletos[0];
            n973ContaBancariaRegistraBoletos = BC002Y26_n973ContaBancariaRegistraBoletos[0];
            A974AgenciaBancoCodigo = BC002Y26_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = BC002Y26_n974AgenciaBancoCodigo[0];
            A938AgenciaId = BC002Y26_A938AgenciaId[0];
            n938AgenciaId = BC002Y26_n938AgenciaId[0];
            A947ContaBancariaCreatedBy = BC002Y26_A947ContaBancariaCreatedBy[0];
            n947ContaBancariaCreatedBy = BC002Y26_n947ContaBancariaCreatedBy[0];
            A949ContaBancariaUpdatedBy = BC002Y26_A949ContaBancariaUpdatedBy[0];
            n949ContaBancariaUpdatedBy = BC002Y26_n949ContaBancariaUpdatedBy[0];
            A970ContaBancariaCountChavePIX_F = BC002Y26_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = BC002Y26_n970ContaBancariaCountChavePIX_F[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2Y102( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound102 = 0;
         ScanKeyLoad2Y102( ) ;
      }

      protected void ScanKeyLoad2Y102( )
      {
         sMode102 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound102 = 1;
            A968AgenciaBancoId = BC002Y26_A968AgenciaBancoId[0];
            n968AgenciaBancoId = BC002Y26_n968AgenciaBancoId[0];
            A951ContaBancariaId = BC002Y26_A951ContaBancariaId[0];
            n951ContaBancariaId = BC002Y26_n951ContaBancariaId[0];
            A954ContaBancariaCreatedAt = BC002Y26_A954ContaBancariaCreatedAt[0];
            n954ContaBancariaCreatedAt = BC002Y26_n954ContaBancariaCreatedAt[0];
            A955ContaBancariaUpdatedAt = BC002Y26_A955ContaBancariaUpdatedAt[0];
            n955ContaBancariaUpdatedAt = BC002Y26_n955ContaBancariaUpdatedAt[0];
            A939AgenciaNumero = BC002Y26_A939AgenciaNumero[0];
            n939AgenciaNumero = BC002Y26_n939AgenciaNumero[0];
            A969AgenciaBancoNome = BC002Y26_A969AgenciaBancoNome[0];
            n969AgenciaBancoNome = BC002Y26_n969AgenciaBancoNome[0];
            A952ContaBancariaNumero = BC002Y26_A952ContaBancariaNumero[0];
            n952ContaBancariaNumero = BC002Y26_n952ContaBancariaNumero[0];
            A975ContaBancariaDigito = BC002Y26_A975ContaBancariaDigito[0];
            n975ContaBancariaDigito = BC002Y26_n975ContaBancariaDigito[0];
            A953ContaBancariaCarteira = BC002Y26_A953ContaBancariaCarteira[0];
            n953ContaBancariaCarteira = BC002Y26_n953ContaBancariaCarteira[0];
            A956ContaBancariaStatus = BC002Y26_A956ContaBancariaStatus[0];
            n956ContaBancariaStatus = BC002Y26_n956ContaBancariaStatus[0];
            A948ContaBancariaCreatedByName = BC002Y26_A948ContaBancariaCreatedByName[0];
            n948ContaBancariaCreatedByName = BC002Y26_n948ContaBancariaCreatedByName[0];
            A950ContaBancariaUpdatedByName = BC002Y26_A950ContaBancariaUpdatedByName[0];
            n950ContaBancariaUpdatedByName = BC002Y26_n950ContaBancariaUpdatedByName[0];
            A973ContaBancariaRegistraBoletos = BC002Y26_A973ContaBancariaRegistraBoletos[0];
            n973ContaBancariaRegistraBoletos = BC002Y26_n973ContaBancariaRegistraBoletos[0];
            A974AgenciaBancoCodigo = BC002Y26_A974AgenciaBancoCodigo[0];
            n974AgenciaBancoCodigo = BC002Y26_n974AgenciaBancoCodigo[0];
            A938AgenciaId = BC002Y26_A938AgenciaId[0];
            n938AgenciaId = BC002Y26_n938AgenciaId[0];
            A947ContaBancariaCreatedBy = BC002Y26_A947ContaBancariaCreatedBy[0];
            n947ContaBancariaCreatedBy = BC002Y26_n947ContaBancariaCreatedBy[0];
            A949ContaBancariaUpdatedBy = BC002Y26_A949ContaBancariaUpdatedBy[0];
            n949ContaBancariaUpdatedBy = BC002Y26_n949ContaBancariaUpdatedBy[0];
            A970ContaBancariaCountChavePIX_F = BC002Y26_A970ContaBancariaCountChavePIX_F[0];
            n970ContaBancariaCountChavePIX_F = BC002Y26_n970ContaBancariaCountChavePIX_F[0];
         }
         Gx_mode = sMode102;
      }

      protected void ScanKeyEnd2Y102( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm2Y102( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2Y102( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2Y102( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2Y102( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2Y102( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2Y102( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2Y102( )
      {
      }

      protected void send_integrity_lvl_hashes2Y102( )
      {
      }

      protected void AddRow2Y102( )
      {
         VarsToRow102( bcContaBancaria) ;
      }

      protected void ReadRow2Y102( )
      {
         RowToVars102( bcContaBancaria, 1) ;
      }

      protected void InitializeNonKey2Y102( )
      {
         A968AgenciaBancoId = 0;
         n968AgenciaBancoId = false;
         A954ContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         n954ContaBancariaCreatedAt = false;
         A955ContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         n955ContaBancariaUpdatedAt = false;
         A976ContaBancariaDescricao_F = "";
         A938AgenciaId = 0;
         n938AgenciaId = false;
         A939AgenciaNumero = 0;
         n939AgenciaNumero = false;
         A969AgenciaBancoNome = "";
         n969AgenciaBancoNome = false;
         A952ContaBancariaNumero = 0;
         n952ContaBancariaNumero = false;
         A975ContaBancariaDigito = 0;
         n975ContaBancariaDigito = false;
         A970ContaBancariaCountChavePIX_F = 0;
         n970ContaBancariaCountChavePIX_F = false;
         A953ContaBancariaCarteira = 0;
         n953ContaBancariaCarteira = false;
         A947ContaBancariaCreatedBy = 0;
         n947ContaBancariaCreatedBy = false;
         A948ContaBancariaCreatedByName = "";
         n948ContaBancariaCreatedByName = false;
         A949ContaBancariaUpdatedBy = 0;
         n949ContaBancariaUpdatedBy = false;
         A950ContaBancariaUpdatedByName = "";
         n950ContaBancariaUpdatedByName = false;
         A973ContaBancariaRegistraBoletos = false;
         n973ContaBancariaRegistraBoletos = false;
         A974AgenciaBancoCodigo = 0;
         n974AgenciaBancoCodigo = false;
         A956ContaBancariaStatus = true;
         n956ContaBancariaStatus = false;
         Z954ContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         Z955ContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         Z952ContaBancariaNumero = 0;
         Z975ContaBancariaDigito = 0;
         Z953ContaBancariaCarteira = 0;
         Z956ContaBancariaStatus = false;
         Z973ContaBancariaRegistraBoletos = false;
         Z938AgenciaId = 0;
         Z947ContaBancariaCreatedBy = 0;
         Z949ContaBancariaUpdatedBy = 0;
      }

      protected void InitAll2Y102( )
      {
         A951ContaBancariaId = 0;
         n951ContaBancariaId = false;
         InitializeNonKey2Y102( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A954ContaBancariaCreatedAt = i954ContaBancariaCreatedAt;
         n954ContaBancariaCreatedAt = false;
         A956ContaBancariaStatus = i956ContaBancariaStatus;
         n956ContaBancariaStatus = false;
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

      public void VarsToRow102( SdtContaBancaria obj102 )
      {
         obj102.gxTpr_Mode = Gx_mode;
         obj102.gxTpr_Contabancariacreatedat = A954ContaBancariaCreatedAt;
         obj102.gxTpr_Contabancariaupdatedat = A955ContaBancariaUpdatedAt;
         obj102.gxTpr_Contabancariadescricao_f = A976ContaBancariaDescricao_F;
         obj102.gxTpr_Agenciaid = A938AgenciaId;
         obj102.gxTpr_Agencianumero = A939AgenciaNumero;
         obj102.gxTpr_Agenciabanconome = A969AgenciaBancoNome;
         obj102.gxTpr_Contabancarianumero = A952ContaBancariaNumero;
         obj102.gxTpr_Contabancariadigito = A975ContaBancariaDigito;
         obj102.gxTpr_Contabancariacountchavepix_f = A970ContaBancariaCountChavePIX_F;
         obj102.gxTpr_Contabancariacarteira = A953ContaBancariaCarteira;
         obj102.gxTpr_Contabancariacreatedby = A947ContaBancariaCreatedBy;
         obj102.gxTpr_Contabancariacreatedbyname = A948ContaBancariaCreatedByName;
         obj102.gxTpr_Contabancariaupdatedby = A949ContaBancariaUpdatedBy;
         obj102.gxTpr_Contabancariaupdatedbyname = A950ContaBancariaUpdatedByName;
         obj102.gxTpr_Contabancariaregistraboletos = A973ContaBancariaRegistraBoletos;
         obj102.gxTpr_Contabancariastatus = A956ContaBancariaStatus;
         obj102.gxTpr_Contabancariaid = A951ContaBancariaId;
         obj102.gxTpr_Contabancariaid_Z = Z951ContaBancariaId;
         obj102.gxTpr_Agenciaid_Z = Z938AgenciaId;
         obj102.gxTpr_Agencianumero_Z = Z939AgenciaNumero;
         obj102.gxTpr_Agenciabanconome_Z = Z969AgenciaBancoNome;
         obj102.gxTpr_Contabancarianumero_Z = Z952ContaBancariaNumero;
         obj102.gxTpr_Contabancariadigito_Z = Z975ContaBancariaDigito;
         obj102.gxTpr_Contabancariacountchavepix_f_Z = Z970ContaBancariaCountChavePIX_F;
         obj102.gxTpr_Contabancariacarteira_Z = Z953ContaBancariaCarteira;
         obj102.gxTpr_Contabancariacreatedat_Z = Z954ContaBancariaCreatedAt;
         obj102.gxTpr_Contabancariastatus_Z = Z956ContaBancariaStatus;
         obj102.gxTpr_Contabancariacreatedby_Z = Z947ContaBancariaCreatedBy;
         obj102.gxTpr_Contabancariacreatedbyname_Z = Z948ContaBancariaCreatedByName;
         obj102.gxTpr_Contabancariaupdatedat_Z = Z955ContaBancariaUpdatedAt;
         obj102.gxTpr_Contabancariaupdatedby_Z = Z949ContaBancariaUpdatedBy;
         obj102.gxTpr_Contabancariaupdatedbyname_Z = Z950ContaBancariaUpdatedByName;
         obj102.gxTpr_Contabancariaregistraboletos_Z = Z973ContaBancariaRegistraBoletos;
         obj102.gxTpr_Contabancariadescricao_f_Z = Z976ContaBancariaDescricao_F;
         obj102.gxTpr_Contabancariaid_N = (short)(Convert.ToInt16(n951ContaBancariaId));
         obj102.gxTpr_Agenciaid_N = (short)(Convert.ToInt16(n938AgenciaId));
         obj102.gxTpr_Agencianumero_N = (short)(Convert.ToInt16(n939AgenciaNumero));
         obj102.gxTpr_Agenciabanconome_N = (short)(Convert.ToInt16(n969AgenciaBancoNome));
         obj102.gxTpr_Contabancarianumero_N = (short)(Convert.ToInt16(n952ContaBancariaNumero));
         obj102.gxTpr_Contabancariadigito_N = (short)(Convert.ToInt16(n975ContaBancariaDigito));
         obj102.gxTpr_Contabancariacountchavepix_f_N = (short)(Convert.ToInt16(n970ContaBancariaCountChavePIX_F));
         obj102.gxTpr_Contabancariacarteira_N = (short)(Convert.ToInt16(n953ContaBancariaCarteira));
         obj102.gxTpr_Contabancariacreatedat_N = (short)(Convert.ToInt16(n954ContaBancariaCreatedAt));
         obj102.gxTpr_Contabancariastatus_N = (short)(Convert.ToInt16(n956ContaBancariaStatus));
         obj102.gxTpr_Contabancariacreatedby_N = (short)(Convert.ToInt16(n947ContaBancariaCreatedBy));
         obj102.gxTpr_Contabancariacreatedbyname_N = (short)(Convert.ToInt16(n948ContaBancariaCreatedByName));
         obj102.gxTpr_Contabancariaupdatedat_N = (short)(Convert.ToInt16(n955ContaBancariaUpdatedAt));
         obj102.gxTpr_Contabancariaupdatedby_N = (short)(Convert.ToInt16(n949ContaBancariaUpdatedBy));
         obj102.gxTpr_Contabancariaupdatedbyname_N = (short)(Convert.ToInt16(n950ContaBancariaUpdatedByName));
         obj102.gxTpr_Contabancariaregistraboletos_N = (short)(Convert.ToInt16(n973ContaBancariaRegistraBoletos));
         obj102.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow102( SdtContaBancaria obj102 )
      {
         obj102.gxTpr_Contabancariaid = A951ContaBancariaId;
         return  ;
      }

      public void RowToVars102( SdtContaBancaria obj102 ,
                                int forceLoad )
      {
         Gx_mode = obj102.gxTpr_Mode;
         A954ContaBancariaCreatedAt = obj102.gxTpr_Contabancariacreatedat;
         n954ContaBancariaCreatedAt = false;
         A955ContaBancariaUpdatedAt = obj102.gxTpr_Contabancariaupdatedat;
         n955ContaBancariaUpdatedAt = false;
         A976ContaBancariaDescricao_F = obj102.gxTpr_Contabancariadescricao_f;
         A938AgenciaId = obj102.gxTpr_Agenciaid;
         n938AgenciaId = false;
         A939AgenciaNumero = obj102.gxTpr_Agencianumero;
         n939AgenciaNumero = false;
         A969AgenciaBancoNome = obj102.gxTpr_Agenciabanconome;
         n969AgenciaBancoNome = false;
         A952ContaBancariaNumero = obj102.gxTpr_Contabancarianumero;
         n952ContaBancariaNumero = false;
         A975ContaBancariaDigito = obj102.gxTpr_Contabancariadigito;
         n975ContaBancariaDigito = false;
         A970ContaBancariaCountChavePIX_F = obj102.gxTpr_Contabancariacountchavepix_f;
         n970ContaBancariaCountChavePIX_F = false;
         A953ContaBancariaCarteira = obj102.gxTpr_Contabancariacarteira;
         n953ContaBancariaCarteira = false;
         A947ContaBancariaCreatedBy = obj102.gxTpr_Contabancariacreatedby;
         n947ContaBancariaCreatedBy = false;
         A948ContaBancariaCreatedByName = obj102.gxTpr_Contabancariacreatedbyname;
         n948ContaBancariaCreatedByName = false;
         A949ContaBancariaUpdatedBy = obj102.gxTpr_Contabancariaupdatedby;
         n949ContaBancariaUpdatedBy = false;
         A950ContaBancariaUpdatedByName = obj102.gxTpr_Contabancariaupdatedbyname;
         n950ContaBancariaUpdatedByName = false;
         A973ContaBancariaRegistraBoletos = obj102.gxTpr_Contabancariaregistraboletos;
         n973ContaBancariaRegistraBoletos = false;
         if ( ! ( IsIns( )  ) || ( forceLoad == 1 ) )
         {
            A956ContaBancariaStatus = obj102.gxTpr_Contabancariastatus;
            n956ContaBancariaStatus = false;
         }
         A951ContaBancariaId = obj102.gxTpr_Contabancariaid;
         n951ContaBancariaId = false;
         Z951ContaBancariaId = obj102.gxTpr_Contabancariaid_Z;
         Z938AgenciaId = obj102.gxTpr_Agenciaid_Z;
         Z939AgenciaNumero = obj102.gxTpr_Agencianumero_Z;
         Z969AgenciaBancoNome = obj102.gxTpr_Agenciabanconome_Z;
         Z952ContaBancariaNumero = obj102.gxTpr_Contabancarianumero_Z;
         Z975ContaBancariaDigito = obj102.gxTpr_Contabancariadigito_Z;
         Z970ContaBancariaCountChavePIX_F = obj102.gxTpr_Contabancariacountchavepix_f_Z;
         Z953ContaBancariaCarteira = obj102.gxTpr_Contabancariacarteira_Z;
         Z954ContaBancariaCreatedAt = obj102.gxTpr_Contabancariacreatedat_Z;
         Z956ContaBancariaStatus = obj102.gxTpr_Contabancariastatus_Z;
         Z947ContaBancariaCreatedBy = obj102.gxTpr_Contabancariacreatedby_Z;
         Z948ContaBancariaCreatedByName = obj102.gxTpr_Contabancariacreatedbyname_Z;
         Z955ContaBancariaUpdatedAt = obj102.gxTpr_Contabancariaupdatedat_Z;
         Z949ContaBancariaUpdatedBy = obj102.gxTpr_Contabancariaupdatedby_Z;
         Z950ContaBancariaUpdatedByName = obj102.gxTpr_Contabancariaupdatedbyname_Z;
         Z973ContaBancariaRegistraBoletos = obj102.gxTpr_Contabancariaregistraboletos_Z;
         Z976ContaBancariaDescricao_F = obj102.gxTpr_Contabancariadescricao_f_Z;
         n951ContaBancariaId = (bool)(Convert.ToBoolean(obj102.gxTpr_Contabancariaid_N));
         n938AgenciaId = (bool)(Convert.ToBoolean(obj102.gxTpr_Agenciaid_N));
         n939AgenciaNumero = (bool)(Convert.ToBoolean(obj102.gxTpr_Agencianumero_N));
         n969AgenciaBancoNome = (bool)(Convert.ToBoolean(obj102.gxTpr_Agenciabanconome_N));
         n952ContaBancariaNumero = (bool)(Convert.ToBoolean(obj102.gxTpr_Contabancarianumero_N));
         n975ContaBancariaDigito = (bool)(Convert.ToBoolean(obj102.gxTpr_Contabancariadigito_N));
         n970ContaBancariaCountChavePIX_F = (bool)(Convert.ToBoolean(obj102.gxTpr_Contabancariacountchavepix_f_N));
         n953ContaBancariaCarteira = (bool)(Convert.ToBoolean(obj102.gxTpr_Contabancariacarteira_N));
         n954ContaBancariaCreatedAt = (bool)(Convert.ToBoolean(obj102.gxTpr_Contabancariacreatedat_N));
         n956ContaBancariaStatus = (bool)(Convert.ToBoolean(obj102.gxTpr_Contabancariastatus_N));
         n947ContaBancariaCreatedBy = (bool)(Convert.ToBoolean(obj102.gxTpr_Contabancariacreatedby_N));
         n948ContaBancariaCreatedByName = (bool)(Convert.ToBoolean(obj102.gxTpr_Contabancariacreatedbyname_N));
         n955ContaBancariaUpdatedAt = (bool)(Convert.ToBoolean(obj102.gxTpr_Contabancariaupdatedat_N));
         n949ContaBancariaUpdatedBy = (bool)(Convert.ToBoolean(obj102.gxTpr_Contabancariaupdatedby_N));
         n950ContaBancariaUpdatedByName = (bool)(Convert.ToBoolean(obj102.gxTpr_Contabancariaupdatedbyname_N));
         n973ContaBancariaRegistraBoletos = (bool)(Convert.ToBoolean(obj102.gxTpr_Contabancariaregistraboletos_N));
         Gx_mode = obj102.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A951ContaBancariaId = (int)getParm(obj,0);
         n951ContaBancariaId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2Y102( ) ;
         ScanKeyStart2Y102( ) ;
         if ( RcdFound102 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z951ContaBancariaId = A951ContaBancariaId;
         }
         ZM2Y102( -8) ;
         OnLoadActions2Y102( ) ;
         AddRow2Y102( ) ;
         ScanKeyEnd2Y102( ) ;
         if ( RcdFound102 == 0 )
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
         RowToVars102( bcContaBancaria, 0) ;
         ScanKeyStart2Y102( ) ;
         if ( RcdFound102 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z951ContaBancariaId = A951ContaBancariaId;
         }
         ZM2Y102( -8) ;
         OnLoadActions2Y102( ) ;
         AddRow2Y102( ) ;
         ScanKeyEnd2Y102( ) ;
         if ( RcdFound102 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2Y102( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2Y102( ) ;
         }
         else
         {
            if ( RcdFound102 == 1 )
            {
               if ( A951ContaBancariaId != Z951ContaBancariaId )
               {
                  A951ContaBancariaId = Z951ContaBancariaId;
                  n951ContaBancariaId = false;
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
                  Update2Y102( ) ;
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
                  if ( A951ContaBancariaId != Z951ContaBancariaId )
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
                        Insert2Y102( ) ;
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
                        Insert2Y102( ) ;
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
         RowToVars102( bcContaBancaria, 1) ;
         SaveImpl( ) ;
         VarsToRow102( bcContaBancaria) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars102( bcContaBancaria, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2Y102( ) ;
         AfterTrn( ) ;
         VarsToRow102( bcContaBancaria) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow102( bcContaBancaria) ;
         }
         else
         {
            SdtContaBancaria auxBC = new SdtContaBancaria(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A951ContaBancariaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcContaBancaria);
               auxBC.Save();
               bcContaBancaria.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars102( bcContaBancaria, 1) ;
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
         RowToVars102( bcContaBancaria, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2Y102( ) ;
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
               VarsToRow102( bcContaBancaria) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow102( bcContaBancaria) ;
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
         RowToVars102( bcContaBancaria, 0) ;
         GetKey2Y102( ) ;
         if ( RcdFound102 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A951ContaBancariaId != Z951ContaBancariaId )
            {
               A951ContaBancariaId = Z951ContaBancariaId;
               n951ContaBancariaId = false;
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
            if ( A951ContaBancariaId != Z951ContaBancariaId )
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
         context.RollbackDataStores("contabancaria_bc",pr_default);
         VarsToRow102( bcContaBancaria) ;
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
         Gx_mode = bcContaBancaria.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcContaBancaria.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcContaBancaria )
         {
            bcContaBancaria = (SdtContaBancaria)(sdt);
            if ( StringUtil.StrCmp(bcContaBancaria.gxTpr_Mode, "") == 0 )
            {
               bcContaBancaria.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow102( bcContaBancaria) ;
            }
            else
            {
               RowToVars102( bcContaBancaria, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcContaBancaria.gxTpr_Mode, "") == 0 )
            {
               bcContaBancaria.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars102( bcContaBancaria, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtContaBancaria ContaBancaria_BC
      {
         get {
            return bcContaBancaria ;
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
         pr_default.close(16);
         pr_default.close(17);
         pr_default.close(15);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV28Pgmname = "";
         AV14TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z954ContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         A954ContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         Z955ContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         A955ContaBancariaUpdatedAt = (DateTime)(DateTime.MinValue);
         Z976ContaBancariaDescricao_F = "";
         A976ContaBancariaDescricao_F = "";
         Z948ContaBancariaCreatedByName = "";
         A948ContaBancariaCreatedByName = "";
         Z950ContaBancariaUpdatedByName = "";
         A950ContaBancariaUpdatedByName = "";
         Z969AgenciaBancoNome = "";
         A969AgenciaBancoNome = "";
         BC002Y11_A968AgenciaBancoId = new int[1] ;
         BC002Y11_n968AgenciaBancoId = new bool[] {false} ;
         BC002Y11_A951ContaBancariaId = new int[1] ;
         BC002Y11_n951ContaBancariaId = new bool[] {false} ;
         BC002Y11_A954ContaBancariaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Y11_n954ContaBancariaCreatedAt = new bool[] {false} ;
         BC002Y11_A955ContaBancariaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Y11_n955ContaBancariaUpdatedAt = new bool[] {false} ;
         BC002Y11_A939AgenciaNumero = new int[1] ;
         BC002Y11_n939AgenciaNumero = new bool[] {false} ;
         BC002Y11_A969AgenciaBancoNome = new string[] {""} ;
         BC002Y11_n969AgenciaBancoNome = new bool[] {false} ;
         BC002Y11_A952ContaBancariaNumero = new long[1] ;
         BC002Y11_n952ContaBancariaNumero = new bool[] {false} ;
         BC002Y11_A975ContaBancariaDigito = new short[1] ;
         BC002Y11_n975ContaBancariaDigito = new bool[] {false} ;
         BC002Y11_A953ContaBancariaCarteira = new long[1] ;
         BC002Y11_n953ContaBancariaCarteira = new bool[] {false} ;
         BC002Y11_A956ContaBancariaStatus = new bool[] {false} ;
         BC002Y11_n956ContaBancariaStatus = new bool[] {false} ;
         BC002Y11_A948ContaBancariaCreatedByName = new string[] {""} ;
         BC002Y11_n948ContaBancariaCreatedByName = new bool[] {false} ;
         BC002Y11_A950ContaBancariaUpdatedByName = new string[] {""} ;
         BC002Y11_n950ContaBancariaUpdatedByName = new bool[] {false} ;
         BC002Y11_A973ContaBancariaRegistraBoletos = new bool[] {false} ;
         BC002Y11_n973ContaBancariaRegistraBoletos = new bool[] {false} ;
         BC002Y11_A974AgenciaBancoCodigo = new int[1] ;
         BC002Y11_n974AgenciaBancoCodigo = new bool[] {false} ;
         BC002Y11_A938AgenciaId = new int[1] ;
         BC002Y11_n938AgenciaId = new bool[] {false} ;
         BC002Y11_A947ContaBancariaCreatedBy = new short[1] ;
         BC002Y11_n947ContaBancariaCreatedBy = new bool[] {false} ;
         BC002Y11_A949ContaBancariaUpdatedBy = new short[1] ;
         BC002Y11_n949ContaBancariaUpdatedBy = new bool[] {false} ;
         BC002Y11_A970ContaBancariaCountChavePIX_F = new short[1] ;
         BC002Y11_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         BC002Y9_A970ContaBancariaCountChavePIX_F = new short[1] ;
         BC002Y9_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         BC002Y4_A968AgenciaBancoId = new int[1] ;
         BC002Y4_n968AgenciaBancoId = new bool[] {false} ;
         BC002Y4_A939AgenciaNumero = new int[1] ;
         BC002Y4_n939AgenciaNumero = new bool[] {false} ;
         BC002Y7_A969AgenciaBancoNome = new string[] {""} ;
         BC002Y7_n969AgenciaBancoNome = new bool[] {false} ;
         BC002Y7_A974AgenciaBancoCodigo = new int[1] ;
         BC002Y7_n974AgenciaBancoCodigo = new bool[] {false} ;
         BC002Y5_A948ContaBancariaCreatedByName = new string[] {""} ;
         BC002Y5_n948ContaBancariaCreatedByName = new bool[] {false} ;
         BC002Y6_A950ContaBancariaUpdatedByName = new string[] {""} ;
         BC002Y6_n950ContaBancariaUpdatedByName = new bool[] {false} ;
         BC002Y12_A951ContaBancariaId = new int[1] ;
         BC002Y12_n951ContaBancariaId = new bool[] {false} ;
         BC002Y3_A951ContaBancariaId = new int[1] ;
         BC002Y3_n951ContaBancariaId = new bool[] {false} ;
         BC002Y3_A954ContaBancariaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Y3_n954ContaBancariaCreatedAt = new bool[] {false} ;
         BC002Y3_A955ContaBancariaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Y3_n955ContaBancariaUpdatedAt = new bool[] {false} ;
         BC002Y3_A952ContaBancariaNumero = new long[1] ;
         BC002Y3_n952ContaBancariaNumero = new bool[] {false} ;
         BC002Y3_A975ContaBancariaDigito = new short[1] ;
         BC002Y3_n975ContaBancariaDigito = new bool[] {false} ;
         BC002Y3_A953ContaBancariaCarteira = new long[1] ;
         BC002Y3_n953ContaBancariaCarteira = new bool[] {false} ;
         BC002Y3_A956ContaBancariaStatus = new bool[] {false} ;
         BC002Y3_n956ContaBancariaStatus = new bool[] {false} ;
         BC002Y3_A973ContaBancariaRegistraBoletos = new bool[] {false} ;
         BC002Y3_n973ContaBancariaRegistraBoletos = new bool[] {false} ;
         BC002Y3_A938AgenciaId = new int[1] ;
         BC002Y3_n938AgenciaId = new bool[] {false} ;
         BC002Y3_A947ContaBancariaCreatedBy = new short[1] ;
         BC002Y3_n947ContaBancariaCreatedBy = new bool[] {false} ;
         BC002Y3_A949ContaBancariaUpdatedBy = new short[1] ;
         BC002Y3_n949ContaBancariaUpdatedBy = new bool[] {false} ;
         sMode102 = "";
         BC002Y2_A951ContaBancariaId = new int[1] ;
         BC002Y2_n951ContaBancariaId = new bool[] {false} ;
         BC002Y2_A954ContaBancariaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Y2_n954ContaBancariaCreatedAt = new bool[] {false} ;
         BC002Y2_A955ContaBancariaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Y2_n955ContaBancariaUpdatedAt = new bool[] {false} ;
         BC002Y2_A952ContaBancariaNumero = new long[1] ;
         BC002Y2_n952ContaBancariaNumero = new bool[] {false} ;
         BC002Y2_A975ContaBancariaDigito = new short[1] ;
         BC002Y2_n975ContaBancariaDigito = new bool[] {false} ;
         BC002Y2_A953ContaBancariaCarteira = new long[1] ;
         BC002Y2_n953ContaBancariaCarteira = new bool[] {false} ;
         BC002Y2_A956ContaBancariaStatus = new bool[] {false} ;
         BC002Y2_n956ContaBancariaStatus = new bool[] {false} ;
         BC002Y2_A973ContaBancariaRegistraBoletos = new bool[] {false} ;
         BC002Y2_n973ContaBancariaRegistraBoletos = new bool[] {false} ;
         BC002Y2_A938AgenciaId = new int[1] ;
         BC002Y2_n938AgenciaId = new bool[] {false} ;
         BC002Y2_A947ContaBancariaCreatedBy = new short[1] ;
         BC002Y2_n947ContaBancariaCreatedBy = new bool[] {false} ;
         BC002Y2_A949ContaBancariaUpdatedBy = new short[1] ;
         BC002Y2_n949ContaBancariaUpdatedBy = new bool[] {false} ;
         BC002Y14_A951ContaBancariaId = new int[1] ;
         BC002Y14_n951ContaBancariaId = new bool[] {false} ;
         BC002Y18_A970ContaBancariaCountChavePIX_F = new short[1] ;
         BC002Y18_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         BC002Y19_A968AgenciaBancoId = new int[1] ;
         BC002Y19_n968AgenciaBancoId = new bool[] {false} ;
         BC002Y19_A939AgenciaNumero = new int[1] ;
         BC002Y19_n939AgenciaNumero = new bool[] {false} ;
         BC002Y20_A969AgenciaBancoNome = new string[] {""} ;
         BC002Y20_n969AgenciaBancoNome = new bool[] {false} ;
         BC002Y20_A974AgenciaBancoCodigo = new int[1] ;
         BC002Y20_n974AgenciaBancoCodigo = new bool[] {false} ;
         BC002Y21_A948ContaBancariaCreatedByName = new string[] {""} ;
         BC002Y21_n948ContaBancariaCreatedByName = new bool[] {false} ;
         BC002Y22_A950ContaBancariaUpdatedByName = new string[] {""} ;
         BC002Y22_n950ContaBancariaUpdatedByName = new bool[] {false} ;
         BC002Y23_A961ChavePIXId = new int[1] ;
         BC002Y24_A261TituloId = new int[1] ;
         BC002Y26_A968AgenciaBancoId = new int[1] ;
         BC002Y26_n968AgenciaBancoId = new bool[] {false} ;
         BC002Y26_A951ContaBancariaId = new int[1] ;
         BC002Y26_n951ContaBancariaId = new bool[] {false} ;
         BC002Y26_A954ContaBancariaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Y26_n954ContaBancariaCreatedAt = new bool[] {false} ;
         BC002Y26_A955ContaBancariaUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC002Y26_n955ContaBancariaUpdatedAt = new bool[] {false} ;
         BC002Y26_A939AgenciaNumero = new int[1] ;
         BC002Y26_n939AgenciaNumero = new bool[] {false} ;
         BC002Y26_A969AgenciaBancoNome = new string[] {""} ;
         BC002Y26_n969AgenciaBancoNome = new bool[] {false} ;
         BC002Y26_A952ContaBancariaNumero = new long[1] ;
         BC002Y26_n952ContaBancariaNumero = new bool[] {false} ;
         BC002Y26_A975ContaBancariaDigito = new short[1] ;
         BC002Y26_n975ContaBancariaDigito = new bool[] {false} ;
         BC002Y26_A953ContaBancariaCarteira = new long[1] ;
         BC002Y26_n953ContaBancariaCarteira = new bool[] {false} ;
         BC002Y26_A956ContaBancariaStatus = new bool[] {false} ;
         BC002Y26_n956ContaBancariaStatus = new bool[] {false} ;
         BC002Y26_A948ContaBancariaCreatedByName = new string[] {""} ;
         BC002Y26_n948ContaBancariaCreatedByName = new bool[] {false} ;
         BC002Y26_A950ContaBancariaUpdatedByName = new string[] {""} ;
         BC002Y26_n950ContaBancariaUpdatedByName = new bool[] {false} ;
         BC002Y26_A973ContaBancariaRegistraBoletos = new bool[] {false} ;
         BC002Y26_n973ContaBancariaRegistraBoletos = new bool[] {false} ;
         BC002Y26_A974AgenciaBancoCodigo = new int[1] ;
         BC002Y26_n974AgenciaBancoCodigo = new bool[] {false} ;
         BC002Y26_A938AgenciaId = new int[1] ;
         BC002Y26_n938AgenciaId = new bool[] {false} ;
         BC002Y26_A947ContaBancariaCreatedBy = new short[1] ;
         BC002Y26_n947ContaBancariaCreatedBy = new bool[] {false} ;
         BC002Y26_A949ContaBancariaUpdatedBy = new short[1] ;
         BC002Y26_n949ContaBancariaUpdatedBy = new bool[] {false} ;
         BC002Y26_A970ContaBancariaCountChavePIX_F = new short[1] ;
         BC002Y26_n970ContaBancariaCountChavePIX_F = new bool[] {false} ;
         i954ContaBancariaCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabancaria_bc__default(),
            new Object[][] {
                new Object[] {
               BC002Y2_A951ContaBancariaId, BC002Y2_A954ContaBancariaCreatedAt, BC002Y2_n954ContaBancariaCreatedAt, BC002Y2_A955ContaBancariaUpdatedAt, BC002Y2_n955ContaBancariaUpdatedAt, BC002Y2_A952ContaBancariaNumero, BC002Y2_n952ContaBancariaNumero, BC002Y2_A975ContaBancariaDigito, BC002Y2_n975ContaBancariaDigito, BC002Y2_A953ContaBancariaCarteira,
               BC002Y2_n953ContaBancariaCarteira, BC002Y2_A956ContaBancariaStatus, BC002Y2_n956ContaBancariaStatus, BC002Y2_A973ContaBancariaRegistraBoletos, BC002Y2_n973ContaBancariaRegistraBoletos, BC002Y2_A938AgenciaId, BC002Y2_n938AgenciaId, BC002Y2_A947ContaBancariaCreatedBy, BC002Y2_n947ContaBancariaCreatedBy, BC002Y2_A949ContaBancariaUpdatedBy,
               BC002Y2_n949ContaBancariaUpdatedBy
               }
               , new Object[] {
               BC002Y3_A951ContaBancariaId, BC002Y3_A954ContaBancariaCreatedAt, BC002Y3_n954ContaBancariaCreatedAt, BC002Y3_A955ContaBancariaUpdatedAt, BC002Y3_n955ContaBancariaUpdatedAt, BC002Y3_A952ContaBancariaNumero, BC002Y3_n952ContaBancariaNumero, BC002Y3_A975ContaBancariaDigito, BC002Y3_n975ContaBancariaDigito, BC002Y3_A953ContaBancariaCarteira,
               BC002Y3_n953ContaBancariaCarteira, BC002Y3_A956ContaBancariaStatus, BC002Y3_n956ContaBancariaStatus, BC002Y3_A973ContaBancariaRegistraBoletos, BC002Y3_n973ContaBancariaRegistraBoletos, BC002Y3_A938AgenciaId, BC002Y3_n938AgenciaId, BC002Y3_A947ContaBancariaCreatedBy, BC002Y3_n947ContaBancariaCreatedBy, BC002Y3_A949ContaBancariaUpdatedBy,
               BC002Y3_n949ContaBancariaUpdatedBy
               }
               , new Object[] {
               BC002Y4_A968AgenciaBancoId, BC002Y4_n968AgenciaBancoId, BC002Y4_A939AgenciaNumero, BC002Y4_n939AgenciaNumero
               }
               , new Object[] {
               BC002Y5_A948ContaBancariaCreatedByName, BC002Y5_n948ContaBancariaCreatedByName
               }
               , new Object[] {
               BC002Y6_A950ContaBancariaUpdatedByName, BC002Y6_n950ContaBancariaUpdatedByName
               }
               , new Object[] {
               BC002Y7_A969AgenciaBancoNome, BC002Y7_n969AgenciaBancoNome, BC002Y7_A974AgenciaBancoCodigo, BC002Y7_n974AgenciaBancoCodigo
               }
               , new Object[] {
               BC002Y9_A970ContaBancariaCountChavePIX_F, BC002Y9_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               BC002Y11_A968AgenciaBancoId, BC002Y11_n968AgenciaBancoId, BC002Y11_A951ContaBancariaId, BC002Y11_A954ContaBancariaCreatedAt, BC002Y11_n954ContaBancariaCreatedAt, BC002Y11_A955ContaBancariaUpdatedAt, BC002Y11_n955ContaBancariaUpdatedAt, BC002Y11_A939AgenciaNumero, BC002Y11_n939AgenciaNumero, BC002Y11_A969AgenciaBancoNome,
               BC002Y11_n969AgenciaBancoNome, BC002Y11_A952ContaBancariaNumero, BC002Y11_n952ContaBancariaNumero, BC002Y11_A975ContaBancariaDigito, BC002Y11_n975ContaBancariaDigito, BC002Y11_A953ContaBancariaCarteira, BC002Y11_n953ContaBancariaCarteira, BC002Y11_A956ContaBancariaStatus, BC002Y11_n956ContaBancariaStatus, BC002Y11_A948ContaBancariaCreatedByName,
               BC002Y11_n948ContaBancariaCreatedByName, BC002Y11_A950ContaBancariaUpdatedByName, BC002Y11_n950ContaBancariaUpdatedByName, BC002Y11_A973ContaBancariaRegistraBoletos, BC002Y11_n973ContaBancariaRegistraBoletos, BC002Y11_A974AgenciaBancoCodigo, BC002Y11_n974AgenciaBancoCodigo, BC002Y11_A938AgenciaId, BC002Y11_n938AgenciaId, BC002Y11_A947ContaBancariaCreatedBy,
               BC002Y11_n947ContaBancariaCreatedBy, BC002Y11_A949ContaBancariaUpdatedBy, BC002Y11_n949ContaBancariaUpdatedBy, BC002Y11_A970ContaBancariaCountChavePIX_F, BC002Y11_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               BC002Y12_A951ContaBancariaId
               }
               , new Object[] {
               }
               , new Object[] {
               BC002Y14_A951ContaBancariaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002Y18_A970ContaBancariaCountChavePIX_F, BC002Y18_n970ContaBancariaCountChavePIX_F
               }
               , new Object[] {
               BC002Y19_A968AgenciaBancoId, BC002Y19_n968AgenciaBancoId, BC002Y19_A939AgenciaNumero, BC002Y19_n939AgenciaNumero
               }
               , new Object[] {
               BC002Y20_A969AgenciaBancoNome, BC002Y20_n969AgenciaBancoNome, BC002Y20_A974AgenciaBancoCodigo, BC002Y20_n974AgenciaBancoCodigo
               }
               , new Object[] {
               BC002Y21_A948ContaBancariaCreatedByName, BC002Y21_n948ContaBancariaCreatedByName
               }
               , new Object[] {
               BC002Y22_A950ContaBancariaUpdatedByName, BC002Y22_n950ContaBancariaUpdatedByName
               }
               , new Object[] {
               BC002Y23_A961ChavePIXId
               }
               , new Object[] {
               BC002Y24_A261TituloId
               }
               , new Object[] {
               BC002Y26_A968AgenciaBancoId, BC002Y26_n968AgenciaBancoId, BC002Y26_A951ContaBancariaId, BC002Y26_A954ContaBancariaCreatedAt, BC002Y26_n954ContaBancariaCreatedAt, BC002Y26_A955ContaBancariaUpdatedAt, BC002Y26_n955ContaBancariaUpdatedAt, BC002Y26_A939AgenciaNumero, BC002Y26_n939AgenciaNumero, BC002Y26_A969AgenciaBancoNome,
               BC002Y26_n969AgenciaBancoNome, BC002Y26_A952ContaBancariaNumero, BC002Y26_n952ContaBancariaNumero, BC002Y26_A975ContaBancariaDigito, BC002Y26_n975ContaBancariaDigito, BC002Y26_A953ContaBancariaCarteira, BC002Y26_n953ContaBancariaCarteira, BC002Y26_A956ContaBancariaStatus, BC002Y26_n956ContaBancariaStatus, BC002Y26_A948ContaBancariaCreatedByName,
               BC002Y26_n948ContaBancariaCreatedByName, BC002Y26_A950ContaBancariaUpdatedByName, BC002Y26_n950ContaBancariaUpdatedByName, BC002Y26_A973ContaBancariaRegistraBoletos, BC002Y26_n973ContaBancariaRegistraBoletos, BC002Y26_A974AgenciaBancoCodigo, BC002Y26_n974AgenciaBancoCodigo, BC002Y26_A938AgenciaId, BC002Y26_n938AgenciaId, BC002Y26_A947ContaBancariaCreatedBy,
               BC002Y26_n947ContaBancariaCreatedBy, BC002Y26_A949ContaBancariaUpdatedBy, BC002Y26_n949ContaBancariaUpdatedBy, BC002Y26_A970ContaBancariaCountChavePIX_F, BC002Y26_n970ContaBancariaCountChavePIX_F
               }
            }
         );
         AV28Pgmname = "ContaBancaria_BC";
         Z956ContaBancariaStatus = true;
         n956ContaBancariaStatus = false;
         A956ContaBancariaStatus = true;
         n956ContaBancariaStatus = false;
         i956ContaBancariaStatus = true;
         n956ContaBancariaStatus = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122Y2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short AV12Insert_ContaBancariaCreatedBy ;
      private short AV13Insert_ContaBancariaUpdatedBy ;
      private short Z975ContaBancariaDigito ;
      private short A975ContaBancariaDigito ;
      private short Z947ContaBancariaCreatedBy ;
      private short A947ContaBancariaCreatedBy ;
      private short Z949ContaBancariaUpdatedBy ;
      private short A949ContaBancariaUpdatedBy ;
      private short Z970ContaBancariaCountChavePIX_F ;
      private short A970ContaBancariaCountChavePIX_F ;
      private short Gx_BScreen ;
      private short RcdFound102 ;
      private int trnEnded ;
      private int Z951ContaBancariaId ;
      private int A951ContaBancariaId ;
      private int AV29GXV1 ;
      private int AV11Insert_AgenciaId ;
      private int Z938AgenciaId ;
      private int A938AgenciaId ;
      private int Z968AgenciaBancoId ;
      private int A968AgenciaBancoId ;
      private int Z939AgenciaNumero ;
      private int A939AgenciaNumero ;
      private int Z974AgenciaBancoCodigo ;
      private int A974AgenciaBancoCodigo ;
      private long Z952ContaBancariaNumero ;
      private long A952ContaBancariaNumero ;
      private long Z953ContaBancariaCarteira ;
      private long A953ContaBancariaCarteira ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV28Pgmname ;
      private string sMode102 ;
      private DateTime Z954ContaBancariaCreatedAt ;
      private DateTime A954ContaBancariaCreatedAt ;
      private DateTime Z955ContaBancariaUpdatedAt ;
      private DateTime A955ContaBancariaUpdatedAt ;
      private DateTime i954ContaBancariaCreatedAt ;
      private bool returnInSub ;
      private bool Z956ContaBancariaStatus ;
      private bool A956ContaBancariaStatus ;
      private bool Z973ContaBancariaRegistraBoletos ;
      private bool A973ContaBancariaRegistraBoletos ;
      private bool n954ContaBancariaCreatedAt ;
      private bool n955ContaBancariaUpdatedAt ;
      private bool n956ContaBancariaStatus ;
      private bool n951ContaBancariaId ;
      private bool n968AgenciaBancoId ;
      private bool n939AgenciaNumero ;
      private bool n969AgenciaBancoNome ;
      private bool n952ContaBancariaNumero ;
      private bool n975ContaBancariaDigito ;
      private bool n953ContaBancariaCarteira ;
      private bool n948ContaBancariaCreatedByName ;
      private bool n950ContaBancariaUpdatedByName ;
      private bool n973ContaBancariaRegistraBoletos ;
      private bool n974AgenciaBancoCodigo ;
      private bool n938AgenciaId ;
      private bool n947ContaBancariaCreatedBy ;
      private bool n949ContaBancariaUpdatedBy ;
      private bool n970ContaBancariaCountChavePIX_F ;
      private bool Gx_longc ;
      private bool i956ContaBancariaStatus ;
      private string Z976ContaBancariaDescricao_F ;
      private string A976ContaBancariaDescricao_F ;
      private string Z948ContaBancariaCreatedByName ;
      private string A948ContaBancariaCreatedByName ;
      private string Z950ContaBancariaUpdatedByName ;
      private string A950ContaBancariaUpdatedByName ;
      private string Z969AgenciaBancoNome ;
      private string A969AgenciaBancoNome ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC002Y11_A968AgenciaBancoId ;
      private bool[] BC002Y11_n968AgenciaBancoId ;
      private int[] BC002Y11_A951ContaBancariaId ;
      private bool[] BC002Y11_n951ContaBancariaId ;
      private DateTime[] BC002Y11_A954ContaBancariaCreatedAt ;
      private bool[] BC002Y11_n954ContaBancariaCreatedAt ;
      private DateTime[] BC002Y11_A955ContaBancariaUpdatedAt ;
      private bool[] BC002Y11_n955ContaBancariaUpdatedAt ;
      private int[] BC002Y11_A939AgenciaNumero ;
      private bool[] BC002Y11_n939AgenciaNumero ;
      private string[] BC002Y11_A969AgenciaBancoNome ;
      private bool[] BC002Y11_n969AgenciaBancoNome ;
      private long[] BC002Y11_A952ContaBancariaNumero ;
      private bool[] BC002Y11_n952ContaBancariaNumero ;
      private short[] BC002Y11_A975ContaBancariaDigito ;
      private bool[] BC002Y11_n975ContaBancariaDigito ;
      private long[] BC002Y11_A953ContaBancariaCarteira ;
      private bool[] BC002Y11_n953ContaBancariaCarteira ;
      private bool[] BC002Y11_A956ContaBancariaStatus ;
      private bool[] BC002Y11_n956ContaBancariaStatus ;
      private string[] BC002Y11_A948ContaBancariaCreatedByName ;
      private bool[] BC002Y11_n948ContaBancariaCreatedByName ;
      private string[] BC002Y11_A950ContaBancariaUpdatedByName ;
      private bool[] BC002Y11_n950ContaBancariaUpdatedByName ;
      private bool[] BC002Y11_A973ContaBancariaRegistraBoletos ;
      private bool[] BC002Y11_n973ContaBancariaRegistraBoletos ;
      private int[] BC002Y11_A974AgenciaBancoCodigo ;
      private bool[] BC002Y11_n974AgenciaBancoCodigo ;
      private int[] BC002Y11_A938AgenciaId ;
      private bool[] BC002Y11_n938AgenciaId ;
      private short[] BC002Y11_A947ContaBancariaCreatedBy ;
      private bool[] BC002Y11_n947ContaBancariaCreatedBy ;
      private short[] BC002Y11_A949ContaBancariaUpdatedBy ;
      private bool[] BC002Y11_n949ContaBancariaUpdatedBy ;
      private short[] BC002Y11_A970ContaBancariaCountChavePIX_F ;
      private bool[] BC002Y11_n970ContaBancariaCountChavePIX_F ;
      private short[] BC002Y9_A970ContaBancariaCountChavePIX_F ;
      private bool[] BC002Y9_n970ContaBancariaCountChavePIX_F ;
      private int[] BC002Y4_A968AgenciaBancoId ;
      private bool[] BC002Y4_n968AgenciaBancoId ;
      private int[] BC002Y4_A939AgenciaNumero ;
      private bool[] BC002Y4_n939AgenciaNumero ;
      private string[] BC002Y7_A969AgenciaBancoNome ;
      private bool[] BC002Y7_n969AgenciaBancoNome ;
      private int[] BC002Y7_A974AgenciaBancoCodigo ;
      private bool[] BC002Y7_n974AgenciaBancoCodigo ;
      private string[] BC002Y5_A948ContaBancariaCreatedByName ;
      private bool[] BC002Y5_n948ContaBancariaCreatedByName ;
      private string[] BC002Y6_A950ContaBancariaUpdatedByName ;
      private bool[] BC002Y6_n950ContaBancariaUpdatedByName ;
      private int[] BC002Y12_A951ContaBancariaId ;
      private bool[] BC002Y12_n951ContaBancariaId ;
      private int[] BC002Y3_A951ContaBancariaId ;
      private bool[] BC002Y3_n951ContaBancariaId ;
      private DateTime[] BC002Y3_A954ContaBancariaCreatedAt ;
      private bool[] BC002Y3_n954ContaBancariaCreatedAt ;
      private DateTime[] BC002Y3_A955ContaBancariaUpdatedAt ;
      private bool[] BC002Y3_n955ContaBancariaUpdatedAt ;
      private long[] BC002Y3_A952ContaBancariaNumero ;
      private bool[] BC002Y3_n952ContaBancariaNumero ;
      private short[] BC002Y3_A975ContaBancariaDigito ;
      private bool[] BC002Y3_n975ContaBancariaDigito ;
      private long[] BC002Y3_A953ContaBancariaCarteira ;
      private bool[] BC002Y3_n953ContaBancariaCarteira ;
      private bool[] BC002Y3_A956ContaBancariaStatus ;
      private bool[] BC002Y3_n956ContaBancariaStatus ;
      private bool[] BC002Y3_A973ContaBancariaRegistraBoletos ;
      private bool[] BC002Y3_n973ContaBancariaRegistraBoletos ;
      private int[] BC002Y3_A938AgenciaId ;
      private bool[] BC002Y3_n938AgenciaId ;
      private short[] BC002Y3_A947ContaBancariaCreatedBy ;
      private bool[] BC002Y3_n947ContaBancariaCreatedBy ;
      private short[] BC002Y3_A949ContaBancariaUpdatedBy ;
      private bool[] BC002Y3_n949ContaBancariaUpdatedBy ;
      private int[] BC002Y2_A951ContaBancariaId ;
      private bool[] BC002Y2_n951ContaBancariaId ;
      private DateTime[] BC002Y2_A954ContaBancariaCreatedAt ;
      private bool[] BC002Y2_n954ContaBancariaCreatedAt ;
      private DateTime[] BC002Y2_A955ContaBancariaUpdatedAt ;
      private bool[] BC002Y2_n955ContaBancariaUpdatedAt ;
      private long[] BC002Y2_A952ContaBancariaNumero ;
      private bool[] BC002Y2_n952ContaBancariaNumero ;
      private short[] BC002Y2_A975ContaBancariaDigito ;
      private bool[] BC002Y2_n975ContaBancariaDigito ;
      private long[] BC002Y2_A953ContaBancariaCarteira ;
      private bool[] BC002Y2_n953ContaBancariaCarteira ;
      private bool[] BC002Y2_A956ContaBancariaStatus ;
      private bool[] BC002Y2_n956ContaBancariaStatus ;
      private bool[] BC002Y2_A973ContaBancariaRegistraBoletos ;
      private bool[] BC002Y2_n973ContaBancariaRegistraBoletos ;
      private int[] BC002Y2_A938AgenciaId ;
      private bool[] BC002Y2_n938AgenciaId ;
      private short[] BC002Y2_A947ContaBancariaCreatedBy ;
      private bool[] BC002Y2_n947ContaBancariaCreatedBy ;
      private short[] BC002Y2_A949ContaBancariaUpdatedBy ;
      private bool[] BC002Y2_n949ContaBancariaUpdatedBy ;
      private int[] BC002Y14_A951ContaBancariaId ;
      private bool[] BC002Y14_n951ContaBancariaId ;
      private short[] BC002Y18_A970ContaBancariaCountChavePIX_F ;
      private bool[] BC002Y18_n970ContaBancariaCountChavePIX_F ;
      private int[] BC002Y19_A968AgenciaBancoId ;
      private bool[] BC002Y19_n968AgenciaBancoId ;
      private int[] BC002Y19_A939AgenciaNumero ;
      private bool[] BC002Y19_n939AgenciaNumero ;
      private string[] BC002Y20_A969AgenciaBancoNome ;
      private bool[] BC002Y20_n969AgenciaBancoNome ;
      private int[] BC002Y20_A974AgenciaBancoCodigo ;
      private bool[] BC002Y20_n974AgenciaBancoCodigo ;
      private string[] BC002Y21_A948ContaBancariaCreatedByName ;
      private bool[] BC002Y21_n948ContaBancariaCreatedByName ;
      private string[] BC002Y22_A950ContaBancariaUpdatedByName ;
      private bool[] BC002Y22_n950ContaBancariaUpdatedByName ;
      private int[] BC002Y23_A961ChavePIXId ;
      private int[] BC002Y24_A261TituloId ;
      private int[] BC002Y26_A968AgenciaBancoId ;
      private bool[] BC002Y26_n968AgenciaBancoId ;
      private int[] BC002Y26_A951ContaBancariaId ;
      private bool[] BC002Y26_n951ContaBancariaId ;
      private DateTime[] BC002Y26_A954ContaBancariaCreatedAt ;
      private bool[] BC002Y26_n954ContaBancariaCreatedAt ;
      private DateTime[] BC002Y26_A955ContaBancariaUpdatedAt ;
      private bool[] BC002Y26_n955ContaBancariaUpdatedAt ;
      private int[] BC002Y26_A939AgenciaNumero ;
      private bool[] BC002Y26_n939AgenciaNumero ;
      private string[] BC002Y26_A969AgenciaBancoNome ;
      private bool[] BC002Y26_n969AgenciaBancoNome ;
      private long[] BC002Y26_A952ContaBancariaNumero ;
      private bool[] BC002Y26_n952ContaBancariaNumero ;
      private short[] BC002Y26_A975ContaBancariaDigito ;
      private bool[] BC002Y26_n975ContaBancariaDigito ;
      private long[] BC002Y26_A953ContaBancariaCarteira ;
      private bool[] BC002Y26_n953ContaBancariaCarteira ;
      private bool[] BC002Y26_A956ContaBancariaStatus ;
      private bool[] BC002Y26_n956ContaBancariaStatus ;
      private string[] BC002Y26_A948ContaBancariaCreatedByName ;
      private bool[] BC002Y26_n948ContaBancariaCreatedByName ;
      private string[] BC002Y26_A950ContaBancariaUpdatedByName ;
      private bool[] BC002Y26_n950ContaBancariaUpdatedByName ;
      private bool[] BC002Y26_A973ContaBancariaRegistraBoletos ;
      private bool[] BC002Y26_n973ContaBancariaRegistraBoletos ;
      private int[] BC002Y26_A974AgenciaBancoCodigo ;
      private bool[] BC002Y26_n974AgenciaBancoCodigo ;
      private int[] BC002Y26_A938AgenciaId ;
      private bool[] BC002Y26_n938AgenciaId ;
      private short[] BC002Y26_A947ContaBancariaCreatedBy ;
      private bool[] BC002Y26_n947ContaBancariaCreatedBy ;
      private short[] BC002Y26_A949ContaBancariaUpdatedBy ;
      private bool[] BC002Y26_n949ContaBancariaUpdatedBy ;
      private short[] BC002Y26_A970ContaBancariaCountChavePIX_F ;
      private bool[] BC002Y26_n970ContaBancariaCountChavePIX_F ;
      private SdtContaBancaria bcContaBancaria ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class contabancaria_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
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
          Object[] prmBC002Y2;
          prmBC002Y2 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y3;
          prmBC002Y3 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y4;
          prmBC002Y4 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y5;
          prmBC002Y5 = new Object[] {
          new ParDef("ContaBancariaCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Y6;
          prmBC002Y6 = new Object[] {
          new ParDef("ContaBancariaUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Y7;
          prmBC002Y7 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y9;
          prmBC002Y9 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y11;
          prmBC002Y11 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y12;
          prmBC002Y12 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y13;
          prmBC002Y13 = new Object[] {
          new ParDef("ContaBancariaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaBancariaUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaBancariaNumero",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("ContaBancariaDigito",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContaBancariaCarteira",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("ContaBancariaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaBancariaRegistraBoletos",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContaBancariaCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContaBancariaUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Y14;
          prmBC002Y14 = new Object[] {
          };
          Object[] prmBC002Y15;
          prmBC002Y15 = new Object[] {
          new ParDef("ContaBancariaCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaBancariaUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("ContaBancariaNumero",GXType.Int64,18,0){Nullable=true} ,
          new ParDef("ContaBancariaDigito",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContaBancariaCarteira",GXType.Int64,10,0){Nullable=true} ,
          new ParDef("ContaBancariaStatus",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("ContaBancariaRegistraBoletos",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("ContaBancariaCreatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContaBancariaUpdatedBy",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y16;
          prmBC002Y16 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y18;
          prmBC002Y18 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y19;
          prmBC002Y19 = new Object[] {
          new ParDef("AgenciaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y20;
          prmBC002Y20 = new Object[] {
          new ParDef("AgenciaBancoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y21;
          prmBC002Y21 = new Object[] {
          new ParDef("ContaBancariaCreatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Y22;
          prmBC002Y22 = new Object[] {
          new ParDef("ContaBancariaUpdatedBy",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC002Y23;
          prmBC002Y23 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y24;
          prmBC002Y24 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002Y26;
          prmBC002Y26 = new Object[] {
          new ParDef("ContaBancariaId",GXType.Int32,9,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("BC002Y2", "SELECT ContaBancariaId, ContaBancariaCreatedAt, ContaBancariaUpdatedAt, ContaBancariaNumero, ContaBancariaDigito, ContaBancariaCarteira, ContaBancariaStatus, ContaBancariaRegistraBoletos, AgenciaId, ContaBancariaCreatedBy, ContaBancariaUpdatedBy FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId  FOR UPDATE OF ContaBancaria",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y3", "SELECT ContaBancariaId, ContaBancariaCreatedAt, ContaBancariaUpdatedAt, ContaBancariaNumero, ContaBancariaDigito, ContaBancariaCarteira, ContaBancariaStatus, ContaBancariaRegistraBoletos, AgenciaId, ContaBancariaCreatedBy, ContaBancariaUpdatedBy FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y4", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y5", "SELECT SecUserName AS ContaBancariaCreatedByName FROM SecUser WHERE SecUserId = :ContaBancariaCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y6", "SELECT SecUserName AS ContaBancariaUpdatedByName FROM SecUser WHERE SecUserId = :ContaBancariaUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y7", "SELECT BancoNome AS AgenciaBancoNome, BancoCodigo AS AgenciaBancoCodigo FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y9", "SELECT COALESCE( T1.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, ContaBancariaId FROM ChavePIX GROUP BY ContaBancariaId ) T1 WHERE T1.ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y11", "SELECT T3.AgenciaBancoId AS AgenciaBancoId, TM1.ContaBancariaId, TM1.ContaBancariaCreatedAt, TM1.ContaBancariaUpdatedAt, T3.AgenciaNumero, T4.BancoNome AS AgenciaBancoNome, TM1.ContaBancariaNumero, TM1.ContaBancariaDigito, TM1.ContaBancariaCarteira, TM1.ContaBancariaStatus, T5.SecUserName AS ContaBancariaCreatedByName, T6.SecUserName AS ContaBancariaUpdatedByName, TM1.ContaBancariaRegistraBoletos, T4.BancoCodigo AS AgenciaBancoCodigo, TM1.AgenciaId, TM1.ContaBancariaCreatedBy AS ContaBancariaCreatedBy, TM1.ContaBancariaUpdatedBy AS ContaBancariaUpdatedBy, COALESCE( T2.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM (((((ContaBancaria TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, ContaBancariaId FROM ChavePIX WHERE TM1.ContaBancariaId = ContaBancariaId GROUP BY ContaBancariaId ) T2 ON T2.ContaBancariaId = TM1.ContaBancariaId) LEFT JOIN Agencia T3 ON T3.AgenciaId = TM1.AgenciaId) LEFT JOIN Banco T4 ON T4.BancoId = T3.AgenciaBancoId) LEFT JOIN SecUser T5 ON T5.SecUserId = TM1.ContaBancariaCreatedBy) LEFT JOIN SecUser T6 ON T6.SecUserId = TM1.ContaBancariaUpdatedBy) WHERE TM1.ContaBancariaId = :ContaBancariaId ORDER BY TM1.ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y11,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y12", "SELECT ContaBancariaId FROM ContaBancaria WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y13", "SAVEPOINT gxupdate;INSERT INTO ContaBancaria(ContaBancariaCreatedAt, ContaBancariaUpdatedAt, ContaBancariaNumero, ContaBancariaDigito, ContaBancariaCarteira, ContaBancariaStatus, ContaBancariaRegistraBoletos, AgenciaId, ContaBancariaCreatedBy, ContaBancariaUpdatedBy) VALUES(:ContaBancariaCreatedAt, :ContaBancariaUpdatedAt, :ContaBancariaNumero, :ContaBancariaDigito, :ContaBancariaCarteira, :ContaBancariaStatus, :ContaBancariaRegistraBoletos, :AgenciaId, :ContaBancariaCreatedBy, :ContaBancariaUpdatedBy);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC002Y13)
             ,new CursorDef("BC002Y14", "SELECT currval('ContaBancariaId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y15", "SAVEPOINT gxupdate;UPDATE ContaBancaria SET ContaBancariaCreatedAt=:ContaBancariaCreatedAt, ContaBancariaUpdatedAt=:ContaBancariaUpdatedAt, ContaBancariaNumero=:ContaBancariaNumero, ContaBancariaDigito=:ContaBancariaDigito, ContaBancariaCarteira=:ContaBancariaCarteira, ContaBancariaStatus=:ContaBancariaStatus, ContaBancariaRegistraBoletos=:ContaBancariaRegistraBoletos, AgenciaId=:AgenciaId, ContaBancariaCreatedBy=:ContaBancariaCreatedBy, ContaBancariaUpdatedBy=:ContaBancariaUpdatedBy  WHERE ContaBancariaId = :ContaBancariaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002Y15)
             ,new CursorDef("BC002Y16", "SAVEPOINT gxupdate;DELETE FROM ContaBancaria  WHERE ContaBancariaId = :ContaBancariaId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002Y16)
             ,new CursorDef("BC002Y18", "SELECT COALESCE( T1.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, ContaBancariaId FROM ChavePIX GROUP BY ContaBancariaId ) T1 WHERE T1.ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y19", "SELECT AgenciaBancoId, AgenciaNumero FROM Agencia WHERE AgenciaId = :AgenciaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y20", "SELECT BancoNome AS AgenciaBancoNome, BancoCodigo AS AgenciaBancoCodigo FROM Banco WHERE BancoId = :AgenciaBancoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y21", "SELECT SecUserName AS ContaBancariaCreatedByName FROM SecUser WHERE SecUserId = :ContaBancariaCreatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y22", "SELECT SecUserName AS ContaBancariaUpdatedByName FROM SecUser WHERE SecUserId = :ContaBancariaUpdatedBy ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002Y23", "SELECT ChavePIXId FROM ChavePIX WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y23,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002Y24", "SELECT TituloId FROM Titulo WHERE ContaBancariaId = :ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y24,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC002Y26", "SELECT T3.AgenciaBancoId AS AgenciaBancoId, TM1.ContaBancariaId, TM1.ContaBancariaCreatedAt, TM1.ContaBancariaUpdatedAt, T3.AgenciaNumero, T4.BancoNome AS AgenciaBancoNome, TM1.ContaBancariaNumero, TM1.ContaBancariaDigito, TM1.ContaBancariaCarteira, TM1.ContaBancariaStatus, T5.SecUserName AS ContaBancariaCreatedByName, T6.SecUserName AS ContaBancariaUpdatedByName, TM1.ContaBancariaRegistraBoletos, T4.BancoCodigo AS AgenciaBancoCodigo, TM1.AgenciaId, TM1.ContaBancariaCreatedBy AS ContaBancariaCreatedBy, TM1.ContaBancariaUpdatedBy AS ContaBancariaUpdatedBy, COALESCE( T2.ContaBancariaCountChavePIX_F, 0) AS ContaBancariaCountChavePIX_F FROM (((((ContaBancaria TM1 LEFT JOIN LATERAL (SELECT COUNT(*) AS ContaBancariaCountChavePIX_F, ContaBancariaId FROM ChavePIX WHERE TM1.ContaBancariaId = ContaBancariaId GROUP BY ContaBancariaId ) T2 ON T2.ContaBancariaId = TM1.ContaBancariaId) LEFT JOIN Agencia T3 ON T3.AgenciaId = TM1.AgenciaId) LEFT JOIN Banco T4 ON T4.BancoId = T3.AgenciaBancoId) LEFT JOIN SecUser T5 ON T5.SecUserId = TM1.ContaBancariaCreatedBy) LEFT JOIN SecUser T6 ON T6.SecUserId = TM1.ContaBancariaUpdatedBy) WHERE TM1.ContaBancariaId = :ContaBancariaId ORDER BY TM1.ContaBancariaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002Y26,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((long[]) buf[9])[0] = rslt.getLong(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((bool[]) buf[11])[0] = rslt.getBool(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((bool[]) buf[13])[0] = rslt.getBool(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((short[]) buf[17])[0] = rslt.getShort(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((short[]) buf[19])[0] = rslt.getShort(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((long[]) buf[11])[0] = rslt.getLong(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((long[]) buf[15])[0] = rslt.getLong(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
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
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 18 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 19 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 20 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((long[]) buf[11])[0] = rslt.getLong(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((short[]) buf[13])[0] = rslt.getShort(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((long[]) buf[15])[0] = rslt.getLong(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((bool[]) buf[17])[0] = rslt.getBool(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((bool[]) buf[23])[0] = rslt.getBool(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
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
