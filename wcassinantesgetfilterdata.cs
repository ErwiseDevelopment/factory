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
   public class wcassinantesgetfilterdata : GXProcedure
   {
      public wcassinantesgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wcassinantesgetfilterdata( IGxContext context )
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
         this.AV62DDOName = aP0_DDOName;
         this.AV63SearchTxtParms = aP1_SearchTxtParms;
         this.AV64SearchTxtTo = aP2_SearchTxtTo;
         this.AV65OptionsJson = "" ;
         this.AV66OptionsDescJson = "" ;
         this.AV67OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV65OptionsJson;
         aP4_OptionsDescJson=this.AV66OptionsDescJson;
         aP5_OptionIndexesJson=this.AV67OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV67OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV62DDOName = aP0_DDOName;
         this.AV63SearchTxtParms = aP1_SearchTxtParms;
         this.AV64SearchTxtTo = aP2_SearchTxtTo;
         this.AV65OptionsJson = "" ;
         this.AV66OptionsDescJson = "" ;
         this.AV67OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV65OptionsJson;
         aP4_OptionsDescJson=this.AV66OptionsDescJson;
         aP5_OptionIndexesJson=this.AV67OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV52Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV54OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV55OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV49MaxItems = 10;
         AV48PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV63SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV63SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV46SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV63SearchTxtParms)) ? "" : StringUtil.Substring( AV63SearchTxtParms, 3, -1));
         AV47SkipItems = (short)(AV48PageIndex*AV49MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_PARTICIPANTENOME") == 0 )
         {
            /* Execute user subroutine: 'LOADPARTICIPANTENOMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_PARTICIPANTEEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADPARTICIPANTEEMAILOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_PARTICIPANTEDOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADPARTICIPANTEDOCUMENTOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_PARTICIPANTEREPRESENTANTENOME") == 0 )
         {
            /* Execute user subroutine: 'LOADPARTICIPANTEREPRESENTANTENOMEOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_PARTICIPANTEREPRESENTANTEEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADPARTICIPANTEREPRESENTANTEEMAILOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_PARTICIPANTEREPRESENTANTEDOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADPARTICIPANTEREPRESENTANTEDOCUMENTOOPTIONS' */
            S171 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV65OptionsJson = AV52Options.ToJSonString(false);
         AV66OptionsDescJson = AV54OptionsDesc.ToJSonString(false);
         AV67OptionIndexesJson = AV55OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV57Session.Get("WcAssinantesGridState"), "") == 0 )
         {
            AV59GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WcAssinantesGridState"), null, "", "");
         }
         else
         {
            AV59GridState.FromXml(AV57Session.Get("WcAssinantesGridState"), null, "", "");
         }
         AV75GXV1 = 1;
         while ( AV75GXV1 <= AV59GridState.gxTpr_Filtervalues.Count )
         {
            AV60GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV59GridState.gxTpr_Filtervalues.Item(AV75GXV1));
            if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME") == 0 )
            {
               AV18TFParticipanteNome = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTENOME_SEL") == 0 )
            {
               AV19TFParticipanteNome_Sel = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL") == 0 )
            {
               AV20TFParticipanteEmail = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL_SEL") == 0 )
            {
               AV21TFParticipanteEmail_Sel = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO") == 0 )
            {
               AV22TFParticipanteDocumento = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO_SEL") == 0 )
            {
               AV23TFParticipanteDocumento_Sel = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEREPRESENTANTENOME") == 0 )
            {
               AV69TFParticipanteRepresentanteNome = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEREPRESENTANTENOME_SEL") == 0 )
            {
               AV70TFParticipanteRepresentanteNome_Sel = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEREPRESENTANTEEMAIL") == 0 )
            {
               AV71TFParticipanteRepresentanteEmail = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEREPRESENTANTEEMAIL_SEL") == 0 )
            {
               AV72TFParticipanteRepresentanteEmail_Sel = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEREPRESENTANTEDOCUMENTO") == 0 )
            {
               AV73TFParticipanteRepresentanteDocumento = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEREPRESENTANTEDOCUMENTO_SEL") == 0 )
            {
               AV74TFParticipanteRepresentanteDocumento_Sel = AV60GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTESTATUS_SEL") == 0 )
            {
               AV24TFAssinaturaParticipanteStatus_SelsJson = AV60GridStateFilterValue.gxTpr_Value;
               AV25TFAssinaturaParticipanteStatus_Sels.FromJSonString(AV24TFAssinaturaParticipanteStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTEDATAVISUALIZACAO") == 0 )
            {
               AV26TFAssinaturaParticipanteDataVisualizacao = context.localUtil.CToT( AV60GridStateFilterValue.gxTpr_Value, 4);
               AV27TFAssinaturaParticipanteDataVisualizacao_To = context.localUtil.CToT( AV60GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "TFASSINATURAPARTICIPANTEDATACONCLUSAO") == 0 )
            {
               AV28TFAssinaturaParticipanteDataConclusao = context.localUtil.CToT( AV60GridStateFilterValue.gxTpr_Value, 4);
               AV29TFAssinaturaParticipanteDataConclusao_To = context.localUtil.CToT( AV60GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV60GridStateFilterValue.gxTpr_Name, "PARM_&ASSINATURAID") == 0 )
            {
               AV68AssinaturaId = (long)(Math.Round(NumberUtil.Val( AV60GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV75GXV1 = (int)(AV75GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPARTICIPANTENOMEOPTIONS' Routine */
         returnInSub = false;
         AV18TFParticipanteNome = AV46SearchTxt;
         AV19TFParticipanteNome_Sel = "";
         AV77Wcassinantesds_1_assinaturaid = AV68AssinaturaId;
         AV78Wcassinantesds_2_tfparticipantenome = AV18TFParticipanteNome;
         AV79Wcassinantesds_3_tfparticipantenome_sel = AV19TFParticipanteNome_Sel;
         AV80Wcassinantesds_4_tfparticipanteemail = AV20TFParticipanteEmail;
         AV81Wcassinantesds_5_tfparticipanteemail_sel = AV21TFParticipanteEmail_Sel;
         AV82Wcassinantesds_6_tfparticipantedocumento = AV22TFParticipanteDocumento;
         AV83Wcassinantesds_7_tfparticipantedocumento_sel = AV23TFParticipanteDocumento_Sel;
         AV84Wcassinantesds_8_tfparticipanterepresentantenome = AV69TFParticipanteRepresentanteNome;
         AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV70TFParticipanteRepresentanteNome_Sel;
         AV86Wcassinantesds_10_tfparticipanterepresentanteemail = AV71TFParticipanteRepresentanteEmail;
         AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV72TFParticipanteRepresentanteEmail_Sel;
         AV88Wcassinantesds_12_tfparticipanterepresentantedocumento = AV73TFParticipanteRepresentanteDocumento;
         AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV74TFParticipanteRepresentanteDocumento_Sel;
         AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV25TFAssinaturaParticipanteStatus_Sels;
         AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV26TFAssinaturaParticipanteDataVisualizacao;
         AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV27TFAssinaturaParticipanteDataVisualizacao_To;
         AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV28TFAssinaturaParticipanteDataConclusao;
         AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV29TFAssinaturaParticipanteDataConclusao_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A353AssinaturaParticipanteStatus ,
                                              AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                              AV79Wcassinantesds_3_tfparticipantenome_sel ,
                                              AV78Wcassinantesds_2_tfparticipantenome ,
                                              AV81Wcassinantesds_5_tfparticipanteemail_sel ,
                                              AV80Wcassinantesds_4_tfparticipanteemail ,
                                              AV83Wcassinantesds_7_tfparticipantedocumento_sel ,
                                              AV82Wcassinantesds_6_tfparticipantedocumento ,
                                              AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                              AV84Wcassinantesds_8_tfparticipanterepresentantenome ,
                                              AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                              AV86Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                              AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                              AV88Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                              AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels.Count ,
                                              AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                              AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                              AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                              AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                              A248ParticipanteNome ,
                                              A235ParticipanteEmail ,
                                              A234ParticipanteDocumento ,
                                              A1002ParticipanteRepresentanteNome ,
                                              A1003ParticipanteRepresentanteEmail ,
                                              A1004ParticipanteRepresentanteDocumento ,
                                              A244AssinaturaParticipanteDataVisualizacao ,
                                              A245AssinaturaParticipanteDataConclusao ,
                                              AV77Wcassinantesds_1_assinaturaid ,
                                              A238AssinaturaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV78Wcassinantesds_2_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV78Wcassinantesds_2_tfparticipantenome), "%", "");
         lV80Wcassinantesds_4_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV80Wcassinantesds_4_tfparticipanteemail), "%", "");
         lV82Wcassinantesds_6_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV82Wcassinantesds_6_tfparticipantedocumento), "%", "");
         lV84Wcassinantesds_8_tfparticipanterepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV84Wcassinantesds_8_tfparticipanterepresentantenome), "%", "");
         lV86Wcassinantesds_10_tfparticipanterepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV86Wcassinantesds_10_tfparticipanterepresentanteemail), "%", "");
         lV88Wcassinantesds_12_tfparticipanterepresentantedocumento = StringUtil.Concat( StringUtil.RTrim( AV88Wcassinantesds_12_tfparticipanterepresentantedocumento), "%", "");
         /* Using cursor P00AE2 */
         pr_default.execute(0, new Object[] {AV77Wcassinantesds_1_assinaturaid, lV78Wcassinantesds_2_tfparticipantenome, AV79Wcassinantesds_3_tfparticipantenome_sel, lV80Wcassinantesds_4_tfparticipanteemail, AV81Wcassinantesds_5_tfparticipanteemail_sel, lV82Wcassinantesds_6_tfparticipantedocumento, AV83Wcassinantesds_7_tfparticipantedocumento_sel, lV84Wcassinantesds_8_tfparticipanterepresentantenome, AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, lV86Wcassinantesds_10_tfparticipanterepresentanteemail, AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, lV88Wcassinantesds_12_tfparticipanterepresentantedocumento, AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao, AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to, AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao, AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAE2 = false;
            A233ParticipanteId = P00AE2_A233ParticipanteId[0];
            n233ParticipanteId = P00AE2_n233ParticipanteId[0];
            A238AssinaturaId = P00AE2_A238AssinaturaId[0];
            n238AssinaturaId = P00AE2_n238AssinaturaId[0];
            A248ParticipanteNome = P00AE2_A248ParticipanteNome[0];
            n248ParticipanteNome = P00AE2_n248ParticipanteNome[0];
            A245AssinaturaParticipanteDataConclusao = P00AE2_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = P00AE2_n245AssinaturaParticipanteDataConclusao[0];
            A244AssinaturaParticipanteDataVisualizacao = P00AE2_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = P00AE2_n244AssinaturaParticipanteDataVisualizacao[0];
            A353AssinaturaParticipanteStatus = P00AE2_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = P00AE2_n353AssinaturaParticipanteStatus[0];
            A1004ParticipanteRepresentanteDocumento = P00AE2_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = P00AE2_n1004ParticipanteRepresentanteDocumento[0];
            A1003ParticipanteRepresentanteEmail = P00AE2_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = P00AE2_n1003ParticipanteRepresentanteEmail[0];
            A1002ParticipanteRepresentanteNome = P00AE2_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = P00AE2_n1002ParticipanteRepresentanteNome[0];
            A234ParticipanteDocumento = P00AE2_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00AE2_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00AE2_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00AE2_n235ParticipanteEmail[0];
            A242AssinaturaParticipanteId = P00AE2_A242AssinaturaParticipanteId[0];
            A248ParticipanteNome = P00AE2_A248ParticipanteNome[0];
            n248ParticipanteNome = P00AE2_n248ParticipanteNome[0];
            A1004ParticipanteRepresentanteDocumento = P00AE2_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = P00AE2_n1004ParticipanteRepresentanteDocumento[0];
            A1003ParticipanteRepresentanteEmail = P00AE2_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = P00AE2_n1003ParticipanteRepresentanteEmail[0];
            A1002ParticipanteRepresentanteNome = P00AE2_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = P00AE2_n1002ParticipanteRepresentanteNome[0];
            A234ParticipanteDocumento = P00AE2_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00AE2_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00AE2_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00AE2_n235ParticipanteEmail[0];
            AV56count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P00AE2_A238AssinaturaId[0] == A238AssinaturaId ) && ( StringUtil.StrCmp(P00AE2_A248ParticipanteNome[0], A248ParticipanteNome) == 0 ) )
            {
               BRKAE2 = false;
               A233ParticipanteId = P00AE2_A233ParticipanteId[0];
               n233ParticipanteId = P00AE2_n233ParticipanteId[0];
               A242AssinaturaParticipanteId = P00AE2_A242AssinaturaParticipanteId[0];
               AV56count = (long)(AV56count+1);
               BRKAE2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV47SkipItems) )
            {
               AV51Option = (String.IsNullOrEmpty(StringUtil.RTrim( A248ParticipanteNome)) ? "<#Empty#>" : A248ParticipanteNome);
               AV52Options.Add(AV51Option, 0);
               AV55OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV56count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV52Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV47SkipItems = (short)(AV47SkipItems-1);
            }
            if ( ! BRKAE2 )
            {
               BRKAE2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPARTICIPANTEEMAILOPTIONS' Routine */
         returnInSub = false;
         AV20TFParticipanteEmail = AV46SearchTxt;
         AV21TFParticipanteEmail_Sel = "";
         AV77Wcassinantesds_1_assinaturaid = AV68AssinaturaId;
         AV78Wcassinantesds_2_tfparticipantenome = AV18TFParticipanteNome;
         AV79Wcassinantesds_3_tfparticipantenome_sel = AV19TFParticipanteNome_Sel;
         AV80Wcassinantesds_4_tfparticipanteemail = AV20TFParticipanteEmail;
         AV81Wcassinantesds_5_tfparticipanteemail_sel = AV21TFParticipanteEmail_Sel;
         AV82Wcassinantesds_6_tfparticipantedocumento = AV22TFParticipanteDocumento;
         AV83Wcassinantesds_7_tfparticipantedocumento_sel = AV23TFParticipanteDocumento_Sel;
         AV84Wcassinantesds_8_tfparticipanterepresentantenome = AV69TFParticipanteRepresentanteNome;
         AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV70TFParticipanteRepresentanteNome_Sel;
         AV86Wcassinantesds_10_tfparticipanterepresentanteemail = AV71TFParticipanteRepresentanteEmail;
         AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV72TFParticipanteRepresentanteEmail_Sel;
         AV88Wcassinantesds_12_tfparticipanterepresentantedocumento = AV73TFParticipanteRepresentanteDocumento;
         AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV74TFParticipanteRepresentanteDocumento_Sel;
         AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV25TFAssinaturaParticipanteStatus_Sels;
         AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV26TFAssinaturaParticipanteDataVisualizacao;
         AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV27TFAssinaturaParticipanteDataVisualizacao_To;
         AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV28TFAssinaturaParticipanteDataConclusao;
         AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV29TFAssinaturaParticipanteDataConclusao_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A353AssinaturaParticipanteStatus ,
                                              AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                              AV79Wcassinantesds_3_tfparticipantenome_sel ,
                                              AV78Wcassinantesds_2_tfparticipantenome ,
                                              AV81Wcassinantesds_5_tfparticipanteemail_sel ,
                                              AV80Wcassinantesds_4_tfparticipanteemail ,
                                              AV83Wcassinantesds_7_tfparticipantedocumento_sel ,
                                              AV82Wcassinantesds_6_tfparticipantedocumento ,
                                              AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                              AV84Wcassinantesds_8_tfparticipanterepresentantenome ,
                                              AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                              AV86Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                              AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                              AV88Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                              AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels.Count ,
                                              AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                              AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                              AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                              AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                              A248ParticipanteNome ,
                                              A235ParticipanteEmail ,
                                              A234ParticipanteDocumento ,
                                              A1002ParticipanteRepresentanteNome ,
                                              A1003ParticipanteRepresentanteEmail ,
                                              A1004ParticipanteRepresentanteDocumento ,
                                              A244AssinaturaParticipanteDataVisualizacao ,
                                              A245AssinaturaParticipanteDataConclusao ,
                                              AV77Wcassinantesds_1_assinaturaid ,
                                              A238AssinaturaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV78Wcassinantesds_2_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV78Wcassinantesds_2_tfparticipantenome), "%", "");
         lV80Wcassinantesds_4_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV80Wcassinantesds_4_tfparticipanteemail), "%", "");
         lV82Wcassinantesds_6_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV82Wcassinantesds_6_tfparticipantedocumento), "%", "");
         lV84Wcassinantesds_8_tfparticipanterepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV84Wcassinantesds_8_tfparticipanterepresentantenome), "%", "");
         lV86Wcassinantesds_10_tfparticipanterepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV86Wcassinantesds_10_tfparticipanterepresentanteemail), "%", "");
         lV88Wcassinantesds_12_tfparticipanterepresentantedocumento = StringUtil.Concat( StringUtil.RTrim( AV88Wcassinantesds_12_tfparticipanterepresentantedocumento), "%", "");
         /* Using cursor P00AE3 */
         pr_default.execute(1, new Object[] {AV77Wcassinantesds_1_assinaturaid, lV78Wcassinantesds_2_tfparticipantenome, AV79Wcassinantesds_3_tfparticipantenome_sel, lV80Wcassinantesds_4_tfparticipanteemail, AV81Wcassinantesds_5_tfparticipanteemail_sel, lV82Wcassinantesds_6_tfparticipantedocumento, AV83Wcassinantesds_7_tfparticipantedocumento_sel, lV84Wcassinantesds_8_tfparticipanterepresentantenome, AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, lV86Wcassinantesds_10_tfparticipanterepresentanteemail, AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, lV88Wcassinantesds_12_tfparticipanterepresentantedocumento, AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao, AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to, AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao, AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAE4 = false;
            A233ParticipanteId = P00AE3_A233ParticipanteId[0];
            n233ParticipanteId = P00AE3_n233ParticipanteId[0];
            A238AssinaturaId = P00AE3_A238AssinaturaId[0];
            n238AssinaturaId = P00AE3_n238AssinaturaId[0];
            A235ParticipanteEmail = P00AE3_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00AE3_n235ParticipanteEmail[0];
            A245AssinaturaParticipanteDataConclusao = P00AE3_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = P00AE3_n245AssinaturaParticipanteDataConclusao[0];
            A244AssinaturaParticipanteDataVisualizacao = P00AE3_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = P00AE3_n244AssinaturaParticipanteDataVisualizacao[0];
            A353AssinaturaParticipanteStatus = P00AE3_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = P00AE3_n353AssinaturaParticipanteStatus[0];
            A1004ParticipanteRepresentanteDocumento = P00AE3_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = P00AE3_n1004ParticipanteRepresentanteDocumento[0];
            A1003ParticipanteRepresentanteEmail = P00AE3_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = P00AE3_n1003ParticipanteRepresentanteEmail[0];
            A1002ParticipanteRepresentanteNome = P00AE3_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = P00AE3_n1002ParticipanteRepresentanteNome[0];
            A234ParticipanteDocumento = P00AE3_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00AE3_n234ParticipanteDocumento[0];
            A248ParticipanteNome = P00AE3_A248ParticipanteNome[0];
            n248ParticipanteNome = P00AE3_n248ParticipanteNome[0];
            A242AssinaturaParticipanteId = P00AE3_A242AssinaturaParticipanteId[0];
            A235ParticipanteEmail = P00AE3_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00AE3_n235ParticipanteEmail[0];
            A1004ParticipanteRepresentanteDocumento = P00AE3_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = P00AE3_n1004ParticipanteRepresentanteDocumento[0];
            A1003ParticipanteRepresentanteEmail = P00AE3_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = P00AE3_n1003ParticipanteRepresentanteEmail[0];
            A1002ParticipanteRepresentanteNome = P00AE3_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = P00AE3_n1002ParticipanteRepresentanteNome[0];
            A234ParticipanteDocumento = P00AE3_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00AE3_n234ParticipanteDocumento[0];
            A248ParticipanteNome = P00AE3_A248ParticipanteNome[0];
            n248ParticipanteNome = P00AE3_n248ParticipanteNome[0];
            AV56count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00AE3_A238AssinaturaId[0] == A238AssinaturaId ) && ( StringUtil.StrCmp(P00AE3_A235ParticipanteEmail[0], A235ParticipanteEmail) == 0 ) )
            {
               BRKAE4 = false;
               A233ParticipanteId = P00AE3_A233ParticipanteId[0];
               n233ParticipanteId = P00AE3_n233ParticipanteId[0];
               A242AssinaturaParticipanteId = P00AE3_A242AssinaturaParticipanteId[0];
               AV56count = (long)(AV56count+1);
               BRKAE4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV47SkipItems) )
            {
               AV51Option = (String.IsNullOrEmpty(StringUtil.RTrim( A235ParticipanteEmail)) ? "<#Empty#>" : A235ParticipanteEmail);
               AV52Options.Add(AV51Option, 0);
               AV55OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV56count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV52Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV47SkipItems = (short)(AV47SkipItems-1);
            }
            if ( ! BRKAE4 )
            {
               BRKAE4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPARTICIPANTEDOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV22TFParticipanteDocumento = AV46SearchTxt;
         AV23TFParticipanteDocumento_Sel = "";
         AV77Wcassinantesds_1_assinaturaid = AV68AssinaturaId;
         AV78Wcassinantesds_2_tfparticipantenome = AV18TFParticipanteNome;
         AV79Wcassinantesds_3_tfparticipantenome_sel = AV19TFParticipanteNome_Sel;
         AV80Wcassinantesds_4_tfparticipanteemail = AV20TFParticipanteEmail;
         AV81Wcassinantesds_5_tfparticipanteemail_sel = AV21TFParticipanteEmail_Sel;
         AV82Wcassinantesds_6_tfparticipantedocumento = AV22TFParticipanteDocumento;
         AV83Wcassinantesds_7_tfparticipantedocumento_sel = AV23TFParticipanteDocumento_Sel;
         AV84Wcassinantesds_8_tfparticipanterepresentantenome = AV69TFParticipanteRepresentanteNome;
         AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV70TFParticipanteRepresentanteNome_Sel;
         AV86Wcassinantesds_10_tfparticipanterepresentanteemail = AV71TFParticipanteRepresentanteEmail;
         AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV72TFParticipanteRepresentanteEmail_Sel;
         AV88Wcassinantesds_12_tfparticipanterepresentantedocumento = AV73TFParticipanteRepresentanteDocumento;
         AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV74TFParticipanteRepresentanteDocumento_Sel;
         AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV25TFAssinaturaParticipanteStatus_Sels;
         AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV26TFAssinaturaParticipanteDataVisualizacao;
         AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV27TFAssinaturaParticipanteDataVisualizacao_To;
         AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV28TFAssinaturaParticipanteDataConclusao;
         AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV29TFAssinaturaParticipanteDataConclusao_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A353AssinaturaParticipanteStatus ,
                                              AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                              AV79Wcassinantesds_3_tfparticipantenome_sel ,
                                              AV78Wcassinantesds_2_tfparticipantenome ,
                                              AV81Wcassinantesds_5_tfparticipanteemail_sel ,
                                              AV80Wcassinantesds_4_tfparticipanteemail ,
                                              AV83Wcassinantesds_7_tfparticipantedocumento_sel ,
                                              AV82Wcassinantesds_6_tfparticipantedocumento ,
                                              AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                              AV84Wcassinantesds_8_tfparticipanterepresentantenome ,
                                              AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                              AV86Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                              AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                              AV88Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                              AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels.Count ,
                                              AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                              AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                              AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                              AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                              A248ParticipanteNome ,
                                              A235ParticipanteEmail ,
                                              A234ParticipanteDocumento ,
                                              A1002ParticipanteRepresentanteNome ,
                                              A1003ParticipanteRepresentanteEmail ,
                                              A1004ParticipanteRepresentanteDocumento ,
                                              A244AssinaturaParticipanteDataVisualizacao ,
                                              A245AssinaturaParticipanteDataConclusao ,
                                              AV77Wcassinantesds_1_assinaturaid ,
                                              A238AssinaturaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV78Wcassinantesds_2_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV78Wcassinantesds_2_tfparticipantenome), "%", "");
         lV80Wcassinantesds_4_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV80Wcassinantesds_4_tfparticipanteemail), "%", "");
         lV82Wcassinantesds_6_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV82Wcassinantesds_6_tfparticipantedocumento), "%", "");
         lV84Wcassinantesds_8_tfparticipanterepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV84Wcassinantesds_8_tfparticipanterepresentantenome), "%", "");
         lV86Wcassinantesds_10_tfparticipanterepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV86Wcassinantesds_10_tfparticipanterepresentanteemail), "%", "");
         lV88Wcassinantesds_12_tfparticipanterepresentantedocumento = StringUtil.Concat( StringUtil.RTrim( AV88Wcassinantesds_12_tfparticipanterepresentantedocumento), "%", "");
         /* Using cursor P00AE4 */
         pr_default.execute(2, new Object[] {AV77Wcassinantesds_1_assinaturaid, lV78Wcassinantesds_2_tfparticipantenome, AV79Wcassinantesds_3_tfparticipantenome_sel, lV80Wcassinantesds_4_tfparticipanteemail, AV81Wcassinantesds_5_tfparticipanteemail_sel, lV82Wcassinantesds_6_tfparticipantedocumento, AV83Wcassinantesds_7_tfparticipantedocumento_sel, lV84Wcassinantesds_8_tfparticipanterepresentantenome, AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, lV86Wcassinantesds_10_tfparticipanterepresentanteemail, AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, lV88Wcassinantesds_12_tfparticipanterepresentantedocumento, AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao, AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to, AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao, AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKAE6 = false;
            A238AssinaturaId = P00AE4_A238AssinaturaId[0];
            n238AssinaturaId = P00AE4_n238AssinaturaId[0];
            A233ParticipanteId = P00AE4_A233ParticipanteId[0];
            n233ParticipanteId = P00AE4_n233ParticipanteId[0];
            A245AssinaturaParticipanteDataConclusao = P00AE4_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = P00AE4_n245AssinaturaParticipanteDataConclusao[0];
            A244AssinaturaParticipanteDataVisualizacao = P00AE4_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = P00AE4_n244AssinaturaParticipanteDataVisualizacao[0];
            A353AssinaturaParticipanteStatus = P00AE4_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = P00AE4_n353AssinaturaParticipanteStatus[0];
            A1004ParticipanteRepresentanteDocumento = P00AE4_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = P00AE4_n1004ParticipanteRepresentanteDocumento[0];
            A1003ParticipanteRepresentanteEmail = P00AE4_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = P00AE4_n1003ParticipanteRepresentanteEmail[0];
            A1002ParticipanteRepresentanteNome = P00AE4_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = P00AE4_n1002ParticipanteRepresentanteNome[0];
            A234ParticipanteDocumento = P00AE4_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00AE4_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00AE4_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00AE4_n235ParticipanteEmail[0];
            A248ParticipanteNome = P00AE4_A248ParticipanteNome[0];
            n248ParticipanteNome = P00AE4_n248ParticipanteNome[0];
            A242AssinaturaParticipanteId = P00AE4_A242AssinaturaParticipanteId[0];
            A1004ParticipanteRepresentanteDocumento = P00AE4_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = P00AE4_n1004ParticipanteRepresentanteDocumento[0];
            A1003ParticipanteRepresentanteEmail = P00AE4_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = P00AE4_n1003ParticipanteRepresentanteEmail[0];
            A1002ParticipanteRepresentanteNome = P00AE4_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = P00AE4_n1002ParticipanteRepresentanteNome[0];
            A234ParticipanteDocumento = P00AE4_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00AE4_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00AE4_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00AE4_n235ParticipanteEmail[0];
            A248ParticipanteNome = P00AE4_A248ParticipanteNome[0];
            n248ParticipanteNome = P00AE4_n248ParticipanteNome[0];
            AV56count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( P00AE4_A238AssinaturaId[0] == A238AssinaturaId ) && ( P00AE4_A233ParticipanteId[0] == A233ParticipanteId ) )
            {
               BRKAE6 = false;
               A242AssinaturaParticipanteId = P00AE4_A242AssinaturaParticipanteId[0];
               AV56count = (long)(AV56count+1);
               BRKAE6 = true;
               pr_default.readNext(2);
            }
            AV51Option = (String.IsNullOrEmpty(StringUtil.RTrim( A234ParticipanteDocumento)) ? "<#Empty#>" : A234ParticipanteDocumento);
            AV50InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV51Option, "<#Empty#>") != 0 ) && ( AV50InsertIndex <= AV52Options.Count ) && ( ( StringUtil.StrCmp(((string)AV52Options.Item(AV50InsertIndex)), AV51Option) < 0 ) || ( StringUtil.StrCmp(((string)AV52Options.Item(AV50InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV50InsertIndex = (int)(AV50InsertIndex+1);
            }
            AV52Options.Add(AV51Option, AV50InsertIndex);
            AV55OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV56count), "Z,ZZZ,ZZZ,ZZ9")), AV50InsertIndex);
            if ( AV52Options.Count == AV47SkipItems + 11 )
            {
               AV52Options.RemoveItem(AV52Options.Count);
               AV55OptionIndexes.RemoveItem(AV55OptionIndexes.Count);
            }
            if ( ! BRKAE6 )
            {
               BRKAE6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
         while ( AV47SkipItems > 0 )
         {
            AV52Options.RemoveItem(1);
            AV55OptionIndexes.RemoveItem(1);
            AV47SkipItems = (short)(AV47SkipItems-1);
         }
      }

      protected void S151( )
      {
         /* 'LOADPARTICIPANTEREPRESENTANTENOMEOPTIONS' Routine */
         returnInSub = false;
         AV69TFParticipanteRepresentanteNome = AV46SearchTxt;
         AV70TFParticipanteRepresentanteNome_Sel = "";
         AV77Wcassinantesds_1_assinaturaid = AV68AssinaturaId;
         AV78Wcassinantesds_2_tfparticipantenome = AV18TFParticipanteNome;
         AV79Wcassinantesds_3_tfparticipantenome_sel = AV19TFParticipanteNome_Sel;
         AV80Wcassinantesds_4_tfparticipanteemail = AV20TFParticipanteEmail;
         AV81Wcassinantesds_5_tfparticipanteemail_sel = AV21TFParticipanteEmail_Sel;
         AV82Wcassinantesds_6_tfparticipantedocumento = AV22TFParticipanteDocumento;
         AV83Wcassinantesds_7_tfparticipantedocumento_sel = AV23TFParticipanteDocumento_Sel;
         AV84Wcassinantesds_8_tfparticipanterepresentantenome = AV69TFParticipanteRepresentanteNome;
         AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV70TFParticipanteRepresentanteNome_Sel;
         AV86Wcassinantesds_10_tfparticipanterepresentanteemail = AV71TFParticipanteRepresentanteEmail;
         AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV72TFParticipanteRepresentanteEmail_Sel;
         AV88Wcassinantesds_12_tfparticipanterepresentantedocumento = AV73TFParticipanteRepresentanteDocumento;
         AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV74TFParticipanteRepresentanteDocumento_Sel;
         AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV25TFAssinaturaParticipanteStatus_Sels;
         AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV26TFAssinaturaParticipanteDataVisualizacao;
         AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV27TFAssinaturaParticipanteDataVisualizacao_To;
         AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV28TFAssinaturaParticipanteDataConclusao;
         AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV29TFAssinaturaParticipanteDataConclusao_To;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A353AssinaturaParticipanteStatus ,
                                              AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                              AV79Wcassinantesds_3_tfparticipantenome_sel ,
                                              AV78Wcassinantesds_2_tfparticipantenome ,
                                              AV81Wcassinantesds_5_tfparticipanteemail_sel ,
                                              AV80Wcassinantesds_4_tfparticipanteemail ,
                                              AV83Wcassinantesds_7_tfparticipantedocumento_sel ,
                                              AV82Wcassinantesds_6_tfparticipantedocumento ,
                                              AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                              AV84Wcassinantesds_8_tfparticipanterepresentantenome ,
                                              AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                              AV86Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                              AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                              AV88Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                              AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels.Count ,
                                              AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                              AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                              AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                              AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                              A248ParticipanteNome ,
                                              A235ParticipanteEmail ,
                                              A234ParticipanteDocumento ,
                                              A1002ParticipanteRepresentanteNome ,
                                              A1003ParticipanteRepresentanteEmail ,
                                              A1004ParticipanteRepresentanteDocumento ,
                                              A244AssinaturaParticipanteDataVisualizacao ,
                                              A245AssinaturaParticipanteDataConclusao ,
                                              AV77Wcassinantesds_1_assinaturaid ,
                                              A238AssinaturaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV78Wcassinantesds_2_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV78Wcassinantesds_2_tfparticipantenome), "%", "");
         lV80Wcassinantesds_4_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV80Wcassinantesds_4_tfparticipanteemail), "%", "");
         lV82Wcassinantesds_6_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV82Wcassinantesds_6_tfparticipantedocumento), "%", "");
         lV84Wcassinantesds_8_tfparticipanterepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV84Wcassinantesds_8_tfparticipanterepresentantenome), "%", "");
         lV86Wcassinantesds_10_tfparticipanterepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV86Wcassinantesds_10_tfparticipanterepresentanteemail), "%", "");
         lV88Wcassinantesds_12_tfparticipanterepresentantedocumento = StringUtil.Concat( StringUtil.RTrim( AV88Wcassinantesds_12_tfparticipanterepresentantedocumento), "%", "");
         /* Using cursor P00AE5 */
         pr_default.execute(3, new Object[] {AV77Wcassinantesds_1_assinaturaid, lV78Wcassinantesds_2_tfparticipantenome, AV79Wcassinantesds_3_tfparticipantenome_sel, lV80Wcassinantesds_4_tfparticipanteemail, AV81Wcassinantesds_5_tfparticipanteemail_sel, lV82Wcassinantesds_6_tfparticipantedocumento, AV83Wcassinantesds_7_tfparticipantedocumento_sel, lV84Wcassinantesds_8_tfparticipanterepresentantenome, AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, lV86Wcassinantesds_10_tfparticipanterepresentanteemail, AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, lV88Wcassinantesds_12_tfparticipanterepresentantedocumento, AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao, AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to, AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao, AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKAE8 = false;
            A233ParticipanteId = P00AE5_A233ParticipanteId[0];
            n233ParticipanteId = P00AE5_n233ParticipanteId[0];
            A238AssinaturaId = P00AE5_A238AssinaturaId[0];
            n238AssinaturaId = P00AE5_n238AssinaturaId[0];
            A1002ParticipanteRepresentanteNome = P00AE5_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = P00AE5_n1002ParticipanteRepresentanteNome[0];
            A245AssinaturaParticipanteDataConclusao = P00AE5_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = P00AE5_n245AssinaturaParticipanteDataConclusao[0];
            A244AssinaturaParticipanteDataVisualizacao = P00AE5_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = P00AE5_n244AssinaturaParticipanteDataVisualizacao[0];
            A353AssinaturaParticipanteStatus = P00AE5_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = P00AE5_n353AssinaturaParticipanteStatus[0];
            A1004ParticipanteRepresentanteDocumento = P00AE5_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = P00AE5_n1004ParticipanteRepresentanteDocumento[0];
            A1003ParticipanteRepresentanteEmail = P00AE5_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = P00AE5_n1003ParticipanteRepresentanteEmail[0];
            A234ParticipanteDocumento = P00AE5_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00AE5_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00AE5_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00AE5_n235ParticipanteEmail[0];
            A248ParticipanteNome = P00AE5_A248ParticipanteNome[0];
            n248ParticipanteNome = P00AE5_n248ParticipanteNome[0];
            A242AssinaturaParticipanteId = P00AE5_A242AssinaturaParticipanteId[0];
            A1002ParticipanteRepresentanteNome = P00AE5_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = P00AE5_n1002ParticipanteRepresentanteNome[0];
            A1004ParticipanteRepresentanteDocumento = P00AE5_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = P00AE5_n1004ParticipanteRepresentanteDocumento[0];
            A1003ParticipanteRepresentanteEmail = P00AE5_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = P00AE5_n1003ParticipanteRepresentanteEmail[0];
            A234ParticipanteDocumento = P00AE5_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00AE5_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00AE5_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00AE5_n235ParticipanteEmail[0];
            A248ParticipanteNome = P00AE5_A248ParticipanteNome[0];
            n248ParticipanteNome = P00AE5_n248ParticipanteNome[0];
            AV56count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( P00AE5_A238AssinaturaId[0] == A238AssinaturaId ) && ( StringUtil.StrCmp(P00AE5_A1002ParticipanteRepresentanteNome[0], A1002ParticipanteRepresentanteNome) == 0 ) )
            {
               BRKAE8 = false;
               A233ParticipanteId = P00AE5_A233ParticipanteId[0];
               n233ParticipanteId = P00AE5_n233ParticipanteId[0];
               A242AssinaturaParticipanteId = P00AE5_A242AssinaturaParticipanteId[0];
               AV56count = (long)(AV56count+1);
               BRKAE8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV47SkipItems) )
            {
               AV51Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1002ParticipanteRepresentanteNome)) ? "<#Empty#>" : A1002ParticipanteRepresentanteNome);
               AV52Options.Add(AV51Option, 0);
               AV55OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV56count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV52Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV47SkipItems = (short)(AV47SkipItems-1);
            }
            if ( ! BRKAE8 )
            {
               BRKAE8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADPARTICIPANTEREPRESENTANTEEMAILOPTIONS' Routine */
         returnInSub = false;
         AV71TFParticipanteRepresentanteEmail = AV46SearchTxt;
         AV72TFParticipanteRepresentanteEmail_Sel = "";
         AV77Wcassinantesds_1_assinaturaid = AV68AssinaturaId;
         AV78Wcassinantesds_2_tfparticipantenome = AV18TFParticipanteNome;
         AV79Wcassinantesds_3_tfparticipantenome_sel = AV19TFParticipanteNome_Sel;
         AV80Wcassinantesds_4_tfparticipanteemail = AV20TFParticipanteEmail;
         AV81Wcassinantesds_5_tfparticipanteemail_sel = AV21TFParticipanteEmail_Sel;
         AV82Wcassinantesds_6_tfparticipantedocumento = AV22TFParticipanteDocumento;
         AV83Wcassinantesds_7_tfparticipantedocumento_sel = AV23TFParticipanteDocumento_Sel;
         AV84Wcassinantesds_8_tfparticipanterepresentantenome = AV69TFParticipanteRepresentanteNome;
         AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV70TFParticipanteRepresentanteNome_Sel;
         AV86Wcassinantesds_10_tfparticipanterepresentanteemail = AV71TFParticipanteRepresentanteEmail;
         AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV72TFParticipanteRepresentanteEmail_Sel;
         AV88Wcassinantesds_12_tfparticipanterepresentantedocumento = AV73TFParticipanteRepresentanteDocumento;
         AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV74TFParticipanteRepresentanteDocumento_Sel;
         AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV25TFAssinaturaParticipanteStatus_Sels;
         AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV26TFAssinaturaParticipanteDataVisualizacao;
         AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV27TFAssinaturaParticipanteDataVisualizacao_To;
         AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV28TFAssinaturaParticipanteDataConclusao;
         AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV29TFAssinaturaParticipanteDataConclusao_To;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A353AssinaturaParticipanteStatus ,
                                              AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                              AV79Wcassinantesds_3_tfparticipantenome_sel ,
                                              AV78Wcassinantesds_2_tfparticipantenome ,
                                              AV81Wcassinantesds_5_tfparticipanteemail_sel ,
                                              AV80Wcassinantesds_4_tfparticipanteemail ,
                                              AV83Wcassinantesds_7_tfparticipantedocumento_sel ,
                                              AV82Wcassinantesds_6_tfparticipantedocumento ,
                                              AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                              AV84Wcassinantesds_8_tfparticipanterepresentantenome ,
                                              AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                              AV86Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                              AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                              AV88Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                              AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels.Count ,
                                              AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                              AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                              AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                              AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                              A248ParticipanteNome ,
                                              A235ParticipanteEmail ,
                                              A234ParticipanteDocumento ,
                                              A1002ParticipanteRepresentanteNome ,
                                              A1003ParticipanteRepresentanteEmail ,
                                              A1004ParticipanteRepresentanteDocumento ,
                                              A244AssinaturaParticipanteDataVisualizacao ,
                                              A245AssinaturaParticipanteDataConclusao ,
                                              AV77Wcassinantesds_1_assinaturaid ,
                                              A238AssinaturaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV78Wcassinantesds_2_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV78Wcassinantesds_2_tfparticipantenome), "%", "");
         lV80Wcassinantesds_4_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV80Wcassinantesds_4_tfparticipanteemail), "%", "");
         lV82Wcassinantesds_6_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV82Wcassinantesds_6_tfparticipantedocumento), "%", "");
         lV84Wcassinantesds_8_tfparticipanterepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV84Wcassinantesds_8_tfparticipanterepresentantenome), "%", "");
         lV86Wcassinantesds_10_tfparticipanterepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV86Wcassinantesds_10_tfparticipanterepresentanteemail), "%", "");
         lV88Wcassinantesds_12_tfparticipanterepresentantedocumento = StringUtil.Concat( StringUtil.RTrim( AV88Wcassinantesds_12_tfparticipanterepresentantedocumento), "%", "");
         /* Using cursor P00AE6 */
         pr_default.execute(4, new Object[] {AV77Wcassinantesds_1_assinaturaid, lV78Wcassinantesds_2_tfparticipantenome, AV79Wcassinantesds_3_tfparticipantenome_sel, lV80Wcassinantesds_4_tfparticipanteemail, AV81Wcassinantesds_5_tfparticipanteemail_sel, lV82Wcassinantesds_6_tfparticipantedocumento, AV83Wcassinantesds_7_tfparticipantedocumento_sel, lV84Wcassinantesds_8_tfparticipanterepresentantenome, AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, lV86Wcassinantesds_10_tfparticipanterepresentanteemail, AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, lV88Wcassinantesds_12_tfparticipanterepresentantedocumento, AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao, AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to, AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao, AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKAE10 = false;
            A233ParticipanteId = P00AE6_A233ParticipanteId[0];
            n233ParticipanteId = P00AE6_n233ParticipanteId[0];
            A238AssinaturaId = P00AE6_A238AssinaturaId[0];
            n238AssinaturaId = P00AE6_n238AssinaturaId[0];
            A1003ParticipanteRepresentanteEmail = P00AE6_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = P00AE6_n1003ParticipanteRepresentanteEmail[0];
            A245AssinaturaParticipanteDataConclusao = P00AE6_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = P00AE6_n245AssinaturaParticipanteDataConclusao[0];
            A244AssinaturaParticipanteDataVisualizacao = P00AE6_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = P00AE6_n244AssinaturaParticipanteDataVisualizacao[0];
            A353AssinaturaParticipanteStatus = P00AE6_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = P00AE6_n353AssinaturaParticipanteStatus[0];
            A1004ParticipanteRepresentanteDocumento = P00AE6_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = P00AE6_n1004ParticipanteRepresentanteDocumento[0];
            A1002ParticipanteRepresentanteNome = P00AE6_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = P00AE6_n1002ParticipanteRepresentanteNome[0];
            A234ParticipanteDocumento = P00AE6_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00AE6_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00AE6_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00AE6_n235ParticipanteEmail[0];
            A248ParticipanteNome = P00AE6_A248ParticipanteNome[0];
            n248ParticipanteNome = P00AE6_n248ParticipanteNome[0];
            A242AssinaturaParticipanteId = P00AE6_A242AssinaturaParticipanteId[0];
            A1003ParticipanteRepresentanteEmail = P00AE6_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = P00AE6_n1003ParticipanteRepresentanteEmail[0];
            A1004ParticipanteRepresentanteDocumento = P00AE6_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = P00AE6_n1004ParticipanteRepresentanteDocumento[0];
            A1002ParticipanteRepresentanteNome = P00AE6_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = P00AE6_n1002ParticipanteRepresentanteNome[0];
            A234ParticipanteDocumento = P00AE6_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00AE6_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00AE6_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00AE6_n235ParticipanteEmail[0];
            A248ParticipanteNome = P00AE6_A248ParticipanteNome[0];
            n248ParticipanteNome = P00AE6_n248ParticipanteNome[0];
            AV56count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( P00AE6_A238AssinaturaId[0] == A238AssinaturaId ) && ( StringUtil.StrCmp(P00AE6_A1003ParticipanteRepresentanteEmail[0], A1003ParticipanteRepresentanteEmail) == 0 ) )
            {
               BRKAE10 = false;
               A233ParticipanteId = P00AE6_A233ParticipanteId[0];
               n233ParticipanteId = P00AE6_n233ParticipanteId[0];
               A242AssinaturaParticipanteId = P00AE6_A242AssinaturaParticipanteId[0];
               AV56count = (long)(AV56count+1);
               BRKAE10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV47SkipItems) )
            {
               AV51Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1003ParticipanteRepresentanteEmail)) ? "<#Empty#>" : A1003ParticipanteRepresentanteEmail);
               AV52Options.Add(AV51Option, 0);
               AV55OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV56count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV52Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV47SkipItems = (short)(AV47SkipItems-1);
            }
            if ( ! BRKAE10 )
            {
               BRKAE10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADPARTICIPANTEREPRESENTANTEDOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV73TFParticipanteRepresentanteDocumento = AV46SearchTxt;
         AV74TFParticipanteRepresentanteDocumento_Sel = "";
         AV77Wcassinantesds_1_assinaturaid = AV68AssinaturaId;
         AV78Wcassinantesds_2_tfparticipantenome = AV18TFParticipanteNome;
         AV79Wcassinantesds_3_tfparticipantenome_sel = AV19TFParticipanteNome_Sel;
         AV80Wcassinantesds_4_tfparticipanteemail = AV20TFParticipanteEmail;
         AV81Wcassinantesds_5_tfparticipanteemail_sel = AV21TFParticipanteEmail_Sel;
         AV82Wcassinantesds_6_tfparticipantedocumento = AV22TFParticipanteDocumento;
         AV83Wcassinantesds_7_tfparticipantedocumento_sel = AV23TFParticipanteDocumento_Sel;
         AV84Wcassinantesds_8_tfparticipanterepresentantenome = AV69TFParticipanteRepresentanteNome;
         AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel = AV70TFParticipanteRepresentanteNome_Sel;
         AV86Wcassinantesds_10_tfparticipanterepresentanteemail = AV71TFParticipanteRepresentanteEmail;
         AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel = AV72TFParticipanteRepresentanteEmail_Sel;
         AV88Wcassinantesds_12_tfparticipanterepresentantedocumento = AV73TFParticipanteRepresentanteDocumento;
         AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = AV74TFParticipanteRepresentanteDocumento_Sel;
         AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels = AV25TFAssinaturaParticipanteStatus_Sels;
         AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = AV26TFAssinaturaParticipanteDataVisualizacao;
         AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = AV27TFAssinaturaParticipanteDataVisualizacao_To;
         AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao = AV28TFAssinaturaParticipanteDataConclusao;
         AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = AV29TFAssinaturaParticipanteDataConclusao_To;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A353AssinaturaParticipanteStatus ,
                                              AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                              AV79Wcassinantesds_3_tfparticipantenome_sel ,
                                              AV78Wcassinantesds_2_tfparticipantenome ,
                                              AV81Wcassinantesds_5_tfparticipanteemail_sel ,
                                              AV80Wcassinantesds_4_tfparticipanteemail ,
                                              AV83Wcassinantesds_7_tfparticipantedocumento_sel ,
                                              AV82Wcassinantesds_6_tfparticipantedocumento ,
                                              AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                              AV84Wcassinantesds_8_tfparticipanterepresentantenome ,
                                              AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                              AV86Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                              AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                              AV88Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                              AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels.Count ,
                                              AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                              AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                              AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                              AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                              A248ParticipanteNome ,
                                              A235ParticipanteEmail ,
                                              A234ParticipanteDocumento ,
                                              A1002ParticipanteRepresentanteNome ,
                                              A1003ParticipanteRepresentanteEmail ,
                                              A1004ParticipanteRepresentanteDocumento ,
                                              A244AssinaturaParticipanteDataVisualizacao ,
                                              A245AssinaturaParticipanteDataConclusao ,
                                              AV77Wcassinantesds_1_assinaturaid ,
                                              A238AssinaturaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV78Wcassinantesds_2_tfparticipantenome = StringUtil.Concat( StringUtil.RTrim( AV78Wcassinantesds_2_tfparticipantenome), "%", "");
         lV80Wcassinantesds_4_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV80Wcassinantesds_4_tfparticipanteemail), "%", "");
         lV82Wcassinantesds_6_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV82Wcassinantesds_6_tfparticipantedocumento), "%", "");
         lV84Wcassinantesds_8_tfparticipanterepresentantenome = StringUtil.Concat( StringUtil.RTrim( AV84Wcassinantesds_8_tfparticipanterepresentantenome), "%", "");
         lV86Wcassinantesds_10_tfparticipanterepresentanteemail = StringUtil.Concat( StringUtil.RTrim( AV86Wcassinantesds_10_tfparticipanterepresentanteemail), "%", "");
         lV88Wcassinantesds_12_tfparticipanterepresentantedocumento = StringUtil.Concat( StringUtil.RTrim( AV88Wcassinantesds_12_tfparticipanterepresentantedocumento), "%", "");
         /* Using cursor P00AE7 */
         pr_default.execute(5, new Object[] {AV77Wcassinantesds_1_assinaturaid, lV78Wcassinantesds_2_tfparticipantenome, AV79Wcassinantesds_3_tfparticipantenome_sel, lV80Wcassinantesds_4_tfparticipanteemail, AV81Wcassinantesds_5_tfparticipanteemail_sel, lV82Wcassinantesds_6_tfparticipantedocumento, AV83Wcassinantesds_7_tfparticipantedocumento_sel, lV84Wcassinantesds_8_tfparticipanterepresentantenome, AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, lV86Wcassinantesds_10_tfparticipanterepresentanteemail, AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, lV88Wcassinantesds_12_tfparticipanterepresentantedocumento, AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao, AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to, AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao, AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRKAE12 = false;
            A233ParticipanteId = P00AE7_A233ParticipanteId[0];
            n233ParticipanteId = P00AE7_n233ParticipanteId[0];
            A238AssinaturaId = P00AE7_A238AssinaturaId[0];
            n238AssinaturaId = P00AE7_n238AssinaturaId[0];
            A1004ParticipanteRepresentanteDocumento = P00AE7_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = P00AE7_n1004ParticipanteRepresentanteDocumento[0];
            A245AssinaturaParticipanteDataConclusao = P00AE7_A245AssinaturaParticipanteDataConclusao[0];
            n245AssinaturaParticipanteDataConclusao = P00AE7_n245AssinaturaParticipanteDataConclusao[0];
            A244AssinaturaParticipanteDataVisualizacao = P00AE7_A244AssinaturaParticipanteDataVisualizacao[0];
            n244AssinaturaParticipanteDataVisualizacao = P00AE7_n244AssinaturaParticipanteDataVisualizacao[0];
            A353AssinaturaParticipanteStatus = P00AE7_A353AssinaturaParticipanteStatus[0];
            n353AssinaturaParticipanteStatus = P00AE7_n353AssinaturaParticipanteStatus[0];
            A1003ParticipanteRepresentanteEmail = P00AE7_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = P00AE7_n1003ParticipanteRepresentanteEmail[0];
            A1002ParticipanteRepresentanteNome = P00AE7_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = P00AE7_n1002ParticipanteRepresentanteNome[0];
            A234ParticipanteDocumento = P00AE7_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00AE7_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00AE7_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00AE7_n235ParticipanteEmail[0];
            A248ParticipanteNome = P00AE7_A248ParticipanteNome[0];
            n248ParticipanteNome = P00AE7_n248ParticipanteNome[0];
            A242AssinaturaParticipanteId = P00AE7_A242AssinaturaParticipanteId[0];
            A1004ParticipanteRepresentanteDocumento = P00AE7_A1004ParticipanteRepresentanteDocumento[0];
            n1004ParticipanteRepresentanteDocumento = P00AE7_n1004ParticipanteRepresentanteDocumento[0];
            A1003ParticipanteRepresentanteEmail = P00AE7_A1003ParticipanteRepresentanteEmail[0];
            n1003ParticipanteRepresentanteEmail = P00AE7_n1003ParticipanteRepresentanteEmail[0];
            A1002ParticipanteRepresentanteNome = P00AE7_A1002ParticipanteRepresentanteNome[0];
            n1002ParticipanteRepresentanteNome = P00AE7_n1002ParticipanteRepresentanteNome[0];
            A234ParticipanteDocumento = P00AE7_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P00AE7_n234ParticipanteDocumento[0];
            A235ParticipanteEmail = P00AE7_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P00AE7_n235ParticipanteEmail[0];
            A248ParticipanteNome = P00AE7_A248ParticipanteNome[0];
            n248ParticipanteNome = P00AE7_n248ParticipanteNome[0];
            AV56count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( P00AE7_A238AssinaturaId[0] == A238AssinaturaId ) && ( StringUtil.StrCmp(P00AE7_A1004ParticipanteRepresentanteDocumento[0], A1004ParticipanteRepresentanteDocumento) == 0 ) )
            {
               BRKAE12 = false;
               A233ParticipanteId = P00AE7_A233ParticipanteId[0];
               n233ParticipanteId = P00AE7_n233ParticipanteId[0];
               A242AssinaturaParticipanteId = P00AE7_A242AssinaturaParticipanteId[0];
               AV56count = (long)(AV56count+1);
               BRKAE12 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV47SkipItems) )
            {
               AV51Option = (String.IsNullOrEmpty(StringUtil.RTrim( A1004ParticipanteRepresentanteDocumento)) ? "<#Empty#>" : A1004ParticipanteRepresentanteDocumento);
               AV52Options.Add(AV51Option, 0);
               AV55OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV56count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV52Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV47SkipItems = (short)(AV47SkipItems-1);
            }
            if ( ! BRKAE12 )
            {
               BRKAE12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
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
         AV65OptionsJson = "";
         AV66OptionsDescJson = "";
         AV67OptionIndexesJson = "";
         AV52Options = new GxSimpleCollection<string>();
         AV54OptionsDesc = new GxSimpleCollection<string>();
         AV55OptionIndexes = new GxSimpleCollection<string>();
         AV46SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV57Session = context.GetSession();
         AV59GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV60GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV18TFParticipanteNome = "";
         AV19TFParticipanteNome_Sel = "";
         AV20TFParticipanteEmail = "";
         AV21TFParticipanteEmail_Sel = "";
         AV22TFParticipanteDocumento = "";
         AV23TFParticipanteDocumento_Sel = "";
         AV69TFParticipanteRepresentanteNome = "";
         AV70TFParticipanteRepresentanteNome_Sel = "";
         AV71TFParticipanteRepresentanteEmail = "";
         AV72TFParticipanteRepresentanteEmail_Sel = "";
         AV73TFParticipanteRepresentanteDocumento = "";
         AV74TFParticipanteRepresentanteDocumento_Sel = "";
         AV24TFAssinaturaParticipanteStatus_SelsJson = "";
         AV25TFAssinaturaParticipanteStatus_Sels = new GxSimpleCollection<string>();
         AV26TFAssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         AV27TFAssinaturaParticipanteDataVisualizacao_To = (DateTime)(DateTime.MinValue);
         AV28TFAssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         AV29TFAssinaturaParticipanteDataConclusao_To = (DateTime)(DateTime.MinValue);
         AV78Wcassinantesds_2_tfparticipantenome = "";
         AV79Wcassinantesds_3_tfparticipantenome_sel = "";
         AV80Wcassinantesds_4_tfparticipanteemail = "";
         AV81Wcassinantesds_5_tfparticipanteemail_sel = "";
         AV82Wcassinantesds_6_tfparticipantedocumento = "";
         AV83Wcassinantesds_7_tfparticipantedocumento_sel = "";
         AV84Wcassinantesds_8_tfparticipanterepresentantenome = "";
         AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel = "";
         AV86Wcassinantesds_10_tfparticipanterepresentanteemail = "";
         AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel = "";
         AV88Wcassinantesds_12_tfparticipanterepresentantedocumento = "";
         AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel = "";
         AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels = new GxSimpleCollection<string>();
         AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao = (DateTime)(DateTime.MinValue);
         AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to = (DateTime)(DateTime.MinValue);
         AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao = (DateTime)(DateTime.MinValue);
         AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to = (DateTime)(DateTime.MinValue);
         lV78Wcassinantesds_2_tfparticipantenome = "";
         lV80Wcassinantesds_4_tfparticipanteemail = "";
         lV82Wcassinantesds_6_tfparticipantedocumento = "";
         lV84Wcassinantesds_8_tfparticipanterepresentantenome = "";
         lV86Wcassinantesds_10_tfparticipanterepresentanteemail = "";
         lV88Wcassinantesds_12_tfparticipanterepresentantedocumento = "";
         A353AssinaturaParticipanteStatus = "";
         A248ParticipanteNome = "";
         A235ParticipanteEmail = "";
         A234ParticipanteDocumento = "";
         A1002ParticipanteRepresentanteNome = "";
         A1003ParticipanteRepresentanteEmail = "";
         A1004ParticipanteRepresentanteDocumento = "";
         A244AssinaturaParticipanteDataVisualizacao = (DateTime)(DateTime.MinValue);
         A245AssinaturaParticipanteDataConclusao = (DateTime)(DateTime.MinValue);
         P00AE2_A233ParticipanteId = new int[1] ;
         P00AE2_n233ParticipanteId = new bool[] {false} ;
         P00AE2_A238AssinaturaId = new long[1] ;
         P00AE2_n238AssinaturaId = new bool[] {false} ;
         P00AE2_A248ParticipanteNome = new string[] {""} ;
         P00AE2_n248ParticipanteNome = new bool[] {false} ;
         P00AE2_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         P00AE2_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         P00AE2_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         P00AE2_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         P00AE2_A353AssinaturaParticipanteStatus = new string[] {""} ;
         P00AE2_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         P00AE2_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         P00AE2_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         P00AE2_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         P00AE2_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         P00AE2_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         P00AE2_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         P00AE2_A234ParticipanteDocumento = new string[] {""} ;
         P00AE2_n234ParticipanteDocumento = new bool[] {false} ;
         P00AE2_A235ParticipanteEmail = new string[] {""} ;
         P00AE2_n235ParticipanteEmail = new bool[] {false} ;
         P00AE2_A242AssinaturaParticipanteId = new int[1] ;
         AV51Option = "";
         P00AE3_A233ParticipanteId = new int[1] ;
         P00AE3_n233ParticipanteId = new bool[] {false} ;
         P00AE3_A238AssinaturaId = new long[1] ;
         P00AE3_n238AssinaturaId = new bool[] {false} ;
         P00AE3_A235ParticipanteEmail = new string[] {""} ;
         P00AE3_n235ParticipanteEmail = new bool[] {false} ;
         P00AE3_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         P00AE3_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         P00AE3_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         P00AE3_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         P00AE3_A353AssinaturaParticipanteStatus = new string[] {""} ;
         P00AE3_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         P00AE3_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         P00AE3_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         P00AE3_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         P00AE3_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         P00AE3_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         P00AE3_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         P00AE3_A234ParticipanteDocumento = new string[] {""} ;
         P00AE3_n234ParticipanteDocumento = new bool[] {false} ;
         P00AE3_A248ParticipanteNome = new string[] {""} ;
         P00AE3_n248ParticipanteNome = new bool[] {false} ;
         P00AE3_A242AssinaturaParticipanteId = new int[1] ;
         P00AE4_A238AssinaturaId = new long[1] ;
         P00AE4_n238AssinaturaId = new bool[] {false} ;
         P00AE4_A233ParticipanteId = new int[1] ;
         P00AE4_n233ParticipanteId = new bool[] {false} ;
         P00AE4_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         P00AE4_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         P00AE4_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         P00AE4_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         P00AE4_A353AssinaturaParticipanteStatus = new string[] {""} ;
         P00AE4_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         P00AE4_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         P00AE4_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         P00AE4_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         P00AE4_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         P00AE4_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         P00AE4_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         P00AE4_A234ParticipanteDocumento = new string[] {""} ;
         P00AE4_n234ParticipanteDocumento = new bool[] {false} ;
         P00AE4_A235ParticipanteEmail = new string[] {""} ;
         P00AE4_n235ParticipanteEmail = new bool[] {false} ;
         P00AE4_A248ParticipanteNome = new string[] {""} ;
         P00AE4_n248ParticipanteNome = new bool[] {false} ;
         P00AE4_A242AssinaturaParticipanteId = new int[1] ;
         P00AE5_A233ParticipanteId = new int[1] ;
         P00AE5_n233ParticipanteId = new bool[] {false} ;
         P00AE5_A238AssinaturaId = new long[1] ;
         P00AE5_n238AssinaturaId = new bool[] {false} ;
         P00AE5_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         P00AE5_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         P00AE5_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         P00AE5_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         P00AE5_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         P00AE5_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         P00AE5_A353AssinaturaParticipanteStatus = new string[] {""} ;
         P00AE5_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         P00AE5_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         P00AE5_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         P00AE5_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         P00AE5_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         P00AE5_A234ParticipanteDocumento = new string[] {""} ;
         P00AE5_n234ParticipanteDocumento = new bool[] {false} ;
         P00AE5_A235ParticipanteEmail = new string[] {""} ;
         P00AE5_n235ParticipanteEmail = new bool[] {false} ;
         P00AE5_A248ParticipanteNome = new string[] {""} ;
         P00AE5_n248ParticipanteNome = new bool[] {false} ;
         P00AE5_A242AssinaturaParticipanteId = new int[1] ;
         P00AE6_A233ParticipanteId = new int[1] ;
         P00AE6_n233ParticipanteId = new bool[] {false} ;
         P00AE6_A238AssinaturaId = new long[1] ;
         P00AE6_n238AssinaturaId = new bool[] {false} ;
         P00AE6_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         P00AE6_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         P00AE6_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         P00AE6_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         P00AE6_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         P00AE6_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         P00AE6_A353AssinaturaParticipanteStatus = new string[] {""} ;
         P00AE6_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         P00AE6_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         P00AE6_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         P00AE6_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         P00AE6_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         P00AE6_A234ParticipanteDocumento = new string[] {""} ;
         P00AE6_n234ParticipanteDocumento = new bool[] {false} ;
         P00AE6_A235ParticipanteEmail = new string[] {""} ;
         P00AE6_n235ParticipanteEmail = new bool[] {false} ;
         P00AE6_A248ParticipanteNome = new string[] {""} ;
         P00AE6_n248ParticipanteNome = new bool[] {false} ;
         P00AE6_A242AssinaturaParticipanteId = new int[1] ;
         P00AE7_A233ParticipanteId = new int[1] ;
         P00AE7_n233ParticipanteId = new bool[] {false} ;
         P00AE7_A238AssinaturaId = new long[1] ;
         P00AE7_n238AssinaturaId = new bool[] {false} ;
         P00AE7_A1004ParticipanteRepresentanteDocumento = new string[] {""} ;
         P00AE7_n1004ParticipanteRepresentanteDocumento = new bool[] {false} ;
         P00AE7_A245AssinaturaParticipanteDataConclusao = new DateTime[] {DateTime.MinValue} ;
         P00AE7_n245AssinaturaParticipanteDataConclusao = new bool[] {false} ;
         P00AE7_A244AssinaturaParticipanteDataVisualizacao = new DateTime[] {DateTime.MinValue} ;
         P00AE7_n244AssinaturaParticipanteDataVisualizacao = new bool[] {false} ;
         P00AE7_A353AssinaturaParticipanteStatus = new string[] {""} ;
         P00AE7_n353AssinaturaParticipanteStatus = new bool[] {false} ;
         P00AE7_A1003ParticipanteRepresentanteEmail = new string[] {""} ;
         P00AE7_n1003ParticipanteRepresentanteEmail = new bool[] {false} ;
         P00AE7_A1002ParticipanteRepresentanteNome = new string[] {""} ;
         P00AE7_n1002ParticipanteRepresentanteNome = new bool[] {false} ;
         P00AE7_A234ParticipanteDocumento = new string[] {""} ;
         P00AE7_n234ParticipanteDocumento = new bool[] {false} ;
         P00AE7_A235ParticipanteEmail = new string[] {""} ;
         P00AE7_n235ParticipanteEmail = new bool[] {false} ;
         P00AE7_A248ParticipanteNome = new string[] {""} ;
         P00AE7_n248ParticipanteNome = new bool[] {false} ;
         P00AE7_A242AssinaturaParticipanteId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wcassinantesgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AE2_A233ParticipanteId, P00AE2_n233ParticipanteId, P00AE2_A238AssinaturaId, P00AE2_n238AssinaturaId, P00AE2_A248ParticipanteNome, P00AE2_n248ParticipanteNome, P00AE2_A245AssinaturaParticipanteDataConclusao, P00AE2_n245AssinaturaParticipanteDataConclusao, P00AE2_A244AssinaturaParticipanteDataVisualizacao, P00AE2_n244AssinaturaParticipanteDataVisualizacao,
               P00AE2_A353AssinaturaParticipanteStatus, P00AE2_n353AssinaturaParticipanteStatus, P00AE2_A1004ParticipanteRepresentanteDocumento, P00AE2_n1004ParticipanteRepresentanteDocumento, P00AE2_A1003ParticipanteRepresentanteEmail, P00AE2_n1003ParticipanteRepresentanteEmail, P00AE2_A1002ParticipanteRepresentanteNome, P00AE2_n1002ParticipanteRepresentanteNome, P00AE2_A234ParticipanteDocumento, P00AE2_n234ParticipanteDocumento,
               P00AE2_A235ParticipanteEmail, P00AE2_n235ParticipanteEmail, P00AE2_A242AssinaturaParticipanteId
               }
               , new Object[] {
               P00AE3_A233ParticipanteId, P00AE3_n233ParticipanteId, P00AE3_A238AssinaturaId, P00AE3_n238AssinaturaId, P00AE3_A235ParticipanteEmail, P00AE3_n235ParticipanteEmail, P00AE3_A245AssinaturaParticipanteDataConclusao, P00AE3_n245AssinaturaParticipanteDataConclusao, P00AE3_A244AssinaturaParticipanteDataVisualizacao, P00AE3_n244AssinaturaParticipanteDataVisualizacao,
               P00AE3_A353AssinaturaParticipanteStatus, P00AE3_n353AssinaturaParticipanteStatus, P00AE3_A1004ParticipanteRepresentanteDocumento, P00AE3_n1004ParticipanteRepresentanteDocumento, P00AE3_A1003ParticipanteRepresentanteEmail, P00AE3_n1003ParticipanteRepresentanteEmail, P00AE3_A1002ParticipanteRepresentanteNome, P00AE3_n1002ParticipanteRepresentanteNome, P00AE3_A234ParticipanteDocumento, P00AE3_n234ParticipanteDocumento,
               P00AE3_A248ParticipanteNome, P00AE3_n248ParticipanteNome, P00AE3_A242AssinaturaParticipanteId
               }
               , new Object[] {
               P00AE4_A238AssinaturaId, P00AE4_n238AssinaturaId, P00AE4_A233ParticipanteId, P00AE4_n233ParticipanteId, P00AE4_A245AssinaturaParticipanteDataConclusao, P00AE4_n245AssinaturaParticipanteDataConclusao, P00AE4_A244AssinaturaParticipanteDataVisualizacao, P00AE4_n244AssinaturaParticipanteDataVisualizacao, P00AE4_A353AssinaturaParticipanteStatus, P00AE4_n353AssinaturaParticipanteStatus,
               P00AE4_A1004ParticipanteRepresentanteDocumento, P00AE4_n1004ParticipanteRepresentanteDocumento, P00AE4_A1003ParticipanteRepresentanteEmail, P00AE4_n1003ParticipanteRepresentanteEmail, P00AE4_A1002ParticipanteRepresentanteNome, P00AE4_n1002ParticipanteRepresentanteNome, P00AE4_A234ParticipanteDocumento, P00AE4_n234ParticipanteDocumento, P00AE4_A235ParticipanteEmail, P00AE4_n235ParticipanteEmail,
               P00AE4_A248ParticipanteNome, P00AE4_n248ParticipanteNome, P00AE4_A242AssinaturaParticipanteId
               }
               , new Object[] {
               P00AE5_A233ParticipanteId, P00AE5_n233ParticipanteId, P00AE5_A238AssinaturaId, P00AE5_n238AssinaturaId, P00AE5_A1002ParticipanteRepresentanteNome, P00AE5_n1002ParticipanteRepresentanteNome, P00AE5_A245AssinaturaParticipanteDataConclusao, P00AE5_n245AssinaturaParticipanteDataConclusao, P00AE5_A244AssinaturaParticipanteDataVisualizacao, P00AE5_n244AssinaturaParticipanteDataVisualizacao,
               P00AE5_A353AssinaturaParticipanteStatus, P00AE5_n353AssinaturaParticipanteStatus, P00AE5_A1004ParticipanteRepresentanteDocumento, P00AE5_n1004ParticipanteRepresentanteDocumento, P00AE5_A1003ParticipanteRepresentanteEmail, P00AE5_n1003ParticipanteRepresentanteEmail, P00AE5_A234ParticipanteDocumento, P00AE5_n234ParticipanteDocumento, P00AE5_A235ParticipanteEmail, P00AE5_n235ParticipanteEmail,
               P00AE5_A248ParticipanteNome, P00AE5_n248ParticipanteNome, P00AE5_A242AssinaturaParticipanteId
               }
               , new Object[] {
               P00AE6_A233ParticipanteId, P00AE6_n233ParticipanteId, P00AE6_A238AssinaturaId, P00AE6_n238AssinaturaId, P00AE6_A1003ParticipanteRepresentanteEmail, P00AE6_n1003ParticipanteRepresentanteEmail, P00AE6_A245AssinaturaParticipanteDataConclusao, P00AE6_n245AssinaturaParticipanteDataConclusao, P00AE6_A244AssinaturaParticipanteDataVisualizacao, P00AE6_n244AssinaturaParticipanteDataVisualizacao,
               P00AE6_A353AssinaturaParticipanteStatus, P00AE6_n353AssinaturaParticipanteStatus, P00AE6_A1004ParticipanteRepresentanteDocumento, P00AE6_n1004ParticipanteRepresentanteDocumento, P00AE6_A1002ParticipanteRepresentanteNome, P00AE6_n1002ParticipanteRepresentanteNome, P00AE6_A234ParticipanteDocumento, P00AE6_n234ParticipanteDocumento, P00AE6_A235ParticipanteEmail, P00AE6_n235ParticipanteEmail,
               P00AE6_A248ParticipanteNome, P00AE6_n248ParticipanteNome, P00AE6_A242AssinaturaParticipanteId
               }
               , new Object[] {
               P00AE7_A233ParticipanteId, P00AE7_n233ParticipanteId, P00AE7_A238AssinaturaId, P00AE7_n238AssinaturaId, P00AE7_A1004ParticipanteRepresentanteDocumento, P00AE7_n1004ParticipanteRepresentanteDocumento, P00AE7_A245AssinaturaParticipanteDataConclusao, P00AE7_n245AssinaturaParticipanteDataConclusao, P00AE7_A244AssinaturaParticipanteDataVisualizacao, P00AE7_n244AssinaturaParticipanteDataVisualizacao,
               P00AE7_A353AssinaturaParticipanteStatus, P00AE7_n353AssinaturaParticipanteStatus, P00AE7_A1003ParticipanteRepresentanteEmail, P00AE7_n1003ParticipanteRepresentanteEmail, P00AE7_A1002ParticipanteRepresentanteNome, P00AE7_n1002ParticipanteRepresentanteNome, P00AE7_A234ParticipanteDocumento, P00AE7_n234ParticipanteDocumento, P00AE7_A235ParticipanteEmail, P00AE7_n235ParticipanteEmail,
               P00AE7_A248ParticipanteNome, P00AE7_n248ParticipanteNome, P00AE7_A242AssinaturaParticipanteId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV49MaxItems ;
      private short AV48PageIndex ;
      private short AV47SkipItems ;
      private int AV75GXV1 ;
      private int AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count ;
      private int A233ParticipanteId ;
      private int A242AssinaturaParticipanteId ;
      private int AV50InsertIndex ;
      private long AV68AssinaturaId ;
      private long AV77Wcassinantesds_1_assinaturaid ;
      private long A238AssinaturaId ;
      private long AV56count ;
      private DateTime AV26TFAssinaturaParticipanteDataVisualizacao ;
      private DateTime AV27TFAssinaturaParticipanteDataVisualizacao_To ;
      private DateTime AV28TFAssinaturaParticipanteDataConclusao ;
      private DateTime AV29TFAssinaturaParticipanteDataConclusao_To ;
      private DateTime AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ;
      private DateTime AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ;
      private DateTime AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao ;
      private DateTime AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ;
      private DateTime A244AssinaturaParticipanteDataVisualizacao ;
      private DateTime A245AssinaturaParticipanteDataConclusao ;
      private bool returnInSub ;
      private bool BRKAE2 ;
      private bool n233ParticipanteId ;
      private bool n238AssinaturaId ;
      private bool n248ParticipanteNome ;
      private bool n245AssinaturaParticipanteDataConclusao ;
      private bool n244AssinaturaParticipanteDataVisualizacao ;
      private bool n353AssinaturaParticipanteStatus ;
      private bool n1004ParticipanteRepresentanteDocumento ;
      private bool n1003ParticipanteRepresentanteEmail ;
      private bool n1002ParticipanteRepresentanteNome ;
      private bool n234ParticipanteDocumento ;
      private bool n235ParticipanteEmail ;
      private bool BRKAE4 ;
      private bool BRKAE6 ;
      private bool BRKAE8 ;
      private bool BRKAE10 ;
      private bool BRKAE12 ;
      private string AV65OptionsJson ;
      private string AV66OptionsDescJson ;
      private string AV67OptionIndexesJson ;
      private string AV24TFAssinaturaParticipanteStatus_SelsJson ;
      private string AV62DDOName ;
      private string AV63SearchTxtParms ;
      private string AV64SearchTxtTo ;
      private string AV46SearchTxt ;
      private string AV18TFParticipanteNome ;
      private string AV19TFParticipanteNome_Sel ;
      private string AV20TFParticipanteEmail ;
      private string AV21TFParticipanteEmail_Sel ;
      private string AV22TFParticipanteDocumento ;
      private string AV23TFParticipanteDocumento_Sel ;
      private string AV69TFParticipanteRepresentanteNome ;
      private string AV70TFParticipanteRepresentanteNome_Sel ;
      private string AV71TFParticipanteRepresentanteEmail ;
      private string AV72TFParticipanteRepresentanteEmail_Sel ;
      private string AV73TFParticipanteRepresentanteDocumento ;
      private string AV74TFParticipanteRepresentanteDocumento_Sel ;
      private string AV78Wcassinantesds_2_tfparticipantenome ;
      private string AV79Wcassinantesds_3_tfparticipantenome_sel ;
      private string AV80Wcassinantesds_4_tfparticipanteemail ;
      private string AV81Wcassinantesds_5_tfparticipanteemail_sel ;
      private string AV82Wcassinantesds_6_tfparticipantedocumento ;
      private string AV83Wcassinantesds_7_tfparticipantedocumento_sel ;
      private string AV84Wcassinantesds_8_tfparticipanterepresentantenome ;
      private string AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel ;
      private string AV86Wcassinantesds_10_tfparticipanterepresentanteemail ;
      private string AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel ;
      private string AV88Wcassinantesds_12_tfparticipanterepresentantedocumento ;
      private string AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ;
      private string lV78Wcassinantesds_2_tfparticipantenome ;
      private string lV80Wcassinantesds_4_tfparticipanteemail ;
      private string lV82Wcassinantesds_6_tfparticipantedocumento ;
      private string lV84Wcassinantesds_8_tfparticipanterepresentantenome ;
      private string lV86Wcassinantesds_10_tfparticipanterepresentanteemail ;
      private string lV88Wcassinantesds_12_tfparticipanterepresentantedocumento ;
      private string A353AssinaturaParticipanteStatus ;
      private string A248ParticipanteNome ;
      private string A235ParticipanteEmail ;
      private string A234ParticipanteDocumento ;
      private string A1002ParticipanteRepresentanteNome ;
      private string A1003ParticipanteRepresentanteEmail ;
      private string A1004ParticipanteRepresentanteDocumento ;
      private string AV51Option ;
      private IGxSession AV57Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV52Options ;
      private GxSimpleCollection<string> AV54OptionsDesc ;
      private GxSimpleCollection<string> AV55OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV59GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV60GridStateFilterValue ;
      private GxSimpleCollection<string> AV25TFAssinaturaParticipanteStatus_Sels ;
      private GxSimpleCollection<string> AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels ;
      private IDataStoreProvider pr_default ;
      private int[] P00AE2_A233ParticipanteId ;
      private bool[] P00AE2_n233ParticipanteId ;
      private long[] P00AE2_A238AssinaturaId ;
      private bool[] P00AE2_n238AssinaturaId ;
      private string[] P00AE2_A248ParticipanteNome ;
      private bool[] P00AE2_n248ParticipanteNome ;
      private DateTime[] P00AE2_A245AssinaturaParticipanteDataConclusao ;
      private bool[] P00AE2_n245AssinaturaParticipanteDataConclusao ;
      private DateTime[] P00AE2_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] P00AE2_n244AssinaturaParticipanteDataVisualizacao ;
      private string[] P00AE2_A353AssinaturaParticipanteStatus ;
      private bool[] P00AE2_n353AssinaturaParticipanteStatus ;
      private string[] P00AE2_A1004ParticipanteRepresentanteDocumento ;
      private bool[] P00AE2_n1004ParticipanteRepresentanteDocumento ;
      private string[] P00AE2_A1003ParticipanteRepresentanteEmail ;
      private bool[] P00AE2_n1003ParticipanteRepresentanteEmail ;
      private string[] P00AE2_A1002ParticipanteRepresentanteNome ;
      private bool[] P00AE2_n1002ParticipanteRepresentanteNome ;
      private string[] P00AE2_A234ParticipanteDocumento ;
      private bool[] P00AE2_n234ParticipanteDocumento ;
      private string[] P00AE2_A235ParticipanteEmail ;
      private bool[] P00AE2_n235ParticipanteEmail ;
      private int[] P00AE2_A242AssinaturaParticipanteId ;
      private int[] P00AE3_A233ParticipanteId ;
      private bool[] P00AE3_n233ParticipanteId ;
      private long[] P00AE3_A238AssinaturaId ;
      private bool[] P00AE3_n238AssinaturaId ;
      private string[] P00AE3_A235ParticipanteEmail ;
      private bool[] P00AE3_n235ParticipanteEmail ;
      private DateTime[] P00AE3_A245AssinaturaParticipanteDataConclusao ;
      private bool[] P00AE3_n245AssinaturaParticipanteDataConclusao ;
      private DateTime[] P00AE3_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] P00AE3_n244AssinaturaParticipanteDataVisualizacao ;
      private string[] P00AE3_A353AssinaturaParticipanteStatus ;
      private bool[] P00AE3_n353AssinaturaParticipanteStatus ;
      private string[] P00AE3_A1004ParticipanteRepresentanteDocumento ;
      private bool[] P00AE3_n1004ParticipanteRepresentanteDocumento ;
      private string[] P00AE3_A1003ParticipanteRepresentanteEmail ;
      private bool[] P00AE3_n1003ParticipanteRepresentanteEmail ;
      private string[] P00AE3_A1002ParticipanteRepresentanteNome ;
      private bool[] P00AE3_n1002ParticipanteRepresentanteNome ;
      private string[] P00AE3_A234ParticipanteDocumento ;
      private bool[] P00AE3_n234ParticipanteDocumento ;
      private string[] P00AE3_A248ParticipanteNome ;
      private bool[] P00AE3_n248ParticipanteNome ;
      private int[] P00AE3_A242AssinaturaParticipanteId ;
      private long[] P00AE4_A238AssinaturaId ;
      private bool[] P00AE4_n238AssinaturaId ;
      private int[] P00AE4_A233ParticipanteId ;
      private bool[] P00AE4_n233ParticipanteId ;
      private DateTime[] P00AE4_A245AssinaturaParticipanteDataConclusao ;
      private bool[] P00AE4_n245AssinaturaParticipanteDataConclusao ;
      private DateTime[] P00AE4_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] P00AE4_n244AssinaturaParticipanteDataVisualizacao ;
      private string[] P00AE4_A353AssinaturaParticipanteStatus ;
      private bool[] P00AE4_n353AssinaturaParticipanteStatus ;
      private string[] P00AE4_A1004ParticipanteRepresentanteDocumento ;
      private bool[] P00AE4_n1004ParticipanteRepresentanteDocumento ;
      private string[] P00AE4_A1003ParticipanteRepresentanteEmail ;
      private bool[] P00AE4_n1003ParticipanteRepresentanteEmail ;
      private string[] P00AE4_A1002ParticipanteRepresentanteNome ;
      private bool[] P00AE4_n1002ParticipanteRepresentanteNome ;
      private string[] P00AE4_A234ParticipanteDocumento ;
      private bool[] P00AE4_n234ParticipanteDocumento ;
      private string[] P00AE4_A235ParticipanteEmail ;
      private bool[] P00AE4_n235ParticipanteEmail ;
      private string[] P00AE4_A248ParticipanteNome ;
      private bool[] P00AE4_n248ParticipanteNome ;
      private int[] P00AE4_A242AssinaturaParticipanteId ;
      private int[] P00AE5_A233ParticipanteId ;
      private bool[] P00AE5_n233ParticipanteId ;
      private long[] P00AE5_A238AssinaturaId ;
      private bool[] P00AE5_n238AssinaturaId ;
      private string[] P00AE5_A1002ParticipanteRepresentanteNome ;
      private bool[] P00AE5_n1002ParticipanteRepresentanteNome ;
      private DateTime[] P00AE5_A245AssinaturaParticipanteDataConclusao ;
      private bool[] P00AE5_n245AssinaturaParticipanteDataConclusao ;
      private DateTime[] P00AE5_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] P00AE5_n244AssinaturaParticipanteDataVisualizacao ;
      private string[] P00AE5_A353AssinaturaParticipanteStatus ;
      private bool[] P00AE5_n353AssinaturaParticipanteStatus ;
      private string[] P00AE5_A1004ParticipanteRepresentanteDocumento ;
      private bool[] P00AE5_n1004ParticipanteRepresentanteDocumento ;
      private string[] P00AE5_A1003ParticipanteRepresentanteEmail ;
      private bool[] P00AE5_n1003ParticipanteRepresentanteEmail ;
      private string[] P00AE5_A234ParticipanteDocumento ;
      private bool[] P00AE5_n234ParticipanteDocumento ;
      private string[] P00AE5_A235ParticipanteEmail ;
      private bool[] P00AE5_n235ParticipanteEmail ;
      private string[] P00AE5_A248ParticipanteNome ;
      private bool[] P00AE5_n248ParticipanteNome ;
      private int[] P00AE5_A242AssinaturaParticipanteId ;
      private int[] P00AE6_A233ParticipanteId ;
      private bool[] P00AE6_n233ParticipanteId ;
      private long[] P00AE6_A238AssinaturaId ;
      private bool[] P00AE6_n238AssinaturaId ;
      private string[] P00AE6_A1003ParticipanteRepresentanteEmail ;
      private bool[] P00AE6_n1003ParticipanteRepresentanteEmail ;
      private DateTime[] P00AE6_A245AssinaturaParticipanteDataConclusao ;
      private bool[] P00AE6_n245AssinaturaParticipanteDataConclusao ;
      private DateTime[] P00AE6_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] P00AE6_n244AssinaturaParticipanteDataVisualizacao ;
      private string[] P00AE6_A353AssinaturaParticipanteStatus ;
      private bool[] P00AE6_n353AssinaturaParticipanteStatus ;
      private string[] P00AE6_A1004ParticipanteRepresentanteDocumento ;
      private bool[] P00AE6_n1004ParticipanteRepresentanteDocumento ;
      private string[] P00AE6_A1002ParticipanteRepresentanteNome ;
      private bool[] P00AE6_n1002ParticipanteRepresentanteNome ;
      private string[] P00AE6_A234ParticipanteDocumento ;
      private bool[] P00AE6_n234ParticipanteDocumento ;
      private string[] P00AE6_A235ParticipanteEmail ;
      private bool[] P00AE6_n235ParticipanteEmail ;
      private string[] P00AE6_A248ParticipanteNome ;
      private bool[] P00AE6_n248ParticipanteNome ;
      private int[] P00AE6_A242AssinaturaParticipanteId ;
      private int[] P00AE7_A233ParticipanteId ;
      private bool[] P00AE7_n233ParticipanteId ;
      private long[] P00AE7_A238AssinaturaId ;
      private bool[] P00AE7_n238AssinaturaId ;
      private string[] P00AE7_A1004ParticipanteRepresentanteDocumento ;
      private bool[] P00AE7_n1004ParticipanteRepresentanteDocumento ;
      private DateTime[] P00AE7_A245AssinaturaParticipanteDataConclusao ;
      private bool[] P00AE7_n245AssinaturaParticipanteDataConclusao ;
      private DateTime[] P00AE7_A244AssinaturaParticipanteDataVisualizacao ;
      private bool[] P00AE7_n244AssinaturaParticipanteDataVisualizacao ;
      private string[] P00AE7_A353AssinaturaParticipanteStatus ;
      private bool[] P00AE7_n353AssinaturaParticipanteStatus ;
      private string[] P00AE7_A1003ParticipanteRepresentanteEmail ;
      private bool[] P00AE7_n1003ParticipanteRepresentanteEmail ;
      private string[] P00AE7_A1002ParticipanteRepresentanteNome ;
      private bool[] P00AE7_n1002ParticipanteRepresentanteNome ;
      private string[] P00AE7_A234ParticipanteDocumento ;
      private bool[] P00AE7_n234ParticipanteDocumento ;
      private string[] P00AE7_A235ParticipanteEmail ;
      private bool[] P00AE7_n235ParticipanteEmail ;
      private string[] P00AE7_A248ParticipanteNome ;
      private bool[] P00AE7_n248ParticipanteNome ;
      private int[] P00AE7_A242AssinaturaParticipanteId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class wcassinantesgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AE2( IGxContext context ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                             string AV79Wcassinantesds_3_tfparticipantenome_sel ,
                                             string AV78Wcassinantesds_2_tfparticipantenome ,
                                             string AV81Wcassinantesds_5_tfparticipanteemail_sel ,
                                             string AV80Wcassinantesds_4_tfparticipanteemail ,
                                             string AV83Wcassinantesds_7_tfparticipantedocumento_sel ,
                                             string AV82Wcassinantesds_6_tfparticipantedocumento ,
                                             string AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                             string AV84Wcassinantesds_8_tfparticipanterepresentantenome ,
                                             string AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                             string AV86Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                             string AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                             string AV88Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                             int AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             string A1002ParticipanteRepresentanteNome ,
                                             string A1003ParticipanteRepresentanteEmail ,
                                             string A1004ParticipanteRepresentanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             long AV77Wcassinantesds_1_assinaturaid ,
                                             long A238AssinaturaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteNome, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteStatus, T2.ParticipanteRepresentanteDocumento, T2.ParticipanteRepresentanteEmail, T2.ParticipanteRepresentanteNome, T2.ParticipanteDocumento, T2.ParticipanteEmail, T1.AssinaturaParticipanteId FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV77Wcassinantesds_1_assinaturaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_3_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wcassinantesds_2_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV78Wcassinantesds_2_tfparticipantenome)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_3_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV79Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV79Wcassinantesds_3_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV79Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_5_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wcassinantesds_4_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV80Wcassinantesds_4_tfparticipanteemail)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_5_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV81Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV81Wcassinantesds_5_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( StringUtil.StrCmp(AV81Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_7_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcassinantesds_6_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV82Wcassinantesds_6_tfparticipantedocumento)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_7_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV83Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV83Wcassinantesds_7_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV83Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wcassinantesds_8_tfparticipanterepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome like :lV84Wcassinantesds_8_tfparticipanterepresentantenome)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome = ( :AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel))");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( StringUtil.StrCmp(AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wcassinantesds_10_tfparticipanterepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail like :lV86Wcassinantesds_10_tfparticipanterepresentanteemail)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail = ( :AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel))");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( StringUtil.StrCmp(AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wcassinantesds_12_tfparticipanterepresentantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento like :lV88Wcassinantesds_12_tfparticipanterepresentantedocumento)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ! ( StringUtil.StrCmp(AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento = ( :AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel))");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( StringUtil.StrCmp(AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteDocumento))=0))");
         }
         if ( AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AssinaturaId, T2.ParticipanteNome";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00AE3( IGxContext context ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                             string AV79Wcassinantesds_3_tfparticipantenome_sel ,
                                             string AV78Wcassinantesds_2_tfparticipantenome ,
                                             string AV81Wcassinantesds_5_tfparticipanteemail_sel ,
                                             string AV80Wcassinantesds_4_tfparticipanteemail ,
                                             string AV83Wcassinantesds_7_tfparticipantedocumento_sel ,
                                             string AV82Wcassinantesds_6_tfparticipantedocumento ,
                                             string AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                             string AV84Wcassinantesds_8_tfparticipanterepresentantenome ,
                                             string AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                             string AV86Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                             string AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                             string AV88Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                             int AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             string A1002ParticipanteRepresentanteNome ,
                                             string A1003ParticipanteRepresentanteEmail ,
                                             string A1004ParticipanteRepresentanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             long AV77Wcassinantesds_1_assinaturaid ,
                                             long A238AssinaturaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteEmail, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteStatus, T2.ParticipanteRepresentanteDocumento, T2.ParticipanteRepresentanteEmail, T2.ParticipanteRepresentanteNome, T2.ParticipanteDocumento, T2.ParticipanteNome, T1.AssinaturaParticipanteId FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV77Wcassinantesds_1_assinaturaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_3_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wcassinantesds_2_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV78Wcassinantesds_2_tfparticipantenome)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_3_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV79Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV79Wcassinantesds_3_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( StringUtil.StrCmp(AV79Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_5_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wcassinantesds_4_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV80Wcassinantesds_4_tfparticipanteemail)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_5_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV81Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV81Wcassinantesds_5_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( StringUtil.StrCmp(AV81Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_7_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcassinantesds_6_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV82Wcassinantesds_6_tfparticipantedocumento)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_7_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV83Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV83Wcassinantesds_7_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV83Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wcassinantesds_8_tfparticipanterepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome like :lV84Wcassinantesds_8_tfparticipanterepresentantenome)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome = ( :AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel))");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( StringUtil.StrCmp(AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wcassinantesds_10_tfparticipanterepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail like :lV86Wcassinantesds_10_tfparticipanterepresentanteemail)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail = ( :AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel))");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( StringUtil.StrCmp(AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wcassinantesds_12_tfparticipanterepresentantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento like :lV88Wcassinantesds_12_tfparticipanterepresentantedocumento)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ! ( StringUtil.StrCmp(AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento = ( :AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel))");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( StringUtil.StrCmp(AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteDocumento))=0))");
         }
         if ( AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AssinaturaId, T2.ParticipanteEmail";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00AE4( IGxContext context ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                             string AV79Wcassinantesds_3_tfparticipantenome_sel ,
                                             string AV78Wcassinantesds_2_tfparticipantenome ,
                                             string AV81Wcassinantesds_5_tfparticipanteemail_sel ,
                                             string AV80Wcassinantesds_4_tfparticipanteemail ,
                                             string AV83Wcassinantesds_7_tfparticipantedocumento_sel ,
                                             string AV82Wcassinantesds_6_tfparticipantedocumento ,
                                             string AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                             string AV84Wcassinantesds_8_tfparticipanterepresentantenome ,
                                             string AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                             string AV86Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                             string AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                             string AV88Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                             int AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             string A1002ParticipanteRepresentanteNome ,
                                             string A1003ParticipanteRepresentanteEmail ,
                                             string A1004ParticipanteRepresentanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             long AV77Wcassinantesds_1_assinaturaid ,
                                             long A238AssinaturaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[17];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.AssinaturaId, T1.ParticipanteId, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteStatus, T2.ParticipanteRepresentanteDocumento, T2.ParticipanteRepresentanteEmail, T2.ParticipanteRepresentanteNome, T2.ParticipanteDocumento, T2.ParticipanteEmail, T2.ParticipanteNome, T1.AssinaturaParticipanteId FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV77Wcassinantesds_1_assinaturaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_3_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wcassinantesds_2_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV78Wcassinantesds_2_tfparticipantenome)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_3_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV79Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV79Wcassinantesds_3_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( StringUtil.StrCmp(AV79Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_5_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wcassinantesds_4_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV80Wcassinantesds_4_tfparticipanteemail)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_5_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV81Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV81Wcassinantesds_5_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( StringUtil.StrCmp(AV81Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_7_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcassinantesds_6_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV82Wcassinantesds_6_tfparticipantedocumento)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_7_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV83Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV83Wcassinantesds_7_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( StringUtil.StrCmp(AV83Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wcassinantesds_8_tfparticipanterepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome like :lV84Wcassinantesds_8_tfparticipanterepresentantenome)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome = ( :AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel))");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( StringUtil.StrCmp(AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wcassinantesds_10_tfparticipanterepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail like :lV86Wcassinantesds_10_tfparticipanterepresentanteemail)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail = ( :AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel))");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( StringUtil.StrCmp(AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wcassinantesds_12_tfparticipanterepresentantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento like :lV88Wcassinantesds_12_tfparticipanterepresentantedocumento)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ! ( StringUtil.StrCmp(AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento = ( :AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel))");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( StringUtil.StrCmp(AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteDocumento))=0))");
         }
         if ( AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AssinaturaId, T1.ParticipanteId";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00AE5( IGxContext context ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                             string AV79Wcassinantesds_3_tfparticipantenome_sel ,
                                             string AV78Wcassinantesds_2_tfparticipantenome ,
                                             string AV81Wcassinantesds_5_tfparticipanteemail_sel ,
                                             string AV80Wcassinantesds_4_tfparticipanteemail ,
                                             string AV83Wcassinantesds_7_tfparticipantedocumento_sel ,
                                             string AV82Wcassinantesds_6_tfparticipantedocumento ,
                                             string AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                             string AV84Wcassinantesds_8_tfparticipanterepresentantenome ,
                                             string AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                             string AV86Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                             string AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                             string AV88Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                             int AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             string A1002ParticipanteRepresentanteNome ,
                                             string A1003ParticipanteRepresentanteEmail ,
                                             string A1004ParticipanteRepresentanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             long AV77Wcassinantesds_1_assinaturaid ,
                                             long A238AssinaturaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[17];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteRepresentanteNome, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteStatus, T2.ParticipanteRepresentanteDocumento, T2.ParticipanteRepresentanteEmail, T2.ParticipanteDocumento, T2.ParticipanteEmail, T2.ParticipanteNome, T1.AssinaturaParticipanteId FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV77Wcassinantesds_1_assinaturaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_3_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wcassinantesds_2_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV78Wcassinantesds_2_tfparticipantenome)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_3_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV79Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV79Wcassinantesds_3_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( StringUtil.StrCmp(AV79Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_5_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wcassinantesds_4_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV80Wcassinantesds_4_tfparticipanteemail)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_5_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV81Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV81Wcassinantesds_5_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( StringUtil.StrCmp(AV81Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_7_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcassinantesds_6_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV82Wcassinantesds_6_tfparticipantedocumento)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_7_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV83Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV83Wcassinantesds_7_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( StringUtil.StrCmp(AV83Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wcassinantesds_8_tfparticipanterepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome like :lV84Wcassinantesds_8_tfparticipanterepresentantenome)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome = ( :AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wcassinantesds_10_tfparticipanterepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail like :lV86Wcassinantesds_10_tfparticipanterepresentanteemail)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail = ( :AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wcassinantesds_12_tfparticipanterepresentantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento like :lV88Wcassinantesds_12_tfparticipanterepresentantedocumento)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ! ( StringUtil.StrCmp(AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento = ( :AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteDocumento))=0))");
         }
         if ( AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AssinaturaId, T2.ParticipanteRepresentanteNome";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00AE6( IGxContext context ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                             string AV79Wcassinantesds_3_tfparticipantenome_sel ,
                                             string AV78Wcassinantesds_2_tfparticipantenome ,
                                             string AV81Wcassinantesds_5_tfparticipanteemail_sel ,
                                             string AV80Wcassinantesds_4_tfparticipanteemail ,
                                             string AV83Wcassinantesds_7_tfparticipantedocumento_sel ,
                                             string AV82Wcassinantesds_6_tfparticipantedocumento ,
                                             string AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                             string AV84Wcassinantesds_8_tfparticipanterepresentantenome ,
                                             string AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                             string AV86Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                             string AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                             string AV88Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                             int AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             string A1002ParticipanteRepresentanteNome ,
                                             string A1003ParticipanteRepresentanteEmail ,
                                             string A1004ParticipanteRepresentanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             long AV77Wcassinantesds_1_assinaturaid ,
                                             long A238AssinaturaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[17];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteRepresentanteEmail, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteStatus, T2.ParticipanteRepresentanteDocumento, T2.ParticipanteRepresentanteNome, T2.ParticipanteDocumento, T2.ParticipanteEmail, T2.ParticipanteNome, T1.AssinaturaParticipanteId FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV77Wcassinantesds_1_assinaturaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_3_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wcassinantesds_2_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV78Wcassinantesds_2_tfparticipantenome)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_3_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV79Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV79Wcassinantesds_3_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( StringUtil.StrCmp(AV79Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_5_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wcassinantesds_4_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV80Wcassinantesds_4_tfparticipanteemail)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_5_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV81Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV81Wcassinantesds_5_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( StringUtil.StrCmp(AV81Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_7_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcassinantesds_6_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV82Wcassinantesds_6_tfparticipantedocumento)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_7_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV83Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV83Wcassinantesds_7_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( StringUtil.StrCmp(AV83Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wcassinantesds_8_tfparticipanterepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome like :lV84Wcassinantesds_8_tfparticipanterepresentantenome)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome = ( :AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wcassinantesds_10_tfparticipanterepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail like :lV86Wcassinantesds_10_tfparticipanterepresentanteemail)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail = ( :AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wcassinantesds_12_tfparticipanterepresentantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento like :lV88Wcassinantesds_12_tfparticipanterepresentantedocumento)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ! ( StringUtil.StrCmp(AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento = ( :AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteDocumento))=0))");
         }
         if ( AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AssinaturaId, T2.ParticipanteRepresentanteEmail";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      protected Object[] conditional_P00AE7( IGxContext context ,
                                             string A353AssinaturaParticipanteStatus ,
                                             GxSimpleCollection<string> AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels ,
                                             string AV79Wcassinantesds_3_tfparticipantenome_sel ,
                                             string AV78Wcassinantesds_2_tfparticipantenome ,
                                             string AV81Wcassinantesds_5_tfparticipanteemail_sel ,
                                             string AV80Wcassinantesds_4_tfparticipanteemail ,
                                             string AV83Wcassinantesds_7_tfparticipantedocumento_sel ,
                                             string AV82Wcassinantesds_6_tfparticipantedocumento ,
                                             string AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel ,
                                             string AV84Wcassinantesds_8_tfparticipanterepresentantenome ,
                                             string AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel ,
                                             string AV86Wcassinantesds_10_tfparticipanterepresentanteemail ,
                                             string AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel ,
                                             string AV88Wcassinantesds_12_tfparticipanterepresentantedocumento ,
                                             int AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count ,
                                             DateTime AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao ,
                                             DateTime AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to ,
                                             DateTime AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao ,
                                             DateTime AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to ,
                                             string A248ParticipanteNome ,
                                             string A235ParticipanteEmail ,
                                             string A234ParticipanteDocumento ,
                                             string A1002ParticipanteRepresentanteNome ,
                                             string A1003ParticipanteRepresentanteEmail ,
                                             string A1004ParticipanteRepresentanteDocumento ,
                                             DateTime A244AssinaturaParticipanteDataVisualizacao ,
                                             DateTime A245AssinaturaParticipanteDataConclusao ,
                                             long AV77Wcassinantesds_1_assinaturaid ,
                                             long A238AssinaturaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int11 = new short[17];
         Object[] GXv_Object12 = new Object[2];
         scmdbuf = "SELECT T1.ParticipanteId, T1.AssinaturaId, T2.ParticipanteRepresentanteDocumento, T1.AssinaturaParticipanteDataConclusao, T1.AssinaturaParticipanteDataVisualizacao, T1.AssinaturaParticipanteStatus, T2.ParticipanteRepresentanteEmail, T2.ParticipanteRepresentanteNome, T2.ParticipanteDocumento, T2.ParticipanteEmail, T2.ParticipanteNome, T1.AssinaturaParticipanteId FROM (AssinaturaParticipante T1 LEFT JOIN Participante T2 ON T2.ParticipanteId = T1.ParticipanteId)";
         AddWhere(sWhereString, "(T1.AssinaturaId = :AV77Wcassinantesds_1_assinaturaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_3_tfparticipantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Wcassinantesds_2_tfparticipantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome like :lV78Wcassinantesds_2_tfparticipantenome)");
         }
         else
         {
            GXv_int11[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wcassinantesds_3_tfparticipantenome_sel)) && ! ( StringUtil.StrCmp(AV79Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome = ( :AV79Wcassinantesds_3_tfparticipantenome_sel))");
         }
         else
         {
            GXv_int11[2] = 1;
         }
         if ( StringUtil.StrCmp(AV79Wcassinantesds_3_tfparticipantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteNome IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_5_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wcassinantesds_4_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail like :lV80Wcassinantesds_4_tfparticipanteemail)");
         }
         else
         {
            GXv_int11[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Wcassinantesds_5_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV81Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail = ( :AV81Wcassinantesds_5_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int11[4] = 1;
         }
         if ( StringUtil.StrCmp(AV81Wcassinantesds_5_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_7_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Wcassinantesds_6_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento like :lV82Wcassinantesds_6_tfparticipantedocumento)");
         }
         else
         {
            GXv_int11[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wcassinantesds_7_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV83Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento = ( :AV83Wcassinantesds_7_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int11[6] = 1;
         }
         if ( StringUtil.StrCmp(AV83Wcassinantesds_7_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from T2.ParticipanteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wcassinantesds_8_tfparticipanterepresentantenome)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome like :lV84Wcassinantesds_8_tfparticipanterepresentantenome)");
         }
         else
         {
            GXv_int11[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel)) && ! ( StringUtil.StrCmp(AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteNome = ( :AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel))");
         }
         else
         {
            GXv_int11[8] = 1;
         }
         if ( StringUtil.StrCmp(AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wcassinantesds_10_tfparticipanterepresentanteemail)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail like :lV86Wcassinantesds_10_tfparticipanterepresentanteemail)");
         }
         else
         {
            GXv_int11[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel)) && ! ( StringUtil.StrCmp(AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteEmail = ( :AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel))");
         }
         else
         {
            GXv_int11[10] = 1;
         }
         if ( StringUtil.StrCmp(AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wcassinantesds_12_tfparticipanterepresentantedocumento)) ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento like :lV88Wcassinantesds_12_tfparticipanterepresentantedocumento)");
         }
         else
         {
            GXv_int11[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel)) && ! ( StringUtil.StrCmp(AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.ParticipanteRepresentanteDocumento = ( :AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel))");
         }
         else
         {
            GXv_int11[12] = 1;
         }
         if ( StringUtil.StrCmp(AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.ParticipanteRepresentanteDocumento))=0))");
         }
         if ( AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV90Wcassinantesds_14_tfassinaturaparticipantestatus_sels, "T1.AssinaturaParticipanteStatus IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao >= :AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao)");
         }
         else
         {
            GXv_int11[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataVisualizacao <= :AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_)");
         }
         else
         {
            GXv_int11[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao >= :AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao)");
         }
         else
         {
            GXv_int11[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to) )
         {
            AddWhere(sWhereString, "(T1.AssinaturaParticipanteDataConclusao <= :AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to)");
         }
         else
         {
            GXv_int11[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.AssinaturaId, T2.ParticipanteRepresentanteDocumento";
         GXv_Object12[0] = scmdbuf;
         GXv_Object12[1] = GXv_int11;
         return GXv_Object12 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00AE2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] );
               case 1 :
                     return conditional_P00AE3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] );
               case 2 :
                     return conditional_P00AE4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] );
               case 3 :
                     return conditional_P00AE5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] );
               case 4 :
                     return conditional_P00AE6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] );
               case 5 :
                     return conditional_P00AE7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (int)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00AE2;
          prmP00AE2 = new Object[] {
          new ParDef("AV77Wcassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV78Wcassinantesds_2_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV79Wcassinantesds_3_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV80Wcassinantesds_4_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV81Wcassinantesds_5_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcassinantesds_6_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV83Wcassinantesds_7_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("lV84Wcassinantesds_8_tfparticipanterepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV86Wcassinantesds_10_tfparticipanterepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcassinantesds_12_tfparticipanterepresentantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao",GXType.DateTime,10,8) ,
          new ParDef("AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_",GXType.DateTime,10,8) ,
          new ParDef("AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao",GXType.DateTime,10,8) ,
          new ParDef("AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to",GXType.DateTime,10,8)
          };
          Object[] prmP00AE3;
          prmP00AE3 = new Object[] {
          new ParDef("AV77Wcassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV78Wcassinantesds_2_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV79Wcassinantesds_3_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV80Wcassinantesds_4_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV81Wcassinantesds_5_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcassinantesds_6_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV83Wcassinantesds_7_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("lV84Wcassinantesds_8_tfparticipanterepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV86Wcassinantesds_10_tfparticipanterepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcassinantesds_12_tfparticipanterepresentantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao",GXType.DateTime,10,8) ,
          new ParDef("AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_",GXType.DateTime,10,8) ,
          new ParDef("AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao",GXType.DateTime,10,8) ,
          new ParDef("AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to",GXType.DateTime,10,8)
          };
          Object[] prmP00AE4;
          prmP00AE4 = new Object[] {
          new ParDef("AV77Wcassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV78Wcassinantesds_2_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV79Wcassinantesds_3_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV80Wcassinantesds_4_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV81Wcassinantesds_5_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcassinantesds_6_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV83Wcassinantesds_7_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("lV84Wcassinantesds_8_tfparticipanterepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV86Wcassinantesds_10_tfparticipanterepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcassinantesds_12_tfparticipanterepresentantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao",GXType.DateTime,10,8) ,
          new ParDef("AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_",GXType.DateTime,10,8) ,
          new ParDef("AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao",GXType.DateTime,10,8) ,
          new ParDef("AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to",GXType.DateTime,10,8)
          };
          Object[] prmP00AE5;
          prmP00AE5 = new Object[] {
          new ParDef("AV77Wcassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV78Wcassinantesds_2_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV79Wcassinantesds_3_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV80Wcassinantesds_4_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV81Wcassinantesds_5_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcassinantesds_6_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV83Wcassinantesds_7_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("lV84Wcassinantesds_8_tfparticipanterepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV86Wcassinantesds_10_tfparticipanterepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcassinantesds_12_tfparticipanterepresentantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao",GXType.DateTime,10,8) ,
          new ParDef("AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_",GXType.DateTime,10,8) ,
          new ParDef("AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao",GXType.DateTime,10,8) ,
          new ParDef("AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to",GXType.DateTime,10,8)
          };
          Object[] prmP00AE6;
          prmP00AE6 = new Object[] {
          new ParDef("AV77Wcassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV78Wcassinantesds_2_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV79Wcassinantesds_3_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV80Wcassinantesds_4_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV81Wcassinantesds_5_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcassinantesds_6_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV83Wcassinantesds_7_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("lV84Wcassinantesds_8_tfparticipanterepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV86Wcassinantesds_10_tfparticipanterepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcassinantesds_12_tfparticipanterepresentantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao",GXType.DateTime,10,8) ,
          new ParDef("AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_",GXType.DateTime,10,8) ,
          new ParDef("AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao",GXType.DateTime,10,8) ,
          new ParDef("AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to",GXType.DateTime,10,8)
          };
          Object[] prmP00AE7;
          prmP00AE7 = new Object[] {
          new ParDef("AV77Wcassinantesds_1_assinaturaid",GXType.Int64,10,0) ,
          new ParDef("lV78Wcassinantesds_2_tfparticipantenome",GXType.VarChar,150,0) ,
          new ParDef("AV79Wcassinantesds_3_tfparticipantenome_sel",GXType.VarChar,150,0) ,
          new ParDef("lV80Wcassinantesds_4_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV81Wcassinantesds_5_tfparticipanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV82Wcassinantesds_6_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV83Wcassinantesds_7_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("lV84Wcassinantesds_8_tfparticipanterepresentantenome",GXType.VarChar,100,0) ,
          new ParDef("AV85Wcassinantesds_9_tfparticipanterepresentantenome_sel",GXType.VarChar,100,0) ,
          new ParDef("lV86Wcassinantesds_10_tfparticipanterepresentanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV87Wcassinantesds_11_tfparticipanterepresentanteemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV88Wcassinantesds_12_tfparticipanterepresentantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV89Wcassinantesds_13_tfparticipanterepresentantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("AV91Wcassinantesds_15_tfassinaturaparticipantedatavisualizacao",GXType.DateTime,10,8) ,
          new ParDef("AV92Wcassinantesds_16_tfassinaturaparticipantedatavisualizacao_",GXType.DateTime,10,8) ,
          new ParDef("AV93Wcassinantesds_17_tfassinaturaparticipantedataconclusao",GXType.DateTime,10,8) ,
          new ParDef("AV94Wcassinantesds_18_tfassinaturaparticipantedataconclusao_to",GXType.DateTime,10,8)
          };
          def= new CursorDef[] {
              new CursorDef("P00AE2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AE2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AE3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AE3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AE4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AE4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AE5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AE5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AE6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AE6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AE7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AE7,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 3 :
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 4 :
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
             case 5 :
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
                ((string[]) buf[18])[0] = rslt.getVarchar(10);
                ((bool[]) buf[19])[0] = rslt.wasNull(10);
                ((string[]) buf[20])[0] = rslt.getVarchar(11);
                ((bool[]) buf[21])[0] = rslt.wasNull(11);
                ((int[]) buf[22])[0] = rslt.getInt(12);
                return;
       }
    }

 }

}
