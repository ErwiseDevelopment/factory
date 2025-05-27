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
   public class propostawwgetfilterdata : GXProcedure
   {
      public propostawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostawwgetfilterdata( IGxContext context )
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
         this.AV44DDOName = aP0_DDOName;
         this.AV45SearchTxtParms = aP1_SearchTxtParms;
         this.AV46SearchTxtTo = aP2_SearchTxtTo;
         this.AV47OptionsJson = "" ;
         this.AV48OptionsDescJson = "" ;
         this.AV49OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV47OptionsJson;
         aP4_OptionsDescJson=this.AV48OptionsDescJson;
         aP5_OptionIndexesJson=this.AV49OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV49OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV44DDOName = aP0_DDOName;
         this.AV45SearchTxtParms = aP1_SearchTxtParms;
         this.AV46SearchTxtTo = aP2_SearchTxtTo;
         this.AV47OptionsJson = "" ;
         this.AV48OptionsDescJson = "" ;
         this.AV49OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV47OptionsJson;
         aP4_OptionsDescJson=this.AV48OptionsDescJson;
         aP5_OptionIndexesJson=this.AV49OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV34Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31MaxItems = 10;
         AV30PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV45SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV45SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV28SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV45SearchTxtParms)) ? "" : StringUtil.Substring( AV45SearchTxtParms, 3, -1));
         AV29SkipItems = (short)(AV30PageIndex*AV31MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_PROPOSTACLINICANOME") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTACLINICANOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV44DDOName), "DDO_PROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
         {
            /* Execute user subroutine: 'LOADPROPOSTAPACIENTECLIENTERAZAOSOCIALOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV47OptionsJson = AV34Options.ToJSonString(false);
         AV48OptionsDescJson = AV36OptionsDesc.ToJSonString(false);
         AV49OptionIndexesJson = AV37OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV39Session.Get("PropostaWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PropostaWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("PropostaWWGridState"), null, "", "");
         }
         AV106GXV1 = 1;
         while ( AV106GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV106GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV50FilterFullText = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTACLINICANOME") == 0 )
            {
               AV83TFPropostaClinicaNome = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTACLINICANOME_SEL") == 0 )
            {
               AV84TFPropostaClinicaNome_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTASTATUS_SEL") == 0 )
            {
               AV22TFPropostaStatus_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV23TFPropostaStatus_Sels.FromJSonString(AV22TFPropostaStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL") == 0 )
            {
               AV85TFPropostaPacienteClienteRazaoSocial = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTAPACIENTECLIENTERAZAOSOCIAL_SEL") == 0 )
            {
               AV86TFPropostaPacienteClienteRazaoSocial_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTAMAIORSCORE_F") == 0 )
            {
               AV87TFPropostaMaiorScore_F = (short)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV88TFPropostaMaiorScore_F_To = (short)(Math.Round(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFPROPOSTAMAIORVALORRECOMENDADO") == 0 )
            {
               AV89TFPropostaMaiorValorRecomendado = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, ".");
               AV90TFPropostaMaiorValorRecomendado_To = NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV106GXV1 = (int)(AV106GXV1+1);
         }
         if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(1));
            AV51DynamicFiltersSelector1 = AV43GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV51DynamicFiltersSelector1, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
            {
               AV52DynamicFiltersOperator1 = AV43GridStateDynamicFilter.gxTpr_Operator;
               AV91PropostaMaxReembolsoId_F1 = (int)(Math.Round(NumberUtil.Val( AV43GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV51DynamicFiltersSelector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
            {
               AV52DynamicFiltersOperator1 = AV43GridStateDynamicFilter.gxTpr_Operator;
               AV92PropostaResponsavelDocumento1 = AV43GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51DynamicFiltersSelector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
            {
               AV52DynamicFiltersOperator1 = AV43GridStateDynamicFilter.gxTpr_Operator;
               AV93PropostaPacienteClienteDocumento1 = AV43GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51DynamicFiltersSelector1, "PROPOSTACLINICADOCUMENTO") == 0 )
            {
               AV52DynamicFiltersOperator1 = AV43GridStateDynamicFilter.gxTpr_Operator;
               AV94PropostaClinicaDocumento1 = AV43GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV51DynamicFiltersSelector1, "CONVENIOCATEGORIADESCRICAO") == 0 )
            {
               AV52DynamicFiltersOperator1 = AV43GridStateDynamicFilter.gxTpr_Operator;
               AV95ConvenioCategoriaDescricao1 = AV43GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV54DynamicFiltersEnabled2 = true;
               AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(2));
               AV55DynamicFiltersSelector2 = AV43GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV55DynamicFiltersSelector2, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
               {
                  AV56DynamicFiltersOperator2 = AV43GridStateDynamicFilter.gxTpr_Operator;
                  AV96PropostaMaxReembolsoId_F2 = (int)(Math.Round(NumberUtil.Val( AV43GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
               {
                  AV56DynamicFiltersOperator2 = AV43GridStateDynamicFilter.gxTpr_Operator;
                  AV97PropostaResponsavelDocumento2 = AV43GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
               {
                  AV56DynamicFiltersOperator2 = AV43GridStateDynamicFilter.gxTpr_Operator;
                  AV98PropostaPacienteClienteDocumento2 = AV43GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector2, "PROPOSTACLINICADOCUMENTO") == 0 )
               {
                  AV56DynamicFiltersOperator2 = AV43GridStateDynamicFilter.gxTpr_Operator;
                  AV99PropostaClinicaDocumento2 = AV43GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector2, "CONVENIOCATEGORIADESCRICAO") == 0 )
               {
                  AV56DynamicFiltersOperator2 = AV43GridStateDynamicFilter.gxTpr_Operator;
                  AV100ConvenioCategoriaDescricao2 = AV43GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV58DynamicFiltersEnabled3 = true;
                  AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(3));
                  AV59DynamicFiltersSelector3 = AV43GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "PROPOSTAMAXREEMBOLSOID_F") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV43GridStateDynamicFilter.gxTpr_Operator;
                     AV101PropostaMaxReembolsoId_F3 = (int)(Math.Round(NumberUtil.Val( AV43GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV43GridStateDynamicFilter.gxTpr_Operator;
                     AV102PropostaResponsavelDocumento3 = AV43GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV43GridStateDynamicFilter.gxTpr_Operator;
                     AV103PropostaPacienteClienteDocumento3 = AV43GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "PROPOSTACLINICADOCUMENTO") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV43GridStateDynamicFilter.gxTpr_Operator;
                     AV104PropostaClinicaDocumento3 = AV43GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV59DynamicFiltersSelector3, "CONVENIOCATEGORIADESCRICAO") == 0 )
                  {
                     AV60DynamicFiltersOperator3 = AV43GridStateDynamicFilter.gxTpr_Operator;
                     AV105ConvenioCategoriaDescricao3 = AV43GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROPOSTACLINICANOMEOPTIONS' Routine */
         returnInSub = false;
         AV83TFPropostaClinicaNome = AV28SearchTxt;
         AV84TFPropostaClinicaNome_Sel = "";
         AV108Propostawwds_1_filterfulltext = AV50FilterFullText;
         AV109Propostawwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV110Propostawwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV111Propostawwds_4_propostamaxreembolsoid_f1 = AV91PropostaMaxReembolsoId_F1;
         AV112Propostawwds_5_propostaresponsaveldocumento1 = AV92PropostaResponsavelDocumento1;
         AV113Propostawwds_6_propostapacienteclientedocumento1 = AV93PropostaPacienteClienteDocumento1;
         AV114Propostawwds_7_propostaclinicadocumento1 = AV94PropostaClinicaDocumento1;
         AV115Propostawwds_8_conveniocategoriadescricao1 = AV95ConvenioCategoriaDescricao1;
         AV116Propostawwds_9_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV117Propostawwds_10_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV118Propostawwds_11_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV119Propostawwds_12_propostamaxreembolsoid_f2 = AV96PropostaMaxReembolsoId_F2;
         AV120Propostawwds_13_propostaresponsaveldocumento2 = AV97PropostaResponsavelDocumento2;
         AV121Propostawwds_14_propostapacienteclientedocumento2 = AV98PropostaPacienteClienteDocumento2;
         AV122Propostawwds_15_propostaclinicadocumento2 = AV99PropostaClinicaDocumento2;
         AV123Propostawwds_16_conveniocategoriadescricao2 = AV100ConvenioCategoriaDescricao2;
         AV124Propostawwds_17_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV125Propostawwds_18_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV126Propostawwds_19_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV127Propostawwds_20_propostamaxreembolsoid_f3 = AV101PropostaMaxReembolsoId_F3;
         AV128Propostawwds_21_propostaresponsaveldocumento3 = AV102PropostaResponsavelDocumento3;
         AV129Propostawwds_22_propostapacienteclientedocumento3 = AV103PropostaPacienteClienteDocumento3;
         AV130Propostawwds_23_propostaclinicadocumento3 = AV104PropostaClinicaDocumento3;
         AV131Propostawwds_24_conveniocategoriadescricao3 = AV105ConvenioCategoriaDescricao3;
         AV132Propostawwds_25_tfpropostaclinicanome = AV83TFPropostaClinicaNome;
         AV133Propostawwds_26_tfpropostaclinicanome_sel = AV84TFPropostaClinicaNome_Sel;
         AV134Propostawwds_27_tfpropostastatus_sels = AV23TFPropostaStatus_Sels;
         AV135Propostawwds_28_tfpropostapacienteclienterazaosocial = AV85TFPropostaPacienteClienteRazaoSocial;
         AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel = AV86TFPropostaPacienteClienteRazaoSocial_Sel;
         AV137Propostawwds_30_tfpropostamaiorscore_f = AV87TFPropostaMaiorScore_F;
         AV138Propostawwds_31_tfpropostamaiorscore_f_to = AV88TFPropostaMaiorScore_F_To;
         AV139Propostawwds_32_tfpropostamaiorvalorrecomendado = AV89TFPropostaMaiorValorRecomendado;
         AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to = AV90TFPropostaMaiorValorRecomendado_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV134Propostawwds_27_tfpropostastatus_sels ,
                                              AV109Propostawwds_2_dynamicfiltersselector1 ,
                                              AV110Propostawwds_3_dynamicfiltersoperator1 ,
                                              AV112Propostawwds_5_propostaresponsaveldocumento1 ,
                                              AV113Propostawwds_6_propostapacienteclientedocumento1 ,
                                              AV114Propostawwds_7_propostaclinicadocumento1 ,
                                              AV115Propostawwds_8_conveniocategoriadescricao1 ,
                                              AV116Propostawwds_9_dynamicfiltersenabled2 ,
                                              AV117Propostawwds_10_dynamicfiltersselector2 ,
                                              AV118Propostawwds_11_dynamicfiltersoperator2 ,
                                              AV120Propostawwds_13_propostaresponsaveldocumento2 ,
                                              AV121Propostawwds_14_propostapacienteclientedocumento2 ,
                                              AV122Propostawwds_15_propostaclinicadocumento2 ,
                                              AV123Propostawwds_16_conveniocategoriadescricao2 ,
                                              AV124Propostawwds_17_dynamicfiltersenabled3 ,
                                              AV125Propostawwds_18_dynamicfiltersselector3 ,
                                              AV126Propostawwds_19_dynamicfiltersoperator3 ,
                                              AV128Propostawwds_21_propostaresponsaveldocumento3 ,
                                              AV129Propostawwds_22_propostapacienteclientedocumento3 ,
                                              AV130Propostawwds_23_propostaclinicadocumento3 ,
                                              AV131Propostawwds_24_conveniocategoriadescricao3 ,
                                              AV133Propostawwds_26_tfpropostaclinicanome_sel ,
                                              AV132Propostawwds_25_tfpropostaclinicanome ,
                                              AV134Propostawwds_27_tfpropostastatus_sels.Count ,
                                              AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel ,
                                              AV135Propostawwds_28_tfpropostapacienteclienterazaosocial ,
                                              AV9WWPContext.gxTpr_Iscliente ,
                                              A580PropostaResponsavelDocumento ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A494ConvenioCategoriaDescricao ,
                                              A643PropostaClinicaNome ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A328PropostaCratedBy ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              AV108Propostawwds_1_filterfulltext ,
                                              A784PropostaMaiorScore_F ,
                                              A788PropostaMaiorValorRecomendado ,
                                              AV111Propostawwds_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV119Propostawwds_12_propostamaxreembolsoid_f2 ,
                                              AV127Propostawwds_20_propostamaxreembolsoid_f3 ,
                                              AV137Propostawwds_30_tfpropostamaiorscore_f ,
                                              AV138Propostawwds_31_tfpropostamaiorscore_f_to ,
                                              AV139Propostawwds_32_tfpropostamaiorvalorrecomendado ,
                                              AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV112Propostawwds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV112Propostawwds_5_propostaresponsaveldocumento1), "%", "");
         lV112Propostawwds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV112Propostawwds_5_propostaresponsaveldocumento1), "%", "");
         lV113Propostawwds_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV113Propostawwds_6_propostapacienteclientedocumento1), "%", "");
         lV113Propostawwds_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV113Propostawwds_6_propostapacienteclientedocumento1), "%", "");
         lV114Propostawwds_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV114Propostawwds_7_propostaclinicadocumento1), "%", "");
         lV114Propostawwds_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV114Propostawwds_7_propostaclinicadocumento1), "%", "");
         lV115Propostawwds_8_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV115Propostawwds_8_conveniocategoriadescricao1), "%", "");
         lV115Propostawwds_8_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV115Propostawwds_8_conveniocategoriadescricao1), "%", "");
         lV120Propostawwds_13_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV120Propostawwds_13_propostaresponsaveldocumento2), "%", "");
         lV120Propostawwds_13_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV120Propostawwds_13_propostaresponsaveldocumento2), "%", "");
         lV121Propostawwds_14_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV121Propostawwds_14_propostapacienteclientedocumento2), "%", "");
         lV121Propostawwds_14_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV121Propostawwds_14_propostapacienteclientedocumento2), "%", "");
         lV122Propostawwds_15_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV122Propostawwds_15_propostaclinicadocumento2), "%", "");
         lV122Propostawwds_15_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV122Propostawwds_15_propostaclinicadocumento2), "%", "");
         lV123Propostawwds_16_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV123Propostawwds_16_conveniocategoriadescricao2), "%", "");
         lV123Propostawwds_16_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV123Propostawwds_16_conveniocategoriadescricao2), "%", "");
         lV128Propostawwds_21_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV128Propostawwds_21_propostaresponsaveldocumento3), "%", "");
         lV128Propostawwds_21_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV128Propostawwds_21_propostaresponsaveldocumento3), "%", "");
         lV129Propostawwds_22_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV129Propostawwds_22_propostapacienteclientedocumento3), "%", "");
         lV129Propostawwds_22_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV129Propostawwds_22_propostapacienteclientedocumento3), "%", "");
         lV130Propostawwds_23_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV130Propostawwds_23_propostaclinicadocumento3), "%", "");
         lV130Propostawwds_23_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV130Propostawwds_23_propostaclinicadocumento3), "%", "");
         lV131Propostawwds_24_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV131Propostawwds_24_conveniocategoriadescricao3), "%", "");
         lV131Propostawwds_24_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV131Propostawwds_24_conveniocategoriadescricao3), "%", "");
         lV132Propostawwds_25_tfpropostaclinicanome = StringUtil.Concat( StringUtil.RTrim( AV132Propostawwds_25_tfpropostaclinicanome), "%", "");
         lV135Propostawwds_28_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV135Propostawwds_28_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P008D12 */
         pr_default.execute(0, new Object[] {AV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, AV109Propostawwds_2_dynamicfiltersselector1, AV110Propostawwds_3_dynamicfiltersoperator1, AV111Propostawwds_4_propostamaxreembolsoid_f1, AV111Propostawwds_4_propostamaxreembolsoid_f1, AV109Propostawwds_2_dynamicfiltersselector1, AV110Propostawwds_3_dynamicfiltersoperator1, AV111Propostawwds_4_propostamaxreembolsoid_f1, AV111Propostawwds_4_propostamaxreembolsoid_f1, AV109Propostawwds_2_dynamicfiltersselector1, AV110Propostawwds_3_dynamicfiltersoperator1, AV111Propostawwds_4_propostamaxreembolsoid_f1, AV111Propostawwds_4_propostamaxreembolsoid_f1, AV116Propostawwds_9_dynamicfiltersenabled2, AV117Propostawwds_10_dynamicfiltersselector2, AV118Propostawwds_11_dynamicfiltersoperator2, AV119Propostawwds_12_propostamaxreembolsoid_f2, AV119Propostawwds_12_propostamaxreembolsoid_f2, AV116Propostawwds_9_dynamicfiltersenabled2, AV117Propostawwds_10_dynamicfiltersselector2, AV118Propostawwds_11_dynamicfiltersoperator2, AV119Propostawwds_12_propostamaxreembolsoid_f2, AV119Propostawwds_12_propostamaxreembolsoid_f2, AV116Propostawwds_9_dynamicfiltersenabled2, AV117Propostawwds_10_dynamicfiltersselector2, AV118Propostawwds_11_dynamicfiltersoperator2, AV119Propostawwds_12_propostamaxreembolsoid_f2, AV119Propostawwds_12_propostamaxreembolsoid_f2, AV124Propostawwds_17_dynamicfiltersenabled3, AV125Propostawwds_18_dynamicfiltersselector3, AV126Propostawwds_19_dynamicfiltersoperator3, AV127Propostawwds_20_propostamaxreembolsoid_f3, AV127Propostawwds_20_propostamaxreembolsoid_f3, AV124Propostawwds_17_dynamicfiltersenabled3, AV125Propostawwds_18_dynamicfiltersselector3, AV126Propostawwds_19_dynamicfiltersoperator3, AV127Propostawwds_20_propostamaxreembolsoid_f3, AV127Propostawwds_20_propostamaxreembolsoid_f3, AV124Propostawwds_17_dynamicfiltersenabled3, AV125Propostawwds_18_dynamicfiltersselector3, AV126Propostawwds_19_dynamicfiltersoperator3, AV127Propostawwds_20_propostamaxreembolsoid_f3, AV127Propostawwds_20_propostamaxreembolsoid_f3, AV137Propostawwds_30_tfpropostamaiorscore_f, AV137Propostawwds_30_tfpropostamaiorscore_f, AV138Propostawwds_31_tfpropostamaiorscore_f_to, AV138Propostawwds_31_tfpropostamaiorscore_f_to, AV139Propostawwds_32_tfpropostamaiorvalorrecomendado, AV139Propostawwds_32_tfpropostamaiorvalorrecomendado, AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to, AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to, lV112Propostawwds_5_propostaresponsaveldocumento1, lV112Propostawwds_5_propostaresponsaveldocumento1, lV113Propostawwds_6_propostapacienteclientedocumento1, lV113Propostawwds_6_propostapacienteclientedocumento1, lV114Propostawwds_7_propostaclinicadocumento1, lV114Propostawwds_7_propostaclinicadocumento1, lV115Propostawwds_8_conveniocategoriadescricao1, lV115Propostawwds_8_conveniocategoriadescricao1, lV120Propostawwds_13_propostaresponsaveldocumento2, lV120Propostawwds_13_propostaresponsaveldocumento2, lV121Propostawwds_14_propostapacienteclientedocumento2, lV121Propostawwds_14_propostapacienteclientedocumento2, lV122Propostawwds_15_propostaclinicadocumento2, lV122Propostawwds_15_propostaclinicadocumento2, lV123Propostawwds_16_conveniocategoriadescricao2, lV123Propostawwds_16_conveniocategoriadescricao2, lV128Propostawwds_21_propostaresponsaveldocumento3, lV128Propostawwds_21_propostaresponsaveldocumento3, lV129Propostawwds_22_propostapacienteclientedocumento3, lV129Propostawwds_22_propostapacienteclientedocumento3, lV130Propostawwds_23_propostaclinicadocumento3, lV130Propostawwds_23_propostaclinicadocumento3, lV131Propostawwds_24_conveniocategoriadescricao3, lV131Propostawwds_24_conveniocategoriadescricao3, lV132Propostawwds_25_tfpropostaclinicanome, AV133Propostawwds_26_tfpropostaclinicanome_sel, lV135Propostawwds_28_tfpropostapacienteclienterazaosocial, AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, AV9WWPContext.gxTpr_Secuserclienteid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8D2 = false;
            A493ConvenioCategoriaId = P008D12_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = P008D12_n493ConvenioCategoriaId[0];
            A504PropostaPacienteClienteId = P008D12_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P008D12_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = P008D12_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = P008D12_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = P008D12_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P008D12_n642PropostaClinicaId[0];
            A643PropostaClinicaNome = P008D12_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = P008D12_n643PropostaClinicaNome[0];
            A328PropostaCratedBy = P008D12_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P008D12_n328PropostaCratedBy[0];
            A494ConvenioCategoriaDescricao = P008D12_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P008D12_n494ConvenioCategoriaDescricao[0];
            A652PropostaClinicaDocumento = P008D12_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P008D12_n652PropostaClinicaDocumento[0];
            A540PropostaPacienteClienteDocumento = P008D12_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P008D12_n540PropostaPacienteClienteDocumento[0];
            A580PropostaResponsavelDocumento = P008D12_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P008D12_n580PropostaResponsavelDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = P008D12_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P008D12_n505PropostaPacienteClienteRazaoSocial[0];
            A329PropostaStatus = P008D12_A329PropostaStatus[0];
            n329PropostaStatus = P008D12_n329PropostaStatus[0];
            A788PropostaMaiorValorRecomendado = P008D12_A788PropostaMaiorValorRecomendado[0];
            n788PropostaMaiorValorRecomendado = P008D12_n788PropostaMaiorValorRecomendado[0];
            A784PropostaMaiorScore_F = P008D12_A784PropostaMaiorScore_F[0];
            n784PropostaMaiorScore_F = P008D12_n784PropostaMaiorScore_F[0];
            A323PropostaId = P008D12_A323PropostaId[0];
            A649PropostaMaxReembolsoId_F = P008D12_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P008D12_n649PropostaMaxReembolsoId_F[0];
            A494ConvenioCategoriaDescricao = P008D12_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P008D12_n494ConvenioCategoriaDescricao[0];
            A540PropostaPacienteClienteDocumento = P008D12_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P008D12_n540PropostaPacienteClienteDocumento[0];
            A505PropostaPacienteClienteRazaoSocial = P008D12_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P008D12_n505PropostaPacienteClienteRazaoSocial[0];
            A580PropostaResponsavelDocumento = P008D12_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P008D12_n580PropostaResponsavelDocumento[0];
            A643PropostaClinicaNome = P008D12_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = P008D12_n643PropostaClinicaNome[0];
            A652PropostaClinicaDocumento = P008D12_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P008D12_n652PropostaClinicaDocumento[0];
            A788PropostaMaiorValorRecomendado = P008D12_A788PropostaMaiorValorRecomendado[0];
            n788PropostaMaiorValorRecomendado = P008D12_n788PropostaMaiorValorRecomendado[0];
            A784PropostaMaiorScore_F = P008D12_A784PropostaMaiorScore_F[0];
            n784PropostaMaiorScore_F = P008D12_n784PropostaMaiorScore_F[0];
            A649PropostaMaxReembolsoId_F = P008D12_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P008D12_n649PropostaMaxReembolsoId_F[0];
            AV38count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P008D12_A643PropostaClinicaNome[0], A643PropostaClinicaNome) == 0 ) )
            {
               BRK8D2 = false;
               A642PropostaClinicaId = P008D12_A642PropostaClinicaId[0];
               n642PropostaClinicaId = P008D12_n642PropostaClinicaId[0];
               A323PropostaId = P008D12_A323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRK8D2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A643PropostaClinicaNome)) ? "<#Empty#>" : A643PropostaClinicaNome);
               AV34Options.Add(AV33Option, 0);
               AV37OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV34Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV29SkipItems = (short)(AV29SkipItems-1);
            }
            if ( ! BRK8D2 )
            {
               BRK8D2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROPOSTAPACIENTECLIENTERAZAOSOCIALOPTIONS' Routine */
         returnInSub = false;
         AV85TFPropostaPacienteClienteRazaoSocial = AV28SearchTxt;
         AV86TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV108Propostawwds_1_filterfulltext = AV50FilterFullText;
         AV109Propostawwds_2_dynamicfiltersselector1 = AV51DynamicFiltersSelector1;
         AV110Propostawwds_3_dynamicfiltersoperator1 = AV52DynamicFiltersOperator1;
         AV111Propostawwds_4_propostamaxreembolsoid_f1 = AV91PropostaMaxReembolsoId_F1;
         AV112Propostawwds_5_propostaresponsaveldocumento1 = AV92PropostaResponsavelDocumento1;
         AV113Propostawwds_6_propostapacienteclientedocumento1 = AV93PropostaPacienteClienteDocumento1;
         AV114Propostawwds_7_propostaclinicadocumento1 = AV94PropostaClinicaDocumento1;
         AV115Propostawwds_8_conveniocategoriadescricao1 = AV95ConvenioCategoriaDescricao1;
         AV116Propostawwds_9_dynamicfiltersenabled2 = AV54DynamicFiltersEnabled2;
         AV117Propostawwds_10_dynamicfiltersselector2 = AV55DynamicFiltersSelector2;
         AV118Propostawwds_11_dynamicfiltersoperator2 = AV56DynamicFiltersOperator2;
         AV119Propostawwds_12_propostamaxreembolsoid_f2 = AV96PropostaMaxReembolsoId_F2;
         AV120Propostawwds_13_propostaresponsaveldocumento2 = AV97PropostaResponsavelDocumento2;
         AV121Propostawwds_14_propostapacienteclientedocumento2 = AV98PropostaPacienteClienteDocumento2;
         AV122Propostawwds_15_propostaclinicadocumento2 = AV99PropostaClinicaDocumento2;
         AV123Propostawwds_16_conveniocategoriadescricao2 = AV100ConvenioCategoriaDescricao2;
         AV124Propostawwds_17_dynamicfiltersenabled3 = AV58DynamicFiltersEnabled3;
         AV125Propostawwds_18_dynamicfiltersselector3 = AV59DynamicFiltersSelector3;
         AV126Propostawwds_19_dynamicfiltersoperator3 = AV60DynamicFiltersOperator3;
         AV127Propostawwds_20_propostamaxreembolsoid_f3 = AV101PropostaMaxReembolsoId_F3;
         AV128Propostawwds_21_propostaresponsaveldocumento3 = AV102PropostaResponsavelDocumento3;
         AV129Propostawwds_22_propostapacienteclientedocumento3 = AV103PropostaPacienteClienteDocumento3;
         AV130Propostawwds_23_propostaclinicadocumento3 = AV104PropostaClinicaDocumento3;
         AV131Propostawwds_24_conveniocategoriadescricao3 = AV105ConvenioCategoriaDescricao3;
         AV132Propostawwds_25_tfpropostaclinicanome = AV83TFPropostaClinicaNome;
         AV133Propostawwds_26_tfpropostaclinicanome_sel = AV84TFPropostaClinicaNome_Sel;
         AV134Propostawwds_27_tfpropostastatus_sels = AV23TFPropostaStatus_Sels;
         AV135Propostawwds_28_tfpropostapacienteclienterazaosocial = AV85TFPropostaPacienteClienteRazaoSocial;
         AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel = AV86TFPropostaPacienteClienteRazaoSocial_Sel;
         AV137Propostawwds_30_tfpropostamaiorscore_f = AV87TFPropostaMaiorScore_F;
         AV138Propostawwds_31_tfpropostamaiorscore_f_to = AV88TFPropostaMaiorScore_F_To;
         AV139Propostawwds_32_tfpropostamaiorvalorrecomendado = AV89TFPropostaMaiorValorRecomendado;
         AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to = AV90TFPropostaMaiorValorRecomendado_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A329PropostaStatus ,
                                              AV134Propostawwds_27_tfpropostastatus_sels ,
                                              AV109Propostawwds_2_dynamicfiltersselector1 ,
                                              AV110Propostawwds_3_dynamicfiltersoperator1 ,
                                              AV112Propostawwds_5_propostaresponsaveldocumento1 ,
                                              AV113Propostawwds_6_propostapacienteclientedocumento1 ,
                                              AV114Propostawwds_7_propostaclinicadocumento1 ,
                                              AV115Propostawwds_8_conveniocategoriadescricao1 ,
                                              AV116Propostawwds_9_dynamicfiltersenabled2 ,
                                              AV117Propostawwds_10_dynamicfiltersselector2 ,
                                              AV118Propostawwds_11_dynamicfiltersoperator2 ,
                                              AV120Propostawwds_13_propostaresponsaveldocumento2 ,
                                              AV121Propostawwds_14_propostapacienteclientedocumento2 ,
                                              AV122Propostawwds_15_propostaclinicadocumento2 ,
                                              AV123Propostawwds_16_conveniocategoriadescricao2 ,
                                              AV124Propostawwds_17_dynamicfiltersenabled3 ,
                                              AV125Propostawwds_18_dynamicfiltersselector3 ,
                                              AV126Propostawwds_19_dynamicfiltersoperator3 ,
                                              AV128Propostawwds_21_propostaresponsaveldocumento3 ,
                                              AV129Propostawwds_22_propostapacienteclientedocumento3 ,
                                              AV130Propostawwds_23_propostaclinicadocumento3 ,
                                              AV131Propostawwds_24_conveniocategoriadescricao3 ,
                                              AV133Propostawwds_26_tfpropostaclinicanome_sel ,
                                              AV132Propostawwds_25_tfpropostaclinicanome ,
                                              AV134Propostawwds_27_tfpropostastatus_sels.Count ,
                                              AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel ,
                                              AV135Propostawwds_28_tfpropostapacienteclienterazaosocial ,
                                              AV9WWPContext.gxTpr_Iscliente ,
                                              A580PropostaResponsavelDocumento ,
                                              A540PropostaPacienteClienteDocumento ,
                                              A652PropostaClinicaDocumento ,
                                              A494ConvenioCategoriaDescricao ,
                                              A643PropostaClinicaNome ,
                                              A505PropostaPacienteClienteRazaoSocial ,
                                              A328PropostaCratedBy ,
                                              AV9WWPContext.gxTpr_Secuserclienteid ,
                                              AV108Propostawwds_1_filterfulltext ,
                                              A784PropostaMaiorScore_F ,
                                              A788PropostaMaiorValorRecomendado ,
                                              AV111Propostawwds_4_propostamaxreembolsoid_f1 ,
                                              A649PropostaMaxReembolsoId_F ,
                                              AV119Propostawwds_12_propostamaxreembolsoid_f2 ,
                                              AV127Propostawwds_20_propostamaxreembolsoid_f3 ,
                                              AV137Propostawwds_30_tfpropostamaiorscore_f ,
                                              AV138Propostawwds_31_tfpropostamaiorscore_f_to ,
                                              AV139Propostawwds_32_tfpropostamaiorvalorrecomendado ,
                                              AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV108Propostawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV108Propostawwds_1_filterfulltext), "%", "");
         lV112Propostawwds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV112Propostawwds_5_propostaresponsaveldocumento1), "%", "");
         lV112Propostawwds_5_propostaresponsaveldocumento1 = StringUtil.Concat( StringUtil.RTrim( AV112Propostawwds_5_propostaresponsaveldocumento1), "%", "");
         lV113Propostawwds_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV113Propostawwds_6_propostapacienteclientedocumento1), "%", "");
         lV113Propostawwds_6_propostapacienteclientedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV113Propostawwds_6_propostapacienteclientedocumento1), "%", "");
         lV114Propostawwds_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV114Propostawwds_7_propostaclinicadocumento1), "%", "");
         lV114Propostawwds_7_propostaclinicadocumento1 = StringUtil.Concat( StringUtil.RTrim( AV114Propostawwds_7_propostaclinicadocumento1), "%", "");
         lV115Propostawwds_8_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV115Propostawwds_8_conveniocategoriadescricao1), "%", "");
         lV115Propostawwds_8_conveniocategoriadescricao1 = StringUtil.Concat( StringUtil.RTrim( AV115Propostawwds_8_conveniocategoriadescricao1), "%", "");
         lV120Propostawwds_13_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV120Propostawwds_13_propostaresponsaveldocumento2), "%", "");
         lV120Propostawwds_13_propostaresponsaveldocumento2 = StringUtil.Concat( StringUtil.RTrim( AV120Propostawwds_13_propostaresponsaveldocumento2), "%", "");
         lV121Propostawwds_14_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV121Propostawwds_14_propostapacienteclientedocumento2), "%", "");
         lV121Propostawwds_14_propostapacienteclientedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV121Propostawwds_14_propostapacienteclientedocumento2), "%", "");
         lV122Propostawwds_15_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV122Propostawwds_15_propostaclinicadocumento2), "%", "");
         lV122Propostawwds_15_propostaclinicadocumento2 = StringUtil.Concat( StringUtil.RTrim( AV122Propostawwds_15_propostaclinicadocumento2), "%", "");
         lV123Propostawwds_16_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV123Propostawwds_16_conveniocategoriadescricao2), "%", "");
         lV123Propostawwds_16_conveniocategoriadescricao2 = StringUtil.Concat( StringUtil.RTrim( AV123Propostawwds_16_conveniocategoriadescricao2), "%", "");
         lV128Propostawwds_21_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV128Propostawwds_21_propostaresponsaveldocumento3), "%", "");
         lV128Propostawwds_21_propostaresponsaveldocumento3 = StringUtil.Concat( StringUtil.RTrim( AV128Propostawwds_21_propostaresponsaveldocumento3), "%", "");
         lV129Propostawwds_22_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV129Propostawwds_22_propostapacienteclientedocumento3), "%", "");
         lV129Propostawwds_22_propostapacienteclientedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV129Propostawwds_22_propostapacienteclientedocumento3), "%", "");
         lV130Propostawwds_23_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV130Propostawwds_23_propostaclinicadocumento3), "%", "");
         lV130Propostawwds_23_propostaclinicadocumento3 = StringUtil.Concat( StringUtil.RTrim( AV130Propostawwds_23_propostaclinicadocumento3), "%", "");
         lV131Propostawwds_24_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV131Propostawwds_24_conveniocategoriadescricao3), "%", "");
         lV131Propostawwds_24_conveniocategoriadescricao3 = StringUtil.Concat( StringUtil.RTrim( AV131Propostawwds_24_conveniocategoriadescricao3), "%", "");
         lV132Propostawwds_25_tfpropostaclinicanome = StringUtil.Concat( StringUtil.RTrim( AV132Propostawwds_25_tfpropostaclinicanome), "%", "");
         lV135Propostawwds_28_tfpropostapacienteclienterazaosocial = StringUtil.Concat( StringUtil.RTrim( AV135Propostawwds_28_tfpropostapacienteclienterazaosocial), "%", "");
         /* Using cursor P008D23 */
         pr_default.execute(1, new Object[] {AV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, lV108Propostawwds_1_filterfulltext, AV109Propostawwds_2_dynamicfiltersselector1, AV110Propostawwds_3_dynamicfiltersoperator1, AV111Propostawwds_4_propostamaxreembolsoid_f1, AV111Propostawwds_4_propostamaxreembolsoid_f1, AV109Propostawwds_2_dynamicfiltersselector1, AV110Propostawwds_3_dynamicfiltersoperator1, AV111Propostawwds_4_propostamaxreembolsoid_f1, AV111Propostawwds_4_propostamaxreembolsoid_f1, AV109Propostawwds_2_dynamicfiltersselector1, AV110Propostawwds_3_dynamicfiltersoperator1, AV111Propostawwds_4_propostamaxreembolsoid_f1, AV111Propostawwds_4_propostamaxreembolsoid_f1, AV116Propostawwds_9_dynamicfiltersenabled2, AV117Propostawwds_10_dynamicfiltersselector2, AV118Propostawwds_11_dynamicfiltersoperator2, AV119Propostawwds_12_propostamaxreembolsoid_f2, AV119Propostawwds_12_propostamaxreembolsoid_f2, AV116Propostawwds_9_dynamicfiltersenabled2, AV117Propostawwds_10_dynamicfiltersselector2, AV118Propostawwds_11_dynamicfiltersoperator2, AV119Propostawwds_12_propostamaxreembolsoid_f2, AV119Propostawwds_12_propostamaxreembolsoid_f2, AV116Propostawwds_9_dynamicfiltersenabled2, AV117Propostawwds_10_dynamicfiltersselector2, AV118Propostawwds_11_dynamicfiltersoperator2, AV119Propostawwds_12_propostamaxreembolsoid_f2, AV119Propostawwds_12_propostamaxreembolsoid_f2, AV124Propostawwds_17_dynamicfiltersenabled3, AV125Propostawwds_18_dynamicfiltersselector3, AV126Propostawwds_19_dynamicfiltersoperator3, AV127Propostawwds_20_propostamaxreembolsoid_f3, AV127Propostawwds_20_propostamaxreembolsoid_f3, AV124Propostawwds_17_dynamicfiltersenabled3, AV125Propostawwds_18_dynamicfiltersselector3, AV126Propostawwds_19_dynamicfiltersoperator3, AV127Propostawwds_20_propostamaxreembolsoid_f3, AV127Propostawwds_20_propostamaxreembolsoid_f3, AV124Propostawwds_17_dynamicfiltersenabled3, AV125Propostawwds_18_dynamicfiltersselector3, AV126Propostawwds_19_dynamicfiltersoperator3, AV127Propostawwds_20_propostamaxreembolsoid_f3, AV127Propostawwds_20_propostamaxreembolsoid_f3, AV137Propostawwds_30_tfpropostamaiorscore_f, AV137Propostawwds_30_tfpropostamaiorscore_f, AV138Propostawwds_31_tfpropostamaiorscore_f_to, AV138Propostawwds_31_tfpropostamaiorscore_f_to, AV139Propostawwds_32_tfpropostamaiorvalorrecomendado, AV139Propostawwds_32_tfpropostamaiorvalorrecomendado, AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to, AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to, lV112Propostawwds_5_propostaresponsaveldocumento1, lV112Propostawwds_5_propostaresponsaveldocumento1, lV113Propostawwds_6_propostapacienteclientedocumento1, lV113Propostawwds_6_propostapacienteclientedocumento1, lV114Propostawwds_7_propostaclinicadocumento1, lV114Propostawwds_7_propostaclinicadocumento1, lV115Propostawwds_8_conveniocategoriadescricao1, lV115Propostawwds_8_conveniocategoriadescricao1, lV120Propostawwds_13_propostaresponsaveldocumento2, lV120Propostawwds_13_propostaresponsaveldocumento2, lV121Propostawwds_14_propostapacienteclientedocumento2, lV121Propostawwds_14_propostapacienteclientedocumento2, lV122Propostawwds_15_propostaclinicadocumento2, lV122Propostawwds_15_propostaclinicadocumento2, lV123Propostawwds_16_conveniocategoriadescricao2, lV123Propostawwds_16_conveniocategoriadescricao2, lV128Propostawwds_21_propostaresponsaveldocumento3, lV128Propostawwds_21_propostaresponsaveldocumento3, lV129Propostawwds_22_propostapacienteclientedocumento3, lV129Propostawwds_22_propostapacienteclientedocumento3, lV130Propostawwds_23_propostaclinicadocumento3, lV130Propostawwds_23_propostaclinicadocumento3, lV131Propostawwds_24_conveniocategoriadescricao3, lV131Propostawwds_24_conveniocategoriadescricao3, lV132Propostawwds_25_tfpropostaclinicanome, AV133Propostawwds_26_tfpropostaclinicanome_sel, lV135Propostawwds_28_tfpropostapacienteclienterazaosocial, AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, AV9WWPContext.gxTpr_Secuserclienteid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK8D4 = false;
            A493ConvenioCategoriaId = P008D23_A493ConvenioCategoriaId[0];
            n493ConvenioCategoriaId = P008D23_n493ConvenioCategoriaId[0];
            A504PropostaPacienteClienteId = P008D23_A504PropostaPacienteClienteId[0];
            n504PropostaPacienteClienteId = P008D23_n504PropostaPacienteClienteId[0];
            A553PropostaResponsavelId = P008D23_A553PropostaResponsavelId[0];
            n553PropostaResponsavelId = P008D23_n553PropostaResponsavelId[0];
            A642PropostaClinicaId = P008D23_A642PropostaClinicaId[0];
            n642PropostaClinicaId = P008D23_n642PropostaClinicaId[0];
            A505PropostaPacienteClienteRazaoSocial = P008D23_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P008D23_n505PropostaPacienteClienteRazaoSocial[0];
            A328PropostaCratedBy = P008D23_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P008D23_n328PropostaCratedBy[0];
            A494ConvenioCategoriaDescricao = P008D23_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P008D23_n494ConvenioCategoriaDescricao[0];
            A652PropostaClinicaDocumento = P008D23_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P008D23_n652PropostaClinicaDocumento[0];
            A540PropostaPacienteClienteDocumento = P008D23_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P008D23_n540PropostaPacienteClienteDocumento[0];
            A580PropostaResponsavelDocumento = P008D23_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P008D23_n580PropostaResponsavelDocumento[0];
            A329PropostaStatus = P008D23_A329PropostaStatus[0];
            n329PropostaStatus = P008D23_n329PropostaStatus[0];
            A643PropostaClinicaNome = P008D23_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = P008D23_n643PropostaClinicaNome[0];
            A788PropostaMaiorValorRecomendado = P008D23_A788PropostaMaiorValorRecomendado[0];
            n788PropostaMaiorValorRecomendado = P008D23_n788PropostaMaiorValorRecomendado[0];
            A784PropostaMaiorScore_F = P008D23_A784PropostaMaiorScore_F[0];
            n784PropostaMaiorScore_F = P008D23_n784PropostaMaiorScore_F[0];
            A323PropostaId = P008D23_A323PropostaId[0];
            A649PropostaMaxReembolsoId_F = P008D23_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P008D23_n649PropostaMaxReembolsoId_F[0];
            A494ConvenioCategoriaDescricao = P008D23_A494ConvenioCategoriaDescricao[0];
            n494ConvenioCategoriaDescricao = P008D23_n494ConvenioCategoriaDescricao[0];
            A505PropostaPacienteClienteRazaoSocial = P008D23_A505PropostaPacienteClienteRazaoSocial[0];
            n505PropostaPacienteClienteRazaoSocial = P008D23_n505PropostaPacienteClienteRazaoSocial[0];
            A540PropostaPacienteClienteDocumento = P008D23_A540PropostaPacienteClienteDocumento[0];
            n540PropostaPacienteClienteDocumento = P008D23_n540PropostaPacienteClienteDocumento[0];
            A580PropostaResponsavelDocumento = P008D23_A580PropostaResponsavelDocumento[0];
            n580PropostaResponsavelDocumento = P008D23_n580PropostaResponsavelDocumento[0];
            A652PropostaClinicaDocumento = P008D23_A652PropostaClinicaDocumento[0];
            n652PropostaClinicaDocumento = P008D23_n652PropostaClinicaDocumento[0];
            A643PropostaClinicaNome = P008D23_A643PropostaClinicaNome[0];
            n643PropostaClinicaNome = P008D23_n643PropostaClinicaNome[0];
            A788PropostaMaiorValorRecomendado = P008D23_A788PropostaMaiorValorRecomendado[0];
            n788PropostaMaiorValorRecomendado = P008D23_n788PropostaMaiorValorRecomendado[0];
            A784PropostaMaiorScore_F = P008D23_A784PropostaMaiorScore_F[0];
            n784PropostaMaiorScore_F = P008D23_n784PropostaMaiorScore_F[0];
            A649PropostaMaxReembolsoId_F = P008D23_A649PropostaMaxReembolsoId_F[0];
            n649PropostaMaxReembolsoId_F = P008D23_n649PropostaMaxReembolsoId_F[0];
            AV38count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P008D23_A505PropostaPacienteClienteRazaoSocial[0], A505PropostaPacienteClienteRazaoSocial) == 0 ) )
            {
               BRK8D4 = false;
               A504PropostaPacienteClienteId = P008D23_A504PropostaPacienteClienteId[0];
               n504PropostaPacienteClienteId = P008D23_n504PropostaPacienteClienteId[0];
               A323PropostaId = P008D23_A323PropostaId[0];
               AV38count = (long)(AV38count+1);
               BRK8D4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV29SkipItems) )
            {
               AV33Option = (String.IsNullOrEmpty(StringUtil.RTrim( A505PropostaPacienteClienteRazaoSocial)) ? "<#Empty#>" : A505PropostaPacienteClienteRazaoSocial);
               AV34Options.Add(AV33Option, 0);
               AV37OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV34Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV29SkipItems = (short)(AV29SkipItems-1);
            }
            if ( ! BRK8D4 )
            {
               BRK8D4 = true;
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
         AV47OptionsJson = "";
         AV48OptionsDescJson = "";
         AV49OptionIndexesJson = "";
         AV34Options = new GxSimpleCollection<string>();
         AV36OptionsDesc = new GxSimpleCollection<string>();
         AV37OptionIndexes = new GxSimpleCollection<string>();
         AV28SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV39Session = context.GetSession();
         AV41GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV50FilterFullText = "";
         AV83TFPropostaClinicaNome = "";
         AV84TFPropostaClinicaNome_Sel = "";
         AV22TFPropostaStatus_SelsJson = "";
         AV23TFPropostaStatus_Sels = new GxSimpleCollection<string>();
         AV85TFPropostaPacienteClienteRazaoSocial = "";
         AV86TFPropostaPacienteClienteRazaoSocial_Sel = "";
         AV43GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV51DynamicFiltersSelector1 = "";
         AV92PropostaResponsavelDocumento1 = "";
         AV93PropostaPacienteClienteDocumento1 = "";
         AV94PropostaClinicaDocumento1 = "";
         AV95ConvenioCategoriaDescricao1 = "";
         AV55DynamicFiltersSelector2 = "";
         AV97PropostaResponsavelDocumento2 = "";
         AV98PropostaPacienteClienteDocumento2 = "";
         AV99PropostaClinicaDocumento2 = "";
         AV100ConvenioCategoriaDescricao2 = "";
         AV59DynamicFiltersSelector3 = "";
         AV102PropostaResponsavelDocumento3 = "";
         AV103PropostaPacienteClienteDocumento3 = "";
         AV104PropostaClinicaDocumento3 = "";
         AV105ConvenioCategoriaDescricao3 = "";
         AV108Propostawwds_1_filterfulltext = "";
         AV109Propostawwds_2_dynamicfiltersselector1 = "";
         AV112Propostawwds_5_propostaresponsaveldocumento1 = "";
         AV113Propostawwds_6_propostapacienteclientedocumento1 = "";
         AV114Propostawwds_7_propostaclinicadocumento1 = "";
         AV115Propostawwds_8_conveniocategoriadescricao1 = "";
         AV117Propostawwds_10_dynamicfiltersselector2 = "";
         AV120Propostawwds_13_propostaresponsaveldocumento2 = "";
         AV121Propostawwds_14_propostapacienteclientedocumento2 = "";
         AV122Propostawwds_15_propostaclinicadocumento2 = "";
         AV123Propostawwds_16_conveniocategoriadescricao2 = "";
         AV125Propostawwds_18_dynamicfiltersselector3 = "";
         AV128Propostawwds_21_propostaresponsaveldocumento3 = "";
         AV129Propostawwds_22_propostapacienteclientedocumento3 = "";
         AV130Propostawwds_23_propostaclinicadocumento3 = "";
         AV131Propostawwds_24_conveniocategoriadescricao3 = "";
         AV132Propostawwds_25_tfpropostaclinicanome = "";
         AV133Propostawwds_26_tfpropostaclinicanome_sel = "";
         AV134Propostawwds_27_tfpropostastatus_sels = new GxSimpleCollection<string>();
         AV135Propostawwds_28_tfpropostapacienteclienterazaosocial = "";
         AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel = "";
         lV108Propostawwds_1_filterfulltext = "";
         lV112Propostawwds_5_propostaresponsaveldocumento1 = "";
         lV113Propostawwds_6_propostapacienteclientedocumento1 = "";
         lV114Propostawwds_7_propostaclinicadocumento1 = "";
         lV115Propostawwds_8_conveniocategoriadescricao1 = "";
         lV120Propostawwds_13_propostaresponsaveldocumento2 = "";
         lV121Propostawwds_14_propostapacienteclientedocumento2 = "";
         lV122Propostawwds_15_propostaclinicadocumento2 = "";
         lV123Propostawwds_16_conveniocategoriadescricao2 = "";
         lV128Propostawwds_21_propostaresponsaveldocumento3 = "";
         lV129Propostawwds_22_propostapacienteclientedocumento3 = "";
         lV130Propostawwds_23_propostaclinicadocumento3 = "";
         lV131Propostawwds_24_conveniocategoriadescricao3 = "";
         lV132Propostawwds_25_tfpropostaclinicanome = "";
         lV135Propostawwds_28_tfpropostapacienteclienterazaosocial = "";
         A329PropostaStatus = "";
         A580PropostaResponsavelDocumento = "";
         A540PropostaPacienteClienteDocumento = "";
         A652PropostaClinicaDocumento = "";
         A494ConvenioCategoriaDescricao = "";
         A643PropostaClinicaNome = "";
         A505PropostaPacienteClienteRazaoSocial = "";
         P008D12_A493ConvenioCategoriaId = new int[1] ;
         P008D12_n493ConvenioCategoriaId = new bool[] {false} ;
         P008D12_A504PropostaPacienteClienteId = new int[1] ;
         P008D12_n504PropostaPacienteClienteId = new bool[] {false} ;
         P008D12_A553PropostaResponsavelId = new int[1] ;
         P008D12_n553PropostaResponsavelId = new bool[] {false} ;
         P008D12_A642PropostaClinicaId = new int[1] ;
         P008D12_n642PropostaClinicaId = new bool[] {false} ;
         P008D12_A643PropostaClinicaNome = new string[] {""} ;
         P008D12_n643PropostaClinicaNome = new bool[] {false} ;
         P008D12_A328PropostaCratedBy = new short[1] ;
         P008D12_n328PropostaCratedBy = new bool[] {false} ;
         P008D12_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P008D12_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P008D12_A652PropostaClinicaDocumento = new string[] {""} ;
         P008D12_n652PropostaClinicaDocumento = new bool[] {false} ;
         P008D12_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         P008D12_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         P008D12_A580PropostaResponsavelDocumento = new string[] {""} ;
         P008D12_n580PropostaResponsavelDocumento = new bool[] {false} ;
         P008D12_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P008D12_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P008D12_A329PropostaStatus = new string[] {""} ;
         P008D12_n329PropostaStatus = new bool[] {false} ;
         P008D12_A788PropostaMaiorValorRecomendado = new decimal[1] ;
         P008D12_n788PropostaMaiorValorRecomendado = new bool[] {false} ;
         P008D12_A784PropostaMaiorScore_F = new short[1] ;
         P008D12_n784PropostaMaiorScore_F = new bool[] {false} ;
         P008D12_A323PropostaId = new int[1] ;
         P008D12_A649PropostaMaxReembolsoId_F = new int[1] ;
         P008D12_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         AV33Option = "";
         P008D23_A493ConvenioCategoriaId = new int[1] ;
         P008D23_n493ConvenioCategoriaId = new bool[] {false} ;
         P008D23_A504PropostaPacienteClienteId = new int[1] ;
         P008D23_n504PropostaPacienteClienteId = new bool[] {false} ;
         P008D23_A553PropostaResponsavelId = new int[1] ;
         P008D23_n553PropostaResponsavelId = new bool[] {false} ;
         P008D23_A642PropostaClinicaId = new int[1] ;
         P008D23_n642PropostaClinicaId = new bool[] {false} ;
         P008D23_A505PropostaPacienteClienteRazaoSocial = new string[] {""} ;
         P008D23_n505PropostaPacienteClienteRazaoSocial = new bool[] {false} ;
         P008D23_A328PropostaCratedBy = new short[1] ;
         P008D23_n328PropostaCratedBy = new bool[] {false} ;
         P008D23_A494ConvenioCategoriaDescricao = new string[] {""} ;
         P008D23_n494ConvenioCategoriaDescricao = new bool[] {false} ;
         P008D23_A652PropostaClinicaDocumento = new string[] {""} ;
         P008D23_n652PropostaClinicaDocumento = new bool[] {false} ;
         P008D23_A540PropostaPacienteClienteDocumento = new string[] {""} ;
         P008D23_n540PropostaPacienteClienteDocumento = new bool[] {false} ;
         P008D23_A580PropostaResponsavelDocumento = new string[] {""} ;
         P008D23_n580PropostaResponsavelDocumento = new bool[] {false} ;
         P008D23_A329PropostaStatus = new string[] {""} ;
         P008D23_n329PropostaStatus = new bool[] {false} ;
         P008D23_A643PropostaClinicaNome = new string[] {""} ;
         P008D23_n643PropostaClinicaNome = new bool[] {false} ;
         P008D23_A788PropostaMaiorValorRecomendado = new decimal[1] ;
         P008D23_n788PropostaMaiorValorRecomendado = new bool[] {false} ;
         P008D23_A784PropostaMaiorScore_F = new short[1] ;
         P008D23_n784PropostaMaiorScore_F = new bool[] {false} ;
         P008D23_A323PropostaId = new int[1] ;
         P008D23_A649PropostaMaxReembolsoId_F = new int[1] ;
         P008D23_n649PropostaMaxReembolsoId_F = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008D12_A493ConvenioCategoriaId, P008D12_n493ConvenioCategoriaId, P008D12_A504PropostaPacienteClienteId, P008D12_n504PropostaPacienteClienteId, P008D12_A553PropostaResponsavelId, P008D12_n553PropostaResponsavelId, P008D12_A642PropostaClinicaId, P008D12_n642PropostaClinicaId, P008D12_A643PropostaClinicaNome, P008D12_n643PropostaClinicaNome,
               P008D12_A328PropostaCratedBy, P008D12_n328PropostaCratedBy, P008D12_A494ConvenioCategoriaDescricao, P008D12_n494ConvenioCategoriaDescricao, P008D12_A652PropostaClinicaDocumento, P008D12_n652PropostaClinicaDocumento, P008D12_A540PropostaPacienteClienteDocumento, P008D12_n540PropostaPacienteClienteDocumento, P008D12_A580PropostaResponsavelDocumento, P008D12_n580PropostaResponsavelDocumento,
               P008D12_A505PropostaPacienteClienteRazaoSocial, P008D12_n505PropostaPacienteClienteRazaoSocial, P008D12_A329PropostaStatus, P008D12_n329PropostaStatus, P008D12_A788PropostaMaiorValorRecomendado, P008D12_n788PropostaMaiorValorRecomendado, P008D12_A784PropostaMaiorScore_F, P008D12_n784PropostaMaiorScore_F, P008D12_A323PropostaId, P008D12_A649PropostaMaxReembolsoId_F,
               P008D12_n649PropostaMaxReembolsoId_F
               }
               , new Object[] {
               P008D23_A493ConvenioCategoriaId, P008D23_n493ConvenioCategoriaId, P008D23_A504PropostaPacienteClienteId, P008D23_n504PropostaPacienteClienteId, P008D23_A553PropostaResponsavelId, P008D23_n553PropostaResponsavelId, P008D23_A642PropostaClinicaId, P008D23_n642PropostaClinicaId, P008D23_A505PropostaPacienteClienteRazaoSocial, P008D23_n505PropostaPacienteClienteRazaoSocial,
               P008D23_A328PropostaCratedBy, P008D23_n328PropostaCratedBy, P008D23_A494ConvenioCategoriaDescricao, P008D23_n494ConvenioCategoriaDescricao, P008D23_A652PropostaClinicaDocumento, P008D23_n652PropostaClinicaDocumento, P008D23_A540PropostaPacienteClienteDocumento, P008D23_n540PropostaPacienteClienteDocumento, P008D23_A580PropostaResponsavelDocumento, P008D23_n580PropostaResponsavelDocumento,
               P008D23_A329PropostaStatus, P008D23_n329PropostaStatus, P008D23_A643PropostaClinicaNome, P008D23_n643PropostaClinicaNome, P008D23_A788PropostaMaiorValorRecomendado, P008D23_n788PropostaMaiorValorRecomendado, P008D23_A784PropostaMaiorScore_F, P008D23_n784PropostaMaiorScore_F, P008D23_A323PropostaId, P008D23_A649PropostaMaxReembolsoId_F,
               P008D23_n649PropostaMaxReembolsoId_F
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV31MaxItems ;
      private short AV30PageIndex ;
      private short AV29SkipItems ;
      private short AV87TFPropostaMaiorScore_F ;
      private short AV88TFPropostaMaiorScore_F_To ;
      private short AV52DynamicFiltersOperator1 ;
      private short AV56DynamicFiltersOperator2 ;
      private short AV60DynamicFiltersOperator3 ;
      private short AV110Propostawwds_3_dynamicfiltersoperator1 ;
      private short AV118Propostawwds_11_dynamicfiltersoperator2 ;
      private short AV126Propostawwds_19_dynamicfiltersoperator3 ;
      private short AV137Propostawwds_30_tfpropostamaiorscore_f ;
      private short AV138Propostawwds_31_tfpropostamaiorscore_f_to ;
      private short AV9WWPContext_gxTpr_Secuserclienteid ;
      private short A328PropostaCratedBy ;
      private short A784PropostaMaiorScore_F ;
      private int AV106GXV1 ;
      private int AV91PropostaMaxReembolsoId_F1 ;
      private int AV96PropostaMaxReembolsoId_F2 ;
      private int AV101PropostaMaxReembolsoId_F3 ;
      private int AV111Propostawwds_4_propostamaxreembolsoid_f1 ;
      private int AV119Propostawwds_12_propostamaxreembolsoid_f2 ;
      private int AV127Propostawwds_20_propostamaxreembolsoid_f3 ;
      private int AV134Propostawwds_27_tfpropostastatus_sels_Count ;
      private int A649PropostaMaxReembolsoId_F ;
      private int A493ConvenioCategoriaId ;
      private int A504PropostaPacienteClienteId ;
      private int A553PropostaResponsavelId ;
      private int A642PropostaClinicaId ;
      private int A323PropostaId ;
      private long AV38count ;
      private decimal AV89TFPropostaMaiorValorRecomendado ;
      private decimal AV90TFPropostaMaiorValorRecomendado_To ;
      private decimal AV139Propostawwds_32_tfpropostamaiorvalorrecomendado ;
      private decimal AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to ;
      private decimal A788PropostaMaiorValorRecomendado ;
      private bool returnInSub ;
      private bool AV54DynamicFiltersEnabled2 ;
      private bool AV58DynamicFiltersEnabled3 ;
      private bool AV116Propostawwds_9_dynamicfiltersenabled2 ;
      private bool AV124Propostawwds_17_dynamicfiltersenabled3 ;
      private bool AV9WWPContext_gxTpr_Iscliente ;
      private bool BRK8D2 ;
      private bool n493ConvenioCategoriaId ;
      private bool n504PropostaPacienteClienteId ;
      private bool n553PropostaResponsavelId ;
      private bool n642PropostaClinicaId ;
      private bool n643PropostaClinicaNome ;
      private bool n328PropostaCratedBy ;
      private bool n494ConvenioCategoriaDescricao ;
      private bool n652PropostaClinicaDocumento ;
      private bool n540PropostaPacienteClienteDocumento ;
      private bool n580PropostaResponsavelDocumento ;
      private bool n505PropostaPacienteClienteRazaoSocial ;
      private bool n329PropostaStatus ;
      private bool n788PropostaMaiorValorRecomendado ;
      private bool n784PropostaMaiorScore_F ;
      private bool n649PropostaMaxReembolsoId_F ;
      private bool BRK8D4 ;
      private string AV47OptionsJson ;
      private string AV48OptionsDescJson ;
      private string AV49OptionIndexesJson ;
      private string AV22TFPropostaStatus_SelsJson ;
      private string AV44DDOName ;
      private string AV45SearchTxtParms ;
      private string AV46SearchTxtTo ;
      private string AV28SearchTxt ;
      private string AV50FilterFullText ;
      private string AV83TFPropostaClinicaNome ;
      private string AV84TFPropostaClinicaNome_Sel ;
      private string AV85TFPropostaPacienteClienteRazaoSocial ;
      private string AV86TFPropostaPacienteClienteRazaoSocial_Sel ;
      private string AV51DynamicFiltersSelector1 ;
      private string AV92PropostaResponsavelDocumento1 ;
      private string AV93PropostaPacienteClienteDocumento1 ;
      private string AV94PropostaClinicaDocumento1 ;
      private string AV95ConvenioCategoriaDescricao1 ;
      private string AV55DynamicFiltersSelector2 ;
      private string AV97PropostaResponsavelDocumento2 ;
      private string AV98PropostaPacienteClienteDocumento2 ;
      private string AV99PropostaClinicaDocumento2 ;
      private string AV100ConvenioCategoriaDescricao2 ;
      private string AV59DynamicFiltersSelector3 ;
      private string AV102PropostaResponsavelDocumento3 ;
      private string AV103PropostaPacienteClienteDocumento3 ;
      private string AV104PropostaClinicaDocumento3 ;
      private string AV105ConvenioCategoriaDescricao3 ;
      private string AV108Propostawwds_1_filterfulltext ;
      private string AV109Propostawwds_2_dynamicfiltersselector1 ;
      private string AV112Propostawwds_5_propostaresponsaveldocumento1 ;
      private string AV113Propostawwds_6_propostapacienteclientedocumento1 ;
      private string AV114Propostawwds_7_propostaclinicadocumento1 ;
      private string AV115Propostawwds_8_conveniocategoriadescricao1 ;
      private string AV117Propostawwds_10_dynamicfiltersselector2 ;
      private string AV120Propostawwds_13_propostaresponsaveldocumento2 ;
      private string AV121Propostawwds_14_propostapacienteclientedocumento2 ;
      private string AV122Propostawwds_15_propostaclinicadocumento2 ;
      private string AV123Propostawwds_16_conveniocategoriadescricao2 ;
      private string AV125Propostawwds_18_dynamicfiltersselector3 ;
      private string AV128Propostawwds_21_propostaresponsaveldocumento3 ;
      private string AV129Propostawwds_22_propostapacienteclientedocumento3 ;
      private string AV130Propostawwds_23_propostaclinicadocumento3 ;
      private string AV131Propostawwds_24_conveniocategoriadescricao3 ;
      private string AV132Propostawwds_25_tfpropostaclinicanome ;
      private string AV133Propostawwds_26_tfpropostaclinicanome_sel ;
      private string AV135Propostawwds_28_tfpropostapacienteclienterazaosocial ;
      private string AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel ;
      private string lV108Propostawwds_1_filterfulltext ;
      private string lV112Propostawwds_5_propostaresponsaveldocumento1 ;
      private string lV113Propostawwds_6_propostapacienteclientedocumento1 ;
      private string lV114Propostawwds_7_propostaclinicadocumento1 ;
      private string lV115Propostawwds_8_conveniocategoriadescricao1 ;
      private string lV120Propostawwds_13_propostaresponsaveldocumento2 ;
      private string lV121Propostawwds_14_propostapacienteclientedocumento2 ;
      private string lV122Propostawwds_15_propostaclinicadocumento2 ;
      private string lV123Propostawwds_16_conveniocategoriadescricao2 ;
      private string lV128Propostawwds_21_propostaresponsaveldocumento3 ;
      private string lV129Propostawwds_22_propostapacienteclientedocumento3 ;
      private string lV130Propostawwds_23_propostaclinicadocumento3 ;
      private string lV131Propostawwds_24_conveniocategoriadescricao3 ;
      private string lV132Propostawwds_25_tfpropostaclinicanome ;
      private string lV135Propostawwds_28_tfpropostapacienteclienterazaosocial ;
      private string A329PropostaStatus ;
      private string A580PropostaResponsavelDocumento ;
      private string A540PropostaPacienteClienteDocumento ;
      private string A652PropostaClinicaDocumento ;
      private string A494ConvenioCategoriaDescricao ;
      private string A643PropostaClinicaNome ;
      private string A505PropostaPacienteClienteRazaoSocial ;
      private string AV33Option ;
      private IGxSession AV39Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV34Options ;
      private GxSimpleCollection<string> AV36OptionsDesc ;
      private GxSimpleCollection<string> AV37OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private GxSimpleCollection<string> AV23TFPropostaStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV43GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV134Propostawwds_27_tfpropostastatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P008D12_A493ConvenioCategoriaId ;
      private bool[] P008D12_n493ConvenioCategoriaId ;
      private int[] P008D12_A504PropostaPacienteClienteId ;
      private bool[] P008D12_n504PropostaPacienteClienteId ;
      private int[] P008D12_A553PropostaResponsavelId ;
      private bool[] P008D12_n553PropostaResponsavelId ;
      private int[] P008D12_A642PropostaClinicaId ;
      private bool[] P008D12_n642PropostaClinicaId ;
      private string[] P008D12_A643PropostaClinicaNome ;
      private bool[] P008D12_n643PropostaClinicaNome ;
      private short[] P008D12_A328PropostaCratedBy ;
      private bool[] P008D12_n328PropostaCratedBy ;
      private string[] P008D12_A494ConvenioCategoriaDescricao ;
      private bool[] P008D12_n494ConvenioCategoriaDescricao ;
      private string[] P008D12_A652PropostaClinicaDocumento ;
      private bool[] P008D12_n652PropostaClinicaDocumento ;
      private string[] P008D12_A540PropostaPacienteClienteDocumento ;
      private bool[] P008D12_n540PropostaPacienteClienteDocumento ;
      private string[] P008D12_A580PropostaResponsavelDocumento ;
      private bool[] P008D12_n580PropostaResponsavelDocumento ;
      private string[] P008D12_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P008D12_n505PropostaPacienteClienteRazaoSocial ;
      private string[] P008D12_A329PropostaStatus ;
      private bool[] P008D12_n329PropostaStatus ;
      private decimal[] P008D12_A788PropostaMaiorValorRecomendado ;
      private bool[] P008D12_n788PropostaMaiorValorRecomendado ;
      private short[] P008D12_A784PropostaMaiorScore_F ;
      private bool[] P008D12_n784PropostaMaiorScore_F ;
      private int[] P008D12_A323PropostaId ;
      private int[] P008D12_A649PropostaMaxReembolsoId_F ;
      private bool[] P008D12_n649PropostaMaxReembolsoId_F ;
      private int[] P008D23_A493ConvenioCategoriaId ;
      private bool[] P008D23_n493ConvenioCategoriaId ;
      private int[] P008D23_A504PropostaPacienteClienteId ;
      private bool[] P008D23_n504PropostaPacienteClienteId ;
      private int[] P008D23_A553PropostaResponsavelId ;
      private bool[] P008D23_n553PropostaResponsavelId ;
      private int[] P008D23_A642PropostaClinicaId ;
      private bool[] P008D23_n642PropostaClinicaId ;
      private string[] P008D23_A505PropostaPacienteClienteRazaoSocial ;
      private bool[] P008D23_n505PropostaPacienteClienteRazaoSocial ;
      private short[] P008D23_A328PropostaCratedBy ;
      private bool[] P008D23_n328PropostaCratedBy ;
      private string[] P008D23_A494ConvenioCategoriaDescricao ;
      private bool[] P008D23_n494ConvenioCategoriaDescricao ;
      private string[] P008D23_A652PropostaClinicaDocumento ;
      private bool[] P008D23_n652PropostaClinicaDocumento ;
      private string[] P008D23_A540PropostaPacienteClienteDocumento ;
      private bool[] P008D23_n540PropostaPacienteClienteDocumento ;
      private string[] P008D23_A580PropostaResponsavelDocumento ;
      private bool[] P008D23_n580PropostaResponsavelDocumento ;
      private string[] P008D23_A329PropostaStatus ;
      private bool[] P008D23_n329PropostaStatus ;
      private string[] P008D23_A643PropostaClinicaNome ;
      private bool[] P008D23_n643PropostaClinicaNome ;
      private decimal[] P008D23_A788PropostaMaiorValorRecomendado ;
      private bool[] P008D23_n788PropostaMaiorValorRecomendado ;
      private short[] P008D23_A784PropostaMaiorScore_F ;
      private bool[] P008D23_n784PropostaMaiorScore_F ;
      private int[] P008D23_A323PropostaId ;
      private int[] P008D23_A649PropostaMaxReembolsoId_F ;
      private bool[] P008D23_n649PropostaMaxReembolsoId_F ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class propostawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008D12( IGxContext context ,
                                              string A329PropostaStatus ,
                                              GxSimpleCollection<string> AV134Propostawwds_27_tfpropostastatus_sels ,
                                              string AV109Propostawwds_2_dynamicfiltersselector1 ,
                                              short AV110Propostawwds_3_dynamicfiltersoperator1 ,
                                              string AV112Propostawwds_5_propostaresponsaveldocumento1 ,
                                              string AV113Propostawwds_6_propostapacienteclientedocumento1 ,
                                              string AV114Propostawwds_7_propostaclinicadocumento1 ,
                                              string AV115Propostawwds_8_conveniocategoriadescricao1 ,
                                              bool AV116Propostawwds_9_dynamicfiltersenabled2 ,
                                              string AV117Propostawwds_10_dynamicfiltersselector2 ,
                                              short AV118Propostawwds_11_dynamicfiltersoperator2 ,
                                              string AV120Propostawwds_13_propostaresponsaveldocumento2 ,
                                              string AV121Propostawwds_14_propostapacienteclientedocumento2 ,
                                              string AV122Propostawwds_15_propostaclinicadocumento2 ,
                                              string AV123Propostawwds_16_conveniocategoriadescricao2 ,
                                              bool AV124Propostawwds_17_dynamicfiltersenabled3 ,
                                              string AV125Propostawwds_18_dynamicfiltersselector3 ,
                                              short AV126Propostawwds_19_dynamicfiltersoperator3 ,
                                              string AV128Propostawwds_21_propostaresponsaveldocumento3 ,
                                              string AV129Propostawwds_22_propostapacienteclientedocumento3 ,
                                              string AV130Propostawwds_23_propostaclinicadocumento3 ,
                                              string AV131Propostawwds_24_conveniocategoriadescricao3 ,
                                              string AV133Propostawwds_26_tfpropostaclinicanome_sel ,
                                              string AV132Propostawwds_25_tfpropostaclinicanome ,
                                              int AV134Propostawwds_27_tfpropostastatus_sels_Count ,
                                              string AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV135Propostawwds_28_tfpropostapacienteclienterazaosocial ,
                                              bool AV9WWPContext_gxTpr_Iscliente ,
                                              string A580PropostaResponsavelDocumento ,
                                              string A540PropostaPacienteClienteDocumento ,
                                              string A652PropostaClinicaDocumento ,
                                              string A494ConvenioCategoriaDescricao ,
                                              string A643PropostaClinicaNome ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              short A328PropostaCratedBy ,
                                              short AV9WWPContext_gxTpr_Secuserclienteid ,
                                              string AV108Propostawwds_1_filterfulltext ,
                                              short A784PropostaMaiorScore_F ,
                                              decimal A788PropostaMaiorValorRecomendado ,
                                              int AV111Propostawwds_4_propostamaxreembolsoid_f1 ,
                                              int A649PropostaMaxReembolsoId_F ,
                                              int AV119Propostawwds_12_propostamaxreembolsoid_f2 ,
                                              int AV127Propostawwds_20_propostamaxreembolsoid_f3 ,
                                              short AV137Propostawwds_30_tfpropostamaiorscore_f ,
                                              short AV138Propostawwds_31_tfpropostamaiorscore_f_to ,
                                              decimal AV139Propostawwds_32_tfpropostamaiorvalorrecomendado ,
                                              decimal AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[92];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ConvenioCategoriaId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T5.ClienteRazaoSocial AS PropostaClinicaNome, T1.PropostaCratedBy, T2.ConvenioCategoriaDescricao, T5.ClienteDocumento AS PropostaClinicaDocumento, T3.ClienteDocumento AS PropostaPacienteClienteDocumento, T4.ClienteDocumento AS PropostaResponsavelDocumento, T3.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaStatus, COALESCE( T6.PropostaMaiorValorRecomendado, 0) AS PropostaMaiorValorRecomendado, COALESCE( T6.PropostaMaiorScore_F, 0) AS PropostaMaiorScore_F, T1.PropostaId, COALESCE( T7.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM ((((((Proposta T1 LEFT JOIN ConvenioCategoria T2 ON T2.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaClinicaId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T9.PropostaSerasaScoreUltimaData_F, 0) > COALESCE( T10.PropostaSerasaScoreUltimaData_F, 0) THEN COALESCE( T9.PropostaSerasaScoreUltimaData_F, 0) ELSE COALESCE( T10.PropostaSerasaScoreUltimaData_F, 0) END AS PropostaMaiorScore_F, T8.PropostaId, CASE  WHEN COALESCE( T11.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) > COALESCE( T12.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) THEN COALESCE( T11.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) ELSE COALESCE( T12.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) END AS PropostaMaiorValorRecomendado FROM ((((Proposta T8 LEFT JOIN LATERAL (SELECT MAX(T13.SerasaScore) AS PropostaSerasaScoreUltimaData_F, COALESCE( T14.SerasaUltimaData_F,";
         scmdbuf += " DATE '00010101') AS SerasaUltimaData_F, T13.ClienteId FROM (Serasa T13 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T13.ClienteId = ClienteId GROUP BY ClienteId ) T14 ON T14.ClienteId = T13.ClienteId) WHERE (T8.PropostaPacienteClienteId = T13.ClienteId) AND (T13.SerasaCreatedAt = COALESCE( T14.SerasaUltimaData_F, DATE '00010101')) GROUP BY T14.SerasaUltimaData_F, T13.ClienteId ) T9 ON T9.ClienteId = T8.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T13.SerasaScore) AS PropostaSerasaScoreUltimaData_F, COALESCE( T14.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T13.ClienteId FROM (Serasa T13 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T13.ClienteId = ClienteId GROUP BY ClienteId ) T14 ON T14.ClienteId = T13.ClienteId) WHERE (T8.PropostaPacienteClienteId = T13.ClienteId) AND (T13.SerasaCreatedAt = COALESCE( T14.SerasaUltimaData_F, DATE '00010101')) GROUP BY T14.SerasaUltimaData_F, T13.ClienteId ) T10 ON T10.ClienteId = T8.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T13.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T14.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T13.ClienteId FROM (Serasa T13 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T13.ClienteId = ClienteId GROUP BY ClienteId ) T14 ON T14.ClienteId = T13.ClienteId) WHERE (T8.PropostaPacienteClienteId = T13.ClienteId) AND (T13.SerasaCreatedAt = COALESCE( T14.SerasaUltimaData_F, DATE '00010101')) GROUP BY T14.SerasaUltimaData_F, T13.ClienteId ) T11 ON T11.ClienteId = T8.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T13.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F,";
         scmdbuf += " COALESCE( T14.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T13.ClienteId FROM (Serasa T13 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T13.ClienteId = ClienteId GROUP BY ClienteId ) T14 ON T14.ClienteId = T13.ClienteId) WHERE (T8.PropostaPacienteClienteId = T13.ClienteId) AND (T13.SerasaCreatedAt = COALESCE( T14.SerasaUltimaData_F, DATE '00010101')) GROUP BY T14.SerasaUltimaData_F, T13.ClienteId ) T12 ON T12.ClienteId = T8.PropostaPacienteClienteId) ) T6 ON T6.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T7 ON T7.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV108Propostawwds_1_filterfulltext))=0) or ( ( T5.ClienteRazaoSocial like '%' || :lV108Propostawwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')) or ( T3.ClienteRazaoSocial like '%' || :lV108Propostawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T6.PropostaMaiorScore_F, 0),'9999'), 2) like '%' || :lV108Propostawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T6.PropostaMaiorValorRecomendado, 0),'999999999999990.99'), 2) like '%' || :lV108Propostawwds_1_filterfulltext)))");
         AddWhere(sWhereString, "(Not ( :AV109Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV110Propostawwds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV111Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) < :AV111Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV109Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV110Propostawwds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV111Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) = :AV111Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV109Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV110Propostawwds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV111Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) > :AV111Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV116Propostawwds_9_dynamicfiltersenabled2 and :AV117Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Propostawwds_11_dynamicfiltersoperator2 = 0 and ( Not (:AV119Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) < :AV119Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV116Propostawwds_9_dynamicfiltersenabled2 and :AV117Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Propostawwds_11_dynamicfiltersoperator2 = 1 and ( Not (:AV119Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) = :AV119Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV116Propostawwds_9_dynamicfiltersenabled2 and :AV117Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Propostawwds_11_dynamicfiltersoperator2 = 2 and ( Not (:AV119Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) > :AV119Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV124Propostawwds_17_dynamicfiltersenabled3 and :AV125Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV126Propostawwds_19_dynamicfiltersoperator3 = 0 and ( Not (:AV127Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) < :AV127Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV124Propostawwds_17_dynamicfiltersenabled3 and :AV125Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV126Propostawwds_19_dynamicfiltersoperator3 = 1 and ( Not (:AV127Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) = :AV127Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV124Propostawwds_17_dynamicfiltersenabled3 and :AV125Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV126Propostawwds_19_dynamicfiltersoperator3 = 2 and ( Not (:AV127Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) > :AV127Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "((:AV137Propostawwds_30_tfpropostamaiorscore_f = 0) or ( COALESCE( T6.PropostaMaiorScore_F, 0) >= :AV137Propostawwds_30_tfpropostamaiorscore_f))");
         AddWhere(sWhereString, "((:AV138Propostawwds_31_tfpropostamaiorscore_f_to = 0) or ( COALESCE( T6.PropostaMaiorScore_F, 0) <= :AV138Propostawwds_31_tfpropostamaiorscore_f_to))");
         AddWhere(sWhereString, "((:AV139Propostawwds_32_tfpropostamaiorvalorrecomendado = 0) or ( COALESCE( T6.PropostaMaiorValorRecomendado, 0) >= :AV139Propostawwds_32_tfpropostamaiorvalorrecomendado))");
         AddWhere(sWhereString, "((:AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to = 0) or ( COALESCE( T6.PropostaMaiorValorRecomendado, 0) <= :AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to))");
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostawwds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV112Propostawwds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int1[63] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostawwds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV112Propostawwds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int1[64] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostawwds_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV113Propostawwds_6_propostapacienteclientedocumento1)");
         }
         else
         {
            GXv_int1[65] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostawwds_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV113Propostawwds_6_propostapacienteclientedocumento1)");
         }
         else
         {
            GXv_int1[66] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Propostawwds_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV114Propostawwds_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int1[67] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Propostawwds_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV114Propostawwds_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int1[68] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostawwds_8_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV115Propostawwds_8_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int1[69] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostawwds_8_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV115Propostawwds_8_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int1[70] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostawwds_13_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV120Propostawwds_13_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int1[71] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostawwds_13_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV120Propostawwds_13_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int1[72] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Propostawwds_14_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV121Propostawwds_14_propostapacienteclientedocumento2)");
         }
         else
         {
            GXv_int1[73] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Propostawwds_14_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV121Propostawwds_14_propostapacienteclientedocumento2)");
         }
         else
         {
            GXv_int1[74] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Propostawwds_15_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV122Propostawwds_15_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int1[75] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Propostawwds_15_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV122Propostawwds_15_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int1[76] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Propostawwds_16_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV123Propostawwds_16_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int1[77] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Propostawwds_16_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV123Propostawwds_16_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int1[78] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Propostawwds_21_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV128Propostawwds_21_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int1[79] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Propostawwds_21_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV128Propostawwds_21_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int1[80] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Propostawwds_22_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV129Propostawwds_22_propostapacienteclientedocumento3)");
         }
         else
         {
            GXv_int1[81] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Propostawwds_22_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV129Propostawwds_22_propostapacienteclientedocumento3)");
         }
         else
         {
            GXv_int1[82] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Propostawwds_23_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV130Propostawwds_23_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int1[83] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Propostawwds_23_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV130Propostawwds_23_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int1[84] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Propostawwds_24_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV131Propostawwds_24_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int1[85] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Propostawwds_24_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV131Propostawwds_24_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int1[86] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Propostawwds_26_tfpropostaclinicanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Propostawwds_25_tfpropostaclinicanome)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV132Propostawwds_25_tfpropostaclinicanome)");
         }
         else
         {
            GXv_int1[87] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Propostawwds_26_tfpropostaclinicanome_sel)) && ! ( StringUtil.StrCmp(AV133Propostawwds_26_tfpropostaclinicanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV133Propostawwds_26_tfpropostaclinicanome_sel))");
         }
         else
         {
            GXv_int1[88] = 1;
         }
         if ( StringUtil.StrCmp(AV133Propostawwds_26_tfpropostaclinicanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( AV134Propostawwds_27_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV134Propostawwds_27_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Propostawwds_28_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV135Propostawwds_28_tfpropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int1[89] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel))");
         }
         else
         {
            GXv_int1[90] = 1;
         }
         if ( StringUtil.StrCmp(AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( AV9WWPContext_gxTpr_Iscliente )
         {
            AddWhere(sWhereString, "(T1.PropostaCratedBy = :AV9WWPCo_1Secuserclienteid)");
         }
         else
         {
            GXv_int1[91] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T5.ClienteRazaoSocial";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008D23( IGxContext context ,
                                              string A329PropostaStatus ,
                                              GxSimpleCollection<string> AV134Propostawwds_27_tfpropostastatus_sels ,
                                              string AV109Propostawwds_2_dynamicfiltersselector1 ,
                                              short AV110Propostawwds_3_dynamicfiltersoperator1 ,
                                              string AV112Propostawwds_5_propostaresponsaveldocumento1 ,
                                              string AV113Propostawwds_6_propostapacienteclientedocumento1 ,
                                              string AV114Propostawwds_7_propostaclinicadocumento1 ,
                                              string AV115Propostawwds_8_conveniocategoriadescricao1 ,
                                              bool AV116Propostawwds_9_dynamicfiltersenabled2 ,
                                              string AV117Propostawwds_10_dynamicfiltersselector2 ,
                                              short AV118Propostawwds_11_dynamicfiltersoperator2 ,
                                              string AV120Propostawwds_13_propostaresponsaveldocumento2 ,
                                              string AV121Propostawwds_14_propostapacienteclientedocumento2 ,
                                              string AV122Propostawwds_15_propostaclinicadocumento2 ,
                                              string AV123Propostawwds_16_conveniocategoriadescricao2 ,
                                              bool AV124Propostawwds_17_dynamicfiltersenabled3 ,
                                              string AV125Propostawwds_18_dynamicfiltersselector3 ,
                                              short AV126Propostawwds_19_dynamicfiltersoperator3 ,
                                              string AV128Propostawwds_21_propostaresponsaveldocumento3 ,
                                              string AV129Propostawwds_22_propostapacienteclientedocumento3 ,
                                              string AV130Propostawwds_23_propostaclinicadocumento3 ,
                                              string AV131Propostawwds_24_conveniocategoriadescricao3 ,
                                              string AV133Propostawwds_26_tfpropostaclinicanome_sel ,
                                              string AV132Propostawwds_25_tfpropostaclinicanome ,
                                              int AV134Propostawwds_27_tfpropostastatus_sels_Count ,
                                              string AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel ,
                                              string AV135Propostawwds_28_tfpropostapacienteclienterazaosocial ,
                                              bool AV9WWPContext_gxTpr_Iscliente ,
                                              string A580PropostaResponsavelDocumento ,
                                              string A540PropostaPacienteClienteDocumento ,
                                              string A652PropostaClinicaDocumento ,
                                              string A494ConvenioCategoriaDescricao ,
                                              string A643PropostaClinicaNome ,
                                              string A505PropostaPacienteClienteRazaoSocial ,
                                              short A328PropostaCratedBy ,
                                              short AV9WWPContext_gxTpr_Secuserclienteid ,
                                              string AV108Propostawwds_1_filterfulltext ,
                                              short A784PropostaMaiorScore_F ,
                                              decimal A788PropostaMaiorValorRecomendado ,
                                              int AV111Propostawwds_4_propostamaxreembolsoid_f1 ,
                                              int A649PropostaMaxReembolsoId_F ,
                                              int AV119Propostawwds_12_propostamaxreembolsoid_f2 ,
                                              int AV127Propostawwds_20_propostamaxreembolsoid_f3 ,
                                              short AV137Propostawwds_30_tfpropostamaiorscore_f ,
                                              short AV138Propostawwds_31_tfpropostamaiorscore_f_to ,
                                              decimal AV139Propostawwds_32_tfpropostamaiorvalorrecomendado ,
                                              decimal AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[92];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ConvenioCategoriaId, T1.PropostaPacienteClienteId AS PropostaPacienteClienteId, T1.PropostaResponsavelId AS PropostaResponsavelId, T1.PropostaClinicaId AS PropostaClinicaId, T3.ClienteRazaoSocial AS PropostaPacienteClienteRazaoSocial, T1.PropostaCratedBy, T2.ConvenioCategoriaDescricao, T5.ClienteDocumento AS PropostaClinicaDocumento, T3.ClienteDocumento AS PropostaPacienteClienteDocumento, T4.ClienteDocumento AS PropostaResponsavelDocumento, T1.PropostaStatus, T5.ClienteRazaoSocial AS PropostaClinicaNome, COALESCE( T6.PropostaMaiorValorRecomendado, 0) AS PropostaMaiorValorRecomendado, COALESCE( T6.PropostaMaiorScore_F, 0) AS PropostaMaiorScore_F, T1.PropostaId, COALESCE( T7.PropostaMaxReembolsoId_F, 0) AS PropostaMaxReembolsoId_F FROM ((((((Proposta T1 LEFT JOIN ConvenioCategoria T2 ON T2.ConvenioCategoriaId = T1.ConvenioCategoriaId) LEFT JOIN Cliente T3 ON T3.ClienteId = T1.PropostaPacienteClienteId) LEFT JOIN Cliente T4 ON T4.ClienteId = T1.PropostaResponsavelId) LEFT JOIN Cliente T5 ON T5.ClienteId = T1.PropostaClinicaId) LEFT JOIN (SELECT CASE  WHEN COALESCE( T9.PropostaSerasaScoreUltimaData_F, 0) > COALESCE( T10.PropostaSerasaScoreUltimaData_F, 0) THEN COALESCE( T9.PropostaSerasaScoreUltimaData_F, 0) ELSE COALESCE( T10.PropostaSerasaScoreUltimaData_F, 0) END AS PropostaMaiorScore_F, T8.PropostaId, CASE  WHEN COALESCE( T11.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) > COALESCE( T12.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) THEN COALESCE( T11.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) ELSE COALESCE( T12.PropostaResponsavelSerasaUltimoValorRecomendado_F, 0) END AS PropostaMaiorValorRecomendado FROM ((((Proposta T8 LEFT JOIN LATERAL (SELECT MAX(T13.SerasaScore) AS PropostaSerasaScoreUltimaData_F, COALESCE( T14.SerasaUltimaData_F,";
         scmdbuf += " DATE '00010101') AS SerasaUltimaData_F, T13.ClienteId FROM (Serasa T13 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T13.ClienteId = ClienteId GROUP BY ClienteId ) T14 ON T14.ClienteId = T13.ClienteId) WHERE (T8.PropostaPacienteClienteId = T13.ClienteId) AND (T13.SerasaCreatedAt = COALESCE( T14.SerasaUltimaData_F, DATE '00010101')) GROUP BY T14.SerasaUltimaData_F, T13.ClienteId ) T9 ON T9.ClienteId = T8.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T13.SerasaScore) AS PropostaSerasaScoreUltimaData_F, COALESCE( T14.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T13.ClienteId FROM (Serasa T13 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T13.ClienteId = ClienteId GROUP BY ClienteId ) T14 ON T14.ClienteId = T13.ClienteId) WHERE (T8.PropostaPacienteClienteId = T13.ClienteId) AND (T13.SerasaCreatedAt = COALESCE( T14.SerasaUltimaData_F, DATE '00010101')) GROUP BY T14.SerasaUltimaData_F, T13.ClienteId ) T10 ON T10.ClienteId = T8.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T13.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F, COALESCE( T14.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T13.ClienteId FROM (Serasa T13 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T13.ClienteId = ClienteId GROUP BY ClienteId ) T14 ON T14.ClienteId = T13.ClienteId) WHERE (T8.PropostaPacienteClienteId = T13.ClienteId) AND (T13.SerasaCreatedAt = COALESCE( T14.SerasaUltimaData_F, DATE '00010101')) GROUP BY T14.SerasaUltimaData_F, T13.ClienteId ) T11 ON T11.ClienteId = T8.PropostaPacienteClienteId) LEFT JOIN LATERAL (SELECT MAX(T13.SerasaValorLimiteRecomendado) AS PropostaResponsavelSerasaUltimoValorRecomendado_F,";
         scmdbuf += " COALESCE( T14.SerasaUltimaData_F, DATE '00010101') AS SerasaUltimaData_F, T13.ClienteId FROM (Serasa T13 LEFT JOIN LATERAL (SELECT MAX(SerasaCreatedAt) AS SerasaUltimaData_F, ClienteId FROM Serasa WHERE T13.ClienteId = ClienteId GROUP BY ClienteId ) T14 ON T14.ClienteId = T13.ClienteId) WHERE (T8.PropostaPacienteClienteId = T13.ClienteId) AND (T13.SerasaCreatedAt = COALESCE( T14.SerasaUltimaData_F, DATE '00010101')) GROUP BY T14.SerasaUltimaData_F, T13.ClienteId ) T12 ON T12.ClienteId = T8.PropostaPacienteClienteId) ) T6 ON T6.PropostaId = T1.PropostaId) LEFT JOIN LATERAL (SELECT MAX(ReembolsoId) AS PropostaMaxReembolsoId_F, ReembolsoPropostaId FROM Reembolso WHERE T1.PropostaId = ReembolsoPropostaId GROUP BY ReembolsoPropostaId ) T7 ON T7.ReembolsoPropostaId = T1.PropostaId)";
         AddWhere(sWhereString, "((char_length(trim(trailing ' ' from :AV108Propostawwds_1_filterfulltext))=0) or ( ( T5.ClienteRazaoSocial like '%' || :lV108Propostawwds_1_filterfulltext) or ( 'pendente aprovação' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'PENDENTE')) or ( 'em análise' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'EM_ANALISE')) or ( 'aprovado' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'APROVADO')) or ( 'rejeitado' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REJEITADO')) or ( 'revisão' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'REVISAO')) or ( 'cancelado' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'CANCELADO')) or ( 'aguardando assinatura' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AGUARDANDO_ASSINATURA')) or ( 'análise reprovada' like '%' || LOWER(:lV108Propostawwds_1_filterfulltext) and T1.PropostaStatus = ( 'AnaliseReprovada')) or ( T3.ClienteRazaoSocial like '%' || :lV108Propostawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T6.PropostaMaiorScore_F, 0),'9999'), 2) like '%' || :lV108Propostawwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(COALESCE( T6.PropostaMaiorValorRecomendado, 0),'999999999999990.99'), 2) like '%' || :lV108Propostawwds_1_filterfulltext)))");
         AddWhere(sWhereString, "(Not ( :AV109Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV110Propostawwds_3_dynamicfiltersoperator1 = 0 and ( Not (:AV111Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) < :AV111Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV109Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV110Propostawwds_3_dynamicfiltersoperator1 = 1 and ( Not (:AV111Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) = :AV111Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV109Propostawwds_2_dynamicfiltersselector1 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV110Propostawwds_3_dynamicfiltersoperator1 = 2 and ( Not (:AV111Propostawwds_4_propostamaxreembolsoid_f1 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) > :AV111Propostawwds_4_propostamaxreembolsoid_f1))");
         AddWhere(sWhereString, "(Not ( :AV116Propostawwds_9_dynamicfiltersenabled2 and :AV117Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Propostawwds_11_dynamicfiltersoperator2 = 0 and ( Not (:AV119Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) < :AV119Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV116Propostawwds_9_dynamicfiltersenabled2 and :AV117Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Propostawwds_11_dynamicfiltersoperator2 = 1 and ( Not (:AV119Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) = :AV119Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV116Propostawwds_9_dynamicfiltersenabled2 and :AV117Propostawwds_10_dynamicfiltersselector2 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV118Propostawwds_11_dynamicfiltersoperator2 = 2 and ( Not (:AV119Propostawwds_12_propostamaxreembolsoid_f2 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) > :AV119Propostawwds_12_propostamaxreembolsoid_f2))");
         AddWhere(sWhereString, "(Not ( :AV124Propostawwds_17_dynamicfiltersenabled3 and :AV125Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV126Propostawwds_19_dynamicfiltersoperator3 = 0 and ( Not (:AV127Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) < :AV127Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV124Propostawwds_17_dynamicfiltersenabled3 and :AV125Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV126Propostawwds_19_dynamicfiltersoperator3 = 1 and ( Not (:AV127Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) = :AV127Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "(Not ( :AV124Propostawwds_17_dynamicfiltersenabled3 and :AV125Propostawwds_18_dynamicfiltersselector3 = ( 'PROPOSTAMAXREEMBOLSOID_F') and :AV126Propostawwds_19_dynamicfiltersoperator3 = 2 and ( Not (:AV127Propostawwds_20_propostamaxreembolsoid_f3 = 0))) or ( COALESCE( T7.PropostaMaxReembolsoId_F, 0) > :AV127Propostawwds_20_propostamaxreembolsoid_f3))");
         AddWhere(sWhereString, "((:AV137Propostawwds_30_tfpropostamaiorscore_f = 0) or ( COALESCE( T6.PropostaMaiorScore_F, 0) >= :AV137Propostawwds_30_tfpropostamaiorscore_f))");
         AddWhere(sWhereString, "((:AV138Propostawwds_31_tfpropostamaiorscore_f_to = 0) or ( COALESCE( T6.PropostaMaiorScore_F, 0) <= :AV138Propostawwds_31_tfpropostamaiorscore_f_to))");
         AddWhere(sWhereString, "((:AV139Propostawwds_32_tfpropostamaiorvalorrecomendado = 0) or ( COALESCE( T6.PropostaMaiorValorRecomendado, 0) >= :AV139Propostawwds_32_tfpropostamaiorvalorrecomendado))");
         AddWhere(sWhereString, "((:AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to = 0) or ( COALESCE( T6.PropostaMaiorValorRecomendado, 0) <= :AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to))");
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostawwds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV112Propostawwds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int3[63] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Propostawwds_5_propostaresponsaveldocumento1)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV112Propostawwds_5_propostaresponsaveldocumento1)");
         }
         else
         {
            GXv_int3[64] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostawwds_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV113Propostawwds_6_propostapacienteclientedocumento1)");
         }
         else
         {
            GXv_int3[65] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Propostawwds_6_propostapacienteclientedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV113Propostawwds_6_propostapacienteclientedocumento1)");
         }
         else
         {
            GXv_int3[66] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Propostawwds_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV114Propostawwds_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int3[67] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Propostawwds_7_propostaclinicadocumento1)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV114Propostawwds_7_propostaclinicadocumento1)");
         }
         else
         {
            GXv_int3[68] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostawwds_8_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV115Propostawwds_8_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int3[69] = 1;
         }
         if ( ( StringUtil.StrCmp(AV109Propostawwds_2_dynamicfiltersselector1, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV110Propostawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Propostawwds_8_conveniocategoriadescricao1)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV115Propostawwds_8_conveniocategoriadescricao1)");
         }
         else
         {
            GXv_int3[70] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostawwds_13_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV120Propostawwds_13_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int3[71] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Propostawwds_13_propostaresponsaveldocumento2)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV120Propostawwds_13_propostaresponsaveldocumento2)");
         }
         else
         {
            GXv_int3[72] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Propostawwds_14_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV121Propostawwds_14_propostapacienteclientedocumento2)");
         }
         else
         {
            GXv_int3[73] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV121Propostawwds_14_propostapacienteclientedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV121Propostawwds_14_propostapacienteclientedocumento2)");
         }
         else
         {
            GXv_int3[74] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Propostawwds_15_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV122Propostawwds_15_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int3[75] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Propostawwds_15_propostaclinicadocumento2)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV122Propostawwds_15_propostaclinicadocumento2)");
         }
         else
         {
            GXv_int3[76] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Propostawwds_16_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV123Propostawwds_16_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int3[77] = 1;
         }
         if ( AV116Propostawwds_9_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV117Propostawwds_10_dynamicfiltersselector2, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV118Propostawwds_11_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Propostawwds_16_conveniocategoriadescricao2)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV123Propostawwds_16_conveniocategoriadescricao2)");
         }
         else
         {
            GXv_int3[78] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Propostawwds_21_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like :lV128Propostawwds_21_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int3[79] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "PROPOSTARESPONSAVELDOCUMENTO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Propostawwds_21_propostaresponsaveldocumento3)) ) )
         {
            AddWhere(sWhereString, "(T4.ClienteDocumento like '%' || :lV128Propostawwds_21_propostaresponsaveldocumento3)");
         }
         else
         {
            GXv_int3[80] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Propostawwds_22_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like :lV129Propostawwds_22_propostapacienteclientedocumento3)");
         }
         else
         {
            GXv_int3[81] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "PROPOSTAPACIENTECLIENTEDOCUMENTO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Propostawwds_22_propostapacienteclientedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteDocumento like '%' || :lV129Propostawwds_22_propostapacienteclientedocumento3)");
         }
         else
         {
            GXv_int3[82] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Propostawwds_23_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like :lV130Propostawwds_23_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int3[83] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "PROPOSTACLINICADOCUMENTO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Propostawwds_23_propostaclinicadocumento3)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteDocumento like '%' || :lV130Propostawwds_23_propostaclinicadocumento3)");
         }
         else
         {
            GXv_int3[84] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Propostawwds_24_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like :lV131Propostawwds_24_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int3[85] = 1;
         }
         if ( AV124Propostawwds_17_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV125Propostawwds_18_dynamicfiltersselector3, "CONVENIOCATEGORIADESCRICAO") == 0 ) && ( AV126Propostawwds_19_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Propostawwds_24_conveniocategoriadescricao3)) ) )
         {
            AddWhere(sWhereString, "(T2.ConvenioCategoriaDescricao like '%' || :lV131Propostawwds_24_conveniocategoriadescricao3)");
         }
         else
         {
            GXv_int3[86] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Propostawwds_26_tfpropostaclinicanome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Propostawwds_25_tfpropostaclinicanome)) ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial like :lV132Propostawwds_25_tfpropostaclinicanome)");
         }
         else
         {
            GXv_int3[87] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Propostawwds_26_tfpropostaclinicanome_sel)) && ! ( StringUtil.StrCmp(AV133Propostawwds_26_tfpropostaclinicanome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial = ( :AV133Propostawwds_26_tfpropostaclinicanome_sel))");
         }
         else
         {
            GXv_int3[88] = 1;
         }
         if ( StringUtil.StrCmp(AV133Propostawwds_26_tfpropostaclinicanome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T5.ClienteRazaoSocial))=0))");
         }
         if ( AV134Propostawwds_27_tfpropostastatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV134Propostawwds_27_tfpropostastatus_sels, "T1.PropostaStatus IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Propostawwds_28_tfpropostapacienteclienterazaosocial)) ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial like :lV135Propostawwds_28_tfpropostapacienteclienterazaosocial)");
         }
         else
         {
            GXv_int3[89] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel)) && ! ( StringUtil.StrCmp(AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial = ( :AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel))");
         }
         else
         {
            GXv_int3[90] = 1;
         }
         if ( StringUtil.StrCmp(AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.ClienteRazaoSocial IS NULL or (char_length(trim(trailing ' ' from T3.ClienteRazaoSocial))=0))");
         }
         if ( AV9WWPContext_gxTpr_Iscliente )
         {
            AddWhere(sWhereString, "(T1.PropostaCratedBy = :AV9WWPCo_1Secuserclienteid)");
         }
         else
         {
            GXv_int3[91] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.ClienteRazaoSocial";
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
                     return conditional_P008D12(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (short)dynConstraints[37] , (decimal)dynConstraints[38] , (int)dynConstraints[39] , (int)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] , (short)dynConstraints[43] , (short)dynConstraints[44] , (decimal)dynConstraints[45] , (decimal)dynConstraints[46] );
               case 1 :
                     return conditional_P008D23(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (short)dynConstraints[34] , (short)dynConstraints[35] , (string)dynConstraints[36] , (short)dynConstraints[37] , (decimal)dynConstraints[38] , (int)dynConstraints[39] , (int)dynConstraints[40] , (int)dynConstraints[41] , (int)dynConstraints[42] , (short)dynConstraints[43] , (short)dynConstraints[44] , (decimal)dynConstraints[45] , (decimal)dynConstraints[46] );
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
          Object[] prmP008D12;
          prmP008D12 = new Object[] {
          new ParDef("AV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV109Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV110Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV111Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV111Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV109Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV110Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV111Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV111Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV109Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV110Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV111Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV111Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV116Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV117Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV118Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV119Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV119Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV116Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV117Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV118Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV119Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV119Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV116Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV117Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV118Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV119Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV119Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV124Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV125Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV126Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV127Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV127Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV124Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV125Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV126Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV127Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV127Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV124Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV125Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV126Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV127Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV127Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV137Propostawwds_30_tfpropostamaiorscore_f",GXType.Int16,4,0) ,
          new ParDef("AV137Propostawwds_30_tfpropostamaiorscore_f",GXType.Int16,4,0) ,
          new ParDef("AV138Propostawwds_31_tfpropostamaiorscore_f_to",GXType.Int16,4,0) ,
          new ParDef("AV138Propostawwds_31_tfpropostamaiorscore_f_to",GXType.Int16,4,0) ,
          new ParDef("AV139Propostawwds_32_tfpropostamaiorvalorrecomendado",GXType.Number,18,2) ,
          new ParDef("AV139Propostawwds_32_tfpropostamaiorvalorrecomendado",GXType.Number,18,2) ,
          new ParDef("AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to",GXType.Number,18,2) ,
          new ParDef("AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to",GXType.Number,18,2) ,
          new ParDef("lV112Propostawwds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV112Propostawwds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV113Propostawwds_6_propostapacienteclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV113Propostawwds_6_propostapacienteclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV114Propostawwds_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV114Propostawwds_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV115Propostawwds_8_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV115Propostawwds_8_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV120Propostawwds_13_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV120Propostawwds_13_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV121Propostawwds_14_propostapacienteclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV121Propostawwds_14_propostapacienteclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV122Propostawwds_15_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV122Propostawwds_15_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV123Propostawwds_16_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV123Propostawwds_16_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV128Propostawwds_21_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV128Propostawwds_21_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV129Propostawwds_22_propostapacienteclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV129Propostawwds_22_propostapacienteclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV130Propostawwds_23_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV130Propostawwds_23_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV131Propostawwds_24_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV131Propostawwds_24_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV132Propostawwds_25_tfpropostaclinicanome",GXType.VarChar,150,0) ,
          new ParDef("AV133Propostawwds_26_tfpropostaclinicanome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV135Propostawwds_28_tfpropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV9WWPCo_1Secuserclienteid",GXType.Int16,4,0)
          };
          Object[] prmP008D23;
          prmP008D23 = new Object[] {
          new ParDef("AV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV108Propostawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV109Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV110Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV111Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV111Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV109Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV110Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV111Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV111Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV109Propostawwds_2_dynamicfiltersselector1",GXType.VarChar,200,0) ,
          new ParDef("AV110Propostawwds_3_dynamicfiltersoperator1",GXType.Int16,4,0) ,
          new ParDef("AV111Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV111Propostawwds_4_propostamaxreembolsoid_f1",GXType.Int32,9,0) ,
          new ParDef("AV116Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV117Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV118Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV119Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV119Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV116Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV117Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV118Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV119Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV119Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV116Propostawwds_9_dynamicfiltersenabled2",GXType.Boolean,4,0) ,
          new ParDef("AV117Propostawwds_10_dynamicfiltersselector2",GXType.VarChar,200,0) ,
          new ParDef("AV118Propostawwds_11_dynamicfiltersoperator2",GXType.Int16,4,0) ,
          new ParDef("AV119Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV119Propostawwds_12_propostamaxreembolsoid_f2",GXType.Int32,9,0) ,
          new ParDef("AV124Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV125Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV126Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV127Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV127Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV124Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV125Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV126Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV127Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV127Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV124Propostawwds_17_dynamicfiltersenabled3",GXType.Boolean,4,0) ,
          new ParDef("AV125Propostawwds_18_dynamicfiltersselector3",GXType.VarChar,200,0) ,
          new ParDef("AV126Propostawwds_19_dynamicfiltersoperator3",GXType.Int16,4,0) ,
          new ParDef("AV127Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV127Propostawwds_20_propostamaxreembolsoid_f3",GXType.Int32,9,0) ,
          new ParDef("AV137Propostawwds_30_tfpropostamaiorscore_f",GXType.Int16,4,0) ,
          new ParDef("AV137Propostawwds_30_tfpropostamaiorscore_f",GXType.Int16,4,0) ,
          new ParDef("AV138Propostawwds_31_tfpropostamaiorscore_f_to",GXType.Int16,4,0) ,
          new ParDef("AV138Propostawwds_31_tfpropostamaiorscore_f_to",GXType.Int16,4,0) ,
          new ParDef("AV139Propostawwds_32_tfpropostamaiorvalorrecomendado",GXType.Number,18,2) ,
          new ParDef("AV139Propostawwds_32_tfpropostamaiorvalorrecomendado",GXType.Number,18,2) ,
          new ParDef("AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to",GXType.Number,18,2) ,
          new ParDef("AV140Propostawwds_33_tfpropostamaiorvalorrecomendado_to",GXType.Number,18,2) ,
          new ParDef("lV112Propostawwds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV112Propostawwds_5_propostaresponsaveldocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV113Propostawwds_6_propostapacienteclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV113Propostawwds_6_propostapacienteclientedocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV114Propostawwds_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV114Propostawwds_7_propostaclinicadocumento1",GXType.VarChar,20,0) ,
          new ParDef("lV115Propostawwds_8_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV115Propostawwds_8_conveniocategoriadescricao1",GXType.VarChar,70,0) ,
          new ParDef("lV120Propostawwds_13_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV120Propostawwds_13_propostaresponsaveldocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV121Propostawwds_14_propostapacienteclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV121Propostawwds_14_propostapacienteclientedocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV122Propostawwds_15_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV122Propostawwds_15_propostaclinicadocumento2",GXType.VarChar,20,0) ,
          new ParDef("lV123Propostawwds_16_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV123Propostawwds_16_conveniocategoriadescricao2",GXType.VarChar,70,0) ,
          new ParDef("lV128Propostawwds_21_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV128Propostawwds_21_propostaresponsaveldocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV129Propostawwds_22_propostapacienteclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV129Propostawwds_22_propostapacienteclientedocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV130Propostawwds_23_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV130Propostawwds_23_propostaclinicadocumento3",GXType.VarChar,20,0) ,
          new ParDef("lV131Propostawwds_24_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV131Propostawwds_24_conveniocategoriadescricao3",GXType.VarChar,70,0) ,
          new ParDef("lV132Propostawwds_25_tfpropostaclinicanome",GXType.VarChar,150,0) ,
          new ParDef("AV133Propostawwds_26_tfpropostaclinicanome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV135Propostawwds_28_tfpropostapacienteclienterazaosocial",GXType.VarChar,150,0) ,
          new ParDef("AV136Propostawwds_29_tfpropostapacienteclienterazaosocial_sel",GXType.VarChar,150,0) ,
          new ParDef("AV9WWPCo_1Secuserclienteid",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008D12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008D12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008D23", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008D23,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
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
                ((decimal[]) buf[24])[0] = rslt.getDecimal(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((short[]) buf[26])[0] = rslt.getShort(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((short[]) buf[10])[0] = rslt.getShort(6);
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
                ((decimal[]) buf[24])[0] = rslt.getDecimal(13);
                ((bool[]) buf[25])[0] = rslt.wasNull(13);
                ((short[]) buf[26])[0] = rslt.getShort(14);
                ((bool[]) buf[27])[0] = rslt.wasNull(14);
                ((int[]) buf[28])[0] = rslt.getInt(15);
                ((int[]) buf[29])[0] = rslt.getInt(16);
                ((bool[]) buf[30])[0] = rslt.wasNull(16);
                return;
       }
    }

 }

}
