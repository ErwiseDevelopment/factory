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
   public class participantewwgetfilterdata : GXProcedure
   {
      public participantewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public participantewwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_PARTICIPANTEDOCUMENTO") == 0 )
         {
            /* Execute user subroutine: 'LOADPARTICIPANTEDOCUMENTOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_PARTICIPANTEEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADPARTICIPANTEEMAILOPTIONS' */
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
         if ( StringUtil.StrCmp(AV29Session.Get("ParticipanteWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ParticipanteWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("ParticipanteWWGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV40FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEID") == 0 )
            {
               AV10TFParticipanteId = (int)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV11TFParticipanteId_To = (int)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO") == 0 )
            {
               AV12TFParticipanteDocumento = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEDOCUMENTO_SEL") == 0 )
            {
               AV52TFParticipanteDocumento_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL") == 0 )
            {
               AV14TFParticipanteEmail = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPARTICIPANTEEMAIL_SEL") == 0 )
            {
               AV15TFParticipanteEmail_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV41DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "PARTICIPANTEDOCUMENTO") == 0 )
            {
               AV43ParticipanteDocumento1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "PARTICIPANTEDOCUMENTO") == 0 )
               {
                  AV47ParticipanteDocumento2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV48DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV49DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV49DynamicFiltersSelector3, "PARTICIPANTEDOCUMENTO") == 0 )
                  {
                     AV51ParticipanteDocumento3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPARTICIPANTEDOCUMENTOOPTIONS' Routine */
         returnInSub = false;
         AV12TFParticipanteDocumento = AV18SearchTxt;
         AV52TFParticipanteDocumento_Sel = "";
         AV55Participantewwds_1_filterfulltext = AV40FilterFullText;
         AV56Participantewwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV57Participantewwds_3_participantedocumento1 = AV43ParticipanteDocumento1;
         AV58Participantewwds_4_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV59Participantewwds_5_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV60Participantewwds_6_participantedocumento2 = AV47ParticipanteDocumento2;
         AV61Participantewwds_7_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV62Participantewwds_8_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV63Participantewwds_9_participantedocumento3 = AV51ParticipanteDocumento3;
         AV64Participantewwds_10_tfparticipanteid = AV10TFParticipanteId;
         AV65Participantewwds_11_tfparticipanteid_to = AV11TFParticipanteId_To;
         AV66Participantewwds_12_tfparticipantedocumento = AV12TFParticipanteDocumento;
         AV67Participantewwds_13_tfparticipantedocumento_sel = AV52TFParticipanteDocumento_Sel;
         AV68Participantewwds_14_tfparticipanteemail = AV14TFParticipanteEmail;
         AV69Participantewwds_15_tfparticipanteemail_sel = AV15TFParticipanteEmail_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV55Participantewwds_1_filterfulltext ,
                                              AV56Participantewwds_2_dynamicfiltersselector1 ,
                                              AV57Participantewwds_3_participantedocumento1 ,
                                              AV58Participantewwds_4_dynamicfiltersenabled2 ,
                                              AV59Participantewwds_5_dynamicfiltersselector2 ,
                                              AV60Participantewwds_6_participantedocumento2 ,
                                              AV61Participantewwds_7_dynamicfiltersenabled3 ,
                                              AV62Participantewwds_8_dynamicfiltersselector3 ,
                                              AV63Participantewwds_9_participantedocumento3 ,
                                              AV64Participantewwds_10_tfparticipanteid ,
                                              AV65Participantewwds_11_tfparticipanteid_to ,
                                              AV67Participantewwds_13_tfparticipantedocumento_sel ,
                                              AV66Participantewwds_12_tfparticipantedocumento ,
                                              AV69Participantewwds_15_tfparticipanteemail_sel ,
                                              AV68Participantewwds_14_tfparticipanteemail ,
                                              A233ParticipanteId ,
                                              A234ParticipanteDocumento ,
                                              A235ParticipanteEmail } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV55Participantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Participantewwds_1_filterfulltext), "%", "");
         lV55Participantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Participantewwds_1_filterfulltext), "%", "");
         lV55Participantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Participantewwds_1_filterfulltext), "%", "");
         lV57Participantewwds_3_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV57Participantewwds_3_participantedocumento1), "%", "");
         lV60Participantewwds_6_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV60Participantewwds_6_participantedocumento2), "%", "");
         lV63Participantewwds_9_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV63Participantewwds_9_participantedocumento3), "%", "");
         lV66Participantewwds_12_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV66Participantewwds_12_tfparticipantedocumento), "%", "");
         lV68Participantewwds_14_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV68Participantewwds_14_tfparticipanteemail), "%", "");
         /* Using cursor P007B2 */
         pr_default.execute(0, new Object[] {lV55Participantewwds_1_filterfulltext, lV55Participantewwds_1_filterfulltext, lV55Participantewwds_1_filterfulltext, lV57Participantewwds_3_participantedocumento1, lV60Participantewwds_6_participantedocumento2, lV63Participantewwds_9_participantedocumento3, AV64Participantewwds_10_tfparticipanteid, AV65Participantewwds_11_tfparticipanteid_to, lV66Participantewwds_12_tfparticipantedocumento, AV67Participantewwds_13_tfparticipantedocumento_sel, lV68Participantewwds_14_tfparticipanteemail, AV69Participantewwds_15_tfparticipanteemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7B2 = false;
            A234ParticipanteDocumento = P007B2_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P007B2_n234ParticipanteDocumento[0];
            A233ParticipanteId = P007B2_A233ParticipanteId[0];
            A235ParticipanteEmail = P007B2_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P007B2_n235ParticipanteEmail[0];
            AV28count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007B2_A234ParticipanteDocumento[0], A234ParticipanteDocumento) == 0 ) )
            {
               BRK7B2 = false;
               A233ParticipanteId = P007B2_A233ParticipanteId[0];
               AV28count = (long)(AV28count+1);
               BRK7B2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A234ParticipanteDocumento)) ? "<#Empty#>" : A234ParticipanteDocumento);
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
            if ( ! BRK7B2 )
            {
               BRK7B2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPARTICIPANTEEMAILOPTIONS' Routine */
         returnInSub = false;
         AV14TFParticipanteEmail = AV18SearchTxt;
         AV15TFParticipanteEmail_Sel = "";
         AV55Participantewwds_1_filterfulltext = AV40FilterFullText;
         AV56Participantewwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV57Participantewwds_3_participantedocumento1 = AV43ParticipanteDocumento1;
         AV58Participantewwds_4_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV59Participantewwds_5_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV60Participantewwds_6_participantedocumento2 = AV47ParticipanteDocumento2;
         AV61Participantewwds_7_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV62Participantewwds_8_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV63Participantewwds_9_participantedocumento3 = AV51ParticipanteDocumento3;
         AV64Participantewwds_10_tfparticipanteid = AV10TFParticipanteId;
         AV65Participantewwds_11_tfparticipanteid_to = AV11TFParticipanteId_To;
         AV66Participantewwds_12_tfparticipantedocumento = AV12TFParticipanteDocumento;
         AV67Participantewwds_13_tfparticipantedocumento_sel = AV52TFParticipanteDocumento_Sel;
         AV68Participantewwds_14_tfparticipanteemail = AV14TFParticipanteEmail;
         AV69Participantewwds_15_tfparticipanteemail_sel = AV15TFParticipanteEmail_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV55Participantewwds_1_filterfulltext ,
                                              AV56Participantewwds_2_dynamicfiltersselector1 ,
                                              AV57Participantewwds_3_participantedocumento1 ,
                                              AV58Participantewwds_4_dynamicfiltersenabled2 ,
                                              AV59Participantewwds_5_dynamicfiltersselector2 ,
                                              AV60Participantewwds_6_participantedocumento2 ,
                                              AV61Participantewwds_7_dynamicfiltersenabled3 ,
                                              AV62Participantewwds_8_dynamicfiltersselector3 ,
                                              AV63Participantewwds_9_participantedocumento3 ,
                                              AV64Participantewwds_10_tfparticipanteid ,
                                              AV65Participantewwds_11_tfparticipanteid_to ,
                                              AV67Participantewwds_13_tfparticipantedocumento_sel ,
                                              AV66Participantewwds_12_tfparticipantedocumento ,
                                              AV69Participantewwds_15_tfparticipanteemail_sel ,
                                              AV68Participantewwds_14_tfparticipanteemail ,
                                              A233ParticipanteId ,
                                              A234ParticipanteDocumento ,
                                              A235ParticipanteEmail } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV55Participantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Participantewwds_1_filterfulltext), "%", "");
         lV55Participantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Participantewwds_1_filterfulltext), "%", "");
         lV55Participantewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Participantewwds_1_filterfulltext), "%", "");
         lV57Participantewwds_3_participantedocumento1 = StringUtil.Concat( StringUtil.RTrim( AV57Participantewwds_3_participantedocumento1), "%", "");
         lV60Participantewwds_6_participantedocumento2 = StringUtil.Concat( StringUtil.RTrim( AV60Participantewwds_6_participantedocumento2), "%", "");
         lV63Participantewwds_9_participantedocumento3 = StringUtil.Concat( StringUtil.RTrim( AV63Participantewwds_9_participantedocumento3), "%", "");
         lV66Participantewwds_12_tfparticipantedocumento = StringUtil.Concat( StringUtil.RTrim( AV66Participantewwds_12_tfparticipantedocumento), "%", "");
         lV68Participantewwds_14_tfparticipanteemail = StringUtil.Concat( StringUtil.RTrim( AV68Participantewwds_14_tfparticipanteemail), "%", "");
         /* Using cursor P007B3 */
         pr_default.execute(1, new Object[] {lV55Participantewwds_1_filterfulltext, lV55Participantewwds_1_filterfulltext, lV55Participantewwds_1_filterfulltext, lV57Participantewwds_3_participantedocumento1, lV60Participantewwds_6_participantedocumento2, lV63Participantewwds_9_participantedocumento3, AV64Participantewwds_10_tfparticipanteid, AV65Participantewwds_11_tfparticipanteid_to, lV66Participantewwds_12_tfparticipantedocumento, AV67Participantewwds_13_tfparticipantedocumento_sel, lV68Participantewwds_14_tfparticipanteemail, AV69Participantewwds_15_tfparticipanteemail_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7B4 = false;
            A235ParticipanteEmail = P007B3_A235ParticipanteEmail[0];
            n235ParticipanteEmail = P007B3_n235ParticipanteEmail[0];
            A233ParticipanteId = P007B3_A233ParticipanteId[0];
            A234ParticipanteDocumento = P007B3_A234ParticipanteDocumento[0];
            n234ParticipanteDocumento = P007B3_n234ParticipanteDocumento[0];
            AV28count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007B3_A235ParticipanteEmail[0], A235ParticipanteEmail) == 0 ) )
            {
               BRK7B4 = false;
               A233ParticipanteId = P007B3_A233ParticipanteId[0];
               AV28count = (long)(AV28count+1);
               BRK7B4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A235ParticipanteEmail)) ? "<#Empty#>" : A235ParticipanteEmail);
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
            if ( ! BRK7B4 )
            {
               BRK7B4 = true;
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
         AV40FilterFullText = "";
         AV12TFParticipanteDocumento = "";
         AV52TFParticipanteDocumento_Sel = "";
         AV14TFParticipanteEmail = "";
         AV15TFParticipanteEmail_Sel = "";
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV41DynamicFiltersSelector1 = "";
         AV43ParticipanteDocumento1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV47ParticipanteDocumento2 = "";
         AV49DynamicFiltersSelector3 = "";
         AV51ParticipanteDocumento3 = "";
         AV55Participantewwds_1_filterfulltext = "";
         AV56Participantewwds_2_dynamicfiltersselector1 = "";
         AV57Participantewwds_3_participantedocumento1 = "";
         AV59Participantewwds_5_dynamicfiltersselector2 = "";
         AV60Participantewwds_6_participantedocumento2 = "";
         AV62Participantewwds_8_dynamicfiltersselector3 = "";
         AV63Participantewwds_9_participantedocumento3 = "";
         AV66Participantewwds_12_tfparticipantedocumento = "";
         AV67Participantewwds_13_tfparticipantedocumento_sel = "";
         AV68Participantewwds_14_tfparticipanteemail = "";
         AV69Participantewwds_15_tfparticipanteemail_sel = "";
         lV55Participantewwds_1_filterfulltext = "";
         lV57Participantewwds_3_participantedocumento1 = "";
         lV60Participantewwds_6_participantedocumento2 = "";
         lV63Participantewwds_9_participantedocumento3 = "";
         lV66Participantewwds_12_tfparticipantedocumento = "";
         lV68Participantewwds_14_tfparticipanteemail = "";
         A234ParticipanteDocumento = "";
         A235ParticipanteEmail = "";
         P007B2_A234ParticipanteDocumento = new string[] {""} ;
         P007B2_n234ParticipanteDocumento = new bool[] {false} ;
         P007B2_A233ParticipanteId = new int[1] ;
         P007B2_A235ParticipanteEmail = new string[] {""} ;
         P007B2_n235ParticipanteEmail = new bool[] {false} ;
         AV23Option = "";
         P007B3_A235ParticipanteEmail = new string[] {""} ;
         P007B3_n235ParticipanteEmail = new bool[] {false} ;
         P007B3_A233ParticipanteId = new int[1] ;
         P007B3_A234ParticipanteDocumento = new string[] {""} ;
         P007B3_n234ParticipanteDocumento = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.participantewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007B2_A234ParticipanteDocumento, P007B2_n234ParticipanteDocumento, P007B2_A233ParticipanteId, P007B2_A235ParticipanteEmail, P007B2_n235ParticipanteEmail
               }
               , new Object[] {
               P007B3_A235ParticipanteEmail, P007B3_n235ParticipanteEmail, P007B3_A233ParticipanteId, P007B3_A234ParticipanteDocumento, P007B3_n234ParticipanteDocumento
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21MaxItems ;
      private short AV20PageIndex ;
      private short AV19SkipItems ;
      private int AV53GXV1 ;
      private int AV10TFParticipanteId ;
      private int AV11TFParticipanteId_To ;
      private int AV64Participantewwds_10_tfparticipanteid ;
      private int AV65Participantewwds_11_tfparticipanteid_to ;
      private int A233ParticipanteId ;
      private long AV28count ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV48DynamicFiltersEnabled3 ;
      private bool AV58Participantewwds_4_dynamicfiltersenabled2 ;
      private bool AV61Participantewwds_7_dynamicfiltersenabled3 ;
      private bool BRK7B2 ;
      private bool n234ParticipanteDocumento ;
      private bool n235ParticipanteEmail ;
      private bool BRK7B4 ;
      private string AV37OptionsJson ;
      private string AV38OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV34DDOName ;
      private string AV35SearchTxtParms ;
      private string AV36SearchTxtTo ;
      private string AV18SearchTxt ;
      private string AV40FilterFullText ;
      private string AV12TFParticipanteDocumento ;
      private string AV52TFParticipanteDocumento_Sel ;
      private string AV14TFParticipanteEmail ;
      private string AV15TFParticipanteEmail_Sel ;
      private string AV41DynamicFiltersSelector1 ;
      private string AV43ParticipanteDocumento1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV47ParticipanteDocumento2 ;
      private string AV49DynamicFiltersSelector3 ;
      private string AV51ParticipanteDocumento3 ;
      private string AV55Participantewwds_1_filterfulltext ;
      private string AV56Participantewwds_2_dynamicfiltersselector1 ;
      private string AV57Participantewwds_3_participantedocumento1 ;
      private string AV59Participantewwds_5_dynamicfiltersselector2 ;
      private string AV60Participantewwds_6_participantedocumento2 ;
      private string AV62Participantewwds_8_dynamicfiltersselector3 ;
      private string AV63Participantewwds_9_participantedocumento3 ;
      private string AV66Participantewwds_12_tfparticipantedocumento ;
      private string AV67Participantewwds_13_tfparticipantedocumento_sel ;
      private string AV68Participantewwds_14_tfparticipanteemail ;
      private string AV69Participantewwds_15_tfparticipanteemail_sel ;
      private string lV55Participantewwds_1_filterfulltext ;
      private string lV57Participantewwds_3_participantedocumento1 ;
      private string lV60Participantewwds_6_participantedocumento2 ;
      private string lV63Participantewwds_9_participantedocumento3 ;
      private string lV66Participantewwds_12_tfparticipantedocumento ;
      private string lV68Participantewwds_14_tfparticipanteemail ;
      private string A234ParticipanteDocumento ;
      private string A235ParticipanteEmail ;
      private string AV23Option ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P007B2_A234ParticipanteDocumento ;
      private bool[] P007B2_n234ParticipanteDocumento ;
      private int[] P007B2_A233ParticipanteId ;
      private string[] P007B2_A235ParticipanteEmail ;
      private bool[] P007B2_n235ParticipanteEmail ;
      private string[] P007B3_A235ParticipanteEmail ;
      private bool[] P007B3_n235ParticipanteEmail ;
      private int[] P007B3_A233ParticipanteId ;
      private string[] P007B3_A234ParticipanteDocumento ;
      private bool[] P007B3_n234ParticipanteDocumento ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class participantewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007B2( IGxContext context ,
                                             string AV55Participantewwds_1_filterfulltext ,
                                             string AV56Participantewwds_2_dynamicfiltersselector1 ,
                                             string AV57Participantewwds_3_participantedocumento1 ,
                                             bool AV58Participantewwds_4_dynamicfiltersenabled2 ,
                                             string AV59Participantewwds_5_dynamicfiltersselector2 ,
                                             string AV60Participantewwds_6_participantedocumento2 ,
                                             bool AV61Participantewwds_7_dynamicfiltersenabled3 ,
                                             string AV62Participantewwds_8_dynamicfiltersselector3 ,
                                             string AV63Participantewwds_9_participantedocumento3 ,
                                             int AV64Participantewwds_10_tfparticipanteid ,
                                             int AV65Participantewwds_11_tfparticipanteid_to ,
                                             string AV67Participantewwds_13_tfparticipantedocumento_sel ,
                                             string AV66Participantewwds_12_tfparticipantedocumento ,
                                             string AV69Participantewwds_15_tfparticipanteemail_sel ,
                                             string AV68Participantewwds_14_tfparticipanteemail ,
                                             int A233ParticipanteId ,
                                             string A234ParticipanteDocumento ,
                                             string A235ParticipanteEmail )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ParticipanteDocumento, ParticipanteId, ParticipanteEmail FROM Participante";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Participantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(ParticipanteId,'99999999'), 2) like '%' || :lV55Participantewwds_1_filterfulltext) or ( ParticipanteDocumento like '%' || :lV55Participantewwds_1_filterfulltext) or ( ParticipanteEmail like '%' || :lV55Participantewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Participantewwds_2_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Participantewwds_3_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV57Participantewwds_3_participantedocumento1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV58Participantewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Participantewwds_5_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Participantewwds_6_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV60Participantewwds_6_participantedocumento2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV61Participantewwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Participantewwds_8_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Participantewwds_9_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV63Participantewwds_9_participantedocumento3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV64Participantewwds_10_tfparticipanteid) )
         {
            AddWhere(sWhereString, "(ParticipanteId >= :AV64Participantewwds_10_tfparticipanteid)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV65Participantewwds_11_tfparticipanteid_to) )
         {
            AddWhere(sWhereString, "(ParticipanteId <= :AV65Participantewwds_11_tfparticipanteid_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Participantewwds_13_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Participantewwds_12_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV66Participantewwds_12_tfparticipantedocumento)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Participantewwds_13_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV67Participantewwds_13_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento = ( :AV67Participantewwds_13_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Participantewwds_13_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from ParticipanteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Participantewwds_15_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Participantewwds_14_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteEmail like :lV68Participantewwds_14_tfparticipanteemail)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Participantewwds_15_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV69Participantewwds_15_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParticipanteEmail = ( :AV69Participantewwds_15_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Participantewwds_15_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from ParticipanteEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ParticipanteDocumento";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007B3( IGxContext context ,
                                             string AV55Participantewwds_1_filterfulltext ,
                                             string AV56Participantewwds_2_dynamicfiltersselector1 ,
                                             string AV57Participantewwds_3_participantedocumento1 ,
                                             bool AV58Participantewwds_4_dynamicfiltersenabled2 ,
                                             string AV59Participantewwds_5_dynamicfiltersselector2 ,
                                             string AV60Participantewwds_6_participantedocumento2 ,
                                             bool AV61Participantewwds_7_dynamicfiltersenabled3 ,
                                             string AV62Participantewwds_8_dynamicfiltersselector3 ,
                                             string AV63Participantewwds_9_participantedocumento3 ,
                                             int AV64Participantewwds_10_tfparticipanteid ,
                                             int AV65Participantewwds_11_tfparticipanteid_to ,
                                             string AV67Participantewwds_13_tfparticipantedocumento_sel ,
                                             string AV66Participantewwds_12_tfparticipantedocumento ,
                                             string AV69Participantewwds_15_tfparticipanteemail_sel ,
                                             string AV68Participantewwds_14_tfparticipanteemail ,
                                             int A233ParticipanteId ,
                                             string A234ParticipanteDocumento ,
                                             string A235ParticipanteEmail )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT ParticipanteEmail, ParticipanteId, ParticipanteDocumento FROM Participante";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Participantewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(ParticipanteId,'99999999'), 2) like '%' || :lV55Participantewwds_1_filterfulltext) or ( ParticipanteDocumento like '%' || :lV55Participantewwds_1_filterfulltext) or ( ParticipanteEmail like '%' || :lV55Participantewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Participantewwds_2_dynamicfiltersselector1, "PARTICIPANTEDOCUMENTO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Participantewwds_3_participantedocumento1)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV57Participantewwds_3_participantedocumento1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Participantewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Participantewwds_5_dynamicfiltersselector2, "PARTICIPANTEDOCUMENTO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Participantewwds_6_participantedocumento2)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV60Participantewwds_6_participantedocumento2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV61Participantewwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Participantewwds_8_dynamicfiltersselector3, "PARTICIPANTEDOCUMENTO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Participantewwds_9_participantedocumento3)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV63Participantewwds_9_participantedocumento3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV64Participantewwds_10_tfparticipanteid) )
         {
            AddWhere(sWhereString, "(ParticipanteId >= :AV64Participantewwds_10_tfparticipanteid)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV65Participantewwds_11_tfparticipanteid_to) )
         {
            AddWhere(sWhereString, "(ParticipanteId <= :AV65Participantewwds_11_tfparticipanteid_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Participantewwds_13_tfparticipantedocumento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Participantewwds_12_tfparticipantedocumento)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento like :lV66Participantewwds_12_tfparticipantedocumento)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Participantewwds_13_tfparticipantedocumento_sel)) && ! ( StringUtil.StrCmp(AV67Participantewwds_13_tfparticipantedocumento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento = ( :AV67Participantewwds_13_tfparticipantedocumento_sel))");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Participantewwds_13_tfparticipantedocumento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParticipanteDocumento IS NULL or (char_length(trim(trailing ' ' from ParticipanteDocumento))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Participantewwds_15_tfparticipanteemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Participantewwds_14_tfparticipanteemail)) ) )
         {
            AddWhere(sWhereString, "(ParticipanteEmail like :lV68Participantewwds_14_tfparticipanteemail)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Participantewwds_15_tfparticipanteemail_sel)) && ! ( StringUtil.StrCmp(AV69Participantewwds_15_tfparticipanteemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParticipanteEmail = ( :AV69Participantewwds_15_tfparticipanteemail_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Participantewwds_15_tfparticipanteemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParticipanteEmail IS NULL or (char_length(trim(trailing ' ' from ParticipanteEmail))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ParticipanteEmail";
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
                     return conditional_P007B2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
               case 1 :
                     return conditional_P007B3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
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
          Object[] prmP007B2;
          prmP007B2 = new Object[] {
          new ParDef("lV55Participantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Participantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Participantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Participantewwds_3_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("lV60Participantewwds_6_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("lV63Participantewwds_9_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("AV64Participantewwds_10_tfparticipanteid",GXType.Int32,8,0) ,
          new ParDef("AV65Participantewwds_11_tfparticipanteid_to",GXType.Int32,8,0) ,
          new ParDef("lV66Participantewwds_12_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV67Participantewwds_13_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("lV68Participantewwds_14_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV69Participantewwds_15_tfparticipanteemail_sel",GXType.VarChar,100,0)
          };
          Object[] prmP007B3;
          prmP007B3 = new Object[] {
          new ParDef("lV55Participantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Participantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV55Participantewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Participantewwds_3_participantedocumento1",GXType.VarChar,14,0) ,
          new ParDef("lV60Participantewwds_6_participantedocumento2",GXType.VarChar,14,0) ,
          new ParDef("lV63Participantewwds_9_participantedocumento3",GXType.VarChar,14,0) ,
          new ParDef("AV64Participantewwds_10_tfparticipanteid",GXType.Int32,8,0) ,
          new ParDef("AV65Participantewwds_11_tfparticipanteid_to",GXType.Int32,8,0) ,
          new ParDef("lV66Participantewwds_12_tfparticipantedocumento",GXType.VarChar,14,0) ,
          new ParDef("AV67Participantewwds_13_tfparticipantedocumento_sel",GXType.VarChar,14,0) ,
          new ParDef("lV68Participantewwds_14_tfparticipanteemail",GXType.VarChar,100,0) ,
          new ParDef("AV69Participantewwds_15_tfparticipanteemail_sel",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

}
