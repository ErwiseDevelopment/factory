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
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class notafiscalitemlistaitenswwgetfilterdata : GXProcedure
   {
      public notafiscalitemlistaitenswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notafiscalitemlistaitenswwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV38DDOName = aP0_DDOName;
         this.AV39SearchTxtParms = aP1_SearchTxtParms;
         this.AV40SearchTxtTo = aP2_SearchTxtTo;
         this.AV41OptionsJson = "" ;
         this.AV42OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV41OptionsJson;
         aP4_OptionsDescJson=this.AV42OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV43OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV38DDOName = aP0_DDOName;
         this.AV39SearchTxtParms = aP1_SearchTxtParms;
         this.AV40SearchTxtTo = aP2_SearchTxtTo;
         this.AV41OptionsJson = "" ;
         this.AV42OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV41OptionsJson;
         aP4_OptionsDescJson=this.AV42OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV28Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25MaxItems = 10;
         AV24PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV39SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV39SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV22SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV39SearchTxtParms)) ? "" : StringUtil.Substring( AV39SearchTxtParms, 3, -1));
         AV23SkipItems = (short)(AV24PageIndex*AV25MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_NOTAFISCALNUMERO") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALNUMEROOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_NOTAFISCALITEMCODIGO") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALITEMCODIGOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_NOTAFISCALITEMDESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALITEMDESCRICAOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV41OptionsJson = AV28Options.ToJSonString(false);
         AV42OptionsDescJson = AV30OptionsDesc.ToJSonString(false);
         AV43OptionIndexesJson = AV31OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get("NotaFiscalItemListaItensWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "NotaFiscalItemListaItensWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("NotaFiscalItemListaItensWWGridState"), null, "", "");
         }
         AV45GXV1 = 1;
         while ( AV45GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV45GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO") == 0 )
            {
               AV10TFNotaFiscalNumero = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO_SEL") == 0 )
            {
               AV11TFNotaFiscalNumero_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMCODIGO") == 0 )
            {
               AV12TFNotaFiscalItemCodigo = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMCODIGO_SEL") == 0 )
            {
               AV13TFNotaFiscalItemCodigo_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMDESCRICAO") == 0 )
            {
               AV14TFNotaFiscalItemDescricao = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMDESCRICAO_SEL") == 0 )
            {
               AV15TFNotaFiscalItemDescricao_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMQUANTIDADE") == 0 )
            {
               AV16TFNotaFiscalItemQuantidade = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV17TFNotaFiscalItemQuantidade_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMVALORUNITARIO") == 0 )
            {
               AV18TFNotaFiscalItemValorUnitario = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV19TFNotaFiscalItemValorUnitario_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALITEMVALORTOTAL") == 0 )
            {
               AV20TFNotaFiscalItemValorTotal = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV21TFNotaFiscalItemValorTotal_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "PARM_&PROPOSTAID") == 0 )
            {
               AV44PropostaId = (int)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV45GXV1 = (int)(AV45GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADNOTAFISCALNUMEROOPTIONS' Routine */
         returnInSub = false;
         AV10TFNotaFiscalNumero = AV22SearchTxt;
         AV11TFNotaFiscalNumero_Sel = "";
         AV47Notafiscalitemlistaitenswwds_1_propostaid = AV44PropostaId;
         AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = AV10TFNotaFiscalNumero;
         AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel = AV11TFNotaFiscalNumero_Sel;
         AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = AV12TFNotaFiscalItemCodigo;
         AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel = AV13TFNotaFiscalItemCodigo_Sel;
         AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = AV14TFNotaFiscalItemDescricao;
         AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel = AV15TFNotaFiscalItemDescricao_Sel;
         AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade = AV16TFNotaFiscalItemQuantidade;
         AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to = AV17TFNotaFiscalItemQuantidade_To;
         AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario = AV18TFNotaFiscalItemValorUnitario;
         AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to = AV19TFNotaFiscalItemValorUnitario_To;
         AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal = AV20TFNotaFiscalItemValorTotal;
         AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to = AV21TFNotaFiscalItemValorTotal_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel ,
                                              AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ,
                                              AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel ,
                                              AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ,
                                              AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel ,
                                              AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ,
                                              AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade ,
                                              AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to ,
                                              AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario ,
                                              AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to ,
                                              AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal ,
                                              AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to ,
                                              A799NotaFiscalNumero ,
                                              A831NotaFiscalItemCodigo ,
                                              A833NotaFiscalItemDescricao ,
                                              A837NotaFiscalItemQuantidade ,
                                              A838NotaFiscalItemValorUnitario ,
                                              A839NotaFiscalItemValorTotal ,
                                              AV47Notafiscalitemlistaitenswwds_1_propostaid ,
                                              A323PropostaId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero), "%", "");
         lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = StringUtil.Concat( StringUtil.RTrim( AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo), "%", "");
         lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = StringUtil.Concat( StringUtil.RTrim( AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao), "%", "");
         /* Using cursor P00E92 */
         pr_default.execute(0, new Object[] {AV47Notafiscalitemlistaitenswwds_1_propostaid, lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero, AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo, AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao, AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade, AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to, AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario, AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to, AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal, AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKE92 = false;
            A794NotaFiscalId = P00E92_A794NotaFiscalId[0];
            n794NotaFiscalId = P00E92_n794NotaFiscalId[0];
            A323PropostaId = P00E92_A323PropostaId[0];
            n323PropostaId = P00E92_n323PropostaId[0];
            A799NotaFiscalNumero = P00E92_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00E92_n799NotaFiscalNumero[0];
            A839NotaFiscalItemValorTotal = P00E92_A839NotaFiscalItemValorTotal[0];
            n839NotaFiscalItemValorTotal = P00E92_n839NotaFiscalItemValorTotal[0];
            A838NotaFiscalItemValorUnitario = P00E92_A838NotaFiscalItemValorUnitario[0];
            n838NotaFiscalItemValorUnitario = P00E92_n838NotaFiscalItemValorUnitario[0];
            A837NotaFiscalItemQuantidade = P00E92_A837NotaFiscalItemQuantidade[0];
            n837NotaFiscalItemQuantidade = P00E92_n837NotaFiscalItemQuantidade[0];
            A833NotaFiscalItemDescricao = P00E92_A833NotaFiscalItemDescricao[0];
            n833NotaFiscalItemDescricao = P00E92_n833NotaFiscalItemDescricao[0];
            A831NotaFiscalItemCodigo = P00E92_A831NotaFiscalItemCodigo[0];
            n831NotaFiscalItemCodigo = P00E92_n831NotaFiscalItemCodigo[0];
            A830NotaFiscalItemId = P00E92_A830NotaFiscalItemId[0];
            A799NotaFiscalNumero = P00E92_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00E92_n799NotaFiscalNumero[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00E92_A323PropostaId[0] == A323PropostaId ) && ( StringUtil.StrCmp(P00E92_A799NotaFiscalNumero[0], A799NotaFiscalNumero) == 0 ) )
            {
               BRKE92 = false;
               A794NotaFiscalId = P00E92_A794NotaFiscalId[0];
               n794NotaFiscalId = P00E92_n794NotaFiscalId[0];
               A830NotaFiscalItemId = P00E92_A830NotaFiscalItemId[0];
               AV32count = (long)(AV32count+1);
               BRKE92 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV23SkipItems) )
            {
               AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A799NotaFiscalNumero)) ? "<#Empty#>" : A799NotaFiscalNumero);
               AV28Options.Add(AV27Option, 0);
               AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV28Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV23SkipItems = (short)(AV23SkipItems-1);
            }
            if ( ! BRKE92 )
            {
               BRKE92 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADNOTAFISCALITEMCODIGOOPTIONS' Routine */
         returnInSub = false;
         AV12TFNotaFiscalItemCodigo = AV22SearchTxt;
         AV13TFNotaFiscalItemCodigo_Sel = "";
         AV47Notafiscalitemlistaitenswwds_1_propostaid = AV44PropostaId;
         AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = AV10TFNotaFiscalNumero;
         AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel = AV11TFNotaFiscalNumero_Sel;
         AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = AV12TFNotaFiscalItemCodigo;
         AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel = AV13TFNotaFiscalItemCodigo_Sel;
         AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = AV14TFNotaFiscalItemDescricao;
         AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel = AV15TFNotaFiscalItemDescricao_Sel;
         AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade = AV16TFNotaFiscalItemQuantidade;
         AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to = AV17TFNotaFiscalItemQuantidade_To;
         AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario = AV18TFNotaFiscalItemValorUnitario;
         AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to = AV19TFNotaFiscalItemValorUnitario_To;
         AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal = AV20TFNotaFiscalItemValorTotal;
         AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to = AV21TFNotaFiscalItemValorTotal_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel ,
                                              AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ,
                                              AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel ,
                                              AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ,
                                              AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel ,
                                              AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ,
                                              AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade ,
                                              AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to ,
                                              AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario ,
                                              AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to ,
                                              AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal ,
                                              AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to ,
                                              A799NotaFiscalNumero ,
                                              A831NotaFiscalItemCodigo ,
                                              A833NotaFiscalItemDescricao ,
                                              A837NotaFiscalItemQuantidade ,
                                              A838NotaFiscalItemValorUnitario ,
                                              A839NotaFiscalItemValorTotal ,
                                              AV47Notafiscalitemlistaitenswwds_1_propostaid ,
                                              A323PropostaId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero), "%", "");
         lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = StringUtil.Concat( StringUtil.RTrim( AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo), "%", "");
         lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = StringUtil.Concat( StringUtil.RTrim( AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao), "%", "");
         /* Using cursor P00E93 */
         pr_default.execute(1, new Object[] {AV47Notafiscalitemlistaitenswwds_1_propostaid, lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero, AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo, AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao, AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade, AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to, AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario, AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to, AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal, AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKE94 = false;
            A794NotaFiscalId = P00E93_A794NotaFiscalId[0];
            n794NotaFiscalId = P00E93_n794NotaFiscalId[0];
            A323PropostaId = P00E93_A323PropostaId[0];
            n323PropostaId = P00E93_n323PropostaId[0];
            A831NotaFiscalItemCodigo = P00E93_A831NotaFiscalItemCodigo[0];
            n831NotaFiscalItemCodigo = P00E93_n831NotaFiscalItemCodigo[0];
            A839NotaFiscalItemValorTotal = P00E93_A839NotaFiscalItemValorTotal[0];
            n839NotaFiscalItemValorTotal = P00E93_n839NotaFiscalItemValorTotal[0];
            A838NotaFiscalItemValorUnitario = P00E93_A838NotaFiscalItemValorUnitario[0];
            n838NotaFiscalItemValorUnitario = P00E93_n838NotaFiscalItemValorUnitario[0];
            A837NotaFiscalItemQuantidade = P00E93_A837NotaFiscalItemQuantidade[0];
            n837NotaFiscalItemQuantidade = P00E93_n837NotaFiscalItemQuantidade[0];
            A833NotaFiscalItemDescricao = P00E93_A833NotaFiscalItemDescricao[0];
            n833NotaFiscalItemDescricao = P00E93_n833NotaFiscalItemDescricao[0];
            A799NotaFiscalNumero = P00E93_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00E93_n799NotaFiscalNumero[0];
            A830NotaFiscalItemId = P00E93_A830NotaFiscalItemId[0];
            A799NotaFiscalNumero = P00E93_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00E93_n799NotaFiscalNumero[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00E93_A323PropostaId[0] == A323PropostaId ) && ( StringUtil.StrCmp(P00E93_A831NotaFiscalItemCodigo[0], A831NotaFiscalItemCodigo) == 0 ) )
            {
               BRKE94 = false;
               A830NotaFiscalItemId = P00E93_A830NotaFiscalItemId[0];
               AV32count = (long)(AV32count+1);
               BRKE94 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV23SkipItems) )
            {
               AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A831NotaFiscalItemCodigo)) ? "<#Empty#>" : A831NotaFiscalItemCodigo);
               AV28Options.Add(AV27Option, 0);
               AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV28Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV23SkipItems = (short)(AV23SkipItems-1);
            }
            if ( ! BRKE94 )
            {
               BRKE94 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADNOTAFISCALITEMDESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV14TFNotaFiscalItemDescricao = AV22SearchTxt;
         AV15TFNotaFiscalItemDescricao_Sel = "";
         AV47Notafiscalitemlistaitenswwds_1_propostaid = AV44PropostaId;
         AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = AV10TFNotaFiscalNumero;
         AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel = AV11TFNotaFiscalNumero_Sel;
         AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = AV12TFNotaFiscalItemCodigo;
         AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel = AV13TFNotaFiscalItemCodigo_Sel;
         AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = AV14TFNotaFiscalItemDescricao;
         AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel = AV15TFNotaFiscalItemDescricao_Sel;
         AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade = AV16TFNotaFiscalItemQuantidade;
         AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to = AV17TFNotaFiscalItemQuantidade_To;
         AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario = AV18TFNotaFiscalItemValorUnitario;
         AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to = AV19TFNotaFiscalItemValorUnitario_To;
         AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal = AV20TFNotaFiscalItemValorTotal;
         AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to = AV21TFNotaFiscalItemValorTotal_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel ,
                                              AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ,
                                              AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel ,
                                              AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ,
                                              AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel ,
                                              AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ,
                                              AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade ,
                                              AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to ,
                                              AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario ,
                                              AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to ,
                                              AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal ,
                                              AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to ,
                                              A799NotaFiscalNumero ,
                                              A831NotaFiscalItemCodigo ,
                                              A833NotaFiscalItemDescricao ,
                                              A837NotaFiscalItemQuantidade ,
                                              A838NotaFiscalItemValorUnitario ,
                                              A839NotaFiscalItemValorTotal ,
                                              AV47Notafiscalitemlistaitenswwds_1_propostaid ,
                                              A323PropostaId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero), "%", "");
         lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = StringUtil.Concat( StringUtil.RTrim( AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo), "%", "");
         lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = StringUtil.Concat( StringUtil.RTrim( AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao), "%", "");
         /* Using cursor P00E94 */
         pr_default.execute(2, new Object[] {AV47Notafiscalitemlistaitenswwds_1_propostaid, lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero, AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo, AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao, AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade, AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to, AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario, AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to, AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal, AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKE96 = false;
            A794NotaFiscalId = P00E94_A794NotaFiscalId[0];
            n794NotaFiscalId = P00E94_n794NotaFiscalId[0];
            A323PropostaId = P00E94_A323PropostaId[0];
            n323PropostaId = P00E94_n323PropostaId[0];
            A833NotaFiscalItemDescricao = P00E94_A833NotaFiscalItemDescricao[0];
            n833NotaFiscalItemDescricao = P00E94_n833NotaFiscalItemDescricao[0];
            A839NotaFiscalItemValorTotal = P00E94_A839NotaFiscalItemValorTotal[0];
            n839NotaFiscalItemValorTotal = P00E94_n839NotaFiscalItemValorTotal[0];
            A838NotaFiscalItemValorUnitario = P00E94_A838NotaFiscalItemValorUnitario[0];
            n838NotaFiscalItemValorUnitario = P00E94_n838NotaFiscalItemValorUnitario[0];
            A837NotaFiscalItemQuantidade = P00E94_A837NotaFiscalItemQuantidade[0];
            n837NotaFiscalItemQuantidade = P00E94_n837NotaFiscalItemQuantidade[0];
            A831NotaFiscalItemCodigo = P00E94_A831NotaFiscalItemCodigo[0];
            n831NotaFiscalItemCodigo = P00E94_n831NotaFiscalItemCodigo[0];
            A799NotaFiscalNumero = P00E94_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00E94_n799NotaFiscalNumero[0];
            A830NotaFiscalItemId = P00E94_A830NotaFiscalItemId[0];
            A799NotaFiscalNumero = P00E94_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00E94_n799NotaFiscalNumero[0];
            AV32count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00E94_A323PropostaId[0] == A323PropostaId ) && ( StringUtil.StrCmp(P00E94_A833NotaFiscalItemDescricao[0], A833NotaFiscalItemDescricao) == 0 ) )
            {
               BRKE96 = false;
               A830NotaFiscalItemId = P00E94_A830NotaFiscalItemId[0];
               AV32count = (long)(AV32count+1);
               BRKE96 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV23SkipItems) )
            {
               AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A833NotaFiscalItemDescricao)) ? "<#Empty#>" : A833NotaFiscalItemDescricao);
               AV28Options.Add(AV27Option, 0);
               AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV28Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV23SkipItems = (short)(AV23SkipItems-1);
            }
            if ( ! BRKE96 )
            {
               BRKE96 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV41OptionsJson = "";
         AV42OptionsDescJson = "";
         AV43OptionIndexesJson = "";
         AV28Options = new GxSimpleCollection<string>();
         AV30OptionsDesc = new GxSimpleCollection<string>();
         AV31OptionIndexes = new GxSimpleCollection<string>();
         AV22SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV33Session = context.GetSession();
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFNotaFiscalNumero = "";
         AV11TFNotaFiscalNumero_Sel = "";
         AV12TFNotaFiscalItemCodigo = "";
         AV13TFNotaFiscalItemCodigo_Sel = "";
         AV14TFNotaFiscalItemDescricao = "";
         AV15TFNotaFiscalItemDescricao_Sel = "";
         AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = "";
         AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel = "";
         AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = "";
         AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel = "";
         AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = "";
         AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel = "";
         lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero = "";
         lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo = "";
         lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao = "";
         A799NotaFiscalNumero = "";
         A831NotaFiscalItemCodigo = "";
         A833NotaFiscalItemDescricao = "";
         P00E92_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00E92_n794NotaFiscalId = new bool[] {false} ;
         P00E92_A323PropostaId = new int[1] ;
         P00E92_n323PropostaId = new bool[] {false} ;
         P00E92_A799NotaFiscalNumero = new string[] {""} ;
         P00E92_n799NotaFiscalNumero = new bool[] {false} ;
         P00E92_A839NotaFiscalItemValorTotal = new decimal[1] ;
         P00E92_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         P00E92_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         P00E92_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         P00E92_A837NotaFiscalItemQuantidade = new decimal[1] ;
         P00E92_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         P00E92_A833NotaFiscalItemDescricao = new string[] {""} ;
         P00E92_n833NotaFiscalItemDescricao = new bool[] {false} ;
         P00E92_A831NotaFiscalItemCodigo = new string[] {""} ;
         P00E92_n831NotaFiscalItemCodigo = new bool[] {false} ;
         P00E92_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         A794NotaFiscalId = Guid.Empty;
         A830NotaFiscalItemId = Guid.Empty;
         AV27Option = "";
         P00E93_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00E93_n794NotaFiscalId = new bool[] {false} ;
         P00E93_A323PropostaId = new int[1] ;
         P00E93_n323PropostaId = new bool[] {false} ;
         P00E93_A831NotaFiscalItemCodigo = new string[] {""} ;
         P00E93_n831NotaFiscalItemCodigo = new bool[] {false} ;
         P00E93_A839NotaFiscalItemValorTotal = new decimal[1] ;
         P00E93_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         P00E93_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         P00E93_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         P00E93_A837NotaFiscalItemQuantidade = new decimal[1] ;
         P00E93_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         P00E93_A833NotaFiscalItemDescricao = new string[] {""} ;
         P00E93_n833NotaFiscalItemDescricao = new bool[] {false} ;
         P00E93_A799NotaFiscalNumero = new string[] {""} ;
         P00E93_n799NotaFiscalNumero = new bool[] {false} ;
         P00E93_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         P00E94_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00E94_n794NotaFiscalId = new bool[] {false} ;
         P00E94_A323PropostaId = new int[1] ;
         P00E94_n323PropostaId = new bool[] {false} ;
         P00E94_A833NotaFiscalItemDescricao = new string[] {""} ;
         P00E94_n833NotaFiscalItemDescricao = new bool[] {false} ;
         P00E94_A839NotaFiscalItemValorTotal = new decimal[1] ;
         P00E94_n839NotaFiscalItemValorTotal = new bool[] {false} ;
         P00E94_A838NotaFiscalItemValorUnitario = new decimal[1] ;
         P00E94_n838NotaFiscalItemValorUnitario = new bool[] {false} ;
         P00E94_A837NotaFiscalItemQuantidade = new decimal[1] ;
         P00E94_n837NotaFiscalItemQuantidade = new bool[] {false} ;
         P00E94_A831NotaFiscalItemCodigo = new string[] {""} ;
         P00E94_n831NotaFiscalItemCodigo = new bool[] {false} ;
         P00E94_A799NotaFiscalNumero = new string[] {""} ;
         P00E94_n799NotaFiscalNumero = new bool[] {false} ;
         P00E94_A830NotaFiscalItemId = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscalitemlistaitenswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00E92_A794NotaFiscalId, P00E92_n794NotaFiscalId, P00E92_A323PropostaId, P00E92_n323PropostaId, P00E92_A799NotaFiscalNumero, P00E92_n799NotaFiscalNumero, P00E92_A839NotaFiscalItemValorTotal, P00E92_n839NotaFiscalItemValorTotal, P00E92_A838NotaFiscalItemValorUnitario, P00E92_n838NotaFiscalItemValorUnitario,
               P00E92_A837NotaFiscalItemQuantidade, P00E92_n837NotaFiscalItemQuantidade, P00E92_A833NotaFiscalItemDescricao, P00E92_n833NotaFiscalItemDescricao, P00E92_A831NotaFiscalItemCodigo, P00E92_n831NotaFiscalItemCodigo, P00E92_A830NotaFiscalItemId
               }
               , new Object[] {
               P00E93_A794NotaFiscalId, P00E93_n794NotaFiscalId, P00E93_A323PropostaId, P00E93_n323PropostaId, P00E93_A831NotaFiscalItemCodigo, P00E93_n831NotaFiscalItemCodigo, P00E93_A839NotaFiscalItemValorTotal, P00E93_n839NotaFiscalItemValorTotal, P00E93_A838NotaFiscalItemValorUnitario, P00E93_n838NotaFiscalItemValorUnitario,
               P00E93_A837NotaFiscalItemQuantidade, P00E93_n837NotaFiscalItemQuantidade, P00E93_A833NotaFiscalItemDescricao, P00E93_n833NotaFiscalItemDescricao, P00E93_A799NotaFiscalNumero, P00E93_n799NotaFiscalNumero, P00E93_A830NotaFiscalItemId
               }
               , new Object[] {
               P00E94_A794NotaFiscalId, P00E94_n794NotaFiscalId, P00E94_A323PropostaId, P00E94_n323PropostaId, P00E94_A833NotaFiscalItemDescricao, P00E94_n833NotaFiscalItemDescricao, P00E94_A839NotaFiscalItemValorTotal, P00E94_n839NotaFiscalItemValorTotal, P00E94_A838NotaFiscalItemValorUnitario, P00E94_n838NotaFiscalItemValorUnitario,
               P00E94_A837NotaFiscalItemQuantidade, P00E94_n837NotaFiscalItemQuantidade, P00E94_A831NotaFiscalItemCodigo, P00E94_n831NotaFiscalItemCodigo, P00E94_A799NotaFiscalNumero, P00E94_n799NotaFiscalNumero, P00E94_A830NotaFiscalItemId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV25MaxItems ;
      private short AV24PageIndex ;
      private short AV23SkipItems ;
      private int AV45GXV1 ;
      private int AV44PropostaId ;
      private int AV47Notafiscalitemlistaitenswwds_1_propostaid ;
      private int A323PropostaId ;
      private long AV32count ;
      private decimal AV16TFNotaFiscalItemQuantidade ;
      private decimal AV17TFNotaFiscalItemQuantidade_To ;
      private decimal AV18TFNotaFiscalItemValorUnitario ;
      private decimal AV19TFNotaFiscalItemValorUnitario_To ;
      private decimal AV20TFNotaFiscalItemValorTotal ;
      private decimal AV21TFNotaFiscalItemValorTotal_To ;
      private decimal AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade ;
      private decimal AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to ;
      private decimal AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario ;
      private decimal AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to ;
      private decimal AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal ;
      private decimal AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to ;
      private decimal A837NotaFiscalItemQuantidade ;
      private decimal A838NotaFiscalItemValorUnitario ;
      private decimal A839NotaFiscalItemValorTotal ;
      private bool returnInSub ;
      private bool BRKE92 ;
      private bool n794NotaFiscalId ;
      private bool n323PropostaId ;
      private bool n799NotaFiscalNumero ;
      private bool n839NotaFiscalItemValorTotal ;
      private bool n838NotaFiscalItemValorUnitario ;
      private bool n837NotaFiscalItemQuantidade ;
      private bool n833NotaFiscalItemDescricao ;
      private bool n831NotaFiscalItemCodigo ;
      private bool BRKE94 ;
      private bool BRKE96 ;
      private string AV41OptionsJson ;
      private string AV42OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV38DDOName ;
      private string AV39SearchTxtParms ;
      private string AV40SearchTxtTo ;
      private string AV22SearchTxt ;
      private string AV10TFNotaFiscalNumero ;
      private string AV11TFNotaFiscalNumero_Sel ;
      private string AV12TFNotaFiscalItemCodigo ;
      private string AV13TFNotaFiscalItemCodigo_Sel ;
      private string AV14TFNotaFiscalItemDescricao ;
      private string AV15TFNotaFiscalItemDescricao_Sel ;
      private string AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ;
      private string AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel ;
      private string AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ;
      private string AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel ;
      private string AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ;
      private string AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel ;
      private string lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ;
      private string lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ;
      private string lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ;
      private string A799NotaFiscalNumero ;
      private string A831NotaFiscalItemCodigo ;
      private string A833NotaFiscalItemDescricao ;
      private string AV27Option ;
      private Guid A794NotaFiscalId ;
      private Guid A830NotaFiscalItemId ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV28Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV31OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00E92_A794NotaFiscalId ;
      private bool[] P00E92_n794NotaFiscalId ;
      private int[] P00E92_A323PropostaId ;
      private bool[] P00E92_n323PropostaId ;
      private string[] P00E92_A799NotaFiscalNumero ;
      private bool[] P00E92_n799NotaFiscalNumero ;
      private decimal[] P00E92_A839NotaFiscalItemValorTotal ;
      private bool[] P00E92_n839NotaFiscalItemValorTotal ;
      private decimal[] P00E92_A838NotaFiscalItemValorUnitario ;
      private bool[] P00E92_n838NotaFiscalItemValorUnitario ;
      private decimal[] P00E92_A837NotaFiscalItemQuantidade ;
      private bool[] P00E92_n837NotaFiscalItemQuantidade ;
      private string[] P00E92_A833NotaFiscalItemDescricao ;
      private bool[] P00E92_n833NotaFiscalItemDescricao ;
      private string[] P00E92_A831NotaFiscalItemCodigo ;
      private bool[] P00E92_n831NotaFiscalItemCodigo ;
      private Guid[] P00E92_A830NotaFiscalItemId ;
      private Guid[] P00E93_A794NotaFiscalId ;
      private bool[] P00E93_n794NotaFiscalId ;
      private int[] P00E93_A323PropostaId ;
      private bool[] P00E93_n323PropostaId ;
      private string[] P00E93_A831NotaFiscalItemCodigo ;
      private bool[] P00E93_n831NotaFiscalItemCodigo ;
      private decimal[] P00E93_A839NotaFiscalItemValorTotal ;
      private bool[] P00E93_n839NotaFiscalItemValorTotal ;
      private decimal[] P00E93_A838NotaFiscalItemValorUnitario ;
      private bool[] P00E93_n838NotaFiscalItemValorUnitario ;
      private decimal[] P00E93_A837NotaFiscalItemQuantidade ;
      private bool[] P00E93_n837NotaFiscalItemQuantidade ;
      private string[] P00E93_A833NotaFiscalItemDescricao ;
      private bool[] P00E93_n833NotaFiscalItemDescricao ;
      private string[] P00E93_A799NotaFiscalNumero ;
      private bool[] P00E93_n799NotaFiscalNumero ;
      private Guid[] P00E93_A830NotaFiscalItemId ;
      private Guid[] P00E94_A794NotaFiscalId ;
      private bool[] P00E94_n794NotaFiscalId ;
      private int[] P00E94_A323PropostaId ;
      private bool[] P00E94_n323PropostaId ;
      private string[] P00E94_A833NotaFiscalItemDescricao ;
      private bool[] P00E94_n833NotaFiscalItemDescricao ;
      private decimal[] P00E94_A839NotaFiscalItemValorTotal ;
      private bool[] P00E94_n839NotaFiscalItemValorTotal ;
      private decimal[] P00E94_A838NotaFiscalItemValorUnitario ;
      private bool[] P00E94_n838NotaFiscalItemValorUnitario ;
      private decimal[] P00E94_A837NotaFiscalItemQuantidade ;
      private bool[] P00E94_n837NotaFiscalItemQuantidade ;
      private string[] P00E94_A831NotaFiscalItemCodigo ;
      private bool[] P00E94_n831NotaFiscalItemCodigo ;
      private string[] P00E94_A799NotaFiscalNumero ;
      private bool[] P00E94_n799NotaFiscalNumero ;
      private Guid[] P00E94_A830NotaFiscalItemId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class notafiscalitemlistaitenswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00E92( IGxContext context ,
                                             string AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel ,
                                             string AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ,
                                             string AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel ,
                                             string AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ,
                                             string AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel ,
                                             string AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ,
                                             decimal AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade ,
                                             decimal AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to ,
                                             decimal AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario ,
                                             decimal AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to ,
                                             decimal AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal ,
                                             decimal AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to ,
                                             string A799NotaFiscalNumero ,
                                             string A831NotaFiscalItemCodigo ,
                                             string A833NotaFiscalItemDescricao ,
                                             decimal A837NotaFiscalItemQuantidade ,
                                             decimal A838NotaFiscalItemValorUnitario ,
                                             decimal A839NotaFiscalItemValorTotal ,
                                             int AV47Notafiscalitemlistaitenswwds_1_propostaid ,
                                             int A323PropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[13];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalId, T1.PropostaId, T2.NotaFiscalNumero, T1.NotaFiscalItemValorTotal, T1.NotaFiscalItemValorUnitario, T1.NotaFiscalItemQuantidade, T1.NotaFiscalItemDescricao, T1.NotaFiscalItemCodigo, T1.NotaFiscalItemId FROM (NotaFiscalItem T1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "(T1.PropostaId = :AV47Notafiscalitemlistaitenswwds_1_propostaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero like :lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero = ( :AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.NotaFiscalNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel)) && ! ( StringUtil.StrCmp(AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo = ( :AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao like :lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel)) && ! ( StringUtil.StrCmp(AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao = ( :AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_se))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade >= :AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade <= :AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_t)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario >= :AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitar)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario <= :AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitar)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal >= :AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal <= :AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PropostaId, T2.NotaFiscalNumero";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00E93( IGxContext context ,
                                             string AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel ,
                                             string AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ,
                                             string AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel ,
                                             string AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ,
                                             string AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel ,
                                             string AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ,
                                             decimal AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade ,
                                             decimal AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to ,
                                             decimal AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario ,
                                             decimal AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to ,
                                             decimal AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal ,
                                             decimal AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to ,
                                             string A799NotaFiscalNumero ,
                                             string A831NotaFiscalItemCodigo ,
                                             string A833NotaFiscalItemDescricao ,
                                             decimal A837NotaFiscalItemQuantidade ,
                                             decimal A838NotaFiscalItemValorUnitario ,
                                             decimal A839NotaFiscalItemValorTotal ,
                                             int AV47Notafiscalitemlistaitenswwds_1_propostaid ,
                                             int A323PropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[13];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalId, T1.PropostaId, T1.NotaFiscalItemCodigo, T1.NotaFiscalItemValorTotal, T1.NotaFiscalItemValorUnitario, T1.NotaFiscalItemQuantidade, T1.NotaFiscalItemDescricao, T2.NotaFiscalNumero, T1.NotaFiscalItemId FROM (NotaFiscalItem T1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "(T1.PropostaId = :AV47Notafiscalitemlistaitenswwds_1_propostaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero like :lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero = ( :AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( StringUtil.StrCmp(AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.NotaFiscalNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel)) && ! ( StringUtil.StrCmp(AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo = ( :AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao like :lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel)) && ! ( StringUtil.StrCmp(AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao = ( :AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_se))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade >= :AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade <= :AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_t)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario >= :AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitar)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario <= :AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitar)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal >= :AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal <= :AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PropostaId, T1.NotaFiscalItemCodigo";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00E94( IGxContext context ,
                                             string AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel ,
                                             string AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero ,
                                             string AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel ,
                                             string AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo ,
                                             string AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel ,
                                             string AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao ,
                                             decimal AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade ,
                                             decimal AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to ,
                                             decimal AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario ,
                                             decimal AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to ,
                                             decimal AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal ,
                                             decimal AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to ,
                                             string A799NotaFiscalNumero ,
                                             string A831NotaFiscalItemCodigo ,
                                             string A833NotaFiscalItemDescricao ,
                                             decimal A837NotaFiscalItemQuantidade ,
                                             decimal A838NotaFiscalItemValorUnitario ,
                                             decimal A839NotaFiscalItemValorTotal ,
                                             int AV47Notafiscalitemlistaitenswwds_1_propostaid ,
                                             int A323PropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[13];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalId, T1.PropostaId, T1.NotaFiscalItemDescricao, T1.NotaFiscalItemValorTotal, T1.NotaFiscalItemValorUnitario, T1.NotaFiscalItemQuantidade, T1.NotaFiscalItemCodigo, T2.NotaFiscalNumero, T1.NotaFiscalItemId FROM (NotaFiscalItem T1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "(T1.PropostaId = :AV47Notafiscalitemlistaitenswwds_1_propostaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero like :lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero = ( :AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( StringUtil.StrCmp(AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.NotaFiscalNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo like :lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel)) && ! ( StringUtil.StrCmp(AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo = ( :AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemCodigo IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao like :lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel)) && ! ( StringUtil.StrCmp(AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao = ( :AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_se))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemDescricao IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalItemDescricao))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade >= :AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemQuantidade <= :AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_t)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitario) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario >= :AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitar)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitario_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorUnitario <= :AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitar)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal >= :AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalItemValorTotal <= :AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PropostaId, T1.NotaFiscalItemDescricao";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00E92(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] );
               case 1 :
                     return conditional_P00E93(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] );
               case 2 :
                     return conditional_P00E94(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (decimal)dynConstraints[6] , (decimal)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (decimal)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00E92;
          prmP00E92 = new Object[] {
          new ParDef("AV47Notafiscalitemlistaitenswwds_1_propostaid",GXType.Int32,9,0) ,
          new ParDef("lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel",GXType.VarChar,40,0) ,
          new ParDef("lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo",GXType.VarChar,60,0) ,
          new ParDef("AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel",GXType.VarChar,60,0) ,
          new ParDef("lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao",GXType.VarChar,255,0) ,
          new ParDef("AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_se",GXType.VarChar,255,0) ,
          new ParDef("AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade",GXType.Number,18,6) ,
          new ParDef("AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_t",GXType.Number,18,6) ,
          new ParDef("AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitar",GXType.Number,18,2) ,
          new ParDef("AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitar",GXType.Number,18,2) ,
          new ParDef("AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal",GXType.Number,18,2) ,
          new ParDef("AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_",GXType.Number,18,2)
          };
          Object[] prmP00E93;
          prmP00E93 = new Object[] {
          new ParDef("AV47Notafiscalitemlistaitenswwds_1_propostaid",GXType.Int32,9,0) ,
          new ParDef("lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel",GXType.VarChar,40,0) ,
          new ParDef("lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo",GXType.VarChar,60,0) ,
          new ParDef("AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel",GXType.VarChar,60,0) ,
          new ParDef("lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao",GXType.VarChar,255,0) ,
          new ParDef("AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_se",GXType.VarChar,255,0) ,
          new ParDef("AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade",GXType.Number,18,6) ,
          new ParDef("AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_t",GXType.Number,18,6) ,
          new ParDef("AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitar",GXType.Number,18,2) ,
          new ParDef("AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitar",GXType.Number,18,2) ,
          new ParDef("AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal",GXType.Number,18,2) ,
          new ParDef("AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_",GXType.Number,18,2)
          };
          Object[] prmP00E94;
          prmP00E94 = new Object[] {
          new ParDef("AV47Notafiscalitemlistaitenswwds_1_propostaid",GXType.Int32,9,0) ,
          new ParDef("lV48Notafiscalitemlistaitenswwds_2_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV49Notafiscalitemlistaitenswwds_3_tfnotafiscalnumero_sel",GXType.VarChar,40,0) ,
          new ParDef("lV50Notafiscalitemlistaitenswwds_4_tfnotafiscalitemcodigo",GXType.VarChar,60,0) ,
          new ParDef("AV51Notafiscalitemlistaitenswwds_5_tfnotafiscalitemcodigo_sel",GXType.VarChar,60,0) ,
          new ParDef("lV52Notafiscalitemlistaitenswwds_6_tfnotafiscalitemdescricao",GXType.VarChar,255,0) ,
          new ParDef("AV53Notafiscalitemlistaitenswwds_7_tfnotafiscalitemdescricao_se",GXType.VarChar,255,0) ,
          new ParDef("AV54Notafiscalitemlistaitenswwds_8_tfnotafiscalitemquantidade",GXType.Number,18,6) ,
          new ParDef("AV55Notafiscalitemlistaitenswwds_9_tfnotafiscalitemquantidade_t",GXType.Number,18,6) ,
          new ParDef("AV56Notafiscalitemlistaitenswwds_10_tfnotafiscalitemvalorunitar",GXType.Number,18,2) ,
          new ParDef("AV57Notafiscalitemlistaitenswwds_11_tfnotafiscalitemvalorunitar",GXType.Number,18,2) ,
          new ParDef("AV58Notafiscalitemlistaitenswwds_12_tfnotafiscalitemvalortotal",GXType.Number,18,2) ,
          new ParDef("AV59Notafiscalitemlistaitenswwds_13_tfnotafiscalitemvalortotal_",GXType.Number,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P00E92", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E92,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E93", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E93,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00E94", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00E94,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((Guid[]) buf[16])[0] = rslt.getGuid(9);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((Guid[]) buf[16])[0] = rslt.getGuid(9);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((Guid[]) buf[16])[0] = rslt.getGuid(9);
                return;
       }
    }

 }

}
