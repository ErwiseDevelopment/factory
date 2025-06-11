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
   public class aprovacaowwgetfilterdata : GXProcedure
   {
      public aprovacaowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprovacaowwgetfilterdata( IGxContext context )
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
         this.AV32DDOName = aP0_DDOName;
         this.AV33SearchTxtParms = aP1_SearchTxtParms;
         this.AV34SearchTxtTo = aP2_SearchTxtTo;
         this.AV35OptionsJson = "" ;
         this.AV36OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         initialize();
         ExecuteImpl();
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV37OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV32DDOName = aP0_DDOName;
         this.AV33SearchTxtParms = aP1_SearchTxtParms;
         this.AV34SearchTxtTo = aP2_SearchTxtTo;
         this.AV35OptionsJson = "" ;
         this.AV36OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV35OptionsJson;
         aP4_OptionsDescJson=this.AV36OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV22Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV19MaxItems = 10;
         AV18PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV33SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
         AV16SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV33SearchTxtParms)) ? "" : StringUtil.Substring( AV33SearchTxtParms, 3, -1));
         AV17SkipItems = (short)(AV18PageIndex*AV19MaxItems);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_SECUSERNAME") == 0 )
         {
            /* Execute user subroutine: 'LOADSECUSERNAMEOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_APROVACAODECISAO") == 0 )
         {
            /* Execute user subroutine: 'LOADAPROVACAODECISAOOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         AV35OptionsJson = AV22Options.ToJSonString(false);
         AV36OptionsDescJson = AV24OptionsDesc.ToJSonString(false);
         AV37OptionIndexesJson = AV25OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("AprovacaoWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "AprovacaoWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("AprovacaoWWGridState"), null, "", "");
         }
         AV41GXV1 = 1;
         while ( AV41GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV41GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV39TFSecUserName = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV40TFSecUserName_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFAPROVACAOEM") == 0 )
            {
               AV10TFAprovacaoEm = context.localUtil.CToT( AV30GridStateFilterValue.gxTpr_Value, 4);
               AV11TFAprovacaoEm_To = context.localUtil.CToT( AV30GridStateFilterValue.gxTpr_Valueto, 4);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFAPROVACAODECISAO") == 0 )
            {
               AV12TFAprovacaoDecisao = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFAPROVACAODECISAO_SEL") == 0 )
            {
               AV13TFAprovacaoDecisao_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFAPROVACAOSTATUS_SEL") == 0 )
            {
               AV14TFAprovacaoStatus_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV15TFAprovacaoStatus_Sels.FromJSonString(AV14TFAprovacaoStatus_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "PARM_&PROPOSTAID") == 0 )
            {
               AV38PropostaId = (int)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV41GXV1 = (int)(AV41GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADSECUSERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV39TFSecUserName = AV16SearchTxt;
         AV40TFSecUserName_Sel = "";
         AV43Aprovacaowwds_1_propostaid = AV38PropostaId;
         AV44Aprovacaowwds_2_tfsecusername = AV39TFSecUserName;
         AV45Aprovacaowwds_3_tfsecusername_sel = AV40TFSecUserName_Sel;
         AV46Aprovacaowwds_4_tfaprovacaoem = AV10TFAprovacaoEm;
         AV47Aprovacaowwds_5_tfaprovacaoem_to = AV11TFAprovacaoEm_To;
         AV48Aprovacaowwds_6_tfaprovacaodecisao = AV12TFAprovacaoDecisao;
         AV49Aprovacaowwds_7_tfaprovacaodecisao_sel = AV13TFAprovacaoDecisao_Sel;
         AV50Aprovacaowwds_8_tfaprovacaostatus_sels = AV15TFAprovacaoStatus_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A340AprovacaoStatus ,
                                              AV50Aprovacaowwds_8_tfaprovacaostatus_sels ,
                                              AV45Aprovacaowwds_3_tfsecusername_sel ,
                                              AV44Aprovacaowwds_2_tfsecusername ,
                                              AV46Aprovacaowwds_4_tfaprovacaoem ,
                                              AV47Aprovacaowwds_5_tfaprovacaoem_to ,
                                              AV49Aprovacaowwds_7_tfaprovacaodecisao_sel ,
                                              AV48Aprovacaowwds_6_tfaprovacaodecisao ,
                                              AV50Aprovacaowwds_8_tfaprovacaostatus_sels.Count ,
                                              A141SecUserName ,
                                              A337AprovacaoEm ,
                                              A338AprovacaoDecisao ,
                                              AV43Aprovacaowwds_1_propostaid ,
                                              A323PropostaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV44Aprovacaowwds_2_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV44Aprovacaowwds_2_tfsecusername), "%", "");
         lV48Aprovacaowwds_6_tfaprovacaodecisao = StringUtil.Concat( StringUtil.RTrim( AV48Aprovacaowwds_6_tfaprovacaodecisao), "%", "");
         /* Using cursor P009Y2 */
         pr_default.execute(0, new Object[] {AV43Aprovacaowwds_1_propostaid, lV44Aprovacaowwds_2_tfsecusername, AV45Aprovacaowwds_3_tfsecusername_sel, AV46Aprovacaowwds_4_tfaprovacaoem, AV47Aprovacaowwds_5_tfaprovacaoem_to, lV48Aprovacaowwds_6_tfaprovacaodecisao, AV49Aprovacaowwds_7_tfaprovacaodecisao_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK9Y2 = false;
            A328PropostaCratedBy = P009Y2_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P009Y2_n328PropostaCratedBy[0];
            A323PropostaId = P009Y2_A323PropostaId[0];
            n323PropostaId = P009Y2_n323PropostaId[0];
            A141SecUserName = P009Y2_A141SecUserName[0];
            n141SecUserName = P009Y2_n141SecUserName[0];
            A340AprovacaoStatus = P009Y2_A340AprovacaoStatus[0];
            n340AprovacaoStatus = P009Y2_n340AprovacaoStatus[0];
            A338AprovacaoDecisao = P009Y2_A338AprovacaoDecisao[0];
            n338AprovacaoDecisao = P009Y2_n338AprovacaoDecisao[0];
            A337AprovacaoEm = P009Y2_A337AprovacaoEm[0];
            n337AprovacaoEm = P009Y2_n337AprovacaoEm[0];
            A336AprovacaoId = P009Y2_A336AprovacaoId[0];
            A328PropostaCratedBy = P009Y2_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P009Y2_n328PropostaCratedBy[0];
            A141SecUserName = P009Y2_A141SecUserName[0];
            n141SecUserName = P009Y2_n141SecUserName[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P009Y2_A323PropostaId[0] == A323PropostaId ) && ( StringUtil.StrCmp(P009Y2_A141SecUserName[0], A141SecUserName) == 0 ) )
            {
               BRK9Y2 = false;
               A328PropostaCratedBy = P009Y2_A328PropostaCratedBy[0];
               n328PropostaCratedBy = P009Y2_n328PropostaCratedBy[0];
               A336AprovacaoId = P009Y2_A336AprovacaoId[0];
               A328PropostaCratedBy = P009Y2_A328PropostaCratedBy[0];
               n328PropostaCratedBy = P009Y2_n328PropostaCratedBy[0];
               AV26count = (long)(AV26count+1);
               BRK9Y2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A141SecUserName)) ? "<#Empty#>" : A141SecUserName);
               AV23OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A141SecUserName, "@!")));
               AV22Options.Add(AV21Option, 0);
               AV24OptionsDesc.Add(AV23OptionDesc, 0);
               AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV22Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV17SkipItems = (short)(AV17SkipItems-1);
            }
            if ( ! BRK9Y2 )
            {
               BRK9Y2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADAPROVACAODECISAOOPTIONS' Routine */
         returnInSub = false;
         AV12TFAprovacaoDecisao = AV16SearchTxt;
         AV13TFAprovacaoDecisao_Sel = "";
         AV43Aprovacaowwds_1_propostaid = AV38PropostaId;
         AV44Aprovacaowwds_2_tfsecusername = AV39TFSecUserName;
         AV45Aprovacaowwds_3_tfsecusername_sel = AV40TFSecUserName_Sel;
         AV46Aprovacaowwds_4_tfaprovacaoem = AV10TFAprovacaoEm;
         AV47Aprovacaowwds_5_tfaprovacaoem_to = AV11TFAprovacaoEm_To;
         AV48Aprovacaowwds_6_tfaprovacaodecisao = AV12TFAprovacaoDecisao;
         AV49Aprovacaowwds_7_tfaprovacaodecisao_sel = AV13TFAprovacaoDecisao_Sel;
         AV50Aprovacaowwds_8_tfaprovacaostatus_sels = AV15TFAprovacaoStatus_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A340AprovacaoStatus ,
                                              AV50Aprovacaowwds_8_tfaprovacaostatus_sels ,
                                              AV45Aprovacaowwds_3_tfsecusername_sel ,
                                              AV44Aprovacaowwds_2_tfsecusername ,
                                              AV46Aprovacaowwds_4_tfaprovacaoem ,
                                              AV47Aprovacaowwds_5_tfaprovacaoem_to ,
                                              AV49Aprovacaowwds_7_tfaprovacaodecisao_sel ,
                                              AV48Aprovacaowwds_6_tfaprovacaodecisao ,
                                              AV50Aprovacaowwds_8_tfaprovacaostatus_sels.Count ,
                                              A141SecUserName ,
                                              A337AprovacaoEm ,
                                              A338AprovacaoDecisao ,
                                              AV43Aprovacaowwds_1_propostaid ,
                                              A323PropostaId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV44Aprovacaowwds_2_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV44Aprovacaowwds_2_tfsecusername), "%", "");
         lV48Aprovacaowwds_6_tfaprovacaodecisao = StringUtil.Concat( StringUtil.RTrim( AV48Aprovacaowwds_6_tfaprovacaodecisao), "%", "");
         /* Using cursor P009Y3 */
         pr_default.execute(1, new Object[] {AV43Aprovacaowwds_1_propostaid, lV44Aprovacaowwds_2_tfsecusername, AV45Aprovacaowwds_3_tfsecusername_sel, AV46Aprovacaowwds_4_tfaprovacaoem, AV47Aprovacaowwds_5_tfaprovacaoem_to, lV48Aprovacaowwds_6_tfaprovacaodecisao, AV49Aprovacaowwds_7_tfaprovacaodecisao_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK9Y4 = false;
            A328PropostaCratedBy = P009Y3_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P009Y3_n328PropostaCratedBy[0];
            A323PropostaId = P009Y3_A323PropostaId[0];
            n323PropostaId = P009Y3_n323PropostaId[0];
            A338AprovacaoDecisao = P009Y3_A338AprovacaoDecisao[0];
            n338AprovacaoDecisao = P009Y3_n338AprovacaoDecisao[0];
            A340AprovacaoStatus = P009Y3_A340AprovacaoStatus[0];
            n340AprovacaoStatus = P009Y3_n340AprovacaoStatus[0];
            A337AprovacaoEm = P009Y3_A337AprovacaoEm[0];
            n337AprovacaoEm = P009Y3_n337AprovacaoEm[0];
            A141SecUserName = P009Y3_A141SecUserName[0];
            n141SecUserName = P009Y3_n141SecUserName[0];
            A336AprovacaoId = P009Y3_A336AprovacaoId[0];
            A328PropostaCratedBy = P009Y3_A328PropostaCratedBy[0];
            n328PropostaCratedBy = P009Y3_n328PropostaCratedBy[0];
            A141SecUserName = P009Y3_A141SecUserName[0];
            n141SecUserName = P009Y3_n141SecUserName[0];
            AV26count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P009Y3_A323PropostaId[0] == A323PropostaId ) && ( StringUtil.StrCmp(P009Y3_A338AprovacaoDecisao[0], A338AprovacaoDecisao) == 0 ) )
            {
               BRK9Y4 = false;
               A336AprovacaoId = P009Y3_A336AprovacaoId[0];
               AV26count = (long)(AV26count+1);
               BRK9Y4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV17SkipItems) )
            {
               AV21Option = (String.IsNullOrEmpty(StringUtil.RTrim( A338AprovacaoDecisao)) ? "<#Empty#>" : A338AprovacaoDecisao);
               AV22Options.Add(AV21Option, 0);
               AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV22Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV17SkipItems = (short)(AV17SkipItems-1);
            }
            if ( ! BRK9Y4 )
            {
               BRK9Y4 = true;
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
         AV35OptionsJson = "";
         AV36OptionsDescJson = "";
         AV37OptionIndexesJson = "";
         AV22Options = new GxSimpleCollection<string>();
         AV24OptionsDesc = new GxSimpleCollection<string>();
         AV25OptionIndexes = new GxSimpleCollection<string>();
         AV16SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV39TFSecUserName = "";
         AV40TFSecUserName_Sel = "";
         AV10TFAprovacaoEm = (DateTime)(DateTime.MinValue);
         AV11TFAprovacaoEm_To = (DateTime)(DateTime.MinValue);
         AV12TFAprovacaoDecisao = "";
         AV13TFAprovacaoDecisao_Sel = "";
         AV14TFAprovacaoStatus_SelsJson = "";
         AV15TFAprovacaoStatus_Sels = new GxSimpleCollection<string>();
         AV44Aprovacaowwds_2_tfsecusername = "";
         AV45Aprovacaowwds_3_tfsecusername_sel = "";
         AV46Aprovacaowwds_4_tfaprovacaoem = (DateTime)(DateTime.MinValue);
         AV47Aprovacaowwds_5_tfaprovacaoem_to = (DateTime)(DateTime.MinValue);
         AV48Aprovacaowwds_6_tfaprovacaodecisao = "";
         AV49Aprovacaowwds_7_tfaprovacaodecisao_sel = "";
         AV50Aprovacaowwds_8_tfaprovacaostatus_sels = new GxSimpleCollection<string>();
         lV44Aprovacaowwds_2_tfsecusername = "";
         lV48Aprovacaowwds_6_tfaprovacaodecisao = "";
         A340AprovacaoStatus = "";
         A141SecUserName = "";
         A337AprovacaoEm = (DateTime)(DateTime.MinValue);
         A338AprovacaoDecisao = "";
         P009Y2_A328PropostaCratedBy = new short[1] ;
         P009Y2_n328PropostaCratedBy = new bool[] {false} ;
         P009Y2_A323PropostaId = new int[1] ;
         P009Y2_n323PropostaId = new bool[] {false} ;
         P009Y2_A141SecUserName = new string[] {""} ;
         P009Y2_n141SecUserName = new bool[] {false} ;
         P009Y2_A340AprovacaoStatus = new string[] {""} ;
         P009Y2_n340AprovacaoStatus = new bool[] {false} ;
         P009Y2_A338AprovacaoDecisao = new string[] {""} ;
         P009Y2_n338AprovacaoDecisao = new bool[] {false} ;
         P009Y2_A337AprovacaoEm = new DateTime[] {DateTime.MinValue} ;
         P009Y2_n337AprovacaoEm = new bool[] {false} ;
         P009Y2_A336AprovacaoId = new int[1] ;
         AV21Option = "";
         AV23OptionDesc = "";
         P009Y3_A328PropostaCratedBy = new short[1] ;
         P009Y3_n328PropostaCratedBy = new bool[] {false} ;
         P009Y3_A323PropostaId = new int[1] ;
         P009Y3_n323PropostaId = new bool[] {false} ;
         P009Y3_A338AprovacaoDecisao = new string[] {""} ;
         P009Y3_n338AprovacaoDecisao = new bool[] {false} ;
         P009Y3_A340AprovacaoStatus = new string[] {""} ;
         P009Y3_n340AprovacaoStatus = new bool[] {false} ;
         P009Y3_A337AprovacaoEm = new DateTime[] {DateTime.MinValue} ;
         P009Y3_n337AprovacaoEm = new bool[] {false} ;
         P009Y3_A141SecUserName = new string[] {""} ;
         P009Y3_n141SecUserName = new bool[] {false} ;
         P009Y3_A336AprovacaoId = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprovacaowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P009Y2_A328PropostaCratedBy, P009Y2_n328PropostaCratedBy, P009Y2_A323PropostaId, P009Y2_n323PropostaId, P009Y2_A141SecUserName, P009Y2_n141SecUserName, P009Y2_A340AprovacaoStatus, P009Y2_n340AprovacaoStatus, P009Y2_A338AprovacaoDecisao, P009Y2_n338AprovacaoDecisao,
               P009Y2_A337AprovacaoEm, P009Y2_n337AprovacaoEm, P009Y2_A336AprovacaoId
               }
               , new Object[] {
               P009Y3_A328PropostaCratedBy, P009Y3_n328PropostaCratedBy, P009Y3_A323PropostaId, P009Y3_n323PropostaId, P009Y3_A338AprovacaoDecisao, P009Y3_n338AprovacaoDecisao, P009Y3_A340AprovacaoStatus, P009Y3_n340AprovacaoStatus, P009Y3_A337AprovacaoEm, P009Y3_n337AprovacaoEm,
               P009Y3_A141SecUserName, P009Y3_n141SecUserName, P009Y3_A336AprovacaoId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19MaxItems ;
      private short AV18PageIndex ;
      private short AV17SkipItems ;
      private short A328PropostaCratedBy ;
      private int AV41GXV1 ;
      private int AV38PropostaId ;
      private int AV43Aprovacaowwds_1_propostaid ;
      private int AV50Aprovacaowwds_8_tfaprovacaostatus_sels_Count ;
      private int A323PropostaId ;
      private int A336AprovacaoId ;
      private long AV26count ;
      private DateTime AV10TFAprovacaoEm ;
      private DateTime AV11TFAprovacaoEm_To ;
      private DateTime AV46Aprovacaowwds_4_tfaprovacaoem ;
      private DateTime AV47Aprovacaowwds_5_tfaprovacaoem_to ;
      private DateTime A337AprovacaoEm ;
      private bool returnInSub ;
      private bool BRK9Y2 ;
      private bool n328PropostaCratedBy ;
      private bool n323PropostaId ;
      private bool n141SecUserName ;
      private bool n340AprovacaoStatus ;
      private bool n338AprovacaoDecisao ;
      private bool n337AprovacaoEm ;
      private bool BRK9Y4 ;
      private string AV35OptionsJson ;
      private string AV36OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV14TFAprovacaoStatus_SelsJson ;
      private string AV32DDOName ;
      private string AV33SearchTxtParms ;
      private string AV34SearchTxtTo ;
      private string AV16SearchTxt ;
      private string AV39TFSecUserName ;
      private string AV40TFSecUserName_Sel ;
      private string AV12TFAprovacaoDecisao ;
      private string AV13TFAprovacaoDecisao_Sel ;
      private string AV44Aprovacaowwds_2_tfsecusername ;
      private string AV45Aprovacaowwds_3_tfsecusername_sel ;
      private string AV48Aprovacaowwds_6_tfaprovacaodecisao ;
      private string AV49Aprovacaowwds_7_tfaprovacaodecisao_sel ;
      private string lV44Aprovacaowwds_2_tfsecusername ;
      private string lV48Aprovacaowwds_6_tfaprovacaodecisao ;
      private string A340AprovacaoStatus ;
      private string A141SecUserName ;
      private string A338AprovacaoDecisao ;
      private string AV21Option ;
      private string AV23OptionDesc ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV22Options ;
      private GxSimpleCollection<string> AV24OptionsDesc ;
      private GxSimpleCollection<string> AV25OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GxSimpleCollection<string> AV15TFAprovacaoStatus_Sels ;
      private GxSimpleCollection<string> AV50Aprovacaowwds_8_tfaprovacaostatus_sels ;
      private IDataStoreProvider pr_default ;
      private short[] P009Y2_A328PropostaCratedBy ;
      private bool[] P009Y2_n328PropostaCratedBy ;
      private int[] P009Y2_A323PropostaId ;
      private bool[] P009Y2_n323PropostaId ;
      private string[] P009Y2_A141SecUserName ;
      private bool[] P009Y2_n141SecUserName ;
      private string[] P009Y2_A340AprovacaoStatus ;
      private bool[] P009Y2_n340AprovacaoStatus ;
      private string[] P009Y2_A338AprovacaoDecisao ;
      private bool[] P009Y2_n338AprovacaoDecisao ;
      private DateTime[] P009Y2_A337AprovacaoEm ;
      private bool[] P009Y2_n337AprovacaoEm ;
      private int[] P009Y2_A336AprovacaoId ;
      private short[] P009Y3_A328PropostaCratedBy ;
      private bool[] P009Y3_n328PropostaCratedBy ;
      private int[] P009Y3_A323PropostaId ;
      private bool[] P009Y3_n323PropostaId ;
      private string[] P009Y3_A338AprovacaoDecisao ;
      private bool[] P009Y3_n338AprovacaoDecisao ;
      private string[] P009Y3_A340AprovacaoStatus ;
      private bool[] P009Y3_n340AprovacaoStatus ;
      private DateTime[] P009Y3_A337AprovacaoEm ;
      private bool[] P009Y3_n337AprovacaoEm ;
      private string[] P009Y3_A141SecUserName ;
      private bool[] P009Y3_n141SecUserName ;
      private int[] P009Y3_A336AprovacaoId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class aprovacaowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P009Y2( IGxContext context ,
                                             string A340AprovacaoStatus ,
                                             GxSimpleCollection<string> AV50Aprovacaowwds_8_tfaprovacaostatus_sels ,
                                             string AV45Aprovacaowwds_3_tfsecusername_sel ,
                                             string AV44Aprovacaowwds_2_tfsecusername ,
                                             DateTime AV46Aprovacaowwds_4_tfaprovacaoem ,
                                             DateTime AV47Aprovacaowwds_5_tfaprovacaoem_to ,
                                             string AV49Aprovacaowwds_7_tfaprovacaodecisao_sel ,
                                             string AV48Aprovacaowwds_6_tfaprovacaodecisao ,
                                             int AV50Aprovacaowwds_8_tfaprovacaostatus_sels_Count ,
                                             string A141SecUserName ,
                                             DateTime A337AprovacaoEm ,
                                             string A338AprovacaoDecisao ,
                                             int AV43Aprovacaowwds_1_propostaid ,
                                             int A323PropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T2.PropostaCratedBy AS PropostaCratedBy, T1.PropostaId, T3.SecUserName, T1.AprovacaoStatus, T1.AprovacaoDecisao, T1.AprovacaoEm, T1.AprovacaoId FROM ((Aprovacao T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.PropostaId) LEFT JOIN SecUser T3 ON T3.SecUserId = T2.PropostaCratedBy)";
         AddWhere(sWhereString, "(T1.PropostaId = :AV43Aprovacaowwds_1_propostaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Aprovacaowwds_3_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Aprovacaowwds_2_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV44Aprovacaowwds_2_tfsecusername)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Aprovacaowwds_3_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV45Aprovacaowwds_3_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV45Aprovacaowwds_3_tfsecusername_sel))");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( StringUtil.StrCmp(AV45Aprovacaowwds_3_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV46Aprovacaowwds_4_tfaprovacaoem) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoEm >= :AV46Aprovacaowwds_4_tfaprovacaoem)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV47Aprovacaowwds_5_tfaprovacaoem_to) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoEm <= :AV47Aprovacaowwds_5_tfaprovacaoem_to)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Aprovacaowwds_7_tfaprovacaodecisao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Aprovacaowwds_6_tfaprovacaodecisao)) ) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoDecisao like :lV48Aprovacaowwds_6_tfaprovacaodecisao)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Aprovacaowwds_7_tfaprovacaodecisao_sel)) && ! ( StringUtil.StrCmp(AV49Aprovacaowwds_7_tfaprovacaodecisao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoDecisao = ( :AV49Aprovacaowwds_7_tfaprovacaodecisao_sel))");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( StringUtil.StrCmp(AV49Aprovacaowwds_7_tfaprovacaodecisao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.AprovacaoDecisao IS NULL or (char_length(trim(trailing ' ' from T1.AprovacaoDecisao))=0))");
         }
         if ( AV50Aprovacaowwds_8_tfaprovacaostatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV50Aprovacaowwds_8_tfaprovacaostatus_sels, "T1.AprovacaoStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PropostaId, T3.SecUserName";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P009Y3( IGxContext context ,
                                             string A340AprovacaoStatus ,
                                             GxSimpleCollection<string> AV50Aprovacaowwds_8_tfaprovacaostatus_sels ,
                                             string AV45Aprovacaowwds_3_tfsecusername_sel ,
                                             string AV44Aprovacaowwds_2_tfsecusername ,
                                             DateTime AV46Aprovacaowwds_4_tfaprovacaoem ,
                                             DateTime AV47Aprovacaowwds_5_tfaprovacaoem_to ,
                                             string AV49Aprovacaowwds_7_tfaprovacaodecisao_sel ,
                                             string AV48Aprovacaowwds_6_tfaprovacaodecisao ,
                                             int AV50Aprovacaowwds_8_tfaprovacaostatus_sels_Count ,
                                             string A141SecUserName ,
                                             DateTime A337AprovacaoEm ,
                                             string A338AprovacaoDecisao ,
                                             int AV43Aprovacaowwds_1_propostaid ,
                                             int A323PropostaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.PropostaCratedBy AS PropostaCratedBy, T1.PropostaId, T1.AprovacaoDecisao, T1.AprovacaoStatus, T1.AprovacaoEm, T3.SecUserName, T1.AprovacaoId FROM ((Aprovacao T1 LEFT JOIN Proposta T2 ON T2.PropostaId = T1.PropostaId) LEFT JOIN SecUser T3 ON T3.SecUserId = T2.PropostaCratedBy)";
         AddWhere(sWhereString, "(T1.PropostaId = :AV43Aprovacaowwds_1_propostaid)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV45Aprovacaowwds_3_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44Aprovacaowwds_2_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName like :lV44Aprovacaowwds_2_tfsecusername)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Aprovacaowwds_3_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV45Aprovacaowwds_3_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.SecUserName = ( :AV45Aprovacaowwds_3_tfsecusername_sel))");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( StringUtil.StrCmp(AV45Aprovacaowwds_3_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.SecUserName IS NULL or (char_length(trim(trailing ' ' from T3.SecUserName))=0))");
         }
         if ( ! (DateTime.MinValue==AV46Aprovacaowwds_4_tfaprovacaoem) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoEm >= :AV46Aprovacaowwds_4_tfaprovacaoem)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV47Aprovacaowwds_5_tfaprovacaoem_to) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoEm <= :AV47Aprovacaowwds_5_tfaprovacaoem_to)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV49Aprovacaowwds_7_tfaprovacaodecisao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Aprovacaowwds_6_tfaprovacaodecisao)) ) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoDecisao like :lV48Aprovacaowwds_6_tfaprovacaodecisao)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Aprovacaowwds_7_tfaprovacaodecisao_sel)) && ! ( StringUtil.StrCmp(AV49Aprovacaowwds_7_tfaprovacaodecisao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.AprovacaoDecisao = ( :AV49Aprovacaowwds_7_tfaprovacaodecisao_sel))");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( StringUtil.StrCmp(AV49Aprovacaowwds_7_tfaprovacaodecisao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.AprovacaoDecisao IS NULL or (char_length(trim(trailing ' ' from T1.AprovacaoDecisao))=0))");
         }
         if ( AV50Aprovacaowwds_8_tfaprovacaostatus_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV50Aprovacaowwds_8_tfaprovacaostatus_sels, "T1.AprovacaoStatus IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.PropostaId, T1.AprovacaoDecisao";
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
                     return conditional_P009Y2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] );
               case 1 :
                     return conditional_P009Y3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] );
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
          Object[] prmP009Y2;
          prmP009Y2 = new Object[] {
          new ParDef("AV43Aprovacaowwds_1_propostaid",GXType.Int32,9,0) ,
          new ParDef("lV44Aprovacaowwds_2_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV45Aprovacaowwds_3_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("AV46Aprovacaowwds_4_tfaprovacaoem",GXType.DateTime,10,8) ,
          new ParDef("AV47Aprovacaowwds_5_tfaprovacaoem_to",GXType.DateTime,10,8) ,
          new ParDef("lV48Aprovacaowwds_6_tfaprovacaodecisao",GXType.VarChar,255,0) ,
          new ParDef("AV49Aprovacaowwds_7_tfaprovacaodecisao_sel",GXType.VarChar,255,0)
          };
          Object[] prmP009Y3;
          prmP009Y3 = new Object[] {
          new ParDef("AV43Aprovacaowwds_1_propostaid",GXType.Int32,9,0) ,
          new ParDef("lV44Aprovacaowwds_2_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("AV45Aprovacaowwds_3_tfsecusername_sel",GXType.VarChar,100,0) ,
          new ParDef("AV46Aprovacaowwds_4_tfaprovacaoem",GXType.DateTime,10,8) ,
          new ParDef("AV47Aprovacaowwds_5_tfaprovacaoem_to",GXType.DateTime,10,8) ,
          new ParDef("lV48Aprovacaowwds_6_tfaprovacaodecisao",GXType.VarChar,255,0) ,
          new ParDef("AV49Aprovacaowwds_7_tfaprovacaodecisao_sel",GXType.VarChar,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P009Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Y3,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getVarchar(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((int[]) buf[2])[0] = rslt.getInt(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getVarchar(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
       }
    }

 }

}
