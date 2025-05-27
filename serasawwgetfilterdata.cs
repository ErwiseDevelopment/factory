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
   public class serasawwgetfilterdata : GXProcedure
   {
      public serasawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasawwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_CLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIENTERAZAOSOCIALOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_SERASANUMEROPROPOSTA") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASANUMEROPROPOSTAOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_SERASATIPOVENDA") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASATIPOVENDAOPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV29Session.Get("SerasaWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SerasaWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("SerasaWWGridState"), null, "", "");
         }
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV57GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV40FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL") == 0 )
            {
               AV52TFClienteRazaoSocial = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV53TFClienteRazaoSocial_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERASANUMEROPROPOSTA") == 0 )
            {
               AV10TFSerasaNumeroProposta = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERASANUMEROPROPOSTA_SEL") == 0 )
            {
               AV11TFSerasaNumeroProposta_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERASAPOLITICA") == 0 )
            {
               AV12TFSerasaPolitica = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, ".");
               AV13TFSerasaPolitica_To = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERASACREATEDAT") == 0 )
            {
               AV14TFSerasaCreatedAt = context.localUtil.CToT( AV32GridStateFilterValue.gxTpr_Value, 4);
               AV15TFSerasaCreatedAt_To = context.localUtil.CToT( AV32GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERASATIPOVENDA") == 0 )
            {
               AV16TFSerasaTipoVenda = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERASATIPOVENDA_SEL") == 0 )
            {
               AV17TFSerasaTipoVenda_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTESIDS") == 0 )
            {
               AV54ClientesIds = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "PARM_&PROPOSTAID") == 0 )
            {
               AV55PropostaId = (int)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV57GXV1 = (int)(AV57GXV1+1);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV41DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "SERASANUMEROPROPOSTA") == 0 )
            {
               AV42DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV43SerasaNumeroProposta1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "SERASANUMEROPROPOSTA") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV47SerasaNumeroProposta2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV48DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV49DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV49DynamicFiltersSelector3, "SERASANUMEROPROPOSTA") == 0 )
                  {
                     AV50DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV51SerasaNumeroProposta3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV52TFClienteRazaoSocial = AV18SearchTxt;
         AV53TFClienteRazaoSocial_Sel = "";
         AV59Serasawwds_1_filterfulltext = AV40FilterFullText;
         AV60Serasawwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV61Serasawwds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV62Serasawwds_4_serasanumeroproposta1 = AV43SerasaNumeroProposta1;
         AV63Serasawwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV64Serasawwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV65Serasawwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV66Serasawwds_8_serasanumeroproposta2 = AV47SerasaNumeroProposta2;
         AV67Serasawwds_9_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV68Serasawwds_10_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV69Serasawwds_11_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV70Serasawwds_12_serasanumeroproposta3 = AV51SerasaNumeroProposta3;
         AV71Serasawwds_13_tfclienterazaosocial = AV52TFClienteRazaoSocial;
         AV72Serasawwds_14_tfclienterazaosocial_sel = AV53TFClienteRazaoSocial_Sel;
         AV73Serasawwds_15_tfserasanumeroproposta = AV10TFSerasaNumeroProposta;
         AV74Serasawwds_16_tfserasanumeroproposta_sel = AV11TFSerasaNumeroProposta_Sel;
         AV75Serasawwds_17_tfserasapolitica = AV12TFSerasaPolitica;
         AV76Serasawwds_18_tfserasapolitica_to = AV13TFSerasaPolitica_To;
         AV77Serasawwds_19_tfserasacreatedat = AV14TFSerasaCreatedAt;
         AV78Serasawwds_20_tfserasacreatedat_to = AV15TFSerasaCreatedAt_To;
         AV79Serasawwds_21_tfserasatipovenda = AV16TFSerasaTipoVenda;
         AV80Serasawwds_22_tfserasatipovenda_sel = AV17TFSerasaTipoVenda_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A168ClienteId ,
                                              AV56Array_ClienteId ,
                                              AV59Serasawwds_1_filterfulltext ,
                                              AV60Serasawwds_2_dynamicfiltersselector1 ,
                                              AV61Serasawwds_3_dynamicfiltersoperator1 ,
                                              AV62Serasawwds_4_serasanumeroproposta1 ,
                                              AV63Serasawwds_5_dynamicfiltersenabled2 ,
                                              AV64Serasawwds_6_dynamicfiltersselector2 ,
                                              AV65Serasawwds_7_dynamicfiltersoperator2 ,
                                              AV66Serasawwds_8_serasanumeroproposta2 ,
                                              AV67Serasawwds_9_dynamicfiltersenabled3 ,
                                              AV68Serasawwds_10_dynamicfiltersselector3 ,
                                              AV69Serasawwds_11_dynamicfiltersoperator3 ,
                                              AV70Serasawwds_12_serasanumeroproposta3 ,
                                              AV72Serasawwds_14_tfclienterazaosocial_sel ,
                                              AV71Serasawwds_13_tfclienterazaosocial ,
                                              AV74Serasawwds_16_tfserasanumeroproposta_sel ,
                                              AV73Serasawwds_15_tfserasanumeroproposta ,
                                              AV75Serasawwds_17_tfserasapolitica ,
                                              AV76Serasawwds_18_tfserasapolitica_to ,
                                              AV77Serasawwds_19_tfserasacreatedat ,
                                              AV78Serasawwds_20_tfserasacreatedat_to ,
                                              AV80Serasawwds_22_tfserasatipovenda_sel ,
                                              AV79Serasawwds_21_tfserasatipovenda ,
                                              A170ClienteRazaoSocial ,
                                              A663SerasaNumeroProposta ,
                                              A664SerasaPolitica ,
                                              A666SerasaTipoVenda ,
                                              A665SerasaCreatedAt } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV59Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Serasawwds_1_filterfulltext), "%", "");
         lV59Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Serasawwds_1_filterfulltext), "%", "");
         lV59Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Serasawwds_1_filterfulltext), "%", "");
         lV59Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Serasawwds_1_filterfulltext), "%", "");
         lV62Serasawwds_4_serasanumeroproposta1 = StringUtil.Concat( StringUtil.RTrim( AV62Serasawwds_4_serasanumeroproposta1), "%", "");
         lV62Serasawwds_4_serasanumeroproposta1 = StringUtil.Concat( StringUtil.RTrim( AV62Serasawwds_4_serasanumeroproposta1), "%", "");
         lV66Serasawwds_8_serasanumeroproposta2 = StringUtil.Concat( StringUtil.RTrim( AV66Serasawwds_8_serasanumeroproposta2), "%", "");
         lV66Serasawwds_8_serasanumeroproposta2 = StringUtil.Concat( StringUtil.RTrim( AV66Serasawwds_8_serasanumeroproposta2), "%", "");
         lV70Serasawwds_12_serasanumeroproposta3 = StringUtil.Concat( StringUtil.RTrim( AV70Serasawwds_12_serasanumeroproposta3), "%", "");
         lV70Serasawwds_12_serasanumeroproposta3 = StringUtil.Concat( StringUtil.RTrim( AV70Serasawwds_12_serasanumeroproposta3), "%", "");
         lV71Serasawwds_13_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV71Serasawwds_13_tfclienterazaosocial), "%", "");
         lV73Serasawwds_15_tfserasanumeroproposta = StringUtil.Concat( StringUtil.RTrim( AV73Serasawwds_15_tfserasanumeroproposta), "%", "");
         lV79Serasawwds_21_tfserasatipovenda = StringUtil.Concat( StringUtil.RTrim( AV79Serasawwds_21_tfserasatipovenda), "%", "");
         /* Using cursor P00CK2 */
         pr_default.execute(0, new Object[] {lV59Serasawwds_1_filterfulltext, lV59Serasawwds_1_filterfulltext, lV59Serasawwds_1_filterfulltext, lV59Serasawwds_1_filterfulltext, lV62Serasawwds_4_serasanumeroproposta1, lV62Serasawwds_4_serasanumeroproposta1, lV66Serasawwds_8_serasanumeroproposta2, lV66Serasawwds_8_serasanumeroproposta2, lV70Serasawwds_12_serasanumeroproposta3, lV70Serasawwds_12_serasanumeroproposta3, lV71Serasawwds_13_tfclienterazaosocial, AV72Serasawwds_14_tfclienterazaosocial_sel, lV73Serasawwds_15_tfserasanumeroproposta, AV74Serasawwds_16_tfserasanumeroproposta_sel, AV75Serasawwds_17_tfserasapolitica, AV76Serasawwds_18_tfserasapolitica_to, AV77Serasawwds_19_tfserasacreatedat, AV78Serasawwds_20_tfserasacreatedat_to, lV79Serasawwds_21_tfserasatipovenda, AV80Serasawwds_22_tfserasatipovenda_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKCK2 = false;
            A170ClienteRazaoSocial = P00CK2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00CK2_n170ClienteRazaoSocial[0];
            A168ClienteId = P00CK2_A168ClienteId[0];
            n168ClienteId = P00CK2_n168ClienteId[0];
            A665SerasaCreatedAt = P00CK2_A665SerasaCreatedAt[0];
            n665SerasaCreatedAt = P00CK2_n665SerasaCreatedAt[0];
            A664SerasaPolitica = P00CK2_A664SerasaPolitica[0];
            n664SerasaPolitica = P00CK2_n664SerasaPolitica[0];
            A666SerasaTipoVenda = P00CK2_A666SerasaTipoVenda[0];
            n666SerasaTipoVenda = P00CK2_n666SerasaTipoVenda[0];
            A663SerasaNumeroProposta = P00CK2_A663SerasaNumeroProposta[0];
            n663SerasaNumeroProposta = P00CK2_n663SerasaNumeroProposta[0];
            A662SerasaId = P00CK2_A662SerasaId[0];
            A170ClienteRazaoSocial = P00CK2_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00CK2_n170ClienteRazaoSocial[0];
            AV28count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00CK2_A170ClienteRazaoSocial[0], A170ClienteRazaoSocial) == 0 ) )
            {
               BRKCK2 = false;
               A168ClienteId = P00CK2_A168ClienteId[0];
               n168ClienteId = P00CK2_n168ClienteId[0];
               A662SerasaId = P00CK2_A662SerasaId[0];
               if ( (AV56Array_ClienteId.IndexOf(A168ClienteId)>0) )
               {
                  AV28count = (long)(AV28count+1);
               }
               BRKCK2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ClienteRazaoSocial)) ? "<#Empty#>" : A170ClienteRazaoSocial);
               AV25OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A170ClienteRazaoSocial, "@!")));
               AV24Options.Add(AV23Option, 0);
               AV26OptionsDesc.Add(AV25OptionDesc, 0);
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
            if ( ! BRKCK2 )
            {
               BRKCK2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSERASANUMEROPROPOSTAOPTIONS' Routine */
         returnInSub = false;
         AV10TFSerasaNumeroProposta = AV18SearchTxt;
         AV11TFSerasaNumeroProposta_Sel = "";
         AV59Serasawwds_1_filterfulltext = AV40FilterFullText;
         AV60Serasawwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV61Serasawwds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV62Serasawwds_4_serasanumeroproposta1 = AV43SerasaNumeroProposta1;
         AV63Serasawwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV64Serasawwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV65Serasawwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV66Serasawwds_8_serasanumeroproposta2 = AV47SerasaNumeroProposta2;
         AV67Serasawwds_9_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV68Serasawwds_10_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV69Serasawwds_11_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV70Serasawwds_12_serasanumeroproposta3 = AV51SerasaNumeroProposta3;
         AV71Serasawwds_13_tfclienterazaosocial = AV52TFClienteRazaoSocial;
         AV72Serasawwds_14_tfclienterazaosocial_sel = AV53TFClienteRazaoSocial_Sel;
         AV73Serasawwds_15_tfserasanumeroproposta = AV10TFSerasaNumeroProposta;
         AV74Serasawwds_16_tfserasanumeroproposta_sel = AV11TFSerasaNumeroProposta_Sel;
         AV75Serasawwds_17_tfserasapolitica = AV12TFSerasaPolitica;
         AV76Serasawwds_18_tfserasapolitica_to = AV13TFSerasaPolitica_To;
         AV77Serasawwds_19_tfserasacreatedat = AV14TFSerasaCreatedAt;
         AV78Serasawwds_20_tfserasacreatedat_to = AV15TFSerasaCreatedAt_To;
         AV79Serasawwds_21_tfserasatipovenda = AV16TFSerasaTipoVenda;
         AV80Serasawwds_22_tfserasatipovenda_sel = AV17TFSerasaTipoVenda_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A168ClienteId ,
                                              AV56Array_ClienteId ,
                                              AV59Serasawwds_1_filterfulltext ,
                                              AV60Serasawwds_2_dynamicfiltersselector1 ,
                                              AV61Serasawwds_3_dynamicfiltersoperator1 ,
                                              AV62Serasawwds_4_serasanumeroproposta1 ,
                                              AV63Serasawwds_5_dynamicfiltersenabled2 ,
                                              AV64Serasawwds_6_dynamicfiltersselector2 ,
                                              AV65Serasawwds_7_dynamicfiltersoperator2 ,
                                              AV66Serasawwds_8_serasanumeroproposta2 ,
                                              AV67Serasawwds_9_dynamicfiltersenabled3 ,
                                              AV68Serasawwds_10_dynamicfiltersselector3 ,
                                              AV69Serasawwds_11_dynamicfiltersoperator3 ,
                                              AV70Serasawwds_12_serasanumeroproposta3 ,
                                              AV72Serasawwds_14_tfclienterazaosocial_sel ,
                                              AV71Serasawwds_13_tfclienterazaosocial ,
                                              AV74Serasawwds_16_tfserasanumeroproposta_sel ,
                                              AV73Serasawwds_15_tfserasanumeroproposta ,
                                              AV75Serasawwds_17_tfserasapolitica ,
                                              AV76Serasawwds_18_tfserasapolitica_to ,
                                              AV77Serasawwds_19_tfserasacreatedat ,
                                              AV78Serasawwds_20_tfserasacreatedat_to ,
                                              AV80Serasawwds_22_tfserasatipovenda_sel ,
                                              AV79Serasawwds_21_tfserasatipovenda ,
                                              A170ClienteRazaoSocial ,
                                              A663SerasaNumeroProposta ,
                                              A664SerasaPolitica ,
                                              A666SerasaTipoVenda ,
                                              A665SerasaCreatedAt } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV59Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Serasawwds_1_filterfulltext), "%", "");
         lV59Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Serasawwds_1_filterfulltext), "%", "");
         lV59Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Serasawwds_1_filterfulltext), "%", "");
         lV59Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Serasawwds_1_filterfulltext), "%", "");
         lV62Serasawwds_4_serasanumeroproposta1 = StringUtil.Concat( StringUtil.RTrim( AV62Serasawwds_4_serasanumeroproposta1), "%", "");
         lV62Serasawwds_4_serasanumeroproposta1 = StringUtil.Concat( StringUtil.RTrim( AV62Serasawwds_4_serasanumeroproposta1), "%", "");
         lV66Serasawwds_8_serasanumeroproposta2 = StringUtil.Concat( StringUtil.RTrim( AV66Serasawwds_8_serasanumeroproposta2), "%", "");
         lV66Serasawwds_8_serasanumeroproposta2 = StringUtil.Concat( StringUtil.RTrim( AV66Serasawwds_8_serasanumeroproposta2), "%", "");
         lV70Serasawwds_12_serasanumeroproposta3 = StringUtil.Concat( StringUtil.RTrim( AV70Serasawwds_12_serasanumeroproposta3), "%", "");
         lV70Serasawwds_12_serasanumeroproposta3 = StringUtil.Concat( StringUtil.RTrim( AV70Serasawwds_12_serasanumeroproposta3), "%", "");
         lV71Serasawwds_13_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV71Serasawwds_13_tfclienterazaosocial), "%", "");
         lV73Serasawwds_15_tfserasanumeroproposta = StringUtil.Concat( StringUtil.RTrim( AV73Serasawwds_15_tfserasanumeroproposta), "%", "");
         lV79Serasawwds_21_tfserasatipovenda = StringUtil.Concat( StringUtil.RTrim( AV79Serasawwds_21_tfserasatipovenda), "%", "");
         /* Using cursor P00CK3 */
         pr_default.execute(1, new Object[] {lV59Serasawwds_1_filterfulltext, lV59Serasawwds_1_filterfulltext, lV59Serasawwds_1_filterfulltext, lV59Serasawwds_1_filterfulltext, lV62Serasawwds_4_serasanumeroproposta1, lV62Serasawwds_4_serasanumeroproposta1, lV66Serasawwds_8_serasanumeroproposta2, lV66Serasawwds_8_serasanumeroproposta2, lV70Serasawwds_12_serasanumeroproposta3, lV70Serasawwds_12_serasanumeroproposta3, lV71Serasawwds_13_tfclienterazaosocial, AV72Serasawwds_14_tfclienterazaosocial_sel, lV73Serasawwds_15_tfserasanumeroproposta, AV74Serasawwds_16_tfserasanumeroproposta_sel, AV75Serasawwds_17_tfserasapolitica, AV76Serasawwds_18_tfserasapolitica_to, AV77Serasawwds_19_tfserasacreatedat, AV78Serasawwds_20_tfserasacreatedat_to, lV79Serasawwds_21_tfserasatipovenda, AV80Serasawwds_22_tfserasatipovenda_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKCK4 = false;
            A663SerasaNumeroProposta = P00CK3_A663SerasaNumeroProposta[0];
            n663SerasaNumeroProposta = P00CK3_n663SerasaNumeroProposta[0];
            A168ClienteId = P00CK3_A168ClienteId[0];
            n168ClienteId = P00CK3_n168ClienteId[0];
            A665SerasaCreatedAt = P00CK3_A665SerasaCreatedAt[0];
            n665SerasaCreatedAt = P00CK3_n665SerasaCreatedAt[0];
            A664SerasaPolitica = P00CK3_A664SerasaPolitica[0];
            n664SerasaPolitica = P00CK3_n664SerasaPolitica[0];
            A666SerasaTipoVenda = P00CK3_A666SerasaTipoVenda[0];
            n666SerasaTipoVenda = P00CK3_n666SerasaTipoVenda[0];
            A170ClienteRazaoSocial = P00CK3_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00CK3_n170ClienteRazaoSocial[0];
            A662SerasaId = P00CK3_A662SerasaId[0];
            A170ClienteRazaoSocial = P00CK3_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00CK3_n170ClienteRazaoSocial[0];
            AV28count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00CK3_A663SerasaNumeroProposta[0], A663SerasaNumeroProposta) == 0 ) )
            {
               BRKCK4 = false;
               A662SerasaId = P00CK3_A662SerasaId[0];
               AV28count = (long)(AV28count+1);
               BRKCK4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A663SerasaNumeroProposta)) ? "<#Empty#>" : A663SerasaNumeroProposta);
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
            if ( ! BRKCK4 )
            {
               BRKCK4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSERASATIPOVENDAOPTIONS' Routine */
         returnInSub = false;
         AV16TFSerasaTipoVenda = AV18SearchTxt;
         AV17TFSerasaTipoVenda_Sel = "";
         AV59Serasawwds_1_filterfulltext = AV40FilterFullText;
         AV60Serasawwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV61Serasawwds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV62Serasawwds_4_serasanumeroproposta1 = AV43SerasaNumeroProposta1;
         AV63Serasawwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV64Serasawwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV65Serasawwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV66Serasawwds_8_serasanumeroproposta2 = AV47SerasaNumeroProposta2;
         AV67Serasawwds_9_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV68Serasawwds_10_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV69Serasawwds_11_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV70Serasawwds_12_serasanumeroproposta3 = AV51SerasaNumeroProposta3;
         AV71Serasawwds_13_tfclienterazaosocial = AV52TFClienteRazaoSocial;
         AV72Serasawwds_14_tfclienterazaosocial_sel = AV53TFClienteRazaoSocial_Sel;
         AV73Serasawwds_15_tfserasanumeroproposta = AV10TFSerasaNumeroProposta;
         AV74Serasawwds_16_tfserasanumeroproposta_sel = AV11TFSerasaNumeroProposta_Sel;
         AV75Serasawwds_17_tfserasapolitica = AV12TFSerasaPolitica;
         AV76Serasawwds_18_tfserasapolitica_to = AV13TFSerasaPolitica_To;
         AV77Serasawwds_19_tfserasacreatedat = AV14TFSerasaCreatedAt;
         AV78Serasawwds_20_tfserasacreatedat_to = AV15TFSerasaCreatedAt_To;
         AV79Serasawwds_21_tfserasatipovenda = AV16TFSerasaTipoVenda;
         AV80Serasawwds_22_tfserasatipovenda_sel = AV17TFSerasaTipoVenda_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A168ClienteId ,
                                              AV56Array_ClienteId ,
                                              AV59Serasawwds_1_filterfulltext ,
                                              AV60Serasawwds_2_dynamicfiltersselector1 ,
                                              AV61Serasawwds_3_dynamicfiltersoperator1 ,
                                              AV62Serasawwds_4_serasanumeroproposta1 ,
                                              AV63Serasawwds_5_dynamicfiltersenabled2 ,
                                              AV64Serasawwds_6_dynamicfiltersselector2 ,
                                              AV65Serasawwds_7_dynamicfiltersoperator2 ,
                                              AV66Serasawwds_8_serasanumeroproposta2 ,
                                              AV67Serasawwds_9_dynamicfiltersenabled3 ,
                                              AV68Serasawwds_10_dynamicfiltersselector3 ,
                                              AV69Serasawwds_11_dynamicfiltersoperator3 ,
                                              AV70Serasawwds_12_serasanumeroproposta3 ,
                                              AV72Serasawwds_14_tfclienterazaosocial_sel ,
                                              AV71Serasawwds_13_tfclienterazaosocial ,
                                              AV74Serasawwds_16_tfserasanumeroproposta_sel ,
                                              AV73Serasawwds_15_tfserasanumeroproposta ,
                                              AV75Serasawwds_17_tfserasapolitica ,
                                              AV76Serasawwds_18_tfserasapolitica_to ,
                                              AV77Serasawwds_19_tfserasacreatedat ,
                                              AV78Serasawwds_20_tfserasacreatedat_to ,
                                              AV80Serasawwds_22_tfserasatipovenda_sel ,
                                              AV79Serasawwds_21_tfserasatipovenda ,
                                              A170ClienteRazaoSocial ,
                                              A663SerasaNumeroProposta ,
                                              A664SerasaPolitica ,
                                              A666SerasaTipoVenda ,
                                              A665SerasaCreatedAt } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN
                                              }
         });
         lV59Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Serasawwds_1_filterfulltext), "%", "");
         lV59Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Serasawwds_1_filterfulltext), "%", "");
         lV59Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Serasawwds_1_filterfulltext), "%", "");
         lV59Serasawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV59Serasawwds_1_filterfulltext), "%", "");
         lV62Serasawwds_4_serasanumeroproposta1 = StringUtil.Concat( StringUtil.RTrim( AV62Serasawwds_4_serasanumeroproposta1), "%", "");
         lV62Serasawwds_4_serasanumeroproposta1 = StringUtil.Concat( StringUtil.RTrim( AV62Serasawwds_4_serasanumeroproposta1), "%", "");
         lV66Serasawwds_8_serasanumeroproposta2 = StringUtil.Concat( StringUtil.RTrim( AV66Serasawwds_8_serasanumeroproposta2), "%", "");
         lV66Serasawwds_8_serasanumeroproposta2 = StringUtil.Concat( StringUtil.RTrim( AV66Serasawwds_8_serasanumeroproposta2), "%", "");
         lV70Serasawwds_12_serasanumeroproposta3 = StringUtil.Concat( StringUtil.RTrim( AV70Serasawwds_12_serasanumeroproposta3), "%", "");
         lV70Serasawwds_12_serasanumeroproposta3 = StringUtil.Concat( StringUtil.RTrim( AV70Serasawwds_12_serasanumeroproposta3), "%", "");
         lV71Serasawwds_13_tfclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV71Serasawwds_13_tfclienterazaosocial), "%", "");
         lV73Serasawwds_15_tfserasanumeroproposta = StringUtil.Concat( StringUtil.RTrim( AV73Serasawwds_15_tfserasanumeroproposta), "%", "");
         lV79Serasawwds_21_tfserasatipovenda = StringUtil.Concat( StringUtil.RTrim( AV79Serasawwds_21_tfserasatipovenda), "%", "");
         /* Using cursor P00CK4 */
         pr_default.execute(2, new Object[] {lV59Serasawwds_1_filterfulltext, lV59Serasawwds_1_filterfulltext, lV59Serasawwds_1_filterfulltext, lV59Serasawwds_1_filterfulltext, lV62Serasawwds_4_serasanumeroproposta1, lV62Serasawwds_4_serasanumeroproposta1, lV66Serasawwds_8_serasanumeroproposta2, lV66Serasawwds_8_serasanumeroproposta2, lV70Serasawwds_12_serasanumeroproposta3, lV70Serasawwds_12_serasanumeroproposta3, lV71Serasawwds_13_tfclienterazaosocial, AV72Serasawwds_14_tfclienterazaosocial_sel, lV73Serasawwds_15_tfserasanumeroproposta, AV74Serasawwds_16_tfserasanumeroproposta_sel, AV75Serasawwds_17_tfserasapolitica, AV76Serasawwds_18_tfserasapolitica_to, AV77Serasawwds_19_tfserasacreatedat, AV78Serasawwds_20_tfserasacreatedat_to, lV79Serasawwds_21_tfserasatipovenda, AV80Serasawwds_22_tfserasatipovenda_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKCK6 = false;
            A666SerasaTipoVenda = P00CK4_A666SerasaTipoVenda[0];
            n666SerasaTipoVenda = P00CK4_n666SerasaTipoVenda[0];
            A168ClienteId = P00CK4_A168ClienteId[0];
            n168ClienteId = P00CK4_n168ClienteId[0];
            A665SerasaCreatedAt = P00CK4_A665SerasaCreatedAt[0];
            n665SerasaCreatedAt = P00CK4_n665SerasaCreatedAt[0];
            A664SerasaPolitica = P00CK4_A664SerasaPolitica[0];
            n664SerasaPolitica = P00CK4_n664SerasaPolitica[0];
            A663SerasaNumeroProposta = P00CK4_A663SerasaNumeroProposta[0];
            n663SerasaNumeroProposta = P00CK4_n663SerasaNumeroProposta[0];
            A170ClienteRazaoSocial = P00CK4_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00CK4_n170ClienteRazaoSocial[0];
            A662SerasaId = P00CK4_A662SerasaId[0];
            A170ClienteRazaoSocial = P00CK4_A170ClienteRazaoSocial[0];
            n170ClienteRazaoSocial = P00CK4_n170ClienteRazaoSocial[0];
            AV28count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00CK4_A666SerasaTipoVenda[0], A666SerasaTipoVenda) == 0 ) )
            {
               BRKCK6 = false;
               A662SerasaId = P00CK4_A662SerasaId[0];
               AV28count = (long)(AV28count+1);
               BRKCK6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A666SerasaTipoVenda)) ? "<#Empty#>" : A666SerasaTipoVenda);
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
            if ( ! BRKCK6 )
            {
               BRKCK6 = true;
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
         AV40FilterFullText = "";
         AV52TFClienteRazaoSocial = "";
         AV53TFClienteRazaoSocial_Sel = "";
         AV10TFSerasaNumeroProposta = "";
         AV11TFSerasaNumeroProposta_Sel = "";
         AV14TFSerasaCreatedAt = (DateTime)(DateTime.MinValue);
         AV15TFSerasaCreatedAt_To = (DateTime)(DateTime.MinValue);
         AV16TFSerasaTipoVenda = "";
         AV17TFSerasaTipoVenda_Sel = "";
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV41DynamicFiltersSelector1 = "";
         AV43SerasaNumeroProposta1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV47SerasaNumeroProposta2 = "";
         AV49DynamicFiltersSelector3 = "";
         AV51SerasaNumeroProposta3 = "";
         AV59Serasawwds_1_filterfulltext = "";
         AV60Serasawwds_2_dynamicfiltersselector1 = "";
         AV62Serasawwds_4_serasanumeroproposta1 = "";
         AV64Serasawwds_6_dynamicfiltersselector2 = "";
         AV66Serasawwds_8_serasanumeroproposta2 = "";
         AV68Serasawwds_10_dynamicfiltersselector3 = "";
         AV70Serasawwds_12_serasanumeroproposta3 = "";
         AV71Serasawwds_13_tfclienterazaosocial = "";
         AV72Serasawwds_14_tfclienterazaosocial_sel = "";
         AV73Serasawwds_15_tfserasanumeroproposta = "";
         AV74Serasawwds_16_tfserasanumeroproposta_sel = "";
         AV77Serasawwds_19_tfserasacreatedat = (DateTime)(DateTime.MinValue);
         AV78Serasawwds_20_tfserasacreatedat_to = (DateTime)(DateTime.MinValue);
         AV79Serasawwds_21_tfserasatipovenda = "";
         AV80Serasawwds_22_tfserasatipovenda_sel = "";
         lV59Serasawwds_1_filterfulltext = "";
         lV62Serasawwds_4_serasanumeroproposta1 = "";
         lV66Serasawwds_8_serasanumeroproposta2 = "";
         lV70Serasawwds_12_serasanumeroproposta3 = "";
         lV71Serasawwds_13_tfclienterazaosocial = "";
         lV73Serasawwds_15_tfserasanumeroproposta = "";
         lV79Serasawwds_21_tfserasatipovenda = "";
         AV56Array_ClienteId = new GxSimpleCollection<int>();
         A170ClienteRazaoSocial = "";
         A663SerasaNumeroProposta = "";
         A666SerasaTipoVenda = "";
         A665SerasaCreatedAt = (DateTime)(DateTime.MinValue);
         P00CK2_A170ClienteRazaoSocial = new string[] {""} ;
         P00CK2_n170ClienteRazaoSocial = new bool[] {false} ;
         P00CK2_A168ClienteId = new int[1] ;
         P00CK2_n168ClienteId = new bool[] {false} ;
         P00CK2_A665SerasaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00CK2_n665SerasaCreatedAt = new bool[] {false} ;
         P00CK2_A664SerasaPolitica = new decimal[1] ;
         P00CK2_n664SerasaPolitica = new bool[] {false} ;
         P00CK2_A666SerasaTipoVenda = new string[] {""} ;
         P00CK2_n666SerasaTipoVenda = new bool[] {false} ;
         P00CK2_A663SerasaNumeroProposta = new string[] {""} ;
         P00CK2_n663SerasaNumeroProposta = new bool[] {false} ;
         P00CK2_A662SerasaId = new int[1] ;
         AV23Option = "";
         AV25OptionDesc = "";
         P00CK3_A663SerasaNumeroProposta = new string[] {""} ;
         P00CK3_n663SerasaNumeroProposta = new bool[] {false} ;
         P00CK3_A168ClienteId = new int[1] ;
         P00CK3_n168ClienteId = new bool[] {false} ;
         P00CK3_A665SerasaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00CK3_n665SerasaCreatedAt = new bool[] {false} ;
         P00CK3_A664SerasaPolitica = new decimal[1] ;
         P00CK3_n664SerasaPolitica = new bool[] {false} ;
         P00CK3_A666SerasaTipoVenda = new string[] {""} ;
         P00CK3_n666SerasaTipoVenda = new bool[] {false} ;
         P00CK3_A170ClienteRazaoSocial = new string[] {""} ;
         P00CK3_n170ClienteRazaoSocial = new bool[] {false} ;
         P00CK3_A662SerasaId = new int[1] ;
         P00CK4_A666SerasaTipoVenda = new string[] {""} ;
         P00CK4_n666SerasaTipoVenda = new bool[] {false} ;
         P00CK4_A168ClienteId = new int[1] ;
         P00CK4_n168ClienteId = new bool[] {false} ;
         P00CK4_A665SerasaCreatedAt = new DateTime[] {DateTime.MinValue} ;
         P00CK4_n665SerasaCreatedAt = new bool[] {false} ;
         P00CK4_A664SerasaPolitica = new decimal[1] ;
         P00CK4_n664SerasaPolitica = new bool[] {false} ;
         P00CK4_A663SerasaNumeroProposta = new string[] {""} ;
         P00CK4_n663SerasaNumeroProposta = new bool[] {false} ;
         P00CK4_A170ClienteRazaoSocial = new string[] {""} ;
         P00CK4_n170ClienteRazaoSocial = new bool[] {false} ;
         P00CK4_A662SerasaId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00CK2_A170ClienteRazaoSocial, P00CK2_n170ClienteRazaoSocial, P00CK2_A168ClienteId, P00CK2_n168ClienteId, P00CK2_A665SerasaCreatedAt, P00CK2_n665SerasaCreatedAt, P00CK2_A664SerasaPolitica, P00CK2_n664SerasaPolitica, P00CK2_A666SerasaTipoVenda, P00CK2_n666SerasaTipoVenda,
               P00CK2_A663SerasaNumeroProposta, P00CK2_n663SerasaNumeroProposta, P00CK2_A662SerasaId
               }
               , new Object[] {
               P00CK3_A663SerasaNumeroProposta, P00CK3_n663SerasaNumeroProposta, P00CK3_A168ClienteId, P00CK3_n168ClienteId, P00CK3_A665SerasaCreatedAt, P00CK3_n665SerasaCreatedAt, P00CK3_A664SerasaPolitica, P00CK3_n664SerasaPolitica, P00CK3_A666SerasaTipoVenda, P00CK3_n666SerasaTipoVenda,
               P00CK3_A170ClienteRazaoSocial, P00CK3_n170ClienteRazaoSocial, P00CK3_A662SerasaId
               }
               , new Object[] {
               P00CK4_A666SerasaTipoVenda, P00CK4_n666SerasaTipoVenda, P00CK4_A168ClienteId, P00CK4_n168ClienteId, P00CK4_A665SerasaCreatedAt, P00CK4_n665SerasaCreatedAt, P00CK4_A664SerasaPolitica, P00CK4_n664SerasaPolitica, P00CK4_A663SerasaNumeroProposta, P00CK4_n663SerasaNumeroProposta,
               P00CK4_A170ClienteRazaoSocial, P00CK4_n170ClienteRazaoSocial, P00CK4_A662SerasaId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21MaxItems ;
      private short AV20PageIndex ;
      private short AV19SkipItems ;
      private short AV54ClientesIds ;
      private short AV42DynamicFiltersOperator1 ;
      private short AV46DynamicFiltersOperator2 ;
      private short AV50DynamicFiltersOperator3 ;
      private short AV61Serasawwds_3_dynamicfiltersoperator1 ;
      private short AV65Serasawwds_7_dynamicfiltersoperator2 ;
      private short AV69Serasawwds_11_dynamicfiltersoperator3 ;
      private int AV57GXV1 ;
      private int AV55PropostaId ;
      private int A168ClienteId ;
      private int A662SerasaId ;
      private long AV28count ;
      private decimal AV12TFSerasaPolitica ;
      private decimal AV13TFSerasaPolitica_To ;
      private decimal AV75Serasawwds_17_tfserasapolitica ;
      private decimal AV76Serasawwds_18_tfserasapolitica_to ;
      private decimal A664SerasaPolitica ;
      private DateTime AV14TFSerasaCreatedAt ;
      private DateTime AV15TFSerasaCreatedAt_To ;
      private DateTime AV77Serasawwds_19_tfserasacreatedat ;
      private DateTime AV78Serasawwds_20_tfserasacreatedat_to ;
      private DateTime A665SerasaCreatedAt ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV48DynamicFiltersEnabled3 ;
      private bool AV63Serasawwds_5_dynamicfiltersenabled2 ;
      private bool AV67Serasawwds_9_dynamicfiltersenabled3 ;
      private bool BRKCK2 ;
      private bool n170ClienteRazaoSocial ;
      private bool n168ClienteId ;
      private bool n665SerasaCreatedAt ;
      private bool n664SerasaPolitica ;
      private bool n666SerasaTipoVenda ;
      private bool n663SerasaNumeroProposta ;
      private bool BRKCK4 ;
      private bool BRKCK6 ;
      private string AV37OptionsJson ;
      private string AV38OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV34DDOName ;
      private string AV35SearchTxtParms ;
      private string AV36SearchTxtTo ;
      private string AV18SearchTxt ;
      private string AV40FilterFullText ;
      private string AV52TFClienteRazaoSocial ;
      private string AV53TFClienteRazaoSocial_Sel ;
      private string AV10TFSerasaNumeroProposta ;
      private string AV11TFSerasaNumeroProposta_Sel ;
      private string AV16TFSerasaTipoVenda ;
      private string AV17TFSerasaTipoVenda_Sel ;
      private string AV41DynamicFiltersSelector1 ;
      private string AV43SerasaNumeroProposta1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV47SerasaNumeroProposta2 ;
      private string AV49DynamicFiltersSelector3 ;
      private string AV51SerasaNumeroProposta3 ;
      private string AV59Serasawwds_1_filterfulltext ;
      private string AV60Serasawwds_2_dynamicfiltersselector1 ;
      private string AV62Serasawwds_4_serasanumeroproposta1 ;
      private string AV64Serasawwds_6_dynamicfiltersselector2 ;
      private string AV66Serasawwds_8_serasanumeroproposta2 ;
      private string AV68Serasawwds_10_dynamicfiltersselector3 ;
      private string AV70Serasawwds_12_serasanumeroproposta3 ;
      private string AV71Serasawwds_13_tfclienterazaosocial ;
      private string AV72Serasawwds_14_tfclienterazaosocial_sel ;
      private string AV73Serasawwds_15_tfserasanumeroproposta ;
      private string AV74Serasawwds_16_tfserasanumeroproposta_sel ;
      private string AV79Serasawwds_21_tfserasatipovenda ;
      private string AV80Serasawwds_22_tfserasatipovenda_sel ;
      private string lV59Serasawwds_1_filterfulltext ;
      private string lV62Serasawwds_4_serasanumeroproposta1 ;
      private string lV66Serasawwds_8_serasanumeroproposta2 ;
      private string lV70Serasawwds_12_serasanumeroproposta3 ;
      private string lV71Serasawwds_13_tfclienterazaosocial ;
      private string lV73Serasawwds_15_tfserasanumeroproposta ;
      private string lV79Serasawwds_21_tfserasatipovenda ;
      private string A170ClienteRazaoSocial ;
      private string A663SerasaNumeroProposta ;
      private string A666SerasaTipoVenda ;
      private string AV23Option ;
      private string AV25OptionDesc ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
      private GxSimpleCollection<int> AV56Array_ClienteId ;
      private IDataStoreProvider pr_default ;
      private string[] P00CK2_A170ClienteRazaoSocial ;
      private bool[] P00CK2_n170ClienteRazaoSocial ;
      private int[] P00CK2_A168ClienteId ;
      private bool[] P00CK2_n168ClienteId ;
      private DateTime[] P00CK2_A665SerasaCreatedAt ;
      private bool[] P00CK2_n665SerasaCreatedAt ;
      private decimal[] P00CK2_A664SerasaPolitica ;
      private bool[] P00CK2_n664SerasaPolitica ;
      private string[] P00CK2_A666SerasaTipoVenda ;
      private bool[] P00CK2_n666SerasaTipoVenda ;
      private string[] P00CK2_A663SerasaNumeroProposta ;
      private bool[] P00CK2_n663SerasaNumeroProposta ;
      private int[] P00CK2_A662SerasaId ;
      private string[] P00CK3_A663SerasaNumeroProposta ;
      private bool[] P00CK3_n663SerasaNumeroProposta ;
      private int[] P00CK3_A168ClienteId ;
      private bool[] P00CK3_n168ClienteId ;
      private DateTime[] P00CK3_A665SerasaCreatedAt ;
      private bool[] P00CK3_n665SerasaCreatedAt ;
      private decimal[] P00CK3_A664SerasaPolitica ;
      private bool[] P00CK3_n664SerasaPolitica ;
      private string[] P00CK3_A666SerasaTipoVenda ;
      private bool[] P00CK3_n666SerasaTipoVenda ;
      private string[] P00CK3_A170ClienteRazaoSocial ;
      private bool[] P00CK3_n170ClienteRazaoSocial ;
      private int[] P00CK3_A662SerasaId ;
      private string[] P00CK4_A666SerasaTipoVenda ;
      private bool[] P00CK4_n666SerasaTipoVenda ;
      private int[] P00CK4_A168ClienteId ;
      private bool[] P00CK4_n168ClienteId ;
      private DateTime[] P00CK4_A665SerasaCreatedAt ;
      private bool[] P00CK4_n665SerasaCreatedAt ;
      private decimal[] P00CK4_A664SerasaPolitica ;
      private bool[] P00CK4_n664SerasaPolitica ;
      private string[] P00CK4_A663SerasaNumeroProposta ;
      private bool[] P00CK4_n663SerasaNumeroProposta ;
      private string[] P00CK4_A170ClienteRazaoSocial ;
      private bool[] P00CK4_n170ClienteRazaoSocial ;
      private int[] P00CK4_A662SerasaId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class serasawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00CK2( IGxContext context ,
                                             int A168ClienteId ,
                                             GxSimpleCollection<int> AV56Array_ClienteId ,
                                             string AV59Serasawwds_1_filterfulltext ,
                                             string AV60Serasawwds_2_dynamicfiltersselector1 ,
                                             short AV61Serasawwds_3_dynamicfiltersoperator1 ,
                                             string AV62Serasawwds_4_serasanumeroproposta1 ,
                                             bool AV63Serasawwds_5_dynamicfiltersenabled2 ,
                                             string AV64Serasawwds_6_dynamicfiltersselector2 ,
                                             short AV65Serasawwds_7_dynamicfiltersoperator2 ,
                                             string AV66Serasawwds_8_serasanumeroproposta2 ,
                                             bool AV67Serasawwds_9_dynamicfiltersenabled3 ,
                                             string AV68Serasawwds_10_dynamicfiltersselector3 ,
                                             short AV69Serasawwds_11_dynamicfiltersoperator3 ,
                                             string AV70Serasawwds_12_serasanumeroproposta3 ,
                                             string AV72Serasawwds_14_tfclienterazaosocial_sel ,
                                             string AV71Serasawwds_13_tfclienterazaosocial ,
                                             string AV74Serasawwds_16_tfserasanumeroproposta_sel ,
                                             string AV73Serasawwds_15_tfserasanumeroproposta ,
                                             decimal AV75Serasawwds_17_tfserasapolitica ,
                                             decimal AV76Serasawwds_18_tfserasapolitica_to ,
                                             DateTime AV77Serasawwds_19_tfserasacreatedat ,
                                             DateTime AV78Serasawwds_20_tfserasacreatedat_to ,
                                             string AV80Serasawwds_22_tfserasatipovenda_sel ,
                                             string AV79Serasawwds_21_tfserasatipovenda ,
                                             string A170ClienteRazaoSocial ,
                                             string A663SerasaNumeroProposta ,
                                             decimal A664SerasaPolitica ,
                                             string A666SerasaTipoVenda ,
                                             DateTime A665SerasaCreatedAt )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.ClienteRazaoSocial, T1.ClienteId, T1.SerasaCreatedAt, T1.SerasaPolitica, T1.SerasaTipoVenda, T1.SerasaNumeroProposta, T1.SerasaId FROM (Serasa T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56Array_ClienteId, "T1.ClienteId IN (", ")")+")");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV59Serasawwds_1_filterfulltext) or ( T1.SerasaNumeroProposta like '%' || :lV59Serasawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.SerasaPolitica,'999999999990.99'), 2) like '%' || :lV59Serasawwds_1_filterfulltext) or ( T1.SerasaTipoVenda like '%' || :lV59Serasawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Serasawwds_2_dynamicfiltersselector1, "SERASANUMEROPROPOSTA") == 0 ) && ( AV61Serasawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasawwds_4_serasanumeroproposta1)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV62Serasawwds_4_serasanumeroproposta1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Serasawwds_2_dynamicfiltersselector1, "SERASANUMEROPROPOSTA") == 0 ) && ( AV61Serasawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasawwds_4_serasanumeroproposta1)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV62Serasawwds_4_serasanumeroproposta1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV63Serasawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Serasawwds_6_dynamicfiltersselector2, "SERASANUMEROPROPOSTA") == 0 ) && ( AV65Serasawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasawwds_8_serasanumeroproposta2)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV66Serasawwds_8_serasanumeroproposta2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV63Serasawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Serasawwds_6_dynamicfiltersselector2, "SERASANUMEROPROPOSTA") == 0 ) && ( AV65Serasawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasawwds_8_serasanumeroproposta2)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV66Serasawwds_8_serasanumeroproposta2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV67Serasawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Serasawwds_10_dynamicfiltersselector3, "SERASANUMEROPROPOSTA") == 0 ) && ( AV69Serasawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasawwds_12_serasanumeroproposta3)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV70Serasawwds_12_serasanumeroproposta3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV67Serasawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Serasawwds_10_dynamicfiltersselector3, "SERASANUMEROPROPOSTA") == 0 ) && ( AV69Serasawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasawwds_12_serasanumeroproposta3)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV70Serasawwds_12_serasanumeroproposta3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Serasawwds_14_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasawwds_13_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV71Serasawwds_13_tfclienterazaosocial)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Serasawwds_14_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV72Serasawwds_14_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV72Serasawwds_14_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV72Serasawwds_14_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Serasawwds_16_tfserasanumeroproposta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasawwds_15_tfserasanumeroproposta)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV73Serasawwds_15_tfserasanumeroproposta)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Serasawwds_16_tfserasanumeroproposta_sel)) && ! ( StringUtil.StrCmp(AV74Serasawwds_16_tfserasanumeroproposta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta = ( :AV74Serasawwds_16_tfserasanumeroproposta_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV74Serasawwds_16_tfserasanumeroproposta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta IS NULL or (char_length(trim(trailing ' ' from T1.SerasaNumeroProposta))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV75Serasawwds_17_tfserasapolitica) )
         {
            AddWhere(sWhereString, "(T1.SerasaPolitica >= :AV75Serasawwds_17_tfserasapolitica)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV76Serasawwds_18_tfserasapolitica_to) )
         {
            AddWhere(sWhereString, "(T1.SerasaPolitica <= :AV76Serasawwds_18_tfserasapolitica_to)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Serasawwds_19_tfserasacreatedat) )
         {
            AddWhere(sWhereString, "(T1.SerasaCreatedAt >= :AV77Serasawwds_19_tfserasacreatedat)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Serasawwds_20_tfserasacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.SerasaCreatedAt <= :AV78Serasawwds_20_tfserasacreatedat_to)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Serasawwds_22_tfserasatipovenda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Serasawwds_21_tfserasatipovenda)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda like :lV79Serasawwds_21_tfserasatipovenda)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Serasawwds_22_tfserasatipovenda_sel)) && ! ( StringUtil.StrCmp(AV80Serasawwds_22_tfserasatipovenda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda = ( :AV80Serasawwds_22_tfserasatipovenda_sel))");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( StringUtil.StrCmp(AV80Serasawwds_22_tfserasatipovenda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda IS NULL or (char_length(trim(trailing ' ' from T1.SerasaTipoVenda))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.ClienteRazaoSocial";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00CK3( IGxContext context ,
                                             int A168ClienteId ,
                                             GxSimpleCollection<int> AV56Array_ClienteId ,
                                             string AV59Serasawwds_1_filterfulltext ,
                                             string AV60Serasawwds_2_dynamicfiltersselector1 ,
                                             short AV61Serasawwds_3_dynamicfiltersoperator1 ,
                                             string AV62Serasawwds_4_serasanumeroproposta1 ,
                                             bool AV63Serasawwds_5_dynamicfiltersenabled2 ,
                                             string AV64Serasawwds_6_dynamicfiltersselector2 ,
                                             short AV65Serasawwds_7_dynamicfiltersoperator2 ,
                                             string AV66Serasawwds_8_serasanumeroproposta2 ,
                                             bool AV67Serasawwds_9_dynamicfiltersenabled3 ,
                                             string AV68Serasawwds_10_dynamicfiltersselector3 ,
                                             short AV69Serasawwds_11_dynamicfiltersoperator3 ,
                                             string AV70Serasawwds_12_serasanumeroproposta3 ,
                                             string AV72Serasawwds_14_tfclienterazaosocial_sel ,
                                             string AV71Serasawwds_13_tfclienterazaosocial ,
                                             string AV74Serasawwds_16_tfserasanumeroproposta_sel ,
                                             string AV73Serasawwds_15_tfserasanumeroproposta ,
                                             decimal AV75Serasawwds_17_tfserasapolitica ,
                                             decimal AV76Serasawwds_18_tfserasapolitica_to ,
                                             DateTime AV77Serasawwds_19_tfserasacreatedat ,
                                             DateTime AV78Serasawwds_20_tfserasacreatedat_to ,
                                             string AV80Serasawwds_22_tfserasatipovenda_sel ,
                                             string AV79Serasawwds_21_tfserasatipovenda ,
                                             string A170ClienteRazaoSocial ,
                                             string A663SerasaNumeroProposta ,
                                             decimal A664SerasaPolitica ,
                                             string A666SerasaTipoVenda ,
                                             DateTime A665SerasaCreatedAt )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.SerasaNumeroProposta, T1.ClienteId, T1.SerasaCreatedAt, T1.SerasaPolitica, T1.SerasaTipoVenda, T2.ClienteRazaoSocial, T1.SerasaId FROM (Serasa T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56Array_ClienteId, "T1.ClienteId IN (", ")")+")");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV59Serasawwds_1_filterfulltext) or ( T1.SerasaNumeroProposta like '%' || :lV59Serasawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.SerasaPolitica,'999999999990.99'), 2) like '%' || :lV59Serasawwds_1_filterfulltext) or ( T1.SerasaTipoVenda like '%' || :lV59Serasawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Serasawwds_2_dynamicfiltersselector1, "SERASANUMEROPROPOSTA") == 0 ) && ( AV61Serasawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasawwds_4_serasanumeroproposta1)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV62Serasawwds_4_serasanumeroproposta1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Serasawwds_2_dynamicfiltersselector1, "SERASANUMEROPROPOSTA") == 0 ) && ( AV61Serasawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasawwds_4_serasanumeroproposta1)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV62Serasawwds_4_serasanumeroproposta1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV63Serasawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Serasawwds_6_dynamicfiltersselector2, "SERASANUMEROPROPOSTA") == 0 ) && ( AV65Serasawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasawwds_8_serasanumeroproposta2)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV66Serasawwds_8_serasanumeroproposta2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV63Serasawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Serasawwds_6_dynamicfiltersselector2, "SERASANUMEROPROPOSTA") == 0 ) && ( AV65Serasawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasawwds_8_serasanumeroproposta2)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV66Serasawwds_8_serasanumeroproposta2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV67Serasawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Serasawwds_10_dynamicfiltersselector3, "SERASANUMEROPROPOSTA") == 0 ) && ( AV69Serasawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasawwds_12_serasanumeroproposta3)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV70Serasawwds_12_serasanumeroproposta3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV67Serasawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Serasawwds_10_dynamicfiltersselector3, "SERASANUMEROPROPOSTA") == 0 ) && ( AV69Serasawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasawwds_12_serasanumeroproposta3)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV70Serasawwds_12_serasanumeroproposta3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Serasawwds_14_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasawwds_13_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV71Serasawwds_13_tfclienterazaosocial)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Serasawwds_14_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV72Serasawwds_14_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV72Serasawwds_14_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV72Serasawwds_14_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Serasawwds_16_tfserasanumeroproposta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasawwds_15_tfserasanumeroproposta)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV73Serasawwds_15_tfserasanumeroproposta)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Serasawwds_16_tfserasanumeroproposta_sel)) && ! ( StringUtil.StrCmp(AV74Serasawwds_16_tfserasanumeroproposta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta = ( :AV74Serasawwds_16_tfserasanumeroproposta_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV74Serasawwds_16_tfserasanumeroproposta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta IS NULL or (char_length(trim(trailing ' ' from T1.SerasaNumeroProposta))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV75Serasawwds_17_tfserasapolitica) )
         {
            AddWhere(sWhereString, "(T1.SerasaPolitica >= :AV75Serasawwds_17_tfserasapolitica)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV76Serasawwds_18_tfserasapolitica_to) )
         {
            AddWhere(sWhereString, "(T1.SerasaPolitica <= :AV76Serasawwds_18_tfserasapolitica_to)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Serasawwds_19_tfserasacreatedat) )
         {
            AddWhere(sWhereString, "(T1.SerasaCreatedAt >= :AV77Serasawwds_19_tfserasacreatedat)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Serasawwds_20_tfserasacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.SerasaCreatedAt <= :AV78Serasawwds_20_tfserasacreatedat_to)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Serasawwds_22_tfserasatipovenda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Serasawwds_21_tfserasatipovenda)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda like :lV79Serasawwds_21_tfserasatipovenda)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Serasawwds_22_tfserasatipovenda_sel)) && ! ( StringUtil.StrCmp(AV80Serasawwds_22_tfserasatipovenda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda = ( :AV80Serasawwds_22_tfserasatipovenda_sel))");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( StringUtil.StrCmp(AV80Serasawwds_22_tfserasatipovenda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda IS NULL or (char_length(trim(trailing ' ' from T1.SerasaTipoVenda))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SerasaNumeroProposta";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00CK4( IGxContext context ,
                                             int A168ClienteId ,
                                             GxSimpleCollection<int> AV56Array_ClienteId ,
                                             string AV59Serasawwds_1_filterfulltext ,
                                             string AV60Serasawwds_2_dynamicfiltersselector1 ,
                                             short AV61Serasawwds_3_dynamicfiltersoperator1 ,
                                             string AV62Serasawwds_4_serasanumeroproposta1 ,
                                             bool AV63Serasawwds_5_dynamicfiltersenabled2 ,
                                             string AV64Serasawwds_6_dynamicfiltersselector2 ,
                                             short AV65Serasawwds_7_dynamicfiltersoperator2 ,
                                             string AV66Serasawwds_8_serasanumeroproposta2 ,
                                             bool AV67Serasawwds_9_dynamicfiltersenabled3 ,
                                             string AV68Serasawwds_10_dynamicfiltersselector3 ,
                                             short AV69Serasawwds_11_dynamicfiltersoperator3 ,
                                             string AV70Serasawwds_12_serasanumeroproposta3 ,
                                             string AV72Serasawwds_14_tfclienterazaosocial_sel ,
                                             string AV71Serasawwds_13_tfclienterazaosocial ,
                                             string AV74Serasawwds_16_tfserasanumeroproposta_sel ,
                                             string AV73Serasawwds_15_tfserasanumeroproposta ,
                                             decimal AV75Serasawwds_17_tfserasapolitica ,
                                             decimal AV76Serasawwds_18_tfserasapolitica_to ,
                                             DateTime AV77Serasawwds_19_tfserasacreatedat ,
                                             DateTime AV78Serasawwds_20_tfserasacreatedat_to ,
                                             string AV80Serasawwds_22_tfserasatipovenda_sel ,
                                             string AV79Serasawwds_21_tfserasatipovenda ,
                                             string A170ClienteRazaoSocial ,
                                             string A663SerasaNumeroProposta ,
                                             decimal A664SerasaPolitica ,
                                             string A666SerasaTipoVenda ,
                                             DateTime A665SerasaCreatedAt )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.SerasaTipoVenda, T1.ClienteId, T1.SerasaCreatedAt, T1.SerasaPolitica, T1.SerasaNumeroProposta, T2.ClienteRazaoSocial, T1.SerasaId FROM (Serasa T1 LEFT JOIN Cliente T2 ON T2.ClienteId = T1.ClienteId)";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV56Array_ClienteId, "T1.ClienteId IN (", ")")+")");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ClienteRazaoSocial like '%' || :lV59Serasawwds_1_filterfulltext) or ( T1.SerasaNumeroProposta like '%' || :lV59Serasawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T1.SerasaPolitica,'999999999990.99'), 2) like '%' || :lV59Serasawwds_1_filterfulltext) or ( T1.SerasaTipoVenda like '%' || :lV59Serasawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Serasawwds_2_dynamicfiltersselector1, "SERASANUMEROPROPOSTA") == 0 ) && ( AV61Serasawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasawwds_4_serasanumeroproposta1)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV62Serasawwds_4_serasanumeroproposta1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Serasawwds_2_dynamicfiltersselector1, "SERASANUMEROPROPOSTA") == 0 ) && ( AV61Serasawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasawwds_4_serasanumeroproposta1)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV62Serasawwds_4_serasanumeroproposta1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV63Serasawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Serasawwds_6_dynamicfiltersselector2, "SERASANUMEROPROPOSTA") == 0 ) && ( AV65Serasawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasawwds_8_serasanumeroproposta2)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV66Serasawwds_8_serasanumeroproposta2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV63Serasawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Serasawwds_6_dynamicfiltersselector2, "SERASANUMEROPROPOSTA") == 0 ) && ( AV65Serasawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasawwds_8_serasanumeroproposta2)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV66Serasawwds_8_serasanumeroproposta2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV67Serasawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Serasawwds_10_dynamicfiltersselector3, "SERASANUMEROPROPOSTA") == 0 ) && ( AV69Serasawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasawwds_12_serasanumeroproposta3)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV70Serasawwds_12_serasanumeroproposta3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV67Serasawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Serasawwds_10_dynamicfiltersselector3, "SERASANUMEROPROPOSTA") == 0 ) && ( AV69Serasawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasawwds_12_serasanumeroproposta3)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like '%' || :lV70Serasawwds_12_serasanumeroproposta3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Serasawwds_14_tfclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasawwds_13_tfclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial like :lV71Serasawwds_13_tfclienterazaosocial)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Serasawwds_14_tfclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV72Serasawwds_14_tfclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial = ( :AV72Serasawwds_14_tfclienterazaosocial_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV72Serasawwds_14_tfclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T2.ClienteRazaoSocial))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Serasawwds_16_tfserasanumeroproposta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasawwds_15_tfserasanumeroproposta)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta like :lV73Serasawwds_15_tfserasanumeroproposta)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Serasawwds_16_tfserasanumeroproposta_sel)) && ! ( StringUtil.StrCmp(AV74Serasawwds_16_tfserasanumeroproposta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta = ( :AV74Serasawwds_16_tfserasanumeroproposta_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV74Serasawwds_16_tfserasanumeroproposta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SerasaNumeroProposta IS NULL or (char_length(trim(trailing ' ' from T1.SerasaNumeroProposta))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV75Serasawwds_17_tfserasapolitica) )
         {
            AddWhere(sWhereString, "(T1.SerasaPolitica >= :AV75Serasawwds_17_tfserasapolitica)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV76Serasawwds_18_tfserasapolitica_to) )
         {
            AddWhere(sWhereString, "(T1.SerasaPolitica <= :AV76Serasawwds_18_tfserasapolitica_to)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Serasawwds_19_tfserasacreatedat) )
         {
            AddWhere(sWhereString, "(T1.SerasaCreatedAt >= :AV77Serasawwds_19_tfserasacreatedat)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV78Serasawwds_20_tfserasacreatedat_to) )
         {
            AddWhere(sWhereString, "(T1.SerasaCreatedAt <= :AV78Serasawwds_20_tfserasacreatedat_to)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Serasawwds_22_tfserasatipovenda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Serasawwds_21_tfserasatipovenda)) ) )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda like :lV79Serasawwds_21_tfserasatipovenda)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Serasawwds_22_tfserasatipovenda_sel)) && ! ( StringUtil.StrCmp(AV80Serasawwds_22_tfserasatipovenda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda = ( :AV80Serasawwds_22_tfserasatipovenda_sel))");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( StringUtil.StrCmp(AV80Serasawwds_22_tfserasatipovenda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.SerasaTipoVenda IS NULL or (char_length(trim(trailing ' ' from T1.SerasaTipoVenda))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.SerasaTipoVenda";
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
                     return conditional_P00CK2(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] );
               case 1 :
                     return conditional_P00CK3(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] );
               case 2 :
                     return conditional_P00CK4(context, (int)dynConstraints[0] , (GxSimpleCollection<int>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (decimal)dynConstraints[18] , (decimal)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (decimal)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] );
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
          Object[] prmP00CK2;
          prmP00CK2 = new Object[] {
          new ParDef("lV59Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Serasawwds_4_serasanumeroproposta1",GXType.VarChar,40,0) ,
          new ParDef("lV62Serasawwds_4_serasanumeroproposta1",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasawwds_8_serasanumeroproposta2",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasawwds_8_serasanumeroproposta2",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasawwds_12_serasanumeroproposta3",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasawwds_12_serasanumeroproposta3",GXType.VarChar,40,0) ,
          new ParDef("lV71Serasawwds_13_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV72Serasawwds_14_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV73Serasawwds_15_tfserasanumeroproposta",GXType.VarChar,40,0) ,
          new ParDef("AV74Serasawwds_16_tfserasanumeroproposta_sel",GXType.VarChar,40,0) ,
          new ParDef("AV75Serasawwds_17_tfserasapolitica",GXType.Number,15,2) ,
          new ParDef("AV76Serasawwds_18_tfserasapolitica_to",GXType.Number,15,2) ,
          new ParDef("AV77Serasawwds_19_tfserasacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV78Serasawwds_20_tfserasacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV79Serasawwds_21_tfserasatipovenda",GXType.VarChar,40,0) ,
          new ParDef("AV80Serasawwds_22_tfserasatipovenda_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00CK3;
          prmP00CK3 = new Object[] {
          new ParDef("lV59Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Serasawwds_4_serasanumeroproposta1",GXType.VarChar,40,0) ,
          new ParDef("lV62Serasawwds_4_serasanumeroproposta1",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasawwds_8_serasanumeroproposta2",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasawwds_8_serasanumeroproposta2",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasawwds_12_serasanumeroproposta3",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasawwds_12_serasanumeroproposta3",GXType.VarChar,40,0) ,
          new ParDef("lV71Serasawwds_13_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV72Serasawwds_14_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV73Serasawwds_15_tfserasanumeroproposta",GXType.VarChar,40,0) ,
          new ParDef("AV74Serasawwds_16_tfserasanumeroproposta_sel",GXType.VarChar,40,0) ,
          new ParDef("AV75Serasawwds_17_tfserasapolitica",GXType.Number,15,2) ,
          new ParDef("AV76Serasawwds_18_tfserasapolitica_to",GXType.Number,15,2) ,
          new ParDef("AV77Serasawwds_19_tfserasacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV78Serasawwds_20_tfserasacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV79Serasawwds_21_tfserasatipovenda",GXType.VarChar,40,0) ,
          new ParDef("AV80Serasawwds_22_tfserasatipovenda_sel",GXType.VarChar,40,0)
          };
          Object[] prmP00CK4;
          prmP00CK4 = new Object[] {
          new ParDef("lV59Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV59Serasawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV62Serasawwds_4_serasanumeroproposta1",GXType.VarChar,40,0) ,
          new ParDef("lV62Serasawwds_4_serasanumeroproposta1",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasawwds_8_serasanumeroproposta2",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasawwds_8_serasanumeroproposta2",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasawwds_12_serasanumeroproposta3",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasawwds_12_serasanumeroproposta3",GXType.VarChar,40,0) ,
          new ParDef("lV71Serasawwds_13_tfclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV72Serasawwds_14_tfclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("lV73Serasawwds_15_tfserasanumeroproposta",GXType.VarChar,40,0) ,
          new ParDef("AV74Serasawwds_16_tfserasanumeroproposta_sel",GXType.VarChar,40,0) ,
          new ParDef("AV75Serasawwds_17_tfserasapolitica",GXType.Number,15,2) ,
          new ParDef("AV76Serasawwds_18_tfserasapolitica_to",GXType.Number,15,2) ,
          new ParDef("AV77Serasawwds_19_tfserasacreatedat",GXType.DateTime,8,5) ,
          new ParDef("AV78Serasawwds_20_tfserasacreatedat_to",GXType.DateTime,8,5) ,
          new ParDef("lV79Serasawwds_21_tfserasatipovenda",GXType.VarChar,40,0) ,
          new ParDef("AV80Serasawwds_22_tfserasatipovenda_sel",GXType.VarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CK2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CK3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00CK4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CK4,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
