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
   public class serasaacoeswwgetfilterdata : GXProcedure
   {
      public serasaacoeswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public serasaacoeswwgetfilterdata( IGxContext context )
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
         this.AV46DDOName = aP0_DDOName;
         this.AV47SearchTxtParms = aP1_SearchTxtParms;
         this.AV48SearchTxtTo = aP2_SearchTxtTo;
         this.AV49OptionsJson = "" ;
         this.AV50OptionsDescJson = "" ;
         this.AV51OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV49OptionsJson;
         aP4_OptionsDescJson=this.AV50OptionsDescJson;
         aP5_OptionIndexesJson=this.AV51OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV51OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV46DDOName = aP0_DDOName;
         this.AV47SearchTxtParms = aP1_SearchTxtParms;
         this.AV48SearchTxtTo = aP2_SearchTxtTo;
         this.AV49OptionsJson = "" ;
         this.AV50OptionsDescJson = "" ;
         this.AV51OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV49OptionsJson;
         aP4_OptionsDescJson=this.AV50OptionsDescJson;
         aP5_OptionIndexesJson=this.AV51OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV36Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33MaxItems = 10;
         AV32PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV47SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV47SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV30SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV47SearchTxtParms)) ? "" : StringUtil.Substring( AV47SearchTxtParms, 3, -1));
         AV31SkipItems = (short)(AV32PageIndex*AV33MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_SERASAACOESNATUREZA") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAACOESNATUREZAOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_SERASAACOESDISTRIBUIDOR") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAACOESDISTRIBUIDOROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_SERASAACOESVARA") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAACOESVARAOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_SERASAACOESCIDADE") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAACOESCIDADEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_SERASAACOESUF") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAACOESUFOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_SERASAACOESPRINCIPAL") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAACOESPRINCIPALOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_SERASAACOESTIPOMOEDA") == 0 )
         {
            /* Execute user subroutine: 'LOADSERASAACOESTIPOMOEDAOPTIONS' */
            S181 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV49OptionsJson = AV36Options.ToJSonString(false);
         AV50OptionsDescJson = AV38OptionsDesc.ToJSonString(false);
         AV51OptionIndexesJson = AV39OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV41Session.Get("SerasaAcoesWWGridState"), "") == 0 )
         {
            AV43GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SerasaAcoesWWGridState"), null, "", "");
         }
         else
         {
            AV43GridState.FromXml(AV41Session.Get("SerasaAcoesWWGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV43GridState.gxTpr_Filtervalues.Count )
         {
            AV44GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV43GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESDATA") == 0 )
            {
               AV10TFSerasaAcoesData = context.localUtil.CToD( AV44GridStateFilterValue.gxTpr_Value, 4);
               AV11TFSerasaAcoesData_To = context.localUtil.CToD( AV44GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESNATUREZA") == 0 )
            {
               AV12TFSerasaAcoesNatureza = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESNATUREZA_SEL") == 0 )
            {
               AV13TFSerasaAcoesNatureza_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESVALOR") == 0 )
            {
               AV14TFSerasaAcoesValor = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, ".");
               AV15TFSerasaAcoesValor_To = NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESDISTRIBUIDOR") == 0 )
            {
               AV16TFSerasaAcoesDistribuidor = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESDISTRIBUIDOR_SEL") == 0 )
            {
               AV17TFSerasaAcoesDistribuidor_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESVARA") == 0 )
            {
               AV18TFSerasaAcoesVara = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESVARA_SEL") == 0 )
            {
               AV19TFSerasaAcoesVara_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESCIDADE") == 0 )
            {
               AV20TFSerasaAcoesCidade = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESCIDADE_SEL") == 0 )
            {
               AV21TFSerasaAcoesCidade_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESUF") == 0 )
            {
               AV22TFSerasaAcoesUF = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESUF_SEL") == 0 )
            {
               AV23TFSerasaAcoesUF_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESPRINCIPAL") == 0 )
            {
               AV24TFSerasaAcoesPrincipal = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESPRINCIPAL_SEL") == 0 )
            {
               AV25TFSerasaAcoesPrincipal_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESTIPOMOEDA") == 0 )
            {
               AV26TFSerasaAcoesTipoMoeda = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESTIPOMOEDA_SEL") == 0 )
            {
               AV27TFSerasaAcoesTipoMoeda_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFSERASAACOESQTDOCO") == 0 )
            {
               AV28TFSerasaAcoesQtdOco = (short)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV29TFSerasaAcoesQtdOco_To = (short)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "PARM_&SERASAID") == 0 )
            {
               AV52SerasaId = (int)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSERASAACOESNATUREZAOPTIONS' Routine */
         returnInSub = false;
         AV12TFSerasaAcoesNatureza = AV30SearchTxt;
         AV13TFSerasaAcoesNatureza_Sel = "";
         AV55Serasaacoeswwds_1_serasaid = AV52SerasaId;
         AV56Serasaacoeswwds_2_tfserasaacoesdata = AV10TFSerasaAcoesData;
         AV57Serasaacoeswwds_3_tfserasaacoesdata_to = AV11TFSerasaAcoesData_To;
         AV58Serasaacoeswwds_4_tfserasaacoesnatureza = AV12TFSerasaAcoesNatureza;
         AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV13TFSerasaAcoesNatureza_Sel;
         AV60Serasaacoeswwds_6_tfserasaacoesvalor = AV14TFSerasaAcoesValor;
         AV61Serasaacoeswwds_7_tfserasaacoesvalor_to = AV15TFSerasaAcoesValor_To;
         AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV16TFSerasaAcoesDistribuidor;
         AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV17TFSerasaAcoesDistribuidor_Sel;
         AV64Serasaacoeswwds_10_tfserasaacoesvara = AV18TFSerasaAcoesVara;
         AV65Serasaacoeswwds_11_tfserasaacoesvara_sel = AV19TFSerasaAcoesVara_Sel;
         AV66Serasaacoeswwds_12_tfserasaacoescidade = AV20TFSerasaAcoesCidade;
         AV67Serasaacoeswwds_13_tfserasaacoescidade_sel = AV21TFSerasaAcoesCidade_Sel;
         AV68Serasaacoeswwds_14_tfserasaacoesuf = AV22TFSerasaAcoesUF;
         AV69Serasaacoeswwds_15_tfserasaacoesuf_sel = AV23TFSerasaAcoesUF_Sel;
         AV70Serasaacoeswwds_16_tfserasaacoesprincipal = AV24TFSerasaAcoesPrincipal;
         AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV25TFSerasaAcoesPrincipal_Sel;
         AV72Serasaacoeswwds_18_tfserasaacoestipomoeda = AV26TFSerasaAcoesTipoMoeda;
         AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV27TFSerasaAcoesTipoMoeda_Sel;
         AV74Serasaacoeswwds_20_tfserasaacoesqtdoco = AV28TFSerasaAcoesQtdOco;
         AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV29TFSerasaAcoesQtdOco_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                              AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                              AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                              AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                              AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                              AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                              AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                              AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                              AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                              AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                              AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                              AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                              AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                              AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                              AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                              AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                              AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                              AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                              AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                              AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                              A700SerasaAcoesData ,
                                              A701SerasaAcoesNatureza ,
                                              A702SerasaAcoesValor ,
                                              A703SerasaAcoesDistribuidor ,
                                              A704SerasaAcoesVara ,
                                              A705SerasaAcoesCidade ,
                                              A706SerasaAcoesUF ,
                                              A707SerasaAcoesPrincipal ,
                                              A708SerasaAcoesTipoMoeda ,
                                              A709SerasaAcoesQtdOco ,
                                              AV55Serasaacoeswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Serasaacoeswwds_4_tfserasaacoesnatureza = StringUtil.Concat( StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza), "%", "");
         lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = StringUtil.Concat( StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor), "%", "");
         lV64Serasaacoeswwds_10_tfserasaacoesvara = StringUtil.Concat( StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara), "%", "");
         lV66Serasaacoeswwds_12_tfserasaacoescidade = StringUtil.Concat( StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade), "%", "");
         lV68Serasaacoeswwds_14_tfserasaacoesuf = StringUtil.Concat( StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf), "%", "");
         lV70Serasaacoeswwds_16_tfserasaacoesprincipal = StringUtil.Concat( StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal), "%", "");
         lV72Serasaacoeswwds_18_tfserasaacoestipomoeda = StringUtil.Concat( StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda), "%", "");
         /* Using cursor P00D32 */
         pr_default.execute(0, new Object[] {AV55Serasaacoeswwds_1_serasaid, AV56Serasaacoeswwds_2_tfserasaacoesdata, AV57Serasaacoeswwds_3_tfserasaacoesdata_to, lV58Serasaacoeswwds_4_tfserasaacoesnatureza, AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, AV60Serasaacoeswwds_6_tfserasaacoesvalor, AV61Serasaacoeswwds_7_tfserasaacoesvalor_to, lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor, AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, lV64Serasaacoeswwds_10_tfserasaacoesvara, AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, lV66Serasaacoeswwds_12_tfserasaacoescidade, AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, lV68Serasaacoeswwds_14_tfserasaacoesuf, AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, lV70Serasaacoeswwds_16_tfserasaacoesprincipal, AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, lV72Serasaacoeswwds_18_tfserasaacoestipomoeda, AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, AV74Serasaacoeswwds_20_tfserasaacoesqtdoco, AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKD32 = false;
            A662SerasaId = P00D32_A662SerasaId[0];
            n662SerasaId = P00D32_n662SerasaId[0];
            A701SerasaAcoesNatureza = P00D32_A701SerasaAcoesNatureza[0];
            n701SerasaAcoesNatureza = P00D32_n701SerasaAcoesNatureza[0];
            A709SerasaAcoesQtdOco = P00D32_A709SerasaAcoesQtdOco[0];
            n709SerasaAcoesQtdOco = P00D32_n709SerasaAcoesQtdOco[0];
            A708SerasaAcoesTipoMoeda = P00D32_A708SerasaAcoesTipoMoeda[0];
            n708SerasaAcoesTipoMoeda = P00D32_n708SerasaAcoesTipoMoeda[0];
            A707SerasaAcoesPrincipal = P00D32_A707SerasaAcoesPrincipal[0];
            n707SerasaAcoesPrincipal = P00D32_n707SerasaAcoesPrincipal[0];
            A706SerasaAcoesUF = P00D32_A706SerasaAcoesUF[0];
            n706SerasaAcoesUF = P00D32_n706SerasaAcoesUF[0];
            A705SerasaAcoesCidade = P00D32_A705SerasaAcoesCidade[0];
            n705SerasaAcoesCidade = P00D32_n705SerasaAcoesCidade[0];
            A704SerasaAcoesVara = P00D32_A704SerasaAcoesVara[0];
            n704SerasaAcoesVara = P00D32_n704SerasaAcoesVara[0];
            A703SerasaAcoesDistribuidor = P00D32_A703SerasaAcoesDistribuidor[0];
            n703SerasaAcoesDistribuidor = P00D32_n703SerasaAcoesDistribuidor[0];
            A702SerasaAcoesValor = P00D32_A702SerasaAcoesValor[0];
            n702SerasaAcoesValor = P00D32_n702SerasaAcoesValor[0];
            A700SerasaAcoesData = P00D32_A700SerasaAcoesData[0];
            n700SerasaAcoesData = P00D32_n700SerasaAcoesData[0];
            A699SerasaAcoesId = P00D32_A699SerasaAcoesId[0];
            AV40count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00D32_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D32_A701SerasaAcoesNatureza[0], A701SerasaAcoesNatureza) == 0 ) )
            {
               BRKD32 = false;
               A699SerasaAcoesId = P00D32_A699SerasaAcoesId[0];
               AV40count = (long)(AV40count+1);
               BRKD32 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A701SerasaAcoesNatureza)) ? "<#Empty#>" : A701SerasaAcoesNatureza);
               AV36Options.Add(AV35Option, 0);
               AV39OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV36Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV31SkipItems = (short)(AV31SkipItems-1);
            }
            if ( ! BRKD32 )
            {
               BRKD32 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSERASAACOESDISTRIBUIDOROPTIONS' Routine */
         returnInSub = false;
         AV16TFSerasaAcoesDistribuidor = AV30SearchTxt;
         AV17TFSerasaAcoesDistribuidor_Sel = "";
         AV55Serasaacoeswwds_1_serasaid = AV52SerasaId;
         AV56Serasaacoeswwds_2_tfserasaacoesdata = AV10TFSerasaAcoesData;
         AV57Serasaacoeswwds_3_tfserasaacoesdata_to = AV11TFSerasaAcoesData_To;
         AV58Serasaacoeswwds_4_tfserasaacoesnatureza = AV12TFSerasaAcoesNatureza;
         AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV13TFSerasaAcoesNatureza_Sel;
         AV60Serasaacoeswwds_6_tfserasaacoesvalor = AV14TFSerasaAcoesValor;
         AV61Serasaacoeswwds_7_tfserasaacoesvalor_to = AV15TFSerasaAcoesValor_To;
         AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV16TFSerasaAcoesDistribuidor;
         AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV17TFSerasaAcoesDistribuidor_Sel;
         AV64Serasaacoeswwds_10_tfserasaacoesvara = AV18TFSerasaAcoesVara;
         AV65Serasaacoeswwds_11_tfserasaacoesvara_sel = AV19TFSerasaAcoesVara_Sel;
         AV66Serasaacoeswwds_12_tfserasaacoescidade = AV20TFSerasaAcoesCidade;
         AV67Serasaacoeswwds_13_tfserasaacoescidade_sel = AV21TFSerasaAcoesCidade_Sel;
         AV68Serasaacoeswwds_14_tfserasaacoesuf = AV22TFSerasaAcoesUF;
         AV69Serasaacoeswwds_15_tfserasaacoesuf_sel = AV23TFSerasaAcoesUF_Sel;
         AV70Serasaacoeswwds_16_tfserasaacoesprincipal = AV24TFSerasaAcoesPrincipal;
         AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV25TFSerasaAcoesPrincipal_Sel;
         AV72Serasaacoeswwds_18_tfserasaacoestipomoeda = AV26TFSerasaAcoesTipoMoeda;
         AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV27TFSerasaAcoesTipoMoeda_Sel;
         AV74Serasaacoeswwds_20_tfserasaacoesqtdoco = AV28TFSerasaAcoesQtdOco;
         AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV29TFSerasaAcoesQtdOco_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                              AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                              AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                              AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                              AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                              AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                              AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                              AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                              AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                              AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                              AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                              AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                              AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                              AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                              AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                              AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                              AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                              AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                              AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                              AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                              A700SerasaAcoesData ,
                                              A701SerasaAcoesNatureza ,
                                              A702SerasaAcoesValor ,
                                              A703SerasaAcoesDistribuidor ,
                                              A704SerasaAcoesVara ,
                                              A705SerasaAcoesCidade ,
                                              A706SerasaAcoesUF ,
                                              A707SerasaAcoesPrincipal ,
                                              A708SerasaAcoesTipoMoeda ,
                                              A709SerasaAcoesQtdOco ,
                                              AV55Serasaacoeswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Serasaacoeswwds_4_tfserasaacoesnatureza = StringUtil.Concat( StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza), "%", "");
         lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = StringUtil.Concat( StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor), "%", "");
         lV64Serasaacoeswwds_10_tfserasaacoesvara = StringUtil.Concat( StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara), "%", "");
         lV66Serasaacoeswwds_12_tfserasaacoescidade = StringUtil.Concat( StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade), "%", "");
         lV68Serasaacoeswwds_14_tfserasaacoesuf = StringUtil.Concat( StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf), "%", "");
         lV70Serasaacoeswwds_16_tfserasaacoesprincipal = StringUtil.Concat( StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal), "%", "");
         lV72Serasaacoeswwds_18_tfserasaacoestipomoeda = StringUtil.Concat( StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda), "%", "");
         /* Using cursor P00D33 */
         pr_default.execute(1, new Object[] {AV55Serasaacoeswwds_1_serasaid, AV56Serasaacoeswwds_2_tfserasaacoesdata, AV57Serasaacoeswwds_3_tfserasaacoesdata_to, lV58Serasaacoeswwds_4_tfserasaacoesnatureza, AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, AV60Serasaacoeswwds_6_tfserasaacoesvalor, AV61Serasaacoeswwds_7_tfserasaacoesvalor_to, lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor, AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, lV64Serasaacoeswwds_10_tfserasaacoesvara, AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, lV66Serasaacoeswwds_12_tfserasaacoescidade, AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, lV68Serasaacoeswwds_14_tfserasaacoesuf, AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, lV70Serasaacoeswwds_16_tfserasaacoesprincipal, AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, lV72Serasaacoeswwds_18_tfserasaacoestipomoeda, AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, AV74Serasaacoeswwds_20_tfserasaacoesqtdoco, AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKD34 = false;
            A662SerasaId = P00D33_A662SerasaId[0];
            n662SerasaId = P00D33_n662SerasaId[0];
            A703SerasaAcoesDistribuidor = P00D33_A703SerasaAcoesDistribuidor[0];
            n703SerasaAcoesDistribuidor = P00D33_n703SerasaAcoesDistribuidor[0];
            A709SerasaAcoesQtdOco = P00D33_A709SerasaAcoesQtdOco[0];
            n709SerasaAcoesQtdOco = P00D33_n709SerasaAcoesQtdOco[0];
            A708SerasaAcoesTipoMoeda = P00D33_A708SerasaAcoesTipoMoeda[0];
            n708SerasaAcoesTipoMoeda = P00D33_n708SerasaAcoesTipoMoeda[0];
            A707SerasaAcoesPrincipal = P00D33_A707SerasaAcoesPrincipal[0];
            n707SerasaAcoesPrincipal = P00D33_n707SerasaAcoesPrincipal[0];
            A706SerasaAcoesUF = P00D33_A706SerasaAcoesUF[0];
            n706SerasaAcoesUF = P00D33_n706SerasaAcoesUF[0];
            A705SerasaAcoesCidade = P00D33_A705SerasaAcoesCidade[0];
            n705SerasaAcoesCidade = P00D33_n705SerasaAcoesCidade[0];
            A704SerasaAcoesVara = P00D33_A704SerasaAcoesVara[0];
            n704SerasaAcoesVara = P00D33_n704SerasaAcoesVara[0];
            A702SerasaAcoesValor = P00D33_A702SerasaAcoesValor[0];
            n702SerasaAcoesValor = P00D33_n702SerasaAcoesValor[0];
            A701SerasaAcoesNatureza = P00D33_A701SerasaAcoesNatureza[0];
            n701SerasaAcoesNatureza = P00D33_n701SerasaAcoesNatureza[0];
            A700SerasaAcoesData = P00D33_A700SerasaAcoesData[0];
            n700SerasaAcoesData = P00D33_n700SerasaAcoesData[0];
            A699SerasaAcoesId = P00D33_A699SerasaAcoesId[0];
            AV40count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00D33_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D33_A703SerasaAcoesDistribuidor[0], A703SerasaAcoesDistribuidor) == 0 ) )
            {
               BRKD34 = false;
               A699SerasaAcoesId = P00D33_A699SerasaAcoesId[0];
               AV40count = (long)(AV40count+1);
               BRKD34 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A703SerasaAcoesDistribuidor)) ? "<#Empty#>" : A703SerasaAcoesDistribuidor);
               AV36Options.Add(AV35Option, 0);
               AV39OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV36Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV31SkipItems = (short)(AV31SkipItems-1);
            }
            if ( ! BRKD34 )
            {
               BRKD34 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSERASAACOESVARAOPTIONS' Routine */
         returnInSub = false;
         AV18TFSerasaAcoesVara = AV30SearchTxt;
         AV19TFSerasaAcoesVara_Sel = "";
         AV55Serasaacoeswwds_1_serasaid = AV52SerasaId;
         AV56Serasaacoeswwds_2_tfserasaacoesdata = AV10TFSerasaAcoesData;
         AV57Serasaacoeswwds_3_tfserasaacoesdata_to = AV11TFSerasaAcoesData_To;
         AV58Serasaacoeswwds_4_tfserasaacoesnatureza = AV12TFSerasaAcoesNatureza;
         AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV13TFSerasaAcoesNatureza_Sel;
         AV60Serasaacoeswwds_6_tfserasaacoesvalor = AV14TFSerasaAcoesValor;
         AV61Serasaacoeswwds_7_tfserasaacoesvalor_to = AV15TFSerasaAcoesValor_To;
         AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV16TFSerasaAcoesDistribuidor;
         AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV17TFSerasaAcoesDistribuidor_Sel;
         AV64Serasaacoeswwds_10_tfserasaacoesvara = AV18TFSerasaAcoesVara;
         AV65Serasaacoeswwds_11_tfserasaacoesvara_sel = AV19TFSerasaAcoesVara_Sel;
         AV66Serasaacoeswwds_12_tfserasaacoescidade = AV20TFSerasaAcoesCidade;
         AV67Serasaacoeswwds_13_tfserasaacoescidade_sel = AV21TFSerasaAcoesCidade_Sel;
         AV68Serasaacoeswwds_14_tfserasaacoesuf = AV22TFSerasaAcoesUF;
         AV69Serasaacoeswwds_15_tfserasaacoesuf_sel = AV23TFSerasaAcoesUF_Sel;
         AV70Serasaacoeswwds_16_tfserasaacoesprincipal = AV24TFSerasaAcoesPrincipal;
         AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV25TFSerasaAcoesPrincipal_Sel;
         AV72Serasaacoeswwds_18_tfserasaacoestipomoeda = AV26TFSerasaAcoesTipoMoeda;
         AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV27TFSerasaAcoesTipoMoeda_Sel;
         AV74Serasaacoeswwds_20_tfserasaacoesqtdoco = AV28TFSerasaAcoesQtdOco;
         AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV29TFSerasaAcoesQtdOco_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                              AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                              AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                              AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                              AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                              AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                              AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                              AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                              AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                              AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                              AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                              AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                              AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                              AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                              AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                              AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                              AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                              AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                              AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                              AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                              A700SerasaAcoesData ,
                                              A701SerasaAcoesNatureza ,
                                              A702SerasaAcoesValor ,
                                              A703SerasaAcoesDistribuidor ,
                                              A704SerasaAcoesVara ,
                                              A705SerasaAcoesCidade ,
                                              A706SerasaAcoesUF ,
                                              A707SerasaAcoesPrincipal ,
                                              A708SerasaAcoesTipoMoeda ,
                                              A709SerasaAcoesQtdOco ,
                                              AV55Serasaacoeswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Serasaacoeswwds_4_tfserasaacoesnatureza = StringUtil.Concat( StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza), "%", "");
         lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = StringUtil.Concat( StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor), "%", "");
         lV64Serasaacoeswwds_10_tfserasaacoesvara = StringUtil.Concat( StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara), "%", "");
         lV66Serasaacoeswwds_12_tfserasaacoescidade = StringUtil.Concat( StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade), "%", "");
         lV68Serasaacoeswwds_14_tfserasaacoesuf = StringUtil.Concat( StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf), "%", "");
         lV70Serasaacoeswwds_16_tfserasaacoesprincipal = StringUtil.Concat( StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal), "%", "");
         lV72Serasaacoeswwds_18_tfserasaacoestipomoeda = StringUtil.Concat( StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda), "%", "");
         /* Using cursor P00D34 */
         pr_default.execute(2, new Object[] {AV55Serasaacoeswwds_1_serasaid, AV56Serasaacoeswwds_2_tfserasaacoesdata, AV57Serasaacoeswwds_3_tfserasaacoesdata_to, lV58Serasaacoeswwds_4_tfserasaacoesnatureza, AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, AV60Serasaacoeswwds_6_tfserasaacoesvalor, AV61Serasaacoeswwds_7_tfserasaacoesvalor_to, lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor, AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, lV64Serasaacoeswwds_10_tfserasaacoesvara, AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, lV66Serasaacoeswwds_12_tfserasaacoescidade, AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, lV68Serasaacoeswwds_14_tfserasaacoesuf, AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, lV70Serasaacoeswwds_16_tfserasaacoesprincipal, AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, lV72Serasaacoeswwds_18_tfserasaacoestipomoeda, AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, AV74Serasaacoeswwds_20_tfserasaacoesqtdoco, AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKD36 = false;
            A662SerasaId = P00D34_A662SerasaId[0];
            n662SerasaId = P00D34_n662SerasaId[0];
            A704SerasaAcoesVara = P00D34_A704SerasaAcoesVara[0];
            n704SerasaAcoesVara = P00D34_n704SerasaAcoesVara[0];
            A709SerasaAcoesQtdOco = P00D34_A709SerasaAcoesQtdOco[0];
            n709SerasaAcoesQtdOco = P00D34_n709SerasaAcoesQtdOco[0];
            A708SerasaAcoesTipoMoeda = P00D34_A708SerasaAcoesTipoMoeda[0];
            n708SerasaAcoesTipoMoeda = P00D34_n708SerasaAcoesTipoMoeda[0];
            A707SerasaAcoesPrincipal = P00D34_A707SerasaAcoesPrincipal[0];
            n707SerasaAcoesPrincipal = P00D34_n707SerasaAcoesPrincipal[0];
            A706SerasaAcoesUF = P00D34_A706SerasaAcoesUF[0];
            n706SerasaAcoesUF = P00D34_n706SerasaAcoesUF[0];
            A705SerasaAcoesCidade = P00D34_A705SerasaAcoesCidade[0];
            n705SerasaAcoesCidade = P00D34_n705SerasaAcoesCidade[0];
            A703SerasaAcoesDistribuidor = P00D34_A703SerasaAcoesDistribuidor[0];
            n703SerasaAcoesDistribuidor = P00D34_n703SerasaAcoesDistribuidor[0];
            A702SerasaAcoesValor = P00D34_A702SerasaAcoesValor[0];
            n702SerasaAcoesValor = P00D34_n702SerasaAcoesValor[0];
            A701SerasaAcoesNatureza = P00D34_A701SerasaAcoesNatureza[0];
            n701SerasaAcoesNatureza = P00D34_n701SerasaAcoesNatureza[0];
            A700SerasaAcoesData = P00D34_A700SerasaAcoesData[0];
            n700SerasaAcoesData = P00D34_n700SerasaAcoesData[0];
            A699SerasaAcoesId = P00D34_A699SerasaAcoesId[0];
            AV40count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00D34_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D34_A704SerasaAcoesVara[0], A704SerasaAcoesVara) == 0 ) )
            {
               BRKD36 = false;
               A699SerasaAcoesId = P00D34_A699SerasaAcoesId[0];
               AV40count = (long)(AV40count+1);
               BRKD36 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A704SerasaAcoesVara)) ? "<#Empty#>" : A704SerasaAcoesVara);
               AV36Options.Add(AV35Option, 0);
               AV39OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV36Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV31SkipItems = (short)(AV31SkipItems-1);
            }
            if ( ! BRKD36 )
            {
               BRKD36 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSERASAACOESCIDADEOPTIONS' Routine */
         returnInSub = false;
         AV20TFSerasaAcoesCidade = AV30SearchTxt;
         AV21TFSerasaAcoesCidade_Sel = "";
         AV55Serasaacoeswwds_1_serasaid = AV52SerasaId;
         AV56Serasaacoeswwds_2_tfserasaacoesdata = AV10TFSerasaAcoesData;
         AV57Serasaacoeswwds_3_tfserasaacoesdata_to = AV11TFSerasaAcoesData_To;
         AV58Serasaacoeswwds_4_tfserasaacoesnatureza = AV12TFSerasaAcoesNatureza;
         AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV13TFSerasaAcoesNatureza_Sel;
         AV60Serasaacoeswwds_6_tfserasaacoesvalor = AV14TFSerasaAcoesValor;
         AV61Serasaacoeswwds_7_tfserasaacoesvalor_to = AV15TFSerasaAcoesValor_To;
         AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV16TFSerasaAcoesDistribuidor;
         AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV17TFSerasaAcoesDistribuidor_Sel;
         AV64Serasaacoeswwds_10_tfserasaacoesvara = AV18TFSerasaAcoesVara;
         AV65Serasaacoeswwds_11_tfserasaacoesvara_sel = AV19TFSerasaAcoesVara_Sel;
         AV66Serasaacoeswwds_12_tfserasaacoescidade = AV20TFSerasaAcoesCidade;
         AV67Serasaacoeswwds_13_tfserasaacoescidade_sel = AV21TFSerasaAcoesCidade_Sel;
         AV68Serasaacoeswwds_14_tfserasaacoesuf = AV22TFSerasaAcoesUF;
         AV69Serasaacoeswwds_15_tfserasaacoesuf_sel = AV23TFSerasaAcoesUF_Sel;
         AV70Serasaacoeswwds_16_tfserasaacoesprincipal = AV24TFSerasaAcoesPrincipal;
         AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV25TFSerasaAcoesPrincipal_Sel;
         AV72Serasaacoeswwds_18_tfserasaacoestipomoeda = AV26TFSerasaAcoesTipoMoeda;
         AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV27TFSerasaAcoesTipoMoeda_Sel;
         AV74Serasaacoeswwds_20_tfserasaacoesqtdoco = AV28TFSerasaAcoesQtdOco;
         AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV29TFSerasaAcoesQtdOco_To;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                              AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                              AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                              AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                              AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                              AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                              AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                              AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                              AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                              AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                              AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                              AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                              AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                              AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                              AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                              AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                              AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                              AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                              AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                              AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                              A700SerasaAcoesData ,
                                              A701SerasaAcoesNatureza ,
                                              A702SerasaAcoesValor ,
                                              A703SerasaAcoesDistribuidor ,
                                              A704SerasaAcoesVara ,
                                              A705SerasaAcoesCidade ,
                                              A706SerasaAcoesUF ,
                                              A707SerasaAcoesPrincipal ,
                                              A708SerasaAcoesTipoMoeda ,
                                              A709SerasaAcoesQtdOco ,
                                              AV55Serasaacoeswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Serasaacoeswwds_4_tfserasaacoesnatureza = StringUtil.Concat( StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza), "%", "");
         lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = StringUtil.Concat( StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor), "%", "");
         lV64Serasaacoeswwds_10_tfserasaacoesvara = StringUtil.Concat( StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara), "%", "");
         lV66Serasaacoeswwds_12_tfserasaacoescidade = StringUtil.Concat( StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade), "%", "");
         lV68Serasaacoeswwds_14_tfserasaacoesuf = StringUtil.Concat( StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf), "%", "");
         lV70Serasaacoeswwds_16_tfserasaacoesprincipal = StringUtil.Concat( StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal), "%", "");
         lV72Serasaacoeswwds_18_tfserasaacoestipomoeda = StringUtil.Concat( StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda), "%", "");
         /* Using cursor P00D35 */
         pr_default.execute(3, new Object[] {AV55Serasaacoeswwds_1_serasaid, AV56Serasaacoeswwds_2_tfserasaacoesdata, AV57Serasaacoeswwds_3_tfserasaacoesdata_to, lV58Serasaacoeswwds_4_tfserasaacoesnatureza, AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, AV60Serasaacoeswwds_6_tfserasaacoesvalor, AV61Serasaacoeswwds_7_tfserasaacoesvalor_to, lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor, AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, lV64Serasaacoeswwds_10_tfserasaacoesvara, AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, lV66Serasaacoeswwds_12_tfserasaacoescidade, AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, lV68Serasaacoeswwds_14_tfserasaacoesuf, AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, lV70Serasaacoeswwds_16_tfserasaacoesprincipal, AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, lV72Serasaacoeswwds_18_tfserasaacoestipomoeda, AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, AV74Serasaacoeswwds_20_tfserasaacoesqtdoco, AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKD38 = false;
            A662SerasaId = P00D35_A662SerasaId[0];
            n662SerasaId = P00D35_n662SerasaId[0];
            A705SerasaAcoesCidade = P00D35_A705SerasaAcoesCidade[0];
            n705SerasaAcoesCidade = P00D35_n705SerasaAcoesCidade[0];
            A709SerasaAcoesQtdOco = P00D35_A709SerasaAcoesQtdOco[0];
            n709SerasaAcoesQtdOco = P00D35_n709SerasaAcoesQtdOco[0];
            A708SerasaAcoesTipoMoeda = P00D35_A708SerasaAcoesTipoMoeda[0];
            n708SerasaAcoesTipoMoeda = P00D35_n708SerasaAcoesTipoMoeda[0];
            A707SerasaAcoesPrincipal = P00D35_A707SerasaAcoesPrincipal[0];
            n707SerasaAcoesPrincipal = P00D35_n707SerasaAcoesPrincipal[0];
            A706SerasaAcoesUF = P00D35_A706SerasaAcoesUF[0];
            n706SerasaAcoesUF = P00D35_n706SerasaAcoesUF[0];
            A704SerasaAcoesVara = P00D35_A704SerasaAcoesVara[0];
            n704SerasaAcoesVara = P00D35_n704SerasaAcoesVara[0];
            A703SerasaAcoesDistribuidor = P00D35_A703SerasaAcoesDistribuidor[0];
            n703SerasaAcoesDistribuidor = P00D35_n703SerasaAcoesDistribuidor[0];
            A702SerasaAcoesValor = P00D35_A702SerasaAcoesValor[0];
            n702SerasaAcoesValor = P00D35_n702SerasaAcoesValor[0];
            A701SerasaAcoesNatureza = P00D35_A701SerasaAcoesNatureza[0];
            n701SerasaAcoesNatureza = P00D35_n701SerasaAcoesNatureza[0];
            A700SerasaAcoesData = P00D35_A700SerasaAcoesData[0];
            n700SerasaAcoesData = P00D35_n700SerasaAcoesData[0];
            A699SerasaAcoesId = P00D35_A699SerasaAcoesId[0];
            AV40count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( P00D35_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D35_A705SerasaAcoesCidade[0], A705SerasaAcoesCidade) == 0 ) )
            {
               BRKD38 = false;
               A699SerasaAcoesId = P00D35_A699SerasaAcoesId[0];
               AV40count = (long)(AV40count+1);
               BRKD38 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A705SerasaAcoesCidade)) ? "<#Empty#>" : A705SerasaAcoesCidade);
               AV36Options.Add(AV35Option, 0);
               AV39OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV36Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV31SkipItems = (short)(AV31SkipItems-1);
            }
            if ( ! BRKD38 )
            {
               BRKD38 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADSERASAACOESUFOPTIONS' Routine */
         returnInSub = false;
         AV22TFSerasaAcoesUF = AV30SearchTxt;
         AV23TFSerasaAcoesUF_Sel = "";
         AV55Serasaacoeswwds_1_serasaid = AV52SerasaId;
         AV56Serasaacoeswwds_2_tfserasaacoesdata = AV10TFSerasaAcoesData;
         AV57Serasaacoeswwds_3_tfserasaacoesdata_to = AV11TFSerasaAcoesData_To;
         AV58Serasaacoeswwds_4_tfserasaacoesnatureza = AV12TFSerasaAcoesNatureza;
         AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV13TFSerasaAcoesNatureza_Sel;
         AV60Serasaacoeswwds_6_tfserasaacoesvalor = AV14TFSerasaAcoesValor;
         AV61Serasaacoeswwds_7_tfserasaacoesvalor_to = AV15TFSerasaAcoesValor_To;
         AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV16TFSerasaAcoesDistribuidor;
         AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV17TFSerasaAcoesDistribuidor_Sel;
         AV64Serasaacoeswwds_10_tfserasaacoesvara = AV18TFSerasaAcoesVara;
         AV65Serasaacoeswwds_11_tfserasaacoesvara_sel = AV19TFSerasaAcoesVara_Sel;
         AV66Serasaacoeswwds_12_tfserasaacoescidade = AV20TFSerasaAcoesCidade;
         AV67Serasaacoeswwds_13_tfserasaacoescidade_sel = AV21TFSerasaAcoesCidade_Sel;
         AV68Serasaacoeswwds_14_tfserasaacoesuf = AV22TFSerasaAcoesUF;
         AV69Serasaacoeswwds_15_tfserasaacoesuf_sel = AV23TFSerasaAcoesUF_Sel;
         AV70Serasaacoeswwds_16_tfserasaacoesprincipal = AV24TFSerasaAcoesPrincipal;
         AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV25TFSerasaAcoesPrincipal_Sel;
         AV72Serasaacoeswwds_18_tfserasaacoestipomoeda = AV26TFSerasaAcoesTipoMoeda;
         AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV27TFSerasaAcoesTipoMoeda_Sel;
         AV74Serasaacoeswwds_20_tfserasaacoesqtdoco = AV28TFSerasaAcoesQtdOco;
         AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV29TFSerasaAcoesQtdOco_To;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                              AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                              AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                              AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                              AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                              AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                              AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                              AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                              AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                              AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                              AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                              AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                              AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                              AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                              AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                              AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                              AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                              AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                              AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                              AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                              A700SerasaAcoesData ,
                                              A701SerasaAcoesNatureza ,
                                              A702SerasaAcoesValor ,
                                              A703SerasaAcoesDistribuidor ,
                                              A704SerasaAcoesVara ,
                                              A705SerasaAcoesCidade ,
                                              A706SerasaAcoesUF ,
                                              A707SerasaAcoesPrincipal ,
                                              A708SerasaAcoesTipoMoeda ,
                                              A709SerasaAcoesQtdOco ,
                                              AV55Serasaacoeswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Serasaacoeswwds_4_tfserasaacoesnatureza = StringUtil.Concat( StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza), "%", "");
         lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = StringUtil.Concat( StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor), "%", "");
         lV64Serasaacoeswwds_10_tfserasaacoesvara = StringUtil.Concat( StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara), "%", "");
         lV66Serasaacoeswwds_12_tfserasaacoescidade = StringUtil.Concat( StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade), "%", "");
         lV68Serasaacoeswwds_14_tfserasaacoesuf = StringUtil.Concat( StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf), "%", "");
         lV70Serasaacoeswwds_16_tfserasaacoesprincipal = StringUtil.Concat( StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal), "%", "");
         lV72Serasaacoeswwds_18_tfserasaacoestipomoeda = StringUtil.Concat( StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda), "%", "");
         /* Using cursor P00D36 */
         pr_default.execute(4, new Object[] {AV55Serasaacoeswwds_1_serasaid, AV56Serasaacoeswwds_2_tfserasaacoesdata, AV57Serasaacoeswwds_3_tfserasaacoesdata_to, lV58Serasaacoeswwds_4_tfserasaacoesnatureza, AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, AV60Serasaacoeswwds_6_tfserasaacoesvalor, AV61Serasaacoeswwds_7_tfserasaacoesvalor_to, lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor, AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, lV64Serasaacoeswwds_10_tfserasaacoesvara, AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, lV66Serasaacoeswwds_12_tfserasaacoescidade, AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, lV68Serasaacoeswwds_14_tfserasaacoesuf, AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, lV70Serasaacoeswwds_16_tfserasaacoesprincipal, AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, lV72Serasaacoeswwds_18_tfserasaacoestipomoeda, AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, AV74Serasaacoeswwds_20_tfserasaacoesqtdoco, AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKD310 = false;
            A662SerasaId = P00D36_A662SerasaId[0];
            n662SerasaId = P00D36_n662SerasaId[0];
            A706SerasaAcoesUF = P00D36_A706SerasaAcoesUF[0];
            n706SerasaAcoesUF = P00D36_n706SerasaAcoesUF[0];
            A709SerasaAcoesQtdOco = P00D36_A709SerasaAcoesQtdOco[0];
            n709SerasaAcoesQtdOco = P00D36_n709SerasaAcoesQtdOco[0];
            A708SerasaAcoesTipoMoeda = P00D36_A708SerasaAcoesTipoMoeda[0];
            n708SerasaAcoesTipoMoeda = P00D36_n708SerasaAcoesTipoMoeda[0];
            A707SerasaAcoesPrincipal = P00D36_A707SerasaAcoesPrincipal[0];
            n707SerasaAcoesPrincipal = P00D36_n707SerasaAcoesPrincipal[0];
            A705SerasaAcoesCidade = P00D36_A705SerasaAcoesCidade[0];
            n705SerasaAcoesCidade = P00D36_n705SerasaAcoesCidade[0];
            A704SerasaAcoesVara = P00D36_A704SerasaAcoesVara[0];
            n704SerasaAcoesVara = P00D36_n704SerasaAcoesVara[0];
            A703SerasaAcoesDistribuidor = P00D36_A703SerasaAcoesDistribuidor[0];
            n703SerasaAcoesDistribuidor = P00D36_n703SerasaAcoesDistribuidor[0];
            A702SerasaAcoesValor = P00D36_A702SerasaAcoesValor[0];
            n702SerasaAcoesValor = P00D36_n702SerasaAcoesValor[0];
            A701SerasaAcoesNatureza = P00D36_A701SerasaAcoesNatureza[0];
            n701SerasaAcoesNatureza = P00D36_n701SerasaAcoesNatureza[0];
            A700SerasaAcoesData = P00D36_A700SerasaAcoesData[0];
            n700SerasaAcoesData = P00D36_n700SerasaAcoesData[0];
            A699SerasaAcoesId = P00D36_A699SerasaAcoesId[0];
            AV40count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( P00D36_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D36_A706SerasaAcoesUF[0], A706SerasaAcoesUF) == 0 ) )
            {
               BRKD310 = false;
               A699SerasaAcoesId = P00D36_A699SerasaAcoesId[0];
               AV40count = (long)(AV40count+1);
               BRKD310 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A706SerasaAcoesUF)) ? "<#Empty#>" : A706SerasaAcoesUF);
               AV36Options.Add(AV35Option, 0);
               AV39OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV36Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV31SkipItems = (short)(AV31SkipItems-1);
            }
            if ( ! BRKD310 )
            {
               BRKD310 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADSERASAACOESPRINCIPALOPTIONS' Routine */
         returnInSub = false;
         AV24TFSerasaAcoesPrincipal = AV30SearchTxt;
         AV25TFSerasaAcoesPrincipal_Sel = "";
         AV55Serasaacoeswwds_1_serasaid = AV52SerasaId;
         AV56Serasaacoeswwds_2_tfserasaacoesdata = AV10TFSerasaAcoesData;
         AV57Serasaacoeswwds_3_tfserasaacoesdata_to = AV11TFSerasaAcoesData_To;
         AV58Serasaacoeswwds_4_tfserasaacoesnatureza = AV12TFSerasaAcoesNatureza;
         AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV13TFSerasaAcoesNatureza_Sel;
         AV60Serasaacoeswwds_6_tfserasaacoesvalor = AV14TFSerasaAcoesValor;
         AV61Serasaacoeswwds_7_tfserasaacoesvalor_to = AV15TFSerasaAcoesValor_To;
         AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV16TFSerasaAcoesDistribuidor;
         AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV17TFSerasaAcoesDistribuidor_Sel;
         AV64Serasaacoeswwds_10_tfserasaacoesvara = AV18TFSerasaAcoesVara;
         AV65Serasaacoeswwds_11_tfserasaacoesvara_sel = AV19TFSerasaAcoesVara_Sel;
         AV66Serasaacoeswwds_12_tfserasaacoescidade = AV20TFSerasaAcoesCidade;
         AV67Serasaacoeswwds_13_tfserasaacoescidade_sel = AV21TFSerasaAcoesCidade_Sel;
         AV68Serasaacoeswwds_14_tfserasaacoesuf = AV22TFSerasaAcoesUF;
         AV69Serasaacoeswwds_15_tfserasaacoesuf_sel = AV23TFSerasaAcoesUF_Sel;
         AV70Serasaacoeswwds_16_tfserasaacoesprincipal = AV24TFSerasaAcoesPrincipal;
         AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV25TFSerasaAcoesPrincipal_Sel;
         AV72Serasaacoeswwds_18_tfserasaacoestipomoeda = AV26TFSerasaAcoesTipoMoeda;
         AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV27TFSerasaAcoesTipoMoeda_Sel;
         AV74Serasaacoeswwds_20_tfserasaacoesqtdoco = AV28TFSerasaAcoesQtdOco;
         AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV29TFSerasaAcoesQtdOco_To;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                              AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                              AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                              AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                              AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                              AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                              AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                              AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                              AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                              AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                              AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                              AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                              AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                              AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                              AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                              AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                              AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                              AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                              AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                              AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                              A700SerasaAcoesData ,
                                              A701SerasaAcoesNatureza ,
                                              A702SerasaAcoesValor ,
                                              A703SerasaAcoesDistribuidor ,
                                              A704SerasaAcoesVara ,
                                              A705SerasaAcoesCidade ,
                                              A706SerasaAcoesUF ,
                                              A707SerasaAcoesPrincipal ,
                                              A708SerasaAcoesTipoMoeda ,
                                              A709SerasaAcoesQtdOco ,
                                              AV55Serasaacoeswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Serasaacoeswwds_4_tfserasaacoesnatureza = StringUtil.Concat( StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza), "%", "");
         lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = StringUtil.Concat( StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor), "%", "");
         lV64Serasaacoeswwds_10_tfserasaacoesvara = StringUtil.Concat( StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara), "%", "");
         lV66Serasaacoeswwds_12_tfserasaacoescidade = StringUtil.Concat( StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade), "%", "");
         lV68Serasaacoeswwds_14_tfserasaacoesuf = StringUtil.Concat( StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf), "%", "");
         lV70Serasaacoeswwds_16_tfserasaacoesprincipal = StringUtil.Concat( StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal), "%", "");
         lV72Serasaacoeswwds_18_tfserasaacoestipomoeda = StringUtil.Concat( StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda), "%", "");
         /* Using cursor P00D37 */
         pr_default.execute(5, new Object[] {AV55Serasaacoeswwds_1_serasaid, AV56Serasaacoeswwds_2_tfserasaacoesdata, AV57Serasaacoeswwds_3_tfserasaacoesdata_to, lV58Serasaacoeswwds_4_tfserasaacoesnatureza, AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, AV60Serasaacoeswwds_6_tfserasaacoesvalor, AV61Serasaacoeswwds_7_tfserasaacoesvalor_to, lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor, AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, lV64Serasaacoeswwds_10_tfserasaacoesvara, AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, lV66Serasaacoeswwds_12_tfserasaacoescidade, AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, lV68Serasaacoeswwds_14_tfserasaacoesuf, AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, lV70Serasaacoeswwds_16_tfserasaacoesprincipal, AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, lV72Serasaacoeswwds_18_tfserasaacoestipomoeda, AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, AV74Serasaacoeswwds_20_tfserasaacoesqtdoco, AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKD312 = false;
            A662SerasaId = P00D37_A662SerasaId[0];
            n662SerasaId = P00D37_n662SerasaId[0];
            A707SerasaAcoesPrincipal = P00D37_A707SerasaAcoesPrincipal[0];
            n707SerasaAcoesPrincipal = P00D37_n707SerasaAcoesPrincipal[0];
            A709SerasaAcoesQtdOco = P00D37_A709SerasaAcoesQtdOco[0];
            n709SerasaAcoesQtdOco = P00D37_n709SerasaAcoesQtdOco[0];
            A708SerasaAcoesTipoMoeda = P00D37_A708SerasaAcoesTipoMoeda[0];
            n708SerasaAcoesTipoMoeda = P00D37_n708SerasaAcoesTipoMoeda[0];
            A706SerasaAcoesUF = P00D37_A706SerasaAcoesUF[0];
            n706SerasaAcoesUF = P00D37_n706SerasaAcoesUF[0];
            A705SerasaAcoesCidade = P00D37_A705SerasaAcoesCidade[0];
            n705SerasaAcoesCidade = P00D37_n705SerasaAcoesCidade[0];
            A704SerasaAcoesVara = P00D37_A704SerasaAcoesVara[0];
            n704SerasaAcoesVara = P00D37_n704SerasaAcoesVara[0];
            A703SerasaAcoesDistribuidor = P00D37_A703SerasaAcoesDistribuidor[0];
            n703SerasaAcoesDistribuidor = P00D37_n703SerasaAcoesDistribuidor[0];
            A702SerasaAcoesValor = P00D37_A702SerasaAcoesValor[0];
            n702SerasaAcoesValor = P00D37_n702SerasaAcoesValor[0];
            A701SerasaAcoesNatureza = P00D37_A701SerasaAcoesNatureza[0];
            n701SerasaAcoesNatureza = P00D37_n701SerasaAcoesNatureza[0];
            A700SerasaAcoesData = P00D37_A700SerasaAcoesData[0];
            n700SerasaAcoesData = P00D37_n700SerasaAcoesData[0];
            A699SerasaAcoesId = P00D37_A699SerasaAcoesId[0];
            AV40count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( P00D37_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D37_A707SerasaAcoesPrincipal[0], A707SerasaAcoesPrincipal) == 0 ) )
            {
               BRKD312 = false;
               A699SerasaAcoesId = P00D37_A699SerasaAcoesId[0];
               AV40count = (long)(AV40count+1);
               BRKD312 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A707SerasaAcoesPrincipal)) ? "<#Empty#>" : A707SerasaAcoesPrincipal);
               AV36Options.Add(AV35Option, 0);
               AV39OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV36Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV31SkipItems = (short)(AV31SkipItems-1);
            }
            if ( ! BRKD312 )
            {
               BRKD312 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADSERASAACOESTIPOMOEDAOPTIONS' Routine */
         returnInSub = false;
         AV26TFSerasaAcoesTipoMoeda = AV30SearchTxt;
         AV27TFSerasaAcoesTipoMoeda_Sel = "";
         AV55Serasaacoeswwds_1_serasaid = AV52SerasaId;
         AV56Serasaacoeswwds_2_tfserasaacoesdata = AV10TFSerasaAcoesData;
         AV57Serasaacoeswwds_3_tfserasaacoesdata_to = AV11TFSerasaAcoesData_To;
         AV58Serasaacoeswwds_4_tfserasaacoesnatureza = AV12TFSerasaAcoesNatureza;
         AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel = AV13TFSerasaAcoesNatureza_Sel;
         AV60Serasaacoeswwds_6_tfserasaacoesvalor = AV14TFSerasaAcoesValor;
         AV61Serasaacoeswwds_7_tfserasaacoesvalor_to = AV15TFSerasaAcoesValor_To;
         AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = AV16TFSerasaAcoesDistribuidor;
         AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = AV17TFSerasaAcoesDistribuidor_Sel;
         AV64Serasaacoeswwds_10_tfserasaacoesvara = AV18TFSerasaAcoesVara;
         AV65Serasaacoeswwds_11_tfserasaacoesvara_sel = AV19TFSerasaAcoesVara_Sel;
         AV66Serasaacoeswwds_12_tfserasaacoescidade = AV20TFSerasaAcoesCidade;
         AV67Serasaacoeswwds_13_tfserasaacoescidade_sel = AV21TFSerasaAcoesCidade_Sel;
         AV68Serasaacoeswwds_14_tfserasaacoesuf = AV22TFSerasaAcoesUF;
         AV69Serasaacoeswwds_15_tfserasaacoesuf_sel = AV23TFSerasaAcoesUF_Sel;
         AV70Serasaacoeswwds_16_tfserasaacoesprincipal = AV24TFSerasaAcoesPrincipal;
         AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel = AV25TFSerasaAcoesPrincipal_Sel;
         AV72Serasaacoeswwds_18_tfserasaacoestipomoeda = AV26TFSerasaAcoesTipoMoeda;
         AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = AV27TFSerasaAcoesTipoMoeda_Sel;
         AV74Serasaacoeswwds_20_tfserasaacoesqtdoco = AV28TFSerasaAcoesQtdOco;
         AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to = AV29TFSerasaAcoesQtdOco_To;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                              AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                              AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                              AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                              AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                              AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                              AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                              AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                              AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                              AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                              AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                              AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                              AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                              AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                              AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                              AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                              AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                              AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                              AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                              AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                              A700SerasaAcoesData ,
                                              A701SerasaAcoesNatureza ,
                                              A702SerasaAcoesValor ,
                                              A703SerasaAcoesDistribuidor ,
                                              A704SerasaAcoesVara ,
                                              A705SerasaAcoesCidade ,
                                              A706SerasaAcoesUF ,
                                              A707SerasaAcoesPrincipal ,
                                              A708SerasaAcoesTipoMoeda ,
                                              A709SerasaAcoesQtdOco ,
                                              AV55Serasaacoeswwds_1_serasaid ,
                                              A662SerasaId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV58Serasaacoeswwds_4_tfserasaacoesnatureza = StringUtil.Concat( StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza), "%", "");
         lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = StringUtil.Concat( StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor), "%", "");
         lV64Serasaacoeswwds_10_tfserasaacoesvara = StringUtil.Concat( StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara), "%", "");
         lV66Serasaacoeswwds_12_tfserasaacoescidade = StringUtil.Concat( StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade), "%", "");
         lV68Serasaacoeswwds_14_tfserasaacoesuf = StringUtil.Concat( StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf), "%", "");
         lV70Serasaacoeswwds_16_tfserasaacoesprincipal = StringUtil.Concat( StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal), "%", "");
         lV72Serasaacoeswwds_18_tfserasaacoestipomoeda = StringUtil.Concat( StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda), "%", "");
         /* Using cursor P00D38 */
         pr_default.execute(6, new Object[] {AV55Serasaacoeswwds_1_serasaid, AV56Serasaacoeswwds_2_tfserasaacoesdata, AV57Serasaacoeswwds_3_tfserasaacoesdata_to, lV58Serasaacoeswwds_4_tfserasaacoesnatureza, AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, AV60Serasaacoeswwds_6_tfserasaacoesvalor, AV61Serasaacoeswwds_7_tfserasaacoesvalor_to, lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor, AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, lV64Serasaacoeswwds_10_tfserasaacoesvara, AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, lV66Serasaacoeswwds_12_tfserasaacoescidade, AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, lV68Serasaacoeswwds_14_tfserasaacoesuf, AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, lV70Serasaacoeswwds_16_tfserasaacoesprincipal, AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, lV72Serasaacoeswwds_18_tfserasaacoestipomoeda, AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, AV74Serasaacoeswwds_20_tfserasaacoesqtdoco, AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRKD314 = false;
            A662SerasaId = P00D38_A662SerasaId[0];
            n662SerasaId = P00D38_n662SerasaId[0];
            A708SerasaAcoesTipoMoeda = P00D38_A708SerasaAcoesTipoMoeda[0];
            n708SerasaAcoesTipoMoeda = P00D38_n708SerasaAcoesTipoMoeda[0];
            A709SerasaAcoesQtdOco = P00D38_A709SerasaAcoesQtdOco[0];
            n709SerasaAcoesQtdOco = P00D38_n709SerasaAcoesQtdOco[0];
            A707SerasaAcoesPrincipal = P00D38_A707SerasaAcoesPrincipal[0];
            n707SerasaAcoesPrincipal = P00D38_n707SerasaAcoesPrincipal[0];
            A706SerasaAcoesUF = P00D38_A706SerasaAcoesUF[0];
            n706SerasaAcoesUF = P00D38_n706SerasaAcoesUF[0];
            A705SerasaAcoesCidade = P00D38_A705SerasaAcoesCidade[0];
            n705SerasaAcoesCidade = P00D38_n705SerasaAcoesCidade[0];
            A704SerasaAcoesVara = P00D38_A704SerasaAcoesVara[0];
            n704SerasaAcoesVara = P00D38_n704SerasaAcoesVara[0];
            A703SerasaAcoesDistribuidor = P00D38_A703SerasaAcoesDistribuidor[0];
            n703SerasaAcoesDistribuidor = P00D38_n703SerasaAcoesDistribuidor[0];
            A702SerasaAcoesValor = P00D38_A702SerasaAcoesValor[0];
            n702SerasaAcoesValor = P00D38_n702SerasaAcoesValor[0];
            A701SerasaAcoesNatureza = P00D38_A701SerasaAcoesNatureza[0];
            n701SerasaAcoesNatureza = P00D38_n701SerasaAcoesNatureza[0];
            A700SerasaAcoesData = P00D38_A700SerasaAcoesData[0];
            n700SerasaAcoesData = P00D38_n700SerasaAcoesData[0];
            A699SerasaAcoesId = P00D38_A699SerasaAcoesId[0];
            AV40count = 0;
            while ( (pr_default.getStatus(6) != 101) && ( P00D38_A662SerasaId[0] == A662SerasaId ) && ( StringUtil.StrCmp(P00D38_A708SerasaAcoesTipoMoeda[0], A708SerasaAcoesTipoMoeda) == 0 ) )
            {
               BRKD314 = false;
               A699SerasaAcoesId = P00D38_A699SerasaAcoesId[0];
               AV40count = (long)(AV40count+1);
               BRKD314 = true;
               pr_default.readNext(6);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A708SerasaAcoesTipoMoeda)) ? "<#Empty#>" : A708SerasaAcoesTipoMoeda);
               AV36Options.Add(AV35Option, 0);
               AV39OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV36Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV31SkipItems = (short)(AV31SkipItems-1);
            }
            if ( ! BRKD314 )
            {
               BRKD314 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
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
         AV49OptionsJson = "";
         AV50OptionsDescJson = "";
         AV51OptionIndexesJson = "";
         AV36Options = new GxSimpleCollection<string>();
         AV38OptionsDesc = new GxSimpleCollection<string>();
         AV39OptionIndexes = new GxSimpleCollection<string>();
         AV30SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV41Session = context.GetSession();
         AV43GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV44GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFSerasaAcoesData = DateTime.MinValue;
         AV11TFSerasaAcoesData_To = DateTime.MinValue;
         AV12TFSerasaAcoesNatureza = "";
         AV13TFSerasaAcoesNatureza_Sel = "";
         AV16TFSerasaAcoesDistribuidor = "";
         AV17TFSerasaAcoesDistribuidor_Sel = "";
         AV18TFSerasaAcoesVara = "";
         AV19TFSerasaAcoesVara_Sel = "";
         AV20TFSerasaAcoesCidade = "";
         AV21TFSerasaAcoesCidade_Sel = "";
         AV22TFSerasaAcoesUF = "";
         AV23TFSerasaAcoesUF_Sel = "";
         AV24TFSerasaAcoesPrincipal = "";
         AV25TFSerasaAcoesPrincipal_Sel = "";
         AV26TFSerasaAcoesTipoMoeda = "";
         AV27TFSerasaAcoesTipoMoeda_Sel = "";
         AV56Serasaacoeswwds_2_tfserasaacoesdata = DateTime.MinValue;
         AV57Serasaacoeswwds_3_tfserasaacoesdata_to = DateTime.MinValue;
         AV58Serasaacoeswwds_4_tfserasaacoesnatureza = "";
         AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel = "";
         AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = "";
         AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel = "";
         AV64Serasaacoeswwds_10_tfserasaacoesvara = "";
         AV65Serasaacoeswwds_11_tfserasaacoesvara_sel = "";
         AV66Serasaacoeswwds_12_tfserasaacoescidade = "";
         AV67Serasaacoeswwds_13_tfserasaacoescidade_sel = "";
         AV68Serasaacoeswwds_14_tfserasaacoesuf = "";
         AV69Serasaacoeswwds_15_tfserasaacoesuf_sel = "";
         AV70Serasaacoeswwds_16_tfserasaacoesprincipal = "";
         AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel = "";
         AV72Serasaacoeswwds_18_tfserasaacoestipomoeda = "";
         AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel = "";
         lV58Serasaacoeswwds_4_tfserasaacoesnatureza = "";
         lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor = "";
         lV64Serasaacoeswwds_10_tfserasaacoesvara = "";
         lV66Serasaacoeswwds_12_tfserasaacoescidade = "";
         lV68Serasaacoeswwds_14_tfserasaacoesuf = "";
         lV70Serasaacoeswwds_16_tfserasaacoesprincipal = "";
         lV72Serasaacoeswwds_18_tfserasaacoestipomoeda = "";
         A700SerasaAcoesData = DateTime.MinValue;
         A701SerasaAcoesNatureza = "";
         A703SerasaAcoesDistribuidor = "";
         A704SerasaAcoesVara = "";
         A705SerasaAcoesCidade = "";
         A706SerasaAcoesUF = "";
         A707SerasaAcoesPrincipal = "";
         A708SerasaAcoesTipoMoeda = "";
         P00D32_A662SerasaId = new int[1] ;
         P00D32_n662SerasaId = new bool[] {false} ;
         P00D32_A701SerasaAcoesNatureza = new string[] {""} ;
         P00D32_n701SerasaAcoesNatureza = new bool[] {false} ;
         P00D32_A709SerasaAcoesQtdOco = new short[1] ;
         P00D32_n709SerasaAcoesQtdOco = new bool[] {false} ;
         P00D32_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         P00D32_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         P00D32_A707SerasaAcoesPrincipal = new string[] {""} ;
         P00D32_n707SerasaAcoesPrincipal = new bool[] {false} ;
         P00D32_A706SerasaAcoesUF = new string[] {""} ;
         P00D32_n706SerasaAcoesUF = new bool[] {false} ;
         P00D32_A705SerasaAcoesCidade = new string[] {""} ;
         P00D32_n705SerasaAcoesCidade = new bool[] {false} ;
         P00D32_A704SerasaAcoesVara = new string[] {""} ;
         P00D32_n704SerasaAcoesVara = new bool[] {false} ;
         P00D32_A703SerasaAcoesDistribuidor = new string[] {""} ;
         P00D32_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         P00D32_A702SerasaAcoesValor = new decimal[1] ;
         P00D32_n702SerasaAcoesValor = new bool[] {false} ;
         P00D32_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         P00D32_n700SerasaAcoesData = new bool[] {false} ;
         P00D32_A699SerasaAcoesId = new int[1] ;
         AV35Option = "";
         P00D33_A662SerasaId = new int[1] ;
         P00D33_n662SerasaId = new bool[] {false} ;
         P00D33_A703SerasaAcoesDistribuidor = new string[] {""} ;
         P00D33_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         P00D33_A709SerasaAcoesQtdOco = new short[1] ;
         P00D33_n709SerasaAcoesQtdOco = new bool[] {false} ;
         P00D33_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         P00D33_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         P00D33_A707SerasaAcoesPrincipal = new string[] {""} ;
         P00D33_n707SerasaAcoesPrincipal = new bool[] {false} ;
         P00D33_A706SerasaAcoesUF = new string[] {""} ;
         P00D33_n706SerasaAcoesUF = new bool[] {false} ;
         P00D33_A705SerasaAcoesCidade = new string[] {""} ;
         P00D33_n705SerasaAcoesCidade = new bool[] {false} ;
         P00D33_A704SerasaAcoesVara = new string[] {""} ;
         P00D33_n704SerasaAcoesVara = new bool[] {false} ;
         P00D33_A702SerasaAcoesValor = new decimal[1] ;
         P00D33_n702SerasaAcoesValor = new bool[] {false} ;
         P00D33_A701SerasaAcoesNatureza = new string[] {""} ;
         P00D33_n701SerasaAcoesNatureza = new bool[] {false} ;
         P00D33_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         P00D33_n700SerasaAcoesData = new bool[] {false} ;
         P00D33_A699SerasaAcoesId = new int[1] ;
         P00D34_A662SerasaId = new int[1] ;
         P00D34_n662SerasaId = new bool[] {false} ;
         P00D34_A704SerasaAcoesVara = new string[] {""} ;
         P00D34_n704SerasaAcoesVara = new bool[] {false} ;
         P00D34_A709SerasaAcoesQtdOco = new short[1] ;
         P00D34_n709SerasaAcoesQtdOco = new bool[] {false} ;
         P00D34_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         P00D34_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         P00D34_A707SerasaAcoesPrincipal = new string[] {""} ;
         P00D34_n707SerasaAcoesPrincipal = new bool[] {false} ;
         P00D34_A706SerasaAcoesUF = new string[] {""} ;
         P00D34_n706SerasaAcoesUF = new bool[] {false} ;
         P00D34_A705SerasaAcoesCidade = new string[] {""} ;
         P00D34_n705SerasaAcoesCidade = new bool[] {false} ;
         P00D34_A703SerasaAcoesDistribuidor = new string[] {""} ;
         P00D34_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         P00D34_A702SerasaAcoesValor = new decimal[1] ;
         P00D34_n702SerasaAcoesValor = new bool[] {false} ;
         P00D34_A701SerasaAcoesNatureza = new string[] {""} ;
         P00D34_n701SerasaAcoesNatureza = new bool[] {false} ;
         P00D34_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         P00D34_n700SerasaAcoesData = new bool[] {false} ;
         P00D34_A699SerasaAcoesId = new int[1] ;
         P00D35_A662SerasaId = new int[1] ;
         P00D35_n662SerasaId = new bool[] {false} ;
         P00D35_A705SerasaAcoesCidade = new string[] {""} ;
         P00D35_n705SerasaAcoesCidade = new bool[] {false} ;
         P00D35_A709SerasaAcoesQtdOco = new short[1] ;
         P00D35_n709SerasaAcoesQtdOco = new bool[] {false} ;
         P00D35_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         P00D35_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         P00D35_A707SerasaAcoesPrincipal = new string[] {""} ;
         P00D35_n707SerasaAcoesPrincipal = new bool[] {false} ;
         P00D35_A706SerasaAcoesUF = new string[] {""} ;
         P00D35_n706SerasaAcoesUF = new bool[] {false} ;
         P00D35_A704SerasaAcoesVara = new string[] {""} ;
         P00D35_n704SerasaAcoesVara = new bool[] {false} ;
         P00D35_A703SerasaAcoesDistribuidor = new string[] {""} ;
         P00D35_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         P00D35_A702SerasaAcoesValor = new decimal[1] ;
         P00D35_n702SerasaAcoesValor = new bool[] {false} ;
         P00D35_A701SerasaAcoesNatureza = new string[] {""} ;
         P00D35_n701SerasaAcoesNatureza = new bool[] {false} ;
         P00D35_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         P00D35_n700SerasaAcoesData = new bool[] {false} ;
         P00D35_A699SerasaAcoesId = new int[1] ;
         P00D36_A662SerasaId = new int[1] ;
         P00D36_n662SerasaId = new bool[] {false} ;
         P00D36_A706SerasaAcoesUF = new string[] {""} ;
         P00D36_n706SerasaAcoesUF = new bool[] {false} ;
         P00D36_A709SerasaAcoesQtdOco = new short[1] ;
         P00D36_n709SerasaAcoesQtdOco = new bool[] {false} ;
         P00D36_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         P00D36_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         P00D36_A707SerasaAcoesPrincipal = new string[] {""} ;
         P00D36_n707SerasaAcoesPrincipal = new bool[] {false} ;
         P00D36_A705SerasaAcoesCidade = new string[] {""} ;
         P00D36_n705SerasaAcoesCidade = new bool[] {false} ;
         P00D36_A704SerasaAcoesVara = new string[] {""} ;
         P00D36_n704SerasaAcoesVara = new bool[] {false} ;
         P00D36_A703SerasaAcoesDistribuidor = new string[] {""} ;
         P00D36_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         P00D36_A702SerasaAcoesValor = new decimal[1] ;
         P00D36_n702SerasaAcoesValor = new bool[] {false} ;
         P00D36_A701SerasaAcoesNatureza = new string[] {""} ;
         P00D36_n701SerasaAcoesNatureza = new bool[] {false} ;
         P00D36_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         P00D36_n700SerasaAcoesData = new bool[] {false} ;
         P00D36_A699SerasaAcoesId = new int[1] ;
         P00D37_A662SerasaId = new int[1] ;
         P00D37_n662SerasaId = new bool[] {false} ;
         P00D37_A707SerasaAcoesPrincipal = new string[] {""} ;
         P00D37_n707SerasaAcoesPrincipal = new bool[] {false} ;
         P00D37_A709SerasaAcoesQtdOco = new short[1] ;
         P00D37_n709SerasaAcoesQtdOco = new bool[] {false} ;
         P00D37_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         P00D37_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         P00D37_A706SerasaAcoesUF = new string[] {""} ;
         P00D37_n706SerasaAcoesUF = new bool[] {false} ;
         P00D37_A705SerasaAcoesCidade = new string[] {""} ;
         P00D37_n705SerasaAcoesCidade = new bool[] {false} ;
         P00D37_A704SerasaAcoesVara = new string[] {""} ;
         P00D37_n704SerasaAcoesVara = new bool[] {false} ;
         P00D37_A703SerasaAcoesDistribuidor = new string[] {""} ;
         P00D37_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         P00D37_A702SerasaAcoesValor = new decimal[1] ;
         P00D37_n702SerasaAcoesValor = new bool[] {false} ;
         P00D37_A701SerasaAcoesNatureza = new string[] {""} ;
         P00D37_n701SerasaAcoesNatureza = new bool[] {false} ;
         P00D37_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         P00D37_n700SerasaAcoesData = new bool[] {false} ;
         P00D37_A699SerasaAcoesId = new int[1] ;
         P00D38_A662SerasaId = new int[1] ;
         P00D38_n662SerasaId = new bool[] {false} ;
         P00D38_A708SerasaAcoesTipoMoeda = new string[] {""} ;
         P00D38_n708SerasaAcoesTipoMoeda = new bool[] {false} ;
         P00D38_A709SerasaAcoesQtdOco = new short[1] ;
         P00D38_n709SerasaAcoesQtdOco = new bool[] {false} ;
         P00D38_A707SerasaAcoesPrincipal = new string[] {""} ;
         P00D38_n707SerasaAcoesPrincipal = new bool[] {false} ;
         P00D38_A706SerasaAcoesUF = new string[] {""} ;
         P00D38_n706SerasaAcoesUF = new bool[] {false} ;
         P00D38_A705SerasaAcoesCidade = new string[] {""} ;
         P00D38_n705SerasaAcoesCidade = new bool[] {false} ;
         P00D38_A704SerasaAcoesVara = new string[] {""} ;
         P00D38_n704SerasaAcoesVara = new bool[] {false} ;
         P00D38_A703SerasaAcoesDistribuidor = new string[] {""} ;
         P00D38_n703SerasaAcoesDistribuidor = new bool[] {false} ;
         P00D38_A702SerasaAcoesValor = new decimal[1] ;
         P00D38_n702SerasaAcoesValor = new bool[] {false} ;
         P00D38_A701SerasaAcoesNatureza = new string[] {""} ;
         P00D38_n701SerasaAcoesNatureza = new bool[] {false} ;
         P00D38_A700SerasaAcoesData = new DateTime[] {DateTime.MinValue} ;
         P00D38_n700SerasaAcoesData = new bool[] {false} ;
         P00D38_A699SerasaAcoesId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.serasaacoeswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00D32_A662SerasaId, P00D32_n662SerasaId, P00D32_A701SerasaAcoesNatureza, P00D32_n701SerasaAcoesNatureza, P00D32_A709SerasaAcoesQtdOco, P00D32_n709SerasaAcoesQtdOco, P00D32_A708SerasaAcoesTipoMoeda, P00D32_n708SerasaAcoesTipoMoeda, P00D32_A707SerasaAcoesPrincipal, P00D32_n707SerasaAcoesPrincipal,
               P00D32_A706SerasaAcoesUF, P00D32_n706SerasaAcoesUF, P00D32_A705SerasaAcoesCidade, P00D32_n705SerasaAcoesCidade, P00D32_A704SerasaAcoesVara, P00D32_n704SerasaAcoesVara, P00D32_A703SerasaAcoesDistribuidor, P00D32_n703SerasaAcoesDistribuidor, P00D32_A702SerasaAcoesValor, P00D32_n702SerasaAcoesValor,
               P00D32_A700SerasaAcoesData, P00D32_n700SerasaAcoesData, P00D32_A699SerasaAcoesId
               }
               , new Object[] {
               P00D33_A662SerasaId, P00D33_n662SerasaId, P00D33_A703SerasaAcoesDistribuidor, P00D33_n703SerasaAcoesDistribuidor, P00D33_A709SerasaAcoesQtdOco, P00D33_n709SerasaAcoesQtdOco, P00D33_A708SerasaAcoesTipoMoeda, P00D33_n708SerasaAcoesTipoMoeda, P00D33_A707SerasaAcoesPrincipal, P00D33_n707SerasaAcoesPrincipal,
               P00D33_A706SerasaAcoesUF, P00D33_n706SerasaAcoesUF, P00D33_A705SerasaAcoesCidade, P00D33_n705SerasaAcoesCidade, P00D33_A704SerasaAcoesVara, P00D33_n704SerasaAcoesVara, P00D33_A702SerasaAcoesValor, P00D33_n702SerasaAcoesValor, P00D33_A701SerasaAcoesNatureza, P00D33_n701SerasaAcoesNatureza,
               P00D33_A700SerasaAcoesData, P00D33_n700SerasaAcoesData, P00D33_A699SerasaAcoesId
               }
               , new Object[] {
               P00D34_A662SerasaId, P00D34_n662SerasaId, P00D34_A704SerasaAcoesVara, P00D34_n704SerasaAcoesVara, P00D34_A709SerasaAcoesQtdOco, P00D34_n709SerasaAcoesQtdOco, P00D34_A708SerasaAcoesTipoMoeda, P00D34_n708SerasaAcoesTipoMoeda, P00D34_A707SerasaAcoesPrincipal, P00D34_n707SerasaAcoesPrincipal,
               P00D34_A706SerasaAcoesUF, P00D34_n706SerasaAcoesUF, P00D34_A705SerasaAcoesCidade, P00D34_n705SerasaAcoesCidade, P00D34_A703SerasaAcoesDistribuidor, P00D34_n703SerasaAcoesDistribuidor, P00D34_A702SerasaAcoesValor, P00D34_n702SerasaAcoesValor, P00D34_A701SerasaAcoesNatureza, P00D34_n701SerasaAcoesNatureza,
               P00D34_A700SerasaAcoesData, P00D34_n700SerasaAcoesData, P00D34_A699SerasaAcoesId
               }
               , new Object[] {
               P00D35_A662SerasaId, P00D35_n662SerasaId, P00D35_A705SerasaAcoesCidade, P00D35_n705SerasaAcoesCidade, P00D35_A709SerasaAcoesQtdOco, P00D35_n709SerasaAcoesQtdOco, P00D35_A708SerasaAcoesTipoMoeda, P00D35_n708SerasaAcoesTipoMoeda, P00D35_A707SerasaAcoesPrincipal, P00D35_n707SerasaAcoesPrincipal,
               P00D35_A706SerasaAcoesUF, P00D35_n706SerasaAcoesUF, P00D35_A704SerasaAcoesVara, P00D35_n704SerasaAcoesVara, P00D35_A703SerasaAcoesDistribuidor, P00D35_n703SerasaAcoesDistribuidor, P00D35_A702SerasaAcoesValor, P00D35_n702SerasaAcoesValor, P00D35_A701SerasaAcoesNatureza, P00D35_n701SerasaAcoesNatureza,
               P00D35_A700SerasaAcoesData, P00D35_n700SerasaAcoesData, P00D35_A699SerasaAcoesId
               }
               , new Object[] {
               P00D36_A662SerasaId, P00D36_n662SerasaId, P00D36_A706SerasaAcoesUF, P00D36_n706SerasaAcoesUF, P00D36_A709SerasaAcoesQtdOco, P00D36_n709SerasaAcoesQtdOco, P00D36_A708SerasaAcoesTipoMoeda, P00D36_n708SerasaAcoesTipoMoeda, P00D36_A707SerasaAcoesPrincipal, P00D36_n707SerasaAcoesPrincipal,
               P00D36_A705SerasaAcoesCidade, P00D36_n705SerasaAcoesCidade, P00D36_A704SerasaAcoesVara, P00D36_n704SerasaAcoesVara, P00D36_A703SerasaAcoesDistribuidor, P00D36_n703SerasaAcoesDistribuidor, P00D36_A702SerasaAcoesValor, P00D36_n702SerasaAcoesValor, P00D36_A701SerasaAcoesNatureza, P00D36_n701SerasaAcoesNatureza,
               P00D36_A700SerasaAcoesData, P00D36_n700SerasaAcoesData, P00D36_A699SerasaAcoesId
               }
               , new Object[] {
               P00D37_A662SerasaId, P00D37_n662SerasaId, P00D37_A707SerasaAcoesPrincipal, P00D37_n707SerasaAcoesPrincipal, P00D37_A709SerasaAcoesQtdOco, P00D37_n709SerasaAcoesQtdOco, P00D37_A708SerasaAcoesTipoMoeda, P00D37_n708SerasaAcoesTipoMoeda, P00D37_A706SerasaAcoesUF, P00D37_n706SerasaAcoesUF,
               P00D37_A705SerasaAcoesCidade, P00D37_n705SerasaAcoesCidade, P00D37_A704SerasaAcoesVara, P00D37_n704SerasaAcoesVara, P00D37_A703SerasaAcoesDistribuidor, P00D37_n703SerasaAcoesDistribuidor, P00D37_A702SerasaAcoesValor, P00D37_n702SerasaAcoesValor, P00D37_A701SerasaAcoesNatureza, P00D37_n701SerasaAcoesNatureza,
               P00D37_A700SerasaAcoesData, P00D37_n700SerasaAcoesData, P00D37_A699SerasaAcoesId
               }
               , new Object[] {
               P00D38_A662SerasaId, P00D38_n662SerasaId, P00D38_A708SerasaAcoesTipoMoeda, P00D38_n708SerasaAcoesTipoMoeda, P00D38_A709SerasaAcoesQtdOco, P00D38_n709SerasaAcoesQtdOco, P00D38_A707SerasaAcoesPrincipal, P00D38_n707SerasaAcoesPrincipal, P00D38_A706SerasaAcoesUF, P00D38_n706SerasaAcoesUF,
               P00D38_A705SerasaAcoesCidade, P00D38_n705SerasaAcoesCidade, P00D38_A704SerasaAcoesVara, P00D38_n704SerasaAcoesVara, P00D38_A703SerasaAcoesDistribuidor, P00D38_n703SerasaAcoesDistribuidor, P00D38_A702SerasaAcoesValor, P00D38_n702SerasaAcoesValor, P00D38_A701SerasaAcoesNatureza, P00D38_n701SerasaAcoesNatureza,
               P00D38_A700SerasaAcoesData, P00D38_n700SerasaAcoesData, P00D38_A699SerasaAcoesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV33MaxItems ;
      private short AV32PageIndex ;
      private short AV31SkipItems ;
      private short AV28TFSerasaAcoesQtdOco ;
      private short AV29TFSerasaAcoesQtdOco_To ;
      private short AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ;
      private short AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ;
      private short A709SerasaAcoesQtdOco ;
      private int AV53GXV1 ;
      private int AV52SerasaId ;
      private int AV55Serasaacoeswwds_1_serasaid ;
      private int A662SerasaId ;
      private int A699SerasaAcoesId ;
      private long AV40count ;
      private decimal AV14TFSerasaAcoesValor ;
      private decimal AV15TFSerasaAcoesValor_To ;
      private decimal AV60Serasaacoeswwds_6_tfserasaacoesvalor ;
      private decimal AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ;
      private decimal A702SerasaAcoesValor ;
      private DateTime AV10TFSerasaAcoesData ;
      private DateTime AV11TFSerasaAcoesData_To ;
      private DateTime AV56Serasaacoeswwds_2_tfserasaacoesdata ;
      private DateTime AV57Serasaacoeswwds_3_tfserasaacoesdata_to ;
      private DateTime A700SerasaAcoesData ;
      private bool returnInSub ;
      private bool BRKD32 ;
      private bool n662SerasaId ;
      private bool n701SerasaAcoesNatureza ;
      private bool n709SerasaAcoesQtdOco ;
      private bool n708SerasaAcoesTipoMoeda ;
      private bool n707SerasaAcoesPrincipal ;
      private bool n706SerasaAcoesUF ;
      private bool n705SerasaAcoesCidade ;
      private bool n704SerasaAcoesVara ;
      private bool n703SerasaAcoesDistribuidor ;
      private bool n702SerasaAcoesValor ;
      private bool n700SerasaAcoesData ;
      private bool BRKD34 ;
      private bool BRKD36 ;
      private bool BRKD38 ;
      private bool BRKD310 ;
      private bool BRKD312 ;
      private bool BRKD314 ;
      private string AV49OptionsJson ;
      private string AV50OptionsDescJson ;
      private string AV51OptionIndexesJson ;
      private string AV46DDOName ;
      private string AV47SearchTxtParms ;
      private string AV48SearchTxtTo ;
      private string AV30SearchTxt ;
      private string AV12TFSerasaAcoesNatureza ;
      private string AV13TFSerasaAcoesNatureza_Sel ;
      private string AV16TFSerasaAcoesDistribuidor ;
      private string AV17TFSerasaAcoesDistribuidor_Sel ;
      private string AV18TFSerasaAcoesVara ;
      private string AV19TFSerasaAcoesVara_Sel ;
      private string AV20TFSerasaAcoesCidade ;
      private string AV21TFSerasaAcoesCidade_Sel ;
      private string AV22TFSerasaAcoesUF ;
      private string AV23TFSerasaAcoesUF_Sel ;
      private string AV24TFSerasaAcoesPrincipal ;
      private string AV25TFSerasaAcoesPrincipal_Sel ;
      private string AV26TFSerasaAcoesTipoMoeda ;
      private string AV27TFSerasaAcoesTipoMoeda_Sel ;
      private string AV58Serasaacoeswwds_4_tfserasaacoesnatureza ;
      private string AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ;
      private string AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ;
      private string AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ;
      private string AV64Serasaacoeswwds_10_tfserasaacoesvara ;
      private string AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ;
      private string AV66Serasaacoeswwds_12_tfserasaacoescidade ;
      private string AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ;
      private string AV68Serasaacoeswwds_14_tfserasaacoesuf ;
      private string AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ;
      private string AV70Serasaacoeswwds_16_tfserasaacoesprincipal ;
      private string AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ;
      private string AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ;
      private string AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ;
      private string lV58Serasaacoeswwds_4_tfserasaacoesnatureza ;
      private string lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ;
      private string lV64Serasaacoeswwds_10_tfserasaacoesvara ;
      private string lV66Serasaacoeswwds_12_tfserasaacoescidade ;
      private string lV68Serasaacoeswwds_14_tfserasaacoesuf ;
      private string lV70Serasaacoeswwds_16_tfserasaacoesprincipal ;
      private string lV72Serasaacoeswwds_18_tfserasaacoestipomoeda ;
      private string A701SerasaAcoesNatureza ;
      private string A703SerasaAcoesDistribuidor ;
      private string A704SerasaAcoesVara ;
      private string A705SerasaAcoesCidade ;
      private string A706SerasaAcoesUF ;
      private string A707SerasaAcoesPrincipal ;
      private string A708SerasaAcoesTipoMoeda ;
      private string AV35Option ;
      private IGxSession AV41Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV36Options ;
      private GxSimpleCollection<string> AV38OptionsDesc ;
      private GxSimpleCollection<string> AV39OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV43GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV44GridStateFilterValue ;
      private IDataStoreProvider pr_default ;
      private int[] P00D32_A662SerasaId ;
      private bool[] P00D32_n662SerasaId ;
      private string[] P00D32_A701SerasaAcoesNatureza ;
      private bool[] P00D32_n701SerasaAcoesNatureza ;
      private short[] P00D32_A709SerasaAcoesQtdOco ;
      private bool[] P00D32_n709SerasaAcoesQtdOco ;
      private string[] P00D32_A708SerasaAcoesTipoMoeda ;
      private bool[] P00D32_n708SerasaAcoesTipoMoeda ;
      private string[] P00D32_A707SerasaAcoesPrincipal ;
      private bool[] P00D32_n707SerasaAcoesPrincipal ;
      private string[] P00D32_A706SerasaAcoesUF ;
      private bool[] P00D32_n706SerasaAcoesUF ;
      private string[] P00D32_A705SerasaAcoesCidade ;
      private bool[] P00D32_n705SerasaAcoesCidade ;
      private string[] P00D32_A704SerasaAcoesVara ;
      private bool[] P00D32_n704SerasaAcoesVara ;
      private string[] P00D32_A703SerasaAcoesDistribuidor ;
      private bool[] P00D32_n703SerasaAcoesDistribuidor ;
      private decimal[] P00D32_A702SerasaAcoesValor ;
      private bool[] P00D32_n702SerasaAcoesValor ;
      private DateTime[] P00D32_A700SerasaAcoesData ;
      private bool[] P00D32_n700SerasaAcoesData ;
      private int[] P00D32_A699SerasaAcoesId ;
      private int[] P00D33_A662SerasaId ;
      private bool[] P00D33_n662SerasaId ;
      private string[] P00D33_A703SerasaAcoesDistribuidor ;
      private bool[] P00D33_n703SerasaAcoesDistribuidor ;
      private short[] P00D33_A709SerasaAcoesQtdOco ;
      private bool[] P00D33_n709SerasaAcoesQtdOco ;
      private string[] P00D33_A708SerasaAcoesTipoMoeda ;
      private bool[] P00D33_n708SerasaAcoesTipoMoeda ;
      private string[] P00D33_A707SerasaAcoesPrincipal ;
      private bool[] P00D33_n707SerasaAcoesPrincipal ;
      private string[] P00D33_A706SerasaAcoesUF ;
      private bool[] P00D33_n706SerasaAcoesUF ;
      private string[] P00D33_A705SerasaAcoesCidade ;
      private bool[] P00D33_n705SerasaAcoesCidade ;
      private string[] P00D33_A704SerasaAcoesVara ;
      private bool[] P00D33_n704SerasaAcoesVara ;
      private decimal[] P00D33_A702SerasaAcoesValor ;
      private bool[] P00D33_n702SerasaAcoesValor ;
      private string[] P00D33_A701SerasaAcoesNatureza ;
      private bool[] P00D33_n701SerasaAcoesNatureza ;
      private DateTime[] P00D33_A700SerasaAcoesData ;
      private bool[] P00D33_n700SerasaAcoesData ;
      private int[] P00D33_A699SerasaAcoesId ;
      private int[] P00D34_A662SerasaId ;
      private bool[] P00D34_n662SerasaId ;
      private string[] P00D34_A704SerasaAcoesVara ;
      private bool[] P00D34_n704SerasaAcoesVara ;
      private short[] P00D34_A709SerasaAcoesQtdOco ;
      private bool[] P00D34_n709SerasaAcoesQtdOco ;
      private string[] P00D34_A708SerasaAcoesTipoMoeda ;
      private bool[] P00D34_n708SerasaAcoesTipoMoeda ;
      private string[] P00D34_A707SerasaAcoesPrincipal ;
      private bool[] P00D34_n707SerasaAcoesPrincipal ;
      private string[] P00D34_A706SerasaAcoesUF ;
      private bool[] P00D34_n706SerasaAcoesUF ;
      private string[] P00D34_A705SerasaAcoesCidade ;
      private bool[] P00D34_n705SerasaAcoesCidade ;
      private string[] P00D34_A703SerasaAcoesDistribuidor ;
      private bool[] P00D34_n703SerasaAcoesDistribuidor ;
      private decimal[] P00D34_A702SerasaAcoesValor ;
      private bool[] P00D34_n702SerasaAcoesValor ;
      private string[] P00D34_A701SerasaAcoesNatureza ;
      private bool[] P00D34_n701SerasaAcoesNatureza ;
      private DateTime[] P00D34_A700SerasaAcoesData ;
      private bool[] P00D34_n700SerasaAcoesData ;
      private int[] P00D34_A699SerasaAcoesId ;
      private int[] P00D35_A662SerasaId ;
      private bool[] P00D35_n662SerasaId ;
      private string[] P00D35_A705SerasaAcoesCidade ;
      private bool[] P00D35_n705SerasaAcoesCidade ;
      private short[] P00D35_A709SerasaAcoesQtdOco ;
      private bool[] P00D35_n709SerasaAcoesQtdOco ;
      private string[] P00D35_A708SerasaAcoesTipoMoeda ;
      private bool[] P00D35_n708SerasaAcoesTipoMoeda ;
      private string[] P00D35_A707SerasaAcoesPrincipal ;
      private bool[] P00D35_n707SerasaAcoesPrincipal ;
      private string[] P00D35_A706SerasaAcoesUF ;
      private bool[] P00D35_n706SerasaAcoesUF ;
      private string[] P00D35_A704SerasaAcoesVara ;
      private bool[] P00D35_n704SerasaAcoesVara ;
      private string[] P00D35_A703SerasaAcoesDistribuidor ;
      private bool[] P00D35_n703SerasaAcoesDistribuidor ;
      private decimal[] P00D35_A702SerasaAcoesValor ;
      private bool[] P00D35_n702SerasaAcoesValor ;
      private string[] P00D35_A701SerasaAcoesNatureza ;
      private bool[] P00D35_n701SerasaAcoesNatureza ;
      private DateTime[] P00D35_A700SerasaAcoesData ;
      private bool[] P00D35_n700SerasaAcoesData ;
      private int[] P00D35_A699SerasaAcoesId ;
      private int[] P00D36_A662SerasaId ;
      private bool[] P00D36_n662SerasaId ;
      private string[] P00D36_A706SerasaAcoesUF ;
      private bool[] P00D36_n706SerasaAcoesUF ;
      private short[] P00D36_A709SerasaAcoesQtdOco ;
      private bool[] P00D36_n709SerasaAcoesQtdOco ;
      private string[] P00D36_A708SerasaAcoesTipoMoeda ;
      private bool[] P00D36_n708SerasaAcoesTipoMoeda ;
      private string[] P00D36_A707SerasaAcoesPrincipal ;
      private bool[] P00D36_n707SerasaAcoesPrincipal ;
      private string[] P00D36_A705SerasaAcoesCidade ;
      private bool[] P00D36_n705SerasaAcoesCidade ;
      private string[] P00D36_A704SerasaAcoesVara ;
      private bool[] P00D36_n704SerasaAcoesVara ;
      private string[] P00D36_A703SerasaAcoesDistribuidor ;
      private bool[] P00D36_n703SerasaAcoesDistribuidor ;
      private decimal[] P00D36_A702SerasaAcoesValor ;
      private bool[] P00D36_n702SerasaAcoesValor ;
      private string[] P00D36_A701SerasaAcoesNatureza ;
      private bool[] P00D36_n701SerasaAcoesNatureza ;
      private DateTime[] P00D36_A700SerasaAcoesData ;
      private bool[] P00D36_n700SerasaAcoesData ;
      private int[] P00D36_A699SerasaAcoesId ;
      private int[] P00D37_A662SerasaId ;
      private bool[] P00D37_n662SerasaId ;
      private string[] P00D37_A707SerasaAcoesPrincipal ;
      private bool[] P00D37_n707SerasaAcoesPrincipal ;
      private short[] P00D37_A709SerasaAcoesQtdOco ;
      private bool[] P00D37_n709SerasaAcoesQtdOco ;
      private string[] P00D37_A708SerasaAcoesTipoMoeda ;
      private bool[] P00D37_n708SerasaAcoesTipoMoeda ;
      private string[] P00D37_A706SerasaAcoesUF ;
      private bool[] P00D37_n706SerasaAcoesUF ;
      private string[] P00D37_A705SerasaAcoesCidade ;
      private bool[] P00D37_n705SerasaAcoesCidade ;
      private string[] P00D37_A704SerasaAcoesVara ;
      private bool[] P00D37_n704SerasaAcoesVara ;
      private string[] P00D37_A703SerasaAcoesDistribuidor ;
      private bool[] P00D37_n703SerasaAcoesDistribuidor ;
      private decimal[] P00D37_A702SerasaAcoesValor ;
      private bool[] P00D37_n702SerasaAcoesValor ;
      private string[] P00D37_A701SerasaAcoesNatureza ;
      private bool[] P00D37_n701SerasaAcoesNatureza ;
      private DateTime[] P00D37_A700SerasaAcoesData ;
      private bool[] P00D37_n700SerasaAcoesData ;
      private int[] P00D37_A699SerasaAcoesId ;
      private int[] P00D38_A662SerasaId ;
      private bool[] P00D38_n662SerasaId ;
      private string[] P00D38_A708SerasaAcoesTipoMoeda ;
      private bool[] P00D38_n708SerasaAcoesTipoMoeda ;
      private short[] P00D38_A709SerasaAcoesQtdOco ;
      private bool[] P00D38_n709SerasaAcoesQtdOco ;
      private string[] P00D38_A707SerasaAcoesPrincipal ;
      private bool[] P00D38_n707SerasaAcoesPrincipal ;
      private string[] P00D38_A706SerasaAcoesUF ;
      private bool[] P00D38_n706SerasaAcoesUF ;
      private string[] P00D38_A705SerasaAcoesCidade ;
      private bool[] P00D38_n705SerasaAcoesCidade ;
      private string[] P00D38_A704SerasaAcoesVara ;
      private bool[] P00D38_n704SerasaAcoesVara ;
      private string[] P00D38_A703SerasaAcoesDistribuidor ;
      private bool[] P00D38_n703SerasaAcoesDistribuidor ;
      private decimal[] P00D38_A702SerasaAcoesValor ;
      private bool[] P00D38_n702SerasaAcoesValor ;
      private string[] P00D38_A701SerasaAcoesNatureza ;
      private bool[] P00D38_n701SerasaAcoesNatureza ;
      private DateTime[] P00D38_A700SerasaAcoesData ;
      private bool[] P00D38_n700SerasaAcoesData ;
      private int[] P00D38_A699SerasaAcoesId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class serasaacoeswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00D32( IGxContext context ,
                                             DateTime AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                             DateTime AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                             string AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                             string AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                             decimal AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                             decimal AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                             string AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                             string AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                             string AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                             string AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                             string AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                             string AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                             string AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                             string AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                             string AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                             string AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                             string AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                             string AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                             short AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                             short AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                             DateTime A700SerasaAcoesData ,
                                             string A701SerasaAcoesNatureza ,
                                             decimal A702SerasaAcoesValor ,
                                             string A703SerasaAcoesDistribuidor ,
                                             string A704SerasaAcoesVara ,
                                             string A705SerasaAcoesCidade ,
                                             string A706SerasaAcoesUF ,
                                             string A707SerasaAcoesPrincipal ,
                                             string A708SerasaAcoesTipoMoeda ,
                                             short A709SerasaAcoesQtdOco ,
                                             int AV55Serasaacoeswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[21];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaAcoesNatureza, SerasaAcoesQtdOco, SerasaAcoesTipoMoeda, SerasaAcoesPrincipal, SerasaAcoesUF, SerasaAcoesCidade, SerasaAcoesVara, SerasaAcoesDistribuidor, SerasaAcoesValor, SerasaAcoesData, SerasaAcoesId FROM SerasaAcoes";
         AddWhere(sWhereString, "(SerasaId = :AV55Serasaacoeswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV56Serasaacoeswwds_2_tfserasaacoesdata) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData >= :AV56Serasaacoeswwds_2_tfserasaacoesdata)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Serasaacoeswwds_3_tfserasaacoesdata_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData <= :AV57Serasaacoeswwds_3_tfserasaacoesdata_to)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza like :lV58Serasaacoeswwds_4_tfserasaacoesnatureza)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ! ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza = ( :AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesNatureza))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV60Serasaacoeswwds_6_tfserasaacoesvalor) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor >= :AV60Serasaacoeswwds_6_tfserasaacoesvalor)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Serasaacoeswwds_7_tfserasaacoesvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor <= :AV61Serasaacoeswwds_7_tfserasaacoesvalor_to)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor like :lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ! ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor = ( :AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesDistribuidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara like :lV64Serasaacoeswwds_10_tfserasaacoesvara)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ! ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara = ( :AV65Serasaacoeswwds_11_tfserasaacoesvara_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesVara))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade like :lV66Serasaacoeswwds_12_tfserasaacoescidade)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ! ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade = ( :AV67Serasaacoeswwds_13_tfserasaacoescidade_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF like :lV68Serasaacoeswwds_14_tfserasaacoesuf)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ! ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF = ( :AV69Serasaacoeswwds_15_tfserasaacoesuf_sel))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal like :lV70Serasaacoeswwds_16_tfserasaacoesprincipal)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ! ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal = ( :AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel))");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesPrincipal))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda like :lV72Serasaacoeswwds_18_tfserasaacoestipomoeda)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ! ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda = ( :AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel))");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesTipoMoeda))=0))");
         }
         if ( ! (0==AV74Serasaacoeswwds_20_tfserasaacoesqtdoco) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco >= :AV74Serasaacoeswwds_20_tfserasaacoesqtdoco)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! (0==AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco <= :AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaAcoesNatureza";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00D33( IGxContext context ,
                                             DateTime AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                             DateTime AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                             string AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                             string AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                             decimal AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                             decimal AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                             string AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                             string AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                             string AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                             string AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                             string AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                             string AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                             string AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                             string AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                             string AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                             string AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                             string AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                             string AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                             short AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                             short AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                             DateTime A700SerasaAcoesData ,
                                             string A701SerasaAcoesNatureza ,
                                             decimal A702SerasaAcoesValor ,
                                             string A703SerasaAcoesDistribuidor ,
                                             string A704SerasaAcoesVara ,
                                             string A705SerasaAcoesCidade ,
                                             string A706SerasaAcoesUF ,
                                             string A707SerasaAcoesPrincipal ,
                                             string A708SerasaAcoesTipoMoeda ,
                                             short A709SerasaAcoesQtdOco ,
                                             int AV55Serasaacoeswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[21];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaAcoesDistribuidor, SerasaAcoesQtdOco, SerasaAcoesTipoMoeda, SerasaAcoesPrincipal, SerasaAcoesUF, SerasaAcoesCidade, SerasaAcoesVara, SerasaAcoesValor, SerasaAcoesNatureza, SerasaAcoesData, SerasaAcoesId FROM SerasaAcoes";
         AddWhere(sWhereString, "(SerasaId = :AV55Serasaacoeswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV56Serasaacoeswwds_2_tfserasaacoesdata) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData >= :AV56Serasaacoeswwds_2_tfserasaacoesdata)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Serasaacoeswwds_3_tfserasaacoesdata_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData <= :AV57Serasaacoeswwds_3_tfserasaacoesdata_to)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza like :lV58Serasaacoeswwds_4_tfserasaacoesnatureza)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ! ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza = ( :AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesNatureza))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV60Serasaacoeswwds_6_tfserasaacoesvalor) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor >= :AV60Serasaacoeswwds_6_tfserasaacoesvalor)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Serasaacoeswwds_7_tfserasaacoesvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor <= :AV61Serasaacoeswwds_7_tfserasaacoesvalor_to)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor like :lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ! ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor = ( :AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesDistribuidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara like :lV64Serasaacoeswwds_10_tfserasaacoesvara)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ! ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara = ( :AV65Serasaacoeswwds_11_tfserasaacoesvara_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesVara))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade like :lV66Serasaacoeswwds_12_tfserasaacoescidade)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ! ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade = ( :AV67Serasaacoeswwds_13_tfserasaacoescidade_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF like :lV68Serasaacoeswwds_14_tfserasaacoesuf)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ! ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF = ( :AV69Serasaacoeswwds_15_tfserasaacoesuf_sel))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal like :lV70Serasaacoeswwds_16_tfserasaacoesprincipal)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ! ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal = ( :AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel))");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesPrincipal))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda like :lV72Serasaacoeswwds_18_tfserasaacoestipomoeda)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ! ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda = ( :AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel))");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesTipoMoeda))=0))");
         }
         if ( ! (0==AV74Serasaacoeswwds_20_tfserasaacoesqtdoco) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco >= :AV74Serasaacoeswwds_20_tfserasaacoesqtdoco)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! (0==AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco <= :AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaAcoesDistribuidor";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00D34( IGxContext context ,
                                             DateTime AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                             DateTime AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                             string AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                             string AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                             decimal AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                             decimal AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                             string AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                             string AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                             string AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                             string AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                             string AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                             string AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                             string AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                             string AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                             string AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                             string AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                             string AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                             string AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                             short AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                             short AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                             DateTime A700SerasaAcoesData ,
                                             string A701SerasaAcoesNatureza ,
                                             decimal A702SerasaAcoesValor ,
                                             string A703SerasaAcoesDistribuidor ,
                                             string A704SerasaAcoesVara ,
                                             string A705SerasaAcoesCidade ,
                                             string A706SerasaAcoesUF ,
                                             string A707SerasaAcoesPrincipal ,
                                             string A708SerasaAcoesTipoMoeda ,
                                             short A709SerasaAcoesQtdOco ,
                                             int AV55Serasaacoeswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[21];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaAcoesVara, SerasaAcoesQtdOco, SerasaAcoesTipoMoeda, SerasaAcoesPrincipal, SerasaAcoesUF, SerasaAcoesCidade, SerasaAcoesDistribuidor, SerasaAcoesValor, SerasaAcoesNatureza, SerasaAcoesData, SerasaAcoesId FROM SerasaAcoes";
         AddWhere(sWhereString, "(SerasaId = :AV55Serasaacoeswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV56Serasaacoeswwds_2_tfserasaacoesdata) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData >= :AV56Serasaacoeswwds_2_tfserasaacoesdata)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Serasaacoeswwds_3_tfserasaacoesdata_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData <= :AV57Serasaacoeswwds_3_tfserasaacoesdata_to)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza like :lV58Serasaacoeswwds_4_tfserasaacoesnatureza)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ! ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza = ( :AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesNatureza))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV60Serasaacoeswwds_6_tfserasaacoesvalor) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor >= :AV60Serasaacoeswwds_6_tfserasaacoesvalor)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Serasaacoeswwds_7_tfserasaacoesvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor <= :AV61Serasaacoeswwds_7_tfserasaacoesvalor_to)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor like :lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ! ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor = ( :AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesDistribuidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara like :lV64Serasaacoeswwds_10_tfserasaacoesvara)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ! ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara = ( :AV65Serasaacoeswwds_11_tfserasaacoesvara_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesVara))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade like :lV66Serasaacoeswwds_12_tfserasaacoescidade)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ! ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade = ( :AV67Serasaacoeswwds_13_tfserasaacoescidade_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF like :lV68Serasaacoeswwds_14_tfserasaacoesuf)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ! ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF = ( :AV69Serasaacoeswwds_15_tfserasaacoesuf_sel))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal like :lV70Serasaacoeswwds_16_tfserasaacoesprincipal)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ! ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal = ( :AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel))");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesPrincipal))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda like :lV72Serasaacoeswwds_18_tfserasaacoestipomoeda)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ! ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda = ( :AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel))");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesTipoMoeda))=0))");
         }
         if ( ! (0==AV74Serasaacoeswwds_20_tfserasaacoesqtdoco) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco >= :AV74Serasaacoeswwds_20_tfserasaacoesqtdoco)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! (0==AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco <= :AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaAcoesVara";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00D35( IGxContext context ,
                                             DateTime AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                             DateTime AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                             string AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                             string AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                             decimal AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                             decimal AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                             string AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                             string AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                             string AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                             string AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                             string AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                             string AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                             string AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                             string AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                             string AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                             string AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                             string AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                             string AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                             short AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                             short AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                             DateTime A700SerasaAcoesData ,
                                             string A701SerasaAcoesNatureza ,
                                             decimal A702SerasaAcoesValor ,
                                             string A703SerasaAcoesDistribuidor ,
                                             string A704SerasaAcoesVara ,
                                             string A705SerasaAcoesCidade ,
                                             string A706SerasaAcoesUF ,
                                             string A707SerasaAcoesPrincipal ,
                                             string A708SerasaAcoesTipoMoeda ,
                                             short A709SerasaAcoesQtdOco ,
                                             int AV55Serasaacoeswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[21];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaAcoesCidade, SerasaAcoesQtdOco, SerasaAcoesTipoMoeda, SerasaAcoesPrincipal, SerasaAcoesUF, SerasaAcoesVara, SerasaAcoesDistribuidor, SerasaAcoesValor, SerasaAcoesNatureza, SerasaAcoesData, SerasaAcoesId FROM SerasaAcoes";
         AddWhere(sWhereString, "(SerasaId = :AV55Serasaacoeswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV56Serasaacoeswwds_2_tfserasaacoesdata) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData >= :AV56Serasaacoeswwds_2_tfserasaacoesdata)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Serasaacoeswwds_3_tfserasaacoesdata_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData <= :AV57Serasaacoeswwds_3_tfserasaacoesdata_to)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza like :lV58Serasaacoeswwds_4_tfserasaacoesnatureza)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ! ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza = ( :AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel))");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesNatureza))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV60Serasaacoeswwds_6_tfserasaacoesvalor) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor >= :AV60Serasaacoeswwds_6_tfserasaacoesvalor)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Serasaacoeswwds_7_tfserasaacoesvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor <= :AV61Serasaacoeswwds_7_tfserasaacoesvalor_to)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor like :lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ! ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor = ( :AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesDistribuidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara like :lV64Serasaacoeswwds_10_tfserasaacoesvara)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ! ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara = ( :AV65Serasaacoeswwds_11_tfserasaacoesvara_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesVara))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade like :lV66Serasaacoeswwds_12_tfserasaacoescidade)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ! ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade = ( :AV67Serasaacoeswwds_13_tfserasaacoescidade_sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF like :lV68Serasaacoeswwds_14_tfserasaacoesuf)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ! ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF = ( :AV69Serasaacoeswwds_15_tfserasaacoesuf_sel))");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal like :lV70Serasaacoeswwds_16_tfserasaacoesprincipal)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ! ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal = ( :AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel))");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesPrincipal))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda like :lV72Serasaacoeswwds_18_tfserasaacoestipomoeda)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ! ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda = ( :AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel))");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesTipoMoeda))=0))");
         }
         if ( ! (0==AV74Serasaacoeswwds_20_tfserasaacoesqtdoco) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco >= :AV74Serasaacoeswwds_20_tfserasaacoesqtdoco)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! (0==AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco <= :AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaAcoesCidade";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00D36( IGxContext context ,
                                             DateTime AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                             DateTime AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                             string AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                             string AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                             decimal AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                             decimal AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                             string AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                             string AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                             string AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                             string AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                             string AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                             string AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                             string AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                             string AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                             string AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                             string AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                             string AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                             string AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                             short AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                             short AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                             DateTime A700SerasaAcoesData ,
                                             string A701SerasaAcoesNatureza ,
                                             decimal A702SerasaAcoesValor ,
                                             string A703SerasaAcoesDistribuidor ,
                                             string A704SerasaAcoesVara ,
                                             string A705SerasaAcoesCidade ,
                                             string A706SerasaAcoesUF ,
                                             string A707SerasaAcoesPrincipal ,
                                             string A708SerasaAcoesTipoMoeda ,
                                             short A709SerasaAcoesQtdOco ,
                                             int AV55Serasaacoeswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[21];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaAcoesUF, SerasaAcoesQtdOco, SerasaAcoesTipoMoeda, SerasaAcoesPrincipal, SerasaAcoesCidade, SerasaAcoesVara, SerasaAcoesDistribuidor, SerasaAcoesValor, SerasaAcoesNatureza, SerasaAcoesData, SerasaAcoesId FROM SerasaAcoes";
         AddWhere(sWhereString, "(SerasaId = :AV55Serasaacoeswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV56Serasaacoeswwds_2_tfserasaacoesdata) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData >= :AV56Serasaacoeswwds_2_tfserasaacoesdata)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Serasaacoeswwds_3_tfserasaacoesdata_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData <= :AV57Serasaacoeswwds_3_tfserasaacoesdata_to)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza like :lV58Serasaacoeswwds_4_tfserasaacoesnatureza)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ! ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza = ( :AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel))");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesNatureza))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV60Serasaacoeswwds_6_tfserasaacoesvalor) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor >= :AV60Serasaacoeswwds_6_tfserasaacoesvalor)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Serasaacoeswwds_7_tfserasaacoesvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor <= :AV61Serasaacoeswwds_7_tfserasaacoesvalor_to)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor like :lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ! ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor = ( :AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesDistribuidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara like :lV64Serasaacoeswwds_10_tfserasaacoesvara)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ! ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara = ( :AV65Serasaacoeswwds_11_tfserasaacoesvara_sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesVara))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade like :lV66Serasaacoeswwds_12_tfserasaacoescidade)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ! ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade = ( :AV67Serasaacoeswwds_13_tfserasaacoescidade_sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF like :lV68Serasaacoeswwds_14_tfserasaacoesuf)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ! ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF = ( :AV69Serasaacoeswwds_15_tfserasaacoesuf_sel))");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal like :lV70Serasaacoeswwds_16_tfserasaacoesprincipal)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ! ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal = ( :AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel))");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesPrincipal))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda like :lV72Serasaacoeswwds_18_tfserasaacoestipomoeda)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ! ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda = ( :AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel))");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesTipoMoeda))=0))");
         }
         if ( ! (0==AV74Serasaacoeswwds_20_tfserasaacoesqtdoco) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco >= :AV74Serasaacoeswwds_20_tfserasaacoesqtdoco)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ! (0==AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco <= :AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaAcoesUF";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00D37( IGxContext context ,
                                             DateTime AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                             DateTime AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                             string AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                             string AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                             decimal AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                             decimal AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                             string AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                             string AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                             string AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                             string AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                             string AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                             string AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                             string AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                             string AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                             string AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                             string AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                             string AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                             string AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                             short AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                             short AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                             DateTime A700SerasaAcoesData ,
                                             string A701SerasaAcoesNatureza ,
                                             decimal A702SerasaAcoesValor ,
                                             string A703SerasaAcoesDistribuidor ,
                                             string A704SerasaAcoesVara ,
                                             string A705SerasaAcoesCidade ,
                                             string A706SerasaAcoesUF ,
                                             string A707SerasaAcoesPrincipal ,
                                             string A708SerasaAcoesTipoMoeda ,
                                             short A709SerasaAcoesQtdOco ,
                                             int AV55Serasaacoeswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[21];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaAcoesPrincipal, SerasaAcoesQtdOco, SerasaAcoesTipoMoeda, SerasaAcoesUF, SerasaAcoesCidade, SerasaAcoesVara, SerasaAcoesDistribuidor, SerasaAcoesValor, SerasaAcoesNatureza, SerasaAcoesData, SerasaAcoesId FROM SerasaAcoes";
         AddWhere(sWhereString, "(SerasaId = :AV55Serasaacoeswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV56Serasaacoeswwds_2_tfserasaacoesdata) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData >= :AV56Serasaacoeswwds_2_tfserasaacoesdata)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Serasaacoeswwds_3_tfserasaacoesdata_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData <= :AV57Serasaacoeswwds_3_tfserasaacoesdata_to)");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza like :lV58Serasaacoeswwds_4_tfserasaacoesnatureza)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ! ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza = ( :AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel))");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesNatureza))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV60Serasaacoeswwds_6_tfserasaacoesvalor) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor >= :AV60Serasaacoeswwds_6_tfserasaacoesvalor)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Serasaacoeswwds_7_tfserasaacoesvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor <= :AV61Serasaacoeswwds_7_tfserasaacoesvalor_to)");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor like :lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ! ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor = ( :AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel))");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesDistribuidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara like :lV64Serasaacoeswwds_10_tfserasaacoesvara)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ! ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara = ( :AV65Serasaacoeswwds_11_tfserasaacoesvara_sel))");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesVara))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade like :lV66Serasaacoeswwds_12_tfserasaacoescidade)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ! ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade = ( :AV67Serasaacoeswwds_13_tfserasaacoescidade_sel))");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF like :lV68Serasaacoeswwds_14_tfserasaacoesuf)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ! ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF = ( :AV69Serasaacoeswwds_15_tfserasaacoesuf_sel))");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal like :lV70Serasaacoeswwds_16_tfserasaacoesprincipal)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ! ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal = ( :AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel))");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesPrincipal))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda like :lV72Serasaacoeswwds_18_tfserasaacoestipomoeda)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ! ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda = ( :AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel))");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesTipoMoeda))=0))");
         }
         if ( ! (0==AV74Serasaacoeswwds_20_tfserasaacoesqtdoco) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco >= :AV74Serasaacoeswwds_20_tfserasaacoesqtdoco)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( ! (0==AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco <= :AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaAcoesPrincipal";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P00D38( IGxContext context ,
                                             DateTime AV56Serasaacoeswwds_2_tfserasaacoesdata ,
                                             DateTime AV57Serasaacoeswwds_3_tfserasaacoesdata_to ,
                                             string AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel ,
                                             string AV58Serasaacoeswwds_4_tfserasaacoesnatureza ,
                                             decimal AV60Serasaacoeswwds_6_tfserasaacoesvalor ,
                                             decimal AV61Serasaacoeswwds_7_tfserasaacoesvalor_to ,
                                             string AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel ,
                                             string AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor ,
                                             string AV65Serasaacoeswwds_11_tfserasaacoesvara_sel ,
                                             string AV64Serasaacoeswwds_10_tfserasaacoesvara ,
                                             string AV67Serasaacoeswwds_13_tfserasaacoescidade_sel ,
                                             string AV66Serasaacoeswwds_12_tfserasaacoescidade ,
                                             string AV69Serasaacoeswwds_15_tfserasaacoesuf_sel ,
                                             string AV68Serasaacoeswwds_14_tfserasaacoesuf ,
                                             string AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel ,
                                             string AV70Serasaacoeswwds_16_tfserasaacoesprincipal ,
                                             string AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel ,
                                             string AV72Serasaacoeswwds_18_tfserasaacoestipomoeda ,
                                             short AV74Serasaacoeswwds_20_tfserasaacoesqtdoco ,
                                             short AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to ,
                                             DateTime A700SerasaAcoesData ,
                                             string A701SerasaAcoesNatureza ,
                                             decimal A702SerasaAcoesValor ,
                                             string A703SerasaAcoesDistribuidor ,
                                             string A704SerasaAcoesVara ,
                                             string A705SerasaAcoesCidade ,
                                             string A706SerasaAcoesUF ,
                                             string A707SerasaAcoesPrincipal ,
                                             string A708SerasaAcoesTipoMoeda ,
                                             short A709SerasaAcoesQtdOco ,
                                             int AV55Serasaacoeswwds_1_serasaid ,
                                             int A662SerasaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[21];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT SerasaId, SerasaAcoesTipoMoeda, SerasaAcoesQtdOco, SerasaAcoesPrincipal, SerasaAcoesUF, SerasaAcoesCidade, SerasaAcoesVara, SerasaAcoesDistribuidor, SerasaAcoesValor, SerasaAcoesNatureza, SerasaAcoesData, SerasaAcoesId FROM SerasaAcoes";
         AddWhere(sWhereString, "(SerasaId = :AV55Serasaacoeswwds_1_serasaid)");
         if ( ! (DateTime.MinValue==AV56Serasaacoeswwds_2_tfserasaacoesdata) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData >= :AV56Serasaacoeswwds_2_tfserasaacoesdata)");
         }
         else
         {
            GXv_int13[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Serasaacoeswwds_3_tfserasaacoesdata_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesData <= :AV57Serasaacoeswwds_3_tfserasaacoesdata_to)");
         }
         else
         {
            GXv_int13[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Serasaacoeswwds_4_tfserasaacoesnatureza)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza like :lV58Serasaacoeswwds_4_tfserasaacoesnatureza)");
         }
         else
         {
            GXv_int13[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel)) && ! ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza = ( :AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel))");
         }
         else
         {
            GXv_int13[4] = 1;
         }
         if ( StringUtil.StrCmp(AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesNatureza IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesNatureza))=0))");
         }
         if ( ! (Convert.ToDecimal(0)==AV60Serasaacoeswwds_6_tfserasaacoesvalor) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor >= :AV60Serasaacoeswwds_6_tfserasaacoesvalor)");
         }
         else
         {
            GXv_int13[5] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV61Serasaacoeswwds_7_tfserasaacoesvalor_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesValor <= :AV61Serasaacoeswwds_7_tfserasaacoesvalor_to)");
         }
         else
         {
            GXv_int13[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor like :lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor)");
         }
         else
         {
            GXv_int13[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel)) && ! ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor = ( :AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel))");
         }
         else
         {
            GXv_int13[8] = 1;
         }
         if ( StringUtil.StrCmp(AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesDistribuidor IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesDistribuidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Serasaacoeswwds_10_tfserasaacoesvara)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara like :lV64Serasaacoeswwds_10_tfserasaacoesvara)");
         }
         else
         {
            GXv_int13[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Serasaacoeswwds_11_tfserasaacoesvara_sel)) && ! ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara = ( :AV65Serasaacoeswwds_11_tfserasaacoesvara_sel))");
         }
         else
         {
            GXv_int13[10] = 1;
         }
         if ( StringUtil.StrCmp(AV65Serasaacoeswwds_11_tfserasaacoesvara_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesVara IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesVara))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Serasaacoeswwds_12_tfserasaacoescidade)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade like :lV66Serasaacoeswwds_12_tfserasaacoescidade)");
         }
         else
         {
            GXv_int13[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Serasaacoeswwds_13_tfserasaacoescidade_sel)) && ! ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade = ( :AV67Serasaacoeswwds_13_tfserasaacoescidade_sel))");
         }
         else
         {
            GXv_int13[12] = 1;
         }
         if ( StringUtil.StrCmp(AV67Serasaacoeswwds_13_tfserasaacoescidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesCidade IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesCidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Serasaacoeswwds_14_tfserasaacoesuf)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF like :lV68Serasaacoeswwds_14_tfserasaacoesuf)");
         }
         else
         {
            GXv_int13[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Serasaacoeswwds_15_tfserasaacoesuf_sel)) && ! ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF = ( :AV69Serasaacoeswwds_15_tfserasaacoesuf_sel))");
         }
         else
         {
            GXv_int13[14] = 1;
         }
         if ( StringUtil.StrCmp(AV69Serasaacoeswwds_15_tfserasaacoesuf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesUF IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Serasaacoeswwds_16_tfserasaacoesprincipal)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal like :lV70Serasaacoeswwds_16_tfserasaacoesprincipal)");
         }
         else
         {
            GXv_int13[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel)) && ! ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal = ( :AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel))");
         }
         else
         {
            GXv_int13[16] = 1;
         }
         if ( StringUtil.StrCmp(AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesPrincipal IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesPrincipal))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Serasaacoeswwds_18_tfserasaacoestipomoeda)) ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda like :lV72Serasaacoeswwds_18_tfserasaacoestipomoeda)");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel)) && ! ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda = ( :AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel))");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( StringUtil.StrCmp(AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(SerasaAcoesTipoMoeda IS NULL or (char_length(trim(trailing ' ' from SerasaAcoesTipoMoeda))=0))");
         }
         if ( ! (0==AV74Serasaacoeswwds_20_tfserasaacoesqtdoco) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco >= :AV74Serasaacoeswwds_20_tfserasaacoesqtdoco)");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( ! (0==AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to) )
         {
            AddWhere(sWhereString, "(SerasaAcoesQtdOco <= :AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to)");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY SerasaId, SerasaAcoesTipoMoeda";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00D32(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (int)dynConstraints[30] , (int)dynConstraints[31] );
               case 1 :
                     return conditional_P00D33(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (int)dynConstraints[30] , (int)dynConstraints[31] );
               case 2 :
                     return conditional_P00D34(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (int)dynConstraints[30] , (int)dynConstraints[31] );
               case 3 :
                     return conditional_P00D35(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (int)dynConstraints[30] , (int)dynConstraints[31] );
               case 4 :
                     return conditional_P00D36(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (int)dynConstraints[30] , (int)dynConstraints[31] );
               case 5 :
                     return conditional_P00D37(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (int)dynConstraints[30] , (int)dynConstraints[31] );
               case 6 :
                     return conditional_P00D38(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (decimal)dynConstraints[4] , (decimal)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (int)dynConstraints[30] , (int)dynConstraints[31] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00D32;
          prmP00D32 = new Object[] {
          new ParDef("AV55Serasaacoeswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV56Serasaacoeswwds_2_tfserasaacoesdata",GXType.Date,8,0) ,
          new ParDef("AV57Serasaacoeswwds_3_tfserasaacoesdata_to",GXType.Date,8,0) ,
          new ParDef("lV58Serasaacoeswwds_4_tfserasaacoesnatureza",GXType.VarChar,100,0) ,
          new ParDef("AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel",GXType.VarChar,100,0) ,
          new ParDef("AV60Serasaacoeswwds_6_tfserasaacoesvalor",GXType.Number,18,2) ,
          new ParDef("AV61Serasaacoeswwds_7_tfserasaacoesvalor_to",GXType.Number,18,2) ,
          new ParDef("lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaacoeswwds_10_tfserasaacoesvara",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaacoeswwds_11_tfserasaacoesvara_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaacoeswwds_12_tfserasaacoescidade",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaacoeswwds_13_tfserasaacoescidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaacoeswwds_14_tfserasaacoesuf",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaacoeswwds_15_tfserasaacoesuf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaacoeswwds_16_tfserasaacoesprincipal",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel",GXType.VarChar,40,0) ,
          new ParDef("lV72Serasaacoeswwds_18_tfserasaacoestipomoeda",GXType.VarChar,40,0) ,
          new ParDef("AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel",GXType.VarChar,40,0) ,
          new ParDef("AV74Serasaacoeswwds_20_tfserasaacoesqtdoco",GXType.Int16,4,0) ,
          new ParDef("AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to",GXType.Int16,4,0)
          };
          Object[] prmP00D33;
          prmP00D33 = new Object[] {
          new ParDef("AV55Serasaacoeswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV56Serasaacoeswwds_2_tfserasaacoesdata",GXType.Date,8,0) ,
          new ParDef("AV57Serasaacoeswwds_3_tfserasaacoesdata_to",GXType.Date,8,0) ,
          new ParDef("lV58Serasaacoeswwds_4_tfserasaacoesnatureza",GXType.VarChar,100,0) ,
          new ParDef("AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel",GXType.VarChar,100,0) ,
          new ParDef("AV60Serasaacoeswwds_6_tfserasaacoesvalor",GXType.Number,18,2) ,
          new ParDef("AV61Serasaacoeswwds_7_tfserasaacoesvalor_to",GXType.Number,18,2) ,
          new ParDef("lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaacoeswwds_10_tfserasaacoesvara",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaacoeswwds_11_tfserasaacoesvara_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaacoeswwds_12_tfserasaacoescidade",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaacoeswwds_13_tfserasaacoescidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaacoeswwds_14_tfserasaacoesuf",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaacoeswwds_15_tfserasaacoesuf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaacoeswwds_16_tfserasaacoesprincipal",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel",GXType.VarChar,40,0) ,
          new ParDef("lV72Serasaacoeswwds_18_tfserasaacoestipomoeda",GXType.VarChar,40,0) ,
          new ParDef("AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel",GXType.VarChar,40,0) ,
          new ParDef("AV74Serasaacoeswwds_20_tfserasaacoesqtdoco",GXType.Int16,4,0) ,
          new ParDef("AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to",GXType.Int16,4,0)
          };
          Object[] prmP00D34;
          prmP00D34 = new Object[] {
          new ParDef("AV55Serasaacoeswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV56Serasaacoeswwds_2_tfserasaacoesdata",GXType.Date,8,0) ,
          new ParDef("AV57Serasaacoeswwds_3_tfserasaacoesdata_to",GXType.Date,8,0) ,
          new ParDef("lV58Serasaacoeswwds_4_tfserasaacoesnatureza",GXType.VarChar,100,0) ,
          new ParDef("AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel",GXType.VarChar,100,0) ,
          new ParDef("AV60Serasaacoeswwds_6_tfserasaacoesvalor",GXType.Number,18,2) ,
          new ParDef("AV61Serasaacoeswwds_7_tfserasaacoesvalor_to",GXType.Number,18,2) ,
          new ParDef("lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaacoeswwds_10_tfserasaacoesvara",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaacoeswwds_11_tfserasaacoesvara_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaacoeswwds_12_tfserasaacoescidade",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaacoeswwds_13_tfserasaacoescidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaacoeswwds_14_tfserasaacoesuf",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaacoeswwds_15_tfserasaacoesuf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaacoeswwds_16_tfserasaacoesprincipal",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel",GXType.VarChar,40,0) ,
          new ParDef("lV72Serasaacoeswwds_18_tfserasaacoestipomoeda",GXType.VarChar,40,0) ,
          new ParDef("AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel",GXType.VarChar,40,0) ,
          new ParDef("AV74Serasaacoeswwds_20_tfserasaacoesqtdoco",GXType.Int16,4,0) ,
          new ParDef("AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to",GXType.Int16,4,0)
          };
          Object[] prmP00D35;
          prmP00D35 = new Object[] {
          new ParDef("AV55Serasaacoeswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV56Serasaacoeswwds_2_tfserasaacoesdata",GXType.Date,8,0) ,
          new ParDef("AV57Serasaacoeswwds_3_tfserasaacoesdata_to",GXType.Date,8,0) ,
          new ParDef("lV58Serasaacoeswwds_4_tfserasaacoesnatureza",GXType.VarChar,100,0) ,
          new ParDef("AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel",GXType.VarChar,100,0) ,
          new ParDef("AV60Serasaacoeswwds_6_tfserasaacoesvalor",GXType.Number,18,2) ,
          new ParDef("AV61Serasaacoeswwds_7_tfserasaacoesvalor_to",GXType.Number,18,2) ,
          new ParDef("lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaacoeswwds_10_tfserasaacoesvara",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaacoeswwds_11_tfserasaacoesvara_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaacoeswwds_12_tfserasaacoescidade",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaacoeswwds_13_tfserasaacoescidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaacoeswwds_14_tfserasaacoesuf",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaacoeswwds_15_tfserasaacoesuf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaacoeswwds_16_tfserasaacoesprincipal",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel",GXType.VarChar,40,0) ,
          new ParDef("lV72Serasaacoeswwds_18_tfserasaacoestipomoeda",GXType.VarChar,40,0) ,
          new ParDef("AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel",GXType.VarChar,40,0) ,
          new ParDef("AV74Serasaacoeswwds_20_tfserasaacoesqtdoco",GXType.Int16,4,0) ,
          new ParDef("AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to",GXType.Int16,4,0)
          };
          Object[] prmP00D36;
          prmP00D36 = new Object[] {
          new ParDef("AV55Serasaacoeswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV56Serasaacoeswwds_2_tfserasaacoesdata",GXType.Date,8,0) ,
          new ParDef("AV57Serasaacoeswwds_3_tfserasaacoesdata_to",GXType.Date,8,0) ,
          new ParDef("lV58Serasaacoeswwds_4_tfserasaacoesnatureza",GXType.VarChar,100,0) ,
          new ParDef("AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel",GXType.VarChar,100,0) ,
          new ParDef("AV60Serasaacoeswwds_6_tfserasaacoesvalor",GXType.Number,18,2) ,
          new ParDef("AV61Serasaacoeswwds_7_tfserasaacoesvalor_to",GXType.Number,18,2) ,
          new ParDef("lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaacoeswwds_10_tfserasaacoesvara",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaacoeswwds_11_tfserasaacoesvara_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaacoeswwds_12_tfserasaacoescidade",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaacoeswwds_13_tfserasaacoescidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaacoeswwds_14_tfserasaacoesuf",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaacoeswwds_15_tfserasaacoesuf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaacoeswwds_16_tfserasaacoesprincipal",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel",GXType.VarChar,40,0) ,
          new ParDef("lV72Serasaacoeswwds_18_tfserasaacoestipomoeda",GXType.VarChar,40,0) ,
          new ParDef("AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel",GXType.VarChar,40,0) ,
          new ParDef("AV74Serasaacoeswwds_20_tfserasaacoesqtdoco",GXType.Int16,4,0) ,
          new ParDef("AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to",GXType.Int16,4,0)
          };
          Object[] prmP00D37;
          prmP00D37 = new Object[] {
          new ParDef("AV55Serasaacoeswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV56Serasaacoeswwds_2_tfserasaacoesdata",GXType.Date,8,0) ,
          new ParDef("AV57Serasaacoeswwds_3_tfserasaacoesdata_to",GXType.Date,8,0) ,
          new ParDef("lV58Serasaacoeswwds_4_tfserasaacoesnatureza",GXType.VarChar,100,0) ,
          new ParDef("AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel",GXType.VarChar,100,0) ,
          new ParDef("AV60Serasaacoeswwds_6_tfserasaacoesvalor",GXType.Number,18,2) ,
          new ParDef("AV61Serasaacoeswwds_7_tfserasaacoesvalor_to",GXType.Number,18,2) ,
          new ParDef("lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaacoeswwds_10_tfserasaacoesvara",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaacoeswwds_11_tfserasaacoesvara_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaacoeswwds_12_tfserasaacoescidade",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaacoeswwds_13_tfserasaacoescidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaacoeswwds_14_tfserasaacoesuf",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaacoeswwds_15_tfserasaacoesuf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaacoeswwds_16_tfserasaacoesprincipal",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel",GXType.VarChar,40,0) ,
          new ParDef("lV72Serasaacoeswwds_18_tfserasaacoestipomoeda",GXType.VarChar,40,0) ,
          new ParDef("AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel",GXType.VarChar,40,0) ,
          new ParDef("AV74Serasaacoeswwds_20_tfserasaacoesqtdoco",GXType.Int16,4,0) ,
          new ParDef("AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to",GXType.Int16,4,0)
          };
          Object[] prmP00D38;
          prmP00D38 = new Object[] {
          new ParDef("AV55Serasaacoeswwds_1_serasaid",GXType.Int32,9,0) ,
          new ParDef("AV56Serasaacoeswwds_2_tfserasaacoesdata",GXType.Date,8,0) ,
          new ParDef("AV57Serasaacoeswwds_3_tfserasaacoesdata_to",GXType.Date,8,0) ,
          new ParDef("lV58Serasaacoeswwds_4_tfserasaacoesnatureza",GXType.VarChar,100,0) ,
          new ParDef("AV59Serasaacoeswwds_5_tfserasaacoesnatureza_sel",GXType.VarChar,100,0) ,
          new ParDef("AV60Serasaacoeswwds_6_tfserasaacoesvalor",GXType.Number,18,2) ,
          new ParDef("AV61Serasaacoeswwds_7_tfserasaacoesvalor_to",GXType.Number,18,2) ,
          new ParDef("lV62Serasaacoeswwds_8_tfserasaacoesdistribuidor",GXType.VarChar,100,0) ,
          new ParDef("AV63Serasaacoeswwds_9_tfserasaacoesdistribuidor_sel",GXType.VarChar,100,0) ,
          new ParDef("lV64Serasaacoeswwds_10_tfserasaacoesvara",GXType.VarChar,40,0) ,
          new ParDef("AV65Serasaacoeswwds_11_tfserasaacoesvara_sel",GXType.VarChar,40,0) ,
          new ParDef("lV66Serasaacoeswwds_12_tfserasaacoescidade",GXType.VarChar,40,0) ,
          new ParDef("AV67Serasaacoeswwds_13_tfserasaacoescidade_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Serasaacoeswwds_14_tfserasaacoesuf",GXType.VarChar,40,0) ,
          new ParDef("AV69Serasaacoeswwds_15_tfserasaacoesuf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Serasaacoeswwds_16_tfserasaacoesprincipal",GXType.VarChar,40,0) ,
          new ParDef("AV71Serasaacoeswwds_17_tfserasaacoesprincipal_sel",GXType.VarChar,40,0) ,
          new ParDef("lV72Serasaacoeswwds_18_tfserasaacoestipomoeda",GXType.VarChar,40,0) ,
          new ParDef("AV73Serasaacoeswwds_19_tfserasaacoestipomoeda_sel",GXType.VarChar,40,0) ,
          new ParDef("AV74Serasaacoeswwds_20_tfserasaacoesqtdoco",GXType.Int16,4,0) ,
          new ParDef("AV75Serasaacoeswwds_21_tfserasaacoesqtdoco_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00D32", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D32,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D33", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D33,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D34", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D34,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D35", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D35,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D36", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D36,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D37", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D37,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00D38", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D38,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((decimal[]) buf[18])[0] = rslt.getDecimal(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 6 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((decimal[]) buf[16])[0] = rslt.getDecimal(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
       }
    }

 }

}
