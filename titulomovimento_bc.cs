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
   public class titulomovimento_bc : GxSilentTrn, IGxSilentTrn
   {
      public titulomovimento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public titulomovimento_bc( IGxContext context )
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
         ReadRow1645( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1645( ) ;
         standaloneModal( ) ;
         AddRow1645( ) ;
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
            E11162 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z270TituloMovimentoId = A270TituloMovimentoId;
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

      protected void CONFIRM_160( )
      {
         BeforeValidate1645( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1645( ) ;
            }
            else
            {
               CheckExtendedTable1645( ) ;
               if ( AnyError == 0 )
               {
                  ZM1645( 12) ;
                  ZM1645( 13) ;
                  ZM1645( 14) ;
               }
               CloseExtendedTableCursors1645( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E12162( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV24Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV25GXV1 = 1;
            while ( AV25GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV25GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TipoPagamentoId") == 0 )
               {
                  AV11Insert_TipoPagamentoId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TituloId") == 0 )
               {
                  AV12Insert_TituloId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TituloMovimentoConta") == 0 )
               {
                  AV22Insert_TituloMovimentoConta = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV25GXV1 = (int)(AV25GXV1+1);
            }
         }
      }

      protected void E11162( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1645( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z280TituloMovimentoCreatedAt = A280TituloMovimentoCreatedAt;
            Z281TituloMovimentoUpdatedAt = A281TituloMovimentoUpdatedAt;
            Z271TituloMovimentoValor = A271TituloMovimentoValor;
            Z272TituloMovimentoTipo = A272TituloMovimentoTipo;
            Z274TituloMovimentoSoma = A274TituloMovimentoSoma;
            Z279TituloMovimentoDataCredito = A279TituloMovimentoDataCredito;
            Z432TituloMovimentoOpe = A432TituloMovimentoOpe;
            Z288TipoPagamentoId = A288TipoPagamentoId;
            Z261TituloId = A261TituloId;
            Z433TituloMovimentoConta = A433TituloMovimentoConta;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z289TipoPagamentoNome = A289TipoPagamentoNome;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -11 )
         {
            Z270TituloMovimentoId = A270TituloMovimentoId;
            Z280TituloMovimentoCreatedAt = A280TituloMovimentoCreatedAt;
            Z281TituloMovimentoUpdatedAt = A281TituloMovimentoUpdatedAt;
            Z271TituloMovimentoValor = A271TituloMovimentoValor;
            Z272TituloMovimentoTipo = A272TituloMovimentoTipo;
            Z274TituloMovimentoSoma = A274TituloMovimentoSoma;
            Z279TituloMovimentoDataCredito = A279TituloMovimentoDataCredito;
            Z432TituloMovimentoOpe = A432TituloMovimentoOpe;
            Z288TipoPagamentoId = A288TipoPagamentoId;
            Z261TituloId = A261TituloId;
            Z433TituloMovimentoConta = A433TituloMovimentoConta;
            Z289TipoPagamentoNome = A289TipoPagamentoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         AV24Pgmname = "TituloMovimento_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsUpd( )  )
         {
            A281TituloMovimentoUpdatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n281TituloMovimentoUpdatedAt = false;
         }
         if ( IsIns( )  )
         {
            A280TituloMovimentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
            n280TituloMovimentoCreatedAt = false;
         }
         else
         {
            if ( IsIns( )  && (DateTime.MinValue==A280TituloMovimentoCreatedAt) && ( Gx_BScreen == 0 ) )
            {
               A280TituloMovimentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
               n280TituloMovimentoCreatedAt = false;
            }
         }
      }

      protected void Load1645( )
      {
         /* Using cursor BC00167 */
         pr_default.execute(5, new Object[] {A270TituloMovimentoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound45 = 1;
            A280TituloMovimentoCreatedAt = BC00167_A280TituloMovimentoCreatedAt[0];
            n280TituloMovimentoCreatedAt = BC00167_n280TituloMovimentoCreatedAt[0];
            A281TituloMovimentoUpdatedAt = BC00167_A281TituloMovimentoUpdatedAt[0];
            n281TituloMovimentoUpdatedAt = BC00167_n281TituloMovimentoUpdatedAt[0];
            A271TituloMovimentoValor = BC00167_A271TituloMovimentoValor[0];
            n271TituloMovimentoValor = BC00167_n271TituloMovimentoValor[0];
            A272TituloMovimentoTipo = BC00167_A272TituloMovimentoTipo[0];
            n272TituloMovimentoTipo = BC00167_n272TituloMovimentoTipo[0];
            A274TituloMovimentoSoma = BC00167_A274TituloMovimentoSoma[0];
            n274TituloMovimentoSoma = BC00167_n274TituloMovimentoSoma[0];
            A279TituloMovimentoDataCredito = BC00167_A279TituloMovimentoDataCredito[0];
            n279TituloMovimentoDataCredito = BC00167_n279TituloMovimentoDataCredito[0];
            A289TipoPagamentoNome = BC00167_A289TipoPagamentoNome[0];
            A432TituloMovimentoOpe = BC00167_A432TituloMovimentoOpe[0];
            n432TituloMovimentoOpe = BC00167_n432TituloMovimentoOpe[0];
            A288TipoPagamentoId = BC00167_A288TipoPagamentoId[0];
            n288TipoPagamentoId = BC00167_n288TipoPagamentoId[0];
            A261TituloId = BC00167_A261TituloId[0];
            n261TituloId = BC00167_n261TituloId[0];
            A433TituloMovimentoConta = BC00167_A433TituloMovimentoConta[0];
            n433TituloMovimentoConta = BC00167_n433TituloMovimentoConta[0];
            ZM1645( -11) ;
         }
         pr_default.close(5);
         OnLoadActions1645( ) ;
      }

      protected void OnLoadActions1645( )
      {
         if ( (0==A288TipoPagamentoId) )
         {
            A288TipoPagamentoId = 0;
            n288TipoPagamentoId = false;
            n288TipoPagamentoId = true;
            n288TipoPagamentoId = true;
         }
         if ( (0==A261TituloId) )
         {
            A261TituloId = 0;
            n261TituloId = false;
            n261TituloId = true;
            n261TituloId = true;
         }
         if ( (0==A433TituloMovimentoConta) )
         {
            A433TituloMovimentoConta = 0;
            n433TituloMovimentoConta = false;
            n433TituloMovimentoConta = true;
            n433TituloMovimentoConta = true;
         }
      }

      protected void CheckExtendedTable1645( )
      {
         standaloneModal( ) ;
         if ( (0==A288TipoPagamentoId) )
         {
            A288TipoPagamentoId = 0;
            n288TipoPagamentoId = false;
            n288TipoPagamentoId = true;
            n288TipoPagamentoId = true;
         }
         /* Using cursor BC00164 */
         pr_default.execute(2, new Object[] {n288TipoPagamentoId, A288TipoPagamentoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A288TipoPagamentoId) ) )
            {
               GX_msglist.addItem("Não existe 'TipoPagamento'.", "ForeignKeyNotFound", 1, "TIPOPAGAMENTOID");
               AnyError = 1;
            }
         }
         A289TipoPagamentoNome = BC00164_A289TipoPagamentoNome[0];
         pr_default.close(2);
         if ( (0==A261TituloId) )
         {
            A261TituloId = 0;
            n261TituloId = false;
            n261TituloId = true;
            n261TituloId = true;
         }
         /* Using cursor BC00165 */
         pr_default.execute(3, new Object[] {n261TituloId, A261TituloId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A261TituloId) ) )
            {
               GX_msglist.addItem("Não existe 'Titulo'.", "ForeignKeyNotFound", 1, "TITULOID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         if ( ( A271TituloMovimentoValor < Convert.ToDecimal( 0 )) )
         {
            GX_msglist.addItem("Valor não pode ser negativo", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A272TituloMovimentoTipo, "Baixa") == 0 ) || ( StringUtil.StrCmp(A272TituloMovimentoTipo, "Juros") == 0 ) || ( StringUtil.StrCmp(A272TituloMovimentoTipo, "Taxa") == 0 ) || ( StringUtil.StrCmp(A272TituloMovimentoTipo, "Multa") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A272TituloMovimentoTipo)) ) )
         {
            GX_msglist.addItem("Campo Tipo baixa fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A432TituloMovimentoOpe, "Entrada") == 0 ) || ( StringUtil.StrCmp(A432TituloMovimentoOpe, "Saida") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A432TituloMovimentoOpe)) ) )
         {
            GX_msglist.addItem("Campo Titulo Movimento Ope fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( (0==A433TituloMovimentoConta) )
         {
            A433TituloMovimentoConta = 0;
            n433TituloMovimentoConta = false;
            n433TituloMovimentoConta = true;
            n433TituloMovimentoConta = true;
         }
         /* Using cursor BC00166 */
         pr_default.execute(4, new Object[] {n433TituloMovimentoConta, A433TituloMovimentoConta});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A433TituloMovimentoConta) ) )
            {
               GX_msglist.addItem("Não existe 'Sb Conta Movimento Id'.", "ForeignKeyNotFound", 1, "TITULOMOVIMENTOCONTA");
               AnyError = 1;
            }
         }
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors1645( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1645( )
      {
         /* Using cursor BC00168 */
         pr_default.execute(6, new Object[] {A270TituloMovimentoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound45 = 1;
         }
         else
         {
            RcdFound45 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00163 */
         pr_default.execute(1, new Object[] {A270TituloMovimentoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1645( 11) ;
            RcdFound45 = 1;
            A270TituloMovimentoId = BC00163_A270TituloMovimentoId[0];
            A280TituloMovimentoCreatedAt = BC00163_A280TituloMovimentoCreatedAt[0];
            n280TituloMovimentoCreatedAt = BC00163_n280TituloMovimentoCreatedAt[0];
            A281TituloMovimentoUpdatedAt = BC00163_A281TituloMovimentoUpdatedAt[0];
            n281TituloMovimentoUpdatedAt = BC00163_n281TituloMovimentoUpdatedAt[0];
            A271TituloMovimentoValor = BC00163_A271TituloMovimentoValor[0];
            n271TituloMovimentoValor = BC00163_n271TituloMovimentoValor[0];
            A272TituloMovimentoTipo = BC00163_A272TituloMovimentoTipo[0];
            n272TituloMovimentoTipo = BC00163_n272TituloMovimentoTipo[0];
            A274TituloMovimentoSoma = BC00163_A274TituloMovimentoSoma[0];
            n274TituloMovimentoSoma = BC00163_n274TituloMovimentoSoma[0];
            A279TituloMovimentoDataCredito = BC00163_A279TituloMovimentoDataCredito[0];
            n279TituloMovimentoDataCredito = BC00163_n279TituloMovimentoDataCredito[0];
            A432TituloMovimentoOpe = BC00163_A432TituloMovimentoOpe[0];
            n432TituloMovimentoOpe = BC00163_n432TituloMovimentoOpe[0];
            A288TipoPagamentoId = BC00163_A288TipoPagamentoId[0];
            n288TipoPagamentoId = BC00163_n288TipoPagamentoId[0];
            A261TituloId = BC00163_A261TituloId[0];
            n261TituloId = BC00163_n261TituloId[0];
            A433TituloMovimentoConta = BC00163_A433TituloMovimentoConta[0];
            n433TituloMovimentoConta = BC00163_n433TituloMovimentoConta[0];
            Z270TituloMovimentoId = A270TituloMovimentoId;
            sMode45 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1645( ) ;
            if ( AnyError == 1 )
            {
               RcdFound45 = 0;
               InitializeNonKey1645( ) ;
            }
            Gx_mode = sMode45;
         }
         else
         {
            RcdFound45 = 0;
            InitializeNonKey1645( ) ;
            sMode45 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode45;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1645( ) ;
         if ( RcdFound45 == 0 )
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
         CONFIRM_160( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency1645( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00162 */
            pr_default.execute(0, new Object[] {A270TituloMovimentoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TituloMovimento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z280TituloMovimentoCreatedAt != BC00162_A280TituloMovimentoCreatedAt[0] ) || ( Z281TituloMovimentoUpdatedAt != BC00162_A281TituloMovimentoUpdatedAt[0] ) || ( Z271TituloMovimentoValor != BC00162_A271TituloMovimentoValor[0] ) || ( StringUtil.StrCmp(Z272TituloMovimentoTipo, BC00162_A272TituloMovimentoTipo[0]) != 0 ) || ( Z274TituloMovimentoSoma != BC00162_A274TituloMovimentoSoma[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z279TituloMovimentoDataCredito ) != DateTimeUtil.ResetTime ( BC00162_A279TituloMovimentoDataCredito[0] ) ) || ( StringUtil.StrCmp(Z432TituloMovimentoOpe, BC00162_A432TituloMovimentoOpe[0]) != 0 ) || ( Z288TipoPagamentoId != BC00162_A288TipoPagamentoId[0] ) || ( Z261TituloId != BC00162_A261TituloId[0] ) || ( Z433TituloMovimentoConta != BC00162_A433TituloMovimentoConta[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TituloMovimento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1645( )
      {
         BeforeValidate1645( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1645( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1645( 0) ;
            CheckOptimisticConcurrency1645( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1645( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1645( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00169 */
                     pr_default.execute(7, new Object[] {n280TituloMovimentoCreatedAt, A280TituloMovimentoCreatedAt, n281TituloMovimentoUpdatedAt, A281TituloMovimentoUpdatedAt, n271TituloMovimentoValor, A271TituloMovimentoValor, n272TituloMovimentoTipo, A272TituloMovimentoTipo, n274TituloMovimentoSoma, A274TituloMovimentoSoma, n279TituloMovimentoDataCredito, A279TituloMovimentoDataCredito, n432TituloMovimentoOpe, A432TituloMovimentoOpe, n288TipoPagamentoId, A288TipoPagamentoId, n261TituloId, A261TituloId, n433TituloMovimentoConta, A433TituloMovimentoConta});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC001610 */
                     pr_default.execute(8);
                     A270TituloMovimentoId = BC001610_A270TituloMovimentoId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("TituloMovimento");
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
               Load1645( ) ;
            }
            EndLevel1645( ) ;
         }
         CloseExtendedTableCursors1645( ) ;
      }

      protected void Update1645( )
      {
         BeforeValidate1645( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1645( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1645( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1645( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1645( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001611 */
                     pr_default.execute(9, new Object[] {n280TituloMovimentoCreatedAt, A280TituloMovimentoCreatedAt, n281TituloMovimentoUpdatedAt, A281TituloMovimentoUpdatedAt, n271TituloMovimentoValor, A271TituloMovimentoValor, n272TituloMovimentoTipo, A272TituloMovimentoTipo, n274TituloMovimentoSoma, A274TituloMovimentoSoma, n279TituloMovimentoDataCredito, A279TituloMovimentoDataCredito, n432TituloMovimentoOpe, A432TituloMovimentoOpe, n288TipoPagamentoId, A288TipoPagamentoId, n261TituloId, A261TituloId, n433TituloMovimentoConta, A433TituloMovimentoConta, A270TituloMovimentoId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("TituloMovimento");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TituloMovimento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1645( ) ;
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
            EndLevel1645( ) ;
         }
         CloseExtendedTableCursors1645( ) ;
      }

      protected void DeferredUpdate1645( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1645( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1645( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1645( ) ;
            AfterConfirm1645( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1645( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001612 */
                  pr_default.execute(10, new Object[] {A270TituloMovimentoId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("TituloMovimento");
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
         sMode45 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1645( ) ;
         Gx_mode = sMode45;
      }

      protected void OnDeleteControls1645( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001613 */
            pr_default.execute(11, new Object[] {n288TipoPagamentoId, A288TipoPagamentoId});
            A289TipoPagamentoNome = BC001613_A289TipoPagamentoNome[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel1645( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1645( ) ;
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

      public void ScanKeyStart1645( )
      {
         /* Scan By routine */
         /* Using cursor BC001614 */
         pr_default.execute(12, new Object[] {A270TituloMovimentoId});
         RcdFound45 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound45 = 1;
            A270TituloMovimentoId = BC001614_A270TituloMovimentoId[0];
            A280TituloMovimentoCreatedAt = BC001614_A280TituloMovimentoCreatedAt[0];
            n280TituloMovimentoCreatedAt = BC001614_n280TituloMovimentoCreatedAt[0];
            A281TituloMovimentoUpdatedAt = BC001614_A281TituloMovimentoUpdatedAt[0];
            n281TituloMovimentoUpdatedAt = BC001614_n281TituloMovimentoUpdatedAt[0];
            A271TituloMovimentoValor = BC001614_A271TituloMovimentoValor[0];
            n271TituloMovimentoValor = BC001614_n271TituloMovimentoValor[0];
            A272TituloMovimentoTipo = BC001614_A272TituloMovimentoTipo[0];
            n272TituloMovimentoTipo = BC001614_n272TituloMovimentoTipo[0];
            A274TituloMovimentoSoma = BC001614_A274TituloMovimentoSoma[0];
            n274TituloMovimentoSoma = BC001614_n274TituloMovimentoSoma[0];
            A279TituloMovimentoDataCredito = BC001614_A279TituloMovimentoDataCredito[0];
            n279TituloMovimentoDataCredito = BC001614_n279TituloMovimentoDataCredito[0];
            A289TipoPagamentoNome = BC001614_A289TipoPagamentoNome[0];
            A432TituloMovimentoOpe = BC001614_A432TituloMovimentoOpe[0];
            n432TituloMovimentoOpe = BC001614_n432TituloMovimentoOpe[0];
            A288TipoPagamentoId = BC001614_A288TipoPagamentoId[0];
            n288TipoPagamentoId = BC001614_n288TipoPagamentoId[0];
            A261TituloId = BC001614_A261TituloId[0];
            n261TituloId = BC001614_n261TituloId[0];
            A433TituloMovimentoConta = BC001614_A433TituloMovimentoConta[0];
            n433TituloMovimentoConta = BC001614_n433TituloMovimentoConta[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1645( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound45 = 0;
         ScanKeyLoad1645( ) ;
      }

      protected void ScanKeyLoad1645( )
      {
         sMode45 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound45 = 1;
            A270TituloMovimentoId = BC001614_A270TituloMovimentoId[0];
            A280TituloMovimentoCreatedAt = BC001614_A280TituloMovimentoCreatedAt[0];
            n280TituloMovimentoCreatedAt = BC001614_n280TituloMovimentoCreatedAt[0];
            A281TituloMovimentoUpdatedAt = BC001614_A281TituloMovimentoUpdatedAt[0];
            n281TituloMovimentoUpdatedAt = BC001614_n281TituloMovimentoUpdatedAt[0];
            A271TituloMovimentoValor = BC001614_A271TituloMovimentoValor[0];
            n271TituloMovimentoValor = BC001614_n271TituloMovimentoValor[0];
            A272TituloMovimentoTipo = BC001614_A272TituloMovimentoTipo[0];
            n272TituloMovimentoTipo = BC001614_n272TituloMovimentoTipo[0];
            A274TituloMovimentoSoma = BC001614_A274TituloMovimentoSoma[0];
            n274TituloMovimentoSoma = BC001614_n274TituloMovimentoSoma[0];
            A279TituloMovimentoDataCredito = BC001614_A279TituloMovimentoDataCredito[0];
            n279TituloMovimentoDataCredito = BC001614_n279TituloMovimentoDataCredito[0];
            A289TipoPagamentoNome = BC001614_A289TipoPagamentoNome[0];
            A432TituloMovimentoOpe = BC001614_A432TituloMovimentoOpe[0];
            n432TituloMovimentoOpe = BC001614_n432TituloMovimentoOpe[0];
            A288TipoPagamentoId = BC001614_A288TipoPagamentoId[0];
            n288TipoPagamentoId = BC001614_n288TipoPagamentoId[0];
            A261TituloId = BC001614_A261TituloId[0];
            n261TituloId = BC001614_n261TituloId[0];
            A433TituloMovimentoConta = BC001614_A433TituloMovimentoConta[0];
            n433TituloMovimentoConta = BC001614_n433TituloMovimentoConta[0];
         }
         Gx_mode = sMode45;
      }

      protected void ScanKeyEnd1645( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1645( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1645( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1645( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1645( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1645( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1645( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1645( )
      {
      }

      protected void send_integrity_lvl_hashes1645( )
      {
      }

      protected void AddRow1645( )
      {
         VarsToRow45( bcTituloMovimento) ;
      }

      protected void ReadRow1645( )
      {
         RowToVars45( bcTituloMovimento, 1) ;
      }

      protected void InitializeNonKey1645( )
      {
         A280TituloMovimentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n280TituloMovimentoCreatedAt = false;
         A281TituloMovimentoUpdatedAt = (DateTime)(DateTime.MinValue);
         n281TituloMovimentoUpdatedAt = false;
         A288TipoPagamentoId = 0;
         n288TipoPagamentoId = false;
         A261TituloId = 0;
         n261TituloId = false;
         A271TituloMovimentoValor = 0;
         n271TituloMovimentoValor = false;
         A272TituloMovimentoTipo = "";
         n272TituloMovimentoTipo = false;
         A274TituloMovimentoSoma = false;
         n274TituloMovimentoSoma = false;
         A279TituloMovimentoDataCredito = DateTime.MinValue;
         n279TituloMovimentoDataCredito = false;
         A289TipoPagamentoNome = "";
         A432TituloMovimentoOpe = "";
         n432TituloMovimentoOpe = false;
         A433TituloMovimentoConta = 0;
         n433TituloMovimentoConta = false;
         Z280TituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
         Z281TituloMovimentoUpdatedAt = (DateTime)(DateTime.MinValue);
         Z271TituloMovimentoValor = 0;
         Z272TituloMovimentoTipo = "";
         Z274TituloMovimentoSoma = false;
         Z279TituloMovimentoDataCredito = DateTime.MinValue;
         Z432TituloMovimentoOpe = "";
         Z288TipoPagamentoId = 0;
         Z261TituloId = 0;
         Z433TituloMovimentoConta = 0;
      }

      protected void InitAll1645( )
      {
         A270TituloMovimentoId = 0;
         InitializeNonKey1645( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A280TituloMovimentoCreatedAt = i280TituloMovimentoCreatedAt;
         n280TituloMovimentoCreatedAt = false;
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

      public void VarsToRow45( SdtTituloMovimento obj45 )
      {
         obj45.gxTpr_Mode = Gx_mode;
         obj45.gxTpr_Titulomovimentocreatedat = A280TituloMovimentoCreatedAt;
         obj45.gxTpr_Titulomovimentoupdatedat = A281TituloMovimentoUpdatedAt;
         obj45.gxTpr_Tipopagamentoid = A288TipoPagamentoId;
         obj45.gxTpr_Tituloid = A261TituloId;
         obj45.gxTpr_Titulomovimentovalor = A271TituloMovimentoValor;
         obj45.gxTpr_Titulomovimentotipo = A272TituloMovimentoTipo;
         obj45.gxTpr_Titulomovimentosoma = A274TituloMovimentoSoma;
         obj45.gxTpr_Titulomovimentodatacredito = A279TituloMovimentoDataCredito;
         obj45.gxTpr_Tipopagamentonome = A289TipoPagamentoNome;
         obj45.gxTpr_Titulomovimentoope = A432TituloMovimentoOpe;
         obj45.gxTpr_Titulomovimentoconta = A433TituloMovimentoConta;
         obj45.gxTpr_Titulomovimentoid = A270TituloMovimentoId;
         obj45.gxTpr_Titulomovimentoid_Z = Z270TituloMovimentoId;
         obj45.gxTpr_Tipopagamentoid_Z = Z288TipoPagamentoId;
         obj45.gxTpr_Tituloid_Z = Z261TituloId;
         obj45.gxTpr_Titulomovimentovalor_Z = Z271TituloMovimentoValor;
         obj45.gxTpr_Titulomovimentotipo_Z = Z272TituloMovimentoTipo;
         obj45.gxTpr_Titulomovimentosoma_Z = Z274TituloMovimentoSoma;
         obj45.gxTpr_Titulomovimentodatacredito_Z = Z279TituloMovimentoDataCredito;
         obj45.gxTpr_Titulomovimentocreatedat_Z = Z280TituloMovimentoCreatedAt;
         obj45.gxTpr_Titulomovimentoupdatedat_Z = Z281TituloMovimentoUpdatedAt;
         obj45.gxTpr_Tipopagamentonome_Z = Z289TipoPagamentoNome;
         obj45.gxTpr_Titulomovimentoope_Z = Z432TituloMovimentoOpe;
         obj45.gxTpr_Titulomovimentoconta_Z = Z433TituloMovimentoConta;
         obj45.gxTpr_Tipopagamentoid_N = (short)(Convert.ToInt16(n288TipoPagamentoId));
         obj45.gxTpr_Tituloid_N = (short)(Convert.ToInt16(n261TituloId));
         obj45.gxTpr_Titulomovimentovalor_N = (short)(Convert.ToInt16(n271TituloMovimentoValor));
         obj45.gxTpr_Titulomovimentotipo_N = (short)(Convert.ToInt16(n272TituloMovimentoTipo));
         obj45.gxTpr_Titulomovimentosoma_N = (short)(Convert.ToInt16(n274TituloMovimentoSoma));
         obj45.gxTpr_Titulomovimentodatacredito_N = (short)(Convert.ToInt16(n279TituloMovimentoDataCredito));
         obj45.gxTpr_Titulomovimentocreatedat_N = (short)(Convert.ToInt16(n280TituloMovimentoCreatedAt));
         obj45.gxTpr_Titulomovimentoupdatedat_N = (short)(Convert.ToInt16(n281TituloMovimentoUpdatedAt));
         obj45.gxTpr_Titulomovimentoope_N = (short)(Convert.ToInt16(n432TituloMovimentoOpe));
         obj45.gxTpr_Titulomovimentoconta_N = (short)(Convert.ToInt16(n433TituloMovimentoConta));
         obj45.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow45( SdtTituloMovimento obj45 )
      {
         obj45.gxTpr_Titulomovimentoid = A270TituloMovimentoId;
         return  ;
      }

      public void RowToVars45( SdtTituloMovimento obj45 ,
                               int forceLoad )
      {
         Gx_mode = obj45.gxTpr_Mode;
         A280TituloMovimentoCreatedAt = obj45.gxTpr_Titulomovimentocreatedat;
         n280TituloMovimentoCreatedAt = false;
         A281TituloMovimentoUpdatedAt = obj45.gxTpr_Titulomovimentoupdatedat;
         n281TituloMovimentoUpdatedAt = false;
         A288TipoPagamentoId = obj45.gxTpr_Tipopagamentoid;
         n288TipoPagamentoId = false;
         A261TituloId = obj45.gxTpr_Tituloid;
         n261TituloId = false;
         A271TituloMovimentoValor = obj45.gxTpr_Titulomovimentovalor;
         n271TituloMovimentoValor = false;
         A272TituloMovimentoTipo = obj45.gxTpr_Titulomovimentotipo;
         n272TituloMovimentoTipo = false;
         A274TituloMovimentoSoma = obj45.gxTpr_Titulomovimentosoma;
         n274TituloMovimentoSoma = false;
         A279TituloMovimentoDataCredito = obj45.gxTpr_Titulomovimentodatacredito;
         n279TituloMovimentoDataCredito = false;
         A289TipoPagamentoNome = obj45.gxTpr_Tipopagamentonome;
         A432TituloMovimentoOpe = obj45.gxTpr_Titulomovimentoope;
         n432TituloMovimentoOpe = false;
         A433TituloMovimentoConta = obj45.gxTpr_Titulomovimentoconta;
         n433TituloMovimentoConta = false;
         A270TituloMovimentoId = obj45.gxTpr_Titulomovimentoid;
         Z270TituloMovimentoId = obj45.gxTpr_Titulomovimentoid_Z;
         Z288TipoPagamentoId = obj45.gxTpr_Tipopagamentoid_Z;
         Z261TituloId = obj45.gxTpr_Tituloid_Z;
         Z271TituloMovimentoValor = obj45.gxTpr_Titulomovimentovalor_Z;
         Z272TituloMovimentoTipo = obj45.gxTpr_Titulomovimentotipo_Z;
         Z274TituloMovimentoSoma = obj45.gxTpr_Titulomovimentosoma_Z;
         Z279TituloMovimentoDataCredito = obj45.gxTpr_Titulomovimentodatacredito_Z;
         Z280TituloMovimentoCreatedAt = obj45.gxTpr_Titulomovimentocreatedat_Z;
         Z281TituloMovimentoUpdatedAt = obj45.gxTpr_Titulomovimentoupdatedat_Z;
         Z289TipoPagamentoNome = obj45.gxTpr_Tipopagamentonome_Z;
         Z432TituloMovimentoOpe = obj45.gxTpr_Titulomovimentoope_Z;
         Z433TituloMovimentoConta = obj45.gxTpr_Titulomovimentoconta_Z;
         n288TipoPagamentoId = (bool)(Convert.ToBoolean(obj45.gxTpr_Tipopagamentoid_N));
         n261TituloId = (bool)(Convert.ToBoolean(obj45.gxTpr_Tituloid_N));
         n271TituloMovimentoValor = (bool)(Convert.ToBoolean(obj45.gxTpr_Titulomovimentovalor_N));
         n272TituloMovimentoTipo = (bool)(Convert.ToBoolean(obj45.gxTpr_Titulomovimentotipo_N));
         n274TituloMovimentoSoma = (bool)(Convert.ToBoolean(obj45.gxTpr_Titulomovimentosoma_N));
         n279TituloMovimentoDataCredito = (bool)(Convert.ToBoolean(obj45.gxTpr_Titulomovimentodatacredito_N));
         n280TituloMovimentoCreatedAt = (bool)(Convert.ToBoolean(obj45.gxTpr_Titulomovimentocreatedat_N));
         n281TituloMovimentoUpdatedAt = (bool)(Convert.ToBoolean(obj45.gxTpr_Titulomovimentoupdatedat_N));
         n432TituloMovimentoOpe = (bool)(Convert.ToBoolean(obj45.gxTpr_Titulomovimentoope_N));
         n433TituloMovimentoConta = (bool)(Convert.ToBoolean(obj45.gxTpr_Titulomovimentoconta_N));
         Gx_mode = obj45.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A270TituloMovimentoId = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1645( ) ;
         ScanKeyStart1645( ) ;
         if ( RcdFound45 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z270TituloMovimentoId = A270TituloMovimentoId;
         }
         ZM1645( -11) ;
         OnLoadActions1645( ) ;
         AddRow1645( ) ;
         ScanKeyEnd1645( ) ;
         if ( RcdFound45 == 0 )
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
         RowToVars45( bcTituloMovimento, 0) ;
         ScanKeyStart1645( ) ;
         if ( RcdFound45 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z270TituloMovimentoId = A270TituloMovimentoId;
         }
         ZM1645( -11) ;
         OnLoadActions1645( ) ;
         AddRow1645( ) ;
         ScanKeyEnd1645( ) ;
         if ( RcdFound45 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey1645( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1645( ) ;
         }
         else
         {
            if ( RcdFound45 == 1 )
            {
               if ( A270TituloMovimentoId != Z270TituloMovimentoId )
               {
                  A270TituloMovimentoId = Z270TituloMovimentoId;
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
                  Update1645( ) ;
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
                  if ( A270TituloMovimentoId != Z270TituloMovimentoId )
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
                        Insert1645( ) ;
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
                        Insert1645( ) ;
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
         RowToVars45( bcTituloMovimento, 1) ;
         SaveImpl( ) ;
         VarsToRow45( bcTituloMovimento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars45( bcTituloMovimento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1645( ) ;
         AfterTrn( ) ;
         VarsToRow45( bcTituloMovimento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow45( bcTituloMovimento) ;
         }
         else
         {
            SdtTituloMovimento auxBC = new SdtTituloMovimento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A270TituloMovimentoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcTituloMovimento);
               auxBC.Save();
               bcTituloMovimento.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars45( bcTituloMovimento, 1) ;
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
         RowToVars45( bcTituloMovimento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1645( ) ;
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
               VarsToRow45( bcTituloMovimento) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow45( bcTituloMovimento) ;
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
         RowToVars45( bcTituloMovimento, 0) ;
         GetKey1645( ) ;
         if ( RcdFound45 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A270TituloMovimentoId != Z270TituloMovimentoId )
            {
               A270TituloMovimentoId = Z270TituloMovimentoId;
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
            if ( A270TituloMovimentoId != Z270TituloMovimentoId )
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
         context.RollbackDataStores("titulomovimento_bc",pr_default);
         VarsToRow45( bcTituloMovimento) ;
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
         Gx_mode = bcTituloMovimento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcTituloMovimento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcTituloMovimento )
         {
            bcTituloMovimento = (SdtTituloMovimento)(sdt);
            if ( StringUtil.StrCmp(bcTituloMovimento.gxTpr_Mode, "") == 0 )
            {
               bcTituloMovimento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow45( bcTituloMovimento) ;
            }
            else
            {
               RowToVars45( bcTituloMovimento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcTituloMovimento.gxTpr_Mode, "") == 0 )
            {
               bcTituloMovimento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars45( bcTituloMovimento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtTituloMovimento TituloMovimento_BC
      {
         get {
            return bcTituloMovimento ;
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV24Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         Z280TituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
         A280TituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
         Z281TituloMovimentoUpdatedAt = (DateTime)(DateTime.MinValue);
         A281TituloMovimentoUpdatedAt = (DateTime)(DateTime.MinValue);
         Z272TituloMovimentoTipo = "";
         A272TituloMovimentoTipo = "";
         Z279TituloMovimentoDataCredito = DateTime.MinValue;
         A279TituloMovimentoDataCredito = DateTime.MinValue;
         Z432TituloMovimentoOpe = "";
         A432TituloMovimentoOpe = "";
         Z289TipoPagamentoNome = "";
         A289TipoPagamentoNome = "";
         BC00167_A270TituloMovimentoId = new int[1] ;
         BC00167_A280TituloMovimentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00167_n280TituloMovimentoCreatedAt = new bool[] {false} ;
         BC00167_A281TituloMovimentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00167_n281TituloMovimentoUpdatedAt = new bool[] {false} ;
         BC00167_A271TituloMovimentoValor = new decimal[1] ;
         BC00167_n271TituloMovimentoValor = new bool[] {false} ;
         BC00167_A272TituloMovimentoTipo = new string[] {""} ;
         BC00167_n272TituloMovimentoTipo = new bool[] {false} ;
         BC00167_A274TituloMovimentoSoma = new bool[] {false} ;
         BC00167_n274TituloMovimentoSoma = new bool[] {false} ;
         BC00167_A279TituloMovimentoDataCredito = new DateTime[] {DateTime.MinValue} ;
         BC00167_n279TituloMovimentoDataCredito = new bool[] {false} ;
         BC00167_A289TipoPagamentoNome = new string[] {""} ;
         BC00167_A432TituloMovimentoOpe = new string[] {""} ;
         BC00167_n432TituloMovimentoOpe = new bool[] {false} ;
         BC00167_A288TipoPagamentoId = new int[1] ;
         BC00167_n288TipoPagamentoId = new bool[] {false} ;
         BC00167_A261TituloId = new int[1] ;
         BC00167_n261TituloId = new bool[] {false} ;
         BC00167_A433TituloMovimentoConta = new int[1] ;
         BC00167_n433TituloMovimentoConta = new bool[] {false} ;
         BC00164_A289TipoPagamentoNome = new string[] {""} ;
         BC00165_A261TituloId = new int[1] ;
         BC00165_n261TituloId = new bool[] {false} ;
         BC00166_A433TituloMovimentoConta = new int[1] ;
         BC00166_n433TituloMovimentoConta = new bool[] {false} ;
         BC00168_A270TituloMovimentoId = new int[1] ;
         BC00163_A270TituloMovimentoId = new int[1] ;
         BC00163_A280TituloMovimentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00163_n280TituloMovimentoCreatedAt = new bool[] {false} ;
         BC00163_A281TituloMovimentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00163_n281TituloMovimentoUpdatedAt = new bool[] {false} ;
         BC00163_A271TituloMovimentoValor = new decimal[1] ;
         BC00163_n271TituloMovimentoValor = new bool[] {false} ;
         BC00163_A272TituloMovimentoTipo = new string[] {""} ;
         BC00163_n272TituloMovimentoTipo = new bool[] {false} ;
         BC00163_A274TituloMovimentoSoma = new bool[] {false} ;
         BC00163_n274TituloMovimentoSoma = new bool[] {false} ;
         BC00163_A279TituloMovimentoDataCredito = new DateTime[] {DateTime.MinValue} ;
         BC00163_n279TituloMovimentoDataCredito = new bool[] {false} ;
         BC00163_A432TituloMovimentoOpe = new string[] {""} ;
         BC00163_n432TituloMovimentoOpe = new bool[] {false} ;
         BC00163_A288TipoPagamentoId = new int[1] ;
         BC00163_n288TipoPagamentoId = new bool[] {false} ;
         BC00163_A261TituloId = new int[1] ;
         BC00163_n261TituloId = new bool[] {false} ;
         BC00163_A433TituloMovimentoConta = new int[1] ;
         BC00163_n433TituloMovimentoConta = new bool[] {false} ;
         sMode45 = "";
         BC00162_A270TituloMovimentoId = new int[1] ;
         BC00162_A280TituloMovimentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00162_n280TituloMovimentoCreatedAt = new bool[] {false} ;
         BC00162_A281TituloMovimentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC00162_n281TituloMovimentoUpdatedAt = new bool[] {false} ;
         BC00162_A271TituloMovimentoValor = new decimal[1] ;
         BC00162_n271TituloMovimentoValor = new bool[] {false} ;
         BC00162_A272TituloMovimentoTipo = new string[] {""} ;
         BC00162_n272TituloMovimentoTipo = new bool[] {false} ;
         BC00162_A274TituloMovimentoSoma = new bool[] {false} ;
         BC00162_n274TituloMovimentoSoma = new bool[] {false} ;
         BC00162_A279TituloMovimentoDataCredito = new DateTime[] {DateTime.MinValue} ;
         BC00162_n279TituloMovimentoDataCredito = new bool[] {false} ;
         BC00162_A432TituloMovimentoOpe = new string[] {""} ;
         BC00162_n432TituloMovimentoOpe = new bool[] {false} ;
         BC00162_A288TipoPagamentoId = new int[1] ;
         BC00162_n288TipoPagamentoId = new bool[] {false} ;
         BC00162_A261TituloId = new int[1] ;
         BC00162_n261TituloId = new bool[] {false} ;
         BC00162_A433TituloMovimentoConta = new int[1] ;
         BC00162_n433TituloMovimentoConta = new bool[] {false} ;
         BC001610_A270TituloMovimentoId = new int[1] ;
         BC001613_A289TipoPagamentoNome = new string[] {""} ;
         BC001614_A270TituloMovimentoId = new int[1] ;
         BC001614_A280TituloMovimentoCreatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001614_n280TituloMovimentoCreatedAt = new bool[] {false} ;
         BC001614_A281TituloMovimentoUpdatedAt = new DateTime[] {DateTime.MinValue} ;
         BC001614_n281TituloMovimentoUpdatedAt = new bool[] {false} ;
         BC001614_A271TituloMovimentoValor = new decimal[1] ;
         BC001614_n271TituloMovimentoValor = new bool[] {false} ;
         BC001614_A272TituloMovimentoTipo = new string[] {""} ;
         BC001614_n272TituloMovimentoTipo = new bool[] {false} ;
         BC001614_A274TituloMovimentoSoma = new bool[] {false} ;
         BC001614_n274TituloMovimentoSoma = new bool[] {false} ;
         BC001614_A279TituloMovimentoDataCredito = new DateTime[] {DateTime.MinValue} ;
         BC001614_n279TituloMovimentoDataCredito = new bool[] {false} ;
         BC001614_A289TipoPagamentoNome = new string[] {""} ;
         BC001614_A432TituloMovimentoOpe = new string[] {""} ;
         BC001614_n432TituloMovimentoOpe = new bool[] {false} ;
         BC001614_A288TipoPagamentoId = new int[1] ;
         BC001614_n288TipoPagamentoId = new bool[] {false} ;
         BC001614_A261TituloId = new int[1] ;
         BC001614_n261TituloId = new bool[] {false} ;
         BC001614_A433TituloMovimentoConta = new int[1] ;
         BC001614_n433TituloMovimentoConta = new bool[] {false} ;
         i280TituloMovimentoCreatedAt = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.titulomovimento_bc__default(),
            new Object[][] {
                new Object[] {
               BC00162_A270TituloMovimentoId, BC00162_A280TituloMovimentoCreatedAt, BC00162_n280TituloMovimentoCreatedAt, BC00162_A281TituloMovimentoUpdatedAt, BC00162_n281TituloMovimentoUpdatedAt, BC00162_A271TituloMovimentoValor, BC00162_n271TituloMovimentoValor, BC00162_A272TituloMovimentoTipo, BC00162_n272TituloMovimentoTipo, BC00162_A274TituloMovimentoSoma,
               BC00162_n274TituloMovimentoSoma, BC00162_A279TituloMovimentoDataCredito, BC00162_n279TituloMovimentoDataCredito, BC00162_A432TituloMovimentoOpe, BC00162_n432TituloMovimentoOpe, BC00162_A288TipoPagamentoId, BC00162_n288TipoPagamentoId, BC00162_A261TituloId, BC00162_n261TituloId, BC00162_A433TituloMovimentoConta,
               BC00162_n433TituloMovimentoConta
               }
               , new Object[] {
               BC00163_A270TituloMovimentoId, BC00163_A280TituloMovimentoCreatedAt, BC00163_n280TituloMovimentoCreatedAt, BC00163_A281TituloMovimentoUpdatedAt, BC00163_n281TituloMovimentoUpdatedAt, BC00163_A271TituloMovimentoValor, BC00163_n271TituloMovimentoValor, BC00163_A272TituloMovimentoTipo, BC00163_n272TituloMovimentoTipo, BC00163_A274TituloMovimentoSoma,
               BC00163_n274TituloMovimentoSoma, BC00163_A279TituloMovimentoDataCredito, BC00163_n279TituloMovimentoDataCredito, BC00163_A432TituloMovimentoOpe, BC00163_n432TituloMovimentoOpe, BC00163_A288TipoPagamentoId, BC00163_n288TipoPagamentoId, BC00163_A261TituloId, BC00163_n261TituloId, BC00163_A433TituloMovimentoConta,
               BC00163_n433TituloMovimentoConta
               }
               , new Object[] {
               BC00164_A289TipoPagamentoNome
               }
               , new Object[] {
               BC00165_A261TituloId
               }
               , new Object[] {
               BC00166_A433TituloMovimentoConta
               }
               , new Object[] {
               BC00167_A270TituloMovimentoId, BC00167_A280TituloMovimentoCreatedAt, BC00167_n280TituloMovimentoCreatedAt, BC00167_A281TituloMovimentoUpdatedAt, BC00167_n281TituloMovimentoUpdatedAt, BC00167_A271TituloMovimentoValor, BC00167_n271TituloMovimentoValor, BC00167_A272TituloMovimentoTipo, BC00167_n272TituloMovimentoTipo, BC00167_A274TituloMovimentoSoma,
               BC00167_n274TituloMovimentoSoma, BC00167_A279TituloMovimentoDataCredito, BC00167_n279TituloMovimentoDataCredito, BC00167_A289TipoPagamentoNome, BC00167_A432TituloMovimentoOpe, BC00167_n432TituloMovimentoOpe, BC00167_A288TipoPagamentoId, BC00167_n288TipoPagamentoId, BC00167_A261TituloId, BC00167_n261TituloId,
               BC00167_A433TituloMovimentoConta, BC00167_n433TituloMovimentoConta
               }
               , new Object[] {
               BC00168_A270TituloMovimentoId
               }
               , new Object[] {
               }
               , new Object[] {
               BC001610_A270TituloMovimentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001613_A289TipoPagamentoNome
               }
               , new Object[] {
               BC001614_A270TituloMovimentoId, BC001614_A280TituloMovimentoCreatedAt, BC001614_n280TituloMovimentoCreatedAt, BC001614_A281TituloMovimentoUpdatedAt, BC001614_n281TituloMovimentoUpdatedAt, BC001614_A271TituloMovimentoValor, BC001614_n271TituloMovimentoValor, BC001614_A272TituloMovimentoTipo, BC001614_n272TituloMovimentoTipo, BC001614_A274TituloMovimentoSoma,
               BC001614_n274TituloMovimentoSoma, BC001614_A279TituloMovimentoDataCredito, BC001614_n279TituloMovimentoDataCredito, BC001614_A289TipoPagamentoNome, BC001614_A432TituloMovimentoOpe, BC001614_n432TituloMovimentoOpe, BC001614_A288TipoPagamentoId, BC001614_n288TipoPagamentoId, BC001614_A261TituloId, BC001614_n261TituloId,
               BC001614_A433TituloMovimentoConta, BC001614_n433TituloMovimentoConta
               }
            }
         );
         AV24Pgmname = "TituloMovimento_BC";
         Z280TituloMovimentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n280TituloMovimentoCreatedAt = false;
         A280TituloMovimentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n280TituloMovimentoCreatedAt = false;
         i280TituloMovimentoCreatedAt = DateTimeUtil.ServerNow( context, pr_default);
         n280TituloMovimentoCreatedAt = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12162 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Gx_BScreen ;
      private short RcdFound45 ;
      private int trnEnded ;
      private int Z270TituloMovimentoId ;
      private int A270TituloMovimentoId ;
      private int AV25GXV1 ;
      private int AV11Insert_TipoPagamentoId ;
      private int AV12Insert_TituloId ;
      private int AV22Insert_TituloMovimentoConta ;
      private int Z288TipoPagamentoId ;
      private int A288TipoPagamentoId ;
      private int Z261TituloId ;
      private int A261TituloId ;
      private int Z433TituloMovimentoConta ;
      private int A433TituloMovimentoConta ;
      private decimal Z271TituloMovimentoValor ;
      private decimal A271TituloMovimentoValor ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV24Pgmname ;
      private string sMode45 ;
      private DateTime Z280TituloMovimentoCreatedAt ;
      private DateTime A280TituloMovimentoCreatedAt ;
      private DateTime Z281TituloMovimentoUpdatedAt ;
      private DateTime A281TituloMovimentoUpdatedAt ;
      private DateTime i280TituloMovimentoCreatedAt ;
      private DateTime Z279TituloMovimentoDataCredito ;
      private DateTime A279TituloMovimentoDataCredito ;
      private bool returnInSub ;
      private bool Z274TituloMovimentoSoma ;
      private bool A274TituloMovimentoSoma ;
      private bool n281TituloMovimentoUpdatedAt ;
      private bool n280TituloMovimentoCreatedAt ;
      private bool n271TituloMovimentoValor ;
      private bool n272TituloMovimentoTipo ;
      private bool n274TituloMovimentoSoma ;
      private bool n279TituloMovimentoDataCredito ;
      private bool n432TituloMovimentoOpe ;
      private bool n288TipoPagamentoId ;
      private bool n261TituloId ;
      private bool n433TituloMovimentoConta ;
      private bool Gx_longc ;
      private string Z272TituloMovimentoTipo ;
      private string A272TituloMovimentoTipo ;
      private string Z432TituloMovimentoOpe ;
      private string A432TituloMovimentoOpe ;
      private string Z289TipoPagamentoNome ;
      private string A289TipoPagamentoNome ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private int[] BC00167_A270TituloMovimentoId ;
      private DateTime[] BC00167_A280TituloMovimentoCreatedAt ;
      private bool[] BC00167_n280TituloMovimentoCreatedAt ;
      private DateTime[] BC00167_A281TituloMovimentoUpdatedAt ;
      private bool[] BC00167_n281TituloMovimentoUpdatedAt ;
      private decimal[] BC00167_A271TituloMovimentoValor ;
      private bool[] BC00167_n271TituloMovimentoValor ;
      private string[] BC00167_A272TituloMovimentoTipo ;
      private bool[] BC00167_n272TituloMovimentoTipo ;
      private bool[] BC00167_A274TituloMovimentoSoma ;
      private bool[] BC00167_n274TituloMovimentoSoma ;
      private DateTime[] BC00167_A279TituloMovimentoDataCredito ;
      private bool[] BC00167_n279TituloMovimentoDataCredito ;
      private string[] BC00167_A289TipoPagamentoNome ;
      private string[] BC00167_A432TituloMovimentoOpe ;
      private bool[] BC00167_n432TituloMovimentoOpe ;
      private int[] BC00167_A288TipoPagamentoId ;
      private bool[] BC00167_n288TipoPagamentoId ;
      private int[] BC00167_A261TituloId ;
      private bool[] BC00167_n261TituloId ;
      private int[] BC00167_A433TituloMovimentoConta ;
      private bool[] BC00167_n433TituloMovimentoConta ;
      private string[] BC00164_A289TipoPagamentoNome ;
      private int[] BC00165_A261TituloId ;
      private bool[] BC00165_n261TituloId ;
      private int[] BC00166_A433TituloMovimentoConta ;
      private bool[] BC00166_n433TituloMovimentoConta ;
      private int[] BC00168_A270TituloMovimentoId ;
      private int[] BC00163_A270TituloMovimentoId ;
      private DateTime[] BC00163_A280TituloMovimentoCreatedAt ;
      private bool[] BC00163_n280TituloMovimentoCreatedAt ;
      private DateTime[] BC00163_A281TituloMovimentoUpdatedAt ;
      private bool[] BC00163_n281TituloMovimentoUpdatedAt ;
      private decimal[] BC00163_A271TituloMovimentoValor ;
      private bool[] BC00163_n271TituloMovimentoValor ;
      private string[] BC00163_A272TituloMovimentoTipo ;
      private bool[] BC00163_n272TituloMovimentoTipo ;
      private bool[] BC00163_A274TituloMovimentoSoma ;
      private bool[] BC00163_n274TituloMovimentoSoma ;
      private DateTime[] BC00163_A279TituloMovimentoDataCredito ;
      private bool[] BC00163_n279TituloMovimentoDataCredito ;
      private string[] BC00163_A432TituloMovimentoOpe ;
      private bool[] BC00163_n432TituloMovimentoOpe ;
      private int[] BC00163_A288TipoPagamentoId ;
      private bool[] BC00163_n288TipoPagamentoId ;
      private int[] BC00163_A261TituloId ;
      private bool[] BC00163_n261TituloId ;
      private int[] BC00163_A433TituloMovimentoConta ;
      private bool[] BC00163_n433TituloMovimentoConta ;
      private int[] BC00162_A270TituloMovimentoId ;
      private DateTime[] BC00162_A280TituloMovimentoCreatedAt ;
      private bool[] BC00162_n280TituloMovimentoCreatedAt ;
      private DateTime[] BC00162_A281TituloMovimentoUpdatedAt ;
      private bool[] BC00162_n281TituloMovimentoUpdatedAt ;
      private decimal[] BC00162_A271TituloMovimentoValor ;
      private bool[] BC00162_n271TituloMovimentoValor ;
      private string[] BC00162_A272TituloMovimentoTipo ;
      private bool[] BC00162_n272TituloMovimentoTipo ;
      private bool[] BC00162_A274TituloMovimentoSoma ;
      private bool[] BC00162_n274TituloMovimentoSoma ;
      private DateTime[] BC00162_A279TituloMovimentoDataCredito ;
      private bool[] BC00162_n279TituloMovimentoDataCredito ;
      private string[] BC00162_A432TituloMovimentoOpe ;
      private bool[] BC00162_n432TituloMovimentoOpe ;
      private int[] BC00162_A288TipoPagamentoId ;
      private bool[] BC00162_n288TipoPagamentoId ;
      private int[] BC00162_A261TituloId ;
      private bool[] BC00162_n261TituloId ;
      private int[] BC00162_A433TituloMovimentoConta ;
      private bool[] BC00162_n433TituloMovimentoConta ;
      private int[] BC001610_A270TituloMovimentoId ;
      private string[] BC001613_A289TipoPagamentoNome ;
      private int[] BC001614_A270TituloMovimentoId ;
      private DateTime[] BC001614_A280TituloMovimentoCreatedAt ;
      private bool[] BC001614_n280TituloMovimentoCreatedAt ;
      private DateTime[] BC001614_A281TituloMovimentoUpdatedAt ;
      private bool[] BC001614_n281TituloMovimentoUpdatedAt ;
      private decimal[] BC001614_A271TituloMovimentoValor ;
      private bool[] BC001614_n271TituloMovimentoValor ;
      private string[] BC001614_A272TituloMovimentoTipo ;
      private bool[] BC001614_n272TituloMovimentoTipo ;
      private bool[] BC001614_A274TituloMovimentoSoma ;
      private bool[] BC001614_n274TituloMovimentoSoma ;
      private DateTime[] BC001614_A279TituloMovimentoDataCredito ;
      private bool[] BC001614_n279TituloMovimentoDataCredito ;
      private string[] BC001614_A289TipoPagamentoNome ;
      private string[] BC001614_A432TituloMovimentoOpe ;
      private bool[] BC001614_n432TituloMovimentoOpe ;
      private int[] BC001614_A288TipoPagamentoId ;
      private bool[] BC001614_n288TipoPagamentoId ;
      private int[] BC001614_A261TituloId ;
      private bool[] BC001614_n261TituloId ;
      private int[] BC001614_A433TituloMovimentoConta ;
      private bool[] BC001614_n433TituloMovimentoConta ;
      private SdtTituloMovimento bcTituloMovimento ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class titulomovimento_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00162;
          prmBC00162 = new Object[] {
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00163;
          prmBC00163 = new Object[] {
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00164;
          prmBC00164 = new Object[] {
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00165;
          prmBC00165 = new Object[] {
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00166;
          prmBC00166 = new Object[] {
          new ParDef("TituloMovimentoConta",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC00167;
          prmBC00167 = new Object[] {
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00168;
          prmBC00168 = new Object[] {
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmBC00169;
          prmBC00169 = new Object[] {
          new ParDef("TituloMovimentoCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TituloMovimentoUpdatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TituloMovimentoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloMovimentoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TituloMovimentoSoma",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloMovimentoDataCredito",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloMovimentoOpe",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloMovimentoConta",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001610;
          prmBC001610 = new Object[] {
          };
          Object[] prmBC001611;
          prmBC001611 = new Object[] {
          new ParDef("TituloMovimentoCreatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TituloMovimentoUpdatedAt",GXType.DateTime,10,8){Nullable=true} ,
          new ParDef("TituloMovimentoValor",GXType.Number,18,2){Nullable=true} ,
          new ParDef("TituloMovimentoTipo",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TituloMovimentoSoma",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("TituloMovimentoDataCredito",GXType.Date,8,0){Nullable=true} ,
          new ParDef("TituloMovimentoOpe",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloMovimentoConta",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmBC001612;
          prmBC001612 = new Object[] {
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          Object[] prmBC001613;
          prmBC001613 = new Object[] {
          new ParDef("TipoPagamentoId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC001614;
          prmBC001614 = new Object[] {
          new ParDef("TituloMovimentoId",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00162", "SELECT TituloMovimentoId, TituloMovimentoCreatedAt, TituloMovimentoUpdatedAt, TituloMovimentoValor, TituloMovimentoTipo, TituloMovimentoSoma, TituloMovimentoDataCredito, TituloMovimentoOpe, TipoPagamentoId, TituloId, TituloMovimentoConta FROM TituloMovimento WHERE TituloMovimentoId = :TituloMovimentoId  FOR UPDATE OF TituloMovimento",true, GxErrorMask.GX_NOMASK, false, this,prmBC00162,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00163", "SELECT TituloMovimentoId, TituloMovimentoCreatedAt, TituloMovimentoUpdatedAt, TituloMovimentoValor, TituloMovimentoTipo, TituloMovimentoSoma, TituloMovimentoDataCredito, TituloMovimentoOpe, TipoPagamentoId, TituloId, TituloMovimentoConta FROM TituloMovimento WHERE TituloMovimentoId = :TituloMovimentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00163,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00164", "SELECT TipoPagamentoNome FROM TipoPagamento WHERE TipoPagamentoId = :TipoPagamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00164,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00165", "SELECT TituloId FROM Titulo WHERE TituloId = :TituloId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00165,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00166", "SELECT ContaId AS TituloMovimentoConta FROM Conta WHERE ContaId = :TituloMovimentoConta ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00166,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00167", "SELECT TM1.TituloMovimentoId, TM1.TituloMovimentoCreatedAt, TM1.TituloMovimentoUpdatedAt, TM1.TituloMovimentoValor, TM1.TituloMovimentoTipo, TM1.TituloMovimentoSoma, TM1.TituloMovimentoDataCredito, T2.TipoPagamentoNome, TM1.TituloMovimentoOpe, TM1.TipoPagamentoId, TM1.TituloId, TM1.TituloMovimentoConta AS TituloMovimentoConta FROM (TituloMovimento TM1 LEFT JOIN TipoPagamento T2 ON T2.TipoPagamentoId = TM1.TipoPagamentoId) WHERE TM1.TituloMovimentoId = :TituloMovimentoId ORDER BY TM1.TituloMovimentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00167,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00168", "SELECT TituloMovimentoId FROM TituloMovimento WHERE TituloMovimentoId = :TituloMovimentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00168,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00169", "SAVEPOINT gxupdate;INSERT INTO TituloMovimento(TituloMovimentoCreatedAt, TituloMovimentoUpdatedAt, TituloMovimentoValor, TituloMovimentoTipo, TituloMovimentoSoma, TituloMovimentoDataCredito, TituloMovimentoOpe, TipoPagamentoId, TituloId, TituloMovimentoConta) VALUES(:TituloMovimentoCreatedAt, :TituloMovimentoUpdatedAt, :TituloMovimentoValor, :TituloMovimentoTipo, :TituloMovimentoSoma, :TituloMovimentoDataCredito, :TituloMovimentoOpe, :TipoPagamentoId, :TituloId, :TituloMovimentoConta);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00169)
             ,new CursorDef("BC001610", "SELECT currval('TituloMovimentoId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001611", "SAVEPOINT gxupdate;UPDATE TituloMovimento SET TituloMovimentoCreatedAt=:TituloMovimentoCreatedAt, TituloMovimentoUpdatedAt=:TituloMovimentoUpdatedAt, TituloMovimentoValor=:TituloMovimentoValor, TituloMovimentoTipo=:TituloMovimentoTipo, TituloMovimentoSoma=:TituloMovimentoSoma, TituloMovimentoDataCredito=:TituloMovimentoDataCredito, TituloMovimentoOpe=:TituloMovimentoOpe, TipoPagamentoId=:TipoPagamentoId, TituloId=:TituloId, TituloMovimentoConta=:TituloMovimentoConta  WHERE TituloMovimentoId = :TituloMovimentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001611)
             ,new CursorDef("BC001612", "SAVEPOINT gxupdate;DELETE FROM TituloMovimento  WHERE TituloMovimentoId = :TituloMovimentoId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001612)
             ,new CursorDef("BC001613", "SELECT TipoPagamentoNome FROM TipoPagamento WHERE TipoPagamentoId = :TipoPagamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001613,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC001614", "SELECT TM1.TituloMovimentoId, TM1.TituloMovimentoCreatedAt, TM1.TituloMovimentoUpdatedAt, TM1.TituloMovimentoValor, TM1.TituloMovimentoTipo, TM1.TituloMovimentoSoma, TM1.TituloMovimentoDataCredito, T2.TipoPagamentoNome, TM1.TituloMovimentoOpe, TM1.TipoPagamentoId, TM1.TituloId, TM1.TituloMovimentoConta AS TituloMovimentoConta FROM (TituloMovimento TM1 LEFT JOIN TipoPagamento T2 ON T2.TipoPagamentoId = TM1.TipoPagamentoId) WHERE TM1.TituloMovimentoId = :TituloMovimentoId ORDER BY TM1.TituloMovimentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001614,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((int[]) buf[15])[0] = rslt.getInt(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((int[]) buf[17])[0] = rslt.getInt(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((int[]) buf[19])[0] = rslt.getInt(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((string[]) buf[14])[0] = rslt.getVarchar(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((int[]) buf[16])[0] = rslt.getInt(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((int[]) buf[18])[0] = rslt.getInt(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((int[]) buf[20])[0] = rslt.getInt(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 8 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getVarchar(8);
                ((string[]) buf[14])[0] = rslt.getVarchar(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                ((int[]) buf[16])[0] = rslt.getInt(10);
                ((bool[]) buf[17])[0] = rslt.wasNull(10);
                ((int[]) buf[18])[0] = rslt.getInt(11);
                ((bool[]) buf[19])[0] = rslt.wasNull(11);
                ((int[]) buf[20])[0] = rslt.getInt(12);
                ((bool[]) buf[21])[0] = rslt.wasNull(12);
                return;
       }
    }

 }

}
