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
   public class servidorsmtpwwgetfilterdata : GXProcedure
   {
      public servidorsmtpwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public servidorsmtpwwgetfilterdata( IGxContext context )
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_SERVIDORSMTPSERVER") == 0 )
         {
            /* Execute user subroutine: 'LOADSERVIDORSMTPSERVEROPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_SERVIDORSMTPPORTA") == 0 )
         {
            /* Execute user subroutine: 'LOADSERVIDORSMTPPORTAOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_SERVIDORSMTPEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADSERVIDORSMTPEMAILOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_SERVIDORSMTPUSUARIO") == 0 )
         {
            /* Execute user subroutine: 'LOADSERVIDORSMTPUSUARIOOPTIONS' */
            S151 ();
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
         if ( StringUtil.StrCmp(AV29Session.Get("ServidorSMTPWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ServidorSMTPWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("ServidorSMTPWWGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV40FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPSERVER") == 0 )
            {
               AV10TFServidorSMTPServer = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPSERVER_SEL") == 0 )
            {
               AV11TFServidorSMTPServer_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPPORTA") == 0 )
            {
               AV12TFServidorSMTPPorta = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPPORTA_SEL") == 0 )
            {
               AV13TFServidorSMTPPorta_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPEMAIL") == 0 )
            {
               AV14TFServidorSMTPEmail = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPEMAIL_SEL") == 0 )
            {
               AV15TFServidorSMTPEmail_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPUSUARIO") == 0 )
            {
               AV16TFServidorSMTPUsuario = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFSERVIDORSMTPUSUARIO_SEL") == 0 )
            {
               AV17TFServidorSMTPUsuario_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV41DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "SERVIDORSMTPSERVER") == 0 )
            {
               AV42DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV43ServidorSMTPServer1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "SERVIDORSMTPSERVER") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV47ServidorSMTPServer2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV48DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV49DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV49DynamicFiltersSelector3, "SERVIDORSMTPSERVER") == 0 )
                  {
                     AV50DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV51ServidorSMTPServer3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSERVIDORSMTPSERVEROPTIONS' Routine */
         returnInSub = false;
         AV10TFServidorSMTPServer = AV18SearchTxt;
         AV11TFServidorSMTPServer_Sel = "";
         AV54Servidorsmtpwwds_1_filterfulltext = AV40FilterFullText;
         AV55Servidorsmtpwwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV57Servidorsmtpwwds_4_servidorsmtpserver1 = AV43ServidorSMTPServer1;
         AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV59Servidorsmtpwwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV61Servidorsmtpwwds_8_servidorsmtpserver2 = AV47ServidorSMTPServer2;
         AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV63Servidorsmtpwwds_10_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV65Servidorsmtpwwds_12_servidorsmtpserver3 = AV51ServidorSMTPServer3;
         AV66Servidorsmtpwwds_13_tfservidorsmtpserver = AV10TFServidorSMTPServer;
         AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel = AV11TFServidorSMTPServer_Sel;
         AV68Servidorsmtpwwds_15_tfservidorsmtpporta = AV12TFServidorSMTPPorta;
         AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel = AV13TFServidorSMTPPorta_Sel;
         AV70Servidorsmtpwwds_17_tfservidorsmtpemail = AV14TFServidorSMTPEmail;
         AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel = AV15TFServidorSMTPEmail_Sel;
         AV72Servidorsmtpwwds_19_tfservidorsmtpusuario = AV16TFServidorSMTPUsuario;
         AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = AV17TFServidorSMTPUsuario_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Servidorsmtpwwds_1_filterfulltext ,
                                              AV55Servidorsmtpwwds_2_dynamicfiltersselector1 ,
                                              AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 ,
                                              AV57Servidorsmtpwwds_4_servidorsmtpserver1 ,
                                              AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 ,
                                              AV59Servidorsmtpwwds_6_dynamicfiltersselector2 ,
                                              AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 ,
                                              AV61Servidorsmtpwwds_8_servidorsmtpserver2 ,
                                              AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 ,
                                              AV63Servidorsmtpwwds_10_dynamicfiltersselector3 ,
                                              AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 ,
                                              AV65Servidorsmtpwwds_12_servidorsmtpserver3 ,
                                              AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel ,
                                              AV66Servidorsmtpwwds_13_tfservidorsmtpserver ,
                                              AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel ,
                                              AV68Servidorsmtpwwds_15_tfservidorsmtpporta ,
                                              AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel ,
                                              AV70Servidorsmtpwwds_17_tfservidorsmtpemail ,
                                              AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ,
                                              AV72Servidorsmtpwwds_19_tfservidorsmtpusuario ,
                                              A159ServidorSMTPServer ,
                                              A160ServidorSMTPPorta ,
                                              A161ServidorSMTPEmail ,
                                              A163ServidorSMTPUsuario } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV57Servidorsmtpwwds_4_servidorsmtpserver1 = StringUtil.Concat( StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1), "%", "");
         lV57Servidorsmtpwwds_4_servidorsmtpserver1 = StringUtil.Concat( StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1), "%", "");
         lV61Servidorsmtpwwds_8_servidorsmtpserver2 = StringUtil.Concat( StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2), "%", "");
         lV61Servidorsmtpwwds_8_servidorsmtpserver2 = StringUtil.Concat( StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2), "%", "");
         lV65Servidorsmtpwwds_12_servidorsmtpserver3 = StringUtil.Concat( StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3), "%", "");
         lV65Servidorsmtpwwds_12_servidorsmtpserver3 = StringUtil.Concat( StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3), "%", "");
         lV66Servidorsmtpwwds_13_tfservidorsmtpserver = StringUtil.Concat( StringUtil.RTrim( AV66Servidorsmtpwwds_13_tfservidorsmtpserver), "%", "");
         lV68Servidorsmtpwwds_15_tfservidorsmtpporta = StringUtil.Concat( StringUtil.RTrim( AV68Servidorsmtpwwds_15_tfservidorsmtpporta), "%", "");
         lV70Servidorsmtpwwds_17_tfservidorsmtpemail = StringUtil.Concat( StringUtil.RTrim( AV70Servidorsmtpwwds_17_tfservidorsmtpemail), "%", "");
         lV72Servidorsmtpwwds_19_tfservidorsmtpusuario = StringUtil.Concat( StringUtil.RTrim( AV72Servidorsmtpwwds_19_tfservidorsmtpusuario), "%", "");
         /* Using cursor P008E2 */
         pr_default.execute(0, new Object[] {lV54Servidorsmtpwwds_1_filterfulltext, lV54Servidorsmtpwwds_1_filterfulltext, lV54Servidorsmtpwwds_1_filterfulltext, lV54Servidorsmtpwwds_1_filterfulltext, lV57Servidorsmtpwwds_4_servidorsmtpserver1, lV57Servidorsmtpwwds_4_servidorsmtpserver1, lV61Servidorsmtpwwds_8_servidorsmtpserver2, lV61Servidorsmtpwwds_8_servidorsmtpserver2, lV65Servidorsmtpwwds_12_servidorsmtpserver3, lV65Servidorsmtpwwds_12_servidorsmtpserver3, lV66Servidorsmtpwwds_13_tfservidorsmtpserver, AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel, lV68Servidorsmtpwwds_15_tfservidorsmtpporta, AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel, lV70Servidorsmtpwwds_17_tfservidorsmtpemail, AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel, lV72Servidorsmtpwwds_19_tfservidorsmtpusuario, AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK8E2 = false;
            A159ServidorSMTPServer = P008E2_A159ServidorSMTPServer[0];
            n159ServidorSMTPServer = P008E2_n159ServidorSMTPServer[0];
            A163ServidorSMTPUsuario = P008E2_A163ServidorSMTPUsuario[0];
            n163ServidorSMTPUsuario = P008E2_n163ServidorSMTPUsuario[0];
            A161ServidorSMTPEmail = P008E2_A161ServidorSMTPEmail[0];
            n161ServidorSMTPEmail = P008E2_n161ServidorSMTPEmail[0];
            A160ServidorSMTPPorta = P008E2_A160ServidorSMTPPorta[0];
            n160ServidorSMTPPorta = P008E2_n160ServidorSMTPPorta[0];
            A158ServidorSMTPId = P008E2_A158ServidorSMTPId[0];
            AV28count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P008E2_A159ServidorSMTPServer[0], A159ServidorSMTPServer) == 0 ) )
            {
               BRK8E2 = false;
               A158ServidorSMTPId = P008E2_A158ServidorSMTPId[0];
               AV28count = (long)(AV28count+1);
               BRK8E2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A159ServidorSMTPServer)) ? "<#Empty#>" : A159ServidorSMTPServer);
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
            if ( ! BRK8E2 )
            {
               BRK8E2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSERVIDORSMTPPORTAOPTIONS' Routine */
         returnInSub = false;
         AV12TFServidorSMTPPorta = AV18SearchTxt;
         AV13TFServidorSMTPPorta_Sel = "";
         AV54Servidorsmtpwwds_1_filterfulltext = AV40FilterFullText;
         AV55Servidorsmtpwwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV57Servidorsmtpwwds_4_servidorsmtpserver1 = AV43ServidorSMTPServer1;
         AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV59Servidorsmtpwwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV61Servidorsmtpwwds_8_servidorsmtpserver2 = AV47ServidorSMTPServer2;
         AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV63Servidorsmtpwwds_10_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV65Servidorsmtpwwds_12_servidorsmtpserver3 = AV51ServidorSMTPServer3;
         AV66Servidorsmtpwwds_13_tfservidorsmtpserver = AV10TFServidorSMTPServer;
         AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel = AV11TFServidorSMTPServer_Sel;
         AV68Servidorsmtpwwds_15_tfservidorsmtpporta = AV12TFServidorSMTPPorta;
         AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel = AV13TFServidorSMTPPorta_Sel;
         AV70Servidorsmtpwwds_17_tfservidorsmtpemail = AV14TFServidorSMTPEmail;
         AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel = AV15TFServidorSMTPEmail_Sel;
         AV72Servidorsmtpwwds_19_tfservidorsmtpusuario = AV16TFServidorSMTPUsuario;
         AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = AV17TFServidorSMTPUsuario_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54Servidorsmtpwwds_1_filterfulltext ,
                                              AV55Servidorsmtpwwds_2_dynamicfiltersselector1 ,
                                              AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 ,
                                              AV57Servidorsmtpwwds_4_servidorsmtpserver1 ,
                                              AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 ,
                                              AV59Servidorsmtpwwds_6_dynamicfiltersselector2 ,
                                              AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 ,
                                              AV61Servidorsmtpwwds_8_servidorsmtpserver2 ,
                                              AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 ,
                                              AV63Servidorsmtpwwds_10_dynamicfiltersselector3 ,
                                              AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 ,
                                              AV65Servidorsmtpwwds_12_servidorsmtpserver3 ,
                                              AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel ,
                                              AV66Servidorsmtpwwds_13_tfservidorsmtpserver ,
                                              AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel ,
                                              AV68Servidorsmtpwwds_15_tfservidorsmtpporta ,
                                              AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel ,
                                              AV70Servidorsmtpwwds_17_tfservidorsmtpemail ,
                                              AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ,
                                              AV72Servidorsmtpwwds_19_tfservidorsmtpusuario ,
                                              A159ServidorSMTPServer ,
                                              A160ServidorSMTPPorta ,
                                              A161ServidorSMTPEmail ,
                                              A163ServidorSMTPUsuario } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV57Servidorsmtpwwds_4_servidorsmtpserver1 = StringUtil.Concat( StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1), "%", "");
         lV57Servidorsmtpwwds_4_servidorsmtpserver1 = StringUtil.Concat( StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1), "%", "");
         lV61Servidorsmtpwwds_8_servidorsmtpserver2 = StringUtil.Concat( StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2), "%", "");
         lV61Servidorsmtpwwds_8_servidorsmtpserver2 = StringUtil.Concat( StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2), "%", "");
         lV65Servidorsmtpwwds_12_servidorsmtpserver3 = StringUtil.Concat( StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3), "%", "");
         lV65Servidorsmtpwwds_12_servidorsmtpserver3 = StringUtil.Concat( StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3), "%", "");
         lV66Servidorsmtpwwds_13_tfservidorsmtpserver = StringUtil.Concat( StringUtil.RTrim( AV66Servidorsmtpwwds_13_tfservidorsmtpserver), "%", "");
         lV68Servidorsmtpwwds_15_tfservidorsmtpporta = StringUtil.Concat( StringUtil.RTrim( AV68Servidorsmtpwwds_15_tfservidorsmtpporta), "%", "");
         lV70Servidorsmtpwwds_17_tfservidorsmtpemail = StringUtil.Concat( StringUtil.RTrim( AV70Servidorsmtpwwds_17_tfservidorsmtpemail), "%", "");
         lV72Servidorsmtpwwds_19_tfservidorsmtpusuario = StringUtil.Concat( StringUtil.RTrim( AV72Servidorsmtpwwds_19_tfservidorsmtpusuario), "%", "");
         /* Using cursor P008E3 */
         pr_default.execute(1, new Object[] {lV54Servidorsmtpwwds_1_filterfulltext, lV54Servidorsmtpwwds_1_filterfulltext, lV54Servidorsmtpwwds_1_filterfulltext, lV54Servidorsmtpwwds_1_filterfulltext, lV57Servidorsmtpwwds_4_servidorsmtpserver1, lV57Servidorsmtpwwds_4_servidorsmtpserver1, lV61Servidorsmtpwwds_8_servidorsmtpserver2, lV61Servidorsmtpwwds_8_servidorsmtpserver2, lV65Servidorsmtpwwds_12_servidorsmtpserver3, lV65Servidorsmtpwwds_12_servidorsmtpserver3, lV66Servidorsmtpwwds_13_tfservidorsmtpserver, AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel, lV68Servidorsmtpwwds_15_tfservidorsmtpporta, AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel, lV70Servidorsmtpwwds_17_tfservidorsmtpemail, AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel, lV72Servidorsmtpwwds_19_tfservidorsmtpusuario, AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK8E4 = false;
            A160ServidorSMTPPorta = P008E3_A160ServidorSMTPPorta[0];
            n160ServidorSMTPPorta = P008E3_n160ServidorSMTPPorta[0];
            A163ServidorSMTPUsuario = P008E3_A163ServidorSMTPUsuario[0];
            n163ServidorSMTPUsuario = P008E3_n163ServidorSMTPUsuario[0];
            A161ServidorSMTPEmail = P008E3_A161ServidorSMTPEmail[0];
            n161ServidorSMTPEmail = P008E3_n161ServidorSMTPEmail[0];
            A159ServidorSMTPServer = P008E3_A159ServidorSMTPServer[0];
            n159ServidorSMTPServer = P008E3_n159ServidorSMTPServer[0];
            A158ServidorSMTPId = P008E3_A158ServidorSMTPId[0];
            AV28count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P008E3_A160ServidorSMTPPorta[0], A160ServidorSMTPPorta) == 0 ) )
            {
               BRK8E4 = false;
               A158ServidorSMTPId = P008E3_A158ServidorSMTPId[0];
               AV28count = (long)(AV28count+1);
               BRK8E4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A160ServidorSMTPPorta)) ? "<#Empty#>" : A160ServidorSMTPPorta);
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
            if ( ! BRK8E4 )
            {
               BRK8E4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSERVIDORSMTPEMAILOPTIONS' Routine */
         returnInSub = false;
         AV14TFServidorSMTPEmail = AV18SearchTxt;
         AV15TFServidorSMTPEmail_Sel = "";
         AV54Servidorsmtpwwds_1_filterfulltext = AV40FilterFullText;
         AV55Servidorsmtpwwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV57Servidorsmtpwwds_4_servidorsmtpserver1 = AV43ServidorSMTPServer1;
         AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV59Servidorsmtpwwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV61Servidorsmtpwwds_8_servidorsmtpserver2 = AV47ServidorSMTPServer2;
         AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV63Servidorsmtpwwds_10_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV65Servidorsmtpwwds_12_servidorsmtpserver3 = AV51ServidorSMTPServer3;
         AV66Servidorsmtpwwds_13_tfservidorsmtpserver = AV10TFServidorSMTPServer;
         AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel = AV11TFServidorSMTPServer_Sel;
         AV68Servidorsmtpwwds_15_tfservidorsmtpporta = AV12TFServidorSMTPPorta;
         AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel = AV13TFServidorSMTPPorta_Sel;
         AV70Servidorsmtpwwds_17_tfservidorsmtpemail = AV14TFServidorSMTPEmail;
         AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel = AV15TFServidorSMTPEmail_Sel;
         AV72Servidorsmtpwwds_19_tfservidorsmtpusuario = AV16TFServidorSMTPUsuario;
         AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = AV17TFServidorSMTPUsuario_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV54Servidorsmtpwwds_1_filterfulltext ,
                                              AV55Servidorsmtpwwds_2_dynamicfiltersselector1 ,
                                              AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 ,
                                              AV57Servidorsmtpwwds_4_servidorsmtpserver1 ,
                                              AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 ,
                                              AV59Servidorsmtpwwds_6_dynamicfiltersselector2 ,
                                              AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 ,
                                              AV61Servidorsmtpwwds_8_servidorsmtpserver2 ,
                                              AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 ,
                                              AV63Servidorsmtpwwds_10_dynamicfiltersselector3 ,
                                              AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 ,
                                              AV65Servidorsmtpwwds_12_servidorsmtpserver3 ,
                                              AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel ,
                                              AV66Servidorsmtpwwds_13_tfservidorsmtpserver ,
                                              AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel ,
                                              AV68Servidorsmtpwwds_15_tfservidorsmtpporta ,
                                              AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel ,
                                              AV70Servidorsmtpwwds_17_tfservidorsmtpemail ,
                                              AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ,
                                              AV72Servidorsmtpwwds_19_tfservidorsmtpusuario ,
                                              A159ServidorSMTPServer ,
                                              A160ServidorSMTPPorta ,
                                              A161ServidorSMTPEmail ,
                                              A163ServidorSMTPUsuario } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV57Servidorsmtpwwds_4_servidorsmtpserver1 = StringUtil.Concat( StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1), "%", "");
         lV57Servidorsmtpwwds_4_servidorsmtpserver1 = StringUtil.Concat( StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1), "%", "");
         lV61Servidorsmtpwwds_8_servidorsmtpserver2 = StringUtil.Concat( StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2), "%", "");
         lV61Servidorsmtpwwds_8_servidorsmtpserver2 = StringUtil.Concat( StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2), "%", "");
         lV65Servidorsmtpwwds_12_servidorsmtpserver3 = StringUtil.Concat( StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3), "%", "");
         lV65Servidorsmtpwwds_12_servidorsmtpserver3 = StringUtil.Concat( StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3), "%", "");
         lV66Servidorsmtpwwds_13_tfservidorsmtpserver = StringUtil.Concat( StringUtil.RTrim( AV66Servidorsmtpwwds_13_tfservidorsmtpserver), "%", "");
         lV68Servidorsmtpwwds_15_tfservidorsmtpporta = StringUtil.Concat( StringUtil.RTrim( AV68Servidorsmtpwwds_15_tfservidorsmtpporta), "%", "");
         lV70Servidorsmtpwwds_17_tfservidorsmtpemail = StringUtil.Concat( StringUtil.RTrim( AV70Servidorsmtpwwds_17_tfservidorsmtpemail), "%", "");
         lV72Servidorsmtpwwds_19_tfservidorsmtpusuario = StringUtil.Concat( StringUtil.RTrim( AV72Servidorsmtpwwds_19_tfservidorsmtpusuario), "%", "");
         /* Using cursor P008E4 */
         pr_default.execute(2, new Object[] {lV54Servidorsmtpwwds_1_filterfulltext, lV54Servidorsmtpwwds_1_filterfulltext, lV54Servidorsmtpwwds_1_filterfulltext, lV54Servidorsmtpwwds_1_filterfulltext, lV57Servidorsmtpwwds_4_servidorsmtpserver1, lV57Servidorsmtpwwds_4_servidorsmtpserver1, lV61Servidorsmtpwwds_8_servidorsmtpserver2, lV61Servidorsmtpwwds_8_servidorsmtpserver2, lV65Servidorsmtpwwds_12_servidorsmtpserver3, lV65Servidorsmtpwwds_12_servidorsmtpserver3, lV66Servidorsmtpwwds_13_tfservidorsmtpserver, AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel, lV68Servidorsmtpwwds_15_tfservidorsmtpporta, AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel, lV70Servidorsmtpwwds_17_tfservidorsmtpemail, AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel, lV72Servidorsmtpwwds_19_tfservidorsmtpusuario, AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK8E6 = false;
            A161ServidorSMTPEmail = P008E4_A161ServidorSMTPEmail[0];
            n161ServidorSMTPEmail = P008E4_n161ServidorSMTPEmail[0];
            A163ServidorSMTPUsuario = P008E4_A163ServidorSMTPUsuario[0];
            n163ServidorSMTPUsuario = P008E4_n163ServidorSMTPUsuario[0];
            A160ServidorSMTPPorta = P008E4_A160ServidorSMTPPorta[0];
            n160ServidorSMTPPorta = P008E4_n160ServidorSMTPPorta[0];
            A159ServidorSMTPServer = P008E4_A159ServidorSMTPServer[0];
            n159ServidorSMTPServer = P008E4_n159ServidorSMTPServer[0];
            A158ServidorSMTPId = P008E4_A158ServidorSMTPId[0];
            AV28count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P008E4_A161ServidorSMTPEmail[0], A161ServidorSMTPEmail) == 0 ) )
            {
               BRK8E6 = false;
               A158ServidorSMTPId = P008E4_A158ServidorSMTPId[0];
               AV28count = (long)(AV28count+1);
               BRK8E6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A161ServidorSMTPEmail)) ? "<#Empty#>" : A161ServidorSMTPEmail);
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
            if ( ! BRK8E6 )
            {
               BRK8E6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSERVIDORSMTPUSUARIOOPTIONS' Routine */
         returnInSub = false;
         AV16TFServidorSMTPUsuario = AV18SearchTxt;
         AV17TFServidorSMTPUsuario_Sel = "";
         AV54Servidorsmtpwwds_1_filterfulltext = AV40FilterFullText;
         AV55Servidorsmtpwwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV57Servidorsmtpwwds_4_servidorsmtpserver1 = AV43ServidorSMTPServer1;
         AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV59Servidorsmtpwwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV61Servidorsmtpwwds_8_servidorsmtpserver2 = AV47ServidorSMTPServer2;
         AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV63Servidorsmtpwwds_10_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV65Servidorsmtpwwds_12_servidorsmtpserver3 = AV51ServidorSMTPServer3;
         AV66Servidorsmtpwwds_13_tfservidorsmtpserver = AV10TFServidorSMTPServer;
         AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel = AV11TFServidorSMTPServer_Sel;
         AV68Servidorsmtpwwds_15_tfservidorsmtpporta = AV12TFServidorSMTPPorta;
         AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel = AV13TFServidorSMTPPorta_Sel;
         AV70Servidorsmtpwwds_17_tfservidorsmtpemail = AV14TFServidorSMTPEmail;
         AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel = AV15TFServidorSMTPEmail_Sel;
         AV72Servidorsmtpwwds_19_tfservidorsmtpusuario = AV16TFServidorSMTPUsuario;
         AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = AV17TFServidorSMTPUsuario_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV54Servidorsmtpwwds_1_filterfulltext ,
                                              AV55Servidorsmtpwwds_2_dynamicfiltersselector1 ,
                                              AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 ,
                                              AV57Servidorsmtpwwds_4_servidorsmtpserver1 ,
                                              AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 ,
                                              AV59Servidorsmtpwwds_6_dynamicfiltersselector2 ,
                                              AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 ,
                                              AV61Servidorsmtpwwds_8_servidorsmtpserver2 ,
                                              AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 ,
                                              AV63Servidorsmtpwwds_10_dynamicfiltersselector3 ,
                                              AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 ,
                                              AV65Servidorsmtpwwds_12_servidorsmtpserver3 ,
                                              AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel ,
                                              AV66Servidorsmtpwwds_13_tfservidorsmtpserver ,
                                              AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel ,
                                              AV68Servidorsmtpwwds_15_tfservidorsmtpporta ,
                                              AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel ,
                                              AV70Servidorsmtpwwds_17_tfservidorsmtpemail ,
                                              AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ,
                                              AV72Servidorsmtpwwds_19_tfservidorsmtpusuario ,
                                              A159ServidorSMTPServer ,
                                              A160ServidorSMTPPorta ,
                                              A161ServidorSMTPEmail ,
                                              A163ServidorSMTPUsuario } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV54Servidorsmtpwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext), "%", "");
         lV57Servidorsmtpwwds_4_servidorsmtpserver1 = StringUtil.Concat( StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1), "%", "");
         lV57Servidorsmtpwwds_4_servidorsmtpserver1 = StringUtil.Concat( StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1), "%", "");
         lV61Servidorsmtpwwds_8_servidorsmtpserver2 = StringUtil.Concat( StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2), "%", "");
         lV61Servidorsmtpwwds_8_servidorsmtpserver2 = StringUtil.Concat( StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2), "%", "");
         lV65Servidorsmtpwwds_12_servidorsmtpserver3 = StringUtil.Concat( StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3), "%", "");
         lV65Servidorsmtpwwds_12_servidorsmtpserver3 = StringUtil.Concat( StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3), "%", "");
         lV66Servidorsmtpwwds_13_tfservidorsmtpserver = StringUtil.Concat( StringUtil.RTrim( AV66Servidorsmtpwwds_13_tfservidorsmtpserver), "%", "");
         lV68Servidorsmtpwwds_15_tfservidorsmtpporta = StringUtil.Concat( StringUtil.RTrim( AV68Servidorsmtpwwds_15_tfservidorsmtpporta), "%", "");
         lV70Servidorsmtpwwds_17_tfservidorsmtpemail = StringUtil.Concat( StringUtil.RTrim( AV70Servidorsmtpwwds_17_tfservidorsmtpemail), "%", "");
         lV72Servidorsmtpwwds_19_tfservidorsmtpusuario = StringUtil.Concat( StringUtil.RTrim( AV72Servidorsmtpwwds_19_tfservidorsmtpusuario), "%", "");
         /* Using cursor P008E5 */
         pr_default.execute(3, new Object[] {lV54Servidorsmtpwwds_1_filterfulltext, lV54Servidorsmtpwwds_1_filterfulltext, lV54Servidorsmtpwwds_1_filterfulltext, lV54Servidorsmtpwwds_1_filterfulltext, lV57Servidorsmtpwwds_4_servidorsmtpserver1, lV57Servidorsmtpwwds_4_servidorsmtpserver1, lV61Servidorsmtpwwds_8_servidorsmtpserver2, lV61Servidorsmtpwwds_8_servidorsmtpserver2, lV65Servidorsmtpwwds_12_servidorsmtpserver3, lV65Servidorsmtpwwds_12_servidorsmtpserver3, lV66Servidorsmtpwwds_13_tfservidorsmtpserver, AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel, lV68Servidorsmtpwwds_15_tfservidorsmtpporta, AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel, lV70Servidorsmtpwwds_17_tfservidorsmtpemail, AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel, lV72Servidorsmtpwwds_19_tfservidorsmtpusuario, AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK8E8 = false;
            A163ServidorSMTPUsuario = P008E5_A163ServidorSMTPUsuario[0];
            n163ServidorSMTPUsuario = P008E5_n163ServidorSMTPUsuario[0];
            A161ServidorSMTPEmail = P008E5_A161ServidorSMTPEmail[0];
            n161ServidorSMTPEmail = P008E5_n161ServidorSMTPEmail[0];
            A160ServidorSMTPPorta = P008E5_A160ServidorSMTPPorta[0];
            n160ServidorSMTPPorta = P008E5_n160ServidorSMTPPorta[0];
            A159ServidorSMTPServer = P008E5_A159ServidorSMTPServer[0];
            n159ServidorSMTPServer = P008E5_n159ServidorSMTPServer[0];
            A158ServidorSMTPId = P008E5_A158ServidorSMTPId[0];
            AV28count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P008E5_A163ServidorSMTPUsuario[0], A163ServidorSMTPUsuario) == 0 ) )
            {
               BRK8E8 = false;
               A158ServidorSMTPId = P008E5_A158ServidorSMTPId[0];
               AV28count = (long)(AV28count+1);
               BRK8E8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV19SkipItems) )
            {
               AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A163ServidorSMTPUsuario)) ? "<#Empty#>" : A163ServidorSMTPUsuario);
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
            if ( ! BRK8E8 )
            {
               BRK8E8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV10TFServidorSMTPServer = "";
         AV11TFServidorSMTPServer_Sel = "";
         AV12TFServidorSMTPPorta = "";
         AV13TFServidorSMTPPorta_Sel = "";
         AV14TFServidorSMTPEmail = "";
         AV15TFServidorSMTPEmail_Sel = "";
         AV16TFServidorSMTPUsuario = "";
         AV17TFServidorSMTPUsuario_Sel = "";
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV41DynamicFiltersSelector1 = "";
         AV43ServidorSMTPServer1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV47ServidorSMTPServer2 = "";
         AV49DynamicFiltersSelector3 = "";
         AV51ServidorSMTPServer3 = "";
         AV54Servidorsmtpwwds_1_filterfulltext = "";
         AV55Servidorsmtpwwds_2_dynamicfiltersselector1 = "";
         AV57Servidorsmtpwwds_4_servidorsmtpserver1 = "";
         AV59Servidorsmtpwwds_6_dynamicfiltersselector2 = "";
         AV61Servidorsmtpwwds_8_servidorsmtpserver2 = "";
         AV63Servidorsmtpwwds_10_dynamicfiltersselector3 = "";
         AV65Servidorsmtpwwds_12_servidorsmtpserver3 = "";
         AV66Servidorsmtpwwds_13_tfservidorsmtpserver = "";
         AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel = "";
         AV68Servidorsmtpwwds_15_tfservidorsmtpporta = "";
         AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel = "";
         AV70Servidorsmtpwwds_17_tfservidorsmtpemail = "";
         AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel = "";
         AV72Servidorsmtpwwds_19_tfservidorsmtpusuario = "";
         AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel = "";
         lV54Servidorsmtpwwds_1_filterfulltext = "";
         lV57Servidorsmtpwwds_4_servidorsmtpserver1 = "";
         lV61Servidorsmtpwwds_8_servidorsmtpserver2 = "";
         lV65Servidorsmtpwwds_12_servidorsmtpserver3 = "";
         lV66Servidorsmtpwwds_13_tfservidorsmtpserver = "";
         lV68Servidorsmtpwwds_15_tfservidorsmtpporta = "";
         lV70Servidorsmtpwwds_17_tfservidorsmtpemail = "";
         lV72Servidorsmtpwwds_19_tfservidorsmtpusuario = "";
         A159ServidorSMTPServer = "";
         A160ServidorSMTPPorta = "";
         A161ServidorSMTPEmail = "";
         A163ServidorSMTPUsuario = "";
         P008E2_A159ServidorSMTPServer = new string[] {""} ;
         P008E2_n159ServidorSMTPServer = new bool[] {false} ;
         P008E2_A163ServidorSMTPUsuario = new string[] {""} ;
         P008E2_n163ServidorSMTPUsuario = new bool[] {false} ;
         P008E2_A161ServidorSMTPEmail = new string[] {""} ;
         P008E2_n161ServidorSMTPEmail = new bool[] {false} ;
         P008E2_A160ServidorSMTPPorta = new string[] {""} ;
         P008E2_n160ServidorSMTPPorta = new bool[] {false} ;
         P008E2_A158ServidorSMTPId = new short[1] ;
         AV23Option = "";
         P008E3_A160ServidorSMTPPorta = new string[] {""} ;
         P008E3_n160ServidorSMTPPorta = new bool[] {false} ;
         P008E3_A163ServidorSMTPUsuario = new string[] {""} ;
         P008E3_n163ServidorSMTPUsuario = new bool[] {false} ;
         P008E3_A161ServidorSMTPEmail = new string[] {""} ;
         P008E3_n161ServidorSMTPEmail = new bool[] {false} ;
         P008E3_A159ServidorSMTPServer = new string[] {""} ;
         P008E3_n159ServidorSMTPServer = new bool[] {false} ;
         P008E3_A158ServidorSMTPId = new short[1] ;
         P008E4_A161ServidorSMTPEmail = new string[] {""} ;
         P008E4_n161ServidorSMTPEmail = new bool[] {false} ;
         P008E4_A163ServidorSMTPUsuario = new string[] {""} ;
         P008E4_n163ServidorSMTPUsuario = new bool[] {false} ;
         P008E4_A160ServidorSMTPPorta = new string[] {""} ;
         P008E4_n160ServidorSMTPPorta = new bool[] {false} ;
         P008E4_A159ServidorSMTPServer = new string[] {""} ;
         P008E4_n159ServidorSMTPServer = new bool[] {false} ;
         P008E4_A158ServidorSMTPId = new short[1] ;
         P008E5_A163ServidorSMTPUsuario = new string[] {""} ;
         P008E5_n163ServidorSMTPUsuario = new bool[] {false} ;
         P008E5_A161ServidorSMTPEmail = new string[] {""} ;
         P008E5_n161ServidorSMTPEmail = new bool[] {false} ;
         P008E5_A160ServidorSMTPPorta = new string[] {""} ;
         P008E5_n160ServidorSMTPPorta = new bool[] {false} ;
         P008E5_A159ServidorSMTPServer = new string[] {""} ;
         P008E5_n159ServidorSMTPServer = new bool[] {false} ;
         P008E5_A158ServidorSMTPId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.servidorsmtpwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P008E2_A159ServidorSMTPServer, P008E2_n159ServidorSMTPServer, P008E2_A163ServidorSMTPUsuario, P008E2_n163ServidorSMTPUsuario, P008E2_A161ServidorSMTPEmail, P008E2_n161ServidorSMTPEmail, P008E2_A160ServidorSMTPPorta, P008E2_n160ServidorSMTPPorta, P008E2_A158ServidorSMTPId
               }
               , new Object[] {
               P008E3_A160ServidorSMTPPorta, P008E3_n160ServidorSMTPPorta, P008E3_A163ServidorSMTPUsuario, P008E3_n163ServidorSMTPUsuario, P008E3_A161ServidorSMTPEmail, P008E3_n161ServidorSMTPEmail, P008E3_A159ServidorSMTPServer, P008E3_n159ServidorSMTPServer, P008E3_A158ServidorSMTPId
               }
               , new Object[] {
               P008E4_A161ServidorSMTPEmail, P008E4_n161ServidorSMTPEmail, P008E4_A163ServidorSMTPUsuario, P008E4_n163ServidorSMTPUsuario, P008E4_A160ServidorSMTPPorta, P008E4_n160ServidorSMTPPorta, P008E4_A159ServidorSMTPServer, P008E4_n159ServidorSMTPServer, P008E4_A158ServidorSMTPId
               }
               , new Object[] {
               P008E5_A163ServidorSMTPUsuario, P008E5_n163ServidorSMTPUsuario, P008E5_A161ServidorSMTPEmail, P008E5_n161ServidorSMTPEmail, P008E5_A160ServidorSMTPPorta, P008E5_n160ServidorSMTPPorta, P008E5_A159ServidorSMTPServer, P008E5_n159ServidorSMTPServer, P008E5_A158ServidorSMTPId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21MaxItems ;
      private short AV20PageIndex ;
      private short AV19SkipItems ;
      private short AV42DynamicFiltersOperator1 ;
      private short AV46DynamicFiltersOperator2 ;
      private short AV50DynamicFiltersOperator3 ;
      private short AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 ;
      private short AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 ;
      private short AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 ;
      private short A158ServidorSMTPId ;
      private int AV52GXV1 ;
      private long AV28count ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV48DynamicFiltersEnabled3 ;
      private bool AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 ;
      private bool AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 ;
      private bool BRK8E2 ;
      private bool n159ServidorSMTPServer ;
      private bool n163ServidorSMTPUsuario ;
      private bool n161ServidorSMTPEmail ;
      private bool n160ServidorSMTPPorta ;
      private bool BRK8E4 ;
      private bool BRK8E6 ;
      private bool BRK8E8 ;
      private string AV37OptionsJson ;
      private string AV38OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV34DDOName ;
      private string AV35SearchTxtParms ;
      private string AV36SearchTxtTo ;
      private string AV18SearchTxt ;
      private string AV40FilterFullText ;
      private string AV10TFServidorSMTPServer ;
      private string AV11TFServidorSMTPServer_Sel ;
      private string AV12TFServidorSMTPPorta ;
      private string AV13TFServidorSMTPPorta_Sel ;
      private string AV14TFServidorSMTPEmail ;
      private string AV15TFServidorSMTPEmail_Sel ;
      private string AV16TFServidorSMTPUsuario ;
      private string AV17TFServidorSMTPUsuario_Sel ;
      private string AV41DynamicFiltersSelector1 ;
      private string AV43ServidorSMTPServer1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV47ServidorSMTPServer2 ;
      private string AV49DynamicFiltersSelector3 ;
      private string AV51ServidorSMTPServer3 ;
      private string AV54Servidorsmtpwwds_1_filterfulltext ;
      private string AV55Servidorsmtpwwds_2_dynamicfiltersselector1 ;
      private string AV57Servidorsmtpwwds_4_servidorsmtpserver1 ;
      private string AV59Servidorsmtpwwds_6_dynamicfiltersselector2 ;
      private string AV61Servidorsmtpwwds_8_servidorsmtpserver2 ;
      private string AV63Servidorsmtpwwds_10_dynamicfiltersselector3 ;
      private string AV65Servidorsmtpwwds_12_servidorsmtpserver3 ;
      private string AV66Servidorsmtpwwds_13_tfservidorsmtpserver ;
      private string AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel ;
      private string AV68Servidorsmtpwwds_15_tfservidorsmtpporta ;
      private string AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel ;
      private string AV70Servidorsmtpwwds_17_tfservidorsmtpemail ;
      private string AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel ;
      private string AV72Servidorsmtpwwds_19_tfservidorsmtpusuario ;
      private string AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ;
      private string lV54Servidorsmtpwwds_1_filterfulltext ;
      private string lV57Servidorsmtpwwds_4_servidorsmtpserver1 ;
      private string lV61Servidorsmtpwwds_8_servidorsmtpserver2 ;
      private string lV65Servidorsmtpwwds_12_servidorsmtpserver3 ;
      private string lV66Servidorsmtpwwds_13_tfservidorsmtpserver ;
      private string lV68Servidorsmtpwwds_15_tfservidorsmtpporta ;
      private string lV70Servidorsmtpwwds_17_tfservidorsmtpemail ;
      private string lV72Servidorsmtpwwds_19_tfservidorsmtpusuario ;
      private string A159ServidorSMTPServer ;
      private string A160ServidorSMTPPorta ;
      private string A161ServidorSMTPEmail ;
      private string A163ServidorSMTPUsuario ;
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
      private string[] P008E2_A159ServidorSMTPServer ;
      private bool[] P008E2_n159ServidorSMTPServer ;
      private string[] P008E2_A163ServidorSMTPUsuario ;
      private bool[] P008E2_n163ServidorSMTPUsuario ;
      private string[] P008E2_A161ServidorSMTPEmail ;
      private bool[] P008E2_n161ServidorSMTPEmail ;
      private string[] P008E2_A160ServidorSMTPPorta ;
      private bool[] P008E2_n160ServidorSMTPPorta ;
      private short[] P008E2_A158ServidorSMTPId ;
      private string[] P008E3_A160ServidorSMTPPorta ;
      private bool[] P008E3_n160ServidorSMTPPorta ;
      private string[] P008E3_A163ServidorSMTPUsuario ;
      private bool[] P008E3_n163ServidorSMTPUsuario ;
      private string[] P008E3_A161ServidorSMTPEmail ;
      private bool[] P008E3_n161ServidorSMTPEmail ;
      private string[] P008E3_A159ServidorSMTPServer ;
      private bool[] P008E3_n159ServidorSMTPServer ;
      private short[] P008E3_A158ServidorSMTPId ;
      private string[] P008E4_A161ServidorSMTPEmail ;
      private bool[] P008E4_n161ServidorSMTPEmail ;
      private string[] P008E4_A163ServidorSMTPUsuario ;
      private bool[] P008E4_n163ServidorSMTPUsuario ;
      private string[] P008E4_A160ServidorSMTPPorta ;
      private bool[] P008E4_n160ServidorSMTPPorta ;
      private string[] P008E4_A159ServidorSMTPServer ;
      private bool[] P008E4_n159ServidorSMTPServer ;
      private short[] P008E4_A158ServidorSMTPId ;
      private string[] P008E5_A163ServidorSMTPUsuario ;
      private bool[] P008E5_n163ServidorSMTPUsuario ;
      private string[] P008E5_A161ServidorSMTPEmail ;
      private bool[] P008E5_n161ServidorSMTPEmail ;
      private string[] P008E5_A160ServidorSMTPPorta ;
      private bool[] P008E5_n160ServidorSMTPPorta ;
      private string[] P008E5_A159ServidorSMTPServer ;
      private bool[] P008E5_n159ServidorSMTPServer ;
      private short[] P008E5_A158ServidorSMTPId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class servidorsmtpwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P008E2( IGxContext context ,
                                             string AV54Servidorsmtpwwds_1_filterfulltext ,
                                             string AV55Servidorsmtpwwds_2_dynamicfiltersselector1 ,
                                             short AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 ,
                                             string AV57Servidorsmtpwwds_4_servidorsmtpserver1 ,
                                             bool AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 ,
                                             string AV59Servidorsmtpwwds_6_dynamicfiltersselector2 ,
                                             short AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 ,
                                             string AV61Servidorsmtpwwds_8_servidorsmtpserver2 ,
                                             bool AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 ,
                                             string AV63Servidorsmtpwwds_10_dynamicfiltersselector3 ,
                                             short AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 ,
                                             string AV65Servidorsmtpwwds_12_servidorsmtpserver3 ,
                                             string AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel ,
                                             string AV66Servidorsmtpwwds_13_tfservidorsmtpserver ,
                                             string AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel ,
                                             string AV68Servidorsmtpwwds_15_tfservidorsmtpporta ,
                                             string AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel ,
                                             string AV70Servidorsmtpwwds_17_tfservidorsmtpemail ,
                                             string AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ,
                                             string AV72Servidorsmtpwwds_19_tfservidorsmtpusuario ,
                                             string A159ServidorSMTPServer ,
                                             string A160ServidorSMTPPorta ,
                                             string A161ServidorSMTPEmail ,
                                             string A163ServidorSMTPUsuario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[18];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT ServidorSMTPServer, ServidorSMTPUsuario, ServidorSMTPEmail, ServidorSMTPPorta, ServidorSMTPId FROM ServidorSMTP";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ServidorSMTPServer like '%' || :lV54Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPPorta like '%' || :lV54Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPEmail like '%' || :lV54Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPUsuario like '%' || :lV54Servidorsmtpwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Servidorsmtpwwds_2_dynamicfiltersselector1, "SERVIDORSMTPSERVER") == 0 ) && ( AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV57Servidorsmtpwwds_4_servidorsmtpserver1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Servidorsmtpwwds_2_dynamicfiltersselector1, "SERVIDORSMTPSERVER") == 0 ) && ( AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV57Servidorsmtpwwds_4_servidorsmtpserver1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Servidorsmtpwwds_6_dynamicfiltersselector2, "SERVIDORSMTPSERVER") == 0 ) && ( AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV61Servidorsmtpwwds_8_servidorsmtpserver2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Servidorsmtpwwds_6_dynamicfiltersselector2, "SERVIDORSMTPSERVER") == 0 ) && ( AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV61Servidorsmtpwwds_8_servidorsmtpserver2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Servidorsmtpwwds_10_dynamicfiltersselector3, "SERVIDORSMTPSERVER") == 0 ) && ( AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV65Servidorsmtpwwds_12_servidorsmtpserver3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Servidorsmtpwwds_10_dynamicfiltersselector3, "SERVIDORSMTPSERVER") == 0 ) && ( AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV65Servidorsmtpwwds_12_servidorsmtpserver3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Servidorsmtpwwds_13_tfservidorsmtpserver)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV66Servidorsmtpwwds_13_tfservidorsmtpserver)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel)) && ! ( StringUtil.StrCmp(AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer = ( :AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel))");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( StringUtil.StrCmp(AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPServer))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Servidorsmtpwwds_15_tfservidorsmtpporta)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta like :lV68Servidorsmtpwwds_15_tfservidorsmtpporta)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel)) && ! ( StringUtil.StrCmp(AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta = ( :AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel))");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( StringUtil.StrCmp(AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPPorta))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Servidorsmtpwwds_17_tfservidorsmtpemail)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail like :lV70Servidorsmtpwwds_17_tfservidorsmtpemail)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel)) && ! ( StringUtil.StrCmp(AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail = ( :AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel))");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( StringUtil.StrCmp(AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Servidorsmtpwwds_19_tfservidorsmtpusuario)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario like :lV72Servidorsmtpwwds_19_tfservidorsmtpusuario)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel)) && ! ( StringUtil.StrCmp(AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario = ( :AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel))");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( StringUtil.StrCmp(AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPUsuario))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ServidorSMTPServer";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P008E3( IGxContext context ,
                                             string AV54Servidorsmtpwwds_1_filterfulltext ,
                                             string AV55Servidorsmtpwwds_2_dynamicfiltersselector1 ,
                                             short AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 ,
                                             string AV57Servidorsmtpwwds_4_servidorsmtpserver1 ,
                                             bool AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 ,
                                             string AV59Servidorsmtpwwds_6_dynamicfiltersselector2 ,
                                             short AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 ,
                                             string AV61Servidorsmtpwwds_8_servidorsmtpserver2 ,
                                             bool AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 ,
                                             string AV63Servidorsmtpwwds_10_dynamicfiltersselector3 ,
                                             short AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 ,
                                             string AV65Servidorsmtpwwds_12_servidorsmtpserver3 ,
                                             string AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel ,
                                             string AV66Servidorsmtpwwds_13_tfservidorsmtpserver ,
                                             string AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel ,
                                             string AV68Servidorsmtpwwds_15_tfservidorsmtpporta ,
                                             string AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel ,
                                             string AV70Servidorsmtpwwds_17_tfservidorsmtpemail ,
                                             string AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ,
                                             string AV72Servidorsmtpwwds_19_tfservidorsmtpusuario ,
                                             string A159ServidorSMTPServer ,
                                             string A160ServidorSMTPPorta ,
                                             string A161ServidorSMTPEmail ,
                                             string A163ServidorSMTPUsuario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT ServidorSMTPPorta, ServidorSMTPUsuario, ServidorSMTPEmail, ServidorSMTPServer, ServidorSMTPId FROM ServidorSMTP";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ServidorSMTPServer like '%' || :lV54Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPPorta like '%' || :lV54Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPEmail like '%' || :lV54Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPUsuario like '%' || :lV54Servidorsmtpwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Servidorsmtpwwds_2_dynamicfiltersselector1, "SERVIDORSMTPSERVER") == 0 ) && ( AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV57Servidorsmtpwwds_4_servidorsmtpserver1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Servidorsmtpwwds_2_dynamicfiltersselector1, "SERVIDORSMTPSERVER") == 0 ) && ( AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV57Servidorsmtpwwds_4_servidorsmtpserver1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Servidorsmtpwwds_6_dynamicfiltersselector2, "SERVIDORSMTPSERVER") == 0 ) && ( AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV61Servidorsmtpwwds_8_servidorsmtpserver2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Servidorsmtpwwds_6_dynamicfiltersselector2, "SERVIDORSMTPSERVER") == 0 ) && ( AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV61Servidorsmtpwwds_8_servidorsmtpserver2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Servidorsmtpwwds_10_dynamicfiltersselector3, "SERVIDORSMTPSERVER") == 0 ) && ( AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV65Servidorsmtpwwds_12_servidorsmtpserver3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Servidorsmtpwwds_10_dynamicfiltersselector3, "SERVIDORSMTPSERVER") == 0 ) && ( AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV65Servidorsmtpwwds_12_servidorsmtpserver3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Servidorsmtpwwds_13_tfservidorsmtpserver)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV66Servidorsmtpwwds_13_tfservidorsmtpserver)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel)) && ! ( StringUtil.StrCmp(AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer = ( :AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel))");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( StringUtil.StrCmp(AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPServer))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Servidorsmtpwwds_15_tfservidorsmtpporta)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta like :lV68Servidorsmtpwwds_15_tfservidorsmtpporta)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel)) && ! ( StringUtil.StrCmp(AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta = ( :AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel))");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( StringUtil.StrCmp(AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPPorta))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Servidorsmtpwwds_17_tfservidorsmtpemail)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail like :lV70Servidorsmtpwwds_17_tfservidorsmtpemail)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel)) && ! ( StringUtil.StrCmp(AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail = ( :AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel))");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( StringUtil.StrCmp(AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Servidorsmtpwwds_19_tfservidorsmtpusuario)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario like :lV72Servidorsmtpwwds_19_tfservidorsmtpusuario)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel)) && ! ( StringUtil.StrCmp(AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario = ( :AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel))");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( StringUtil.StrCmp(AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPUsuario))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ServidorSMTPPorta";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P008E4( IGxContext context ,
                                             string AV54Servidorsmtpwwds_1_filterfulltext ,
                                             string AV55Servidorsmtpwwds_2_dynamicfiltersselector1 ,
                                             short AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 ,
                                             string AV57Servidorsmtpwwds_4_servidorsmtpserver1 ,
                                             bool AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 ,
                                             string AV59Servidorsmtpwwds_6_dynamicfiltersselector2 ,
                                             short AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 ,
                                             string AV61Servidorsmtpwwds_8_servidorsmtpserver2 ,
                                             bool AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 ,
                                             string AV63Servidorsmtpwwds_10_dynamicfiltersselector3 ,
                                             short AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 ,
                                             string AV65Servidorsmtpwwds_12_servidorsmtpserver3 ,
                                             string AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel ,
                                             string AV66Servidorsmtpwwds_13_tfservidorsmtpserver ,
                                             string AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel ,
                                             string AV68Servidorsmtpwwds_15_tfservidorsmtpporta ,
                                             string AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel ,
                                             string AV70Servidorsmtpwwds_17_tfservidorsmtpemail ,
                                             string AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ,
                                             string AV72Servidorsmtpwwds_19_tfservidorsmtpusuario ,
                                             string A159ServidorSMTPServer ,
                                             string A160ServidorSMTPPorta ,
                                             string A161ServidorSMTPEmail ,
                                             string A163ServidorSMTPUsuario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[18];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT ServidorSMTPEmail, ServidorSMTPUsuario, ServidorSMTPPorta, ServidorSMTPServer, ServidorSMTPId FROM ServidorSMTP";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ServidorSMTPServer like '%' || :lV54Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPPorta like '%' || :lV54Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPEmail like '%' || :lV54Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPUsuario like '%' || :lV54Servidorsmtpwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Servidorsmtpwwds_2_dynamicfiltersselector1, "SERVIDORSMTPSERVER") == 0 ) && ( AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV57Servidorsmtpwwds_4_servidorsmtpserver1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Servidorsmtpwwds_2_dynamicfiltersselector1, "SERVIDORSMTPSERVER") == 0 ) && ( AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV57Servidorsmtpwwds_4_servidorsmtpserver1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Servidorsmtpwwds_6_dynamicfiltersselector2, "SERVIDORSMTPSERVER") == 0 ) && ( AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV61Servidorsmtpwwds_8_servidorsmtpserver2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Servidorsmtpwwds_6_dynamicfiltersselector2, "SERVIDORSMTPSERVER") == 0 ) && ( AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV61Servidorsmtpwwds_8_servidorsmtpserver2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Servidorsmtpwwds_10_dynamicfiltersselector3, "SERVIDORSMTPSERVER") == 0 ) && ( AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV65Servidorsmtpwwds_12_servidorsmtpserver3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Servidorsmtpwwds_10_dynamicfiltersselector3, "SERVIDORSMTPSERVER") == 0 ) && ( AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV65Servidorsmtpwwds_12_servidorsmtpserver3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Servidorsmtpwwds_13_tfservidorsmtpserver)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV66Servidorsmtpwwds_13_tfservidorsmtpserver)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel)) && ! ( StringUtil.StrCmp(AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer = ( :AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel))");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( StringUtil.StrCmp(AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPServer))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Servidorsmtpwwds_15_tfservidorsmtpporta)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta like :lV68Servidorsmtpwwds_15_tfservidorsmtpporta)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel)) && ! ( StringUtil.StrCmp(AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta = ( :AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel))");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( StringUtil.StrCmp(AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPPorta))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Servidorsmtpwwds_17_tfservidorsmtpemail)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail like :lV70Servidorsmtpwwds_17_tfservidorsmtpemail)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel)) && ! ( StringUtil.StrCmp(AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail = ( :AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel))");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( StringUtil.StrCmp(AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Servidorsmtpwwds_19_tfservidorsmtpusuario)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario like :lV72Servidorsmtpwwds_19_tfservidorsmtpusuario)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel)) && ! ( StringUtil.StrCmp(AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario = ( :AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel))");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( StringUtil.StrCmp(AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPUsuario))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ServidorSMTPEmail";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P008E5( IGxContext context ,
                                             string AV54Servidorsmtpwwds_1_filterfulltext ,
                                             string AV55Servidorsmtpwwds_2_dynamicfiltersselector1 ,
                                             short AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 ,
                                             string AV57Servidorsmtpwwds_4_servidorsmtpserver1 ,
                                             bool AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 ,
                                             string AV59Servidorsmtpwwds_6_dynamicfiltersselector2 ,
                                             short AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 ,
                                             string AV61Servidorsmtpwwds_8_servidorsmtpserver2 ,
                                             bool AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 ,
                                             string AV63Servidorsmtpwwds_10_dynamicfiltersselector3 ,
                                             short AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 ,
                                             string AV65Servidorsmtpwwds_12_servidorsmtpserver3 ,
                                             string AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel ,
                                             string AV66Servidorsmtpwwds_13_tfservidorsmtpserver ,
                                             string AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel ,
                                             string AV68Servidorsmtpwwds_15_tfservidorsmtpporta ,
                                             string AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel ,
                                             string AV70Servidorsmtpwwds_17_tfservidorsmtpemail ,
                                             string AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel ,
                                             string AV72Servidorsmtpwwds_19_tfservidorsmtpusuario ,
                                             string A159ServidorSMTPServer ,
                                             string A160ServidorSMTPPorta ,
                                             string A161ServidorSMTPEmail ,
                                             string A163ServidorSMTPUsuario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[18];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT ServidorSMTPUsuario, ServidorSMTPEmail, ServidorSMTPPorta, ServidorSMTPServer, ServidorSMTPId FROM ServidorSMTP";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Servidorsmtpwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ServidorSMTPServer like '%' || :lV54Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPPorta like '%' || :lV54Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPEmail like '%' || :lV54Servidorsmtpwwds_1_filterfulltext) or ( ServidorSMTPUsuario like '%' || :lV54Servidorsmtpwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Servidorsmtpwwds_2_dynamicfiltersselector1, "SERVIDORSMTPSERVER") == 0 ) && ( AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV57Servidorsmtpwwds_4_servidorsmtpserver1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Servidorsmtpwwds_2_dynamicfiltersselector1, "SERVIDORSMTPSERVER") == 0 ) && ( AV56Servidorsmtpwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Servidorsmtpwwds_4_servidorsmtpserver1)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV57Servidorsmtpwwds_4_servidorsmtpserver1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Servidorsmtpwwds_6_dynamicfiltersselector2, "SERVIDORSMTPSERVER") == 0 ) && ( AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV61Servidorsmtpwwds_8_servidorsmtpserver2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV58Servidorsmtpwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Servidorsmtpwwds_6_dynamicfiltersselector2, "SERVIDORSMTPSERVER") == 0 ) && ( AV60Servidorsmtpwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Servidorsmtpwwds_8_servidorsmtpserver2)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV61Servidorsmtpwwds_8_servidorsmtpserver2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Servidorsmtpwwds_10_dynamicfiltersselector3, "SERVIDORSMTPSERVER") == 0 ) && ( AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV65Servidorsmtpwwds_12_servidorsmtpserver3)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV62Servidorsmtpwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Servidorsmtpwwds_10_dynamicfiltersselector3, "SERVIDORSMTPSERVER") == 0 ) && ( AV64Servidorsmtpwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Servidorsmtpwwds_12_servidorsmtpserver3)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like '%' || :lV65Servidorsmtpwwds_12_servidorsmtpserver3)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Servidorsmtpwwds_13_tfservidorsmtpserver)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer like :lV66Servidorsmtpwwds_13_tfservidorsmtpserver)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel)) && ! ( StringUtil.StrCmp(AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer = ( :AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPServer IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPServer))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Servidorsmtpwwds_15_tfservidorsmtpporta)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta like :lV68Servidorsmtpwwds_15_tfservidorsmtpporta)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel)) && ! ( StringUtil.StrCmp(AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta = ( :AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel))");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( StringUtil.StrCmp(AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPPorta IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPPorta))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Servidorsmtpwwds_17_tfservidorsmtpemail)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail like :lV70Servidorsmtpwwds_17_tfservidorsmtpemail)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel)) && ! ( StringUtil.StrCmp(AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail = ( :AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel))");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( StringUtil.StrCmp(AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPEmail IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Servidorsmtpwwds_19_tfservidorsmtpusuario)) ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario like :lV72Servidorsmtpwwds_19_tfservidorsmtpusuario)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel)) && ! ( StringUtil.StrCmp(AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario = ( :AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel))");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( StringUtil.StrCmp(AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ServidorSMTPUsuario IS NULL or (char_length(trim(trailing ' ' from ServidorSMTPUsuario))=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY ServidorSMTPUsuario";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P008E2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] );
               case 1 :
                     return conditional_P008E3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] );
               case 2 :
                     return conditional_P008E4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] );
               case 3 :
                     return conditional_P008E5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP008E2;
          prmP008E2 = new Object[] {
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Servidorsmtpwwds_4_servidorsmtpserver1",GXType.VarChar,40,0) ,
          new ParDef("lV57Servidorsmtpwwds_4_servidorsmtpserver1",GXType.VarChar,40,0) ,
          new ParDef("lV61Servidorsmtpwwds_8_servidorsmtpserver2",GXType.VarChar,40,0) ,
          new ParDef("lV61Servidorsmtpwwds_8_servidorsmtpserver2",GXType.VarChar,40,0) ,
          new ParDef("lV65Servidorsmtpwwds_12_servidorsmtpserver3",GXType.VarChar,40,0) ,
          new ParDef("lV65Servidorsmtpwwds_12_servidorsmtpserver3",GXType.VarChar,40,0) ,
          new ParDef("lV66Servidorsmtpwwds_13_tfservidorsmtpserver",GXType.VarChar,40,0) ,
          new ParDef("AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Servidorsmtpwwds_15_tfservidorsmtpporta",GXType.VarChar,40,0) ,
          new ParDef("AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Servidorsmtpwwds_17_tfservidorsmtpemail",GXType.VarChar,100,0) ,
          new ParDef("AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV72Servidorsmtpwwds_19_tfservidorsmtpusuario",GXType.VarChar,90,0) ,
          new ParDef("AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel",GXType.VarChar,90,0)
          };
          Object[] prmP008E3;
          prmP008E3 = new Object[] {
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Servidorsmtpwwds_4_servidorsmtpserver1",GXType.VarChar,40,0) ,
          new ParDef("lV57Servidorsmtpwwds_4_servidorsmtpserver1",GXType.VarChar,40,0) ,
          new ParDef("lV61Servidorsmtpwwds_8_servidorsmtpserver2",GXType.VarChar,40,0) ,
          new ParDef("lV61Servidorsmtpwwds_8_servidorsmtpserver2",GXType.VarChar,40,0) ,
          new ParDef("lV65Servidorsmtpwwds_12_servidorsmtpserver3",GXType.VarChar,40,0) ,
          new ParDef("lV65Servidorsmtpwwds_12_servidorsmtpserver3",GXType.VarChar,40,0) ,
          new ParDef("lV66Servidorsmtpwwds_13_tfservidorsmtpserver",GXType.VarChar,40,0) ,
          new ParDef("AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Servidorsmtpwwds_15_tfservidorsmtpporta",GXType.VarChar,40,0) ,
          new ParDef("AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Servidorsmtpwwds_17_tfservidorsmtpemail",GXType.VarChar,100,0) ,
          new ParDef("AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV72Servidorsmtpwwds_19_tfservidorsmtpusuario",GXType.VarChar,90,0) ,
          new ParDef("AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel",GXType.VarChar,90,0)
          };
          Object[] prmP008E4;
          prmP008E4 = new Object[] {
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Servidorsmtpwwds_4_servidorsmtpserver1",GXType.VarChar,40,0) ,
          new ParDef("lV57Servidorsmtpwwds_4_servidorsmtpserver1",GXType.VarChar,40,0) ,
          new ParDef("lV61Servidorsmtpwwds_8_servidorsmtpserver2",GXType.VarChar,40,0) ,
          new ParDef("lV61Servidorsmtpwwds_8_servidorsmtpserver2",GXType.VarChar,40,0) ,
          new ParDef("lV65Servidorsmtpwwds_12_servidorsmtpserver3",GXType.VarChar,40,0) ,
          new ParDef("lV65Servidorsmtpwwds_12_servidorsmtpserver3",GXType.VarChar,40,0) ,
          new ParDef("lV66Servidorsmtpwwds_13_tfservidorsmtpserver",GXType.VarChar,40,0) ,
          new ParDef("AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Servidorsmtpwwds_15_tfservidorsmtpporta",GXType.VarChar,40,0) ,
          new ParDef("AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Servidorsmtpwwds_17_tfservidorsmtpemail",GXType.VarChar,100,0) ,
          new ParDef("AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV72Servidorsmtpwwds_19_tfservidorsmtpusuario",GXType.VarChar,90,0) ,
          new ParDef("AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel",GXType.VarChar,90,0)
          };
          Object[] prmP008E5;
          prmP008E5 = new Object[] {
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Servidorsmtpwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Servidorsmtpwwds_4_servidorsmtpserver1",GXType.VarChar,40,0) ,
          new ParDef("lV57Servidorsmtpwwds_4_servidorsmtpserver1",GXType.VarChar,40,0) ,
          new ParDef("lV61Servidorsmtpwwds_8_servidorsmtpserver2",GXType.VarChar,40,0) ,
          new ParDef("lV61Servidorsmtpwwds_8_servidorsmtpserver2",GXType.VarChar,40,0) ,
          new ParDef("lV65Servidorsmtpwwds_12_servidorsmtpserver3",GXType.VarChar,40,0) ,
          new ParDef("lV65Servidorsmtpwwds_12_servidorsmtpserver3",GXType.VarChar,40,0) ,
          new ParDef("lV66Servidorsmtpwwds_13_tfservidorsmtpserver",GXType.VarChar,40,0) ,
          new ParDef("AV67Servidorsmtpwwds_14_tfservidorsmtpserver_sel",GXType.VarChar,40,0) ,
          new ParDef("lV68Servidorsmtpwwds_15_tfservidorsmtpporta",GXType.VarChar,40,0) ,
          new ParDef("AV69Servidorsmtpwwds_16_tfservidorsmtpporta_sel",GXType.VarChar,40,0) ,
          new ParDef("lV70Servidorsmtpwwds_17_tfservidorsmtpemail",GXType.VarChar,100,0) ,
          new ParDef("AV71Servidorsmtpwwds_18_tfservidorsmtpemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV72Servidorsmtpwwds_19_tfservidorsmtpusuario",GXType.VarChar,90,0) ,
          new ParDef("AV73Servidorsmtpwwds_20_tfservidorsmtpusuario_sel",GXType.VarChar,90,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008E4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P008E5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008E5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((short[]) buf[8])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
