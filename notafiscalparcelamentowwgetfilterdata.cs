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
   public class notafiscalparcelamentowwgetfilterdata : GXProcedure
   {
      public notafiscalparcelamentowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public notafiscalparcelamentowwgetfilterdata( IGxContext context )
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
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV39OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV24Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21MaxItems = 10;
         AV20PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV35SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV18SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? "" : StringUtil.Substring( AV35SearchTxtParms, 3, -1));
         AV19SkipItems = (short)(AV20PageIndex*AV21MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_NOTAFISCALNUMERO") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALNUMEROOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_NOTAFISCALPARCELAMENTONUMERO") == 0 )
         {
            /* Execute user subroutine: 'LOADNOTAFISCALPARCELAMENTONUMEROOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV37OptionsJson = AV24Options.ToJSonString(false);
         AV38OptionsDescJson = AV26OptionsDesc.ToJSonString(false);
         AV39OptionIndexesJson = AV27OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("NotaFiscalParcelamentoWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "NotaFiscalParcelamentoWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("NotaFiscalParcelamentoWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO") == 0 )
            {
               AV10TFNotaFiscalNumero = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALNUMERO_SEL") == 0 )
            {
               AV11TFNotaFiscalNumero_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTONUMERO") == 0 )
            {
               AV12TFNotaFiscalParcelamentoNumero = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTONUMERO_SEL") == 0 )
            {
               AV13TFNotaFiscalParcelamentoNumero_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTOVENCIMENTO") == 0 )
            {
               AV16TFNotaFiscalParcelamentoVencimento = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Value, 4);
               AV17TFNotaFiscalParcelamentoVencimento_To = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTOVALOR") == 0 )
            {
               AV14TFNotaFiscalParcelamentoValor = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, ".");
               AV15TFNotaFiscalParcelamentoValor_To = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTOVALORTAXAADMINISTRATIVA") == 0 )
            {
               AV42TFNotaFiscalParcelamentoValorTaxaAdministrativa = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, ".");
               AV43TFNotaFiscalParcelamentoValorTaxaAdministrativa_To = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTOVALORTAXAANUAL") == 0 )
            {
               AV44TFNotaFiscalParcelamentoValorTaxaAnual = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, ".");
               AV45TFNotaFiscalParcelamentoValorTaxaAnual_To = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFNOTAFISCALPARCELAMENTOLIQUIDO") == 0 )
            {
               AV46TFNotaFiscalParcelamentoLiquido = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, ".");
               AV47TFNotaFiscalParcelamentoLiquido_To = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "PARM_&JSON") == 0 )
            {
               AV40JSON = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADNOTAFISCALNUMEROOPTIONS' Routine */
         returnInSub = false;
         AV10TFNotaFiscalNumero = AV18SearchTxt;
         AV11TFNotaFiscalNumero_Sel = "";
         AV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero = AV10TFNotaFiscalNumero;
         AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel = AV11TFNotaFiscalNumero_Sel;
         AV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = AV12TFNotaFiscalParcelamentoNumero;
         AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel = AV13TFNotaFiscalParcelamentoNumero_Sel;
         AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento = AV16TFNotaFiscalParcelamentoVencimento;
         AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to = AV17TFNotaFiscalParcelamentoVencimento_To;
         AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor = AV14TFNotaFiscalParcelamentoValor;
         AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to = AV15TFNotaFiscalParcelamentoValor_To;
         AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa = AV42TFNotaFiscalParcelamentoValorTaxaAdministrativa;
         AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to = AV43TFNotaFiscalParcelamentoValorTaxaAdministrativa_To;
         AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual = AV44TFNotaFiscalParcelamentoValorTaxaAnual;
         AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to = AV45TFNotaFiscalParcelamentoValorTaxaAnual_To;
         AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido = AV46TFNotaFiscalParcelamentoLiquido;
         AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to = AV47TFNotaFiscalParcelamentoLiquido_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A794NotaFiscalId ,
                                              AV41array_NotaFiscalId ,
                                              AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel ,
                                              AV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero ,
                                              AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel ,
                                              AV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero ,
                                              AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento ,
                                              AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to ,
                                              AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor ,
                                              AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to ,
                                              AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa ,
                                              AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to ,
                                              AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual ,
                                              AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to ,
                                              AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido ,
                                              AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to ,
                                              A799NotaFiscalNumero ,
                                              A891NotaFiscalParcelamentoNumero ,
                                              A893NotaFiscalParcelamentoVencimento ,
                                              A892NotaFiscalParcelamentoValor ,
                                              A895NotaFiscalParcelamentoValorTaxaAdministrativa ,
                                              A896NotaFiscalParcelamentoValorTaxaAnual ,
                                              A897NotaFiscalParcelamentoLiquido } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                              }
         });
         lV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero), "%", "");
         lV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = StringUtil.Concat( StringUtil.RTrim( AV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero), "%", "");
         /* Using cursor P00EC2 */
         pr_default.execute(0, new Object[] {lV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero, AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel, lV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero, AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel, AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento, AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to, AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor, AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to, AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa, AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to, AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual, AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to, AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido, AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKEC2 = false;
            A799NotaFiscalNumero = P00EC2_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EC2_n799NotaFiscalNumero[0];
            A794NotaFiscalId = P00EC2_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EC2_n794NotaFiscalId[0];
            A897NotaFiscalParcelamentoLiquido = P00EC2_A897NotaFiscalParcelamentoLiquido[0];
            n897NotaFiscalParcelamentoLiquido = P00EC2_n897NotaFiscalParcelamentoLiquido[0];
            A896NotaFiscalParcelamentoValorTaxaAnual = P00EC2_A896NotaFiscalParcelamentoValorTaxaAnual[0];
            n896NotaFiscalParcelamentoValorTaxaAnual = P00EC2_n896NotaFiscalParcelamentoValorTaxaAnual[0];
            A895NotaFiscalParcelamentoValorTaxaAdministrativa = P00EC2_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            n895NotaFiscalParcelamentoValorTaxaAdministrativa = P00EC2_n895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            A892NotaFiscalParcelamentoValor = P00EC2_A892NotaFiscalParcelamentoValor[0];
            n892NotaFiscalParcelamentoValor = P00EC2_n892NotaFiscalParcelamentoValor[0];
            A893NotaFiscalParcelamentoVencimento = P00EC2_A893NotaFiscalParcelamentoVencimento[0];
            n893NotaFiscalParcelamentoVencimento = P00EC2_n893NotaFiscalParcelamentoVencimento[0];
            A891NotaFiscalParcelamentoNumero = P00EC2_A891NotaFiscalParcelamentoNumero[0];
            n891NotaFiscalParcelamentoNumero = P00EC2_n891NotaFiscalParcelamentoNumero[0];
            A890NotaFiscalParcelamentoID = P00EC2_A890NotaFiscalParcelamentoID[0];
            A799NotaFiscalNumero = P00EC2_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EC2_n799NotaFiscalNumero[0];
            AV28count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00EC2_A799NotaFiscalNumero[0], A799NotaFiscalNumero) == 0 ) )
            {
               BRKEC2 = false;
               A794NotaFiscalId = P00EC2_A794NotaFiscalId[0];
               n794NotaFiscalId = P00EC2_n794NotaFiscalId[0];
               A890NotaFiscalParcelamentoID = P00EC2_A890NotaFiscalParcelamentoID[0];
               if ( (AV41array_NotaFiscalId.IndexOf(A794NotaFiscalId)>0) )
               {
                  AV28count = (long)(AV28count+1);
               }
               BRKEC2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A799NotaFiscalNumero)) ? "<#Empty#>" : A799NotaFiscalNumero);
               AV24Options.Add(AV23Option, 0);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV24Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV19SkipItems = (short)(AV19SkipItems-1);
            }
            if ( ! BRKEC2 )
            {
               BRKEC2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADNOTAFISCALPARCELAMENTONUMEROOPTIONS' Routine */
         returnInSub = false;
         AV12TFNotaFiscalParcelamentoNumero = AV18SearchTxt;
         AV13TFNotaFiscalParcelamentoNumero_Sel = "";
         AV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero = AV10TFNotaFiscalNumero;
         AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel = AV11TFNotaFiscalNumero_Sel;
         AV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = AV12TFNotaFiscalParcelamentoNumero;
         AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel = AV13TFNotaFiscalParcelamentoNumero_Sel;
         AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento = AV16TFNotaFiscalParcelamentoVencimento;
         AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to = AV17TFNotaFiscalParcelamentoVencimento_To;
         AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor = AV14TFNotaFiscalParcelamentoValor;
         AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to = AV15TFNotaFiscalParcelamentoValor_To;
         AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa = AV42TFNotaFiscalParcelamentoValorTaxaAdministrativa;
         AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to = AV43TFNotaFiscalParcelamentoValorTaxaAdministrativa_To;
         AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual = AV44TFNotaFiscalParcelamentoValorTaxaAnual;
         AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to = AV45TFNotaFiscalParcelamentoValorTaxaAnual_To;
         AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido = AV46TFNotaFiscalParcelamentoLiquido;
         AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to = AV47TFNotaFiscalParcelamentoLiquido_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A794NotaFiscalId ,
                                              AV41array_NotaFiscalId ,
                                              AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel ,
                                              AV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero ,
                                              AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel ,
                                              AV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero ,
                                              AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento ,
                                              AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to ,
                                              AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor ,
                                              AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to ,
                                              AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa ,
                                              AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to ,
                                              AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual ,
                                              AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to ,
                                              AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido ,
                                              AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to ,
                                              A799NotaFiscalNumero ,
                                              A891NotaFiscalParcelamentoNumero ,
                                              A893NotaFiscalParcelamentoVencimento ,
                                              A892NotaFiscalParcelamentoValor ,
                                              A895NotaFiscalParcelamentoValorTaxaAdministrativa ,
                                              A896NotaFiscalParcelamentoValorTaxaAnual ,
                                              A897NotaFiscalParcelamentoLiquido } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                              }
         });
         lV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero = StringUtil.Concat( StringUtil.RTrim( AV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero), "%", "");
         lV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = StringUtil.Concat( StringUtil.RTrim( AV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero), "%", "");
         /* Using cursor P00EC3 */
         pr_default.execute(1, new Object[] {lV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero, AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel, lV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero, AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel, AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento, AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to, AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor, AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to, AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa, AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to, AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual, AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to, AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido, AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKEC4 = false;
            A891NotaFiscalParcelamentoNumero = P00EC3_A891NotaFiscalParcelamentoNumero[0];
            n891NotaFiscalParcelamentoNumero = P00EC3_n891NotaFiscalParcelamentoNumero[0];
            A794NotaFiscalId = P00EC3_A794NotaFiscalId[0];
            n794NotaFiscalId = P00EC3_n794NotaFiscalId[0];
            A897NotaFiscalParcelamentoLiquido = P00EC3_A897NotaFiscalParcelamentoLiquido[0];
            n897NotaFiscalParcelamentoLiquido = P00EC3_n897NotaFiscalParcelamentoLiquido[0];
            A896NotaFiscalParcelamentoValorTaxaAnual = P00EC3_A896NotaFiscalParcelamentoValorTaxaAnual[0];
            n896NotaFiscalParcelamentoValorTaxaAnual = P00EC3_n896NotaFiscalParcelamentoValorTaxaAnual[0];
            A895NotaFiscalParcelamentoValorTaxaAdministrativa = P00EC3_A895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            n895NotaFiscalParcelamentoValorTaxaAdministrativa = P00EC3_n895NotaFiscalParcelamentoValorTaxaAdministrativa[0];
            A892NotaFiscalParcelamentoValor = P00EC3_A892NotaFiscalParcelamentoValor[0];
            n892NotaFiscalParcelamentoValor = P00EC3_n892NotaFiscalParcelamentoValor[0];
            A893NotaFiscalParcelamentoVencimento = P00EC3_A893NotaFiscalParcelamentoVencimento[0];
            n893NotaFiscalParcelamentoVencimento = P00EC3_n893NotaFiscalParcelamentoVencimento[0];
            A799NotaFiscalNumero = P00EC3_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EC3_n799NotaFiscalNumero[0];
            A890NotaFiscalParcelamentoID = P00EC3_A890NotaFiscalParcelamentoID[0];
            A799NotaFiscalNumero = P00EC3_A799NotaFiscalNumero[0];
            n799NotaFiscalNumero = P00EC3_n799NotaFiscalNumero[0];
            AV28count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00EC3_A891NotaFiscalParcelamentoNumero[0], A891NotaFiscalParcelamentoNumero) == 0 ) )
            {
               BRKEC4 = false;
               A890NotaFiscalParcelamentoID = P00EC3_A890NotaFiscalParcelamentoID[0];
               AV28count = (long)(AV28count+1);
               BRKEC4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A891NotaFiscalParcelamentoNumero)) ? "<#Empty#>" : A891NotaFiscalParcelamentoNumero);
               AV24Options.Add(AV23Option, 0);
               AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV24Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV19SkipItems = (short)(AV19SkipItems-1);
            }
            if ( ! BRKEC4 )
            {
               BRKEC4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV37OptionsJson = "";
         AV38OptionsDescJson = "";
         AV39OptionIndexesJson = "";
         AV24Options = new GxSimpleCollection<string>();
         AV26OptionsDesc = new GxSimpleCollection<string>();
         AV27OptionIndexes = new GxSimpleCollection<string>();
         AV18SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29Session = context.GetSession();
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFNotaFiscalNumero = "";
         AV11TFNotaFiscalNumero_Sel = "";
         AV12TFNotaFiscalParcelamentoNumero = "";
         AV13TFNotaFiscalParcelamentoNumero_Sel = "";
         AV16TFNotaFiscalParcelamentoVencimento = DateTime.MinValue;
         AV17TFNotaFiscalParcelamentoVencimento_To = DateTime.MinValue;
         AV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero = "";
         AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel = "";
         AV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = "";
         AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel = "";
         AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento = DateTime.MinValue;
         AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to = DateTime.MinValue;
         lV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero = "";
         lV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero = "";
         A794NotaFiscalId = Guid.Empty;
         AV41array_NotaFiscalId = new GxSimpleCollection<Guid>();
         A799NotaFiscalNumero = "";
         A891NotaFiscalParcelamentoNumero = "";
         A893NotaFiscalParcelamentoVencimento = DateTime.MinValue;
         P00EC2_A799NotaFiscalNumero = new string[] {""} ;
         P00EC2_n799NotaFiscalNumero = new bool[] {false} ;
         P00EC2_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00EC2_n794NotaFiscalId = new bool[] {false} ;
         P00EC2_A897NotaFiscalParcelamentoLiquido = new decimal[1] ;
         P00EC2_n897NotaFiscalParcelamentoLiquido = new bool[] {false} ;
         P00EC2_A896NotaFiscalParcelamentoValorTaxaAnual = new decimal[1] ;
         P00EC2_n896NotaFiscalParcelamentoValorTaxaAnual = new bool[] {false} ;
         P00EC2_A895NotaFiscalParcelamentoValorTaxaAdministrativa = new decimal[1] ;
         P00EC2_n895NotaFiscalParcelamentoValorTaxaAdministrativa = new bool[] {false} ;
         P00EC2_A892NotaFiscalParcelamentoValor = new decimal[1] ;
         P00EC2_n892NotaFiscalParcelamentoValor = new bool[] {false} ;
         P00EC2_A893NotaFiscalParcelamentoVencimento = new DateTime[] {DateTime.MinValue} ;
         P00EC2_n893NotaFiscalParcelamentoVencimento = new bool[] {false} ;
         P00EC2_A891NotaFiscalParcelamentoNumero = new string[] {""} ;
         P00EC2_n891NotaFiscalParcelamentoNumero = new bool[] {false} ;
         P00EC2_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         A890NotaFiscalParcelamentoID = Guid.Empty;
         AV23Option = "";
         P00EC3_A891NotaFiscalParcelamentoNumero = new string[] {""} ;
         P00EC3_n891NotaFiscalParcelamentoNumero = new bool[] {false} ;
         P00EC3_A794NotaFiscalId = new Guid[] {Guid.Empty} ;
         P00EC3_n794NotaFiscalId = new bool[] {false} ;
         P00EC3_A897NotaFiscalParcelamentoLiquido = new decimal[1] ;
         P00EC3_n897NotaFiscalParcelamentoLiquido = new bool[] {false} ;
         P00EC3_A896NotaFiscalParcelamentoValorTaxaAnual = new decimal[1] ;
         P00EC3_n896NotaFiscalParcelamentoValorTaxaAnual = new bool[] {false} ;
         P00EC3_A895NotaFiscalParcelamentoValorTaxaAdministrativa = new decimal[1] ;
         P00EC3_n895NotaFiscalParcelamentoValorTaxaAdministrativa = new bool[] {false} ;
         P00EC3_A892NotaFiscalParcelamentoValor = new decimal[1] ;
         P00EC3_n892NotaFiscalParcelamentoValor = new bool[] {false} ;
         P00EC3_A893NotaFiscalParcelamentoVencimento = new DateTime[] {DateTime.MinValue} ;
         P00EC3_n893NotaFiscalParcelamentoVencimento = new bool[] {false} ;
         P00EC3_A799NotaFiscalNumero = new string[] {""} ;
         P00EC3_n799NotaFiscalNumero = new bool[] {false} ;
         P00EC3_A890NotaFiscalParcelamentoID = new Guid[] {Guid.Empty} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.notafiscalparcelamentowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00EC2_A799NotaFiscalNumero, P00EC2_n799NotaFiscalNumero, P00EC2_A794NotaFiscalId, P00EC2_n794NotaFiscalId, P00EC2_A897NotaFiscalParcelamentoLiquido, P00EC2_n897NotaFiscalParcelamentoLiquido, P00EC2_A896NotaFiscalParcelamentoValorTaxaAnual, P00EC2_n896NotaFiscalParcelamentoValorTaxaAnual, P00EC2_A895NotaFiscalParcelamentoValorTaxaAdministrativa, P00EC2_n895NotaFiscalParcelamentoValorTaxaAdministrativa,
               P00EC2_A892NotaFiscalParcelamentoValor, P00EC2_n892NotaFiscalParcelamentoValor, P00EC2_A893NotaFiscalParcelamentoVencimento, P00EC2_n893NotaFiscalParcelamentoVencimento, P00EC2_A891NotaFiscalParcelamentoNumero, P00EC2_n891NotaFiscalParcelamentoNumero, P00EC2_A890NotaFiscalParcelamentoID
               }
               , new Object[] {
               P00EC3_A891NotaFiscalParcelamentoNumero, P00EC3_n891NotaFiscalParcelamentoNumero, P00EC3_A794NotaFiscalId, P00EC3_n794NotaFiscalId, P00EC3_A897NotaFiscalParcelamentoLiquido, P00EC3_n897NotaFiscalParcelamentoLiquido, P00EC3_A896NotaFiscalParcelamentoValorTaxaAnual, P00EC3_n896NotaFiscalParcelamentoValorTaxaAnual, P00EC3_A895NotaFiscalParcelamentoValorTaxaAdministrativa, P00EC3_n895NotaFiscalParcelamentoValorTaxaAdministrativa,
               P00EC3_A892NotaFiscalParcelamentoValor, P00EC3_n892NotaFiscalParcelamentoValor, P00EC3_A893NotaFiscalParcelamentoVencimento, P00EC3_n893NotaFiscalParcelamentoVencimento, P00EC3_A799NotaFiscalNumero, P00EC3_n799NotaFiscalNumero, P00EC3_A890NotaFiscalParcelamentoID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21MaxItems ;
      private short AV20PageIndex ;
      private short AV19SkipItems ;
      private short AV40JSON ;
      private int AV48GXV1 ;
      private long AV28count ;
      private decimal AV14TFNotaFiscalParcelamentoValor ;
      private decimal AV15TFNotaFiscalParcelamentoValor_To ;
      private decimal AV42TFNotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal AV43TFNotaFiscalParcelamentoValorTaxaAdministrativa_To ;
      private decimal AV44TFNotaFiscalParcelamentoValorTaxaAnual ;
      private decimal AV45TFNotaFiscalParcelamentoValorTaxaAnual_To ;
      private decimal AV46TFNotaFiscalParcelamentoLiquido ;
      private decimal AV47TFNotaFiscalParcelamentoLiquido_To ;
      private decimal AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor ;
      private decimal AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to ;
      private decimal AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa ;
      private decimal AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to ;
      private decimal AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual ;
      private decimal AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to ;
      private decimal AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido ;
      private decimal AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to ;
      private decimal A892NotaFiscalParcelamentoValor ;
      private decimal A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal A896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal A897NotaFiscalParcelamentoLiquido ;
      private DateTime AV16TFNotaFiscalParcelamentoVencimento ;
      private DateTime AV17TFNotaFiscalParcelamentoVencimento_To ;
      private DateTime AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento ;
      private DateTime AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to ;
      private DateTime A893NotaFiscalParcelamentoVencimento ;
      private bool returnInSub ;
      private bool BRKEC2 ;
      private bool n799NotaFiscalNumero ;
      private bool n794NotaFiscalId ;
      private bool n897NotaFiscalParcelamentoLiquido ;
      private bool n896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool n892NotaFiscalParcelamentoValor ;
      private bool n893NotaFiscalParcelamentoVencimento ;
      private bool n891NotaFiscalParcelamentoNumero ;
      private bool BRKEC4 ;
      private string AV37OptionsJson ;
      private string AV38OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV34DDOName ;
      private string AV35SearchTxtParms ;
      private string AV36SearchTxtTo ;
      private string AV18SearchTxt ;
      private string AV10TFNotaFiscalNumero ;
      private string AV11TFNotaFiscalNumero_Sel ;
      private string AV12TFNotaFiscalParcelamentoNumero ;
      private string AV13TFNotaFiscalParcelamentoNumero_Sel ;
      private string AV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero ;
      private string AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel ;
      private string AV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero ;
      private string AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel ;
      private string lV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero ;
      private string lV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero ;
      private string A799NotaFiscalNumero ;
      private string A891NotaFiscalParcelamentoNumero ;
      private string AV23Option ;
      private Guid A794NotaFiscalId ;
      private Guid A890NotaFiscalParcelamentoID ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private GxSimpleCollection<Guid> AV41array_NotaFiscalId ;
      private IDataStoreProvider pr_default ;
      private string[] P00EC2_A799NotaFiscalNumero ;
      private bool[] P00EC2_n799NotaFiscalNumero ;
      private Guid[] P00EC2_A794NotaFiscalId ;
      private bool[] P00EC2_n794NotaFiscalId ;
      private decimal[] P00EC2_A897NotaFiscalParcelamentoLiquido ;
      private bool[] P00EC2_n897NotaFiscalParcelamentoLiquido ;
      private decimal[] P00EC2_A896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool[] P00EC2_n896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal[] P00EC2_A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool[] P00EC2_n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal[] P00EC2_A892NotaFiscalParcelamentoValor ;
      private bool[] P00EC2_n892NotaFiscalParcelamentoValor ;
      private DateTime[] P00EC2_A893NotaFiscalParcelamentoVencimento ;
      private bool[] P00EC2_n893NotaFiscalParcelamentoVencimento ;
      private string[] P00EC2_A891NotaFiscalParcelamentoNumero ;
      private bool[] P00EC2_n891NotaFiscalParcelamentoNumero ;
      private Guid[] P00EC2_A890NotaFiscalParcelamentoID ;
      private string[] P00EC3_A891NotaFiscalParcelamentoNumero ;
      private bool[] P00EC3_n891NotaFiscalParcelamentoNumero ;
      private Guid[] P00EC3_A794NotaFiscalId ;
      private bool[] P00EC3_n794NotaFiscalId ;
      private decimal[] P00EC3_A897NotaFiscalParcelamentoLiquido ;
      private bool[] P00EC3_n897NotaFiscalParcelamentoLiquido ;
      private decimal[] P00EC3_A896NotaFiscalParcelamentoValorTaxaAnual ;
      private bool[] P00EC3_n896NotaFiscalParcelamentoValorTaxaAnual ;
      private decimal[] P00EC3_A895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private bool[] P00EC3_n895NotaFiscalParcelamentoValorTaxaAdministrativa ;
      private decimal[] P00EC3_A892NotaFiscalParcelamentoValor ;
      private bool[] P00EC3_n892NotaFiscalParcelamentoValor ;
      private DateTime[] P00EC3_A893NotaFiscalParcelamentoVencimento ;
      private bool[] P00EC3_n893NotaFiscalParcelamentoVencimento ;
      private string[] P00EC3_A799NotaFiscalNumero ;
      private bool[] P00EC3_n799NotaFiscalNumero ;
      private Guid[] P00EC3_A890NotaFiscalParcelamentoID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class notafiscalparcelamentowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EC2( IGxContext context ,
                                             Guid A794NotaFiscalId ,
                                             GxSimpleCollection<Guid> AV41array_NotaFiscalId ,
                                             string AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel ,
                                             string AV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero ,
                                             string AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel ,
                                             string AV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero ,
                                             DateTime AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento ,
                                             DateTime AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to ,
                                             decimal AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor ,
                                             decimal AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to ,
                                             decimal AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa ,
                                             decimal AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to ,
                                             decimal AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual ,
                                             decimal AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to ,
                                             decimal AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido ,
                                             decimal AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to ,
                                             string A799NotaFiscalNumero ,
                                             string A891NotaFiscalParcelamentoNumero ,
                                             DateTime A893NotaFiscalParcelamentoVencimento ,
                                             decimal A892NotaFiscalParcelamentoValor ,
                                             decimal A895NotaFiscalParcelamentoValorTaxaAdministrativa ,
                                             decimal A896NotaFiscalParcelamentoValorTaxaAnual ,
                                             decimal A897NotaFiscalParcelamentoLiquido )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.NotaFiscalNumero, T1.NotaFiscalId, T1.NotaFiscalParcelamentoLiquido, T1.NotaFiscalParcelamentoValorTaxaAnual, T1.NotaFiscalParcelamentoValorTaxaAdministrativa, T1.NotaFiscalParcelamentoValor, T1.NotaFiscalParcelamentoVencimento, T1.NotaFiscalParcelamentoNumero, T1.NotaFiscalParcelamentoID FROM (NotaFiscalParcelamento T1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV41array_NotaFiscalId, "T1.NotaFiscalId IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero like :lV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero = ( :AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( StringUtil.StrCmp(AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T2.NotaFiscalNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoNumero like :lV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel)) && ! ( StringUtil.StrCmp(AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoNumero = ( :AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero))");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( StringUtil.StrCmp(AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoNumero IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalParcelamentoNumero))=0))");
         }
         if ( ! (DateTime.MinValue==AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoVencimento >= :AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencim)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoVencimento <= :AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencim)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValor >= :AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValor <= :AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAdministrativa >= :AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalort)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAdministrativa <= :AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAnual >= :AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAnual <= :AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoLiquido >= :AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliqui)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoLiquido <= :AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliqui)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.NotaFiscalNumero";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00EC3( IGxContext context ,
                                             Guid A794NotaFiscalId ,
                                             GxSimpleCollection<Guid> AV41array_NotaFiscalId ,
                                             string AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel ,
                                             string AV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero ,
                                             string AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel ,
                                             string AV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero ,
                                             DateTime AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento ,
                                             DateTime AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to ,
                                             decimal AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor ,
                                             decimal AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to ,
                                             decimal AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa ,
                                             decimal AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to ,
                                             decimal AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual ,
                                             decimal AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to ,
                                             decimal AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido ,
                                             decimal AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to ,
                                             string A799NotaFiscalNumero ,
                                             string A891NotaFiscalParcelamentoNumero ,
                                             DateTime A893NotaFiscalParcelamentoVencimento ,
                                             decimal A892NotaFiscalParcelamentoValor ,
                                             decimal A895NotaFiscalParcelamentoValorTaxaAdministrativa ,
                                             decimal A896NotaFiscalParcelamentoValorTaxaAnual ,
                                             decimal A897NotaFiscalParcelamentoLiquido )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.NotaFiscalParcelamentoNumero, T1.NotaFiscalId, T1.NotaFiscalParcelamentoLiquido, T1.NotaFiscalParcelamentoValorTaxaAnual, T1.NotaFiscalParcelamentoValorTaxaAdministrativa, T1.NotaFiscalParcelamentoValor, T1.NotaFiscalParcelamentoVencimento, T2.NotaFiscalNumero, T1.NotaFiscalParcelamentoID FROM (NotaFiscalParcelamento T1 LEFT JOIN NotaFiscal T2 ON T2.NotaFiscalId = T1.NotaFiscalId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV41array_NotaFiscalId, "T1.NotaFiscalId IN (", ")")+")");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero)) ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero like :lV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel)) && ! ( StringUtil.StrCmp(AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero = ( :AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel))");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( StringUtil.StrCmp(AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.NotaFiscalNumero IS NULL or (char_length(trim(trailing ' ' from T2.NotaFiscalNumero))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero)) ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoNumero like :lV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel)) && ! ( StringUtil.StrCmp(AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoNumero = ( :AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero))");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( StringUtil.StrCmp(AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoNumero IS NULL or (char_length(trim(trailing ' ' from T1.NotaFiscalParcelamentoNumero))=0))");
         }
         if ( ! (DateTime.MinValue==AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencimento) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoVencimento >= :AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencim)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencimento_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoVencimento <= :AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencim)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValor >= :AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValor <= :AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalortaxaadministrativa) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAdministrativa >= :AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalort)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalortaxaadministrativa_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAdministrativa <= :AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalortaxaanual) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAnual >= :AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalortaxaanual_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoValorTaxaAnual <= :AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalor)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliquido) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoLiquido >= :AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliqui)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliquido_to) )
         {
            AddWhere(sWhereString, "(T1.NotaFiscalParcelamentoLiquido <= :AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliqui)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.NotaFiscalParcelamentoNumero";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00EC2(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] );
               case 1 :
                     return conditional_P00EC3(context, (Guid)dynConstraints[0] , (GxSimpleCollection<Guid>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (decimal)dynConstraints[10] , (decimal)dynConstraints[11] , (decimal)dynConstraints[12] , (decimal)dynConstraints[13] , (decimal)dynConstraints[14] , (decimal)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (DateTime)dynConstraints[18] , (decimal)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00EC2;
          prmP00EC2 = new Object[] {
          new ParDef("lV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel",GXType.VarChar,40,0) ,
          new ParDef("lV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero",GXType.VarChar,100,0) ,
          new ParDef("AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero",GXType.VarChar,100,0) ,
          new ParDef("AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencim",GXType.Date,8,0) ,
          new ParDef("AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencim",GXType.Date,8,0) ,
          new ParDef("AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_",GXType.Number,18,2) ,
          new ParDef("AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalort",GXType.Number,18,2) ,
          new ParDef("AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliqui",GXType.Number,18,2) ,
          new ParDef("AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliqui",GXType.Number,18,2)
          };
          Object[] prmP00EC3;
          prmP00EC3 = new Object[] {
          new ParDef("lV50Notafiscalparcelamentowwds_1_tfnotafiscalnumero",GXType.VarChar,40,0) ,
          new ParDef("AV51Notafiscalparcelamentowwds_2_tfnotafiscalnumero_sel",GXType.VarChar,40,0) ,
          new ParDef("lV52Notafiscalparcelamentowwds_3_tfnotafiscalparcelamentonumero",GXType.VarChar,100,0) ,
          new ParDef("AV53Notafiscalparcelamentowwds_4_tfnotafiscalparcelamentonumero",GXType.VarChar,100,0) ,
          new ParDef("AV54Notafiscalparcelamentowwds_5_tfnotafiscalparcelamentovencim",GXType.Date,8,0) ,
          new ParDef("AV55Notafiscalparcelamentowwds_6_tfnotafiscalparcelamentovencim",GXType.Date,8,0) ,
          new ParDef("AV56Notafiscalparcelamentowwds_7_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV57Notafiscalparcelamentowwds_8_tfnotafiscalparcelamentovalor_",GXType.Number,18,2) ,
          new ParDef("AV58Notafiscalparcelamentowwds_9_tfnotafiscalparcelamentovalort",GXType.Number,18,2) ,
          new ParDef("AV59Notafiscalparcelamentowwds_10_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV60Notafiscalparcelamentowwds_11_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV61Notafiscalparcelamentowwds_12_tfnotafiscalparcelamentovalor",GXType.Number,18,2) ,
          new ParDef("AV62Notafiscalparcelamentowwds_13_tfnotafiscalparcelamentoliqui",GXType.Number,18,2) ,
          new ParDef("AV63Notafiscalparcelamentowwds_14_tfnotafiscalparcelamentoliqui",GXType.Number,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P00EC2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EC2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EC3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EC3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((Guid[]) buf[16])[0] = rslt.getGuid(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((Guid[]) buf[2])[0] = rslt.getGuid(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((Guid[]) buf[16])[0] = rslt.getGuid(9);
                return;
       }
    }

 }

}
