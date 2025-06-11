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
   public class representantewwgetfilterdata : GXProcedure
   {
      public representantewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public representantewwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_REPRESENTANTENOME") == 0 )
         {
            /* Execute user subroutine: 'LOADREPRESENTANTENOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_REPRESENTANTERG") == 0 )
         {
            /* Execute user subroutine: 'LOADREPRESENTANTERGOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_REPRESENTANTEORGAOEXPEDIDOR") == 0 )
         {
            /* Execute user subroutine: 'LOADREPRESENTANTEORGAOEXPEDIDOROPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_REPRESENTANTERGUF") == 0 )
         {
            /* Execute user subroutine: 'LOADREPRESENTANTERGUFOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_REPRESENTANTECPF") == 0 )
         {
            /* Execute user subroutine: 'LOADREPRESENTANTECPFOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_REPRESENTANTENACIONALIDADE") == 0 )
         {
            /* Execute user subroutine: 'LOADREPRESENTANTENACIONALIDADEOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_REPRESENTANTEPROFISSAODESCRICAO") == 0 )
         {
            /* Execute user subroutine: 'LOADREPRESENTANTEPROFISSAODESCRICAOOPTIONS' */
            S181 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV46DDOName), "DDO_REPRESENTANTEEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADREPRESENTANTEEMAILOPTIONS' */
            S191 ();
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
         if ( StringUtil.StrCmp(AV41Session.Get("RepresentanteWWGridState"), "") == 0 )
         {
            AV43GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RepresentanteWWGridState"), null, "", "");
         }
         else
         {
            AV43GridState.FromXml(AV41Session.Get("RepresentanteWWGridState"), null, "", "");
         }
         AV70GXV1 = 1;
         while ( AV70GXV1 <= AV43GridState.gxTpr_Filtervalues.Count )
         {
            AV44GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV43GridState.gxTpr_Filtervalues.Item(AV70GXV1));
            if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV52FilterFullText = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTENOME") == 0 )
            {
               AV10TFRepresentanteNome = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTENOME_SEL") == 0 )
            {
               AV11TFRepresentanteNome_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTERG") == 0 )
            {
               AV12TFRepresentanteRG = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTERG_SEL") == 0 )
            {
               AV13TFRepresentanteRG_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEORGAOEXPEDIDOR") == 0 )
            {
               AV14TFRepresentanteOrgaoExpedidor = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEORGAOEXPEDIDOR_SEL") == 0 )
            {
               AV15TFRepresentanteOrgaoExpedidor_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTERGUF") == 0 )
            {
               AV16TFRepresentanteRGUF = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTERGUF_SEL") == 0 )
            {
               AV17TFRepresentanteRGUF_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTECPF") == 0 )
            {
               AV18TFRepresentanteCPF = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTECPF_SEL") == 0 )
            {
               AV19TFRepresentanteCPF_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEESTADOCIVIL_SEL") == 0 )
            {
               AV20TFRepresentanteEstadoCivil_SelsJson = AV44GridStateFilterValue.gxTpr_Value;
               AV21TFRepresentanteEstadoCivil_Sels.FromJSonString(AV20TFRepresentanteEstadoCivil_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTENACIONALIDADE") == 0 )
            {
               AV22TFRepresentanteNacionalidade = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTENACIONALIDADE_SEL") == 0 )
            {
               AV23TFRepresentanteNacionalidade_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEPROFISSAODESCRICAO") == 0 )
            {
               AV68TFRepresentanteProfissaoDescricao = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEPROFISSAODESCRICAO_SEL") == 0 )
            {
               AV69TFRepresentanteProfissaoDescricao_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEEMAIL") == 0 )
            {
               AV26TFRepresentanteEmail = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTEEMAIL_SEL") == 0 )
            {
               AV27TFRepresentanteEmail_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFREPRESENTANTETIPO_SEL") == 0 )
            {
               AV28TFRepresentanteTipo_SelsJson = AV44GridStateFilterValue.gxTpr_Value;
               AV29TFRepresentanteTipo_Sels.FromJSonString(AV28TFRepresentanteTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "PARM_&CLIENTEID") == 0 )
            {
               AV67ClienteId = (int)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV70GXV1 = (int)(AV70GXV1+1);
         }
         if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV45GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(1));
            AV53DynamicFiltersSelector1 = AV45GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV53DynamicFiltersSelector1, "REPRESENTANTENOME") == 0 )
            {
               AV54DynamicFiltersOperator1 = AV45GridStateDynamicFilter.gxTpr_Operator;
               AV55RepresentanteNome1 = AV45GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector1, "REPRESENTANTEMUNICIPIONOME") == 0 )
            {
               AV54DynamicFiltersOperator1 = AV45GridStateDynamicFilter.gxTpr_Operator;
               AV56RepresentanteMunicipioNome1 = AV45GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV57DynamicFiltersEnabled2 = true;
               AV45GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(2));
               AV58DynamicFiltersSelector2 = AV45GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "REPRESENTANTENOME") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV45GridStateDynamicFilter.gxTpr_Operator;
                  AV60RepresentanteNome2 = AV45GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "REPRESENTANTEMUNICIPIONOME") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV45GridStateDynamicFilter.gxTpr_Operator;
                  AV61RepresentanteMunicipioNome2 = AV45GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV62DynamicFiltersEnabled3 = true;
                  AV45GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(3));
                  AV63DynamicFiltersSelector3 = AV45GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV63DynamicFiltersSelector3, "REPRESENTANTENOME") == 0 )
                  {
                     AV64DynamicFiltersOperator3 = AV45GridStateDynamicFilter.gxTpr_Operator;
                     AV65RepresentanteNome3 = AV45GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV63DynamicFiltersSelector3, "REPRESENTANTEMUNICIPIONOME") == 0 )
                  {
                     AV64DynamicFiltersOperator3 = AV45GridStateDynamicFilter.gxTpr_Operator;
                     AV66RepresentanteMunicipioNome3 = AV45GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADREPRESENTANTENOMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFRepresentanteNome = AV30SearchTxt;
         AV11TFRepresentanteNome_Sel = "";
         AV72Representantewwds_1_filterfulltext = AV52FilterFullText;
         AV73Representantewwds_2_dynamicfiltersselector1 = AV53DynamicFiltersSelector1;
         AV74Representantewwds_3_dynamicfiltersoperator1 = AV54DynamicFiltersOperator1;
         AV75Representantewwds_4_representantenome1 = AV55RepresentanteNome1;
         AV76Representantewwds_5_representantemunicipionome1 = AV56RepresentanteMunicipioNome1;
         AV77Representantewwds_6_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV78Representantewwds_7_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV79Representantewwds_8_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV80Representantewwds_9_representantenome2 = AV60RepresentanteNome2;
         AV81Representantewwds_10_representantemunicipionome2 = AV61RepresentanteMunicipioNome2;
         AV82Representantewwds_11_dynamicfiltersenabled3 = AV62DynamicFiltersEnabled3;
         AV83Representantewwds_12_dynamicfiltersselector3 = AV63DynamicFiltersSelector3;
         AV84Representantewwds_13_dynamicfiltersoperator3 = AV64DynamicFiltersOperator3;
         AV85Representantewwds_14_representantenome3 = AV65RepresentanteNome3;
         AV86Representantewwds_15_representantemunicipionome3 = AV66RepresentanteMunicipioNome3;
         AV87Representantewwds_16_tfrepresentantenome = AV10TFRepresentanteNome;
         AV88Representantewwds_17_tfrepresentantenome_sel = AV11TFRepresentanteNome_Sel;
         AV89Representantewwds_18_tfrepresentanterg = AV12TFRepresentanteRG;
         AV90Representantewwds_19_tfrepresentanterg_sel = AV13TFRepresentanteRG_Sel;
         AV91Representantewwds_20_tfrepresentanteorgaoexpedidor = AV14TFRepresentanteOrgaoExpedidor;
         AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV15TFRepresentanteOrgaoExpedidor_Sel;
         AV93Representantewwds_22_tfrepresentanterguf = AV16TFRepresentanteRGUF;
         AV94Representantewwds_23_tfrepresentanterguf_sel = AV17TFRepresentanteRGUF_Sel;
         AV95Representantewwds_24_tfrepresentantecpf = AV18TFRepresentanteCPF;
         AV96Representantewwds_25_tfrepresentantecpf_sel = AV19TFRepresentanteCPF_Sel;
         AV97Representantewwds_26_tfrepresentanteestadocivil_sels = AV21TFRepresentanteEstadoCivil_Sels;
         AV98Representantewwds_27_tfrepresentantenacionalidade = AV22TFRepresentanteNacionalidade;
         AV99Representantewwds_28_tfrepresentantenacionalidade_sel = AV23TFRepresentanteNacionalidade_Sel;
         AV100Representantewwds_29_tfrepresentanteprofissaodescricao = AV68TFRepresentanteProfissaoDescricao;
         AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV69TFRepresentanteProfissaoDescricao_Sel;
         AV102Representantewwds_31_tfrepresentanteemail = AV26TFRepresentanteEmail;
         AV103Representantewwds_32_tfrepresentanteemail_sel = AV27TFRepresentanteEmail_Sel;
         AV104Representantewwds_33_tfrepresentantetipo_sels = AV29TFRepresentanteTipo_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A984RepresentanteEstadoCivil ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                              A998RepresentanteTipo ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                              AV72Representantewwds_1_filterfulltext ,
                                              AV73Representantewwds_2_dynamicfiltersselector1 ,
                                              AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                              AV75Representantewwds_4_representantenome1 ,
                                              AV76Representantewwds_5_representantemunicipionome1 ,
                                              AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                              AV78Representantewwds_7_dynamicfiltersselector2 ,
                                              AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                              AV80Representantewwds_9_representantenome2 ,
                                              AV81Representantewwds_10_representantemunicipionome2 ,
                                              AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                              AV83Representantewwds_12_dynamicfiltersselector3 ,
                                              AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                              AV85Representantewwds_14_representantenome3 ,
                                              AV86Representantewwds_15_representantemunicipionome3 ,
                                              AV88Representantewwds_17_tfrepresentantenome_sel ,
                                              AV87Representantewwds_16_tfrepresentantenome ,
                                              AV90Representantewwds_19_tfrepresentanterg_sel ,
                                              AV89Representantewwds_18_tfrepresentanterg ,
                                              AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                              AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                              AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                              AV93Representantewwds_22_tfrepresentanterguf ,
                                              AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                              AV95Representantewwds_24_tfrepresentantecpf ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels.Count ,
                                              AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                              AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                              AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                              AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                              AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                              AV102Representantewwds_31_tfrepresentanteemail ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels.Count ,
                                              A979RepresentanteNome ,
                                              A980RepresentanteRG ,
                                              A981RepresentanteOrgaoExpedidor ,
                                              A982RepresentanteRGUF ,
                                              A983RepresentanteCPF ,
                                              A985RepresentanteNacionalidade ,
                                              A999RepresentanteProfissaoDescricao ,
                                              A986RepresentanteEmail ,
                                              A997RepresentanteMunicipioNome ,
                                              A168ClienteId ,
                                              AV67ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT
                                              }
         });
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV87Representantewwds_16_tfrepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome), "%", "");
         lV89Representantewwds_18_tfrepresentanterg = StringUtil.Concat( StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg), "%", "");
         lV91Representantewwds_20_tfrepresentanteorgaoexpedidor = StringUtil.Concat( StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor), "%", "");
         lV93Representantewwds_22_tfrepresentanterguf = StringUtil.Concat( StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf), "%", "");
         lV95Representantewwds_24_tfrepresentantecpf = StringUtil.Concat( StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf), "%", "");
         lV98Representantewwds_27_tfrepresentantenacionalidade = StringUtil.Concat( StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade), "%", "");
         lV100Representantewwds_29_tfrepresentanteprofissaodescricao = StringUtil.Concat( StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao), "%", "");
         lV102Representantewwds_31_tfrepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail), "%", "");
         /* Using cursor P00EX2 */
         pr_default.execute(0, new Object[] {AV67ClienteId, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV75Representantewwds_4_representantenome1, lV75Representantewwds_4_representantenome1, lV76Representantewwds_5_representantemunicipionome1, lV76Representantewwds_5_representantemunicipionome1, lV80Representantewwds_9_representantenome2, lV80Representantewwds_9_representantenome2, lV81Representantewwds_10_representantemunicipionome2, lV81Representantewwds_10_representantemunicipionome2, lV85Representantewwds_14_representantenome3, lV85Representantewwds_14_representantenome3, lV86Representantewwds_15_representantemunicipionome3, lV86Representantewwds_15_representantemunicipionome3, lV87Representantewwds_16_tfrepresentantenome, AV88Representantewwds_17_tfrepresentantenome_sel, lV89Representantewwds_18_tfrepresentanterg, AV90Representantewwds_19_tfrepresentanterg_sel, lV91Representantewwds_20_tfrepresentanteorgaoexpedidor, AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, lV93Representantewwds_22_tfrepresentanterguf, AV94Representantewwds_23_tfrepresentanterguf_sel, lV95Representantewwds_24_tfrepresentantecpf, AV96Representantewwds_25_tfrepresentantecpf_sel, lV98Representantewwds_27_tfrepresentantenacionalidade, AV99Representantewwds_28_tfrepresentantenacionalidade_sel, lV100Representantewwds_29_tfrepresentanteprofissaodescricao, AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, lV102Representantewwds_31_tfrepresentanteemail, AV103Representantewwds_32_tfrepresentanteemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKEX2 = false;
            A977RepresentanteProfissao = P00EX2_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = P00EX2_n977RepresentanteProfissao[0];
            A991RepresentanteMunicipio = P00EX2_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = P00EX2_n991RepresentanteMunicipio[0];
            A168ClienteId = P00EX2_A168ClienteId[0];
            n168ClienteId = P00EX2_n168ClienteId[0];
            A979RepresentanteNome = P00EX2_A979RepresentanteNome[0];
            n979RepresentanteNome = P00EX2_n979RepresentanteNome[0];
            A997RepresentanteMunicipioNome = P00EX2_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX2_n997RepresentanteMunicipioNome[0];
            A998RepresentanteTipo = P00EX2_A998RepresentanteTipo[0];
            n998RepresentanteTipo = P00EX2_n998RepresentanteTipo[0];
            A986RepresentanteEmail = P00EX2_A986RepresentanteEmail[0];
            n986RepresentanteEmail = P00EX2_n986RepresentanteEmail[0];
            A999RepresentanteProfissaoDescricao = P00EX2_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX2_n999RepresentanteProfissaoDescricao[0];
            A985RepresentanteNacionalidade = P00EX2_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = P00EX2_n985RepresentanteNacionalidade[0];
            A984RepresentanteEstadoCivil = P00EX2_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = P00EX2_n984RepresentanteEstadoCivil[0];
            A983RepresentanteCPF = P00EX2_A983RepresentanteCPF[0];
            n983RepresentanteCPF = P00EX2_n983RepresentanteCPF[0];
            A982RepresentanteRGUF = P00EX2_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = P00EX2_n982RepresentanteRGUF[0];
            A981RepresentanteOrgaoExpedidor = P00EX2_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = P00EX2_n981RepresentanteOrgaoExpedidor[0];
            A980RepresentanteRG = P00EX2_A980RepresentanteRG[0];
            n980RepresentanteRG = P00EX2_n980RepresentanteRG[0];
            A978RepresentanteId = P00EX2_A978RepresentanteId[0];
            A999RepresentanteProfissaoDescricao = P00EX2_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX2_n999RepresentanteProfissaoDescricao[0];
            A997RepresentanteMunicipioNome = P00EX2_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX2_n997RepresentanteMunicipioNome[0];
            AV40count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00EX2_A979RepresentanteNome[0], A979RepresentanteNome) == 0 ) )
            {
               BRKEX2 = false;
               A978RepresentanteId = P00EX2_A978RepresentanteId[0];
               AV40count = (long)(AV40count+1);
               BRKEX2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A979RepresentanteNome)) ? "<#Empty#>" : A979RepresentanteNome);
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
            if ( ! BRKEX2 )
            {
               BRKEX2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADREPRESENTANTERGOPTIONS' Routine */
         returnInSub = false;
         AV12TFRepresentanteRG = AV30SearchTxt;
         AV13TFRepresentanteRG_Sel = "";
         AV72Representantewwds_1_filterfulltext = AV52FilterFullText;
         AV73Representantewwds_2_dynamicfiltersselector1 = AV53DynamicFiltersSelector1;
         AV74Representantewwds_3_dynamicfiltersoperator1 = AV54DynamicFiltersOperator1;
         AV75Representantewwds_4_representantenome1 = AV55RepresentanteNome1;
         AV76Representantewwds_5_representantemunicipionome1 = AV56RepresentanteMunicipioNome1;
         AV77Representantewwds_6_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV78Representantewwds_7_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV79Representantewwds_8_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV80Representantewwds_9_representantenome2 = AV60RepresentanteNome2;
         AV81Representantewwds_10_representantemunicipionome2 = AV61RepresentanteMunicipioNome2;
         AV82Representantewwds_11_dynamicfiltersenabled3 = AV62DynamicFiltersEnabled3;
         AV83Representantewwds_12_dynamicfiltersselector3 = AV63DynamicFiltersSelector3;
         AV84Representantewwds_13_dynamicfiltersoperator3 = AV64DynamicFiltersOperator3;
         AV85Representantewwds_14_representantenome3 = AV65RepresentanteNome3;
         AV86Representantewwds_15_representantemunicipionome3 = AV66RepresentanteMunicipioNome3;
         AV87Representantewwds_16_tfrepresentantenome = AV10TFRepresentanteNome;
         AV88Representantewwds_17_tfrepresentantenome_sel = AV11TFRepresentanteNome_Sel;
         AV89Representantewwds_18_tfrepresentanterg = AV12TFRepresentanteRG;
         AV90Representantewwds_19_tfrepresentanterg_sel = AV13TFRepresentanteRG_Sel;
         AV91Representantewwds_20_tfrepresentanteorgaoexpedidor = AV14TFRepresentanteOrgaoExpedidor;
         AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV15TFRepresentanteOrgaoExpedidor_Sel;
         AV93Representantewwds_22_tfrepresentanterguf = AV16TFRepresentanteRGUF;
         AV94Representantewwds_23_tfrepresentanterguf_sel = AV17TFRepresentanteRGUF_Sel;
         AV95Representantewwds_24_tfrepresentantecpf = AV18TFRepresentanteCPF;
         AV96Representantewwds_25_tfrepresentantecpf_sel = AV19TFRepresentanteCPF_Sel;
         AV97Representantewwds_26_tfrepresentanteestadocivil_sels = AV21TFRepresentanteEstadoCivil_Sels;
         AV98Representantewwds_27_tfrepresentantenacionalidade = AV22TFRepresentanteNacionalidade;
         AV99Representantewwds_28_tfrepresentantenacionalidade_sel = AV23TFRepresentanteNacionalidade_Sel;
         AV100Representantewwds_29_tfrepresentanteprofissaodescricao = AV68TFRepresentanteProfissaoDescricao;
         AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV69TFRepresentanteProfissaoDescricao_Sel;
         AV102Representantewwds_31_tfrepresentanteemail = AV26TFRepresentanteEmail;
         AV103Representantewwds_32_tfrepresentanteemail_sel = AV27TFRepresentanteEmail_Sel;
         AV104Representantewwds_33_tfrepresentantetipo_sels = AV29TFRepresentanteTipo_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A984RepresentanteEstadoCivil ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                              A998RepresentanteTipo ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                              AV72Representantewwds_1_filterfulltext ,
                                              AV73Representantewwds_2_dynamicfiltersselector1 ,
                                              AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                              AV75Representantewwds_4_representantenome1 ,
                                              AV76Representantewwds_5_representantemunicipionome1 ,
                                              AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                              AV78Representantewwds_7_dynamicfiltersselector2 ,
                                              AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                              AV80Representantewwds_9_representantenome2 ,
                                              AV81Representantewwds_10_representantemunicipionome2 ,
                                              AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                              AV83Representantewwds_12_dynamicfiltersselector3 ,
                                              AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                              AV85Representantewwds_14_representantenome3 ,
                                              AV86Representantewwds_15_representantemunicipionome3 ,
                                              AV88Representantewwds_17_tfrepresentantenome_sel ,
                                              AV87Representantewwds_16_tfrepresentantenome ,
                                              AV90Representantewwds_19_tfrepresentanterg_sel ,
                                              AV89Representantewwds_18_tfrepresentanterg ,
                                              AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                              AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                              AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                              AV93Representantewwds_22_tfrepresentanterguf ,
                                              AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                              AV95Representantewwds_24_tfrepresentantecpf ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels.Count ,
                                              AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                              AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                              AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                              AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                              AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                              AV102Representantewwds_31_tfrepresentanteemail ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels.Count ,
                                              A979RepresentanteNome ,
                                              A980RepresentanteRG ,
                                              A981RepresentanteOrgaoExpedidor ,
                                              A982RepresentanteRGUF ,
                                              A983RepresentanteCPF ,
                                              A985RepresentanteNacionalidade ,
                                              A999RepresentanteProfissaoDescricao ,
                                              A986RepresentanteEmail ,
                                              A997RepresentanteMunicipioNome ,
                                              A168ClienteId ,
                                              AV67ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT
                                              }
         });
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV87Representantewwds_16_tfrepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome), "%", "");
         lV89Representantewwds_18_tfrepresentanterg = StringUtil.Concat( StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg), "%", "");
         lV91Representantewwds_20_tfrepresentanteorgaoexpedidor = StringUtil.Concat( StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor), "%", "");
         lV93Representantewwds_22_tfrepresentanterguf = StringUtil.Concat( StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf), "%", "");
         lV95Representantewwds_24_tfrepresentantecpf = StringUtil.Concat( StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf), "%", "");
         lV98Representantewwds_27_tfrepresentantenacionalidade = StringUtil.Concat( StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade), "%", "");
         lV100Representantewwds_29_tfrepresentanteprofissaodescricao = StringUtil.Concat( StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao), "%", "");
         lV102Representantewwds_31_tfrepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail), "%", "");
         /* Using cursor P00EX3 */
         pr_default.execute(1, new Object[] {AV67ClienteId, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV75Representantewwds_4_representantenome1, lV75Representantewwds_4_representantenome1, lV76Representantewwds_5_representantemunicipionome1, lV76Representantewwds_5_representantemunicipionome1, lV80Representantewwds_9_representantenome2, lV80Representantewwds_9_representantenome2, lV81Representantewwds_10_representantemunicipionome2, lV81Representantewwds_10_representantemunicipionome2, lV85Representantewwds_14_representantenome3, lV85Representantewwds_14_representantenome3, lV86Representantewwds_15_representantemunicipionome3, lV86Representantewwds_15_representantemunicipionome3, lV87Representantewwds_16_tfrepresentantenome, AV88Representantewwds_17_tfrepresentantenome_sel, lV89Representantewwds_18_tfrepresentanterg, AV90Representantewwds_19_tfrepresentanterg_sel, lV91Representantewwds_20_tfrepresentanteorgaoexpedidor, AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, lV93Representantewwds_22_tfrepresentanterguf, AV94Representantewwds_23_tfrepresentanterguf_sel, lV95Representantewwds_24_tfrepresentantecpf, AV96Representantewwds_25_tfrepresentantecpf_sel, lV98Representantewwds_27_tfrepresentantenacionalidade, AV99Representantewwds_28_tfrepresentantenacionalidade_sel, lV100Representantewwds_29_tfrepresentanteprofissaodescricao, AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, lV102Representantewwds_31_tfrepresentanteemail, AV103Representantewwds_32_tfrepresentanteemail_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKEX4 = false;
            A977RepresentanteProfissao = P00EX3_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = P00EX3_n977RepresentanteProfissao[0];
            A991RepresentanteMunicipio = P00EX3_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = P00EX3_n991RepresentanteMunicipio[0];
            A168ClienteId = P00EX3_A168ClienteId[0];
            n168ClienteId = P00EX3_n168ClienteId[0];
            A980RepresentanteRG = P00EX3_A980RepresentanteRG[0];
            n980RepresentanteRG = P00EX3_n980RepresentanteRG[0];
            A997RepresentanteMunicipioNome = P00EX3_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX3_n997RepresentanteMunicipioNome[0];
            A998RepresentanteTipo = P00EX3_A998RepresentanteTipo[0];
            n998RepresentanteTipo = P00EX3_n998RepresentanteTipo[0];
            A986RepresentanteEmail = P00EX3_A986RepresentanteEmail[0];
            n986RepresentanteEmail = P00EX3_n986RepresentanteEmail[0];
            A999RepresentanteProfissaoDescricao = P00EX3_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX3_n999RepresentanteProfissaoDescricao[0];
            A985RepresentanteNacionalidade = P00EX3_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = P00EX3_n985RepresentanteNacionalidade[0];
            A984RepresentanteEstadoCivil = P00EX3_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = P00EX3_n984RepresentanteEstadoCivil[0];
            A983RepresentanteCPF = P00EX3_A983RepresentanteCPF[0];
            n983RepresentanteCPF = P00EX3_n983RepresentanteCPF[0];
            A982RepresentanteRGUF = P00EX3_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = P00EX3_n982RepresentanteRGUF[0];
            A981RepresentanteOrgaoExpedidor = P00EX3_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = P00EX3_n981RepresentanteOrgaoExpedidor[0];
            A979RepresentanteNome = P00EX3_A979RepresentanteNome[0];
            n979RepresentanteNome = P00EX3_n979RepresentanteNome[0];
            A978RepresentanteId = P00EX3_A978RepresentanteId[0];
            A999RepresentanteProfissaoDescricao = P00EX3_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX3_n999RepresentanteProfissaoDescricao[0];
            A997RepresentanteMunicipioNome = P00EX3_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX3_n997RepresentanteMunicipioNome[0];
            AV40count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00EX3_A980RepresentanteRG[0], A980RepresentanteRG) == 0 ) )
            {
               BRKEX4 = false;
               A978RepresentanteId = P00EX3_A978RepresentanteId[0];
               AV40count = (long)(AV40count+1);
               BRKEX4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A980RepresentanteRG)) ? "<#Empty#>" : A980RepresentanteRG);
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
            if ( ! BRKEX4 )
            {
               BRKEX4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADREPRESENTANTEORGAOEXPEDIDOROPTIONS' Routine */
         returnInSub = false;
         AV14TFRepresentanteOrgaoExpedidor = AV30SearchTxt;
         AV15TFRepresentanteOrgaoExpedidor_Sel = "";
         AV72Representantewwds_1_filterfulltext = AV52FilterFullText;
         AV73Representantewwds_2_dynamicfiltersselector1 = AV53DynamicFiltersSelector1;
         AV74Representantewwds_3_dynamicfiltersoperator1 = AV54DynamicFiltersOperator1;
         AV75Representantewwds_4_representantenome1 = AV55RepresentanteNome1;
         AV76Representantewwds_5_representantemunicipionome1 = AV56RepresentanteMunicipioNome1;
         AV77Representantewwds_6_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV78Representantewwds_7_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV79Representantewwds_8_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV80Representantewwds_9_representantenome2 = AV60RepresentanteNome2;
         AV81Representantewwds_10_representantemunicipionome2 = AV61RepresentanteMunicipioNome2;
         AV82Representantewwds_11_dynamicfiltersenabled3 = AV62DynamicFiltersEnabled3;
         AV83Representantewwds_12_dynamicfiltersselector3 = AV63DynamicFiltersSelector3;
         AV84Representantewwds_13_dynamicfiltersoperator3 = AV64DynamicFiltersOperator3;
         AV85Representantewwds_14_representantenome3 = AV65RepresentanteNome3;
         AV86Representantewwds_15_representantemunicipionome3 = AV66RepresentanteMunicipioNome3;
         AV87Representantewwds_16_tfrepresentantenome = AV10TFRepresentanteNome;
         AV88Representantewwds_17_tfrepresentantenome_sel = AV11TFRepresentanteNome_Sel;
         AV89Representantewwds_18_tfrepresentanterg = AV12TFRepresentanteRG;
         AV90Representantewwds_19_tfrepresentanterg_sel = AV13TFRepresentanteRG_Sel;
         AV91Representantewwds_20_tfrepresentanteorgaoexpedidor = AV14TFRepresentanteOrgaoExpedidor;
         AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV15TFRepresentanteOrgaoExpedidor_Sel;
         AV93Representantewwds_22_tfrepresentanterguf = AV16TFRepresentanteRGUF;
         AV94Representantewwds_23_tfrepresentanterguf_sel = AV17TFRepresentanteRGUF_Sel;
         AV95Representantewwds_24_tfrepresentantecpf = AV18TFRepresentanteCPF;
         AV96Representantewwds_25_tfrepresentantecpf_sel = AV19TFRepresentanteCPF_Sel;
         AV97Representantewwds_26_tfrepresentanteestadocivil_sels = AV21TFRepresentanteEstadoCivil_Sels;
         AV98Representantewwds_27_tfrepresentantenacionalidade = AV22TFRepresentanteNacionalidade;
         AV99Representantewwds_28_tfrepresentantenacionalidade_sel = AV23TFRepresentanteNacionalidade_Sel;
         AV100Representantewwds_29_tfrepresentanteprofissaodescricao = AV68TFRepresentanteProfissaoDescricao;
         AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV69TFRepresentanteProfissaoDescricao_Sel;
         AV102Representantewwds_31_tfrepresentanteemail = AV26TFRepresentanteEmail;
         AV103Representantewwds_32_tfrepresentanteemail_sel = AV27TFRepresentanteEmail_Sel;
         AV104Representantewwds_33_tfrepresentantetipo_sels = AV29TFRepresentanteTipo_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A984RepresentanteEstadoCivil ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                              A998RepresentanteTipo ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                              AV72Representantewwds_1_filterfulltext ,
                                              AV73Representantewwds_2_dynamicfiltersselector1 ,
                                              AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                              AV75Representantewwds_4_representantenome1 ,
                                              AV76Representantewwds_5_representantemunicipionome1 ,
                                              AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                              AV78Representantewwds_7_dynamicfiltersselector2 ,
                                              AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                              AV80Representantewwds_9_representantenome2 ,
                                              AV81Representantewwds_10_representantemunicipionome2 ,
                                              AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                              AV83Representantewwds_12_dynamicfiltersselector3 ,
                                              AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                              AV85Representantewwds_14_representantenome3 ,
                                              AV86Representantewwds_15_representantemunicipionome3 ,
                                              AV88Representantewwds_17_tfrepresentantenome_sel ,
                                              AV87Representantewwds_16_tfrepresentantenome ,
                                              AV90Representantewwds_19_tfrepresentanterg_sel ,
                                              AV89Representantewwds_18_tfrepresentanterg ,
                                              AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                              AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                              AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                              AV93Representantewwds_22_tfrepresentanterguf ,
                                              AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                              AV95Representantewwds_24_tfrepresentantecpf ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels.Count ,
                                              AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                              AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                              AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                              AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                              AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                              AV102Representantewwds_31_tfrepresentanteemail ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels.Count ,
                                              A979RepresentanteNome ,
                                              A980RepresentanteRG ,
                                              A981RepresentanteOrgaoExpedidor ,
                                              A982RepresentanteRGUF ,
                                              A983RepresentanteCPF ,
                                              A985RepresentanteNacionalidade ,
                                              A999RepresentanteProfissaoDescricao ,
                                              A986RepresentanteEmail ,
                                              A997RepresentanteMunicipioNome ,
                                              A168ClienteId ,
                                              AV67ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT
                                              }
         });
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV87Representantewwds_16_tfrepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome), "%", "");
         lV89Representantewwds_18_tfrepresentanterg = StringUtil.Concat( StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg), "%", "");
         lV91Representantewwds_20_tfrepresentanteorgaoexpedidor = StringUtil.Concat( StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor), "%", "");
         lV93Representantewwds_22_tfrepresentanterguf = StringUtil.Concat( StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf), "%", "");
         lV95Representantewwds_24_tfrepresentantecpf = StringUtil.Concat( StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf), "%", "");
         lV98Representantewwds_27_tfrepresentantenacionalidade = StringUtil.Concat( StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade), "%", "");
         lV100Representantewwds_29_tfrepresentanteprofissaodescricao = StringUtil.Concat( StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao), "%", "");
         lV102Representantewwds_31_tfrepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail), "%", "");
         /* Using cursor P00EX4 */
         pr_default.execute(2, new Object[] {AV67ClienteId, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV75Representantewwds_4_representantenome1, lV75Representantewwds_4_representantenome1, lV76Representantewwds_5_representantemunicipionome1, lV76Representantewwds_5_representantemunicipionome1, lV80Representantewwds_9_representantenome2, lV80Representantewwds_9_representantenome2, lV81Representantewwds_10_representantemunicipionome2, lV81Representantewwds_10_representantemunicipionome2, lV85Representantewwds_14_representantenome3, lV85Representantewwds_14_representantenome3, lV86Representantewwds_15_representantemunicipionome3, lV86Representantewwds_15_representantemunicipionome3, lV87Representantewwds_16_tfrepresentantenome, AV88Representantewwds_17_tfrepresentantenome_sel, lV89Representantewwds_18_tfrepresentanterg, AV90Representantewwds_19_tfrepresentanterg_sel, lV91Representantewwds_20_tfrepresentanteorgaoexpedidor, AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, lV93Representantewwds_22_tfrepresentanterguf, AV94Representantewwds_23_tfrepresentanterguf_sel, lV95Representantewwds_24_tfrepresentantecpf, AV96Representantewwds_25_tfrepresentantecpf_sel, lV98Representantewwds_27_tfrepresentantenacionalidade, AV99Representantewwds_28_tfrepresentantenacionalidade_sel, lV100Representantewwds_29_tfrepresentanteprofissaodescricao, AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, lV102Representantewwds_31_tfrepresentanteemail, AV103Representantewwds_32_tfrepresentanteemail_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKEX6 = false;
            A977RepresentanteProfissao = P00EX4_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = P00EX4_n977RepresentanteProfissao[0];
            A991RepresentanteMunicipio = P00EX4_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = P00EX4_n991RepresentanteMunicipio[0];
            A168ClienteId = P00EX4_A168ClienteId[0];
            n168ClienteId = P00EX4_n168ClienteId[0];
            A981RepresentanteOrgaoExpedidor = P00EX4_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = P00EX4_n981RepresentanteOrgaoExpedidor[0];
            A997RepresentanteMunicipioNome = P00EX4_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX4_n997RepresentanteMunicipioNome[0];
            A998RepresentanteTipo = P00EX4_A998RepresentanteTipo[0];
            n998RepresentanteTipo = P00EX4_n998RepresentanteTipo[0];
            A986RepresentanteEmail = P00EX4_A986RepresentanteEmail[0];
            n986RepresentanteEmail = P00EX4_n986RepresentanteEmail[0];
            A999RepresentanteProfissaoDescricao = P00EX4_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX4_n999RepresentanteProfissaoDescricao[0];
            A985RepresentanteNacionalidade = P00EX4_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = P00EX4_n985RepresentanteNacionalidade[0];
            A984RepresentanteEstadoCivil = P00EX4_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = P00EX4_n984RepresentanteEstadoCivil[0];
            A983RepresentanteCPF = P00EX4_A983RepresentanteCPF[0];
            n983RepresentanteCPF = P00EX4_n983RepresentanteCPF[0];
            A982RepresentanteRGUF = P00EX4_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = P00EX4_n982RepresentanteRGUF[0];
            A980RepresentanteRG = P00EX4_A980RepresentanteRG[0];
            n980RepresentanteRG = P00EX4_n980RepresentanteRG[0];
            A979RepresentanteNome = P00EX4_A979RepresentanteNome[0];
            n979RepresentanteNome = P00EX4_n979RepresentanteNome[0];
            A978RepresentanteId = P00EX4_A978RepresentanteId[0];
            A999RepresentanteProfissaoDescricao = P00EX4_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX4_n999RepresentanteProfissaoDescricao[0];
            A997RepresentanteMunicipioNome = P00EX4_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX4_n997RepresentanteMunicipioNome[0];
            AV40count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00EX4_A981RepresentanteOrgaoExpedidor[0], A981RepresentanteOrgaoExpedidor) == 0 ) )
            {
               BRKEX6 = false;
               A978RepresentanteId = P00EX4_A978RepresentanteId[0];
               AV40count = (long)(AV40count+1);
               BRKEX6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A981RepresentanteOrgaoExpedidor)) ? "<#Empty#>" : A981RepresentanteOrgaoExpedidor);
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
            if ( ! BRKEX6 )
            {
               BRKEX6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADREPRESENTANTERGUFOPTIONS' Routine */
         returnInSub = false;
         AV16TFRepresentanteRGUF = AV30SearchTxt;
         AV17TFRepresentanteRGUF_Sel = "";
         AV72Representantewwds_1_filterfulltext = AV52FilterFullText;
         AV73Representantewwds_2_dynamicfiltersselector1 = AV53DynamicFiltersSelector1;
         AV74Representantewwds_3_dynamicfiltersoperator1 = AV54DynamicFiltersOperator1;
         AV75Representantewwds_4_representantenome1 = AV55RepresentanteNome1;
         AV76Representantewwds_5_representantemunicipionome1 = AV56RepresentanteMunicipioNome1;
         AV77Representantewwds_6_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV78Representantewwds_7_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV79Representantewwds_8_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV80Representantewwds_9_representantenome2 = AV60RepresentanteNome2;
         AV81Representantewwds_10_representantemunicipionome2 = AV61RepresentanteMunicipioNome2;
         AV82Representantewwds_11_dynamicfiltersenabled3 = AV62DynamicFiltersEnabled3;
         AV83Representantewwds_12_dynamicfiltersselector3 = AV63DynamicFiltersSelector3;
         AV84Representantewwds_13_dynamicfiltersoperator3 = AV64DynamicFiltersOperator3;
         AV85Representantewwds_14_representantenome3 = AV65RepresentanteNome3;
         AV86Representantewwds_15_representantemunicipionome3 = AV66RepresentanteMunicipioNome3;
         AV87Representantewwds_16_tfrepresentantenome = AV10TFRepresentanteNome;
         AV88Representantewwds_17_tfrepresentantenome_sel = AV11TFRepresentanteNome_Sel;
         AV89Representantewwds_18_tfrepresentanterg = AV12TFRepresentanteRG;
         AV90Representantewwds_19_tfrepresentanterg_sel = AV13TFRepresentanteRG_Sel;
         AV91Representantewwds_20_tfrepresentanteorgaoexpedidor = AV14TFRepresentanteOrgaoExpedidor;
         AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV15TFRepresentanteOrgaoExpedidor_Sel;
         AV93Representantewwds_22_tfrepresentanterguf = AV16TFRepresentanteRGUF;
         AV94Representantewwds_23_tfrepresentanterguf_sel = AV17TFRepresentanteRGUF_Sel;
         AV95Representantewwds_24_tfrepresentantecpf = AV18TFRepresentanteCPF;
         AV96Representantewwds_25_tfrepresentantecpf_sel = AV19TFRepresentanteCPF_Sel;
         AV97Representantewwds_26_tfrepresentanteestadocivil_sels = AV21TFRepresentanteEstadoCivil_Sels;
         AV98Representantewwds_27_tfrepresentantenacionalidade = AV22TFRepresentanteNacionalidade;
         AV99Representantewwds_28_tfrepresentantenacionalidade_sel = AV23TFRepresentanteNacionalidade_Sel;
         AV100Representantewwds_29_tfrepresentanteprofissaodescricao = AV68TFRepresentanteProfissaoDescricao;
         AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV69TFRepresentanteProfissaoDescricao_Sel;
         AV102Representantewwds_31_tfrepresentanteemail = AV26TFRepresentanteEmail;
         AV103Representantewwds_32_tfrepresentanteemail_sel = AV27TFRepresentanteEmail_Sel;
         AV104Representantewwds_33_tfrepresentantetipo_sels = AV29TFRepresentanteTipo_Sels;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A984RepresentanteEstadoCivil ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                              A998RepresentanteTipo ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                              AV72Representantewwds_1_filterfulltext ,
                                              AV73Representantewwds_2_dynamicfiltersselector1 ,
                                              AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                              AV75Representantewwds_4_representantenome1 ,
                                              AV76Representantewwds_5_representantemunicipionome1 ,
                                              AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                              AV78Representantewwds_7_dynamicfiltersselector2 ,
                                              AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                              AV80Representantewwds_9_representantenome2 ,
                                              AV81Representantewwds_10_representantemunicipionome2 ,
                                              AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                              AV83Representantewwds_12_dynamicfiltersselector3 ,
                                              AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                              AV85Representantewwds_14_representantenome3 ,
                                              AV86Representantewwds_15_representantemunicipionome3 ,
                                              AV88Representantewwds_17_tfrepresentantenome_sel ,
                                              AV87Representantewwds_16_tfrepresentantenome ,
                                              AV90Representantewwds_19_tfrepresentanterg_sel ,
                                              AV89Representantewwds_18_tfrepresentanterg ,
                                              AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                              AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                              AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                              AV93Representantewwds_22_tfrepresentanterguf ,
                                              AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                              AV95Representantewwds_24_tfrepresentantecpf ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels.Count ,
                                              AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                              AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                              AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                              AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                              AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                              AV102Representantewwds_31_tfrepresentanteemail ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels.Count ,
                                              A979RepresentanteNome ,
                                              A980RepresentanteRG ,
                                              A981RepresentanteOrgaoExpedidor ,
                                              A982RepresentanteRGUF ,
                                              A983RepresentanteCPF ,
                                              A985RepresentanteNacionalidade ,
                                              A999RepresentanteProfissaoDescricao ,
                                              A986RepresentanteEmail ,
                                              A997RepresentanteMunicipioNome ,
                                              A168ClienteId ,
                                              AV67ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT
                                              }
         });
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV87Representantewwds_16_tfrepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome), "%", "");
         lV89Representantewwds_18_tfrepresentanterg = StringUtil.Concat( StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg), "%", "");
         lV91Representantewwds_20_tfrepresentanteorgaoexpedidor = StringUtil.Concat( StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor), "%", "");
         lV93Representantewwds_22_tfrepresentanterguf = StringUtil.Concat( StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf), "%", "");
         lV95Representantewwds_24_tfrepresentantecpf = StringUtil.Concat( StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf), "%", "");
         lV98Representantewwds_27_tfrepresentantenacionalidade = StringUtil.Concat( StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade), "%", "");
         lV100Representantewwds_29_tfrepresentanteprofissaodescricao = StringUtil.Concat( StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao), "%", "");
         lV102Representantewwds_31_tfrepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail), "%", "");
         /* Using cursor P00EX5 */
         pr_default.execute(3, new Object[] {AV67ClienteId, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV75Representantewwds_4_representantenome1, lV75Representantewwds_4_representantenome1, lV76Representantewwds_5_representantemunicipionome1, lV76Representantewwds_5_representantemunicipionome1, lV80Representantewwds_9_representantenome2, lV80Representantewwds_9_representantenome2, lV81Representantewwds_10_representantemunicipionome2, lV81Representantewwds_10_representantemunicipionome2, lV85Representantewwds_14_representantenome3, lV85Representantewwds_14_representantenome3, lV86Representantewwds_15_representantemunicipionome3, lV86Representantewwds_15_representantemunicipionome3, lV87Representantewwds_16_tfrepresentantenome, AV88Representantewwds_17_tfrepresentantenome_sel, lV89Representantewwds_18_tfrepresentanterg, AV90Representantewwds_19_tfrepresentanterg_sel, lV91Representantewwds_20_tfrepresentanteorgaoexpedidor, AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, lV93Representantewwds_22_tfrepresentanterguf, AV94Representantewwds_23_tfrepresentanterguf_sel, lV95Representantewwds_24_tfrepresentantecpf, AV96Representantewwds_25_tfrepresentantecpf_sel, lV98Representantewwds_27_tfrepresentantenacionalidade, AV99Representantewwds_28_tfrepresentantenacionalidade_sel, lV100Representantewwds_29_tfrepresentanteprofissaodescricao, AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, lV102Representantewwds_31_tfrepresentanteemail, AV103Representantewwds_32_tfrepresentanteemail_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKEX8 = false;
            A977RepresentanteProfissao = P00EX5_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = P00EX5_n977RepresentanteProfissao[0];
            A991RepresentanteMunicipio = P00EX5_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = P00EX5_n991RepresentanteMunicipio[0];
            A168ClienteId = P00EX5_A168ClienteId[0];
            n168ClienteId = P00EX5_n168ClienteId[0];
            A982RepresentanteRGUF = P00EX5_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = P00EX5_n982RepresentanteRGUF[0];
            A997RepresentanteMunicipioNome = P00EX5_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX5_n997RepresentanteMunicipioNome[0];
            A998RepresentanteTipo = P00EX5_A998RepresentanteTipo[0];
            n998RepresentanteTipo = P00EX5_n998RepresentanteTipo[0];
            A986RepresentanteEmail = P00EX5_A986RepresentanteEmail[0];
            n986RepresentanteEmail = P00EX5_n986RepresentanteEmail[0];
            A999RepresentanteProfissaoDescricao = P00EX5_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX5_n999RepresentanteProfissaoDescricao[0];
            A985RepresentanteNacionalidade = P00EX5_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = P00EX5_n985RepresentanteNacionalidade[0];
            A984RepresentanteEstadoCivil = P00EX5_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = P00EX5_n984RepresentanteEstadoCivil[0];
            A983RepresentanteCPF = P00EX5_A983RepresentanteCPF[0];
            n983RepresentanteCPF = P00EX5_n983RepresentanteCPF[0];
            A981RepresentanteOrgaoExpedidor = P00EX5_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = P00EX5_n981RepresentanteOrgaoExpedidor[0];
            A980RepresentanteRG = P00EX5_A980RepresentanteRG[0];
            n980RepresentanteRG = P00EX5_n980RepresentanteRG[0];
            A979RepresentanteNome = P00EX5_A979RepresentanteNome[0];
            n979RepresentanteNome = P00EX5_n979RepresentanteNome[0];
            A978RepresentanteId = P00EX5_A978RepresentanteId[0];
            A999RepresentanteProfissaoDescricao = P00EX5_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX5_n999RepresentanteProfissaoDescricao[0];
            A997RepresentanteMunicipioNome = P00EX5_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX5_n997RepresentanteMunicipioNome[0];
            AV40count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00EX5_A982RepresentanteRGUF[0], A982RepresentanteRGUF) == 0 ) )
            {
               BRKEX8 = false;
               A978RepresentanteId = P00EX5_A978RepresentanteId[0];
               AV40count = (long)(AV40count+1);
               BRKEX8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A982RepresentanteRGUF)) ? "<#Empty#>" : A982RepresentanteRGUF);
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
            if ( ! BRKEX8 )
            {
               BRKEX8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADREPRESENTANTECPFOPTIONS' Routine */
         returnInSub = false;
         AV18TFRepresentanteCPF = AV30SearchTxt;
         AV19TFRepresentanteCPF_Sel = "";
         AV72Representantewwds_1_filterfulltext = AV52FilterFullText;
         AV73Representantewwds_2_dynamicfiltersselector1 = AV53DynamicFiltersSelector1;
         AV74Representantewwds_3_dynamicfiltersoperator1 = AV54DynamicFiltersOperator1;
         AV75Representantewwds_4_representantenome1 = AV55RepresentanteNome1;
         AV76Representantewwds_5_representantemunicipionome1 = AV56RepresentanteMunicipioNome1;
         AV77Representantewwds_6_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV78Representantewwds_7_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV79Representantewwds_8_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV80Representantewwds_9_representantenome2 = AV60RepresentanteNome2;
         AV81Representantewwds_10_representantemunicipionome2 = AV61RepresentanteMunicipioNome2;
         AV82Representantewwds_11_dynamicfiltersenabled3 = AV62DynamicFiltersEnabled3;
         AV83Representantewwds_12_dynamicfiltersselector3 = AV63DynamicFiltersSelector3;
         AV84Representantewwds_13_dynamicfiltersoperator3 = AV64DynamicFiltersOperator3;
         AV85Representantewwds_14_representantenome3 = AV65RepresentanteNome3;
         AV86Representantewwds_15_representantemunicipionome3 = AV66RepresentanteMunicipioNome3;
         AV87Representantewwds_16_tfrepresentantenome = AV10TFRepresentanteNome;
         AV88Representantewwds_17_tfrepresentantenome_sel = AV11TFRepresentanteNome_Sel;
         AV89Representantewwds_18_tfrepresentanterg = AV12TFRepresentanteRG;
         AV90Representantewwds_19_tfrepresentanterg_sel = AV13TFRepresentanteRG_Sel;
         AV91Representantewwds_20_tfrepresentanteorgaoexpedidor = AV14TFRepresentanteOrgaoExpedidor;
         AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV15TFRepresentanteOrgaoExpedidor_Sel;
         AV93Representantewwds_22_tfrepresentanterguf = AV16TFRepresentanteRGUF;
         AV94Representantewwds_23_tfrepresentanterguf_sel = AV17TFRepresentanteRGUF_Sel;
         AV95Representantewwds_24_tfrepresentantecpf = AV18TFRepresentanteCPF;
         AV96Representantewwds_25_tfrepresentantecpf_sel = AV19TFRepresentanteCPF_Sel;
         AV97Representantewwds_26_tfrepresentanteestadocivil_sels = AV21TFRepresentanteEstadoCivil_Sels;
         AV98Representantewwds_27_tfrepresentantenacionalidade = AV22TFRepresentanteNacionalidade;
         AV99Representantewwds_28_tfrepresentantenacionalidade_sel = AV23TFRepresentanteNacionalidade_Sel;
         AV100Representantewwds_29_tfrepresentanteprofissaodescricao = AV68TFRepresentanteProfissaoDescricao;
         AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV69TFRepresentanteProfissaoDescricao_Sel;
         AV102Representantewwds_31_tfrepresentanteemail = AV26TFRepresentanteEmail;
         AV103Representantewwds_32_tfrepresentanteemail_sel = AV27TFRepresentanteEmail_Sel;
         AV104Representantewwds_33_tfrepresentantetipo_sels = AV29TFRepresentanteTipo_Sels;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A984RepresentanteEstadoCivil ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                              A998RepresentanteTipo ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                              AV72Representantewwds_1_filterfulltext ,
                                              AV73Representantewwds_2_dynamicfiltersselector1 ,
                                              AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                              AV75Representantewwds_4_representantenome1 ,
                                              AV76Representantewwds_5_representantemunicipionome1 ,
                                              AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                              AV78Representantewwds_7_dynamicfiltersselector2 ,
                                              AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                              AV80Representantewwds_9_representantenome2 ,
                                              AV81Representantewwds_10_representantemunicipionome2 ,
                                              AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                              AV83Representantewwds_12_dynamicfiltersselector3 ,
                                              AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                              AV85Representantewwds_14_representantenome3 ,
                                              AV86Representantewwds_15_representantemunicipionome3 ,
                                              AV88Representantewwds_17_tfrepresentantenome_sel ,
                                              AV87Representantewwds_16_tfrepresentantenome ,
                                              AV90Representantewwds_19_tfrepresentanterg_sel ,
                                              AV89Representantewwds_18_tfrepresentanterg ,
                                              AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                              AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                              AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                              AV93Representantewwds_22_tfrepresentanterguf ,
                                              AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                              AV95Representantewwds_24_tfrepresentantecpf ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels.Count ,
                                              AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                              AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                              AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                              AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                              AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                              AV102Representantewwds_31_tfrepresentanteemail ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels.Count ,
                                              A979RepresentanteNome ,
                                              A980RepresentanteRG ,
                                              A981RepresentanteOrgaoExpedidor ,
                                              A982RepresentanteRGUF ,
                                              A983RepresentanteCPF ,
                                              A985RepresentanteNacionalidade ,
                                              A999RepresentanteProfissaoDescricao ,
                                              A986RepresentanteEmail ,
                                              A997RepresentanteMunicipioNome ,
                                              A168ClienteId ,
                                              AV67ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT
                                              }
         });
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV87Representantewwds_16_tfrepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome), "%", "");
         lV89Representantewwds_18_tfrepresentanterg = StringUtil.Concat( StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg), "%", "");
         lV91Representantewwds_20_tfrepresentanteorgaoexpedidor = StringUtil.Concat( StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor), "%", "");
         lV93Representantewwds_22_tfrepresentanterguf = StringUtil.Concat( StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf), "%", "");
         lV95Representantewwds_24_tfrepresentantecpf = StringUtil.Concat( StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf), "%", "");
         lV98Representantewwds_27_tfrepresentantenacionalidade = StringUtil.Concat( StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade), "%", "");
         lV100Representantewwds_29_tfrepresentanteprofissaodescricao = StringUtil.Concat( StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao), "%", "");
         lV102Representantewwds_31_tfrepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail), "%", "");
         /* Using cursor P00EX6 */
         pr_default.execute(4, new Object[] {AV67ClienteId, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV75Representantewwds_4_representantenome1, lV75Representantewwds_4_representantenome1, lV76Representantewwds_5_representantemunicipionome1, lV76Representantewwds_5_representantemunicipionome1, lV80Representantewwds_9_representantenome2, lV80Representantewwds_9_representantenome2, lV81Representantewwds_10_representantemunicipionome2, lV81Representantewwds_10_representantemunicipionome2, lV85Representantewwds_14_representantenome3, lV85Representantewwds_14_representantenome3, lV86Representantewwds_15_representantemunicipionome3, lV86Representantewwds_15_representantemunicipionome3, lV87Representantewwds_16_tfrepresentantenome, AV88Representantewwds_17_tfrepresentantenome_sel, lV89Representantewwds_18_tfrepresentanterg, AV90Representantewwds_19_tfrepresentanterg_sel, lV91Representantewwds_20_tfrepresentanteorgaoexpedidor, AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, lV93Representantewwds_22_tfrepresentanterguf, AV94Representantewwds_23_tfrepresentanterguf_sel, lV95Representantewwds_24_tfrepresentantecpf, AV96Representantewwds_25_tfrepresentantecpf_sel, lV98Representantewwds_27_tfrepresentantenacionalidade, AV99Representantewwds_28_tfrepresentantenacionalidade_sel, lV100Representantewwds_29_tfrepresentanteprofissaodescricao, AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, lV102Representantewwds_31_tfrepresentanteemail, AV103Representantewwds_32_tfrepresentanteemail_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKEX10 = false;
            A977RepresentanteProfissao = P00EX6_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = P00EX6_n977RepresentanteProfissao[0];
            A991RepresentanteMunicipio = P00EX6_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = P00EX6_n991RepresentanteMunicipio[0];
            A168ClienteId = P00EX6_A168ClienteId[0];
            n168ClienteId = P00EX6_n168ClienteId[0];
            A983RepresentanteCPF = P00EX6_A983RepresentanteCPF[0];
            n983RepresentanteCPF = P00EX6_n983RepresentanteCPF[0];
            A997RepresentanteMunicipioNome = P00EX6_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX6_n997RepresentanteMunicipioNome[0];
            A998RepresentanteTipo = P00EX6_A998RepresentanteTipo[0];
            n998RepresentanteTipo = P00EX6_n998RepresentanteTipo[0];
            A986RepresentanteEmail = P00EX6_A986RepresentanteEmail[0];
            n986RepresentanteEmail = P00EX6_n986RepresentanteEmail[0];
            A999RepresentanteProfissaoDescricao = P00EX6_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX6_n999RepresentanteProfissaoDescricao[0];
            A985RepresentanteNacionalidade = P00EX6_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = P00EX6_n985RepresentanteNacionalidade[0];
            A984RepresentanteEstadoCivil = P00EX6_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = P00EX6_n984RepresentanteEstadoCivil[0];
            A982RepresentanteRGUF = P00EX6_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = P00EX6_n982RepresentanteRGUF[0];
            A981RepresentanteOrgaoExpedidor = P00EX6_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = P00EX6_n981RepresentanteOrgaoExpedidor[0];
            A980RepresentanteRG = P00EX6_A980RepresentanteRG[0];
            n980RepresentanteRG = P00EX6_n980RepresentanteRG[0];
            A979RepresentanteNome = P00EX6_A979RepresentanteNome[0];
            n979RepresentanteNome = P00EX6_n979RepresentanteNome[0];
            A978RepresentanteId = P00EX6_A978RepresentanteId[0];
            A999RepresentanteProfissaoDescricao = P00EX6_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX6_n999RepresentanteProfissaoDescricao[0];
            A997RepresentanteMunicipioNome = P00EX6_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX6_n997RepresentanteMunicipioNome[0];
            AV40count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00EX6_A983RepresentanteCPF[0], A983RepresentanteCPF) == 0 ) )
            {
               BRKEX10 = false;
               A978RepresentanteId = P00EX6_A978RepresentanteId[0];
               AV40count = (long)(AV40count+1);
               BRKEX10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A983RepresentanteCPF)) ? "<#Empty#>" : A983RepresentanteCPF);
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
            if ( ! BRKEX10 )
            {
               BRKEX10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADREPRESENTANTENACIONALIDADEOPTIONS' Routine */
         returnInSub = false;
         AV22TFRepresentanteNacionalidade = AV30SearchTxt;
         AV23TFRepresentanteNacionalidade_Sel = "";
         AV72Representantewwds_1_filterfulltext = AV52FilterFullText;
         AV73Representantewwds_2_dynamicfiltersselector1 = AV53DynamicFiltersSelector1;
         AV74Representantewwds_3_dynamicfiltersoperator1 = AV54DynamicFiltersOperator1;
         AV75Representantewwds_4_representantenome1 = AV55RepresentanteNome1;
         AV76Representantewwds_5_representantemunicipionome1 = AV56RepresentanteMunicipioNome1;
         AV77Representantewwds_6_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV78Representantewwds_7_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV79Representantewwds_8_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV80Representantewwds_9_representantenome2 = AV60RepresentanteNome2;
         AV81Representantewwds_10_representantemunicipionome2 = AV61RepresentanteMunicipioNome2;
         AV82Representantewwds_11_dynamicfiltersenabled3 = AV62DynamicFiltersEnabled3;
         AV83Representantewwds_12_dynamicfiltersselector3 = AV63DynamicFiltersSelector3;
         AV84Representantewwds_13_dynamicfiltersoperator3 = AV64DynamicFiltersOperator3;
         AV85Representantewwds_14_representantenome3 = AV65RepresentanteNome3;
         AV86Representantewwds_15_representantemunicipionome3 = AV66RepresentanteMunicipioNome3;
         AV87Representantewwds_16_tfrepresentantenome = AV10TFRepresentanteNome;
         AV88Representantewwds_17_tfrepresentantenome_sel = AV11TFRepresentanteNome_Sel;
         AV89Representantewwds_18_tfrepresentanterg = AV12TFRepresentanteRG;
         AV90Representantewwds_19_tfrepresentanterg_sel = AV13TFRepresentanteRG_Sel;
         AV91Representantewwds_20_tfrepresentanteorgaoexpedidor = AV14TFRepresentanteOrgaoExpedidor;
         AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV15TFRepresentanteOrgaoExpedidor_Sel;
         AV93Representantewwds_22_tfrepresentanterguf = AV16TFRepresentanteRGUF;
         AV94Representantewwds_23_tfrepresentanterguf_sel = AV17TFRepresentanteRGUF_Sel;
         AV95Representantewwds_24_tfrepresentantecpf = AV18TFRepresentanteCPF;
         AV96Representantewwds_25_tfrepresentantecpf_sel = AV19TFRepresentanteCPF_Sel;
         AV97Representantewwds_26_tfrepresentanteestadocivil_sels = AV21TFRepresentanteEstadoCivil_Sels;
         AV98Representantewwds_27_tfrepresentantenacionalidade = AV22TFRepresentanteNacionalidade;
         AV99Representantewwds_28_tfrepresentantenacionalidade_sel = AV23TFRepresentanteNacionalidade_Sel;
         AV100Representantewwds_29_tfrepresentanteprofissaodescricao = AV68TFRepresentanteProfissaoDescricao;
         AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV69TFRepresentanteProfissaoDescricao_Sel;
         AV102Representantewwds_31_tfrepresentanteemail = AV26TFRepresentanteEmail;
         AV103Representantewwds_32_tfrepresentanteemail_sel = AV27TFRepresentanteEmail_Sel;
         AV104Representantewwds_33_tfrepresentantetipo_sels = AV29TFRepresentanteTipo_Sels;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A984RepresentanteEstadoCivil ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                              A998RepresentanteTipo ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                              AV72Representantewwds_1_filterfulltext ,
                                              AV73Representantewwds_2_dynamicfiltersselector1 ,
                                              AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                              AV75Representantewwds_4_representantenome1 ,
                                              AV76Representantewwds_5_representantemunicipionome1 ,
                                              AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                              AV78Representantewwds_7_dynamicfiltersselector2 ,
                                              AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                              AV80Representantewwds_9_representantenome2 ,
                                              AV81Representantewwds_10_representantemunicipionome2 ,
                                              AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                              AV83Representantewwds_12_dynamicfiltersselector3 ,
                                              AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                              AV85Representantewwds_14_representantenome3 ,
                                              AV86Representantewwds_15_representantemunicipionome3 ,
                                              AV88Representantewwds_17_tfrepresentantenome_sel ,
                                              AV87Representantewwds_16_tfrepresentantenome ,
                                              AV90Representantewwds_19_tfrepresentanterg_sel ,
                                              AV89Representantewwds_18_tfrepresentanterg ,
                                              AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                              AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                              AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                              AV93Representantewwds_22_tfrepresentanterguf ,
                                              AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                              AV95Representantewwds_24_tfrepresentantecpf ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels.Count ,
                                              AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                              AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                              AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                              AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                              AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                              AV102Representantewwds_31_tfrepresentanteemail ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels.Count ,
                                              A979RepresentanteNome ,
                                              A980RepresentanteRG ,
                                              A981RepresentanteOrgaoExpedidor ,
                                              A982RepresentanteRGUF ,
                                              A983RepresentanteCPF ,
                                              A985RepresentanteNacionalidade ,
                                              A999RepresentanteProfissaoDescricao ,
                                              A986RepresentanteEmail ,
                                              A997RepresentanteMunicipioNome ,
                                              A168ClienteId ,
                                              AV67ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT
                                              }
         });
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV87Representantewwds_16_tfrepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome), "%", "");
         lV89Representantewwds_18_tfrepresentanterg = StringUtil.Concat( StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg), "%", "");
         lV91Representantewwds_20_tfrepresentanteorgaoexpedidor = StringUtil.Concat( StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor), "%", "");
         lV93Representantewwds_22_tfrepresentanterguf = StringUtil.Concat( StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf), "%", "");
         lV95Representantewwds_24_tfrepresentantecpf = StringUtil.Concat( StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf), "%", "");
         lV98Representantewwds_27_tfrepresentantenacionalidade = StringUtil.Concat( StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade), "%", "");
         lV100Representantewwds_29_tfrepresentanteprofissaodescricao = StringUtil.Concat( StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao), "%", "");
         lV102Representantewwds_31_tfrepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail), "%", "");
         /* Using cursor P00EX7 */
         pr_default.execute(5, new Object[] {AV67ClienteId, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV75Representantewwds_4_representantenome1, lV75Representantewwds_4_representantenome1, lV76Representantewwds_5_representantemunicipionome1, lV76Representantewwds_5_representantemunicipionome1, lV80Representantewwds_9_representantenome2, lV80Representantewwds_9_representantenome2, lV81Representantewwds_10_representantemunicipionome2, lV81Representantewwds_10_representantemunicipionome2, lV85Representantewwds_14_representantenome3, lV85Representantewwds_14_representantenome3, lV86Representantewwds_15_representantemunicipionome3, lV86Representantewwds_15_representantemunicipionome3, lV87Representantewwds_16_tfrepresentantenome, AV88Representantewwds_17_tfrepresentantenome_sel, lV89Representantewwds_18_tfrepresentanterg, AV90Representantewwds_19_tfrepresentanterg_sel, lV91Representantewwds_20_tfrepresentanteorgaoexpedidor, AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, lV93Representantewwds_22_tfrepresentanterguf, AV94Representantewwds_23_tfrepresentanterguf_sel, lV95Representantewwds_24_tfrepresentantecpf, AV96Representantewwds_25_tfrepresentantecpf_sel, lV98Representantewwds_27_tfrepresentantenacionalidade, AV99Representantewwds_28_tfrepresentantenacionalidade_sel, lV100Representantewwds_29_tfrepresentanteprofissaodescricao, AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, lV102Representantewwds_31_tfrepresentanteemail, AV103Representantewwds_32_tfrepresentanteemail_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKEX12 = false;
            A977RepresentanteProfissao = P00EX7_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = P00EX7_n977RepresentanteProfissao[0];
            A991RepresentanteMunicipio = P00EX7_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = P00EX7_n991RepresentanteMunicipio[0];
            A168ClienteId = P00EX7_A168ClienteId[0];
            n168ClienteId = P00EX7_n168ClienteId[0];
            A985RepresentanteNacionalidade = P00EX7_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = P00EX7_n985RepresentanteNacionalidade[0];
            A997RepresentanteMunicipioNome = P00EX7_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX7_n997RepresentanteMunicipioNome[0];
            A998RepresentanteTipo = P00EX7_A998RepresentanteTipo[0];
            n998RepresentanteTipo = P00EX7_n998RepresentanteTipo[0];
            A986RepresentanteEmail = P00EX7_A986RepresentanteEmail[0];
            n986RepresentanteEmail = P00EX7_n986RepresentanteEmail[0];
            A999RepresentanteProfissaoDescricao = P00EX7_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX7_n999RepresentanteProfissaoDescricao[0];
            A984RepresentanteEstadoCivil = P00EX7_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = P00EX7_n984RepresentanteEstadoCivil[0];
            A983RepresentanteCPF = P00EX7_A983RepresentanteCPF[0];
            n983RepresentanteCPF = P00EX7_n983RepresentanteCPF[0];
            A982RepresentanteRGUF = P00EX7_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = P00EX7_n982RepresentanteRGUF[0];
            A981RepresentanteOrgaoExpedidor = P00EX7_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = P00EX7_n981RepresentanteOrgaoExpedidor[0];
            A980RepresentanteRG = P00EX7_A980RepresentanteRG[0];
            n980RepresentanteRG = P00EX7_n980RepresentanteRG[0];
            A979RepresentanteNome = P00EX7_A979RepresentanteNome[0];
            n979RepresentanteNome = P00EX7_n979RepresentanteNome[0];
            A978RepresentanteId = P00EX7_A978RepresentanteId[0];
            A999RepresentanteProfissaoDescricao = P00EX7_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX7_n999RepresentanteProfissaoDescricao[0];
            A997RepresentanteMunicipioNome = P00EX7_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX7_n997RepresentanteMunicipioNome[0];
            AV40count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P00EX7_A985RepresentanteNacionalidade[0], A985RepresentanteNacionalidade) == 0 ) )
            {
               BRKEX12 = false;
               A978RepresentanteId = P00EX7_A978RepresentanteId[0];
               AV40count = (long)(AV40count+1);
               BRKEX12 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A985RepresentanteNacionalidade)) ? "<#Empty#>" : A985RepresentanteNacionalidade);
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
            if ( ! BRKEX12 )
            {
               BRKEX12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADREPRESENTANTEPROFISSAODESCRICAOOPTIONS' Routine */
         returnInSub = false;
         AV68TFRepresentanteProfissaoDescricao = AV30SearchTxt;
         AV69TFRepresentanteProfissaoDescricao_Sel = "";
         AV72Representantewwds_1_filterfulltext = AV52FilterFullText;
         AV73Representantewwds_2_dynamicfiltersselector1 = AV53DynamicFiltersSelector1;
         AV74Representantewwds_3_dynamicfiltersoperator1 = AV54DynamicFiltersOperator1;
         AV75Representantewwds_4_representantenome1 = AV55RepresentanteNome1;
         AV76Representantewwds_5_representantemunicipionome1 = AV56RepresentanteMunicipioNome1;
         AV77Representantewwds_6_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV78Representantewwds_7_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV79Representantewwds_8_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV80Representantewwds_9_representantenome2 = AV60RepresentanteNome2;
         AV81Representantewwds_10_representantemunicipionome2 = AV61RepresentanteMunicipioNome2;
         AV82Representantewwds_11_dynamicfiltersenabled3 = AV62DynamicFiltersEnabled3;
         AV83Representantewwds_12_dynamicfiltersselector3 = AV63DynamicFiltersSelector3;
         AV84Representantewwds_13_dynamicfiltersoperator3 = AV64DynamicFiltersOperator3;
         AV85Representantewwds_14_representantenome3 = AV65RepresentanteNome3;
         AV86Representantewwds_15_representantemunicipionome3 = AV66RepresentanteMunicipioNome3;
         AV87Representantewwds_16_tfrepresentantenome = AV10TFRepresentanteNome;
         AV88Representantewwds_17_tfrepresentantenome_sel = AV11TFRepresentanteNome_Sel;
         AV89Representantewwds_18_tfrepresentanterg = AV12TFRepresentanteRG;
         AV90Representantewwds_19_tfrepresentanterg_sel = AV13TFRepresentanteRG_Sel;
         AV91Representantewwds_20_tfrepresentanteorgaoexpedidor = AV14TFRepresentanteOrgaoExpedidor;
         AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV15TFRepresentanteOrgaoExpedidor_Sel;
         AV93Representantewwds_22_tfrepresentanterguf = AV16TFRepresentanteRGUF;
         AV94Representantewwds_23_tfrepresentanterguf_sel = AV17TFRepresentanteRGUF_Sel;
         AV95Representantewwds_24_tfrepresentantecpf = AV18TFRepresentanteCPF;
         AV96Representantewwds_25_tfrepresentantecpf_sel = AV19TFRepresentanteCPF_Sel;
         AV97Representantewwds_26_tfrepresentanteestadocivil_sels = AV21TFRepresentanteEstadoCivil_Sels;
         AV98Representantewwds_27_tfrepresentantenacionalidade = AV22TFRepresentanteNacionalidade;
         AV99Representantewwds_28_tfrepresentantenacionalidade_sel = AV23TFRepresentanteNacionalidade_Sel;
         AV100Representantewwds_29_tfrepresentanteprofissaodescricao = AV68TFRepresentanteProfissaoDescricao;
         AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV69TFRepresentanteProfissaoDescricao_Sel;
         AV102Representantewwds_31_tfrepresentanteemail = AV26TFRepresentanteEmail;
         AV103Representantewwds_32_tfrepresentanteemail_sel = AV27TFRepresentanteEmail_Sel;
         AV104Representantewwds_33_tfrepresentantetipo_sels = AV29TFRepresentanteTipo_Sels;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              A984RepresentanteEstadoCivil ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                              A998RepresentanteTipo ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                              AV72Representantewwds_1_filterfulltext ,
                                              AV73Representantewwds_2_dynamicfiltersselector1 ,
                                              AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                              AV75Representantewwds_4_representantenome1 ,
                                              AV76Representantewwds_5_representantemunicipionome1 ,
                                              AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                              AV78Representantewwds_7_dynamicfiltersselector2 ,
                                              AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                              AV80Representantewwds_9_representantenome2 ,
                                              AV81Representantewwds_10_representantemunicipionome2 ,
                                              AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                              AV83Representantewwds_12_dynamicfiltersselector3 ,
                                              AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                              AV85Representantewwds_14_representantenome3 ,
                                              AV86Representantewwds_15_representantemunicipionome3 ,
                                              AV88Representantewwds_17_tfrepresentantenome_sel ,
                                              AV87Representantewwds_16_tfrepresentantenome ,
                                              AV90Representantewwds_19_tfrepresentanterg_sel ,
                                              AV89Representantewwds_18_tfrepresentanterg ,
                                              AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                              AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                              AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                              AV93Representantewwds_22_tfrepresentanterguf ,
                                              AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                              AV95Representantewwds_24_tfrepresentantecpf ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels.Count ,
                                              AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                              AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                              AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                              AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                              AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                              AV102Representantewwds_31_tfrepresentanteemail ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels.Count ,
                                              A979RepresentanteNome ,
                                              A980RepresentanteRG ,
                                              A981RepresentanteOrgaoExpedidor ,
                                              A982RepresentanteRGUF ,
                                              A983RepresentanteCPF ,
                                              A985RepresentanteNacionalidade ,
                                              A999RepresentanteProfissaoDescricao ,
                                              A986RepresentanteEmail ,
                                              A997RepresentanteMunicipioNome ,
                                              A168ClienteId ,
                                              AV67ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT
                                              }
         });
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV87Representantewwds_16_tfrepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome), "%", "");
         lV89Representantewwds_18_tfrepresentanterg = StringUtil.Concat( StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg), "%", "");
         lV91Representantewwds_20_tfrepresentanteorgaoexpedidor = StringUtil.Concat( StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor), "%", "");
         lV93Representantewwds_22_tfrepresentanterguf = StringUtil.Concat( StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf), "%", "");
         lV95Representantewwds_24_tfrepresentantecpf = StringUtil.Concat( StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf), "%", "");
         lV98Representantewwds_27_tfrepresentantenacionalidade = StringUtil.Concat( StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade), "%", "");
         lV100Representantewwds_29_tfrepresentanteprofissaodescricao = StringUtil.Concat( StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao), "%", "");
         lV102Representantewwds_31_tfrepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail), "%", "");
         /* Using cursor P00EX8 */
         pr_default.execute(6, new Object[] {AV67ClienteId, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV75Representantewwds_4_representantenome1, lV75Representantewwds_4_representantenome1, lV76Representantewwds_5_representantemunicipionome1, lV76Representantewwds_5_representantemunicipionome1, lV80Representantewwds_9_representantenome2, lV80Representantewwds_9_representantenome2, lV81Representantewwds_10_representantemunicipionome2, lV81Representantewwds_10_representantemunicipionome2, lV85Representantewwds_14_representantenome3, lV85Representantewwds_14_representantenome3, lV86Representantewwds_15_representantemunicipionome3, lV86Representantewwds_15_representantemunicipionome3, lV87Representantewwds_16_tfrepresentantenome, AV88Representantewwds_17_tfrepresentantenome_sel, lV89Representantewwds_18_tfrepresentanterg, AV90Representantewwds_19_tfrepresentanterg_sel, lV91Representantewwds_20_tfrepresentanteorgaoexpedidor, AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, lV93Representantewwds_22_tfrepresentanterguf, AV94Representantewwds_23_tfrepresentanterguf_sel, lV95Representantewwds_24_tfrepresentantecpf, AV96Representantewwds_25_tfrepresentantecpf_sel, lV98Representantewwds_27_tfrepresentantenacionalidade, AV99Representantewwds_28_tfrepresentantenacionalidade_sel, lV100Representantewwds_29_tfrepresentanteprofissaodescricao, AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, lV102Representantewwds_31_tfrepresentanteemail, AV103Representantewwds_32_tfrepresentanteemail_sel});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRKEX14 = false;
            A991RepresentanteMunicipio = P00EX8_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = P00EX8_n991RepresentanteMunicipio[0];
            A977RepresentanteProfissao = P00EX8_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = P00EX8_n977RepresentanteProfissao[0];
            A168ClienteId = P00EX8_A168ClienteId[0];
            n168ClienteId = P00EX8_n168ClienteId[0];
            A997RepresentanteMunicipioNome = P00EX8_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX8_n997RepresentanteMunicipioNome[0];
            A998RepresentanteTipo = P00EX8_A998RepresentanteTipo[0];
            n998RepresentanteTipo = P00EX8_n998RepresentanteTipo[0];
            A986RepresentanteEmail = P00EX8_A986RepresentanteEmail[0];
            n986RepresentanteEmail = P00EX8_n986RepresentanteEmail[0];
            A999RepresentanteProfissaoDescricao = P00EX8_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX8_n999RepresentanteProfissaoDescricao[0];
            A985RepresentanteNacionalidade = P00EX8_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = P00EX8_n985RepresentanteNacionalidade[0];
            A984RepresentanteEstadoCivil = P00EX8_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = P00EX8_n984RepresentanteEstadoCivil[0];
            A983RepresentanteCPF = P00EX8_A983RepresentanteCPF[0];
            n983RepresentanteCPF = P00EX8_n983RepresentanteCPF[0];
            A982RepresentanteRGUF = P00EX8_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = P00EX8_n982RepresentanteRGUF[0];
            A981RepresentanteOrgaoExpedidor = P00EX8_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = P00EX8_n981RepresentanteOrgaoExpedidor[0];
            A980RepresentanteRG = P00EX8_A980RepresentanteRG[0];
            n980RepresentanteRG = P00EX8_n980RepresentanteRG[0];
            A979RepresentanteNome = P00EX8_A979RepresentanteNome[0];
            n979RepresentanteNome = P00EX8_n979RepresentanteNome[0];
            A978RepresentanteId = P00EX8_A978RepresentanteId[0];
            A997RepresentanteMunicipioNome = P00EX8_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX8_n997RepresentanteMunicipioNome[0];
            A999RepresentanteProfissaoDescricao = P00EX8_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX8_n999RepresentanteProfissaoDescricao[0];
            AV40count = 0;
            while ( (pr_default.getStatus(6) != 101) && ( P00EX8_A977RepresentanteProfissao[0] == A977RepresentanteProfissao ) )
            {
               BRKEX14 = false;
               A978RepresentanteId = P00EX8_A978RepresentanteId[0];
               AV40count = (long)(AV40count+1);
               BRKEX14 = true;
               pr_default.readNext(6);
            }
            AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A999RepresentanteProfissaoDescricao)) ? "<#Empty#>" : A999RepresentanteProfissaoDescricao);
            AV34InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV35Option, "<#Empty#>") != 0 ) && ( AV34InsertIndex <= AV36Options.Count ) && ( ( StringUtil.StrCmp(((string)AV36Options.Item(AV34InsertIndex)), AV35Option) < 0 ) || ( StringUtil.StrCmp(((string)AV36Options.Item(AV34InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV34InsertIndex = (int)(AV34InsertIndex+1);
            }
            AV36Options.Add(AV35Option, AV34InsertIndex);
            AV39OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), AV34InsertIndex);
            if ( AV36Options.Count == AV31SkipItems + 11 )
            {
               AV36Options.RemoveItem(AV36Options.Count);
               AV39OptionIndexes.RemoveItem(AV39OptionIndexes.Count);
            }
            if ( ! BRKEX14 )
            {
               BRKEX14 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
         while ( AV31SkipItems > 0 )
         {
            AV36Options.RemoveItem(1);
            AV39OptionIndexes.RemoveItem(1);
            AV31SkipItems = (short)(AV31SkipItems-1);
         }
      }

      protected void S191( )
      {
         /* 'LOADREPRESENTANTEEMAILOPTIONS' Routine */
         returnInSub = false;
         AV26TFRepresentanteEmail = AV30SearchTxt;
         AV27TFRepresentanteEmail_Sel = "";
         AV72Representantewwds_1_filterfulltext = AV52FilterFullText;
         AV73Representantewwds_2_dynamicfiltersselector1 = AV53DynamicFiltersSelector1;
         AV74Representantewwds_3_dynamicfiltersoperator1 = AV54DynamicFiltersOperator1;
         AV75Representantewwds_4_representantenome1 = AV55RepresentanteNome1;
         AV76Representantewwds_5_representantemunicipionome1 = AV56RepresentanteMunicipioNome1;
         AV77Representantewwds_6_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV78Representantewwds_7_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV79Representantewwds_8_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV80Representantewwds_9_representantenome2 = AV60RepresentanteNome2;
         AV81Representantewwds_10_representantemunicipionome2 = AV61RepresentanteMunicipioNome2;
         AV82Representantewwds_11_dynamicfiltersenabled3 = AV62DynamicFiltersEnabled3;
         AV83Representantewwds_12_dynamicfiltersselector3 = AV63DynamicFiltersSelector3;
         AV84Representantewwds_13_dynamicfiltersoperator3 = AV64DynamicFiltersOperator3;
         AV85Representantewwds_14_representantenome3 = AV65RepresentanteNome3;
         AV86Representantewwds_15_representantemunicipionome3 = AV66RepresentanteMunicipioNome3;
         AV87Representantewwds_16_tfrepresentantenome = AV10TFRepresentanteNome;
         AV88Representantewwds_17_tfrepresentantenome_sel = AV11TFRepresentanteNome_Sel;
         AV89Representantewwds_18_tfrepresentanterg = AV12TFRepresentanteRG;
         AV90Representantewwds_19_tfrepresentanterg_sel = AV13TFRepresentanteRG_Sel;
         AV91Representantewwds_20_tfrepresentanteorgaoexpedidor = AV14TFRepresentanteOrgaoExpedidor;
         AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = AV15TFRepresentanteOrgaoExpedidor_Sel;
         AV93Representantewwds_22_tfrepresentanterguf = AV16TFRepresentanteRGUF;
         AV94Representantewwds_23_tfrepresentanterguf_sel = AV17TFRepresentanteRGUF_Sel;
         AV95Representantewwds_24_tfrepresentantecpf = AV18TFRepresentanteCPF;
         AV96Representantewwds_25_tfrepresentantecpf_sel = AV19TFRepresentanteCPF_Sel;
         AV97Representantewwds_26_tfrepresentanteestadocivil_sels = AV21TFRepresentanteEstadoCivil_Sels;
         AV98Representantewwds_27_tfrepresentantenacionalidade = AV22TFRepresentanteNacionalidade;
         AV99Representantewwds_28_tfrepresentantenacionalidade_sel = AV23TFRepresentanteNacionalidade_Sel;
         AV100Representantewwds_29_tfrepresentanteprofissaodescricao = AV68TFRepresentanteProfissaoDescricao;
         AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel = AV69TFRepresentanteProfissaoDescricao_Sel;
         AV102Representantewwds_31_tfrepresentanteemail = AV26TFRepresentanteEmail;
         AV103Representantewwds_32_tfrepresentanteemail_sel = AV27TFRepresentanteEmail_Sel;
         AV104Representantewwds_33_tfrepresentantetipo_sels = AV29TFRepresentanteTipo_Sels;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              A984RepresentanteEstadoCivil ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                              A998RepresentanteTipo ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                              AV72Representantewwds_1_filterfulltext ,
                                              AV73Representantewwds_2_dynamicfiltersselector1 ,
                                              AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                              AV75Representantewwds_4_representantenome1 ,
                                              AV76Representantewwds_5_representantemunicipionome1 ,
                                              AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                              AV78Representantewwds_7_dynamicfiltersselector2 ,
                                              AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                              AV80Representantewwds_9_representantenome2 ,
                                              AV81Representantewwds_10_representantemunicipionome2 ,
                                              AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                              AV83Representantewwds_12_dynamicfiltersselector3 ,
                                              AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                              AV85Representantewwds_14_representantenome3 ,
                                              AV86Representantewwds_15_representantemunicipionome3 ,
                                              AV88Representantewwds_17_tfrepresentantenome_sel ,
                                              AV87Representantewwds_16_tfrepresentantenome ,
                                              AV90Representantewwds_19_tfrepresentanterg_sel ,
                                              AV89Representantewwds_18_tfrepresentanterg ,
                                              AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                              AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                              AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                              AV93Representantewwds_22_tfrepresentanterguf ,
                                              AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                              AV95Representantewwds_24_tfrepresentantecpf ,
                                              AV97Representantewwds_26_tfrepresentanteestadocivil_sels.Count ,
                                              AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                              AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                              AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                              AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                              AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                              AV102Representantewwds_31_tfrepresentanteemail ,
                                              AV104Representantewwds_33_tfrepresentantetipo_sels.Count ,
                                              A979RepresentanteNome ,
                                              A980RepresentanteRG ,
                                              A981RepresentanteOrgaoExpedidor ,
                                              A982RepresentanteRGUF ,
                                              A983RepresentanteCPF ,
                                              A985RepresentanteNacionalidade ,
                                              A999RepresentanteProfissaoDescricao ,
                                              A986RepresentanteEmail ,
                                              A997RepresentanteMunicipioNome ,
                                              A168ClienteId ,
                                              AV67ClienteId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT
                                              }
         });
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV72Representantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Representantewwds_1_filterfulltext), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV75Representantewwds_4_representantenome1 = StringUtil.Concat( StringUtil.RTrim( AV75Representantewwds_4_representantenome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV76Representantewwds_5_representantemunicipionome1 = StringUtil.Concat( StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV80Representantewwds_9_representantenome2 = StringUtil.Concat( StringUtil.RTrim( AV80Representantewwds_9_representantenome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV81Representantewwds_10_representantemunicipionome2 = StringUtil.Concat( StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV85Representantewwds_14_representantenome3 = StringUtil.Concat( StringUtil.RTrim( AV85Representantewwds_14_representantenome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV86Representantewwds_15_representantemunicipionome3 = StringUtil.Concat( StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3), "%", "");
         lV87Representantewwds_16_tfrepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome), "%", "");
         lV89Representantewwds_18_tfrepresentanterg = StringUtil.Concat( StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg), "%", "");
         lV91Representantewwds_20_tfrepresentanteorgaoexpedidor = StringUtil.Concat( StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor), "%", "");
         lV93Representantewwds_22_tfrepresentanterguf = StringUtil.Concat( StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf), "%", "");
         lV95Representantewwds_24_tfrepresentantecpf = StringUtil.Concat( StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf), "%", "");
         lV98Representantewwds_27_tfrepresentantenacionalidade = StringUtil.Concat( StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade), "%", "");
         lV100Representantewwds_29_tfrepresentanteprofissaodescricao = StringUtil.Concat( StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao), "%", "");
         lV102Representantewwds_31_tfrepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail), "%", "");
         /* Using cursor P00EX9 */
         pr_default.execute(7, new Object[] {AV67ClienteId, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV72Representantewwds_1_filterfulltext, lV75Representantewwds_4_representantenome1, lV75Representantewwds_4_representantenome1, lV76Representantewwds_5_representantemunicipionome1, lV76Representantewwds_5_representantemunicipionome1, lV80Representantewwds_9_representantenome2, lV80Representantewwds_9_representantenome2, lV81Representantewwds_10_representantemunicipionome2, lV81Representantewwds_10_representantemunicipionome2, lV85Representantewwds_14_representantenome3, lV85Representantewwds_14_representantenome3, lV86Representantewwds_15_representantemunicipionome3, lV86Representantewwds_15_representantemunicipionome3, lV87Representantewwds_16_tfrepresentantenome, AV88Representantewwds_17_tfrepresentantenome_sel, lV89Representantewwds_18_tfrepresentanterg, AV90Representantewwds_19_tfrepresentanterg_sel, lV91Representantewwds_20_tfrepresentanteorgaoexpedidor, AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, lV93Representantewwds_22_tfrepresentanterguf, AV94Representantewwds_23_tfrepresentanterguf_sel, lV95Representantewwds_24_tfrepresentantecpf, AV96Representantewwds_25_tfrepresentantecpf_sel, lV98Representantewwds_27_tfrepresentantenacionalidade, AV99Representantewwds_28_tfrepresentantenacionalidade_sel, lV100Representantewwds_29_tfrepresentanteprofissaodescricao, AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, lV102Representantewwds_31_tfrepresentanteemail, AV103Representantewwds_32_tfrepresentanteemail_sel});
         while ( (pr_default.getStatus(7) != 101) )
         {
            BRKEX16 = false;
            A977RepresentanteProfissao = P00EX9_A977RepresentanteProfissao[0];
            n977RepresentanteProfissao = P00EX9_n977RepresentanteProfissao[0];
            A991RepresentanteMunicipio = P00EX9_A991RepresentanteMunicipio[0];
            n991RepresentanteMunicipio = P00EX9_n991RepresentanteMunicipio[0];
            A168ClienteId = P00EX9_A168ClienteId[0];
            n168ClienteId = P00EX9_n168ClienteId[0];
            A986RepresentanteEmail = P00EX9_A986RepresentanteEmail[0];
            n986RepresentanteEmail = P00EX9_n986RepresentanteEmail[0];
            A997RepresentanteMunicipioNome = P00EX9_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX9_n997RepresentanteMunicipioNome[0];
            A998RepresentanteTipo = P00EX9_A998RepresentanteTipo[0];
            n998RepresentanteTipo = P00EX9_n998RepresentanteTipo[0];
            A999RepresentanteProfissaoDescricao = P00EX9_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX9_n999RepresentanteProfissaoDescricao[0];
            A985RepresentanteNacionalidade = P00EX9_A985RepresentanteNacionalidade[0];
            n985RepresentanteNacionalidade = P00EX9_n985RepresentanteNacionalidade[0];
            A984RepresentanteEstadoCivil = P00EX9_A984RepresentanteEstadoCivil[0];
            n984RepresentanteEstadoCivil = P00EX9_n984RepresentanteEstadoCivil[0];
            A983RepresentanteCPF = P00EX9_A983RepresentanteCPF[0];
            n983RepresentanteCPF = P00EX9_n983RepresentanteCPF[0];
            A982RepresentanteRGUF = P00EX9_A982RepresentanteRGUF[0];
            n982RepresentanteRGUF = P00EX9_n982RepresentanteRGUF[0];
            A981RepresentanteOrgaoExpedidor = P00EX9_A981RepresentanteOrgaoExpedidor[0];
            n981RepresentanteOrgaoExpedidor = P00EX9_n981RepresentanteOrgaoExpedidor[0];
            A980RepresentanteRG = P00EX9_A980RepresentanteRG[0];
            n980RepresentanteRG = P00EX9_n980RepresentanteRG[0];
            A979RepresentanteNome = P00EX9_A979RepresentanteNome[0];
            n979RepresentanteNome = P00EX9_n979RepresentanteNome[0];
            A978RepresentanteId = P00EX9_A978RepresentanteId[0];
            A999RepresentanteProfissaoDescricao = P00EX9_A999RepresentanteProfissaoDescricao[0];
            n999RepresentanteProfissaoDescricao = P00EX9_n999RepresentanteProfissaoDescricao[0];
            A997RepresentanteMunicipioNome = P00EX9_A997RepresentanteMunicipioNome[0];
            n997RepresentanteMunicipioNome = P00EX9_n997RepresentanteMunicipioNome[0];
            AV40count = 0;
            while ( (pr_default.getStatus(7) != 101) && ( StringUtil.StrCmp(P00EX9_A986RepresentanteEmail[0], A986RepresentanteEmail) == 0 ) )
            {
               BRKEX16 = false;
               A978RepresentanteId = P00EX9_A978RepresentanteId[0];
               AV40count = (long)(AV40count+1);
               BRKEX16 = true;
               pr_default.readNext(7);
            }
            if ( (0==AV31SkipItems) )
            {
               AV35Option = (String.IsNullOrEmpty(StringUtil.RTrim( A986RepresentanteEmail)) ? "<#Empty#>" : A986RepresentanteEmail);
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
            if ( ! BRKEX16 )
            {
               BRKEX16 = true;
               pr_default.readNext(7);
            }
         }
         pr_default.close(7);
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
         AV52FilterFullText = "";
         AV10TFRepresentanteNome = "";
         AV11TFRepresentanteNome_Sel = "";
         AV12TFRepresentanteRG = "";
         AV13TFRepresentanteRG_Sel = "";
         AV14TFRepresentanteOrgaoExpedidor = "";
         AV15TFRepresentanteOrgaoExpedidor_Sel = "";
         AV16TFRepresentanteRGUF = "";
         AV17TFRepresentanteRGUF_Sel = "";
         AV18TFRepresentanteCPF = "";
         AV19TFRepresentanteCPF_Sel = "";
         AV20TFRepresentanteEstadoCivil_SelsJson = "";
         AV21TFRepresentanteEstadoCivil_Sels = new GxSimpleCollection<string>();
         AV22TFRepresentanteNacionalidade = "";
         AV23TFRepresentanteNacionalidade_Sel = "";
         AV68TFRepresentanteProfissaoDescricao = "";
         AV69TFRepresentanteProfissaoDescricao_Sel = "";
         AV26TFRepresentanteEmail = "";
         AV27TFRepresentanteEmail_Sel = "";
         AV28TFRepresentanteTipo_SelsJson = "";
         AV29TFRepresentanteTipo_Sels = new GxSimpleCollection<string>();
         AV45GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV53DynamicFiltersSelector1 = "";
         AV55RepresentanteNome1 = "";
         AV56RepresentanteMunicipioNome1 = "";
         AV58DynamicFiltersSelector2 = "";
         AV60RepresentanteNome2 = "";
         AV61RepresentanteMunicipioNome2 = "";
         AV63DynamicFiltersSelector3 = "";
         AV65RepresentanteNome3 = "";
         AV66RepresentanteMunicipioNome3 = "";
         AV72Representantewwds_1_filterfulltext = "";
         AV73Representantewwds_2_dynamicfiltersselector1 = "";
         AV75Representantewwds_4_representantenome1 = "";
         AV76Representantewwds_5_representantemunicipionome1 = "";
         AV78Representantewwds_7_dynamicfiltersselector2 = "";
         AV80Representantewwds_9_representantenome2 = "";
         AV81Representantewwds_10_representantemunicipionome2 = "";
         AV83Representantewwds_12_dynamicfiltersselector3 = "";
         AV85Representantewwds_14_representantenome3 = "";
         AV86Representantewwds_15_representantemunicipionome3 = "";
         AV87Representantewwds_16_tfrepresentantenome = "";
         AV88Representantewwds_17_tfrepresentantenome_sel = "";
         AV89Representantewwds_18_tfrepresentanterg = "";
         AV90Representantewwds_19_tfrepresentanterg_sel = "";
         AV91Representantewwds_20_tfrepresentanteorgaoexpedidor = "";
         AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel = "";
         AV93Representantewwds_22_tfrepresentanterguf = "";
         AV94Representantewwds_23_tfrepresentanterguf_sel = "";
         AV95Representantewwds_24_tfrepresentantecpf = "";
         AV96Representantewwds_25_tfrepresentantecpf_sel = "";
         AV97Representantewwds_26_tfrepresentanteestadocivil_sels = new GxSimpleCollection<string>();
         AV98Representantewwds_27_tfrepresentantenacionalidade = "";
         AV99Representantewwds_28_tfrepresentantenacionalidade_sel = "";
         AV100Representantewwds_29_tfrepresentanteprofissaodescricao = "";
         AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel = "";
         AV102Representantewwds_31_tfrepresentanteemail = "";
         AV103Representantewwds_32_tfrepresentanteemail_sel = "";
         AV104Representantewwds_33_tfrepresentantetipo_sels = new GxSimpleCollection<string>();
         lV72Representantewwds_1_filterfulltext = "";
         lV75Representantewwds_4_representantenome1 = "";
         lV76Representantewwds_5_representantemunicipionome1 = "";
         lV80Representantewwds_9_representantenome2 = "";
         lV81Representantewwds_10_representantemunicipionome2 = "";
         lV85Representantewwds_14_representantenome3 = "";
         lV86Representantewwds_15_representantemunicipionome3 = "";
         lV87Representantewwds_16_tfrepresentantenome = "";
         lV89Representantewwds_18_tfrepresentanterg = "";
         lV91Representantewwds_20_tfrepresentanteorgaoexpedidor = "";
         lV93Representantewwds_22_tfrepresentanterguf = "";
         lV95Representantewwds_24_tfrepresentantecpf = "";
         lV98Representantewwds_27_tfrepresentantenacionalidade = "";
         lV100Representantewwds_29_tfrepresentanteprofissaodescricao = "";
         lV102Representantewwds_31_tfrepresentanteemail = "";
         A984RepresentanteEstadoCivil = "";
         A998RepresentanteTipo = "";
         A979RepresentanteNome = "";
         A980RepresentanteRG = "";
         A981RepresentanteOrgaoExpedidor = "";
         A982RepresentanteRGUF = "";
         A983RepresentanteCPF = "";
         A985RepresentanteNacionalidade = "";
         A999RepresentanteProfissaoDescricao = "";
         A986RepresentanteEmail = "";
         A997RepresentanteMunicipioNome = "";
         P00EX2_A977RepresentanteProfissao = new int[1] ;
         P00EX2_n977RepresentanteProfissao = new bool[] {false} ;
         P00EX2_A991RepresentanteMunicipio = new string[] {""} ;
         P00EX2_n991RepresentanteMunicipio = new bool[] {false} ;
         P00EX2_A168ClienteId = new int[1] ;
         P00EX2_n168ClienteId = new bool[] {false} ;
         P00EX2_A979RepresentanteNome = new string[] {""} ;
         P00EX2_n979RepresentanteNome = new bool[] {false} ;
         P00EX2_A997RepresentanteMunicipioNome = new string[] {""} ;
         P00EX2_n997RepresentanteMunicipioNome = new bool[] {false} ;
         P00EX2_A998RepresentanteTipo = new string[] {""} ;
         P00EX2_n998RepresentanteTipo = new bool[] {false} ;
         P00EX2_A986RepresentanteEmail = new string[] {""} ;
         P00EX2_n986RepresentanteEmail = new bool[] {false} ;
         P00EX2_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         P00EX2_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         P00EX2_A985RepresentanteNacionalidade = new string[] {""} ;
         P00EX2_n985RepresentanteNacionalidade = new bool[] {false} ;
         P00EX2_A984RepresentanteEstadoCivil = new string[] {""} ;
         P00EX2_n984RepresentanteEstadoCivil = new bool[] {false} ;
         P00EX2_A983RepresentanteCPF = new string[] {""} ;
         P00EX2_n983RepresentanteCPF = new bool[] {false} ;
         P00EX2_A982RepresentanteRGUF = new string[] {""} ;
         P00EX2_n982RepresentanteRGUF = new bool[] {false} ;
         P00EX2_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         P00EX2_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         P00EX2_A980RepresentanteRG = new string[] {""} ;
         P00EX2_n980RepresentanteRG = new bool[] {false} ;
         P00EX2_A978RepresentanteId = new int[1] ;
         A991RepresentanteMunicipio = "";
         AV35Option = "";
         P00EX3_A977RepresentanteProfissao = new int[1] ;
         P00EX3_n977RepresentanteProfissao = new bool[] {false} ;
         P00EX3_A991RepresentanteMunicipio = new string[] {""} ;
         P00EX3_n991RepresentanteMunicipio = new bool[] {false} ;
         P00EX3_A168ClienteId = new int[1] ;
         P00EX3_n168ClienteId = new bool[] {false} ;
         P00EX3_A980RepresentanteRG = new string[] {""} ;
         P00EX3_n980RepresentanteRG = new bool[] {false} ;
         P00EX3_A997RepresentanteMunicipioNome = new string[] {""} ;
         P00EX3_n997RepresentanteMunicipioNome = new bool[] {false} ;
         P00EX3_A998RepresentanteTipo = new string[] {""} ;
         P00EX3_n998RepresentanteTipo = new bool[] {false} ;
         P00EX3_A986RepresentanteEmail = new string[] {""} ;
         P00EX3_n986RepresentanteEmail = new bool[] {false} ;
         P00EX3_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         P00EX3_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         P00EX3_A985RepresentanteNacionalidade = new string[] {""} ;
         P00EX3_n985RepresentanteNacionalidade = new bool[] {false} ;
         P00EX3_A984RepresentanteEstadoCivil = new string[] {""} ;
         P00EX3_n984RepresentanteEstadoCivil = new bool[] {false} ;
         P00EX3_A983RepresentanteCPF = new string[] {""} ;
         P00EX3_n983RepresentanteCPF = new bool[] {false} ;
         P00EX3_A982RepresentanteRGUF = new string[] {""} ;
         P00EX3_n982RepresentanteRGUF = new bool[] {false} ;
         P00EX3_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         P00EX3_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         P00EX3_A979RepresentanteNome = new string[] {""} ;
         P00EX3_n979RepresentanteNome = new bool[] {false} ;
         P00EX3_A978RepresentanteId = new int[1] ;
         P00EX4_A977RepresentanteProfissao = new int[1] ;
         P00EX4_n977RepresentanteProfissao = new bool[] {false} ;
         P00EX4_A991RepresentanteMunicipio = new string[] {""} ;
         P00EX4_n991RepresentanteMunicipio = new bool[] {false} ;
         P00EX4_A168ClienteId = new int[1] ;
         P00EX4_n168ClienteId = new bool[] {false} ;
         P00EX4_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         P00EX4_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         P00EX4_A997RepresentanteMunicipioNome = new string[] {""} ;
         P00EX4_n997RepresentanteMunicipioNome = new bool[] {false} ;
         P00EX4_A998RepresentanteTipo = new string[] {""} ;
         P00EX4_n998RepresentanteTipo = new bool[] {false} ;
         P00EX4_A986RepresentanteEmail = new string[] {""} ;
         P00EX4_n986RepresentanteEmail = new bool[] {false} ;
         P00EX4_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         P00EX4_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         P00EX4_A985RepresentanteNacionalidade = new string[] {""} ;
         P00EX4_n985RepresentanteNacionalidade = new bool[] {false} ;
         P00EX4_A984RepresentanteEstadoCivil = new string[] {""} ;
         P00EX4_n984RepresentanteEstadoCivil = new bool[] {false} ;
         P00EX4_A983RepresentanteCPF = new string[] {""} ;
         P00EX4_n983RepresentanteCPF = new bool[] {false} ;
         P00EX4_A982RepresentanteRGUF = new string[] {""} ;
         P00EX4_n982RepresentanteRGUF = new bool[] {false} ;
         P00EX4_A980RepresentanteRG = new string[] {""} ;
         P00EX4_n980RepresentanteRG = new bool[] {false} ;
         P00EX4_A979RepresentanteNome = new string[] {""} ;
         P00EX4_n979RepresentanteNome = new bool[] {false} ;
         P00EX4_A978RepresentanteId = new int[1] ;
         P00EX5_A977RepresentanteProfissao = new int[1] ;
         P00EX5_n977RepresentanteProfissao = new bool[] {false} ;
         P00EX5_A991RepresentanteMunicipio = new string[] {""} ;
         P00EX5_n991RepresentanteMunicipio = new bool[] {false} ;
         P00EX5_A168ClienteId = new int[1] ;
         P00EX5_n168ClienteId = new bool[] {false} ;
         P00EX5_A982RepresentanteRGUF = new string[] {""} ;
         P00EX5_n982RepresentanteRGUF = new bool[] {false} ;
         P00EX5_A997RepresentanteMunicipioNome = new string[] {""} ;
         P00EX5_n997RepresentanteMunicipioNome = new bool[] {false} ;
         P00EX5_A998RepresentanteTipo = new string[] {""} ;
         P00EX5_n998RepresentanteTipo = new bool[] {false} ;
         P00EX5_A986RepresentanteEmail = new string[] {""} ;
         P00EX5_n986RepresentanteEmail = new bool[] {false} ;
         P00EX5_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         P00EX5_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         P00EX5_A985RepresentanteNacionalidade = new string[] {""} ;
         P00EX5_n985RepresentanteNacionalidade = new bool[] {false} ;
         P00EX5_A984RepresentanteEstadoCivil = new string[] {""} ;
         P00EX5_n984RepresentanteEstadoCivil = new bool[] {false} ;
         P00EX5_A983RepresentanteCPF = new string[] {""} ;
         P00EX5_n983RepresentanteCPF = new bool[] {false} ;
         P00EX5_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         P00EX5_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         P00EX5_A980RepresentanteRG = new string[] {""} ;
         P00EX5_n980RepresentanteRG = new bool[] {false} ;
         P00EX5_A979RepresentanteNome = new string[] {""} ;
         P00EX5_n979RepresentanteNome = new bool[] {false} ;
         P00EX5_A978RepresentanteId = new int[1] ;
         P00EX6_A977RepresentanteProfissao = new int[1] ;
         P00EX6_n977RepresentanteProfissao = new bool[] {false} ;
         P00EX6_A991RepresentanteMunicipio = new string[] {""} ;
         P00EX6_n991RepresentanteMunicipio = new bool[] {false} ;
         P00EX6_A168ClienteId = new int[1] ;
         P00EX6_n168ClienteId = new bool[] {false} ;
         P00EX6_A983RepresentanteCPF = new string[] {""} ;
         P00EX6_n983RepresentanteCPF = new bool[] {false} ;
         P00EX6_A997RepresentanteMunicipioNome = new string[] {""} ;
         P00EX6_n997RepresentanteMunicipioNome = new bool[] {false} ;
         P00EX6_A998RepresentanteTipo = new string[] {""} ;
         P00EX6_n998RepresentanteTipo = new bool[] {false} ;
         P00EX6_A986RepresentanteEmail = new string[] {""} ;
         P00EX6_n986RepresentanteEmail = new bool[] {false} ;
         P00EX6_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         P00EX6_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         P00EX6_A985RepresentanteNacionalidade = new string[] {""} ;
         P00EX6_n985RepresentanteNacionalidade = new bool[] {false} ;
         P00EX6_A984RepresentanteEstadoCivil = new string[] {""} ;
         P00EX6_n984RepresentanteEstadoCivil = new bool[] {false} ;
         P00EX6_A982RepresentanteRGUF = new string[] {""} ;
         P00EX6_n982RepresentanteRGUF = new bool[] {false} ;
         P00EX6_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         P00EX6_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         P00EX6_A980RepresentanteRG = new string[] {""} ;
         P00EX6_n980RepresentanteRG = new bool[] {false} ;
         P00EX6_A979RepresentanteNome = new string[] {""} ;
         P00EX6_n979RepresentanteNome = new bool[] {false} ;
         P00EX6_A978RepresentanteId = new int[1] ;
         P00EX7_A977RepresentanteProfissao = new int[1] ;
         P00EX7_n977RepresentanteProfissao = new bool[] {false} ;
         P00EX7_A991RepresentanteMunicipio = new string[] {""} ;
         P00EX7_n991RepresentanteMunicipio = new bool[] {false} ;
         P00EX7_A168ClienteId = new int[1] ;
         P00EX7_n168ClienteId = new bool[] {false} ;
         P00EX7_A985RepresentanteNacionalidade = new string[] {""} ;
         P00EX7_n985RepresentanteNacionalidade = new bool[] {false} ;
         P00EX7_A997RepresentanteMunicipioNome = new string[] {""} ;
         P00EX7_n997RepresentanteMunicipioNome = new bool[] {false} ;
         P00EX7_A998RepresentanteTipo = new string[] {""} ;
         P00EX7_n998RepresentanteTipo = new bool[] {false} ;
         P00EX7_A986RepresentanteEmail = new string[] {""} ;
         P00EX7_n986RepresentanteEmail = new bool[] {false} ;
         P00EX7_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         P00EX7_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         P00EX7_A984RepresentanteEstadoCivil = new string[] {""} ;
         P00EX7_n984RepresentanteEstadoCivil = new bool[] {false} ;
         P00EX7_A983RepresentanteCPF = new string[] {""} ;
         P00EX7_n983RepresentanteCPF = new bool[] {false} ;
         P00EX7_A982RepresentanteRGUF = new string[] {""} ;
         P00EX7_n982RepresentanteRGUF = new bool[] {false} ;
         P00EX7_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         P00EX7_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         P00EX7_A980RepresentanteRG = new string[] {""} ;
         P00EX7_n980RepresentanteRG = new bool[] {false} ;
         P00EX7_A979RepresentanteNome = new string[] {""} ;
         P00EX7_n979RepresentanteNome = new bool[] {false} ;
         P00EX7_A978RepresentanteId = new int[1] ;
         P00EX8_A991RepresentanteMunicipio = new string[] {""} ;
         P00EX8_n991RepresentanteMunicipio = new bool[] {false} ;
         P00EX8_A977RepresentanteProfissao = new int[1] ;
         P00EX8_n977RepresentanteProfissao = new bool[] {false} ;
         P00EX8_A168ClienteId = new int[1] ;
         P00EX8_n168ClienteId = new bool[] {false} ;
         P00EX8_A997RepresentanteMunicipioNome = new string[] {""} ;
         P00EX8_n997RepresentanteMunicipioNome = new bool[] {false} ;
         P00EX8_A998RepresentanteTipo = new string[] {""} ;
         P00EX8_n998RepresentanteTipo = new bool[] {false} ;
         P00EX8_A986RepresentanteEmail = new string[] {""} ;
         P00EX8_n986RepresentanteEmail = new bool[] {false} ;
         P00EX8_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         P00EX8_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         P00EX8_A985RepresentanteNacionalidade = new string[] {""} ;
         P00EX8_n985RepresentanteNacionalidade = new bool[] {false} ;
         P00EX8_A984RepresentanteEstadoCivil = new string[] {""} ;
         P00EX8_n984RepresentanteEstadoCivil = new bool[] {false} ;
         P00EX8_A983RepresentanteCPF = new string[] {""} ;
         P00EX8_n983RepresentanteCPF = new bool[] {false} ;
         P00EX8_A982RepresentanteRGUF = new string[] {""} ;
         P00EX8_n982RepresentanteRGUF = new bool[] {false} ;
         P00EX8_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         P00EX8_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         P00EX8_A980RepresentanteRG = new string[] {""} ;
         P00EX8_n980RepresentanteRG = new bool[] {false} ;
         P00EX8_A979RepresentanteNome = new string[] {""} ;
         P00EX8_n979RepresentanteNome = new bool[] {false} ;
         P00EX8_A978RepresentanteId = new int[1] ;
         P00EX9_A977RepresentanteProfissao = new int[1] ;
         P00EX9_n977RepresentanteProfissao = new bool[] {false} ;
         P00EX9_A991RepresentanteMunicipio = new string[] {""} ;
         P00EX9_n991RepresentanteMunicipio = new bool[] {false} ;
         P00EX9_A168ClienteId = new int[1] ;
         P00EX9_n168ClienteId = new bool[] {false} ;
         P00EX9_A986RepresentanteEmail = new string[] {""} ;
         P00EX9_n986RepresentanteEmail = new bool[] {false} ;
         P00EX9_A997RepresentanteMunicipioNome = new string[] {""} ;
         P00EX9_n997RepresentanteMunicipioNome = new bool[] {false} ;
         P00EX9_A998RepresentanteTipo = new string[] {""} ;
         P00EX9_n998RepresentanteTipo = new bool[] {false} ;
         P00EX9_A999RepresentanteProfissaoDescricao = new string[] {""} ;
         P00EX9_n999RepresentanteProfissaoDescricao = new bool[] {false} ;
         P00EX9_A985RepresentanteNacionalidade = new string[] {""} ;
         P00EX9_n985RepresentanteNacionalidade = new bool[] {false} ;
         P00EX9_A984RepresentanteEstadoCivil = new string[] {""} ;
         P00EX9_n984RepresentanteEstadoCivil = new bool[] {false} ;
         P00EX9_A983RepresentanteCPF = new string[] {""} ;
         P00EX9_n983RepresentanteCPF = new bool[] {false} ;
         P00EX9_A982RepresentanteRGUF = new string[] {""} ;
         P00EX9_n982RepresentanteRGUF = new bool[] {false} ;
         P00EX9_A981RepresentanteOrgaoExpedidor = new string[] {""} ;
         P00EX9_n981RepresentanteOrgaoExpedidor = new bool[] {false} ;
         P00EX9_A980RepresentanteRG = new string[] {""} ;
         P00EX9_n980RepresentanteRG = new bool[] {false} ;
         P00EX9_A979RepresentanteNome = new string[] {""} ;
         P00EX9_n979RepresentanteNome = new bool[] {false} ;
         P00EX9_A978RepresentanteId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.representantewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00EX2_A977RepresentanteProfissao, P00EX2_n977RepresentanteProfissao, P00EX2_A991RepresentanteMunicipio, P00EX2_n991RepresentanteMunicipio, P00EX2_A168ClienteId, P00EX2_n168ClienteId, P00EX2_A979RepresentanteNome, P00EX2_n979RepresentanteNome, P00EX2_A997RepresentanteMunicipioNome, P00EX2_n997RepresentanteMunicipioNome,
               P00EX2_A998RepresentanteTipo, P00EX2_n998RepresentanteTipo, P00EX2_A986RepresentanteEmail, P00EX2_n986RepresentanteEmail, P00EX2_A999RepresentanteProfissaoDescricao, P00EX2_n999RepresentanteProfissaoDescricao, P00EX2_A985RepresentanteNacionalidade, P00EX2_n985RepresentanteNacionalidade, P00EX2_A984RepresentanteEstadoCivil, P00EX2_n984RepresentanteEstadoCivil,
               P00EX2_A983RepresentanteCPF, P00EX2_n983RepresentanteCPF, P00EX2_A982RepresentanteRGUF, P00EX2_n982RepresentanteRGUF, P00EX2_A981RepresentanteOrgaoExpedidor, P00EX2_n981RepresentanteOrgaoExpedidor, P00EX2_A980RepresentanteRG, P00EX2_n980RepresentanteRG, P00EX2_A978RepresentanteId
               }
               , new Object[] {
               P00EX3_A977RepresentanteProfissao, P00EX3_n977RepresentanteProfissao, P00EX3_A991RepresentanteMunicipio, P00EX3_n991RepresentanteMunicipio, P00EX3_A168ClienteId, P00EX3_n168ClienteId, P00EX3_A980RepresentanteRG, P00EX3_n980RepresentanteRG, P00EX3_A997RepresentanteMunicipioNome, P00EX3_n997RepresentanteMunicipioNome,
               P00EX3_A998RepresentanteTipo, P00EX3_n998RepresentanteTipo, P00EX3_A986RepresentanteEmail, P00EX3_n986RepresentanteEmail, P00EX3_A999RepresentanteProfissaoDescricao, P00EX3_n999RepresentanteProfissaoDescricao, P00EX3_A985RepresentanteNacionalidade, P00EX3_n985RepresentanteNacionalidade, P00EX3_A984RepresentanteEstadoCivil, P00EX3_n984RepresentanteEstadoCivil,
               P00EX3_A983RepresentanteCPF, P00EX3_n983RepresentanteCPF, P00EX3_A982RepresentanteRGUF, P00EX3_n982RepresentanteRGUF, P00EX3_A981RepresentanteOrgaoExpedidor, P00EX3_n981RepresentanteOrgaoExpedidor, P00EX3_A979RepresentanteNome, P00EX3_n979RepresentanteNome, P00EX3_A978RepresentanteId
               }
               , new Object[] {
               P00EX4_A977RepresentanteProfissao, P00EX4_n977RepresentanteProfissao, P00EX4_A991RepresentanteMunicipio, P00EX4_n991RepresentanteMunicipio, P00EX4_A168ClienteId, P00EX4_n168ClienteId, P00EX4_A981RepresentanteOrgaoExpedidor, P00EX4_n981RepresentanteOrgaoExpedidor, P00EX4_A997RepresentanteMunicipioNome, P00EX4_n997RepresentanteMunicipioNome,
               P00EX4_A998RepresentanteTipo, P00EX4_n998RepresentanteTipo, P00EX4_A986RepresentanteEmail, P00EX4_n986RepresentanteEmail, P00EX4_A999RepresentanteProfissaoDescricao, P00EX4_n999RepresentanteProfissaoDescricao, P00EX4_A985RepresentanteNacionalidade, P00EX4_n985RepresentanteNacionalidade, P00EX4_A984RepresentanteEstadoCivil, P00EX4_n984RepresentanteEstadoCivil,
               P00EX4_A983RepresentanteCPF, P00EX4_n983RepresentanteCPF, P00EX4_A982RepresentanteRGUF, P00EX4_n982RepresentanteRGUF, P00EX4_A980RepresentanteRG, P00EX4_n980RepresentanteRG, P00EX4_A979RepresentanteNome, P00EX4_n979RepresentanteNome, P00EX4_A978RepresentanteId
               }
               , new Object[] {
               P00EX5_A977RepresentanteProfissao, P00EX5_n977RepresentanteProfissao, P00EX5_A991RepresentanteMunicipio, P00EX5_n991RepresentanteMunicipio, P00EX5_A168ClienteId, P00EX5_n168ClienteId, P00EX5_A982RepresentanteRGUF, P00EX5_n982RepresentanteRGUF, P00EX5_A997RepresentanteMunicipioNome, P00EX5_n997RepresentanteMunicipioNome,
               P00EX5_A998RepresentanteTipo, P00EX5_n998RepresentanteTipo, P00EX5_A986RepresentanteEmail, P00EX5_n986RepresentanteEmail, P00EX5_A999RepresentanteProfissaoDescricao, P00EX5_n999RepresentanteProfissaoDescricao, P00EX5_A985RepresentanteNacionalidade, P00EX5_n985RepresentanteNacionalidade, P00EX5_A984RepresentanteEstadoCivil, P00EX5_n984RepresentanteEstadoCivil,
               P00EX5_A983RepresentanteCPF, P00EX5_n983RepresentanteCPF, P00EX5_A981RepresentanteOrgaoExpedidor, P00EX5_n981RepresentanteOrgaoExpedidor, P00EX5_A980RepresentanteRG, P00EX5_n980RepresentanteRG, P00EX5_A979RepresentanteNome, P00EX5_n979RepresentanteNome, P00EX5_A978RepresentanteId
               }
               , new Object[] {
               P00EX6_A977RepresentanteProfissao, P00EX6_n977RepresentanteProfissao, P00EX6_A991RepresentanteMunicipio, P00EX6_n991RepresentanteMunicipio, P00EX6_A168ClienteId, P00EX6_n168ClienteId, P00EX6_A983RepresentanteCPF, P00EX6_n983RepresentanteCPF, P00EX6_A997RepresentanteMunicipioNome, P00EX6_n997RepresentanteMunicipioNome,
               P00EX6_A998RepresentanteTipo, P00EX6_n998RepresentanteTipo, P00EX6_A986RepresentanteEmail, P00EX6_n986RepresentanteEmail, P00EX6_A999RepresentanteProfissaoDescricao, P00EX6_n999RepresentanteProfissaoDescricao, P00EX6_A985RepresentanteNacionalidade, P00EX6_n985RepresentanteNacionalidade, P00EX6_A984RepresentanteEstadoCivil, P00EX6_n984RepresentanteEstadoCivil,
               P00EX6_A982RepresentanteRGUF, P00EX6_n982RepresentanteRGUF, P00EX6_A981RepresentanteOrgaoExpedidor, P00EX6_n981RepresentanteOrgaoExpedidor, P00EX6_A980RepresentanteRG, P00EX6_n980RepresentanteRG, P00EX6_A979RepresentanteNome, P00EX6_n979RepresentanteNome, P00EX6_A978RepresentanteId
               }
               , new Object[] {
               P00EX7_A977RepresentanteProfissao, P00EX7_n977RepresentanteProfissao, P00EX7_A991RepresentanteMunicipio, P00EX7_n991RepresentanteMunicipio, P00EX7_A168ClienteId, P00EX7_n168ClienteId, P00EX7_A985RepresentanteNacionalidade, P00EX7_n985RepresentanteNacionalidade, P00EX7_A997RepresentanteMunicipioNome, P00EX7_n997RepresentanteMunicipioNome,
               P00EX7_A998RepresentanteTipo, P00EX7_n998RepresentanteTipo, P00EX7_A986RepresentanteEmail, P00EX7_n986RepresentanteEmail, P00EX7_A999RepresentanteProfissaoDescricao, P00EX7_n999RepresentanteProfissaoDescricao, P00EX7_A984RepresentanteEstadoCivil, P00EX7_n984RepresentanteEstadoCivil, P00EX7_A983RepresentanteCPF, P00EX7_n983RepresentanteCPF,
               P00EX7_A982RepresentanteRGUF, P00EX7_n982RepresentanteRGUF, P00EX7_A981RepresentanteOrgaoExpedidor, P00EX7_n981RepresentanteOrgaoExpedidor, P00EX7_A980RepresentanteRG, P00EX7_n980RepresentanteRG, P00EX7_A979RepresentanteNome, P00EX7_n979RepresentanteNome, P00EX7_A978RepresentanteId
               }
               , new Object[] {
               P00EX8_A991RepresentanteMunicipio, P00EX8_n991RepresentanteMunicipio, P00EX8_A977RepresentanteProfissao, P00EX8_n977RepresentanteProfissao, P00EX8_A168ClienteId, P00EX8_n168ClienteId, P00EX8_A997RepresentanteMunicipioNome, P00EX8_n997RepresentanteMunicipioNome, P00EX8_A998RepresentanteTipo, P00EX8_n998RepresentanteTipo,
               P00EX8_A986RepresentanteEmail, P00EX8_n986RepresentanteEmail, P00EX8_A999RepresentanteProfissaoDescricao, P00EX8_n999RepresentanteProfissaoDescricao, P00EX8_A985RepresentanteNacionalidade, P00EX8_n985RepresentanteNacionalidade, P00EX8_A984RepresentanteEstadoCivil, P00EX8_n984RepresentanteEstadoCivil, P00EX8_A983RepresentanteCPF, P00EX8_n983RepresentanteCPF,
               P00EX8_A982RepresentanteRGUF, P00EX8_n982RepresentanteRGUF, P00EX8_A981RepresentanteOrgaoExpedidor, P00EX8_n981RepresentanteOrgaoExpedidor, P00EX8_A980RepresentanteRG, P00EX8_n980RepresentanteRG, P00EX8_A979RepresentanteNome, P00EX8_n979RepresentanteNome, P00EX8_A978RepresentanteId
               }
               , new Object[] {
               P00EX9_A977RepresentanteProfissao, P00EX9_n977RepresentanteProfissao, P00EX9_A991RepresentanteMunicipio, P00EX9_n991RepresentanteMunicipio, P00EX9_A168ClienteId, P00EX9_n168ClienteId, P00EX9_A986RepresentanteEmail, P00EX9_n986RepresentanteEmail, P00EX9_A997RepresentanteMunicipioNome, P00EX9_n997RepresentanteMunicipioNome,
               P00EX9_A998RepresentanteTipo, P00EX9_n998RepresentanteTipo, P00EX9_A999RepresentanteProfissaoDescricao, P00EX9_n999RepresentanteProfissaoDescricao, P00EX9_A985RepresentanteNacionalidade, P00EX9_n985RepresentanteNacionalidade, P00EX9_A984RepresentanteEstadoCivil, P00EX9_n984RepresentanteEstadoCivil, P00EX9_A983RepresentanteCPF, P00EX9_n983RepresentanteCPF,
               P00EX9_A982RepresentanteRGUF, P00EX9_n982RepresentanteRGUF, P00EX9_A981RepresentanteOrgaoExpedidor, P00EX9_n981RepresentanteOrgaoExpedidor, P00EX9_A980RepresentanteRG, P00EX9_n980RepresentanteRG, P00EX9_A979RepresentanteNome, P00EX9_n979RepresentanteNome, P00EX9_A978RepresentanteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV33MaxItems ;
      private short AV32PageIndex ;
      private short AV31SkipItems ;
      private short AV54DynamicFiltersOperator1 ;
      private short AV59DynamicFiltersOperator2 ;
      private short AV64DynamicFiltersOperator3 ;
      private short AV74Representantewwds_3_dynamicfiltersoperator1 ;
      private short AV79Representantewwds_8_dynamicfiltersoperator2 ;
      private short AV84Representantewwds_13_dynamicfiltersoperator3 ;
      private int AV70GXV1 ;
      private int AV67ClienteId ;
      private int AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count ;
      private int AV104Representantewwds_33_tfrepresentantetipo_sels_Count ;
      private int A168ClienteId ;
      private int A977RepresentanteProfissao ;
      private int A978RepresentanteId ;
      private int AV34InsertIndex ;
      private long AV40count ;
      private bool returnInSub ;
      private bool AV57DynamicFiltersEnabled2 ;
      private bool AV62DynamicFiltersEnabled3 ;
      private bool AV77Representantewwds_6_dynamicfiltersenabled2 ;
      private bool AV82Representantewwds_11_dynamicfiltersenabled3 ;
      private bool BRKEX2 ;
      private bool n977RepresentanteProfissao ;
      private bool n991RepresentanteMunicipio ;
      private bool n168ClienteId ;
      private bool n979RepresentanteNome ;
      private bool n997RepresentanteMunicipioNome ;
      private bool n998RepresentanteTipo ;
      private bool n986RepresentanteEmail ;
      private bool n999RepresentanteProfissaoDescricao ;
      private bool n985RepresentanteNacionalidade ;
      private bool n984RepresentanteEstadoCivil ;
      private bool n983RepresentanteCPF ;
      private bool n982RepresentanteRGUF ;
      private bool n981RepresentanteOrgaoExpedidor ;
      private bool n980RepresentanteRG ;
      private bool BRKEX4 ;
      private bool BRKEX6 ;
      private bool BRKEX8 ;
      private bool BRKEX10 ;
      private bool BRKEX12 ;
      private bool BRKEX14 ;
      private bool BRKEX16 ;
      private string AV49OptionsJson ;
      private string AV50OptionsDescJson ;
      private string AV51OptionIndexesJson ;
      private string AV20TFRepresentanteEstadoCivil_SelsJson ;
      private string AV28TFRepresentanteTipo_SelsJson ;
      private string AV46DDOName ;
      private string AV47SearchTxtParms ;
      private string AV48SearchTxtTo ;
      private string AV30SearchTxt ;
      private string AV52FilterFullText ;
      private string AV10TFRepresentanteNome ;
      private string AV11TFRepresentanteNome_Sel ;
      private string AV12TFRepresentanteRG ;
      private string AV13TFRepresentanteRG_Sel ;
      private string AV14TFRepresentanteOrgaoExpedidor ;
      private string AV15TFRepresentanteOrgaoExpedidor_Sel ;
      private string AV16TFRepresentanteRGUF ;
      private string AV17TFRepresentanteRGUF_Sel ;
      private string AV18TFRepresentanteCPF ;
      private string AV19TFRepresentanteCPF_Sel ;
      private string AV22TFRepresentanteNacionalidade ;
      private string AV23TFRepresentanteNacionalidade_Sel ;
      private string AV68TFRepresentanteProfissaoDescricao ;
      private string AV69TFRepresentanteProfissaoDescricao_Sel ;
      private string AV26TFRepresentanteEmail ;
      private string AV27TFRepresentanteEmail_Sel ;
      private string AV53DynamicFiltersSelector1 ;
      private string AV55RepresentanteNome1 ;
      private string AV56RepresentanteMunicipioNome1 ;
      private string AV58DynamicFiltersSelector2 ;
      private string AV60RepresentanteNome2 ;
      private string AV61RepresentanteMunicipioNome2 ;
      private string AV63DynamicFiltersSelector3 ;
      private string AV65RepresentanteNome3 ;
      private string AV66RepresentanteMunicipioNome3 ;
      private string AV72Representantewwds_1_filterfulltext ;
      private string AV73Representantewwds_2_dynamicfiltersselector1 ;
      private string AV75Representantewwds_4_representantenome1 ;
      private string AV76Representantewwds_5_representantemunicipionome1 ;
      private string AV78Representantewwds_7_dynamicfiltersselector2 ;
      private string AV80Representantewwds_9_representantenome2 ;
      private string AV81Representantewwds_10_representantemunicipionome2 ;
      private string AV83Representantewwds_12_dynamicfiltersselector3 ;
      private string AV85Representantewwds_14_representantenome3 ;
      private string AV86Representantewwds_15_representantemunicipionome3 ;
      private string AV87Representantewwds_16_tfrepresentantenome ;
      private string AV88Representantewwds_17_tfrepresentantenome_sel ;
      private string AV89Representantewwds_18_tfrepresentanterg ;
      private string AV90Representantewwds_19_tfrepresentanterg_sel ;
      private string AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ;
      private string AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ;
      private string AV93Representantewwds_22_tfrepresentanterguf ;
      private string AV94Representantewwds_23_tfrepresentanterguf_sel ;
      private string AV95Representantewwds_24_tfrepresentantecpf ;
      private string AV96Representantewwds_25_tfrepresentantecpf_sel ;
      private string AV98Representantewwds_27_tfrepresentantenacionalidade ;
      private string AV99Representantewwds_28_tfrepresentantenacionalidade_sel ;
      private string AV100Representantewwds_29_tfrepresentanteprofissaodescricao ;
      private string AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ;
      private string AV102Representantewwds_31_tfrepresentanteemail ;
      private string AV103Representantewwds_32_tfrepresentanteemail_sel ;
      private string lV72Representantewwds_1_filterfulltext ;
      private string lV75Representantewwds_4_representantenome1 ;
      private string lV76Representantewwds_5_representantemunicipionome1 ;
      private string lV80Representantewwds_9_representantenome2 ;
      private string lV81Representantewwds_10_representantemunicipionome2 ;
      private string lV85Representantewwds_14_representantenome3 ;
      private string lV86Representantewwds_15_representantemunicipionome3 ;
      private string lV87Representantewwds_16_tfrepresentantenome ;
      private string lV89Representantewwds_18_tfrepresentanterg ;
      private string lV91Representantewwds_20_tfrepresentanteorgaoexpedidor ;
      private string lV93Representantewwds_22_tfrepresentanterguf ;
      private string lV95Representantewwds_24_tfrepresentantecpf ;
      private string lV98Representantewwds_27_tfrepresentantenacionalidade ;
      private string lV100Representantewwds_29_tfrepresentanteprofissaodescricao ;
      private string lV102Representantewwds_31_tfrepresentanteemail ;
      private string A984RepresentanteEstadoCivil ;
      private string A998RepresentanteTipo ;
      private string A979RepresentanteNome ;
      private string A980RepresentanteRG ;
      private string A981RepresentanteOrgaoExpedidor ;
      private string A982RepresentanteRGUF ;
      private string A983RepresentanteCPF ;
      private string A985RepresentanteNacionalidade ;
      private string A999RepresentanteProfissaoDescricao ;
      private string A986RepresentanteEmail ;
      private string A997RepresentanteMunicipioNome ;
      private string A991RepresentanteMunicipio ;
      private string AV35Option ;
      private IGxSession AV41Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV36Options ;
      private GxSimpleCollection<string> AV38OptionsDesc ;
      private GxSimpleCollection<string> AV39OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV43GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV44GridStateFilterValue ;
      private GxSimpleCollection<string> AV21TFRepresentanteEstadoCivil_Sels ;
      private GxSimpleCollection<string> AV29TFRepresentanteTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV45GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV97Representantewwds_26_tfrepresentanteestadocivil_sels ;
      private GxSimpleCollection<string> AV104Representantewwds_33_tfrepresentantetipo_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00EX2_A977RepresentanteProfissao ;
      private bool[] P00EX2_n977RepresentanteProfissao ;
      private string[] P00EX2_A991RepresentanteMunicipio ;
      private bool[] P00EX2_n991RepresentanteMunicipio ;
      private int[] P00EX2_A168ClienteId ;
      private bool[] P00EX2_n168ClienteId ;
      private string[] P00EX2_A979RepresentanteNome ;
      private bool[] P00EX2_n979RepresentanteNome ;
      private string[] P00EX2_A997RepresentanteMunicipioNome ;
      private bool[] P00EX2_n997RepresentanteMunicipioNome ;
      private string[] P00EX2_A998RepresentanteTipo ;
      private bool[] P00EX2_n998RepresentanteTipo ;
      private string[] P00EX2_A986RepresentanteEmail ;
      private bool[] P00EX2_n986RepresentanteEmail ;
      private string[] P00EX2_A999RepresentanteProfissaoDescricao ;
      private bool[] P00EX2_n999RepresentanteProfissaoDescricao ;
      private string[] P00EX2_A985RepresentanteNacionalidade ;
      private bool[] P00EX2_n985RepresentanteNacionalidade ;
      private string[] P00EX2_A984RepresentanteEstadoCivil ;
      private bool[] P00EX2_n984RepresentanteEstadoCivil ;
      private string[] P00EX2_A983RepresentanteCPF ;
      private bool[] P00EX2_n983RepresentanteCPF ;
      private string[] P00EX2_A982RepresentanteRGUF ;
      private bool[] P00EX2_n982RepresentanteRGUF ;
      private string[] P00EX2_A981RepresentanteOrgaoExpedidor ;
      private bool[] P00EX2_n981RepresentanteOrgaoExpedidor ;
      private string[] P00EX2_A980RepresentanteRG ;
      private bool[] P00EX2_n980RepresentanteRG ;
      private int[] P00EX2_A978RepresentanteId ;
      private int[] P00EX3_A977RepresentanteProfissao ;
      private bool[] P00EX3_n977RepresentanteProfissao ;
      private string[] P00EX3_A991RepresentanteMunicipio ;
      private bool[] P00EX3_n991RepresentanteMunicipio ;
      private int[] P00EX3_A168ClienteId ;
      private bool[] P00EX3_n168ClienteId ;
      private string[] P00EX3_A980RepresentanteRG ;
      private bool[] P00EX3_n980RepresentanteRG ;
      private string[] P00EX3_A997RepresentanteMunicipioNome ;
      private bool[] P00EX3_n997RepresentanteMunicipioNome ;
      private string[] P00EX3_A998RepresentanteTipo ;
      private bool[] P00EX3_n998RepresentanteTipo ;
      private string[] P00EX3_A986RepresentanteEmail ;
      private bool[] P00EX3_n986RepresentanteEmail ;
      private string[] P00EX3_A999RepresentanteProfissaoDescricao ;
      private bool[] P00EX3_n999RepresentanteProfissaoDescricao ;
      private string[] P00EX3_A985RepresentanteNacionalidade ;
      private bool[] P00EX3_n985RepresentanteNacionalidade ;
      private string[] P00EX3_A984RepresentanteEstadoCivil ;
      private bool[] P00EX3_n984RepresentanteEstadoCivil ;
      private string[] P00EX3_A983RepresentanteCPF ;
      private bool[] P00EX3_n983RepresentanteCPF ;
      private string[] P00EX3_A982RepresentanteRGUF ;
      private bool[] P00EX3_n982RepresentanteRGUF ;
      private string[] P00EX3_A981RepresentanteOrgaoExpedidor ;
      private bool[] P00EX3_n981RepresentanteOrgaoExpedidor ;
      private string[] P00EX3_A979RepresentanteNome ;
      private bool[] P00EX3_n979RepresentanteNome ;
      private int[] P00EX3_A978RepresentanteId ;
      private int[] P00EX4_A977RepresentanteProfissao ;
      private bool[] P00EX4_n977RepresentanteProfissao ;
      private string[] P00EX4_A991RepresentanteMunicipio ;
      private bool[] P00EX4_n991RepresentanteMunicipio ;
      private int[] P00EX4_A168ClienteId ;
      private bool[] P00EX4_n168ClienteId ;
      private string[] P00EX4_A981RepresentanteOrgaoExpedidor ;
      private bool[] P00EX4_n981RepresentanteOrgaoExpedidor ;
      private string[] P00EX4_A997RepresentanteMunicipioNome ;
      private bool[] P00EX4_n997RepresentanteMunicipioNome ;
      private string[] P00EX4_A998RepresentanteTipo ;
      private bool[] P00EX4_n998RepresentanteTipo ;
      private string[] P00EX4_A986RepresentanteEmail ;
      private bool[] P00EX4_n986RepresentanteEmail ;
      private string[] P00EX4_A999RepresentanteProfissaoDescricao ;
      private bool[] P00EX4_n999RepresentanteProfissaoDescricao ;
      private string[] P00EX4_A985RepresentanteNacionalidade ;
      private bool[] P00EX4_n985RepresentanteNacionalidade ;
      private string[] P00EX4_A984RepresentanteEstadoCivil ;
      private bool[] P00EX4_n984RepresentanteEstadoCivil ;
      private string[] P00EX4_A983RepresentanteCPF ;
      private bool[] P00EX4_n983RepresentanteCPF ;
      private string[] P00EX4_A982RepresentanteRGUF ;
      private bool[] P00EX4_n982RepresentanteRGUF ;
      private string[] P00EX4_A980RepresentanteRG ;
      private bool[] P00EX4_n980RepresentanteRG ;
      private string[] P00EX4_A979RepresentanteNome ;
      private bool[] P00EX4_n979RepresentanteNome ;
      private int[] P00EX4_A978RepresentanteId ;
      private int[] P00EX5_A977RepresentanteProfissao ;
      private bool[] P00EX5_n977RepresentanteProfissao ;
      private string[] P00EX5_A991RepresentanteMunicipio ;
      private bool[] P00EX5_n991RepresentanteMunicipio ;
      private int[] P00EX5_A168ClienteId ;
      private bool[] P00EX5_n168ClienteId ;
      private string[] P00EX5_A982RepresentanteRGUF ;
      private bool[] P00EX5_n982RepresentanteRGUF ;
      private string[] P00EX5_A997RepresentanteMunicipioNome ;
      private bool[] P00EX5_n997RepresentanteMunicipioNome ;
      private string[] P00EX5_A998RepresentanteTipo ;
      private bool[] P00EX5_n998RepresentanteTipo ;
      private string[] P00EX5_A986RepresentanteEmail ;
      private bool[] P00EX5_n986RepresentanteEmail ;
      private string[] P00EX5_A999RepresentanteProfissaoDescricao ;
      private bool[] P00EX5_n999RepresentanteProfissaoDescricao ;
      private string[] P00EX5_A985RepresentanteNacionalidade ;
      private bool[] P00EX5_n985RepresentanteNacionalidade ;
      private string[] P00EX5_A984RepresentanteEstadoCivil ;
      private bool[] P00EX5_n984RepresentanteEstadoCivil ;
      private string[] P00EX5_A983RepresentanteCPF ;
      private bool[] P00EX5_n983RepresentanteCPF ;
      private string[] P00EX5_A981RepresentanteOrgaoExpedidor ;
      private bool[] P00EX5_n981RepresentanteOrgaoExpedidor ;
      private string[] P00EX5_A980RepresentanteRG ;
      private bool[] P00EX5_n980RepresentanteRG ;
      private string[] P00EX5_A979RepresentanteNome ;
      private bool[] P00EX5_n979RepresentanteNome ;
      private int[] P00EX5_A978RepresentanteId ;
      private int[] P00EX6_A977RepresentanteProfissao ;
      private bool[] P00EX6_n977RepresentanteProfissao ;
      private string[] P00EX6_A991RepresentanteMunicipio ;
      private bool[] P00EX6_n991RepresentanteMunicipio ;
      private int[] P00EX6_A168ClienteId ;
      private bool[] P00EX6_n168ClienteId ;
      private string[] P00EX6_A983RepresentanteCPF ;
      private bool[] P00EX6_n983RepresentanteCPF ;
      private string[] P00EX6_A997RepresentanteMunicipioNome ;
      private bool[] P00EX6_n997RepresentanteMunicipioNome ;
      private string[] P00EX6_A998RepresentanteTipo ;
      private bool[] P00EX6_n998RepresentanteTipo ;
      private string[] P00EX6_A986RepresentanteEmail ;
      private bool[] P00EX6_n986RepresentanteEmail ;
      private string[] P00EX6_A999RepresentanteProfissaoDescricao ;
      private bool[] P00EX6_n999RepresentanteProfissaoDescricao ;
      private string[] P00EX6_A985RepresentanteNacionalidade ;
      private bool[] P00EX6_n985RepresentanteNacionalidade ;
      private string[] P00EX6_A984RepresentanteEstadoCivil ;
      private bool[] P00EX6_n984RepresentanteEstadoCivil ;
      private string[] P00EX6_A982RepresentanteRGUF ;
      private bool[] P00EX6_n982RepresentanteRGUF ;
      private string[] P00EX6_A981RepresentanteOrgaoExpedidor ;
      private bool[] P00EX6_n981RepresentanteOrgaoExpedidor ;
      private string[] P00EX6_A980RepresentanteRG ;
      private bool[] P00EX6_n980RepresentanteRG ;
      private string[] P00EX6_A979RepresentanteNome ;
      private bool[] P00EX6_n979RepresentanteNome ;
      private int[] P00EX6_A978RepresentanteId ;
      private int[] P00EX7_A977RepresentanteProfissao ;
      private bool[] P00EX7_n977RepresentanteProfissao ;
      private string[] P00EX7_A991RepresentanteMunicipio ;
      private bool[] P00EX7_n991RepresentanteMunicipio ;
      private int[] P00EX7_A168ClienteId ;
      private bool[] P00EX7_n168ClienteId ;
      private string[] P00EX7_A985RepresentanteNacionalidade ;
      private bool[] P00EX7_n985RepresentanteNacionalidade ;
      private string[] P00EX7_A997RepresentanteMunicipioNome ;
      private bool[] P00EX7_n997RepresentanteMunicipioNome ;
      private string[] P00EX7_A998RepresentanteTipo ;
      private bool[] P00EX7_n998RepresentanteTipo ;
      private string[] P00EX7_A986RepresentanteEmail ;
      private bool[] P00EX7_n986RepresentanteEmail ;
      private string[] P00EX7_A999RepresentanteProfissaoDescricao ;
      private bool[] P00EX7_n999RepresentanteProfissaoDescricao ;
      private string[] P00EX7_A984RepresentanteEstadoCivil ;
      private bool[] P00EX7_n984RepresentanteEstadoCivil ;
      private string[] P00EX7_A983RepresentanteCPF ;
      private bool[] P00EX7_n983RepresentanteCPF ;
      private string[] P00EX7_A982RepresentanteRGUF ;
      private bool[] P00EX7_n982RepresentanteRGUF ;
      private string[] P00EX7_A981RepresentanteOrgaoExpedidor ;
      private bool[] P00EX7_n981RepresentanteOrgaoExpedidor ;
      private string[] P00EX7_A980RepresentanteRG ;
      private bool[] P00EX7_n980RepresentanteRG ;
      private string[] P00EX7_A979RepresentanteNome ;
      private bool[] P00EX7_n979RepresentanteNome ;
      private int[] P00EX7_A978RepresentanteId ;
      private string[] P00EX8_A991RepresentanteMunicipio ;
      private bool[] P00EX8_n991RepresentanteMunicipio ;
      private int[] P00EX8_A977RepresentanteProfissao ;
      private bool[] P00EX8_n977RepresentanteProfissao ;
      private int[] P00EX8_A168ClienteId ;
      private bool[] P00EX8_n168ClienteId ;
      private string[] P00EX8_A997RepresentanteMunicipioNome ;
      private bool[] P00EX8_n997RepresentanteMunicipioNome ;
      private string[] P00EX8_A998RepresentanteTipo ;
      private bool[] P00EX8_n998RepresentanteTipo ;
      private string[] P00EX8_A986RepresentanteEmail ;
      private bool[] P00EX8_n986RepresentanteEmail ;
      private string[] P00EX8_A999RepresentanteProfissaoDescricao ;
      private bool[] P00EX8_n999RepresentanteProfissaoDescricao ;
      private string[] P00EX8_A985RepresentanteNacionalidade ;
      private bool[] P00EX8_n985RepresentanteNacionalidade ;
      private string[] P00EX8_A984RepresentanteEstadoCivil ;
      private bool[] P00EX8_n984RepresentanteEstadoCivil ;
      private string[] P00EX8_A983RepresentanteCPF ;
      private bool[] P00EX8_n983RepresentanteCPF ;
      private string[] P00EX8_A982RepresentanteRGUF ;
      private bool[] P00EX8_n982RepresentanteRGUF ;
      private string[] P00EX8_A981RepresentanteOrgaoExpedidor ;
      private bool[] P00EX8_n981RepresentanteOrgaoExpedidor ;
      private string[] P00EX8_A980RepresentanteRG ;
      private bool[] P00EX8_n980RepresentanteRG ;
      private string[] P00EX8_A979RepresentanteNome ;
      private bool[] P00EX8_n979RepresentanteNome ;
      private int[] P00EX8_A978RepresentanteId ;
      private int[] P00EX9_A977RepresentanteProfissao ;
      private bool[] P00EX9_n977RepresentanteProfissao ;
      private string[] P00EX9_A991RepresentanteMunicipio ;
      private bool[] P00EX9_n991RepresentanteMunicipio ;
      private int[] P00EX9_A168ClienteId ;
      private bool[] P00EX9_n168ClienteId ;
      private string[] P00EX9_A986RepresentanteEmail ;
      private bool[] P00EX9_n986RepresentanteEmail ;
      private string[] P00EX9_A997RepresentanteMunicipioNome ;
      private bool[] P00EX9_n997RepresentanteMunicipioNome ;
      private string[] P00EX9_A998RepresentanteTipo ;
      private bool[] P00EX9_n998RepresentanteTipo ;
      private string[] P00EX9_A999RepresentanteProfissaoDescricao ;
      private bool[] P00EX9_n999RepresentanteProfissaoDescricao ;
      private string[] P00EX9_A985RepresentanteNacionalidade ;
      private bool[] P00EX9_n985RepresentanteNacionalidade ;
      private string[] P00EX9_A984RepresentanteEstadoCivil ;
      private bool[] P00EX9_n984RepresentanteEstadoCivil ;
      private string[] P00EX9_A983RepresentanteCPF ;
      private bool[] P00EX9_n983RepresentanteCPF ;
      private string[] P00EX9_A982RepresentanteRGUF ;
      private bool[] P00EX9_n982RepresentanteRGUF ;
      private string[] P00EX9_A981RepresentanteOrgaoExpedidor ;
      private bool[] P00EX9_n981RepresentanteOrgaoExpedidor ;
      private string[] P00EX9_A980RepresentanteRG ;
      private bool[] P00EX9_n980RepresentanteRG ;
      private string[] P00EX9_A979RepresentanteNome ;
      private bool[] P00EX9_n979RepresentanteNome ;
      private int[] P00EX9_A978RepresentanteId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class representantewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EX2( IGxContext context ,
                                             string A984RepresentanteEstadoCivil ,
                                             GxSimpleCollection<string> AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                             string A998RepresentanteTipo ,
                                             GxSimpleCollection<string> AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                             string AV72Representantewwds_1_filterfulltext ,
                                             string AV73Representantewwds_2_dynamicfiltersselector1 ,
                                             short AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                             string AV75Representantewwds_4_representantenome1 ,
                                             string AV76Representantewwds_5_representantemunicipionome1 ,
                                             bool AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                             string AV78Representantewwds_7_dynamicfiltersselector2 ,
                                             short AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                             string AV80Representantewwds_9_representantenome2 ,
                                             string AV81Representantewwds_10_representantemunicipionome2 ,
                                             bool AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                             string AV83Representantewwds_12_dynamicfiltersselector3 ,
                                             short AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                             string AV85Representantewwds_14_representantenome3 ,
                                             string AV86Representantewwds_15_representantemunicipionome3 ,
                                             string AV88Representantewwds_17_tfrepresentantenome_sel ,
                                             string AV87Representantewwds_16_tfrepresentantenome ,
                                             string AV90Representantewwds_19_tfrepresentanterg_sel ,
                                             string AV89Representantewwds_18_tfrepresentanterg ,
                                             string AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                             string AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                             string AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                             string AV93Representantewwds_22_tfrepresentanterguf ,
                                             string AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                             string AV95Representantewwds_24_tfrepresentantecpf ,
                                             int AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count ,
                                             string AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                             string AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                             string AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                             string AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                             string AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                             string AV102Representantewwds_31_tfrepresentanteemail ,
                                             int AV104Representantewwds_33_tfrepresentantetipo_sels_Count ,
                                             string A979RepresentanteNome ,
                                             string A980RepresentanteRG ,
                                             string A981RepresentanteOrgaoExpedidor ,
                                             string A982RepresentanteRGUF ,
                                             string A983RepresentanteCPF ,
                                             string A985RepresentanteNacionalidade ,
                                             string A999RepresentanteProfissaoDescricao ,
                                             string A986RepresentanteEmail ,
                                             string A997RepresentanteMunicipioNome ,
                                             int A168ClienteId ,
                                             int AV67ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[45];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.RepresentanteProfissao AS RepresentanteProfissao, T1.RepresentanteMunicipio AS RepresentanteMunicipio, T1.ClienteId, T1.RepresentanteNome, T3.MunicipioNome AS RepresentanteMunicipioNome, T1.RepresentanteTipo, T1.RepresentanteEmail, T2.ProfissaoNome AS RepresentanteProfissaoDescricao, T1.RepresentanteNacionalidade, T1.RepresentanteEstadoCivil, T1.RepresentanteCPF, T1.RepresentanteRGUF, T1.RepresentanteOrgaoExpedidor, T1.RepresentanteRG, T1.RepresentanteId FROM ((Representante T1 LEFT JOIN Profissao T2 ON T2.ProfissaoId = T1.RepresentanteProfissao) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.RepresentanteMunicipio)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV67ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Representantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.RepresentanteNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRG like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteOrgaoExpedidor like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRGUF like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteCPF like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'solteiro(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SOLTEIRO')) or ( 'casado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'CASADO')) or ( 'divorciado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'DIVORCIADO')) or ( 'viúvo(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'VIUVO')) or ( 'separado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SEPARADO')) or ( 'união estável' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'UNIAO_ESTAVEL')) or ( T1.RepresentanteNacionalidade like '%' || :lV72Representantewwds_1_filterfulltext) or ( T2.ProfissaoNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteEmail like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'representante' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Representante')) or ( 'responsável solidário' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Responsavel_solidario')))");
         }
         else
         {
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
            GXv_int1[4] = 1;
            GXv_int1[5] = 1;
            GXv_int1[6] = 1;
            GXv_int1[7] = 1;
            GXv_int1[8] = 1;
            GXv_int1[9] = 1;
            GXv_int1[10] = 1;
            GXv_int1[11] = 1;
            GXv_int1[12] = 1;
            GXv_int1[13] = 1;
            GXv_int1[14] = 1;
            GXv_int1[15] = 1;
            GXv_int1[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV87Representantewwds_16_tfrepresentantenome)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome = ( :AV88Representantewwds_17_tfrepresentantenome_sel))");
         }
         else
         {
            GXv_int1[30] = 1;
         }
         if ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG like :lV89Representantewwds_18_tfrepresentanterg)");
         }
         else
         {
            GXv_int1[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ! ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG = ( :AV90Representantewwds_19_tfrepresentanterg_sel))");
         }
         else
         {
            GXv_int1[32] = 1;
         }
         if ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRG))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor like :lV91Representantewwds_20_tfrepresentanteorgaoexpedidor)");
         }
         else
         {
            GXv_int1[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ! ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor = ( :AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel))");
         }
         else
         {
            GXv_int1[34] = 1;
         }
         if ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteOrgaoExpedidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF like :lV93Representantewwds_22_tfrepresentanterguf)");
         }
         else
         {
            GXv_int1[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ! ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF = ( :AV94Representantewwds_23_tfrepresentanterguf_sel))");
         }
         else
         {
            GXv_int1[36] = 1;
         }
         if ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRGUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF like :lV95Representantewwds_24_tfrepresentantecpf)");
         }
         else
         {
            GXv_int1[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ! ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF = ( :AV96Representantewwds_25_tfrepresentantecpf_sel))");
         }
         else
         {
            GXv_int1[38] = 1;
         }
         if ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteCPF))=0))");
         }
         if ( AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV97Representantewwds_26_tfrepresentanteestadocivil_sels, "T1.RepresentanteEstadoCivil IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade like :lV98Representantewwds_27_tfrepresentantenacionalidade)");
         }
         else
         {
            GXv_int1[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ! ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade = ( :AV99Representantewwds_28_tfrepresentantenacionalidade_sel))");
         }
         else
         {
            GXv_int1[40] = 1;
         }
         if ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNacionalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome like :lV100Representantewwds_29_tfrepresentanteprofissaodescricao)");
         }
         else
         {
            GXv_int1[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ! ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome = ( :AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel))");
         }
         else
         {
            GXv_int1[42] = 1;
         }
         if ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from T2.ProfissaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail like :lV102Representantewwds_31_tfrepresentanteemail)");
         }
         else
         {
            GXv_int1[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail = ( :AV103Representantewwds_32_tfrepresentanteemail_sel))");
         }
         else
         {
            GXv_int1[44] = 1;
         }
         if ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteEmail))=0))");
         }
         if ( AV104Representantewwds_33_tfrepresentantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV104Representantewwds_33_tfrepresentantetipo_sels, "T1.RepresentanteTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.RepresentanteNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00EX3( IGxContext context ,
                                             string A984RepresentanteEstadoCivil ,
                                             GxSimpleCollection<string> AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                             string A998RepresentanteTipo ,
                                             GxSimpleCollection<string> AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                             string AV72Representantewwds_1_filterfulltext ,
                                             string AV73Representantewwds_2_dynamicfiltersselector1 ,
                                             short AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                             string AV75Representantewwds_4_representantenome1 ,
                                             string AV76Representantewwds_5_representantemunicipionome1 ,
                                             bool AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                             string AV78Representantewwds_7_dynamicfiltersselector2 ,
                                             short AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                             string AV80Representantewwds_9_representantenome2 ,
                                             string AV81Representantewwds_10_representantemunicipionome2 ,
                                             bool AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                             string AV83Representantewwds_12_dynamicfiltersselector3 ,
                                             short AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                             string AV85Representantewwds_14_representantenome3 ,
                                             string AV86Representantewwds_15_representantemunicipionome3 ,
                                             string AV88Representantewwds_17_tfrepresentantenome_sel ,
                                             string AV87Representantewwds_16_tfrepresentantenome ,
                                             string AV90Representantewwds_19_tfrepresentanterg_sel ,
                                             string AV89Representantewwds_18_tfrepresentanterg ,
                                             string AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                             string AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                             string AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                             string AV93Representantewwds_22_tfrepresentanterguf ,
                                             string AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                             string AV95Representantewwds_24_tfrepresentantecpf ,
                                             int AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count ,
                                             string AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                             string AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                             string AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                             string AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                             string AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                             string AV102Representantewwds_31_tfrepresentanteemail ,
                                             int AV104Representantewwds_33_tfrepresentantetipo_sels_Count ,
                                             string A979RepresentanteNome ,
                                             string A980RepresentanteRG ,
                                             string A981RepresentanteOrgaoExpedidor ,
                                             string A982RepresentanteRGUF ,
                                             string A983RepresentanteCPF ,
                                             string A985RepresentanteNacionalidade ,
                                             string A999RepresentanteProfissaoDescricao ,
                                             string A986RepresentanteEmail ,
                                             string A997RepresentanteMunicipioNome ,
                                             int A168ClienteId ,
                                             int AV67ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[45];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.RepresentanteProfissao AS RepresentanteProfissao, T1.RepresentanteMunicipio AS RepresentanteMunicipio, T1.ClienteId, T1.RepresentanteRG, T3.MunicipioNome AS RepresentanteMunicipioNome, T1.RepresentanteTipo, T1.RepresentanteEmail, T2.ProfissaoNome AS RepresentanteProfissaoDescricao, T1.RepresentanteNacionalidade, T1.RepresentanteEstadoCivil, T1.RepresentanteCPF, T1.RepresentanteRGUF, T1.RepresentanteOrgaoExpedidor, T1.RepresentanteNome, T1.RepresentanteId FROM ((Representante T1 LEFT JOIN Profissao T2 ON T2.ProfissaoId = T1.RepresentanteProfissao) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.RepresentanteMunicipio)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV67ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Representantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.RepresentanteNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRG like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteOrgaoExpedidor like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRGUF like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteCPF like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'solteiro(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SOLTEIRO')) or ( 'casado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'CASADO')) or ( 'divorciado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'DIVORCIADO')) or ( 'viúvo(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'VIUVO')) or ( 'separado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SEPARADO')) or ( 'união estável' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'UNIAO_ESTAVEL')) or ( T1.RepresentanteNacionalidade like '%' || :lV72Representantewwds_1_filterfulltext) or ( T2.ProfissaoNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteEmail like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'representante' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Representante')) or ( 'responsável solidário' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Responsavel_solidario')))");
         }
         else
         {
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
            GXv_int3[5] = 1;
            GXv_int3[6] = 1;
            GXv_int3[7] = 1;
            GXv_int3[8] = 1;
            GXv_int3[9] = 1;
            GXv_int3[10] = 1;
            GXv_int3[11] = 1;
            GXv_int3[12] = 1;
            GXv_int3[13] = 1;
            GXv_int3[14] = 1;
            GXv_int3[15] = 1;
            GXv_int3[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV87Representantewwds_16_tfrepresentantenome)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome = ( :AV88Representantewwds_17_tfrepresentantenome_sel))");
         }
         else
         {
            GXv_int3[30] = 1;
         }
         if ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG like :lV89Representantewwds_18_tfrepresentanterg)");
         }
         else
         {
            GXv_int3[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ! ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG = ( :AV90Representantewwds_19_tfrepresentanterg_sel))");
         }
         else
         {
            GXv_int3[32] = 1;
         }
         if ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRG))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor like :lV91Representantewwds_20_tfrepresentanteorgaoexpedidor)");
         }
         else
         {
            GXv_int3[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ! ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor = ( :AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel))");
         }
         else
         {
            GXv_int3[34] = 1;
         }
         if ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteOrgaoExpedidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF like :lV93Representantewwds_22_tfrepresentanterguf)");
         }
         else
         {
            GXv_int3[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ! ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF = ( :AV94Representantewwds_23_tfrepresentanterguf_sel))");
         }
         else
         {
            GXv_int3[36] = 1;
         }
         if ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRGUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF like :lV95Representantewwds_24_tfrepresentantecpf)");
         }
         else
         {
            GXv_int3[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ! ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF = ( :AV96Representantewwds_25_tfrepresentantecpf_sel))");
         }
         else
         {
            GXv_int3[38] = 1;
         }
         if ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteCPF))=0))");
         }
         if ( AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV97Representantewwds_26_tfrepresentanteestadocivil_sels, "T1.RepresentanteEstadoCivil IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade like :lV98Representantewwds_27_tfrepresentantenacionalidade)");
         }
         else
         {
            GXv_int3[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ! ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade = ( :AV99Representantewwds_28_tfrepresentantenacionalidade_sel))");
         }
         else
         {
            GXv_int3[40] = 1;
         }
         if ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNacionalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome like :lV100Representantewwds_29_tfrepresentanteprofissaodescricao)");
         }
         else
         {
            GXv_int3[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ! ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome = ( :AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel))");
         }
         else
         {
            GXv_int3[42] = 1;
         }
         if ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from T2.ProfissaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail like :lV102Representantewwds_31_tfrepresentanteemail)");
         }
         else
         {
            GXv_int3[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail = ( :AV103Representantewwds_32_tfrepresentanteemail_sel))");
         }
         else
         {
            GXv_int3[44] = 1;
         }
         if ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteEmail))=0))");
         }
         if ( AV104Representantewwds_33_tfrepresentantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV104Representantewwds_33_tfrepresentantetipo_sels, "T1.RepresentanteTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.RepresentanteRG";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00EX4( IGxContext context ,
                                             string A984RepresentanteEstadoCivil ,
                                             GxSimpleCollection<string> AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                             string A998RepresentanteTipo ,
                                             GxSimpleCollection<string> AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                             string AV72Representantewwds_1_filterfulltext ,
                                             string AV73Representantewwds_2_dynamicfiltersselector1 ,
                                             short AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                             string AV75Representantewwds_4_representantenome1 ,
                                             string AV76Representantewwds_5_representantemunicipionome1 ,
                                             bool AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                             string AV78Representantewwds_7_dynamicfiltersselector2 ,
                                             short AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                             string AV80Representantewwds_9_representantenome2 ,
                                             string AV81Representantewwds_10_representantemunicipionome2 ,
                                             bool AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                             string AV83Representantewwds_12_dynamicfiltersselector3 ,
                                             short AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                             string AV85Representantewwds_14_representantenome3 ,
                                             string AV86Representantewwds_15_representantemunicipionome3 ,
                                             string AV88Representantewwds_17_tfrepresentantenome_sel ,
                                             string AV87Representantewwds_16_tfrepresentantenome ,
                                             string AV90Representantewwds_19_tfrepresentanterg_sel ,
                                             string AV89Representantewwds_18_tfrepresentanterg ,
                                             string AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                             string AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                             string AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                             string AV93Representantewwds_22_tfrepresentanterguf ,
                                             string AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                             string AV95Representantewwds_24_tfrepresentantecpf ,
                                             int AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count ,
                                             string AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                             string AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                             string AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                             string AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                             string AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                             string AV102Representantewwds_31_tfrepresentanteemail ,
                                             int AV104Representantewwds_33_tfrepresentantetipo_sels_Count ,
                                             string A979RepresentanteNome ,
                                             string A980RepresentanteRG ,
                                             string A981RepresentanteOrgaoExpedidor ,
                                             string A982RepresentanteRGUF ,
                                             string A983RepresentanteCPF ,
                                             string A985RepresentanteNacionalidade ,
                                             string A999RepresentanteProfissaoDescricao ,
                                             string A986RepresentanteEmail ,
                                             string A997RepresentanteMunicipioNome ,
                                             int A168ClienteId ,
                                             int AV67ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[45];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.RepresentanteProfissao AS RepresentanteProfissao, T1.RepresentanteMunicipio AS RepresentanteMunicipio, T1.ClienteId, T1.RepresentanteOrgaoExpedidor, T3.MunicipioNome AS RepresentanteMunicipioNome, T1.RepresentanteTipo, T1.RepresentanteEmail, T2.ProfissaoNome AS RepresentanteProfissaoDescricao, T1.RepresentanteNacionalidade, T1.RepresentanteEstadoCivil, T1.RepresentanteCPF, T1.RepresentanteRGUF, T1.RepresentanteRG, T1.RepresentanteNome, T1.RepresentanteId FROM ((Representante T1 LEFT JOIN Profissao T2 ON T2.ProfissaoId = T1.RepresentanteProfissao) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.RepresentanteMunicipio)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV67ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Representantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.RepresentanteNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRG like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteOrgaoExpedidor like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRGUF like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteCPF like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'solteiro(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SOLTEIRO')) or ( 'casado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'CASADO')) or ( 'divorciado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'DIVORCIADO')) or ( 'viúvo(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'VIUVO')) or ( 'separado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SEPARADO')) or ( 'união estável' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'UNIAO_ESTAVEL')) or ( T1.RepresentanteNacionalidade like '%' || :lV72Representantewwds_1_filterfulltext) or ( T2.ProfissaoNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteEmail like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'representante' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Representante')) or ( 'responsável solidário' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Responsavel_solidario')))");
         }
         else
         {
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
            GXv_int5[5] = 1;
            GXv_int5[6] = 1;
            GXv_int5[7] = 1;
            GXv_int5[8] = 1;
            GXv_int5[9] = 1;
            GXv_int5[10] = 1;
            GXv_int5[11] = 1;
            GXv_int5[12] = 1;
            GXv_int5[13] = 1;
            GXv_int5[14] = 1;
            GXv_int5[15] = 1;
            GXv_int5[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV87Representantewwds_16_tfrepresentantenome)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome = ( :AV88Representantewwds_17_tfrepresentantenome_sel))");
         }
         else
         {
            GXv_int5[30] = 1;
         }
         if ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG like :lV89Representantewwds_18_tfrepresentanterg)");
         }
         else
         {
            GXv_int5[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ! ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG = ( :AV90Representantewwds_19_tfrepresentanterg_sel))");
         }
         else
         {
            GXv_int5[32] = 1;
         }
         if ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRG))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor like :lV91Representantewwds_20_tfrepresentanteorgaoexpedidor)");
         }
         else
         {
            GXv_int5[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ! ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor = ( :AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel))");
         }
         else
         {
            GXv_int5[34] = 1;
         }
         if ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteOrgaoExpedidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF like :lV93Representantewwds_22_tfrepresentanterguf)");
         }
         else
         {
            GXv_int5[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ! ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF = ( :AV94Representantewwds_23_tfrepresentanterguf_sel))");
         }
         else
         {
            GXv_int5[36] = 1;
         }
         if ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRGUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF like :lV95Representantewwds_24_tfrepresentantecpf)");
         }
         else
         {
            GXv_int5[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ! ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF = ( :AV96Representantewwds_25_tfrepresentantecpf_sel))");
         }
         else
         {
            GXv_int5[38] = 1;
         }
         if ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteCPF))=0))");
         }
         if ( AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV97Representantewwds_26_tfrepresentanteestadocivil_sels, "T1.RepresentanteEstadoCivil IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade like :lV98Representantewwds_27_tfrepresentantenacionalidade)");
         }
         else
         {
            GXv_int5[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ! ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade = ( :AV99Representantewwds_28_tfrepresentantenacionalidade_sel))");
         }
         else
         {
            GXv_int5[40] = 1;
         }
         if ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNacionalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome like :lV100Representantewwds_29_tfrepresentanteprofissaodescricao)");
         }
         else
         {
            GXv_int5[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ! ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome = ( :AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel))");
         }
         else
         {
            GXv_int5[42] = 1;
         }
         if ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from T2.ProfissaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail like :lV102Representantewwds_31_tfrepresentanteemail)");
         }
         else
         {
            GXv_int5[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail = ( :AV103Representantewwds_32_tfrepresentanteemail_sel))");
         }
         else
         {
            GXv_int5[44] = 1;
         }
         if ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteEmail))=0))");
         }
         if ( AV104Representantewwds_33_tfrepresentantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV104Representantewwds_33_tfrepresentantetipo_sels, "T1.RepresentanteTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.RepresentanteOrgaoExpedidor";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00EX5( IGxContext context ,
                                             string A984RepresentanteEstadoCivil ,
                                             GxSimpleCollection<string> AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                             string A998RepresentanteTipo ,
                                             GxSimpleCollection<string> AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                             string AV72Representantewwds_1_filterfulltext ,
                                             string AV73Representantewwds_2_dynamicfiltersselector1 ,
                                             short AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                             string AV75Representantewwds_4_representantenome1 ,
                                             string AV76Representantewwds_5_representantemunicipionome1 ,
                                             bool AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                             string AV78Representantewwds_7_dynamicfiltersselector2 ,
                                             short AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                             string AV80Representantewwds_9_representantenome2 ,
                                             string AV81Representantewwds_10_representantemunicipionome2 ,
                                             bool AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                             string AV83Representantewwds_12_dynamicfiltersselector3 ,
                                             short AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                             string AV85Representantewwds_14_representantenome3 ,
                                             string AV86Representantewwds_15_representantemunicipionome3 ,
                                             string AV88Representantewwds_17_tfrepresentantenome_sel ,
                                             string AV87Representantewwds_16_tfrepresentantenome ,
                                             string AV90Representantewwds_19_tfrepresentanterg_sel ,
                                             string AV89Representantewwds_18_tfrepresentanterg ,
                                             string AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                             string AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                             string AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                             string AV93Representantewwds_22_tfrepresentanterguf ,
                                             string AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                             string AV95Representantewwds_24_tfrepresentantecpf ,
                                             int AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count ,
                                             string AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                             string AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                             string AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                             string AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                             string AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                             string AV102Representantewwds_31_tfrepresentanteemail ,
                                             int AV104Representantewwds_33_tfrepresentantetipo_sels_Count ,
                                             string A979RepresentanteNome ,
                                             string A980RepresentanteRG ,
                                             string A981RepresentanteOrgaoExpedidor ,
                                             string A982RepresentanteRGUF ,
                                             string A983RepresentanteCPF ,
                                             string A985RepresentanteNacionalidade ,
                                             string A999RepresentanteProfissaoDescricao ,
                                             string A986RepresentanteEmail ,
                                             string A997RepresentanteMunicipioNome ,
                                             int A168ClienteId ,
                                             int AV67ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[45];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.RepresentanteProfissao AS RepresentanteProfissao, T1.RepresentanteMunicipio AS RepresentanteMunicipio, T1.ClienteId, T1.RepresentanteRGUF, T3.MunicipioNome AS RepresentanteMunicipioNome, T1.RepresentanteTipo, T1.RepresentanteEmail, T2.ProfissaoNome AS RepresentanteProfissaoDescricao, T1.RepresentanteNacionalidade, T1.RepresentanteEstadoCivil, T1.RepresentanteCPF, T1.RepresentanteOrgaoExpedidor, T1.RepresentanteRG, T1.RepresentanteNome, T1.RepresentanteId FROM ((Representante T1 LEFT JOIN Profissao T2 ON T2.ProfissaoId = T1.RepresentanteProfissao) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.RepresentanteMunicipio)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV67ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Representantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.RepresentanteNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRG like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteOrgaoExpedidor like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRGUF like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteCPF like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'solteiro(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SOLTEIRO')) or ( 'casado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'CASADO')) or ( 'divorciado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'DIVORCIADO')) or ( 'viúvo(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'VIUVO')) or ( 'separado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SEPARADO')) or ( 'união estável' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'UNIAO_ESTAVEL')) or ( T1.RepresentanteNacionalidade like '%' || :lV72Representantewwds_1_filterfulltext) or ( T2.ProfissaoNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteEmail like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'representante' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Representante')) or ( 'responsável solidário' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Responsavel_solidario')))");
         }
         else
         {
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
            GXv_int7[4] = 1;
            GXv_int7[5] = 1;
            GXv_int7[6] = 1;
            GXv_int7[7] = 1;
            GXv_int7[8] = 1;
            GXv_int7[9] = 1;
            GXv_int7[10] = 1;
            GXv_int7[11] = 1;
            GXv_int7[12] = 1;
            GXv_int7[13] = 1;
            GXv_int7[14] = 1;
            GXv_int7[15] = 1;
            GXv_int7[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV87Representantewwds_16_tfrepresentantenome)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome = ( :AV88Representantewwds_17_tfrepresentantenome_sel))");
         }
         else
         {
            GXv_int7[30] = 1;
         }
         if ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG like :lV89Representantewwds_18_tfrepresentanterg)");
         }
         else
         {
            GXv_int7[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ! ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG = ( :AV90Representantewwds_19_tfrepresentanterg_sel))");
         }
         else
         {
            GXv_int7[32] = 1;
         }
         if ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRG))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor like :lV91Representantewwds_20_tfrepresentanteorgaoexpedidor)");
         }
         else
         {
            GXv_int7[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ! ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor = ( :AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel))");
         }
         else
         {
            GXv_int7[34] = 1;
         }
         if ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteOrgaoExpedidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF like :lV93Representantewwds_22_tfrepresentanterguf)");
         }
         else
         {
            GXv_int7[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ! ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF = ( :AV94Representantewwds_23_tfrepresentanterguf_sel))");
         }
         else
         {
            GXv_int7[36] = 1;
         }
         if ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRGUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF like :lV95Representantewwds_24_tfrepresentantecpf)");
         }
         else
         {
            GXv_int7[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ! ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF = ( :AV96Representantewwds_25_tfrepresentantecpf_sel))");
         }
         else
         {
            GXv_int7[38] = 1;
         }
         if ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteCPF))=0))");
         }
         if ( AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV97Representantewwds_26_tfrepresentanteestadocivil_sels, "T1.RepresentanteEstadoCivil IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade like :lV98Representantewwds_27_tfrepresentantenacionalidade)");
         }
         else
         {
            GXv_int7[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ! ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade = ( :AV99Representantewwds_28_tfrepresentantenacionalidade_sel))");
         }
         else
         {
            GXv_int7[40] = 1;
         }
         if ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNacionalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome like :lV100Representantewwds_29_tfrepresentanteprofissaodescricao)");
         }
         else
         {
            GXv_int7[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ! ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome = ( :AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel))");
         }
         else
         {
            GXv_int7[42] = 1;
         }
         if ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from T2.ProfissaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail like :lV102Representantewwds_31_tfrepresentanteemail)");
         }
         else
         {
            GXv_int7[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail = ( :AV103Representantewwds_32_tfrepresentanteemail_sel))");
         }
         else
         {
            GXv_int7[44] = 1;
         }
         if ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteEmail))=0))");
         }
         if ( AV104Representantewwds_33_tfrepresentantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV104Representantewwds_33_tfrepresentantetipo_sels, "T1.RepresentanteTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.RepresentanteRGUF";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00EX6( IGxContext context ,
                                             string A984RepresentanteEstadoCivil ,
                                             GxSimpleCollection<string> AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                             string A998RepresentanteTipo ,
                                             GxSimpleCollection<string> AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                             string AV72Representantewwds_1_filterfulltext ,
                                             string AV73Representantewwds_2_dynamicfiltersselector1 ,
                                             short AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                             string AV75Representantewwds_4_representantenome1 ,
                                             string AV76Representantewwds_5_representantemunicipionome1 ,
                                             bool AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                             string AV78Representantewwds_7_dynamicfiltersselector2 ,
                                             short AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                             string AV80Representantewwds_9_representantenome2 ,
                                             string AV81Representantewwds_10_representantemunicipionome2 ,
                                             bool AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                             string AV83Representantewwds_12_dynamicfiltersselector3 ,
                                             short AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                             string AV85Representantewwds_14_representantenome3 ,
                                             string AV86Representantewwds_15_representantemunicipionome3 ,
                                             string AV88Representantewwds_17_tfrepresentantenome_sel ,
                                             string AV87Representantewwds_16_tfrepresentantenome ,
                                             string AV90Representantewwds_19_tfrepresentanterg_sel ,
                                             string AV89Representantewwds_18_tfrepresentanterg ,
                                             string AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                             string AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                             string AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                             string AV93Representantewwds_22_tfrepresentanterguf ,
                                             string AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                             string AV95Representantewwds_24_tfrepresentantecpf ,
                                             int AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count ,
                                             string AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                             string AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                             string AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                             string AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                             string AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                             string AV102Representantewwds_31_tfrepresentanteemail ,
                                             int AV104Representantewwds_33_tfrepresentantetipo_sels_Count ,
                                             string A979RepresentanteNome ,
                                             string A980RepresentanteRG ,
                                             string A981RepresentanteOrgaoExpedidor ,
                                             string A982RepresentanteRGUF ,
                                             string A983RepresentanteCPF ,
                                             string A985RepresentanteNacionalidade ,
                                             string A999RepresentanteProfissaoDescricao ,
                                             string A986RepresentanteEmail ,
                                             string A997RepresentanteMunicipioNome ,
                                             int A168ClienteId ,
                                             int AV67ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[45];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.RepresentanteProfissao AS RepresentanteProfissao, T1.RepresentanteMunicipio AS RepresentanteMunicipio, T1.ClienteId, T1.RepresentanteCPF, T3.MunicipioNome AS RepresentanteMunicipioNome, T1.RepresentanteTipo, T1.RepresentanteEmail, T2.ProfissaoNome AS RepresentanteProfissaoDescricao, T1.RepresentanteNacionalidade, T1.RepresentanteEstadoCivil, T1.RepresentanteRGUF, T1.RepresentanteOrgaoExpedidor, T1.RepresentanteRG, T1.RepresentanteNome, T1.RepresentanteId FROM ((Representante T1 LEFT JOIN Profissao T2 ON T2.ProfissaoId = T1.RepresentanteProfissao) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.RepresentanteMunicipio)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV67ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Representantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.RepresentanteNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRG like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteOrgaoExpedidor like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRGUF like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteCPF like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'solteiro(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SOLTEIRO')) or ( 'casado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'CASADO')) or ( 'divorciado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'DIVORCIADO')) or ( 'viúvo(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'VIUVO')) or ( 'separado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SEPARADO')) or ( 'união estável' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'UNIAO_ESTAVEL')) or ( T1.RepresentanteNacionalidade like '%' || :lV72Representantewwds_1_filterfulltext) or ( T2.ProfissaoNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteEmail like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'representante' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Representante')) or ( 'responsável solidário' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Responsavel_solidario')))");
         }
         else
         {
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
            GXv_int9[4] = 1;
            GXv_int9[5] = 1;
            GXv_int9[6] = 1;
            GXv_int9[7] = 1;
            GXv_int9[8] = 1;
            GXv_int9[9] = 1;
            GXv_int9[10] = 1;
            GXv_int9[11] = 1;
            GXv_int9[12] = 1;
            GXv_int9[13] = 1;
            GXv_int9[14] = 1;
            GXv_int9[15] = 1;
            GXv_int9[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV87Representantewwds_16_tfrepresentantenome)");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome = ( :AV88Representantewwds_17_tfrepresentantenome_sel))");
         }
         else
         {
            GXv_int9[30] = 1;
         }
         if ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG like :lV89Representantewwds_18_tfrepresentanterg)");
         }
         else
         {
            GXv_int9[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ! ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG = ( :AV90Representantewwds_19_tfrepresentanterg_sel))");
         }
         else
         {
            GXv_int9[32] = 1;
         }
         if ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRG))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor like :lV91Representantewwds_20_tfrepresentanteorgaoexpedidor)");
         }
         else
         {
            GXv_int9[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ! ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor = ( :AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel))");
         }
         else
         {
            GXv_int9[34] = 1;
         }
         if ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteOrgaoExpedidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF like :lV93Representantewwds_22_tfrepresentanterguf)");
         }
         else
         {
            GXv_int9[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ! ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF = ( :AV94Representantewwds_23_tfrepresentanterguf_sel))");
         }
         else
         {
            GXv_int9[36] = 1;
         }
         if ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRGUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF like :lV95Representantewwds_24_tfrepresentantecpf)");
         }
         else
         {
            GXv_int9[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ! ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF = ( :AV96Representantewwds_25_tfrepresentantecpf_sel))");
         }
         else
         {
            GXv_int9[38] = 1;
         }
         if ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteCPF))=0))");
         }
         if ( AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV97Representantewwds_26_tfrepresentanteestadocivil_sels, "T1.RepresentanteEstadoCivil IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade like :lV98Representantewwds_27_tfrepresentantenacionalidade)");
         }
         else
         {
            GXv_int9[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ! ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade = ( :AV99Representantewwds_28_tfrepresentantenacionalidade_sel))");
         }
         else
         {
            GXv_int9[40] = 1;
         }
         if ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNacionalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome like :lV100Representantewwds_29_tfrepresentanteprofissaodescricao)");
         }
         else
         {
            GXv_int9[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ! ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome = ( :AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel))");
         }
         else
         {
            GXv_int9[42] = 1;
         }
         if ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from T2.ProfissaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail like :lV102Representantewwds_31_tfrepresentanteemail)");
         }
         else
         {
            GXv_int9[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail = ( :AV103Representantewwds_32_tfrepresentanteemail_sel))");
         }
         else
         {
            GXv_int9[44] = 1;
         }
         if ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteEmail))=0))");
         }
         if ( AV104Representantewwds_33_tfrepresentantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV104Representantewwds_33_tfrepresentantetipo_sels, "T1.RepresentanteTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.RepresentanteCPF";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00EX7( IGxContext context ,
                                             string A984RepresentanteEstadoCivil ,
                                             GxSimpleCollection<string> AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                             string A998RepresentanteTipo ,
                                             GxSimpleCollection<string> AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                             string AV72Representantewwds_1_filterfulltext ,
                                             string AV73Representantewwds_2_dynamicfiltersselector1 ,
                                             short AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                             string AV75Representantewwds_4_representantenome1 ,
                                             string AV76Representantewwds_5_representantemunicipionome1 ,
                                             bool AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                             string AV78Representantewwds_7_dynamicfiltersselector2 ,
                                             short AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                             string AV80Representantewwds_9_representantenome2 ,
                                             string AV81Representantewwds_10_representantemunicipionome2 ,
                                             bool AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                             string AV83Representantewwds_12_dynamicfiltersselector3 ,
                                             short AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                             string AV85Representantewwds_14_representantenome3 ,
                                             string AV86Representantewwds_15_representantemunicipionome3 ,
                                             string AV88Representantewwds_17_tfrepresentantenome_sel ,
                                             string AV87Representantewwds_16_tfrepresentantenome ,
                                             string AV90Representantewwds_19_tfrepresentanterg_sel ,
                                             string AV89Representantewwds_18_tfrepresentanterg ,
                                             string AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                             string AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                             string AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                             string AV93Representantewwds_22_tfrepresentanterguf ,
                                             string AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                             string AV95Representantewwds_24_tfrepresentantecpf ,
                                             int AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count ,
                                             string AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                             string AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                             string AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                             string AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                             string AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                             string AV102Representantewwds_31_tfrepresentanteemail ,
                                             int AV104Representantewwds_33_tfrepresentantetipo_sels_Count ,
                                             string A979RepresentanteNome ,
                                             string A980RepresentanteRG ,
                                             string A981RepresentanteOrgaoExpedidor ,
                                             string A982RepresentanteRGUF ,
                                             string A983RepresentanteCPF ,
                                             string A985RepresentanteNacionalidade ,
                                             string A999RepresentanteProfissaoDescricao ,
                                             string A986RepresentanteEmail ,
                                             string A997RepresentanteMunicipioNome ,
                                             int A168ClienteId ,
                                             int AV67ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[45];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.RepresentanteProfissao AS RepresentanteProfissao, T1.RepresentanteMunicipio AS RepresentanteMunicipio, T1.ClienteId, T1.RepresentanteNacionalidade, T3.MunicipioNome AS RepresentanteMunicipioNome, T1.RepresentanteTipo, T1.RepresentanteEmail, T2.ProfissaoNome AS RepresentanteProfissaoDescricao, T1.RepresentanteEstadoCivil, T1.RepresentanteCPF, T1.RepresentanteRGUF, T1.RepresentanteOrgaoExpedidor, T1.RepresentanteRG, T1.RepresentanteNome, T1.RepresentanteId FROM ((Representante T1 LEFT JOIN Profissao T2 ON T2.ProfissaoId = T1.RepresentanteProfissao) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.RepresentanteMunicipio)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV67ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Representantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.RepresentanteNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRG like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteOrgaoExpedidor like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRGUF like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteCPF like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'solteiro(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SOLTEIRO')) or ( 'casado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'CASADO')) or ( 'divorciado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'DIVORCIADO')) or ( 'viúvo(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'VIUVO')) or ( 'separado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SEPARADO')) or ( 'união estável' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'UNIAO_ESTAVEL')) or ( T1.RepresentanteNacionalidade like '%' || :lV72Representantewwds_1_filterfulltext) or ( T2.ProfissaoNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteEmail like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'representante' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Representante')) or ( 'responsável solidário' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Responsavel_solidario')))");
         }
         else
         {
            GXv_int11[1] = 1;
            GXv_int11[2] = 1;
            GXv_int11[3] = 1;
            GXv_int11[4] = 1;
            GXv_int11[5] = 1;
            GXv_int11[6] = 1;
            GXv_int11[7] = 1;
            GXv_int11[8] = 1;
            GXv_int11[9] = 1;
            GXv_int11[10] = 1;
            GXv_int11[11] = 1;
            GXv_int11[12] = 1;
            GXv_int11[13] = 1;
            GXv_int11[14] = 1;
            GXv_int11[15] = 1;
            GXv_int11[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int11[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int11[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int11[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int11[20] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int11[21] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int11[22] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int11[23] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int11[24] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int11[25] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int11[26] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int11[27] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int11[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV87Representantewwds_16_tfrepresentantenome)");
         }
         else
         {
            GXv_int11[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome = ( :AV88Representantewwds_17_tfrepresentantenome_sel))");
         }
         else
         {
            GXv_int11[30] = 1;
         }
         if ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG like :lV89Representantewwds_18_tfrepresentanterg)");
         }
         else
         {
            GXv_int11[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ! ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG = ( :AV90Representantewwds_19_tfrepresentanterg_sel))");
         }
         else
         {
            GXv_int11[32] = 1;
         }
         if ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRG))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor like :lV91Representantewwds_20_tfrepresentanteorgaoexpedidor)");
         }
         else
         {
            GXv_int11[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ! ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor = ( :AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel))");
         }
         else
         {
            GXv_int11[34] = 1;
         }
         if ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteOrgaoExpedidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF like :lV93Representantewwds_22_tfrepresentanterguf)");
         }
         else
         {
            GXv_int11[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ! ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF = ( :AV94Representantewwds_23_tfrepresentanterguf_sel))");
         }
         else
         {
            GXv_int11[36] = 1;
         }
         if ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRGUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF like :lV95Representantewwds_24_tfrepresentantecpf)");
         }
         else
         {
            GXv_int11[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ! ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF = ( :AV96Representantewwds_25_tfrepresentantecpf_sel))");
         }
         else
         {
            GXv_int11[38] = 1;
         }
         if ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteCPF))=0))");
         }
         if ( AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV97Representantewwds_26_tfrepresentanteestadocivil_sels, "T1.RepresentanteEstadoCivil IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade like :lV98Representantewwds_27_tfrepresentantenacionalidade)");
         }
         else
         {
            GXv_int11[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ! ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade = ( :AV99Representantewwds_28_tfrepresentantenacionalidade_sel))");
         }
         else
         {
            GXv_int11[40] = 1;
         }
         if ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNacionalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome like :lV100Representantewwds_29_tfrepresentanteprofissaodescricao)");
         }
         else
         {
            GXv_int11[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ! ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome = ( :AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel))");
         }
         else
         {
            GXv_int11[42] = 1;
         }
         if ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from T2.ProfissaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail like :lV102Representantewwds_31_tfrepresentanteemail)");
         }
         else
         {
            GXv_int11[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail = ( :AV103Representantewwds_32_tfrepresentanteemail_sel))");
         }
         else
         {
            GXv_int11[44] = 1;
         }
         if ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteEmail))=0))");
         }
         if ( AV104Representantewwds_33_tfrepresentantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV104Representantewwds_33_tfrepresentantetipo_sels, "T1.RepresentanteTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.RepresentanteNacionalidade";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      protected Object[] conditional_P00EX8( IGxContext context ,
                                             string A984RepresentanteEstadoCivil ,
                                             GxSimpleCollection<string> AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                             string A998RepresentanteTipo ,
                                             GxSimpleCollection<string> AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                             string AV72Representantewwds_1_filterfulltext ,
                                             string AV73Representantewwds_2_dynamicfiltersselector1 ,
                                             short AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                             string AV75Representantewwds_4_representantenome1 ,
                                             string AV76Representantewwds_5_representantemunicipionome1 ,
                                             bool AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                             string AV78Representantewwds_7_dynamicfiltersselector2 ,
                                             short AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                             string AV80Representantewwds_9_representantenome2 ,
                                             string AV81Representantewwds_10_representantemunicipionome2 ,
                                             bool AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                             string AV83Representantewwds_12_dynamicfiltersselector3 ,
                                             short AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                             string AV85Representantewwds_14_representantenome3 ,
                                             string AV86Representantewwds_15_representantemunicipionome3 ,
                                             string AV88Representantewwds_17_tfrepresentantenome_sel ,
                                             string AV87Representantewwds_16_tfrepresentantenome ,
                                             string AV90Representantewwds_19_tfrepresentanterg_sel ,
                                             string AV89Representantewwds_18_tfrepresentanterg ,
                                             string AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                             string AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                             string AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                             string AV93Representantewwds_22_tfrepresentanterguf ,
                                             string AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                             string AV95Representantewwds_24_tfrepresentantecpf ,
                                             int AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count ,
                                             string AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                             string AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                             string AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                             string AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                             string AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                             string AV102Representantewwds_31_tfrepresentanteemail ,
                                             int AV104Representantewwds_33_tfrepresentantetipo_sels_Count ,
                                             string A979RepresentanteNome ,
                                             string A980RepresentanteRG ,
                                             string A981RepresentanteOrgaoExpedidor ,
                                             string A982RepresentanteRGUF ,
                                             string A983RepresentanteCPF ,
                                             string A985RepresentanteNacionalidade ,
                                             string A999RepresentanteProfissaoDescricao ,
                                             string A986RepresentanteEmail ,
                                             string A997RepresentanteMunicipioNome ,
                                             int A168ClienteId ,
                                             int AV67ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int13 = new short[45];
         Object[] GXv_Object14 = new Object[2];
         scmdbuf = "SELECT T1.RepresentanteMunicipio AS RepresentanteMunicipio, T1.RepresentanteProfissao AS RepresentanteProfissao, T1.ClienteId, T2.MunicipioNome AS RepresentanteMunicipioNome, T1.RepresentanteTipo, T1.RepresentanteEmail, T3.ProfissaoNome AS RepresentanteProfissaoDescricao, T1.RepresentanteNacionalidade, T1.RepresentanteEstadoCivil, T1.RepresentanteCPF, T1.RepresentanteRGUF, T1.RepresentanteOrgaoExpedidor, T1.RepresentanteRG, T1.RepresentanteNome, T1.RepresentanteId FROM ((Representante T1 LEFT JOIN Municipio T2 ON T2.MunicipioCodigo = T1.RepresentanteMunicipio) LEFT JOIN Profissao T3 ON T3.ProfissaoId = T1.RepresentanteProfissao)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV67ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Representantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.RepresentanteNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRG like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteOrgaoExpedidor like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRGUF like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteCPF like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'solteiro(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SOLTEIRO')) or ( 'casado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'CASADO')) or ( 'divorciado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'DIVORCIADO')) or ( 'viúvo(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'VIUVO')) or ( 'separado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SEPARADO')) or ( 'união estável' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'UNIAO_ESTAVEL')) or ( T1.RepresentanteNacionalidade like '%' || :lV72Representantewwds_1_filterfulltext) or ( T3.ProfissaoNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteEmail like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'representante' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Representante')) or ( 'responsável solidário' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Responsavel_solidario')))");
         }
         else
         {
            GXv_int13[1] = 1;
            GXv_int13[2] = 1;
            GXv_int13[3] = 1;
            GXv_int13[4] = 1;
            GXv_int13[5] = 1;
            GXv_int13[6] = 1;
            GXv_int13[7] = 1;
            GXv_int13[8] = 1;
            GXv_int13[9] = 1;
            GXv_int13[10] = 1;
            GXv_int13[11] = 1;
            GXv_int13[12] = 1;
            GXv_int13[13] = 1;
            GXv_int13[14] = 1;
            GXv_int13[15] = 1;
            GXv_int13[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int13[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int13[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int13[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int13[20] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int13[21] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int13[22] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int13[23] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int13[24] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int13[25] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int13[26] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int13[27] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T2.MunicipioNome like '%' || :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int13[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV87Representantewwds_16_tfrepresentantenome)");
         }
         else
         {
            GXv_int13[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome = ( :AV88Representantewwds_17_tfrepresentantenome_sel))");
         }
         else
         {
            GXv_int13[30] = 1;
         }
         if ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG like :lV89Representantewwds_18_tfrepresentanterg)");
         }
         else
         {
            GXv_int13[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ! ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG = ( :AV90Representantewwds_19_tfrepresentanterg_sel))");
         }
         else
         {
            GXv_int13[32] = 1;
         }
         if ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRG))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor like :lV91Representantewwds_20_tfrepresentanteorgaoexpedidor)");
         }
         else
         {
            GXv_int13[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ! ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor = ( :AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel))");
         }
         else
         {
            GXv_int13[34] = 1;
         }
         if ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteOrgaoExpedidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF like :lV93Representantewwds_22_tfrepresentanterguf)");
         }
         else
         {
            GXv_int13[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ! ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF = ( :AV94Representantewwds_23_tfrepresentanterguf_sel))");
         }
         else
         {
            GXv_int13[36] = 1;
         }
         if ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRGUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF like :lV95Representantewwds_24_tfrepresentantecpf)");
         }
         else
         {
            GXv_int13[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ! ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF = ( :AV96Representantewwds_25_tfrepresentantecpf_sel))");
         }
         else
         {
            GXv_int13[38] = 1;
         }
         if ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteCPF))=0))");
         }
         if ( AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV97Representantewwds_26_tfrepresentanteestadocivil_sels, "T1.RepresentanteEstadoCivil IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade like :lV98Representantewwds_27_tfrepresentantenacionalidade)");
         }
         else
         {
            GXv_int13[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ! ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade = ( :AV99Representantewwds_28_tfrepresentantenacionalidade_sel))");
         }
         else
         {
            GXv_int13[40] = 1;
         }
         if ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNacionalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao)) ) )
         {
            AddWhere(sWhereString, "(T3.ProfissaoNome like :lV100Representantewwds_29_tfrepresentanteprofissaodescricao)");
         }
         else
         {
            GXv_int13[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ! ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ProfissaoNome = ( :AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel))");
         }
         else
         {
            GXv_int13[42] = 1;
         }
         if ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from T3.ProfissaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail like :lV102Representantewwds_31_tfrepresentanteemail)");
         }
         else
         {
            GXv_int13[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail = ( :AV103Representantewwds_32_tfrepresentanteemail_sel))");
         }
         else
         {
            GXv_int13[44] = 1;
         }
         if ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteEmail))=0))");
         }
         if ( AV104Representantewwds_33_tfrepresentantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV104Representantewwds_33_tfrepresentantetipo_sels, "T1.RepresentanteTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.RepresentanteProfissao";
         GXv_Object14[0] = scmdbuf;
         GXv_Object14[1] = GXv_int13;
         return GXv_Object14 ;
      }

      protected Object[] conditional_P00EX9( IGxContext context ,
                                             string A984RepresentanteEstadoCivil ,
                                             GxSimpleCollection<string> AV97Representantewwds_26_tfrepresentanteestadocivil_sels ,
                                             string A998RepresentanteTipo ,
                                             GxSimpleCollection<string> AV104Representantewwds_33_tfrepresentantetipo_sels ,
                                             string AV72Representantewwds_1_filterfulltext ,
                                             string AV73Representantewwds_2_dynamicfiltersselector1 ,
                                             short AV74Representantewwds_3_dynamicfiltersoperator1 ,
                                             string AV75Representantewwds_4_representantenome1 ,
                                             string AV76Representantewwds_5_representantemunicipionome1 ,
                                             bool AV77Representantewwds_6_dynamicfiltersenabled2 ,
                                             string AV78Representantewwds_7_dynamicfiltersselector2 ,
                                             short AV79Representantewwds_8_dynamicfiltersoperator2 ,
                                             string AV80Representantewwds_9_representantenome2 ,
                                             string AV81Representantewwds_10_representantemunicipionome2 ,
                                             bool AV82Representantewwds_11_dynamicfiltersenabled3 ,
                                             string AV83Representantewwds_12_dynamicfiltersselector3 ,
                                             short AV84Representantewwds_13_dynamicfiltersoperator3 ,
                                             string AV85Representantewwds_14_representantenome3 ,
                                             string AV86Representantewwds_15_representantemunicipionome3 ,
                                             string AV88Representantewwds_17_tfrepresentantenome_sel ,
                                             string AV87Representantewwds_16_tfrepresentantenome ,
                                             string AV90Representantewwds_19_tfrepresentanterg_sel ,
                                             string AV89Representantewwds_18_tfrepresentanterg ,
                                             string AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel ,
                                             string AV91Representantewwds_20_tfrepresentanteorgaoexpedidor ,
                                             string AV94Representantewwds_23_tfrepresentanterguf_sel ,
                                             string AV93Representantewwds_22_tfrepresentanterguf ,
                                             string AV96Representantewwds_25_tfrepresentantecpf_sel ,
                                             string AV95Representantewwds_24_tfrepresentantecpf ,
                                             int AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count ,
                                             string AV99Representantewwds_28_tfrepresentantenacionalidade_sel ,
                                             string AV98Representantewwds_27_tfrepresentantenacionalidade ,
                                             string AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel ,
                                             string AV100Representantewwds_29_tfrepresentanteprofissaodescricao ,
                                             string AV103Representantewwds_32_tfrepresentanteemail_sel ,
                                             string AV102Representantewwds_31_tfrepresentanteemail ,
                                             int AV104Representantewwds_33_tfrepresentantetipo_sels_Count ,
                                             string A979RepresentanteNome ,
                                             string A980RepresentanteRG ,
                                             string A981RepresentanteOrgaoExpedidor ,
                                             string A982RepresentanteRGUF ,
                                             string A983RepresentanteCPF ,
                                             string A985RepresentanteNacionalidade ,
                                             string A999RepresentanteProfissaoDescricao ,
                                             string A986RepresentanteEmail ,
                                             string A997RepresentanteMunicipioNome ,
                                             int A168ClienteId ,
                                             int AV67ClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int15 = new short[45];
         Object[] GXv_Object16 = new Object[2];
         scmdbuf = "SELECT T1.RepresentanteProfissao AS RepresentanteProfissao, T1.RepresentanteMunicipio AS RepresentanteMunicipio, T1.ClienteId, T1.RepresentanteEmail, T3.MunicipioNome AS RepresentanteMunicipioNome, T1.RepresentanteTipo, T2.ProfissaoNome AS RepresentanteProfissaoDescricao, T1.RepresentanteNacionalidade, T1.RepresentanteEstadoCivil, T1.RepresentanteCPF, T1.RepresentanteRGUF, T1.RepresentanteOrgaoExpedidor, T1.RepresentanteRG, T1.RepresentanteNome, T1.RepresentanteId FROM ((Representante T1 LEFT JOIN Profissao T2 ON T2.ProfissaoId = T1.RepresentanteProfissao) LEFT JOIN Municipio T3 ON T3.MunicipioCodigo = T1.RepresentanteMunicipio)";
         AddWhere(sWhereString, "(T1.ClienteId = :AV67ClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Representantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.RepresentanteNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRG like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteOrgaoExpedidor like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteRGUF like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteCPF like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'solteiro(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SOLTEIRO')) or ( 'casado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'CASADO')) or ( 'divorciado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'DIVORCIADO')) or ( 'viúvo(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'VIUVO')) or ( 'separado(a)' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'SEPARADO')) or ( 'união estável' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteEstadoCivil = ( 'UNIAO_ESTAVEL')) or ( T1.RepresentanteNacionalidade like '%' || :lV72Representantewwds_1_filterfulltext) or ( T2.ProfissaoNome like '%' || :lV72Representantewwds_1_filterfulltext) or ( T1.RepresentanteEmail like '%' || :lV72Representantewwds_1_filterfulltext) or ( 'representante' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Representante')) or ( 'responsável solidário' like '%' || LOWER(:lV72Representantewwds_1_filterfulltext) and T1.RepresentanteTipo = ( 'Responsavel_solidario')))");
         }
         else
         {
            GXv_int15[1] = 1;
            GXv_int15[2] = 1;
            GXv_int15[3] = 1;
            GXv_int15[4] = 1;
            GXv_int15[5] = 1;
            GXv_int15[6] = 1;
            GXv_int15[7] = 1;
            GXv_int15[8] = 1;
            GXv_int15[9] = 1;
            GXv_int15[10] = 1;
            GXv_int15[11] = 1;
            GXv_int15[12] = 1;
            GXv_int15[13] = 1;
            GXv_int15[14] = 1;
            GXv_int15[15] = 1;
            GXv_int15[16] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int15[17] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTENOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Representantewwds_4_representantenome1)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV75Representantewwds_4_representantenome1)");
         }
         else
         {
            GXv_int15[18] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int15[19] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Representantewwds_2_dynamicfiltersselector1, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV74Representantewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Representantewwds_5_representantemunicipionome1)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV76Representantewwds_5_representantemunicipionome1)");
         }
         else
         {
            GXv_int15[20] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int15[21] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTENOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Representantewwds_9_representantenome2)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV80Representantewwds_9_representantenome2)");
         }
         else
         {
            GXv_int15[22] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int15[23] = 1;
         }
         if ( AV77Representantewwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Representantewwds_7_dynamicfiltersselector2, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV79Representantewwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Representantewwds_10_representantemunicipionome2)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV81Representantewwds_10_representantemunicipionome2)");
         }
         else
         {
            GXv_int15[24] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int15[25] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTENOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Representantewwds_14_representantenome3)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like '%' || :lV85Representantewwds_14_representantenome3)");
         }
         else
         {
            GXv_int15[26] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int15[27] = 1;
         }
         if ( AV82Representantewwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Representantewwds_12_dynamicfiltersselector3, "REPRESENTANTEMUNICIPIONOME") == 0 ) && ( AV84Representantewwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Representantewwds_15_representantemunicipionome3)) ) )
         {
            AddWhere(sWhereString, "(T3.MunicipioNome like '%' || :lV86Representantewwds_15_representantemunicipionome3)");
         }
         else
         {
            GXv_int15[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Representantewwds_16_tfrepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome like :lV87Representantewwds_16_tfrepresentantenome)");
         }
         else
         {
            GXv_int15[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Representantewwds_17_tfrepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome = ( :AV88Representantewwds_17_tfrepresentantenome_sel))");
         }
         else
         {
            GXv_int15[30] = 1;
         }
         if ( StringUtil.StrCmp(AV88Representantewwds_17_tfrepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNome IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Representantewwds_18_tfrepresentanterg)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG like :lV89Representantewwds_18_tfrepresentanterg)");
         }
         else
         {
            GXv_int15[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Representantewwds_19_tfrepresentanterg_sel)) && ! ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG = ( :AV90Representantewwds_19_tfrepresentanterg_sel))");
         }
         else
         {
            GXv_int15[32] = 1;
         }
         if ( StringUtil.StrCmp(AV90Representantewwds_19_tfrepresentanterg_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRG IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRG))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Representantewwds_20_tfrepresentanteorgaoexpedidor)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor like :lV91Representantewwds_20_tfrepresentanteorgaoexpedidor)");
         }
         else
         {
            GXv_int15[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel)) && ! ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor = ( :AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel))");
         }
         else
         {
            GXv_int15[34] = 1;
         }
         if ( StringUtil.StrCmp(AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteOrgaoExpedidor IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteOrgaoExpedidor))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Representantewwds_22_tfrepresentanterguf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF like :lV93Representantewwds_22_tfrepresentanterguf)");
         }
         else
         {
            GXv_int15[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Representantewwds_23_tfrepresentanterguf_sel)) && ! ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF = ( :AV94Representantewwds_23_tfrepresentanterguf_sel))");
         }
         else
         {
            GXv_int15[36] = 1;
         }
         if ( StringUtil.StrCmp(AV94Representantewwds_23_tfrepresentanterguf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteRGUF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteRGUF))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Representantewwds_24_tfrepresentantecpf)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF like :lV95Representantewwds_24_tfrepresentantecpf)");
         }
         else
         {
            GXv_int15[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Representantewwds_25_tfrepresentantecpf_sel)) && ! ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF = ( :AV96Representantewwds_25_tfrepresentantecpf_sel))");
         }
         else
         {
            GXv_int15[38] = 1;
         }
         if ( StringUtil.StrCmp(AV96Representantewwds_25_tfrepresentantecpf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteCPF IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteCPF))=0))");
         }
         if ( AV97Representantewwds_26_tfrepresentanteestadocivil_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV97Representantewwds_26_tfrepresentanteestadocivil_sels, "T1.RepresentanteEstadoCivil IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Representantewwds_27_tfrepresentantenacionalidade)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade like :lV98Representantewwds_27_tfrepresentantenacionalidade)");
         }
         else
         {
            GXv_int15[39] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Representantewwds_28_tfrepresentantenacionalidade_sel)) && ! ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade = ( :AV99Representantewwds_28_tfrepresentantenacionalidade_sel))");
         }
         else
         {
            GXv_int15[40] = 1;
         }
         if ( StringUtil.StrCmp(AV99Representantewwds_28_tfrepresentantenacionalidade_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteNacionalidade IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteNacionalidade))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Representantewwds_29_tfrepresentanteprofissaodescricao)) ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome like :lV100Representantewwds_29_tfrepresentanteprofissaodescricao)");
         }
         else
         {
            GXv_int15[41] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel)) && ! ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome = ( :AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel))");
         }
         else
         {
            GXv_int15[42] = 1;
         }
         if ( StringUtil.StrCmp(AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ProfissaoNome IS NULL or (char_length(trim(trailing ' ' from T2.ProfissaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Representantewwds_31_tfrepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail like :lV102Representantewwds_31_tfrepresentanteemail)");
         }
         else
         {
            GXv_int15[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Representantewwds_32_tfrepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail = ( :AV103Representantewwds_32_tfrepresentanteemail_sel))");
         }
         else
         {
            GXv_int15[44] = 1;
         }
         if ( StringUtil.StrCmp(AV103Representantewwds_32_tfrepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.RepresentanteEmail IS NULL or (char_length(trim(trailing ' ' from T1.RepresentanteEmail))=0))");
         }
         if ( AV104Representantewwds_33_tfrepresentantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV104Representantewwds_33_tfrepresentantetipo_sels, "T1.RepresentanteTipo IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.RepresentanteEmail";
         GXv_Object16[0] = scmdbuf;
         GXv_Object16[1] = GXv_int15;
         return GXv_Object16 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00EX2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (int)dynConstraints[46] , (int)dynConstraints[47] );
               case 1 :
                     return conditional_P00EX3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (int)dynConstraints[46] , (int)dynConstraints[47] );
               case 2 :
                     return conditional_P00EX4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (int)dynConstraints[46] , (int)dynConstraints[47] );
               case 3 :
                     return conditional_P00EX5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (int)dynConstraints[46] , (int)dynConstraints[47] );
               case 4 :
                     return conditional_P00EX6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (int)dynConstraints[46] , (int)dynConstraints[47] );
               case 5 :
                     return conditional_P00EX7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (int)dynConstraints[46] , (int)dynConstraints[47] );
               case 6 :
                     return conditional_P00EX8(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (int)dynConstraints[46] , (int)dynConstraints[47] );
               case 7 :
                     return conditional_P00EX9(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (int)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (int)dynConstraints[46] , (int)dynConstraints[47] );
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
         ,new ForEachCursor(def[7])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00EX2;
          prmP00EX2 = new Object[] {
          new ParDef("AV67ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV87Representantewwds_16_tfrepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV88Representantewwds_17_tfrepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Representantewwds_18_tfrepresentanterg",GXType.VarChar,40,0) ,
          new ParDef("AV90Representantewwds_19_tfrepresentanterg_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Representantewwds_20_tfrepresentanteorgaoexpedidor",GXType.VarChar,40,0) ,
          new ParDef("AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel",GXType.VarChar,40,0) ,
          new ParDef("lV93Representantewwds_22_tfrepresentanterguf",GXType.VarChar,40,0) ,
          new ParDef("AV94Representantewwds_23_tfrepresentanterguf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV95Representantewwds_24_tfrepresentantecpf",GXType.VarChar,40,0) ,
          new ParDef("AV96Representantewwds_25_tfrepresentantecpf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV98Representantewwds_27_tfrepresentantenacionalidade",GXType.VarChar,60,0) ,
          new ParDef("AV99Representantewwds_28_tfrepresentantenacionalidade_sel",GXType.VarChar,60,0) ,
          new ParDef("lV100Representantewwds_29_tfrepresentanteprofissaodescricao",GXType.VarChar,90,0) ,
          new ParDef("AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel",GXType.VarChar,90,0) ,
          new ParDef("lV102Representantewwds_31_tfrepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV103Representantewwds_32_tfrepresentanteemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00EX3;
          prmP00EX3 = new Object[] {
          new ParDef("AV67ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV87Representantewwds_16_tfrepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV88Representantewwds_17_tfrepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Representantewwds_18_tfrepresentanterg",GXType.VarChar,40,0) ,
          new ParDef("AV90Representantewwds_19_tfrepresentanterg_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Representantewwds_20_tfrepresentanteorgaoexpedidor",GXType.VarChar,40,0) ,
          new ParDef("AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel",GXType.VarChar,40,0) ,
          new ParDef("lV93Representantewwds_22_tfrepresentanterguf",GXType.VarChar,40,0) ,
          new ParDef("AV94Representantewwds_23_tfrepresentanterguf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV95Representantewwds_24_tfrepresentantecpf",GXType.VarChar,40,0) ,
          new ParDef("AV96Representantewwds_25_tfrepresentantecpf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV98Representantewwds_27_tfrepresentantenacionalidade",GXType.VarChar,60,0) ,
          new ParDef("AV99Representantewwds_28_tfrepresentantenacionalidade_sel",GXType.VarChar,60,0) ,
          new ParDef("lV100Representantewwds_29_tfrepresentanteprofissaodescricao",GXType.VarChar,90,0) ,
          new ParDef("AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel",GXType.VarChar,90,0) ,
          new ParDef("lV102Representantewwds_31_tfrepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV103Representantewwds_32_tfrepresentanteemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00EX4;
          prmP00EX4 = new Object[] {
          new ParDef("AV67ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV87Representantewwds_16_tfrepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV88Representantewwds_17_tfrepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Representantewwds_18_tfrepresentanterg",GXType.VarChar,40,0) ,
          new ParDef("AV90Representantewwds_19_tfrepresentanterg_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Representantewwds_20_tfrepresentanteorgaoexpedidor",GXType.VarChar,40,0) ,
          new ParDef("AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel",GXType.VarChar,40,0) ,
          new ParDef("lV93Representantewwds_22_tfrepresentanterguf",GXType.VarChar,40,0) ,
          new ParDef("AV94Representantewwds_23_tfrepresentanterguf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV95Representantewwds_24_tfrepresentantecpf",GXType.VarChar,40,0) ,
          new ParDef("AV96Representantewwds_25_tfrepresentantecpf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV98Representantewwds_27_tfrepresentantenacionalidade",GXType.VarChar,60,0) ,
          new ParDef("AV99Representantewwds_28_tfrepresentantenacionalidade_sel",GXType.VarChar,60,0) ,
          new ParDef("lV100Representantewwds_29_tfrepresentanteprofissaodescricao",GXType.VarChar,90,0) ,
          new ParDef("AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel",GXType.VarChar,90,0) ,
          new ParDef("lV102Representantewwds_31_tfrepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV103Representantewwds_32_tfrepresentanteemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00EX5;
          prmP00EX5 = new Object[] {
          new ParDef("AV67ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV87Representantewwds_16_tfrepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV88Representantewwds_17_tfrepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Representantewwds_18_tfrepresentanterg",GXType.VarChar,40,0) ,
          new ParDef("AV90Representantewwds_19_tfrepresentanterg_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Representantewwds_20_tfrepresentanteorgaoexpedidor",GXType.VarChar,40,0) ,
          new ParDef("AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel",GXType.VarChar,40,0) ,
          new ParDef("lV93Representantewwds_22_tfrepresentanterguf",GXType.VarChar,40,0) ,
          new ParDef("AV94Representantewwds_23_tfrepresentanterguf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV95Representantewwds_24_tfrepresentantecpf",GXType.VarChar,40,0) ,
          new ParDef("AV96Representantewwds_25_tfrepresentantecpf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV98Representantewwds_27_tfrepresentantenacionalidade",GXType.VarChar,60,0) ,
          new ParDef("AV99Representantewwds_28_tfrepresentantenacionalidade_sel",GXType.VarChar,60,0) ,
          new ParDef("lV100Representantewwds_29_tfrepresentanteprofissaodescricao",GXType.VarChar,90,0) ,
          new ParDef("AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel",GXType.VarChar,90,0) ,
          new ParDef("lV102Representantewwds_31_tfrepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV103Representantewwds_32_tfrepresentanteemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00EX6;
          prmP00EX6 = new Object[] {
          new ParDef("AV67ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV87Representantewwds_16_tfrepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV88Representantewwds_17_tfrepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Representantewwds_18_tfrepresentanterg",GXType.VarChar,40,0) ,
          new ParDef("AV90Representantewwds_19_tfrepresentanterg_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Representantewwds_20_tfrepresentanteorgaoexpedidor",GXType.VarChar,40,0) ,
          new ParDef("AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel",GXType.VarChar,40,0) ,
          new ParDef("lV93Representantewwds_22_tfrepresentanterguf",GXType.VarChar,40,0) ,
          new ParDef("AV94Representantewwds_23_tfrepresentanterguf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV95Representantewwds_24_tfrepresentantecpf",GXType.VarChar,40,0) ,
          new ParDef("AV96Representantewwds_25_tfrepresentantecpf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV98Representantewwds_27_tfrepresentantenacionalidade",GXType.VarChar,60,0) ,
          new ParDef("AV99Representantewwds_28_tfrepresentantenacionalidade_sel",GXType.VarChar,60,0) ,
          new ParDef("lV100Representantewwds_29_tfrepresentanteprofissaodescricao",GXType.VarChar,90,0) ,
          new ParDef("AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel",GXType.VarChar,90,0) ,
          new ParDef("lV102Representantewwds_31_tfrepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV103Representantewwds_32_tfrepresentanteemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00EX7;
          prmP00EX7 = new Object[] {
          new ParDef("AV67ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV87Representantewwds_16_tfrepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV88Representantewwds_17_tfrepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Representantewwds_18_tfrepresentanterg",GXType.VarChar,40,0) ,
          new ParDef("AV90Representantewwds_19_tfrepresentanterg_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Representantewwds_20_tfrepresentanteorgaoexpedidor",GXType.VarChar,40,0) ,
          new ParDef("AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel",GXType.VarChar,40,0) ,
          new ParDef("lV93Representantewwds_22_tfrepresentanterguf",GXType.VarChar,40,0) ,
          new ParDef("AV94Representantewwds_23_tfrepresentanterguf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV95Representantewwds_24_tfrepresentantecpf",GXType.VarChar,40,0) ,
          new ParDef("AV96Representantewwds_25_tfrepresentantecpf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV98Representantewwds_27_tfrepresentantenacionalidade",GXType.VarChar,60,0) ,
          new ParDef("AV99Representantewwds_28_tfrepresentantenacionalidade_sel",GXType.VarChar,60,0) ,
          new ParDef("lV100Representantewwds_29_tfrepresentanteprofissaodescricao",GXType.VarChar,90,0) ,
          new ParDef("AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel",GXType.VarChar,90,0) ,
          new ParDef("lV102Representantewwds_31_tfrepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV103Representantewwds_32_tfrepresentanteemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00EX8;
          prmP00EX8 = new Object[] {
          new ParDef("AV67ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV87Representantewwds_16_tfrepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV88Representantewwds_17_tfrepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Representantewwds_18_tfrepresentanterg",GXType.VarChar,40,0) ,
          new ParDef("AV90Representantewwds_19_tfrepresentanterg_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Representantewwds_20_tfrepresentanteorgaoexpedidor",GXType.VarChar,40,0) ,
          new ParDef("AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel",GXType.VarChar,40,0) ,
          new ParDef("lV93Representantewwds_22_tfrepresentanterguf",GXType.VarChar,40,0) ,
          new ParDef("AV94Representantewwds_23_tfrepresentanterguf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV95Representantewwds_24_tfrepresentantecpf",GXType.VarChar,40,0) ,
          new ParDef("AV96Representantewwds_25_tfrepresentantecpf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV98Representantewwds_27_tfrepresentantenacionalidade",GXType.VarChar,60,0) ,
          new ParDef("AV99Representantewwds_28_tfrepresentantenacionalidade_sel",GXType.VarChar,60,0) ,
          new ParDef("lV100Representantewwds_29_tfrepresentanteprofissaodescricao",GXType.VarChar,90,0) ,
          new ParDef("AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel",GXType.VarChar,90,0) ,
          new ParDef("lV102Representantewwds_31_tfrepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV103Representantewwds_32_tfrepresentanteemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP00EX9;
          prmP00EX9 = new Object[] {
          new ParDef("AV67ClienteId",GXType.Int32,9,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Representantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV75Representantewwds_4_representantenome1",GXType.VarChar,100,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV76Representantewwds_5_representantemunicipionome1",GXType.VarChar,150,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV80Representantewwds_9_representantenome2",GXType.VarChar,100,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV81Representantewwds_10_representantemunicipionome2",GXType.VarChar,150,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV85Representantewwds_14_representantenome3",GXType.VarChar,100,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV86Representantewwds_15_representantemunicipionome3",GXType.VarChar,150,0) ,
          new ParDef("lV87Representantewwds_16_tfrepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV88Representantewwds_17_tfrepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV89Representantewwds_18_tfrepresentanterg",GXType.VarChar,40,0) ,
          new ParDef("AV90Representantewwds_19_tfrepresentanterg_sel",GXType.VarChar,40,0) ,
          new ParDef("lV91Representantewwds_20_tfrepresentanteorgaoexpedidor",GXType.VarChar,40,0) ,
          new ParDef("AV92Representantewwds_21_tfrepresentanteorgaoexpedidor_sel",GXType.VarChar,40,0) ,
          new ParDef("lV93Representantewwds_22_tfrepresentanterguf",GXType.VarChar,40,0) ,
          new ParDef("AV94Representantewwds_23_tfrepresentanterguf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV95Representantewwds_24_tfrepresentantecpf",GXType.VarChar,40,0) ,
          new ParDef("AV96Representantewwds_25_tfrepresentantecpf_sel",GXType.VarChar,40,0) ,
          new ParDef("lV98Representantewwds_27_tfrepresentantenacionalidade",GXType.VarChar,60,0) ,
          new ParDef("AV99Representantewwds_28_tfrepresentantenacionalidade_sel",GXType.VarChar,60,0) ,
          new ParDef("lV100Representantewwds_29_tfrepresentanteprofissaodescricao",GXType.VarChar,90,0) ,
          new ParDef("AV101Representantewwds_30_tfrepresentanteprofissaodescricao_sel",GXType.VarChar,90,0) ,
          new ParDef("lV102Representantewwds_31_tfrepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV103Representantewwds_32_tfrepresentanteemail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EX2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EX2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EX3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EX3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EX4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EX4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EX5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EX5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EX6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EX6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EX7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EX7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EX8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EX8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EX9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EX9,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[4])[0] = rslt.getInt(3);
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((string[]) buf[22])[0] = rslt.getVarchar(12);
                ((bool[]) buf[23])[0] = rslt.wasNull(12);
                ((string[]) buf[24])[0] = rslt.getVarchar(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((string[]) buf[26])[0] = rslt.getVarchar(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                return;
       }
    }

 }

}
