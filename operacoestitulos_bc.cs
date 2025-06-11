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
   public class operacoestitulos_bc : GxSilentTrn, IGxSilentTrn
   {
      public operacoestitulos_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacoestitulos_bc( IGxContext context )
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
         ReadRow32106( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey32106( ) ;
         standaloneModal( ) ;
         AddRow32106( ) ;
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
            E11322 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1019OperacoesTitulosId = A1019OperacoesTitulosId;
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

      protected void CONFIRM_320( )
      {
         BeforeValidate32106( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls32106( ) ;
            }
            else
            {
               CheckExtendedTable32106( ) ;
               if ( AnyError == 0 )
               {
                  ZM32106( 13) ;
                  ZM32106( 14) ;
               }
               CloseExtendedTableCursors32106( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12322( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV23Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV24GXV1 = 1;
            while ( AV24GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV24GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "OperacoesId") == 0 )
               {
                  AV11Insert_OperacoesId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "SacadoId") == 0 )
               {
                  AV20Insert_SacadoId = (int)(Math.Round(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV24GXV1 = (int)(AV24GXV1+1);
            }
         }
      }

      protected void E11322( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void E13322( )
      {
         /* 'DoSelecionar' Routine */
         returnInSub = false;
         context.PopUp(formatLink("popupsacado", new object[] {UrlEncode(StringUtil.LTrimStr(A1034SacadoId,9,0)),UrlEncode(StringUtil.RTrim(A1035SacadoRazaoSocial))}, new string[] {"InOutClienteId","InOutClienteRazaoSocial"}) , new Object[] {"A1034SacadoId","A1035SacadoRazaoSocial"});
      }

      protected void ZM32106( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z1028OperacoesTitulosCreatedAt = A1028OperacoesTitulosCreatedAt;
            Z1029OperacoesTitulosUpdatedAt = A1029OperacoesTitulosUpdatedAt;
            Z1020OperacoesTitulosTipo = A1020OperacoesTitulosTipo;
            Z1021OperacoesTitulosNumero = A1021OperacoesTitulosNumero;
            Z1022OperacoesTitulosDataEmissao = A1022OperacoesTitulosDataEmissao;
            Z1023OperacoesTitulosDataVencimento = A1023OperacoesTitulosDataVencimento;
            Z1024OperacoesTitulosValor = A1024OperacoesTitulosValor;
            Z1025OperacoesTitulosLiquido = A1025OperacoesTitulosLiquido;
            Z1026OperacoesTitulosTaxa = A1026OperacoesTitulosTaxa;
            Z1027OperacoesTitulosStatus = A1027OperacoesTitulosStatus;
            Z1010OperacoesId = A1010OperacoesId;
            Z1034SacadoId = A1034SacadoId;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z1035SacadoRazaoSocial = A1035SacadoRazaoSocial;
         }
         if ( GX_JID == -12 )
         {
            Z1019OperacoesTitulosId = A1019OperacoesTitulosId;
            Z1028OperacoesTitulosCreatedAt = A1028OperacoesTitulosCreatedAt;
            Z1029OperacoesTitulosUpdatedAt = A1029OperacoesTitulosUpdatedAt;
            Z1020OperacoesTitulosTipo = A1020OperacoesTitulosTipo;
            Z1021OperacoesTitulosNumero = A1021OperacoesTitulosNumero;
            Z1022OperacoesTitulosDataEmissao = A1022OperacoesTitulosDataEmissao;
            Z1023OperacoesTitulosDataVencimento = A1023OperacoesTitulosDataVencimento;
            Z1024OperacoesTitulosValor = A1024OperacoesTitulosValor;
            Z1025OperacoesTitulosLiquido = A1025OperacoesTitulosLiquido;
            Z1026OperacoesTitulosTaxa = A1026OperacoesTitulosTaxa;
            Z1027OperacoesTitulosStatus = A1027OperacoesTitulosStatus;
            Z1010OperacoesId = A1010OperacoesId;
            Z1034SacadoId = A1034SacadoId;
            Z1035SacadoRazaoSocial = A1035SacadoRazaoSocial;
         }
      }

      protected void standaloneNotModal( )
      {
         AV23Pgmname = "OperacoesTitulos_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            A1028OperacoesTitulosCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1028OperacoesTitulosCreatedAt = false;
         }
         if ( IsUpd( )  )
         {
            A1029OperacoesTitulosUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n1029OperacoesTitulosUpdatedAt = false;
         }
      }

      protected void Load32106( )
      {
         /* Using cursor BC00326 */
         pr_default.execute(4, new Object[] {A1019OperacoesTitulosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound106 = 1;
            A1028OperacoesTitulosCreatedAt = BC00326_A1028OperacoesTitulosCreatedAt[0];
            n1028OperacoesTitulosCreatedAt = BC00326_n1028OperacoesTitulosCreatedAt[0];
            A1029OperacoesTitulosUpdatedAt = BC00326_A1029OperacoesTitulosUpdatedAt[0];
            n1029OperacoesTitulosUpdatedAt = BC00326_n1029OperacoesTitulosUpdatedAt[0];
            A1035SacadoRazaoSocial = BC00326_A1035SacadoRazaoSocial[0];
            n1035SacadoRazaoSocial = BC00326_n1035SacadoRazaoSocial[0];
            A1020OperacoesTitulosTipo = BC00326_A1020OperacoesTitulosTipo[0];
            n1020OperacoesTitulosTipo = BC00326_n1020OperacoesTitulosTipo[0];
            A1021OperacoesTitulosNumero = BC00326_A1021OperacoesTitulosNumero[0];
            n1021OperacoesTitulosNumero = BC00326_n1021OperacoesTitulosNumero[0];
            A1022OperacoesTitulosDataEmissao = BC00326_A1022OperacoesTitulosDataEmissao[0];
            n1022OperacoesTitulosDataEmissao = BC00326_n1022OperacoesTitulosDataEmissao[0];
            A1023OperacoesTitulosDataVencimento = BC00326_A1023OperacoesTitulosDataVencimento[0];
            n1023OperacoesTitulosDataVencimento = BC00326_n1023OperacoesTitulosDataVencimento[0];
            A1024OperacoesTitulosValor = BC00326_A1024OperacoesTitulosValor[0];
            n1024OperacoesTitulosValor = BC00326_n1024OperacoesTitulosValor[0];
            A1025OperacoesTitulosLiquido = BC00326_A1025OperacoesTitulosLiquido[0];
            n1025OperacoesTitulosLiquido = BC00326_n1025OperacoesTitulosLiquido[0];
            A1026OperacoesTitulosTaxa = BC00326_A1026OperacoesTitulosTaxa[0];
            n1026OperacoesTitulosTaxa = BC00326_n1026OperacoesTitulosTaxa[0];
            A1027OperacoesTitulosStatus = BC00326_A1027OperacoesTitulosStatus[0];
            n1027OperacoesTitulosStatus = BC00326_n1027OperacoesTitulosStatus[0];
            A1010OperacoesId = BC00326_A1010OperacoesId[0];
            n1010OperacoesId = BC00326_n1010OperacoesId[0];
            A1034SacadoId = BC00326_A1034SacadoId[0];
            n1034SacadoId = BC00326_n1034SacadoId[0];
            ZM32106( -12) ;
         }
         pr_default.close(4);
         OnLoadActions32106( ) ;
      }

      protected void OnLoadActions32106( )
      {
      }

      protected void CheckExtendedTable32106( )
      {
         standaloneModal( ) ;
         /* Using cursor BC00324 */
         pr_default.execute(2, new Object[] {n1010OperacoesId, A1010OperacoesId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A1010OperacoesId) ) )
            {
               GX_msglist.addItem("Não existe 'Operacoes'.", "ForeignKeyNotFound", 1, "OPERACOESID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         /* Using cursor BC00325 */
         pr_default.execute(3, new Object[] {n1034SacadoId, A1034SacadoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A1034SacadoId) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Sacado'.", "ForeignKeyNotFound", 1, "SACADOID");
               AnyError = 1;
            }
         }
         A1035SacadoRazaoSocial = BC00325_A1035SacadoRazaoSocial[0];
         n1035SacadoRazaoSocial = BC00325_n1035SacadoRazaoSocial[0];
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1035SacadoRazaoSocial)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sacado Razao Social", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A1020OperacoesTitulosTipo, "NOTA_FISCAL") == 0 ) || ( StringUtil.StrCmp(A1020OperacoesTitulosTipo, "RPA") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1020OperacoesTitulosTipo)) ) )
         {
            GX_msglist.addItem("Campo Tipo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (DateTime.MinValue==A1022OperacoesTitulosDataEmissao) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Emissão", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( (DateTime.MinValue==A1023OperacoesTitulosDataVencimento) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Vencimento", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( (Convert.ToDecimal(0)==A1024OperacoesTitulosValor) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Valor", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( ( A1024OperacoesTitulosValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A1027OperacoesTitulosStatus, "PENDENTE") == 0 ) || ( StringUtil.StrCmp(A1027OperacoesTitulosStatus, "ACEITO") == 0 ) || ( StringUtil.StrCmp(A1027OperacoesTitulosStatus, "RECUSADO") == 0 ) || ( StringUtil.StrCmp(A1027OperacoesTitulosStatus, "VENCIDO") == 0 ) || ( StringUtil.StrCmp(A1027OperacoesTitulosStatus, "LIQUIDADO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A1027OperacoesTitulosStatus)) ) )
         {
            GX_msglist.addItem("Campo Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors32106( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey32106( )
      {
         /* Using cursor BC00327 */
         pr_default.execute(5, new Object[] {A1019OperacoesTitulosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound106 = 1;
         }
         else
         {
            RcdFound106 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00323 */
         pr_default.execute(1, new Object[] {A1019OperacoesTitulosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM32106( 12) ;
            RcdFound106 = 1;
            A1019OperacoesTitulosId = BC00323_A1019OperacoesTitulosId[0];
            A1028OperacoesTitulosCreatedAt = BC00323_A1028OperacoesTitulosCreatedAt[0];
            n1028OperacoesTitulosCreatedAt = BC00323_n1028OperacoesTitulosCreatedAt[0];
            A1029OperacoesTitulosUpdatedAt = BC00323_A1029OperacoesTitulosUpdatedAt[0];
            n1029OperacoesTitulosUpdatedAt = BC00323_n1029OperacoesTitulosUpdatedAt[0];
            A1020OperacoesTitulosTipo = BC00323_A1020OperacoesTitulosTipo[0];
            n1020OperacoesTitulosTipo = BC00323_n1020OperacoesTitulosTipo[0];
            A1021OperacoesTitulosNumero = BC00323_A1021OperacoesTitulosNumero[0];
            n1021OperacoesTitulosNumero = BC00323_n1021OperacoesTitulosNumero[0];
            A1022OperacoesTitulosDataEmissao = BC00323_A1022OperacoesTitulosDataEmissao[0];
            n1022OperacoesTitulosDataEmissao = BC00323_n1022OperacoesTitulosDataEmissao[0];
            A1023OperacoesTitulosDataVencimento = BC00323_A1023OperacoesTitulosDataVencimento[0];
            n1023OperacoesTitulosDataVencimento = BC00323_n1023OperacoesTitulosDataVencimento[0];
            A1024OperacoesTitulosValor = BC00323_A1024OperacoesTitulosValor[0];
            n1024OperacoesTitulosValor = BC00323_n1024OperacoesTitulosValor[0];
            A1025OperacoesTitulosLiquido = BC00323_A1025OperacoesTitulosLiquido[0];
            n1025OperacoesTitulosLiquido = BC00323_n1025OperacoesTitulosLiquido[0];
            A1026OperacoesTitulosTaxa = BC00323_A1026OperacoesTitulosTaxa[0];
            n1026OperacoesTitulosTaxa = BC00323_n1026OperacoesTitulosTaxa[0];
            A1027OperacoesTitulosStatus = BC00323_A1027OperacoesTitulosStatus[0];
            n1027OperacoesTitulosStatus = BC00323_n1027OperacoesTitulosStatus[0];
            A1010OperacoesId = BC00323_A1010OperacoesId[0];
            n1010OperacoesId = BC00323_n1010OperacoesId[0];
            A1034SacadoId = BC00323_A1034SacadoId[0];
            n1034SacadoId = BC00323_n1034SacadoId[0];
            Z1019OperacoesTitulosId = A1019OperacoesTitulosId;
            sMode106 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load32106( ) ;
            if ( AnyError == 1 )
            {
               RcdFound106 = 0;
               InitializeNonKey32106( ) ;
            }
            Gx_mode = sMode106;
         }
         else
         {
            RcdFound106 = 0;
            InitializeNonKey32106( ) ;
            sMode106 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode106;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey32106( ) ;
         if ( RcdFound106 == 0 )
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
         CONFIRM_320( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency32106( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00322 */
            pr_default.execute(0, new Object[] {A1019OperacoesTitulosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"OperacoesTitulos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1028OperacoesTitulosCreatedAt != BC00322_A1028OperacoesTitulosCreatedAt[0] ) || ( Z1029OperacoesTitulosUpdatedAt != BC00322_A1029OperacoesTitulosUpdatedAt[0] ) || ( StringUtil.StrCmp(Z1020OperacoesTitulosTipo, BC00322_A1020OperacoesTitulosTipo[0]) != 0 ) || ( Z1021OperacoesTitulosNumero != BC00322_A1021OperacoesTitulosNumero[0] ) || ( DateTimeUtil.ResetTime ( Z1022OperacoesTitulosDataEmissao ) != DateTimeUtil.ResetTime ( BC00322_A1022OperacoesTitulosDataEmissao[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z1023OperacoesTitulosDataVencimento ) != DateTimeUtil.ResetTime ( BC00322_A1023OperacoesTitulosDataVencimento[0] ) ) || ( Z1024OperacoesTitulosValor != BC00322_A1024OperacoesTitulosValor[0] ) || ( Z1025OperacoesTitulosLiquido != BC00322_A1025OperacoesTitulosLiquido[0] ) || ( Z1026OperacoesTitulosTaxa != BC00322_A1026OperacoesTitulosTaxa[0] ) || ( StringUtil.StrCmp(Z1027OperacoesTitulosStatus, BC00322_A1027OperacoesTitulosStatus[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1010OperacoesId != BC00322_A1010OperacoesId[0] ) || ( Z1034SacadoId != BC00322_A1034SacadoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"OperacoesTitulos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert32106( )
      {
         BeforeValidate32106( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable32106( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM32106( 0) ;
            CheckOptimisticConcurrency32106( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm32106( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert32106( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00328 */
                     pr_default.execute(6, new Object[] {n1028OperacoesTitulosCreatedAt, A1028OperacoesTitulosCreatedAt, n1029OperacoesTitulosUpdatedAt, A1029OperacoesTitulosUpdatedAt, n1020OperacoesTitulosTipo, A1020OperacoesTitulosTipo, n1021OperacoesTitulosNumero, A1021OperacoesTitulosNumero, n1022OperacoesTitulosDataEmissao, A1022OperacoesTitulosDataEmissao, n1023OperacoesTitulosDataVencimento, A1023OperacoesTitulosDataVencimento, n1024OperacoesTitulosValor, A1024OperacoesTitulosValor, n1025OperacoesTitulosLiquido, A1025OperacoesTitulosLiquido, n1026OperacoesTitulosTaxa, A1026OperacoesTitulosTaxa, n1027OperacoesTitulosStatus, A1027OperacoesTitulosStatus, n1010OperacoesId, A1010OperacoesId, n1034SacadoId, A1034SacadoId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00329 */
                     pr_default.execute(7);
                     A1019OperacoesTitulosId = BC00329_A1019OperacoesTitulosId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("OperacoesTitulos");
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
               Load32106( ) ;
            }
            EndLevel32106( ) ;
         }
         CloseExtendedTableCursors32106( ) ;
      }

      protected void Update32106( )
      {
         BeforeValidate32106( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable32106( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency32106( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm32106( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate32106( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC003210 */
                     pr_default.execute(8, new Object[] {n1028OperacoesTitulosCreatedAt, A1028OperacoesTitulosCreatedAt, n1029OperacoesTitulosUpdatedAt, A1029OperacoesTitulosUpdatedAt, n1020OperacoesTitulosTipo, A1020OperacoesTitulosTipo, n1021OperacoesTitulosNumero, A1021OperacoesTitulosNumero, n1022OperacoesTitulosDataEmissao, A1022OperacoesTitulosDataEmissao, n1023OperacoesTitulosDataVencimento, A1023OperacoesTitulosDataVencimento, n1024OperacoesTitulosValor, A1024OperacoesTitulosValor, n1025OperacoesTitulosLiquido, A1025OperacoesTitulosLiquido, n1026OperacoesTitulosTaxa, A1026OperacoesTitulosTaxa, n1027OperacoesTitulosStatus, A1027OperacoesTitulosStatus, n1010OperacoesId, A1010OperacoesId, n1034SacadoId, A1034SacadoId, A1019OperacoesTitulosId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("OperacoesTitulos");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"OperacoesTitulos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate32106( ) ;
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
            EndLevel32106( ) ;
         }
         CloseExtendedTableCursors32106( ) ;
      }

      protected void DeferredUpdate32106( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate32106( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency32106( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls32106( ) ;
            AfterConfirm32106( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete32106( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC003211 */
                  pr_default.execute(9, new Object[] {A1019OperacoesTitulosId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("OperacoesTitulos");
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
         sMode106 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel32106( ) ;
         Gx_mode = sMode106;
      }

      protected void OnDeleteControls32106( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC003212 */
            pr_default.execute(10, new Object[] {n1034SacadoId, A1034SacadoId});
            A1035SacadoRazaoSocial = BC003212_A1035SacadoRazaoSocial[0];
            n1035SacadoRazaoSocial = BC003212_n1035SacadoRazaoSocial[0];
            pr_default.close(10);
         }
      }

      protected void EndLevel32106( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete32106( ) ;
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

      public void ScanKeyStart32106( )
      {
         /* Scan By routine */
         /* Using cursor BC003213 */
         pr_default.execute(11, new Object[] {A1019OperacoesTitulosId});
         RcdFound106 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound106 = 1;
            A1019OperacoesTitulosId = BC003213_A1019OperacoesTitulosId[0];
            A1028OperacoesTitulosCreatedAt = BC003213_A1028OperacoesTitulosCreatedAt[0];
            n1028OperacoesTitulosCreatedAt = BC003213_n1028OperacoesTitulosCreatedAt[0];
            A1029OperacoesTitulosUpdatedAt = BC003213_A1029OperacoesTitulosUpdatedAt[0];
            n1029OperacoesTitulosUpdatedAt = BC003213_n1029OperacoesTitulosUpdatedAt[0];
            A1035SacadoRazaoSocial = BC003213_A1035SacadoRazaoSocial[0];
            n1035SacadoRazaoSocial = BC003213_n1035SacadoRazaoSocial[0];
            A1020OperacoesTitulosTipo = BC003213_A1020OperacoesTitulosTipo[0];
            n1020OperacoesTitulosTipo = BC003213_n1020OperacoesTitulosTipo[0];
            A1021OperacoesTitulosNumero = BC003213_A1021OperacoesTitulosNumero[0];
            n1021OperacoesTitulosNumero = BC003213_n1021OperacoesTitulosNumero[0];
            A1022OperacoesTitulosDataEmissao = BC003213_A1022OperacoesTitulosDataEmissao[0];
            n1022OperacoesTitulosDataEmissao = BC003213_n1022OperacoesTitulosDataEmissao[0];
            A1023OperacoesTitulosDataVencimento = BC003213_A1023OperacoesTitulosDataVencimento[0];
            n1023OperacoesTitulosDataVencimento = BC003213_n1023OperacoesTitulosDataVencimento[0];
            A1024OperacoesTitulosValor = BC003213_A1024OperacoesTitulosValor[0];
            n1024OperacoesTitulosValor = BC003213_n1024OperacoesTitulosValor[0];
            A1025OperacoesTitulosLiquido = BC003213_A1025OperacoesTitulosLiquido[0];
            n1025OperacoesTitulosLiquido = BC003213_n1025OperacoesTitulosLiquido[0];
            A1026OperacoesTitulosTaxa = BC003213_A1026OperacoesTitulosTaxa[0];
            n1026OperacoesTitulosTaxa = BC003213_n1026OperacoesTitulosTaxa[0];
            A1027OperacoesTitulosStatus = BC003213_A1027OperacoesTitulosStatus[0];
            n1027OperacoesTitulosStatus = BC003213_n1027OperacoesTitulosStatus[0];
            A1010OperacoesId = BC003213_A1010OperacoesId[0];
            n1010OperacoesId = BC003213_n1010OperacoesId[0];
            A1034SacadoId = BC003213_A1034SacadoId[0];
            n1034SacadoId = BC003213_n1034SacadoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext32106( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound106 = 0;
         ScanKeyLoad32106( ) ;
      }

      protected void ScanKeyLoad32106( )
      {
         sMode106 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound106 = 1;
            A1019OperacoesTitulosId = BC003213_A1019OperacoesTitulosId[0];
            A1028OperacoesTitulosCreatedAt = BC003213_A1028OperacoesTitulosCreatedAt[0];
            n1028OperacoesTitulosCreatedAt = BC003213_n1028OperacoesTitulosCreatedAt[0];
            A1029OperacoesTitulosUpdatedAt = BC003213_A1029OperacoesTitulosUpdatedAt[0];
            n1029OperacoesTitulosUpdatedAt = BC003213_n1029OperacoesTitulosUpdatedAt[0];
            A1035SacadoRazaoSocial = BC003213_A1035SacadoRazaoSocial[0];
            n1035SacadoRazaoSocial = BC003213_n1035SacadoRazaoSocial[0];
            A1020OperacoesTitulosTipo = BC003213_A1020OperacoesTitulosTipo[0];
            n1020OperacoesTitulosTipo = BC003213_n1020OperacoesTitulosTipo[0];
            A1021OperacoesTitulosNumero = BC003213_A1021OperacoesTitulosNumero[0];
            n1021OperacoesTitulosNumero = BC003213_n1021OperacoesTitulosNumero[0];
            A1022OperacoesTitulosDataEmissao = BC003213_A1022OperacoesTitulosDataEmissao[0];
            n1022OperacoesTitulosDataEmissao = BC003213_n1022OperacoesTitulosDataEmissao[0];
            A1023OperacoesTitulosDataVencimento = BC003213_A1023OperacoesTitulosDataVencimento[0];
            n1023OperacoesTitulosDataVencimento = BC003213_n1023OperacoesTitulosDataVencimento[0];
            A1024OperacoesTitulosValor = BC003213_A1024OperacoesTitulosValor[0];
            n1024OperacoesTitulosValor = BC003213_n1024OperacoesTitulosValor[0];
            A1025OperacoesTitulosLiquido = BC003213_A1025OperacoesTitulosLiquido[0];
            n1025OperacoesTitulosLiquido = BC003213_n1025OperacoesTitulosLiquido[0];
            A1026OperacoesTitulosTaxa = BC003213_A1026OperacoesTitulosTaxa[0];
            n1026OperacoesTitulosTaxa = BC003213_n1026OperacoesTitulosTaxa[0];
            A1027OperacoesTitulosStatus = BC003213_A1027OperacoesTitulosStatus[0];
            n1027OperacoesTitulosStatus = BC003213_n1027OperacoesTitulosStatus[0];
            A1010OperacoesId = BC003213_A1010OperacoesId[0];
            n1010OperacoesId = BC003213_n1010OperacoesId[0];
            A1034SacadoId = BC003213_A1034SacadoId[0];
            n1034SacadoId = BC003213_n1034SacadoId[0];
         }
         Gx_mode = sMode106;
      }

      protected void ScanKeyEnd32106( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm32106( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert32106( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate32106( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete32106( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete32106( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate32106( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes32106( )
      {
      }

      protected void send_integrity_lvl_hashes32106( )
      {
      }

      protected void AddRow32106( )
      {
         VarsToRow106( bcOperacoesTitulos) ;
      }

      protected void ReadRow32106( )
      {
         RowToVars106( bcOperacoesTitulos, 1) ;
      }

      protected void InitializeNonKey32106( )
      {
         A1028OperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         n1028OperacoesTitulosCreatedAt = false;
         A1029OperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         n1029OperacoesTitulosUpdatedAt = false;
         A1010OperacoesId = 0;
         n1010OperacoesId = false;
         A1034SacadoId = 0;
         n1034SacadoId = false;
         A1035SacadoRazaoSocial = "";
         n1035SacadoRazaoSocial = false;
         A1020OperacoesTitulosTipo = "";
         n1020OperacoesTitulosTipo = false;
         A1021OperacoesTitulosNumero = 0;
         n1021OperacoesTitulosNumero = false;
         A1022OperacoesTitulosDataEmissao = DateTime.MinValue;
         n1022OperacoesTitulosDataEmissao = false;
         A1023OperacoesTitulosDataVencimento = DateTime.MinValue;
         n1023OperacoesTitulosDataVencimento = false;
         A1024OperacoesTitulosValor = 0;
         n1024OperacoesTitulosValor = false;
         A1025OperacoesTitulosLiquido = 0;
         n1025OperacoesTitulosLiquido = false;
         A1026OperacoesTitulosTaxa = 0;
         n1026OperacoesTitulosTaxa = false;
         A1027OperacoesTitulosStatus = "";
         n1027OperacoesTitulosStatus = false;
         Z1028OperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         Z1029OperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1020OperacoesTitulosTipo = "";
         Z1021OperacoesTitulosNumero = 0;
         Z1022OperacoesTitulosDataEmissao = DateTime.MinValue;
         Z1023OperacoesTitulosDataVencimento = DateTime.MinValue;
         Z1024OperacoesTitulosValor = 0;
         Z1025OperacoesTitulosLiquido = 0;
         Z1026OperacoesTitulosTaxa = 0;
         Z1027OperacoesTitulosStatus = "";
         Z1010OperacoesId = 0;
         Z1034SacadoId = 0;
      }

      protected void InitAll32106( )
      {
         A1019OperacoesTitulosId = 0;
         InitializeNonKey32106( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1028OperacoesTitulosCreatedAt = i1028OperacoesTitulosCreatedAt;
         n1028OperacoesTitulosCreatedAt = false;
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

      public void VarsToRow106( SdtOperacoesTitulos obj106 )
      {
         obj106.gxTpr_Mode = Gx_mode;
         obj106.gxTpr_Operacoestituloscreatedat = A1028OperacoesTitulosCreatedAt;
         obj106.gxTpr_Operacoestitulosupdatedat = A1029OperacoesTitulosUpdatedAt;
         obj106.gxTpr_Operacoesid = A1010OperacoesId;
         obj106.gxTpr_Sacadoid = A1034SacadoId;
         obj106.gxTpr_Sacadorazaosocial = A1035SacadoRazaoSocial;
         obj106.gxTpr_Operacoestitulostipo = A1020OperacoesTitulosTipo;
         obj106.gxTpr_Operacoestitulosnumero = A1021OperacoesTitulosNumero;
         obj106.gxTpr_Operacoestitulosdataemissao = A1022OperacoesTitulosDataEmissao;
         obj106.gxTpr_Operacoestitulosdatavencimento = A1023OperacoesTitulosDataVencimento;
         obj106.gxTpr_Operacoestitulosvalor = A1024OperacoesTitulosValor;
         obj106.gxTpr_Operacoestitulosliquido = A1025OperacoesTitulosLiquido;
         obj106.gxTpr_Operacoestitulostaxa = A1026OperacoesTitulosTaxa;
         obj106.gxTpr_Operacoestitulosstatus = A1027OperacoesTitulosStatus;
         obj106.gxTpr_Operacoestitulosid = A1019OperacoesTitulosId;
         obj106.gxTpr_Operacoestitulosid_Z = Z1019OperacoesTitulosId;
         obj106.gxTpr_Operacoesid_Z = Z1010OperacoesId;
         obj106.gxTpr_Sacadoid_Z = Z1034SacadoId;
         obj106.gxTpr_Sacadorazaosocial_Z = Z1035SacadoRazaoSocial;
         obj106.gxTpr_Operacoestitulostipo_Z = Z1020OperacoesTitulosTipo;
         obj106.gxTpr_Operacoestitulosnumero_Z = Z1021OperacoesTitulosNumero;
         obj106.gxTpr_Operacoestitulosdataemissao_Z = Z1022OperacoesTitulosDataEmissao;
         obj106.gxTpr_Operacoestitulosdatavencimento_Z = Z1023OperacoesTitulosDataVencimento;
         obj106.gxTpr_Operacoestitulosvalor_Z = Z1024OperacoesTitulosValor;
         obj106.gxTpr_Operacoestitulosliquido_Z = Z1025OperacoesTitulosLiquido;
         obj106.gxTpr_Operacoestitulostaxa_Z = Z1026OperacoesTitulosTaxa;
         obj106.gxTpr_Operacoestitulosstatus_Z = Z1027OperacoesTitulosStatus;
         obj106.gxTpr_Operacoestituloscreatedat_Z = Z1028OperacoesTitulosCreatedAt;
         obj106.gxTpr_Operacoestitulosupdatedat_Z = Z1029OperacoesTitulosUpdatedAt;
         obj106.gxTpr_Operacoesid_N = (short)(Convert.ToInt16(n1010OperacoesId));
         obj106.gxTpr_Sacadoid_N = (short)(Convert.ToInt16(n1034SacadoId));
         obj106.gxTpr_Sacadorazaosocial_N = (short)(Convert.ToInt16(n1035SacadoRazaoSocial));
         obj106.gxTpr_Operacoestitulostipo_N = (short)(Convert.ToInt16(n1020OperacoesTitulosTipo));
         obj106.gxTpr_Operacoestitulosnumero_N = (short)(Convert.ToInt16(n1021OperacoesTitulosNumero));
         obj106.gxTpr_Operacoestitulosdataemissao_N = (short)(Convert.ToInt16(n1022OperacoesTitulosDataEmissao));
         obj106.gxTpr_Operacoestitulosdatavencimento_N = (short)(Convert.ToInt16(n1023OperacoesTitulosDataVencimento));
         obj106.gxTpr_Operacoestitulosvalor_N = (short)(Convert.ToInt16(n1024OperacoesTitulosValor));
         obj106.gxTpr_Operacoestitulosliquido_N = (short)(Convert.ToInt16(n1025OperacoesTitulosLiquido));
         obj106.gxTpr_Operacoestitulostaxa_N = (short)(Convert.ToInt16(n1026OperacoesTitulosTaxa));
         obj106.gxTpr_Operacoestitulosstatus_N = (short)(Convert.ToInt16(n1027OperacoesTitulosStatus));
         obj106.gxTpr_Operacoestituloscreatedat_N = (short)(Convert.ToInt16(n1028OperacoesTitulosCreatedAt));
         obj106.gxTpr_Operacoestitulosupdatedat_N = (short)(Convert.ToInt16(n1029OperacoesTitulosUpdatedAt));
         obj106.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow106( SdtOperacoesTitulos obj106 )
      {
         obj106.gxTpr_Operacoestitulosid = A1019OperacoesTitulosId;
         return  ;
      }

      public void RowToVars106( SdtOperacoesTitulos obj106 ,
                                int forceLoad )
      {
         Gx_mode = obj106.gxTpr_Mode;
         A1028OperacoesTitulosCreatedAt = obj106.gxTpr_Operacoestituloscreatedat;
         n1028OperacoesTitulosCreatedAt = false;
         A1029OperacoesTitulosUpdatedAt = obj106.gxTpr_Operacoestitulosupdatedat;
         n1029OperacoesTitulosUpdatedAt = false;
         A1010OperacoesId = obj106.gxTpr_Operacoesid;
         n1010OperacoesId = false;
         A1034SacadoId = obj106.gxTpr_Sacadoid;
         n1034SacadoId = false;
         A1035SacadoRazaoSocial = obj106.gxTpr_Sacadorazaosocial;
         n1035SacadoRazaoSocial = false;
         A1020OperacoesTitulosTipo = obj106.gxTpr_Operacoestitulostipo;
         n1020OperacoesTitulosTipo = false;
         A1021OperacoesTitulosNumero = obj106.gxTpr_Operacoestitulosnumero;
         n1021OperacoesTitulosNumero = false;
         A1022OperacoesTitulosDataEmissao = obj106.gxTpr_Operacoestitulosdataemissao;
         n1022OperacoesTitulosDataEmissao = false;
         A1023OperacoesTitulosDataVencimento = obj106.gxTpr_Operacoestitulosdatavencimento;
         n1023OperacoesTitulosDataVencimento = false;
         A1024OperacoesTitulosValor = obj106.gxTpr_Operacoestitulosvalor;
         n1024OperacoesTitulosValor = false;
         A1025OperacoesTitulosLiquido = obj106.gxTpr_Operacoestitulosliquido;
         n1025OperacoesTitulosLiquido = false;
         A1026OperacoesTitulosTaxa = obj106.gxTpr_Operacoestitulostaxa;
         n1026OperacoesTitulosTaxa = false;
         A1027OperacoesTitulosStatus = obj106.gxTpr_Operacoestitulosstatus;
         n1027OperacoesTitulosStatus = false;
         A1019OperacoesTitulosId = obj106.gxTpr_Operacoestitulosid;
         Z1019OperacoesTitulosId = obj106.gxTpr_Operacoestitulosid_Z;
         Z1010OperacoesId = obj106.gxTpr_Operacoesid_Z;
         Z1034SacadoId = obj106.gxTpr_Sacadoid_Z;
         Z1035SacadoRazaoSocial = obj106.gxTpr_Sacadorazaosocial_Z;
         Z1020OperacoesTitulosTipo = obj106.gxTpr_Operacoestitulostipo_Z;
         Z1021OperacoesTitulosNumero = obj106.gxTpr_Operacoestitulosnumero_Z;
         Z1022OperacoesTitulosDataEmissao = obj106.gxTpr_Operacoestitulosdataemissao_Z;
         Z1023OperacoesTitulosDataVencimento = obj106.gxTpr_Operacoestitulosdatavencimento_Z;
         Z1024OperacoesTitulosValor = obj106.gxTpr_Operacoestitulosvalor_Z;
         Z1025OperacoesTitulosLiquido = obj106.gxTpr_Operacoestitulosliquido_Z;
         Z1026OperacoesTitulosTaxa = obj106.gxTpr_Operacoestitulostaxa_Z;
         Z1027OperacoesTitulosStatus = obj106.gxTpr_Operacoestitulosstatus_Z;
         Z1028OperacoesTitulosCreatedAt = obj106.gxTpr_Operacoestituloscreatedat_Z;
         Z1029OperacoesTitulosUpdatedAt = obj106.gxTpr_Operacoestitulosupdatedat_Z;
         n1010OperacoesId = (bool)(Convert.ToBoolean(obj106.gxTpr_Operacoesid_N));
         n1034SacadoId = (bool)(Convert.ToBoolean(obj106.gxTpr_Sacadoid_N));
         n1035SacadoRazaoSocial = (bool)(Convert.ToBoolean(obj106.gxTpr_Sacadorazaosocial_N));
         n1020OperacoesTitulosTipo = (bool)(Convert.ToBoolean(obj106.gxTpr_Operacoestitulostipo_N));
         n1021OperacoesTitulosNumero = (bool)(Convert.ToBoolean(obj106.gxTpr_Operacoestitulosnumero_N));
         n1022OperacoesTitulosDataEmissao = (bool)(Convert.ToBoolean(obj106.gxTpr_Operacoestitulosdataemissao_N));
         n1023OperacoesTitulosDataVencimento = (bool)(Convert.ToBoolean(obj106.gxTpr_Operacoestitulosdatavencimento_N));
         n1024OperacoesTitulosValor = (bool)(Convert.ToBoolean(obj106.gxTpr_Operacoestitulosvalor_N));
         n1025OperacoesTitulosLiquido = (bool)(Convert.ToBoolean(obj106.gxTpr_Operacoestitulosliquido_N));
         n1026OperacoesTitulosTaxa = (bool)(Convert.ToBoolean(obj106.gxTpr_Operacoestitulostaxa_N));
         n1027OperacoesTitulosStatus = (bool)(Convert.ToBoolean(obj106.gxTpr_Operacoestitulosstatus_N));
         n1028OperacoesTitulosCreatedAt = (bool)(Convert.ToBoolean(obj106.gxTpr_Operacoestituloscreatedat_N));
         n1029OperacoesTitulosUpdatedAt = (bool)(Convert.ToBoolean(obj106.gxTpr_Operacoestitulosupdatedat_N));
         Gx_mode = obj106.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1019OperacoesTitulosId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey32106( ) ;
         ScanKeyStart32106( ) ;
         if ( RcdFound106 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1019OperacoesTitulosId = A1019OperacoesTitulosId;
         }
         ZM32106( -12) ;
         OnLoadActions32106( ) ;
         AddRow32106( ) ;
         ScanKeyEnd32106( ) ;
         if ( RcdFound106 == 0 )
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
         RowToVars106( bcOperacoesTitulos, 0) ;
         ScanKeyStart32106( ) ;
         if ( RcdFound106 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1019OperacoesTitulosId = A1019OperacoesTitulosId;
         }
         ZM32106( -12) ;
         OnLoadActions32106( ) ;
         AddRow32106( ) ;
         ScanKeyEnd32106( ) ;
         if ( RcdFound106 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey32106( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert32106( ) ;
         }
         else
         {
            if ( RcdFound106 == 1 )
            {
               if ( A1019OperacoesTitulosId != Z1019OperacoesTitulosId )
               {
                  A1019OperacoesTitulosId = Z1019OperacoesTitulosId;
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
                  Update32106( ) ;
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
                  if ( A1019OperacoesTitulosId != Z1019OperacoesTitulosId )
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
                        Insert32106( ) ;
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
                        Insert32106( ) ;
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
         RowToVars106( bcOperacoesTitulos, 1) ;
         SaveImpl( ) ;
         VarsToRow106( bcOperacoesTitulos) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars106( bcOperacoesTitulos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert32106( ) ;
         AfterTrn( ) ;
         VarsToRow106( bcOperacoesTitulos) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow106( bcOperacoesTitulos) ;
         }
         else
         {
            SdtOperacoesTitulos auxBC = new SdtOperacoesTitulos(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1019OperacoesTitulosId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcOperacoesTitulos);
               auxBC.Save();
               bcOperacoesTitulos.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars106( bcOperacoesTitulos, 1) ;
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
         RowToVars106( bcOperacoesTitulos, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert32106( ) ;
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
               VarsToRow106( bcOperacoesTitulos) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow106( bcOperacoesTitulos) ;
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
         RowToVars106( bcOperacoesTitulos, 0) ;
         GetKey32106( ) ;
         if ( RcdFound106 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1019OperacoesTitulosId != Z1019OperacoesTitulosId )
            {
               A1019OperacoesTitulosId = Z1019OperacoesTitulosId;
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
            if ( A1019OperacoesTitulosId != Z1019OperacoesTitulosId )
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
         context.RollbackDataStores("operacoestitulos_bc",pr_default);
         VarsToRow106( bcOperacoesTitulos) ;
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
         Gx_mode = bcOperacoesTitulos.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcOperacoesTitulos.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcOperacoesTitulos )
         {
            bcOperacoesTitulos = (SdtOperacoesTitulos)(sdt);
            if ( StringUtil.StrCmp(bcOperacoesTitulos.gxTpr_Mode, "") == 0 )
            {
               bcOperacoesTitulos.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow106( bcOperacoesTitulos) ;
            }
            else
            {
               RowToVars106( bcOperacoesTitulos, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcOperacoesTitulos.gxTpr_Mode, "") == 0 )
            {
               bcOperacoesTitulos.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars106( bcOperacoesTitulos, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtOperacoesTitulos OperacoesTitulos_BC
      {
         get {
            return bcOperacoesTitulos ;
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
         pr_default.close(10);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV23Pgmname = "";
         AV12TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         A1035SacadoRazaoSocial = "";
         Z1028OperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         A1028OperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         Z1029OperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         A1029OperacoesTitulosUpdatedAt = (DateTime)(DateTime.MinValue);
         Z1020OperacoesTitulosTipo = "";
         A1020OperacoesTitulosTipo = "";
         Z1022OperacoesTitulosDataEmissao = DateTime.MinValue;
         A1022OperacoesTitulosDataEmissao = DateTime.MinValue;
         Z1023OperacoesTitulosDataVencimento = DateTime.MinValue;
         A1023OperacoesTitulosDataVencimento = DateTime.MinValue;
         Z1027OperacoesTitulosStatus = "";
         A1027OperacoesTitulosStatus = "";
         Z1035SacadoRazaoSocial = "";
         BC00326_A1019OperacoesTitulosId = new int[1] ;
         BC00326_A1028OperacoesTitulosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00326_n1028OperacoesTitulosCreatedAt = new bool[] {false} ;
         BC00326_A1029OperacoesTitulosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00326_n1029OperacoesTitulosUpdatedAt = new bool[] {false} ;
         BC00326_A1035SacadoRazaoSocial = new string[] {""} ;
         BC00326_n1035SacadoRazaoSocial = new bool[] {false} ;
         BC00326_A1020OperacoesTitulosTipo = new string[] {""} ;
         BC00326_n1020OperacoesTitulosTipo = new bool[] {false} ;
         BC00326_A1021OperacoesTitulosNumero = new int[1] ;
         BC00326_n1021OperacoesTitulosNumero = new bool[] {false} ;
         BC00326_A1022OperacoesTitulosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         BC00326_n1022OperacoesTitulosDataEmissao = new bool[] {false} ;
         BC00326_A1023OperacoesTitulosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         BC00326_n1023OperacoesTitulosDataVencimento = new bool[] {false} ;
         BC00326_A1024OperacoesTitulosValor = new decimal[1] ;
         BC00326_n1024OperacoesTitulosValor = new bool[] {false} ;
         BC00326_A1025OperacoesTitulosLiquido = new decimal[1] ;
         BC00326_n1025OperacoesTitulosLiquido = new bool[] {false} ;
         BC00326_A1026OperacoesTitulosTaxa = new decimal[1] ;
         BC00326_n1026OperacoesTitulosTaxa = new bool[] {false} ;
         BC00326_A1027OperacoesTitulosStatus = new string[] {""} ;
         BC00326_n1027OperacoesTitulosStatus = new bool[] {false} ;
         BC00326_A1010OperacoesId = new int[1] ;
         BC00326_n1010OperacoesId = new bool[] {false} ;
         BC00326_A1034SacadoId = new int[1] ;
         BC00326_n1034SacadoId = new bool[] {false} ;
         BC00324_A1010OperacoesId = new int[1] ;
         BC00324_n1010OperacoesId = new bool[] {false} ;
         BC00325_A1035SacadoRazaoSocial = new string[] {""} ;
         BC00325_n1035SacadoRazaoSocial = new bool[] {false} ;
         BC00327_A1019OperacoesTitulosId = new int[1] ;
         BC00323_A1019OperacoesTitulosId = new int[1] ;
         BC00323_A1028OperacoesTitulosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00323_n1028OperacoesTitulosCreatedAt = new bool[] {false} ;
         BC00323_A1029OperacoesTitulosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00323_n1029OperacoesTitulosUpdatedAt = new bool[] {false} ;
         BC00323_A1020OperacoesTitulosTipo = new string[] {""} ;
         BC00323_n1020OperacoesTitulosTipo = new bool[] {false} ;
         BC00323_A1021OperacoesTitulosNumero = new int[1] ;
         BC00323_n1021OperacoesTitulosNumero = new bool[] {false} ;
         BC00323_A1022OperacoesTitulosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         BC00323_n1022OperacoesTitulosDataEmissao = new bool[] {false} ;
         BC00323_A1023OperacoesTitulosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         BC00323_n1023OperacoesTitulosDataVencimento = new bool[] {false} ;
         BC00323_A1024OperacoesTitulosValor = new decimal[1] ;
         BC00323_n1024OperacoesTitulosValor = new bool[] {false} ;
         BC00323_A1025OperacoesTitulosLiquido = new decimal[1] ;
         BC00323_n1025OperacoesTitulosLiquido = new bool[] {false} ;
         BC00323_A1026OperacoesTitulosTaxa = new decimal[1] ;
         BC00323_n1026OperacoesTitulosTaxa = new bool[] {false} ;
         BC00323_A1027OperacoesTitulosStatus = new string[] {""} ;
         BC00323_n1027OperacoesTitulosStatus = new bool[] {false} ;
         BC00323_A1010OperacoesId = new int[1] ;
         BC00323_n1010OperacoesId = new bool[] {false} ;
         BC00323_A1034SacadoId = new int[1] ;
         BC00323_n1034SacadoId = new bool[] {false} ;
         sMode106 = "";
         BC00322_A1019OperacoesTitulosId = new int[1] ;
         BC00322_A1028OperacoesTitulosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00322_n1028OperacoesTitulosCreatedAt = new bool[] {false} ;
         BC00322_A1029OperacoesTitulosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00322_n1029OperacoesTitulosUpdatedAt = new bool[] {false} ;
         BC00322_A1020OperacoesTitulosTipo = new string[] {""} ;
         BC00322_n1020OperacoesTitulosTipo = new bool[] {false} ;
         BC00322_A1021OperacoesTitulosNumero = new int[1] ;
         BC00322_n1021OperacoesTitulosNumero = new bool[] {false} ;
         BC00322_A1022OperacoesTitulosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         BC00322_n1022OperacoesTitulosDataEmissao = new bool[] {false} ;
         BC00322_A1023OperacoesTitulosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         BC00322_n1023OperacoesTitulosDataVencimento = new bool[] {false} ;
         BC00322_A1024OperacoesTitulosValor = new decimal[1] ;
         BC00322_n1024OperacoesTitulosValor = new bool[] {false} ;
         BC00322_A1025OperacoesTitulosLiquido = new decimal[1] ;
         BC00322_n1025OperacoesTitulosLiquido = new bool[] {false} ;
         BC00322_A1026OperacoesTitulosTaxa = new decimal[1] ;
         BC00322_n1026OperacoesTitulosTaxa = new bool[] {false} ;
         BC00322_A1027OperacoesTitulosStatus = new string[] {""} ;
         BC00322_n1027OperacoesTitulosStatus = new bool[] {false} ;
         BC00322_A1010OperacoesId = new int[1] ;
         BC00322_n1010OperacoesId = new bool[] {false} ;
         BC00322_A1034SacadoId = new int[1] ;
         BC00322_n1034SacadoId = new bool[] {false} ;
         BC00329_A1019OperacoesTitulosId = new int[1] ;
         BC003212_A1035SacadoRazaoSocial = new string[] {""} ;
         BC003212_n1035SacadoRazaoSocial = new bool[] {false} ;
         BC003213_A1019OperacoesTitulosId = new int[1] ;
         BC003213_A1028OperacoesTitulosCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003213_n1028OperacoesTitulosCreatedAt = new bool[] {false} ;
         BC003213_A1029OperacoesTitulosUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC003213_n1029OperacoesTitulosUpdatedAt = new bool[] {false} ;
         BC003213_A1035SacadoRazaoSocial = new string[] {""} ;
         BC003213_n1035SacadoRazaoSocial = new bool[] {false} ;
         BC003213_A1020OperacoesTitulosTipo = new string[] {""} ;
         BC003213_n1020OperacoesTitulosTipo = new bool[] {false} ;
         BC003213_A1021OperacoesTitulosNumero = new int[1] ;
         BC003213_n1021OperacoesTitulosNumero = new bool[] {false} ;
         BC003213_A1022OperacoesTitulosDataEmissao = new DateTime[] {DateTime.MinValue} ;
         BC003213_n1022OperacoesTitulosDataEmissao = new bool[] {false} ;
         BC003213_A1023OperacoesTitulosDataVencimento = new DateTime[] {DateTime.MinValue} ;
         BC003213_n1023OperacoesTitulosDataVencimento = new bool[] {false} ;
         BC003213_A1024OperacoesTitulosValor = new decimal[1] ;
         BC003213_n1024OperacoesTitulosValor = new bool[] {false} ;
         BC003213_A1025OperacoesTitulosLiquido = new decimal[1] ;
         BC003213_n1025OperacoesTitulosLiquido = new bool[] {false} ;
         BC003213_A1026OperacoesTitulosTaxa = new decimal[1] ;
         BC003213_n1026OperacoesTitulosTaxa = new bool[] {false} ;
         BC003213_A1027OperacoesTitulosStatus = new string[] {""} ;
         BC003213_n1027OperacoesTitulosStatus = new bool[] {false} ;
         BC003213_A1010OperacoesId = new int[1] ;
         BC003213_n1010OperacoesId = new bool[] {false} ;
         BC003213_A1034SacadoId = new int[1] ;
         BC003213_n1034SacadoId = new bool[] {false} ;
         i1028OperacoesTitulosCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacoestitulos_bc__default(),
            new Object[][] {
                new Object[] {
               BC00322_A1019OperacoesTitulosId, BC00322_A1028OperacoesTitulosCreatedAt, BC00322_n1028OperacoesTitulosCreatedAt, BC00322_A1029OperacoesTitulosUpdatedAt, BC00322_n1029OperacoesTitulosUpdatedAt, BC00322_A1020OperacoesTitulosTipo, BC00322_n1020OperacoesTitulosTipo, BC00322_A1021OperacoesTitulosNumero, BC00322_n1021OperacoesTitulosNumero, BC00322_A1022OperacoesTitulosDataEmissao,
               BC00322_n1022OperacoesTitulosDataEmissao, BC00322_A1023OperacoesTitulosDataVencimento, BC00322_n1023OperacoesTitulosDataVencimento, BC00322_A1024OperacoesTitulosValor, BC00322_n1024OperacoesTitulosValor, BC00322_A1025OperacoesTitulosLiquido, BC00322_n1025OperacoesTitulosLiquido, BC00322_A1026OperacoesTitulosTaxa, BC00322_n1026OperacoesTitulosTaxa, BC00322_A1027OperacoesTitulosStatus,
               BC00322_n1027OperacoesTitulosStatus, BC00322_A1010OperacoesId, BC00322_n1010OperacoesId, BC00322_A1034SacadoId, BC00322_n1034SacadoId
               }
               , new Object[] {
               BC00323_A1019OperacoesTitulosId, BC00323_A1028OperacoesTitulosCreatedAt, BC00323_n1028OperacoesTitulosCreatedAt, BC00323_A1029OperacoesTitulosUpdatedAt, BC00323_n1029OperacoesTitulosUpdatedAt, BC00323_A1020OperacoesTitulosTipo, BC00323_n1020OperacoesTitulosTipo, BC00323_A1021OperacoesTitulosNumero, BC00323_n1021OperacoesTitulosNumero, BC00323_A1022OperacoesTitulosDataEmissao,
               BC00323_n1022OperacoesTitulosDataEmissao, BC00323_A1023OperacoesTitulosDataVencimento, BC00323_n1023OperacoesTitulosDataVencimento, BC00323_A1024OperacoesTitulosValor, BC00323_n1024OperacoesTitulosValor, BC00323_A1025OperacoesTitulosLiquido, BC00323_n1025OperacoesTitulosLiquido, BC00323_A1026OperacoesTitulosTaxa, BC00323_n1026OperacoesTitulosTaxa, BC00323_A1027OperacoesTitulosStatus,
               BC00323_n1027OperacoesTitulosStatus, BC00323_A1010OperacoesId, BC00323_n1010OperacoesId, BC00323_A1034SacadoId, BC00323_n1034SacadoId
               }
               , new Object[] {
               BC00324_A1010OperacoesId
               }
               , new Object[] {
               BC00325_A1035SacadoRazaoSocial, BC00325_n1035SacadoRazaoSocial
               }
               , new Object[] {
               BC00326_A1019OperacoesTitulosId, BC00326_A1028OperacoesTitulosCreatedAt, BC00326_n1028OperacoesTitulosCreatedAt, BC00326_A1029OperacoesTitulosUpdatedAt, BC00326_n1029OperacoesTitulosUpdatedAt, BC00326_A1035SacadoRazaoSocial, BC00326_n1035SacadoRazaoSocial, BC00326_A1020OperacoesTitulosTipo, BC00326_n1020OperacoesTitulosTipo, BC00326_A1021OperacoesTitulosNumero,
               BC00326_n1021OperacoesTitulosNumero, BC00326_A1022OperacoesTitulosDataEmissao, BC00326_n1022OperacoesTitulosDataEmissao, BC00326_A1023OperacoesTitulosDataVencimento, BC00326_n1023OperacoesTitulosDataVencimento, BC00326_A1024OperacoesTitulosValor, BC00326_n1024OperacoesTitulosValor, BC00326_A1025OperacoesTitulosLiquido, BC00326_n1025OperacoesTitulosLiquido, BC00326_A1026OperacoesTitulosTaxa,
               BC00326_n1026OperacoesTitulosTaxa, BC00326_A1027OperacoesTitulosStatus, BC00326_n1027OperacoesTitulosStatus, BC00326_A1010OperacoesId, BC00326_n1010OperacoesId, BC00326_A1034SacadoId, BC00326_n1034SacadoId
               }
               , new Object[] {
               BC00327_A1019OperacoesTitulosId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00329_A1019OperacoesTitulosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC003212_A1035SacadoRazaoSocial, BC003212_n1035SacadoRazaoSocial
               }
               , new Object[] {
               BC003213_A1019OperacoesTitulosId, BC003213_A1028OperacoesTitulosCreatedAt, BC003213_n1028OperacoesTitulosCreatedAt, BC003213_A1029OperacoesTitulosUpdatedAt, BC003213_n1029OperacoesTitulosUpdatedAt, BC003213_A1035SacadoRazaoSocial, BC003213_n1035SacadoRazaoSocial, BC003213_A1020OperacoesTitulosTipo, BC003213_n1020OperacoesTitulosTipo, BC003213_A1021OperacoesTitulosNumero,
               BC003213_n1021OperacoesTitulosNumero, BC003213_A1022OperacoesTitulosDataEmissao, BC003213_n1022OperacoesTitulosDataEmissao, BC003213_A1023OperacoesTitulosDataVencimento, BC003213_n1023OperacoesTitulosDataVencimento, BC003213_A1024OperacoesTitulosValor, BC003213_n1024OperacoesTitulosValor, BC003213_A1025OperacoesTitulosLiquido, BC003213_n1025OperacoesTitulosLiquido, BC003213_A1026OperacoesTitulosTaxa,
               BC003213_n1026OperacoesTitulosTaxa, BC003213_A1027OperacoesTitulosStatus, BC003213_n1027OperacoesTitulosStatus, BC003213_A1010OperacoesId, BC003213_n1010OperacoesId, BC003213_A1034SacadoId, BC003213_n1034SacadoId
               }
            }
         );
         AV23Pgmname = "OperacoesTitulos_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12322 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short RcdFound106 ;
      private int trnEnded ;
      private int Z1019OperacoesTitulosId ;
      private int A1019OperacoesTitulosId ;
      private int AV24GXV1 ;
      private int AV11Insert_OperacoesId ;
      private int AV20Insert_SacadoId ;
      private int A1034SacadoId ;
      private int Z1021OperacoesTitulosNumero ;
      private int A1021OperacoesTitulosNumero ;
      private int Z1010OperacoesId ;
      private int A1010OperacoesId ;
      private int Z1034SacadoId ;
      private decimal Z1024OperacoesTitulosValor ;
      private decimal A1024OperacoesTitulosValor ;
      private decimal Z1025OperacoesTitulosLiquido ;
      private decimal A1025OperacoesTitulosLiquido ;
      private decimal Z1026OperacoesTitulosTaxa ;
      private decimal A1026OperacoesTitulosTaxa ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV23Pgmname ;
      private string sMode106 ;
      private DateTime Z1028OperacoesTitulosCreatedAt ;
      private DateTime A1028OperacoesTitulosCreatedAt ;
      private DateTime Z1029OperacoesTitulosUpdatedAt ;
      private DateTime A1029OperacoesTitulosUpdatedAt ;
      private DateTime i1028OperacoesTitulosCreatedAt ;
      private DateTime Z1022OperacoesTitulosDataEmissao ;
      private DateTime A1022OperacoesTitulosDataEmissao ;
      private DateTime Z1023OperacoesTitulosDataVencimento ;
      private DateTime A1023OperacoesTitulosDataVencimento ;
      private bool returnInSub ;
      private bool n1028OperacoesTitulosCreatedAt ;
      private bool n1029OperacoesTitulosUpdatedAt ;
      private bool n1035SacadoRazaoSocial ;
      private bool n1020OperacoesTitulosTipo ;
      private bool n1021OperacoesTitulosNumero ;
      private bool n1022OperacoesTitulosDataEmissao ;
      private bool n1023OperacoesTitulosDataVencimento ;
      private bool n1024OperacoesTitulosValor ;
      private bool n1025OperacoesTitulosLiquido ;
      private bool n1026OperacoesTitulosTaxa ;
      private bool n1027OperacoesTitulosStatus ;
      private bool n1010OperacoesId ;
      private bool n1034SacadoId ;
      private bool Gx_longc ;
      private string A1035SacadoRazaoSocial ;
      private string Z1020OperacoesTitulosTipo ;
      private string A1020OperacoesTitulosTipo ;
      private string Z1027OperacoesTitulosStatus ;
      private string A1027OperacoesTitulosStatus ;
      private string Z1035SacadoRazaoSocial ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC00326_A1019OperacoesTitulosId ;
      private DateTime[] BC00326_A1028OperacoesTitulosCreatedAt ;
      private bool[] BC00326_n1028OperacoesTitulosCreatedAt ;
      private DateTime[] BC00326_A1029OperacoesTitulosUpdatedAt ;
      private bool[] BC00326_n1029OperacoesTitulosUpdatedAt ;
      private string[] BC00326_A1035SacadoRazaoSocial ;
      private bool[] BC00326_n1035SacadoRazaoSocial ;
      private string[] BC00326_A1020OperacoesTitulosTipo ;
      private bool[] BC00326_n1020OperacoesTitulosTipo ;
      private int[] BC00326_A1021OperacoesTitulosNumero ;
      private bool[] BC00326_n1021OperacoesTitulosNumero ;
      private DateTime[] BC00326_A1022OperacoesTitulosDataEmissao ;
      private bool[] BC00326_n1022OperacoesTitulosDataEmissao ;
      private DateTime[] BC00326_A1023OperacoesTitulosDataVencimento ;
      private bool[] BC00326_n1023OperacoesTitulosDataVencimento ;
      private decimal[] BC00326_A1024OperacoesTitulosValor ;
      private bool[] BC00326_n1024OperacoesTitulosValor ;
      private decimal[] BC00326_A1025OperacoesTitulosLiquido ;
      private bool[] BC00326_n1025OperacoesTitulosLiquido ;
      private decimal[] BC00326_A1026OperacoesTitulosTaxa ;
      private bool[] BC00326_n1026OperacoesTitulosTaxa ;
      private string[] BC00326_A1027OperacoesTitulosStatus ;
      private bool[] BC00326_n1027OperacoesTitulosStatus ;
      private int[] BC00326_A1010OperacoesId ;
      private bool[] BC00326_n1010OperacoesId ;
      private int[] BC00326_A1034SacadoId ;
      private bool[] BC00326_n1034SacadoId ;
      private int[] BC00324_A1010OperacoesId ;
      private bool[] BC00324_n1010OperacoesId ;
      private string[] BC00325_A1035SacadoRazaoSocial ;
      private bool[] BC00325_n1035SacadoRazaoSocial ;
      private int[] BC00327_A1019OperacoesTitulosId ;
      private int[] BC00323_A1019OperacoesTitulosId ;
      private DateTime[] BC00323_A1028OperacoesTitulosCreatedAt ;
      private bool[] BC00323_n1028OperacoesTitulosCreatedAt ;
      private DateTime[] BC00323_A1029OperacoesTitulosUpdatedAt ;
      private bool[] BC00323_n1029OperacoesTitulosUpdatedAt ;
      private string[] BC00323_A1020OperacoesTitulosTipo ;
      private bool[] BC00323_n1020OperacoesTitulosTipo ;
      private int[] BC00323_A1021OperacoesTitulosNumero ;
      private bool[] BC00323_n1021OperacoesTitulosNumero ;
      private DateTime[] BC00323_A1022OperacoesTitulosDataEmissao ;
      private bool[] BC00323_n1022OperacoesTitulosDataEmissao ;
      private DateTime[] BC00323_A1023OperacoesTitulosDataVencimento ;
      private bool[] BC00323_n1023OperacoesTitulosDataVencimento ;
      private decimal[] BC00323_A1024OperacoesTitulosValor ;
      private bool[] BC00323_n1024OperacoesTitulosValor ;
      private decimal[] BC00323_A1025OperacoesTitulosLiquido ;
      private bool[] BC00323_n1025OperacoesTitulosLiquido ;
      private decimal[] BC00323_A1026OperacoesTitulosTaxa ;
      private bool[] BC00323_n1026OperacoesTitulosTaxa ;
      private string[] BC00323_A1027OperacoesTitulosStatus ;
      private bool[] BC00323_n1027OperacoesTitulosStatus ;
      private int[] BC00323_A1010OperacoesId ;
      private bool[] BC00323_n1010OperacoesId ;
      private int[] BC00323_A1034SacadoId ;
      private bool[] BC00323_n1034SacadoId ;
      private int[] BC00322_A1019OperacoesTitulosId ;
      private DateTime[] BC00322_A1028OperacoesTitulosCreatedAt ;
      private bool[] BC00322_n1028OperacoesTitulosCreatedAt ;
      private DateTime[] BC00322_A1029OperacoesTitulosUpdatedAt ;
      private bool[] BC00322_n1029OperacoesTitulosUpdatedAt ;
      private string[] BC00322_A1020OperacoesTitulosTipo ;
      private bool[] BC00322_n1020OperacoesTitulosTipo ;
      private int[] BC00322_A1021OperacoesTitulosNumero ;
      private bool[] BC00322_n1021OperacoesTitulosNumero ;
      private DateTime[] BC00322_A1022OperacoesTitulosDataEmissao ;
      private bool[] BC00322_n1022OperacoesTitulosDataEmissao ;
      private DateTime[] BC00322_A1023OperacoesTitulosDataVencimento ;
      private bool[] BC00322_n1023OperacoesTitulosDataVencimento ;
      private decimal[] BC00322_A1024OperacoesTitulosValor ;
      private bool[] BC00322_n1024OperacoesTitulosValor ;
      private decimal[] BC00322_A1025OperacoesTitulosLiquido ;
      private bool[] BC00322_n1025OperacoesTitulosLiquido ;
      private decimal[] BC00322_A1026OperacoesTitulosTaxa ;
      private bool[] BC00322_n1026OperacoesTitulosTaxa ;
      private string[] BC00322_A1027OperacoesTitulosStatus ;
      private bool[] BC00322_n1027OperacoesTitulosStatus ;
      private int[] BC00322_A1010OperacoesId ;
      private bool[] BC00322_n1010OperacoesId ;
      private int[] BC00322_A1034SacadoId ;
      private bool[] BC00322_n1034SacadoId ;
      private int[] BC00329_A1019OperacoesTitulosId ;
      private string[] BC003212_A1035SacadoRazaoSocial ;
      private bool[] BC003212_n1035SacadoRazaoSocial ;
      private int[] BC003213_A1019OperacoesTitulosId ;
      private DateTime[] BC003213_A1028OperacoesTitulosCreatedAt ;
      private bool[] BC003213_n1028OperacoesTitulosCreatedAt ;
      private DateTime[] BC003213_A1029OperacoesTitulosUpdatedAt ;
      private bool[] BC003213_n1029OperacoesTitulosUpdatedAt ;
      private string[] BC003213_A1035SacadoRazaoSocial ;
      private bool[] BC003213_n1035SacadoRazaoSocial ;
      private string[] BC003213_A1020OperacoesTitulosTipo ;
      private bool[] BC003213_n1020OperacoesTitulosTipo ;
      private int[] BC003213_A1021OperacoesTitulosNumero ;
      private bool[] BC003213_n1021OperacoesTitulosNumero ;
      private DateTime[] BC003213_A1022OperacoesTitulosDataEmissao ;
      private bool[] BC003213_n1022OperacoesTitulosDataEmissao ;
      private DateTime[] BC003213_A1023OperacoesTitulosDataVencimento ;
      private bool[] BC003213_n1023OperacoesTitulosDataVencimento ;
      private decimal[] BC003213_A1024OperacoesTitulosValor ;
      private bool[] BC003213_n1024OperacoesTitulosValor ;
      private decimal[] BC003213_A1025OperacoesTitulosLiquido ;
      private bool[] BC003213_n1025OperacoesTitulosLiquido ;
      private decimal[] BC003213_A1026OperacoesTitulosTaxa ;
      private bool[] BC003213_n1026OperacoesTitulosTaxa ;
      private string[] BC003213_A1027OperacoesTitulosStatus ;
      private bool[] BC003213_n1027OperacoesTitulosStatus ;
      private int[] BC003213_A1010OperacoesId ;
      private bool[] BC003213_n1010OperacoesId ;
      private int[] BC003213_A1034SacadoId ;
      private bool[] BC003213_n1034SacadoId ;
      private SdtOperacoesTitulos bcOperacoesTitulos ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class operacoestitulos_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00322;
          prmBC00322 = new Object[] {
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmBC00323;
          prmBC00323 = new Object[] {
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmBC00324;
          prmBC00324 = new Object[] {
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00325;
          prmBC00325 = new Object[] {
          new ParDef("SacadoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00326;
          prmBC00326 = new Object[] {
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmBC00327;
          prmBC00327 = new Object[] {
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmBC00328;
          prmBC00328 = new Object[] {
          new ParDef("OperacoesTitulosCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("OperacoesTitulosUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("OperacoesTitulosTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTitulosNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("OperacoesTitulosDataEmissao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("OperacoesTitulosDataVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("OperacoesTitulosValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("OperacoesTitulosLiquido",GXType.Number,18,2){Nullable=true} ,
          new ParDef("OperacoesTitulosTaxa",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesTitulosStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SacadoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00329;
          prmBC00329 = new Object[] {
          };
          Object[] prmBC003210;
          prmBC003210 = new Object[] {
          new ParDef("OperacoesTitulosCreatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("OperacoesTitulosUpdatedAt",GXType.DateTime,8,5){Nullable=true} ,
          new ParDef("OperacoesTitulosTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesTitulosNumero",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("OperacoesTitulosDataEmissao",GXType.Date,8,0){Nullable=true} ,
          new ParDef("OperacoesTitulosDataVencimento",GXType.Date,8,0){Nullable=true} ,
          new ParDef("OperacoesTitulosValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("OperacoesTitulosLiquido",GXType.Number,18,2){Nullable=true} ,
          new ParDef("OperacoesTitulosTaxa",GXType.Number,16,4){Nullable=true} ,
          new ParDef("OperacoesTitulosStatus",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("OperacoesId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("SacadoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmBC003211;
          prmBC003211 = new Object[] {
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          Object[] prmBC003212;
          prmBC003212 = new Object[] {
          new ParDef("SacadoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC003213;
          prmBC003213 = new Object[] {
          new ParDef("OperacoesTitulosId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00322", "SELECT OperacoesTitulosId, OperacoesTitulosCreatedAt, OperacoesTitulosUpdatedAt, OperacoesTitulosTipo, OperacoesTitulosNumero, OperacoesTitulosDataEmissao, OperacoesTitulosDataVencimento, OperacoesTitulosValor, OperacoesTitulosLiquido, OperacoesTitulosTaxa, OperacoesTitulosStatus, OperacoesId, SacadoId FROM OperacoesTitulos WHERE OperacoesTitulosId = :OperacoesTitulosId  FOR UPDATE OF OperacoesTitulos",true, GxErrorMask.GX_NOMASK, false, this,prmBC00322,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00323", "SELECT OperacoesTitulosId, OperacoesTitulosCreatedAt, OperacoesTitulosUpdatedAt, OperacoesTitulosTipo, OperacoesTitulosNumero, OperacoesTitulosDataEmissao, OperacoesTitulosDataVencimento, OperacoesTitulosValor, OperacoesTitulosLiquido, OperacoesTitulosTaxa, OperacoesTitulosStatus, OperacoesId, SacadoId FROM OperacoesTitulos WHERE OperacoesTitulosId = :OperacoesTitulosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00323,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00324", "SELECT OperacoesId FROM Operacoes WHERE OperacoesId = :OperacoesId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00324,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00325", "SELECT ClienteRazaoSocial AS SacadoRazaoSocial FROM Cliente WHERE ClienteId = :SacadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00325,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00326", "SELECT TM1.OperacoesTitulosId, TM1.OperacoesTitulosCreatedAt, TM1.OperacoesTitulosUpdatedAt, T2.ClienteRazaoSocial AS SacadoRazaoSocial, TM1.OperacoesTitulosTipo, TM1.OperacoesTitulosNumero, TM1.OperacoesTitulosDataEmissao, TM1.OperacoesTitulosDataVencimento, TM1.OperacoesTitulosValor, TM1.OperacoesTitulosLiquido, TM1.OperacoesTitulosTaxa, TM1.OperacoesTitulosStatus, TM1.OperacoesId, TM1.SacadoId AS SacadoId FROM (OperacoesTitulos TM1 LEFT JOIN Cliente T2 ON T2.ClienteId = TM1.SacadoId) WHERE TM1.OperacoesTitulosId = :OperacoesTitulosId ORDER BY TM1.OperacoesTitulosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00326,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00327", "SELECT OperacoesTitulosId FROM OperacoesTitulos WHERE OperacoesTitulosId = :OperacoesTitulosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00327,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00328", "SAVEPOINT gxupdate;INSERT INTO OperacoesTitulos(OperacoesTitulosCreatedAt, OperacoesTitulosUpdatedAt, OperacoesTitulosTipo, OperacoesTitulosNumero, OperacoesTitulosDataEmissao, OperacoesTitulosDataVencimento, OperacoesTitulosValor, OperacoesTitulosLiquido, OperacoesTitulosTaxa, OperacoesTitulosStatus, OperacoesId, SacadoId) VALUES(:OperacoesTitulosCreatedAt, :OperacoesTitulosUpdatedAt, :OperacoesTitulosTipo, :OperacoesTitulosNumero, :OperacoesTitulosDataEmissao, :OperacoesTitulosDataVencimento, :OperacoesTitulosValor, :OperacoesTitulosLiquido, :OperacoesTitulosTaxa, :OperacoesTitulosStatus, :OperacoesId, :SacadoId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00328)
             ,new CursorDef("BC00329", "SELECT currval('OperacoesTitulosId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00329,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003210", "SAVEPOINT gxupdate;UPDATE OperacoesTitulos SET OperacoesTitulosCreatedAt=:OperacoesTitulosCreatedAt, OperacoesTitulosUpdatedAt=:OperacoesTitulosUpdatedAt, OperacoesTitulosTipo=:OperacoesTitulosTipo, OperacoesTitulosNumero=:OperacoesTitulosNumero, OperacoesTitulosDataEmissao=:OperacoesTitulosDataEmissao, OperacoesTitulosDataVencimento=:OperacoesTitulosDataVencimento, OperacoesTitulosValor=:OperacoesTitulosValor, OperacoesTitulosLiquido=:OperacoesTitulosLiquido, OperacoesTitulosTaxa=:OperacoesTitulosTaxa, OperacoesTitulosStatus=:OperacoesTitulosStatus, OperacoesId=:OperacoesId, SacadoId=:SacadoId  WHERE OperacoesTitulosId = :OperacoesTitulosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003210)
             ,new CursorDef("BC003211", "SAVEPOINT gxupdate;DELETE FROM OperacoesTitulos  WHERE OperacoesTitulosId = :OperacoesTitulosId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC003211)
             ,new CursorDef("BC003212", "SELECT ClienteRazaoSocial AS SacadoRazaoSocial FROM Cliente WHERE ClienteId = :SacadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003212,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC003213", "SELECT TM1.OperacoesTitulosId, TM1.OperacoesTitulosCreatedAt, TM1.OperacoesTitulosUpdatedAt, T2.ClienteRazaoSocial AS SacadoRazaoSocial, TM1.OperacoesTitulosTipo, TM1.OperacoesTitulosNumero, TM1.OperacoesTitulosDataEmissao, TM1.OperacoesTitulosDataVencimento, TM1.OperacoesTitulosValor, TM1.OperacoesTitulosLiquido, TM1.OperacoesTitulosTaxa, TM1.OperacoesTitulosStatus, TM1.OperacoesId, TM1.SacadoId AS SacadoId FROM (OperacoesTitulos TM1 LEFT JOIN Cliente T2 ON T2.ClienteId = TM1.SacadoId) WHERE TM1.OperacoesTitulosId = :OperacoesTitulosId ORDER BY TM1.OperacoesTitulosId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC003213,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((int[]) buf[7])[0] = rslt.getInt(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((int[]) buf[21])[0] = rslt.getInt(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((int[]) buf[23])[0] = rslt.getInt(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((int[]) buf[25])[0] = rslt.getInt(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                return;
       }
    }

 }

}
