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
   public class wclistaassinantesgetfilterdata : GXProcedure
   {
      public wclistaassinantesgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wclistaassinantesgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_PARTICIPANTENOME") == 0 )
         {
            /* Execute user subroutine: 'LOADPARTICIPANTENOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_PARTICIPANTEEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADPARTICIPANTEEMAILOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_PARTICIPANTEDOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADPARTICIPANTEDOCUMENTOOPTIONS' */
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
         if ( StringUtil.StrCmp(AV33Session.Get("WcListaAssinantesGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WcListaAssinantesGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("WcListaAssinantesGridState"), null, "", "");
         }
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV62GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV44FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME") == 0 )
            {
               AV10TFParticipanteNome = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME_SEL") == 0 )
            {
               AV11TFParticipanteNome_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL") == 0 )
            {
               AV12TFParticipanteEmail = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL_SEL") == 0 )
            {
               AV13TFParticipanteEmail_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO") == 0 )
            {
               AV14TFParticipanteDocumento = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO_SEL") == 0 )
            {
               AV15TFParticipanteDocumento_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTETIPO_SEL") == 0 )
            {
               AV60TFAssinaturaParticipanteTipo_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV61TFAssinaturaParticipanteTipo_Sels.FromJSonString(AV60TFAssinaturaParticipanteTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTESTATUS_SEL") == 0 )
            {
               AV16TFAssinaturaParticipanteStatus_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV17TFAssinaturaParticipanteStatus_Sels.FromJSonString(AV16TFAssinaturaParticipanteStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTEDATAVISUALIZACAO") == 0 )
            {
               AV18TFAssinaturaParticipanteDataVisualizacao = context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Value, 4);
               AV19TFAssinaturaParticipanteDataVisualizacao_To = context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTEDATACONCLUSAO") == 0 )
            {
               AV20TFAssinaturaParticipanteDataConclusao = context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Value, 4);
               AV21TFAssinaturaParticipanteDataConclusao_To = context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "PARM_&ASSINATURAID") == 0 )
            {
               AV59AssinaturaId = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV62GXV1 = (int)(AV62GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV45DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "ASSINATURAPARTICIPANTESTATUS") == 0 )
            {
               AV47AssinaturaParticipanteStatus1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "PARTICIPANTEDOCUMENTO") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV48ParticipanteDocumento1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV49DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV50DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV50DynamicFiltersSelector2, "ASSINATURAPARTICIPANTESTATUS") == 0 )
               {
                  AV52AssinaturaParticipanteStatus2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector2, "PARTICIPANTEDOCUMENTO") == 0 )
               {
                  AV51DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV53ParticipanteDocumento2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV54DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV55DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "ASSINATURAPARTICIPANTESTATUS") == 0 )
                  {
                     AV57AssinaturaParticipanteStatus3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV55DynamicFiltersSelector3, "PARTICIPANTEDOCUMENTO") == 0 )
                  {
                     AV56DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV58ParticipanteDocumento3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPARTICIPANTENOMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFParticipanteNome = AV22SearchTxt;
         AV11TFParticipanteNome_Sel = "";
         AV64Wclistaassinantesds_1_assinaturaid = AV59AssinaturaId;
         AV65Wclistaassinantesds_2_filterfulltext = AV44FilterFullText;
         AV66Wclistaassinantesds_3_dynamicfiltersselector1 = AV45DynamicFiltersSelector1;
         AV67Wclistaassinantesds_4_dynamicfiltersoperator1 = AV46DynamicFiltersOperator1;
         AV68Wclistaassinantesds_5_assinaturaparticipantestatus1 = AV47AssinaturaParticipanteStatus1;
         AV69Wclistaassinantesds_6_participantedocumento1 = AV48ParticipanteDocumento1;
         AV70Wclistaassinantesds_7_dynamicfiltersenabled2 = AV49DynamicFiltersEnabled2;
         AV71Wclistaassinantesds_8_dynamicfiltersselector2 = AV50DynamicFiltersSelector2;
         AV72Wclistaassinantesds_9_dynamicfiltersoperator2 = AV51DynamicFiltersOperator2;
         AV73Wclistaassinantesds_10_assinaturaparticipantestatus2 = AV52AssinaturaParticipanteStatus2;
         AV74Wclistaassinantesds_11_participantedocumento2 = AV53ParticipanteDocumento2;
         AV75Wclistaassinantesds_12_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV76Wclistaassinantesds_13_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV77Wclistaassinantesds_14_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV78Wclistaassinantesds_15_assinaturaparticipantestatus3 = AV57AssinaturaParticipanteStatus3;
         AV79Wclistaassinantesds_16_participantedocumento3 = AV58ParticipanteDocumento3;
         AV80Wclistaassinantesds_17_tfparticipantenome = AV10TFParticipanteNome;
         AV81Wclistaassinantesds_18_tfparticipantenome_sel = AV11TFParticipanteNome_Sel;
         AV82Wclistaassinantesds_19_tfparticipanteemail = AV12TFParticipanteEmail;
         AV83Wclistaassinantesds_20_tfparticipanteemail_sel = AV13TFParticipanteEmail_Sel;
         AV84Wclistaassinantesds_21_tfparticipantedocumento = AV14TFParticipanteDocumento;
         AV85Wclistaassinantesds_22_tfparticipantedocumento_sel = AV15TFParticipanteDocumento_Sel;
         AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = AV61TFAssinaturaParticipanteTipo_Sels;
         AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = AV17TFAssinaturaParticipanteStatus_Sels;
         AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = AV18TFAssinaturaParticipanteDataVisualizacao;
         AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = AV19TFAssinaturaParticipanteDataVisualizacao_To;
         AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = AV20TFAssinaturaParticipanteDataConclusao;
         AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = AV21TFAssinaturaParticipanteDataConclusao_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A247AssinaturaParticipanteTipo ,
                                              AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ,
                                              A353AssinaturaParticipanteStatus ,
                                              AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ,
                                              AV65Wclistaassinantesds_2_filterfulltext ,
                                              AV66Wclistaassinantesds_3_dynamicfiltersselector1 ,
                                              AV68Wclistaassinantesds_5_assinaturaparticipantestatus1 ,
                                              AV67Wclistaassinantesds_4_dynamicfiltersoperator1 ,
                                              AV69Wclistaassinantesds_6_participantedocumento1 ,
                                              AV70Wclistaassinantesds_7_dynamicfiltersenabled2 ,
                                              AV71Wclistaassinantesds_8_dynamicfiltersselector2 ,
                                              AV73Wclistaassinantesds_10_assinaturaparticipantestatus2 ,
                                              AV72Wclistaassinantesds_9_dynamicfiltersoperator2 ,
                                              AV74Wclistaassinantesds_11_participantedocumento2 ,
                                              AV75Wclistaassinantesds_12_dynamicfiltersenabled3 ,
                                              AV76Wclistaassinantesds_13_dynamicfiltersselector3 ,
                                              AV78Wclistaassinantesds_15_assinaturaparticipantestatus3 ,
                                              AV77Wclistaassinantesds_14_dynamicfiltersoperator3 ,
                                              AV79Wclistaassinantesds_16_participantedocumento3 ,
                                              AV81Wclistaassinantesds_18_tfparticipantenome_sel ,
                                              AV80Wclistaassinantesds_17_tfparticipantenome ,
                                              AV83Wclistaassinantesds_20_tfparticipanteemail_sel ,
                                              AV82Wclistaassinantesds_19_tfparticipanteemail ,
                                              AV85Wclistaassinantesds_22_tfparticipantedocumento_sel ,
                                              AV84Wclistaassinantesds_21_tfparticipantedocumento ,
                                              AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels.Count ,
                                              AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels.Count ,
                                              AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ,
                                              AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ,
                                              AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ,
                                              AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ,
                                              A248ParticipanteNome ,
                                              A235ParticipanteEmail ,
                                              A234ParticipanteDocumento ,
                                              A244AssinaturaParticipanteDataVisualizacao ,
                                              A245AssinaturaParticipanteDataConclusao ,
                                              AV64Wclistaassinantesds_1_assinaturaid ,
                                              A238AssinaturaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV69Wclistaassinantesds_6_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV69Wclistaassinantesds_6_participantedocumento1), "%", "");
         lV69Wclistaassinantesds_6_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV69Wclistaassinantesds_6_participantedocumento1), "%", "");
         lV74Wclistaassinantesds_11_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV74Wclistaassinantesds_11_participantedocumento2), "%", "");
         lV74Wclistaassinantesds_11_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV74Wclistaassinantesds_11_participantedocumento2), "%", "");
         lV79Wclistaassinantesds_16_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Wclistaassinantesds_16_participantedocumento3), "%", "");
         lV79Wclistaassinantesds_16_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Wclistaassinantesds_16_participantedocumento3), "%", "");
         lV80Wclistaassinantesds_17_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV80Wclistaassinantesds_17_tfparticipantenome), "%", "");
         lV82Wclistaassinantesds_19_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV82Wclistaassinantesds_19_tfparticipanteemail), "%", "");
         lV84Wclistaassinantesds_21_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV84Wclistaassinantesds_21_tfparticipantedocumento), "%", "");
         /* Using cursor P00932 */
         pr_default.execute(0, new Object[] {AV64Wclistaassinantesds_1_assinaturaid, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, AV68Wclistaassinantesds_5_assinaturaparticipantestatus1, lV69Wclistaassinantesds_6_participantedocumento1, lV69Wclistaassinantesds_6_participantedocumento1, AV73Wclistaassinantesds_10_assinaturaparticipantestatus2, lV74Wclistaassinantesds_11_participantedocumento2, lV74Wclistaassinantesds_11_participantedocumento2, AV78Wclistaassinantesds_15_assinaturaparticipantestatus3, lV79Wclistaassinantesds_16_participantedocumento3, lV79Wclistaassinantesds_16_participantedocumento3, lV80Wclistaassinantesds_17_tfparticipantenome, AV81Wclistaassinantesds_18_tfparticipantenome_sel, lV82Wclistaassinantesds_19_tfparticipanteemail, AV83Wclistaassinantesds_20_tfparticipanteemail_sel, lV84Wclistaassinantesds_21_tfparticipantedocumento, AV85Wclistaassinantesds_22_tfparticipantedocumento_sel, AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao, AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to, AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao, AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK932 = false;
            A233ParticipanteId = P00932_A233ParticipanteId[0];
            n233ParticipanteId = P00932_n233ParticipanteId[0];
            A238AssinaturaId = P00932_A238AssinaturaId[0];
            n238AssinaturaId = P00932_n238AssinaturaId[0];
            A248ParticipanteNome = P00932_A248ParticipanteNome[0];
            n248ParticipanteNome = P00932_n248ParticipanteNome[0];
            A245AssinaturaParticipanteDataConclusao = P00932_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = P00932_n245AssinaturaParticipanteDataConclusao[0];
            A244AssinaturaParticipanteDataVisualizacao = P00932_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = P00932_n244AssinaturaParticipanteDataVisualizacao[0];
            A353AssinaturaParticipanteStatus = P00932_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = P00932_n353AssinaturaParticipanteStatus[0];
            A247AssinaturaParticipanteTipo = P00932_A247AssinaturaParticipanteTipo[0];
            n247AssinaturaParticipanteTipo = P00932_n247AssinaturaParticipanteTipo[0];
            A234ParticipanteDocumento = P00932_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00932_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00932_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00932_n235ParticipanteEmail[0];
            A242AssinaturaParticipanteId = P00932_A242AssinaturaParticipanteId[0];
            A248ParticipanteNome = P00932_A248ParticipanteNome[0];
            n248ParticipanteNome = P00932_n248ParticipanteNome[0];
            A234ParticipanteDocumento = P00932_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00932_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00932_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00932_n235ParticipanteEmail[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00932_A238AssinaturaId[0] == A238AssinaturaId ) && ( StringUtil.StrCmp(P00932_A248ParticipanteNome[0], A248ParticipanteNome) == 0 ) )
            {
               BRK932 = false;
               A233ParticipanteId = P00932_A233ParticipanteId[0];
               n233ParticipanteId = P00932_n233ParticipanteId[0];
               A242AssinaturaParticipanteId = P00932_A242AssinaturaParticipanteId[0];
               AV32count = (long)(AV32count+1);
               BRK932 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV23SkipItems) )
            {
               AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A248ParticipanteNome)) ? "<#Empty#>" : A248ParticipanteNome);
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
            if ( ! BRK932 )
            {
               BRK932 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPARTICIPANTEEMAILOPTIONS' Routine */
         returnInSub = false;
         AV12TFParticipanteEmail = AV22SearchTxt;
         AV13TFParticipanteEmail_Sel = "";
         AV64Wclistaassinantesds_1_assinaturaid = AV59AssinaturaId;
         AV65Wclistaassinantesds_2_filterfulltext = AV44FilterFullText;
         AV66Wclistaassinantesds_3_dynamicfiltersselector1 = AV45DynamicFiltersSelector1;
         AV67Wclistaassinantesds_4_dynamicfiltersoperator1 = AV46DynamicFiltersOperator1;
         AV68Wclistaassinantesds_5_assinaturaparticipantestatus1 = AV47AssinaturaParticipanteStatus1;
         AV69Wclistaassinantesds_6_participantedocumento1 = AV48ParticipanteDocumento1;
         AV70Wclistaassinantesds_7_dynamicfiltersenabled2 = AV49DynamicFiltersEnabled2;
         AV71Wclistaassinantesds_8_dynamicfiltersselector2 = AV50DynamicFiltersSelector2;
         AV72Wclistaassinantesds_9_dynamicfiltersoperator2 = AV51DynamicFiltersOperator2;
         AV73Wclistaassinantesds_10_assinaturaparticipantestatus2 = AV52AssinaturaParticipanteStatus2;
         AV74Wclistaassinantesds_11_participantedocumento2 = AV53ParticipanteDocumento2;
         AV75Wclistaassinantesds_12_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV76Wclistaassinantesds_13_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV77Wclistaassinantesds_14_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV78Wclistaassinantesds_15_assinaturaparticipantestatus3 = AV57AssinaturaParticipanteStatus3;
         AV79Wclistaassinantesds_16_participantedocumento3 = AV58ParticipanteDocumento3;
         AV80Wclistaassinantesds_17_tfparticipantenome = AV10TFParticipanteNome;
         AV81Wclistaassinantesds_18_tfparticipantenome_sel = AV11TFParticipanteNome_Sel;
         AV82Wclistaassinantesds_19_tfparticipanteemail = AV12TFParticipanteEmail;
         AV83Wclistaassinantesds_20_tfparticipanteemail_sel = AV13TFParticipanteEmail_Sel;
         AV84Wclistaassinantesds_21_tfparticipantedocumento = AV14TFParticipanteDocumento;
         AV85Wclistaassinantesds_22_tfparticipantedocumento_sel = AV15TFParticipanteDocumento_Sel;
         AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = AV61TFAssinaturaParticipanteTipo_Sels;
         AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = AV17TFAssinaturaParticipanteStatus_Sels;
         AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = AV18TFAssinaturaParticipanteDataVisualizacao;
         AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = AV19TFAssinaturaParticipanteDataVisualizacao_To;
         AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = AV20TFAssinaturaParticipanteDataConclusao;
         AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = AV21TFAssinaturaParticipanteDataConclusao_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A247AssinaturaParticipanteTipo ,
                                              AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ,
                                              A353AssinaturaParticipanteStatus ,
                                              AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ,
                                              AV65Wclistaassinantesds_2_filterfulltext ,
                                              AV66Wclistaassinantesds_3_dynamicfiltersselector1 ,
                                              AV68Wclistaassinantesds_5_assinaturaparticipantestatus1 ,
                                              AV67Wclistaassinantesds_4_dynamicfiltersoperator1 ,
                                              AV69Wclistaassinantesds_6_participantedocumento1 ,
                                              AV70Wclistaassinantesds_7_dynamicfiltersenabled2 ,
                                              AV71Wclistaassinantesds_8_dynamicfiltersselector2 ,
                                              AV73Wclistaassinantesds_10_assinaturaparticipantestatus2 ,
                                              AV72Wclistaassinantesds_9_dynamicfiltersoperator2 ,
                                              AV74Wclistaassinantesds_11_participantedocumento2 ,
                                              AV75Wclistaassinantesds_12_dynamicfiltersenabled3 ,
                                              AV76Wclistaassinantesds_13_dynamicfiltersselector3 ,
                                              AV78Wclistaassinantesds_15_assinaturaparticipantestatus3 ,
                                              AV77Wclistaassinantesds_14_dynamicfiltersoperator3 ,
                                              AV79Wclistaassinantesds_16_participantedocumento3 ,
                                              AV81Wclistaassinantesds_18_tfparticipantenome_sel ,
                                              AV80Wclistaassinantesds_17_tfparticipantenome ,
                                              AV83Wclistaassinantesds_20_tfparticipanteemail_sel ,
                                              AV82Wclistaassinantesds_19_tfparticipanteemail ,
                                              AV85Wclistaassinantesds_22_tfparticipantedocumento_sel ,
                                              AV84Wclistaassinantesds_21_tfparticipantedocumento ,
                                              AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels.Count ,
                                              AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels.Count ,
                                              AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ,
                                              AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ,
                                              AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ,
                                              AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ,
                                              A248ParticipanteNome ,
                                              A235ParticipanteEmail ,
                                              A234ParticipanteDocumento ,
                                              A244AssinaturaParticipanteDataVisualizacao ,
                                              A245AssinaturaParticipanteDataConclusao ,
                                              AV64Wclistaassinantesds_1_assinaturaid ,
                                              A238AssinaturaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV69Wclistaassinantesds_6_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV69Wclistaassinantesds_6_participantedocumento1), "%", "");
         lV69Wclistaassinantesds_6_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV69Wclistaassinantesds_6_participantedocumento1), "%", "");
         lV74Wclistaassinantesds_11_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV74Wclistaassinantesds_11_participantedocumento2), "%", "");
         lV74Wclistaassinantesds_11_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV74Wclistaassinantesds_11_participantedocumento2), "%", "");
         lV79Wclistaassinantesds_16_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Wclistaassinantesds_16_participantedocumento3), "%", "");
         lV79Wclistaassinantesds_16_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Wclistaassinantesds_16_participantedocumento3), "%", "");
         lV80Wclistaassinantesds_17_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV80Wclistaassinantesds_17_tfparticipantenome), "%", "");
         lV82Wclistaassinantesds_19_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV82Wclistaassinantesds_19_tfparticipanteemail), "%", "");
         lV84Wclistaassinantesds_21_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV84Wclistaassinantesds_21_tfparticipantedocumento), "%", "");
         /* Using cursor P00933 */
         pr_default.execute(1, new Object[] {AV64Wclistaassinantesds_1_assinaturaid, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, AV68Wclistaassinantesds_5_assinaturaparticipantestatus1, lV69Wclistaassinantesds_6_participantedocumento1, lV69Wclistaassinantesds_6_participantedocumento1, AV73Wclistaassinantesds_10_assinaturaparticipantestatus2, lV74Wclistaassinantesds_11_participantedocumento2, lV74Wclistaassinantesds_11_participantedocumento2, AV78Wclistaassinantesds_15_assinaturaparticipantestatus3, lV79Wclistaassinantesds_16_participantedocumento3, lV79Wclistaassinantesds_16_participantedocumento3, lV80Wclistaassinantesds_17_tfparticipantenome, AV81Wclistaassinantesds_18_tfparticipantenome_sel, lV82Wclistaassinantesds_19_tfparticipanteemail, AV83Wclistaassinantesds_20_tfparticipanteemail_sel, lV84Wclistaassinantesds_21_tfparticipantedocumento, AV85Wclistaassinantesds_22_tfparticipantedocumento_sel, AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao, AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to, AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao, AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK934 = false;
            A233ParticipanteId = P00933_A233ParticipanteId[0];
            n233ParticipanteId = P00933_n233ParticipanteId[0];
            A238AssinaturaId = P00933_A238AssinaturaId[0];
            n238AssinaturaId = P00933_n238AssinaturaId[0];
            A235ParticipanteEmail = P00933_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00933_n235ParticipanteEmail[0];
            A245AssinaturaParticipanteDataConclusao = P00933_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = P00933_n245AssinaturaParticipanteDataConclusao[0];
            A244AssinaturaParticipanteDataVisualizacao = P00933_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = P00933_n244AssinaturaParticipanteDataVisualizacao[0];
            A353AssinaturaParticipanteStatus = P00933_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = P00933_n353AssinaturaParticipanteStatus[0];
            A247AssinaturaParticipanteTipo = P00933_A247AssinaturaParticipanteTipo[0];
            n247AssinaturaParticipanteTipo = P00933_n247AssinaturaParticipanteTipo[0];
            A234ParticipanteDocumento = P00933_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00933_n234ParticipanteDocumento[0];
            A248ParticipanteNome = P00933_A248ParticipanteNome[0];
            n248ParticipanteNome = P00933_n248ParticipanteNome[0];
            A242AssinaturaParticipanteId = P00933_A242AssinaturaParticipanteId[0];
            A235ParticipanteEmail = P00933_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00933_n235ParticipanteEmail[0];
            A234ParticipanteDocumento = P00933_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00933_n234ParticipanteDocumento[0];
            A248ParticipanteNome = P00933_A248ParticipanteNome[0];
            n248ParticipanteNome = P00933_n248ParticipanteNome[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00933_A238AssinaturaId[0] == A238AssinaturaId ) && ( StringUtil.StrCmp(P00933_A235ParticipanteEmail[0], A235ParticipanteEmail) == 0 ) )
            {
               BRK934 = false;
               A233ParticipanteId = P00933_A233ParticipanteId[0];
               n233ParticipanteId = P00933_n233ParticipanteId[0];
               A242AssinaturaParticipanteId = P00933_A242AssinaturaParticipanteId[0];
               AV32count = (long)(AV32count+1);
               BRK934 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV23SkipItems) )
            {
               AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A235ParticipanteEmail)) ? "<#Empty#>" : A235ParticipanteEmail);
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
            if ( ! BRK934 )
            {
               BRK934 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPARTICIPANTEDOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV14TFParticipanteDocumento = AV22SearchTxt;
         AV15TFParticipanteDocumento_Sel = "";
         AV64Wclistaassinantesds_1_assinaturaid = AV59AssinaturaId;
         AV65Wclistaassinantesds_2_filterfulltext = AV44FilterFullText;
         AV66Wclistaassinantesds_3_dynamicfiltersselector1 = AV45DynamicFiltersSelector1;
         AV67Wclistaassinantesds_4_dynamicfiltersoperator1 = AV46DynamicFiltersOperator1;
         AV68Wclistaassinantesds_5_assinaturaparticipantestatus1 = AV47AssinaturaParticipanteStatus1;
         AV69Wclistaassinantesds_6_participantedocumento1 = AV48ParticipanteDocumento1;
         AV70Wclistaassinantesds_7_dynamicfiltersenabled2 = AV49DynamicFiltersEnabled2;
         AV71Wclistaassinantesds_8_dynamicfiltersselector2 = AV50DynamicFiltersSelector2;
         AV72Wclistaassinantesds_9_dynamicfiltersoperator2 = AV51DynamicFiltersOperator2;
         AV73Wclistaassinantesds_10_assinaturaparticipantestatus2 = AV52AssinaturaParticipanteStatus2;
         AV74Wclistaassinantesds_11_participantedocumento2 = AV53ParticipanteDocumento2;
         AV75Wclistaassinantesds_12_dynamicfiltersenabled3 = AV54DynamicFiltersEnabled3;
         AV76Wclistaassinantesds_13_dynamicfiltersselector3 = AV55DynamicFiltersSelector3;
         AV77Wclistaassinantesds_14_dynamicfiltersoperator3 = AV56DynamicFiltersOperator3;
         AV78Wclistaassinantesds_15_assinaturaparticipantestatus3 = AV57AssinaturaParticipanteStatus3;
         AV79Wclistaassinantesds_16_participantedocumento3 = AV58ParticipanteDocumento3;
         AV80Wclistaassinantesds_17_tfparticipantenome = AV10TFParticipanteNome;
         AV81Wclistaassinantesds_18_tfparticipantenome_sel = AV11TFParticipanteNome_Sel;
         AV82Wclistaassinantesds_19_tfparticipanteemail = AV12TFParticipanteEmail;
         AV83Wclistaassinantesds_20_tfparticipanteemail_sel = AV13TFParticipanteEmail_Sel;
         AV84Wclistaassinantesds_21_tfparticipantedocumento = AV14TFParticipanteDocumento;
         AV85Wclistaassinantesds_22_tfparticipantedocumento_sel = AV15TFParticipanteDocumento_Sel;
         AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = AV61TFAssinaturaParticipanteTipo_Sels;
         AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = AV17TFAssinaturaParticipanteStatus_Sels;
         AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = AV18TFAssinaturaParticipanteDataVisualizacao;
         AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = AV19TFAssinaturaParticipanteDataVisualizacao_To;
         AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = AV20TFAssinaturaParticipanteDataConclusao;
         AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = AV21TFAssinaturaParticipanteDataConclusao_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A247AssinaturaParticipanteTipo ,
                                              AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ,
                                              A353AssinaturaParticipanteStatus ,
                                              AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ,
                                              AV65Wclistaassinantesds_2_filterfulltext ,
                                              AV66Wclistaassinantesds_3_dynamicfiltersselector1 ,
                                              AV68Wclistaassinantesds_5_assinaturaparticipantestatus1 ,
                                              AV67Wclistaassinantesds_4_dynamicfiltersoperator1 ,
                                              AV69Wclistaassinantesds_6_participantedocumento1 ,
                                              AV70Wclistaassinantesds_7_dynamicfiltersenabled2 ,
                                              AV71Wclistaassinantesds_8_dynamicfiltersselector2 ,
                                              AV73Wclistaassinantesds_10_assinaturaparticipantestatus2 ,
                                              AV72Wclistaassinantesds_9_dynamicfiltersoperator2 ,
                                              AV74Wclistaassinantesds_11_participantedocumento2 ,
                                              AV75Wclistaassinantesds_12_dynamicfiltersenabled3 ,
                                              AV76Wclistaassinantesds_13_dynamicfiltersselector3 ,
                                              AV78Wclistaassinantesds_15_assinaturaparticipantestatus3 ,
                                              AV77Wclistaassinantesds_14_dynamicfiltersoperator3 ,
                                              AV79Wclistaassinantesds_16_participantedocumento3 ,
                                              AV81Wclistaassinantesds_18_tfparticipantenome_sel ,
                                              AV80Wclistaassinantesds_17_tfparticipantenome ,
                                              AV83Wclistaassinantesds_20_tfparticipanteemail_sel ,
                                              AV82Wclistaassinantesds_19_tfparticipanteemail ,
                                              AV85Wclistaassinantesds_22_tfparticipantedocumento_sel ,
                                              AV84Wclistaassinantesds_21_tfparticipantedocumento ,
                                              AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels.Count ,
                                              AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels.Count ,
                                              AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ,
                                              AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ,
                                              AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ,
                                              AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ,
                                              A248ParticipanteNome ,
                                              A235ParticipanteEmail ,
                                              A234ParticipanteDocumento ,
                                              A244AssinaturaParticipanteDataVisualizacao ,
                                              A245AssinaturaParticipanteDataConclusao ,
                                              AV64Wclistaassinantesds_1_assinaturaid ,
                                              A238AssinaturaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV65Wclistaassinantesds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext), "%", "");
         lV69Wclistaassinantesds_6_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV69Wclistaassinantesds_6_participantedocumento1), "%", "");
         lV69Wclistaassinantesds_6_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV69Wclistaassinantesds_6_participantedocumento1), "%", "");
         lV74Wclistaassinantesds_11_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV74Wclistaassinantesds_11_participantedocumento2), "%", "");
         lV74Wclistaassinantesds_11_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV74Wclistaassinantesds_11_participantedocumento2), "%", "");
         lV79Wclistaassinantesds_16_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Wclistaassinantesds_16_participantedocumento3), "%", "");
         lV79Wclistaassinantesds_16_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV79Wclistaassinantesds_16_participantedocumento3), "%", "");
         lV80Wclistaassinantesds_17_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV80Wclistaassinantesds_17_tfparticipantenome), "%", "");
         lV82Wclistaassinantesds_19_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV82Wclistaassinantesds_19_tfparticipanteemail), "%", "");
         lV84Wclistaassinantesds_21_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV84Wclistaassinantesds_21_tfparticipantedocumento), "%", "");
         /* Using cursor P00934 */
         pr_default.execute(2, new Object[] {AV64Wclistaassinantesds_1_assinaturaid, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, lV65Wclistaassinantesds_2_filterfulltext, AV68Wclistaassinantesds_5_assinaturaparticipantestatus1, lV69Wclistaassinantesds_6_participantedocumento1, lV69Wclistaassinantesds_6_participantedocumento1, AV73Wclistaassinantesds_10_assinaturaparticipantestatus2, lV74Wclistaassinantesds_11_participantedocumento2, lV74Wclistaassinantesds_11_participantedocumento2, AV78Wclistaassinantesds_15_assinaturaparticipantestatus3, lV79Wclistaassinantesds_16_participantedocumento3, lV79Wclistaassinantesds_16_participantedocumento3, lV80Wclistaassinantesds_17_tfparticipantenome, AV81Wclistaassinantesds_18_tfparticipantenome_sel, lV82Wclistaassinantesds_19_tfparticipanteemail, AV83Wclistaassinantesds_20_tfparticipanteemail_sel, lV84Wclistaassinantesds_21_tfparticipantedocumento, AV85Wclistaassinantesds_22_tfparticipantedocumento_sel, AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao, AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to, AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao, AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK936 = false;
            A238AssinaturaId = P00934_A238AssinaturaId[0];
            n238AssinaturaId = P00934_n238AssinaturaId[0];
            A233ParticipanteId = P00934_A233ParticipanteId[0];
            n233ParticipanteId = P00934_n233ParticipanteId[0];
            A245AssinaturaParticipanteDataConclusao = P00934_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = P00934_n245AssinaturaParticipanteDataConclusao[0];
            A244AssinaturaParticipanteDataVisualizacao = P00934_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = P00934_n244AssinaturaParticipanteDataVisualizacao[0];
            A353AssinaturaParticipanteStatus = P00934_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = P00934_n353AssinaturaParticipanteStatus[0];
            A247AssinaturaParticipanteTipo = P00934_A247AssinaturaParticipanteTipo[0];
            n247AssinaturaParticipanteTipo = P00934_n247AssinaturaParticipanteTipo[0];
            A234ParticipanteDocumento = P00934_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00934_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00934_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00934_n235ParticipanteEmail[0];
            A248ParticipanteNome = P00934_A248ParticipanteNome[0];
            n248ParticipanteNome = P00934_n248ParticipanteNome[0];
            A242AssinaturaParticipanteId = P00934_A242AssinaturaParticipanteId[0];
            A234ParticipanteDocumento = P00934_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00934_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00934_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00934_n235ParticipanteEmail[0];
            A248ParticipanteNome = P00934_A248ParticipanteNome[0];
            n248ParticipanteNome = P00934_n248ParticipanteNome[0];
            AV32count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00934_A238AssinaturaId[0] == A238AssinaturaId ) && ( P00934_A233ParticipanteId[0] == A233ParticipanteId ) )
            {
               BRK936 = false;
               A242AssinaturaParticipanteId = P00934_A242AssinaturaParticipanteId[0];
               AV32count = (long)(AV32count+1);
               BRK936 = true;
               pr_default.readNext(2);
            }
            AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A234ParticipanteDocumento)) ? "<#Empty#>" : A234ParticipanteDocumento);
            AV26InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV27Option, "<#Empty#>") != 0 ) && ( AV26InsertIndex <= AV28Options.Count ) && ( ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), AV27Option) < 0 ) || ( StringUtil.StrCmp(((string)AV28Options.Item(AV26InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV26InsertIndex = (int)(AV26InsertIndex+1);
            }
            AV28Options.Add(AV27Option, AV26InsertIndex);
            AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), AV26InsertIndex);
            if ( AV28Options.Count == AV23SkipItems + 11 )
            {
               AV28Options.RemoveItem(AV28Options.Count);
               AV31OptionIndexes.RemoveItem(AV31OptionIndexes.Count);
            }
            if ( ! BRK936 )
            {
               BRK936 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV23SkipItems > 0 )
         {
            AV28Options.RemoveItem(1);
            AV31OptionIndexes.RemoveItem(1);
            AV23SkipItems = (short)(AV23SkipItems-1);
         }
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
         AV44FilterFullText = "";
         AV10TFParticipanteNome = "";
         AV11TFParticipanteNome_Sel = "";
         AV12TFParticipanteEmail = "";
         AV13TFParticipanteEmail_Sel = "";
         AV14TFParticipanteDocumento = "";
         AV15TFParticipanteDocumento_Sel = "";
         AV60TFAssinaturaParticipanteTipo_SelsJson = "";
         AV61TFAssinaturaParticipanteTipo_Sels = new GxSimpleCollection<string>();
         AV16TFAssinaturaParticipanteStatus_SelsJson = "";
         AV17TFAssinaturaParticipanteStatus_Sels = new GxSimpleCollection<string>();
         AV18TFAssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         AV19TFAssinaturaParticipanteDataVisualizacao_To = (DateTime)(DateTime.MinValue);
         AV20TFAssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         AV21TFAssinaturaParticipanteDataConclusao_To = (DateTime)(DateTime.MinValue);
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV45DynamicFiltersSelector1 = "";
         AV47AssinaturaParticipanteStatus1 = "";
         AV48ParticipanteDocumento1 = "";
         AV50DynamicFiltersSelector2 = "";
         AV52AssinaturaParticipanteStatus2 = "";
         AV53ParticipanteDocumento2 = "";
         AV55DynamicFiltersSelector3 = "";
         AV57AssinaturaParticipanteStatus3 = "";
         AV58ParticipanteDocumento3 = "";
         AV65Wclistaassinantesds_2_filterfulltext = "";
         AV66Wclistaassinantesds_3_dynamicfiltersselector1 = "";
         AV68Wclistaassinantesds_5_assinaturaparticipantestatus1 = "";
         AV69Wclistaassinantesds_6_participantedocumento1 = "";
         AV71Wclistaassinantesds_8_dynamicfiltersselector2 = "";
         AV73Wclistaassinantesds_10_assinaturaparticipantestatus2 = "";
         AV74Wclistaassinantesds_11_participantedocumento2 = "";
         AV76Wclistaassinantesds_13_dynamicfiltersselector3 = "";
         AV78Wclistaassinantesds_15_assinaturaparticipantestatus3 = "";
         AV79Wclistaassinantesds_16_participantedocumento3 = "";
         AV80Wclistaassinantesds_17_tfparticipantenome = "";
         AV81Wclistaassinantesds_18_tfparticipantenome_sel = "";
         AV82Wclistaassinantesds_19_tfparticipanteemail = "";
         AV83Wclistaassinantesds_20_tfparticipanteemail_sel = "";
         AV84Wclistaassinantesds_21_tfparticipantedocumento = "";
         AV85Wclistaassinantesds_22_tfparticipantedocumento_sel = "";
         AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels = new GxSimpleCollection<string>();
         AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels = new GxSimpleCollection<string>();
         AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao = (DateTime)(DateTime.MinValue);
         AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to = (DateTime)(DateTime.MinValue);
         AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao = (DateTime)(DateTime.MinValue);
         AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to = (DateTime)(DateTime.MinValue);
         lV65Wclistaassinantesds_2_filterfulltext = "";
         lV69Wclistaassinantesds_6_participantedocumento1 = "";
         lV74Wclistaassinantesds_11_participantedocumento2 = "";
         lV79Wclistaassinantesds_16_participantedocumento3 = "";
         lV80Wclistaassinantesds_17_tfparticipantenome = "";
         lV82Wclistaassinantesds_19_tfparticipanteemail = "";
         lV84Wclistaassinantesds_21_tfparticipantedocumento = "";
         A247AssinaturaParticipanteTipo = "";
         A353AssinaturaParticipanteStatus = "";
         A248ParticipanteNome = "";
         A235ParticipanteEmail = "";
         A234ParticipanteDocumento = "";
         A244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         A245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         P00932_A233ParticipanteId = new int[1] ;
         P00932_n233ParticipanteId = new bool[] {false} ;
         P00932_A238AssinaturaId = new long[1] ;
         P00932_n238AssinaturaId = new bool[] {false} ;
         P00932_A248ParticipanteNome = new string[] {""} ;
         P00932_n248ParticipanteNome = new bool[] {false} ;
         P00932_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         P00932_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         P00932_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         P00932_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         P00932_A353AssinaturaParticipanteStatus = new string[] {""} ;
         P00932_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         P00932_A247AssinaturaParticipanteTipo = new string[] {""} ;
         P00932_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         P00932_A234ParticipanteDocumento = new string[] {""} ;
         P00932_n234ParticipanteDocumento = new bool[] {false} ;
         P00932_A235ParticipanteEmail = new string[] {""} ;
         P00932_n235ParticipanteEmail = new bool[] {false} ;
         P00932_A242AssinaturaParticipanteId = new int[1] ;
         AV27Option = "";
         P00933_A233ParticipanteId = new int[1] ;
         P00933_n233ParticipanteId = new bool[] {false} ;
         P00933_A238AssinaturaId = new long[1] ;
         P00933_n238AssinaturaId = new bool[] {false} ;
         P00933_A235ParticipanteEmail = new string[] {""} ;
         P00933_n235ParticipanteEmail = new bool[] {false} ;
         P00933_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         P00933_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         P00933_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         P00933_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         P00933_A353AssinaturaParticipanteStatus = new string[] {""} ;
         P00933_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         P00933_A247AssinaturaParticipanteTipo = new string[] {""} ;
         P00933_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         P00933_A234ParticipanteDocumento = new string[] {""} ;
         P00933_n234ParticipanteDocumento = new bool[] {false} ;
         P00933_A248ParticipanteNome = new string[] {""} ;
         P00933_n248ParticipanteNome = new bool[] {false} ;
         P00933_A242AssinaturaParticipanteId = new int[1] ;
         P00934_A238AssinaturaId = new long[1] ;
         P00934_n238AssinaturaId = new bool[] {false} ;
         P00934_A233ParticipanteId = new int[1] ;
         P00934_n233ParticipanteId = new bool[] {false} ;
         P00934_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         P00934_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         P00934_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         P00934_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         P00934_A353AssinaturaParticipanteStatus = new string[] {""} ;
         P00934_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         P00934_A247AssinaturaParticipanteTipo = new string[] {""} ;
         P00934_n247AssinaturaParticipanteTipo = new bool[] {false} ;
         P00934_A234ParticipanteDocumento = new string[] {""} ;
         P00934_n234ParticipanteDocumento = new bool[] {false} ;
         P00934_A235ParticipanteEmail = new string[] {""} ;
         P00934_n235ParticipanteEmail = new bool[] {false} ;
         P00934_A248ParticipanteNome = new string[] {""} ;
         P00934_n248ParticipanteNome = new bool[] {false} ;
         P00934_A242AssinaturaParticipanteId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wclistaassinantesgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00932_A233ParticipanteId, P00932_n233ParticipanteId, P00932_A238AssinaturaId, P00932_n238AssinaturaId, P00932_A248ParticipanteNome, P00932_n248ParticipanteNome, P00932_A245AssinaturaParticipanteDataConclusao, P00932_n245AssinaturaParticipanteDataConclusao, P00932_A244AssinaturaParticipanteDataVisualizacao, P00932_n244AssinaturaParticipanteDataVisualizacao,
               P00932_A353AssinaturaParticipanteStatus, P00932_n353AssinaturaParticipanteStatus, P00932_A247AssinaturaParticipanteTipo, P00932_n247AssinaturaParticipanteTipo, P00932_A234ParticipanteDocumento, P00932_n234ParticipanteDocumento, P00932_A235ParticipanteEmail, P00932_n235ParticipanteEmail, P00932_A242AssinaturaParticipanteId
               }
               , new Object[] {
               P00933_A233ParticipanteId, P00933_n233ParticipanteId, P00933_A238AssinaturaId, P00933_n238AssinaturaId, P00933_A235ParticipanteEmail, P00933_n235ParticipanteEmail, P00933_A245AssinaturaParticipanteDataConclusao, P00933_n245AssinaturaParticipanteDataConclusao, P00933_A244AssinaturaParticipanteDataVisualizacao, P00933_n244AssinaturaParticipanteDataVisualizacao,
               P00933_A353AssinaturaParticipanteStatus, P00933_n353AssinaturaParticipanteStatus, P00933_A247AssinaturaParticipanteTipo, P00933_n247AssinaturaParticipanteTipo, P00933_A234ParticipanteDocumento, P00933_n234ParticipanteDocumento, P00933_A248ParticipanteNome, P00933_n248ParticipanteNome, P00933_A242AssinaturaParticipanteId
               }
               , new Object[] {
               P00934_A238AssinaturaId, P00934_n238AssinaturaId, P00934_A233ParticipanteId, P00934_n233ParticipanteId, P00934_A245AssinaturaParticipanteDataConclusao, P00934_n245AssinaturaParticipanteDataConclusao, P00934_A244AssinaturaParticipanteDataVisualizacao, P00934_n244AssinaturaParticipanteDataVisualizacao, P00934_A353AssinaturaParticipanteStatus, P00934_n353AssinaturaParticipanteStatus,
               P00934_A247AssinaturaParticipanteTipo, P00934_n247AssinaturaParticipanteTipo, P00934_A234ParticipanteDocumento, P00934_n234ParticipanteDocumento, P00934_A235ParticipanteEmail, P00934_n235ParticipanteEmail, P00934_A248ParticipanteNome, P00934_n248ParticipanteNome, P00934_A242AssinaturaParticipanteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV25MaxItems ;
      private short AV24PageIndex ;
      private short AV23SkipItems ;
      private short AV46DynamicFiltersOperator1 ;
      private short AV51DynamicFiltersOperator2 ;
      private short AV56DynamicFiltersOperator3 ;
      private short AV67Wclistaassinantesds_4_dynamicfiltersoperator1 ;
      private short AV72Wclistaassinantesds_9_dynamicfiltersoperator2 ;
      private short AV77Wclistaassinantesds_14_dynamicfiltersoperator3 ;
      private int AV62GXV1 ;
      private int AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count ;
      private int AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count ;
      private int A233ParticipanteId ;
      private int A242AssinaturaParticipanteId ;
      private int AV26InsertIndex ;
      private long AV59AssinaturaId ;
      private long AV64Wclistaassinantesds_1_assinaturaid ;
      private long A238AssinaturaId ;
      private long AV32count ;
      private DateTime AV18TFAssinaturaParticipanteDataVisualizacao ;
      private DateTime AV19TFAssinaturaParticipanteDataVisualizacao_To ;
      private DateTime AV20TFAssinaturaParticipanteDataConclusao ;
      private DateTime AV21TFAssinaturaParticipanteDataConclusao_To ;
      private DateTime AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ;
      private DateTime AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ;
      private DateTime AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ;
      private DateTime AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ;
      private DateTime A244AssinaturaParticipanteDataVisualizacao ;
      private DateTime A245AssinaturaParticipanteDataConclusao ;
      private bool returnInSub ;
      private bool AV49DynamicFiltersEnabled2 ;
      private bool AV54DynamicFiltersEnabled3 ;
      private bool AV70Wclistaassinantesds_7_dynamicfiltersenabled2 ;
      private bool AV75Wclistaassinantesds_12_dynamicfiltersenabled3 ;
      private bool BRK932 ;
      private bool n233ParticipanteId ;
      private bool n238AssinaturaId ;
      private bool n248ParticipanteNome ;
      private bool n245AssinaturaParticipanteDataConclusao ;
      private bool n244AssinaturaParticipanteDataVisualizacao ;
      private bool n353AssinaturaParticipanteStatus ;
      private bool n247AssinaturaParticipanteTipo ;
      private bool n234ParticipanteDocumento ;
      private bool n235ParticipanteEmail ;
      private bool BRK934 ;
      private bool BRK936 ;
      private string AV41OptionsJson ;
      private string AV42OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV60TFAssinaturaParticipanteTipo_SelsJson ;
      private string AV16TFAssinaturaParticipanteStatus_SelsJson ;
      private string AV38DDOName ;
      private string AV39SearchTxtParms ;
      private string AV40SearchTxtTo ;
      private string AV22SearchTxt ;
      private string AV44FilterFullText ;
      private string AV10TFParticipanteNome ;
      private string AV11TFParticipanteNome_Sel ;
      private string AV12TFParticipanteEmail ;
      private string AV13TFParticipanteEmail_Sel ;
      private string AV14TFParticipanteDocumento ;
      private string AV15TFParticipanteDocumento_Sel ;
      private string AV45DynamicFiltersSelector1 ;
      private string AV47AssinaturaParticipanteStatus1 ;
      private string AV48ParticipanteDocumento1 ;
      private string AV50DynamicFiltersSelector2 ;
      private string AV52AssinaturaParticipanteStatus2 ;
      private string AV53ParticipanteDocumento2 ;
      private string AV55DynamicFiltersSelector3 ;
      private string AV57AssinaturaParticipanteStatus3 ;
      private string AV58ParticipanteDocumento3 ;
      private string AV65Wclistaassinantesds_2_filterfulltext ;
      private string AV66Wclistaassinantesds_3_dynamicfiltersselector1 ;
      private string AV68Wclistaassinantesds_5_assinaturaparticipantestatus1 ;
      private string AV69Wclistaassinantesds_6_participantedocumento1 ;
      private string AV71Wclistaassinantesds_8_dynamicfiltersselector2 ;
      private string AV73Wclistaassinantesds_10_assinaturaparticipantestatus2 ;
      private string AV74Wclistaassinantesds_11_participantedocumento2 ;
      private string AV76Wclistaassinantesds_13_dynamicfiltersselector3 ;
      private string AV78Wclistaassinantesds_15_assinaturaparticipantestatus3 ;
      private string AV79Wclistaassinantesds_16_participantedocumento3 ;
      private string AV80Wclistaassinantesds_17_tfparticipantenome ;
      private string AV81Wclistaassinantesds_18_tfparticipantenome_sel ;
      private string AV82Wclistaassinantesds_19_tfparticipanteemail ;
      private string AV83Wclistaassinantesds_20_tfparticipanteemail_sel ;
      private string AV84Wclistaassinantesds_21_tfparticipantedocumento ;
      private string AV85Wclistaassinantesds_22_tfparticipantedocumento_sel ;
      private string lV65Wclistaassinantesds_2_filterfulltext ;
      private string lV69Wclistaassinantesds_6_participantedocumento1 ;
      private string lV74Wclistaassinantesds_11_participantedocumento2 ;
      private string lV79Wclistaassinantesds_16_participantedocumento3 ;
      private string lV80Wclistaassinantesds_17_tfparticipantenome ;
      private string lV82Wclistaassinantesds_19_tfparticipanteemail ;
      private string lV84Wclistaassinantesds_21_tfparticipantedocumento ;
      private string A247AssinaturaParticipanteTipo ;
      private string A353AssinaturaParticipanteStatus ;
      private string A248ParticipanteNome ;
      private string A235ParticipanteEmail ;
      private string A234ParticipanteDocumento ;
      private string AV27Option ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV28Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV31OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GxSimpleCollection<string> AV61TFAssinaturaParticipanteTipo_Sels ;
      private GxSimpleCollection<string> AV17TFAssinaturaParticipanteStatus_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV37GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ;
      private GxSimpleCollection<string> AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00932_A233ParticipanteId ;
      private bool[] P00932_n233ParticipanteId ;
      private long[] P00932_A238AssinaturaId ;
      private bool[] P00932_n238AssinaturaId ;
      private string[] P00932_A248ParticipanteNome ;
      private bool[] P00932_n248ParticipanteNome ;
      private DateTime[] P00932_A245AssinaturaParticipanteDataConclusao ;
      private bool[] P00932_n245AssinaturaParticipanteDataConclusao ;
      private DateTime[] P00932_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] P00932_n244AssinaturaParticipanteDataVisualizacao ;
      private string[] P00932_A353AssinaturaParticipanteStatus ;
      private bool[] P00932_n353AssinaturaParticipanteStatus ;
      private string[] P00932_A247AssinaturaParticipanteTipo ;
      private bool[] P00932_n247AssinaturaParticipanteTipo ;
      private string[] P00932_A234ParticipanteDocumento ;
      private bool[] P00932_n234ParticipanteDocumento ;
      private string[] P00932_A235ParticipanteEmail ;
      private bool[] P00932_n235ParticipanteEmail ;
      private int[] P00932_A242AssinaturaParticipanteId ;
      private int[] P00933_A233ParticipanteId ;
      private bool[] P00933_n233ParticipanteId ;
      private long[] P00933_A238AssinaturaId ;
      private bool[] P00933_n238AssinaturaId ;
      private string[] P00933_A235ParticipanteEmail ;
      private bool[] P00933_n235ParticipanteEmail ;
      private DateTime[] P00933_A245AssinaturaParticipanteDataConclusao ;
      private bool[] P00933_n245AssinaturaParticipanteDataConclusao ;
      private DateTime[] P00933_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] P00933_n244AssinaturaParticipanteDataVisualizacao ;
      private string[] P00933_A353AssinaturaParticipanteStatus ;
      private bool[] P00933_n353AssinaturaParticipanteStatus ;
      private string[] P00933_A247AssinaturaParticipanteTipo ;
      private bool[] P00933_n247AssinaturaParticipanteTipo ;
      private string[] P00933_A234ParticipanteDocumento ;
      private bool[] P00933_n234ParticipanteDocumento ;
      private string[] P00933_A248ParticipanteNome ;
      private bool[] P00933_n248ParticipanteNome ;
      private int[] P00933_A242AssinaturaParticipanteId ;
      private long[] P00934_A238AssinaturaId ;
      private bool[] P00934_n238AssinaturaId ;
      private int[] P00934_A233ParticipanteId ;
      private bool[] P00934_n233ParticipanteId ;
      private DateTime[] P00934_A245AssinaturaParticipanteDataConclusao ;
      private bool[] P00934_n245AssinaturaParticipanteDataConclusao ;
      private DateTime[] P00934_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] P00934_n244AssinaturaParticipanteDataVisualizacao ;
      private string[] P00934_A353AssinaturaParticipanteStatus ;
      private bool[] P00934_n353AssinaturaParticipanteStatus ;
      private string[] P00934_A247AssinaturaParticipanteTipo ;
      private bool[] P00934_n247AssinaturaParticipanteTipo ;
      private string[] P00934_A234ParticipanteDocumento ;
      private bool[] P00934_n234ParticipanteDocumento ;
      private string[] P00934_A235ParticipanteEmail ;
      private bool[] P00934_n235ParticipanteEmail ;
      private string[] P00934_A248ParticipanteNome ;
      private bool[] P00934_n248ParticipanteNome ;
      private int[] P00934_A242AssinaturaParticipanteId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wclistaassinantesgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00932( IGxContext context ,
                                             string A247AssinaturaParticipanteTipo ,
                                             GxSimpleCollection<string> AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ,
                                             string AV65Wclistaassinantesds_2_filterfulltext ,
                                             string AV66Wclistaassinantesds_3_dynamicfiltersselector1 ,
                                             string AV68Wclistaassinantesds_5_assinaturaparticipantestatus1 ,
                                             short AV67Wclistaassinantesds_4_dynamicfiltersoperator1 ,
                                             string AV69Wclistaassinantesds_6_participantedocumento1 ,
                                             bool AV70Wclistaassinantesds_7_dynamicfiltersenabled2 ,
                                             string AV71Wclistaassinantesds_8_dynamicfiltersselector2 ,
                                             string AV73Wclistaassinantesds_10_assinaturaparticipantestatus2 ,
                                             short AV72Wclistaassinantesds_9_dynamicfiltersoperator2 ,
                                             string AV74Wclistaassinantesds_11_participantedocumento2 ,
                                             bool AV75Wclistaassinantesds_12_dynamicfiltersenabled3 ,
                                             string AV76Wclistaassinantesds_13_dynamicfiltersselector3 ,
                                             string AV78Wclistaassinantesds_15_assinaturaparticipantestatus3 ,
                                             short AV77Wclistaassinantesds_14_dynamicfiltersoperator3 ,
                                             string AV79Wclistaassinantesds_16_participantedocumento3 ,
                                             string AV81Wclistaassinantesds_18_tfparticipantenome_sel ,
                                             string AV80Wclistaassinantesds_17_tfparticipantenome ,
                                             string AV83Wclistaassinantesds_20_tfparticipanteemail_sel ,
                                             string AV82Wclistaassinantesds_19_tfparticipanteemail ,
                                             string AV85Wclistaassinantesds_22_tfparticipantedocumento_sel ,
                                             string AV84Wclistaassinantesds_21_tfparticipantedocumento ,
                                             int AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count ,
                                             int AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             long AV64Wclistaassinantesds_1_assinaturaid ,
                                             long A238AssinaturaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[30];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteNome, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteStatus, T1.AssinaturaParticipanteTipo, T2.ParticipanteDocumento, T2.ParticipanteEmail, T1.AssinaturaParticipanteId FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV64Wclistaassinantesds_1_assinaturaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ParticipanteNome like '%' || :lV65Wclistaassinantesds_2_filterfulltext) or ( T2.ParticipanteEmail like '%' || :lV65Wclistaassinantesds_2_filterfulltext) or ( T2.ParticipanteDocumento like '%' || :lV65Wclistaassinantesds_2_filterfulltext) or ( 'contratada' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Contratado')) or ( 'contratante' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Contratante')) or ( 'testemunha' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Testemunha')) or ( 'sacado' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Sacado')) or ( 'pendente' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Pendente')) or ( 'assinado' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Assinado')) or ( 'recusado' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Recusado')))");
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
         }
         if ( ( StringUtil.StrCmp(AV66Wclistaassinantesds_3_dynamicfiltersselector1, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wclistaassinantesds_5_assinaturaparticipantestatus1)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV68Wclistaassinantesds_5_assinaturaparticipantestatus1))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Wclistaassinantesds_3_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV67Wclistaassinantesds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wclistaassinantesds_6_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV69Wclistaassinantesds_6_participantedocumento1)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Wclistaassinantesds_3_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV67Wclistaassinantesds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wclistaassinantesds_6_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV69Wclistaassinantesds_6_participantedocumento1)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV70Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wclistaassinantesds_8_dynamicfiltersselector2, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wclistaassinantesds_10_assinaturaparticipantestatus2)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV73Wclistaassinantesds_10_assinaturaparticipantestatus2))");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV70Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wclistaassinantesds_8_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV72Wclistaassinantesds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wclistaassinantesds_11_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV74Wclistaassinantesds_11_participantedocumento2)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV70Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wclistaassinantesds_8_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV72Wclistaassinantesds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wclistaassinantesds_11_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV74Wclistaassinantesds_11_participantedocumento2)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV75Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wclistaassinantesds_13_dynamicfiltersselector3, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wclistaassinantesds_15_assinaturaparticipantestatus3)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV78Wclistaassinantesds_15_assinaturaparticipantestatus3))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV75Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wclistaassinantesds_13_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV77Wclistaassinantesds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wclistaassinantesds_16_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV79Wclistaassinantesds_16_participantedocumento3)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV75Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wclistaassinantesds_13_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV77Wclistaassinantesds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wclistaassinantesds_16_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV79Wclistaassinantesds_16_participantedocumento3)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wclistaassinantesds_18_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wclistaassinantesds_17_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV80Wclistaassinantesds_17_tfparticipantenome)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wclistaassinantesds_18_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV81Wclistaassinantesds_18_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV81Wclistaassinantesds_18_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( StringUtil.StrCmp(AV81Wclistaassinantesds_18_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Wclistaassinantesds_20_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wclistaassinantesds_19_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV82Wclistaassinantesds_19_tfparticipanteemail)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wclistaassinantesds_20_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV83Wclistaassinantesds_20_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV83Wclistaassinantesds_20_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( StringUtil.StrCmp(AV83Wclistaassinantesds_20_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wclistaassinantesds_22_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wclistaassinantesds_21_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV84Wclistaassinantesds_21_tfparticipantedocumento)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wclistaassinantesds_22_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV85Wclistaassinantesds_22_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV85Wclistaassinantesds_22_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( StringUtil.StrCmp(AV85Wclistaassinantesds_22_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels, "T1.AssinaturaParticipanteTipo IN (", ")")+")");
         }
         if ( AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualiz)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualiz)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusa)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusa)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AssinaturaId, T2.ParticipanteNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00933( IGxContext context ,
                                             string A247AssinaturaParticipanteTipo ,
                                             GxSimpleCollection<string> AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ,
                                             string AV65Wclistaassinantesds_2_filterfulltext ,
                                             string AV66Wclistaassinantesds_3_dynamicfiltersselector1 ,
                                             string AV68Wclistaassinantesds_5_assinaturaparticipantestatus1 ,
                                             short AV67Wclistaassinantesds_4_dynamicfiltersoperator1 ,
                                             string AV69Wclistaassinantesds_6_participantedocumento1 ,
                                             bool AV70Wclistaassinantesds_7_dynamicfiltersenabled2 ,
                                             string AV71Wclistaassinantesds_8_dynamicfiltersselector2 ,
                                             string AV73Wclistaassinantesds_10_assinaturaparticipantestatus2 ,
                                             short AV72Wclistaassinantesds_9_dynamicfiltersoperator2 ,
                                             string AV74Wclistaassinantesds_11_participantedocumento2 ,
                                             bool AV75Wclistaassinantesds_12_dynamicfiltersenabled3 ,
                                             string AV76Wclistaassinantesds_13_dynamicfiltersselector3 ,
                                             string AV78Wclistaassinantesds_15_assinaturaparticipantestatus3 ,
                                             short AV77Wclistaassinantesds_14_dynamicfiltersoperator3 ,
                                             string AV79Wclistaassinantesds_16_participantedocumento3 ,
                                             string AV81Wclistaassinantesds_18_tfparticipantenome_sel ,
                                             string AV80Wclistaassinantesds_17_tfparticipantenome ,
                                             string AV83Wclistaassinantesds_20_tfparticipanteemail_sel ,
                                             string AV82Wclistaassinantesds_19_tfparticipanteemail ,
                                             string AV85Wclistaassinantesds_22_tfparticipantedocumento_sel ,
                                             string AV84Wclistaassinantesds_21_tfparticipantedocumento ,
                                             int AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count ,
                                             int AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             long AV64Wclistaassinantesds_1_assinaturaid ,
                                             long A238AssinaturaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[30];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteEmail, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteStatus, T1.AssinaturaParticipanteTipo, T2.ParticipanteDocumento, T2.ParticipanteNome, T1.AssinaturaParticipanteId FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV64Wclistaassinantesds_1_assinaturaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ParticipanteNome like '%' || :lV65Wclistaassinantesds_2_filterfulltext) or ( T2.ParticipanteEmail like '%' || :lV65Wclistaassinantesds_2_filterfulltext) or ( T2.ParticipanteDocumento like '%' || :lV65Wclistaassinantesds_2_filterfulltext) or ( 'contratada' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Contratado')) or ( 'contratante' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Contratante')) or ( 'testemunha' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Testemunha')) or ( 'sacado' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Sacado')) or ( 'pendente' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Pendente')) or ( 'assinado' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Assinado')) or ( 'recusado' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Recusado')))");
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
         }
         if ( ( StringUtil.StrCmp(AV66Wclistaassinantesds_3_dynamicfiltersselector1, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wclistaassinantesds_5_assinaturaparticipantestatus1)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV68Wclistaassinantesds_5_assinaturaparticipantestatus1))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Wclistaassinantesds_3_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV67Wclistaassinantesds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wclistaassinantesds_6_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV69Wclistaassinantesds_6_participantedocumento1)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Wclistaassinantesds_3_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV67Wclistaassinantesds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wclistaassinantesds_6_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV69Wclistaassinantesds_6_participantedocumento1)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV70Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wclistaassinantesds_8_dynamicfiltersselector2, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wclistaassinantesds_10_assinaturaparticipantestatus2)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV73Wclistaassinantesds_10_assinaturaparticipantestatus2))");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV70Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wclistaassinantesds_8_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV72Wclistaassinantesds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wclistaassinantesds_11_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV74Wclistaassinantesds_11_participantedocumento2)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV70Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wclistaassinantesds_8_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV72Wclistaassinantesds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wclistaassinantesds_11_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV74Wclistaassinantesds_11_participantedocumento2)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV75Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wclistaassinantesds_13_dynamicfiltersselector3, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wclistaassinantesds_15_assinaturaparticipantestatus3)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV78Wclistaassinantesds_15_assinaturaparticipantestatus3))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV75Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wclistaassinantesds_13_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV77Wclistaassinantesds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wclistaassinantesds_16_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV79Wclistaassinantesds_16_participantedocumento3)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( AV75Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wclistaassinantesds_13_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV77Wclistaassinantesds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wclistaassinantesds_16_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV79Wclistaassinantesds_16_participantedocumento3)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wclistaassinantesds_18_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wclistaassinantesds_17_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV80Wclistaassinantesds_17_tfparticipantenome)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wclistaassinantesds_18_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV81Wclistaassinantesds_18_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV81Wclistaassinantesds_18_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( StringUtil.StrCmp(AV81Wclistaassinantesds_18_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Wclistaassinantesds_20_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wclistaassinantesds_19_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV82Wclistaassinantesds_19_tfparticipanteemail)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wclistaassinantesds_20_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV83Wclistaassinantesds_20_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV83Wclistaassinantesds_20_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( StringUtil.StrCmp(AV83Wclistaassinantesds_20_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wclistaassinantesds_22_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wclistaassinantesds_21_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV84Wclistaassinantesds_21_tfparticipantedocumento)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wclistaassinantesds_22_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV85Wclistaassinantesds_22_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV85Wclistaassinantesds_22_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( StringUtil.StrCmp(AV85Wclistaassinantesds_22_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels, "T1.AssinaturaParticipanteTipo IN (", ")")+")");
         }
         if ( AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualiz)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualiz)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusa)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusa)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AssinaturaId, T2.ParticipanteEmail";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00934( IGxContext context ,
                                             string A247AssinaturaParticipanteTipo ,
                                             GxSimpleCollection<string> AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels ,
                                             string AV65Wclistaassinantesds_2_filterfulltext ,
                                             string AV66Wclistaassinantesds_3_dynamicfiltersselector1 ,
                                             string AV68Wclistaassinantesds_5_assinaturaparticipantestatus1 ,
                                             short AV67Wclistaassinantesds_4_dynamicfiltersoperator1 ,
                                             string AV69Wclistaassinantesds_6_participantedocumento1 ,
                                             bool AV70Wclistaassinantesds_7_dynamicfiltersenabled2 ,
                                             string AV71Wclistaassinantesds_8_dynamicfiltersselector2 ,
                                             string AV73Wclistaassinantesds_10_assinaturaparticipantestatus2 ,
                                             short AV72Wclistaassinantesds_9_dynamicfiltersoperator2 ,
                                             string AV74Wclistaassinantesds_11_participantedocumento2 ,
                                             bool AV75Wclistaassinantesds_12_dynamicfiltersenabled3 ,
                                             string AV76Wclistaassinantesds_13_dynamicfiltersselector3 ,
                                             string AV78Wclistaassinantesds_15_assinaturaparticipantestatus3 ,
                                             short AV77Wclistaassinantesds_14_dynamicfiltersoperator3 ,
                                             string AV79Wclistaassinantesds_16_participantedocumento3 ,
                                             string AV81Wclistaassinantesds_18_tfparticipantenome_sel ,
                                             string AV80Wclistaassinantesds_17_tfparticipantenome ,
                                             string AV83Wclistaassinantesds_20_tfparticipanteemail_sel ,
                                             string AV82Wclistaassinantesds_19_tfparticipanteemail ,
                                             string AV85Wclistaassinantesds_22_tfparticipantedocumento_sel ,
                                             string AV84Wclistaassinantesds_21_tfparticipantedocumento ,
                                             int AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count ,
                                             int AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             long AV64Wclistaassinantesds_1_assinaturaid ,
                                             long A238AssinaturaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[30];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.AssinaturaId, T1.ParticipanteId, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteStatus, T1.AssinaturaParticipanteTipo, T2.ParticipanteDocumento, T2.ParticipanteEmail, T2.ParticipanteNome, T1.AssinaturaParticipanteId FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV64Wclistaassinantesds_1_assinaturaid)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wclistaassinantesds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.ParticipanteNome like '%' || :lV65Wclistaassinantesds_2_filterfulltext) or ( T2.ParticipanteEmail like '%' || :lV65Wclistaassinantesds_2_filterfulltext) or ( T2.ParticipanteDocumento like '%' || :lV65Wclistaassinantesds_2_filterfulltext) or ( 'contratada' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Contratado')) or ( 'contratante' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Contratante')) or ( 'testemunha' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Testemunha')) or ( 'sacado' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteTipo = ( 'Sacado')) or ( 'pendente' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Pendente')) or ( 'assinado' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Assinado')) or ( 'recusado' like '%' || LOWER(:lV65Wclistaassinantesds_2_filterfulltext) and T1.AssinaturaParticipanteStatus = ( 'Recusado')))");
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
         }
         if ( ( StringUtil.StrCmp(AV66Wclistaassinantesds_3_dynamicfiltersselector1, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wclistaassinantesds_5_assinaturaparticipantestatus1)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV68Wclistaassinantesds_5_assinaturaparticipantestatus1))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Wclistaassinantesds_3_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV67Wclistaassinantesds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wclistaassinantesds_6_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV69Wclistaassinantesds_6_participantedocumento1)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Wclistaassinantesds_3_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV67Wclistaassinantesds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wclistaassinantesds_6_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV69Wclistaassinantesds_6_participantedocumento1)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV70Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wclistaassinantesds_8_dynamicfiltersselector2, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Wclistaassinantesds_10_assinaturaparticipantestatus2)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV73Wclistaassinantesds_10_assinaturaparticipantestatus2))");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV70Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wclistaassinantesds_8_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV72Wclistaassinantesds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wclistaassinantesds_11_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV74Wclistaassinantesds_11_participantedocumento2)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV70Wclistaassinantesds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Wclistaassinantesds_8_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV72Wclistaassinantesds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wclistaassinantesds_11_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV74Wclistaassinantesds_11_participantedocumento2)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV75Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wclistaassinantesds_13_dynamicfiltersselector3, "ASSINATURAPARTICIPANTESTATUS") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wclistaassinantesds_15_assinaturaparticipantestatus3)) ) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteStatus = ( :AV78Wclistaassinantesds_15_assinaturaparticipantestatus3))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV75Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wclistaassinantesds_13_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV77Wclistaassinantesds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wclistaassinantesds_16_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV79Wclistaassinantesds_16_participantedocumento3)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( AV75Wclistaassinantesds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Wclistaassinantesds_13_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( AV77Wclistaassinantesds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wclistaassinantesds_16_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like '%' || :lV79Wclistaassinantesds_16_participantedocumento3)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wclistaassinantesds_18_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wclistaassinantesds_17_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV80Wclistaassinantesds_17_tfparticipantenome)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wclistaassinantesds_18_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV81Wclistaassinantesds_18_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV81Wclistaassinantesds_18_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( StringUtil.StrCmp(AV81Wclistaassinantesds_18_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Wclistaassinantesds_20_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wclistaassinantesds_19_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV82Wclistaassinantesds_19_tfparticipanteemail)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wclistaassinantesds_20_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV83Wclistaassinantesds_20_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV83Wclistaassinantesds_20_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( StringUtil.StrCmp(AV83Wclistaassinantesds_20_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wclistaassinantesds_22_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wclistaassinantesds_21_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV84Wclistaassinantesds_21_tfparticipantedocumento)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wclistaassinantesds_22_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV85Wclistaassinantesds_22_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV85Wclistaassinantesds_22_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( StringUtil.StrCmp(AV85Wclistaassinantesds_22_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV86Wclistaassinantesds_23_tfassinaturaparticipantetipo_sels, "T1.AssinaturaParticipanteTipo IN (", ")")+")");
         }
         if ( AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV87Wclistaassinantesds_24_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualiz)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualiz)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusa)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusa)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AssinaturaId, T1.ParticipanteId";
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
                     return conditional_P00932(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (long)dynConstraints[36] , (long)dynConstraints[37] );
               case 1 :
                     return conditional_P00933(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (long)dynConstraints[36] , (long)dynConstraints[37] );
               case 2 :
                     return conditional_P00934(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (DateTime)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (DateTime)dynConstraints[34] , (DateTime)dynConstraints[35] , (long)dynConstraints[36] , (long)dynConstraints[37] );
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
          Object[] prmP00932;
          prmP00932 = new Object[] {
          new ParDef("AV64Wclistaassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV68Wclistaassinantesds_5_assinaturaparticipantestatus1",GXType.VarChar,40,0) ,
          new ParDef("lV69Wclistaassinantesds_6_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("lV69Wclistaassinantesds_6_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("AV73Wclistaassinantesds_10_assinaturaparticipantestatus2",GXType.VarChar,40,0) ,
          new ParDef("lV74Wclistaassinantesds_11_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("lV74Wclistaassinantesds_11_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("AV78Wclistaassinantesds_15_assinaturaparticipantestatus3",GXType.VarChar,40,0) ,
          new ParDef("lV79Wclistaassinantesds_16_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("lV79Wclistaassinantesds_16_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("lV80Wclistaassinantesds_17_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV81Wclistaassinantesds_18_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV82Wclistaassinantesds_19_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV83Wclistaassinantesds_20_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV84Wclistaassinantesds_21_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV85Wclistaassinantesds_22_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualiz",GXType.DateTime,10,8) ,
          new ParDef("AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualiz",GXType.DateTime,10,8) ,
          new ParDef("AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusa",GXType.DateTime,10,8) ,
          new ParDef("AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusa",GXType.DateTime,10,8)
          };
          Object[] prmP00933;
          prmP00933 = new Object[] {
          new ParDef("AV64Wclistaassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV68Wclistaassinantesds_5_assinaturaparticipantestatus1",GXType.VarChar,40,0) ,
          new ParDef("lV69Wclistaassinantesds_6_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("lV69Wclistaassinantesds_6_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("AV73Wclistaassinantesds_10_assinaturaparticipantestatus2",GXType.VarChar,40,0) ,
          new ParDef("lV74Wclistaassinantesds_11_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("lV74Wclistaassinantesds_11_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("AV78Wclistaassinantesds_15_assinaturaparticipantestatus3",GXType.VarChar,40,0) ,
          new ParDef("lV79Wclistaassinantesds_16_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("lV79Wclistaassinantesds_16_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("lV80Wclistaassinantesds_17_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV81Wclistaassinantesds_18_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV82Wclistaassinantesds_19_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV83Wclistaassinantesds_20_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV84Wclistaassinantesds_21_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV85Wclistaassinantesds_22_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualiz",GXType.DateTime,10,8) ,
          new ParDef("AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualiz",GXType.DateTime,10,8) ,
          new ParDef("AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusa",GXType.DateTime,10,8) ,
          new ParDef("AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusa",GXType.DateTime,10,8)
          };
          Object[] prmP00934;
          prmP00934 = new Object[] {
          new ParDef("AV64Wclistaassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV65Wclistaassinantesds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV68Wclistaassinantesds_5_assinaturaparticipantestatus1",GXType.VarChar,40,0) ,
          new ParDef("lV69Wclistaassinantesds_6_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("lV69Wclistaassinantesds_6_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("AV73Wclistaassinantesds_10_assinaturaparticipantestatus2",GXType.VarChar,40,0) ,
          new ParDef("lV74Wclistaassinantesds_11_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("lV74Wclistaassinantesds_11_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("AV78Wclistaassinantesds_15_assinaturaparticipantestatus3",GXType.VarChar,40,0) ,
          new ParDef("lV79Wclistaassinantesds_16_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("lV79Wclistaassinantesds_16_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("lV80Wclistaassinantesds_17_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV81Wclistaassinantesds_18_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV82Wclistaassinantesds_19_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV83Wclistaassinantesds_20_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV84Wclistaassinantesds_21_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV85Wclistaassinantesds_22_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV88Wclistaassinantesds_25_tfassinaturaparticipantedatavisualiz",GXType.DateTime,10,8) ,
          new ParDef("AV89Wclistaassinantesds_26_tfassinaturaparticipantedatavisualiz",GXType.DateTime,10,8) ,
          new ParDef("AV90Wclistaassinantesds_27_tfassinaturaparticipantedataconclusa",GXType.DateTime,10,8) ,
          new ParDef("AV91Wclistaassinantesds_28_tfassinaturaparticipantedataconclusa",GXType.DateTime,10,8)
          };
          def= new CursorDef[] {
              new CursorDef("P00932", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00932,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00933", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00933,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00934", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00934,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((string[]) buf[12])[0] = rslt.getVarchar(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((string[]) buf[14])[0] = rslt.getVarchar(8);
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((string[]) buf[16])[0] = rslt.getVarchar(9);
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((int[]) buf[18])[0] = rslt.getInt(10);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
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
                ((int[]) buf[18])[0] = rslt.getInt(10);
                return;
       }
    }

 }

}
