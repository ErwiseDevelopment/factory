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
   public class notafiscalitem_bc : GxSilentTrn, IGxSilentTrn
   {
      public notafiscalitem_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notafiscalitem_bc( IGxContext context )
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
         ReadRow2O94( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey2O94( ) ;
         standaloneModal( ) ;
         AddRow2O94( ) ;
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
            E112O2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z830NotaFiscalItemId = A830NotaFiscalItemId;
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

      protected void CONFIRM_2O0( )
      {
         BeforeValidate2O94( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2O94( ) ;
            }
            else
            {
               CheckExtendedTable2O94( ) ;
               if ( AnyError == 0 )
               {
                  ZM2O94( 10) ;
                  ZM2O94( 11) ;
               }
               CloseExtendedTableCursors2O94( ) ;
            }
         }
         if ( AnyError == 0 )
         {
         }
      }

      protected void E122O2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV22Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV23GXV1 = 1;
            while ( AV23GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV23GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PropostaId") == 0 )
               {
                  AV11Insert_PropostaId = (int)(Math.Round(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "NotaFiscalId") == 0 )
               {
                  AV12Insert_NotaFiscalId = StringUtil.StrToGuid( AV13TrnContextAtt.gxTpr_Attributevalue);
               }
               AV23GXV1 = (int)(AV23GXV1+1);
            }
         }
      }

      protected void E112O2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2O94( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z831NotaFiscalItemCodigo = A831NotaFiscalItemCodigo;
            Z832NotaFiscalItemCFOP = A832NotaFiscalItemCFOP;
            Z833NotaFiscalItemDescricao = A833NotaFiscalItemDescricao;
            Z834NotaFiscalItemNCM = A834NotaFiscalItemNCM;
            Z835NotaFiscalItemCodigoEAN = A835NotaFiscalItemCodigoEAN;
            Z836NotaFiscalItemUnidadeComercial = A836NotaFiscalItemUnidadeComercial;
            Z837NotaFiscalItemQuantidade = A837NotaFiscalItemQuantidade;
            Z838NotaFiscalItemValorUnitario = A838NotaFiscalItemValorUnitario;
            Z839NotaFiscalItemValorTotal = A839NotaFiscalItemValorTotal;
            Z840NotaFiscalItemCodBarGTIN = A840NotaFiscalItemCodBarGTIN;
            Z841NotaFiscalItemUnidadeTributavel = A841NotaFiscalItemUnidadeTributavel;
            Z842NotaFiscalItemValorUnTributavel = A842NotaFiscalItemValorUnTributavel;
            Z843NotaFiscalItemQtdTributavel = A843NotaFiscalItemQtdTributavel;
            Z844NotaFiscalItemValorFrete = A844NotaFiscalItemValorFrete;
            Z845NotaFiscalItemDesconto = A845NotaFiscalItemDesconto;
            Z846NotaFiscalItemIndicadorValorTotal = A846NotaFiscalItemIndicadorValorTotal;
            Z847NotaFiscalItemNumPedido = A847NotaFiscalItemNumPedido;
            Z848NotaFiscalItemNumItem = A848NotaFiscalItemNumItem;
            Z851NotaFiscalItemVendido = A851NotaFiscalItemVendido;
            Z323PropostaId = A323PropostaId;
            Z794NotaFiscalId = A794NotaFiscalId;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -9 )
         {
            Z830NotaFiscalItemId = A830NotaFiscalItemId;
            Z831NotaFiscalItemCodigo = A831NotaFiscalItemCodigo;
            Z832NotaFiscalItemCFOP = A832NotaFiscalItemCFOP;
            Z833NotaFiscalItemDescricao = A833NotaFiscalItemDescricao;
            Z834NotaFiscalItemNCM = A834NotaFiscalItemNCM;
            Z835NotaFiscalItemCodigoEAN = A835NotaFiscalItemCodigoEAN;
            Z836NotaFiscalItemUnidadeComercial = A836NotaFiscalItemUnidadeComercial;
            Z837NotaFiscalItemQuantidade = A837NotaFiscalItemQuantidade;
            Z838NotaFiscalItemValorUnitario = A838NotaFiscalItemValorUnitario;
            Z839NotaFiscalItemValorTotal = A839NotaFiscalItemValorTotal;
            Z840NotaFiscalItemCodBarGTIN = A840NotaFiscalItemCodBarGTIN;
            Z841NotaFiscalItemUnidadeTributavel = A841NotaFiscalItemUnidadeTributavel;
            Z842NotaFiscalItemValorUnTributavel = A842NotaFiscalItemValorUnTributavel;
            Z843NotaFiscalItemQtdTributavel = A843NotaFiscalItemQtdTributavel;
            Z844NotaFiscalItemValorFrete = A844NotaFiscalItemValorFrete;
            Z845NotaFiscalItemDesconto = A845NotaFiscalItemDesconto;
            Z846NotaFiscalItemIndicadorValorTotal = A846NotaFiscalItemIndicadorValorTotal;
            Z847NotaFiscalItemNumPedido = A847NotaFiscalItemNumPedido;
            Z848NotaFiscalItemNumItem = A848NotaFiscalItemNumItem;
            Z851NotaFiscalItemVendido = A851NotaFiscalItemVendido;
            Z323PropostaId = A323PropostaId;
            Z794NotaFiscalId = A794NotaFiscalId;
         }
      }

      protected void standaloneNotModal( )
      {
         AV22Pgmname = "NotaFiscalItem_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A830NotaFiscalItemId) )
         {
            A830NotaFiscalItemId = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load2O94( )
      {
         /* Using cursor BC002O6 */
         pr_default.execute(4, new Object[] {A830NotaFiscalItemId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound94 = 1;
            A831NotaFiscalItemCodigo = BC002O6_A831NotaFiscalItemCodigo[0];
            n831NotaFiscalItemCodigo = BC002O6_n831NotaFiscalItemCodigo[0];
            A832NotaFiscalItemCFOP = BC002O6_A832NotaFiscalItemCFOP[0];
            n832NotaFiscalItemCFOP = BC002O6_n832NotaFiscalItemCFOP[0];
            A833NotaFiscalItemDescricao = BC002O6_A833NotaFiscalItemDescricao[0];
            n833NotaFiscalItemDescricao = BC002O6_n833NotaFiscalItemDescricao[0];
            A834NotaFiscalItemNCM = BC002O6_A834NotaFiscalItemNCM[0];
            n834NotaFiscalItemNCM = BC002O6_n834NotaFiscalItemNCM[0];
            A835NotaFiscalItemCodigoEAN = BC002O6_A835NotaFiscalItemCodigoEAN[0];
            n835NotaFiscalItemCodigoEAN = BC002O6_n835NotaFiscalItemCodigoEAN[0];
            A836NotaFiscalItemUnidadeComercial = BC002O6_A836NotaFiscalItemUnidadeComercial[0];
            n836NotaFiscalItemUnidadeComercial = BC002O6_n836NotaFiscalItemUnidadeComercial[0];
            A837NotaFiscalItemQuantidade = BC002O6_A837NotaFiscalItemQuantidade[0];
            n837NotaFiscalItemQuantidade = BC002O6_n837NotaFiscalItemQuantidade[0];
            A838NotaFiscalItemValorUnitario = BC002O6_A838NotaFiscalItemValorUnitario[0];
            n838NotaFiscalItemValorUnitario = BC002O6_n838NotaFiscalItemValorUnitario[0];
            A839NotaFiscalItemValorTotal = BC002O6_A839NotaFiscalItemValorTotal[0];
            n839NotaFiscalItemValorTotal = BC002O6_n839NotaFiscalItemValorTotal[0];
            A840NotaFiscalItemCodBarGTIN = BC002O6_A840NotaFiscalItemCodBarGTIN[0];
            n840NotaFiscalItemCodBarGTIN = BC002O6_n840NotaFiscalItemCodBarGTIN[0];
            A841NotaFiscalItemUnidadeTributavel = BC002O6_A841NotaFiscalItemUnidadeTributavel[0];
            n841NotaFiscalItemUnidadeTributavel = BC002O6_n841NotaFiscalItemUnidadeTributavel[0];
            A842NotaFiscalItemValorUnTributavel = BC002O6_A842NotaFiscalItemValorUnTributavel[0];
            n842NotaFiscalItemValorUnTributavel = BC002O6_n842NotaFiscalItemValorUnTributavel[0];
            A843NotaFiscalItemQtdTributavel = BC002O6_A843NotaFiscalItemQtdTributavel[0];
            n843NotaFiscalItemQtdTributavel = BC002O6_n843NotaFiscalItemQtdTributavel[0];
            A844NotaFiscalItemValorFrete = BC002O6_A844NotaFiscalItemValorFrete[0];
            n844NotaFiscalItemValorFrete = BC002O6_n844NotaFiscalItemValorFrete[0];
            A845NotaFiscalItemDesconto = BC002O6_A845NotaFiscalItemDesconto[0];
            n845NotaFiscalItemDesconto = BC002O6_n845NotaFiscalItemDesconto[0];
            A846NotaFiscalItemIndicadorValorTotal = BC002O6_A846NotaFiscalItemIndicadorValorTotal[0];
            n846NotaFiscalItemIndicadorValorTotal = BC002O6_n846NotaFiscalItemIndicadorValorTotal[0];
            A847NotaFiscalItemNumPedido = BC002O6_A847NotaFiscalItemNumPedido[0];
            n847NotaFiscalItemNumPedido = BC002O6_n847NotaFiscalItemNumPedido[0];
            A848NotaFiscalItemNumItem = BC002O6_A848NotaFiscalItemNumItem[0];
            n848NotaFiscalItemNumItem = BC002O6_n848NotaFiscalItemNumItem[0];
            A851NotaFiscalItemVendido = BC002O6_A851NotaFiscalItemVendido[0];
            n851NotaFiscalItemVendido = BC002O6_n851NotaFiscalItemVendido[0];
            A323PropostaId = BC002O6_A323PropostaId[0];
            n323PropostaId = BC002O6_n323PropostaId[0];
            A794NotaFiscalId = BC002O6_A794NotaFiscalId[0];
            n794NotaFiscalId = BC002O6_n794NotaFiscalId[0];
            ZM2O94( -9) ;
         }
         pr_default.close(4);
         OnLoadActions2O94( ) ;
      }

      protected void OnLoadActions2O94( )
      {
         if ( (0==A323PropostaId) )
         {
            A323PropostaId = 0;
            n323PropostaId = false;
            n323PropostaId = true;
            n323PropostaId = true;
         }
      }

      protected void CheckExtendedTable2O94( )
      {
         standaloneModal( ) ;
         if ( (0==A323PropostaId) )
         {
            A323PropostaId = 0;
            n323PropostaId = false;
            n323PropostaId = true;
            n323PropostaId = true;
         }
         /* Using cursor BC002O4 */
         pr_default.execute(2, new Object[] {n323PropostaId, A323PropostaId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A323PropostaId) ) )
            {
               GX_msglist.addItem("Não existe 'Proposta'.", "ForeignKeyNotFound", 1, "PROPOSTAID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
         /* Using cursor BC002O5 */
         pr_default.execute(3, new Object[] {n794NotaFiscalId, A794NotaFiscalId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A794NotaFiscalId) ) )
            {
               GX_msglist.addItem("Não existe 'NotaFiscal'.", "ForeignKeyNotFound", 1, "NOTAFISCALID");
               AnyError = 1;
            }
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A846NotaFiscalItemIndicadorValorTotal, "1") == 0 ) || ( StringUtil.StrCmp(A846NotaFiscalItemIndicadorValorTotal, "0") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A846NotaFiscalItemIndicadorValorTotal)) ) )
         {
            GX_msglist.addItem("Campo Nota Fiscal Item Indicador Valor Total fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( ( StringUtil.StrCmp(A851NotaFiscalItemVendido, "VENDIDO") == 0 ) || ( StringUtil.StrCmp(A851NotaFiscalItemVendido, "ABERTO") == 0 ) || ( StringUtil.StrCmp(A851NotaFiscalItemVendido, "DEVOLVIDO") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( A851NotaFiscalItemVendido)) ) )
         {
            GX_msglist.addItem("Campo Nota Fiscal Item Vendido fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors2O94( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2O94( )
      {
         /* Using cursor BC002O7 */
         pr_default.execute(5, new Object[] {A830NotaFiscalItemId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound94 = 1;
         }
         else
         {
            RcdFound94 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC002O3 */
         pr_default.execute(1, new Object[] {A830NotaFiscalItemId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2O94( 9) ;
            RcdFound94 = 1;
            A830NotaFiscalItemId = BC002O3_A830NotaFiscalItemId[0];
            A831NotaFiscalItemCodigo = BC002O3_A831NotaFiscalItemCodigo[0];
            n831NotaFiscalItemCodigo = BC002O3_n831NotaFiscalItemCodigo[0];
            A832NotaFiscalItemCFOP = BC002O3_A832NotaFiscalItemCFOP[0];
            n832NotaFiscalItemCFOP = BC002O3_n832NotaFiscalItemCFOP[0];
            A833NotaFiscalItemDescricao = BC002O3_A833NotaFiscalItemDescricao[0];
            n833NotaFiscalItemDescricao = BC002O3_n833NotaFiscalItemDescricao[0];
            A834NotaFiscalItemNCM = BC002O3_A834NotaFiscalItemNCM[0];
            n834NotaFiscalItemNCM = BC002O3_n834NotaFiscalItemNCM[0];
            A835NotaFiscalItemCodigoEAN = BC002O3_A835NotaFiscalItemCodigoEAN[0];
            n835NotaFiscalItemCodigoEAN = BC002O3_n835NotaFiscalItemCodigoEAN[0];
            A836NotaFiscalItemUnidadeComercial = BC002O3_A836NotaFiscalItemUnidadeComercial[0];
            n836NotaFiscalItemUnidadeComercial = BC002O3_n836NotaFiscalItemUnidadeComercial[0];
            A837NotaFiscalItemQuantidade = BC002O3_A837NotaFiscalItemQuantidade[0];
            n837NotaFiscalItemQuantidade = BC002O3_n837NotaFiscalItemQuantidade[0];
            A838NotaFiscalItemValorUnitario = BC002O3_A838NotaFiscalItemValorUnitario[0];
            n838NotaFiscalItemValorUnitario = BC002O3_n838NotaFiscalItemValorUnitario[0];
            A839NotaFiscalItemValorTotal = BC002O3_A839NotaFiscalItemValorTotal[0];
            n839NotaFiscalItemValorTotal = BC002O3_n839NotaFiscalItemValorTotal[0];
            A840NotaFiscalItemCodBarGTIN = BC002O3_A840NotaFiscalItemCodBarGTIN[0];
            n840NotaFiscalItemCodBarGTIN = BC002O3_n840NotaFiscalItemCodBarGTIN[0];
            A841NotaFiscalItemUnidadeTributavel = BC002O3_A841NotaFiscalItemUnidadeTributavel[0];
            n841NotaFiscalItemUnidadeTributavel = BC002O3_n841NotaFiscalItemUnidadeTributavel[0];
            A842NotaFiscalItemValorUnTributavel = BC002O3_A842NotaFiscalItemValorUnTributavel[0];
            n842NotaFiscalItemValorUnTributavel = BC002O3_n842NotaFiscalItemValorUnTributavel[0];
            A843NotaFiscalItemQtdTributavel = BC002O3_A843NotaFiscalItemQtdTributavel[0];
            n843NotaFiscalItemQtdTributavel = BC002O3_n843NotaFiscalItemQtdTributavel[0];
            A844NotaFiscalItemValorFrete = BC002O3_A844NotaFiscalItemValorFrete[0];
            n844NotaFiscalItemValorFrete = BC002O3_n844NotaFiscalItemValorFrete[0];
            A845NotaFiscalItemDesconto = BC002O3_A845NotaFiscalItemDesconto[0];
            n845NotaFiscalItemDesconto = BC002O3_n845NotaFiscalItemDesconto[0];
            A846NotaFiscalItemIndicadorValorTotal = BC002O3_A846NotaFiscalItemIndicadorValorTotal[0];
            n846NotaFiscalItemIndicadorValorTotal = BC002O3_n846NotaFiscalItemIndicadorValorTotal[0];
            A847NotaFiscalItemNumPedido = BC002O3_A847NotaFiscalItemNumPedido[0];
            n847NotaFiscalItemNumPedido = BC002O3_n847NotaFiscalItemNumPedido[0];
            A848NotaFiscalItemNumItem = BC002O3_A848NotaFiscalItemNumItem[0];
            n848NotaFiscalItemNumItem = BC002O3_n848NotaFiscalItemNumItem[0];
            A851NotaFiscalItemVendido = BC002O3_A851NotaFiscalItemVendido[0];
            n851NotaFiscalItemVendido = BC002O3_n851NotaFiscalItemVendido[0];
            A323PropostaId = BC002O3_A323PropostaId[0];
            n323PropostaId = BC002O3_n323PropostaId[0];
            A794NotaFiscalId = BC002O3_A794NotaFiscalId[0];
            n794NotaFiscalId = BC002O3_n794NotaFiscalId[0];
            Z830NotaFiscalItemId = A830NotaFiscalItemId;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load2O94( ) ;
            if ( AnyError == 1 )
            {
               RcdFound94 = 0;
               InitializeNonKey2O94( ) ;
            }
            Gx_mode = sMode94;
         }
         else
         {
            RcdFound94 = 0;
            InitializeNonKey2O94( ) ;
            sMode94 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode94;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2O94( ) ;
         if ( RcdFound94 == 0 )
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
         CONFIRM_2O0( ) ;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency2O94( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC002O2 */
            pr_default.execute(0, new Object[] {A830NotaFiscalItemId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotaFiscalItem"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z831NotaFiscalItemCodigo, BC002O2_A831NotaFiscalItemCodigo[0]) != 0 ) || ( Z832NotaFiscalItemCFOP != BC002O2_A832NotaFiscalItemCFOP[0] ) || ( StringUtil.StrCmp(Z833NotaFiscalItemDescricao, BC002O2_A833NotaFiscalItemDescricao[0]) != 0 ) || ( StringUtil.StrCmp(Z834NotaFiscalItemNCM, BC002O2_A834NotaFiscalItemNCM[0]) != 0 ) || ( StringUtil.StrCmp(Z835NotaFiscalItemCodigoEAN, BC002O2_A835NotaFiscalItemCodigoEAN[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z836NotaFiscalItemUnidadeComercial, BC002O2_A836NotaFiscalItemUnidadeComercial[0]) != 0 ) || ( Z837NotaFiscalItemQuantidade != BC002O2_A837NotaFiscalItemQuantidade[0] ) || ( Z838NotaFiscalItemValorUnitario != BC002O2_A838NotaFiscalItemValorUnitario[0] ) || ( Z839NotaFiscalItemValorTotal != BC002O2_A839NotaFiscalItemValorTotal[0] ) || ( StringUtil.StrCmp(Z840NotaFiscalItemCodBarGTIN, BC002O2_A840NotaFiscalItemCodBarGTIN[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z841NotaFiscalItemUnidadeTributavel, BC002O2_A841NotaFiscalItemUnidadeTributavel[0]) != 0 ) || ( Z842NotaFiscalItemValorUnTributavel != BC002O2_A842NotaFiscalItemValorUnTributavel[0] ) || ( Z843NotaFiscalItemQtdTributavel != BC002O2_A843NotaFiscalItemQtdTributavel[0] ) || ( Z844NotaFiscalItemValorFrete != BC002O2_A844NotaFiscalItemValorFrete[0] ) || ( Z845NotaFiscalItemDesconto != BC002O2_A845NotaFiscalItemDesconto[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z846NotaFiscalItemIndicadorValorTotal, BC002O2_A846NotaFiscalItemIndicadorValorTotal[0]) != 0 ) || ( StringUtil.StrCmp(Z847NotaFiscalItemNumPedido, BC002O2_A847NotaFiscalItemNumPedido[0]) != 0 ) || ( StringUtil.StrCmp(Z848NotaFiscalItemNumItem, BC002O2_A848NotaFiscalItemNumItem[0]) != 0 ) || ( StringUtil.StrCmp(Z851NotaFiscalItemVendido, BC002O2_A851NotaFiscalItemVendido[0]) != 0 ) || ( Z323PropostaId != BC002O2_A323PropostaId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z794NotaFiscalId != BC002O2_A794NotaFiscalId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"NotaFiscalItem"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2O94( )
      {
         BeforeValidate2O94( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2O94( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2O94( 0) ;
            CheckOptimisticConcurrency2O94( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2O94( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2O94( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002O8 */
                     pr_default.execute(6, new Object[] {A830NotaFiscalItemId, n831NotaFiscalItemCodigo, A831NotaFiscalItemCodigo, n832NotaFiscalItemCFOP, A832NotaFiscalItemCFOP, n833NotaFiscalItemDescricao, A833NotaFiscalItemDescricao, n834NotaFiscalItemNCM, A834NotaFiscalItemNCM, n835NotaFiscalItemCodigoEAN, A835NotaFiscalItemCodigoEAN, n836NotaFiscalItemUnidadeComercial, A836NotaFiscalItemUnidadeComercial, n837NotaFiscalItemQuantidade, A837NotaFiscalItemQuantidade, n838NotaFiscalItemValorUnitario, A838NotaFiscalItemValorUnitario, n839NotaFiscalItemValorTotal, A839NotaFiscalItemValorTotal, n840NotaFiscalItemCodBarGTIN, A840NotaFiscalItemCodBarGTIN, n841NotaFiscalItemUnidadeTributavel, A841NotaFiscalItemUnidadeTributavel, n842NotaFiscalItemValorUnTributavel, A842NotaFiscalItemValorUnTributavel, n843NotaFiscalItemQtdTributavel, A843NotaFiscalItemQtdTributavel, n844NotaFiscalItemValorFrete, A844NotaFiscalItemValorFrete, n845NotaFiscalItemDesconto, A845NotaFiscalItemDesconto, n846NotaFiscalItemIndicadorValorTotal, A846NotaFiscalItemIndicadorValorTotal, n847NotaFiscalItemNumPedido, A847NotaFiscalItemNumPedido, n848NotaFiscalItemNumItem, A848NotaFiscalItemNumItem, n851NotaFiscalItemVendido, A851NotaFiscalItemVendido, n323PropostaId, A323PropostaId, n794NotaFiscalId, A794NotaFiscalId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("NotaFiscalItem");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
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
               Load2O94( ) ;
            }
            EndLevel2O94( ) ;
         }
         CloseExtendedTableCursors2O94( ) ;
      }

      protected void Update2O94( )
      {
         BeforeValidate2O94( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2O94( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2O94( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2O94( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2O94( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC002O9 */
                     pr_default.execute(7, new Object[] {n831NotaFiscalItemCodigo, A831NotaFiscalItemCodigo, n832NotaFiscalItemCFOP, A832NotaFiscalItemCFOP, n833NotaFiscalItemDescricao, A833NotaFiscalItemDescricao, n834NotaFiscalItemNCM, A834NotaFiscalItemNCM, n835NotaFiscalItemCodigoEAN, A835NotaFiscalItemCodigoEAN, n836NotaFiscalItemUnidadeComercial, A836NotaFiscalItemUnidadeComercial, n837NotaFiscalItemQuantidade, A837NotaFiscalItemQuantidade, n838NotaFiscalItemValorUnitario, A838NotaFiscalItemValorUnitario, n839NotaFiscalItemValorTotal, A839NotaFiscalItemValorTotal, n840NotaFiscalItemCodBarGTIN, A840NotaFiscalItemCodBarGTIN, n841NotaFiscalItemUnidadeTributavel, A841NotaFiscalItemUnidadeTributavel, n842NotaFiscalItemValorUnTributavel, A842NotaFiscalItemValorUnTributavel, n843NotaFiscalItemQtdTributavel, A843NotaFiscalItemQtdTributavel, n844NotaFiscalItemValorFrete, A844NotaFiscalItemValorFrete, n845NotaFiscalItemDesconto, A845NotaFiscalItemDesconto, n846NotaFiscalItemIndicadorValorTotal, A846NotaFiscalItemIndicadorValorTotal, n847NotaFiscalItemNumPedido, A847NotaFiscalItemNumPedido, n848NotaFiscalItemNumItem, A848NotaFiscalItemNumItem, n851NotaFiscalItemVendido, A851NotaFiscalItemVendido, n323PropostaId, A323PropostaId, n794NotaFiscalId, A794NotaFiscalId, A830NotaFiscalItemId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("NotaFiscalItem");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"NotaFiscalItem"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2O94( ) ;
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
            EndLevel2O94( ) ;
         }
         CloseExtendedTableCursors2O94( ) ;
      }

      protected void DeferredUpdate2O94( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate2O94( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2O94( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2O94( ) ;
            AfterConfirm2O94( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2O94( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC002O10 */
                  pr_default.execute(8, new Object[] {A830NotaFiscalItemId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("NotaFiscalItem");
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
         sMode94 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel2O94( ) ;
         Gx_mode = sMode94;
      }

      protected void OnDeleteControls2O94( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2O94( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2O94( ) ;
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

      public void ScanKeyStart2O94( )
      {
         /* Scan By routine */
         /* Using cursor BC002O11 */
         pr_default.execute(9, new Object[] {A830NotaFiscalItemId});
         RcdFound94 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound94 = 1;
            A830NotaFiscalItemId = BC002O11_A830NotaFiscalItemId[0];
            A831NotaFiscalItemCodigo = BC002O11_A831NotaFiscalItemCodigo[0];
            n831NotaFiscalItemCodigo = BC002O11_n831NotaFiscalItemCodigo[0];
            A832NotaFiscalItemCFOP = BC002O11_A832NotaFiscalItemCFOP[0];
            n832NotaFiscalItemCFOP = BC002O11_n832NotaFiscalItemCFOP[0];
            A833NotaFiscalItemDescricao = BC002O11_A833NotaFiscalItemDescricao[0];
            n833NotaFiscalItemDescricao = BC002O11_n833NotaFiscalItemDescricao[0];
            A834NotaFiscalItemNCM = BC002O11_A834NotaFiscalItemNCM[0];
            n834NotaFiscalItemNCM = BC002O11_n834NotaFiscalItemNCM[0];
            A835NotaFiscalItemCodigoEAN = BC002O11_A835NotaFiscalItemCodigoEAN[0];
            n835NotaFiscalItemCodigoEAN = BC002O11_n835NotaFiscalItemCodigoEAN[0];
            A836NotaFiscalItemUnidadeComercial = BC002O11_A836NotaFiscalItemUnidadeComercial[0];
            n836NotaFiscalItemUnidadeComercial = BC002O11_n836NotaFiscalItemUnidadeComercial[0];
            A837NotaFiscalItemQuantidade = BC002O11_A837NotaFiscalItemQuantidade[0];
            n837NotaFiscalItemQuantidade = BC002O11_n837NotaFiscalItemQuantidade[0];
            A838NotaFiscalItemValorUnitario = BC002O11_A838NotaFiscalItemValorUnitario[0];
            n838NotaFiscalItemValorUnitario = BC002O11_n838NotaFiscalItemValorUnitario[0];
            A839NotaFiscalItemValorTotal = BC002O11_A839NotaFiscalItemValorTotal[0];
            n839NotaFiscalItemValorTotal = BC002O11_n839NotaFiscalItemValorTotal[0];
            A840NotaFiscalItemCodBarGTIN = BC002O11_A840NotaFiscalItemCodBarGTIN[0];
            n840NotaFiscalItemCodBarGTIN = BC002O11_n840NotaFiscalItemCodBarGTIN[0];
            A841NotaFiscalItemUnidadeTributavel = BC002O11_A841NotaFiscalItemUnidadeTributavel[0];
            n841NotaFiscalItemUnidadeTributavel = BC002O11_n841NotaFiscalItemUnidadeTributavel[0];
            A842NotaFiscalItemValorUnTributavel = BC002O11_A842NotaFiscalItemValorUnTributavel[0];
            n842NotaFiscalItemValorUnTributavel = BC002O11_n842NotaFiscalItemValorUnTributavel[0];
            A843NotaFiscalItemQtdTributavel = BC002O11_A843NotaFiscalItemQtdTributavel[0];
            n843NotaFiscalItemQtdTributavel = BC002O11_n843NotaFiscalItemQtdTributavel[0];
            A844NotaFiscalItemValorFrete = BC002O11_A844NotaFiscalItemValorFrete[0];
            n844NotaFiscalItemValorFrete = BC002O11_n844NotaFiscalItemValorFrete[0];
            A845NotaFiscalItemDesconto = BC002O11_A845NotaFiscalItemDesconto[0];
            n845NotaFiscalItemDesconto = BC002O11_n845NotaFiscalItemDesconto[0];
            A846NotaFiscalItemIndicadorValorTotal = BC002O11_A846NotaFiscalItemIndicadorValorTotal[0];
            n846NotaFiscalItemIndicadorValorTotal = BC002O11_n846NotaFiscalItemIndicadorValorTotal[0];
            A847NotaFiscalItemNumPedido = BC002O11_A847NotaFiscalItemNumPedido[0];
            n847NotaFiscalItemNumPedido = BC002O11_n847NotaFiscalItemNumPedido[0];
            A848NotaFiscalItemNumItem = BC002O11_A848NotaFiscalItemNumItem[0];
            n848NotaFiscalItemNumItem = BC002O11_n848NotaFiscalItemNumItem[0];
            A851NotaFiscalItemVendido = BC002O11_A851NotaFiscalItemVendido[0];
            n851NotaFiscalItemVendido = BC002O11_n851NotaFiscalItemVendido[0];
            A323PropostaId = BC002O11_A323PropostaId[0];
            n323PropostaId = BC002O11_n323PropostaId[0];
            A794NotaFiscalId = BC002O11_A794NotaFiscalId[0];
            n794NotaFiscalId = BC002O11_n794NotaFiscalId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext2O94( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound94 = 0;
         ScanKeyLoad2O94( ) ;
      }

      protected void ScanKeyLoad2O94( )
      {
         sMode94 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound94 = 1;
            A830NotaFiscalItemId = BC002O11_A830NotaFiscalItemId[0];
            A831NotaFiscalItemCodigo = BC002O11_A831NotaFiscalItemCodigo[0];
            n831NotaFiscalItemCodigo = BC002O11_n831NotaFiscalItemCodigo[0];
            A832NotaFiscalItemCFOP = BC002O11_A832NotaFiscalItemCFOP[0];
            n832NotaFiscalItemCFOP = BC002O11_n832NotaFiscalItemCFOP[0];
            A833NotaFiscalItemDescricao = BC002O11_A833NotaFiscalItemDescricao[0];
            n833NotaFiscalItemDescricao = BC002O11_n833NotaFiscalItemDescricao[0];
            A834NotaFiscalItemNCM = BC002O11_A834NotaFiscalItemNCM[0];
            n834NotaFiscalItemNCM = BC002O11_n834NotaFiscalItemNCM[0];
            A835NotaFiscalItemCodigoEAN = BC002O11_A835NotaFiscalItemCodigoEAN[0];
            n835NotaFiscalItemCodigoEAN = BC002O11_n835NotaFiscalItemCodigoEAN[0];
            A836NotaFiscalItemUnidadeComercial = BC002O11_A836NotaFiscalItemUnidadeComercial[0];
            n836NotaFiscalItemUnidadeComercial = BC002O11_n836NotaFiscalItemUnidadeComercial[0];
            A837NotaFiscalItemQuantidade = BC002O11_A837NotaFiscalItemQuantidade[0];
            n837NotaFiscalItemQuantidade = BC002O11_n837NotaFiscalItemQuantidade[0];
            A838NotaFiscalItemValorUnitario = BC002O11_A838NotaFiscalItemValorUnitario[0];
            n838NotaFiscalItemValorUnitario = BC002O11_n838NotaFiscalItemValorUnitario[0];
            A839NotaFiscalItemValorTotal = BC002O11_A839NotaFiscalItemValorTotal[0];
            n839NotaFiscalItemValorTotal = BC002O11_n839NotaFiscalItemValorTotal[0];
            A840NotaFiscalItemCodBarGTIN = BC002O11_A840NotaFiscalItemCodBarGTIN[0];
            n840NotaFiscalItemCodBarGTIN = BC002O11_n840NotaFiscalItemCodBarGTIN[0];
            A841NotaFiscalItemUnidadeTributavel = BC002O11_A841NotaFiscalItemUnidadeTributavel[0];
            n841NotaFiscalItemUnidadeTributavel = BC002O11_n841NotaFiscalItemUnidadeTributavel[0];
            A842NotaFiscalItemValorUnTributavel = BC002O11_A842NotaFiscalItemValorUnTributavel[0];
            n842NotaFiscalItemValorUnTributavel = BC002O11_n842NotaFiscalItemValorUnTributavel[0];
            A843NotaFiscalItemQtdTributavel = BC002O11_A843NotaFiscalItemQtdTributavel[0];
            n843NotaFiscalItemQtdTributavel = BC002O11_n843NotaFiscalItemQtdTributavel[0];
            A844NotaFiscalItemValorFrete = BC002O11_A844NotaFiscalItemValorFrete[0];
            n844NotaFiscalItemValorFrete = BC002O11_n844NotaFiscalItemValorFrete[0];
            A845NotaFiscalItemDesconto = BC002O11_A845NotaFiscalItemDesconto[0];
            n845NotaFiscalItemDesconto = BC002O11_n845NotaFiscalItemDesconto[0];
            A846NotaFiscalItemIndicadorValorTotal = BC002O11_A846NotaFiscalItemIndicadorValorTotal[0];
            n846NotaFiscalItemIndicadorValorTotal = BC002O11_n846NotaFiscalItemIndicadorValorTotal[0];
            A847NotaFiscalItemNumPedido = BC002O11_A847NotaFiscalItemNumPedido[0];
            n847NotaFiscalItemNumPedido = BC002O11_n847NotaFiscalItemNumPedido[0];
            A848NotaFiscalItemNumItem = BC002O11_A848NotaFiscalItemNumItem[0];
            n848NotaFiscalItemNumItem = BC002O11_n848NotaFiscalItemNumItem[0];
            A851NotaFiscalItemVendido = BC002O11_A851NotaFiscalItemVendido[0];
            n851NotaFiscalItemVendido = BC002O11_n851NotaFiscalItemVendido[0];
            A323PropostaId = BC002O11_A323PropostaId[0];
            n323PropostaId = BC002O11_n323PropostaId[0];
            A794NotaFiscalId = BC002O11_A794NotaFiscalId[0];
            n794NotaFiscalId = BC002O11_n794NotaFiscalId[0];
         }
         Gx_mode = sMode94;
      }

      protected void ScanKeyEnd2O94( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm2O94( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2O94( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2O94( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2O94( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2O94( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2O94( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2O94( )
      {
      }

      protected void send_integrity_lvl_hashes2O94( )
      {
      }

      protected void AddRow2O94( )
      {
         VarsToRow94( bcNotaFiscalItem) ;
      }

      protected void ReadRow2O94( )
      {
         RowToVars94( bcNotaFiscalItem, 1) ;
      }

      protected void InitializeNonKey2O94( )
      {
         A323PropostaId = 0;
         n323PropostaId = false;
         A794NotaFiscalId = Guid.Empty;
         n794NotaFiscalId = false;
         A831NotaFiscalItemCodigo = "";
         n831NotaFiscalItemCodigo = false;
         A832NotaFiscalItemCFOP = 0;
         n832NotaFiscalItemCFOP = false;
         A833NotaFiscalItemDescricao = "";
         n833NotaFiscalItemDescricao = false;
         A834NotaFiscalItemNCM = "";
         n834NotaFiscalItemNCM = false;
         A835NotaFiscalItemCodigoEAN = "";
         n835NotaFiscalItemCodigoEAN = false;
         A836NotaFiscalItemUnidadeComercial = "";
         n836NotaFiscalItemUnidadeComercial = false;
         A837NotaFiscalItemQuantidade = 0;
         n837NotaFiscalItemQuantidade = false;
         A838NotaFiscalItemValorUnitario = 0;
         n838NotaFiscalItemValorUnitario = false;
         A839NotaFiscalItemValorTotal = 0;
         n839NotaFiscalItemValorTotal = false;
         A840NotaFiscalItemCodBarGTIN = "";
         n840NotaFiscalItemCodBarGTIN = false;
         A841NotaFiscalItemUnidadeTributavel = "";
         n841NotaFiscalItemUnidadeTributavel = false;
         A842NotaFiscalItemValorUnTributavel = 0;
         n842NotaFiscalItemValorUnTributavel = false;
         A843NotaFiscalItemQtdTributavel = 0;
         n843NotaFiscalItemQtdTributavel = false;
         A844NotaFiscalItemValorFrete = 0;
         n844NotaFiscalItemValorFrete = false;
         A845NotaFiscalItemDesconto = 0;
         n845NotaFiscalItemDesconto = false;
         A846NotaFiscalItemIndicadorValorTotal = "";
         n846NotaFiscalItemIndicadorValorTotal = false;
         A847NotaFiscalItemNumPedido = "";
         n847NotaFiscalItemNumPedido = false;
         A848NotaFiscalItemNumItem = "";
         n848NotaFiscalItemNumItem = false;
         A851NotaFiscalItemVendido = "";
         n851NotaFiscalItemVendido = false;
         Z831NotaFiscalItemCodigo = "";
         Z832NotaFiscalItemCFOP = 0;
         Z833NotaFiscalItemDescricao = "";
         Z834NotaFiscalItemNCM = "";
         Z835NotaFiscalItemCodigoEAN = "";
         Z836NotaFiscalItemUnidadeComercial = "";
         Z837NotaFiscalItemQuantidade = 0;
         Z838NotaFiscalItemValorUnitario = 0;
         Z839NotaFiscalItemValorTotal = 0;
         Z840NotaFiscalItemCodBarGTIN = "";
         Z841NotaFiscalItemUnidadeTributavel = "";
         Z842NotaFiscalItemValorUnTributavel = 0;
         Z843NotaFiscalItemQtdTributavel = 0;
         Z844NotaFiscalItemValorFrete = 0;
         Z845NotaFiscalItemDesconto = 0;
         Z846NotaFiscalItemIndicadorValorTotal = "";
         Z847NotaFiscalItemNumPedido = "";
         Z848NotaFiscalItemNumItem = "";
         Z851NotaFiscalItemVendido = "";
         Z323PropostaId = 0;
         Z794NotaFiscalId = Guid.Empty;
      }

      protected void InitAll2O94( )
      {
         A830NotaFiscalItemId = Guid.NewGuid( );
         InitializeNonKey2O94( ) ;
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

      public void VarsToRow94( SdtNotaFiscalItem obj94 )
      {
         obj94.gxTpr_Mode = Gx_mode;
         obj94.gxTpr_Propostaid = A323PropostaId;
         obj94.gxTpr_Notafiscalid = A794NotaFiscalId;
         obj94.gxTpr_Notafiscalitemcodigo = A831NotaFiscalItemCodigo;
         obj94.gxTpr_Notafiscalitemcfop = A832NotaFiscalItemCFOP;
         obj94.gxTpr_Notafiscalitemdescricao = A833NotaFiscalItemDescricao;
         obj94.gxTpr_Notafiscalitemncm = A834NotaFiscalItemNCM;
         obj94.gxTpr_Notafiscalitemcodigoean = A835NotaFiscalItemCodigoEAN;
         obj94.gxTpr_Notafiscalitemunidadecomercial = A836NotaFiscalItemUnidadeComercial;
         obj94.gxTpr_Notafiscalitemquantidade = A837NotaFiscalItemQuantidade;
         obj94.gxTpr_Notafiscalitemvalorunitario = A838NotaFiscalItemValorUnitario;
         obj94.gxTpr_Notafiscalitemvalortotal = A839NotaFiscalItemValorTotal;
         obj94.gxTpr_Notafiscalitemcodbargtin = A840NotaFiscalItemCodBarGTIN;
         obj94.gxTpr_Notafiscalitemunidadetributavel = A841NotaFiscalItemUnidadeTributavel;
         obj94.gxTpr_Notafiscalitemvaloruntributavel = A842NotaFiscalItemValorUnTributavel;
         obj94.gxTpr_Notafiscalitemqtdtributavel = A843NotaFiscalItemQtdTributavel;
         obj94.gxTpr_Notafiscalitemvalorfrete = A844NotaFiscalItemValorFrete;
         obj94.gxTpr_Notafiscalitemdesconto = A845NotaFiscalItemDesconto;
         obj94.gxTpr_Notafiscalitemindicadorvalortotal = A846NotaFiscalItemIndicadorValorTotal;
         obj94.gxTpr_Notafiscalitemnumpedido = A847NotaFiscalItemNumPedido;
         obj94.gxTpr_Notafiscalitemnumitem = A848NotaFiscalItemNumItem;
         obj94.gxTpr_Notafiscalitemvendido = A851NotaFiscalItemVendido;
         obj94.gxTpr_Notafiscalitemid = A830NotaFiscalItemId;
         obj94.gxTpr_Notafiscalitemid_Z = Z830NotaFiscalItemId;
         obj94.gxTpr_Propostaid_Z = Z323PropostaId;
         obj94.gxTpr_Notafiscalid_Z = Z794NotaFiscalId;
         obj94.gxTpr_Notafiscalitemcodigo_Z = Z831NotaFiscalItemCodigo;
         obj94.gxTpr_Notafiscalitemcfop_Z = Z832NotaFiscalItemCFOP;
         obj94.gxTpr_Notafiscalitemdescricao_Z = Z833NotaFiscalItemDescricao;
         obj94.gxTpr_Notafiscalitemncm_Z = Z834NotaFiscalItemNCM;
         obj94.gxTpr_Notafiscalitemcodigoean_Z = Z835NotaFiscalItemCodigoEAN;
         obj94.gxTpr_Notafiscalitemunidadecomercial_Z = Z836NotaFiscalItemUnidadeComercial;
         obj94.gxTpr_Notafiscalitemquantidade_Z = Z837NotaFiscalItemQuantidade;
         obj94.gxTpr_Notafiscalitemvalorunitario_Z = Z838NotaFiscalItemValorUnitario;
         obj94.gxTpr_Notafiscalitemvalortotal_Z = Z839NotaFiscalItemValorTotal;
         obj94.gxTpr_Notafiscalitemcodbargtin_Z = Z840NotaFiscalItemCodBarGTIN;
         obj94.gxTpr_Notafiscalitemunidadetributavel_Z = Z841NotaFiscalItemUnidadeTributavel;
         obj94.gxTpr_Notafiscalitemvaloruntributavel_Z = Z842NotaFiscalItemValorUnTributavel;
         obj94.gxTpr_Notafiscalitemqtdtributavel_Z = Z843NotaFiscalItemQtdTributavel;
         obj94.gxTpr_Notafiscalitemvalorfrete_Z = Z844NotaFiscalItemValorFrete;
         obj94.gxTpr_Notafiscalitemdesconto_Z = Z845NotaFiscalItemDesconto;
         obj94.gxTpr_Notafiscalitemindicadorvalortotal_Z = Z846NotaFiscalItemIndicadorValorTotal;
         obj94.gxTpr_Notafiscalitemnumpedido_Z = Z847NotaFiscalItemNumPedido;
         obj94.gxTpr_Notafiscalitemnumitem_Z = Z848NotaFiscalItemNumItem;
         obj94.gxTpr_Notafiscalitemvendido_Z = Z851NotaFiscalItemVendido;
         obj94.gxTpr_Propostaid_N = (short)(Convert.ToInt16(n323PropostaId));
         obj94.gxTpr_Notafiscalid_N = (short)(Convert.ToInt16(n794NotaFiscalId));
         obj94.gxTpr_Notafiscalitemcodigo_N = (short)(Convert.ToInt16(n831NotaFiscalItemCodigo));
         obj94.gxTpr_Notafiscalitemcfop_N = (short)(Convert.ToInt16(n832NotaFiscalItemCFOP));
         obj94.gxTpr_Notafiscalitemdescricao_N = (short)(Convert.ToInt16(n833NotaFiscalItemDescricao));
         obj94.gxTpr_Notafiscalitemncm_N = (short)(Convert.ToInt16(n834NotaFiscalItemNCM));
         obj94.gxTpr_Notafiscalitemcodigoean_N = (short)(Convert.ToInt16(n835NotaFiscalItemCodigoEAN));
         obj94.gxTpr_Notafiscalitemunidadecomercial_N = (short)(Convert.ToInt16(n836NotaFiscalItemUnidadeComercial));
         obj94.gxTpr_Notafiscalitemquantidade_N = (short)(Convert.ToInt16(n837NotaFiscalItemQuantidade));
         obj94.gxTpr_Notafiscalitemvalorunitario_N = (short)(Convert.ToInt16(n838NotaFiscalItemValorUnitario));
         obj94.gxTpr_Notafiscalitemvalortotal_N = (short)(Convert.ToInt16(n839NotaFiscalItemValorTotal));
         obj94.gxTpr_Notafiscalitemcodbargtin_N = (short)(Convert.ToInt16(n840NotaFiscalItemCodBarGTIN));
         obj94.gxTpr_Notafiscalitemunidadetributavel_N = (short)(Convert.ToInt16(n841NotaFiscalItemUnidadeTributavel));
         obj94.gxTpr_Notafiscalitemvaloruntributavel_N = (short)(Convert.ToInt16(n842NotaFiscalItemValorUnTributavel));
         obj94.gxTpr_Notafiscalitemqtdtributavel_N = (short)(Convert.ToInt16(n843NotaFiscalItemQtdTributavel));
         obj94.gxTpr_Notafiscalitemvalorfrete_N = (short)(Convert.ToInt16(n844NotaFiscalItemValorFrete));
         obj94.gxTpr_Notafiscalitemdesconto_N = (short)(Convert.ToInt16(n845NotaFiscalItemDesconto));
         obj94.gxTpr_Notafiscalitemindicadorvalortotal_N = (short)(Convert.ToInt16(n846NotaFiscalItemIndicadorValorTotal));
         obj94.gxTpr_Notafiscalitemnumpedido_N = (short)(Convert.ToInt16(n847NotaFiscalItemNumPedido));
         obj94.gxTpr_Notafiscalitemnumitem_N = (short)(Convert.ToInt16(n848NotaFiscalItemNumItem));
         obj94.gxTpr_Notafiscalitemvendido_N = (short)(Convert.ToInt16(n851NotaFiscalItemVendido));
         obj94.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow94( SdtNotaFiscalItem obj94 )
      {
         obj94.gxTpr_Notafiscalitemid = A830NotaFiscalItemId;
         return  ;
      }

      public void RowToVars94( SdtNotaFiscalItem obj94 ,
                               int forceLoad )
      {
         Gx_mode = obj94.gxTpr_Mode;
         A323PropostaId = obj94.gxTpr_Propostaid;
         n323PropostaId = false;
         A794NotaFiscalId = obj94.gxTpr_Notafiscalid;
         n794NotaFiscalId = false;
         A831NotaFiscalItemCodigo = obj94.gxTpr_Notafiscalitemcodigo;
         n831NotaFiscalItemCodigo = false;
         A832NotaFiscalItemCFOP = obj94.gxTpr_Notafiscalitemcfop;
         n832NotaFiscalItemCFOP = false;
         A833NotaFiscalItemDescricao = obj94.gxTpr_Notafiscalitemdescricao;
         n833NotaFiscalItemDescricao = false;
         A834NotaFiscalItemNCM = obj94.gxTpr_Notafiscalitemncm;
         n834NotaFiscalItemNCM = false;
         A835NotaFiscalItemCodigoEAN = obj94.gxTpr_Notafiscalitemcodigoean;
         n835NotaFiscalItemCodigoEAN = false;
         A836NotaFiscalItemUnidadeComercial = obj94.gxTpr_Notafiscalitemunidadecomercial;
         n836NotaFiscalItemUnidadeComercial = false;
         A837NotaFiscalItemQuantidade = obj94.gxTpr_Notafiscalitemquantidade;
         n837NotaFiscalItemQuantidade = false;
         A838NotaFiscalItemValorUnitario = obj94.gxTpr_Notafiscalitemvalorunitario;
         n838NotaFiscalItemValorUnitario = false;
         A839NotaFiscalItemValorTotal = obj94.gxTpr_Notafiscalitemvalortotal;
         n839NotaFiscalItemValorTotal = false;
         A840NotaFiscalItemCodBarGTIN = obj94.gxTpr_Notafiscalitemcodbargtin;
         n840NotaFiscalItemCodBarGTIN = false;
         A841NotaFiscalItemUnidadeTributavel = obj94.gxTpr_Notafiscalitemunidadetributavel;
         n841NotaFiscalItemUnidadeTributavel = false;
         A842NotaFiscalItemValorUnTributavel = obj94.gxTpr_Notafiscalitemvaloruntributavel;
         n842NotaFiscalItemValorUnTributavel = false;
         A843NotaFiscalItemQtdTributavel = obj94.gxTpr_Notafiscalitemqtdtributavel;
         n843NotaFiscalItemQtdTributavel = false;
         A844NotaFiscalItemValorFrete = obj94.gxTpr_Notafiscalitemvalorfrete;
         n844NotaFiscalItemValorFrete = false;
         A845NotaFiscalItemDesconto = obj94.gxTpr_Notafiscalitemdesconto;
         n845NotaFiscalItemDesconto = false;
         A846NotaFiscalItemIndicadorValorTotal = obj94.gxTpr_Notafiscalitemindicadorvalortotal;
         n846NotaFiscalItemIndicadorValorTotal = false;
         A847NotaFiscalItemNumPedido = obj94.gxTpr_Notafiscalitemnumpedido;
         n847NotaFiscalItemNumPedido = false;
         A848NotaFiscalItemNumItem = obj94.gxTpr_Notafiscalitemnumitem;
         n848NotaFiscalItemNumItem = false;
         A851NotaFiscalItemVendido = obj94.gxTpr_Notafiscalitemvendido;
         n851NotaFiscalItemVendido = false;
         A830NotaFiscalItemId = obj94.gxTpr_Notafiscalitemid;
         Z830NotaFiscalItemId = obj94.gxTpr_Notafiscalitemid_Z;
         Z323PropostaId = obj94.gxTpr_Propostaid_Z;
         Z794NotaFiscalId = obj94.gxTpr_Notafiscalid_Z;
         Z831NotaFiscalItemCodigo = obj94.gxTpr_Notafiscalitemcodigo_Z;
         Z832NotaFiscalItemCFOP = obj94.gxTpr_Notafiscalitemcfop_Z;
         Z833NotaFiscalItemDescricao = obj94.gxTpr_Notafiscalitemdescricao_Z;
         Z834NotaFiscalItemNCM = obj94.gxTpr_Notafiscalitemncm_Z;
         Z835NotaFiscalItemCodigoEAN = obj94.gxTpr_Notafiscalitemcodigoean_Z;
         Z836NotaFiscalItemUnidadeComercial = obj94.gxTpr_Notafiscalitemunidadecomercial_Z;
         Z837NotaFiscalItemQuantidade = obj94.gxTpr_Notafiscalitemquantidade_Z;
         Z838NotaFiscalItemValorUnitario = obj94.gxTpr_Notafiscalitemvalorunitario_Z;
         Z839NotaFiscalItemValorTotal = obj94.gxTpr_Notafiscalitemvalortotal_Z;
         Z840NotaFiscalItemCodBarGTIN = obj94.gxTpr_Notafiscalitemcodbargtin_Z;
         Z841NotaFiscalItemUnidadeTributavel = obj94.gxTpr_Notafiscalitemunidadetributavel_Z;
         Z842NotaFiscalItemValorUnTributavel = obj94.gxTpr_Notafiscalitemvaloruntributavel_Z;
         Z843NotaFiscalItemQtdTributavel = obj94.gxTpr_Notafiscalitemqtdtributavel_Z;
         Z844NotaFiscalItemValorFrete = obj94.gxTpr_Notafiscalitemvalorfrete_Z;
         Z845NotaFiscalItemDesconto = obj94.gxTpr_Notafiscalitemdesconto_Z;
         Z846NotaFiscalItemIndicadorValorTotal = obj94.gxTpr_Notafiscalitemindicadorvalortotal_Z;
         Z847NotaFiscalItemNumPedido = obj94.gxTpr_Notafiscalitemnumpedido_Z;
         Z848NotaFiscalItemNumItem = obj94.gxTpr_Notafiscalitemnumitem_Z;
         Z851NotaFiscalItemVendido = obj94.gxTpr_Notafiscalitemvendido_Z;
         n323PropostaId = (bool)(Convert.ToBoolean(obj94.gxTpr_Propostaid_N));
         n794NotaFiscalId = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalid_N));
         n831NotaFiscalItemCodigo = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemcodigo_N));
         n832NotaFiscalItemCFOP = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemcfop_N));
         n833NotaFiscalItemDescricao = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemdescricao_N));
         n834NotaFiscalItemNCM = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemncm_N));
         n835NotaFiscalItemCodigoEAN = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemcodigoean_N));
         n836NotaFiscalItemUnidadeComercial = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemunidadecomercial_N));
         n837NotaFiscalItemQuantidade = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemquantidade_N));
         n838NotaFiscalItemValorUnitario = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemvalorunitario_N));
         n839NotaFiscalItemValorTotal = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemvalortotal_N));
         n840NotaFiscalItemCodBarGTIN = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemcodbargtin_N));
         n841NotaFiscalItemUnidadeTributavel = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemunidadetributavel_N));
         n842NotaFiscalItemValorUnTributavel = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemvaloruntributavel_N));
         n843NotaFiscalItemQtdTributavel = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemqtdtributavel_N));
         n844NotaFiscalItemValorFrete = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemvalorfrete_N));
         n845NotaFiscalItemDesconto = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemdesconto_N));
         n846NotaFiscalItemIndicadorValorTotal = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemindicadorvalortotal_N));
         n847NotaFiscalItemNumPedido = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemnumpedido_N));
         n848NotaFiscalItemNumItem = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemnumitem_N));
         n851NotaFiscalItemVendido = (bool)(Convert.ToBoolean(obj94.gxTpr_Notafiscalitemvendido_N));
         Gx_mode = obj94.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A830NotaFiscalItemId = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey2O94( ) ;
         ScanKeyStart2O94( ) ;
         if ( RcdFound94 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z830NotaFiscalItemId = A830NotaFiscalItemId;
         }
         ZM2O94( -9) ;
         OnLoadActions2O94( ) ;
         AddRow2O94( ) ;
         ScanKeyEnd2O94( ) ;
         if ( RcdFound94 == 0 )
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
         RowToVars94( bcNotaFiscalItem, 0) ;
         ScanKeyStart2O94( ) ;
         if ( RcdFound94 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z830NotaFiscalItemId = A830NotaFiscalItemId;
         }
         ZM2O94( -9) ;
         OnLoadActions2O94( ) ;
         AddRow2O94( ) ;
         ScanKeyEnd2O94( ) ;
         if ( RcdFound94 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         GetKey2O94( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert2O94( ) ;
         }
         else
         {
            if ( RcdFound94 == 1 )
            {
               if ( A830NotaFiscalItemId != Z830NotaFiscalItemId )
               {
                  A830NotaFiscalItemId = Z830NotaFiscalItemId;
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
                  Update2O94( ) ;
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
                  if ( A830NotaFiscalItemId != Z830NotaFiscalItemId )
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
                        Insert2O94( ) ;
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
                        Insert2O94( ) ;
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
         RowToVars94( bcNotaFiscalItem, 1) ;
         SaveImpl( ) ;
         VarsToRow94( bcNotaFiscalItem) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars94( bcNotaFiscalItem, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2O94( ) ;
         AfterTrn( ) ;
         VarsToRow94( bcNotaFiscalItem) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow94( bcNotaFiscalItem) ;
         }
         else
         {
            SdtNotaFiscalItem auxBC = new SdtNotaFiscalItem(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A830NotaFiscalItemId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcNotaFiscalItem);
               auxBC.Save();
               bcNotaFiscalItem.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars94( bcNotaFiscalItem, 1) ;
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
         RowToVars94( bcNotaFiscalItem, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert2O94( ) ;
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
               VarsToRow94( bcNotaFiscalItem) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow94( bcNotaFiscalItem) ;
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
         RowToVars94( bcNotaFiscalItem, 0) ;
         GetKey2O94( ) ;
         if ( RcdFound94 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A830NotaFiscalItemId != Z830NotaFiscalItemId )
            {
               A830NotaFiscalItemId = Z830NotaFiscalItemId;
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
            if ( A830NotaFiscalItemId != Z830NotaFiscalItemId )
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
         context.RollbackDataStores("notafiscalitem_bc",pr_default);
         VarsToRow94( bcNotaFiscalItem) ;
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
         Gx_mode = bcNotaFiscalItem.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcNotaFiscalItem.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcNotaFiscalItem )
         {
            bcNotaFiscalItem = (SdtNotaFiscalItem)(sdt);
            if ( StringUtil.StrCmp(bcNotaFiscalItem.gxTpr_Mode, "") == 0 )
            {
               bcNotaFiscalItem.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow94( bcNotaFiscalItem) ;
            }
            else
            {
               RowToVars94( bcNotaFiscalItem, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcNotaFiscalItem.gxTpr_Mode, "") == 0 )
            {
               bcNotaFiscalItem.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars94( bcNotaFiscalItem, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         return  ;
      }

      public SdtNotaFiscalItem NotaFiscalItem_BC
      {
         get {
            return bcNotaFiscalItem ;
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
         Z830NotaFiscalItemId = Guid.Empty;
         A830NotaFiscalItemId = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV22Pgmname = "";
         AV13TrnContextAtt = new WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute(context);
         AV12Insert_NotaFiscalId = Guid.Empty;
         Z831NotaFiscalItemCodigo = "";
         A831NotaFiscalItemCodigo = "";
         Z833NotaFiscalItemDescricao = "";
         A833NotaFiscalItemDescricao = "";
         Z834NotaFiscalItemNCM = "";
         A834NotaFiscalItemNCM = "";
         Z835NotaFiscalItemCodigoEAN = "";
         A835NotaFiscalItemCodigoEAN = "";
         Z836NotaFiscalItemUnidadeComercial = "";
         A836NotaFiscalItemUnidadeComercial = "";
         Z840NotaFiscalItemCodBarGTIN = "";
         A840NotaFiscalItemCodBarGTIN = "";
         Z841NotaFiscalItemUnidadeTributavel = "";
         A841NotaFiscalItemUnidadeTributavel = "";
         Z846NotaFiscalItemIndicadorValorTotal = "";
         A846NotaFiscalItemIndicadorValorTotal = "";
         Z847NotaFiscalItemNumPedido = "";
         A847NotaFiscalItemNumPedido = "";
         Z848NotaFiscalItemNumItem = "";
         A848NotaFiscalItemNumItem = "";
         Z851NotaFiscalItemVendido = "";
         A851NotaFiscalItemVendido = "";
         Z794NotaFiscalId = Guid.Empty;
         A794NotaFiscalId = Guid.Empty;
         BC002O6_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         BC002O6_A831NotaFiscalItemCodigo = new string[] {""} ;
         BC002O6_n831NotaFiscalItemCodigo = new bool[] {false} ;
         BC002O6_A832NotaFiscalItemCFOP = new short[1] ;
         BC002O6_n832NotaFiscalItemCFOP = new bool[] {false} ;
         BC002O6_A833NotaFiscalItemDescricao = new string[] {""} ;
         BC002O6_n833NotaFiscalItemDescricao = new bool[] {false} ;
         BC002O6_A834NotaFiscalItemNCM = new string[] {""} ;
         BC002O6_n834NotaFiscalItemNCM = new bool[] {false} ;
         BC002O6_A835NotaFiscalItemCodigoEAN = new string[] {""} ;
         BC002O6_n835NotaFiscalItemCodigoEAN = new bool[] {false} ;
         BC002O6_A836NotaFiscalItemUnidadeComercial = new string[] {""} ;
         BC002O6_n836NotaFiscalItemUnidadeComercial = new bool[] {false} ;
         BC002O6_A837NotaFiscalItemQuantidade = new decimal[1] ;
         BC002O6_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         BC002O6_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         BC002O6_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         BC002O6_A839NotaFiscalItemValorTotal = new decimal[1] ;
         BC002O6_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         BC002O6_A840NotaFiscalItemCodBarGTIN = new string[] {""} ;
         BC002O6_n840NotaFiscalItemCodBarGTIN = new bool[] {false} ;
         BC002O6_A841NotaFiscalItemUnidadeTributavel = new string[] {""} ;
         BC002O6_n841NotaFiscalItemUnidadeTributavel = new bool[] {false} ;
         BC002O6_A842NotaFiscalItemValorUnTributavel = new decimal[1] ;
         BC002O6_n842NotaFiscalItemValorUnTributavel = new bool[] {false} ;
         BC002O6_A843NotaFiscalItemQtdTributavel = new decimal[1] ;
         BC002O6_n843NotaFiscalItemQtdTributavel = new bool[] {false} ;
         BC002O6_A844NotaFiscalItemValorFrete = new decimal[1] ;
         BC002O6_n844NotaFiscalItemValorFrete = new bool[] {false} ;
         BC002O6_A845NotaFiscalItemDesconto = new decimal[1] ;
         BC002O6_n845NotaFiscalItemDesconto = new bool[] {false} ;
         BC002O6_A846NotaFiscalItemIndicadorValorTotal = new string[] {""} ;
         BC002O6_n846NotaFiscalItemIndicadorValorTotal = new bool[] {false} ;
         BC002O6_A847NotaFiscalItemNumPedido = new string[] {""} ;
         BC002O6_n847NotaFiscalItemNumPedido = new bool[] {false} ;
         BC002O6_A848NotaFiscalItemNumItem = new string[] {""} ;
         BC002O6_n848NotaFiscalItemNumItem = new bool[] {false} ;
         BC002O6_A851NotaFiscalItemVendido = new string[] {""} ;
         BC002O6_n851NotaFiscalItemVendido = new bool[] {false} ;
         BC002O6_A323PropostaId = new int[1] ;
         BC002O6_n323PropostaId = new bool[] {false} ;
         BC002O6_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002O6_n794NotaFiscalId = new bool[] {false} ;
         BC002O4_A323PropostaId = new int[1] ;
         BC002O4_n323PropostaId = new bool[] {false} ;
         BC002O5_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002O5_n794NotaFiscalId = new bool[] {false} ;
         BC002O7_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         BC002O3_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         BC002O3_A831NotaFiscalItemCodigo = new string[] {""} ;
         BC002O3_n831NotaFiscalItemCodigo = new bool[] {false} ;
         BC002O3_A832NotaFiscalItemCFOP = new short[1] ;
         BC002O3_n832NotaFiscalItemCFOP = new bool[] {false} ;
         BC002O3_A833NotaFiscalItemDescricao = new string[] {""} ;
         BC002O3_n833NotaFiscalItemDescricao = new bool[] {false} ;
         BC002O3_A834NotaFiscalItemNCM = new string[] {""} ;
         BC002O3_n834NotaFiscalItemNCM = new bool[] {false} ;
         BC002O3_A835NotaFiscalItemCodigoEAN = new string[] {""} ;
         BC002O3_n835NotaFiscalItemCodigoEAN = new bool[] {false} ;
         BC002O3_A836NotaFiscalItemUnidadeComercial = new string[] {""} ;
         BC002O3_n836NotaFiscalItemUnidadeComercial = new bool[] {false} ;
         BC002O3_A837NotaFiscalItemQuantidade = new decimal[1] ;
         BC002O3_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         BC002O3_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         BC002O3_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         BC002O3_A839NotaFiscalItemValorTotal = new decimal[1] ;
         BC002O3_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         BC002O3_A840NotaFiscalItemCodBarGTIN = new string[] {""} ;
         BC002O3_n840NotaFiscalItemCodBarGTIN = new bool[] {false} ;
         BC002O3_A841NotaFiscalItemUnidadeTributavel = new string[] {""} ;
         BC002O3_n841NotaFiscalItemUnidadeTributavel = new bool[] {false} ;
         BC002O3_A842NotaFiscalItemValorUnTributavel = new decimal[1] ;
         BC002O3_n842NotaFiscalItemValorUnTributavel = new bool[] {false} ;
         BC002O3_A843NotaFiscalItemQtdTributavel = new decimal[1] ;
         BC002O3_n843NotaFiscalItemQtdTributavel = new bool[] {false} ;
         BC002O3_A844NotaFiscalItemValorFrete = new decimal[1] ;
         BC002O3_n844NotaFiscalItemValorFrete = new bool[] {false} ;
         BC002O3_A845NotaFiscalItemDesconto = new decimal[1] ;
         BC002O3_n845NotaFiscalItemDesconto = new bool[] {false} ;
         BC002O3_A846NotaFiscalItemIndicadorValorTotal = new string[] {""} ;
         BC002O3_n846NotaFiscalItemIndicadorValorTotal = new bool[] {false} ;
         BC002O3_A847NotaFiscalItemNumPedido = new string[] {""} ;
         BC002O3_n847NotaFiscalItemNumPedido = new bool[] {false} ;
         BC002O3_A848NotaFiscalItemNumItem = new string[] {""} ;
         BC002O3_n848NotaFiscalItemNumItem = new bool[] {false} ;
         BC002O3_A851NotaFiscalItemVendido = new string[] {""} ;
         BC002O3_n851NotaFiscalItemVendido = new bool[] {false} ;
         BC002O3_A323PropostaId = new int[1] ;
         BC002O3_n323PropostaId = new bool[] {false} ;
         BC002O3_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002O3_n794NotaFiscalId = new bool[] {false} ;
         sMode94 = "";
         BC002O2_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         BC002O2_A831NotaFiscalItemCodigo = new string[] {""} ;
         BC002O2_n831NotaFiscalItemCodigo = new bool[] {false} ;
         BC002O2_A832NotaFiscalItemCFOP = new short[1] ;
         BC002O2_n832NotaFiscalItemCFOP = new bool[] {false} ;
         BC002O2_A833NotaFiscalItemDescricao = new string[] {""} ;
         BC002O2_n833NotaFiscalItemDescricao = new bool[] {false} ;
         BC002O2_A834NotaFiscalItemNCM = new string[] {""} ;
         BC002O2_n834NotaFiscalItemNCM = new bool[] {false} ;
         BC002O2_A835NotaFiscalItemCodigoEAN = new string[] {""} ;
         BC002O2_n835NotaFiscalItemCodigoEAN = new bool[] {false} ;
         BC002O2_A836NotaFiscalItemUnidadeComercial = new string[] {""} ;
         BC002O2_n836NotaFiscalItemUnidadeComercial = new bool[] {false} ;
         BC002O2_A837NotaFiscalItemQuantidade = new decimal[1] ;
         BC002O2_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         BC002O2_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         BC002O2_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         BC002O2_A839NotaFiscalItemValorTotal = new decimal[1] ;
         BC002O2_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         BC002O2_A840NotaFiscalItemCodBarGTIN = new string[] {""} ;
         BC002O2_n840NotaFiscalItemCodBarGTIN = new bool[] {false} ;
         BC002O2_A841NotaFiscalItemUnidadeTributavel = new string[] {""} ;
         BC002O2_n841NotaFiscalItemUnidadeTributavel = new bool[] {false} ;
         BC002O2_A842NotaFiscalItemValorUnTributavel = new decimal[1] ;
         BC002O2_n842NotaFiscalItemValorUnTributavel = new bool[] {false} ;
         BC002O2_A843NotaFiscalItemQtdTributavel = new decimal[1] ;
         BC002O2_n843NotaFiscalItemQtdTributavel = new bool[] {false} ;
         BC002O2_A844NotaFiscalItemValorFrete = new decimal[1] ;
         BC002O2_n844NotaFiscalItemValorFrete = new bool[] {false} ;
         BC002O2_A845NotaFiscalItemDesconto = new decimal[1] ;
         BC002O2_n845NotaFiscalItemDesconto = new bool[] {false} ;
         BC002O2_A846NotaFiscalItemIndicadorValorTotal = new string[] {""} ;
         BC002O2_n846NotaFiscalItemIndicadorValorTotal = new bool[] {false} ;
         BC002O2_A847NotaFiscalItemNumPedido = new string[] {""} ;
         BC002O2_n847NotaFiscalItemNumPedido = new bool[] {false} ;
         BC002O2_A848NotaFiscalItemNumItem = new string[] {""} ;
         BC002O2_n848NotaFiscalItemNumItem = new bool[] {false} ;
         BC002O2_A851NotaFiscalItemVendido = new string[] {""} ;
         BC002O2_n851NotaFiscalItemVendido = new bool[] {false} ;
         BC002O2_A323PropostaId = new int[1] ;
         BC002O2_n323PropostaId = new bool[] {false} ;
         BC002O2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002O2_n794NotaFiscalId = new bool[] {false} ;
         BC002O11_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         BC002O11_A831NotaFiscalItemCodigo = new string[] {""} ;
         BC002O11_n831NotaFiscalItemCodigo = new bool[] {false} ;
         BC002O11_A832NotaFiscalItemCFOP = new short[1] ;
         BC002O11_n832NotaFiscalItemCFOP = new bool[] {false} ;
         BC002O11_A833NotaFiscalItemDescricao = new string[] {""} ;
         BC002O11_n833NotaFiscalItemDescricao = new bool[] {false} ;
         BC002O11_A834NotaFiscalItemNCM = new string[] {""} ;
         BC002O11_n834NotaFiscalItemNCM = new bool[] {false} ;
         BC002O11_A835NotaFiscalItemCodigoEAN = new string[] {""} ;
         BC002O11_n835NotaFiscalItemCodigoEAN = new bool[] {false} ;
         BC002O11_A836NotaFiscalItemUnidadeComercial = new string[] {""} ;
         BC002O11_n836NotaFiscalItemUnidadeComercial = new bool[] {false} ;
         BC002O11_A837NotaFiscalItemQuantidade = new decimal[1] ;
         BC002O11_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         BC002O11_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         BC002O11_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         BC002O11_A839NotaFiscalItemValorTotal = new decimal[1] ;
         BC002O11_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         BC002O11_A840NotaFiscalItemCodBarGTIN = new string[] {""} ;
         BC002O11_n840NotaFiscalItemCodBarGTIN = new bool[] {false} ;
         BC002O11_A841NotaFiscalItemUnidadeTributavel = new string[] {""} ;
         BC002O11_n841NotaFiscalItemUnidadeTributavel = new bool[] {false} ;
         BC002O11_A842NotaFiscalItemValorUnTributavel = new decimal[1] ;
         BC002O11_n842NotaFiscalItemValorUnTributavel = new bool[] {false} ;
         BC002O11_A843NotaFiscalItemQtdTributavel = new decimal[1] ;
         BC002O11_n843NotaFiscalItemQtdTributavel = new bool[] {false} ;
         BC002O11_A844NotaFiscalItemValorFrete = new decimal[1] ;
         BC002O11_n844NotaFiscalItemValorFrete = new bool[] {false} ;
         BC002O11_A845NotaFiscalItemDesconto = new decimal[1] ;
         BC002O11_n845NotaFiscalItemDesconto = new bool[] {false} ;
         BC002O11_A846NotaFiscalItemIndicadorValorTotal = new string[] {""} ;
         BC002O11_n846NotaFiscalItemIndicadorValorTotal = new bool[] {false} ;
         BC002O11_A847NotaFiscalItemNumPedido = new string[] {""} ;
         BC002O11_n847NotaFiscalItemNumPedido = new bool[] {false} ;
         BC002O11_A848NotaFiscalItemNumItem = new string[] {""} ;
         BC002O11_n848NotaFiscalItemNumItem = new bool[] {false} ;
         BC002O11_A851NotaFiscalItemVendido = new string[] {""} ;
         BC002O11_n851NotaFiscalItemVendido = new bool[] {false} ;
         BC002O11_A323PropostaId = new int[1] ;
         BC002O11_n323PropostaId = new bool[] {false} ;
         BC002O11_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         BC002O11_n794NotaFiscalId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscalitem_bc__default(),
            new Object[][] {
                new Object[] {
               BC002O2_A830NotaFiscalItemId, BC002O2_A831NotaFiscalItemCodigo, BC002O2_n831NotaFiscalItemCodigo, BC002O2_A832NotaFiscalItemCFOP, BC002O2_n832NotaFiscalItemCFOP, BC002O2_A833NotaFiscalItemDescricao, BC002O2_n833NotaFiscalItemDescricao, BC002O2_A834NotaFiscalItemNCM, BC002O2_n834NotaFiscalItemNCM, BC002O2_A835NotaFiscalItemCodigoEAN,
               BC002O2_n835NotaFiscalItemCodigoEAN, BC002O2_A836NotaFiscalItemUnidadeComercial, BC002O2_n836NotaFiscalItemUnidadeComercial, BC002O2_A837NotaFiscalItemQuantidade, BC002O2_n837NotaFiscalItemQuantidade, BC002O2_A838NotaFiscalItemValorUnitario, BC002O2_n838NotaFiscalItemValorUnitario, BC002O2_A839NotaFiscalItemValorTotal, BC002O2_n839NotaFiscalItemValorTotal, BC002O2_A840NotaFiscalItemCodBarGTIN,
               BC002O2_n840NotaFiscalItemCodBarGTIN, BC002O2_A841NotaFiscalItemUnidadeTributavel, BC002O2_n841NotaFiscalItemUnidadeTributavel, BC002O2_A842NotaFiscalItemValorUnTributavel, BC002O2_n842NotaFiscalItemValorUnTributavel, BC002O2_A843NotaFiscalItemQtdTributavel, BC002O2_n843NotaFiscalItemQtdTributavel, BC002O2_A844NotaFiscalItemValorFrete, BC002O2_n844NotaFiscalItemValorFrete, BC002O2_A845NotaFiscalItemDesconto,
               BC002O2_n845NotaFiscalItemDesconto, BC002O2_A846NotaFiscalItemIndicadorValorTotal, BC002O2_n846NotaFiscalItemIndicadorValorTotal, BC002O2_A847NotaFiscalItemNumPedido, BC002O2_n847NotaFiscalItemNumPedido, BC002O2_A848NotaFiscalItemNumItem, BC002O2_n848NotaFiscalItemNumItem, BC002O2_A851NotaFiscalItemVendido, BC002O2_n851NotaFiscalItemVendido, BC002O2_A323PropostaId,
               BC002O2_n323PropostaId, BC002O2_A794NotaFiscalId, BC002O2_n794NotaFiscalId
               }
               , new Object[] {
               BC002O3_A830NotaFiscalItemId, BC002O3_A831NotaFiscalItemCodigo, BC002O3_n831NotaFiscalItemCodigo, BC002O3_A832NotaFiscalItemCFOP, BC002O3_n832NotaFiscalItemCFOP, BC002O3_A833NotaFiscalItemDescricao, BC002O3_n833NotaFiscalItemDescricao, BC002O3_A834NotaFiscalItemNCM, BC002O3_n834NotaFiscalItemNCM, BC002O3_A835NotaFiscalItemCodigoEAN,
               BC002O3_n835NotaFiscalItemCodigoEAN, BC002O3_A836NotaFiscalItemUnidadeComercial, BC002O3_n836NotaFiscalItemUnidadeComercial, BC002O3_A837NotaFiscalItemQuantidade, BC002O3_n837NotaFiscalItemQuantidade, BC002O3_A838NotaFiscalItemValorUnitario, BC002O3_n838NotaFiscalItemValorUnitario, BC002O3_A839NotaFiscalItemValorTotal, BC002O3_n839NotaFiscalItemValorTotal, BC002O3_A840NotaFiscalItemCodBarGTIN,
               BC002O3_n840NotaFiscalItemCodBarGTIN, BC002O3_A841NotaFiscalItemUnidadeTributavel, BC002O3_n841NotaFiscalItemUnidadeTributavel, BC002O3_A842NotaFiscalItemValorUnTributavel, BC002O3_n842NotaFiscalItemValorUnTributavel, BC002O3_A843NotaFiscalItemQtdTributavel, BC002O3_n843NotaFiscalItemQtdTributavel, BC002O3_A844NotaFiscalItemValorFrete, BC002O3_n844NotaFiscalItemValorFrete, BC002O3_A845NotaFiscalItemDesconto,
               BC002O3_n845NotaFiscalItemDesconto, BC002O3_A846NotaFiscalItemIndicadorValorTotal, BC002O3_n846NotaFiscalItemIndicadorValorTotal, BC002O3_A847NotaFiscalItemNumPedido, BC002O3_n847NotaFiscalItemNumPedido, BC002O3_A848NotaFiscalItemNumItem, BC002O3_n848NotaFiscalItemNumItem, BC002O3_A851NotaFiscalItemVendido, BC002O3_n851NotaFiscalItemVendido, BC002O3_A323PropostaId,
               BC002O3_n323PropostaId, BC002O3_A794NotaFiscalId, BC002O3_n794NotaFiscalId
               }
               , new Object[] {
               BC002O4_A323PropostaId
               }
               , new Object[] {
               BC002O5_A794NotaFiscalId
               }
               , new Object[] {
               BC002O6_A830NotaFiscalItemId, BC002O6_A831NotaFiscalItemCodigo, BC002O6_n831NotaFiscalItemCodigo, BC002O6_A832NotaFiscalItemCFOP, BC002O6_n832NotaFiscalItemCFOP, BC002O6_A833NotaFiscalItemDescricao, BC002O6_n833NotaFiscalItemDescricao, BC002O6_A834NotaFiscalItemNCM, BC002O6_n834NotaFiscalItemNCM, BC002O6_A835NotaFiscalItemCodigoEAN,
               BC002O6_n835NotaFiscalItemCodigoEAN, BC002O6_A836NotaFiscalItemUnidadeComercial, BC002O6_n836NotaFiscalItemUnidadeComercial, BC002O6_A837NotaFiscalItemQuantidade, BC002O6_n837NotaFiscalItemQuantidade, BC002O6_A838NotaFiscalItemValorUnitario, BC002O6_n838NotaFiscalItemValorUnitario, BC002O6_A839NotaFiscalItemValorTotal, BC002O6_n839NotaFiscalItemValorTotal, BC002O6_A840NotaFiscalItemCodBarGTIN,
               BC002O6_n840NotaFiscalItemCodBarGTIN, BC002O6_A841NotaFiscalItemUnidadeTributavel, BC002O6_n841NotaFiscalItemUnidadeTributavel, BC002O6_A842NotaFiscalItemValorUnTributavel, BC002O6_n842NotaFiscalItemValorUnTributavel, BC002O6_A843NotaFiscalItemQtdTributavel, BC002O6_n843NotaFiscalItemQtdTributavel, BC002O6_A844NotaFiscalItemValorFrete, BC002O6_n844NotaFiscalItemValorFrete, BC002O6_A845NotaFiscalItemDesconto,
               BC002O6_n845NotaFiscalItemDesconto, BC002O6_A846NotaFiscalItemIndicadorValorTotal, BC002O6_n846NotaFiscalItemIndicadorValorTotal, BC002O6_A847NotaFiscalItemNumPedido, BC002O6_n847NotaFiscalItemNumPedido, BC002O6_A848NotaFiscalItemNumItem, BC002O6_n848NotaFiscalItemNumItem, BC002O6_A851NotaFiscalItemVendido, BC002O6_n851NotaFiscalItemVendido, BC002O6_A323PropostaId,
               BC002O6_n323PropostaId, BC002O6_A794NotaFiscalId, BC002O6_n794NotaFiscalId
               }
               , new Object[] {
               BC002O7_A830NotaFiscalItemId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC002O11_A830NotaFiscalItemId, BC002O11_A831NotaFiscalItemCodigo, BC002O11_n831NotaFiscalItemCodigo, BC002O11_A832NotaFiscalItemCFOP, BC002O11_n832NotaFiscalItemCFOP, BC002O11_A833NotaFiscalItemDescricao, BC002O11_n833NotaFiscalItemDescricao, BC002O11_A834NotaFiscalItemNCM, BC002O11_n834NotaFiscalItemNCM, BC002O11_A835NotaFiscalItemCodigoEAN,
               BC002O11_n835NotaFiscalItemCodigoEAN, BC002O11_A836NotaFiscalItemUnidadeComercial, BC002O11_n836NotaFiscalItemUnidadeComercial, BC002O11_A837NotaFiscalItemQuantidade, BC002O11_n837NotaFiscalItemQuantidade, BC002O11_A838NotaFiscalItemValorUnitario, BC002O11_n838NotaFiscalItemValorUnitario, BC002O11_A839NotaFiscalItemValorTotal, BC002O11_n839NotaFiscalItemValorTotal, BC002O11_A840NotaFiscalItemCodBarGTIN,
               BC002O11_n840NotaFiscalItemCodBarGTIN, BC002O11_A841NotaFiscalItemUnidadeTributavel, BC002O11_n841NotaFiscalItemUnidadeTributavel, BC002O11_A842NotaFiscalItemValorUnTributavel, BC002O11_n842NotaFiscalItemValorUnTributavel, BC002O11_A843NotaFiscalItemQtdTributavel, BC002O11_n843NotaFiscalItemQtdTributavel, BC002O11_A844NotaFiscalItemValorFrete, BC002O11_n844NotaFiscalItemValorFrete, BC002O11_A845NotaFiscalItemDesconto,
               BC002O11_n845NotaFiscalItemDesconto, BC002O11_A846NotaFiscalItemIndicadorValorTotal, BC002O11_n846NotaFiscalItemIndicadorValorTotal, BC002O11_A847NotaFiscalItemNumPedido, BC002O11_n847NotaFiscalItemNumPedido, BC002O11_A848NotaFiscalItemNumItem, BC002O11_n848NotaFiscalItemNumItem, BC002O11_A851NotaFiscalItemVendido, BC002O11_n851NotaFiscalItemVendido, BC002O11_A323PropostaId,
               BC002O11_n323PropostaId, BC002O11_A794NotaFiscalId, BC002O11_n794NotaFiscalId
               }
            }
         );
         Z830NotaFiscalItemId = Guid.NewGuid( );
         A830NotaFiscalItemId = Guid.NewGuid( );
         AV22Pgmname = "NotaFiscalItem_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E122O2 ();
         standaloneNotModal( ) ;
      }

      private short AnyError ;
      private short Z832NotaFiscalItemCFOP ;
      private short A832NotaFiscalItemCFOP ;
      private short Gx_BScreen ;
      private short RcdFound94 ;
      private int trnEnded ;
      private int AV23GXV1 ;
      private int AV11Insert_PropostaId ;
      private int Z323PropostaId ;
      private int A323PropostaId ;
      private decimal Z837NotaFiscalItemQuantidade ;
      private decimal A837NotaFiscalItemQuantidade ;
      private decimal Z838NotaFiscalItemValorUnitario ;
      private decimal A838NotaFiscalItemValorUnitario ;
      private decimal Z839NotaFiscalItemValorTotal ;
      private decimal A839NotaFiscalItemValorTotal ;
      private decimal Z842NotaFiscalItemValorUnTributavel ;
      private decimal A842NotaFiscalItemValorUnTributavel ;
      private decimal Z843NotaFiscalItemQtdTributavel ;
      private decimal A843NotaFiscalItemQtdTributavel ;
      private decimal Z844NotaFiscalItemValorFrete ;
      private decimal A844NotaFiscalItemValorFrete ;
      private decimal Z845NotaFiscalItemDesconto ;
      private decimal A845NotaFiscalItemDesconto ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV22Pgmname ;
      private string sMode94 ;
      private bool returnInSub ;
      private bool n831NotaFiscalItemCodigo ;
      private bool n832NotaFiscalItemCFOP ;
      private bool n833NotaFiscalItemDescricao ;
      private bool n834NotaFiscalItemNCM ;
      private bool n835NotaFiscalItemCodigoEAN ;
      private bool n836NotaFiscalItemUnidadeComercial ;
      private bool n837NotaFiscalItemQuantidade ;
      private bool n838NotaFiscalItemValorUnitario ;
      private bool n839NotaFiscalItemValorTotal ;
      private bool n840NotaFiscalItemCodBarGTIN ;
      private bool n841NotaFiscalItemUnidadeTributavel ;
      private bool n842NotaFiscalItemValorUnTributavel ;
      private bool n843NotaFiscalItemQtdTributavel ;
      private bool n844NotaFiscalItemValorFrete ;
      private bool n845NotaFiscalItemDesconto ;
      private bool n846NotaFiscalItemIndicadorValorTotal ;
      private bool n847NotaFiscalItemNumPedido ;
      private bool n848NotaFiscalItemNumItem ;
      private bool n851NotaFiscalItemVendido ;
      private bool n323PropostaId ;
      private bool n794NotaFiscalId ;
      private bool Gx_longc ;
      private string Z831NotaFiscalItemCodigo ;
      private string A831NotaFiscalItemCodigo ;
      private string Z833NotaFiscalItemDescricao ;
      private string A833NotaFiscalItemDescricao ;
      private string Z834NotaFiscalItemNCM ;
      private string A834NotaFiscalItemNCM ;
      private string Z835NotaFiscalItemCodigoEAN ;
      private string A835NotaFiscalItemCodigoEAN ;
      private string Z836NotaFiscalItemUnidadeComercial ;
      private string A836NotaFiscalItemUnidadeComercial ;
      private string Z840NotaFiscalItemCodBarGTIN ;
      private string A840NotaFiscalItemCodBarGTIN ;
      private string Z841NotaFiscalItemUnidadeTributavel ;
      private string A841NotaFiscalItemUnidadeTributavel ;
      private string Z846NotaFiscalItemIndicadorValorTotal ;
      private string A846NotaFiscalItemIndicadorValorTotal ;
      private string Z847NotaFiscalItemNumPedido ;
      private string A847NotaFiscalItemNumPedido ;
      private string Z848NotaFiscalItemNumItem ;
      private string A848NotaFiscalItemNumItem ;
      private string Z851NotaFiscalItemVendido ;
      private string A851NotaFiscalItemVendido ;
      private Guid Z830NotaFiscalItemId ;
      private Guid A830NotaFiscalItemId ;
      private Guid AV12Insert_NotaFiscalId ;
      private Guid Z794NotaFiscalId ;
      private Guid A794NotaFiscalId ;
      private IGxSession AV10WebSession ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext AV9TrnContext ;
      private WorkWithPlus.workwithplus_commonobjects.SdtWWPTransactionContext_Attribute AV13TrnContextAtt ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC002O6_A830NotaFiscalItemId ;
      private string[] BC002O6_A831NotaFiscalItemCodigo ;
      private bool[] BC002O6_n831NotaFiscalItemCodigo ;
      private short[] BC002O6_A832NotaFiscalItemCFOP ;
      private bool[] BC002O6_n832NotaFiscalItemCFOP ;
      private string[] BC002O6_A833NotaFiscalItemDescricao ;
      private bool[] BC002O6_n833NotaFiscalItemDescricao ;
      private string[] BC002O6_A834NotaFiscalItemNCM ;
      private bool[] BC002O6_n834NotaFiscalItemNCM ;
      private string[] BC002O6_A835NotaFiscalItemCodigoEAN ;
      private bool[] BC002O6_n835NotaFiscalItemCodigoEAN ;
      private string[] BC002O6_A836NotaFiscalItemUnidadeComercial ;
      private bool[] BC002O6_n836NotaFiscalItemUnidadeComercial ;
      private decimal[] BC002O6_A837NotaFiscalItemQuantidade ;
      private bool[] BC002O6_n837NotaFiscalItemQuantidade ;
      private decimal[] BC002O6_A838NotaFiscalItemValorUnitario ;
      private bool[] BC002O6_n838NotaFiscalItemValorUnitario ;
      private decimal[] BC002O6_A839NotaFiscalItemValorTotal ;
      private bool[] BC002O6_n839NotaFiscalItemValorTotal ;
      private string[] BC002O6_A840NotaFiscalItemCodBarGTIN ;
      private bool[] BC002O6_n840NotaFiscalItemCodBarGTIN ;
      private string[] BC002O6_A841NotaFiscalItemUnidadeTributavel ;
      private bool[] BC002O6_n841NotaFiscalItemUnidadeTributavel ;
      private decimal[] BC002O6_A842NotaFiscalItemValorUnTributavel ;
      private bool[] BC002O6_n842NotaFiscalItemValorUnTributavel ;
      private decimal[] BC002O6_A843NotaFiscalItemQtdTributavel ;
      private bool[] BC002O6_n843NotaFiscalItemQtdTributavel ;
      private decimal[] BC002O6_A844NotaFiscalItemValorFrete ;
      private bool[] BC002O6_n844NotaFiscalItemValorFrete ;
      private decimal[] BC002O6_A845NotaFiscalItemDesconto ;
      private bool[] BC002O6_n845NotaFiscalItemDesconto ;
      private string[] BC002O6_A846NotaFiscalItemIndicadorValorTotal ;
      private bool[] BC002O6_n846NotaFiscalItemIndicadorValorTotal ;
      private string[] BC002O6_A847NotaFiscalItemNumPedido ;
      private bool[] BC002O6_n847NotaFiscalItemNumPedido ;
      private string[] BC002O6_A848NotaFiscalItemNumItem ;
      private bool[] BC002O6_n848NotaFiscalItemNumItem ;
      private string[] BC002O6_A851NotaFiscalItemVendido ;
      private bool[] BC002O6_n851NotaFiscalItemVendido ;
      private int[] BC002O6_A323PropostaId ;
      private bool[] BC002O6_n323PropostaId ;
      private Guid[] BC002O6_A794NotaFiscalId ;
      private bool[] BC002O6_n794NotaFiscalId ;
      private int[] BC002O4_A323PropostaId ;
      private bool[] BC002O4_n323PropostaId ;
      private Guid[] BC002O5_A794NotaFiscalId ;
      private bool[] BC002O5_n794NotaFiscalId ;
      private Guid[] BC002O7_A830NotaFiscalItemId ;
      private Guid[] BC002O3_A830NotaFiscalItemId ;
      private string[] BC002O3_A831NotaFiscalItemCodigo ;
      private bool[] BC002O3_n831NotaFiscalItemCodigo ;
      private short[] BC002O3_A832NotaFiscalItemCFOP ;
      private bool[] BC002O3_n832NotaFiscalItemCFOP ;
      private string[] BC002O3_A833NotaFiscalItemDescricao ;
      private bool[] BC002O3_n833NotaFiscalItemDescricao ;
      private string[] BC002O3_A834NotaFiscalItemNCM ;
      private bool[] BC002O3_n834NotaFiscalItemNCM ;
      private string[] BC002O3_A835NotaFiscalItemCodigoEAN ;
      private bool[] BC002O3_n835NotaFiscalItemCodigoEAN ;
      private string[] BC002O3_A836NotaFiscalItemUnidadeComercial ;
      private bool[] BC002O3_n836NotaFiscalItemUnidadeComercial ;
      private decimal[] BC002O3_A837NotaFiscalItemQuantidade ;
      private bool[] BC002O3_n837NotaFiscalItemQuantidade ;
      private decimal[] BC002O3_A838NotaFiscalItemValorUnitario ;
      private bool[] BC002O3_n838NotaFiscalItemValorUnitario ;
      private decimal[] BC002O3_A839NotaFiscalItemValorTotal ;
      private bool[] BC002O3_n839NotaFiscalItemValorTotal ;
      private string[] BC002O3_A840NotaFiscalItemCodBarGTIN ;
      private bool[] BC002O3_n840NotaFiscalItemCodBarGTIN ;
      private string[] BC002O3_A841NotaFiscalItemUnidadeTributavel ;
      private bool[] BC002O3_n841NotaFiscalItemUnidadeTributavel ;
      private decimal[] BC002O3_A842NotaFiscalItemValorUnTributavel ;
      private bool[] BC002O3_n842NotaFiscalItemValorUnTributavel ;
      private decimal[] BC002O3_A843NotaFiscalItemQtdTributavel ;
      private bool[] BC002O3_n843NotaFiscalItemQtdTributavel ;
      private decimal[] BC002O3_A844NotaFiscalItemValorFrete ;
      private bool[] BC002O3_n844NotaFiscalItemValorFrete ;
      private decimal[] BC002O3_A845NotaFiscalItemDesconto ;
      private bool[] BC002O3_n845NotaFiscalItemDesconto ;
      private string[] BC002O3_A846NotaFiscalItemIndicadorValorTotal ;
      private bool[] BC002O3_n846NotaFiscalItemIndicadorValorTotal ;
      private string[] BC002O3_A847NotaFiscalItemNumPedido ;
      private bool[] BC002O3_n847NotaFiscalItemNumPedido ;
      private string[] BC002O3_A848NotaFiscalItemNumItem ;
      private bool[] BC002O3_n848NotaFiscalItemNumItem ;
      private string[] BC002O3_A851NotaFiscalItemVendido ;
      private bool[] BC002O3_n851NotaFiscalItemVendido ;
      private int[] BC002O3_A323PropostaId ;
      private bool[] BC002O3_n323PropostaId ;
      private Guid[] BC002O3_A794NotaFiscalId ;
      private bool[] BC002O3_n794NotaFiscalId ;
      private Guid[] BC002O2_A830NotaFiscalItemId ;
      private string[] BC002O2_A831NotaFiscalItemCodigo ;
      private bool[] BC002O2_n831NotaFiscalItemCodigo ;
      private short[] BC002O2_A832NotaFiscalItemCFOP ;
      private bool[] BC002O2_n832NotaFiscalItemCFOP ;
      private string[] BC002O2_A833NotaFiscalItemDescricao ;
      private bool[] BC002O2_n833NotaFiscalItemDescricao ;
      private string[] BC002O2_A834NotaFiscalItemNCM ;
      private bool[] BC002O2_n834NotaFiscalItemNCM ;
      private string[] BC002O2_A835NotaFiscalItemCodigoEAN ;
      private bool[] BC002O2_n835NotaFiscalItemCodigoEAN ;
      private string[] BC002O2_A836NotaFiscalItemUnidadeComercial ;
      private bool[] BC002O2_n836NotaFiscalItemUnidadeComercial ;
      private decimal[] BC002O2_A837NotaFiscalItemQuantidade ;
      private bool[] BC002O2_n837NotaFiscalItemQuantidade ;
      private decimal[] BC002O2_A838NotaFiscalItemValorUnitario ;
      private bool[] BC002O2_n838NotaFiscalItemValorUnitario ;
      private decimal[] BC002O2_A839NotaFiscalItemValorTotal ;
      private bool[] BC002O2_n839NotaFiscalItemValorTotal ;
      private string[] BC002O2_A840NotaFiscalItemCodBarGTIN ;
      private bool[] BC002O2_n840NotaFiscalItemCodBarGTIN ;
      private string[] BC002O2_A841NotaFiscalItemUnidadeTributavel ;
      private bool[] BC002O2_n841NotaFiscalItemUnidadeTributavel ;
      private decimal[] BC002O2_A842NotaFiscalItemValorUnTributavel ;
      private bool[] BC002O2_n842NotaFiscalItemValorUnTributavel ;
      private decimal[] BC002O2_A843NotaFiscalItemQtdTributavel ;
      private bool[] BC002O2_n843NotaFiscalItemQtdTributavel ;
      private decimal[] BC002O2_A844NotaFiscalItemValorFrete ;
      private bool[] BC002O2_n844NotaFiscalItemValorFrete ;
      private decimal[] BC002O2_A845NotaFiscalItemDesconto ;
      private bool[] BC002O2_n845NotaFiscalItemDesconto ;
      private string[] BC002O2_A846NotaFiscalItemIndicadorValorTotal ;
      private bool[] BC002O2_n846NotaFiscalItemIndicadorValorTotal ;
      private string[] BC002O2_A847NotaFiscalItemNumPedido ;
      private bool[] BC002O2_n847NotaFiscalItemNumPedido ;
      private string[] BC002O2_A848NotaFiscalItemNumItem ;
      private bool[] BC002O2_n848NotaFiscalItemNumItem ;
      private string[] BC002O2_A851NotaFiscalItemVendido ;
      private bool[] BC002O2_n851NotaFiscalItemVendido ;
      private int[] BC002O2_A323PropostaId ;
      private bool[] BC002O2_n323PropostaId ;
      private Guid[] BC002O2_A794NotaFiscalId ;
      private bool[] BC002O2_n794NotaFiscalId ;
      private Guid[] BC002O11_A830NotaFiscalItemId ;
      private string[] BC002O11_A831NotaFiscalItemCodigo ;
      private bool[] BC002O11_n831NotaFiscalItemCodigo ;
      private short[] BC002O11_A832NotaFiscalItemCFOP ;
      private bool[] BC002O11_n832NotaFiscalItemCFOP ;
      private string[] BC002O11_A833NotaFiscalItemDescricao ;
      private bool[] BC002O11_n833NotaFiscalItemDescricao ;
      private string[] BC002O11_A834NotaFiscalItemNCM ;
      private bool[] BC002O11_n834NotaFiscalItemNCM ;
      private string[] BC002O11_A835NotaFiscalItemCodigoEAN ;
      private bool[] BC002O11_n835NotaFiscalItemCodigoEAN ;
      private string[] BC002O11_A836NotaFiscalItemUnidadeComercial ;
      private bool[] BC002O11_n836NotaFiscalItemUnidadeComercial ;
      private decimal[] BC002O11_A837NotaFiscalItemQuantidade ;
      private bool[] BC002O11_n837NotaFiscalItemQuantidade ;
      private decimal[] BC002O11_A838NotaFiscalItemValorUnitario ;
      private bool[] BC002O11_n838NotaFiscalItemValorUnitario ;
      private decimal[] BC002O11_A839NotaFiscalItemValorTotal ;
      private bool[] BC002O11_n839NotaFiscalItemValorTotal ;
      private string[] BC002O11_A840NotaFiscalItemCodBarGTIN ;
      private bool[] BC002O11_n840NotaFiscalItemCodBarGTIN ;
      private string[] BC002O11_A841NotaFiscalItemUnidadeTributavel ;
      private bool[] BC002O11_n841NotaFiscalItemUnidadeTributavel ;
      private decimal[] BC002O11_A842NotaFiscalItemValorUnTributavel ;
      private bool[] BC002O11_n842NotaFiscalItemValorUnTributavel ;
      private decimal[] BC002O11_A843NotaFiscalItemQtdTributavel ;
      private bool[] BC002O11_n843NotaFiscalItemQtdTributavel ;
      private decimal[] BC002O11_A844NotaFiscalItemValorFrete ;
      private bool[] BC002O11_n844NotaFiscalItemValorFrete ;
      private decimal[] BC002O11_A845NotaFiscalItemDesconto ;
      private bool[] BC002O11_n845NotaFiscalItemDesconto ;
      private string[] BC002O11_A846NotaFiscalItemIndicadorValorTotal ;
      private bool[] BC002O11_n846NotaFiscalItemIndicadorValorTotal ;
      private string[] BC002O11_A847NotaFiscalItemNumPedido ;
      private bool[] BC002O11_n847NotaFiscalItemNumPedido ;
      private string[] BC002O11_A848NotaFiscalItemNumItem ;
      private bool[] BC002O11_n848NotaFiscalItemNumItem ;
      private string[] BC002O11_A851NotaFiscalItemVendido ;
      private bool[] BC002O11_n851NotaFiscalItemVendido ;
      private int[] BC002O11_A323PropostaId ;
      private bool[] BC002O11_n323PropostaId ;
      private Guid[] BC002O11_A794NotaFiscalId ;
      private bool[] BC002O11_n794NotaFiscalId ;
      private SdtNotaFiscalItem bcNotaFiscalItem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class notafiscalitem_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC002O2;
          prmBC002O2 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002O3;
          prmBC002O3 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002O4;
          prmBC002O4 = new Object[] {
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true}
          };
          Object[] prmBC002O5;
          prmBC002O5 = new Object[] {
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002O6;
          prmBC002O6 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002O7;
          prmBC002O7 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002O8;
          prmBC002O8 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0) ,
          new ParDef("NotaFiscalItemCodigo",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemCFOP",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotaFiscalItemDescricao",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("NotaFiscalItemNCM",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemCodigoEAN",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemUnidadeComercial",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemQuantidade",GXType.Number,18,6){Nullable=true} ,
          new ParDef("NotaFiscalItemValorUnitario",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemValorTotal",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemCodBarGTIN",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalItemUnidadeTributavel",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemValorUnTributavel",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemQtdTributavel",GXType.Number,18,6){Nullable=true} ,
          new ParDef("NotaFiscalItemValorFrete",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemIndicadorValorTotal",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemNumPedido",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemNumItem",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemVendido",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true}
          };
          Object[] prmBC002O9;
          prmBC002O9 = new Object[] {
          new ParDef("NotaFiscalItemCodigo",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemCFOP",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("NotaFiscalItemDescricao",GXType.VarChar,255,0){Nullable=true} ,
          new ParDef("NotaFiscalItemNCM",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemCodigoEAN",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemUnidadeComercial",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemQuantidade",GXType.Number,18,6){Nullable=true} ,
          new ParDef("NotaFiscalItemValorUnitario",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemValorTotal",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemCodBarGTIN",GXType.VarChar,100,0){Nullable=true} ,
          new ParDef("NotaFiscalItemUnidadeTributavel",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemValorUnTributavel",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemQtdTributavel",GXType.Number,18,6){Nullable=true} ,
          new ParDef("NotaFiscalItemValorFrete",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemDesconto",GXType.Number,18,2){Nullable=true} ,
          new ParDef("NotaFiscalItemIndicadorValorTotal",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("NotaFiscalItemNumPedido",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemNumItem",GXType.VarChar,60,0){Nullable=true} ,
          new ParDef("NotaFiscalItemVendido",GXType.VarChar,40,0){Nullable=true} ,
          new ParDef("PropostaId",GXType.Int32,9,0){Nullable=true} ,
          new ParDef("NotaFiscalId",GXType.UniqueIdentifier,36,0){Nullable=true} ,
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002O10;
          prmBC002O10 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmBC002O11;
          prmBC002O11 = new Object[] {
          new ParDef("NotaFiscalItemId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC002O2", "SELECT NotaFiscalItemId, NotaFiscalItemCodigo, NotaFiscalItemCFOP, NotaFiscalItemDescricao, NotaFiscalItemNCM, NotaFiscalItemCodigoEAN, NotaFiscalItemUnidadeComercial, NotaFiscalItemQuantidade, NotaFiscalItemValorUnitario, NotaFiscalItemValorTotal, NotaFiscalItemCodBarGTIN, NotaFiscalItemUnidadeTributavel, NotaFiscalItemValorUnTributavel, NotaFiscalItemQtdTributavel, NotaFiscalItemValorFrete, NotaFiscalItemDesconto, NotaFiscalItemIndicadorValorTotal, NotaFiscalItemNumPedido, NotaFiscalItemNumItem, NotaFiscalItemVendido, PropostaId, NotaFiscalId FROM NotaFiscalItem WHERE NotaFiscalItemId = :NotaFiscalItemId  FOR UPDATE OF NotaFiscalItem",true, GxErrorMask.GX_NOMASK, false, this,prmBC002O2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002O3", "SELECT NotaFiscalItemId, NotaFiscalItemCodigo, NotaFiscalItemCFOP, NotaFiscalItemDescricao, NotaFiscalItemNCM, NotaFiscalItemCodigoEAN, NotaFiscalItemUnidadeComercial, NotaFiscalItemQuantidade, NotaFiscalItemValorUnitario, NotaFiscalItemValorTotal, NotaFiscalItemCodBarGTIN, NotaFiscalItemUnidadeTributavel, NotaFiscalItemValorUnTributavel, NotaFiscalItemQtdTributavel, NotaFiscalItemValorFrete, NotaFiscalItemDesconto, NotaFiscalItemIndicadorValorTotal, NotaFiscalItemNumPedido, NotaFiscalItemNumItem, NotaFiscalItemVendido, PropostaId, NotaFiscalId FROM NotaFiscalItem WHERE NotaFiscalItemId = :NotaFiscalItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002O3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002O4", "SELECT PropostaId FROM Proposta WHERE PropostaId = :PropostaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002O4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002O5", "SELECT NotaFiscalId FROM NotaFiscal WHERE NotaFiscalId = :NotaFiscalId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002O5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002O6", "SELECT TM1.NotaFiscalItemId, TM1.NotaFiscalItemCodigo, TM1.NotaFiscalItemCFOP, TM1.NotaFiscalItemDescricao, TM1.NotaFiscalItemNCM, TM1.NotaFiscalItemCodigoEAN, TM1.NotaFiscalItemUnidadeComercial, TM1.NotaFiscalItemQuantidade, TM1.NotaFiscalItemValorUnitario, TM1.NotaFiscalItemValorTotal, TM1.NotaFiscalItemCodBarGTIN, TM1.NotaFiscalItemUnidadeTributavel, TM1.NotaFiscalItemValorUnTributavel, TM1.NotaFiscalItemQtdTributavel, TM1.NotaFiscalItemValorFrete, TM1.NotaFiscalItemDesconto, TM1.NotaFiscalItemIndicadorValorTotal, TM1.NotaFiscalItemNumPedido, TM1.NotaFiscalItemNumItem, TM1.NotaFiscalItemVendido, TM1.PropostaId, TM1.NotaFiscalId FROM NotaFiscalItem TM1 WHERE TM1.NotaFiscalItemId = :NotaFiscalItemId ORDER BY TM1.NotaFiscalItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002O6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002O7", "SELECT NotaFiscalItemId FROM NotaFiscalItem WHERE NotaFiscalItemId = :NotaFiscalItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002O7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC002O8", "SAVEPOINT gxupdate;INSERT INTO NotaFiscalItem(NotaFiscalItemId, NotaFiscalItemCodigo, NotaFiscalItemCFOP, NotaFiscalItemDescricao, NotaFiscalItemNCM, NotaFiscalItemCodigoEAN, NotaFiscalItemUnidadeComercial, NotaFiscalItemQuantidade, NotaFiscalItemValorUnitario, NotaFiscalItemValorTotal, NotaFiscalItemCodBarGTIN, NotaFiscalItemUnidadeTributavel, NotaFiscalItemValorUnTributavel, NotaFiscalItemQtdTributavel, NotaFiscalItemValorFrete, NotaFiscalItemDesconto, NotaFiscalItemIndicadorValorTotal, NotaFiscalItemNumPedido, NotaFiscalItemNumItem, NotaFiscalItemVendido, PropostaId, NotaFiscalId) VALUES(:NotaFiscalItemId, :NotaFiscalItemCodigo, :NotaFiscalItemCFOP, :NotaFiscalItemDescricao, :NotaFiscalItemNCM, :NotaFiscalItemCodigoEAN, :NotaFiscalItemUnidadeComercial, :NotaFiscalItemQuantidade, :NotaFiscalItemValorUnitario, :NotaFiscalItemValorTotal, :NotaFiscalItemCodBarGTIN, :NotaFiscalItemUnidadeTributavel, :NotaFiscalItemValorUnTributavel, :NotaFiscalItemQtdTributavel, :NotaFiscalItemValorFrete, :NotaFiscalItemDesconto, :NotaFiscalItemIndicadorValorTotal, :NotaFiscalItemNumPedido, :NotaFiscalItemNumItem, :NotaFiscalItemVendido, :PropostaId, :NotaFiscalId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002O8)
             ,new CursorDef("BC002O9", "SAVEPOINT gxupdate;UPDATE NotaFiscalItem SET NotaFiscalItemCodigo=:NotaFiscalItemCodigo, NotaFiscalItemCFOP=:NotaFiscalItemCFOP, NotaFiscalItemDescricao=:NotaFiscalItemDescricao, NotaFiscalItemNCM=:NotaFiscalItemNCM, NotaFiscalItemCodigoEAN=:NotaFiscalItemCodigoEAN, NotaFiscalItemUnidadeComercial=:NotaFiscalItemUnidadeComercial, NotaFiscalItemQuantidade=:NotaFiscalItemQuantidade, NotaFiscalItemValorUnitario=:NotaFiscalItemValorUnitario, NotaFiscalItemValorTotal=:NotaFiscalItemValorTotal, NotaFiscalItemCodBarGTIN=:NotaFiscalItemCodBarGTIN, NotaFiscalItemUnidadeTributavel=:NotaFiscalItemUnidadeTributavel, NotaFiscalItemValorUnTributavel=:NotaFiscalItemValorUnTributavel, NotaFiscalItemQtdTributavel=:NotaFiscalItemQtdTributavel, NotaFiscalItemValorFrete=:NotaFiscalItemValorFrete, NotaFiscalItemDesconto=:NotaFiscalItemDesconto, NotaFiscalItemIndicadorValorTotal=:NotaFiscalItemIndicadorValorTotal, NotaFiscalItemNumPedido=:NotaFiscalItemNumPedido, NotaFiscalItemNumItem=:NotaFiscalItemNumItem, NotaFiscalItemVendido=:NotaFiscalItemVendido, PropostaId=:PropostaId, NotaFiscalId=:NotaFiscalId  WHERE NotaFiscalItemId = :NotaFiscalItemId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002O9)
             ,new CursorDef("BC002O10", "SAVEPOINT gxupdate;DELETE FROM NotaFiscalItem  WHERE NotaFiscalItemId = :NotaFiscalItemId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC002O10)
             ,new CursorDef("BC002O11", "SELECT TM1.NotaFiscalItemId, TM1.NotaFiscalItemCodigo, TM1.NotaFiscalItemCFOP, TM1.NotaFiscalItemDescricao, TM1.NotaFiscalItemNCM, TM1.NotaFiscalItemCodigoEAN, TM1.NotaFiscalItemUnidadeComercial, TM1.NotaFiscalItemQuantidade, TM1.NotaFiscalItemValorUnitario, TM1.NotaFiscalItemValorTotal, TM1.NotaFiscalItemCodBarGTIN, TM1.NotaFiscalItemUnidadeTributavel, TM1.NotaFiscalItemValorUnTributavel, TM1.NotaFiscalItemQtdTributavel, TM1.NotaFiscalItemValorFrete, TM1.NotaFiscalItemDesconto, TM1.NotaFiscalItemIndicadorValorTotal, TM1.NotaFiscalItemNumPedido, TM1.NotaFiscalItemNumItem, TM1.NotaFiscalItemVendido, TM1.PropostaId, TM1.NotaFiscalId FROM NotaFiscalItem TM1 WHERE TM1.NotaFiscalItemId = :NotaFiscalItemId ORDER BY TM1.NotaFiscalItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC002O11,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((Guid[]) buf[41])[0] = rslt.getGuid(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((Guid[]) buf[41])[0] = rslt.getGuid(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((Guid[]) buf[41])[0] = rslt.getGuid(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                return;
             case 9 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getVarchar(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((string[]) buf[9])[0] = rslt.getVarchar(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((string[]) buf[11])[0] = rslt.getVarchar(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((decimal[]) buf[13])[0] = rslt.getDecimal(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((decimal[]) buf[15])[0] = rslt.getDecimal(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((decimal[]) buf[17])[0] = rslt.getDecimal(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getVarchar(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((string[]) buf[21])[0] = rslt.getVarchar(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(14);
                ((bool[]) buf[26])[0] = rslt.wasNull(14);
                ((decimal[]) buf[27])[0] = rslt.getDecimal(15);
                ((bool[]) buf[28])[0] = rslt.wasNull(15);
                ((decimal[]) buf[29])[0] = rslt.getDecimal(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                ((string[]) buf[31])[0] = rslt.getVarchar(17);
                ((bool[]) buf[32])[0] = rslt.wasNull(17);
                ((string[]) buf[33])[0] = rslt.getVarchar(18);
                ((bool[]) buf[34])[0] = rslt.wasNull(18);
                ((string[]) buf[35])[0] = rslt.getVarchar(19);
                ((bool[]) buf[36])[0] = rslt.wasNull(19);
                ((string[]) buf[37])[0] = rslt.getVarchar(20);
                ((bool[]) buf[38])[0] = rslt.wasNull(20);
                ((int[]) buf[39])[0] = rslt.getInt(21);
                ((bool[]) buf[40])[0] = rslt.wasNull(21);
                ((Guid[]) buf[41])[0] = rslt.getGuid(22);
                ((bool[]) buf[42])[0] = rslt.wasNull(22);
                return;
       }
    }

 }

}
