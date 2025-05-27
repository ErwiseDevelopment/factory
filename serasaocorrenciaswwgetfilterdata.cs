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
   public class serasaocorrenciaswwgetfilterdata : GXProcedure
   {
      public serasaocorrenciaswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasaocorrenciaswwgetfilterdata( IGxContext context )
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
         this.AV36DDOName = aP0_DDOName;
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
         this.AV38SearchTxtTo = aP2_SearchTxtTo;
         this.AV39OptionsJson = "" ;
         this.AV40OptionsDescJson = "" ;
         this.AV41OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV39OptionsJson;
         aP4_OptionsDescJson=this.AV40OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV41OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV36DDOName = aP0_DDOName;
         this.AV37SearchTxtParms = aP1_SearchTxtParms;
         this.AV38SearchTxtTo = aP2_SearchTxtTo;
         this.AV39OptionsJson = "" ;
         this.AV40OptionsDescJson = "" ;
         this.AV41OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV39OptionsJson;
         aP4_OptionsDescJson=this.AV40OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV26Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23MaxItems = 10;
         AV22PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV37SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV20SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV37SearchTxtParms)) ? "" : StringUtil.Substring( AV37SearchTxtParms, 3, -1));
         AV21SkipItems = (short)(AV22PageIndex*AV23MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_SERASAOCORRENCIASORIGEM") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAOCORRENCIASORIGEMOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_SERASAOCORRENCIASMODALIDADE") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAOCORRENCIASMODALIDADEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV36DDOName), "DDO_SERASAOCORRENCIASTIPOMOEDA") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAOCORRENCIASTIPOMOEDAOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV39OptionsJson = AV26Options.ToJSonString(false);
         AV40OptionsDescJson = AV28OptionsDesc.ToJSonString(false);
         AV41OptionIndexesJson = AV29OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get("SerasaOcorrenciasWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SerasaOcorrenciasWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("SerasaOcorrenciasWWGridState"), null, "", "");
         }
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV43GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASAOCORRENCIASDATA") == 0 )
            {
               AV10TFSerasaOcorrenciasData = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Value, 4);
               AV11TFSerasaOcorrenciasData_To = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASAOCORRENCIASORIGEM") == 0 )
            {
               AV12TFSerasaOcorrenciasOrigem = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASAOCORRENCIASORIGEM_SEL") == 0 )
            {
               AV13TFSerasaOcorrenciasOrigem_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASAOCORRENCIASMODALIDADE") == 0 )
            {
               AV14TFSerasaOcorrenciasModalidade = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASAOCORRENCIASMODALIDADE_SEL") == 0 )
            {
               AV15TFSerasaOcorrenciasModalidade_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASAOCORRENCIASTIPOMOEDA") == 0 )
            {
               AV16TFSerasaOcorrenciasTipoMoeda = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASAOCORRENCIASTIPOMOEDA_SEL") == 0 )
            {
               AV17TFSerasaOcorrenciasTipoMoeda_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSERASAOCORRENCIASVALOR") == 0 )
            {
               AV18TFSerasaOcorrenciasValor = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV19TFSerasaOcorrenciasValor_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "PARM_&SERASAID") == 0 )
            {
               AV42SerasaId = (int)(Math.Round(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSERASAOCORRENCIASORIGEMOPTIONS' Routine */
         returnInSub = false;
         AV12TFSerasaOcorrenciasOrigem = AV20SearchTxt;
         AV13TFSerasaOcorrenciasOrigem_Sel = "";
         AV45Serasaocorrenciaswwds_1_serasaid = AV42SerasaId;
         AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata = AV10TFSerasaOcorrenciasData;
         AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to = AV11TFSerasaOcorrenciasData_To;
         AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem = AV12TFSerasaOcorrenciasOrigem;
         AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel = AV13TFSerasaOcorrenciasOrigem_Sel;
         AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade = AV14TFSerasaOcorrenciasModalidade;
         AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel = AV15TFSerasaOcorrenciasModalidade_Sel;
         AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda = AV16TFSerasaOcorrenciasTipoMoeda;
         AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel = AV17TFSerasaOcorrenciasTipoMoeda_Sel;
         AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor = AV18TFSerasaOcorrenciasValor;
         AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to = AV19TFSerasaOcorrenciasValor_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata ,
                                              AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to ,
                                              AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel ,
                                              AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem ,
                                              AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel ,
                                              AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade ,
                                              AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel ,
                                              AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda ,
                                              AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor ,
                                              AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to ,
                                              A727SerasaOcorrenciasData ,
                                              A728SerasaOcorrenciasOrigem ,
                                              A729SerasaOcorrenciasModalidade ,
                                              A730SerasaOcorrenciasTipoMoeda ,
                                              A731SerasaOcorrenciasValor ,
                                              AV45Serasaocorrenciaswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem = StringUtil.Concat( StringUtil.RTrim( AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem), "%", "");
         lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade = StringUtil.Concat( StringUtil.RTrim( AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade), "%", "");
         lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda = StringUtil.Concat( StringUtil.RTrim( AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda), "%", "");
         /* Using cursor P00D12 */
         pr_default.execute(0, new Object[] {AV45Serasaocorrenciaswwds_1_serasaid, AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata, AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to, lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem, AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel, lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade, AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel, lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda, AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel, AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor, AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKD12 = false;
            A662SerasaId = P00D12_A662SerasaId[0];
            n662SerasaId = P00D12_n662SerasaId[0];
            A728SerasaOcorrenciasOrigem = P00D12_A728SerasaOcorrenciasOrigem[0];
            n728SerasaOcorrenciasOrigem = P00D12_n728SerasaOcorrenciasOrigem[0];
            A731SerasaOcorrenciasValor = P00D12_A731SerasaOcorrenciasValor[0];
            n731SerasaOcorrenciasValor = P00D12_n731SerasaOcorrenciasValor[0];
            A730SerasaOcorrenciasTipoMoeda = P00D12_A730SerasaOcorrenciasTipoMoeda[0];
            n730SerasaOcorrenciasTipoMoeda = P00D12_n730SerasaOcorrenciasTipoMoeda[0];
            A729SerasaOcorrenciasModalidade = P00D12_A729SerasaOcorrenciasModalidade[0];
            n729SerasaOcorrenciasModalidade = P00D12_n729SerasaOcorrenciasModalidade[0];
            A727SerasaOcorrenciasData = P00D12_A727SerasaOcorrenciasData[0];
            n727SerasaOcorrenciasData = P00D12_n727SerasaOcorrenciasData[0];
            A726SerasaOcorrenciasId = P00D12_A726SerasaOcorrenciasId[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00D12_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D12_A728SerasaOcorrenciasOrigem[0], A728SerasaOcorrenciasOrigem) == 0 ) )
            {
               BRKD12 = false;
               A726SerasaOcorrenciasId = P00D12_A726SerasaOcorrenciasId[0];
               AV30count = (long)(AV30count+1);
               BRKD12 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV21SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A728SerasaOcorrenciasOrigem)) ? "<#Empty#>" : A728SerasaOcorrenciasOrigem);
               AV26Options.Add(AV25Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV26Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV21SkipItems = (short)(AV21SkipItems-1);
            }
            if ( ! BRKD12 )
            {
               BRKD12 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSERASAOCORRENCIASMODALIDADEOPTIONS' Routine */
         returnInSub = false;
         AV14TFSerasaOcorrenciasModalidade = AV20SearchTxt;
         AV15TFSerasaOcorrenciasModalidade_Sel = "";
         AV45Serasaocorrenciaswwds_1_serasaid = AV42SerasaId;
         AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata = AV10TFSerasaOcorrenciasData;
         AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to = AV11TFSerasaOcorrenciasData_To;
         AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem = AV12TFSerasaOcorrenciasOrigem;
         AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel = AV13TFSerasaOcorrenciasOrigem_Sel;
         AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade = AV14TFSerasaOcorrenciasModalidade;
         AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel = AV15TFSerasaOcorrenciasModalidade_Sel;
         AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda = AV16TFSerasaOcorrenciasTipoMoeda;
         AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel = AV17TFSerasaOcorrenciasTipoMoeda_Sel;
         AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor = AV18TFSerasaOcorrenciasValor;
         AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to = AV19TFSerasaOcorrenciasValor_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata ,
                                              AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to ,
                                              AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel ,
                                              AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem ,
                                              AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel ,
                                              AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade ,
                                              AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel ,
                                              AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda ,
                                              AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor ,
                                              AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to ,
                                              A727SerasaOcorrenciasData ,
                                              A728SerasaOcorrenciasOrigem ,
                                              A729SerasaOcorrenciasModalidade ,
                                              A730SerasaOcorrenciasTipoMoeda ,
                                              A731SerasaOcorrenciasValor ,
                                              AV45Serasaocorrenciaswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem = StringUtil.Concat( StringUtil.RTrim( AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem), "%", "");
         lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade = StringUtil.Concat( StringUtil.RTrim( AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade), "%", "");
         lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda = StringUtil.Concat( StringUtil.RTrim( AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda), "%", "");
         /* Using cursor P00D13 */
         pr_default.execute(1, new Object[] {AV45Serasaocorrenciaswwds_1_serasaid, AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata, AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to, lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem, AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel, lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade, AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel, lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda, AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel, AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor, AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKD14 = false;
            A662SerasaId = P00D13_A662SerasaId[0];
            n662SerasaId = P00D13_n662SerasaId[0];
            A729SerasaOcorrenciasModalidade = P00D13_A729SerasaOcorrenciasModalidade[0];
            n729SerasaOcorrenciasModalidade = P00D13_n729SerasaOcorrenciasModalidade[0];
            A731SerasaOcorrenciasValor = P00D13_A731SerasaOcorrenciasValor[0];
            n731SerasaOcorrenciasValor = P00D13_n731SerasaOcorrenciasValor[0];
            A730SerasaOcorrenciasTipoMoeda = P00D13_A730SerasaOcorrenciasTipoMoeda[0];
            n730SerasaOcorrenciasTipoMoeda = P00D13_n730SerasaOcorrenciasTipoMoeda[0];
            A728SerasaOcorrenciasOrigem = P00D13_A728SerasaOcorrenciasOrigem[0];
            n728SerasaOcorrenciasOrigem = P00D13_n728SerasaOcorrenciasOrigem[0];
            A727SerasaOcorrenciasData = P00D13_A727SerasaOcorrenciasData[0];
            n727SerasaOcorrenciasData = P00D13_n727SerasaOcorrenciasData[0];
            A726SerasaOcorrenciasId = P00D13_A726SerasaOcorrenciasId[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00D13_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D13_A729SerasaOcorrenciasModalidade[0], A729SerasaOcorrenciasModalidade) == 0 ) )
            {
               BRKD14 = false;
               A726SerasaOcorrenciasId = P00D13_A726SerasaOcorrenciasId[0];
               AV30count = (long)(AV30count+1);
               BRKD14 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV21SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A729SerasaOcorrenciasModalidade)) ? "<#Empty#>" : A729SerasaOcorrenciasModalidade);
               AV26Options.Add(AV25Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV26Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV21SkipItems = (short)(AV21SkipItems-1);
            }
            if ( ! BRKD14 )
            {
               BRKD14 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSERASAOCORRENCIASTIPOMOEDAOPTIONS' Routine */
         returnInSub = false;
         AV16TFSerasaOcorrenciasTipoMoeda = AV20SearchTxt;
         AV17TFSerasaOcorrenciasTipoMoeda_Sel = "";
         AV45Serasaocorrenciaswwds_1_serasaid = AV42SerasaId;
         AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata = AV10TFSerasaOcorrenciasData;
         AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to = AV11TFSerasaOcorrenciasData_To;
         AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem = AV12TFSerasaOcorrenciasOrigem;
         AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel = AV13TFSerasaOcorrenciasOrigem_Sel;
         AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade = AV14TFSerasaOcorrenciasModalidade;
         AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel = AV15TFSerasaOcorrenciasModalidade_Sel;
         AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda = AV16TFSerasaOcorrenciasTipoMoeda;
         AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel = AV17TFSerasaOcorrenciasTipoMoeda_Sel;
         AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor = AV18TFSerasaOcorrenciasValor;
         AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to = AV19TFSerasaOcorrenciasValor_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata ,
                                              AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to ,
                                              AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel ,
                                              AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem ,
                                              AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel ,
                                              AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade ,
                                              AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel ,
                                              AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda ,
                                              AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor ,
                                              AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to ,
                                              A727SerasaOcorrenciasData ,
                                              A728SerasaOcorrenciasOrigem ,
                                              A729SerasaOcorrenciasModalidade ,
                                              A730SerasaOcorrenciasTipoMoeda ,
                                              A731SerasaOcorrenciasValor ,
                                              AV45Serasaocorrenciaswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem = StringUtil.Concat( StringUtil.RTrim( AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem), "%", "");
         lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade = StringUtil.Concat( StringUtil.RTrim( AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade), "%", "");
         lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda = StringUtil.Concat( StringUtil.RTrim( AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda), "%", "");
         /* Using cursor P00D14 */
         pr_default.execute(2, new Object[] {AV45Serasaocorrenciaswwds_1_serasaid, AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata, AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to, lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem, AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel, lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade, AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel, lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda, AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel, AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor, AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKD16 = false;
            A662SerasaId = P00D14_A662SerasaId[0];
            n662SerasaId = P00D14_n662SerasaId[0];
            A730SerasaOcorrenciasTipoMoeda = P00D14_A730SerasaOcorrenciasTipoMoeda[0];
            n730SerasaOcorrenciasTipoMoeda = P00D14_n730SerasaOcorrenciasTipoMoeda[0];
            A731SerasaOcorrenciasValor = P00D14_A731SerasaOcorrenciasValor[0];
            n731SerasaOcorrenciasValor = P00D14_n731SerasaOcorrenciasValor[0];
            A729SerasaOcorrenciasModalidade = P00D14_A729SerasaOcorrenciasModalidade[0];
            n729SerasaOcorrenciasModalidade = P00D14_n729SerasaOcorrenciasModalidade[0];
            A728SerasaOcorrenciasOrigem = P00D14_A728SerasaOcorrenciasOrigem[0];
            n728SerasaOcorrenciasOrigem = P00D14_n728SerasaOcorrenciasOrigem[0];
            A727SerasaOcorrenciasData = P00D14_A727SerasaOcorrenciasData[0];
            n727SerasaOcorrenciasData = P00D14_n727SerasaOcorrenciasData[0];
            A726SerasaOcorrenciasId = P00D14_A726SerasaOcorrenciasId[0];
            AV30count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00D14_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D14_A730SerasaOcorrenciasTipoMoeda[0], A730SerasaOcorrenciasTipoMoeda) == 0 ) )
            {
               BRKD16 = false;
               A726SerasaOcorrenciasId = P00D14_A726SerasaOcorrenciasId[0];
               AV30count = (long)(AV30count+1);
               BRKD16 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV21SkipItems) )
            {
               AV25Option = (String.IsNullOrEmpty(StringUtil.RTrim( A730SerasaOcorrenciasTipoMoeda)) ? "<#Empty#>" : A730SerasaOcorrenciasTipoMoeda);
               AV26Options.Add(AV25Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV26Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV21SkipItems = (short)(AV21SkipItems-1);
            }
            if ( ! BRKD16 )
            {
               BRKD16 = true;
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
         AV39OptionsJson = "";
         AV40OptionsDescJson = "";
         AV41OptionIndexesJson = "";
         AV26Options = new GxSimpleCollection<string>();
         AV28OptionsDesc = new GxSimpleCollection<string>();
         AV29OptionIndexes = new GxSimpleCollection<string>();
         AV20SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV31Session = context.GetSession();
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFSerasaOcorrenciasData = DateTime.MinValue;
         AV11TFSerasaOcorrenciasData_To = DateTime.MinValue;
         AV12TFSerasaOcorrenciasOrigem = "";
         AV13TFSerasaOcorrenciasOrigem_Sel = "";
         AV14TFSerasaOcorrenciasModalidade = "";
         AV15TFSerasaOcorrenciasModalidade_Sel = "";
         AV16TFSerasaOcorrenciasTipoMoeda = "";
         AV17TFSerasaOcorrenciasTipoMoeda_Sel = "";
         AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata = DateTime.MinValue;
         AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to = DateTime.MinValue;
         AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem = "";
         AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel = "";
         AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade = "";
         AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel = "";
         AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda = "";
         AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel = "";
         lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem = "";
         lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade = "";
         lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda = "";
         A727SerasaOcorrenciasData = DateTime.MinValue;
         A728SerasaOcorrenciasOrigem = "";
         A729SerasaOcorrenciasModalidade = "";
         A730SerasaOcorrenciasTipoMoeda = "";
         P00D12_A662SerasaId = new int[1] ;
         P00D12_n662SerasaId = new bool[] {false} ;
         P00D12_A728SerasaOcorrenciasOrigem = new string[] {""} ;
         P00D12_n728SerasaOcorrenciasOrigem = new bool[] {false} ;
         P00D12_A731SerasaOcorrenciasValor = new decimal[1] ;
         P00D12_n731SerasaOcorrenciasValor = new bool[] {false} ;
         P00D12_A730SerasaOcorrenciasTipoMoeda = new string[] {""} ;
         P00D12_n730SerasaOcorrenciasTipoMoeda = new bool[] {false} ;
         P00D12_A729SerasaOcorrenciasModalidade = new string[] {""} ;
         P00D12_n729SerasaOcorrenciasModalidade = new bool[] {false} ;
         P00D12_A727SerasaOcorrenciasData = new DateTime[] {DateTime.MinValue} ;
         P00D12_n727SerasaOcorrenciasData = new bool[] {false} ;
         P00D12_A726SerasaOcorrenciasId = new int[1] ;
         AV25Option = "";
         P00D13_A662SerasaId = new int[1] ;
         P00D13_n662SerasaId = new bool[] {false} ;
         P00D13_A729SerasaOcorrenciasModalidade = new string[] {""} ;
         P00D13_n729SerasaOcorrenciasModalidade = new bool[] {false} ;
         P00D13_A731SerasaOcorrenciasValor = new decimal[1] ;
         P00D13_n731SerasaOcorrenciasValor = new bool[] {false} ;
         P00D13_A730SerasaOcorrenciasTipoMoeda = new string[] {""} ;
         P00D13_n730SerasaOcorrenciasTipoMoeda = new bool[] {false} ;
         P00D13_A728SerasaOcorrenciasOrigem = new string[] {""} ;
         P00D13_n728SerasaOcorrenciasOrigem = new bool[] {false} ;
         P00D13_A727SerasaOcorrenciasData = new DateTime[] {DateTime.MinValue} ;
         P00D13_n727SerasaOcorrenciasData = new bool[] {false} ;
         P00D13_A726SerasaOcorrenciasId = new int[1] ;
         P00D14_A662SerasaId = new int[1] ;
         P00D14_n662SerasaId = new bool[] {false} ;
         P00D14_A730SerasaOcorrenciasTipoMoeda = new string[] {""} ;
         P00D14_n730SerasaOcorrenciasTipoMoeda = new bool[] {false} ;
         P00D14_A731SerasaOcorrenciasValor = new decimal[1] ;
         P00D14_n731SerasaOcorrenciasValor = new bool[] {false} ;
         P00D14_A729SerasaOcorrenciasModalidade = new string[] {""} ;
         P00D14_n729SerasaOcorrenciasModalidade = new bool[] {false} ;
         P00D14_A728SerasaOcorrenciasOrigem = new string[] {""} ;
         P00D14_n728SerasaOcorrenciasOrigem = new bool[] {false} ;
         P00D14_A727SerasaOcorrenciasData = new DateTime[] {DateTime.MinValue} ;
         P00D14_n727SerasaOcorrenciasData = new bool[] {false} ;
         P00D14_A726SerasaOcorrenciasId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaocorrenciaswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00D12_A662SerasaId, P00D12_n662SerasaId, P00D12_A728SerasaOcorrenciasOrigem, P00D12_n728SerasaOcorrenciasOrigem, P00D12_A731SerasaOcorrenciasValor, P00D12_n731SerasaOcorrenciasValor, P00D12_A730SerasaOcorrenciasTipoMoeda, P00D12_n730SerasaOcorrenciasTipoMoeda, P00D12_A729SerasaOcorrenciasModalidade, P00D12_n729SerasaOcorrenciasModalidade,
               P00D12_A727SerasaOcorrenciasData, P00D12_n727SerasaOcorrenciasData, P00D12_A726SerasaOcorrenciasId
               }
               , new Object[] {
               P00D13_A662SerasaId, P00D13_n662SerasaId, P00D13_A729SerasaOcorrenciasModalidade, P00D13_n729SerasaOcorrenciasModalidade, P00D13_A731SerasaOcorrenciasValor, P00D13_n731SerasaOcorrenciasValor, P00D13_A730SerasaOcorrenciasTipoMoeda, P00D13_n730SerasaOcorrenciasTipoMoeda, P00D13_A728SerasaOcorrenciasOrigem, P00D13_n728SerasaOcorrenciasOrigem,
               P00D13_A727SerasaOcorrenciasData, P00D13_n727SerasaOcorrenciasData, P00D13_A726SerasaOcorrenciasId
               }
               , new Object[] {
               P00D14_A662SerasaId, P00D14_n662SerasaId, P00D14_A730SerasaOcorrenciasTipoMoeda, P00D14_n730SerasaOcorrenciasTipoMoeda, P00D14_A731SerasaOcorrenciasValor, P00D14_n731SerasaOcorrenciasValor, P00D14_A729SerasaOcorrenciasModalidade, P00D14_n729SerasaOcorrenciasModalidade, P00D14_A728SerasaOcorrenciasOrigem, P00D14_n728SerasaOcorrenciasOrigem,
               P00D14_A727SerasaOcorrenciasData, P00D14_n727SerasaOcorrenciasData, P00D14_A726SerasaOcorrenciasId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23MaxItems ;
      private short AV22PageIndex ;
      private short AV21SkipItems ;
      private int AV43GXV1 ;
      private int AV42SerasaId ;
      private int AV45Serasaocorrenciaswwds_1_serasaid ;
      private int A662SerasaId ;
      private int A726SerasaOcorrenciasId ;
      private long AV30count ;
      private decimal AV18TFSerasaOcorrenciasValor ;
      private decimal AV19TFSerasaOcorrenciasValor_To ;
      private decimal AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor ;
      private decimal AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to ;
      private decimal A731SerasaOcorrenciasValor ;
      private DateTime AV10TFSerasaOcorrenciasData ;
      private DateTime AV11TFSerasaOcorrenciasData_To ;
      private DateTime AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata ;
      private DateTime AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to ;
      private DateTime A727SerasaOcorrenciasData ;
      private bool returnInSub ;
      private bool BRKD12 ;
      private bool n662SerasaId ;
      private bool n728SerasaOcorrenciasOrigem ;
      private bool n731SerasaOcorrenciasValor ;
      private bool n730SerasaOcorrenciasTipoMoeda ;
      private bool n729SerasaOcorrenciasModalidade ;
      private bool n727SerasaOcorrenciasData ;
      private bool BRKD14 ;
      private bool BRKD16 ;
      private string AV39OptionsJson ;
      private string AV40OptionsDescJson ;
      private string AV41OptionIndexesJson ;
      private string AV36DDOName ;
      private string AV37SearchTxtParms ;
      private string AV38SearchTxtTo ;
      private string AV20SearchTxt ;
      private string AV12TFSerasaOcorrenciasOrigem ;
      private string AV13TFSerasaOcorrenciasOrigem_Sel ;
      private string AV14TFSerasaOcorrenciasModalidade ;
      private string AV15TFSerasaOcorrenciasModalidade_Sel ;
      private string AV16TFSerasaOcorrenciasTipoMoeda ;
      private string AV17TFSerasaOcorrenciasTipoMoeda_Sel ;
      private string AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem ;
      private string AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel ;
      private string AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade ;
      private string AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel ;
      private string AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda ;
      private string AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel ;
      private string lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem ;
      private string lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade ;
      private string lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda ;
      private string A728SerasaOcorrenciasOrigem ;
      private string A729SerasaOcorrenciasModalidade ;
      private string A730SerasaOcorrenciasTipoMoeda ;
      private string AV25Option ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV26Options ;
      private GxSimpleCollection<string> AV28OptionsDesc ;
      private GxSimpleCollection<string> AV29OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P00D12_A662SerasaId ;
      private bool[] P00D12_n662SerasaId ;
      private string[] P00D12_A728SerasaOcorrenciasOrigem ;
      private bool[] P00D12_n728SerasaOcorrenciasOrigem ;
      private decimal[] P00D12_A731SerasaOcorrenciasValor ;
      private bool[] P00D12_n731SerasaOcorrenciasValor ;
      private string[] P00D12_A730SerasaOcorrenciasTipoMoeda ;
      private bool[] P00D12_n730SerasaOcorrenciasTipoMoeda ;
      private string[] P00D12_A729SerasaOcorrenciasModalidade ;
      private bool[] P00D12_n729SerasaOcorrenciasModalidade ;
      private DateTime[] P00D12_A727SerasaOcorrenciasData ;
      private bool[] P00D12_n727SerasaOcorrenciasData ;
      private int[] P00D12_A726SerasaOcorrenciasId ;
      private int[] P00D13_A662SerasaId ;
      private bool[] P00D13_n662SerasaId ;
      private string[] P00D13_A729SerasaOcorrenciasModalidade ;
      private bool[] P00D13_n729SerasaOcorrenciasModalidade ;
      private decimal[] P00D13_A731SerasaOcorrenciasValor ;
      private bool[] P00D13_n731SerasaOcorrenciasValor ;
      private string[] P00D13_A730SerasaOcorrenciasTipoMoeda ;
      private bool[] P00D13_n730SerasaOcorrenciasTipoMoeda ;
      private string[] P00D13_A728SerasaOcorrenciasOrigem ;
      private bool[] P00D13_n728SerasaOcorrenciasOrigem ;
      private DateTime[] P00D13_A727SerasaOcorrenciasData ;
      private bool[] P00D13_n727SerasaOcorrenciasData ;
      private int[] P00D13_A726SerasaOcorrenciasId ;
      private int[] P00D14_A662SerasaId ;
      private bool[] P00D14_n662SerasaId ;
      private string[] P00D14_A730SerasaOcorrenciasTipoMoeda ;
      private bool[] P00D14_n730SerasaOcorrenciasTipoMoeda ;
      private decimal[] P00D14_A731SerasaOcorrenciasValor ;
      private bool[] P00D14_n731SerasaOcorrenciasValor ;
      private string[] P00D14_A729SerasaOcorrenciasModalidade ;
      private bool[] P00D14_n729SerasaOcorrenciasModalidade ;
      private string[] P00D14_A728SerasaOcorrenciasOrigem ;
      private bool[] P00D14_n728SerasaOcorrenciasOrigem ;
      private DateTime[] P00D14_A727SerasaOcorrenciasData ;
      private bool[] P00D14_n727SerasaOcorrenciasData ;
      private int[] P00D14_A726SerasaOcorrenciasId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class serasaocorrenciaswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00D12( IGxContext context ,
                                             DateTime AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata ,
                                             DateTime AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to ,
                                             string AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel ,
                                             string AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem ,
                                             string AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel ,
                                             string AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade ,
                                             string AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel ,
                                             string AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda ,
                                             decimal AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor ,
                                             decimal AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to ,
                                             DateTime A727SerasaOcorrenciasData ,
                                             string A728SerasaOcorrenciasOrigem ,
                                             string A729SerasaOcorrenciasModalidade ,
                                             string A730SerasaOcorrenciasTipoMoeda ,
                                             decimal A731SerasaOcorrenciasValor ,
                                             int AV45Serasaocorrenciaswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[11];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaOcorrenciasOrigem, SerasaOcorrenciasValor, SerasaOcorrenciasTipoMoeda, SerasaOcorrenciasModalidade, SerasaOcorrenciasData, SerasaOcorrenciasId FROM SerasaOcorrencias";
         AddWhere(sWhereString, "(SerasaId = :AV45Serasaocorrenciaswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasData >= :AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasData <= :AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem)) ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasOrigem like :lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel)) && ! ( StringUtil.StrCmp(AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasOrigem = ( :AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasOrigem IS NULL or (char_length(trim(trailing ' ' from SerasaOcorrenciasOrigem))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasModalidade like :lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel)) && ! ( StringUtil.StrCmp(AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasModalidade = ( :AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasModalidade IS NULL or (char_length(trim(trailing ' ' from SerasaOcorrenciasModalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda)) ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasTipoMoeda like :lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel)) && ! ( StringUtil.StrCmp(AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasTipoMoeda = ( :AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasTipoMoeda IS NULL or (char_length(trim(trailing ' ' from SerasaOcorrenciasTipoMoeda))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasValor >= :AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasValor <= :AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaOcorrenciasOrigem";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00D13( IGxContext context ,
                                             DateTime AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata ,
                                             DateTime AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to ,
                                             string AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel ,
                                             string AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem ,
                                             string AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel ,
                                             string AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade ,
                                             string AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel ,
                                             string AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda ,
                                             decimal AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor ,
                                             decimal AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to ,
                                             DateTime A727SerasaOcorrenciasData ,
                                             string A728SerasaOcorrenciasOrigem ,
                                             string A729SerasaOcorrenciasModalidade ,
                                             string A730SerasaOcorrenciasTipoMoeda ,
                                             decimal A731SerasaOcorrenciasValor ,
                                             int AV45Serasaocorrenciaswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[11];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaOcorrenciasModalidade, SerasaOcorrenciasValor, SerasaOcorrenciasTipoMoeda, SerasaOcorrenciasOrigem, SerasaOcorrenciasData, SerasaOcorrenciasId FROM SerasaOcorrencias";
         AddWhere(sWhereString, "(SerasaId = :AV45Serasaocorrenciaswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasData >= :AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasData <= :AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem)) ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasOrigem like :lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel)) && ! ( StringUtil.StrCmp(AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasOrigem = ( :AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasOrigem IS NULL or (char_length(trim(trailing ' ' from SerasaOcorrenciasOrigem))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasModalidade like :lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel)) && ! ( StringUtil.StrCmp(AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasModalidade = ( :AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasModalidade IS NULL or (char_length(trim(trailing ' ' from SerasaOcorrenciasModalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda)) ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasTipoMoeda like :lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel)) && ! ( StringUtil.StrCmp(AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasTipoMoeda = ( :AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasTipoMoeda IS NULL or (char_length(trim(trailing ' ' from SerasaOcorrenciasTipoMoeda))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasValor >= :AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasValor <= :AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaOcorrenciasModalidade";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00D14( IGxContext context ,
                                             DateTime AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata ,
                                             DateTime AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to ,
                                             string AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel ,
                                             string AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem ,
                                             string AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel ,
                                             string AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade ,
                                             string AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel ,
                                             string AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda ,
                                             decimal AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor ,
                                             decimal AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to ,
                                             DateTime A727SerasaOcorrenciasData ,
                                             string A728SerasaOcorrenciasOrigem ,
                                             string A729SerasaOcorrenciasModalidade ,
                                             string A730SerasaOcorrenciasTipoMoeda ,
                                             decimal A731SerasaOcorrenciasValor ,
                                             int AV45Serasaocorrenciaswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[11];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaOcorrenciasTipoMoeda, SerasaOcorrenciasValor, SerasaOcorrenciasModalidade, SerasaOcorrenciasOrigem, SerasaOcorrenciasData, SerasaOcorrenciasId FROM SerasaOcorrencias";
         AddWhere(sWhereString, "(SerasaId = :AV45Serasaocorrenciaswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasData >= :AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasData <= :AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem)) ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasOrigem like :lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel)) && ! ( StringUtil.StrCmp(AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasOrigem = ( :AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasOrigem IS NULL or (char_length(trim(trailing ' ' from SerasaOcorrenciasOrigem))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasModalidade like :lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel)) && ! ( StringUtil.StrCmp(AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasModalidade = ( :AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasModalidade IS NULL or (char_length(trim(trailing ' ' from SerasaOcorrenciasModalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda)) ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasTipoMoeda like :lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel)) && ! ( StringUtil.StrCmp(AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasTipoMoeda = ( :AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasTipoMoeda IS NULL or (char_length(trim(trailing ' ' from SerasaOcorrenciasTipoMoeda))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasValor >= :AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaOcorrenciasValor <= :AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaOcorrenciasTipoMoeda";
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
                     return conditional_P00D12(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] );
               case 1 :
                     return conditional_P00D13(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] );
               case 2 :
                     return conditional_P00D14(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (decimal)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (decimal)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] );
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
          Object[] prmP00D12;
          prmP00D12 = new Object[] {
          new ParDef("AV45Serasaocorrenciaswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata",GXType.Date,8,0) ,
          new ParDef("AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to",GXType.Date,8,0) ,
          new ParDef("lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem",GXType.VarChar,40,0) ,
          new ParDef("AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel",GXType.VarChar,40,0) ,
          new ParDef("lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade",GXType.VarChar,40,0) ,
          new ParDef("AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda",GXType.VarChar,40,0) ,
          new ParDef("AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel",GXType.VarChar,40,0) ,
          new ParDef("AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor",GXType.Number,18,2) ,
          new ParDef("AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to",GXType.Number,18,2)
          };
          Object[] prmP00D13;
          prmP00D13 = new Object[] {
          new ParDef("AV45Serasaocorrenciaswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata",GXType.Date,8,0) ,
          new ParDef("AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to",GXType.Date,8,0) ,
          new ParDef("lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem",GXType.VarChar,40,0) ,
          new ParDef("AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel",GXType.VarChar,40,0) ,
          new ParDef("lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade",GXType.VarChar,40,0) ,
          new ParDef("AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda",GXType.VarChar,40,0) ,
          new ParDef("AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel",GXType.VarChar,40,0) ,
          new ParDef("AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor",GXType.Number,18,2) ,
          new ParDef("AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to",GXType.Number,18,2)
          };
          Object[] prmP00D14;
          prmP00D14 = new Object[] {
          new ParDef("AV45Serasaocorrenciaswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV46Serasaocorrenciaswwds_2_tfserasaocorrenciasdata",GXType.Date,8,0) ,
          new ParDef("AV47Serasaocorrenciaswwds_3_tfserasaocorrenciasdata_to",GXType.Date,8,0) ,
          new ParDef("lV48Serasaocorrenciaswwds_4_tfserasaocorrenciasorigem",GXType.VarChar,40,0) ,
          new ParDef("AV49Serasaocorrenciaswwds_5_tfserasaocorrenciasorigem_sel",GXType.VarChar,40,0) ,
          new ParDef("lV50Serasaocorrenciaswwds_6_tfserasaocorrenciasmodalidade",GXType.VarChar,40,0) ,
          new ParDef("AV51Serasaocorrenciaswwds_7_tfserasaocorrenciasmodalidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV52Serasaocorrenciaswwds_8_tfserasaocorrenciastipomoeda",GXType.VarChar,40,0) ,
          new ParDef("AV53Serasaocorrenciaswwds_9_tfserasaocorrenciastipomoeda_sel",GXType.VarChar,40,0) ,
          new ParDef("AV54Serasaocorrenciaswwds_10_tfserasaocorrenciasvalor",GXType.Number,18,2) ,
          new ParDef("AV55Serasaocorrenciaswwds_11_tfserasaocorrenciasvalor_to",GXType.Number,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P00D12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D14", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D14,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
